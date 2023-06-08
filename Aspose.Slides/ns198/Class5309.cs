using System.Collections;
using ns173;
using ns181;
using ns184;
using ns187;
using ns189;
using ns195;
using ns196;
using ns205;

namespace ns198;

internal class Class5309 : Class5299
{
	private Class5746 class5746_0;

	private int int_2;

	private Class5729 class5729_0;

	private Class5703 class5703_1;

	public Class5309(Class5165 node)
		: base(node)
	{
	}

	public override void imethod_3()
	{
		Class5165 @class = (Class5165)class5094_0;
		class5729_0 = Class5603.smethod_1(@class, this);
		Class5697 class2 = Class5697.smethod_2(@class.method_57());
		class5746_0 = class2.method_3();
		int_2 = @class.method_50().method_1(class5729_0);
		class5703_1 = @class.method_48();
		method_26(class5703_1);
		Class4948 class3 = method_31(@class);
		class3.method_59(class5729_0.method_1());
		method_25(class3);
	}

	private Class4948 method_31(Class5165 node)
	{
		Class4948 @class = new Class4948();
		char c = node.method_51();
		int ipD = class5729_0.method_16(c);
		int blockProgressionOffseT = 0;
		int num = node.method_41();
		if (Class5710.smethod_6(c))
		{
			if (!Class5710.smethod_2(c))
			{
				@class.method_64(c, ipD, Class5710.smethod_5(c), blockProgressionOffseT, num);
			}
		}
		else
		{
			int[] levels = ((num >= 0) ? new int[1] { num } : null);
			@class.method_63(c.ToString(), ipD, null, levels, null, blockProgressionOffseT);
		}
		Class5677.smethod_21(@class, node.vmethod_31());
		Class5677.smethod_19(@class, node.method_59());
		Class5677.smethod_20(@class, node.imethod_1());
		return @class;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		class4943_0 = vmethod_2(context);
		Class5274 @class = new Class5277();
		if (class4943_0 == null)
		{
			imethod_6(fin: true);
			return null;
		}
		Class5165 class2 = (Class5165)class5094_0;
		Class5746 ipd = Class5746.smethod_1(class4943_0.method_12());
		class4943_0.method_13(class5729_0.method_1() - class5729_0.method_3());
		Class5677.smethod_18(class4943_0, class5729_0);
		class4943_0.method_29(Class5757.int_4, class2.method_52());
		class5684_0 = new Class5684(class5729_0, class5729_0.method_6(), class2.method_53(), class2.method_54(), class2.method_55(), class2.method_56(), context.method_42());
		method_29(@class);
		class5327_0 = new Class5327(0, ipd, isHyphenated: false, class5684_0);
		if (class5746_0.method_17())
		{
			@class.Add(new Class5339(class5327_0.class5746_0.method_2(), class5327_0.class5684_0, imethod_22(new Class5258(this, 0)), auxiliary: false));
		}
		else
		{
			@class.Add(new Class5339(class5327_0.class5746_0.method_2(), class5327_0.class5684_0, imethod_22(new Class5258(this, 0)), auxiliary: false));
			@class.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, new Class5258(this, -1), auxiliary: true));
			@class.Add(new Class5344(0, 0, 0, new Class5258(this, -1), auxiliary: true));
			@class.Add(new Class5339(0, null, imethod_22(new Class5258(this, -1)), auxiliary: true));
		}
		method_30(@class);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(@class);
		imethod_6(fin: true);
		return arrayList;
	}

	public override string imethod_29(Class5254 pos)
	{
		return ((Class4948)class4943_0).vmethod_10();
	}

	public override void imethod_30(Class5254 pos, Class5685 hc)
	{
		if (hc.method_0() == 1)
		{
			class5327_0.bool_0 = true;
			bool_3 = true;
		}
		hc.method_2(1);
	}

	public override bool imethod_31(ArrayList oldList)
	{
		imethod_6(fin: false);
		return bool_3;
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		if (imethod_5())
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		method_29(arrayList);
		if (!class5746_0.method_17() && class5327_0.short_0 != 0)
		{
			arrayList.Add(new Class5339(class5327_0.class5746_0.method_2() - class5327_0.short_0 * class5746_0.method_2(), class5327_0.class5684_0, imethod_22(new Class5258(this, 0)), auxiliary: false));
			arrayList.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, new Class5258(this, -1), auxiliary: true));
			arrayList.Add(new Class5344(class5746_0.method_15(class5327_0.short_0), new Class5258(this, -1), auxiliary: true));
			arrayList.Add(new Class5339(0, null, imethod_22(new Class5258(this, -1)), auxiliary: true));
			if (class5327_0.bool_0)
			{
				arrayList.Add(new Class5342(int_2, Class5342.int_2, penaltyFlagged: true, new Class5258(this, -1), auxiliary: false));
			}
		}
		else
		{
			arrayList.Add(new Class5339(class5327_0.class5746_0.method_2(), class5327_0.class5684_0, imethod_22(new Class5258(this, 0)), auxiliary: false));
			if (class5327_0.bool_0)
			{
				arrayList.Add(new Class5342(int_2, Class5342.int_2, penaltyFlagged: true, new Class5258(this, -1), auxiliary: false));
			}
		}
		method_30(arrayList);
		imethod_6(fin: true);
		return arrayList;
	}
}
