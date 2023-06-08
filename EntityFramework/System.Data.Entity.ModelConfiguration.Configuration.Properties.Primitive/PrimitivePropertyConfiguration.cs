using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.Entity.Edm;
using System.Data.Entity.Edm.Db;
using System.Data.Entity.Edm.Db.Mapping;
using System.Data.Entity.Internal;
using System.Data.Entity.ModelConfiguration.Edm;
using System.Data.Entity.ModelConfiguration.Edm.Common;
using System.Data.Entity.ModelConfiguration.Edm.Db;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Entity.Resources;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;

internal class PrimitivePropertyConfiguration : PropertyConfiguration
{
	public bool? IsNullable { get; set; }

	public EdmConcurrencyMode? ConcurrencyMode { get; set; }

	public DatabaseGeneratedOption? DatabaseGeneratedOption { get; set; }

	public string ColumnType { get; set; }

	public string ColumnName { get; set; }

	public int? ColumnOrder { get; set; }

	public OverridableConfigurationParts OverridableConfigurationParts { get; set; }

	public PrimitivePropertyConfiguration()
	{
		OverridableConfigurationParts = OverridableConfigurationParts.OverridableInCSpace | OverridableConfigurationParts.OverridableInSSpace;
	}

	public PrimitivePropertyConfiguration(PrimitivePropertyConfiguration source)
	{
		IsNullable = source.IsNullable;
		ConcurrencyMode = source.ConcurrencyMode;
		DatabaseGeneratedOption = source.DatabaseGeneratedOption;
		ColumnType = source.ColumnType;
		ColumnName = source.ColumnName;
		ColumnOrder = source.ColumnOrder;
		OverridableConfigurationParts = source.OverridableConfigurationParts;
	}

	internal virtual PrimitivePropertyConfiguration Clone()
	{
		return new PrimitivePropertyConfiguration(this);
	}

	internal virtual void Configure(System.Data.Entity.Edm.EdmProperty property)
	{
		if (property.GetConfiguration() is PrimitivePropertyConfiguration primitivePropertyConfiguration)
		{
			if ((primitivePropertyConfiguration.OverridableConfigurationParts & OverridableConfigurationParts.OverridableInCSpace) != OverridableConfigurationParts.OverridableInCSpace)
			{
				bool inCSpace = true;
				if (!primitivePropertyConfiguration.IsCompatible(this, inCSpace, out var errorMessage))
				{
					PropertyInfo clrPropertyInfo = property.GetClrPropertyInfo();
					string p = ((clrPropertyInfo == null) ? string.Empty : ObjectContextTypeCache.GetObjectType(clrPropertyInfo.DeclaringType).FullName);
					throw Error.ConflictingPropertyConfiguration(property.Name, p, errorMessage);
				}
			}
			PrimitivePropertyConfiguration primitivePropertyConfiguration2;
			if (primitivePropertyConfiguration.GetType().IsAssignableFrom(GetType()))
			{
				primitivePropertyConfiguration2 = (PrimitivePropertyConfiguration)MemberwiseClone();
			}
			else
			{
				primitivePropertyConfiguration2 = (PrimitivePropertyConfiguration)primitivePropertyConfiguration.MemberwiseClone();
				primitivePropertyConfiguration2.CopyFrom(this);
			}
			PrimitivePropertyConfiguration primitivePropertyConfiguration3 = primitivePropertyConfiguration2;
			bool inCSpace2 = true;
			primitivePropertyConfiguration3.FillFrom(primitivePropertyConfiguration, inCSpace2);
			property.SetConfiguration(primitivePropertyConfiguration2);
		}
		else
		{
			property.SetConfiguration(this);
		}
		if (IsNullable.HasValue)
		{
			property.PropertyType.IsNullable = IsNullable;
		}
		if (ConcurrencyMode.HasValue)
		{
			property.ConcurrencyMode = ConcurrencyMode.Value;
		}
		if (DatabaseGeneratedOption.HasValue)
		{
			property.SetStoreGeneratedPattern((DbStoreGeneratedPattern)DatabaseGeneratedOption.Value);
			if (DatabaseGeneratedOption.Value == System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)
			{
				property.PropertyType.IsNullable = false;
			}
		}
	}

