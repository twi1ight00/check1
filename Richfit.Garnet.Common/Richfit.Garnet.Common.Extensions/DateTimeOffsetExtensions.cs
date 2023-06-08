using System;
using System.Collections.Generic;
using System.Linq;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.DateTimeOffset" /> 类型扩展方法类
///
/// 包括：
/// 1. DateTimeOffset类型的扩展方法
/// 2. 以DateTimeOffset类型为约束的泛型的扩展方法
/// 3. DateTimeOffset类型数组或者泛型数组的扩展方法
/// 4. 以DateTimeOffset类型为约束的泛型或者泛型数组的扩展方法
/// </summary>
public static class DateTimeOffsetExtensions
{
	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(this DateTimeOffset value)
	{
		byte[] bytes = new byte[16];
		Array.Copy(value.DateTime.GetBytes(), bytes, 8);
		Array.Copy(value.Offset.GetBytes(), 0, bytes, 8, 8);
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(this DateTimeOffset[] values)
	{
		values.GuardNotNull("values");
		return values.GetBytes(0, values.Length);
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
	public static byte[] GetBytes(this DateTimeOffset[] values, int start, int count)
	{
		values.GuardNotNull("values");
		start.GuardIndexRange(0, values.Length - 1, "start");
		count.GuardBetween(0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 16);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(values[i].GetBytes());
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(this IEnumerable<DateTimeOffset> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((DateTimeOffset x) => x.GetBytes()).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(this DateTimeOffset value)
	{
		byte[] bytes = new byte[16];
		Array.Copy(value.DateTime.GetRawBytes(), bytes, 8);
		Array.Copy(value.Offset.GetRawBytes(), 0, bytes, 8, 8);
		return bytes;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(this DateTimeOffset[] values)
	{
		values.GuardNotNull("values");
		return values.GetRawBytes(0, values.Length);
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
	public static byte[] GetRawBytes(this DateTimeOffset[] values, int start, int count)
	{
		values.GuardNotNull("values");
		start.GuardIndexRange(0, values.Length - 1, "start");
		count.GuardBetween(0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 16);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(values[i].GetRawBytes());
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTimeOffset" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(this IEnumerable<DateTimeOffset> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((DateTimeOffset x) => x.GetRawBytes()).ToArray();
	}

	/// <summary>
	/// 把当前 <see cref="T:System.DateTimeOffset" /> 型数值序列化为相应的字节数组
	/// </summary>
	/// <param name="date">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] Serialize(this DateTimeOffset date)
	{
		byte[] bytes = new byte[16];
		Array.Copy(date.DateTime.GetRawBytes(), bytes, 8);
		Array.Copy(date.Offset.GetRawBytes(), 0, bytes, 8, 8);
		return bytes;
	}

	/// <summary>
	/// 将当前 <see cref="T:System.DateTimeOffset" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this DateTimeOffset value, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.DateTimeOffset" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this DateTimeOffset value, string prefix, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(prefix, upperCase);
	}

	/// <summary>
	/// 将指定日期转换为指定时区的时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="hours">目标时区的偏移量，小时</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="hours" /> 超出了时区偏移的范围，正负14小时。</exception>
	public static DateTimeOffset ToOffset(this DateTimeOffset date, double hours)
	{
		hours.GuardBetween(-14.0, 14.0, "hours");
		return date.ToOffset(TimeSpan.FromHours(hours));
	}

	/// <summary>
	/// 将指定日期转换为指定时区的时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="minutes">目标时区的偏移量，分钟</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="minutes" /> 超出了时区偏移的范围，正负840分钟。</exception>
	public static DateTimeOffset ToOffset(this DateTimeOffset date, int minutes)
	{
		minutes.GuardBetween(-14, 14, "hours");
		return date.ToOffset(TimeSpan.FromMinutes(minutes));
	}

	/// <summary>
	/// 将指定日期转换为指定时区的时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="targetTimeZone">转换的目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTimeOffset ToTimeZone(this DateTimeOffset date, TimeZoneInfo targetTimeZone)
	{
		targetTimeZone.GuardNotNull("target timezone");
		return TimeZoneInfo.ConvertTime(date, targetTimeZone);
	}
}
