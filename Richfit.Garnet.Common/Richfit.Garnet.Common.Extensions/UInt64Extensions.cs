using System;
using System.Collections.Generic;
using System.Linq;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.UInt64" /> 类型扩展方法类
/// </summary>
public static class UInt64Extensions
{
	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(this ulong value)
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
	public static byte[] GetBytes(this ulong value, int size)
	{
		size.GuardGreaterThanOrEqualTo(0, "size");
		byte[] bytes = value.GetBytes();
		byte[] buff = new byte[size];
		Array.Copy(bytes, 0, buff, 0, bytes.Length.Min(buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(this ulong[] values)
	{
		values.GuardNotNull("values");
		return values.GetBytes(0, values.Length);
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
	public static byte[] GetBytes(this ulong[] values, int start, int count)
	{
		values.GuardNotNull("values");
		start.GuardIndexRange(0, values.Length - 1, "start");
		count.GuardBetween(0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(values[i].GetBytes());
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(this IEnumerable<ulong> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((ulong x) => x.GetBytes()).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(this ulong value)
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
	public static byte[] GetRawBytes(this ulong value, int size)
	{
		size.GuardGreaterThanOrEqualTo(0, "size");
		byte[] bytes = value.GetRawBytes();
		byte[] buff = new byte[size];
		Array.Copy(bytes, bytes.Length - bytes.Length.Min(buff.Length), buff, buff.Length - bytes.Length.Min(buff.Length), bytes.Length.Min(buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(this ulong[] values)
	{
		values.GuardNotNull("values");
		return values.GetRawBytes(0, values.Length);
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
	public static byte[] GetRawBytes(this ulong[] values, int start, int count)
	{
		values.GuardNotNull("values");
		start.GuardIndexRange(0, values.Length - 1, "start");
		count.GuardBetween(0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 8);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(values[i].GetRawBytes());
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.UInt64" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(this IEnumerable<ulong> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((ulong x) => x.GetRawBytes()).ToArray();
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt64" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this ulong value, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.UInt64" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this ulong value, string prefix, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(prefix, upperCase);
	}
}
