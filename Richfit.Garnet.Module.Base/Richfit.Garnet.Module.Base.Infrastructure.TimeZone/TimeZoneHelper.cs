using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.Infrastructure.Session;

namespace Richfit.Garnet.Module.Base.Infrastructure.TimeZone;

/// <summary>
/// 时区帮助类
/// </summary>
public class TimeZoneHelper
{
	/// <summary>
	/// 安装时区设置，获取系统当前时间。
	/// </summary>
	/// <value>系统的当前时间。如果开启了多时区设置则返回UTC前时间；如果未开启多时区则返回本地当前时间。</value>
	/// <seealso cref="P:System.DateTime.Now" />
	/// <seealso cref="P:System.DateTime.UtcNow" />
	public static DateTime Now => ConfigurationManager.System.Settings.EnableTimeOffset ? DateTime.UtcNow : DateTime.Now;

	/// <summary>
	/// 将本地时间转化为UTC时间，时间偏移量来源于Session
	/// </summary>
	/// <param name="localTime"></param>
	/// <returns></returns>
	public static DateTime LocalTimeToUtc(DateTime localTime)
	{
		if (ConfigurationManager.System.Settings.EnableTimeOffset)
		{
			int timeOffset = SessionContext.UserInfo?.TimeOffset ?? 0;
			return LocalTimeToUtc(localTime, timeOffset);
		}
		return localTime;
	}

	/// <summary>
	/// 将本地时间转化为UTC时间
	/// </summary>
	/// <param name="localTime"></param>
	/// <param name="timeOffset"></param>
	/// <returns></returns>
	public static DateTime LocalTimeToUtc(DateTime localTime, int timeOffset)
	{
		timeOffset *= 60;
		if ((localTime - DateTime.MinValue).TotalMinutes >= (double)timeOffset)
		{
			return localTime.AddMinutes(-timeOffset);
		}
		return DateTime.MinValue;
	}

	/// <summary>
	/// 将UTC时间转化为本地时间，时间偏移量来源于Session
	/// </summary>
	/// <param name="utcTime"></param>
	/// <returns></returns>
	public static DateTime UtcTimeToLocal(DateTime utcTime)
	{
		if (ConfigurationManager.System.Settings.EnableTimeOffset)
		{
			int timeOffset = SessionContext.UserInfo?.TimeOffset ?? 0;
			return UtcTimeToLocal(utcTime, timeOffset);
		}
		return utcTime;
	}

	/// <summary>
	/// 将UTC时间转化为本地时间
	/// </summary>
	/// <param name="utcTime"></param>
	/// <param name="timeOffset"></param>
	/// <returns></returns>
	public static DateTime UtcTimeToLocal(DateTime utcTime, int timeOffset)
	{
		timeOffset *= 60;
		return utcTime.AddMinutes(timeOffset);
	}

	/// <summary>
	/// 将实体对象中所有时间类型的属性值（认为是本地时间）转化为UTC时间，不需要处理的属性用ZoneAway Attribute标识
	/// 时间偏移量来源于Session
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="item"></param>
	public static void LocalTimeToUtc<TEntity>(TEntity item) where TEntity : class
	{
		if (ConfigurationManager.System.Settings.EnableTimeOffset)
		{
			int timeOffset = SessionContext.UserInfo?.TimeOffset ?? 0;
			if (timeOffset != 0)
			{
				LocalTimeToUtc(item, timeOffset);
			}
		}
	}

	/// <summary>
	/// 将实体对象中所有时间类型的属性值（认为是本地时间）转化为UTC时间，不需要处理的属性用ZoneAway Attribute标识
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="item"></param>
	/// <param name="timeOffset">时间分钟的偏移量</param>
	public static void LocalTimeToUtc<TEntity>(TEntity item, int timeOffset) where TEntity : class
	{
		timeOffset = ((Math.Abs(timeOffset) < 24) ? (timeOffset * 60) : timeOffset);
		IEnumerable<PropertyInfo> result = from x in item.GetType().GetProperties()
			where x.PropertyType.IsType(typeof(DateTime)) || x.PropertyType.IsType(typeof(DateTime?))
			select x;
		if (result == null || !result.Any())
		{
			return;
		}
		foreach (PropertyInfo property in result)
		{
			object[] attribute = property.GetCustomAttributes(typeof(ZoneAwayAttribute), inherit: false);
			if (attribute != null && attribute.Length != 0)
			{
				continue;
			}
			if (property.PropertyType.IsType(typeof(DateTime)))
			{
				DateTime dateTime = (DateTime)property.GetValue(item, null);
				if ((dateTime - DateTime.MinValue).TotalMinutes >= (double)timeOffset)
				{
					dateTime = dateTime.AddMinutes(-timeOffset);
					property.SetValue(item, dateTime, null);
				}
				continue;
			}
			object obj = property.GetValue(item, null);
			if (obj != null)
			{
				DateTime dateTime = (DateTime)obj;
				if ((dateTime - DateTime.MinValue).TotalMinutes >= (double)timeOffset)
				{
					dateTime = dateTime.AddMinutes(-timeOffset);
					property.SetValue(item, dateTime, null);
				}
			}
		}
	}

	/// <summary>
	/// 将实体对象中所有时间类型的属性值（认为是UTC时间）转化为某时区的当地时间，不需要处理的属性用ZoneAway Attribute标识
	///  时间偏移量来源于Session
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="item"></param>
	public static void UtcTimeToLocal<TEntity>(TEntity item) where TEntity : class
	{
		if (ConfigurationManager.System.Settings.EnableTimeOffset)
		{
			int timeOffset = SessionContext.UserInfo?.TimeOffset ?? 0;
			if (timeOffset != 0)
			{
				UtcTimeToLocal(item, timeOffset);
			}
		}
	}

	/// <summary>
	/// 将实体对象中所有时间类型的属性值（认为是UTC时间）转化为某时区的当地时间，不需要处理的属性用ZoneAway Attribute标识
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	/// <param name="item"></param>
	/// <param name="timeOffset">时间分钟的偏移量</param>
	public static void UtcTimeToLocal<TEntity>(TEntity item, int timeOffset) where TEntity : class
	{
		timeOffset = ((Math.Abs(timeOffset) < 24) ? (timeOffset * 60) : timeOffset);
		IEnumerable<PropertyInfo> result = from x in item.GetType().GetProperties()
			where x.PropertyType.IsType(typeof(DateTime)) || x.PropertyType.IsType(typeof(DateTime?))
			select x;
		if (result == null || !result.Any())
		{
			return;
		}
		foreach (PropertyInfo property in result)
		{
			object[] attribute = property.GetCustomAttributes(typeof(ZoneAwayAttribute), inherit: false);
			if (attribute != null && attribute.Length != 0)
			{
				continue;
			}
			if (property.PropertyType.IsType(typeof(DateTime)))
			{
				DateTime dateTime = ((DateTime)property.GetValue(item, null)).AddMinutes(timeOffset);
				property.SetValue(item, dateTime, null);
				continue;
			}
			object obj = property.GetValue(item, null);
			if (obj != null)
			{
				DateTime dateTime = ((DateTime)obj).AddMinutes(timeOffset);
				property.SetValue(item, dateTime, null);
			}
		}
	}
}
