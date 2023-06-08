using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace ns322;

internal class Class7422 : Class7400
{
	private Interface401 interface401_0;

	private static string string_26;

	private static string string_27;

	private static string string_28;

	private static string string_29;

	private static GroupCollection groupCollection_0;

	private static Class7435 class7435_0;

	private static Interface401 interface401_1;

	private static string string_30;

	private static Class7400 class7400_0;

	private static string string_31;

	private static string smethod_0(Match match)
	{
		switch (match.Value)
		{
		case "$'":
			return string_28;
		case "$`":
			return string_27;
		case "$&":
			return string_26;
		case "$$":
			return "$";
		default:
		{
			int num = int.Parse(match.Value.Substring(1));
			if (num != 0)
			{
				return groupCollection_0[num].Value;
			}
			return match.Value;
		}
		}
	}

	private static string smethod_1(Match match)
	{
		IList list = new ArrayList();
		if (!class7435_0.IsGlobal)
		{
			class7435_0["lastIndex"] = interface401_1.NumberClass.method_4(match.Index + 1);
		}
		list.Add(interface401_1.StringClass.method_5(match.Value));
		for (int i = 1; i < match.Groups.Count; i++)
		{
			if (match.Groups[i].Success)
			{
				list.Add(interface401_1.StringClass.method_5(match.Groups[i].Value));
			}
			else
			{
				list.Add(Class7437.class7437_0);
			}
		}
		list.Add(interface401_1.NumberClass.method_4(match.Index));
		list.Add(interface401_1.StringClass.method_5(string_30));
		Class7397[] array = new Class7397[list.Count];
		int num = 0;
		foreach (Class7397 item in list)
		{
			array[num++] = item;
		}
		interface401_1.Visitor.imethod_37(class7400_0, null, array);
		return interface401_1.Visitor.Returned.ToString();
	}

	private static string smethod_2(Match match)
	{
		if (!class7435_0.IsGlobal)
		{
			class7435_0["lastIndex"] = interface401_1.NumberClass.method_4(match.Index + 1);
		}
		string after = string_30.Substring(Math.Min(string_30.Length - 1, match.Index + match.Length));
		return smethod_3(match.Value, string_30.Substring(0, match.Index), after, string_31, match.Groups);
	}

	private static string smethod_3(string matched, string before, string after, string newString, GroupCollection groups)
	{
		if (newString.IndexOf("$") != -1)
		{
			string_26 = matched;
			string_27 = before;
			string_28 = after;
			string_29 = newString;
			groupCollection_0 = groups;
			Regex regex = new Regex("\\$\\$|\\$&|\\$`|\\$'|\\$\\d{1,2}", RegexOptions.Compiled);
			return regex.Replace(newString, smethod_0);
		}
		return newString;
	}

	public Class7397 method_4(Class7398 target, Class7397[] parameters)
	{
		Class7399 @class = interface401_0.ArrayClass.method_4();
		string text = target.ToString();
		if (parameters.Length == 0 || parameters[0] == Class7437.class7437_0)
		{
			@class["0"] = interface401_0.StringClass.method_5(text);
		}
		Class7397 class2 = parameters[0];
		int count = ((parameters.Length > 1) ? Convert.ToInt32(parameters[1].vmethod_3()) : int.MaxValue);
		string[] array = ((!(class2._Class == "RegExp")) ? text.Split(new string[1] { class2.ToString() }, count, StringSplitOptions.None) : ((Class7435)parameters[0]).Regex.Split(text, count));
		for (int i = 0; i < array.Length; i++)
		{
			@class[i.ToString()] = interface401_0.StringClass.method_5(array[i]);
		}
		return @class;
	}

