using System;
using ns171;

namespace ns205;

internal class Class5445 : Class5440
{
	private static string[] string_1 = new string[4] { "lr-tb", "rl-tb", "tb-lr", "tb-rl" };

	private static Enum679[] enum679_0 = new Enum679[4]
	{
		Enum679.const_80,
		Enum679.const_208,
		Enum679.const_292,
		Enum679.const_227
	};

	public static Class5445 class5445_0 = new Class5445(0);

	public static Class5445 class5445_1 = new Class5445(1);

	public static Class5445 class5445_2 = new Class5445(2);

	public static Class5445 class5445_3 = new Class5445(3);

	private static Class5445[] class5445_4 = new Class5445[4] { class5445_0, class5445_1, class5445_2, class5445_3 };

	private Class5445(int index)
		: base(string_1[index], (int)enum679_0[index])
	{
	}

	public void method_2(Interface234 wms)
	{
		Class5444 direction;
		Class5444 direction2;
		Class5444 direction3;
		Class5444 direction4;
		Class5444 direction5;
		switch ((Enum679)method_1())
		{
		case Enum679.const_208:
			direction = Class5444.class5444_1;
			direction2 = Class5444.class5444_2;
			direction3 = Class5444.class5444_1;
			direction4 = Class5444.class5444_2;
			direction5 = Class5444.class5444_3;
			break;
		default:
			direction = Class5444.class5444_0;
			direction2 = Class5444.class5444_2;
			direction3 = Class5444.class5444_0;
			direction4 = Class5444.class5444_2;
			direction5 = Class5444.class5444_3;
			break;
		case Enum679.const_292:
			direction = Class5444.class5444_2;
			direction2 = Class5444.class5444_0;
			direction3 = Class5444.class5444_2;
			direction4 = Class5444.class5444_0;
			direction5 = Class5444.class5444_1;
			break;
		case Enum679.const_227:
			direction = Class5444.class5444_2;
			direction2 = Class5444.class5444_1;
			direction3 = Class5444.class5444_2;
			direction4 = Class5444.class5444_1;
			direction5 = Class5444.class5444_0;
			break;
		}
		wms.imethod_1(direction);
		wms.imethod_2(direction2);
		wms.imethod_8(direction3);
		wms.imethod_9(direction4);
		wms.imethod_10(direction5);
		wms.imethod_11(this);
	}

	public bool method_3()
	{
		switch ((Enum679)method_1())
		{
		case Enum679.const_80:
		case Enum679.const_208:
			return true;
		default:
			return true;
		case Enum679.const_227:
		case Enum679.const_292:
			return false;
		}
	}

	public bool method_4()
	{
		return !method_3();
	}

	public static Class5445 smethod_0(string name)
	{
		int num = 0;
		while (true)
		{
			if (num < class5445_4.Length)
			{
				if (class5445_4[num].method_0().ToLower() == name.ToLower())
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal writing mode: " + name);
		}
		return class5445_4[num];
	}

	public static Class5445 smethod_1(int enumValue)
	{
		int num = 0;
		while (true)
		{
			if (num < class5445_4.Length)
			{
				if (class5445_4[num].method_1() == enumValue)
				{
					break;
				}
				num++;
				continue;
			}
			throw new ArgumentException("Illegal writing mode: " + enumValue);
		}
		return class5445_4[num];
	}

	private object method_5()
	{
		return smethod_0(method_0());
	}

	public override string ToString()
	{
		return method_0();
	}
}
