using System;
using System.Collections;
using ns198;
using ns205;

namespace ns196;

internal class Class5687
{
	public const int int_0 = 1;

	public const int int_1 = 2;

	public const int int_2 = 4;

	public const int int_3 = 8;

	public const int int_4 = 16;

	public const int int_5 = 32;

	public const int int_6 = 64;

	public const int int_7 = 128;

	public const int int_8 = 256;

	private int int_9;

	private Class5746 class5746_0;

	private int int_10;

	private int int_11;

	private int int_12;

	private Class5445 class5445_0 = Class5445.class5445_0;

	private Class5696 class5696_0;

	private Class5696 class5696_1;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private Class5685 class5685_0;

	private int int_13 = 135;

	private double double_0;

	private double double_1;

	private Class5684 class5684_0;

	private int int_14;

	private int int_15;

	private int int_16;

	private int int_17;

	private int int_18;

	private int int_19;

	private Class5686 class5686_0 = Class5686.class5686_0;

	private Class5686 class5686_1 = Class5686.class5686_0;

	private int int_20;

	private Class5746 class5746_1 = Class5746.class5746_0;

	public Class5687(Class5687 parentLC)
	{
		int_9 = parentLC.int_9;
		int_12 = parentLC.int_12;
		class5445_0 = parentLC.class5445_0;
		method_28(parentLC.method_29());
		class5696_1 = parentLC.class5696_1;
		class5696_0 = parentLC.class5696_0;
		class5685_0 = parentLC.class5685_0;
		int_13 = parentLC.int_13;
		double_1 = parentLC.double_1;
		double_0 = parentLC.double_0;
		class5684_0 = parentLC.class5684_0;
		int_16 = parentLC.int_16;
		int_17 = parentLC.int_17;
		method_0(parentLC);
		class5686_0 = parentLC.class5686_0;
		class5686_1 = parentLC.class5686_1;
		int_20 = parentLC.int_20;
	}

	public Class5687(int flags)
	{
		int_9 = flags;
		int_12 = 0;
		class5746_0 = Class5746.class5746_0;
		class5696_1 = null;
		class5696_0 = null;
	}

	public void method_0(Class5687 source)
	{
		if (source.arrayList_0 != null)
		{
			arrayList_0 = new ArrayList(source.arrayList_0);
		}
		if (source.arrayList_1 != null)
		{
			arrayList_1 = new ArrayList(source.arrayList_1);
		}
	}

	public void method_1(int flags)
	{
		method_2(flags, bSet: true);
	}

	public void method_2(int flags, bool bSet)
	{
		if (bSet)
		{
			int_9 |= flags;
		}
		else
		{
			int_9 &= ~flags;
		}
	}

	public void method_3(int flags)
	{
		method_2(flags, bSet: false);
	}

	public bool method_4()
	{
		return (int_9 & 2) != 0;
	}

	public bool method_5()
	{
		if (((uint)int_9 & 2u) != 0)
		{
			return class5696_1 != null;
		}
		return false;
	}

	public bool method_6()
	{
		return (int_9 & 0x20) != 0;
	}

	public bool method_7()
	{
		return (int_9 & 0x80) != 0;
	}

	public bool method_8()
	{
		return (int_9 & 0x10) != 0;
	}

	public Class5686 method_9()
	{
		return class5686_0;
	}

	public Class5686 method_10()
	{
		return class5686_1;
	}

	public void method_11()
	{
		class5686_0 = Class5686.class5686_0;
	}

	public void method_12()
	{
		class5686_1 = Class5686.class5686_0;
	}

	public void method_13()
	{
		method_12();
		method_11();
	}

	public void method_14(Class5686 keep)
	{
		class5686_0 = class5686_0.method_4(keep);
	}

	public void method_15(Class5686 keep)
	{
		class5686_1 = class5686_1.method_4(keep);
	}

	public bool method_16()
	{
		return !method_9().method_1();
	}

	public bool method_17()
	{
		return !method_10().method_1();
	}

	public void method_18(Class5696 space)
	{
		class5696_1 = space;
	}

	public Class5696 method_19()
	{
		return class5696_1;
	}

	public bool method_20()
	{
		return (int_9 & 0x100) != 0;
	}

	public void method_21(Class5696 space)
	{
		class5696_0 = space;
	}

	public Class5696 method_22()
	{
		return class5696_0;
	}

