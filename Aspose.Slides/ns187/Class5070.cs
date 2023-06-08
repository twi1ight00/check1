using System;
using ns171;

namespace ns187;

internal class Class5070 : Class5034.Class5068
{
	private const int int_3 = 12000;

	private const double double_0 = 1.2;

	public Class5070(int propId)
		: base(propId)
	{
	}

	public override Class5024 vmethod_8(Class5634 propertyList, string value, Class5094 fo)
	{
		Class5024 @class = base.vmethod_8(propertyList, value, fo);
		if (@class is Class5037)
		{
			Class5024 class2 = propertyList.method_8(int_0);
			@class = Class5036.smethod_2((double)class2.vmethod_0().imethod_5() * ((Class5037)@class).method_4() / 100.0);
		}
		return @class;
	}

	public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
	{
		if (p.imethod_0() != 71 && p.imethod_0() != 132)
		{
			return base.vmethod_11(p, propertyList, fo);
		}
		Class5024 @class = propertyList.method_8(int_0);
		int num = smethod_0(@class.vmethod_0().imethod_5());
		if (p.imethod_0() == 71)
		{
			return Class5036.smethod_2(Math.Round((double)num * 1.2));
		}
		return Class5036.smethod_2(Math.Round((double)num / 1.2));
	}

	private static int smethod_0(int baseFontSize)
	{
		double num = 1.2;
		int num2 = 12000;
		if (baseFontSize < 12000)
		{
			num = 5.0 / 6.0;
		}
		int num3 = (int)Math.Round((double)num2 * num);
		while ((num < 1.0 && num3 > baseFontSize) || (num > 1.0 && num3 < baseFontSize))
		{
			num2 = num3;
			num3 = (int)Math.Round((double)num2 * num);
		}
		if (Math.Abs(num2 - baseFontSize) <= Math.Abs(baseFontSize - num3))
		{
			return num2;
		}
		return num3;
	}
}
