using System.Collections;
using ns171;
using ns173;
using ns181;
using ns184;
using ns189;
using ns196;
using ns205;

namespace ns198;

internal class Class5310 : Class5299
{
	private Class5102 class5102_0;

	private Class5729 class5729_0;

	private ArrayList arrayList_1;

	private Class5323 class5323_0;

	private int int_2;

	public Class5310(Class5102 node)
		: base(node)
	{
		class5102_0 = node;
	}

	public override void imethod_3()
	{
		Class5730 @class = class5102_0.vmethod_3().vmethod_1();
		Class5732[] array = class5102_0.method_52().method_9(@class);
		class5729_0 = @class.method_12(array[0], class5102_0.method_52().interface182_0.imethod_6(this), array[0].method_4());
		method_26(class5102_0.method_51());
	}

	public override Class4943 vmethod_2(Class5687 context)
	{
		return method_32(context);
	}

	protected override Class5746 vmethod_3(int refIPD)
	{
		return method_31(refIPD);
	}

	private Class5746 method_31(int ipd)
	{
		int num = 0;
		if (class5703_0 != null)
		{
			num = class5703_0.method_18(discard: false, this);
		}
		method_33(ipd - num);
		int opt = class5102_0.method_60().method_10(this).vmethod_0()
			.imethod_6(this) - num;
		int min = class5102_0.method_60().method_8(this).vmethod_0()
			.imethod_6(this) - num;
		int max = class5102_0.method_60().method_9(this).vmethod_0()
			.imethod_6(this) - num;
		return Class5746.smethod_0(min, opt, max);
	}

