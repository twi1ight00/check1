using System.Collections;
using System.Collections.Generic;
using ns171;
using ns173;
using ns176;
using ns187;
using ns192;
using ns195;
using ns196;
using ns198;
using ns205;

namespace ns197;

internal class Class5296 : Class5281, Interface172, Interface173, Interface174
{
	internal Class5631 class5631_0;

	private Class4962 class4962_0;

	private int int_10;

	private int int_11;

	private int int_12;

	private int int_13;

	private int int_14;

	private bool bool_5 = true;

	private Class5746 class5746_0;

	public Class5296(Class5157 node, Class5631 pgu)
		: base(node)
	{
		class5631_0 = pgu;
		bool_5 = method_53().method_28();
		if (!bool_5)
		{
			return;
		}
		Class5088 @class = method_53().vmethod_15().imethod_12();
		Class5088.Interface163 @interface = @class.vmethod_15();
		if (@interface == null || !@interface.imethod_0())
		{
			return;
		}
		if (@interface.imethod_1() is Class5172 class2)
		{
			Class5656 class3 = class2.vmethod_17();
			char c;
			do
			{
				if (class3.imethod_0())
				{
					c = class3.vmethod_0();
					continue;
				}
				return;
			}
			while (c != '\n' && c != '\r' && c != '\t' && c != '\u00a0');
			bool_5 = false;
		}
		else
		{
			bool_5 = false;
		}
	}

	public Class5157 method_53()
	{
		return (Class5157)class5094_0;
	}

	private bool method_54()
	{
		return method_55().method_72();
	}

	public Class5156 method_55()
	{
		return method_53().vmethod_32();
	}

	public int method_56()
	{
		return int_5;
	}

	public new bool imethod_25()
	{
		Class5156 @class = method_55();
		if (@class.method_56())
		{
			int index = class5631_0.method_32();
			Class5158 class2 = @class.method_58(index);
			return class2.method_63();
		}
		return false;
	}

	internal override int vmethod_7()
	{
		int[] array = class5631_0.method_33();
		int_6 = array[0];
		int_7 = array[1];
		if (method_54())
		{
			int num = method_55().method_73().vmethod_4().method_3()
				.vmethod_0()
				.imethod_6(this);
			int_6 += num / 2;
			int_7 += num / 2;
		}
		else
		{
			int_6 /= 2;
			int_7 /= 2;
		}
		int_6 += method_53().vmethod_33().method_8(discard: false, this);
		int_7 += method_53().vmethod_33().method_9(discard: false, this);
		return int_6 + int_7;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		List<Class5298> list = Class5326.Instance.method_1(this);
		if (list != null)
		{
			foreach (Class5298 item in list)
			{
				if (item.BodyLm != null)
				{
					item.BodyLm.method_65();
				}
			}
		}
		Class5746 operand = context.method_29();
		int_5 = context.method_31();
		int_12 = int_5;
		if (int_12 != 0)
		{
			int_12 -= vmethod_7();
		}
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		Interface173 @interface = null;
		Interface173 interface2;
		ArrayList arrayList3;
		while ((interface2 = method_9()) != null)
		{
			Class5687 @class = new Class5687(0);
			@class.method_28(context.method_29().method_8(operand));
			@class.method_30(int_12);
			arrayList3 = interface2.imethod_14(@class, alignment);
			int num = @class.method_31() + vmethod_7();
			class5746_0 = @class.method_63().method_7(vmethod_7());
			if (method_56() < num && imethod_25())
			{
				int_5 = num;
				int_12 = method_56() - vmethod_7();
			}
			@class.method_16();
			if (arrayList.Count == 0 && @class.method_17())
			{
				class5631_0.method_37(@class.method_10());
				@class.method_12();
			}
			if (@interface != null && !Class5683.smethod_6(arrayList))
			{
				method_37(arrayList, context, @class);
			}
			Class5693.smethod_2(arrayList, arrayList3);
			if (arrayList3.Count != 0)
			{
				if (@class.method_16())
				{
					context.method_14(@class.method_9());
					@class.method_11();
				}
				@interface = interface2;
			}
		}
		class5631_0.method_39(context.method_9());
		arrayList3 = new ArrayList();
		if (arrayList.Count != 0)
		{
			method_50(arrayList, arrayList2);
		}
		else
		{
			arrayList2.Add(new Class5338(0, imethod_22(new Class5254(this)), auxiliary: true));
		}
		Class5644.smethod_6(arrayList2);
		if (((Class5337)arrayList2[0]).vmethod_3())
		{
			class5631_0.method_41(((Class5342)arrayList2[0]).method_8());
			arrayList2.Remove(0);
		}
		Class5337 class2 = (Class5337)Class5693.smethod_0(arrayList2);
		if (class2.vmethod_3())
		{
			Class5342 class3 = (Class5342)class2;
			class5631_0.method_43(class3.method_8());
			class3.method_6(0);
		}
		imethod_6(fin: true);
		return arrayList2;
	}

	public void method_57(int off)
	{
		int_11 = off;
	}

	public void method_58(int off)
	{
		int_10 = off;
	}

	public void method_59(int h)
	{
		int_14 = h;
	}

