using System;
using System.Collections;
using ns171;
using ns173;
using ns183;
using ns190;
using ns205;

namespace ns196;

internal class Class5272 : Class5268
{
	private class Class5436 : Class5395.Interface183
	{
		private Class5272 class5272_0;

		internal Class5436(Class5272 owner)
		{
			class5272_0 = owner;
		}

		public void imethod_0(int part, int amount, Class5094 obj)
		{
			Class5690 @class = class5272_0.class5691_0.method_9(isBlank: false, part, Class5691.int_1);
			Class5143 class2 = (Class5143)@class.method_0().method_51(58);
			Interface206 @interface = Class5701.smethod_0(class2.method_2().method_48());
			bool canRecover = class2.method_54() != 42;
			bool clip = class2.method_54() == 57 || class2.method_54() == 42;
			@interface.imethod_5(this, class2.method_17(), @class.method_1().method_15(), amount, clip, canRecover, class2.method_1());
		}
	}

	private Class5322 class5322_0;

	private bool bool_1 = true;

	private bool bool_2;

	private bool bool_3;

	private Class5691 class5691_0;

	private Class4962 class4962_0;

	private Class4962 class4962_1;

	private bool bool_4;

	private Class5297 class5297_0;

	private Class5295 class5295_0;

	private Class5295 class5295_1;

	public Class5272(Class5322 pslm)
	{
		class5322_0 = pslm;
		class5691_0 = pslm.method_34();
		class5297_0 = pslm.method_24().imethod_4(pslm, pslm.method_35().method_56());
	}

	protected override void vmethod_15(Class5687 context)
	{
		int ipd = class5322_0.method_15().method_34().method_39();
		context.method_30(ipd);
	}

	protected override Interface173 vmethod_3()
	{
		return class5322_0;
	}

	protected override Class5691 vmethod_7()
	{
		return class5322_0.method_34();
	}

	internal void method_7(int flowBPD)
	{
		method_1(flowBPD, autoHeight: false);
	}

	protected override Class5395.Interface183 vmethod_8()
	{
		return new Class5436(this);
	}

	protected override int vmethod_18(Class5687 childLC, int nextSequenceStartsOn)
	{
		bool_3 = false;
		if (childLC.method_48() != 0)
		{
			nextSequenceStartsOn = childLC.method_48();
			bool_3 = childLC.method_48() == 5 && childLC.method_61() == 48;
		}
		return nextSequenceStartsOn;
	}

	protected override int vmethod_19(Class5687 childLC, int nextSequenceStartsOn)
	{
		return vmethod_20(childLC, nextSequenceStartsOn, null, null, null);
	}

	protected override int vmethod_20(Class5687 childLC, int nextSequenceStartsOn, Class5254 positionAtIPDChange, Interface173 restartLM, ArrayList firstElements)
	{
		if (!bool_1)
		{
			method_13(nextSequenceStartsOn);
		}
		bool_1 = false;
		bool_2 = true;
		class5691_0.method_0(class5322_0.method_26(), class5322_0.method_15().method_34().method_43(), bool_4);
		return base.vmethod_20(childLC, nextSequenceStartsOn, positionAtIPDChange, restartLM, firstElements);
	}

	private bool method_8(ArrayList contentList, Class5687 context, out bool floatsPresent)
	{
		bool result = false;
		floatsPresent = false;
		if (contentList != null)
		{
			Interface168 @interface = new Class5495(contentList);
			while (@interface.imethod_0())
			{
				Class5328 @class = (Class5328)@interface.imethod_1();
				if (!(@class is Class5341))
				{
					continue;
				}
				if (((Class5341)@class).method_8())
				{
					result = true;
					Class5687 class2 = new Class5687(context);
					class2.method_28(context.method_29());
					class2.method_30(class5322_0.method_15().method_37(58).method_12());
					ArrayList arrayList = ((Class5341)@class).method_6();
					Interface168 interface2 = new Class5495(arrayList);
					while (interface2.imethod_0())
					{
						Class5294 class3 = (Class5294)interface2.imethod_1();
						class3.imethod_1(class5297_0);
						class3.imethod_3();
						((Class5341)@class).method_10(class3.imethod_14(class2, int_0));
					}
				}
				if (((Class5341)@class).method_9())
				{
					floatsPresent = true;
					Class5687 class4 = new Class5687(context);
					class4.method_28(context.method_29());
					class4.method_30(class5322_0.method_15().method_37(58).method_12());
					ArrayList arrayList2 = ((Class5341)@class).method_7();
					Interface168 interface3 = new Class5495(arrayList2);
					while (interface3.imethod_0())
					{
						Class5282 class5 = (Class5282)interface3.imethod_1();
						class5.imethod_1(class5297_0);
						class5.imethod_3();
						((Class5341)@class).method_12(class5.imethod_14(class4, int_0));
					}
				}
			}
		}
		return result;
	}

