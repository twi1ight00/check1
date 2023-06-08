using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns2;
using ns221;
using ns33;
using ns35;
using ns36;
using ns37;
using ns40;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct24
{
	public static int int_0 = 10;

	public static int int_1 = 8;

	internal static void smethod_0(Class740 chart, Chart sourceChart, Class784 renderContext)
	{
		Interface32 graphics = chart.Graphics;
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 x2AxisRenderContext = renderContext.X2AxisRenderContext;
		Class783 y1AxisRenderContext = renderContext.Y1AxisRenderContext;
		Class783 y2AxisRenderContext = renderContext.Y2AxisRenderContext;
		if (chart.NSeriesInternal.Count == 0 || smethod_23(chart.NSeriesInternal.ListSeries) == 0)
		{
			return;
		}
		string text = smethod_2(chart);
		if (text != "")
		{
			throw new ArgumentException(text);
		}
		smethod_4(chart);
		Class757 @class = new Class757(chart);
		Class757 class2 = new Class757(chart);
		foreach (Class759 item in nSeriesInternal)
		{
			if (item.AxisGroup == Enum141.const_0)
			{
				@class.Add(item);
			}
			else
			{
				class2.Add(item);
			}
		}
		if (chart.NSeries.CategoryLabels.Count > 0)
		{
			chart.NSeriesInternal.bool_0 = true;
		}
		if (chart.NSeries.Category2Labels.Count > 0)
		{
			chart.NSeriesInternal.bool_1 = true;
		}
		chart.NSeriesInternal.Categories = smethod_64(chart.NSeriesInternal.CategoryLabels);
		chart.NSeriesInternal.Categories2 = smethod_64(chart.NSeriesInternal.Category2Labels);
		chart.NSeriesInternal.CategoryLabelsInternal = smethod_65(chart.NSeriesInternal.CategoryLabels);
		chart.NSeriesInternal.Category2LabelsInternal = smethod_65(chart.NSeriesInternal.Category2Labels);
		if (x2AxisRenderContext.Axis != null && x2AxisRenderContext.Axis.IsVisible && smethod_61(chart))
		{
			smethod_62(renderContext);
			smethod_63(chart);
		}
		Struct41.smethod_2(x1AxisRenderContext, chart.NSeriesInternal.CategoryLabelsInternal, @class);
		Struct41.smethod_2(x2AxisRenderContext, chart.NSeriesInternal.CategoryLabelsInternal, @class);
		Class759 class4 = @class.method_0(0);
		Class759 class5 = new Class759(chart, null, ChartType.ClusteredColumn);
		if (class2.Count > 0)
		{
			class5 = (Class759)class2[0];
		}
		Struct41.smethod_8(@class, class4, x1AxisRenderContext, y1AxisRenderContext);
		Struct41.smethod_8(class2, class5, x1AxisRenderContext, y1AxisRenderContext);
		bool flag = smethod_8(class4.ResembleType);
		bool flag2 = smethod_8(class5.ResembleType);
		smethod_6(chart);
		Rectangle rect = new Rectangle(int_0 + chart.Position.X, int_0 + chart.Position.Y, chart.Position.Width - int_0 * 2, chart.Position.Height - int_0 * 2);
		if (sourceChart.HasTitle)
		{
			SizeF layoutArea = new SizeF((float)rect.Width * 0.8f, (float)rect.Height * 0.5f);
			Size size = renderContext.ChartTitleRenderContext.method_0(layoutArea, graphics);
			renderContext.ChartTitleRenderContext.rectangle_0 = new Rectangle((chart.Position.Width - size.Width) / 2, int_0, size.Width, size.Height);
			rect.Y += size.Height + int_1;
			rect.Height -= size.Height + int_1;
		}
		if (sourceChart.HasLegend)
		{
			if (class2.Count == 0 && (class4.ResembleType == ChartType.Pie || class4.ResembleType == ChartType.Doughnut || renderContext.LegendRenderContext.IsRenderedLegendByPoint))
			{
				Class759 class6 = class4;
				if (class4.Type == ChartType.Doughnut || class4.Type == ChartType.ExplodedDoughnut)
				{
					for (int i = 1; i < chart.NSeriesInternal.Count; i++)
					{
						if (chart.NSeriesInternal[i].Points != null && class6.PointsInternal != null && chart.NSeriesInternal[i].Points.Count > class6.PointsInternal.Count)
						{
							class6 = chart.NSeriesInternal.method_0(i);
						}
					}
				}
				Struct31.smethod_17(graphics, class6, ref rect, (Legend)sourceChart.Legend, renderContext);
			}
			else
			{
				Struct31.smethod_18(graphics, ref rect, (Legend)sourceChart.Legend, renderContext);
			}
		}
		if (x1AxisRenderContext.Axis != null && renderContext.X1AxisRenderContext.Axis.HasTitle)
		{
			smethod_9(x1AxisRenderContext, flag);
			SizeF sizeF = default(SizeF);
			sizeF = ((!flag) ? new SizeF((float)chart.Width * 0.8f, (float)chart.Height * 0.8f) : new SizeF((float)chart.Width * 0.8f, (float)chart.Height * 0.8f));
			Size titleSizeIn = x1AxisRenderContext.AxisTitleRenderContext.method_0(sizeF, graphics);
			if (y1AxisRenderContext.Axis.CrossType == CrossesType.Maximum && !y1AxisRenderContext.Axis.IsPlotOrderReversed)
			{
				x1AxisRenderContext.bool_5 = false;
			}
			else if (y1AxisRenderContext.Axis.CrossType != CrossesType.Maximum && y1AxisRenderContext.Axis.IsPlotOrderReversed)
			{
				x1AxisRenderContext.bool_5 = false;
			}
			smethod_11(x1AxisRenderContext, ref rect, flag, titleSizeIn);
		}
		if (y1AxisRenderContext.Axis != null && y1AxisRenderContext.Axis.HasTitle)
		{
			smethod_9(y1AxisRenderContext, flag);
			SizeF sizeF2 = default(SizeF);
			sizeF2 = ((!flag) ? new SizeF((float)chart.Width * 0.8f, (float)chart.Height * 0.8f) : new SizeF((float)chart.Width * 0.8f, (float)chart.Height * 0.8f));
			Size titleSizeIn2 = y1AxisRenderContext.AxisTitleRenderContext.method_0(sizeF2, graphics);
			if (x1AxisRenderContext.Axis.CrossType == CrossesType.Maximum && !x1AxisRenderContext.Axis.IsPlotOrderReversed)
			{
				y1AxisRenderContext.bool_5 = false;
			}
			else if (x1AxisRenderContext.Axis.CrossType != CrossesType.Maximum && x1AxisRenderContext.Axis.IsPlotOrderReversed)
			{
				y1AxisRenderContext.bool_5 = false;
			}
			smethod_11(y1AxisRenderContext, ref rect, flag, titleSizeIn2);
		}
		if (x2AxisRenderContext.Axis != null && x2AxisRenderContext.Axis.HasTitle && class2.Count > 0)
		{
			smethod_9(x2AxisRenderContext, flag2);
			SizeF sizeF3 = default(SizeF);
			sizeF3 = ((!flag) ? new SizeF((float)chart.Width * 0.8f, (float)chart.Height * 0.8f) : new SizeF((float)chart.Width * 0.8f, (float)chart.Height * 0.8f));
			Size titleSizeIn3 = x2AxisRenderContext.AxisTitleRenderContext.method_0(sizeF3, graphics);
			if (flag == flag2)
			{
				x2AxisRenderContext.bool_5 = !x1AxisRenderContext.bool_5;
			}
			else
			{
				x2AxisRenderContext.bool_5 = !y1AxisRenderContext.bool_5;
			}
			smethod_11(x2AxisRenderContext, ref rect, flag2, titleSizeIn3);
		}
		if (y2AxisRenderContext.Axis != null && y2AxisRenderContext.Axis.HasTitle && class2.Count > 0)
		{
			smethod_9(renderContext.Y2AxisRenderContext, flag2);
			SizeF sizeF4 = default(SizeF);
			sizeF4 = ((!flag) ? new SizeF((float)chart.Width * 0.8f, (float)chart.Height * 0.8f) : new SizeF((float)chart.Width * 0.8f, (float)chart.Height * 0.8f));
			Size titleSizeIn4 = y2AxisRenderContext.AxisTitleRenderContext.method_0(sizeF4, graphics);
			if (flag == flag2)
			{
				y2AxisRenderContext.bool_5 = !y1AxisRenderContext.bool_5;
			}
			else
			{
				y2AxisRenderContext.bool_5 = !x1AxisRenderContext.bool_5;
			}
			smethod_11(y2AxisRenderContext, ref rect, flag2, titleSizeIn4);
		}
		Struct31.smethod_4((Legend)sourceChart.Legend, rect, renderContext);
		if (!chart.PlotAreaInternal.IsSizeAuto)
		{
			if (chart.PlotAreaInternal.Rectangle.Y < 0)
			{
				chart.PlotAreaInternal.Height += chart.PlotAreaInternal.Rectangle.Y;
				chart.PlotAreaInternal.Y = 0;
			}
			if (chart.PlotAreaInternal.Rectangle.X < 0)
			{
				chart.PlotAreaInternal.Width += chart.PlotAreaInternal.Rectangle.X;
				chart.PlotAreaInternal.X = 0;
			}
			if (chart.PlotAreaInternal.Width + chart.PlotAreaInternal.X > 4000)
			{
				chart.PlotAreaInternal.Width = 4000 - chart.PlotAreaInternal.X;
			}
			if (chart.PlotAreaInternal.Height + chart.PlotAreaInternal.Y > 4000)
			{
				chart.PlotAreaInternal.Height = 4000 - chart.PlotAreaInternal.Y;
			}
			rect.X = chart.PlotAreaInternal.method_4();
			rect.Y = chart.PlotAreaInternal.method_5();
			rect.Width = chart.PlotAreaInternal.method_2();
			rect.Height = chart.PlotAreaInternal.method_3();
			if (rect.Right > chart.Width)
			{
				rect.Width = chart.Width - rect.X;
			}
			if (rect.Bottom > chart.Height)
			{
				rect.Height = chart.Height - rect.Y;
			}
		}
		chart.method_1(rect.X, rect.Y, rect.Width, rect.Height);
		chart.PlotAreaInternal.rectangle_1 = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		Rectangle rectangle = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		bool flag3 = false;
		bool flag4 = smethod_50(renderContext.X1AxisRenderContext);
		if (!Struct41.smethod_21(rect) && renderContext.Chart.HasDataTable)
		{
			Class786 dataTableRenderContext = renderContext.DataTableRenderContext;
			if (!flag && !flag2 && !flag4)
			{
				x1AxisRenderContext.int_5 = 0;
				x2AxisRenderContext.int_5 = 0;
				flag3 = true;
			}
			Size size3 = (dataTableRenderContext.LegendSize = Struct26.smethod_4(graphics, renderContext));
			smethod_46(graphics, x1AxisRenderContext.arrayList_0, rect, class4.ResembleType, @class, flag, renderContext.X1AxisRenderContext);
			int num2 = (dataTableRenderContext.CategoryLabelHeight = Struct26.smethod_6(graphics, rect, renderContext));
			int num3 = size3.Height + num2;
			if (chart.PlotAreaInternal.IsSizeAuto)
			{
				rect.X += size3.Width;
				rect.Width -= size3.Width;
				rect.Height -= num3;
				if (flag4)
				{
					dataTableRenderContext.rectangle_1.X = rect.X;
					dataTableRenderContext.rectangle_1.Y = rect.Bottom;
					dataTableRenderContext.rectangle_1.Width = rect.Width;
					rect.Height -= int_1;
				}
			}
			else
			{
				chart.int_12 -= size3.Width;
				chart.int_14 += size3.Width;
				chart.int_15 += num3;
			}
		}
		int maxPointsCount = smethod_23(@class.ListSeries);
		int maxPointsCount2 = smethod_23(class2.ListSeries);
		Class783 class7 = new Class783(null, null, Enum160.const_2);
		double minValue;
		double maxValue;
		if (smethod_29(renderContext, @class.ListSeries, class2.ListSeries))
		{
			class7 = ((y1AxisRenderContext.Axis == null || !y1AxisRenderContext.Axis.IsVisible || (y2AxisRenderContext.Axis != null && y2AxisRenderContext.Axis.IsVisible)) ? y2AxisRenderContext : y1AxisRenderContext);
			smethod_31(@class.ListSeries, class2.ListSeries, out minValue, out maxValue, class7);
			chart.bool_8 = true;
		}
		else
		{
			smethod_24(@class.ListSeries, out minValue, out maxValue, renderContext.Y1AxisRenderContext);
		}
		bool flag5 = y1AxisRenderContext.Axis == null || y1AxisRenderContext.IsAutoMajorUnit;
		bool flag6 = y1AxisRenderContext.Axis == null || y1AxisRenderContext.IsAutoMinorUnit;
		if (chart.bool_8)
		{
			if (class7 == renderContext.Y1AxisRenderContext)
			{
				smethod_33(graphics, maxValue, minValue, y1AxisRenderContext.arrayList_0, class4.ResembleType, rect, flag, @class.method_0(0), y1AxisRenderContext);
			}
			else
			{
				smethod_33(graphics, maxValue, minValue, y2AxisRenderContext.arrayList_0, class5.ResembleType, rect, flag2, class2.method_0(0), y2AxisRenderContext);
			}
			if (class4.IsRardarSeries && class5.IsRardarSeries)
			{
				smethod_24(@class.ListSeries, out var minValue2, out var maxValue2, y1AxisRenderContext);
				smethod_33(graphics, maxValue2, minValue2, y1AxisRenderContext.arrayList_0, class4.ResembleType, rect, flag, @class.method_0(0), y1AxisRenderContext);
				smethod_24(class2.ListSeries, out minValue2, out maxValue2, y2AxisRenderContext);
				smethod_33(graphics, maxValue2, minValue2, y1AxisRenderContext.arrayList_0, class5.ResembleType, rect, flag2, class2.method_0(0), y2AxisRenderContext);
			}
			Class783 class8 = smethod_30(renderContext);
			if (class7 != null)
			{
				class8.MaxValue = class7.MaxValue;
				class8.MinValue = class7.MinValue;
			}
		}
		else
		{
			smethod_33(graphics, maxValue, minValue, y1AxisRenderContext.arrayList_0, class4.ResembleType, rect, flag, @class.method_0(0), y1AxisRenderContext);
		}
		bool flag7 = x1AxisRenderContext.Axis == null || x1AxisRenderContext.IsAutoMajorUnit;
		bool flag8 = x1AxisRenderContext.Axis == null || x1AxisRenderContext.IsAutoMinorUnit;
		smethod_46(graphics, x1AxisRenderContext.arrayList_0, rect, class4.ResembleType, @class, flag, x1AxisRenderContext);
		smethod_22(@class, x1AxisRenderContext);
		if (!Struct41.smethod_21(rect) && y1AxisRenderContext.Axis != null && class4.ResembleType != ChartType.Radar && class4.ResembleType != ChartType.FilledRadar)
		{
			smethod_16(y1AxisRenderContext, @class, chart, x1AxisRenderContext);
			Size labelSize = Struct21.smethod_21(y1AxisRenderContext, graphics, class4, flag);
			smethod_10(y1AxisRenderContext, flag);
			SizeF sizeF5 = default(SizeF);
			sizeF5 = (flag ? new SizeF(rectangle.Width, rectangle.Height) : new SizeF(rectangle.Width, rectangle.Height));
			Size displayUnitSize = y1AxisRenderContext.DisplayUnitInternal.method_1(sizeF5);
			smethod_17(chart, graphics, labelSize, displayUnitSize, ref rect, flag, y1AxisRenderContext, renderContext.DataTableRenderContext);
		}
		if (!Struct41.smethod_21(rect) && !flag3 && x1AxisRenderContext.Axis != null && x1AxisRenderContext.Axis.IsVisible && class4.ResembleType != ChartType.Radar && class4.ResembleType != ChartType.FilledRadar)
		{
			smethod_16(x1AxisRenderContext, @class, chart, y1AxisRenderContext);
			Size labelSize2 = Struct21.smethod_23(x1AxisRenderContext, graphics, rect, maxPointsCount, flag, class4);
			float size4 = renderContext.X1AxisRenderContext.TickLabelTextFont.Size;
			int num4 = (int)Struct21.smethod_1(size4);
			if (x1AxisRenderContext.TickLabelsOffsetPixel != 0)
			{
				num4 = (int)((double)((float)renderContext.X1AxisRenderContext.TickLabelsOffsetPixel + Struct21.smethod_0(size4) + Struct21.smethod_1(size4)) + 0.5);
			}
			if (chart.NSeriesInternal.Categories != null)
			{
				num4 += num4 * chart.NSeriesInternal.Categories.Length;
			}
			if (class4.ResembleType == ChartType.ScatterWithMarkers || class4.ResembleType == ChartType.Bubble)
			{
				smethod_10(x1AxisRenderContext, flag);
				SizeF sizeF6 = default(SizeF);
				sizeF6 = ((!flag) ? new SizeF(rectangle.Width, rectangle.Height) : new SizeF(rectangle.Width, rectangle.Height));
				num4 += x1AxisRenderContext.DisplayUnitInternal.method_1(sizeF6).Height;
			}
			smethod_19(chart, graphics, labelSize2, num4, ref rect, flag, flag4, renderContext, x1AxisRenderContext);
			if (chart.PlotAreaInternal.IsSizeAuto && y1AxisRenderContext.Axis != null && y1AxisRenderContext.Axis.IsVisible && class4.ResembleType != ChartType.Radar && class4.ResembleType != ChartType.FilledRadar)
			{
				float num5 = smethod_37(graphics, flag, class4, rect, y1AxisRenderContext);
				int num6 = 0;
				num6 = ((!flag) ? rect.Height : rect.Width);
				if (flag5 && y1AxisRenderContext.arrayList_0.Count > 3 && num5 > (float)num6 && num6 != 0)
				{
					y1AxisRenderContext.arrayList_0.Clear();
					y1AxisRenderContext.IsAutoMajorUnit = flag5;
					y1AxisRenderContext.IsAutoMinorUnit = flag6;
					smethod_33(graphics, maxValue, minValue, y1AxisRenderContext.arrayList_0, class4.ResembleType, rect, flag, @class.method_0(0), y1AxisRenderContext);
					Struct21.smethod_21(y1AxisRenderContext, graphics, class4, flag);
				}
			}
		}
		if (class2.Count > 0)
		{
			if (!chart.bool_8)
			{
				smethod_24(class2.ListSeries, out var minValue3, out var maxValue3, renderContext.Y2AxisRenderContext);
				smethod_33(graphics, maxValue3, minValue3, y2AxisRenderContext.arrayList_0, class5.ResembleType, rect, flag2, class2.method_0(0), y2AxisRenderContext);
			}
			smethod_22(class2, y2AxisRenderContext);
			smethod_46(graphics, x2AxisRenderContext.arrayList_0, rect, class5.ResembleType, class2, flag2, x2AxisRenderContext);
			smethod_22(class2, x2AxisRenderContext);
			if (!Struct41.smethod_21(rect) && y2AxisRenderContext.Axis != null && y2AxisRenderContext.Axis.IsVisible && class5.ResembleType != ChartType.Radar && class5.ResembleType != ChartType.FilledRadar)
			{
				smethod_16(y2AxisRenderContext, class2, chart, x2AxisRenderContext);
				Size labelSize3 = Struct21.smethod_21(y2AxisRenderContext, graphics, class5, flag2);
				smethod_10(y2AxisRenderContext, flag2);
				SizeF layout = new SizeF(rectangle.Width, rectangle.Height);
				Size displayUnitSize2 = y2AxisRenderContext.DisplayUnitInternal.method_1(layout);
				if (flag == flag2)
				{
					if (y2AxisRenderContext.int_5 != 3 && y2AxisRenderContext.int_5 == y1AxisRenderContext.int_5)
					{
						y2AxisRenderContext.int_5 = 0;
					}
				}
				else if (y2AxisRenderContext.int_5 != 3 && y2AxisRenderContext.int_5 == x1AxisRenderContext.int_5)
				{
					y2AxisRenderContext.int_5 = 0;
				}
				smethod_17(chart, graphics, labelSize3, displayUnitSize2, ref rect, flag2, y2AxisRenderContext, renderContext.DataTableRenderContext);
			}
			if (!Struct41.smethod_21(rect) && !flag3 && x2AxisRenderContext.Axis != null && x2AxisRenderContext.Axis.IsVisible && class5.ResembleType != ChartType.Radar && class5.ResembleType != ChartType.FilledRadar)
			{
				smethod_16(x2AxisRenderContext, class2, chart, y2AxisRenderContext);
				Size labelSize4 = Struct21.smethod_23(x2AxisRenderContext, graphics, rect, maxPointsCount2, flag2, class5);
				float size5 = x2AxisRenderContext.TickLabelTextFont.Size;
				int num7 = (int)((double)((float)x2AxisRenderContext.TickLabelsOffsetPixel + Struct21.smethod_0(size5) + Struct21.smethod_1(size5)) + 0.5);
				if (class5.ResembleType == ChartType.ScatterWithMarkers || class5.ResembleType == ChartType.Bubble)
				{
					smethod_10(x1AxisRenderContext, flag2);
					SizeF sizeF7 = default(SizeF);
					sizeF7 = ((!flag2) ? new SizeF(rectangle.Width, rectangle.Height) : new SizeF(rectangle.Width, rectangle.Height));
					num7 += x1AxisRenderContext.DisplayUnitInternal.method_1(sizeF7).Height;
				}
				if (flag == flag2)
				{
					if (x2AxisRenderContext.int_5 != 3 && x2AxisRenderContext.int_5 == x1AxisRenderContext.int_5)
					{
						x2AxisRenderContext.int_5 = 0;
					}
				}
				else if (x2AxisRenderContext.int_5 != 3 && x2AxisRenderContext.int_5 == y1AxisRenderContext.int_5)
				{
					x2AxisRenderContext.int_5 = 0;
				}
				smethod_19(chart, graphics, labelSize4, num7, ref rect, flag2, flag4, renderContext, x2AxisRenderContext);
			}
		}
		if (!Struct41.smethod_21(rect) && y1AxisRenderContext.Axis != null && y1AxisRenderContext.Axis.IsVisible && y1AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && class4.ResembleType != ChartType.Radar && class4.ResembleType != ChartType.FilledRadar)
		{
			Struct21.smethod_31(graphics, class4, flag, y1AxisRenderContext);
			float float_ = y1AxisRenderContext.float_5;
			float float_2 = y1AxisRenderContext.float_6;
			if (!flag)
			{
				if (chart.PlotAreaInternal.IsSizeAuto)
				{
					if ((float)(rect.Y - rectangle.Y) < float_2)
					{
						int num8 = (int)(float_2 - (float)(rect.Y - rectangle.Y));
						rect.Y += num8;
						rect.Height -= num8;
					}
					if ((float)(rectangle.Bottom - rect.Bottom) < float_)
					{
						int num9 = (int)(float_ - (float)(rectangle.Bottom - rect.Bottom));
						rect.Height -= num9;
					}
				}
				else
				{
					if ((float)(rect.Y - chart.int_13) < float_2)
					{
						int num10 = (int)(float_2 - (float)(rect.Y - chart.int_13));
						chart.int_13 -= num10;
						chart.int_15 += num10;
					}
					if ((float)(chart.int_13 + chart.int_15 - rect.Bottom) < float_)
					{
						int num11 = (int)(float_ - (float)(chart.int_13 + chart.int_15 - rect.Bottom));
						chart.int_15 += num11;
					}
				}
			}
			else if (chart.PlotAreaInternal.IsSizeAuto)
			{
				if ((float)(rect.X - rectangle.X) < float_)
				{
					int num12 = (int)(float_ - (float)(rect.X - rectangle.X));
					rect.X += num12;
					rect.Width -= num12;
				}
				if ((float)(rectangle.Right - rect.Right) < float_2)
				{
					int num13 = (int)(float_2 - (float)(rectangle.Right - rect.Right));
					rect.Width -= num13;
				}
			}
			else
			{
				if ((float)(rect.X - chart.int_12) < float_)
				{
					int num14 = (int)(float_ - (float)(rect.X - chart.int_12));
					chart.int_12 -= num14;
					chart.int_14 += num14;
				}
				if ((float)(chart.int_12 + chart.int_14 - rect.Right) < float_2)
				{
					int num15 = (int)(float_2 - (float)(chart.int_12 + chart.int_14 - rect.Right));
					chart.int_14 += num15;
				}
			}
		}
		if (!Struct41.smethod_21(rect) && x1AxisRenderContext.Axis != null && x1AxisRenderContext.Axis.IsVisible && x1AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && class4.ResembleType != ChartType.Radar && class4.ResembleType != ChartType.FilledRadar && (x1AxisRenderContext.float_5 > 0f || x1AxisRenderContext.float_6 > 0f))
		{
			float float_3 = x1AxisRenderContext.float_5;
			float float_4 = x1AxisRenderContext.float_6;
			if (flag)
			{
				if (chart.PlotAreaInternal.IsSizeAuto)
				{
					if ((float)(rect.Y - rectangle.Y) < float_4)
					{
						int num16 = (int)(float_4 - (float)(rect.Y - rectangle.Y));
						rect.Y += num16;
						rect.Height -= num16;
					}
					if ((float)(rectangle.Bottom - rect.Bottom) < float_3)
					{
						int num17 = (int)(float_3 - (float)(rectangle.Bottom - rect.Bottom));
						rect.Height -= num17;
					}
				}
				else
				{
					if ((float)(rect.Y - chart.int_13) < float_4)
					{
						int num18 = (int)(float_4 - (float)(rect.Y - chart.int_13));
						chart.int_13 -= num18;
						chart.int_15 += num18;
					}
					if ((float)(chart.int_13 + chart.int_15 - rect.Bottom) < float_3)
					{
						int num19 = (int)(float_3 - (float)(chart.int_13 + chart.int_15 - rect.Bottom));
						chart.int_15 += num19;
					}
				}
			}
			else if (chart.PlotAreaInternal.IsSizeAuto)
			{
				if ((float)(rect.X - rectangle.X) < float_3)
				{
					int num20 = (int)(float_3 - (float)(rect.X - rectangle.X));
					rect.X += num20;
					rect.Width -= num20;
				}
				if ((float)(rectangle.Right - rect.Right) < float_4)
				{
					int num21 = (int)(float_4 - (float)(rectangle.Right - rect.Right));
					rect.Width -= num21;
				}
			}
			else
			{
				if ((float)(rect.X - chart.int_12) < float_3)
				{
					int num22 = (int)(float_3 - (float)(rect.X - chart.int_12));
					chart.int_12 -= num22;
					chart.int_14 += num22;
				}
				if ((float)(chart.int_12 + chart.int_14 - rect.Right) < float_4)
				{
					int num23 = (int)(float_4 - (float)(chart.int_12 + chart.int_14 - rect.Right));
					chart.int_14 += num23;
				}
			}
		}
		if (class2.Count > 0)
		{
			if (!Struct41.smethod_21(rect) && chart.PlotAreaInternal.IsSizeAuto && y2AxisRenderContext.Axis != null && y2AxisRenderContext.Axis.IsVisible && y2AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && class5.ResembleType != ChartType.Radar && class5.ResembleType != ChartType.FilledRadar)
			{
				if (!flag2)
				{
					float num24 = y2AxisRenderContext.float_2 / 2f;
					if ((float)(rect.Y - rectangle.Y) < num24)
					{
						int num25 = (int)(num24 - (float)(rect.Y - rectangle.Y));
						rect.Y += num25;
						rect.Height -= num25;
					}
					if ((float)(rectangle.Bottom - rect.Bottom) < num24)
					{
						int num26 = (int)(num24 - (float)(rectangle.Bottom - rect.Bottom));
						rect.Height -= num26;
					}
				}
				else
				{
					float num27 = y2AxisRenderContext.float_1 / 2f;
					if ((float)(rect.X - rectangle.X) < num27)
					{
						int num28 = (int)(num27 - (float)(rect.X - rectangle.X));
						rect.X += num28;
						rect.Width -= num28;
					}
					if ((float)(rectangle.Right - rect.Right) < num27)
					{
						int num29 = (int)(num27 - (float)(rectangle.Right - rect.Right));
						rect.Width -= num29;
					}
				}
			}
			if (!Struct41.smethod_21(rect) && chart.PlotAreaInternal.IsSizeAuto && x2AxisRenderContext.Axis != null && x2AxisRenderContext.Axis.IsVisible && x2AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None && class5.ResembleType != ChartType.Radar && class5.ResembleType != ChartType.FilledRadar && (x2AxisRenderContext.float_5 > 0f || x2AxisRenderContext.float_6 > 0f))
			{
				if (flag2)
				{
					float num30 = x2AxisRenderContext.float_2 / 2f;
					if ((float)(rect.Y - rectangle.Y) < num30)
					{
						int num31 = (int)(num30 - (float)(rect.Y - rectangle.Y));
						rect.Y += num31;
						rect.Height -= num31;
					}
					if ((float)(rectangle.Bottom - rect.Bottom) < num30)
					{
						int num32 = (int)(num30 - (float)(rectangle.Bottom - rect.Bottom));
						rect.Height -= num32;
					}
				}
				else
				{
					float num33 = x2AxisRenderContext.float_1 / 2f;
					if ((float)(rect.X - rectangle.X) < num33)
					{
						int num34 = (int)(num33 - (float)(rect.X - rectangle.X));
						rect.X += num34;
						rect.Width -= num34;
					}
					if ((float)(rectangle.Right - rect.Right) < num33)
					{
						int num35 = (int)(num33 - (float)(rectangle.Right - rect.Right));
						rect.Width -= num35;
					}
				}
			}
		}
		if (!Struct41.smethod_21(rect))
		{
			smethod_18(chart, ref rect);
			chart.OriginalPlotRect = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
			smethod_21(graphics, chart, class4, class5, ref rect, renderContext);
		}
		else
		{
			chart.OriginalPlotRect = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		}
		chart.PlotAreaInternal.rectangle_1 = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		Rectangle rect2 = new Rectangle(chart.int_12, chart.int_13, chart.int_14, chart.int_15);
		if (!Struct41.smethod_21(rect) && !chart.PlotAreaInternal.IsSizeAuto)
		{
			if (x1AxisRenderContext.Axis != null && x1AxisRenderContext.Axis.HasTitle)
			{
				smethod_12(x1AxisRenderContext, rect2, flag);
			}
			if (x2AxisRenderContext.Axis != null && x2AxisRenderContext.Axis.HasTitle && class2.Count > 0)
			{
				smethod_12(x2AxisRenderContext, rect2, flag2);
			}
			if (y1AxisRenderContext.Axis != null && y1AxisRenderContext.Axis.HasTitle)
			{
				smethod_12(y1AxisRenderContext, rect2, flag);
			}
			if (y2AxisRenderContext.Axis != null && y2AxisRenderContext.Axis.HasTitle && class2.Count > 0)
			{
				smethod_12(y2AxisRenderContext, rect2, flag2);
			}
		}
		if (x1AxisRenderContext.Axis != null && !Struct41.smethod_21(rect) && x1AxisRenderContext.Axis.HasTitle)
		{
			smethod_13(x1AxisRenderContext, flag);
		}
		if (y1AxisRenderContext.Axis != null && !Struct41.smethod_21(rect) && y1AxisRenderContext.Axis.HasTitle)
		{
			smethod_13(y1AxisRenderContext, flag);
		}
		if (x2AxisRenderContext.Axis != null && !Struct41.smethod_21(rect) && x2AxisRenderContext.Axis.HasTitle && class2.Count > 0)
		{
			smethod_13(x2AxisRenderContext, flag2);
		}
		if (y2AxisRenderContext.Axis != null && !Struct41.smethod_21(rect) && y2AxisRenderContext.Axis.HasTitle && class2.Count > 0)
		{
			smethod_13(y2AxisRenderContext, flag2);
		}
		if (chart.PlotAreaInternal.IsSizeAuto && y1AxisRenderContext.Axis != null && y1AxisRenderContext.Axis.IsVisible && class4.ResembleType != ChartType.Radar && class4.ResembleType != ChartType.FilledRadar)
		{
			float num36 = smethod_37(graphics, flag, class4, rect, y1AxisRenderContext);
			int num37 = 0;
			num37 = ((!flag) ? rect.Height : rect.Width);
			if (flag5 && y1AxisRenderContext.arrayList_0.Count > 3 && num36 > (float)num37 && num37 != 0)
			{
				y1AxisRenderContext.arrayList_0.Clear();
				y1AxisRenderContext.IsAutoMajorUnit = flag5;
				y1AxisRenderContext.IsAutoMinorUnit = flag6;
				smethod_33(graphics, maxValue, minValue, y1AxisRenderContext.arrayList_0, class4.ResembleType, rect, flag, @class.method_0(0), y1AxisRenderContext);
			}
		}
		if (chart.PlotAreaInternal.IsSizeAuto && x1AxisRenderContext.Axis != null && x1AxisRenderContext.Axis.IsVisible && class4.ResembleType == ChartType.ScatterWithMarkers)
		{
			float num38 = smethod_37(graphics, isDisplayAxisSameAsBar: true, class4, rect, x1AxisRenderContext);
			int num39 = 0;
			num39 = ((!flag) ? rect.Height : rect.Width);
			if (flag7 && x1AxisRenderContext.arrayList_0.Count > 3 && num38 > (float)num39 && num39 != 0)
			{
				x1AxisRenderContext.arrayList_0.Clear();
				x1AxisRenderContext.IsAutoMajorUnit = flag7;
				x1AxisRenderContext.IsAutoMinorUnit = flag8;
				smethod_46(graphics, x1AxisRenderContext.arrayList_0, rect, class4.ResembleType, @class, flag, x1AxisRenderContext);
			}
		}
		if (smethod_44(chart.Type))
		{
			Struct23.smethod_5(renderContext, graphics, nSeriesInternal, rect, nSeriesInternal.method_1(), flag7, flag8, x1AxisRenderContext.Axis.IsAutomaticMaxValue, x1AxisRenderContext.Axis.IsAutomaticMinValue, flag5, flag6, y1AxisRenderContext.Axis.IsAutomaticMaxValue, y1AxisRenderContext.Axis.IsAutomaticMinValue);
		}
		chart.PlotAreaInternal.method_6();
		chart.bool_9 = true;
	}

	internal static void smethod_1(Class740 chart)
	{
		Interface32 graphics = chart.Graphics;
		Chart sourceChart = chart.SourceChart;
		Class784 @class = new Class784(sourceChart, graphics, chart);
		if (!chart.bool_9)
		{
			smethod_0(chart, sourceChart, @class);
		}
		@class.method_1();
		TextRenderingHint textRenderingHint = chart.Graphics.TextRenderingHint;
		Struct40.smethod_0(chart);
		Class757 nSeriesInternal = chart.NSeriesInternal;
		if (chart.NSeriesInternal.Count == 0 || smethod_23(chart.NSeriesInternal.ListSeries) == 0)
		{
			return;
		}
		Class757 class2 = new Class757(chart);
		Class757 class3 = new Class757(chart);
		foreach (Class759 item in nSeriesInternal)
		{
			if (item.AxisGroup == Enum141.const_0)
			{
				class2.Add(item);
			}
			else
			{
				class3.Add(item);
			}
		}
		Class759 class5 = class2.method_0(0);
		Class759 class6 = new Class759(chart, null, ChartType.ClusteredColumn);
		if (class3.Count > 0)
		{
			class6 = (Class759)class3[0];
		}
		bool flag = smethod_8(class5.ResembleType);
		bool flag2 = smethod_8(class6.ResembleType);
		int num = smethod_23(class2.ListSeries);
		int num2 = smethod_23(class3.ListSeries);
		bool flag3 = chart.PlotAreaInternal.method_16();
		chart.PlotAreaInternal.method_17();
		Rectangle rectangle_ = chart.PlotAreaInternal.rectangle_0;
		float num3 = smethod_14(rectangle_.X, rectangle_.Width, flag, @class.Y1AxisRenderContext);
		double num4 = @class.Y1AxisRenderContext.CrossAt;
		float num5 = smethod_14(rectangle_.X, rectangle_.Width, flag2, @class.Y2AxisRenderContext);
		double num6 = @class.Y2AxisRenderContext.CrossAt;
		float num7 = smethod_14(rectangle_.Y, rectangle_.Height, flag, @class.Y1AxisRenderContext);
		float num8 = smethod_14(rectangle_.Y, rectangle_.Height, flag2, @class.Y2AxisRenderContext);
		float top = smethod_15(rectangle_.Y, rectangle_.Height, flag, class2, @class.X1AxisRenderContext);
		float top2 = smethod_15(rectangle_.Y, rectangle_.Height, flag2, class3, @class.X2AxisRenderContext);
		float num9 = 0f;
		float num10 = 0f;
		num9 = ((class5.ResembleType == ChartType.Bubble || class5.ResembleType == ChartType.ScatterWithMarkers) ? smethod_14(rectangle_.X, rectangle_.Width, !flag, @class.X1AxisRenderContext) : smethod_15(rectangle_.X, rectangle_.Width, flag, class2, @class.X1AxisRenderContext));
		num10 = ((class6.ResembleType == ChartType.Bubble || class6.ResembleType == ChartType.ScatterWithMarkers) ? smethod_14(rectangle_.X, rectangle_.Width, !flag2, @class.X2AxisRenderContext) : smethod_15(rectangle_.X, rectangle_.Width, flag2, class3, @class.X2AxisRenderContext));
		if (class5.ResembleType != ChartType.Radar && class5.ResembleType != ChartType.FilledRadar)
		{
			Struct21.smethod_2(graphics, rectangle_, flag, class5, @class.X1AxisRenderContext, @class);
			Struct21.smethod_2(graphics, rectangle_, flag, class5, @class.Y1AxisRenderContext, @class);
		}
		else
		{
			Struct21.smethod_3(@class.Y1AxisRenderContext, graphics, rectangle_, num, @class);
		}
		if (class6.ResembleType != ChartType.Radar && class6.ResembleType != ChartType.FilledRadar)
		{
			Struct21.smethod_2(graphics, rectangle_, flag2, class6, @class.X2AxisRenderContext, @class);
			Struct21.smethod_2(graphics, rectangle_, flag2, class6, @class.Y2AxisRenderContext, @class);
		}
		else
		{
			Struct21.smethod_3(@class.Y2AxisRenderContext, graphics, rectangle_, num2, @class);
		}
		int num11 = 0;
		float num12 = 0f;
		float num13 = 0f;
		double num14 = 0.0;
		IList list = nSeriesInternal.method_9();
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		bool flag4 = false;
		bool upDownBarsHaveBeenDrawn = false;
		bool hiLoLinesHaveBeenDrawn = false;
		for (int i = 0; i < list.Count; i++)
		{
			if (flag3)
			{
				break;
			}
			Class759 class7 = (Class759)list[i];
			if (class7.AxisGroup == Enum141.const_0)
			{
				num11 = num;
				num12 = num3;
				num14 = num4;
				num13 = num7;
			}
			else
			{
				num11 = num2;
				num12 = num5;
				num14 = num6;
				num13 = num8;
			}
			if (chart.bool_8)
			{
				if (@class.Y1AxisRenderContext.Axis != null && @class.Y1AxisRenderContext.Axis.IsVisible && (@class.Y2AxisRenderContext.Axis == null || !@class.Y2AxisRenderContext.Axis.IsVisible))
				{
					num12 = num3;
					num14 = num4;
					num13 = num7;
				}
				else
				{
					num12 = num5;
					num14 = num6;
					num13 = num8;
				}
			}
			ChartType[] chartType = new ChartType[1];
			if (class7.method_2(chartType))
			{
				List<object[]> c = Struct27.smethod_0(graphics, class7, rectangle_, num13, num14, num11, @class);
				arrayList.AddRange(c);
			}
			else if (class7.method_2(new ChartType[1] { ChartType.StackedColumn }))
			{
				List<object[]> c2 = Struct27.smethod_23(graphics, class7, rectangle_, num11, @class);
				arrayList.AddRange(c2);
			}
			else if (class7.method_2(new ChartType[1] { ChartType.PercentsStackedColumn }))
			{
				List<object[]> c3 = Struct27.smethod_27(graphics, class7, rectangle_, num11, @class);
				arrayList.AddRange(c3);
			}
			else if (class7.method_2(new ChartType[3]
			{
				ChartType.Line,
				ChartType.LineWithMarkers,
				ChartType.HighLowClose
			}))
			{
				List<object[]> c4 = Struct27.smethod_19(graphics, class7, rectangle_, num13, num14, num11, ref upDownBarsHaveBeenDrawn, ref hiLoLinesHaveBeenDrawn, @class);
				arrayList2.AddRange(c4);
			}
			else if (class7.method_2(new ChartType[2]
			{
				ChartType.StackedLine,
				ChartType.StackedLineWithMarkers
			}))
			{
				List<object[]> c5 = Struct27.smethod_25(graphics, class7, rectangle_, num13, num11, @class);
				arrayList2.AddRange(c5);
			}
			else if (class7.method_2(new ChartType[2]
			{
				ChartType.PercentsStackedLine,
				ChartType.PercentsStackedLineWithMarkers
			}))
			{
				List<object[]> c6 = Struct27.smethod_30(graphics, class7, rectangle_, num13, num11, @class);
				arrayList2.AddRange(c6);
			}
			else if (class7.method_2(new ChartType[1] { ChartType.ClusteredBar }))
			{
				List<object[]> c7 = Struct22.smethod_0(graphics, chart, class7, rectangle_, num12, num14, num11, @class);
				arrayList3.AddRange(c7);
			}
			else if (class7.method_2(new ChartType[1] { ChartType.StackedBar }))
			{
				List<object[]> c8 = Struct22.smethod_5(graphics, chart, class7, rectangle_, num11, @class);
				arrayList3.AddRange(c8);
			}
			else if (class7.method_2(new ChartType[1] { ChartType.PercentsStackedBar }))
			{
				List<object[]> c9 = Struct22.smethod_8(graphics, chart, class7, rectangle_, num11, @class);
				arrayList3.AddRange(c9);
			}
			else if (class7.method_3(new ChartType[1] { ChartType.ScatterWithMarkers }))
			{
				ArrayList c10 = Struct42.smethod_0(graphics, class7, rectangle_, num13, num14, num11, @class);
				arrayList2.AddRange(c10);
			}
			else if (class7.method_2(new ChartType[1] { ChartType.Area }))
			{
				List<object[]> c11 = Struct20.smethod_0(graphics, chart, class7, rectangle_, num13, num14, num11, @class);
				arrayList2.AddRange(c11);
			}
			else if (class7.method_2(new ChartType[1] { ChartType.StackedArea }))
			{
				List<object[]> c12 = Struct20.smethod_2(graphics, chart, class7, rectangle_, num13, num11, @class);
				arrayList2.AddRange(c12);
			}
			else if (class7.method_2(new ChartType[1] { ChartType.PercentsStackedArea }))
			{
				List<object[]> c13 = Struct20.smethod_4(graphics, chart, class7, rectangle_, num13, num11, @class);
				arrayList2.AddRange(c13);
			}
			else if (class7.method_3(new ChartType[2]
			{
				ChartType.Pie,
				ChartType.Doughnut
			}) && !flag4)
			{
				Struct37.smethod_0(graphics, rectangle_, class7, @class);
				flag4 = true;
			}
			else if (class7.method_3(new ChartType[2]
			{
				ChartType.Radar,
				ChartType.FilledRadar
			}))
			{
				List<object[]> c14 = Struct38.smethod_0(graphics, class7, rectangle_, num11, @class);
				arrayList4.AddRange(c14);
			}
			else if (class7.method_2(new ChartType[2]
			{
				ChartType.Bubble,
				ChartType.BubbleWith3D
			}))
			{
				List<object[]> c15 = Struct23.smethod_0(graphics, class7, rectangle_, num13, num14, num11, @class);
				arrayList2.AddRange(c15);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			Class759 class8 = (Class759)list[j];
			Struct41.smethod_0(graphics, class8.YErrorBarInternal, class8.ResembleType, rectangle_);
			Struct41.smethod_0(graphics, class8.XErrorBarInternal, class8.ResembleType, rectangle_);
		}
		for (int k = 0; k < list.Count; k++)
		{
			Class759 class9 = (Class759)list[k];
			if (class9.AxisGroup == Enum141.const_0)
			{
				num12 = num3;
				num14 = num4;
				num13 = num7;
			}
			else
			{
				num12 = num5;
				num14 = num6;
				num13 = num8;
			}
			if (class9.TrendlinesInternal.Count > 0)
			{
				if (class9.ResembleType != ChartType.ClusteredBar && class9.ResembleType != ChartType.StackedBar && class9.ResembleType != ChartType.PercentsStackedBar)
				{
					Struct40.smethod_1(graphics, class9, rectangle_, num13, num14, @class);
				}
				else
				{
					Struct40.smethod_5(graphics, class9, rectangle_, num12, num14, @class);
				}
			}
		}
		Struct27.smethod_5(graphics, chart, arrayList, @class);
		Struct27.smethod_21(graphics, chart, arrayList2, @class);
		Struct22.smethod_2(graphics, chart, rectangle_, arrayList3, @class);
		Struct38.smethod_1(graphics, chart, arrayList4, @class);
		if (sourceChart.HasTitle)
		{
			(sourceChart.ChartTitle as ChartTitle).method_2(@class, @class.ChartTitleRenderContext);
		}
		if (chart.ChartAreaInternal.AreaInternal.IsTransparent)
		{
			chart.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		if (class5.IsRardarSeries)
		{
			Struct21.smethod_19(@class.X1AxisRenderContext, graphics, class2, rectangle_);
		}
		else if (@class.X1AxisRenderContext.Axis != null && @class.X1AxisRenderContext.Axis.IsVisible && class5.ResembleType != ChartType.Radar && class5.ResembleType != ChartType.FilledRadar)
		{
			if (flag)
			{
				Struct21.smethod_13(graphics, @class.Y1AxisRenderContext.Axis.IsPlotOrderReversed, num3, rectangle_, num, @class.X1AxisRenderContext, @class);
			}
			else if (class5.ResembleType != ChartType.ScatterWithMarkers && class5.ResembleType != ChartType.Bubble)
			{
				Struct21.smethod_7(graphics, @class.Y1AxisRenderContext.Axis.IsPlotOrderReversed, num7, rectangle_, num, flag, @class.X1AxisRenderContext, @class);
			}
			else
			{
				Struct21.smethod_18(graphics, @class.Y1AxisRenderContext.Axis.IsPlotOrderReversed, num7, rectangle_, class5, @class.X1AxisRenderContext, @class);
			}
		}
		if (class6.IsRardarSeries)
		{
			Struct21.smethod_19(@class.X2AxisRenderContext, graphics, class3, rectangle_);
		}
		else if (@class.X2AxisRenderContext.Axis != null && @class.X2AxisRenderContext.Axis.IsVisible && class6.ResembleType != ChartType.Radar && class6.ResembleType != ChartType.FilledRadar)
		{
			if (flag2)
			{
				Struct21.smethod_13(graphics, @class.Y2AxisRenderContext.Axis.IsPlotOrderReversed, num5, rectangle_, num2, @class.X2AxisRenderContext, @class);
			}
			else if (class6.ResembleType != ChartType.ScatterWithMarkers && class6.ResembleType != ChartType.Bubble)
			{
				Struct21.smethod_7(graphics, @class.Y2AxisRenderContext.Axis.IsPlotOrderReversed, num8, rectangle_, num2, flag2, @class.X2AxisRenderContext, @class);
			}
			else
			{
				Struct21.smethod_18(graphics, @class.Y2AxisRenderContext.Axis.IsPlotOrderReversed, num8, rectangle_, class6, @class.X2AxisRenderContext, @class);
			}
		}
		if (@class.Y1AxisRenderContext.Axis != null && @class.Y1AxisRenderContext.Axis.IsVisible)
		{
			if (flag)
			{
				Struct21.smethod_11(graphics, @class.X1AxisRenderContext.Axis.IsPlotOrderReversed, top, rectangle_, class5, @class.Y1AxisRenderContext, @class);
			}
			else if (class5.ResembleType != ChartType.Radar && class5.ResembleType != ChartType.FilledRadar)
			{
				Struct21.smethod_4(graphics, @class.X1AxisRenderContext.Axis.IsPlotOrderReversed, num9, rectangle_, class5, @class.Y1AxisRenderContext, @class);
			}
			else
			{
				Struct21.smethod_20(@class.Y1AxisRenderContext, graphics, class2, rectangle_);
			}
		}
		if (@class.Y2AxisRenderContext.Axis != null && @class.Y2AxisRenderContext.Axis.IsVisible)
		{
			if (flag2)
			{
				Struct21.smethod_11(graphics, @class.X2AxisRenderContext.Axis.IsPlotOrderReversed, top2, rectangle_, class6, @class.Y2AxisRenderContext, @class);
			}
			else if (class6.ResembleType != ChartType.Radar && class6.ResembleType != ChartType.FilledRadar)
			{
				Struct21.smethod_4(graphics, @class.X1AxisRenderContext.Axis.IsPlotOrderReversed, num10, rectangle_, class6, @class.Y2AxisRenderContext, @class);
			}
			else
			{
				Struct21.smethod_20(@class.Y2AxisRenderContext, graphics, class3, rectangle_);
			}
		}
		if (chart.ChartAreaInternal.AreaInternal.IsTransparent)
		{
			chart.Graphics.TextRenderingHint = textRenderingHint;
		}
		for (int l = 0; l < list.Count; l++)
		{
			if (chart.ChartAreaInternal.AreaInternal.IsTransparent && chart.PlotAreaInternal.AreaInternal.IsTransparent)
			{
				chart.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			}
			Class759 aSeries = (Class759)list[l];
			Struct40.smethod_20(graphics, aSeries);
			if (chart.ChartAreaInternal.AreaInternal.IsTransparent && chart.PlotAreaInternal.AreaInternal.IsTransparent)
			{
				chart.Graphics.TextRenderingHint = textRenderingHint;
			}
		}
		if (@class.X1AxisRenderContext.Axis != null && @class.X1AxisRenderContext.Axis.HasTitle)
		{
			(@class.X1AxisRenderContext.Axis.Title as ChartTitle).method_2(@class, @class.X1AxisRenderContext.AxisTitleRenderContext);
		}
		if (@class.Y1AxisRenderContext.Axis != null && @class.Y1AxisRenderContext.Axis.HasTitle)
		{
			(@class.Y1AxisRenderContext.Axis.Title as ChartTitle).method_2(@class, @class.Y1AxisRenderContext.AxisTitleRenderContext);
		}
		if (@class.X2AxisRenderContext.Axis != null && @class.X2AxisRenderContext.Axis.HasTitle && class3.Count > 0)
		{
			(@class.X2AxisRenderContext.Axis.Title as ChartTitle).method_2(@class, @class.X2AxisRenderContext.AxisTitleRenderContext);
		}
		if (@class.Y2AxisRenderContext.Axis != null && @class.Y2AxisRenderContext.Axis.HasTitle && class3.Count > 0)
		{
			(@class.Y2AxisRenderContext.Axis.Title as ChartTitle).method_2(@class, @class.Y2AxisRenderContext.AxisTitleRenderContext);
		}
		if (@class.Chart.HasDataTable)
		{
			Class786 dataTableRenderContext = @class.DataTableRenderContext;
			if (smethod_50(@class.X1AxisRenderContext))
			{
				dataTableRenderContext.rectangle_1.X = chart.PlotAreaInternal.rectangle_0.X;
				dataTableRenderContext.rectangle_1.Width = chart.PlotAreaInternal.rectangle_0.Width;
			}
			else
			{
				dataTableRenderContext.rectangle_1.X = chart.PlotAreaInternal.rectangle_0.X;
				dataTableRenderContext.rectangle_1.Y = chart.PlotAreaInternal.rectangle_0.Bottom;
				dataTableRenderContext.rectangle_1.Width = chart.PlotAreaInternal.rectangle_0.Width;
			}
			Struct26.smethod_0(graphics, dataTableRenderContext.rectangle_1.X, dataTableRenderContext.rectangle_1.Y, dataTableRenderContext.rectangle_1.Width, flag, @class);
		}
		if (sourceChart.HasLegend)
		{
			if (chart.ChartAreaInternal.AreaInternal.IsTransparent && @class.LegendRenderContext.IsTransparent)
			{
				chart.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
			}
			if (class3.Count == 0 && (class5.ResembleType == ChartType.Pie || class5.ResembleType == ChartType.Doughnut || @class.LegendRenderContext.IsRenderedLegendByPoint))
			{
				Class759 class10 = class5;
				if (class5.Type == ChartType.Doughnut || class5.Type == ChartType.ExplodedDoughnut)
				{
					for (int m = 1; m < chart.NSeriesInternal.Count; m++)
					{
						if (chart.NSeriesInternal[m].Points != null && class10.PointsInternal != null && chart.NSeriesInternal[m].Points.Count > class10.PointsInternal.Count)
						{
							class10 = chart.NSeriesInternal.method_0(m);
						}
					}
				}
				Struct31.smethod_9(graphics, class10, @class, (Legend)sourceChart.Legend);
			}
			else
			{
				Struct31.smethod_23(graphics, flag, class5, @class, (Legend)sourceChart.Legend);
			}
			if (chart.ChartAreaInternal.AreaInternal.IsTransparent && @class.LegendRenderContext.IsTransparent)
			{
				chart.Graphics.TextRenderingHint = textRenderingHint;
			}
		}
		chart.ChartAreaInternal.BorderInternal.method_6(chart.ChartAreaInternal.rectangle_0);
	}

	internal static string smethod_2(Class740 chart)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		Class757 @class = new Class757(chart);
		Class757 class2 = new Class757(chart);
		foreach (Class759 item in nSeriesInternal)
		{
			if (item.AxisGroup == Enum141.const_0)
			{
				@class.Add(item);
			}
			else
			{
				class2.Add(item);
			}
		}
		if (@class.Count == 0)
		{
			return "Plot series are all on secondary axis. Must set one or more of Plot series on primary axis!";
		}
		smethod_3(nSeriesInternal);
		Class759 class4 = @class.method_0(0);
		for (int i = 1; i < @class.Count; i++)
		{
			Class759 class5 = @class.method_0(i);
			if (class5.ResembleType != class4.ResembleType)
			{
				class5.AxisGroup = Enum141.const_1;
				class2.Add(class5);
			}
		}
		Class759 class6 = new Class759(chart, null, ChartType.ClusteredColumn);
		if (class2.Count > 0)
		{
			class6 = class2.method_0(0);
		}
		int num = 1;
		while (true)
		{
			if (num < class2.Count)
			{
				Class759 class7 = class2.method_0(num);
				if (class7.ResembleType != class6.ResembleType)
				{
					break;
				}
				num++;
				continue;
			}
			return "";
		}
		return "Some chart types cannot be combined with other types!";
	}

	private static void smethod_3(Class757 nSeries)
	{
		foreach (Class759 item in nSeries)
		{
			item.ResembleType = item.Type;
			switch (item.Type)
			{
			case ChartType.ScatterWithMarkers:
			case ChartType.ScatterWithSmoothLinesAndMarkers:
			case ChartType.ScatterWithSmoothLines:
			case ChartType.ScatterWithStraightLinesAndMarkers:
			case ChartType.ScatterWithStraightLines:
				item.ResembleType = ChartType.ScatterWithMarkers;
				break;
			case ChartType.Bubble:
			case ChartType.BubbleWith3D:
				item.ResembleType = ChartType.Bubble;
				break;
			case ChartType.Radar:
			case ChartType.RadarWithMarkers:
				item.ResembleType = ChartType.Radar;
				break;
			case ChartType.FilledRadar:
				item.ResembleType = ChartType.FilledRadar;
				break;
			case ChartType.StackedColumn3D:
				item.ResembleType = ChartType.StackedColumn3D;
				break;
			case ChartType.PercentsStackedColumn3D:
				item.ResembleType = ChartType.PercentsStackedColumn3D;
				break;
			case ChartType.ClusteredColumn:
			case ChartType.Line:
			case ChartType.LineWithMarkers:
			case ChartType.Area:
				item.ResembleType = ChartType.ClusteredColumn;
				break;
			case ChartType.StackedColumn:
			case ChartType.StackedLine:
			case ChartType.StackedLineWithMarkers:
			case ChartType.StackedArea:
				item.ResembleType = ChartType.StackedColumn;
				break;
			case ChartType.PercentsStackedColumn:
			case ChartType.PercentsStackedLine:
			case ChartType.PercentsStackedLineWithMarkers:
			case ChartType.PercentsStackedArea:
				item.ResembleType = ChartType.PercentsStackedColumn;
				break;
			case ChartType.ExplodedPie3D:
			case ChartType.Doughnut:
			case ChartType.ExplodedDoughnut:
				item.ResembleType = ChartType.Doughnut;
				break;
			case ChartType.Pie:
			case ChartType.Pie3D:
			case ChartType.PieOfPie:
			case ChartType.ExplodedPie:
			case ChartType.BarOfPie:
				item.ResembleType = ChartType.Pie;
				break;
			case ChartType.PercentsStackedBar:
				item.ResembleType = ChartType.PercentsStackedBar;
				break;
			case ChartType.ClusteredBar:
				item.ResembleType = ChartType.ClusteredBar;
				break;
			case ChartType.StackedBar:
				item.ResembleType = ChartType.StackedBar;
				break;
			}
		}
	}

	private static void smethod_4(Class740 chart)
	{
		Class757 nSeriesInternal = chart.NSeriesInternal;
		foreach (Class759 item in nSeriesInternal)
		{
			if (item.ResembleType != ChartType.ScatterWithMarkers && item.ResembleType != ChartType.Bubble)
			{
				item.XErrorBarInternal.IsVisible = false;
			}
			switch (item.ResembleType)
			{
			case ChartType.Pie:
			case ChartType.Doughnut:
				if (item.IsColorVariedAuto)
				{
					item.IsColorVaried = true;
				}
				break;
			}
		}
	}

	private static void smethod_5(Class755 line, int width)
	{
		if (line.Formatting == FillType.NotDefined)
		{
			_ = line.LineStyleInternal;
		}
	}

	internal static void smethod_6(Class740 c)
	{
		Class757 nSeriesInternal = c.NSeriesInternal;
		int count = nSeriesInternal.Count;
		Color[] array = c.Themes.ThemeColors.method_5(c.StyleIndex, nSeriesInternal.MaxColorCount);
		Color color = c.Themes.ThemeColors.method_3("lt1");
		Color color2 = c.Themes.ThemeColors.method_3("dk1");
		for (int i = 0; i < nSeriesInternal.Count; i++)
		{
			Class759 @class = nSeriesInternal.method_0(i);
			int seriesIndex = @class.SeriesIndex;
			_ = @class.Type;
			Color color3 = array[seriesIndex];
			Color color4 = array[seriesIndex];
			Color color5 = color4;
			@class.AreaInternal.method_1(color3);
			if (@class.IsDrawMarkerInPlot)
			{
				@class.LineInternal.method_1(color4);
				if (c.StyleIndex <= 8)
				{
					smethod_5(@class.LineInternal, 3);
				}
				else if (c.StyleIndex <= 24)
				{
					smethod_5(@class.LineInternal, 5);
				}
				else if (c.StyleIndex <= 32)
				{
					smethod_5(@class.LineInternal, 7);
				}
				else if (c.StyleIndex <= 48)
				{
					smethod_5(@class.LineInternal, 5);
				}
			}
			else
			{
				if (c.StyleIndex >= 9 && c.StyleIndex <= 16)
				{
					@class.LineInternal.method_1(Color.FromArgb(255, smethod_7(color)));
					smethod_5(@class.LineInternal, 1);
				}
				else if (c.StyleIndex == 33)
				{
					Color baseColor = c.Themes.ThemeColors.method_7(color2, 0.925);
					baseColor = Color.FromArgb(255, baseColor);
					@class.LineInternal.method_1(baseColor);
					smethod_5(@class.LineInternal, 1);
				}
				else if (c.StyleIndex == 34)
				{
					Color baseColor2 = c.Themes.ThemeColors.method_8(color4, 0.5);
					baseColor2 = Color.FromArgb(255, baseColor2);
					@class.LineInternal.method_1(baseColor2);
					smethod_5(@class.LineInternal, 1);
				}
				if (c.StyleIndex >= 35 && c.StyleIndex <= 40)
				{
					int num = c.StyleIndex - 34;
					Color color6 = c.Themes.ThemeColors.method_3("accent" + num);
					color6 = c.Themes.ThemeColors.method_8(color6, 0.5);
					color6 = Color.FromArgb(255, color6);
					@class.LineInternal.method_1(color6);
					smethod_5(@class.LineInternal, 1);
				}
			}
			if (@class.IsDrawMarkerInPlot)
			{
				@class.MarkerInternal.BorderInternal.method_1(color5);
				if (c.StyleIndex <= 8)
				{
					@class.MarkerInternal.method_3(7);
				}
				else if (c.StyleIndex <= 24)
				{
					@class.MarkerInternal.method_3(9);
				}
				else if (c.StyleIndex <= 32)
				{
					@class.MarkerInternal.method_3(13);
				}
				else if (c.StyleIndex <= 48)
				{
					@class.MarkerInternal.method_3(9);
				}
				@class.MarkerInternal.method_2(Struct31.smethod_6(@class, seriesIndex));
				int markerStyle = (int)@class.MarkerInternal.MarkerStyle;
				if (markerStyle != 5 && markerStyle != 6 && markerStyle != 8)
				{
					@class.MarkerInternal.AreaInternal.method_1(color5);
				}
				else
				{
					@class.MarkerInternal.AreaInternal.method_1(Color.Empty);
				}
			}
			Class747 pointsInternal = @class.PointsInternal;
			int count2 = pointsInternal.Count;
			Color[] array2 = c.Themes.ThemeColors.method_5(c.StyleIndex, count2);
			bool flag = false;
			if (@class.Type == ChartType.Pie || @class.Type == ChartType.Pie3D || @class.Type == ChartType.ExplodedPie3D || @class.Type == ChartType.BarOfPie || @class.Type == ChartType.ExplodedPie || @class.Type == ChartType.PieOfPie || @class.Type == ChartType.Doughnut || @class.Type == ChartType.ExplodedDoughnut)
			{
				flag = true;
			}
			for (int j = 0; j < pointsInternal.Count; j++)
			{
				Class748 class2 = pointsInternal.method_0(j);
				if (class2 == null)
				{
					continue;
				}
				if ((flag && @class.IsColorVaried) || (!flag && @class.IsColorVaried && count == 1))
				{
					Color color7 = array2[j];
					Color color8 = array2[j];
					Color color9 = color8;
					class2.AreaInternal.method_1(color7);
					if (@class.IsDrawMarkerInPlot)
					{
						class2.BorderInternal.method_1(color8);
						if (c.StyleIndex <= 8)
						{
							smethod_5(class2.BorderInternal, 3);
						}
						else if (c.StyleIndex <= 24)
						{
							smethod_5(class2.BorderInternal, 5);
						}
						else if (c.StyleIndex <= 32)
						{
							smethod_5(class2.BorderInternal, 7);
						}
						else if (c.StyleIndex <= 48)
						{
							smethod_5(class2.BorderInternal, 5);
						}
					}
					else
					{
						if (c.StyleIndex >= 9 && c.StyleIndex <= 16)
						{
							class2.BorderInternal.method_1(Color.FromArgb(255, smethod_7(color)));
							smethod_5(class2.BorderInternal, 1);
						}
						else if (c.StyleIndex == 33)
						{
							Color baseColor3 = c.Themes.ThemeColors.method_7(color2, 0.925);
							baseColor3 = Color.FromArgb(255, baseColor3);
							class2.BorderInternal.method_1(baseColor3);
							smethod_5(class2.BorderInternal, 1);
						}
						else if (c.StyleIndex == 34)
						{
							Color baseColor4 = c.Themes.ThemeColors.method_8(color4, 0.5);
							baseColor4 = Color.FromArgb(255, baseColor4);
							class2.BorderInternal.method_1(baseColor4);
							smethod_5(class2.BorderInternal, 1);
						}
						if (c.StyleIndex >= 35 && c.StyleIndex <= 40)
						{
							int num2 = c.StyleIndex - 34;
							Color color10 = c.Themes.ThemeColors.method_3("accent" + num2);
							color10 = c.Themes.ThemeColors.method_8(color10, 0.5);
							color10 = Color.FromArgb(255, color10);
							class2.BorderInternal.method_1(color10);
							smethod_5(class2.BorderInternal, 1);
						}
					}
					if (@class.IsDrawMarkerInPlot)
					{
						class2.MarkerInternal.BorderInternal.method_1(color9);
						if (c.StyleIndex <= 8)
						{
							class2.MarkerInternal.method_3(7);
						}
						else if (c.StyleIndex <= 24)
						{
							class2.MarkerInternal.method_3(9);
						}
						else if (c.StyleIndex <= 32)
						{
							class2.MarkerInternal.method_3(13);
						}
						else if (c.StyleIndex <= 48)
						{
							class2.MarkerInternal.method_3(9);
						}
						class2.MarkerInternal.method_2(Struct31.smethod_6(@class, j));
						int markerStyle2 = (int)class2.MarkerInternal.MarkerStyle;
						if (markerStyle2 != 5 && markerStyle2 != 6 && markerStyle2 != 8)
						{
							class2.MarkerInternal.AreaInternal.method_1(color9);
						}
						else
						{
							class2.MarkerInternal.AreaInternal.method_1(Color.Empty);
						}
					}
					continue;
				}
				class2.AreaInternal.method_1(color3);
				if (@class.IsDrawMarkerInPlot)
				{
					class2.BorderInternal.method_1(color4);
					if (c.StyleIndex <= 8)
					{
						smethod_5(class2.BorderInternal, 3);
					}
					else if (c.StyleIndex <= 24)
					{
						smethod_5(class2.BorderInternal, 5);
					}
					else if (c.StyleIndex <= 32)
					{
						smethod_5(class2.BorderInternal, 7);
					}
					else if (c.StyleIndex <= 48)
					{
						smethod_5(class2.BorderInternal, 5);
					}
				}
				else
				{
					if (c.StyleIndex >= 9 && c.StyleIndex <= 16)
					{
						class2.BorderInternal.method_1(Color.FromArgb(255, smethod_7(color)));
						smethod_5(class2.BorderInternal, 1);
					}
					else if (c.StyleIndex == 33)
					{
						Color baseColor5 = c.Themes.ThemeColors.method_7(color2, 0.925);
						baseColor5 = Color.FromArgb(255, baseColor5);
						class2.BorderInternal.method_1(baseColor5);
						smethod_5(class2.BorderInternal, 1);
					}
					else if (c.StyleIndex == 34)
					{
						Color baseColor6 = c.Themes.ThemeColors.method_8(color4, 0.5);
						baseColor6 = Color.FromArgb(255, baseColor6);
						class2.BorderInternal.method_1(baseColor6);
						smethod_5(class2.BorderInternal, 1);
					}
					if (c.StyleIndex >= 35 && c.StyleIndex <= 40)
					{
						int num3 = c.StyleIndex - 34;
						Color color11 = c.Themes.ThemeColors.method_3("accent" + num3);
						color11 = c.Themes.ThemeColors.method_8(color11, 0.5);
						color11 = Color.FromArgb(255, color11);
						class2.BorderInternal.method_1(color11);
						smethod_5(class2.BorderInternal, 1);
					}
				}
				if (@class.IsDrawMarkerInPlot)
				{
					class2.MarkerInternal.BorderInternal.method_1(color5);
					if (c.StyleIndex <= 8)
					{
						class2.MarkerInternal.method_3(7);
					}
					else if (c.StyleIndex <= 24)
					{
						class2.MarkerInternal.method_3(9);
					}
					else if (c.StyleIndex <= 32)
					{
						class2.MarkerInternal.method_3(13);
					}
					else if (c.StyleIndex <= 48)
					{
						class2.MarkerInternal.method_3(9);
					}
					class2.MarkerInternal.method_2(Struct31.smethod_6(@class, seriesIndex));
					int markerStyle3 = (int)class2.MarkerInternal.MarkerStyle;
					if (markerStyle3 != 5 && markerStyle3 != 6 && markerStyle3 != 8)
					{
						class2.MarkerInternal.AreaInternal.method_1(color5);
					}
					else
					{
						class2.MarkerInternal.AreaInternal.method_1(Color.Empty);
					}
				}
			}
		}
	}

	private static Color smethod_7(Color color)
	{
		Class765 @class = new Class765("r", color.R);
		Class765 class2 = new Class765("g", color.G);
		Class765 class3 = new Class765("b", color.B);
		if (@class.Val != 0 && class2.Val != 0 && class3.Val != 0)
		{
			List<Class765> list = new List<Class765>();
			list.Add(@class);
			list.Add(class2);
			list.Add(class3);
			list.Sort();
			Class765 class4 = list[0];
			Class765 class5 = list[1];
			Class765 class6 = list[2];
			int val = class4.Val;
			foreach (Class765 item in list)
			{
				item.ToMax = val - item.Val;
			}
			int num = class4.Val + class5.Val + class6.Val;
			int num2 = class4.ToMax + class5.ToMax + class6.ToMax;
			int num3 = Struct41.smethod_5((float)num / 42f);
			if (num > 30)
			{
				if (class6.ToMax == 0)
				{
					int num4 = Struct41.smethod_3(num3 / 3);
					class4.Val -= num4;
					class5.Val -= num4;
					class6.Val -= num4;
				}
				else
				{
					class4.Val--;
					num3--;
					if (class5.ToMax == 0)
					{
						class5.Val--;
						num3--;
						if (num3 > 0)
						{
							class6.Val -= num3;
						}
						else
						{
							class6.Val--;
						}
					}
					else
					{
						int num5 = Struct41.smethod_3((float)class5.ToMax / (float)num2 * (float)num3);
						class5.Val -= num5;
						num3 -= num5;
						if (num3 > 0)
						{
							class6.Val -= num3;
						}
						else
						{
							class6.Val--;
						}
					}
				}
			}
		}
		return Color.FromArgb(@class.Val, class2.Val, class3.Val);
	}

	internal static bool smethod_8(ChartType chartType)
	{
		switch (chartType)
		{
		default:
			return false;
		case ChartType.PercentsStackedBar:
		case ChartType.ClusteredBar3D:
		case ChartType.ClusteredBar:
		case ChartType.StackedBar:
		case ChartType.StackedBar3D:
		case ChartType.PercentsStackedBar3D:
		case ChartType.ClusteredHorizontalCylinder:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.ClusteredHorizontalCone:
		case ChartType.StackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.ClusteredHorizontalPyramid:
		case ChartType.StackedHorizontalPyramid:
		case ChartType.PercentsStackedHorizontalPyramid:
			return true;
		}
	}

	private static void smethod_9(Class783 axisRenderContext, bool isDisplayAxisSameAsBar)
	{
		if (axisRenderContext.AxisType == Enum160.const_2 || axisRenderContext.AxisType == Enum160.const_3)
		{
			isDisplayAxisSameAsBar = !isDisplayAxisSameAsBar;
		}
		if (isDisplayAxisSameAsBar && float.IsNaN(axisRenderContext.AxisTitleRenderContext.Rotation))
		{
			axisRenderContext.AxisTitleRenderContext.Rotation = 90f;
		}
	}

	private static void smethod_10(Class783 axisRenderContext, bool isDisplayAxisSameAsBar)
	{
		if (axisRenderContext.AxisType == Enum160.const_2 || axisRenderContext.AxisType == Enum160.const_3)
		{
			isDisplayAxisSameAsBar = !isDisplayAxisSameAsBar;
		}
		if (isDisplayAxisSameAsBar && axisRenderContext.DisplayUnitInternal.IsAutoRotation)
		{
			axisRenderContext.DisplayUnitInternal.Rotation = 90;
		}
	}

	private static void smethod_11(Class783 axisRenderContext, ref Rectangle rect, bool isDisplayAxisSameAsBar, Size titleSizeIn)
	{
		Size size = new Size(titleSizeIn.Width, titleSizeIn.Height);
		if (axisRenderContext.AxisType == Enum160.const_2 || axisRenderContext.AxisType == Enum160.const_3)
		{
			isDisplayAxisSameAsBar = !isDisplayAxisSameAsBar;
		}
		if (isDisplayAxisSameAsBar)
		{
			if (axisRenderContext.bool_5)
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.X = rect.X;
				rect.X += size.Width + int_1;
				rect.Width -= size.Width + int_1;
			}
			else
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.X = rect.Right - size.Width;
				rect.Width -= size.Width + int_1;
			}
		}
		else if (axisRenderContext.bool_5)
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Bottom - size.Height;
			rect.Height -= size.Height + int_1;
		}
		else
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Y;
			rect.Y += size.Height + int_1;
			rect.Height -= size.Height + int_1;
		}
		axisRenderContext.AxisTitleRenderContext.rectangle_0.Size = size;
	}

	private static void smethod_12(Class783 axisRenderContext, Rectangle rect, bool isDisplayAxisSameAsBar)
	{
		Size size = new Size(axisRenderContext.AxisTitleRenderContext.rectangle_0.Size.Width, axisRenderContext.AxisTitleRenderContext.rectangle_0.Size.Height);
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (axisRenderContext.AxisType == Enum160.const_2 || axisRenderContext.AxisType == Enum160.const_3)
		{
			isDisplayAxisSameAsBar = !isDisplayAxisSameAsBar;
		}
		if (isDisplayAxisSameAsBar)
		{
			if (axisRenderContext.bool_5)
			{
				if (rect.X < size.Width + int_0 && float.IsNaN(axisRenderContext.Axis.Title.X))
				{
					axisRenderContext.AxisTitleRenderContext.rectangle_0.X = rect.X - size.Width;
				}
				else
				{
					axisRenderContext.AxisTitleRenderContext.rectangle_0.X = rect.X - size.Width;
				}
			}
			else if (chart.Position.Right - rect.Right < size.Width + int_0 && float.IsNaN(axisRenderContext.Axis.Title.Y))
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.X = chart.Position.Right - size.Width - int_0;
			}
			else
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.X = rect.Right;
			}
		}
		else if (axisRenderContext.bool_5)
		{
			if (chart.Position.Bottom - rect.Bottom < size.Height + int_0 && float.IsNaN(axisRenderContext.Axis.Title.Y))
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = chart.Position.Bottom - size.Height - int_0;
			}
			else
			{
				axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Bottom;
			}
		}
		else if (rect.Y < size.Height + int_0 && float.IsNaN(axisRenderContext.Axis.Title.Y))
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = size.Height + int_0;
		}
		else
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = rect.Y - size.Height;
		}
		if (axisRenderContext.AxisTitleRenderContext.rectangle_0.X < 0)
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.X = 0;
		}
		else if (axisRenderContext.AxisTitleRenderContext.rectangle_0.Right > chart.Width)
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.X = chart.Width - axisRenderContext.AxisTitleRenderContext.rectangle_0.Width;
		}
		if (axisRenderContext.AxisTitleRenderContext.rectangle_0.Y < 0)
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = 0;
		}
		else if (axisRenderContext.AxisTitleRenderContext.rectangle_0.Bottom > chart.Height)
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = chart.Height - axisRenderContext.AxisTitleRenderContext.rectangle_0.Height;
		}
	}

	private static void smethod_13(Class783 axisRenderContext, bool isDisplayAxisSameAsBar)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (axisRenderContext.AxisType == Enum160.const_2 || axisRenderContext.AxisType == Enum160.const_3)
		{
			isDisplayAxisSameAsBar = !isDisplayAxisSameAsBar;
		}
		if (isDisplayAxisSameAsBar)
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.Y = chart.int_13 + (chart.int_15 - axisRenderContext.AxisTitleRenderContext.rectangle_0.Height) / 2;
		}
		else
		{
			axisRenderContext.AxisTitleRenderContext.rectangle_0.X = chart.int_12 + (chart.int_14 - axisRenderContext.AxisTitleRenderContext.rectangle_0.Width) / 2;
		}
	}

	internal static float smethod_14(int jumping_off, int length, bool isDisplayAxisSameAsBar, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis == null)
		{
			return 0f;
		}
		float num = 0f;
		bool flag = ((!isDisplayAxisSameAsBar) ? axisRenderContext.Axis.IsPlotOrderReversed : (!axisRenderContext.Axis.IsPlotOrderReversed));
		double num2 = axisRenderContext.LogCrossAt;
		double logMaxValue = axisRenderContext.LogMaxValue;
		double logMinValue = axisRenderContext.LogMinValue;
		if (axisRenderContext.Axis.CrossType == CrossesType.Maximum)
		{
			num2 = logMaxValue;
		}
		if (num2 > logMaxValue)
		{
			num2 = logMaxValue;
		}
		if (num2 < logMinValue)
		{
			num2 = logMinValue;
		}
		axisRenderContext.CrossAt = (axisRenderContext.Axis.IsLogarithmic ? ((float)axisRenderContext.method_1(num2)) : ((float)num2));
		if (!flag)
		{
			return (float)((double)jumping_off + (logMaxValue - num2) / (logMaxValue - logMinValue) * (double)length);
		}
		return (float)((double)jumping_off + (num2 - logMinValue) / (logMaxValue - logMinValue) * (double)length);
	}

	internal static float smethod_15(int jumping_off, int length, bool isDisplayAxisSameAsBar, Class757 nSeries, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis == null)
		{
			return 0f;
		}
		if (nSeries.Count == 0)
		{
			return 0f;
		}
		float num = 0f;
		bool flag = ((!isDisplayAxisSameAsBar) ? axisRenderContext.Axis.IsPlotOrderReversed : (!axisRenderContext.Axis.IsPlotOrderReversed));
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2)
		{
			int num2 = smethod_23(nSeries.ListSeries);
			int num3 = num2;
			if (axisRenderContext.AxisBetweenCategories || axisRenderContext.ChartRenderContext.Chart.HasDataTable)
			{
				num3++;
			}
			int num4 = 1;
			if (num3 <= 1)
			{
				num3 = 2;
			}
			double num5 = axisRenderContext.CrossAt;
			if (axisRenderContext.Axis.CrossType == CrossesType.Maximum)
			{
				num5 = num3;
			}
			if (num5 > (double)num3)
			{
				num5 = num3;
			}
			else if (num5 < (double)num4)
			{
				num5 = num4;
			}
			if (nSeries.method_0(0).IsXValueSeries)
			{
				num5 = axisRenderContext.LogCrossAt;
				double logMaxValue = axisRenderContext.LogMaxValue;
				double logMinValue = axisRenderContext.LogMinValue;
				if (axisRenderContext.Axis.CrossType == CrossesType.Maximum)
				{
					num5 = logMaxValue;
				}
				if (num5 > logMaxValue)
				{
					num5 = logMaxValue;
				}
				if (num5 < logMinValue)
				{
					num5 = logMinValue;
				}
				axisRenderContext.CrossAt = (axisRenderContext.Axis.IsLogarithmic ? ((float)axisRenderContext.method_1(num5)) : ((float)num5));
				if (flag)
				{
					return (float)((double)jumping_off + (logMaxValue - num5) / (logMaxValue - logMinValue) * (double)length);
				}
				return (float)((double)jumping_off + (num5 - logMinValue) / (logMaxValue - logMinValue) * (double)length);
			}
			axisRenderContext.CrossAt = (float)num5;
			if (flag)
			{
				return (float)((double)jumping_off + ((double)num3 - num5) / (double)(num3 - num4) * (double)length);
			}
			return (float)((double)jumping_off + (num5 - (double)num4) / (double)(num3 - num4) * (double)length);
		}
		TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
		int num6 = (int)axisRenderContext.MaxValue;
		int num7 = (int)axisRenderContext.MinValue;
		int num8 = 0;
		if (!axisRenderContext.AxisBetweenCategories && !axisRenderContext.ChartRenderContext.Chart.HasDataTable)
		{
			num8 = Struct21.smethod_35(baseUnitScale, num6, num7, chart.IsDate1904);
			if (num8 == 0)
			{
				num8 = 1;
			}
		}
		else
		{
			num6 = Struct21.smethod_37(baseUnitScale, baseUnitScale, 1, num6, chart.IsDate1904);
			num8 = Struct21.smethod_35(baseUnitScale, num6, num7, chart.IsDate1904);
		}
		int num9 = Struct21.smethod_38(baseUnitScale, (int)axisRenderContext.CrossAt, chart.IsDate1904);
		if (axisRenderContext.Axis.CrossType == CrossesType.Maximum)
		{
			num9 = num6;
		}
		if (num9 > num6)
		{
			num9 = num6;
		}
		else if (num9 < num7)
		{
			num9 = num7;
		}
		axisRenderContext.CrossAt = num9;
		if (flag)
		{
			return (float)(jumping_off + length) - (float)Struct21.smethod_35(baseUnitScale, num9, num7, chart.IsDate1904) / (float)num8 * (float)length;
		}
		return (float)jumping_off + (float)Struct21.smethod_35(baseUnitScale, num9, num7, chart.IsDate1904) / (float)num8 * (float)length;
	}

	private static void smethod_16(Class783 labelAxisRenderContext, Class757 nSeries, Class740 chart, Class783 otherAxisRenderContext)
	{
		if (otherAxisRenderContext.Axis == null)
		{
			return;
		}
		bool flag = false;
		ChartType resembleType = nSeries.method_0(0).ResembleType;
		switch (labelAxisRenderContext.Axis.TickLabelPosition)
		{
		case TickLabelPositionType.High:
			labelAxisRenderContext.int_5 = 2;
			if (otherAxisRenderContext.Axis.IsPlotOrderReversed)
			{
				labelAxisRenderContext.int_5 = 1;
			}
			break;
		case TickLabelPositionType.Low:
			labelAxisRenderContext.int_5 = 1;
			if (otherAxisRenderContext.Axis.IsPlotOrderReversed)
			{
				labelAxisRenderContext.int_5 = 2;
			}
			break;
		case TickLabelPositionType.NextTo:
		{
			labelAxisRenderContext.int_5 = 3;
			if (otherAxisRenderContext.Axis.CrossType == CrossesType.Maximum)
			{
				if (!otherAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					labelAxisRenderContext.int_5 = 2;
				}
				else
				{
					labelAxisRenderContext.int_5 = 1;
				}
			}
			else if (otherAxisRenderContext.Axis.CrossType == CrossesType.AxisCrossesAtZero)
			{
				if (otherAxisRenderContext.AxisType != Enum160.const_2 && otherAxisRenderContext.AxisType != Enum160.const_3)
				{
					if (otherAxisRenderContext.AxisType == Enum160.const_0 || otherAxisRenderContext.AxisType == Enum160.const_1)
					{
						if (resembleType != ChartType.ScatterWithMarkers && resembleType != ChartType.Bubble)
						{
							otherAxisRenderContext.CrossAt = (float)otherAxisRenderContext.MinValue;
							flag = true;
						}
						else
						{
							otherAxisRenderContext.CrossAt = 0f;
							flag = true;
						}
					}
				}
				else
				{
					otherAxisRenderContext.CrossAt = 0f;
					flag = true;
				}
			}
			if (otherAxisRenderContext.Axis.CrossType != CrossesType.Custom && !flag)
			{
				break;
			}
			if (otherAxisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2 && (otherAxisRenderContext.AxisType == Enum160.const_0 || otherAxisRenderContext.AxisType == Enum160.const_1) && nSeries.method_0(0).ResembleType != ChartType.Bubble && nSeries.method_0(0).ResembleType != ChartType.ScatterWithMarkers)
			{
				int num = smethod_23(nSeries.ListSeries);
				int num2 = num;
				if (otherAxisRenderContext.AxisBetweenCategories || otherAxisRenderContext.ChartRenderContext.Chart.HasDataTable)
				{
					num2++;
				}
				int num3 = 1;
				if (num2 <= 1)
				{
					num2 = 2;
				}
				double num4 = otherAxisRenderContext.CrossAt;
				if (otherAxisRenderContext.Axis.CrossType == CrossesType.Maximum)
				{
					num4 = num2;
				}
				if (num4 > (double)num2)
				{
					num4 = num2;
				}
				else if (num4 < (double)num3)
				{
					num4 = num3;
				}
				if (!otherAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					if (num4 == (double)num3)
					{
						labelAxisRenderContext.int_5 = 1;
					}
				}
				else if (num4 == (double)num3)
				{
					labelAxisRenderContext.int_5 = 2;
				}
				break;
			}
			double minValue = otherAxisRenderContext.MinValue;
			if ((double)otherAxisRenderContext.CrossAt <= minValue)
			{
				if (!otherAxisRenderContext.Axis.IsPlotOrderReversed)
				{
					labelAxisRenderContext.int_5 = 1;
				}
				else
				{
					labelAxisRenderContext.int_5 = 2;
				}
			}
			break;
		}
		case TickLabelPositionType.None:
			labelAxisRenderContext.int_5 = 0;
			break;
		}
	}

	private static void smethod_17(Class740 chart, Interface32 g, Size labelSize, Size displayUnitSize, ref Rectangle rect, bool isDisplayAxisSameAsBar, Class783 valAxisRenderContext, Class786 dataTableRenderContext)
	{
		Class784 chartRenderContext = valAxisRenderContext.ChartRenderContext;
		if (isDisplayAxisSameAsBar)
		{
			switch (valAxisRenderContext.int_5)
			{
			case 1:
				if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
				{
					chart.int_15 += labelSize.Height;
					chart.int_15 += displayUnitSize.Height;
				}
				else
				{
					rect.Height -= labelSize.Height;
					rect.Height -= displayUnitSize.Height;
				}
				break;
			case 2:
				if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
				{
					chart.int_13 -= labelSize.Height;
					chart.int_15 += labelSize.Height;
					chart.int_13 -= displayUnitSize.Height;
					chart.int_15 += displayUnitSize.Height;
				}
				else
				{
					rect.Y += labelSize.Height;
					rect.Height -= labelSize.Height;
					rect.Y += displayUnitSize.Height;
					rect.Height -= displayUnitSize.Height;
				}
				break;
			case 3:
				if (chart.PlotAreaInternal.IsSizeAuto && chartRenderContext.Chart.HasDataTable)
				{
					rect.Height -= 5;
				}
				break;
			case 0:
				break;
			}
			return;
		}
		switch (valAxisRenderContext.int_5)
		{
		case 1:
			if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
			{
				if (!chartRenderContext.Chart.HasDataTable)
				{
					chart.int_12 -= labelSize.Width;
					chart.int_14 += labelSize.Width;
					chart.int_12 -= displayUnitSize.Width;
					chart.int_14 += displayUnitSize.Width;
					break;
				}
				Size legendSize = dataTableRenderContext.LegendSize;
				if (labelSize.Width + displayUnitSize.Width > legendSize.Width)
				{
					chart.int_12 -= labelSize.Width + displayUnitSize.Width - legendSize.Width;
					chart.int_14 += labelSize.Width + displayUnitSize.Width - legendSize.Width;
				}
			}
			else if (!chartRenderContext.Chart.HasDataTable)
			{
				rect.X += labelSize.Width;
				rect.Width -= labelSize.Width;
				rect.X += displayUnitSize.Width;
				rect.Width -= displayUnitSize.Width;
			}
			else
			{
				Size legendSize2 = dataTableRenderContext.LegendSize;
				if (labelSize.Width + displayUnitSize.Width > legendSize2.Width)
				{
					rect.X += labelSize.Width + displayUnitSize.Width - legendSize2.Width;
					rect.Width -= labelSize.Width + displayUnitSize.Width - legendSize2.Width;
				}
			}
			break;
		case 2:
			if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
			{
				chart.int_14 += labelSize.Width;
				chart.int_14 += displayUnitSize.Width;
			}
			else
			{
				rect.Width -= labelSize.Width;
				rect.Width -= displayUnitSize.Width;
			}
			break;
		case 0:
		case 3:
			break;
		}
	}

	private static void smethod_18(Class740 chart, ref Rectangle plotArea)
	{
		int x = plotArea.X - chart.int_12;
		int num = chart.int_12 + chart.int_14 - plotArea.Right;
		int y = plotArea.Y - chart.int_13;
		int num2 = chart.int_13 + chart.int_15 - plotArea.Bottom;
		if (chart.int_12 < 0)
		{
			chart.int_12 = 0;
			plotArea.X = x;
		}
		if (chart.int_14 > chart.Width)
		{
			chart.int_14 = chart.Width;
		}
		int num3 = chart.Width - num;
		if (plotArea.Right > num3)
		{
			plotArea.Width = num3 - plotArea.X;
		}
		if (chart.int_13 < 0)
		{
			chart.int_13 = 0;
			int bottom = plotArea.Bottom;
			plotArea.Y = y;
			plotArea.Height = bottom - plotArea.Y;
		}
		if (chart.int_15 > chart.Height)
		{
			chart.int_15 = chart.Height;
		}
		int num4 = chart.Height - num2;
		if (plotArea.Height > num4)
		{
			plotArea.Height = num4 - plotArea.Y;
		}
	}

	private static void smethod_19(Class740 chart, Interface32 g, Size labelSize, int labelOffset, ref Rectangle rect, bool isDisplayAxisSameAsBar, bool isTimeAxis, Class784 renderContext, Class783 axisRenderContext)
	{
		if (isDisplayAxisSameAsBar)
		{
			switch (axisRenderContext.int_5)
			{
			case 1:
				if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
				{
					if (!renderContext.Chart.HasDataTable)
					{
						chart.int_12 -= labelSize.Width + labelOffset;
						chart.int_14 += labelSize.Width + labelOffset;
						break;
					}
					Size legendSize = renderContext.DataTableRenderContext.LegendSize;
					if (labelSize.Width + labelOffset > legendSize.Width)
					{
						chart.int_12 -= labelSize.Width + labelOffset - legendSize.Width;
						chart.int_14 += labelSize.Width + labelOffset - legendSize.Width;
					}
				}
				else if (!renderContext.Chart.HasDataTable)
				{
					rect.X += labelSize.Width + labelOffset;
					rect.Width -= labelSize.Width + labelOffset;
				}
				else
				{
					Size legendSize2 = renderContext.DataTableRenderContext.LegendSize;
					if (labelSize.Width + labelOffset > legendSize2.Width)
					{
						rect.X += labelSize.Width + labelOffset - legendSize2.Width;
						rect.Width -= labelSize.Width + labelOffset - legendSize2.Width;
					}
				}
				break;
			case 2:
				if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
				{
					chart.int_14 += labelSize.Width + labelOffset;
				}
				else
				{
					rect.Width -= labelSize.Width + labelOffset;
				}
				break;
			case 3:
				smethod_20(Struct21.smethod_43(renderContext, axisRenderContext), ref rect, isDisplayAxisSameAsBar, labelSize, labelOffset, chart);
				break;
			case 0:
				break;
			}
			return;
		}
		if (renderContext.Chart.HasDataTable && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType != Enum267.const_2)
		{
			axisRenderContext.int_5 = 0;
			labelOffset = 0;
		}
		switch (axisRenderContext.int_5)
		{
		case 1:
			if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
			{
				chart.int_15 += labelSize.Height + labelOffset;
				if (!chart.PlotArea.IsSizeAuto && chart.int_15 + chart.int_13 > chart.Height)
				{
					int num = int_1;
					if (renderContext.Chart.HasTitle)
					{
						num = renderContext.ChartTitleRenderContext.rectangle_0.Bottom + int_1;
					}
					int num2 = chart.int_15 + chart.int_13 - chart.Height;
					if (rect.Y - num2 < num)
					{
						rect.Y = num;
					}
					else
					{
						rect.Y -= num2;
					}
				}
			}
			else
			{
				rect.Height -= labelSize.Height + labelOffset;
			}
			break;
		case 2:
			if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
			{
				if (renderContext.Chart.HasDataTable && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
				{
					chart.int_13 -= labelSize.Height + labelOffset;
					chart.int_15 += labelSize.Height + labelOffset + int_1;
				}
				else
				{
					chart.int_13 -= labelSize.Height + labelOffset;
					chart.int_15 += labelSize.Height + labelOffset;
				}
			}
			else if (renderContext.Chart.HasDataTable && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
			{
				rect.Y += labelSize.Height + labelOffset;
				rect.Height -= labelSize.Height + labelOffset + int_1;
			}
			else
			{
				rect.Y += labelSize.Height + labelOffset;
				rect.Height -= labelSize.Height + labelOffset;
			}
			break;
		case 3:
			if (!chart.PlotAreaInternal.IsSizeAuto && (chart.PlotArea.IsSizeAuto || chart.IsInnerMode))
			{
				if (renderContext.Chart.HasDataTable && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
				{
					chart.int_15 += int_1;
				}
				else
				{
					smethod_20(Struct21.smethod_43(renderContext, axisRenderContext), ref rect, isDisplayAxisSameAsBar, labelSize, labelOffset, chart);
				}
			}
			else if (renderContext.Chart.HasDataTable && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
			{
				rect.Height -= int_1;
			}
			else
			{
				smethod_20(Struct21.smethod_43(renderContext, axisRenderContext), ref rect, isDisplayAxisSameAsBar, labelSize, labelOffset, chart);
			}
			break;
		case 0:
			break;
		}
	}

	internal static void smethod_20(Class783 axisRenderContext, ref Rectangle plotArea, bool isDisplayAxisSameAsBar, Size labelSizeIn, int labelOffset, Class740 chart)
	{
		Size size = Class790.smethod_1(labelSizeIn);
		size.Width += labelOffset;
		size.Height += labelOffset;
		float num = plotArea.Height;
		if (isDisplayAxisSameAsBar)
		{
			num = plotArea.Width;
		}
		double num2 = axisRenderContext.LogCrossAt;
		double logMaxValue = axisRenderContext.LogMaxValue;
		double logMinValue = axisRenderContext.LogMinValue;
		if (axisRenderContext.Axis.CrossType == CrossesType.Maximum)
		{
			num2 = logMaxValue;
		}
		if (num2 > logMaxValue)
		{
			num2 = logMaxValue;
		}
		if (num2 < logMinValue)
		{
			num2 = logMinValue;
		}
		float num3 = (float)((num2 - logMinValue) / (logMaxValue - logMinValue) * (double)num);
		if (isDisplayAxisSameAsBar)
		{
			int num4 = 2;
			Rectangle rectangle = Class790.smethod_4(plotArea);
			while (num4 > 0)
			{
				plotArea = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
				int num5 = (int)((float)size.Width - num3);
				if (num5 > 0)
				{
					if (chart.PlotAreaInternal.IsSizeAuto)
					{
						if (axisRenderContext.Axis.IsPlotOrderReversed)
						{
							plotArea.Width -= num5;
						}
						else
						{
							plotArea.X += num5;
							plotArea.Width -= num5;
						}
					}
					else if (axisRenderContext.Axis.IsPlotOrderReversed)
					{
						chart.int_14 += num5;
					}
					else
					{
						chart.int_12 -= num5;
						chart.int_14 += num5;
					}
				}
				num3 = (float)plotArea.Width * num3 / (float)rectangle.Width;
				num4--;
			}
			return;
		}
		int num6 = 2;
		Rectangle rectangle2 = Class790.smethod_4(plotArea);
		while (num6 > 0)
		{
			plotArea = new Rectangle(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
			int num7 = (int)((float)size.Height - num3);
			if (num7 > 0)
			{
				if (chart.PlotAreaInternal.IsSizeAuto)
				{
					if (axisRenderContext.Axis.IsPlotOrderReversed)
					{
						plotArea.Y += num7;
						plotArea.Height -= num7;
					}
					else
					{
						plotArea.Height -= num7;
					}
				}
				else if (axisRenderContext.Axis.IsPlotOrderReversed)
				{
					chart.int_13 -= num7;
					chart.int_15 += num7;
				}
				else
				{
					chart.int_15 += num7;
				}
			}
			num3 = (float)plotArea.Height * num3 / (float)rectangle2.Height;
			num6--;
		}
	}

	private static void smethod_21(Interface32 g, Class740 chart, Class759 firstPrimarySeries, Class759 firstSecondarySeries, ref Rectangle rect, Class784 renderContext)
	{
		if (!firstPrimarySeries.IsPieSeries && !firstSecondarySeries.IsPieSeries)
		{
			if (!firstPrimarySeries.IsRardarSeries && !firstSecondarySeries.IsRardarSeries)
			{
				return;
			}
			SizeF layoutArea = new SizeF((float)chart.Width * 0.2f, chart.Height);
			bool flag = renderContext.X1AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None;
			bool flag2 = renderContext.X2AxisRenderContext.Axis != null && renderContext.X2AxisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None;
			if (chart.PlotAreaInternal.IsSizeAuto)
			{
				Size empty = Size.Empty;
				int num = 0;
				int num2 = 0;
				if (firstPrimarySeries.IsRardarSeries && flag)
				{
					renderContext.X1AxisRenderContext.float_1 = layoutArea.Width;
					renderContext.X2AxisRenderContext.float_2 = layoutArea.Height;
					Size size = Struct39.smethod_10(g, "a", renderContext.X1AxisRenderContext.TickLabelTextFont);
					renderContext.X1AxisRenderContext.TickLabelsOffsetPixel = size.Width / 2;
					num = renderContext.X1AxisRenderContext.TickLabelsOffsetPixel;
					for (int i = 0; i < renderContext.X1AxisRenderContext.arrayList_0.Count; i++)
					{
						string text = renderContext.X1AxisRenderContext.arrayList_0[i].ToString();
						Font tickLabelTextFont = renderContext.X1AxisRenderContext.TickLabelTextFont;
						int tickLableRotation = renderContext.X1AxisRenderContext.TickLableRotation;
						Size size2 = Struct39.smethod_12(chart.Graphics, text, tickLableRotation, tickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
						if (size2.Width > empty.Width)
						{
							empty.Width = size2.Width;
						}
						if (size2.Height > empty.Height)
						{
							empty.Height = size2.Height;
						}
					}
				}
				if (firstSecondarySeries.IsRardarSeries && flag2)
				{
					renderContext.X2AxisRenderContext.float_1 = layoutArea.Width;
					renderContext.X2AxisRenderContext.float_2 = layoutArea.Height;
					Size size3 = Struct39.smethod_10(g, "a", renderContext.X2AxisRenderContext.TickLabelTextFont);
					renderContext.X2AxisRenderContext.TickLabelsOffsetPixel = size3.Width / 2;
					num2 = renderContext.X2AxisRenderContext.TickLabelsOffsetPixel;
					for (int j = 0; j < renderContext.X2AxisRenderContext.arrayList_0.Count; j++)
					{
						string text2 = renderContext.X2AxisRenderContext.arrayList_0[j].ToString();
						Font tickLabelTextFont2 = renderContext.X2AxisRenderContext.TickLabelTextFont;
						int tickLableRotation2 = renderContext.X2AxisRenderContext.TickLableRotation;
						Size size4 = Struct39.smethod_12(chart.Graphics, text2, tickLableRotation2, tickLabelTextFont2, layoutArea, Enum157.const_1, Enum157.const_1);
						if (size4.Width > empty.Width)
						{
							empty.Width = size4.Width;
						}
						if (size4.Height > empty.Height)
						{
							empty.Height = size4.Height;
						}
					}
				}
				if (empty != Size.Empty)
				{
					if (num < num2)
					{
						num = num2;
					}
					empty.Width += num;
					empty.Height += num;
				}
				rect.Inflate(-empty.Width, -empty.Height);
			}
			else
			{
				if (firstPrimarySeries.IsRardarSeries && flag)
				{
					renderContext.X1AxisRenderContext.float_1 = layoutArea.Width;
					renderContext.X1AxisRenderContext.float_2 = layoutArea.Height;
				}
				if (firstSecondarySeries.IsRardarSeries && flag2)
				{
					renderContext.X2AxisRenderContext.float_1 = layoutArea.Width;
					renderContext.X2AxisRenderContext.float_2 = layoutArea.Height;
				}
			}
			Struct41.smethod_20(ref rect);
			int num3 = 15;
			if (rect.Width < 15)
			{
				rect.Width = num3;
			}
			if (rect.Height < num3)
			{
				rect.Height = num3;
			}
			return;
		}
		ChartType type = firstPrimarySeries.Type;
		ChartType type2 = firstSecondarySeries.Type;
		int secondPieSize = (renderContext.Chart.ChartData.SeriesGroups[0] as ChartSeriesGroup).SecondPieSize;
		int num4 = 100;
		Struct37.smethod_13(chart, ref rect, firstPrimarySeries);
		Struct37.smethod_13(chart, ref rect, firstSecondarySeries);
		if (type != ChartType.PieOfPie && type2 != ChartType.PieOfPie)
		{
			if (type != ChartType.BarOfPie && type2 != ChartType.BarOfPie)
			{
				Struct41.smethod_20(ref rect);
				return;
			}
			if (type == ChartType.BarOfPie)
			{
				num4 = firstPrimarySeries.GapWidth;
			}
			if (type2 == ChartType.BarOfPie)
			{
				num4 = firstSecondarySeries.GapWidth;
			}
			int num5 = 100 * rect.Width / (200 + secondPieSize + num4 / 2);
			if (num5 <= rect.Height / 2)
			{
				chart.RadiusFirst = num5;
			}
			else
			{
				chart.RadiusFirst = rect.Height / 2;
			}
			chart.RadiusSecond = (int)((float)(chart.RadiusFirst * secondPieSize) / 100f);
			chart.GapWidthBetween2Plots = (int)((float)(chart.RadiusFirst * num4) / 100f / 2f);
		}
		else
		{
			if (type == ChartType.PieOfPie)
			{
				num4 = firstPrimarySeries.GapWidth;
			}
			if (type2 == ChartType.PieOfPie)
			{
				num4 = firstSecondarySeries.GapWidth;
			}
			int num6 = 100 * rect.Width / (200 + 2 * secondPieSize + num4);
			if (num6 <= rect.Height / 2)
			{
				chart.RadiusFirst = num6;
			}
			else
			{
				chart.RadiusFirst = rect.Height / 2;
			}
			chart.RadiusSecond = (int)((float)(chart.RadiusFirst * secondPieSize) / 100f);
			chart.GapWidthBetween2Plots = (int)((float)(chart.RadiusFirst * num4) / 100f);
		}
	}

	private static void smethod_22(Class757 nSeries, Class783 axisRenderContext)
	{
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		bool flag = ((axisRenderContext.AxisType == Enum160.const_2 || axisRenderContext.AxisType == Enum160.const_3) ? true : false);
		IList list = nSeries.method_9();
		for (int i = 0; i < list.Count; i++)
		{
			Class759 @class = (Class759)list[i];
			ChartType resembleType = @class.ResembleType;
			Class752 class2 = ((!flag) ? @class.XErrorBarInternal : @class.YErrorBarInternal);
			if (class2 == null || !class2.IsVisible)
			{
				continue;
			}
			for (int j = 0; j < @class.PointsInternal.Count; j++)
			{
				Class748 class3 = @class.PointsInternal.method_0(j);
				if (class3.NotPlotted)
				{
					continue;
				}
				double num = 0.0;
				num = ((!flag) ? class3.XValue : class3.YValue);
				double num2 = 0.0;
				double num3 = 0.0;
				switch (class2.Type)
				{
				case ErrorBarValueType.Custom:
				{
					double num4 = 0.0;
					try
					{
						num4 = ((class2.MinusValue.Count > j) ? Convert.ToDouble(class2.MinusValue[j]) : 0.0);
					}
					catch (Exception ex)
					{
						Class1165.smethod_28(ex);
					}
					num2 = num4;
					try
					{
						num4 = ((class2.PlusValue.Count > j) ? Convert.ToDouble(class2.PlusValue[j]) : 0.0);
					}
					catch (Exception ex2)
					{
						Class1165.smethod_28(ex2);
					}
					num3 = num4;
					break;
				}
				case ErrorBarValueType.Fixed:
					num2 = class2.Amount;
					num3 = num2;
					break;
				case ErrorBarValueType.Percentage:
					num2 = class2.Amount * Math.Abs(num) / 100.0;
					num3 = class2.Amount * Math.Abs(num) / 100.0;
					break;
				}
				if (flag && (resembleType == ChartType.StackedColumn || resembleType == ChartType.StackedBar))
				{
					double num5 = num;
					for (int k = 0; k < i; k++)
					{
						Class748 class4 = ((Class759)list[k]).PointsInternal.method_0(j);
						if (class4 != null)
						{
							double yValue = class4.YValue;
							if (yValue > 0.0 && num > 0.0)
							{
								num5 += yValue;
							}
							if (yValue <= 0.0 && num <= 0.0)
							{
								num5 += yValue;
							}
						}
					}
					num = num5;
				}
				else if (flag && (resembleType == ChartType.PercentsStackedColumn || resembleType == ChartType.PercentsStackedBar))
				{
					double num6 = num;
					double num7 = 0.0;
					for (int l = 0; l < i; l++)
					{
						Class748 class5 = ((Class759)list[l]).PointsInternal.method_0(j);
						if (class5 != null)
						{
							double yValue2 = class5.YValue;
							if (yValue2 > 0.0 && num > 0.0)
							{
								num6 += yValue2;
							}
							if (yValue2 <= 0.0 && num <= 0.0)
							{
								num6 += yValue2;
							}
						}
					}
					for (int m = 0; m < list.Count; m++)
					{
						Class748 class6 = ((Class759)list[m]).PointsInternal.method_0(j);
						if (class6 != null)
						{
							double yValue3 = class6.YValue;
							num7 += Math.Abs(yValue3);
						}
					}
					num = num6 * 100.0 / num7;
					num3 = num3 * 100.0 / num7;
					num2 = num2 * 100.0 / num7;
				}
				if (num3 > 0.0 && num3 + num >= axisRenderContext.MaxValue && (class2.DisplayType == ErrorBarType.Both || class2.DisplayType == ErrorBarType.Plus))
				{
					for (double num8 = axisRenderContext.MaxValue + axisRenderContext.MajorUnit; num8 <= num3 + num + axisRenderContext.MajorUnit; num8 += axisRenderContext.MajorUnit)
					{
						arrayList_.Insert(0, num8);
					}
					if (axisRenderContext.Axis.IsAutomaticMaxValue)
					{
						axisRenderContext.MaxValue = (double)arrayList_[0];
					}
				}
				if (num2 < 0.0 && 0.0 - num2 + num >= axisRenderContext.MaxValue && (class2.DisplayType == ErrorBarType.Both || class2.DisplayType == ErrorBarType.Minus))
				{
					for (double num9 = axisRenderContext.MaxValue + axisRenderContext.MajorUnit; num9 <= 0.0 - num2 + num + axisRenderContext.MajorUnit; num9 += axisRenderContext.MajorUnit)
					{
						arrayList_.Insert(0, num9);
					}
					if (axisRenderContext.Axis.IsAutomaticMaxValue)
					{
						axisRenderContext.MaxValue = (double)arrayList_[0];
					}
				}
				if (num2 > 0.0 && num - num2 <= axisRenderContext.MinValue && (class2.DisplayType == ErrorBarType.Both || class2.DisplayType == ErrorBarType.Minus))
				{
					for (double num10 = axisRenderContext.MinValue - axisRenderContext.MajorUnit; num10 >= num - num2 - axisRenderContext.MajorUnit; num10 -= axisRenderContext.MajorUnit)
					{
						arrayList_.Add(num10);
					}
					if (axisRenderContext.Axis.IsAutomaticMinValue)
					{
						axisRenderContext.MinValue = (double)arrayList_[arrayList_.Count - 1];
					}
				}
				if (num3 < 0.0 && num + num3 <= axisRenderContext.MinValue && (class2.DisplayType == ErrorBarType.Both || class2.DisplayType == ErrorBarType.Plus))
				{
					for (double num11 = axisRenderContext.MinValue - axisRenderContext.MajorUnit; num11 >= num + num3 - axisRenderContext.MajorUnit; num11 -= axisRenderContext.MajorUnit)
					{
						arrayList_.Add(num11);
					}
					if (axisRenderContext.Axis.IsAutomaticMinValue)
					{
						axisRenderContext.MinValue = (double)arrayList_[arrayList_.Count - 1];
					}
				}
			}
		}
	}

	internal static int smethod_23(IList list)
	{
		List<int> list2 = new List<int>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(((Class759)list[i]).PointsInternal.Count);
		}
		list2.Sort();
		if (list2.Count == 0)
		{
			return 0;
		}
		return list2[list2.Count - 1];
	}

	internal static void smethod_24(IList list, out double minValue, out double maxValue, Class783 axisRenderContext)
	{
		List<List<Class759>> list2 = smethod_25(list);
		minValue = 0.0;
		maxValue = 0.0;
		if (axisRenderContext.Axis == null)
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < list2.Count; i++)
		{
			double minValue2;
			double maxValue2;
			bool flag = smethod_26(list2[i], out minValue2, out maxValue2);
			if (i == num && !flag)
			{
				num++;
				continue;
			}
			if (i == num)
			{
				minValue = minValue2;
				maxValue = maxValue2;
				continue;
			}
			if (minValue2 < minValue)
			{
				minValue = minValue2;
			}
			if (maxValue2 > maxValue)
			{
				maxValue = maxValue2;
			}
		}
		if (num == list2.Count && axisRenderContext.Axis.IsAutomaticMinValue != axisRenderContext.Axis.IsAutomaticMaxValue)
		{
			minValue = 0.0;
			maxValue = 1.0;
			if (!axisRenderContext.Axis.IsAutomaticMinValue)
			{
				axisRenderContext.MinValue = 0.0;
			}
			if (!axisRenderContext.Axis.IsAutomaticMaxValue)
			{
				axisRenderContext.MaxValue = 1.0;
			}
		}
		else
		{
			if (!axisRenderContext.Axis.IsAutomaticMinValue)
			{
				minValue = axisRenderContext.LogMinValue;
			}
			if (!axisRenderContext.Axis.IsAutomaticMaxValue)
			{
				maxValue = axisRenderContext.LogMaxValue;
			}
		}
	}

	private static List<List<Class759>> smethod_25(IList list)
	{
		Class759 @class = (Class759)list[0];
		List<List<Class759>> list2 = new List<List<Class759>>();
		List<Class759> list3 = new List<Class759>();
		List<Class759> list4 = new List<Class759>();
		foreach (Class759 item in list)
		{
			if (item.method_2(new ChartType[1] { @class.Type }))
			{
				list4.Add(item);
			}
			else
			{
				list3.Add(item);
			}
		}
		if (list4.Count > 0)
		{
			list2.Add(list4);
		}
		List<Class759> list5 = new List<Class759>();
		if (list3.Count > 0)
		{
			@class = list3[0];
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(list3);
			list3.Clear();
			foreach (Class759 item2 in arrayList)
			{
				if (item2.method_2(new ChartType[1] { @class.Type }))
				{
					list5.Add(item2);
				}
				else
				{
					list3.Add(item2);
				}
			}
		}
		if (list5.Count > 0)
		{
			list2.Add(list5);
		}
		if (list3.Count > 0)
		{
			list2.Add(list3);
		}
		return list2;
	}

	private static bool smethod_26(List<Class759> list, out double minValue, out double maxValue)
	{
		bool result = false;
		Class758 comparer = new Class758();
		list.Sort(comparer);
		minValue = 0.0;
		maxValue = 0.0;
		Class759 @class = list[0];
		if (@class.IsStatckedSeries)
		{
			if (@class.IsAreaStatckedSeries)
			{
				int num = smethod_23(list);
				bool flag = true;
				for (int i = 0; i < num; i++)
				{
					double num2 = 0.0;
					for (int j = 0; j < list.Count; j++)
					{
						Class759 class2 = list[j];
						if (!class2.IsStatckedSeries)
						{
							break;
						}
						Class748 class3 = class2.PointsInternal.method_0(i);
						if (class3 == null || class3.NotPlotted || class3 == null)
						{
							continue;
						}
						double yValue = class3.YValue;
						num2 += yValue;
						if (flag)
						{
							flag = false;
							result = true;
							minValue = num2;
							maxValue = num2;
							continue;
						}
						if (num2 < minValue)
						{
							minValue = num2;
						}
						if (num2 > maxValue)
						{
							maxValue = num2;
						}
					}
				}
			}
			else
			{
				int num3 = smethod_27(list);
				new ArrayList();
				int num4 = smethod_23(list);
				bool flag2 = true;
				for (int k = 0; k < num4; k++)
				{
					double num5 = 0.0;
					double num6 = 0.0;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = true;
					for (int l = 0; l < list.Count; l++)
					{
						Class759 class4 = list[l];
						if (!class4.IsStatckedSeries)
						{
							break;
						}
						Class748 class5 = class4.PointsInternal.method_0(k);
						if (class5 == null || class5.NotPlotted || class5 == null)
						{
							continue;
						}
						double yValue2 = class5.YValue;
						if (flag2)
						{
							flag2 = false;
							flag5 = false;
							result = true;
							switch (num3)
							{
							case 1:
								minValue = yValue2;
								break;
							case 2:
								maxValue = yValue2;
								break;
							}
						}
						else if (flag5)
						{
							flag5 = false;
							if (num3 == 1 && yValue2 < minValue)
							{
								minValue = yValue2;
							}
							else if (num3 == 2 && yValue2 > maxValue)
							{
								maxValue = yValue2;
							}
						}
						if (yValue2 < 0.0)
						{
							flag4 = true;
							num6 += yValue2;
						}
						if (yValue2 > 0.0)
						{
							flag3 = true;
							num5 += yValue2;
						}
					}
					if (flag4 && num6 < minValue)
					{
						minValue = num6;
					}
					if (flag3 && num5 > maxValue)
					{
						maxValue = num5;
					}
				}
			}
		}
		else if (@class.IsPercentSeries)
		{
			result = true;
			if (@class.IsAreaPercentSeries)
			{
				int num7 = smethod_23(list);
				for (int m = 0; m < num7; m++)
				{
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					for (int n = 0; n < list.Count; n++)
					{
						Class759 class6 = list[n];
						if (!class6.IsPercentSeries)
						{
							break;
						}
						Class748 class7 = class6.PointsInternal.method_0(m);
						if (class7 != null)
						{
							double yValue3 = class7.YValue;
							num8 += yValue3;
							num9 += Math.Abs(yValue3);
							if (num8 < num10)
							{
								num10 = num8;
							}
							if (num8 > num11)
							{
								num11 = num8;
							}
						}
					}
					if (num9 != 0.0)
					{
						int num12 = (int)(100.0 * num10 / num9);
						if ((double)num12 < minValue)
						{
							minValue = num12;
						}
						num12 = (int)(100.0 * num11 / num9);
						if ((double)num12 > maxValue)
						{
							maxValue = num12;
						}
					}
				}
			}
			else
			{
				int num13 = smethod_23(list);
				for (int num14 = 0; num14 < num13; num14++)
				{
					double num15 = 0.0;
					double num16 = 0.0;
					double num17 = 0.0;
					for (int num18 = 0; num18 < list.Count; num18++)
					{
						Class759 class8 = list[num18];
						if (!class8.IsPercentSeries)
						{
							break;
						}
						Class748 class9 = class8.PointsInternal.method_0(num14);
						if (class9 != null)
						{
							double yValue4 = class9.YValue;
							num15 += Math.Abs(yValue4);
							if (yValue4 < 0.0)
							{
								num17 += yValue4;
							}
							if (yValue4 > 0.0)
							{
								num16 += yValue4;
							}
						}
					}
					if (num15 != 0.0)
					{
						if ((double)(int)(100.0 * num17 / num15) < minValue)
						{
							minValue = (int)(100.0 * num17 / num15);
						}
						if ((double)(int)(100.0 * num16 / num15) > maxValue)
						{
							maxValue = (int)(100.0 * num16 / num15);
						}
					}
				}
			}
		}
		else
		{
			bool flag6 = true;
			for (int num19 = 0; num19 < list.Count; num19++)
			{
				Class747 pointsInternal = list[num19].PointsInternal;
				for (int num20 = 0; num20 < pointsInternal.Count; num20++)
				{
					if (pointsInternal[num20] != null && pointsInternal[num20].NotPlotted)
					{
						continue;
					}
					double num21 = ((pointsInternal[num20] == null) ? 0.0 : pointsInternal[num20].YValue);
					if (flag6)
					{
						minValue = num21;
						maxValue = num21;
						result = true;
						flag6 = false;
						continue;
					}
					if (num21 < minValue)
					{
						minValue = num21;
					}
					if (num21 > maxValue)
					{
						maxValue = num21;
					}
				}
			}
		}
		return result;
	}

	internal static int smethod_27(List<Class759> list)
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < list.Count; i++)
		{
			Class747 pointsInternal = list[i].PointsInternal;
			for (int j = 0; j < pointsInternal.Count; j++)
			{
				if (pointsInternal[j] != null)
				{
					double yValue = pointsInternal[j].YValue;
					if (yValue > 0.0)
					{
						flag = true;
					}
					else if (yValue < 0.0)
					{
						flag2 = true;
					}
				}
			}
		}
		if (flag && !flag2)
		{
			return 1;
		}
		if (!flag && flag2)
		{
			return 2;
		}
		return 3;
	}

	private static void smethod_28(IList list, out double minValue, out double maxValue, Class783 axisRenderContext)
	{
		minValue = 2147483647.0;
		maxValue = -2147483648.0;
		bool flag = axisRenderContext.AxisType == Enum160.const_2 || axisRenderContext.AxisType == Enum160.const_3;
		for (int i = 0; i < list.Count; i++)
		{
			Class759 @class = (Class759)list[i];
			Class747 pointsInternal = @class.PointsInternal;
			double num = 2147483647.0;
			double num2 = -2147483648.0;
			bool flag2 = true;
			Class752 class2 = (flag ? @class.YErrorBarInternal : @class.XErrorBarInternal);
			for (int j = 0; j < pointsInternal.Count; j++)
			{
				if (pointsInternal[j] == null || pointsInternal[j].XNotPlotted)
				{
					continue;
				}
				double xValue = pointsInternal[j].XValue;
				if (flag2)
				{
					num = xValue;
					num2 = xValue;
					flag2 = false;
				}
				if (xValue < num)
				{
					num = xValue;
				}
				if (xValue > num2)
				{
					num2 = xValue;
				}
				if (class2 == null || !class2.IsVisible || flag)
				{
					continue;
				}
				double num3 = 0.0;
				double num4 = 0.0;
				switch (class2.Type)
				{
				case ErrorBarValueType.Custom:
				{
					double num5 = 0.0;
					try
					{
						num5 = ((class2.MinusValue.Count > j) ? Convert.ToDouble(class2.MinusValue[j]) : 0.0);
					}
					catch (Exception ex)
					{
						Class1165.smethod_28(ex);
					}
					num3 = num5;
					try
					{
						num5 = ((class2.PlusValue.Count > j) ? Convert.ToDouble(class2.PlusValue[j]) : 0.0);
					}
					catch (Exception ex2)
					{
						Class1165.smethod_28(ex2);
					}
					num4 = num5;
					break;
				}
				case ErrorBarValueType.Fixed:
					num3 = class2.Amount;
					num4 = num3;
					break;
				case ErrorBarValueType.Percentage:
					num3 = class2.Amount * xValue / 100.0;
					num4 = num3;
					break;
				}
				if (num4 > 0.0 && num4 + xValue >= num2 && (class2.DisplayType == ErrorBarType.Both || class2.DisplayType == ErrorBarType.Plus))
				{
					num2 = num4 + xValue;
				}
				if (num4 < 0.0 && xValue + num4 <= num && (class2.DisplayType == ErrorBarType.Both || class2.DisplayType == ErrorBarType.Plus))
				{
					num = xValue + num4;
				}
				if (num3 > 0.0 && xValue - num3 <= num && (class2.DisplayType == ErrorBarType.Both || class2.DisplayType == ErrorBarType.Minus))
				{
					num = xValue - num3;
				}
				if (num3 < 0.0 && 0.0 - num3 + xValue >= num2 && (class2.DisplayType == ErrorBarType.Both || class2.DisplayType == ErrorBarType.Minus))
				{
					num2 = 0.0 - num3 + xValue;
				}
			}
			if (flag2)
			{
				num = 0.0;
				num2 = 0.0;
			}
			double num6 = 0.0;
			double num7 = 0.0;
			for (int k = 0; k < @class.TrendlinesInternal.Count; k++)
			{
				Class763 class3 = @class.TrendlinesInternal.method_0(k);
				if (class3.BorderInternal.IsVisible)
				{
					if (class3.Forward > num6)
					{
						num6 = class3.Forward;
					}
					if (class3.Backward > num7)
					{
						num7 = class3.Backward;
					}
				}
			}
			num -= num7;
			num2 += num6;
			if (num < minValue)
			{
				minValue = num;
			}
			if (num2 > maxValue)
			{
				maxValue = num2;
			}
		}
		if (!axisRenderContext.Axis.IsAutomaticMinValue)
		{
			minValue = axisRenderContext.LogMinValue;
		}
		if (!axisRenderContext.Axis.IsAutomaticMaxValue)
		{
			maxValue = axisRenderContext.LogMaxValue;
		}
	}

	private static bool smethod_29(Class784 renderContext, IList primarySeries, IList secondarySeries)
	{
		if (secondarySeries.Count > 0 && primarySeries.Count > 0)
		{
			Axis axis = renderContext.Y1AxisRenderContext.Axis;
			Axis axis2 = renderContext.Y2AxisRenderContext.Axis;
			Class759 @class = (Class759)primarySeries[0];
			Class759 class2 = (Class759)secondarySeries[0];
			if (@class.ResembleType != 0 && @class.ResembleType != ChartType.StackedColumn && @class.ResembleType != ChartType.PercentsStackedColumn && @class.ResembleType != ChartType.ScatterWithMarkers)
			{
				if (@class.ResembleType != ChartType.ClusteredBar && @class.ResembleType != ChartType.StackedBar && @class.ResembleType != ChartType.PercentsStackedBar)
				{
					if (@class.ResembleType != ChartType.Radar)
					{
						return false;
					}
					if (class2.ResembleType != ChartType.Radar)
					{
						return false;
					}
				}
				else if (class2.ResembleType != ChartType.ClusteredBar && class2.ResembleType != ChartType.StackedBar && class2.ResembleType != ChartType.PercentsStackedBar)
				{
					return false;
				}
			}
			else if (class2.ResembleType != 0 && class2.ResembleType != ChartType.StackedColumn && class2.ResembleType != ChartType.PercentsStackedColumn && class2.ResembleType != ChartType.ScatterWithMarkers)
			{
				return false;
			}
			if (axis != null && axis.IsVisible && axis2 != null && axis2.IsVisible)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private static Class783 smethod_30(Class784 renderContext)
	{
		Axis axis = renderContext.Y1AxisRenderContext.Axis;
		Axis axis2 = renderContext.Y2AxisRenderContext.Axis;
		if (axis != null && axis.IsVisible && (axis2 == null || !axis2.IsVisible))
		{
			return renderContext.Y2AxisRenderContext;
		}
		return renderContext.Y1AxisRenderContext;
	}

	internal static void smethod_31(IList primarySeries, IList secondarySeries, out double minValue, out double maxValue, Class783 axisRenderContext)
	{
		smethod_32(primarySeries, out var minValue2, out var maxValue2);
		smethod_32(secondarySeries, out var minValue3, out var maxValue3);
		if (minValue2 < minValue3)
		{
			minValue = minValue2;
		}
		else
		{
			minValue = minValue3;
		}
		if (maxValue2 < maxValue3)
		{
			maxValue = maxValue3;
		}
		else
		{
			maxValue = maxValue2;
		}
		if (axisRenderContext.Axis != null)
		{
			if (!axisRenderContext.Axis.IsAutomaticMinValue)
			{
				minValue = axisRenderContext.LogMinValue;
			}
			if (!axisRenderContext.Axis.IsAutomaticMaxValue)
			{
				maxValue = axisRenderContext.LogMaxValue;
			}
		}
	}

	internal static void smethod_32(IList list, out double minValue, out double maxValue)
	{
		List<List<Class759>> list2 = smethod_25(list);
		minValue = 0.0;
		maxValue = 0.0;
		for (int i = 0; i < list2.Count; i++)
		{
			smethod_26(list2[i], out var minValue2, out var maxValue2);
			if (i == 0)
			{
				minValue = minValue2;
				maxValue = maxValue2;
				continue;
			}
			if (minValue2 < minValue)
			{
				minValue = minValue2;
			}
			if (maxValue2 > maxValue)
			{
				maxValue = maxValue2;
			}
		}
	}

	internal static void smethod_33(Interface32 g, double maxValue, double minValue, ArrayList scales, ChartType chartType, Rectangle rect, bool isDisplayAxisSameAsBar, Class759 firstSeries, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis == null)
		{
			return;
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (axisRenderContext.Axis.IsLogarithmic)
		{
			smethod_55(g, maxValue, minValue, scales, chartType, rect, isDisplayAxisSameAsBar, firstSeries, axisRenderContext);
			return;
		}
		double originalMaxValue = maxValue;
		double originalMinValue = minValue;
		if (maxValue == minValue && maxValue == 0.0)
		{
			if (axisRenderContext.Axis.IsPlotOrderReversed)
			{
				axisRenderContext.MaxValue = 0.0;
				maxValue = 0.0;
				originalMaxValue = 0.0;
				axisRenderContext.MinValue = -1.0;
			}
			else
			{
				axisRenderContext.MaxValue = 1.0;
				maxValue = 1.0;
				originalMaxValue = 1.0;
				axisRenderContext.MinValue = 0.0;
			}
		}
		else if (maxValue <= minValue)
		{
			if (!axisRenderContext.Axis.IsAutomaticMaxValue && axisRenderContext.Axis.IsAutomaticMinValue)
			{
				axisRenderContext.MinValue = maxValue - 1.0;
				minValue = axisRenderContext.MinValue;
			}
			else if (axisRenderContext.Axis.IsAutomaticMaxValue && !axisRenderContext.Axis.IsAutomaticMinValue)
			{
				axisRenderContext.MaxValue = minValue + 1.0;
				maxValue = axisRenderContext.MaxValue;
			}
		}
		bool originalIsAutoMax = !chart.Is3DChart() && axisRenderContext.Axis.IsAutomaticMaxValue;
		bool isAutomaticMinValue = axisRenderContext.Axis.IsAutomaticMinValue;
		double step = 0.0;
		int direction = 1;
		bool isPercentChart;
		if (isPercentChart = smethod_42(chartType))
		{
			if (maxValue == 100.0 && axisRenderContext.Axis.IsAutomaticMaxValue)
			{
				axisRenderContext.MaxValue = 100.0;
			}
			if (minValue == -100.0 && axisRenderContext.Axis.IsAutomaticMinValue)
			{
				axisRenderContext.MinValue = -100.0;
			}
			axisRenderContext.MajorUnit *= 100.0;
		}
		double calculateMaxValue = 0.0;
		double calculateMinValue = 0.0;
		smethod_34(ref calculateMaxValue, ref calculateMinValue, ref minValue, ref maxValue, ref step, ref direction, isDisplayAxisSameAsBar, originalMaxValue, originalMinValue, originalIsAutoMax, isAutomaticMinValue, axisRenderContext);
		if (!axisRenderContext.IsAutoMinorUnit)
		{
			if (!axisRenderContext.IsAutoMajorUnit && axisRenderContext.MajorUnit < axisRenderContext.MinorUnit)
			{
				throw new ArgumentException("The numbers you specified can't be used because the interval for the minor unittick marks must be less than or equal to the interval for the major unit tick marks!");
			}
			if (step < axisRenderContext.MinorUnit)
			{
				step = axisRenderContext.MinorUnit;
			}
		}
		smethod_36(direction, step, calculateMinValue, calculateMaxValue, scales, originalMaxValue, originalMinValue, originalIsAutoMax, isAutomaticMinValue, isPercentChart, axisRenderContext);
		float num = smethod_37(g, isDisplayAxisSameAsBar, firstSeries, rect, axisRenderContext);
		int num2 = 0;
		num2 = (chart.Is3DChart() ? ((!isDisplayAxisSameAsBar) ? ((int)chart.WallsInternal.Height) : ((int)chart.WallsInternal.Width)) : ((!isDisplayAxisSameAsBar) ? rect.Height : rect.Width));
		while (axisRenderContext.IsAutoMajorUnit && scales.Count > 2 && num > (float)num2 && num2 != 0)
		{
			smethod_38(step, out step, out var _, axisRenderContext);
			step *= 10.0;
			smethod_36(direction, step, calculateMinValue, calculateMaxValue, scales, originalMaxValue, originalMinValue, originalIsAutoMax, isAutomaticMinValue, isPercentChart, axisRenderContext);
			num = smethod_37(g, isDisplayAxisSameAsBar, firstSeries, rect, axisRenderContext);
		}
		if (scales.Count >= 2)
		{
			axisRenderContext.MaxValue = (double)scales[0];
			axisRenderContext.MinValue = (double)scales[scales.Count - 1];
			if (axisRenderContext.IsAutoMajorUnit)
			{
				axisRenderContext.MajorUnit = step;
			}
			if (axisRenderContext.IsAutoMinorUnit)
			{
				axisRenderContext.MinorUnit = axisRenderContext.MajorUnit / 5.0;
			}
		}
	}

	public static void smethod_34(ref double calculateMaxValue, ref double calculateMinValue, ref double minValue, ref double maxValue, ref double step, ref int direction, bool isDisplayAxisSameAsBar, double originalMaxValue, double originalMinValue, bool originalIsAutoMax, bool originalIsAutoMin, Class783 axisRenderContext)
	{
		bool flag = axisRenderContext.Axis.IsAutomaticMinValue;
		bool flag2 = !axisRenderContext.ChartRenderContext.Chart2007.Is3DChart() && axisRenderContext.Axis.IsAutomaticMaxValue;
		if (axisRenderContext.IsAutoMajorUnit)
		{
			bool flag3 = true;
			smethod_38(minValue, out var step2, out var maxScale, axisRenderContext);
			smethod_38(maxValue, out var step3, out var maxScale2, axisRenderContext);
			calculateMinValue = ((minValue < maxScale) ? minValue : maxScale);
			calculateMaxValue = ((maxValue > maxScale2) ? maxValue : maxScale2);
			if (Math.Abs(step3) > Math.Abs(step2))
			{
				step = Math.Abs(step3);
			}
			else
			{
				step = Math.Abs(step2);
			}
			if (maxValue != minValue && maxValue > 0.0 && minValue > 0.0)
			{
				double num = Struct41.smethod_11(maxValue, minValue);
				smethod_38(num, out var step4, out var maxScale3, axisRenderContext);
				if (minValue / num >= 5.0)
				{
					calculateMinValue = Struct41.smethod_11(minValue, maxScale3) / 2.0;
					calculateMaxValue = minValue + maxScale3;
					step = Math.Abs(step4);
					if (Struct41.smethod_11(maxValue, minValue) / step >= 8.0)
					{
						smethod_40(ref step);
					}
					int digits = Struct41.smethod_9(step);
					double num2 = 0.0;
					double value = 3.0 * minValue - maxValue;
					value = Math.Round(value, 10);
					double num3 = 2.0 * step;
					double num4 = Math.Floor(value / num3);
					num2 = Math.Round(num4 * step, digits);
					if (flag && flag2)
					{
						axisRenderContext.MinValue = num2;
						flag = false;
						calculateMinValue = num2;
					}
				}
				else
				{
					if (flag && flag2)
					{
						axisRenderContext.MinValue = 0.0;
						flag = false;
					}
					calculateMinValue = 0.0;
				}
			}
			else if (maxValue != minValue && maxValue < 0.0 && minValue < 0.0)
			{
				double num5 = minValue - maxValue;
				smethod_38(num5, out var step5, out var maxScale4, axisRenderContext);
				if (minValue / num5 >= 5.0)
				{
					calculateMaxValue = maxValue - maxScale4 / 2.0;
					calculateMinValue = maxValue + maxScale4;
					step = Math.Abs(step5);
					if ((maxValue - minValue) / step >= 8.0)
					{
						smethod_40(ref step);
					}
					int digits2 = Struct41.smethod_9(step);
					double num6 = 0.0;
					while (num6 - 3.0 * step > maxValue)
					{
						num6 = Math.Round(num6, digits2);
						num6 -= step;
					}
					if (flag && flag2)
					{
						axisRenderContext.MaxValue = num6;
						calculateMaxValue = num6;
					}
				}
				else
				{
					if (flag && flag2)
					{
						axisRenderContext.MaxValue = 0.0;
						flag2 = false;
					}
					calculateMaxValue = 0.0;
				}
			}
			else if (maxValue != minValue && maxValue > 0.0 && minValue < 0.0)
			{
				double val = maxValue - minValue;
				smethod_38(val, out var step6, out var _, axisRenderContext);
				step = Math.Abs(step6);
				if ((maxValue - minValue) / step > 9.0)
				{
					smethod_40(ref step);
				}
			}
			if (flag && flag2)
			{
				direction = 3;
				if (minValue == 0.0 || (maxValue == minValue && maxValue > 0.0))
				{
					axisRenderContext.MinValue = 0.0;
					direction = 2;
					calculateMinValue = 0.0;
				}
				if (maxValue == 0.0 || (maxValue == minValue && maxValue < 0.0))
				{
					axisRenderContext.MaxValue = 0.0;
					direction = 1;
					calculateMaxValue = 0.0;
				}
			}
			else if (flag && !flag2)
			{
				direction = 1;
				calculateMaxValue = (axisRenderContext.ChartRenderContext.Chart2007.Is3DChart() ? maxValue : axisRenderContext.MaxValue);
				maxValue = axisRenderContext.MaxValue;
			}
			else if (!flag && flag2)
			{
				direction = 2;
				calculateMinValue = axisRenderContext.MinValue;
				minValue = axisRenderContext.MinValue;
			}
			else
			{
				direction = 2;
				calculateMinValue = axisRenderContext.MinValue;
				calculateMaxValue = axisRenderContext.MaxValue;
				minValue = axisRenderContext.MinValue;
				maxValue = axisRenderContext.MaxValue;
				double val2 = Struct41.smethod_11(maxValue, minValue);
				smethod_38(val2, out var step7, out var _, axisRenderContext);
				step = step7;
			}
			if ((!isDisplayAxisSameAsBar || smethod_44(axisRenderContext.ChartRenderContext.Chart2007.Type)) && flag3)
			{
				smethod_45(calculateMinValue, calculateMaxValue, ref step, direction, originalMaxValue, originalMinValue, originalIsAutoMax, originalIsAutoMin, axisRenderContext);
			}
			return;
		}
		step = axisRenderContext.MajorUnit;
		calculateMinValue = minValue;
		calculateMaxValue = maxValue;
		if (maxValue != minValue && maxValue > 0.0 && minValue > 0.0)
		{
			double num7 = maxValue - minValue;
			smethod_38(num7, out var step8, out var maxScale7, axisRenderContext);
			if (minValue / num7 >= 5.0)
			{
				calculateMinValue = minValue - maxScale7 / 2.0;
				calculateMaxValue = minValue + maxScale7;
				double num8 = Math.Abs(step8);
				int digits3 = Struct41.smethod_9(num8);
				double num9;
				for (num9 = 0.0; num9 < calculateMinValue; num9 += num8)
				{
					num9 = Math.Round(num9, digits3);
				}
				if (flag && flag2)
				{
					digits3 = Struct41.smethod_9(step);
					double num10;
					for (num10 = 0.0; num10 <= num9; num10 += step)
					{
						num10 = Math.Round(num10, digits3);
					}
					axisRenderContext.MinValue = num10 - step;
					flag = false;
					minValue = axisRenderContext.MinValue;
					calculateMinValue = axisRenderContext.MinValue;
				}
			}
			else
			{
				if (flag && flag2)
				{
					axisRenderContext.MinValue = 0.0;
					flag = false;
					minValue = axisRenderContext.MinValue;
				}
				calculateMinValue = 0.0;
			}
		}
		else if (maxValue != minValue && maxValue < 0.0 && minValue < 0.0)
		{
			double num11 = minValue - maxValue;
			smethod_38(num11, out var step9, out var maxScale8, axisRenderContext);
			if (minValue / num11 >= 5.0)
			{
				calculateMaxValue = maxValue - maxScale8 / 2.0;
				calculateMinValue = maxValue + maxScale8;
				double num12 = Math.Abs(step9);
				int digits4 = Struct41.smethod_9(num12);
				double num13;
				for (num13 = 0.0; num13 > calculateMaxValue; num13 -= num12)
				{
					num13 = Math.Round(num13, digits4);
				}
				if (flag && flag2)
				{
					digits4 = Struct41.smethod_9(step);
					double num14;
					for (num14 = 0.0; num14 >= num13; num14 -= step)
					{
						num14 = Math.Round(num14, digits4);
					}
					axisRenderContext.MaxValue = num14 + step;
					maxValue = axisRenderContext.MaxValue;
					flag2 = false;
					calculateMaxValue = axisRenderContext.MaxValue;
				}
			}
			else
			{
				if (flag && flag2)
				{
					axisRenderContext.MaxValue = 0.0;
					flag2 = false;
					maxValue = axisRenderContext.MaxValue;
				}
				calculateMaxValue = 0.0;
			}
		}
		if (flag && flag2)
		{
			direction = 3;
			if (minValue == 0.0)
			{
				axisRenderContext.MinValue = 0.0;
				direction = 2;
				calculateMinValue = 0.0;
			}
			if (maxValue == 0.0)
			{
				axisRenderContext.MaxValue = 0.0;
				direction = 1;
				calculateMaxValue = 0.0;
			}
		}
		else if (flag && !flag2)
		{
			direction = 1;
			calculateMaxValue = axisRenderContext.MaxValue;
			maxValue = axisRenderContext.MaxValue;
		}
		else if (!flag && flag2)
		{
			direction = 2;
			calculateMinValue = axisRenderContext.MinValue;
			minValue = axisRenderContext.MinValue;
		}
		else
		{
			direction = 2;
			calculateMinValue = axisRenderContext.MinValue;
			calculateMaxValue = axisRenderContext.MaxValue;
			minValue = axisRenderContext.MinValue;
			maxValue = axisRenderContext.MaxValue;
		}
	}

	private static bool smethod_35(Class740 chart)
	{
		if (!chart.Is3DChart() && chart.Type != ChartType.Radar && chart.Type != ChartType.FilledRadar && chart.Type != ChartType.RadarWithMarkers)
		{
			return false;
		}
		return true;
	}

	public static void smethod_36(int direction, double step, double calculateMinValue, double calculateMaxValue, ArrayList scales, double originalMaxValue, double originalMinValue, bool originalIsAutoMax, bool originalIsAutoMin, bool isPercentChart, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		scales.Clear();
		switch (direction)
		{
		case 1:
		{
			decimal num6 = (decimal)calculateMaxValue;
			int digits3 = Struct41.smethod_9(step);
			for (; num6 >= (decimal)calculateMinValue || (decimal)calculateMinValue - num6 < (decimal)step; num6 -= (decimal)step)
			{
				double num7 = Math.Round((double)num6, digits3);
				if (!axisRenderContext.Axis.IsAutomaticMinValue && num7 < axisRenderContext.MinValue)
				{
					scales.Add(axisRenderContext.MinValue);
				}
				else
				{
					scales.Add(num7);
				}
			}
			if (originalIsAutoMin)
			{
				double num8 = 2147483647.0;
				if (scales.Count > 0)
				{
					num8 = (double)scales[scales.Count - 1];
				}
				double num9 = originalMinValue - num8;
				if (num9 > step && num8 != 0.0)
				{
					num8 += step;
					if ((originalMinValue - calculateMaxValue) / (num8 - calculateMaxValue) <= 20.0 / 21.0)
					{
						scales.RemoveAt(scales.Count - 1);
					}
				}
				else if ((originalMinValue - calculateMaxValue) / (num8 - calculateMaxValue) > 20.0 / 21.0 && num8 != 0.0)
				{
					num6 = (decimal)Math.Round(num8 - step, digits3);
					scales.Add(num6);
				}
			}
			for (int i = 0; i < scales.Count; i++)
			{
				scales[i] = Convert.ToDouble(scales[i]);
			}
			break;
		}
		case 2:
		{
			double num4 = calculateMinValue;
			int digits2 = Struct41.smethod_9(step);
			while (num4 <= calculateMaxValue || num4 < calculateMaxValue + step)
			{
				num4 = Math.Round(num4, digits2);
				if (!axisRenderContext.Axis.IsAutomaticMaxValue && num4 > axisRenderContext.MaxValue)
				{
					scales.Add(axisRenderContext.MaxValue);
				}
				else
				{
					scales.Add(num4);
				}
				num4 += step;
			}
			if (originalIsAutoMax)
			{
				double num5 = -2147483648.0;
				if (scales.Count > 0)
				{
					num5 = (double)scales[scales.Count - 1];
				}
				if (Struct41.smethod_11(num5, originalMaxValue) > step && num5 != 0.0)
				{
					num5 -= step;
					if ((originalMaxValue - calculateMinValue) / (num5 - calculateMinValue) <= 20.0 / 21.0)
					{
						scales.RemoveAt(scales.Count - 1);
					}
				}
				else if ((originalMaxValue - calculateMinValue) / (num5 - calculateMinValue) > 20.0 / 21.0 && num5 != 0.0)
				{
					num4 = Math.Round(num5 + step, digits2);
					scales.Add(num4);
				}
			}
			scales.Reverse();
			break;
		}
		default:
		{
			double num = 0.0;
			int digits = Struct41.smethod_9(step);
			while (num <= calculateMaxValue || Struct41.smethod_11(num, calculateMaxValue) < step)
			{
				num = Math.Round(num, digits);
				if (!axisRenderContext.Axis.IsAutomaticMaxValue && num > axisRenderContext.MaxValue)
				{
					scales.Add(axisRenderContext.MaxValue);
				}
				else
				{
					scales.Add(num);
				}
				num += step;
			}
			if (originalIsAutoMax)
			{
				double num2 = -2147483648.0;
				if (scales.Count > 0)
				{
					num2 = (double)scales[scales.Count - 1];
				}
				if (num2 - originalMaxValue > step)
				{
					num2 -= step;
					if ((originalMaxValue - originalMinValue) / (num2 - originalMinValue) <= 20.0 / 21.0)
					{
						scales.RemoveAt(scales.Count - 1);
					}
				}
				else if ((originalMaxValue - originalMinValue) / (num2 - originalMinValue) > 20.0 / 21.0)
				{
					num = Math.Round(num2 + step, digits);
					scales.Add(num);
				}
			}
			scales.Reverse();
			num = 0.0 - step;
			while (num >= calculateMinValue || Struct41.smethod_11(calculateMinValue, num) < step)
			{
				num = Math.Round(num, digits);
				if (!axisRenderContext.Axis.IsAutomaticMinValue && num < axisRenderContext.MinValue)
				{
					scales.Add(axisRenderContext.MinValue);
				}
				else
				{
					scales.Add(num);
				}
				num -= step;
			}
			if (!originalIsAutoMin)
			{
				break;
			}
			double num3 = 2147483647.0;
			if (scales.Count > 0)
			{
				num3 = (double)scales[scales.Count - 1];
			}
			if (originalMinValue - num3 > step)
			{
				num3 += step;
				if ((originalMinValue - originalMaxValue) / (num3 - originalMaxValue) <= 20.0 / 21.0)
				{
					scales.RemoveAt(scales.Count - 1);
				}
			}
			else if ((originalMinValue - originalMaxValue) / (num3 - originalMaxValue) > 20.0 / 21.0)
			{
				num = Math.Round(num3 - step, digits);
				scales.Add(num);
			}
			break;
		}
		}
		if (scales.Count >= 2)
		{
			if ((isPercentChart || smethod_35(chart)) && (double)scales[0] >= originalMaxValue + step && (double)scales[0] != 0.0 && originalIsAutoMax && scales.Count >= 3)
			{
				scales.RemoveAt(0);
			}
			if ((isPercentChart || smethod_35(chart)) && (double)scales[scales.Count - 1] <= Struct41.smethod_11(originalMinValue, step) && (double)scales[scales.Count - 1] != 0.0 && originalIsAutoMin && scales.Count >= 3)
			{
				scales.RemoveAt(scales.Count - 1);
			}
		}
	}

	internal static float smethod_37(Interface32 g, bool isDisplayAxisSameAsBar, Class759 firstSeries, Rectangle rect, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis != null && axisRenderContext.Axis.TickLabelPosition != TickLabelPositionType.None)
		{
			ChartType resembleType = firstSeries.ResembleType;
			Class748 @class = firstSeries.PointsInternal.method_0(0);
			string format = @class.YFormat;
			bool yValueIsCulture = @class.YValueIsCulture;
			string text = "";
			for (int i = 0; i < axisRenderContext.arrayList_0.Count; i++)
			{
				double num = (double)axisRenderContext.arrayList_0[i];
				if (resembleType == ChartType.PercentsStackedBar || resembleType == ChartType.PercentsStackedColumn)
				{
					num /= 100.0;
					format = "0%";
				}
				string text2 = (axisRenderContext.IsLinkedSource ? Struct28.smethod_5(num, format, yValueIsCulture) : Struct21.smethod_34(num, axisRenderContext));
				if (text2.Length > text.Length)
				{
					text = text2;
				}
			}
			Size size = new Size(rect.Width, rect.Height);
			SizeF sizeF = default(SizeF);
			sizeF = Struct39.smethod_5(g, text, axisRenderContext.TickLableRotation, axisRenderContext.TickLabelTextFont, size, Enum157.const_1, Enum157.const_1, axisRenderContext.ChartRenderContext.Chart2007.Is3DChart());
			float num2 = 0f;
			if (isDisplayAxisSameAsBar)
			{
				return sizeF.Width * (float)(axisRenderContext.arrayList_0.Count - 1);
			}
			return sizeF.Height * (float)(axisRenderContext.arrayList_0.Count - 1);
		}
		return 0f;
	}

	public static void smethod_38(double val, out double step, out double maxScale, Class783 axisRenderContext)
	{
		bool flag = !(val < 0.0);
		val = Math.Abs(val);
		step = 0.0;
		maxScale = 0.0;
		if (val > 1.0)
		{
			smethod_39(val, out step, out maxScale, axisRenderContext);
		}
		else
		{
			if (val == 0.0)
			{
				return;
			}
			int num = Struct41.smethod_9(val);
			double val2 = val * Math.Pow(10.0, num);
			smethod_39(val2, out step, out maxScale, axisRenderContext);
			step /= Math.Pow(10.0, num);
			maxScale /= Math.Pow(10.0, num);
		}
		if (!flag)
		{
			step = 0.0 - step;
			maxScale = 0.0 - maxScale;
		}
	}

	private static void smethod_39(double val, out double step, out double maxScale, Class783 axisRenderContext)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		val = Math.Abs(val);
		step = 1.0;
		maxScale = 1.0;
		string text = val.ToString();
		string text2 = "";
		if (text.IndexOf("E") > 0)
		{
			string[] array = text.Split('E');
			text = array[0];
			text2 = "E" + array[1];
		}
		int num = int.Parse(text[0].ToString());
		int num2 = 0;
		if (text.Length > 1)
		{
			num2 = ((text[1] == c) ? int.Parse(text[2].ToString()) : int.Parse(text[1].ToString()));
		}
		if (num == 1)
		{
			int num3 = num2 / 2;
			num3++;
			num2 = num3 * 2;
			step = 2.0;
		}
		else if (num < 5)
		{
			if (num2 % 5 > 0)
			{
				num++;
				num2 = 0;
			}
			else
			{
				num2 = 5;
			}
			step = 5.0;
		}
		else
		{
			num++;
			step = 10.0;
			num2 = 0;
		}
		int num4 = text.Length;
		int num5 = text.IndexOf(c, 0);
		if (num5 > 0)
		{
			num4 = num5;
		}
		if (text2 == "")
		{
			step *= Math.Pow(10.0, num4 - 2);
			maxScale = (double)(num * 10 + num2) * Math.Pow(10.0, num4 - 2);
			return;
		}
		step *= Math.Pow(10.0, num4 - 2);
		maxScale = (double)(num * 10 + num2) * Math.Pow(10.0, num4 - 2);
		step = Convert.ToDouble(step + text2);
		maxScale = Convert.ToDouble(maxScale + text2);
	}

	private static void smethod_40(ref double step)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		bool flag = true;
		if (step < 0.0)
		{
			flag = false;
		}
		step = Math.Abs(step);
		int num = 1;
		if (step > 1.0)
		{
			string text = step.ToString();
			num = int.Parse(text[0].ToString());
		}
		else if (step == 0.0)
		{
			step = 0.0;
			return;
		}
		if (step < 1.0)
		{
			string text2 = step.ToString();
			for (int i = 0; i < text2.Length; i++)
			{
				if (text2[i] != '0' && text2[i] != c)
				{
					num = int.Parse(text2[i].ToString());
					break;
				}
			}
		}
		if (num != 1 && num != 5)
		{
			step = step * 5.0 / 2.0;
		}
		else
		{
			step = 2.0 * step;
		}
		if (!flag)
		{
			step = 0.0 - step;
		}
	}

	private static void smethod_41(ref double step)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		bool flag = true;
		if (step < 0.0)
		{
			flag = false;
		}
		step = Math.Abs(step);
		int num = 1;
		if (step > 1.0)
		{
			string text = step.ToString();
			num = int.Parse(text[0].ToString());
		}
		else if (step == 0.0)
		{
			step = 0.0;
			return;
		}
		if (step < 1.0)
		{
			string text2 = step.ToString();
			for (int i = 0; i < text2.Length; i++)
			{
				if (text2[i] != '0' && text2[i] != c)
				{
					num = int.Parse(text2[i].ToString());
					break;
				}
			}
		}
		if (num != 1 && num != 2)
		{
			step = step * 2.0 / 5.0;
		}
		else
		{
			step /= 2.0;
		}
		if (!flag)
		{
			step = 0.0 - step;
		}
	}

	internal static bool smethod_42(ChartType type)
	{
		switch (type)
		{
		default:
			return false;
		case ChartType.PercentsStackedColumn:
		case ChartType.PercentsStackedColumn3D:
		case ChartType.PercentsStackedCylinder:
		case ChartType.PercentsStackedCone:
		case ChartType.PercentsStackedPyramid:
		case ChartType.PercentsStackedLine:
		case ChartType.PercentsStackedLineWithMarkers:
		case ChartType.PercentsStackedBar:
		case ChartType.PercentsStackedBar3D:
		case ChartType.PercentsStackedHorizontalCylinder:
		case ChartType.PercentsStackedHorizontalCone:
		case ChartType.PercentsStackedHorizontalPyramid:
		case ChartType.PercentsStackedArea:
		case ChartType.PercentsStackedArea3D:
			return true;
		}
	}

	private static bool smethod_43(ChartType type)
	{
		switch (type)
		{
		default:
			return false;
		case ChartType.StackedColumn:
		case ChartType.StackedColumn3D:
		case ChartType.StackedCylinder:
		case ChartType.StackedCone:
		case ChartType.StackedPyramid:
		case ChartType.StackedLine:
		case ChartType.StackedLineWithMarkers:
		case ChartType.StackedBar:
		case ChartType.StackedBar3D:
		case ChartType.StackedHorizontalCylinder:
		case ChartType.StackedHorizontalCone:
		case ChartType.StackedHorizontalPyramid:
		case ChartType.StackedArea:
		case ChartType.StackedArea3D:
			return true;
		}
	}

	private static bool smethod_44(ChartType type)
	{
		if (type != ChartType.BubbleWith3D && type != ChartType.Bubble)
		{
			return false;
		}
		return true;
	}

	internal static void smethod_45(double calculateMinValue, double calculateMaxValue, ref double step, int direction, double originalMaxValue, double originalMinValue, bool originalIsAutoMax, bool originalIsAutoMin, Class783 axisRenderContext)
	{
		double num = calculateMinValue;
		double num2 = calculateMaxValue;
		int digits = Struct41.smethod_9(step);
		switch (direction)
		{
		case 1:
		{
			double num5 = calculateMaxValue;
			if (!axisRenderContext.Axis.IsAutomaticMinValue)
			{
				num = axisRenderContext.MinValue;
				break;
			}
			while (num5 >= calculateMinValue || calculateMinValue - num5 < step)
			{
				num5 = Math.Round(num5, digits);
				num = num5;
				double b4 = step;
				num5 = Struct41.smethod_11(num5, b4);
			}
			if ((!(Struct41.smethod_11(originalMinValue, num) > step) || num == 0.0) && (originalMinValue - calculateMaxValue) / (num - calculateMaxValue) > 20.0 / 21.0 && num != 0.0)
			{
				num = Math.Round(num - step, digits);
			}
			break;
		}
		case 2:
		{
			double num4 = calculateMinValue;
			if (!axisRenderContext.Axis.IsAutomaticMaxValue)
			{
				num2 = axisRenderContext.MaxValue;
				break;
			}
			while (num4 <= calculateMaxValue || num4 < calculateMaxValue + step)
			{
				num4 = Math.Round(num4, digits);
				num2 = num4;
				double b3 = step;
				num4 = Struct41.smethod_12(num4, b3);
			}
			if ((!(Struct41.smethod_11(num2, originalMaxValue) > step) || num2 == 0.0) && (originalMaxValue - calculateMinValue) / (num2 - calculateMinValue) > 20.0 / 21.0 && num2 != 0.0)
			{
				num2 = Math.Round(num2 + step, digits);
			}
			break;
		}
		default:
		{
			double num3 = 0.0;
			if (!axisRenderContext.Axis.IsAutomaticMinValue)
			{
				num = axisRenderContext.MinValue;
			}
			else
			{
				while (num3 >= calculateMinValue || calculateMinValue - num3 < step)
				{
					num3 = Math.Round(num3, digits);
					num = num3;
					double b = step;
					num3 = Struct41.smethod_11(num3, b);
				}
				if ((!(Struct41.smethod_11(originalMinValue, num) > step) || num == 0.0) && (originalMinValue - calculateMaxValue) / (num - calculateMaxValue) > 20.0 / 21.0 && num != 0.0)
				{
					num = Math.Round(num - step, digits);
				}
			}
			num3 = 0.0;
			if (!axisRenderContext.Axis.IsAutomaticMaxValue)
			{
				num2 = axisRenderContext.MinValue;
				break;
			}
			while (num3 <= calculateMaxValue || num3 < calculateMaxValue + step)
			{
				num3 = Math.Round(num3, digits);
				num2 = num3;
				double b2 = step;
				num3 = Struct41.smethod_12(num3, b2);
			}
			if ((!(Struct41.smethod_11(num2, originalMaxValue) > step) || num2 == 0.0) && (originalMaxValue - calculateMinValue) / (num2 - calculateMinValue) > 20.0 / 21.0 && num2 != 0.0)
			{
				num2 = Math.Round(num2 + step, digits);
			}
			break;
		}
		}
		double num6 = step;
		double num7 = (num2 - num) / step;
		int num8 = (smethod_44(axisRenderContext.ChartRenderContext.Chart2007.Type) ? 10 : 11);
		if (num7 > (double)num8)
		{
			smethod_40(ref step);
			return;
		}
		smethod_41(ref step);
		if (num2 - num > 10.0 * step)
		{
			step = num6;
		}
	}

	internal static void smethod_46(Interface32 g, ArrayList scales, Rectangle rect, ChartType chartType, Class757 nSeries, bool isDisplayAxisSameAsBar, Class783 axisRenderContext)
	{
		scales.Clear();
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		int num = smethod_23(nSeries.ListSeries);
		if (chartType != ChartType.ScatterWithMarkers && chartType != ChartType.Bubble)
		{
			smethod_48(axisRenderContext);
			if (axisRenderContext.Axis != null && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
			{
				List<Interface8> list = ((axisRenderContext.AxisType == Enum160.const_0) ? chart.NSeriesInternal.CategoryLabelsInternal : chart.NSeriesInternal.Category2LabelsInternal);
				if (list.Count != 0 && Type.GetTypeCode(list[0].LabelValue.GetType()) == TypeCode.String)
				{
					axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType = Enum267.const_1;
				}
			}
			if (axisRenderContext.Axis != null && axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
			{
				smethod_51(g, rect, chartType, nSeries, isDisplayAxisSameAsBar, axisRenderContext);
				return;
			}
			List<Interface8> list2 = ((axisRenderContext.AxisType == Enum160.const_0) ? chart.NSeriesInternal.CategoryLabelsInternal : chart.NSeriesInternal.Category2LabelsInternal);
			if (list2.Count > 0)
			{
				bool flag = smethod_47(list2);
				for (int i = 0; i < list2.Count && i < num; i++)
				{
					Class743 @class = (Class743)list2[i];
					if (@class.IsDate && flag)
					{
						DateTime dateTime = Struct41.smethod_29(Convert.ToDouble(@class.LabelValue), chart.IsDate1904);
						string value = Struct43.smethod_0(dateTime, @class.SourceFormat, @class.IsCulture);
						scales.Add(value);
					}
					else
					{
						scales.Add(@class.LabelValue);
					}
				}
				for (int j = 0; j < nSeries.Count; j++)
				{
					Class759 class2 = nSeries.method_0(j);
					for (int k = 0; k < class2.PointsInternal.Count; k++)
					{
						class2.PointsInternal.method_0(k).XValue = k + 1;
					}
				}
			}
			else if (chartType == ChartType.Pie)
			{
				for (int l = 1; l <= nSeries[0].Points.Count; l++)
				{
					scales.Add(l);
					Class743 item = new Class743(null, l);
					list2.Add(item);
				}
			}
			else
			{
				for (int m = 1; m <= num; m++)
				{
					scales.Add(m);
					Class743 item2 = new Class743(null, m);
					list2.Add(item2);
				}
				for (int n = 0; n < nSeries.Count; n++)
				{
					Class759 class3 = nSeries.method_0(n);
					for (int num2 = 0; num2 < class3.PointsInternal.Count; num2++)
					{
						class3.PointsInternal.method_0(num2).XValue = num2 + 1;
					}
				}
			}
			if (!axisRenderContext.AxisBetweenCategories && !axisRenderContext.ChartRenderContext.Chart.HasDataTable)
			{
				axisRenderContext.MinValue = 1.0;
				axisRenderContext.MaxValue = num;
			}
			else
			{
				axisRenderContext.MinValue = 1.0;
				axisRenderContext.MaxValue = num;
			}
			axisRenderContext.MajorUnit = 1.0;
			axisRenderContext.MinorUnit = axisRenderContext.MajorUnit / 2.0;
			return;
		}
		smethod_28(nSeries.ListSeries, out var minValue, out var maxValue, axisRenderContext);
		if (chartType == ChartType.Bubble && minValue == 0.0 && maxValue == 0.0)
		{
			axisRenderContext.MajorUnit = 1.0;
		}
		for (int num3 = 0; num3 < nSeries.Count; num3++)
		{
			Class759 class4 = nSeries.method_0(num3);
			double minValue2 = 0.0;
			double maxValue2 = 0.0;
			Class757 class5 = new Class757(chart);
			class5.Add(class4);
			smethod_28(class5.ListSeries, out minValue2, out maxValue2, axisRenderContext);
			if (minValue2 == 0.0 && maxValue2 == 0.0)
			{
				Class747 pointsInternal = class4.PointsInternal;
				for (int num4 = 0; num4 < pointsInternal.Count; num4++)
				{
					pointsInternal[num4].XValue = num4 + 1;
				}
			}
		}
		smethod_28(nSeries.ListSeries, out minValue, out maxValue, axisRenderContext);
		smethod_33(g, maxValue, minValue, scales, chartType, rect, isDisplayAxisSameAsBar: true, nSeries.method_0(0), axisRenderContext);
	}

	private static bool smethod_47(List<Interface8> categoryLabels)
	{
		int num = 0;
		while (true)
		{
			if (num < categoryLabels.Count)
			{
				Class743 @class = (Class743)categoryLabels[num];
				TypeCode typeCode = Type.GetTypeCode(@class.LabelValue.GetType());
				if (typeCode == TypeCode.String)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private static void smethod_48(Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis == null || axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return;
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
		}
		if (array != null || list.Count <= 0)
		{
			return;
		}
		Class743 @class = (Class743)list[0];
		if (!@class.IsDate || !smethod_49(@class.SourceFormat))
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < list.Count; i++)
		{
			Class743 class2 = (Class743)list[i];
			if (!class2.IsNull)
			{
				bool flag2 = false;
				if (class2.LabelValue == null)
				{
					flag2 = true;
				}
				if (class2.LabelValue.Equals(""))
				{
					flag2 = true;
				}
				if (flag2)
				{
					flag = false;
					break;
				}
				bool flag3 = false;
				switch (Type.GetTypeCode(class2.LabelValue.GetType()))
				{
				case TypeCode.Boolean:
				case TypeCode.Int32:
				case TypeCode.Double:
				case TypeCode.DateTime:
					flag3 = true;
					break;
				}
				if (!flag3)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType = Enum267.const_2;
		}
	}

	private static bool smethod_49(string format)
	{
		if (format == null)
		{
			return false;
		}
		format = format.ToLower();
		if (format.IndexOf("y") == -1 && format.IndexOf("d") == -1 && (format.IndexOf("m") == -1 || format.IndexOf("h") != -1 || format.IndexOf("s") != -1))
		{
			return false;
		}
		return true;
	}

	private static bool smethod_50(Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis == null)
		{
			return false;
		}
		if (axisRenderContext.Axis.PPTXUnsupportedProps.CategoryAxisType == Enum267.const_2)
		{
			return true;
		}
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		List<Interface8> list;
		List<Interface8>[] array;
		if (axisRenderContext.AxisType == Enum160.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			array = chart.NSeriesInternal.Categories;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			array = chart.NSeriesInternal.Categories2;
		}
		if (array != null)
		{
			return false;
		}
		if (list.Count > 0)
		{
			Class743 @class = (Class743)list[0];
			if (@class.IsDate && smethod_49(@class.SourceFormat))
			{
				bool flag = true;
				for (int i = 0; i < list.Count; i++)
				{
					Class743 class2 = (Class743)list[i];
					if (!class2.IsNull)
					{
						bool flag2 = false;
						if (class2.LabelValue == null)
						{
							flag2 = true;
						}
						if (class2.LabelValue.Equals(""))
						{
							flag2 = true;
						}
						if (flag2)
						{
							flag = false;
							break;
						}
						bool flag3 = false;
						switch (Type.GetTypeCode(class2.LabelValue.GetType()))
						{
						case TypeCode.Boolean:
						case TypeCode.Int32:
						case TypeCode.Double:
						case TypeCode.DateTime:
							flag3 = true;
							break;
						}
						if (!flag3)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void smethod_51(Interface32 g, Rectangle rect, ChartType chartType, Class757 nSeries, bool isDisplayAxisSameAsBar, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		ArrayList arrayList_ = axisRenderContext.arrayList_0;
		List<Interface8> list = ((axisRenderContext.AxisType == Enum160.const_0) ? chart.NSeriesInternal.CategoryLabelsInternal : chart.NSeriesInternal.Category2LabelsInternal);
		int num = smethod_23(nSeries.ListSeries);
		bool flag = list.Count == 0;
		List<int> list2 = new List<int>();
		if (list.Count > 0)
		{
			while (list.Count > num)
			{
				list.RemoveAt(list.Count - 1);
			}
			for (int i = 0; i < list.Count; i++)
			{
				Interface8 @interface = list[i];
				if (@interface.LabelValue != null && @interface.LabelValue.ToString().Equals("#N/A"))
				{
					list.RemoveAt(i);
					i--;
					continue;
				}
				int num2 = smethod_52(@interface.LabelValue, chart.IsDate1904);
				if (num2 >= 0)
				{
					list2.Add(num2);
				}
				else if (!@interface.IsNull)
				{
					flag = true;
					list2.Clear();
					list.Clear();
					break;
				}
			}
		}
		if (flag)
		{
			string text = "";
			text = ((axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Days) ? "M/d/yyyy" : ((axisRenderContext.Axis.BaseUnitScale != TimeUnitType.Months) ? "yyyy" : "MMM-yy"));
			for (int j = 1; j <= num; j++)
			{
				Class743 @class = new Class743(null, j);
				@class.IsCulture = false;
				@class.SourceFormat = text;
				list.Add(@class);
				list2.Add(j);
			}
		}
		for (int k = 0; k < nSeries.Count; k++)
		{
			Class759 class2 = nSeries.method_0(k);
			for (int l = 0; l < list.Count; l++)
			{
				Class748 class3 = class2.PointsInternal.method_0(l);
				if (class3 != null)
				{
					Class743 class4 = (Class743)list[l];
					int num3 = smethod_52(class4.LabelValue, chart.IsDate1904);
					class3.XValue = num3;
				}
			}
		}
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(list2);
		arrayList.Sort();
		if (axisRenderContext.Axis.IsAutomaticMaxValue)
		{
			axisRenderContext.MaxValue = Struct21.smethod_38(axisRenderContext.Axis.BaseUnitScale, (int)arrayList[arrayList.Count - 1], chart.IsDate1904);
		}
		if (axisRenderContext.Axis.IsAutomaticMinValue)
		{
			axisRenderContext.MinValue = Struct21.smethod_38(axisRenderContext.Axis.BaseUnitScale, (int)arrayList[0], chart.IsDate1904);
		}
		smethod_53(g, rect, chartType, isDisplayAxisSameAsBar, flag, axisRenderContext);
		int num4 = (int)axisRenderContext.MinValue;
		int num5 = (int)axisRenderContext.MaxValue;
		int start = num4;
		arrayList_.Clear();
		arrayList_.Add(num4);
		start = Struct21.smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, start, chart.IsDate1904);
		while (num5 - start >= 0)
		{
			arrayList_.Add(start);
			start = Struct21.smethod_37(axisRenderContext.Axis.BaseUnitScale, axisRenderContext.MajorUnitScale, (int)axisRenderContext.MajorUnit, start, chart.IsDate1904);
		}
	}

	[Attribute7(true)]
	internal static int smethod_52(object o, bool date1904)
	{
		int result = -10000;
		if (o == null)
		{
			return result;
		}
		switch (Type.GetTypeCode(o.GetType()))
		{
		case TypeCode.DateTime:
		{
			DateTime dateTime = Convert.ToDateTime(o);
			return Struct21.smethod_33(dateTime, date1904);
		}
		default:
			try
			{
				return Convert.ToInt16(o);
			}
			catch (Exception ex)
			{
				Class1165.smethod_28(ex);
				return result;
			}
		case TypeCode.String:
		{
			string text = o.ToString();
			if (text == "")
			{
				return result;
			}
			if (double.TryParse(text, NumberStyles.Integer, CultureInfo.CurrentCulture, out var _))
			{
				return int.Parse(text);
			}
			return result;
		}
		case TypeCode.Boolean:
		case TypeCode.Int32:
		case TypeCode.Double:
			return Convert.ToInt32(o);
		}
	}

	private static void smethod_53(Interface32 g, Rectangle rect, ChartType chartType, bool isDisplayAxisSameAsBar, bool isAutoLabels, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		float num = 0f;
		string text = Struct21.smethod_34(axisRenderContext.MaxValue, axisRenderContext);
		SizeF layoutArea = new SizeF(rect.Width, rect.Height);
		bool tickLabelAutoRotation = axisRenderContext.TickLabelAutoRotation;
		Size size = Struct39.smethod_12(chart.Graphics, text, 0, axisRenderContext.TickLabelTextFont, layoutArea, Enum157.const_1, Enum157.const_1);
		Size size2 = Struct39.smethod_10(g, "0", axisRenderContext.TickLabelTextFont);
		float num2;
		float num3;
		if (isDisplayAxisSameAsBar)
		{
			num2 = rect.Height;
			num3 = ((!tickLabelAutoRotation) ? ((float)size.Height) : ((float)size.Height));
		}
		else
		{
			num2 = rect.Width;
			num3 = (tickLabelAutoRotation ? ((float)(size.Width + size2.Width)) : ((axisRenderContext.TickLableRotation == 0) ? ((float)size.Width) : ((axisRenderContext.TickLableRotation == 90 || axisRenderContext.TickLableRotation == -90) ? ((float)size.Height) : ((float)((double)size.Height / Math.Sin((double)Math.Abs(axisRenderContext.TickLableRotation) * Math.PI / 180.0))))));
		}
		int maxValue = (int)axisRenderContext.MaxValue;
		int minValue = (int)axisRenderContext.MinValue;
		TimeUnitType baseUnitScale = axisRenderContext.Axis.BaseUnitScale;
		int num4;
		if (!axisRenderContext.AxisBetweenCategories && !axisRenderContext.ChartRenderContext.Chart.HasDataTable)
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
		if (axisRenderContext.IsAutoMajorUnit && axisRenderContext.IsAutoMinorUnit)
		{
			while (true)
			{
				if (!((float)num4 * (num3 + num) < num2))
				{
					if (!tickLabelAutoRotation || isAutoLabels)
					{
						break;
					}
					if (axisRenderContext.TickLableRotation == 0)
					{
						axisRenderContext.TickLableRotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(axisRenderContext.TickLableRotation) * Math.PI / 180.0));
						continue;
					}
					if (axisRenderContext.TickLableRotation == 45)
					{
						axisRenderContext.TickLableRotation = 90;
						num3 = size.Height;
					}
					break;
				}
				axisRenderContext.MajorUnit = 1.0;
				axisRenderContext.MinorUnit = 1.0;
				axisRenderContext.MajorUnitScale = axisRenderContext.Axis.BaseUnitScale;
				axisRenderContext.MinorUnitScale = axisRenderContext.Axis.BaseUnitScale;
				return;
			}
			if (tickLabelAutoRotation && !isAutoLabels && axisRenderContext.TickLableRotation > 0)
			{
				num3 *= 2f;
			}
			int num5 = (int)(num2 / (num3 + num));
			int num6 = ((num4 % num5 == 0) ? (num4 / num5) : (num4 / num5 + 1));
			if (axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Days)
			{
				if (num6 <= 2)
				{
					axisRenderContext.MajorUnit = num6;
					axisRenderContext.MinorUnit = 1.0;
					axisRenderContext.MajorUnitScale = axisRenderContext.Axis.BaseUnitScale;
					axisRenderContext.MinorUnitScale = axisRenderContext.Axis.BaseUnitScale;
				}
				else if (num6 > 2 && num6 <= 7)
				{
					axisRenderContext.MajorUnit = 7.0;
					axisRenderContext.MinorUnit = 1.0;
					axisRenderContext.MajorUnitScale = axisRenderContext.Axis.BaseUnitScale;
					axisRenderContext.MinorUnitScale = axisRenderContext.Axis.BaseUnitScale;
				}
				else if (num6 > 7 && num6 <= 14)
				{
					axisRenderContext.MajorUnit = 14.0;
					axisRenderContext.MinorUnit = 7.0;
					axisRenderContext.MajorUnitScale = axisRenderContext.Axis.BaseUnitScale;
					axisRenderContext.MinorUnitScale = axisRenderContext.Axis.BaseUnitScale;
				}
				else if (num6 > 14 && num6 <= 30)
				{
					axisRenderContext.MajorUnit = 1.0;
					axisRenderContext.MinorUnit = 1.0;
					axisRenderContext.MajorUnitScale = TimeUnitType.Months;
					axisRenderContext.MinorUnitScale = TimeUnitType.Months;
				}
				else if (num6 > 30 && num6 <= 360)
				{
					axisRenderContext.MajorUnit = ((num6 % 30 == 0) ? (num6 / 30) : (num6 / 30 + 1));
					axisRenderContext.MinorUnit = (((int)(axisRenderContext.MajorUnit / 2.0) == 0) ? 1 : ((int)(axisRenderContext.MajorUnit / 2.0)));
					axisRenderContext.MajorUnitScale = TimeUnitType.Months;
					axisRenderContext.MinorUnitScale = TimeUnitType.Months;
				}
				else
				{
					axisRenderContext.MajorUnit = ((num6 % 360 == 0) ? (num6 / 360) : (num6 / 360 + 1));
					axisRenderContext.MinorUnit = (((int)(axisRenderContext.MajorUnit / 2.0) == 0) ? 1 : ((int)(axisRenderContext.MajorUnit / 2.0)));
					axisRenderContext.MajorUnitScale = TimeUnitType.Years;
					axisRenderContext.MinorUnitScale = TimeUnitType.Years;
				}
			}
			else if (axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Months)
			{
				if (num6 < 12)
				{
					axisRenderContext.MajorUnit = num6;
					axisRenderContext.MinorUnit = (((int)(axisRenderContext.MajorUnit / 2.0) == 0) ? 1 : ((int)(axisRenderContext.MajorUnit / 2.0)));
					axisRenderContext.MajorUnitScale = TimeUnitType.Months;
					axisRenderContext.MinorUnitScale = TimeUnitType.Months;
				}
				else
				{
					axisRenderContext.MajorUnit = ((num6 % 12 == 0) ? (num6 / 12) : (num6 / 12 + 1));
					axisRenderContext.MinorUnit = (((int)(axisRenderContext.MajorUnit / 2.0) == 0) ? 1 : ((int)(axisRenderContext.MajorUnit / 2.0)));
					axisRenderContext.MajorUnitScale = TimeUnitType.Years;
					axisRenderContext.MinorUnitScale = TimeUnitType.Years;
				}
			}
			else
			{
				axisRenderContext.MajorUnit = num6;
				axisRenderContext.MinorUnit = (((int)(axisRenderContext.MajorUnit / 2.0) == 0) ? 1 : ((int)(axisRenderContext.MajorUnit / 2.0)));
				axisRenderContext.MajorUnitScale = TimeUnitType.Years;
				axisRenderContext.MinorUnitScale = TimeUnitType.Years;
			}
		}
		else if (axisRenderContext.IsAutoMajorUnit && !axisRenderContext.IsAutoMinorUnit)
		{
			int num7 = Struct41.smethod_3((float)((double)Struct21.smethod_36(axisRenderContext.MinorUnitScale, maxValue, minValue, chart.IsDate1904) / axisRenderContext.MinorUnit));
			if (!axisRenderContext.AxisBetweenCategories && !axisRenderContext.ChartRenderContext.Chart.HasDataTable)
			{
				num4 = num7;
				if (num4 == 0)
				{
					num4 = 1;
				}
			}
			else
			{
				num4 = num7 + 1;
			}
			while (true)
			{
				if (!((float)num4 * (num3 + num) < num2))
				{
					if (!tickLabelAutoRotation || isAutoLabels)
					{
						break;
					}
					if (axisRenderContext.TickLableRotation == 0)
					{
						axisRenderContext.TickLableRotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(axisRenderContext.TickLableRotation) * Math.PI / 180.0));
						continue;
					}
					if (axisRenderContext.TickLableRotation == 45)
					{
						axisRenderContext.TickLableRotation = 90;
						num3 = size.Height;
					}
					break;
				}
				axisRenderContext.MajorUnitScale = axisRenderContext.MinorUnitScale;
				axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
				return;
			}
			if (tickLabelAutoRotation && !isAutoLabels && axisRenderContext.TickLableRotation > 0)
			{
				num3 *= 2f;
			}
			int num8 = (int)(num2 / (num3 + num));
			int num9 = ((num4 % num8 == 0) ? (num4 / num8) : (num4 / num8 + 1));
			if (axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Days)
			{
				if (num9 <= 2)
				{
					if (axisRenderContext.MinorUnitScale > axisRenderContext.Axis.BaseUnitScale)
					{
						axisRenderContext.MajorUnitScale = axisRenderContext.MinorUnitScale;
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
						return;
					}
					axisRenderContext.MajorUnitScale = axisRenderContext.Axis.BaseUnitScale;
					axisRenderContext.MajorUnit = num9;
					if (axisRenderContext.MajorUnit < axisRenderContext.MinorUnit)
					{
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
					}
				}
				else if (num9 > 2 && num9 <= 7)
				{
					if (axisRenderContext.MinorUnitScale > axisRenderContext.Axis.BaseUnitScale)
					{
						axisRenderContext.MajorUnitScale = axisRenderContext.MinorUnitScale;
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
						return;
					}
					axisRenderContext.MajorUnitScale = axisRenderContext.Axis.BaseUnitScale;
					axisRenderContext.MajorUnit = 7.0;
					if (axisRenderContext.MajorUnit < axisRenderContext.MinorUnit)
					{
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
					}
				}
				else if (num9 > 7 && num9 <= 14)
				{
					if (axisRenderContext.MinorUnitScale > axisRenderContext.Axis.BaseUnitScale)
					{
						axisRenderContext.MajorUnitScale = axisRenderContext.MinorUnitScale;
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
						return;
					}
					axisRenderContext.MajorUnitScale = axisRenderContext.Axis.BaseUnitScale;
					axisRenderContext.MajorUnit = 14.0;
					if (axisRenderContext.MajorUnit < axisRenderContext.MinorUnit)
					{
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
					}
				}
				else if (num9 > 14 && num9 <= 30)
				{
					if (axisRenderContext.MinorUnitScale == TimeUnitType.Years)
					{
						axisRenderContext.MajorUnitScale = axisRenderContext.MinorUnitScale;
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
						return;
					}
					axisRenderContext.MajorUnitScale = TimeUnitType.Months;
					axisRenderContext.MajorUnit = 1.0;
					if (axisRenderContext.MajorUnit < axisRenderContext.MinorUnit && axisRenderContext.MinorUnitScale == TimeUnitType.Months)
					{
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
					}
				}
				else if (num9 > 30 && num9 <= 360)
				{
					if (axisRenderContext.MinorUnitScale == TimeUnitType.Years)
					{
						axisRenderContext.MajorUnitScale = axisRenderContext.MinorUnitScale;
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
						return;
					}
					axisRenderContext.MajorUnitScale = TimeUnitType.Months;
					axisRenderContext.MajorUnit = ((num9 % 30 == 0) ? (num9 / 30) : (num9 / 30 + 1));
					if (axisRenderContext.MajorUnit < axisRenderContext.MinorUnit && axisRenderContext.MinorUnitScale == TimeUnitType.Months)
					{
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
					}
				}
				else
				{
					axisRenderContext.MajorUnit = ((num9 % 360 == 0) ? (num9 / 360) : (num9 / 360 + 1));
					axisRenderContext.MajorUnitScale = TimeUnitType.Years;
					if (axisRenderContext.MajorUnit < axisRenderContext.MinorUnit && axisRenderContext.MinorUnitScale == TimeUnitType.Years)
					{
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
					}
				}
			}
			else if (axisRenderContext.Axis.BaseUnitScale == TimeUnitType.Months)
			{
				if (num9 < 12)
				{
					if (axisRenderContext.MinorUnitScale == TimeUnitType.Months)
					{
						if (axisRenderContext.MinorUnit <= (double)num9)
						{
							axisRenderContext.MajorUnit = num9;
							axisRenderContext.MajorUnitScale = TimeUnitType.Months;
						}
						else
						{
							axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
							axisRenderContext.MajorUnitScale = TimeUnitType.Months;
						}
					}
					else
					{
						axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
						axisRenderContext.MajorUnitScale = TimeUnitType.Years;
					}
					return;
				}
				num9 = ((num9 % 12 == 0) ? (num9 / 12) : (num9 / 12 + 1));
				if (axisRenderContext.MinorUnitScale == TimeUnitType.Months)
				{
					axisRenderContext.MajorUnit = num9;
					axisRenderContext.MajorUnitScale = TimeUnitType.Years;
				}
				else if (axisRenderContext.MinorUnit <= (double)num9)
				{
					axisRenderContext.MajorUnit = num9;
					axisRenderContext.MajorUnitScale = TimeUnitType.Years;
				}
				else
				{
					axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
					axisRenderContext.MajorUnitScale = TimeUnitType.Years;
				}
			}
			else
			{
				if (axisRenderContext.MinorUnit <= (double)num9)
				{
					axisRenderContext.MajorUnit = num9;
				}
				else
				{
					axisRenderContext.MajorUnit = axisRenderContext.MinorUnit;
				}
				axisRenderContext.MajorUnitScale = TimeUnitType.Years;
			}
		}
		else if (!axisRenderContext.IsAutoMajorUnit && axisRenderContext.IsAutoMinorUnit)
		{
			axisRenderContext.MinorUnit = (((int)(axisRenderContext.MajorUnit / 2.0) == 0) ? 1 : ((int)(axisRenderContext.MajorUnit / 2.0)));
			axisRenderContext.MinorUnitScale = axisRenderContext.MajorUnitScale;
			if (!tickLabelAutoRotation || isAutoLabels)
			{
				return;
			}
			int num10 = Struct41.smethod_3((float)((double)Struct21.smethod_36(axisRenderContext.MajorUnitScale, maxValue, minValue, chart.IsDate1904) / axisRenderContext.MajorUnit));
			if (!axisRenderContext.AxisBetweenCategories && !axisRenderContext.ChartRenderContext.Chart.HasDataTable)
			{
				num4 = num10;
				if (num4 == 0)
				{
					num4 = 1;
				}
			}
			else
			{
				num4 = num10 + 1;
			}
			while (true)
			{
				if ((float)num4 * (num3 + num) > num2)
				{
					if (axisRenderContext.TickLableRotation == 0)
					{
						axisRenderContext.TickLableRotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(axisRenderContext.TickLableRotation) * Math.PI / 180.0));
					}
					else if (axisRenderContext.TickLableRotation == 45)
					{
						break;
					}
					continue;
				}
				return;
			}
			axisRenderContext.TickLableRotation = 90;
		}
		else
		{
			if (!tickLabelAutoRotation || isAutoLabels)
			{
				return;
			}
			int num11 = Struct41.smethod_3(Struct21.smethod_36(axisRenderContext.MajorUnitScale, maxValue, minValue, chart.IsDate1904));
			num4 = num11;
			if (num4 == 0)
			{
				num4 = 1;
			}
			while (true)
			{
				if ((float)num4 * (num3 + num) > num2)
				{
					if (axisRenderContext.TickLableRotation == 0)
					{
						axisRenderContext.TickLableRotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(axisRenderContext.TickLableRotation) * Math.PI / 180.0));
					}
					else if (axisRenderContext.TickLableRotation == 45)
					{
						break;
					}
					continue;
				}
				return;
			}
			axisRenderContext.TickLableRotation = 90;
		}
	}

	internal static List<int> smethod_54(List<Interface8> list, bool date1904)
	{
		List<int> list2 = new List<int>();
		for (int i = 0; i < list.Count; i++)
		{
			int item = smethod_52(list[i].LabelValue, date1904);
			list2.Add(item);
		}
		return list2;
	}

	internal static void smethod_55(Interface32 g, double maxValue, double minValue, ArrayList scales, ChartType chartType, Rectangle rect, bool isDisplayAxisSameAsBar, Class759 firstSeries, Class783 axisRenderContext)
	{
		Class740 chart = axisRenderContext.ChartRenderContext.Chart2007;
		if (maxValue == minValue && maxValue == 0.0)
		{
			axisRenderContext.MaxValue = 10.0;
			maxValue = 10.0;
			axisRenderContext.MinValue = 1.0;
		}
		double step = 0.0;
		int direction = 1;
		if (firstSeries.IsPercentSeries)
		{
			if (maxValue == 100.0 && axisRenderContext.Axis.IsAutomaticMaxValue)
			{
				axisRenderContext.MaxValue = 100.0;
			}
			if (minValue >= 1.0 && axisRenderContext.Axis.IsAutomaticMinValue)
			{
				axisRenderContext.MinValue = 1.0;
			}
		}
		double calculateMaxValue = 0.0;
		double calculateMinValue = 0.0;
		smethod_56(ref calculateMaxValue, ref calculateMinValue, ref minValue, ref maxValue, ref step, ref direction, isDisplayAxisSameAsBar, axisRenderContext);
		smethod_57(direction, step, calculateMinValue, calculateMaxValue, scales, axisRenderContext);
		int num = smethod_58(g, isDisplayAxisSameAsBar, firstSeries, rect, axisRenderContext);
		int num2 = 0;
		num2 = (chart.Is3DChart() ? ((!isDisplayAxisSameAsBar) ? ((int)chart.WallsInternal.Height) : ((int)chart.WallsInternal.Width)) : ((!isDisplayAxisSameAsBar) ? rect.Height : rect.Width));
		while (axisRenderContext.IsAutoMajorUnit && scales.Count > 3 && num > num2 && num2 != 0)
		{
			step += 1.0;
			smethod_57(direction, step, calculateMinValue, calculateMaxValue, scales, axisRenderContext);
			num = smethod_58(g, isDisplayAxisSameAsBar, firstSeries, rect, axisRenderContext);
		}
		if (scales.Count >= 2)
		{
			if (axisRenderContext.Axis.IsAutomaticMaxValue)
			{
				axisRenderContext.MaxValue = axisRenderContext.method_1((double)scales[0]);
			}
			if (axisRenderContext.Axis.IsAutomaticMinValue)
			{
				axisRenderContext.MinValue = axisRenderContext.method_1((double)scales[scales.Count - 1]);
			}
			if (axisRenderContext.IsAutoMajorUnit)
			{
				axisRenderContext.MajorUnit = axisRenderContext.method_1(step);
			}
			if (axisRenderContext.IsAutoMinorUnit)
			{
				axisRenderContext.MinorUnit = axisRenderContext.MajorUnit;
			}
		}
	}

	private static void smethod_56(ref double calculateMaxValue, ref double calculateMinValue, ref double minValue, ref double maxValue, ref double step, ref int direction, bool isDisplayAxisSameAsBar, Class783 axisRenderContext)
	{
		step = 1.0;
		double num;
		double num2;
		if (!axisRenderContext.IsAutoMajorUnit && axisRenderContext.method_0(axisRenderContext.MajorUnit) != 0.0)
		{
			step = axisRenderContext.method_0(axisRenderContext.MajorUnit);
			num = (int)minValue;
			num2 = (double)(int)maxValue + step;
			calculateMinValue = num;
			calculateMaxValue = num2;
			if (axisRenderContext.Axis.IsAutomaticMaxValue && axisRenderContext.Axis.IsAutomaticMinValue)
			{
				if (num >= 0.0 && num2 >= 0.0)
				{
					axisRenderContext.MinValue = axisRenderContext.method_1(0.0);
					direction = 2;
					calculateMinValue = 0.0;
				}
				else
				{
					axisRenderContext.MinValue = axisRenderContext.method_1(num);
					direction = 2;
					calculateMinValue = num;
				}
			}
			else if (!axisRenderContext.Axis.IsAutomaticMaxValue && axisRenderContext.Axis.IsAutomaticMinValue)
			{
				direction = 1;
				calculateMaxValue = axisRenderContext.method_0(axisRenderContext.MaxValue);
				maxValue = calculateMaxValue;
			}
			else if (axisRenderContext.Axis.IsAutomaticMaxValue && !axisRenderContext.Axis.IsAutomaticMinValue)
			{
				direction = 2;
				calculateMinValue = axisRenderContext.method_0(axisRenderContext.MinValue);
				minValue = calculateMinValue;
			}
			else
			{
				direction = 2;
				calculateMinValue = axisRenderContext.method_0(axisRenderContext.MinValue);
				calculateMaxValue = axisRenderContext.method_0(axisRenderContext.MaxValue);
				minValue = axisRenderContext.method_0(axisRenderContext.MinValue);
				maxValue = axisRenderContext.method_0(axisRenderContext.MaxValue);
			}
			return;
		}
		num = smethod_60(minValue);
		num2 = smethod_59(maxValue);
		calculateMinValue = num;
		calculateMaxValue = num2;
		if (axisRenderContext.Axis.IsAutomaticMaxValue && axisRenderContext.Axis.IsAutomaticMinValue)
		{
			if (num >= 0.0 && num2 >= 0.0)
			{
				axisRenderContext.MinValue = axisRenderContext.method_1(0.0);
				direction = 2;
				calculateMinValue = 0.0;
			}
			else
			{
				axisRenderContext.MinValue = axisRenderContext.method_1(num);
				direction = 2;
				calculateMinValue = num;
			}
		}
		else if (!axisRenderContext.Axis.IsAutomaticMaxValue && axisRenderContext.Axis.IsAutomaticMinValue)
		{
			direction = 1;
			calculateMaxValue = axisRenderContext.method_0(axisRenderContext.MaxValue);
			maxValue = calculateMaxValue;
		}
		else if (axisRenderContext.Axis.IsAutomaticMaxValue && !axisRenderContext.Axis.IsAutomaticMinValue)
		{
			direction = 2;
			calculateMinValue = axisRenderContext.method_0(axisRenderContext.MinValue);
			minValue = calculateMinValue;
		}
		else
		{
			direction = 2;
			calculateMinValue = axisRenderContext.method_0(axisRenderContext.MinValue);
			calculateMaxValue = axisRenderContext.method_0(axisRenderContext.MaxValue);
			minValue = axisRenderContext.method_0(axisRenderContext.MinValue);
			maxValue = axisRenderContext.method_0(axisRenderContext.MaxValue);
		}
	}

	private static void smethod_57(int direction, double step, double calculateMinValue, double calculateMaxValue, ArrayList scales, Class783 axisRenderContext)
	{
		scales.Clear();
		switch (direction)
		{
		case 1:
		{
			double num = calculateMaxValue;
			while (num >= calculateMinValue || Struct41.smethod_11(calculateMinValue, num) < step)
			{
				if (!axisRenderContext.Axis.IsAutomaticMinValue && num < axisRenderContext.LogMinValue)
				{
					scales.Add(axisRenderContext.LogMinValue);
				}
				else
				{
					scales.Add(num);
				}
				num -= step;
			}
			return;
		}
		case 2:
		{
			for (double num2 = calculateMinValue; num2 <= calculateMaxValue || num2 < calculateMaxValue + step; num2 += step)
			{
				if (!axisRenderContext.Axis.IsAutomaticMaxValue && num2 > axisRenderContext.LogMaxValue)
				{
					scales.Add(axisRenderContext.LogMaxValue);
				}
				else
				{
					scales.Add(num2);
				}
			}
			scales.Reverse();
			return;
		}
		}
		double num3;
		for (num3 = 0.0; num3 <= calculateMaxValue || Struct41.smethod_11(num3, calculateMaxValue) < step; num3 += step)
		{
			if (!axisRenderContext.Axis.IsAutomaticMaxValue && num3 > axisRenderContext.LogMaxValue)
			{
				scales.Add(axisRenderContext.LogMaxValue);
			}
			else
			{
				scales.Add(num3);
			}
		}
		scales.Reverse();
		num3 = 0.0 - step;
		while (num3 >= calculateMinValue || Struct41.smethod_11(calculateMinValue, num3) < step)
		{
			if (!axisRenderContext.Axis.IsAutomaticMinValue && num3 < axisRenderContext.LogMinValue)
			{
				scales.Add(axisRenderContext.LogMinValue);
			}
			else
			{
				scales.Add(num3);
			}
			num3 -= step;
		}
	}

	private static int smethod_58(Interface32 g, bool isDisplayAxisSameAsBar, Class759 firstSeries, Rectangle rect, Class783 axisRenderContext)
	{
		if (axisRenderContext.Axis.TickLabelPosition == TickLabelPositionType.None)
		{
			return 0;
		}
		Class748 @class = firstSeries.PointsInternal.method_0(0);
		string format = @class.YFormat;
		bool yValueIsCulture = @class.YValueIsCulture;
		int num = 0;
		for (int i = 0; i < axisRenderContext.arrayList_0.Count; i++)
		{
			double num2 = axisRenderContext.method_1((double)axisRenderContext.arrayList_0[i]);
			if (firstSeries.IsPercentSeries)
			{
				num2 /= 100.0;
				format = "0%";
			}
			string text = (axisRenderContext.IsLinkedSource ? Struct28.smethod_5(num2, format, yValueIsCulture) : Struct21.smethod_34(num2, axisRenderContext));
			Size size = Struct39.smethod_11(layoutArea: new Size(rect.Width, rect.Height), g: g, text: text, rotation: axisRenderContext.TickLableRotation, font: axisRenderContext.TickLabelTextFont, horizontalAlignment: Enum157.const_1, verticalAlignment: Enum157.const_1);
			num = ((!isDisplayAxisSameAsBar) ? ((i == 0 || i == axisRenderContext.arrayList_0.Count - 1) ? (num + size.Height / 2) : (num + size.Height)) : ((i == 0 || i == axisRenderContext.arrayList_0.Count - 1) ? (num + size.Width / 2) : (num + size.Width)));
			num = ((i == 0 || i == axisRenderContext.arrayList_0.Count - 1) ? (num - 1) : (num - 2));
		}
		return (int)((double)num + 0.5);
	}

	private static double smethod_59(double val)
	{
		bool flag = true;
		if (val < 0.0)
		{
			flag = false;
		}
		val = Math.Abs(val);
		if (flag)
		{
			double num = Struct41.smethod_4(val);
			if (num != val)
			{
				num += 1.0;
			}
			return num;
		}
		double num2 = Struct41.smethod_4(val);
		return 0.0 - num2;
	}

	private static double smethod_60(double val)
	{
		bool flag = true;
		if (val < 0.0)
		{
			flag = false;
		}
		val = Math.Abs(val);
		if (!flag)
		{
			double num = Struct41.smethod_4(val);
			if (num != val)
			{
				num += 1.0;
			}
			return 0.0 - num;
		}
		return Struct41.smethod_4(val);
	}

	private static bool smethod_61(Class740 c)
	{
		int num = 0;
		while (true)
		{
			if (num < c.NSeries.Count)
			{
				Interface21 @interface = c.NSeries[num];
				if (@interface.Type == ChartType.Radar || @interface.Type == ChartType.FilledRadar || @interface.Type == ChartType.RadarWithMarkers)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < c.NSeries.Count)
				{
					Interface21 interface2 = c.NSeries[num2];
					if (interface2.PlotOnSecondAxis)
					{
						break;
					}
					num2++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private static void smethod_62(Class784 renderContext)
	{
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class783 x2AxisRenderContext = renderContext.X2AxisRenderContext;
		if (x2AxisRenderContext.Axis == null || !x2AxisRenderContext.Axis.IsVisible)
		{
			x2AxisRenderContext.IsAutoMajorUnit = x1AxisRenderContext.IsAutoMajorUnit;
			if (!x1AxisRenderContext.IsAutoMajorUnit)
			{
				x2AxisRenderContext.MajorUnit = x1AxisRenderContext.MajorUnit;
			}
			x2AxisRenderContext.IsAutoMinorUnit = x1AxisRenderContext.IsAutoMinorUnit;
			if (!x1AxisRenderContext.IsAutoMinorUnit)
			{
				x2AxisRenderContext.MinorUnit = x1AxisRenderContext.MinorUnit;
			}
		}
	}

	private static void smethod_63(Class740 c)
	{
		for (int i = 0; i < c.NSeriesInternal.Category2LabelsInternal.Count; i++)
		{
			Interface8 @interface = c.NSeriesInternal.Category2LabelsInternal[i];
			Interface8 interface2 = new Class743(null, @interface.LabelValue);
			interface2.IsCulture = @interface.IsCulture;
			interface2.IsDate = @interface.IsDate;
			interface2.IsNull = @interface.IsNull;
			interface2.SourceFormat = @interface.SourceFormat;
			c.NSeriesInternal.OriginalCategory2Labels.Add(interface2);
		}
		c.NSeriesInternal.Category2LabelsInternal.Clear();
		for (int j = 0; j < c.NSeriesInternal.CategoryLabelsInternal.Count; j++)
		{
			Interface8 interface3 = c.NSeriesInternal.CategoryLabelsInternal[j];
			Interface8 interface4 = new Class743(null, interface3.LabelValue);
			interface4.IsCulture = interface3.IsCulture;
			interface4.IsDate = interface3.IsDate;
			interface4.IsNull = interface3.IsNull;
			interface4.SourceFormat = interface3.SourceFormat;
			c.NSeriesInternal.Category2LabelsInternal.Add(interface4);
		}
	}

	internal static List<Interface8>[] smethod_64(Interface7 categoryLabels)
	{
		List<Interface8>[] array = null;
		int level = GetLevel(categoryLabels);
		if (level > 1)
		{
			array = new List<Interface8>[level - 1];
			for (int i = 0; i < level - 1; i++)
			{
				array[i] = new List<Interface8>();
				smethod_66(categoryLabels, i, 0, array[i]);
			}
		}
		return array;
	}

	internal static List<Interface8> smethod_65(Interface7 categoryLabels)
	{
		List<Interface8> list = null;
		list = new List<Interface8>();
		int level = GetLevel(categoryLabels);
		smethod_66(categoryLabels, level - 1, 0, list);
		return list;
	}

	private static int GetLevel(Interface7 categoryLabels)
	{
		if (categoryLabels.Count == 0)
		{
			return 0;
		}
		Interface8 @interface = categoryLabels[0];
		int num = 1;
		while (@interface.Children.Count > 0)
		{
			num++;
			@interface = @interface.Children[0];
		}
		return num;
	}

	private static void smethod_66(Interface7 categoryLabels, int targetLevel, int seekLevel, List<Interface8> list)
	{
		if (targetLevel == seekLevel)
		{
			for (int i = 0; i < categoryLabels.Count; i++)
			{
				Interface8 item = categoryLabels[i];
				list.Add(item);
			}
		}
		else
		{
			for (int j = 0; j < categoryLabels.Count; j++)
			{
				Interface8 @interface = categoryLabels[j];
				smethod_66(@interface.Children, targetLevel, seekLevel + 1, list);
			}
		}
	}
}
