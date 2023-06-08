using System;

namespace Quartz.Spi;

/// <summary>
/// A simple class (structure) used for returning execution-time data from the
/// JobStore to the <see cref="T:Quartz.Core.QuartzSchedulerThread" />.
/// </summary>
/// <seealso cref="T:Quartz.Core.QuartzScheduler" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class TriggerFiredBundle
{
	private readonly IJobDetail job;

	private readonly IOperableTrigger trigger;

	private readonly ICalendar cal;

	private readonly bool jobIsRecovering;

	private readonly DateTimeOffset? fireTimeUtc;

	private readonly DateTimeOffset? scheduledFireTimeUtc;

	private readonly DateTimeOffset? prevFireTimeUtc;

	private readonly DateTimeOffset? nextFireTimeUtc;

	/// <summary>
	/// Gets the job detail.
	/// </summary>
	/// <value>The job detail.</value>
	public virtual IJobDetail JobDetail => job;

	/// <summary>
	/// Gets the trigger.
	/// </summary>
	/// <value>The trigger.</value>
	public virtual IOperableTrigger Trigger => trigger;

	/// <summary>
	/// Gets the calendar.
	/// </summary>
	/// <value>The calendar.</value>
	public virtual ICalendar Calendar => cal;

	/// <summary>
	/// Gets a value indicating whether this <see cref="T:Quartz.Spi.TriggerFiredBundle" /> is recovering.
	/// </summary>
	/// <value><c>true</c> if recovering; otherwise, <c>false</c>.</value>
	public virtual bool Recovering => jobIsRecovering;

	/// <returns> 
	/// Returns the UTC fire time.
	/// </returns>
	public virtual DateTimeOffset? FireTimeUtc => fireTimeUtc;

	/// <summary>
	/// Gets the next UTC fire time.
	/// </summary>
	/// <value>The next fire time.</value>
	/// <returns> Returns the nextFireTimeUtc.</returns>
	public virtual DateTimeOffset? NextFireTimeUtc => nextFireTimeUtc;

	/// <summary>
	/// Gets the previous UTC fire time.
	/// </summary>
	/// <value>The previous fire time.</value>
	/// <returns> Returns the previous fire time. </returns>
	public virtual DateTimeOffset? PrevFireTimeUtc => prevFireTimeUtc;

	/// <returns> 
	/// Returns the scheduled UTC fire time.
	/// </returns>
	public virtual DateTimeOffset? ScheduledFireTimeUtc => scheduledFireTimeUtc;

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Spi.TriggerFiredBundle" /> class.
	/// </summary>
	/// <param name="job">The job.</param>
	/// <param name="trigger">The trigger.</param>
	/// <param name="cal">The calendar.</param>
	/// <param name="jobIsRecovering">if set to <c>true</c> [job is recovering].</param>
	/// <param name="fireTimeUtc">The fire time.</param>
	/// <param name="scheduledFireTimeUtc">The scheduled fire time.</param>
	/// <param name="prevFireTimeUtc">The previous fire time.</param>
	/// <param name="nextFireTimeUtc">The next fire time.</param>
	public TriggerFiredBundle(IJobDetail job, IOperableTrigger trigger, ICalendar cal, bool jobIsRecovering, DateTimeOffset? fireTimeUtc, DateTimeOffset? scheduledFireTimeUtc, DateTimeOffset? prevFireTimeUtc, DateTimeOffset? nextFireTimeUtc)
	{
		this.job = job;
		this.trigger = trigger;
		this.cal = cal;
		this.jobIsRecovering = jobIsRecovering;
		this.fireTimeUtc = fireTimeUtc;
		this.scheduledFireTimeUtc = scheduledFireTimeUtc;
		this.prevFireTimeUtc = prevFireTimeUtc;
		this.nextFireTimeUtc = nextFireTimeUtc;
	}
}
