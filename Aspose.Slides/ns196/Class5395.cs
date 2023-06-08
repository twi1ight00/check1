using System;
using System.Collections;
using ns171;
using ns195;
using ns205;

namespace ns196;

internal class Class5395 : Class5394
{
	internal interface Interface183
	{
		void imethod_0(int part, int amount, Class5094 obj);
	}

	internal class Class5400 : Class5399
	{
		public Class5345.Class5346 class5346_0;

		public Class5345.Class5346 class5346_1;

		public Class5400(int position, int line, int fitness, int totalWidth, int totalStretch, int totalShrink, Class5345.Class5346 footnotesProgress, Class5345.Class5346 floatsProgress, double adjustRatio, int availableShrink, int availableStretch, int difference, double totalDemerits, Class5399 previous)
			: base(position, line, fitness, totalWidth, totalStretch, totalShrink, adjustRatio, availableShrink, availableStretch, difference, totalDemerits, previous)
		{
			class5346_0 = footnotesProgress.method_1();
			class5346_1 = floatsProgress.method_1();
		}
	}

	protected class Class5402 : Class5401
	{
		private Class5345.Class5346[] class5346_0 = new Class5345.Class5346[4];

		private Class5345.Class5346[] class5346_1 = new Class5345.Class5346[4];

		private Class5395 class5395_0;

		internal Class5402(Class5395 owner)
		{
			class5395_0 = owner;
		}

		public override void vmethod_0(double demerits, Class5399 node, double adjust, int availableShrink, int availableStretch, int difference, int fitness)
		{
			base.vmethod_0(demerits, node, adjust, availableShrink, availableStretch, difference, fitness);
			class5346_0[fitness] = class5395_0.class5345_0.method_1().method_1();
			class5346_1[fitness] = class5395_0.class5345_1.method_1().method_1();
		}

		public int method_10(int fitness)
		{
			return class5346_0[fitness].method_2();
		}

		public int method_11(int fitness)
		{
			return class5346_0[fitness].method_4();
		}

		public int method_12(int fitness)
		{
			return class5346_0[fitness].method_3();
		}

		public Class5345.Class5346 method_13(int fitness)
		{
			return class5346_0[fitness];
		}

		public Class5345.Class5346 method_14(int fitness)
		{
			return class5346_1[fitness];
		}
	}

	private Interface173 interface173_0;

	private Class5691 class5691_0;

	private Interface183 interface183_0;

	private ArrayList arrayList_0;

	private Class5345 class5345_0;

	private Class5345 class5345_1;

	private int int_18 = 5000;

	private int int_19 = 10000;

	private int int_20 = 10000;

	private int int_21 = -1;

	private int int_22 = -1;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private int int_23;

	private Class5399 class5399_5;

	private int int_24 = 9;

	private Class5399 class5399_6;

	public Class5395(Interface173 topLevelLM, Class5691 pageProvider, Interface183 layoutListener, int alignment, int alignmentLast, Class5746 footnoteSeparatorLength, Class5746 floatSeparatorLength, bool partOverflowRecovery, bool autoHeight, bool favorSinglePart)
		: base(alignment, alignmentLast, first: true, partOverflowRecovery, 0)
	{
		interface173_0 = topLevelLM;
		class5691_0 = pageProvider;
		interface183_0 = layoutListener;
		class5401_0 = new Class5402(this);
		class5345_0 = new Class5345((Class5746)footnoteSeparatorLength.method_0());
		class5345_1 = new Class5345((Class5746)floatSeparatorLength.method_0());
		bool_5 = autoHeight;
		bool_6 = favorSinglePart;
	}

	protected override void vmethod_6()
	{
		base.vmethod_6();
		class5345_0.method_0();
		class5345_1.method_0();
	}

