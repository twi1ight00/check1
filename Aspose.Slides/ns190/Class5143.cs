using System.Drawing;
using ns171;
using ns176;
using ns187;

namespace ns190;

internal class Class5143 : Class5135
{
	private Class5718 class5718_0;

	private Interface181 interface181_1;

	private Interface182 interface182_0;

	public Class5143(Class5088 parent)
		: base(parent)
	{
	}

	public override void vmethod_2(Class5634 pList)
	{
		base.vmethod_2(pList);
		class5718_0 = pList.method_20();
		interface181_1 = pList.method_6(Enum679.const_75).vmethod_10();
		interface182_0 = pList.method_6(Enum679.const_76).vmethod_0();
		if (method_59() > 1 && method_54() == 126)
		{
			method_5().imethod_22(this, method_17(), method_1());
		}
	}

	public Class5718 method_58()
	{
		return class5718_0;
	}

	public int method_59()
	{
		return interface181_1.imethod_5();
	}

	public int method_60()
	{
		return interface182_0.imethod_5();
	}

	public override RectangleF vmethod_32(Class5728 reldims)
	{
		Interface172 context = method_49(5);
		Interface172 context2 = method_50(5);
		int num;
		int num2;
		switch ((Enum679)method_57().method_1())
		{
		case Enum679.const_208:
			num = class5718_0.interface182_3.imethod_6(context);
			num2 = class5718_0.interface182_2.imethod_6(context);
			break;
		default:
			num = class5718_0.interface182_2.imethod_6(context);
			num2 = class5718_0.interface182_3.imethod_6(context);
			break;
		case Enum679.const_227:
		case Enum679.const_292:
			num = class5718_0.interface182_0.imethod_6(context);
			num2 = class5718_0.interface182_1.imethod_6(context);
			break;
		}
		int num3 = class5718_0.class5046_0.method_10(context2).vmethod_0().imethod_6(context2);
		int num4 = class5718_0.class5046_1.method_10(context2).vmethod_0().imethod_6(context2);
		return new RectangleF(num, num3, reldims.int_0 - num - num2, reldims.int_1 - num3 - num4);
	}

	internal override string vmethod_33()
	{
		return "xsl-region-body";
	}

	public override string vmethod_21()
	{
		return "region-body";
	}

	public override int vmethod_24()
	{
		return 58;
	}
}
