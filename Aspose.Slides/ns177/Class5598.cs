using System;

namespace ns177;

internal class Class5598
{
	public static Class5598 class5598_0 = new Class5598("INFO");

	public static Class5598 class5598_1 = new Class5598("WARN");

	public static Class5598 class5598_2 = new Class5598("ERROR");

	public static Class5598 class5598_3 = new Class5598("FATAL");

	private string string_0;

	private Class5598(string name)
	{
		string_0 = name;
	}

	public string method_0()
	{
		return string_0;
	}

	public static Class5598 smethod_0(string name)
	{
		string text = name.ToLower();
		if (text == class5598_0.method_0().ToLower())
		{
			return class5598_0;
		}
		if (text == class5598_1.method_0().ToLower())
		{
			return class5598_1;
		}
		if (text == class5598_2.method_0().ToLower())
		{
			return class5598_2;
		}
		if (!(text == class5598_3.method_0().ToLower()))
		{
			throw new ArgumentException("Illegal value for enumeration: " + name);
		}
		return class5598_3;
	}

	private object method_1()
	{
		return smethod_0(method_0());
	}

	public override string ToString()
	{
		return "EventSeverity:" + string_0;
	}
}
