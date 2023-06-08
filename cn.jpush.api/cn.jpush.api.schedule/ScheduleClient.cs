using System;
using cn.jpush.api.common;
using cn.jpush.api.push;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.schedule;

public class ScheduleClient : BaseHttpClient
{
	private const string HOST_NAME_SSL = "https://api.jpush.cn";

	private const string PUSH_PATH = "/v3/schedules";

	private const string DELETE_PATH = "/";

	private const string PUT_PATH = "/";

	private const string GET_PATH = "?page=";

	private JsonSerializerSettings jSetting;

	private string appKey;

	private string masterSecret;

	public ScheduleClient(string appKey, string masterSecret)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(appKey), "appKey should be set");
		Preconditions.checkArgument(!string.IsNullOrEmpty(masterSecret), "masterSecret should be set");
		this.appKey = appKey;
		this.masterSecret = masterSecret;
	}

	public ScheduleResult sendSchedule(SchedulePayload schedulepayload)
	{
		Preconditions.checkArgument(schedulepayload != null, "schedulepayload should not be empty");
		schedulepayload.Check();
		string text = schedulepayload.ToJson();
		Console.WriteLine(text);
		return sendSchedule(text);
	}

	public ScheduleResult sendSchedule(string schedulepayload)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(schedulepayload), "schedulepayload should not be empty");
		Console.WriteLine(schedulepayload);
		string text = "https://api.jpush.cn";
		text += "/v3/schedules";
		ResponseWrapper responseWrapper = sendPost(text, Authorization(), schedulepayload);
		ScheduleResult obj = new ScheduleResult
		{
			ResponseResult = responseWrapper
		};
		ScheduleSuccess scheduleSuccess = JsonConvert.DeserializeObject<ScheduleSuccess>(responseWrapper.responseContent);
		obj.schedule_id = scheduleSuccess.schedule_id;
		obj.name = scheduleSuccess.name;
		return obj;
	}

	public getScheduleResult getSchedule(int pageid)
	{
		Preconditions.checkArgument(pageid > 0, "page should more than 0.");
		jSetting = new JsonSerializerSettings();
		jSetting.NullValueHandling = NullValueHandling.Ignore;
		jSetting.DefaultValueHandling = DefaultValueHandling.Ignore;
		Console.WriteLine(pageid);
		string text = "https://api.jpush.cn";
		text += "/v3/schedules";
		text += "?page=";
		text += pageid;
		ResponseWrapper responseWrapper = sendGet(text, Authorization(), pageid.ToString());
		getScheduleResult obj = new getScheduleResult
		{
			ResponseResult = responseWrapper
		};
		ScheduleListResult scheduleListResult = JsonConvert.DeserializeObject<ScheduleListResult>(responseWrapper.responseContent, jSetting);
		obj.page = scheduleListResult.page;
		obj.total_pages = scheduleListResult.total_pages;
		obj.total_count = scheduleListResult.total_count;
		obj.schedules = scheduleListResult.schedules;
		return obj;
	}

	public SchedulePayload getScheduleById(string id)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(id), "id should be set.");
		jSetting = new JsonSerializerSettings();
		jSetting.NullValueHandling = NullValueHandling.Ignore;
		jSetting.DefaultValueHandling = DefaultValueHandling.Ignore;
		string text = "https://api.jpush.cn";
		text += "/v3/schedules";
		text += "/";
		text += id;
		return JsonConvert.DeserializeObject<SchedulePayload>(sendGet(text, Authorization(), id).responseContent, jSetting);
	}

	public ScheduleResult putSchedule(SchedulePayload schedulepayload, string schedule_id)
	{
		Preconditions.checkArgument(schedulepayload != null, "schedulepayload should not be empty");
		Preconditions.checkArgument(schedule_id != null, "schedule_id should not be empty");
		if (schedulepayload.push.audience == null || schedulepayload.push.platform == null)
		{
			schedulepayload.push = null;
		}
		if (schedulepayload.trigger.getTime() == null && schedulepayload.trigger.getSingleTime() == null)
		{
			schedulepayload.trigger = null;
		}
		string text = schedulepayload.ToJson();
		Console.WriteLine(text);
		return putSchedule(text, schedule_id);
	}

	public ScheduleResult putSchedule(string schedulepayload, string schedule_id)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(schedulepayload), "schedulepayload should not be empty");
		Console.WriteLine(schedulepayload);
		string text = "https://api.jpush.cn";
		text += "/v3/schedules";
		text += "/";
		text += schedule_id;
		ResponseWrapper responseWrapper = sendPut(text, Authorization(), schedulepayload);
		ScheduleResult obj = new ScheduleResult
		{
			ResponseResult = responseWrapper
		};
		ScheduleSuccess scheduleSuccess = JsonConvert.DeserializeObject<ScheduleSuccess>(responseWrapper.responseContent);
		obj.schedule_id = scheduleSuccess.schedule_id;
		obj.name = scheduleSuccess.name;
		return obj;
	}

	public ScheduleResult deleteSchedule(string schedule_id)
	{
		Preconditions.checkArgument(schedule_id != null, "schedule_id should not be empty");
		Console.WriteLine(schedule_id);
		string text = "https://api.jpush.cn";
		text += "/v3/schedules";
		text += "/";
		text += schedule_id;
		ResponseWrapper responseWrapper = sendDelete(text, Authorization(), schedule_id);
		ScheduleResult result = new ScheduleResult
		{
			ResponseResult = responseWrapper
		};
		JsonConvert.DeserializeObject<ScheduleSuccess>(responseWrapper.responseContent);
		return result;
	}

	private string Authorization()
	{
		return Base64.getBase64Encode(appKey + ":" + masterSecret);
	}
}
