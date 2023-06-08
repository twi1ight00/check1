using System;
using ns171;

namespace ns205;

internal class Class5441 : Class5440
{
	private static string[] string_1;

	private static Enum679[] enum679_0;

	public static Class5441 class5441_0;

	public static Class5441 class5441_1;

	public static Class5441 class5441_2;

	public static Class5441 class5441_3;

	public static Class5441 class5441_4;

	public static Class5441 class5441_5;

	public static Class5441 class5441_6;

	private static Class5441[] class5441_7;

	static Class5441()
	{
		string_1 = new string[7] { "none", "dotted", "dashed", "solid", "double", "groove", "ridge" };
		enum679_0 = new Enum679[7]
		{
			Enum679.const_182,
			Enum679.const_37,
			Enum679.const_32,
			Enum679.const_220,
			Enum679.const_38,
			Enum679.const_56,
			Enum679.const_206
		};
		class5441_0 = new Class5441(0);
		class5441_1 = new Class5441(1);
		class5441_2 = new Class5441(2);
		class5441_3 = new Class5441(3);
		class5441_4 = new Class5441(4);
		class5441_5 = new Class5441(5);
		class5441_6 = new Class5441(6);
		class5441_7 = new Class5441[7] { class5441_0, class5441_1, class5441_2, class5441_3, class5441_4, class5441_5, class5441_6 };
	}

	private Class5441(int index)
		: base(string_1[index], (int)enum679_0[index])
	{
	}

	public static Class5441 smethod_0(string name)
	{
		string text = name.ToLower();
		int num = 0;
		while (true)
		{
			if (num < class5441_7.Length)
			{
				if (class5441_7[num].method_0().ToLower() == text)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal rule style: " + name);
		}
		return class5441_7[num];
	}

	public static Class5441 smethod_1(int enumValue)
	{
		int num = 0;
		while (true)
		{
			if (num < class5441_7.Length)
			{
				if (class5441_7[num].method_1() == enumValue)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal rule style: " + enumValue);
		}
		return class5441_7[num];
	}

	private object method_2()
	{
		return smethod_0(method_0());
	}

	public string method_3()
	{
		return "RuleStyle:" + method_0();
	}
}
