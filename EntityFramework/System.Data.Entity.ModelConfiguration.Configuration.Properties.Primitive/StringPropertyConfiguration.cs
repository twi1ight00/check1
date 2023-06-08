using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Metadata.Edm;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;

internal class StringPropertyConfiguration : LengthPropertyConfiguration
{
	public bool? IsUnicode { get; set; }

	public StringPropertyConfiguration()
	{
	}

	private StringPropertyConfiguration(StringPropertyConfiguration source)
		: base(source)
	{
		IsUnicode = source.IsUnicode;
	}

	internal override PrimitivePropertyConfiguration Clone()
	{
		return new StringPropertyConfiguration(this);
	}

	internal override void Configure(System.Data.Entity.Edm.EdmProperty property)
	{
		base.Configure(property);
		if (IsUnicode.HasValue)
		{
			property.PropertyType.PrimitiveTypeFacets.IsUnicode = IsUnicode;
		}
	}

	internal override void Configure(DbPrimitiveTypeFacets facets, FacetDescription facetDescription)
	{
		base.Configure(facets, facetDescription);
		string facetName;
		if ((facetName = facetDescription.FacetName) != null && facetName == "Unicode")
		{
			facets.IsUnicode = (facetDescription.IsConstant ? null : (IsUnicode ?? facets.IsUnicode));
		}
	}

	internal override void CopyFrom(PrimitivePropertyConfiguration other)
	{
		base.CopyFrom(other);
		if (other is StringPropertyConfiguration stringPropertyConfiguration)
		{
			IsUnicode = stringPropertyConfiguration.IsUnicode;
		}
	}

	public override void FillFrom(PrimitivePropertyConfiguration other, bool inCSpace)
	{
		base.FillFrom(other, inCSpace);
		if (other is StringPropertyConfiguration stringPropertyConfiguration && !IsUnicode.HasValue)
		{
			IsUnicode = stringPropertyConfiguration.IsUnicode;
		}
	}

	public override bool IsCompatible(PrimitivePropertyConfiguration other, bool InCSpace, out string errorMessage)
	{
		StringPropertyConfiguration stringPropertyConfiguration = other as StringPropertyConfiguration;
		bool flag = base.IsCompatible(other, InCSpace, out errorMessage);
		bool result = stringPropertyConfiguration == null || IsCompatible((StringPropertyConfiguration c) => c.IsUnicode, stringPropertyConfiguration, ref errorMessage);
		if (flag)
		{
			return result;
		}
		return false;
	}
}
