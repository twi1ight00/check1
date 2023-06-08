using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns171;
using ns173;
using ns176;
using ns183;
using ns186;
using ns187;
using ns189;
using ns205;

namespace ns196;

internal class Class5285 : Class5281, Interface184
{
	private class Class5257 : Class5255
	{
		private Class5271 class5271_0;

		public Class5257(Interface173 lm, Class5271 breaker)
			: base(lm, null)
		{
			class5271_0 = breaker;
		}

		public Class5271 method_6()
		{
			return class5271_0;
		}
	}

	private class Class5271 : Class5268
	{
		private Class5285 class5285_0;

		private Class5746 class5746_2;

		internal Class5395 class5395_0;

		private Class5276 class5276_0;

		private Class5276 class5276_1;

		public Class5271(Class5285 bclm, Class5746 ipd)
		{
			class5285_0 = bclm;
			class5746_2 = ipd;
		}

		protected override void vmethod_16(ArrayList elementList)
		{
			Class5651.smethod_2(elementList, "block-container", class5285_0.method_67().vmethod_31());
		}

		protected override bool vmethod_5()
		{
			return false;
		}

		protected override bool vmethod_6()
		{
			return true;
		}

		public int method_7()
		{
			Class5259 @class = (Class5259)class5395_0.method_23()[0];
			return @class.int_2;
		}

		public bool method_8()
		{
			if (!method_0())
			{
				if (class5395_0.method_23().Count <= 1)
				{
					return class5395_0.int_14 - class5395_0.int_16 > class5395_0.vmethod_22();
				}
				return true;
			}
			return false;
		}

		public int method_9()
		{
			return class5395_0.int_14 - class5395_0.int_16 - class5395_0.vmethod_22();
		}

		protected override Interface173 vmethod_3()
		{
			return class5285_0;
		}

		protected override Class5687 vmethod_14()
		{
			Class5687 @class = base.vmethod_14();
			@class.method_30(class5746_2.method_2());
			@class.method_52(class5285_0.method_67().imethod_7());
			return @class;
		}

		protected override ArrayList vmethod_9(Class5687 context, int alignment)
		{
			ArrayList arrayList = new ArrayList();
			Interface173 @interface;
			while ((@interface = class5285_0.method_9()) != null)
			{
				Class5687 context2 = class5285_0.vmethod_4(context);
				ArrayList arrayList2 = null;
				if (!@interface.imethod_5())
				{
					arrayList2 = @interface.imethod_14(context2, alignment);
				}
				if (arrayList2 != null)
				{
					class5285_0.method_50(arrayList2, arrayList);
				}
			}
			Class5644.smethod_6(arrayList);
			class5285_0.imethod_6(fin: true);
			return arrayList;
		}

		protected override int vmethod_0()
		{
			return class5285_0.method_67().method_53();
		}

		private static object smethod_4()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		protected override bool vmethod_1()
		{
			return !class5285_0.imethod_5();
		}

		protected override void vmethod_2(Class5652 posIter, Class5687 context)
		{
			Class5648.smethod_0(class5285_0, posIter, context);
		}

		protected override void vmethod_17(Class5395 alg, int partCount, Class5276 originalList, Class5276 effectiveList)
		{
			class5395_0 = alg;
			class5276_0 = originalList;
			class5276_1 = effectiveList;
		}

		protected override void vmethod_13(Class5395 alg, Class5259 pbp)
		{
		}

		protected override Interface173 vmethod_4()
		{
			return class5285_0.interface173_1;
		}

		public void method_10()
		{
			if (!method_0())
			{
				class5395_0.method_25();
				method_3(class5395_0, class5395_0.method_23().Count, class5276_0, class5276_1);
			}
		}
	}

	private Class4963 class4963_0;

	private Class4962 class4962_0;

	private Class5673 class5673_0;

	private Class5728 class5728_0;

	private Class5492 class5492_0;

	private Interface182 interface182_0;

	private Interface182 interface182_1;

	private int int_10;