	public void method_60(int h)
	{
		int_13 = h;
	}

	public void method_61(Class5652 parentIter, Class5687 layoutContext, int[] spannedGridRowHeights, int startRow, int endRow, int borderBeforeWhich, int borderAfterWhich, bool firstOnPage, bool lastOnPage, Class5655 painter, int firstRowHeight)
	{
		imethod_7(null);
		vmethod_1();
		int num = class5631_0.method_24(startRow, borderBeforeWhich);
		int num2 = class5631_0.method_25(endRow, borderAfterWhich);
		Class5703 @class = class5631_0.method_1().vmethod_33();
		int num3 = int_13 - num - num2;
		int num4 = num3;
		num4 -= @class.method_10(borderBeforeWhich == 2, this);
		num4 -= @class.method_11(borderAfterWhich == 2, this);
		method_62(painter, firstRowHeight, num, num3);
		if (method_54())
		{
			if (!bool_5 || method_53().method_52())
			{
				if (num > 0)
				{
					int amount = method_53().vmethod_32().method_73().method_4()
						.vmethod_0()
						.imethod_5() / 2;
					smethod_3(class4962_0, amount);
				}
				Class5677.smethod_3(class4962_0, method_53().vmethod_33(), num == 0, num2 == 0, discardStart: false, discardEnd: false, this);
			}
		}
		else
		{
			bool flag = class5631_0.method_32() == 0;
			bool flag2 = class5631_0.method_32() + method_53().method_53() == method_55().method_59();
			if (!class5631_0.method_34())
			{
				smethod_3(class4962_0, -num);
				bool[] outer = new bool[4] { firstOnPage, lastOnPage, flag, flag2 };
				Class5677.smethod_5(class4962_0, class5631_0.method_7(borderBeforeWhich), class5631_0.method_8(borderAfterWhich), class5631_0.method_9(), class5631_0.method_10(), outer);
			}
			else
			{
				smethod_3(class4962_0, num);
				Class4962[][] array = new Class4962[method_53().method_54()][];
				for (int i = 0; i < method_53().method_54(); i++)
				{
					array[i] = new Class4962[method_53().method_53()];
				}
				Class5630[] array2 = (Class5630[])class5631_0.method_28()[startRow];
				for (int j = 0; j < method_53().method_53(); j++)
				{
					Class5630 class2 = array2[j];
					Class5703.Class5704 class3 = class2.method_7(borderBeforeWhich);
					int num5 = class3.method_3() / 2;
					if (num5 > 0)
					{
						smethod_1(array, startRow, j, Class5757.int_12, class3, firstOnPage);
						smethod_3(array[startRow][j], -num5);
						smethod_5(array[startRow][j], -num5);
					}
				}
				array2 = (Class5630[])class5631_0.method_28()[endRow];
				for (int k = 0; k < method_53().method_53(); k++)
				{
					Class5630 class4 = array2[k];
					Class5703.Class5704 class5 = class4.method_8(borderAfterWhich);
					int num6 = class5.method_3() / 2;
					if (num6 > 0)
					{
						smethod_1(array, endRow, k, Class5757.int_13, class5, lastOnPage);
						smethod_5(array[endRow][k], -num6);
					}
				}
				for (int l = startRow; l <= endRow; l++)
				{
					array2 = (Class5630[])class5631_0.method_28()[l];
					Class5703.Class5704 class6 = array2[0].method_9();
					int num7 = class6.method_3() / 2;
					if (num7 > 0)
					{
						smethod_1(array, l, 0, Class5757.int_10, class6, flag);
						smethod_2(array[l][0], num7);
						smethod_4(array[l][0], -num7);
					}
					class6 = array2[array2.Length - 1].method_10();
					num7 = class6.method_3() / 2;
					if (num7 > 0)
					{
						smethod_1(array, l, array2.Length - 1, Class5757.int_11, class6, flag2);
						smethod_4(array[l][array2.Length - 1], -num7);
					}
				}
				int num8 = int_11;
				for (int m = startRow; m <= endRow; m++)
				{
					int num9 = spannedGridRowHeights[m - startRow];
					int num10 = int_10;
					for (int n = 0; n < array2.Length; n++)
					{
						int num11 = method_55().method_58(class5631_0.method_32() + n).method_52().imethod_6(imethod_2());
						if (array[m][n] != null)
						{
							Class4962 class7 = array[m][n];
							smethod_3(class7, num8);
							smethod_2(class7, num10);
							smethod_4(class7, num11);
							smethod_5(class7, num9);
							interface173_0.imethod_8(class7);
						}
						num10 += num11;
					}
					num8 += num9;
				}
			}
		}
		Class5677.smethod_7(class4962_0, @class, borderBeforeWhich == 2, borderAfterWhich == 2, discardStart: false, discardEnd: false, this);
		if (int_14 < num4)
		{
			if (method_53().method_56() == 23)
			{
				Class4962 class8 = new Class4962();
				class8.method_13((num4 - int_14) / 2);
				class4962_0.vmethod_5(class8);
			}
			else if (method_53().method_56() == 3)
			{
				Class4962 class9 = new Class4962();
				class9.method_13(num4 - int_14);
				class4962_0.vmethod_5(class9);
			}
		}
		Class5648.smethod_0(this, parentIter, layoutContext);
		class4962_0.method_13(num4);
		if (!method_54() || !bool_5 || method_53().method_52())
		{
			Class5677.smethod_11(class4962_0, method_53().vmethod_33(), this);
		}
		vmethod_2();
		class4962_0 = null;
		method_22();
	}

