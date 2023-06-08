using System.Collections;
using ns173;
using ns176;
using ns181;
using ns183;
using ns184;
using ns187;
using ns189;
using ns190;
using ns195;
using ns196;
using ns205;

namespace ns198;

internal class Class5315 : Class5314
{
	private Class5719 class5719_0;

	private Class5703 class5703_0;

	private bool bool_3;

	private Interface173 interface173_2;

	private Class5729 class5729_0;

	protected Interface182 interface182_0;

	protected int int_2 = 12;

	protected Interface182 interface182_1;

	protected int int_3;

	protected Class5046 class5046_0;

	private int int_4 = 161;

	private Class5684 class5684_0;

	public Class5315(Class5097 node)
		: base(node)
	{
	}

	public override void imethod_3()
	{
		Class5097 @class = (Class5097)class5094_0;
		int value = 0;
		Class5730 class2 = @class.vmethod_3().vmethod_1();
		Class5716 class3 = @class.method_52();
		Class5732[] array = class3.method_9(class2);
		class5729_0 = class2.method_12(array[0], class3.interface182_0.imethod_6(this), class3.method_5());
		class5046_0 = @class.method_54();
		class5703_0 = @class.method_51();
		class5719_0 = @class.method_50();
		if (@class is Class5100)
		{
			interface182_0 = ((Class5100)@class).method_64();
			int_2 = ((Class5100)@class).method_65();
			interface182_1 = ((Class5100)@class).method_66();
			int_3 = ((Class5100)@class).method_67();
			int_4 = ((Class5100)@class).method_63();
		}
		else if (@class is Class5102)
		{
			interface182_0 = ((Class5102)@class).method_63();
			int_2 = ((Class5102)@class).method_64();
			interface182_1 = ((Class5102)@class).method_65();
			int_3 = ((Class5102)@class).method_66();
		}
		else if (@class is Class5098)
		{
			interface182_0 = ((Class5098)@class).method_58();
			int_2 = ((Class5098)@class).method_59();
			interface182_1 = ((Class5098)@class).method_60();
			int_3 = ((Class5098)@class).method_61();
			int_4 = ((Class5098)@class).method_57();
		}
		if (class5703_0 != null)
		{
			value = class5703_0.method_16(0, discard: false, this);
			value += class5703_0.method_12(0, discard: false);
			value += class5703_0.method_16(1, discard: false, this);
			value += class5703_0.method_12(1, discard: false);
		}
		class5746_0 = Class5746.smethod_1(value);
	}

	public int method_30()
	{
		return int_4;
	}

	protected override Class5746 vmethod_2(bool isNotFirst, bool isNotLast)
	{
		int value = 0;
		if (class5703_0 != null)
		{
			value = class5703_0.method_16(2, isNotFirst, this);
			value += class5703_0.method_12(2, isNotFirst);
			value += class5703_0.method_16(3, isNotLast, this);
			value += class5703_0.method_12(3, isNotLast);
		}
		return Class5746.smethod_1(value);
	}

	protected override bool vmethod_3(bool isNotFirst)
	{
		if (class5703_0 != null)
		{
			if (class5703_0.method_16(2, isNotFirst, this) <= 0)
			{
				return class5703_0.method_12(2, isNotFirst) > 0;
			}
			return true;
		}
		return false;
	}

	protected override bool vmethod_4(bool isNotLast)
	{
		if (class5703_0 != null)
		{
			if (class5703_0.method_16(3, isNotLast, this) <= 0)
			{
				return class5703_0.method_12(3, isNotLast) > 0;
			}
			return true;
		}
		return false;
	}

	protected override Class5046 vmethod_5()
	{
		if (class5719_0 == null)
		{
			return null;
		}
		return class5719_0.class5046_0;
	}

	protected override Class5046 vmethod_6()
	{
		if (class5719_0 == null)
		{
			return null;
		}
		return class5719_0.class5046_1;
	}

	protected virtual Class4943 vmethod_8(bool isInline)
	{
		Class4943 @class;
		if (isInline)
		{
			@class = vmethod_9();
			@class.method_41(0);
			if (class5094_0 is Class5100 class2)
			{
				Class5024 class3 = class2.method_57();
				Class5677.smethod_23(@class, class3);
				if (class3 != null && class3.imethod_0() != 95)
				{
					Class5677.smethod_18(@class, class5729_0);
				}
				Class5677.smethod_25(@class, class2.method_58(this));
				Class5677.smethod_26(@class, class2.method_59(this));
				Class5677.smethod_27(@class, class2.method_60());
				Class5677.smethod_28(@class, class2.method_61());
			}
		}
		else
		{
			@class = new Class4950();
		}
		if (class5094_0 is Class5100 || class5094_0 is Class5098)
		{
			Class5677.smethod_21(@class, class5094_0.vmethod_31());
			if (class5094_0 is Class5100 class4)
			{
				Class5677.smethod_29(@class, class4.method_68());
				Interface182 @interface = class4.method_62();
				if (@interface.imethod_4())
				{
					@class.method_11((int)@interface.imethod_1());
				}
			}
		}
		return @class;
	}

