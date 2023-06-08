using System.Collections.Generic;
using Newtonsoft.Json;

namespace cn.jpush.api.push.notification;

public class WinphoneNotification : PlatformNotification
{
	[JsonProperty]
	private string title;

	[JsonProperty(PropertyName = "_open_page")]
	public string openPage;

	public WinphoneNotification()
	{
		title = null;
		openPage = null;
	}

	public WinphoneNotification setAlert(string alert)
	{
		base.alert = alert;
		return this;
	}

	public WinphoneNotification setOpenPage(string openPage)
	{
		this.openPage = openPage;
		return this;
	}

	public WinphoneNotification setTitle(string title)
	{
		this.title = title;
		return this;
	}

	public WinphoneNotification AddExtra(string key, string value)
	{
		if (base.extras == null)
		{
			base.extras = new Dictionary<string, object>();
		}
		if (value != null)
		{
			base.extras.Add(key, value);
		}
		return this;
	}

	public WinphoneNotification AddExtra(string key, int value)
	{
		if (base.extras == null)
		{
			base.extras = new Dictionary<string, object>();
		}
		base.extras.Add(key, value);
		return this;
	}

	public WinphoneNotification AddExtra(string key, bool value)
	{
		if (base.extras == null)
		{
			base.extras = new Dictionary<string, object>();
		}
		base.extras.Add(key, value);
		return this;
	}

	public WinphoneNotification AddExtra(string key, object value)
	{
		if (base.extras == null)
		{
			base.extras = new Dictionary<string, object>();
		}
		base.extras.Add(key, value);
		return this;
	}
}
