using System;
using System.Collections;
using System.Drawing;
using ns173;
using ns176;
using ns181;
using ns183;
using ns187;
using ns189;
using ns196;
using ns205;

namespace ns198;

internal class Class5300 : Class5299
{
	private class Class5270 : Class5269
	{
		private Class5300 class5300_0;

		internal Class5270(Class5300 iclm, Class5746 ipd)
			: base(iclm, ipd)
		{
			class5300_0 = iclm;
		}

		public override bool vmethod_21()
		{
			if (!method_0())
			{
				return class5395_0.method_23().Count > 1;
			}
			return false;
		}

		public override int vmethod_22()
		{
			return 0;
		}

		protected override Class5687 vmethod_14()
		{
			Class5687 @class = base.vmethod_14();
			@class.method_52(((Class5114)class5300_0.class5094_0).method_67());
			return @class;
		}

		protected override ArrayList vmethod_9(Class5687 context, int alignment)
		{
			ArrayList arrayList = new ArrayList();
			Interface173 @interface;
			while ((@interface = class5300_0.method_9()) != null)
			{
				Class5687 @class = new Class5687(0);
				@class.method_28(context.method_29());
				@class.method_30(context.method_31());
				@class.method_52(((Class5114)class5300_0.class5094_0).method_67());
				ArrayList arrayList2 = null;
				if (!@interface.imethod_5())
				{
					arrayList2 = @interface.imethod_14(@class, alignment);
				}
				if (arrayList2 != null)
				{
					class5300_0.method_33(arrayList2, arrayList);
				}
			}
			Class5644.smethod_6(arrayList);
			class5300_0.imethod_6(fin: true);
			return arrayList;
		}

		protected override void vmethod_2(Class5652 posIter, Class5687 context)
		{
			vmethod_3().imethod_9(posIter, context);
		}

		protected override int vmethod_0()
		{
			return ((Class5114)class5300_0.class5094_0).method_55();
		}
	}

	private Class4951 class4951_0;

	private Class4943 class4943_1;

	private Class4962 class4962_0;

	private Class5703 class5703_1;

	private Interface182 interface182_0;

	private int int_2 = 12;

	private Interface182 interface182_1;

	private int int_3;

	private Class5046 class5046_0;

	private Interface182 interface182_2;

	private Interface182 interface182_3;

	private bool bool_4;

	private bool bool_5;

	private int int_4;

	private int int_5;

	private int int_6;

	private bool bool_6;

	private Interface173 interface173_2;

	private int int_7;

	private int int_8;

	public bool InsideInline
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public int Lead
	{
		get
		{
			return int_7;
		}
		set
		{
			int_7 = value;
		}
	}

	public int Follow
	{
		get
		{
			return int_8;
		}
		set
		{
			int_8 = value;
		}
	}

	public Class5300(Class5114 node)
		: base(node)
	{
	}

	public override void imethod_3()
	{
		Class5114 @class = (Class5114)class5094_0;
		class5703_1 = @class.method_53();
		interface182_0 = @class.method_48();
		int_2 = @class.method_49();
		interface182_1 = @class.method_50();
		int_3 = @class.method_56();
		if (@class.method_61() % 180 != 0)
		{
			interface182_2 = @class.method_58().method_10(this).vmethod_0();
			interface182_3 = @class.method_51().method_10(this).vmethod_0();
		}
		else
		{
			interface182_2 = @class.method_51().method_10(this).vmethod_0();
			interface182_3 = @class.method_58().method_10(this).vmethod_0();
		}
	}

	protected void method_31(int contentAreaIPD)
	{
		int_4 = contentAreaIPD;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		Class5114 @class = (Class5114)class5094_0;
		bool flag = @class.method_61() % 180 != 0;
		bool_4 = false;
		context.method_29().method_2();
		int_6 = context.method_31();
		int num;
		if (interface182_2.imethod_0() != 9 && (interface182_2.imethod_4() || method_1() > 0))
		{
			num = interface182_2.imethod_6(this);
			num += class5703_1.method_19(discard: false, this);
		}
		else
		{
			num = 0;
			bool_4 = true;
		}
		if (interface182_3.imethod_0() == 9)
		{
			method_31(int_6);
			bool_5 = true;
		}
		int_5 = num - class5703_1.method_19(discard: false, this);
		method_36();
		ArrayList arrayList = new ArrayList();
		Class5274 class2 = new Class5277();
		method_29(class2);
		Class5746 class3 = Class5746.smethod_1(bool_5 ? int_6 : interface182_3.imethod_6(this));
		Class5270 class4 = new Class5270(this, class3);
		class4.method_1(interface182_2.imethod_6(this), bool_4);
		if (!class4.method_0())
		{
			if (bool_4)
			{
				int num2 = class4.vmethod_23();
				if (flag)
				{
					method_31(num2);
				}
				else
				{
					int_5 = num2 - class5703_1.method_19(discard: false, this);
				}
				method_36();
			}
			Class5254 pos = new Class5256(this, class4);
			class2.Add(new Class5339(class3.method_2(), vmethod_5(context), imethod_22(pos), auxiliary: false));
		}
		method_30(class2);
		arrayList.Add(class2);
		imethod_6(fin: true);
		return arrayList;
	}

	public override void imethod_8(Class4942 childArea)
	{
		class4962_0.vmethod_5((Class4962)childArea);
	}

