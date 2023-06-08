using System;
using System.Collections.Generic;
using System.Globalization;
using cn.jpush.api.push.mode;
using Newtonsoft.Json;

namespace cn.jpush.api.common;

public class PlatformConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		if (!(objectType == typeof(Platform)))
		{
			return false;
		}
		return true;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		if (!(value is Platform platform))
		{
			return;
		}
		platform.Check();
		if (platform.isAll())
		{
			writer.WriteValue(platform.allPlatform);
			return;
		}
		writer.WriteStartArray();
		foreach (string deviceType in platform.deviceTypes)
		{
			writer.WriteValue(deviceType);
		}
		writer.WriteEndArray();
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		Platform platform = Platform.all();
		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}
		if (reader.TokenType == JsonToken.StartArray)
		{
			platform.allPlatform = null;
			platform.deviceTypes = ReadArray(reader);
		}
		else
		{
			if (reader.TokenType != JsonToken.String)
			{
				return null;
			}
			platform.allPlatform = reader.Value.ToString();
		}
		return platform;
	}

	private HashSet<string> ReadArray(JsonReader reader)
	{
		HashSet<string> hashSet = new HashSet<string>();
		while (reader.Read())
		{
			switch (reader.TokenType)
			{
			case JsonToken.String:
				hashSet.Add(Convert.ToString(reader.Value, CultureInfo.InvariantCulture));
				break;
			case JsonToken.EndArray:
				return hashSet;
			default:
				return null;
			case JsonToken.Comment:
				break;
			}
		}
		return null;
	}
}
