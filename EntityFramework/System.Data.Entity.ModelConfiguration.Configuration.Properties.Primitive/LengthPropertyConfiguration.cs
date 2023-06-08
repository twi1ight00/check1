using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Metadata.Edm;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;

internal abstract class LengthPropertyConfiguration : PrimitivePropertyConfiguration
{
	public bool? IsFixedLength { get; set; }

	public int? MaxLength { get; set; }

	public bool? IsMaxLength { get; set; }

	protected LengthPropertyConfiguration()
	{
	}

	protected LengthPropertyConfiguration(LengthPropertyConfiguration source)
		: base(source)
	{
		IsFixedLength = source.IsFixedLength;
		MaxLength = source.MaxLength;
		IsMaxLength = source.IsMaxLength;
	}

	internal override void Configure(System.Data.Entity.Edm.EdmProperty property)
	{
		base.Configure(property);
		if (IsFixedLength.HasValue)
		{
			property.PropertyType.PrimitiveTypeFacets.IsFixedLength = IsFixedLength;
		}
		if (MaxLength.HasValue)
		{
			property.PropertyType.PrimitiveTypeFacets.MaxLength = MaxLength;
		}
		if (IsMaxLength.HasValue)
		{
			property.PropertyType.PrimitiveTypeFacets.IsMaxLength = IsMaxLength;
		}
	}

	internal override void Configure(DbPrimitiveTypeFacets facets, FacetDescription facetDescription)
	{
		switch (facetDescription.FacetName)
		{
		case "FixedLength":
			facets.IsFixedLength = (facetDescription.IsConstant ? null : (IsFixedLength ?? facets.IsFixedLength));
			break;
		case "MaxLength":
			facets.MaxLength = (facetDescription.IsConstant ? null : (MaxLength ?? facets.MaxLength));
			facets.IsMaxLength = (facetDescription.IsConstant ? null : (IsMaxLength ?? facets.IsMaxLength));
			break;
		}
	}

	internal override void CopyFrom(PrimitivePropertyConfiguration other)
	{
		base.CopyFrom(other);
		if (other is LengthPropertyConfiguration lengthPropertyConfiguration)
		{
			IsFixedLength = lengthPropertyConfiguration.IsFixedLength;
			MaxLength = lengthPropertyConfiguration.MaxLength;
			IsMaxLength = lengthPropertyConfiguration.IsMaxLength;
		}
	}

	public override void FillFrom(PrimitivePropertyConfiguration other, bool inCSpace)
	{
		base.FillFrom(other, inCSpace);
		if (other is LengthPropertyConfiguration lengthPropertyConfiguration)
		{
			if (!IsFixedLength.HasValue)
			{
				IsFixedLength = lengthPropertyConfiguration.IsFixedLength;
			}
			if (!MaxLength.HasValue)
			{
				MaxLength = lengthPropertyConfiguration.MaxLength;
			}
			if (!IsMaxLength.HasValue)
			{
				IsMaxLength = lengthPropertyConfiguration.IsMaxLength;
			}
		}
	}

	public override bool IsCompatible(PrimitivePropertyConfiguration other, bool InCSpace, out string errorMessage)
	{
		LengthPropertyConfiguration lengthPropertyConfiguration = other as LengthPropertyConfiguration;
		bool flag = base.IsCompatible(other, InCSpace, out errorMessage);
		bool flag2 = lengthPropertyConfiguration == null || IsCompatible((LengthPropertyConfiguration c) => c.IsFixedLength, lengthPropertyConfiguration, ref errorMessage);
		bool flag3 = lengthPropertyConfiguration == null || IsCompatible((LengthPropertyConfiguration c) => c.IsMaxLength, lengthPropertyConfiguration, ref errorMessage);
		bool result = lengthPropertyConfiguration == null || IsCompatible((LengthPropertyConfiguration c) => c.MaxLength, lengthPropertyConfiguration, ref errorMessage);
		if (flag && flag2 && flag3)
		{
			return result;
		}
		return false;
	}
}
