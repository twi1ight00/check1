using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Slides.Charts;
using ns2;
using ns35;
using ns36;
using ns37;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct31
{
	internal static int int_0 = 4;

	internal static float float_0 = 0.4f;

	private static SizeF smethod_0(Interface32 g, Class784 renderContext)
	{
		Class757 nSeriesInternal = renderContext.Chart2007.NSeriesInternal;
		SizeF result = new SizeF(0f, 0f);
		for (int i = 0; i < nSeriesInternal.Count; i++)
		{
			Class759 @class = nSeriesInternal.method_0(i);
			SizeF sizeF = g.imethod_105(@class.Name, renderContext.LegendRenderContext.TextFont);
			if (result.Width < sizeF.Width)
			{
				result.Width = sizeF.Width;
			}
			if (result.Height < sizeF.Height)
			{
				result.Height = sizeF.Height;
			}
		}
		return result;
	}

	internal static SizeF smethod_1(Interface32 g, Class784 renderContext)
	{
		Class757 nSeriesInternal = renderContext.Chart2007.NSeriesInternal;
		SizeF result = new SizeF(0f, 0f);
		for (int i = 0; i < nSeriesInternal.Count; i++)
		{
			Class759 @class = nSeriesInternal.method_0(i);
			SizeF sizeF = g.imethod_105(@class.Name, renderContext.LegendRenderContext.TextFont);
			result.Width += sizeF.Width;
			if (result.Height < sizeF.Height)
			{
				result.Height = sizeF.Height;
			}
		}
		return result;
	}

	private static bool smethod_2(Class757 nSeries)
	{
		bool result = false;
		for (int i = 0; i < nSeries.Count; i++)
		{
			Class759 @class = nSeries.method_0(i);
			if (@class.LineInternal.IsVisible && @class.IsDrawMarkerInPlot)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	internal static SizeF smethod_3(Interface32 g, Class784 renderContext)
	{
		SizeF sizeF = smethod_0(g, renderContext);
		float width = sizeF.Height * Class745.float_0;
		float height = sizeF.Height;
		if (smethod_2(renderContext.Chart2007.NSeriesInternal))
		{
			width = Class745.int_0;
		}
		return new SizeF(width, height);
	}

	internal static void smethod_4(Legend legend, Rectangle plotRect, Class784 renderContext)
	{
		Size size = renderContext.LegendRenderContext.DrawingRect.Size;
		int height = plotRect.Height;
		int width = plotRect.Width;
		if (float.IsNaN(legend.X) || float.IsNaN(legend.Y))
		{
			int x = renderContext.LegendRenderContext.DrawingRect.X;
			int y = renderContext.LegendRenderContext.DrawingRect.Y;
			int width2 = renderContext.LegendRenderContext.DrawingRect.Width;
			int height2 = renderContext.LegendRenderContext.DrawingRect.Height;
			switch (legend.Position)
			{
			case LegendPositionType.Bottom:
				x = plotRect.X + (width - size.Width) / 2;
				break;
			case LegendPositionType.Left:
				y = plotRect.Y + (height - size.Height) / 2;
				break;
			case LegendPositionType.Right:
				y = plotRect.Y + (height - size.Height) / 2;
				break;
			case LegendPositionType.Top:
				x = plotRect.X + (width - size.Width) / 2;
				break;
			}
			renderContext.LegendRenderContext.DrawingRect = new Rectangle(x, y, width2, height2);
		}
	}

	internal static void smethod_5(Interface32 g, RectangleF rect, Class759 aSeries)
	{
		_ = aSeries.Type;
		Class755 @class = (Class755)aSeries.LineInternal.Clone();
		int num = @class.Width;
		if (num > 2)
		{
			num = 2;
		}
		@class.LineStyleInternal.Width = num;
		if (aSeries.IsBubbleSeries)
		{
			float width = rect.Width;
			RectangleF rect2 = new RectangleF(rect.X, rect.Y + (rect.Height - width) / 2f, width, width);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(rect2);
			aSeries.AreaInternal.method_6(graphicsPath);
			@class.method_8(graphicsPath);
			return;
		}
		if (!aSeries.IsDrawMarkerInPlot)
		{
			float width2 = rect.Width;
			RectangleF rect3 = new RectangleF(rect.X, rect.Y + (rect.Height - width2) / 2f, width2, width2);
			aSeries.AreaInternal.method_5(rect3);
			@class.method_7(rect3);
			return;
		}
		if (aSeries.LineInternal.IsVisible)
		{
			@class.method_5(new PointF(rect.X, rect.Y + rect.Height / 2f), new PointF(rect.X + rect.Width, rect.Y + rect.Height / 2f));
		}
		if (aSeries.MarkerInternal.IsVisible)
		{
			float x = rect.X + rect.Width / 2f;
			float y = rect.Y + rect.Height / 2f;
			float num2 = rect.Height * Class745.float_0;
			float num3 = aSeries.MarkerInternal.MarkerSize;
			if (num3 > num2)
			{
				num3 = num2;
			}
			aSeries.MarkerInternal.method_5(x, y, num3);
		}
	}

	internal static MarkerStyleType smethod_6(Class759 aSeries, int index)
	{
		if (index == -1)
		{
			return MarkerStyleType.Square;
		}
		if (aSeries.Type == ChartType.Bubble)
		{
			return MarkerStyleType.Circle;
		}
		index %= 9;
		index += 2;
		return index switch
		{
			2 => MarkerStyleType.Diamond, 
			3 => MarkerStyleType.Square, 
			4 => MarkerStyleType.Triangle, 
			5 => MarkerStyleType.X, 
			6 => MarkerStyleType.Star, 
			7 => MarkerStyleType.Circle, 
			8 => MarkerStyleType.X, 
			9 => MarkerStyleType.Dot, 
			10 => MarkerStyleType.Dash, 
			_ => MarkerStyleType.None, 
		};
	}

	internal static bool smethod_7(Chart chart)
	{
		if (chart.ChartData.Series.Count != 1)
		{
			return false;
		}
		ChartSeries chartSeries = (ChartSeries)chart.ChartData.Series[0];
		ChartType[] array = new ChartType[50]
		{
			ChartType.ClusteredColumn,
			ChartType.PercentsStackedColumn,
			ChartType.Column3D,
			ChartType.PercentsStackedColumn3D,
			ChartType.ClusteredColumn3D,
			ChartType.StackedColumn3D,
			ChartType.StackedColumn,
			ChartType.ClusteredBar,
			ChartType.PercentsStackedBar,
			ChartType.PercentsStackedBar3D,
			ChartType.ClusteredBar3D,
			ChartType.StackedBar,
			ChartType.Line,
			ChartType.PercentsStackedLine,
			ChartType.PercentsStackedLineWithMarkers,
			ChartType.Line3D,
			ChartType.StackedLine,
			ChartType.StackedLineWithMarkers,
			ChartType.LineWithMarkers,
			ChartType.ScatterWithMarkers,
			ChartType.ScatterWithSmoothLinesAndMarkers,
			ChartType.ScatterWithSmoothLines,
			ChartType.ScatterWithStraightLinesAndMarkers,
			ChartType.ScatterWithStraightLines,
			ChartType.Radar,
			ChartType.FilledRadar,
			ChartType.RadarWithMarkers,
			ChartType.Bubble,
			ChartType.BubbleWith3D,
			ChartType.ClusteredCylinder,
			ChartType.PercentsStackedCylinder,
			ChartType.ClusteredHorizontalCylinder,
			ChartType.PercentsStackedHorizontalCylinder,
			ChartType.StackedHorizontalCylinder,
			ChartType.Cylinder3D,
			ChartType.StackedCylinder,
			ChartType.ClusteredCone,
			ChartType.PercentsStackedCone,
			ChartType.StackedCone,
			ChartType.ClusteredHorizontalCone,
			ChartType.PercentsStackedHorizontalCone,
			ChartType.StackedHorizontalCone,
			ChartType.Cone3D,
			ChartType.ClusteredPyramid,
			ChartType.PercentsStackedPyramid,
			ChartType.ClusteredHorizontalPyramid,
			ChartType.PercentsStackedHorizontalPyramid,
			ChartType.StackedHorizontalPyramid,
			ChartType.Pyramid3D,
			ChartType.StackedPyramid
		};
		int i;
		for (i = 0; i < array.Length && chartSeries.Type != array[i]; i++)
		{
		}
		if (i == array.Length)
		{
			return false;
		}
		IChartDataPointCollection dataPoints = chartSeries.DataPoints;
		_ = chartSeries.Type;
		if (chartSeries.IsColorVaried)
		{
			return true;
		}
		if (dataPoints.Count > 0 && !smethod_8(dataPoints))
		{
			return true;
		}
		return false;
	}

	private static bool smethod_8(IChartDataPointCollection points)
	{
		int num = 1;
		while (true)
		{
			if (num < points.Count)
			{
				bool flag = points[0].Format.Equals(points[num].Format);
				bool flag2 = points[0].Marker.Format.Equals(points[num].Marker.Format);
				bool flag3 = points[0].Marker.Size.Equals(points[num].Marker.Size);
				bool flag4 = points[0].Marker.Symbol.Equals(points[num].Marker.Symbol);
				if (!flag || !flag2 || !flag3 || !flag4)
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

	internal static void smethod_9(Interface32 g, Class759 aSeries, Class784 renderContext, Legend legend)
	{
		Class740 chart = renderContext.Chart2007;
		Rectangle drawingRect = renderContext.LegendRenderContext.DrawingRect;
		if (!float.IsNaN(legend.X) && !float.IsNaN(legend.Y))
		{
			drawingRect.X = (int)(legend.X * (float)chart.Width);
			drawingRect.Y = (int)(legend.Y * (float)chart.Height);
			if (drawingRect.X < 0)
			{
				drawingRect.X = 0;
			}
			if (drawingRect.Y < 0)
			{
				drawingRect.Y = 0;
			}
		}
		Class747 pointsInternal = aSeries.PointsInternal;
		Struct30.smethod_0(renderContext, drawingRect, renderContext.Chart.Legend.Format);
		SizeF sizeF = smethod_3(g, renderContext);
		SizeF sizeF2 = smethod_11(g, aSeries, renderContext);
		int num = (int)(sizeF.Width + sizeF2.Width);
		int width = drawingRect.Width;
		int height = drawingRect.Height;
		int num2 = (width - int_0) / num;
		if (num2 <= 0)
		{
			num2 = 1;
		}
		int num3 = Struct41.smethod_3((float)pointsInternal.Count / (float)num2);
		float num4 = (width - num * num2) / num2;
		if (num4 < 0f)
		{
			num4 = 0f;
		}
		float num5 = (int)(((float)(height - 2 * int_0) - sizeF2.Height * (float)num3) / (float)num3);
		if (num5 < 0f && 0f - num5 > sizeF.Height * (1f - float_0))
		{
			num5 = (0f - sizeF.Height) * (1f - float_0);
		}
		SizeF sizeF3 = smethod_14(g, aSeries, renderContext);
		int num6 = (int)(sizeF.Width * (float)pointsInternal.Count + sizeF3.Width);
		if (num6 <= width - int_0)
		{
			num2 = 1;
			num3 = 1;
			num4 = (width - int_0 - num6) / pointsInternal.Count;
			num5 = (int)(((float)height - sizeF2.Height * 1f) / 1f);
		}
		float num7 = drawingRect.X + int_0;
		float num8 = drawingRect.Y;
		num7 += num4 / 2f;
		num8 += num5 / 2f;
		List<Interface8> list = ((aSeries.AxisGroup != Enum141.const_0) ? chart.NSeriesInternal.Category2LabelsInternal : chart.NSeriesInternal.CategoryLabelsInternal);
		for (int i = 1; i <= pointsInternal.Count; i++)
		{
			if (!(num8 + sizeF.Height * (1f - float_0) <= (float)(drawingRect.Y + drawingRect.Height)))
			{
				break;
			}
			RectangleF rect = new RectangleF(num7, num8, sizeF.Width, sizeF.Height);
			smethod_10(g, rect, aSeries, i - 1, renderContext);
			string text = i.ToString();
			if (i - 1 < list.Count)
			{
				text = smethod_12((Class743)list[i - 1], chart.IsDate1904);
			}
			else if (list.Count != 0)
			{
				text = " ";
			}
			float width2 = (width - int_0) / num2;
			float num9 = sizeF2.Height;
			if (num8 + sizeF.Height > (float)(drawingRect.Y + drawingRect.Height))
			{
				num9 -= num8 + sizeF.Height - (float)drawingRect.Y + (float)drawingRect.Height;
			}
			RectangleF layoutRectangle = new RectangleF(num7 + sizeF.Width, num8, width2, num9);
			SizeF sizeF4 = g.imethod_105(text, renderContext.LegendRenderContext.TextFont);
			g.imethod_58(text, renderContext.LegendRenderContext.TextFont, new SolidBrush(renderContext.LegendRenderContext.FontColor), layoutRectangle);
			if (num6 <= width - int_0)
			{
				num7 += sizeF.Width + sizeF4.Width;
				num7 += num4;
				continue;
			}
			num7 += (float)num;
			num7 += num4;
			if (i % num2 == 0)
			{
				num7 = (float)(drawingRect.X + int_0) + num4 / 2f;
				num8 += sizeF2.Height;
				num8 += num5;
			}
		}
	}

	internal static void smethod_10(Interface32 g, RectangleF rect, Class759 aSeries, int pointIndex, Class784 renderContext)
	{
		_ = aSeries.Type;
		Class748 @class = aSeries.PointsInternal.method_0(pointIndex);
		if (@class == null)
		{
			@class = aSeries.VirtualPointInternal;
		}
		if (aSeries.IsBubbleSeries)
		{
			float num = renderContext.LegendRenderContext.KeyHeight;
			RectangleF rect2 = new RectangleF(rect.X, rect.Y + (rect.Height - num) / 2f, num, num);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(rect2);
			@class.AreaInternal.method_6(graphicsPath);
			@class.BorderInternal.method_8(graphicsPath);
			return;
		}
		if (!aSeries.IsDrawMarkerInPlot)
		{
			float width = rect.Width;
			float num2 = rect.Height / 2f;
			RectangleF rect3 = new RectangleF(rect.X, rect.Y + rect.Height / 2f - num2 / 2f, width, num2);
			@class.AreaInternal.method_5(rect3);
			@class.BorderInternal.method_7(rect3);
			return;
		}
		if (aSeries.LineInternal.IsVisible)
		{
			@class.BorderInternal.method_3(rect.X, rect.Y + rect.Height / 2f, rect.X + rect.Width, rect.Y + rect.Height / 2f);
		}
		if (!@class.MarkerInternal.IsVisible)
		{
			return;
		}
		float x = rect.X + rect.Width / 2f;
		float y = rect.Y + rect.Height / 2f;
		float markerSize;
		if (aSeries.MarkerInternal.MarkerSize == 0)
		{
			markerSize = rect.Height * float_0;
		}
		else if ((float)aSeries.MarkerInternal.MarkerSize <= rect.Height * float_0)
		{
			markerSize = aSeries.MarkerInternal.MarkerSize;
		}
		else
		{
			float num3 = aSeries.MarkerInternal.MarkerSize / aSeries.Chart.ChartAreaInternal.Height;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			markerSize = rect.Height * float_0 * (1f + num3);
		}
		@class.MarkerInternal.method_5(x, y, markerSize);
	}

	internal static SizeF smethod_11(Interface32 g, Class759 aSeries, Class784 renderContext)
	{
		Class747 pointsInternal = aSeries.PointsInternal;
		SizeF result = new SizeF(0f, 0f);
		Class740 chart = renderContext.Chart2007;
		List<Interface8> list = ((aSeries.AxisGroup != Enum141.const_0) ? chart.NSeriesInternal.Category2LabelsInternal : chart.NSeriesInternal.CategoryLabelsInternal);
		if (list.Count > 0)
		{
			for (int i = 0; i < pointsInternal.Count; i++)
			{
				SizeF sizeF;
				if (list.Count >= pointsInternal.Count)
				{
					Class743 categoryLabel = (Class743)list[i];
					string text = smethod_12(categoryLabel, chart.IsDate1904);
					sizeF = g.imethod_105(text, renderContext.LegendRenderContext.TextFont);
				}
				else
				{
					sizeF = g.imethod_105(" ", renderContext.LegendRenderContext.TextFont);
				}
				if (result.Width < sizeF.Width)
				{
					result.Width = sizeF.Width;
				}
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		else
		{
			for (int j = 1; j <= pointsInternal.Count; j++)
			{
				SizeF sizeF = g.imethod_105(j.ToString(), renderContext.LegendRenderContext.TextFont);
				if (result.Width < sizeF.Width)
				{
					result.Width = sizeF.Width;
				}
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		return result;
	}

	private static string smethod_12(Interface8 categoryLabel, bool date1904)
	{
		string text = smethod_13(categoryLabel, date1904);
		while (categoryLabel.Parent != null)
		{
			categoryLabel = categoryLabel.Parent;
			text = smethod_13(categoryLabel, date1904) + " " + text;
		}
		return text;
	}

	private static string smethod_13(Interface8 categoryLabel, bool date1904)
	{
		string sourceFormat = categoryLabel.SourceFormat;
		if (categoryLabel.IsDate)
		{
			double doubleValue = Convert.ToDouble(categoryLabel.LabelValue);
			DateTime dateTime = Struct41.smethod_29(doubleValue, date1904);
			return Struct43.smethod_0(dateTime, sourceFormat, isCulture: false);
		}
		return Struct43.smethod_0(categoryLabel.LabelValue, sourceFormat, isCulture: false);
	}

	internal static SizeF smethod_14(Interface32 g, Class759 aSeries, Class784 renderContext)
	{
		Class740 chart = renderContext.Chart2007;
		Class747 pointsInternal = aSeries.PointsInternal;
		SizeF result = new SizeF(0f, 0f);
		List<Interface8> list = ((aSeries.AxisGroup != Enum141.const_0) ? chart.NSeriesInternal.Category2LabelsInternal : chart.NSeriesInternal.CategoryLabelsInternal);
		if (list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				SizeF sizeF;
				if (list.Count >= pointsInternal.Count)
				{
					Class743 categoryLabel = (Class743)list[i];
					string text = smethod_12(categoryLabel, chart.IsDate1904);
					sizeF = g.imethod_105(text, renderContext.LegendRenderContext.TextFont);
				}
				else
				{
					sizeF = g.imethod_105(" ", renderContext.LegendRenderContext.TextFont);
				}
				result.Width += sizeF.Width;
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		else
		{
			for (int j = 1; j <= pointsInternal.Count; j++)
			{
				SizeF sizeF = g.imethod_105(j.ToString(), renderContext.LegendRenderContext.TextFont);
				result.Width += sizeF.Width;
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		return result;
	}

	internal static SizeF smethod_15(Interface32 g, Class759 aSeries, Class784 renderContext)
	{
		SizeF sizeF = smethod_11(g, aSeries, renderContext);
		float width = sizeF.Height * float_0;
		float height = sizeF.Height;
		return new SizeF(width, height);
	}

	internal static Size smethod_16(Interface32 g, Class759 aSeries, Legend legend, Class784 renderContext)
	{
		if (float.IsNaN(legend.Width) && float.IsNaN(legend.Height))
		{
			Class747 pointsInternal = aSeries.PointsInternal;
			int num;
			int num2;
			if (legend.Position != LegendPositionType.Top && legend.Position != 0)
			{
				SizeF sizeF = smethod_3(g, renderContext);
				SizeF sizeF2 = smethod_11(g, aSeries, renderContext);
				num = (int)((float)int_0 + sizeF.Width + sizeF2.Width) + 1;
				num2 = (int)(sizeF2.Height + (float)(2 * int_0) + (float)(pointsInternal.Count - 1) * sizeF2.Height);
				if (num > renderContext.Chart2007.Width)
				{
					num = renderContext.Chart2007.Width;
				}
				if (num2 > renderContext.Chart2007.ChartAreaInternal.Height - 2 * Struct24.int_0)
				{
					num2 = renderContext.Chart2007.ChartAreaInternal.Height - 2 * Struct24.int_0;
				}
			}
			else
			{
				SizeF sizeF3 = smethod_3(g, renderContext);
				SizeF sizeF4 = smethod_11(g, aSeries, renderContext);
				int num3 = (int)(sizeF3.Width + sizeF4.Width) + 1;
				int num4 = renderContext.Chart2007.ChartAreaInternal.Width - 2 * Struct24.int_0 - int_0;
				int num5 = num4 / num3;
				if (num5 == 0)
				{
					num5 = 1;
				}
				SizeF sizeF2 = smethod_14(g, aSeries, renderContext);
				int num6 = (int)(sizeF3.Width * (float)aSeries.PointsInternal.Count + sizeF2.Width) + 1;
				if (num6 <= num4)
				{
					num = int_0 + num6;
					num2 = (int)sizeF2.Height + 2 * int_0;
				}
				else
				{
					int num7 = Struct41.smethod_3((double)aSeries.PointsInternal.Count / (double)num5);
					int num8 = Struct41.smethod_3((double)aSeries.PointsInternal.Count / (double)num7);
					num = int_0 + num8 * num3;
					num2 = num7 * (int)sizeF2.Height + 2 * int_0;
				}
				if (num2 > renderContext.Chart2007.ChartAreaInternal.Height - 2 * Struct24.int_0)
				{
					num2 = renderContext.Chart2007.ChartAreaInternal.Height - 2 * Struct24.int_0;
				}
			}
			return new Size(num, num2);
		}
		Class740 chart = renderContext.Chart2007;
		return new Size((int)(legend.Width * (float)chart.Width), (int)(legend.Height * (float)chart.Height));
	}

	internal static Point smethod_17(Interface32 g, Class759 aSeries, ref Rectangle rect, Legend legend, Class784 renderContext)
	{
		Class740 chart = renderContext.Chart2007;
		float num = 0f;
		float num2 = 0f;
		Size size = smethod_16(g, aSeries, legend, renderContext);
		int num3 = Struct24.int_0;
		int int_ = Struct24.int_1;
		renderContext.LegendRenderContext.DrawingRect = new Rectangle(0, 0, size.Width, size.Height);
		switch (legend.Position)
		{
		case LegendPositionType.Bottom:
			num = (chart.Width - size.Width) / 2;
			num2 = chart.Position.Bottom - num3 - size.Height;
			if (!legend.Overlay)
			{
				rect.Height -= size.Height + int_;
			}
			break;
		case LegendPositionType.Left:
			num = chart.Position.X + num3;
			num2 = (chart.Height - size.Height) / 2;
			if (!legend.Overlay)
			{
				rect.X += size.Width + int_;
				rect.Width -= size.Width + int_;
			}
			break;
		case LegendPositionType.Right:
			num = chart.Position.Right - num3 - size.Width;
			num2 = (chart.Height - size.Height) / 2;
			if (!legend.Overlay)
			{
				rect.Width -= size.Width + int_;
			}
			break;
		case LegendPositionType.Top:
			num = (chart.Width - size.Width) / 2;
			num2 = chart.Position.Y + num3 + renderContext.ChartTitleRenderContext.rectangle_0.Height + int_;
			if (!legend.Overlay)
			{
				rect.Y += size.Height + int_;
				rect.Height -= size.Height + int_;
			}
			break;
		case LegendPositionType.TopRight:
			num = chart.Position.Right - num3 - size.Width;
			num2 = ((!renderContext.Chart.HasTitle) ? ((float)(chart.Position.Y + num3)) : ((float)(chart.Position.Y + num3 + renderContext.ChartTitleRenderContext.rectangle_0.Height + int_)));
			if (!legend.Overlay)
			{
				rect.Width -= size.Width + int_;
			}
			break;
		}
		renderContext.LegendRenderContext.DrawingRect = new Rectangle((int)num, (int)num2, size.Width, size.Height);
		return new Point(renderContext.LegendRenderContext.DrawingRect.X, renderContext.LegendRenderContext.DrawingRect.Y);
	}

	internal static Point smethod_18(Interface32 g, ref Rectangle rect, Legend legend, Class784 renderContext)
	{
		float num = 0f;
		float num2 = 0f;
		Size size = smethod_19(g, renderContext, legend);
		int height = renderContext.Chart2007.Height;
		int width = renderContext.Chart2007.Width;
		int num3 = Struct24.int_0;
		int int_ = Struct24.int_1;
		switch (legend.Position)
		{
		case LegendPositionType.Bottom:
			num = (width - size.Width) / 2;
			num2 = height - num3 - size.Height;
			if (!legend.Overlay)
			{
				rect.Height -= size.Height + int_;
			}
			break;
		case LegendPositionType.Left:
			num = num3;
			num2 = (height - size.Height) / 2;
			if (!legend.Overlay)
			{
				rect.X += size.Width + int_;
				rect.Width -= size.Width + int_;
			}
			break;
		case LegendPositionType.Right:
			num = width - num3 - size.Width;
			num2 = (height - size.Height) / 2;
			if (!legend.Overlay)
			{
				rect.Width -= size.Width + int_;
			}
			break;
		case LegendPositionType.Top:
			num = (width - size.Width) / 2;
			num2 = num3 + renderContext.ChartTitleRenderContext.rectangle_0.Height + int_;
			if (!legend.Overlay)
			{
				rect.Y += size.Height + int_;
				rect.Height -= size.Height + int_;
			}
			break;
		case LegendPositionType.TopRight:
			num = width - num3 - size.Width;
			num2 = ((!renderContext.Chart.HasTitle) ? ((float)num3) : ((float)(num3 + renderContext.ChartTitleRenderContext.rectangle_0.Height + int_)));
			if (!legend.Overlay)
			{
				rect.Width -= size.Width + int_;
				rect.Y += size.Height + int_;
			}
			break;
		}
		renderContext.LegendRenderContext.DrawingRect = new Rectangle((int)num, (int)num2, size.Width, size.Height);
		return new Point(renderContext.LegendRenderContext.DrawingRect.X, renderContext.LegendRenderContext.DrawingRect.Y);
	}

	internal static Size smethod_19(Interface32 g, Class784 renderContext, Legend legend)
	{
		SizeF sizeF = smethod_21(g, renderContext);
		Class740 chart = renderContext.Chart2007;
		if (float.IsNaN(legend.Width) && float.IsNaN(legend.Height))
		{
			int frameBlank = renderContext.LegendRenderContext.FrameBlank;
			int textSpan = renderContext.LegendRenderContext.TextSpan;
			int count = renderContext.LegendRenderContext.DisplayedEntryProperties.Count;
			int num3;
			int num4;
			if (legend.Position != LegendPositionType.Top && legend.Position != 0)
			{
				renderContext.LegendRenderContext.IsVertical = true;
				int num = chart.ChartAreaInternal.Height - 2 * Struct24.int_0;
				int num2 = chart.Width / 3;
				SizeF layout = new SizeF(num2, num);
				SizeF sizeF2 = smethod_22(g, layout, renderContext);
				num3 = Struct41.smethod_3((float)frameBlank + sizeF.Width + sizeF2.Width);
				num4 = Struct41.smethod_3((float)(2 * frameBlank) + (float)count * (sizeF2.Height + (float)textSpan));
				if (num3 > num2)
				{
					num3 = num2;
				}
				if (num4 > num)
				{
					num4 = num;
				}
			}
			else
			{
				SizeF layout = new SizeF(renderContext.Chart2007.Width - 2 * Struct24.int_0, renderContext.Chart2007.ChartAreaInternal.Height / 2 - Struct24.int_0);
				SizeF sizeF2 = smethod_22(g, layout, renderContext);
				int num5 = Struct41.smethod_3(sizeF.Width + sizeF2.Width);
				int num6 = Struct41.smethod_5(layout.Width) - frameBlank;
				int num7 = num6 / num5;
				if (num7 == 0)
				{
					num7 = 1;
				}
				SizeF sizeF3 = smethod_20(g, layout, renderContext);
				int num8 = Struct41.smethod_3(sizeF.Width * (float)count + sizeF3.Width);
				if (num8 <= num6)
				{
					renderContext.LegendRenderContext.IsVertical = false;
					num3 = frameBlank + num8 + textSpan;
					num4 = Struct41.smethod_3(sizeF3.Height + (float)(2 * frameBlank));
				}
				else
				{
					renderContext.LegendRenderContext.IsVertical = false;
					num3 = frameBlank + num7 * num5 + textSpan;
					num4 = Struct41.smethod_3((float)count / (float)num7) * (Struct41.smethod_3(sizeF2.Height) + textSpan) + 2 * frameBlank;
					int num9 = chart.ChartAreaInternal.Height / 2 - Struct24.int_0;
					if (num4 > num9)
					{
						int num10 = 0;
						int num11 = 0;
						while (num10 <= num9 && num11 <= count)
						{
							num10 = Struct41.smethod_3((float)num11 / (float)num7) * (Struct41.smethod_3(sizeF2.Height) + textSpan) + 2 * frameBlank;
							num11 += num7;
						}
						if (num11 < count && num10 != num9)
						{
							if (num10 > num9)
							{
								num4 = num10 - (Struct41.smethod_3(sizeF2.Height) + textSpan);
							}
						}
						else
						{
							num4 = num10;
						}
					}
				}
				if (num4 > chart.ChartAreaInternal.Height - 2 * Struct24.int_0)
				{
					num4 = chart.ChartAreaInternal.Height - 2 * Struct24.int_0;
				}
			}
			return new Size(num3, num4);
		}
		Size result = new Size((int)(legend.Width * (float)chart.Width), (int)(legend.Height * (float)chart.Height));
		SizeF sizeF4 = smethod_22(g, new SizeF(chart.Width, chart.Height), renderContext);
		Struct41.smethod_3(sizeF.Width + sizeF4.Width);
		switch (legend.Position)
		{
		case LegendPositionType.Bottom:
		case LegendPositionType.Top:
			renderContext.LegendRenderContext.IsVertical = false;
			break;
		case LegendPositionType.Left:
		case LegendPositionType.Right:
		case LegendPositionType.TopRight:
			renderContext.LegendRenderContext.IsVertical = true;
			break;
		}
		return result;
	}

	internal static SizeF smethod_20(Interface32 g, SizeF layOut, Class784 renderContext)
	{
		List<Class787> displayedEntryProperties = renderContext.LegendRenderContext.DisplayedEntryProperties;
		SizeF result = new SizeF(0f, 0f);
		int textSpan = renderContext.LegendRenderContext.TextSpan;
		for (int i = 0; i < displayedEntryProperties.Count; i++)
		{
			string name = displayedEntryProperties[i].Name;
			SizeF sizeF = Struct39.smethod_17(g, name, renderContext.LegendRenderContext.TextFont, layOut);
			sizeF.Width += 2 * textSpan;
			result.Width += sizeF.Width;
			if (result.Height < sizeF.Height)
			{
				result.Height = sizeF.Height;
			}
		}
		return result;
	}

	internal static SizeF smethod_21(Interface32 g, Class784 renderContext)
	{
		if (renderContext.LegendRenderContext.IsWideKey)
		{
			return new SizeF(renderContext.LegendRenderContext.WideKeyWidth, Struct41.smethod_3(g.GraphicsTools.imethod_2(renderContext.LegendRenderContext.TextFont)));
		}
		return new SizeF(renderContext.LegendRenderContext.KeyHeight, Struct39.smethod_22(g, renderContext.LegendRenderContext.TextFont));
	}

	internal static SizeF smethod_22(Interface32 g, SizeF layout, Class784 renderContext)
	{
		layout = new SizeF(layout.Width, layout.Height);
		SizeF result = new SizeF(0f, 0f);
		int textSpan = renderContext.LegendRenderContext.TextSpan;
		List<Class787> displayedEntryProperties = renderContext.LegendRenderContext.DisplayedEntryProperties;
		for (int i = 0; i < displayedEntryProperties.Count; i++)
		{
			SizeF sizeF = Struct39.smethod_17(g, displayedEntryProperties[i].Name, renderContext.LegendRenderContext.TextFont, layout);
			sizeF.Width += 2 * textSpan;
			if (result.Width < sizeF.Width)
			{
				result.Width = sizeF.Width;
			}
			if (result.Height < sizeF.Height)
			{
				result.Height = sizeF.Height;
			}
		}
		return result;
	}

	internal static void smethod_23(Interface32 g, bool primaryAxisIsDisplayAxisSameAsBar, Class759 firstPrimarySeries, Class784 renderContext, Legend legend)
	{
		List<Class787> list = smethod_26(renderContext.LegendRenderContext.IsVertical, primaryAxisIsDisplayAxisSameAsBar, renderContext.LegendRenderContext.DisplayedEntryProperties, renderContext.Chart2007, renderContext);
		int count = list.Count;
		Class740 chart = renderContext.Chart2007;
		if (!float.IsNaN(legend.X) && !float.IsNaN(legend.Y))
		{
			Rectangle drawingRect = renderContext.LegendRenderContext.DrawingRect;
			drawingRect.X = (int)(legend.X * (float)chart.Width);
			drawingRect.Y = (int)(legend.Y * (float)chart.Height);
			if (drawingRect.X < 0)
			{
				drawingRect.X = 0;
			}
			if (drawingRect.Y < 0)
			{
				drawingRect.Y = 0;
			}
			renderContext.LegendRenderContext.DrawingRect = drawingRect;
		}
		Struct30.smethod_0(renderContext, renderContext.LegendRenderContext.DrawingRect, renderContext.Chart.Legend.Format);
		SizeF sizeF = smethod_21(g, renderContext);
		int frameBlank = renderContext.LegendRenderContext.FrameBlank;
		int textSpan = renderContext.LegendRenderContext.TextSpan;
		float oneColumnSpan = renderContext.LegendRenderContext.OneColumnSpan;
		float multiColumnSpan = renderContext.LegendRenderContext.MultiColumnSpan;
		int num = 1;
		int width = renderContext.LegendRenderContext.DrawingRect.Width;
		int height = renderContext.LegendRenderContext.DrawingRect.Height;
		float num2 = 0f;
		float num3 = 0f;
		SizeF sizeF2 = SizeF.Empty;
		int num4 = 0;
		SizeF layout = SizeF.Empty;
		SizeF sizeF3 = smethod_20(g, new SizeF(chart.Width, chart.Height), renderContext);
		float height2 = (((float)renderContext.LegendRenderContext.DrawingRect.Height < sizeF3.Height) ? sizeF3.Height : ((float)renderContext.LegendRenderContext.DrawingRect.Height));
		int num5 = (int)(sizeF.Width * (float)count + sizeF3.Width);
		bool flag = false;
		int num6 = 1;
		int num7;
		if (num5 <= width - frameBlank)
		{
			num7 = count;
			int num8 = 1;
			num2 = (float)(width - frameBlank - num5) / (float)(num7 + 1);
			num3 = (float)(height - renderContext.LegendRenderContext.FontHeight * 1) / 1f;
			flag = true;
		}
		else
		{
			int num9 = renderContext.LegendRenderContext.DrawingRect.Width - frameBlank;
			int num10 = num9 - (int)sizeF.Width;
			layout = new SizeF(num10, height2);
			sizeF2 = smethod_22(g, layout, renderContext);
			num4 = (int)(sizeF.Width + sizeF2.Width);
			int num11 = Struct41.smethod_4((float)num9 / (float)num4);
			if (num11 < 1)
			{
				num11 = 1;
			}
			int num8 = Struct41.smethod_3((float)count / (float)num11);
			num7 = Struct41.smethod_3((float)count / (float)num8);
			num2 = (float)(num9 - num4 * num7) / (float)num7;
			num6 = (int)Math.Round((float)height / sizeF2.Height);
			if (num6 == 0)
			{
				num6 = 1;
			}
			if (num6 > num8)
			{
				num6 = num8;
			}
			num3 = ((float)height - sizeF2.Height * (float)num6) / (float)num6;
			num = Struct41.smethod_3(sizeF2.Height / (float)Struct39.smethod_22(g, renderContext.LegendRenderContext.TextFont));
		}
		if (num2 < 0f)
		{
			num2 = 0f;
		}
		if (num > 1)
		{
			if (num3 < multiColumnSpan)
			{
				num3 = multiColumnSpan;
			}
		}
		else if (num3 < oneColumnSpan)
		{
			num3 = oneColumnSpan;
		}
		float num12 = renderContext.LegendRenderContext.DrawingRect.X;
		float num13 = renderContext.LegendRenderContext.DrawingRect.Y;
		num12 += (float)frameBlank;
		num12 += num2 / (float)(flag ? 1 : 2);
		num13 += num3 / 2f;
		GraphicsState gstate = g.Save();
		g.imethod_121(renderContext.LegendRenderContext.DrawingRect);
		StringFormat format = new StringFormat(StringFormat.GenericTypographic);
		for (int i = 0; i < list.Count; i++)
		{
			Class787 @class = list[i];
			if (num6 > 1 && Math.Round(num13 + sizeF2.Height) > (double)renderContext.LegendRenderContext.DrawingRect.Bottom)
			{
				break;
			}
			RectangleF rect = new RectangleF(num12, num13, sizeF.Width, sizeF.Height);
			if (chart.Type != ChartType.HighLowClose && chart.Type != ChartType.OpenHighLowClose && chart.Type != ChartType.VolumeHighLowClose && chart.Type != ChartType.VolumeOpenHighLowClose)
			{
				smethod_24(g, rect, @class, renderContext);
			}
			string name = @class.Name;
			PointF pointF = new PointF(num12 + sizeF.Width + (float)textSpan, num13);
			if (flag)
			{
				g.imethod_64(name, renderContext.LegendRenderContext.TextFont, new SolidBrush(renderContext.LegendRenderContext.FontColor), pointF.X, pointF.Y, format);
				Size size = renderContext.LegendRenderContext.DrawingRect.Size;
				if (size.Height < Struct39.smethod_22(g, renderContext.LegendRenderContext.TextFont))
				{
					size.Height = Struct41.smethod_5(Struct39.smethod_22(g, renderContext.LegendRenderContext.TextFont) + 1);
				}
				SizeF sizeF4 = Struct39.smethod_16(g, name, renderContext.LegendRenderContext.TextFont, size);
				num12 += sizeF.Width + sizeF4.Width + (float)(2 * textSpan);
				num12 += num2;
				continue;
			}
			float width2 = Struct41.smethod_3(layout.Width);
			float height3 = Struct41.smethod_3(layout.Height);
			g.imethod_61(layoutRectangle: new RectangleF(pointF.X, pointF.Y, width2, height3), s: name, font: renderContext.LegendRenderContext.TextFont, brush: new SolidBrush(renderContext.LegendRenderContext.FontColor), format: format);
			num12 += (float)num4;
			num12 += num2;
			if ((i + 1) % num7 == 0)
			{
				num12 = (float)(renderContext.LegendRenderContext.DrawingRect.X + frameBlank) + num2 / (float)(flag ? 1 : 2);
				num13 += sizeF2.Height;
				num13 += num3;
			}
		}
		g.imethod_114(gstate);
	}

	internal static void smethod_24(Interface32 g, RectangleF rect, Class787 entry, Class784 renderContext)
	{
		int num = smethod_25(g, renderContext);
		if (entry.EntryType == Enum144.const_1)
		{
			PointF point = new PointF(rect.X, rect.Y + rect.Height / 2f);
			PointF point2 = new PointF(rect.Right, rect.Y + rect.Height / 2f);
			Class755 @class = (Class755)entry.Trendline.BorderInternal.Clone();
			if (@class.Width > num)
			{
				@class.LineStyleInternal.Width = num;
			}
			@class.method_5(point, point2);
		}
		else
		{
			if (entry.EntryType != Enum144.const_0)
			{
				return;
			}
			Class759 series = entry.Series;
			Class755 class2 = (Class755)series.LineInternal.Clone();
			if (class2.Width > num)
			{
				class2.LineStyleInternal.Width = num;
			}
			if (series.IsBubbleSeries)
			{
				float num2 = renderContext.LegendRenderContext.KeyHeight;
				RectangleF rect2 = new RectangleF(rect.X, rect.Y + (rect.Height - num2) / 2f, num2, num2);
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(rect2);
				series.AreaInternal.method_6(graphicsPath);
				class2.method_8(graphicsPath);
			}
			else if (series.IsDrawMarkerInPlot)
			{
				if (class2.IsVisible)
				{
					class2.method_3(rect.X, rect.Y + rect.Height / 2f, rect.X + rect.Width, rect.Y + rect.Height / 2f);
				}
				if (series.MarkerInternal.MarkerStyle != MarkerStyleType.None)
				{
					float x = rect.X + rect.Width / 2f;
					float y = rect.Y + rect.Height / 2f;
					float markerSize = ((series.MarkerInternal.MarkerSize == 0) ? (rect.Height * Class745.float_0) : ((!((float)series.MarkerInternal.MarkerSize <= rect.Height * Class745.float_0)) ? (rect.Height * Class745.float_0) : ((float)series.MarkerInternal.MarkerSize)));
					series.MarkerInternal.method_5(x, y, markerSize);
				}
			}
			else
			{
				float width = rect.Width;
				float num3 = renderContext.LegendRenderContext.KeyHeight;
				RectangleF rect3 = new RectangleF(rect.X, rect.Y + rect.Height / 2f - num3 / 2f, width, num3);
				series.AreaInternal.method_5(rect3);
				class2.method_7(rect3);
			}
		}
	}

	private static int smethod_25(Interface32 g, Class784 renderContext)
	{
		if (Struct39.smethod_22(g, renderContext.LegendRenderContext.TextFont) <= 8)
		{
			return 1;
		}
		int num = Struct41.smethod_5(renderContext.LegendRenderContext.TextFont.Size) - 8;
		int num2 = Struct41.smethod_3((double)num / 5.0) * 2;
		switch (num % 5)
		{
		default:
			return num2 + 1;
		case 1:
		case 2:
			return num2;
		}
	}

	internal static List<Class787> smethod_26(bool isVertical, bool primaryAxisIsDisplayAxisSameAsBar, List<Class787> listToSort, Class740 chart, Class784 renderContext)
	{
		List<Class787> list = smethod_28(Enum144.const_0, plotOnSecondAxis: false, listToSort);
		List<Class787> list2 = smethod_28(Enum144.const_0, plotOnSecondAxis: true, listToSort);
		List<Class787> list3 = smethod_28(Enum144.const_1, plotOnSecondAxis: false, listToSort);
		List<Class787> list4 = smethod_28(Enum144.const_1, plotOnSecondAxis: true, listToSort);
		bool isPlotOrderReversed = renderContext.X1AxisRenderContext.Axis.IsPlotOrderReversed;
		bool isPlotOrderReversed2 = renderContext.Y1AxisRenderContext.Axis.IsPlotOrderReversed;
		bool flag = true;
		List<Class759> list5 = chart.NSeriesInternal.method_9();
		if (list5.Count > 0 && list5[0].PlotOnSecondAxis)
		{
			flag = false;
		}
		bool flag2 = false;
		if (list.Count > 0)
		{
			Class759 series = list[0].Series;
			if (series.IsStatckedSeries || series.IsPercentSeries)
			{
				flag2 = true;
			}
		}
		if (list2.Count > 0)
		{
			Class759 series2 = list2[0].Series;
			if (series2.IsStatckedSeries || series2.IsPercentSeries)
			{
				flag2 = true;
			}
		}
		if (primaryAxisIsDisplayAxisSameAsBar)
		{
			if (!flag2)
			{
				if (!isPlotOrderReversed && isVertical)
				{
					list = smethod_27(list);
					list2 = smethod_27(list2);
					list3.Reverse();
					list4.Reverse();
				}
			}
			else if (isPlotOrderReversed2 && isVertical)
			{
				list = smethod_27(list);
				list2 = smethod_27(list2);
				list3.Reverse();
				list4.Reverse();
			}
		}
		else if (flag2 && isVertical)
		{
			list = smethod_27(list);
			list2 = smethod_27(list2);
			list3.Reverse();
			list4.Reverse();
		}
		List<Class787> list6 = new List<Class787>();
		if (flag)
		{
			list6.AddRange(list);
			list6.AddRange(list2);
			list6.AddRange(list3);
			list6.AddRange(list4);
		}
		else
		{
			list6.AddRange(list2);
			list6.AddRange(list);
			list6.AddRange(list4);
			list6.AddRange(list3);
		}
		return list6;
	}

	private static List<Class787> smethod_27(List<Class787> list)
	{
		List<List<Class787>> list2 = new List<List<Class787>>();
		Class759 @class = null;
		if (list.Count > 0)
		{
			@class = list[0].Series;
			List<Class787> list3 = new List<Class787>();
			list3.Add(list[0]);
			list2.Add(list3);
			for (int i = 1; i < list.Count; i++)
			{
				Class787 class2 = list[i];
				if (class2.Series.ResembleType == @class.ResembleType)
				{
					List<Class787> list4 = list2[list2.Count - 1];
					list4.Add(list[i]);
					continue;
				}
				@class = class2.Series;
				List<Class787> list5 = new List<Class787>();
				list5.Add(list[i]);
				list2.Add(list5);
			}
			List<Class787> list6 = new List<Class787>();
			for (int j = 0; j < list2.Count; j++)
			{
				List<Class787> list7 = list2[j];
				list7.Reverse();
				list6.AddRange(list7);
			}
			return list6;
		}
		return list;
	}

	private static List<Class787> smethod_28(Enum144 entryType, bool plotOnSecondAxis, List<Class787> listToSort)
	{
		List<Class787> list = new List<Class787>();
		for (int i = 0; i < listToSort.Count; i++)
		{
			Class787 @class = listToSort[i];
			if (@class.EntryType == entryType && @class.Series.PlotOnSecondAxis == plotOnSecondAxis)
			{
				list.Add(@class);
			}
		}
		return list;
	}
}