	protected override Class5399 vmethod_5(Class5399 lastTooLong)
	{
		if (class5399_6 != null && int_24 != 9)
		{
			Class5399 @class = class5399_6;
			class5399_6 = null;
			while (!class5691_0.method_6(@class.int_1 - 1))
			{
				@class = vmethod_7(@class.int_0, @class.int_1 + 1, 1, 0, 0, 0, 0.0, 0, 0, 0, 0.0, @class);
			}
			return @class;
		}
		return base.vmethod_5(lastTooLong);
	}

	protected override Class5399 vmethod_19(Class5399 node1, Class5399 node2)
	{
		if (node1 != null && node2 != null)
		{
			if (class5691_0 != null)
			{
				if (class5691_0.method_6(node1.int_1 - 1) && !class5691_0.method_6(node2.int_1 - 1))
				{
					return node1;
				}
				if (class5691_0.method_6(node2.int_1 - 1) && !class5691_0.method_6(node1.int_1 - 1))
				{
					return node2;
				}
			}
			return base.vmethod_19(node1, node2);
		}
		if (node1 != null)
		{
			return node1;
		}
		return node2;
	}

	internal override Class5399 vmethod_7(int position, int line, int fitness, int totalWidth, int totalStretch, int totalShrink, double adjustRatio, int availableShrink, int availableStretch, int difference, double totalDemerits, Class5399 previous)
	{
		return new Class5400(position, line, fitness, totalWidth, totalStretch, totalShrink, class5345_0.method_1(), class5345_1.method_1(), adjustRatio, availableShrink, availableStretch, difference, totalDemerits, previous);
	}

	protected override Class5399 vmethod_8(int position, int line, int fitness, int totalWidth, int totalStretch, int totalShrink)
	{
		return new Class5400(position, line, fitness, totalWidth, totalStretch, totalShrink, ((Class5402)class5401_0).method_13(fitness), ((Class5402)class5401_0).method_14(fitness), class5401_0.method_4(fitness), class5401_0.method_5(fitness), class5401_0.method_6(fitness), class5401_0.method_7(fitness), class5401_0.method_2(fitness), class5401_0.method_3(fitness));
	}

	protected override void vmethod_9(Class5338 box)
	{
		base.vmethod_9(box);
		if (box is Class5341 && ((Class5341)box).method_8())
		{
			ArrayList arrayList = ((Class5341)box).method_11();
			ArrayList arrayList2 = new ArrayList();
			arrayList2.AddRange(arrayList);
			arrayList.Clear();
			class5345_0.method_7(arrayList2);
		}
		if (box is Class5341)
		{
			((Class5341)box).method_9();
		}
	}

	protected override void vmethod_10(Class5342 penalty, int position, int allowedBreaks)
	{
		base.vmethod_10(penalty, position, allowedBreaks);
		if (penalty.vmethod_5() == Class5337.int_0)
		{
			int num = penalty.method_8();
			if (num == 104 || num == 28)
			{
				vmethod_12(penalty, position);
			}
		}
	}

	protected override int vmethod_11(Class5399 restartingNode, int currentIndex)
	{
		int result = base.vmethod_11(restartingNode, currentIndex);
		class5345_0.method_5();
		class5345_1.method_5();
		if (class5345_0.method_4() || class5345_1.method_4())
		{
			for (int num = currentIndex; num >= restartingNode.int_0; num--)
			{
				Class5337 @class = method_14(num);
				if (@class is Class5341 && ((Class5341)@class).method_8())
				{
					class5345_0.method_16(((Class5341)@class).method_11());
				}
				if (@class is Class5341 && ((Class5341)@class).method_9())
				{
					class5345_1.method_16(((Class5341)@class).method_13());
				}
			}
		}
		return result;
	}

