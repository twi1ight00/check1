using System.Collections.Generic;
using System.Data.Entity.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to set a default maximum length of 4000 for properties whose type supports length facets when SqlCe is the provider.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", Justification = "Casing is intentional")]
public sealed class SqlCePropertyMaxLengthConvention : IEdmConvention<EdmEntityType>, IEdmConvention<EdmComplexType>, IConvention
{
	private const int DefaultLength = 4000;

	internal SqlCePropertyMaxLengthConvention()
	{
	}

	void IEdmConvention<EdmEntityType>.Apply(EdmEntityType entityType, EdmModel model)
	{
		DbProviderInfo providerInfo = model.GetProviderInfo();
		if (providerInfo != null && providerInfo.IsSqlCe())
		{
			SetLength(entityType.DeclaredProperties);
		}
	}

	void IEdmConvention<EdmComplexType>.Apply(EdmComplexType complexType, EdmModel model)
	{
		DbProviderInfo providerInfo = model.GetProviderInfo();
		if (providerInfo != null && providerInfo.IsSqlCe())
		{
			SetLength(complexType.DeclaredProperties);
		}
	}

	private static void SetLength(IEnumerable<EdmProperty> properties)
	{
		foreach (EdmProperty property in properties)
		{
			if (property.PropertyType.IsPrimitiveType && (property.PropertyType.PrimitiveType == EdmPrimitiveType.String || property.PropertyType.PrimitiveType == EdmPrimitiveType.Binary))
			{
				SetDefaults(property);
			}
		}
	}

	private static void SetDefaults(EdmProperty property)
	{
		EdmPrimitiveTypeFacets primitiveTypeFacets = property.PropertyType.PrimitiveTypeFacets;
		if (!primitiveTypeFacets.MaxLength.HasValue && !primitiveTypeFacets.IsMaxLength.HasValue)
		{
			primitiveTypeFacets.MaxLength = 4000;
		}
	}
}
