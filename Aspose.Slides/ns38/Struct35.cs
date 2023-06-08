using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns2;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct35
{
	internal static void smethod_0(Class740 chart, ref Rectangle rect, Class759 aSeries)
	{
		if (rect.Width > 0 && rect.Height > 0 && (chart.Type == ChartType.Pie3D || chart.Type == ChartType.ExplodedPie3D) && chart.PlotAreaInternal.IsSizeAuto)
		{
			rect.X += 4;
			rect.Y += 4;
			rect.Width -= 8;
			rect.Height -= 8;
			if (aSeries.IsDataLabelsShown && (aSeries.DataLabelsInternal.LabelPosition == LegendDataLabelPosition.OutsideEnd || aSeries.DataLabelsInternal.LabelPosition == LegendDataLabelPosition.BestFit))
			{
				int num = Struct41.smethod_3((float)chart.Width / 100f * 6f);
				int num2 = Struct41.smethod_3((float)chart.Height / 100f * 6f);
				rect.X += num;
				rect.Y += num2;
				rect.Width -= 2 * num;
				rect.Height -= 2 * num2;
			}
		}
	}

	private static void smethod_1(ref Rectangle rect, Class740 chart)
	{
		int num = Struct41.smethod_3((float)rect.Width / 400f * 3f);
		int num2 = Struct41.smethod_3((float)rect.Height / 400f * 3f);
		rect.X += num;
		rect.Y += num2;
		rect.Width -= 2 * num;
		rect.Height -= 2 * num2;
		double num3 = 1.0 / 7.0 / Math.Cos(Math.PI / 18.0);
		double num4 = (double)chart.Elevation * Math.PI / 180.0;
		double num5 = (double)rect.Width * (Math.Sin(num4) + num3 * (double)chart.HeightPercent / 100.0 * Math.Cos(num4));
		double num6 = (double)rect.Height / (Math.Sin(num4) + num3 * (double)chart.HeightPercent / 100.0 * Math.Cos(num4));
		if (num5 <= (double)rect.Height)
		{
			rect.Y = Struct41.smethod_5((double)((float)rect.Y + (float)rect.Height / 2f) - num5 / 2.0);
			rect.Height = Struct41.smethod_5(num5);
		}
		else
		{
			rect.X = Struct41.smethod_5((double)((float)rect.X + (float)rect.Width / 2f) - num6 / 2.0);
			rect.Width = Struct41.smethod_5(num6);
		}
		double num7 = (double)rect.Width * num3 * (double)chart.HeightPercent / 100.0 * Math.Cos(num4);
		double num8 = num7 / (double)rect.Height;
		chart.SliceRelativeHeight = (float)num8;
	}

	internal static void smethod_2(Interface32 g, Class740 chart, Class784 renderContext)
	{
		Class759 @class = chart.NSeriesInternal.method_9()[0];
		Class747 pointsInternal = @class.PointsInternal;
		Color[] array = new Color[pointsInternal.Count];
		Color[] array2 = chart.Themes.ThemeColors.method_5(chart.StyleIndex, pointsInternal.Count);
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			Class748 class2 = pointsInternal.method_0(i);
			if (@class.IsColorVaried)
			{
				class2.AreaInternal.method_1(array2[i]);
			}
			else
			{
				class2.AreaInternal.method_1(@class.AreaInternal.ForegroundColor);
			}
			ref Color reference = ref array[i];
			reference = class2.AreaInternal.ForegroundColor;
		}
		double[] array3 = new double[pointsInternal.Count];
		for (int j = 0; j < pointsInternal.Count; j++)
		{
			Class748 class3 = pointsInternal.method_0(j);
			array3[j] = class3.YValue;
		}
		string[] array4 = new string[pointsInternal.Count];
		double num = 0.0;
		for (int k = 0; k < pointsInternal.Count; k++)
		{
			num += Math.Abs(pointsInternal[k].YValue);
		}
		if (num == 0.0)
		{
			return;
		}
		for (int l = 0; l < pointsInternal.Count; l++)
		{
			Class748 class4 = pointsInternal.method_0(l);
			double yValue = class4.YValue;
			double percent = 0.0;
			if (num != 0.0)
			{
				percent = yValue / num;
			}
			array4[l] = smethod_3(@class, l, percent, renderContext);
		}
		Rectangle rect = chart.PlotAreaInternal.rectangle_1;
		smethod_1(ref rect, chart);
		Class767 class5 = new Class767(rect.X, rect.Y, rect.Width, rect.Height, array3, array, chart.SliceRelativeHeight, array4, pointsInternal);
		class5.method_0(@class);
		class5.method_1(g);
		class5.vmethod_0(g, renderContext);
	}

	private static string smethod_3(Class759 aSeries, int chartPointIndex, double percent, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		Class748 @class = aSeries.PointsInternal.method_0(chartPointIndex);
		List<Interface8> categoryLabelsInternal = chart.NSeriesInternal.CategoryLabelsInternal;
		Class783 x1AxisRenderContext = renderContext.X1AxisRenderContext;
		Class750 dataLabelsInternal = @class.DataLabelsInternal;
		bool isCulture = dataLabelsInternal.IsCulture;
		bool linkedSource = dataLabelsInternal.LinkedSource;
		string format = (dataLabelsInternal.IsPercentageShown ? "" : dataLabelsInternal.Format);
		string format2 = ((dataLabelsInternal.Format == "") ? "0%" : dataLabelsInternal.Format);
		string name = aSeries.Name;
		string text = ((chartPointIndex < x1AxisRenderContext.arrayList_0.Count) ? Struct28.smethod_5(x1AxisRenderContext.arrayList_0[chartPointIndex], format, isCulture) : "");
		if (linkedSource)
		{
			string format3 = ((chartPointIndex < 0 || chartPointIndex >= categoryLabelsInternal.Count) ? "" : ((Class743)categoryLabelsInternal[chartPointIndex]).SourceFormat);
			bool isCulture2 = chartPointIndex >= 0 && chartPointIndex < categoryLabelsInternal.Count && ((Class743)categoryLabelsInternal[chartPointIndex]).IsCulture;
			text = ((chartPointIndex < 0 || chartPointIndex >= x1AxisRenderContext.arrayList_0.Count) ? "" : Struct28.smethod_5(x1AxisRenderContext.arrayList_0[chartPointIndex], format3, isCulture2));
		}
		string text2 = Struct28.smethod_5(@class.YValue, format, isCulture);
		if (linkedSource)
		{
			text2 = Struct28.smethod_5(@class.YValue, @class.YFormat, @class.YValueIsCulture);
		}
		string text3 = Struct28.smethod_5(percent, format2, isCulture);
		string text4 = Struct28.smethod_3(dataLabelsInternal.Separator);
		string text5 = "";
		if (dataLabelsInternal.IsSeriesNameShown)
		{
			text5 += name;
		}
		if (dataLabelsInternal.IsCategoryNameShown)
		{
			if (text5 != "")
			{
				text5 += text4;
			}
			text5 += text;
		}
		if (dataLabelsInternal.IsValueShown)
		{
			if (text5 != "")
			{
				text5 += text4;
			}
			text5 += text2;
		}
		if (dataLabelsInternal.IsPercentageShown)
		{
			if (text5 != "")
			{
				text5 += text4;
			}
			text5 += text3;
		}
		return text5;
	}

	internal static Rectangle smethod_4(Interface32 graphics, Class759 aSeries, Rectangle plotArea, double[] values, Color[] colors, string[] texts, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		Class747 pointsInternal = aSeries.PointsInternal;
		Class767 @class = new Class767(plotArea.X, plotArea.Y, plotArea.Width, plotArea.Height, values, colors, chart.SliceRelativeHeight, texts, pointsInternal);
		@class.method_0(aSeries);
		Rectangle rectangle = default(Rectangle);
		rectangle = plotArea;
		smethod_5(graphics, @class, renderContext);
		if (aSeries.Chart.PlotAreaInternal.IsXAuto)
		{
			SizeF sizeF = smethod_6(plotArea, aSeries);
			if (sizeF.Width > (float)plotArea.Width * 0.3f)
			{
				sizeF.Width = (float)plotArea.Width * 0.3f;
			}
			if (sizeF.Height > (float)plotArea.Height * 0.3f)
			{
				sizeF.Height = (float)plotArea.Height * 0.3f;
			}
			rectangle.X = plotArea.X + (int)sizeF.Width;
			rectangle.Width = plotArea.Width - 2 * (int)sizeF.Width;
			rectangle.Y = plotArea.Y + (int)sizeF.Height;
			rectangle.Height = plotArea.Height - 2 * (int)sizeF.Height;
			smethod_1(ref rectangle, chart);
		}
		return rectangle;
	}

	private static ArrayList smethod_5(Interface32 graphics, Class767 pieChart, Class784 renderContext)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		Class740 chart = pieChart.ChartPoints.Chart;
		double num = 0.0;
		double[] values = pieChart.Values;
		foreach (double num2 in values)
		{
			num += num2;
		}
		ArrayList arrayList = new ArrayList();
		Class768[] slices = pieChart.Slices;
		foreach (Class768 @class in slices)
		{
			if (@class == null || @class.Text.Length < 1)
			{
				continue;
			}
			Class748 chartPoint = @class.ChartPoint;
			Class759 aSeries = chartPoint.ChartPoints.ASeries;
			Class750 dataLabelsInternal = chartPoint.DataLabelsInternal;
			double percent = ((num != 0.0) ? (Math.Abs(chartPoint.YValue) / num) : 0.01);
			float scaleWidth = (chart.PlotAreaInternal.IsXAuto ? ((!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f)) : ((!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f)));
			float scaleHeight = chart.Height;
			SizeF size = Struct37.smethod_42(graphics, chart.NSeriesInternal, aSeries.Index, chartPoint.Index, percent, scaleWidth, scaleHeight, 0.0, renderContext);
			RectangleF empty = RectangleF.Empty;
			PointF location;
			float dlAngle;
			switch (dataLabelsInternal.LabelPosition)
			{
			case LegendDataLabelPosition.Center:
				location = @class.vmethod_1(0.25f, out dlAngle);
				location.X -= size.Width / 2f;
				location.Y -= size.Height / 2f;
				break;
			default:
				location = @class.vmethod_1(0.5f, out dlAngle);
				if ((double)dlAngle > 67.5 && (double)dlAngle < 112.5)
				{
					location.X = (float)((double)location.X - ((double)dlAngle - 67.5) * (double)size.Width / 45.0);
				}
				else if ((double)dlAngle >= 112.5 && (double)dlAngle <= 247.5)
				{
					location.X -= size.Width;
				}
				else if ((double)dlAngle > 247.5 && (double)dlAngle < 292.5)
				{
					location.X = (float)((double)(location.X - size.Width) + ((double)dlAngle - 247.5) * (double)size.Width / 45.0);
				}
				if (dlAngle >= 0f && dlAngle <= 180f)
				{
					location.Y += @class.SliceHeight;
				}
				else if (dlAngle < 225f && dlAngle > 180f)
				{
					location.Y -= (dlAngle - 135f) * size.Height / 90f;
				}
				else if (dlAngle >= 225f && dlAngle <= 315f)
				{
					location.Y -= size.Height;
				}
				else if (dlAngle > 315f && dlAngle <= 360f)
				{
					location.Y = location.Y - size.Height + (dlAngle - 315f) * size.Height / 90f;
				}
				break;
			case LegendDataLabelPosition.InsideEnd:
			{
				location = @class.vmethod_1(0.5f, out dlAngle);
				double num3 = (double)dlAngle * Math.PI / 180.0;
				if (dlAngle > 270f || dlAngle < 90f)
				{
					location.X -= (float)((double)size.Width * Math.Cos(num3));
				}
				if (dlAngle > 0f && dlAngle < 180f)
				{
					location.Y -= (float)((double)size.Height * Math.Sin(num3));
				}
				break;
			}
			}
			empty = new RectangleF(location, size);
			dataLabelsInternal.rectangleF_0 = new RectangleF(empty.X, empty.Y, empty.Width, empty.Height);
			arrayList.Add(empty);
		}
		return arrayList;
	}

	private static SizeF smethod_6(Rectangle plotArea, Class759 aSeries)
	{
		return smethod_7(Struct41.smethod_23(plotArea), aSeries);
	}

	private static SizeF smethod_7(RectangleF plotArea, Class759 aSeries)
	{
		SizeF offset = new SizeF(0f, 0f);
		for (int i = 0; i < aSeries.PointsInternal.Count; i++)
		{
			Class748 @class = aSeries.PointsInternal.method_0(i);
			Class750 dataLabelsInternal = @class.DataLabelsInternal;
			if (dataLabelsInternal.LabelPosition == LegendDataLabelPosition.BestFit || dataLabelsInternal.LabelPosition == LegendDataLabelPosition.OutsideEnd || !dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto)
			{
				smethod_8(plotArea, dataLabelsInternal.rectangleF_0, ref offset);
			}
		}
		return offset;
	}

	private static void smethod_8(RectangleF plotArea, RectangleF rectLabel, ref SizeF offset)
	{
		if (rectLabel.IsEmpty)
		{
			return;
		}
		if (rectLabel.Left < plotArea.Left)
		{
			float num = plotArea.Left - rectLabel.Left;
			if (num > offset.Width)
			{
				offset.Width = num;
			}
		}
		if (rectLabel.Right > plotArea.Right)
		{
			float num2 = rectLabel.Right - plotArea.Right;
			if (num2 > offset.Width)
			{
				offset.Width = num2;
			}
		}
		if (rectLabel.Top < plotArea.Top)
		{
			float num3 = plotArea.Top - rectLabel.Top;
			if (num3 > offset.Height)
			{
				offset.Height = num3;
			}
		}
		if (rectLabel.Bottom > plotArea.Bottom)
		{
			float num4 = rectLabel.Bottom - plotArea.Bottom;
			if (num4 > offset.Height)
			{
				offset.Height = num4;
			}
		}
	}
}
