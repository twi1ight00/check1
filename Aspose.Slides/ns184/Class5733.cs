using System;

namespace ns184;

internal class Class5733
{
	public static Class5733 class5733_0 = new Class5733("Other", 0);

	public static Class5733 class5733_1 = new Class5733("Type0", 1);

	public static Class5733 class5733_2 = new Class5733("Type1", 2);

	public static Class5733 class5733_3 = new Class5733("MMType1", 3);

	public static Class5733 class5733_4 = new Class5733("Type3", 4);

	public static Class5733 class5733_5 = new Class5733("TrueType", 5);

	private string string_0;

	private int int_0;

	protected Class5733(string name, int value)
	{
		string_0 = name;
		int_0 = value;
	}

	public static Class5733 smethod_0(string name)
	{
		string text = name.ToLower();
		if (text == class5733_0.method_0().ToLower())
		{
			return class5733_0;
		}
		if (text == class5733_1.method_0().ToLower())
		{
			return class5733_1;
		}
		if (text == class5733_2.method_0().ToLower())
		{
			return class5733_2;
		}
		if (text == class5733_3.method_0().ToLower())
		{
			return class5733_3;
		}
		if (text == class5733_4.method_0().ToLower())
		{
			return class5733_4;
		}
		if (!(text == class5733_5.method_0().ToLower()))
		{
			throw new ArgumentException("Invalid font type: " + name);
		}
		return class5733_5;
	}

	public static Class5733 smethod_1(int value)
	{
		if (value == class5733_0.method_1())
		{
			return class5733_0;
		}
		if (value == class5733_1.method_1())
		{
			return class5733_1;
		}
		if (value == class5733_2.method_1())
		{
			return class5733_2;
		}
		if (value == class5733_3.method_1())
		{
			return class5733_3;
		}
		if (value == class5733_4.method_1())
		{
			return class5733_4;
		}
		if (value != class5733_5.method_1())
		{
			throw new ArgumentException("Invalid font type: " + value);
		}
		return class5733_5;
	}

	public string method_0()
	{
		return string_0;
	}

	public int method_1()
	{
		return int_0;
	}
}