	internal Interface182 method_31()
	{
		if ((class5094_0 is Class5100 || class5094_0 is Class5098) && class5094_0 is Class5100 @class)
		{
			return @class.method_62();
		}
		return null;
	}

	protected virtual Class4944 vmethod_9()
	{
		return new Class4944();
	}

	protected override void vmethod_7(bool isNotFirst, bool isNotLast)
	{
		if (class5703_0 != null)
		{
			Class5677.smethod_0(method_25(), class5703_0, isNotFirst, isNotLast, this);
			Class5677.smethod_11(method_25(), class5703_0, this);
		}
	}

	public bool method_32()
	{
		return method_33(imethod_2());
	}

	private bool method_33(Interface173 lm)
	{
		if (lm is Interface174)
		{
			return ((Interface174)lm).imethod_30();
		}
		if (lm is Class5315)
		{
			return ((Class5315)lm).method_32();
		}
		return method_33(lm.imethod_2());
	}

	private Class5319 method_34(Interface173 lm)
	{
		if (lm == null)
		{
			return null;
		}
		if (lm is Class5319 result)
		{
			return result;
		}
		return method_34(lm.imethod_2());
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		ArrayList arrayList = new ArrayList();
		Class5274 @class = null;
		if (class5094_0 is Class5099)
		{
			class5684_0 = new Class5684(class5729_0, class5046_0.method_10(this).vmethod_0().imethod_6(this), context.method_51());
		}
		else
		{
			class5684_0 = new Class5684(class5729_0, class5046_0.method_10(this).vmethod_0().imethod_6(this), interface182_0, int_2, interface182_1, int_3, context.method_42());
		}
		class5687_0 = new Class5687(context);
		class5687_0.method_41(class5684_0);
		if (context.method_5() && vmethod_5() != null)
		{
			context.method_19().method_3(new Class5697(vmethod_5(), this));
		}
		bool flag = false;
		if (class5703_0 != null)
		{
			class5687_0.method_45(context.method_44() + class5703_0.method_8(discard: true, this) + class5703_0.method_4(discard: true));
			class5687_0.method_47(context.method_46() + class5703_0.method_9(discard: true, this) + class5703_0.method_5(discard: true));
		}
		Interface173 @interface;
		while ((@interface = method_9()) != null)
		{
			if (!(@interface is Interface175) && class5703_0 != null)
			{
				class5687_0.method_30(class5687_0.method_31() - class5703_0.method_8(interface173_2 != null, this) - class5703_0.method_4(interface173_2 != null) - class5703_0.method_9(method_11(), this) - class5703_0.method_5(method_11()));
			}
			if (@interface is Class5300 class2)
			{
				Class5319 class3 = method_34(imethod_2());
				if (class3 != null && method_11())
				{
					Class5313 class4 = method_12() as Class5313;
					method_13();
					if (class4 != null)
					{
						class2.Lead = class3.Lead;
						class2.InsideInline = true;
						class2.Follow = class3.Follow;
					}
				}
			}
			ArrayList arrayList2 = @interface.imethod_14(class5687_0, alignment);
			if (arrayList.Count == 0 && class5687_0.method_17())
			{
				class5687_0.method_12();
			}
			if (arrayList2 == null || arrayList2.Count == 0)
			{
				continue;
			}
			if (@interface is Interface175)
			{
				context.method_11();
				Interface168 interface2 = new Class5495(arrayList2);
				while (interface2.imethod_0())
				{
					Class5274 class5 = (Class5274)interface2.imethod_1();
					class5.method_2(this);
				}
				int pos = 0;
				if (@class != null && @class.method_0((Class5274)arrayList2[0]))
				{
					pos = 1;
				}
				if (!flag && arrayList2.Count != 0)
				{
					method_35((ArrayList)arrayList2[0]);
					flag = true;
				}
				Interface208 interface3 = new Class5495(arrayList2, pos);
				while (interface3.imethod_0())
				{
					arrayList.Add(interface3.imethod_1());
				}
			}
			else
			{
				Class5275 class6 = new Class5275(arrayList2);
				class6.method_2(this);
				bool flag2 = false;
				if (@class != null)
				{
					if (@class.vmethod_2(class6))
					{
						Class5336 breakElement = new Class5336(new Class5254(this), 0, context);
						bool keepTogether = method_32() || context.method_16() || class5687_0.method_17();
						flag2 = @class.method_1(class6, keepTogether, breakElement);
					}
					else
					{
						@class.vmethod_1();
					}
				}
				if (!flag2)
				{
					if (!flag)
					{
						method_35(class6);
						flag = true;
					}
					arrayList.Add(class6);
				}
				context.method_14(class5687_0.method_9());
				class5687_0.method_13();
			}
			@class = (Class5274)Class5693.smethod_0(arrayList);
			interface173_2 = @interface;
		}
		if (@class != null)
		{
			method_36(@class);
		}
		imethod_6(fin: true);
		if (arrayList.Count == 0 && class5094_0.method_31())
		{
			Class5277 class7 = new Class5277();
			class7.Add(new Class5339(0, class5684_0, imethod_22(method_37()), auxiliary: true));
			arrayList.Add(class7);
		}
		if (arrayList.Count != 0)
		{
			return arrayList;
		}
		return null;
	}