	private void method_9()
	{
		Class5129 @class = class5322_0.method_35().method_54("xsl-footnote-separator");
		if (@class != null)
		{
			class4962_0 = new Class4962();
			class4962_0.method_11(class5322_0.method_15().method_37(58).method_12());
			class5295_0 = class5322_0.method_24().imethod_7(class5322_0, @class, class4962_0);
			class5295_0.method_53();
			class5746_0 = Class5746.smethod_1(class4962_0.vmethod_1());
		}
	}

	private void method_10(bool floatsPresent)
	{
		Class5129 sc;
		if (floatsPresent && (sc = class5322_0.method_35().method_54("xsl-before-float-separator")) != null)
		{
			class4962_1 = new Class4962();
			class4962_1.method_11(class5322_0.method_15().method_37(58).method_12());
			class5295_1 = class5322_0.method_24().imethod_7(class5322_0, sc, class4962_1);
			class5295_1.method_53();
			class5746_1 = Class5746.smethod_1(class4962_1.vmethod_1());
		}
	}

	protected override ArrayList vmethod_9(Class5687 context, int alignment)
	{
		ArrayList arrayList = null;
		while (!class5297_0.imethod_5() && arrayList == null)
		{
			arrayList = class5297_0.imethod_14(context, alignment);
		}
		if (method_8(arrayList, context, out var floatsPresent))
		{
			method_9();
		}
		method_10(floatsPresent);
		return arrayList;
	}

	protected override ArrayList vmethod_10(Class5687 context, int alignment, Class5254 positionAtIPDChange, Interface173 restartAtLM)
	{
		ArrayList arrayList = null;
		do
		{
			arrayList = class5297_0.method_53(context, alignment, positionAtIPDChange, restartAtLM);
		}
		while (!class5297_0.imethod_5() && arrayList == null);
		if (method_8(arrayList, context, out var floatsPresent))
		{
			method_9();
		}
		method_10(floatsPresent);
		return arrayList;
	}

	protected override int vmethod_0()
	{
		return class5322_0.vmethod_0().method_0().method_51(58)
			.method_55();
	}

	protected override bool vmethod_1()
	{
		return !class5297_0.imethod_5();
	}

	protected override void vmethod_2(Class5652 posIter, Class5687 context)
	{
		if (class5295_0 != null)
		{
			Class5129 sc = class5322_0.method_35().method_54("xsl-footnote-separator");
			class4962_0 = new Class4962();
			class4962_0.method_11(class5322_0.method_15().method_37(58).method_12());
			class5295_0 = class5322_0.method_24().imethod_7(class5322_0, sc, class4962_0);
			class5295_0.method_53();
		}
		if (class5295_1 != null)
		{
			Class5129 sc2 = class5322_0.method_35().method_54("xsl-before-float-separator");
			class4962_1 = new Class4962();
			class4962_1.method_11(class5322_0.method_15().method_37(58).method_12());
			class5295_1 = class5322_0.method_24().imethod_7(class5322_0, sc2, class4962_1);
			class5295_1.method_53();
		}
		class5297_0.imethod_9(posIter, context);
	}

	protected override void vmethod_17(Class5395 alg, int partCount, Class5276 originalList, Class5276 effectiveList)
	{
		if (bool_3)
		{
			method_11(alg, partCount, originalList, effectiveList);
			return;
		}
		bool flag = class5322_0.method_35().method_61();
		if (!vmethod_1() && flag)
		{
			method_11(alg, partCount, originalList, effectiveList);
		}
		else
		{
			method_3(alg, partCount, originalList, effectiveList);
		}
	}

	private void method_11(Class5395 alg, int partCount, Class5276 originalList, Class5276 effectiveList)
	{
		int num = 0;
		int num2 = class5691_0.method_8(partCount);
		if (num2 > 0)
		{
			method_3(alg, num2, originalList, effectiveList);
			Class5259 @class = (Class5259)alg.method_23()[num2 - 1];
			num = @class.method_6() + 1;
			if (num > 0)
			{
				method_13(104);
			}
		}
		bool_2 = true;
		int num3 = class5322_0.method_26();
		class5691_0.method_0(num3, class5322_0.method_15().method_34().method_43(), bool_4);
		effectiveList.int_1 = num;
		Class5395 class2;
		if (bool_3)
		{
			class2 = new Class5396(vmethod_3(), vmethod_7(), vmethod_8(), int_0, 135, class5746_0, class5746_1, vmethod_5(), class5322_0.method_15().method_32().method_45());
		}
		else
		{
			Class4965 class3 = class5691_0.method_10(isBlank: false, num3).method_1().method_32();
			method_12(num3);
			Class4965 class4 = class5691_0.method_10(isBlank: false, num3).method_1().method_32();
			class4.method_47().method_39(class3.method_47().method_38());
			class2 = new Class5395(vmethod_3(), vmethod_7(), vmethod_8(), alg.method_19(), alg.method_20(), class5746_0, class5746_1, vmethod_5(), autoHeight: false, favorSinglePart: false);
		}
		int num4 = class2.method_4(effectiveList, num, 1.0, force: true, Class5394.int_2);
		bool flag = num4 <= class5322_0.method_15().method_32().method_47()
			.method_40()
			.method_38();
		if (bool_3)
		{
			if (flag)
			{
			}
		}
		else
		{
			if (!flag)
			{
				method_4(alg, num2, partCount - num2, originalList, effectiveList);
				method_12(num3 + 1);
				class5322_0.method_25(class5322_0.vmethod_3(isBlank: true));
				return;
			}
			class5322_0.method_25(class5691_0.method_10(isBlank: false, num3));
		}
		method_3(class2, num4, originalList, effectiveList);
	}

