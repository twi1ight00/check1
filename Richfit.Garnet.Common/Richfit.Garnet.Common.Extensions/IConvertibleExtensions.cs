using System;
using System.Collections.Generic;
using System.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// IConvertible接口扩展方法类
/// </summary>
public static class IConvertibleExtensions
{
	/// <summary>
	/// 将当前摄氏温度转华氏温度
	/// </summary>
	/// <typeparam name="T">温度数值类型</typeparam>
	/// <param name="temperature">当前摄氏温度</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>华氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static T CelsiusToFahrenheit<T>(this T temperature, IFormatProvider provider = null) where T : IConvertible
	{
		temperature.GuardNotNull("temperature");
		return (temperature.ConvertToDecimal(provider) * 9m / 5m + 32m).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 当前摄氏温度转热力学温度
	/// </summary>
	/// <typeparam name="T">温度数值类型</typeparam>
	/// <param name="temperature">当前摄氏温度</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>热力学温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static T CelsiusToKelvin<T>(this T temperature, IFormatProvider provider = null) where T : IConvertible
	{
		temperature.GuardNotNull("temperature");
		return (temperature.ConvertToDecimal(provider) + 273.15m).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 当前华氏温度转摄氏温度
	/// </summary>
	/// <typeparam name="T">温度数值类型</typeparam>
	/// <param name="temperature">当前华氏温度</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>摄氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static T FahrenheitToCelsius<T>(this T temperature, IFormatProvider provider = null) where T : IConvertible
	{
		temperature.GuardNotNull("temperature");
		return ((temperature.ConvertToDecimal(provider) - 32m) * 5m / 9m).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 当前华氏温度转热力学温度
	/// </summary>
	/// <typeparam name="T">温度数值类型</typeparam>
	/// <param name="temperature">当前华氏温度</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>热力学温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static T FahrenheitToKelvin<T>(this T temperature, IFormatProvider provider = null) where T : IConvertible
	{
		temperature.GuardNotNull("temperature");
		return ((temperature.ConvertToDecimal(provider) + 459.67m) * 5m / 9m).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 当前热力学温度转摄氏温度
	/// </summary>
	/// <typeparam name="T">温度数值类型</typeparam>
	/// <param name="temperature">当前热力学温度</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>摄氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static T KelvinToCelsius<T>(this T temperature, IFormatProvider provider = null) where T : IConvertible
	{
		temperature.GuardNotNull("temperature");
		return (temperature.ConvertToDecimal(provider) - 273.15m).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 当前热力学温度转华氏温度
	/// </summary>
	/// <typeparam name="T">温度数值类型</typeparam>
	/// <param name="temperature">当前热力学温度</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>华氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static T KelvinToFahrenheit<T>(this T temperature, IFormatProvider provider = null) where T : IConvertible
	{
		temperature.GuardNotNull("temperature");
		return (temperature.ConvertToDecimal(provider) * 9m / 5m - 459.67m).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的绝对值
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Abs<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Abs(value.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前余弦值的反余弦值（弧度）
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前余弦值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Acos<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Acos(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前正弦值的反正弦值（弧度）
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前正弦值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Asin<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Asin(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前正切值的反正切值（弧度）
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前正切值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Atan<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Atan(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="values">当前的值序列</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static T Average<T>(this IEnumerable<T> values, IFormatProvider provider = null) where T : IConvertible
	{
		values.GuardNotNull("values");
		return values.Where((T x) => x.IsNotNull()).Average((T x) => x.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算大于或等于当前数值的最小整数
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Ceiling<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return decimal.Ceiling(value.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的余弦值
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值（弧度）</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Cos<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Cos(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的双曲余弦值
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值（弧度）</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Cosh<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Cosh(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值整除目标数值的商（整数）
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="target">目标数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者目标数值为空。</exception>
	public static T Div<T>(this T value, T target, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		return decimal.Truncate(value.ConvertToDecimal(provider) / target.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算以当前数值为指数的 <b>e</b> 的指定次数幂
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Exp<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Exp(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的阶乘
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">计算阶乘的当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前数值小于0。</exception>
	public static T Factorial<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		decimal baseValue = value.ConvertToDecimal(provider);
		baseValue.GuardGreaterThanOrEqualTo(0m, "value");
		decimal result = 1m;
		for (decimal x = 2m; x <= baseValue; ++x)
		{
			result *= x;
		}
		return result.ConvertToType<T>(provider);
	}

	/// <summary>
	/// 向当前数组的各个元素中填充该元素相应的索引
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待填充的数组</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] FillIndex<T>(this T[] array, IFormatProvider provider = null) where T : IConvertible
	{
		array.GuardNotNull("array");
		for (long i = 0L; i < array.LongLength; i++)
		{
			array[i] = i.ConvertToType<T>(provider);
		}
		return array;
	}

	/// <summary>
	/// 向当前数组的各个元素中填充该元素相应的序号
	/// </summary>
	/// <typeparam name="T">当前数组元素类型</typeparam>
	/// <param name="array">当前待填充的数组</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>填充后的数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static T[] FillNo<T>(this T[] array, IFormatProvider provider = null) where T : IConvertible
	{
		array.GuardNotNull("array");
		for (long i = 0L; i < array.LongLength; i++)
		{
			array[i] = (i + 1).ConvertToType<T>(provider);
		}
		return array;
	}

	/// <summary>
	/// 将当前数值的有效数字的数量（精度）限制为指定数量
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="precision">缩减的目标有效数字数量（精度）</param>
	/// <param name="rounding">截断有效数字时是否进行四舍五入</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">有效数字（精度）<paramref name="precision" /> 小于1。</exception>
	public static T Fix<T>(this T value, int precision, bool rounding = true, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		precision.GuardGreaterThanOrEqualTo(1, "precision");
		decimal baseValue = value.ConvertToDecimal(provider);
		int exponent = baseValue.GetExponent(provider);
		if (exponent > 0)
		{
			decimal factor = 10m.Pow(exponent);
			baseValue /= factor;
			baseValue = (rounding ? baseValue.Round(precision - 1, provider) : baseValue.Truncate(precision - 1, provider));
			decimal result = baseValue * factor;
		}
		else if (exponent < 0)
		{
			decimal factor = 10m.Pow(-exponent);
			baseValue *= factor;
			baseValue = (rounding ? baseValue.Round(precision - 1, provider) : baseValue.Truncate(precision - 1, provider));
			decimal result = baseValue / factor;
		}
		else
		{
			baseValue = (rounding ? baseValue.Round(precision - 1, provider) : baseValue.Truncate(precision - 1, provider));
			decimal result = baseValue;
		}
		return baseValue.ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算小于或等于当前数值的最大整数
	/// </summary>
	/// <typeparam name="T">数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Floor<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return decimal.Floor(value.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 获取当前数值的小数部分
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>当前数值的小数部分</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T GetDecimal<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		decimal baseValue = value.ConvertToDecimal(provider);
		return (baseValue - decimal.Truncate(baseValue)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 获取将当前数值使用科学记数法表示时的指数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>当前数值的科学计数法指数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static int GetExponent(this IConvertible value, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		double baseValue = value.ConvertToDouble(provider);
		if (baseValue > 0.0)
		{
			return (int)Math.Floor(Math.Log10(baseValue));
		}
		if (baseValue < 0.0)
		{
			return (int)Math.Floor(Math.Log10(Math.Abs(baseValue)));
		}
		return 0;
	}

	/// <summary>
	/// 获取当前数值的整数部分
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>当前数值的整数部分</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T GetInteger<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		return decimal.Truncate(value.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 获取数值精度（有效数字的个数）
	/// </summary>
	/// <param name="value">源数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>数值的精度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static int GetPrecision(this IConvertible value, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		decimal baseValue = Math.Abs(value.ConvertToDecimal(provider));
		int count = 0;
		decimal integer = decimal.Truncate(baseValue);
		decimal decimals = baseValue - integer;
		for (; integer >= 1m; integer /= 10m)
		{
			count++;
		}
		for (; decimals < 1m; decimals -= decimal.Truncate(decimals))
		{
			count++;
			decimals *= 10m;
		}
		return count;
	}

	/// <summary>
	/// 比较当前数值和目标数值是否相等，如果两个数值之间的偏差小于指定的数量级，则认为相等
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则两个数值必须严格相等</param>
	/// <param name="delta">误差增量</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值等于目标值或者偏差小于指定值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsEqualTo(this IConvertible value, IConvertible target, int level = -15, int delta = 1, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		delta.GuardGreaterThanOrEqualTo(1, "delta");
		if (level == 0)
		{
			return value.ConvertToDecimal(provider) == target.ConvertToDecimal(provider);
		}
		return value.IsEqualTo(target, 10m.Pow((level > 0) ? (level - 1) : level) * (decimal)delta, provider);
	}

	/// <summary>
	/// 比较当前数值和目标数值是否相等，如果两个数值之间的偏差小于指定值，则视为相等
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值等于目标值或者偏差小于指定值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空；或者比较误差为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsEqualTo(this IConvertible value, IConvertible target, IConvertible deviation, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		deviation.GuardNotNull("deviation");
		decimal baseValue = value.ConvertToDecimal(provider);
		decimal baseTarget = target.ConvertToDecimal(provider);
		decimal baseDeviation = deviation.ConvertToDecimal(provider);
		baseDeviation.GuardGreaterThanOrEqualTo(0m, "deviation");
		return (baseValue - baseTarget).Abs() < baseDeviation;
	}

	/// <summary>
	/// 判断当前数值是否是偶数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值是偶数返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static bool IsEven(this IConvertible value, IFormatProvider provider = null)
	{
		return decimal.Remainder(value.ConvertToDecimal(provider), 2m) == 0m;
	}

	/// <summary>
	/// 判断当前数值是否大于目标值，如果指定值与目标值的偏差大于等于指定的数量级才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格大于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值大于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsGreaterThan(this IConvertible value, IConvertible target, int level = -15, int delta = 1, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		delta.GuardGreaterThanOrEqualTo(1, "delta");
		if (level == 0)
		{
			return value.ConvertToDecimal(provider) > target.ConvertToDecimal(provider);
		}
		return value.IsGreaterThan(target, 10m.Pow((level > 0) ? (level - 1) : level) * (decimal)delta, provider);
	}

	/// <summary>
	/// 判断当前数值是否大于目标值，如果指定值与目标值的偏差大于等于指定值才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值大于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空；或者比较误差为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsGreaterThan(this IConvertible value, IConvertible target, IConvertible deviation, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		deviation.GuardNotNull("deviation");
		decimal baseValue = value.ConvertToDecimal(provider);
		decimal baseTarget = target.ConvertToDecimal(provider);
		decimal baseDeviation = deviation.ConvertToDecimal(provider);
		baseDeviation.GuardGreaterThanOrEqualTo(0m, "deviation");
		decimal diff = baseValue - baseTarget;
		return diff >= baseDeviation;
	}

	/// <summary>
	/// 判断当前数值是否大于或者等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格大于或者等于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值大于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsGreaterThanOrEqualTo(this IConvertible value, IConvertible target, int level = -15, int delta = 1, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		delta.GuardGreaterThanOrEqualTo(1, "delta");
		if (level == 0)
		{
			return value.ConvertToDecimal(provider) > target.ConvertToDecimal(provider);
		}
		return value.IsGreaterThanOrEqualTo(target, 10m.Pow((level > 0) ? (level - 1) : level) * (decimal)delta, provider);
	}

	/// <summary>
	/// 判断当前数值是否大于或者等于目标值；如果两个数值的误差小于指定值，则认为相等；如果指定值与目标值的偏差大于等于指定值才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值大于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空；或者比较误差为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsGreaterThanOrEqualTo(this IConvertible value, IConvertible target, IConvertible deviation, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		deviation.GuardNotNull("deviation");
		decimal baseValue = value.ConvertToDecimal(provider);
		decimal baseTarget = target.ConvertToDecimal(provider);
		decimal baseDeviation = deviation.ConvertToDecimal(provider);
		baseDeviation.GuardGreaterThanOrEqualTo(0m, "deviation");
		decimal diff = baseValue - baseTarget;
		return Math.Abs(diff) < baseDeviation || diff >= baseDeviation;
	}

	/// <summary>
	/// 判断当前数值是否小于目标值，如果指定值与目标值的偏差大于等于指定值才成立
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格小于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值小于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsLessThan(this IConvertible value, IConvertible target, int level = -15, int delta = 1, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		delta.GuardGreaterThanOrEqualTo(1, "delta");
		if (level == 0)
		{
			return value.ConvertToDecimal(provider) < target.ConvertToDecimal(provider);
		}
		return value.IsLessThan(target, 10m.Pow((level > 0) ? (level - 1) : level) * (decimal)delta, provider);
	}

	/// <summary>
	/// 判断当前数值是否小于目标值，如果指定值与目标值的偏差大于等于指定值才成立
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值小于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空；或者比较误差为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsLessThan(this IConvertible value, IConvertible target, IConvertible deviation, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		deviation.GuardNotNull("deviation");
		decimal baseValue = value.ConvertToDecimal(provider);
		decimal baseTarget = target.ConvertToDecimal(provider);
		decimal baseDeviation = deviation.ConvertToDecimal(provider);
		baseDeviation.GuardGreaterThanOrEqualTo(0m, "deviation");
		decimal diff = baseValue - baseTarget;
		return diff <= -baseDeviation;
	}

	/// <summary>
	/// 判断当前数值是否小于等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为小于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格小于等于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值小于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsLessThanOrEqualTo(this IConvertible value, IConvertible target, int level = -15, int delta = 1, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		delta.GuardGreaterThanOrEqualTo(1, "delta");
		if (level == 0)
		{
			return value.ConvertToDecimal(provider) < target.ConvertToDecimal(provider);
		}
		return value.IsLessThanOrEqualTo(target, 10m.Pow((level > 0) ? (level - 1) : level) * (decimal)delta, provider);
	}

	/// <summary>
	/// 判断当前数值是否小于等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为小于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果当前数值小于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者比较的目标数值为空；或者比较误差为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsLessThanOrEqualTo(this IConvertible value, IConvertible target, IConvertible deviation, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		deviation.GuardNotNull("deviation");
		decimal baseValue = value.ConvertToDecimal(provider);
		decimal baseTarget = target.ConvertToDecimal(provider);
		decimal baseDeviation = deviation.ConvertToDecimal(provider);
		baseDeviation.GuardGreaterThanOrEqualTo(0m, "deviation");
		decimal diff = baseValue - baseTarget;
		return Math.Abs(diff) < baseDeviation || diff <= -baseDeviation;
	}

	/// <summary>
	/// 判断当前数值是否是奇数
	/// </summary>
	/// <param name="value">当前待检测的数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>如果是奇数返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static bool IsOdd(this IConvertible value, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		return decimal.Remainder(value.ConvertToDecimal(provider), 2m) != 0m;
	}

	/// <summary>
	/// 计算以 <b>e</b> 为底的当前数值的对数（自然对数）
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Ln<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Log(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算以指定数值为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="logBase">对数的底，默认为10。</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Log<T>(this T value, int logBase, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Log(value.ConvertToDouble(provider), logBase).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算以指定数值为底的当前数值的对数
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="logBase">对数的底</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Log<T>(this T value, decimal logBase, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Log(value.ConvertToDouble(provider), (double)logBase).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算以10为底的当前数值的对数
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Log10<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Log10(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的指定次幂
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="n">乘幂的次数</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">乘幂的次数 <paramref name="n" /> 小于0。</exception>
	public static T Pow<T>(this T value, int n, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		n.GuardGreaterThanOrEqualTo(0, "n");
		decimal result = 1m;
		decimal baseValue = value.ConvertToDecimal(provider);
		while (n-- > 0)
		{
			result *= baseValue;
		}
		return result.ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的指定次幂
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="n">乘幂的次数</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Pow<T>(this T value, decimal n, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Pow(value.ConvertToDouble(provider), (double)n).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的倒数
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Reciproc<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return (1m / value.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值除以目标值后的余数
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="target">目标数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>余数</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空；或者目标数值为空。</exception>
	public static T Rem<T>(this T value, T target, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		target.GuardNotNull("target");
		decimal baseValue = value.ConvertToDecimal(provider);
		decimal baseTarget = target.ConvertToDecimal(provider);
		return decimal.Remainder(baseValue, baseTarget).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的指定次数的方根
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="n">开方的次数</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Root<T>(this T value, int n, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Pow(value.ConvertToDouble(provider), 1.0 / (double)n).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的指定次数的方根
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="n">开方的次数</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Root<T>(this T value, decimal n, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Pow(value.ConvertToDouble(provider), (double)(1m / n)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 将当前数值四舍五入到最接近的整数
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Round<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return decimal.Round(value.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 将当前数值按指定的小数位数进行舍入
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="decimals">保留小数的位数，范围是0到28。</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="decimals" /> 小于0，或者大于28。</exception>
	public static T Round<T>(this T value, int decimals, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		decimals.GuardBetween(0, 28, "decimals");
		return decimal.Round(value.ConvertToDecimal(provider), decimals).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 获取当前数值的符号
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>当前数值的符号；如果当前数值大于0，返回1；如果当前数值小于0，返回-1。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static int Sign(this IConvertible value, IFormatProvider provider = null)
	{
		value.GuardNotNull("value");
		return Math.Sign(value.ConvertToDecimal(provider));
	}

	/// <summary>
	/// 计算当前数值的正弦值
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值（弧度）</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Sin<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Sin(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的双曲正弦值
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam> 
	/// <param name="value">当前数值（弧度）</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Sinh<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Sinh(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 将当前数值分解为整数和小数部分
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam> 
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>分解后的两个元素的数组，第一个元素为整数部分，第二个元素为小数部分</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception> 
	public static T[] SplitNumber<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return new T[2]
		{
			value.GetInteger(provider),
			value.GetDecimal(provider)
		};
	}

	/// <summary>
	/// 计算当前数值的平方根
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Sqrt<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Sqrt(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="values">当前数值序列</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值列表为空。</exception>
	public static T StdDev<T>(this IEnumerable<T> values, IFormatProvider provider = null) where T : IConvertible
	{
		values.GuardNotNull("values");
		return values.Var(provider).Sqrt(provider);
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <typeparam name="T">当前值序列元素类型</typeparam>
	/// <param name="values">当前的值序列</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static T Sum<T>(this IEnumerable<T> values, IFormatProvider provider = null) where T : IConvertible
	{
		values.GuardNotNull("values");
		return values.Where((T x) => x.IsNotNull()).Sum((T x) => x.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的正切值
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值（弧度）</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Tan<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Tan(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值的双曲正切值
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值（弧度）</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Tanh<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return Math.Tanh(value.ConvertToDouble(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 截断当前数值，返回整数部分
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>当前数值的整数部分</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	public static T Truncate<T>(this T value, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		return decimal.Truncate(value.ConvertToDecimal(provider)).ConvertToType<T>(provider);
	}

	/// <summary>
	/// 将当前数值进行截断，保留指定位数的小数；截断不进行四舍五入
	/// </summary>
	/// <typeparam name="T">当前数值类型</typeparam>
	/// <param name="value">当前数值</param>
	/// <param name="decimals">保留的小数的位数，范围0到28。</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>截断后的数值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保留的小数位数 <paramref name="decimals" /> 小于0，或者大于28。</exception>
	public static T Truncate<T>(this T value, int decimals, IFormatProvider provider = null) where T : IConvertible
	{
		value.GuardNotNull("value");
		decimals.GuardBetween(0, 28, "decimals");
		decimal baseValue = value.ConvertToDecimal(provider);
		decimal integer = decimal.Truncate(baseValue);
		decimal result = 0m;
		if (decimals == 0)
		{
			result = integer;
		}
		else
		{
			decimal factor = 10m.Pow(decimals);
			result = integer + decimal.Truncate((baseValue - integer) * factor) / factor;
		}
		return result.ConvertToType<T>(provider);
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <typeparam name="T">当前序列元素类型</typeparam>
	/// <param name="values">当前数值序列</param>
	/// <param name="provider">格式化控制对象，可以为 <see cref="T:System.Globalization.CultureInfo" />、<see cref="T:System.Globalization.NumberFormatInfo" />、<see cref="T:System.Globalization.DateTimeFormatInfo" />等内置对象，或者自定义的对象。</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static T Var<T>(this IEnumerable<T> values, IFormatProvider provider = null) where T : IConvertible
	{
		values.GuardNotNull("values");
		if (!values.Any())
		{
			return 0.ConvertToType<T>(provider);
		}
		IEnumerable<decimal> baseValues = from v in values
			where v.IsNotNull()
			select v.ConvertToDecimal(provider);
		if (!baseValues.Any())
		{
			return 0.ConvertToType<T>(provider);
		}
		decimal avgValue = 0m;
		int count = 0;
		baseValues.ForEach(delegate(decimal v)
		{
			avgValue += v;
			count++;
		});
		avgValue /= (decimal)count;
		decimal sum = 0m;
		baseValues.ForEach(delegate(decimal v)
		{
			sum += (v - avgValue) * (v - avgValue);
		});
		sum /= (decimal)count;
		return sum.ConvertToType<T>(provider);
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
	public static bool ConvertToBoolean(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
				if (s.EqualOrdinal("true", ignoreCase: true))
				{
					return true;
				}
				if (s.EqualOrdinal("false", ignoreCase: true))
				{
					return false;
				}
				break;
			}
			case TypeCode.DateTime:
				return ((DateTime)(object)value).IsNotDefault();
			default:
				return Convert.ToBoolean(value, provider);
			}
			throw new NotSupportedException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(bool).FullName));
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(bool).FullName), ex);
		}
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
	public static byte ConvertToByte(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(byte).FullName), ex);
		}
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
	public static char ConvertToChar(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(char).FullName), ex);
		}
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
	public static DateTime ConvertToDateTime(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
				throw new NotSupportedException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(DateTime).FullName));
			}
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(DateTime).FullName), ex);
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
	public static decimal ConvertToDecimal(this IConvertible value, IFormatProvider provider = null)
	{
		if (!value.IsNull())
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
				throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(decimal).FullName), ex);
			}
		}
		return 0m;
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
	public static double ConvertToDouble(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(double).FullName), ex);
		}
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
	public static object ConvertToEnum(this IConvertible value, Type type, IFormatProvider provider = null)
	{
		type.GuardNotNull("type");
		type.Guard(type.IsEnum, () => new NotSupportedException(Literals.MSG_TypeNotEnum_1.FormatValue(type.FullName)));
		if (value.IsNull())
		{
			return Enum.ToObject(type, 0);
		}
		try
		{
			Type valueType = value.GetType();
			if (valueType.IsNumeric() || valueType == typeof(bool))
			{
				return Enum.ToObject(type, Convert.ToInt64(value, provider));
			}
			return Enum.Parse(type, value.ToString(), ignoreCase: true);
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), type.FullName), ex);
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
	public static T ConvertToEnum<T>(this IConvertible value, IFormatProvider provider = null) where T : struct
	{
		return (T)value.ConvertToEnum(typeof(T), provider);
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
	/// <seealso cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToSingle(System.IConvertible,System.IFormatProvider)" />
	public static float ConvertToFloat(this IConvertible value, IFormatProvider provider = null)
	{
		return value.ConvertToSingle(provider);
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
	public static short ConvertToInt16(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(short).FullName), ex);
		}
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
	public static int ConvertToInt32(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(int).FullName), ex);
		}
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
	public static long ConvertToInt64(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(long).FullName), ex);
		}
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
	/// 2. 根据 <see cref="P:System.IntPtr.Size" /> 属性值的不同，调用 <see cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToInt32(System.IConvertible,System.IFormatProvider)" /> 或者 <see cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToInt64(System.IConvertible,System.IFormatProvider)" /> 转换当前值。
	/// </remarks>
	public static IntPtr ConvertToIntPtr(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(IntPtr).FullName), ex);
		}
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
	public static sbyte ConvertToSByte(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(sbyte).FullName), ex);
		}
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
	public static float ConvertToSingle(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(float).FullName), ex);
		}
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
	public static string ConvertToString(this IConvertible value, IFormatProvider provider)
	{
		if (value.IsNull())
		{
			return null;
		}
		try
		{
			return Convert.ToString(value, provider);
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(string).FullName), ex);
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
	public static TimeSpan ConvertToTimeSpan(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
				return TimeSpan.Parse(value.As<string>(), provider);
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
				throw new NotSupportedException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(TimeSpan).FullName));
			}
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(TimeSpan).FullName), ex);
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
	public static object ConvertToType(this IConvertible value, Type type, IFormatProvider provider = null)
	{
		type.GuardNotNull("type");
		if (value.IsNull())
		{
			return type.CreateInstance();
		}
		try
		{
			return Convert.ChangeType(value, type, provider);
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), type.FullName), ex);
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
	public static T ConvertToType<T>(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
		{
			return default(T);
		}
		try
		{
			return Convert.ChangeType(value, typeof(T), provider).As<T>();
		}
		catch (Exception ex)
		{
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(T).FullName), ex);
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
	public static ushort ConvertToUInt16(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(ushort).FullName), ex);
		}
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
	public static uint ConvertToUInt32(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(uint).FullName), ex);
		}
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
	public static ulong ConvertToUInt64(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(ulong).FullName), ex);
		}
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
	/// 2. 根据 <see cref="P:System.UIntPtr.Size" /> 属性值的不同，调用 <see cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToUInt32(System.IConvertible,System.IFormatProvider)" /> 或者 <see cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToUInt64(System.IConvertible,System.IFormatProvider)" /> 转换当前值。
	/// </remarks>
	public static UIntPtr ConvertToUIntPtr(this IConvertible value, IFormatProvider provider = null)
	{
		if (value.IsNull())
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
			throw new InvalidCastException(Literals.MSG_InvalidCast_2.FormatValue(value.ToString(), typeof(UIntPtr).FullName), ex);
		}
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
	public static bool? ConvertToNullableBoolean(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new bool?(value.ConvertToBoolean(provider));
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
	public static byte? ConvertToNullableByte(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new byte?(value.ConvertToByte(provider));
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
	public static char? ConvertToNullableChar(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new char?(value.ConvertToChar(provider));
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
	public static DateTime? ConvertToNullableDateTime(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new DateTime?(value.ConvertToDateTime(provider));
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
	public static decimal? ConvertToNullableDecimal(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new decimal?(value.ConvertToDecimal(provider));
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
	public static double? ConvertToNullableDouble(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new double?(value.ConvertToDouble(provider));
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
	public static T? ConvertToNullableEnum<T>(this IConvertible value, IFormatProvider provider = null) where T : struct
	{
		return value.IsNull() ? null : new T?(value.ConvertToEnum<T>(provider));
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
	/// <seealso cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToSingle(System.IConvertible,System.IFormatProvider)" />
	public static float? ConvertToNullableFloat(this IConvertible value, IFormatProvider provider = null)
	{
		return value.ConvertToNullableSingle(provider);
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
	public static short? ConvertToNullableInt16(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new short?(value.ConvertToInt16(provider));
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
	public static int? ConvertToNullableInt32(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new int?(value.ConvertToInt32(provider));
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
	public static long? ConvertToNullableInt64(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new long?(value.ConvertToInt64(provider));
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
	/// 2. 根据 <see cref="P:System.IntPtr.Size" /> 属性值的不同，调用 <see cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToInt32(System.IConvertible,System.IFormatProvider)" /> 或者 <see cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToInt64(System.IConvertible,System.IFormatProvider)" /> 转换当前值。
	/// </remarks>
	public static IntPtr? ConvertToNullableIntPtr(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new IntPtr?(value.ConvertToIntPtr(provider));
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
	public static sbyte? ConvertToNullableSByte(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new sbyte?(value.ConvertToSByte(provider));
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
	public static float? ConvertToNullableSingle(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new float?(value.ConvertToSingle(provider));
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
	public static TimeSpan? ConvertToNullableTimeSpan(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new TimeSpan?(value.ConvertToTimeSpan(provider));
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
	public static T? ConvertToNullableType<T>(this IConvertible value, IFormatProvider provider = null) where T : struct
	{
		return value.IsNull() ? null : new T?(value.ConvertToType<T>(provider));
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
	public static ushort? ConvertToNullableUInt16(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new ushort?(value.ConvertToUInt16(provider));
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
	public static uint? ConvertToNullableUInt32(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new uint?(value.ConvertToUInt32(provider));
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
	public static ulong? ConvertToNullableUInt64(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new ulong?(value.ConvertToUInt64(provider));
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
	/// 2. 根据 <see cref="P:System.UIntPtr.Size" /> 属性值的不同，调用 <see cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToUInt32(System.IConvertible,System.IFormatProvider)" /> 或者 <see cref="M:Richfit.Garnet.Common.Extensions.IConvertibleExtensions.ConvertToUInt64(System.IConvertible,System.IFormatProvider)" /> 转换当前值。
	/// </remarks>
	public static UIntPtr? ConvertToNullableUIntPtr(this IConvertible value, IFormatProvider provider = null)
	{
		return value.IsNull() ? null : new UIntPtr?(value.ConvertToUIntPtr(provider));
	}
}
