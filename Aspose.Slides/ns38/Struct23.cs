using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns2;
using ns33;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct23
{
	internal static List<object[]> smethod_0(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		GraphicsState gstate = g.Save();
		g.imethod_121(rect);
		Class740 chart = aSeries.Chart;
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
		Class757 nSeriesInternal = chart.NSeriesInternal;
		double logMinValue = class2.LogMinValue;
		double logMaxValue = class2.LogMaxValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		double logMinValue2 = @class.LogMinValue;
		double logMaxValue2 = @class.LogMaxValue;
		List<object[]> list = new List<object[]>();
		double num = (double)rect.Width / (logMaxValue2 - logMinValue2);
		double maxBubbleSize = smethod_2(nSeriesInternal, logMinValue, logMaxValue, logMinValue2, logMaxValue2);
		int index = aSeries.Index;
		ArrayList arrayList = new ArrayList();
		Class747 pointsInternal = aSeries.PointsInternal;
		for (int i = 0; i < maxPointsCount; i++)
		{
			Class748 class3 = pointsInternal.method_0(i);
			if (class3 != null && !class3.NotPlotted && !class3.XNotPlotted)
			{
				if (class3.YValue > logMaxValue || class3.YValue < logMinValue || class3.XValue > logMaxValue2 || class3.XValue < logMinValue2)
				{
					continue;
				}
				double num2 = (double)(float)num * (class3.XValue - logMinValue2);
				num2 = (@class.Axis.IsPlotOrderReversed ? ((double)(rect.X + rect.Width) - num2) : ((double)rect.X + num2));
				double num3 = categoryAxisY;
				double yValue = class3.YValue;
				double num4 = (yValue - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Height;
				Class752 xErrorBarInternal = aSeries.XErrorBarInternal;
				PointF originPoint = new PointF((float)num2, categoryAxisY);
				double num5 = 0.0;
				double num6 = 0.0;
				float minusHeight = 0f;
				float plusHeight = 0f;
				if (xErrorBarInternal != null)
				{
					switch (xErrorBarInternal.Type)
					{
					case ErrorBarValueType.Custom:
					{
						double num7 = 0.0;
						try
						{
							num7 = ((xErrorBarInternal.MinusValue.Count > i) ? Convert.ToDouble(xErrorBarInternal.MinusValue[i]) : 0.0);
						}
						catch (Exception ex)
						{
							Class1165.smethod_28(ex);
						}
						num5 = num7;
						try
						{
							num7 = ((xErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(xErrorBarInternal.PlusValue[i]) : 0.0);
						}
						catch (Exception ex2)
						{
							Class1165.smethod_28(ex2);
						}
						num6 = num7;
						break;
					}
					case ErrorBarValueType.Fixed:
						num5 = xErrorBarInternal.Amount;
						num6 = num5;
						break;
					case ErrorBarValueType.Percentage:
						num5 = xErrorBarInternal.Amount * yValue / 100.0;
						num6 = num5;
						break;
					}
					minusHeight = (float)(num5 / (logMaxValue2 - logMinValue2) * (double)rect.Width);
					plusHeight = (float)(num6 / (logMaxValue2 - logMinValue2) * (double)rect.Width);
					if (!class2.Axis.IsPlotOrderReversed)
					{
						originPoint.Y -= (float)num4;
					}
					else
					{
						originPoint.Y += (float)num4;
					}
				}
				xErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
				Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
				num5 = 0.0;
				num6 = 0.0;
				minusHeight = 0f;
				plusHeight = 0f;
				if (yErrorBarInternal != null)
				{
					switch (yErrorBarInternal.Type)
					{
					case ErrorBarValueType.Custom:
					{
						double num8 = 0.0;
						try
						{
							num8 = ((yErrorBarInternal.MinusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.MinusValue[i]) : 0.0);
						}
						catch (Exception ex3)
						{
							Class1165.smethod_28(ex3);
						}
						num5 = num8;
						try
						{
							num8 = ((yErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.PlusValue[i]) : 0.0);
						}
						catch (Exception ex4)
						{
							Class1165.smethod_28(ex4);
						}
						num6 = num8;
						break;
					}
					case ErrorBarValueType.Fixed:
						num5 = yErrorBarInternal.Amount;
						num6 = num5;
						break;
					case ErrorBarValueType.Percentage:
						num5 = yErrorBarInternal.Amount * yValue / 100.0;
						num6 = num5;
						break;
					}
					minusHeight = (float)num5 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
					plusHeight = (float)num6 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
				}
				yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
				num3 = (class2.Axis.IsPlotOrderReversed ? (num3 + num4) : (num3 - num4));
				PointF pointF = new PointF((float)num2, (float)num3);
				object[] array = new object[5];
				if (smethod_1(g, pointF, aSeries, class3, maxBubbleSize, (int)smethod_3(rect), array))
				{
					array[0] = index;
					array[1] = i;
					array[2] = pointF;
					array[3] = @class;
					list.Add(array);
				}
			}
			else
			{
				arrayList.Add(null);
			}
		}
		g.imethod_114(gstate);
		return list;
	}

	private static bool smethod_1(Interface32 g, PointF point, Class759 series, Class748 chartPoint, double maxBubbleSize, int maxBubble_R, object[] aParamOfDataLabels)
	{
		double num = chartPoint.BubbleSizeValue;
		float num2 = (float)series.BubbleScale / 100f;
		Enum149 sizeRepresents = series.SizeRepresents;
		bool showNegativeBubbles = series.ShowNegativeBubbles;
		if (num == 0.0)
		{
			return false;
		}
		if (showNegativeBubbles)
		{
			num = Math.Abs(num);
		}
		else if (num < 0.0)
		{
			return false;
		}
		double num3 = 0.0;
		double num4;
		if (sizeRepresents == Enum149.const_0)
		{
			num3 = Math.PI * Math.Pow(maxBubble_R, 2.0) / maxBubbleSize;
			num4 = Math.Sqrt(num * num3 / Math.PI);
		}
		else
		{
			num3 = (double)(2 * maxBubble_R) / maxBubbleSize;
			num4 = num * num3 / 2.0;
		}
		num4 *= (double)num2;
		aParamOfDataLabels[4] = (float)num4;
		RectangleF rect = new RectangleF(point.X - (float)num4, point.Y - (float)num4, Struct41.smethod_3(2f * (float)num4), Struct41.smethod_3(2f * (float)num4));
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rect);
		if (chartPoint.AreaInternal.Formatting != 0)
		{
			if (chartPoint.BubbleSizeValue > 0.0)
			{
				chartPoint.AreaInternal.method_6(graphicsPath);
			}
			else
			{
				g.imethod_74(new SolidBrush(Color.White), rect);
			}
		}
		chartPoint.BorderInternal.method_8(graphicsPath);
		return true;
	}

	private static double smethod_2(Class757 nSeries, double minValue, double maxValue, double xMinValue, double xMaxValue)
	{
		double num = 0.0;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Class759 @class = nSeries.method_0(i);
			bool showNegativeBubbles = @class.ShowNegativeBubbles;
			if (@class.Type != ChartType.Bubble && @class.Type != ChartType.BubbleWith3D)
			{
				continue;
			}
			Class747 pointsInternal = @class.PointsInternal;
			for (int j = 0; j < pointsInternal.Count; j++)
			{
				Class748 class2 = pointsInternal.method_0(j);
				if (class2 != null && !class2.NotPlotted)
				{
					double num2 = class2.BubbleSizeValue;
					if (showNegativeBubbles)
					{
						num2 = Math.Abs(num2);
					}
					if (num < num2)
					{
						num = num2;
					}
				}
			}
		}
		return num;
	}

	internal static float smethod_3(Rectangle plotArea)
	{
		RectangleF plotArea2 = new RectangleF(plotArea.X, plotArea.Y, plotArea.Width, plotArea.Height);
		return smethod_4(plotArea2);
	}

	internal static float smethod_4(RectangleF plotArea)
	{
		float num = ((plotArea.Width > plotArea.Height) ? plotArea.Height : plotArea.Width);
		return num / 8f;
	}

	internal static void smethod_5(Class784 renderContext, Interface32 g, Class757 nSeries, Rectangle plotArea, int maxPointsCount, bool xIsAutoMajorUnitOriginal, bool xIsAutoMinorUnitOriginal, bool xIsAutoMaximumOriginal, bool xIsAutoMinimumOriginal, bool yIsAutoMajorUnitOriginal, bool yIsAutoMinorUnitOriginal, bool yIsAutoMaximumOriginal, bool yIsAutoMinimumOriginal)
	{
		_ = nSeries.method_0(0).Chart;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		double num = y1AxisRenderContext.MinValue;
		double maxValue = y1AxisRenderContext.MaxValue;
		double num2 = y1AxisRenderContext.MajorUnit;
		double num3 = x1AxisRenderContext.MinValue;
		double num4 = x1AxisRenderContext.MaxValue;
		double num5 = x1AxisRenderContext.MajorUnit;
		double xMaxValue = (num4 - num3) / 2.0;
		double xMinValue = xMaxValue;
		double yMaxValue = (maxValue - num) / 2.0;
		double yMinValue = yMaxValue;
		smethod_7(nSeries, maxPointsCount, ref xMaxValue, ref xMinValue, ref yMaxValue, ref yMinValue);
		double num6 = smethod_3(plotArea);
		double num7 = num6 * (num4 - num3) / (double)plotArea.Width;
		double num8 = num6 * (maxValue - num) / (double)plotArea.Height;
		if (!renderContext.Y1AxisRenderContext.Axis.IsLogarithmic)
		{
			ArrayList arrayList_ = renderContext.Y1AxisRenderContext.arrayList_0;
			bool flag = false;
			if (yIsAutoMinimumOriginal && yMinValue - num8 <= num)
			{
				num = Struct41.smethod_11(num, num2);
				arrayList_.Add(num);
				num8 = num6 * (maxValue - num) / (double)plotArea.Height;
				flag = true;
			}
			if (yIsAutoMaximumOriginal && yMaxValue + num8 * 1.2 >= maxValue)
			{
				maxValue = Struct41.smethod_12(maxValue, num2);
				arrayList_.Insert(0, maxValue);
				num8 = num6 * (maxValue - num) / (double)plotArea.Height;
				flag = true;
			}
			if (yIsAutoMajorUnitOriginal && renderContext.Y1AxisRenderContext.arrayList_0.Count > 11)
			{
				double num9 = num2 * 0.35;
				if (yMinValue - num8 - (double)arrayList_[arrayList_.Count - 1] < num9 || (double)arrayList_[0] - (yMaxValue + num8) < num9)
				{
					flag = true;
					num2 *= 2.0;
					double num10 = (double)arrayList_[0];
					double num11 = (double)arrayList_[arrayList_.Count - 1];
					double num12 = num2;
					int digits = Struct41.smethod_9(num12);
					arrayList_.Clear();
					switch (smethod_6(yIsAutoMaximumOriginal, yIsAutoMinimumOriginal, num10, num11))
					{
					case 1:
					{
						double num14 = num10;
						while (num14 > num11 || Struct41.smethod_11(num11, num14) < num12)
						{
							num14 = Math.Round(num14, digits);
							arrayList_.Add(num14);
							num14 -= num12;
						}
						break;
					}
					case 2:
					{
						double num15 = num11;
						while (num15 <= num10 || Struct41.smethod_11(num15, num10) < num12)
						{
							num15 = Math.Round(num15, digits);
							arrayList_.Add(num15);
							num15 += num12;
						}
						arrayList_.Reverse();
						break;
					}
					default:
					{
						double num13 = 0.0;
						while (num13 <= num10 || Struct41.smethod_11(num13, num10) < num12)
						{
							num13 = Math.Round(num13, digits);
							arrayList_.Add(num13);
							num13 += num12;
						}
						arrayList_.Reverse();
						num13 = 0.0;
						while (num13 > num11 || Struct41.smethod_11(num11, num13) < num12)
						{
							num13 = Math.Round(num13, digits);
							arrayList_.Add(num13);
							num13 -= num12;
						}
						break;
					}
					}
				}
			}
			if (flag)
			{
				if (arrayList_.Count >= 2)
				{
					if (yIsAutoMaximumOriginal)
					{
						y1AxisRenderContext.MaxValue = (double)arrayList_[0];
					}
					if (yIsAutoMinimumOriginal)
					{
						y1AxisRenderContext.MinValue = (double)arrayList_[arrayList_.Count - 1];
					}
					if (yIsAutoMajorUnitOriginal)
					{
						y1AxisRenderContext.MajorUnit = num2;
					}
					if (yIsAutoMinorUnitOriginal)
					{
						y1AxisRenderContext.MinorUnit = num2 / 5.0;
					}
				}
				Struct21.smethod_21(renderContext.Y1AxisRenderContext, g, nSeries.method_0(0), isDisplayAxisSameAsBar: false);
			}
		}
		if (renderContext.X1AxisRenderContext.Axis.IsLogarithmic)
		{
			return;
		}
		ArrayList arrayList_2 = renderContext.X1AxisRenderContext.arrayList_0;
		bool flag2 = false;
		if (xIsAutoMinimumOriginal && xMinValue - num7 <= num3)
		{
			num3 = Struct41.smethod_11(num3, num5);
			arrayList_2.Add(num3);
			num7 = num6 * (num4 - num3) / (double)plotArea.Width;
			flag2 = true;
		}
		if (xIsAutoMaximumOriginal && xMaxValue + num7 >= num4)
		{
			num4 = Struct41.smethod_12(num4, num5);
			arrayList_2.Insert(0, num4);
			num7 = num6 * (num4 - num3) / (double)plotArea.Width;
			flag2 = true;
		}
		if (xIsAutoMinimumOriginal)
		{
			int digits2 = Struct41.smethod_9(num5);
			if ((xMinValue - num7 - (xMaxValue + num7)) / (num3 - (xMaxValue + num7)) > 20.0 / 21.0)
			{
				double num16 = Math.Round(num3 - num5, digits2);
				arrayList_2.Add(num16);
				num3 = num16;
				num7 = num6 * (num4 - num3) / (double)plotArea.Width;
				flag2 = true;
			}
		}
		if (xIsAutoMaximumOriginal)
		{
			int digits3 = Struct41.smethod_9(num5);
			if ((xMaxValue + num7 - (xMinValue - num7)) / (num4 - (xMinValue - num7)) > 20.0 / 21.0)
			{
				double num17 = Math.Round(num4 + num5, digits3);
				arrayList_2.Insert(0, num17);
				num4 = num17;
				num7 = num6 * (num4 - num3) / (double)plotArea.Width;
				flag2 = true;
			}
		}
		if (xIsAutoMajorUnitOriginal && arrayList_2.Count > 11)
		{
			flag2 = true;
			num5 *= 2.0;
			double num18 = (double)arrayList_2[0];
			double num19 = (double)arrayList_2[arrayList_2.Count - 1];
			double num20 = num5;
			int digits4 = Struct41.smethod_9(num20);
			arrayList_2.Clear();
			switch (smethod_6(xIsAutoMaximumOriginal, xIsAutoMinimumOriginal, num18, num19))
			{
			case 1:
			{
				double num22 = num18;
				while (num22 > num19 || Struct41.smethod_11(num19, num22) < num20)
				{
					num22 = Math.Round(num22, digits4);
					arrayList_2.Add(num22);
					num22 -= num20;
				}
				break;
			}
			case 2:
			{
				double num23 = num19;
				while (num23 <= num18 || Struct41.smethod_11(num23, num18) < num20)
				{
					num23 = Math.Round(num23, digits4);
					arrayList_2.Add(num23);
					num23 += num20;
				}
				arrayList_2.Reverse();
				break;
			}
			default:
			{
				double num21 = 0.0;
				while (num21 <= num18 || Struct41.smethod_11(num21, num18) < num20)
				{
					num21 = Math.Round(num21, digits4);
					arrayList_2.Add(num21);
					num21 += num20;
				}
				arrayList_2.Reverse();
				num21 = 0.0;
				while (num21 > num19 || Struct41.smethod_11(num19, num21) < num20)
				{
					num21 = Math.Round(num21, digits4);
					arrayList_2.Add(num21);
					num21 -= num20;
				}
				break;
			}
			}
		}
		if (!flag2)
		{
			return;
		}
		if (arrayList_2.Count >= 2)
		{
			if (xIsAutoMaximumOriginal)
			{
				x1AxisRenderContext.MaxValue = (double)arrayList_2[0];
			}
			if (xIsAutoMinimumOriginal)
			{
				x1AxisRenderContext.MinValue = (double)arrayList_2[arrayList_2.Count - 1];
			}
			if (xIsAutoMajorUnitOriginal)
			{
				x1AxisRenderContext.MajorUnit = num5;
			}
			if (xIsAutoMinorUnitOriginal)
			{
				x1AxisRenderContext.MinorUnit = num5 / 5.0;
			}
		}
		Struct21.smethod_23(renderContext.X1AxisRenderContext, g, plotArea, maxPointsCount, isDisplayAxisSameAsBar: false, nSeries.method_0(0));
	}

	private static int smethod_6(bool isAutoMaximum, bool isAutoMinimum, double minValue, double maxValue)
	{
		int num = 2;
		if (!isAutoMaximum || !isAutoMinimum)
		{
			num = ((!isAutoMaximum && isAutoMinimum) ? 1 : ((!isAutoMaximum || isAutoMinimum) ? 2 : 2));
		}
		else
		{
			num = 3;
			if (minValue == 0.0)
			{
				num = 2;
			}
			if (maxValue == 0.0)
			{
				num = 1;
			}
		}
		return num;
	}

	private static void smethod_7(Class757 nSeries, int maxPointsCount, ref double xMaxValue, ref double xMinValue, ref double yMaxValue, ref double yMinValue)
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Class747 pointsInternal = nSeries.method_0(i).PointsInternal;
			for (int j = 0; j < maxPointsCount; j++)
			{
				Class748 @class = pointsInternal.method_0(j);
				if (@class != null && !@class.XNotPlotted)
				{
					if (!flag)
					{
						xMaxValue = @class.XValue;
						xMinValue = xMaxValue;
						flag = true;
					}
					else
					{
						if (@class.XValue > xMaxValue)
						{
							xMaxValue = @class.XValue;
						}
						if (@class.XValue < xMinValue)
						{
							xMinValue = @class.XValue;
						}
					}
				}
				if (@class == null || @class.NotPlotted)
				{
					continue;
				}
				if (!flag2)
				{
					yMaxValue = @class.YValue;
					yMinValue = yMaxValue;
					flag2 = true;
					continue;
				}
				if (@class.YValue > yMaxValue)
				{
					yMaxValue = @class.YValue;
				}
				if (@class.YValue < yMinValue)
				{
					yMinValue = @class.YValue;
				}
			}
		}
	}
}
