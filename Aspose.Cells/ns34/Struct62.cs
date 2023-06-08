using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct62
{
	internal static void smethod_0(Class821 class821_0)
	{
		Class842 @class = class821_0.method_7();
		foreach (Class844 item in @class)
		{
			if (item.method_10().Count == 0)
			{
				continue;
			}
			Class823 categoryAxis = ((!item.PlotOnSecondAxis) ? class821_0.method_1() : class821_0.method_2());
			for (int i = 0; i < item.method_10().Count; i++)
			{
				smethod_12(item, categoryAxis, out var y, out var x);
				double R = 0.0;
				Class850 class3 = item.method_10().method_1(i);
				if (class3.method_1().IsVisible && x.Length >= 2 && y.Length >= 2)
				{
					switch (class3.Type)
					{
					case Enum88.const_0:
						class3.method_5(smethod_19(y, x, class3.method_2(), class3.Intercept, out R));
						break;
					case Enum88.const_1:
						class3.method_5(smethod_15(y, x, class3.method_2(), class3.Intercept, out R));
						break;
					case Enum88.const_2:
						class3.method_5(smethod_18(y, x, out R));
						break;
					case Enum88.const_4:
						class3.method_5(smethod_16(y, x, class3.Order, class3.method_2(), class3.Intercept, out R));
						break;
					case Enum88.const_5:
						class3.method_5(smethod_17(y, x, out R));
						break;
					}
					class3.method_7(R);
				}
			}
		}
	}

	internal static void smethod_1(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		for (int i = 0; i < class844_0.method_10().Count; i++)
		{
			Class850 @class = class844_0.method_10().method_1(i);
			if (@class.method_1().IsVisible && smethod_14(@class.method_4()))
			{
				switch (@class.Type)
				{
				case Enum88.const_1:
					smethod_2(interface42_0, class844_0, rectangle_0, float_0, double_0, @class);
					break;
				case Enum88.const_3:
					smethod_4(interface42_0, class844_0, rectangle_0, float_0, double_0, @class);
					break;
				case Enum88.const_0:
				case Enum88.const_2:
				case Enum88.const_4:
				case Enum88.const_5:
					smethod_3(interface42_0, class844_0, rectangle_0, float_0, double_0, @class);
					break;
				}
			}
		}
	}

	private static void smethod_2(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0, Class850 class850_0)
	{
		if (class850_0.method_1().IsVisible)
		{
			Class821 chart = class844_0.Chart;
			Enum53 @enum = class844_0.method_20();
			Class823 @class;
			Class823 class2;
			if (@enum == Enum53.const_0)
			{
				@class = chart.method_1();
				class2 = chart.method_9();
			}
			else
			{
				@class = chart.method_2();
				class2 = chart.method_10();
			}
			smethod_13(class844_0, class850_0, out var minValue, out var maxValue);
			double num = (class2.IsLogarithmic ? class2.method_6(class2.MinValue) : class2.MinValue);
			double num2 = (class2.IsLogarithmic ? class2.method_6(class2.MaxValue) : class2.MaxValue);
			double_0 = (class2.IsLogarithmic ? class2.method_6(double_0) : double_0);
			double num3 = 0.0;
			double num4 = (@class.IsLogarithmic ? @class.method_6(@class.MajorUnit) : @class.MajorUnit);
			double num5 = (@class.IsLogarithmic ? @class.method_6(@class.MaxValue) : @class.MaxValue);
			double num6 = (@class.IsLogarithmic ? @class.method_6(@class.MinValue) : @class.MinValue);
			if (@class.CategoryType == Enum64.const_2)
			{
				num4 = Struct44.smethod_31(Enum87.const_0, @class.MajorUnitScale, (int)@class.MajorUnit, 0, class844_0.Chart.vmethod_0());
			}
			double num7;
			double num8;
			if (!@class.AxisBetweenCategories && !chart.IsDataTableShown)
			{
				num3 = num5 - num6;
				num7 = minValue - num6;
				num8 = maxValue - num6;
			}
			else
			{
				num3 = num5 - num6 + num4;
				num7 = minValue - num6 + num4 / 2.0;
				num8 = maxValue - num6 + num4 - num4 / 2.0;
			}
			double num9 = (double)rectangle_0.Width / num3;
			double num10 = num7 * num9;
			num10 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.Left + num10) : ((double)rectangle_0.Right - num10));
			double num11 = float_0;
			double num12 = smethod_10(class850_0, minValue);
			double num13 = (num12 - double_0) / (num2 - num) * (double)rectangle_0.Height;
			num11 = (class2.IsPlotOrderReversed ? (num11 + num13) : (num11 - num13));
			double num14 = num8 * num9;
			num14 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.Left + num14) : ((double)rectangle_0.Right - num14));
			double num15 = float_0;
			double num16 = smethod_10(class850_0, maxValue);
			double num17 = (num16 - double_0) / (num2 - num) * (double)rectangle_0.Height;
			num15 = (class2.IsPlotOrderReversed ? (num15 + num17) : (num15 - num17));
			class850_0.method_1().method_7((float)num10, (float)num11, (float)num14, (float)num15);
			class850_0.pointF_0 = new PointF((float)num14, (float)num15);
		}
	}

	private static void smethod_3(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0, Class850 class850_0)
	{
		if (class850_0.method_1().IsVisible)
		{
			Class821 chart = class844_0.Chart;
			Enum53 @enum = class844_0.method_20();
			Class823 @class;
			Class823 class2;
			if (@enum == Enum53.const_0)
			{
				@class = chart.method_1();
				class2 = chart.method_9();
			}
			else
			{
				@class = chart.method_2();
				class2 = chart.method_10();
			}
			double num = (class2.IsLogarithmic ? class2.method_6(class2.MinValue) : class2.MinValue);
			double num2 = (class2.IsLogarithmic ? class2.method_6(class2.MaxValue) : class2.MaxValue);
			double_0 = (class2.IsLogarithmic ? class2.method_6(double_0) : double_0);
			smethod_13(class844_0, class850_0, out var minValue, out var maxValue);
			double num3 = 0.0;
			double num4 = (@class.IsLogarithmic ? @class.method_6(@class.MajorUnit) : @class.MajorUnit);
			double num5 = (@class.IsLogarithmic ? @class.method_6(@class.MaxValue) : @class.MaxValue);
			double num6 = (@class.IsLogarithmic ? @class.method_6(@class.MinValue) : @class.MinValue);
			if (@class.CategoryType == Enum64.const_2)
			{
				num4 = Struct44.smethod_31(Enum87.const_0, @class.MajorUnitScale, (int)@class.MajorUnit, 0, class844_0.Chart.vmethod_0());
			}
			num3 = ((@class.AxisBetweenCategories || chart.IsDataTableShown) ? (num5 - num6 + num4) : (num5 - num6));
			IList list = new ArrayList();
			double num7 = num3 / (double)rectangle_0.Width;
			double num8 = ((minValue < num6) ? num6 : minValue);
			double num9 = ((maxValue > num5) ? num5 : maxValue);
			for (double num10 = num8; num10 <= num9; num10 += num7)
			{
				double num11 = ((@class.AxisBetweenCategories || chart.IsDataTableShown) ? ((num10 - num6 + num4 / 2.0) * (double)rectangle_0.Width / num3) : ((num10 - num6) * (double)rectangle_0.Width / num3));
				num11 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.Left + num11) : ((double)rectangle_0.Right - num11));
				double num12 = float_0;
				double num13 = smethod_10(class850_0, num10);
				double num14 = (num13 - double_0) / (num2 - num) * (double)rectangle_0.Height;
				num12 = (class2.IsPlotOrderReversed ? (num12 + num14) : (num12 - num14));
				PointF pointF = new PointF((float)num11, (float)num12);
				list.Add(pointF);
			}
			smethod_11(interface42_0, list, class850_0, bool_0: true);
			if (list.Count > 0)
			{
				class850_0.pointF_0 = (PointF)list[list.Count - 1];
			}
		}
	}

	private static void smethod_4(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0, Class850 class850_0)
	{
		if (!class850_0.method_1().IsVisible)
		{
			return;
		}
		Class821 chart = class844_0.Chart;
		Enum53 @enum = class844_0.method_20();
		Class823 @class;
		Class823 class2;
		if (@enum == Enum53.const_0)
		{
			@class = chart.method_1();
			class2 = chart.method_9();
		}
		else
		{
			@class = chart.method_2();
			class2 = chart.method_10();
		}
		double num = (class2.IsLogarithmic ? class2.method_6(class2.MinValue) : class2.MinValue);
		double num2 = (class2.IsLogarithmic ? class2.method_6(class2.MaxValue) : class2.MaxValue);
		double_0 = (class2.IsLogarithmic ? class2.method_6(double_0) : double_0);
		smethod_13(class844_0, class850_0, out var _, out var _);
		double num3 = 0.0;
		double num4 = (@class.IsLogarithmic ? @class.method_6(@class.MajorUnit) : @class.MajorUnit);
		double num5 = (@class.IsLogarithmic ? @class.method_6(@class.MaxValue) : @class.MaxValue);
		double num6 = (@class.IsLogarithmic ? @class.method_6(@class.MinValue) : @class.MinValue);
		if (@class.CategoryType == Enum64.const_2)
		{
			num4 = Struct44.smethod_31(Enum87.const_0, @class.MajorUnitScale, (int)@class.MajorUnit, 0, class844_0.Chart.vmethod_0());
		}
		num3 = ((@class.AxisBetweenCategories || chart.IsDataTableShown) ? (num5 - num6 + num4) : (num5 - num6));
		double num7 = (double)rectangle_0.Width / num3;
		IList list = new ArrayList();
		Class830 class3 = class844_0.method_9();
		ArrayList arrayList = class3.method_3();
		for (int i = class850_0.Period - 1; i < arrayList.Count; i++)
		{
			Class831 class4 = (Class831)arrayList[i];
			if (!smethod_9(i, class850_0.Period, arrayList, out var average))
			{
				double num8 = ((@class.AxisBetweenCategories || chart.IsDataTableShown) ? ((class4.XValue - num6 + num4 / 2.0) * num7) : ((class4.XValue - num6) * num7));
				num8 = ((!@class.IsPlotOrderReversed) ? ((double)rectangle_0.Left + num8) : ((double)rectangle_0.Right - num8));
				double num9 = float_0;
				double num10 = (average - double_0) / (num2 - num) * (double)rectangle_0.Height;
				num9 = (class2.IsPlotOrderReversed ? (num9 + num10) : (num9 - num10));
				PointF pointF = new PointF((float)num8, (float)num9);
				list.Add(pointF);
			}
		}
		smethod_11(interface42_0, list, class850_0, bool_0: false);
	}

	internal static void smethod_5(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		for (int i = 0; i < class844_0.method_10().Count; i++)
		{
			Class850 @class = class844_0.method_10().method_1(i);
			if (@class.method_1().IsVisible && smethod_14(@class.method_4()))
			{
				switch (@class.Type)
				{
				case Enum88.const_1:
					smethod_6(interface42_0, class844_0, rectangle_0, float_0, double_0, @class);
					break;
				case Enum88.const_3:
					smethod_8(interface42_0, class844_0, rectangle_0, float_0, double_0, @class);
					break;
				case Enum88.const_0:
				case Enum88.const_2:
				case Enum88.const_4:
				case Enum88.const_5:
					smethod_7(interface42_0, class844_0, rectangle_0, float_0, double_0, @class);
					break;
				}
			}
		}
	}

	private static void smethod_6(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0, Class850 class850_0)
	{
		if (class850_0.method_1().IsVisible)
		{
			Class821 chart = class844_0.Chart;
			Enum53 @enum = class844_0.method_20();
			Class823 @class;
			Class823 class2;
			if (@enum == Enum53.const_0)
			{
				@class = chart.method_1();
				class2 = chart.method_9();
			}
			else
			{
				@class = chart.method_2();
				class2 = chart.method_10();
			}
			smethod_13(class844_0, class850_0, out var minValue, out var maxValue);
			double num = (class2.IsLogarithmic ? class2.method_6(class2.MinValue) : class2.MinValue);
			double num2 = (class2.IsLogarithmic ? class2.method_6(class2.MaxValue) : class2.MaxValue);
			double_0 = (class2.IsLogarithmic ? class2.method_6(double_0) : double_0);
			double num3 = 0.0;
			double num4 = (@class.IsLogarithmic ? @class.method_6(@class.MajorUnit) : @class.MajorUnit);
			double num5 = (@class.IsLogarithmic ? @class.method_6(@class.MaxValue) : @class.MaxValue);
			double num6 = (@class.IsLogarithmic ? @class.method_6(@class.MinValue) : @class.MinValue);
			if (@class.CategoryType == Enum64.const_2)
			{
				num4 = Struct44.smethod_31(Enum87.const_0, @class.MajorUnitScale, (int)@class.MajorUnit, 0, class844_0.Chart.vmethod_0());
			}
			double num7;
			double num8;
			if (!@class.AxisBetweenCategories && !chart.IsDataTableShown)
			{
				num3 = num5 - num6;
				num7 = minValue - num6;
				num8 = maxValue - num6;
			}
			else
			{
				num3 = num5 - num6 + num4;
				num7 = minValue - num6 + num4 / 2.0;
				num8 = maxValue - num6 + num4 - num4 / 2.0;
			}
			double num9 = (double)rectangle_0.Height / num3;
			double num10 = num7 * num9;
			num10 = (@class.IsPlotOrderReversed ? ((double)rectangle_0.Top + num10) : ((double)rectangle_0.Bottom - num10));
			double num11 = float_0;
			double num12 = smethod_10(class850_0, minValue);
			double num13 = (num12 - double_0) / (num2 - num) * (double)rectangle_0.Width;
			num11 = (class2.IsPlotOrderReversed ? (num11 - num13) : (num11 + num13));
			double num14 = num8 * num9;
			num14 = (@class.IsPlotOrderReversed ? ((double)rectangle_0.Top + num14) : ((double)rectangle_0.Bottom - num14));
			double num15 = float_0;
			double num16 = smethod_10(class850_0, maxValue);
			double num17 = (num16 - double_0) / (num2 - num) * (double)rectangle_0.Width;
			num15 = (class2.IsPlotOrderReversed ? (num15 - num17) : (num15 + num17));
			class850_0.method_1().method_7((float)num11, (float)num10, (float)num15, (float)num14);
			class850_0.pointF_0 = new PointF((float)num15, (float)num14);
		}
	}

	private static void smethod_7(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0, Class850 class850_0)
	{
		if (class850_0.method_1().IsVisible)
		{
			Class821 chart = class844_0.Chart;
			Enum53 @enum = class844_0.method_20();
			Class823 @class;
			Class823 class2;
			if (@enum == Enum53.const_0)
			{
				@class = chart.method_1();
				class2 = chart.method_9();
			}
			else
			{
				@class = chart.method_2();
				class2 = chart.method_10();
			}
			double num = (class2.IsLogarithmic ? class2.method_6(class2.MinValue) : class2.MinValue);
			double num2 = (class2.IsLogarithmic ? class2.method_6(class2.MaxValue) : class2.MaxValue);
			double_0 = (class2.IsLogarithmic ? class2.method_6(double_0) : double_0);
			smethod_13(class844_0, class850_0, out var minValue, out var maxValue);
			double num3 = 0.0;
			double num4 = (@class.IsLogarithmic ? @class.method_6(@class.MajorUnit) : @class.MajorUnit);
			double num5 = (@class.IsLogarithmic ? @class.method_6(@class.MaxValue) : @class.MaxValue);
			double num6 = (@class.IsLogarithmic ? @class.method_6(@class.MinValue) : @class.MinValue);
			if (@class.CategoryType == Enum64.const_2)
			{
				num4 = Struct44.smethod_31(Enum87.const_0, @class.MajorUnitScale, (int)@class.MajorUnit, 0, class844_0.Chart.vmethod_0());
			}
			num3 = ((@class.AxisBetweenCategories || chart.IsDataTableShown) ? (num5 - num6 + num4) : (num5 - num6));
			IList list = new ArrayList();
			double num7 = num3 / (double)rectangle_0.Height;
			for (double num8 = minValue; num8 <= maxValue; num8 += num7)
			{
				double num9 = ((@class.AxisBetweenCategories || chart.IsDataTableShown) ? ((num8 - num6 + num4 / 2.0) * (double)rectangle_0.Height / num3) : ((num8 - num6) * (double)rectangle_0.Height / num3));
				num9 = (@class.IsPlotOrderReversed ? ((double)rectangle_0.Top + num9) : ((double)rectangle_0.Bottom - num9));
				double num10 = float_0;
				double num11 = smethod_10(class850_0, num8);
				double num12 = (num11 - double_0) / (num2 - num) * (double)rectangle_0.Width;
				num10 = (class2.IsPlotOrderReversed ? (num10 - num12) : (num10 + num12));
				PointF pointF = new PointF((float)num10, (float)num9);
				list.Add(pointF);
			}
			smethod_11(interface42_0, list, class850_0, bool_0: true);
			if (list.Count > 0)
			{
				class850_0.pointF_0 = (PointF)list[list.Count - 1];
			}
		}
	}

	private static void smethod_8(Interface42 interface42_0, Class844 class844_0, Rectangle rectangle_0, float float_0, double double_0, Class850 class850_0)
	{
		if (!class850_0.method_1().IsVisible)
		{
			return;
		}
		Class821 chart = class844_0.Chart;
		Enum53 @enum = class844_0.method_20();
		Class823 @class;
		Class823 class2;
		if (@enum == Enum53.const_0)
		{
			@class = chart.method_1();
			class2 = chart.method_9();
		}
		else
		{
			@class = chart.method_2();
			class2 = chart.method_10();
		}
		double num = (class2.IsLogarithmic ? class2.method_6(class2.MinValue) : class2.MinValue);
		double num2 = (class2.IsLogarithmic ? class2.method_6(class2.MaxValue) : class2.MaxValue);
		double_0 = (class2.IsLogarithmic ? class2.method_6(double_0) : double_0);
		smethod_13(class844_0, class850_0, out var _, out var _);
		double num3 = 0.0;
		double num4 = (@class.IsLogarithmic ? @class.method_6(@class.MajorUnit) : @class.MajorUnit);
		double num5 = (@class.IsLogarithmic ? @class.method_6(@class.MaxValue) : @class.MaxValue);
		double num6 = (@class.IsLogarithmic ? @class.method_6(@class.MinValue) : @class.MinValue);
		if (@class.CategoryType == Enum64.const_2)
		{
			num4 = Struct44.smethod_31(Enum87.const_0, @class.MajorUnitScale, (int)@class.MajorUnit, 0, class844_0.Chart.vmethod_0());
		}
		num3 = ((@class.AxisBetweenCategories || chart.IsDataTableShown) ? (num5 - num6 + num4) : (num5 - num6));
		double num7 = (double)rectangle_0.Height / num3;
		IList list = new ArrayList();
		Class830 class3 = class844_0.method_9();
		ArrayList arrayList = class3.method_3();
		for (int i = class850_0.Period - 1; i < arrayList.Count; i++)
		{
			Class831 class4 = (Class831)arrayList[i];
			if (!smethod_9(i, class850_0.Period, arrayList, out var average))
			{
				double num8 = ((@class.AxisBetweenCategories || chart.IsDataTableShown) ? ((class4.XValue - num6 + num4 / 2.0) * num7) : ((class4.XValue - num6) * num7));
				num8 = (@class.IsPlotOrderReversed ? ((double)rectangle_0.Top + num8) : ((double)rectangle_0.Bottom - num8));
				double num9 = float_0;
				double num10 = (average - double_0) / (num2 - num) * (double)rectangle_0.Width;
				num9 = (class2.IsPlotOrderReversed ? (num9 - num10) : (num9 + num10));
				PointF pointF = new PointF((float)num9, (float)num8);
				list.Add(pointF);
			}
		}
		smethod_11(interface42_0, list, class850_0, bool_0: false);
	}

	private static bool smethod_9(int pointIndex, int period, ArrayList points, out double average)
	{
		double num = 0.0;
		int num2 = 0;
		for (int i = pointIndex - period + 1; i <= pointIndex; i++)
		{
			Class831 @class = (Class831)points[i];
			if (@class != null && !@class.imethod_0())
			{
				num += @class.YValue;
			}
			else
			{
				num2++;
			}
		}
		if (period == num2)
		{
			average = 0.0;
			return true;
		}
		average = num / (double)(period - num2);
		return false;
	}

	private static double smethod_10(Class850 class850_0, double double_0)
	{
		double[] array = class850_0.method_4();
		switch (class850_0.Type)
		{
		case Enum88.const_0:
			return array[1] * Math.Pow(Math.E, array[0] * double_0);
		case Enum88.const_1:
			return array[0] * double_0 + array[1];
		case Enum88.const_2:
			return array[0] * Math.Log(double_0) + array[1];
		default:
			return 0.0;
		case Enum88.const_4:
		{
			double num = 0.0;
			for (int i = 0; i < array.Length; i++)
			{
				num += array[i] * Math.Pow(double_0, array.Length - 1 - i);
			}
			return num;
		}
		case Enum88.const_5:
			return array[1] * Math.Pow(double_0, array[0]);
		}
	}

	internal static void smethod_11(Interface42 interface42_0, IList ilist_0, Class850 class850_0, bool bool_0)
	{
		PointF[] array = new PointF[ilist_0.Count];
		ilist_0.CopyTo(array, 0);
		if (array.Length > 1)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (bool_0)
			{
				graphicsPath.AddCurve(array);
			}
			else
			{
				graphicsPath.AddPolygon(array);
			}
			class850_0.method_1().method_11(graphicsPath);
		}
	}

	private static void smethod_12(Class844 aSeries, Class823 categoryAxis, out double[] y, out double[] x)
	{
		double num = 2147483647.0;
		for (int i = 0; i < aSeries.method_9().Count; i++)
		{
			Class831 @class = aSeries.method_9().method_1(i);
			if (@class != null && !@class.imethod_0() && !@class.imethod_2() && @class.XValue < num)
			{
				num = @class.XValue;
			}
		}
		int num2 = aSeries.method_9().Count;
		for (int j = 0; j < aSeries.method_9().Count; j++)
		{
			Class831 class2 = aSeries.method_9().method_1(j);
			if (class2 == null || class2.imethod_0() || class2.imethod_2())
			{
				num2--;
			}
		}
		y = new double[num2];
		x = new double[num2];
		int num3 = 0;
		for (int k = 0; k < aSeries.method_9().Count; k++)
		{
			Class831 class3 = aSeries.method_9().method_1(k);
			if (class3 != null && !class3.imethod_0() && !class3.imethod_2())
			{
				y[num3] = class3.YValue;
				if (class3.imethod_2())
				{
					x[num3] = num;
				}
				else
				{
					x[num3] = class3.XValue;
				}
				num3++;
			}
		}
	}

	private static void smethod_13(Class844 series, Class850 trendLine, out double minValue, out double maxValue)
	{
		minValue = 2147483647.0;
		maxValue = -2147483648.0;
		Class830 @class = series.method_9();
		bool flag = true;
		for (int i = 0; i < @class.Count; i++)
		{
			if (@class[i] != null && !@class[i].imethod_2())
			{
				double xValue = @class[i].XValue;
				if (flag)
				{
					minValue = xValue;
					maxValue = xValue;
					flag = false;
				}
				if (xValue < minValue)
				{
					minValue = xValue;
				}
				if (xValue > maxValue)
				{
					maxValue = xValue;
				}
			}
		}
		if (flag)
		{
			minValue = 0.0;
			maxValue = 0.0;
		}
		minValue -= trendLine.Backward;
		maxValue += trendLine.Forward;
	}

	private static bool smethod_14(double[] double_0)
	{
		if (double_0 == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < double_0.Length)
			{
				double d = double_0[num];
				if (double.IsNaN(d))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	private static double[] smethod_15(double[] y, double[] x, bool isSetIntercept, double intercept, out double R)
	{
		double[][] array = new double[y.Length][];
		for (int i = 0; i < y.Length; i++)
		{
			array[i] = new double[1] { x[i] };
		}
		object[][] array2 = null;
		if (isSetIntercept)
		{
			for (int j = 0; j < y.Length; j++)
			{
				y[j] -= intercept;
			}
			array2 = Class862.smethod_1(y, array);
		}
		else
		{
			array2 = Class862.smethod_0(y, array);
		}
		double[] array3 = new double[array2[0].Length];
		for (int k = 0; k < array3.Length; k++)
		{
			array3[k] = (double)array2[0][k];
			if (k == array3.Length - 1 && isSetIntercept)
			{
				array3[k] = intercept;
			}
		}
		R = (double)array2[2][0];
		return array3;
	}

	private static double[] smethod_16(double[] y, double[] x, int order, bool isSetIntercept, double intercept, out double R)
	{
		double[][] array = new double[x.Length][];
		if (order > x.Length - 1)
		{
			order = x.Length - 1;
		}
		for (int i = 0; i < x.Length; i++)
		{
			array[i] = new double[order];
			array[i][0] = x[i];
			for (int j = 1; j < order; j++)
			{
				array[i][j] = x[i] * array[i][j - 1];
			}
		}
		object[][] array2 = null;
		if (isSetIntercept)
		{
			for (int k = 0; k < y.Length; k++)
			{
				y[k] -= intercept;
			}
			array2 = Class862.smethod_1(y, array);
		}
		else
		{
			array2 = Class862.smethod_0(y, array);
		}
		double[] array3 = new double[array2[0].Length];
		for (int l = 0; l < array3.Length; l++)
		{
			array3[l] = (double)array2[0][l];
			if (l == array3.Length - 1 && isSetIntercept)
			{
				array3[l] = intercept;
			}
		}
		R = (double)array2[2][0];
		return array3;
	}

	private static double[] smethod_17(double[] y, double[] x, out double R)
	{
		for (int i = 0; i < y.Length; i++)
		{
			y[i] = Math.Log(y[i]);
			x[i] = Math.Log(x[i]);
		}
		double[] array = smethod_15(y, x, isSetIntercept: false, 0.0, out R);
		array[1] = Math.Exp(array[1]);
		return array;
	}

	private static double[] smethod_18(double[] y, double[] x, out double R)
	{
		for (int i = 0; i < y.Length; i++)
		{
			x[i] = Math.Log(x[i]);
		}
		return smethod_15(y, x, isSetIntercept: false, 0.0, out R);
	}

	private static double[] smethod_19(double[] y, double[] x, bool isSetIntercept, double intercept, out double R)
	{
		for (int i = 0; i < y.Length; i++)
		{
			y[i] = Math.Log(y[i]);
		}
		double intercept2 = 0.0;
		if (isSetIntercept)
		{
			intercept2 = Math.Log(intercept);
		}
		double[] array = smethod_15(y, x, isSetIntercept, intercept2, out R);
		if (isSetIntercept)
		{
			array[1] = intercept;
		}
		else
		{
			array[1] = Math.Exp(array[1]);
		}
		return array;
	}

	internal static void smethod_20(Interface42 interface42_0, Class844 class844_0)
	{
		bool flag = false;
		if (class844_0.method_22() == ChartType_Chart.Bar || class844_0.method_22() == ChartType_Chart.BarStacked || class844_0.method_22() == ChartType_Chart.Bar100PercentStacked)
		{
			flag = true;
		}
		for (int i = 0; i < class844_0.method_10().Count; i++)
		{
			Class850 @class = class844_0.method_10().method_1(i);
			if (!@class.method_1().IsVisible || !smethod_14(@class.method_4()))
			{
				continue;
			}
			string text = null;
			if (@class.method_3().Text == null)
			{
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				if (@class.DisplayEquation)
				{
					double[] array = @class.method_4();
					string[] array2 = smethod_22(class844_0.Chart, @class.method_4(), @class);
					switch (@class.Type)
					{
					case Enum88.const_0:
						text = "y = ";
						if (array[1] < 0.0)
						{
							text += " -";
						}
						text = ((Math.Abs(array[1]) != 1.0) ? (text + array2[1] + "e") : (text + "e"));
						arrayList.Add(text);
						text = "";
						if (array[0] < 0.0)
						{
							text += " - ";
						}
						text = ((Math.Abs(array[0]) != 1.0) ? (text + array2[0] + "x") : (text + "x"));
						arrayList.Add(text);
						break;
					case Enum88.const_1:
						text = "y = ";
						if (array[0] < 0.0)
						{
							text += " -";
						}
						text = ((Math.Abs(array[0]) != 1.0) ? (text + array2[0] + "x") : (text + "x"));
						if (array[1] != 0.0)
						{
							if (array[1] > 0.0)
							{
								text += " + ";
							}
							else if (array[1] < 0.0)
							{
								text += " - ";
							}
							text += array2[1];
						}
						arrayList.Add(text);
						break;
					case Enum88.const_2:
						text = "y = ";
						if (array[0] < 0.0)
						{
							text += " -";
						}
						text = ((Math.Abs(array[0]) != 1.0) ? (text + array2[0] + "Ln(x)") : (text + "x"));
						if (array[1] != 0.0)
						{
							if (array[1] > 0.0)
							{
								text += " + ";
							}
							else if (array[1] < 0.0)
							{
								text += " - ";
							}
							text += array2[1];
							arrayList.Add(text);
						}
						break;
					case Enum88.const_4:
						text = "y = ";
						if (array[0] != 0.0)
						{
							if (array[0] < 0.0)
							{
								text += " -";
							}
							text = ((Math.Abs(array[0]) != 1.0) ? (text + array2[0] + "x") : (text + "x"));
							arrayList.Add(text);
							arrayList.Add("2");
						}
						text = "";
						if (array[1] != 0.0)
						{
							text = ((!(array[1] < 0.0)) ? (text + " + ") : (text + " - "));
							text = ((Math.Abs(array[1]) != 1.0) ? (text + array2[1] + "x") : (text + "x"));
						}
						if (array[2] != 0.0)
						{
							if (array[2] > 0.0)
							{
								text += " + ";
							}
							else if (array[2] < 0.0)
							{
								text += " - ";
							}
							text += array2[2];
						}
						arrayList.Add(text);
						break;
					case Enum88.const_5:
						text = "y = ";
						if (array[1] < 0.0)
						{
							text += " -";
						}
						text = ((Math.Abs(array[1]) != 1.0) ? (text + array2[1] + "x") : (text + "x"));
						arrayList.Add(text);
						text = "";
						if (array[0] < 0.0)
						{
							text += " - ";
						}
						text += array2[0];
						arrayList.Add(text);
						break;
					}
				}
				if (@class.DisplayRSquared)
				{
					text = "";
					text += "R";
					arrayList2.Add(text);
					arrayList2.Add("2");
					bool flag2 = true;
					string text2 = "0.0000";
					if (@class.method_3().imethod_2() != "")
					{
						text2 = @class.method_3().imethod_2();
						flag2 = false;
						if (text2.ToLower().Equals("general"))
						{
							text2 = "0.0000";
							flag2 = true;
						}
					}
					text = " = ";
					string text3 = Struct65.smethod_0(class844_0.Chart.vmethod_2(), @class.method_6(), text2);
					if (flag2)
					{
						if (double.Parse(text3) == 0.0)
						{
							text3 = @class.method_6().ToString("0.00E+00");
							string[] array3 = text3.Split('E');
							if (array3.Length > 1)
							{
								text3 = smethod_23(array3[0]) + "E";
								for (int j = 1; j < array3.Length; j++)
								{
									text3 += array3[j];
								}
							}
						}
						else
						{
							text3 = smethod_23(text3);
						}
					}
					text += text3;
					arrayList2.Add(text);
				}
				string text4 = "";
				for (int k = 0; k < arrayList.Count; k++)
				{
					text4 += (string)arrayList[k];
				}
				string text5 = "";
				for (int l = 0; l < arrayList2.Count; l++)
				{
					text5 += (string)arrayList2[l];
				}
				if (!(text4 != "") && !(text5 != ""))
				{
					continue;
				}
				Class832 class2 = @class.method_3();
				Font font_ = new Font(class2.method_0().Font.FontFamily, class2.method_0().Font.Size * 0.7f);
				SizeF sizeF = new SizeF(0f, 0f);
				if (arrayList.Count > 0)
				{
					if (arrayList.Count == 1)
					{
						sizeF = Struct61.smethod_10(interface42_0, text4, class2.method_0().Font);
					}
					else
					{
						string string_ = (string)arrayList[0];
						SizeF sizeF2 = Struct61.smethod_10(interface42_0, string_, class2.method_0().Font);
						sizeF.Width += sizeF2.Width;
						sizeF.Height += sizeF2.Height;
						string string_2 = (string)arrayList[1];
						SizeF sizeF3 = Struct61.smethod_10(interface42_0, string_2, font_);
						sizeF.Width += sizeF3.Width;
						if (arrayList.Count > 2)
						{
							string string_3 = (string)arrayList[2];
							SizeF sizeF4 = Struct61.smethod_10(interface42_0, string_3, class2.method_0().Font);
							sizeF.Width += sizeF4.Width;
						}
					}
				}
				SizeF sizeF5 = new SizeF(0f, 0f);
				if (arrayList2.Count > 0)
				{
					string string_4 = (string)arrayList2[0];
					SizeF sizeF6 = Struct61.smethod_10(interface42_0, string_4, class2.method_0().Font);
					sizeF5.Width += sizeF6.Width;
					sizeF5.Height += sizeF6.Height;
					string string_5 = (string)arrayList2[1];
					SizeF sizeF7 = Struct61.smethod_10(interface42_0, string_5, font_);
					sizeF5.Width += sizeF7.Width;
					string string_6 = (string)arrayList2[2];
					SizeF sizeF8 = Struct61.smethod_10(interface42_0, string_6, class2.method_0().Font);
					sizeF5.Width += sizeF8.Width;
				}
				float num = sizeF.Height / 4f;
				if (arrayList.Count > 1)
				{
					sizeF.Height += num;
				}
				float num2 = sizeF5.Height / 4f;
				if (arrayList.Count > 1)
				{
					sizeF5.Height += num2;
				}
				float num3 = ((sizeF.Width > sizeF5.Width) ? sizeF.Width : sizeF5.Width);
				float num4 = sizeF.Height + sizeF5.Height;
				RectangleF value = new RectangleF(@class.pointF_0.X - num3 - 8f, @class.pointF_0.Y - num4 / 2f, num3, num4);
				if (flag)
				{
					value = new RectangleF(@class.pointF_0.X - num3 / 2f, @class.pointF_0.Y + 10f, num3, num4);
				}
				class2.method_0().rectangle_1 = Rectangle.Round(value);
				class2.method_0().method_9();
				RectangleF rectangleF_ = new RectangleF(class2.method_0().rectangle_0.X, class2.method_0().rectangle_0.Y, class2.method_0().rectangle_0.Width, class2.method_0().rectangle_0.Height);
				@class.method_1().Chart.method_29(ref rectangleF_);
				RectangleF rectangleF_2 = rectangleF_;
				rectangleF_2.Inflate(2f, 4f);
				class2.method_0().method_1().method_8(rectangleF_2);
				class2.method_0().method_2().method_10(rectangleF_2);
				PointF location = rectangleF_.Location;
				float num5 = 0f;
				float num6 = 0f;
				if (sizeF.Width > sizeF5.Width)
				{
					num6 = (sizeF.Width - sizeF5.Width) / 2f;
				}
				else
				{
					num5 = (sizeF5.Width - sizeF.Width) / 2f;
				}
				if (arrayList.Count > 0)
				{
					if (arrayList.Count == 1)
					{
						interface42_0.imethod_24(text4, class2.method_0().Font, new SolidBrush(class2.method_0().FontColor), location);
					}
					else
					{
						location.X += num5;
						location.Y += num;
						string string_7 = (string)arrayList[0];
						interface42_0.imethod_24(string_7, class2.method_0().Font, new SolidBrush(class2.method_0().FontColor), location);
						SizeF sizeF9 = Struct61.smethod_10(interface42_0, string_7, class2.method_0().Font);
						location.X += sizeF9.Width;
						location.Y -= num;
						string string_8 = (string)arrayList[1];
						interface42_0.imethod_24(string_8, font_, new SolidBrush(class2.method_0().FontColor), location);
						if (arrayList.Count > 2)
						{
							SizeF sizeF10 = Struct61.smethod_10(interface42_0, string_8, font_);
							location.X += sizeF10.Width;
							location.Y += num;
							string string_9 = (string)arrayList[2];
							interface42_0.imethod_24(string_9, class2.method_0().Font, new SolidBrush(class2.method_0().FontColor), location);
						}
					}
				}
				if (arrayList2.Count > 0)
				{
					location.X = rectangleF_.X;
					location.Y = rectangleF_.Y + sizeF.Height;
					location.X += num6;
					location.Y += num2;
					string string_10 = (string)arrayList2[0];
					interface42_0.imethod_24(string_10, class2.method_0().Font, new SolidBrush(class2.method_0().FontColor), location);
					SizeF sizeF11 = Struct61.smethod_10(interface42_0, string_10, class2.method_0().Font);
					location.X += sizeF11.Width;
					location.Y -= num2;
					string string_11 = (string)arrayList2[1];
					interface42_0.imethod_24(string_11, font_, new SolidBrush(class2.method_0().FontColor), location);
					if (arrayList2.Count > 2)
					{
						SizeF sizeF12 = Struct61.smethod_10(interface42_0, string_11, font_);
						location.X += sizeF12.Width;
						location.Y += num2;
						string string_12 = (string)arrayList2[2];
						interface42_0.imethod_24(string_12, class2.method_0().Font, new SolidBrush(class2.method_0().FontColor), location);
					}
				}
				continue;
			}
			text = @class.method_3().Text;
			if (@class.method_3().method_2())
			{
				Class832 class3 = @class.method_3();
				new SizeF(@class.method_1().Chart.Width, @class.method_1().Chart.Height);
				Size size = new Size(class3.method_0().Width, class3.method_0().Height);
				Rectangle rectangle = new Rectangle((int)@class.pointF_0.X - size.Width - 8, (int)@class.pointF_0.Y - size.Height / 2, size.Width, size.Height);
				if (flag)
				{
					rectangle = new Rectangle((int)@class.pointF_0.X - size.Width / 2, (int)@class.pointF_0.Y + 10, size.Width, size.Height);
				}
				class3.method_0().rectangle_1 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
				class3.method_0().method_9();
				RectangleF rectangleF_3 = new RectangleF(class3.method_0().rectangle_0.X, class3.method_0().rectangle_0.Y, class3.method_0().Width, class3.method_0().rectangle_0.Height);
				smethod_21(interface42_0, rectangleF_3, class3);
			}
			else if (text != "")
			{
				Class832 class4 = @class.method_3();
				Size size2 = Struct61.smethod_3(sizeF_0: new SizeF(@class.method_1().Chart.Width, @class.method_1().Chart.Height), interface42_0: interface42_0, string_0: text, int_0: class4.Rotation, font_0: class4.method_0().Font, enum82_0: class4.TextHorizontalAlignment, enum82_1: class4.TextVerticalAlignment);
				Rectangle rectangle2 = new Rectangle((int)@class.pointF_0.X - size2.Width - 8, (int)@class.pointF_0.Y - size2.Height / 2, size2.Width, size2.Height);
				if (flag)
				{
					rectangle2 = new Rectangle((int)@class.pointF_0.X - size2.Width / 2, (int)@class.pointF_0.Y + 10, size2.Width, size2.Height);
				}
				class4.method_0().rectangle_1 = new Rectangle(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
				class4.method_0().method_9();
				RectangleF rectangleF_4 = new RectangleF(class4.method_0().rectangle_0.X, class4.method_0().rectangle_0.Y, class4.method_0().rectangle_0.Width, class4.method_0().rectangle_0.Height);
				@class.method_1().Chart.method_29(ref rectangleF_4);
				RectangleF rectangleF_5 = rectangleF_4;
				rectangleF_5.Inflate(0f, 4f);
				class4.method_0().method_1().method_8(rectangleF_5);
				class4.method_0().method_2().method_10(rectangleF_5);
				Struct51.smethod_12(interface42_0, class4, Rectangle.Round(rectangleF_4), text, class4.Rotation, class4.method_0().Font, class4.method_0().FontColor, class4.TextHorizontalAlignment, class4.TextVerticalAlignment);
			}
		}
	}

	private static void smethod_21(Interface42 interface42_0, RectangleF rectangleF_0, Class832 class832_0)
	{
		Class863 @class = new Class863();
		@class.TextHorizontalAlignment = Struct61.smethod_13(class832_0.TextHorizontalAlignment);
		@class.TextVerticalAlignment = Struct61.smethod_13(class832_0.TextVerticalAlignment);
		Class866 class2 = new Class866(rectangleF_0, @class, class832_0.imethod_4(), class832_0.method_0().Font);
		class2.method_0(interface42_0);
	}

	private static string[] smethod_22(Class821 class821_0, double[] double_0, Class850 class850_0)
	{
		bool flag = true;
		string text = "0.0000";
		if (class850_0.method_3().imethod_2() != "")
		{
			text = class850_0.method_3().imethod_2();
			flag = false;
			if (text.ToLower().Equals("general"))
			{
				text = "0.0000";
				flag = true;
			}
		}
		string[] array = new string[double_0.Length];
		for (int i = 0; i < double_0.Length; i++)
		{
			array[i] = Struct65.smethod_0(class821_0.vmethod_2(), Math.Abs(double_0[i]), text);
			if (!flag)
			{
				continue;
			}
			if (double.Parse(array[i]) == 0.0)
			{
				array[i] = Math.Abs(double_0[i]).ToString("0.00E+00");
				string[] array2 = array[i].Split('E');
				if (array2.Length > 1)
				{
					array[i] = smethod_23(array2[0]) + "E";
					for (int j = 1; j < array2.Length; j++)
					{
						string[] array3;
						string[] array4 = (array3 = array);
						int num = i;
						nint num2 = num;
						array4[num] = array3[num2] + array2[j];
					}
				}
			}
			else
			{
				array[i] = smethod_23(array[i]);
			}
		}
		return array;
	}

	private static string smethod_23(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
			int num = string_0.Length - 1;
			char c2 = string_0[num];
			while (c2 == '0' || c2 == c)
			{
				num--;
				if (num < 0)
				{
					break;
				}
				c2 = string_0[num];
			}
			return string_0.Substring(0, num + 1);
		}
		return "";
	}
}
