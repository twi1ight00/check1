using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns16;
using ns2;
using ns33;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct22
{
	internal static List<object[]> smethod_0(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisX, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.ClusteredBar;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		_ = nSeriesInternal.Count;
		int num;
		Class783 @class;
		Class783 class2;
		if (axisGroup == Enum141.const_0)
		{
			num = nSeriesInternal.method_7(Enum141.const_0, ChartType.ClusteredBar);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
		}
		else
		{
			num = nSeriesInternal.method_7(Enum141.const_1, ChartType.ClusteredBar);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
		}
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_4(g, chart, aSeries, rect, categoryAxisX, categoryAxisCrossAt, renderContext);
		}
		double logMaxValue = class2.LogMaxValue;
		double logMinValue = class2.LogMinValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		float num2 = (float)aSeries.Overlap / 100f;
		float num3 = (float)aSeries.GapWidth / 100f;
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
		double num5 = (double)rect.Height / (double)num4;
		float num6 = 0f;
		int num7 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
		if (num7 == -1)
		{
			return new List<object[]>();
		}
		int index = aSeries.Index;
		Class747 pointsInternal = aSeries.PointsInternal;
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			Class748 class3 = pointsInternal.method_0(i);
			float num8 = (float)num5 / ((float)num - num2 * (float)(num - 1) + num3);
			float num9 = num8 * num2;
			float num10 = num8 * num3;
			num6 = (float)num7 * (num8 - num9);
			float num11 = (float)num5 * (float)i + num10 / 2f + num6;
			if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
			{
				num11 -= (float)(num5 / 2.0);
			}
			num11 = (@class.Axis.IsPlotOrderReversed ? ((float)rect.Y + num11) : ((float)(rect.Y + rect.Height) - num11 - num8));
			if (class3 == null || class3.NotPlotted)
			{
				continue;
			}
			double yValue = class3.YValue;
			float num12 = (float)(categoryAxisCrossAt - yValue) / (float)(logMaxValue - logMinValue) * (float)rect.Width;
			bool flag = false;
			if (num12 == 0f)
			{
				flag = true;
			}
			Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
			PointF originPoint = new PointF(categoryAxisX, num11 + num8 / 2f);
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
				minusHeight = (float)num13 / (float)(logMaxValue - logMinValue) * (float)rect.Width;
				plusHeight = (float)num14 / (float)(logMaxValue - logMinValue) * (float)rect.Width;
				if (!class2.Axis.IsPlotOrderReversed)
				{
					originPoint.X -= num12;
				}
				else
				{
					originPoint.X += num12;
				}
			}
			yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
			float num16 = categoryAxisX;
			if (class2.Axis.IsPlotOrderReversed)
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
			RectangleF rectangleF = new RectangleF(num16, num11, num12 + 1f, num8);
			if (rectangleF.X < (float)rect.X)
			{
				rectangleF.Width -= (float)rect.X - rectangleF.X;
				rectangleF.X = rect.X;
			}
			if (rectangleF.Right > (float)(rect.Right + 1))
			{
				rectangleF.Width -= rectangleF.Right - (float)rect.Right;
			}
			if (!(rectangleF.Bottom >= (float)rect.Y) || !(rectangleF.Y <= (float)rect.Bottom))
			{
				continue;
			}
			if (rectangleF.Y < (float)rect.Y)
			{
				rectangleF.Height -= (float)rect.Y - rectangleF.Y;
				rectangleF.Y = rect.Y;
			}
			else if (rectangleF.Bottom > (float)rect.Bottom)
			{
				rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
			}
			if (rectangleF.Height + 1f >= (num8 - 1f) / 3f)
			{
				if (!flag)
				{
					smethod_1(g, class3, rectangleF, categoryAxisX);
				}
				object[] array = new object[4];
				bool flag2 = !(rectangleF.X < categoryAxisX) && (yValue != 0.0 || !class2.Axis.IsPlotOrderReversed);
				array[0] = index;
				array[1] = i;
				array[2] = rectangleF;
				array[3] = flag2;
				list.Add(array);
			}
		}
		return list;
	}

	private static void smethod_1(Interface32 g, Class748 point, RectangleF rectBar, float categoryAxisX)
	{
		Struct27.smethod_4(point);
		if (point.AreaInternal.Formatting != 0)
		{
			point.AreaInternal.method_5(rectBar);
		}
		rectBar.Width -= (float)point.BorderInternal.Width / 2f;
		rectBar.Height -= (float)point.BorderInternal.Width / 2f;
		point.BorderInternal.method_7(rectBar);
	}

	internal static void smethod_2(Interface32 g, Class740 chart, Rectangle plotRect, ArrayList paramOfDataLabels, Class784 renderContext)
	{
		if (!Struct41.smethod_21(plotRect))
		{
			Class757 nSeriesInternal = chart.NSeriesInternal;
			for (int i = 0; i < paramOfDataLabels.Count; i++)
			{
				object[] array = (object[])paramOfDataLabels[i];
				int num = (int)array[0];
				int chartPointIndex = (int)array[1];
				RectangleF rectPoint = (RectangleF)array[2];
				bool isAtCategoryAxisUp = (bool)array[3];
				Class759 @class = nSeriesInternal.method_0(num);
				Enum141 axisGroup = @class.AxisGroup;
				smethod_3(axisRenderContext: (axisGroup != Enum141.const_0) ? renderContext.X2AxisRenderContext : renderContext.X1AxisRenderContext, g: g, nSeries: nSeriesInternal, seriesIndex: num, chartPointIndex: chartPointIndex, rectPoint: rectPoint, isAtCategoryAxisUp: isAtCategoryAxisUp, scaleWidth: plotRect.Width, renderContext: renderContext);
			}
		}
	}

	private static void smethod_3(Interface32 g, Class757 nSeries, int seriesIndex, int chartPointIndex, RectangleF rectPoint, bool isAtCategoryAxisUp, int scaleWidth, Class784 renderContext, Class783 axisRenderContext)
	{
		nSeries.method_0(seriesIndex);
		Class750 dataLabelsInternal = nSeries.method_0(seriesIndex).PointsInternal.method_0(chartPointIndex).DataLabelsInternal;
		SizeF sizeF = Struct28.smethod_0(g, nSeries, seriesIndex, chartPointIndex, scaleWidth, renderContext, axisRenderContext);
		float num = 0f;
		float num2 = rectPoint.Y + (rectPoint.Height - sizeF.Height) / 2f;
		switch (dataLabelsInternal.LabelPosition)
		{
		default:
			if (isAtCategoryAxisUp)
			{
				num = rectPoint.X + rectPoint.Width;
				num += 5f;
			}
			else
			{
				num = rectPoint.X - sizeF.Width;
			}
			break;
		case LegendDataLabelPosition.Center:
			num = rectPoint.X + rectPoint.Width / 2f - sizeF.Width / 2f;
			break;
		case LegendDataLabelPosition.InsideBase:
			if (isAtCategoryAxisUp)
			{
				num = rectPoint.X;
				num += 5f;
			}
			else
			{
				num = rectPoint.X + rectPoint.Width - sizeF.Width;
			}
			break;
		case LegendDataLabelPosition.InsideEnd:
			if (isAtCategoryAxisUp)
			{
				num = rectPoint.X + rectPoint.Width - sizeF.Width;
				num += -1f;
			}
			else
			{
				num = rectPoint.X;
				num += 6f;
			}
			break;
		}
		if (isAtCategoryAxisUp)
		{
			if (num - (float)Struct28.int_0 < rectPoint.X)
			{
				num += rectPoint.X - (num - (float)Struct28.int_0);
			}
		}
		else if (num + (float)Struct28.int_0 + sizeF.Width > rectPoint.Right)
		{
			num -= num + (float)Struct28.int_0 + sizeF.Width - rectPoint.Right;
		}
		dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_5(num), Struct41.smethod_5(num2), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
		dataLabelsInternal.ChartFrameInternal.method_6();
		Struct28.smethod_1(g, nSeries, seriesIndex, chartPointIndex, dataLabelsInternal.ChartFrameInternal.rectangle_0, renderContext, axisRenderContext);
	}

	private static List<object[]> smethod_4(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisX, double categoryAxisCrossAt, Class784 renderContext)
	{
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.ClusteredBar;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		int num;
		List<int> list;
		Class783 @class;
		Class783 class2;
		if (axisGroup == Enum141.const_0)
		{
			num = nSeriesInternal.method_7(Enum141.const_0, ChartType.ClusteredBar);
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
		}
		else
		{
			num = nSeriesInternal.method_7(Enum141.const_1, ChartType.ClusteredBar);
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
		}
		double logMaxValue = class2.LogMaxValue;
		double logMinValue = class2.LogMinValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		float num2 = (float)aSeries.Overlap / 100f;
		float num3 = (float)aSeries.GapWidth / 100f;
		List<object[]> list2 = new List<object[]>();
		int count = list.Count;
		TimeUnitType baseUnitScale = @class.Axis.BaseUnitScale;
		int minValue = (int)@class.MinValue;
		int maxValue = (int)@class.MaxValue;
		int num4 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
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
		double num5 = (double)rect.Height / (double)num4;
		int num6 = 0;
		while (true)
		{
			if (num6 < count)
			{
				Class748 class3 = aSeries.PointsInternal.method_0(num6);
				float num7 = (float)(num5 / (double)((float)num - num2 * (float)(num - 1) + num3));
				float num8 = num7 * num2;
				float num9 = num7 * num3;
				int val = int.Parse(list[num6].ToString());
				val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
				int num10 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
				float num11 = (float)(num5 * (double)num10);
				if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
				{
					num11 -= (float)(num5 / 2.0);
				}
				float num12 = 0f;
				num12 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)(rect.Y + rect.Height) - num7 - num11 - num9 / 2f) : ((float)rect.Y + num11 + num9 / 2f));
				int num13 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
				if (num13 == -1)
				{
					break;
				}
				int index = aSeries.Index;
				num12 = ((!@class.Axis.IsPlotOrderReversed) ? (num12 - (float)num13 * (num7 - num8)) : (num12 + (float)num13 * (num7 - num8)));
				if (class3 != null && !class3.NotPlotted)
				{
					double yValue = class3.YValue;
					float num14 = (float)(categoryAxisCrossAt - yValue) / (float)(logMaxValue - logMinValue) * (float)rect.Width;
					bool flag = num14 == 0f;
					float num15 = categoryAxisX;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(categoryAxisX, num12 + num7 / 2f);
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
								num18 = ((yErrorBarInternal.MinusValue.Count > num6) ? Convert.ToDouble(yErrorBarInternal.MinusValue[num6]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num16 = num18;
							try
							{
								num18 = ((yErrorBarInternal.PlusValue.Count > num6) ? Convert.ToDouble(yErrorBarInternal.PlusValue[num6]) : 0.0);
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
						minusHeight = (float)num16 / (float)(logMaxValue - logMinValue) * (float)rect.Width;
						plusHeight = (float)num17 / (float)(logMaxValue - logMinValue) * (float)rect.Width;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							originPoint.X -= num14;
						}
						else
						{
							originPoint.X += num14;
						}
					}
					yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					if (!class2.Axis.IsPlotOrderReversed)
					{
						if (num14 < 0f)
						{
							num14 = 0f - num14;
						}
						else
						{
							num15 -= num14;
						}
					}
					else if (num14 < 0f)
					{
						num14 = 0f - num14;
						num15 -= num14;
					}
					RectangleF rectangleF = new RectangleF(num15, num12, num14 + 1f, num7);
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
						if (rectangleF.Height + 1f >= (num7 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_1(g, class3, rectangleF, categoryAxisX);
							}
							object[] array = new object[4];
							bool flag2 = !(rectangleF.X < categoryAxisX) && (yValue != 0.0 || ((!class2.Axis.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num6;
							array[2] = rectangleF;
							array[3] = flag2;
							list2.Add(array);
						}
					}
				}
				num6++;
				continue;
			}
			return list2;
		}
		return new List<object[]>();
	}

	internal static List<object[]> smethod_5(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, int maxPointsCount, Class784 renderContext)
	{
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.StackedBar;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		_ = nSeriesInternal.Count;
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
		float num2 = 0f;
		num2 = ((!class2.Axis.IsPlotOrderReversed) ? ((float)rect.Right - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width) : ((float)rect.X + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width));
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_7(g, chart, aSeries, rect, num2, renderContext);
		}
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
		double num6 = (double)rect.Height / (double)num5;
		float num7 = 0f;
		List<Class759> list2 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
		int num8 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
		if (num8 == -1)
		{
			return new List<object[]>();
		}
		int index = aSeries.Index;
		Class747 pointsInternal = aSeries.PointsInternal;
		List<ValueType> previous = new List<ValueType>();
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
			num12 = (@class.Axis.IsPlotOrderReversed ? ((float)rect.Y + num12) : ((float)(rect.Y + rect.Height) - num12 - num9));
			List<ValueType> list3 = new List<ValueType>();
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
				float num14 = (float)Math.Abs(yValue) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
				float num15 = (float)Math.Abs(num13) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
				bool flag = num14 == 0f;
				Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
				PointF originPoint = new PointF(num2, num12 + num9 / 2f);
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
					minusHeight = (float)num16 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
					plusHeight = (float)num17 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
					if (!class2.Axis.IsPlotOrderReversed)
					{
						if (yValue <= 0.0)
						{
							originPoint.X -= num15;
						}
						else
						{
							originPoint.X += num15;
						}
					}
					else if (yValue <= 0.0)
					{
						originPoint.X += num15;
					}
					else
					{
						originPoint.X -= num15;
					}
				}
				yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
				num15 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue >= 0.0)) ? (num2 - num15) : (num2 + num15 - num14)) : ((!(yValue >= 0.0)) ? (num2 + num15 - num14) : (num2 - num15)));
				RectangleF rectangleF = new RectangleF(num15, num12, num14, num9);
				if (rectangleF.X < (float)rect.X)
				{
					rectangleF.Width -= (float)rect.X - rectangleF.X;
					rectangleF.X = rect.X;
				}
				if (rectangleF.Right > (float)(rect.Right + 1))
				{
					rectangleF.Width -= rectangleF.Right - (float)rect.Right;
				}
				if (rectangleF.Bottom >= (float)rect.Y && rectangleF.Y <= (float)rect.Bottom)
				{
					if (rectangleF.Y < (float)rect.Y)
					{
						rectangleF.Height -= (float)rect.Y - rectangleF.Y;
						rectangleF.Y = rect.Y;
					}
					else if (rectangleF.Bottom > (float)rect.Bottom)
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
					}
					if (rectangleF.Height + 1f >= (num9 - 1f) / 3f)
					{
						if (!flag)
						{
							smethod_1(g, class3, rectangleF, num2);
						}
						object[] array = new object[4];
						bool flag2 = !(rectangleF.X + rectangleF.Width / 2f < num2) && (yValue != 0.0 || ((!class2.Axis.IsPlotOrderReversed) ? true : false));
						array[0] = index;
						array[1] = i;
						array[2] = rectangleF;
						array[3] = flag2;
						if (!flag)
						{
							list.Add(array);
						}
						if (aSeries.HasSeriesLines)
						{
							list3.Add(rectangleF);
							list3.Add(flag2);
						}
					}
				}
			}
			smethod_6(g, aSeries, ref previous, list3);
		}
		return list;
	}

	private static void smethod_6(Interface32 g, Class759 aSeries, ref List<ValueType> previous, List<ValueType> current)
	{
		if (previous.Count > 0 && current.Count > 0 && aSeries.HasSeriesLines)
		{
			RectangleF rectangleF = (RectangleF)(object)previous[0];
			bool flag = (bool)(object)previous[1];
			RectangleF rectangleF2 = (RectangleF)(object)current[0];
			bool flag2 = (bool)(object)current[1];
			PointF point;
			PointF point2;
			if (!(rectangleF.Y < rectangleF2.Y))
			{
				point = ((!flag) ? new PointF(rectangleF.Left, rectangleF.Top) : new PointF(rectangleF.Right, rectangleF.Top));
				point2 = ((!flag2) ? new PointF(rectangleF2.Left, rectangleF2.Bottom) : new PointF(rectangleF2.Right, rectangleF2.Bottom));
			}
			else
			{
				point = ((!flag) ? new PointF(rectangleF.Left, rectangleF.Bottom) : new PointF(rectangleF.Right, rectangleF.Bottom));
				point2 = ((!flag2) ? new PointF(rectangleF2.Left, rectangleF2.Top) : new PointF(rectangleF2.Right, rectangleF2.Top));
			}
			aSeries.SeriesLinesInternal.method_5(point, point2);
		}
		if (current.Count > 0)
		{
			previous = current;
		}
	}

	private static List<object[]> smethod_7(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisX, Class784 renderContext)
	{
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.StackedBar;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		int num;
		Class783 @class;
		Class783 class2;
		List<int> list;
		if (axisGroup == Enum141.const_0)
		{
			num = nSeriesInternal.method_7(Enum141.const_0, chartType);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			num = nSeriesInternal.method_7(Enum141.const_1, chartType);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		float num2 = (float)aSeries.Overlap / 100f;
		float num3 = (float)aSeries.GapWidth / 100f;
		List<object[]> list2 = new List<object[]>();
		int count = list.Count;
		TimeUnitType baseUnitScale = @class.Axis.BaseUnitScale;
		int minValue = (int)@class.MinValue;
		int maxValue = (int)@class.MaxValue;
		int num4 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
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
		double num5 = (double)rect.Height / (double)num4;
		List<ValueType> previous = new List<ValueType>();
		int num6 = 0;
		while (true)
		{
			if (num6 < count)
			{
				Class748 class3 = aSeries.PointsInternal.method_0(num6);
				float num7 = (float)(num5 / (double)((float)num - num2 * (float)(num - 1) + num3));
				float num8 = num7 * num2;
				float num9 = num7 * num3;
				int val = int.Parse(list[num6].ToString());
				val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
				int num10 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
				float num11 = (float)(num5 * (double)num10);
				if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
				{
					num11 -= (float)(num5 / 2.0);
				}
				float num12 = 0f;
				num12 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)(rect.Y + rect.Height) - num7 - num11 - num9 / 2f) : ((float)rect.Y + num11 + num9 / 2f));
				List<Class759> list3 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
				int num13 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
				if (num13 == -1)
				{
					break;
				}
				int index = aSeries.Index;
				num12 = ((!@class.Axis.IsPlotOrderReversed) ? (num12 - (float)num13 * (num7 - num8)) : (num12 + (float)num13 * (num7 - num8)));
				List<ValueType> list4 = new List<ValueType>();
				if (class3 != null)
				{
					double yValue = class3.YValue;
					double num14 = yValue;
					if (yValue >= 0.0)
					{
						for (int i = 0; i < num13; i++)
						{
							Class748 class4 = list3[i].PointsInternal.method_0(num6);
							if (class4 != null)
							{
								double yValue2 = class4.YValue;
								if (yValue2 > 0.0)
								{
									num14 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < num13; j++)
						{
							Class748 class5 = list3[j].PointsInternal.method_0(num6);
							if (class5 != null)
							{
								double yValue3 = class5.YValue;
								if (yValue3 <= 0.0)
								{
									num14 += yValue3;
								}
							}
						}
					}
					float num15 = (float)Math.Abs(yValue) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
					float num16 = (float)Math.Abs(num14) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
					bool flag = num15 == 0f;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(categoryAxisX, num12 + num7 / 2f);
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
								num19 = ((yErrorBarInternal.MinusValue.Count > num6) ? Convert.ToDouble(yErrorBarInternal.MinusValue[num6]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num17 = num19;
							try
							{
								num19 = ((yErrorBarInternal.PlusValue.Count > num6) ? Convert.ToDouble(yErrorBarInternal.PlusValue[num6]) : 0.0);
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
						minusHeight = (float)num17 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
						plusHeight = (float)num18 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							if (yValue <= 0.0)
							{
								originPoint.X -= num16;
							}
							else
							{
								originPoint.X += num16;
							}
						}
						else if (yValue <= 0.0)
						{
							originPoint.X += num16;
						}
						else
						{
							originPoint.X -= num16;
						}
					}
					yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					num16 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue >= 0.0)) ? (categoryAxisX - num16) : (categoryAxisX + num16 - num15)) : ((!(yValue >= 0.0)) ? (categoryAxisX + num16 - num15) : (categoryAxisX - num16)));
					RectangleF rectangleF = new RectangleF(num16, num12, num15, num7);
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
						if (rectangleF.Height + 1f >= (num7 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_1(g, class3, rectangleF, categoryAxisX);
							}
							object[] array = new object[4];
							bool flag2 = !(rectangleF.X + rectangleF.Width / 2f < categoryAxisX) && (yValue != 0.0 || ((!class2.Axis.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num6;
							array[2] = rectangleF;
							array[3] = flag2;
							if (!flag)
							{
								list2.Add(array);
							}
							if (aSeries.HasSeriesLines)
							{
								list4.Add(rectangleF);
								list4.Add(flag2);
							}
						}
					}
				}
				smethod_6(g, aSeries, ref previous, list4);
				num6++;
				continue;
			}
			return list2;
		}
		return new List<object[]>();
	}

	internal static List<object[]> smethod_8(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, int maxPointsCount, Class784 renderContext)
	{
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.PercentsStackedBar;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		_ = nSeriesInternal.Count;
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
		float num2 = 0f;
		num2 = ((!class2.Axis.IsPlotOrderReversed) ? ((float)rect.Right - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width) : ((float)rect.X + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width));
		if (@class.Axis != null && @class.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return smethod_9(g, chart, aSeries, rect, num2, renderContext);
		}
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
		double num6 = (double)rect.Height / (double)num5;
		float num7 = 0f;
		List<Class759> list2 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
		int num8 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
		if (num8 == -1)
		{
			return new List<object[]>();
		}
		int index = aSeries.Index;
		Class747 pointsInternal = aSeries.PointsInternal;
		List<ValueType> previous = new List<ValueType>();
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
			num12 = (@class.Axis.IsPlotOrderReversed ? ((float)rect.Y + num12) : ((float)(rect.Y + rect.Height) - num12 - num9));
			List<ValueType> list3 = new List<ValueType>();
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
				if (num14 == 0.0)
				{
					continue;
				}
				float num15 = (float)Math.Abs(yValue) * 100f / (float)num14 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
				float num16 = (float)Math.Abs(num13) * 100f / (float)num14 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
				bool flag = num15 == 0f;
				Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
				PointF originPoint = new PointF(num2, num12 + num9 / 2f);
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
					minusHeight = (float)num17 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
					plusHeight = (float)num18 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
					if (!class2.Axis.IsPlotOrderReversed)
					{
						if (yValue <= 0.0)
						{
							originPoint.X -= num16;
						}
						else
						{
							originPoint.X += num16;
						}
					}
					else if (yValue <= 0.0)
					{
						originPoint.X += num16;
					}
					else
					{
						originPoint.X -= num16;
					}
				}
				yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
				num16 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue >= 0.0)) ? (num2 - num16) : (num2 + num16 - num15)) : ((!(yValue >= 0.0)) ? (num2 + num16 - num15) : (num2 - num16)));
				RectangleF rectangleF = new RectangleF(num16, num12, num15, num9);
				if (rectangleF.X < (float)rect.X)
				{
					rectangleF.Width -= (float)rect.X - rectangleF.X;
					rectangleF.X = rect.X;
				}
				if (rectangleF.Right > (float)(rect.Right + 1))
				{
					rectangleF.Width -= rectangleF.Right - (float)rect.Right;
				}
				if (rectangleF.Bottom >= (float)rect.Y && rectangleF.Y <= (float)rect.Bottom)
				{
					if (rectangleF.Y < (float)rect.Y)
					{
						rectangleF.Height -= (float)rect.Y - rectangleF.Y;
						rectangleF.Y = rect.Y;
					}
					else if (rectangleF.Bottom > (float)rect.Bottom)
					{
						rectangleF.Height -= rectangleF.Bottom - (float)rect.Bottom;
					}
					if (rectangleF.Height + 1f >= (num9 - 1f) / 3f)
					{
						if (!flag)
						{
							smethod_1(g, class3, rectangleF, num2);
						}
						object[] array = new object[4];
						bool flag2 = !(rectangleF.X + rectangleF.Width / 2f < num2) && (yValue != 0.0 || ((!class2.Axis.IsPlotOrderReversed) ? true : false));
						array[0] = index;
						array[1] = i;
						array[2] = rectangleF;
						array[3] = flag2;
						if (!flag)
						{
							list.Add(array);
						}
						if (aSeries.HasSeriesLines)
						{
							list3.Add(rectangleF);
							list3.Add(flag2);
						}
					}
				}
			}
			smethod_6(g, aSeries, ref previous, list3);
		}
		return list;
	}

	private static List<object[]> smethod_9(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisX, Class784 renderContext)
	{
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.PercentsStackedBar;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		int num;
		Class783 @class;
		Class783 class2;
		List<int> list;
		if (axisGroup == Enum141.const_0)
		{
			num = nSeriesInternal.method_7(Enum141.const_0, chartType);
			@class = renderContext.X1AxisRenderContext;
			class2 = renderContext.Y1AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			num = nSeriesInternal.method_7(Enum141.const_1, chartType);
			@class = renderContext.X2AxisRenderContext;
			class2 = renderContext.Y2AxisRenderContext;
			list = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		float num2 = (float)aSeries.Overlap / 100f;
		float num3 = (float)aSeries.GapWidth / 100f;
		List<object[]> list2 = new List<object[]>();
		int count = list.Count;
		TimeUnitType baseUnitScale = @class.Axis.BaseUnitScale;
		int minValue = (int)@class.MinValue;
		int maxValue = (int)@class.MaxValue;
		int num4 = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
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
		double num5 = (double)rect.Height / (double)num4;
		List<ValueType> previous = new List<ValueType>();
		int num6 = 0;
		while (true)
		{
			if (num6 < count)
			{
				Class748 class3 = aSeries.PointsInternal.method_0(num6);
				float num7 = (float)(num5 / (double)((float)num - num2 * (float)(num - 1) + num3));
				float num8 = num7 * num2;
				float num9 = num7 * num3;
				int val = int.Parse(list[num6].ToString());
				val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
				int num10 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
				float num11 = (float)(num5 * (double)num10);
				if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
				{
					num11 -= (float)(num5 / 2.0);
				}
				float num12 = 0f;
				num12 = ((!@class.Axis.IsPlotOrderReversed) ? ((float)(rect.Y + rect.Height) - num7 - num11 - num9 / 2f) : ((float)rect.Y + num11 + num9 / 2f));
				List<Class759> list3 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
				int num13 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
				if (num13 == -1)
				{
					break;
				}
				int index = aSeries.Index;
				num12 = ((!@class.Axis.IsPlotOrderReversed) ? (num12 - (float)num13 * (num7 - num8)) : (num12 + (float)num13 * (num7 - num8)));
				List<ValueType> list4 = new List<ValueType>();
				if (class3 != null)
				{
					double yValue = class3.YValue;
					double num14 = yValue;
					double num15 = 0.0;
					if (yValue >= 0.0)
					{
						for (int i = 0; i < num13; i++)
						{
							Class748 class4 = list3[i].PointsInternal.method_0(num6);
							if (class4 != null)
							{
								double yValue2 = class4.YValue;
								if (yValue2 > 0.0)
								{
									num14 += yValue2;
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < num13; j++)
						{
							Class748 class5 = list3[j].PointsInternal.method_0(num6);
							if (class5 != null)
							{
								double yValue3 = class5.YValue;
								if (yValue3 <= 0.0)
								{
									num14 += yValue3;
								}
							}
						}
					}
					for (int k = 0; k < list3.Count; k++)
					{
						Class748 class6 = list3[k].PointsInternal.method_0(num6);
						if (class6 != null)
						{
							double yValue4 = class6.YValue;
							num15 += Math.Abs(yValue4);
						}
					}
					if (num15 == 0.0)
					{
						goto IL_0862;
					}
					float num16 = (float)Math.Abs(yValue) * 100f / (float)num15 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
					float num17 = (float)Math.Abs(num14) * 100f / (float)num15 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
					bool flag = num16 == 0f;
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
					PointF originPoint = new PointF(categoryAxisX, num12 + num7 / 2f);
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
								num20 = ((yErrorBarInternal.MinusValue.Count > num6) ? Convert.ToDouble(yErrorBarInternal.MinusValue[num6]) : 0.0);
							}
							catch (Exception ex)
							{
								Class1165.smethod_28(ex);
							}
							num18 = num20;
							try
							{
								num20 = ((yErrorBarInternal.PlusValue.Count > num6) ? Convert.ToDouble(yErrorBarInternal.PlusValue[num6]) : 0.0);
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
						num19 = num19 * 100.0 / num15;
						num18 = num18 * 100.0 / num15;
						minusHeight = (float)num18 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
						plusHeight = (float)num19 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Width;
						if (!class2.Axis.IsPlotOrderReversed)
						{
							if (yValue <= 0.0)
							{
								originPoint.X -= num17;
							}
							else
							{
								originPoint.X += num17;
							}
						}
						else if (yValue <= 0.0)
						{
							originPoint.X += num17;
						}
						else
						{
							originPoint.X -= num17;
						}
					}
					yErrorBarInternal.method_0(originPoint, minusHeight, plusHeight);
					num17 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(yValue >= 0.0)) ? (categoryAxisX - num17) : (categoryAxisX + num17 - num16)) : ((!(yValue >= 0.0)) ? (categoryAxisX + num17 - num16) : (categoryAxisX - num17)));
					RectangleF rectangleF = new RectangleF(num17, num12, num16, num7);
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
						if (rectangleF.Height + 1f >= (num7 - 1f) / 3f)
						{
							if (!flag)
							{
								smethod_1(g, class3, rectangleF, categoryAxisX);
							}
							object[] array = new object[4];
							bool flag2 = !(rectangleF.X + rectangleF.Width / 2f < categoryAxisX) && (yValue != 0.0 || ((!class2.Axis.IsPlotOrderReversed) ? true : false));
							array[0] = index;
							array[1] = num6;
							array[2] = rectangleF;
							array[3] = flag2;
							if (!flag)
							{
								list2.Add(array);
							}
							if (aSeries.HasSeriesLines)
							{
								list4.Add(rectangleF);
								list4.Add(flag2);
							}
						}
					}
				}
				smethod_6(g, aSeries, ref previous, list4);
				goto IL_0862;
			}
			return list2;
			IL_0862:
			num6++;
		}
		return new List<object[]>();
	}

	internal static void smethod_10(Interface32 g, Class740 chart, float categoryAxisX, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		int count = nSeriesInternal.Count;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_11(g, chart, categoryAxisX, categoryAxisCrossAt, renderContext);
			return;
		}
		List<object[]> list = new List<object[]>();
		float num = chart.WallsInternal.Height / (float)maxPointsCount;
		float num2 = chart.WallsInternal.method_0(isBar: true, maxPointsCount, count);
		float num3 = chart.WallsInternal.method_1();
		float num4 = num2 * (float)chart.GapWidth / 100f;
		for (int i = 0; i < maxPointsCount; i++)
		{
			List<Class759> list2 = nSeriesInternal.method_9();
			if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
			{
				list2.Reverse();
			}
			for (int j = 0; j < list2.Count; j++)
			{
				Class759 @class = list2[j];
				int index = @class.Index;
				float num5 = (float)j * num2;
				float num6 = num * (float)i + num4 / 2f + num5;
				num6 = chart.WallsInternal.Y - num6;
				Class747 pointsInternal = @class.PointsInternal;
				int num7 = i;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num7 = maxPointsCount - 1 - num7;
				}
				Class748 class2 = pointsInternal.method_0(num7);
				if (class2 != null && !class2.NotPlotted)
				{
					double num8 = y1AxisRenderContext.method_2(class2.YValue);
					float num9 = (float)(num8 - categoryAxisCrossAt) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num9 = 0f - num9;
					}
					smethod_20(g, class2, chart, num6, num2, num3, categoryAxisX, num9, double.NaN, renderContext);
					PointF pointF = smethod_17(chart, num6, num2, num3, categoryAxisX, num9);
					list.Add(new object[3] { index, num7, pointF });
				}
			}
		}
		smethod_19(g, chart, list, renderContext);
	}

	private static void smethod_11(Interface32 g, Class740 chart, float categoryAxisX, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class764 wallsInternal = chart.WallsInternal;
		int count = nSeriesInternal.Count;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		List<object[]> list = new List<object[]>();
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int minValue = (int)x1AxisRenderContext.MinValue;
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int num = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		float num2 = wallsInternal.Height / (float)num;
		float num3 = chart.WallsInternal.method_0(isBar: true, num, count);
		float num4 = chart.WallsInternal.method_1();
		float num5 = num3 * (float)chart.GapWidth / 100f;
		List<int> list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count2 = list2.Count;
		for (int i = 0; i < count2; i++)
		{
			int val = int.Parse(list2[i].ToString());
			val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
			int num6 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
			float num7 = num2 * (float)num6;
			float num8 = num7 + num5 / 2f;
			num8 = chart.WallsInternal.Y - num8 + num3;
			IList list3 = nSeriesInternal.method_9();
			for (int j = 0; j < list3.Count; j++)
			{
				Class759 @class = (Class759)list3[j];
				int index = @class.Index;
				float num9 = num3;
				num8 -= num9;
				Class747 pointsInternal = @class.PointsInternal;
				int num10 = i;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num10 = count2 - 1 - num10;
				}
				Class748 class2 = pointsInternal.method_0(num10);
				if (class2 != null && !class2.NotPlotted)
				{
					double num11 = y1AxisRenderContext.method_2(class2.YValue);
					float num12 = (float)(num11 - categoryAxisCrossAt) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num12 = 0f - num12;
					}
					smethod_20(g, class2, chart, num8, num3, num4, categoryAxisX, num12, double.NaN, renderContext);
					PointF pointF = smethod_17(chart, num8, num3, num4, categoryAxisX, num12);
					list.Add(new object[3] { index, num10, pointF });
				}
			}
		}
		smethod_19(g, chart, list, renderContext);
	}

	internal static void smethod_12(Interface32 g, Class740 chart, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		float num = 0f;
		num = ((!y1AxisRenderContext.Axis.IsPlotOrderReversed) ? (chart.WallsInternal.X + chart.WallsInternal.Width - (float)y1AxisRenderContext.MaxValue / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width) : (chart.WallsInternal.X + (float)Math.Abs(y1AxisRenderContext.MaxValue / (double)(float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue)) * chart.WallsInternal.Width));
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_13(g, chart, num, categoryAxisCrossAt, renderContext);
			return;
		}
		List<object[]> list = new List<object[]>();
		float num2 = chart.WallsInternal.Height / (float)maxPointsCount;
		float num3 = chart.WallsInternal.method_0(isBar: true, maxPointsCount, 1);
		float num4 = chart.WallsInternal.method_1();
		float num5 = num3 * (float)chart.GapWidth / 100f;
		for (int i = 0; i < maxPointsCount; i++)
		{
			List<object[]> list2 = new List<object[]>();
			IList list3 = nSeriesInternal.method_9();
			for (int j = 0; j < list3.Count; j++)
			{
				Class759 @class = (Class759)list3[j];
				int index = @class.Index;
				float num6 = num2 * (float)i + num5 / 2f;
				num6 = chart.WallsInternal.Y - num6;
				Class747 pointsInternal = @class.PointsInternal;
				int num7 = i;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num7 = maxPointsCount - 1 - num7;
				}
				Class748 class2 = pointsInternal.method_0(num7);
				int displayOrder = j;
				if (class2 == null || class2.NotPlotted)
				{
					continue;
				}
				double pointVal = class2.YValue;
				if (!Struct41.smethod_16(ref pointVal, out var valTotal, list3, displayOrder, num7, y1AxisRenderContext.MaxValue, y1AxisRenderContext.MinValue))
				{
					continue;
				}
				float num8 = (float)pointVal / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
				float num9 = (float)valTotal / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
				float num10;
				if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num10 = num - (num9 - num8);
					num8 = 0f - num8;
				}
				else
				{
					num10 = num + (num9 - num8);
					if (num10 < chart.WallsInternal.X)
					{
						num8 -= chart.WallsInternal.X - num10;
						num10 = chart.WallsInternal.X;
					}
				}
				smethod_16(aParamOfColumns: new object[5] { class2, num6, num10, num8, valTotal }, val: pointVal, paramOfColumns: list2, axisRenderContext: y1AxisRenderContext);
				PointF pointF = smethod_18(chart, num6, num3, num4, num10, num8);
				list.Add(new object[3] { index, num7, pointF });
			}
			for (int k = 0; k < list2.Count; k++)
			{
				object[] array = list2[k];
				Class748 chartPoint = (Class748)array[0];
				smethod_20(g, chartPoint, chart, (float)array[1], num3, num4, (float)array[2], (float)array[3], (double)array[4], renderContext);
			}
			list2.Clear();
		}
		smethod_19(g, chart, list, renderContext);
	}

	private static void smethod_13(Interface32 g, Class740 chart, float categoryAxisX, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		List<object[]> list = new List<object[]>();
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int minValue = (int)x1AxisRenderContext.MinValue;
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int num = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		float num2 = chart.WallsInternal.Height / (float)num;
		float num3 = chart.WallsInternal.method_0(isBar: true, num, 1);
		float num4 = chart.WallsInternal.method_1();
		float num5 = num3 * (float)chart.GapWidth / 100f;
		List<int> list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			List<object[]> list3 = new List<object[]>();
			int val = int.Parse(list2[i].ToString());
			val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
			int num6 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
			float num7 = num2 * (float)num6;
			float num8 = num7 + num5 / 2f;
			num8 = chart.WallsInternal.Y - num8;
			IList list4 = nSeriesInternal.method_9();
			for (int j = 0; j < list4.Count; j++)
			{
				Class759 @class = (Class759)list4[j];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				int num9 = i;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num9 = count - 1 - num9;
				}
				Class748 class2 = pointsInternal.method_0(num9);
				int displayOrder = j;
				if (class2 == null || class2.NotPlotted)
				{
					continue;
				}
				double pointVal = class2.YValue;
				if (Struct41.smethod_16(ref pointVal, out var valTotal, list4, displayOrder, num9, y1AxisRenderContext.MaxValue, y1AxisRenderContext.MinValue))
				{
					float num10 = (float)pointVal / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
					float num11 = (float)valTotal / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
					float num12;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num12 = categoryAxisX - (num11 - num10);
						num10 = 0f - num10;
					}
					else
					{
						num12 = categoryAxisX + (num11 - num10);
					}
					smethod_16(aParamOfColumns: new object[5] { class2, num8, num12, num10, valTotal }, val: pointVal, paramOfColumns: list3, axisRenderContext: y1AxisRenderContext);
					PointF pointF = smethod_18(chart, num8, num3, num4, num12, num10);
					list.Add(new object[3] { index, num9, pointF });
				}
			}
			for (int k = 0; k < list3.Count; k++)
			{
				object[] array = list3[k];
				Class748 chartPoint = (Class748)array[0];
				smethod_20(g, chartPoint, chart, (float)array[1], num3, num4, (float)array[2], (float)array[3], (double)array[4], renderContext);
			}
			list3.Clear();
		}
		smethod_19(g, chart, list, renderContext);
	}

	internal static void smethod_14(Interface32 g, Class740 chart, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		float num = 0f;
		num = ((!y1AxisRenderContext.Axis.IsPlotOrderReversed) ? (chart.WallsInternal.X + (float)Math.Abs(y1AxisRenderContext.MinValue / (double)(float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue)) * chart.WallsInternal.Width) : (chart.WallsInternal.X + (float)Math.Abs(y1AxisRenderContext.MaxValue / (double)(float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue)) * chart.WallsInternal.Width));
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_15(g, chart, num, categoryAxisCrossAt, renderContext);
			return;
		}
		List<object[]> list = new List<object[]>();
		float num2 = chart.WallsInternal.Height / (float)maxPointsCount;
		float num3 = chart.WallsInternal.method_0(isBar: true, maxPointsCount, 1);
		float num4 = chart.WallsInternal.method_1();
		float num5 = num3 * (float)chart.GapWidth / 100f;
		for (int i = 0; i < maxPointsCount; i++)
		{
			List<object[]> list2 = new List<object[]>();
			IList list3 = nSeriesInternal.method_9();
			for (int j = 0; j < list3.Count; j++)
			{
				Class759 @class = (Class759)list3[j];
				int index = @class.Index;
				float num6 = num2 * (float)i + num5 / 2f;
				num6 = chart.WallsInternal.Y - num6;
				Class747 pointsInternal = @class.PointsInternal;
				int num7 = i;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num7 = maxPointsCount - 1 - num7;
				}
				Class748 class2 = pointsInternal.method_0(num7);
				int displayOrder = j;
				if (class2 == null || class2.NotPlotted)
				{
					continue;
				}
				double num8 = Struct41.smethod_17(list3, num7);
				if (num8 == 0.0)
				{
					continue;
				}
				double pointVal = class2.YValue;
				double valTotal = pointVal;
				if (Struct41.smethod_18(ref pointVal, out valTotal, list3, displayOrder, num7, num8, y1AxisRenderContext))
				{
					float num9 = (float)pointVal * 100f / (float)num8 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
					float num10 = (float)valTotal * 100f / (float)num8 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
					float num11;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num11 = num - (num10 - num9);
						num9 = 0f - num9;
					}
					else
					{
						num11 = num + (num10 - num9);
					}
					smethod_16(aParamOfColumns: new object[5] { class2, num6, num11, num9, valTotal }, val: pointVal, paramOfColumns: list2, axisRenderContext: y1AxisRenderContext);
					PointF pointF = smethod_18(chart, num6, num3, num4, num11, num9);
					list.Add(new object[3] { index, num7, pointF });
				}
			}
			for (int k = 0; k < list2.Count; k++)
			{
				object[] array = list2[k];
				Class748 chartPoint = (Class748)array[0];
				smethod_20(g, chartPoint, chart, (float)array[1], num3, num4, (float)array[2], (float)array[3], (double)array[4], renderContext);
			}
			list2.Clear();
		}
		smethod_19(g, chart, list, renderContext);
	}

	private static void smethod_15(Interface32 g, Class740 chart, float categoryAxisX, double categoryAxisCrossAt, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		List<object[]> list = new List<object[]>();
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int minValue = (int)x1AxisRenderContext.MinValue;
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int num = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		float num2 = chart.WallsInternal.Height / (float)num;
		float num3 = chart.WallsInternal.method_0(isBar: true, num, 1);
		float num4 = chart.WallsInternal.method_1();
		float num5 = num3 * (float)chart.GapWidth / 100f;
		List<int> list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			List<object[]> list3 = new List<object[]>();
			int val = int.Parse(list2[i].ToString());
			val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
			int num6 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
			float num7 = num2 * (float)num6;
			float num8 = num7 + num5 / 2f;
			num8 = chart.WallsInternal.Y - num8;
			IList list4 = nSeriesInternal.method_9();
			for (int j = 0; j < list4.Count; j++)
			{
				Class759 @class = (Class759)list4[j];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				int num9 = i;
				if (x1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num9 = count - 1 - num9;
				}
				Class748 class2 = pointsInternal.method_0(num9);
				int displayOrder = j;
				if (class2 == null || class2.NotPlotted)
				{
					continue;
				}
				double num10 = Struct41.smethod_17(list4, num9);
				if (num10 == 0.0)
				{
					continue;
				}
				double pointVal = class2.YValue;
				double valTotal = pointVal;
				if (Struct41.smethod_18(ref pointVal, out valTotal, list4, displayOrder, num9, num10, y1AxisRenderContext))
				{
					float num11 = (float)pointVal * 100f / (float)num10 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
					float num12 = (float)valTotal * 100f / (float)num10 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Width;
					float num13;
					if (y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num13 = categoryAxisX - (num12 - num11);
						num11 = 0f - num11;
					}
					else
					{
						num13 = categoryAxisX + (num12 - num11);
					}
					smethod_16(aParamOfColumns: new object[5] { class2, num8, num13, num11, valTotal }, val: pointVal, paramOfColumns: list3, axisRenderContext: y1AxisRenderContext);
					PointF pointF = smethod_18(chart, num8, num3, num4, num13, num11);
					list.Add(new object[3] { index, num9, pointF });
				}
			}
			for (int k = 0; k < list3.Count; k++)
			{
				object[] array = list3[k];
				Class748 chartPoint = (Class748)array[0];
				smethod_20(g, chartPoint, chart, (float)array[1], num3, num4, (float)array[2], (float)array[3], (double)array[4], renderContext);
			}
			list3.Clear();
		}
		smethod_19(g, chart, list, renderContext);
	}

	private static void smethod_16(double val, object[] aParamOfColumns, List<object[]> paramOfColumns, Class783 axisRenderContext)
	{
		float num = (float)aParamOfColumns[2] + (float)aParamOfColumns[3];
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
			float num3 = (float)array[2] + (float)array[3];
			if (num >= num3)
			{
				if (num != num3)
				{
					if (num2 == paramOfColumns.Count - 1)
					{
						break;
					}
					num2++;
					continue;
				}
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
			paramOfColumns.Insert(num2, aParamOfColumns);
			return;
		}
		paramOfColumns.Add(aParamOfColumns);
	}

	private static PointF smethod_17(Class740 chart, float shapeY, float shapeWidth, float shapeDepth, float categoryAxisX, float height)
	{
		float num = categoryAxisX + height;
		float xCenter = chart.WallsInternal.xCenter;
		PointF pointF;
		if (num <= xCenter)
		{
			float wallsWidth = 2f * (xCenter - num);
			int order = ((!(categoryAxisX > num)) ? 3 : 0);
			pointF = Struct27.smethod_47(chart, shapeY, wallsWidth, shapeDepth, order);
		}
		else
		{
			int order = ((categoryAxisX > num) ? 1 : 2);
			float wallsWidth = 2f * (num - xCenter);
			pointF = Struct27.smethod_47(chart, shapeY, wallsWidth, shapeDepth, order);
		}
		PointF pointF2 = Struct27.smethod_47(chart, shapeY, 1f, shapeDepth, 0);
		float num2 = shapeDepth * (float)Math.Sin((double)chart.Elevation * Math.PI / 180.0);
		return new PointF(pointF.X, pointF2.Y - (shapeWidth + num2) / 2f);
	}

	private static PointF smethod_18(Class740 chart, float shapeY, float shapeWidth, float shapeDepth, float x, float height)
	{
		x += height / 2f;
		float xCenter = chart.WallsInternal.xCenter;
		float wallsWidth;
		if (x <= xCenter)
		{
			wallsWidth = 2f * (xCenter - x);
			return Struct27.smethod_47(chart, shapeY - shapeWidth / 2f, wallsWidth, shapeDepth, 0);
		}
		wallsWidth = 2f * (x - xCenter);
		return Struct27.smethod_47(chart, shapeY - shapeWidth / 2f, wallsWidth, shapeDepth, 1);
	}

	private static void smethod_19(Interface32 g, Class740 chart, List<object[]> paramOfDataLabels, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		for (int i = 0; i < paramOfDataLabels.Count; i++)
		{
			object[] array = paramOfDataLabels[i];
			int seriesIndex = (int)array[0];
			int chartPointIndex = (int)array[1];
			PointF pointF = (PointF)array[2];
			SizeF sizeF = Struct28.smethod_0(g, nSeriesInternal, seriesIndex, chartPointIndex, (int)chart.WallsInternal.Width, renderContext, renderContext.X1AxisRenderContext);
			RectangleF rect = new RectangleF(pointF.X - sizeF.Width / 2f, pointF.Y - sizeF.Height / 2f, sizeF.Width, sizeF.Height);
			Struct28.smethod_2(g, nSeriesInternal, seriesIndex, chartPointIndex, rect, renderContext, renderContext.X1AxisRenderContext);
		}
	}

	private static void smethod_20(Interface32 g, Class748 chartPoint, Class740 chart, float shapeY, float shapeWidth, float wallsDepth, float categoryAxisX, float height, double totalValue, Class784 renderContext)
	{
		Class759 aSeries = chartPoint.ChartPoints.ASeries;
		double num = 1.0;
		double num2 = 1.0;
		switch (aSeries.BarShape)
		{
		case ChartShapeType.Box:
			smethod_21(g, chartPoint, chart, shapeY, shapeWidth, wallsDepth, categoryAxisX, height, (float)num, (float)num2);
			break;
		case ChartShapeType.Cone:
			if (!aSeries.IsStatckedSeries && !aSeries.IsPercentSeries)
			{
				num = 0.0;
			}
			else
			{
				Struct27.smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue4, out var totalMinusYValue4);
				if (chartPoint.YValue > 0.0)
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
			smethod_22(g, chartPoint, chart, shapeY, shapeWidth, wallsDepth, categoryAxisX, height, (float)num, (float)num2);
			break;
		case ChartShapeType.ConeToMax:
			if (aSeries.IsStatckedSeries)
			{
				Struct27.smethod_59(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue5, out var totalMinusYValue5);
				if (chartPoint.YValue > 0.0)
				{
					num = ((totalPositiveYValue5 == 0.0) ? 1.0 : ((totalPositiveYValue5 - totalValue) / totalPositiveYValue5));
					num2 = ((totalPositiveYValue5 == 0.0) ? 1.0 : ((totalPositiveYValue5 - (totalValue - chartPoint.YValue)) / totalPositiveYValue5));
				}
				else
				{
					num = ((totalMinusYValue5 == 0.0) ? 1.0 : ((totalMinusYValue5 - totalValue) / totalMinusYValue5));
					num2 = ((totalMinusYValue5 == 0.0) ? 1.0 : ((totalMinusYValue5 - (totalValue - chartPoint.YValue)) / totalMinusYValue5));
				}
			}
			else if (aSeries.IsPercentSeries)
			{
				Struct27.smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue6, out var totalMinusYValue6);
				if (chartPoint.YValue > 0.0)
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
				num = (float)Struct27.smethod_57(chartPoint, renderContext);
				num2 = 1.0;
			}
			smethod_22(g, chartPoint, chart, shapeY, shapeWidth, wallsDepth, categoryAxisX, height, (float)num, (float)num2);
			break;
		case ChartShapeType.Cylinder:
			smethod_22(g, chartPoint, chart, shapeY, shapeWidth, wallsDepth, categoryAxisX, height, (float)num, (float)num2);
			break;
		case ChartShapeType.Pyramid:
			if (!aSeries.IsStatckedSeries && !aSeries.IsPercentSeries)
			{
				num = 0.0;
			}
			else
			{
				Struct27.smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue3, out var totalMinusYValue3);
				if (chartPoint.YValue > 0.0)
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
			smethod_21(g, chartPoint, chart, shapeY, shapeWidth, wallsDepth, categoryAxisX, height, (float)num, (float)num2);
			break;
		case ChartShapeType.PyramidToMaximum:
			if (aSeries.IsStatckedSeries)
			{
				Struct27.smethod_59(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue, out var totalMinusYValue);
				if (chartPoint.YValue > 0.0)
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
				Struct27.smethod_58(aSeries.NSeries, chartPoint.Index, out var totalPositiveYValue2, out var totalMinusYValue2);
				if (chartPoint.YValue > 0.0)
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
				num = (float)Struct27.smethod_57(chartPoint, renderContext);
				num2 = 1.0;
			}
			smethod_21(g, chartPoint, chart, shapeY, shapeWidth, wallsDepth, categoryAxisX, height, (float)num, (float)num2);
			break;
		}
	}

	private static void smethod_21(Interface32 g, Class748 chartPoint, Class740 chart, float shapeY, float shapeWidth, float wallsDepth, float categoryAxisX, float height, float paraTop, float paraBottom)
	{
		Class741 areaInternal = chartPoint.AreaInternal;
		Class755 borderInternal = chartPoint.BorderInternal;
		PointF[] array = new PointF[8];
		float xCenter = chart.WallsInternal.xCenter;
		float num = categoryAxisX;
		int num2 = 3;
		float wallsDepth2 = wallsDepth * paraBottom;
		float num3 = shapeWidth * paraBottom;
		float yFloor = shapeY - shapeWidth * (1f - paraBottom) / 2f;
		for (int i = 0; i < 2; i++)
		{
			if (num <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num);
				ref PointF reference = ref array[i];
				reference = Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth2, 0);
				array[i + 4].X = array[i].X;
				array[i + 4].Y = array[i].Y - num3;
				ref PointF reference2 = ref array[i + num2];
				reference2 = Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth2, 3);
				array[i + num2 + 4].X = array[i + num2].X;
				array[i + num2 + 4].Y = array[i + num2].Y - num3;
			}
			else
			{
				float wallsWidth = 2f * (num - xCenter);
				ref PointF reference3 = ref array[i];
				reference3 = Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth2, 1);
				array[i + 4].X = array[i].X;
				array[i + 4].Y = array[i].Y - num3;
				ref PointF reference4 = ref array[i + num2];
				reference4 = Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth2, 2);
				array[i + num2 + 4].X = array[i + num2].X;
				array[i + num2 + 4].Y = array[i + num2].Y - num3;
			}
			num2 = 1;
			num += height;
			yFloor = shapeY - shapeWidth * (1f - paraTop) / 2f;
			wallsDepth2 = wallsDepth * paraTop;
			num3 = shapeWidth * paraTop;
		}
		if (height != 0f)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(new PointF[4]
			{
				array[0],
				array[1],
				array[5],
				array[4]
			});
			areaInternal.method_6(graphicsPath);
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPolygon(new PointF[4]
			{
				array[4],
				array[5],
				array[6],
				array[7]
			});
			areaInternal.method_7(graphicsPath2, 2f / 3f);
			borderInternal.method_8(graphicsPath);
			borderInternal.method_8(graphicsPath2);
		}
		if (height > 0f)
		{
			GraphicsPath graphicsPath3 = new GraphicsPath();
			graphicsPath3.AddPolygon(new PointF[4]
			{
				array[1],
				array[2],
				array[6],
				array[5]
			});
			areaInternal.method_7(graphicsPath3, 0.5f);
			borderInternal.method_8(graphicsPath3);
		}
		else if (height < 0f)
		{
			GraphicsPath graphicsPath4 = new GraphicsPath();
			graphicsPath4.AddPolygon(new PointF[4]
			{
				array[0],
				array[3],
				array[7],
				array[4]
			});
			areaInternal.method_7(graphicsPath4, 0f);
			borderInternal.method_8(graphicsPath4);
		}
		else
		{
			GraphicsPath graphicsPath5 = new GraphicsPath();
			graphicsPath5.AddPolygon(new PointF[4]
			{
				array[0],
				array[3],
				array[7],
				array[4]
			});
			areaInternal.method_7(graphicsPath5, 0.5f);
			borderInternal.method_8(graphicsPath5);
		}
	}

	private static void smethod_22(Interface32 g, Class748 chartPoint, Class740 chart, float shapeY, float shapeWidth, float wallsDepth, float categoryAxisX, float height, float paraTop, float paraBottom)
	{
		Class741 areaInternal = chartPoint.AreaInternal;
		float xCenter = chart.WallsInternal.xCenter;
		Dictionary<int, PointF> dictionary = new Dictionary<int, PointF>();
		Dictionary<int, PointF> dictionary2 = new Dictionary<int, PointF>();
		float num = shapeY - shapeWidth / 2f;
		for (int i = 0; i <= 90; i++)
		{
			double num2 = (double)i * Math.PI / 180.0;
			float wallsDepth2 = (float)((double)(wallsDepth * paraBottom) * Math.Cos(num2));
			float yFloor = (float)((double)num - (double)(shapeWidth * paraBottom / 2f) * Math.Sin(num2));
			float yFloor2 = (float)((double)num + (double)(shapeWidth * paraBottom / 2f) * Math.Sin(num2));
			if (categoryAxisX <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - categoryAxisX);
				if (!dictionary.ContainsKey(180 - i))
				{
					dictionary.Add(180 - i, Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth2, 0));
				}
				if (!dictionary.ContainsKey(180 + i))
				{
					dictionary.Add(180 + i, Struct27.smethod_47(chart, yFloor2, wallsWidth, wallsDepth2, 0));
				}
				if (!dictionary.ContainsKey(i))
				{
					dictionary.Add(i, Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth2, 3));
				}
				if (!dictionary.ContainsKey(360 - i))
				{
					dictionary.Add(360 - i, Struct27.smethod_47(chart, yFloor2, wallsWidth, wallsDepth2, 3));
				}
			}
			else
			{
				float wallsWidth = 2f * (categoryAxisX - xCenter);
				if (!dictionary.ContainsKey(180 - i))
				{
					dictionary.Add(180 - i, Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth2, 1));
				}
				if (!dictionary.ContainsKey(180 + i))
				{
					dictionary.Add(180 + i, Struct27.smethod_47(chart, yFloor2, wallsWidth, wallsDepth2, 1));
				}
				if (!dictionary.ContainsKey(i))
				{
					dictionary.Add(i, Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth2, 2));
				}
				if (!dictionary.ContainsKey(360 - i))
				{
					dictionary.Add(360 - i, Struct27.smethod_47(chart, yFloor2, wallsWidth, wallsDepth2, 2));
				}
			}
			float num3 = categoryAxisX + height;
			float wallsDepth3 = (float)((double)(wallsDepth * paraTop) * Math.Cos(num2));
			yFloor = (float)((double)num - (double)(shapeWidth * paraTop / 2f) * Math.Sin(num2));
			yFloor2 = (float)((double)num + (double)(shapeWidth * paraTop / 2f) * Math.Sin(num2));
			if (num3 <= xCenter)
			{
				float wallsWidth = 2f * (xCenter - num3);
				if (!dictionary2.ContainsKey(180 - i))
				{
					dictionary2.Add(180 - i, Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth3, 0));
				}
				if (!dictionary2.ContainsKey(180 + i))
				{
					dictionary2.Add(180 + i, Struct27.smethod_47(chart, yFloor2, wallsWidth, wallsDepth3, 0));
				}
				if (!dictionary2.ContainsKey(i))
				{
					dictionary2.Add(i, Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth3, 3));
				}
				if (!dictionary2.ContainsKey(360 - i))
				{
					dictionary2.Add(360 - i, Struct27.smethod_47(chart, yFloor2, wallsWidth, wallsDepth3, 3));
				}
			}
			else
			{
				float wallsWidth = 2f * (num3 - xCenter);
				if (!dictionary2.ContainsKey(180 - i))
				{
					dictionary2.Add(180 - i, Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth3, 1));
				}
				if (!dictionary2.ContainsKey(180 + i))
				{
					dictionary2.Add(180 + i, Struct27.smethod_47(chart, yFloor2, wallsWidth, wallsDepth3, 1));
				}
				if (!dictionary2.ContainsKey(i))
				{
					dictionary2.Add(i, Struct27.smethod_47(chart, yFloor, wallsWidth, wallsDepth3, 2));
				}
				if (!dictionary2.ContainsKey(360 - i))
				{
					dictionary2.Add(360 - i, Struct27.smethod_47(chart, yFloor2, wallsWidth, wallsDepth3, 2));
				}
			}
		}
		smethod_23(dictionary, out var max, out var min, out var maxAngle, out var minAngle);
		smethod_23(dictionary2, out var max2, out var min2, out var _, out var _);
		if (height != 0f)
		{
			int num4 = 90;
			int num5 = 270;
			float num6 = 0.5f;
			int elevation = chart.Elevation;
			float num7 = 7.5f;
			float num8;
			for (num8 = 90 - elevation; num8 <= (float)(num5 - elevation); num8 += num7)
			{
				int key = (int)(num8 % 360f);
				PointF pointF = dictionary[key];
				PointF pointF2 = dictionary2[key];
				if (num8 == (float)(num4 - elevation))
				{
					pointF = min;
					pointF2 = min2;
				}
				float num9 = num7;
				if ((num8 - (float)num4 == 30f && elevation <= 30) || num8 - (float)num4 == 75f || (num8 - (float)num4 == 120f && elevation > 30))
				{
					num9 = 2f * num7;
				}
				if (num8 == (float)(num4 - elevation) && (float)elevation % num7 != 0f)
				{
					num9 = (float)elevation % num7;
				}
				int key2 = ((num8 + num9 > (float)(num5 - elevation)) ? ((num5 - elevation) % 360) : ((int)((num8 + num9) % 360f)));
				PointF pointF3 = dictionary[key2];
				PointF pointF4 = dictionary2[key2];
				if (num8 + num9 >= (float)(num5 - elevation))
				{
					pointF3 = max;
					pointF4 = max2;
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				PointF[] array = new PointF[(int)num9 + 1];
				int num10 = 0;
				for (int j = (int)num8; j <= (int)num8 + (int)num9; j++)
				{
					ref PointF reference = ref array[num10];
					reference = dictionary[j % 360];
					num10++;
				}
				graphicsPath.AddLine(pointF, pointF3);
				graphicsPath.AddLine(pointF3, pointF4);
				PointF[] array2 = new PointF[(int)num9 + 1];
				num10 = 0;
				for (int num11 = (int)num8 + (int)num9; num11 >= (int)num8; num11--)
				{
					ref PointF reference2 = ref array2[num10];
					reference2 = dictionary2[num11 % 360];
					num10++;
				}
				graphicsPath.AddLine(pointF4, pointF2);
				graphicsPath.AddLine(pointF2, pointF);
				num6 = ((elevation >= 0 && elevation <= 30) ? ((!(num8 - (float)num4 <= 30f)) ? (1.0833334f - 0.5f * ((num8 - (float)num4) / 180f)) : (11f / 12f + 0.5f * ((num8 - (float)num4) / 180f))) : ((!(num8 - (float)num4 <= 120f)) ? (1.3333334f - 0.5f * ((num8 - (float)num4) / 180f)) : (2f / 3f + 0.5f * ((num8 - (float)num4) / 180f))));
				if (num6 == 1f)
				{
					num6 -= 1f / 90f;
				}
				areaInternal.method_7(graphicsPath, num6);
				num8 += num9 - num7;
			}
		}
		Class755 borderInternal = chartPoint.BorderInternal;
		PointF[] array3 = new PointF[dictionary.Count];
		PointF[] array4 = new PointF[dictionary2.Count];
		for (int k = 0; k <= 360; k++)
		{
			ref PointF reference3 = ref array3[k];
			reference3 = dictionary[k];
			ref PointF reference4 = ref array4[k];
			reference4 = dictionary2[k];
		}
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddCurve(array3);
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath3.AddCurve(array4);
		if (chart.Rotation != 0)
		{
			if (height > 0f)
			{
				areaInternal.method_7(graphicsPath3, 0.7f);
				borderInternal.method_8(graphicsPath3);
				Struct27.smethod_67(g, chartPoint, maxAngle, minAngle, dictionary);
			}
			else if (height < 0f)
			{
				areaInternal.method_7(graphicsPath2, 0f);
				borderInternal.method_8(graphicsPath2);
				Struct27.smethod_67(g, chartPoint, maxAngle, minAngle, dictionary2);
			}
			else
			{
				areaInternal.method_7(graphicsPath2, 0.7f);
				borderInternal.method_8(graphicsPath2);
			}
		}
		else
		{
			borderInternal.method_3(min.X, min.Y, max.X, max.Y);
			borderInternal.method_3(min2.X, min2.Y, max2.X, max2.Y);
		}
		if (height != 0f)
		{
			borderInternal.method_3(min.X, min.Y, min2.X, min2.Y);
			borderInternal.method_3(max.X, max.Y, max2.X, max2.Y);
		}
	}

	private static void smethod_23(Dictionary<int, PointF> htPoint, out PointF max, out PointF min, out int maxAngle, out int minAngle)
	{
		max = PointF.Empty;
		min = PointF.Empty;
		maxAngle = 0;
		minAngle = 0;
		IDictionaryEnumerator dictionaryEnumerator = htPoint.GetEnumerator();
		while (dictionaryEnumerator.MoveNext())
		{
			PointF pointF = (PointF)dictionaryEnumerator.Value;
			if (max == PointF.Empty || pointF.Y > max.Y)
			{
				max = pointF;
				maxAngle = (int)dictionaryEnumerator.Key;
			}
			if (min == PointF.Empty || pointF.Y < min.Y)
			{
				min = pointF;
				minAngle = (int)dictionaryEnumerator.Key;
			}
		}
	}
}