	public override void imethod_9(Class5652 posIter, Class5687 context)
	{
		ArrayList arrayList = new ArrayList();
		Interface173 @interface = null;
		Class5254 @class = null;
		Class5256 class2 = null;
		bool num;
		while (true)
		{
			if (posIter.imethod_0())
			{
				Class5254 class3 = (Class5254)posIter.imethod_1();
				Class5254 class4 = class3;
				if (class3 is Class5255)
				{
					class4 = class3.vmethod_0();
				}
				if (class3 is Class5256)
				{
					if (class2 != null)
					{
						throw new Exception("Only one SubBreakerPosition allowed");
					}
					class2 = (Class5256)class3;
				}
				else if (class4 != null && !(class4 is Class5644.Class5264))
				{
					arrayList.Add(class4);
					@interface = class4.method_0();
					@class = class4;
				}
				continue;
			}
			vmethod_1();
			method_21(isStarting: true, isFirst: true, @class == null || method_17(@class));
			Interface173 interface2 = null;
			if (class2 == null)
			{
				Class5652 class5 = new Class5652(new Class5495(arrayList));
				Interface173 interface3;
				while ((interface3 = class5.method_0()) != null)
				{
					context.method_2(128, context.method_7() && interface3 == @interface);
					interface3.imethod_9(class5, context);
					context.method_18(context.method_22());
					context.method_2(256, bSet: true);
					interface2 = interface3;
				}
				class4951_0.method_54(class4943_1);
				imethod_2().imethod_8(class4951_0);
			}
			else
			{
				((Class5269)class2.method_6()).method_7();
			}
			method_21(isStarting: false, isFirst: true, @class == null || method_17(@class));
			num = context.method_7() && interface2 == interface173_2;
			break;
		}
		bool bSet = num;
		context.method_2(128, bSet);
	}

	public override int imethod_16()
	{
		if (interface182_3.imethod_0() != 9)
		{
			return interface182_3.imethod_6(this);
		}
		return int_4;
	}

	public override int imethod_17()
	{
		if (interface182_2.imethod_0() != 9)
		{
			return interface182_2.imethod_6(this);
		}
		return int_5;
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (Class5326.Instance.ResetArea)
		{
			class4943_1 = null;
		}
		if (class4943_1 == null)
		{
			class4951_0 = new Class4951(childArea);
			class4951_0.method_29(Class5757.int_25, true);
			class4951_0.method_11(imethod_16());
			class4951_0.method_13(imethod_17());
			Class5677.smethod_21(class4951_0, class5094_0.vmethod_31());
			Class5677.smethod_3(class4951_0, class5703_1, discardBefore: false, discardAfter: false, discardStart: false, discardEnd: false, this);
			Class5677.smethod_7(class4951_0, class5703_1, discardBefore: false, discardAfter: false, discardStart: false, discardEnd: false, this);
			Class5677.smethod_11(class4951_0, class5703_1, this);
			class4951_0.method_51(method_32());
			class4951_0.method_52(new RectangleF(0f, 0f, imethod_16(), imethod_17()));
			if (interface182_0 != null && interface182_0.imethod_0() != 14)
			{
				class4951_0.method_41(class5684_0.method_21());
			}
			class4943_1 = new Class4950();
			class4943_1.method_29(Class5757.int_24, true);
			Class5677.smethod_21(class4943_1, class5094_0.vmethod_31());
			imethod_2().imethod_7(class4943_1);
			class4943_1.method_11(int_6);
			class4962_0 = new Class4962();
			class4943_1.vmethod_2(class4962_0);
			method_25(class4951_0);
		}
		return class4943_1;
	}

	private bool method_32()
	{
		int num = ((Class5114)class5094_0).method_60();
		if (num != 57)
		{
			return num == 42;
		}
		return true;
	}

	protected override Class5684 vmethod_5(Class5687 context)
	{
		int num = int_7 + int_8;
		if ((int_7 == 0 && int_8 == 0) || int_5 < num)
		{
			class5684_0 = new Class5684(int_5, interface182_0, int_2, interface182_1, int_3, context.method_42());
			return class5684_0;
		}
		int num2 = (int_5 + num) / 2;
		class5684_0 = new Class5684(num2, interface182_0, int_2, interface182_1, int_3, context.method_42());
		if (InsideInline)
		{
			num *= 2;
		}
		Class5684 @class = new Class5684(InsideInline ? ((num2 + num) / 2) : num2, interface182_0, int_2, interface182_1, int_3, context.method_42());
		@class.AlignmentPoint = num2 - num;
		return @class;
	}

	protected override Class5746 vmethod_3(int refIPD)
	{
		return Class5746.smethod_1(class4943_0.method_12());
	}

	private void method_33(ArrayList sourceList, ArrayList targetList)
	{
		method_34(sourceList, targetList, force: false);
	}

	private void method_34(ArrayList sourceList, ArrayList targetList, bool force)
	{
		Interface168 @interface = new Class5495(sourceList);
		while (@interface.imethod_0())
		{
			object obj = @interface.imethod_1();
			if (obj is Class5328)
			{
				method_35((Class5328)obj, targetList, force);
			}
			else if (obj is ArrayList)
			{
				method_34((ArrayList)obj, targetList, force);
			}
		}
	}

	private void method_35(Class5328 el, ArrayList targetList, bool force)
	{
		if (force || el.method_2() != this)
		{
			el.method_1(imethod_22(new Class5255(this, el.method_0())));
		}
		targetList.Add(el);
	}

	private void method_36()
	{
	}
}
