using System.Collections.Generic;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cn.jpush.api.device;

public class DeviceClient : BaseHttpClient
{
	public const string HOST_NAME_SSL = "https://device.jpush.cn";

	public const string DEVICES_PATH = "/v3/devices";

	public const string TAGS_PATH = "/v3/tags";

	public const string ALIASES_PATH = "/v3/aliases";

	public const string STATUS_PATH = "/status/";

	private string appKey;

	private string masterSecret;

	private JsonSerializerSettings jSetting;

	public DeviceClient(string appKey, string masterSecret)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(appKey), "appKey should be set");
		Preconditions.checkArgument(!string.IsNullOrEmpty(masterSecret), "masterSecret should be set");
		this.appKey = appKey;
		this.masterSecret = masterSecret;
	}

	public TagAliasResult getDeviceTagAlias(string registrationId)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(registrationId), "registrationId should be set");
		string url = "https://device.jpush.cn/v3/devices/" + registrationId;
		string base64Encode = Base64.getBase64Encode(appKey + ":" + masterSecret);
		return TagAliasResult.fromResponse(sendGet(url, base64Encode, null));
	}

	public DefaultResult updateDevice(string registrationId, string alias, string mobile, HashSet<string> tagsToAdd, HashSet<string> tagsToRemove)
	{
		string url = "https://device.jpush.cn/v3/devices/" + registrationId;
		JObject jObject = new JObject();
		if (alias != null)
		{
			jObject.Add("alias", alias);
		}
		if (mobile != null)
		{
			jObject.Add("mobile", mobile);
		}
		JObject jObject2 = new JObject();
		if (tagsToAdd != null)
		{
			JArray jArray = JArray.FromObject(tagsToAdd);
			if (jArray.Count > 0)
			{
				jObject2.Add("add", jArray);
			}
		}
		if (tagsToRemove != null)
		{
			JArray jArray2 = JArray.FromObject(tagsToRemove);
			if (jArray2.Count > 0)
			{
				jObject2.Add("remove", jArray2);
			}
		}
		if (jObject2.Count > 0)
		{
			jObject.Add("tags", jObject2);
		}
		return DefaultResult.fromResponse(sendPost(url, Authorization(), jObject.ToString()));
	}

	public DefaultResult updateDeviceTagAlias(string registrationId, string alias, HashSet<string> tagsToAdd, HashSet<string> tagsToRemove)
	{
		string url = "https://device.jpush.cn/v3/devices/" + registrationId;
		JObject jObject = new JObject();
		if (alias != null)
		{
			jObject.Add("alias", alias);
		}
		JObject jObject2 = new JObject();
		if (tagsToAdd != null)
		{
			JArray jArray = JArray.FromObject(tagsToAdd);
			if (jArray.Count > 0)
			{
				jObject2.Add("add", jArray);
			}
		}
		if (tagsToRemove != null)
		{
			JArray jArray2 = JArray.FromObject(tagsToRemove);
			if (jArray2.Count > 0)
			{
				jObject2.Add("remove", jArray2);
			}
		}
		if (jObject2.Count > 0)
		{
			jObject.Add("tags", jObject2);
		}
		return DefaultResult.fromResponse(sendPost(url, Authorization(), jObject.ToString()));
	}

	public DefaultResult addDeviceAlias(string registrationId, string alias)
	{
		string mobile = null;
		HashSet<string> tagsToAdd = null;
		HashSet<string> tagsToRemove = null;
		return updateDevice(registrationId, alias, mobile, tagsToAdd, tagsToRemove);
	}

	public DefaultResult addDeviceMobile(string registrationId, string mobile)
	{
		string alias = null;
		HashSet<string> tagsToAdd = null;
		HashSet<string> tagsToRemove = null;
		return updateDevice(registrationId, alias, mobile, tagsToAdd, tagsToRemove);
	}

	public DefaultResult addDeviceTags(string registrationId, HashSet<string> tags)
	{
		string alias = null;
		string mobile = null;
		HashSet<string> tagsToRemove = null;
		return updateDevice(registrationId, alias, mobile, tags, tagsToRemove);
	}

	public DefaultResult removeDeviceTags(string registrationId, HashSet<string> tags)
	{
		string alias = null;
		string mobile = null;
		HashSet<string> tagsToAdd = null;
		return updateDevice(registrationId, alias, mobile, tagsToAdd, tags);
	}

	public DefaultResult updateDeviceTags(string registrationId, HashSet<string> tagsToAdd, HashSet<string> tagsToRemove)
	{
		string url = "https://device.jpush.cn/v3/devices/" + registrationId;
		JObject jObject = new JObject();
		JObject jObject2 = new JObject();
		if (tagsToAdd != null)
		{
			JArray jArray = JArray.FromObject(tagsToAdd);
			if (jArray.Count > 0)
			{
				jObject2.Add("add", jArray);
			}
		}
		if (tagsToRemove != null)
		{
			JArray jArray2 = JArray.FromObject(tagsToRemove);
			if (jArray2.Count > 0)
			{
				jObject2.Add("remove", jArray2);
			}
		}
		if (jObject2.Count > 0)
		{
			jObject.Add("tags", jObject2);
		}
		return DefaultResult.fromResponse(sendPost(url, Authorization(), jObject.ToString()));
	}

	public DefaultResult updateDeviceTagAlias(string registrationId, bool clearAlias, bool clearTag)
	{
		Preconditions.checkArgument(clearAlias || clearTag, "It is not meaningful to do nothing.");
		string url = "https://device.jpush.cn/v3/devices/" + registrationId;
		JObject jObject = new JObject();
		if (clearAlias)
		{
			jObject.Add("alias", "");
		}
		if (clearTag)
		{
			jObject.Add("tags", "");
		}
		return DefaultResult.fromResponse(sendPost(url, Authorization(), jObject.ToString()));
	}

	public TagListResult getTagList()
	{
		string url = "https://device.jpush.cn/v3/tags/";
		string base64Encode = Base64.getBase64Encode(appKey + ":" + masterSecret);
		return TagListResult.fromResponse(sendGet(url, base64Encode, null));
	}

	public BooleanResult isDeviceInTag(string tag, string registrationID)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(tag), "theTag should be set");
		Preconditions.checkArgument(!string.IsNullOrEmpty(registrationID), "registrationID should be set");
		string url = "https://device.jpush.cn/v3/tags/" + tag + "/registration_ids/" + registrationID;
		return BooleanResult.fromResponse(sendGet(url, Authorization(), null));
	}

	public DefaultResult addRemoveDevicesFromTag(string tag, HashSet<string> toAddUsers, HashSet<string> toRemoveUsers)
	{
		string url = "https://device.jpush.cn/v3/tags/" + tag;
		JObject jObject = new JObject();
		JObject jObject2 = new JObject();
		if (toAddUsers != null && toAddUsers.Count > 0)
		{
			JArray jArray = new JArray();
			foreach (string toAddUser in toAddUsers)
			{
				jArray.Add(JToken.FromObject(toAddUser));
			}
			jObject2.Add("add", jArray);
		}
		if (toRemoveUsers != null && toRemoveUsers.Count > 0)
		{
			JArray jArray2 = new JArray();
			foreach (string toRemoveUser in toRemoveUsers)
			{
				jArray2.Add(JToken.FromObject(toRemoveUser));
			}
			jObject2.Add("remove", jArray2);
		}
		jObject.Add("registration_ids", jObject2);
		return DefaultResult.fromResponse(sendPost(url, Authorization(), jObject.ToString()));
	}

	public DefaultResult addDevicesFromTag(string tag, HashSet<string> toAddUsers)
	{
		HashSet<string> toRemoveUsers = null;
		return addRemoveDevicesFromTag(tag, toAddUsers, toRemoveUsers);
	}

	public DefaultResult removeDevicesFromTag(string tag, HashSet<string> toRemoveUsers)
	{
		HashSet<string> toAddUsers = null;
		return addRemoveDevicesFromTag(tag, toAddUsers, toRemoveUsers);
	}

	public DefaultResult deleteTag(string tag, string platform)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(tag), "tag should be set");
		Preconditions.checkArgument(StringUtil.IsValidTag(tag), "tag should be the right format");
		string text = "https://device.jpush.cn/v3/tags/" + tag;
		if (platform != null)
		{
			text = text + "?platform=" + platform;
		}
		return DefaultResult.fromResponse(sendDelete(text, Authorization(), null));
	}

	public AliasDeviceListResult getAliasDeviceList(string alias, string platform)
	{
		Preconditions.checkArgument(!string.IsNullOrEmpty(alias), "alias should be set");
		Preconditions.checkArgument(StringUtil.IsValidAlias(alias), "alias should be the right format");
		string text = "https://device.jpush.cn/v3/aliases/" + alias;
		if (platform != null)
		{
			text = text + "?platform=" + platform;
		}
		return AliasDeviceListResult.fromResponse(sendGet(text, Authorization(), null));
	}

	public DefaultResult deleteAlias(string alias, string platform)
	{
		Preconditions.checkArgument(StringUtil.IsValidAlias(alias), "alias should be the right format");
		Preconditions.checkArgument(!string.IsNullOrEmpty(alias), "alias should be set");
		string text = "https://device.jpush.cn/v3/aliases/" + alias;
		if (platform != null)
		{
			text = text + "?platform=" + platform;
		}
		return DefaultResult.fromResponse(sendDelete(text, Authorization(), null));
	}

	public DefaultResult getDeviceStatus(string[] registrationId)
	{
		string url = "https://device.jpush.cn/v3/devices/status/";
		Dictionary<string, string[]> registration = new Dictionary<string, string[]> { { "registration_ids", registrationId } };
		return DefaultResult.fromResponse(sendPost(url, Authorization(), ToJson(registration)));
	}

	public string ToJson(Dictionary<string, string[]> registration)
	{
		jSetting = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
		return JsonConvert.SerializeObject(registration, jSetting);
	}

	private string Authorization()
	{
		return Base64.getBase64Encode(appKey + ":" + masterSecret);
	}
}
