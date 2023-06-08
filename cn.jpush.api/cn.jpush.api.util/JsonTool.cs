using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using cn.jpush.api.report;

namespace cn.jpush.api.util;

public class JsonTool
{
	public static string ObjectToJson(object obj)
	{
		DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(obj.GetType());
		MemoryStream memoryStream = new MemoryStream();
		dataContractJsonSerializer.WriteObject((Stream)memoryStream, obj);
		byte[] array = new byte[memoryStream.Length];
		memoryStream.Position = 0L;
		memoryStream.Read(array, 0, (int)memoryStream.Length);
		return Encoding.UTF8.GetString(array).Replace("\\", "");
	}

	public static object JsonToObject(string jsonString, object obj)
	{
		DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(obj.GetType());
		MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
		return dataContractJsonSerializer.ReadObject((Stream)stream);
	}

	public static string DictionaryToJson(Dictionary<string, object> dict)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, object> item in dict)
		{
			stringBuilder.Append("\"").Append(item.Key).Append("\"")
				.Append(":")
				.Append(ValueToJson(item.Value))
				.Append(",");
		}
		if (stringBuilder.Length > 0)
		{
			stringBuilder.Remove(stringBuilder.Length - 1, 1);
		}
		stringBuilder.Append("}");
		stringBuilder.Insert(0, "{");
		return stringBuilder.ToString();
	}

	public static List<ReceivedResult.Received> JsonList(string jsonString)
	{
		return new JavaScriptSerializer().Deserialize<List<ReceivedResult.Received>>(jsonString);
	}

	private static string ValueToJson(object value)
	{
		Type type = value.GetType();
		if (type == typeof(int))
		{
			return value.ToString();
		}
		if (type == typeof(string))
		{
			return string.Concat("\"", value, "\"");
		}
		if (type == typeof(List<int>) || type == typeof(List<string>))
		{
			return ObjectToJson(value);
		}
		if (type == typeof(Dictionary<string, object>))
		{
			return DictionaryToJson((Dictionary<string, object>)value);
		}
		return "type erro";
	}
}
