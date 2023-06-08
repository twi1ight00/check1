using Aspose.Cells.Charts;
using ns7;

namespace ns16;

internal class Class1532
{
	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal bool bool_3;

	internal bool bool_4;

	internal bool bool_5;

	internal bool bool_6;

	internal bool bool_7;

	internal bool bool_8;

	internal bool bool_9;

	internal void method_0(Class1387 class1387_0)
	{
		ChartType chartType_ = class1387_0.method_11();
		if (ChartCollection.smethod_3(chartType_) || ChartCollection.smethod_13(chartType_))
		{
			return;
		}
		bool_8 = true;
		bool flag = ((!class1387_0.PlotOnSecondAxis) ? true : false);
		string grouping = null;
		if (!ChartCollection.smethod_7(chartType_) && !ChartCollection.smethod_10(chartType_))
		{
			if (ChartCollection.smethod_14(chartType_))
			{
				grouping = Class1618.smethod_114(class1387_0.method_11());
			}
			else if (ChartCollection.smethod_17(chartType_) || ChartCollection.smethod_11(chartType_))
			{
				if (flag)
				{
					bool_4 = true;
				}
				else
				{
					bool_5 = true;
				}
			}
		}
		else
		{
			string barDir = null;
			Class1618.smethod_110(class1387_0.method_11(), out barDir, out grouping);
			if (barDir == "bar")
			{
				if (flag)
				{
					bool_2 = true;
				}
				else
				{
					bool_3 = true;
				}
			}
		}
		if (grouping == "percentStacked")
		{
			if (flag)
			{
				bool_6 = true;
			}
			else
			{
				bool_7 = true;
			}
		}
		if (flag)
		{
			bool_0 = true;
		}
		else
		{
			bool_1 = true;
		}
		if (ChartCollection.smethod_6(chartType_))
		{
			bool_9 = true;
		}
	}
}