	protected override void vmethod_12(Class5337 element, int elementIdx)
	{
		if (element.vmethod_2())
		{
			int num = ((Class5342)element).method_8();
			switch ((Enum679)num)
			{
			case Enum679.const_191:
				if (int_24 != num)
				{
					class5399_6 = method_5();
				}
				int_24 = num;
				break;
			case Enum679.const_29:
				if (int_24 != num)
				{
					class5399_6 = method_5();
				}
				int_24 = num;
				break;
			case Enum679.const_10:
				int_24 = num;
				break;
			}
		}
		base.vmethod_12(element, elementIdx);
		class5345_0.method_5();
		class5345_1.method_5();
	}

	protected override bool vmethod_14(Class5337 element, int line, int difference)
	{
		if (element.vmethod_2() && class5691_0 != null)
		{
			Class5342 @class = (Class5342)element;
			if (@class.vmethod_5() <= 0)
			{
				return true;
			}
			switch ((Enum679)@class.method_8())
			{
			case Enum679.const_10:
				return true;
			default:
				if (@class.vmethod_5() < Class5337.int_0)
				{
					return true;
				}
				return false;
			case Enum679.const_191:
				if (@class.vmethod_5() >= Class5337.int_0)
				{
					return !class5691_0.method_6(line - 1);
				}
				return true;
			case Enum679.const_29:
			case Enum679.const_76:
				return @class.vmethod_5() < Class5337.int_0;
			}
		}
		return true;
	}

	protected override int vmethod_15(Class5399 activeNode, Class5337 element, int elementIndex, int line, ref bool isFloat)
	{
		Class5400 @class = (Class5400)activeNode;
		int num = int_14 - @class.int_3;
		if (element.vmethod_2())
		{
			num += element.method_4();
		}
		if (class5345_0.method_4())
		{
			class5345_0.method_8(@class.class5346_0);
			int num2 = class5345_0.method_3() - @class.class5346_0.method_2();
			if (num2 > 0)
			{
				num += class5345_0.method_2().int_1;
				bool canDeferOldFootnotes;
				int num3;
				if (num + num2 <= vmethod_21(activeNode.int_1, elementIndex, ref isFloat))
				{
					num += num2;
					class5345_0.method_15();
				}
				else if (((canDeferOldFootnotes = method_21(class5345_0, @class.int_0, elementIndex)) || class5345_0.method_6()) && (num3 = class5345_0.method_13(@class.class5346_0, vmethod_22() - num, canDeferOldFootnotes)) > 0)
				{
					num += num3;
				}
				else
				{
					num += num2;
					class5345_0.method_15();
				}
			}
		}
		if (class5345_1.method_4())
		{
			class5345_1.method_8(@class.class5346_1);
			int num4 = class5345_1.method_3() - @class.class5346_1.method_2();
			if (num4 > 0 && vmethod_22() - num - class5345_1.method_2().int_1 > 0)
			{
				int num5 = class5345_1.method_14(@class.class5346_1, vmethod_22() - num - class5345_1.method_2().int_1);
				if (num5 > 0)
				{
					num += class5345_1.method_2().int_1 + num5;
				}
			}
		}
		int num6 = vmethod_21(activeNode.int_1, elementIndex, ref isFloat) - num;
		if (bool_5 && num6 < 0)
		{
			return 0;
		}
		return num6;
	}

	private bool method_21(Class5345 outOfLine, int activeNodePosition, int contentElementIndex)
	{
		if (method_22(activeNodePosition, contentElementIndex))
		{
			return outOfLine.method_9();
		}
		return false;
	}

	private bool method_22(int prevBreakIndex, int breakIndex)
	{
		if (int_21 == -1 || ((prevBreakIndex < int_21 || breakIndex != int_22 || !bool_4) && (prevBreakIndex > int_21 || breakIndex < int_22 || bool_4)))
		{
			int i;
			for (i = prevBreakIndex + 1; !class5274_0.method_5(i).vmethod_0(); i++)
			{
			}
			for (; i < breakIndex && (!class5274_0.method_5(i).vmethod_1() || !class5274_0.method_5(i - 1).vmethod_0()) && (!class5274_0.method_5(i).vmethod_2() || ((Class5337)class5274_0.method_5(i)).vmethod_5() >= Class5337.int_0); i++)
			{
			}
			int_21 = prevBreakIndex;
			int_22 = breakIndex;
			bool_4 = i == breakIndex;
		}
		return bool_4;
	}

