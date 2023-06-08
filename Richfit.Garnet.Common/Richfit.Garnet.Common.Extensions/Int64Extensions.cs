using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Int64" /> 的扩展方法类
/// </summary>
public static class Int64Extensions
{
	/// <summary>
	/// 将当前的数组唯一索引转换为数组各个秩（维数）的索引的数组
	/// </summary>
	/// <param name="index">当前数组索引</param>
	/// <param name="array">进行转换的基础数组</param>
	/// <returns>按数组各个秩（维数）分割的索引数组</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前的索引小于0。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> 为空。</exception>
	public static long[] ConvertArrayIndexToRankIndex(this long index, Array array)
	{
		index.GuardGreaterThanOrEqualTo(0L, "index");
		array.GuardNotNull("array");
		return index.RadixParse(array.GetLongWeight(), 1L);
	}

	/// <summary>
	/// 将当前的数组各个秩（维数）的索引的数组转换为数组元素的唯一索引
	/// </summary>
	/// <param name="rankIndex">当前数组维度索引</param>
	/// <param name="array">进行转换的基础数组</param>
	/// <returns>数组唯一索引</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前的索引为空或者为空。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> 为空。</exception>
	public static long ConvertRankIndexToArrayIndex(this long[] rankIndex, Array array)
	{
		rankIndex.GuardNotNullAndEmpty("rank index");
		array.GuardNotNull("array");
		return rankIndex.RadixSum(array.GetLongWeight(), 1L);
	}

	/// <summary>
	/// 将 <see cref="T:System.DateTime" /> 序列化后的64位二进制值反序列
	/// </summary>
	/// <param name="data"><see cref="T:System.DateTime" /> 序列化后的64位二进制值</param>
	/// <returns>反序列化后的值</returns>
	public static DateTime DeserializeDateTime(this long data)
	{
		return DateTime.FromBinary(data);
	}

	/// <summary>
	/// 将方法委托执行指定次数
	/// </summary>
	/// <param name="count">执行次数</param>
	/// <param name="action">执行的方法委托</param>
	/// <exception cref="T:System.ArgumentNullException">指定的方法委托 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行次数小于0。</exception>
	public static void For(this long count, Action action)
	{
		action.ForLong(count);
	}

	/// <summary>
	/// 将方法委托执行指定次数
	/// </summary>
	/// <param name="count">执行次数</param>
	/// <param name="action">执行的方法委托，委托接受当前执行次数作为参数</param>
	/// <exception cref="T:System.ArgumentNullException">指定的方法委托 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行次数小于0。</exception>
	/// <remarks>执行的次数从0开始计数，直到执行了指定的次数。</remarks>
	public static void For(this long count, Action<long> action)
	{
		action.ForLong(count);
	}

	/// <summary>
	/// 将方法委托执行指定次数
	/// </summary>
	/// <param name="start">执行的起始计数</param>
	/// <param name="count">执行的次数</param>
	/// <param name="action">执行的方法委托</param>
	/// <exception cref="T:System.ArgumentNullException">指定的方法委托 <paramref name="action" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行的次数 <paramref name="count" /> 小于0。</exception>
	public static void For(this long start, long count, Action<long> action)
	{
		action.ForLong(start, count, 1L);
	}

	/// <summary>
	/// 将方法委托执行指定次数
	/// </summary>
	/// <param name="range">执行的计数范围</param>
	/// <param name="action">执行的方法委托</param>
	/// <exception cref="T:System.ArgumentNullException">执行的方法委托为空。</exception>
	public static void For(this Range<long> range, Action action)
	{
		action.ForLong(range);
	}

	/// <summary>
	/// 将方法委托执行指定次数
	/// </summary>
	/// <param name="range">执行的计数范围</param>
	/// <param name="action">执行的方法委托</param>
	/// <exception cref="T:System.ArgumentNullException">执行的方法委托为空。</exception>
	public static void For(this Range<long> range, Action<long> action)
	{
		action.ForLong(range);
	}

