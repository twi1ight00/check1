using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;

internal static class DbEntityTypeMappingExtensions
{
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static object GetConfiguration(this DbEntityTypeMapping entityTypeMapping)
	{
		return entityTypeMapping.Annotations.GetConfiguration();
	}

	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static void SetConfiguration(this DbEntityTypeMapping entityTypeMapping, object configuration)
	{
		entityTypeMapping.Annotations.SetConfiguration(configuration);
	}

	public static DbEdmPropertyMapping GetPropertyMapping(this DbEntityTypeMapping entityTypeMapping, params EdmProperty[] propertyPath)
	{
		return entityTypeMapping.TypeMappingFragments.SelectMany((DbEntityTypeMappingFragment f) => f.PropertyMappings).Single((DbEdmPropertyMapping p) => p.PropertyPath.SequenceEqual(propertyPath));
	}

	public static DbTableMetadata GetPrimaryTable(this DbEntityTypeMapping entityTypeMapping)
	{
		return entityTypeMapping.TypeMappingFragments.First().Table;
	}

	public static bool UsesOtherTables(this DbEntityTypeMapping entityTypeMapping, DbTableMetadata table)
	{
		return entityTypeMapping.TypeMappingFragments.Any((DbEntityTypeMappingFragment f) => f.Table != table);
	}

	public static Type GetClrType(this DbEntityTypeMapping entityTypeMappping)
	{
		return entityTypeMappping.Annotations.GetClrType();
	}

	public static void SetClrType(this DbEntityTypeMapping entityTypeMapping, Type type)
	{
		entityTypeMapping.Annotations.SetClrType(type);
	}

	public static DbEntityTypeMapping Clone(this DbEntityTypeMapping entityTypeMappping)
	{
		DbEntityTypeMapping dbEntityTypeMapping = new DbEntityTypeMapping();
		dbEntityTypeMapping.EntityType = entityTypeMappping.EntityType;
		DbEntityTypeMapping dbEntityTypeMapping2 = dbEntityTypeMapping;
		entityTypeMappping.Annotations.Copy(dbEntityTypeMapping2.Annotations);
		return dbEntityTypeMapping2;
	}
}
