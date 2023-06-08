using System.Collections;
using ns171;
using ns173;
using ns176;
using ns181;
using ns187;
using ns196;
using ns205;

namespace ns198;

internal abstract class Class5299 : Class5280, Interface172, Interface173, Interface175
{
	protected class Class5327
	{
		internal short short_0;

		internal Class5746 class5746_0;

		internal bool bool_0;

		internal Class5684 class5684_0;

		public Class5327(short letterSpaces, Class5746 ipd, bool isHyphenated, Class5684 alignmentContext)
		{
			short_0 = letterSpaces;
			class5746_0 = ipd;
			bool_0 = isHyphenated;
			class5684_0 = alignmentContext;
		}
	}

	protected Class4943 class4943_0;

	protected Class5703 class5703_0;

	protected Class5684 class5684_0;

	protected bool bool_3;

	protected Class5327 class5327_0;

	public Class5299(Class5094 node)
		: base(node)
	{
	}

	public Class5299()
	{
	}

	public virtual Class4943 vmethod_2(Class5687 context)
	{
		return class4943_0;
	}

	public bool method_24()
	{
		return false;
	}

	public void method_25(Class4943 ia)
	{
		class4943_0 = ia;
	}

	public override void imethod_8(Class4942 childArea)
	{
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		return null;
	}

	protected void method_26(Class5703 commonBorderPaddingBackground)
	{
		class5703_0 = commonBorderPaddingBackground;
	}

	protected virtual Class5746 vmethod_3(int refIPD)
	{
		return Class5746.smethod_1(class4943_0.method_12());
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
		vmethod_1();
		Class4943 @class = vmethod_4();
		if (@class.method_14() > 0 || @class.method_15() > 0)
		{
			method_27(@class, context);
			method_28(@class, context);
			if (class5703_0 != null)
			{
				Class5677.smethod_0(@class, class5703_0, isNotFirst: false, isNotLast: false, this);
				Class5677.smethod_11(@class, class5703_0, this);
			}
			interface173_0.imethod_8(@class);
		}
		while (posIter.imethod_0())
		{
			posIter.imethod_1();
		}
	}

	protected virtual Class4943 vmethod_4()
	{
		return class4943_0;
	}

	protected void method_27(Class4943 area, Class5687 context)
	{
		area.method_41(class5684_0.method_21());
	}

	protected virtual Class5684 vmethod_5(Class5687 context)
	{
		return context.method_42();
	}

	protected void method_28(Class4943 area, Class5687 context)
	{
		double num = context.method_40();
		int num2 = 0;
		if (num < 0.0)
		{
			num2 += (int)(num * (double)class5327_0.class5746_0.method_4());
		}
		else if (num > 0.0)
		{
			num2 += (int)(num * (double)class5327_0.class5746_0.method_5());
		}
		area.method_11(class5327_0.class5746_0.method_2() + num2);
		area.method_39(num2);
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		class4943_0 = vmethod_2(context);
		if (class4943_0 == null)
		{
			imethod_6(fin: true);
			return null;
		}
		class5684_0 = vmethod_5(context);
		Class5746 ipd = vmethod_3(context.method_31());
		class5327_0 = new Class5327(0, ipd, isHyphenated: false, class5684_0);
		Class5274 @class = new Class5277();
		method_29(@class);
		@class.Add(new Class5339(class5327_0.class5746_0.method_2(), class5684_0, imethod_22(new Class5258(this, 0)), auxiliary: false));
		method_30(@class);
		imethod_6(fin: true);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(@class);
		return arrayList;
	}

	public virtual ArrayList imethod_27(ArrayList oldList)
	{
		return oldList;
	}

	public virtual ArrayList imethod_28(ArrayList oldList, int depth)
	{
		return imethod_27(oldList);
	}

	public virtual string imethod_29(Class5254 pos)
	{
		return string.Empty;
	}

	public virtual void imethod_30(Class5254 pos, Class5685 hyphContext)
	{
	}

	public virtual bool imethod_31(ArrayList oldList)
	{
		imethod_6(fin: false);
		return false;
	}

	public virtual bool imethod_32(ArrayList oldList, int depth)
	{
		return imethod_31(oldList);
	}

	public ArrayList imethod_38(ArrayList oldList, int alignment, int depth)
	{
		return imethod_15(oldList, alignment);
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		if (imethod_5())
		{
			return null;
		}
		ArrayList arrayList = new ArrayList();
		method_29(arrayList);
		arrayList.Add(new Class5339(class5327_0.class5746_0.method_2(), class5327_0.class5684_0, imethod_22(new Class5258(this, 0)), auxiliary: true));
		method_30(arrayList);
		imethod_6(fin: true);
		return arrayList;
	}

	protected void method_29(ArrayList returnList)
	{
		if (class5703_0 != null)
		{
			int num = class5703_0.method_4(discard: false) + class5703_0.method_8(discard: false, this);
			if (num > 0)
			{
				returnList.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, new Class5258(this, -1), auxiliary: true));
				returnList.Add(new Class5344(num, 0, 0, new Class5258(this, -1), auxiliary: true));
			}
		}
	}

	protected void method_30(ArrayList returnList)
	{
		if (class5703_0 != null)
		{
			int num = class5703_0.method_5(discard: false) + class5703_0.method_9(discard: false, this);
			if (num > 0)
			{
				returnList.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, new Class5258(this, -1), auxiliary: true));
				returnList.Add(new Class5344(num, 0, 0, new Class5258(this, -1), auxiliary: true));
			}
		}
	}
}
