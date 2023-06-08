using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Metadata.Edm;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;

internal class DecimalPropertyConfiguration : PrimitivePropertyConfiguration
{
	public byte? Precision { get; set; }

	public byte? Scale { get; set; }

	public DecimalPropertyConfiguration()
	{
	}

	private DecimalPropertyConfiguration(DecimalPropertyConfiguration source)
		: base(source)
	{
		Precision = source.Precision;
		Scale = source.Scale;
	}

	internal override PrimitivePropertyConfiguration Clone()
	{
		return new DecimalPropertyConfiguration(this);
	}

	internal override void Configure(System.Data.Entity.Edm.EdmProperty property)
	{
		base.Configure(property);
		if (((int?)Precision).HasValue)
		{
			property.PropertyType.PrimitiveTypeFacets.Precision = Precision;
		}
		if (((int?)Scale).HasValue)
		{
			property.PropertyType.PrimitiveTypeFacets.Scale = Scale;
		}
	}

	internal override void Configure(DbPrimitiveTypeFacets facets, FacetDescription facetDescription)
	{
		base.Configure(facets, facetDescription);
		switch (facetDescription.FacetName)
		{
		case "Precision":
			facets.Precision = (facetDescription.IsConstant ? null : (Precision ?? facets.Precision));
			break;
		case "Scale":
			facets.Scale = (facetDescription.IsConstant ? null : (Scale ?? facets.Scale));
			break;
		}
	}

	internal override void CopyFrom(PrimitivePropertyConfiguration other)
	{
		base.CopyFrom(other);
		if (other is DecimalPropertyConfiguration decimalPropertyConfiguration)
		{
			Precision = decimalPropertyConfiguration.Precision;
			Scale = decimalPropertyConfiguration.Scale;
		}
	}

	public override void FillFrom(PrimitivePropertyConfiguration other, bool inCSpace)
	{
		base.FillFrom(other, inCSpace);
		if (other is DecimalPropertyConfiguration decimalPropertyConfiguration)
		{
			if (!((int?)Precision).HasValue)
			{
				Precision = decimalPropertyConfiguration.Precision;
			}
			if (!((int?)Scale).HasValue)
			{
				Scale = decimalPropertyConfiguration.Scale;
			}
		}
	}

	public override bool IsCompatible(PrimitivePropertyConfiguration other, bool InCSpace, out string errorMessage)
	{
		DecimalPropertyConfiguration decimalPropertyConfiguration = other as DecimalPropertyConfiguration;
		bool flag = base.IsCompatible(other, InCSpace, out errorMessage);
		bool flag2 = decimalPropertyConfiguration == null || IsCompatible((DecimalPropertyConfiguration c) => c.Precision, decimalPropertyConfiguration, ref errorMessage);
		bool result = decimalPropertyConfiguration == null || IsCompatible((DecimalPropertyConfiguration c) => c.Scale, decimalPropertyConfiguration, ref errorMessage);
		if (flag && flag2)
		{
			return result;
		}
		return false;
	}
}
