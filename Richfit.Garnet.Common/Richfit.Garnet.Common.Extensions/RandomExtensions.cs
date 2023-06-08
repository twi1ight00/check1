using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.Random" /> 类型扩展方法类
/// </summary>
public static class RandomExtensions
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
		if (localRandom.IsNull())
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
	public static Random GetLocalRandom(this Random random)
	{
		return GetLocalRandom();
	}

	/// <summary>
	/// 枚举随机字母（大写和小写）
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字母序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateAlphabet(this Random random)
	{
		while (true)
		{
			yield return random.GetAlphabet();
		}
	}

	/// <summary>
	/// 枚举随机字母（大写和小写）和数字
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字母和数字序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateAlphabetDigit(this Random random)
	{
		while (true)
		{
			yield return random.GetAlphabetDigit();
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<bool> EnumerateBoolean(this Random random)
	{
		while (true)
		{
			yield return random.GetBoolean();
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
	public static IEnumerable<bool> EnumerateBoolean(this Random random, double trueRatio)
	{
		while (true)
		{
			yield return random.GetBoolean(trueRatio);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Byte" /> 型数值；生成的随机数大于等于 <see cref="F:System.Byte.MinValue" />，小于等于 <see cref="F:System.Byte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<byte> EnumerateByte(this Random random)
	{
		while (true)
		{
			yield return random.GetByte();
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
	public static IEnumerable<byte> EnumerateByte(this Random random, byte min, byte max)
	{
		while (true)
		{
			yield return random.GetByte(min, max);
		}
	}

	/// <summary>
	/// 枚举随机中文字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机中文字符序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateCharacter(this Random random)
	{
		while (true)
		{
			yield return random.GetCharacter();
		}
	}

	/// <summary>
	/// 枚举随机的颜色；获取的随进颜色均为不透明的颜色。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>产生随机的颜色序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<Color> EnumerateColor(this Random random)
	{
		while (true)
		{
			yield return random.GetColor();
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
	public static IEnumerable<Color> EnumerateColor(this Random random, int alpha)
	{
		while (true)
		{
			yield return random.GetColor(alpha);
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
	public static IEnumerable<Color> EnumerateColor(this Random random, Color min, Color max)
	{
		while (true)
		{
			yield return random.GetColor(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.DateTime" /> 型数值；生成的随机数大于等于 <see cref="F:System.DateTime.MinValue" />，小于等于 <see cref="F:System.DateTime.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static DateTime EnumerateDateTime(this Random random)
	{
		bool flag = true;
		return random.GetDateTime();
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
	public static DateTime EnumerateDateTime(this Random random, DateTime min, DateTime max)
	{
		bool flag = true;
		return random.GetDateTime(min, max);
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Decimal" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<decimal> EnumerateDecimal(this Random random)
	{
		while (true)
		{
			yield return random.GetDecimal();
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
	public static IEnumerable<decimal> EnumerateDecimal(this Random random, decimal min, decimal max)
	{
		while (true)
		{
			yield return random.GetDecimal(min, max);
		}
	}

	/// <summary>
	/// 枚举随机十进制数值字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字符序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateDigit(this Random random)
	{
		while (true)
		{
			yield return random.GetDigit();
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Double" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<double> EnumerateDouble(this Random random)
	{
		while (true)
		{
			yield return random.GetDouble();
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
	public static IEnumerable<double> EnumerateDouble(this Random random, double min, double max)
	{
		while (true)
		{
			yield return random.GetDouble(min, max);
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
	public static IEnumerable<T> EnumerateEnum<T>(this Random random)
	{
		while (true)
		{
			yield return random.GetEnum<T>();
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
	public static IEnumerable<object> EnumerateEnum(this Random random, Type type)
	{
		while (true)
		{
			yield return random.GetEnum(type);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<float> EnumerateFloat(this Random random)
	{
		while (true)
		{
			yield return random.GetFloat();
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
	public static IEnumerable<float> EnumerateFloat(this Random random, float min, float max)
	{
		while (true)
		{
			yield return random.GetFloat(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的十六进制数值的字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="upperCase">是否生成大写字母</param>
	/// <returns>生成的随机十六进制数值字符序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<char> EnumerateHex(this Random random, bool upperCase = false)
	{
		while (true)
		{
			yield return random.GetHex(upperCase);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int16" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int16.MinValue" />，小于等于 <see cref="F:System.Int16.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<short> EnumerateInt16(this Random random)
	{
		while (true)
		{
			yield return random.GetInt16();
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
	public static IEnumerable<short> EnumerateInt16(this Random random, short min, short max)
	{
		while (true)
		{
			yield return random.GetInt16(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int32" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int32.MinValue" />，小于等于 <see cref="F:System.Int32.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<int> EnumerateInt32(this Random random)
	{
		while (true)
		{
			yield return random.GetInt32();
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
	public static IEnumerable<int> EnumerateInt32(this Random random, int min, int max)
	{
		while (true)
		{
			yield return random.GetInt32(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Int64" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int64.MinValue" />，小于等于 <see cref="F:System.Int64.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<long> EnumerateInt64(this Random random)
	{
		while (true)
		{
			yield return random.GetInt64();
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
	public static IEnumerable<long> EnumerateInt64(this Random random, long min, long max)
	{
		while (true)
		{
			yield return random.GetInt64(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.SByte" /> 型数值；生成的随机数大于等于 <see cref="F:System.SByte.MinValue" />，小于等于 <see cref="F:System.SByte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<sbyte> EnumerateSByte(this Random random)
	{
		while (true)
		{
			yield return random.GetSByte();
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
	public static IEnumerable<sbyte> EnumerateSByte(this Random random, sbyte min, sbyte max)
	{
		while (true)
		{
			yield return random.GetSByte(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<float> EnumerateSingle(this Random random)
	{
		while (true)
		{
			yield return random.GetSingle();
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
	public static IEnumerable<float> EnumerateSingle(this Random random, float min, float max)
	{
		while (true)
		{
			yield return random.GetSingle(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.TimeSpan" /> 型数值；生成的随机数大于等于 <see cref="F:System.TimeSpan.MinValue" />，小于等于 <see cref="F:System.TimeSpan.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<TimeSpan> EnumerateTimeSpan(this Random random)
	{
		while (true)
		{
			yield return random.GetTimeSpan();
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
	public static IEnumerable<TimeSpan> EnumerateTimeSpan(this Random random, TimeSpan min, TimeSpan max)
	{
		while (true)
		{
			yield return random.GetTimeSpan(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt16" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt16.MinValue" />，小于等于 <see cref="F:System.UInt16.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<ushort> EnumerateUInt16(this Random random)
	{
		while (true)
		{
			yield return random.GetUInt16();
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
	public static IEnumerable<ushort> EnumerateUInt16(this Random random, int min, int max)
	{
		while (true)
		{
			yield return random.GetUInt16(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt32" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt32.MinValue" />，小于等于 <see cref="F:System.UInt32.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<uint> EnumerateUInt32(this Random random)
	{
		while (true)
		{
			yield return random.GetUInt32();
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
	public static IEnumerable<uint> EnumerateUInt32(this Random random, uint min, uint max)
	{
		while (true)
		{
			yield return random.GetUInt32(min, max);
		}
	}

	/// <summary>
	/// 枚举随机的 <see cref="T:System.UInt64" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt64.MinValue" />，小于等于 <see cref="F:System.UInt64.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static IEnumerable<ulong> EnumerateUInt64(this Random random)
	{
		while (true)
		{
			yield return random.GetUInt64();
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
	public static IEnumerable<ulong> EnumerateUInt64(this Random random, ulong min, ulong max)
	{
		while (true)
		{
			yield return random.GetUInt64(min, max);
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
	public static IEnumerable<T> EnumerateValue<T>(this Random random, Func<int, T> creator)
	{
		while (true)
		{
			yield return random.GetValue(creator);
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
	public static IEnumerable<T> EnumerateValue<T>(this Random random, T min, T max, Func<int, T, T, T> creator)
	{
		while (true)
		{
			yield return random.GetValue(min, max, creator);
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
	public static IEnumerable<T> EnumerateValue<T>(this Random random, T min, T max, IFormatProvider provider = null) where T : IConvertible
	{
		while (true)
		{
			yield return random.GetValue(min, max, provider);
		}
	}

	/// <summary>
	/// 获取随机字母（大写和小写）
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字母</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetAlphabet(this Random random)
	{
		random.GuardNotNull("random");
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
	public static string GetAlphabetText(this Random random, int count)
	{
		random.GuardNotNull("random");
		count.GuardGreaterThanOrEqualTo(0, "count");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(random.GetAlphabet());
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机字母（大写和小写）和数字
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字母和数字</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetAlphabetDigit(this Random random)
	{
		random.GuardNotNull("random");
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
	public static string GetAlphabetDigitText(this Random random, int count)
	{
		random.GuardNotNull("random");
		count.GuardGreaterThanOrEqualTo(0, "count");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(random.GetAlphabetDigit());
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Boolean" /> 型数值
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static bool GetBoolean(this Random random)
	{
		random.GuardNotNull("random");
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
	public static bool GetBoolean(this Random random, double ratio)
	{
		random.GuardNotNull("random");
		ratio.GuardBetween(0.0, 1.0, "ratio");
		return random.NextDouble() <= ratio;
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Byte" /> 型数值；生成的随机数大于等于 <see cref="F:System.Byte.MinValue" />，小于等于 <see cref="F:System.Byte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static byte GetByte(this Random random)
	{
		random.GuardNotNull("random");
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
	public static byte GetByte(this Random random, int min, int max)
	{
		random.GuardNotNull("random");
		min.GuardBetween(0, 255, "min");
		max.GuardBetween(0, 255, "max");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
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
	public static byte[] GetByteArray(this Random random, int count)
	{
		random.GuardNotNull("randon");
		count.GuardGreaterThanOrEqualTo(0, "count");
		byte[] buff = new byte[count];
		for (int i = 0; i < buff.Length; i++)
		{
			buff[i] = random.GetByte();
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
	public static byte[] GetByteArray(this Random random, int count, byte min, byte max)
	{
		random.GuardNotNull("randon");
		count.GuardGreaterThanOrEqualTo(0, "count");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		byte[] buff = new byte[count];
		for (int i = 0; i < buff.Length; i++)
		{
			buff[i] = random.GetByte(min, max);
		}
		return buff;
	}

	/// <summary>
	/// 获取随机中文字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机中文字符</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetCharacter(this Random random)
	{
		random.GuardNotNull("random");
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
	public static string GetCharacterText(this Random random, int count)
	{
		random.GuardNotNull("random");
		count.GuardGreaterThanOrEqualTo(0, "length");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(random.GetCharacter());
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机的颜色；获取的随进颜色均为不透明的颜色。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>产生随机的颜色</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static Color GetColor(this Random random)
	{
		return random.GetColor(255);
	}

	/// <summary>
	/// 获取随机的颜色；获取的随进颜色均为不透明的颜色。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="alpha">随机颜色的Alpha分量</param>
	/// <returns>产生随机的颜色</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">随机颜色的Alpha分量 <paramref name="alpha" /> 小于0，或者大于255。</exception>
	public static Color GetColor(this Random random, int alpha)
	{
		random.GuardNotNull("random");
		alpha.GuardBetween(0, 255, "alpha");
		return Color.FromArgb(alpha, random.GetByte(), random.GetByte(), random.GetByte());
	}

	/// <summary>
	/// 获取随机的颜色
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="min">随机范围的起始颜色</param>
	/// <param name="max">随机范围的结束颜色</param>
	/// <returns>产生随机的颜色</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static Color GetColor(this Random random, Color min, Color max)
	{
		random.GuardNotNull("random");
		return Color.FromArgb(random.GetByte(Math.Min(min.A, max.A), Math.Max(min.A, max.A)), random.GetByte(Math.Min(min.R, max.R), Math.Max(min.R, max.R)), random.GetByte(Math.Min(min.G, max.G), Math.Max(min.G, max.G)), random.GetByte(Math.Min(min.B, max.B), Math.Max(min.B, max.B)));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.DateTime" /> 型数值；生成的随机数大于等于 <see cref="F:System.DateTime.MinValue" />，小于等于 <see cref="F:System.DateTime.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static DateTime GetDateTime(this Random random)
	{
		random.GuardNotNull("random");
		return new DateTime(random.GetInt64());
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
	public static DateTime GetDateTime(this Random random, DateTime min, DateTime max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return new DateTime(random.GetInt64(min.Ticks, max.Ticks + 1));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Decimal" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static decimal GetDecimal(this Random random)
	{
		random.GuardNotNull("random");
		byte[] buff = new byte[12];
		random.NextBytes(buff);
		decimal value = new decimal(new int[4]
		{
			buff.GetInt32(),
			buff.GetInt32(4),
			buff.GetInt32(8),
			new byte[4] { 0, 0, 28, 0 }.GetInt32()
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
	public static decimal GetDecimal(this Random random, decimal min, decimal max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = (max - min) * random.GetDecimal();
		return min + delta;
	}

	/// <summary>
	/// 获取随机十进制数值字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机字符串</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetDigit(this Random random)
	{
		random.GuardNotNull("random");
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
	public static string GetDigitText(this Random random, int count)
	{
		random.GuardNotNull("random");
		count.GuardGreaterThanOrEqualTo(0, "count");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(random.GetDigit());
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Double" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static double GetDouble(this Random random)
	{
		random.GuardNotNull("random");
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
	public static double GetDouble(this Random random, double min, double max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		double delta = (max - min) * random.GetDouble();
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
	public static T GetEnum<T>(this Random random)
	{
		return (T)random.GetEnum(typeof(T));
	}

	/// <summary>
	/// 获取随机的 <paramref name="type" /> 类型的枚举值
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="type">枚举类型</param>
	/// <returns>产生的随机枚举值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空；或者枚举类型 <paramref name="type" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">指定的类型 <paramref name="type" /> 不是枚举类型。</exception>
	public static object GetEnum(this Random random, Type type)
	{
		random.GuardNotNull("random");
		type.GuardNotNull("enum type");
		type.Guard(type.IsEnum, () => new NotSupportedException(Literals.MSG_TypeNotEnum_1.FormatValue(type.FullName)));
		Array values = Enum.GetValues(type);
		return values.GetValue(values.GetLowerBound(0) + random.Next(0, values.Length));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static float GetFloat(this Random random)
	{
		return random.GetSingle();
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
	public static float GetFloat(this Random random, float min, float max)
	{
		return random.GetSingle(min, max);
	}

	/// <summary>
	/// 获取随机的十六进制数值的字符
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <param name="upperCase">是否生成大写字母</param>
	/// <returns>生成的随机十六进制数值字符</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static char GetHex(this Random random, bool upperCase = false)
	{
		random.GuardNotNull("random");
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
	public static string GetHexText(this Random random, int count, bool upperCase = false)
	{
		random.GuardNotNull("random");
		count.GuardGreaterThanOrEqualTo(0, "count");
		StringBuilder buff = new StringBuilder(count);
		while (buff.Length < count)
		{
			buff.Append(random.GetHex(upperCase));
		}
		return buff.ToString();
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int16" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int16.MinValue" />，小于等于 <see cref="F:System.Int16.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static short GetInt16(this Random random)
	{
		random.GuardNotNull("random");
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
	public static short GetInt16(this Random random, int min, int max)
	{
		random.GuardNotNull("random");
		min.GuardBetween(-128, 127, "min");
		max.GuardBetween(-128, 127, "max");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (short)random.Next(min, max + 1);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int32" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int32.MinValue" />，小于等于 <see cref="F:System.Int32.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static int GetInt32(this Random random)
	{
		random.GuardNotNull("random");
		byte[] buff = new byte[4];
		random.NextBytes(buff);
		return buff.GetInt32();
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
	public static int GetInt32(this Random random, int min, int max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = ((decimal)max - (decimal)min + 1m) * random.GetDecimal();
		return (int)((decimal)min + delta);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Int64" /> 型数值；生成的随机数大于等于 <see cref="F:System.Int64.MinValue" />，小于等于 <see cref="F:System.Int64.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static long GetInt64(this Random random)
	{
		random.GuardNotNull("random");
		byte[] buff = new byte[8];
		random.NextBytes(buff);
		return buff.GetInt64();
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
	public static long GetInt64(this Random random, long min, long max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = ((decimal)max - (decimal)min + 1m) * random.GetDecimal();
		return (long)((decimal)min + delta);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.SByte" /> 型数值；生成的随机数大于等于 <see cref="F:System.SByte.MinValue" />，小于等于 <see cref="F:System.SByte.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static sbyte GetSByte(this Random random)
	{
		random.GuardNotNull("random");
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
	public static sbyte GetSByte(this Random random, int min, int max)
	{
		random.GuardNotNull("random");
		min.GuardBetween(-128, 127, "min");
		max.GuardBetween(-128, 127, "max");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (sbyte)random.Next(min, max + 1);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.Single" /> 型数值；生成的随机数大于等于0，小于1。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static float GetSingle(this Random random)
	{
		return (float)random.GetDouble();
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
	public static float GetSingle(this Random random, float min, float max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		double delta = (double)(max - min) * random.GetDouble();
		return (float)((double)min + delta);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.TimeSpan" /> 型数值；生成的随机数大于等于 <see cref="F:System.TimeSpan.MinValue" />，小于等于 <see cref="F:System.TimeSpan.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static TimeSpan GetTimeSpan(this Random random)
	{
		random.GuardNotNull("random");
		return new TimeSpan(random.GetInt64());
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
	public static TimeSpan GetTimeSpan(this Random random, TimeSpan min, TimeSpan max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return new TimeSpan(random.GetInt64(min.Ticks, max.Ticks + 1));
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt16" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt16.MinValue" />，小于等于 <see cref="F:System.UInt16.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static ushort GetUInt16(this Random random)
	{
		random.GuardNotNull("random");
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
	public static ushort GetUInt16(this Random random, int min, int max)
	{
		random.GuardNotNull("random");
		min.GuardBetween(0, 65535, "min");
		max.GuardBetween(0, 65535, "max");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (ushort)random.Next(min, max + 1);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt32" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt32.MinValue" />，小于等于 <see cref="F:System.UInt32.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static uint GetUInt32(this Random random)
	{
		random.GuardNotNull("random");
		byte[] buff = new byte[4];
		random.NextBytes(buff);
		return buff.GetUInt32();
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
	public static uint GetUInt32(this Random random, uint min, uint max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = (decimal)(ulong)((long)max - (long)min + 1) * random.GetDecimal();
		return (uint)((decimal)min + delta);
	}

	/// <summary>
	/// 获取随机的 <see cref="T:System.UInt64" /> 型数值；生成的随机数大于等于 <see cref="F:System.UInt64.MinValue" />，小于等于 <see cref="F:System.UInt64.MaxValue" />。
	/// </summary>
	/// <param name="random">当前随机数生成器</param>
	/// <returns>生成的随机数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前随机数生成器为空。</exception>
	public static ulong GetUInt64(this Random random)
	{
		random.GuardNotNull("random");
		byte[] buff = new byte[8];
		random.NextBytes(buff);
		return buff.GetUInt64();
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
	public static ulong GetUInt64(this Random random, ulong min, ulong max)
	{
		random.GuardNotNull("random");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = ((decimal)max - (decimal)min + 1m) * random.GetDecimal();
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
	public static T GetValue<T>(this Random random, Func<int, T> creator)
	{
		random.GuardNotNull("random");
		creator.GuardNotNull("creator");
		return creator(random.GetInt32());
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
	public static T GetValue<T>(this Random random, T min, T max, Func<int, T, T, T> creator)
	{
		random.GuardNotNull("random");
		creator.GuardNotNull("creator");
		return creator(random.GetInt32(), min, max);
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
	public static T GetValue<T>(this Random random, T min, T max, IFormatProvider provider = null) where T : IConvertible
	{
		random.GuardNotNull("random");
		random.GuardNotNull("random");
		decimal baseMin = min.ConvertToDecimal(provider);
		decimal baseMax = max.ConvertToDecimal(provider);
		baseMin.GuardLessThanOrEqualTo(baseMax, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		decimal delta = (baseMax - baseMin) * random.GetDecimal();
		return (baseMin + delta).ConvertToType<T>(provider);
	}
}
