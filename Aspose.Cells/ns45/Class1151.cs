using System;
using System.Collections;
using Aspose.Cells;

namespace ns45;

internal class Class1151
{
	internal static object smethod_0(ConsolidationFunction consolidationFunction_0, int int_0, ArrayList arrayList_0, bool bool_0)
	{
		if (int_0 == 0 && !bool_0)
		{
			return null;
		}
		return consolidationFunction_0 switch
		{
			ConsolidationFunction.Sum => smethod_1(arrayList_0), 
			ConsolidationFunction.Count => int_0, 
			ConsolidationFunction.Average => smethod_4(arrayList_0, bool_0), 
			ConsolidationFunction.Max => smethod_2(arrayList_0), 
			ConsolidationFunction.Min => smethod_3(arrayList_0), 
			ConsolidationFunction.Product => smethod_5(arrayList_0), 
			ConsolidationFunction.CountNums => arrayList_0.Count, 
			ConsolidationFunction.StdDev => smethod_7(arrayList_0), 
			ConsolidationFunction.StdDevp => smethod_6(arrayList_0), 
			ConsolidationFunction.Var => smethod_9(arrayList_0), 
			ConsolidationFunction.Varp => smethod_8(arrayList_0), 
			_ => null, 
		};
	}

	private static double smethod_1(ArrayList arrayList_0)
	{
		double num = 0.0;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			num += (double)arrayList_0[i];
		}
		return num;
	}

	private static double smethod_2(ArrayList arrayList_0)
	{
		double num = (double)arrayList_0[0];
		for (int i = 1; i < arrayList_0.Count; i++)
		{
			if ((double)arrayList_0[i] > num)
			{
				num = (double)arrayList_0[i];
			}
		}
		return num;
	}

	private static double smethod_3(ArrayList arrayList_0)
	{
		double num = (double)arrayList_0[0];
		for (int i = 1; i < arrayList_0.Count; i++)
		{
			if ((double)arrayList_0[i] < num)
			{
				num = (double)arrayList_0[i];
			}
		}
		return num;
	}

	private static object smethod_4(ArrayList arrayList_0, bool bool_0)
	{
		if (arrayList_0.Count == 0 && !bool_0)
		{
			return 0;
		}
		if (arrayList_0.Count == 0 && bool_0)
		{
			return "#DIV/0!";
		}
		double num = 0.0;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			_ = arrayList_0[i];
			num += (double)arrayList_0[i];
		}
		return num / (double)arrayList_0.Count;
	}

	private static double smethod_5(ArrayList arrayList_0)
	{
		if (arrayList_0.Count == 0)
		{
			return 0.0;
		}
		double num = 1.0;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			num *= (double)arrayList_0[i];
		}
		return num;
	}

	private static object smethod_6(ArrayList arrayList_0)
	{
		if (arrayList_0.Count < 1)
		{
			return "#DIV/0!";
		}
		double num = 0.0;
		double num2 = 0.0;
		int count = arrayList_0.Count;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			double num3 = (double)arrayList_0[i];
			num += num3;
			num2 += num3 * num3;
		}
		return Math.Sqrt(((double)count * num2 - num * num) / (double)(count * count));
	}

	private static object smethod_7(ArrayList arrayList_0)
	{
		if (arrayList_0.Count < 2)
		{
			return "#DIV/0!";
		}
		double num = 0.0;
		double num2 = 0.0;
		double num3 = arrayList_0.Count;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			double num4 = (double)arrayList_0[i];
			num += num4;
			num2 += num4 * num4;
		}
		return Math.Sqrt((num3 * num2 - num * num) / (num3 * (num3 - 1.0)));
	}

	private static object smethod_8(ArrayList arrayList_0)
	{
		if (arrayList_0.Count < 1)
		{
			return "#DIV/0!";
		}
		double num = 0.0;
		double num2 = 0.0;
		int count = arrayList_0.Count;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			double num3 = (double)arrayList_0[i];
			num += num3;
			num2 += num3 * num3;
		}
		return ((double)count * num2 - num * num) / (double)(count * count);
	}

	private static object smethod_9(ArrayList arrayList_0)
	{
		if (arrayList_0.Count < 2)
		{
			return "#DIV/0!";
		}
		double num = 0.0;
		double num2 = 0.0;
		double num3 = arrayList_0.Count;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			double num4 = (double)arrayList_0[i];
			num += num4;
			num2 += num4 * num4;
		}
		return (num3 * num2 - num * num) / (num3 * (num3 - 1.0));
	}
}
