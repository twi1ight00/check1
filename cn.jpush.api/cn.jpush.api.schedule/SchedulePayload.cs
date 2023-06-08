using cn.jpush.api.push.mode;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.schedule;

public class SchedulePayload
{
	private JsonSerializerSettings jSetting;

	private const string NAME = "name";

	private const string ENABLED = "enabled";

	private const string TRIGGER = "trigger";

	private const string PUSH = "push";

	public string schedule_id;

	public PushPayload push { get; set; }

	public string name { get; set; }

	[JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
	public bool enabled { get; set; }

	public TriggerPayload trigger { get; set; }

	public SchedulePayload()
	{
		name = null;
		enabled = true;
		trigger = new TriggerPayload();
		push = new PushPayload();
		schedule_id = null;
		jSetting = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
	}

	public SchedulePayload(string name, bool enabled, TriggerPayload trigger, PushPayload push)
	{
		schedule_id = null;
		this.name = name;
		this.enabled = enabled;
		this.trigger = trigger;
		this.push = push;
		jSetting = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
	}

	public SchedulePayload(Name name, Enabled enabled, TriggerPayload trigger, PushPayload push)
	{
		schedule_id = null;
		this.name = name.getName();
		this.enabled = true;
		this.trigger = trigger;
		this.push = push;
		jSetting = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
	}

	public SchedulePayload setName(string name)
	{
		Preconditions.checkArgument(StringUtil.IsValidName(name), "The name must be the right format.");
		this.name = name;
		return this;
	}

	public SchedulePayload setEnabled(bool enabled)
	{
		this.enabled = enabled;
		return this;
	}

	public SchedulePayload setTrigger(TriggerPayload trigger)
	{
		this.trigger = trigger;
		return this;
	}

	public SchedulePayload setPushPayload(PushPayload push)
	{
		this.push = push;
		return this;
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

	public SchedulePayload Check()
	{
		Preconditions.checkArgument(push != null, "pushpayload should be set.");
		Preconditions.checkArgument(name != null, "name should be set.");
		Preconditions.checkArgument(enabled, "enabled should be true.");
		Preconditions.checkArgument(trigger != null, "trigger should be set.");
		Preconditions.checkArgument(StringUtil.IsValidName(name), "The name must be the right format.");
		Preconditions.checkArgument(name.Length < 255, "The name must be less than 255 bytes.");
		return this;
	}
}