	private bool bool_5 = true;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private Class5746 class5746_0;

	private Class5746 class5746_1;

	private double double_0;

	private double double_1;

	private List<Class5254> list_0 = new List<Class5254>();

	private bool bool_11;

	internal Interface182 Width
	{
		get
		{
			return interface182_0;
		}
		set
		{
			interface182_0 = value;
		}
	}

	public Class5673 CommonAbsolutePosition => class5673_0;

	public Class5285(Class5161 node)
		: base(node)
	{
	}

	public override void imethod_3()
	{
		class5673_0 = method_67().method_48();
		int_6 = method_67().method_49().interface182_4.imethod_6(this);
		int_8 = (int_7 = method_67().method_49().interface182_5.imethod_6(this));
		if (method_62())
		{
			interface182_1 = method_67().method_57().method_10(this).vmethod_0();
			interface182_0 = method_67().method_52().method_10(this).vmethod_0();
		}
		else
		{
			interface182_1 = method_67().method_52().method_10(this).vmethod_0();
			interface182_0 = method_67().method_57().method_10(this).vmethod_0();
		}
		int_3 = method_67().method_49().class5046_0.vmethod_5().method_10(this).vmethod_0()
			.imethod_6(this);
		int_4 = method_67().method_49().class5046_1.vmethod_5().method_10(this).vmethod_0()
			.imethod_6(this);
	}

	private void method_53()
	{
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		bool_10 = false;
		class5746_0 = null;
		class5746_1 = null;
	}

	protected int method_54()
	{
		return method_67().method_57().method_10(this).vmethod_0()
			.imethod_6(this);
	}

	private bool method_55()
	{
		int num = method_67().method_58();
		if (num != 57 && num != 42)
		{
			return method_67().method_64() != null;
		}
		return true;
	}

	private int method_56()
	{
		int num = 0;
		return 0 + method_67().method_50().method_19(discard: false, this);
	}

	private bool method_57()
	{
		if (class5673_0.int_0 != 1 && class5673_0.int_0 != 51 && class5673_0.int_0 != 206)
		{
			return class5673_0.int_0 == 215;
		}
		return true;
	}

	internal bool method_58()
	{
		return class5673_0.int_0 == 1;
	}

	private bool method_59()
	{
		return class5673_0.int_0 == 51;
	}

	public override int imethod_17()
	{
		if (bool_5)
		{
			return -1;
		}
		return int_10;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		return imethod_26(context, alignment, null, null, null);
	}

	protected override Class5687 vmethod_4(Class5687 context)
	{
		Class5687 @class = new Class5687(0);
		@class.method_28(context.method_29().method_8(Class5746.smethod_1(class5728_0.int_1)));
		@class.method_30(class5728_0.int_0);
		@class.method_52(method_67().imethod_7());
		return @class;
	}

