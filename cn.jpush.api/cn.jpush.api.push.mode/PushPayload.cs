using System;
using System.IO;
using System.Text;
using cn.jpush.api.common;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.push.mode;

public class PushPayload
{
	private JsonSerializerSettings jSetting;

	private const string PLATFORM = "platform";

	private const string AUDIENCE = "audience";

	private const string NOTIFICATION = "notification";

	private const string MESSAGE = "message";

	private const string SMS_MESSAGE = "sms_message";

	private const string OPTIONS = "options";

	private const int MAX_IOS_ENTITY_LENGTH = 6144;

	private const int MAX_IOS_PAYLOAD_LENGTH = 2048;

	private const int MAX_ANDROID_ENTITY_LENGTH = 4096;

	[JsonConverter(typeof(PlatformConverter))]
	public Platform platform { get; set; }

	[JsonConverter(typeof(AudienceConverter))]
	public Audience audience { get; set; }

	public Notification notification { get; set; }

	public Message message { get; set; }

	public SmsMessage sms_message { get; set; }

	public Options options { get; set; }

	public PushPayload()
	{
		platform = null;
		audience = null;
		notification = null;
		message = null;
		sms_message = null;
		options = new Options();
		jSetting = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
	}

	public PushPayload(Platform platform, Audience audience, Notification notification, Message message = null, SmsMessage sms_message = null, Options options = null)
	{
		this.platform = platform;
		this.audience = audience;
		this.notification = notification;
		this.message = message;
		this.sms_message = sms_message;
		this.options = options;
		jSetting = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			DefaultValueHandling = DefaultValueHandling.Ignore
		};
	}

	public static PushPayload AlertAll(string alert)
	{
		return new PushPayload(Platform.all(), Audience.all(), new Notification().setAlert(alert), null, null, new Options());
	}

	public static PushPayload MessageAll(string msgContent)
	{
		return new PushPayload(Platform.all(), Audience.all(), null, Message.content(msgContent), null, new Options());
	}

	public static PushPayload FromJSON(string payloadString)
	{
		try
		{
			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
			jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			jsonSerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
			return JsonConvert.DeserializeObject<PushPayload>(payloadString, jsonSerializerSettings).Check();
		}
		catch (Exception ex)
		{
			Console.WriteLine("JSON to PushPayLoad occur error:" + ex.Message);
			return null;
		}
	}

	public void ResetOptionsApnsProduction(bool apnsProduction)
	{
		if (options == null)
		{
			options = new Options();
		}
		options.apns_production = apnsProduction;
	}

	public void ResetOptionsTimeToLive(long timeToLive)
	{
		if (options == null)
		{
			options = new Options();
		}
		options.time_to_live = timeToLive;
	}

	public int GetSendno()
	{
		if (options != null)
		{
			return options.sendno;
		}
		return 0;
	}

	public bool IsGlobalExceedLength()
	{
		if (IsAndroidExceedLength())
		{
			return IsiOSExceedLength();
		}
		return false;
	}

	public bool IsiOSExceedLength()
	{
		int num = 0;
		if (message != null)
		{
			string s = JsonConvert.SerializeObject(message, jSetting);
			num += Encoding.UTF8.GetBytes(s).Length;
		}
		if (notification == null)
		{
			return num > 6144;
		}
		string text = JsonConvert.SerializeObject(notification);
		if (text != null)
		{
			int num2 = 0;
			if (notification.IosNotification != null)
			{
				string text2 = JsonConvert.SerializeObject(notification.IosNotification, jSetting);
				if (text2 != null)
				{
					num2 = Encoding.UTF8.GetBytes(text2).Length;
				}
			}
			num += Encoding.UTF8.GetBytes(text).Length;
			num -= num2;
		}
		return num > 6144;
	}

	public bool IsAndroidExceedLength()
	{
		int num = 0;
		if (message != null)
		{
			string s = JsonConvert.SerializeObject(message, jSetting);
			num += Encoding.UTF8.GetBytes(s).Length;
		}
		if (notification == null)
		{
			return num > 4096;
		}
		string text = JsonConvert.SerializeObject(notification.AndroidNotification);
		if (text != null)
		{
			int num2 = 0;
			if (notification.AndroidNotification != null)
			{
				string text2 = JsonConvert.SerializeObject(notification.AndroidNotification, jSetting);
				if (text2 != null)
				{
					num2 = Encoding.UTF8.GetBytes(text2).Length;
				}
			}
			num += Encoding.UTF8.GetBytes(text).Length;
			num -= num2;
		}
		return num > 4096;
	}

	public bool IsIosExceedLength()
	{
		if (notification != null)
		{
			if (notification.IosNotification != null)
			{
				string text = JsonConvert.SerializeObject(notification.IosNotification, jSetting);
				if (text != null)
				{
					return Encoding.UTF8.GetBytes(text).Length > 2048;
				}
			}
			else if (notification.alert != null)
			{
				string s;
				using (StringWriter stringWriter = new StringWriter())
				{
					JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter);
					jsonTextWriter.WriteValue(notification.alert);
					jsonTextWriter.Flush();
					s = stringWriter.GetStringBuilder().ToString();
				}
				return Encoding.UTF8.GetBytes(s).Length > 2048;
			}
		}
		return false;
	}

	public string ToJson()
	{
		return JsonConvert.SerializeObject(this, jSetting);
	}

	public PushPayload Check()
	{
		Preconditions.checkArgument(audience != null && platform != null, "audience and platform both should be set.");
		Preconditions.checkArgument(notification != null || message != null, "notification or message should be set at least one.");
		if (audience != null)
		{
			audience.Check();
		}
		if (platform != null)
		{
			platform.Check();
		}
		if (message != null)
		{
			message.Check();
		}
		if (notification != null)
		{
			notification.Check();
		}
		return this;
	}
}
