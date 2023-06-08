using System;
using System.Collections.Generic;

namespace ns21;

internal class Class256
{
	private static Dictionary<string, Enum22> dictionary_0;

	private static Dictionary<Enum22, string> dictionary_1;

	private static Dictionary<Enum22, string> dictionary_2;

	private static Dictionary<string, Enum22> dictionary_3;

	private static Dictionary<string, string> dictionary_4;

	private static readonly string[] string_0;

	private static readonly string[] string_1;

	public static Enum22 smethod_0(string contentType, Enum22 defaultType)
	{
		if (!dictionary_0.TryGetValue(contentType, out var value))
		{
			return defaultType;
		}
		return value;
	}

	public static string smethod_1(Enum22 workbookType)
	{
		dictionary_1.TryGetValue(workbookType, out var value);
		return value;
	}

	public static Enum22 smethod_2(string extension, Enum22 defaultType)
	{
		Enum22 result = defaultType;
		if (dictionary_3.ContainsKey(extension))
		{
			result = dictionary_3[extension];
		}
		return result;
	}

	public static string smethod_3(Enum22 workbookType)
	{
		dictionary_2.TryGetValue(workbookType, out var value);
		return value;
	}

	public static string smethod_4(string contentType, Enum22 defaultType)
	{
		if (!dictionary_4.TryGetValue(contentType, out var value))
		{
			return smethod_3(defaultType);
		}
		return value;
	}

	static Class256()
	{
		dictionary_0 = new Dictionary<string, Enum22>();
		dictionary_1 = new Dictionary<Enum22, string>();
		dictionary_2 = new Dictionary<Enum22, string>();
		dictionary_3 = new Dictionary<string, Enum22>();
		dictionary_4 = new Dictionary<string, string>();
		string_0 = new string[4] { ".xlsx", ".xlsm", ".xltx", ".xltm" };
		string_1 = new string[4] { "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml", "application/vnd.ms-excel.sheet.macroEnabled.main+xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.template.main+xml", "application/vnd.ms-excel.template.macroEnabled.main+xml" };
		List<Enum22> list = new List<Enum22>();
		foreach (Enum22 value in Enum.GetValues(typeof(Enum22)))
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
