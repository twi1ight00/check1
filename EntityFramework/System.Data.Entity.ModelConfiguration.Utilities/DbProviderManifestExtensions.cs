using System.Data.Common;
using System.Data.Metadata.Edm;

namespace System.Data.Entity.ModelConfiguration.Utilities;

internal static class DbProviderManifestExtensions
{
	public static string GetStoreTypeName(this DbProviderManifest providerManifest, PrimitiveTypeKind primitiveTypeKind)
	{
		TypeUsage edmType = TypeUsage.CreateDefaultTypeUsage(PrimitiveType.GetEdmPrimitiveType(primitiveTypeKind));
		return providerManifest.GetStoreType(edmType).EdmType.Name;
	}
}
