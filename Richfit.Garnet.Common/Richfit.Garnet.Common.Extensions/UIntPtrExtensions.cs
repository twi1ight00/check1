using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.UIntPtr" /> 类型扩展方法类
/// </summary>
public static class UIntPtrExtensions
{
	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static bool ToBoolean(this UIntPtr p)
	{
		return p != UIntPtr.Zero;
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Byte" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static byte ToByte(this UIntPtr p)
	{
		return p.ToUInt64().As<byte>();
	}

	/// <summary>
	/// 获取当前句柄型数值的位字节数组
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(this UIntPtr p)
	{
		return IntPtr.Size switch
		{
			4 => p.ToUInt32().GetBytes(), 
			8 => p.ToUInt64().GetBytes(), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 获取当前句柄型数值数组的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(this UIntPtr[] ps)
	{
		ps.GuardNotNull("values");
		return ps.GetBytes(0, ps.Length);
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
	public static byte[] GetBytes(this UIntPtr[] ps, int start, int count)
	{
		ps.GuardNotNull("values");
		start.GuardIndexRange(0, ps.Length - 1, "start");
		count.GuardBetween(0, ps.Length - start, "count");
		List<byte> result = new List<byte>(count * UIntPtr.Size);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			result.AddRange(ps[i].GetBytes());
		}
		return result.ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值序列的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(this IEnumerable<UIntPtr> ps)
	{
		ps.GuardNotNull("values");
		return ps.SelectMany((UIntPtr x) => x.GetBytes()).ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(this UIntPtr p)
	{
		return UIntPtr.Size switch
		{
			4 => p.ToUInt32().GetRawBytes(), 
			8 => p.ToUInt64().GetRawBytes(), 
			_ => throw new NotSupportedException(Literals.MSG_PlatformArchitectureException), 
		};
	}

	/// <summary>
	/// 获取当前句柄型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(this UIntPtr[] ps)
	{
		ps.GuardNotNull("values");
		return ps.GetRawBytes(0, ps.Length);
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
	public static byte[] GetRawBytes(this UIntPtr[] ps, int start, int count)
	{
		ps.GuardNotNull("values");
		start.GuardIndexRange(0, ps.Length - 1, "start");
		count.GuardBetween(0, ps.Length - start, "count");
		List<byte> bytes = new List<byte>(count * UIntPtr.Size);
		int end = start + count;
		for (int i = start; i < end; i++)
		{
			bytes.AddRange(ps[i].GetRawBytes());
		}
		return bytes.ToArray();
	}

	/// <summary>
	/// 获取当前句柄型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="ps">当前句柄数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(this IEnumerable<UIntPtr> ps)
	{
		ps.GuardNotNull("values");
		return ps.SelectMany((UIntPtr x) => x.GetRawBytes()).ToArray();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Char" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static char ToChar(this UIntPtr p)
	{
		return p.ToUInt64().As<char>();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Decimal" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static decimal ToDecimal(this UIntPtr p)
	{
		return p.ToUInt64().As<decimal>();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Double" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static double ToDouble(this UIntPtr p)
	{
		return p.ToUInt64().As<double>();
	}

	/// <summary>
	/// 将当前句柄转换为指定类型的枚举
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="type">枚举类型</param>
	/// <returns>数值对应的枚举</returns>
	public static object ToEnum(this UIntPtr p, Type type)
	{
		return p.ToUInt64().ConvertToEnum(type);
	}

	/// <summary>
	/// 将当前句柄转换为指定类型的枚举
	/// </summary>
	/// <typeparam name="T">枚举类型</typeparam>
	/// <param name="p">当前句柄</param>
	/// <returns>数值对应的枚举</returns>
	public static T ToEnum<T>(this UIntPtr p) where T : struct
	{
		return p.ToUInt64().ConvertToEnum<T>();
	}

	/// <summary>
	/// 将当前句柄转换为十六进制字符串形式
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前句柄的十六进制字符串形式</returns>
	public static string ToHex(this UIntPtr p, bool upperCase = false)
	{
		return p.GetRawBytes().ToHex(upperCase);
	}

	/// <summary>
	/// 将当前句柄转换为十六进制字符串形式
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前句柄的十六进制字符串形式</returns>
	public static string ToHex(this UIntPtr p, string prefix, bool upperCase = false)
	{
		return p.GetRawBytes().ToHex(prefix, upperCase);
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int16" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static short ToInt16(this UIntPtr p)
	{
		return p.ToUInt64().As<short>();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int32" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static int ToInt32(this UIntPtr p)
	{
		return p.ToUInt64().As<int>();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Int64" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static long ToInt64(this UIntPtr p)
	{
		return p.ToUInt64().As<long>();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.IntPtr" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static IntPtr ToIntPtr(this UIntPtr p)
	{
		return new IntPtr(p.ToInt64());
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.SByte" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static sbyte ToSByte(this UIntPtr p)
	{
		return p.ToUInt64().As<sbyte>();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.Single" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static float ToSingle(this UIntPtr p)
	{
		return p.ToUInt64().As<float>();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt16" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static ushort ToUInt16(this UIntPtr p)
	{
		return p.ToUInt64().As<ushort>();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt32" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static uint ToUInt32(this UIntPtr p)
	{
		return p.ToUInt32();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UInt64" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static ulong ToUInt64(this UIntPtr p)
	{
		return p.ToUInt64();
	}

	/// <summary>
	/// 将当前句柄转换为 <see cref="T:System.UIntPtr" /> 型数值
	/// </summary>
	/// <param name="p">当前句柄</param>
	/// <returns>转换后的值</returns>
	public static UIntPtr ToUIntPtr(this UIntPtr p)
	{
		return new UIntPtr(p.ToUInt64());
	}
}
