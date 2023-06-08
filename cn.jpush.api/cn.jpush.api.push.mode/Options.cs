using System.ComponentModel;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.push.mode;

public class Options
{
	private const long NONE_TIME_TO_LIVE = -1L;

	private int _sendno;

	private long _override_msg_id;

	private long _time_to_live;

	private long _big_push_duration;

	[DefaultValue(0)]
	public int sendno
	{
		get
		{
			return _sendno;
		}
		set
		{
			Preconditions.checkArgument(value >= 0, "sendno should be greater than 0.");
			_sendno = value;
		}
	}

	[DefaultValue(0)]
	public long override_msg_id
	{
		get
		{
			return _override_msg_id;
		}
		set
		{
			Preconditions.checkArgument(value >= 0, "override_msg_id should be greater than 0.");
			_override_msg_id = value;
		}
	}

	[DefaultValue(-1L)]
	public long time_to_live
	{
		get
		{
			return _time_to_live;
		}
		set
		{
			Preconditions.checkArgument(value >= -1, "time_to_live should be greater than 0.");
			_time_to_live = value;
		}
	}

	[DefaultValue(0)]
	public long big_push_duration
	{
		get
		{
			return _big_push_duration;
		}
		set
		{
			Preconditions.checkArgument(value >= 0, "big_push_duration should be greater than 0.");
			_big_push_duration = value;
		}
	}

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
	public bool apns_production { get; set; }

	public Options()
	{
		sendno = 0;
		override_msg_id = 0L;
		time_to_live = -1L;
		big_push_duration = 0L;
		apns_production = false;
	}

	public Options(int sendno, long overrideMsgId, long timeToLive, int bigPushDuration, bool apnsProduction = false)
	{
		this.sendno = sendno;
		override_msg_id = overrideMsgId;
		time_to_live = timeToLive;
		big_push_duration = bigPushDuration;
		apns_production = apnsProduction;
	}
}
