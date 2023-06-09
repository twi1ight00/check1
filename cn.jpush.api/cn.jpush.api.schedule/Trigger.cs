using System;
using cn.jpush.api.util;

namespace cn.jpush.api.schedule;

public class Trigger
{
	private const string TRIGGER = "trigger";

	private const string SINGLE = "single";

	public Periodical periodical;

	public Single single;

	public Trigger()
	{
		periodical = new Periodical();
		single = new Single();
	}

	public Trigger(Single single)
	{
		this.single = single;
		periodical = null;
		throw new NotImplementedException();
	}

	public Trigger(Periodical periodical)
	{
		this.periodical = periodical;
		single = null;
		throw new NotImplementedException();
	}

	public Trigger(string time)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsDateTime(time), "the time is not valid");
		Single single = new Single();
		single.setTime(time);
		this.single = single;
	}

	public Trigger(string start, string end, string time, string time_unit, int frequency, string[] point)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(start), "The start time must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(end), "The end time must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), "The time_unit must not be empty.");
		Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), "The frequency must be number.");
		Preconditions.checkArgument(StringUtil.IsDateTime(start), "The start time is not valid.");
		Preconditions.checkArgument(StringUtil.IsDateTime(end), "The end time is not valid.");
		Preconditions.checkArgument(StringUtil.IsTime(time), "The time must be the right format.");
		periodical = new Periodical(start, end, time, time_unit, frequency, point);
	}

	public Trigger setSingleTime(string time)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(!StringUtil.IsDateTime(time), "The time must be the right format.");
		single.setTime(time);
		return this;
	}

	public string getSingleTime()
	{
		return single.getTime();
	}

	public Trigger setTime(string time)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsTime(time), "The time must be the right format.");
		periodical.setTime(time);
		return this;
	}

	public string getTime()
	{
		return periodical.getTime();
	}

	public void setStart(string start)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(start), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsDateTime(start), "The start is not valid.");
		periodical.setStart(start);
	}

	public string getStart()
	{
		return periodical.getStart();
	}

	public Trigger setEnd(string end)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(end), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsDateTime(end), "The end is not valid.");
		periodical.setEnd(end);
		return this;
	}

	public string getEnd()
	{
		return periodical.getEnd();
	}

	public Trigger setTime_unit(string time_unit)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), "The time_unit must not be empty.");
		Preconditions.checkArgument(StringUtil.IsTimeunit(time_unit), "The time_unit must be the right format.");
		periodical.setTime_unit(time_unit);
		return this;
	}

	public string getTime_unit()
	{
		return periodical.getTime_unit();
	}

	public Trigger setFrequency(int frequency)
	{
		Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), "The frequency must be number.");
		Preconditions.checkArgument(0 < frequency && frequency < 101, "The frequency must be less than 100.");
		periodical.setFrequency(frequency);
		return this;
	}

	public int getFrequency()
	{
		return periodical.getFrequency();
	}

	public Trigger setPoint(string[] point)
	{
		periodical.setPoint(point);
		return this;
	}

	public string[] getPoint()
	{
		return periodical.getPoint();
	}
}
