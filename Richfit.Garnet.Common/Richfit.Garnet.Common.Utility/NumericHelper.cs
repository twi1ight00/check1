#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 值类型辅助类
/// </summary>
public static class NumericHelper
{
	/// <summary>
	/// 将当前摄氏温度转华氏温度
	/// </summary>
	/// <param name="temperature">当前摄氏温度</param>
	/// <returns>华氏温度</returns>
	public static float CelsiusToFahrenheit(float temperature)
	{
		return temperature * 9f / 5f + 32f;
	}

	/// <summary>
	/// 将当前摄氏温度转华氏温度
	/// </summary>
	/// <param name="temperature">当前摄氏温度</param>
	/// <returns>华氏温度</returns>
	public static double CelsiusToFahrenheit(double temperature)
	{
		return temperature * 9.0 / 5.0 + 32.0;
	}

	/// <summary>
	/// 将当前摄氏温度转华氏温度
	/// </summary>
	/// <param name="temperature">当前摄氏温度</param>
	/// <returns>华氏温度</returns>
	public static decimal CelsiusToFahrenheit(decimal temperature)
	{
		return temperature * 9m / 5m + 32m;
	}

	/// <summary>
	/// 当前摄氏温度转热力学温度
	/// </summary>
	/// <param name="temperature">当前摄氏温度</param>
	/// <returns>热力学温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static float CelsiusToKelvin(float temperature)
	{
		return temperature + 273.15f;
	}

	/// <summary>
	/// 当前摄氏温度转热力学温度
	/// </summary>
	/// <param name="temperature">当前摄氏温度</param>
	/// <returns>热力学温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static double CelsiusToKelvin(double temperature)
	{
		return temperature + 273.15;
	}

	/// <summary>
	/// 当前摄氏温度转热力学温度
	/// </summary>
	/// <param name="temperature">当前摄氏温度</param>
	/// <returns>热力学温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static decimal CelsiusToKelvin(decimal temperature)
	{
		return temperature + 273.15m;
	}

	/// <summary>
	/// 当前华氏温度转摄氏温度
	/// </summary>
	/// <param name="temperature">当前华氏温度</param>
	/// <returns>摄氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static float FahrenheitToCelsius(float temperature)
	{
		return (temperature - 32f) * 5f / 9f;
	}

	/// <summary>
	/// 当前华氏温度转摄氏温度
	/// </summary>
	/// <param name="temperature">当前华氏温度</param>
	/// <returns>摄氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static double FahrenheitToCelsius(double temperature)
	{
		return (temperature - 32.0) * 5.0 / 9.0;
	}

	/// <summary>
	/// 当前华氏温度转摄氏温度
	/// </summary>
	/// <param name="temperature">当前华氏温度</param>
	/// <returns>摄氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static decimal FahrenheitToCelsius(decimal temperature)
	{
		return (temperature - 32m) * 5m / 9m;
	}

	/// <summary>
	/// 当前华氏温度转热力学温度
	/// </summary>
	/// <param name="temperature">当前华氏温度</param>
	/// <returns>热力学温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static float FahrenheitToKelvin(float temperature)
	{
		return (temperature + 459.67f) * 5f / 9f;
	}

	/// <summary>
	/// 当前华氏温度转热力学温度
	/// </summary>
	/// <param name="temperature">当前华氏温度</param>
	/// <returns>热力学温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static double FahrenheitToKelvin(double temperature)
	{
		return (temperature + 459.67) * 5.0 / 9.0;
	}

	/// <summary>
	/// 当前华氏温度转热力学温度
	/// </summary>
	/// <param name="temperature">当前华氏温度</param>
	/// <returns>热力学温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static decimal FahrenheitToKelvin(decimal temperature)
	{
		return (temperature + 459.67m) * 5m / 9m;
	}

	/// <summary>
	/// 当前热力学温度转摄氏温度
	/// </summary>
	/// <param name="temperature">当前热力学温度</param>
	/// <returns>摄氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static float KelvinToCelsius(float temperature)
	{
		return temperature - 274.15f;
	}

	/// <summary>
	/// 当前热力学温度转摄氏温度
	/// </summary>
	/// <param name="temperature">当前热力学温度</param>
	/// <returns>摄氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static double KelvinToCelsius(double temperature)
	{
		return temperature - 274.15;
	}

	/// <summary>
	/// 当前热力学温度转摄氏温度
	/// </summary>
	/// <param name="temperature">当前热力学温度</param>
	/// <returns>摄氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static decimal KelvinToCelsius(decimal temperature)
	{
		return temperature - 274.15m;
	}

	/// <summary>
	/// 当前热力学温度转华氏温度
	/// </summary>
	/// <param name="temperature">当前热力学温度</param>
	/// <returns>华氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static float KelvinToFahrenheit(float temperature)
	{
		return temperature * 9f / 5f - 459.67f;
	}

	/// <summary>
	/// 当前热力学温度转华氏温度
	/// </summary>
	/// <param name="temperature">当前热力学温度</param>
	/// <returns>华氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static double KelvinToFahrenheit(double temperature)
	{
		return temperature * 9.0 / 5.0 - 459.67;
	}

	/// <summary>
	/// 当前热力学温度转华氏温度
	/// </summary>
	/// <param name="temperature">当前热力学温度</param>
	/// <returns>华氏温度</returns>
	/// <exception cref="T:System.ArgumentNullException">当前温度为空。</exception>
	public static decimal KelvinToFahrenheit(decimal temperature)
	{
		return temperature * 9m / 5m - 459.67m;
	}

	/// <summary>
	/// 计算当前数值的绝对值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static BigInteger Abs(BigInteger value)
	{
		return BigInteger.Abs(value);
	}

	/// <summary>
	/// 计算当前数值的绝对值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static sbyte Abs(sbyte value)
	{
		return Math.Abs(value);
	}

	/// <summary>
	/// 计算当前数值的绝对值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static int Abs(int value)
	{
		return Math.Abs(value);
	}

	/// <summary>
	/// 计算当前数值的绝对值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static long Abs(long value)
	{
		return Math.Abs(value);
	}

	/// <summary>
	/// 计算当前数值的绝对值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static float Abs(float value)
	{
		return Math.Abs(value);
	}

	/// <summary>
	/// 计算当前数值的绝对值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Abs(double value)
	{
		return Math.Abs(value);
	}

	/// <summary>
	/// 计算当前数值的绝对值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static decimal Abs(decimal value)
	{
		return Math.Abs(value);
	}

	/// <summary>
	/// 计算当前余弦值的反余弦值（弧度）
	/// </summary>
	/// <param name="value">当前余弦值</param>
	/// <returns>计算结果</returns>
	public static double Acos(int value)
	{
		return Math.Acos(value);
	}

	/// <summary>
	/// 计算当前余弦值的反余弦值（弧度）
	/// </summary>
	/// <param name="value">当前余弦值</param>
	/// <returns>计算结果</returns>
	public static double Acos(long value)
	{
		return Math.Acos(value);
	}

	/// <summary>
	/// 计算当前余弦值的反余弦值（弧度）
	/// </summary>
	/// <param name="value">当前余弦值</param>
	/// <returns>计算结果</returns>
	public static float Acos(float value)
	{
		return (float)Math.Acos(value);
	}

	/// <summary>
	/// 计算当前余弦值的反余弦值（弧度）
	/// </summary>
	/// <param name="value">当前余弦值</param>
	/// <returns>计算结果</returns>
	public static double Acos(double value)
	{
		return Math.Acos(value);
	}

	/// <summary>
	/// 计算当前余弦值的反余弦值（弧度）
	/// </summary>
	/// <param name="value">当前余弦值</param>
	/// <returns>计算结果</returns>
	public static decimal Acos(decimal value)
	{
		return (decimal)Math.Acos((double)value);
	}

	/// <summary>
	/// 计算当前正弦值的反正弦值（弧度）
	/// </summary>
	/// <param name="value">当前正弦值</param>
	/// <returns>计算结果</returns>
	public static double Asin(int value)
	{
		return Math.Asin(value);
	}

	/// <summary>
	/// 计算当前正弦值的反正弦值（弧度）
	/// </summary>
	/// <param name="value">当前正弦值</param>
	/// <returns>计算结果</returns>
	public static double Asin(long value)
	{
		return Math.Asin(value);
	}

	/// <summary>
	/// 计算当前正弦值的反正弦值（弧度）
	/// </summary>
	/// <param name="value">当前正弦值</param>
	/// <returns>计算结果</returns>
	public static float Asin(float value)
	{
		return (float)Math.Asin(value);
	}

	/// <summary>
	/// 计算当前正弦值的反正弦值（弧度）
	/// </summary>
	/// <param name="value">当前正弦值</param>
	/// <returns>计算结果</returns>
	public static double Asin(double value)
	{
		return Math.Asin(value);
	}

	/// <summary>
	/// 计算当前正弦值的反正弦值（弧度）
	/// </summary>
	/// <param name="value">当前正弦值</param>
	/// <returns>计算结果</returns>
	public static decimal Asin(decimal value)
	{
		return (decimal)Math.Asin((double)value);
	}

	/// <summary>
	/// 计算当前正切值的反正切值（弧度）
	/// </summary>
	/// <param name="value">当前正切值</param>
	/// <returns>计算结果</returns>
	public static double Atan(int value)
	{
		return Math.Atan(value);
	}

	/// <summary>
	/// 计算当前正切值的反正切值（弧度）
	/// </summary>
	/// <param name="value">当前正切值</param>
	/// <returns>计算结果</returns>
	public static double Atan(long value)
	{
		return Math.Atan(value);
	}

