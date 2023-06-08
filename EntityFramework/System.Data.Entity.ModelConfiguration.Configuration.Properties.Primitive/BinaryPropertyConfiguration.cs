using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.ModelConfiguration.Utilities;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;

internal class BinaryPropertyConfiguration : LengthPropertyConfiguration
{
	public bool? IsRowVersion { get; set; }

	public BinaryPropertyConfiguration()
	{
	}

	private BinaryPropertyConfiguration(BinaryPropertyConfiguration source)
		: base(source)
	{
		IsRowVersion = source.IsRowVersion;
	}

	internal override PrimitivePropertyConfiguration Clone()
	{
		return new BinaryPropertyConfiguration(this);
	}

	internal override void Configure(EdmProperty property)
	{
		if (IsRowVersion.HasValue)
		{
			base.ColumnType = base.ColumnType ?? "rowversion";
			base.ConcurrencyMode = base.ConcurrencyMode ?? EdmConcurrencyMode.Fixed;
			base.DatabaseGeneratedOption = base.DatabaseGeneratedOption ?? System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Computed;
			base.IsNullable = base.IsNullable ?? false;
			base.MaxLength = base.MaxLength ?? 8;
		}
		base.Configure(property);
	}

	internal override void Configure(IEnumerable<Tuple<DbEdmPropertyMapping, DbTableMetadata>> propertyMappings, DbProviderManifest providerManifest, bool allowOverride = false)
	{
		base.Configure(propertyMappings, providerManifest, allowOverride);
		propertyMappings.Each(delegate(Tuple<DbEdmPropertyMapping, DbTableMetadata> pm)
		{
			if (IsRowVersion.HasValue)
			{
				pm.Item1.Column.Facets.MaxLength = null;
			}
		});
	}

	internal override void CopyFrom(PrimitivePropertyConfiguration other)
	{
		base.CopyFrom(other);
		if (other is BinaryPropertyConfiguration binaryPropertyConfiguration)
		{
			IsRowVersion = binaryPropertyConfiguration.IsRowVersion;
		}
	}

	public override void FillFrom(PrimitivePropertyConfiguration other, bool inCSpace)
	{
		base.FillFrom(other, inCSpace);
		if (other is BinaryPropertyConfiguration binaryPropertyConfiguration && !IsRowVersion.HasValue)
		{
			IsRowVersion = binaryPropertyConfiguration.IsRowVersion;
		}
	}

	public override bool IsCompatible(PrimitivePropertyConfiguration other, bool InCSpace, out string errorMessage)
	{
		BinaryPropertyConfiguration binaryPropertyConfiguration = other as BinaryPropertyConfiguration;
		bool flag = base.IsCompatible(other, InCSpace, out errorMessage);
		bool result = binaryPropertyConfiguration == null || IsCompatible((BinaryPropertyConfiguration c) => c.IsRowVersion, binaryPropertyConfiguration, ref errorMessage);
		if (flag)
		{
			return result;
		}
		return false;
	}
}
