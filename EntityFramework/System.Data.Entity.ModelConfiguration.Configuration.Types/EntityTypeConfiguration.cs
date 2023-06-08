using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration.Mapping;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Configuration.Types;

internal class EntityTypeConfiguration : StructuralTypeConfiguration
{
	private readonly List<PropertyInfo> _keyProperties = new List<PropertyInfo>();

	private readonly Dictionary<PropertyInfo, NavigationPropertyConfiguration> _navigationPropertyConfigurations = new Dictionary<PropertyInfo, NavigationPropertyConfiguration>(new DynamicEqualityComparer<PropertyInfo>((PropertyInfo p1, PropertyInfo p2) => p1.IsSameAs(p2)));

	private readonly List<EntityMappingConfiguration> _entityMappingConfigurations = new List<EntityMappingConfiguration>();

	private readonly Dictionary<Type, EntityMappingConfiguration> _entitySubTypesMappingConfigurations = new Dictionary<Type, EntityMappingConfiguration>();

	private bool _isKeyConfigured;

	private string _entitySetName;

	internal IEnumerable<Type> ConfiguredComplexTypes => from pi in (from c in base.PrimitivePropertyConfigurations
			where c.Key.Count > 1
			select c.Key.Reverse().Skip(1)).SelectMany((IEnumerable<PropertyInfo> p) => p)
		select pi.PropertyType;

	internal bool IsStructuralConfigurationOnly
	{
		get
		{
			if (!_keyProperties.Any() && !_navigationPropertyConfigurations.Any() && !_entityMappingConfigurations.Any() && !_entitySubTypesMappingConfigurations.Any())
			{
				return _entitySetName == null;
			}
			return false;
		}
	}

	public bool IsTableNameConfigured { get; private set; }

	/// <summary>
	///     True if this configuration can be replaced in the model configuration, false otherwise
	///     This is only set to true for configurations that are registered automatically via the DbContext
	/// </summary>
	internal bool IsReplaceable { get; set; }

	internal bool IsExplicitEntity { get; set; }

	public virtual string EntitySetName
	{
		get
		{
			return _entitySetName;
		}
		set
		{
			_entitySetName = value;
		}
	}

	internal override IEnumerable<PropertyInfo> ConfiguredProperties => base.ConfiguredProperties.Union(_navigationPropertyConfigurations.Keys);

	public EntityTypeConfiguration(Type structuralType)
		: base(structuralType)
	{
		IsReplaceable = false;
	}

	private EntityTypeConfiguration(EntityTypeConfiguration source)
		: base(source)
	{
		_keyProperties.AddRange(source._keyProperties);
		source._navigationPropertyConfigurations.Each(delegate(KeyValuePair<PropertyInfo, NavigationPropertyConfiguration> c)
		{
			_navigationPropertyConfigurations.Add(c.Key, c.Value.Clone());
		});
		source._entitySubTypesMappingConfigurations.Each(delegate(KeyValuePair<Type, EntityMappingConfiguration> c)
		{
			_entitySubTypesMappingConfigurations.Add(c.Key, c.Value.Clone());
		});
		_entityMappingConfigurations.AddRange(source._entityMappingConfigurations.Select((EntityMappingConfiguration e) => e.Clone()));
		_isKeyConfigured = source._isKeyConfigured;
		_entitySetName = source._entitySetName;
		IsReplaceable = source.IsReplaceable;
		IsTableNameConfigured = source.IsTableNameConfigured;
		IsExplicitEntity = source.IsExplicitEntity;
	}

	internal virtual EntityTypeConfiguration Clone()
	{
		return new EntityTypeConfiguration(this);
	}

	internal override void RemoveProperty(PropertyPath propertyPath)
	{
		base.RemoveProperty(propertyPath);
		_navigationPropertyConfigurations.Remove(propertyPath.Single());
	}

	internal virtual void Key(IEnumerable<PropertyInfo> keyProperties)
	{
		ClearKey();
		foreach (PropertyInfo keyProperty in keyProperties)
		{
			Key(keyProperty, OverridableConfigurationParts.None);
		}
		_isKeyConfigured = true;
	}

