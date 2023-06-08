#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Mapping;
using Richfit.Garnet.Common.Properties;
using Richfit.Garnet.Common.Text;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 转换辅助类
/// </summary>
public static class ConvertHelper
{
	/// <summary>
	/// 将当前Base64编码的字符串解码为字节数组
	/// </summary>
	/// <param name="base64">当前Base64编码的字符串</param>
	/// <returns>解码后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Base64编码的字符串为空。</exception>
	public static byte[] Base64Decode(string base64)
	{
		Guard.AssertNotNull(base64, "base64 text");
		return Convert.FromBase64String(base64);
	}

	/// <summary>
	/// 将当前Base64编码的字符串解码，并按指定编码转换为文本
	/// </summary>
	/// <param name="base64">当前Base64编码的字符串</param>
	/// <param name="encoding">转换文本所使用的编码；如果设置为空，则默认为UTF-8编码</param>
	/// <returns>转换后文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前Base64编码的字符串为空。</exception>
	public static string Base64DecodeToText(string base64, Encoding encoding = null)
	{
		Guard.AssertNotNull(base64, "base64 text");
		return ObjectHelper.IfNull(encoding, Encoding.UTF8).GetString(Convert.FromBase64String(base64));
	}

	/// <summary>
	/// 将当前字节数组转换Base64编码的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="options">转换参数</param>
	/// <returns>字节数组的Base64编码字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <seealso cref="M:System.Convert.ToBase64String(System.Byte[])" />
	public static string Base64Encode(byte[] bytes, Base64FormattingOptions options = Base64FormattingOptions.None)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return Convert.ToBase64String(bytes, options);
	}

	/// <summary>
	/// 将当前字节数组转换Base64编码的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <param name="options">转换参数</param>
	/// <returns>字节数组的Base64编码字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数。</exception>
	/// <seealso cref="M:System.Convert.ToBase64String(System.Byte[],System.Int32,System.Int32,System.Base64FormattingOptions)" />
	public static string Base64Encode(byte[] bytes, int start, int count, Base64FormattingOptions options = Base64FormattingOptions.None)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		Guard.AssertBetween(count, 0, bytes.Length - start, "count");
		return Convert.ToBase64String(bytes, start, count, options);
	}

	/// <summary>
	/// 将当前字节序列转换Base64编码的字符串
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="options">转换参数</param>
	/// <returns>字节序列的Base64编码字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	/// <seealso cref="M:System.Convert.ToBase64String(System.Byte[])" />
	public static string Base64Encode(IEnumerable<byte> bytes, Base64FormattingOptions options = Base64FormattingOptions.None)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return Base64Encode(bytes.ToArray(), options);
	}

	/// <summary>
	/// 将当前文本按照指定的文本编码编码为字节数组，并编码为Base64字符串。
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="encoding">转换文本所使用的编码；如果设置为空，则默认为UTF-8编码</param>
	/// <returns>转换后的Base64编码的字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static string Base64Encode(string text, Encoding encoding = null)
	{
		Guard.AssertNotNull(text, "text");
		return Convert.ToBase64String(ObjectHelper.IfNull(encoding, Encoding.UTF8).GetBytes(text));
	}

	/// <summary>
	/// 将当前的数组唯一索引转换为数组各个秩（维数）的索引的数组
	/// </summary>
	/// <param name="index">当前数组索引</param>
	/// <param name="array">进行转换的基础数组</param>
	/// <returns>按数组各个秩（维数）分割的索引数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> 为空。</exception>
	public static int[] ConvertArrayIndexToRankIndex(int index, Array array)
	{
		Guard.AssertGreaterThanOrEqualTo(index, 0, "index");
		Guard.AssertNotNull(array, "array");
		return NumericHelper.RadixParse(index, ArrayHelper.GetWeight(array));
	}

	/// <summary>
	/// 将当前的数组唯一索引转换为数组各个秩（维数）的索引的数组
	/// </summary>
	/// <param name="index">当前数组索引</param>
	/// <param name="array">进行转换的基础数组</param>
	/// <returns>按数组各个秩（维数）分割的索引数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> 为空。</exception>
	public static long[] ConvertArrayIndexToRankIndex(long index, Array array)
	{
		Guard.AssertGreaterThanOrEqualTo(index, 0L, "index");
		Guard.AssertNotNull(array, "array");
		return NumericHelper.RadixParse(index, ArrayHelper.GetLongWeight(array), 1L);
	}

	/// <summary>
	/// 将当前的数组各个秩（维数）的索引的数组转换为数组元素的唯一索引
	/// </summary>
	/// <param name="rankIndex">当前数组维度索引</param>
	/// <param name="array">进行转换的基础数组</param>
	/// <returns>数组唯一索引</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前的索引为空或者为空。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> 为空。</exception>
	public static int ConvertRankIndexToArrayIndex(int[] rankIndex, Array array)
	{
		Guard.AssertNotNullAndEmpty(rankIndex, "rank index");
		Guard.AssertNotNull(array, "array");
		return NumericHelper.RadixSum(rankIndex, ArrayHelper.GetWeight(array));
	}

	/// <summary>
	/// 将当前的数组各个秩（维数）的索引的数组转换为数组元素的唯一索引
	/// </summary>
	/// <param name="rankIndex">当前数组维度索引</param>
	/// <param name="array">进行转换的基础数组</param>
	/// <returns>数组唯一索引</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前的索引为空或者为空。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> 为空。</exception>
	public static long ConvertRankIndexToArrayIndex(long[] rankIndex, Array array)
	{
		Guard.AssertNotNullAndEmpty(rankIndex, "rank index");
		Guard.AssertNotNull(array, "array");
		return NumericHelper.RadixSum(rankIndex, ArrayHelper.GetLongWeight(array), 1L);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <param name="value">当前值</param>
	/// <param name="targetType">转换的目标类型</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.ArgumentNullException">转换的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static object Cast(object value, Type targetType, CultureInfo culture = null)
	{
		return Cast(value, targetType, null, culture);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <param name="value">当前值</param>
	/// <param name="targetType">转换的目标类型</param>
	/// <param name="defaultValue">如果无法将当前值转换为目标类型，则返回该默认值</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.ArgumentNullException">转换的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static object Cast(object value, Type targetType, object defaultValue, CultureInfo culture = null)
	{
		return Cast(value, targetType, (object v, Type t) => defaultValue, culture);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <param name="value">当前值</param>
	/// <param name="targetType">转换的目标类型</param>
	/// <param name="conversion">当前值到目标类型的转换方法</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.ArgumentNullException">转换的目标类型 <paramref name="targetType" /> 为空。</exception>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static object Cast(object value, Type targetType, Func<object, Type, object> conversion, CultureInfo culture = null)
	{
		Guard.AssertNotNull(targetType, "target type");
		culture = ObjectHelper.IfNull(culture, CultureInfo.CurrentCulture);
		if (ObjectHelper.IsNull(value))
		{
			return TypeHelper.CreateDefault(targetType);
		}
		Type valueType = value.GetType();
		if (targetType.IsAssignableFrom(valueType))
		{
			return value;
		}
		if (TypeHelper.IsNullableValueType(valueType))
		{
			return Cast(valueType.GetProperty("Value").GetValue(value, null), targetType);
		}
		if (TypeHelper.IsNullableValueType(targetType))
		{
			return TypeHelper.CreateInstance(targetType, Cast(value, TypeHelper.GetGenericArgument(targetType)));
		}
		if (typeof(IConvertible).IsAssignableFrom(valueType) && typeof(IConvertible).IsAssignableFrom(targetType))
		{
			return Convert.ChangeType(value, targetType, culture);
		}
		TypeConverter typeConverter = TypeDescriptor.GetConverter(targetType);
		if (ObjectHelper.IsNotNull(typeConverter) && !object.ReferenceEquals(typeConverter.GetType(), typeof(TypeConverter)) && typeConverter.CanConvertFrom(valueType))
		{
			return typeConverter.ConvertFrom(null, culture, value);
		}
		typeConverter = TypeDescriptor.GetConverter(valueType);
		if (ObjectHelper.IsNotNull(typeConverter) && !object.ReferenceEquals(typeConverter.GetType(), typeof(TypeConverter)) && typeConverter.CanConvertTo(targetType))
		{
			return typeConverter.ConvertTo(null, culture, value, targetType);
		}
		if (TypeMapper.IsMappable(valueType, targetType))
		{
			return TypeMapper.StaticMap(value, valueType, targetType);
		}
		if (ObjectHelper.IsNotNull(conversion))
		{
			try
			{
				return conversion(value, targetType);
			}
			catch (Exception ex)
			{
				throw new InvalidCastException(TextHelper.FormatValue(Literals.MSG_InvalidCast_2, value, targetType), ex);
			}
		}
		throw new InvalidCastException(TextHelper.FormatValue(Literals.MSG_InvalidCast_2, value, targetType));
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static T Cast<T>(object value, CultureInfo culture = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return default(T);
		}
		return (T)Cast(value, typeof(T), culture);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="defaultValue">如果无法将当前值转换为目标类型，则返回该默认值</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static T Cast<T>(object value, T defaultValue, CultureInfo culture = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return default(T);
		}
		return (T)Cast(value, typeof(T), defaultValue, culture);
	}

	/// <summary>
	/// 将当前值转换为目标类型的值
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="value">当前值</param>
	/// <param name="conversion">当前值到目标类型的转换方法</param>
	/// <param name="culture">转换时使用的区域信息</param>
	/// <returns>转换后的值</returns>
	/// <remarks>如果当前值为空，则返回目标类型的默认值。</remarks>
	public static T Cast<T>(object value, Func<object, Type, object> conversion, CultureInfo culture = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return default(T);
		}
		return (T)Cast(value, typeof(T), conversion, culture);
	}

	/// <summary>
	/// 获取可空类型的值，如果可空类型为空则返回DBNull，否则返回可空类型的值
	/// </summary>
	/// <typeparam name="T">当前可空类型的基础类型</typeparam>
	/// <param name="value">当期可空类型的值</param>
	/// <returns>当前可空类型不为空时，返回可空类型的基础值；为空时返回 <see cref="T:System.DBNull" />。</returns>
	public static object EnsureDBNull<T>(T? value) where T : struct
	{
		return value.HasValue ? ((object)value.Value) : DBNull.Value;
	}

	/// <summary>
	/// 如果当前对象为空则返回DBNull，否则返回对象本身
	/// </summary>
	/// <param name="obj">待检测的值</param>
	/// <returns>如果对象为空则返回DBNull，否则返回对象本身</returns>
	public static object EnsureDBNull(object obj)
	{
		return ObjectHelper.IsNull(obj) ? DBNull.Value : obj;
	}

	/// <summary>
	/// 如果当前对象为空则返回当前对象类型的默认值
	/// </summary>
	/// <param name="obj">当前对象</param>
	/// <param name="type">当前对象类型</param>
	/// <returns>当前对象本身或者对象类型的默认值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象类型 <paramref name="type" /> 为空。</exception>
	public static object EnsureDefault(object obj, Type type)
	{
		Guard.AssertNotNull(type, "type");
		return ObjectHelper.IsNull(obj) ? TypeHelper.CreateDefault(type) : obj;
	}

	/// <summary>
	/// 如果当前对象为空则返回当前对象类型的默认值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="obj">当前对象</param>
	/// <returns>当前对象本身或者对象类型的默认值</returns>
	public static T EnsureDefault<T>(T obj)
	{
		return ObjectHelper.IsNull(obj) ? default(T) : obj;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(BigInteger value)
	{
		return value.ToByteArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetBytes(BigInteger value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, 0, buff, 0, Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(BigInteger[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(BigInteger[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<BigInteger> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((BigInteger x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(bool value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(bool[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(bool[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<bool> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((bool x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前字节的字节数组
	/// </summary>
	/// <param name="b">当前字节</param>
	/// <returns>以当前字节作为元素的字节数组</returns>
	public static byte[] GetBytes(byte b)
	{
		return new byte[1] { b };
	}

	/// <summary>
	/// 获取当前字节数组的指定部分的子数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">子数组的起始索引</param>
	/// <returns>获取的子字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	public static byte[] GetBytes(byte[] bytes, int start)
	{
		Guard.AssertNotNull(bytes, "values");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		return GetBytes(bytes, start, bytes.Length - start);
	}

	/// <summary>
	/// 获取当前字节数组的指定部分的子数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">子数组的起始索引</param>
	/// <param name="count">子数组的元素数量</param>
	/// <returns>获取的子字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(byte[] bytes, int start, int count)
	{
		Guard.AssertNotNull(bytes, "values");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		Guard.AssertBetween(count, 0, bytes.Length - start, "count");
		byte[] buff = new byte[count];
		Array.Copy(bytes, start, buff, 0, count);
		return buff;
	}

	/// <summary>
	/// 获取当前字节序列的指定部分的子数组
	/// </summary>
	/// <param name="bytes">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<byte> bytes)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前字符的位字节数组
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>当前字符的字节数组</returns>
	public static byte[] GetBytes(char c)
	{
		return BitConverter.GetBytes(c);
	}

	/// <summary>
	/// 获取当前字符数组的位字节数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>当前字符数组的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] GetBytes(char[] cs)
	{
		Guard.AssertNotNull(cs, "chars");
		return GetBytes(cs, 0, cs.Length);
	}

	/// <summary>
	/// 获取当前字符数组的位字节数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>当前字符数组的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GetBytes(char[] cs, int start, int count)
	{
		Guard.AssertNotNull(cs, "chars");
		Guard.AssertIndexRange(start, 0, cs.Length - 1, "start");
		Guard.AssertBetween(count, 0, cs.Length - start, "count");
		List<byte> result = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(cs[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前字符序列的位字节数组
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>当前字符序列的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<char> cs)
	{
		Guard.AssertNotNull(cs, "chars");
		return cs.SelectMany((char c) => GetBytes(c)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(DateTime value)
	{
		return GetBytes(value.Ticks);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(DateTime[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(DateTime[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<DateTime> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((DateTime x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(DateTimeOffset value)
	{
		byte[] bytes = new byte[16];
		Array.Copy(GetBytes(value.DateTime), bytes, 8);
		Array.Copy(GetBytes(value.Offset), 0, bytes, 8, 8);
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(DateTimeOffset[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(DateTimeOffset[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 16);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<DateTimeOffset> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((DateTimeOffset x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Decimal" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(decimal value)
	{
		int[] bits = decimal.GetBits(value);
		return bits.SelectMany((int bit) => GetBytes(bit)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Decimal" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(decimal[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Decimal" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(decimal[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 4 * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Decimal" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<decimal> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((decimal x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Double" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(double value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Double" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(double[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Double" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(double[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Double" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<double> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((double x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Guid" /> 型数值的位字节数组
	/// </summary>
	/// <param name="guid">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(Guid guid)
	{
		return guid.ToByteArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Guid" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(Guid[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Guid" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(Guid[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 16);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Guid" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<Guid> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((Guid x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int16" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(short value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int16" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(short[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int16" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(short[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int16" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<short> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((short x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(int value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetBytes(int value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, 0, buff, 0, Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(int[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(int[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<int> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((int x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(long value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetBytes(long value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, 0, buff, 0, Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(long[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(long[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<long> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((long x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值的位字节数组
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(IntPtr p)
	{
		return IntPtr.Size switch
		{
			4 => GetBytes(p.ToInt32()), 
			8 => GetBytes(p.ToInt64()), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 获取当前句柄型数值数组的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(IntPtr[] ps)
	{
		Guard.AssertNotNull(ps, "values");
		return GetBytes(ps, 0, ps.Length);
	}

	/// <summary>
	/// 获取当前句柄型数值数组的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(IntPtr[] ps, int start, int count)
	{
		Guard.AssertNotNull(ps, "values");
		Guard.AssertIndexRange(start, 0, ps.Length - 1, "start");
		Guard.AssertBetween(count, 0, ps.Length - start, "count");
		List<byte> result = new List<byte>(count * IntPtr.Size);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(ps[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值序列的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<IntPtr> ps)
	{
		Guard.AssertNotNull(ps, "values");
		return ps.SelectMany((IntPtr x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.SByte" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(sbyte value)
	{
		return new byte[1] { (byte)value };
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.SByte" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(sbyte[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.SByte" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(sbyte[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.Add((byte)values[i]);
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.SByte" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<sbyte> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Select((sbyte x) => (byte)x).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(float value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(float[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(float[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<float> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((float x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.TimeSpan" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(TimeSpan value)
	{
		return GetBytes(value.Ticks);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.TimeSpan" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(TimeSpan[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.TimeSpan" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(TimeSpan[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.TimeSpan" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<TimeSpan> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((TimeSpan x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt16" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(ushort value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt16" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(ushort[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt16" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(ushort[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt16" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<ushort> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((ushort x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(uint value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetBytes(uint value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, 0, buff, 0, Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(uint[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(uint[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<uint> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((uint x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(ulong value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetBytes(ulong value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, 0, buff, 0, Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(ulong[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(ulong[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(values[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<ulong> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((ulong x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值的位字节数组
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(UIntPtr p)
	{
		return IntPtr.Size switch
		{
			4 => GetBytes(p.ToUInt32()), 
			8 => GetBytes(p.ToUInt64()), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 获取当前句柄型数值数组的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(UIntPtr[] ps)
	{
		Guard.AssertNotNull(ps, "values");
		return GetBytes(ps, 0, ps.Length);
	}

	/// <summary>
	/// 获取当前句柄型数值数组的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(UIntPtr[] ps, int start, int count)
	{
		Guard.AssertNotNull(ps, "values");
		Guard.AssertIndexRange(start, 0, ps.Length - 1, "start");
		Guard.AssertBetween(count, 0, ps.Length - start, "count");
		List<byte> result = new List<byte>(count * UIntPtr.Size);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(ps[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值序列的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(IEnumerable<UIntPtr> ps)
	{
		Guard.AssertNotNull(ps, "values");
		return ps.SelectMany((UIntPtr x) => GetBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前文本区域中字符的位字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本区域中的字符的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] GetBytes(string text)
	{
		Guard.AssertNotNull(text, "text");
		return GetBytes(text, 0, text.Length);
	}

	/// <summary>
	/// 获取当前文本区域中字符的位字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <returns>当前文本区域中的字符的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GetBytes(string text, int start, int count)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		List<byte> result = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetBytes(text[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(BigInteger value)
	{
		byte[] bytes = value.ToByteArray();
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值的 Big-Endian 顺序的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetRawBytes(BigInteger value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetRawBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, bytes.Length - Math.Min(bytes.Length, buff.Length), buff, buff.Length - Math.Min(bytes.Length, buff.Length), Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(BigInteger[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(BigInteger[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Numerics.BigInteger" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<BigInteger> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((BigInteger x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(bool value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(bool[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(bool[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<bool> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((bool x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前字节数组的 Big-Endian 顺序的子字节数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>获取的字节数组</returns>
	public static byte[] GetRawBytes(byte[] bytes)
	{
		Guard.AssertNotNull(bytes, "bytes");
		byte[] buff = new byte[bytes.Length];
		Array.Copy(bytes, buff, buff.Length);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
			return buff;
		}
		return buff;
	}

	/// <summary>
	/// 获取当前字节数组的 Big-Endian 顺序的子字节数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">子数组的起始索引</param>
	/// <returns>获取的字节数组</returns>
	public static byte[] GetRawBytes(byte[] bytes, int start)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		return GetRawBytes(bytes, start, bytes.Length - start);
	}

	/// <summary>
	/// 获取当前字节数组的指定部分的 Big-Endian 顺序的子字节数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">子数组的起始索引</param>
	/// <param name="count">子数组的元素数量</param>
	/// <returns>获取的子字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(byte[] bytes, int start, int count)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		Guard.AssertBetween(count, 0, bytes.Length - start, "count");
		byte[] buff = new byte[count];
		Array.Copy(bytes, start, buff, 0, count);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
			return buff;
		}
		return buff;
	}

	/// <summary>
	/// 获取当前字节数组的指定部分的 Big-Endian 顺序的子字节数组
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>获取子字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<byte> bytes)
	{
		Guard.AssertNotNull(bytes, "bytes");
		if (BitConverter.IsLittleEndian)
		{
			return bytes.Reverse().ToArray();
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前字符的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>当前字符的 Big-Endian 顺序的位字节数组</returns>
	public static byte[] GetRawBytes(char c)
	{
		byte[] bytes = BitConverter.GetBytes(c);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前字符数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>当前字符数组的 Big-Endian 顺序的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	public static byte[] GetRawBytes(char[] cs)
	{
		Guard.AssertNotNull(cs, "chars");
		return GetRawBytes(cs, 0, cs.Length);
	}

	/// <summary>
	/// 获取当前字符数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符的索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>当前字符数组的 Big-Endian 顺序的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符的索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GetRawBytes(char[] cs, int start, int count)
	{
		Guard.AssertNotNull(cs, "chars");
		Guard.AssertIndexRange(start, 0, cs.Length - 1, "start");
		Guard.AssertBetween(count, 0, cs.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(cs[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前字符序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>当前字符序列的 Big-Endian 顺序的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<char> cs)
	{
		Guard.AssertNotNull(cs, "chars");
		return cs.SelectMany((char x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(DateTime value)
	{
		return GetRawBytes(value.Ticks);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(DateTime[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(DateTime[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<DateTime> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((DateTime x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(DateTimeOffset value)
	{
		byte[] bytes = new byte[16];
		Array.Copy(GetRawBytes(value.DateTime), bytes, 8);
		Array.Copy(GetRawBytes(value.Offset), 0, bytes, 8, 8);
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(DateTimeOffset[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(DateTimeOffset[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 16);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<DateTimeOffset> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((DateTimeOffset x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Decimal" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(decimal value)
	{
		int[] bits = decimal.GetBits(value);
		Array.Reverse(bits, 0, 3);
		return bits.SelectMany((int bit) => GetRawBytes(bit)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Decimal" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(decimal[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Decimal" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(decimal[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 4 * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Decimal" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<decimal> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((decimal x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Double" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(double value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Double" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(double[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Double" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(double[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Double" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<double> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((double x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Guid" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(Guid value)
	{
		byte[] bytes = value.ToByteArray();
		Array.Reverse(bytes, 0, 4);
		Array.Reverse(bytes, 4, 2);
		Array.Reverse(bytes, 6, 2);
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Guid" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(Guid[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Guid" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(Guid[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 16);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Guid" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<Guid> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((Guid x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int16" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(short value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int16" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(short[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int16" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(short[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int16" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<short> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((short x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(int value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值的 Big-Endian 顺序的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetRawBytes(int value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetRawBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, bytes.Length - Math.Min(bytes.Length, buff.Length), buff, buff.Length - Math.Min(bytes.Length, buff.Length), Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(int[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(int[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int32" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<int> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((int x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(long value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值的 Big-Endian 顺序的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetRawBytes(long value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetRawBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, bytes.Length - Math.Min(bytes.Length, buff.Length), buff, buff.Length - Math.Min(bytes.Length, buff.Length), Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(long[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(long[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<long> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((long x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(IntPtr p)
	{
		return IntPtr.Size switch
		{
			4 => GetRawBytes(p.ToInt32()), 
			8 => GetRawBytes(p.ToInt64()), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 获取当前句柄型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(IntPtr[] ps)
	{
		Guard.AssertNotNull(ps, "values");
		return GetRawBytes(ps, 0, ps.Length);
	}

	/// <summary>
	/// 获取当前句柄型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <param name="start">开始转换的句柄的索引</param>
	/// <param name="count">转换的句柄数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(IntPtr[] ps, int start, int count)
	{
		Guard.AssertNotNull(ps, "values");
		Guard.AssertIndexRange(start, 0, ps.Length - 1, "start");
		Guard.AssertBetween(count, 0, ps.Length - start, "count");
		List<byte> bytes = new List<byte>(count * IntPtr.Size);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(ps[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<IntPtr> ps)
	{
		Guard.AssertNotNull(ps, "values");
		return ps.SelectMany((IntPtr x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.SByte" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(sbyte value)
	{
		return new byte[1] { (byte)value };
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.SByte" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(sbyte[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.SByte" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(sbyte[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> result = new List<byte>(count);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.Add((byte)values[i]);
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<sbyte> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Select((sbyte x) => (byte)x).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(float value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(float[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(float[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Single" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<float> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((float x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.TimeSpan" /> 型数值 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(TimeSpan value)
	{
		return GetRawBytes(value.Ticks);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.TimeSpan" /> 型数值数组 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(TimeSpan[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.TimeSpan" /> 型数值数组 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(TimeSpan[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.TimeSpan" /> 型数值序列 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<TimeSpan> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((TimeSpan x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt16" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(ushort value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt16" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(ushort[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt16" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(ushort[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt16" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<ushort> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((ushort x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(uint value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值的 Big-Endian 顺序的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetRawBytes(uint value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetRawBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, bytes.Length - Math.Min(bytes.Length, buff.Length), buff, buff.Length - Math.Min(bytes.Length, buff.Length), Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(uint[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(uint[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt32" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<uint> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((uint x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(ulong value)
	{
		byte[] bytes = BitConverter.GetBytes(value);
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(bytes);
			return bytes;
		}
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值的 Big-Endian 顺序的位字节数组；当前数值的位字节数组的长度大于指定的长度则字节低位值开始截断，小于指定的长度则补充0。
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="size">获取的字节数组的长度</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">获取的字节数组长度小于0。</exception>
	public static byte[] GetRawBytes(ulong value, int size)
	{
		Guard.AssertGreaterThanOrEqualTo(size, 0, "size");
		byte[] bytes = GetRawBytes(value);
		byte[] buff = new byte[size];
		Array.Copy(bytes, bytes.Length - Math.Min(bytes.Length, buff.Length), buff, buff.Length - Math.Min(bytes.Length, buff.Length), Math.Min(bytes.Length, buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(ulong[] values)
	{
		Guard.AssertNotNull(values, "values");
		return GetRawBytes(values, 0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(ulong[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(values[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<ulong> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.SelectMany((ulong x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(UIntPtr p)
	{
		return UIntPtr.Size switch
		{
			4 => GetRawBytes(p.ToUInt32()), 
			8 => GetRawBytes(p.ToUInt64()), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 获取当前句柄型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(UIntPtr[] ps)
	{
		Guard.AssertNotNull(ps, "values");
		return GetRawBytes(ps, 0, ps.Length);
	}

	/// <summary>
	/// 获取当前句柄型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <param name="start">开始转换的句柄的索引</param>
	/// <param name="count">转换的句柄数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(UIntPtr[] ps, int start, int count)
	{
		Guard.AssertNotNull(ps, "values");
		Guard.AssertIndexRange(start, 0, ps.Length - 1, "start");
		Guard.AssertBetween(count, 0, ps.Length - start, "count");
		List<byte> bytes = new List<byte>(count * UIntPtr.Size);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(GetRawBytes(ps[i]));
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(IEnumerable<UIntPtr> ps)
	{
		Guard.AssertNotNull(ps, "values");
		return ps.SelectMany((UIntPtr x) => GetRawBytes(x)).ToArray();
	}

	/// <summary>
	/// 获取当前文本区域中字符的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <returns>当前文本区域中的字符的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	public static byte[] GetRawBytes(string text)
	{
		Guard.AssertNotNull(text, "text");
		return GetRawBytes(text, 0, text.Length);
	}

	/// <summary>
	/// 获取当前文本区域中字符的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="text">当前文本</param>
	/// <param name="start">区域的起始位置</param>
	/// <param name="count">区域中的字符数量</param>
	/// <returns>当前文本区域中的字符的位字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前文本为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	public static byte[] GetRawBytes(string text, int start, int count)
	{
		Guard.AssertNotNull(text, "text");
		Guard.AssertIndexRange(start, 0, text.Length - 1, "start");
		Guard.AssertBetween(count, 0, text.Length - start, "count");
		List<byte> result = new List<byte>(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(GetRawBytes(text[i]));
		}
		return result.ToArray();
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Numerics.BigInteger" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	public static BigInteger GetBigInteger(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = bytes;
		if (start > 0)
		{
			buff = new byte[bytes.Length - start];
			Array.Copy(bytes, start, buff, 0, buff.Length);
		}
		return new BigInteger(buff);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Numerics.BigInteger" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	public static BigInteger GetBigInteger(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return new BigInteger(bytes.Skip(start).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Numerics.BigInteger" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	public static BigInteger GetRawBigInteger(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = bytes;
		if (start > 0)
		{
			buff = new byte[bytes.Length - start];
			Array.Copy(bytes, start, buff, 0, buff.Length);
		}
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return new BigInteger(buff);
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Boolean" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToBoolean(System.Byte[],System.Int32)" />
	public static bool GetBoolean(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = bytes;
		if (start > 0)
		{
			buff = new byte[1];
			Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		}
		return BitConverter.ToBoolean(buff, 0);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Boolean" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToBoolean(System.Byte[],System.Int32)" />
	public static bool GetBoolean(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetBoolean(bytes.Skip(start).Take(1).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToBoolean(System.Byte[],System.Int32)" />
	public static bool GetRawBoolean(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[1];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToBoolean(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列转换为 <see cref="T:System.Boolean" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToBoolean(System.Byte[],System.Int32)" />
	public static bool GetRawBoolean(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawBoolean(bytes.Skip(start).Take(1).ToArray());
	}

	/// <summary>
	/// 获取当前字节数组中指定位置的 <see cref="T:System.Byte" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">获取的字节的起始位置</param>
	/// <returns>获取的字节值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>本方法返回当前字节数组中指定索引位置的字节数据。</remarks>
	public static byte GetByte(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		return bytes[start];
	}

	/// <summary>
	/// 获取当前字节序列中指定位置的 <see cref="T:System.Byte" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">获取的字节的起始位置</param>
	/// <returns>获取的字节值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	/// <remarks>本方法返回当前字节序列中指定索引位置的字节数据。</remarks>
	public static byte GetByte(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		IEnumerable<byte> sub = bytes.Skip(start);
		if (sub.Any())
		{
			return sub.First();
		}
		throw new IndexOutOfRangeException(string.Format(Literals.MSG_IndexOutOfRange_1, "start"));
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Char" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Char" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	/// <seealso cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" />
	public static char GetChar(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToChar(buff, 0);
	}

	/// <summary>
	/// 将当前字节序列中指定位置开始的数个字节转换为 <see cref="T:System.Char" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Char" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	/// <seealso cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" />
	public static char GetChar(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetChar(bytes.Skip(start).Take(2).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Char" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" />
	public static char GetRawChar(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToChar(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列转换为 <see cref="T:System.Char" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列元素索引有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToChar(System.Byte[],System.Int32)" />
	public static char GetRawChar(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawChar(bytes.Skip(start).Take(2).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.DateTime" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 将字节数组还原为 <see cref="T:System.Int64" /> 型整数，再调用 <see cref="M:System.DateTime.#ctor(System.Int64)" /> 构造函数转换为 <see cref="T:System.DateTime" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static DateTime GetDateTime(byte[] bytes, int start = 0)
	{
		return new DateTime(GetInt64(bytes, start));
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.DateTime" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 将字节数组还原为 <see cref="T:System.Int64" /> 型整数，再调用 <see cref="M:System.DateTime.#ctor(System.Int64)" /> 构造函数转换为 <see cref="T:System.DateTime" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static DateTime GetDateTime(IEnumerable<byte> bytes, int start = 0)
	{
		return GetDateTime(bytes.Skip(start).Take(8).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.DateTime" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.DateTime.FromBinary(System.Int64)" />
	public static DateTime GetRawDateTime(byte[] bytes, int start = 0)
	{
		return new DateTime(GetRawInt64(bytes, start));
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.DateTime" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.DateTime.FromBinary(System.Int64)" />
	public static DateTime GetRawDateTime(IEnumerable<byte> bytes, int start = 0)
	{
		return GetRawDateTime(bytes.Skip(start).Take(8).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.DateTimeOffset" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	public static DateTimeOffset GetDateTimeOffset(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		DateTime dateTime = GetDateTime(bytes, start);
		TimeSpan offset = TimeSpan.Zero;
		if (bytes.Length > start + 8)
		{
			offset = GetTimeSpan(bytes, start + 8);
		}
		return new DateTimeOffset(dateTime, offset);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.DateTimeOffset" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	public static DateTimeOffset GetDateTimeOffset(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetDateTimeOffset(bytes.Skip(start).Take(16).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.DateTimeOffset" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.DateTime.FromBinary(System.Int64)" />
	/// <seealso cref="M:System.TimeSpan.FromTicks(System.Int64)" />
	public static DateTimeOffset GetRawDateTimeOffset(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		DateTime dateTime = GetRawDateTime(bytes, start);
		TimeSpan offset = TimeSpan.Zero;
		if (bytes.Length > start + 8)
		{
			offset = GetRawTimeSpan(bytes, start + 8);
		}
		return new DateTimeOffset(dateTime, offset);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.DateTimeOffset" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.DateTime.FromBinary(System.Int64)" />
	/// <seealso cref="M:System.TimeSpan.FromTicks(System.Int64)" />
	public static DateTimeOffset GetRawDateTimeOffset(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawDateTimeOffset(bytes.Skip(start).Take(16).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Decimal" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 将字节数组还原为4个 <see cref="T:System.Int32" /> 型整数，再调用 <see cref="M:System.Decimal.#ctor(System.Int32[])" /> 构造函数生成 <see cref="T:System.Decimal" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是4个 <see cref="T:System.Int32" /> 型数据占用字节数量（16）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static decimal GetDecimal(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		int[] bits = new int[4];
		for (int i = 0; i < bits.Length; i++)
		{
			bits[i] = ((bytes.Length > start + 4 * i) ? GetInt32(bytes, start + 4 * i) : 0);
		}
		return new decimal(bits);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Decimal" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 将字节数组还原为4个 <see cref="T:System.Int32" /> 型整数，再调用 <see cref="M:System.Decimal.#ctor(System.Int32[])" /> 构造函数生成 <see cref="T:System.Decimal" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是4个 <see cref="T:System.Int32" /> 型数据占用字节数量（16）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static decimal GetDecimal(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetDecimal(bytes.Skip(start).Take(16).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Decimal" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.Decimal.#ctor(System.Int32[])" />
	public static decimal GetRawDecimal(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		int[] bits = new int[4];
		for (int i = 0; i < bits.Length; i++)
		{
			bits[i] = ((bytes.Length > start + 4 * i) ? GetRawInt32(bytes, start + 4 * i) : 0);
		}
		return new decimal(bits);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Decimal" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.Decimal.#ctor(System.Int32[])" />
	public static decimal GetRawDecimal(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawDecimal(bytes.Skip(start).Take(16).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Double" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToDouble(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Double" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static double GetDouble(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToDouble(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Double" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToDouble(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Double" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static double GetDouble(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetDouble(bytes.Skip(start).Take(8).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Double" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToDouble(System.Byte[],System.Int32)" />
	public static double GetRawDouble(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToDouble(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Double" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToDouble(System.Byte[],System.Int32)" />
	public static double GetRawDouble(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawDouble(bytes.Skip(start).Take(8).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Single" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static float GetFloat(byte[] bytes, int start = 0)
	{
		return GetSingle(bytes, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Single" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static float GetFloat(IEnumerable<byte> bytes, int start = 0)
	{
		return GetSingle(bytes, start);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" />
	public static float GetRawFloat(byte[] bytes, int start = 0)
	{
		return GetRawSingle(bytes, start);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" />
	public static float GetRawFloat(IEnumerable<byte> bytes, int start = 0)
	{
		return GetRawSingle(bytes, start);
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Guid" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.Guid.#ctor(System.Byte[])" /> 构造函数创建 <see cref="T:System.Guid" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Guid" /> 型数据占用字节数量（16）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static Guid GetGuid(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[16];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return new Guid(bytes);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Guid" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.Guid.#ctor(System.Byte[])" /> 构造函数创建 <see cref="T:System.Guid" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Guid" /> 型数据占用字节数量（16）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static Guid GetGuid(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetGuid(bytes.Skip(start).Take(16).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Guid" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.Guid.#ctor(System.Byte[])" />
	public static Guid GetRawGuid(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[16];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return new Guid(buff);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Guid" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.Guid.#ctor(System.Byte[])" />
	public static Guid GetRawGuid(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawGuid(bytes.Skip(start).Take(16).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static short GetInt16(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToInt16(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static short GetInt16(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetInt16(bytes.Skip(start).Take(2).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Int16" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" />
	public static short GetRawInt16(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToInt16(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" />
	public static short GetRawInt16(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawInt16(bytes.Skip(start).Take(2).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int32" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static int GetInt32(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToInt32(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 方法还原当前字节序列。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int32" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static int GetInt32(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetInt32(bytes.Skip(start).Take(4).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Int32" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	public static int GetRawInt32(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToInt32(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Int32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	public static int GetRawInt32(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawInt32(bytes.Skip(start).Take(4).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static long GetInt64(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToInt64(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static long GetInt64(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetInt64(bytes.Skip(start).Take(8).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组转换为 <see cref="T:System.Int64" /> 类型数值
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始转换的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	public static long GetRawInt64(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToInt64(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	public static long GetRawInt64(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawInt64(bytes.Skip(start).Take(8).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.IntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法根据 <see cref="P:System.IntPtr.Size" /> 的指示，分别调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 或者 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />，并将方法结果转换为 <see cref="T:System.IntPtr" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.IntPtr" /> 型数据占用字节数量（4或者8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static IntPtr GetIntPtr(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		return IntPtr.Size switch
		{
			4 => (IntPtr)GetInt32(bytes, start), 
			8 => (IntPtr)GetInt64(bytes, start), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.IntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法根据 <see cref="P:System.IntPtr.Size" /> 的指示，分别调用 <see cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" /> 或者 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />，并将方法结果转换为 <see cref="T:System.IntPtr" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.IntPtr" /> 型数据占用字节数量（4或者8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static IntPtr GetIntPtr(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetIntPtr(bytes.Skip(start).Take(IntPtr.Size).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.IntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	public static IntPtr GetRawIntPtr(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		return IntPtr.Size switch
		{
			4 => (IntPtr)GetRawInt32(bytes, start), 
			8 => (IntPtr)GetRawInt64(bytes, start), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.IntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	public static IntPtr GetRawIntPtr(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawIntPtr(bytes.Skip(start).Take(IntPtr.Size).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static long GetLong(byte[] bytes, int start = 0)
	{
		return GetInt64(bytes, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static long GetLong(IEnumerable<byte> bytes, int start = 0)
	{
		return GetInt64(bytes, start);
	}

	/// <summary>
	/// 从当前字节数组中获取 <see cref="T:System.SByte" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">获取的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>本方法返回当前字节数组中指定索引位置的字节数据。</remarks>
	public static sbyte GetSByte(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		return (sbyte)bytes[start];
	}

	/// <summary>
	/// 从当前字节序列中获取 <see cref="T:System.SByte" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">获取的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>本方法返回当前字节序列中指定索引位置的字节数据。</remarks>
	public static sbyte GetSByte(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		IEnumerable<byte> sub = bytes.Skip(start);
		if (sub.Any())
		{
			return (sbyte)sub.First();
		}
		throw new IndexOutOfRangeException(string.Format(Literals.MSG_IndexOutOfRange_1, "start"));
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static short GetShort(byte[] bytes, int start = 0)
	{
		return GetInt16(bytes, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Int16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static short GetShort(IEnumerable<byte> bytes, int start = 0)
	{
		return GetInt16(bytes, start);
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Single" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static float GetSingle(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToSingle(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Single" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static float GetSingle(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetSingle(bytes.Skip(start).Take(4).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" />
	public static float GetRawSingle(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToSingle(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.Single" /> 数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToSingle(System.Byte[],System.Int32)" />
	public static float GetRawSingle(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawSingle(bytes.Skip(start).Take(4).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.TimeSpan" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 将字节数组还原为 <see cref="T:System.Int64" /> 型整数，再调用 <see cref="M:System.TimeSpan.FromTicks(System.Int64)" /> 方法转换为 <see cref="T:System.TimeSpan" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static TimeSpan GetTimeSpan(byte[] bytes, int start = 0)
	{
		return TimeSpan.FromTicks(GetInt64(bytes, start));
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.TimeSpan" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法先调用 <see cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" /> 将字节序列还原为 <see cref="T:System.Int64" /> 型整数，再调用 <see cref="M:System.TimeSpan.FromTicks(System.Int64)" /> 方法转换为 <see cref="T:System.TimeSpan" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static TimeSpan GetTimeSpan(IEnumerable<byte> bytes, int start = 0)
	{
		return TimeSpan.FromTicks(GetInt64(bytes, start));
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.TimeSpan" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.TimeSpan.FromTicks(System.Int64)" />
	public static TimeSpan GetRawTimeSpan(byte[] bytes, int start = 0)
	{
		return TimeSpan.FromTicks(GetRawInt64(bytes, start));
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.TimeSpan" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToInt64(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.TimeSpan.FromTicks(System.Int64)" />
	public static TimeSpan GetRawTimeSpan(IEnumerable<byte> bytes, int start = 0)
	{
		return TimeSpan.FromTicks(GetRawInt64(bytes, start));
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.UInt16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UInt16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ushort GetUInt16(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToUInt16(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.UInt16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt16(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.Int16" /> 型数据占用字节数量（2）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ushort GetUInt16(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetUInt16(bytes.Skip(start).Take(2).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.UInt16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt16(System.Byte[],System.Int32)" />
	public static ushort GetRawUInt16(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[2];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToUInt16(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.UInt16" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt16(System.Byte[],System.Int32)" />
	public static ushort GetRawUInt16(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawUInt16(bytes.Skip(start).Take(2).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.UInt32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UInt32" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static uint GetUInt32(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToUInt32(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.UInt32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" /> 方法还原当前字节序列。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UInt32" /> 型数据占用字节数量（4）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static uint GetUInt32(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetUInt32(bytes.Skip(start).Take(4).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.UInt32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" />
	public static uint GetRawUInt32(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToUInt32(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.UInt32" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" />
	public static uint GetRawUInt32(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawUInt32(bytes.Skip(start).Take(4).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.UInt64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" /> 方法还原当前字节数组。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UInt64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ulong GetUInt64(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "index");
		byte[] buff = new byte[4];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		return BitConverter.ToUInt64(buff, start);
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.UInt64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" /> 方法还原当前字节序列。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.UInt64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ulong GetUInt64(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetUInt64(bytes.Skip(start).Take(8).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.UInt64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />
	public static ulong GetRawUInt64(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "index");
		byte[] buff = new byte[8];
		Array.Copy(bytes, start, buff, 0, Math.Min(buff.Length, bytes.Length - start));
		if (BitConverter.IsLittleEndian)
		{
			Array.Reverse(buff);
		}
		return BitConverter.ToUInt64(buff, 0);
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.UInt64" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法调用 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" /> 方法还原当前字节序列。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.UInt64" /> 型数据占用字节数量（8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static ulong GetRawUInt64(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawUInt64(bytes.Skip(start).Take(8).ToArray());
	}

	/// <summary>
	/// 将当前字节数组还原为 <see cref="T:System.UIntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <remarks>
	/// 本方法根据 <see cref="P:System.UIntPtr.Size" /> 的指示，分别调用 <see cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" /> 或者 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />，并将方法结果转换为 <see cref="T:System.UIntPtr" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节数组的结束的字节数量应是 <see cref="T:System.UIntPtr" /> 型数据占用字节数量（4或者8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static UIntPtr GetUIntPtr(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "index");
		return UIntPtr.Size switch
		{
			4 => (UIntPtr)GetUInt32(bytes, start), 
			8 => (UIntPtr)GetUInt64(bytes, start), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 将当前字节序列还原为 <see cref="T:System.UIntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <remarks>
	/// 本方法根据 <see cref="P:System.UIntPtr.Size" /> 的指示，分别调用 <see cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" /> 或者 <see cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />，并将方法结果转换为 <see cref="T:System.UIntPtr" /> 型数据。
	/// 从 <paramref name="start" /> 指定的索引位置开始到字节序列的结束的字节数量应是 <see cref="T:System.UIntPtr" /> 型数据占用字节数量（4或者8）的整倍数；如果不是整倍数，则使用0补充为整倍数。
	/// </remarks>
	public static UIntPtr GetUIntPtr(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetUIntPtr(bytes.Skip(start).Take(UIntPtr.Size).ToArray());
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节数组还原为 <see cref="T:System.UIntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出数组索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />
	public static UIntPtr GetRawUIntPtr(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "index");
		return UIntPtr.Size switch
		{
			4 => (UIntPtr)GetRawUInt32(bytes, start), 
			8 => (UIntPtr)GetRawUInt64(bytes, start), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 将当前 Big-Endian 顺序的字节序列还原为 <see cref="T:System.UIntPtr" /> 型数据
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>转换的结果值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空，或者不包含任何元素。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出序列索引的有效范围。</exception>
	/// <seealso cref="M:System.BitConverter.ToUInt32(System.Byte[],System.Int32)" />
	/// <seealso cref="M:System.BitConverter.ToUInt64(System.Byte[],System.Int32)" />
	public static UIntPtr GetRawUIntPtr(IEnumerable<byte> bytes, int start = 0)
	{
		Guard.AssertNotNullAndEmpty(bytes, "bytes");
		Guard.AssertIndexLowBound(start, 0, "start");
		return GetRawUIntPtr(bytes.Skip(start).Take(UIntPtr.Size).ToArray());
	}

	/// <summary>
	/// 将当前十六进制字符串转换为字节数组
	/// </summary>
	/// <param name="hex">当前字节的十六进制字符串</param>
	/// <returns>转换生成的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节的16进制字符串为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前字符串的长度不是2的整倍数；或者包含非十六进制数值字符。</exception>
	public static byte[] HexDecode(string hex)
	{
		Guard.AssertNotNull(hex, "hex text");
		Guard.Assert(hex.Length % 2 == 0, "hex", Literals.MSG_HexStringLengthError);
		List<byte> buff = new List<byte>(hex.Length / 2);
		for (int i = 0; i < hex.Length; i += 2)
		{
			buff.Add((byte)((ParseHex(hex[i]) << 4) + ParseHex(hex[i + 1])));
		}
		return buff.ToArray();
	}

	/// <summary>
	/// 将当前字节编码为字节的十六进制字符串表示
	/// </summary>
	/// <param name="value">当前字节</param>
	/// <param name="upperCase">是否使用大写的字符形式，默认为false。</param>
	/// <returns>字节的字符串表达形式</returns>
	public static string HexEncode(byte value, bool upperCase = false)
	{
		return value.ToString(upperCase ? "X2" : "x2");
	}

	/// <summary>
	/// 将当前字节数组编码为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="upperCase">是否使用大写的字符形式，默认为false。</param>
	/// <returns>当前字节数组的字符串表达形式；如果当前数组不包含元素，则返回空字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string HexEncode(byte[] bytes, bool upperCase = false)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return HexEncode(bytes, 0, bytes.Length, upperCase);
	}

	/// <summary>
	/// 将当前字节数组编码为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">开始编码的字节索引</param>
	/// <param name="count">编码的字节数量</param>
	/// <param name="upperCase">是否使用大写的字符形式，默认为false。</param>
	/// <returns>当前字节数组的字符串表达形式；如果当前数组不包含元素，则返回空字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数据为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出当前字节数据的索引范围</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 开始剩余的字节数量。</exception>
	public static string HexEncode(byte[] bytes, int start, int count, bool upperCase = false)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertIndexRange(start, 0, bytes.Length - 1, "start");
		Guard.AssertBetween(count, 0, bytes.Length - start, "count");
		StringBuilder buff = new StringBuilder(count * 2);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			AppendByteHex(buff, bytes[i], upperCase);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前字节序列编码为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="upperCase">是否使用大写的字符形式，默认为false。</param>
	/// <returns>当前字节序列的字符串表达形式；如果当前序列不包含元素，则返回空字符串。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空。</exception>
	public static string HexEncode(IEnumerable<byte> bytes, bool upperCase = false)
	{
		Guard.AssertNotNull(bytes, "bytes");
		StringBuilder buff = new StringBuilder(1024);
		foreach (byte b in bytes)
		{
			AppendByteHex(buff, b, upperCase);
		}
		return buff.ToString();
	}

	private static StringBuilder AppendByteHex(StringBuilder buff, byte b, bool upperCase)
	{
		int c = (upperCase ? 65 : 97);
		int v = b >> 4;
		buff.Append((char)((v < 10) ? (48 + v) : (c - 10 + v)));
		v = b & 0xF;
		buff.Append((char)((v < 10) ? (48 + v) : (c - 10 + v)));
		return buff;
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Boolean" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static bool ParseBoolean(string s)
	{
		Guard.AssertNotNull(s, "s");
		s = s.Trim();
		if (TextHelper.IsWholeMatch(RegexPatterns.BooleanTrue, s))
		{
			return true;
		}
		if (TextHelper.IsWholeMatch(RegexPatterns.BooleanFalse, s))
		{
			return false;
		}
		return bool.Parse(s);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static byte ParseByte(string s, IFormatProvider provider = null)
	{
		return ParseByte(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static byte ParseByte(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return byte.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Byte" />[] 型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>解析出的字符数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static byte[] ParseByteArray(string s)
	{
		return HexDecode(s);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Char" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <remarks>本方法支持将"0x"、"&amp;h"、"\x"或者"\u"开头的十六进制数值解析为 <see cref="T:System.Char" /> 型数值。</remarks>
	public static char ParseChar(string s)
	{
		Guard.AssertNotNull(s, "s");
		s = RegexPatterns.HexCharPrefix.Replace(s, string.Empty);
		return char.Parse(s);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串表示的区域信息
	/// </summary>
	/// <param name="s">当前区域名称</param>
	/// <param name="alt">区域性名称</param>
	/// <returns>当前区域名称相应的区域性对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前区域名称为空。</exception>
	public static CultureInfo ParseCulture(string s, string alt = null)
	{
		Guard.AssertNotNull(s, "culture name");
		return ObjectHelper.IsNull(alt) ? CultureInfo.GetCultureInfo(s) : CultureInfo.GetCultureInfo(s, alt);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static DateTime ParseDateTime(string s, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTime.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static DateTime ParseDateTime(string s, DateTimeStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTime.Parse(s, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="format" /> 为空。</exception>
	public static DateTime ParseDateTime(string s, string format, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTime.ParseExact(s, format, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符数组</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="formats" /> 为空。</exception>
	public static DateTime ParseDateTime(string s, string[] formats, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTime.ParseExact(s, formats, provider, DateTimeStyles.None);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="format" /> 为空。</exception>
	public static DateTime ParseDateTime(string s, string format, DateTimeStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTime.ParseExact(s, format, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符数组</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="formats" /> 为空。</exception>
	public static DateTime ParseDateTime(string s, string[] formats, DateTimeStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTime.ParseExact(s, formats, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(string s, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTimeOffset.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(string s, DateTimeStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTimeOffset.Parse(s, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="format" /> 为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(string s, string format, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTimeOffset.ParseExact(s, format, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="formats" /> 为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(string s, string[] formats, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTimeOffset.ParseExact(s, formats, provider, DateTimeStyles.None);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="format" /> 为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(string s, string format, DateTimeStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTimeOffset.ParseExact(s, format, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符数组</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者日期格式说明符 <paramref name="formats" /> 为空。</exception>
	public static DateTimeOffset ParseDateTimeOffset(string s, string[] formats, DateTimeStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return DateTimeOffset.ParseExact(s, formats, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static decimal ParseDecimal(string s, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return decimal.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static decimal ParseDecimal(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return decimal.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static double ParseDouble(string s, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return double.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static double ParseDouble(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return double.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的枚举。
	/// </summary>
	/// <param name="s">当前枚举字符串</param>
	/// <param name="enumType">解析的枚举类型</param>
	/// <param name="ignoreCase">是否区分枚举名称的大小写</param>
	/// <returns>解析出的枚举</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者枚举类型 <paramref name="enumType" /> 为空。</exception>
	public static object ParseEnum(string s, Type enumType, bool ignoreCase = false)
	{
		Guard.AssertNotNull(s, "s");
		Guard.AssertNotNull(enumType, "enum type");
		return Enum.Parse(enumType, s, ignoreCase);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的枚举。
	/// </summary>
	/// <typeparam name="T">解析的枚举类型</typeparam>
	/// <param name="s">当前枚举字符串</param>
	/// <param name="ignoreCase">是否区分枚举名称的大小写</param>
	/// <returns>解析出的枚举</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static T ParseEnum<T>(string s, bool ignoreCase = false)
	{
		return (T)ParseEnum(s, typeof(T), ignoreCase);
	}

	/// <summary>
	/// 分析当前字符串所表示的数值；该数值应是用科学计数法表示的。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <returns>将字符串所表示的数值分解为4个部分：符号（1/-1)、整数部分数值、小数部分数值和指数部分数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前字符串不是可识别的科学计数法表达式</exception>
	public static int[] ParseExponential(string s)
	{
		Guard.AssertNotNull(s, "s");
		Match i = RegexPatterns.ExponentialNumber.Match(s);
		Guard.Assert(i.Success && i.Groups.Count == 6, "s");
		return new int[4]
		{
			(!(i.Groups[2].Value == "-")) ? 1 : (-1),
			(i.Groups[3].Value.Length != 0) ? ParseInt32(i.Groups[3].Value) : 0,
			(i.Groups[4].Value.Length != 0) ? ParseInt32(i.Groups[4].Value.TrimEnd('0')) : 0,
			(i.Groups[5].Value.Length != 0) ? ParseInt32(i.Groups[5].Value) : 0
		};
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static float ParseFloat(string s, IFormatProvider provider = null)
	{
		return ParseSingle(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static float ParseFloat(string s, NumberStyles style, IFormatProvider provider = null)
	{
		return ParseSingle(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Guid" /> 类型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="format">Guid字符串的格式</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	/// <remarks>
	/// <paramref name="format" /> 指定待解析的Guid字符串的格式，包括：
	/// N:00000000000000000000000000000000
	/// D:00000000-0000-0000-0000-000000000000
	/// B:{00000000-0000-0000-0000-000000000000}
	/// P:(00000000-0000-0000-0000-000000000000)
	/// X:{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
	/// 如果设置为空，则自动检测Guid字符串格式。
	/// </remarks>
	public static Guid ParseGuid(string s, string format = null)
	{
		Guard.AssertNotNull(s, "s");
		return ObjectHelper.IsNull(format) ? Guid.Parse(s) : Guid.ParseExact(s, format);
	}

	/// <summary>
	/// 获取当前字符所表示的16进制的数值
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>当前字符表示的16进制数值</returns>
	/// <exception cref="T:System.ArgumentException">当前字符不是16进制数值字符。</exception>
	public static int ParseHex(char c)
	{
		if ('A' <= c && c <= 'Z')
		{
			return c - 65 + 10;
		}
		if ('a' <= c && c <= 'z')
		{
			return c - 97 + 10;
		}
		if ('0' <= c && c <= '9')
		{
			return c - 48;
		}
		throw new ArgumentException(string.Format(Literals.MSG_CharNotHexSymbol_1, c));
	}

	/// <summary>
	/// 分析当前字符串，将字符串所表示的十六进制值转换为 <see cref="T:System.Int32" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseHex(string s)
	{
		return ParseInt32(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseInt(string s, IFormatProvider provider = null)
	{
		return ParseInt32(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseInt(string s, NumberStyles style, IFormatProvider provider = null)
	{
		return ParseInt32(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static short ParseInt16(string s, IFormatProvider provider = null)
	{
		return ParseInt16(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static short ParseInt16(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return short.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseInt32(string s, IFormatProvider provider = null)
	{
		return ParseInt32(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static int ParseInt32(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return int.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseInt64(string s, IFormatProvider provider = null)
	{
		return ParseInt64(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseInt64(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return long.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static IntPtr ParseIntPtr(string s, IFormatProvider provider = null)
	{
		return ParseIntPtr(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static IntPtr ParseIntPtr(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return IntPtr.Size switch
		{
			4 => (IntPtr)ParseInt32(s, style, provider), 
			8 => (IntPtr)ParseInt64(s, style, provider), 
			_ => throw new NotSupportedException(string.Format(Literals.MSG_InvalidCast_2, s, typeof(IntPtr).FullName)), 
		};
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseLong(string s, IFormatProvider provider = null)
	{
		return ParseInt64(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseLong(string s, NumberStyles style, IFormatProvider provider = null)
	{
		return ParseInt64(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，将字符串所表示的十六进制值转换为 <see cref="T:System.Int64" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static long ParseLongHex(string s)
	{
		return ParseInt64(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// 获取当前字符所表示的数值
	/// </summary>
	/// <param name="c">当前字符</param>
	/// <returns>该字符表示数值</returns>
	/// <see cref="M:System.Char.GetNumericValue(System.Char)" />
	public static double ParseNumeric(char c)
	{
		return char.GetNumericValue(c);
	}

	/// <summary>
	/// 获取当前字符数组中字符所表示的数值的数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <returns>字符所表示的数值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <seealso cref="M:System.Char.GetNumericValue(System.Char)" />
	public static double[] ParseNumeric(char[] cs)
	{
		Guard.AssertNotNull(cs, "chars");
		return ParseNumeric(cs, 0, cs.Length);
	}

	/// <summary>
	/// 获取当前字符数组中指定范围内的字符所表示的数值的数组
	/// </summary>
	/// <param name="cs">当前字符数组</param>
	/// <param name="start">开始转换的字符索引</param>
	/// <param name="count">转换的字符数量</param>
	/// <returns>字符所表示的数值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的字符索引 <paramref name="start" /> 超出了当前字符数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的字符数量 <paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字符数量。</exception>
	/// <seealso cref="M:System.Char.GetNumericValue(System.Char)" />
	public static double[] ParseNumeric(char[] cs, int start, int count)
	{
		Guard.AssertNotNull(cs, "chars");
		Guard.AssertIndexRange(start, 0, cs.Length - 1, "start");
		Guard.AssertBetween(count, 0, cs.Length - start, "count");
		double[] result = new double[count];
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result[i - start] = ParseNumeric(cs[i]);
		}
		return result;
	}

	/// <summary>
	/// 获取当前字符序列中字符表示的数值的数组
	/// </summary>
	/// <param name="cs">当前字符序列</param>
	/// <returns>字符表示的数值的序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符数组为空。</exception>
	/// <seealso cref="M:System.Char.GetNumericValue(System.Char)" />
	public static IEnumerable<double> ParseNumeric(IEnumerable<char> cs)
	{
		Guard.AssertNotNull(cs, "chars");
		return cs.Select((char c) => ParseNumeric(c));
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static sbyte ParseSByte(string s, IFormatProvider provider = null)
	{
		return ParseSByte(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static sbyte ParseSByte(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return sbyte.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static short ParseShort(string s, IFormatProvider provider = null)
	{
		return ParseInt16(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static short ParseShort(string s, NumberStyles style, IFormatProvider provider = null)
	{
		return ParseInt16(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static float ParseSingle(string s, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return float.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static float ParseSingle(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return float.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static TimeSpan ParseTimeSpan(string s, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return TimeSpan.Parse(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static TimeSpan ParseTimeSpan(string s, TimeSpanStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return TimeSpan.ParseExact(s, "G", provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者时间间隔格式说明符 <paramref name="format" /> 为空。</exception>
	public static TimeSpan ParseTimeSpan(string s, string format, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return TimeSpan.ParseExact(s, format, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者时间间隔格式说明符 <paramref name="formats" /> 为空。</exception>
	public static TimeSpan ParseTimeSpan(string s, string[] formats, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return TimeSpan.ParseExact(s, formats, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者时间间隔格式说明符 <paramref name="format" /> 为空。</exception>
	public static TimeSpan ParseTimeSpan(string s, string format, TimeSpanStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return TimeSpan.ParseExact(s, format, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的时间间隔</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空；或者时间间隔格式说明符 <paramref name="formats" /> 为空。</exception>
	public static TimeSpan ParseTimeSpan(string s, string[] formats, TimeSpanStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return TimeSpan.ParseExact(s, formats, provider, style);
	}

	/// <summary>
	/// 分析当前字符串，将字符串所表示的十六进制值转换为 <see cref="T:System.UInt32" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUHex(string s)
	{
		return ParseUInt32(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUInt(string s, IFormatProvider provider = null)
	{
		return ParseUInt32(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUInt(string s, NumberStyles style, IFormatProvider provider = null)
	{
		return ParseUInt32(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ushort ParseUInt16(string s, IFormatProvider provider = null)
	{
		return ParseUInt16(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ushort ParseUInt16(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return ushort.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUInt32(string s, IFormatProvider provider = null)
	{
		return ParseUInt32(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static uint ParseUInt32(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return uint.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseUInt64(string s, IFormatProvider provider = null)
	{
		return ParseUInt64(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseUInt64(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return ulong.Parse(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static UIntPtr ParseUIntPtr(string s, IFormatProvider provider = null)
	{
		return ParseUIntPtr(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static UIntPtr ParseUIntPtr(string s, NumberStyles style, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(s, "s");
		return UIntPtr.Size switch
		{
			4 => (UIntPtr)ParseUInt32(s, style, provider), 
			8 => (UIntPtr)ParseUInt64(s, style, provider), 
			_ => throw new NotSupportedException(string.Format(Literals.MSG_InvalidCast_2, s, typeof(UIntPtr).FullName)), 
		};
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseULong(string s, IFormatProvider provider = null)
	{
		return ParseUInt64(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseULong(string s, NumberStyles style, IFormatProvider provider = null)
	{
		return ParseUInt64(s, style, provider);
	}

	/// <summary>
	/// 分析当前字符串，将字符串所表示的十六进制值转换为 <see cref="T:System.UInt64" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ulong ParseULongHex(string s)
	{
		return ParseUInt64(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ushort ParseUShort(string s, IFormatProvider provider = null)
	{
		return ParseUInt16(s, provider);
	}

	/// <summary>
	/// 分析当前字符串，返回当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <returns>解析出的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static ushort ParseUShort(string s, NumberStyles style, IFormatProvider provider = null)
	{
		return ParseUInt16(s, style, provider);
	}

	/// <summary>
	/// 把当前布尔值转换为位数组
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <returns>当前值的位数组</returns>
	public static BitArray ToBitArray(bool value)
	{
		return new BitArray(new bool[1] { value });
	}

	/// <summary>
	/// 把当前布尔值数组转换为位数组
	/// </summary>
	/// <param name="values">当前布尔值数组</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前布尔值数组为空。</exception>
	public static BitArray ToBitArray(bool[] values)
	{
		Guard.AssertNotNull(values, "values");
		return new BitArray(values);
	}

	/// <summary>
	/// 把当前布尔值数组转换为位数组
	/// </summary>
	/// <param name="values">当前布尔数组</param>
	/// <param name="start">开始转换的布尔值索引位置</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前布尔数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前布尔数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的值数量。</exception>
	public static BitArray ToBitArray(bool[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		bool[] bytes = new bool[count];
		Array.Copy(values, start, bytes, 0, count);
		return new BitArray(bytes);
	}

	/// <summary>
	/// 把当前布尔值序列转换为位数组
	/// </summary>
	/// <param name="values">当前布尔值序列</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前布尔值序列为空。</exception>
	public static BitArray ToBitArray(IEnumerable<bool> values)
	{
		Guard.AssertNotNull(values, "values");
		return ToBitArray(values.ToArray());
	}

	/// <summary>
	/// 把当前字节值转换为位数组
	/// </summary>
	/// <param name="value">当前字节值</param>
	/// <returns>生成的位数组</returns>
	public static BitArray ToBitArray(byte value)
	{
		return new BitArray(new byte[1] { value });
	}

	/// <summary>
	/// 把当前字节值数组转换为位数组
	/// </summary>
	/// <param name="values">当前字节值数组</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节值数组为空。</exception>
	public static BitArray ToBitArray(byte[] values)
	{
		Guard.AssertNotNull(values, "values");
		return new BitArray(values);
	}

	/// <summary>
	/// 把当前字节值数组转换为位数组
	/// </summary>
	/// <param name="values">当前字节数组</param>
	/// <param name="start">开始转换的字节索引位置</param>
	/// <param name="count">转换的字节数量</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException"><paramref name="start" /> 超出了当前字节数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="count" /> 小于0，或者大于 <paramref name="start" /> 起剩余的字节数量。</exception>
	public static BitArray ToBitArray(byte[] values, int start, int count)
	{
		Guard.AssertNotNull(values, "values");
		Guard.AssertIndexRange(start, 0, values.Length - 1, "start");
		Guard.AssertBetween(count, 0, values.Length - start, "count");
		byte[] bytes = new byte[count];
		Array.Copy(values, start, bytes, 0, count);
		return new BitArray(bytes);
	}

	/// <summary>
	/// 把当前字节值序列转换为位数组
	/// </summary>
	/// <param name="values">当前字节值序列</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节值序列为空。</exception>
	public static BitArray ToBitArray(IEnumerable<byte> values)
	{
		Guard.AssertNotNull(values, "values");
		return ToBitArray(values.ToArray());
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Boolean" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Boolean" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到 <see cref="T:System.Boolean" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 'T'、'Y' 返回true，为 'F'、'N' 返回false；不区分大小写。
	/// 3. 如果当前值为 "true" 返回true，为 "false" 返回false；不区分大小写。
	/// 4. 如果当前值等于日期类型的默认值为false，否则返回true；
	/// 5. 否则调用 <see cref="M:System.Convert.ToBoolean(System.Object,System.IFormatProvider)" /> 方法。
	/// </remarks>
	public static bool ToBoolean(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return false;
		}
		try
		{
			switch (value.GetTypeCode())
			{
			case TypeCode.Boolean:
				return (bool)(object)value;
			case TypeCode.Char:
			{
				char c = (char)(object)value;
				if (c == 'T' || c == 't' || c == 'Y' || c == 'y')
				{
					return true;
				}
				if (c == 'F' || c == 'f' || c == 'N' || c == 'n')
				{
					return false;
				}
				break;
			}
			case TypeCode.String:
			{
				string s = (string)value;
				if (TextHelper.EqualOrdinal(s, "true", ignoreCase: true))
				{
					return true;
				}
				if (TextHelper.EqualOrdinal(s, "false", ignoreCase: true))
				{
					return false;
				}
				break;
			}
			case TypeCode.DateTime:
				return ObjectHelper.IsNotDefault(value, typeof(DateTime));
			default:
				return Convert.ToBoolean(value, provider);
			}
			throw new NotSupportedException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(bool).FullName));
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(bool).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static bool ToBoolean(IntPtr p)
	{
		return p != IntPtr.Zero;
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static bool ToBoolean(UIntPtr p)
	{
		return p != UIntPtr.Zero;
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Byte" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Byte" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的数值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToByte(System.Object,System.IFormatProvider)" /> 方法。
	/// </remarks>
	public static byte ToByte(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.Byte => (byte)(object)value, 
				TypeCode.DateTime => Convert.ToByte(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToByte(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(byte).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Byte" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static byte ToByte(IntPtr p)
	{
		return ObjectHelper.As<byte>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Byte" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static byte ToByte(UIntPtr p)
	{
		return ObjectHelper.As<byte>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Char" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Char" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 true 则返回 'T'，如果为 false 则返回 'F'。
	/// 3. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的数值对应的字符。
	/// 4. 如果当前值为数值类型，则返回其数值对应的字符。
	/// 5. 否则调用 <see cref="M:System.Convert.ToChar(System.Object,System.IFormatProvider)" /> 方法。
	/// </remarks>
	public static char ToChar(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return '\0';
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.Char => (char)(object)value, 
				TypeCode.Boolean => ((bool)(object)value) ? 'T' : 'F', 
				TypeCode.Single => Convert.ToChar(Convert.ToUInt16(value, provider), provider), 
				TypeCode.Double => Convert.ToChar(Convert.ToUInt16(value, provider), provider), 
				TypeCode.Decimal => Convert.ToChar(Convert.ToUInt16(value, provider), provider), 
				TypeCode.DateTime => Convert.ToChar(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToChar(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(char).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Char" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static char ToChar(IntPtr p)
	{
		return ObjectHelper.As<char>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Char" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static char ToChar(UIntPtr p)
	{
		return ObjectHelper.As<char>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Collections.IComparer" /> 类型比较器转换为 <see cref="T:System.Collections.Generic.IComparer`1" /> 类型比较器
	/// </summary>
	/// <param name="comparer">当前比较器</param>
	/// <returns>转换后的泛型比较器</returns>
	/// <exception cref="T:System.ArgumentNullException">当前比较器为空。</exception>
	public static IComparer<object> ToComparer(IComparer comparer)
	{
		Guard.EnsureNotNull(comparer, "comparer");
		return new CustomComparer<object>((Comparison<object>)comparer.Compare);
	}

	/// <summary>
	/// 将相等比较方法转化为相等比较对象
	/// </summary>
	/// <param name="equalition">当前相等比较方法</param>
	/// <returns>使用指定当前比较方法的比较对象</returns>
	/// <remarks>如果当前相等比较方法为空，则使用 <see cref="M:System.Object.Equals(System.Object)" /> 检测对象的相等性。</remarks>
	public static IEqualityComparer ToComparer(Func<object, object, bool> equalition)
	{
		equalition = ObjectHelper.IfNull(equalition, ObjectHelper.ObjectEquals);
		return new CustomEqualityComparer(equalition);
	}

	/// <summary>
	/// 将相等比较方法转化为相等比较对象
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="equalition">当前相等比较方法</param>
	/// <returns>使用当前相等比较方法的比较对象；如果当前相等比较方法为空，返回 <see cref="P:System.Collections.Generic.EqualityComparer`1.Default" />。</returns>
	public static IEqualityComparer<T> ToComparer<T>(Func<T, T, bool> equalition)
	{
		object result;
		if (!ObjectHelper.IsNull(equalition))
		{
			IEqualityComparer<T> equalityComparer = new CustomEqualityComparer<T>(equalition);
			result = equalityComparer;
		}
		else
		{
			result = EqualityComparer<T>.Default;
		}
		return (IEqualityComparer<T>)result;
	}

	/// <summary>
	/// 将大小比较方法转化为大小比较对象
	/// </summary>
	/// <param name="comparison">当前大小比较方法</param>
	/// <returns>使用当前大小比较方法的比较对象；如果当前相等比较方法为空，返回 <see cref="F:System.Collections.Comparer.Default" />。</returns>
	public static IComparer ToComparer(Func<object, object, int> comparison)
	{
		object result;
		if (!ObjectHelper.IsNull(comparison))
		{
			IComparer comparer = new CustomComparer(comparison);
			result = comparer;
		}
		else
		{
			result = Comparer.Default;
		}
		return (IComparer)result;
	}

	/// <summary>
	/// 将大小比较方法转化为大小比较对象
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="comparison">当前大小比较方法</param>
	/// <returns>使用当前大小比较方法的比较对象；如果当前相等比较方法为空，返回 <see cref="P:System.Collections.Generic.Comparer`1.Default" />。</returns>
	public static IComparer<T> ToComparer<T>(Func<T, T, int> comparison)
	{
		object result;
		if (!ObjectHelper.IsNull(comparison))
		{
			IComparer<T> comparer = new CustomComparer<T>(comparison);
			result = comparer;
		}
		else
		{
			result = Comparer<T>.Default;
		}
		return (IComparer<T>)result;
	}

	/// <summary>
	/// 将大小比较方法转化为大小比较对象
	/// </summary>
	/// <typeparam name="T">比较的对象类型</typeparam>
	/// <param name="comparison">当前大小比较方法</param>
	/// <returns>使用当前大小比较方法的比较对象；如果当前相等比较方法为空，返回 <see cref="P:System.Collections.Generic.Comparer`1.Default" />。</returns>
	public static IComparer<T> ToComparer<T>(Comparison<T> comparison)
	{
		object result;
		if (!ObjectHelper.IsNull(comparison))
		{
			IComparer<T> comparer = new CustomComparer<T>(comparison);
			result = comparer;
		}
		else
		{
			result = Comparer<T>.Default;
		}
		return (IComparer<T>)result;
	}

	/// <summary>
	/// 将当前区域名称转换为所表示的区域信息对象
	/// </summary>
	/// <param name="name">当前区域名称</param>
	/// <param name="alt">区域性名称</param>
	/// <returns>当前区域名称相应的区域性对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前区域名称为空。</exception>
	public static CultureInfo ToCultureInfo(string name, string alt = null)
	{
		Guard.AssertNotNull(name, "culture name");
		return ObjectHelper.IsNull(alt) ? CultureInfo.GetCultureInfo(name) : CultureInfo.GetCultureInfo(name, alt);
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.DateTime" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.DateTime" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到 <see cref="T:System.DateTime" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.String" /> 类型，则调用 <see cref="M:System.DateTime.Parse(System.String,System.IFormatProvider)" /> 方法。
	/// 3. 如果当前值为数值类型，则调用 <see cref="M:System.DateTime.#ctor(System.Int64)" />。
	/// </remarks>
	public static DateTime ToDateTime(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return default(DateTime);
		}
		try
		{
			switch (value.GetTypeCode())
			{
			case TypeCode.DateTime:
				return (DateTime)(object)value;
			case TypeCode.String:
				return DateTime.Parse((string)value, provider);
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return new DateTime(Convert.ToInt64(value, provider));
			default:
				throw new NotSupportedException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(DateTime).FullName));
			}
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(DateTime).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Decimal" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Decimal" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToDecimal(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static decimal ToDecimal(IConvertible value, IFormatProvider provider = null)
	{
		if (!ObjectHelper.IsNull(value))
		{
			try
			{
				return value.GetTypeCode() switch
				{
					TypeCode.Decimal => (decimal)(object)value, 
					TypeCode.Char => Convert.ToDecimal(Convert.ToUInt16(value, provider), provider), 
					TypeCode.DateTime => Convert.ToDecimal(((DateTime)(object)value).Ticks, provider), 
					_ => Convert.ToDecimal(value, provider), 
				};
			}
			catch (Exception ex)
			{
				throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(decimal).FullName), ex);
			}
		}
		return 0m;
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Decimal" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static decimal ToDecimal(IntPtr p)
	{
		return ObjectHelper.As<decimal>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Decimal" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static decimal ToDecimal(UIntPtr p)
	{
		return ObjectHelper.As<decimal>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前目录路径转换为目录信息对象
	/// </summary>
	/// <param name="directory">当前目录路径</param>
	/// <returns>当前目录的目录信息对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录路径为空。</exception>
	/// <remarks>本方法获取当前目录路径表示目录信息对象</remarks>
	public static DirectoryInfo ToDirecotryInfo(string directory)
	{
		Guard.AssertNotNull(directory, "directory");
		return new DirectoryInfo(directory);
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Double" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Double" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToDouble(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static double ToDouble(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0.0;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.Double => (double)(object)value, 
				TypeCode.Char => Convert.ToDouble(Convert.ToUInt16(value, provider), provider), 
				TypeCode.DateTime => Convert.ToDouble(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToDouble(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(double).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Double" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static double ToDouble(IntPtr p)
	{
		return ObjectHelper.As<double>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Double" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static double ToDouble(UIntPtr p)
	{
		return ObjectHelper.As<double>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前值转换为 <paramref name="type" /> 指定的枚举类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="type">目标枚举类型</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="type" /> 不是枚举类型。</exception>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <paramref name="type" /> 指定的枚举类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为数值类型，则将该数值转换为对应的枚举。
	/// 3. 否则将当前值的字符串表示转换为对应的枚举值。
	/// </remarks>
	public static object ToEnum(IConvertible value, Type type, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(type, "type");
		Guard.Assert(type.IsEnum, () => new NotSupportedException(string.Format(Literals.MSG_TypeNotEnum_1, type.FullName)));
		if (ObjectHelper.IsNull(value))
		{
			return Enum.ToObject(type, 0);
		}
		try
		{
			Type valueType = value.GetType();
			if (TypeHelper.IsNumeric(valueType) || valueType == typeof(bool))
			{
				return Enum.ToObject(type, Convert.ToInt64(value, provider));
			}
			return Enum.Parse(type, value.ToString(), ignoreCase: true);
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), type.FullName), ex);
		}
	}

	/// <summary>
	/// 将当前值转换为 <typeparamref name="T" /> 指定的枚举类型
	/// </summary>
	/// <typeparam name="T">枚举类型</typeparam>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <typeparamref name="T" /> 指定的枚举类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为数值类型，则将该数值转换为对应的枚举。
	/// 3. 否则将当前值的字符串表示转换为对应的枚举值。
	/// </remarks>
	public static T ToEnum<T>(IConvertible value, IFormatProvider provider = null) where T : struct
	{
		return (T)ToEnum(value, typeof(T), provider);
	}

	/// <summary>
	/// 将当前句柄转换为指定类型的枚举
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="type">枚举类型</param>
	/// <returns>数值对应的枚举</returns>
	public static object ToEnum(IntPtr p, Type type)
	{
		return ToEnum(p.ToInt64(), type);
	}

	/// <summary>
	/// 将当前句柄转换为指定类型的枚举
	/// </summary>
	/// <typeparam name="T">枚举类型</typeparam>
	/// <param name="p">当前句柄</param>
	/// <returns>数值对应的枚举</returns>
	public static T ToEnum<T>(IntPtr p) where T : struct
	{
		return ToEnum<T>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为指定类型的枚举
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="type">枚举类型</param>
	/// <returns>数值对应的枚举</returns>
	public static object ToEnum(UIntPtr p, Type type)
	{
		return ToEnum(p.ToUInt64(), type);
	}

	/// <summary>
	/// 将当前句柄转换为指定类型的枚举
	/// </summary>
	/// <typeparam name="T">枚举类型</typeparam>
	/// <param name="p">当前句柄</param>
	/// <returns>数值对应的枚举</returns>
	public static T ToEnum<T>(UIntPtr p) where T : struct
	{
		return ToEnum<T>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前文件路径转换为所指示的文件对象，不检测文件是否实际存在是否存在
	/// </summary>
	/// <param name="file">当前文件路径</param>
	/// <returns>当前文件路径指示的文件对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前目录路径为空。</exception>
	/// <exception cref="T:System.ArgumentException">当前目录路径无效。</exception>
	public static FileInfo ToFileInfo(string file)
	{
		Guard.AssertNotNull(file, "file");
		return new FileInfo(file);
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Single" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Single" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToSingle(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	/// <seealso cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToSingle(System.IConvertible,System.IFormatProvider)" />
	public static float ToFloat(IConvertible value, IFormatProvider provider = null)
	{
		return ToSingle(value, provider);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Numerics.BigInteger" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(BigInteger value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Numerics.BigInteger" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(BigInteger value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Boolean" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(bool value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Boolean" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(bool value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的小写的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <returns>字节数组的小写十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(byte[] bytes)
	{
		return ToHex(bytes, bytePrefix: false, upperCase: false);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(byte[] bytes, bool upperCase)
	{
		return ToHex(bytes, bytePrefix: false, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="bytePrefix">是否每个字节前都添加前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(byte[] bytes, bool bytePrefix, bool upperCase)
	{
		return ToHex(bytes, upperCase ? "0X" : "0x", bytePrefix, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="bytePrefix">是否每个字节前都添加前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(IEnumerable<byte> bytes, bool bytePrefix, bool upperCase)
	{
		return ToHex(bytes, upperCase ? "0X" : "0x", bytePrefix, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="prefix">十六进制字符串前缀</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(byte[] bytes, string prefix)
	{
		return ToHex(bytes, prefix, bytePrefix: false, upperCase: false);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="prefix">十六进制字符串前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(byte[] bytes, string prefix, bool upperCase)
	{
		return ToHex(bytes, prefix, bytePrefix: false, upperCase);
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="prefix">十六进制字符串前缀</param>
	/// <param name="bytePrefix">是否每个字节前都添加前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(byte[] bytes, string prefix, bool bytePrefix, bool upperCase)
	{
		Guard.AssertNotNull(bytes, "bytes");
		prefix = ObjectHelper.IfNull(prefix, string.Empty);
		StringBuilder buff = new StringBuilder(bytes.Length * (bytePrefix ? (2 + prefix.Length) : 2) + ((!bytePrefix) ? prefix.Length : 0));
		for (int i = 0; i < bytes.Length; i++)
		{
			if (bytePrefix || i == 0)
			{
				buff.Append(prefix);
			}
			AppendByteHex(buff, bytes[i], upperCase);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前字节数组转换为字节的十六进制字符串表示，十六进制字符串具有"0x"的前缀
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="prefix">十六进制字符串前缀</param>
	/// <param name="bytePrefix">是否每个字节前都添加前缀</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static string ToHex(IEnumerable<byte> bytes, string prefix, bool bytePrefix, bool upperCase)
	{
		Guard.AssertNotNull(bytes, "bytes");
		prefix = ObjectHelper.IfNull(prefix, string.Empty);
		StringBuilder buff = new StringBuilder(1024);
		bool firstByte = true;
		foreach (byte b in bytes)
		{
			if (firstByte || bytePrefix)
			{
				buff.Append(prefix);
				firstByte = false;
			}
			AppendByteHex(buff, b, upperCase);
		}
		return buff.ToString();
	}

	/// <summary>
	/// 将当前字节数组中转换为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="groupSize">字节分组的元素个数</param>
	/// <param name="groupFormat">字节分组格式化字符串</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节数组的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空；或者字节分组格式化字符串 <paramref name="groupFormat" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字节分组元素个数 <paramref name="groupSize" /> 小于0。</exception>
	public static string ToHex(byte[] bytes, int groupSize, string groupFormat, bool upperCase = false)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return ToHex(bytes.AsEnumerable(), groupSize, groupFormat, upperCase);
	}

	/// <summary>
	/// 将当前字节序列中转换为字节的十六进制字符串表示
	/// </summary>
	/// <param name="bytes">当前字节序列</param>
	/// <param name="groupSize">字节分组的元素个数</param>
	/// <param name="groupFormat">字节分组格式化字符串</param>
	/// <param name="upperCase">十六进制字符串是否使用大写形式</param>
	/// <returns>字节序列的十六进制字符串表示</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节序列为空；或者字节分组格式化字符串 <paramref name="groupFormat" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字节分组元素个数 <paramref name="groupSize" /> 小于0。</exception>
	public static string ToHex(IEnumerable<byte> bytes, int groupSize, string groupFormat, bool upperCase = false)
	{
		Guard.AssertNotNull(bytes, "bytes");
		Guard.AssertGreaterThanOrEqualTo(groupSize, 0, "group size");
		Guard.AssertNotNull(groupFormat, "group format");
		StringBuilder buff = new StringBuilder(1024);
		StringBuilder groupBuff = new StringBuilder(16);
		int groupCount = 0;
		foreach (byte b in bytes)
		{
			if (groupCount >= groupSize)
			{
				buff.Append(string.Format(groupFormat, groupBuff.ToString()));
				groupBuff.Clear();
				groupCount = 0;
			}
			AppendByteHex(buff, b, upperCase);
			groupCount++;
		}
		buff.Append(string.Format(groupFormat, groupBuff.ToString()));
		return buff.ToString();
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Char" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(char value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Char" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(char value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.DateTime" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(DateTime value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.DateTime" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(DateTime value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.DateTimeOffset" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(DateTimeOffset value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.DateTimeOffset" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(DateTimeOffset value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Decimal" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(decimal value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Decimal" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(decimal value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Double" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(double value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Double" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(double value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Guid" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(Guid value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Guid" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(Guid value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Int16" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(short value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Int16" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(short value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Int32" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(int value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Int32" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(int value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Int64" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(long value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Int64" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(long value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前句柄转换为十六进制字符串形式
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前句柄的十六进制字符串形式</returns>
	public static string ToHex(IntPtr p, bool upperCase = false)
	{
		return ToHex(GetRawBytes(p), upperCase);
	}

	/// <summary>
	/// 将当前句柄转换为十六进制字符串形式
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前句柄的十六进制字符串形式</returns>
	public static string ToHex(IntPtr p, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(p), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Single" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(sbyte value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Single" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(sbyte value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Single" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(float value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Single" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(float value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.TimeSpan" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(TimeSpan value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt16" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(TimeSpan value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt16" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(ushort value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt16" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(ushort value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt32" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(uint value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt32" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(uint value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt64" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(ulong value, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt64" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(ulong value, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(value), prefix, upperCase);
	}

	/// <summary>
	/// 将当前句柄转换为十六进制字符串形式
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前句柄的十六进制字符串形式</returns>
	public static string ToHex(UIntPtr p, bool upperCase = false)
	{
		return ToHex(GetRawBytes(p), upperCase);
	}

	/// <summary>
	/// 将当前句柄转换为十六进制字符串形式
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前句柄的十六进制字符串形式</returns>
	public static string ToHex(UIntPtr p, string prefix, bool upperCase = false)
	{
		return ToHex(GetRawBytes(p), prefix, upperCase);
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Int16" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Int16" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToInt16(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static short ToInt16(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.Int16 => (short)(object)value, 
				TypeCode.DateTime => Convert.ToInt16(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToInt16(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(short).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int16" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static short ToInt16(IntPtr p)
	{
		return ObjectHelper.As<short>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int16" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static short ToInt16(UIntPtr p)
	{
		return ObjectHelper.As<short>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Int32" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Int32" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToInt32(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static int ToInt32(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.Int32 => (int)(object)value, 
				TypeCode.DateTime => Convert.ToInt32(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToInt32(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(int).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前位值数组转换为 <see cref="T:System.Int32" /> 类型数值
	/// </summary>
	/// <param name="bits">当前位值数组</param>
	/// <returns>转换后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前位值数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前位值数组的长度超过目标类型的位数。</exception>
	public static int ToInt32(BitArray bits)
	{
		Guard.AssertNotNull(bits, "bits");
		Guard.AssertBetween(bits.Count, 0, 32, "bits");
		int value = 0;
		for (int i = 0; i < bits.Count; i++)
		{
			if (bits[i])
			{
				value += 1 << i;
			}
		}
		return value;
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int32" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static int ToInt32(IntPtr p)
	{
		return p.ToInt32();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int32" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static int ToInt32(UIntPtr p)
	{
		return ObjectHelper.As<int>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Int64" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Int64" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToInt64(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static long ToInt64(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0L;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.Int64 => (long)(object)value, 
				TypeCode.DateTime => Convert.ToInt64(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToInt64(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(long).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前位值数组转换为 <see cref="T:System.Int64" /> 类型数值
	/// </summary>
	/// <param name="bits">当前位值数组</param>
	/// <returns>转换后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前位值数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前位值数组的长度超过目标类型的位数。</exception>
	public static long ToInt64(BitArray bits)
	{
		Guard.AssertNotNull(bits, "bits");
		Guard.AssertBetween(bits.Count, 0, 64, "bits");
		long value = 0L;
		for (int i = 0; i < bits.Count; i++)
		{
			if (bits[i])
			{
				value += 1L << i;
			}
		}
		return value;
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int64" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static long ToInt64(IntPtr p)
	{
		return p.ToInt64();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int64" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static long ToInt64(UIntPtr p)
	{
		return ObjectHelper.As<long>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.IntPtr" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.IntPtr" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到 <see cref="T:System.IntPtr" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 根据 <see cref="P:System.IntPtr.Size" /> 属性值的不同，调用 <see cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToInt32(System.IConvertible,System.IFormatProvider)" /> 或者 <see cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToInt64(System.IConvertible,System.IFormatProvider)" /> 转换当前值。
	/// </remarks>
	public static IntPtr ToIntPtr(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return default(IntPtr);
		}
		try
		{
			return IntPtr.Size switch
			{
				4 => (IntPtr)value.ToInt32(provider), 
				8 => (IntPtr)value.ToInt64(provider), 
				_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(IntPtr).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.IntPtr" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static IntPtr ToIntPtr(IntPtr p)
	{
		return new IntPtr(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.IntPtr" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static IntPtr ToIntPtr(UIntPtr p)
	{
		return new IntPtr(ToInt64(p));
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Guid" /> 型数值转换为Oracle存储的十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToOracleHex(Guid value)
	{
		return ToHex(GetBytes(value), string.Empty, upperCase: true);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Guid" /> 型数值转换为Oracle存储的十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToOracleHex(Guid value, string prefix)
	{
		return ToHex(GetBytes(value), prefix, upperCase: true);
	}

	/// <summary>
	/// 将当前正则模式字符串转换为正则表达式对象
	/// </summary>
	/// <param name="pattern">当前正则模式字符串</param>
	/// <param name="options">正则表达式选项</param>
	/// <returns>正则表达式字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式字符串为空。</exception>
	public static Regex ToRegex(string pattern, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return RegexManager.GetOrAdd(pattern, options);
	}

	/// <summary>
	/// 将当前正则模式字符串转换为正则表达式对象
	/// </summary>
	/// <param name="pattern">当前正则模式字符串</param>
	/// <param name="escape">当前正则模式字符串中的字符是否需要进行转义，作为普通字符处理</param>
	/// <param name="options">正则表达式选项</param>
	/// <returns>正则表达式字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前正则模式字符串为空。</exception>
	public static Regex ToRegex(string pattern, bool escape, RegexOptions options = RegexOptions.None)
	{
		Guard.AssertNotNull(pattern, "pattern");
		return RegexManager.GetOrAdd(escape ? TextHelper.RegexEscape(pattern) : pattern, options);
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.SByte" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.SByte" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToSByte(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static sbyte ToSByte(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.SByte => (sbyte)(object)value, 
				TypeCode.DateTime => Convert.ToSByte(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToSByte(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(sbyte).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.SByte" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static sbyte ToSByte(IntPtr p)
	{
		return ObjectHelper.As<sbyte>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.SByte" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static sbyte ToSByte(UIntPtr p)
	{
		return ObjectHelper.As<sbyte>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.Single" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.Single" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToSingle(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static float ToSingle(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0f;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.Single => (float)(object)value, 
				TypeCode.Char => Convert.ToSingle(Convert.ToUInt16(value, provider), provider), 
				TypeCode.DateTime => Convert.ToSingle(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToSingle(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(float).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Single" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static float ToSingle(IntPtr p)
	{
		return ObjectHelper.As<float>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Single" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static float ToSingle(UIntPtr p)
	{
		return ObjectHelper.As<float>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.String" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.String" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 本方法调用 <see cref="M:System.Convert.ToString(System.Object,System.IFormatProvider)" /> 方法转换当前值。
	/// </remarks>
	public static string ToString(IConvertible value, IFormatProvider provider)
	{
		if (ObjectHelper.IsNull(value))
		{
			return null;
		}
		try
		{
			return Convert.ToString(value, provider);
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(string).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.TimeSpan" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.TimeSpan" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到 <see cref="T:System.TimeSpan" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.String" /> 类型，则调用 <see cref="M:System.TimeSpan.Parse(System.String,System.IFormatProvider)" /> 方法。
	/// 3. 如果当前值为数值类型，则调用 <see cref="M:System.TimeSpan.#ctor(System.Int64)" />。
	/// </remarks>
	public static TimeSpan ToTimeSpan(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return default(TimeSpan);
		}
		try
		{
			switch (value.GetTypeCode())
			{
			case TypeCode.DateTime:
				return new TimeSpan(((DateTime)(object)value).Ticks);
			case TypeCode.String:
				return TimeSpan.Parse(ObjectHelper.As<string>(value), provider);
			case TypeCode.Char:
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
				return new TimeSpan(Convert.ToInt64(value, provider));
			default:
				throw new NotSupportedException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(TimeSpan).FullName));
			}
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(TimeSpan).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前值转换为 <paramref name="type" /> 指定的类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="type">转换的目标类型</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <paramref name="type" /> 指定的类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 本方法调用 <see cref="M:System.Convert.ChangeType(System.Object,System.Type,System.IFormatProvider)" /> 方法转换当前值。
	/// </remarks>
	public static object ToType(IConvertible value, Type type, IFormatProvider provider = null)
	{
		Guard.AssertNotNull(type, "type");
		if (ObjectHelper.IsNull(value))
		{
			return TypeHelper.CreateInstance(type);
		}
		try
		{
			return Convert.ChangeType(value, type, provider);
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), type.FullName), ex);
		}
	}

	/// <summary>
	/// 将当前值转换为 <typeparamref name="T" /> 指定的类型
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <typeparamref name="T" /> 指定的类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 本方法调用 <see cref="M:System.Convert.ChangeType(System.Object,System.Type,System.IFormatProvider)" /> 方法转换当前值。
	/// </remarks>
	public static T ToType<T>(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return default(T);
		}
		try
		{
			return ObjectHelper.As<T>(Convert.ChangeType(value, typeof(T), provider));
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(T).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.UInt16" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.UInt16" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToUInt16(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static ushort ToUInt16(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.UInt16 => (ushort)(object)value, 
				TypeCode.DateTime => Convert.ToUInt16(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToUInt16(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(ushort).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt16" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static ushort ToUInt16(IntPtr p)
	{
		return ObjectHelper.As<ushort>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt16" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static ushort ToUInt16(UIntPtr p)
	{
		return ObjectHelper.As<ushort>(p.ToUInt64());
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.UInt32" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.UInt32" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToUInt32(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static uint ToUInt32(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0u;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.UInt32 => (uint)(object)value, 
				TypeCode.DateTime => Convert.ToUInt32(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToUInt32(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(uint).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前位值数组转换为 <see cref="T:System.UInt32" /> 类型数值
	/// </summary>
	/// <param name="bits">当前位值数组</param>
	/// <returns>转换后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前位值数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前位值数组的长度超过目标类型的位数。</exception>
	public static uint ToUInt32(BitArray bits)
	{
		Guard.AssertNotNull(bits, "bits");
		Guard.AssertBetween(bits.Count, 0, 32, "bits");
		uint value = 0u;
		for (int i = 0; i < bits.Count; i++)
		{
			if (bits[i])
			{
				value += (uint)(1 << i);
			}
		}
		return value;
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt32" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static uint ToUInt32(IntPtr p)
	{
		return ObjectHelper.As<uint>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt32" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static uint ToUInt32(UIntPtr p)
	{
		return p.ToUInt32();
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.UInt64" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.UInt64" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToUInt32(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static ulong ToUInt64(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return 0uL;
		}
		try
		{
			return value.GetTypeCode() switch
			{
				TypeCode.UInt64 => (ulong)(object)value, 
				TypeCode.DateTime => Convert.ToUInt64(((DateTime)(object)value).Ticks, provider), 
				_ => Convert.ToUInt64(value, provider), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(ulong).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前位值数组转换为 <see cref="T:System.UInt64" /> 类型数值
	/// </summary>
	/// <param name="bits">当前位值数组</param>
	/// <returns>转换后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前位值数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前位值数组的长度超过目标类型的位数。</exception>
	public static ulong ToUInt64(BitArray bits)
	{
		Guard.AssertNotNull(bits, "bits");
		Guard.AssertBetween(bits.Count, 0, 64, "bits");
		ulong value = 0uL;
		for (int i = 0; i < bits.Count; i++)
		{
			if (bits[i])
			{
				value += (ulong)(1L << i);
			}
		}
		return value;
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt64" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static ulong ToUInt64(IntPtr p)
	{
		return ObjectHelper.As<ulong>(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt64" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static ulong ToUInt64(UIntPtr p)
	{
		return p.ToUInt64();
	}

	/// <summary>
	/// 将当前值转换为 <see cref="T:System.UIntPtr" />类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到 <see cref="T:System.UIntPtr" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到 <see cref="T:System.IntPtr" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为 null，返回类型默认值。
	/// 2. 根据 <see cref="P:System.UIntPtr.Size" /> 属性值的不同，调用 <see cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToUInt32(System.IConvertible,System.IFormatProvider)" /> 或者 <see cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToUInt64(System.IConvertible,System.IFormatProvider)" /> 转换当前值。
	/// </remarks>
	public static UIntPtr ToUIntPtr(IConvertible value, IFormatProvider provider = null)
	{
		if (ObjectHelper.IsNull(value))
		{
			return default(UIntPtr);
		}
		try
		{
			return UIntPtr.Size switch
			{
				4 => (UIntPtr)value.ToUInt32(provider), 
				8 => (UIntPtr)value.ToUInt64(provider), 
				_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
			};
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(string.Format(Literals.MSG_InvalidCast_2, value.ToString(), typeof(UIntPtr).FullName), ex);
		}
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UIntPtr" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static UIntPtr ToUIntPtr(IntPtr p)
	{
		return new UIntPtr(ToUInt64(p));
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UIntPtr" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static UIntPtr ToUIntPtr(UIntPtr p)
	{
		return new UIntPtr(ToUInt64(p));
	}

	/// <summary>
	/// 将字符串转换为其所表示的统一资源标识符 (URI) 的对象
	/// </summary>
	/// <param name="s">待转换的字符串</param>
	/// <returns>转换后的URI对象</returns>
	public static Uri ToUri(string s)
	{
		Guard.AssertNotNull(s);
		return new Uri(s);
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Boolean" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Boolean" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到可空的 <see cref="T:System.Boolean" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回类型空。
	/// 2. 如果当前值为 'T'、'Y' 返回true，为 'F'、'N' 返回false；不区分大小写。
	/// 3. 如果当前值为 "true" 返回true，为 "false" 返回false；不区分大小写。
	/// 4. 如果当前值等于日期类型的默认值为false，否则返回true；
	/// 5. 否则调用 <see cref="M:System.Convert.ToBoolean(System.Object,System.IFormatProvider)" /> 方法。
	/// </remarks>
	public static bool? ToNullableBoolean(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new bool?(ToBoolean(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Byte" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Byte" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的数值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToByte(System.Object,System.IFormatProvider)" /> 方法。
	/// </remarks>
	public static byte? ToNullableByte(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new byte?(ToByte(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Char" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Char" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 true 则返回 'T'，如果为 false 则返回 'F'。
	/// 3. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的数值对应的字符。
	/// 4. 如果当前值为数值类型，则返回其数值对应的字符。
	/// 5. 否则调用 <see cref="M:System.Convert.ToChar(System.Object,System.IFormatProvider)" /> 方法。
	/// </remarks>
	public static char? ToNullableChar(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new char?(ToChar(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.DateTime" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.DateTime" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到可空的 <see cref="T:System.DateTime" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.String" /> 类型，则调用 <see cref="M:System.DateTime.Parse(System.String,System.IFormatProvider)" /> 方法。
	/// 3. 如果当前值为数值类型，则调用 <see cref="M:System.DateTime.#ctor(System.Int64)" />。
	/// </remarks>
	public static DateTime? ToNullableDateTime(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new DateTime?(ToDateTime(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Decimal" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的可空值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Decimal" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToDecimal(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static decimal? ToNullableDecimal(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new decimal?(ToDecimal(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空 <see cref="T:System.Double" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Double" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToDouble(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static double? ToNullableDouble(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new double?(ToDouble(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <typeparamref name="T" /> 指定的枚举类型
	/// </summary>
	/// <typeparam name="T">枚举类型</typeparam>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <typeparamref name="T" /> 指定的枚举类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为数值类型，则将该数值转换为对应的枚举。
	/// 3. 否则将当前值的字符串表示转换为对应的枚举值。
	/// </remarks>
	public static T? ToNullableEnum<T>(IConvertible value, IFormatProvider provider = null) where T : struct
	{
		return ObjectHelper.IsNull(value) ? null : new T?(ToEnum<T>(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Single" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Single" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToSingle(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	/// <seealso cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToSingle(System.IConvertible,System.IFormatProvider)" />
	public static float? ToNullableFloat(IConvertible value, IFormatProvider provider = null)
	{
		return ToNullableSingle(value, provider);
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Int16" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Int16" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToInt16(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static short? ToNullableInt16(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new short?(ToInt16(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Int32" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Int32" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToInt32(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static int? ToNullableInt32(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new int?(ToInt32(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Int64" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Int64" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToInt64(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static long? ToNullableInt64(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new long?(ToInt64(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.IntPtr" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.IntPtr" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到可空的 <see cref="T:System.IntPtr" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 根据 <see cref="P:System.IntPtr.Size" /> 属性值的不同，调用 <see cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToInt32(System.IConvertible,System.IFormatProvider)" /> 或者 <see cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToInt64(System.IConvertible,System.IFormatProvider)" /> 转换当前值。
	/// </remarks>
	public static IntPtr? ToNullableIntPtr(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new IntPtr?(ToIntPtr(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.SByte" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.SByte" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToSByte(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static sbyte? ToNullableSByte(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new sbyte?(ToSByte(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.Single" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.Single" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToSingle(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static float? ToNullableSingle(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new float?(ToSingle(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.TimeSpan" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.TimeSpan" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到可空的 <see cref="T:System.TimeSpan" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.String" /> 类型，则调用 <see cref="M:System.TimeSpan.Parse(System.String,System.IFormatProvider)" /> 方法。
	/// 3. 如果当前值为数值类型，则调用 <see cref="M:System.TimeSpan.#ctor(System.Int64)" />。
	/// </remarks>
	public static TimeSpan? ToNullableTimeSpan(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new TimeSpan?(ToTimeSpan(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <typeparamref name="T" /> 指定的类型
	/// </summary>
	/// <typeparam name="T">转换的目标类型</typeparam>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <typeparamref name="T" /> 指定的类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 本方法调用 <see cref="M:System.Convert.ChangeType(System.Object,System.Type,System.IFormatProvider)" /> 方法转换当前值。
	/// </remarks>
	public static T? ToNullableType<T>(IConvertible value, IFormatProvider provider = null) where T : struct
	{
		return ObjectHelper.IsNull(value) ? null : new T?(ToType<T>(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.UInt16" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.UInt16" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToUInt16(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static ushort? ToNullableUInt16(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new ushort?(ToUInt16(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.UInt32" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.UInt32" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToUInt32(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static uint? ToNullableUInt32(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new uint?(ToUInt32(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.UInt64" /> 类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.UInt64" /> 类型。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 如果当前值为 <see cref="T:System.DateTime" /> 类型，则返回 <see cref="P:System.DateTime.Ticks" /> 的值。
	/// 3. 否则调用 <see cref="M:System.Convert.ToUInt32(System.Object,System.IFormatProvider)" /> 的值。
	/// </remarks>
	public static ulong? ToNullableUInt64(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new ulong?(ToUInt64(value, provider));
	}

	/// <summary>
	/// 将当前值转换为可空的 <see cref="T:System.UIntPtr" />类型
	/// </summary>
	/// <param name="value">待转换的当前值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等。</param>
	/// <returns>转换后的值</returns>
	/// <exception cref="T:System.InvalidCastException">无法转换当前值到可空的 <see cref="T:System.UIntPtr" /> 类型。</exception>
	/// <exception cref="T:System.NotSupportedException">不支持当前值的类型到可空的 <see cref="T:System.IntPtr" /> 类型的转换。</exception>
	/// <remarks>
	/// 1. 如果当前值为空，返回空。
	/// 2. 根据 <see cref="P:System.UIntPtr.Size" /> 属性值的不同，调用 <see cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToUInt32(System.IConvertible,System.IFormatProvider)" /> 或者 <see cref="M:Richfit.Garnet.Common.Utility.ConvertHelper.ToUInt64(System.IConvertible,System.IFormatProvider)" /> 转换当前值。
	/// </remarks>
	public static UIntPtr? ToNullableUIntPtr(IConvertible value, IFormatProvider provider = null)
	{
		return ObjectHelper.IsNull(value) ? null : new UIntPtr?(ToUIntPtr(value, provider));
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false。</returns>
	public static bool TryParseBoolean(string s, out bool value)
	{
		value = false;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		s = s.Trim();
		if (TextHelper.IsWholeMatch(RegexPatterns.BooleanTrue, s))
		{
			return true;
		}
		if (TextHelper.IsWholeMatch(RegexPatterns.BooleanFalse, s))
		{
			return false;
		}
		return bool.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByte(string s, out byte value)
	{
		return TryParseByte(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByte(string s, NumberStyles style, out byte value)
	{
		return TryParseByte(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByte(string s, IFormatProvider provider, out byte value)
	{
		return TryParseByte(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByte(string s, NumberStyles style, IFormatProvider provider, out byte value)
	{
		value = 0;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return byte.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Byte" />[] 型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseByteArray(string s, out byte[] value)
	{
		value = null;
		return ObjectHelper.IsNull(ObjectHelper.Try(s, (string x) => HexDecode(x), out value));
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Char" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>本方法支持将"0x"、"&amp;h"、"\x"或者"\u"开头的十六进制数值解析为 <see cref="T:System.Char" /> 型数值。</remarks>
	public static bool TryParseChar(string s, out char value)
	{
		value = '\0';
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		s = RegexPatterns.HexCharPrefix.Replace(s, string.Empty);
		return char.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串表示的区域信息
	/// </summary>
	/// <param name="s">当前区域名称</param>
	/// <param name="culture">输出参数，返回当前字符串表示的区域信息</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseCulture(string s, out CultureInfo culture)
	{
		return ObjectHelper.IsNull(ObjectHelper.Try(s, (string x) => CultureInfo.GetCultureInfo(x), out culture));
	}

	/// <summary>
	/// 尝试分析当前字符串表示的区域信息
	/// </summary>
	/// <param name="s">当前区域名称</param>
	/// <param name="alt">区域性名称</param>
	/// <param name="culture">输出参数，返回当前字符串表示的区域信息</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseCulture(string s, string alt, out CultureInfo culture)
	{
		return ObjectHelper.IsNull(ObjectHelper.Try(s, (string x) => CultureInfo.GetCultureInfo(x, alt), out culture));
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, out DateTime value)
	{
		return DateTime.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, DateTimeStyles style, out DateTime value)
	{
		return DateTime.TryParse(s, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParse(s, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, DateTimeStyles style, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParse(s, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, string format, out DateTime value)
	{
		return DateTime.TryParseExact(s, format, null, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, string format, DateTimeStyles style, out DateTime value)
	{
		return DateTime.TryParseExact(s, format, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, string format, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParseExact(s, format, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, string format, DateTimeStyles style, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParseExact(s, format, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, string[] formats, out DateTime value)
	{
		return DateTime.TryParseExact(s, formats, null, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, string[] formats, DateTimeStyles style, out DateTime value)
	{
		return DateTime.TryParseExact(s, formats, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, string[] formats, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParseExact(s, formats, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTime(string s, string[] formats, DateTimeStyles style, IFormatProvider provider, out DateTime value)
	{
		return DateTime.TryParseExact(s, formats, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, DateTimeStyles style, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParse(s, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期。
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParse(s, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, DateTimeStyles style, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParse(s, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, string format, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, format, null, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, string format, DateTimeStyles style, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, format, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, string format, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, format, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="format">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, string format, DateTimeStyles style, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, format, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, string[] formats, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, formats, null, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, string[] formats, DateTimeStyles style, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, formats, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, string[] formats, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, formats, provider, DateTimeStyles.None, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的日期
	/// </summary>
	/// <param name="s">当前日期字符串</param>
	/// <param name="formats">分析时使用的日期格式说明符</param>
	/// <param name="style">日期字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDateTimeOffset(string s, string[] formats, DateTimeStyles style, IFormatProvider provider, out DateTimeOffset value)
	{
		return DateTimeOffset.TryParseExact(s, formats, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDecimal(string s, out decimal value)
	{
		return TryParseDecimal(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDecimal(string s, NumberStyles style, out decimal value)
	{
		return TryParseDecimal(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDecimal(string s, IFormatProvider provider, out decimal value)
	{
		return TryParseDecimal(s, NumberStyles.Number, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Decimal" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDecimal(string s, NumberStyles style, IFormatProvider provider, out decimal value)
	{
		return decimal.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDouble(string s, out double value)
	{
		return TryParseDouble(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDouble(string s, NumberStyles style, out double value)
	{
		return TryParseDouble(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDouble(string s, IFormatProvider provider, out double value)
	{
		return TryParseDouble(s, NumberStyles.Float | NumberStyles.AllowThousands, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Double" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseDouble(string s, NumberStyles style, IFormatProvider provider, out double value)
	{
		return double.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的枚举。
	/// </summary>
	/// <typeparam name="T">解析的枚举类型</typeparam>
	/// <param name="s">当前枚举字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseEnum<T>(string s, out T value) where T : struct
	{
		return Enum.TryParse<T>(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的枚举。
	/// </summary>
	/// <typeparam name="T">解析的枚举类型</typeparam>
	/// <param name="s">当前枚举字符串</param>
	/// <param name="ignoreCase">是否区分枚举名称的大小写</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseEnum<T>(string s, bool ignoreCase, out T value) where T : struct
	{
		return Enum.TryParse<T>(s, ignoreCase, out value);
	}

	/// <summary>
	/// 分析当前字符串所表示的数值；该数值应是用科学计数法表示的。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseExponential(string s, out int[] value)
	{
		value = null;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		Match i = RegexPatterns.ExponentialNumber.Match(s);
		if (i.Groups.Count != 6)
		{
			return false;
		}
		value = new int[4]
		{
			(!(i.Groups[2].Value == "-")) ? 1 : (-1),
			(i.Groups[3].Value.Length != 0) ? ParseInt32(i.Groups[3].Value) : 0,
			(i.Groups[4].Value.Length != 0) ? ParseInt32(i.Groups[4].Value.TrimEnd('0')) : 0,
			(i.Groups[5].Value.Length != 0) ? ParseInt32(i.Groups[5].Value) : 0
		};
		return true;
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseFloat(string s, out float value)
	{
		return TryParseSingle(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseFloat(string s, NumberStyles style, out float value)
	{
		return TryParseSingle(s, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseFloat(string s, IFormatProvider provider, out float value)
	{
		return TryParseSingle(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseFloat(string s, NumberStyles style, IFormatProvider provider, out float value)
	{
		return TryParseSingle(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Guid" /> 类型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>
	/// N:00000000000000000000000000000000
	/// D:00000000-0000-0000-0000-000000000000
	/// B:{00000000-0000-0000-0000-000000000000}
	/// P:(00000000-0000-0000-0000-000000000000)
	/// X:{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
	/// 如果设置为空，则自动检测Guid字符串格式。
	/// </remarks>
	public static bool TryParseGuid(string s, out Guid value)
	{
		return Guid.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Guid" /> 类型数值。
	/// </summary>
	/// <param name="s">当前字符串</param>
	/// <param name="format">Guid字符串的格式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>
	/// <paramref name="format" /> 指定待解析的Guid字符串的格式，包括：
	/// N:00000000000000000000000000000000
	/// D:00000000-0000-0000-0000-000000000000
	/// B:{00000000-0000-0000-0000-000000000000}
	/// P:(00000000-0000-0000-0000-000000000000)
	/// X:{0x00000000,0x0000,0x0000,{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00}}
	/// 如果设置为空，则自动检测Guid字符串格式。
	/// </remarks>
	public static bool TryParseGuid(string s, string format, out Guid value)
	{
		return Guid.TryParseExact(s, format, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的十六进制 <see cref="T:System.Int32" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseHex(string s, out int value)
	{
		return TryParseInt32(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt(string s, out int value)
	{
		return TryParseInt32(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt(string s, NumberStyles style, out int value)
	{
		return TryParseInt32(s, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt(string s, IFormatProvider provider, out int value)
	{
		return TryParseInt32(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt(string s, NumberStyles style, IFormatProvider provider, out int value)
	{
		return TryParseInt32(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt16(string s, out short value)
	{
		return TryParseInt16(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt16(string s, NumberStyles style, out short value)
	{
		return TryParseInt16(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt16(string s, IFormatProvider provider, out short value)
	{
		return TryParseInt16(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt16(string s, NumberStyles style, IFormatProvider provider, out short value)
	{
		value = 0;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return short.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt32(string s, out int value)
	{
		return TryParseInt32(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt32(string s, NumberStyles style, out int value)
	{
		return TryParseInt32(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt32(string s, IFormatProvider provider, out int value)
	{
		return TryParseInt32(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt32(string s, NumberStyles style, IFormatProvider provider, out int value)
	{
		value = 0;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return int.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>本方法支持将"0x"或者"&amp;h"开头的十六进制数值解析为 <see cref="T:System.Int64" /> 型数值。</remarks>
	public static bool TryParseInt64(string s, out long value)
	{
		return TryParseInt64(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt64(string s, NumberStyles style, out long value)
	{
		return TryParseInt64(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt64(string s, IFormatProvider provider, out long value)
	{
		return TryParseInt64(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseInt64(string s, NumberStyles style, IFormatProvider provider, out long value)
	{
		value = 0L;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return long.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>本方法支持将"0x"或者"&amp;h"开头的十六进制数值解析为 <see cref="T:System.IntPtr" /> 型数值。</remarks>
	public static bool TryParseIntPtr(string s, out IntPtr value)
	{
		return TryParseIntPtr(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseIntPtr(string s, NumberStyles style, out IntPtr value)
	{
		return TryParseIntPtr(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseIntPtr(string s, IFormatProvider provider, out IntPtr value)
	{
		return TryParseIntPtr(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.IntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseIntPtr(string s, NumberStyles style, IFormatProvider provider, out IntPtr value)
	{
		value = IntPtr.Zero;
		switch (IntPtr.Size)
		{
		case 4:
		{
			if (TryParseInt32(s, style, provider, out var intResult))
			{
				value = (IntPtr)intResult;
				return true;
			}
			break;
		}
		case 8:
		{
			if (TryParseInt64(s, style, provider, out var longResult))
			{
				value = (IntPtr)longResult;
				return true;
			}
			break;
		}
		default:
			throw new NotSupportedException(string.Format(Literals.MSG_InvalidCast_2, s, typeof(IntPtr).FullName));
		}
		return false;
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	/// <remarks>本方法支持将"0x"或者"&amp;h"开头的十六进制数值解析为 <see cref="T:System.Int64" /> 型数值。</remarks>
	public static bool TryParseLong(string s, out long value)
	{
		return TryParseInt64(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseLong(string s, NumberStyles style, out long value)
	{
		return TryParseInt64(s, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseLong(string s, IFormatProvider provider, out long value)
	{
		return TryParseInt64(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseLong(string s, NumberStyles style, IFormatProvider provider, out long value)
	{
		return TryParseInt64(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的十六进制 <see cref="T:System.Int64" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseLongHex(string s, out long value)
	{
		return TryParseInt64(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSByte(string s, out sbyte value)
	{
		return TryParseSByte(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSByte(string s, NumberStyles style, out sbyte value)
	{
		return TryParseSByte(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSByte(string s, IFormatProvider provider, out sbyte value)
	{
		return TryParseSByte(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.SByte" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSByte(string s, NumberStyles style, IFormatProvider provider, out sbyte value)
	{
		value = 0;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return sbyte.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseShort(string s, out short value)
	{
		return TryParseInt16(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseShort(string s, NumberStyles style, out short value)
	{
		return TryParseInt16(s, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseShort(string s, IFormatProvider provider, out short value)
	{
		return TryParseInt16(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Int16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseShort(string s, NumberStyles style, IFormatProvider provider, out short value)
	{
		return TryParseInt16(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSingle(string s, out float value)
	{
		return TryParseSingle(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSingle(string s, NumberStyles style, out float value)
	{
		return TryParseSingle(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSingle(string s, IFormatProvider provider, out float value)
	{
		return TryParseSingle(s, NumberStyles.Float | NumberStyles.AllowThousands, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.Single" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseSingle(string s, NumberStyles style, IFormatProvider provider, out float value)
	{
		return float.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, out TimeSpan value)
	{
		return TimeSpan.TryParse(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, TimeSpanStyles style, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, "G", null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParse(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, TimeSpanStyles style, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, "G", provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, string format, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, format, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, string format, TimeSpanStyles style, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, format, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, string format, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, format, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="format">分析时使用的时间间隔格式说明符</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, string format, TimeSpanStyles style, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, format, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, string[] formats, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, formats, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, string[] formats, TimeSpanStyles style, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, formats, null, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, string[] formats, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, formats, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.TimeSpan" /> 类型数值。
	/// </summary>
	/// <param name="s">当前时间间隔字符串</param>
	/// <param name="formats">分析时使用的时间间隔格式说明符数组</param>
	/// <param name="style">时间间隔字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseTimeSpan(string s, string[] formats, TimeSpanStyles style, IFormatProvider provider, out TimeSpan value)
	{
		return TimeSpan.TryParseExact(s, formats, provider, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的十六进制值的 <see cref="T:System.UInt32" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUHex(string s, out uint value)
	{
		return TryParseUInt32(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt(string s, out uint value)
	{
		return TryParseUInt32(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt(string s, NumberStyles style, out uint value)
	{
		return TryParseUInt32(s, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt(string s, IFormatProvider provider, out uint value)
	{
		return TryParseUInt32(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt(string s, NumberStyles style, IFormatProvider provider, out uint value)
	{
		return TryParseUInt32(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt16(string s, out ushort value)
	{
		return TryParseUInt16(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt16(string s, NumberStyles style, out ushort value)
	{
		return TryParseUInt16(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt16(string s, IFormatProvider provider, out ushort value)
	{
		return TryParseUInt16(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt16(string s, NumberStyles style, IFormatProvider provider, out ushort value)
	{
		value = 0;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return ushort.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt32(string s, out uint value)
	{
		return TryParseUInt32(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt32(string s, NumberStyles style, out uint value)
	{
		return TryParseUInt32(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt32(string s, IFormatProvider provider, out uint value)
	{
		return TryParseUInt32(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt32" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt32(string s, NumberStyles style, IFormatProvider provider, out uint value)
	{
		value = 0u;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return uint.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt64(string s, out ulong value)
	{
		return TryParseUInt64(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt64(string s, NumberStyles style, out ulong value)
	{
		return TryParseUInt64(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt64(string s, IFormatProvider provider, out ulong value)
	{
		return TryParseUInt64(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUInt64(string s, NumberStyles style, IFormatProvider provider, out ulong value)
	{
		value = 0uL;
		if (ObjectHelper.IsNull(s))
		{
			return false;
		}
		if (style.HasFlag(NumberStyles.AllowHexSpecifier))
		{
			s = RegexPatterns.HexNumberPrefix.Replace(s, string.Empty);
		}
		return ulong.TryParse(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUIntPtr(string s, out UIntPtr value)
	{
		return TryParseUIntPtr(s, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUIntPtr(string s, NumberStyles style, out UIntPtr value)
	{
		return TryParseUIntPtr(s, style, null, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUIntPtr(string s, IFormatProvider provider, out UIntPtr value)
	{
		return TryParseUIntPtr(s, NumberStyles.Integer | NumberStyles.AllowHexSpecifier, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UIntPtr" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUIntPtr(string s, NumberStyles style, IFormatProvider provider, out UIntPtr value)
	{
		value = UIntPtr.Zero;
		switch (UIntPtr.Size)
		{
		case 4:
		{
			if (TryParseInt32(s, style, provider, out var intResult))
			{
				value = (UIntPtr)(ulong)intResult;
				return true;
			}
			break;
		}
		case 8:
		{
			if (TryParseInt64(s, style, provider, out var longResult))
			{
				value = (UIntPtr)(ulong)longResult;
				return true;
			}
			break;
		}
		default:
			throw new NotSupportedException(string.Format(Literals.MSG_InvalidCast_2, s, typeof(UIntPtr).FullName));
		}
		return false;
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULong(string s, out ulong value)
	{
		return TryParseUInt64(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULong(string s, NumberStyles style, out ulong value)
	{
		return TryParseUInt64(s, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULong(string s, IFormatProvider provider, out ulong value)
	{
		return TryParseUInt64(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt64" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULong(string s, NumberStyles style, IFormatProvider provider, out ulong value)
	{
		return TryParseUInt64(s, style, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的十六进制值的 <see cref="T:System.UInt64" /> 类型数值
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseULongHex(string s, out ulong value)
	{
		return TryParseUInt64(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUShort(string s, out ushort value)
	{
		return TryParseUInt16(s, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUShort(string s, NumberStyles style, out ushort value)
	{
		return TryParseUInt16(s, style, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUShort(string s, IFormatProvider provider, out ushort value)
	{
		return TryParseUInt16(s, provider, out value);
	}

	/// <summary>
	/// 尝试分析当前字符串所表示的 <see cref="T:System.UInt16" /> 型数值。
	/// </summary>
	/// <param name="s">当前数值字符串</param>
	/// <param name="style">数值字符串样式</param>
	/// <param name="provider">区域性特定格式设置信息</param>
	/// <param name="value">输出参数，返回当前字符串表示的数值</param>
	/// <returns>如果解析成功返回true，否则返回false</returns>
	public static bool TryParseUShort(string s, NumberStyles style, IFormatProvider provider, out ushort value)
	{
		return TryParseUInt16(s, style, provider, out value);
	}
}
