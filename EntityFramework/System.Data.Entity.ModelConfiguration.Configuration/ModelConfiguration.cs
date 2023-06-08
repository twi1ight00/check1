using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration.Types;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Configuration;

[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
internal class ModelConfiguration : ConfigurationBase
{
	private readonly Dictionary<Type, EntityTypeConfiguration> _entityConfigurations = new Dictionary<Type, EntityTypeConfiguration>();

	private readonly Dictionary<Type, ComplexTypeConfiguration> _complexTypeConfigurations = new Dictionary<Type, ComplexTypeConfiguration>();

	private readonly HashSet<Type> _ignoredTypes = new HashSet<Type>();

	internal virtual IEnumerable<Type> ConfiguredTypes => _entityConfigurations.Keys.Union(_complexTypeConfigurations.Keys).Union(_ignoredTypes);

	internal virtual IEnumerable<Type> Entities => _entityConfigurations.Keys.Except(_ignoredTypes).ToList();

	internal virtual IEnumerable<Type> ComplexTypes => _complexTypeConfigurations.Keys.Except(_ignoredTypes).ToList();

	internal virtual IEnumerable<Type> StructuralTypes => _entityConfigurations.Keys.Union(_complexTypeConfigurations.Keys).Except(_ignoredTypes).ToList();

	private IEnumerable<EntityTypeConfiguration> ActiveEntityConfigurations => (from keyValuePair in _entityConfigurations
		where !_ignoredTypes.Contains(keyValuePair.Key)
		select keyValuePair.Value).ToList();

	private IEnumerable<ComplexTypeConfiguration> ActiveComplexTypeConfigurations => (from keyValuePair in _complexTypeConfigurations
		where !_ignoredTypes.Contains(keyValuePair.Key)
		select keyValuePair.Value).ToList();

	internal ModelConfiguration()
	{
	}

	private ModelConfiguration(ModelConfiguration source)
	{
		Dictionary<Type, EntityTypeConfiguration> entityConfigurations = source._entityConfigurations;
		Action<KeyValuePair<Type, EntityTypeConfiguration>> action = delegate(KeyValuePair<Type, EntityTypeConfiguration> c)
		{
			_entityConfigurations.Add(c.Key, c.Value.Clone());
		};
		entityConfigurations.Each(action);
		source._complexTypeConfigurations.Each(delegate(KeyValuePair<Type, ComplexTypeConfiguration> c)
		{
			_complexTypeConfigurations.Add(c.Key, c.Value.Clone());
		});
		_ignoredTypes.AddRange(source._ignoredTypes);
	}

	internal virtual ModelConfiguration Clone()
	{
		return new ModelConfiguration(this);
	}

	internal virtual void Add(EntityTypeConfiguration entityTypeConfiguration)
	{
		if ((_entityConfigurations.TryGetValue(entityTypeConfiguration.ClrType, out var value) && !value.IsReplaceable) || _complexTypeConfigurations.ContainsKey(entityTypeConfiguration.ClrType))
		{
			throw Error.DuplicateStructuralTypeConfiguration(entityTypeConfiguration.ClrType);
		}
		if (value != null && value.IsReplaceable)
		{
			_entityConfigurations.Remove(value.ClrType);
			entityTypeConfiguration.ReplaceFrom(value);
		}
		else
		{
			entityTypeConfiguration.IsReplaceable = false;
		}
		_entityConfigurations.Add(entityTypeConfiguration.ClrType, entityTypeConfiguration);
	}

	internal virtual void Add(ComplexTypeConfiguration complexTypeConfiguration)
	{
		if (_entityConfigurations.ContainsKey(complexTypeConfiguration.ClrType) || _complexTypeConfigurations.ContainsKey(complexTypeConfiguration.ClrType))
		{
			throw Error.DuplicateStructuralTypeConfiguration(complexTypeConfiguration.ClrType);
		}
		_complexTypeConfigurations.Add(complexTypeConfiguration.ClrType, complexTypeConfiguration);
	}

	internal virtual EntityTypeConfiguration Entity(Type entityType, bool explicitEntity = false)
	{
		if (_complexTypeConfigurations.ContainsKey(entityType))
		{
			throw Error.EntityTypeConfigurationMismatch(entityType.FullName);
		}
		if (!_entityConfigurations.TryGetValue(entityType, out var value))
		{
			_entityConfigurations.Add(entityType, value = new EntityTypeConfiguration(entityType)
			{
				IsExplicitEntity = explicitEntity
			});
		}
		return value;
	}

	[SuppressMessage("Microsoft.Naming", "CA1719:ParameterNamesShouldNotMatchMemberNames", MessageId = "0#")]
	public virtual ComplexTypeConfiguration ComplexType(Type complexType)
	{
		if (_entityConfigurations.ContainsKey(complexType))
		{
			throw Error.ComplexTypeConfigurationMismatch(complexType.FullName);
		}
		if (!_complexTypeConfigurations.TryGetValue(complexType, out var value))
		{
			_complexTypeConfigurations.Add(complexType, value = new ComplexTypeConfiguration(complexType));
		}
		return value;
	}

	public virtual void Ignore(Type type)
	{
		_ignoredTypes.Add(type);
	}

	internal virtual StructuralTypeConfiguration GetStructuralTypeConfiguration(Type type)
	{
		if (_entityConfigurations.TryGetValue(type, out var value))
		{
			return value;
		}
		if (_complexTypeConfigurations.TryGetValue(type, out var value2))
		{
			return value2;
		}
		return null;
	}

	internal virtual bool IsComplexType(Type type)
	{
		return _complexTypeConfigurations.ContainsKey(type);
	}

	internal virtual bool IsIgnoredType(Type type)
	{
		return _ignoredTypes.Contains(type);
	}

	internal virtual IEnumerable<PropertyInfo> GetConfiguredProperties(Type type)
	{
		StructuralTypeConfiguration structuralTypeConfiguration = GetStructuralTypeConfiguration(type);
		if (structuralTypeConfiguration == null)
		{
			return Enumerable.Empty<PropertyInfo>();
		}
		return structuralTypeConfiguration.ConfiguredProperties;
	}

	internal virtual bool IsIgnoredProperty(Type type, PropertyInfo propertyInfo)
	{
		return GetStructuralTypeConfiguration(type)?.IgnoredProperties.Any((PropertyInfo p) => p.IsSameAs(propertyInfo)) ?? false;
	}

	internal void Configure(EdmModel model)
	{
		ConfigureEntities(model);
		ConfigureComplexTypes(model);
	}

	internal void ConfigureEntities(EdmModel model)
	{
		foreach (EntityTypeConfiguration activeEntityConfiguration in ActiveEntityConfigurations)
		{
			Type clrType = activeEntityConfiguration.ClrType;
			EdmEntityType entityType = model.GetEntityType(clrType);
			activeEntityConfiguration.Configure(entityType, model);
		}
	}

	private void ConfigureComplexTypes(EdmModel model)
	{
		foreach (ComplexTypeConfiguration activeComplexTypeConfiguration in ActiveComplexTypeConfigurations)
		{
			EdmComplexType complexType = model.GetComplexType(activeComplexTypeConfiguration.ClrType);
			activeComplexTypeConfiguration.Configure(complexType);
		}
	}

	internal void Configure(DbDatabaseMapping databaseMapping, DbProviderManifest providerManifest)
	{
		foreach (StructuralTypeConfiguration item in from StructuralTypeConfiguration c in from ct in databaseMapping.Model.GetComplexTypes()
				select ct.GetConfiguration()
			where c != null
			select c)
		{
			item.Configure(databaseMapping.GetComplexPropertyMappings(item.ClrType), providerManifest);
		}
		ConfigureEntityTypes(databaseMapping, providerManifest);
		RemoveRedundantColumnConditions(databaseMapping);
		ConfigureTables(databaseMapping.Database);
	}

	private void ConfigureEntityTypes(DbDatabaseMapping databaseMapping, DbProviderManifest providerManifest)
	{
		IEnumerable<EntityTypeConfiguration> enumerable = SortEntityConfigurationsByInheritance(databaseMapping);
		foreach (EntityTypeConfiguration item in enumerable)
		{
			DbEntityTypeMapping entityTypeMapping = databaseMapping.GetEntityTypeMapping(item.ClrType);
			item.ConfigureTablesAndConditions(entityTypeMapping, databaseMapping, providerManifest);
			ConfigureUnconfiguredDerivedTypes(databaseMapping, providerManifest, databaseMapping.Model.GetEntityType(item.ClrType), enumerable);
		}
		new EntityMappingService(databaseMapping).Configure();
		foreach (EdmEntityType item2 in from e in databaseMapping.Model.GetEntityTypes()
			where e.GetConfiguration() != null
			select e)
		{
			EntityTypeConfiguration entityTypeConfiguration = (EntityTypeConfiguration)item2.GetConfiguration();
			entityTypeConfiguration.Configure(item2, databaseMapping, providerManifest);
		}
	}

	private static void ConfigureUnconfiguredDerivedTypes(DbDatabaseMapping databaseMapping, DbProviderManifest providerManifest, EdmEntityType entityType, IEnumerable<EntityTypeConfiguration> sortedEntityConfigurations)
	{
		List<EdmEntityType> list = databaseMapping.Model.GetDerivedTypes(entityType).ToList();
		while (list.Count > 0)
		{
			EdmEntityType currentType = list[0];
			list.RemoveAt(0);
			if (!currentType.IsAbstract && !sortedEntityConfigurations.Any((EntityTypeConfiguration etc) => etc.ClrType == currentType.GetClrType()))
			{
				EntityTypeConfiguration.ConfigureUnconfiguredType(databaseMapping, providerManifest, currentType);
				list.AddRange(databaseMapping.Model.GetDerivedTypes(currentType));
			}
		}
	}

	private static void ConfigureTables(DbDatabaseMetadata database)
	{
		DbSchemaMetadata dbSchemaMetadata = database.Schemas.Single();
		foreach (DbTableMetadata item in dbSchemaMetadata.Tables.ToList())
		{
			ConfigureTable(database, dbSchemaMetadata, item);
		}
	}

	private static void ConfigureTable(DbDatabaseMetadata database, DbSchemaMetadata containingSchema, DbTableMetadata table)
	{
		DatabaseName tableName = table.GetTableName();
		if (tableName == null)
		{
			return;
		}
		if (!string.IsNullOrWhiteSpace(tableName.Schema) && !string.Equals(containingSchema.Name, tableName.Schema, StringComparison.Ordinal))
		{
			containingSchema = database.Schemas.SingleOrDefault((DbSchemaMetadata s) => string.Equals(s.Name, tableName.Schema, StringComparison.Ordinal));
			if (containingSchema == null)
			{
				database.Schemas.Add(containingSchema = new DbSchemaMetadata
				{
					Name = tableName.Schema,
					DatabaseIdentifier = tableName.Schema
				});
			}
			database.RemoveTable(table);
			containingSchema.Tables.Add(table);
		}
		if (!string.Equals(table.DatabaseIdentifier, tableName.Name, StringComparison.Ordinal))
		{
			table.DatabaseIdentifier = tableName.Name;
		}
	}

	private IEnumerable<EntityTypeConfiguration> SortEntityConfigurationsByInheritance(DbDatabaseMapping databaseMapping)
	{
		List<EntityTypeConfiguration> list = new List<EntityTypeConfiguration>();
		foreach (EntityTypeConfiguration activeEntityConfiguration in ActiveEntityConfigurations)
		{
			EdmEntityType entityType = databaseMapping.Model.GetEntityType(activeEntityConfiguration.ClrType);
			if (entityType == null)
			{
				continue;
			}
			if (entityType.BaseType == null)
			{
				if (!list.Contains(activeEntityConfiguration))
				{
					list.Add(activeEntityConfiguration);
				}
				continue;
			}
			Stack<EdmEntityType> stack = new Stack<EdmEntityType>();
			while (entityType != null)
			{
				stack.Push(entityType);
				entityType = entityType.BaseType;
			}
			while (stack.Count > 0)
			{
				entityType = stack.Pop();
				EntityTypeConfiguration entityTypeConfiguration = ActiveEntityConfigurations.Where((EntityTypeConfiguration ec) => ec.ClrType == entityType.GetClrType()).SingleOrDefault();
				if (entityTypeConfiguration != null && !list.Contains(entityTypeConfiguration))
				{
					list.Add(entityTypeConfiguration);
				}
			}
		}
		return list;
	}

	/// <summary>
	///     Initializes configurations in the ModelConfiguration so that configuration data
	///     is in a single place
	/// </summary>
	public void NormalizeConfigurations()
	{
		DiscoverIndirectlyConfiguredComplexTypes();
		ReassignSubtypeMappings();
	}

	private void DiscoverIndirectlyConfiguredComplexTypes()
	{
		ActiveEntityConfigurations.SelectMany((EntityTypeConfiguration ec) => ec.ConfiguredComplexTypes).Each((Type t) => ComplexType(t));
	}

	private void ReassignSubtypeMappings()
	{
		foreach (EntityTypeConfiguration activeEntityConfiguration in ActiveEntityConfigurations)
		{
			Dictionary<Type, EntityMappingConfiguration> dictionary = activeEntityConfiguration.SubTypeMappingConfigurations();
			if (!dictionary.Any())
			{
				continue;
			}
			foreach (KeyValuePair<Type, EntityMappingConfiguration> item in dictionary)
			{
				Type subTypeClrType = item.Key;
				EntityTypeConfiguration entityTypeConfiguration = ActiveEntityConfigurations.Where((EntityTypeConfiguration ec) => ec.ClrType == subTypeClrType).SingleOrDefault();
				if (entityTypeConfiguration == null)
				{
					entityTypeConfiguration = new EntityTypeConfiguration(subTypeClrType);
					_entityConfigurations.Add(subTypeClrType, entityTypeConfiguration);
				}
				entityTypeConfiguration.AddMappingConfiguration(item.Value);
			}
		}
	}

	private static void RemoveRedundantColumnConditions(DbDatabaseMapping databaseMapping)
	{
		(from esm in databaseMapping.GetEntitySetMappings()
			select new
			{
				Set = esm,
				Fragments = from etm in esm.EntityTypeMappings
					from etmf in etm.TypeMappingFragments
					group etmf by etmf.Table into g
					where g.Count((DbEntityTypeMappingFragment x) => x.GetDefaultDiscriminator() != null) == 1
					select g.Single((DbEntityTypeMappingFragment x) => x.GetDefaultDiscriminator() != null)
			}).Each(x =>
		{
			x.Fragments.Each(delegate(DbEntityTypeMappingFragment f)
			{
				f.RemoveDefaultDiscriminator(x.Set);
			});
		});
	}
}