	/// <summary>
	/// 将函数委托执行指定次数
	/// </summary>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="count">执行次数</param>
	/// <param name="func">执行的函数委托</param>
	/// <returns>函数委托的返回值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">指定的函数委托 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行次数小于0。</exception>
	public static IEnumerable<R> ForEval<R>(this long count, Func<R> func)
	{
		return func.ForEvalLong(count);
	}

	/// <summary>
	/// 将函数委托执行指定次数
	/// </summary>
	/// <typeparam name="R">函数委托返回值类型</typeparam>
	/// <param name="count">执行次数</param>
	/// <param name="func">执行的函数委托</param>
	/// <exception cref="T:System.ArgumentNullException">指定的方法委托 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行次数小于0。</exception>
	/// <remarks>执行的次数从0开始计数，直到执行了指定的次数。</remarks>
	public static IEnumerable<R> ForEva<R>(this long count, Func<long, R> func)
	{
		return func.ForEvalLong(count);
	}

	/// <summary>
	/// 将函数委托执行指定次数
	/// </summary>
	/// <param name="start">执行的起始计数</param>
	/// <param name="count">执行的次数</param>
	/// <param name="func">执行的函数委托</param>
	/// <exception cref="T:System.ArgumentNullException">指定的函数委托 <paramref name="func" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">执行的次数 <paramref name="count" /> 小于0。</exception>
	public static IEnumerable<R> ForEval<R>(this long start, long count, Func<long, R> func)
	{
		return func.ForEvalLong(start, count, 1L);
	}

	/// <summary>
	/// 将函数委托执行指定次数
	/// </summary>
	/// <param name="range">执行的计数范围</param>
	/// <param name="func">执行的函数委托</param>
	/// <exception cref="T:System.ArgumentNullException">执行的函数委托为空。</exception>
	public static IEnumerable<R> ForEval<R>(this Range<long> range, Func<R> func)
	{
		return func.ForEvalLong(range);
	}

