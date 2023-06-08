using System;
using ns171;

namespace ns205;

internal class Class5444 : Class5440
{
	private static string[] string_1 = new string[4] { "lr", "rl", "tb", "bt" };

	private static Enum679[] enum679_0 = new Enum679[4]
	{
		Enum679.const_288,
		Enum679.const_289,
		Enum679.const_290,
		Enum679.const_291
	};

	public static Class5444 class5444_0 = new Class5444(0);

	public static Class5444 class5444_1 = new Class5444(1);

	public static Class5444 class5444_2 = new Class5444(2);

	public static Class5444 class5444_3 = new Class5444(3);

	private static Class5444[] class5444_4 = new Class5444[4] { class5444_0, class5444_1, class5444_2, class5444_3 };

	private Class5444(int index)
		: base(string_1[index], (int)enum679_0[index])
	{
	}

	public bool method_2()
	{
		if (method_1() != 203)
		{
			return method_1() == 204;
		}
		return true;
	}

	public bool method_3()
	{
		if (method_1() != 201)
		{
			return method_1() == 202;
		}
		return true;
	}

	public static Class5444 smethod_0(string name)
	{
		int num = 0;
		while (true)
		{
			if (num < class5444_4.Length)
			{
				if (class5444_4[num].method_0().ToLower() == name.ToLower())
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal direction: " + name);
		}
		return class5444_4[num];
	}

	public static Class5444 smethod_1(int enumValue)
	{
		int num = 0;
		while (true)
		{
			if (num < class5444_4.Length)
			{
				if (class5444_4[num].method_1() == enumValue)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal direction: " + enumValue);
		}
		return class5444_4[num];
	}

	private object method_4()
	{
		return smethod_0(method_0());
	}

	public override string ToString()
	{
		return method_0();
	}
}
