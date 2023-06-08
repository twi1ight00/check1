using System;
using Common.Logging;
using Quartz.Util;

namespace Quartz.Impl;

/// <summary>
/// This utility calls methods reflectively on the given objects even though the
/// methods are likely on a proper interface (ThreadPool, JobStore, etc). The
/// motivation is to be tolerant of older implementations that have not been
/// updated for the changes in the interfaces (eg. LocalTaskExecutorThreadPool in
/// spring quartz helpers)
/// </summary>
/// <author>teck</author>
/// <author>Marko Lahma (.NET)</author>
internal static class SchedulerDetailsSetter
{
	private static readonly ILog log = LogManager.GetLogger(typeof(SchedulerDetailsSetter));

	internal static void SetDetails(object target, string schedulerName, string schedulerId)
	{
		Set(target, "InstanceName", schedulerName);
		Set(target, "InstanceId", schedulerId);
	}

	private static void Set(object target, string propertyName, string propertyValue)
	{
		try
		{
			ObjectUtils.SetPropertyValue(target, propertyName, propertyValue);
		}
		catch (MemberAccessException)
		{
			log.WarnFormat("Unable to set property {0} for {1}. Possibly older binary compilation.", propertyName, target);
		}
	}
}
