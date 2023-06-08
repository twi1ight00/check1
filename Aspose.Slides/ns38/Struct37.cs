using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns2;
using ns25;
using ns35;
using ns36;
using ns37;
using ns40;

namespace ns38;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct37
{
	private static float float_0 = 0.05f;

	private static float float_1 = 0.6f;

	internal static void smethod_0(Interface32 g, Rectangle rect, Class759 aSeries, Class784 renderContext)
	{
		Class740 chart = aSeries.Chart;
		List<Class759> list = chart.NSeriesInternal.method_10(aSeries.AxisGroup, new ChartType[1] { aSeries.Type });
		if (chart.NSeriesInternal.method_12(aSeries, aSeries.AxisGroup, new ChartType[1] { aSeries.Type }) == 0)
		{
			switch (aSeries.Type)
			{
			case ChartType.Doughnut:
				smethod_11(g, chart, rect, list, renderContext);
				break;
			case ChartType.ExplodedDoughnut:
				smethod_12(g, chart, rect, list, renderContext);
				break;
			case ChartType.Pie:
				smethod_17(g, chart, rect, aSeries, renderContext);
				smethod_1(g, chart, rect, aSeries, renderContext);
				break;
			case ChartType.PieOfPie:
				smethod_9(g, chart, rect, aSeries, renderContext);
				break;
			case ChartType.ExplodedPie:
				smethod_17(g, chart, rect, aSeries, renderContext);
				smethod_8(g, chart, rect, aSeries, renderContext);
				break;
			case ChartType.BarOfPie:
				smethod_10(g, chart, rect, aSeries, renderContext);
				break;
			}
		}
	}

