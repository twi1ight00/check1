using System;
using ns171;

namespace ns205;

internal class Class5443 : Class5440
{
	private static string[] string_1 = new string[10] { "none", "hidden", "dotted", "dashed", "solid", "double", "groove", "ridge", "inset", "outset" };

	private static Enum679[] enum679_0 = new Enum679[10]
	{
		Enum679.const_182,
		Enum679.const_58,
		Enum679.const_37,
		Enum679.const_32,
		Enum679.const_220,
		Enum679.const_38,
		Enum679.const_56,
		Enum679.const_206,
		Enum679.const_68,
		Enum679.const_188
	};

	public static Class5443 class5443_0 = new Class5443(0);

	public static Class5443 class5443_1 = new Class5443(1);

	public static Class5443 class5443_2 = new Class5443(2);

	public static Class5443 class5443_3 = new Class5443(3);

	public static Class5443 class5443_4 = new Class5443(4);

	public static Class5443 class5443_5 = new Class5443(5);

	public static Class5443 class5443_6 = new Class5443(6);

	public static Class5443 class5443_7 = new Class5443(7);

	public static Class5443 class5443_8 = new Class5443(8);

	public static Class5443 class5443_9 = new Class5443(9);

	private static Class5443[] class5443_10 = new Class5443[10] { class5443_0, class5443_1, class5443_2, class5443_3, class5443_4, class5443_5, class5443_6, class5443_7, class5443_8, class5443_9 };

	private Class5443(int index)
		: base(string_1[index], (int)enum679_0[index])
	{
	}

	public static Class5443 smethod_0(string name)
	{
		int num = 0;
		while (true)
		{
			if (num < class5443_10.Length)
			{
				if (class5443_10[num].method_0().ToLower() == name.ToLower())
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal border style: " + name);
		}
		return class5443_10[num];
	}

	public static Class5443 smethod_1(int enumValue)
	{
		int num = 0;
		while (true)
		{
			if (num < class5443_10.Length)
			{
				if (class5443_10[num].method_1() == enumValue)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal border style: " + enumValue);
		}
		return class5443_10[num];
	}

	private object method_2()
	{
		return smethod_0(method_0());
	}

	public override string ToString()
	{
		return "BorderStyle:" + method_0();
	}
}
