#define DEBUG
using System;
using System.Globalization;
using System.Linq;
using Richfit.Garnet.Common.Properties;

namespace Richfit.Garnet.Common.Utility;

/// <summary>
/// 日期时间辅助类
/// </summary>
public static class DateTimeHelper
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
	public static DateTime AddDays(DateTime date, int days, IFormatProvider provider)
	{
		Guard.AssertNotNull(provider, "provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(typeof(ArgumentException), "provider", Literals.MSG_InvalidFormatProvider);
		return AddDays(date, days, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="days">增加的天数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddDays(DateTime date, int days, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return SpecifyKind(calendar.AddDays(date, days), date.Kind);
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
	public static DateTime AddHours(DateTime date, int hours, IFormatProvider provider)
	{
		Guard.AssertNotNull(provider, "provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return AddHours(date, hours, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的小时数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="hours">增加的小时数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddHours(DateTime date, int hours, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return SpecifyKind(calendar.AddHours(date, hours), date.Kind);
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
	public static DateTime AddMilliseconds(DateTime date, double milliseconds, IFormatProvider provider)
	{
		Guard.AssertNotNull(provider, "provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return AddMilliseconds(date, milliseconds, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的毫秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="milliseconds">增加的毫秒数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddMilliseconds(DateTime date, double milliseconds, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return SpecifyKind(calendar.AddMilliseconds(date, milliseconds), date.Kind);
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
	public static DateTime AddMinutes(DateTime date, int minutes, IFormatProvider provider)
	{
		Guard.AssertNotNull(provider, "provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return AddMinutes(date, minutes, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的分钟数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="minutes">增加的分钟数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddMinutes(DateTime date, int minutes, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return SpecifyKind(calendar.AddMinutes(date, minutes), date.Kind);
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
	public static DateTime AddMonths(DateTime date, int months, IFormatProvider provider)
	{
		Guard.AssertNotNull(provider, "provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return AddMonths(date, months, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的月数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="months">增加的月数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddMonths(DateTime date, int months, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return SpecifyKind(calendar.AddMonths(date, months), date.Kind);
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
	public static DateTime AddSeconds(DateTime date, int seconds, IFormatProvider provider)
	{
		Guard.AssertNotNull(provider, "provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return AddSeconds(date, seconds, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="seconds">增加的秒数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddSeconds(DateTime date, int seconds, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return SpecifyKind(calendar.AddSeconds(date, seconds), date.Kind);
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
	public static DateTime AddWeeks(DateTime date, int weeks, IFormatProvider provider)
	{
		Guard.AssertNotNull(provider, "provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return AddWeeks(date, weeks, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的周数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="weeks">增加的周数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddWeeks(DateTime date, int weeks, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return SpecifyKind(calendar.AddWeeks(date, weeks), date.Kind);
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
	public static DateTime AddYears(DateTime date, int years, IFormatProvider provider)
	{
		Guard.AssertNotNull(provider, "provider");
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return AddYears(date, years, info.Calendar);
	}

	/// <summary>
	/// 在指定日期上增加指定的年数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="years">增加的年数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>处理后的新日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime AddYears(DateTime date, int years, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return SpecifyKind(calendar.AddYears(date, years), date.Kind);
	}

	/// <summary>
	/// 将指定日期转换为本地时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>转换后的本地时间</returns>
	/// <remarks>本方法调用 <see cref="M:System.DateTime.SpecifyKind(System.DateTime,System.DateTimeKind)" /> 方法改变指定日期的 <see cref="P:System.DateTime.Kind" /> 属性；不改变当前时间的值。</remarks>
	public static DateTime AsLocal(DateTime date)
	{
		return SpecifyKind(date, DateTimeKind.Local);
	}

	/// <summary>
	/// 将指定日期转换为非特定时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>本方法调用 <see cref="M:System.DateTime.SpecifyKind(System.DateTime,System.DateTimeKind)" /> 方法改变指定日期的 <see cref="P:System.DateTime.Kind" /> 属性；不改变当前时间的值。</returns>
	public static DateTime AsUnspecified(DateTime date)
	{
		return SpecifyKind(date, DateTimeKind.Unspecified);
	}

	/// <summary>
	/// 将指定日期转换为UTC时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>本方法调用 <see cref="M:System.DateTime.SpecifyKind(System.DateTime,System.DateTimeKind)" /> 方法改变指定日期的 <see cref="P:System.DateTime.Kind" /> 属性；不改变当前时间的值。</returns>
	public static DateTime AsUtc(DateTime date)
	{
		return SpecifyKind(date, DateTimeKind.Utc);
	}

	/// <summary>
	/// 计算出生日期到当前日期为止的年龄
	/// </summary>
	/// <param name="birthday">出生日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>根据出生日期计算的年龄</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static double CalcAge(DateTime birthday, IFormatProvider provider = null)
	{
		return CalcAge(birthday, DateTime.Now, provider);
	}

	/// <summary>
	/// 计算出生日期到当前日期为止的年龄
	/// </summary>
	/// <param name="birthday">出生日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>根据出生日期计算的年龄</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static double CalcAge(DateTime birthday, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return CalcAge(birthday, DateTime.Now, calendar);
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
	public static double CalcAge(DateTime birthday, DateTime nowDate, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return CalcAge(birthday, nowDate, info.Calendar);
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
	public static double CalcAge(DateTime birthday, DateTime nowDate, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		Guard.AssertGreaterThanOrEqualTo(nowDate, birthday, "base date");
		int years = GetYear(nowDate, calendar) - GetYear(birthday, calendar);
		int baseDays = GetDayOfYear(nowDate, calendar);
		int birthdayDays = GetDayOfYear(birthday, calendar);
		if (baseDays >= birthdayDays)
		{
			return (double)years + (double)(baseDays - birthdayDays) * 1.0 / (double)GetDaysInYear(nowDate, calendar);
		}
		DateTime beforeDays = new DateTime(GetYear(nowDate, calendar) - 1, GetMonth(birthday, calendar), GetDaysInMonth(birthday, calendar), calendar);
		return (double)(years - 1) + (double)(GetDaysRemainedInYear(beforeDays, calendar) + baseDays) * 1.0 / (double)GetDaysInYear(nowDate, calendar);
	}

	/// <summary>
	/// 将当前字节数组反序列化为 <see cref="T:System.DateTime" /> 类型
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>反序列化后生成的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static DateTime DeserializeDateTime(byte[] bytes, int start = 0)
	{
		Guard.AssertNotNull(bytes, "bytes");
		return DateTime.FromBinary(ConvertHelper.GetInt64(bytes, start));
	}

	/// <summary>
	/// 将 <see cref="T:System.DateTime" /> 序列化后的64位二进制值反序列
	/// </summary>
	/// <param name="data"><see cref="T:System.DateTime" /> 序列化后的64位二进制值</param>
	/// <returns>反序列化后的值</returns>
	public static DateTime DeserializeDateTime(long data)
	{
		return DateTime.FromBinary(data);
	}

	/// <summary>
	/// 将当前字节数组反序列化为 <see cref="T:System.DateTimeOffset" /> 类型
	/// </summary>
	/// <param name="bytes">当前字节数组</param>
	/// <param name="start">待转换的字节的起始位置</param>
	/// <returns>反序列化后生成的日期</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字节数组为空。</exception>
	public static DateTimeOffset DeserializeDateTimeOffset(byte[] bytes, int start = 0)
	{
		DateTime dateTime = ConvertHelper.GetRawDateTime(bytes, start);
		TimeSpan timeSpan = ConvertHelper.GetRawTimeSpan(bytes, start);
		return new DateTimeOffset(dateTime, timeSpan);
	}

	/// <summary>
	/// 反序列化当前字符串，重新创建当前字符串表示的 <see cref="T:System.TimeZoneInfo" /> 对象
	/// </summary>
	/// <param name="serializedTimeZoneInfo">当前 <see cref="T:System.TimeZoneInfo" /> 对象的序列化字符串</param>
	/// <returns>反序列化生成的对象</returns>
	/// <exception cref="T:System.ArgumentNullException">当前字符串为空。</exception>
	public static TimeZoneInfo DeserializeTimeZoneInfo(string serializedTimeZoneInfo)
	{
		Guard.AssertNotNullAndEmpty(serializedTimeZoneInfo, "serialized TimeZoneInfo");
		return TimeZoneInfo.FromSerializedString(serializedTimeZoneInfo);
	}

	/// <summary>
	/// 检测当前日期与目标日期的指定部分是否相同
	/// </summary>
	/// <param name="date">当前日期</param>
	/// <param name="target">目标日期</param>
	/// <param name="parts">日期比较的部分</param>
	/// <returns>如果相等返回true，否则返回false。</returns>
	public static bool Equals(DateTime date, DateTime target, DateTimeParts parts)
	{
		return IsEqualTo(date, target, parts);
	}

	/// <summary>
	/// 将Unix格式日期转化为UTC日期
	/// </summary>
	/// <param name="seconds">Unix格式时间，自1970年1月1日零时起的秒数</param>
	/// <returns>转换后的UTC日期</returns>
	public static DateTime FromUnixTime(long seconds)
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
	public static DateTime GetBeginningOfDay(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.EnsureNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetBeginningOfDay(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在天的开始
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在天的开始（零时零分零秒）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetBeginningOfDay(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return new DateTime(GetYear(date, calendar), GetMonth(date, calendar), GetDay(date, calendar), calendar);
	}

	/// <summary>
	/// 获取指定的日期是该月的第几天
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定的日期是该月的第几天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDay(DateTime date, IFormatProvider provider = null)
	{
		return GetDay(date, provider);
	}

	/// <summary>
	/// 获取指定的日期是该月的第几天
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定的日期是该月的第几天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDay(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetDayOfMonth(date);
	}

	/// <summary>
	/// 获取指定日期是该月中的几号
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月中是几号</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDayOfMonth(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetDayOfMonth(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期是该月中的几号
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月中是几号</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDayOfMonth(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetDayOfMonth(date);
	}

	/// <summary>
	/// 获取指定日期是星期几
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期是星期几</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DayOfWeek GetDayOfWeek(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetDayOfWeek(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期是星期几
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期是星期几</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DayOfWeek GetDayOfWeek(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetDayOfWeek(date);
	}

	/// <summary>
	/// 获取指定日期在该年中是第几天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期在该年中是第几天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDayOfYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetDayOfYear(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期在该年中是第几天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期在该年中是第几天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDayOfYear(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetDayOfYear(date);
	}

	/// <summary>
	/// 获取指定日期所在月的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月的天数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysInMonth(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetDaysInMonth(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在月的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月的天数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysInMonth(DateTime date, Calendar calendar)
	{
		return calendar.GetDaysInMonth(GetYear(date, calendar), GetMonth(date, calendar));
	}

	/// <summary>
	/// 获取指定日期所在年的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年的天数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysInYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetDaysInYear(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年的天数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年的天数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysInYear(DateTime date, Calendar calendar)
	{
		return calendar.GetDaysInYear(GetYear(date, calendar));
	}

	/// <summary>
	/// 获取指定日期所在月还剩的天数（多少天到月底）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月还剩的天数（多少天到月底）</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysRemainedInMonth(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetDaysRemainedInMonth(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在月还剩的天数（多少天到月底）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月还剩的天数（多少天到月底）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysRemainedInMonth(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return GetDaysInMonth(date, calendar) - GetDayOfMonth(date, calendar);
	}

	/// <summary>
	/// 获取指定日期所在星期还剩的天数（多少天到周末）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在星期还剩的天数（多少天到周末）</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysRemainedInWeek(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetDaysRemainedInWeek(date, info.Calendar, info.FirstDayOfWeek);
	}

	/// <summary>
	/// 获取指定日期所在星期还剩的天数（多少天到周末）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <param name="firstDay">一周的第一天是星期几</param>
	/// <returns>指定日期所在星期还剩的天数（多少天到周末）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysRemainedInWeek(DateTime date, Calendar calendar, DayOfWeek firstDay)
	{
		Guard.AssertNotNull(calendar, "calendar");
		int lastDayOfWeek = (int)(firstDay - 1);
		lastDayOfWeek = ((lastDayOfWeek >= 0) ? lastDayOfWeek : (7 + lastDayOfWeek));
		int currentDayOfWeek = (int)GetDayOfWeek(date, calendar);
		return (currentDayOfWeek <= lastDayOfWeek) ? (lastDayOfWeek - currentDayOfWeek) : (lastDayOfWeek + 7 - currentDayOfWeek);
	}

	/// <summary>
	/// 获取指定日期所在年还剩的天数（多少天到年底）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年还剩的天数（多少天到年底）</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetDaysRemainedInYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetDaysRemainedInYear(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年还剩的天数（多少天到年底）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年还剩的天数（多少天到年底）</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetDaysRemainedInYear(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return GetDaysInYear(date, calendar) - GetDayOfYear(date, calendar);
	}

	/// <summary>
	/// 获取指定日期所在天的结束，最小精度为1毫秒
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在天的结束</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetEndOfDay(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetEndOfDay(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在天的结束，最小精度为1毫秒
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在天的结束</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetEndOfDay(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return AddMilliseconds(AddDays(date, 1, calendar).Date, -1.0, calendar);
	}

	/// <summary>
	/// 获取指定日期所在月的第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月的第一天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetFirstDayOfMonth(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetFirstDayOfMonth(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在月的第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月的第一天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetFirstDayOfMonth(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return AddDays(date, -(GetDayOfMonth(date, calendar) - 1), calendar).Date;
	}

	/// <summary>
	/// 获取指定日期所在季度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在季度的第一天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetFirstDayOfQuarter(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetFirstDayOfQuarter(date, GetFirstDayOfYear(date, info.Calendar), info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在季度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetFirstDayOfQuarter(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return GetFirstDayOfQuarter(date, GetFirstDayOfYear(date, calendar), calendar);
	}

	/// <summary>
	/// 获取指定日期所在季度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="quarterStartDate">年度季度的起始日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在季度的第一天</returns>
	public static DateTime GetFirstDayOfQuarter(DateTime date, DateTime quarterStartDate, Calendar calendar = null)
	{
		calendar = ObjectHelper.IfNull(calendar, CultureInfo.CurrentCulture.Calendar);
		for (int i = 0; i < 4; i++)
		{
			if (quarterStartDate <= date && date < AddMonths(quarterStartDate, 3, calendar).Date)
			{
				return quarterStartDate.Date;
			}
			quarterStartDate = AddMonths(quarterStartDate, 3, calendar);
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
	public static DateTime GetFirstDayOfWeek(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetFirstDayOfWeek(date, info.Calendar, info.FirstDayOfWeek);
	}

	/// <summary>
	/// 获取指定日期所在星期的第一天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <param name="firstDay">一周的第一天是星期几</param>
	/// <returns>指定日期所在星期的第一天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetFirstDayOfWeek(DateTime date, Calendar calendar, DayOfWeek firstDay)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return AddDays(date, -(7 - GetDaysRemainedInWeek(date, calendar, firstDay) - 1), calendar).Date;
	}

	/// <summary>
	/// 获取指定日期所在年度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年度第一天的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetFirstDayOfYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetFirstDayOfYear(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年度第一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年度第一天的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetFirstDayOfYear(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return AddDays(date, -(GetDayOfYear(date, calendar) - 1), calendar).Date;
	}

	/// <summary>
	/// 获取在指定日期的小时数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的小时数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetHour(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetHour(date, info.Calendar);
	}

	/// <summary>
	/// 获取在指定日期的小时数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的小时数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetHour(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetHour(date);
	}

	/// <summary>
	/// 获取指定日期所在月的最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在月的最后一天的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetLastDayOfMonth(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetLastDayOfMonth(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在月的最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在月的最后一天的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetLastDayOfMonth(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return AddDays(GetFirstDayOfMonth(AddMonths(date, 1, calendar), calendar), -1, calendar).Date;
	}

	/// <summary>
	/// 获取指定日期所在季度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在季度最后一天的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetLastDayOfQuarter(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetLastDayOfQuarter(date, GetFirstDayOfYear(date, info.Calendar), info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在季度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在季度最后一天的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetLastDayOfQuarter(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return GetLastDayOfQuarter(date, GetFirstDayOfYear(date, calendar), calendar);
	}

	/// <summary>
	/// 获取指定日期所在季度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="quarterStartDate">年度季度的起始日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在季度最后一天的日期</returns>
	public static DateTime GetLastDayOfQuarter(DateTime date, DateTime quarterStartDate, Calendar calendar = null)
	{
		calendar = ObjectHelper.IfNull(calendar, CultureInfo.CurrentCulture.Calendar);
		for (int i = 0; i < 4; i++)
		{
			if (quarterStartDate <= date && date < AddMonths(quarterStartDate, 3, calendar).Date)
			{
				return AddDays(AddMonths(quarterStartDate, 3, calendar), -1, calendar).Date;
			}
			quarterStartDate = AddMonths(quarterStartDate, 3, calendar);
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
	public static DateTime GetLastDayOfWeek(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetLastDayOfWeek(date, info.Calendar, info.FirstDayOfWeek);
	}

	/// <summary>
	/// 获取指定日期所在星期的最后一天
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <param name="firstDay">一个星期的第一天是星期几</param>
	/// <returns>指定日期所在星期的最后一天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetLastDayOfWeek(DateTime date, Calendar calendar, DayOfWeek firstDay)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return AddDays(GetFirstDayOfWeek(date, calendar, firstDay), 6, calendar);
	}

	/// <summary>
	/// 获取指定日期所在年度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年度的最后一天</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime GetLastDayOfYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetLastDayOfYear(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年度最后一天的日期
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年度的最后一天</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime GetLastDayOfYear(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return AddDays(AddYears(GetFirstDayOfYear(date, calendar), 1, calendar), -1, calendar).Date;
	}

	/// <summary>
	/// 获取指定日期所在年份的闰月
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年份的闰月</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetLeapMonth(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetLeapMonth(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年份的闰月
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年份的闰月</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetLeapMonth(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetLeapMonth(GetYear(date, calendar));
	}

	/// <summary>
	/// 获得本地时区
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>本地时间区域</returns>
	public static TimeZoneInfo GetLocalTimeZone(DateTime date)
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
	public static double GetMilliseconds(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetMilliseconds(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的毫秒
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>获取指定日期的毫秒</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static double GetMilliseconds(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetMilliseconds(date);
	}

	/// <summary>
	/// 获取指定日期的分钟数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的分钟数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetMinute(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetMinute(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的分钟数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的分钟数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetMinute(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetMinute(date);
	}

	/// <summary>
	/// 获取指定日期的月份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的月份</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetMonth(DateTime date, IFormatProvider provider = null)
	{
		return GetMonthOfYear(date, provider);
	}

	/// <summary>
	/// 获取指定日期的月份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的月份</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetMonth(DateTime date, Calendar calendar)
	{
		return GetMonthOfYear(date, calendar);
	}

	/// <summary>
	/// 获取指定日期的月份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的月份</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetMonthOfYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetMonthOfYear(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的月份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的月份</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetMonthOfYear(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetMonth(date);
	}

	/// <summary>
	/// 获取指定日期所在年的月数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年的月数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetMonthsInYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetMonthsInYear(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期所在年的月数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期所在年的月数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetMonthsInYear(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetMonthsInYear(GetYear(date, calendar));
	}

	/// <summary>
	/// 获取指定日期的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的秒数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetSecond(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetSecond(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期的秒数</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetSecond(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
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
	public static TimeZoneInfo GetTimeZone(DateTime date)
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
	public static int GetWeekOfYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetWeekOfYear(date, info.Calendar, info.CalendarWeekRule, info.FirstDayOfWeek);
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
	public static int GetWeekOfYear(DateTime date, Calendar calendar, CalendarWeekRule rule, DayOfWeek firstDay)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetWeekOfYear(date, rule, firstDay);
	}

	/// <summary>
	/// 返回指定日期所在年的星期数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期所在年的星期数</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetWeeksInYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetWeeksInYear(date, info.Calendar, info.CalendarWeekRule, info.FirstDayOfWeek);
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
	public static int GetWeeksInYear(DateTime date, Calendar calendar, CalendarWeekRule rule, DayOfWeek firstDay)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetWeekOfYear(GetLastDayOfYear(date, calendar), rule, firstDay);
	}

	/// <summary>
	/// 获取指定日期的年份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>指定日期的年份</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static int GetYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return GetYear(date, info.Calendar);
	}

	/// <summary>
	/// 获取指定日期的年份
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>指定日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static int GetYear(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.GetYear(date);
	}

	/// <summary>
	/// 检测指定的日期是否早于目标日期，仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定日期早于目标日期返回true，否则返回false。</returns>
	public static bool IsDateEarlierThan(DateTime date, DateTime target)
	{
		return date.Date < target.Date;
	}

	/// <summary>
	/// 检测指定的日期是否不晚于目标日期，仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定日期不晚于目标日期返回true，否则返回false。</returns>
	public static bool IsDateEarlierThanOrEqualTo(DateTime date, DateTime target)
	{
		return date.Date <= target.Date;
	}

	/// <summary>
	/// 检测指定日期和目标日期的日期部分是否相等
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果相等返回true，否则返回false</returns>
	public static bool IsDateEqualTo(DateTime date, DateTime target)
	{
		return date.Date.Equals(target.Date);
	}

	/// <summary>
	/// 判断指定日期是否晚于目标日期，仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定的日期晚于目标日期则返回true，否则返回false</returns>
	public static bool IsDateLaterThan(DateTime date, DateTime target)
	{
		return date.Date > target.Date;
	}

	/// <summary>
	/// 判断指定日期是否不早于目标日期，仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定的日期不早于目标日期则返回true，否则返回false</returns>
	public static bool IsDateLaterThanOrEqualTo(DateTime date, DateTime target)
	{
		return date.Date >= target.Date;
	}

	/// <summary>
	/// 检测指定日期是否早于目标日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果早于返回true，否则返回false</returns>
	public static bool IsEarlierThan(DateTime date, DateTime target)
	{
		return date < target;
	}

	/// <summary>
	/// 检测指定日期是否不晚于目标日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果不晚于返回true，否则返回false</returns>
	public static bool IsEarlierThanOrEqualTo(DateTime date, DateTime target)
	{
		return date <= target;
	}

	/// <summary>
	/// 检测当前日期是否与目标日期相同
	/// </summary>
	/// <param name="date">当前日期</param>
	/// <param name="target">目标日期</param>
	/// <returns>如果相等则返回true，否则返回false。</returns>
	public static bool IsEqualTo(DateTime date, DateTime target)
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
	public static bool IsEqualTo(DateTime date, DateTime target, DateTimeParts parts)
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
	public static bool IsFuture(DateTime date)
	{
		return date > DateTime.Now;
	}

	/// <summary>
	/// 判断指定日期是否是将来的日期（大于当前日期），仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>如果指定的日期晚于当前日期返回true，否则返回false</returns>
	public static bool IsFutureDate(DateTime date)
	{
		return date.Date > DateTime.Now.Date;
	}

	/// <summary>
	/// 判断指定时间是否是将来的时间（大于当前时间）
	/// </summary>
	/// <param name="time">指定的时间</param>
	/// <returns>如果指定的时间晚于当前时间返回true，否则返回false</returns>
	public static bool IsFutureTime(DateTime time)
	{
		return time.TimeOfDay > DateTime.Now.TimeOfDay;
	}

	/// <summary>
	/// 判断指定日期是否晚于目标日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定的日期晚于目标日期则返回true，否则返回false</returns>
	public static bool IsLaterThan(DateTime date, DateTime target)
	{
		return date > target;
	}

	/// <summary>
	/// 判断指定日期是否不早于目标日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果指定的日期不早于目标日期则返回true，否则返回false</returns>
	public static bool IsLaterThanOrEqualTo(DateTime date, DateTime target)
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
	public static bool IsLeapDay(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return IsLeapDay(date, info.Calendar);
	}

	/// <summary>
	/// 检测指定日期所在的日是否是闰日
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果是闰日返回true，否则false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsLeapDay(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.IsLeapDay(GetYear(date, calendar), GetMonth(date, calendar), GetDay(date, calendar));
	}

	/// <summary>
	/// 检测指定日期所在的月是否是闰月
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>如果是闰月返回true，否则返回false。</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static bool IsLeapMonth(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return IsLeapMonth(date, info.Calendar);
	}

	/// <summary>
	/// 检测指定日期所在的月是否是闰月
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果是闰月返回true，否则false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsLeapMonth(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.IsLeapMonth(GetYear(date, calendar), GetMonth(date, calendar));
	}

	/// <summary>
	/// 检测指定日期所在的年是否是闰年
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>如果是闰年返回true，否则false</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static bool IsLeapYear(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return IsLeapYear(date, info.Calendar);
	}

	/// <summary>
	/// 检测指定日期所在的年是否是闰年
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果是闰年返回true，否则false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsLeapYear(DateTime date, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return calendar.IsLeapYear(GetYear(date, calendar));
	}

	/// <summary>
	/// 判断指定日期是否是过去的日期（早于当前日期）
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>如果指定日期早于当前时间返回true，否则返回false</returns>
	public static bool IsPast(DateTime date)
	{
		return date < DateTime.Now;
	}

	/// <summary>
	/// 判断指定日期是否是过去的日期（早于当前日期），仅比较日期部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>如果指定日期早于当前时间返回true，否则返回false</returns>
	public static bool IsPastDate(DateTime date)
	{
		return date.Date < DateTime.Now.Date;
	}

	/// <summary>
	/// 判断指定时间是否是过去的时间
	/// </summary>
	/// <param name="time">指定的时间</param>
	/// <returns>如果指定的时间早于当前时间返回true，否则返回false</returns>
	public static bool IsPastTime(DateTime time)
	{
		return time.TimeOfDay < DateTime.Now.TimeOfDay;
	}

	/// <summary>
	/// 检测指定的时间是否早于目标时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="target">比较的目标时间</param>
	/// <returns>如果指定时间早于目标时间返回true，否则返回false。</returns>
	public static bool IsTimeEarlierThan(DateTime date, DateTime target)
	{
		return date.TimeOfDay < target.TimeOfDay;
	}

	/// <summary>
	/// 检测指定的时间是否不晚于目标时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="target">比较的目标时间</param>
	/// <returns>如果指定时间不晚于目标时间返回true，否则返回false。</returns>
	public static bool IsTimeEarlierThanOrEqualTo(DateTime date, DateTime target)
	{
		return date.TimeOfDay <= target.TimeOfDay;
	}

	/// <summary>
	/// 检测指定日期和目标日期的时间部分是否相等
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果相等返回true，否则返回false</returns>
	public static bool IsTimeEqualTo(DateTime date, DateTime target)
	{
		return date.TimeOfDay.Equals(target.TimeOfDay);
	}

	/// <summary>
	/// 判断指定时间是否晚于目标时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="target">比较的目标时间</param>
	/// <returns>如果指定的时间晚于目标时间则返回true，否则返回false</returns>
	public static bool IsTimeLaterThan(DateTime date, DateTime target)
	{
		return date.TimeOfDay > target.TimeOfDay;
	}

	/// <summary>
	/// 判断指定时间是否不早于目标时间
	/// </summary>
	/// <param name="date">指定的时间</param>
	/// <param name="target">比较的目标时间</param>
	/// <returns>如果指定的时间不早于目标时间则返回true，否则返回false</returns>
	public static bool IsTimeLaterThanOrEqualTo(DateTime date, DateTime target)
	{
		return date.TimeOfDay >= target.TimeOfDay;
	}

	/// <summary>
	/// 判断指定日期是否是今天（指定日期和当前时间的日期部分相等）
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>如果是今天返回true，否则返回false。</returns>
	public static bool IsToday(DateTime date)
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
	public static bool IsWeekend(DateTime date, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return new DayOfWeek[2]
		{
			DayOfWeek.Saturday,
			DayOfWeek.Sunday
		}.Any((DayOfWeek x) => x == GetDayOfWeek(date, info.Calendar));
	}

	/// <summary>
	/// 判断指定日期是否是周末
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="weekends">一周中周末是那几天</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>如果指定日期是周末返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static bool IsWeekend(DateTime date, DayOfWeek[] weekends, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return ObjectHelper.IfNull(weekends, new DayOfWeek[2]
		{
			DayOfWeek.Saturday,
			DayOfWeek.Sunday
		}).Any((DayOfWeek x) => x == GetDayOfWeek(date, info.Calendar));
	}

	/// <summary>
	/// 判断指定日期是否是周末
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果指定日期是周末返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsWeekend(DateTime date, Calendar calendar)
	{
		return new DayOfWeek[2]
		{
			DayOfWeek.Saturday,
			DayOfWeek.Sunday
		}.Any((DayOfWeek x) => x == GetDayOfWeek(date, calendar));
	}

	/// <summary>
	/// 判断指定日期是否是周末
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="weekends">一周中周末是那几天</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>如果指定日期是周末返回true，否则返回false</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static bool IsWeekend(DateTime date, DayOfWeek[] weekends, Calendar calendar)
	{
		return ObjectHelper.IfNull(weekends, new DayOfWeek[2]
		{
			DayOfWeek.Saturday,
			DayOfWeek.Sunday
		}).Any((DayOfWeek x) => x == GetDayOfWeek(date, calendar));
	}

	/// <summary>
	/// 把指定的日期序列化为字节数组
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>指定的日期序列化的字节数组</returns>
	public static byte[] Serialize(DateTime date)
	{
		return ConvertHelper.GetBytes(date.ToBinary());
	}

	/// <summary>
	/// 把当前 <see cref="T:System.DateTimeOffset" /> 型数值序列化为相应的字节数组
	/// </summary>
	/// <param name="date">当前数值</param>
	/// <returns>转换后的字节数组</returns>
	public static byte[] Serialize(DateTimeOffset date)
	{
		byte[] bytes = new byte[16];
		Array.Copy(ConvertHelper.GetRawBytes(date.DateTime), bytes, 8);
		Array.Copy(ConvertHelper.GetRawBytes(date.Offset), 0, bytes, 8, 8);
		return bytes;
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
	public static DateTime SetDate(DateTime date, int year, int month, int day, IFormatProvider provider = null)
	{
		provider = ObjectHelper.IfNull(provider, CultureInfo.CurrentCulture);
		DateTimeFormatInfo info = (DateTimeFormatInfo)provider.GetFormat(typeof(DateTimeFormatInfo));
		Guard.AssertNotNull(info, typeof(ArgumentException), Literals.MSG_InvalidFormatProvider, "provider");
		return SetDate(date, year, month, day, info.Calendar);
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
	public static DateTime SetDate(DateTime date, int year, int month, int day, Calendar calendar)
	{
		Guard.AssertNotNull(calendar, "calendar");
		return AddMilliseconds(new DateTime(year, month, day, calendar), (date - date.Date).TotalMilliseconds, calendar);
	}

	/// <summary>
	/// 设置指定日期的日数
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="day">设置的日数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置日数后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetDay(DateTime date, int day, IFormatProvider provider = null)
	{
		return AddDays(date, day - GetDayOfMonth(date, provider), provider);
	}

	/// <summary>
	/// 设置指定日期的日数
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="day">设置的日数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置日数后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetDay(DateTime date, int day, Calendar calendar)
	{
		return AddDays(date, day - GetDayOfMonth(date, calendar), calendar);
	}

	/// <summary>
	/// 设置指定日期的小时
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="hour">设置的小时数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置小时后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetHour(DateTime date, int hour, IFormatProvider provider = null)
	{
		return AddHours(date, hour - GetHour(date, provider), provider);
	}

	/// <summary>
	/// 设置指定日期的小时
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="hour">设置的小时数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置小时后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetHour(DateTime date, int hour, Calendar calendar)
	{
		return AddHours(date, hour - GetHour(date, calendar), calendar);
	}

	/// <summary>
	/// 设置指定的日期的分钟
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="minute">设置的分钟数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置分钟后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetMinute(DateTime date, int minute, IFormatProvider provider = null)
	{
		return AddMinutes(date, minute - GetMinute(date, provider), provider);
	}

	/// <summary>
	/// 设置指定的日期的分钟
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="minute">设置的分钟数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置分钟后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetMinute(DateTime date, int minute, Calendar calendar)
	{
		return AddMinutes(date, minute - GetMinute(date, calendar), calendar);
	}

	/// <summary>
	/// 设置指定的日期的月份
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="month">设置的月份</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置月份后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetMonth(DateTime date, int month, IFormatProvider provider = null)
	{
		return AddMonths(date, month - GetMonth(date, provider), provider);
	}

	/// <summary>
	/// 设置指定的日期的月份
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="month">设置的月份</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置月份后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetMonth(DateTime date, int month, Calendar calendar)
	{
		return AddMonths(date, month - GetMonth(date, calendar), calendar);
	}

	/// <summary>
	/// 设置指定的日期的秒数
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="second">设置的秒数</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置秒数后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetSecond(DateTime date, int second, IFormatProvider provider = null)
	{
		return AddSeconds(date, second - GetSecond(date, provider), provider);
	}

	/// <summary>
	/// 设置指定的日期的秒数
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="second">设置的秒数</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置秒数后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetSecond(DateTime date, int second, Calendar calendar)
	{
		return AddSeconds(date, second - GetSecond(date, calendar), calendar);
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
	public static DateTime SetTime(DateTime date, int hour, int minutes, int seconds, int millisecond, IFormatProvider provider = null)
	{
		return SetTime(date, new TimeSpan(0, hour, minutes, seconds, millisecond), provider);
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
	public static DateTime SetTime(DateTime date, int hour, int minutes, int seconds, int millisecond, Calendar calendar)
	{
		return SetTime(date, new TimeSpan(0, hour, minutes, seconds, millisecond), calendar);
	}

	/// <summary>
	/// 设置指定的日期的时间部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="time">设置的时间</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置时间后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetTime(DateTime date, TimeSpan time, IFormatProvider provider = null)
	{
		return AddMilliseconds(date.Date, time.TotalMilliseconds, provider);
	}

	/// <summary>
	/// 设置指定的日期的时间部分
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="time">设置的时间</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置时间后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetTime(DateTime date, TimeSpan time, Calendar calendar)
	{
		return AddMilliseconds(date.Date, time.TotalMilliseconds, calendar);
	}

	/// <summary>
	/// 设置指定的日期的年份
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="year">设置的年份</param>
	/// <param name="provider">使用的格式化信息</param>
	/// <returns>设置年份后的日期</returns>
	/// <exception cref="T:System.ArgumentException"><paramref name="provider" /> 的 <see cref="M:System.IFormatProvider.GetFormat(System.Type)" /> 方法不返回 <see cref="T:System.Globalization.DateTimeFormatInfo" /> 对象。</exception>
	public static DateTime SetYear(DateTime date, int year, IFormatProvider provider = null)
	{
		return AddYears(date, year - GetYear(date, provider), provider);
	}

	/// <summary>
	/// 设置指定的日期的年份
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="year">设置的年份</param>
	/// <param name="calendar">使用的日历</param>
	/// <returns>设置年份后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="calendar" /> 为空。</exception>
	public static DateTime SetYear(DateTime date, int year, Calendar calendar)
	{
		return AddYears(date, year - GetYear(date, calendar), calendar);
	}

	/// <summary>
	/// 设置指定日期的种类
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="kind">设置的日期类型</param>
	/// <returns>处理后的日期</returns>
	public static DateTime SpecifyKind(DateTime date, DateTimeKind kind)
	{
		return DateTime.SpecifyKind(date, kind);
	}

	/// <summary>
	/// 检测指定日期和目标日期的时间部分是否相等
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="target">比较的目标日期</param>
	/// <returns>如果相等返回true，否则返回false。</returns>
	public static bool TimeEquals(DateTime date, DateTime target)
	{
		return date.TimeOfDay.Equals(target.TimeOfDay);
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <returns>转换后的日期</returns>
	/// <exception cref="T:System.ArgumentException">指定的日期的 <see cref="P:System.DateTime.Kind" /> 属性等于 <see cref="F:System.DateTimeKind.Unspecified" />。</exception>
	public static DateTimeOffset ToDateTimeOffset(DateTime date)
	{
		return date.Kind switch
		{
			DateTimeKind.Utc => new DateTimeOffset(date, TimeZoneInfo.Utc.BaseUtcOffset), 
			DateTimeKind.Local => new DateTimeOffset(date, TimeZoneInfo.Local.BaseUtcOffset), 
			_ => throw new ArgumentException(string.Format(Literals.MSG_InvalidDateTimeKind_1, date), "date"), 
		};
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="timezone">转换使用的时区</param>
	/// <returns>转换后的日期</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="timezone" /> 为空。</exception>
	public static DateTimeOffset ToDateTimeOffset(DateTime date, TimeZoneInfo timezone)
	{
		Guard.AssertNotNull(timezone, "timezone");
		return new DateTimeOffset(AsUnspecified(date), timezone.BaseUtcOffset);
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="offset">转换使用的时区偏移</param>
	/// <returns>转换后的日期</returns>
	public static DateTimeOffset ToDateTimeOffset(DateTime date, TimeSpan offset)
	{
		return new DateTimeOffset(AsUnspecified(date), offset);
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="minutes">转换使用的时区偏移分钟</param>
	/// <returns>转换后的日期</returns>
	public static DateTimeOffset ToDateTimeOffset(DateTime date, int minutes)
	{
		return new DateTimeOffset(AsUnspecified(date), TimeSpan.FromMinutes(minutes));
	}

	/// <summary>
	/// 将指定日期转换为 <see cref="T:System.DateTimeOffset" /> 类型日期
	/// </summary>
	/// <param name="date">指定的日期</param>
	/// <param name="hours">转换使用的时区偏移小时</param>
	/// <returns>转换后的日期</returns>
	public static DateTimeOffset ToDateTimeOffset(DateTime date, double hours)
	{
		return new DateTimeOffset(AsUnspecified(date), TimeSpan.FromHours(hours));
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
	public static DateTime ToLocal(DateTime date)
	{
		return date.Kind switch
		{
			DateTimeKind.Utc => TimeZoneInfo.ConvertTime(date, TimeZoneInfo.Utc, TimeZoneInfo.Local), 
			DateTimeKind.Local => date, 
			_ => throw new ArgumentException(string.Format(Literals.MSG_InvalidDateTimeKind_1, date), "date"), 
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
	public static DateTime ToLocal(DateTime date, TimeZoneInfo sourceTimeZone)
	{
		Guard.AssertNotNull(sourceTimeZone, "Source Timezone");
		return TimeZoneInfo.ConvertTime(AsUnspecified(date), sourceTimeZone, TimeZoneInfo.Local);
	}

	/// <summary>
	/// 将指定时间转换为本地时间
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="minutes">指定时间的时区偏移分钟数</param>
	/// <returns>转换后的本地时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="minutes" /> 超出有效时区偏移量，正负840分钟，14小时。</exception>
	public static DateTime ToLocal(DateTime date, int minutes)
	{
		Guard.AssertBetween(minutes, -840, 840, "minutes");
		return AsLocal(date.AddMinutes(-minutes));
	}

	/// <summary>
	/// 将指定时间转换为本地时间
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="hours">指定时间的时区偏移小时数</param>
	/// <returns>转换后的本地时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="hours" /> 超出有效时区偏移量，正负14小时。</exception>
	public static DateTime ToLocal(DateTime date, double hours)
	{
		Guard.AssertBetween(hours, -14.0, 14.0, "hours");
		return AsLocal(date.AddHours(0.0 - hours));
	}

	/// <summary>
	/// 将指定时间转换为本地时间
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="offset">指定时间的时区偏移</param>
	/// <returns>转换后的本地时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset" /> 超出有效时区偏移量，正负14小时。</exception>
	public static DateTime ToLocal(DateTime date, TimeSpan offset)
	{
		Guard.AssertBetween(offset.TotalHours, -14.0, 14.0, "offset");
		return AsUtc(date.Subtract(offset));
	}

	/// <summary>
	/// 将协调世界时（UTC）转换为本地时间
	/// </summary>
	/// <param name="date">协调世界时（UTC）</param>
	/// <returns>转换后的本地时间</returns>
	/// <remarks>本方法始终将指定的时间作为协调世界时（UTC）转换为本地时间。</remarks>
	public static DateTime ToLocalFromUtc(DateTime date)
	{
		return TimeZoneInfo.ConvertTime(AsUtc(date), TimeZoneInfo.Utc, TimeZoneInfo.Local);
	}

	/// <summary>
	/// 将指定日期转换为指定时区的时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="hours">目标时区的偏移量，小时</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="hours" /> 超出了时区偏移的范围，正负14小时。</exception>
	public static DateTimeOffset ToOffset(DateTimeOffset date, double hours)
	{
		Guard.AssertBetween(hours, -14.0, 14.0, "hours");
		return date.ToOffset(TimeSpan.FromHours(hours));
	}

	/// <summary>
	/// 将指定日期转换为指定时区的时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="minutes">目标时区的偏移量，分钟</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="minutes" /> 超出了时区偏移的范围，正负840分钟。</exception>
	public static DateTimeOffset ToOffset(DateTimeOffset date, int minutes)
	{
		Guard.AssertBetween(minutes, -14, 14, "hours");
		return date.ToOffset(TimeSpan.FromMinutes(minutes));
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
	public static DateTime ToUtc(DateTime date)
	{
		return date.Kind switch
		{
			DateTimeKind.Utc => date, 
			DateTimeKind.Local => TimeZoneInfo.ConvertTime(date, TimeZoneInfo.Local, TimeZoneInfo.Utc), 
			_ => throw new ArgumentException(string.Format(Literals.MSG_InvalidDateTimeKind_1, date), "date"), 
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
	public static DateTime ToUtc(DateTime date, TimeZoneInfo sourceTimeZone)
	{
		Guard.AssertNotNull(sourceTimeZone, "Source Timezone");
		return TimeZoneInfo.ConvertTime(AsUnspecified(date), sourceTimeZone, TimeZoneInfo.Utc);
	}

	/// <summary>
	/// 将指定时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="minutes">指定时间的时区偏移分钟数</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="minutes" /> 超出有效时区偏移量，正负840分钟，14小时。</exception>
	public static DateTime ToUtc(DateTime date, int minutes)
	{
		Guard.AssertBetween(minutes, -840, 840, "minutes");
		return AsUtc(date.AddMinutes(-minutes));
	}

	/// <summary>
	/// 将指定时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="hours">指定时间的时区偏移小时数</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="hours" /> 超出有效时区偏移量，正负14小时。</exception>
	public static DateTime ToUtc(DateTime date, double hours)
	{
		Guard.AssertBetween(hours, -14.0, 14.0, "hours");
		return AsUtc(date.AddHours(0.0 - hours));
	}

	/// <summary>
	/// 将指定时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定时间</param>
	/// <param name="offset">指定时间的时区偏移</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset" /> 超出有效时区偏移量，正负14小时。</exception>
	public static DateTime ToUtc(DateTime date, TimeSpan offset)
	{
		Guard.AssertBetween(offset.TotalHours, -14.0, 14.0, "offset");
		return AsUtc(date.Subtract(offset));
	}

	/// <summary>
	/// 将本地时间转换为协调世界时（UTC）
	/// </summary>
	/// <param name="date">本地时间</param>
	/// <returns>转换后的协调世界时（UTC）</returns>
	/// <remarks>本方法始终将指定的时间作为本地时间转换为协调世界时。</remarks>
	public static DateTime ToUtcFromLocal(DateTime date)
	{
		return TimeZoneInfo.ConvertTime(AsLocal(date), TimeZoneInfo.Local, TimeZoneInfo.Utc);
	}

	/// <summary>
	/// 将指定日期转化为Unix时间，Unix时间为自1970年1月1日零时起的秒数
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <returns>Unix时间</returns>
	public static long ToUnixTime(DateTime date)
	{
		return (AsUtc(date) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).Ticks / 10000000;
	}

	/// <summary>
	/// 将指定的时间转换为目标时区的时间
	/// </summary>
	/// <param name="date">指定的时间（本地时间）</param>
	/// <param name="targetTimeZone">目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTime ToTimeZone(DateTime date, TimeZoneInfo targetTimeZone)
	{
		Guard.AssertNotNull(targetTimeZone, "target timezone");
		if (date.Kind == DateTimeKind.Unspecified)
		{
			throw new ArgumentException(string.Format(Literals.MSG_InvalidDateTimeKind_1, date), "date");
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
	public static DateTime ToTimeZone(DateTime date, TimeZoneInfo sourceTimeZone, TimeZoneInfo targetTimeZone)
	{
		Guard.AssertNotNull(sourceTimeZone, "source timezone");
		Guard.AssertNotNull(targetTimeZone, "target timezone");
		return TimeZoneInfo.ConvertTime(AsUnspecified(date), sourceTimeZone, targetTimeZone);
	}

	/// <summary>
	/// 将指定的时间转换为目标时区的时间，指定的时间始终认为是本地时间
	/// </summary>
	/// <param name="date">指定的时间（本地时间）</param>
	/// <param name="targetTimeZone">目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTime ToTimeZoneFromLocal(DateTime date, TimeZoneInfo targetTimeZone)
	{
		Guard.AssertNotNull(targetTimeZone, "target timezone");
		return TimeZoneInfo.ConvertTime(AsLocal(date), TimeZoneInfo.Local, targetTimeZone);
	}

	/// <summary>
	/// 将指定的时间转换为目标时区的时间，指定的时间始终认为是协调世界时（UTC）
	/// </summary>
	/// <param name="date">指定的时间（协调世界时（UTC））</param>
	/// <param name="targetTimeZone">目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTime ToTimeZoneFromUtc(DateTime date, TimeZoneInfo targetTimeZone)
	{
		Guard.AssertNotNull(targetTimeZone, "target timezone");
		return TimeZoneInfo.ConvertTime(AsUtc(date), TimeZoneInfo.Utc, targetTimeZone);
	}

	/// <summary>
	/// 将指定日期转换为指定时区的时间
	/// </summary>
	/// <param name="date">指定日期</param>
	/// <param name="targetTimeZone">转换的目标时区</param>
	/// <returns>转换后的目标时区时间</returns>
	/// <exception cref="T:System.ArgumentNullException"><paramref name="targetTimeZone" /> 为空。</exception>
	public static DateTimeOffset ToTimeZone(DateTimeOffset date, TimeZoneInfo targetTimeZone)
	{
		Guard.AssertNotNull(targetTimeZone, "target timezone");
		return TimeZoneInfo.ConvertTime(date, targetTimeZone);
	}
}