	public override ArrayList imethod_26(Class5687 context, int alignment, Stack lmStack, Class5254 restartPosition, Interface173 restartAtLM)
	{
		method_53();
		if (method_57())
		{
			return method_63(context);
		}
		bool flag;
		bool flag2 = !(flag = lmStack != null) || lmStack.Count == 0;
		method_60(context);
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		if (!method_32(context, arrayList2))
		{
			return arrayList2;
		}
		vmethod_5(arrayList2, context, alignment);
		if (bool_5 && bool_6)
		{
			Interface173 @interface = null;
			Interface173 interface2;
			if (flag)
			{
				interface2 = ((!flag2) ? ((Interface173)lmStack.Pop()) : restartAtLM);
				method_10(interface2);
			}
			else
			{
				interface2 = method_9();
			}
			while (interface2 != null)
			{
				Class5687 @class = vmethod_4(context);
				ArrayList arrayList3;
				if (flag && !flag2)
				{
					arrayList3 = vmethod_6(interface2, context, @class, alignment, lmStack, restartPosition, restartAtLM);
					flag2 = true;
				}
				else
				{
					if (flag)
					{
						interface2.imethod_23();
					}
					arrayList3 = vmethod_6(interface2, context, @class, alignment, null, null, null);
					context.method_64(@class.method_63());
				}
				if (arrayList.Count == 0 && @class.method_17())
				{
					context.method_15(@class.method_10());
					@class.method_12();
				}
				if (arrayList3.Count != 1 || !Class5683.smethod_7(arrayList3))
				{
					if (@interface != null)
					{
						method_37(arrayList, context, @class);
					}
					if (arrayList3.Count == 1 && arrayList.Count > 0 && Class5683.smethod_6(arrayList) && arrayList3[0] is Class5338 && ((Class5338)arrayList3[0]).method_4() == 0)
					{
						arrayList.Insert(arrayList.Count - 1, arrayList3[0]);
					}
					else
					{
						arrayList.AddRange(arrayList3);
					}
					if (arrayList3.Count != 0)
					{
						context.method_14(@class.method_9());
						@class.method_13();
						@interface = interface2;
						interface2 = method_9();
					}
					continue;
				}
				arrayList.AddRange(arrayList3);
				method_50(arrayList, arrayList2);
				return arrayList2;
			}
			method_50(arrayList, arrayList2);
		}
		else
		{
			arrayList2.Add(method_61());
			context.method_64(Class5746.smethod_1(-1));
		}
		method_31(arrayList2, context, alignment);
		method_47(arrayList2, context);
		context.method_14(imethod_33());
		imethod_6(fin: true);
		if (method_67().IsBodyElement)
		{
			if (arrayList2.Count > 2 && arrayList2[0] is Class5335 && arrayList2[1] is Class5335 && ((Class5335)arrayList2[1]).method_4().method_2() != 13440)
			{
				arrayList2.RemoveAt(1);
			}
			if (arrayList2.Count > 2 && arrayList2[arrayList2.Count - 1] is Class5335 && arrayList2[arrayList2.Count - 2] is Class5335 && ((Class5335)arrayList2[arrayList2.Count - 2]).method_4().method_2() != 13440)
			{
				arrayList2.RemoveAt(arrayList2.Count - 2);
			}
		}
		return arrayList2;
	}

	private void method_60(Class5687 context)
	{
		bool_5 = false;
		int num = context.method_29().method_2();
		Class5161 @class = method_67();
		int num2;
		if (interface182_1.imethod_0() != 9 && (interface182_1.imethod_4() || method_1() > 0))
		{
			num2 = interface182_1.imethod_6(this);
			num2 += method_56();
		}
		else
		{
			Interface182 @interface = method_67().method_52().imethod_2(3072).vmethod_0();
			if (@interface.imethod_0() == 9)
			{
				num2 = num;
				bool_5 = true;
				bool_6 = @class.method_59() == 0;
			}
			else
			{
				num2 = @interface.imethod_6(this);
				num2 += method_56();
			}
		}
		int_10 = num2 - method_56();
		int_5 = context.method_31();
		if (interface182_0.imethod_0() == 9)
		{
			Interface182 interface2 = method_67().method_57().imethod_2(3072).vmethod_0();
			if (interface2.imethod_0() == 9)
			{
				method_29();
			}
			else
			{
				method_30(interface2.imethod_6(this));
			}
		}
		else
		{
			int contentIPD = interface182_0.imethod_6(this);
			method_30(contentIPD);
		}
		double_0 = 0.0;
		double_1 = 0.0;
		int num3 = @class.method_41();
		if (num3 >= 0 && ((uint)num3 & (true ? 1u : 0u)) != 0)
		{
			double_0 += @class.method_49().interface182_5.imethod_6(this);
		}
		else
		{
			double_0 += @class.method_49().interface182_4.imethod_6(this);
		}
		double_1 += @class.method_50().method_6(discard: false);
		double_1 += @class.method_50().method_10(discard: false, this);
		method_65();
		int num4 = int_5 - vmethod_7();
		if (imethod_16() > num4)
		{
			Interface206 interface3 = Class5701.smethod_0(@class.method_2().method_48());
			interface3.imethod_2(this, @class.method_17(), imethod_16(), context.method_31(), @class.method_1());
		}
	}

