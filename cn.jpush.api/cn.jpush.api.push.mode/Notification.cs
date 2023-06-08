using cn.jpush.api.push.notification;
using cn.jpush.api.util;
using Newtonsoft.Json;

namespace cn.jpush.api.push.mode;

public class Notification
{
	public string alert { get; set; }

	[JsonProperty(PropertyName = "ios")]
	public IosNotification IosNotification { get; set; }

	[JsonProperty(PropertyName = "android")]
	public AndroidNotification AndroidNotification { get; set; }

	[JsonProperty(PropertyName = "winphone")]
	public WinphoneNotification WinphoneNotification { get; set; }

	public Notification()
	{
		alert = null;
		IosNotification = null;
		AndroidNotification = null;
		WinphoneNotification = null;
	}

	public Notification setAlert(string alert)
	{
		this.alert = alert;
		return this;
	}

	public Notification setAndroid(AndroidNotification android)
	{
		AndroidNotification = android;
		return this;
	}

	public Notification setIos(IosNotification ios)
	{
		IosNotification = ios;
		return this;
	}

	public Notification setWinphone(WinphoneNotification winphone)
	{
		WinphoneNotification = winphone;
		return this;
	}

	public static Notification android(string alert, string title)
	{
		AndroidNotification androidNotification = new AndroidNotification().setAlert(alert).setTitle(title);
		Notification notification = new Notification().setAlert(alert);
		notification.AndroidNotification = androidNotification;
		return notification;
	}

	public static Notification ios(string alert)
	{
		IosNotification iosNotification = new IosNotification().setAlert(alert);
		Notification notification = new Notification().setAlert(alert);
		notification.IosNotification = iosNotification;
		return notification;
	}

	public static Notification ios_auto_badge()
	{
		IosNotification iosNotification = new IosNotification();
		iosNotification.autoBadge();
		Notification notification = new Notification().setAlert("");
		notification.IosNotification = iosNotification;
		return notification;
	}

	public static Notification ios_set_badge(int badge)
	{
		IosNotification iosNotification = new IosNotification();
		iosNotification.setBadge(badge);
		return new Notification
		{
			IosNotification = iosNotification
		};
	}

	public static Notification ios_incr_badge(int badge)
	{
		IosNotification iosNotification = new IosNotification();
		iosNotification.incrBadge(badge);
		return new Notification
		{
			IosNotification = iosNotification
		};
	}

	public static Notification winphone(string alert)
	{
		WinphoneNotification winphoneNotification = new WinphoneNotification().setAlert(alert);
		Notification notification = new Notification().setAlert(alert);
		notification.WinphoneNotification = winphoneNotification;
		return notification;
	}

	public Notification Check()
	{
		Preconditions.checkArgument(!isPlatformEmpty() || alert != null, "No notification payload is set.");
		if (IosNotification != null)
		{
			Preconditions.checkArgument(IosNotification.alert != null || alert != null, "No notification payload is set.");
		}
		if (AndroidNotification != null)
		{
			Preconditions.checkArgument(AndroidNotification.alert != null || alert != null, "No notification payload is set.");
		}
		if (WinphoneNotification != null)
		{
			Preconditions.checkArgument(WinphoneNotification.alert != null || alert != null, "No notification payload is set.");
		}
		return this;
	}

	private bool isPlatformEmpty()
	{
		if (IosNotification == null && AndroidNotification == null)
		{
			return WinphoneNotification == null;
		}
		return false;
	}
}
