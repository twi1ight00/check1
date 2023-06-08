using System;
using ns205;

namespace ns196;

internal class Class5396 : Class5395
{
	private int int_25;

	private int int_26;

	private int int_27;

	public Class5396(Interface173 topLevelLM, Class5691 pageProvider, Interface183 layoutListener, int alignment, int alignmentLast, Class5746 footnoteSeparatorLength, Class5746 floatSeparatorLength, bool partOverflowRecovery, int columnCount)
		: base(topLevelLM, pageProvider, layoutListener, alignment, alignmentLast, footnoteSeparatorLength, floatSeparatorLength, partOverflowRecovery, autoHeight: false, favorSinglePart: false)
	{
		int_25 = columnCount;
		bool_1 = true;
	}

	protected override double vmethod_17(Class5399 activeNode, Class5337 element, int fitnessClass, double r)
	{
		double num = base.vmethod_17(activeNode, element, fitnessClass, r);
		int num2 = int_25 - activeNode.int_1;
		int num3 = class5274_0.IndexOf(element);
		if (int_26 == 0)
		{
			int_26 = Class5683.smethod_4(class5274_0, activeNode.int_0, class5274_0.Count - 1);
			int_27 = int_26 / int_25;
		}
		int num4 = Class5683.smethod_4(class5274_0, activeNode.int_0, num3 - 1);
		int num5 = Class5683.smethod_4(class5274_0, num3 - 1, class5274_0.Count - 1);
		int num6 = 0;
		if (num2 > 0)
		{
			num6 = num5 / num2;
		}
		double num7 = (float)(int_27 - num4) / 1000f;
		double num8 = Math.Abs(num7);
		num = num8;
		if (int_25 > 2)
		{
			if (num7 > 0.0)
			{
				num *= 1.2000000476837158;
			}
		}
		else if (num7 < 0.0)
		{
			num *= 1.2000000476837158;
		}
		num += (double)((float)num6 / 1000f);
		if (activeNode.int_1 >= int_25)
		{
			num = double.MaxValue;
		}
		return num;
	}
}
