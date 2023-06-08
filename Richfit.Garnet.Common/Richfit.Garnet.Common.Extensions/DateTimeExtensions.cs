using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Extensions;

/// <summary>
/// <see cref="T:System.DateTime" /> 类型的扩展方法
///
/// 包括：
/// 1. DateTime类型的扩展方法
/// 2. 以DateTime类型为约束的泛型的扩展方法
/// 3. DateTime类型数组或者泛型数组的扩展方法
/// 4. 以DateTime类型为约束的泛型或者泛型数组的扩展方法
/// </summary>
public static class DateTimeExtensions
{
	/// <summary>
	/// 在指定日期上增加指定的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="days">增加的天数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="provider" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime AddDays(this DateTime date, int days, IFormatProvider provider)
	{
		provider.GuardNotNull("provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.AddDays(days, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="days">增加的天数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddDays(this DateTime date, int days, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.AddDays(date, days).SpecifyKind(date.Kind);
	}

	/// <summary>
	/// 在指定日期上增加指定的小时数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="hours">增加的小时数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="provider" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime AddHours(this DateTime date, int hours, IFormatProvider provider)
	{
		provider.GuardNotNull("provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.AddHours(hours, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的小时数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="hours">增加的小时数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddHours(this DateTime date, int hours, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.AddHours(date, hours).SpecifyKind(date.Kind);
	}

	/// <summary>
	/// 在指定日期上增加指定的毫秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="milliseconds">增加的毫秒数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="provider" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime AddMilliseconds(this DateTime date, double milliseconds, IFormatProvider provider)
	{
		provider.GuardNotNull("provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.AddMilliseconds(milliseconds, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的毫秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="milliseconds">增加的毫秒数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddMilliseconds(this DateTime date, double milliseconds, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.AddMilliseconds(date, milliseconds).SpecifyKind(date.Kind);
	}

	/// <summary>
	/// 在指定日期上增加指定的分钟数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="minutes">增加的分钟数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="provider" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime AddMinutes(this DateTime date, int minutes, IFormatProvider provider)
	{
		provider.GuardNotNull("provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.AddMinutes(minutes, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的分钟数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="minutes">增加的分钟数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddMinutes(this DateTime date, int minutes, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.AddMinutes(date, minutes).SpecifyKind(date.Kind);
	}

	/// <summary>
	/// 在指定日期上增加指定的月数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="months">增加的月数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="provider" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime AddMonths(this DateTime date, int months, IFormatProvider provider)
	{
		provider.GuardNotNull("provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.AddMonths(months, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的月数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="months">增加的月数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddMonths(this DateTime date, int months, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.AddMonths(date, months).SpecifyKind(date.Kind);
	}

	/// <summary>
	/// 在指定日期上增加指定的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="seconds">增加的秒数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="provider" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime AddSeconds(this DateTime date, int seconds, IFormatProvider provider)
	{
		provider.GuardNotNull("provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.AddSeconds(seconds, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="seconds">增加的秒数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddSeconds(this DateTime date, int seconds, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.AddSeconds(date, seconds).SpecifyKind(date.Kind);
	}

	/// <summary>
	/// 在指定日期上增加指定的周数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="weeks">增加的周数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="provider" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime AddWeeks(this DateTime date, int weeks, IFormatProvider provider)
	{
		provider.GuardNotNull("provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.AddWeeks(weeks, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的周数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="weeks">增加的周数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddWeeks(this DateTime date, int weeks, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.AddWeeks(date, weeks).SpecifyKind(date.Kind);
	}

	/// <summary>
	/// 在指定日期上增加指定的年数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="years">增加的年数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="provider" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime AddYears(this DateTime date, int years, IFormatProvider provider)
	{
		provider.GuardNotNull("provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.AddYears(years, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的年数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="years">增加的年数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddYears(this DateTime date, int years, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.AddYears(date, years).SpecifyKind(date.Kind);
	}

	/// <summary>
	/// 将指定日期转换为本地时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>转换后的本地时间</returns>
	/// <remarks>本方法调用 <see cref="M:System.DateTime.SpecifyKind(System.DateTime,System.DateTimeKind)" /> 方法改变指定日期的 <see cref="P:System.DateTime.Kind" /> 属性；不改变当前时间的值。</remarks>
	public static DateTime AsLocal(this DateTime date)
	{
		return date.SpecifyKind(DateTimeKind.Local);
	}

	/// <summary>
	/// 将指定日期转换为非特定时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>本方法调用 <see cref="M:System.DateTime.SpecifyKind(System.DateTime,System.DateTimeKind)" /> 方法改变指定日期的 <see cref="P:System.DateTime.Kind" /> 属性；不改变当前时间的值。</returns>
	public static DateTime AsUnspecified(this DateTime date)
	{
		return date.SpecifyKind(DateTimeKind.Unspecified);
	}

	/// <summary>
	/// 将指定日期转换为UTC时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>本方法调用 <see cref="M:System.DateTime.SpecifyKind(System.DateTime,System.DateTimeKind)" /> 方法改变指定日期的 <see cref="P:System.DateTime.Kind" /> 属性；不改变当前时间的值。</returns>
	public static DateTime AsUtc(this DateTime date)
	{
		return date.SpecifyKind(DateTimeKind.Utc);
	}

	/// <summary>
	/// 计算出生日期到当前日期为止的年龄
	/// </summary>
	/// <param name="birthday">出生日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>根据出生日期计算的年龄</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static double CalcAge(this DateTime birthday, IFormatProvider provider = null)
	{
		return birthday.CalcAge(DateTime.Now, provider);
	}

	/// <summary>
	/// 计算出生日期到当前日期为止的年龄
	/// </summary>
	/// <param name="birthday">出生日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>根据出生日期计算的年龄</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static double CalcAge(this DateTime birthday, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return birthday.CalcAge(DateTime.Now, calendar);
	}

	/// <summary>
	/// 计算出生日期到 <paramref name="nowDate" /> 为止的年龄
	/// </summary>
	/// <param name="birthday">出生日期</param>
	/// <param name="nowDate">计算年龄的截止日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>计算的年龄</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="nowDate" /> 早于 <paramref name="birthday" />。</exception>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static double CalcAge(this DateTime birthday, DateTime nowDate, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return birthday.CalcAge(nowDate, info.Calendar);
	}

	/// <summary>
	/// 计算出生日期到 <paramref name="nowDate" /> 为止的年龄
	/// </summary>
	/// <param name="birthday">出生日期</param>
	/// <param name="nowDate">计算年龄的截止日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>计算的年龄</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="nowDate" /> 早于 <paramref name="birthday" />。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static double CalcAge(this DateTime birthday, DateTime nowDate, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		nowDate.GuardGreaterThanOrEqualTo(birthday, "base date");
		int years = nowDate.GetYear(calendar) - birthday.GetYear(calendar);
		int baseDays = nowDate.GetDayOfYear(calendar);
		int birthdayDays = birthday.GetDayOfYear(calendar);
		if (baseDays >= birthdayDays)
		{
			return (double)years + (double)(baseDays - birthdayDays) * 1.0 / (double)nowDate.GetDaysInYear(calendar);
		}
		DateTime beforeDays = new DateTime(nowDate.GetYear(calendar) - 1, birthday.GetMonth(calendar), birthday.GetDaysInMonth(calendar), calendar);
		return (double)(years - 1) + (double)(beforeDays.GetDaysRemainedInYear(calendar) + baseDays) * 1.0 / (double)nowDate.GetDaysInYear(calendar);
	}

	/// <summary>
	/// 检测当前日期与目标日期的指定部分是否相同
	/// </summary>
	/// <param name="date">当前日期</param>
	/// <param name="target">目标日期</param>
	/// <param name="parts">日期比较的部分</param>
	/// <returns>如果相等返回true，否则返回false。</returns>
	public static bool Equals(this DateTime date, DateTime target, DateTimeParts parts)
	{
		return date.IsEqualTo(target, parts);
	}

	/// <summary>
	/// 将Unix格式日期转化为UTC日期
	/// </summary>
	/// <param name="seconds">Unix格式时间，自1970年1月1日零时起的秒数</param>
	/// <returns>转换后的UTC日期</returns>
	public static DateTime FromUnixTime(this long seconds)
	{
		return new DateTime(seconds * 10000000 + new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks, DateTimeKind.Utc);
	}

	/// <summary>
	/// 获取指定日期所在天的开始
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在天的开始（零时零分零秒）</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetBeginningOfDay(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetBeginningOfDay(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在天的开始
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在天的开始（零时零分零秒）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetBeginningOfDay(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return new DateTime(date.GetYear(calendar), date.GetMonth(calendar), date.GetDay(calendar), calendar);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] GetBytes(this DateTime value)
	{
		return value.Ticks.GetBytes();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetBytes(this DateTime[] values)
	{
		values.GuardNotNull("values");
		return values.GetBytes(0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值数组的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetBytes(this DateTime[] values, int start, int count)
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
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值序列的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>转换后的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetBytes(this IEnumerable<DateTime> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((DateTime x) => x.GetBytes()).ToArray();
	}

	/// <summary>
	/// 获取指定的日期是该月的第几天
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定的日期是该月的第几天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDay(this DateTime date, IFormatProvider provider = null)
	{
		return date.GetDay(provider);
	}

	/// <summary>
	/// 获取指定的日期是该月的第几天
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定的日期是该月的第几天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDay(this DateTime date, Calendar calendar)
	{
		return date.GetDay(calendar);
	}

	/// <summary>
	/// 获取指定日期是该月中的几号
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月中是几号</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDayOfMonth(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetDayOfMonth(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期是该月中的几号
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月中是几号</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDayOfMonth(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetDayOfMonth(date);
	}

	/// <summary>
	/// 获取指定日期是星期几
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期是星期几</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DayOfWeek GetDayOfWeek(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetDayOfWeek(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期是星期几
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期是星期几</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DayOfWeek GetDayOfWeek(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetDayOfWeek(date);
	}

	/// <summary>
	/// 获取指定日期在该年中是第几天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期在该年中是第几天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDayOfYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetDayOfYear(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期在该年中是第几天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期在该年中是第几天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDayOfYear(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetDayOfYear(date);
	}

	/// <summary>
	/// 获取指定日期所在月的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月的天数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysInMonth(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetDaysInMonth(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在月的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月的天数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysInMonth(this DateTime date, Calendar calendar)
	{
		return calendar.GetDaysInMonth(date.GetYear(calendar), date.GetMonth(calendar));
	}

	/// <summary>
	/// 获取指定日期所在年的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年的天数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysInYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetDaysInYear(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年的天数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysInYear(this DateTime date, Calendar calendar)
	{
		return calendar.GetDaysInYear(date.GetYear(calendar));
	}

	/// <summary>
	/// 获取指定日期所在月还剩的天数（多少天到月底）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月还剩的天数（多少天到月底）</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysRemainedInMonth(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetDaysRemainedInMonth(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在月还剩的天数（多少天到月底）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月还剩的天数（多少天到月底）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysRemainedInMonth(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.GetDaysInMonth(calendar) - date.GetDayOfMonth(calendar);
	}

	/// <summary>
	/// 获取指定日期所在星期还剩的天数（多少天到周末）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在星期还剩的天数（多少天到周末）</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysRemainedInWeek(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetDaysRemainedInWeek(info.Calendar, info.FirstDayOfWeek);
	}

	/// <summary>
	/// 获取指定日期所在星期还剩的天数（多少天到周末）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <param name="firstDay">一周的第一天是星期几</param>
	/// <returns>指定日期所在星期还剩的天数（多少天到周末）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysRemainedInWeek(this DateTime date, Calendar calendar, DayOfWeek firstDay)
	{
		calendar.GuardNotNull("calendar");
		int lastDayOfWeek = (int)(firstDay - 1);
		lastDayOfWeek = ((lastDayOfWeek >= 0) ? lastDayOfWeek : (7 + lastDayOfWeek));
		int currentDayOfWeek = (int)date.GetDayOfWeek(calendar);
		return (currentDayOfWeek <= lastDayOfWeek) ? (lastDayOfWeek - currentDayOfWeek) : (lastDayOfWeek + 7 - currentDayOfWeek);
	}

	/// <summary>
	/// 获取指定日期所在年还剩的天数（多少天到年底）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年还剩的天数（多少天到年底）</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysRemainedInYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetDaysRemainedInYear(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年还剩的天数（多少天到年底）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年还剩的天数（多少天到年底）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysRemainedInYear(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.GetDaysInYear(calendar) - date.GetDayOfYear(calendar);
	}

	/// <summary>
	/// 获取指定日期所在天的结束，最小精度为1毫秒
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在天的结束</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetEndOfDay(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetEndOfDay(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在天的结束，最小精度为1毫秒
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在天的结束</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetEndOfDay(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.AddDays(1, calendar).Date.AddMilliseconds(-1.0, calendar);
	}

	/// <summary>
	/// 获取指定日期所在月的第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月的第一天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetFirstDayOfMonth(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetFirstDayOfMonth(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在月的第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月的第一天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetFirstDayOfMonth(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.AddDays(-(date.GetDayOfMonth(calendar) - 1), calendar).Date;
	}

	/// <summary>
	/// 获取指定日期所在季度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在季度的第一天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetFirstDayOfQuarter(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetFirstDayOfQuarter(date.GetFirstDayOfYear(info.Calendar), info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在季度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetFirstDayOfQuarter(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.GetFirstDayOfQuarter(date.GetFirstDayOfYear(calendar), calendar);
	}

	/// <summary>
	/// 获取指定日期所在季度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="quarterStartDate">年度季度的起始日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在季度的第一天</returns>
	public static DateTime GetFirstDayOfQuarter(this DateTime date, DateTime quarterStartDate, Calendar calendar = null)
	{
		calendar = calendar.IfNull(CultureInfo.CurrentCulture.Calendar);
		for (int i = 0; i < 4; i++)
		{
			if (quarterStartDate <= date && date < quarterStartDate.AddMonths(3, calendar).Date)
			{
				return quarterStartDate.Date;
			}
			quarterStartDate = quarterStartDate.AddMonths(3, calendar);
		}
		throw new ArithmeticException();
	}

	/// <summary>
	/// 获取指定日期所在星期的第一天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在星期的第一天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetFirstDayOfWeek(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetFirstDayOfWeek(info.Calendar, info.FirstDayOfWeek);
	}

	/// <summary>
	/// 获取指定日期所在星期的第一天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <param name="firstDay">一周的第一天是星期几</param>
	/// <returns>指定日期所在星期的第一天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetFirstDayOfWeek(this DateTime date, Calendar calendar, DayOfWeek firstDay)
	{
		calendar.GuardNotNull("calendar");
		return date.AddDays(-(7 - date.GetDaysRemainedInWeek(calendar, firstDay) - 1), calendar).Date;
	}

	/// <summary>
	/// 获取指定日期所在年度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年度第一天的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetFirstDayOfYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetFirstDayOfYear(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年度第一天的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetFirstDayOfYear(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.AddDays(-(date.GetDayOfYear(calendar) - 1), calendar).Date;
	}

	/// <summary>
	/// 获取在指定日期的小时数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的小时数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetHour(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetHour(info.Calendar);
	}

	/// <summary>
	/// 获取在指定日期的小时数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的小时数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetHour(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetHour(date);
	}

	/// <summary>
	/// 获取指定日期所在月的最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月的最后一天的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetLastDayOfMonth(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetLastDayOfMonth(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在月的最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月的最后一天的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetLastDayOfMonth(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.AddMonths(1, calendar).GetFirstDayOfMonth(calendar).AddDays(-1, calendar)
			.Date;
	}

	/// <summary>
	/// 获取指定日期所在季度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在季度最后一天的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetLastDayOfQuarter(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetLastDayOfQuarter(date.GetFirstDayOfYear(info.Calendar), info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在季度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在季度最后一天的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetLastDayOfQuarter(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.GetLastDayOfQuarter(date.GetFirstDayOfYear(calendar), calendar);
	}

	/// <summary>
	/// 获取指定日期所在季度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="quarterStartDate">年度季度的起始日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在季度最后一天的日期</returns>
	public static DateTime GetLastDayOfQuarter(this DateTime date, DateTime quarterStartDate, Calendar calendar = null)
	{
		calendar = calendar.IfNull(CultureInfo.CurrentCulture.Calendar);
		for (int i = 0; i < 4; i++)
		{
			if (quarterStartDate <= date && date < quarterStartDate.AddMonths(3, calendar).Date)
			{
				return quarterStartDate.AddMonths(3, calendar).AddDays(-1, calendar).Date;
			}
			quarterStartDate = quarterStartDate.AddMonths(3, calendar);
		}
		throw new ArithmeticException();
	}

	/// <summary>
	/// 获取指定日期所在星期的最后一天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在星期的最后一天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetLastDayOfWeek(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetLastDayOfWeek(info.Calendar, info.FirstDayOfWeek);
	}

	/// <summary>
	/// 获取指定日期所在星期的最后一天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <param name="firstDay">一个星期的第一天是星期几</param>
	/// <returns>指定日期所在星期的最后一天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetLastDayOfWeek(this DateTime date, Calendar calendar, DayOfWeek firstDay)
	{
		calendar.GuardNotNull("calendar");
		return date.GetFirstDayOfWeek(calendar, firstDay).AddDays(6, calendar);
	}

	/// <summary>
	/// 获取指定日期所在年度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年度的最后一天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetLastDayOfYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetLastDayOfYear(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年度的最后一天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetLastDayOfYear(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return date.GetFirstDayOfYear(calendar).AddYears(1, calendar).AddDays(-1, calendar)
			.Date;
	}

	/// <summary>
	/// 获取指定日期所在年份的闰月
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年份的闰月</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetLeapMonth(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetLeapMonth(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年份的闰月
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年份的闰月</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetLeapMonth(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetLeapMonth(date.GetYear(calendar));
	}

	/// <summary>
	/// 获得本地时区
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>本地时间区域</returns>
	public static TimeZoneInfo GetLocalTimeZone(this DateTime date)
	{
		return TimeZoneInfo.Local;
	}

	/// <summary>
	/// 获取指定日期的毫秒
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>获取指定日期的毫秒</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static double GetMilliseconds(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetMilliseconds(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的毫秒
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>获取指定日期的毫秒</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static double GetMilliseconds(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetMilliseconds(date);
	}

	/// <summary>
	/// 获取指定日期的分钟数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的分钟数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetMinute(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetMinute(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的分钟数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的分钟数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetMinute(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetMinute(date);
	}

	/// <summary>
	/// 获取指定日期的月份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的月份</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetMonth(this DateTime date, IFormatProvider provider = null)
	{
		return date.GetMonthOfYear(provider);
	}

	/// <summary>
	/// 获取指定日期的月份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的月份</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetMonth(this DateTime date, Calendar calendar)
	{
		return date.GetMonthOfYear(calendar);
	}

	/// <summary>
	/// 获取指定日期的月份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的月份</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetMonthOfYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetMonthOfYear(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的月份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的月份</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetMonthOfYear(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetMonth(date);
	}

	/// <summary>
	/// 获取指定日期所在年的月数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年的月数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetMonthsInYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetMonthsInYear(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年的月数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年的月数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetMonthsInYear(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetMonthsInYear(date.GetYear(calendar));
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	public static byte[] GetRawBytes(this DateTime value)
	{
		return value.Ticks.GetRawBytes();
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	public static byte[] GetRawBytes(this DateTime[] values)
	{
		values.GuardNotNull("values");
		return values.GetRawBytes(0, values.Length);
	}

	/// <summary>
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值数组的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值数组</param>
	/// <param name="start">开始转换的数值的索引</param>
	/// <param name="count">转换的值数量</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前数组为空。</exception>
	/// <exception cref="T:System.IndexOutOfRangeException">开始转换的索引 <paramref name="start" /> 超出了当前数组的索引范围。</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">转换的值数量 <paramref name="count" /> 小于0，或者大于从 <paramref name="start" /> 起剩余的值数量。</exception>
	public static byte[] GetRawBytes(this DateTime[] values, int start, int count)
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
	/// 获取当前 <see cref="T:System.DateTime" /> 型数值序列的 Big-Endian 顺序的位字节数组
	/// </summary>
	/// <param name="values">当前数值序列</param>
	/// <returns>Big-Endian 顺序的字节数组</returns>
	/// <exception cref="T:System.ArgumentNullException">当前序列为空。</exception>
	public static byte[] GetRawBytes(this IEnumerable<DateTime> values)
	{
		values.GuardNotNull("values");
		return values.SelectMany((DateTime x) => x.GetRawBytes()).ToArray();
	}

	/// <summary>
	/// 获取指定日期的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的秒数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetSecond(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetSecond(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的秒数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetSecond(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetSecond(date);
	}

	/// <summary>
	/// 根据指定时间的时区属性获取匹配的时区信息
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <returns>
	/// 如果指定时间的 <see cref="P:System.DateTime.Kind" /> 属性为 <see cref="F:System.DateTimeKind.Local" /> 则返回本地时区；
	/// 如果为 <see cref="F:System.DateTimeKind.Utc" /> 则返回UTC时区；
	/// 否则返回null。
	/// </returns>
	public static TimeZoneInfo GetTimeZone(this DateTime date)
	{
		return date.Kind switch
		{
			DateTimeKind.Local => TimeZoneInfo.Local, 
			DateTimeKind.Utc => TimeZoneInfo.Utc, 
			_ => null, 
		};
	}

	/// <summary>
	/// 获取指定日期所在周是所在年中的第几周
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在周是所在年中的第几周</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetWeekOfYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetWeekOfYear(info.Calendar, info.CalendarWeekRule, info.FirstDayOfWeek);
	}

	/// <summary>
	/// 获取在指定日历中参数日期所在的周是年中的第几周
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <param name="rule">确定年份第一周的规则</param>
	/// <param name="firstDay">每周的第一天</param>
	/// <returns>公历日期在指定日历中对应的周数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetWeekOfYear(this DateTime date, Calendar calendar, CalendarWeekRule rule, DayOfWeek firstDay)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetWeekOfYear(date, rule, firstDay);
	}

	/// <summary>
	/// 返回指定日期所在年的星期数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年的星期数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetWeeksInYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetWeeksInYear(info.Calendar, info.CalendarWeekRule, info.FirstDayOfWeek);
	}

	/// <summary>
	/// 返回指定日期所在年的星期数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <param name="rule">确定年份第一周的规则</param>
	/// <param name="firstDay">每周的第一天</param>
	/// <returns>指定日期所在年的星期数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetWeeksInYear(this DateTime date, Calendar calendar, CalendarWeekRule rule, DayOfWeek firstDay)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetWeekOfYear(date.GetLastDayOfYear(calendar), rule, firstDay);
	}

