using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ns171;
using ns173;
using ns175;
using ns176;
using ns181;
using ns182;
using ns183;
using ns184;
using ns187;
using ns189;
using ns195;
using ns196;
using ns197;
using ns205;

namespace ns198;

internal class Class5319 : Class5314, Interface172, Interface173, Interface174
{
	private class Class5260 : Class5258
	{
		internal int int_2;

		internal int int_3;

		internal int int_4;

		internal int int_5;

		internal int int_6;

		internal double double_0;

		internal double double_1;

		internal int int_7;

		internal int int_8;

		internal int int_9;

		internal int int_10;

		internal int int_11;

		internal int int_12;

		internal int int_13;

		internal Class5260(Interface173 lm, int index, int startIndex, int breakIndex, int shrink, int stretch, int diff, double ipdA, double adjust, int si, int ei, int lh, int lw, int sb, int sa, int bl)
			: base(lm, breakIndex)
		{
			int_4 = shrink;
			int_5 = stretch;
			int_6 = diff;
			int_2 = index;
			int_3 = startIndex;
			double_1 = ipdA;
			double_0 = adjust;
			int_7 = si;
			int_8 = ei;
			int_9 = lh;
			int_10 = lw;
			int_11 = sb;
			int_12 = sa;
			int_13 = bl;
		}
	}

	private class Class5612
	{
		internal Interface175 interface175_0;

		internal int int_0;

		internal Class5612(Interface175 lm, int index)
		{
			interface175_0 = lm;
			int_0 = index;
		}
	}

	private class Class5278 : Class5277
	{
		internal int int_1;

		internal int int_2;

		internal Class5746 class5746_0;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private Class5319 class5319_0;

		private Class5319 class5319_1;

		internal int int_7 = -1;

		internal Class5278(Class5319 llm, int alignment, int alignmentLast, int indent, int endIndent, Class5319 parent)
		{
			class5319_0 = llm;
			int_3 = alignment;
			int_4 = alignmentLast;
			int_5 = indent;
			int_6 = endIndent;
			class5319_1 = parent;
		}

		public override void vmethod_0()
		{
			if (int_3 == 23)
			{
				class5746_0 = Class5746.smethod_1(int_6);
			}
			else
			{
				class5746_0 = Class5746.smethod_0(int_6, int_6, class5319_0.int_12);
			}
			if (int_3 == 23 && int_4 != 70)
			{
				Add(new Class5344(0, 3 * Class5319.int_2, 0, null, auxiliary: false));
				int_1++;
			}
			if (class5319_1.bool_3 && class5319_1.arrayList_1.Count == 0 && int_5 != 0)
			{
				Add(new Class5339(int_5, null, null, auxiliary: false));
				int_1++;
			}
		}

		public void method_9()
		{
			Class5274 @class = vmethod_1();
			@class.int_0 = int_7;
			if (@class != null)
			{
				class5319_1.arrayList_1.Add(@class);
			}
		}

