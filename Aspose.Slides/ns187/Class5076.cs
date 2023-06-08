using System;
using ns171;

namespace ns187;

internal class Class5076 : Class5042.Class5075
{
	private Class5024[] class5024_1;

	public Class5076(int propId)
		: base(propId)
	{
	}

	public override Class5024 vmethod_11(Class5024 p, Class5634 propertyList, Class5094 fo)
	{
		if (p.imethod_0() == 85)
		{
			return method_19(propertyList.method_8(method_0()), -1);
		}
		if (p.imethod_0() == 160)
		{
			return method_19(propertyList.method_8(method_0()), 1);
		}
		return base.vmethod_11(p, propertyList, fo);
	}

	private Class5024 method_19(Class5024 baseProperty, int direction)
	{
		if (class5024_1 == null)
		{
			class5024_1 = new Class5024[9]
			{
				vmethod_10("ultra-condensed"),
				vmethod_10("extra-condensed"),
				vmethod_10("condensed"),
				vmethod_10("semi-condensed"),
				vmethod_10("normal"),
				vmethod_10("semi-expanded"),
				vmethod_10("expanded"),
				vmethod_10("extra-expanded"),
				vmethod_10("ultra-expanded")
			};
		}
		int num = baseProperty.imethod_0();
		int num2 = 0;
		while (true)
		{
			if (num2 < class5024_1.Length)
			{
				if (num == class5024_1[num2].imethod_0())
				{
					break;
				}
				num2++;
				continue;
			}
			return class5024_1[4];
		}
		num2 = Math.Min(Math.Max(0, num2 + direction), class5024_1.Length - 1);
		return class5024_1[num2];
	}
}
