using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Richfit.Garnet.Module.UEditor;

/// <summary>
/// Config 的摘要说明
/// </summary>
public static class Config
{
	private static bool noCache = true;

	private static JObject _Items;

	public static JObject Items
	{
		get
		{
			if (noCache || _Items == null)
			{
				_Items = BuildItems();
			}
			return _Items;
		}
	}

	private static JObject BuildItems()
	{
		StringBuilder sb = new StringBuilder();
		string json = File.ReadAllText(HttpContext.Current.Server.MapPath("/config.json"));
		while (json.IndexOf("/*") >= 0)
		{
			sb.Append(json.Substring(0, json.IndexOf("/*")));
			int i;
			json = json.Substring(i = json.IndexOf("*/") + 2, json.Length - i);
		}
		sb.Append(json);
		return JObject.Parse(sb.ToString());
	}

	public static T GetValue<T>(string key)
	{
		return Items[key].Value<T>();
	}

	public static string[] GetStringList(string key)
	{
		return Items[key].Select((JToken x) => x.Value<string>()).ToArray();
	}

	public static string GetString(string key)
	{
		return GetValue<string>(key);
	}

	public static int GetInt(string key)
	{
		return GetValue<int>(key);
	}
}
