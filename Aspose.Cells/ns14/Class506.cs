using System;
using System.Runtime.CompilerServices;
using ns2;

namespace ns14;

internal class Class506 : Class487
{
	private Interface3[] interface3_0;

	private Class517[] class517_0;

	private Interface3 interface3_1;

	internal Class506(Class509 class509_1, Interface3[] interface3_2, Class517[] class517_1, Interface3 interface3_3)
		: base(class509_1, "")
	{
		interface3_0 = interface3_2;
		class517_0 = class517_1;
		interface3_1 = interface3_3;
	}

	protected override void vmethod_0(char[] char_0, int int_0, int int_1)
	{
	}

	internal double method_2(double double_0)
	{
		if (double_0 == 0.0)
		{
			return 0.0;
		}
		if (interface3_0.Length >= 2)
		{
			Interface3 @interface = ((double_0 > 0.0) ? interface3_0[0] : interface3_0[1]);
			switch (@interface.imethod_0())
			{
			case Enum136.const_2:
			case Enum136.const_4:
			case Enum136.const_5:
				return ((Class488)@interface).method_2(double_0);
			}
		}
		return double_0;
	}

	public override Class518 Format(Class515 class515_0, TypeCode typeCode_0, object object_0)
	{
		switch (typeCode_0)
		{
		case TypeCode.Double:
			return method_8(class515_0, (double)object_0);
		case TypeCode.DateTime:
			return method_7(class515_0, (DateTime)object_0);
		case TypeCode.String:
			if (Class428.smethod_0((string)object_0))
			{
				class518_0.Reset();
				class518_0.method_0(Enum136.const_1, object_0.ToString());
				return class518_0;
			}
			goto default;
		default:
		{
			Interface3 @interface = method_5(class515_0, typeCode_0, object_0);
			if (@interface != null)
			{
				if (interface3_0.Length == 3 && interface3_1 != null && @interface.imethod_0() == Enum136.const_1)
				{
					return ((Class505)@interface).Format(class515_0, typeCode_0, object_0, bool_0: true);
				}
				return @interface.Format(class515_0, typeCode_0, object_0);
			}
			return method_9();
		}
		case TypeCode.Int32:
			return method_8(class515_0, (int)object_0);
		}
	}

	internal Interface3 method_3(Class515 class515_0, double double_0)
	{
		int num = 0;
		while (true)
		{
			if (num < interface3_0.Length)
			{
				if (class517_0[num].method_0(double_0))
				{
					break;
				}
				num++;
				continue;
			}
			return interface3_1;
		}
		return interface3_0[num];
	}

	internal Interface3 method_4(Class515 class515_0, DateTime dateTime_0)
	{
		double double_ = ToDouble(dateTime_0);
		int num = 0;
		while (true)
		{
			if (num < interface3_0.Length)
			{
				if (class517_0[num].method_0(double_))
				{
					break;
				}
				num++;
				continue;
			}
			return interface3_1;
		}
		return interface3_0[num];
	}

	internal Interface3 method_5(Class515 class515_0, TypeCode typeCode_0, object object_0)
	{
		switch (typeCode_0)
		{
		case TypeCode.Double:
			return method_3(class515_0, (double)object_0);
		case TypeCode.DateTime:
			return method_4(class515_0, (DateTime)object_0);
		default:
		{
			int num2 = 0;
			while (true)
			{
				if (num2 < interface3_0.Length)
				{
					if (class517_0[num2].method_1(typeCode_0, object_0, class509_0.method_0().Date1904))
					{
						break;
					}
					num2++;
					continue;
				}
				return interface3_1;
			}
			return interface3_0[num2];
		}
		case TypeCode.Int32:
			return method_3(class515_0, (int)object_0);
		case TypeCode.Boolean:
		case TypeCode.String:
		{
			if (interface3_1 != null)
			{
				return interface3_1;
			}
			int num = 0;
			while (true)
			{
				if (num < interface3_0.Length)
				{
					if (class517_0[num].method_1(typeCode_0, object_0, class509_0.method_0().Date1904))
					{
						break;
					}
					num++;
					continue;
				}
				return interface3_1;
			}
			return interface3_0[num];
		}
		}
	}

	private Class518 method_6(Interface3 interface3_2, Class515 class515_0, TypeCode typeCode_0, object object_0)
	{
		if (interface3_2.imethod_0() == Enum136.const_1)
		{
			return ((Class505)interface3_2).Format(class515_0, typeCode_0, object_0, bool_0: true);
		}
		return interface3_2.Format(class515_0, typeCode_0, object_0);
	}

	private Class518 method_7(Class515 class515_0, DateTime dateTime_0)
	{
		double num = ToDouble(dateTime_0);
		Interface3 @interface = method_3(class515_0, num);
		if (@interface != null)
		{
			if (@interface.imethod_0() == Enum136.const_3)
			{
				return ((Class495)@interface).Format(class515_0, dateTime_0, num, bool_0: true);
			}
			return method_6(@interface, class515_0, TypeCode.Double, num);
		}
		return method_9();
	}

	private Class518 method_8(Class515 class515_0, double double_0)
	{
		int num = 0;
		while (true)
		{
			if (num < interface3_0.Length)
			{
				if (class517_0[num].method_0(double_0))
				{
					break;
				}
				num++;
				continue;
			}
			if (interface3_1 != null)
			{
				return method_6(interface3_1, class515_0, TypeCode.Double, double_0);
			}
			return method_9();
		}
		return method_6(interface3_0[num], class515_0, TypeCode.Double, (double_0 < 0.0) ? (0.0 - double_0) : double_0);
	}

	private Class518 method_9()
	{
		class518_0.Reset();
		class518_0.method_0(Enum136.const_1, "");
		return class518_0;
	}

	[SpecialName]
	public override Enum136 imethod_0()
	{
		return Enum136.const_6;
	}
}
