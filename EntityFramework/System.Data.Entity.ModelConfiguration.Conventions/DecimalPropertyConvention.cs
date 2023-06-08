using System.Data.Entity.Edm;

namespace System.Data.Entity.ModelConfiguration.Conventions;

/// <summary>
///     Convention to set precision to 18 and scale to 2 for decimal properties.
/// </summary>
public sealed class DecimalPropertyConvention : IEdmConvention<EdmProperty>, IConvention
{
	internal DecimalPropertyConvention()
	{
	}

	void IEdmConvention<EdmProperty>.Apply(EdmProperty property, EdmModel model)
	{
		if (property.PropertyType.PrimitiveType == EdmPrimitiveType.Decimal)
		{
			EdmPrimitiveTypeFacets primitiveTypeFacets = property.PropertyType.PrimitiveTypeFacets;
			if (!((int?)primitiveTypeFacets.Precision).HasValue)
			{
				primitiveTypeFacets.Precision = 18;
			}
			if (!((int?)primitiveTypeFacets.Scale).HasValue)
			{
				primitiveTypeFacets.Scale = 2;
			}
		}
	}
}
