using System;
using System.Collections.Generic;
using Richfit.Garnet.Common.Collections;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.IComparable`1" /> 类型扩展方法类
/// </summary>
public static class IComparableTExtensions
{
	/// <summary>
	/// 判断当前对象值是否介于两个对象值之间
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果当前对象介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static bool Between<T>(this IComparable<T> value, T min, T max, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		value.GuardNotNull("value");
		min.GuardLessThanOrEqualTo(max, "min & max", Literals.MSG_ValueRangeMinGreaterThanMax);
		return (value.CompareTo(min) > 0 && value.CompareTo(max) < 0) || (includeMin && value.CompareTo(min) == 0) || (includeMax && value.CompareTo(max) == 0);
	}

	/// <summary>
	/// 判断当前对象值是否不介于两个对象值之间
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="value">当前对象</param>
	/// <param name="min">值范围的最小值</param>
	/// <param name="max">值范围的最大值</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果当前对象介于最大值和最小值之间返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static bool NotBetween<T>(this IComparable<T> value, T min, T max, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		return !value.Between(min, max, includeMin, includeMax);
	}

	/// <summary>
	/// 将当前对象按照指定的比较方式与目标对象进行比较，如果满足指定的比较方式的条件，返回true；如果不满足则返回false。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="target">待比较的目标对象</param>
	/// <param name="comparison">指定的比较方式</param>
	/// <returns>如果当前对象满足比较方式指定的条件返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool CompareTo<T>(this IComparable<T> item, T target, ComparisonMode comparison)
	{
		item.GuardNotNull("item");
		int result = item.CompareTo(target);
		bool flag = false;
		if (!flag && comparison.HasFlag(ComparisonMode.Equal))
		{
			flag = result == 0;
		}
		if (!flag && comparison.HasFlag(ComparisonMode.GreaterThan))
		{
			flag = result > 0;
		}
		if (!flag && comparison.HasFlag(ComparisonMode.LessThan))
		{
			flag = result < 0;
		}
		flag.GuardTrue("comparsion");
		if (comparison.HasFlag(ComparisonMode.Not))
		{
			flag = !flag;
		}
		return flag;
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象超出指定的范围；或者值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static T GuardBetween<T>(this IComparable<T> item, T min, T max, string name = null, string message = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		item.Guard(item.Between(min, max, includeMin, includeMax), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueOutOfRange)));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardBetween<T>(this IComparable<T> item, T min, T max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		item.Guard(item.Between(min, max, includeMin, includeMax), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否在指定范围内，超出指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象超出指定的范围，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardBetween<T>(this IComparable<T> item, T min, T max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		item.Guard(item.Between(min, max, includeMin, includeMax), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">错误消息</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在指定的范围中；或者值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	public static T GuardNotBetween<T>(this IComparable<T> item, T min, T max, string name = null, string message = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		item.Guard(item.NotBetween(min, max, includeMin, includeMax), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueInRange)));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotBetween<T>(this IComparable<T> item, T min, T max, Func<Exception> exceptionCreator, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		item.Guard(item.NotBetween(min, max, includeMin, includeMax), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不在指定范围内，在指定的值范围则抛出参数 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="min">最小值</param>
	/// <param name="max">最大值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <param name="includeMin">值范围是否包含最小值，默认包含最小值</param>
	/// <param name="includeMax">值范围是否包含最大值，默认包含最大值</param>
	/// <returns>如果检测通过则返回当前对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">值范围最小值 <paramref name="min" /> 大于最大值 <paramref name="max" /></exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在指定的范围中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotBetween<T>(this IComparable<T> item, T min, T max, Type exceptionType, object[] args = null, bool includeMin = true, bool includeMax = true) where T : IComparable<T>
	{
		item.Guard(item.NotBetween(min, max, includeMin, includeMax), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不等于 <paramref name="value" /> 时。</exception>
	public static T GuardEqualTo<T>(this IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		item.Guard(item.IsEqualTo(value), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotEqualToTarget_1.FormatValue(value))));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardEqualTo<T>(this IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		item.Guard(item.IsEqualTo(value), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否等于指定值，如果不等于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值不等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardEqualTo<T>(this IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		item.Guard(item.IsEqualTo(value), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象等于 <paramref name="value" /> 时。</exception>
	public static T GuardNotEqualTo<T>(this IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		item.Guard(item.IsNotEqualTo(value), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueEqualToTarget_1.FormatValue(value))));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象的类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回null。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotEqualTo<T>(this IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		item.Guard(item.IsNotEqualTo(value), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不等于指定值，如果等于指定值则抛出  <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotEqualTo<T>(this IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		item.Guard(item.IsNotEqualTo(value), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象的值小于等于 <paramref name="value" /> 的值。</exception>
	public static T GuardGreaterThan<T>(this IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		item.Guard(item.IsGreaterThan(value), name.IfNull("item"), message.IfNull(Literals.MSG_ValueLessThanOrEqualToTarget_1.FormatValue(value)));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardGreaterThan<T>(this IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		item.Guard(item.IsGreaterThan(value), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否大于指定值，如果不大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardGreaterThan<T>(this IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		item.Guard(item.IsGreaterThan(value), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象小于 <paramref name="value" /> 时。</exception>
	public static T GuardGreaterThanOrEqualTo<T>(this IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		item.Guard(item.IsGreaterThanOrEqualTo(value), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueLessThanTarget_1.FormatValue(value))));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardGreaterThanOrEqualTo<T>(this IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		item.Guard(item.IsGreaterThanOrEqualTo(value), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否大于等于指定值，如果小于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值小于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardGreaterThanOrEqualTo<T>(this IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		item.Guard(item.IsGreaterThanOrEqualTo(value), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象不在给定的值列表 <paramref name="values" /> 中。</exception>
	public static T GuardIn<T>(this IComparable<T> item, IEnumerable<T> values, string name = null, string message = null) where T : IComparable<T>
	{
		item.Guard(item.In(values), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueNotInTargets)));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardIn<T>(this IComparable<T> item, IEnumerable<T> values, Func<Exception> exceptionCreator)
	{
		item.Guard(item.In(values), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否是指定值之一，如果不等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型<paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象不在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardIn<T>(this IComparable<T> item, IEnumerable<T> values, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		item.Guard(item.In(values), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象在给定的值列表 <paramref name="values" /> 中。</exception>
	public static T GuardNotIn<T>(this IComparable<T> item, IEnumerable<T> values, string name = null, string message = null) where T : IComparable<T>
	{
		item.Guard(item.NotIn(values), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueInTargets)));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardNotIn<T>(this IComparable<T> item, IEnumerable<T> values, Func<Exception> exceptionCreator)
	{
		item.Guard(item.NotIn(values), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否不是指定值，如果等于任何指定的值，则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">检测的指定值列表</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回对象本身</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象在给定的值列表 <paramref name="values" /> 中，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardNotIn<T>(this T item, IEnumerable<T> values, Type exceptionType, params object[] args)
	{
		item.Guard(item.NotIn(values), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于等于 <paramref name="value" /> 时。</exception>
	public static T GuardLessThan<T>(this IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		item.Guard(item.IsLessThan(value), () => new ArgumentOutOfRangeException(name.IfNull("item"), message.IfNull(Literals.MSG_ValueGreaterThanOrEqualToTarget_1.FormatValue(value))));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常生成方法 <paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardLessThan<T>(this IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		item.Guard(item.IsLessThan(value), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否小于指定值，如果不小于指定值则抛出抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于等于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardLessThan<T>(this IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		item.Guard(item.IsLessThan(value), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <see cref="T:System.ArgumentOutOfRangeException" /> 异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="name">对象名称</param>
	/// <param name="message">异常信息</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">当前对象大于 <paramref name="value" /> 的值。</exception>
	public static T GuardLessThanOrEqualTo<T>(this IComparable<T> item, T value, string name = null, string message = null) where T : IComparable<T>
	{
		item.Guard(item.IsLessThanOrEqualTo(value), () => new ArgumentOutOfRangeException(name.IfNull("items"), message.IfNull(Literals.MSG_ValueGreaterThanTarget_1.FormatValue(value))));
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionCreator" /> 生成的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionCreator">异常生成方法</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常生成方法 <paramref name="exceptionCreator" /> 为空。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException"><paramref name="exceptionCreator" /> 执行异常或者返回空。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionCreator" /> 生成的异常。</exception>
	public static T GuardLessThanOrEqualTo<T>(this IComparable<T> item, T value, Func<Exception> exceptionCreator) where T : IComparable<T>
	{
		item.Guard(item.IsLessThanOrEqualTo(value), exceptionCreator);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否小于等于指定值，如果大于指定值则抛出 <paramref name="exceptionType" /> 指定的异常
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <param name="exceptionType">异常类型</param>
	/// <param name="args">异常参数</param>
	/// <returns>如果检测通过则返回原对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者异常类型 <paramref name="exceptionType" /> 为空。</exception>
	/// <exception cref="T:System.NotSupportedException">异常类型 <paramref name="exceptionType" /> 不是继承于 <see cref="T:System.Exception" />。</exception>
	/// <exception cref="T:System.Reflection.TargetInvocationException">异常类型 <paramref name="exceptionType" /> 无法创建实例。</exception>
	/// <exception cref="T:System.Exception">当前对象的值大于 <paramref name="value" /> 的值，则抛出 <paramref name="exceptionType" /> 指定的异常。</exception>
	public static T GuardLessThanOrEqualTo<T>(this IComparable<T> item, T value, Type exceptionType, params object[] args) where T : IComparable<T>
	{
		item.Guard(item.IsLessThanOrEqualTo(value), exceptionType, args);
		return item.As<T>();
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者值列表 <paramref name="values" /> 为空。</exception>
	public static bool In<T>(this IComparable<T> item, params T[] values)
	{
		return item.In((IEnumerable<T>)values);
	}

	/// <summary>
	/// 检测当前对象是否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者值列表 <paramref name="values" /> 为空。</exception>
	public static bool In<T>(this IComparable<T> item, IEnumerable<T> values)
	{
		item.GuardNotNull("item");
		values.GuardNotNull("Values");
		foreach (T value in values)
		{
			if (item.CompareTo(value) == 0)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 检测当前对象是不否存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn<T>(this IComparable<T> item, params T[] values)
	{
		return !item.In(values);
	}

	/// <summary>
	/// 检测当前对象是否不存在于给定的值列表中
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="values">给定的值列表</param>
	/// <returns>如果当前对象不存在于值列表中返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空；或者值列表 <paramref name="values" /> 为空。</exception>
	public static bool NotIn<T>(this IComparable<T> item, IEnumerable<T> values)
	{
		return !item.In(values);
	}

	/// <summary>
	/// 检测当前对象是否等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">比较目标对象</param>
	/// <returns>如果当前对象等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsEqualTo<T>(this IComparable<T> item, T value)
	{
		item.GuardNotNull("item");
		return item.CompareTo(value) == 0;
	}

	/// <summary>
	/// 检测当前对象是否不等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象不等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsNotEqualTo<T>(this IComparable<T> item, T value)
	{
		item.GuardNotNull("item");
		return item.CompareTo(value) != 0;
	}

	/// <summary>
	/// 检测当前对象是否大于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象大于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsGreaterThan<T>(this IComparable<T> item, T value)
	{
		item.GuardNotNull("item");
		return item.CompareTo(value) > 0;
	}

	/// <summary>
	/// 检测当前对象是否大于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象大于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsGreaterThanOrEqualTo<T>(this IComparable<T> item, T value)
	{
		item.GuardNotNull("item");
		return item.CompareTo(value) >= 0;
	}

	/// <summary>
	/// 检测当前对象是否小于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象小于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsLessThan<T>(this IComparable<T> item, T value)
	{
		item.GuardNotNull("item");
		return item.CompareTo(value) < 0;
	}

	/// <summary>
	/// 检测当前对象是否小于等于 <paramref name="value" /> 的值
	/// </summary>
	/// <typeparam name="T">当前对象类型</typeparam>
	/// <param name="item">当前对象</param>
	/// <param name="value">检测的基准值</param>
	/// <returns>如果当前对象小于等于 <paramref name="value" /> 的值返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException">当前对象为空。</exception>
	public static bool IsLessThanOrEqualTo<T>(this IComparable<T> item, T value)
	{
		item.GuardNotNull("item");
		return item.CompareTo(value) <= 0;
	}
}
