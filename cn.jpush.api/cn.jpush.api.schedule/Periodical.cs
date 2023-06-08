using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.schedule;

public class Periodical
{
	[JsonProperty]
	private string start;

	[JsonProperty]
	private string end;

	[JsonProperty]
	private string time;

	[JsonProperty]
	private string time_unit;

	[JsonProperty]
	private int frequency;

	[JsonProperty]
	private string[] point;

	public Periodical(string start, string end, string time, string time_unit, int frequency, string[] point)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(start), "The time must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(end), "The time must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), "The time_unit must not be empty.");
		Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), "The frequency must be number.");
		Preconditions.checkArgument(StringUtil.IsDateTime(start), "The start is not valid.");
		Preconditions.checkArgument(StringUtil.IsDateTime(end), "The end is not valid.");
		Preconditions.checkArgument(StringUtil.IsTime(time), "The time must be the right format.");
		this.start = start;
		this.end = end;
		this.time = time;
		this.time_unit = time_unit;
		this.frequency = frequency;
		this.point = point;
	}

	public Periodical()
	{
		start = null;
		end = null;
		time = null;
		time_unit = null;
		frequency = 0;
		point = null;
	}

	public Periodical setStart(string start)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(start), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsDateTime(start), "The start is not valid.");
		this.start = start;
		return this;
	}

	public string getStart()
	{
		return start;
	}

	public Periodical setEnd(string end)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(end), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsDateTime(end), "The end is not valid.");
		this.end = end;
		return this;
	}

	public string getEnd()
	{
		return end;
	}

	public Periodical setTime(string time)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsTime(time), "The time must be the right format.");
		this.time = time;
		return this;
	}

	public string getTime()
	{
		return time;
	}

	public Periodical setTime_unit(string time_unit)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), "The time_unit must not be empty.");
		Preconditions.checkArgument(StringUtil.IsTimeunit(time_unit), "The time_unit must be the right format.");
		this.time_unit = time_unit;
		return this;
	}

	public string getTime_unit()
	{
		return time_unit;
	}

	public Periodical setFrequency(int frequency)
	{
		Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), "The frequency must be number.");
		Preconditions.checkArgument(0 < frequency && frequency < 101, "The frequency must be less than 100.");
		this.frequency = frequency;
		return this;
	}

	public int getFrequency()
	{
		return frequency;
	}

	public Periodical setPoint(string[] point)
	{
		this.point = point;
		return this;
	}

	public string[] getPoint()
	{
		return point;
	}
}