	/// <summary>
	/// 计算当前正切值的反正切值（弧度）
	/// </summary>
	/// <param name="value">当前正切值</param>
	/// <returns>计算结果</returns>
	public static float Atan(float value)
	{
		return (float)Math.Atan(value);
	}

	/// <summary>
	/// 计算当前正切值的反正切值（弧度）
	/// </summary>
	/// <param name="value">当前正切值</param>
	/// <returns>计算结果</returns>
	public static double Atan(double value)
	{
		return Math.Atan(value);
	}

	/// <summary>
	/// 计算当前正切值的反正切值（弧度）
	/// </summary>
	/// <param name="value">当前正切值</param>
	/// <returns>计算结果</returns>
	public static decimal Atan(decimal value)
	{
		return (decimal)Math.Atan((double)value);
	}

	/// <summary>
	/// 计算正切值为两个指定数字的商的角度
	/// </summary>
	/// <param name="x">x 坐标</param>
	/// <param name="y">y 坐标</param>
	/// <returns>计算结果</returns>
	public static double Atan2(int x, int y)
	{
		return Math.Atan2(x, y);
	}

	/// <summary>
	/// 计算正切值为两个指定数字的商的角度
	/// </summary>
	/// <param name="x">x 坐标</param>
	/// <param name="y">y 坐标</param>
	/// <returns>计算结果</returns>
	public static double Atan2(long x, long y)
	{
		return Math.Atan2(x, y);
	}

	/// <summary>
	/// 计算正切值为两个指定数字的商的角度
	/// </summary>
	/// <param name="x">x 坐标</param>
	/// <param name="y">y 坐标</param>
	/// <returns>计算结果</returns>
	public static float Atan2(float x, float y)
	{
		return (float)Math.Atan2(x, y);
	}

	/// <summary>
	/// 计算正切值为两个指定数字的商的角度
	/// </summary>
	/// <param name="x">x 坐标</param>
	/// <param name="y">y 坐标</param>
	/// <returns>计算结果</returns>
	public static double Atan2(double x, double y)
	{
		return Math.Atan2(x, y);
	}