	public virtual void Key(PropertyInfo propertyInfo, OverridableConfigurationParts? overridableConfigurationParts = null)
	{
		if (!propertyInfo.IsValidEdmPrimitiveProperty())
		{
			throw Error.ModelBuilder_KeyPropertiesMustBePrimitive(propertyInfo.Name, base.ClrType);
		}
		if (!_isKeyConfigured && !_keyProperties.ContainsSame(propertyInfo))
		{
			_keyProperties.Add(propertyInfo);
			Property(new PropertyPath(propertyInfo), overridableConfigurationParts);
		}
	}

	internal void ClearKey()
	{
		_keyProperties.Clear();
		_isKeyConfigured = false;
	}

	internal void ReplaceFrom(EntityTypeConfiguration existing)
	{
		if (EntitySetName == null)
		{
			EntitySetName = existing.EntitySetName;
		}
	}

	internal DatabaseName GetTableName()
	{
		if (!IsTableNameConfigured)
		{
			return null;
		}
		return _entityMappingConfigurations.First().TableName;
	}

	public void ToTable(string tableName)
	{
		ToTable(tableName, null);
	}

	public void ToTable(string tableName, string schemaName)
	{
		IsTableNameConfigured = true;
		if (!_entityMappingConfigurations.Any())
		{
			_entityMappingConfigurations.Add(new EntityMappingConfiguration());
		}
		_entityMappingConfigurations.First().TableName = (string.IsNullOrWhiteSpace(schemaName) ? new DatabaseName(tableName) : new DatabaseName(tableName, schemaName));
		UpdateTableNameForSubTypes();
	}

	private void UpdateTableNameForSubTypes()
	{
		(from smc in _entitySubTypesMappingConfigurations
			where smc.Value.TableName == null
			select smc into tphs
			select tphs.Value).Each((EntityMappingConfiguration tphmc) => tphmc.TableName = GetTableName());
	}

	internal void AddMappingConfiguration(EntityMappingConfiguration mappingConfiguration)
	{
		DatabaseName tableName = mappingConfiguration.TableName;
		if (tableName != null)
		{
			EntityMappingConfiguration entityMappingConfiguration = _entityMappingConfigurations.Where((EntityMappingConfiguration mf) => tableName.Equals(mf.TableName)).SingleOrDefault();
			if (entityMappingConfiguration != null)
			{
				throw Error.InvalidTableMapping(base.ClrType.Name, tableName);
			}
			_entityMappingConfigurations.Add(mappingConfiguration);
		}
		else
		{
			_entityMappingConfigurations.Add(mappingConfiguration);
		}
		if (_entityMappingConfigurations.Count > 1 && _entityMappingConfigurations.Where((EntityMappingConfiguration mc) => mc.TableName == null).Any())
		{
			throw Error.InvalidTableMapping_NoTableName(base.ClrType.Name);
		}
		IsTableNameConfigured |= tableName != null;
	}

	internal void AddSubTypeMappingConfiguration(Type subType, EntityMappingConfiguration mappingConfiguration)
	{
		if (_entitySubTypesMappingConfigurations.TryGetValue(subType, out var _))
		{
			throw Error.InvalidChainedMappingSyntax(subType.Name);
		}
		_entitySubTypesMappingConfigurations.Add(subType, mappingConfiguration);
	}

	internal Dictionary<Type, EntityMappingConfiguration> SubTypeMappingConfigurations()
	{
		return _entitySubTypesMappingConfigurations;
	}

	internal NavigationPropertyConfiguration Navigation(PropertyInfo propertyInfo)
	{
		if (!_navigationPropertyConfigurations.TryGetValue(propertyInfo, out var value))
		{
			_navigationPropertyConfigurations.Add(propertyInfo, value = new NavigationPropertyConfiguration(propertyInfo));
		}
		return value;
	}

	internal virtual void Configure(EdmEntityType entityType, EdmModel model)
	{
		ConfigureKey(entityType);
		Configure(entityType.Name, entityType.Properties, entityType.Annotations);
		ConfigureAssociations(entityType, model);
		ConfigureEntitySetName(entityType, model);
	}

