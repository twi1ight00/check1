using System.Collections.Generic;
using cn.jpush.api.common;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.push.mode;

public class Platform
{
	private const string ALL = "all";

	private HashSet<string> _deviceTypes;

	[JsonProperty(PropertyName = "winphone")]
	public string allPlatform { get; set; }

	public HashSet<string> deviceTypes
	{
		get
		{
			return _deviceTypes;
		}
		set
		{
			if (value != null)
			{
				allPlatform = null;
			}
			_deviceTypes = value;
		}
	}

	private Platform()
	{
		allPlatform = "all";
		deviceTypes = null;
	}

	private Platform(bool all, HashSet<string> deviceTypes)
	{
		if (all)
		{
			allPlatform = "all";
		}
		this.deviceTypes = deviceTypes;
	}

	public static Platform all()
	{
		return new Platform(all: true, null).Check();
	}

	public static Platform ios()
	{
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(DeviceType.ios.ToString());
		return new Platform(all: false, hashSet).Check();
	}

	public static Platform android()
	{
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(DeviceType.android.ToString());
		return new Platform(all: false, hashSet).Check();
	}

	public static Platform winphone()
	{
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(DeviceType.winphone.ToString());
		return new Platform(all: false, hashSet).Check();
	}

	public static Platform android_ios()
	{
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(DeviceType.android.ToString());
		hashSet.Add(DeviceType.ios.ToString());
		return new Platform(all: false, hashSet).Check();
	}

	public static Platform android_winphone()
	{
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(DeviceType.android.ToString());
		hashSet.Add(DeviceType.winphone.ToString());
		return new Platform(all: false, hashSet).Check();
	}

	public static Platform ios_winphone()
	{
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(DeviceType.ios.ToString());
		hashSet.Add(DeviceType.winphone.ToString());
		return new Platform(all: false, hashSet).Check();
	}

	public bool isAll()
	{
		return allPlatform != null;
	}

	public void setAll(bool all)
	{
		if (all)
		{
			allPlatform = "all";
		}
		else
		{
			allPlatform = null;
		}
	}

	public Platform Check()
	{
		Preconditions.checkArgument(!isAll() || deviceTypes == null, "Since all is enabled, any platform should not be set.");
		Preconditions.checkArgument(isAll() || deviceTypes != null, "No any deviceType is set.");
		return this;
	}
}
