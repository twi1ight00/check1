using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Edm.Internal;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Services;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class EntityMappingConfiguration
{
	private DatabaseName _tableName;

	private List<PropertyPath> _properties;

	private readonly List<ValueConditionConfiguration> _valueConditions = new List<ValueConditionConfiguration>();

	private readonly List<NotNullConditionConfiguration> _notNullConditions = new List<NotNullConditionConfiguration>();

	public bool MapInheritedProperties { get; set; }

	public DatabaseName TableName
	{
		get
		{
			return _tableName;
		}
		set
		{
			_tableName = value;
		}
	}

	internal List<PropertyPath> Properties
	{
		get
		{
			return _properties;
		}
		set
		{
			if (_properties == null)
			{
				_properties = new List<PropertyPath>();
			}
			value.Each(Property);
		}
	}

	public List<ValueConditionConfiguration> ValueConditions => _valueConditions;

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public List<NotNullConditionConfiguration> NullabilityConditions
	{
		get
		{
			return _notNullConditions;
		}
		set
		{
			value.Each(AddNullabilityCondition);
		}
	}

	internal EntityMappingConfiguration()
	{
	}

	private EntityMappingConfiguration(EntityMappingConfiguration source)
	{
		_tableName = source._tableName;
		MapInheritedProperties = source.MapInheritedProperties;
		if (source._properties != null)
		{
			_properties = new List<PropertyPath>(source._properties);
		}
		_valueConditions.AddRange(source._valueConditions.Select((ValueConditionConfiguration c) => c.Clone(this)));
		_notNullConditions.AddRange(source._notNullConditions.Select((NotNullConditionConfiguration c) => c.Clone(this)));
	}

	internal virtual EntityMappingConfiguration Clone()
	{
		return new EntityMappingConfiguration(this);
	}

	private void Property(PropertyPath property)
	{
		if (!_properties.Where((PropertyPath pp) => pp.SequenceEqual(property)).Any())
		{
			_properties.Add(property);
		}
	}

	public void AddValueCondition(ValueConditionConfiguration valueCondition)
	{
		ValueConditionConfiguration valueConditionConfiguration = ValueConditions.Where((ValueConditionConfiguration vc) => vc.Discriminator.Equals(valueCondition.Discriminator, StringComparison.Ordinal)).SingleOrDefault();
		if (valueConditionConfiguration == null)
		{
			ValueConditions.Add(valueCondition);
		}
		else
		{
			valueConditionConfiguration.Value = valueCondition.Value;
		}
	}

	public void AddNullabilityCondition(NotNullConditionConfiguration notNullConditionConfiguration)
	{
		if (!NullabilityConditions.Contains(notNullConditionConfiguration))
		{
			NullabilityConditions.Add(notNullConditionConfiguration);
		}
	}

	public bool MapsAnyInheritedProperties(EdmEntityType entityType)
	{
		HashSet<EdmPropertyPath> properties = new HashSet<EdmPropertyPath>();
		if (Properties != null)
		{
			Properties.Each(delegate(PropertyPath p)
			{
				properties.AddRange(PropertyPathToEdmPropertyPath(p, entityType));
			});
		}
		if (!MapInheritedProperties)
		{
			return properties.Any((EdmPropertyPath x) => !entityType.KeyProperties().Contains(x.First()) && !entityType.DeclaredProperties.Contains(x.First()));
		}
		return true;
	}

	public void Configure(DbDatabaseMapping databaseMapping, DbProviderManifest providerManifest, EdmEntityType entityType, ref DbEntityTypeMapping entityTypeMapping, bool isMappingAnyInheritedProperty, int configurationIndex, int configurationCount)
	{
		bool flag = entityType.BaseType == null && configurationIndex == 0;
		DbEntityTypeMappingFragment dbEntityTypeMappingFragment = FindOrCreateTypeMappingFragment(databaseMapping, ref entityTypeMapping, configurationIndex, entityType, providerManifest);
		DbTableMetadata table = dbEntityTypeMappingFragment.Table;
		bool isTableSharing;
		DbTableMetadata dbTableMetadata = FindOrCreateTargetTable(databaseMapping, dbEntityTypeMappingFragment, entityType, table, flag, out isTableSharing);
		bool isSharingTableWithBase = DiscoverIsSharingWithBase(databaseMapping, dbEntityTypeMappingFragment, entityType, dbTableMetadata);
		HashSet<EdmPropertyPath> hashSet = DiscoverAllMappingsToContain(databaseMapping, entityType, dbTableMetadata, isSharingTableWithBase);
		List<DbEdmPropertyMapping> list = dbEntityTypeMappingFragment.PropertyMappings.ToList();
		EdmPropertyPath propertyPath;
		foreach (EdmPropertyPath item in hashSet)
		{
			propertyPath = item;
			DbEdmPropertyMapping dbEdmPropertyMapping = dbEntityTypeMappingFragment.PropertyMappings.SingleOrDefault((DbEdmPropertyMapping pm) => pm.PropertyPath.SequenceEqual(propertyPath));
			if (dbEdmPropertyMapping == null)
			{
				throw Error.EntityMappingConfiguration_DuplicateMappedProperty(entityType.Name, propertyPath.ToString());
			}
			list.Remove(dbEdmPropertyMapping);
		}
		if (!flag)
		{
			bool isSplitting;
			DbTableMetadata dbTableMetadata2 = FindParentTable(databaseMapping, table, entityTypeMapping, dbTableMetadata, isMappingAnyInheritedProperty, configurationIndex, configurationCount, out isSplitting);
			if (dbTableMetadata2 != null)
			{
				DatabaseOperations.AddTypeConstraint(entityType, dbTableMetadata2, dbTableMetadata, isSplitting);
			}
		}
		if (table != dbTableMetadata)
		{
			if (Properties == null)
			{
				AssociationMappingOperations.MoveAllDeclaredAssociationSetMappings(databaseMapping, entityType, table, dbTableMetadata, !isTableSharing);
				ForeignKeyPrimitiveOperations.MoveAllDeclaredForeignKeyConstraintsForPrimaryKeyColumns(entityType, table, dbTableMetadata);
			}
			if (isMappingAnyInheritedProperty)
			{
				ForeignKeyPrimitiveOperations.CopyAllForeignKeyConstraintsForPrimaryKeyColumns(databaseMapping.Database, table, dbTableMetadata);
			}
		}
		if (list.Any())
		{
			DbTableMetadata extraTable = null;
			if (configurationIndex < configurationCount - 1)
			{
				DbEdmPropertyMapping pm2 = list.First();
				extraTable = FindTableForTemporaryExtraPropertyMapping(databaseMapping, entityType, table, dbTableMetadata, pm2);
				DbEntityTypeMappingFragment toFragment = EntityMappingOperations.CreateTypeMappingFragment(entityTypeMapping, dbEntityTypeMappingFragment, extraTable);
				bool requiresUpdate = extraTable != table;
				foreach (DbEdmPropertyMapping item2 in list)
				{
					EntityMappingOperations.MovePropertyMapping(databaseMapping.Database, dbEntityTypeMappingFragment, toFragment, item2, requiresUpdate, useExisting: true);
				}
			}
			else
			{
				DbTableMetadata unmappedTable = null;
				foreach (DbEdmPropertyMapping item3 in list)
				{
					extraTable = FindTableForExtraPropertyMapping(databaseMapping, entityType, table, dbTableMetadata, ref unmappedTable, item3);
					DbEntityTypeMappingFragment dbEntityTypeMappingFragment2 = entityTypeMapping.TypeMappingFragments.SingleOrDefault((DbEntityTypeMappingFragment tmf) => tmf.Table == extraTable);
					if (dbEntityTypeMappingFragment2 == null)
					{
						dbEntityTypeMappingFragment2 = EntityMappingOperations.CreateTypeMappingFragment(entityTypeMapping, dbEntityTypeMappingFragment, extraTable);
						dbEntityTypeMappingFragment2.SetIsUnmappedPropertiesFragment(isUnmappedPropertiesFragment: true);
					}
					if (extraTable == table)
					{
						MoveDefaultDiscriminator(dbEntityTypeMappingFragment, dbEntityTypeMappingFragment2);
					}
					bool requiresUpdate2 = extraTable != table;
					EntityMappingOperations.MovePropertyMapping(databaseMapping.Database, dbEntityTypeMappingFragment, dbEntityTypeMappingFragment2, item3, requiresUpdate2, useExisting: true);
				}
			}
		}
		EntityMappingOperations.UpdatePropertyMappings(databaseMapping.Database, entityType, table, dbEntityTypeMappingFragment, !isTableSharing);
		ConfigureDefaultDiscriminator(entityType, dbEntityTypeMappingFragment, isSharingTableWithBase);
		ConfigureConditions(databaseMapping, entityType, entityTypeMapping, dbEntityTypeMappingFragment, providerManifest);
		EntityMappingOperations.UpdateConditions(databaseMapping.Database, table, dbEntityTypeMappingFragment);
		ForeignKeyPrimitiveOperations.UpdatePrincipalTables(databaseMapping, entityType, table, dbTableMetadata, isMappingAnyInheritedProperty);
		CleanupUnmappedArtifacts(databaseMapping, table);
		CleanupUnmappedArtifacts(databaseMapping, dbTableMetadata);
		dbTableMetadata.SetConfiguration(this);
	}

	private void ConfigureDefaultDiscriminator(EdmEntityType entityType, DbEntityTypeMappingFragment fragment, bool isSharingTableWithBase)
	{
		if ((entityType.BaseType != null && !isSharingTableWithBase) || ValueConditions.Any() || NullabilityConditions.Any())
		{
			DbTableColumnMetadata dbTableColumnMetadata = fragment.RemoveDefaultDiscriminatorCondition();
			if (dbTableColumnMetadata != null && entityType.BaseType != null)
			{
				dbTableColumnMetadata.IsNullable = true;
			}
		}
	}

	private void MoveDefaultDiscriminator(DbEntityTypeMappingFragment fromFragment, DbEntityTypeMappingFragment toFragment)
	{
		DbTableColumnMetadata discriminatorColumn = fromFragment.GetDefaultDiscriminator();
		if (discriminatorColumn != null)
		{
			DbColumnCondition dbColumnCondition = fromFragment.ColumnConditions.SingleOrDefault((DbColumnCondition cc) => cc.Column == discriminatorColumn);
			if (dbColumnCondition != null)
			{
				fromFragment.RemoveDefaultDiscriminatorAnnotation();
				fromFragment.ColumnConditions.Remove(dbColumnCondition);
				toFragment.AddDiscriminatorCondition(dbColumnCondition.Column, dbColumnCondition.Value);
				toFragment.SetDefaultDiscriminator(dbColumnCondition.Column);
			}
		}
	}

	private static DbTableMetadata FindTableForTemporaryExtraPropertyMapping(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbTableMetadata fromTable, DbTableMetadata toTable, DbEdmPropertyMapping pm)
	{
		DbTableMetadata dbTableMetadata = fromTable;
		if (fromTable == toTable)
		{
			dbTableMetadata = databaseMapping.Database.AddTable(fromTable.Name, fromTable, isIdentity: false);
		}
		else if (entityType.BaseType == null)
		{
			dbTableMetadata = fromTable;
		}
		else
		{
			dbTableMetadata = FindBaseTableForExtraPropertyMapping(databaseMapping, entityType, fromTable, pm);
			if (dbTableMetadata == null)
			{
				dbTableMetadata = fromTable;
			}
		}
		return dbTableMetadata;
	}

	private DbTableMetadata FindTableForExtraPropertyMapping(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbTableMetadata fromTable, DbTableMetadata toTable, ref DbTableMetadata unmappedTable, DbEdmPropertyMapping pm)
	{
		DbTableMetadata dbTableMetadata = FindBaseTableForExtraPropertyMapping(databaseMapping, entityType, fromTable, pm);
		if (dbTableMetadata == null)
		{
			if (fromTable != toTable && entityType.BaseType == null)
			{
				return fromTable;
			}
			if (unmappedTable == null)
			{
				unmappedTable = databaseMapping.Database.AddTable(fromTable.Name, fromTable, isIdentity: false);
			}
			dbTableMetadata = unmappedTable;
		}
		return dbTableMetadata;
	}

	private static DbTableMetadata FindBaseTableForExtraPropertyMapping(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbTableMetadata fromTable, DbEdmPropertyMapping pm)
	{
		EdmEntityType baseType = entityType.BaseType;
		DbEntityTypeMapping dbEntityTypeMapping = null;
		DbEntityTypeMappingFragment dbEntityTypeMappingFragment = null;
		while (baseType != null && dbEntityTypeMappingFragment == null)
		{
			dbEntityTypeMapping = databaseMapping.GetEntityTypeMapping(entityType.BaseType);
			if (dbEntityTypeMapping != null)
			{
				dbEntityTypeMappingFragment = dbEntityTypeMapping.TypeMappingFragments.SingleOrDefault((DbEntityTypeMappingFragment f) => f.PropertyMappings.Any((DbEdmPropertyMapping bpm) => bpm.PropertyPath.SequenceEqual(pm.PropertyPath)));
				if (dbEntityTypeMappingFragment != null)
				{
					return dbEntityTypeMappingFragment.Table;
				}
			}
			baseType = baseType.BaseType;
		}
		return null;
	}

	private bool DiscoverIsSharingWithBase(DbDatabaseMapping databaseMapping, DbEntityTypeMappingFragment fragment, EdmEntityType entityType, DbTableMetadata toTable)
	{
		bool flag = false;
		if (entityType.BaseType != null)
		{
			EdmEntityType baseType = entityType.BaseType;
			bool flag2 = false;
			while (baseType != null && !flag)
			{
				IEnumerable<DbEntityTypeMapping> entityTypeMappings = databaseMapping.GetEntityTypeMappings(baseType);
				if (entityTypeMappings.Count() > 0)
				{
					flag = entityTypeMappings.SelectMany((DbEntityTypeMapping m) => m.TypeMappingFragments).Any((DbEntityTypeMappingFragment tmf) => tmf.Table == toTable);
					flag2 = true;
				}
				baseType = baseType.BaseType;
			}
			if (!flag2)
			{
				flag = TableName == null || string.IsNullOrWhiteSpace(TableName.Name);
			}
		}
		return flag;
	}

	private DbTableMetadata FindParentTable(DbDatabaseMapping databaseMapping, DbTableMetadata fromTable, DbEntityTypeMapping entityTypeMapping, DbTableMetadata toTable, bool isMappingInheritedProperties, int configurationIndex, int configurationCount, out bool isSplitting)
	{
		DbTableMetadata dbTableMetadata = null;
		isSplitting = false;
		if ((entityTypeMapping.UsesOtherTables(toTable) || configurationCount > 1) && configurationIndex != 0)
		{
			dbTableMetadata = entityTypeMapping.GetPrimaryTable();
			isSplitting = true;
		}
		if (dbTableMetadata == null && fromTable != toTable && !isMappingInheritedProperties)
		{
			EdmEntityType baseType = entityTypeMapping.EntityType.BaseType;
			while (baseType != null && dbTableMetadata == null)
			{
				DbEntityTypeMapping dbEntityTypeMapping = databaseMapping.GetEntityTypeMappings(baseType).FirstOrDefault();
				if (dbEntityTypeMapping != null)
				{
					dbTableMetadata = dbEntityTypeMapping.GetPrimaryTable();
				}
				baseType = baseType.BaseType;
			}
		}
		return dbTableMetadata;
	}

	private DbEntityTypeMappingFragment FindOrCreateTypeMappingFragment(DbDatabaseMapping databaseMapping, ref DbEntityTypeMapping entityTypeMapping, int configurationIndex, EdmEntityType entityType, DbProviderManifest providerManifest)
	{
		DbEntityTypeMappingFragment dbEntityTypeMappingFragment = null;
		if (entityTypeMapping == null)
		{
			new EntityTypeMappingGenerator(providerManifest).Generate(entityType, databaseMapping);
			entityTypeMapping = databaseMapping.GetEntityTypeMapping(entityType);
			configurationIndex = 0;
		}
		if (configurationIndex < entityTypeMapping.TypeMappingFragments.Count)
		{
			return entityTypeMapping.TypeMappingFragments[configurationIndex];
		}
		if (MapInheritedProperties)
		{
			throw Error.EntityMappingConfiguration_DuplicateMapInheritedProperties(entityType.Name);
		}
		if (Properties == null)
		{
			throw Error.EntityMappingConfiguration_DuplicateMappedProperties(entityType.Name);
		}
		Properties.Each(delegate(PropertyPath p)
		{
			if (PropertyPathToEdmPropertyPath(p, entityType).Any((EdmPropertyPath pp) => !entityType.KeyProperties().Contains(pp.First())))
			{
				throw Error.EntityMappingConfiguration_DuplicateMappedProperty(entityType.Name, p.ToString());
			}
		});
		DbTableMetadata table = entityTypeMapping.TypeMappingFragments[0].Table;
		return EntityMappingOperations.CreateTypeMappingFragment(entityTypeMapping, entityTypeMapping.TypeMappingFragments[0], databaseMapping.Database.AddTable(table.Name, table, isIdentity: false));
	}

	private DbTableMetadata FindOrCreateTargetTable(DbDatabaseMapping databaseMapping, DbEntityTypeMappingFragment fragment, EdmEntityType entityType, DbTableMetadata fromTable, bool isIdentityTable, out bool isTableSharing)
	{
		isTableSharing = false;
		DbTableMetadata dbTableMetadata;
		if (TableName == null)
		{
			dbTableMetadata = fragment.Table;
		}
		else
		{
			dbTableMetadata = databaseMapping.Database.FindTableByName(TableName);
			if (dbTableMetadata == null)
			{
				dbTableMetadata = ((entityType.BaseType != null) ? databaseMapping.Database.AddTable(TableName.Name, fromTable, isIdentityTable) : fragment.Table);
			}
			isTableSharing = UpdateColumnNamesForTableSharing(databaseMapping, entityType, dbTableMetadata, fragment);
			fragment.Table = dbTableMetadata;
			dbTableMetadata.SetTableName(TableName);
		}
		return dbTableMetadata;
	}

	private HashSet<EdmPropertyPath> DiscoverAllMappingsToContain(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbTableMetadata toTable, bool isSharingTableWithBase)
	{
		HashSet<EdmPropertyPath> mappingsToContain = new HashSet<EdmPropertyPath>();
		entityType.KeyProperties().Each(delegate(EdmProperty p)
		{
			mappingsToContain.AddRange(p.ToPropertyPathList());
		});
		if (MapInheritedProperties)
		{
			entityType.Properties.Except(entityType.DeclaredProperties).Each(delegate(EdmProperty p)
			{
				mappingsToContain.AddRange(p.ToPropertyPathList());
			});
		}
		if (isSharingTableWithBase)
		{
			HashSet<EdmPropertyPath> baseMappingsToContain = new HashSet<EdmPropertyPath>();
			EdmEntityType baseType = entityType.BaseType;
			DbEntityTypeMapping dbEntityTypeMapping = null;
			DbEntityTypeMappingFragment dbEntityTypeMappingFragment = null;
			while (baseType != null && dbEntityTypeMapping == null)
			{
				dbEntityTypeMapping = databaseMapping.GetEntityTypeMapping(entityType.BaseType);
				if (dbEntityTypeMapping != null)
				{
					dbEntityTypeMappingFragment = dbEntityTypeMapping.TypeMappingFragments.SingleOrDefault((DbEntityTypeMappingFragment tmf) => tmf.Table == toTable);
				}
				if (dbEntityTypeMappingFragment == null)
				{
					baseType.DeclaredProperties.Each(delegate(EdmProperty p)
					{
						baseMappingsToContain.AddRange(p.ToPropertyPathList());
					});
				}
				baseType = baseType.BaseType;
			}
			if (dbEntityTypeMappingFragment != null)
			{
				foreach (DbEdmPropertyMapping propertyMapping in dbEntityTypeMappingFragment.PropertyMappings)
				{
					mappingsToContain.Add(new EdmPropertyPath(propertyMapping.PropertyPath));
				}
			}
			mappingsToContain.AddRange(baseMappingsToContain);
		}
		if (Properties == null)
		{
			entityType.DeclaredProperties.Each(delegate(EdmProperty p)
			{
				mappingsToContain.AddRange(p.ToPropertyPathList());
			});
		}
		else
		{
			Properties.Each(delegate(PropertyPath p)
			{
				mappingsToContain.AddRange(PropertyPathToEdmPropertyPath(p, entityType));
			});
		}
		return mappingsToContain;
	}

	private void ConfigureConditions(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbEntityTypeMapping entityTypeMapping, DbEntityTypeMappingFragment fragment, DbProviderManifest providerManifest)
	{
		if (!ValueConditions.Any() && !NullabilityConditions.Any())
		{
			return;
		}
		fragment.ColumnConditions.Clear();
		foreach (ValueConditionConfiguration valueCondition in ValueConditions)
		{
			valueCondition.Configure(databaseMapping, fragment, entityType, providerManifest);
		}
		foreach (NotNullConditionConfiguration nullabilityCondition in NullabilityConditions)
		{
			nullabilityCondition.Configure(databaseMapping, fragment, entityType);
		}
	}

	internal static void CleanupUnmappedArtifacts(DbDatabaseMapping databaseMapping, DbTableMetadata table)
	{
		DbAssociationSetMapping[] source = (from asm in databaseMapping.EntityContainerMappings.SelectMany((DbEntityContainerMapping ecm) => ecm.AssociationSetMappings)
			where asm.Table == table
			select asm).ToArray();
		DbEntityTypeMappingFragment[] source2 = (from f in databaseMapping.EntityContainerMappings.SelectMany((DbEntityContainerMapping ecm) => ecm.EntitySetMappings).SelectMany((DbEntitySetMapping esm) => esm.EntityTypeMappings).SelectMany((DbEntityTypeMapping etm) => etm.TypeMappingFragments)
			where f.Table == table
			select f).ToArray();
		if (!source.Any() && !source2.Any())
		{
			databaseMapping.Database.Schemas.Single().Tables.Remove(table);
			return;
		}
		DbTableColumnMetadata[] array = table.Columns.ToArray();
		DbTableColumnMetadata column;
		for (int i = 0; i < array.Length; i++)
		{
			column = array[i];
			if (!(from pm in source2.SelectMany((DbEntityTypeMappingFragment f) => f.PropertyMappings)
				where pm.Column == column
				select pm).Any() && !(from cc in source2.SelectMany((DbEntityTypeMappingFragment f) => f.ColumnConditions)
				where cc.Column == column
				select cc).Any() && !(from pm in source.SelectMany((DbAssociationSetMapping am) => am.SourceEndMapping.PropertyMappings)
				where pm.Column == column
				select pm).Any() && !(from pm in source.SelectMany((DbAssociationSetMapping am) => am.SourceEndMapping.PropertyMappings)
				where pm.Column == column
				select pm).Any())
			{
				ForeignKeyPrimitiveOperations.RemoveAllForeignKeyConstraintsForColumn(table, column);
				TablePrimitiveOperations.RemoveColumn(table, column);
			}
		}
		table.ForeignKeyConstraints.Where((DbForeignKeyConstraintMetadata fk) => fk.PrincipalTable == table && fk.DependentColumns.SequenceEqual(table.KeyColumns)).ToArray().Each((DbForeignKeyConstraintMetadata fk) => table.ForeignKeyConstraints.Remove(fk));
	}

	internal static IEnumerable<EdmPropertyPath> PropertyPathToEdmPropertyPath(PropertyPath path, EdmEntityType entityType)
	{
		List<EdmProperty> list = new List<EdmProperty>();
		EdmStructuralType edmStructuralType = entityType;
		int i;
		for (i = 0; i < path.Count; i++)
		{
			EdmProperty edmProperty = edmStructuralType.Members.OfType<EdmProperty>().SingleOrDefault((EdmProperty p) => p.GetClrPropertyInfo().IsSameAs(path[i]));
			if (edmProperty == null)
			{
				throw Error.EntityMappingConfiguration_CannotMapIgnoredProperty(entityType.Name, path.ToString());
			}
			list.Add(edmProperty);
			if (edmProperty.PropertyType.IsComplexType)
			{
				edmStructuralType = edmProperty.PropertyType.ComplexType;
			}
		}
		EdmProperty edmProperty2 = list.Last();
		if (edmProperty2.PropertyType.IsPrimitiveType)
		{
			return new EdmPropertyPath[1]
			{
				new EdmPropertyPath(list)
			};
		}
		if (edmProperty2.PropertyType.IsComplexType)
		{
			list.Remove(edmProperty2);
			return edmProperty2.ToPropertyPathList(list);
		}
		return new EdmPropertyPath[1] { EdmPropertyPath.Empty };
	}

	private static IEnumerable<EdmEntityType> FindAllTypesUsingTable(DbDatabaseMapping databaseMapping, DbTableMetadata toTable)
	{
		return from etm in databaseMapping.EntityContainerMappings.SelectMany((DbEntityContainerMapping ecm) => ecm.EntitySetMappings).SelectMany((DbEntitySetMapping esm) => esm.EntityTypeMappings)
			where etm.TypeMappingFragments.Any((DbEntityTypeMappingFragment tmf) => tmf.Table == toTable)
			select etm.EntityType;
	}

	private static IEnumerable<EdmAssociationType> FindAllOneToOneFKAssociationTypes(EdmModel model, EdmEntityType entityType, EdmEntityType candidateType)
	{
		return from aset in model.Containers.SelectMany((EdmEntityContainer ec) => ec.AssociationSets)
			where aset.ElementType.Constraint != null && aset.ElementType.SourceEnd.EndKind == EdmAssociationEndKind.Required && aset.ElementType.TargetEnd.EndKind == EdmAssociationEndKind.Required && ((aset.ElementType.SourceEnd.EntityType == entityType && aset.ElementType.TargetEnd.EntityType == candidateType) || (aset.ElementType.TargetEnd.EntityType == entityType && aset.ElementType.SourceEnd.EntityType == candidateType))
			select aset.ElementType;
	}

	private static bool UpdateColumnNamesForTableSharing(DbDatabaseMapping databaseMapping, EdmEntityType entityType, DbTableMetadata toTable, DbEntityTypeMappingFragment fragment)
	{
		IEnumerable<EdmEntityType> enumerable = FindAllTypesUsingTable(databaseMapping, toTable);
		Dictionary<EdmEntityType, List<EdmAssociationType>> dictionary = new Dictionary<EdmEntityType, List<EdmAssociationType>>();
		foreach (EdmEntityType item in enumerable)
		{
			IEnumerable<EdmAssociationType> enumerable2 = FindAllOneToOneFKAssociationTypes(databaseMapping.Model, entityType, item);
			EdmEntityType rootType = item.GetRootType();
			if (!dictionary.ContainsKey(rootType))
			{
				dictionary.Add(rootType, enumerable2.ToList());
			}
			else
			{
				dictionary[rootType].AddRange(enumerable2);
			}
		}
		foreach (KeyValuePair<EdmEntityType, List<EdmAssociationType>> item2 in dictionary)
		{
			if (item2.Key != entityType.GetRootType() && item2.Value.Count == 0)
			{
				DatabaseName tableName = toTable.GetTableName();
				throw Error.EntityMappingConfiguration_InvalidTableSharing(entityType.Name, item2.Key.Name, (tableName != null) ? tableName.Name : toTable.DatabaseIdentifier);
			}
		}
		IEnumerable<EdmAssociationType> source = dictionary.Values.SelectMany((List<EdmAssociationType> l) => l);
		if (source.Any())
		{
			EdmEntityType principalKeyNamesType = toTable.GetKeyNamesType();
			if (principalKeyNamesType == null)
			{
				EdmAssociationType edmAssociationType = source.First();
				principalKeyNamesType = edmAssociationType.Constraint.PrincipalEnd(edmAssociationType).EntityType;
				if (source.All((EdmAssociationType x) => x.Constraint.PrincipalEnd(x).EntityType == principalKeyNamesType))
				{
					toTable.SetKeyNamesType(principalKeyNamesType);
				}
			}
			EdmProperty[] array = principalKeyNamesType.KeyProperties().ToArray();
			int num = 0;
			EdmProperty i;
			foreach (EdmProperty item3 in entityType.KeyProperties())
			{
				i = item3;
				DbTableColumnMetadata column = fragment.PropertyMappings.Single((DbEdmPropertyMapping pm) => pm.PropertyPath.First() == i).Column;
				column.Name = array[num].Name;
				num++;
			}
			return true;
		}
		return false;
	}
}