	private void method_62(Class5655 painter, int firstRowHeight, int borderBeforeWidth, int paddingRectBPD)
	{
		Class5158 @class = method_55().method_58(class5631_0.method_32());
		if (@class.vmethod_33().method_20())
		{
			Class4962 backgroundArea = method_63(paddingRectBPD, borderBeforeWidth);
			((Class5287)interface173_0).method_59(@class, backgroundArea, -int_6);
		}
		Class5151 class2 = class5631_0.method_19();
		if (class2.vmethod_33().method_20())
		{
			painter.method_7(method_63(paddingRectBPD, borderBeforeWidth));
		}
		Class5155 class3 = class5631_0.method_2();
		if (class3 != null && class3.vmethod_33().method_20())
		{
			Class4962 class4 = method_63(paddingRectBPD, borderBeforeWidth);
			((Class5287)interface173_0).method_60(class4);
			Class5677.smethod_10(class4, class3.vmethod_33(), interface173_0, -int_10 - int_6, -borderBeforeWidth, interface173_0.imethod_16(), firstRowHeight);
		}
	}

	private static void smethod_1(Class4962[][] blocks, int i, int j, int side, Class5703.Class5704 border, bool outer)
	{
		if (blocks[i][j] == null)
		{
			blocks[i][j] = new Class4962();
			blocks[i][j].method_29(Class5757.int_24, true);
			blocks[i][j].method_44(2);
		}
		blocks[i][j].method_29(side, new Class5705(border.method_0(), border.method_3(), border.method_1(), outer ? Class5705.int_2 : Class5705.int_1, border.class5702_0));
	}

	private static void smethod_2(Class4962 block, int amount)
	{
		block.method_38(block.method_40() + amount, leftAuto: false, rightAuto: false);
	}

	private static void smethod_3(Class4962 block, int amount)
	{
		block.method_39(block.method_41() + amount, topAuto: false, bottomAuto: false);
	}

	private static void smethod_4(Class4962 block, int amount)
	{
		block.method_11(block.method_12() + amount);
	}

	private static void smethod_5(Class4962 block, int amount)
	{
		block.method_13(block.vmethod_1() + amount);
	}

	private Class4962 method_63(int bpd, int borderBeforeWidth)
	{
		Class5703 @class = method_53().vmethod_33();
		int num = @class.method_8(discard: false, this);
		int num2 = @class.method_9(discard: false, this);
		Class4962 class2 = new Class4962();
		Class5677.smethod_21(class2, method_55().vmethod_31());
		class2.method_44(2);
		class2.method_11(int_12 + num + num2);
		class2.method_13(bpd);
		class2.method_38(int_10 + int_6 - num, leftAuto: false, rightAuto: false);
		class2.method_39(int_11 + borderBeforeWidth, topAuto: false, bottomAuto: false);
		return class2;
	}

	public override Class4942 imethod_7(Class4942 childArea)
	{
		if (class4962_0 == null)
		{
			class4962_0 = new Class4962();
			class4962_0.method_29(Class5757.int_24, true);
			Class5677.smethod_21(class4962_0, method_53().vmethod_31());
			class4962_0.method_44(2);
			class4962_0.method_38(int_10 + int_6, leftAuto: false, rightAuto: false);
			class4962_0.method_39(int_11, topAuto: false, bottomAuto: false);
			Class5156 @class = method_55();
			if (@class.method_56())
			{
				int num = class5631_0.method_31();
				int index = class5631_0.method_32();
				Class5158 class2 = @class.method_58(index);
				int num2 = class2.int_4;
				if (class2.hashtable_2.Contains(num))
				{
					num2 = (int)class2.hashtable_2[num];
				}
				class4962_0.method_11(num2 - vmethod_7());
			}
			else
			{
				class4962_0.method_11(int_12);
			}
			interface173_0.imethod_7(class4962_0);
			method_25(class4962_0);
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

	public override int imethod_27(int adj, Class5337 lastElement)
	{
		return 0;
	}

	public override void imethod_28(Class5344 spaceGlue)
	{
	}

	public override Class5686 imethod_29()
	{
		return Class5686.class5686_0;
	}

	public override Class5686 imethod_33()
	{
		return Class5686.class5686_0;
	}

	public override Class5686 imethod_31()
	{
		return Class5686.class5686_0;
	}

	public override int imethod_16()
	{
		return int_12;
	}

	public override int imethod_17()
	{
		if (class4962_0 != null)
		{
			return class4962_0.vmethod_1();
		}
		return -1;
	}

	public override bool imethod_18()
	{
		return true;
	}

	public override bool imethod_19()
	{
		return true;
	}

	public Class5746 method_64()
	{
		return class5746_0;
	}
}