	/// <summary>
	/// 计算正切值为两个指定数字的商的角度
	/// </summary>
	/// <param name="x">x 坐标</param>
	/// <param name="y">y 坐标</param>
	/// <returns>计算结果</returns>
	public static decimal Atan2(decimal x, decimal y)
	{
		return (decimal)Math.Atan2((double)x, (double)y);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <param name="remainder">序列平均值的余数</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static BigInteger Average(IEnumerable<BigInteger> values, out BigInteger remainder)
	{
		Guard.AssertNotNull(values, "values");
		remainder = 0;
		BigInteger sum = 0;
		int count = 0;
		foreach (BigInteger value in values)
		{
			sum += value;
			count++;
		}
		return (count == 0) ? ((BigInteger)0) : BigInteger.DivRem(sum, count, out remainder);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static double Average(IEnumerable<int> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Average();
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <param name="remainder">序列平均值的余数</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static int Average(IEnumerable<int> values, out int remainder)
	{
		Guard.AssertNotNull(values, "values");
		remainder = 0;
		int sum = 0;
		int count = 0;
		foreach (int value in values)
		{
			sum += value;
			count++;
		}
		return (count != 0) ? Div(sum, count, out remainder) : 0;
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static double Average(IEnumerable<int?> values)
	{
		Guard.AssertNotNull(values, "values");
		return Average(from v in values
			where ObjectHelper.IsNotNull(v)
			select v.Value);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <param name="remainder">序列平均值的余数</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static int Average(IEnumerable<int?> values, out int remainder)
	{
		Guard.AssertNotNull(values, "values");
		return Average(from v in values
			where ObjectHelper.IsNotNull(v)
			select v.Value, out remainder);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static double Average(IEnumerable<long> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Average();
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <param name="remainder">序列平均值的余数</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static long Average(IEnumerable<long> values, out long remainder)
	{
		Guard.AssertNotNull(values, "values");
		remainder = 0L;
		long sum = 0L;
		int count = 0;
		foreach (long value in values)
		{
			sum += value;
			count++;
		}
		return (count == 0) ? 0 : Div(sum, count, out remainder);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static double Average(IEnumerable<long?> values)
	{
		Guard.AssertNotNull(values, "values");
		return Average(from v in values
			where ObjectHelper.IsNotNull(v)
			select v.Value);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <param name="remainder">序列平均值的余数</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static long Average(IEnumerable<long?> values, out long remainder)
	{
		Guard.AssertNotNull(values, "values");
		return Average(from v in values
			where ObjectHelper.IsNotNull(v)
			select v.Value, out remainder);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static float Average(IEnumerable<float> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Average();
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static float Average(IEnumerable<float?> values)
	{
		Guard.AssertNotNull(values, "values");
		return ObjectHelper.IfNullThen(values.Average(), 0f);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static double Average(IEnumerable<double> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Average();
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static double Average(IEnumerable<double?> values)
	{
		Guard.AssertNotNull(values, "values");
		return ObjectHelper.IfNullThen(values.Average(), 0.0);
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static decimal Average(IEnumerable<decimal> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Average();
	}

	/// <summary>
	/// 计算当前的值序列的平均值
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前值序列的平均值</returns>
	/// <exception cref="T:System.ArgumentNullException">当前的值序列为空。</exception>
	public static decimal Average(IEnumerable<decimal?> values)
	{
		Guard.AssertNotNull(values, "values");
		return ObjectHelper.IfNullThen(values.Average(), 0m);
	}

	/// <summary>
	/// 计算两个 <see cref="T:System.Int32" /> 类型数值的完整乘积
	/// </summary>
	/// <param name="a">相乘的第一个数值</param>
	/// <param name="b">相乘的第二个数值</param>
	/// <returns>相乘后 <see cref="T:System.Int64" /> 类型的完整乘积</returns>
	public static long BigMul(int a, int b)
	{
		return Math.BigMul(a, b);
	}

	/// <summary>
	/// 计算大于或等于当前数值的最小整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static float Ceiling(float value)
	{
		return (float)Math.Ceiling(value);
	}

	/// <summary>
	/// 计算大于或等于当前数值的最小整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Ceiling(double value)
	{
		return Math.Ceiling(value);
	}

	/// <summary>
	/// 计算大于或等于当前数值的最小整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static decimal Ceiling(decimal value)
	{
		return decimal.Ceiling(value);
	}

	/// <summary>
	/// 计算当前数值的余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Cos(int value)
	{
		return Math.Cos(value);
	}

	/// <summary>
	/// 计算当前数值的余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Cos(long value)
	{
		return Math.Cos(value);
	}

	/// <summary>
	/// 计算当前数值的余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static float Cos(float value)
	{
		return (float)Math.Cos(value);
	}

	/// <summary>
	/// 计算当前数值的余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Cos(double value)
	{
		return Math.Cos(value);
	}

	/// <summary>
	/// 计算当前数值的余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static decimal Cos(decimal value)
	{
		return (decimal)Math.Cos((double)value);
	}

	/// <summary>
	/// 计算当前数值的双曲余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Cosh(int value)
	{
		return Math.Cosh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Cosh(long value)
	{
		return Math.Cosh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static float Cosh(float value)
	{
		return (float)Math.Cosh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Cosh(double value)
	{
		return Math.Cosh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲余弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static decimal Cosh(decimal value)
	{
		return (decimal)Math.Cosh((double)value);
	}

	/// <summary>
	/// 计算两个 <see cref="T:System.Numerics.BigInteger" /> 类型数值的商
	/// </summary>
	/// <param name="a">被除数</param>
	/// <param name="b">除数</param>
	/// <returns>计算的商</returns>
	public static BigInteger Div(BigInteger a, BigInteger b)
	{
		BigInteger remainder;
		return BigInteger.DivRem(a, b, out remainder);
	}

	/// <summary>
	/// 计算两个 <see cref="T:System.Int32" /> 类型数值的商
	/// </summary>
	/// <param name="a">被除数</param>
	/// <param name="b">除数</param>
	/// <param name="remainder">计算的余数</param>
	/// <returns>计算的商</returns>
	public static BigInteger Div(BigInteger a, BigInteger b, out BigInteger remainder)
	{
		return BigInteger.DivRem(a, b, out remainder);
	}

	/// <summary>
	/// 计算两个 <see cref="T:System.Int32" /> 类型数值的商
	/// </summary>
	/// <param name="a">被除数</param>
	/// <param name="b">除数</param>
	/// <returns>计算的商</returns>
	public static int Div(int a, int b)
	{
		int remainder;
		return Math.DivRem(a, b, out remainder);
	}

	/// <summary>
	/// 计算两个 <see cref="T:System.Int32" /> 类型数值的商
	/// </summary>
	/// <param name="a">被除数</param>
	/// <param name="b">除数</param>
	/// <param name="remainder">计算的余数</param>
	/// <returns>计算的商</returns>
	public static int Div(int a, int b, out int remainder)
	{
		return Math.DivRem(a, b, out remainder);
	}

	/// <summary>
	/// 计算两个 <see cref="T:System.Int64" /> 类型数值的商
	/// </summary>
	/// <param name="a">被除数</param>
	/// <param name="b">除数</param>
	/// <returns>计算的商</returns>
	public static long Div(long a, long b)
	{
		long remainder;
		return Math.DivRem(a, b, out remainder);
	}

	/// <summary>
	/// 计算两个 <see cref="T:System.Int64" /> 类型数值的商
	/// </summary>
	/// <param name="a">被除数</param>
	/// <param name="b">除数</param>
	/// <param name="remainder">计算的余数</param>
	/// <returns>计算的商</returns>
	public static long Div(long a, long b, out long remainder)
	{
		return Math.DivRem(a, b, out remainder);
	}

	/// <summary>
	/// 计算以当前数值为指数的 <b>e</b> 的指定次数幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Exp(int value)
	{
		return Math.Exp(value);
	}

	/// <summary>
	/// 计算以当前数值为指数的 <b>e</b> 的指定次数幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Exp(long value)
	{
		return Math.Exp(value);
	}

	/// <summary>
	/// 计算以当前数值为指数的 <b>e</b> 的指定次数幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static float Exp(float value)
	{
		return (float)Math.Exp(value);
	}

	/// <summary>
	/// 计算以当前数值为指数的 <b>e</b> 的指定次数幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Exp(double value)
	{
		return Math.Exp(value);
	}

	/// <summary>
	/// 计算以当前数值为指数的 <b>e</b> 的指定次数幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static decimal Exp(decimal value)
	{
		return (decimal)Math.Exp((double)value);
	}

	/// <summary>
	/// 计算小于或等于当前数值的最大整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static float Floor(float value)
	{
		return (float)Math.Floor(value);
	}

	/// <summary>
	/// 计算小于或等于当前数值的最大整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Floor(double value)
	{
		return Math.Floor(value);
	}

	/// <summary>
	/// 计算小于或等于当前数值的最大整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static decimal Floor(decimal value)
	{
		return decimal.Floor(value);
	}

	/// <summary>
	/// 计算以 <b>e</b> 为底的当前数值的对数（自然对数）
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Ln(BigInteger value)
	{
		return BigInteger.Log(value);
	}

	/// <summary>
	/// 计算以 <b>e</b> 为底的当前数值的对数（自然对数）
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Ln(int value)
	{
		return Math.Log(value);
	}

	/// <summary>
	/// 计算以 <b>e</b> 为底的当前数值的对数（自然对数）
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Ln(long value)
	{
		return Math.Log(value);
	}

	/// <summary>
	/// 计算以 <b>e</b> 为底的当前数值的对数（自然对数）
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static float Ln(float value)
	{
		return (float)Math.Log(value);
	}

	/// <summary>
	/// 计算以 <b>e</b> 为底的当前数值的对数（自然对数）
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Ln(double value)
	{
		return Math.Log(value);
	}

	/// <summary>
	/// 计算以 <b>e</b> 为底的当前数值的对数（自然对数）
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static decimal Ln(decimal value)
	{
		return (decimal)Math.Log((double)value);
	}

	/// <summary>
	/// 计算以指定数值为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="logBase">对数的底</param>
	/// <returns>计算结果</returns>
	public static double Log(BigInteger value, double logBase)
	{
		return BigInteger.Log(value, logBase);
	}

	/// <summary>
	/// 计算以指定数值为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="logBase">对数的底</param>
	/// <returns>计算结果</returns>
	public static double Log(int value, int logBase)
	{
		return Math.Log(value, logBase);
	}

	/// <summary>
	/// 计算以指定数值为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="logBase">对数的底</param>
	/// <returns>计算结果</returns>
	public static double Log(long value, long logBase)
	{
		return Math.Log(value, logBase);
	}

	/// <summary>
	/// 计算以指定数值为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="logBase">对数的底</param>
	/// <returns>计算结果</returns>
	public static float Log(float value, float logBase)
	{
		return (float)Math.Log(value, logBase);
	}

	/// <summary>
	/// 计算以指定数值为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="logBase">对数的底</param>
	/// <returns>计算结果</returns>
	public static double Log(double value, double logBase)
	{
		return Math.Log(value, logBase);
	}

	/// <summary>
	/// 计算以指定数值为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="logBase">对数的底</param>
	/// <returns>计算结果</returns>
	public static decimal Log(decimal value, decimal logBase)
	{
		return (decimal)Math.Log((double)value, (double)logBase);
	}

	/// <summary>
	/// 计算以10为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Log10(BigInteger value)
	{
		return BigInteger.Log10(value);
	}

	/// <summary>
	/// 计算以10为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Log10(int value)
	{
		return Math.Log10(value);
	}

	/// <summary>
	/// 计算以10为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Log10(long value)
	{
		return Math.Log10(value);
	}

	/// <summary>
	/// 计算以10为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static float Log10(float value)
	{
		return (float)Math.Log10(value);
	}

	/// <summary>
	/// 计算以10为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Log10(double value)
	{
		return Math.Log10(value);
	}

	/// <summary>
	/// 计算以10为底的当前数值的对数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static decimal Log10(decimal value)
	{
		return (decimal)Math.Log10((double)value);
	}

	/// <summary>
	/// 返回两个数值中较大的一个
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static BigInteger Max(BigInteger a, BigInteger b)
	{
		return BigInteger.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static BigInteger Max(params BigInteger[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static byte Max(byte a, byte b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static byte Max(params byte[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static sbyte Max(sbyte a, sbyte b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static sbyte Max(params sbyte[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static short Max(short a, short b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static short Max(params short[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static int Max(int a, int b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static int Max(params int[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static long Max(long a, long b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static long Max(params long[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static ushort Max(ushort a, ushort b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static ushort Max(params ushort[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static uint Max(uint a, uint b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static uint Max(params uint[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static ulong Max(ulong a, ulong b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static ulong Max(params ulong[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static float Max(float a, float b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static float Max(params float[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static double Max(double a, double b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static double Max(params double[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较大的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较大的数值</returns>
	public static decimal Max(decimal a, decimal b)
	{
		return Math.Max(a, b);
	}

	/// <summary>
	/// 返回多个数值中较大的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较大的数值</returns>
	public static decimal Max(params decimal[] values)
	{
		return CollectionHelper.Max(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static BigInteger Min(BigInteger a, BigInteger b)
	{
		return BigInteger.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static BigInteger Min(params BigInteger[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static byte Min(byte a, byte b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static byte Min(params byte[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static sbyte Min(sbyte a, sbyte b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static sbyte Min(params sbyte[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static short Min(short a, short b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static short Min(params short[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static int Min(int a, int b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static int Min(params int[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static long Min(long a, long b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static long Min(params long[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static ushort Min(ushort a, ushort b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static ushort Min(params ushort[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static uint Min(uint a, uint b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static uint Min(params uint[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static ulong Min(ulong a, ulong b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static ulong Min(params ulong[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static float Min(float a, float b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static float Min(params float[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static double Min(double a, double b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static double Min(params double[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 返回两个数值中较小的一个。
	/// </summary>
	/// <param name="a">比较的第一个数值</param>
	/// <param name="b">比较的第二个数值</param>
	/// <returns>较小的数值</returns>
	public static decimal Min(decimal a, decimal b)
	{
		return Math.Min(a, b);
	}

	/// <summary>
	/// 返回多个数值中较小的一个
	/// </summary>
	/// <param name="values">进行比较的多个数值</param>
	/// <returns>较小的数值</returns>
	public static decimal Min(params decimal[] values)
	{
		return CollectionHelper.Min(values);
	}

	/// <summary>
	/// 计算当前数值的指定次幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">乘幂的次数</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">乘幂次数小于0。</exception>
	public static BigInteger Pow(BigInteger value, int n)
	{
		Guard.AssertGreaterThanOrEqualTo(n, 0, "n");
		return BigInteger.Pow(value, n);
	}

	/// <summary>
	/// 计算当前数值的指定次幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">乘幂的次数</param>
	/// <returns>计算结果</returns>
	public static double Pow(int value, int n)
	{
		if (n > 0)
		{
			int result = 1;
			while (n-- > 0)
			{
				result *= value;
			}
			return result;
		}
		if (n < 0)
		{
			double result2 = 1.0;
			while (n++ < 0)
			{
				result2 /= (double)value;
			}
			return result2;
		}
		return 1.0;
	}

	/// <summary>
	/// 计算当前数值的指定次幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">乘幂的次数</param>
	/// <returns>计算结果</returns>
	public static double Pow(long value, long n)
	{
		if (n > 0)
		{
			long result = 1L;
			while (n-- > 0)
			{
				result *= value;
			}
			return result;
		}
		if (n < 0)
		{
			double result2 = 1.0;
			while (n++ < 0)
			{
				result2 /= (double)value;
			}
			return result2;
		}
		return 1.0;
	}

	/// <summary>
	/// 计算当前数值的指定次幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">乘幂的次数</param>
	/// <returns>计算结果</returns>
	public static float Pow(float value, float n)
	{
		return (float)Math.Pow(value, n);
	}

	/// <summary>
	/// 计算当前数值的指定次幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">乘幂的次数</param>
	/// <returns>计算结果</returns>
	public static double Pow(double value, double n)
	{
		return Math.Pow(value, n);
	}

	/// <summary>
	/// 计算当前数值的指定次幂
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">乘幂的次数</param>
	/// <returns>计算结果</returns>
	public static decimal Pow(decimal value, decimal n)
	{
		return (decimal)Math.Pow((double)value, (double)n);
	}

	/// <summary>
	/// 计算当前数值的倒数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Reciproc(int value)
	{
		return 1.0 / (double)value;
	}

	/// <summary>
	/// 计算当前数值的倒数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Reciproc(long value)
	{
		return 1.0 / (double)value;
	}

	/// <summary>
	/// 计算当前数值的倒数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static float Reciproc(float value)
	{
		return 1f / value;
	}

	/// <summary>
	/// 计算当前数值的倒数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Reciproc(double value)
	{
		return 1.0 / value;
	}

	/// <summary>
	/// 计算当前数值的倒数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static decimal Reciproc(decimal value)
	{
		return 1m / value;
	}

	/// <summary>
	/// 计算当前数值除以目标值后的余数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">目标数值</param>
	/// <returns>余数</returns>
	public static BigInteger Rem(BigInteger value, BigInteger target)
	{
		return BigInteger.Remainder(value, target);
	}

	/// <summary>
	/// 计算当前数值除以目标值后的余数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">目标数值</param>
	/// <returns>余数</returns>
	public static int Rem(int value, int target)
	{
		return value % target;
	}

	/// <summary>
	/// 计算当前数值除以目标值后的余数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">目标数值</param>
	/// <returns>余数</returns>
	public static long Rem(long value, long target)
	{
		return value % target;
	}

	/// <summary>
	/// 计算当前数值除以目标值后的余数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">目标数值</param>
	/// <returns>余数</returns>
	public static float Rem(float value, float target)
	{
		return (float)Math.IEEERemainder(value, target);
	}

	/// <summary>
	/// 计算当前数值除以目标值后的余数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">目标数值</param>
	/// <returns>余数</returns>
	public static double Rem(double value, double target)
	{
		return Math.IEEERemainder(value, target);
	}

	/// <summary>
	/// 计算当前数值除以目标值后的余数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">目标数值</param>
	/// <returns>余数</returns>
	public static decimal Rem(decimal value, decimal target)
	{
		return decimal.Remainder(value, target);
	}

	/// <summary>
	/// 计算当前数值的指定次数的方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">开方的次数</param>
	/// <returns>计算结果</returns>
	public static double Root(int value, int n)
	{
		return Root((double)value, (double)n);
	}

	/// <summary>
	/// 计算当前数值的指定次数的方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">开方的次数</param>
	/// <returns>计算结果</returns>
	public static double Root(long value, long n)
	{
		return Root((double)value, (double)n);
	}

	/// <summary>
	/// 计算当前数值的指定次数的方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">开方的次数</param>
	/// <returns>计算结果</returns>
	public static float Root(float value, float n)
	{
		return (float)Root((double)value, (double)n);
	}

	/// <summary>
	/// 计算当前数值的指定次数的方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">开方的次数</param>
	/// <returns>计算结果</returns>
	public static double Root(double value, double n)
	{
		return Math.Pow(value, 1.0 / n);
	}

	/// <summary>
	/// 计算当前数值的指定次数的方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="n">开方的次数</param>
	/// <returns>计算结果</returns>
	public static decimal Root(decimal value, decimal n)
	{
		return (decimal)Math.Pow((double)value, (double)(1m / n));
	}

	/// <summary>
	/// 将当前数值四舍五入到最接近的整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>处理后的数值</returns>
	public static float Round(float value)
	{
		return (float)Round((double)value);
	}

	/// <summary>
	/// 将当前数值按指定的小数位数进行舍入
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="decimals">保留小数的位数，范围是0到28。</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="decimals" /> 小于0，或者大于28。</exception>
	public static float Round(float value, int decimals)
	{
		return (float)Round((double)value, decimals);
	}

	/// <summary>
	/// 将当前数值四舍五入到最接近的整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>处理后的数值</returns>
	public static double Round(double value)
	{
		return Math.Round(value);
	}

	/// <summary>
	/// 将当前数值按指定的小数位数进行舍入
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="decimals">保留小数的位数，范围是0到28。</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="decimals" /> 小于0，或者大于28。</exception>
	public static double Round(double value, int decimals)
	{
		return Math.Round(value, decimals);
	}

	/// <summary>
	/// 将当前数值四舍五入到最接近的整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>处理后的数值</returns>
	public static decimal Round(decimal value)
	{
		return decimal.Round(value);
	}

	/// <summary>
	/// 将当前数值按指定的小数位数进行舍入
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="decimals">保留小数的位数，范围是0到28。</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="decimals" /> 小于0，或者大于28。</exception>
	public static decimal Round(decimal value, int decimals)
	{
		return decimal.Round(value, decimals);
	}

	/// <summary>
	/// 获取当前数值的符号
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的符号；如果当前数值大于0，返回1；如果当前数值小于0，返回-1。</returns>
	public static int Sign(BigInteger value)
	{
		return value.Sign;
	}

	/// <summary>
	/// 获取当前数值的符号
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的符号；如果当前数值大于0，返回1；如果当前数值小于0，返回-1。</returns>
	public static int Sign(int value)
	{
		return Math.Sign(value);
	}

	/// <summary>
	/// 获取当前数值的符号
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的符号；如果当前数值大于0，返回1；如果当前数值小于0，返回-1。</returns>
	public static int Sign(long value)
	{
		return Math.Sign(value);
	}

	/// <summary>
	/// 获取当前数值的符号
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的符号；如果当前数值大于0，返回1；如果当前数值小于0，返回-1。</returns>
	public static int Sign(float value)
	{
		return Math.Sign(value);
	}

	/// <summary>
	/// 获取当前数值的符号
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的符号；如果当前数值大于0，返回1；如果当前数值小于0，返回-1。</returns>
	public static int Sign(double value)
	{
		return Math.Sign(value);
	}

	/// <summary>
	/// 获取当前数值的符号
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的符号；如果当前数值大于0，返回1；如果当前数值小于0，返回-1。</returns>
	public static int Sign(decimal value)
	{
		return Math.Sign(value);
	}

	/// <summary>
	/// 计算当前数值的正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Sin(int value)
	{
		return Math.Sin(value);
	}

	/// <summary>
	/// 计算当前数值的正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Sin(long value)
	{
		return Math.Sin(value);
	}

	/// <summary>
	/// 计算当前数值的正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static float Sin(float value)
	{
		return (float)Math.Sin(value);
	}

	/// <summary>
	/// 计算当前数值的正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Sin(double value)
	{
		return Math.Sin(value);
	}

	/// <summary>
	/// 计算当前数值的正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static decimal Sin(decimal value)
	{
		return (decimal)Math.Sin((double)value);
	}

	/// <summary>
	/// 计算当前数值的双曲正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Sinh(int value)
	{
		return Math.Sinh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Sinh(long value)
	{
		return Math.Sinh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static float Sinh(float value)
	{
		return (float)Math.Sinh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Sinh(double value)
	{
		return Math.Sinh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲正弦值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static decimal Sinh(decimal value)
	{
		return (decimal)Math.Sinh((double)value);
	}

	/// <summary>
	/// 计算当前数值的平方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Sqrt(int value)
	{
		return Math.Sqrt(value);
	}

	/// <summary>
	/// 计算当前数值的平方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Sqrt(long value)
	{
		return Math.Sqrt(value);
	}

	/// <summary>
	/// 计算当前数值的平方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static float Sqrt(float value)
	{
		return (float)Math.Sqrt(value);
	}

	/// <summary>
	/// 计算当前数值的平方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static double Sqrt(double value)
	{
		return Math.Sqrt(value);
	}

	/// <summary>
	/// 计算当前数值的平方根
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>计算结果</returns>
	public static decimal Sqrt(decimal value)
	{
		return (decimal)Math.Sqrt((double)value);
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double StdDev(IEnumerable<int> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double StdDev(IEnumerable<int?> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double StdDev(IEnumerable<long> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double StdDev(IEnumerable<long?> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static float StdDev(IEnumerable<float> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static float StdDev(IEnumerable<float?> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double StdDev(IEnumerable<double> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double StdDev(IEnumerable<double?> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static decimal StdDev(IEnumerable<decimal> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列的标准偏差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的标准偏差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static decimal StdDev(IEnumerable<decimal?> values)
	{
		Guard.AssertNotNull(values, "values");
		return Sqrt(Var(values));
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static BigInteger Sum(IEnumerable<BigInteger> values)
	{
		Guard.AssertNotNull(values, "values");
		BigInteger result = 0;
		foreach (BigInteger value in values)
		{
			result += value;
		}
		return result;
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static int Sum(IEnumerable<int> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Sum();
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static int Sum(IEnumerable<int?> values)
	{
		Guard.AssertNotNull(values, "values");
		return ObjectHelper.IfNullThen(values.Sum(), 0);
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static long Sum(IEnumerable<long> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Sum();
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static long Sum(IEnumerable<long?> values)
	{
		Guard.AssertNotNull(values, "values");
		return ObjectHelper.IfNullThen(values.Sum(), 0L);
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static float Sum(IEnumerable<float> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Sum();
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static float Sum(IEnumerable<float?> values)
	{
		Guard.AssertNotNull(values, "values");
		return ObjectHelper.IfNullThen(values.Sum(), 0f);
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double Sum(IEnumerable<double> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Sum();
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double Sum(IEnumerable<double?> values)
	{
		Guard.AssertNotNull(values, "values");
		return ObjectHelper.IfNullThen(values.Sum(), 0.0);
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static decimal Sum(IEnumerable<decimal> values)
	{
		Guard.AssertNotNull(values, "values");
		return values.Sum();
	}

	/// <summary>
	/// 计算当前数值序列之和
	/// </summary>
	/// <param name="values">当前的值序列</param>
	/// <returns>当前数值序列之和</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static decimal Sum(IEnumerable<decimal?> values)
	{
		Guard.AssertNotNull(values, "values");
		return ObjectHelper.IfNullThen(values.Sum(), 0m);
	}

	/// <summary>
	/// 计算当前数值的正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Tan(int value)
	{
		return Math.Tan(value);
	}

	/// <summary>
	/// 计算当前数值的正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Tan(long value)
	{
		return Math.Tan(value);
	}

	/// <summary>
	/// 计算当前数值的正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static float Tan(float value)
	{
		return (float)Math.Tan(value);
	}

	/// <summary>
	/// 计算当前数值的正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Tan(double value)
	{
		return Math.Tan(value);
	}

	/// <summary>
	/// 计算当前数值的正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static decimal Tan(decimal value)
	{
		return (decimal)Math.Tan((double)value);
	}

	/// <summary>
	/// 计算当前数值的双曲正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Tanh(int value)
	{
		return Math.Tanh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Tanh(long value)
	{
		return Math.Tanh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static float Tanh(float value)
	{
		return (float)Math.Tanh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static double Tanh(double value)
	{
		return Math.Tanh(value);
	}

	/// <summary>
	/// 计算当前数值的双曲正切值
	/// </summary>
	/// <param name="value">当前数值（弧度）</param>
	/// <returns>计算结果</returns>
	public static decimal Tanh(decimal value)
	{
		return (decimal)Math.Tanh((double)value);
	}

	/// <summary>
	/// 截断当前数值，返回整数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的整数部分</returns>
	public static float Truncate(float value)
	{
		return (float)Truncate((double)value);
	}

	/// <summary>
	/// 将当前数值进行截断，保留指定位数的小数；截断不进行四舍五入
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="decimals">保留的小数的位数，范围0到28。</param>
	/// <returns>截断后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保留的小数位数 <paramref name="decimals" /> 小于0，或者大于28。</exception>
	public static float Truncate(float value, int decimals)
	{
		return (float)Truncate((double)value, decimals);
	}

	/// <summary>
	/// 截断当前数值，返回整数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的整数部分</returns>
	public static double Truncate(double value)
	{
		return GetInteger(value);
	}

	/// <summary>
	/// 将当前数值进行截断，保留指定位数的小数；截断不进行四舍五入
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="decimals">保留的小数的位数，范围0到28。</param>
	/// <returns>截断后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保留的小数位数 <paramref name="decimals" /> 小于0，或者大于28。</exception>
	public static double Truncate(double value, int decimals)
	{
		Guard.AssertBetween(decimals, 0, 28, "decimals");
		double integer = GetInteger(value);
		double result = 0.0;
		if (decimals == 0)
		{
			return integer;
		}
		double factor = Pow(10, decimals);
		return integer + GetInteger((value - integer) * factor) / factor;
	}

	/// <summary>
	/// 截断当前数值，返回整数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的整数部分</returns>
	public static decimal Truncate(decimal value)
	{
		return decimal.Truncate(value);
	}

	/// <summary>
	/// 将当前数值进行截断，保留指定位数的小数；截断不进行四舍五入
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="decimals">保留的小数的位数，范围0到28。</param>
	/// <returns>截断后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">保留的小数位数 <paramref name="decimals" /> 小于0，或者大于28。</exception>
	public static decimal Truncate(decimal value, int decimals)
	{
		Guard.AssertBetween(decimals, 0, 28, "decimals");
		decimal integer = GetInteger(value);
		decimal result = 0m;
		if (decimals == 0)
		{
			return integer;
		}
		decimal factor = (decimal)Pow(10, decimals);
		return integer + decimal.Truncate((value - integer) * factor) / factor;
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double Var(IEnumerable<int> values)
	{
		return Var(values.Select((Func<int, double>)((int v) => v)));
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double Var(IEnumerable<int?> values)
	{
		return Var(values.Where((int? v) => ObjectHelper.IsNotNull(v)).Select((Func<int?, double?>)((int? v) => v)));
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double Var(IEnumerable<long> values)
	{
		return Var(values.Select((Func<long, double>)((long v) => v)));
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double Var(IEnumerable<long?> values)
	{
		return Var(values.Where((long? v) => ObjectHelper.IsNotNull(v)).Select((Func<long?, double?>)((long? v) => v)));
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static float Var(IEnumerable<float> values)
	{
		return (float)Var(values.Select((Func<float, double>)((float v) => v)));
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static float Var(IEnumerable<float?> values)
	{
		return (float)Var(values.Where((float? v) => ObjectHelper.IsNotNull(v)).Select((Func<float?, double?>)((float? v) => v)));
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double Var(IEnumerable<double> values)
	{
		Guard.AssertNotNull(values, "values");
		if (!values.Any())
		{
			return 0.0;
		}
		double avgValue = 0.0;
		int count = 0;
		foreach (double value2 in values)
		{
			double value = value2;
			avgValue += value;
			count++;
		}
		avgValue /= (double)count;
		double sum = 0.0;
		double delta = 0.0;
		foreach (double value3 in values)
		{
			double value = value3;
			delta = value - avgValue;
			sum += delta * delta;
		}
		return sum / (double)count;
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static double Var(IEnumerable<double?> values)
	{
		Guard.AssertNotNull(values, "values");
		values = values.Where((double? v) => ObjectHelper.IsNotNull(v));
		if (!values.Any())
		{
			return 0.0;
		}
		double avgValue = 0.0;
		int count = 0;
		foreach (double? value2 in values)
		{
			double value = value2.Value;
			avgValue += value;
			count++;
		}
		avgValue /= (double)count;
		double sum = 0.0;
		double delta = 0.0;
		foreach (double? value3 in values)
		{
			double value = value3.Value;
			delta = value - avgValue;
			sum += delta * delta;
		}
		return sum / (double)count;
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static decimal Var(IEnumerable<decimal> values)
	{
		Guard.AssertNotNull(values, "values");
		if (!values.Any())
		{
			return 0m;
		}
		decimal avgValue = 0m;
		int count = 0;
		foreach (decimal value in values)
		{
			avgValue += value;
			count++;
		}
		avgValue /= (decimal)count;
		decimal sum = 0m;
		decimal delta = 0m;
		foreach (decimal value in values)
		{
			delta = value - avgValue;
			sum += delta * delta;
		}
		return sum / (decimal)count;
	}

	/// <summary>
	/// 计算当前数值序列的方差
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>序列值的方差</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数值序列为空。</exception>
	public static decimal Var(IEnumerable<decimal?> values)
	{
		Guard.AssertNotNull(values, "values");
		values = values.Where((decimal? v) => ObjectHelper.IsNotNull(v));
		if (!values.Any())
		{
			return 0m;
		}
		decimal avgValue = 0m;
		int count = 0;
		foreach (decimal? value2 in values)
		{
			decimal value = value2.Value;
			avgValue += value;
			count++;
		}
		avgValue /= (decimal)count;
		decimal sum = 0m;
		decimal delta = 0m;
		foreach (decimal? value3 in values)
		{
			decimal value = value3.Value;
			delta = value - avgValue;
			sum += delta * delta;
		}
		return sum / (decimal)count;
	}

	/// <summary>
	/// 将当前字节数组与指定的字节数组进行异或运算
	/// </summary>
	/// <param name="a">当前的字节数组</param>
	/// <param name="b">进行运算的数组</param>
	/// <returns>异或结果数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空；或者进行运算的数组 <paramref name="b" /> 为空。</exception>
	public static byte[] Xor(byte[] a, byte[] b)
	{
		byte[] result = new byte[Math.Min(a.Length, b.Length)];
		for (int i = 0; i < result.Length; i++)
		{
			result[i] = (byte)(a[i] ^ b[i]);
		}
		return result;
	}

	/// <summary>
	/// 计算当前数值的阶乘
	/// </summary>
	/// <param name="value">计算阶乘的当前数值</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前数值小于0。</exception>
	public static int Factorial(int value)
	{
		Guard.AssertGreaterThanOrEqualTo(value, 0, "value");
		int result = 1;
		for (int x = 2; x <= value; x++)
		{
			result *= x;
		}
		return result;
	}

	/// <summary>
	/// 计算当前数值的阶乘
	/// </summary>
	/// <param name="value">计算阶乘的当前数值</param>
	/// <returns>计算结果</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前数值小于0。</exception>
	public static long Factorial(long value)
	{
		Guard.AssertGreaterThanOrEqualTo(value, 0L, "value");
		long result = 1L;
		for (long x = 2L; x <= value; x++)
		{
			result *= x;
		}
		return result;
	}

	/// <summary>
	/// 将当前数值的有效数字的数量（精度）限制为指定数量
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="precision">缩减的目标有效数字数量（精度）</param>
	/// <param name="rounding">截断有效数字时是否进行四舍五入</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">有效数字（精度）<paramref name="precision" /> 小于1。</exception>
	public static int Fix(int value, int precision, bool rounding = true)
	{
		return (int)Fix((decimal)value, precision, rounding);
	}

	/// <summary>
	/// 将当前数值的有效数字的数量（精度）限制为指定数量
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="precision">缩减的目标有效数字数量（精度）</param>
	/// <param name="rounding">截断有效数字时是否进行四舍五入</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">有效数字（精度）<paramref name="precision" /> 小于1。</exception>
	public static long Fix(long value, int precision, bool rounding = true)
	{
		return (long)Fix((decimal)value, precision, rounding);
	}

	/// <summary>
	/// 将当前数值的有效数字的数量（精度）限制为指定数量
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="precision">缩减的目标有效数字数量（精度）</param>
	/// <param name="rounding">截断有效数字时是否进行四舍五入</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">有效数字（精度）<paramref name="precision" /> 小于1。</exception>
	public static float Fix(float value, int precision, bool rounding = true)
	{
		return (float)Fix((double)value, precision, rounding);
	}

	/// <summary>
	/// 将当前数值的有效数字的数量（精度）限制为指定数量
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="precision">缩减的目标有效数字数量（精度）</param>
	/// <param name="rounding">截断有效数字时是否进行四舍五入</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">有效数字（精度）<paramref name="precision" /> 小于1。</exception>
	public static double Fix(double value, int precision, bool rounding = true)
	{
		Guard.AssertGreaterThanOrEqualTo(precision, 1, "precision");
		int exponent = GetExponent(value);
		if (exponent > 0)
		{
			double factor = Pow(10.0, exponent);
			value /= factor;
			value = (rounding ? Round(value, precision - 1) : Truncate(value, precision - 1));
			return value * factor;
		}
		if (exponent < 0)
		{
			double factor = Pow(10.0, -exponent);
			value *= factor;
			value = (rounding ? Round(value, precision - 1) : Truncate(value, precision - 1));
			return value / factor;
		}
		value = (rounding ? Round(value, precision - 1) : Truncate(value, precision - 1));
		return value;
	}

	/// <summary>
	/// 将当前数值的有效数字的数量（精度）限制为指定数量
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="precision">缩减的目标有效数字数量（精度）</param>
	/// <param name="rounding">截断有效数字时是否进行四舍五入</param>
	/// <returns>处理后的数值</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException">有效数字（精度）<paramref name="precision" /> 小于1。</exception>
	public static decimal Fix(decimal value, int precision, bool rounding = true)
	{
		Guard.AssertGreaterThanOrEqualTo(precision, 1, "precision");
		int exponent = GetExponent(value);
		if (exponent > 0)
		{
			decimal factor = Pow(10m, exponent);
			value /= factor;
			value = (rounding ? Round(value, precision - 1) : Truncate(value, precision - 1));
			return value * factor;
		}
		if (exponent < 0)
		{
			decimal factor = Pow(10m, -exponent);
			value *= factor;
			value = (rounding ? Round(value, precision - 1) : Truncate(value, precision - 1));
			return value / factor;
		}
		value = (rounding ? Round(value, precision - 1) : Truncate(value, precision - 1));
		return value;
	}

	/// <summary>
	/// 获取当前数值的小数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的小数部分</returns>
	public static float GetDecimal(float value)
	{
		return (float)GetDecimal((double)value);
	}

	/// <summary>
	/// 获取当前数值的小数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的小数部分</returns>
	public static double GetDecimal(double value)
	{
		return value - Math.Truncate(value);
	}

	/// <summary>
	/// 获取当前数值的小数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的小数部分</returns>
	public static decimal GetDecimal(decimal value)
	{
		return value - decimal.Truncate(value);
	}

	/// <summary>
	/// 获取将当前数值使用科学记数法表示时的指数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的科学计数法指数</returns>
	public static int GetExponent(int value)
	{
		if (value > 0)
		{
			return (int)Math.Floor(Math.Log10(value));
		}
		if (value < 0)
		{
			return (int)Math.Floor(Math.Log10(Math.Abs(value)));
		}
		return 0;
	}

	/// <summary>
	/// 获取将当前数值使用科学记数法表示时的指数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的科学计数法指数</returns>
	public static int GetExponent(long value)
	{
		if (value > 0)
		{
			return (int)Math.Floor(Math.Log10(value));
		}
		if (value < 0)
		{
			return (int)Math.Floor(Math.Log10(Math.Abs(value)));
		}
		return 0;
	}

	/// <summary>
	/// 获取将当前数值使用科学记数法表示时的指数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的科学计数法指数</returns>
	public static int GetExponent(float value)
	{
		return GetExponent((double)value);
	}

	/// <summary>
	/// 获取将当前数值使用科学记数法表示时的指数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的科学计数法指数</returns>
	public static int GetExponent(double value)
	{
		if (value > 0.0)
		{
			return (int)Math.Floor(Math.Log10(value));
		}
		if (value < 0.0)
		{
			return (int)Math.Floor(Math.Log10(Math.Abs(value)));
		}
		return 0;
	}

	/// <summary>
	/// 获取将当前数值使用科学记数法表示时的指数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的科学计数法指数</returns>
	public static int GetExponent(decimal value)
	{
		if (value > 0m)
		{
			return (int)Math.Floor(Math.Log10((double)value));
		}
		if (value < 0m)
		{
			return (int)Math.Floor(Math.Log10((double)Math.Abs(value)));
		}
		return 0;
	}

	/// <summary>
	/// 获取当前数值的整数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的整数部分</returns>
	public static float GetInteger(float value)
	{
		return (float)GetInteger((double)value);
	}

	/// <summary>
	/// 获取当前数值的整数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的整数部分</returns>
	public static double GetInteger(double value)
	{
		return Math.Truncate(value);
	}

	/// <summary>
	/// 获取当前数值的整数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>当前数值的整数部分</returns>
	public static decimal GetInteger(decimal value)
	{
		return decimal.Truncate(value);
	}

	/// <summary>
	/// 获取数值精度（有效数字的个数）
	/// </summary>
	/// <param name="value">源数值</param>
	/// <returns>数值的精度</returns>
	public static int GetPrecision(int value)
	{
		int count = 0;
		for (value = Abs(value); value >= 1; value /= 10)
		{
			count++;
		}
		return count;
	}

	/// <summary>
	/// 获取数值精度（有效数字的个数）
	/// </summary>
	/// <param name="value">源数值</param>
	/// <returns>数值的精度</returns>
	public static int GetPrecision(long value)
	{
		int count = 0;
		for (value = Abs(value); value >= 1; value /= 10)
		{
			count++;
		}
		return count;
	}

	/// <summary>
	/// 获取数值精度（有效数字的个数）
	/// </summary>
	/// <param name="value">源数值</param>
	/// <returns>数值的精度</returns>
	public static int GetPrecision(float value)
	{
		return GetPrecision((double)value);
	}

	/// <summary>
	/// 获取数值精度（有效数字的个数）
	/// </summary>
	/// <param name="value">源数值</param>
	/// <returns>数值的精度</returns>
	public static int GetPrecision(double value)
	{
		int count = 0;
		value = Abs(value);
		double integer = GetInteger(value);
		double decimals = GetDecimal(value);
		while (integer >= 1.0)
		{
			count++;
			integer /= 10.0;
		}
		while (decimals < 1.0 && decimals != 0.0)
		{
			count++;
			decimals *= 10.0;
			decimals = GetDecimal(decimals);
		}
		return count;
	}

	/// <summary>
	/// 获取数值精度（有效数字的个数）
	/// </summary>
	/// <param name="value">源数值</param>
	/// <returns>数值的精度</returns>
	public static int GetPrecision(decimal value)
	{
		int count = 0;
		value = Abs(value);
		decimal integer = GetInteger(value);
		decimal decimals = GetDecimal(value);
		for (; integer >= 1m; integer /= 10m)
		{
			count++;
		}
		while (decimals < 1m && decimals != 0m)
		{
			count++;
			decimals *= 10m;
			decimals = GetDecimal(decimals);
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
	/// <returns>如果当前数值等于目标值或者偏差小于指定值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsEqualTo(float value, float target, int level = -7, int delta = 1)
	{
		return IsEqualTo((double)value, (double)target, level, delta);
	}

	/// <summary>
	/// 比较当前数值和目标数值是否相等，如果两个数值之间的偏差小于指定值，则视为相等
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值等于目标值或者偏差小于指定值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsEqualTo(float value, float target, float deviation)
	{
		return IsEqualTo((double)value, (double)target, (double)deviation);
	}

	/// <summary>
	/// 比较当前数值和目标数值是否相等，如果两个数值之间的偏差小于指定的数量级，则认为相等
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则两个数值必须严格相等</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值等于目标值或者偏差小于指定值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsEqualTo(double value, double target, int level = -15, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value == target;
		}
		return IsEqualTo(value, target, Pow(10.0, (level > 0) ? (level - 1) : level) * (double)delta);
	}

	/// <summary>
	/// 比较当前数值和目标数值是否相等，如果两个数值之间的偏差小于指定值，则视为相等
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值等于目标值或者偏差小于指定值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsEqualTo(double value, double target, double deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0.0, "deviation");
		return Abs(value - target) < deviation;
	}

	/// <summary>
	/// 比较当前数值和目标数值是否相等，如果两个数值之间的偏差小于指定的数量级，则认为相等
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则两个数值必须严格相等</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值等于目标值或者偏差小于指定值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsEqualTo(decimal value, decimal target, int level = -28, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value == target;
		}
		return IsEqualTo(value, target, Pow(10m, (level > 0) ? (level - 1) : level) * (decimal)delta);
	}

	/// <summary>
	/// 比较当前数值和目标数值是否相等，如果两个数值之间的偏差小于指定值，则视为相等
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值等于目标值或者偏差小于指定值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsEqualTo(decimal value, decimal target, decimal deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0m, "deviation");
		return Abs(value - target) < deviation;
	}

	/// <summary>
	/// 判断当前数值是否是偶数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值是偶数返回true，否则返回false</returns>
	public static bool IsEven(BigInteger value)
	{
		return value.IsEven;
	}

	/// <summary>
	/// 判断当前数值是否是偶数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值是偶数返回true，否则返回false</returns>
	public static bool IsEven(int value)
	{
		return value % 2 == 0;
	}

	/// <summary>
	/// 判断当前数值是否是偶数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值是偶数返回true，否则返回false</returns>
	public static bool IsEven(long value)
	{
		return value % 2 == 0;
	}

	/// <summary>
	/// 判断当前数值是否是偶数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值是偶数返回true，否则返回false</returns>
	public static bool IsEven(float value)
	{
		return IsEven((double)value);
	}

	/// <summary>
	/// 判断当前数值是否是偶数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值是偶数返回true，否则返回false</returns>
	public static bool IsEven(double value)
	{
		return Math.IEEERemainder(value, 2.0) == 0.0;
	}

	/// <summary>
	/// 判断当前数值是否是偶数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值是偶数返回true，否则返回false</returns>
	public static bool IsEven(decimal value)
	{
		return decimal.Remainder(value, 2m) == 0m;
	}

	/// <summary>
	/// 判断当前数值是否大于目标值，如果指定值与目标值的偏差大于等于指定的数量级才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格大于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值大于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsGreaterThan(float value, float target, int level = -7, int delta = 1)
	{
		return IsGreaterThan((double)value, (double)target, level, delta);
	}

	/// <summary>
	/// 判断当前数值是否大于目标值，如果指定值与目标值的偏差大于等于指定值才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值大于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsGreaterThan(float value, float target, float deviation)
	{
		return IsGreaterThan((double)value, (double)target, (double)deviation);
	}

	/// <summary>
	/// 判断当前数值是否大于目标值，如果指定值与目标值的偏差大于等于指定的数量级才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格大于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值大于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsGreaterThan(double value, double target, int level = -15, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value > target;
		}
		return IsGreaterThan(value, target, Pow(10.0, (level > 0) ? (level - 1) : level) * (double)delta);
	}

	/// <summary>
	/// 判断当前数值是否大于目标值，如果指定值与目标值的偏差大于等于指定值才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值大于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsGreaterThan(double value, double target, double deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0.0, "deviation");
		return value - target >= deviation;
	}

	/// <summary>
	/// 判断当前数值是否大于目标值，如果指定值与目标值的偏差大于等于指定的数量级才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格大于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值大于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsGreaterThan(decimal value, decimal target, int level = -28, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value > target;
		}
		return IsGreaterThan(value, target, Pow(10m, (level > 0) ? (level - 1) : level) * (decimal)delta);
	}

	/// <summary>
	/// 判断当前数值是否大于目标值，如果指定值与目标值的偏差大于等于指定值才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值大于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsGreaterThan(decimal value, decimal target, decimal deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0m, "deviation");
		return value - target >= deviation;
	}

	/// <summary>
	/// 判断当前数值是否大于或者等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格大于或者等于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值大于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsGreaterThanOrEqualTo(float value, float target, int level = -7, int delta = 1)
	{
		return IsGreaterThanOrEqualTo((double)value, (double)target, level, delta);
	}

	/// <summary>
	/// 判断当前数值是否大于或者等于目标值；如果两个数值的误差小于指定值，则认为相等；如果指定值与目标值的偏差大于等于指定值才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值大于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsGreaterThanOrEqualTo(float value, float target, float deviation)
	{
		return IsGreaterThanOrEqualTo((double)value, (double)target, (double)deviation);
	}

	/// <summary>
	/// 判断当前数值是否大于或者等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格大于或者等于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值大于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsGreaterThanOrEqualTo(double value, double target, int level = -15, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value > target;
		}
		return IsGreaterThanOrEqualTo(value, target, Pow(10.0, (level > 0) ? (level - 1) : level) * (double)delta);
	}

	/// <summary>
	/// 判断当前数值是否大于或者等于目标值；如果两个数值的误差小于指定值，则认为相等；如果指定值与目标值的偏差大于等于指定值才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值大于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsGreaterThanOrEqualTo(double value, double target, double deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0.0, "deviation");
		double diff = value - target;
		return Abs(diff) < deviation || diff >= deviation;
	}

	/// <summary>
	/// 判断当前数值是否大于或者等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格大于或者等于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值大于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsGreaterThanOrEqualTo(decimal value, decimal target, int level = -28, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value > target;
		}
		return IsGreaterThanOrEqualTo(value, target, Pow(10m, (level > 0) ? (level - 1) : level) * (decimal)delta);
	}

	/// <summary>
	/// 判断当前数值是否大于或者等于目标值；如果两个数值的误差小于指定值，则认为相等；如果指定值与目标值的偏差大于等于指定值才视为大于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值大于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsGreaterThanOrEqualTo(decimal value, decimal target, decimal deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0m, "deviation");
		decimal diff = value - target;
		return Abs(diff) < deviation || diff >= deviation;
	}

	/// <summary>
	/// 检测当前数值是否为整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值为整数则返回true，否则返回false。</returns>
	public static bool IsInteger(float value)
	{
		return GetDecimal(value) == 0f;
	}

	/// <summary>
	/// 检测当前数值是否为整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值为整数则返回true，否则返回false。</returns>
	public static bool IsInteger(double value)
	{
		return GetDecimal(value) == 0.0;
	}

	/// <summary>
	/// 检测当前数值是否为整数
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>如果当前数值为整数则返回true，否则返回false。</returns>
	public static bool IsInteger(decimal value)
	{
		return GetDecimal(value) == 0m;
	}

	/// <summary>
	/// 判断当前数值是否小于目标值，如果指定值与目标值的偏差大于等于指定值才成立
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格小于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值小于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsLessThan(float value, float target, int level = -7, int delta = 1)
	{
		return IsLessThan((double)value, (double)target, level, delta);
	}

	/// <summary>
	/// 判断当前数值是否小于目标值，如果指定值与目标值的偏差大于等于指定值才成立
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值小于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsLessThan(float value, float target, float deviation)
	{
		return IsLessThan((double)value, (double)target, (double)deviation);
	}

	/// <summary>
	/// 判断当前数值是否小于目标值，如果指定值与目标值的偏差大于等于指定值才成立
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格小于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值小于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsLessThan(double value, double target, int level = -15, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value < target;
		}
		return IsLessThan(value, target, Pow(10.0, (level > 0) ? (level - 1) : level) * (double)delta);
	}

	/// <summary>
	/// 判断当前数值是否小于目标值，如果指定值与目标值的偏差大于等于指定值才成立
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值小于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsLessThan(double value, double target, double deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0.0, "deviation");
		double diff = value - target;
		return diff <= 0.0 - deviation;
	}

	/// <summary>
	/// 判断当前数值是否小于目标值，如果指定值与目标值的偏差大于等于指定值才成立
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格小于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值小于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsLessThan(decimal value, decimal target, int level = -28, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value < target;
		}
		return IsLessThan(value, target, Pow(10m, (level > 0) ? (level - 1) : level) * (decimal)delta);
	}

	/// <summary>
	/// 判断当前数值是否小于目标值，如果指定值与目标值的偏差大于等于指定值才成立
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值小于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsLessThan(decimal value, decimal target, decimal deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0m, "deviation");
		decimal diff = value - target;
		return diff <= -deviation;
	}

	/// <summary>
	/// 判断当前数值是否小于等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为小于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格小于等于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值小于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsLessThanOrEqualTo(float value, float target, int level = -7, int delta = 1)
	{
		return IsLessThanOrEqualTo((double)value, (double)target, level, delta);
	}

	/// <summary>
	/// 判断当前数值是否小于等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为小于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值小于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsLessThanOrEqualTo(float value, float target, float deviation)
	{
		return IsLessThanOrEqualTo((double)value, (double)target, (double)deviation);
	}

	/// <summary>
	/// 判断当前数值是否小于等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为小于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格小于等于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值小于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsLessThanOrEqualTo(double value, double target, int level = -15, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value < target;
		}
		return IsLessThanOrEqualTo(value, target, Pow(10.0, (level > 0) ? (level - 1) : level) * (double)delta);
	}

	/// <summary>
	/// 判断当前数值是否小于等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为小于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值小于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsLessThanOrEqualTo(double value, double target, double deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0.0, "deviation");
		double diff = value - target;
		return Abs(diff) < deviation || diff <= 0.0 - deviation;
	}

	/// <summary>
	/// 判断当前数值是否小于等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为小于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="level">比较时误差的数量级；设置为0，则当前数值必须严格小于等于目标数值</param>
	/// <param name="delta">误差增量</param>
	/// <returns>如果当前数值小于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="delta" /> 小于等于零。</exception>
	public static bool IsLessThanOrEqualTo(decimal value, decimal target, int level = -28, int delta = 1)
	{
		Guard.AssertGreaterThanOrEqualTo(delta, 1, "delta");
		if (level == 0)
		{
			return value < target;
		}
		return IsLessThanOrEqualTo(value, target, Pow(10m, (level > 0) ? (level - 1) : level) * (decimal)delta);
	}

	/// <summary>
	/// 判断当前数值是否小于等于目标值；如果两个数值的误差小于指定的数量级，则认为相等；如果指定值与目标值的偏差大于等于指定的数量级才视为小于目标值
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="target">比较的目标数值</param>
	/// <param name="deviation">比较误差</param>
	/// <returns>如果当前数值小于等于目标值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="deviation" /> 小于零。</exception>
	public static bool IsLessThanOrEqualTo(decimal value, decimal target, decimal deviation)
	{
		Guard.AssertGreaterThanOrEqualTo(deviation, 0m, "deviation");
		decimal diff = value - target;
		return Abs(diff) < deviation || diff <= -deviation;
	}

	/// <summary>
	/// 判断当前数值是否是奇数
	/// </summary>
	/// <param name="value">当前待检测的数值</param>
	/// <returns>如果是奇数返回true，否则返回false</returns>
	public static bool IsOdd(BigInteger value)
	{
		return !value.IsEven;
	}

	/// <summary>
	/// 判断当前数值是否是奇数
	/// </summary>
	/// <param name="value">当前待检测的数值</param>
	/// <returns>如果是奇数返回true，否则返回false</returns>
	public static bool IsOdd(int value)
	{
		return value % 2 != 0;
	}

	/// <summary>
	/// 判断当前数值是否是奇数
	/// </summary>
	/// <param name="value">当前待检测的数值</param>
	/// <returns>如果是奇数返回true，否则返回false</returns>
	public static bool IsOdd(long value)
	{
		return value % 2 != 0;
	}

	/// <summary>
	/// 判断当前数值是否是奇数
	/// </summary>
	/// <param name="value">当前待检测的数值</param>
	/// <returns>如果是奇数返回true，否则返回false</returns>
	public static bool IsOdd(float value)
	{
		return IsOdd((double)value);
	}

	/// <summary>
	/// 判断当前数值是否是奇数
	/// </summary>
	/// <param name="value">当前待检测的数值</param>
	/// <returns>如果是奇数返回true，否则返回false</returns>
	public static bool IsOdd(double value)
	{
		return Math.IEEERemainder(value, 2.0) != 0.0;
	}

	/// <summary>
	/// 判断当前数值是否是奇数
	/// </summary>
	/// <param name="value">当前待检测的数值</param>
	/// <returns>如果是奇数返回true，否则返回false</returns>
	public static bool IsOdd(decimal value)
	{
		return decimal.Remainder(value, 2m) != 0m;
	}

	/// <summary>
	/// 计算以当前数组值为上限的，各维度从零开始的数值的排列组合
	/// </summary>
	/// <param name="weight">当前数组</param>
	/// <returns>排列组合序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static IEnumerable<int[]> Permute(int[] weight)
	{
		Guard.AssertNotNull(weight, "weight");
		int[] dimension = new int[weight.Length];
		do
		{
			int[] temp = new int[weight.Length];
			Array.Copy(dimension, temp, dimension.Length);
			yield return temp;
		}
		while (PermuteIncrease(dimension, weight));
	}

	/// <summary>
	/// 计算以当前数组值为上限的，各维度从零开始的数值的排列组合
	/// </summary>
	/// <param name="weight">当前数组</param>
	/// <returns>排列组合序列</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static IEnumerable<long[]> Permute(long[] weight)
	{
		Guard.AssertNotNull(weight, "weight");
		long[] dimension = new long[weight.Length];
		do
		{
			long[] temp = new long[weight.Length];
			Array.Copy(dimension, temp, dimension.Length);
			yield return temp;
		}
		while (PermuteIncrease(dimension, weight));
	}

	/// <summary>
	/// 递增排列数组
	/// </summary>
	/// <param name="dimension">当前递增的数组</param>
	/// <param name="max">递增数组的上限</param>
	/// <returns>如果递增成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="max" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="max" /> 的元素个数不等于 <paramref name="dimension" /> 的元素个数。</exception>
	public static bool PermuteIncrease(int[] dimension, int[] max)
	{
		Guard.AssertNotNull(dimension, "dimension");
		Guard.AssertNotNull(max, "max");
		Guard.Assert(dimension.Length == max.Length, "dimension & max");
		for (int i = 0; i < dimension.Length; i++)
		{
			if (++dimension[i] < max[i])
			{
				return true;
			}
			dimension[i] = 0;
		}
		return false;
	}

	/// <summary>
	/// 递增排列数组
	/// </summary>
	/// <param name="dimension">当前递增的数组</param>
	/// <param name="max">递增数组的上限</param>
	/// <returns>如果递增成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空；<paramref name="max" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="max" /> 的元素个数不等于 <paramref name="dimension" /> 的元素个数。</exception>
	public static bool PermuteIncrease(long[] dimension, long[] max)
	{
		Guard.AssertNotNull(dimension, "dimension");
		Guard.AssertNotNull(max, "max");
		Guard.Assert(dimension.Length == max.Length, "dimension & max");
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
	public static bool PermuteDecrease(int[] dimension, int[] origin = null)
	{
		Guard.AssertNotNull(dimension, "dimension");
		if (ObjectHelper.IsNull(origin))
		{
			origin = new int[dimension.Length];
			Array.Copy(dimension, origin, dimension.Length);
		}
		Guard.Assert(dimension.Length == origin.Length, "dimension & origin");
		for (int i = 0; i < dimension.Length; i++)
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
	/// 递减排列数组
	/// </summary>
	/// <param name="dimension">当前递减的数组</param>
	/// <param name="origin">递减数组的原始值</param>
	/// <returns>如果递减成功返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="origin" /> 不为空，且 <paramref name="origin" /> 的元素个数不等于 <paramref name="dimension" /> 的元素个数。</exception>
	public static bool PermuteDecrease(long[] dimension, long[] origin = null)
	{
		Guard.AssertNotNull(dimension, "dimension");
		if (ObjectHelper.IsNull(origin))
		{
			origin = new long[dimension.Length];
			Array.Copy(dimension, origin, dimension.Length);
		}
		Guard.Assert(dimension.Length == origin.Length, "dimension & origin");
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
	public static int[] RadixParse(int value, int[] weight, int radix = 1)
	{
		Guard.AssertNotNullAndEmpty(weight, "weight");
		Array.ForEach(weight, delegate(int x)
		{
			Guard.AssertGreaterThan(x, 0, "weight", Literals.MSG_RadixParseWeigthsOutOfRange);
		});
		Guard.AssertGreaterThanOrEqualTo(radix, 1, "radix");
		int[] weightValue = new int[weight.Length];
		weightValue[0] = radix;
		for (int i = 1; i < weightValue.Length; i++)
		{
			weightValue[i] = weight[i - 1] * weightValue[i - 1];
		}
		int sign = Math.Sign(value);
		value = Math.Abs(value);
		int[] result = new int[weight.Length];
		for (int i = result.Length - 1; i >= 0; i--)
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
	/// 按指定的各个整数位的权重，对当前整型值进行分解
	/// </summary>
	/// <param name="value">当前整型值</param>
	/// <param name="weight">分解权重</param>
	/// <param name="radix">分解基数</param>
	/// <returns>分解后各个整数位的值的数组</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="weight" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="weight" /> 的元素个数小于1。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="weight" /> 的某个元素小于等于0；或者 <paramref name="radix" /> 小于1。</exception>
	public static long[] RadixParse(long value, long[] weight, long radix = 1L)
	{
		Guard.AssertNotNullAndEmpty(weight, "weight");
		Array.ForEach(weight, delegate(long x)
		{
			Guard.AssertGreaterThan(x, 0L, "weight", Literals.MSG_RadixParseWeigthsOutOfRange);
		});
		Guard.AssertGreaterThanOrEqualTo(radix, 1L, "radix");
		long[] weightValue = new long[weight.Length];
		weightValue[0] = radix;
		for (long i = 1L; i < weightValue.Length; i++)
		{
			weightValue[i] = weight[i - 1] * weightValue[i - 1];
		}
		long sign = Math.Sign(value);
		value = Math.Abs(value);
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
	public static int RadixSum(int[] value, int[] weight, int radix = 1)
	{
		Guard.AssertNotNullAndEmpty(value, "value");
		Guard.AssertNotNullAndEmpty(weight, "weight");
		Array.ForEach(weight, delegate(int x)
		{
			Guard.AssertGreaterThan(x, 0, "weight", Literals.MSG_RadixParseWeigthsOutOfRange);
		});
		Guard.AssertGreaterThanOrEqualTo(radix, 1, "radix");
		int[] weightValue = new int[weight.Length];
		weightValue[0] = radix;
		for (int i = 1; i < weightValue.Length; i++)
		{
			weightValue[i] = weight[i - 1] * weightValue[i - 1];
		}
		int sign = Math.Sign(value[^1]);
		value[^1] = Math.Abs(value[^1]);
		int result = 0;
		for (int i = 0; i < value.Length; i++)
		{
			result += value[i] * weight[i] * weightValue[i];
		}
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
	public static long RadixSum(long[] value, long[] weight, long radix = 1L)
	{
		Guard.AssertNotNullAndEmpty(value, "value");
		Guard.AssertNotNullAndEmpty(weight, "weight");
		Array.ForEach(weight, delegate(long x)
		{
			Guard.AssertGreaterThan(x, 0L, "weight", Literals.MSG_RadixParseWeigthsOutOfRange);
		});
		Guard.AssertGreaterThanOrEqualTo(radix, 1L, "radix");
		long[] weightValue = new long[weight.Length];
		weightValue[0] = radix;
		for (long i = 1L; i < weightValue.Length; i++)
		{
			weightValue[i] = weight[i - 1] * weightValue[i - 1];
		}
		long sign = Math.Sign(value[^1]);
		value[^1] = Math.Abs(value[^1]);
		long result = 0L;
		for (long i = 0L; i < value.Length; i++)
		{
			result += value[i] * weight[i] * weightValue[i];
		}
		return result;
	}

	/// <summary>
	/// 将当前数值分解为整数和小数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>分解后的两个元素的数组，第一个元素为整数部分，第二个元素为小数部分</returns>
	public static float[] SplitNumber(float value)
	{
		return new float[2]
		{
			GetInteger(value),
			GetDecimal(value)
		};
	}

	/// <summary>
	/// 将当前数值分解为整数和小数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>分解后的两个元素的数组，第一个元素为整数部分，第二个元素为小数部分</returns>
	public static double[] SplitNumber(double value)
	{
		return new double[2]
		{
			GetInteger(value),
			GetDecimal(value)
		};
	}

	/// <summary>
	/// 将当前数值分解为整数和小数部分
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>分解后的两个元素的数组，第一个元素为整数部分，第二个元素为小数部分</returns>
	public static decimal[] SplitNumber(decimal value)
	{
		return new decimal[2]
		{
			GetInteger(value),
			GetDecimal(value)
		};
	}
}