	internal virtual void Configure(IEnumerable<Tuple<DbEdmPropertyMapping, DbTableMetadata>> propertyMappings, DbProviderManifest providerManifest, bool allowOverride = false)
	{
		propertyMappings.Each(delegate(Tuple<DbEdmPropertyMapping, DbTableMetadata> pm)
		{
			Configure(pm.Item1.Column, pm.Item2, providerManifest, allowOverride);
		});
	}

	internal virtual void Configure(DbTableColumnMetadata column, DbTableMetadata table, DbProviderManifest providerManifest, bool allowOverride = false)
	{
		if (column.GetConfiguration() is PrimitivePropertyConfiguration primitivePropertyConfiguration)
		{
			bool allowOverride2 = column.GetAllowOverride();
			if ((primitivePropertyConfiguration.OverridableConfigurationParts & OverridableConfigurationParts.OverridableInSSpace) != OverridableConfigurationParts.OverridableInSSpace && !allowOverride2 && !allowOverride)
			{
				bool inCSpace = false;
				if (!primitivePropertyConfiguration.IsCompatible(this, inCSpace, out var errorMessage))
				{
					throw Error.ConflictingColumnConfiguration(column.Name, table.Name, errorMessage);
				}
			}
			bool inCSpace2 = false;
			FillFrom(primitivePropertyConfiguration, inCSpace2);
		}
		ConfigureColumnName(column, table);
		if (!string.IsNullOrWhiteSpace(ColumnType))
		{
			column.TypeName = ColumnType;
		}
		if (ColumnOrder.HasValue)
		{
			column.SetOrder(ColumnOrder.Value);
		}
		(from t in providerManifest.GetStoreTypes()
			where t.Name.Equals(column.TypeName, StringComparison.OrdinalIgnoreCase)
			select t).SingleOrDefault()?.FacetDescriptions.Each(delegate(FacetDescription f)
		{
			Configure(column.Facets, f);
		});
		column.SetConfiguration(this);
		column.SetAllowOverride(allowOverride);
	}

	private void ConfigureColumnName(DbTableColumnMetadata column, DbTableMetadata table)
	{
		if (!string.IsNullOrWhiteSpace(ColumnName) && !string.Equals(ColumnName, column.Name, StringComparison.Ordinal))
		{
			column.Name = ColumnName;
			IEnumerable<DbTableColumnMetadata> ts = from c in table.Columns
				let configuration = c.GetConfiguration() as PrimitivePropertyConfiguration
				where c != column && string.Equals(ColumnName, c.GetPreferredName(), StringComparison.Ordinal) && (configuration == null || configuration.ColumnName == null)
				select c;
			List<DbColumnMetadata> renamedColumns = new List<DbColumnMetadata> { column };
			ts.Each(delegate(DbTableColumnMetadata c)
			{
				c.Name = renamedColumns.UniquifyName(ColumnName);
				renamedColumns.Add(c);
			});
		}
	}

	internal virtual void Configure(DbPrimitiveTypeFacets facets, FacetDescription facetDescription)
	{
	}

	internal virtual void CopyFrom(PrimitivePropertyConfiguration other)
	{
		ColumnName = other.ColumnName;
		ColumnOrder = other.ColumnOrder;
		ColumnType = other.ColumnType;
		ConcurrencyMode = other.ConcurrencyMode;
		DatabaseGeneratedOption = other.DatabaseGeneratedOption;
		IsNullable = other.IsNullable;
		OverridableConfigurationParts = other.OverridableConfigurationParts;
	}

