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
internal struct Struct20
{
	internal static List<object[]> smethod_0(Interface32 g, Class740 chart, Class759 aSeries, Rectangle plotAreaRect, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		List<object[]> list = new List<object[]>();
		if (maxPointsCount < 2)
		{
			return list;
		}
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
			return smethod_1(g, chart, aSeries, plotAreaRect, categoryAxisY, (float)categoryAxisCrossAt, renderContext);
		}
		_ = chart.NSeriesInternal;
		double logMaxValue = class2.LogMaxValue;
		double logMinValue = class2.LogMinValue;
		categoryAxisCrossAt = (class2.Axis.IsLogarithmic ? class2.method_0(categoryAxisCrossAt) : categoryAxisCrossAt);
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
		int num = 0;
		if (!@class.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num = maxPointsCount - 1;
			if (num == 0)
			{
				num = 1;
			}
		}
		else
		{
			num = maxPointsCount;
		}
		double num2 = (double)plotAreaRect.Width / (double)num;
		List<List<PointF>> list2 = new List<List<PointF>>();
		List<PointF> list3 = new List<PointF>();
		Class747 pointsInternal = aSeries.PointsInternal;
		for (int i = 0; i < maxPointsCount; i++)
		{
			Class748 class3 = pointsInternal.method_0(i);
			double num3 = (float)num2 * (float)i + 1f;
			if (@class.AxisBetweenCategories || renderContext.Chart.HasDataTable)
			{
				num3 += (double)(float)(num2 / 2.0);
			}
			num3 = ((!@class.Axis.IsPlotOrderReversed) ? ((double)plotAreaRect.X + num3) : ((double)(plotAreaRect.X + plotAreaRect.Width) - num3));
			if (class3 != null)
			{
				double num4 = categoryAxisY;
				double yValue = class3.YValue;
				double num5 = (yValue - categoryAxisCrossAt) / (logMaxValue - logMinValue) * (double)plotAreaRect.Height;
				num4 = (class2.Axis.IsPlotOrderReversed ? (num4 + num5) : (num4 - num5));
				PointF pointF = new PointF((float)num3, (float)num4);
				list3.Add(pointF);
				Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
				double num6 = 0.0;
				double num7 = 0.0;
				float minusHeight = 0f;
				float plusHeight = 0f;
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
						catch (Exception ex)
						{
							Class1165.smethod_28(ex);
						}
						num6 = num8;
						try
						{
							num8 = ((yErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.PlusValue[i]) : 0.0);
						}
						catch (Exception ex2)
						{
							Class1165.smethod_28(ex2);
						}
						num7 = num8;
						break;
					}
					case ErrorBarValueType.Fixed:
						num6 = yErrorBarInternal.Amount;
						num7 = num6;
						break;
					case ErrorBarValueType.Percentage:
						num6 = yErrorBarInternal.Amount * yValue / 100.0;
						num7 = num6;
						break;
					}
					minusHeight = (float)num6 / (float)(logMaxValue - logMinValue) * (float)plotAreaRect.Height;
					plusHeight = (float)num7 / (float)(logMaxValue - logMinValue) * (float)plotAreaRect.Height;
				}
				yErrorBarInternal.method_0(pointF, minusHeight, plusHeight);
			}
			else
			{
				list3.Add(new PointF((float)num3, categoryAxisY));
			}
		}
		list2.Add(list3);
		smethod_7(g, aSeries, list2, categoryAxisY, hasDropLines, dropLinesInternal, list, plotAreaRect, @class);
		return list;
	}

	private static List<object[]> smethod_1(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisY, float categoryAxisCrossAt, Class784 renderContext)
	{
		List<object[]> list = new List<object[]>();
		Enum141 axisGroup = aSeries.AxisGroup;
		Class783 @class;
		Class783 class2;
		List<int> list2;
		if (axisGroup == Enum141.const_0)
		{
			@class = renderContext.Y1AxisRenderContext;
			class2 = renderContext.X1AxisRenderContext;
			list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			@class = renderContext.Y2AxisRenderContext;
			class2 = renderContext.X2AxisRenderContext;
			list2 = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		double minValue = @class.MinValue;
		double maxValue = @class.MaxValue;
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
		int count = list2.Count;
		TimeUnitType baseUnitScale = class2.Axis.BaseUnitScale;
		int minValue2 = (int)class2.MinValue;
		int maxValue2 = (int)class2.MaxValue;
		int num = 0;
		if (!class2.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
		{
			num = Struct21.smethod_35(baseUnitScale, maxValue2, minValue2, chart.IsDate1904);
			if (num == 0)
			{
				num = 1;
			}
		}
		else
		{
			num = Struct21.smethod_35(baseUnitScale, maxValue2, minValue2, chart.IsDate1904) + 1;
		}
		double num2 = (double)rect.Width / (double)num;
		List<List<PointF>> list3 = new List<List<PointF>>();
		bool isOffsetAx = false;
		List<PointF> list4 = new List<PointF>();
		for (int i = 0; i < count; i++)
		{
			Class748 class3 = aSeries.PointsInternal.method_0(i);
			int num3 = int.Parse(list2[i].ToString());
			if (num3 == -10000)
			{
				isOffsetAx = true;
				continue;
			}
			num3 = Struct21.smethod_38(baseUnitScale, num3, chart.IsDate1904);
			int num4 = Struct21.smethod_35(baseUnitScale, num3, minValue2, chart.IsDate1904);
			float num5 = (float)(num2 * (double)num4);
			if (class2.AxisBetweenCategories || renderContext.Chart.HasDataTable)
			{
				num5 += (float)(num2 / 2.0);
			}
			float num6 = 0f;
			num6 = ((!class2.Axis.IsPlotOrderReversed) ? ((float)rect.X + num5) : ((float)(rect.X + rect.Width) - num5));
			if (class3 != null)
			{
				float num7 = categoryAxisY;
				float num8 = (float)class3.YValue;
				float num9 = (num8 - categoryAxisCrossAt) / (float)(maxValue - minValue) * (float)rect.Height;
				num7 = (@class.Axis.IsPlotOrderReversed ? (num7 + num9) : (num7 - num9));
				PointF pointF = new PointF(num6, num7);
				if (list4.Count == 0)
				{
					list4.Add(pointF);
				}
				else
				{
					int j;
					for (j = 0; j < list4.Count; j++)
					{
						_ = list4[j];
						PointF pointF2 = list4[j];
						if (!(pointF.X >= pointF2.X))
						{
							list4.Insert(j, pointF);
							break;
						}
					}
					if (j == list4.Count)
					{
						list4.Add(pointF);
					}
				}
				Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
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
							num12 = ((yErrorBarInternal.MinusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.MinusValue[i]) : 0.0);
						}
						catch (Exception ex)
						{
							Class1165.smethod_28(ex);
						}
						num10 = num12;
						try
						{
							num12 = ((yErrorBarInternal.PlusValue.Count > i) ? Convert.ToDouble(yErrorBarInternal.PlusValue[i]) : 0.0);
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
						num10 = yErrorBarInternal.Amount * (double)num8 / 100.0;
						num11 = num10;
						break;
					}
					minusHeight = (float)num10 / (float)(@class.MaxValue - @class.MinValue) * (float)rect.Height;
					plusHeight = (float)num11 / (float)(@class.MaxValue - @class.MinValue) * (float)rect.Height;
				}
				yErrorBarInternal.method_0(pointF, minusHeight, plusHeight);
			}
			else
			{
				list4.Add(new PointF(num6, categoryAxisY));
			}
		}
		list3.Add(list4);
		smethod_8(g, aSeries, list3, categoryAxisY, hasDropLines, dropLinesInternal, list, rect, isOffsetAx, class2);
		return list;
	}

	internal static List<object[]> smethod_2(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisY, int maxPointsCount, Class784 renderContext)
	{
		List<object[]> list = new List<object[]>();
		if (maxPointsCount < 2)
		{
			return list;
		}
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.StackedArea;
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
			return smethod_3(g, chart, aSeries, rect, categoryAxisY, axisGroup, renderContext);
		}
		float num = 0f;
		num = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		Class757 nSeriesInternal = chart.NSeriesInternal;
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
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
		List<List<PointF>> list2 = new List<List<PointF>>();
		List<Class759> list3 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
		List<Class759> list4 = new List<Class759>();
		int num4 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
		Class759 class3 = null;
		if (num4 > 0)
		{
			class3 = nSeriesInternal.method_11(num4 - 1, axisGroup, new ChartType[1] { chartType });
		}
		if (class3 != null)
		{
			list4.Add(class3);
		}
		list4.Add(aSeries);
		for (int i = 0; i < list4.Count; i++)
		{
			Class759 class4 = list4[i];
			int num5 = nSeriesInternal.method_12(class4, axisGroup, new ChartType[1] { chartType });
			int index = class4.Index;
			List<PointF> list5 = new List<PointF>();
			Class747 pointsInternal = nSeriesInternal.method_0(index).PointsInternal;
			for (int j = 0; j < maxPointsCount; j++)
			{
				Class748 class5 = pointsInternal.method_0(j);
				double num6 = (float)num3 * (float)j + 1f;
				if (@class.AxisBetweenCategories || renderContext.Chart.HasDataTable)
				{
					num6 += (double)(float)(num3 / 2.0);
				}
				num6 = ((!@class.Axis.IsPlotOrderReversed) ? ((double)rect.X + num6) : ((double)(rect.X + rect.Width) - num6));
				if (class5 != null)
				{
					double yValue = class5.YValue;
					double num7 = yValue;
					for (int k = 0; k < num5; k++)
					{
						Class748 class6 = list3[k].PointsInternal.method_0(j);
						if (class6 != null)
						{
							double yValue2 = class6.YValue;
							num7 += yValue2;
						}
					}
					float num8 = (float)Math.Abs(num7) / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					num8 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(num7 <= 0.0)) ? (num - num8) : (num + num8)) : ((!(num7 <= 0.0)) ? (num + num8) : (num - num8)));
					PointF pointF = new PointF((float)num6, num8);
					list5.Add(pointF);
					if (!class4.Equals(aSeries))
					{
						continue;
					}
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
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
					}
					yErrorBarInternal.method_0(pointF, minusHeight, plusHeight);
				}
				else
				{
					list5.Add(new PointF((float)num6, categoryAxisY));
				}
			}
			list2.Add(list5);
		}
		smethod_9(g, list4, list2, categoryAxisY, hasDropLines, dropLinesInternal, list, @class);
		return list;
	}

	private static List<object[]> smethod_3(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisY, Enum141 axisGroupType, Class784 renderContext)
	{
		List<object[]> list = new List<object[]>();
		ChartType chartType = ChartType.StackedArea;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class759 @class = chart.NSeriesInternal.method_5(axisGroupType, ChartType.StackedArea);
		if (@class == null)
		{
			return list;
		}
		Class783 class2;
		Class783 class3;
		List<int> list2;
		if (axisGroupType == Enum141.const_0)
		{
			class2 = renderContext.X1AxisRenderContext;
			class3 = renderContext.Y1AxisRenderContext;
			list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			class2 = renderContext.X2AxisRenderContext;
			class3 = renderContext.Y2AxisRenderContext;
			list2 = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		float num = 0f;
		num = (class3.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class3.MaxValue / (float)(class3.MaxValue - class3.MinValue) * (float)rect.Height));
		bool hasDropLines = @class.HasDropLines;
		Class755 dropLinesInternal = @class.DropLinesInternal;
		int count = list2.Count;
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
		List<List<PointF>> list3 = new List<List<PointF>>();
		List<Class759> list4 = nSeriesInternal.method_10(axisGroupType, new ChartType[1] { chartType });
		List<Class759> list5 = new List<Class759>();
		int num4 = nSeriesInternal.method_12(aSeries, axisGroupType, new ChartType[1] { chartType });
		Class759 class4 = null;
		if (num4 > 0)
		{
			class4 = nSeriesInternal.method_11(num4 - 1, axisGroupType, new ChartType[1] { chartType });
		}
		if (class4 != null)
		{
			list5.Add(class4);
		}
		list5.Add(aSeries);
		for (int i = 0; i < list5.Count; i++)
		{
			Class759 class5 = list5[i];
			int num5 = nSeriesInternal.method_12(class5, axisGroupType, new ChartType[1] { chartType });
			int index = class5.Index;
			List<PointF> list6 = new List<PointF>();
			for (int j = 0; j < count; j++)
			{
				Class748 class6 = nSeriesInternal.method_0(index).PointsInternal.method_0(j);
				int val = int.Parse(list2[j].ToString());
				val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
				int num6 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
				float num7 = (float)(num3 * (double)num6);
				if (class2.AxisBetweenCategories || renderContext.Chart.HasDataTable)
				{
					num7 += (float)(num3 / 2.0);
				}
				float num8 = 0f;
				num8 = ((!class2.Axis.IsPlotOrderReversed) ? ((float)rect.X + num7) : ((float)(rect.X + rect.Width) - num7));
				if (class6 != null)
				{
					double yValue = class6.YValue;
					double num9 = yValue;
					for (int k = 0; k < num5; k++)
					{
						Class748 class7 = list4[k].PointsInternal.method_0(j);
						if (class7 != null)
						{
							double yValue2 = class7.YValue;
							num9 += yValue2;
						}
					}
					float num10 = (float)Math.Abs(num9) / (float)(class3.MaxValue - class3.MinValue) * (float)rect.Height;
					num10 = ((!class3.Axis.IsPlotOrderReversed) ? ((!(num9 <= 0.0)) ? (num - num10) : (num + num10)) : ((!(num9 <= 0.0)) ? (num + num10) : (num - num10)));
					PointF pointF = new PointF(num8, num10);
					if (list6.Count == 0)
					{
						list6.Add(pointF);
					}
					else
					{
						int l;
						for (l = 0; l < list6.Count; l++)
						{
							_ = list6[l];
							PointF pointF2 = list6[l];
							if (!(pointF.X >= pointF2.X))
							{
								list6.Insert(l, pointF);
								break;
							}
						}
						if (l == list6.Count)
						{
							list6.Add(pointF);
						}
					}
					if (!class5.Equals(aSeries))
					{
						continue;
					}
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
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
							num11 = yErrorBarInternal.Amount * yValue / 100.0;
							num12 = num11;
							break;
						}
						minusHeight = (float)num11 / (float)(class3.MaxValue - class3.MinValue) * (float)rect.Height;
						plusHeight = (float)num12 / (float)(class3.MaxValue - class3.MinValue) * (float)rect.Height;
					}
					yErrorBarInternal.method_0(pointF, minusHeight, plusHeight);
				}
				else
				{
					list6.Add(new PointF(num8, categoryAxisY));
				}
			}
			list3.Add(list6);
		}
		smethod_9(g, list5, list3, categoryAxisY, hasDropLines, dropLinesInternal, list, class2);
		return list;
	}

	internal static List<object[]> smethod_4(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisY, int maxPointsCount, Class784 renderContext)
	{
		List<object[]> list = new List<object[]>();
		if (maxPointsCount < 2)
		{
			return list;
		}
		Enum141 axisGroup = aSeries.AxisGroup;
		ChartType chartType = ChartType.PercentsStackedArea;
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
			return smethod_5(g, chart, aSeries, rect, categoryAxisY, axisGroup, renderContext);
		}
		float num = 0f;
		num = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		Class757 nSeriesInternal = chart.NSeriesInternal;
		bool hasDropLines = aSeries.HasDropLines;
		Class755 dropLinesInternal = aSeries.DropLinesInternal;
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
		List<List<PointF>> list2 = new List<List<PointF>>();
		List<Class759> list3 = nSeriesInternal.method_10(axisGroup, new ChartType[1] { chartType });
		List<Class759> list4 = new List<Class759>();
		int num4 = nSeriesInternal.method_12(aSeries, axisGroup, new ChartType[1] { chartType });
		Class759 class3 = null;
		if (num4 > 0)
		{
			class3 = nSeriesInternal.method_11(num4 - 1, axisGroup, new ChartType[1] { chartType });
		}
		if (class3 != null)
		{
			list4.Add(class3);
		}
		list4.Add(aSeries);
		for (int i = 0; i < list4.Count; i++)
		{
			Class759 class4 = list4[i];
			int num5 = nSeriesInternal.method_12(class4, axisGroup, new ChartType[1] { chartType });
			int index = class4.Index;
			List<PointF> list5 = new List<PointF>();
			Class747 pointsInternal = nSeriesInternal.method_0(index).PointsInternal;
			for (int j = 0; j < maxPointsCount; j++)
			{
				Class748 class5 = pointsInternal.method_0(j);
				double num6 = (float)num3 * (float)j + 1f;
				if (@class.AxisBetweenCategories || renderContext.Chart.HasDataTable)
				{
					num6 += (double)(float)(num3 / 2.0);
				}
				num6 = ((!@class.Axis.IsPlotOrderReversed) ? ((double)rect.X + num6) : ((double)(rect.X + rect.Width) - num6));
				if (class5 != null)
				{
					double yValue = class5.YValue;
					double num7 = yValue;
					double num8 = 0.0;
					for (int k = 0; k < num5; k++)
					{
						Class748 class6 = list3[k].PointsInternal.method_0(j);
						if (class6 != null)
						{
							double yValue2 = class6.YValue;
							num7 += yValue2;
						}
					}
					for (int l = 0; l < list3.Count; l++)
					{
						Class748 class7 = list3[l].PointsInternal.method_0(j);
						if (class7 != null)
						{
							double yValue3 = class7.YValue;
							num8 += Math.Abs(yValue3);
						}
					}
					float num9 = (float)Math.Abs(num7) * 100f / (float)num8 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					num9 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(num7 <= 0.0)) ? (num - num9) : (num + num9)) : ((!(num7 <= 0.0)) ? (num + num9) : (num - num9)));
					PointF pointF = new PointF((float)num6, num9);
					list5.Add(pointF);
					if (!class4.Equals(aSeries))
					{
						continue;
					}
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
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
					}
					yErrorBarInternal.method_0(pointF, minusHeight, plusHeight);
				}
				else
				{
					int num13 = i;
					if (num13 > 0)
					{
						_ = list2[num13 - 1][j];
						list5.Add(list2[num13 - 1][j]);
					}
					if (i == 0)
					{
						list5.Add(new PointF((float)num6, categoryAxisY));
					}
				}
			}
			list2.Add(list5);
		}
		smethod_9(g, list4, list2, categoryAxisY, hasDropLines, dropLinesInternal, list, @class);
		return list;
	}

	private static List<object[]> smethod_5(Interface32 g, Class740 chart, Class759 aSeries, Rectangle rect, float categoryAxisY, Enum141 axisGroupType, Class784 renderContext)
	{
		List<object[]> list = new List<object[]>();
		ChartType chartType = ChartType.PercentsStackedArea;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class759 @class = chart.NSeriesInternal.method_5(axisGroupType, ChartType.PercentsStackedArea);
		if (@class == null)
		{
			return list;
		}
		Class783 class2;
		Class783 class3;
		List<int> list2;
		if (axisGroupType == Enum141.const_0)
		{
			class2 = renderContext.Y1AxisRenderContext;
			class3 = renderContext.X1AxisRenderContext;
			list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		}
		else
		{
			class2 = renderContext.Y2AxisRenderContext;
			class3 = renderContext.X2AxisRenderContext;
			list2 = Struct24.smethod_54(chart.NSeriesInternal.Category2LabelsInternal, chart.IsDate1904);
		}
		float num = 0f;
		num = (class2.Axis.IsPlotOrderReversed ? ((float)rect.Bottom - (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height) : ((float)rect.Y + (float)class2.MaxValue / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height));
		bool hasDropLines = @class.HasDropLines;
		Class755 dropLinesInternal = @class.DropLinesInternal;
		int count = list2.Count;
		TimeUnitType baseUnitScale = class3.Axis.BaseUnitScale;
		int minValue = (int)class3.MinValue;
		int maxValue = (int)class3.MaxValue;
		int num2 = 0;
		if (!class3.AxisBetweenCategories && !renderContext.Chart.HasDataTable)
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
		List<List<PointF>> list3 = new List<List<PointF>>();
		List<Class759> list4 = nSeriesInternal.method_10(axisGroupType, new ChartType[1] { chartType });
		List<Class759> list5 = new List<Class759>();
		int num4 = nSeriesInternal.method_12(aSeries, axisGroupType, new ChartType[1] { chartType });
		Class759 class4 = null;
		if (num4 > 0)
		{
			class4 = nSeriesInternal.method_11(num4 - 1, axisGroupType, new ChartType[1] { chartType });
		}
		if (class4 != null)
		{
			list5.Add(class4);
		}
		list5.Add(aSeries);
		for (int i = 0; i < list5.Count; i++)
		{
			Class759 class5 = list5[i];
			int num5 = nSeriesInternal.method_12(class5, axisGroupType, new ChartType[1] { chartType });
			int index = class5.Index;
			List<PointF> list6 = new List<PointF>();
			for (int j = 0; j < count; j++)
			{
				Class748 class6 = nSeriesInternal.method_0(index).PointsInternal.method_0(j);
				int val = int.Parse(list2[j].ToString());
				val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
				int num6 = Struct21.smethod_35(baseUnitScale, val, minValue, chart.IsDate1904);
				float num7 = (float)(num3 * (double)num6);
				if (class3.AxisBetweenCategories || renderContext.Chart.HasDataTable)
				{
					num7 += (float)(num3 / 2.0);
				}
				float num8 = 0f;
				num8 = ((!class3.Axis.IsPlotOrderReversed) ? ((float)rect.X + num7) : ((float)(rect.X + rect.Width) - num7));
				if (class6 != null)
				{
					double yValue = class6.YValue;
					double num9 = yValue;
					double num10 = 0.0;
					for (int k = 0; k < num5; k++)
					{
						Class748 class7 = list4[k].PointsInternal.method_0(j);
						if (class7 != null)
						{
							double yValue2 = class7.YValue;
							num9 += yValue2;
						}
					}
					for (int l = 0; l < list4.Count; l++)
					{
						Class748 class8 = list4[l].PointsInternal.method_0(j);
						if (class8 != null)
						{
							double yValue3 = class8.YValue;
							num10 += Math.Abs(yValue3);
						}
					}
					float num11 = (float)Math.Abs(num9) * 100f / (float)num10 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					num11 = ((!class2.Axis.IsPlotOrderReversed) ? ((!(num9 <= 0.0)) ? (num - num11) : (num + num11)) : ((!(num9 <= 0.0)) ? (num + num11) : (num - num11)));
					PointF pointF = new PointF(num8, num11);
					if (list6.Count == 0)
					{
						list6.Add(pointF);
					}
					else
					{
						int m;
						for (m = 0; m < list6.Count; m++)
						{
							_ = list6[m];
							PointF pointF2 = list6[m];
							if (!(pointF.X >= pointF2.X))
							{
								list6.Insert(m, pointF);
								break;
							}
						}
						if (m == list6.Count)
						{
							list6.Add(pointF);
						}
					}
					if (!class5.Equals(aSeries))
					{
						continue;
					}
					Class752 yErrorBarInternal = aSeries.YErrorBarInternal;
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
						num13 = num13 * 100.0 / num10;
						num12 = num12 * 100.0 / num10;
						minusHeight = (float)num12 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
						plusHeight = (float)num13 / (float)(class2.MaxValue - class2.MinValue) * (float)rect.Height;
					}
					yErrorBarInternal.method_0(pointF, minusHeight, plusHeight);
				}
				else
				{
					list6.Add(new PointF(num8, categoryAxisY));
				}
			}
			list3.Add(list6);
		}
		smethod_9(g, list5, list3, categoryAxisY, hasDropLines, dropLinesInternal, list, class3);
		return list;
	}

	internal static RectangleF smethod_6(PointF[] points)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		if (points.Length > 0)
		{
			num = points[0].X;
			num2 = points[0].X;
			num3 = points[0].Y;
			num4 = points[0].Y;
		}
		for (int i = 1; i < points.Length; i++)
		{
			PointF pointF = points[i];
			if (pointF.X < num)
			{
				num = pointF.X;
			}
			if (pointF.X > num2)
			{
				num2 = pointF.X;
			}
			if (pointF.Y < num3)
			{
				num3 = pointF.Y;
			}
			if (pointF.Y > num4)
			{
				num4 = pointF.Y;
			}
		}
		float num5 = (int)num;
		float num6 = (int)num3;
		float num7 = (int)Math.Ceiling(num2 - num5);
		if (num7 == 0f)
		{
			num7 = 1f;
		}
		float num8 = (int)Math.Ceiling(num4 - num6);
		if (num8 == 0f)
		{
			num8 = 1f;
		}
		return new RectangleF(num5, num6, num7, num8);
	}

	private static void smethod_7(Interface32 g, Class759 series, List<List<PointF>> list, float categoryAxisY, bool hasDropLines, Class755 dropLines, List<object[]> paramOfDataLabels, Rectangle plotAreaRect, Class783 axisRenderContext)
	{
		smethod_8(g, series, list, categoryAxisY, hasDropLines, dropLines, paramOfDataLabels, plotAreaRect, isOffsetAx: false, axisRenderContext);
	}

	private static void smethod_8(Interface32 g, Class759 series, List<List<PointF>> list, float categoryAxisY, bool hasDropLines, Class755 dropLines, List<object[]> paramOfDataLabels, Rectangle plotAreaRect, bool isOffsetAx, Class783 axisRenderContext)
	{
		Rectangle rect = new Rectangle(plotAreaRect.X, plotAreaRect.Y + 1, plotAreaRect.Width, plotAreaRect.Height + 1);
		GraphicsState gstate = g.Save();
		g.imethod_121(rect);
		for (int i = 0; i < list.Count; i++)
		{
			List<PointF> list2 = list[i];
			if (list2.Count >= 2)
			{
				PointF pointF = list2[0];
				series.LineInternal.method_3(pointF.X, pointF.Y, pointF.X, categoryAxisY);
				PointF[] array = new PointF[2 * list2.Count];
				for (int j = 0; j < list2.Count; j++)
				{
					PointF pointF2 = list2[j];
					array[j] = pointF2;
					ref PointF reference = ref array[array.Length - 1 - j];
					reference = new PointF(pointF2.X, categoryAxisY);
					paramOfDataLabels.Add(new object[4]
					{
						series.Index,
						j,
						new PointF(pointF2.X, (pointF2.Y + array[array.Length - 1 - j].Y) / 2f),
						axisRenderContext
					});
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddPolygon(array);
				series.AreaInternal.method_6(graphicsPath);
				series.LineInternal.method_8(graphicsPath);
			}
		}
		if (hasDropLines)
		{
			for (int k = 0; k < list.Count; k++)
			{
				List<PointF> list3 = list[k];
				for (int l = 1; l < list3.Count - 1; l++)
				{
					PointF pointF3 = list3[l];
					dropLines.method_3(pointF3.X, pointF3.Y, pointF3.X, categoryAxisY);
				}
			}
		}
		g.imethod_114(gstate);
	}

	private static void smethod_9(Interface32 g, IList nSeries, List<List<PointF>> list, float categoryAxisY, bool hasDropLines, Class755 dropLines, List<object[]> paramOfDataLabels, Class783 axisRenderContext)
	{
		for (int i = list.Count - 1; i < list.Count; i++)
		{
			List<PointF> list2 = list[i];
			Class759 @class = (Class759)nSeries[i];
			List<PointF> list3 = null;
			if (i > 0)
			{
				list3 = list[i - 1];
			}
			if (list2.Count < 2)
			{
				continue;
			}
			PointF pointF = list2[0];
			@class.LineInternal.method_3(pointF.X, pointF.Y, pointF.X, categoryAxisY);
			PointF[] array = new PointF[2 * list2.Count];
			for (int j = 0; j < list2.Count; j++)
			{
				PointF pointF2 = list2[j];
				array[j] = pointF2;
				if (list3 == null)
				{
					ref PointF reference = ref array[array.Length - 1 - j];
					reference = new PointF(pointF2.X, categoryAxisY);
				}
				else
				{
					ref PointF reference2 = ref array[array.Length - 1 - j];
					reference2 = list3[j];
				}
				paramOfDataLabels.Add(new object[4]
				{
					@class.Index,
					j,
					new PointF(pointF2.X, (pointF2.Y + array[array.Length - 1 - j].Y) / 2f),
					axisRenderContext
				});
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(array);
			@class.AreaInternal.method_6(graphicsPath);
			@class.LineInternal.method_8(graphicsPath);
		}
		if (!hasDropLines)
		{
			return;
		}
		for (int k = 0; k < list.Count; k++)
		{
			List<PointF> list4 = list[k];
			for (int l = 1; l < list4.Count - 1; l++)
			{
				PointF pointF3 = list4[l];
				dropLines.method_3(pointF3.X, pointF3.Y, pointF3.X, categoryAxisY);
			}
		}
	}

	internal static void smethod_10(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, Class784 renderContext)
	{
		if (maxPointsCount < 2)
		{
			return;
		}
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_11(g, chart, categoryAxisY, categoryAxisCrossAt, renderContext);
			return;
		}
		float num = (float)chart.DepthPercent / 100f;
		float num2 = (float)chart.GapDepth / 100f;
		List<object[]> list = new List<object[]>();
		int num3 = 0;
		bool flag;
		if (flag = renderContext.X1AxisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
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
		List<PointF[]> list2 = new List<PointF[]>();
		IList list3 = nSeriesInternal.method_9();
		if ((chart.Rotation >= 0 && chart.Rotation < 90) || (chart.Rotation >= 180 && chart.Rotation < 270))
		{
			for (int i = 0; i < list3.Count; i++)
			{
				int num5 = list3.Count - 1 - i;
				if (chart.Rotation >= 180 && chart.Rotation < 270)
				{
					num5 = list3.Count - 1 - num5;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num5 = list3.Count - 1 - num5;
				}
				Class759 @class = (Class759)list3[num5];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				Class748 chartPoint = null;
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
					if (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num8 = maxPointsCount - 1 - num6;
					}
					Class748 class2 = pointsInternal.method_0(num8);
					double num9 = 0.0;
					if (class2 != null && !class2.NotPlotted)
					{
						num9 = class2.YValue;
						chartPoint = class2;
					}
					float num10 = (float)(categoryAxisCrossAt - num9) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					if (renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num10 = 0f - num10;
					}
					PointF[] array = Struct27.smethod_48(g, chart, categoryAxisY, 0f, num7, shapeDepth, index + 1, list3.Count, renderContext);
					list2.Add(array);
					PointF[] array2 = Struct27.smethod_48(g, chart, categoryAxisY, num10, num7, shapeDepth, index + 1, list3.Count, renderContext);
					list2.Add(array2);
					if (class2 != null && !class2.NotPlotted)
					{
						PointF pointF = new PointF(0f, 0f);
						if (chart.Rotation >= 90 && chart.Rotation < 270)
						{
							pointF.X = (array[1].X + array2[1].X) / 2f;
							pointF.Y = (array[1].Y + array2[1].Y) / 2f;
						}
						else
						{
							pointF.X = (array[0].X + array2[0].X) / 2f;
							pointF.Y = (array[0].Y + array2[0].Y) / 2f;
						}
						list.Add(new object[3] { index, num8, pointF });
					}
					else
					{
						list2.Add(null);
					}
				}
				smethod_14(g, chart, chartPoint, list2);
				list2.Clear();
				Struct27.smethod_45(g, chart, list, renderContext);
				list.Clear();
			}
		}
		else
		{
			if ((chart.Rotation < 90 || chart.Rotation >= 180) && (chart.Rotation < 270 || chart.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < list3.Count; k++)
			{
				int num11 = k;
				if (chart.Rotation >= 270 && chart.Rotation < 360)
				{
					num11 = list3.Count - 1 - num11;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num11 = list3.Count - 1 - num11;
				}
				Class759 class3 = (Class759)list3[num11];
				int index2 = class3.Index;
				Class747 pointsInternal2 = class3.PointsInternal;
				Class748 chartPoint2 = null;
				for (int l = 0; l < maxPointsCount; l++)
				{
					int num12 = l;
					if (chart.Rotation >= 270 && chart.Rotation < 360)
					{
						num12 = maxPointsCount - 1 - num12;
					}
					float num13 = num4 * (float)num12;
					num13 = chart.WallsInternal.X + num13;
					if (flag)
					{
						num13 += num4 / 2f;
					}
					int num14 = num12;
					if (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num14 = maxPointsCount - 1 - num12;
					}
					Class748 class4 = pointsInternal2.method_0(num14);
					double yValue = class4.YValue;
					if (class4 != null && !class4.NotPlotted)
					{
						yValue = class4.YValue;
						chartPoint2 = class4;
					}
					float num15 = (float)(categoryAxisCrossAt - yValue) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					if (renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num15 = 0f - num15;
					}
					PointF[] array3 = Struct27.smethod_48(g, chart, categoryAxisY, 0f, num13, shapeDepth, index2 + 1, list3.Count, renderContext);
					list2.Add(array3);
					PointF[] array4 = Struct27.smethod_48(g, chart, categoryAxisY, num15, num13, shapeDepth, index2 + 1, list3.Count, renderContext);
					list2.Add(array4);
					if (class4 != null && !class4.NotPlotted)
					{
						PointF pointF2 = new PointF(0f, 0f);
						if (chart.Rotation >= 90 && chart.Rotation < 270)
						{
							pointF2.X = (array3[1].X + array4[1].X) / 2f;
							pointF2.Y = (array3[1].Y + array4[1].Y) / 2f;
						}
						else
						{
							pointF2.X = (array3[0].X + array4[0].X) / 2f;
							pointF2.Y = (array3[0].Y + array4[0].Y) / 2f;
						}
						list.Add(new object[3] { index2, num14, pointF2 });
					}
					else
					{
						list2.Add(null);
					}
				}
				smethod_14(g, chart, chartPoint2, list2);
				list2.Clear();
				Struct27.smethod_45(g, chart, list, renderContext);
				list.Clear();
			}
		}
	}

	private static void smethod_11(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, Class784 renderContext)
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
		if (flag = renderContext.X1AxisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
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
		List<PointF[]> list2 = new List<PointF[]>();
		IList list3 = nSeriesInternal.method_9();
		List<int> list4 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count = list4.Count;
		if ((chart.Rotation >= 0 && chart.Rotation < 90) || (chart.Rotation >= 180 && chart.Rotation < 270))
		{
			for (int i = 0; i < list3.Count; i++)
			{
				int num5 = list3.Count - 1 - i;
				if (chart.Rotation >= 180 && chart.Rotation < 270)
				{
					num5 = list3.Count - 1 - num5;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num5 = list3.Count - 1 - num5;
				}
				Class759 @class = (Class759)list3[num5];
				int index = @class.Index;
				Class747 pointsInternal = @class.PointsInternal;
				Class748 chartPoint = null;
				for (int j = 0; j < count; j++)
				{
					int num6 = j;
					if (chart.Rotation >= 180 && chart.Rotation < 270)
					{
						num6 = count - 1 - num6;
					}
					int val = int.Parse(list4[num6].ToString());
					val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
					int num7 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
					float num8 = num4 * (float)num7;
					float num9 = chart.WallsInternal.X + num8;
					if (flag)
					{
						num9 += num4 / 2f;
					}
					int num10 = num6;
					if (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num10 = count - 1 - num6;
					}
					Class748 class2 = pointsInternal.method_0(num10);
					double num11 = 0.0;
					if (class2 != null && !class2.NotPlotted)
					{
						num11 = class2.YValue;
						chartPoint = class2;
					}
					float num12 = (float)(categoryAxisCrossAt - num11) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					if (renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num12 = 0f - num12;
					}
					PointF[] array = Struct27.smethod_48(g, chart, categoryAxisY, 0f, num9, shapeDepth, index + 1, list3.Count, renderContext);
					list2.Add(array);
					PointF[] array2 = Struct27.smethod_48(g, chart, categoryAxisY, num12, num9, shapeDepth, index + 1, list3.Count, renderContext);
					list2.Add(array2);
					if (class2 != null && !class2.NotPlotted)
					{
						PointF pointF = new PointF(0f, 0f);
						if (chart.Rotation >= 90 && chart.Rotation < 270)
						{
							pointF.X = (array[1].X + array2[1].X) / 2f;
							pointF.Y = (array[1].Y + array2[1].Y) / 2f;
						}
						else
						{
							pointF.X = (array[0].X + array2[0].X) / 2f;
							pointF.Y = (array[0].Y + array2[0].Y) / 2f;
						}
						list.Add(new object[3] { index, num10, pointF });
					}
					else
					{
						list2.Add(null);
					}
				}
				smethod_14(g, chart, chartPoint, list2);
				list2.Clear();
				Struct27.smethod_45(g, chart, list, renderContext);
				list.Clear();
			}
		}
		else
		{
			if ((chart.Rotation < 90 || chart.Rotation >= 180) && (chart.Rotation < 270 || chart.Rotation >= 360))
			{
				return;
			}
			for (int k = 0; k < list3.Count; k++)
			{
				int num13 = k;
				if (chart.Rotation >= 270 && chart.Rotation < 360)
				{
					num13 = list3.Count - 1 - num13;
				}
				if (renderContext.SeriesAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num13 = list3.Count - 1 - num13;
				}
				Class759 class3 = (Class759)list3[num13];
				int index2 = class3.Index;
				Class747 pointsInternal2 = class3.PointsInternal;
				Class748 chartPoint2 = null;
				for (int l = 0; l < count; l++)
				{
					int num14 = l;
					if (chart.Rotation >= 270 && chart.Rotation < 360)
					{
						num14 = count - 1 - num14;
					}
					int val2 = int.Parse(list4[num14].ToString());
					val2 = Struct21.smethod_38(baseUnitScale, val2, chart.IsDate1904);
					int num15 = Struct21.smethod_35(baseUnitScale, val2, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
					float num16 = num4 * (float)num15;
					float num17 = chart.WallsInternal.X + num16;
					if (flag)
					{
						num17 += num4 / 2f;
					}
					int num18 = num14;
					if (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num18 = count - 1 - num14;
					}
					Class748 class4 = pointsInternal2.method_0(num18);
					double yValue = class4.YValue;
					if (class4 != null && !class4.NotPlotted)
					{
						yValue = class4.YValue;
						chartPoint2 = class4;
					}
					float num19 = (float)(categoryAxisCrossAt - yValue) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
					if (renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
					{
						num19 = 0f - num19;
					}
					PointF[] array3 = Struct27.smethod_48(g, chart, categoryAxisY, 0f, num17, shapeDepth, index2 + 1, list3.Count, renderContext);
					list2.Add(array3);
					PointF[] array4 = Struct27.smethod_48(g, chart, categoryAxisY, num19, num17, shapeDepth, index2 + 1, list3.Count, renderContext);
					list2.Add(array4);
					if (class4 != null && !class4.NotPlotted)
					{
						PointF pointF2 = new PointF(0f, 0f);
						if (chart.Rotation >= 90 && chart.Rotation < 270)
						{
							pointF2.X = (array3[1].X + array4[1].X) / 2f;
							pointF2.Y = (array3[1].Y + array4[1].Y) / 2f;
						}
						else
						{
							pointF2.X = (array3[0].X + array4[0].X) / 2f;
							pointF2.Y = (array3[0].Y + array4[0].Y) / 2f;
						}
						list.Add(new object[3] { index2, num18, pointF2 });
					}
					else
					{
						list2.Add(null);
					}
				}
				smethod_14(g, chart, chartPoint2, list2);
				list2.Clear();
				Struct27.smethod_45(g, chart, list, renderContext);
				list.Clear();
			}
		}
	}

	internal static void smethod_12(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, int maxPointsCount, bool isPercent, Class784 renderContext)
	{
		if (maxPointsCount < 2)
		{
			return;
		}
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		if (renderContext.X1AxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			smethod_13(g, chart, categoryAxisY, categoryAxisCrossAt, isPercent, renderContext);
			return;
		}
		float num = (float)chart.DepthPercent / 100f;
		float num2 = (float)chart.GapDepth / 100f;
		float num3 = 0f;
		num3 = (renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed ? (chart.WallsInternal.Y - (float)y1AxisRenderContext.MaxValue / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height) : (chart.WallsInternal.Y - chart.WallsInternal.Height + (float)y1AxisRenderContext.MaxValue / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height));
		List<object[]> list = new List<object[]>();
		int num4 = 0;
		bool flag;
		if (flag = renderContext.X1AxisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
		{
			num4 = maxPointsCount;
		}
		else
		{
			num4 = maxPointsCount - 1;
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		float num5 = chart.WallsInternal.Width / (float)num4;
		float wallsDepth = num5 * num / (1f + num2);
		List<List<PointF[]>> list2 = new List<List<PointF[]>>();
		List<PointF[]> list3 = new List<PointF[]>();
		for (int i = 0; i < maxPointsCount; i++)
		{
			float num6 = chart.WallsInternal.X + num5 * (float)i;
			if (flag)
			{
				num6 += num5 / 2f;
			}
			PointF[] item = smethod_18(chart, num6, wallsDepth, categoryAxisY, g);
			list3.Add(item);
		}
		list2.Add(list3);
		IList list4 = nSeriesInternal.method_9();
		Class748[] array = new Class748[list4.Count];
		List<PointF[]> list5 = null;
		for (int j = 0; j < list4.Count; j++)
		{
			Class759 @class = (Class759)list4[j];
			int index = @class.Index;
			int num7 = j;
			Class747 pointsInternal = @class.PointsInternal;
			List<PointF[]> list6 = new List<PointF[]>();
			if (j == 0)
			{
				list5 = list3;
			}
			for (int k = 0; k < maxPointsCount; k++)
			{
				int num8 = k;
				float num9 = num5 * (float)num8;
				num9 = chart.WallsInternal.X + num9;
				if (flag)
				{
					num9 += num5 / 2f;
				}
				int num10 = num8;
				if (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num10 = maxPointsCount - 1 - num8;
				}
				Class748 class2 = pointsInternal.method_0(num10);
				double num11 = 0.0;
				double num12 = 0.0;
				double num13 = 0.0;
				if (class2 != null && !class2.NotPlotted)
				{
					array[j] = class2;
					num11 = class2.YValue;
					num12 = num11;
					for (int l = 0; l < num7; l++)
					{
						Class748 class3 = ((Class759)list4[l]).PointsInternal.method_0(num10);
						if (class3 != null)
						{
							double yValue = class3.YValue;
							num12 += yValue;
						}
					}
				}
				for (int m = 0; m < list4.Count; m++)
				{
					Class748 class4 = ((Class759)list4[m]).PointsInternal.method_0(num10);
					if (class4 != null)
					{
						double yValue2 = class4.YValue;
						num13 += Math.Abs(yValue2);
					}
				}
				float num14;
				if (!isPercent)
				{
					num14 = (float)Math.Abs(num12) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
				}
				else
				{
					if (num13 == 0.0)
					{
						continue;
					}
					num14 = (float)Math.Abs(num12) * 100f / (float)num13 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
				}
				float y = ((!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed) ? ((!(num12 <= 0.0)) ? (num3 - num14) : (num3 + num14)) : ((!(num12 <= 0.0)) ? (num3 + num14) : (num3 - num14)));
				PointF[] array2 = smethod_18(chart, num9, wallsDepth, y, g);
				list6.Add(array2);
				if (class2 != null && !class2.NotPlotted)
				{
					PointF pointF = new PointF(0f, 0f);
					PointF[] array3 = list5[num8];
					if (chart.Rotation >= 90 && chart.Rotation < 270)
					{
						pointF.X = array2[1].X;
						pointF.Y = (array3[1].Y + array2[1].Y) / 2f;
					}
					else
					{
						pointF.X = array2[0].X;
						pointF.Y = (array3[0].Y + array2[0].Y) / 2f;
					}
					list.Add(new object[3] { index, num10, pointF });
				}
			}
			list2.Add(list6);
			list5 = list6;
		}
		smethod_19(g, chart, array, list2, renderContext);
		Struct27.smethod_45(g, chart, list, renderContext);
	}

	internal static void smethod_13(Interface32 g, Class740 chart, float categoryAxisY, double categoryAxisCrossAt, bool isPercent, Class784 renderContext)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		float num = (float)chart.DepthPercent / 100f;
		float num2 = (float)chart.GapDepth / 100f;
		float num3 = 0f;
		num3 = (renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed ? (chart.WallsInternal.Y - (float)y1AxisRenderContext.MaxValue / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height) : (chart.WallsInternal.Y - chart.WallsInternal.Height + (float)y1AxisRenderContext.MaxValue / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height));
		List<object[]> list = new List<object[]>();
		TimeUnitType baseUnitScale = x1AxisRenderContext.Axis.BaseUnitScale;
		int minValue = (int)x1AxisRenderContext.MinValue;
		int maxValue = (int)x1AxisRenderContext.MaxValue;
		int num4 = 0;
		bool flag;
		if (flag = renderContext.X1AxisRenderContext.AxisBetweenCategories || renderContext.Chart.HasDataTable)
		{
			num4 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904) + 1;
		}
		else
		{
			num4 = Struct21.smethod_35(baseUnitScale, maxValue, minValue, chart.IsDate1904);
			if (num4 == 0)
			{
				num4 = 1;
			}
		}
		float num5 = chart.WallsInternal.Width / (float)num4;
		float wallsDepth = num5 * num / (1f + num2);
		List<int> list2 = Struct24.smethod_54(chart.NSeriesInternal.CategoryLabelsInternal, chart.IsDate1904);
		int count = list2.Count;
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		for (int i = 0; i < count; i++)
		{
			int val = int.Parse(list2[i].ToString());
			val = Struct21.smethod_38(baseUnitScale, val, chart.IsDate1904);
			int num6 = Struct21.smethod_35(baseUnitScale, val, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
			float num7 = num5 * (float)num6;
			float num8 = chart.WallsInternal.X + num7;
			if (flag)
			{
				num8 += num5 / 2f;
			}
			PointF[] value = smethod_18(chart, num8, wallsDepth, categoryAxisY, g);
			arrayList2.Add(value);
		}
		arrayList.Add(arrayList2);
		IList list3 = nSeriesInternal.method_9();
		Class748[] array = new Class748[list3.Count];
		ArrayList arrayList3 = null;
		for (int j = 0; j < list3.Count; j++)
		{
			Class759 @class = (Class759)list3[j];
			int index = @class.Index;
			int num9 = j;
			Class747 pointsInternal = @class.PointsInternal;
			ArrayList arrayList4 = new ArrayList();
			if (j == 0)
			{
				arrayList3 = arrayList2;
			}
			for (int k = 0; k < count; k++)
			{
				int num10 = k;
				int val2 = int.Parse(list2[num10].ToString());
				val2 = Struct21.smethod_38(baseUnitScale, val2, chart.IsDate1904);
				int num11 = Struct21.smethod_35(baseUnitScale, val2, (int)x1AxisRenderContext.MinValue, chart.IsDate1904);
				float num12 = num5 * (float)num11;
				float num13 = chart.WallsInternal.X + num12;
				if (flag)
				{
					num13 += num5 / 2f;
				}
				int num14 = num10;
				if (renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed)
				{
					num14 = count - 1 - num10;
				}
				Class748 class2 = pointsInternal.method_0(num14);
				double num15 = 0.0;
				double num16 = 0.0;
				double num17 = 0.0;
				if (class2 != null && !class2.NotPlotted)
				{
					array[j] = class2;
					num15 = class2.YValue;
					num16 = num15;
					for (int l = 0; l < num9; l++)
					{
						Class748 class3 = ((Class759)list3[l]).PointsInternal.method_0(num14);
						if (class3 != null)
						{
							double yValue = class3.YValue;
							num16 += yValue;
						}
					}
				}
				for (int m = 0; m < list3.Count; m++)
				{
					Class748 class4 = ((Class759)list3[m]).PointsInternal.method_0(num14);
					if (class4 != null && !class2.NotPlotted)
					{
						double yValue2 = class4.YValue;
						num17 += Math.Abs(yValue2);
					}
				}
				float num18;
				if (!isPercent)
				{
					num18 = (float)Math.Abs(num16) / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
				}
				else
				{
					if (num17 == 0.0)
					{
						continue;
					}
					num18 = (float)Math.Abs(num16) * 100f / (float)num17 / (float)(y1AxisRenderContext.MaxValue - y1AxisRenderContext.MinValue) * chart.WallsInternal.Height;
				}
				float y = ((!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed) ? ((!(num16 <= 0.0)) ? (num3 - num18) : (num3 + num18)) : ((!(num16 <= 0.0)) ? (num3 + num18) : (num3 - num18)));
				PointF[] array2 = smethod_18(chart, num13, wallsDepth, y, g);
				arrayList4.Add(array2);
				if (class2 != null && !class2.NotPlotted)
				{
					PointF pointF = new PointF(0f, 0f);
					PointF[] array3 = (PointF[])arrayList3[num10];
					if (chart.Rotation >= 90 && chart.Rotation < 270)
					{
						pointF.X = array2[1].X;
						pointF.Y = (array3[1].Y + array2[1].Y) / 2f;
					}
					else
					{
						pointF.X = array2[0].X;
						pointF.Y = (array3[0].Y + array2[0].Y) / 2f;
					}
					list.Add(new object[3] { index, num14, pointF });
				}
			}
			arrayList3 = arrayList4;
			arrayList.Add(arrayList4);
		}
		smethod_19(g, chart, array, arrayList, renderContext);
		Struct27.smethod_45(g, chart, list, renderContext);
	}

	private static void smethod_14(Interface32 g, Class740 chart, Class748 chartPoint, IList listLinePoints)
	{
		if (listLinePoints.Count < 4 || chartPoint == null)
		{
			return;
		}
		int num = listLinePoints.Count / 2;
		PointF[] array = new PointF[num];
		PointF[] array2 = new PointF[num];
		PointF[] array3 = new PointF[num];
		PointF[] array4 = new PointF[num];
		for (int i = 0; i < listLinePoints.Count; i += 2)
		{
			PointF[] array5 = (PointF[])listLinePoints[i];
			PointF[] array6 = (PointF[])listLinePoints[i + 1];
			ref PointF reference = ref array[i / 2];
			reference = array5[0];
			ref PointF reference2 = ref array2[i / 2];
			reference2 = array5[1];
			ref PointF reference3 = ref array3[i / 2];
			reference3 = array6[0];
			ref PointF reference4 = ref array4[i / 2];
			reference4 = array6[1];
		}
		for (int j = 1; j < num; j++)
		{
			PointF[] array7 = new PointF[8];
			if (smethod_15(array[j - 1], array[j], array3[j - 1], array3[j], out var crossPoint))
			{
				if (smethod_15(array2[j - 1], array2[j], array4[j - 1], array4[j], out var crossPoint2))
				{
					ref PointF reference5 = ref array7[0];
					reference5 = array[j - 1];
					array7[1] = crossPoint;
					array7[2] = crossPoint2;
					ref PointF reference6 = ref array7[3];
					reference6 = array2[j - 1];
					ref PointF reference7 = ref array7[4];
					reference7 = array3[j - 1];
					array7[5] = crossPoint;
					array7[6] = crossPoint2;
					ref PointF reference8 = ref array7[7];
					reference8 = array4[j - 1];
					smethod_16(g, chart, chartPoint, array7);
					array7[0] = crossPoint;
					ref PointF reference9 = ref array7[1];
					reference9 = array[j];
					ref PointF reference10 = ref array7[2];
					reference10 = array2[j];
					array7[3] = crossPoint2;
					array7[4] = crossPoint;
					ref PointF reference11 = ref array7[5];
					reference11 = array3[j];
					ref PointF reference12 = ref array7[6];
					reference12 = array4[j];
					array7[7] = crossPoint2;
					smethod_16(g, chart, chartPoint, array7);
				}
			}
			else
			{
				ref PointF reference13 = ref array7[0];
				reference13 = array[j - 1];
				ref PointF reference14 = ref array7[1];
				reference14 = array[j];
				ref PointF reference15 = ref array7[2];
				reference15 = array2[j];
				ref PointF reference16 = ref array7[3];
				reference16 = array2[j - 1];
				ref PointF reference17 = ref array7[4];
				reference17 = array3[j - 1];
				ref PointF reference18 = ref array7[5];
				reference18 = array3[j];
				ref PointF reference19 = ref array7[6];
				reference19 = array4[j];
				ref PointF reference20 = ref array7[7];
				reference20 = array4[j - 1];
				smethod_16(g, chart, chartPoint, array7);
			}
		}
		smethod_17(g, chart, chartPoint, array, array2, array3, array4);
	}

	private static bool smethod_15(PointF point1, PointF point2, PointF point3, PointF point4, out PointF crossPoint)
	{
		crossPoint = new PointF(0f, 0f);
		if (point1.X != point2.X && point3.X != point4.X)
		{
			float num = (point1.Y - point2.Y) / (point1.X - point2.X);
			float num2 = point1.Y - num * point1.X;
			float num3 = (point3.Y - point4.Y) / (point3.X - point4.X);
			float num4 = point3.Y - num3 * point3.X;
			if (num == num3)
			{
				return false;
			}
			crossPoint.X = (num4 - num2) / (num - num3);
			crossPoint.Y = num * crossPoint.X + num2;
			if ((point1.X < crossPoint.X && point2.X > crossPoint.X && point3.X < crossPoint.X && point4.X > crossPoint.X) || (point1.X > crossPoint.X && point2.X < crossPoint.X && point3.X > crossPoint.X && point4.X < crossPoint.X))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static void smethod_16(Interface32 g, Class740 chart, Class748 chartPoint, PointF[] points)
	{
		Class741 areaInternal = chartPoint.AreaInternal;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPolygon(points);
		chartPoint.BorderInternal.method_9(graphicsPath);
		bool flag = ((points[0].Y + points[1].Y + points[2].Y + points[3].Y > points[4].Y + points[5].Y + points[6].Y + points[7].Y) ? true : false);
		if (chart.Elevation > 0)
		{
			if (flag)
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddPolygon(new PointF[4]
				{
					points[0],
					points[1],
					points[2],
					points[3]
				});
				areaInternal.method_7(graphicsPath2, 2f / 3f);
				chartPoint.BorderInternal.method_8(graphicsPath2);
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddPolygon(new PointF[4]
				{
					points[4],
					points[5],
					points[6],
					points[7]
				});
				areaInternal.method_7(graphicsPath3, 2f / 3f);
				chartPoint.BorderInternal.method_8(graphicsPath3);
			}
			else
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddPolygon(new PointF[4]
				{
					points[4],
					points[5],
					points[6],
					points[7]
				});
				areaInternal.method_7(graphicsPath4, 2f / 3f);
				chartPoint.BorderInternal.method_8(graphicsPath4);
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddPolygon(new PointF[4]
				{
					points[0],
					points[1],
					points[2],
					points[3]
				});
				areaInternal.method_7(graphicsPath5, 2f / 3f);
				chartPoint.BorderInternal.method_8(graphicsPath5);
			}
		}
		else if (!flag)
		{
			GraphicsPath graphicsPath6 = new GraphicsPath();
			graphicsPath6.AddPolygon(new PointF[4]
			{
				points[0],
				points[1],
				points[2],
				points[3]
			});
			areaInternal.method_7(graphicsPath6, 2f / 3f);
			chartPoint.BorderInternal.method_8(graphicsPath6);
			GraphicsPath graphicsPath7 = new GraphicsPath();
			graphicsPath7.AddPolygon(new PointF[4]
			{
				points[4],
				points[5],
				points[6],
				points[7]
			});
			areaInternal.method_7(graphicsPath7, 2f / 3f);
			chartPoint.BorderInternal.method_8(graphicsPath7);
		}
		else
		{
			GraphicsPath graphicsPath8 = new GraphicsPath();
			graphicsPath8.AddPolygon(new PointF[4]
			{
				points[4],
				points[5],
				points[6],
				points[7]
			});
			areaInternal.method_7(graphicsPath8, 2f / 3f);
			chartPoint.BorderInternal.method_8(graphicsPath8);
			GraphicsPath graphicsPath9 = new GraphicsPath();
			graphicsPath9.AddPolygon(new PointF[4]
			{
				points[0],
				points[1],
				points[2],
				points[3]
			});
			areaInternal.method_7(graphicsPath9, 2f / 3f);
			chartPoint.BorderInternal.method_8(graphicsPath9);
		}
		if (chart.Rotation > 90 && chart.Rotation != 360)
		{
			if (chart.Rotation > 90 && chart.Rotation <= 180)
			{
				GraphicsPath graphicsPath10 = new GraphicsPath();
				graphicsPath10.AddPolygon(new PointF[4]
				{
					points[1],
					points[2],
					points[6],
					points[5]
				});
				areaInternal.method_7(graphicsPath10, 0.5f);
				chartPoint.BorderInternal.method_8(graphicsPath10);
			}
			else if (chart.Rotation > 180 && chart.Rotation <= 270)
			{
				GraphicsPath graphicsPath11 = new GraphicsPath();
				graphicsPath11.AddPolygon(new PointF[4]
				{
					points[1],
					points[2],
					points[6],
					points[5]
				});
				areaInternal.method_7(graphicsPath11, 0.5f);
				chartPoint.BorderInternal.method_8(graphicsPath11);
			}
			else if (chart.Rotation > 270 && chart.Rotation < 360)
			{
				GraphicsPath graphicsPath12 = new GraphicsPath();
				graphicsPath12.AddPolygon(new PointF[4]
				{
					points[1],
					points[2],
					points[6],
					points[5]
				});
				areaInternal.method_7(graphicsPath12, 0.5f);
				chartPoint.BorderInternal.method_8(graphicsPath12);
			}
		}
		else
		{
			GraphicsPath graphicsPath13 = new GraphicsPath();
			graphicsPath13.AddPolygon(new PointF[4]
			{
				points[1],
				points[2],
				points[6],
				points[5]
			});
			areaInternal.method_7(graphicsPath13, 0.5f);
			chartPoint.BorderInternal.method_8(graphicsPath13);
		}
	}

	private static void smethod_17(Interface32 g, Class740 chart, Class748 chartPoint, PointF[] points1, PointF[] points2, PointF[] points3, PointF[] points4)
	{
		Class741 areaInternal = chartPoint.AreaInternal;
		if (chart.Rotation > 90 && chart.Rotation != 360 && (chart.Rotation <= 270 || chart.Rotation >= 360))
		{
			if ((chart.Rotation > 90 && chart.Rotation <= 180) || (chart.Rotation > 180 && chart.Rotation <= 270))
			{
				PointF[] array = new PointF[points2.Length * 2];
				for (int i = 0; i < points2.Length; i++)
				{
					ref PointF reference = ref array[i];
					reference = points2[i];
					ref PointF reference2 = ref array[array.Length - 1 - i];
					reference2 = points4[i];
				}
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddPolygon(array);
				areaInternal.method_6(graphicsPath);
				chartPoint.BorderInternal.method_8(graphicsPath);
			}
		}
		else
		{
			PointF[] array2 = new PointF[points1.Length * 2];
			for (int j = 0; j < points1.Length; j++)
			{
				ref PointF reference3 = ref array2[j];
				reference3 = points1[j];
				ref PointF reference4 = ref array2[array2.Length - 1 - j];
				reference4 = points3[j];
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPolygon(array2);
			areaInternal.method_6(graphicsPath2);
			chartPoint.BorderInternal.method_8(graphicsPath2);
		}
	}

	private static PointF[] smethod_18(Class740 chart, float shapeX, float wallsDepth, float y, Interface32 g)
	{
		PointF[] array = new PointF[2];
		float xCenter = chart.WallsInternal.xCenter;
		if (shapeX <= xCenter)
		{
			float wallsWidth = 2f * (xCenter - shapeX);
			ref PointF reference = ref array[0];
			reference = Struct27.smethod_47(chart, y, wallsWidth, wallsDepth, 0);
			ref PointF reference2 = ref array[1];
			reference2 = Struct27.smethod_47(chart, y, wallsWidth, wallsDepth, 3);
		}
		else
		{
			float wallsWidth = 2f * (shapeX - xCenter);
			ref PointF reference3 = ref array[0];
			reference3 = Struct27.smethod_47(chart, y, wallsWidth, wallsDepth, 1);
			ref PointF reference4 = ref array[1];
			reference4 = Struct27.smethod_47(chart, y, wallsWidth, wallsDepth, 2);
		}
		return array;
	}

	private static void smethod_19(Interface32 g, Class740 chart, Class748[] chartPoints, IList seriesLinePoints, Class784 renderContext)
	{
		if (seriesLinePoints.Count < 2)
		{
			return;
		}
		IList list = (IList)seriesLinePoints[0];
		if (seriesLinePoints.Count < 2)
		{
			return;
		}
		IList seriesLinePoint = (IList)seriesLinePoints[seriesLinePoints.Count - 1];
		for (int i = 1; i < list.Count; i++)
		{
			if (chart.Elevation < 0)
			{
				continue;
			}
			int num = seriesLinePoints.Count - 1;
			Class748 @class = chartPoints[num - 1];
			Class741 areaInternal = @class.AreaInternal;
			PointF[] crossPoints;
			bool flag = smethod_21(seriesLinePoint, list, i, out crossPoints);
			if (!renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed)
			{
				if (smethod_20(seriesLinePoint, list, i))
				{
					IList list2 = (IList)seriesLinePoints[num];
					PointF[] array = new PointF[4];
					PointF[] array2 = (PointF[])list2[i - 1];
					ref PointF reference = ref array[0];
					reference = array2[0];
					ref PointF reference2 = ref array[1];
					reference2 = array2[1];
					array2 = (PointF[])list2[i];
					ref PointF reference3 = ref array[2];
					reference3 = array2[1];
					ref PointF reference4 = ref array[3];
					reference4 = array2[0];
					GraphicsPath graphicsPath = new GraphicsPath();
					graphicsPath.AddPolygon(array);
					areaInternal.method_7(graphicsPath, 2f / 3f);
					@class.BorderInternal.method_8(graphicsPath);
				}
			}
			else if (flag)
			{
				IList list3 = (IList)seriesLinePoints[num];
				PointF[] array3 = new PointF[4];
				PointF[] array4 = (PointF[])list3[i - 1];
				if (crossPoints[0].Y >= array4[0].Y)
				{
					PointF[] array5 = (PointF[])list[i - 1];
					ref PointF reference5 = ref array3[0];
					reference5 = array5[0];
					ref PointF reference6 = ref array3[1];
					reference6 = array5[1];
					ref PointF reference7 = ref array3[2];
					reference7 = crossPoints[1];
					ref PointF reference8 = ref array3[3];
					reference8 = crossPoints[0];
					GraphicsPath graphicsPath2 = new GraphicsPath();
					graphicsPath2.AddPolygon(array3);
					areaInternal.method_7(graphicsPath2, 2f / 3f);
					@class.BorderInternal.method_8(graphicsPath2);
				}
				else
				{
					ref PointF reference9 = ref array3[0];
					reference9 = array4[0];
					ref PointF reference10 = ref array3[1];
					reference10 = array4[1];
					ref PointF reference11 = ref array3[2];
					reference11 = crossPoints[1];
					ref PointF reference12 = ref array3[3];
					reference12 = crossPoints[0];
					GraphicsPath graphicsPath3 = new GraphicsPath();
					graphicsPath3.AddPolygon(array3);
					areaInternal.method_7(graphicsPath3, 2f / 3f);
					@class.BorderInternal.method_8(graphicsPath3);
				}
				array4 = (PointF[])list3[i];
				if (crossPoints[0].Y >= array4[0].Y)
				{
					PointF[] array6 = (PointF[])list[i];
					ref PointF reference13 = ref array3[0];
					reference13 = array6[0];
					ref PointF reference14 = ref array3[1];
					reference14 = array6[1];
					ref PointF reference15 = ref array3[2];
					reference15 = crossPoints[1];
					ref PointF reference16 = ref array3[3];
					reference16 = crossPoints[0];
					GraphicsPath graphicsPath4 = new GraphicsPath();
					graphicsPath4.AddPolygon(array3);
					areaInternal.method_7(graphicsPath4, 2f / 3f);
					@class.BorderInternal.method_8(graphicsPath4);
				}
				else
				{
					ref PointF reference17 = ref array3[0];
					reference17 = array4[0];
					ref PointF reference18 = ref array3[1];
					reference18 = array4[1];
					ref PointF reference19 = ref array3[2];
					reference19 = crossPoints[1];
					ref PointF reference20 = ref array3[3];
					reference20 = crossPoints[0];
					GraphicsPath graphicsPath5 = new GraphicsPath();
					graphicsPath5.AddPolygon(array3);
					areaInternal.method_7(graphicsPath5, 2f / 3f);
					@class.BorderInternal.method_8(graphicsPath5);
				}
			}
		}
		for (int j = 1; j < seriesLinePoints.Count; j++)
		{
			Class748 class2 = chartPoints[j - 1];
			Class741 areaInternal2 = class2.AreaInternal;
			IList list4 = (IList)seriesLinePoints[j - 1];
			IList list5 = (IList)seriesLinePoints[j];
			PointF[] array7;
			PointF[] array8;
			if (chart.Rotation <= 180)
			{
				array7 = (PointF[])list4[list4.Count - 1];
				array8 = (PointF[])list5[list5.Count - 1];
			}
			else
			{
				array7 = (PointF[])list4[0];
				array8 = (PointF[])list5[0];
			}
			GraphicsPath graphicsPath6 = new GraphicsPath();
			graphicsPath6.AddPolygon(new PointF[4]
			{
				array7[0],
				array7[1],
				array8[1],
				array8[0]
			});
			areaInternal2.method_7(graphicsPath6, 0.5f);
			class2.BorderInternal.method_8(graphicsPath6);
		}
		for (int k = 1; k < seriesLinePoints.Count; k++)
		{
			Class748 class3 = chartPoints[k - 1];
			Class741 areaInternal3 = class3.AreaInternal;
			IList list6 = (IList)seriesLinePoints[k - 1];
			IList list7 = (IList)seriesLinePoints[k];
			int num2 = list7.Count * 2;
			PointF[] array9 = new PointF[num2];
			for (int l = 0; l < list6.Count; l++)
			{
				PointF[] array10 = (PointF[])list6[l];
				PointF[] array11 = (PointF[])list7[l];
				if (chart.Rotation > 90 && chart.Rotation != 360 && (chart.Rotation <= 270 || chart.Rotation >= 360))
				{
					ref PointF reference21 = ref array9[l];
					reference21 = array10[1];
					ref PointF reference22 = ref array9[num2 - l - 1];
					reference22 = array11[1];
				}
				else
				{
					ref PointF reference23 = ref array9[l];
					reference23 = array10[0];
					ref PointF reference24 = ref array9[num2 - l - 1];
					reference24 = array11[0];
				}
			}
			GraphicsPath graphicsPath7 = new GraphicsPath();
			graphicsPath7.AddPolygon(array9);
			areaInternal3.method_6(graphicsPath7);
			class3.BorderInternal.method_8(graphicsPath7);
		}
	}

	private static bool smethod_20(IList seriesLinePoint1, IList seriesLinePoint0, int j)
	{
		PointF pointF = ((PointF[])seriesLinePoint1[j - 1])[0];
		PointF pointF2 = ((PointF[])seriesLinePoint1[j])[0];
		PointF pointF3 = ((PointF[])seriesLinePoint0[j - 1])[0];
		PointF pointF4 = ((PointF[])seriesLinePoint0[j])[0];
		if (pointF.Y < pointF3.Y && pointF2.Y < pointF4.Y)
		{
			return true;
		}
		return false;
	}

	private static bool smethod_21(IList seriesLinePoint1, IList seriesLinePoint0, int j, out PointF[] crossPoints)
	{
		PointF point = ((PointF[])seriesLinePoint1[j - 1])[0];
		PointF point2 = ((PointF[])seriesLinePoint1[j])[0];
		PointF point3 = ((PointF[])seriesLinePoint0[j - 1])[0];
		PointF point4 = ((PointF[])seriesLinePoint0[j])[0];
		PointF crossPoint;
		bool result = smethod_15(point, point2, point3, point4, out crossPoint);
		point = ((PointF[])seriesLinePoint1[j - 1])[1];
		point2 = ((PointF[])seriesLinePoint1[j])[1];
		point3 = ((PointF[])seriesLinePoint0[j - 1])[1];
		point4 = ((PointF[])seriesLinePoint0[j])[1];
		smethod_15(point, point2, point3, point4, out var crossPoint2);
		crossPoints = new PointF[2];
		crossPoints[0] = crossPoint;
		crossPoints[1] = crossPoint2;
		return result;
	}
}
