using System.Runtime.InteropServices;

namespace Quartz;

/// <summary>
/// Scheduler constants.
/// </summary>
/// <author>Marko Lahma (.NET)</author>
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct SchedulerConstants
{
	/// <summary>
	/// A (possibly) useful constant that can be used for specifying the group
	/// that <see cref="T:Quartz.IJob" /> and <see cref="T:Quartz.ITrigger" /> instances belong to.
	/// </summary>
	public const string DefaultGroup = "DEFAULT";

	/// <summary>
	/// A constant <see cref="T:Quartz.ITrigger" /> group name used internally by the
	/// scheduler - clients should not use the value of this constant
	/// ("RECOVERING_JOBS") for thename of a <see cref="T:Quartz.ITrigger" />'s group.
	/// </summary>
	public const string DefaultRecoveryGroup = "RECOVERING_JOBS";

	/// <summary>
	/// A constant <see cref="T:Quartz.ITrigger" /> group name used internally by the
	/// scheduler - clients should not use the value of this constant
	/// ("FAILED_OVER_JOBS") for thename of a <see cref="T:Quartz.ITrigger" />'s group.
	/// </summary>
	public const string DefaultFailOverGroup = "FAILED_OVER_JOBS";

	/// <summary>
	///  A constant <see cref="T:Quartz.JobDataMap" /> key that can be used to retrieve the
	/// name of the original <see cref="T:Quartz.ITrigger" /> from a recovery trigger's
	/// data map in the case of a job recovering after a failed scheduler
	/// instance.
	/// </summary>
	/// <seealso cref="P:Quartz.IJobDetail.RequestsRecovery" />
	public const string FailedJobOriginalTriggerName = "QRTZ_FAILED_JOB_ORIG_TRIGGER_NAME";

	/// <summary>
	/// A constant <see cref="T:Quartz.JobDataMap" /> key that can be used to retrieve the
	/// group of the original <see cref="T:Quartz.ITrigger" /> from a recovery trigger's
	/// data map in the case of a job recovering after a failed scheduler
	/// instance.
	/// </summary>
	/// <seealso cref="P:Quartz.IJobDetail.RequestsRecovery" />
	public const string FailedJobOriginalTriggerGroup = "QRTZ_FAILED_JOB_ORIG_TRIGGER_GROUP";

	/// <summary>
	/// A constant <see cref="T:Quartz.JobDataMap" /> key that can be used to retrieve the
	/// fire time of the original <see cref="T:Quartz.ITrigger" /> from a recovery
	/// trigger's data map in the case of a job recovering after a failed scheduler
	/// instance.
	/// </summary>
	/// <remarks>
	/// Note that this is the time the original firing actually occurred,
	/// which may be different from the scheduled fire time - as a trigger doesn't
	/// always fire exactly on time.
	/// </remarks>
	/// <seealso cref="P:Quartz.IJobDetail.RequestsRecovery" />
	public const string FailedJobOriginalTriggerFiretimeInMillisecoonds = "QRTZ_FAILED_JOB_ORIG_TRIGGER_FIRETIME_IN_MILLISECONDS_AS_STRING";
}
