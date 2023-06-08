using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;

internal static class DbEntityTypeMappingFragmentExtensions
{
	private const string DefaultDiscriminatorAnnotation = "DefaultDiscriminator";

	private const string ConditionOnlyFragmentAnnotation = "ConditionOnlyFragment";

	private const string UnmappedPropertiesFragmentAnnotation = "UnmappedPropertiesFragment";

	public static DbTableColumnMetadata GetDefaultDiscriminator(this DbEntityTypeMappingFragment entityTypeMapppingFragment)
	{
		return (DbTableColumnMetadata)entityTypeMapppingFragment.Annotations.GetAnnotation("DefaultDiscriminator");
	}

	public static void SetDefaultDiscriminator(this DbEntityTypeMappingFragment entityTypeMappingFragment, DbTableColumnMetadata discriminator)
	{
		entityTypeMappingFragment.Annotations.SetAnnotation("DefaultDiscriminator", discriminator);
	}

	public static void RemoveDefaultDiscriminatorAnnotation(this DbEntityTypeMappingFragment entityTypeMappingFragment)
	{
		entityTypeMappingFragment.Annotations.RemoveAnnotation("DefaultDiscriminator");
	}

	public static void RemoveDefaultDiscriminator(this DbEntityTypeMappingFragment entityTypeMappingFragment, DbEntitySetMapping entitySetMapping)
	{
		DbTableColumnMetadata discriminatorColumn = entityTypeMappingFragment.RemoveDefaultDiscriminatorCondition();
		if (discriminatorColumn != null)
		{
			DbTableMetadata table = entityTypeMappingFragment.Table;
			table.Columns.Where((DbTableColumnMetadata c) => c.Name.Equals(discriminatorColumn.Name, StringComparison.Ordinal)).ToList().Each((DbTableColumnMetadata column) => table.Columns.Remove(column));
		}
		if (entitySetMapping != null && entityTypeMappingFragment.IsConditionOnlyFragment() && !entityTypeMappingFragment.ColumnConditions.Any())
		{
			DbEntityTypeMapping dbEntityTypeMapping = entitySetMapping.EntityTypeMappings.Single((DbEntityTypeMapping etm) => etm.TypeMappingFragments.Contains(entityTypeMappingFragment));
			dbEntityTypeMapping.TypeMappingFragments.Remove(entityTypeMappingFragment);
			if (dbEntityTypeMapping.TypeMappingFragments.Count == 0)
			{
				entitySetMapping.EntityTypeMappings.Remove(dbEntityTypeMapping);
			}
		}
	}

	public static DbTableColumnMetadata RemoveDefaultDiscriminatorCondition(this DbEntityTypeMappingFragment entityTypeMappingFragment)
	{
		DbTableColumnMetadata defaultDiscriminator = entityTypeMappingFragment.GetDefaultDiscriminator();
		if (defaultDiscriminator != null && entityTypeMappingFragment.ColumnConditions.Count > 0)
		{
			entityTypeMappingFragment.ColumnConditions.RemoveAt(0);
		}
		entityTypeMappingFragment.RemoveDefaultDiscriminatorAnnotation();
		return defaultDiscriminator;
	}

	public static void AddDiscriminatorCondition(this DbEntityTypeMappingFragment entityTypeMapppingFragment, DbTableColumnMetadata discriminatorColumn, object value)
	{
		entityTypeMapppingFragment.ColumnConditions.Add(new DbColumnCondition
		{
			Column = discriminatorColumn,
			Value = value
		});
	}

	public static void AddNullabilityCondition(this DbEntityTypeMappingFragment entityTypeMapppingFragment, DbTableColumnMetadata column, bool isNull)
	{
		entityTypeMapppingFragment.ColumnConditions.Add(new DbColumnCondition
		{
			Column = column,
			IsNull = isNull
		});
	}

	public static bool IsConditionOnlyFragment(this DbEntityTypeMappingFragment entityTypeMapppingFragment)
	{
		object annotation = entityTypeMapppingFragment.Annotations.GetAnnotation("ConditionOnlyFragment");
		if (annotation != null)
		{
			return (bool)annotation;
		}
		return false;
	}

	public static void SetIsConditionOnlyFragment(this DbEntityTypeMappingFragment entityTypeMapppingFragment, bool isConditionOnlyFragment)
	{
		if (isConditionOnlyFragment)
		{
			entityTypeMapppingFragment.Annotations.SetAnnotation("ConditionOnlyFragment", isConditionOnlyFragment);
		}
		else
		{
			entityTypeMapppingFragment.Annotations.RemoveAnnotation("ConditionOnlyFragment");
		}
	}

	public static bool IsUnmappedPropertiesFragment(this DbEntityTypeMappingFragment entityTypeMapppingFragment)
	{
		object annotation = entityTypeMapppingFragment.Annotations.GetAnnotation("UnmappedPropertiesFragment");
		if (annotation != null)
		{
			return (bool)annotation;
		}
		return false;
	}

	public static void SetIsUnmappedPropertiesFragment(this DbEntityTypeMappingFragment entityTypeMapppingFragment, bool isUnmappedPropertiesFragment)
	{
		if (isUnmappedPropertiesFragment)
		{
			entityTypeMapppingFragment.Annotations.SetAnnotation("UnmappedPropertiesFragment", isUnmappedPropertiesFragment);
		}
		else
		{
			entityTypeMapppingFragment.Annotations.RemoveAnnotation("UnmappedPropertiesFragment");
		}
	}
}
