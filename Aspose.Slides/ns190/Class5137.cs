using System.Drawing;
using ns171;
using ns176;
using ns205;

namespace ns190;

internal abstract class Class5137 : Class5136
{
	private int int_3;

	protected Class5137(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		int_3 = pList.method_6(Enum679.const_281).imethod_0();
	}

	public int method_59()
	{
		return int_3;
	}

	protected void method_60(RectangleF vpRefRect, Class5445 wm, Interface172 siblingContext)
	{
		int num = 0;
		Class5142 @class = (Class5142)method_51(61);
		if (@class != null)
		{
			num = @class.method_58().imethod_6(siblingContext);
			float width = vpRefRect.Width;
			vpRefRect.X += num;
			vpRefRect.Width = width;
		}
		Class5141 class2 = (Class5141)method_51(59);
		if (class2 != null)
		{
			num += class2.method_58().imethod_6(siblingContext);
		}
		if (num > 0)
		{
			if (wm != Class5445.class5445_0 && wm != Class5445.class5445_1)
			{
				vpRefRect.Height -= num;
			}
			else
			{
				vpRefRect.Width -= num;
			}
		}
	}
}