	public void method_23(Class5330 element)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(element);
	}

	public ArrayList method_24()
	{
		if (arrayList_0 != null)
		{
			return arrayList_0;
		}
		return null;
	}

	public void method_25()
	{
		arrayList_1 = null;
		arrayList_0 = null;
	}

	public void method_26(Class5330 element)
	{
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
		}
		arrayList_1.Add(element);
	}

	public ArrayList method_27()
	{
		if (arrayList_1 != null)
		{
			return arrayList_1;
		}
		return null;
	}

	public void method_28(Class5746 limit)
	{
		class5746_0 = limit;
	}

	public Class5746 method_29()
	{
		return class5746_0;
	}

	public void method_30(int ipd)
	{
		int_12 = ipd;
	}

	public int method_31()
	{
		return int_12;
	}

	public void method_32(Class5685 hyph)
	{
		class5685_0 = hyph;
	}

	public Class5685 method_33()
	{
		return class5685_0;
	}

	public bool method_34()
	{
		return (int_9 & 0x40) != 0;
	}

	public void method_35(int alignment)
	{
		int_13 = alignment;
	}

	public int method_36()
	{
		return int_13;
	}

	public void method_37(double adjust)
	{
		double_1 = adjust;
	}

	public double method_38()
	{
		return double_1;
	}

	public void method_39(double ipdA)
	{
		double_0 = ipdA;
	}

	public double method_40()
	{
		return double_0;
	}

	public void method_41(Class5684 alignmentContext)
	{
		class5684_0 = alignmentContext;
	}

	public Class5684 method_42()
	{
		return class5684_0;
	}

	public void method_43()
	{
		if (class5684_0 != null)
		{
			class5684_0 = class5684_0.method_8();
		}
	}

	public int method_44()
	{
		return int_16;
	}

	public void method_45(int lineStartBorderAndPaddingWidth)
	{
		int_16 = lineStartBorderAndPaddingWidth;
	}

	public int method_46()
	{
		return int_17;
	}

	public void method_47(int lineEndBorderAndPaddingWidth)
	{
		int_17 = lineEndBorderAndPaddingWidth;
	}

	public int method_48()
	{
		return int_11;
	}

	public int method_49()
	{
		if (int_10 != 0)
		{
			return int_10;
		}
		return 95;
	}

	public void method_50(int span)
	{
		if (span != 0 && span != 5 && span != 95)
		{
			throw new ArgumentException("Illegal value on signalSpanChange() for span: " + span);
		}
		int_10 = int_11;
		int_11 = span;
	}

	public Class5445 method_51()
	{
		return class5445_0;
	}

	public void method_52(Class5445 writingMode)
	{
		class5445_0 = writingMode;
	}

	public int method_53()
	{
		return int_14;
	}

	public void method_54(int spaceBefore)
	{
		int_14 = spaceBefore;
	}

	public int method_55()
	{
		return int_15;
	}

	public void method_56(int spaceAfter)
	{
		int_15 = spaceAfter;
	}

	public int method_57()
	{
		return int_18;
	}

	public void method_58(int breakBefore)
	{
		int_18 = breakBefore;
	}

	public int method_59()
	{
		return int_19;
	}

	public void method_60(int breakAfter)
	{
		int_19 = breakAfter;
	}

	public override string ToString()
	{
		return string.Concat("Layout Context:\nStack Limit BPD: \t", (method_29() == null) ? "null" : method_29().ToString(), "\nTrailing Space: \t", (method_22() == null) ? "null" : method_22().ToString(), "\nLeading Space: \t", (method_19() == null) ? "null" : method_19().ToString(), "\nReference IPD: \t", method_31(), "\nSpace Adjust: \t", method_38(), "\nIPD Adjust: \t", method_40(), "\nResolve Leading Space: \t", method_20(), "\nSuppress Break Before: \t", method_8(), "\nIs First Area: \t", method_6(), "\nStarts New Area: \t", method_5(), "\nIs Last Area: \t", method_7(), "\nTry Hyphenate: \t", method_34(), "\nKeeps: \t[keep-with-next=", method_9(), "][keep-with-previous=", method_10(), "] pending\nBreaks: \tforced [", (int_18 != 9) ? "break-before" : string.Empty, "][", (int_19 != 9) ? "break-after" : string.Empty, "]");
	}

	public int method_61()
	{
		return int_20;
	}

	public void method_62(int disableColumnBalancing)
	{
		int_20 = disableColumnBalancing;
	}

	public Class5746 method_63()
	{
		return class5746_1;
	}

	public void method_64(Class5746 range)
	{
		class5746_1 = range;
	}
}
