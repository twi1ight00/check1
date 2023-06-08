using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Configuration.Mapping;

internal class EntityMappingOperations
{
	public static DbEntityTypeMappingFragment CreateTypeMappingFragment(DbEntityTypeMapping entityTypeMapping, DbEntityTypeMappingFragment templateFragment, DbTableMetadata table)
	{
		DbEntityTypeMappingFragment dbEntityTypeMappingFragment = new DbEntityTypeMappingFragment();
		dbEntityTypeMappingFragment.Table = table;
		DbEntityTypeMappingFragment dbEntityTypeMappingFragment2 = dbEntityTypeMappingFragment;
		entityTypeMapping.TypeMappingFragments.Add(dbEntityTypeMappingFragment2);
		foreach (DbEdmPropertyMapping item in templateFragment.PropertyMappings.Where((DbEdmPropertyMapping pm) => pm.Column.IsPrimaryKeyColumn))
		{
			CopyPropertyMappingToFragment(item, dbEntityTypeMappingFragment2, useExisting: true);
		}
		return dbEntityTypeMappingFragment2;
	}

	private static void UpdatePropertyMapping(DbDatabaseMetadata database, DbEdmPropertyMapping propertyMapping, DbTableMetadata fromTable, DbTableMetadata toTable, bool useExisting)
	{
		propertyMapping.Column = TableOperations.CopyColumnAndAnyConstraints(database, fromTable, toTable, propertyMapping.Column, useExisting, allowPkConstraintCopy: false);
		propertyMapping.SyncNullabilityCSSpace();
	}

	public static void UpdatePropertyMappings(DbDatabaseMetadata database, EdmEntityType entityType, DbTableMetadata fromTable, DbEntityTypeMappingFragment fragment, bool useExisting)
	{
		if (fromTable != fragment.Table)
		{
			fragment.PropertyMappings.Each(delegate(DbEdmPropertyMapping pm)
			{
				UpdatePropertyMapping(database, pm, fromTable, fragment.Table, useExisting);
			});
		}
	}

	public static void MovePropertyMapping(DbDatabaseMetadata database, DbEntityTypeMappingFragment fromFragment, DbEntityTypeMappingFragment toFragment, DbEdmPropertyMapping propertyMapping, bool requiresUpdate, bool useExisting)
	{
		if (requiresUpdate && fromFragment.Table != toFragment.Table)
		{
			UpdatePropertyMapping(database, propertyMapping, fromFragment.Table, toFragment.Table, useExisting);
		}
		fromFragment.PropertyMappings.Remove(propertyMapping);
		toFragment.PropertyMappings.Add(propertyMapping);
	}

	public static void CopyPropertyMappingToFragment(DbEdmPropertyMapping propertyMapping, DbEntityTypeMappingFragment fragment, bool useExisting)
	{
		DbTableColumnMetadata column = TablePrimitiveOperations.IncludeColumn(fragment.Table, propertyMapping.Column, useExisting);
		fragment.PropertyMappings.Add(new DbEdmPropertyMapping
		{
			PropertyPath = propertyMapping.PropertyPath,
			Column = column
		});
	}

	public static void UpdateConditions(DbDatabaseMetadata database, DbTableMetadata fromTable, DbEntityTypeMappingFragment fragment)
	{
		if (fromTable != fragment.Table)
		{
			fragment.ColumnConditions.Each(delegate(DbColumnCondition cc)
			{
				cc.Column = TableOperations.CopyColumnAndAnyConstraints(database, fromTable, fragment.Table, cc.Column, useExisting: true, allowPkConstraintCopy: false);
			});
		}
	}
}
