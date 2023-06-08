using System;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.schedule;

public class TriggerPayload
{
	[JsonProperty]
	private Periodical periodical;

	[JsonProperty]
	private Single single;

	private JsonSerializerSettings jSetting;

	public TriggerPayload()
	{
		periodical = new Periodical();
		single = new Single();
	}

	public TriggerPayload(Single single)
	{
		this.single = single;
		periodical = null;
		throw new NotImplementedException();
	}

	public TriggerPayload(Periodical periodical)
	{
		this.periodical = periodical;
		single = null;
		throw new NotImplementedException();
	}

	public TriggerPayload(string time)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsDateTime(time), "the time is not valid");
		Single single = new Single();
		single.setTime(time);
		this.single = single;
		periodical = null;
	}

	public TriggerPayload(string start, string end, string time, string time_unit, int frequency, string[] point)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(start), "The start must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(end), "The end must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(!string.IsNullOrEmpty(time_unit), "The time_unit must not be empty.");
		Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), "The frequency must be number.");
		Preconditions.checkArgument(StringUtil.IsDateTime(start), "The start is not valid.");
		Preconditions.checkArgument(StringUtil.IsDateTime(end), "The end is not valid.");
		Preconditions.checkArgument(StringUtil.IsTime(time), "The time must be the right format.");
		Preconditions.checkArgument(0 < frequency && frequency < 101, "The frequency must be less than 100.");
		Preconditions.checkArgument(StringUtil.IsTimeunit(time_unit), "The time_unit must be the right format.");
		single = null;
		periodical = new Periodical(start, end, time, time_unit, frequency, point);
	}

	public TriggerPayload setSingleTime(string time)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(!StringUtil.IsDateTime(time), "The time must be the right format.");
		single.setTime(time);
		periodical = null;
		return this;
	}

	public string getSingleTime()
	{
		return single.getTime();
	}

	public TriggerPayload setTime(string time)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(time), "The time must not be empty.");
		Preconditions.checkArgument(StringUtil.IsTime(time), "The time must be the right format.");
		periodical.setTime(time);
		single = null;
		return this;
	}

	public string getTime()
	{
		return periodical.getTime();
	}

	public void setStart(string start)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(start), "The time could not be empty.");
		Preconditions.checkArgument(StringUtil.IsDateTime(start), "The start is not valid.");
		single = null;
		periodical.setStart(start);
	}

	public string getStart()
	{
		return periodical.getStart();
	}

	public TriggerPayload setEnd(string end)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(end), "The time could not be empty.");
		Preconditions.checkArgument(StringUtil.IsDateTime(end), "The end is not valid.");
		periodical.setEnd(end);
		single = null;
		return this;
	}

	public string getEnd()
	{
		return periodical.getEnd();
	}

	public TriggerPayload setTime_unit(string time_unit)
	{
		periodical.setTime_unit(time_unit);
		single = null;
		return this;
	}

	public string getTime_unit()
	{
		return periodical.getTime_unit();
	}

	public TriggerPayload setFrequency(int frequency)
	{
		Preconditions.checkArgument(StringUtil.IsNumber(frequency.ToString()), "The frequency must be number.");
		Preconditions.checkArgument(0 < frequency && frequency < 101, "The name must be the right format.");
		periodical.setFrequency(frequency);
		single = null;
		return this;
	}

	public int getFrequency()
	{
		return periodical.getFrequency();
	}

	public TriggerPayload setPoint(string[] point)
	{
		periodical.setPoint(point);
		single = null;
		return this;
	}

	public string[] getPoint()
	{
		return periodical.getPoint();
	}

	public string ToJson()
	{
		jSetting = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
		return JsonConvert.SerializeObject(this, jSetting);
	}
}
