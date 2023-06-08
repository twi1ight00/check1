using System;
using System.Collections.Generic;

namespace ns44;

internal class Class889
{
	private static Dictionary<string, Enum165> dictionary_0;

	private static Dictionary<Enum165, string> dictionary_1;

	private static Dictionary<Enum165, string> dictionary_2;

	private static Dictionary<string, Enum165> dictionary_3;

	private static Dictionary<string, string> dictionary_4;

	private static readonly string[] string_0;

	private static readonly string[] string_1;

	public static Enum165 smethod_0(string contentType, Enum165 defaultType)
	{
		if (!dictionary_0.TryGetValue(contentType, out var value))
		{
			return defaultType;
		}
		return value;
	}

	public static string smethod_1(Enum165 presentationType)
	{
		dictionary_1.TryGetValue(presentationType, out var value);
		return value;
	}

	public static Enum165 smethod_2(string extension, Enum165 defaultType)
	{
		Enum165 result = defaultType;
		if (dictionary_3.ContainsKey(extension))
		{
			result = dictionary_3[extension];
		}
		return result;
	}

	public static string smethod_3(Enum165 presentationType)
	{
		dictionary_2.TryGetValue(presentationType, out var value);
		return value;
	}

	public static string smethod_4(string contentType, Enum165 defaultType)
	{
		if (!dictionary_4.TryGetValue(contentType, out var value))
		{
			return smethod_3(defaultType);
		}
		return value;
	}

	static Class889()
	{
		dictionary_0 = new Dictionary<string, Enum165>();
		dictionary_1 = new Dictionary<Enum165, string>();
		dictionary_2 = new Dictionary<Enum165, string>();
		dictionary_3 = new Dictionary<string, Enum165>();
		dictionary_4 = new Dictionary<string, string>();
		string_0 = new string[6] { ".pptx", ".pptm", ".ppsx", ".ppsm", ".potx", ".potm" };
		string_1 = new string[6] { "application/vnd.openxmlformats-officedocument.presentationml.presentation.main+xml", "application/vnd.ms-powerpoint.presentation.macroEnabled.main+xml", "application/vnd.openxmlformats-officedocument.presentationml.slideshow.main+xml", "application/vnd.ms-powerpoint.slideshow.macroEnabled.main+xml", "application/vnd.openxmlformats-officedocument.presentationml.template.main+xml", "application/vnd.ms-powerpoint.template.macroEnabled.main+xml" };
		List<Enum165> list = new List<Enum165>();
		foreach (Enum165 value in Enum.GetValues(typeof(Enum165)))
		{
			list.Add(value);
		}
		for (int i = 0; i < string_1.GetLength(0); i++)
		{
			dictionary_0.Add(string_1[i], list[i]);
			dictionary_1.Add(list[i], string_1[i]);
			dictionary_2.Add(list[i], string_0[i]);
			dictionary_3.Add(string_0[i], list[i]);
			dictionary_4.Add(string_1[i], string_0[i]);
		}
	}
}