	/// <summary>
	/// 获取指定日期的年份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的年份</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.GetYear(info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的年份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetYear(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.GetYear(date);
	}

	/// <summary>
	/// 检测指定的日期是否早于目标日期，仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定日期早于目标日期返回true，否则返回false。</returns>
	public static bool IsDateEarlierThan(this DateTime date, DateTime target)
	{
		return date.Date < target.Date;
	}

	/// <summary>
	/// 检测指定的日期是否不晚于目标日期，仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定日期不晚于目标日期返回true，否则返回false。</returns>
	public static bool IsDateEarlierThanOrEqualTo(this DateTime date, DateTime target)
	{
		return date.Date <= target.Date;
	}

	/// <summary>
	/// 检测指定日期和目标日期的日期部分是否相等
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果相等返回true，否则返回false</returns>
	public static bool IsDateEqualTo(this DateTime date, DateTime target)
	{
		return date.Date.Equals(target.Date);
	}

	/// <summary>
	/// 判断指定日期是否晚于目标日期，仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定的日期晚于目标日期则返回true，否则返回false</returns>
	public static bool IsDateLaterThan(this DateTime date, DateTime target)
	{
		return date.Date > target.Date;
	}

	/// <summary>
	/// 判断指定日期是否不早于目标日期，仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定的日期不早于目标日期则返回true，否则返回false</returns>
	public static bool IsDateLaterThanOrEqualTo(this DateTime date, DateTime target)
	{
		return date.Date >= target.Date;
	}

	/// <summary>
	/// 检测指定日期是否早于目标日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果早于返回true，否则返回false</returns>
	public static bool IsEarlierThan(this DateTime date, DateTime target)
	{
		return date < target;
	}

	/// <summary>
	/// 检测指定日期是否不晚于目标日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果不晚于返回true，否则返回false</returns>
	public static bool IsEarlierThanOrEqualTo(this DateTime date, DateTime target)
	{
		return date <= target;
	}

	/// <summary>
	/// 检测当前日期是否与目标日期相同
	/// </summary>
	/// <param name="date">当前日期</param>
	/// <param name="target">目标日期</param>
	/// <returns>如果相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(this DateTime date, DateTime target)
	{
		return date.Equals(target);
	}

	/// <summary>
	/// 检测当前日期与目标日期的指定部分是否相同
	/// </summary>
	/// <param name="date">当前日期</param>
	/// <param name="target">目标日期</param>
	/// <param name="parts">日期比较的部分</param>
	/// <returns>如果当前日期和目标日期的指定部分相等返回true，否则返回false。</returns>
	public static bool IsEqualTo(this DateTime date, DateTime target, DateTimeParts parts)
	{
		bool result = true;
		if (result && parts.HasFlag(DateTimeParts.Year))
		{
			result = date.Year == target.Year;
		}
		if (result && parts.HasFlag(DateTimeParts.Month))
		{
			result = date.Month == target.Month;
		}
		if (result && parts.HasFlag(DateTimeParts.Day))
		{
			result = date.Day == target.Day;
		}
		if (result && parts.HasFlag(DateTimeParts.Hour))
		{
			result = date.Hour == target.Hour;
		}
		if (result && parts.HasFlag(DateTimeParts.Minute))
		{
			result = date.Minute == target.Minute;
		}
		if (result && parts.HasFlag(DateTimeParts.Second))
		{
			result = date.Second == target.Second;
		}
		if (result && parts.HasFlag(DateTimeParts.Millisecond))
		{
			result = date.Millisecond == target.Millisecond;
		}
		return result;
	}

	/// <summary>
	/// 判断指定日期是否是将来的日期（大于当前日期）
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>如果指定的日期晚于当前日期返回true，否则返回false</returns>
	public static bool IsFuture(this DateTime date)
	{
		return date > DateTime.Now;
	}

	/// <summary>
	/// 判断指定日期是否是将来的日期（大于当前日期），仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>如果指定的日期晚于当前日期返回true，否则返回false</returns>
	public static bool IsFutureDate(this DateTime date)
	{
		return date.Date > DateTime.Now.Date;
	}

	/// <summary>
	/// 判断指定时间是否是将来的时间（大于当前时间）
	/// </summary>
	/// <param name="time">指定的时间</param>
	/// <returns>如果指定的时间晚于当前时间返回true，否则返回false</returns>
	public static bool IsFutureTime(this DateTime time)
	{
		return time.TimeOfDay > DateTime.Now.TimeOfDay;
	}

	/// <summary>
	/// 判断指定日期是否晚于目标日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定的日期晚于目标日期则返回true，否则返回false</returns>
	public static bool IsLaterThan(this DateTime date, DateTime target)
	{
		return date > target;
	}

	/// <summary>
	/// 判断指定日期是否不早于目标日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定的日期不早于目标日期则返回true，否则返回false</returns>
	public static bool IsLaterThanOrEqualTo(this DateTime date, DateTime target)
	{
		return date >= target;
	}

	/// <summary>
	/// 检测指定日期所在的日是否是闰日
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>如果是闰日返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static bool IsLeapDay(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.IsLeapDay(info.Calendar);
	}

	/// <summary>
	/// 检测指定日期所在的日是否是闰日
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果是闰日返回true，否则false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsLeapDay(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.IsLeapDay(date.GetYear(calendar), date.GetMonth(calendar), date.GetDay(calendar));
	}

	/// <summary>
	/// 检测指定日期所在的月是否是闰月
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>如果是闰月返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static bool IsLeapMonth(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.IsLeapMonth(info.Calendar);
	}

	/// <summary>
	/// 检测指定日期所在的月是否是闰月
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果是闰月返回true，否则false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsLeapMonth(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.IsLeapMonth(date.GetYear(calendar), date.GetMonth(calendar));
	}

	/// <summary>
	/// 检测指定日期所在的年是否是闰年
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>如果是闰年返回true，否则false</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static bool IsLeapYear(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.IsLeapYear(info.Calendar);
	}

	/// <summary>
	/// 检测指定日期所在的年是否是闰年
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果是闰年返回true，否则false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsLeapYear(this DateTime date, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return calendar.IsLeapYear(date.GetYear(calendar));
	}

	/// <summary>
	/// 判断指定日期是否是过去的日期（早于当前日期）
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>如果指定日期早于当前时间返回true，否则返回false</returns>
	public static bool IsPast(this DateTime date)
	{
		return date < DateTime.Now;
	}

	/// <summary>
	/// 判断指定日期是否是过去的日期（早于当前日期），仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>如果指定日期早于当前时间返回true，否则返回false</returns>
	public static bool IsPastDate(this DateTime date)
	{
		return date.Date < DateTime.Now.Date;
	}

	/// <summary>
	/// 判断指定时间是否是过去的时间
	/// </summary>
	/// <param name="time">指定的时间</param>
	/// <returns>如果指定的时间早于当前时间返回true，否则返回false</returns>
	public static bool IsPastTime(this DateTime time)
	{
		return time.TimeOfDay < DateTime.Now.TimeOfDay;
	}

	/// <summary>
	/// 检测指定的时间是否早于目标时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="target">比较的目标时间</param>
	/// <returns>如果指定时间早于目标时间返回true，否则返回false。</returns>
	public static bool IsTimeEarlierThan(this DateTime date, DateTime target)
	{
		return date.TimeOfDay < target.TimeOfDay;
	}

	/// <summary>
	/// 检测指定的时间是否不晚于目标时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="target">比较的目标时间</param>
	/// <returns>如果指定时间不晚于目标时间返回true，否则返回false。</returns>
	public static bool IsTimeEarlierThanOrEqualTo(this DateTime date, DateTime target)
	{
		return date.TimeOfDay <= target.TimeOfDay;
	}

	/// <summary>
	/// 检测指定日期和目标日期的时间部分是否相等
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果相等返回true，否则返回false</returns>
	public static bool IsTimeEqualTo(this DateTime date, DateTime target)
	{
		return date.TimeOfDay.Equals(target.TimeOfDay);
	}

	/// <summary>
	/// 判断指定时间是否晚于目标时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="target">比较的目标时间</param>
	/// <returns>如果指定的时间晚于目标时间则返回true，否则返回false</returns>
	public static bool IsTimeLaterThan(this DateTime date, DateTime target)
	{
		return date.TimeOfDay > target.TimeOfDay;
	}

	/// <summary>
	/// 判断指定时间是否不早于目标时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="target">比较的目标时间</param>
	/// <returns>如果指定的时间不早于目标时间则返回true，否则返回false</returns>
	public static bool IsTimeLaterThanOrEqualTo(this DateTime date, DateTime target)
	{
		return date.TimeOfDay >= target.TimeOfDay;
	}

	/// <summary>
	/// 判断指定日期是否是今天（指定日期和当前时间的日期部分相等）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>如果是今天返回true，否则返回false。</returns>
	public static bool IsToday(this DateTime date)
	{
		return date.Date == DateTime.Now.Date;
	}

	/// <summary>
	/// 判断指定日期是否是周末
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>如果指定日期是周末返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static bool IsWeekend(this DateTime date, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return new DayOfWeek[2]
		{
			DayOfWeek.Saturday,
			DayOfWeek.Sunday
		}.Any((DayOfWeek x) => x == date.GetDayOfWeek(info.Calendar));
	}

	/// <summary>
	/// 判断指定日期是否是周末
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="weekends">一周中周末是那几天</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>如果指定日期是周末返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static bool IsWeekend(this DateTime date, DayOfWeek[] weekends, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return weekends.IfNull(new DayOfWeek[2]
		{
			DayOfWeek.Saturday,
			DayOfWeek.Sunday
		}).Any((DayOfWeek x) => x == date.GetDayOfWeek(info.Calendar));
	}

	/// <summary>
	/// 判断指定日期是否是周末
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果指定日期是周末返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsWeekend(this DateTime date, Calendar calendar)
	{
		return new DayOfWeek[2]
		{
			DayOfWeek.Saturday,
			DayOfWeek.Sunday
		}.Any((DayOfWeek x) => x == date.GetDayOfWeek(calendar));
	}

	/// <summary>
	/// 判断指定日期是否是周末
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="weekends">一周中周末是那几天</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果指定日期是周末返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsWeekend(this DateTime date, DayOfWeek[] weekends, Calendar calendar)
	{
		return weekends.IfNull(new DayOfWeek[2]
		{
			DayOfWeek.Saturday,
			DayOfWeek.Sunday
		}).Any((DayOfWeek x) => x == date.GetDayOfWeek(calendar));
	}

	/// <summary>
	/// 把指定的日期序列化为字节数组
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>指定的日期序列化的字节数组</returns>
	public static byte[] Serialize(this DateTime date)
	{
		return date.ToBinary().GetBytes();
	}

	/// <summary>
	/// 设置指定日期的日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="year">设置的年份</param>
	/// <param name="month">设置的月份</param>
	/// <param name="day">设置的日数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置日期后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetDate(this DateTime date, int year, int month, int day, IFormatProvider provider = null)
	{
		provider = provider.IfNull(CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo)).GuardNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return date.SetDate(year, month, day, info.Calendar);
	}

	/// <summary>
	/// 设置指定日期的日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="year">设置的年份</param>
	/// <param name="month">设置的月份</param>
	/// <param name="day">设置的日数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置日期后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetDate(this DateTime date, int year, int month, int day, Calendar calendar)
	{
		calendar.GuardNotNull("calendar");
		return new DateTime(year, month, day, calendar).AddMilliseconds((date - date.Date).TotalMilliseconds, calendar);
	}

	/// <summary>
	/// 设置指定日期的日数
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="day">设置的日数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置日数后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetDay(this DateTime date, int day, IFormatProvider provider = null)
	{
		return date.AddDays(day - date.GetDayOfMonth(provider), provider);
	}

	/// <summary>
	/// 设置指定日期的日数
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="day">设置的日数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置日数后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetDay(this DateTime date, int day, Calendar calendar)
	{
		return date.AddDays(day - date.GetDayOfMonth(calendar), calendar);
	}

	/// <summary>
	/// 设置指定日期的小时
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="hour">设置的小时数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置小时后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetHour(this DateTime date, int hour, IFormatProvider provider = null)
	{
		return date.AddHours(hour - date.GetHour(provider), provider);
	}

	/// <summary>
	/// 设置指定日期的小时
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="hour">设置的小时数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置小时后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetHour(this DateTime date, int hour, Calendar calendar)
	{
		return date.AddHours(hour - date.GetHour(calendar), calendar);
	}

	/// <summary>
	/// 设置指定的日期的分钟
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="minute">设置的分钟数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置分钟后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetMinute(this DateTime date, int minute, IFormatProvider provider = null)
	{
		return date.AddMinutes(minute - date.GetMinute(provider), provider);
	}

	/// <summary>
	/// 设置指定的日期的分钟
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="minute">设置的分钟数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置分钟后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetMinute(this DateTime date, int minute, Calendar calendar)
	{
		return date.AddMinutes(minute - date.GetMinute(calendar), calendar);
	}

	/// <summary>
	/// 设置指定的日期的月份
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="month">设置的月份</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置月份后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetMonth(this DateTime date, int month, IFormatProvider provider = null)
	{
		return date.AddMonths(month - date.GetMonth(provider), provider);
	}

	/// <summary>
	/// 设置指定的日期的月份
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="month">设置的月份</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置月份后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetMonth(this DateTime date, int month, Calendar calendar)
	{
		return date.AddMonths(month - date.GetMonth(calendar), calendar);
	}

	/// <summary>
	/// 设置指定的日期的秒数
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="second">设置的秒数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置秒数后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetSecond(this DateTime date, int second, IFormatProvider provider = null)
	{
		return date.AddSeconds(second - date.GetSecond(provider), provider);
	}

	/// <summary>
	/// 设置指定的日期的秒数
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="second">设置的秒数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置秒数后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetSecond(this DateTime date, int second, Calendar calendar)
	{
		return date.AddSeconds(second - date.GetSecond(calendar), calendar);
	}

	/// <summary>
	/// 设置指定的日期的时间部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="hour">设置的小时</param>
	/// <param name="minutes">设置的分钟</param>
	/// <param name="seconds">设置的秒数</param>
	/// <param name="millisecond">设置的毫秒数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置时间后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetTime(this DateTime date, int hour, int minutes, int seconds, int millisecond, IFormatProvider provider = null)
	{
		return date.SetTime(new TimeSpan(0, hour, minutes, seconds, millisecond), provider);
	}

	/// <summary>
	/// 设置指定的日期的时间部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="hour">设置的小时</param>
	/// <param name="minutes">设置的分钟</param>
	/// <param name="seconds">设置的秒数</param>
	/// <param name="millisecond">设置的毫秒数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置时间后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetTime(this DateTime date, int hour, int minutes, int seconds, int millisecond, Calendar calendar)
	{
		return date.SetTime(new TimeSpan(0, hour, minutes, seconds, millisecond), calendar);
	}

	/// <summary>
	/// 设置指定的日期的时间部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="time">设置的时间</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置时间后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetTime(this DateTime date, TimeSpan time, IFormatProvider provider = null)
	{
		return date.Date.AddMilliseconds(time.TotalMilliseconds, provider);
	}

	/// <summary>
	/// 设置指定的日期的时间部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="time">设置的时间</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置时间后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetTime(this DateTime date, TimeSpan time, Calendar calendar)
	{
		return date.Date.AddMilliseconds(time.TotalMilliseconds, calendar);
	}

	/// <summary>
	/// 设置指定的日期的年份
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="year">设置的年份</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置年份后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetYear(this DateTime date, int year, IFormatProvider provider = null)
	{
		return date.AddYears(year - date.GetYear(provider), provider);
	}

	/// <summary>
	/// 设置指定的日期的年份
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="year">设置的年份</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置年份后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetYear(this DateTime date, int year, Calendar calendar)
	{
		return date.AddYears(year - date.GetYear(calendar), calendar);
	}

	/// <summary>
	/// 设置指定日期的种类
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="kind">设置的日期类型</param>
	/// <returns>处理后的日期</returns>
	public static DateTime SpecifyKind(this DateTime date, DateTimeKind kind)
	{
		return DateTime.SpecifyKind(date, kind);
	}

	/// <summary>
	/// 检测指定日期和目标日期的时间部分是否相等
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果相等返回true，否则返回false。</returns>
	public static bool TimeEquals(this DateTime date, DateTime target)
	{
		return date.TimeOfDay.Equals(target.TimeOfDay);
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>转换后的日期</returns>
	/// <exception cref="T:System.ArgumentException">指定的日期的 <see cref="P:System.DateTime.Kind" /> 属性等于 <see cref="F:System.DateTimeKind.Unspecified" />。</exception>
	public static DateTimeOffset ToDateTimeOffset(this DateTime date)
	{
		return date.Kind switch
		{
			DateTimeKind.Utc => new DateTimeOffset(date, TimeZoneInfo.Utc.BaseUtcOffset), 
			DateTimeKind.Local => new DateTimeOffset(date, TimeZoneInfo.Local.BaseUtcOffset), 
			_ => throw new ArgumentException(Literals.MSG_InvalidDateTimeKind_1.FormatValue(date), "date"), 
		};
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="timezone">转换使用的时区</param>
	/// <returns>转换后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="timezone" /> 为空。</exception>
	public static DateTimeOffset ToDateTimeOffset(this DateTime date, TimeZoneInfo timezone)
	{
		timezone.GuardNotNull("timezone");
		return new DateTimeOffset(date.AsUnspecified(), timezone.BaseUtcOffset);
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="offset">转换使用的时区偏移</param>
	/// <returns>转换后的日期</returns>
	public static DateTimeOffset ToDateTimeOffset(this DateTime date, TimeSpan offset)
	{
		return new DateTimeOffset(date.AsUnspecified(), offset);
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="minutes">转换使用的时区偏移分钟</param>
	/// <returns>转换后的日期</returns>
	public static DateTimeOffset ToDateTimeOffset(this DateTime date, int minutes)
	{
		return new DateTimeOffset(date.AsUnspecified(), TimeSpan.FromMinutes(minutes));
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="hours">转换使用的时区偏移小时</param>
	/// <returns>转换后的日期</returns>
	public static DateTimeOffset ToDateTimeOffset(this DateTime date, double hours)
	{
		return new DateTimeOffset(date.AsUnspecified(), TimeSpan.FromHours(hours));
	}

	/// <summary>
	/// 将当前 <see cref="T:System.DateTime" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this DateTime value, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(upperCase);
	}

	/// <summary>
	/// 将当前 <see cref="T:System.DateTime" /> 型数值转换为十六进制字符串形式
	/// </summary>
	/// <param name="value">当前数值</param>
	/// <param name="prefix">字符串前缀</param>
	/// <param name="upperCase">是否转换为大写的十六进制字符串形式</param>
	/// <returns>当前数值的十六进制字符串形式</returns>
	public static string ToHex(this DateTime value, string prefix, bool upperCase = false)
	{
		return value.GetRawBytes().ToHex(prefix, upperCase);
	}

	/// <summary>
	/// 将指定时间转换为本地时间
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <returns>转换后的本地时间</returns>
	/// <exception cref="T:System.ArgumentException">指定的日期的 <see cref="P:System.DateTime.Kind" /> 属性等于 <see cref="F:System.DateTimeKind.Unspecified" />。</exception>
	/// <remarks>
	/// 如果指定的时间为 <see cref="F:System.DateTimeKind.Utc" />, 则返回指定时间；
	/// 如果指定的时间为 <see cref="F:System.DateTimeKind.Local" />, 则将指定时间转换为本地时间并返回；
	/// 如果指定的时间为 <see cref="F:System.DateTimeKind.Unspecified" />, 则抛出异常；
	/// </remarks>
	public static DateTime ToLocal(this DateTime date)
	{
		return date.Kind switch
		{
			DateTimeKind.Utc => TimeZoneInfo.ConvertTime(date, TimeZoneInfo.Utc, TimeZoneInfo.Local), 
			DateTimeKind.Local => date, 
			_ => throw new ArgumentException(Literals.MSG_InvalidDateTimeKind_1.FormatValue(date), "date"), 
		};
	}

	/// <summary>
	/// 将指定时间转换为本地时间
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="sourceTimeZone">指定时间所属的时区</param>
	/// <returns>转换后的本地时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="sourceTimeZone" /> 为空。</exception>
	/// <remarks>本方法始终将指定的时间作为 <paramref name="sourceTimeZone" /> 指定的时区的时间，并转换为本地时间。</remarks>
	public static DateTime ToLocal(this DateTime date, TimeZoneInfo sourceTimeZone)
	{
		sourceTimeZone.GuardNotNull("Source Timezone");
		return TimeZoneInfo.ConvertTime(date.AsUnspecified(), sourceTimeZone, TimeZoneInfo.Local);
	}

	/// <summary>
	/// 将指定时间转换为本地时间
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="minutes">指定时间的时区偏移分钟数</param>
	/// <returns>转换后的本地时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="minutes" /> 超出有效时区偏移量，正负840分钟，14小时。</exception>
	public static DateTime ToLocal(this DateTime date, int minutes)
	{
		minutes.GuardBetween(-840, 840, "minutes");
		return date.AddMinutes(-minutes).AsLocal();
	}

	/// <summary>
	/// 将指定时间转换为本地时间
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="hours">指定时间的时区偏移小时数</param>
	/// <returns>转换后的本地时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="hours" /> 超出有效时区偏移量，正负14小时。</exception>
	public static DateTime ToLocal(this DateTime date, double hours)
	{
		hours.GuardBetween(-14.0, 14.0, "hours");
		return date.AddHours(0.0 - hours).AsLocal();
	}

	/// <summary>
	/// 将指定时间转换为本地时间
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="offset">指定时间的时区偏移</param>
	/// <returns>转换后的本地时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset" /> 超出有效时区偏移量，正负14小时。</exception>
	public static DateTime ToLocal(this DateTime date, TimeSpan offset)
	{
		offset.TotalHours.GuardBetween(-14.0, 14.0, "offset");
		return date.Subtract(offset).AsUtc();
	}

	/// <summary>
	/// 将协调世界时（UTC）转换为本地时间
	/// </summary>
	/// <param name="date">协调世界时（UTC）</param>
	/// <returns>转换后的本地时间</returns>
	/// <remarks>本方法始终将指定的时间作为协调世界时（UTC）转换为本地时间。</remarks>
	public static DateTime ToLocalFromUtc(this DateTime date)
	{
		return TimeZoneInfo.ConvertTime(date.AsUtc(), TimeZoneInfo.Utc, TimeZoneInfo.Local);
	}

	/// <summary>
	/// 将指定时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <exception cref="T:System.ArgumentException">指定的日期的 <see cref="P:System.DateTime.Kind" /> 属性等于 <see cref="F:System.DateTimeKind.Unspecified" />。</exception>
	/// <remarks>
	/// 如果指定的时间为 <see cref="F:System.DateTimeKind.Utc" />, 则返回指定时间；
	/// 如果指定的时间为 <see cref="F:System.DateTimeKind.Local" />, 则将指定时间转换为协调世界时并返回；
	/// 如果指定的时间为 <see cref="F:System.DateTimeKind.Unspecified" />, 则抛出异常；
	/// </remarks>
	public static DateTime ToUtc(this DateTime date)
	{
		return date.Kind switch
		{
			DateTimeKind.Utc => date, 
			DateTimeKind.Local => TimeZoneInfo.ConvertTime(date, TimeZoneInfo.Local, TimeZoneInfo.Utc), 
			_ => throw new ArgumentException(Literals.MSG_InvalidDateTimeKind_1.FormatValue(date), "date"), 
		};
	}

	/// <summary>
	/// 将指定时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="sourceTimeZone">指定时间所属的时区</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="sourceTimeZone" /> 为空。</exception>
	/// <remarks>本方法始终将指定的时间作为 <paramref name="sourceTimeZone" /> 指定的时区的时间，并转换为协调世界时。</remarks>
	public static DateTime ToUtc(this DateTime date, TimeZoneInfo sourceTimeZone)
	{
		sourceTimeZone.GuardNotNull("Source Timezone");
		return TimeZoneInfo.ConvertTime(date.AsUnspecified(), sourceTimeZone, TimeZoneInfo.Utc);
	}

	/// <summary>
	/// 将指定时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="minutes">指定时间的时区偏移分钟数</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="minutes" /> 超出有效时区偏移量，正负840分钟，14小时。</exception>
	public static DateTime ToUtc(this DateTime date, int minutes)
	{
		minutes.GuardBetween(-840, 840, "minutes");
		return date.AddMinutes(-minutes).AsUtc();
	}

	/// <summary>
	/// 将指定时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="hours">指定时间的时区偏移小时数</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="hours" /> 超出有效时区偏移量，正负14小时。</exception>
	public static DateTime ToUtc(this DateTime date, double hours)
	{
		hours.GuardBetween(-14.0, 14.0, "hours");
		return date.AddHours(0.0 - hours).AsUtc();
	}

	/// <summary>
	/// 将指定时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="offset">指定时间的时区偏移</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset" /> 超出有效时区偏移量，正负14小时。</exception>
	public static DateTime ToUtc(this DateTime date, TimeSpan offset)
	{
		offset.TotalHours.GuardBetween(-14.0, 14.0, "offset");
		return date.Subtract(offset).AsUtc();
	}

	/// <summary>
	/// 将本地时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">本地时间</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <remarks>本方法始终将指定的时间作为本地时间转换为协调世界时。</remarks>
	public static DateTime ToUtcFromLocal(this DateTime date)
	{
		return TimeZoneInfo.ConvertTime(date.AsLocal(), TimeZoneInfo.Local, TimeZoneInfo.Utc);
	}

	/// <summary>
	/// 将指定日期转化为Unix时间，Unix时间为自1970年1月1日零时起的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>Unix时间</returns>
	public static long ToUnixTime(this DateTime date)
	{
		return (date.AsUtc() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks / 10000000;
	}

	/// <summary>
	/// 将指定的时间转换为目标时区的时间
	/// </summary>
	/// <param name="date">指定的时间（本地时间）</param>
	/// <param name="targetTimeZone">目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTime ToTimeZone(this DateTime date, TimeZoneInfo targetTimeZone)
	{
		targetTimeZone.GuardNotNull("target timezone");
		if (date.Kind == DateTimeKind.Unspecified)
		{
			throw new ArgumentException(Literals.MSG_InvalidDateTimeKind_1.FormatValue(date), "date");
		}
		return TimeZoneInfo.ConvertTime(date, targetTimeZone);
	}

	/// <summary>
	/// 将指定的时间转换为目标时区的时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="sourceTimeZone">指定的时间所在的时区</param>
	/// <param name="targetTimeZone">转换的目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="sourceTimeZone" /> 为空。</exception>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTime ToTimeZone(this DateTime date, TimeZoneInfo sourceTimeZone, TimeZoneInfo targetTimeZone)
	{
		sourceTimeZone.GuardNotNull("source timezone");
		targetTimeZone.GuardNotNull("target timezone");
		return TimeZoneInfo.ConvertTime(date.AsUnspecified(), sourceTimeZone, targetTimeZone);
	}

	/// <summary>
	/// 将指定的时间转换为目标时区的时间，指定的时间始终认为是本地时间
	/// </summary>
	/// <param name="date">指定的时间（本地时间）</param>
	/// <param name="targetTimeZone">目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTime ToTimeZoneFromLocal(this DateTime date, TimeZoneInfo targetTimeZone)
	{
		targetTimeZone.GuardNotNull("target timezone");
		return TimeZoneInfo.ConvertTime(date.AsLocal(), TimeZoneInfo.Local, targetTimeZone);
	}

	/// <summary>
	/// 将指定的时间转换为目标时区的时间，指定的时间始终认为是协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定的时间（协调世界时（UTC））</param>
	/// <param name="targetTimeZone">目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTime ToTimeZoneFromUtc(this DateTime date, TimeZoneInfo targetTimeZone)
	{
		targetTimeZone.GuardNotNull("target timezone");
		return TimeZoneInfo.ConvertTime(date.AsUtc(), TimeZoneInfo.Utc, targetTimeZone);
	}
}
