#define DEBUG
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 随机数辅助类
/// </summary>
public static class RandomHelper
{
	/// <summary>
	/// 全局的随机数生成器
	/// </summary>
	private static Random globalRandom = new Random();

	/// <summary>
	/// 线程独立的随机数生成器
	/// </summary>
	[ThreadStatic]
	private static Random localRandom = null;

	/// <summary>
	/// 获取当前线程的随机数生成器
	/// </summary>
	/// <returns>当前线程的随机数生成器</returns>
	public static Random GetLocalRandom()
	{
		if (ObjectHelper.IsNull(localRandom))
		{
			lock (globalRandom)
			{
				localRandom = new Random(globalRandom.Next());
			}
		}
		return localRandom;
	}

	/// <summary>
	/// 获取当前线程的随机数生成器
	/// </summary>
	/// <param name="random">当前随机数生成器对象</param>
	/// <returns>当前线程的随机数生成器</returns>
	public static Random GetLocalRandom(Random random)
	{
		return GetLocalRandom();
	}

	/// <summary>
	/// 枚举随机字母（大写和小写）
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字母序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateAlphabet(Random random)
	{
		while (true)
		{
			yield return GetAlphabet(random);
		}
	}

	/// <summary>
	/// 枚举随机字母（大写和小写）和数字
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字母和数字序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateAlphabetDigit(Random random)
	{
		while (true)
		{
			yield return GetAlphabetDigit(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<bool> EnumerateBoolean(Random random)
	{
		while (true)
		{
			yield return GetBoolean(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="trueRatio">产生的真值的概率，值为0到1之间的小数</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">真值概率 <paramref name="trueRatio" /> 小于0，或者大于1。</exception>
	public static IEnumerable<bool> EnumerateBoolean(Random random, double trueRatio)
	{
		while (true)
		{
			yield return GetBoolean(random, trueRatio);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Byte" /> 型数值；生成的随机数大于等于 <see cref="F:System.Byte.MinValue" />，小于等于 <see cref="F:System.Byte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<byte> EnumerateByte(Random random)
	{
		while (true)
		{
			yield return GetByte(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Byte" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 随机数最小值 <paramref name="min" /> 小于 <see cref="F:System.Byte.MinValue" />，或者大于 <see cref="F:System.Byte.MaxValue" />；
	/// 随机数最大值 <paramref name="max" /> 小于 <see cref="F:System.Byte.MinValue" />，或者大于 <see cref="F:System.Byte.MaxValue" />；
	/// 随机数的最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。
	/// </exception>
	public static IEnumerable<byte> EnumerateByte(Random random, byte min, byte max)
	{
		while (true)
		{
			yield return GetByte(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机中文字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机中文字符序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateCharacter(Random random)
	{
		while (true)
		{
			yield return GetCharacter(random);
		}
	}

	/// <summary>
	/// 枚举随机的颜色；获取的随进颜色均为不透明的颜色。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>产生随机的颜色序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<Color> EnumerateColor(Random random)
	{
		while (true)
		{
			yield return GetColor(random);
		}
	}

	/// <summary>
	/// 枚举随机的颜色；获取的随进颜色均为不透明的颜色。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="alpha">随机颜色的Alpha分量</param>
	/// <returns>产生随机的颜色序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机颜色的Alpha分量 <paramref name="alpha" /> 小于0，或者大于255。</exception>
	public static IEnumerable<Color> EnumerateColor(Random random, int alpha)
	{
		while (true)
		{
			yield return GetColor(random, alpha);
		}
	}

	/// <summary>
	/// 枚举随机的颜色
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">随机范围的起始颜色</param>
	/// <param name="max">随机范围的结束颜色</param>
	/// <returns>产生随机的颜色序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<Color> EnumerateColor(Random random, Color min, Color max)
	{
		while (true)
		{
			yield return GetColor(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.DateTime" /> 型数值；生成的随机数大于等于 <see cref="F:System.DateTime.MinValue" />，小于等于 <see cref="F:System.DateTime.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static DateTime EnumerateDateTime(Random random)
	{
		bool flag = true;
		return GetDateTime(random);
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.DateTime" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static DateTime EnumerateDateTime(Random random, DateTime min, DateTime max)
	{
		bool flag = true;
		return GetDateTime(random, min, max);
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Decimal" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<decimal> EnumerateDecimal(Random random)
	{
		while (true)
		{
			yield return GetDecimal(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Decimal" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值值大于最大值。</exception>
	public static IEnumerable<decimal> EnumerateDecimal(Random random, decimal min, decimal max)
	{
		while (true)
		{
			yield return GetDecimal(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机十进制数值字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字符序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateDigit(Random random)
	{
		while (true)
		{
			yield return GetDigit(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Double" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<double> EnumerateDouble(Random random)
	{
		while (true)
		{
			yield return GetDouble(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Double" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值值大于最大值。</exception>
	public static IEnumerable<double> EnumerateDouble(Random random, double min, double max)
	{
		while (true)
		{
			yield return GetDouble(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <typeparamref name="T" /> 类型的枚举值
	/// </summary>
	/// <typeparam name="T">枚举类型</typeparam>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>产生随机的枚举值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.NotSupportedException">指定的类型 <typeparamref name="T" /> 不是枚举类型。</exception>
	public static IEnumerable<T> EnumerateEnum<T>(Random random)
	{
		while (true)
		{
			yield return GetEnum<T>(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <paramref name="type" /> 类型的枚举值
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="type">枚举类型</param>
	/// <returns>产生的随机枚举值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空；或者枚举类型 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">指定的类型 <paramref name="type" /> 不是枚举类型。</exception>
	public static IEnumerable<object> EnumerateEnum(Random random, Type type)
	{
		while (true)
		{
			yield return GetEnum(random, type);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<float> EnumerateFloat(Random random)
	{
		while (true)
		{
			yield return GetFloat(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static IEnumerable<float> EnumerateFloat(Random random, float min, float max)
	{
		while (true)
		{
			yield return GetFloat(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的十六进制数值的字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="upperCase">是否生成大写字母</param>
	/// <returns>生成的随机十六进制数值字符序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateHex(Random random, bool upperCase = false)
	{
		while (true)
		{
			yield return GetHex(random, upperCase);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int16" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int16.MinValue" />，小于等于 <see cref="F:System.Int16.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<short> EnumerateInt16(Random random)
	{
		while (true)
		{
			yield return GetInt16(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int16" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 随机数最小值 <paramref name="min" /> 小于 <see cref="F:System.Int16.MinValue" />，或者大于 <see cref="F:System.Int16.MaxValue" />；
	/// 随机数最大值 <paramref name="max" /> 小于 <see cref="F:System.Int16.MinValue" />，或者大于 <see cref="F:System.Int16.MaxValue" />；
	/// 随机数的最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。
	/// </exception>
	public static IEnumerable<short> EnumerateInt16(Random random, short min, short max)
	{
		while (true)
		{
			yield return GetInt16(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int32" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int32.MinValue" />，小于等于 <see cref="F:System.Int32.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<int> EnumerateInt32(Random random)
	{
		while (true)
		{
			yield return GetInt32(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int32" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static IEnumerable<int> EnumerateInt32(Random random, int min, int max)
	{
		while (true)
		{
			yield return GetInt32(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int64" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int64.MinValue" />，小于等于 <see cref="F:System.Int64.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<long> EnumerateInt64(Random random)
	{
		while (true)
		{
			yield return GetInt64(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int64" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static IEnumerable<long> EnumerateInt64(Random random, long min, long max)
	{
		while (true)
		{
			yield return GetInt64(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.SByte" /> 型数值；生成的随机数大于等于 <see cref="F:System.SByte.MinValue" />，小于等于 <see cref="F:System.SByte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<sbyte> EnumerateSByte(Random random)
	{
		while (true)
		{
			yield return GetSByte(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.SByte" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 随机数最小值 <paramref name="min" /> 小于 <see cref="F:System.SByte.MinValue" />，或者大于 <see cref="F:System.SByte.MaxValue" />；
	/// 随机数最大值 <paramref name="max" /> 小于 <see cref="F:System.SByte.MinValue" />，或者大于 <see cref="F:System.SByte.MaxValue" />；
	/// 随机数的最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。
	/// </exception>
	public static IEnumerable<sbyte> EnumerateSByte(Random random, sbyte min, sbyte max)
	{
		while (true)
		{
			yield return GetSByte(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<float> EnumerateSingle(Random random)
	{
		while (true)
		{
			yield return GetSingle(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static IEnumerable<float> EnumerateSingle(Random random, float min, float max)
	{
		while (true)
		{
			yield return GetSingle(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.TimeSpan" /> 型数值；生成的随机数大于等于 <see cref="F:System.TimeSpan.MinValue" />，小于等于 <see cref="F:System.TimeSpan.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<TimeSpan> EnumerateTimeSpan(Random random)
	{
		while (true)
		{
			yield return GetTimeSpan(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.TimeSpan" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static IEnumerable<TimeSpan> EnumerateTimeSpan(Random random, TimeSpan min, TimeSpan max)
	{
		while (true)
		{
			yield return GetTimeSpan(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt16" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt16.MinValue" />，小于等于 <see cref="F:System.UInt16.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<ushort> EnumerateUInt16(Random random)
	{
		while (true)
		{
			yield return GetUInt16(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt32" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 随机数最小值 <paramref name="min" /> 小于 <see cref="F:System.UInt16.MinValue" />，或者大于 <see cref="F:System.UInt16.MaxValue" />；
	/// 随机数最大值 <paramref name="max" /> 小于 <see cref="F:System.UInt16.MinValue" />，或者大于 <see cref="F:System.UInt16.MaxValue" />；
	/// 随机数的最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。
	/// </exception>
	public static IEnumerable<ushort> EnumerateUInt16(Random random, int min, int max)
	{
		while (true)
		{
			yield return GetUInt16(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt32" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt32.MinValue" />，小于等于 <see cref="F:System.UInt32.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<uint> EnumerateUInt32(Random random)
	{
		while (true)
		{
			yield return GetUInt32(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt32" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static IEnumerable<uint> EnumerateUInt32(Random random, uint min, uint max)
	{
		while (true)
		{
			yield return GetUInt32(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt64" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt64.MinValue" />，小于等于 <see cref="F:System.UInt64.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<ulong> EnumerateUInt64(Random random)
	{
		while (true)
		{
			yield return GetUInt64(random);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt64" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static IEnumerable<ulong> EnumerateUInt64(Random random, ulong min, ulong max)
	{
		while (true)
		{
			yield return GetUInt64(random, min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <typeparamref name="T" /> 型数值。
	/// </summary>
	/// <typeparam name="T">生成的随机数类型</typeparam>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="creator">根据当前整形随机值创建 <typeparamref name="T" /> 类型数值的方法</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空；或者随机数值生成方法为空。</exception>
	public static IEnumerable<T> EnumerateValue<T>(Random random, Func<int, T> creator)
	{
		while (true)
		{
			yield return GetValue(random, creator);
		}
	}

	/// <summary>
	/// 获取随机的 <typeparamref name="T" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <typeparam name="T">生成的随机数类型</typeparam>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <param name="creator">根据当前整形随机值创建 <typeparamref name="T" /> 类型数值的方法</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空；或者随机数值生成方法为空。</exception>
	public static IEnumerable<T> EnumerateValue<T>(Random random, T min, T max, Func<int, T, T, T> creator)
	{
		while (true)
		{
			yield return GetValue(random, min, max, creator);
		}
	}

	/// <summary>
	/// 枚举随机的 <typeparamref name="T" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <typeparam name="T">生成的随机数类型</typeparam>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <param name="provider">格式化提供对象</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static IEnumerable<T> EnumerateValue<T>(Random random, T min, T max, IFormatProvider provider = null) where T : IConvertible
	{
		while (true)
		{
			yield return GetValue(random, min, max, provider);
		}
	}

	/// <summary>
	/// 获取随机字母（大写和小写）
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字母</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetAlphabet(Random random)
	{
		Guard.AssertNotNull(random, "random");
		int value = random.Next(0, 52);
		return (value < 26) ? ((char)(65 + value)) : ((char)(97 + value - 26));
	}

	/// <summary>
	/// 获取指定个数的随机字母组成的文本
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="count">随机生成的字符数量</param>
	/// <returns>生成的随机文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的字符数量 <paramref name="count" /> 小于0。</exception>
	public static string GetAlphabetText(Random random, int count)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(GetAlphabet(random));
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机字母（大写和小写）和数字
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字母和数字</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetAlphabetDigit(Random random)
	{
		Guard.AssertNotNull(random, "random");
		int value = random.Next(0, 62);
		return (value < 10) ? ((char)(48 + value)) : ((value < 36) ? ((char)(65 + value - 10)) : ((char)(97 + value - 36)));
	}

	/// <summary>
	/// 获取指定个数的随机字母和数字组成的文本
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="count">随机生成的字符数量</param>
	/// <returns>生成的随机文本</returns>\
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的字符串的字符数量 <paramref name="count" /> 小于0。</exception>
	public static string GetAlphabetDigitText(Random random, int count)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(GetAlphabetDigit(random));
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static bool GetBoolean(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return random.Next(0, 2) == 1;
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Boolean" /> 型数值；真值满足由 <paramref name="ratio" /> 指定的概率
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="ratio">产生的真值的概率，值为0到1之间的小数</param>
	/// <returns>产生的随机的布尔值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">真值概率 <paramref name="ratio" /> 小于0，或者大于1。</exception>
	public static bool GetBoolean(Random random, double ratio)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertBetween(ratio, 0.0, 1.0, "ratio");
		return random.NextDouble() <= ratio;
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Byte" /> 型数值；生成的随机数大于等于 <see cref="F:System.Byte.MinValue" />，小于等于 <see cref="F:System.Byte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static byte GetByte(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return (byte)random.Next(0, 256);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Byte" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 随机数最小值 <paramref name="min" /> 小于 <see cref="F:System.Byte.MinValue" />，或者大于 <see cref="F:System.Byte.MaxValue" />；
	/// 随机数最大值 <paramref name="max" /> 小于 <see cref="F:System.Byte.MinValue" />，或者大于 <see cref="F:System.Byte.MaxValue" />；
	/// 随机数的最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。
	/// </exception>
	public static byte GetByte(Random random, int min, int max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertBetween(min, 0, 255, "min");
		Guard.AssertBetween(max, 0, 255, "max");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (byte)random.Next(min, max + 1);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Byte" /> 型数值数组；生成的随机数大于等于 <see cref="F:System.Byte.MinValue" />，小于等于 <see cref="F:System.Byte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="count">生成的数组的元素数量</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的数组元素数量 <paramref name="count" /> 小于0。</exception>
	public static byte[] GetByteArray(Random random, int count)
	{
		Guard.AssertNotNull(random, "randon");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		byte[] buff = new byte[count];
		for (int i = 0; i < buff.Length; i++)
		{
			buff[i] = GetByte(random);
		}
		return buff;
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Byte" /> 型数值数组；生成的随机数大于等于 <see cref="F:System.Byte.MinValue" />，小于等于 <see cref="F:System.Byte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="count">生成的数组的元素数量</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的数组元素数量 <paramref name="count" /> 小于0。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static byte[] GetByteArray(Random random, int count, byte min, byte max)
	{
		Guard.AssertNotNull(random, "randon");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		byte[] buff = new byte[count];
		for (int i = 0; i < buff.Length; i++)
		{
			buff[i] = GetByte(random, min, max);
		}
		return buff;
	}

	/// <summary>
	/// 获取随机中文字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机中文字符</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetCharacter(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return (char)random.Next(19968, 40870);
	}

	/// <summary>
	/// 获取指定个数的随机中文字符组成的文本
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="count">生成的中文字符数量</param>
	/// <returns>生成的随机文本</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的中文字符数量 <paramref name="count" /> 小于0。</exception>
	public static string GetCharacterText(Random random, int count)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "length");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(GetCharacter(random));
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机的颜色；获取的随进颜色均为不透明的颜色。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>产生随机的颜色</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static Color GetColor(Random random)
	{
		return GetColor(random, 255);
	}

	/// <summary>
	/// 获取随机的颜色；获取的随进颜色均为不透明的颜色。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="alpha">随机颜色的Alpha分量</param>
	/// <returns>产生随机的颜色</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机颜色的Alpha分量 <paramref name="alpha" /> 小于0，或者大于255。</exception>
	public static Color GetColor(Random random, int alpha)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertBetween(alpha, 0, 255, "alpha");
		return Color.FromArgb(alpha, GetByte(random), GetByte(random), GetByte(random));
	}

	/// <summary>
	/// 获取随机的颜色
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">随机范围的起始颜色</param>
	/// <param name="max">随机范围的结束颜色</param>
	/// <returns>产生随机的颜色</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static Color GetColor(Random random, Color min, Color max)
	{
		Guard.AssertNotNull(random, "random");
		return Color.FromArgb(GetByte(random, Math.Min(min.A, max.A), Math.Max(min.A, max.A)), GetByte(random, Math.Min(min.R, max.R), Math.Max(min.R, max.R)), GetByte(random, Math.Min(min.G, max.G), Math.Max(min.G, max.G)), GetByte(random, Math.Min(min.B, max.B), Math.Max(min.B, max.B)));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.DateTime" /> 型数值；生成的随机数大于等于 <see cref="F:System.DateTime.MinValue" />，小于等于 <see cref="F:System.DateTime.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static DateTime GetDateTime(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return new DateTime(GetInt64(random));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.DateTime" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static DateTime GetDateTime(Random random, DateTime min, DateTime max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return new DateTime(GetInt64(random, min.Ticks, max.Ticks + 1));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Decimal" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static decimal GetDecimal(Random random)
	{
		Guard.AssertNotNull(random, "random");
		byte[] buff = new byte[12];
		random.NextBytes(buff);
		decimal value = new decimal(new int[4]
		{
			ConvertHelper.GetInt32(buff),
			ConvertHelper.GetInt32(buff, 4),
			ConvertHelper.GetInt32(buff, 8),
			ConvertHelper.GetInt32(new byte[4] { 0, 0, 28, 0 })
		});
		return value - decimal.Truncate(value);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Decimal" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值值大于最大值。</exception>
	public static decimal GetDecimal(Random random, decimal min, decimal max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = (max - min) * GetDecimal(random);
		return min + delta;
	}

	/// <summary>
	/// 获取随机十进制数值字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetDigit(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return (char)(48 + random.Next(0, 10));
	}

	/// <summary>
	/// 获取指定个数的随机十进制数值字符组成的字符串
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="count">随机生成的字符串的字符个数</param>
	/// <returns>生成的随机字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">生成的字符串的字符数量 <paramref name="count" /> 小于0。</exception>
	public static string GetDigitText(Random random, int count)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(GetDigit(random));
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Double" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static double GetDouble(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return random.NextDouble();
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Double" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值值大于最大值。</exception>
	public static double GetDouble(Random random, double min, double max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		double delta = (max - min) * GetDouble(random);
		return min + delta;
	}

	/// <summary>
	/// 获取随机的 <typeparamref name="T" /> 类型的枚举值
	/// </summary>
	/// <typeparam name="T">枚举类型</typeparam>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>产生随机的枚举值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.NotSupportedException">指定的类型 <typeparamref name="T" /> 不是枚举类型。</exception>
	public static T GetEnum<T>(Random random)
	{
		return (T)GetEnum(random, typeof(T));
	}

	/// <summary>
	/// 获取随机的 <paramref name="type" /> 类型的枚举值
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="type">枚举类型</param>
	/// <returns>产生的随机枚举值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空；或者枚举类型 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">指定的类型 <paramref name="type" /> 不是枚举类型。</exception>
	public static object GetEnum(Random random, Type type)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertNotNull(type, "enum type");
		Guard.Assert(type.IsEnum, () => new NotSupportedException(string.Format(Literals.MSG_TypeNotEnum_1, type.FullName)));
		Array values = Enum.GetValues(type);
		return values.GetValue(values.GetLowerBound(0) + random.Next(0, values.Length));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static float GetFloat(Random random)
	{
		return GetSingle(random);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static float GetFloat(Random random, float min, float max)
	{
		return GetSingle(random, min, max);
	}

	/// <summary>
	/// 获取随机的十六进制数值的字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="upperCase">是否生成大写字母</param>
	/// <returns>生成的随机十六进制数值字符</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetHex(Random random, bool upperCase = false)
	{
		Guard.AssertNotNull(random, "random");
		int value = random.Next(0, 16);
		return (value < 10) ? ((char)(48 + value)) : ((char)(upperCase ? 65u : ((uint)(97 + (value - 10)))));
	}

	/// <summary>
	/// 获取由指定数量的随机十六进制数值字符组成的文本
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="count">随机生成的字符数量</param>
	/// <param name="upperCase">是否生成大写字母</param>
	/// <returns>生成的随机十六进制数值字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">字符数量 <paramref name="count" /> 小于0。</exception>
	public static string GetHexText(Random random, int count, bool upperCase = false)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertGreaterThanOrEqualTo(count, 0, "count");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(GetHex(random, upperCase));
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int16" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int16.MinValue" />，小于等于 <see cref="F:System.Int16.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static short GetInt16(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return (short)random.Next(-32768, 32768);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int16" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 随机数最小值 <paramref name="min" /> 小于 <see cref="F:System.Int16.MinValue" />，或者大于 <see cref="F:System.Int16.MaxValue" />；
	/// 随机数最大值 <paramref name="max" /> 小于 <see cref="F:System.Int16.MinValue" />，或者大于 <see cref="F:System.Int16.MaxValue" />；
	/// 随机数的最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。
	/// </exception>
	public static short GetInt16(Random random, int min, int max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertBetween(min, -128, 127, "min");
		Guard.AssertBetween(max, -128, 127, "max");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (short)random.Next(min, max + 1);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int32" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int32.MinValue" />，小于等于 <see cref="F:System.Int32.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static int GetInt32(Random random)
	{
		Guard.AssertNotNull(random, "random");
		byte[] buff = new byte[4];
		random.NextBytes(buff);
		return ConvertHelper.GetInt32(buff);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int32" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static int GetInt32(Random random, int min, int max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = ((decimal)max - (decimal)min + 1m) * GetDecimal(random);
		return (int)((decimal)min + delta);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int64" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int64.MinValue" />，小于等于 <see cref="F:System.Int64.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static long GetInt64(Random random)
	{
		Guard.AssertNotNull(random, "random");
		byte[] buff = new byte[8];
		random.NextBytes(buff);
		return ConvertHelper.GetInt64(buff);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int64" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static long GetInt64(Random random, long min, long max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = ((decimal)max - (decimal)min + 1m) * GetDecimal(random);
		return (long)((decimal)min + delta);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.SByte" /> 型数值；生成的随机数大于等于 <see cref="F:System.SByte.MinValue" />，小于等于 <see cref="F:System.SByte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static sbyte GetSByte(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return (sbyte)random.Next(0, 256);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.SByte" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 随机数最小值 <paramref name="min" /> 小于 <see cref="F:System.SByte.MinValue" />，或者大于 <see cref="F:System.SByte.MaxValue" />；
	/// 随机数最大值 <paramref name="max" /> 小于 <see cref="F:System.SByte.MinValue" />，或者大于 <see cref="F:System.SByte.MaxValue" />；
	/// 随机数的最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。
	/// </exception>
	public static sbyte GetSByte(Random random, int min, int max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertBetween(min, -128, 127, "min");
		Guard.AssertBetween(max, -128, 127, "max");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (sbyte)random.Next(min, max + 1);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static float GetSingle(Random random)
	{
		return (float)GetDouble(random);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static float GetSingle(Random random, float min, float max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		double delta = (double)(max - min) * GetDouble(random);
		return (float)((double)min + delta);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.TimeSpan" /> 型数值；生成的随机数大于等于 <see cref="F:System.TimeSpan.MinValue" />，小于等于 <see cref="F:System.TimeSpan.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static TimeSpan GetTimeSpan(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return new TimeSpan(GetInt64(random));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.TimeSpan" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static TimeSpan GetTimeSpan(Random random, TimeSpan min, TimeSpan max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return new TimeSpan(GetInt64(random, min.Ticks, max.Ticks + 1));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt16" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt16.MinValue" />，小于等于 <see cref="F:System.UInt16.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static ushort GetUInt16(Random random)
	{
		Guard.AssertNotNull(random, "random");
		return (ushort)random.Next(0, 65536);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt32" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	/// 随机数最小值 <paramref name="min" /> 小于 <see cref="F:System.UInt16.MinValue" />，或者大于 <see cref="F:System.UInt16.MaxValue" />；
	/// 随机数最大值 <paramref name="max" /> 小于 <see cref="F:System.UInt16.MinValue" />，或者大于 <see cref="F:System.UInt16.MaxValue" />；
	/// 随机数的最小值 <paramref name="min" /> 大于最大值 <paramref name="max" />。
	/// </exception>
	public static ushort GetUInt16(Random random, int min, int max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertBetween(min, 0, 65535, "min");
		Guard.AssertBetween(max, 0, 65535, "max");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (ushort)random.Next(min, max + 1);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt32" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt32.MinValue" />，小于等于 <see cref="F:System.UInt32.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static uint GetUInt32(Random random)
	{
		Guard.AssertNotNull(random, "random");
		byte[] buff = new byte[4];
		random.NextBytes(buff);
		return ConvertHelper.GetUInt32(buff);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt32" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static uint GetUInt32(Random random, uint min, uint max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = (decimal)(ulong)((long)max - (long)min + 1) * GetDecimal(random);
		return (uint)((decimal)min + delta);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt64" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt64.MinValue" />，小于等于 <see cref="F:System.UInt64.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static ulong GetUInt64(Random random)
	{
		Guard.AssertNotNull(random, "random");
		byte[] buff = new byte[8];
		random.NextBytes(buff);
		return ConvertHelper.GetUInt64(buff);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt64" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于等于最大值 <paramref name="max" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static ulong GetUInt64(Random random, ulong min, ulong max)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertLessThanOrEqualTo(min, max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = ((decimal)max - (decimal)min + 1m) * GetDecimal(random);
		return (ulong)((decimal)min + delta);
	}

	/// <summary>
	/// 获取随机的 <typeparamref name="T" /> 型数值。
	/// </summary>
	/// <typeparam name="T">生成的随机数类型</typeparam>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="creator">根据当前整形随机值创建 <typeparamref name="T" /> 类型数值的方法</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空；或者随机数值生成方法为空。</exception>
	public static T GetValue<T>(Random random, Func<int, T> creator)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertNotNull(creator, "creator");
		return creator(GetInt32(random));
	}

	/// <summary>
	/// 获取随机的 <typeparamref name="T" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <typeparam name="T">生成的随机数类型</typeparam>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <param name="creator">根据当前整形随机值创建 <typeparamref name="T" /> 类型数值的方法</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空；或者随机数值生成方法为空。</exception>
	public static T GetValue<T>(Random random, T min, T max, Func<int, T, T, T> creator)
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertNotNull(creator, "creator");
		return creator(GetInt32(random), min, max);
	}

	/// <summary>
	/// 获取随机的 <typeparamref name="T" /> 型数值；生成的随机数大于等于最小值 <paramref name="min" />，小于最大值 <paramref name="max" />。
	/// </summary>
	/// <typeparam name="T">生成的随机数类型</typeparam>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">生成随机数的最小值</param>
	/// <param name="max">生成随机数的最大值</param>
	/// <param name="provider">格式化提供对象</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机数的最小值大于最大值。</exception>
	public static T GetValue<T>(Random random, T min, T max, IFormatProvider provider = null) where T : IConvertible
	{
		Guard.AssertNotNull(random, "random");
		Guard.AssertNotNull(random, "random");
		decimal baseMin = ConvertHelper.ToDecimal(min, provider);
		decimal baseMax = ConvertHelper.ToDecimal(max, provider);
		Guard.AssertLessThanOrEqualTo(baseMin, baseMax, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = (baseMax - baseMin) * GetDecimal(random);
		return ConvertHelper.ToType<T>(baseMin + delta, provider);
	}
}