	protected override double vmethod_16(Class5399 activeNode, int difference)
	{
		if (difference > 0)
		{
			int num = int_15 - activeNode.int_4;
			if (((Class5400)activeNode).class5346_0.method_2() < class5345_0.method_3())
			{
				num += class5345_0.method_2().int_2 - class5345_0.method_2().int_1;
			}
			if (((Class5400)activeNode).class5346_1.method_2() < class5345_1.method_3())
			{
				num += class5345_1.method_2().int_2 - class5345_1.method_2().int_1;
			}
			if (num > 0)
			{
				return (double)difference / (double)num;
			}
			return Class5394.int_0;
		}
		if (difference < 0)
		{
			int num2 = int_16 - activeNode.int_5;
			if (((Class5400)activeNode).class5346_0.method_2() < class5345_0.method_3())
			{
				num2 += class5345_0.method_2().int_1 - class5345_0.method_2().int_0;
			}
			if (((Class5400)activeNode).class5346_1.method_2() < class5345_1.method_3())
			{
				num2 += class5345_1.method_2().int_1 - class5345_1.method_2().int_0;
			}
			if (num2 > 0)
			{
				return (double)difference / (double)num2;
			}
			return -Class5394.int_0;
		}
		return 0.0;
	}

	protected override double vmethod_17(Class5399 activeNode, Class5337 element, int fitnessClass, double r)
	{
		double num = 0.0;
		double num2 = Math.Abs(r);
		if (num2 > 1.0)
		{
			num2 = 1.0;
		}
		num2 = 1.0 + 100.0 * num2 * num2 * num2;
		if (element.vmethod_2())
		{
			double num3 = element.vmethod_5();
			if (!(num3 >= 0.0))
			{
				num = (element.vmethod_3() ? (num2 * num2) : (num2 * num2 - num3 * num3));
			}
			else
			{
				num2 += num3;
				num = num2 * num2;
			}
		}
		else
		{
			num = num2 * num2;
		}
		if (element.vmethod_2() && ((Class5342)element).method_7() && method_14(activeNode.int_0).vmethod_2() && ((Class5342)method_14(activeNode.int_0)).method_7())
		{
			num += (double)int_5;
		}
		if (Math.Abs(fitnessClass - activeNode.int_2) > 1)
		{
			num += (double)int_6;
		}
		if (class5345_0.method_4())
		{
			num += (double)(class5345_0.method_10() * int_19);
			if (class5345_0.method_11())
			{
				num += (double)int_18;
			}
		}
		if (class5345_1.method_4())
		{
			num += (double)(class5345_1.method_10() * int_20);
		}
		return num + activeNode.double_1;
	}

	protected override void vmethod_18()
	{
		for (int i = base.StartLine; i < int_13; i++)
		{
			for (Class5400 @class = (Class5400)method_16(i); @class != null; @class = (Class5400)@class.class5399_1)
			{
				if (@class.class5346_0.method_2() < class5345_0.method_3())
				{
					class5345_0.method_17(@class, this, vmethod_22());
				}
				if (@class.class5346_1.method_2() < class5345_1.method_3())
				{
					class5345_1.method_18(@class, this, vmethod_22());
				}
			}
		}
	}

	public ArrayList method_23()
	{
		return arrayList_0;
	}

