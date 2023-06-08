using Quartz.Listener;

namespace Quartz.Core;

/// <summary>
/// ErrorLogger - Scheduler Listener Class
/// </summary>
internal class ErrorLogger : SchedulerListenerSupport
{
	public override void SchedulerError(string msg, SchedulerException cause)
	{
		base.Log.Error(msg, cause);
	}
}
