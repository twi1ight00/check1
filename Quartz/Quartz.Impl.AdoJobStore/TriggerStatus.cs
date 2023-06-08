using System;

namespace Quartz.Impl.AdoJobStore;

/// <summary>
/// Object representing a job or trigger key.
/// </summary>
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public class TriggerStatus
{
	private readonly string status;

	private readonly DateTimeOffset? nextFireTime;

	public JobKey JobKey { get; set; }

	public TriggerKey Key { get; set; }

	public string Status => status;

	public DateTimeOffset? NextFireTimeUtc => nextFireTime;

	/// <summary>
	/// Construct a new TriggerStatus with the status name and nextFireTime.
	/// </summary>
	/// <param name="status">The trigger's status</param>
	/// <param name="nextFireTime">The next time trigger will fire</param>
	public TriggerStatus(string status, DateTimeOffset? nextFireTime)
	{
		this.status = status;
		this.nextFireTime = nextFireTime;
	}

	/// <summary>
	/// Return the string representation of the TriggerStatus.
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		return "status: " + Status + ", next Fire = " + NextFireTimeUtc;
	}
}