	private Class4943 method_32(Class5687 context)
	{
		Class4943 @class = null;
		int num = class5102_0.method_41();
		if (class5102_0.method_61() == 123)
		{
			if (class5102_0.method_57() != 95)
			{
				Class4953 class2 = new Class4953();
				class2.method_51(class5102_0.method_57());
				class2.method_53(class5102_0.method_58().imethod_6(this));
				@class = class2;
			}
			else
			{
				@class = new Class4954();
				if (num >= 0)
				{
					@class.method_16(num);
				}
			}
			@class.method_13(class5102_0.method_58().imethod_6(this));
			@class.method_29(Class5757.int_4, class5102_0.method_53());
			if (num >= 0)
			{
				@class.method_16(num);
			}
		}
		else if (class5102_0.method_61() == 134)
		{
			@class = new Class4954();
			@class.method_13(class5102_0.method_58().imethod_6(this));
			if (num >= 0)
			{
				@class.method_16(num);
			}
		}
		else if (class5102_0.method_61() == 35)
		{
			Class4948 class3 = new Class4948();
			char c = '.';
			int num2 = class5729_0.method_16('.');
			int[] levels = ((num < 0) ? null : new int[1] { num });
			class3.method_63(string.Empty + c, num2, null, levels, null, 0);
			class3.method_11(num2);
			class3.method_13(num2);
			class3.method_59(num2);
			Class5677.smethod_18(class3, class5729_0);
			class3.method_29(Class5757.int_4, class5102_0.method_53());
			Class4954 class4 = null;
			int num3 = class5102_0.method_62().imethod_6(this);
			if (num3 > num2)
			{
				class4 = new Class4954();
				class4.method_11(num3 - num2);
				if (num >= 0)
				{
					class4.method_16(num);
				}
				num2 = num3;
			}
			Class4946 class5 = new Class4946();
			class5.method_53(num2);
			class5.vmethod_2(class3);
			if (class4 != null)
			{
				class5.vmethod_2(class4);
			}
			class5.method_13(class3.vmethod_1());
			@class = class5;
		}
		else if (class5102_0.method_61() == 158)
		{
			if (class5102_0.vmethod_15() == null)
			{
				Interface185 @interface = Class5408.smethod_0(imethod_21().method_2().method_48());
				@interface.imethod_0(this, imethod_21().method_1());
				return null;
			}
			interface168_0 = null;
			Class4946 class6 = new Class4946();
			class5323_0 = new Class5323(class6, this);
			imethod_12(class5323_0);
			Class5315 class7 = new Class5315(class5102_0);
			class5323_0.imethod_12(class7);
			class7.imethod_3();
			Class5687 class8 = new Class5687(0);
			class8.method_41(context.method_42());
			arrayList_1 = class5323_0.imethod_14(class8, 0);
			int num4 = class5323_0.method_10();
			if (num4 != 0)
			{
				Class4954 class9 = null;
				if (class5102_0.method_62().imethod_6(this) > num4)
				{
					class9 = new Class4954();
					class9.method_11(class5102_0.method_62().imethod_6(this) - num4);
					if (num >= 0)
					{
						class9.method_16(num);
					}
					num4 = class5102_0.method_62().imethod_6(this);
				}
				class6.method_53(num4);
				if (class9 != null)
				{
					class6.vmethod_2(class9);
				}
				@class = class6;
			}
			else
			{
				@class = new Class4954();
				@class.method_13(class5102_0.method_58().imethod_6(this));
				@class.method_16(class5102_0.method_42());
			}
		}
		Class5677.smethod_21(@class, class5102_0.vmethod_31());
		return @class;
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
		if (class5102_0.method_61() != 158)
		{
			base.imethod_9(posIter, context);
			return;
		}
		vmethod_1();
		method_28(class4943_0, context);
		if (class5703_0 != null)
		{
			Class5677.smethod_0(class4943_0, class5703_0, isNotFirst: false, isNotLast: false, this);
			Class5677.smethod_11(class4943_0, class5703_0, this);
		}
		Class5653 posIter2 = new Class5653(arrayList_1, 0, arrayList_1.Count);
		class5323_0.imethod_9(posIter2, context);
		interface173_0.imethod_8(class4943_0);
		while (posIter.imethod_0())
		{
			posIter.imethod_1();
		}
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
		class5684_0 = new Class5684(class4943_0.vmethod_1(), class5102_0.method_63(), class5102_0.method_64(), class5102_0.method_65(), class5102_0.method_66(), context.method_42());
		Class5746 class2 = vmethod_3(context.method_31());
		if (class5102_0.method_61() == 158 && class4943_0 is Class4946)
		{
			int num = ((Class4946)class4943_0).method_54();
			if (class2.method_2() < num && num <= class2.method_3())
			{
				class2 = Class5746.smethod_0(class2.method_1(), num, class2.method_3());
			}
		}
		class5327_0 = new Class5327(0, class2, isHyphenated: false, context.method_42());
		class4943_0.method_38(class2.method_5(), class2.method_4(), 0);
		method_29(@class);
		@class.Add(new Class5339(0, class5684_0, new Class5258(this, -1), auxiliary: true));
		@class.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, new Class5258(this, -1), auxiliary: true));
		if (alignment != 70 && alignment != 0)
		{
			@class.Add(new Class5344(class5327_0.class5746_0.method_2(), 0, 0, new Class5258(this, 0), auxiliary: false));
		}
		else
		{
			@class.Add(new Class5344(class5327_0.class5746_0, new Class5258(this, 0), auxiliary: false));
		}
		@class.Add(new Class5339(0, class5684_0, new Class5258(this, -1), auxiliary: true));
		method_30(@class);
		imethod_6(fin: true);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(@class);
		return arrayList;
	}

	public override void imethod_30(Class5254 pos, Class5685 hc)
	{
		base.imethod_30(pos, hc);
	}

	public override bool imethod_31(ArrayList oldList)
	{
		imethod_6(fin: false);
		return false;
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		if (imethod_5())
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		method_29(arrayList);
		arrayList.Add(new Class5339(0, class5327_0.class5684_0, new Class5258(this, -1), auxiliary: true));
		arrayList.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, new Class5258(this, -1), auxiliary: true));
		if (alignment != 70 && alignment != 0)
		{
			arrayList.Add(new Class5344(class5327_0.class5746_0.method_2(), 0, 0, new Class5258(this, 0), auxiliary: false));
		}
		else
		{
			arrayList.Add(new Class5344(class5327_0.class5746_0, new Class5258(this, 0), auxiliary: false));
		}
		arrayList.Add(new Class5339(0, class5327_0.class5684_0, new Class5258(this, -1), auxiliary: true));
		method_30(arrayList);
		imethod_6(fin: true);
		return arrayList;
	}

	public override int imethod_0(int lengthBase, Class5094 fobj)
	{
		return imethod_2().imethod_0(lengthBase, imethod_2().imethod_21());
	}

	public override int imethod_16()
	{
		return int_2;
	}

	private void method_33(int contentAreaIPD)
	{
		int_2 = contentAreaIPD;
	}

	public override void imethod_23()
	{
		arrayList_0.Clear();
		base.imethod_23();
	}
}
