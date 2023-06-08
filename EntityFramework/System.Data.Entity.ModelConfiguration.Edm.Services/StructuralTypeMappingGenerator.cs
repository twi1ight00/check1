using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Edm.Db.Mapping;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;
using System.Linq;

namespace System.Data.Entity.ModelConfiguration.Edm.Services;

internal abstract class StructuralTypeMappingGenerator
{
	protected readonly DbProviderManifest _providerManifest;

	protected StructuralTypeMappingGenerator(DbProviderManifest providerManifest)
	{
		_providerManifest = providerManifest;
	}

	protected void MapTableColumn(System.Data.Entity.Edm.EdmProperty property, DbTableColumnMetadata tableColumnMetadata, bool isInstancePropertyOnDerivedType, bool isKeyProperty = false)
	{
		TypeUsage storeType = _providerManifest.GetStoreType(GetEdmTypeUsage(property.PropertyType));
		tableColumnMetadata.TypeName = storeType.EdmType.Name;
		tableColumnMetadata.IsPrimaryKeyColumn = isKeyProperty;
		if (isInstancePropertyOnDerivedType)
		{
			tableColumnMetadata.IsNullable = true;
		}
		else if (property.PropertyType.IsNullable.HasValue)
		{
			tableColumnMetadata.IsNullable = property.PropertyType.IsNullable.Value;
		}
		if (tableColumnMetadata.IsPrimaryKeyColumn)
		{
			tableColumnMetadata.IsNullable = false;
		}
		DbStoreGeneratedPattern? storeGeneratedPattern = property.GetStoreGeneratedPattern();
		if (storeGeneratedPattern.HasValue)
		{
			tableColumnMetadata.StoreGeneratedPattern = storeGeneratedPattern.Value;
		}
		MapPrimitivePropertyFacets(property.PropertyType.PrimitiveTypeFacets, tableColumnMetadata.Facets, storeType);
	}

	private static TypeUsage GetEdmTypeUsage(EdmTypeReference edmTypeReference)
	{
		EdmPrimitiveTypeFacets primitiveTypeFacets = edmTypeReference.PrimitiveTypeFacets;
		PrimitiveType edmPrimitiveType = PrimitiveType.GetEdmPrimitiveType((PrimitiveTypeKind)edmTypeReference.PrimitiveType.PrimitiveTypeKind);
		if (edmTypeReference.PrimitiveType == EdmPrimitiveType.String && primitiveTypeFacets.IsUnicode.HasValue && primitiveTypeFacets.IsFixedLength.HasValue)
		{
			if (!primitiveTypeFacets.MaxLength.HasValue)
			{
				return TypeUsage.CreateStringTypeUsage(edmPrimitiveType, primitiveTypeFacets.IsUnicode.Value, primitiveTypeFacets.IsFixedLength.Value);
			}
			return TypeUsage.CreateStringTypeUsage(edmPrimitiveType, primitiveTypeFacets.IsUnicode.Value, primitiveTypeFacets.IsFixedLength.Value, primitiveTypeFacets.MaxLength.Value);
		}
		if (edmTypeReference.PrimitiveType == EdmPrimitiveType.Binary && primitiveTypeFacets.IsFixedLength.HasValue)
		{
			if (!primitiveTypeFacets.MaxLength.HasValue)
			{
				return TypeUsage.CreateBinaryTypeUsage(edmPrimitiveType, primitiveTypeFacets.IsFixedLength.Value);
			}
			return TypeUsage.CreateBinaryTypeUsage(edmPrimitiveType, primitiveTypeFacets.IsFixedLength.Value, primitiveTypeFacets.MaxLength.Value);
		}
		if (edmTypeReference.PrimitiveType == EdmPrimitiveType.Time && ((int?)primitiveTypeFacets.Precision).HasValue)
		{
			return TypeUsage.CreateTimeTypeUsage(edmPrimitiveType, primitiveTypeFacets.Precision);
		}
		if (edmTypeReference.PrimitiveType == EdmPrimitiveType.DateTime && ((int?)primitiveTypeFacets.Precision).HasValue)
		{
			return TypeUsage.CreateDateTimeTypeUsage(edmPrimitiveType, primitiveTypeFacets.Precision);
		}
		if (edmTypeReference.PrimitiveType == EdmPrimitiveType.DateTimeOffset && ((int?)primitiveTypeFacets.Precision).HasValue)
		{
			return TypeUsage.CreateDateTimeOffsetTypeUsage(edmPrimitiveType, primitiveTypeFacets.Precision);
		}
		if (edmTypeReference.PrimitiveType == EdmPrimitiveType.Decimal)
		{
			if (!((int?)primitiveTypeFacets.Precision).HasValue || !((int?)primitiveTypeFacets.Scale).HasValue)
			{
				return TypeUsage.CreateDecimalTypeUsage(edmPrimitiveType);
			}
			return TypeUsage.CreateDecimalTypeUsage(edmPrimitiveType, primitiveTypeFacets.Precision.Value, primitiveTypeFacets.Scale.Value);
		}
		return TypeUsage.CreateDefaultTypeUsage(edmPrimitiveType);
	}

	internal static void MapPrimitivePropertyFacets(EdmPrimitiveTypeFacets primitiveTypeFacets, DbPrimitiveTypeFacets dbPrimitiveTypeFacets, TypeUsage typeUsage)
	{
		if (IsValidFacet(typeUsage, "FixedLength"))
		{
			dbPrimitiveTypeFacets.IsFixedLength = primitiveTypeFacets.IsFixedLength;
		}
		if (IsValidFacet(typeUsage, "MaxLength"))
		{
			dbPrimitiveTypeFacets.IsMaxLength = primitiveTypeFacets.IsMaxLength;
			dbPrimitiveTypeFacets.MaxLength = primitiveTypeFacets.MaxLength;
		}
		if (IsValidFacet(typeUsage, "Unicode"))
		{
			dbPrimitiveTypeFacets.IsUnicode = primitiveTypeFacets.IsUnicode;
		}
		if (IsValidFacet(typeUsage, "Precision"))
		{
			dbPrimitiveTypeFacets.Precision = primitiveTypeFacets.Precision;
		}
		if (IsValidFacet(typeUsage, "Scale"))
		{
			dbPrimitiveTypeFacets.Scale = primitiveTypeFacets.Scale;
		}
	}

	private static bool IsValidFacet(TypeUsage typeUsage, string name)
	{
		if (typeUsage.Facets.TryGetValue(name, ignoreCase: false, out var item))
		{
			return !item.Description.IsConstant;
		}
		return false;
	}

	protected static DbEntityTypeMapping GetEntityTypeMappingInHierarchy(DbDatabaseMapping databaseMapping, EdmEntityType entityType)
	{
		DbEntityTypeMapping dbEntityTypeMapping = databaseMapping.GetEntityTypeMapping(entityType);
		if (dbEntityTypeMapping == null)
		{
			DbEntitySetMapping entitySetMapping = databaseMapping.GetEntitySetMapping(databaseMapping.Model.GetEntitySet(entityType));
			if (entitySetMapping != null)
			{
				dbEntityTypeMapping = entitySetMapping.EntityTypeMappings.First((DbEntityTypeMapping etm) => entityType.DeclaredProperties.All((System.Data.Entity.Edm.EdmProperty dp) => etm.TypeMappingFragments.First().PropertyMappings.Select((DbEdmPropertyMapping pm) => pm.PropertyPath.First()).Contains(dp)));
			}
		}
		if (dbEntityTypeMapping == null)
		{
			throw Error.UnmappedAbstractType(entityType.GetClrType());
		}
		return dbEntityTypeMapping;
	}
}
