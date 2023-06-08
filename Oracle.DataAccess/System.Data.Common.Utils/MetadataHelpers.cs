using System.Collections.Generic;
using System.Data.Metadata.Edm;

namespace System.Data.Common.Utils;

internal static class MetadataHelpers
{
	internal const string MaxLengthFacetName = "MaxLength";

	internal const string UnicodeFacetName = "Unicode";

	internal const string FixedLengthFacetName = "FixedLength";

	internal const string PrecisionFacetName = "Precision";

	internal const string ScaleFacetName = "Scale";

	internal const string NullableFacetName = "Nullable";

	internal const string DefaultValueFacetName = "DefaultValue";

	internal const string TableMetadata = "Table";

	internal const string SchemaMetadata = "Schema";

	internal const string DefiningQueryMetadata = "DefiningQuery";

	internal const string CommandTextMetadata = "CommandTextAttribute";

	internal const string StoreFunctionNameMetadata = "StoreFunctionNameAttribute";

	internal const string BuiltInMetadata = "BuiltInAttribute";

	internal const string NiladicFunctionMetadata = "NiladicFunctionAttribute";

	internal const string OracleCursorParameterNameMetadata = "EFOracleProviderExtensions:CursorParameterName";

	internal const string EdmNamespaceName = "Edm";

	internal static FacetDescription GetFacet(IEnumerable<FacetDescription> facetCollection, string facetName)
	{
		foreach (FacetDescription item in facetCollection)
		{
			if (item.FacetName == facetName)
			{
				return item;
			}
		}
		return null;
	}

	internal static bool TryGetBooleanFacetValue(TypeUsage type, string facetName, out bool boolValue)
	{
		boolValue = false;
		if (type.Facets.TryGetValue(facetName, ignoreCase: false, out var item) && item.Value != null)
		{
			boolValue = (bool)item.Value;
			return true;
		}
		return false;
	}

	internal static bool TryGetByteFacetValue(TypeUsage type, string facetName, out byte byteValue)
	{
		byteValue = 0;
		if (type.Facets.TryGetValue(facetName, ignoreCase: false, out var item) && item.Value != null && !item.IsUnbounded)
		{
			byteValue = (byte)item.Value;
			return true;
		}
		return false;
	}

	internal static bool TryGetIntFacetValue(TypeUsage type, string facetName, out int intValue)
	{
		intValue = 0;
		if (type.Facets.TryGetValue(facetName, ignoreCase: false, out var item) && item.Value != null && !item.IsUnbounded)
		{
			intValue = (int)item.Value;
			return true;
		}
		return false;
	}

	internal static bool TryGetIsFixedLength(TypeUsage type, out bool isFixedLength)
	{
		if (!IsPrimitiveType(type, PrimitiveTypeKind.String) && !IsPrimitiveType(type, PrimitiveTypeKind.Binary))
		{
			isFixedLength = false;
			return false;
		}
		return TryGetBooleanFacetValue(type, "FixedLength", out isFixedLength);
	}

	internal static bool TryGetIsUnicode(TypeUsage type, out bool isUnicode)
	{
		if (!IsPrimitiveType(type, PrimitiveTypeKind.String))
		{
			isUnicode = false;
			return false;
		}
		return TryGetBooleanFacetValue(type, "Unicode", out isUnicode);
	}

	internal static bool IsFacetValueConstant(TypeUsage type, string facetName)
	{
		return GetFacet(((PrimitiveType)type.EdmType).FacetDescriptions, facetName).IsConstant;
	}

	internal static bool TryGetMaxLength(TypeUsage type, out int maxLength)
	{
		if (!IsPrimitiveType(type, PrimitiveTypeKind.String) && !IsPrimitiveType(type, PrimitiveTypeKind.Binary))
		{
			maxLength = 0;
			return false;
		}
		return TryGetIntFacetValue(type, "MaxLength", out maxLength);
	}

	internal static bool TryGetPrecision(TypeUsage type, out byte precision)
	{
		if (!IsPrimitiveType(type, PrimitiveTypeKind.Decimal))
		{
			precision = 0;
			return false;
		}
		return TryGetByteFacetValue(type, "Precision", out precision);
	}