	private void ConfigureEntitySetName(EdmEntityType entityType, EdmModel model)
	{
		if (EntitySetName != null && entityType.BaseType == null)
		{
			EdmEntitySet entitySet = model.GetEntitySet(entityType);
			entitySet.Name = model.GetEntitySets().Except(new EdmEntitySet[1] { entitySet }).UniquifyName(EntitySetName);
			entitySet.SetConfiguration(this);
		}
	}

	private void ConfigureKey(EdmEntityType entityType)
	{
		if (!_keyProperties.Any())
		{
			return;
		}
		if (entityType.BaseType != null)
		{
			throw Error.KeyRegisteredOnDerivedType(base.ClrType, entityType.GetRootType().GetClrType());
		}
		IEnumerable<PropertyInfo> enumerable = Enumerable.AsEnumerable(_keyProperties);
		if (!_isKeyConfigured)
		{
			List<PropertyInfo> keyProperties = _keyProperties;
			Func<PropertyInfo, _003C_003Ef__AnonymousType1d<PropertyInfo, int?>> func = default(Func<PropertyInfo, _003C_003Ef__AnonymousType1d<PropertyInfo, int?>>);
			if (func == null)
			{
				func = (PropertyInfo p) => new
				{
					PropertyInfo = p,
					ColumnOrder = Property(new PropertyPath(p)).ColumnOrder
				};
			}
			var source = keyProperties.Select(func);
			if (_keyProperties.Count > 1 && source.Any(p => !p.ColumnOrder.HasValue))
			{
				throw Error.ModelGeneration_UnableToDetermineKeyOrder(base.ClrType);
			}
			enumerable = from p in source
				orderby p.ColumnOrder
				select p.PropertyInfo;
		}
		foreach (PropertyInfo item in enumerable)
		{
			EdmProperty declaredPrimitiveProperty = entityType.GetDeclaredPrimitiveProperty(item);
			if (declaredPrimitiveProperty == null)
			{
				throw Error.KeyPropertyNotFound(item.Name, entityType.Name);
			}
			declaredPrimitiveProperty.PropertyType.IsNullable = false;
			entityType.DeclaredKeyProperties.Add(declaredPrimitiveProperty);
		}
	}

	private void ConfigureAssociations(EdmEntityType entityType, EdmModel model)
	{
		foreach (KeyValuePair<PropertyInfo, NavigationPropertyConfiguration> navigationPropertyConfiguration in _navigationPropertyConfigurations)
		{
			PropertyInfo key = navigationPropertyConfiguration.Key;
			NavigationPropertyConfiguration value = navigationPropertyConfiguration.Value;
			EdmNavigationProperty navigationProperty = entityType.GetNavigationProperty(key);
			if (navigationProperty == null)
			{
				throw Error.NavigationPropertyNotFound(key.Name, entityType.Name);
			}
			value.Configure(navigationProperty, model, this);
		}
	}

	internal void ConfigureTablesAndConditions(DbEntityTypeMapping entityTypeMapping, DbDatabaseMapping databaseMapping, DbProviderManifest providerManifest)
	{
		EdmEntityType entityType = ((entityTypeMapping != null) ? entityTypeMapping.EntityType : databaseMapping.Model.GetEntityType(base.ClrType));
		if (_entityMappingConfigurations.Any())
		{
			for (int i = 0; i < _entityMappingConfigurations.Count; i++)
			{
				_entityMappingConfigurations[i].Configure(databaseMapping, providerManifest, entityType, ref entityTypeMapping, IsMappingAnyInheritedProperty(entityType), i, _entityMappingConfigurations.Count);
			}
		}
		else
		{
			ConfigureUnconfiguredType(databaseMapping, providerManifest, entityType);
		}
	}

	internal bool IsMappingAnyInheritedProperty(EdmEntityType entityType)
	{
		return _entityMappingConfigurations.Any((EntityMappingConfiguration emc) => emc.MapsAnyInheritedProperties(entityType));
	}

	internal static void ConfigureUnconfiguredType(DbDatabaseMapping databaseMapping, DbProviderManifest providerManifest, EdmEntityType entityType)
	{
		EntityMappingConfiguration entityMappingConfiguration = new EntityMappingConfiguration();
		DbEntityTypeMapping entityTypeMapping = databaseMapping.GetEntityTypeMapping(entityType.GetClrType());
		entityMappingConfiguration.Configure(databaseMapping, providerManifest, entityType, ref entityTypeMapping, isMappingAnyInheritedProperty: false, 0, 1);
	}