	public virtual void FillFrom(PrimitivePropertyConfiguration other, bool inCSpace)
	{
		if (ColumnName == null && !inCSpace)
		{
			ColumnName = other.ColumnName;
		}
		if (!ColumnOrder.HasValue && !inCSpace)
		{
			ColumnOrder = other.ColumnOrder;
		}
		if (ColumnType == null && !inCSpace)
		{
			ColumnType = other.ColumnType;
		}
		if (!ConcurrencyMode.HasValue)
		{
			ConcurrencyMode = other.ConcurrencyMode;
		}
		if (!DatabaseGeneratedOption.HasValue)
		{
			DatabaseGeneratedOption = other.DatabaseGeneratedOption;
		}
		if (!IsNullable.HasValue)
		{
			IsNullable = other.IsNullable;
		}
		OverridableConfigurationParts &= other.OverridableConfigurationParts;
	}

	public virtual bool IsCompatible(PrimitivePropertyConfiguration other, bool inCSpace, out string errorMessage)
	{
		errorMessage = string.Empty;
		if (other == null)
		{
			return true;
		}
		bool flag = !inCSpace || IsCompatible((PrimitivePropertyConfiguration c) => c.IsNullable, other, ref errorMessage);
		bool flag2 = !inCSpace || IsCompatible((PrimitivePropertyConfiguration c) => c.ConcurrencyMode, other, ref errorMessage);
		bool flag3 = !inCSpace || IsCompatible((PrimitivePropertyConfiguration c) => c.DatabaseGeneratedOption, other, ref errorMessage);
		bool flag4 = inCSpace || IsCompatible((PrimitivePropertyConfiguration c) => c.ColumnName, other, ref errorMessage);
		bool flag5 = inCSpace || IsCompatible((PrimitivePropertyConfiguration c) => c.ColumnOrder, other, ref errorMessage);
		bool result = inCSpace || IsCompatible((PrimitivePropertyConfiguration c) => c.ColumnType, other, ref errorMessage);
		if (flag && flag2 && flag3 && flag4 && flag5)
		{
			return result;
		}
		return false;
	}

	protected bool IsCompatible<T, C>(Expression<Func<C, T?>> propertyExpression, C other, ref string errorMessage) where T : struct where C : PrimitivePropertyConfiguration
	{
		PropertyInfo propertyInfo = propertyExpression.GetSimplePropertyAccess().Single();
		T? val = (T?)propertyInfo.GetValue(this, null);
		T? val2 = (T?)propertyInfo.GetValue(other, null);
		if (IsCompatible(val, val2))
		{
			return true;
		}
		errorMessage = errorMessage + Environment.NewLine + "\t" + Strings.ConflictingConfigurationValue(propertyInfo.Name, val, propertyInfo.Name, val2);
		return false;
	}

	protected bool IsCompatible<C>(Expression<Func<C, string>> propertyExpression, C other, ref string errorMessage) where C : PrimitivePropertyConfiguration
	{
		PropertyInfo propertyInfo = propertyExpression.GetSimplePropertyAccess().Single();
		string text = (string)propertyInfo.GetValue(this, null);
		string text2 = (string)propertyInfo.GetValue(other, null);
		if (IsCompatible(text, text2))
		{
			return true;
		}
		errorMessage = errorMessage + Environment.NewLine + "\t" + Strings.ConflictingConfigurationValue(propertyInfo.Name, text, propertyInfo.Name, text2);
		return false;
	}

	protected bool IsCompatible<T>(T? thisConfiguration, T? other) where T : struct
	{
		if (thisConfiguration.HasValue)
		{
			if (other.HasValue)
			{
				return object.Equals(thisConfiguration.Value, other.Value);
			}
			return true;
		}
		return true;
	}

	protected bool IsCompatible(string thisConfiguration, string other)
	{
		if (thisConfiguration != null)
		{
			if (other != null)
			{
				return object.Equals(thisConfiguration, other);
			}
			return true;
		}
		return true;
	}
}
