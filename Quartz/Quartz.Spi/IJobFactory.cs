namespace Quartz.Spi;

/// <summary>
/// A JobFactory is responsible for producing instances of <see cref="T:Quartz.IJob" />
/// classes.
/// </summary>
/// <remarks>
/// This interface may be of use to those wishing to have their application
/// produce <see cref="T:Quartz.IJob" /> instances via some special mechanism, such as to
/// give the opertunity for dependency injection.
/// </remarks>
/// <seealso cref="P:Quartz.IScheduler.JobFactory" />
/// <seealso cref="T:Quartz.Simpl.SimpleJobFactory" />
/// <seealso cref="T:Quartz.Simpl.PropertySettingJobFactory" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
public interface IJobFactory
{
	/// <summary> 
	/// Called by the scheduler at the time of the trigger firing, in order to
	/// produce a <see cref="T:Quartz.IJob" /> instance on which to call Execute.
	/// </summary>
	/// <remarks>
	/// It should be extremely rare for this method to throw an exception -
	/// basically only the the case where there is no way at all to instantiate
	/// and prepare the Job for execution.  When the exception is thrown, the
	/// Scheduler will move all triggers associated with the Job into the
	/// <see cref="F:Quartz.TriggerState.Error" /> state, which will require human
	/// intervention (e.g. an application restart after fixing whatever 
	/// configuration problem led to the issue wih instantiating the Job. 
	/// </remarks>
	/// <param name="bundle">
	///   The TriggerFiredBundle from which the <see cref="T:Quartz.IJobDetail" />
	///   and other info relating to the trigger firing can be obtained.
	/// </param>
	/// <param name="scheduler">a handle to the scheduler that is about to execute the job</param>
	/// <throws>  SchedulerException if there is a problem instantiating the Job. </throws>
	/// <returns> the newly instantiated Job
	/// </returns>
	IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler);

	/// <summary>
	/// Allows the the job factory to destroy/cleanup the job if needed.
	/// </summary>
	void ReturnJob(IJob job);
}
