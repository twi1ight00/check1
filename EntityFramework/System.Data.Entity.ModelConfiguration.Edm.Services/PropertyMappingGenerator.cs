using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.Resources;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Services;

internal class PropertyMappingGenerator : StructuralTypeMappingGenerator
{
	public PropertyMappingGenerator(DbProviderManifest providerManifest)
		: base(providerManifest)
	{
	}

	public void Generate(EdmEntityType entityType, IEnumerable<EdmProperty> properties, DbEntitySetMapping entitySetMapping, DbEntityTypeMappingFragment entityTypeMappingFragment, IList<EdmProperty> propertyPath, bool createNewColumn)
	{
		IList<EdmProperty> declaredProperties = entityType.GetRootType().DeclaredProperties;
		EdmProperty property;
		foreach (EdmProperty property2 in properties)
		{
			property = property2;
			if (property.PropertyType.IsComplexType && propertyPath.Any((EdmProperty p) => p.PropertyType.IsComplexType && p.PropertyType.ComplexType == property.PropertyType.ComplexType))
			{
				throw Error.CircularComplexTypeHierarchy();
			}
			propertyPath.Add(property);
			if (property.PropertyType.IsComplexType)
			{
				Generate(entityType, property.PropertyType.ComplexType.DeclaredProperties, entitySetMapping, entityTypeMappingFragment, propertyPath, createNewColumn);
			}
			else
			{
				DbTableColumnMetadata dbTableColumnMetadata = (from pm in entitySetMapping.EntityTypeMappings.SelectMany((DbEntityTypeMapping etm) => etm.TypeMappingFragments).SelectMany((DbEntityTypeMappingFragment etmf) => etmf.PropertyMappings)
					where pm.PropertyPath.SequenceEqual(propertyPath)
					select pm.Column).FirstOrDefault();
				if (dbTableColumnMetadata == null || createNewColumn)
				{
					dbTableColumnMetadata = entityTypeMappingFragment.Table.AddColumn(string.Join("_", propertyPath.Select((EdmProperty p) => p.Name)));
					MapTableColumn(property, dbTableColumnMetadata, !declaredProperties.Contains(propertyPath.First()), entityType.KeyProperties().Contains(property));
				}
				entityTypeMappingFragment.PropertyMappings.Add(new DbEdmPropertyMapping
				{
					Column = dbTableColumnMetadata,
					PropertyPath = propertyPath.ToList()
				});
			}
			propertyPath.Remove(property);
		}
	}
}
