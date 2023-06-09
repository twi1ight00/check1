using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.ModelConfiguration.Utilities;
using System.Data.Metadata.Edm;

namespace System.Data.Entity.Migrations.Model;

/// <summary>
/// Represents information about a column.
/// </summary>
public class ColumnModel
{
	private readonly PrimitiveTypeKind _type;

	private readonly Type _clrType;

	private readonly object _clrDefaultValue;

	private TypeUsage _typeUsage;

	private static readonly Dictionary<PrimitiveTypeKind, int> _typeSize = new Dictionary<PrimitiveTypeKind, int>
	{
		{
			PrimitiveTypeKind.Binary,
			int.MaxValue
		},
		{
			PrimitiveTypeKind.Boolean,
			1
		},
		{
			PrimitiveTypeKind.Byte,
			1
		},
		{
			PrimitiveTypeKind.DateTime,
			8
		},
		{
			PrimitiveTypeKind.DateTimeOffset,
			10
		},
		{
			PrimitiveTypeKind.Decimal,
			17
		},
		{
			PrimitiveTypeKind.Double,
			53
		},
		{
			PrimitiveTypeKind.Guid,
			16
		},
		{
			PrimitiveTypeKind.Int16,
			2
		},
		{
			PrimitiveTypeKind.Int32,
			4
		},
		{
			PrimitiveTypeKind.Int64,
			8
		},
		{
			PrimitiveTypeKind.SByte,
			1
		},
		{
			PrimitiveTypeKind.Single,
			4
		},
		{
			PrimitiveTypeKind.String,
			int.MaxValue
		},
		{
			PrimitiveTypeKind.Time,
			5
		}
	};

	/// <summary>
	/// Gets the data type for this column.
	/// </summary>
	public virtual PrimitiveTypeKind Type => _type;

	/// <summary>
	/// Gets the CLR type corresponding to the database type of this column.
	/// </summary>
	public virtual Type ClrType => _clrType;

	/// <summary>
	/// Gets the default value for the CLR type corresponding to the database type of this column.
	/// </summary>
	public virtual object ClrDefaultValue => _clrDefaultValue;

	/// <summary>
	/// Gets additional details about the data type of this column.
	/// This includes details such as maximum length, nullability etc.
	/// </summary>
	public TypeUsage TypeUsage => _typeUsage ?? (_typeUsage = BuildTypeUsage());

	/// <summary>
	/// Gets or sets the name of the column.
	/// </summary>
	public virtual string Name { get; set; }

	/// <summary>
	/// Gets or sets a provider specific data type to use for this column.
	/// </summary>
	public virtual string StoreType { get; set; }

	/// <summary>
	/// Gets or sets a value indicating if this column can store null values.
	/// </summary>
	public virtual bool? IsNullable { get; set; }

	/// <summary>
	/// Gets or sets a value indicating if values for this column will be generated by the database using the identity pattern.
	/// </summary>
	public virtual bool IsIdentity { get; set; }

	/// <summary>
	/// Gets or sets the maximum length for this column.
	/// Only valid for array data types.
	/// </summary>
	public virtual int? MaxLength { get; set; }

	/// <summary>
	/// Gets or sets the precision for this column.
	/// Only valid for decimal data types.
	/// </summary>
	public virtual byte? Precision { get; set; }

	/// <summary>
	/// Gets or sets the scale for this column.
	/// Only valid for decimal data types.
	/// </summary>
	public virtual byte? Scale { get; set; }

	/// <summary>
	/// Gets or sets a constant value to use as the default value for this column.
	/// </summary>
	public virtual object DefaultValue { get; set; }

	/// <summary>
	/// Gets or sets a SQL expression used as the default value for this column.
	/// </summary>
	public virtual string DefaultValueSql { get; set; }

	/// <summary>
	/// Gets or sets a value indicating if this column is fixed length.
	/// Only valid for array data types.
	/// </summary>
	public virtual bool? IsFixedLength { get; set; }

	/// <summary>
	/// Gets or sets a value indicating if this column supports Unicode characters.
	/// Only valid for textual data types.
	/// </summary>
	public virtual bool? IsUnicode { get; set; }

	/// <summary>
	/// Gets or sets a value indicating if this column should be configured as a timestamp.
	/// </summary>
	public virtual bool IsTimestamp { get; set; }

	/// <summary>
	/// Initializes a new instance of the  class.
	/// </summary>
	/// <param name="type">The data type for this column.</param>
	public ColumnModel(PrimitiveTypeKind type)
		: this(type, null)
	{
	}

