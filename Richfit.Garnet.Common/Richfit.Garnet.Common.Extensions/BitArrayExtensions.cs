using System.Collections;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Collections.BitArray" /> 类扩展方法类
/// </summary>
public static class BitArrayExtensions
{
	/// <summary>
	/// 将当前位值数组转换为 <see cref="T:System.Int32" /> 类型数值
	/// </summary>
	/// <param name="bits">当前位值数组</param>
	/// <returns>转换后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前位值数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前位值数组的长度超过目标类型的位数。</exception>
	public static int ToInt32(this BitArray bits)
	{
		bits.GuardNotNull("bits");
		bits.Count.GuardBetween(0, 32, "bits");
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
	/// 将当前位值数组转换为 <see cref="T:System.UInt32" /> 类型数值
	/// </summary>
	/// <param name="bits">当前位值数组</param>
	/// <returns>转换后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前位值数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前位值数组的长度超过目标类型的位数。</exception>
	public static uint ToUInt32(this BitArray bits)
	{
		bits.GuardNotNull("bits");
		bits.Count.GuardBetween(0, 32, "bits");
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
	/// 将当前位值数组转换为 <see cref="T:System.Int64" /> 类型数值
	/// </summary>
	/// <param name="bits">当前位值数组</param>
	/// <returns>转换后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前位值数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前位值数组的长度超过目标类型的位数。</exception>
	public static long ToInt64(this BitArray bits)
	{
		bits.GuardNotNull("bits");
		bits.Count.GuardBetween(0, 64, "bits");
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
	/// 将当前位值数组转换为 <see cref="T:System.UInt64" /> 类型数值
	/// </summary>
	/// <param name="bits">当前位值数组</param>
	/// <returns>转换后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前位值数组为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前位值数组的长度超过目标类型的位数。</exception>
	public static ulong ToUInt64(this BitArray bits)
	{
		bits.GuardNotNull("bits");
		bits.Count.GuardBetween(0, 64, "bits");
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
}