	internal static bool TryGetScale(TypeUsage type, out byte scale)
	{
		if (!IsPrimitiveType(type, PrimitiveTypeKind.Decimal))
		{
			scale = 0;
			return false;
		}
		return TryGetByteFacetValue(type, "Scale", out scale);
	}

	internal static bool TryGetPrimitiveTypeKind(TypeUsage type, out PrimitiveTypeKind typeKind)
	{
		if (type != null && type.EdmType != null && type.EdmType.BuiltInTypeKind == BuiltInTypeKind.PrimitiveType)
		{
			typeKind = ((PrimitiveType)type.EdmType).PrimitiveTypeKind;
			return true;
		}
		typeKind = PrimitiveTypeKind.Binary;
		return false;
	}

	internal static PrimitiveTypeKind GetPrimitiveTypeKind(TypeUsage typeUsage)
	{
		PrimitiveType primitiveType = (PrimitiveType)typeUsage.EdmType;
		return primitiveType.PrimitiveTypeKind;
	}

	internal static bool IsPrimitiveType(EdmType type)
	{
		return BuiltInTypeKind.PrimitiveType == type.BuiltInTypeKind;
	}

	internal static bool IsPrimitiveType(TypeUsage type, PrimitiveTypeKind primitiveTypeKind)
	{
		if (TryGetPrimitiveTypeKind(type, out var typeKind))
		{
			return typeKind == primitiveTypeKind;
		}
		return false;
	}

	internal static bool IsNullable(TypeUsage type)
	{
		if (type.Facets.TryGetValue("Nullable", ignoreCase: false, out var item))
		{
			return (bool)item.Value;
		}
		return true;
	}

	internal static bool IsReferenceType(GlobalItem item)
	{
		return BuiltInTypeKind.RefType == item.BuiltInTypeKind;
	}

	internal static bool IsRowType(GlobalItem item)
	{
		return BuiltInTypeKind.RowType == item.BuiltInTypeKind;
	}

	internal static bool IsCollectionType(GlobalItem item)
	{
		return BuiltInTypeKind.CollectionType == item.BuiltInTypeKind;
	}

	internal static TypeUsage GetElementTypeUsage(TypeUsage type)
	{
		if (IsCollectionType(type.EdmType))
		{
			return ((CollectionType)type.EdmType).TypeUsage;
		}
		if (IsReferenceType(type.EdmType))
		{
			return TypeUsage.CreateDefaultTypeUsage(((RefType)type.EdmType).ElementType);
		}
		return null;
	}

	internal static TEdmType GetEdmType<TEdmType>(TypeUsage typeUsage) where TEdmType : EdmType
	{
		return (TEdmType)typeUsage.EdmType;
	}

	internal static bool IsCanonicalFunction(EdmFunction function)
	{
		return function.NamespaceName.Equals("Edm", StringComparison.InvariantCulture);
	}

	internal static IList<EdmProperty> GetProperties(TypeUsage typeUsage)
	{
		return GetProperties(typeUsage.EdmType);
	}

	internal static IList<EdmProperty> GetProperties(EdmType edmType)
	{
		return edmType.BuiltInTypeKind switch
		{
			BuiltInTypeKind.ComplexType => ((ComplexType)edmType).Properties, 
			BuiltInTypeKind.EntityType => ((EntityType)edmType).Properties, 
			BuiltInTypeKind.RowType => ((RowType)edmType).Properties, 
			_ => new List<EdmProperty>(), 
		};
	}

	internal static T GetMetadataProperty<T>(MetadataItem item, string propertyName)
	{
		if (!item.MetadataProperties.TryGetValue(propertyName, ignoreCase: true, out var item2) || !(item2.Value is T))
		{
			return default(T);
		}
		return (T)item2.Value;
	}

	internal static ParameterDirection ParameterModeToParameterDirection(ParameterMode mode)
	{
		return mode switch
		{
			ParameterMode.In => ParameterDirection.Input, 
			ParameterMode.InOut => ParameterDirection.InputOutput, 
			ParameterMode.Out => ParameterDirection.Output, 
			ParameterMode.ReturnValue => ParameterDirection.ReturnValue, 
			_ => (ParameterDirection)0, 
		};
	}
}
