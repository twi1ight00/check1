using System;
using System.Runtime.Serialization;
using System.Security;
using System.Text;

namespace Quartz.Impl.Calendar;

/// <summary>
/// This implementation of the Calendar excludes the set of times expressed by a
/// given CronExpression. 
/// </summary>
/// <remarks>
/// For example, you could use this calendar to exclude all but business hours (8AM - 5PM) every 
/// day using the expression "* * 0-7,18-23 ? * *". 
/// <para>
/// It is important to remember that the cron expression here describes a set of
/// times to be <i>excluded</i> from firing. Whereas the cron expression in 
/// CronTrigger describes a set of times that can
/// be <i>included</i> for firing. Thus, if a <see cref="T:Quartz.ICronTrigger" /> has a 
/// given cron expression and is associated with a <see cref="T:Quartz.Impl.Calendar.CronCalendar" /> with
/// the <i>same</i> expression, the calendar will exclude all the times the 
/// trigger includes, and they will cancel each other out.
/// </para>
/// </remarks>
/// <author>Aaron Craven</author>
/// <author>Marko Lahma (.NET)</author>
[Serializable]
public class CronCalendar : BaseCalendar
{
	private CronExpression cronExpression;

	public override TimeZoneInfo TimeZone
	{
		get
		{
			return cronExpression.TimeZone;
		}
		set
		{
			cronExpression.TimeZone = value;
		}
	}

	/// <summary>
	///  Returns the object representation of the cron expression that defines the
	/// dates and times this calendar excludes.
	/// </summary>
	public CronExpression CronExpression
	{
		get
		{
			return cronExpression;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentException("expression cannot be null");
			}
			cronExpression = value;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Quartz.Impl.Calendar.CronCalendar" /> class.
	/// </summary>
	/// <param name="expression">a string representation of the desired cron expression</param>
	public CronCalendar(string expression)
	{
		cronExpression = new CronExpression(expression);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.CronCalendar" /> with the given cron expression and 
	/// <see cref="T:Quartz.Impl.Calendar.BaseCalendar" />. 
	/// </summary>
	/// <param name="baseCalendar">
	/// the base calendar for this calendar instance 
	/// see BaseCalendar for more information on base
	/// calendar functionality
	/// </param>
	/// <param name="expression">a string representation of the desired cron expression</param>
	public CronCalendar(ICalendar baseCalendar, string expression)
		: base(baseCalendar)
	{
		cronExpression = new CronExpression(expression);
	}

	/// <summary>
	/// Create a <see cref="T:Quartz.Impl.Calendar.CronCalendar" /> with the given cron expression and 
	/// <see cref="T:Quartz.Impl.Calendar.BaseCalendar" />. 
	/// </summary>
	/// <param name="baseCalendar">
	/// the base calendar for this calendar instance 
	/// see BaseCalendar for more information on base
	/// calendar functionality
	/// </param>
	/// <param name="expression">a string representation of the desired cron expression</param>
	/// <param name="timeZone"></param>
	public CronCalendar(ICalendar baseCalendar, string expression, TimeZoneInfo timeZone)
		: base(baseCalendar, timeZone)
	{
		cronExpression = new CronExpression(expression);
	}

	/// <summary>
	/// Serialization constructor.
	/// </summary>
	/// <param name="info"></param>
	/// <param name="context"></param>
	protected CronCalendar(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		int version;
		try
		{
			version = info.GetInt32("version");
		}
		catch
		{
			version = 0;
		}
		switch (version)
		{
		case 0:
		case 1:
			cronExpression = (CronExpression)info.GetValue("cronExpression", typeof(CronExpression));
			break;
		default:
			throw new NotSupportedException("Unknown serialization version");
		}
	}

	[SecurityCritical]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("version", 1);
		info.AddValue("cronExpression", cronExpression);
	}

	/// <summary>
	/// Determine whether the given time  is 'included' by the
	/// Calendar.
	/// </summary>
	/// <param name="timeUtc">the time to test</param>
	/// <returns>a boolean indicating whether the specified time is 'included' by the CronCalendar</returns>
	public override bool IsTimeIncluded(DateTimeOffset timeUtc)
	{
		if (GetBaseCalendar() != null && !GetBaseCalendar().IsTimeIncluded(timeUtc))
		{
			return false;
		}
		return !cronExpression.IsSatisfiedBy(timeUtc);
	}

	/// <summary>
	/// Determine the next time that is 'included' by the
	/// Calendar after the given time. Return the original value if timeStamp is
	/// included. Return 0 if all days are excluded.
	/// </summary>
	/// <param name="timeUtc"></param>
	/// <returns></returns>
	public override DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeUtc)
	{
		DateTimeOffset nextIncludedTime = timeUtc.AddMilliseconds(1.0);
		while (!IsTimeIncluded(nextIncludedTime))
		{
			nextIncludedTime = ((!cronExpression.IsSatisfiedBy(nextIncludedTime)) ? ((GetBaseCalendar() == null || GetBaseCalendar().IsTimeIncluded(nextIncludedTime)) ? nextIncludedTime.AddMilliseconds(1.0) : GetBaseCalendar().GetNextIncludedTimeUtc(nextIncludedTime)) : cronExpression.GetNextValidTimeAfter(nextIncludedTime).Value);
		}
		return nextIncludedTime;
	}

	/// <summary>
	/// Creates a new object that is a copy of the current instance.
	/// </summary>
	/// <returns>A new object that is a copy of this instance.</returns>
	public override object Clone()
	{
		CronCalendar clone = (CronCalendar)base.Clone();
		clone.cronExpression = (CronExpression)cronExpression.Clone();
		return clone;
	}

	/// <summary>
	/// Returns a <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
	/// </summary>
	/// <returns>
	/// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
	/// </returns>
	public override string ToString()
	{
		StringBuilder buffer = new StringBuilder();
		buffer.Append("base calendar: [");
		if (GetBaseCalendar() != null)
		{
			buffer.Append(GetBaseCalendar());
		}
		else
		{
			buffer.Append("null");
		}
		buffer.Append("], excluded cron expression: '");
		buffer.Append(cronExpression);
		buffer.Append("'");
		return buffer.ToString();
	}

	/// <summary>
	/// Sets the cron expression for the calendar to a new value.
	/// </summary>
	/// <param name="expression">The expression.</param>
	public void SetCronExpressionString(string expression)
	{
		CronExpression newExp = new CronExpression(expression);
		cronExpression = newExp;
	}

	public override int GetHashCode()
	{
		int baseHash = 0;
		if (GetBaseCalendar() != null)
		{
			baseHash = GetBaseCalendar().GetHashCode();
		}
		return CronExpression.GetHashCode() + 5 * baseHash;
	}

	public bool Equals(CronCalendar obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (GetBaseCalendar() == null || GetBaseCalendar().Equals(obj.GetBaseCalendar()))
		{
			return CronExpression.Equals(obj.CronExpression);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is CronCalendar))
		{
			return false;
		}
		return Equals((CronCalendar)obj);
	}
}
