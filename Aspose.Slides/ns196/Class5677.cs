using ns171;
using ns173;
using ns174;
using ns176;
using ns184;
using ns187;
using ns205;

namespace ns196;

internal class Class5677
{
	private Class5677()
	{
	}

	public static void smethod_0(Class4942 area, Class5703 bpProps, bool isNotFirst, bool isNotLast, Interface172 context)
	{
		int num = bpProps.method_16(2, isNotFirst, context);
		if (num > 0)
		{
			area.method_29(Class5757.int_14, num);
		}
		num = bpProps.method_16(3, isNotLast, context);
		if (num > 0)
		{
			area.method_29(Class5757.int_15, num);
		}
		num = bpProps.method_16(0, discard: false, context);
		if (num > 0)
		{
			area.method_29(Class5757.int_16, num);
		}
		num = bpProps.method_16(1, discard: false, context);
		if (num > 0)
		{
			area.method_29(Class5757.int_17, num);
		}
		smethod_1(area, bpProps, isNotFirst, 2, Class5705.int_0, Class5757.int_10);
		smethod_1(area, bpProps, isNotLast, 3, Class5705.int_0, Class5757.int_11);
		smethod_1(area, bpProps, discard: false, 0, Class5705.int_0, Class5757.int_12);
		smethod_1(area, bpProps, discard: false, 1, Class5705.int_0, Class5757.int_13);
	}

	private static void smethod_1(Class4942 area, Class5703 bpProps, bool discard, int side, int mode, int trait)
	{
		int num = bpProps.method_12(side, discard);
		if (num > 0)
		{
			area.method_29(trait, new Class5705(bpProps.method_14(side), num, bpProps.method_13(side), mode, bpProps.method_15(side)));
		}
	}

	public static void smethod_2(Class4942 area, Class5703 borderProps, Interface172 context)
	{
		Class5705 @class = smethod_8(borderProps, 0);
		if (@class != null)
		{
			area.method_29(Class5757.int_12, @class);
		}
		@class = smethod_8(borderProps, 1);
		if (@class != null)
		{
			area.method_29(Class5757.int_13, @class);
		}
		@class = smethod_8(borderProps, 2);
		if (@class != null)
		{
			area.method_29(Class5757.int_10, @class);
		}
		@class = smethod_8(borderProps, 3);
		if (@class != null)
		{
			area.method_29(Class5757.int_11, @class);
		}
		smethod_6(area, borderProps, context);
	}

	public static void smethod_3(Class4942 area, Class5703 borderProps, bool discardBefore, bool discardAfter, bool discardStart, bool discardEnd, Interface172 context)
	{
		Class5705 @class = smethod_8(borderProps, 0);
		if (@class != null && !discardBefore)
		{
			area.method_29(Class5757.int_12, @class);
		}
		@class = smethod_8(borderProps, 1);
		if (@class != null && !discardAfter)
		{
			area.method_29(Class5757.int_13, @class);
		}
		@class = smethod_8(borderProps, 2);
		if (@class != null && !discardStart)
		{
			area.method_29(Class5757.int_10, @class);
		}
		@class = smethod_8(borderProps, 3);
		if (@class != null && !discardEnd)
		{
			area.method_29(Class5757.int_11, @class);
		}
	}

	public static void smethod_4(Class4942 area, Class5087 outlineProps, Interface172 context)
	{
		if (outlineProps.method_3() > 0)
		{
			Class5475 prop = new Class5475(outlineProps.method_0(), outlineProps.method_3(), outlineProps.method_1());
			area.method_29(Class5757.int_37, prop);
		}
	}

	public static void smethod_5(Class4942 area, Class5703.Class5704 borderBefore, Class5703.Class5704 borderAfter, Class5703.Class5704 borderStart, Class5703.Class5704 borderEnd, bool[] outer)
	{
		Class5705 @class = smethod_9(borderBefore, outer[0]);
		if (@class != null)
		{
			area.method_29(Class5757.int_12, @class);
		}
		@class = smethod_9(borderAfter, outer[1]);
		if (@class != null)
		{
			area.method_29(Class5757.int_13, @class);
		}
		@class = smethod_9(borderStart, outer[2]);
		if (@class != null)
		{
			area.method_29(Class5757.int_10, @class);
		}
		@class = smethod_9(borderEnd, outer[3]);
		if (@class != null)
		{
			area.method_29(Class5757.int_11, @class);
		}
	}

	private static void smethod_6(Class4942 area, Class5703 bordProps, Interface172 context)
	{
		smethod_7(area, bordProps, discardBefore: false, discardAfter: false, discardStart: false, discardEnd: false, context);
	}