	private static void smethod_1(Interface32 g, Class740 chart, Rectangle rect, Class759 aSeries, Class784 renderContext)
	{
		int index = aSeries.Index;
		double num = 0.0;
		Class747 pointsInternal = aSeries.PointsInternal;
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			num += Math.Abs(pointsInternal[i].YValue);
		}
		double num2 = (float)aSeries.AngleOfFirstSlice - 90f;
		double num3 = 0.0;
		double num4 = 90 - aSeries.AngleOfFirstSlice;
		GraphicsPath graphicsPath = new GraphicsPath();
		for (int j = 0; j < pointsInternal.Count; j++)
		{
			Class748 @class = pointsInternal.method_0(j);
			num3 = smethod_39(pointsInternal[j].YValue, num);
			if (@class.Explosion > 0)
			{
				smethod_7(@class, rect, num2, (float)((num3 == 0.0) ? 0.01 : num3), num4);
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddPie(rect, (float)num2, (float)((num3 == 0.0) ? 0.01 : num3));
				@class.AreaInternal.method_6(graphicsPath2);
				graphicsPath.AddPie(rect, (float)num2, (float)((num3 == 0.0) ? 0.01 : num3));
				g.ResetTransform();
			}
			else
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddPie(rect, (float)num2, (float)((num3 == 0.0) ? 0.01 : num3));
				@class.AreaInternal.method_6(graphicsPath3);
				graphicsPath.AddPie(rect, (float)num2, (float)((num3 == 0.0) ? 0.01 : num3));
			}
			num2 += num3;
			num4 -= num3;
		}
		double num5 = (double)rect.X + (double)rect.Width / 2.0;
		double num6 = (double)rect.Y + (double)rect.Height / 2.0;
		double num7 = (double)rect.Width / 2.0;
		num2 = (float)aSeries.AngleOfFirstSlice - 90f;
		num3 = 0.0;
		PointF pt = PointF.Empty;
		PointF empty = PointF.Empty;
		PointF pointF = new PointF((float)num5, (float)num6);
		num4 = 90 - aSeries.AngleOfFirstSlice;
		bool flag = false;
		for (int k = 0; k < pointsInternal.Count; k++)
		{
			Class748 class2 = pointsInternal.method_0(k);
			num3 = smethod_39(pointsInternal[k].YValue, num);
			if (k == 0)
			{
				pt = smethod_4(num5, num6, num4, num7);
			}
			empty = smethod_4(num5, num6, num4 - num3, num7);
			if (class2.Explosion > 0)
			{
				smethod_7(class2, rect, num2, (float)((num3 == 0.0) ? 0.01 : num3), num4);
			}
			if (num3 == 0.0)
			{
				num3 = 0.009999999776482582;
			}
			GraphicsPath graphicsPath4 = new GraphicsPath();
			if (num3 == 360.0)
			{
				graphicsPath4.AddArc(rect, (float)num2, (float)num3);
			}
			else
			{
				graphicsPath4.AddLine(pointF, pt);
				graphicsPath4.AddArc(rect, (float)num2, (float)num3);
				graphicsPath4.AddLine(empty, pointF);
			}
			class2.BorderInternal.method_8(graphicsPath4);
			if (!flag && class2.BorderInternal.IsVisible && class2.Explosion <= 0)
			{
				g.imethod_80(new SolidBrush(Color.Black), pointF.X - 0.5f, pointF.Y - 0.5f, 1f, 1f, 0f, 360f);
				flag = true;
			}
			if (class2.Explosion > 0)
			{
				g.ResetTransform();
			}
			num2 += num3;
			num4 -= num3;
			pt = empty;
		}
		num2 = 90f - (float)aSeries.AngleOfFirstSlice;
		num3 = 0.0;
		float turnLength = (float)(num7 * (double)float_0);
		double num8 = 0.0;
		double num9 = 1.0;
		int index2 = 0;
		for (int l = 0; l < pointsInternal.Count; l++)
		{
			Class748 class3 = pointsInternal.method_0(l);
			double num10 = ((num == 0.0) ? 1.0 : (Math.Abs(class3.YValue) / num * 100.0));
			num8 += Math.Round(num10);
			double num11 = num10 - Math.Truncate(num10);
			if (num11 > 0.5 && num11 < num9)
			{
				index2 = l;
				num9 = num11;
			}
		}
		if (num8 > 100.0)
		{
			Class748 class4 = pointsInternal.method_0(index2);
			class4.YValue = Math.Truncate(class4.YValue * 100.0) / 100.0;
		}
		for (int m = 0; m < pointsInternal.Count; m++)
		{
			Class748 class5 = pointsInternal.method_0(m);
			Class750 dataLabelsInternal = class5.DataLabelsInternal;
			if (dataLabelsInternal.IsVisible)
			{
				double percent = ((num == 0.0) ? 0.01 : (Math.Abs(class5.YValue) / num));
				num3 = smethod_39(class5.YValue, num);
				double num12 = (num2 - num3 / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
				double num13 = (float)class5.Explosion / 100f;
				double num14 = (1.0 + num13) * num7 * Math.Cos(num12);
				double num15 = (1.0 + num13) * num7 * Math.Sin(num12);
				RectangleF rect2 = dataLabelsInternal.rectangleF_0;
				chart.method_2(ref rect2);
				smethod_43(g, chart, index, m, percent, rect2, 0.0, renderContext);
				dataLabelsInternal.pointF_0 = new PointF((float)(num5 + num14), (float)(num6 - num15));
				if (aSeries.HasLeaderLines && (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto))
				{
					smethod_2(g, aSeries.LeaderLinesInternal, graphicsPath, rect2, dataLabelsInternal.pointF_0, turnLength);
				}
				num2 -= num3;
			}
		}
	}

	private static void smethod_2(Interface32 g, Class755 leaderLine, GraphicsPath piePath, RectangleF rectDl, PointF start, float turnLength)
	{
		RectangleF rectangleF = Class790.smethod_0(piePath);
		PointF pointF = new PointF(rectangleF.X + rectangleF.Width / 2f, rectangleF.Y + rectangleF.Height / 2f);
		PointF pt = start;
		if (start.X < pointF.X)
		{
			pt.X -= 1f;
		}
		else
		{
			pt.X += 1f;
		}
		if (start.Y < pointF.Y)
		{
			pt.Y -= 1f;
		}
		else
		{
			pt.Y += 1f;
		}
		PointF pt2 = new PointF(rectDl.Left, rectDl.Top + rectDl.Height / 3f);
		PointF pt3 = new PointF(rectDl.Left + rectDl.Width / 3f, rectDl.Top);
		PointF pt4 = new PointF(rectDl.Right, rectDl.Top + rectDl.Height / 3f);
		PointF pt5 = new PointF(rectDl.Left + rectDl.Width / 3f, rectDl.Bottom);
		int num = smethod_3(start, rectDl);
		GraphicsPath graphicsPath = new GraphicsPath();
		Region region = null;
		PointF empty = PointF.Empty;
		switch (num)
		{
		case 1:
		{
			empty = new PointF(pt4.X + turnLength, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.X <= start.X)
			{
				GraphicsPath graphicsPath7 = new GraphicsPath();
				graphicsPath7.AddLine(pt4, empty);
				graphicsPath7.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath7);
			}
			break;
		}
		case 2:
		{
			empty = new PointF(pt4.X + turnLength, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.X <= start.X)
			{
				GraphicsPath graphicsPath8 = new GraphicsPath();
				graphicsPath8.AddLine(pt4, empty);
				graphicsPath8.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath8);
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + turnLength);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.Y <= start.Y)
			{
				GraphicsPath graphicsPath9 = new GraphicsPath();
				graphicsPath9.AddLine(pt5, empty);
				graphicsPath9.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath9);
			}
			break;
		}
		case 3:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + turnLength);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.Y <= start.Y)
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddLine(pt5, empty);
				graphicsPath6.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath6);
			}
			break;
		}
		case 4:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - turnLength, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.X >= start.X)
			{
				GraphicsPath graphicsPath12 = new GraphicsPath();
				graphicsPath12.AddLine(pt2, empty);
				graphicsPath12.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath12);
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + turnLength);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.Y <= start.Y)
			{
				GraphicsPath graphicsPath13 = new GraphicsPath();
				graphicsPath13.AddLine(pt5, empty);
				graphicsPath13.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath13);
			}
			break;
		}
		case 5:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - turnLength, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.X >= start.X)
			{
				GraphicsPath graphicsPath10 = new GraphicsPath();
				graphicsPath10.AddLine(pt2, empty);
				graphicsPath10.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath10);
			}
			break;
		}
		case 6:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - turnLength, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.X >= start.X)
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(pt2, empty);
				graphicsPath4.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath4);
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - turnLength);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.Y >= start.Y)
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddLine(pt3, empty);
				graphicsPath5.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath5);
			}
			break;
		}
		case 7:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - turnLength);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.Y >= start.Y)
			{
				GraphicsPath graphicsPath11 = new GraphicsPath();
				graphicsPath11.AddLine(pt3, empty);
				graphicsPath11.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath11);
			}
			break;
		}
		case 8:
		{
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt4.X + turnLength, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			Pen pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.X <= start.X)
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddLine(pt4, empty);
				graphicsPath2.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath2);
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - turnLength);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			pen = leaderLine.method_9(graphicsPath);
			graphicsPath.Widen(pen);
			region = new Region(graphicsPath);
			region.Intersect(piePath);
			if (g.GraphicsTools.imethod_1(region) && empty.Y >= start.Y)
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddLine(pt3, empty);
				graphicsPath3.AddLine(empty, start);
				pen = leaderLine.method_9(graphicsPath);
				g.imethod_45(pen, graphicsPath3);
			}
			break;
		}
		}
	}

	private static int smethod_3(PointF start, RectangleF rectDl)
	{
		int num = 0;
		if (rectDl.Right < start.X)
		{
			if (rectDl.Bottom < start.Y)
			{
				return 2;
			}
			if (rectDl.Top > start.Y)
			{
				return 8;
			}
			return 1;
		}
		if (rectDl.Left > start.X)
		{
			if (rectDl.Bottom < start.Y)
			{
				return 4;
			}
			if (rectDl.Top > start.Y)
			{
				return 6;
			}
			return 5;
		}
		if (rectDl.Bottom < start.Y)
		{
			return 3;
		}
		if (rectDl.Top > start.Y)
		{
			return 7;
		}
		return 0;
	}

	private static PointF smethod_4(double XOfCircleCenter, double YOfCircleCenter, double angle, double r)
	{
		double num = angle * Math.PI / 180.0 % (Math.PI * 2.0);
		double num2 = r * Math.Cos(num);
		double num3 = r * Math.Sin(num);
		num2 = XOfCircleCenter + num2;
		num3 = YOfCircleCenter - num3;
		return new PointF((float)num2, (float)num3);
	}

	private static bool smethod_5(RectangleF a, Rectangle b)
	{
		RectangleF b2 = new RectangleF(b.X, b.Y, b.Width, b.Height);
		return smethod_6(a, b2);
	}

	private static bool smethod_6(RectangleF a, RectangleF b)
	{
		if (a.Left >= b.Left && a.Right <= b.Right && a.Top >= b.Top && a.Bottom <= b.Bottom)
		{
			return true;
		}
		return false;
	}

	private static void smethod_7(Class748 chartPoint, Rectangle rect, double startAngle, double sweepAngle, double actualAngle)
	{
		Class740 chart = chartPoint.Chart;
		Interface32 graphics = chart.Graphics;
		Rectangle b = new Rectangle(0, 0, chart.Width, chart.Height);
		int num = chartPoint.Explosion;
		double num2 = (double)rect.X + (double)rect.Width / 2.0;
		double num3 = (double)rect.Y + (double)rect.Height / 2.0;
		double num4 = (double)rect.Width / 2.0;
		double r = num4 * (double)num / 100.0;
		PointF pointF = smethod_4(num2, num3, actualAngle - sweepAngle / 2.0, r);
		Rectangle pieRect = new Rectangle(Struct41.smethod_5((double)pointF.X - num4), Struct41.smethod_5((double)pointF.Y - num4), rect.Width, rect.Height);
		RectangleF a = smethod_40(pieRect, startAngle, sweepAngle);
		if (num > 0)
		{
			while (!smethod_5(a, b) && num > 0)
			{
				num--;
				r = num4 * (double)num / 100.0;
				pointF = smethod_4(num2, num3, actualAngle - sweepAngle / 2.0, r);
				pieRect = new Rectangle(Struct41.smethod_5((double)pointF.X - num4), Struct41.smethod_5((double)pointF.Y - num4), rect.Width, rect.Height);
				a = smethod_40(pieRect, startAngle, sweepAngle);
			}
		}
		else
		{
			while (!smethod_5(a, b) && num < 0)
			{
				num++;
				r = num4 * (double)num / 100.0;
				pointF = smethod_4(num2, num3, actualAngle - sweepAngle / 2.0, r);
				pieRect = new Rectangle(Struct41.smethod_5((double)pointF.X - num4), Struct41.smethod_5((double)pointF.Y - num4), rect.Width, rect.Height);
				a = smethod_40(pieRect, startAngle, sweepAngle);
			}
		}
		Matrix matrix = new Matrix();
		matrix.Translate((float)((double)pointF.X - num2), (float)((double)pointF.Y - num3));
		graphics.Transform = matrix;
	}

	private static void smethod_8(Interface32 g, Class740 chart, Rectangle rect, Class759 aSeries, Class784 renderContext)
	{
		_ = chart.NSeriesInternal;
		int index = aSeries.Index;
		double num = 0.0;
		Class747 pointsInternal = aSeries.PointsInternal;
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			num += Math.Abs(pointsInternal[i].YValue);
		}
		double num2 = (double)rect.X + (double)rect.Width / 2.0;
		double num3 = (double)rect.Y + (double)rect.Height / 2.0;
		GraphicsPath graphicsPath = new GraphicsPath();
		double num4 = (float)aSeries.AngleOfFirstSlice - 90f;
		double num5 = 0.0;
		double num6 = 90f - (float)aSeries.AngleOfFirstSlice;
		for (int j = 0; j < pointsInternal.Count; j++)
		{
			_ = pointsInternal.method_0(j).DataLabelsInternal;
			num5 = smethod_39(pointsInternal[j].YValue, num);
			double num7 = (num6 - num5 / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
			Class748 @class = pointsInternal.method_0(j);
			double num8 = (float)@class.Explosion / 100f;
			double num9 = (double)rect.Width / 2.0 / (1.0 + num8);
			double num10 = num9 * num8;
			double num11 = num10 * Math.Cos(num7);
			double num12 = num10 * Math.Sin(num7);
			double num13 = num2 + num11;
			double num14 = num3 - num12;
			Rectangle rect2 = new Rectangle((int)(num13 - num9), (int)(num14 - num9), (int)(2.0 * num9), (int)(2.0 * num9));
			if (num5 == 0.0)
			{
				num5 = 0.001;
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPie(rect2, (float)num4, (float)num5);
			graphicsPath.AddPie(rect2, (float)num4, (float)num5);
			@class.AreaInternal.method_6(graphicsPath2);
			if (num5 == 360.0)
			{
				graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddArc(rect2, (float)num4, (float)num5);
			}
			@class.BorderInternal.method_8(graphicsPath2);
			num4 += num5;
			num6 -= num5;
		}
		double num15 = 90f - (float)aSeries.AngleOfFirstSlice;
		for (int k = 0; k < pointsInternal.Count; k++)
		{
			Class748 class2 = pointsInternal.method_0(k);
			Class750 dataLabelsInternal = class2.DataLabelsInternal;
			double percent = ((num == 0.0) ? 0.01 : (Math.Abs(class2.YValue) / num));
			num5 = smethod_39(pointsInternal[k].YValue, num);
			double num16 = (num15 - num5 / 2.0) % 360.0;
			double num17 = (dataLabelsInternal.double_0 = num16 * Math.PI / 180.0);
			double num18 = (float)class2.Explosion / 100f;
			double num19 = (double)rect.Width / 2.0 / (1.0 + num18);
			double num20 = (1.0 + num18) * num19 * Math.Cos(num17);
			double num21 = (1.0 + num18) * num19 * Math.Sin(num17);
			num20 = num2 + num20;
			num21 = num3 - num21;
			RectangleF rect3 = dataLabelsInternal.rectangleF_0;
			chart.method_2(ref rect3);
			smethod_43(g, chart, index, k, percent, rect3, 0.0, renderContext);
			dataLabelsInternal.pointF_0 = new PointF((float)num20, (float)num21);
			float turnLength = (float)(num19 * (double)float_0);
			if (aSeries.HasLeaderLines && (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto))
			{
				smethod_2(g, aSeries.LeaderLinesInternal, graphicsPath, rect3, dataLabelsInternal.pointF_0, turnLength);
			}
			num15 -= num5;
		}
	}

	private static void smethod_9(Interface32 g, Class740 chart, Rectangle rect, Class759 aSeries, Class784 renderContext)
	{
		int radiusFirst = chart.RadiusFirst;
		int radiusSecond = chart.RadiusSecond;
		int gapWidthBetween2Plots = chart.GapWidthBetween2Plots;
		Class748 virtualPointInternal = aSeries.VirtualPointInternal;
		int num = rect.Width - (2 * radiusFirst + gapWidthBetween2Plots + 2 * radiusSecond);
		int num2 = rect.X + num / 2 + radiusFirst;
		int num3 = rect.Y + rect.Height / 2;
		int num4 = rect.Right - num / 2 - radiusSecond;
		int num5 = num3;
		int index = aSeries.Index;
		Class747 pointsInternal = aSeries.PointsInternal;
		int count = pointsInternal.Count;
		int num6 = 0;
		int num7 = 0;
		SortedList<int, double> sortedList = new SortedList<int, double>();
		SortedList<int, double> sortedList2 = new SortedList<int, double>();
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		switch ((renderContext.Chart.ChartData.SeriesGroups[0] as ChartSeriesGroup).PPTXUnsupportedProps.OfPieSplitType)
		{
		case Enum270.const_1:
		{
			Class884 ofPieCustomSplitPoints = (renderContext.Chart.ChartData.SeriesGroups[0] as ChartSeriesGroup).PPTXUnsupportedProps.OfPieCustomSplitPoints;
			ChartDataPointCollection chartDataPointCollection = (ChartDataPointCollection)renderContext.Chart.ChartData.Series[0].DataPoints;
			for (int j = 0; j < chartDataPointCollection.Count; j++)
			{
				IChartDataPoint chartDataPoint = chartDataPointCollection[j];
				IDoubleChartValue value = chartDataPoint.Value;
				if (value.DataSourceType != 0 || value.AsCell != null)
				{
					double num11 = ((value.Data == null || double.IsNaN(value.ToDouble())) ? 0.0 : value.ToDouble());
					if (ofPieCustomSplitPoints.Contains(chartDataPoint))
					{
						sortedList2.Add(j + 1, num11);
						num9 += num11;
					}
					else
					{
						sortedList.Add(j + 1, num11);
						num8 += num11;
					}
					num10 += num11;
				}
			}
			sortedList.Add(0, num9);
			num8 += num9;
			break;
		}
		case Enum270.const_0:
		case Enum270.const_2:
		case Enum270.const_3:
		case Enum270.const_4:
		{
			if (count == 1)
			{
				num6 = 1;
			}
			else
			{
				num7 = Struct41.smethod_3((float)count / 3f);
				num6 = count - num7 + 1;
			}
			for (int i = 0; i < count; i++)
			{
				if (i + 1 < num6)
				{
					sortedList.Add(i + 1, Math.Abs(pointsInternal[i].YValue));
					num8 += Math.Abs(pointsInternal[i].YValue);
				}
				else
				{
					sortedList2.Add(i + 1, Math.Abs(pointsInternal[i].YValue));
					num9 += Math.Abs(pointsInternal[i].YValue);
				}
				num10 += Math.Abs(pointsInternal[i].YValue);
			}
			sortedList.Add(0, num9);
			num8 += num9;
			break;
		}
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		double num12 = ((num8 == 0.0) ? 0.0 : ((0.0 - Math.Abs(sortedList[0])) / num8 * 360.0 / 2.0));
		if (num6 == 1)
		{
			num12 = 0.0;
		}
		double num13 = 0.0;
		Rectangle rect2 = new Rectangle(num2 - radiusFirst, num3 - radiusFirst, 2 * radiusFirst, 2 * radiusFirst);
		for (int k = 0; k < sortedList.Count; k++)
		{
			Class748 @class = null;
			if (sortedList.Values[k] == 0.0)
			{
				continue;
			}
			if (k == 0)
			{
				if (virtualPointInternal != null)
				{
					Color[] array = chart.Themes.ThemeColors.method_5(chart.StyleIndex, count + 1);
					Color color = array[count];
					if (count < renderContext.Chart.ChartData.Series[0].DataPoints.Count)
					{
						IChartDataPoint chartDataPoint2 = renderContext.Chart.ChartData.Series[0].DataPoints[count];
						renderContext.Chart.method_16(virtualPointInternal.AreaInternal, (FillFormat)chartDataPoint2.Format.Fill, renderContext.Chart2007);
						DataLabel dataLabel = (DataLabel)chartDataPoint2.Label;
						virtualPointInternal.DataLabels.ChartFrame.FontColor = renderContext.Chart.method_14(((DataLabelFormat)dataLabel.DataLabelFormat).TextFormatManager, dataLabel.TextFrameForOverriding, virtualPointInternal.DataLabels.ChartFrame.FontColor, renderContext.Chart2007);
						virtualPointInternal.DataLabels.ChartFrame.TextFont = renderContext.Chart.method_15(((DataLabelFormat)dataLabel.DataLabelFormat).TextFormatManager, dataLabel.TextFrameForOverriding, isBold: false, isTitle: false);
						if (dataLabel.DataLabelFormat.ShowLegendKey)
						{
							virtualPointInternal.DataLabels.IsLegendKeyShown = true;
						}
						if (dataLabel.DataLabelFormat.ShowCategoryName)
						{
							virtualPointInternal.DataLabels.IsCategoryNameShown = true;
						}
						if (dataLabel.DataLabelFormat.ShowPercentage)
						{
							virtualPointInternal.DataLabels.IsPercentageShown = true;
						}
						if (dataLabel.DataLabelFormat.ShowValue)
						{
							virtualPointInternal.DataLabels.IsValueShown = true;
						}
						if (dataLabel.DataLabelFormat.ShowBubbleSize)
						{
							virtualPointInternal.DataLabels.IsBubbleSizeShown = true;
						}
						if (dataLabel.DataLabelFormat.ShowSeriesName)
						{
							virtualPointInternal.DataLabels.IsSeriesNameShown = true;
						}
						if (renderContext.Chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Position != LegendDataLabelPosition.NotDefined)
						{
							virtualPointInternal.DataLabels.LabelPosition = renderContext.Chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.Position;
						}
						if (!float.IsNaN(dataLabel.X))
						{
							virtualPointInternal.DataLabels.ChartFrame.IsEdge = false;
							virtualPointInternal.DataLabels.ChartFrame.X = (int)(dataLabel.X * 4000f);
						}
						if (!float.IsNaN(dataLabel.Y))
						{
							virtualPointInternal.DataLabels.ChartFrame.IsEdge = false;
							virtualPointInternal.DataLabels.ChartFrame.Y = (int)(dataLabel.Y * 4000f);
						}
					}
					virtualPointInternal.AreaInternal.method_1(color);
					@class = virtualPointInternal;
				}
			}
			else
			{
				@class = pointsInternal.method_0(sortedList.Keys[k] - 1);
			}
			num13 = smethod_39(sortedList.Values[k], num8);
			if (num13 == 0.0)
			{
				num13 = 0.001;
			}
			GraphicsPath graphicsPath3 = new GraphicsPath();
			graphicsPath3.AddPie(rect2, (float)num12, (float)num13);
			graphicsPath.AddPie(rect2, (float)num12, (float)num13);
			@class.AreaInternal.method_6(graphicsPath3);
			num12 += num13;
		}
		num12 = ((num8 == 0.0) ? 0.0 : ((0.0 - Math.Abs(sortedList[0])) / num8 * 360.0 / 2.0));
		if (num6 == 1)
		{
			num12 = 0.0;
		}
		for (int l = 0; l < sortedList.Count; l++)
		{
			Class748 class2 = null;
			if (sortedList.Values[l] == 0.0)
			{
				continue;
			}
			if (l == 0)
			{
				if (virtualPointInternal != null)
				{
					class2 = virtualPointInternal;
				}
			}
			else
			{
				class2 = pointsInternal.method_0(sortedList.Keys[l] - 1);
			}
			num13 = smethod_39(sortedList.Values[l], num8);
			if (num13 == 0.0)
			{
				num13 = 0.001;
			}
			GraphicsPath graphicsPath4 = new GraphicsPath();
			if (num13 == 360.0)
			{
				graphicsPath4.AddArc(rect2, (float)num12, (float)num13);
			}
			else
			{
				graphicsPath4.AddPie(rect2, (float)num12, (float)num13);
			}
			class2.BorderInternal.method_8(graphicsPath4);
			num12 += num13;
		}
		num12 = ((num8 == 0.0) ? 0.0 : (Math.Abs(sortedList[0]) / num8 * 360.0 / 2.0));
		if (num6 == 1)
		{
			num12 = 0.0;
		}
		Rectangle rect3 = new Rectangle(num4 - radiusSecond, num5 - radiusSecond, 2 * radiusSecond, 2 * radiusSecond);
		for (int m = 0; m < sortedList2.Count; m++)
		{
			if (sortedList2.Values[m] != 0.0)
			{
				Class748 class3 = pointsInternal.method_0(sortedList2.Keys[m] - 1);
				num13 = smethod_39(sortedList2.Values[m], num9);
				if (num13 == 0.0)
				{
					num13 = 0.001;
				}
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddPie(rect3, (float)num12, (float)num13);
				class3.AreaInternal.method_6(graphicsPath5);
				num12 += num13;
			}
		}
		num12 = ((num8 == 0.0) ? 0.0 : (Math.Abs(sortedList[0]) / num8 * 360.0 / 2.0));
		if (num6 == 1)
		{
			num12 = 0.0;
		}
		for (int n = 0; n < sortedList2.Count; n++)
		{
			if (sortedList2.Values[n] != 0.0)
			{
				Class748 class4 = pointsInternal.method_0(sortedList2.Keys[n] - 1);
				num13 = smethod_39(sortedList2.Values[n], num9);
				if (num13 == 0.0)
				{
					num13 = 0.001;
				}
				GraphicsPath graphicsPath6 = new GraphicsPath();
				if (num13 == 360.0)
				{
					graphicsPath2.AddArc(rect3, (float)num12, (float)num13);
					graphicsPath6.AddArc(rect3, (float)num12, (float)num13);
				}
				else
				{
					graphicsPath2.AddPie(rect3, (float)num12, (float)num13);
					graphicsPath6.AddPie(rect3, (float)num12, (float)num13);
				}
				class4.BorderInternal.method_8(graphicsPath6);
				num12 += num13;
			}
		}
		if (aSeries.HasSeriesLines)
		{
			if (Math.Abs(sortedList.Values[0]) / num8 * 2.0 * Math.PI > Math.PI)
			{
				double num14 = Math.Acos((radiusFirst - radiusSecond) / (num4 - num2));
				PointF point = new PointF((float)((double)num2 + (double)radiusFirst * Math.Cos(num14)), (float)((double)num3 - (double)radiusFirst * Math.Sin(num14)));
				PointF point2 = new PointF((float)((double)num4 + (double)radiusSecond * Math.Cos(num14)), (float)((double)num5 - (double)radiusSecond * Math.Sin(num14)));
				PointF point3 = new PointF((float)((double)num2 + (double)radiusFirst * Math.Cos(0.0 - num14)), (float)((double)num3 - (double)radiusFirst * Math.Sin(0.0 - num14)));
				PointF point4 = new PointF((float)((double)num4 + (double)radiusSecond * Math.Cos(0.0 - num14)), (float)((double)num5 - (double)radiusSecond * Math.Sin(0.0 - num14)));
				aSeries.SeriesLinesInternal.method_5(point, point2);
				aSeries.SeriesLinesInternal.method_5(point3, point4);
			}
			else
			{
				num12 = ((num8 == 0.0) ? 0.0 : (Math.Abs(sortedList.Values[0]) / num8 * Math.PI));
				if (num6 == 1)
				{
					num12 = 0.0;
				}
				double num15 = (double)num2 + (double)radiusFirst * Math.Cos(num12);
				double num16 = (double)num3 - (double)radiusFirst * Math.Sin(num12);
				double num17 = Math.Sqrt(Math.Pow(num16 - (double)num5, 2.0) + Math.Pow(num15 - (double)num4, 2.0));
				double num14 = Math.Acos(((double)num4 - num15) / num17) + Math.Acos((double)radiusSecond / num17);
				PointF point5 = new PointF((float)num15, (float)num16);
				PointF point6 = new PointF((float)((double)num4 + (double)radiusSecond * Math.Cos(Math.PI - num14)), (float)((double)num5 - (double)radiusSecond * Math.Sin(Math.PI - num14)));
				PointF point7 = new PointF((float)((double)num2 + (double)radiusFirst * Math.Cos(0.0 - num12)), (float)((double)num3 - (double)radiusFirst * Math.Sin(0.0 - num12)));
				PointF point8 = new PointF((float)((double)num4 + (double)radiusSecond * Math.Cos(num14 + Math.PI)), (float)((double)num5 - (double)radiusSecond * Math.Sin(num14 + Math.PI)));
				aSeries.SeriesLinesInternal.method_5(point5, point6);
				aSeries.SeriesLinesInternal.method_5(point7, point8);
			}
		}
		Class750 dataLabelsInternal = aSeries.DataLabelsInternal;
		double num18 = ((num8 == 0.0) ? 0.0 : ((0.0 - Math.Abs(sortedList[0])) / num8 * 180.0));
		double num19 = ((num8 == 0.0) ? 0.0 : (Math.Abs(sortedList[0]) / num8 * 180.0));
		double num20 = 0.0 - num18;
		double num21 = 0.0 - num19;
		if (num6 == 1)
		{
			num18 = 0.0;
			num19 = 0.0;
		}
		float scaleHeight = chart.Height;
		for (int num22 = 0; num22 < sortedList.Count + sortedList2.Count; num22++)
		{
			Class748 class5 = null;
			bool flag;
			num12 = ((flag = sortedList.ContainsKey(num22)) ? num19 : num18);
			double num23 = 0.0;
			if (num22 == 0)
			{
				if (virtualPointInternal != null)
				{
					class5 = virtualPointInternal;
				}
			}
			else
			{
				class5 = pointsInternal.method_0(num22 - 1);
			}
			if (class5 != null)
			{
				dataLabelsInternal = class5.DataLabelsInternal;
				num23 = (float)class5.Explosion / 100f;
			}
			float scaleWidth = ((!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f));
			double percent = sortedList[0];
			SizeF sizeF = new SizeF(0f, 0f);
			sizeF = smethod_42(g, chart.NSeriesInternal, index, num22 - 1, percent, scaleWidth, scaleHeight, sortedList[0], renderContext);
			double x = 0.0;
			double y = 0.0;
			double num24 = 0.0;
			double num25;
			if (flag)
			{
				percent = ((num10 == 0.0) ? 0.01 : (sortedList[num22] / num10));
				num13 = ((num8 == 0.0) ? 0.0 : (sortedList[num22] / num8 * 360.0));
				num25 = radiusFirst;
				num24 = (double)radiusFirst * num23;
			}
			else
			{
				percent = ((num10 == 0.0) ? 0.01 : (sortedList2[num22] / num10));
				num13 = ((num9 == 0.0) ? 0.0 : (sortedList2[num22] / num9 * 360.0));
				num25 = radiusSecond;
				num24 = (double)radiusSecond * num23;
			}
			if (num13 == 0.0)
			{
				continue;
			}
			double num26 = (num12 - num13 / 2.0) % 360.0;
			double num14 = num26 * Math.PI / 180.0;
			bool flag2 = false;
			LegendDataLabelPosition legendDataLabelPosition = dataLabelsInternal.LabelPosition;
			if (dataLabelsInternal.ChartFrameInternal.IsXAuto && dataLabelsInternal.ChartFrameInternal.IsYAuto)
			{
				while (!flag2)
				{
					double num27;
					switch (legendDataLabelPosition)
					{
					case LegendDataLabelPosition.Center:
						num27 = num24 + num25 * 0.5;
						x = num27 * Math.Cos(num14);
						y = num27 * Math.Sin(num14);
						x -= (double)(sizeF.Width / 2f);
						y += (double)(sizeF.Height / 2f);
						flag2 = true;
						continue;
					case LegendDataLabelPosition.InsideEnd:
						num27 = num24 + num25 * 0.96;
						x = num27 * Math.Cos(num14);
						y = num27 * Math.Sin(num14);
						smethod_20(ref x, ref y, num26, sizeF);
						flag2 = true;
						continue;
					case LegendDataLabelPosition.OutsideEnd:
						num27 = num24 + num25 * 1.04;
						x = num27 * Math.Cos(num14);
						y = num27 * Math.Sin(num14);
						smethod_19(ref x, ref y, num26, sizeF);
						flag2 = true;
						continue;
					}
					num27 = num24 + num25 * 0.96;
					x = num27 * Math.Cos(num14);
					y = num27 * Math.Sin(num14);
					smethod_20(ref x, ref y, num26, sizeF);
					if (smethod_21(rectDl: new RectangleF((float)x, (float)y, sizeF.Width, sizeF.Height), g: g, drawingStartAngle: flag ? ((float)num21) : ((float)num20), startAngle: (float)num12, sweepAngle: (float)num13, r: (float)num25, explodeLength: (float)num24, dataLabels: dataLabelsInternal))
					{
						flag2 = true;
						continue;
					}
					PointF pointF = smethod_22(g, flag ? ((float)num21) : ((float)num20), (float)num12, (float)num13, (float)num25, (float)num24, sizeF, dataLabelsInternal);
					if (pointF.IsEmpty)
					{
						flag2 = false;
						legendDataLabelPosition = LegendDataLabelPosition.OutsideEnd;
					}
					else
					{
						x = pointF.X;
						y = pointF.Y;
						flag2 = true;
					}
				}
			}
			else
			{
				double num27 = num24 + num25 * 1.04;
				x = num27 * Math.Cos(num14);
				y = num27 * Math.Sin(num14);
				smethod_19(ref x, ref y, num26, sizeF);
			}
			if (flag)
			{
				x = (double)num2 + x;
				y = (double)num3 - y;
			}
			else
			{
				x = (double)num4 + x;
				y = (double)num5 - y;
			}
			if (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto)
			{
				dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_3(x), Struct41.smethod_3(y), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
				dataLabelsInternal.ChartFrameInternal.method_6();
				x = dataLabelsInternal.ChartFrameInternal.rectangle_0.X;
				y = dataLabelsInternal.ChartFrameInternal.rectangle_0.Y;
			}
			RectangleF rectangleF = new RectangleF((float)x, (float)y, sizeF.Width, sizeF.Height);
			smethod_43(g, chart, index, num22 - 1, percent, rectangleF, sortedList[0], renderContext);
			dataLabelsInternal.pointF_0 = new PointF((float)x, (float)y);
			if (flag)
			{
				double num28 = (1.0 + num23) * (double)radiusFirst * Math.Cos(num14);
				double num29 = (1.0 + num23) * (double)radiusFirst * Math.Sin(num14);
				float turnLength = (float)radiusFirst * float_0;
				dataLabelsInternal.pointF_0 = new PointF((float)((double)num2 + num28), (float)((double)num3 - num29));
				if (aSeries.HasLeaderLines && (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto))
				{
					smethod_2(g, aSeries.LeaderLinesInternal, graphicsPath, rectangleF, dataLabelsInternal.pointF_0, turnLength);
				}
			}
			else
			{
				double num30 = (1.0 + num23) * (double)radiusSecond * Math.Cos(num14);
				double num31 = (1.0 + num23) * (double)radiusSecond * Math.Sin(num14);
				float turnLength2 = (float)radiusSecond * float_0;
				dataLabelsInternal.pointF_0 = new PointF((float)((double)num4 + num30), (float)((double)num5 - num31));
				if (aSeries.HasLeaderLines && (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto))
				{
					smethod_2(g, aSeries.LeaderLinesInternal, graphicsPath2, rectangleF, dataLabelsInternal.pointF_0, turnLength2);
				}
			}
			if (flag)
			{
				num21 += num13;
				num19 -= num13;
			}
			else
			{
				num20 += num13;
				num18 -= num13;
			}
		}
	}

	private static void smethod_10(Interface32 g, Class740 chart, Rectangle rect, Class759 aSeries, Class784 renderContext)
	{
		int radiusFirst = chart.RadiusFirst;
		int radiusSecond = chart.RadiusSecond;
		int gapWidthBetween2Plots = chart.GapWidthBetween2Plots;
		Class748 virtualPointInternal = aSeries.VirtualPointInternal;
		int num = rect.Width - (2 * radiusFirst + gapWidthBetween2Plots + radiusSecond);
		int num2 = rect.X + num / 2 + radiusFirst;
		int num3 = rect.Y + rect.Height / 2;
		int num4 = rect.Right - num / 2 - radiusSecond;
		int num5 = num3;
		_ = chart.NSeriesInternal;
		int index = aSeries.Index;
		Class747 pointsInternal = aSeries.PointsInternal;
		int count = pointsInternal.Count;
		int num6 = 0;
		int num7 = 0;
		if (count == 1)
		{
			num6 = 1;
			num7 = 1;
		}
		else
		{
			num7 = Struct41.smethod_3((float)count / 3f);
			num6 = count - num7 + 1;
		}
		double[] array = new double[num6];
		double[] array2 = new double[num7];
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (i + 1 < num6)
			{
				array[i + 1] = Math.Abs(pointsInternal[i].YValue);
				num8 += array[i + 1];
			}
			else
			{
				array2[i + 1 - num6] = Math.Abs(pointsInternal[i].YValue);
				num9 += array2[i + 1 - num6];
			}
			num10 += Math.Abs(pointsInternal[i].YValue);
		}
		array[0] = num9;
		num8 += num9;
		double num11 = ((num8 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num8 * 360.0 / 2.0));
		if (num6 == 1)
		{
			num11 = 0.0;
		}
		double num12 = 0.0;
		Rectangle rect2 = new Rectangle(num2 - radiusFirst, num3 - radiusFirst, 2 * radiusFirst, 2 * radiusFirst);
		for (int j = 0; j < array.Length; j++)
		{
			Class748 @class = null;
			if (array[j] == 0.0)
			{
				continue;
			}
			if (j == 0)
			{
				if (virtualPointInternal != null)
				{
					Color[] array3 = chart.Themes.ThemeColors.method_5(chart.StyleIndex, count + 1);
					Color color = array3[count];
					virtualPointInternal.AreaInternal.method_1(color);
					@class = virtualPointInternal;
				}
			}
			else
			{
				@class = pointsInternal.method_0(j - 1);
			}
			num12 = smethod_39(array[j], num8);
			if (num12 == 0.0)
			{
				num12 = 0.001;
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rect2, (float)num11, (float)num12);
			@class.AreaInternal.method_6(graphicsPath);
			num11 += num12;
		}
		num11 = ((num8 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num8 * 360.0 / 2.0));
		if (num6 == 1)
		{
			num11 = 0.0;
		}
		for (int k = 0; k < array.Length; k++)
		{
			Class748 class2 = null;
			if (array[k] == 0.0)
			{
				continue;
			}
			if (k == 0)
			{
				if (virtualPointInternal != null)
				{
					class2 = virtualPointInternal;
				}
			}
			else
			{
				class2 = pointsInternal.method_0(k - 1);
			}
			num12 = smethod_39(array[k], num8);
			if (num12 == 0.0)
			{
				num12 = 0.001;
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			if (num12 == 360.0)
			{
				graphicsPath2.AddArc(rect2, (float)num11, (float)num12);
			}
			else
			{
				graphicsPath2.AddPie(rect2, (float)num11, (float)num12);
			}
			class2.BorderInternal.method_8(graphicsPath2);
			num11 += num12;
		}
		double num13 = num5 - radiusSecond;
		for (int l = 0; l < array2.Length; l++)
		{
			if (array2[l] != 0.0)
			{
				int index2 = array.Length - 1 + l;
				Class748 class3 = pointsInternal.method_0(index2);
				double num14 = Math.Abs(array2[l]) / num9 * 2.0 * (double)radiusSecond;
				RectangleF rect3 = new RectangleF(num4, (float)num13, radiusSecond, (float)num14);
				class3.AreaInternal.method_5(rect3);
				class3.BorderInternal.method_7(rect3);
				num13 += num14;
			}
		}
		if (aSeries.HasSeriesLines)
		{
			PointF point = new PointF(num4, num5 - radiusSecond);
			PointF point2 = new PointF(num4, num5 + radiusSecond);
			if (Math.Abs(array[0]) / num8 * 2.0 * Math.PI > Math.PI)
			{
				num11 = ((num8 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num8 * Math.PI));
				if (num6 == 1)
				{
					num11 = 0.0;
				}
				double num15 = Math.Sqrt(Math.Pow(num5 - num3, 2.0) + Math.Pow(num4 - num2, 2.0));
				double num16 = Math.Acos((double)radiusFirst / num15) + Math.Asin((double)radiusSecond / num15);
				PointF point3 = new PointF((float)((double)num2 + (double)radiusFirst * Math.Cos(num16)), (float)((double)num3 - (double)radiusFirst * Math.Sin(num16)));
				PointF point4 = new PointF((float)((double)num2 + (double)radiusFirst * Math.Cos(0.0 - num16)), (float)((double)num3 - (double)radiusFirst * Math.Sin(0.0 - num16)));
				aSeries.SeriesLinesInternal.method_5(point3, point);
				aSeries.SeriesLinesInternal.method_5(point4, point2);
			}
			else
			{
				double num16 = Math.Abs(array[0]) / num8 * Math.PI;
				PointF point5 = new PointF((float)((double)num2 + (double)radiusFirst * Math.Cos(num16)), (float)((double)num3 - (double)radiusFirst * Math.Sin(num16)));
				PointF point6 = new PointF((float)((double)num2 + (double)radiusFirst * Math.Cos(0.0 - num16)), (float)((double)num3 - (double)radiusFirst * Math.Sin(0.0 - num16)));
				aSeries.SeriesLinesInternal.method_5(point5, point);
				aSeries.SeriesLinesInternal.method_5(point6, point2);
			}
		}
		Class750 dataLabelsInternal = aSeries.DataLabelsInternal;
		double percent = array[0];
		SizeF sizeF = new SizeF(0f, 0f);
		double num17 = 0.0;
		double num18 = 0.0;
		num11 = ((num8 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num8 * 180.0));
		double num19 = 0.0 - num11;
		if (num6 == 1)
		{
			num11 = 0.0;
		}
		num12 = 0.0;
		float scaleHeight = chart.Height;
		for (int m = 0; m < array.Length; m++)
		{
			if (array[m] == 0.0)
			{
				continue;
			}
			Class748 class4 = null;
			double num20 = 0.0;
			if (m == 0)
			{
				if (virtualPointInternal != null)
				{
					class4 = virtualPointInternal;
				}
			}
			else
			{
				class4 = pointsInternal.method_0(m - 1);
			}
			if (class4 != null)
			{
				dataLabelsInternal = class4.DataLabelsInternal;
				num20 = (float)class4.Explosion / 100f;
			}
			sizeF = smethod_42(scaleWidth: (!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f), g: g, nSeries: chart.NSeriesInternal, seriesIndex: index, chartPointIndex: m - 1, percent: percent, scaleHeight: scaleHeight, otherValue: array[0], renderContext: renderContext);
			percent = ((num10 == 0.0) ? 0.01 : (array[m] / num10));
			num12 = ((num8 == 0.0) ? 0.0 : (array[m] / num8 * 360.0));
			double num21 = (double)radiusFirst * num20;
			double num22 = (num11 - num12 / 2.0) % 360.0;
			double num16 = num22 * Math.PI / 180.0;
			bool flag = false;
			LegendDataLabelPosition legendDataLabelPosition = dataLabelsInternal.LabelPosition;
			num17 = 0.0;
			num18 = 0.0;
			while (!flag)
			{
				double num23;
				switch (legendDataLabelPosition)
				{
				case LegendDataLabelPosition.Center:
					num23 = num21 + (double)radiusFirst * 0.5;
					num17 = num23 * Math.Cos(num16);
					num18 = num23 * Math.Sin(num16);
					num17 -= (double)(sizeF.Width / 2f);
					num18 += (double)(sizeF.Height / 2f);
					flag = true;
					continue;
				case LegendDataLabelPosition.InsideEnd:
					num23 = num21 + (double)radiusFirst * 0.96;
					num17 = num23 * Math.Cos(num16);
					num18 = num23 * Math.Sin(num16);
					smethod_20(ref num17, ref num18, num22, sizeF);
					flag = true;
					continue;
				case LegendDataLabelPosition.OutsideEnd:
					num23 = num21 + (double)radiusFirst * 1.04;
					num17 = num23 * Math.Cos(num16);
					num18 = num23 * Math.Sin(num16);
					smethod_19(ref num17, ref num18, num22, sizeF);
					flag = true;
					continue;
				}
				num23 = num21 + (double)radiusFirst * 0.96;
				num17 = num23 * Math.Cos(num16);
				num18 = num23 * Math.Sin(num16);
				smethod_20(ref num17, ref num18, num22, sizeF);
				RectangleF rectDl = new RectangleF((float)num17, (float)num18, sizeF.Width, sizeF.Height);
				if (smethod_21(g, (float)num19, (float)num11, (float)num12, radiusFirst, (float)num21, rectDl, dataLabelsInternal))
				{
					flag = true;
					continue;
				}
				PointF pointF = smethod_22(g, (float)num19, (float)num11, (float)num12, radiusFirst, (float)num21, sizeF, dataLabelsInternal);
				if (pointF.IsEmpty)
				{
					flag = false;
					legendDataLabelPosition = LegendDataLabelPosition.OutsideEnd;
				}
				else
				{
					num17 = pointF.X;
					num18 = pointF.Y;
					flag = true;
				}
			}
			num17 = (double)num2 + num17;
			num18 = (double)num3 - num18;
			if (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto)
			{
				dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_3(num17), Struct41.smethod_3(num18), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
				dataLabelsInternal.ChartFrameInternal.method_6();
				num17 = dataLabelsInternal.ChartFrameInternal.rectangle_0.X;
				num18 = dataLabelsInternal.ChartFrameInternal.rectangle_0.Y;
			}
			RectangleF rect4 = new RectangleF((float)num17, (float)num18, sizeF.Width, sizeF.Height);
			smethod_43(g, chart, index, m - 1, percent, rect4, array[0], renderContext);
			num11 -= num12;
			num19 += num12;
		}
		num13 = num5 - radiusSecond;
		scaleHeight = chart.Height;
		dataLabelsInternal = aSeries.DataLabelsInternal;
		for (int n = 0; n < array2.Length; n++)
		{
			if (array2[n] != 0.0)
			{
				Class748 class5 = null;
				int num24 = array.Length + n - 1;
				if (num24 < aSeries.PointsInternal.Count)
				{
					class5 = pointsInternal.method_0(num24);
				}
				if (class5 != null)
				{
					dataLabelsInternal = class5.DataLabelsInternal;
				}
				float scaleWidth2 = ((!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f));
				double num14 = Math.Abs(array2[n]) / num9 * 2.0 * (double)radiusSecond;
				num17 = num4;
				num18 = num13;
				num13 += num14;
				int chartPointIndex = array.Length - 1 + n;
				percent = ((num10 == 0.0) ? 0.01 : (array2[n] / num10));
				sizeF = smethod_42(g, chart.NSeriesInternal, index, chartPointIndex, percent, scaleWidth2, scaleHeight, array[0], renderContext);
				double num16 = 0.0;
				switch (dataLabelsInternal.LabelPosition)
				{
				case LegendDataLabelPosition.Center:
					num17 += (double)(((float)radiusSecond - sizeF.Width) / 2f);
					num18 += (num14 - (double)sizeF.Height) / 2.0;
					break;
				default:
					num17 = num17 + (double)radiusSecond + 1.0;
					num18 += (num14 - (double)sizeF.Height) / 2.0;
					break;
				case LegendDataLabelPosition.InsideEnd:
					num17 += (double)(((float)radiusSecond - sizeF.Width) / 2f);
					break;
				}
				if (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto)
				{
					dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_3(num17), Struct41.smethod_3(num18), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
					dataLabelsInternal.ChartFrameInternal.method_6();
					num17 = dataLabelsInternal.ChartFrameInternal.rectangle_0.X;
					num18 = dataLabelsInternal.ChartFrameInternal.rectangle_0.Y;
				}
				RectangleF rect5 = new RectangleF((float)num17, (float)num18, sizeF.Width, sizeF.Height);
				smethod_43(g, chart, index, chartPointIndex, percent, rect5, array[0], renderContext);
			}
		}
	}

	private static void smethod_11(Interface32 g, Class740 chart, Rectangle rect, IList list, Class784 renderContext)
	{
		Class759 @class = (Class759)list[0];
		int angleOfFirstSlice = @class.AngleOfFirstSlice;
		int doughnutHoleSize = @class.DoughnutHoleSize;
		double num = (double)rect.Width / 2.0;
		double num2 = num * (double)doughnutHoleSize / 100.0;
		double num3 = (num - num2) / (double)list.Count;
		double num4 = (double)rect.X + (double)rect.Width / 2.0;
		double num5 = (double)rect.Y + (double)rect.Height / 2.0;
		RectangleF src = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		src.X += (float)(num - num2);
		src.Y += (float)(num - num2);
		src.Width -= 2f * (float)(num - num2);
		src.Height -= 2f * (float)(num - num2);
		double num6 = num2;
		for (int i = 0; i < list.Count; i++)
		{
			Class759 class2 = (Class759)list[i];
			_ = class2.Index;
			double num7 = 0.0;
			Class747 pointsInternal = class2.PointsInternal;
			_ = pointsInternal.Count;
			for (int j = 0; j < pointsInternal.Count; j++)
			{
				num7 += Math.Abs(pointsInternal[j].YValue);
			}
			double num8 = (float)angleOfFirstSlice - 90f;
			double num9 = 0.0;
			for (int k = 0; k < pointsInternal.Count; k++)
			{
				Class748 class3 = pointsInternal.method_0(k);
				if (pointsInternal[k].YValue != 0.0)
				{
					num9 = smethod_39(pointsInternal[k].YValue, num7);
					if (num9 == 0.0)
					{
						num9 = 0.001;
					}
					GraphicsPath graphicsPath = new GraphicsPath();
					RectangleF rect2 = Struct41.smethod_27(src);
					graphicsPath.AddArc(rect2, (float)num8, (float)num9);
					double num10 = (360.0 - num8 - num9) * Math.PI / 180.0;
					double num11 = num6 * Math.Cos(num10);
					double num12 = num6 * Math.Sin(num10);
					num11 = num4 + num11;
					num12 = num5 - num12;
					PointF pt = new PointF((float)num11, (float)num12);
					num11 = (num6 + num3) * Math.Cos(num10);
					num12 = (num6 + num3) * Math.Sin(num10);
					num11 = num4 + num11;
					num12 = num5 - num12;
					PointF pt2 = new PointF((float)num11, (float)num12);
					graphicsPath.AddLine(pt, pt2);
					RectangleF rect3 = Struct41.smethod_27(src);
					rect3.X -= (float)num3;
					rect3.Y -= (float)num3;
					rect3.Width += 2f * (float)num3;
					rect3.Height += 2f * (float)num3;
					graphicsPath.AddArc(rect3, (float)num8, (float)num9);
					num10 = (360.0 - num8) * Math.PI / 180.0;
					num11 = num6 * Math.Cos(num10);
					num12 = num6 * Math.Sin(num10);
					num11 = num4 + num11;
					num12 = num5 - num12;
					PointF pt3 = new PointF((float)num11, (float)num12);
					num11 = (num6 + num3) * Math.Cos(num10);
					num12 = (num6 + num3) * Math.Sin(num10);
					num11 = num4 + num11;
					num12 = num5 - num12;
					PointF pt4 = new PointF((float)num11, (float)num12);
					graphicsPath.AddLine(pt4, pt3);
					class3.AreaInternal.method_6(graphicsPath);
					class3.BorderInternal.method_8(graphicsPath);
					num8 += num9;
				}
			}
			num6 += num3;
			src.X -= (float)num3;
			src.Y -= (float)num3;
			src.Width += 2f * (float)num3;
			src.Height += 2f * (float)num3;
		}
		float scaleHeight = chart.Height;
		for (int l = 0; l < list.Count; l++)
		{
			Class759 class4 = (Class759)list[l];
			int index = class4.Index;
			Class747 pointsInternal2 = class4.PointsInternal;
			double num13 = (float)angleOfFirstSlice - 90f;
			double num14 = 0.0;
			double num15 = 0.0;
			for (int m = 0; m < pointsInternal2.Count; m++)
			{
				num15 += Math.Abs(pointsInternal2[m].YValue);
			}
			num6 = num2 + (double)l * num3 + num3 / 2.0;
			for (int n = 0; n < pointsInternal2.Count; n++)
			{
				if (pointsInternal2[n].YValue != 0.0)
				{
					Class750 dataLabelsInternal = pointsInternal2.method_0(n).DataLabelsInternal;
					float scaleWidth = ((!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f));
					double percent = ((num15 == 0.0) ? 0.01 : (Math.Abs(pointsInternal2[n].YValue) / num15));
					SizeF sizeF = smethod_42(g, chart.NSeriesInternal, index, n, percent, scaleWidth, scaleHeight, 0.0, renderContext);
					num14 = smethod_39(pointsInternal2[n].YValue, num15);
					double num16 = (360.0 - num13 - num14 / 2.0) * Math.PI / 180.0;
					double num17 = num6 * Math.Cos(num16);
					double num18 = num6 * Math.Sin(num16);
					num17 = num4 + num17;
					num18 = num5 - num18;
					num17 -= (double)(sizeF.Width / 2f);
					num18 -= (double)(sizeF.Height / 2f);
					if (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto)
					{
						dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_3(num17), Struct41.smethod_3(num18), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
						dataLabelsInternal.ChartFrameInternal.method_6();
						num17 = dataLabelsInternal.ChartFrameInternal.rectangle_0.X;
						num18 = dataLabelsInternal.ChartFrameInternal.rectangle_0.Y;
					}
					RectangleF rect4 = new RectangleF((float)num17, (float)num18, sizeF.Width, sizeF.Height);
					smethod_43(g, chart, index, n, percent, rect4, 0.0, renderContext);
					num13 += num14;
				}
			}
		}
	}

	private static void smethod_12(Interface32 g, Class740 chart, Rectangle rect, IList list, Class784 renderContext)
	{
		double num = 0.15000000596046448;
		Class759 @class = (Class759)list[0];
		int angleOfFirstSlice = @class.AngleOfFirstSlice;
		int doughnutHoleSize = @class.DoughnutHoleSize;
		double num2 = (double)rect.Width / 2.0;
		double num3 = num * num2;
		num2 -= num3;
		double num4 = num2 * (double)doughnutHoleSize / 100.0;
		double num5 = (num2 - num4) / (double)list.Count;
		double num6 = (double)rect.X + (double)rect.Width / 2.0;
		double num7 = (double)rect.Y + (double)rect.Height / 2.0;
		double num8 = num4;
		RectangleF empty = RectangleF.Empty;
		empty.X = (float)(num6 - num8);
		empty.Y = (float)(num7 - num8);
		empty.Width = (float)(2.0 * num8);
		empty.Height = (float)(2.0 * num8);
		for (int i = 0; i < list.Count; i++)
		{
			Class759 class2 = (Class759)list[i];
			_ = class2.Index;
			double num9 = 0.0;
			Class747 pointsInternal = class2.PointsInternal;
			for (int j = 0; j < pointsInternal.Count; j++)
			{
				num9 += Math.Abs(pointsInternal[j].YValue);
			}
			double num10 = (float)angleOfFirstSlice - 90f;
			double num11 = 0.0;
			_ = pointsInternal.Count;
			for (int k = 0; k < pointsInternal.Count; k++)
			{
				Class748 class3 = pointsInternal.method_0(k);
				if (pointsInternal[k].YValue != 0.0)
				{
					num11 = smethod_39(pointsInternal[k].YValue, num9);
					if (num11 == 0.0)
					{
						num11 = 0.001;
					}
					if (i == list.Count - 1)
					{
						double num12 = (360.0 - num10 - num11 / 2.0) * Math.PI / 180.0;
						double num13 = num3 * Math.Cos(num12);
						double num14 = num3 * Math.Sin(num12);
						num6 = (double)rect.X + (double)rect.Width / 2.0 + num13;
						num7 = (double)rect.Y + (double)rect.Height / 2.0 - num14;
						empty.X = (float)(num6 - num8);
						empty.Y = (float)(num7 - num8);
						empty.Width = (float)(2.0 * num8);
						empty.Height = (float)(2.0 * num8);
					}
					GraphicsPath graphicsPath = new GraphicsPath();
					RectangleF rect2 = Struct41.smethod_27(empty);
					graphicsPath.AddArc(rect2, (float)num10, (float)num11);
					double num15 = (360.0 - num10 - num11) * Math.PI / 180.0;
					double num16 = num8 * Math.Cos(num15);
					double num17 = num8 * Math.Sin(num15);
					num16 = num6 + num16;
					num17 = num7 - num17;
					PointF pt = new PointF((float)num16, (float)num17);
					num16 = (num8 + num5) * Math.Cos(num15);
					num17 = (num8 + num5) * Math.Sin(num15);
					num16 = num6 + num16;
					num17 = num7 - num17;
					PointF pt2 = new PointF((float)num16, (float)num17);
					graphicsPath.AddLine(pt, pt2);
					RectangleF rect3 = Struct41.smethod_27(empty);
					rect3.X -= (float)num5;
					rect3.Y -= (float)num5;
					rect3.Width += 2f * (float)num5;
					rect3.Height += 2f * (float)num5;
					graphicsPath.AddArc(rect3, (float)num10, (float)num11);
					num15 = (360.0 - num10) * Math.PI / 180.0;
					num16 = num8 * Math.Cos(num15);
					num17 = num8 * Math.Sin(num15);
					num16 = num6 + num16;
					num17 = num7 - num17;
					PointF pt3 = new PointF((float)num16, (float)num17);
					num16 = (num8 + num5) * Math.Cos(num15);
					num17 = (num8 + num5) * Math.Sin(num15);
					num16 = num6 + num16;
					num17 = num7 - num17;
					PointF pt4 = new PointF((float)num16, (float)num17);
					graphicsPath.AddLine(pt4, pt3);
					class3.AreaInternal.method_6(graphicsPath);
					class3.BorderInternal.method_8(graphicsPath);
					num10 += num11;
				}
			}
			num8 += num5;
			empty.X -= (float)num5;
			empty.Y -= (float)num5;
			empty.Width += 2f * (float)num5;
			empty.Height += 2f * (float)num5;
		}
		num6 = (double)rect.X + (double)rect.Width / 2.0;
		num7 = (double)rect.Y + (double)rect.Height / 2.0;
		float scaleHeight = chart.Height;
		for (int l = 0; l < list.Count; l++)
		{
			Class759 class4 = (Class759)list[l];
			int index = class4.Index;
			Class747 pointsInternal2 = class4.PointsInternal;
			double num18 = (float)angleOfFirstSlice - 90f;
			double num19 = 0.0;
			double num20 = 0.0;
			for (int m = 0; m < pointsInternal2.Count; m++)
			{
				num20 += Math.Abs(pointsInternal2[m].YValue);
			}
			num8 = num4 + (double)l * num5 + num5 / 2.0;
			for (int n = 0; n < pointsInternal2.Count; n++)
			{
				if (pointsInternal2[n].YValue != 0.0)
				{
					Class750 dataLabelsInternal = pointsInternal2.method_0(n).DataLabelsInternal;
					float scaleWidth = ((!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f));
					double percent = ((num20 == 0.0) ? 0.01 : (Math.Abs(pointsInternal2[n].YValue) / num20));
					SizeF sizeF = smethod_42(g, chart.NSeriesInternal, index, n, percent, scaleWidth, scaleHeight, 0.0, renderContext);
					num19 = smethod_39(pointsInternal2[n].YValue, num20);
					if (l == list.Count - 1)
					{
						double num21 = (360.0 - num18 - num19 / 2.0) * Math.PI / 180.0;
						double num22 = num3 * Math.Cos(num21);
						double num23 = num3 * Math.Sin(num21);
						num6 = (double)rect.X + (double)rect.Width / 2.0 + num22;
						num7 = (double)rect.Y + (double)rect.Height / 2.0 - num23;
					}
					double num24 = (360.0 - num18 - num19 / 2.0) * Math.PI / 180.0;
					double num25 = num8 * Math.Cos(num24);
					double num26 = num8 * Math.Sin(num24);
					num25 = num6 + num25;
					num26 = num7 - num26;
					num25 -= (double)(sizeF.Width / 2f);
					num26 -= (double)(sizeF.Height / 2f);
					if (!dataLabelsInternal.ChartFrameInternal.IsXAuto || !dataLabelsInternal.ChartFrameInternal.IsYAuto)
					{
						dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_3(num25), Struct41.smethod_3(num26), Struct41.smethod_3(sizeF.Width), Struct41.smethod_3(sizeF.Height));
						dataLabelsInternal.ChartFrameInternal.method_6();
						num25 = dataLabelsInternal.ChartFrameInternal.rectangle_0.X;
						num26 = dataLabelsInternal.ChartFrameInternal.rectangle_0.Y;
					}
					RectangleF rect4 = new RectangleF((float)num25, (float)num26, sizeF.Width, sizeF.Height);
					smethod_43(g, chart, index, n, percent, rect4, 0.0, renderContext);
					num18 += num19;
				}
			}
		}
	}

	internal static void smethod_13(Class740 chart, ref Rectangle rect, Class759 aSeries)
	{
		if (rect.Width <= 0 || rect.Height <= 0 || !aSeries.IsPieSeries || !chart.PlotAreaInternal.IsSizeAuto)
		{
			return;
		}
		rect.X += 4;
		rect.Y += 4;
		rect.Width -= 8;
		rect.Height -= 8;
		bool flag = false;
		if (aSeries.Type != ChartType.Doughnut && aSeries.Type != ChartType.ExplodedDoughnut)
		{
			if (aSeries.IsDataLabelsShown && (aSeries.DataLabelsInternal.LabelPosition == LegendDataLabelPosition.OutsideEnd || aSeries.DataLabelsInternal.LabelPosition == LegendDataLabelPosition.BestFit))
			{
				flag = true;
			}
		}
		else if (aSeries.IsDataLabelsShown)
		{
			flag = true;
		}
		if (flag)
		{
			int num = rect.Width;
			if (rect.Width > rect.Height)
			{
				num = rect.Height;
			}
			int num2 = Struct41.smethod_4((float)num / 100f * 7f);
			rect.X += num2;
			rect.Y += num2;
			rect.Width -= 2 * num2;
			rect.Height -= 2 * num2;
		}
		int num3 = 10;
		if (rect.Width < 10)
		{
			rect.Width = num3;
		}
		if (rect.Height < num3)
		{
			rect.Height = num3;
		}
	}

	internal static void smethod_14(Interface32 g, Class740 chart, ref Rectangle rectPlot, Class759 aSeries, Class784 renderContext)
	{
		smethod_17(g, chart, rectPlot, aSeries, renderContext);
		ArrayList arrayList;
		if (aSeries.Chart.PlotAreaInternal.IsXAuto)
		{
			float num = 0f;
			num = smethod_15(rectPlot, aSeries);
			if (num > (float)rectPlot.Width * 0.3f)
			{
				num = (float)rectPlot.Width * 0.3f;
			}
			RectangleF rect = default(RectangleF);
			rect.X = (float)rectPlot.X + num;
			rect.Width = (float)rectPlot.Width - 2f * num;
			rect.Y = (float)rectPlot.Y + num;
			rect.Height = (float)rectPlot.Height - 2f * num;
			smethod_18(g, chart, rect, aSeries, renderContext);
			arrayList = smethod_34(aSeries, rectPlot);
			smethod_17(g, chart, rectPlot, aSeries, renderContext);
			float offset = 0f;
			for (int i = 0; i < aSeries.PointsInternal.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < arrayList.Count; j++)
				{
					ArrayList arrayList2 = (ArrayList)arrayList[j];
					for (int k = 0; k < arrayList2.Count; k++)
					{
						if ((int)arrayList2[k] == i)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					Class748 @class = aSeries.PointsInternal.method_0(i);
					Class750 dataLabelsInternal = @class.DataLabelsInternal;
					if (dataLabelsInternal.LabelPosition == LegendDataLabelPosition.BestFit || dataLabelsInternal.LabelPosition == LegendDataLabelPosition.OutsideEnd)
					{
						smethod_37(rectPlot, dataLabelsInternal.rectangleF_0, ref offset);
					}
				}
			}
			if (offset > (float)rectPlot.Width * 0.3f)
			{
				offset = (float)rectPlot.Width * 0.3f;
			}
			rectPlot.X += (int)offset;
			rectPlot.Width -= (int)(offset * 2f);
			rectPlot.Y += (int)offset;
			rectPlot.Height -= (int)(offset * 2f);
		}
		smethod_17(g, chart, rectPlot, aSeries, renderContext);
		smethod_24(aSeries, rectPlot.Width / 2);
		arrayList = smethod_34(aSeries, rectPlot);
		for (int l = 0; l < 10; l++)
		{
			if (arrayList.Count <= 0)
			{
				break;
			}
			smethod_25(aSeries, rectPlot.Width / 2, arrayList);
			ArrayList arrayList3 = new ArrayList();
			for (int m = 0; m < arrayList.Count; m++)
			{
				ArrayList arrayList4 = (ArrayList)arrayList[m];
				ArrayList arrayList5 = new ArrayList();
				for (int n = 0; n < arrayList4.Count; n++)
				{
					arrayList5.Add(arrayList4[n]);
				}
				arrayList3.Add(arrayList5);
			}
			ArrayList arrayList6 = new ArrayList();
			smethod_27(aSeries, arrayList, rectPlot, rectPlot, arrayList6);
			smethod_26(aSeries, rectPlot.Width / 2, arrayList3, arrayList6);
			arrayList = smethod_34(aSeries, rectPlot);
			int num2 = 0;
			foreach (ArrayList item in arrayList)
			{
				num2 += item.Count;
			}
			if (arrayList6.Count == num2)
			{
				break;
			}
		}
	}

	internal static float smethod_15(Rectangle rectPlot, Class759 aSeries)
	{
		return smethod_16(Struct41.smethod_23(rectPlot), aSeries);
	}

	internal static float smethod_16(RectangleF rectPlot, Class759 aSeries)
	{
		ArrayList arrayList = smethod_35(aSeries, rectPlot);
		float offset = 0f;
		for (int i = 0; i < aSeries.PointsInternal.Count; i++)
		{
			bool flag = false;
			for (int j = 0; j < arrayList.Count; j++)
			{
				ArrayList arrayList2 = (ArrayList)arrayList[j];
				for (int k = 0; k < arrayList2.Count; k++)
				{
					if ((int)arrayList2[k] == i)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (!flag)
			{
				Class748 @class = aSeries.PointsInternal.method_0(i);
				Class750 dataLabelsInternal = @class.DataLabelsInternal;
				if (dataLabelsInternal.LabelPosition == LegendDataLabelPosition.BestFit || dataLabelsInternal.LabelPosition == LegendDataLabelPosition.OutsideEnd)
				{
					smethod_38(rectPlot, dataLabelsInternal.rectangleF_0, ref offset);
				}
			}
		}
		return offset;
	}

	internal static void smethod_17(Interface32 g, Class740 chart, Rectangle rect, Class759 aSeries, Class784 renderContext)
	{
		RectangleF rect2 = new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
		smethod_18(g, chart, rect2, aSeries, renderContext);
	}

	internal static void smethod_18(Interface32 g, Class740 chart, RectangleF rect, Class759 aSeries, Class784 renderContext)
	{
		int index = aSeries.Index;
		double num = 0.0;
		Class747 pointsInternal = aSeries.PointsInternal;
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			num += Math.Abs(pointsInternal[i].YValue);
		}
		double num2 = (double)rect.X + (double)rect.Width / 2.0;
		double num3 = (double)rect.Y + (double)rect.Height / 2.0;
		double num4 = 90f - (float)aSeries.AngleOfFirstSlice;
		double num5 = 0.0;
		double num6 = 0.0 - num4;
		float scaleHeight = chart.Height;
		for (int j = 0; j < pointsInternal.Count; j++)
		{
			Class748 @class = pointsInternal.method_0(j);
			Class750 dataLabelsInternal = @class.DataLabelsInternal;
			float scaleWidth = ((!dataLabelsInternal.ChartFrameInternal.BorderInternal.IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f));
			double percent = ((num == 0.0) ? 0.01 : (Math.Abs(pointsInternal[j].YValue) / num));
			SizeF dataLabelsSize = smethod_42(g, chart.NSeriesInternal, index, j, percent, scaleWidth, scaleHeight, 0.0, renderContext);
			num5 = smethod_39(pointsInternal[j].YValue, num);
			double num7 = (num4 - num5 / 2.0) % 360.0;
			double num8 = (dataLabelsInternal.double_0 = num7 * Math.PI / 180.0);
			double num9 = (float)@class.Explosion / 100f;
			double num10 = ((chart.Type != ChartType.Pie) ? ((double)rect.Width / 2.0 / (1.0 + num9)) : ((double)rect.Width / 2.0));
			double num11 = num10 * num9;
			double x = 0.0;
			double y = 0.0;
			bool flag = false;
			LegendDataLabelPosition legendDataLabelPosition = dataLabelsInternal.LabelPosition;
			Class746 chartFrameInternal = dataLabelsInternal.ChartFrameInternal;
			if (legendDataLabelPosition == LegendDataLabelPosition.BestFit && (!chartFrameInternal.IsXAuto || !chartFrameInternal.IsYAuto))
			{
				legendDataLabelPosition = LegendDataLabelPosition.OutsideEnd;
			}
			while (!flag)
			{
				double num12;
				switch (legendDataLabelPosition)
				{
				case LegendDataLabelPosition.Center:
					num12 = num11 + num10 * 0.5;
					x = num12 * Math.Cos(num8);
					y = num12 * Math.Sin(num8);
					x -= (double)(dataLabelsSize.Width / 2f);
					y += (double)(dataLabelsSize.Height / 2f);
					flag = true;
					continue;
				case LegendDataLabelPosition.InsideEnd:
					num12 = num11 + num10 * 0.96;
					x = num12 * Math.Cos(num8);
					y = num12 * Math.Sin(num8);
					smethod_20(ref x, ref y, num7, dataLabelsSize);
					flag = true;
					continue;
				case LegendDataLabelPosition.OutsideEnd:
					num12 = num11 + num10 * 1.04;
					x = num12 * Math.Cos(num8);
					y = num12 * Math.Sin(num8);
					smethod_19(ref x, ref y, num7, dataLabelsSize);
					flag = true;
					continue;
				}
				num12 = num11 + num10 * 0.96;
				x = num12 * Math.Cos(num8);
				y = num12 * Math.Sin(num8);
				smethod_20(ref x, ref y, num7, dataLabelsSize);
				RectangleF rectDl = new RectangleF((float)x, (float)y, dataLabelsSize.Width, dataLabelsSize.Height);
				if (smethod_21(g, (float)num6, (float)num4, (float)num5, (float)num10, (float)num11, rectDl, dataLabelsInternal))
				{
					flag = true;
					continue;
				}
				PointF pointF = smethod_22(g, (float)num6, (float)num4, (float)num5, (float)num10, (float)num11, dataLabelsSize, dataLabelsInternal);
				if (pointF.IsEmpty)
				{
					flag = false;
					legendDataLabelPosition = LegendDataLabelPosition.OutsideEnd;
				}
				else
				{
					x = pointF.X;
					y = pointF.Y;
					flag = true;
				}
			}
			x = num2 + x;
			y = num3 - y;
			if (!chartFrameInternal.IsXAuto || !chartFrameInternal.IsYAuto)
			{
				chartFrameInternal.rectangle_1 = new Rectangle(Struct41.smethod_3(x), Struct41.smethod_3(y), Struct41.smethod_3(dataLabelsSize.Width), Struct41.smethod_3(dataLabelsSize.Height));
				chartFrameInternal.method_6();
				x = chartFrameInternal.rectangle_0.X;
				y = chartFrameInternal.rectangle_0.Y;
			}
			RectangleF rectangleF = new RectangleF((float)x, (float)y, dataLabelsSize.Width, dataLabelsSize.Height);
			num6 += num5;
			num4 -= num5;
			dataLabelsInternal.rectangleF_0 = rectangleF;
			dataLabelsInternal.rectangleF_1 = rectangleF;
		}
	}

	private static void smethod_19(ref double x, ref double y, double dlAngle, SizeF dataLabelsSize)
	{
		if (dlAngle <= -67.5 && dlAngle >= -112.5)
		{
			x -= (-67.5 - dlAngle) * (double)dataLabelsSize.Width / 45.0;
		}
		else if (dlAngle <= -112.5 && dlAngle >= -247.5)
		{
			x -= dataLabelsSize.Width;
		}
		else if (dlAngle <= -247.5 && dlAngle >= -292.5)
		{
			x -= (dlAngle - -292.5) * (double)dataLabelsSize.Width / 45.0;
		}
		else if (dlAngle >= 67.5 && dlAngle <= 90.0)
		{
			x -= (dlAngle - 67.5) * (double)dataLabelsSize.Width / 45.0;
		}
		if (dlAngle <= -135.0 && dlAngle >= -225.0)
		{
			y += (-135.0 - dlAngle) * (double)dataLabelsSize.Height / 90.0;
		}
		else if ((dlAngle <= -225.0 && dlAngle >= -315.0) || (dlAngle <= 90.0 && dlAngle >= 45.0))
		{
			y += dataLabelsSize.Height;
		}
		else if (dlAngle < -315.0 && dlAngle >= -360.0)
		{
			y += (dlAngle - -405.0) * (double)dataLabelsSize.Height / 90.0;
		}
		else if (dlAngle <= 45.0 && dlAngle >= -45.0)
		{
			y += (dlAngle - -45.0) * (double)dataLabelsSize.Height / 90.0;
		}
	}

	private static void smethod_20(ref double x, ref double y, double dlAngle, SizeF dataLabelsSize)
	{
		if (dlAngle >= -112.5 && dlAngle <= -67.5)
		{
			x -= (dlAngle - -112.5) * (double)dataLabelsSize.Width / 45.0;
		}
		else if (dlAngle >= -292.5 && dlAngle <= -247.5)
		{
			x -= (-247.5 - dlAngle) * (double)dataLabelsSize.Width / 45.0;
		}
		else if (dlAngle > 67.5 && dlAngle <= 90.0)
		{
			x -= (112.5 - dlAngle) * (double)dataLabelsSize.Width / 45.0;
		}
		else if ((dlAngle >= -67.5 && dlAngle <= 67.5) || dlAngle <= -292.5)
		{
			x -= dataLabelsSize.Width;
		}
		if (dlAngle <= 22.5 && dlAngle >= -22.5)
		{
			y += (22.5 - dlAngle) * (double)dataLabelsSize.Height / 45.0;
		}
		else if (dlAngle <= -337.5)
		{
			y += (-337.5 - dlAngle) * (double)dataLabelsSize.Height / 45.0;
		}
		else if (dlAngle >= -202.5 && dlAngle <= -157.5)
		{
			y += (dlAngle - -202.5) * (double)dataLabelsSize.Height / 45.0;
		}
		else if (dlAngle >= -157.5 && dlAngle <= -22.5)
		{
			y += dataLabelsSize.Height;
		}
	}

	private static bool smethod_21(Interface32 g, float drawingStartAngle, float startAngle, float sweepAngle, float r, float explodeLength, RectangleF rectDl, Class750 dataLabels)
	{
		Class740 chart = dataLabels.ChartFrameInternal.Chart;
		GraphicsPath graphicsPath = new GraphicsPath();
		RectangleF rect = new RectangleF(-chart.Width / 2, -chart.Height / 2, chart.Width, chart.Height);
		graphicsPath.AddRectangle(rect);
		GraphicsPath graphicsPath2 = new GraphicsPath();
		double num = (double)(startAngle - sweepAngle / 2f) * Math.PI / 180.0 % (Math.PI * 2.0);
		double num2 = (double)explodeLength * Math.Cos(num);
		double num3 = (double)explodeLength * Math.Sin(num);
		RectangleF rectangleF = new RectangleF((float)num2 - r, (float)num3 + r, 2f * r, 2f * r);
		graphicsPath2.AddPie(rectangleF.X, 0f - rectangleF.Y, rectangleF.Width, rectangleF.Height, drawingStartAngle, sweepAngle);
		Region region = new Region(graphicsPath);
		region.Xor(graphicsPath2);
		if (dataLabels.ChartFrameInternal.BorderInternal.Formatting == FillType.NoFill || dataLabels.ChartFrameInternal.BorderInternal.Color.IsEmpty)
		{
			rectDl.Inflate(-5f, -5f);
		}
		region.Intersect(new RectangleF(rectDl.X, 0f - rectDl.Y, rectDl.Width, rectDl.Height));
		if (g.GraphicsTools.imethod_1(region))
		{
			return true;
		}
		return false;
	}

	private static PointF smethod_22(Interface32 g, float drawingStartAngle, float startAngle, float sweepAngle, float r, float explodeLength, SizeF dataLabelsSize, Class750 dataLabels)
	{
		float num = startAngle - sweepAngle / 2f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = -0.5f;
		bool flag = false;
		if ((num > -90f && num < 0f) || (num >= -270f && num < -180f))
		{
			flag = false;
			float num5 = num;
			while (num5 > startAngle - sweepAngle)
			{
				num5 += num4;
				RectangleF rectDl = smethod_23(r, num5, dataLabelsSize, startAngle, sweepAngle, explodeLength);
				num2 += num4;
				if (smethod_21(g, drawingStartAngle, startAngle, sweepAngle, r, explodeLength, rectDl, dataLabels))
				{
					num3 += num4;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					return smethod_23(r, num + num2 - num3 / 2f, dataLabelsSize, startAngle, sweepAngle, explodeLength).Location;
				}
			}
			if (flag)
			{
				return smethod_23(r, num + num2 - num3 / 2f, dataLabelsSize, startAngle, sweepAngle, explodeLength).Location;
			}
			flag = false;
			num5 = num;
			num2 = 0f;
			num3 = 0f;
			while (num5 < startAngle)
			{
				num5 -= num4;
				RectangleF rectDl2 = smethod_23(r, num5, dataLabelsSize, startAngle, sweepAngle, explodeLength);
				num2 -= num4;
				if (smethod_21(g, drawingStartAngle, startAngle, sweepAngle, r, explodeLength, rectDl2, dataLabels))
				{
					num3 -= num4;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					return smethod_23(r, num + num2 - num3 / 2f, dataLabelsSize, startAngle, sweepAngle, explodeLength).Location;
				}
			}
			if (flag)
			{
				return smethod_23(r, num + num2 - num3 / 2f, dataLabelsSize, startAngle, sweepAngle, explodeLength).Location;
			}
		}
		else
		{
			flag = false;
			float num6 = num;
			while (num6 < startAngle)
			{
				num6 -= num4;
				RectangleF rectDl3 = smethod_23(r, num6, dataLabelsSize, startAngle, sweepAngle, explodeLength);
				num2 -= num4;
				if (smethod_21(g, drawingStartAngle, startAngle, sweepAngle, r, explodeLength, rectDl3, dataLabels))
				{
					num3 -= num4;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					return smethod_23(r, num + num2 - num3 / 2f, dataLabelsSize, startAngle, sweepAngle, explodeLength).Location;
				}
			}
			if (flag)
			{
				return smethod_23(r, num + num2 - num3 / 2f, dataLabelsSize, startAngle, sweepAngle, explodeLength).Location;
			}
			flag = false;
			num6 = num;
			num2 = 0f;
			num3 = 0f;
			while (num6 > startAngle - sweepAngle)
			{
				num6 += num4;
				RectangleF rectDl4 = smethod_23(r, num6, dataLabelsSize, startAngle, sweepAngle, explodeLength);
				num2 += num4;
				if (smethod_21(g, drawingStartAngle, startAngle, sweepAngle, r, explodeLength, rectDl4, dataLabels))
				{
					num3 += num4;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					return smethod_23(r, num + num2 - num3 / 2f, dataLabelsSize, startAngle, sweepAngle, explodeLength).Location;
				}
			}
			if (flag)
			{
				return smethod_23(r, num + num2 - num3 / 2f, dataLabelsSize, startAngle, sweepAngle, explodeLength).Location;
			}
		}
		return PointF.Empty;
	}

	private static RectangleF smethod_23(double r, double angle, SizeF dataLabelsSize, float startAngle, float sweepAngle, float explodeLength)
	{
		angle %= 360.0;
		double num = angle * Math.PI / 180.0;
		r -= r * 0.03;
		double num2 = r * Math.Cos(num);
		double num3 = r * Math.Sin(num);
		if ((angle < 90.0 && angle > -90.0) || angle < -270.0)
		{
			num2 -= (double)dataLabelsSize.Width;
		}
		if (angle > -180.0 && angle < 0.0)
		{
			num3 += (double)dataLabelsSize.Height;
		}
		num = (double)(startAngle - sweepAngle / 2f) * Math.PI / 180.0 % (Math.PI * 2.0);
		double num4 = (double)explodeLength * Math.Cos(num);
		double num5 = (double)explodeLength * Math.Sin(num);
		num2 += num4;
		num3 += num5;
		return new RectangleF((float)num2, (float)num3, dataLabelsSize.Width, dataLabelsSize.Height);
	}

	private static void smethod_24(Class759 aSeries, double r)
	{
		Class747 pointsInternal = aSeries.PointsInternal;
		double num = r * (double)float_0;
		ArrayList arrayList = new ArrayList();
		if (!aSeries.HasLeaderLines)
		{
			return;
		}
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			Interface10 chartFrame = pointsInternal[i].DataLabels.ChartFrame;
			if (chartFrame.IsXAuto && chartFrame.IsYAuto)
			{
				continue;
			}
			arrayList.Add(i);
			Class748 @class = pointsInternal.method_0(i);
			Class750 dataLabelsInternal = @class.DataLabelsInternal;
			dataLabelsInternal.bool_8 = true;
			if (dataLabelsInternal.pointF_1.IsEmpty)
			{
				if (!dataLabelsInternal.IsPositionToLeft)
				{
					dataLabelsInternal.pointF_2 = new PointF(dataLabelsInternal.rectangleF_0.X, dataLabelsInternal.rectangleF_0.Y + dataLabelsInternal.rectangleF_0.Height / 2f);
					dataLabelsInternal.pointF_1 = new PointF(dataLabelsInternal.rectangleF_0.X - (float)num, dataLabelsInternal.pointF_2.Y);
				}
				else
				{
					dataLabelsInternal.pointF_2 = new PointF(dataLabelsInternal.rectangleF_0.Right, dataLabelsInternal.rectangleF_0.Top + dataLabelsInternal.rectangleF_0.Height / 2f);
					dataLabelsInternal.pointF_1 = new PointF(dataLabelsInternal.rectangleF_0.Right + (float)num, dataLabelsInternal.pointF_2.Y);
				}
			}
		}
	}

	private static void smethod_25(Class759 aSeries, double r, ArrayList listCross)
	{
		double num = r * (double)float_0;
		double num2 = num;
		for (int i = 0; i < listCross.Count; i++)
		{
			ArrayList arrayList = (ArrayList)listCross[i];
			for (int j = 0; j < arrayList.Count; j++)
			{
				Class748 @class = aSeries.PointsInternal.method_0((int)arrayList[j]);
				Class750 dataLabelsInternal = @class.DataLabelsInternal;
				dataLabelsInternal.bool_8 = true;
				if (dataLabelsInternal.pointF_1.IsEmpty)
				{
					if (!dataLabelsInternal.IsPositionToLeft)
					{
						dataLabelsInternal.rectangleF_0.X = (float)((double)dataLabelsInternal.pointF_0.X + num + num2 * Math.Abs(Math.Cos(dataLabelsInternal.double_0)));
					}
					else
					{
						dataLabelsInternal.rectangleF_0.X = (float)((double)(dataLabelsInternal.pointF_0.X - dataLabelsInternal.rectangleF_0.Width) - num - num2 * Math.Abs(Math.Cos(dataLabelsInternal.double_0)));
					}
					if (dataLabelsInternal.IsPositionToBottom)
					{
						dataLabelsInternal.rectangleF_0.Y = (float)((double)dataLabelsInternal.pointF_0.Y + num2 * Math.Abs(Math.Sin(dataLabelsInternal.double_0)) - (double)(dataLabelsInternal.rectangleF_0.Height / 2f));
					}
					else
					{
						dataLabelsInternal.rectangleF_0.Y = (float)((double)dataLabelsInternal.pointF_0.Y - num2 * Math.Abs(Math.Sin(dataLabelsInternal.double_0)) - (double)(dataLabelsInternal.rectangleF_0.Height / 2f));
					}
					if (!dataLabelsInternal.IsPositionToLeft)
					{
						dataLabelsInternal.pointF_2 = new PointF(dataLabelsInternal.rectangleF_0.X, dataLabelsInternal.rectangleF_0.Y + dataLabelsInternal.rectangleF_0.Height / 2f);
						dataLabelsInternal.pointF_1 = new PointF(dataLabelsInternal.rectangleF_0.X - (float)num, dataLabelsInternal.pointF_2.Y);
					}
					else
					{
						dataLabelsInternal.pointF_2 = new PointF(dataLabelsInternal.rectangleF_0.Right, dataLabelsInternal.rectangleF_0.Top + dataLabelsInternal.rectangleF_0.Height / 2f);
						dataLabelsInternal.pointF_1 = new PointF(dataLabelsInternal.rectangleF_0.Right + (float)num, dataLabelsInternal.pointF_2.Y);
					}
				}
			}
		}
	}

	private static void smethod_26(Class759 aSeries, double r, ArrayList listCross, ArrayList listCancel)
	{
		double num = r * (double)float_0;
		for (int i = 0; i < listCross.Count; i++)
		{
			ArrayList arrayList = (ArrayList)listCross[i];
			for (int j = 0; j < arrayList.Count; j++)
			{
				int k;
				for (k = 0; k < listCancel.Count && (int)arrayList[j] != (int)listCancel[k]; k++)
				{
				}
				if (k == listCancel.Count)
				{
					Class748 @class = aSeries.PointsInternal.method_0((int)arrayList[j]);
					Class750 dataLabelsInternal = @class.DataLabelsInternal;
					if (!dataLabelsInternal.IsPositionToLeft)
					{
						dataLabelsInternal.pointF_2 = new PointF(dataLabelsInternal.rectangleF_0.X, dataLabelsInternal.rectangleF_0.Y + dataLabelsInternal.rectangleF_0.Height / 2f);
						dataLabelsInternal.pointF_1 = new PointF(dataLabelsInternal.rectangleF_0.X - (float)num, dataLabelsInternal.pointF_2.Y);
					}
					else
					{
						dataLabelsInternal.pointF_2 = new PointF(dataLabelsInternal.rectangleF_0.Right, dataLabelsInternal.rectangleF_0.Top + dataLabelsInternal.rectangleF_0.Height / 2f);
						dataLabelsInternal.pointF_1 = new PointF(dataLabelsInternal.rectangleF_0.Right + (float)num, dataLabelsInternal.pointF_2.Y);
					}
				}
			}
		}
	}

	private static void smethod_27(Class759 aSeries, ArrayList listCross, Rectangle maxRect, Rectangle plotRect, ArrayList listCancel)
	{
		for (int i = 0; i < listCross.Count; i++)
		{
			ArrayList list = (ArrayList)listCross[i];
			smethod_28(aSeries, list, maxRect, plotRect, listCancel);
		}
		for (int j = 0; j < listCancel.Count; j++)
		{
			Class750 dataLabelsInternal = aSeries.PointsInternal.method_0((int)listCancel[j]).DataLabelsInternal;
			dataLabelsInternal.rectangleF_0 = dataLabelsInternal.rectangleF_1;
			dataLabelsInternal.pointF_2 = PointF.Empty;
			dataLabelsInternal.pointF_1 = PointF.Empty;
		}
	}

	private static void smethod_28(Class759 aSeries, ArrayList list, Rectangle maxRect, Rectangle plotRect, ArrayList listCancel)
	{
		Class740 chart = aSeries.Chart;
		if (list.Count < 1)
		{
			return;
		}
		float num = float_1;
		Class747 pointsInternal = aSeries.PointsInternal;
		int num2 = (int)list[0];
		Class750 dataLabelsInternal = pointsInternal.method_0(num2).DataLabelsInternal;
		list.RemoveAt(0);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(num2);
		smethod_29(aSeries, arrayList, list, dataLabelsInternal);
		switch (dataLabelsInternal.MoveType)
		{
		case 1:
		{
			if (aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal.double_0 >= 0.0)
			{
				smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: true);
			}
			else
			{
				smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: true);
			}
			Class750 @class = aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal;
			Class750 class2 = (((int)arrayList[0] != pointsInternal.Count - 1) ? pointsInternal.method_0((int)arrayList[0] + 1).DataLabelsInternal : pointsInternal.method_0(0).DataLabelsInternal);
			if (smethod_33(@class.rectangleF_0, class2.rectangleF_0, num))
			{
				float num9 = Math.Abs(class2.rectangleF_0.Y - @class.rectangleF_0.Bottom);
				float num10 = (num9 + num) / 2f;
				if (class2.bool_8)
				{
					@class.rectangleF_0.Y -= num10;
					class2.rectangleF_0.Y += num10;
				}
				else
				{
					@class.rectangleF_0.Y -= num9 + num;
				}
			}
			for (int m = 1; m < arrayList.Count; m++)
			{
				Class750 dataLabelsInternal5 = aSeries.PointsInternal.method_0((int)arrayList[m]).DataLabelsInternal;
				float num11 = Math.Abs(@class.rectangleF_0.Y - dataLabelsInternal5.rectangleF_0.Bottom);
				dataLabelsInternal5.rectangleF_0.Y -= num11 + num;
				@class = dataLabelsInternal5;
			}
			Class750 dataLabelsInternal3 = aSeries.PointsInternal.method_0((int)arrayList[arrayList.Count - 1]).DataLabelsInternal;
			if (dataLabelsInternal3.rectangleF_0.Y < 0f)
			{
				for (int n = 0; n < arrayList.Count; n++)
				{
					listCancel.Add((int)arrayList[n]);
				}
			}
			break;
		}
		case 2:
		{
			smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: false);
			Class750 @class = aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal;
			Class750 class2 = (((int)arrayList[0] != 0) ? pointsInternal.method_0((int)arrayList[0] - 1).DataLabelsInternal : pointsInternal.method_0(pointsInternal.Count - 1).DataLabelsInternal);
			if (smethod_33(@class.rectangleF_0, class2.rectangleF_0, num))
			{
				float num12 = Math.Abs(class2.rectangleF_0.Bottom - @class.rectangleF_0.Y);
				float num13 = (num12 + num) / 2f;
				if (class2.bool_8)
				{
					@class.rectangleF_0.Y += num13;
					class2.rectangleF_0.Y -= num13;
				}
				else
				{
					@class.rectangleF_0.Y += num12 + num;
				}
			}
			for (int num14 = 1; num14 < arrayList.Count; num14++)
			{
				Class750 dataLabelsInternal6 = aSeries.PointsInternal.method_0((int)arrayList[num14]).DataLabelsInternal;
				float num15 = Math.Abs(@class.rectangleF_0.Bottom - dataLabelsInternal6.rectangleF_0.Y);
				dataLabelsInternal6.rectangleF_0.Y += num15 + num;
				@class = dataLabelsInternal6;
			}
			Class750 dataLabelsInternal3 = aSeries.PointsInternal.method_0((int)arrayList[arrayList.Count - 1]).DataLabelsInternal;
			if (dataLabelsInternal3.rectangleF_0.Y > (float)chart.Height)
			{
				for (int num16 = 0; num16 < arrayList.Count; num16++)
				{
					listCancel.Add((int)arrayList[num16]);
				}
			}
			break;
		}
		case 3:
		{
			smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: true);
			Class750 @class = aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal;
			Class750 class2 = (((int)arrayList[0] != pointsInternal.Count - 1) ? pointsInternal.method_0((int)arrayList[0] + 1).DataLabelsInternal : pointsInternal.method_0(0).DataLabelsInternal);
			if (smethod_33(@class.rectangleF_0, class2.rectangleF_0, num))
			{
				float num6 = Math.Abs(class2.rectangleF_0.Bottom - @class.rectangleF_0.Y);
				float num7 = (num6 + num) / 2f;
				if (class2.bool_8)
				{
					@class.rectangleF_0.Y += num7;
					class2.rectangleF_0.Y -= num7;
				}
				else
				{
					@class.rectangleF_0.Y += num6 + num;
				}
			}
			for (int k = 1; k < arrayList.Count; k++)
			{
				Class750 dataLabelsInternal4 = aSeries.PointsInternal.method_0((int)arrayList[k]).DataLabelsInternal;
				float num8 = Math.Abs(@class.rectangleF_0.Bottom - dataLabelsInternal4.rectangleF_0.Y);
				dataLabelsInternal4.rectangleF_0.Y += num8 + num;
				@class = dataLabelsInternal4;
			}
			Class750 dataLabelsInternal3 = aSeries.PointsInternal.method_0((int)arrayList[arrayList.Count - 1]).DataLabelsInternal;
			if (dataLabelsInternal3.rectangleF_0.Y > (float)chart.Height)
			{
				for (int l = 0; l < arrayList.Count; l++)
				{
					listCancel.Add((int)arrayList[l]);
				}
			}
			break;
		}
		case 4:
		{
			smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: false);
			Class750 @class = aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal;
			Class750 class2 = (((int)arrayList[0] != 0) ? pointsInternal.method_0((int)arrayList[0] - 1).DataLabelsInternal : pointsInternal.method_0(pointsInternal.Count - 1).DataLabelsInternal);
			if (smethod_33(@class.rectangleF_0, class2.rectangleF_0, num))
			{
				float num3 = Math.Abs(class2.rectangleF_0.Y - @class.rectangleF_0.Bottom);
				float num4 = (num3 + num) / 2f;
				if (class2.bool_8)
				{
					@class.rectangleF_0.Y -= num4;
					class2.rectangleF_0.Y += num4;
				}
				else
				{
					@class.rectangleF_0.Y -= num3 + num;
				}
			}
			for (int i = 1; i < arrayList.Count; i++)
			{
				Class750 dataLabelsInternal2 = aSeries.PointsInternal.method_0((int)arrayList[i]).DataLabelsInternal;
				float num5 = Math.Abs(@class.rectangleF_0.Y - dataLabelsInternal2.rectangleF_0.Bottom);
				dataLabelsInternal2.rectangleF_0.Y -= num5 + num;
				@class = dataLabelsInternal2;
			}
			Class750 dataLabelsInternal3 = aSeries.PointsInternal.method_0((int)arrayList[arrayList.Count - 1]).DataLabelsInternal;
			if (dataLabelsInternal3.rectangleF_0.Y < 0f)
			{
				for (int j = 0; j < arrayList.Count; j++)
				{
					listCancel.Add((int)arrayList[j]);
				}
			}
			break;
		}
		}
		smethod_28(aSeries, list, maxRect, plotRect, listCancel);
	}

	private static ArrayList smethod_29(Class759 aSeries, ArrayList listSame, ArrayList list, Class750 firstLabel)
	{
		for (int i = 0; i < list.Count; i++)
		{
			Class750 dataLabelsInternal = aSeries.PointsInternal.method_0((int)list[i]).DataLabelsInternal;
			if (dataLabelsInternal.MoveType == firstLabel.MoveType)
			{
				listSame.Add(list[i]);
				list.RemoveAt(i);
				i--;
			}
		}
		return listSame;
	}

	private static object[] smethod_30(Class759 aSeries, ArrayList list)
	{
		object[] array = new object[4]
		{
			new ArrayList(),
			new ArrayList(),
			new ArrayList(),
			new ArrayList()
		};
		for (int i = 0; i < list.Count; i++)
		{
			Class750 dataLabelsInternal = aSeries.PointsInternal.method_0((int)list[i]).DataLabelsInternal;
			switch (dataLabelsInternal.MoveType)
			{
			case 1:
				((ArrayList)array[0]).Add(list[i]);
				break;
			case 2:
				((ArrayList)array[0]).Add(list[i]);
				break;
			case 3:
				((ArrayList)array[0]).Add(list[i]);
				break;
			case 4:
				((ArrayList)array[0]).Add(list[i]);
				break;
			}
		}
		return array;
	}

	private static void smethod_31(Class759 aSeries, ArrayList list, Rectangle maxRect, Rectangle plotRect, ArrayList listCancel)
	{
		Class740 chart = aSeries.Chart;
		if (list.Count < 1)
		{
			return;
		}
		float num = float_1;
		Class747 pointsInternal = aSeries.PointsInternal;
		int num2 = (int)list[0];
		Class750 dataLabelsInternal = pointsInternal.method_0(num2).DataLabelsInternal;
		list.RemoveAt(0);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(num2);
		smethod_29(aSeries, arrayList, list, dataLabelsInternal);
		switch (dataLabelsInternal.MoveType)
		{
		case 1:
		{
			if (aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal.double_0 >= 0.0)
			{
				smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: true);
			}
			else
			{
				smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: true);
			}
			Class750 @class = aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal;
			Class750 class2 = (((int)arrayList[0] != pointsInternal.Count - 1) ? pointsInternal.method_0((int)arrayList[0] + 1).DataLabelsInternal : pointsInternal.method_0(0).DataLabelsInternal);
			if (smethod_33(@class.rectangleF_0, class2.rectangleF_0, num))
			{
				float num9 = Math.Abs(class2.rectangleF_0.Y - @class.rectangleF_0.Bottom);
				float num10 = (num9 + num) / 2f;
				if (class2.bool_8)
				{
					@class.rectangleF_0.Y -= num10;
					class2.rectangleF_0.Y += num10;
				}
				else
				{
					@class.rectangleF_0.Y -= num9 + num;
				}
			}
			for (int m = 1; m < arrayList.Count; m++)
			{
				Class750 dataLabelsInternal5 = aSeries.PointsInternal.method_0((int)arrayList[m]).DataLabelsInternal;
				float num11 = Math.Abs(@class.rectangleF_0.Y - dataLabelsInternal5.rectangleF_0.Bottom);
				dataLabelsInternal5.rectangleF_0.Y -= num11 + num;
				@class = dataLabelsInternal5;
			}
			Class750 dataLabelsInternal3 = aSeries.PointsInternal.method_0((int)arrayList[arrayList.Count - 1]).DataLabelsInternal;
			if (dataLabelsInternal3.rectangleF_0.Y < 0f)
			{
				for (int n = 0; n < arrayList.Count; n++)
				{
					listCancel.Add((int)arrayList[n]);
				}
			}
			break;
		}
		case 2:
		{
			smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: false);
			Class750 @class = aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal;
			Class750 class2 = (((int)arrayList[0] != 0) ? pointsInternal.method_0((int)arrayList[0] - 1).DataLabelsInternal : pointsInternal.method_0(pointsInternal.Count - 1).DataLabelsInternal);
			if (smethod_33(@class.rectangleF_0, class2.rectangleF_0, num))
			{
				float num12 = Math.Abs(class2.rectangleF_0.Bottom - @class.rectangleF_0.Y);
				float num13 = (num12 + num) / 2f;
				if (class2.bool_8)
				{
					@class.rectangleF_0.Y += num13;
					class2.rectangleF_0.Y -= num13;
				}
				else
				{
					@class.rectangleF_0.Y += num12 + num;
				}
			}
			for (int num14 = 1; num14 < arrayList.Count; num14++)
			{
				Class750 dataLabelsInternal6 = aSeries.PointsInternal.method_0((int)arrayList[num14]).DataLabelsInternal;
				float num15 = Math.Abs(@class.rectangleF_0.Bottom - dataLabelsInternal6.rectangleF_0.Y);
				dataLabelsInternal6.rectangleF_0.Y += num15 + num;
				@class = dataLabelsInternal6;
			}
			Class750 dataLabelsInternal3 = aSeries.PointsInternal.method_0((int)arrayList[arrayList.Count - 1]).DataLabelsInternal;
			if (dataLabelsInternal3.rectangleF_0.Y > (float)chart.Height)
			{
				for (int num16 = 0; num16 < arrayList.Count; num16++)
				{
					listCancel.Add((int)arrayList[num16]);
				}
			}
			break;
		}
		case 3:
		{
			smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: true);
			Class750 @class = aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal;
			Class750 class2 = (((int)arrayList[0] != pointsInternal.Count - 1) ? pointsInternal.method_0((int)arrayList[0] + 1).DataLabelsInternal : pointsInternal.method_0(0).DataLabelsInternal);
			if (smethod_33(@class.rectangleF_0, class2.rectangleF_0, num))
			{
				float num6 = Math.Abs(class2.rectangleF_0.Bottom - @class.rectangleF_0.Y);
				float num7 = (num6 + num) / 2f;
				if (class2.bool_8)
				{
					@class.rectangleF_0.Y += num7;
					class2.rectangleF_0.Y -= num7;
				}
				else
				{
					@class.rectangleF_0.Y += num6 + num;
				}
			}
			for (int k = 1; k < arrayList.Count; k++)
			{
				Class750 dataLabelsInternal4 = aSeries.PointsInternal.method_0((int)arrayList[k]).DataLabelsInternal;
				float num8 = Math.Abs(@class.rectangleF_0.Bottom - dataLabelsInternal4.rectangleF_0.Y);
				dataLabelsInternal4.rectangleF_0.Y += num8 + num;
				@class = dataLabelsInternal4;
			}
			Class750 dataLabelsInternal3 = aSeries.PointsInternal.method_0((int)arrayList[arrayList.Count - 1]).DataLabelsInternal;
			if (dataLabelsInternal3.rectangleF_0.Y > (float)chart.Height)
			{
				for (int l = 0; l < arrayList.Count; l++)
				{
					listCancel.Add((int)arrayList[l]);
				}
			}
			break;
		}
		case 4:
		{
			smethod_32(aSeries, arrayList, 0, arrayList.Count - 1, isAscend: false);
			Class750 @class = aSeries.PointsInternal.method_0((int)arrayList[0]).DataLabelsInternal;
			Class750 class2 = (((int)arrayList[0] != 0) ? pointsInternal.method_0((int)arrayList[0] - 1).DataLabelsInternal : pointsInternal.method_0(pointsInternal.Count - 1).DataLabelsInternal);
			if (smethod_33(@class.rectangleF_0, class2.rectangleF_0, num))
			{
				float num3 = Math.Abs(class2.rectangleF_0.Y - @class.rectangleF_0.Bottom);
				float num4 = (num3 + num) / 2f;
				if (class2.bool_8)
				{
					@class.rectangleF_0.Y -= num4;
					class2.rectangleF_0.Y += num4;
				}
				else
				{
					@class.rectangleF_0.Y -= num3 + num;
				}
			}
			for (int i = 1; i < arrayList.Count; i++)
			{
				Class750 dataLabelsInternal2 = aSeries.PointsInternal.method_0((int)arrayList[i]).DataLabelsInternal;
				float num5 = Math.Abs(@class.rectangleF_0.Y - dataLabelsInternal2.rectangleF_0.Bottom);
				dataLabelsInternal2.rectangleF_0.Y -= num5 + num;
				@class = dataLabelsInternal2;
			}
			Class750 dataLabelsInternal3 = aSeries.PointsInternal.method_0((int)arrayList[arrayList.Count - 1]).DataLabelsInternal;
			if (dataLabelsInternal3.rectangleF_0.Y < 0f)
			{
				for (int j = 0; j < arrayList.Count; j++)
				{
					listCancel.Add((int)arrayList[j]);
				}
			}
			break;
		}
		}
		smethod_28(aSeries, list, maxRect, plotRect, listCancel);
	}

	private static void smethod_32(Class759 aSeries, ArrayList list, int startIndex, int endIndex, bool isAscend)
	{
		if (endIndex >= list.Count || startIndex >= list.Count || endIndex <= startIndex)
		{
			return;
		}
		Class750 dataLabelsInternal = aSeries.PointsInternal.method_0((int)list[startIndex]).DataLabelsInternal;
		int num = 0;
		for (int i = startIndex + 1; i <= endIndex; i++)
		{
			Class750 dataLabelsInternal2 = aSeries.PointsInternal.method_0((int)list[i]).DataLabelsInternal;
			if (isAscend)
			{
				if (dataLabelsInternal2.double_0 < dataLabelsInternal.double_0)
				{
					list.Insert(startIndex, list[i]);
					list.RemoveAt(i + 1);
					num++;
				}
			}
			else if (dataLabelsInternal2.double_0 > dataLabelsInternal.double_0)
			{
				list.Insert(startIndex, list[i]);
				list.RemoveAt(i + 1);
				num++;
			}
		}
		smethod_32(aSeries, list, startIndex, endIndex + num - 1, isAscend);
		smethod_32(aSeries, list, startIndex + num + 1, endIndex, isAscend);
	}

	private static bool smethod_33(RectangleF a, RectangleF b, float span)
	{
		a = new RectangleF(a.X, a.Y, a.Width, a.Height);
		b = new RectangleF(b.X, b.Y, b.Width, b.Height);
		if (a.Width != 0f && a.Height != 0f && a.Width != 0f && a.Height != 0f)
		{
			a.Inflate(span / 2f, span / 2f);
			b.Inflate(span / 2f, span / 2f);
			if (((b.Left >= a.Left && b.Left <= a.Right) || (b.Right >= a.Left && b.Right <= a.Right)) && ((b.Bottom >= a.Top && b.Bottom <= a.Bottom) || (b.Top >= a.Top && b.Top <= a.Bottom)))
			{
				return true;
			}
			RectangleF rectangleF = a;
			a = b;
			b = rectangleF;
			if (((b.Left >= a.Left && b.Left <= a.Right) || (b.Right >= a.Left && b.Right <= a.Right)) && ((b.Bottom >= a.Top && b.Bottom <= a.Bottom) || (b.Top >= a.Top && b.Top <= a.Bottom)))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static ArrayList smethod_34(Class759 aSeries, Rectangle plotRect)
	{
		return smethod_35(aSeries, Struct41.smethod_23(plotRect));
	}

	private static ArrayList smethod_35(Class759 aSeries, RectangleF plotRect)
	{
		float span = float_1;
		Class747 pointsInternal = aSeries.PointsInternal;
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < pointsInternal.Count; i++)
		{
			if (pointsInternal[i].DataLabels.LabelPosition != LegendDataLabelPosition.BestFit)
			{
				continue;
			}
			ArrayList arrayList2 = new ArrayList();
			bool flag = false;
			for (int j = 0; j < pointsInternal.Count; j++)
			{
				if (i != j && smethod_33(pointsInternal.method_0(i).DataLabelsInternal.rectangleF_0, pointsInternal.method_0(j).DataLabelsInternal.rectangleF_0, span))
				{
					flag = true;
					if (pointsInternal[j].DataLabels.LabelPosition == LegendDataLabelPosition.BestFit)
					{
						arrayList2.Add(j);
					}
				}
			}
			if (flag)
			{
				arrayList2.Add(i);
				arrayList2.Sort();
				arrayList.Add(arrayList2);
			}
		}
		for (int k = 0; k < arrayList.Count; k++)
		{
			ArrayList arrayList3 = (ArrayList)arrayList[k];
			for (int l = k + 1; l < arrayList.Count; l++)
			{
				ArrayList arrayList4 = (ArrayList)arrayList[l];
				if (arrayList3.Count <= arrayList4.Count)
				{
					if (smethod_36(arrayList3, arrayList4))
					{
						arrayList.RemoveAt(k);
						k--;
						break;
					}
				}
				else if (smethod_36(arrayList4, arrayList3))
				{
					arrayList.RemoveAt(l);
					break;
				}
			}
		}
		return arrayList;
	}

	private static bool smethod_36(ArrayList listSmall, ArrayList listLong)
	{
		int num = 0;
		while (true)
		{
			if (num < listSmall.Count)
			{
				if (!listLong.Contains(listSmall[num]))
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

	private static void smethod_37(Rectangle rectPlot, RectangleF rectLabel, ref float offset)
	{
		smethod_38(Struct41.smethod_23(rectPlot), rectLabel, ref offset);
	}

	private static void smethod_38(RectangleF rectPlot, RectangleF rectLabel, ref float offset)
	{
		if (rectLabel.Left < rectPlot.Left)
		{
			float num = rectPlot.Left - rectLabel.Left;
			if (num > offset)
			{
				offset = num;
			}
		}
		if (rectLabel.Top < rectPlot.Top)
		{
			float num2 = rectPlot.Top - rectLabel.Top;
			if (num2 > offset)
			{
				offset = num2;
			}
		}
		if (rectLabel.Right > rectPlot.Right)
		{
			float num3 = rectLabel.Right - rectPlot.Right;
			if (num3 > offset)
			{
				offset = num3;
			}
		}
		if (rectLabel.Bottom > rectPlot.Bottom)
		{
			float num4 = rectLabel.Bottom - rectPlot.Bottom;
			if (num4 > offset)
			{
				offset = num4;
			}
		}
	}

	private static double smethod_39(double yValue, double sum)
	{
		if (sum == 0.0)
		{
			return 0.0;
		}
		return Math.Abs(yValue) / sum * 360.0;
	}

	internal static RectangleF smethod_40(Rectangle pieRect, double startAngle, double sweepAngle)
	{
		RectangleF pieRect2 = new RectangleF(pieRect.X, pieRect.Y, pieRect.Width, pieRect.Height);
		return smethod_41(pieRect2, startAngle, sweepAngle);
	}

	internal static RectangleF smethod_41(RectangleF pieRect, double startAngle, double sweepAngle)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPie(pieRect.X, pieRect.Y, pieRect.Width, pieRect.Height, (float)startAngle, (float)sweepAngle);
		graphicsPath.Widen(new Pen(Color.Black, 1f));
		return Class790.smethod_0(graphicsPath);
	}

	internal static SizeF smethod_42(Interface32 g, Class757 nSeries, int seriesIndex, int chartPointIndex, double percent, float scaleWidth, float scaleHeight, double otherValue, Class784 renderContext)
	{
		Class759 @class = nSeries.method_0(seriesIndex);
		Class740 chart = @class.Chart;
		Class748 class2 = @class.PointsInternal.method_0(chartPointIndex);
		if (class2 == null)
		{
			class2 = @class.VirtualPointInternal;
		}
		Enum141 axisGroup = @class.AxisGroup;
		List<Interface8> list;
		Class783 class3;
		if (axisGroup == Enum141.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			class3 = renderContext.X1AxisRenderContext;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			class3 = renderContext.X2AxisRenderContext;
		}
		Class750 dataLabelsInternal = class2.DataLabelsInternal;
		string name = @class.Name;
		bool flag = dataLabelsInternal.LinkedSource;
		if (dataLabelsInternal.IsPercentageShown)
		{
			flag = true;
		}
		string format = (dataLabelsInternal.IsPercentageShown ? "" : dataLabelsInternal.Format);
		string text;
		if (flag)
		{
			format = ((chartPointIndex < 0 || chartPointIndex >= list.Count) ? "" : ((Class743)list[chartPointIndex]).SourceFormat);
			bool isCulture = chartPointIndex >= 0 && chartPointIndex < list.Count && ((Class743)list[chartPointIndex]).IsCulture;
			text = ((chartPointIndex < 0 || chartPointIndex >= class3.arrayList_0.Count) ? "Other" : Struct28.smethod_5(class3.arrayList_0[chartPointIndex], format, isCulture));
		}
		else
		{
			text = ((chartPointIndex == -1) ? "Other" : Struct28.smethod_5(class3.arrayList_0[chartPointIndex], format, dataLabelsInternal.IsCategoryNameShown));
		}
		bool flag2 = dataLabelsInternal.LinkedSource;
		if (dataLabelsInternal.IsPercentageShown)
		{
			flag2 = true;
		}
		string format2 = (dataLabelsInternal.IsPercentageShown ? "" : dataLabelsInternal.Format);
		string text2 = ((!flag2) ? ((chartPointIndex == -1) ? Struct28.smethod_5(otherValue, format2, dataLabelsInternal.IsCulture) : Struct28.smethod_5(class2.YValue, format2, dataLabelsInternal.IsCulture)) : ((chartPointIndex == -1) ? Struct28.smethod_5(otherValue, format2, dataLabelsInternal.IsCulture) : Struct28.smethod_5(class2.YValue, class2.YFormat, class2.YValueIsCulture)));
		string text3;
		if (dataLabelsInternal.LinkedSource)
		{
			text3 = Struct28.smethod_5(percent, "0%", isCulture: false);
		}
		else
		{
			string format3 = ((dataLabelsInternal.Format == "") ? "0%" : dataLabelsInternal.Format);
			text3 = Struct28.smethod_5(percent, format3, dataLabelsInternal.IsCulture);
		}
		string text4 = Struct28.smethod_4(dataLabelsInternal);
		Font textFont = dataLabelsInternal.ChartFrameInternal.TextFont;
		int rotation = dataLabelsInternal.Rotation;
		Enum157 textHorizontalAlignment = dataLabelsInternal.TextHorizontalAlignment;
		Enum157 textVerticalAlignment = dataLabelsInternal.TextVerticalAlignment;
		SizeF sizeF = Struct31.smethod_15(g, @class, renderContext);
		string text5 = "";
		if (dataLabelsInternal.Text == null)
		{
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
		}
		else
		{
			text5 = dataLabelsInternal.Text;
		}
		SizeF layoutArea = new SizeF(scaleWidth, scaleHeight);
		Size size = Struct39.smethod_3(g, text5, rotation, textFont, layoutArea, textHorizontalAlignment, textVerticalAlignment);
		if (text5 == "")
		{
			return new SizeF(0f, 0f);
		}
		SizeF result = ((!dataLabelsInternal.IsLegendKeyShown) ? new SizeF(size.Width, size.Height) : new SizeF((float)size.Width + sizeF.Width, size.Height));
		if (dataLabelsInternal.IsLegendKeyShown)
		{
			result.Width += 2 * Struct28.int_0;
		}
		result.Height += 2 * Struct28.int_0;
		return result;
	}

	internal static void smethod_43(Interface32 g, Class740 chart, int seriesIndex, int chartPointIndex, double percent, RectangleF rect, double otherValue, Class784 renderContext)
	{
		chart.method_2(ref rect);
		Class759 @class = chart.NSeriesInternal.method_0(seriesIndex);
		Class748 class2 = @class.PointsInternal.method_0(chartPointIndex);
		if (class2 == null)
		{
			class2 = @class.VirtualPointInternal;
		}
		Enum141 axisGroup = @class.AxisGroup;
		List<Interface8> list;
		Class783 class3;
		if (axisGroup == Enum141.const_0)
		{
			list = chart.NSeriesInternal.CategoryLabelsInternal;
			class3 = renderContext.X1AxisRenderContext;
		}
		else
		{
			list = chart.NSeriesInternal.Category2LabelsInternal;
			class3 = renderContext.X2AxisRenderContext;
		}
		Class750 dataLabelsInternal = class2.DataLabelsInternal;
		string name = @class.Name;
		bool flag = dataLabelsInternal.LinkedSource;
		if (dataLabelsInternal.IsPercentageShown)
		{
			flag = true;
		}
		string format = (dataLabelsInternal.IsPercentageShown ? "" : dataLabelsInternal.Format);
		bool flag2 = false;
		string text;
		if (flag)
		{
			format = ((chartPointIndex < 0 || chartPointIndex >= list.Count) ? "" : ((Class743)list[chartPointIndex]).SourceFormat);
			bool isCulture = chartPointIndex >= 0 && chartPointIndex < list.Count && ((Class743)list[chartPointIndex]).IsCulture;
			text = ((chartPointIndex < 0 || chartPointIndex >= class3.arrayList_0.Count) ? "Other" : Struct28.smethod_5(class3.arrayList_0[chartPointIndex], format, isCulture));
			if (chartPointIndex >= 0 && chartPointIndex < class3.arrayList_0.Count)
			{
				flag2 = Struct28.smethod_7(class3.arrayList_0[chartPointIndex], format);
			}
		}
		else
		{
			text = ((chartPointIndex == -1) ? "Other" : Struct28.smethod_5(class3.arrayList_0[chartPointIndex], format, dataLabelsInternal.IsCategoryNameShown));
		}
		bool flag3 = dataLabelsInternal.LinkedSource;
		if (dataLabelsInternal.IsPercentageShown)
		{
			flag3 = true;
		}
		string format2 = (dataLabelsInternal.IsPercentageShown ? "" : dataLabelsInternal.Format);
		bool flag4 = false;
		string text2;
		if (flag3)
		{
			text2 = ((chartPointIndex == -1) ? Struct28.smethod_5(otherValue, format2, dataLabelsInternal.IsCulture) : Struct28.smethod_5(class2.YValue, class2.YFormat, class2.YValueIsCulture));
			if (chartPointIndex != -1)
			{
				flag4 = Struct28.smethod_7(class2.YValue, class2.YFormat);
			}
		}
		else
		{
			text2 = ((chartPointIndex == -1) ? Struct28.smethod_5(otherValue, format2, dataLabelsInternal.IsCulture) : Struct28.smethod_5(class2.YValue, format2, dataLabelsInternal.IsCulture));
		}
		string text3;
		if (dataLabelsInternal.LinkedSource)
		{
			text3 = Struct28.smethod_5(percent, "0%", isCulture: false);
		}
		else
		{
			string format3 = ((dataLabelsInternal.Format == "") ? "0%" : dataLabelsInternal.Format);
			text3 = Struct28.smethod_5(percent, format3, dataLabelsInternal.IsCulture);
		}
		string text4 = Struct28.smethod_4(dataLabelsInternal);
		Font textFont = dataLabelsInternal.ChartFrameInternal.TextFont;
		Color fontColor = dataLabelsInternal.ChartFrameInternal.FontColor;
		int rotation = dataLabelsInternal.Rotation;
		Enum157 textHorizontalAlignment = dataLabelsInternal.TextHorizontalAlignment;
		Enum157 textVerticalAlignment = dataLabelsInternal.TextVerticalAlignment;
		SizeF sizeF = Struct31.smethod_15(g, @class, renderContext);
		dataLabelsInternal.ChartFrameInternal.rectangle_1 = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
		dataLabelsInternal.ChartFrameInternal.rectangle_0 = dataLabelsInternal.ChartFrameInternal.rectangle_1;
		dataLabelsInternal.ChartFrameInternal.method_17();
		int num = (dataLabelsInternal.IsLegendKeyShown ? ((int)(rect.X + (float)Struct28.int_0)) : ((int)rect.X));
		int y = (int)rect.Y + Struct28.int_0;
		int num2 = (dataLabelsInternal.IsLegendKeyShown ? ((int)(rect.Width - (float)(2 * Struct28.int_0))) : ((int)rect.Width));
		int height = (int)rect.Height - 2 * Struct28.int_0;
		if (dataLabelsInternal.IsLegendKeyShown)
		{
			RectangleF rect2 = new RectangleF(rect.X, rect.Y + (float)Struct28.int_0, sizeF.Width, sizeF.Height);
			Struct31.smethod_10(g, rect2, @class, chartPointIndex, renderContext);
			num += (int)sizeF.Width;
			num2 -= (int)sizeF.Width;
		}
		string text5 = "";
		if (dataLabelsInternal.Text == null)
		{
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
		}
		else
		{
			text5 = dataLabelsInternal.Text;
		}
		if (text5 != "")
		{
			Rectangle rect3 = new Rectangle(num, y, num2, height);
			if (flag2 || flag4)
			{
				fontColor = Color.Red;
			}
			smethod_44(g, dataLabelsInternal, rect3, text5, rotation, textFont, fontColor, textHorizontalAlignment, textVerticalAlignment);
		}
	}

	public static void smethod_44(Interface32 g, Class750 dataLabels, Rectangle rect, string text, int rotation, Font font, Color fontColor, Enum157 horizontalAlignment, Enum157 verticalAlignment)
	{
		bool flag = false;
		TextRenderingHint textRenderingHint = g.TextRenderingHint;
		if (dataLabels.ChartFrameInternal.Chart.ChartAreaInternal.AreaInternal.IsTransparent && dataLabels.ChartFrameInternal.AreaInternal.IsTransparent && dataLabels.LabelPosition == LegendDataLabelPosition.OutsideEnd)
		{
			flag = true;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
		stringFormat.Alignment = Struct39.smethod_18(horizontalAlignment);
		stringFormat.LineAlignment = Struct39.smethod_18(verticalAlignment);
		switch (Math.Abs(rotation))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rect.Width, 2.0) + Math.Pow(rect.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = g.imethod_110(text, font, (int)num, stringFormat);
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			g.imethod_61(layoutRectangle: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), s: text, font: font, brush: new SolidBrush(fontColor), format: stringFormat);
			g.ResetTransform();
			break;
		}
		case 90:
			g.imethod_132(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
			g.imethod_115(-rotation);
			rect = new Rectangle(-rect.Height / 2, -rect.Width / 2, rect.Height, rect.Width);
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			g.ResetTransform();
			break;
		case 0:
			g.imethod_62(text, font, new SolidBrush(fontColor), rect, stringFormat);
			break;
		}
		if (flag)
		{
			g.TextRenderingHint = textRenderingHint;
		}
	}
}
