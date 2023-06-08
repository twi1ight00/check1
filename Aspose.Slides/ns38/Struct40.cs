using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns16;
using ns2;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct40
{
	internal static void smethod_0(Class740 chart)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		foreach (Class759 item in nSeriesInternal)
		{
			if (item.TrendlinesInternal.Count == 0)
			{
				continue;
			}
			_ = item.PlotOnSecondAxis;
			for (int i = 0; i < item.TrendlinesInternal.Count; i++)
			{
				smethod_12(item, out var y, out var x);
				double R = 0.0;
				Class763 class2 = item.TrendlinesInternal.method_0(i);
				if (class2.BorderInternal.IsVisible && x.Length >= 2 && y.Length >= 2)
				{
					switch (class2.Type)
					{
					case TrendlineType.Exponential:
						class2.EquationParam = smethod_19(y, x, class2.IsInterceptSet, class2.Intercept, out R);
						break;
					case TrendlineType.Linear:
						class2.EquationParam = smethod_15(y, x, class2.IsInterceptSet, class2.Intercept, out R);
						break;
					case TrendlineType.Logarithmic:
						class2.EquationParam = smethod_18(y, x, out R);
						break;
					case TrendlineType.Polynomial:
						class2.EquationParam = smethod_16(y, x, class2.Order, class2.IsInterceptSet, class2.Intercept, out R);
						break;
					case TrendlineType.Power:
						class2.EquationParam = smethod_17(y, x, out R);
						break;
					}
					class2.RSquaredParam = R;
				}
			}
		}
	}

	internal static void smethod_1(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
	{
		if (Struct41.smethod_21(rect))
		{
			return;
		}
		for (int i = 0; i < aSeries.TrendlinesInternal.Count; i++)
		{
			Class763 @class = aSeries.TrendlinesInternal.method_0(i);
			if (@class.BorderInternal.IsVisible && smethod_14(@class.EquationParam))
			{
				switch (@class.Type)
				{
				case TrendlineType.Linear:
					smethod_2(g, aSeries, rect, categoryAxisY, categoryAxisCrossAt, @class, renderContext);
					break;
				case TrendlineType.MovingAverage:
					smethod_4(g, aSeries, rect, categoryAxisY, categoryAxisCrossAt, @class, renderContext);
					break;
				case TrendlineType.Exponential:
				case TrendlineType.Logarithmic:
				case TrendlineType.Polynomial:
				case TrendlineType.Power:
					smethod_3(g, aSeries, rect, categoryAxisY, categoryAxisCrossAt, @class, renderContext);
					break;
				}
			}
		}
	}

	private static void smethod_2(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, Class763 trendline, Class784 renderContext)
	{
		if (trendline.BorderInternal.IsVisible)
		{
			_ = aSeries.Chart;
			Enum141 axisGroup = aSeries.AxisGroup;
			Class783 @class;
			Class783 class2;
			if (axisGroup == Enum141.const_0)
			{
				@class = renderContext.X1AxisRenderContext;
				class2 = renderContext.Y1AxisRenderContext;
			}
			else
			{
				@class = renderContext.X2AxisRenderContext;
				class2 = renderContext.Y2AxisRenderContext;
			}
			smethod_13(aSeries, trendline, out var minValue, out var maxValue);
			double logMinValue = class2.LogMinValue;
			double logMaxValue = class2.LogMaxValue;
			categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
			double num = 0.0;
			double num2 = (@class.Axis.IsLogarithmic ? @class.method_0(@class.MajorUnit) : @class.MajorUnit);
			double logMaxValue2 = @class.LogMaxValue;
			double logMinValue2 = @class.LogMinValue;
			if (@class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
			{
				num2 = Struct21.smethod_37(TimeUnitType.Days, @class.MajorUnitScale, (int)@class.MajorUnit, 0, aSeries.Chart.IsDate1904);
			}
			double num3;
			double num4;
			if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
			{
				num = logMaxValue2 - logMinValue2;
				num3 = minValue - logMinValue2;
				num4 = maxValue - logMinValue2;
			}
			else
			{
				num = logMaxValue2 - logMinValue2 + num2;
				num3 = minValue - logMinValue2 + num2 / 2.0;
				num4 = maxValue - logMinValue2 + num2 - num2 / 2.0;
			}
			double num5 = (double)rect.Width / num;
			double num6 = num3 * num5;
			num6 = ((!renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed) ? ((double)rect.Left + num6) : ((double)rect.Right - num6));
			double num7 = categoryAxisY;
			double num8 = smethod_10(trendline, minValue);
			double num9 = (num8 - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Height;
			num7 = (renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed ? (num7 + num9) : (num7 - num9));
			double num10 = num4 * num5;
			num10 = ((!renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed) ? ((double)rect.Left + num10) : ((double)rect.Right - num10));
			double num11 = categoryAxisY;
			double num12 = smethod_10(trendline, maxValue);
			double num13 = (num12 - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Height;
			num11 = (renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed ? (num11 + num13) : (num11 - num13));
			trendline.BorderInternal.method_3((float)num6, (float)num7, (float)num10, (float)num11);
			trendline.pointF_0 = new PointF((float)num10, (float)num11);
		}
	}

	private static void smethod_3(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, Class763 trendline, Class784 renderContext)
	{
		if (trendline.BorderInternal.IsVisible)
		{
			_ = aSeries.Chart;
			Enum141 axisGroup = aSeries.AxisGroup;
			Class783 @class;
			Class783 class2;
			if (axisGroup == Enum141.const_0)
			{
				@class = renderContext.X1AxisRenderContext;
				class2 = renderContext.Y1AxisRenderContext;
			}
			else
			{
				@class = renderContext.X2AxisRenderContext;
				class2 = renderContext.Y2AxisRenderContext;
			}
			double logMinValue = class2.LogMinValue;
			double logMaxValue = class2.LogMaxValue;
			categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
			smethod_13(aSeries, trendline, out var minValue, out var maxValue);
			double num = 0.0;
			double num2 = (@class.Axis.IsLogarithmic ? @class.method_0(@class.MajorUnit) : @class.MajorUnit);
			double logMaxValue2 = @class.LogMaxValue;
			double logMinValue2 = @class.LogMinValue;
			if (@class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
			{
				num2 = Struct21.smethod_37(TimeUnitType.Days, @class.MajorUnitScale, (int)@class.MajorUnit, 0, aSeries.Chart.IsDate1904);
			}
			num = ((@class.AxisBetweenCategories || renderContext.Chart.HasDataTable) ? (logMaxValue2 - logMinValue2 + num2) : (logMaxValue2 - logMinValue2));
			IList list = new ArrayList();
			double num3 = num / (double)rect.Width;
			double num4 = ((minValue < logMinValue2) ? logMinValue2 : minValue);
			double num5 = ((maxValue > logMaxValue2) ? logMaxValue2 : maxValue);
			for (double num6 = num4; num6 <= num5; num6 += num3)
			{
				double num7 = ((@class.AxisBetweenCategories || renderContext.Chart.HasDataTable) ? ((num6 - logMinValue2 + num2 / 2.0) * (double)rect.Width / num) : ((num6 - logMinValue2) * (double)rect.Width / num));
				num7 = ((!@class.Axis.IsPlotOrderReversed) ? ((double)rect.Left + num7) : ((double)rect.Right - num7));
				double num8 = categoryAxisY;
				double num9 = smethod_10(trendline, num6);
				double num10 = (num9 - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Height;
				num8 = (class2.Axis.IsPlotOrderReversed ? (num8 + num10) : (num8 - num10));
				PointF pointF = new PointF((float)num7, (float)num8);
				list.Add(pointF);
			}
			smethod_11(g, list, trendline, isSmooth: true);
			if (list.Count > 0)
			{
				trendline.pointF_0 = (PointF)list[list.Count - 1];
			}
		}
	}

	private static void smethod_4(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, Class763 trendline, Class784 renderContext)
	{
		if (!trendline.BorderInternal.IsVisible)
		{
			return;
		}
		_ = aSeries.Chart;
		Enum141 axisGroup = aSeries.AxisGroup;
		Class783 @class;
		Class783 class2;
		if (axisGroup == Enum141.const_0)
		{
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
		}
		else
		{
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
		}
		double logMinValue = class2.LogMinValue;
		double logMaxValue = class2.LogMaxValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		smethod_13(aSeries, trendline, out var _, out var _);
		double num = 0.0;
		double num2 = (@class.Axis.IsLogarithmic ? @class.method_0(@class.MajorUnit) : @class.MajorUnit);
		double logMaxValue2 = @class.LogMaxValue;
		double logMinValue2 = @class.LogMinValue;
		if (@class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			num2 = Struct21.smethod_37(TimeUnitType.Days, @class.MajorUnitScale, (int)@class.MajorUnit, 0, aSeries.Chart.IsDate1904);
		}
		num = ((@class.AxisBetweenCategories || renderContext.Chart.HasDataTable) ? (logMaxValue2 - logMinValue2 + num2) : (logMaxValue2 - logMinValue2));
		double num3 = (double)rect.Width / num;
		IList list = new ArrayList();
		Class747 pointsInternal = aSeries.PointsInternal;
		List<Class748> list2 = pointsInternal.method_1();
		for (int i = trendline.Period - 1; i < list2.Count; i++)
		{
			Class748 class3 = list2[i];
			if (!smethod_9(i, trendline.Period, list2, out var average))
			{
				double num4 = ((@class.AxisBetweenCategories || renderContext.Chart.HasDataTable) ? ((class3.XValue - logMinValue2 + num2 / 2.0) * num3) : ((class3.XValue - logMinValue2) * num3));
				num4 = ((!@class.Axis.IsPlotOrderReversed) ? ((double)rect.Left + num4) : ((double)rect.Right - num4));
				double num5 = categoryAxisY;
				double num6 = (average - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Height;
				num5 = (class2.Axis.IsPlotOrderReversed ? (num5 + num6) : (num5 - num6));
				PointF pointF = new PointF((float)num4, (float)num5);
				list.Add(pointF);
			}
		}
		smethod_11(g, list, trendline, isSmooth: false);
	}

	internal static void smethod_5(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisX, double categoryAxisCrossAt, Class784 renderContext)
	{
		if (Struct41.smethod_21(rect))
		{
			return;
		}
		for (int i = 0; i < aSeries.TrendlinesInternal.Count; i++)
		{
			Class763 @class = aSeries.TrendlinesInternal.method_0(i);
			if (@class.BorderInternal.IsVisible && smethod_14(@class.EquationParam))
			{
				switch (@class.Type)
				{
				case TrendlineType.Linear:
					smethod_6(g, aSeries, rect, categoryAxisX, categoryAxisCrossAt, @class, renderContext);
					break;
				case TrendlineType.MovingAverage:
					smethod_8(g, aSeries, rect, categoryAxisX, categoryAxisCrossAt, @class, renderContext);
					break;
				case TrendlineType.Exponential:
				case TrendlineType.Logarithmic:
				case TrendlineType.Polynomial:
				case TrendlineType.Power:
					smethod_7(g, aSeries, rect, categoryAxisX, categoryAxisCrossAt, @class, renderContext);
					break;
				}
			}
		}
	}

	private static void smethod_6(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisX, double categoryAxisCrossAt, Class763 trendline, Class784 renderContext)
	{
		if (trendline.BorderInternal.IsVisible)
		{
			_ = aSeries.Chart;
			Enum141 axisGroup = aSeries.AxisGroup;
			Class783 @class;
			Class783 class2;
			if (axisGroup == Enum141.const_0)
			{
				@class = renderContext.X1AxisRenderContext;
				class2 = renderContext.Y1AxisRenderContext;
			}
			else
			{
				@class = renderContext.X2AxisRenderContext;
				class2 = renderContext.Y2AxisRenderContext;
			}
			smethod_13(aSeries, trendline, out var minValue, out var maxValue);
			double logMinValue = class2.LogMinValue;
			double logMaxValue = class2.LogMaxValue;
			categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
			double num = 0.0;
			double num2 = (@class.Axis.IsLogarithmic ? @class.method_0(@class.MajorUnit) : @class.MajorUnit);
			double logMinValue2 = @class.LogMinValue;
			double logMaxValue2 = @class.LogMaxValue;
			if (@class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
			{
				num2 = Struct21.smethod_37(TimeUnitType.Days, @class.MajorUnitScale, (int)@class.MajorUnit, 0, aSeries.Chart.IsDate1904);
			}
			double num3;
			double num4;
			if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
			{
				num = logMinValue2 - logMaxValue2;
				num3 = minValue - logMaxValue2;
				num4 = maxValue - logMaxValue2;
			}
			else
			{
				num = logMinValue2 - logMaxValue2 + num2;
				num3 = minValue - logMaxValue2 + num2 / 2.0;
				num4 = maxValue - logMaxValue2 + num2 - num2 / 2.0;
			}
			double num5 = (double)rect.Height / num;
			double num6 = num3 * num5;
			num6 = (@class.Axis.IsPlotOrderReversed ? ((double)rect.Top + num6) : ((double)rect.Bottom - num6));
			double num7 = categoryAxisX;
			double num8 = smethod_10(trendline, minValue);
			double num9 = (num8 - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Width;
			num7 = (class2.Axis.IsPlotOrderReversed ? (num7 - num9) : (num7 + num9));
			double num10 = num4 * num5;
			num10 = (@class.Axis.IsPlotOrderReversed ? ((double)rect.Top + num10) : ((double)rect.Bottom - num10));
			double num11 = categoryAxisX;
			double num12 = smethod_10(trendline, maxValue);
			double num13 = (num12 - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Width;
			num11 = (class2.Axis.IsPlotOrderReversed ? (num11 - num13) : (num11 + num13));
			trendline.BorderInternal.method_3((float)num7, (float)num6, (float)num11, (float)num10);
			trendline.pointF_0 = new PointF((float)num11, (float)num10);
		}
	}

	private static void smethod_7(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisX, double categoryAxisCrossAt, Class763 trendline, Class784 renderContext)
	{
		if (trendline.BorderInternal.IsVisible)
		{
			_ = aSeries.Chart;
			Enum141 axisGroup = aSeries.AxisGroup;
			Class783 @class;
			Class783 class2;
			if (axisGroup == Enum141.const_0)
			{
				@class = renderContext.X1AxisRenderContext;
				class2 = renderContext.Y1AxisRenderContext;
			}
			else
			{
				@class = renderContext.X2AxisRenderContext;
				class2 = renderContext.Y2AxisRenderContext;
			}
			double logMinValue = class2.LogMinValue;
			double logMaxValue = class2.LogMaxValue;
			categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
			smethod_13(aSeries, trendline, out var minValue, out var maxValue);
			double num = 0.0;
			double num2 = (@class.Axis.IsLogarithmic ? @class.method_0(@class.MajorUnit) : @class.MajorUnit);
			double logMaxValue2 = @class.LogMaxValue;
			double logMinValue2 = @class.LogMinValue;
			if (@class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
			{
				num2 = Struct21.smethod_37(TimeUnitType.Days, @class.MajorUnitScale, (int)@class.MajorUnit, 0, aSeries.Chart.IsDate1904);
			}
			num = ((@class.AxisBetweenCategories || renderContext.Chart.HasDataTable) ? (logMaxValue2 - logMinValue2 + num2) : (logMaxValue2 - logMinValue2));
			IList list = new ArrayList();
			double num3 = num / (double)rect.Height;
			for (double num4 = minValue; num4 <= maxValue; num4 += num3)
			{
				double num5 = ((@class.AxisBetweenCategories || renderContext.Chart.HasDataTable) ? ((num4 - logMinValue2 + num2 / 2.0) * (double)rect.Height / num) : ((num4 - logMinValue2) * (double)rect.Height / num));
				num5 = (@class.Axis.IsPlotOrderReversed ? ((double)rect.Top + num5) : ((double)rect.Bottom - num5));
				double num6 = categoryAxisX;
				double num7 = smethod_10(trendline, num4);
				double num8 = (num7 - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Width;
				num6 = (class2.Axis.IsPlotOrderReversed ? (num6 - num8) : (num6 + num8));
				PointF pointF = new PointF((float)num6, (float)num5);
				list.Add(pointF);
			}
			smethod_11(g, list, trendline, isSmooth: true);
			if (list.Count > 0)
			{
				trendline.pointF_0 = (PointF)list[list.Count - 1];
			}
		}
	}

	private static void smethod_8(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisX, double categoryAxisCrossAt, Class763 trendline, Class784 renderContext)
	{
		if (!trendline.BorderInternal.IsVisible)
		{
			return;
		}
		_ = aSeries.Chart;
		Enum141 axisGroup = aSeries.AxisGroup;
		Class783 @class;
		Class783 class2;
		if (axisGroup == Enum141.const_0)
		{
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
		}
		else
		{
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
		}
		double logMinValue = class2.LogMinValue;
		double logMaxValue = class2.LogMaxValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		smethod_13(aSeries, trendline, out var _, out var _);
		double num = 0.0;
		double num2 = (@class.Axis.IsLogarithmic ? @class.method_0(@class.MajorUnit) : @class.MajorUnit);
		double logMaxValue2 = @class.LogMaxValue;
		double logMinValue2 = @class.LogMinValue;
		if (@class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			num2 = Struct21.smethod_37(TimeUnitType.Days, @class.MajorUnitScale, (int)@class.MajorUnit, 0, aSeries.Chart.IsDate1904);
		}
		num = ((@class.AxisBetweenCategories || renderContext.Chart.HasDataTable) ? (logMaxValue2 - logMinValue2 + num2) : (logMaxValue2 - logMinValue2));
		double num3 = (double)rect.Height / num;
		IList list = new ArrayList();
		Class747 pointsInternal = aSeries.PointsInternal;
		List<Class748> list2 = pointsInternal.method_1();
		for (int i = trendline.Period - 1; i < list2.Count; i++)
		{
			Class748 class3 = list2[i];
			if (!smethod_9(i, trendline.Period, list2, out var average))
			{
				double num4 = ((@class.AxisBetweenCategories || renderContext.Chart.HasDataTable) ? ((class3.XValue - logMinValue2 + num2 / 2.0) * num3) : ((class3.XValue - logMinValue2) * num3));
				num4 = (@class.Axis.IsPlotOrderReversed ? ((double)rect.Top + num4) : ((double)rect.Bottom - num4));
				double num5 = categoryAxisX;
				double num6 = (average - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Width;
				num5 = (class2.Axis.IsPlotOrderReversed ? (num5 - num6) : (num5 + num6));
				PointF pointF = new PointF((float)num5, (float)num4);
				list.Add(pointF);
			}
		}
		smethod_11(g, list, trendline, isSmooth: false);
	}

	private static bool smethod_9(int pointIndex, int period, List<Class748> points, out double average)
	{
		double num = 0.0;
		int num2 = 0;
		for (int i = pointIndex - period + 1; i <= pointIndex; i++)
		{
			Class748 @class = points[i];
			if (@class != null && !@class.NotPlotted)
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

	private static double smethod_10(Class763 trendline, double x)
	{
		double[] equationParam = trendline.EquationParam;
		switch (trendline.Type)
		{
		case TrendlineType.Exponential:
			return equationParam[1] * Math.Pow(Math.E, equationParam[0] * x);
		case TrendlineType.Linear:
			return equationParam[0] * x + equationParam[1];
		case TrendlineType.Logarithmic:
			return equationParam[0] * Math.Log(x) + equationParam[1];
		default:
			return 0.0;
		case TrendlineType.Polynomial:
		{
			double num = 0.0;
			for (int i = 0; i < equationParam.Length; i++)
			{
				num += equationParam[i] * Math.Pow(x, equationParam.Length - 1 - i);
			}
			return num;
		}
		case TrendlineType.Power:
			return equationParam[1] * Math.Pow(x, equationParam[0]);
		}
	}

	internal static void smethod_11(Interface32 g, IList list, Class763 trendline, bool isSmooth)
	{
		PointF[] array = new PointF[list.Count];
		list.CopyTo(array, 0);
		if (array.Length > 1)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			if (isSmooth)
			{
				graphicsPath.AddCurve(array);
			}
			else
			{
				graphicsPath.AddPolygon(array);
			}
			trendline.BorderInternal.method_8(graphicsPath);
		}
	}

	private static void smethod_12(Class759 aSeries, out double[] y, out double[] x)
	{
		double num = 2147483647.0;
		for (int i = 0; i < aSeries.PointsInternal.Count; i++)
		{
			Class748 @class = aSeries.PointsInternal.method_0(i);
			if (@class != null && !@class.NotPlotted && !@class.XNotPlotted && @class.XValue < num)
			{
				num = @class.XValue;
			}
		}
		int num2 = aSeries.PointsInternal.Count;
		for (int j = 0; j < aSeries.PointsInternal.Count; j++)
		{
			Class748 class2 = aSeries.PointsInternal.method_0(j);
			if (class2 == null || class2.NotPlotted)
			{
				num2--;
			}
		}
		y = new double[num2];
		x = new double[num2];
		int num3 = 0;
		for (int k = 0; k < aSeries.PointsInternal.Count; k++)
		{
			Class748 class3 = aSeries.PointsInternal.method_0(k);
			if (class3 != null && !class3.NotPlotted)
			{
				y[num3] = class3.YValue;
				if (class3.XNotPlotted)
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

	private static void smethod_13(Class759 series, Class763 trendLine, out double minValue, out double maxValue)
	{
		minValue = 2147483647.0;
		maxValue = -2147483648.0;
		Class747 pointsInternal = series.PointsInternal;
		bool flag = true;
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			if (pointsInternal[i] != null && !pointsInternal[i].XNotPlotted)
			{
				double xValue = pointsInternal[i].XValue;
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

	private static bool smethod_14(double[] equationParam)
	{
		if (equationParam == null)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < equationParam.Length)
			{
				double d = equationParam[num];
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
			array2 = Class776.smethod_1(y, array);
		}
		else
		{
			array2 = Class776.smethod_0(y, array);
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
			array2 = Class776.smethod_1(y, array);
		}
		else
		{
			array2 = Class776.smethod_0(y, array);
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

	internal static void smethod_20(Interface32 g, Class759 aSeries)
	{
		bool flag = false;
		if (aSeries.ResembleType == ChartType.ClusteredBar || aSeries.ResembleType == ChartType.StackedBar || aSeries.ResembleType == ChartType.PercentsStackedBar)
		{
			flag = true;
		}
		for (int i = 0; i < aSeries.TrendlinesInternal.Count; i++)
		{
			Class763 @class = aSeries.TrendlinesInternal.method_0(i);
			if (!@class.BorderInternal.IsVisible || !smethod_14(@class.EquationParam))
			{
				continue;
			}
			string text = null;
			if (@class.DataLabelsInternal.Text == null)
			{
				ArrayList arrayList = new ArrayList();
				ArrayList arrayList2 = new ArrayList();
				if (@class.DisplayEquation)
				{
					double[] equationParam = @class.EquationParam;
					string[] array = smethod_22(@class.EquationParam, @class);
					switch (@class.Type)
					{
					case TrendlineType.Exponential:
						text = "y = ";
						if (equationParam[1] < 0.0)
						{
							text += " -";
						}
						text = ((Math.Abs(equationParam[1]) != 1.0) ? (text + array[1] + "e") : (text + "e"));
						arrayList.Add(text);
						text = "";
						if (equationParam[0] < 0.0)
						{
							text += " - ";
						}
						text = ((Math.Abs(equationParam[0]) != 1.0) ? (text + array[0] + "x") : (text + "x"));
						arrayList.Add(text);
						break;
					case TrendlineType.Linear:
						text = "y = ";
						if (equationParam[0] < 0.0)
						{
							text += " -";
						}
						text = ((Math.Abs(equationParam[0]) != 1.0) ? (text + array[0] + "x") : (text + "x"));
						if (equationParam[1] != 0.0)
						{
							if (equationParam[1] > 0.0)
							{
								text += " + ";
							}
							else if (equationParam[1] < 0.0)
							{
								text += " - ";
							}
							text += array[1];
						}
						arrayList.Add(text);
						break;
					case TrendlineType.Logarithmic:
						text = "y = ";
						if (equationParam[0] < 0.0)
						{
							text += " -";
						}
						text = ((Math.Abs(equationParam[0]) != 1.0) ? (text + array[0] + "Ln(x)") : (text + "x"));
						if (equationParam[1] != 0.0)
						{
							if (equationParam[1] > 0.0)
							{
								text += " + ";
							}
							else if (equationParam[1] < 0.0)
							{
								text += " - ";
							}
							text += array[1];
							arrayList.Add(text);
						}
						break;
					case TrendlineType.Polynomial:
						text = "y = ";
						if (equationParam[0] != 0.0)
						{
							if (equationParam[0] < 0.0)
							{
								text += " -";
							}
							text = ((Math.Abs(equationParam[0]) != 1.0) ? (text + array[0] + "x") : (text + "x"));
							arrayList.Add(text);
							arrayList.Add("2");
						}
						text = "";
						if (equationParam[1] != 0.0)
						{
							text = ((!(equationParam[1] < 0.0)) ? (text + " + ") : (text + " - "));
							text = ((Math.Abs(equationParam[1]) != 1.0) ? (text + array[1] + "x") : (text + "x"));
						}
						if (equationParam[2] != 0.0)
						{
							if (equationParam[2] > 0.0)
							{
								text += " + ";
							}
							else if (equationParam[2] < 0.0)
							{
								text += " - ";
							}
							text += array[2];
						}
						arrayList.Add(text);
						break;
					case TrendlineType.Power:
						text = "y = ";
						if (equationParam[1] < 0.0)
						{
							text += " -";
						}
						text = ((Math.Abs(equationParam[1]) != 1.0) ? (text + array[1] + "x") : (text + "x"));
						arrayList.Add(text);
						text = "";
						if (equationParam[0] < 0.0)
						{
							text += " - ";
						}
						text += array[0];
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
					if (@class.DataLabelsInternal.Format != "")
					{
						text2 = @class.DataLabelsInternal.Format;
						flag2 = false;
					}
					text = " = ";
					string text3 = @class.RSquaredParam.ToString(text2);
					if (flag2)
					{
						if (double.Parse(text3) == 0.0)
						{
							text3 = @class.RSquaredParam.ToString("0.00E+00");
							string[] array2 = text3.Split('E');
							if (array2.Length > 1)
							{
								text3 = smethod_23(array2[0]) + "E";
								for (int j = 1; j < array2.Length; j++)
								{
									text3 += array2[j];
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
				Class750 dataLabelsInternal = @class.DataLabelsInternal;
				Font font = new Font(dataLabelsInternal.ChartFrameInternal.TextFont.FontFamily, dataLabelsInternal.ChartFrameInternal.TextFont.Size * 0.7f);
				SizeF sizeF = new SizeF(0f, 0f);
				if (arrayList.Count > 0)
				{
					if (arrayList.Count == 1)
					{
						sizeF = Struct39.smethod_14(g, text4, dataLabelsInternal.ChartFrameInternal.TextFont);
					}
					else
					{
						string text6 = (string)arrayList[0];
						SizeF sizeF2 = Struct39.smethod_14(g, text6, dataLabelsInternal.ChartFrameInternal.TextFont);
						sizeF.Width += sizeF2.Width;
						sizeF.Height += sizeF2.Height;
						string text7 = (string)arrayList[1];
						SizeF sizeF3 = Struct39.smethod_14(g, text7, font);
						sizeF.Width += sizeF3.Width;
						if (arrayList.Count > 2)
						{
							string text8 = (string)arrayList[2];
							SizeF sizeF4 = Struct39.smethod_14(g, text8, dataLabelsInternal.ChartFrameInternal.TextFont);
							sizeF.Width += sizeF4.Width;
						}
					}
				}
				SizeF sizeF5 = new SizeF(0f, 0f);
				if (arrayList2.Count > 0)
				{
					string text9 = (string)arrayList2[0];
					SizeF sizeF6 = Struct39.smethod_14(g, text9, dataLabelsInternal.ChartFrameInternal.TextFont);
					sizeF5.Width += sizeF6.Width;
					sizeF5.Height += sizeF6.Height;
					string text10 = (string)arrayList2[1];
					SizeF sizeF7 = Struct39.smethod_14(g, text10, font);
					sizeF5.Width += sizeF7.Width;
					string text11 = (string)arrayList2[2];
					SizeF sizeF8 = Struct39.smethod_14(g, text11, dataLabelsInternal.ChartFrameInternal.TextFont);
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
				dataLabelsInternal.ChartFrameInternal.rectangle_1 = Rectangle.Round(value);
				dataLabelsInternal.ChartFrameInternal.method_6();
				RectangleF rect = new RectangleF(dataLabelsInternal.ChartFrameInternal.rectangle_0.X, dataLabelsInternal.ChartFrameInternal.rectangle_0.Y, dataLabelsInternal.ChartFrameInternal.rectangle_0.Width, dataLabelsInternal.ChartFrameInternal.rectangle_0.Height);
				@class.BorderInternal.Chart.method_2(ref rect);
				RectangleF rect2 = rect;
				rect2.Inflate(2f, 4f);
				dataLabelsInternal.ChartFrameInternal.AreaInternal.method_5(rect2);
				dataLabelsInternal.ChartFrameInternal.BorderInternal.method_7(rect2);
				PointF location = rect.Location;
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
						g.imethod_57(text4, dataLabelsInternal.ChartFrameInternal.TextFont, new SolidBrush(dataLabelsInternal.ChartFrameInternal.FontColor), location);
					}
					else
					{
						location.X += num5;
						location.Y += num;
						string text12 = (string)arrayList[0];
						g.imethod_57(text12, dataLabelsInternal.ChartFrameInternal.TextFont, new SolidBrush(dataLabelsInternal.ChartFrameInternal.FontColor), location);
						SizeF sizeF9 = Struct39.smethod_14(g, text12, dataLabelsInternal.ChartFrameInternal.TextFont);
						location.X += sizeF9.Width;
						location.Y -= num;
						string text13 = (string)arrayList[1];
						g.imethod_57(text13, font, new SolidBrush(dataLabelsInternal.ChartFrameInternal.FontColor), location);
						if (arrayList.Count > 2)
						{
							SizeF sizeF10 = Struct39.smethod_14(g, text13, font);
							location.X += sizeF10.Width;
							location.Y += num;
							string s = (string)arrayList[2];
							g.imethod_57(s, dataLabelsInternal.ChartFrameInternal.TextFont, new SolidBrush(dataLabelsInternal.ChartFrameInternal.FontColor), location);
						}
					}
				}
				if (arrayList2.Count > 0)
				{
					location.X = rect.X;
					location.Y = rect.Y + sizeF.Height;
					location.X += num6;
					location.Y += num2;
					string text14 = (string)arrayList2[0];
					g.imethod_57(text14, dataLabelsInternal.ChartFrameInternal.TextFont, new SolidBrush(dataLabelsInternal.ChartFrameInternal.FontColor), location);
					SizeF sizeF11 = Struct39.smethod_14(g, text14, dataLabelsInternal.ChartFrameInternal.TextFont);
					location.X += sizeF11.Width;
					location.Y -= num2;
					string text15 = (string)arrayList2[1];
					g.imethod_57(text15, font, new SolidBrush(dataLabelsInternal.ChartFrameInternal.FontColor), location);
					if (arrayList2.Count > 2)
					{
						SizeF sizeF12 = Struct39.smethod_14(g, text15, font);
						location.X += sizeF12.Width;
						location.Y += num2;
						string s2 = (string)arrayList2[2];
						g.imethod_57(s2, dataLabelsInternal.ChartFrameInternal.TextFont, new SolidBrush(dataLabelsInternal.ChartFrameInternal.FontColor), location);
					}
				}
				continue;
			}
			text = @class.DataLabelsInternal.Text;
			if (@class.DataLabelsInternal.RichCharactersList.Count > 0)
			{
				Class750 dataLabelsInternal2 = @class.DataLabelsInternal;
				new SizeF(@class.BorderInternal.Chart.Width, @class.BorderInternal.Chart.Height);
				Size size = new Size(dataLabelsInternal2.ChartFrameInternal.Width, dataLabelsInternal2.ChartFrameInternal.Height);
				Rectangle rectangle = new Rectangle((int)@class.pointF_0.X - size.Width - 8, (int)@class.pointF_0.Y - size.Height / 2, size.Width, size.Height);
				if (flag)
				{
					rectangle = new Rectangle((int)@class.pointF_0.X - size.Width / 2, (int)@class.pointF_0.Y + 10, size.Width, size.Height);
				}
				dataLabelsInternal2.ChartFrameInternal.rectangle_1 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
				dataLabelsInternal2.ChartFrameInternal.method_6();
				RectangleF rect3 = new RectangleF(dataLabelsInternal2.ChartFrameInternal.rectangle_0.X, dataLabelsInternal2.ChartFrameInternal.rectangle_0.Y, dataLabelsInternal2.ChartFrameInternal.Width, dataLabelsInternal2.ChartFrameInternal.rectangle_0.Height);
				smethod_21(g, rect3, dataLabelsInternal2);
			}
			else if (text != "")
			{
				Class750 dataLabelsInternal3 = @class.DataLabelsInternal;
				Size size2 = Struct39.smethod_3(layoutArea: new SizeF(@class.BorderInternal.Chart.Width, @class.BorderInternal.Chart.Height), g: g, text: text, rotation: dataLabelsInternal3.Rotation, font: dataLabelsInternal3.ChartFrameInternal.TextFont, horizontalAlignment: dataLabelsInternal3.TextHorizontalAlignment, verticalAlignment: dataLabelsInternal3.TextVerticalAlignment);
				Rectangle rectangle2 = new Rectangle((int)@class.pointF_0.X - size2.Width - 8, (int)@class.pointF_0.Y - size2.Height / 2, size2.Width, size2.Height);
				if (flag)
				{
					rectangle2 = new Rectangle((int)@class.pointF_0.X - size2.Width / 2, (int)@class.pointF_0.Y + 10, size2.Width, size2.Height);
				}
				dataLabelsInternal3.ChartFrameInternal.rectangle_1 = new Rectangle(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
				dataLabelsInternal3.ChartFrameInternal.method_6();
				RectangleF rect4 = new RectangleF(dataLabelsInternal3.ChartFrameInternal.rectangle_0.X, dataLabelsInternal3.ChartFrameInternal.rectangle_0.Y, dataLabelsInternal3.ChartFrameInternal.rectangle_0.Width, dataLabelsInternal3.ChartFrameInternal.rectangle_0.Height);
				@class.BorderInternal.Chart.method_2(ref rect4);
				RectangleF rect5 = rect4;
				rect5.Inflate(0f, 4f);
				dataLabelsInternal3.ChartFrameInternal.AreaInternal.method_5(rect5);
				dataLabelsInternal3.ChartFrameInternal.BorderInternal.method_7(rect5);
				Struct28.smethod_12(g, dataLabelsInternal3, Rectangle.Round(rect4), text, dataLabelsInternal3.Rotation, dataLabelsInternal3.ChartFrameInternal.TextFont, dataLabelsInternal3.ChartFrameInternal.FontColor, dataLabelsInternal3.TextHorizontalAlignment, dataLabelsInternal3.TextVerticalAlignment);
			}
		}
	}

	private static void smethod_21(Interface32 g, RectangleF rect, Class750 dls)
	{
		Class777 @class = new Class777();
		@class.TextHorizontalAlignment = Struct39.smethod_18(dls.TextHorizontalAlignment);
		@class.TextVerticalAlignment = Struct39.smethod_18(dls.TextVerticalAlignment);
		Class780 class2 = new Class780(rect, @class, dls.RichCharactersList, dls.ChartFrameInternal.TextFont);
		class2.method_0(g);
	}

	private static string[] smethod_22(double[] param, Class763 trendline)
	{
		bool flag = true;
		string text = "0.0000";
		if (trendline.DataLabelsInternal.Format != "")
		{
			text = trendline.DataLabelsInternal.Format;
			flag = false;
		}
		string[] array = new string[param.Length];
		for (int i = 0; i < param.Length; i++)
		{
			array[i] = Math.Abs(param[i]).ToString(text);
			if (!flag)
			{
				continue;
			}
			if (double.Parse(array[i]) == 0.0)
			{
				array[i] = Math.Abs(param[i]).ToString("0.00E+00");
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

	private static string smethod_23(string val)
	{
		if (val != null && !(val == ""))
		{
			char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
			int num = val.Length - 1;
			char c2 = val[num];
			while (c2 == '0' || c2 == c)
			{
				num--;
				if (num < 0)
				{
					break;
				}
				c2 = val[num];
			}
			return val.Substring(0, num + 1);
		}
		return "";
	}
}