	/// <summary>
	/// 将函数委托执行指定次数
	/// </summary>
	/// <param name="range">执行的计数范围</param>
	/// <param name="func">执行的函数委托</param>
	/// <exception cref="T:System.ArgumentNullException">或者执行的方法委托为空。</exception>
	public static IEnumerable<R> ForEval<R>(this Range<long> range, Func<long, R> func)
	{
		return func.ForEvalLong(range);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(this long value)
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
	public static byte[] GetBytes(this long value, int size)
	{
		size.GuardGreaterThanOrEqualTo(0, "size");
		byte[] bytes = value.GetBytes();
		byte[] buff = new byte[size];
		Array.Copy(bytes, 0, buff, 0, bytes.Length.Min(buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(this long[] values)
	{
		values.GuardNotNull("values");
		return values.GetBytes(0, values.Length);
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
	public static byte[] GetBytes(this long[] values, int start, int count)
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
	/// 获取当前 <see cref="T:System.Int64" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(this IEnumerable<long> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((long x) => x.GetBytes()).ToArray();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(this long value)
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
	public static byte[] GetRawBytes(this long value, int size)
	{
		size.GuardGreaterThanOrEqualTo(0, "size");
		byte[] bytes = value.GetRawBytes();
		byte[] buff = new byte[size];
		Array.Copy(bytes, bytes.Length - bytes.Length.Min(buff.Length), buff, buff.Length - bytes.Length.Min(buff.Length), bytes.Length.Min(buff.Length));
		return buff;
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.Int64" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(this long[] values)
	{
		values.GuardNotNull("values");
		return values.GetRawBytes(0, values.Length);
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
	public static byte[] GetRawBytes(this long[] values, int start, int count)
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
	/// 获取当前 <see cref="T:System.Int64" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(this IEnumerable<long> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((long x) => x.GetRawBytes()).ToArray();
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引大于 <paramref name="max" />。</exception>
	public static long GuardIndexHighBound(this long index, long max, string name = null, string message = null)
	{
		message = message.IfNull(Literals.MSG_IndexGreaterThanHighBound_2).FormatValue(name.IfNull("index"), max);
		index.Guard(index <= max, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static long GuardIndexHighBound(this long index, long max, Func<Exception> exceptionCreator)
	{
		index.Guard(index <= max, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否小于等于指定的上限，如果大于指定上限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="max">索引的最大值（上限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static long GuardIndexHighBound(this long index, long max, Type exceptionType, params object[] args)
	{
		index.Guard(index <= max, exceptionType, args);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />。</exception>
	public static long GuardIndexLowBound(this long index, long min, string name = null, string message = null)
	{
		message = message.IfNull(Literals.MSG_IndexLessThanLowBound_2).FormatValue(name.IfNull("index"), min);
		index.Guard(index >= min, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	/// <remarks>索引的最小值默认为 0。</remarks>
	public static long GuardIndexLowBound(this long index, long min, Func<Exception> exceptionCreator)
	{
		index.Guard(index >= min, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否大于等于指定的下限，如果小于指定下限则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值（下限）</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static long GuardIndexLowBound(this long index, long min, Type exceptionType, params object[] args)
	{
		index.Guard(index >= min, exceptionType, args);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <see cref="T:System.IndexOutOfRangeException" /> 异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.IndexOutOfRangeException">当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />。</exception>
	public static long GuardIndexRange(this long index, long min, long max, string name = null, string message = null)
	{
		message = string.Format(message.IfNull(Literals.MSG_IndexOutOfRange_1), name.IfNull("index"));
		index.Guard(min <= index && index <= max, () => new IndexOutOfRangeException(message));
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static long GuardIndexRange(this long index, long min, long max, Func<Exception> exceptionCreator)
	{
		index.Guard(min <= index && index <= max, exceptionCreator);
		return index;
	}

	/// <summary>
	/// 检测当前索引是否在指定的范围内，如果超出指定范围则抛出 <paramref name="exceptionType" /> 指定的异常。
	/// </summary>
	/// <param name="index">当前索引</param>
	/// <param name="min">索引的最小值</param>
	/// <param name="max">索引的最大值</param>
	/// <param name="exceptionType">抛出的异常类型</param>
	/// <param name="args">异常构造参数</param>
	/// <returns>如果检测通过返回当前索引</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException"><paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">如果当前索引小于 <paramref name="min" />，或者大于 <paramref name="max" />，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static long GuardIndexRange(this long index, long min, long max, Type exceptionType, params object[] args)
	{
		index.Guard(min <= index && index <= max, exceptionType, args);
		return index;
	}

	/// <summary>
	/// 计算以当前数组值为上限的，各维度从零开始的数值的排列组合
	/// </summary>
	/// <param name="weight">当前数组</param>
	/// <returns>排列组合序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static IEnumerable<long[]> Permute(this long[] weight)
	{
		weight.GuardNotNull("weight");
		long[] dimension = new long[weight.Length];
		do
		{
			long[] temp = new long[weight.Length];
			Array.Copy(dimension, temp, dimension.Length);
			yield return temp;
		}
		while (dimension.PermuteIncrease(weight));
	}

	/// <summary>
	/// 递增排列数组
	/// </summary>
	/// <param name="dimension">当前递增的数组</param>
	/// <param name="max">递增数组的上限</param>
	/// <returns>如果递增成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="max" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="max" /> 的元素个数不等于 <paramref name="dimension" /> 的元素个数。</exception>
	public static bool PermuteIncrease(this long[] dimension, long[] max)
	{
		dimension.GuardNotNull("dimension");
		max.GuardNotNull("max");
		dimension.Guard(dimension.Length == max.Length, "dimension & max");
		for (long i = 0L; i < dimension.Length; i++)
		{
			if (++dimension[i] < max[i])
			{
				return true;
			}
			dimension[i] = 0L;
		}
		return false;
	}

	/// <summary>
	/// 递减排列数组
	/// </summary>
	/// <param name="dimension">当前递减的数组</param>
	/// <param name="origin">递减数组的原始值</param>
	/// <returns>如果递减成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="origin" /> 不为空，且 <paramref name="origin" /> 的元素个数不等于 <paramref name="dimension" /> 的元素个数。</exception>
	public static bool PermuteDecrease(this long[] dimension, long[] origin = null)
	{
		dimension.GuardNotNull("dimension");
		if (origin.IsNull())
		{
			origin = new long[dimension.Length];
			Array.Copy(dimension, origin, dimension.Length);
		}
		dimension.Guard(dimension.Length == origin.Length, "dimension & origin");
		for (long i = 0L; i < dimension.Length; i++)
		{
			if (--dimension[i] >= 0)
			{
				return true;
			}
			dimension[i] = origin[i];
		}
		return false;
	}

	/// <summary>
	/// 按指定的各个整数位的权重，对当前整型值进行分解
	/// </summary>
	/// <param name="value">当前整型值</param>
	/// <param name="weight">分解权重</param>
	/// <param name="radix">分解基数</param>
	/// <returns>分解后各个整数位的值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="weight" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="weight" /> 的元素个数小于1。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="weight" /> 的某个元素小于等于0；或者 <paramref name="radix" /> 小于1。</exception>
	public static long[] RadixParse(this long value, long[] weight, long radix = 1L)
	{
		weight.GuardNotNullAndEmpty("weight");
		weight.ForEach(delegate(long x)
		{
			x.GuardGreaterThan(0L, "weight", Literals.MSG_RadixParseWeigthsOutOfRange);
		});
		radix.GuardGreaterThanOrEqualTo(1L, "radix");
		long[] weightValue = new long[weight.Length];
		weightValue[0] = radix;
		for (long i = 1L; i < weightValue.Length; i++)
		{
			weightValue[i] = weight[i - 1] * weightValue[i - 1];
		}
		long sign = value.Sign();
		value = value.Abs();
		long[] result = new long[weight.Length];
		for (long i = result.Length - 1; i >= 0; i--)
		{
			result[i] = value / (weight[i] * weightValue[i]);
			value %= weight[i] * weightValue[i];
			if (value == 0)
			{
				break;
			}
		}
		result[^1] *= sign;
		return result;
	}

	/// <summary>
	/// 按照指定的各个整数位的权重，将当前权重值的数组组合为相应的整数值
	/// </summary>
	/// <param name="value">当前分解权重值</param>
	/// <param name="weight">分解权重</param>
	/// <param name="radix">分解基数</param>
	/// <returns>组合后的整数值</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="value" /> 为空或者不包含任何元素。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="weight" /> 为空或者不包含任何元素。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="weight" /> 的某个元素小于等于0；或者 <paramref name="radix" /> 小于1。</exception>
	public static long RadixSum(this long[] value, long[] weight, long radix = 1L)
	{
		value.GuardNotNullAndEmpty("value");
		weight.GuardNotNullAndEmpty("weight");
		weight.ForEach(delegate(long x)
		{
			x.GuardGreaterThan(0L, "weight", Literals.MSG_RadixParseWeigthsOutOfRange);
		});
		radix.GuardGreaterThanOrEqualTo(1L, "radix");
		long[] weightValue = new long[weight.Length];
		weightValue[0] = radix;
		for (long i = 1L; i < weightValue.Length; i++)
		{
			weightValue[i] = weight[i - 1] * weightValue[i - 1];
		}
		long sign = value[^1].Sign();
		value[^1] = value[^1].Abs();
		long result = 0L;
		for (long i = 0L; i < value.Length; i++)
		{
			result += value[i] * weight[i] * weightValue[i];
		}
		return result;
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Int64" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this long value, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.Int64" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this long value, string prefix, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(prefix, upperCase);
	}
}