	private Class5338 method_61()
	{
		Class5746 ipd = Class5746.smethod_1(class5728_0.int_0);
		Class5271 @class = new Class5271(this, ipd);
		@class.method_1(class5728_0.int_1, bool_5);
		bool flag = @class.method_8();
		if (bool_5)
		{
			int int_ = @class.class5395_0.int_14;
			if (method_62())
			{
				vmethod_8(int_);
			}
			else
			{
				int_10 = int_;
			}
			method_65();
		}
		Class5254 pos = new Class5257(this, @class);
		Class5338 result = new Class5338(int_10, imethod_22(pos), auxiliary: false);
		if (flag)
		{
			Interface206 @interface = Class5701.smethod_0(method_67().method_2().method_48());
			bool canRecover = method_67().method_58() != 42;
			@interface.imethod_4(this, method_67().method_17(), @class.method_9(), method_55(), canRecover, method_67().method_1());
		}
		return result;
	}

	private bool method_62()
	{
		return method_67().method_59() % 180 != 0;
	}

	public override bool imethod_24()
	{
		return true;
	}

	private ArrayList method_63(Class5687 context)
	{
		bool_5 = false;
		bool flag = method_62();
		Point point = method_66();
		Class5285 @class = method_2();
		Interface172 context2;
		Interface172 context3;
		if (@class != null && @class.class5728_0 != null)
		{
			context2 = new Class5753(null, 5, @class.class5728_0.int_0);
			context3 = new Class5753(null, 6, @class.class5728_0.int_1);
		}
		else
		{
			context2 = this;
			context3 = this;
		}
		int num;
		if (interface182_1.imethod_0() != 9 && (interface182_1.imethod_4() || @class.method_6() > 0))
		{
			num = interface182_1.imethod_6(context3);
			num += method_56();
		}
		else
		{
			num = 0;
			if (class5673_0.interface182_2.imethod_0() != 9)
			{
				int num2 = ((!method_59()) ? context.method_29().method_2() : ((int)method_15().method_11().Height));
				num = num2;
				num -= point.Y;
				if (class5673_0.interface182_2.imethod_0() != 9)
				{
					num -= class5673_0.interface182_2.imethod_6(context3);
					if (num < 0)
					{
						num = 0;
					}
				}
				else if (num < 0)
				{
					num = 0;
				}
			}
			else
			{
				num = context.method_29().method_2();
				if (!flag)
				{
					bool_5 = true;
				}
			}
		}
		int num4;
		if (interface182_0.imethod_0() == 9)
		{
			int num3 = ((!method_59()) ? context.method_31() : ((int)method_15().method_11().Width));
			num4 = num3;
			if (class5673_0.interface182_3.imethod_0() != 9)
			{
				num4 -= class5673_0.interface182_3.imethod_6(context2);
			}
			if (class5673_0.interface182_1.imethod_0() != 9)
			{
				num4 -= class5673_0.interface182_1.imethod_6(context2);
				if (num4 < 0)
				{
					num4 = 0;
				}
			}
			else
			{
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (flag)
				{
					bool_5 = true;
				}
			}
		}
		else
		{
			num4 = interface182_0.imethod_6(context2);
			num4 += vmethod_7();
		}
		int_10 = num - method_56();
		vmethod_8(num4 - vmethod_7());
		double_0 = 0.0;
		double_1 = 0.0;
		method_65();
		Class5746 ipd = Class5746.smethod_1(class5728_0.int_0);
		Class5271 class2 = new Class5271(this, ipd);
		class2.method_1((!bool_5) ? class5728_0.int_1 : 0, bool_5);
		bool flag2 = class2.method_8();
		if (bool_5)
		{
			int int_ = class2.class5395_0.int_14;
			if (flag)
			{
				vmethod_8(int_);
			}
			else
			{
				int_10 = int_;
			}
			method_65();
		}
		ArrayList arrayList = new ArrayList();
		if (!class2.method_0())
		{
			Class5254 class3 = new Class5257(this, class2);
			if (@class != null && class5673_0.int_0 == 1)
			{
				@class.list_0.Add(class3);
			}
			arrayList.Add(new Class5338(0, imethod_22(class3), auxiliary: false));
			if (!bool_5 && flag2)
			{
				Interface206 @interface = Class5701.smethod_0(method_67().method_2().method_48());
				bool canRecover = method_67().method_58() != 42;
				@interface.imethod_4(this, method_67().method_17(), class2.method_9(), method_55(), canRecover, method_67().method_1());
			}
		}
		imethod_6(fin: true);
		return arrayList;
	}