	private void method_12(int currentPageNum)
	{
		int index = class5322_0.method_37(currentPageNum);
		class5691_0.method_1(index);
	}

	protected override void vmethod_11(Class5276 list, int breakClass)
	{
		if (class5322_0.vmethod_0() == null)
		{
			throw new InvalidOperationException("curPage must not be null");
		}
		if (!bool_2)
		{
			if (!bool_1)
			{
				method_13(breakClass);
			}
			class5691_0.method_0(class5322_0.method_26(), class5322_0.method_15().method_34().method_43(), bool_4);
		}
		bool_2 = false;
		bool_1 = false;
	}

	protected override void vmethod_12()
	{
		class5322_0.method_15().method_12().method_9();
	}

	protected override void vmethod_13(Class5395 alg, Class5259 pbp)
	{
		if (pbp.int_7 <= pbp.int_8)
		{
			for (int i = pbp.int_7; i <= pbp.int_8; i++)
			{
				ArrayList arrayList = alg.method_27(i);
				int num = arrayList.Count - 1;
				Class5644.smethod_7(arrayList, 0, num, -1);
				Class5687 layoutContext = new Class5687(0);
				Class5648.smethod_0(null, new Class5653(arrayList, 0, num + 1), layoutContext);
			}
			Class4958 @class = class5322_0.method_15().method_32().method_49();
			@class.method_42(class4962_1);
		}
		if (pbp.int_3 < pbp.int_5 || pbp.int_4 <= pbp.int_6)
		{
			for (int j = pbp.int_3; j <= pbp.int_5; j++)
			{
				ArrayList arrayList2 = alg.method_26(j);
				int num2 = ((j == pbp.int_3) ? pbp.int_4 : 0);
				int num3 = ((j == pbp.int_5) ? pbp.int_6 : (arrayList2.Count - 1));
				Class5644.smethod_7(arrayList2, num2, num3, -1);
				Class5687 layoutContext2 = new Class5687(0);
				Class5648.smethod_0(null, new Class5653(arrayList2, num2, num3 + 1), layoutContext2);
			}
			Class4960 class2 = class5322_0.method_15().method_32().method_50();
			int num4 = class5322_0.method_15().method_32().vmethod_1() - class2.vmethod_1() - class5322_0.method_15().method_32().method_49()
				.vmethod_1();
			if (class4962_0 != null)
			{
				num4 -= class4962_0.vmethod_1();
			}
			class2.method_44(num4);
			class2.method_42(class4962_0);
		}
		class5322_0.method_15().method_34().method_46();
	}

	protected override Interface173 vmethod_4()
	{
		return class5297_0;
	}

	protected override void vmethod_16(ArrayList elementList)
	{
		Class5651.smethod_2(elementList, "breaker", class5322_0.imethod_21().vmethod_31());
	}

	private void method_13(int breakVal)
	{
		Class5690 @class = class5322_0.vmethod_0();
		switch (breakVal)
		{
		case 5:
			@class.method_1().method_33(spanAll: true);
			bool_4 = true;
			break;
		default:
			if (method_14(breakVal))
			{
				class5322_0.vmethod_3(isBlank: true);
			}
			if (method_15(breakVal))
			{
				class5322_0.vmethod_3(isBlank: false);
			}
			break;
		case 95:
			@class.method_1().method_33(spanAll: false);
			bool_4 = false;
			break;
		case -1:
		case 9:
		case 28:
		case 104:
		{
			Class4974 class2 = @class.method_1();
			Class5143 class3 = (Class5143)@class.method_0().method_51(58);
			if (class3.method_59() > 1 && class2.method_34().method_38() == 1)
			{
				@class = class5322_0.vmethod_3(isBlank: false);
				@class.method_1().method_33(spanAll: true);
			}
			else if (class2.method_34().method_45())
			{
				class2.method_34().method_44();
			}
			else
			{
				class5322_0.vmethod_3(isBlank: false);
			}
			break;
		}
		}
	}

	private bool method_14(int breakVal)
	{
		if (breakVal != 104 && !class5322_0.vmethod_0().method_1().method_12()
			.method_12())
		{
			if (class5322_0.method_26() % 2 == 0)
			{
				return breakVal == 44;
			}
			return breakVal == 100;
		}
		return false;
	}

	private bool method_15(int breakVal)
	{
		if (class5322_0.vmethod_0().method_1().method_12()
			.method_12())
		{
			if (breakVal == 104)
			{
				return false;
			}
			if (class5322_0.method_26() % 2 == 0)
			{
				return breakVal == 100;
			}
			return breakVal == 44;
		}
		return true;
	}
}
