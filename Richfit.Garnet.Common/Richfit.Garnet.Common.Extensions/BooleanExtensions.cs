using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Boolean" /> 类型扩展方法类
/// </summary>
public static class BooleanExtensions
{
	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常消息</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">如果 <paramref name="value" /> 为true。</exception>
	public static bool GuardFalse(this bool value, string name = null, string message = null)
	{
		value.Guard(!value, () => new ArgumentOutOfRangeException(name.IfNull("value"), message.IfNull(Literals.MSG_ValueTrue)));
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于false，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static bool GuardFalse(this bool value, Func<Exception> exceptionCreator)
	{
		value.Guard(!value, exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于false，如果不等于false，否则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于false，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static bool GuardFalse(this bool value, Type exceptionType, params object[] args)
	{
		value.Guard(!value, exceptionType, args);
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="name">参数名称</param>
	/// <param name="message">异常消息</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">如果 <paramref name="value" /> 为false。</exception>
	public static bool GuardTrue(this bool value, string name = null, string message = null)
	{
		value.Guard(value, () => new ArgumentOutOfRangeException(name.IfNull("value"), message.IfNull(Literals.MSG_ValueFalse)));
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于true，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static bool GuardTrue(this bool value, Func<Exception> exceptionCreator)
	{
		value.Guard(value, exceptionCreator);
		return value;
	}

	/// <summary>
	/// 检测当前值是否等于true，如果不等于true，抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过返回true</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception"><paramref name="value" /> 不等于true，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static bool GuardTrue(this bool value, Type exceptionType, params object[] args)
	{
		value.Guard(value, exceptionType, args);
		return value;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(this bool value)
	{
		return BitConverter.GetBytes(value);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(this bool[] values)
	{
		values.GuardNotNull("values");
		return values.GetBytes(0, values.Length);
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
	public static byte[] GetBytes(this bool[] values, int start, int count)
	{
		values.GuardNotNull("values");
		start.GuardIndexRange(0, values.Length - 1, "start");
		count.GuardBetween(0, values.Length - start, "count");
		List<byte> result = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(values[i].GetBytes());
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(this IEnumerable<bool> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((bool x) => x.GetBytes()).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(this bool value)
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
	public static byte[] GetRawBytes(this bool[] values)
	{
		values.GuardNotNull("values");
		return values.GetRawBytes(0, values.Length);
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
	public static byte[] GetRawBytes(this bool[] values, int start, int count)
	{
		values.GuardNotNull("values");
		start.GuardIndexRange(0, values.Length - 1, "start");
		count.GuardBetween(0, values.Length - start, "count");
		List<byte> bytes = new List<byte>(count * 4);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(values[i].GetRawBytes());
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Boolean" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(this IEnumerable<bool> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((bool x) => x.GetRawBytes()).ToArray();
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Boolean" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this bool value, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Boolean" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this bool value, string prefix, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(prefix, upperCase);
	}

	/// <summary>
	/// 把当前布尔值转换为位数组
	/// </summary>
	/// <param name="value">当前布尔值</param>
	/// <returns>当前值的位数组</returns>
	public static BitArray ToBitArray(this bool value)
	{
		return new BitArray(new bool[1] { value });
	}

	/// <summary>
	/// 把当前布尔值数组转换为位数组
	/// </summary>
	/// <param name="values">当前布尔值数组</param>
	/// <returns>生成的位数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前布尔值数组为空。</exception>
	public static BitArray ToBitArray(this bool[] values)
	{
		values.GuardNotNull("values");
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
	public static BitArray ToBitArray(this bool[] values, int start, int count)
	{
		values.GuardNotNull("values");
		start.GuardIndexRange(0, values.Length - 1, "start");
		count.GuardBetween(0, values.Length - start, "count");
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
	public static BitArray ToBitArray(this IEnumerable<bool> values)
	{
		values.GuardNotNull("values");
		return values.ToArray().ToBitArray();
	}
}