	private void method_64()
	{
		Class5285 @class = method_2();
		if (@class == null)
		{
			return;
		}
		bool_11 = true;
		Class5094 class2 = imethod_21();
		if (class2 == null)
		{
			return;
		}
		foreach (Class5254 item in @class.list_0)
		{
			if (item.method_0() is Class5285 class3)
			{
				Class5094 class4 = class3.imethod_21();
				if (class4 != null && class4 == class2)
				{
					class3.bool_11 = true;
				}
			}
		}
	}

	private void method_65()
	{
		RectangleF absVPrect = new RectangleF((float)double_0, (float)double_1, imethod_16(), int_10);
		class5728_0 = new Class5728(0, 0);
		class5492_0 = Class5492.smethod_1(method_67().method_59(), method_67().imethod_7(), absVPrect, class5728_0);
	}

	private Point method_66()
	{
		Class5285 @class = method_2();
		Interface172 context;
		Interface172 context2;
		if (@class != null && @class.class5728_0 != null)
		{
			context = new Class5753(null, 5, @class.class5728_0.int_0);
			context2 = new Class5753(null, 6, @class.class5728_0.int_1);
		}
		else
		{
			context = this;
			context2 = this;
		}
		int x = 0;
		int y = 0;
		if (class5673_0.interface182_3.imethod_0() != 9)
		{
			x = class5673_0.interface182_3.imethod_6(context);
		}
		else if (class5673_0.interface182_1.imethod_0() != 9 && interface182_0.imethod_0() != 9)
		{
			x = @class.class5728_0.int_0 - class5673_0.interface182_1.imethod_6(context) - interface182_0.imethod_6(context);
		}
		if (class5673_0.interface182_0.imethod_0() != 9)
		{
			y = class5673_0.interface182_0.imethod_6(context2);
		}
		else if (class5673_0.interface182_2.imethod_0() != 9 && interface182_1.imethod_0() != 9)
		{
			y = @class.class5728_0.int_1 - class5673_0.interface182_2.imethod_6(context2) - interface182_1.imethod_6(context2);
		}
		return new Point(x, y);
	}

