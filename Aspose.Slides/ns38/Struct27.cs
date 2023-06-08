using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns2;
using ns33;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct27
{
	internal static List<object[]> smethod_0(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Enum141 axisGroup = aSeries.AxisGroup;
		int num;
		Class783 @class;
		Class783 class2;
		if (axisGroup == Enum141.const_0)
		{
			num = nSeriesInternal.method_4(Enum141.const_0);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
		}
		else
		{
			num = nSeriesInternal.method_4(Enum141.const_1);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
		}
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_2(g, aSeries, rect, categoryAxisY, categoryAxisCrossAt, renderContext);
		}
		double logMaxValue = class2.LogMaxValue;
		double logMinValue = class2.LogMinValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		float num2 = 0f;
		float num3 = 1.5f;
		Class759 class3 = chart.NSeriesInternal.method_3(axisGroup);
		if (class3 != null)
		{
			num2 = (float)class3.Overlap / 100f;
			num3 = (float)class3.GapWidth / 100f;
		}
		List<object[]> list = new List<object[]>();
		int num4 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num4 = maxPointsCount - 1;
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		else
		{
			num4 = maxPointsCount;
		}
		double num5 = (double)rect.Width / (double)num4;
		ChartType[] chartType = new ChartType[1];
		int num6 = nSeriesInternal.method_12(aSeries, axisGroup, chartType);
		if (num6 == -1)
		{
			return list;
		}
		int index = aSeries.Index;
		Class747 pointsInternal = aSeries.PointsInternal;
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			Class748 class4 = pointsInternal.method_0(i);
			float num7 = (float)num5 / ((float)num - num2 * (float)(num - 1) + num3);
			float num8 = num7 * num2;
			float num9 = num7 * num3;
			float num10 = (float)num6 * (num7 - num8);
			float num11 = (float)num5 * (float)i + num9 / 2f + num10;
			if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
			{
				num11 -= (float)(num5 / 2.0);
			}
			num11 = (@class.Axis.IsPlotOrderReversed ? ((float)(rect.X + rect.Width) - num11 - num7) : ((float)rect.X + num11));
			if (class4 == null || class4.NotPlotted)
			{
				continue;
			}
			double yValue = class4.YValue;
			float num12 = (float)(categoryAxisCrossAt - yValue) / (float)(logMaxValue - logMinValue) * (float)rect.Height;
			bool flag = num12 == 0f;
			Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
			PointF originPoint = new PointF(num11 + num7 / 2f, categoryAxisY);
			double num13 = 0.0;
			double num14 = 0.0;
			float minusHeight = 0f;
			float plusHeight = 0f;
			if (yErrorBarInternal != null)
			{
				switch (yErrorBarInternal.Type)
				{
				case ErrorBarValueType.Custom:
				{
					double num15 = 0.0;
					try
					{
						num15 = ((yErrorBarInternal.MinusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.MinusValue[i]) : 0.0);
					}
					catch (Exception ex)
					{
						Class1165.smethod_28(ex);
					}
					num13 = num15;
					try
					{
						num15 = ((yErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.PlusValue[i]) : 0.0);
					}
					catch (Exception ex2)
					{
						Class1165.smethod_28(ex2);
					}
					num14 = num15;
					break;
				}
				case ErrorBarValueType.Fixed:
					num13 = yErrorBarInternal.Amount;
					num14 = num13;
					break;
				case ErrorBarValueType.Percentage:
					num13 = yErrorBarInternal.Amount * yValue / 100.0;
					num14 = num13;
					break;
				}
				minusHeight = (float)num13 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
				plusHeight = (float)num14 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
				if (!class2.Axis.IsPlotOrderReversed)
				{
					originPoint.Y += num12;
				}
				else
				{
					originPoint.Y -= num12;
				}
			}
			yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
			float num16 = categoryAxisY;
			if (!class2.Axis.IsPlotOrderReversed)
			{
				if (num12 < 0f)
				{
					num12 = 0f - num12;
					num16 -= num12;
				}
			}
			else if (num12 < 0f)
			{
				num12 = 0f - num12;
			}
			else
			{
				num16 -= num12;
			}
			RectangleF rectangleF = new RectangleF(num11, num16, num7, num12 + 1f);
			if (rectangleF.Y < (float)rect.Y)
			{
				rectangleF.Height -= (float)rect.Y - rectangleF.Y;
				rectangleF.Y = rect.Y;
			}
			if (rectangleF.Bottom > (float)(rect.Bottom + 1))
			{
				rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
			}
			if (!(rectangleF.Right >= (float)rect.X) || !(rectangleF.Left <= (float)rect.Right))
			{
				continue;
			}
			if (rectangleF.X < (float)rect.X)
			{
				rectangleF.Width -= (float)rect.X - rectangleF.X;
				rectangleF.X = rect.X;
			}
			else if (rectangleF.Right > (float)rect.Right)
			{
				rectangleF.Width -= rectangleF.Right - (float)rect.Right;
			}
			if (rectangleF.Width + 1f >= (num7 - 1f) / 3f)
			{
				if (!flag)
				{
					smethod_3(g, class4, rectangleF, categoryAxisY, rect);
				}
				object[] array = new object[5];
				bool flag2 = rectangleF.Y < categoryAxisY || (yValue == 0.0 && !class2.Axis.IsPlotOrderReversed);
				array[0] = index;
				array[1] = i;
				array[2] = rectangleF;
				array[3] = @class;
				array[4] = flag2;
				list.Add(array);
			}
		}
		return list;
	}

	private static void smethod_1(Interface32 g, Class746 bars, RectangleF rect)
	{
		bars.AreaInternal.method_5(rect);
		if (bars.BorderInternal.IsVisible)
		{
			if (rect.Width > (float)bars.BorderInternal.Width / 2f)
			{
				rect.Width -= (float)bars.BorderInternal.Width / 2f;
			}
			if (rect.Height < 1f)
			{
				rect.Height = 1f;
			}
			bars.BorderInternal.method_7(rect);
		}
	}

	private static List<object[]> smethod_2(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		_ = chart.NSeriesInternal.Count;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Enum141 axisGroup = aSeries.AxisGroup;
		float num = 0f;
		float num2 = 1.5f;
		Class759 @class = chart.NSeriesInternal.method_3(axisGroup);
		if (@class != null)
		{
			num = (float)@class.Overlap / 100f;
			num2 = (float)@class.GapWidth / 100f;
		}
		int num3;
		Class783 class2;
		Class783 class3;
		List<int> list;
		if (axisGroup == Enum141.const_0)
		{
			num3 = nSeriesInternal.method_4(Enum141.const_0);
			class2 = renderContext.Y1AxisRenderContext;
			class3 = renderContext.X1AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			num3 = nSeriesInternal.method_4(Enum141.const_1);
			class2 = renderContext.Y2AxisRenderContext;
			class3 = renderContext.X2AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		double logMaxValue = class2.LogMaxValue;
		double logMinValue = class2.LogMinValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		List<object[]> list2 = new List<object[]>();
		int count = list.Count;
		TimeUnitType baseUnitScale = class3.Axis.BaseUnitScale;
		int minValue = (int)class3.MinValue;
		int maxValue = (int)class3.MaxValue;
		int num4 = 0;
		if (!class3.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num4 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		else
		{
			num4 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		double num5 = (double)rect.Width / (double)num4;
		int num6 = 0;
		while (true)
		{
			if (num6 < count)
			{
				Class748 class4 = aSeries.PointsInternal.method_0(num6);
				float num7 = (float)(num5 / (double)((float)num3 - num * (float)(num3 - 1) + num2));
				float num8 = num7 * num;
				float num9 = num7 * num2;
				int val = int.Parse(list[num6].ToString());
				val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
				int num10 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
				float num11 = (float)(num5 * (double)num10);
				if (!class3.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
				{
					num11 -= (float)(num5 / 2.0);
				}
				float num12 = 0f;
				num12 = ((!class3.Axis.IsPlotOrderReversed) ? ((float)rect.X + num11 + num9 / 2f + 1f) : ((float)(rect.X + rect.Width) - num11 - num9 / 2f - num7 - 1f));
				ChartType[] chartType = new ChartType[1];
				int num13 = nSeriesInternal.method_12(aSeries, axisGroup, chartType);
				if (num13 == -1)
				{
					break;
				}
				int index = aSeries.Index;
				num12 = ((!class3.Axis.IsPlotOrderReversed) ? (num12 + (float)num13 * (num7 - num8)) : (num12 - (float)num13 * (num7 - num8)));
				if (class4 != null && !class4.NotPlotted)
				{
					double yValue = class4.YValue;
					float num14 = (float)(categoryAxisCrossAt - yValue) / (float)(logMaxValue - logMinValue) * (float)rect.Height;
					bool flag = false;
					if (num14 == 0f)
					{
						flag = true;
					}
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(num12 + num7 / 2f, categoryAxisY);
					double num15 = 0.0;
					double num16 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num17 = 0.0;
							try
							{
								num17 = ((yErrorBarInternal.MinusValue.Count > num6) ? Convert.ToDouble(yErrorBarInternal.MinusValue[num6]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num15 = num17;
							try
							{
								num17 = ((yErrorBarInternal.PlusValue.Count > num6) ? Convert.ToDouble(yErrorBarInternal.PlusValue[num6]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num16 = num17;
							break;
						}
						case ErrorBarValueType.Fixed:
							num15 = yErrorBarInternal.Amount;
							num16 = num15;
							break;
						case ErrorBarValueType.Percentage:
							num15 = yErrorBarInternal.Amount * yValue / 100.0;
							num16 = num15;
							break;
						}
						minusHeight = (float)num15 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
						plusHeight = (float)num16 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							originPoint.Y += num14;
						}
						else
						{
							originPoint.Y -= num14;
						}
					}
					yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					float num18 = categoryAxisY;
					if (!class2.Axis.IsPlotOrderReversed)
					{
						if (num14 < 0f)
						{
							num14 = 0f - num14;
							num18 -= num14;
						}
					}
					else if (num14 < 0f)
					{
						num14 = 0f - num14;
					}
					else
					{
						num18 -= num14;
					}
					RectangleF rectangleF = ((num7 < 1f) ? new RectangleF(num12, num18, 1f, num14 + 1f) : new RectangleF(num12, num18, num7, num14 + 1f));
					if (rectangleF.Y < (float)rect.Y)
					{
						rectangleF.Height -= (float)rect.Y - rectangleF.Y;
						rectangleF.Y = rect.Y;
					}
					if (rectangleF.Bottom > (float)(rect.Bottom + 1))
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
					}
					if (rectangleF.Right >= (float)rect.X && rectangleF.Left <= (float)rect.Right)
					{
						if (rectangleF.X < (float)rect.X)
						{
							rectangleF.Width -= (float)rect.X - rectangleF.X;
							rectangleF.X = rect.X;
						}
						else if (rectangleF.Right > (float)rect.Right)
						{
							rectangleF.Width -= rectangleF.Right - (float)rect.Right;
						}
						if (rectangleF.Width + 1f >= (num7 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_3(g, class4, rectangleF, categoryAxisY, rect);
							}
							object[] array = new object[5];
							bool flag2 = rectangleF.Y < categoryAxisY || (yValue == 0.0 && ((!class2.Axis.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num6;
							array[2] = rectangleF;
							array[3] = class3;
							array[4] = flag2;
							list2.Add(array);
						}
					}
				}
				num6++;
				continue;
			}
			return list2;
		}
		return list2;
	}

	private static void smethod_3(Interface32 g, Class748 point, RectangleF rect, float categoryAxisY, Rectangle plotRect)
	{
		smethod_4(point);
		if (point.AreaInternal.Formatting != 0)
		{
			if (rect.Bottom > (float)plotRect.Bottom && !point.BorderInternal.method_14())
			{
				rect.Height -= rect.Bottom - (float)plotRect.Bottom;
			}
			point.AreaInternal.method_5(rect);
		}
		rect.Width -= (float)point.BorderInternal.Width / 2f;
		rect.Height -= (float)point.BorderInternal.Width / 2f;
		point.BorderInternal.method_7(rect);
	}

	internal static void smethod_4(Class748 point)
	{
		Class741 areaInternal = point.AreaInternal;
		Class755 borderInternal = point.BorderInternal;
		if (!areaInternal.method_17() || areaInternal.IsFillFormat || areaInternal.Formatting == FillType.NoFill)
		{
			return;
		}
		if (point.Chart.StyleIndex <= 16)
		{
			if (areaInternal.BackgroundColor.IsEmpty)
			{
				areaInternal.BackgroundColor = Color.White;
			}
			if (borderInternal.Formatting != FillType.Gradient)
			{
				borderInternal.Color = Color.Black;
			}
		}
		else
		{
			areaInternal.BackgroundColor = areaInternal.ForegroundColor;
		}
	}

	internal static void smethod_5(Interface32 g, Class740 chart, ArrayList paramOfDataLabels, Class784 renderContext)
	{
		for (int i = 0; i < paramOfDataLabels.Count; i++)
		{
			object[] array = (object[])paramOfDataLabels[i];
			int seriesIndex = (int)array[0];
			int chartPointIndex = (int)array[1];
			RectangleF rectPoint = (RectangleF)array[2];
			Class783 @class = (Class783)array[3];
			Class783 axisRenderContext = ((@class == renderContext.X1AxisRenderContext) ? renderContext.X1AxisRenderContext : renderContext.X2AxisRenderContext);
			bool isAtCategoryAxisUp = (bool)array[4];
			int scaleWidth = (int)((float)chart.Width * Struct41.float_0);
			smethod_6(g, seriesIndex, chartPointIndex, rectPoint, isAtCategoryAxisUp, scaleWidth, renderContext, axisRenderContext);
		}
	}

	private static void smethod_6(Interface32 g, int seriesIndex, int chartPointIndex, RectangleF rectPoint, bool isAtCategoryAxisUp, int scaleWidth, Class784 renderContext, Class783 axisRenderContext)
	{
		Class757 nSeriesInternal = renderContext.Chart2007.NSeriesInternal;
		nSeriesInternal.method_0(seriesIndex);
		Class750 dataLabelsInternal = nSeriesInternal.method_0(seriesIndex).PointsInternal.method_0(chartPointIndex).DataLabelsInternal;
		SizeF sizeF = Struct28.smethod_0(g, nSeriesInternal, seriesIndex, chartPointIndex, scaleWidth, renderContext, axisRenderContext);
		float num = rectPoint.X + rectPoint.Width / 2f - sizeF.Width / 2f;
		float num2 = 0f;
		switch (dataLabelsInternal.LabelPosition)
		{
		default:
			if (isAtCategoryAxisUp)
			{
				num2 = rectPoint.Y - sizeF.Height;
				num2 += -1f;
			}
			else
			{
				num2 = rectPoint.Y + rectPoint.Height;
				num2 += 5f;
			}
			break;
		case LegendDataLabelPosition.Center:
			num2 = rectPoint.Y + rectPoint.Height / 2f - sizeF.Height / 2f;
			break;
		case LegendDataLabelPosition.InsideBase:
			if (isAtCategoryAxisUp)
			{
				num2 = rectPoint.Y + rectPoint.Height - sizeF.Height;
				num2 += -1f;
			}
			else
			{
				num2 = rectPoint.Y;
				num2 += 5f;
			}
			break;
		case LegendDataLabelPosition.InsideEnd:
			if (isAtCategoryAxisUp)
			{
				num2 = rectPoint.Y;
				num2 += 5f;
			}
			else
			{
				num2 = rectPoint.Y + rectPoint.Height - sizeF.Height;
				num2 += -1f;
			}
			break;
		}
		Class759 @class = nSeriesInternal.method_0(seriesIndex);
		ChartType[] chartType = new ChartType[1];
		if (@class.method_2(chartType))
		{
			if (isAtCategoryAxisUp)
			{
				if (num2 + (float)Struct28.int_0 + sizeF.Height > rectPoint.Bottom)
				{
					num2 -= num2 + (float)Struct28.int_0 + sizeF.Height - rectPoint.Bottom;
				}
			}
			else if (num2 < rectPoint.Y)
			{
				num2 += rectPoint.Y - num2;
			}
		}
		dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_5(num), Struct41.smethod_5(num2), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
		dataLabelsInternal.ChartFrameInternal.method_6();
		Struct28.smethod_1(g, nSeriesInternal, seriesIndex, chartPointIndex, dataLabelsInternal.ChartFrameInternal.rectangle_0, renderContext, axisRenderContext);
	}

	internal static void smethod_7(Interface32 g, Class759 aSeries, ArrayList list, Rectangle rect)
	{
		GraphicsState gstate = g.Save();
		SmoothingMode smoothingMode = g.SmoothingMode;
		g.SmoothingMode = SmoothingMode.HighQuality;
		RectangleF clipBounds = g.ClipBounds;
		g.imethod_121(rect);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != null)
			{
				PointF pointF = (PointF)list[i];
				if (smethod_18(new PointF(pointF.X / 10f, pointF.Y / 10f), clipBounds))
				{
					list[i] = null;
				}
			}
		}
		if (aSeries.Smooth)
		{
			if (list.Count > 1)
			{
				_ = list[0];
				ArrayList arrayList = new ArrayList();
				for (int j = 0; j < list.Count; j++)
				{
					Class748 @class = aSeries.PointsInternal.method_0(j);
					if (j == list.Count - 1 && (aSeries.Type == ChartType.Radar || aSeries.Type == ChartType.RadarWithMarkers))
					{
						@class = aSeries.PointsInternal.method_0(0);
					}
					if (@class == null)
					{
						if (arrayList.Count > 1)
						{
							smethod_14(g, aSeries, arrayList, rect);
						}
						arrayList.Clear();
					}
					else
					{
						if (@class != null && (@class.IsXValueError || @class.IsYValueError || @class.Interpolated))
						{
							continue;
						}
						if (list[j] != null)
						{
							PointF pointF2 = (PointF)list[j];
							arrayList.Add(pointF2);
							continue;
						}
						if (arrayList.Count > 1)
						{
							smethod_14(g, aSeries, arrayList, rect);
						}
						arrayList.Clear();
					}
				}
				if (arrayList.Count > 1)
				{
					smethod_14(g, aSeries, arrayList, rect);
				}
			}
		}
		else if (list.Count > 1)
		{
			ArrayList arrayList2 = new ArrayList();
			object obj = list[0];
			Class748 class2 = aSeries.PointsInternal.method_0(0);
			if (obj != null)
			{
				arrayList2.Add(obj);
			}
			for (int k = 1; k < list.Count; k++)
			{
				object obj2 = list[k];
				Class748 class3 = aSeries.PointsInternal.method_0(k);
				if (k == list.Count - 1 && (aSeries.Type == ChartType.Radar || aSeries.Type == ChartType.RadarWithMarkers))
				{
					class3 = aSeries.PointsInternal.method_0(0);
				}
				if (class3 != null && (class3.IsXValueError || class3.IsYValueError || class3.Interpolated))
				{
					continue;
				}
				if (class3 != null && obj2 != null)
				{
					if (!class2.BorderInternal.method_0(class3.BorderInternal) && arrayList2.Count > 1)
					{
						new GraphicsPath();
						PointF[] points = smethod_13(arrayList2);
						smethod_9(g, points, class2);
						class2 = class3;
						PointF pointF3 = (PointF)arrayList2[arrayList2.Count - 1];
						arrayList2.Clear();
						if (obj2 != null)
						{
							arrayList2.Add(pointF3);
							arrayList2.Add(obj2);
							continue;
						}
					}
					if (obj2 != null)
					{
						arrayList2.Add(obj2);
					}
					class2 = class3;
				}
				else
				{
					obj = obj2;
					if (arrayList2.Count > 1)
					{
						new GraphicsPath();
						PointF[] points2 = smethod_13(arrayList2);
						smethod_9(g, points2, class2);
					}
					arrayList2.Clear();
					class2 = class3;
				}
			}
			if (arrayList2.Count > 1)
			{
				new GraphicsPath();
				PointF[] points3 = smethod_13(arrayList2);
				smethod_9(g, points3, class2);
			}
		}
		g.SmoothingMode = smoothingMode;
		g.imethod_114(gstate);
	}

	private static double smethod_8(PointF p1, PointF p2, PointF p3)
	{
		double num = Math.Sqrt(Math.Pow(p2.Y - p1.Y, 2.0) + Math.Pow(p2.X - p1.X, 2.0));
		double num2 = Math.Sqrt(Math.Pow(p3.Y - p2.Y, 2.0) + Math.Pow(p3.X - p2.X, 2.0));
		double x = Math.Sqrt(Math.Pow(p3.Y - p1.Y, 2.0) + Math.Pow(p3.X - p1.X, 2.0));
		double d = (Math.Pow(num, 2.0) + Math.Pow(num2, 2.0) - Math.Pow(x, 2.0)) / (2.0 * num * num2);
		return Math.Acos(d);
	}

	private static void smethod_9(Interface32 g, PointF[] points, Class748 chartPoint)
	{
		if (points.Length < 3)
		{
			chartPoint.BorderInternal.method_5(points[0], points[1]);
			return;
		}
		smethod_12(ref points);
		ArrayList arrayList = new ArrayList();
		PointF pointF = points[0];
		PointF pointF2 = points[1];
		arrayList.Add(pointF);
		arrayList.Add(pointF2);
		for (int i = 2; i < points.Length; i++)
		{
			PointF pointF3 = points[i];
			double num = smethod_8(pointF, pointF2, pointF3);
			num = num * 180.0 / Math.PI;
			if (num < 30.0)
			{
				smethod_10(g, arrayList, chartPoint);
				chartPoint.BorderInternal.method_5(pointF2, pointF3);
				pointF = pointF2;
				pointF2 = pointF3;
				arrayList.Clear();
				arrayList.Add(pointF);
				arrayList.Add(pointF2);
			}
			else
			{
				arrayList.Add(pointF3);
				pointF = pointF2;
				pointF2 = pointF3;
			}
		}
		if (arrayList.Count > 1)
		{
			smethod_10(g, arrayList, chartPoint);
		}
	}

	private static void smethod_10(Interface32 g, ArrayList points, Class748 chartPoint)
	{
		if (points.Count == 2)
		{
			chartPoint.BorderInternal.method_5((PointF)points[0], (PointF)points[1]);
			return;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] points2 = smethod_13(points);
		graphicsPath.AddLines(points2);
		Pen pen = chartPoint.BorderInternal.method_9(graphicsPath);
		g.imethod_45(pen, graphicsPath);
	}

	private static void smethod_11(ArrayList list)
	{
		PointF pointF = PointF.Empty;
		if (list.Count > 0)
		{
			pointF = (PointF)list[0];
		}
		for (int i = 1; i < list.Count; i++)
		{
			PointF pointF2 = (PointF)list[i];
			if (list.Count > 2)
			{
				if (Math.Abs(pointF.X - pointF2.X) < 1f && Math.Abs(pointF.Y - pointF2.Y) < 1f)
				{
					list.RemoveAt(i);
					i--;
				}
				else
				{
					pointF = (PointF)list[i];
				}
				continue;
			}
			break;
		}
	}

	private static void smethod_12(ref PointF[] list)
	{
		PointF pointF = PointF.Empty;
		if (list.Length > 0)
		{
			pointF = list[0];
		}
		int num = 0;
		for (int i = 1; i < list.Length; i++)
		{
			PointF pointF2 = list[i];
			if (list.Length - num <= 2)
			{
				break;
			}
			if (Math.Abs(pointF.X - pointF2.X) < 1f && Math.Abs(pointF.Y - pointF2.Y) < 1f)
			{
				ref PointF reference = ref list[i];
				reference = PointF.Empty;
				num++;
			}
			else
			{
				pointF = list[i];
			}
		}
		if (num <= 0)
		{
			return;
		}
		PointF[] array = new PointF[list.Length - num];
		int num2 = 0;
		for (int j = 0; j < list.Length; j++)
		{
			if (!list[j].IsEmpty)
			{
				ref PointF reference2 = ref array[num2];
				reference2 = list[j];
				num2++;
			}
		}
		list = array;
	}

	internal static PointF[] smethod_13(IList list)
	{
		PointF[] array = new PointF[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			ref PointF reference = ref array[i];
			reference = (PointF)list[i];
		}
		return array;
	}

	private static void smethod_14(Interface32 g, Class759 aSeries, ArrayList list, Rectangle rect)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = Struct41.smethod_15(list);
		if (array.Length <= 1)
		{
			return;
		}
		graphicsPath.AddCurve(array);
		Pen pen = aSeries.LineInternal.method_9(graphicsPath);
		float tension = 0.3f;
		float tension2 = 0.5f;
		if (list.Count < 3)
		{
			g.imethod_19(pen, smethod_13(list), tension2);
			return;
		}
		ArrayList arrayList = new ArrayList();
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < list.Count; i++)
		{
			PointF pointF = (PointF)list[i];
			arrayList.Add(pointF);
			if (arrayList.Count >= 3)
			{
				PointF pointF2 = (PointF)arrayList[arrayList.Count - 3];
				PointF pointF3 = (PointF)arrayList[arrayList.Count - 2];
				float value = (pointF3.Y - pointF2.Y) / (pointF3.X - pointF2.X);
				float value2 = (pointF.Y - pointF3.Y) / (pointF.X - pointF3.X);
				float num = pointF3.Y - pointF2.Y;
				float num2 = pointF.Y - pointF3.Y;
				Math.Abs(Math.Abs(value2) - Math.Abs(value));
				if (Math.Abs(value2) < 2f || num2 / num < 8f)
				{
					continue;
				}
			}
			bool flag3;
			if (flag3 = smethod_17(pointF, rect))
			{
				if (flag2)
				{
					int num3 = arrayList.Count - 1 - 1;
					for (i++; i < list.Count; i++)
					{
						PointF pointF4 = (PointF)list[i];
						if (!smethod_17(pointF4, rect))
						{
							break;
						}
						arrayList.Add(pointF4);
					}
					i--;
					if (arrayList.Count != 2 && num3 != 0)
					{
						if (arrayList.Count > 2)
						{
							g.imethod_19(pen, smethod_16(arrayList, 0, num3), tension2);
							smethod_15(g, pen, smethod_16(arrayList, num3, arrayList.Count - 1), tension);
							arrayList.Clear();
							arrayList.Add(pointF);
							flag = false;
							flag2 = false;
						}
					}
					else
					{
						smethod_15(g, pen, smethod_13(arrayList), tension);
						arrayList.Clear();
						arrayList.Add(pointF);
						flag = false;
						flag2 = false;
					}
				}
			}
			else if (flag)
			{
				smethod_15(g, pen, smethod_13(arrayList), tension);
				arrayList.Clear();
				arrayList.Add(pointF);
				flag = false;
				flag2 = false;
			}
			if (flag3)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
		}
		if (arrayList.Count > 1)
		{
			if (flag)
			{
				smethod_15(g, pen, smethod_13(arrayList), tension);
			}
			else
			{
				g.imethod_19(pen, smethod_13(arrayList), tension2);
			}
		}
	}

	private static void smethod_15(Interface32 g, Pen pen, PointF[] points, float tension)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		for (int i = 0; i < points.Length; i++)
		{
			if (i == 0)
			{
				num = points[i].X;
				num2 = num;
				num3 = points[i].Y;
				num4 = num3;
				continue;
			}
			if (points[i].X < num)
			{
				num = points[i].X;
			}
			if (points[i].X > num2)
			{
				num2 = points[i].X;
			}
			if (points[i].Y < num3)
			{
				num3 = points[i].Y;
			}
			if (points[i].Y > num4)
			{
				num4 = points[i].Y;
			}
		}
		int num5 = Struct41.smethod_13(num2 - num);
		int num6 = Struct41.smethod_13(num4 - num3);
		int num7 = ((num5 > num6) ? num5 : num6);
		if (num7 > 4)
		{
			tension *= (float)Math.Pow(10.0, 4 - num7);
		}
		g.imethod_19(pen, points, tension);
	}

	private static PointF[] smethod_16(IList list, int startIndex, int endIndex)
	{
		PointF[] array = new PointF[endIndex - startIndex + 1];
		for (int i = startIndex; i <= endIndex; i++)
		{
			ref PointF reference = ref array[i - startIndex];
			reference = (PointF)list[i];
		}
		return array;
	}

	private static bool smethod_17(PointF point, Rectangle rect)
	{
		RectangleF rect2 = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		return smethod_18(point, rect2);
	}

	private static bool smethod_18(PointF point, RectangleF rect)
	{
		if (!((point.X < rect.X) | (point.X > rect.Right)) && !(point.Y < rect.Y) && point.Y <= rect.Bottom)
		{
			return false;
		}
		return true;
	}

	internal static List<object[]> smethod_19(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, ref bool upDownBarsHaveBeenDrawn, ref bool hiLoLinesHaveBeenDrawn, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		ChartType[] chartType = new ChartType[2]
		{
			ChartType.Line,
			ChartType.LineWithMarkers
		};
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
			@class = ((renderContext.X2AxisRenderContext.Axis == null) ? renderContext.X1AxisRenderContext : renderContext.X2AxisRenderContext);
			class2 = ((renderContext.Y2AxisRenderContext.Axis == null) ? renderContext.Y1AxisRenderContext : renderContext.Y2AxisRenderContext);
		}
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_22(g, aSeries, rect, categoryAxisY, (float)categoryAxisCrossAt, renderContext);
		}
		Class757 nSeriesInternal = chart.NSeriesInternal;
		float num = (float)aSeries.GapWidth / 100f;
		double logMaxValue = class2.LogMaxValue;
		double logMinValue = class2.LogMinValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		bool hasDropLines = aSeries.HasDropLines;
		bool flag = false;
		bool flag2 = false;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
		Class755 highLowLinesInternal = aSeries.HighLowLinesInternal;
		Class746 upBarsInternal = aSeries.UpBarsInternal;
		Class746 downBarsInternal = aSeries.DownBarsInternal;
		List<object[]> list = new List<object[]>();
		int num2 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num2 = maxPointsCount - 1;
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = maxPointsCount;
		}
		double num3 = (double)rect.Width / (double)num2;
		ArrayList arrayList = new ArrayList();
		List<Class759> list2 = nSeriesInternal.method_10(axisGroup, chartType);
		for (int i = 0; i < list2.Count; i++)
		{
			Class759 class3 = list2[i];
			int index = class3.Index;
			ArrayList arrayList2 = new ArrayList();
			Class747 pointsInternal = class3.PointsInternal;
			for (int j = 0; j < maxPointsCount; j++)
			{
				Class748 class4 = pointsInternal.method_0(j);
				if (class4 != null && !class4.NotPlotted)
				{
					double num4 = (float)num3 * (float)j + 1f;
					if (@class.AxisBetweenCategories || renderContext.Chart.HasDataTable)
					{
						num4 += (double)(float)(num3 / 2.0);
					}
					num4 = ((!@class.Axis.IsPlotOrderReversed) ? ((double)rect.X + num4) : ((double)(rect.X + rect.Width) - num4));
					double num5 = categoryAxisY;
					double yValue = class4.YValue;
					double num6 = (yValue - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)rect.Height;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF((float)num4, categoryAxisY);
					double num7 = 0.0;
					double num8 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num9 = 0.0;
							try
							{
								num9 = ((yErrorBarInternal.MinusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.MinusValue[j]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num7 = num9;
							try
							{
								num9 = ((yErrorBarInternal.PlusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.PlusValue[j]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num8 = num9;
							break;
						}
						case ErrorBarValueType.Fixed:
							num7 = yErrorBarInternal.Amount;
							num8 = num7;
							break;
						case ErrorBarValueType.Percentage:
							num7 = yErrorBarInternal.Amount * yValue / 100.0;
							num8 = num7;
							break;
						}
						minusHeight = (float)num7 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
						plusHeight = (float)num8 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							originPoint.Y -= (float)num6;
						}
						else
						{
							originPoint.Y += (float)num6;
						}
					}
					if (class3.Equals(aSeries))
					{
						yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					}
					num5 = (class2.Axis.IsPlotOrderReversed ? (num5 + num6) : (num5 - num6));
					PointF pointF = new PointF((float)num4, (float)num5);
					arrayList2.Add(pointF);
					if (class3.Equals(aSeries))
					{
						if (hasDropLines)
						{
							dropLinesInternal.method_3((float)num4, (float)num5, (float)num4, categoryAxisY);
						}
						list.Add(new object[4] { index, j, pointF, @class });
					}
				}
				else
				{
					arrayList2.Add(null);
				}
			}
			if (class3.Equals(aSeries) && arrayList2.Count > 1)
			{
				smethod_7(g, aSeries, arrayList2, rect);
			}
			arrayList.Add(arrayList2);
		}
		for (int k = 0; k < maxPointsCount; k++)
		{
			bool flag3 = false;
			bool flag4 = false;
			float num10 = 0f;
			float num11 = 0f;
			float num12 = 0f;
			bool flag5 = false;
			bool flag6 = false;
			float num13 = 0f;
			float num14 = 0f;
			for (int l = 0; l < arrayList.Count; l++)
			{
				ArrayList arrayList3 = (ArrayList)arrayList[l];
				if (arrayList3.Count <= k || k >= arrayList3.Count || arrayList3[k] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList3[k];
				num12 = pointF2.X;
				if (!flag3)
				{
					num10 = pointF2.Y;
					flag3 = true;
				}
				else if (!flag4)
				{
					if (num10 < pointF2.Y)
					{
						num11 = num10;
						num10 = pointF2.Y;
						flag4 = true;
					}
					else
					{
						num11 = pointF2.Y;
						flag4 = true;
					}
				}
				else
				{
					if (num10 < pointF2.Y)
					{
						num10 = pointF2.Y;
					}
					if (num11 > pointF2.Y)
					{
						num11 = pointF2.Y;
					}
				}
				if (l == 0)
				{
					num13 = pointF2.Y;
					flag5 = true;
				}
				else if (l == arrayList.Count - 1)
				{
					num14 = pointF2.Y;
					flag6 = true;
				}
			}
			if (aSeries.HasHighLowLines && flag3 && flag4 && !hiLoLinesHaveBeenDrawn)
			{
				highLowLinesInternal.method_3(num12, num10, num12, num11);
				flag2 = true;
			}
			if (aSeries.HasUpDownBars && !upDownBarsHaveBeenDrawn && flag5 && flag6)
			{
				int num15 = (int)(num3 / (double)(1f + num));
				RectangleF rect2 = default(RectangleF);
				if (num13 <= num14)
				{
					rect2.Width = num15;
					rect2.Height = num14 - num13;
					rect2.X = num12 - rect2.Width / 2f;
					rect2.Y = num13;
					smethod_1(g, downBarsInternal, rect2);
				}
				else
				{
					rect2.Width = num15;
					rect2.Height = num13 - num14;
					rect2.X = num12 - rect2.Width / 2f;
					rect2.Y = num14;
					smethod_1(g, upBarsInternal, rect2);
				}
				flag = true;
			}
		}
		if (!upDownBarsHaveBeenDrawn)
		{
			upDownBarsHaveBeenDrawn = flag;
		}
		if (!hiLoLinesHaveBeenDrawn)
		{
			hiLoLinesHaveBeenDrawn = flag2;
		}
		for (int m = 0; m < list.Count; m++)
		{
			object[] array = list[m];
			int index2 = (int)array[0];
			int index3 = (int)array[1];
			PointF pointF3 = (PointF)array[2];
			nSeriesInternal.method_0(index2).PointsInternal.method_0(index3).MarkerInternal.method_4(pointF3.X, pointF3.Y);
		}
		return list;
	}

	internal static void smethod_20(Interface32 g, int seriesIndex, int chartPointIndex, PointF pointF, int scaleWidth, Class784 renderContext, Class783 axisRenderContext, float R)
	{
		Class757 nSeriesInternal = renderContext.Chart2007.NSeriesInternal;
		Class759 @class = nSeriesInternal.method_0(seriesIndex);
		Class748 class2 = @class.PointsInternal.method_0(chartPointIndex);
		Class750 dataLabelsInternal = class2.DataLabelsInternal;
		SizeF sizeF = Struct28.smethod_0(g, nSeriesInternal, seriesIndex, chartPointIndex, scaleWidth, renderContext, axisRenderContext);
		float num = 0f;
		float num2 = 0f;
		float num3 = 4f + R;
		if (class2.MarkerInternal.MarkerStyle != MarkerStyleType.None)
		{
			num3 += (float)(int)((float)class2.MarkerInternal.MarkerSize / 2f);
		}
		switch (dataLabelsInternal.LabelPosition)
		{
		case LegendDataLabelPosition.Top:
			num = pointF.X - sizeF.Width / 2f;
			num2 = pointF.Y - sizeF.Height - num3;
			num2 -= (float)Struct28.int_0;
			break;
		case LegendDataLabelPosition.Left:
			num = pointF.X - sizeF.Width - num3;
			num2 = pointF.Y - sizeF.Height / 2f;
			if (dataLabelsInternal.IsLegendKeyShown)
			{
				num -= (float)Struct28.int_0;
			}
			break;
		case LegendDataLabelPosition.Bottom:
			num = pointF.X - sizeF.Width / 2f;
			num2 = pointF.Y + num3;
			num2 += (float)Struct28.int_0;
			break;
		default:
			num = pointF.X + num3;
			num2 = pointF.Y - sizeF.Height / 2f;
			if (dataLabelsInternal.IsLegendKeyShown)
			{
				num += (float)Struct28.int_0;
			}
			break;
		case LegendDataLabelPosition.Center:
			num = pointF.X - sizeF.Width / 2f;
			num2 = pointF.Y - sizeF.Height / 2f;
			break;
		}
		dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_5(num), Struct41.smethod_5(num2), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
		dataLabelsInternal.ChartFrameInternal.method_6();
		Struct28.smethod_1(g, nSeriesInternal, seriesIndex, chartPointIndex, dataLabelsInternal.ChartFrameInternal.rectangle_0, renderContext, axisRenderContext);
	}

	internal static void smethod_21(Interface32 g, Class740 chart, ArrayList paramOfDataLabels, Class784 renderContext)
	{
		for (int i = 0; i < paramOfDataLabels.Count; i++)
		{
			object[] array = (object[])paramOfDataLabels[i];
			int seriesIndex = (int)array[0];
			int chartPointIndex = (int)array[1];
			PointF pointF = (PointF)array[2];
			Class783 @class = (Class783)array[3];
			float r = ((array.Length == 5) ? ((float)array[4]) : 0f);
			Class783 axisRenderContext = ((@class == renderContext.X1AxisRenderContext) ? renderContext.X1AxisRenderContext : renderContext.X2AxisRenderContext);
			int scaleWidth = (int)((float)chart.Width * Struct41.float_0);
			smethod_20(g, seriesIndex, chartPointIndex, pointF, scaleWidth, renderContext, axisRenderContext, r);
		}
	}

	private static List<object[]> smethod_22(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		ChartType[] chartType = new ChartType[3]
		{
			ChartType.Line,
			ChartType.LineWithMarkers,
			ChartType.HighLowClose
		};
		Enum141 axisGroup = aSeries.AxisGroup;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		float num = (float)aSeries.GapWidth / 100f;
		Class783 @class;
		Class783 class2;
		List<int> list;
		if (axisGroup == Enum141.const_0)
		{
			@class = renderContext.Y1AxisRenderContext;
			class2 = renderContext.X1AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			@class = renderContext.Y2AxisRenderContext;
			class2 = renderContext.X2AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		double logMaxValue = @class.LogMaxValue;
		double logMinValue = @class.LogMinValue;
		categoryAxisCrossAt = (@class.Axis.IsLogarithmic ? @class.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
		Class755 highLowLinesInternal = aSeries.HighLowLinesInternal;
		Class746 upBarsInternal = aSeries.UpBarsInternal;
		Class746 downBarsInternal = aSeries.DownBarsInternal;
		int count = list.Count;
		TimeUnitType baseUnitScale = class2.Axis.BaseUnitScale;
		int minValue = (int)class2.MinValue;
		int maxValue = (int)class2.MaxValue;
		int num2 = 0;
		if (!class2.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num2 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num2 == 0)
			{
				num2 = 1;
			}
		}
		else
		{
			num2 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		double num3 = (double)rect.Width / (double)num2;
		float num4 = 0f;
		List<object[]> list2 = new List<object[]>();
		ArrayList arrayList = new ArrayList();
		List<Class759> list3 = nSeriesInternal.method_10(axisGroup, chartType);
		for (int i = 0; i < list3.Count; i++)
		{
			Class759 class3 = list3[i];
			int index = class3.Index;
			ArrayList arrayList2 = new ArrayList();
			for (int j = 0; j < count; j++)
			{
				Class748 class4 = class3.PointsInternal.method_0(j);
				if (class4 != null && !class4.NotPlotted)
				{
					int val = int.Parse(list[j].ToString());
					val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
					int num5 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
					float num6 = (float)(num3 * (double)num5);
					num4 = (float)(num3 * (double)Struct21.smethod_35(baseUnitScale, Struct21.smethod_37(class2.Axis.BaseUnitScale, class2.MajorUnitScale, (int)class2.MajorUnit, val, chart.IsDate1904), val, chart.IsDate1904));
					if (class2.AxisBetweenCategories || renderContext.Chart.HasDataTable)
					{
						num6 += (float)(num3 / 2.0);
					}
					float num7 = 0f;
					num7 = ((!class2.Axis.IsPlotOrderReversed) ? ((float)rect.X + num6) : ((float)(rect.X + rect.Width) - num6));
					float num8 = categoryAxisY;
					float num9 = (float)class4.YValue;
					float num10 = (float)((double)num9 - categoryAxisCrossAt) / (float)(logMaxValue - logMinValue) * (float)rect.Height;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(num7, categoryAxisY);
					double num11 = 0.0;
					double num12 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num13 = 0.0;
							try
							{
								num13 = ((yErrorBarInternal.MinusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.MinusValue[j]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num11 = num13;
							try
							{
								num13 = ((yErrorBarInternal.PlusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.PlusValue[j]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num12 = num13;
							break;
						}
						case ErrorBarValueType.Fixed:
							num11 = yErrorBarInternal.Amount;
							num12 = num11;
							break;
						case ErrorBarValueType.Percentage:
							num11 = yErrorBarInternal.Amount * (double)num9 / 100.0;
							num12 = num11;
							break;
						}
						minusHeight = (float)num11 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
						plusHeight = (float)num12 / (float)(logMaxValue - logMinValue) * (float)rect.Height;
						if (!@class.Axis.IsPlotOrderReversed)
						{
							originPoint.Y -= num10;
						}
						else
						{
							originPoint.Y += num10;
						}
					}
					if (class3.Equals(aSeries))
					{
						yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					}
					num8 = (@class.Axis.IsPlotOrderReversed ? (num8 + num10) : (num8 - num10));
					PointF pointF = new PointF(num7, num8);
					if (arrayList2.Count == 0)
					{
						arrayList2.Add(pointF);
					}
					else
					{
						int k;
						for (k = 0; k < arrayList2.Count; k++)
						{
							if (arrayList2[k] != null)
							{
								PointF pointF2 = (PointF)arrayList2[k];
								if (!(pointF.X >= pointF2.X))
								{
									arrayList2.Insert(k, pointF);
									break;
								}
							}
						}
						if (k == arrayList2.Count)
						{
							arrayList2.Add(pointF);
						}
					}
					if (class3.Equals(aSeries))
					{
						if (hasDropLines)
						{
							dropLinesInternal.method_3(num7, num8, num7, categoryAxisY);
						}
						class4.MarkerInternal.method_4(num7, num8);
						list2.Add(new object[4] { index, j, pointF, class2 });
					}
				}
				else
				{
					arrayList2.Add(null);
				}
			}
			if (class3.Equals(aSeries) && arrayList2.Count > 1)
			{
				smethod_7(g, aSeries, arrayList2, rect);
			}
			arrayList.Add(arrayList2);
		}
		for (int l = 0; l < count; l++)
		{
			bool flag = false;
			bool flag2 = false;
			float num14 = 0f;
			float num15 = 0f;
			float num16 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num17 = 0f;
			float num18 = 0f;
			for (int m = 0; m < arrayList.Count; m++)
			{
				ArrayList arrayList3 = (ArrayList)arrayList[m];
				if (arrayList3.Count <= l || arrayList3[l] == null)
				{
					continue;
				}
				PointF pointF3 = (PointF)arrayList3[l];
				num16 = pointF3.X;
				if (!flag)
				{
					num14 = pointF3.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (num14 < pointF3.Y)
					{
						num15 = num14;
						num14 = pointF3.Y;
						flag2 = true;
					}
					else
					{
						num15 = pointF3.Y;
						flag2 = true;
					}
				}
				else
				{
					if (num14 < pointF3.Y)
					{
						num14 = pointF3.Y;
					}
					if (num15 > pointF3.Y)
					{
						num15 = pointF3.Y;
					}
				}
				if (m == 0)
				{
					num17 = pointF3.Y;
					flag3 = true;
				}
				else if (m == arrayList.Count - 1)
				{
					num18 = pointF3.Y;
					flag4 = true;
				}
			}
			if (aSeries.HasHighLowLines && flag && flag2)
			{
				highLowLinesInternal.method_3(num16, num14, num16, num15);
			}
			if (aSeries.HasUpDownBars && flag3 && flag4)
			{
				int num19 = (int)(num4 / (1f + num));
				RectangleF rect2 = default(RectangleF);
				if (num17 <= num18)
				{
					rect2.Width = num19;
					rect2.Height = num18 - num17;
					rect2.X = num16 - rect2.Width / 2f;
					rect2.Y = num17;
					smethod_1(g, downBarsInternal, rect2);
				}
				else
				{
					rect2.Width = num19;
					rect2.Height = num17 - num18;
					rect2.X = num16 - rect2.Width / 2f;
					rect2.Y = num18;
					smethod_1(g, upBarsInternal, rect2);
				}
			}
		}
		return list2;
	}

	internal static List<object[]> smethod_23(Interface32 g, Class759 aSeries, Rectangle rect, int maxPointsCount, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		ChartType chartType = ChartType.StackedColumn;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		_ = nSeriesInternal.Count;
		Enum141 axisGroup = aSeries.AxisGroup;
		int num;
		Class783 @class;
		Class783 class2;
		if (axisGroup == Enum141.const_0)
		{
			num = nSeriesInternal.method_7(Enum141.const_0, chartType);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
		}
		else
		{
			num = nSeriesInternal.method_7(Enum141.const_1, chartType);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
		}
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_24(g, aSeries, rect, renderContext);
		}
		float num2 = 0f;
		num2 = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		float num3 = (float)aSeries.Overlap / 100f;
		float num4 = (float)aSeries.GapWidth / 100f;
		List<object[]> list = new List<object[]>();
		int num5 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num5 = maxPointsCount - 1;
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = maxPointsCount;
		}
		double num6 = (double)rect.Width / (double)num5;
		float num7 = 0f;
		List<Class759> list2 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
		int num8 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
		if (num8 == -1)
		{
			return list;
		}
		int index = aSeries.Index;
		Class747 pointsInternal = aSeries.PointsInternal;
		ArrayList previous = new ArrayList();
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			Class748 class3 = pointsInternal.method_0(i);
			float num9 = (float)num6 / ((float)num - num3 * (float)(num - 1) + num4);
			float num10 = num9 * num3;
			float num11 = num9 * num4;
			num7 += (float)num8 * (num9 - num10);
			float num12 = (float)num6 * (float)i + num11 / 2f + num7;
			if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
			{
				num12 -= (float)(num6 / 2.0);
			}
			num12 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)rect.X + num12) : ((float)(rect.X + rect.Width) - num12 - num9));
			ArrayList arrayList = new ArrayList();
			if (class3 != null)
			{
				double yValue = class3.YValue;
				double num13 = yValue;
				if (yValue >= 0.0)
				{
					for (int j = 0; j < num8; j++)
					{
						Class748 class4 = list2[j].PointsInternal.method_0(i);
						if (class4 != null)
						{
							double yValue2 = class4.YValue;
							if (yValue2 > 0.0)
							{
								num13 += yValue2;
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < num8; k++)
					{
						Class748 class5 = list2[k].PointsInternal.method_0(i);
						if (class5 != null)
						{
							double yValue3 = class5.YValue;
							if (yValue3 <= 0.0)
							{
								num13 += yValue3;
							}
						}
					}
				}
				float num14 = (float)Math.Abs(yValue) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
				float num15 = (float)Math.Abs(num13) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
				bool flag = false;
				if (num14 == 0f)
				{
					flag = true;
				}
				Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
				PointF originPoint = new PointF(num12 + num9 / 2f, num2);
				double num16 = 0.0;
				double num17 = 0.0;
				float minusHeight = 0f;
				float plusHeight = 0f;
				if (yErrorBarInternal != null)
				{
					switch (yErrorBarInternal.Type)
					{
					case ErrorBarValueType.Custom:
					{
						double num18 = 0.0;
						try
						{
							num18 = ((yErrorBarInternal.MinusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.MinusValue[i]) : 0.0);
						}
						catch (Exception ex)
						{
							Class1165.smethod_28(ex);
						}
						num16 = num18;
						try
						{
							num18 = ((yErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.PlusValue[i]) : 0.0);
						}
						catch (Exception ex2)
						{
							Class1165.smethod_28(ex2);
						}
						num17 = num18;
						break;
					}
					case ErrorBarValueType.Fixed:
						num16 = yErrorBarInternal.Amount;
						num17 = num16;
						break;
					case ErrorBarValueType.Percentage:
						num16 = yErrorBarInternal.Amount * yValue / 100.0;
						num17 = num16;
						break;
					}
					minusHeight = (float)num16 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					plusHeight = (float)num17 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					if (!class2.Axis.IsPlotOrderReversed)
					{
						if (yValue <= 0.0)
						{
							originPoint.Y += num15;
						}
						else
						{
							originPoint.Y -= num15;
						}
					}
					else if (yValue <= 0.0)
					{
						originPoint.Y -= num15;
					}
					else
					{
						originPoint.Y += num15;
					}
				}
				yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
				num15 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num2 - num15) : (num2 + num15 - num14)) : ((!(yValue < 0.0)) ? (num2 + num15 - num14) : (num2 - num15)));
				if (class3.BorderInternal.IsVisible)
				{
					num14 -= 1f;
				}
				RectangleF rectangleF = new RectangleF(num12, num15, num9, num14 + 1f);
				if (rectangleF.Y < (float)rect.Y)
				{
					rectangleF.Height -= (float)rect.Y - rectangleF.Y;
					rectangleF.Y = rect.Y;
				}
				if (rectangleF.Bottom > (float)(rect.Bottom + 1))
				{
					rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
				}
				if (rectangleF.Right >= (float)rect.X && rectangleF.Left <= (float)rect.Right)
				{
					if (rectangleF.X < (float)rect.X)
					{
						rectangleF.Width -= (float)rect.X - rectangleF.X;
						rectangleF.X = rect.X;
					}
					else if (rectangleF.Right > (float)rect.Right)
					{
						rectangleF.Width -= rectangleF.Right - (float)rect.Right;
					}
					if (rectangleF.Width + 1f >= (num9 - 1f) / 3f)
					{
						if (!flag)
						{
							smethod_3(g, class3, rectangleF, num2, rect);
						}
						object[] array = new object[5];
						bool flag2 = rectangleF.Y + rectangleF.Height / 2f < num2 || (yValue == 0.0 && ((!class2.Axis.IsPlotOrderReversed) ? true : false));
						array[0] = index;
						array[1] = i;
						array[2] = rectangleF;
						array[3] = @class;
						array[4] = flag2;
						if (!class3.NotPlotted)
						{
							list.Add(array);
						}
						if (aSeries.HasSeriesLines)
						{
							arrayList.Add(rectangleF);
							arrayList.Add(flag2);
						}
					}
				}
			}
			smethod_28(g, aSeries, ref previous, arrayList);
		}
		return list;
	}

	private static List<object[]> smethod_24(Interface32 g, Class759 aSeries, Rectangle rect, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.StackedColumn;
		_ = chart.NSeriesInternal.Count;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		float num = (float)aSeries.Overlap / 100f;
		float num2 = (float)aSeries.GapWidth / 100f;
		int num3;
		Class783 @class;
		Class783 class2;
		List<int> list;
		if (axisGroup == Enum141.const_0)
		{
			num3 = nSeriesInternal.method_7(Enum141.const_0, chartType);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			num3 = nSeriesInternal.method_7(Enum141.const_1, chartType);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		float num4 = 0f;
		num4 = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		List<object[]> list2 = new List<object[]>();
		int count = list.Count;
		TimeUnitType baseUnitScale = @class.Axis.BaseUnitScale;
		int minValue = (int)@class.MinValue;
		int maxValue = (int)@class.MaxValue;
		int num5 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num5 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		double num6 = (double)rect.Width / (double)num5;
		ArrayList previous = new ArrayList();
		int num7 = 0;
		while (true)
		{
			if (num7 < count)
			{
				Class748 class3 = aSeries.PointsInternal.method_0(num7);
				float num8 = (float)(num6 / (double)((float)num3 - num * (float)(num3 - 1) + num2));
				float num9 = num8 * num;
				float num10 = num8 * num2;
				int val = int.Parse(list[num7].ToString());
				val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
				int num11 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
				float num12 = (float)(num6 * (double)num11);
				if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
				{
					num12 -= (float)(num6 / 2.0);
				}
				float num13 = 0f;
				num13 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)rect.X + num12 + num10 / 2f + 1f) : ((float)(rect.X + rect.Width) - num12 - num10 / 2f - num8 - 1f));
				List<Class759> list3 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
				int num14 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
				if (num14 == -1)
				{
					break;
				}
				int index = aSeries.Index;
				num13 = ((!@class.Axis.IsPlotOrderReversed) ? (num13 + (float)num14 * (num8 - num9)) : (num13 - (float)num14 * (num8 - num9)));
				ArrayList arrayList = new ArrayList();
				if (class3 != null)
				{
					double yValue = class3.YValue;
					double num15 = yValue;
					if (yValue >= 0.0)
					{
						for (int i = 0; i < num14; i++)
						{
							Class748 class4 = list3[i].PointsInternal.method_0(num7);
							if (class4 != null)
							{
								double yValue2 = class4.YValue;
								if (yValue2 > 0.0)
								{
									num15 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < num14; j++)
						{
							Class748 class5 = list3[j].PointsInternal.method_0(num7);
							if (class5 != null)
							{
								double yValue3 = class5.YValue;
								if (yValue3 <= 0.0)
								{
									num15 += yValue3;
								}
							}
						}
					}
					float num16 = (float)Math.Abs(yValue) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					float num17 = (float)Math.Abs(num15) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					bool flag = false;
					if (num16 == 0f)
					{
						flag = true;
					}
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(num13 + num8 / 2f, num4);
					double num18 = 0.0;
					double num19 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num20 = 0.0;
							try
							{
								num20 = ((yErrorBarInternal.MinusValue.Count > num7) ? Convert.ToDouble(yErrorBarInternal.MinusValue[num7]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num18 = num20;
							try
							{
								num20 = ((yErrorBarInternal.PlusValue.Count > num7) ? Convert.ToDouble(yErrorBarInternal.PlusValue[num7]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num19 = num20;
							break;
						}
						case ErrorBarValueType.Fixed:
							num18 = yErrorBarInternal.Amount;
							num19 = num18;
							break;
						case ErrorBarValueType.Percentage:
							num18 = yErrorBarInternal.Amount * yValue / 100.0;
							num19 = num18;
							break;
						}
						minusHeight = (float)num18 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						plusHeight = (float)num19 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							if (yValue <= 0.0)
							{
								originPoint.Y += num17;
							}
							else
							{
								originPoint.Y -= num17;
							}
						}
						else if (yValue <= 0.0)
						{
							originPoint.Y -= num17;
						}
						else
						{
							originPoint.Y += num17;
						}
					}
					yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					num17 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num4 - num17) : (num4 + num17 - num16)) : ((!(yValue < 0.0)) ? (num4 + num17 - num16) : (num4 - num17)));
					if (class3.BorderInternal.IsVisible)
					{
						num16 -= 1f;
					}
					RectangleF rectangleF = new RectangleF(num13, num17, num8, num16 + 1f);
					if (rectangleF.Y < (float)rect.Y)
					{
						rectangleF.Height -= (float)rect.Y - rectangleF.Y;
						rectangleF.Y = rect.Y;
					}
					if (rectangleF.Bottom > (float)(rect.Bottom + 1))
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
					}
					if (rectangleF.Right >= (float)rect.X && rectangleF.Left <= (float)rect.Right)
					{
						if (rectangleF.X < (float)rect.X)
						{
							rectangleF.Width -= (float)rect.X - rectangleF.X;
							rectangleF.X = rect.X;
						}
						else if (rectangleF.Right > (float)rect.Right)
						{
							rectangleF.Width -= rectangleF.Right - (float)rect.Right;
						}
						if (rectangleF.Width + 1f >= (num8 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_3(g, class3, rectangleF, num4, rect);
							}
							object[] array = new object[5];
							bool flag2 = rectangleF.Y + rectangleF.Height / 2f < num4 || (yValue == 0.0 && ((!class2.Axis.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num7;
							array[2] = rectangleF;
							array[3] = @class;
							array[4] = flag2;
							if (!class3.NotPlotted)
							{
								list2.Add(array);
							}
							if (aSeries.HasSeriesLines)
							{
								arrayList.Add(rectangleF);
								arrayList.Add(flag2);
							}
						}
					}
				}
				smethod_28(g, aSeries, ref previous, arrayList);
				num7++;
				continue;
			}
			return list2;
		}
		return list2;
	}

	internal static List<object[]> smethod_25(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, int maxPointsCount, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		ChartType[] chartType = new ChartType[2]
		{
			ChartType.StackedLine,
			ChartType.StackedLineWithMarkers
		};
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
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_26(g, aSeries, rect, categoryAxisY, renderContext);
		}
		float num = 0f;
		num = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		Class757 nSeriesInternal = chart.NSeriesInternal;
		float num2 = (float)aSeries.GapWidth / 100f;
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
		Class755 highLowLinesInternal = aSeries.HighLowLinesInternal;
		Class746 upBarsInternal = aSeries.UpBarsInternal;
		Class746 downBarsInternal = aSeries.DownBarsInternal;
		List<object[]> list = new List<object[]>();
		int num3 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num3 = maxPointsCount - 1;
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		else
		{
			num3 = maxPointsCount;
		}
		double num4 = (double)rect.Width / (double)num3;
		ArrayList arrayList = new ArrayList();
		List<Class759> list2 = nSeriesInternal.method_10(axisGroup, chartType);
		for (int i = 0; i < list2.Count; i++)
		{
			Class759 class3 = list2[i];
			int num5 = nSeriesInternal.method_12(class3, axisGroup, chartType);
			int index = class3.Index;
			ArrayList arrayList2 = new ArrayList();
			Class747 pointsInternal = class3.PointsInternal;
			for (int j = 0; j < maxPointsCount; j++)
			{
				Class748 class4 = pointsInternal.method_0(j);
				if (class4 != null && !class4.NotPlotted)
				{
					double num6 = (float)num4 * (float)j + 1f;
					if (@class.AxisBetweenCategories || renderContext.Chart.HasDataTable)
					{
						num6 += (double)(float)(num4 / 2.0);
					}
					num6 = ((!@class.Axis.IsPlotOrderReversed) ? ((double)rect.X + num6) : ((double)(rect.X + rect.Width) - num6));
					double yValue = class4.YValue;
					double num7 = yValue;
					if (yValue >= 0.0)
					{
						for (int k = 0; k < num5; k++)
						{
							Class748 class5 = list2[k].PointsInternal.method_0(j);
							if (class5 != null)
							{
								double yValue2 = class5.YValue;
								if (yValue2 > 0.0)
								{
									num7 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < num5; l++)
						{
							Class748 class6 = list2[l].PointsInternal.method_0(j);
							if (class6 != null)
							{
								double yValue3 = class6.YValue;
								if (yValue3 <= 0.0)
								{
									num7 += yValue3;
								}
							}
						}
					}
					float num8 = (float)Math.Abs(num7) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF((float)num6, num);
					double num9 = 0.0;
					double num10 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num11 = 0.0;
							try
							{
								num11 = ((yErrorBarInternal.MinusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.MinusValue[j]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num9 = num11;
							try
							{
								num11 = ((yErrorBarInternal.PlusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.PlusValue[j]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num10 = num11;
							break;
						}
						case ErrorBarValueType.Fixed:
							num9 = yErrorBarInternal.Amount;
							num10 = num9;
							break;
						case ErrorBarValueType.Percentage:
							num9 = yErrorBarInternal.Amount * yValue / 100.0;
							num10 = num9;
							break;
						}
						minusHeight = (float)num9 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						plusHeight = (float)num10 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							if (yValue < 0.0)
							{
								originPoint.Y += num8;
							}
							else
							{
								originPoint.Y -= num8;
							}
						}
						else if (yValue < 0.0)
						{
							originPoint.Y -= num8;
						}
						else
						{
							originPoint.Y += num8;
						}
					}
					if (class3.Equals(aSeries))
					{
						yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					}
					num8 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num - num8) : (num + num8)) : ((!(yValue < 0.0)) ? (num + num8) : (num - num8)));
					PointF pointF = new PointF((float)num6, num8);
					arrayList2.Add(pointF);
					if (class3.Equals(aSeries))
					{
						if (hasDropLines)
						{
							dropLinesInternal.method_3((float)num6, num8, (float)num6, categoryAxisY);
						}
						class4.MarkerInternal.method_4((float)num6, num8);
						list.Add(new object[4] { index, j, pointF, @class });
					}
				}
				else
				{
					arrayList2.Add(null);
				}
			}
			if (class3.Equals(aSeries) && arrayList2.Count > 1)
			{
				smethod_7(g, aSeries, arrayList2, rect);
			}
			arrayList.Add(arrayList2);
		}
		for (int m = 0; m < maxPointsCount; m++)
		{
			bool flag = false;
			bool flag2 = false;
			float num12 = 0f;
			float num13 = 0f;
			float num14 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num15 = 0f;
			float num16 = 0f;
			for (int n = 0; n < arrayList.Count; n++)
			{
				ArrayList arrayList3 = (ArrayList)arrayList[n];
				if (arrayList3.Count <= m || arrayList3[m] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList3[m];
				num14 = pointF2.X;
				if (!flag)
				{
					num12 = pointF2.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (num12 < pointF2.Y)
					{
						num13 = num12;
						num12 = pointF2.Y;
						flag2 = true;
					}
					else
					{
						num13 = pointF2.Y;
						flag2 = true;
					}
				}
				else
				{
					if (num12 < pointF2.Y)
					{
						num12 = pointF2.Y;
					}
					if (num13 > pointF2.Y)
					{
						num13 = pointF2.Y;
					}
				}
				if (n == 0)
				{
					num15 = pointF2.Y;
					flag3 = true;
				}
				else if (n == arrayList.Count - 1)
				{
					num16 = pointF2.Y;
					flag4 = true;
				}
			}
			if (aSeries.HasHighLowLines && flag && flag2)
			{
				highLowLinesInternal.method_3(num14, num12, num14, num13);
			}
			if (aSeries.HasUpDownBars && flag3 && flag4)
			{
				int num17 = (int)(num4 / (double)(1f + num2));
				RectangleF rect2 = default(RectangleF);
				if (num15 <= num16)
				{
					rect2.Width = num17;
					rect2.Height = num16 - num15;
					rect2.X = num14 - rect2.Width / 2f;
					rect2.Y = num15;
					smethod_1(g, downBarsInternal, rect2);
				}
				else
				{
					rect2.Width = num17;
					rect2.Height = num15 - num16;
					rect2.X = num14 - rect2.Width / 2f;
					rect2.Y = num16;
					smethod_1(g, upBarsInternal, rect2);
				}
			}
		}
		return list;
	}

	private static List<object[]> smethod_26(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		ChartType[] chartType = new ChartType[2]
		{
			ChartType.StackedLine,
			ChartType.StackedLineWithMarkers
		};
		Enum141 axisGroup = aSeries.AxisGroup;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		float num = (float)aSeries.GapWidth / 100f;
		Class783 @class;
		Class783 class2;
		List<int> list;
		if (axisGroup == Enum141.const_0)
		{
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		float num2 = 0f;
		num2 = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
		Class755 highLowLinesInternal = aSeries.HighLowLinesInternal;
		Class746 upBarsInternal = aSeries.UpBarsInternal;
		Class746 downBarsInternal = aSeries.DownBarsInternal;
		int count = list.Count;
		TimeUnitType baseUnitScale = @class.Axis.BaseUnitScale;
		int minValue = (int)@class.MinValue;
		int maxValue = (int)@class.MaxValue;
		int num3 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num3 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		else
		{
			num3 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		double num4 = (double)rect.Width / (double)num3;
		float num5 = 0f;
		List<object[]> list2 = new List<object[]>();
		ArrayList arrayList = new ArrayList();
		List<Class759> list3 = nSeriesInternal.method_10(axisGroup, chartType);
		for (int i = 0; i < list3.Count; i++)
		{
			Class759 class3 = list3[i];
			int num6 = nSeriesInternal.method_12(class3, axisGroup, chartType);
			int index = class3.Index;
			ArrayList arrayList2 = new ArrayList();
			for (int j = 0; j < count; j++)
			{
				Class748 class4 = class3.PointsInternal.method_0(j);
				if (class4 != null && !class4.NotPlotted)
				{
					int val = int.Parse(list[j].ToString());
					val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
					int num7 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
					float num8 = (float)(num4 * (double)num7);
					num5 = (float)(num4 * (double)Struct21.smethod_35(baseUnitScale, Struct21.smethod_37(@class.Axis.BaseUnitScale, @class.MajorUnitScale, (int)@class.MajorUnit, val, chart.IsDate1904), val, chart.IsDate1904));
					if (@class.AxisBetweenCategories || renderContext.Chart.HasDataTable)
					{
						num8 += (float)(num4 / 2.0);
					}
					float num9 = 0f;
					num9 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)rect.X + num8) : ((float)(rect.X + rect.Width) - num8));
					double yValue = class4.YValue;
					double num10 = yValue;
					if (yValue >= 0.0)
					{
						for (int k = 0; k < num6; k++)
						{
							Class748 class5 = list3[k].PointsInternal.method_0(j);
							if (class5 != null)
							{
								double yValue2 = class5.YValue;
								if (yValue2 > 0.0)
								{
									num10 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < num6; l++)
						{
							Class748 class6 = list3[l].PointsInternal.method_0(j);
							if (class6 != null)
							{
								double yValue3 = class6.YValue;
								if (yValue3 <= 0.0)
								{
									num10 += yValue3;
								}
							}
						}
					}
					float num11 = (float)Math.Abs(num10) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(num9, num2);
					double num12 = 0.0;
					double num13 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num14 = 0.0;
							try
							{
								num14 = ((yErrorBarInternal.MinusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.MinusValue[j]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num12 = num14;
							try
							{
								num14 = ((yErrorBarInternal.PlusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.PlusValue[j]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num13 = num14;
							break;
						}
						case ErrorBarValueType.Fixed:
							num12 = yErrorBarInternal.Amount;
							num13 = num12;
							break;
						case ErrorBarValueType.Percentage:
							num12 = yErrorBarInternal.Amount * yValue / 100.0;
							num13 = num12;
							break;
						}
						minusHeight = (float)num12 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						plusHeight = (float)num13 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							if (yValue < 0.0)
							{
								originPoint.Y += num11;
							}
							else
							{
								originPoint.Y -= num11;
							}
						}
						else if (yValue < 0.0)
						{
							originPoint.Y -= num11;
						}
						else
						{
							originPoint.Y += num11;
						}
					}
					if (class3.Equals(aSeries))
					{
						yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					}
					num11 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num2 - num11) : (num2 + num11)) : ((!(yValue < 0.0)) ? (num2 + num11) : (num2 - num11)));
					PointF pointF = new PointF(num9, num11);
					if (arrayList2.Count == 0)
					{
						arrayList2.Add(pointF);
					}
					else
					{
						int m;
						for (m = 0; m < arrayList2.Count; m++)
						{
							if (arrayList2[m] != null)
							{
								PointF pointF2 = (PointF)arrayList2[m];
								if (!(pointF.X >= pointF2.X))
								{
									arrayList2.Insert(m, pointF);
									break;
								}
							}
						}
						if (m == arrayList2.Count)
						{
							arrayList2.Add(pointF);
						}
					}
					if (class3.Equals(aSeries))
					{
						if (hasDropLines)
						{
							dropLinesInternal.method_3(num9, num11, num9, categoryAxisY);
						}
						class4.MarkerInternal.method_4(num9, num11);
						list2.Add(new object[4] { index, j, pointF, @class });
					}
				}
				else
				{
					arrayList2.Add(null);
				}
			}
			if (class3.Equals(aSeries))
			{
				smethod_7(g, class3, arrayList2, rect);
			}
			arrayList.Add(arrayList2);
		}
		for (int n = 0; n < count; n++)
		{
			bool flag = false;
			bool flag2 = false;
			float num15 = 0f;
			float num16 = 0f;
			float num17 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num18 = 0f;
			float num19 = 0f;
			for (int num20 = 0; num20 < arrayList.Count; num20++)
			{
				ArrayList arrayList3 = (ArrayList)arrayList[num20];
				if (arrayList3.Count <= n || arrayList3[n] == null)
				{
					continue;
				}
				PointF pointF3 = (PointF)arrayList3[n];
				num17 = pointF3.X;
				if (!flag)
				{
					num15 = pointF3.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (num15 < pointF3.Y)
					{
						num16 = num15;
						num15 = pointF3.Y;
						flag2 = true;
					}
					else
					{
						num16 = pointF3.Y;
						flag2 = true;
					}
				}
				else
				{
					if (num15 < pointF3.Y)
					{
						num15 = pointF3.Y;
					}
					if (num16 > pointF3.Y)
					{
						num16 = pointF3.Y;
					}
				}
				if (num20 == 0)
				{
					num18 = pointF3.Y;
					flag3 = true;
				}
				else if (num20 == arrayList.Count - 1)
				{
					num19 = pointF3.Y;
					flag4 = true;
				}
			}
			if (aSeries.HasHighLowLines && flag && flag2)
			{
				highLowLinesInternal.method_3(num17, num15, num17, num16);
			}
			if (aSeries.HasUpDownBars && flag3 && flag4)
			{
				int num21 = (int)(num5 / (1f + num));
				RectangleF rect2 = default(RectangleF);
				if (num18 <= num19)
				{
					rect2.Width = num21;
					rect2.Height = num19 - num18;
					rect2.X = num17 - rect2.Width / 2f;
					rect2.Y = num18;
					smethod_1(g, downBarsInternal, rect2);
				}
				else
				{
					rect2.Width = num21;
					rect2.Height = num18 - num19;
					rect2.X = num17 - rect2.Width / 2f;
					rect2.Y = num19;
					smethod_1(g, upBarsInternal, rect2);
				}
			}
		}
		return list2;
	}

	internal static List<object[]> smethod_27(Interface32 g, Class759 aSeries, Rectangle rect, int maxPointsCount, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.PercentsStackedColumn;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		int num;
		Class783 @class;
		Class783 class2;
		if (axisGroup == Enum141.const_0)
		{
			num = nSeriesInternal.method_7(Enum141.const_0, chartType);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
		}
		else
		{
			num = nSeriesInternal.method_7(Enum141.const_1, chartType);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
		}
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_29(g, aSeries, rect, renderContext);
		}
		float num2 = 0f;
		num2 = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		float num3 = (float)aSeries.Overlap / 100f;
		float num4 = (float)aSeries.GapWidth / 100f;
		List<object[]> list = new List<object[]>();
		int num5 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num5 = maxPointsCount - 1;
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = maxPointsCount;
		}
		double num6 = (double)rect.Width / (double)num5;
		float num7 = 0f;
		List<Class759> list2 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
		int num8 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
		if (num8 == -1)
		{
			return list;
		}
		int index = aSeries.Index;
		Class747 pointsInternal = aSeries.PointsInternal;
		ArrayList previous = new ArrayList();
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			Class748 class3 = pointsInternal.method_0(i);
			float num9 = (float)num6 / ((float)num - num3 * (float)(num - 1) + num4);
			float num10 = num9 * num3;
			float num11 = num9 * num4;
			num7 = (float)num8 * (num9 - num10);
			float num12 = (float)num6 * (float)i + num11 / 2f + num7;
			if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
			{
				num12 -= (float)(num6 / 2.0);
			}
			num12 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)rect.X + num12) : ((float)(rect.X + rect.Width) - num12 - num9));
			ArrayList arrayList = new ArrayList();
			if (class3 != null)
			{
				double yValue = class3.YValue;
				double num13 = yValue;
				double num14 = 0.0;
				if (yValue >= 0.0)
				{
					for (int j = 0; j < num8; j++)
					{
						Class748 class4 = list2[j].PointsInternal.method_0(i);
						if (class4 != null)
						{
							double yValue2 = class4.YValue;
							if (yValue2 > 0.0)
							{
								num13 += yValue2;
							}
						}
					}
				}
				else
				{
					for (int k = 0; k < num8; k++)
					{
						Class748 class5 = list2[k].PointsInternal.method_0(i);
						if (class5 != null)
						{
							double yValue3 = class5.YValue;
							if (yValue3 <= 0.0)
							{
								num13 += yValue3;
							}
						}
					}
				}
				for (int l = 0; l < list2.Count; l++)
				{
					Class748 class6 = list2[l].PointsInternal.method_0(i);
					if (class6 != null)
					{
						double yValue4 = class6.YValue;
						num14 += Math.Abs(yValue4);
					}
				}
				if (num14 == 0.0 || num14 == 0.0)
				{
					continue;
				}
				float num15 = (float)Math.Abs(yValue) * 100f / (float)num14 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
				float num16 = (float)Math.Abs(num13) * 100f / (float)num14 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
				bool flag = num15 == 0f;
				Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
				PointF originPoint = new PointF(num12 + num9 / 2f, num2);
				double num17 = 0.0;
				double num18 = 0.0;
				float minusHeight = 0f;
				float plusHeight = 0f;
				if (yErrorBarInternal != null)
				{
					switch (yErrorBarInternal.Type)
					{
					case ErrorBarValueType.Custom:
					{
						double num19 = 0.0;
						try
						{
							num19 = ((yErrorBarInternal.MinusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.MinusValue[i]) : 0.0);
						}
						catch (Exception ex)
						{
							Class1165.smethod_28(ex);
						}
						num17 = num19;
						try
						{
							num19 = ((yErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.PlusValue[i]) : 0.0);
						}
						catch (Exception ex2)
						{
							Class1165.smethod_28(ex2);
						}
						num18 = num19;
						break;
					}
					case ErrorBarValueType.Fixed:
						num17 = yErrorBarInternal.Amount;
						num18 = num17;
						break;
					case ErrorBarValueType.Percentage:
						num17 = yErrorBarInternal.Amount * yValue / 100.0;
						num18 = num17;
						break;
					}
					num18 = num18 * 100.0 / num14;
					num17 = num17 * 100.0 / num14;
					minusHeight = (float)num17 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					plusHeight = (float)num18 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					if (!class2.Axis.IsPlotOrderReversed)
					{
						if (yValue <= 0.0)
						{
							originPoint.Y += num16;
						}
						else
						{
							originPoint.Y -= num16;
						}
					}
					else if (yValue <= 0.0)
					{
						originPoint.Y -= num16;
					}
					else
					{
						originPoint.Y += num16;
					}
				}
				yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
				num16 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num2 - num16) : (num2 + num16 - num15)) : ((!(yValue < 0.0)) ? (num2 + num16 - num15) : (num2 - num16)));
				if (class3.BorderInternal.IsVisible)
				{
					num15 -= 1f;
				}
				RectangleF rectangleF = new RectangleF(num12, num16, num9, num15 + 1f);
				if (rectangleF.Y < (float)rect.Y)
				{
					rectangleF.Height -= (float)rect.Y - rectangleF.Y;
					rectangleF.Y = rect.Y;
				}
				if (rectangleF.Bottom > (float)(rect.Bottom + 1))
				{
					rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
				}
				if (rectangleF.Right >= (float)rect.X && rectangleF.Left <= (float)rect.Right)
				{
					if (rectangleF.X < (float)rect.X)
					{
						rectangleF.Width -= (float)rect.X - rectangleF.X;
						rectangleF.X = rect.X;
					}
					else if (rectangleF.Right > (float)rect.Right)
					{
						rectangleF.Width -= rectangleF.Right - (float)rect.Right;
					}
					if (rectangleF.Width + 1f >= (num9 - 1f) / 3f)
					{
						if (!flag)
						{
							smethod_3(g, class3, rectangleF, num2, rect);
						}
						object[] array = new object[5];
						bool flag2 = rectangleF.Y + rectangleF.Height / 2f < num2 || (yValue == 0.0 && ((!class2.Axis.IsPlotOrderReversed) ? true : false));
						array[0] = index;
						array[1] = i;
						array[2] = rectangleF;
						array[3] = @class;
						array[4] = flag2;
						if (!class3.NotPlotted)
						{
							list.Add(array);
						}
						if (aSeries.HasSeriesLines)
						{
							arrayList.Add(rectangleF);
							arrayList.Add(flag2);
						}
					}
				}
			}
			smethod_28(g, aSeries, ref previous, arrayList);
		}
		return list;
	}

	private static void smethod_28(Interface32 g, Class759 aSeries, ref ArrayList previous, ArrayList current)
	{
		if (previous.Count > 0 && current.Count > 0 && aSeries.HasSeriesLines)
		{
			RectangleF rectangleF = (RectangleF)previous[0];
			bool flag = (bool)previous[1];
			RectangleF rectangleF2 = (RectangleF)current[0];
			bool flag2 = (bool)current[1];
			PointF point;
			PointF point2;
			if (!(rectangleF.X < rectangleF2.X))
			{
				point = ((!flag) ? new PointF(rectangleF.Left, rectangleF.Bottom) : new PointF(rectangleF.Left, rectangleF.Top));
				point2 = ((!flag2) ? new PointF(rectangleF2.Right, rectangleF2.Bottom) : new PointF(rectangleF2.Right, rectangleF2.Top));
			}
			else
			{
				point = ((!flag) ? new PointF(rectangleF.Right, rectangleF.Bottom) : new PointF(rectangleF.Right, rectangleF.Top));
				point2 = ((!flag2) ? new PointF(rectangleF2.Left, rectangleF2.Bottom) : new PointF(rectangleF2.Left, rectangleF2.Top));
			}
			aSeries.SeriesLinesInternal.method_5(point, point2);
		}
		if (current.Count > 0)
		{
			previous = current;
		}
	}

	private static List<object[]> smethod_29(Interface32 g, Class759 aSeries, Rectangle rect, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.PercentsStackedColumn;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		float num = (float)aSeries.Overlap / 100f;
		float num2 = (float)aSeries.GapWidth / 100f;
		int num3;
		Class783 @class;
		Class783 class2;
		List<int> list;
		if (axisGroup == Enum141.const_0)
		{
			num3 = nSeriesInternal.method_7(Enum141.const_0, chartType);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			num3 = nSeriesInternal.method_7(Enum141.const_1, chartType);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		float num4 = 0f;
		num4 = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		List<object[]> list2 = new List<object[]>();
		int count = list.Count;
		TimeUnitType baseUnitScale = @class.Axis.BaseUnitScale;
		int minValue = (int)@class.MinValue;
		int maxValue = (int)@class.MaxValue;
		int num5 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num5 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num5 == 0)
			{
				num5 = 1;
			}
		}
		else
		{
			num5 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		double num6 = (double)rect.Width / (double)num5;
		ArrayList previous = new ArrayList();
		int num7 = 0;
		while (true)
		{
			if (num7 < count)
			{
				Class748 class3 = aSeries.PointsInternal.method_0(num7);
				float num8 = (float)(num6 / (double)((float)num3 - num * (float)(num3 - 1) + num2));
				float num9 = num8 * num;
				float num10 = num8 * num2;
				int val = int.Parse(list[num7].ToString());
				val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
				int num11 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
				float num12 = (float)(num6 * (double)num11);
				if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
				{
					num12 -= (float)(num6 / 2.0);
				}
				float num13 = 0f;
				num13 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)rect.X + num12 + num10 / 2f + 1f) : ((float)(rect.X + rect.Width) - num12 - num10 / 2f - num8 - 1f));
				List<Class759> list3 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
				int num14 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
				if (num14 == -1)
				{
					break;
				}
				int index = aSeries.Index;
				num13 = ((!@class.Axis.IsPlotOrderReversed) ? (num13 + (float)num14 * (num8 - num9)) : (num13 - (float)num14 * (num8 - num9)));
				ArrayList arrayList = new ArrayList();
				if (class3 != null)
				{
					double yValue = class3.YValue;
					double num15 = yValue;
					double num16 = 0.0;
					if (yValue >= 0.0)
					{
						for (int i = 0; i < num14; i++)
						{
							Class748 class4 = list3[i].PointsInternal.method_0(num7);
							if (class4 != null)
							{
								double yValue2 = class4.YValue;
								if (yValue2 > 0.0)
								{
									num15 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < num14; j++)
						{
							Class748 class5 = list3[j].PointsInternal.method_0(num7);
							if (class5 != null)
							{
								double yValue3 = class5.YValue;
								if (yValue3 <= 0.0)
								{
									num15 += yValue3;
								}
							}
						}
					}
					for (int k = 0; k < list3.Count; k++)
					{
						Class748 class6 = list3[k].PointsInternal.method_0(num7);
						if (class6 != null)
						{
							double yValue4 = class6.YValue;
							num16 += Math.Abs(yValue4);
						}
					}
					if (num16 == 0.0 || num16 == 0.0)
					{
						goto IL_091f;
					}
					float num17 = (float)Math.Abs(yValue) * 100f / (float)num16 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					float num18 = (float)Math.Abs(num15) * 100f / (float)num16 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					bool flag = num17 == 0f;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(num13 + num8 / 2f, num4);
					double num19 = 0.0;
					double num20 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num21 = 0.0;
							try
							{
								num21 = ((yErrorBarInternal.MinusValue.Count > num7) ? Convert.ToDouble(yErrorBarInternal.MinusValue[num7]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num19 = num21;
							try
							{
								num21 = ((yErrorBarInternal.PlusValue.Count > num7) ? Convert.ToDouble(yErrorBarInternal.PlusValue[num7]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num20 = num21;
							break;
						}
						case ErrorBarValueType.Fixed:
							num19 = yErrorBarInternal.Amount;
							num20 = num19;
							break;
						case ErrorBarValueType.Percentage:
							num19 = yErrorBarInternal.Amount * yValue / 100.0;
							num20 = num19;
							break;
						}
						num20 = num20 * 100.0 / num16;
						num19 = num19 * 100.0 / num16;
						minusHeight = (float)num19 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						plusHeight = (float)num20 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							if (yValue <= 0.0)
							{
								originPoint.Y += num18;
							}
							else
							{
								originPoint.Y -= num18;
							}
						}
						else if (yValue <= 0.0)
						{
							originPoint.Y -= num18;
						}
						else
						{
							originPoint.Y += num18;
						}
					}
					yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					num18 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num4 - num18) : (num4 + num18 - num17)) : ((!(yValue < 0.0)) ? (num4 + num18 - num17) : (num4 - num18)));
					if (class3.BorderInternal.IsVisible)
					{
						num17 -= 1f;
					}
					RectangleF rectangleF = new RectangleF(num13, num18, num8, num17 + 1f);
					if (rectangleF.Y < (float)rect.Y)
					{
						rectangleF.Height -= (float)rect.Y - rectangleF.Y;
						rectangleF.Y = rect.Y;
					}
					if (rectangleF.Bottom > (float)(rect.Bottom + 1))
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
					}
					if (rectangleF.Right >= (float)rect.X && rectangleF.Left <= (float)rect.Right)
					{
						if (rectangleF.X < (float)rect.X)
						{
							rectangleF.Width -= (float)rect.X - rectangleF.X;
							rectangleF.X = rect.X;
						}
						else if (rectangleF.Right > (float)rect.Right)
						{
							rectangleF.Width -= rectangleF.Right - (float)rect.Right;
						}
						if (rectangleF.Width + 1f >= (num8 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_3(g, class3, rectangleF, num4, rect);
							}
							object[] array = new object[5];
							bool flag2 = rectangleF.Y + rectangleF.Height / 2f < num4 || (yValue == 0.0 && ((!class2.Axis.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num7;
							array[2] = rectangleF;
							array[3] = @class;
							array[4] = flag2;
							if (!class3.NotPlotted)
							{
								list2.Add(array);
							}
							if (aSeries.HasSeriesLines)
							{
								arrayList.Add(rectangleF);
								arrayList.Add(flag2);
							}
						}
					}
				}
				smethod_28(g, aSeries, ref previous, arrayList);
				goto IL_091f;
			}
			return list2;
			IL_091f:
			num7++;
		}
		return list2;
	}

	internal static List<object[]> smethod_30(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, int maxPointsCount, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		ChartType[] chartType = new ChartType[2]
		{
			ChartType.PercentsStackedLine,
			ChartType.PercentsStackedLineWithMarkers
		};
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
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_31(g, aSeries, rect, categoryAxisY, renderContext);
		}
		float num = 0f;
		num = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		Class757 nSeriesInternal = chart.NSeriesInternal;
		float num2 = (float)aSeries.GapWidth / 100f;
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
		Class755 highLowLinesInternal = aSeries.HighLowLinesInternal;
		Class746 upBarsInternal = aSeries.UpBarsInternal;
		Class746 downBarsInternal = aSeries.DownBarsInternal;
		List<object[]> list = new List<object[]>();
		int num3 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num3 = maxPointsCount - 1;
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		else
		{
			num3 = maxPointsCount;
		}
		double num4 = (double)rect.Width / (double)num3;
		ArrayList arrayList = new ArrayList();
		List<Class759> list2 = nSeriesInternal.method_10(axisGroup, chartType);
		for (int i = 0; i < list2.Count; i++)
		{
			Class759 class3 = list2[i];
			int num5 = nSeriesInternal.method_12(class3, axisGroup, chartType);
			int index = class3.Index;
			ArrayList arrayList2 = new ArrayList();
			Class747 pointsInternal = class3.PointsInternal;
			for (int j = 0; j < maxPointsCount; j++)
			{
				Class748 class4 = pointsInternal.method_0(j);
				if (class4 != null && !class4.NotPlotted)
				{
					double num6 = (float)num4 * (float)j + 1f;
					if (@class.AxisBetweenCategories || renderContext.Chart.HasDataTable)
					{
						num6 += (double)(float)(num4 / 2.0);
					}
					num6 = ((!@class.Axis.IsPlotOrderReversed) ? ((double)rect.X + num6) : ((double)(rect.X + rect.Width) - num6));
					double yValue = class4.YValue;
					double num7 = yValue;
					double num8 = 0.0;
					if (yValue >= 0.0)
					{
						for (int k = 0; k < num5; k++)
						{
							Class748 class5 = list2[k].PointsInternal.method_0(j);
							if (class5 != null)
							{
								double yValue2 = class5.YValue;
								if (yValue2 > 0.0)
								{
									num7 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < num5; l++)
						{
							Class748 class6 = list2[l].PointsInternal.method_0(j);
							if (class6 != null)
							{
								double yValue3 = class6.YValue;
								if (yValue3 <= 0.0)
								{
									num7 += yValue3;
								}
							}
						}
					}
					for (int m = 0; m < list2.Count; m++)
					{
						Class748 class7 = list2[m].PointsInternal.method_0(j);
						if (class7 != null)
						{
							double yValue4 = class7.YValue;
							num8 += Math.Abs(yValue4);
						}
					}
					if (num8 == 0.0)
					{
						continue;
					}
					float num9 = (float)Math.Abs(num7) * 100f / (float)num8 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF((float)num6, num);
					double num10 = 0.0;
					double num11 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num12 = 0.0;
							try
							{
								num12 = ((yErrorBarInternal.MinusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.MinusValue[j]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num10 = num12;
							try
							{
								num12 = ((yErrorBarInternal.PlusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.PlusValue[j]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num11 = num12;
							break;
						}
						case ErrorBarValueType.Fixed:
							num10 = yErrorBarInternal.Amount;
							num11 = num10;
							break;
						case ErrorBarValueType.Percentage:
							num10 = yErrorBarInternal.Amount * yValue / 100.0;
							num11 = num10;
							break;
						}
						num11 = num11 * 100.0 / num8;
						num10 = num10 * 100.0 / num8;
						minusHeight = (float)num10 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						plusHeight = (float)num11 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							if (yValue < 0.0)
							{
								originPoint.Y += num9;
							}
							else
							{
								originPoint.Y -= num9;
							}
						}
						else if (yValue < 0.0)
						{
							originPoint.Y -= num9;
						}
						else
						{
							originPoint.Y += num9;
						}
					}
					if (class3.Equals(aSeries))
					{
						yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					}
					num9 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num - num9) : (num + num9)) : ((!(yValue < 0.0)) ? (num + num9) : (num - num9)));
					PointF pointF = new PointF((float)num6, num9);
					arrayList2.Add(pointF);
					if (class3.Equals(aSeries))
					{
						if (hasDropLines)
						{
							dropLinesInternal.method_3((float)num6, num9, (float)num6, categoryAxisY);
						}
						class4.MarkerInternal.method_4((float)num6, num9);
						list.Add(new object[4] { index, j, pointF, @class });
					}
				}
				else
				{
					arrayList2.Add(null);
				}
			}
			if (class3.Equals(aSeries))
			{
				smethod_7(g, class3, arrayList2, rect);
			}
			arrayList.Add(arrayList2);
		}
		for (int n = 0; n < maxPointsCount; n++)
		{
			bool flag = false;
			bool flag2 = false;
			float num13 = 0f;
			float num14 = 0f;
			float num15 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num16 = 0f;
			float num17 = 0f;
			for (int num18 = 0; num18 < arrayList.Count; num18++)
			{
				ArrayList arrayList3 = (ArrayList)arrayList[num18];
				if (arrayList3.Count <= n || arrayList3[n] == null)
				{
					continue;
				}
				PointF pointF2 = (PointF)arrayList3[n];
				num15 = pointF2.X;
				if (!flag)
				{
					num13 = pointF2.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (num13 < pointF2.Y)
					{
						num14 = num13;
						num13 = pointF2.Y;
						flag2 = true;
					}
					else
					{
						num14 = pointF2.Y;
						flag2 = true;
					}
				}
				else
				{
					if (num13 < pointF2.Y)
					{
						num13 = pointF2.Y;
					}
					if (num14 > pointF2.Y)
					{
						num14 = pointF2.Y;
					}
				}
				if (num18 == 0)
				{
					num16 = pointF2.Y;
					flag3 = true;
				}
				else if (num18 == arrayList.Count - 1)
				{
					num17 = pointF2.Y;
					flag4 = true;
				}
			}
			if (aSeries.HasHighLowLines && flag && flag2)
			{
				highLowLinesInternal.method_3(num15, num13, num15, num14);
			}
			if (aSeries.HasUpDownBars && flag3 && flag4)
			{
				int num19 = (int)(num4 / (double)(1f + num2));
				RectangleF rect2 = default(RectangleF);
				if (num16 <= num17)
				{
					rect2.Width = num19;
					rect2.Height = num17 - num16;
					rect2.X = num15 - rect2.Width / 2f;
					rect2.Y = num16;
					smethod_1(g, downBarsInternal, rect2);
				}
				else
				{
					rect2.Width = num19;
					rect2.Height = num16 - num17;
					rect2.X = num15 - rect2.Width / 2f;
					rect2.Y = num17;
					smethod_1(g, upBarsInternal, rect2);
				}
			}
		}
		return list;
	}

	private static List<object[]> smethod_31(Interface32 g, Class759 aSeries, Rectangle rect, float categoryAxisY, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		ChartType[] chartType = new ChartType[2]
		{
			ChartType.PercentsStackedLine,
			ChartType.PercentsStackedLineWithMarkers
		};
		Enum141 axisGroup = aSeries.AxisGroup;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		_ = nSeriesInternal.Count;
		_ = (float)aSeries.Overlap / 100f;
		float num = (float)aSeries.GapWidth / 100f;
		Class783 @class;
		Class783 class2;
		List<int> list;
		if (axisGroup == Enum141.const_0)
		{
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		float num2 = 0f;
		num2 = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
		Class755 highLowLinesInternal = aSeries.HighLowLinesInternal;
		Class746 upBarsInternal = aSeries.UpBarsInternal;
		Class746 downBarsInternal = aSeries.DownBarsInternal;
		int count = list.Count;
		TimeUnitType baseUnitScale = @class.Axis.BaseUnitScale;
		int minValue = (int)@class.MinValue;
		int maxValue = (int)@class.MaxValue;
		int num3 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num3 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		else
		{
			num3 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		double num4 = (double)rect.Width / (double)num3;
		float num5 = 0f;
		List<object[]> list2 = new List<object[]>();
		ArrayList arrayList = new ArrayList();
		List<Class759> list3 = nSeriesInternal.method_10(axisGroup, chartType);
		for (int i = 0; i < list3.Count; i++)
		{
			Class759 class3 = list3[i];
			int num6 = nSeriesInternal.method_12(class3, axisGroup, chartType);
			int index = class3.Index;
			ArrayList arrayList2 = new ArrayList();
			for (int j = 0; j < count; j++)
			{
				Class748 class4 = class3.PointsInternal.method_0(j);
				if (class4 != null && !class4.NotPlotted)
				{
					int val = int.Parse(list[j].ToString());
					val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
					int num7 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
					float num8 = (float)(num4 * (double)num7);
					num5 = (float)(num4 * (double)Struct21.smethod_35(baseUnitScale, Struct21.smethod_37(@class.Axis.BaseUnitScale, @class.MajorUnitScale, (int)@class.MajorUnit, val, chart.IsDate1904), val, chart.IsDate1904));
					if (@class.AxisBetweenCategories || renderContext.Chart.HasDataTable)
					{
						num8 += (float)(num4 / 2.0);
					}
					float num9 = 0f;
					num9 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)rect.X + num8) : ((float)(rect.X + rect.Width) - num8));
					double yValue = class4.YValue;
					double num10 = yValue;
					double num11 = 0.0;
					if (yValue >= 0.0)
					{
						for (int k = 0; k < num6; k++)
						{
							Class748 class5 = list3[k].PointsInternal.method_0(j);
							if (class5 != null)
							{
								double yValue2 = class5.YValue;
								if (yValue2 > 0.0)
								{
									num10 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int l = 0; l < num6; l++)
						{
							Class748 class6 = list3[l].PointsInternal.method_0(j);
							if (class6 != null)
							{
								double yValue3 = class6.YValue;
								if (yValue3 <= 0.0)
								{
									num10 += yValue3;
								}
							}
						}
					}
					for (int m = 0; m < list3.Count; m++)
					{
						Class748 class7 = list3[m].PointsInternal.method_0(j);
						if (class7 != null)
						{
							double yValue4 = class7.YValue;
							num11 += Math.Abs(yValue4);
						}
					}
					if (num11 == 0.0)
					{
						continue;
					}
					float num12 = (float)Math.Abs(num10) * 100f / (float)num11 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(num9, num2);
					double num13 = 0.0;
					double num14 = 0.0;
					float minusHeight = 0f;
					float plusHeight = 0f;
					if (yErrorBarInternal != null)
					{
						switch (yErrorBarInternal.Type)
						{
						case ErrorBarValueType.Custom:
						{
							double num15 = 0.0;
							try
							{
								num15 = ((yErrorBarInternal.MinusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.MinusValue[j]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num13 = num15;
							try
							{
								num15 = ((yErrorBarInternal.PlusValue.Count > j) ? Convert.ToDouble(yErrorBarInternal.PlusValue[j]) : 0.0);
							}
							catch (Exception ex2)
							{
								Class1165.smethod_28(ex2);
							}
							num14 = num15;
							break;
						}
						case ErrorBarValueType.Fixed:
							num13 = yErrorBarInternal.Amount;
							num14 = num13;
							break;
						case ErrorBarValueType.Percentage:
							num13 = yErrorBarInternal.Amount * yValue / 100.0;
							num14 = num13;
							break;
						}
						num14 = num14 * 100.0 / num11;
						num13 = num13 * 100.0 / num11;
						minusHeight = (float)num13 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						plusHeight = (float)num14 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							if (yValue < 0.0)
							{
								originPoint.Y += num12;
							}
							else
							{
								originPoint.Y -= num12;
							}
						}
						else if (yValue < 0.0)
						{
							originPoint.Y -= num12;
						}
						else
						{
							originPoint.Y += num12;
						}
					}
					if (class3.Equals(aSeries))
					{
						yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					}
					num12 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue < 0.0)) ? (num2 - num12) : (num2 + num12)) : ((!(yValue < 0.0)) ? (num2 + num12) : (num2 - num12)));
					PointF pointF = new PointF(num9, num12);
					if (arrayList2.Count == 0)
					{
						arrayList2.Add(pointF);
					}
					else
					{
						int n;
						for (n = 0; n < arrayList2.Count; n++)
						{
							if (arrayList2[n] != null)
							{
								PointF pointF2 = (PointF)arrayList2[n];
								if (!(pointF.X >= pointF2.X))
								{
									arrayList2.Insert(n, pointF);
									break;
								}
							}
						}
						if (n == arrayList2.Count)
						{
							arrayList2.Add(pointF);
						}
					}
					if (class3.Equals(aSeries))
					{
						if (hasDropLines)
						{
							dropLinesInternal.method_3(num9, num12, num9, categoryAxisY);
						}
						class4.MarkerInternal.method_4(num9, num12);
						list2.Add(new object[4] { index, j, pointF, @class });
					}
				}
				else
				{
					arrayList2.Add(null);
				}
			}
			if (class3.Equals(aSeries))
			{
				smethod_7(g, class3, arrayList2, rect);
			}
			arrayList.Add(arrayList2);
		}
		for (int num16 = 0; num16 < count; num16++)
		{
			bool flag = false;
			bool flag2 = false;
			float num17 = 0f;
			float num18 = 0f;
			float num19 = 0f;
			bool flag3 = false;
			bool flag4 = false;
			float num20 = 0f;
			float num21 = 0f;
			for (int num22 = 0; num22 < arrayList.Count; num22++)
			{
				ArrayList arrayList3 = (ArrayList)arrayList[num22];
				if (arrayList3.Count <= num16 || arrayList3[num16] == null)
				{
					continue;
				}
				PointF pointF3 = (PointF)arrayList3[num16];
				num19 = pointF3.X;
				if (!flag)
				{
					num17 = pointF3.Y;
					flag = true;
				}
				else if (!flag2)
				{
					if (num17 < pointF3.Y)
					{
						num18 = num17;
						num17 = pointF3.Y;
						flag2 = true;
					}
					else
					{
						num18 = pointF3.Y;
						flag2 = true;
					}
				}
				else
				{
					if (num17 < pointF3.Y)
					{
						num17 = pointF3.Y;
					}
					if (num18 > pointF3.Y)
					{
						num18 = pointF3.Y;
					}
				}
				if (num22 == 0)
				{
					num20 = pointF3.Y;
					flag3 = true;
				}
				else if (num22 == arrayList.Count - 1)
				{
					num21 = pointF3.Y;
					flag4 = true;
				}
			}
			if (aSeries.HasHighLowLines && flag && flag2)
			{
				highLowLinesInternal.method_3(num19, num17, num19, num18);
			}
			if (aSeries.HasUpDownBars && flag3 && flag4)
			{
				int num23 = (int)(num5 / (1f + num));
				RectangleF rect2 = default(RectangleF);
				if (num20 <= num21)
				{
					rect2.Width = num23;
					rect2.Height = num21 - num20;
					rect2.X = num19 - rect2.Width / 2f;
					rect2.Y = num20;
					smethod_1(g, downBarsInternal, rect2);
				}
				else
				{
					rect2.Width = num23;
					rect2.Height = num20 - num21;
					rect2.X = num19 - rect2.Width / 2f;
					rect2.Y = num21;
					smethod_1(g, upBarsInternal, rect2);
				}
			}
		}
		return list2;
	}

	internal static void smethod_32(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		int count = nSeriesInternal.Count;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_33(g, chart, categoryAxisY, categoryAxisCrossAt, renderContext);
			return;
		}
		List<object[]> list = new List<object[]>();
		float num = chart.WallsInternal.Width / (float)maxPointsCount;
		float num2 = chart.WallsInternal.method_0(isBar: false, maxPointsCount, count);
		float wallsDepth = chart.WallsInternal.method_1();
		float num3 = num2 * (float)chart.GapWidth / 100f;
		for (int i = 0; i < maxPointsCount; i++)
		{
			int num4 = i;
			if (chart.Rotation > 180)
			{
				num4 = maxPointsCount - 1 - i;
			}
			IList list2 = nSeriesInternal.method_9();
			double preParaTop = 1.0;
			for (int j = 0; j < list2.Count; j++)
			{
				int num5 = j;
				if (chart.Rotation > 180)
				{
					num5 = list2.Count - 1 - j;
				}
				Class759 @class = (Class759)list2[num5];
				int index = @class.Index;
				float num6 = (float)num5 * num2;
				float num7 = num * (float)num4 + num3 / 2f + num6;
				num7 = chart.WallsInternal.X + num7;
				Class747 pointsInternal = @class.PointsInternal;
				int num8 = num4;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num8 = maxPointsCount - 1 - num4;
				}
				Class748 class2 = pointsInternal.method_0(num8);
				if (class2 != null && !class2.NotPlotted)
				{
					double b = y1AxisRenderContext.method_2(class2.YValue);
					float num9 = (float)Struct41.smethod_11(categoryAxisCrossAt, b) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num9 = 0f - num9;
					}
					smethod_46(g, class2, chart, num7, num2, wallsDepth, categoryAxisY, num9, double.NaN, ref preParaTop, renderContext);
					bool flag = Struct41.smethod_11(num9, 0.0) <= 0.0;
					PointF pointF = smethod_43(chart, num7, num2, categoryAxisY, num9, flag);
					list.Add(new object[4] { index, num8, pointF, flag });
				}
			}
		}
		smethod_45(g, chart, list, renderContext);
	}

	private static void smethod_33(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		int count = nSeriesInternal.Count;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		List<object[]> list = new List<object[]>();
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int minValue = (int)x1AxisRenderContext.MinValue;
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int num = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		float num2 = chart.WallsInternal.Width / (float)num;
		float num3 = chart.WallsInternal.method_0(isBar: false, num, count);
		float wallsDepth = chart.WallsInternal.method_1();
		float num4 = num3 * (float)chart.GapWidth / 100f;
		List<int> list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count2 = list2.Count;
		for (int i = 0; i < count2; i++)
		{
			int num5 = i;
			if (chart.Rotation > 180)
			{
				num5 = count2 - 1 - i;
			}
			int val = int.Parse(list2[num5].ToString());
			val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
			int num6 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
			float num7 = num2 * (float)num6;
			num7 += chart.WallsInternal.X + num4 / 2f;
			IList list3 = nSeriesInternal.method_9();
			double preParaTop = 1.0;
			for (int j = 0; j < list3.Count; j++)
			{
				int num8 = j;
				if (chart.Rotation > 180)
				{
					num8 = list3.Count - 1 - j;
				}
				Class759 @class = (Class759)list3[num8];
				int index = @class.Index;
				float num9 = (float)num8 * num3;
				float shapeX = num7 + num9;
				Class747 pointsInternal = @class.PointsInternal;
				int num10 = num5;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num10 = count2 - 1 - num5;
				}
				Class748 class2 = pointsInternal.method_0(num10);
				if (class2 != null && !class2.NotPlotted)
				{
					double b = y1AxisRenderContext.method_2(class2.YValue);
					float num11 = (float)Struct41.smethod_11(categoryAxisCrossAt, b) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num11 = 0f - num11;
					}
					smethod_46(g, class2, chart, shapeX, num3, wallsDepth, categoryAxisY, num11, double.NaN, ref preParaTop, renderContext);
					bool flag = true;
					flag = Struct41.smethod_11(num11, 0.0) < 0.0;
					PointF pointF = smethod_43(chart, shapeX, num3, categoryAxisY, num11, flag);
					list.Add(new object[4] { index, num10, pointF, flag });
				}
			}
		}
		smethod_45(g, chart, list, renderContext);
	}

	internal static void smethod_34(Interface32 g, Class740 chart, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		List<Class759> list = nSeriesInternal.method_9();
		int num = Struct24.smethod_27(list);
		double num2 = 0.0;
		switch (num)
		{
		case 1:
			num2 = y1AxisRenderContext.MinValue;
			break;
		case 2:
			num2 = y1AxisRenderContext.MaxValue;
			break;
		}
		float num3 = 0f;
		num3 = ((!y1AxisRenderContext.Axis.IsPlotOrderReversed) ? (chart.WallsInternal.Y - (float)Math.Abs((y1AxisRenderContext.MinValue - num2) / (double)(float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue)) * chart.WallsInternal.Height) : (chart.WallsInternal.Y - (float)Math.Abs((y1AxisRenderContext.MaxValue - num2) / (double)(float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue)) * chart.WallsInternal.Height));
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_35(g, chart, num3, categoryAxisCrossAt, renderContext);
			return;
		}
		List<object[]> list2 = new List<object[]>();
		float num4 = chart.WallsInternal.Width / (float)maxPointsCount;
		float num5 = chart.WallsInternal.method_0(isBar: false, maxPointsCount, 1);
		float num6 = chart.WallsInternal.method_1();
		float num7 = num5 * (float)chart.GapWidth / 100f;
		for (int i = 0; i < maxPointsCount; i++)
		{
			int num8 = i;
			if (chart.Rotation > 180)
			{
				num8 = maxPointsCount - 1 - i;
			}
			float num9 = chart.WallsInternal.X + num4 * (float)num8 + num7 / 2f;
			List<object[]> list3 = new List<object[]>();
			for (int j = 0; j < list.Count; j++)
			{
				Class759 @class = list[j];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				int num10 = num8;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num10 = maxPointsCount - 1 - num8;
				}
				Class748 class2 = pointsInternal.method_0(num10);
				int displayOrder = j;
				if (class2 == null || class2.NotPlotted)
				{
					continue;
				}
				double pointVal = class2.YValue;
				if (Struct41.smethod_16(ref pointVal, out var valTotal, list, displayOrder, num10, y1AxisRenderContext.MaxValue, y1AxisRenderContext.MinValue))
				{
					if (num == 1 && j == 0)
					{
						pointVal -= num2;
					}
					else if (num == 2 && j == 0)
					{
						pointVal -= num2;
					}
					float num11 = (float)pointVal / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					float num12 = (float)(valTotal - num2) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					float num13;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num13 = num3 + (num12 - num11);
					}
					else
					{
						num13 = num3 - (num12 - num11);
						num11 = 0f - num11;
					}
					smethod_42(aParamOfColumns: new object[5] { class2, num9, num13, num11, valTotal }, val: pointVal, paramOfColumns: list3, axisRenderContext: y1AxisRenderContext);
					PointF pointF = smethod_44(chart, num9, num5, num6, num13, num11);
					list2.Add(new object[3] { index, num10, pointF });
				}
			}
			double preParaTop = 1.0;
			for (int k = 0; k < list3.Count; k++)
			{
				object[] array = list3[k];
				Class748 chartPoint = (Class748)array[0];
				smethod_46(g, chartPoint, chart, (float)array[1], num5, num6, (float)array[2], (float)array[3], (double)array[4], ref preParaTop, renderContext);
			}
			list3.Clear();
			smethod_45(g, chart, list2, renderContext);
			list2.Clear();
		}
	}

	private static void smethod_35(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		List<object[]> list = new List<object[]>();
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int minValue = (int)x1AxisRenderContext.MinValue;
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int num = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		float num2 = chart.WallsInternal.Width / (float)num;
		float num3 = chart.WallsInternal.method_0(isBar: false, num, 1);
		float num4 = chart.WallsInternal.method_1();
		float num5 = num3 * (float)chart.GapWidth / 100f;
		List<int> list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			int num6 = i;
			if (chart.Rotation > 180)
			{
				num6 = count - 1 - i;
			}
			int val = int.Parse(list2[num6].ToString());
			val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
			int num7 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
			float num8 = num2 * (float)num7;
			float num9 = chart.WallsInternal.X + num5 / 2f + num8;
			List<object[]> list3 = new List<object[]>();
			IList list4 = nSeriesInternal.method_9();
			for (int j = 0; j < list4.Count; j++)
			{
				Class759 @class = (Class759)list4[j];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				int num10 = num6;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num10 = count - 1 - num6;
				}
				Class748 class2 = pointsInternal.method_0(num10);
				int displayOrder = j;
				if (class2 == null || class2.NotPlotted)
				{
					continue;
				}
				double pointVal = class2.YValue;
				if (Struct41.smethod_16(ref pointVal, out var valTotal, list4, displayOrder, num10, y1AxisRenderContext.MaxValue, y1AxisRenderContext.MinValue))
				{
					float num11 = (float)pointVal / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					float num12 = (float)valTotal / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					float num13;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num13 = categoryAxisY + (num12 - num11);
					}
					else
					{
						num13 = categoryAxisY - (num12 - num11);
						num11 = 0f - num11;
					}
					smethod_42(aParamOfColumns: new object[5] { class2, num9, num13, num11, valTotal }, val: pointVal, paramOfColumns: list3, axisRenderContext: y1AxisRenderContext);
					PointF pointF = smethod_44(chart, num9, num3, num4, num13, num11);
					list.Add(new object[3] { index, num10, pointF });
				}
			}
			double preParaTop = 1.0;
			for (int k = 0; k < list3.Count; k++)
			{
				object[] array = list3[k];
				Class748 chartPoint = (Class748)array[0];
				smethod_46(g, chartPoint, chart, (float)array[1], num3, num4, (float)array[2], (float)array[3], (double)array[4], ref preParaTop, renderContext);
			}
			list3.Clear();
			smethod_45(g, chart, list, renderContext);
			list.Clear();
		}
	}

	internal static void smethod_36(Interface32 g, Class740 chart, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		float num = 0f;
		num = ((!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed) ? (chart.WallsInternal.Y - (float)Math.Abs(y1AxisRenderContext.MinValue / (double)(float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue)) * chart.WallsInternal.Height) : (chart.WallsInternal.Y - (float)Math.Abs(y1AxisRenderContext.MaxValue / (double)(float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue)) * chart.WallsInternal.Height));
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_37(g, chart, num, categoryAxisCrossAt, renderContext);
			return;
		}
		List<object[]> list = new List<object[]>();
		float num2 = chart.WallsInternal.Width / (float)maxPointsCount;
		float num3 = chart.WallsInternal.method_0(isBar: false, maxPointsCount, 1);
		float num4 = chart.WallsInternal.method_1();
		float num5 = num3 * (float)chart.GapWidth / 100f;
		for (int i = 0; i < maxPointsCount; i++)
		{
			int num6 = i;
			if (chart.Rotation > 180)
			{
				num6 = maxPointsCount - 1 - i;
			}
			float num7 = chart.WallsInternal.X + num2 * (float)num6 + num5 / 2f;
			List<object[]> list2 = new List<object[]>();
			IList list3 = nSeriesInternal.method_9();
			for (int j = 0; j < list3.Count; j++)
			{
				Class759 @class = (Class759)list3[j];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				int num8 = num6;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num8 = maxPointsCount - 1 - num6;
				}
				Class748 class2 = pointsInternal.method_0(num8);
				int displayOrder = j;
				if (class2 == null || class2.NotPlotted)
				{
					continue;
				}
				double num9 = Struct41.smethod_17(list3, num8);
				if (num9 == 0.0)
				{
					continue;
				}
				double pointVal = class2.YValue;
				double valTotal = pointVal;
				if (Struct41.smethod_18(ref pointVal, out valTotal, list3, displayOrder, num8, num9, y1AxisRenderContext))
				{
					float num10 = (float)pointVal * 100f / (float)num9 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					float num11 = (float)valTotal * 100f / (float)num9 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					float num12;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num12 = num + (num11 - num10);
					}
					else
					{
						num12 = num - (num11 - num10);
						num10 = 0f - num10;
					}
					smethod_42(aParamOfColumns: new object[5] { class2, num7, num12, num10, valTotal }, val: pointVal, paramOfColumns: list2, axisRenderContext: y1AxisRenderContext);
					PointF pointF = smethod_44(chart, num7, num3, num4, num12, num10);
					list.Add(new object[3] { index, num8, pointF });
				}
			}
			double preParaTop = 1.0;
			for (int k = 0; k < list2.Count; k++)
			{
				object[] array = list2[k];
				Class748 chartPoint = (Class748)array[0];
				smethod_46(g, chartPoint, chart, (float)array[1], num3, num4, (float)array[2], (float)array[3], (double)array[4], ref preParaTop, renderContext);
			}
			list2.Clear();
			smethod_45(g, chart, list, renderContext);
			list.Clear();
		}
	}

	private static void smethod_37(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		List<object[]> list = new List<object[]>();
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int minValue = (int)x1AxisRenderContext.MinValue;
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int num = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		float num2 = chart.WallsInternal.Width / (float)num;
		float num3 = chart.WallsInternal.method_0(isBar: false, num, 1);
		float num4 = chart.WallsInternal.method_1();
		float num5 = num3 * (float)chart.GapWidth / 100f;
		List<int> list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			int num6 = i;
			if (chart.Rotation > 180)
			{
				num6 = count - 1 - i;
			}
			int val = int.Parse(list2[num6].ToString());
			val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
			int num7 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
			float num8 = num2 * (float)num7;
			float num9 = chart.WallsInternal.X + num5 / 2f + num8;
			List<object[]> list3 = new List<object[]>();
			IList list4 = nSeriesInternal.method_9();
			for (int j = 0; j < list4.Count; j++)
			{
				Class759 @class = (Class759)list4[j];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				int num10 = num6;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num10 = count - 1 - num6;
				}
				Class748 class2 = pointsInternal.method_0(num10);
				int displayOrder = j;
				if (class2 == null || class2.NotPlotted)
				{
					continue;
				}
				double num11 = Struct41.smethod_17(list4, num10);
				if (num11 == 0.0)
				{
					continue;
				}
				double pointVal = class2.YValue;
				double valTotal = pointVal;
				if (Struct41.smethod_18(ref pointVal, out valTotal, list4, displayOrder, num10, num11, y1AxisRenderContext))
				{
					float num12 = (float)pointVal * 100f / (float)num11 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					float num13 = (float)valTotal * 100f / (float)num11 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					float num14;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num14 = categoryAxisY + (num13 - num12);
					}
					else
					{
						num14 = categoryAxisY - (num13 - num12);
						num12 = 0f - num12;
					}
					smethod_42(aParamOfColumns: new object[5] { class2, num9, num14, num12, valTotal }, val: pointVal, paramOfColumns: list3, axisRenderContext: y1AxisRenderContext);
					PointF pointF = smethod_44(chart, num9, num3, num4, num14, num12);
					list.Add(new object[3] { index, num10, pointF });
				}
			}
			double preParaTop = 1.0;
			for (int k = 0; k < list3.Count; k++)
			{
				object[] array = list3[k];
				Class748 chartPoint = (Class748)array[0];
				smethod_46(g, chartPoint, chart, (float)array[1], num3, num4, (float)array[2], (float)array[3], (double)array[4], ref preParaTop, renderContext);
			}
			list3.Clear();
			smethod_45(g, chart, list, renderContext);
			list.Clear();
		}
	}

	internal static void smethod_38(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_39(g, chart, categoryAxisY, categoryAxisCrossAt, renderContext);
			return;
		}
		float num = (float)chart.DepthPercent / 100f;
		float num2 = (float)chart.GapDepth / 100f;
		float num3 = (float)chart.GapWidth / 100f;
		List<object[]> list = new List<object[]>();
		float num4 = chart.WallsInternal.Width / (float)maxPointsCount;
		float num5 = num4 / (1f + num3);
		float num6 = num5 * num3;
		float shapeDepth = num4 * num / (1f + num2);
		IList list2 = nSeriesInternal.method_9();
		if ((chart.Rotation >= 0 && chart.Rotation < 90) || (chart.Rotation >= 180 && chart.Rotation < 270))
		{
			for (int i = 0; i < list2.Count; i++)
			{
				int num7 = list2.Count - 1 - i;
				if (chart.Rotation >= 180 && chart.Rotation < 270)
				{
					num7 = list2.Count - 1 - num7;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num7 = list2.Count - 1 - num7;
				}
				Class759 @class = (Class759)list2[num7];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				for (int j = 0; j < maxPointsCount; j++)
				{
					int num8 = j;
					if (chart.Rotation >= 180 && chart.Rotation < 270)
					{
						num8 = maxPointsCount - 1 - num8;
					}
					float num9 = num4 * (float)num8 + num6 / 2f;
					num9 = chart.WallsInternal.X + num9;
					int num10 = num8;
					if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num10 = maxPointsCount - 1 - num8;
					}
					Class748 class2 = pointsInternal.method_0(num10);
					if (class2 != null && !class2.NotPlotted)
					{
						double b = y1AxisRenderContext.method_2(class2.YValue);
						float num11 = (float)Struct41.smethod_11(categoryAxisCrossAt, b) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
						if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
						{
							num11 = 0f - num11;
						}
						smethod_49(g, class2, chart, categoryAxisY, num11, num9, num5, shapeDepth, index + 1, list2.Count, renderContext);
						bool flag = true;
						flag = Struct41.smethod_11(num11, 0.0) < 0.0;
						PointF pointF = smethod_56(chart, categoryAxisY, num11, num9, num5, shapeDepth, index + 1, list2.Count, flag, renderContext);
						list.Clear();
						list.Add(new object[4] { index, num10, pointF, flag });
						smethod_45(g, chart, list, renderContext);
					}
				}
			}
		}
		else
		{
			if ((chart.Rotation < 90 || chart.Rotation >= 180) && (chart.Rotation < 270 || chart.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < maxPointsCount; k++)
			{
				int num12 = k;
				if (chart.Rotation >= 270 && chart.Rotation < 360)
				{
					num12 = maxPointsCount - 1 - num12;
				}
				for (int l = 0; l < list2.Count; l++)
				{
					int num13 = l;
					if (chart.Rotation >= 270 && chart.Rotation < 360)
					{
						num13 = list2.Count - 1 - num13;
					}
					if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num13 = list2.Count - 1 - num13;
					}
					Class759 class3 = (Class759)list2[num13];
					int index2 = class3.Index;
					float num14 = num4 * (float)num12 + num6 / 2f;
					num14 = chart.WallsInternal.X + num14;
					Class747 pointsInternal2 = class3.PointsInternal;
					int num15 = num12;
					if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num15 = maxPointsCount - 1 - num12;
					}
					Class748 class4 = pointsInternal2.method_0(num15);
					if (class4 != null && !class4.NotPlotted)
					{
						double b2 = y1AxisRenderContext.method_2(class4.YValue);
						float num16 = (float)Struct41.smethod_11(categoryAxisCrossAt, b2) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
						if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
						{
							num16 = 0f - num16;
						}
						smethod_49(g, class4, chart, categoryAxisY, num16, num14, num5, shapeDepth, index2 + 1, list2.Count, renderContext);
						bool flag2 = Struct41.smethod_11(num16, 0.0) < 0.0;
						PointF pointF2 = smethod_56(chart, categoryAxisY, num16, num14, num5, shapeDepth, index2 + 1, list2.Count, flag2, renderContext);
						list.Clear();
						list.Add(new object[4] { index2, num15, pointF2, flag2 });
						smethod_45(g, chart, list, renderContext);
					}
				}
			}
		}
	}

	private static void smethod_39(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		Class783 seriesAxisRenderContext = renderContext.SeriesAxisRenderContext;
		float num = (float)chart.DepthPercent / 100f;
		float num2 = (float)chart.GapDepth / 100f;
		float num3 = (float)chart.GapWidth / 100f;
		List<object[]> list = new List<object[]>();
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int minValue = (int)x1AxisRenderContext.MinValue;
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int num4 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		float num5 = chart.WallsInternal.Width / (float)num4;
		float num6 = num5 / (1f + num3);
		float num7 = num6 * num3;
		float shapeDepth = num5 * num / (1f + num2);
		IList list2 = nSeriesInternal.method_9();
		List<int> list3 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count = list3.Count;
		if ((chart.Rotation >= 0 && chart.Rotation < 90) || (chart.Rotation >= 180 && chart.Rotation < 270))
		{
			for (int i = 0; i < list2.Count; i++)
			{
				int num8 = list2.Count - 1 - i;
				if (chart.Rotation >= 180 && chart.Rotation < 270)
				{
					num8 = list2.Count - 1 - num8;
				}
				if (seriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num8 = list2.Count - 1 - num8;
				}
				Class759 @class = (Class759)list2[num8];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				for (int j = 0; j < count; j++)
				{
					int num9 = j;
					if (chart.Rotation >= 180 && chart.Rotation < 270)
					{
						num9 = count - 1 - num9;
					}
					int val = int.Parse(list3[num9].ToString());
					val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
					int num10 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
					float num11 = num5 * (float)num10;
					float shapeX = chart.WallsInternal.X + num11 + num7 / 2f;
					int num12 = num9;
					if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num12 = count - 1 - num9;
					}
					Class748 class2 = pointsInternal.method_0(num12);
					if (class2 != null && !class2.NotPlotted)
					{
						double b = y1AxisRenderContext.method_2(class2.YValue);
						float num13 = (float)Struct41.smethod_11(categoryAxisCrossAt, b) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
						if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
						{
							num13 = 0f - num13;
						}
						smethod_49(g, class2, chart, categoryAxisY, num13, shapeX, num6, shapeDepth, index + 1, list2.Count, renderContext);
						bool flag = Struct41.smethod_11(num13, 0.0) < 0.0;
						PointF pointF = smethod_56(chart, categoryAxisY, num13, shapeX, num6, shapeDepth, index + 1, list2.Count, flag, renderContext);
						list.Clear();
						list.Add(new object[4] { index, num12, pointF, flag });
						smethod_45(g, chart, list, renderContext);
					}
				}
			}
		}
		else
		{
			if ((chart.Rotation < 90 || chart.Rotation >= 180) && (chart.Rotation < 270 || chart.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < count; k++)
			{
				int num14 = k;
				if (chart.Rotation >= 270 && chart.Rotation < 360)
				{
					num14 = count - 1 - num14;
				}
				int val2 = int.Parse(list3[num14].ToString());
				val2 = Struct21.smethod_38(baseUnitScale, val2, chart.IsDate1904);
				int num15 = Struct21.smethod_35(baseUnitScale, val2, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
				float num16 = num5 * (float)num15;
				float shapeX2 = chart.WallsInternal.X + num16 + num7 / 2f;
				for (int l = 0; l < list2.Count; l++)
				{
					int num17 = l;
					if (chart.Rotation >= 270 && chart.Rotation < 360)
					{
						num17 = list2.Count - 1 - num17;
					}
					if (seriesAxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num17 = list2.Count - 1 - num17;
					}
					Class759 class3 = (Class759)list2[num17];
					int index2 = class3.Index;
					Class747 pointsInternal2 = class3.PointsInternal;
					int num18 = num14;
					if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num18 = count - 1 - num14;
					}
					Class748 class4 = pointsInternal2.method_0(num18);
					if (class4 != null && !class4.NotPlotted)
					{
						double b2 = y1AxisRenderContext.method_2(class4.YValue);
						float num19 = (float)Struct41.smethod_11(categoryAxisCrossAt, b2) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
						if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
						{
							num19 = 0f - num19;
						}
						smethod_49(g, class4, chart, categoryAxisY, num19, shapeX2, num6, shapeDepth, index2 + 1, list2.Count, renderContext);
						bool flag2 = Struct41.smethod_11(num19, 0.0) < 0.0;
						PointF pointF2 = smethod_56(chart, categoryAxisY, num19, shapeX2, num6, shapeDepth, index2 + 1, list2.Count, flag2, renderContext);
						list.Clear();
						list.Add(new object[4] { index2, num18, pointF2, flag2 });
						smethod_45(g, chart, list, renderContext);
					}
				}
			}
		}
	}

	internal static void smethod_40(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_41(g, chart, categoryAxisY, categoryAxisCrossAt, renderContext);
			return;
		}
		float num = (float)chart.DepthPercent / 100f;
		float num2 = (float)chart.GapDepth / 100f;
		List<object[]> list = new List<object[]>();
		double logMaxValue = y1AxisRenderContext.LogMaxValue;
		double logMinValue = y1AxisRenderContext.LogMinValue;
		categoryAxisCrossAt = (y1AxisRenderContext.Axis.IsLogarithmic ? y1AxisRenderContext.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		int num3 = 0;
		bool flag;
		if (flag = x1AxisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
		{
			num3 = maxPointsCount;
		}
		else
		{
			num3 = maxPointsCount - 1;
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		float num4 = chart.WallsInternal.Width / (float)num3;
		float shapeDepth = num4 * num / (1f + num2);
		ArrayList arrayList = new ArrayList();
		IList list2 = nSeriesInternal.method_9();
		if ((chart.Rotation >= 0 && chart.Rotation < 90) || (chart.Rotation >= 180 && chart.Rotation < 270))
		{
			for (int i = 0; i < list2.Count; i++)
			{
				int num5 = list2.Count - 1 - i;
				if (chart.Rotation >= 180 && chart.Rotation < 270)
				{
					num5 = list2.Count - 1 - num5;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num5 = list2.Count - 1 - num5;
				}
				Class759 @class = (Class759)list2[num5];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				for (int j = 0; j < maxPointsCount; j++)
				{
					int num6 = j;
					if (chart.Rotation >= 180 && chart.Rotation < 270)
					{
						num6 = maxPointsCount - 1 - num6;
					}
					float num7 = num4 * (float)num6;
					num7 = chart.WallsInternal.X + num7;
					if (flag)
					{
						num7 += num4 / 2f;
					}
					int num8 = num6;
					if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num8 = maxPointsCount - 1 - num6;
					}
					Class748 class2 = pointsInternal.method_0(num8);
					if (class2 != null && !class2.NotPlotted)
					{
						double num9 = y1AxisRenderContext.method_2(class2.YValue);
						float num10 = (float)(categoryAxisCrossAt - num9) / (float)(logMaxValue - logMinValue) * chart.WallsInternal.Height;
						if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
						{
							num10 = 0f - num10;
						}
						object[] array = new object[2]
						{
							class2,
							smethod_48(g, chart, categoryAxisY, num10, num7, shapeDepth, index + 1, list2.Count, renderContext)
						};
						arrayList.Add(array);
						int num11 = 0;
						if (chart.Rotation >= 90 && chart.Rotation < 270)
						{
							num11 = 1;
						}
						list.Add(new object[3]
						{
							index,
							num8,
							((PointF[])array[1])[num11]
						});
					}
					else
					{
						arrayList.Add(null);
					}
				}
				smethod_54(g, chart, arrayList);
				arrayList.Clear();
				smethod_45(g, chart, list, renderContext);
				list.Clear();
			}
		}
		else
		{
			if ((chart.Rotation < 90 || chart.Rotation >= 180) && (chart.Rotation < 270 || chart.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < list2.Count; k++)
			{
				int num12 = k;
				if (chart.Rotation >= 270 && chart.Rotation < 360)
				{
					num12 = list2.Count - 1 - num12;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num12 = list2.Count - 1 - num12;
				}
				Class759 class3 = (Class759)list2[num12];
				int index2 = class3.Index;
				Class747 pointsInternal2 = class3.PointsInternal;
				for (int l = 0; l < maxPointsCount; l++)
				{
					int num13 = l;
					if (chart.Rotation >= 270 && chart.Rotation < 360)
					{
						num13 = maxPointsCount - 1 - num13;
					}
					float num14 = num4 * (float)num13;
					num14 = chart.WallsInternal.X + num14;
					if (flag)
					{
						num14 += num4 / 2f;
					}
					int num15 = num13;
					if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num15 = maxPointsCount - 1 - num13;
					}
					Class748 class4 = pointsInternal2.method_0(num15);
					if (class4 != null && !class4.NotPlotted)
					{
						double num16 = y1AxisRenderContext.method_2(class4.YValue);
						float num17 = (float)(categoryAxisCrossAt - num16) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
						if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
						{
							num17 = 0f - num17;
						}
						object[] array2 = new object[2]
						{
							class4,
							smethod_48(g, chart, categoryAxisY, num17, num14, shapeDepth, index2 + 1, list2.Count, renderContext)
						};
						arrayList.Add(array2);
						int num18 = 0;
						if (chart.Rotation >= 90 && chart.Rotation < 270)
						{
							num18 = 1;
						}
						list.Add(new object[3]
						{
							index2,
							num15,
							((PointF[])array2[1])[num18]
						});
					}
				}
				smethod_54(g, chart, arrayList);
				arrayList.Clear();
				smethod_45(g, chart, list, renderContext);
				list.Clear();
			}
		}
	}

	private static void smethod_41(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		float num = (float)chart.DepthPercent / 100f;
		float num2 = (float)chart.GapDepth / 100f;
		List<object[]> list = new List<object[]>();
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int minValue = (int)x1AxisRenderContext.MinValue;
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int num3 = 0;
		bool flag;
		if (flag = x1AxisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
		{
			num3 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		else
		{
			num3 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num3 == 0)
			{
				num3 = 1;
			}
		}
		float num4 = chart.WallsInternal.Width / (float)num3;
		float shapeDepth = num4 * num / (1f + num2);
		ArrayList arrayList = new ArrayList();
		IList list2 = nSeriesInternal.method_9();
		List<int> list3 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count = list3.Count;
		if ((chart.Rotation >= 0 && chart.Rotation < 90) || (chart.Rotation >= 180 && chart.Rotation < 270))
		{
			for (int i = 0; i < list2.Count; i++)
			{
				int num5 = list2.Count - 1 - i;
				if (chart.Rotation >= 180 && chart.Rotation < 270)
				{
					num5 = list2.Count - 1 - num5;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num5 = list2.Count - 1 - num5;
				}
				Class759 @class = (Class759)list2[num5];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				for (int j = 0; j < count; j++)
				{
					int num6 = j;
					if (chart.Rotation >= 180 && chart.Rotation < 270)
					{
						num6 = count - 1 - num6;
					}
					int val = int.Parse(list3[num6].ToString());
					val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
					int num7 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
					float num8 = num4 * (float)num7;
					float num9 = chart.WallsInternal.X + num8;
					if (flag)
					{
						num9 += num4 / 2f;
					}
					int num10 = num6;
					if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num10 = count - 1 - num6;
					}
					Class748 class2 = pointsInternal.method_0(num10);
					if (class2 != null && !class2.NotPlotted)
					{
						double num11 = y1AxisRenderContext.method_2(class2.YValue);
						float num12 = (float)(categoryAxisCrossAt - num11) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
						if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
						{
							num12 = 0f - num12;
						}
						object[] array = new object[2]
						{
							class2,
							smethod_48(g, chart, categoryAxisY, num12, num9, shapeDepth, index + 1, list2.Count, renderContext)
						};
						arrayList.Add(array);
						int num13 = 0;
						if (chart.Rotation >= 90 && chart.Rotation < 270)
						{
							num13 = 1;
						}
						list.Add(new object[3]
						{
							index,
							num10,
							((PointF[])array[1])[num13]
						});
					}
					else
					{
						arrayList.Add(null);
					}
				}
				smethod_54(g, chart, arrayList);
				arrayList.Clear();
				smethod_45(g, chart, list, renderContext);
				list.Clear();
			}
		}
		else
		{
			if ((chart.Rotation < 90 || chart.Rotation >= 180) && (chart.Rotation < 270 || chart.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < list2.Count; k++)
			{
				int num14 = k;
				if (chart.Rotation >= 270 && chart.Rotation < 360)
				{
					num14 = list2.Count - 1 - num14;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num14 = list2.Count - 1 - num14;
				}
				Class759 class3 = (Class759)list2[num14];
				int index2 = class3.Index;
				Class747 pointsInternal2 = class3.PointsInternal;
				for (int l = 0; l < count; l++)
				{
					int num15 = l;
					if (chart.Rotation >= 270 && chart.Rotation < 360)
					{
						num15 = count - 1 - num15;
					}
					int val2 = int.Parse(list3[num15].ToString());
					val2 = Struct21.smethod_38(baseUnitScale, val2, chart.IsDate1904);
					int num16 = Struct21.smethod_35(baseUnitScale, val2, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
					float num17 = num4 * (float)num16;
					float num18 = chart.WallsInternal.X + num17;
					if (flag)
					{
						num18 += num4 / 2f;
					}
					int num19 = num15;
					if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num19 = count - 1 - num15;
					}
					Class748 class4 = pointsInternal2.method_0(num19);
					if (class4 != null && !class4.NotPlotted)
					{
						double num20 = y1AxisRenderContext.method_2(class4.YValue);
						float num21 = (float)(categoryAxisCrossAt - num20) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
						if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
						{
							num21 = 0f - num21;
						}
						object[] array2 = new object[2]
						{
							class4,
							smethod_48(g, chart, categoryAxisY, num21, num18, shapeDepth, index2 + 1, list2.Count, renderContext)
						};
						arrayList.Add(array2);
						int num22 = 0;
						if (chart.Rotation >= 90 && chart.Rotation < 270)
						{
							num22 = 1;
						}
						list.Add(new object[3]
						{
							index2,
							num19,
							((PointF[])array2[1])[num22]
						});
					}
				}
				smethod_54(g, chart, arrayList);
				arrayList.Clear();
				smethod_45(g, chart, list, renderContext);
				list.Clear();
			}
		}
	}

	private static void smethod_42(double val, object[] aParamOfColumns, List<object[]> paramOfColumns, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		int num = (int)((double)((float)aParamOfColumns[2] + (float)aParamOfColumns[3]) + 0.5);
		if (paramOfColumns.Count == 0)
		{
			paramOfColumns.Add(aParamOfColumns);
			return;
		}
		int num2 = 0;
		while (true)
		{
			if (num2 >= paramOfColumns.Count)
			{
				return;
			}
			object[] array = paramOfColumns[num2];
			int num3 = (int)((double)((float)array[2] + (float)array[3]) + 0.5);
			if (chart.Elevation >= 0)
			{
				if (num > num3)
				{
					paramOfColumns.Insert(num2, aParamOfColumns);
					return;
				}
				if (num == num3)
				{
					if (axisRenderContext.Axis.IsPlotOrderReversed)
					{
						if (val > 0.0)
						{
							paramOfColumns.Insert(num2, aParamOfColumns);
						}
						else
						{
							paramOfColumns.Insert(num2 + 1, aParamOfColumns);
						}
					}
					else if (val < 0.0)
					{
						paramOfColumns.Insert(num2, aParamOfColumns);
					}
					else
					{
						paramOfColumns.Insert(num2 + 1, aParamOfColumns);
					}
					return;
				}
				if (num2 == paramOfColumns.Count - 1)
				{
					paramOfColumns.Add(aParamOfColumns);
					return;
				}
			}
			else
			{
				if (num < num3)
				{
					paramOfColumns.Insert(num2, aParamOfColumns);
					return;
				}
				if (num == num3)
				{
					if (!axisRenderContext.Axis.IsPlotOrderReversed)
					{
						if (val > 0.0)
						{
							paramOfColumns.Insert(num2, aParamOfColumns);
						}
						else
						{
							paramOfColumns.Insert(num2 + 1, aParamOfColumns);
						}
					}
					else if (val < 0.0)
					{
						paramOfColumns.Insert(num2, aParamOfColumns);
					}
					else
					{
						paramOfColumns.Insert(num2 + 1, aParamOfColumns);
					}
					return;
				}
				if (num2 == paramOfColumns.Count - 1)
				{
					break;
				}
			}
			num2++;
		}
		paramOfColumns.Add(aParamOfColumns);
	}

	private static PointF smethod_43(Class740 chart, float shapeX, float shapeWidth, float categoryAxisY, float height, bool isUp)
	{
		float num = shapeWidth / 2f;
		float float_ = Class745.float_1;
		height = ((!isUp) ? (height + float_) : (height - float_));
		float xCenter = chart.WallsInternal.xCenter;
		shapeX += num;
		float wallsWidth;
		if (shapeX <= xCenter)
		{
			wallsWidth = 2f * (xCenter - shapeX);
			return smethod_47(chart, categoryAxisY + height, wallsWidth, 0f, 0);
		}
		wallsWidth = 2f * (shapeX - xCenter);
		return smethod_47(chart, categoryAxisY + height, wallsWidth, 0f, 1);
	}

	internal static PointF smethod_44(Class740 chart, float shapeX, float shapeWidth, float shapeDepth, float categoryAxisY, float height)
	{
		int num = chart.Rotation / 45;
		float num2 = 0f;
		int num3 = 0;
		switch (num)
		{
		case 1:
			num2 = shapeWidth;
			shapeDepth = 0f;
			break;
		case 2:
			num2 = shapeWidth;
			shapeDepth = 0f;
			break;
		case 3:
			num2 = shapeWidth / 2f;
			num3 = 1;
			break;
		case 4:
			num2 = shapeWidth / 2f;
			num3 = 2;
			break;
		case 5:
			num2 = 0f;
			shapeDepth = 0f;
			break;
		case 6:
			num2 = 0f;
			shapeDepth = 0f;
			break;
		case 7:
			num2 = shapeWidth / 2f;
			break;
		case 0:
		case 8:
			num2 = shapeWidth / 2f;
			break;
		}
		float xCenter = chart.WallsInternal.xCenter;
		shapeX += num2;
		float wallsWidth;
		int order;
		if (shapeX <= xCenter)
		{
			wallsWidth = 2f * (xCenter - shapeX);
			order = ((num3 != 0) ? 3 : 0);
			return smethod_47(chart, categoryAxisY + height / 2f, wallsWidth, shapeDepth, order);
		}
		wallsWidth = 2f * (shapeX - xCenter);
		order = ((num3 == 0) ? 1 : 2);
		return smethod_47(chart, categoryAxisY + height / 2f, wallsWidth, shapeDepth, order);
	}

	internal static void smethod_45(Interface32 g, Class740 chart, List<object[]> paramOfDataLabels, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		for (int i = 0; i < paramOfDataLabels.Count; i++)
		{
			object[] array = paramOfDataLabels[i];
			int num = (int)array[0];
			int num2 = (int)array[1];
			PointF pointF = (PointF)array[2];
			bool flag = false;
			bool flag2 = false;
			if (array.Length == 4)
			{
				flag = true;
				flag2 = (bool)array[3];
			}
			Class750 dataLabelsInternal = nSeriesInternal.method_0(num).PointsInternal.method_0(num2).DataLabelsInternal;
			SizeF sizeF = Struct28.smethod_0(g, nSeriesInternal, num, num2, (int)chart.WallsInternal.Width, renderContext, renderContext.X1AxisRenderContext);
			float num3 = pointF.X - sizeF.Width / 2f;
			float num4 = pointF.Y - sizeF.Height / 2f;
			if (flag)
			{
				num4 = ((!flag2) ? pointF.Y : (pointF.Y - sizeF.Height));
			}
			dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_5(num3), Struct41.smethod_5(num4), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
			dataLabelsInternal.ChartFrameInternal.method_6();
			Struct28.smethod_1(g, nSeriesInternal, num, num2, dataLabelsInternal.ChartFrameInternal.rectangle_0, renderContext, renderContext.X1AxisRenderContext);
		}
	}

	private static void smethod_46(Interface32 g, Class748 chartPoint, Class740 chart, float shapeX, float shapeWidth, float wallsDepth, float categoryAxisY, float height, double totalValue, ref double preParaTop, Class784 renderContext)
	{
		Class759 aSeries = chartPoint.ChartPoints.ASeries;
		double num = 1.0;
		double num2 = 1.0;
		switch (aSeries.BarShape)
		{
		case ChartShapeType.Box:
			smethod_60(g, chartPoint, chart, shapeX, shapeWidth, wallsDepth, categoryAxisY, height, (float)num, (float)num2);
			break;
		case ChartShapeType.Cone:
			if (!aSeries.IsStatckedSeries && !aSeries.IsPercentSeries)
			{
				num = 0.0;
			}
			else
			{
				smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue7, out var totalMinusYValue7);
				if (chartPoint.YValue == 0.0)
				{
					num = preParaTop;
					num2 = preParaTop;
				}
				else if (chartPoint.YValue > 0.0)
				{
					num = ((totalPositiveYValue7 == 0.0) ? 1.0 : ((totalPositiveYValue7 - totalValue) / totalPositiveYValue7));
					num2 = ((totalPositiveYValue7 == 0.0) ? 1.0 : ((totalPositiveYValue7 - (totalValue - chartPoint.YValue)) / totalPositiveYValue7));
				}
				else
				{
					num = ((totalMinusYValue7 == 0.0) ? 1.0 : ((totalMinusYValue7 - totalValue) / totalMinusYValue7));
					num2 = ((totalMinusYValue7 == 0.0) ? 1.0 : ((totalMinusYValue7 - (totalValue - chartPoint.YValue)) / totalMinusYValue7));
				}
			}
			smethod_62(g, chartPoint, chart, shapeX, shapeWidth, wallsDepth, categoryAxisY, height, (float)num, (float)num2);
			break;
		case ChartShapeType.ConeToMax:
			if (aSeries.IsStatckedSeries)
			{
				smethod_59(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue3, out var totalMinusYValue3);
				if (chartPoint.YValue == 0.0)
				{
					num = preParaTop;
					num2 = preParaTop;
				}
				else if (chartPoint.YValue > 0.0)
				{
					num = ((totalPositiveYValue3 == 0.0) ? 1.0 : ((totalPositiveYValue3 - totalValue) / totalPositiveYValue3));
					num2 = ((totalPositiveYValue3 == 0.0) ? 1.0 : ((totalPositiveYValue3 - (totalValue - chartPoint.YValue)) / totalPositiveYValue3));
				}
				else
				{
					num = ((totalMinusYValue3 == 0.0) ? 1.0 : ((totalMinusYValue3 - totalValue) / totalMinusYValue3));
					num2 = ((totalMinusYValue3 == 0.0) ? 1.0 : ((totalMinusYValue3 - (totalValue - chartPoint.YValue)) / totalMinusYValue3));
				}
			}
			else if (aSeries.IsPercentSeries)
			{
				smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue4, out var totalMinusYValue4);
				if (chartPoint.YValue == 0.0)
				{
					num = preParaTop;
					num2 = preParaTop;
				}
				else if (chartPoint.YValue > 0.0)
				{
					num = ((totalPositiveYValue4 == 0.0) ? 1.0 : ((totalPositiveYValue4 - totalValue) / totalPositiveYValue4));
					num2 = ((totalPositiveYValue4 == 0.0) ? 1.0 : ((totalPositiveYValue4 - (totalValue - chartPoint.YValue)) / totalPositiveYValue4));
				}
				else
				{
					num = ((totalMinusYValue4 == 0.0) ? 1.0 : ((totalMinusYValue4 - totalValue) / totalMinusYValue4));
					num2 = ((totalMinusYValue4 == 0.0) ? 1.0 : ((totalMinusYValue4 - (totalValue - chartPoint.YValue)) / totalMinusYValue4));
				}
			}
			else
			{
				num = (float)smethod_57(chartPoint, renderContext);
				num2 = 1.0;
			}
			smethod_62(g, chartPoint, chart, shapeX, shapeWidth, wallsDepth, categoryAxisY, height, (float)num, (float)num2);
			break;
		case ChartShapeType.Cylinder:
			smethod_62(g, chartPoint, chart, shapeX, shapeWidth, wallsDepth, categoryAxisY, height, (float)num, (float)num2);
			break;
		case ChartShapeType.Pyramid:
			if (aSeries.IsStatckedSeries)
			{
				Class757 nSeriesInternal = chart.NSeriesInternal;
				List<Class759> list = nSeriesInternal.method_9();
				Class759 @class = list[0];
				int num3 = Struct24.smethod_27(list);
				double num4 = 0.0;
				switch (num3)
				{
				case 1:
					num4 = renderContext.Y1AxisRenderContext.MinValue;
					break;
				case 2:
					num4 = renderContext.Y1AxisRenderContext.MaxValue;
					break;
				}
				smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue5, out var totalMinusYValue5);
				if (chartPoint.YValue == 0.0)
				{
					num = preParaTop;
					num2 = preParaTop;
				}
				else if (chartPoint.YValue > 0.0)
				{
					double num5 = chartPoint.YValue;
					if (aSeries == @class)
					{
						num5 -= num4;
					}
					num = ((totalPositiveYValue5 == 0.0) ? 1.0 : ((totalPositiveYValue5 - totalValue) / (totalPositiveYValue5 - num4)));
					num2 = ((totalPositiveYValue5 == 0.0) ? 1.0 : ((totalPositiveYValue5 - (totalValue - num5)) / (totalPositiveYValue5 - num4)));
				}
				else
				{
					double num6 = chartPoint.YValue;
					if (aSeries == @class)
					{
						num6 -= num4;
					}
					num = ((totalMinusYValue5 == 0.0) ? 1.0 : ((totalMinusYValue5 - totalValue) / (totalMinusYValue5 - num4)));
					num2 = ((totalMinusYValue5 == 0.0) ? 1.0 : ((totalMinusYValue5 - (totalValue - num6)) / (totalMinusYValue5 - num4)));
				}
			}
			else if (aSeries.IsPercentSeries)
			{
				smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue6, out var totalMinusYValue6);
				if (chartPoint.YValue == 0.0)
				{
					num = preParaTop;
					num2 = preParaTop;
				}
				else if (chartPoint.YValue > 0.0)
				{
					num = ((totalPositiveYValue6 == 0.0) ? 1.0 : ((totalPositiveYValue6 - totalValue) / totalPositiveYValue6));
					num2 = ((totalPositiveYValue6 == 0.0) ? 1.0 : ((totalPositiveYValue6 - (totalValue - chartPoint.YValue)) / totalPositiveYValue6));
				}
				else
				{
					num = ((totalMinusYValue6 == 0.0) ? 1.0 : ((totalMinusYValue6 - totalValue) / totalMinusYValue6));
					num2 = ((totalMinusYValue6 == 0.0) ? 1.0 : ((totalMinusYValue6 - (totalValue - chartPoint.YValue)) / totalMinusYValue6));
				}
			}
			else
			{
				num = 0.0;
			}
			smethod_60(g, chartPoint, chart, shapeX, shapeWidth, wallsDepth, categoryAxisY, height, (float)num, (float)num2);
			break;
		case ChartShapeType.PyramidToMaximum:
			if (aSeries.IsStatckedSeries)
			{
				smethod_59(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue, out var totalMinusYValue);
				if (chartPoint.YValue == 0.0)
				{
					num = preParaTop;
					num2 = preParaTop;
				}
				else if (chartPoint.YValue > 0.0)
				{
					num = ((totalPositiveYValue == 0.0) ? 1.0 : ((totalPositiveYValue - totalValue) / totalPositiveYValue));
					num2 = ((totalPositiveYValue == 0.0) ? 1.0 : ((totalPositiveYValue - (totalValue - chartPoint.YValue)) / totalPositiveYValue));
				}
				else
				{
					num = ((totalMinusYValue == 0.0) ? 1.0 : ((totalMinusYValue - totalValue) / totalMinusYValue));
					num2 = ((totalMinusYValue == 0.0) ? 1.0 : ((totalMinusYValue - (totalValue - chartPoint.YValue)) / totalMinusYValue));
				}
			}
			else if (aSeries.IsPercentSeries)
			{
				smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue2, out var totalMinusYValue2);
				if (chartPoint.YValue == 0.0)
				{
					num = preParaTop;
					num2 = preParaTop;
				}
				else if (chartPoint.YValue > 0.0)
				{
					num = ((totalPositiveYValue2 == 0.0) ? 1.0 : ((totalPositiveYValue2 - totalValue) / totalPositiveYValue2));
					num2 = ((totalPositiveYValue2 == 0.0) ? 1.0 : ((totalPositiveYValue2 - (totalValue - chartPoint.YValue)) / totalPositiveYValue2));
				}
				else
				{
					num = ((totalMinusYValue2 == 0.0) ? 1.0 : ((totalMinusYValue2 - totalValue) / totalMinusYValue2));
					num2 = ((totalMinusYValue2 == 0.0) ? 1.0 : ((totalMinusYValue2 - (totalValue - chartPoint.YValue)) / totalMinusYValue2));
				}
			}
			else
			{
				num = (float)smethod_57(chartPoint, renderContext);
				num2 = 1.0;
			}
			smethod_60(g, chartPoint, chart, shapeX, shapeWidth, wallsDepth, categoryAxisY, height, (float)num, (float)num2);
			break;
		}
	}

	internal static PointF smethod_47(Class740 chart, float yFloor, float wallsWidth, float wallsDepth, int order)
	{
		PointF pointF = new PointF(chart.WallsInternal.X + chart.WallsInternal.Width / 2f, yFloor);
		int num = chart.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = chart.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = wallsDepth;
			num4 = wallsWidth;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = wallsWidth;
			num4 = wallsDepth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)chart.Elevation * Math.PI / 180.0);
		PointF[] array = new PointF[4];
		switch (num2)
		{
		case 1:
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 2:
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 3:
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			break;
		case 4:
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			break;
		case 5:
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 6:
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			break;
		case 7:
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			break;
		case 0:
		case 8:
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[0].X + num5;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			break;
		}
		return array[order];
	}

	internal static PointF[] smethod_48(Interface32 g, Class740 chart, float categoryAxisY, float height, float shapeX, float shapeDepth, int seriesIndex, int seriesCount, Class784 renderContext)
	{
		float num = shapeDepth * (float)chart.GapDepth / 100f;
		PointF[] array = new PointF[2];
		float xCenter = chart.WallsInternal.xCenter;
		float num2 = chart.WallsInternal.Depth / (float)seriesCount;
		float num3 = (float)seriesCount / 2f;
		if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
		{
			seriesIndex = seriesCount + 1 - seriesIndex;
		}
		if ((float)seriesIndex <= num3 && !renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
		{
			float num4 = ((num3 - (float)seriesIndex) * num2 + num / 2f + shapeDepth) * 2f;
			if (shapeX <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - shapeX);
				ref PointF reference = ref array[0];
				reference = smethod_47(chart, categoryAxisY + height, wallsWidth, num4, 0);
				num4 -= shapeDepth * 2f;
				ref PointF reference2 = ref array[1];
				reference2 = smethod_47(chart, categoryAxisY + height, wallsWidth, num4, 0);
			}
			else
			{
				float wallsWidth = 2f * (shapeX - xCenter);
				ref PointF reference3 = ref array[0];
				reference3 = smethod_47(chart, categoryAxisY + height, wallsWidth, num4, 1);
				num4 -= shapeDepth * 2f;
				ref PointF reference4 = ref array[1];
				reference4 = smethod_47(chart, categoryAxisY + height, wallsWidth, num4, 1);
			}
		}
		else
		{
			float num4 = (((float)seriesIndex - num3) * num2 - num / 2f - shapeDepth) * 2f;
			if (shapeX <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - shapeX);
				ref PointF reference5 = ref array[0];
				reference5 = smethod_47(chart, categoryAxisY + height, wallsWidth, num4, 3);
				num4 += shapeDepth * 2f;
				ref PointF reference6 = ref array[1];
				reference6 = smethod_47(chart, categoryAxisY + height, wallsWidth, num4, 3);
			}
			else
			{
				float wallsWidth = 2f * (shapeX - xCenter);
				ref PointF reference7 = ref array[0];
				reference7 = smethod_47(chart, categoryAxisY + height, wallsWidth, num4, 2);
				num4 += shapeDepth * 2f;
				ref PointF reference8 = ref array[1];
				reference8 = smethod_47(chart, categoryAxisY + height, wallsWidth, num4, 2);
			}
		}
		return array;
	}

	private static void smethod_49(Interface32 g, Class748 chartPoint, Class740 chart, float categoryAxisY, float height, float shapeX, float shapeWidth, float shapeDepth, int seriesIndex, int seriesCount, Class784 renderContext)
	{
		Class759 aSeries = chartPoint.ChartPoints.ASeries;
		switch (aSeries.BarShape)
		{
		case ChartShapeType.Box:
			smethod_50(g, chartPoint, chart, categoryAxisY, height, shapeX, shapeWidth, shapeDepth, seriesIndex, seriesCount, 1f, renderContext);
			break;
		case ChartShapeType.Cone:
			smethod_51(g, chartPoint, chart, categoryAxisY, height, shapeX, shapeWidth, shapeDepth, seriesIndex, seriesCount, 0f, renderContext);
			break;
		case ChartShapeType.ConeToMax:
			break;
		case ChartShapeType.Cylinder:
			smethod_51(g, chartPoint, chart, categoryAxisY, height, shapeX, shapeWidth, shapeDepth, seriesIndex, seriesCount, 1f, renderContext);
			break;
		case ChartShapeType.Pyramid:
			smethod_50(g, chartPoint, chart, categoryAxisY, height, shapeX, shapeWidth, shapeDepth, seriesIndex, seriesCount, 0f, renderContext);
			break;
		}
	}

	private static void smethod_50(Interface32 g, Class748 chartPoint, Class740 chart, float categoryAxisY, float height, float shapeX, float shapeWidth, float shapeDepth, int seriesIndex, int seriesCount, float paraTop, Class784 renderContext)
	{
		float num = shapeDepth * (float)chart.GapDepth / 100f;
		PointF[] array = new PointF[8];
		float xCenter = chart.WallsInternal.xCenter;
		float num2 = shapeX;
		float num3 = shapeX + shapeWidth * (1f - paraTop) / 2f;
		float num4 = chart.WallsInternal.Depth / (float)seriesCount;
		float num5 = (float)seriesCount / 2f;
		if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
		{
			seriesIndex = seriesCount + 1 - seriesIndex;
		}
		bool flag = false;
		if ((float)seriesIndex <= num5 && !renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
		{
			flag = true;
		}
		float num6 = (((float)seriesIndex - num5) * num4 - num / 2f - shapeDepth) * 2f;
		int order;
		int order2;
		if (flag)
		{
			num6 = 0f - num6;
			order = 0;
			order2 = 1;
		}
		else
		{
			order = 3;
			order2 = 2;
		}
		int num7 = 3;
		PointF empty = PointF.Empty;
		for (int i = 0; i < 2; i++)
		{
			if (num2 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num2);
				ref PointF reference = ref array[i];
				reference = smethod_47(chart, categoryAxisY, wallsWidth, num6, order);
				num6 = ((!flag) ? (num6 + shapeDepth * 2f) : (num6 - shapeDepth * 2f));
				ref PointF reference2 = ref array[i + num7];
				reference2 = smethod_47(chart, categoryAxisY, wallsWidth, num6, order);
			}
			else
			{
				float wallsWidth = 2f * (num2 - xCenter);
				ref PointF reference3 = ref array[i];
				reference3 = smethod_47(chart, categoryAxisY, wallsWidth, num6, order2);
				num6 = ((!flag) ? (num6 + shapeDepth * 2f) : (num6 - shapeDepth * 2f));
				ref PointF reference4 = ref array[i + num7];
				reference4 = smethod_47(chart, categoryAxisY, wallsWidth, num6, order2);
			}
			num6 = (((float)seriesIndex - num5) * num4 - num / 2f - shapeDepth) * 2f;
			if (flag)
			{
				num6 = 0f - num6;
			}
			if (num3 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num3);
				empty = smethod_47(chart, categoryAxisY, wallsWidth, smethod_53(num6, flag, shapeDepth, paraTop), order);
				array[i + 4].X = empty.X;
				array[i + 4].Y = empty.Y + height;
				if (paraTop == 1f)
				{
					num6 = ((!flag) ? (num6 + shapeDepth * 2f) : (num6 - shapeDepth * 2f));
				}
				empty = smethod_47(chart, categoryAxisY, wallsWidth, smethod_53(num6, flag, shapeDepth, paraTop), order);
				array[i + num7 + 4].X = empty.X;
				array[i + num7 + 4].Y = empty.Y + height;
			}
			else
			{
				float wallsWidth = 2f * (num3 - xCenter);
				empty = smethod_47(chart, categoryAxisY, wallsWidth, smethod_53(num6, flag, shapeDepth, paraTop), order2);
				array[i + 4].X = empty.X;
				array[i + 4].Y = empty.Y + height;
				if (paraTop == 1f)
				{
					num6 = ((!flag) ? (num6 + shapeDepth * 2f) : (num6 - shapeDepth * 2f));
				}
				empty = smethod_47(chart, categoryAxisY, wallsWidth, smethod_53(num6, flag, shapeDepth, paraTop), order2);
				array[i + num7 + 4].X = empty.X;
				array[i + num7 + 4].Y = empty.Y + height;
			}
			num7 = 1;
			num2 += shapeWidth;
			num3 += shapeWidth * paraTop;
			num6 = (((float)seriesIndex - num5) * num4 - num / 2f - shapeDepth) * 2f;
			if (flag)
			{
				num6 = 0f - num6;
			}
		}
		smethod_61(g, chart, chartPoint, array, height);
	}

	private static void smethod_51(Interface32 g, Class748 chartPoint, Class740 chart, float categoryAxisY, float height, float shapeX, float shapeWidth, float shapeDepth, int seriesIndex, int seriesCount, float paraTop, Class784 renderContext)
	{
		float xCenter = chart.WallsInternal.xCenter;
		Dictionary<int, PointF> dictionary = new Dictionary<int, PointF>();
		Dictionary<int, PointF> dictionary2 = new Dictionary<int, PointF>();
		float num = shapeX + shapeWidth / 2f;
		float num2 = shapeDepth * (float)chart.GapDepth / 100f;
		float num3 = chart.WallsInternal.Depth / (float)seriesCount;
		float num4 = (float)seriesCount / 2f;
		if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
		{
			seriesIndex = seriesCount + 1 - seriesIndex;
		}
		bool flag = false;
		if ((float)seriesIndex <= num4 && !renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
		{
			flag = true;
		}
		float num5 = (((float)seriesIndex - num4) * num3 - num2 / 2f - shapeDepth / 2f) * 2f;
		int order;
		int order2;
		if (flag)
		{
			num5 = 0f - num5;
			order = 0;
			order2 = 1;
		}
		else
		{
			order = 3;
			order2 = 2;
		}
		for (int i = 0; i <= 180; i++)
		{
			double num6 = (double)i * Math.PI / 180.0;
			float newWallsDepth = (float)((double)shapeDepth * Math.Sin(num6));
			float num7 = (float)((double)num + (double)(shapeWidth / 2f) * Math.Cos(num6));
			if (num7 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num7);
				if (!dictionary.ContainsKey(360 - i))
				{
					dictionary.Add(360 - i, smethod_47(chart, categoryAxisY, wallsWidth, smethod_52(360 - i, flag, num5, newWallsDepth), order));
				}
				if (!dictionary.ContainsKey(i))
				{
					dictionary.Add(i, smethod_47(chart, categoryAxisY, wallsWidth, smethod_52(i, flag, num5, newWallsDepth), order));
				}
			}
			else
			{
				float wallsWidth = 2f * (num7 - xCenter);
				if (!dictionary.ContainsKey(360 - i))
				{
					dictionary.Add(360 - i, smethod_47(chart, categoryAxisY, wallsWidth, smethod_52(360 - i, flag, num5, newWallsDepth), order2));
				}
				if (!dictionary.ContainsKey(i))
				{
					dictionary.Add(i, smethod_47(chart, categoryAxisY, wallsWidth, smethod_52(i, flag, num5, newWallsDepth), order2));
				}
			}
			num7 = (float)((double)num + (double)(shapeWidth / 2f * paraTop) * Math.Cos(num6));
			newWallsDepth = (float)((double)(shapeDepth * paraTop) * Math.Sin(num6));
			if (num7 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num7);
				if (!dictionary2.ContainsKey(360 - i))
				{
					PointF value = smethod_47(chart, categoryAxisY, wallsWidth, smethod_52(360 - i, flag, num5, newWallsDepth), order);
					value.Y += height;
					dictionary2.Add(360 - i, value);
				}
				if (!dictionary2.ContainsKey(i))
				{
					PointF value2 = smethod_47(chart, categoryAxisY, wallsWidth, smethod_52(i, flag, num5, newWallsDepth), order);
					value2.Y += height;
					dictionary2.Add(i, value2);
				}
			}
			else
			{
				float wallsWidth = 2f * (num7 - xCenter);
				if (!dictionary2.ContainsKey(360 - i))
				{
					PointF value3 = smethod_47(chart, categoryAxisY, wallsWidth, smethod_52(360 - i, flag, num5, newWallsDepth), order2);
					value3.Y += height;
					dictionary2.Add(360 - i, value3);
				}
				if (!dictionary2.ContainsKey(i))
				{
					PointF value4 = smethod_47(chart, categoryAxisY, wallsWidth, smethod_52(i, flag, num5, newWallsDepth), order2);
					value4.Y += height;
					dictionary2.Add(i, value4);
				}
			}
		}
		smethod_64(g, chartPoint, dictionary, dictionary2, height);
	}

	private static float smethod_52(int angle, bool isLowSeriesIndex, float wallsDepth, float newWallsDepth)
	{
		if (isLowSeriesIndex)
		{
			if (angle <= 180)
			{
				return wallsDepth - newWallsDepth;
			}
			return wallsDepth + newWallsDepth;
		}
		if (angle <= 180)
		{
			return wallsDepth + newWallsDepth;
		}
		return wallsDepth - newWallsDepth;
	}

	private static float smethod_53(float wallsDepth, bool isLowSeriesIndex, float shapeDepth, float paraTop)
	{
		wallsDepth = ((!isLowSeriesIndex) ? (wallsDepth + shapeDepth * (1f - paraTop)) : (wallsDepth - shapeDepth * (1f - paraTop)));
		return wallsDepth;
	}

	private static void smethod_54(Interface32 g, Class740 chart, IList listLinePoints)
	{
		if (listLinePoints.Count <= 1)
		{
			return;
		}
		PointF[] previousPoints = null;
		int i;
		for (i = 0; i < listLinePoints.Count; i++)
		{
			if (listLinePoints[i] != null)
			{
				object[] array = (object[])listLinePoints[i];
				previousPoints = (PointF[])array[1];
				i++;
				break;
			}
		}
		for (int j = i; j < listLinePoints.Count; j++)
		{
			if (listLinePoints[j] != null)
			{
				object[] array2 = (object[])listLinePoints[j];
				Class748 chartPoint = (Class748)array2[0];
				PointF[] array3 = (PointF[])array2[1];
				smethod_55(g, chart, chartPoint, previousPoints, array3);
				previousPoints = array3;
			}
			else
			{
				previousPoints = null;
			}
		}
	}

	private static void smethod_55(Interface32 g, Class740 chart, Class748 chartPoint, PointF[] previousPoints, PointF[] points)
	{
		if (previousPoints == null || points == null || chartPoint == null)
		{
			return;
		}
		Class741 areaInternal = chartPoint.AreaInternal;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(new PointF[4]
		{
			previousPoints[0],
			points[0],
			points[1],
			previousPoints[1]
		});
		graphicsPath.CloseAllFigures();
		Brush brush = areaInternal.method_14(graphicsPath);
		if (chart.Rotation == 0 || chart.Rotation == 360 || chart.Rotation == 180)
		{
			brush = ((points[1].Y > points[0].Y) ? ((chart.Rotation == 0 || chart.Rotation == 360) ? areaInternal.method_15(graphicsPath, 2f / 3f) : areaInternal.method_14(graphicsPath)) : ((chart.Rotation == 0 || chart.Rotation == 360) ? areaInternal.method_14(graphicsPath) : areaInternal.method_15(graphicsPath, 2f / 3f)));
		}
		else if (chart.Rotation == 90 || chart.Rotation == 270)
		{
			brush = ((!(points[0].Y > previousPoints[0].Y)) ? areaInternal.method_15(graphicsPath, 2f / 3f) : areaInternal.method_14(graphicsPath));
		}
		else if (previousPoints[1].X != points[1].X && previousPoints[1].Y != points[1].Y)
		{
			float num = 0f;
			float num2 = (num - previousPoints[1].Y - (num - points[1].Y)) / (previousPoints[1].X - points[1].X);
			float num3 = num - points[1].Y - num2 * points[1].X;
			float num4 = num - points[0].Y;
			float num5 = num2 * points[0].X + num3;
			if ((chart.Rotation > 0 && chart.Rotation < 90) || (chart.Rotation > 270 && chart.Rotation < 360))
			{
				brush = ((!(num4 > num5)) ? areaInternal.method_14(graphicsPath) : areaInternal.method_15(graphicsPath, 2f / 3f));
			}
			else if (chart.Rotation > 90 && chart.Rotation < 270)
			{
				brush = ((!(num4 < num5)) ? areaInternal.method_14(graphicsPath) : areaInternal.method_15(graphicsPath, 2f / 3f));
			}
		}
		g.imethod_77(brush, graphicsPath);
		Pen pen = chartPoint.BorderInternal.method_9(graphicsPath);
		g.imethod_40(pen, previousPoints[0], points[0]);
		g.imethod_40(pen, points[0], points[1]);
		g.imethod_40(pen, points[1], previousPoints[1]);
		g.imethod_40(pen, previousPoints[1], previousPoints[0]);
	}

	private static PointF smethod_56(Class740 chart, float categoryAxisY, float height, float shapeX, float shapeWidth, float shapeDepth, int seriesIndex, int seriesCount, bool isUp, Class784 renderContext)
	{
		int num = chart.Rotation / 45;
		float num2 = 0f;
		float num3 = 0f;
		switch (num)
		{
		case 1:
			num2 = shapeWidth;
			num3 = shapeDepth / 2f;
			break;
		case 2:
			num2 = shapeWidth;
			num3 = shapeDepth / 2f;
			break;
		case 3:
			num2 = shapeWidth / 2f;
			num3 = shapeDepth;
			break;
		case 4:
			num2 = shapeWidth / 2f;
			num3 = shapeDepth;
			break;
		case 5:
			num2 = 0f;
			num3 = shapeDepth / 2f;
			break;
		case 6:
			num2 = 0f;
			num3 = shapeDepth / 2f;
			break;
		case 7:
			num2 = shapeWidth / 2f;
			break;
		case 0:
		case 8:
			num2 = shapeWidth / 2f;
			break;
		}
		float xCenter = chart.WallsInternal.xCenter;
		shapeX += num2;
		float float_ = Class745.float_1;
		height = ((!isUp) ? (height + float_) : (height - float_));
		float num4 = shapeDepth * (float)chart.GapDepth / 100f;
		float num5 = chart.WallsInternal.Depth / (float)seriesCount;
		float num6 = (float)seriesCount / 2f;
		if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
		{
			seriesIndex = seriesCount + 1 - seriesIndex;
		}
		float wallsDepth;
		float wallsWidth;
		if ((float)seriesIndex <= num6 && !renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
		{
			wallsDepth = ((num6 - (float)seriesIndex) * num5 + num4 / 2f + shapeDepth - num3) * 2f;
			if (shapeX <= xCenter)
			{
				wallsWidth = 2f * (xCenter - shapeX);
				return smethod_47(chart, categoryAxisY + height, wallsWidth, wallsDepth, 0);
			}
			wallsWidth = 2f * (shapeX - xCenter);
			return smethod_47(chart, categoryAxisY + height, wallsWidth, wallsDepth, 1);
		}
		wallsDepth = (((float)seriesIndex - num6) * num5 - num4 / 2f - shapeDepth + num3) * 2f;
		if (shapeX <= xCenter)
		{
			wallsWidth = 2f * (xCenter - shapeX);
			return smethod_47(chart, categoryAxisY + height, wallsWidth, wallsDepth, 3);
		}
		wallsWidth = 2f * (shapeX - xCenter);
		return smethod_47(chart, categoryAxisY + height, wallsWidth, wallsDepth, 2);
	}

	internal static double smethod_57(Class748 chartPoint, Class784 renderContext)
	{
		double num = 0.0;
		double num2 = 0.0;
		double logCrossAt = renderContext.Y1AxisRenderContext.LogCrossAt;
		Class757 nSeriesInternal = chartPoint.Chart.NSeriesInternal;
		for (int i = 0; i < chartPoint.ChartPoints.Count; i++)
		{
			for (int j = 0; j < nSeriesInternal.Count; j++)
			{
				Class748 @class = nSeriesInternal.method_0(j).PointsInternal.method_0(i);
				if (@class != null)
				{
					double yValue = @class.YValue;
					if (yValue > logCrossAt && num < yValue - logCrossAt)
					{
						num = yValue - logCrossAt;
					}
					if (yValue < logCrossAt && num2 < logCrossAt - yValue)
					{
						num2 = logCrossAt - yValue;
					}
				}
			}
		}
		double num3 = renderContext.Y1AxisRenderContext.method_2(chartPoint.YValue);
		if (chartPoint.YValue >= logCrossAt)
		{
			if (num != 0.0)
			{
				return (num - (num3 - logCrossAt)) / num;
			}
			return 1.0;
		}
		if (num2 != 0.0)
		{
			return (num2 - (logCrossAt - num3)) / num2;
		}
		return 1.0;
	}

	internal static void smethod_58(Class757 nSeries, int pointIndex, out double totalPositiveYValue, out double totalMinusYValue)
	{
		totalPositiveYValue = 0.0;
		totalMinusYValue = 0.0;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Class759 @class = nSeries.method_0(i);
			double yValue = @class.PointsInternal[pointIndex].YValue;
			if (yValue > 0.0)
			{
				totalPositiveYValue += yValue;
			}
			if (yValue < 0.0)
			{
				totalMinusYValue += yValue;
			}
		}
	}

	internal static void smethod_59(Class757 nSeries, int pointIndex, out double totalPositiveYValue, out double totalMinusYValue)
	{
		totalPositiveYValue = 0.0;
		totalMinusYValue = 0.0;
		int num = nSeries.method_1();
		for (int i = 0; i < num; i++)
		{
			smethod_58(nSeries, i, out var totalPositiveYValue2, out var totalMinusYValue2);
			if (totalPositiveYValue2 > totalPositiveYValue)
			{
				totalPositiveYValue = totalPositiveYValue2;
			}
			if (totalMinusYValue2 < totalMinusYValue)
			{
				totalMinusYValue = totalMinusYValue2;
			}
		}
	}

	private static void smethod_60(Interface32 g, Class748 chartPoint, Class740 chart, float shapeX, float shapeWidth, float wallsDepth, float categoryAxisY, float height, float paraTop, float paraBottom)
	{
		PointF[] array = new PointF[8];
		float xCenter = chart.WallsInternal.xCenter;
		_ = chartPoint.ChartPoints.ASeries;
		int num = 3;
		PointF empty = PointF.Empty;
		float num2 = shapeX + shapeWidth * (1f - paraTop) / 2f;
		float num3 = shapeX + shapeWidth * (1f - paraBottom) / 2f;
		for (int i = 0; i < 2; i++)
		{
			if (num3 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num3);
				ref PointF reference = ref array[i];
				reference = smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraBottom, 0);
				ref PointF reference2 = ref array[i + num];
				reference2 = smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraBottom, 3);
			}
			else
			{
				float wallsWidth = 2f * (num3 - xCenter);
				ref PointF reference3 = ref array[i];
				reference3 = smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraBottom, 1);
				ref PointF reference4 = ref array[i + num];
				reference4 = smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraBottom, 2);
			}
			if (num2 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num2);
				empty = smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraTop, 0);
				array[i + 4].X = empty.X;
				array[i + 4].Y = empty.Y + height;
				empty = smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraTop, 3);
				array[i + num + 4].X = empty.X;
				array[i + num + 4].Y = empty.Y + height;
			}
			else
			{
				float wallsWidth = 2f * (num2 - xCenter);
				empty = smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraTop, 1);
				array[i + 4].X = empty.X;
				array[i + 4].Y = empty.Y + height;
				empty = smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraTop, 2);
				array[i + num + 4].X = empty.X;
				array[i + num + 4].Y = empty.Y + height;
			}
			num = 1;
			num3 += shapeWidth * paraBottom;
			num2 += shapeWidth * paraTop;
		}
		smethod_61(g, chart, chartPoint, array, height);
	}

	private static void smethod_61(Interface32 g, Class740 chart, Class748 chartPoint, PointF[] points, float height)
	{
		Class741 areaInternal = chartPoint.AreaInternal;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(points);
		Pen pen = chartPoint.BorderInternal.method_9(graphicsPath);
		g.imethod_40(pen, points[0], points[1]);
		g.imethod_40(pen, points[1], points[2]);
		g.imethod_40(pen, points[2], points[3]);
		g.imethod_40(pen, points[0], points[3]);
		if (height != 0f)
		{
			g.imethod_40(pen, points[4], points[5]);
			g.imethod_40(pen, points[5], points[6]);
			g.imethod_40(pen, points[6], points[7]);
			g.imethod_40(pen, points[4], points[7]);
			g.imethod_40(pen, points[0], points[4]);
			g.imethod_40(pen, points[1], points[5]);
			g.imethod_40(pen, points[2], points[6]);
			g.imethod_40(pen, points[3], points[7]);
		}
		if (height != 0f)
		{
			if (chart.Rotation > 45 && chart.Rotation != 360)
			{
				if (chart.Rotation > 45 && chart.Rotation <= 90)
				{
					GraphicsPath graphicsPath2 = new GraphicsPath();
					graphicsPath2.AddPolygon(new PointF[4]
					{
						points[1],
						points[2],
						points[6],
						points[5]
					});
					Brush brush = areaInternal.method_14(graphicsPath2);
					g.imethod_77(brush, graphicsPath2);
					GraphicsPath graphicsPath3 = new GraphicsPath();
					graphicsPath3.AddPolygon(new PointF[4]
					{
						points[0],
						points[1],
						points[5],
						points[4]
					});
					Brush brush2 = areaInternal.method_15(graphicsPath3, 0.5f);
					g.imethod_77(brush2, graphicsPath3);
					g.imethod_45(pen, graphicsPath2);
					g.imethod_45(pen, graphicsPath3);
				}
				else if (chart.Rotation > 90 && chart.Rotation <= 135)
				{
					GraphicsPath graphicsPath4 = new GraphicsPath();
					graphicsPath4.AddPolygon(new PointF[4]
					{
						points[1],
						points[2],
						points[6],
						points[5]
					});
					Brush brush3 = areaInternal.method_14(graphicsPath4);
					g.imethod_77(brush3, graphicsPath4);
					GraphicsPath graphicsPath5 = new GraphicsPath();
					graphicsPath5.AddPolygon(new PointF[4]
					{
						points[2],
						points[3],
						points[7],
						points[6]
					});
					Brush brush4 = areaInternal.method_15(graphicsPath5, 0.5f);
					g.imethod_77(brush4, graphicsPath5);
					g.imethod_45(pen, graphicsPath4);
					g.imethod_45(pen, graphicsPath5);
				}
				else if (chart.Rotation > 135 && chart.Rotation <= 180)
				{
					GraphicsPath graphicsPath6 = new GraphicsPath();
					graphicsPath6.AddPolygon(new PointF[4]
					{
						points[2],
						points[3],
						points[7],
						points[6]
					});
					Brush brush5 = areaInternal.method_14(graphicsPath6);
					g.imethod_77(brush5, graphicsPath6);
					GraphicsPath graphicsPath7 = new GraphicsPath();
					graphicsPath7.AddPolygon(new PointF[4]
					{
						points[1],
						points[2],
						points[6],
						points[5]
					});
					Brush brush6 = areaInternal.method_15(graphicsPath7, 0.5f);
					g.imethod_77(brush6, graphicsPath7);
					g.imethod_45(pen, graphicsPath6);
					g.imethod_45(pen, graphicsPath7);
				}
				else if (chart.Rotation > 180 && chart.Rotation <= 225)
				{
					GraphicsPath graphicsPath8 = new GraphicsPath();
					graphicsPath8.AddPolygon(new PointF[4]
					{
						points[2],
						points[3],
						points[7],
						points[6]
					});
					Brush brush7 = areaInternal.method_14(graphicsPath8);
					g.imethod_77(brush7, graphicsPath8);
					GraphicsPath graphicsPath9 = new GraphicsPath();
					graphicsPath9.AddPolygon(new PointF[4]
					{
						points[3],
						points[0],
						points[4],
						points[7]
					});
					Brush brush8 = areaInternal.method_15(graphicsPath9, 0.5f);
					g.imethod_77(brush8, graphicsPath9);
					g.imethod_45(pen, graphicsPath8);
					g.imethod_45(pen, graphicsPath9);
				}
				else if (chart.Rotation > 225 && chart.Rotation <= 270)
				{
					GraphicsPath graphicsPath10 = new GraphicsPath();
					graphicsPath10.AddPolygon(new PointF[4]
					{
						points[3],
						points[0],
						points[4],
						points[7]
					});
					Brush brush9 = areaInternal.method_14(graphicsPath10);
					g.imethod_77(brush9, graphicsPath10);
					GraphicsPath graphicsPath11 = new GraphicsPath();
					graphicsPath11.AddPolygon(new PointF[4]
					{
						points[2],
						points[3],
						points[7],
						points[6]
					});
					Brush brush10 = areaInternal.method_15(graphicsPath11, 0.5f);
					g.imethod_77(brush10, graphicsPath11);
					g.imethod_45(pen, graphicsPath10);
					g.imethod_45(pen, graphicsPath11);
				}
				else if (chart.Rotation > 270 && chart.Rotation <= 315)
				{
					GraphicsPath graphicsPath12 = new GraphicsPath();
					graphicsPath12.AddPolygon(new PointF[4]
					{
						points[3],
						points[0],
						points[4],
						points[7]
					});
					Brush brush11 = areaInternal.method_14(graphicsPath12);
					g.imethod_77(brush11, graphicsPath12);
					GraphicsPath graphicsPath13 = new GraphicsPath();
					graphicsPath13.AddPolygon(new PointF[4]
					{
						points[0],
						points[1],
						points[5],
						points[4]
					});
					Brush brush12 = areaInternal.method_15(graphicsPath13, 0.5f);
					g.imethod_77(brush12, graphicsPath13);
					g.imethod_45(pen, graphicsPath12);
					g.imethod_45(pen, graphicsPath13);
				}
				else if (chart.Rotation > 315 && chart.Rotation < 360)
				{
					GraphicsPath graphicsPath14 = new GraphicsPath();
					graphicsPath14.AddPolygon(new PointF[4]
					{
						points[0],
						points[1],
						points[5],
						points[4]
					});
					Brush brush13 = areaInternal.method_14(graphicsPath14);
					g.imethod_77(brush13, graphicsPath14);
					GraphicsPath graphicsPath15 = new GraphicsPath();
					graphicsPath15.AddPolygon(new PointF[4]
					{
						points[3],
						points[0],
						points[4],
						points[7]
					});
					Brush brush14 = areaInternal.method_15(graphicsPath15, 0.5f);
					g.imethod_77(brush14, graphicsPath15);
					g.imethod_45(pen, graphicsPath14);
					g.imethod_45(pen, graphicsPath15);
				}
			}
			else
			{
				GraphicsPath graphicsPath16 = new GraphicsPath();
				graphicsPath16.AddPolygon(new PointF[4]
				{
					points[0],
					points[1],
					points[5],
					points[4]
				});
				Brush brush15 = areaInternal.method_14(graphicsPath16);
				g.imethod_77(brush15, graphicsPath16);
				GraphicsPath graphicsPath17 = new GraphicsPath();
				graphicsPath17.AddPolygon(new PointF[4]
				{
					points[1],
					points[2],
					points[6],
					points[5]
				});
				Brush brush16 = areaInternal.method_15(graphicsPath17, 0.5f);
				g.imethod_77(brush16, graphicsPath17);
				g.imethod_45(pen, graphicsPath16);
				g.imethod_45(pen, graphicsPath17);
			}
			if (chart.Elevation > 0)
			{
				if (height <= 0f)
				{
					GraphicsPath graphicsPath18 = new GraphicsPath();
					graphicsPath18.AddPolygon(new PointF[4]
					{
						points[4],
						points[5],
						points[6],
						points[7]
					});
					areaInternal.method_7(graphicsPath18, 2f / 3f);
					chartPoint.BorderInternal.method_8(graphicsPath18);
				}
				else
				{
					GraphicsPath graphicsPath19 = new GraphicsPath();
					graphicsPath19.AddPolygon(new PointF[4]
					{
						points[0],
						points[1],
						points[2],
						points[3]
					});
					areaInternal.method_7(graphicsPath19, 2f / 3f);
					chartPoint.BorderInternal.method_8(graphicsPath19);
				}
			}
			else if (chart.Elevation < 0)
			{
				if (height <= 0f)
				{
					GraphicsPath graphicsPath20 = new GraphicsPath();
					graphicsPath20.AddPolygon(new PointF[4]
					{
						points[0],
						points[1],
						points[2],
						points[3]
					});
					areaInternal.method_7(graphicsPath20, 1f / 3f);
					chartPoint.BorderInternal.method_8(graphicsPath20);
				}
				else
				{
					GraphicsPath graphicsPath21 = new GraphicsPath();
					graphicsPath21.AddPolygon(new PointF[4]
					{
						points[4],
						points[5],
						points[6],
						points[7]
					});
					areaInternal.method_7(graphicsPath21, 1f / 3f);
					chartPoint.BorderInternal.method_8(graphicsPath21);
				}
			}
		}
		else
		{
			GraphicsPath graphicsPath22 = new GraphicsPath();
			graphicsPath22.AddPolygon(new PointF[4]
			{
				points[0],
				points[1],
				points[2],
				points[3]
			});
			if (chart.Elevation > 0)
			{
				areaInternal.method_7(graphicsPath22, 2f / 3f);
			}
			else
			{
				areaInternal.method_7(graphicsPath22, 1f / 3f);
			}
			chartPoint.BorderInternal.method_8(graphicsPath22);
		}
	}

	private static void smethod_62(Interface32 g, Class748 chartPoint, Class740 chart, float shapeX, float shapeWidth, float wallsDepth, float categoryAxisY, float height, float paraTop, float paraBottom)
	{
		float xCenter = chart.WallsInternal.xCenter;
		Dictionary<int, PointF> dictionary = new Dictionary<int, PointF>();
		Dictionary<int, PointF> dictionary2 = new Dictionary<int, PointF>();
		float num = shapeX + shapeWidth / 2f;
		for (int i = 0; i <= 180; i++)
		{
			double num2 = (double)i * Math.PI / 180.0;
			float num3 = (float)((double)wallsDepth * Math.Sin(num2));
			float num4 = (float)((double)num + (double)(shapeWidth * paraBottom / 2f) * Math.Cos(num2));
			if (num4 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num4);
				if (!dictionary.ContainsKey(360 - i))
				{
					dictionary.Add(360 - i, smethod_47(chart, categoryAxisY, wallsWidth, num3 * paraBottom, 0));
				}
				if (!dictionary.ContainsKey(i))
				{
					dictionary.Add(i, smethod_47(chart, categoryAxisY, wallsWidth, num3 * paraBottom, 3));
				}
			}
			else
			{
				float wallsWidth = 2f * (num4 - xCenter);
				if (!dictionary.ContainsKey(360 - i))
				{
					dictionary.Add(360 - i, smethod_47(chart, categoryAxisY, wallsWidth, num3 * paraBottom, 1));
				}
				if (!dictionary.ContainsKey(i))
				{
					dictionary.Add(i, smethod_47(chart, categoryAxisY, wallsWidth, num3 * paraBottom, 2));
				}
			}
			num4 = (float)((double)num + (double)(shapeWidth * paraTop / 2f) * Math.Cos(num2));
			if (num4 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num4);
				if (!dictionary2.ContainsKey(360 - i))
				{
					PointF value = smethod_47(chart, categoryAxisY, wallsWidth, num3 * paraTop, 0);
					value.Y += height;
					dictionary2.Add(360 - i, value);
				}
				if (!dictionary2.ContainsKey(i))
				{
					PointF value2 = smethod_47(chart, categoryAxisY, wallsWidth, num3 * paraTop, 3);
					value2.Y += height;
					dictionary2.Add(i, value2);
				}
			}
			else
			{
				float wallsWidth = 2f * (num4 - xCenter);
				if (!dictionary2.ContainsKey(360 - i))
				{
					PointF value3 = smethod_47(chart, categoryAxisY, wallsWidth, num3 * paraTop, 1);
					value3.Y += height;
					dictionary2.Add(360 - i, value3);
				}
				if (!dictionary2.ContainsKey(i))
				{
					PointF value4 = smethod_47(chart, categoryAxisY, wallsWidth, num3 * paraTop, 2);
					value4.Y += height;
					dictionary2.Add(i, value4);
				}
			}
		}
		smethod_64(g, chartPoint, dictionary, dictionary2, height);
	}

	private static PointF smethod_63(Interface32 g, Class748 chartPoint, Class740 chart, float shapeX, float shapeWidth, float wallsDepth, float categoryAxisY, float height, float paraTop, float paraBottom, double angle)
	{
		float xCenter = chart.WallsInternal.xCenter;
		float num = shapeX + shapeWidth / 2f;
		double num2 = angle * Math.PI / 180.0;
		wallsDepth = (float)((double)(shapeWidth / 2f) * Math.Sin(num2));
		float num3 = (float)((double)num + (double)(shapeWidth / 2f) * Math.Cos(num2));
		float wallsWidth;
		if (num3 <= xCenter)
		{
			wallsWidth = 2f * (xCenter - num3);
			if (angle >= 180.0 && angle <= 360.0)
			{
				return smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraBottom, 0);
			}
			return smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraBottom, 3);
		}
		wallsWidth = 2f * (num3 - xCenter);
		if (angle >= 180.0 && angle <= 360.0)
		{
			return smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraBottom, 1);
		}
		return smethod_47(chart, categoryAxisY, wallsWidth, wallsDepth * paraBottom, 2);
	}

	private static void smethod_64(Interface32 g, Class748 chartPoint, Dictionary<int, PointF> htPointBottom, Dictionary<int, PointF> htPointTop, float height)
	{
		_ = chartPoint.ChartPoints.ASeries;
		Class740 chart = chartPoint.Chart;
		Class741 areaInternal = chartPoint.AreaInternal;
		int rotation = chart.Rotation;
		smethod_65(htPointBottom, out var max, out var min, out var maxAngle, out var minAngle);
		smethod_65(htPointTop, out var max2, out var min2, out var _, out var _);
		if (height != 0f)
		{
			int num = 180;
			int num2 = 360;
			float num3 = 0.5f;
			float num4 = 7.5f;
			float num5;
			for (num5 = 180 + rotation; num5 <= (float)(num2 + rotation); num5 += num4)
			{
				int key = (int)(num5 % 360f);
				PointF pointF = htPointBottom[key];
				PointF pointF2 = htPointTop[key];
				if (num5 == (float)(num + rotation))
				{
					pointF = min;
					pointF2 = min2;
				}
				float num6 = num4;
				if ((num5 - (float)num == 45f && rotation <= 30) || (num5 - (float)num == 135f && rotation > 30) || num5 - (float)num == 90f || num5 - (float)num == 180f || (num5 - (float)num == 225f && rotation > 120) || num5 - (float)num == 270f || (num5 - (float)num == 315f && rotation > 210) || num5 - (float)num == 360f || (num5 - (float)num == 405f && rotation > 300) || num5 - (float)num == 450f)
				{
					num6 = 2f * num4;
				}
				if (num5 == (float)(num + rotation))
				{
					num6 = num4 - (float)rotation % num4;
				}
				int key2 = ((num5 + num6 > (float)(num2 + rotation)) ? ((num2 + rotation) % 360) : ((int)((num5 + num6) % 360f)));
				PointF pointF3 = htPointBottom[key2];
				PointF pointF4 = htPointTop[key2];
				if (num5 + num6 >= (float)(num2 + rotation))
				{
					pointF3 = max;
					pointF4 = max2;
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				PointF[] array = new PointF[(int)num6 + 1];
				int num7 = 0;
				for (int i = (int)num5; i <= (int)num5 + (int)num6; i++)
				{
					ref PointF reference = ref array[num7];
					reference = htPointBottom[i % 360];
					num7++;
				}
				graphicsPath.AddLine(pointF, pointF3);
				graphicsPath.AddLine(pointF3, pointF4);
				PointF[] array2 = new PointF[(int)num6 + 1];
				num7 = 0;
				for (int num8 = (int)num5 + (int)num6; num8 >= (int)num5; num8--)
				{
					ref PointF reference2 = ref array2[num7];
					reference2 = htPointTop[num8 % 360];
					num7++;
				}
				graphicsPath.AddLine(pointF4, pointF2);
				graphicsPath.AddLine(pointF2, pointF);
				if (rotation >= 0 && rotation <= 30)
				{
					num3 = ((!(num5 - (float)num < 45f)) ? (1.125f - 0.5f * ((num5 - (float)num) / 180f)) : (0.75f + 0.5f * ((num5 - (float)num) / 90f)));
				}
				else if (rotation > 30 && rotation <= 120)
				{
					num3 = ((!(num5 - (float)num < 135f)) ? (1.375f - 0.5f * ((num5 - (float)num) / 180f)) : (0.625f + 0.5f * ((num5 - (float)num) / 180f)));
				}
				else if (rotation > 120 && rotation <= 210)
				{
					num3 = ((!(num5 - (float)num < 225f)) ? (1.375f - 0.5f * ((num5 - (float)num - 90f) / 180f)) : (0.625f + 0.5f * ((num5 - (float)num - 90f) / 180f)));
				}
				else if (rotation > 210 && rotation <= 300)
				{
					num3 = ((!(num5 - (float)num < 315f)) ? (1.375f - 0.5f * ((num5 - (float)num - 180f) / 180f)) : (0.625f + 0.5f * ((num5 - (float)num - 180f) / 180f)));
				}
				else if (rotation > 300 && rotation <= 360)
				{
					num3 = ((!(num5 - (float)num < 405f)) ? (1.375f - 0.5f * ((num5 - (float)num - 270f) / 180f)) : (0.625f + 0.5f * ((num5 - (float)num - 270f) / 180f)));
				}
				if (num3 == 1f)
				{
					num3 -= 1f / 90f;
				}
				areaInternal.method_7(graphicsPath, num3);
				num5 += num6 - num4;
			}
		}
		GraphicsPath graphicsPath2 = new GraphicsPath();
		GraphicsPath graphicsPath3 = new GraphicsPath();
		PointF[] array3 = new PointF[htPointBottom.Count];
		PointF[] array4 = new PointF[htPointBottom.Count];
		for (int j = 0; j <= 360; j++)
		{
			ref PointF reference3 = ref array3[j];
			reference3 = htPointBottom[j];
			ref PointF reference4 = ref array4[j];
			reference4 = htPointTop[j];
		}
		graphicsPath2.AddCurve(array3);
		graphicsPath3.AddCurve(array4);
		if (chart.Elevation > 0)
		{
			if (height < 0f)
			{
				areaInternal.method_7(graphicsPath3, 0.7f);
				chartPoint.BorderInternal.method_8(graphicsPath3);
				smethod_67(g, chartPoint, maxAngle, minAngle, htPointBottom);
			}
			else if (height > 0f)
			{
				areaInternal.method_7(graphicsPath2, 0.7f);
				chartPoint.BorderInternal.method_8(graphicsPath2);
				smethod_67(g, chartPoint, maxAngle, minAngle, htPointTop);
			}
			else
			{
				areaInternal.method_7(graphicsPath2, 0.7f);
				chartPoint.BorderInternal.method_8(graphicsPath2);
			}
		}
		else if (chart.Elevation < 0)
		{
			if (height < 0f)
			{
				areaInternal.method_7(graphicsPath2, 1f / 3f);
				chartPoint.BorderInternal.method_8(graphicsPath2);
				smethod_67(g, chartPoint, maxAngle, minAngle, htPointTop);
			}
			else if (height > 0f)
			{
				areaInternal.method_7(graphicsPath3, 1f / 3f);
				chartPoint.BorderInternal.method_8(graphicsPath3);
				smethod_67(g, chartPoint, maxAngle, minAngle, htPointBottom);
			}
			else
			{
				areaInternal.method_7(graphicsPath2, 1f / 3f);
				chartPoint.BorderInternal.method_8(graphicsPath2);
			}
		}
		else
		{
			GraphicsPath graphicsPath4 = new GraphicsPath();
			graphicsPath4.AddLine(min.X, min.Y, max.X, max.Y);
			graphicsPath4.AddLine(min2.X, min2.Y, max2.X, max2.Y);
			chartPoint.BorderInternal.method_8(graphicsPath4);
		}
		if (height != 0f)
		{
			GraphicsPath graphicsPath5 = new GraphicsPath();
			graphicsPath5.StartFigure();
			graphicsPath5.AddLine(min.X, min.Y, min2.X, min2.Y);
			graphicsPath5.StartFigure();
			graphicsPath5.AddLine(max.X, max.Y, max2.X, max2.Y);
			chartPoint.BorderInternal.method_8(graphicsPath5);
		}
	}

	private static void smethod_65(Dictionary<int, PointF> htPoint, out PointF max, out PointF min, out int maxAngle, out int minAngle)
	{
		max = PointF.Empty;
		min = PointF.Empty;
		maxAngle = 0;
		minAngle = 0;
		IDictionaryEnumerator dictionaryEnumerator = htPoint.GetEnumerator();
		while (dictionaryEnumerator.MoveNext())
		{
			PointF pointF = (PointF)dictionaryEnumerator.Value;
			if (max == PointF.Empty || pointF.X > max.X)
			{
				max = pointF;
				maxAngle = (int)dictionaryEnumerator.Key;
			}
			if (min == PointF.Empty || pointF.X < min.X)
			{
				min = pointF;
				minAngle = (int)dictionaryEnumerator.Key;
			}
		}
	}

	internal static PointF[] smethod_66(ArrayList list, bool isRevered)
	{
		PointF[] array = new PointF[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			if (isRevered)
			{
				ref PointF reference = ref array[list.Count - 1 - i];
				reference = (PointF)list[i];
			}
			else
			{
				ref PointF reference2 = ref array[i];
				reference2 = (PointF)list[i];
			}
		}
		return array;
	}

	internal static void smethod_67(Interface32 g, Class748 chartPoint, int maxAngle, int minAngle, Dictionary<int, PointF> htPoint)
	{
		if (minAngle > maxAngle)
		{
			maxAngle += 360;
		}
		PointF[] array = new PointF[Math.Abs(maxAngle - minAngle + 1)];
		int num = 0;
		for (int i = minAngle; i <= maxAngle; i++)
		{
			ref PointF reference = ref array[num];
			reference = htPoint[i % 360];
			num++;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddCurve(array);
		chartPoint.BorderInternal.method_8(graphicsPath);
	}
}