	public override void imethod_9(Class5652 parentIter, Class5687 context)
	{
		vmethod_1();
		method_27(new Class5687(context));
		ArrayList arrayList = new ArrayList();
		Interface173 @interface = null;
		Class5254 @class = null;
		while (parentIter.imethod_0())
		{
			Class5254 class2 = (Class5254)parentIter.imethod_1();
			if (class2 != null && class2.vmethod_0() != null)
			{
				if (method_16(class2))
				{
					bool_3 = false;
				}
				arrayList.Add(class2.vmethod_0());
				@interface = class2.vmethod_0().method_0();
				@class = class2;
			}
		}
		if (vmethod_3(bool_3))
		{
			method_28().method_18(new Class5696(startsReferenceArea: false));
			method_28().method_2(256, bSet: true);
		}
		else
		{
			method_28().method_2(256, bSet: false);
		}
		if (vmethod_5() != null)
		{
			context.method_19().method_3(new Class5697(vmethod_5(), this));
		}
		method_21(isStarting: true, !bool_3, @class == null || method_17(@class));
		Class4943 class3 = vmethod_8(@interface == null || @interface is Interface175);
		class3.method_13(class5684_0.method_15());
		if (class3 is Class4944)
		{
			class3.method_41(class5684_0.method_21());
		}
		else if (class3 is Class4950 && class5703_0 != null)
		{
			class3.method_41(class5703_0.method_10(discard: false, this) + class5703_0.method_6(discard: false));
		}
		method_26(class3);
		Class5652 class4 = new Class5652(new Class5495(arrayList));
		Interface173 interface2 = null;
		Interface173 interface3;
		while ((interface3 = class4.method_0()) != null)
		{
			method_28().method_2(128, context.method_7() && interface3 == @interface);
			interface3.imethod_9(class4, method_28());
			method_28().method_18(method_28().method_22());
			method_28().method_2(256, bSet: true);
			interface2 = interface3;
		}
		bool flag = method_28().method_7() && interface2 == interface173_2;
		if (vmethod_4(flag))
		{
			method_29(method_25(), method_28().method_22().method_4(endsReferenceArea: false), method_28().method_38());
			context.method_21(new Class5696(startsReferenceArea: false));
		}
		else
		{
			context.method_21(method_28().method_22());
		}
		if (context.method_22() != null && vmethod_6() != null)
		{
			context.method_22().method_3(new Class5697(vmethod_6(), this));
		}
		vmethod_7(bool_3, @class == null || !method_17(@class));
		interface173_0.imethod_8(method_25());
		method_21(isStarting: false, !bool_3, @class == null || method_17(@class));
		context.method_2(128, flag);
		bool_3 = true;
		method_23(@class);
	}

	public override void imethod_8(Class4942 childArea)
	{
		Class4942 @class = method_25();
		if (method_28().method_20())
		{
			method_29(@class, method_28().method_19().method_4(endsReferenceArea: false), method_28().method_38());
		}
		@class.vmethod_2(childArea);
	}

	public override ArrayList imethod_38(ArrayList oldList, int alignment, int depth)
	{
		ArrayList arrayList = new ArrayList();
		method_35(arrayList);
		arrayList.AddRange(base.imethod_38(oldList, alignment, depth));
		method_36(arrayList);
		return arrayList;
	}

	protected void method_35(ArrayList returnList)
	{
		if (returnList is Class5275)
		{
			return;
		}
		Class5703 @class = ((Class5097)class5094_0).method_51();
		if (@class != null)
		{
			int num = @class.method_4(discard: false) + @class.method_8(discard: false, this);
			if (num > 0)
			{
				returnList.Insert(0, new Class5338(num, method_37(), auxiliary: true));
			}
		}
	}

	protected void method_36(ArrayList returnList)
	{
		if (returnList is Class5275)
		{
			return;
		}
		Class5703 @class = ((Class5097)class5094_0).method_51();
		if (@class != null)
		{
			int num = @class.method_5(discard: false) + @class.method_9(discard: false, this);
			if (num > 0)
			{
				returnList.Add(new Class5338(num, method_37(), auxiliary: true));
			}
		}
	}

	protected Class5254 method_37()
	{
		return new Class5255(this, null);
	}
}