	public override void imethod_9(Class5652 parentIter, Class5687 layoutContext)
	{
		imethod_7(null);
		if (bool_11 && class5673_0.int_0 == 1)
		{
			while (parentIter.imethod_0())
			{
				parentIter.imethod_1();
			}
			return;
		}
		if (layoutContext.method_53() > 0)
		{
			method_26(0.0, Class5746.smethod_1(layoutContext.method_53()));
		}
		Interface173 lastLM = null;
		Class5687 @class = new Class5687(0);
		@class.method_37(layoutContext.method_38());
		if (layoutContext.method_55() > 0)
		{
			@class.method_56(layoutContext.method_55());
		}
		Class5257 class2 = null;
		ArrayList arrayList = new ArrayList();
		Class5254 class3 = null;
		Class5254 pos = null;
		while (true)
		{
			if (parentIter.imethod_0())
			{
				Class5254 class4 = (Class5254)parentIter.imethod_1();
				if (class4.method_4() >= 0)
				{
					if (class3 == null)
					{
						class3 = class4;
					}
					pos = class4;
				}
				Class5254 class5 = class4;
				if (class4 is Class5255)
				{
					class5 = class4.vmethod_0();
				}
				if (class4 is Class5257)
				{
					if (class2 != null)
					{
						throw new InvalidOperationException("Only one BlockContainerPosition allowed");
					}
					class2 = (Class5257)class4;
				}
				else if (class5 != null && (class5.method_0() != this || class5 is Class5261))
				{
					arrayList.Add(class5);
					lastLM = class5.method_0();
				}
				continue;
			}
			vmethod_1();
			method_21(isStarting: true, method_16(class3), method_17(pos));
			if (class2 == null)
			{
				Class5652 class6 = new Class5652(new Class5495(arrayList));
				Interface173 childLM;
				while ((childLM = class6.method_0()) != null)
				{
					smethod_1(layoutContext, @class, childLM, lastLM, class6);
				}
				if (list_0.Count <= 0)
				{
					break;
				}
				ArrayList arrayList2 = new ArrayList();
				foreach (Class5254 item in list_0)
				{
					arrayList2.Add(item);
				}
				list_0.Clear();
				class6 = new Class5652(new Class5495(arrayList2));
				while ((childLM = class6.method_0()) != null)
				{
					childLM.imethod_1(this);
					smethod_1(layoutContext, @class, childLM, lastLM, class6);
				}
			}
			else
			{
				class2.method_6().method_10();
			}
			break;
		}
		method_21(isStarting: false, method_16(class3), method_17(pos));
		Class5677.smethod_15(class4963_0, layoutContext.method_38(), class5746_0, class5746_1);
		vmethod_2();
		class4963_0 = null;
		class4962_0 = null;
		method_53();
		method_22();
		method_64();
	}

	private static void smethod_1(Class5687 layoutContext, Class5687 lc, Interface173 childLM, Interface173 lastLM, Class5652 childPosIter)
	{
		lc.method_2(128, layoutContext.method_7() && childLM == lastLM);
		lc.method_28(layoutContext.method_29());
		childLM.imethod_9(childPosIter, lc);
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (class4962_0 == null)
		{
			bool flag = method_62();
			bool flag2 = bool_5 && !flag;
			int num = method_67().method_41();
			class4963_0 = new Class4963(flag2);
			class4963_0.PredefinedWidth = interface182_0;
			class4963_0.method_29(Class5757.int_25, true);
			if (num >= 0)
			{
				class4963_0.method_16(num);
			}
			class4963_0.method_11(imethod_16());
			if (flag2)
			{
				class4963_0.method_13(0);
			}
			else
			{
				class4963_0.method_13(int_10);
			}
			method_18(class4963_0);
			Class5677.smethod_21(class4963_0, method_67().vmethod_31());
			Class5677.smethod_22(class4963_0, method_67().method_62());
			Class5677.smethod_4(class4963_0, method_67().method_51(), this);
			Class5677.smethod_29(class4963_0, method_67().method_63());
			Class5677.smethod_3(class4963_0, method_67().method_50(), bool_7, bool_8, discardStart: false, discardEnd: false, this);
			Class5677.smethod_7(class4963_0, method_67().method_50(), bool_9, bool_10, discardStart: false, discardEnd: false, this);
			if (method_67().method_49().interface182_2 is Class5035 && method_67().method_49().interface182_3 is Class5035)
			{
				int num2 = imethod_16();
				int num3 = (method_5() - num2) / 2;
				if (num3 < 0)
				{
					num3 = 0;
				}
				Interface182 numeric = Class5036.smethod_2(num3);
				Class5049 @class = (Class5049)method_67().method_49().interface182_4;
				@class.method_5(method_67().method_49().interface182_2, numeric);
				@class = (Class5049)method_67().method_49().interface182_5;
				@class.method_5(method_67().method_49().interface182_3, numeric);
				if (class5673_0.int_0 != 1 && class5673_0.int_0 != 51 && class5673_0.int_0 != 206 && class5673_0.int_0 != 215)
				{
					int_6 = method_67().method_49().interface182_4.imethod_6(this);
					int_7 = method_67().method_49().interface182_5.imethod_6(this);
				}
				else
				{
					class4963_0.method_38(method_67().method_49().interface182_4.imethod_6(this), leftAuto: false, rightAuto: false);
				}
			}
			Class5677.smethod_12(class4963_0, method_67().method_50(), int_6, int_7, this);
			class4963_0.EndIndent = int_8;
			class4963_0.method_49(class5492_0);
			class4963_0.method_51(method_55());
			if (method_67().method_64() != null)
			{
				Class4925 class2 = method_67().method_64();
				class4963_0.method_52(class2.method_0());
			}
			if ((class5673_0.int_0 == 1 || class5673_0.int_0 == 51 || class5673_0.int_0 == 206 || class5673_0.int_0 == 215) && (!(method_67().method_49().interface182_2 is Class5035) || !(method_67().method_49().interface182_3 is Class5035)))
			{
				Point point = method_66();
				class4963_0.method_38(point.X, class5673_0.interface182_3.imethod_0() == 9, class5673_0.interface182_1.imethod_0() == 9);
				class4963_0.method_39(point.Y, class5673_0.interface182_0.imethod_0() == 9, class5673_0.interface182_2.imethod_0() == 9);
			}
			class4962_0 = new Class4962();
			class4962_0.method_29(Class5757.int_24, true);
			if (num >= 0)
			{
				class4962_0.method_16(num);
			}
			Class5677.smethod_21(class4962_0, method_67().vmethod_31());
			if (class5673_0.int_0 == 1)
			{
				class4963_0.method_44(2);
			}
			else if (class5673_0.int_0 == 206)
			{
				class4963_0.method_44(4);
			}
			else if (class5673_0.int_0 == 215)
			{
				class4963_0.method_44(5);
			}
			else if (class5673_0.int_0 == 51)
			{
				class4963_0.method_44(3);
			}
			interface173_0.imethod_7(class4962_0);
			class4962_0.method_11(class5728_0.int_0);
			if (method_67().method_49().interface182_2 is Class5035 && method_67().method_49().interface182_3 is Class5035)
			{
				class4962_0.method_38(int_6, leftAuto: false, rightAuto: false);
			}
			method_25(class4963_0);
		}
		return class4962_0;
	}

