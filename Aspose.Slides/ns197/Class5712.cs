using ns187;
using ns192;

namespace ns197;

internal class Class5712 : Class5711
{
	public override Class5706 vmethod_0(Class5706 border1, Class5706 border2, bool discard)
	{
		Class5703.Class5704 @class = border1.method_0();
		Class5703.Class5704 class2 = border2.method_0();
		if (discard)
		{
			if (@class.method_2().vmethod_16())
			{
				if (class2.method_2().vmethod_16())
				{
					return new Class5706(Class5703.smethod_0(), 0);
				}
				return border2;
			}
			if (class2.method_2().vmethod_16())
			{
				return border1;
			}
		}
		return vmethod_1(border1, border2);
	}

	public override Class5706 vmethod_1(Class5706 border1, Class5706 border2)
	{
		Class5703.Class5704 @class = border1.method_0();
		Class5703.Class5704 class2 = border2.method_0();
		if (@class.method_0() == 57)
		{
			return border1;
		}
		if (class2.method_0() == 57)
		{
			return border2;
		}
		if (class2.method_0() == 95)
		{
			return border1;
		}
		if (@class.method_0() == 95)
		{
			return border2;
		}
		int num = @class.method_3();
		int num2 = class2.method_3();
		if (num > num2)
		{
			return border1;
		}
		if (num == num2)
		{
			int num3 = Class5711.smethod_4(@class.method_0(), class2.method_0());
			if (num3 > 0)
			{
				return border1;
			}
			if (num3 < 0)
			{
				return border2;
			}
			num3 = Class5711.smethod_6(border1.method_1(), border2.method_1());
			if (num3 > 0)
			{
				return border1;
			}
			if (num3 < 0)
			{
				return border2;
			}
			return null;
		}
		return border2;
	}
}
