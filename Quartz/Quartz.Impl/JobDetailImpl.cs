using System;
using System.Globalization;
using Quartz.Util;

namespace Quartz.Impl;

/// <summary>
/// Conveys the detail properties of a given job instance. 
/// </summary>
/// <remarks>
/// Quartz does not store an actual instance of a <see cref="T:Quartz.IJob" /> type, but
/// instead allows you to define an instance of one, through the use of a <see cref="T:Quartz.IJobDetail" />.
/// <para>
/// <see cref="T:Quartz.IJob" />s have a name and group associated with them, which
/// should uniquely identify them within a single <see cref="T:Quartz.IScheduler" />.
/// </para>
/// <para>
/// <see cref="T:Quartz.ITrigger" /> s are the 'mechanism' by which <see cref="T:Quartz.IJob" /> s
/// are scheduled. Many <see cref="T:Quartz.ITrigger" /> s can point to the same <see cref="T:Quartz.IJob" />,
/// but a single <see cref="T:Quartz.ITrigger" /> can only point to one <see cref="T:Quartz.IJob" />.
/// </para>
/// </remarks>
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.DisallowConcurrentExecutionAttribute" />
/// <seealso cref="T:Quartz.PersistJobDataAfterExecutionAttribute" />
/// <seealso cref="P:Quartz.Impl.JobDetailImpl.JobDataMap" />
/// <seealso cref="T:Quartz.ITrigger" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class JobDetailImpl : IJobDetail, ICloneable
{
	private string name;

	private string group = "DEFAULT";

	private string description;

	private Type jobType;

	private JobDataMap jobDataMap;

	private bool durability;

	private bool shouldRecover;

	[NonSerialized]
	private JobKey key;

	/// <summary>
	/// Get or sets the name of this <see cref="T:Quartz.IJob" />.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// if name is null or empty.
	/// </exception>
	public virtual string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (value == null || value.Trim().Length == 0)
			{
				throw new ArgumentException("Job name cannot be empty.");
			}
			name = value;
		}
	}

	/// <summary>
	/// Get or sets the group of this <see cref="T:Quartz.IJob" />. 
	/// If <see langword="null" />, <see cref="F:Quartz.SchedulerConstants.DefaultGroup" /> will be used.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// If the group is an empty string.
	/// </exception>
	public virtual string Group
	{
		get
		{
			return group;
		}
		set
		{
			if (value != null && value.Trim().Length == 0)
			{
				throw new ArgumentException("Group name cannot be empty.");
			}
			if (value == null)
			{
				value = "DEFAULT";
			}
			group = value;
		}
	}

	/// <summary> 
	/// Returns the 'full name' of the <see cref="T:Quartz.ITrigger" /> in the format
	/// "group.name".
	/// </summary>
	public virtual string FullName => group + "." + name;

	/// <summary>
	/// Gets the key.
	/// </summary>
	/// <value>The key.</value>
	public virtual JobKey Key
	{
		get
		{
			if (key == null)
			{
				if (Name == null)
				{
					return null;
				}
				key = new JobKey(Name, Group);
			}
			return key;
		}
		set
		{
			Name = value?.Name;
			Group = value?.Group;
			key = value;
		}
	}

	/// <summary>
	/// Get or set the description given to the <see cref="T:Quartz.IJob" /> instance by its
	/// creator (if any).
	/// </summary>
	/// <remarks>
	/// May be useful for remembering/displaying the purpose of the job, though the
	/// description has no meaning to Quartz.
	/// </remarks>
	public virtual string Description
	{
		get
		{
			return description;
		}
		set
		{
			description = value;
		}
	}

	/// <summary>
	/// Get or sets the instance of <see cref="T:Quartz.IJob" /> that will be executed.
	/// </summary>
	/// <exception cref="T:System.ArgumentException"> 
	/// if jobType is null or the class is not a <see cref="T:Quartz.IJob" />.
	/// </exception>
	public virtual Type JobType
	{
		get
		{
			return jobType;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentException("Job class cannot be null.");
			}
			if (!typeof(IJob).IsAssignableFrom(value))
			{
				throw new ArgumentException("Job class must implement the Job interface.");
			}
			jobType = value;
		}
	}

	/// <summary>
	/// Get or set the <see cref="P:Quartz.Impl.JobDetailImpl.JobDataMap" /> that is associated with the <see cref="T:Quartz.IJob" />.
	/// </summary>
	public virtual JobDataMap JobDataMap
	{
		get
		{
			if (jobDataMap == null)
			{
				jobDataMap = new JobDataMap();
			}
			return jobDataMap;
		}
		set
		{
			jobDataMap = value;
		}
	}

	/// <summary>
	/// Set whether or not the the <see cref="T:Quartz.IScheduler" /> should re-Execute
	/// the <see cref="T:Quartz.IJob" /> if a 'recovery' or 'fail-over' situation is
	/// encountered.
	/// <para>
	/// If not explicitly set, the default value is <see langword="false" />.
	/// </para>
	/// </summary>
	/// <seealso cref="P:Quartz.IJobExecutionContext.Recovering" />
	public virtual bool RequestsRecovery
	{
		get
		{
			return shouldRecover;
		}
		set
		{
			shouldRecover = value;
		}
	}

	/// <summary>
	/// Whether or not the <see cref="T:Quartz.IJob" /> should remain stored after it is
	/// orphaned (no <see cref="T:Quartz.ITrigger" />s point to it).
	/// <para>
	/// If not explicitly set, the default value is <see langword="false" />.
	/// </para>
	/// </summary>
	/// <returns> 
	/// <see langword="true" /> if the Job should remain persisted after
	/// being orphaned.
	/// </returns>
	public virtual bool Durable
	{
		get
		{
			return durability;
		}
		set
		{
			durability = value;
		}
	}

	/// <summary>
	/// Whether the associated Job class carries the <see cref="P:Quartz.Impl.JobDetailImpl.PersistJobDataAfterExecution" /> attribute.
	/// </summary>
	public bool PersistJobDataAfterExecution => ObjectUtils.IsAttributePresent(jobType, typeof(PersistJobDataAfterExecutionAttribute));

	/// <summary>
	/// Whether the associated Job class carries the <see cref="T:Quartz.DisallowConcurrentExecutionAttribute" /> attribute.
	/// </summary>
	public bool ConcurrentExecutionDisallowed => ObjectUtils.IsAttributePresent(jobType, typeof(DisallowConcurrentExecutionAttribute));

	/// <summary>
	/// Create a <see cref="T:Quartz.IJobDetail" /> with no specified name or group, and
	/// the default settings of all the other properties.
	/// <para>
	/// Note that the <see cref="P:Quartz.Impl.JobDetailImpl.Name" />,<see cref="P:Quartz.Impl.JobDetailImpl.Group" /> and
	/// <see cref="P:Quartz.Impl.JobDetailImpl.JobType" /> properties must be set before the job can be
	/// placed into a <see cref="T:Quartz.IScheduler" />.
	/// </para>
	/// </summary>
	public JobDetailImpl()
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.IJobDetail" /> with the given name, default group, and
	/// the default settings of all the other properties.
	/// If <see langword="null" />, Scheduler.DefaultGroup will be used.
	/// </summary>
	/// <exception cref="T:System.ArgumentException">
	/// If name is null or empty, or the group is an empty string.
	/// </exception>
	public JobDetailImpl(string name, Type jobType)
		: this(name, null, jobType)
	{
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.IJobDetail" /> with the given name, and group, and
	/// the default settings of all the other properties.
	/// If <see langword="null" />, Scheduler.DefaultGroup will be used.
	/// </summary>
	/// <exception cref="T:System.ArgumentException">
	/// If name is null or empty, or the group is an empty string.
	/// </exception>
	public JobDetailImpl(string name, string group, Type jobType)
	{
		Name = name;
		Group = group;
		JobType = jobType;
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.IJobDetail" /> with the given name, and group, and
	/// the given settings of all the other properties.
	/// </summary>
	/// <param name="name">The name.</param>
	/// <param name="group">if <see langword="null" />, Scheduler.DefaultGroup will be used.</param>
	/// <param name="jobType">Type of the job.</param>
	/// <param name="isDurable">if set to <c>true</c>, job will be durable.</param>
	/// <param name="requestsRecovery">if set to <c>true</c>, job will request recovery.</param>
	/// <exception cref="T:System.ArgumentException"> 
	/// ArgumentException if name is null or empty, or the group is an empty string.
	/// </exception>
	public JobDetailImpl(string name, string group, Type jobType, bool isDurable, bool requestsRecovery)
	{
		Name = name;
		Group = group;
		JobType = jobType;
		Durable = isDurable;
		RequestsRecovery = requestsRecovery;
	}

	/// <summary> 
	/// Validates whether the properties of the <see cref="T:Quartz.IJobDetail" /> are
	/// valid for submission into a <see cref="T:Quartz.IScheduler" />.
	/// </summary>
	public virtual void Validate()
	{
		if (name == null)
		{
			throw new SchedulerException("Job's name cannot be null");
		}
		if (group == null)
		{
			throw new SchedulerException("Job's group cannot be null");
		}
		if (jobType == null)
		{
			throw new SchedulerException("Job's class cannot be null");
		}
	}

	/// <summary>
	/// Return a simple string representation of this object.
	/// </summary>
	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "JobDetail '{0}':  jobType: '{1} persistJobDataAfterExecution: {2} concurrentExectionDisallowed: {3} isDurable: {4} requestsRecovers: {5}", FullName, (JobType == null) ? null : JobType.FullName, PersistJobDataAfterExecution, ConcurrentExecutionDisallowed, Durable, RequestsRecovery);
	}

	/// <summary>
	/// Creates a new object that is a copy of the current instance.
	/// </summary>
	/// <returns>
	/// A new object that is a copy of this instance.
	/// </returns>
	public virtual object Clone()
	{
		JobDetailImpl copy;
		try
		{
			copy = (JobDetailImpl)MemberwiseClone();
			if (jobDataMap != null)
			{
				copy.jobDataMap = (JobDataMap)jobDataMap.Clone();
			}
		}
		catch (Exception)
		{
			throw new Exception("Not Cloneable.");
		}
		return copy;
	}

	/// <summary>
	/// Determines whether the specified detail is equal to this instance.
	/// </summary>
	/// <param name="detail">The detail to examine.</param>
	/// <returns>
	/// 	<c>true</c> if the specified detail is equal; otherwise, <c>false</c>.
	/// </returns>
	protected virtual bool IsEqual(JobDetailImpl detail)
	{
		if (detail != null && detail.Name == Name && detail.Group == Group)
		{
			return detail.JobType == JobType;
		}
		return false;
	}

	/// <summary>
	/// Determines whether the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />.
	/// </summary>
	/// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
	/// <returns>
	/// 	<see langword="true" /> if the specified <see cref="T:System.Object" /> is equal to the
	/// current <see cref="T:System.Object" />; otherwise, <see langword="false" />.
	/// </returns>
	public override bool Equals(object obj)
	{
		if (!(obj is JobDetailImpl jd))
		{
			return false;
		}
		return IsEqual(jd);
	}

	/// <summary>
	/// Checks equality between given job detail and this instance.
	/// </summary>
	/// <param name="detail">The detail to compare this instance with.</param>
	/// <returns></returns>
	public bool Equals(JobDetailImpl detail)
	{
		return IsEqual(detail);
	}

	/// <summary>
	/// Serves as a hash function for a particular type, suitable
	/// for use in hashing algorithms and data structures like a hash table.
	/// </summary>
	/// <returns>
	/// A hash code for the current <see cref="T:System.Object" />.
	/// </returns>
	public override int GetHashCode()
	{
		return FullName.GetHashCode();
	}

	public JobBuilder GetJobBuilder()
	{
		return JobBuilder.Create().OfType(JobType).RequestRecovery(RequestsRecovery)
			.StoreDurably(Durable)
			.UsingJobData(JobDataMap)
			.WithDescription(description)
			.WithIdentity(Key);
	}
}
