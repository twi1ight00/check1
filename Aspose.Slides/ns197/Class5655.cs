using System;
using System.Collections;
using ns173;
using ns183;
using ns187;
using ns192;
using ns196;

namespace ns197;

internal class Class5655
{
	private int int_0;

	private int int_1;

	private Class5645 class5645_0;

	private Class5687 class5687_0;

	private int int_2;

	private int int_3;

	private ArrayList arrayList_0 = new ArrayList();

	private int[] int_4;

	private bool[] bool_0;

	private Class5649[] class5649_0;

	private Class5649[] class5649_1;

	private int int_5;

	private Class5703 class5703_0;

	private ArrayList arrayList_1;

	private Class5674 class5674_0;

	internal Class5655(Class5674 tclm, Class5687 layoutContext)
	{
		class5674_0 = tclm;
		class5687_0 = layoutContext;
		int_0 = tclm.method_2().method_2();
		int_4 = new int[int_0];
		bool_0 = new bool[int_0];
		class5649_0 = new Class5649[int_0];
		class5649_1 = new Class5649[int_0];
		int_2 = -1;
		int_3 = -1;
	}

	internal void method_0(Class5151 tablePart)
	{
		Class5703 @class = tablePart.vmethod_33();
		if (@class.method_20())
		{
			class5703_0 = @class;
			if (arrayList_1 == null)
			{
				arrayList_1 = new ArrayList();
			}
		}
		int_5 = int_1;
	}

	internal void method_1(bool lastInBody, bool lastOnPage)
	{
		method_4(lastInBody, lastOnPage);
		if (class5703_0 != null)
		{
			Class5287 @class = class5674_0.method_0();
			Interface208 @interface = new Class5495(arrayList_1);
			while (@interface.imethod_0())
			{
				Class4962 class2 = (Class4962)@interface.imethod_1();
				Class5677.smethod_10(class2, class5703_0, @class, -class2.method_40(), int_5 - class2.method_41(), @class.imethod_16(), int_1 - int_5);
			}
			class5703_0 = null;
			arrayList_1.Clear();
		}
	}

	internal int method_2()
	{
		return int_1;
	}

	internal void method_3(Class5265 tcpos)
	{
		if (class5645_0 == null)
		{
			class5645_0 = tcpos.method_7();
		}
		else
		{
			Class5645 @class = tcpos.method_8();
			if (@class.method_0() > class5645_0.method_0())
			{
				method_4(lastInPart: false, lastOnPage: false);
				class5645_0 = @class;
			}
		}
		if (int_2 < 0)
		{
			int_2 = class5645_0.method_0();
			if (int_3 < 0)
			{
				int_3 = int_2;
			}
		}
		Interface208 @interface = new Class5495(tcpos.arrayList_0);
		while (@interface.imethod_0())
		{
			Class5649 class2 = (Class5649)@interface.imethod_1();
			int num = class2.class5631_0.method_32();
			if (class5649_0[num] == null)
			{
				class5649_0[num] = class2;
				int_4[num] = class2.method_2(bool_0[num]);
			}
			else
			{
				int_4[num] += class2.method_4();
			}
			int_4[num] += class2.method_5();
			class5649_1[num] = class2;
		}
	}

	private void method_4(bool lastInPart, bool lastOnPage)
	{
		method_8(class5645_0.method_0(), int_1);
		bool flag = true;
		bool flag2 = true;
		int num = 0;
		for (int i = 0; i < int_0; i++)
		{
			Class5630 @class = class5645_0.method_8(i);
			if (!@class.method_4())
			{
				if (@class.method_6() == 0 && (lastInPart || @class.vmethod_4()) && class5649_0[i] != null)
				{
					int num2 = int_4[i];
					num2 += class5649_1[i].method_6();
					num2 += class5649_1[i].method_3(lastInPart);
					int num3 = method_9(Math.Max(class5649_0[i].class5631_0.method_31(), int_2));
					num = Math.Max(num, num3 + num2 - int_1);
				}
				if (class5649_0[i] != null && !class5649_0[i].method_0())
				{
					flag = false;
				}
				if (class5649_1[i] != null && !class5649_1[i].method_1())
				{
					flag2 = false;
				}
			}
		}
		Class4962 class2 = new Class4962();
		Class5287 class3 = class5674_0.method_0();
		Class5155 class4 = class5645_0.method_2();
		if (class4 != null)
		{
			Class5677.smethod_21(class2, class4.vmethod_31());
		}
		Class4962 class4962_ = class3.class4962_0;
		class4962_.vmethod_2(class2);
		class3.class4962_0 = class2;
		class2.method_11(class3.imethod_16());
		for (int j = 0; j < int_0; j++)
		{
			Class5630 class5 = class5645_0.method_8(j);
			if (class5.method_4() && !class5674_0.method_1())
			{
				int borderBeforeWhich = ((!flag) ? 2 : (bool_0[j] ? 1 : 0));
				int borderAfterWhich = ((!flag2) ? 2 : (lastInPart ? 1 : 0));
				method_6((Class5632)class5, class5645_0.method_0(), j, num, borderBeforeWhich, borderAfterWhich, lastOnPage);
				bool_0[j] = false;
			}
			else if (class5.method_6() == 0 && (lastInPart || class5.vmethod_4()) && class5649_0[j] != null)
			{
				method_5(borderBeforeWhich: (!class5649_0[j].method_0()) ? 2 : (bool_0[j] ? 1 : 0), borderAfterWhich: (!class5649_1[j].method_1()) ? 2 : (lastInPart ? 1 : 0), pgu: class5649_0[j].class5631_0, startPos: class5649_0[j].int_0, endPos: class5649_1[j].int_1, rowHeight: num, lastOnPage: lastOnPage);
				class5649_0[j] = null;
				for (int k = j; k < j + class5.method_1().method_53(); k++)
				{
					bool_0[k] = false;
				}
			}
		}
		class2.method_13(num);
		class2.method_44(2);
		class3.class4962_0 = class4962_;
		int_1 += num;
		if (lastInPart)
		{
			class5645_0 = null;
			int_2 = -1;
			arrayList_0.Clear();
			int_3 = int.MaxValue;
		}
	}