	internal void Configure(EdmEntityType entityType, DbDatabaseMapping databaseMapping, DbProviderManifest providerManifest)
	{
		DbEntityTypeMapping entityTypeMapping = databaseMapping.GetEntityTypeMapping(entityType.GetClrType());
		if (entityTypeMapping != null)
		{
			VerifyAllCSpacePropertiesAreMapped(databaseMapping.GetEntityTypeMappings(entityType), entityTypeMapping.EntityType.DeclaredProperties, new List<EdmProperty>());
		}
		ConfigurePropertyMappings(databaseMapping, entityType, providerManifest);
		ConfigureAssociationMappings(databaseMapping);
		ConfigureDependentKeys(databaseMapping);
	}

	private void ConfigurePropertyMappings(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbProviderManifest providerManifest, bool allowOverride = false)
	{
		IEnumerable<DbEntityTypeMapping> entityTypeMappings = databaseMapping.GetEntityTypeMappings(entityType);
		IEnumerable<Tuple<DbEdmPropertyMapping, DbTableMetadata>> propertyMappings = from etm in entityTypeMappings
			from etmf in etm.TypeMappingFragments
			from pm in etmf.PropertyMappings
			select Tuple.Create(pm, etmf.Table);
		Configure(propertyMappings, providerManifest, allowOverride);
		foreach (EdmEntityType item in from et in databaseMapping.Model.GetEntityTypes()
			where et.BaseType == entityType
			select et)
		{
			ConfigurePropertyMappings(databaseMapping, item, providerManifest, allowOverride: true);
		}
	}

	private void ConfigureAssociationMappings(DbDatabaseMapping databaseMapping)
	{
		_navigationPropertyConfigurations.Values.Each(delegate(NavigationPropertyConfiguration c)
		{
			c.Configure(databaseMapping);
		});
	}

	private static void ConfigureDependentKeys(DbDatabaseMapping databaseMapping)
	{
		DbSchemaMetadata dbSchemaMetadata = databaseMapping.Database.Schemas.Single();
		DbForeignKeyConstraintMetadata foreignKeyConstraint;
		foreach (DbForeignKeyConstraintMetadata item in dbSchemaMetadata.Tables.SelectMany((DbTableMetadata t) => t.ForeignKeyConstraints))
		{
			foreignKeyConstraint = item;
			foreignKeyConstraint.DependentColumns.Each(delegate(DbTableColumnMetadata c, int i)
			{
				if (!(c.GetConfiguration() is System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive.PrimitivePropertyConfiguration primitivePropertyConfiguration) || primitivePropertyConfiguration.ColumnType == null)
				{
					DbTableColumnMetadata dbTableColumnMetadata = foreignKeyConstraint.PrincipalTable.KeyColumns.ElementAt(i);
					c.TypeName = dbTableColumnMetadata.TypeName;
					c.Facets.CopyFrom(dbTableColumnMetadata.Facets);
				}
			});
		}
	}

	private static void VerifyAllCSpacePropertiesAreMapped(IEnumerable<DbEntityTypeMapping> entityTypeMappings, IEnumerable<EdmProperty> properties, IList<EdmProperty> propertyPath)
	{
		EdmEntityType entityType = entityTypeMappings.First().EntityType;
		foreach (EdmProperty property in properties)
		{
			propertyPath.Add(property);
			if (property.PropertyType.IsComplexType)
			{
				VerifyAllCSpacePropertiesAreMapped(entityTypeMappings, property.PropertyType.ComplexType.DeclaredProperties, propertyPath);
			}
			else if (!(from pm in entityTypeMappings.SelectMany((DbEntityTypeMapping etm) => etm.TypeMappingFragments).SelectMany((DbEntityTypeMappingFragment mf) => mf.PropertyMappings)
				where pm.PropertyPath.SequenceEqual(propertyPath)
				select pm).Any() && !entityType.IsAbstract)
			{
				throw Error.InvalidEntitySplittingProperties(entityType.Name);
			}
			propertyPath.Remove(property);
		}
	}
}