	public Class7397 method_5(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			return interface401_0.StringClass.method_5(target.ToString());
		}
		Class7397 @class = parameters[0];
		Class7397 class2 = Class7437.class7437_0;
		if (parameters.Length > 1)
		{
			class2 = parameters[1];
		}
		string text = target.ToString();
		Class7400 class3 = class2 as Class7400;
		if (@class._Class == "RegExp")
		{
			int count = ((!((Class7435)parameters[0]).IsGlobal) ? 1 : int.MaxValue);
			Class7435 class4 = (Class7435)parameters[0];
			int startat = ((!class4.IsGlobal) ? Math.Max(0, (int)class4["lastIndex"].vmethod_3() - 1) : 0);
			if (class4.IsGlobal)
			{
				class4["lastIndex"] = interface401_0.NumberClass.method_4(0.0);
			}
			if (class3 != null)
			{
				class7435_0 = class4;
				interface401_1 = interface401_0;
				string_30 = text;
				class7400_0 = class3;
				string value = ((Class7435)parameters[0]).Regex.Replace(text, smethod_1, count, startat);
				return interface401_0.StringClass.method_5(value);
			}
			string_31 = parameters[1].ToString();
			class7435_0 = class4;
			interface401_1 = interface401_0;
			string_30 = text;
			string value2 = ((Class7435)parameters[0]).Regex.Replace(target.ToString(), smethod_2, count, startat);
			return interface401_0.StringClass.method_5(value2);
		}
		string text2 = @class.ToString();
		int num = text.IndexOf(text2);
		if (num != -1)
		{
			if (class3 != null)
			{
				IList list = new ArrayList();
				list.Add(interface401_0.StringClass.method_5(text2));
				list.Add(interface401_0.NumberClass.method_4(num));
				list.Add(interface401_0.StringClass.method_5(text));
				Class7397[] array = new Class7397[list.Count];
				int num2 = 0;
				foreach (Class7397 item in list)
				{
					array[num2++] = item;
				}
				interface401_0.Visitor.imethod_37(class3, null, array);
				class2 = interface401_0.Visitor.Result;
				return interface401_0.StringClass.method_5(text.Substring(0, num) + class2.ToString() + text.Substring(num + text2.Length));
			}
			string text3 = text.Substring(0, num);
			string text4 = text.Substring(num + text2.Length);
			string text5 = smethod_3(text2, text3, text4, class2.ToString(), null);
			return interface401_0.StringClass.method_5(text3 + text5 + text4);
		}
		return interface401_0.StringClass.method_5(text);
	}

	public Class7397 method_6(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.StringClass.method_5(target.ToString());
	}

	public Class7397 method_7(Class7398 target, Class7397[] parameters)
	{
		Class7435 regexp = ((parameters[0]._Class == "String") ? interface401_0.RegExpClass.method_5(parameters[0].ToString(), g: false, i: false, m: false) : ((Class7435)parameters[0]));
		Class7427 @class = (Class7427)interface401_0.RegExpClass.method_6(regexp, new Class7397[1] { target });
		Class7397[] array = new Class7397[@class.Length];
		for (int i = 0; i < @class.Length; i++)
		{
			array[i] = @class[interface401_0.NumberClass.method_4(i)];
		}
		return interface401_0.ArrayClass.method_5(array);
	}

	public Class7397 method_8(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.NumberClass.method_4(target.ToString().CompareTo(parameters[0].ToString()));
	}

	public Class7397 method_9(Class7398 target, Class7397[] parameters)
	{
		string text = target.ToString();
		int val = 0;
		int val2 = text.Length;
		if (parameters.Length > 0 && !double.IsNaN(parameters[0].vmethod_3()))
		{
			val = Convert.ToInt32(parameters[0].vmethod_3());
		}
		if (parameters.Length > 1 && parameters[1] != Class7437.class7437_0 && !double.IsNaN(parameters[1].vmethod_3()))
		{
			val2 = Convert.ToInt32(parameters[1].vmethod_3());
		}
		val = Math.Min(Math.Max(val, 0), Math.Max(0, text.Length - 1));
		val2 = Math.Min(Math.Max(val2, 0), text.Length);
		text = text.Substring(val, val2 - val);
		return interface401_0.StringClass.method_5(text);
	}

	public Class7397 method_10(Class7398 target, Class7397[] parameters)
	{
		string text = target.ToString();
		int val = 0;
		int val2 = text.Length;
		if (parameters.Length > 0 && !double.IsNaN(parameters[0].vmethod_3()))
		{
			val = Convert.ToInt32(parameters[0].vmethod_3());
		}
		if (parameters.Length > 1 && parameters[1] != Class7437.class7437_0 && !double.IsNaN(parameters[1].vmethod_3()))
		{
			val2 = Convert.ToInt32(parameters[1].vmethod_3());
		}
		val = Math.Min(Math.Max(val, 0), Math.Max(0, text.Length - 1));
		val2 = Math.Min(Math.Max(val2, 0), text.Length);
		text = text.Substring(val, val2 - val);
		return interface401_0.StringClass.method_5(text);
	}

	public Class7397 method_11(Class7398 target, Class7397[] parameters)
	{
		if (parameters[0]._Class == "String")
		{
			parameters[0] = interface401_0.RegExpClass.method_5(parameters[0].ToString(), g: false, i: false, m: false);
		}
		Match match = ((Class7435)parameters[0]).Regex.Match(target.ToString());
		if (match != null && match.Success)
		{
			return interface401_0.NumberClass.method_4(match.Index);
		}
		return interface401_0.NumberClass.method_4(-1.0);
	}

	public Class7397 method_12(Class7436 target, Class7397[] parameters)
	{
		return interface401_0.StringClass.method_5(target.ToString());
	}

	public Class7397 method_13(Class7398 target, Class7397[] parameters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(target.ToString());
		for (int i = 0; i < parameters.Length; i++)
		{
			stringBuilder.Append(parameters[i].ToString());
		}
		return interface401_0.StringClass.method_5(stringBuilder.ToString());
	}

	public Class7397 method_14(Class7398 target, Class7397[] parameters)
	{
		return method_9(target, new Class7397[2]
		{
			parameters[0],
			interface401_0.NumberClass.method_4(parameters[0].vmethod_3() + 1.0)
		});
	}

	public Class7397 method_15(Class7398 target, Class7397[] parameters)
	{
		string text = target.ToString();
		int num = (int)parameters[0].vmethod_3();
		if (!string.IsNullOrEmpty(text) && num <= text.Length - 1)
		{
			return interface401_0.NumberClass.method_4(Convert.ToInt32(text[num]));
		}
		return interface401_0.NaN;
	}

	public Class7397 method_16(Class7398 target, Class7397[] parameters)
	{
		string text = target.ToString();
		string value = parameters[0].ToString();
		int length = ((parameters.Length > 1) ? ((int)parameters[1].vmethod_3()) : text.Length);
		return interface401_0.NumberClass.method_4(text.Substring(0, length).LastIndexOf(value));
	}

	public Class7397 method_17(Class7398 target, Class7397[] parameters)
	{
		string text = target.ToString();
		string value = parameters[0].ToString();
		int num = ((parameters.Length > 1) ? ((int)parameters[1].vmethod_3()) : 0);
		if (string.IsNullOrEmpty(value))
		{
			if (parameters.Length > 1)
			{
				return interface401_0.NumberClass.method_4(Math.Min(text.Length, num));
			}
			return interface401_0.NumberClass.method_4(0.0);
		}
		if (num >= text.Length)
		{
			return interface401_0.NumberClass.method_4(-1.0);
		}
		return interface401_0.NumberClass.method_4(text.IndexOf(value, num));
	}

	public Class7397 method_18(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.StringClass.method_5(target.ToString().ToLowerInvariant());
	}

	public Class7397 method_19(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.StringClass.method_5(target.ToString().ToLower());
	}

	public Class7397 method_20(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.StringClass.method_5(target.ToString().ToUpperInvariant());
	}

	public Class7397 method_21(Class7398 target, Class7397[] parameters)
	{
		string text = target.ToString();
		return interface401_0.StringClass.method_5(text.ToUpper());
	}

	public Class7397 method_22(Class7398 target)
	{
		string text = target.ToString();
		return interface401_0.NumberClass.method_4(text.Length);
	}

	public Class7397 method_23(Class7398 target, Class7397[] parameters)
	{
		string text = target.ToString();
		int num = (int)parameters[0].vmethod_3();
		int num2 = text.Length;
		if (parameters.Length > 1)
		{
			num2 = (int)parameters[1].vmethod_3();
			if (num2 < 0)
			{
				num2 = text.Length + num2;
			}
		}
		if (num < 0)
		{
			num = text.Length + num;
		}
		return interface401_0.StringClass.method_5(text.Substring(num, num2 - num));
	}

	public Class7397 method_24(Class7398 target, Class7397[] parameters)
	{
		string text = string.Empty;
		foreach (Class7397 @class in parameters)
		{
			text += Convert.ToChar(Convert.ToUInt32(@class.vmethod_3()));
		}
		return interface401_0.StringClass.method_5(text);
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "get_length")
		{
			result = method_22(that);
		}
		else if (string_21 == "split")
		{
			result = method_4(that, parameters);
		}
		else if (string_21 == "replace")
		{
			result = method_5(that, parameters);
		}
		else if (string_21 == "toString")
		{
			result = method_6(that, parameters);
		}
		else if (string_21 == "toLocaleString")
		{
			result = method_6(that, parameters);
		}
		else if (string_21 == "match")
		{
			result = method_7(that, parameters);
		}
		else if (string_21 == "localeCompare")
		{
			result = method_8(that, parameters);
		}
		else if (string_21 == "substring")
		{
			result = method_9(that, parameters);
		}
		else if (string_21 == "substr")
		{
			result = method_10(that, parameters);
		}
		else if (string_21 == "search")
		{
			result = method_11(that, parameters);
		}
		else if (string_21 == "valueOf")
		{
			result = method_12(that as Class7436, parameters);
		}
		else if (string_21 == "concat")
		{
			result = method_13(that, parameters);
		}
		else if (string_21 == "charAt")
		{
			result = method_14(that, parameters);
		}
		else if (string_21 == "charCodeAt")
		{
			result = method_15(that, parameters);
		}
		else if (string_21 == "lastIndexOf")
		{
			result = method_16(that, parameters);
		}
		else if (string_21 == "indexOf")
		{
			result = method_17(that, parameters);
		}
		else if (string_21 == "toLowerCase")
		{
			result = method_18(that, parameters);
		}
		else if (string_21 == "toLocaleLowerCase")
		{
			result = method_19(that, parameters);
		}
		else if (string_21 == "toUpperCase")
		{
			result = method_20(that, parameters);
		}
		else if (string_21 == "toLocaleUpperCase")
		{
			result = method_21(that, parameters);
		}
		else if (string_21 == "slice")
		{
			result = method_23(that, parameters);
		}
		else
		{
			if (!(string_21 == "fromCharCode"))
			{
				throw new Exception89("unknown error function");
			}
			result = method_24(that, parameters);
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7422(Interface401 global, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
	}
}
