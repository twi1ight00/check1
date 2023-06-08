using System;
using System.Collections.Generic;
using Newtonsoft.Json.Utilities;

namespace Newtonsoft.Json.Serialization;

/// <summary>
///   Contract details for a <see cref="T:System.Type" /> used by the <see cref="T:Newtonsoft.Json.JsonSerializer" />.
/// </summary>
public class JsonPrimitiveContract : JsonContract
{
	private static readonly Dictionary<Type, ReadType> ReadTypeMap = new Dictionary<Type, ReadType>
	{
		[typeof(byte[])] = ReadType.ReadAsBytes,
		[typeof(byte)] = ReadType.ReadAsInt32,
		[typeof(short)] = ReadType.ReadAsInt32,
		[typeof(int)] = ReadType.ReadAsInt32,
		[typeof(decimal)] = ReadType.ReadAsDecimal,
		[typeof(bool)] = ReadType.ReadAsBoolean,
		[typeof(string)] = ReadType.ReadAsString,
		[typeof(DateTime)] = ReadType.ReadAsDateTime,
		[typeof(DateTimeOffset)] = ReadType.ReadAsDateTimeOffset,
		[typeof(float)] = ReadType.ReadAsDouble,
		[typeof(double)] = ReadType.ReadAsDouble
	};

	internal PrimitiveTypeCode TypeCode { get; set; }

	/// <summary>
	///   Initializes a new instance of the <see cref="T:Newtonsoft.Json.Serialization.JsonPrimitiveContract" /> class.
	/// </summary>
	/// <param name="underlyingType">The underlying type for the contract.</param>
	public JsonPrimitiveContract(Type underlyingType)
		: base(underlyingType)
	{
		ContractType = JsonContractType.Primitive;
		TypeCode = ConvertUtils.GetTypeCode(underlyingType);
		IsReadOnlyOrFixedSize = true;
		if (ReadTypeMap.TryGetValue(NonNullableUnderlyingType, out var value))
		{
			InternalReadType = value;
		}
	}
}
