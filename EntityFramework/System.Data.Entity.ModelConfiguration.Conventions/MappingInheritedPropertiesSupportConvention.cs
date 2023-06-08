using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Edm.Internal;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to ensure an invalid/unsupported mapping is not created when mapping inherited properties
/// </summary>
public sealed class MappingInheritedPropertiesSupportConvention : IDbMappingConvention, IConvention
{
	internal MappingInheritedPropertiesSupportConvention()
	{
	}

	void IDbMappingConvention.Apply(DbDatabaseMapping databaseMapping)
	{
		databaseMapping.EntityContainerMappings.SelectMany((DbEntityContainerMapping ecm) => ecm.EntitySetMappings).Each(delegate(DbEntitySetMapping esm)
		{
			foreach (DbEntityTypeMapping entityTypeMapping in esm.EntityTypeMappings)
			{
				if (RemapsInheritedProperties(databaseMapping, entityTypeMapping) && HasBaseWithIsTypeOf(esm, entityTypeMapping.EntityType))
				{
					throw Error.UnsupportedHybridInheritanceMapping(entityTypeMapping.EntityType.Name);
				}
			}
		});
	}

	private bool RemapsInheritedProperties(DbDatabaseMapping databaseMapping, DbEntityTypeMapping entityTypeMapping)
	{
		IEnumerable<EdmProperty> enumerable = entityTypeMapping.EntityType.Properties.Except(entityTypeMapping.EntityType.DeclaredProperties).Except(entityTypeMapping.EntityType.GetKeyProperties());
		foreach (EdmProperty item in enumerable)
		{
			DbEntityTypeMappingFragment fragmentForPropertyMapping = GetFragmentForPropertyMapping(entityTypeMapping, item);
			if (fragmentForPropertyMapping == null)
			{
				continue;
			}
			for (EdmEntityType baseType = entityTypeMapping.EntityType.BaseType; baseType != null; baseType = baseType.BaseType)
			{
				foreach (DbEntityTypeMapping entityTypeMapping2 in databaseMapping.GetEntityTypeMappings(baseType))
				{
					DbEntityTypeMappingFragment fragmentForPropertyMapping2 = GetFragmentForPropertyMapping(entityTypeMapping2, item);
					if (fragmentForPropertyMapping2 != null && fragmentForPropertyMapping2.Table != fragmentForPropertyMapping.Table)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private static DbEntityTypeMappingFragment GetFragmentForPropertyMapping(DbEntityTypeMapping entityTypeMapping, EdmProperty property)
	{
		return entityTypeMapping.TypeMappingFragments.Where((DbEntityTypeMappingFragment tmf) => tmf.PropertyMappings.Any((DbEdmPropertyMapping pm) => pm.PropertyPath.Last() == property)).SingleOrDefault();
	}

	private bool HasBaseWithIsTypeOf(DbEntitySetMapping entitySetMapping, EdmEntityType entityType)
	{
		EdmEntityType baseType;
		for (baseType = entityType.BaseType; baseType != null; baseType = baseType.BaseType)
		{
			if (entitySetMapping.EntityTypeMappings.Where((DbEntityTypeMapping etm) => etm.EntityType == baseType).Any((DbEntityTypeMapping etm) => etm.IsHierarchyMapping))
			{
				return true;
			}
		}
		return false;
	}
}
