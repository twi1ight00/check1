using System.Collections.Generic;
using Newtonsoft.Json;

namespace cn.jpush.api.push.notification;

public abstract class PlatformNotification
{
	public const string ALERT = "alert";

	private const string EXTRAS = "extras";

	[JsonProperty]
	public object alert { get; protected set; }

	[JsonProperty]
	public Dictionary<string, object> extras { get; protected set; }

	public PlatformNotification()
	{
		alert = null;
		extras = null;
	}
}
