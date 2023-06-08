using System.Collections;
using System.Drawing;
using ns171;
using ns173;
using ns181;
using ns187;
using ns189;
using ns196;

namespace ns198;

internal abstract class Class5302 : Class5299
{
	public Class5302(Class5109 node)
		: base(node)
	{
	}

	private Class4951 method_31()
	{
		Class5109 @class = (Class5109)class5094_0;
		Size intrinsicSize = new Size(@class.vmethod_32(), @class.vmethod_33());
		int num = @class.method_41();
		Class5407 class2 = new Class5407(@class, this, intrinsicSize);
		RectangleF cp = class2.method_6();
		Class5703 class3 = @class.method_48();
		method_26(class3);
		int num2 = class3.method_16(0, discard: false, this);
		num2 += class3.method_12(0, discard: false);
		cp.Y += num2;
		if (num != -1 && ((uint)num & (true ? 1u : 0u)) != 0)
		{
			int num3 = class3.method_16(3, discard: false, this);
			num3 += class3.method_12(3, discard: false);
			cp.X += num3;
		}
		else
		{
			int num4 = class3.method_16(2, discard: false, this);
			num4 += class3.method_12(2, discard: false);
			cp.X += num4;
		}
		Class4942 class4 = vmethod_6();
		Class5677.smethod_21(class4, @class.vmethod_31());
		method_18(class4);
		Class4951 class5 = new Class4951(class4, num);
		Class5677.smethod_20(class5, @class.imethod_1());
		Class5677.smethod_21(class5, @class.vmethod_31());
		class5.method_11(class2.method_7().Width);
		class5.method_13(class2.method_7().Height);
		class5.method_52(cp);
		class5.method_51(class2.method_9());
		class5.method_41(0);
		Class5677.smethod_3(class5, class3, discardBefore: false, discardAfter: false, discardStart: false, discardEnd: false, this);
		Class5677.smethod_7(class5, class3, discardBefore: false, discardAfter: false, discardStart: false, discardEnd: false, this);
		Class5677.smethod_11(class5, class3, this);
		return class5;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		Class4951 ia = method_31();
		method_25(ia);
		return base.imethod_14(context, alignment);
	}

	protected override Class5684 vmethod_5(Class5687 context)
	{
		Class5109 @class = (Class5109)class5094_0;
		return new Class5684(vmethod_2(context).method_15(), @class.method_50(), @class.method_51(), @class.method_52(), @class.method_53(), context.method_42());
	}

	protected abstract Class4942 vmethod_6();

	public override int imethod_0(int lengthBase, Class5094 fobj)
	{
		return lengthBase switch
		{
			12 => vmethod_2(null).vmethod_1(), 
			7 => ((Class5109)fobj).vmethod_32(), 
			8 => ((Class5109)fobj).vmethod_33(), 
			_ => base.imethod_0(lengthBase, fobj), 
		};
	}
}