	public override void imethod_8(Class4942 childArea)
	{
		if (class4962_0 != null)
		{
			class4962_0.vmethod_5((Class4962)childArea);
		}
	}

	protected override void vmethod_2()
	{
		class4963_0.method_42(class4962_0, bool_5);
		Class5677.smethod_11(class4963_0, method_67().method_50(), this);
		base.vmethod_2();
	}

	public override int imethod_27(int adj, Class5337 lastElement)
	{
		return 0;
	}

	public override void imethod_28(Class5344 spaceGlue)
	{
	}

	public override Class5043 imethod_35()
	{
		return method_67().method_56();
	}

	public override Class5043 imethod_36()
	{
		return method_67().method_55();
	}

	public override Class5043 imethod_37()
	{
		return method_67().method_54();
	}

	internal Class5161 method_67()
	{
		return (Class5161)class5094_0;
	}

	public override bool imethod_18()
	{
		return true;
	}

	public override bool imethod_19()
	{
		return true;
	}

	public void imethod_38(Class5695 side, Class5746 effectiveLength)
	{
		if (Class5695.class5695_0 == side)
		{
			class5746_0 = effectiveLength;
		}
		else
		{
			class5746_1 = effectiveLength;
		}
	}

	public void imethod_39(Class5695 side, Class5746 effectiveLength)
	{
		if (effectiveLength == null)
		{
			if (Class5695.class5695_0 == side)
			{
				bool_7 = true;
			}
			else
			{
				bool_8 = true;
			}
		}
	}

	public void imethod_40(Class5695 side, Class5746 effectiveLength)
	{
		if (effectiveLength == null)
		{
			if (Class5695.class5695_0 == side)
			{
				bool_9 = true;
			}
			else
			{
				bool_10 = true;
			}
		}
	}
}
