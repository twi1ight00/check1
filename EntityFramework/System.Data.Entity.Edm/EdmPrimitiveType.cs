using System.Collections.Generic;
using System.Data.Entity.Edm.Common;
using System.Data.Entity.Edm.Internal;
using System.Data.Entity.Resources;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace System.Data.Entity.Edm;

/// <summary>
///     Represents one of the fixed set of Entity Data Model (EDM) primitive types.
/// </summary>
internal sealed class EdmPrimitiveType : EdmScalarType
{
	private static readonly EdmPrimitiveType binaryType;

	private static readonly EdmPrimitiveType booleanType;

	private static readonly EdmPrimitiveType byteType;

	private static readonly EdmPrimitiveType dateTimeType;

	private static readonly EdmPrimitiveType dateTimeOffsetType;

	private static readonly EdmPrimitiveType decimalType;

	private static readonly EdmPrimitiveType doubleType;

	private static readonly EdmPrimitiveType guidType;

	private static readonly EdmPrimitiveType int16Type;

	private static readonly EdmPrimitiveType int32Type;

	private static readonly EdmPrimitiveType int64Type;

	private static readonly EdmPrimitiveType sbyteType;

	private static readonly EdmPrimitiveType singleType;

	private static readonly EdmPrimitiveType stringType;

	private static readonly EdmPrimitiveType timeType;

	private static readonly Dictionary<EdmPrimitiveTypeKind, EdmPrimitiveType> typeKindToTypeMap;

	private readonly EdmPrimitiveTypeKind typeKind;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Binary" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Binary => binaryType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Boolean" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Boolean => booleanType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Byte" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Byte => byteType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.DateTime" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType DateTime => dateTimeType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.DateTimeOffset" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType DateTimeOffset => dateTimeOffsetType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Decimal" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Decimal => decimalType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Double" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Double => doubleType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Guid" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Guid => guidType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Int16" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Int16 => int16Type;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Int32" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Int32 => int32Type;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Int64" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Int64 => int64Type;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.SByte" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType SByte => sbyteType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Single" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Single => singleType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.String" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType String => stringType;

	/// <summary>
	///     Gets the EdmPrimitiveType instance that represents the <see cref="F:System.Data.Entity.Edm.EdmPrimitiveTypeKind.Time" /> primitive type.
	/// </summary>
	[SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Used by test code.")]
	public static EdmPrimitiveType Time => timeType;

	/// <summary>
	///     Gets an <see cref="T:System.Data.Entity.Edm.EdmPrimitiveTypeKind" /> value that indicates which Entity Data Model (EDM) primitive type this type represents.
	/// </summary>
	public EdmPrimitiveTypeKind PrimitiveTypeKind => typeKind;

	public override IList<DataModelAnnotation> Annotations
	{
		get
		{
			return new DataModelAnnotation[0];
		}
		set
		{
			throw EdmUtil.NotSupported(Strings.EdmPrimitiveType_SetPropertyNotSupported("Annotations"));
		}
	}

	public override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			throw EdmUtil.NotSupported(Strings.EdmPrimitiveType_SetPropertyNotSupported("Name"));
		}
	}

	static EdmPrimitiveType()
	{
		binaryType = new EdmPrimitiveType(EdmPrimitiveTypeKind.Binary);
		booleanType = new EdmPrimitiveType(EdmPrimitiveTypeKind.Boolean);
		byteType = new EdmPrimitiveType(EdmPrimitiveTypeKind.Byte);
		dateTimeType = new EdmPrimitiveType(EdmPrimitiveTypeKind.DateTime);
		dateTimeOffsetType = new EdmPrimitiveType(EdmPrimitiveTypeKind.DateTimeOffset);
		decimalType = new EdmPrimitiveType(EdmPrimitiveTypeKind.Decimal);
		doubleType = new EdmPrimitiveType(EdmPrimitiveTypeKind.Double);
		guidType = new EdmPrimitiveType(EdmPrimitiveTypeKind.Guid);
		int16Type = new EdmPrimitiveType(EdmPrimitiveTypeKind.Int16);
		int32Type = new EdmPrimitiveType(EdmPrimitiveTypeKind.Int32);
		int64Type = new EdmPrimitiveType(EdmPrimitiveTypeKind.Int64);
		sbyteType = new EdmPrimitiveType(EdmPrimitiveTypeKind.SByte);
		singleType = new EdmPrimitiveType(EdmPrimitiveTypeKind.Single);
		stringType = new EdmPrimitiveType(EdmPrimitiveTypeKind.String);
		timeType = new EdmPrimitiveType(EdmPrimitiveTypeKind.Time);
		typeKindToTypeMap = new Dictionary<EdmPrimitiveTypeKind, EdmPrimitiveType>
		{
			{
				EdmPrimitiveTypeKind.Binary,
				binaryType
			},
			{
				EdmPrimitiveTypeKind.Boolean,
				booleanType
			},
			{
				EdmPrimitiveTypeKind.Byte,
				byteType
			},
			{
				EdmPrimitiveTypeKind.DateTime,
				dateTimeType
			},
			{
				EdmPrimitiveTypeKind.DateTimeOffset,
				dateTimeOffsetType
			},
			{
				EdmPrimitiveTypeKind.Decimal,
				decimalType
			},
			{
				EdmPrimitiveTypeKind.Double,
				doubleType
			},
			{
				EdmPrimitiveTypeKind.Guid,
				guidType
			},
			{
				EdmPrimitiveTypeKind.Int16,
				int16Type
			},
			{
				EdmPrimitiveTypeKind.Int32,
				int32Type
			},
			{
				EdmPrimitiveTypeKind.Int64,
				int64Type
			},
			{
				EdmPrimitiveTypeKind.SByte,
				sbyteType
			},
			{
				EdmPrimitiveTypeKind.Single,
				singleType
			},
			{
				EdmPrimitiveTypeKind.String,
				stringType
			},
			{
				EdmPrimitiveTypeKind.Time,
				timeType
			}
		};
	}

	private EdmPrimitiveType(EdmPrimitiveTypeKind kind)
	{
		typeKind = kind;
		base.Name = kind.ToString();
	}

	/// <summary>
	///     Retrieves the EdmPrimitiveType instance with the <see cref="T:System.Data.Entity.Edm.EdmPrimitiveTypeKind" /> corresponding to the specified <paramref name="primitiveTypeName" /> value, if any.
	/// </summary>
	/// <param name="primitiveTypeName"> The name of the primitive type instance to retrieve </param>
	/// <param name="primitiveType"> The EdmPrimitiveType with the specified name, if successful; otherwise <c>null</c> . </param>
	/// <returns> <c>true</c> if the given name corresponds to an EDM primitive type name; otherwise <c>false</c> . </returns>
	public static bool TryGetByName(string primitiveTypeName, out EdmPrimitiveType primitiveType)
	{
		if (EdmUtil.TryGetPrimitiveTypeKindFromString(primitiveTypeName, out var key))
		{
			return typeKindToTypeMap.TryGetValue(key, out primitiveType);
		}
		primitiveType = null;
		return false;
	}

	internal override EdmItemKind GetItemKind()
	{
		return EdmItemKind.PrimitiveType;
	}

	protected override IEnumerable<EdmMetadataItem> GetChildItems()
	{
		return Enumerable.Empty<EdmMetadataItem>();
	}
}