	public static void smethod_7(Class4942 area, Class5703 bordProps, bool discardBefore, bool discardAfter, bool discardStart, bool discardEnd, Interface172 context)
	{
		int num = bordProps.method_16(0, discardBefore, context);
		if (num != 0)
		{
			area.method_29(Class5757.int_16, num);
		}
		num = bordProps.method_16(1, discardAfter, context);
		if (num != 0)
		{
			area.method_29(Class5757.int_17, num);
		}
		num = bordProps.method_16(2, discardStart, context);
		if (num != 0)
		{
			area.method_29(Class5757.int_14, num);
		}
		num = bordProps.method_16(3, discardEnd, context);
		if (num != 0)
		{
			area.method_29(Class5757.int_15, num);
		}
	}

	private static Class5705 smethod_8(Class5703 bordProps, int side)
	{
		int num = bordProps.method_12(side, discard: false);
		if (num != 0)
		{
			return new Class5705(bordProps.method_14(side), num, bordProps.method_13(side), Class5705.int_0, bordProps.method_15(side));
		}
		return null;
	}

	private static Class5705 smethod_9(Class5703.Class5704 borderInfo, bool outer)
	{
		int num = borderInfo.method_3();
		if (num != 0)
		{
			return new Class5705(borderInfo.method_0(), num, borderInfo.method_1(), outer ? Class5705.int_2 : Class5705.int_1, borderInfo.class5702_0);
		}
		return null;
	}

	public static void smethod_10(Class4942 area, Class5703 backProps, Interface172 context, int ipdShift, int bpdShift, int referenceIPD, int referenceBPD)
	{
		if (!backProps.method_20())
		{
			return;
		}
		Class5757.Class5761 @class = new Class5757.Class5761();
		@class.method_6(backProps.color_0);
		@class.bool_0 = backProps.bool_0;
		if (backProps.method_3() != null)
		{
			@class.method_10(backProps.string_0);
			@class.method_11(backProps.method_3());
			@class.method_8(backProps.int_6);
			if (backProps.interface182_0 != null && (@class.method_2() == 96 || @class.method_2() == 114) && area.method_12() > 0)
			{
				Interface172 context2 = new Class5753(context, 9, referenceIPD - @class.method_4().method_2().method_8());
				@class.method_7(ipdShift + backProps.interface182_0.imethod_6(context2));
			}
			if (backProps.interface182_1 != null && (@class.method_2() == 96 || @class.method_2() == 113) && area.vmethod_1() > 0)
			{
				Interface172 context3 = new Class5753(context, 10, referenceBPD - @class.method_4().method_2().method_9());
				@class.method_12(bpdShift + backProps.interface182_1.imethod_6(context3));
			}
		}
		area.method_29(Class5757.int_6, @class);
	}

	public static void smethod_11(Class4942 area, Class5703 backProps, Interface172 context)
	{
		if (!backProps.method_20())
		{
			return;
		}
		Class5757.Class5761 @class = new Class5757.Class5761();
		@class.method_6(backProps.color_0);
		@class.bool_0 = backProps.bool_0;
		if (backProps.method_3() != null)
		{
			@class.method_10(backProps.string_0);
			@class.method_11(backProps.method_3());
			@class.method_8(backProps.int_6);
			if (backProps.interface182_0 != null && (@class.method_2() == 96 || @class.method_2() == 114) && area.method_12() > 0)
			{
				int num = area.method_12();
				num += backProps.method_8(discard: false, context);
				num += backProps.method_9(discard: false, context);
				int num2 = @class.method_4().method_2().method_8();
				int lengthBaseValue = num - num2;
				Class5753 context2 = new Class5753(context, 9, lengthBaseValue);
				int horiz = backProps.interface182_0.imethod_6(context2);
				@class.method_7(horiz);
			}
			if (backProps.interface182_1 != null && (@class.method_2() == 96 || @class.method_2() == 113) && area.vmethod_1() > 0)
			{
				int num3 = area.vmethod_1();
				num3 += backProps.method_10(discard: false, context);
				num3 += backProps.method_11(discard: false, context);
				int num4 = @class.method_4().method_2().method_9();
				int lengthBaseValue2 = num3 - num4;
				Class5753 context3 = new Class5753(context, 10, lengthBaseValue2);
				int vertical = backProps.interface182_1.imethod_6(context3);
				@class.method_12(vertical);
			}
		}
		area.method_29(Class5757.int_6, @class);
	}