		public override Class5274 vmethod_1()
		{
			if (Count > int_1)
			{
				if (int_3 == 23 && int_4 != 70)
				{
					Add(new Class5344(0, 3 * Class5319.int_2, 0, null, auxiliary: false));
					Add(new Class5342(class5746_0.method_2(), -Class5337.int_0, penaltyFlagged: false, null, auxiliary: false));
					int_2 = 2;
				}
				else if (int_4 != 70)
				{
					Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, null, auxiliary: false));
					Add(new Class5344(0, class5746_0.method_5(), class5746_0.method_4(), null, auxiliary: false));
					Add(new Class5342(class5746_0.method_2(), -Class5337.int_0, penaltyFlagged: false, null, auxiliary: false));
					int_2 = 3;
				}
				else
				{
					Add(new Class5342(class5746_0.method_2(), -Class5337.int_0, penaltyFlagged: false, null, auxiliary: false));
					int_2 = 1;
				}
				return this;
			}
			Clear();
			return null;
		}

		public bool method_10()
		{
			int num = 0;
			while (true)
			{
				if (num < Count)
				{
					Class5337 @class = (Class5337)this[num];
					if (@class.vmethod_0())
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	private class Class5397 : Class5394
	{
		private Class5319 class5319_0;

		private int int_18;

		private int int_19;

		private int int_20;

		private int int_21;

		private int int_22;

		private int int_23;

		private int int_24;

		private static double double_1 = 10000000.0;

		private Class5319 class5319_1;

		internal Class5687 class5687_0;

		private int int_25 = -1;

		public Class5397(int pageAlign, int textAlign, int textAlignLast, int indent, int fillerWidth, int lh, int ld, int fl, bool first, int maxFlagCount, Class5319 llm, Class5319 parent)
			: base(textAlign, textAlignLast, first, partOverflowRecovery: false, maxFlagCount)
		{
			int_18 = pageAlign;
			int_21 = indent;
			int_22 = lh;
			int_23 = ld;
			int_24 = fl;
			class5319_0 = llm;
			int_19 = -1;
			class5319_1 = parent;
		}

		public override void vmethod_0(int lineCount, double demerits)
		{
			class5319_1.class5610_0.method_0(lineCount, demerits);
		}

		protected override void vmethod_13(int elementIdx, bool isFloat, int difference, int line)
		{
			if (class5319_1.int_8 == 93 || !isFloat || difference >= 0 || line == int_25)
			{
				return;
			}
			if (int_25 == -1 && line == 0)
			{
				for (int num = elementIdx; num >= 0; num--)
				{
					if (class5274_0[num] is Class5339 @class)
					{
						Interface173 @interface = @class.method_2();
						Class5315 class2 = @interface as Class5315;
						if ((class2 == null && !(@interface is Class5313)) || (class2 != null && class2.method_30() == 93))
						{
							class5319_1.bool_5 = true;
							break;
						}
					}
				}
			}
			if (class5319_1.bool_5)
			{
				int_25 = line;
				throw new Exception52();
			}
		}

		protected override int vmethod_21(int line, int index, ref bool isFloat)
		{
			int leftInset = 0;
			int rightInset = 0;
			Class5282.smethod_4(line, index, class5319_1, int_8, int_22, int_23, int_24, class5687_0, int_9, ref leftInset, ref rightInset);
			if (rightInset == int_8 && leftInset == 0)
			{
				return int_8;
			}
			isFloat = true;
			return rightInset - leftInset;
		}

		protected override void vmethod_2(int line)
		{
			List<Class5298> list = null;
			Class5296 @class = Class5283.smethod_1(class5319_1);
			if (@class != null)
			{
				list = Class5326.Instance.method_1(@class);
			}
			if (list == null)
			{
				list = Class5282.smethod_3(class5319_1);
				if (list == null)
				{
					list = Class5282.smethod_1(class5319_1);
					if (list == null)
					{
						return;
					}
				}
			}
			foreach (Class5298 item in list)
			{
				if (item.BodyLm.IsCalculated)
				{
					item.BodyLm.method_66(line, int_22, int_25, class5319_1);
				}
			}
		}

		public override void vmethod_1(Class5399 bestActiveNode, Class5274 par, int total)
		{
			int num = bestActiveNode.int_8;
			int num2 = ((bestActiveNode.int_1 < total) ? int_9 : int_10);
			int endIndent;
			int num3;
			switch ((Enum679)num2)
			{
			case Enum679.const_40:
				num3 = ((num > 0) ? num : 0);
				endIndent = 0;
				break;
			case Enum679.const_24:
				num3 = num / 2;
				endIndent = num3;
				break;
			case Enum679.const_222:
				num3 = 0;
				endIndent = ((num > 0) ? num : 0);
				break;
			default:
				num3 = 0;
				endIndent = 0;
				break;
			case Enum679.const_71:
				num3 = 0;
				endIndent = 0;
				break;
			}
			num3 += ((bestActiveNode.int_1 == 1 && bool_2 && class5319_1.bool_3) ? int_21 : 0);
			double ratio = ((num2 == 70 || (num < 0 && -num <= bestActiveNode.int_6)) ? bestActiveNode.double_0 : 0.0);
			if (int_19 == -1)
			{
				int_19 = 0;
				int_20 = 0;
			}
			if (int_20 == class5319_1.class5610_0.method_10(int_19))
			{
				int_19++;
				int_20 = 0;
			}
			class5319_1.class5610_0.method_3(method_22(par, (bestActiveNode.int_1 > 1) ? (bestActiveNode.class5399_0.int_0 + 1) : 0, bestActiveNode.int_0, bestActiveNode.int_6 - ((int_20 <= 0) ? ((Class5278)par).class5746_0.method_4() : 0), bestActiveNode.int_7, num, ratio, num3, endIndent), int_19);
			int_20++;
		}

		public void method_21()
		{
			int_19 = -1;
		}

		private Class5260 method_22(Class5274 par, int firstElementIndex, int lastElementIndex, int availableShrink, int availableStretch, int difference, double ratio, int startIndent, int endIndent)
		{
			int num = (int_22 - int_23 - int_24) / 2;
			int sa = int_22 - int_23 - int_24 - num;
			int num2 = int_23;
			int num3 = int_24;
			bool flag = difference == class5319_1.int_12;
			if (class5319_1.class5106_0.method_61() != 52)
			{
				Interface168 @interface = new Class5495(par, firstElementIndex);
				Class5684 @class = null;
				int num4 = 0;
				for (int i = firstElementIndex; i <= lastElementIndex; i++)
				{
					Class5337 class2 = (Class5337)@interface.imethod_1();
					if (!(class2 is Class5339))
					{
						continue;
					}
					Class5684 class3 = ((Class5339)class2).method_8();
					if (class3 != null && @class != class3)
					{
						if (class3.method_22() && (class3.method_2() == 14 || class3.method_2() == 4))
						{
							if (class3.method_15() > num4)
							{
								num4 = class3.method_15();
							}
						}
						else if (class5319_1.class5106_0.method_77() == 30 || class3.method_1() == 0)
						{
							int num5 = class3.method_11();
							if (num5 + class3.method_17() > num2)
							{
								num2 = num5 + class3.method_17();
							}
							if (class3.method_18() - num5 > num3)
							{
								num3 = class3.method_18() - num5;
							}
						}
						@class = class3;
					}
					if (flag && (!class2.method_3() || (class3 != null && class3.method_15() > 0)))
					{
						flag = false;
					}
				}
				if (num3 < num4 - num2)
				{
					num3 = num4 - num2;
				}
			}
			class5319_1.int_13 = num2 + num3;
			if (flag)
			{
				return new Class5260(class5319_0, class5319_1.arrayList_1.IndexOf(par), firstElementIndex, lastElementIndex, availableShrink, availableStretch, difference, ratio, 0.0, startIndent, endIndent, 0, class5319_1.int_12, 0, 0, 0);
			}
			return new Class5260(class5319_0, class5319_1.arrayList_1.IndexOf(par), firstElementIndex, lastElementIndex, availableShrink, availableStretch, difference, ratio, 0.0, startIndent, endIndent, num2 + num3, class5319_1.int_12, num, sa, num2);
		}

		protected override int vmethod_23()
		{
			Class5399 @class = null;
			if (int_18 == 70)
			{
				for (int i = base.StartLine; i < int_13; i++)
				{
					for (Class5399 class2 = method_16(i); class2 != null; class2 = class2.class5399_1)
					{
						@class = vmethod_19(@class, class2);
					}
				}
				for (int j = base.StartLine; j < int_13; j++)
				{
					for (Class5399 class3 = method_16(j); class3 != null; class3 = class3.class5399_1)
					{
						if (class3.int_1 != @class.int_1 && class3.double_1 > double_1)
						{
							method_15(j, class3);
						}
					}
				}
			}
			else
			{
				for (int k = base.StartLine; k < int_13; k++)
				{
					for (Class5399 class4 = method_16(k); class4 != null; class4 = class4.class5399_1)
					{
						@class = vmethod_19(@class, class4);
						if (class4 != @class)
						{
							method_15(k, class4);
						}
					}
				}
			}
			return @class.int_1;
		}
	}

	public static int int_2 = 3336;

	private Class5106 class5106_0;

	private bool bool_3;

	internal int int_3 = -1;

	private int int_4 = -1;

	private int int_5 = 70;

	private int int_6;

	private int int_7;

	private Interface182 interface182_0;

	private Interface182 interface182_1;

	private Class5717 class5717_0;

	private Interface181 interface181_0;

	private int int_8 = 161;

	private int int_9;

	private Interface182 interface182_2;

	private int int_10;

	private int int_11;

	private Class5684 class5684_0;

	internal ArrayList arrayList_1;

	private Class5610 class5610_0;

	private Class5610[] class5610_1;

	private int int_12;

	private bool bool_4;

	private int int_13 = 12000;

	private int int_14;

	private bool bool_5;

	public int Lead => int_10;

	public int Follow => int_11;

	public Class5319(Class5106 block, Interface182 lh, int l, int f)
		: base(block)
	{
		class5106_0 = block;
		interface168_0 = null;
		interface182_2 = lh;
		int_10 = l;
		int_11 = f;
	}

	public override void imethod_3()
	{
		int_4 = class5106_0.method_41();
		int_5 = class5106_0.method_65();
		int_6 = class5106_0.method_66();
		interface182_0 = class5106_0.method_67();
		interface182_1 = class5106_0.method_68();
		class5717_0 = class5106_0.method_54();
		interface181_0 = class5106_0.method_55();
		int_8 = class5106_0.method_69();
		int_9 = class5106_0.method_72();
		int_7 = method_30(int_5);
		bool_3 = this == imethod_2().imethod_11()[0];
	}

	private int method_30(int alignment)
	{
		if (int_5 != 70 && int_6 == 70)
		{
			return 0;
		}
		return int_5;
	}

	public override ArrayList imethod_14(Class5687 context, int alignment)
	{
		if (class5684_0 == null)
		{
			Class5730 @class = class5106_0.vmethod_3().vmethod_1();
			Class5732[] array = class5106_0.method_53().method_9(@class);
			Class5729 font = @class.method_12(array[0], class5106_0.method_53().interface182_0.imethod_6(this), class5106_0.method_53().method_5());
			class5684_0 = new Class5684(font, interface182_2.imethod_6(this), context.method_51());
		}
		context.method_41(class5684_0);
		int_12 = context.method_31();
		if (arrayList_1 == null)
		{
			arrayList_1 = new ArrayList();
			method_32(context);
		}
		if (arrayList_1.Count == 0)
		{
			imethod_6(fin: true);
			return null;
		}
		int num = 0;
		int num2 = 0;
		Interface168 @interface = new Class5495(arrayList_1);
		bool flag = int_8 != 93;
		while (@interface.imethod_0())
		{
			Class5274 arrayList = (Class5274)@interface.imethod_1();
			Interface168 interface2 = new Class5495(arrayList);
			while (interface2.imethod_0())
			{
				Class5328 class2 = (Class5328)interface2.imethod_1();
				if (class2 is Class5341)
				{
					Class5746 class3 = ((Class5341)class2).method_14();
					if (class3 != null)
					{
						num2 = class3.method_3();
					}
				}
				else if (class2 is Class5337)
				{
					num2 += ((Class5337)class2).method_4();
				}
				else if (class2 is Class5335)
				{
					num2 += ((Class5335)class2).method_4().method_2();
				}
				if (!flag || !(class2 is Class5339))
				{
					continue;
				}
				num = ((num != 0) ? Math.Max(num, ((Class5339)class2).method_4()) : ((Class5339)class2).method_4());
				while (interface2.imethod_0())
				{
					if (interface2.imethod_1() is Class5339 class4)
					{
						num += class4.method_4();
						num2 += class4.method_4();
						continue;
					}
					interface2.imethod_3();
					break;
				}
			}
		}
		if (!flag)
		{
			num = num2;
		}
		if (num2 < num)
		{
			num2 = num;
		}
		context.method_64(Class5746.smethod_0(num, num2, num2));
		return method_33(context.method_36(), context);
	}

	public ArrayList method_31(Class5687 context, int alignment, Class5258 restartPosition)
	{
		int num = restartPosition.method_6();
		Class5274 @class = (Class5274)arrayList_1[num];
		@class.RemoveRange(0, restartPosition.method_4() + 1);
		Interface208 @interface = new Class5495(@class);
		while (@interface.imethod_0() && !((Class5337)@interface.imethod_1()).vmethod_0())
		{
			@interface.imethod_6();
		}
		if (!@interface.imethod_0())
		{
			arrayList_1.Remove(num);
		}
		if (arrayList_1.Count == 0)
		{
			imethod_6(fin: true);
			return null;
		}
		int_12 = context.method_31();
		return method_33(context.method_36(), context);
	}

	private void method_32(Class5687 context)
	{
		Class5687 context2 = new Class5687(context);
		bool flag = false;
		Class5278 @class = null;
		int num = -1;
		int num2 = int_12;
		Interface175 @interface;
		while ((@interface = (Interface175)method_9()) != null)
		{
			if (@interface is Class5300 class2 && method_11())
			{
				Class5313 class3 = method_12() as Class5313;
				method_13();
				if (class3 != null)
				{
					class2.Lead = int_10;
					class2.Follow = int_11;
				}
			}
			ArrayList arrayList = @interface.imethod_14(context2, int_7);
			if (arrayList == null || arrayList.Count == 0)
			{
				continue;
			}
			int num3 = -1;
			if (@interface is Class5315 class4)
			{
				Interface182 interface2 = class4.method_31();
				if (interface2 != null && interface2.imethod_0() != 9)
				{
					num3 = (int)interface2.imethod_1();
				}
			}
			if (@class != null)
			{
				Class5274 class5 = (Class5274)arrayList[0];
				if (!class5.vmethod_5() || num3 != -1)
				{
					@class.method_9();
					Class5651.smethod_2(@class, "line", null);
					@class = null;
					flag = false;
				}
				if (@class != null)
				{
					Class5337 class6 = (Class5337)class5[0];
					if (class6.vmethod_0() && !class6.method_3() && flag)
					{
						@class.method_8();
					}
				}
			}
			Interface168 interface3 = new Class5495(arrayList);
			int num4 = num2;
			while (interface3.imethod_0())
			{
				Class5274 class7 = (Class5274)interface3.imethod_1();
				if (imethod_25())
				{
					Interface168 interface4 = new Class5495(class7);
					while (interface4.imethod_0())
					{
						Class5328 class8 = (Class5328)interface4.imethod_1();
						int num5 = 0;
						if (class8 is Class5337)
						{
							num5 = ((Class5337)class8).method_4();
						}
						else if (class8 is Class5335)
						{
							num5 = ((Class5335)class8).method_4().method_2();
						}
						int_12 += num5;
						num4 += num5;
					}
				}
				if (class7.vmethod_5())
				{
					Class5328 class9 = class7.method_3();
					flag = class9.vmethod_0() && !((Class5337)class9).method_3() && ((Class5337)class9).method_4() != 0;
					if (@class == null)
					{
						@class = new Class5278(this, int_5, int_6, interface182_0.imethod_6(this), interface182_1.imethod_6(this), this);
						@class.int_7 = num3;
						@class.vmethod_0();
					}
					Class5298 class10 = @interface as Class5298;
					if (class10 != null)
					{
						class10.BodyLm.KnuthListPosition = @class.Count;
					}
					else
					{
						@class.AddRange(class7);
					}
					if (class9.vmethod_2() && ((Class5342)class9).vmethod_5() == -Class5337.int_0 && class10 == null)
					{
						@class.method_4();
						if (!@class.method_10())
						{
							@class.Add(new Class5344(int_12, 0, int_12, null, auxiliary: true));
						}
						@class.method_9();
						Class5651.smethod_2(@class, "line", null);
						@class = null;
						flag = false;
					}
				}
				else
				{
					arrayList_1.Add(class7);
				}
			}
			if (imethod_25())
			{
				num = ((num3 == -1) ? Math.Max(num, num4) : Math.Max(num, num3));
			}
		}
		if (@class != null)
		{
			@class.method_9();
			Class5651.smethod_2(@class, "line", class5106_0.vmethod_31());
		}
		if (imethod_25())
		{
			context.method_30(num);
		}
	}

	private ArrayList method_33(int alignment, Class5687 context)
	{
		Interface208 @interface = new Class5495(arrayList_1);
		class5610_1 = new Class5610[arrayList_1.Count];
		int num = 0;
		while (@interface.imethod_0())
		{
			Class5274 @class = (Class5274)@interface.imethod_1();
			Class5610 class2 = (@class.vmethod_5() ? method_35(context, alignment, (Class5278)@class, !@interface.imethod_0(), @class.int_0) : new Class5610());
			class5610_1[num] = class2;
			num++;
		}
		imethod_6(fin: true);
		return method_36(alignment, context);
	}

	private ArrayList method_34(int alignment, Class5687 context)
	{
		Interface208 @interface = new Class5495(arrayList_1);
		class5610_1 = new Class5610[arrayList_1.Count];
		int num = 0;
		while (@interface.imethod_0())
		{
			Class5274 @class = (Class5274)@interface.imethod_1();
			Class5610 class2 = (@class.vmethod_5() ? method_35(context, alignment, (Class5278)@class, !@interface.imethod_0(), 0) : new Class5610());
			class5610_1[num] = class2;
			num++;
		}
		imethod_6(fin: true);
		return method_36(alignment, context);
	}

	private Class5610 method_35(Class5687 context, int alignment, Class5278 currPar, bool isLastPar, int width)
	{
		class5610_0 = new Class5610();
		double threshold = 1.0;
		Class5397 @class = new Class5397(alignment, int_5, int_6, interface182_0.imethod_6(this), currPar.class5746_0.method_2(), interface182_2.imethod_6(this), int_10, int_11, arrayList_1.IndexOf(currPar) == 0, (interface181_0.imethod_0() != 89) ? interface181_0.imethod_5() : 0, this, this);
		@class.class5687_0 = context;
		@class.method_2((width != -1) ? Math.Min(int_12, width) : int_12);
		bool flag2;
		bool flag;
		if ((flag2 = (flag = int_8 != 93) && class5717_0.class5042_0.imethod_0() == 149) && !bool_4)
		{
			bool_4 = isLastPar;
			method_38(currPar);
		}
		int num = (flag ? Class5394.int_3 : Class5394.int_4);
		Class5738 class2 = imethod_21().method_2();
		bool forceAlignBreak = class2.ForceAlignBreak;
		int num2 = @class.method_3(currPar, threshold, forceAlignBreak, num);
		if (num2 == 0 || alignment == 70)
		{
			if (num2 > 0)
			{
				@class.method_21();
				class5610_0.method_1(bSaveOptLineCount: false);
			}
			if (flag2 && num != Class5394.int_4)
			{
				num = Class5394.int_2;
			}
			else
			{
				threshold = 5.0;
			}
			if (@class.method_3(currPar, threshold, forceAlignBreak, num) == 0)
			{
				threshold = 20.0;
				@class.method_3(currPar, threshold, force: true, num);
			}
			class5610_0.method_2();
		}
		return class5610_0;
	}

	private ArrayList method_36(int alignment, Class5687 context)
	{
		ArrayList arrayList = new ArrayList();
		int num = -1;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			if (i > 0)
			{
				Class5686 @class = imethod_29();
				arrayList.Add(new Class5336(new Class5254(this), @class.method_3(), @class.method_2(), context));
			}
			Class5610 class2 = class5610_1[i];
			Class5274 class3 = (Class5274)arrayList_1[i];
			if (!class3.vmethod_5())
			{
				ArrayList arrayList2 = new ArrayList();
				Interface168 @interface = new Class5495(class3);
				while (@interface.imethod_0())
				{
					Class5328 class4 = (Class5328)@interface.imethod_1();
					if (class4.method_2() != this)
					{
						class4.method_1(imethod_22(new Class5255(this, class4.method_0())));
					}
					arrayList2.Add(class4);
				}
				arrayList.AddRange(arrayList2);
				continue;
			}
			if (class3.vmethod_5() && alignment == 70)
			{
				Class5254 elementPosition = new Class5258(this, i);
				method_37(arrayList, class2, elementPosition);
				continue;
			}
			int pos = 0;
			for (int j = 0; j < class2.method_9(); j++)
			{
				if (arrayList.Count > 0 && j > 0 && j >= class5106_0.method_59() && j <= class2.method_9() - class5106_0.method_60())
				{
					Class5686 class5 = imethod_29();
					arrayList.Add(new Class5336(new Class5258(this, i, num), class5.method_3(), class5.method_2(), context));
				}
				num = ((Class5260)class2.method_14(j)).method_6();
				ArrayList arrayList3 = new ArrayList();
				ArrayList arrayList4 = new ArrayList();
				Interface168 interface2 = new Class5495(class3, pos);
				while (interface2.imethod_4() <= num)
				{
					Class5337 class6 = (Class5337)interface2.imethod_1();
					if (class6 is Class5339 && ((Class5339)class6).method_11())
					{
						if (((Class5339)class6).method_12())
						{
							arrayList3.Add(((Class5339)class6).method_10());
						}
						else
						{
							arrayList4.Add(((Class5339)class6).method_7());
						}
					}
					else if (class6 is Class5341)
					{
						arrayList3.AddRange(((Class5341)class6).method_6());
						arrayList4.AddRange(((Class5341)class6).method_7());
					}
				}
				pos = num + 1;
				Class5260 class7 = (Class5260)class2.method_14(j);
				Class5746 ipd = alignment switch
				{
					70 => Class5746.smethod_0(class7.int_10 - class7.int_6 - class7.int_4, class7.int_10 - class7.int_6, class7.int_10 - class7.int_6 + class7.int_5), 
					23 => Class5746.smethod_1(class7.int_10 - 2 * class7.int_7), 
					39 => Class5746.smethod_1(class7.int_10 - class7.int_7), 
					_ => Class5746.smethod_1(class7.int_10 - class7.int_6 + class7.int_7), 
				};
				Class5341 class8 = new Class5341(class7.int_9 + class7.int_11 + class7.int_12, arrayList3, arrayList4, class7, auxiliary: false);
				class8.method_15(ipd);
				arrayList.Add(class8);
			}
		}
		return arrayList;
	}

	private void method_37(ArrayList list, Class5610 llPoss, Class5254 elementPosition)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = class5106_0.method_59();
		int num7 = class5106_0.method_60();
		ArrayList arrayList = new ArrayList();
		if (class5106_0.method_59() + class5106_0.method_60() <= llPoss.method_6())
		{
			num = llPoss.method_6() - (class5106_0.method_59() + class5106_0.method_60());
			num2 = llPoss.method_8() - llPoss.method_7();
			num4 = llPoss.method_7() - llPoss.method_6();
		}
		else if (class5106_0.method_59() + class5106_0.method_60() <= llPoss.method_7())
		{
			num2 = llPoss.method_8() - llPoss.method_7();
			num4 = llPoss.method_7() - (class5106_0.method_59() + class5106_0.method_60());
			num5 = class5106_0.method_59() + class5106_0.method_60() - llPoss.method_6();
		}
		else if (class5106_0.method_59() + class5106_0.method_60() <= llPoss.method_8())
		{
			num2 = llPoss.method_8() - (class5106_0.method_59() + class5106_0.method_60());
			num3 = class5106_0.method_59() + class5106_0.method_60() - llPoss.method_7();
			num5 = llPoss.method_7() - llPoss.method_6();
			num6 -= num3;
		}
		else
		{
			num3 = llPoss.method_8() - llPoss.method_7();
			num5 = llPoss.method_7() - llPoss.method_6();
			num6 = llPoss.method_7();
			num7 = 0;
		}
		if (num7 != 0 && (num3 > 0 || num5 > 0))
		{
			arrayList.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, elementPosition, auxiliary: false));
			arrayList.Add(new Class5344(0, -num3 * int_13, -num5 * int_13, Class5682.class5682_3, elementPosition, auxiliary: false));
			arrayList.Add(new Class5342(num3 * int_13, 0, penaltyFlagged: false, elementPosition, auxiliary: false));
			arrayList.Add(new Class5344(0, num3 * int_13, num5 * int_13, Class5682.class5682_3, elementPosition, auxiliary: false));
		}
		else if (num7 != 0)
		{
			arrayList.Add(new Class5342(0, 0, penaltyFlagged: false, elementPosition, auxiliary: false));
		}
		list.Add(new Class5338(num6 * int_13, elementPosition, num7 == 0 && num3 == 0 && num5 == 0));
		if (num3 > 0 || num5 > 0)
		{
			list.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, elementPosition, auxiliary: false));
			list.Add(new Class5344(0, num3 * int_13, num5 * int_13, Class5682.class5682_3, elementPosition, auxiliary: false));
			list.Add(new Class5338(0, elementPosition, num7 == 0));
		}
		for (int i = 0; i < num2; i++)
		{
			list.AddRange(arrayList);
			list.Add(new Class5338(0, elementPosition, auxiliary: false));
			list.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, elementPosition, auxiliary: false));
			list.Add(new Class5344(0, int_13, 0, Class5682.class5682_3, elementPosition, auxiliary: false));
			list.Add(new Class5338(0, elementPosition, auxiliary: false));
		}
		for (int j = 0; j < num4; j++)
		{
			list.AddRange(arrayList);
			list.Add(new Class5338(int_13, elementPosition, auxiliary: false));
			list.Add(new Class5342(0, Class5337.int_0, penaltyFlagged: false, elementPosition, auxiliary: false));
			list.Add(new Class5344(0, 0, int_13, Class5682.class5682_3, elementPosition, auxiliary: false));
			list.Add(new Class5338(0, elementPosition, auxiliary: false));
		}
		for (int k = 0; k < num; k++)
		{
			list.AddRange(arrayList);
			list.Add(new Class5338(int_13, elementPosition, auxiliary: false));
		}
		if (num7 > 0)
		{
			list.AddRange(arrayList);
			list.Add(new Class5338(num7 * int_13, elementPosition, auxiliary: true));
		}
	}

	public bool imethod_30()
	{
		return ((Interface174)imethod_2()).imethod_30();
	}

	public Class5043 imethod_35()
	{
		return ((Interface174)imethod_2()).imethod_35();
	}

	public Class5043 imethod_36()
	{
		return ((Interface174)imethod_2()).imethod_36();
	}

	public Class5043 imethod_37()
	{
		return ((Interface174)imethod_2()).imethod_37();
	}

	public Class5686 imethod_29()
	{
		return ((Interface174)imethod_2()).imethod_29();
	}

	public bool imethod_32()
	{
		return !imethod_31().method_1();
	}

	public bool imethod_34()
	{
		return !imethod_33().method_1();
	}

	public Class5686 imethod_33()
	{
		return Class5686.class5686_0;
	}

	public Class5686 imethod_31()
	{
		return Class5686.class5686_0;
	}

	public int imethod_27(int adj, Class5337 lastElement)
	{
		Class5258 @class = (Class5258)lastElement.method_0();
		int adj2 = (int)Math.Round((double)adj / (double)int_13 + ((adj > 0) ? (-0.4) : 0.4));
		Class5610 class2 = class5610_1[@class.method_6()];
		adj2 = class2.method_15(adj2);
		return adj2 * int_13;
	}

	public void imethod_28(Class5344 spaceGlue)
	{
	}

	public override ArrayList imethod_38(ArrayList oldList, int alignment, int depth)
	{
		return imethod_15(oldList, alignment);
	}

	public override ArrayList imethod_15(ArrayList oldList, int alignment)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class5610 @class = class5610_1[i];
			for (int j = 0; j < @class.method_9(); j++)
			{
				if (!((Interface174)interface173_0).imethod_30() && j >= class5106_0.method_59() && j <= @class.method_9() - class5106_0.method_60())
				{
					arrayList.Add(new Class5342(0, 0, penaltyFlagged: false, new Class5254(this), auxiliary: false));
				}
				Class5260 class2 = (Class5260)@class.method_14(j);
				arrayList.Add(new Class5341(range: alignment switch
				{
					70 => Class5746.smethod_0(class2.int_10 - class2.int_6 - class2.int_4, class2.int_10 - class2.int_6, class2.int_10 - class2.int_6 + class2.int_5), 
					23 => Class5746.smethod_1(class2.int_10 - 2 * class2.int_7), 
					39 => Class5746.smethod_1(class2.int_10 - class2.int_7), 
					_ => Class5746.smethod_1(class2.int_10 - class2.int_6 + class2.int_7), 
				}, width: class2.int_9, bpdim: (class2.double_1 != 0.0) ? (class2.int_10 - class2.int_6) : 0, pos: class2, auxiliary: false));
			}
		}
		return arrayList;
	}

	private void method_38(Class5278 currPar)
	{
		Interface168 @interface = new Class5495(currPar, currPar.int_1);
		ArrayList arrayList = new ArrayList();
		Interface175 interface2 = null;
		while (@interface.imethod_0())
		{
			Class5337 @class = (Class5337)@interface.imethod_1();
			if (@class.method_2() != interface2)
			{
				interface2 = (Interface175)@class.method_2();
				if (interface2 == null)
				{
					break;
				}
				arrayList.Add(new Class5612(interface2, @interface.imethod_5()));
			}
			else if (interface2 == null)
			{
				break;
			}
			if (!@class.vmethod_0() || @class.method_3())
			{
				continue;
			}
			int num = 1;
			int num2 = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(interface2.imethod_29(@class.method_0()));
			while (@interface.imethod_0())
			{
				Class5337 class2 = (Class5337)@interface.imethod_1();
				if (class2.vmethod_0() && !class2.method_3())
				{
					if (interface2 != class2.method_2())
					{
						interface2 = (Interface175)class2.method_2();
						arrayList.Add(new Class5612(interface2, @interface.imethod_5()));
					}
					num++;
					stringBuilder.Append(interface2.imethod_29(class2.method_0()));
					continue;
				}
				if (class2.method_3())
				{
					if (interface2 != class2.method_2())
					{
						interface2 = (Interface175)class2.method_2();
						arrayList.Add(new Class5612(interface2, @interface.imethod_5()));
					}
					num2++;
					continue;
				}
				@interface.imethod_3();
				break;
			}
			Class5685 class3 = method_40(stringBuilder);
			if (class3 == null)
			{
				continue;
			}
			Class5337 class4 = null;
			for (int i = 0; i < num + num2; i++)
			{
				@interface.imethod_3();
			}
			for (int j = 0; j < num + num2; j++)
			{
				class4 = (Class5337)@interface.imethod_1();
				if (class4.vmethod_0() && !class4.method_3())
				{
					((Interface175)class4.method_2()).imethod_30(class4.method_0(), class3);
				}
			}
		}
		method_39(currPar, arrayList);
	}

	private void method_39(Class5278 par, ArrayList updateList)
	{
		Interface168 @interface = new Class5495(updateList);
		int num = 0;
		while (@interface.imethod_0())
		{
			Class5612 @class = (Class5612)@interface.imethod_1();
			int num2 = @class.int_0;
			int num3;
			if (@interface.imethod_0())
			{
				Class5612 class2 = (Class5612)@interface.imethod_1();
				num3 = class2.int_0;
				@interface.imethod_3();
			}
			else
			{
				num3 = par.Count - par.int_2 - num;
			}
			Class5480 class3 = new Class5480(par, num2 + num, num3 + num);
			if (@class.interface175_0.imethod_31(class3.method_0()))
			{
				class3.method_1();
				class3 = new Class5480(par, num2 + num, num3 + num);
				ArrayList arrayList = @class.interface175_0.imethod_15(class3.method_0(), int_7);
				class3.method_1();
				class3 = new Class5480(par, num2 + num, num3 + num);
				class3.method_0().Clear();
				class3.method_1();
				par.InsertRange(num2 + num, arrayList);
				num += arrayList.Count - (num3 - num2);
			}
		}
		updateList.Clear();
	}

	protected override bool vmethod_3(bool isNotFirst)
	{
		return true;
	}

	protected override bool vmethod_4(bool isNotLast)
	{
		return true;
	}

	private Class5685 method_40(StringBuilder sbChars)
	{
		return null;
	}

	public override void imethod_9(Class5652 parentIter, Class5687 context)
	{
		while (parentIter.imethod_0())
		{
			Class5254 @class = (Class5254)parentIter.imethod_1();
			bool isLastPosition = !parentIter.imethod_0();
			if (@class is Class5260)
			{
				method_41(context, (Class5260)@class, isLastPosition);
			}
			else if (@class is Class5255 && @class.vmethod_1())
			{
				method_44(context, @class, isLastPosition);
			}
		}
		method_26(null);
	}

	private void method_41(Class5687 context, Class5260 lbp, bool isLastPosition)
	{
		Class5274 @class = (Class5274)arrayList_1[lbp.int_2];
		int num = lbp.int_3;
		int num2 = lbp.method_6();
		Class4972 class2 = new Class4972((lbp.method_6() < @class.Count - 1) ? int_5 : int_6, lbp.int_6, lbp.int_5, lbp.int_4);
		if (lbp.int_7 != 0)
		{
			class2.method_29(Class5757.int_20, lbp.int_7);
		}
		if (lbp.int_8 != 0)
		{
			class2.method_29(Class5757.int_21, lbp.int_8);
		}
		class2.method_13(lbp.int_9);
		class2.method_11(lbp.int_10);
		class2.method_16(int_4);
		class2.method_29(Class5757.int_22, lbp.int_11);
		class2.method_29(Class5757.int_23, lbp.int_12);
		class5684_0.method_20(lbp.int_9, lbp.int_13);
		if (@class is Class5278)
		{
			Class5278 class3 = (Class5278)@class;
			num += ((num == 0) ? class3.int_1 : 0);
			if (num2 == class3.Count - 1)
			{
				num2 -= class3.int_2;
				class2.method_11(class2.method_12() - interface182_1.imethod_6(this));
			}
		}
		Interface168 @interface = new Class5495(@class, num2);
		Class5337 class4 = (Class5337)@interface.imethod_1();
		Interface173 interface2 = class4.method_2();
		if (class4.vmethod_1() && (int_9 == 63 || int_9 == 60 || int_9 == 62))
		{
			num2--;
			@interface.imethod_3();
			if (@interface.imethod_2())
			{
				interface2 = ((Class5337)@interface.imethod_3()).method_2();
			}
		}
		if (int_9 == 63 || int_9 == 60 || int_9 == 61)
		{
			@interface = new Class5495(@class, num);
			while (@interface.imethod_0() && !((Class5337)@interface.imethod_1()).vmethod_0())
			{
				num++;
			}
		}
		Class5652 class5 = new Class5653(@class, num, num2 + 1);
		Class5687 class6 = new Class5687(0);
		class6.method_41(class5684_0);
		class6.method_37(lbp.double_0);
		class6.method_39(lbp.double_1);
		class6.method_18(new Class5696(startsReferenceArea: true));
		class6.method_21(new Class5696(startsReferenceArea: false));
		class6.method_2(256, bSet: true);
		method_26(class2);
		method_27(class6);
		Interface173 interface3;
		while ((interface3 = class5.method_0()) != null)
		{
			class6.method_2(128, interface3 == interface2);
			interface3.imethod_9(class5, class6);
			class6.method_18(class6.method_22());
			class6.method_21(new Class5696(startsReferenceArea: false));
		}
		Class5283 class7 = interface173_0 as Class5283;
		int num3 = 0;
		if (class7 != null)
		{
			num3 = class7.method_55();
		}
		method_43(class2, num3 - 1);
		int num4 = 0;
		foreach (Class5282 currentFloatBodyLayoutManager in Class5326.Instance.CurrentFloatBodyLayoutManagers)
		{
			if (currentFloatBodyLayoutManager != null && currentFloatBodyLayoutManager.method_67() && !currentFloatBodyLayoutManager.InitForTable && currentFloatBodyLayoutManager.Lines > 0)
			{
				num4 = Math.Max(num4, currentFloatBodyLayoutManager.X + currentFloatBodyLayoutManager.Width);
				if (class2.method_39().Count > 0)
				{
					currentFloatBodyLayoutManager.Lines--;
				}
			}
		}
		ArrayList arrayList = class2.method_39();
		if (arrayList.Count > 0 && !bool_5 && (!(class2.method_39()[0] is Class4951 class8) || !(class8.method_55() is Class4950)))
		{
			class2.XOffset = num4;
		}
		if (context.method_55() > 0 && (!context.method_7() || !isLastPosition))
		{
			class2.method_13(class2.vmethod_1() + context.method_55());
		}
		class2.method_44();
		if (class2.method_18() >= 0)
		{
			Class5433.smethod_1(class2);
		}
		interface173_0.imethod_8(class2);
	}

	private Class5287 method_42(Interface173 lm)
	{
		if (lm == null)
		{
			return null;
		}
		if (lm is Class5287 result)
		{
			return result;
		}
		return method_42(lm.imethod_2());
	}

	private void method_43(Class4972 lineArea, int line)
	{
		List<Class5298> list = null;
		Class5296 @class = Class5283.smethod_1(this);
		if (@class != null)
		{
			list = Class5326.Instance.method_1(@class);
		}
		if (list == null)
		{
			list = Class5282.smethod_3(this);
			if (list == null)
			{
				list = Class5282.smethod_1(this);
				if (list == null)
				{
					return;
				}
			}
		}
		foreach (Class5298 item in list)
		{
			Class5282 bodyLm = item.BodyLm;
			if (bodyLm == null || bodyLm.class4942_0 == null || (bodyLm.IsReinitialized && imethod_21() != bodyLm.FObjInitializer))
			{
				continue;
			}
			if (!bodyLm.InitForTable)
			{
				if ((bodyLm.StartLine != 0 && line < bodyLm.StartLine) || (item.imethod_2() != this && !(item.imethod_2() is Class5285) && !item.IsInsideTableCell))
				{
					continue;
				}
			}
			else
			{
				Class5287 class2 = method_42(this);
				if (class2 != item.imethod_2())
				{
					continue;
				}
			}
			Class4943 class3 = new Class4950();
			class3.vmethod_2(bodyLm.class4942_0);
			Class5326.Instance.CurrentFloatBodyLayoutManagers.Add(bodyLm);
			if (bodyLm.class4942_0 is Class4962 class4)
			{
				Class4962 class5 = ((class4 is Class4963) ? (class4.method_37()[0] as Class4962) : class4);
				int num = bodyLm.X;
				if (bodyLm.InitForTable)
				{
					num -= bodyLm.Width;
				}
				num -= class4.method_47() - class4.method_21();
				class5.method_38(num, leftAuto: true, rightAuto: true);
				class5.method_39(bodyLm.Y, topAuto: true, bottomAuto: true);
				if (bodyLm.method_67() || bodyLm.method_68())
				{
					class5.IsFloatSide = true;
					class5.FloatWidth = bodyLm.Width;
				}
			}
			lineArea.method_37(class3);
			bodyLm.class4942_0 = null;
		}
	}

	private void method_44(Class5687 context, Class5254 pos, bool isLastPosition)
	{
		ArrayList arrayList = new ArrayList(1);
		Class5254 @class = pos.vmethod_0();
		arrayList.Add(@class);
		Interface173 @interface = null;
		if (isLastPosition)
		{
			@interface = @class.method_0();
		}
		Class4972 class2 = new Class4972();
		method_26(class2);
		Class5687 class3 = new Class5687(0);
		class3.method_41(class5684_0);
		method_27(class3);
		Class5652 class4 = new Class5652(new Class5495(arrayList));
		Class5687 class5 = new Class5687(0);
		class5.method_18(new Class5696(startsReferenceArea: true));
		class5.method_21(new Class5696(startsReferenceArea: false));
		class5.method_2(256, bSet: true);
		Interface173 interface2;
		while ((interface2 = class4.method_0()) != null)
		{
			class5.method_2(128, context.method_7() && interface2 == @interface);
			class5.method_28(context.method_29());
			interface2.imethod_9(class4, class5);
			class5.method_18(class5.method_22());
			class5.method_21(new Class5696(startsReferenceArea: false));
		}
		class2.method_42();
		if (class2.method_18() >= 0)
		{
			Class5433.smethod_1(class2);
		}
		interface173_0.imethod_8(class2);
	}

	public override void imethod_8(Class4942 childArea)
	{
		if (childArea is Class4943)
		{
			Class4942 @class = method_25();
			if (method_28().method_20())
			{
				method_29(@class, method_28().method_19().method_4(endsReferenceArea: false), method_28().method_38());
			}
			@class.vmethod_2(childArea);
		}
	}

	public override bool imethod_19()
	{
		return true;
	}

	public override bool imethod_20()
	{
		return true;
	}

	public override bool imethod_24()
	{
		return true;
	}
}
