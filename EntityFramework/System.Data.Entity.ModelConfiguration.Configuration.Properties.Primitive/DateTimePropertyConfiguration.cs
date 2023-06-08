using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Metadata.Edm;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;

internal class DateTimePropertyConfiguration : PrimitivePropertyConfiguration
{
	public byte? Precision { get; set; }

	public DateTimePropertyConfiguration()
	{
	}

	private DateTimePropertyConfiguration(DateTimePropertyConfiguration source)
		: base(source)
	{
		Precision = source.Precision;
	}

	internal override PrimitivePropertyConfiguration Clone()
	{
		return new DateTimePropertyConfiguration(this);
	}

	internal override void Configure(System.Data.Entity.Edm.EdmProperty property)
	{
		base.Configure(property);
		if (((int?)Precision).HasValue)
		{
			property.PropertyType.PrimitiveTypeFacets.Precision = Precision;
		}
	}

	internal override void Configure(DbPrimitiveTypeFacets facets, FacetDescription facetDescription)
	{
		base.Configure(facets, facetDescription);
		string facetName;
		if ((facetName = facetDescription.FacetName) != null && facetName == "Precision")
		{
			facets.Precision = (facetDescription.IsConstant ? null : (Precision ?? facets.Precision));
		}
	}

	internal override void CopyFrom(PrimitivePropertyConfiguration other)
	{
		base.CopyFrom(other);
		if (other is DateTimePropertyConfiguration dateTimePropertyConfiguration)
		{
			Precision = dateTimePropertyConfiguration.Precision;
		}
	}

	public override void FillFrom(PrimitivePropertyConfiguration other, bool inCSpace)
	{
		base.FillFrom(other, inCSpace);
		if (other is DateTimePropertyConfiguration dateTimePropertyConfiguration && !((int?)Precision).HasValue)
		{
			Precision = dateTimePropertyConfiguration.Precision;
		}
	}

	public override bool IsCompatible(PrimitivePropertyConfiguration other, bool InCSpace, out string errorMessage)
	{
		DateTimePropertyConfiguration dateTimePropertyConfiguration = other as DateTimePropertyConfiguration;
		bool flag = base.IsCompatible(other, InCSpace, out errorMessage);
		bool result = dateTimePropertyConfiguration == null || IsCompatible((DateTimePropertyConfiguration c) => c.Precision, dateTimePropertyConfiguration, ref errorMessage);
		if (flag)
		{
			return result;
		}
		return false;
	}
}