	public void method_24(Class5268.Class5259 pageBreak)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Insert(0, pageBreak);
	}

	public void method_25()
	{
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			Class5480 @class = new Class5480(arrayList_0, 0, arrayList_0.Count - 1);
			@class.method_0().Clear();
		}
	}

	public override void vmethod_0(int total, double demerits)
	{
	}

	public override void vmethod_1(Class5399 bestActiveNode, Class5274 sequence, int total)
	{
		int num = bestActiveNode.int_8;
		if (num + bestActiveNode.int_6 < 0 && !bool_5 && interface183_0 != null)
		{
			interface183_0.imethod_0(bestActiveNode.int_1 - 1, -num, method_28());
		}
		bool flag;
		int num2 = ((flag = bestActiveNode.int_1 < total) ? int_9 : int_10);
		double num3 = bestActiveNode.double_0;
		if (num3 < 0.0)
		{
			num = 0;
		}
		else if (num3 <= 1.0 && flag)
		{
			num = 0;
		}
		else if (num3 > 1.0)
		{
			num3 = 1.0;
			num -= bestActiveNode.int_7;
		}
		else if (num2 != 70)
		{
			num3 = 0.0;
		}
		else
		{
			num = 0;
		}
		int num4 = ((Class5400)bestActiveNode.class5399_0).class5346_0.method_4();
		int num5 = ((Class5400)bestActiveNode.class5399_0).class5346_0.method_3();
		if (num4 == -1)
		{
			num4++;
			num5 = 0;
		}
		else if (class5345_0.method_12(num4) != null && num5 == class5345_0.method_12(num4).Count - 1)
		{
			num4++;
			num5 = 0;
		}
		else
		{
			num5++;
		}
		int flfli = ((Class5400)bestActiveNode.class5399_0).class5346_1.method_4() + 1;
		method_24(new Class5268.Class5259(interface173_0, bestActiveNode.int_0, num4, num5, ((Class5400)bestActiveNode).class5346_0.method_4(), ((Class5400)bestActiveNode).class5346_0.method_3(), flfli, ((Class5400)bestActiveNode).class5346_1.method_4(), num3, num));
	}

	protected override int vmethod_23()
	{
		Class5399 @class = null;
		for (int i = base.StartLine; i < int_13; i++)
		{
			for (Class5399 class2 = method_16(i); class2 != null; class2 = class2.class5399_1)
			{
				if (!bool_6 || class2.int_1 <= 1 || @class == null || Math.Abs(@class.int_8) >= @class.int_6)
				{
					@class = vmethod_19(@class, class2);
				}
				if (class2 != @class)
				{
					method_15(i, class2);
				}
			}
		}
		return @class.int_1;
	}

	internal ArrayList method_26(int index)
	{
		return class5345_0.method_12(index);
	}

	public ArrayList method_27(int index)
	{
		return class5345_1.method_12(index);
	}

	public Class5094 method_28()
	{
		return interface173_0.imethod_21();
	}

	protected override int vmethod_21(int line, int index, ref bool isFloat)
	{
		if (class5691_0 != null)
		{
			return class5691_0.method_2(line);
		}
		return base.vmethod_21(line, index, ref isFloat);
	}

	internal override int vmethod_3()
	{
		return int_23;
	}

	protected override int vmethod_4()
	{
		method_18(class5399_5, class5274_0, class5399_5.int_1 + 1);
		class5399_3 = null;
		return class5399_5.int_1;
	}

	internal override void vmethod_20(int line, Class5399 node)
	{
		if (node.int_0 < class5274_0.Count - 1 && line > 0 && (int_23 = method_30(line - 1)) != 0)
		{
			if (class5399_5 == null || node.double_1 < class5399_5.double_1)
			{
				class5399_5 = node;
			}
			return;
		}
		if (node.int_0 == class5274_0.Count - 1)
		{
			int_23 = 0;
		}
		base.vmethod_20(line, node);
	}

	internal Class5399 method_29()
	{
		return class5399_5;
	}

	private int method_30(int line)
	{
		if (class5691_0 == null)
		{
			return 0;
		}
		return class5691_0.method_4(line);
	}
}