	/// <summary>
	/// Initializes a new instance of the  class.
	/// </summary>
	/// <param name="type">The data type for this column.</param>
	/// <param name="typeUsage">
	/// Additional details about the data type.
	/// This includes details such as maximum length, nullability etc.
	/// </param>
	public ColumnModel(PrimitiveTypeKind type, TypeUsage typeUsage)
	{
		_type = type;
		_typeUsage = typeUsage;
		_clrType = PrimitiveType.GetEdmPrimitiveType(_type).ClrEquivalentType;
		_clrDefaultValue = (_clrType.IsValueType ? Activator.CreateInstance(_clrType) : ((_clrType == typeof(string)) ? ((object)string.Empty) : ((object)new byte[0])));
	}

	/// <summary>
	/// Determines if this column is a narrower data type than another column.
	/// Used to determine if altering the supplied column definition to this definition will result in data loss.
	/// </summary>
	/// <param name="column">The column to compare to.</param>
	/// <param name="providerManifest">Details of the database provider being used.</param>
	/// <returns>True if this column is of a narrower data type.</returns>
	public bool IsNarrowerThan(ColumnModel column, DbProviderManifest providerManifest)
	{
		RuntimeFailureMethods.Requires(column != null, null, "column != null");
		RuntimeFailureMethods.Requires(providerManifest != null, null, "providerManifest != null");
		TypeUsage storeType = providerManifest.GetStoreType(TypeUsage);
		TypeUsage storeType2 = providerManifest.GetStoreType(column.TypeUsage);
		if (_typeSize[Type] >= _typeSize[column.Type])
		{
			bool? isUnicode = IsUnicode;
			if (!isUnicode.HasValue || isUnicode.GetValueOrDefault() || ((!column.IsUnicode) ?? false))
			{
				bool? isNullable = IsNullable;
				if (!isNullable.HasValue || isNullable.GetValueOrDefault() || ((!column.IsNullable) ?? false))
				{
					return IsNarrowerThan(storeType, storeType2);
				}
			}
		}
		return true;
	}

	private static bool IsNarrowerThan(TypeUsage typeUsage, TypeUsage other)
	{
		string[] array = new string[3] { "MaxLength", "Precision", "Scale" };
		foreach (string identity in array)
		{
			if (typeUsage.Facets.TryGetValue(identity, ignoreCase: true, out var item) && other.Facets.TryGetValue(item.Name, ignoreCase: true, out var item2) && item.Value != item2.Value)
			{
				int num = Convert.ToInt32(item.Value);
				int num2 = Convert.ToInt32(item2.Value);
				if (num < num2)
				{
					return true;
				}
			}
		}
		return false;
	}

	private TypeUsage BuildTypeUsage()
	{
		PrimitiveType edmPrimitiveType = PrimitiveType.GetEdmPrimitiveType(Type);
		if (Type == PrimitiveTypeKind.Binary)
		{
			if (MaxLength.HasValue)
			{
				return TypeUsage.CreateBinaryTypeUsage(edmPrimitiveType, IsFixedLength ?? false, MaxLength.Value);
			}
			return TypeUsage.CreateBinaryTypeUsage(edmPrimitiveType, IsFixedLength ?? false);
		}
		if (Type == PrimitiveTypeKind.String)
		{
			if (MaxLength.HasValue)
			{
				return TypeUsage.CreateStringTypeUsage(edmPrimitiveType, IsUnicode ?? true, IsFixedLength ?? false, MaxLength.Value);
			}
			return TypeUsage.CreateStringTypeUsage(edmPrimitiveType, IsUnicode ?? true, IsFixedLength ?? false);
		}
		if (Type == PrimitiveTypeKind.DateTime)
		{
			return TypeUsage.CreateDateTimeTypeUsage(edmPrimitiveType, Precision);
		}
		if (Type == PrimitiveTypeKind.DateTimeOffset)
		{
			return TypeUsage.CreateDateTimeOffsetTypeUsage(edmPrimitiveType, Precision);
		}
		if (Type == PrimitiveTypeKind.Decimal)
		{
			if (((int?)Precision).HasValue || ((int?)Scale).HasValue)
			{
				return TypeUsage.CreateDecimalTypeUsage(edmPrimitiveType, Precision ?? 18, Scale ?? 0);
			}
			return TypeUsage.CreateDecimalTypeUsage(edmPrimitiveType);
		}
		if (Type != PrimitiveTypeKind.Time)
		{
			return TypeUsage.CreateDefaultTypeUsage(edmPrimitiveType);
		}
		return TypeUsage.CreateTimeTypeUsage(edmPrimitiveType, Precision);
	}
}