	public static void smethod_12(Class4942 area, Class5703 bpProps, int startIndent, int endIndent, Interface172 context)
	{
		if (startIndent != 0)
		{
			area.method_29(Class5757.int_20, startIndent);
		}
		int num = startIndent - bpProps.method_4(discard: false) - bpProps.method_8(discard: false, context);
		if (num != 0)
		{
			area.method_29(Class5757.int_18, num);
		}
		if (endIndent != 0)
		{
			area.method_29(Class5757.int_21, endIndent);
		}
		int num2 = endIndent - bpProps.method_5(discard: false) - bpProps.method_9(discard: false, context);
		if (num2 != 0)
		{
			area.method_29(Class5757.int_19, num2);
		}
	}

	public static void smethod_13(Class4942 area, Class5703 bpProps, Class5718 marginProps, Interface172 context)
	{
		int startIndent = marginProps.interface182_4.imethod_6(context);
		int endIndent = marginProps.interface182_5.imethod_6(context);
		smethod_12(area, bpProps, startIndent, endIndent, context);
	}

	public static int smethod_14(double adjust, Class5746 space)
	{
		if (space == null)
		{
			return 0;
		}
		int num = space.method_2();
		if (adjust > 0.0)
		{
			return num + (int)(adjust * (double)space.method_5());
		}
		return num + (int)(adjust * (double)space.method_4());
	}

	public static void smethod_15(Class4942 area, double adjust, Class5746 spaceBefore, Class5746 spaceAfter)
	{
		smethod_16(area, Class5757.int_22, spaceBefore, adjust);
		smethod_16(area, Class5757.int_23, spaceAfter, adjust);
	}

	private static void smethod_16(Class4942 area, int spaceTrait, Class5746 space, double adjust)
	{
		int num = smethod_14(adjust, space);
		if (num != 0)
		{
			area.method_29(spaceTrait, num);
		}
	}

	public static void smethod_17(Class4942 area, int breakBefore, int breakAfter)
	{
	}

	public static void smethod_18(Class4942 area, Class5729 font)
	{
		area.method_29(Class5757.int_2, font.method_5());
		area.method_29(Class5757.int_3, font.method_6());
	}

	public static void smethod_19(Class4942 area, Class5720 deco)
	{
		if (deco != null)
		{
			if (deco.method_0())
			{
				area.method_29(Class5757.int_7, true);
				area.method_29(Class5757.int_27, deco.method_4());
			}
			if (deco.method_1())
			{
				area.method_29(Class5757.int_8, true);
				area.method_29(Class5757.int_28, deco.method_5());
			}
			if (deco.method_2())
			{
				area.method_29(Class5757.int_9, true);
				area.method_29(Class5757.int_29, deco.method_6());
			}
			if (deco.method_3())
			{
				area.method_29(Class5757.int_26, true);
			}
		}
	}

	public static void smethod_20(Class4942 area, Interface244 structureTreeElement)
	{
		if (structureTreeElement != null)
		{
			area.method_29(Class5757.int_30, structureTreeElement);
		}
	}

	public static void smethod_21(Class4942 area, string id)
	{
		if (id != null && id.Length > 0)
		{
			area.method_29(Class5757.int_5, id);
		}
	}

	public static void smethod_22(Class4942 area, Interface181 zIndex)
	{
		if (zIndex != null)
		{
			area.method_29(Class5757.int_36, zIndex);
		}
	}

	public static void smethod_23(Class4942 area, Class5024 controlType)
	{
		if (controlType != null && controlType.imethod_0() != 95)
		{
			area.method_29(Class5757.int_39, controlType.imethod_0());
		}
	}

	public static void smethod_24(Class4942 area, Interface181 controlPart)
	{
		if (controlPart != null)
		{
			area.method_29(Class5757.int_40, controlPart);
		}
	}

	public static void smethod_25(Class4942 area, int widht)
	{
		area.method_29(Class5757.int_41, widht);
	}

	public static void smethod_26(Class4942 area, int height)
	{
		area.method_29(Class5757.int_42, height);
	}

	public static void smethod_27(Class4942 area, Class5024 value)
	{
		if (value != null && value.imethod_0() == 149)
		{
			area.method_29(Class5757.int_43, Enum679.const_236);
		}
	}

	public static void smethod_28(Class4942 area, Class5024 selected)
	{
		if (selected != null && selected.imethod_0() == 149)
		{
			area.method_29(Class5757.int_44, Enum679.const_236);
		}
	}

	public static void smethod_29(Class4942 area, int visibility)
	{
		if (visibility != 0)
		{
			area.method_29(Class5757.int_38, new Class5442(visibility));
		}
	}
}
