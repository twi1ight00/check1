using System;
using System.Text;
using ns198;

namespace ns196;

internal abstract class Class5394
{
	internal class Class5399
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		public int int_5;

		public double double_0;

		public int int_6;

		public int int_7;

		public int int_8;

		public double double_1;

		public Class5399 class5399_0;

		public Class5399 class5399_1;

		public int int_9;

		public Class5399(int position, int line, int fitness, int totalWidth, int totalStretch, int totalShrink, double adjustRatio, int availableShrink, int availableStretch, int difference, double totalDemerits, Class5399 previous)
		{
			int_0 = position;
			int_1 = line;
			int_2 = fitness;
			int_3 = totalWidth;
			int_4 = totalStretch;
			int_5 = totalShrink;
			double_0 = adjustRatio;
			int_6 = availableShrink;
			int_7 = availableStretch;
			int_8 = difference;
			double_1 = totalDemerits;
			class5399_0 = previous;
		}

		public string method_0()
		{
			return "<KnuthNode at " + int_0 + " " + int_3 + "+" + int_4 + "-" + int_5 + " line:" + int_1 + " prev:" + ((class5399_0 != null) ? class5399_0.int_0 : (-1)) + " dem:" + double_1 + " fitness:" + Class5398.string_0[int_2] + ">";
		}
	}

	private class Class5398
	{
		private static int int_0 = 0;

		private static int int_1 = 1;

		private static int int_2 = 2;

		private static int int_3 = 3;

		internal static string[] string_0 = new string[4] { "VERY TIGHT", "TIGHT", "LOOSE", "VERY LOOSE" };

		private Class5398()
		{
		}

		internal static int smethod_0(double adjustRatio)
		{
			if (adjustRatio < -0.5)
			{
				return int_0;
			}
			if (adjustRatio <= 0.5)
			{
				return int_1;
			}
			if (adjustRatio <= 1.0)
			{
				return int_2;
			}
			return int_3;
		}
	}

	protected class Class5401
	{
		internal const double double_0 = double.PositiveInfinity;

		private double[] double_1 = new double[4];

		private Class5399[] class5399_0 = new Class5399[4];

		private double[] double_2 = new double[4];

		private int[] int_0 = new int[4];

		private int[] int_1 = new int[4];

		private int[] int_2 = new int[4];

		private int int_3 = -1;

		public Class5401()
		{
			method_9();
		}

		public virtual void vmethod_0(double demerits, Class5399 node, double adjust, int availableShrink, int availableStretch, int difference, int fitness)
		{
			double_1[fitness] = demerits;
			class5399_0[fitness] = node;
			double_2[fitness] = adjust;
			int_1[fitness] = availableShrink;
			int_2[fitness] = availableStretch;
			int_0[fitness] = difference;
			if (int_3 == -1 || demerits < double_1[int_3])
			{
				int_3 = fitness;
			}
		}

		public bool method_0()
		{
			return int_3 != -1;
		}

		public bool method_1(int fitness)
		{
			return double_1[fitness] != double.PositiveInfinity;
		}

		public double method_2(int fitness)
		{
			return double_1[fitness];
		}

		public Class5399 method_3(int fitness)
		{
			return class5399_0[fitness];
		}

		public double method_4(int fitness)
		{
			return double_2[fitness];
		}

		public int method_5(int fitness)
		{
			return int_1[fitness];
		}

		public int method_6(int fitness)
		{
			return int_2[fitness];
		}

		public int method_7(int fitness)
		{
			return int_0[fitness];
		}

		public double method_8()
		{
			if (int_3 != -1)
			{
				return method_2(int_3);
			}
			return double.PositiveInfinity;
		}

		public void method_9()
		{
			for (int i = 0; i < 4; i++)
			{
				double_1[i] = double.PositiveInfinity;
			}
			int_3 = -1;
		}
	}

	protected static int int_0 = 1000;

	private static int int_1 = 5;

	public static int int_2 = 0;

	public static int int_3 = 1;

	public static int int_4 = 2;

	protected int int_5 = Class5342.int_2;

	protected int int_6 = Class5342.int_2;

	protected int int_7;

	private double double_0;

	protected Class5274 class5274_0;

	protected int int_8 = -1;

	private bool bool_0;

	protected bool bool_1;

	private Class5399 class5399_0;

	private Class5399 class5399_1;

	private Class5399 class5399_2;

	protected int int_9;

	protected int int_10;

	protected bool bool_2;

	protected Class5399[] class5399_3;

	protected int int_11;

	private int int_12;

	protected int int_13;

	internal int int_14;

	protected int int_15;

	internal int int_16;

	protected Class5401 class5401_0;

	private bool bool_3 = true;

	private Class5399 class5399_4;

	protected int int_17;

	public int StartLine
	{
		get
		{
			return int_12;
		}
		set
		{
			int_12 = value;
		}
	}

	public Class5394(int align, int alignLast, bool first, bool partOverflowRecovery, int maxFlagCount)
	{
		int_9 = align;
		int_10 = alignLast;
		bool_2 = first;
		bool_3 = partOverflowRecovery;
		class5401_0 = new Class5401();
		int_7 = maxFlagCount;
	}

	protected int method_0()
	{
		return int_1;
	}

	protected bool method_1()
	{
		return bool_3;
	}

	public abstract void vmethod_0(int total, double demerits);

	public abstract void vmethod_1(Class5399 bestActiveNode, Class5274 sequence, int total);

	public void method_2(int lineWidth)
	{
		int_8 = lineWidth;
	}

	public int method_3(Class5274 par, double threshold, bool force, int allowedBreaks)
	{
		return method_4(par, 0, threshold, force, allowedBreaks);
	}

	public int method_4(Class5274 par, int startIndex, double threshold, bool force, int allowedBreaks)
	{
		class5274_0 = par;
		double_0 = threshold;
		bool_0 = force;
		vmethod_6();
		bool previousIsBox = false;
		int num = startIndex;
		if (int_9 != 23)
		{
			num = par.method_7(startIndex);
		}
		num = ((num >= 0) ? num : 0);
		vmethod_20(0, vmethod_7(num, 0, 1, 0, 0, 0, 0.0, 0, 0, 0, 0.0, null));
		Class5399 @class = method_16(0);
		int num2 = startIndex;
		while (true)
		{
			if (num2 < par.Count)
			{
				try
				{
					previousIsBox = method_6(num2, previousIsBox, allowedBreaks).vmethod_0();
				}
				catch (Exception52)
				{
					int num3 = num2;
					while (num3 >= 0 && !(par[num3] is Class5338))
					{
						num3--;
					}
					par.Insert(num3, new Class5344(0, Class5337.int_0, 0, null, auxiliary: true));
					par.Insert(num3, new Class5339(0, null, null, auxiliary: true));
					num2 = num3 - 1;
					goto IL_0141;
				}
				if (int_11 == 0)
				{
					if (vmethod_3() != 0)
					{
						return vmethod_4();
					}
					if (!force)
					{
						break;
					}
					if (class5399_2 != null && class5399_2 != @class)
					{
						method_8();
					}
					if (class5399_1 != null && @class.int_0 != class5399_1.int_0)
					{
						@class = class5399_1;
						class5399_4 = null;
					}
					else
					{
						@class = method_9();
					}
					num2 = vmethod_11(@class, num2);
				}
				goto IL_0141;
			}
			vmethod_18();
			int num4 = vmethod_23();
			for (int i = StartLine; i < int_13; i++)
			{
				for (Class5399 class2 = method_16(i); class2 != null; class2 = class2.class5399_1)
				{
					vmethod_0(class2.int_1, class2.double_1);
					method_18(class2, par, class2.int_1);
				}
			}
			class5399_3 = null;
			vmethod_2(num4);
			return num4;
			IL_0141:
			num2++;
		}
		return 0;
	}

	protected virtual void vmethod_2(int line)
	{
	}

	internal virtual int vmethod_3()
	{
		return 0;
	}

	protected virtual int vmethod_4()
	{
		throw new InvalidOperationException();
	}

	protected virtual Class5399 vmethod_5(Class5399 lastTooLong)
	{
		if (lastTooLong.class5399_0.class5399_0 == null)
		{
			Class5328 @class = (Class5328)class5274_0[0];
			if (!@class.vmethod_2())
			{
				class5274_0.Insert(0, Class5342.class5342_0);
			}
		}
		return vmethod_7(lastTooLong.class5399_0.int_0, lastTooLong.class5399_0.int_1 + 1, 1, 0, 0, 0, 0.0, 0, 0, 0, 0.0, lastTooLong.class5399_0);
	}

	protected virtual void vmethod_6()
	{
		int_14 = 0;
		int_15 = 0;
		int_16 = 0;
		class5399_1 = null;
		class5399_0 = null;
		StartLine = 0;
		int_13 = 0;
		class5399_3 = new Class5399[20];
	}

	internal virtual Class5399 vmethod_7(int position, int line, int fitness, int totalWidth, int totalStretch, int totalShrink, double adjustRatio, int availableShrink, int availableStretch, int difference, double totalDemerits, Class5399 previous)
	{
		return new Class5399(position, line, fitness, totalWidth, totalStretch, totalShrink, adjustRatio, availableShrink, availableStretch, difference, totalDemerits, previous);
	}

	protected virtual Class5399 vmethod_8(int position, int line, int fitness, int totalWidth, int totalStretch, int totalShrink)
	{
		return new Class5399(position, line, fitness, totalWidth, totalStretch, totalShrink, class5401_0.method_4(fitness), class5401_0.method_5(fitness), class5401_0.method_6(fitness), class5401_0.method_7(fitness), class5401_0.method_2(fitness), class5401_0.method_3(fitness));
	}

	protected Class5399 method_5()
	{
		return class5399_1;
	}

	protected Class5337 method_6(int position, bool previousIsBox, int allowedBreaks)
	{
		Class5337 @class = method_14(position);
		if (@class.vmethod_0())
		{
			vmethod_9((Class5338)@class);
		}
		else if (@class.vmethod_1())
		{
			method_7((Class5344)@class, position, previousIsBox, allowedBreaks);
		}
		else
		{
			if (!@class.vmethod_2())
			{
				throw new ArgumentException("Unknown KnuthElement type: expecting KnuthBox, KnuthGlue or KnuthPenalty");
			}
			vmethod_10((Class5342)@class, position, allowedBreaks);
		}
		return @class;
	}

	protected virtual void vmethod_9(Class5338 box)
	{
		int_14 += box.method_4();
	}

	protected void method_7(Class5344 glue, int position, bool previousIsBox, int allowedBreaks)
	{
		if (previousIsBox && allowedBreaks != int_4)
		{
			vmethod_12(glue, position);
		}
		int_14 += glue.method_4();
		int_15 += glue.vmethod_6();
		int_16 += glue.vmethod_7();
	}

	protected virtual void vmethod_10(Class5342 penalty, int position, int allowedBreaks)
	{
		if (penalty.vmethod_5() < Class5337.int_0 && (allowedBreaks != int_3 || !penalty.method_7()) && (allowedBreaks != int_4 || penalty.vmethod_3()))
		{
			vmethod_12(penalty, position);
		}
	}

	protected void method_8()
	{
		if (class5399_2.double_0 > 0.0)
		{
			class5399_1 = class5399_2;
		}
		else
		{
			class5399_0 = class5399_2;
		}
	}

	protected Class5399 method_9()
	{
		Class5399 class2;
		if (method_1())
		{
			if (class5399_4 == null)
			{
				class5399_4 = class5399_0;
			}
			Class5399 @class = vmethod_5(class5399_0);
			class2 = @class;
			@class.int_9 = class5399_0.class5399_0.int_9 + 1;
			if (@class.int_9 > method_0())
			{
				while (class2.int_9 > 0 && class2.class5399_0 != null)
				{
					class2 = class2.class5399_0;
					class5399_2 = class2.class5399_0;
				}
				class2 = class5399_4;
				class5399_4 = null;
				StartLine = class2.int_1;
				int_13 = class2.int_1;
			}
		}
		else
		{
			class2 = class5399_0;
		}
		return class2;
	}

	protected virtual int vmethod_11(Class5399 restartingNode, int currentIndex)
	{
		restartingNode.double_1 = 0.0;
		vmethod_20(restartingNode.int_1, restartingNode);
		StartLine = restartingNode.int_1;
		int_13 = StartLine + 1;
		int_14 = restartingNode.int_3;
		int_15 = restartingNode.int_4;
		int_16 = restartingNode.int_5;
		class5399_1 = null;
		class5399_0 = null;
		int i;
		for (i = restartingNode.int_0; i + 1 < class5274_0.Count && !method_14(i + 1).vmethod_0(); i++)
		{
		}
		return i;
	}

	protected virtual void vmethod_12(Class5337 element, int elementIdx)
	{
		class5399_2 = null;
		class5399_0 = null;
		for (int i = StartLine; i < int_13; i++)
		{
			for (Class5399 @class = method_16(i); @class != null; @class = @class.class5399_1)
			{
				if (@class.int_0 != elementIdx)
				{
					bool isFloat = false;
					int difference = vmethod_15(@class, element, elementIdx, i, ref isFloat);
					vmethod_13(elementIdx, isFloat, difference, i);
					if (!vmethod_14(element, int_13, difference))
					{
						break;
					}
					double num = vmethod_16(@class, difference);
					int availableShrink = int_16 - @class.int_5;
					int availableStretch = int_15 - @class.int_4;
					if (num < -1.0 || element.vmethod_3())
					{
						method_12(@class, i);
					}
					int fitnessClass = Class5398.smethod_0(num);
					double demerits = vmethod_17(@class, element, fitnessClass, num);
					if (num >= -1.0 && num <= double_0)
					{
						method_11(@class, difference, num, demerits, fitnessClass, availableShrink, availableStretch);
					}
					if (bool_0 && (num <= -1.0 || num > double_0))
					{
						method_10(@class, i, elementIdx, difference, num, demerits, fitnessClass, availableShrink, availableStretch);
					}
				}
			}
			method_13(i, elementIdx);
		}
	}

	protected virtual void vmethod_13(int elementIdx, bool isFloat, int difference, int line)
	{
	}

	protected virtual bool vmethod_14(Class5337 element, int line, int difference)
	{
		if (element.vmethod_2())
		{
			return element.vmethod_5() < Class5337.int_0;
		}
		return true;
	}

	protected void method_10(Class5399 node, int line, int elementIdx, int difference, double r, double demerits, int fitnessClass, int availableShrink, int availableStretch)
	{
		int num = int_14;
		int num2 = int_15;
		int num3 = int_16;
		for (int i = elementIdx; i < class5274_0.Count; i++)
		{
			Class5337 @class = method_14(i);
			if (@class.vmethod_0())
			{
				break;
			}
			if (@class.vmethod_1())
			{
				num += @class.method_4();
				num2 += @class.vmethod_6();
				num3 += @class.vmethod_7();
			}
			else if (@class.vmethod_3() && i != elementIdx)
			{
				break;
			}
		}
		if (r <= -1.0)
		{
			if (class5399_0 == null || demerits < class5399_0.double_1)
			{
				class5399_0 = vmethod_7(elementIdx, line + 1, fitnessClass, num, num2, num3, r, availableShrink, availableStretch, difference, demerits, node);
			}
		}
		else if (class5399_1 == null || demerits <= class5399_1.double_1)
		{
			if (bool_1)
			{
				class5401_0.vmethod_0(demerits, node, r, availableShrink, availableStretch, difference, fitnessClass);
			}
			class5399_1 = vmethod_7(elementIdx, line + 1, fitnessClass, num, num2, num3, r, availableShrink, availableStretch, difference, demerits, node);
		}
	}

	protected void method_11(Class5399 node, int difference, double r, double demerits, int fitnessClass, int availableShrink, int availableStretch)
	{
		if (demerits < class5401_0.method_2(fitnessClass))
		{
			class5401_0.vmethod_0(demerits, node, r, availableShrink, availableStretch, difference, fitnessClass);
			class5399_1 = null;
		}
	}

	protected void method_12(Class5399 node, int line)
	{
		method_15(line, node);
		class5399_2 = vmethod_19(class5399_2, node);
	}

	private void method_13(int line, int elementIdx)
	{
		if (!class5401_0.method_0())
		{
			return;
		}
		int_17 = line;
		int num = int_14;
		int num2 = int_15;
		int num3 = int_16;
		for (int i = elementIdx; i < class5274_0.Count; i++)
		{
			Class5337 @class = method_14(i);
			if (@class.vmethod_0())
			{
				break;
			}
			if (@class.vmethod_1())
			{
				num += @class.method_4();
				num2 += @class.vmethod_6();
				num3 += @class.vmethod_7();
			}
			else if (@class.vmethod_3() && i != elementIdx)
			{
				break;
			}
		}
		double num4 = class5401_0.method_8() + (double)int_6;
		for (int j = 0; j <= 3; j++)
		{
			if (class5401_0.method_1(j) && class5401_0.method_2(j) <= num4)
			{
				Class5399 node = vmethod_8(elementIdx, line + 1, j, num, num2, num3);
				vmethod_20(line + 1, node);
			}
		}
		class5401_0.method_9();
	}

	protected virtual int vmethod_15(Class5399 activeNode, Class5337 element, int elementIndex, int line, ref bool isFloat)
	{
		int num = int_14 - activeNode.int_3;
		if (element.vmethod_2())
		{
			num += element.method_4();
		}
		return vmethod_21(line, elementIndex, ref isFloat) - num;
	}

	protected virtual double vmethod_16(Class5399 activeNode, int difference)
	{
		if (difference > 0)
		{
			int num = int_15 - activeNode.int_4;
			if (num > 0)
			{
				return (double)difference / (double)num;
			}
			return int_0;
		}
		if (difference < 0)
		{
			int num2 = int_16 - activeNode.int_5;
			if (num2 > 0)
			{
				return (double)difference / (double)num2;
			}
			return -int_0;
		}
		return 0.0;
	}

	protected virtual double vmethod_17(Class5399 activeNode, Class5337 element, int fitnessClass, double r)
	{
		double num = 0.0;
		double num2 = Math.Abs(r);
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
			int num4 = 2;
			Class5399 @class = activeNode.class5399_0;
			while (@class != null && num4 <= int_7)
			{
				Class5337 class2 = method_14(@class.int_0);
				if (!class2.vmethod_2() || !((Class5342)class2).method_7())
				{
					break;
				}
				num4++;
				@class = @class.class5399_0;
			}
			if (int_7 >= 1 && num4 > int_7)
			{
				num += double.PositiveInfinity;
			}
		}
		if (Math.Abs(fitnessClass - activeNode.int_2) > 1)
		{
			num += (double)int_6;
		}
		return num + activeNode.double_1;
	}

	protected virtual void vmethod_18()
	{
	}

	internal Class5337 method_14(int idx)
	{
		return (Class5337)class5274_0[idx];
	}

	protected virtual Class5399 vmethod_19(Class5399 node1, Class5399 node2)
	{
		if (node1 != null && node2.int_0 <= node1.int_0)
		{
			if (node2.int_0 == node1.int_0 && node2.double_1 < node1.double_1)
			{
				return node2;
			}
			return node1;
		}
		return node2;
	}

	internal virtual void vmethod_20(int line, Class5399 node)
	{
		int num = line * 2;
		if (num >= class5399_3.Length)
		{
			Class5399[] array = class5399_3;
			class5399_3 = new Class5399[num + num];
			Array.Copy(array, 0, class5399_3, 0, array.Length);
		}
		node.class5399_1 = null;
		if (class5399_3[num + 1] != null)
		{
			class5399_3[num + 1].class5399_1 = node;
		}
		else
		{
			class5399_3[num] = node;
			int_13 = line + 1;
		}
		class5399_3[num + 1] = node;
		int_11++;
	}

	internal void method_15(int line, Class5399 node)
	{
		int num = line * 2;
		Class5399 @class = method_16(line);
		if (@class != node)
		{
			Class5399 class2 = null;
			while (@class != node)
			{
				class2 = @class;
				@class = @class.class5399_1;
			}
			class2.class5399_1 = @class.class5399_1;
			if (class2.class5399_1 == null)
			{
				class5399_3[num + 1] = class2;
			}
		}
		else
		{
			class5399_3[num] = node.class5399_1;
			if (node.class5399_1 == null)
			{
				class5399_3[num + 1] = null;
			}
			while (StartLine < int_13 && method_16(StartLine) == null)
			{
				StartLine++;
			}
		}
		int_11--;
	}

	protected Class5399 method_16(int line)
	{
		return class5399_3[line * 2];
	}

	protected virtual int vmethod_21(int line, int index, ref bool isFloat)
	{
		return int_8;
	}

	internal virtual int vmethod_22()
	{
		return int_8;
	}

	public string method_17(string prepend)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[\n");
		for (int i = StartLine; i < int_13; i++)
		{
			for (Class5399 @class = method_16(i); @class != null; @class = @class.class5399_1)
			{
				stringBuilder.Append(prepend).Append('\t').Append(@class)
					.Append(",\n");
			}
		}
		stringBuilder.Append(prepend).Append("]");
		return stringBuilder.ToString();
	}

	protected abstract int vmethod_23();

	protected void method_18(Class5399 node, Class5274 par, int total)
	{
		Class5399 @class = node;
		for (int num = node.int_1; num > 0; num--)
		{
			vmethod_1(@class, par, total);
			@class = @class.class5399_0;
		}
	}

	public int method_19()
	{
		return int_9;
	}

	public int method_20()
	{
		return int_10;
	}
}
