using System;
using ns171;
using ns176;
using ns186;

namespace ns187;

internal class Class5725 : Class5723
{
	private int[] int_4;

	private int[] int_5;

	public Class5725(Class5052 baseMaker)
		: base(baseMaker)
	{
	}

	public void method_4(int[] paddingCorrespondinG)
	{
		if (paddingCorrespondinG == null || paddingCorrespondinG.Length != 4)
		{
			throw new ArgumentException();
		}
		int_4 = paddingCorrespondinG;
	}

	public void method_5(int[] borderWidthCorrespondinG)
	{
		if (borderWidthCorrespondinG == null || borderWidthCorrespondinG.Length != 4)
		{
			throw new ArgumentException();
		}
		int_5 = borderWidthCorrespondinG;
	}

	public override Class5024 vmethod_1(Class5634 propertyList)
	{
		if (propertyList.method_0().method_2().method_43())
		{
			return method_7(propertyList);
		}
		return method_6(propertyList);
	}

	public Class5024 method_6(Class5634 propertyList)
	{
		Class5634 @class = method_3(propertyList);
		if (@class == null)
		{
			return null;
		}
		Interface181 op = method_8(int_4, propertyList).vmethod_10();
		Interface181 op2 = method_8(int_5, propertyList).vmethod_10();
		int propId = @class.method_9(int_4[0], int_4[1], int_4[2], int_4[3]);
		int propId2 = @class.method_9(int_5[0], int_5[1], int_5[2], int_5[3]);
		Class5024 class2 = propertyList.method_3(propId);
		Class5024 class3 = propertyList.method_3(propId2);
		int propId3 = @class.method_9(int_0, int_1, int_2, int_3);
		if (propertyList.method_3(propId3) == null && class2 == null && class3 == null)
		{
			Class5024 class4 = propertyList.vmethod_0(class5052_0.int_0);
			if (class4 == null)
			{
				for (Class5634 class5 = propertyList.method_2(); class5 != null; class5 = class5.method_2())
				{
					class4 = class5.vmethod_0(class5052_0.int_0);
					if (class4 != null)
					{
						break;
					}
				}
			}
			return class4;
		}
		Interface181 op3 = propertyList.method_5(propId3).vmethod_10();
		Interface181 op4 = Class5036.class5036_0;
		if (!propertyList.method_0().vmethod_30())
		{
			op4 = Class5747.smethod_0(op4, propertyList.method_4(class5052_0.int_0).vmethod_10());
		}
		op4 = Class5747.smethod_0(op4, op3);
		op4 = Class5747.smethod_0(op4, op);
		op4 = Class5747.smethod_0(op4, op2);
		return (Class5024)op4;
	}

	private static bool smethod_0(Class5634 pList)
	{
		if (pList.method_0().method_2().method_43())
		{
			Class5088 @class = pList.method_0().method_4();
			if (@class is Class5094)
			{
				return !((Class5094)@class).vmethod_30();
			}
			return true;
		}
		return true;
	}

	public Class5024 method_7(Class5634 propertyList)
	{
		Class5634 @class = method_3(propertyList);
		if (@class == null)
		{
			return null;
		}
		Interface181 op = method_8(int_4, propertyList).vmethod_10();
		Interface181 op2 = method_8(int_5, propertyList).vmethod_10();
		int propId = @class.method_9(int_0, int_1, int_2, int_3);
		bool flag = false;
		Class5634 class2 = propertyList.method_2();
		while (class2 != null && class2.vmethod_0(class5052_0.int_0) == null)
		{
			if (class2.method_3(propId) == null)
			{
				class2 = class2.method_2();
				continue;
			}
			flag = true;
			break;
		}
		if (propertyList.method_3(propId) == null)
		{
			Class5024 class3 = propertyList.vmethod_0(class5052_0.int_0);
			if (class3 == null)
			{
				if (!smethod_0(propertyList) && flag)
				{
					return Class5036.class5036_0;
				}
				return null;
			}
			return class3;
		}
		Interface181 op3 = propertyList.method_5(propId).vmethod_10();
		Interface181 op4 = Class5036.class5036_0;
		if (smethod_0(propertyList))
		{
			op4 = Class5747.smethod_0(op4, propertyList.method_4(class5052_0.int_0).vmethod_10());
		}
		op4 = Class5747.smethod_0(op4, op3);
		op4 = Class5747.smethod_0(op4, op);
		op4 = Class5747.smethod_0(op4, op2);
		return (Class5024)op4;
	}

	private Class5024 method_8(int[] corresponding, Class5634 propertyList)
	{
		Class5634 @class = method_3(propertyList);
		if (@class != null)
		{
			int propId = @class.method_9(corresponding[0], corresponding[1], corresponding[2], corresponding[3]);
			return propertyList.method_5(propId);
		}
		return null;
	}
}
