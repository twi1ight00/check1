using System;
using System.Collections.Generic;
using cn.jpush.api.push.mode;
using Newtonsoft.Json;

namespace cn.jpush.api.common;

public class AudienceConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		if (!(objectType == typeof(Audience)))
		{
			return false;
		}
		return true;
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		if (value is Audience audience)
		{
			audience.Check();
			if (audience.isAll())
			{
				writer.WriteValue(audience.allAudience);
				return;
			}
			string json = JsonConvert.SerializeObject(audience.dictionary);
			writer.WriteRawValue(json);
		}
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		Audience audience = Audience.all();
		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}
		if (reader.TokenType == JsonToken.String)
		{
			audience.allAudience = reader.Value.ToString();
		}
		else if (reader.TokenType == JsonToken.StartObject)
		{
			audience.allAudience = null;
			Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
			string key = "key";
			HashSet<string> hashSet = null;
			while (reader.Read())
			{
				switch (reader.TokenType)
				{
				case JsonToken.PropertyName:
					key = reader.Value.ToString();
					break;
				case JsonToken.StartArray:
					hashSet = new HashSet<string>();
					break;
				case JsonToken.String:
					hashSet.Add(reader.Value.ToString());
					break;
				case JsonToken.EndArray:
					dictionary.Add(key, hashSet);
					break;
				case JsonToken.EndObject:
					return audience;
				}
			}
			audience.dictionary = dictionary;
		}
		return audience;
	}
}
