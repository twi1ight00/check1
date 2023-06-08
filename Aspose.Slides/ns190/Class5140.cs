using System.Drawing;
using ns171;
using ns176;
using ns205;

namespace ns190;

internal abstract class Class5140 : Class5136
{
	protected Class5140(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
	}

	protected void method_59(RectangleF vpRefRect, Class5445 wm, Interface172 siblingContext)
	{
		int num = 0;
		Class5139 @class = (Class5139)method_51(57);
		if (@class != null && @class.method_59() == 149)
		{
			num = @class.method_58().imethod_6(siblingContext);
			float height = vpRefRect.Height;
			vpRefRect.Y += num;
			vpRefRect.Height = height;
		}
		Class5138 class2 = (Class5138)method_51(56);
		if (class2 != null && class2.method_59() == 149)
		{
			num += class2.method_58().imethod_6(siblingContext);
		}
		if (num > 0)
		{
			if (wm != Class5445.class5445_0 && wm != Class5445.class5445_1)
			{
				vpRefRect.Width -= num;
			}
			else
			{
				vpRefRect.Height -= num;
			}
		}
	}
}
