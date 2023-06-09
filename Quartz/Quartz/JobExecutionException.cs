using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Quartz;

/// <summary>
/// An exception that can be thrown by a <see cref="T:Quartz.IJob" />
/// to indicate to the Quartz <see cref="T:Quartz.IScheduler" /> that an error
/// occurred while executing, and whether or not the <see cref="T:Quartz.IJob" /> requests
/// to be re-fired immediately (using the same <see cref="T:Quartz.IJobExecutionContext" />,
/// or whether it wants to be unscheduled.
/// </summary>
/// <remarks>
/// Note that if the flag for 'refire immediately' is set, the flags for
/// unscheduling the Job are ignored.
/// </remarks>
/// <seealso cref="T:Quartz.IJob" />
/// <seealso cref="T:Quartz.IJobExecutionContext" />
/// <seealso cref="T:Quartz.SchedulerException" />
/// <author>James House</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class JobExecutionException : SchedulerException
{
	private bool refire;

	private bool unscheduleTrigg;

	private bool unscheduleAllTriggs;

	/// <summary>
	/// Gets or sets a value indicating whether to unschedule firing trigger.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if firing trigger should be unscheduled; otherwise, <c>false</c>.
	/// </value>
	public virtual bool UnscheduleFiringTrigger
	{
		get
		{
			return unscheduleTrigg;
		}
		set
		{
			unscheduleTrigg = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to unschedule all triggers.
	/// </summary>
	/// <value>
	/// 	<c>true</c> if all triggers should be unscheduled; otherwise, <c>false</c>.
	/// </value>
	public virtual bool UnscheduleAllTriggers
	{
		get
		{
			return unscheduleAllTriggs;
		}
		set
		{
			unscheduleAllTriggs = value;
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether to refire immediately.
	/// </summary>
	/// <value><c>true</c> if to refire immediately; otherwise, <c>false</c>.</value>
	public virtual bool RefireImmediately
	{
		get
		{
			return refire;
		}
		set
		{
			refire = value;
		}
	}

	/// <summary>
	/// Create a JobExcecutionException, with the 're-fire immediately' flag set
	/// to <see langword="false" />.
	/// </summary>
	public JobExecutionException()
	{
	}

	/// <summary>
	/// Create a JobExcecutionException, with the given cause.
	/// </summary>
	/// <param name="cause">The cause.</param>
	public JobExecutionException(Exception cause)
		: base(cause)
	{
	}

	/// <summary>
	/// Create a JobExcecutionException, with the given message.
	/// </summary>
	public JobExecutionException(string msg)
		: base(msg)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.JobExecutionException" /> class.
	/// </summary>
	/// <param name="msg">The message.</param>
	/// <param name="cause">The original cause.</param>
	public JobExecutionException(string msg, Exception cause)
		: base(msg, cause)
	{
	}

	/// <summary>
	/// Create a JobExcecutionException with the 're-fire immediately' flag set
	/// to the given value.
	/// </summary>
	public JobExecutionException(bool refireImmediately)
	{
		refire = refireImmediately;
	}

	/// <summary>
	/// Create a JobExcecutionException with the given underlying exception, and
	/// the 're-fire immediately' flag set to the given value.
	/// </summary>
	public JobExecutionException(Exception cause, bool refireImmediately)
		: base(cause)
	{
		refire = refireImmediately;
	}

	/// <summary>
	/// Create a JobExcecutionException with the given message, and underlying
	/// exception, and the 're-fire immediately' flag set to the given value.
	/// </summary>
	public JobExecutionException(string msg, Exception cause, bool refireImmediately)
		: base(msg, cause)
	{
		refire = refireImmediately;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.JobExecutionException" /> class.
	/// </summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
	/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
	/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
	/// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
	protected JobExecutionException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	/// <summary>
	/// Creates and returns a string representation of the current exception.
	/// </summary>
	/// <returns>
	/// A string representation of the current exception.
	/// </returns>
	/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*" /></PermissionSet>
	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "Parameters: refire = {0}, unscheduleFiringTrigger = {1}, unscheduleAllTriggers = {2} \n {3}", RefireImmediately, UnscheduleFiringTrigger, UnscheduleAllTriggers, base.ToString());
	}
}