	private static int smethod_0(Class5631 pgu, int startIndex, int endIndex)
	{
		if (startIndex > endIndex)
		{
			return 0;
		}
		Interface168 @interface = new Class5495(pgu.method_22(), startIndex);
		bool flag = false;
		while (@interface.imethod_4() <= endIndex && !flag)
		{
			flag = ((Class5337)@interface.imethod_1()).vmethod_0();
		}
		int num = 0;
		if (((Class5337)@interface.imethod_3()).vmethod_0())
		{
			while (@interface.imethod_4() < endIndex)
			{
				Class5337 @class = (Class5337)@interface.imethod_1();
				if (@class.vmethod_0() || @class.vmethod_1())
				{
					num += @class.method_4();
				}
			}
			num += Class5646.smethod_0((Class5337)@interface.imethod_1());
		}
		return num;
	}

	private void method_5(Class5631 pgu, int startPos, int endPos, int rowHeight, int borderBeforeWhich, int borderAfterWhich, bool lastOnPage)
	{
		int num = class5645_0.method_0();
		int num2;
		int firstRowHeight;
		if (pgu.method_31() >= int_2)
		{
			num2 = pgu.method_31();
			firstRowHeight = ((num2 >= num) ? rowHeight : (method_9(num2 + 1) - method_9(num2)));
		}
		else
		{
			num2 = int_2;
			firstRowHeight = 0;
		}
		int[] array = null;
		if (!class5674_0.method_0().method_53().method_72() && pgu.method_34())
		{
			array = new int[num - num2 + 1];
			int num3 = method_9(num2);
			for (int i = 0; i < num - num2; i++)
			{
				int num4 = method_9(num2 + i + 1);
				array[i] = num4 - num3;
				num3 = num4;
			}
			array[num - num2] = rowHeight;
		}
		int num5 = method_9(num2);
		int h = rowHeight + int_1 - num5;
		Class5296 @class = pgu.method_20();
		@class.method_58(class5674_0.method_14(pgu));
		@class.method_57(num5);
		@class.method_59(smethod_0(pgu, startPos, endPos));
		@class.method_60(h);
		int prevBreak = Class5683.smethod_9(pgu.method_22(), startPos);
		if (endPos >= 0)
		{
			Class5644.smethod_7(pgu.method_22(), startPos, endPos, prevBreak);
		}
		@class.method_61(new Class5653(pgu.method_22(), startPos, endPos + 1), class5687_0, array, num2 - pgu.method_31(), num - pgu.method_31(), borderBeforeWhich, borderAfterWhich, num2 == int_3, lastOnPage, this, firstRowHeight);
	}

	private void method_6(Class5632 gu, int rowIndex, int colIndex, int actualRowHeight, int borderBeforeWhich, int borderAfterWhich, bool lastOnPage)
	{
		Class5703.Class5704 @class = gu.method_7(borderBeforeWhich);
		Class5703.Class5704 class2 = gu.method_8(borderAfterWhich);
		Class5703.Class5704 class3 = gu.method_9();
		Class5703.Class5704 class4 = gu.method_10();
		if (@class.method_3() != 0 || class2.method_3() != 0 || class3.method_3() != 0 || class4.method_3() != 0)
		{
			Class5287 class5 = class5674_0.method_0();
			Class5156 class6 = class5.method_53();
			Class5158 class7 = class5674_0.method_2().method_1(colIndex + 1);
			bool flag = rowIndex == int_3;
			bool flag2 = colIndex == 0;
			bool flag3 = colIndex == class6.method_59() - 1;
			int num = class7.method_52().imethod_6(class5);
			num -= (class3.method_3() + class4.method_3()) / 2;
			int num2 = actualRowHeight;
			num2 -= (@class.method_3() + class2.method_3()) / 2;
			Class4962 class8 = new Class4962();
			class8.method_44(2);
			class8.method_29(Class5757.int_24, true);
			class8.method_11(num);
			class8.method_13(num2);
			class8.method_38(class5674_0.method_15(colIndex) + class3.method_3() / 2, leftAuto: false, rightAuto: false);
			class8.method_39(method_9(rowIndex) - @class.method_3() / 2, topAuto: false, bottomAuto: false);
			bool[] outer = new bool[4] { flag, lastOnPage, flag2, flag3 };
			Class5677.smethod_5(class8, @class, class2, class3, class4, outer);
			class5.imethod_8(class8);
		}
	}

	internal void method_7(Class4962 backgroundArea)
	{
		class5674_0.method_0().method_60(backgroundArea);
		arrayList_1.Add(backgroundArea);
	}

	private void method_8(int rowIndex, int offset)
	{
		for (int i = arrayList_0.Count; i <= rowIndex - int_2; i++)
		{
			arrayList_0.Add(offset);
		}
	}

	private int method_9(int rowIndex)
	{
		return (int)arrayList_0[rowIndex - int_2];
	}

	internal void method_10()
	{
		for (int i = 0; i < bool_0.Length; i++)
		{
			bool_0[i] = true;
		}
	}

	internal void method_11()
	{
		for (int i = 0; i < bool_0.Length; i++)
		{
			bool_0[i] = false;
		}
	}
}
