using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns22;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct59
{
	private static float float_0 = 0.05f;

	private static float float_1 = 0.6f;

	internal static void smethod_0(Interface42 interface42_0, Rectangle rectangle_0, Class844 class844_0)
	{
		Class821 chart = class844_0.Chart;
		IList ilist_ = chart.method_7().method_17(class844_0.method_20(), new ChartType_Chart[1] { class844_0.Type });
		if (chart.method_7().method_19(class844_0, class844_0.method_20(), new ChartType_Chart[1] { class844_0.Type }) == 0)
		{
			switch (class844_0.Type)
			{
			case ChartType_Chart.Pie:
				smethod_16(interface42_0, chart, rectangle_0, class844_0);
				smethod_1(interface42_0, chart, rectangle_0, class844_0);
				break;
			case ChartType_Chart.PiePie:
				smethod_10(interface42_0, chart, rectangle_0, class844_0);
				break;
			case ChartType_Chart.PieExploded:
				smethod_16(interface42_0, chart, rectangle_0, class844_0);
				smethod_9(interface42_0, chart, rectangle_0, class844_0);
				break;
			case ChartType_Chart.PieBar:
				smethod_12(interface42_0, chart, rectangle_0, class844_0);
				break;
			case ChartType_Chart.Doughnut:
				smethod_13(interface42_0, chart, rectangle_0, ilist_);
				break;
			case ChartType_Chart.DoughnutExploded:
				smethod_14(interface42_0, chart, rectangle_0, ilist_);
				break;
			}
		}
	}

	private static void smethod_1(Interface42 interface42_0, Class821 class821_0, Rectangle rectangle_0, Class844 class844_0)
	{
		int index = class844_0.Index;
		double num = 0.0;
		Class830 @class = class844_0.method_9();
		for (int i = 0; i < @class.Count; i++)
		{
			num += Math.Abs(@class[i].YValue);
		}
		if (num == 0.0)
		{
			return;
		}
		double num2 = (float)class844_0.vmethod_1() - 90f;
		double num3 = 0.0;
		double num4 = 90 - class844_0.vmethod_1();
		GraphicsPath graphicsPath = new GraphicsPath();
		ArrayList arrayList = new ArrayList();
		double num5 = (double)rectangle_0.Width / 2.0 / (double)(1f + class844_0.Explosion / 100f);
		double num6 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num7 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		RectangleF rectangleF = new RectangleF((float)(num6 - num5), (float)(num7 - num5), (float)(2.0 * num5), (float)(2.0 * num5));
		for (int j = 0; j < @class.Count; j++)
		{
			Class831 class2 = @class.method_1(j);
			num3 = smethod_23(@class[j].YValue, num);
			if (class2.Explosion > 0f)
			{
				smethod_8(class2, rectangleF, num2, (float)((num3 == 0.0) ? 0.01 : num3), num4);
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num2, (float)((num3 == 0.0) ? 0.01 : num3));
				class2.method_3().method_9(graphicsPath2);
				graphicsPath.AddPath(graphicsPath2, connect: false);
				arrayList.Add(graphicsPath2);
				interface42_0.ResetTransform();
			}
			else
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num2, (float)((num3 == 0.0) ? 0.01 : num3));
				class2.method_3().method_9(graphicsPath3);
				graphicsPath.AddPath(graphicsPath3, connect: false);
				arrayList.Add(graphicsPath3);
			}
			num2 += num3;
			num4 -= num3;
		}
		num2 = (float)class844_0.vmethod_1() - 90f;
		num3 = 0.0;
		PointF pt = PointF.Empty;
		PointF empty = PointF.Empty;
		PointF pointF = new PointF((float)num6, (float)num7);
		num4 = 90 - class844_0.vmethod_1();
		bool flag = false;
		for (int k = 0; k < @class.Count; k++)
		{
			Class831 class3 = @class.method_1(k);
			num3 = smethod_23(@class[k].YValue, num);
			if (k == 0)
			{
				pt = smethod_5(num6, num7, num4, num5);
			}
			empty = smethod_5(num6, num7, num4 - num3, num5);
			if (class3.Explosion > 0f)
			{
				smethod_8(class3, rectangleF, num2, (float)((num3 == 0.0) ? 0.01 : num3), num4);
			}
			if (num3 == 0.0)
			{
				num3 = 0.009999999776482582;
			}
			GraphicsPath graphicsPath4 = new GraphicsPath();
			if (num3 == 360.0)
			{
				graphicsPath4.AddArc(rectangleF, (float)num2, (float)num3);
			}
			else
			{
				graphicsPath4.AddLine(pointF, pt);
				graphicsPath4.AddArc(rectangleF, (float)num2, (float)num3);
				graphicsPath4.AddLine(empty, pointF);
			}
			class3.method_4().method_11(graphicsPath4);
			if (!flag && class3.method_4().IsVisible && class3.Explosion <= 0f)
			{
				interface42_0.imethod_34(new SolidBrush(Color.Black), pointF.X - 0.5f, pointF.Y - 0.5f, 1f, 1f, 0f, 360f);
				flag = true;
			}
			if (class3.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num2 += num3;
			num4 -= num3;
			pt = empty;
		}
		num2 = 90f - (float)class844_0.vmethod_1();
		num3 = 0.0;
		float float_ = (float)(num5 * (double)float_0);
		RectangleF rectangleF_ = Class1181.smethod_1(graphicsPath);
		for (int l = 0; l < @class.Count; l++)
		{
			Class831 class4 = @class.method_1(l);
			Class832 class5 = class4.method_6();
			if (class5.IsVisible)
			{
				double double_ = ((num == 0.0) ? 0.01 : (Math.Abs(class4.YValue) / num));
				num3 = smethod_23(class4.YValue, num);
				double num8 = (num2 - num3 / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
				double num9 = class4.Explosion / 100f;
				double num10 = (1.0 + num9) * num5 * Math.Cos(num8);
				double num11 = (1.0 + num9) * num5 * Math.Sin(num8);
				RectangleF rectangleF_2 = class5.rectangleF_0;
				class821_0.method_29(ref rectangleF_2);
				smethod_26(interface42_0, class821_0, index, l, double_, rectangleF_2, 0.0);
				class5.pointF_0 = new PointF((float)(num6 + num10), (float)(num7 - num11));
				if (class844_0.HasLeaderLines && class5.vmethod_0() == Enum74.const_9)
				{
					smethod_2(interface42_0, rectangleF_, arrayList, class844_0.method_14(), rectangleF_2, class5.pointF_0, float_);
				}
				num2 -= num3;
			}
		}
	}

	private static void smethod_2(Interface42 interface42_0, RectangleF rectangleF_0, ArrayList arrayList_0, Class840 class840_0, RectangleF rectangleF_1, PointF pointF_0, float float_2)
	{
		PointF pointF = new PointF(rectangleF_0.X + rectangleF_0.Width / 2f, rectangleF_0.Y + rectangleF_0.Height / 2f);
		PointF pt = pointF_0;
		if (pointF_0.X < pointF.X)
		{
			pt.X -= 1f;
		}
		else
		{
			pt.X += 1f;
		}
		if (pointF_0.Y < pointF.Y)
		{
			pt.Y -= 1f;
		}
		else
		{
			pt.Y += 1f;
		}
		PointF pt2 = new PointF(rectangleF_1.Left, rectangleF_1.Top + rectangleF_1.Height / 3f);
		PointF pt3 = new PointF(rectangleF_1.Left + rectangleF_1.Width / 3f, rectangleF_1.Top);
		PointF pt4 = new PointF(rectangleF_1.Right, rectangleF_1.Top + rectangleF_1.Height / 3f);
		PointF pt5 = new PointF(rectangleF_1.Left + rectangleF_1.Width / 3f, rectangleF_1.Bottom);
		int num = smethod_4(pointF_0, rectangleF_1);
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF empty = PointF.Empty;
		Pen pen = null;
		switch (num)
		{
		case 1:
			empty = new PointF(pt4.X + float_2, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath8 = new GraphicsPath();
				graphicsPath8.AddLine(pt4, empty);
				graphicsPath8.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath8);
				graphicsPath8.Dispose();
			}
			break;
		case 2:
			empty = new PointF(pt4.X + float_2, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddLine(pt4, empty);
				graphicsPath5.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath5);
				graphicsPath5.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + float_2);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			pen?.Dispose();
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddLine(pt5, empty);
				graphicsPath6.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath6);
				graphicsPath6.Dispose();
			}
			break;
		case 3:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + float_2);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(pt5, empty);
				graphicsPath4.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath4);
				graphicsPath4.Dispose();
			}
			break;
		case 4:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - float_2, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath12 = new GraphicsPath();
				graphicsPath12.AddLine(pt2, empty);
				graphicsPath12.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath12);
				graphicsPath12.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + float_2);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			pen?.Dispose();
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath13 = new GraphicsPath();
				graphicsPath13.AddLine(pt5, empty);
				graphicsPath13.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath13);
				graphicsPath13.Dispose();
			}
			break;
		case 5:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - float_2, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath11 = new GraphicsPath();
				graphicsPath11.AddLine(pt2, empty);
				graphicsPath11.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath11);
				graphicsPath11.Dispose();
			}
			break;
		case 6:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - float_2, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath9 = new GraphicsPath();
				graphicsPath9.AddLine(pt2, empty);
				graphicsPath9.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath9);
				graphicsPath9.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - float_2);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			pen?.Dispose();
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath10 = new GraphicsPath();
				graphicsPath10.AddLine(pt3, empty);
				graphicsPath10.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath10);
				graphicsPath10.Dispose();
			}
			break;
		case 7:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - float_2);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath7 = new GraphicsPath();
				graphicsPath7.AddLine(pt3, empty);
				graphicsPath7.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath7);
				graphicsPath7.Dispose();
			}
			break;
		case 8:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt4.X + float_2, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath2 = new GraphicsPath();
				graphicsPath2.AddLine(pt4, empty);
				graphicsPath2.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath2);
				graphicsPath2.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - float_2);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			pen?.Dispose();
			pen = class840_0.method_12(graphicsPath);
			graphicsPath.Widen(pen);
			if (smethod_3(interface42_0, graphicsPath, arrayList_0) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddLine(pt3, empty);
				graphicsPath3.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath3);
				graphicsPath3.Dispose();
			}
			break;
		}
		pen?.Dispose();
	}

	private static bool smethod_3(Interface42 interface42_0, GraphicsPath graphicsPath_0, ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			GraphicsPath path = (GraphicsPath)arrayList_0[i];
			using Region region = new Region(graphicsPath_0);
			region.Intersect(path);
			if (!interface42_0.imethod_0().imethod_1(region))
			{
				return false;
			}
		}
		return true;
	}

	private static int smethod_4(PointF pointF_0, RectangleF rectangleF_0)
	{
		int num = 0;
		if (rectangleF_0.Right < pointF_0.X)
		{
			if (rectangleF_0.Bottom < pointF_0.Y)
			{
				return 2;
			}
			if (rectangleF_0.Top > pointF_0.Y)
			{
				return 8;
			}
			return 1;
		}
		if (rectangleF_0.Left > pointF_0.X)
		{
			if (rectangleF_0.Bottom < pointF_0.Y)
			{
				return 4;
			}
			if (rectangleF_0.Top > pointF_0.Y)
			{
				return 6;
			}
			return 5;
		}
		if (rectangleF_0.Bottom < pointF_0.Y)
		{
			return 3;
		}
		if (rectangleF_0.Top > pointF_0.Y)
		{
			return 7;
		}
		return 0;
	}

	private static PointF smethod_5(double double_0, double double_1, double double_2, double double_3)
	{
		double num = double_2 * Math.PI / 180.0 % (Math.PI * 2.0);
		double num2 = double_3 * Math.Cos(num);
		double num3 = double_3 * Math.Sin(num);
		num2 = double_0 + num2;
		num3 = double_1 - num3;
		return new PointF((float)num2, (float)num3);
	}

	private static bool smethod_6(RectangleF rectangleF_0, Rectangle rectangle_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		return smethod_7(rectangleF_0, rectangleF_);
	}

	private static bool smethod_7(RectangleF rectangleF_0, RectangleF rectangleF_1)
	{
		if (rectangleF_0.Left >= rectangleF_1.Left && rectangleF_0.Right <= rectangleF_1.Right && rectangleF_0.Top >= rectangleF_1.Top && rectangleF_0.Bottom <= rectangleF_1.Bottom)
		{
			return true;
		}
		return false;
	}

	private static void smethod_8(Class831 class831_0, RectangleF rectangleF_0, double double_0, double double_1, double double_2)
	{
		Class821 chart = class831_0.Chart;
		Interface42 @interface = chart.imethod_0();
		Rectangle rectangle_ = new Rectangle(0, 0, chart.Width, chart.Height);
		float num = class831_0.Explosion;
		double num2 = (double)rectangleF_0.X + (double)rectangleF_0.Width / 2.0;
		double num3 = (double)rectangleF_0.Y + (double)rectangleF_0.Height / 2.0;
		double num4 = (double)rectangleF_0.Width / 2.0;
		double double_3 = num4 * (double)num / 100.0;
		PointF pointF = smethod_5(num2, num3, double_2 - double_1 / 2.0, double_3);
		RectangleF rectangleF_ = new RectangleF((float)((double)pointF.X - num4), (float)((double)pointF.Y - num4), rectangleF_0.Width, rectangleF_0.Height);
		RectangleF rectangleF_2 = smethod_24(rectangleF_, double_0, double_1);
		if (num > 0f)
		{
			while (!smethod_6(rectangleF_2, rectangle_) && !(num <= 0f))
			{
				num -= 1f;
				double_3 = num4 * (double)num / 100.0;
				pointF = smethod_5(num2, num3, double_2 - double_1 / 2.0, double_3);
				rectangleF_ = new RectangleF((float)((double)pointF.X - num4), (float)((double)pointF.Y - num4), rectangleF_0.Width, rectangleF_0.Height);
				rectangleF_2 = smethod_24(rectangleF_, double_0, double_1);
			}
		}
		else
		{
			while (!smethod_6(rectangleF_2, rectangle_) && !(num >= 0f))
			{
				num += 1f;
				double_3 = num4 * (double)num / 100.0;
				pointF = smethod_5(num2, num3, double_2 - double_1 / 2.0, double_3);
				rectangleF_ = new RectangleF((float)((double)pointF.X - num4), (float)((double)pointF.Y - num4), rectangleF_0.Width, rectangleF_0.Height);
				rectangleF_2 = smethod_24(rectangleF_, double_0, double_1);
			}
		}
		Matrix matrix = new Matrix();
		matrix.Translate((float)((double)pointF.X - num2), (float)((double)pointF.Y - num3));
		@interface.imethod_58(matrix);
	}

	private static void smethod_9(Interface42 interface42_0, Class821 class821_0, Rectangle rectangle_0, Class844 class844_0)
	{
		class821_0.method_7();
		int index = class844_0.Index;
		double num = 0.0;
		Class830 @class = class844_0.method_9();
		for (int i = 0; i < @class.Count; i++)
		{
			num += Math.Abs(@class[i].YValue);
		}
		if (num == 0.0)
		{
			return;
		}
		double num2 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num3 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		GraphicsPath graphicsPath = new GraphicsPath();
		ArrayList arrayList = new ArrayList();
		double num4 = (float)class844_0.vmethod_1() - 90f;
		double num5 = 0.0;
		double num6 = 90f - (float)class844_0.vmethod_1();
		double num7 = (double)rectangle_0.Width / 2.0 / (double)(1f + class844_0.Explosion / 100f);
		for (int j = 0; j < @class.Count; j++)
		{
			@class.method_1(j).method_6();
			num5 = smethod_23(@class[j].YValue, num);
			double num8 = (num6 - num5 / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
			Class831 class2 = @class.method_1(j);
			double num9 = class2.Explosion / 100f;
			double num10 = num7 * num9;
			double num11 = num10 * Math.Cos(num8);
			double num12 = num10 * Math.Sin(num8);
			double num13 = num2 + num11;
			double num14 = num3 - num12;
			Rectangle rect = new Rectangle((int)(num13 - num7), (int)(num14 - num7), (int)(2.0 * num7), (int)(2.0 * num7));
			if (num5 == 0.0)
			{
				num5 = 0.001;
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPie(rect, (float)num4, (float)num5);
			graphicsPath.AddPath(graphicsPath2, connect: false);
			arrayList.Add(graphicsPath2);
			class2.method_3().method_9(graphicsPath2);
			class2.method_4().method_11(graphicsPath2);
			num4 += num5;
			num6 -= num5;
		}
		double num15 = 90f - (float)class844_0.vmethod_1();
		RectangleF rectangleF_ = Class1181.smethod_1(graphicsPath);
		for (int k = 0; k < @class.Count; k++)
		{
			Class831 class3 = @class.method_1(k);
			Class832 class4 = class3.method_6();
			double double_ = ((num == 0.0) ? 0.01 : (Math.Abs(class3.YValue) / num));
			num5 = smethod_23(@class[k].YValue, num);
			double num16 = (num15 - num5 / 2.0) % 360.0;
			double num17 = (class4.double_0 = num16 * Math.PI / 180.0);
			double num18 = class3.Explosion / 100f;
			double num19 = (1.0 + num18) * num7 * Math.Cos(num17);
			double num20 = (1.0 + num18) * num7 * Math.Sin(num17);
			num19 = num2 + num19;
			num20 = num3 - num20;
			RectangleF rectangleF_2 = class4.rectangleF_0;
			class821_0.method_29(ref rectangleF_2);
			smethod_26(interface42_0, class821_0, index, k, double_, rectangleF_2, 0.0);
			class4.pointF_0 = new PointF((float)num19, (float)num20);
			float float_ = (float)(num7 * (double)float_0);
			if (class844_0.HasLeaderLines && class4.vmethod_0() == Enum74.const_9)
			{
				smethod_2(interface42_0, rectangleF_, arrayList, class844_0.method_14(), rectangleF_2, class4.pointF_0, float_);
			}
			num15 -= num5;
		}
	}

	private static void smethod_10(Interface42 interface42_0, Class821 class821_0, Rectangle rectangle_0, Class844 class844_0)
	{
		int num = class821_0.method_18();
		int num2 = class821_0.method_20();
		int num3 = class821_0.method_22();
		Class831 @class = class844_0.method_0();
		int num4 = rectangle_0.Width - (2 * num + num3 + 2 * num2);
		int num5 = rectangle_0.X + num4 / 2 + num;
		int num6 = rectangle_0.Y + rectangle_0.Height / 2;
		int num7 = rectangle_0.Right - num4 / 2 - num2;
		int num8 = num6;
		class821_0.method_7();
		int index = class844_0.Index;
		Class830 class2 = class844_0.method_9();
		int count = class2.Count;
		int num9 = 0;
		int num10 = 0;
		if (count == 1)
		{
			num9 = 1;
			num10 = 1;
		}
		else
		{
			if (class844_0.SplitType != 0 && class844_0.SplitValue > 0.0)
			{
				num10 = (int)class844_0.SplitValue;
				if (num10 > count)
				{
					num10 = count;
				}
			}
			else
			{
				num10 = Struct63.smethod_3((float)count / 3f);
			}
			num9 = count - num10 + 1;
		}
		double[] array = new double[num9];
		double[] array2 = new double[num10];
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (i + 1 < num9)
			{
				array[i + 1] = Math.Abs(class2[i].YValue);
				num11 += array[i + 1];
			}
			else
			{
				array2[i + 1 - num9] = Math.Abs(class2[i].YValue);
				num12 += array2[i + 1 - num9];
			}
			num13 += Math.Abs(class2[i].YValue);
		}
		array[0] = num12;
		num11 += num12;
		double num14 = ((num11 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num11 * 360.0 / 2.0));
		if (num9 == 1)
		{
			num14 = 0.0;
		}
		double num15 = 0.0;
		double num16 = (double)num / (double)(1f + class844_0.Explosion / 100f);
		RectangleF rectangleF = new RectangleF((float)((double)num5 - num16), (float)((double)num6 - num16), (float)(2.0 * num16), (float)(2.0 * num16));
		double num17 = 0.0 - num14;
		for (int j = 0; j < array.Length; j++)
		{
			Class831 class3 = null;
			if (array[j] == 0.0)
			{
				continue;
			}
			if (j == 0)
			{
				if (@class != null)
				{
					Color[] array3 = class821_0.method_16().method_0().method_4(class821_0.imethod_7(), count + 1);
					Color color_ = array3[count];
					@class.method_3().method_4(color_);
					class3 = @class;
				}
			}
			else
			{
				class3 = class2.method_1(j - 1);
			}
			num15 = smethod_23(array[j], num11);
			if (num15 == 0.0)
			{
				num15 = 0.001;
			}
			if (class3.Explosion > 0f)
			{
				smethod_8(class3, rectangleF, num14, (float)((num15 == 0.0) ? 0.01 : num15), num17);
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num14, (float)num15);
			class3.method_3().method_9(graphicsPath);
			if (class3.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num14 += num15;
			num17 -= num15;
		}
		num14 = ((num11 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num11 * 360.0 / 2.0));
		if (num9 == 1)
		{
			num14 = 0.0;
		}
		num17 = 0.0 - num14;
		for (int k = 0; k < array.Length; k++)
		{
			Class831 class4 = null;
			if (array[k] == 0.0)
			{
				continue;
			}
			if (k == 0)
			{
				if (@class != null)
				{
					class4 = @class;
				}
			}
			else
			{
				class4 = class2.method_1(k - 1);
			}
			num15 = smethod_23(array[k], num11);
			if (num15 == 0.0)
			{
				num15 = 0.001;
			}
			if (class4.Explosion > 0f)
			{
				smethod_8(class4, rectangleF, num14, (float)((num15 == 0.0) ? 0.01 : num15), num17);
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			if (num15 == 360.0)
			{
				graphicsPath2.AddArc(rectangleF, (float)num14, (float)num15);
			}
			else
			{
				graphicsPath2.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num14, (float)num15);
			}
			class4.method_4().method_11(graphicsPath2);
			if (class4.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num14 += num15;
			num17 -= num15;
		}
		num14 = ((num11 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num11 * 360.0 / 2.0));
		if (num9 == 1)
		{
			num14 = 0.0;
		}
		double num18 = (double)num2 / (double)(1f + class844_0.Explosion / 100f);
		RectangleF rectangleF2 = new RectangleF((float)((double)num7 - num18), (float)((double)num8 - num18), (float)(2.0 * num18), (float)(2.0 * num18));
		num17 = 0.0 - num14;
		for (int l = 0; l < array2.Length; l++)
		{
			if (array2[l] != 0.0)
			{
				int int_ = array.Length - 1 + l;
				Class831 class5 = class2.method_1(int_);
				num15 = smethod_23(array2[l], num12);
				if (num15 == 0.0)
				{
					num15 = 0.001;
				}
				if (class5.Explosion > 0f)
				{
					smethod_8(class5, rectangleF2, num14, (float)((num15 == 0.0) ? 0.01 : num15), num17);
				}
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddPie(rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height, (float)num14, (float)num15);
				class5.method_3().method_9(graphicsPath3);
				if (class5.Explosion > 0f)
				{
					interface42_0.ResetTransform();
				}
				num14 += num15;
				num17 -= num15;
			}
		}
		num14 = ((num11 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num11 * 360.0 / 2.0));
		if (num9 == 1)
		{
			num14 = 0.0;
		}
		num17 = 0.0 - num14;
		double[] array4 = new double[array2.Length];
		double[] array5 = new double[array2.Length];
		for (int m = 0; m < array2.Length; m++)
		{
			if (array2[m] != 0.0)
			{
				int int_2 = array.Length - 1 + m;
				Class831 class6 = class2.method_1(int_2);
				num15 = smethod_23(array2[m], num12);
				if (num15 == 0.0)
				{
					num15 = 0.001;
				}
				if (class6.Explosion > 0f)
				{
					smethod_8(class6, rectangleF2, num14, (float)((num15 == 0.0) ? 0.01 : num15), num17);
				}
				GraphicsPath graphicsPath4 = new GraphicsPath();
				if (num15 == 360.0)
				{
					graphicsPath4.AddArc(rectangleF2, (float)num14, (float)num15);
				}
				else
				{
					graphicsPath4.AddPie(rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height, (float)num14, (float)num15);
				}
				class6.method_4().method_11(graphicsPath4);
				if (class6.Explosion > 0f)
				{
					interface42_0.ResetTransform();
				}
				array4[m] = num14;
				array5[m] = num15;
				num14 += num15;
				num17 -= num15;
			}
		}
		if (class844_0.HasSeriesLines && num11 != 0.0)
		{
			if (Math.Abs(array[0]) / num11 * 2.0 * Math.PI > Math.PI)
			{
				double num19 = Math.Acos((num16 - num18) / (double)(num7 - num5));
				PointF pointF_ = new PointF((float)((double)num5 + num16 * Math.Cos(num19)), (float)((double)num6 - num16 * Math.Sin(num19)));
				PointF pointF_2 = new PointF((float)((double)num7 + num18 * Math.Cos(num19)), (float)((double)num8 - num18 * Math.Sin(num19)));
				PointF pointF_3 = new PointF((float)((double)num5 + num16 * Math.Cos(0.0 - num19)), (float)((double)num6 - num16 * Math.Sin(0.0 - num19)));
				PointF pointF_4 = new PointF((float)((double)num7 + num18 * Math.Cos(0.0 - num19)), (float)((double)num8 - num18 * Math.Sin(0.0 - num19)));
				if (@class.Explosion > 0f)
				{
					float num20 = (float)(num16 * (double)@class.Explosion / 100.0);
					pointF_.X += num20;
					pointF_3.X += num20;
				}
				int num21 = smethod_11(array4, array5, num19 * 180.0 / Math.PI);
				Class831 class7 = class844_0.method_9().method_1(array.Length - 1 + num21);
				if (class7.Explosion > 0f)
				{
					float num22 = (float)(num18 * (double)class7.Explosion / 100.0);
					double num23 = (360.0 - array4[num21] - array5[num21] / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
					pointF_4.X += (float)((double)num22 * Math.Cos(num23));
					pointF_4.Y -= (float)((double)num22 * Math.Sin(num23));
				}
				num21 = smethod_11(array4, array5, 360.0 - num19 * 180.0 / Math.PI);
				class7 = class844_0.method_9().method_1(array.Length - 1 + num21);
				if (class7.Explosion > 0f)
				{
					float num24 = (float)(num18 * (double)class7.Explosion / 100.0);
					double num25 = (360.0 - array4[num21] - array5[num21] / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
					pointF_2.X += (float)((double)num24 * Math.Cos(num25));
					pointF_2.Y -= (float)((double)num24 * Math.Sin(num25));
				}
				class844_0.method_17().method_8(pointF_, pointF_2);
				class844_0.method_17().method_8(pointF_3, pointF_4);
			}
			else
			{
				num14 = ((num11 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num11 * Math.PI));
				if (num9 == 1)
				{
					num14 = 0.0;
				}
				double num26 = (double)num5 + num16 * Math.Cos(num14);
				double num27 = (double)num6 - num16 * Math.Sin(num14);
				double num28 = Math.Sqrt(Math.Pow(num27 - (double)num8, 2.0) + Math.Pow(num26 - (double)num7, 2.0));
				double num19 = Math.Acos(((double)num7 - num26) / num28) + Math.Acos(num18 / num28);
				PointF pointF_5 = new PointF((float)num26, (float)num27);
				PointF pointF_6 = new PointF((float)((double)num7 + num18 * Math.Cos(Math.PI - num19)), (float)((double)num8 - num18 * Math.Sin(Math.PI - num19)));
				PointF pointF_7 = new PointF((float)((double)num5 + num16 * Math.Cos(0.0 - num14)), (float)((double)num6 - num16 * Math.Sin(0.0 - num14)));
				PointF pointF_8 = new PointF((float)((double)num7 + num18 * Math.Cos(num19 + Math.PI)), (float)((double)num8 - num18 * Math.Sin(num19 + Math.PI)));
				if (@class.Explosion > 0f)
				{
					float num29 = (float)(num16 * (double)@class.Explosion / 100.0);
					pointF_5.X += num29;
					pointF_7.X += num29;
				}
				int num30 = smethod_11(array4, array5, num19 * 180.0 / Math.PI);
				Class831 class8 = class844_0.method_9().method_1(array.Length - 1 + num30);
				if (class8.Explosion > 0f)
				{
					float num31 = (float)(num18 * (double)class8.Explosion / 100.0);
					double num32 = (360.0 - array4[num30] - array5[num30] / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
					pointF_8.X += (float)((double)num31 * Math.Cos(num32));
					pointF_8.Y -= (float)((double)num31 * Math.Sin(num32));
				}
				num30 = smethod_11(array4, array5, 360.0 - num19 * 180.0 / Math.PI);
				class8 = class844_0.method_9().method_1(array.Length - 1 + num30);
				if (class8.Explosion > 0f)
				{
					float num33 = (float)(num18 * (double)class8.Explosion / 100.0);
					double num34 = (360.0 - array4[num30] - array5[num30] / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
					pointF_6.X += (float)((double)num33 * Math.Cos(num34));
					pointF_6.Y -= (float)((double)num33 * Math.Sin(num34));
				}
				class844_0.method_17().method_8(pointF_5, pointF_6);
				class844_0.method_17().method_8(pointF_7, pointF_8);
			}
		}
		Class832 class9 = class844_0.method_2();
		num14 = ((num11 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num11 * 180.0));
		double num35 = 0.0 - num14;
		if (num9 == 1)
		{
			num14 = 0.0;
		}
		num15 = 0.0;
		float float_ = class821_0.Height;
		for (int n = 0; n < array.Length + array2.Length; n++)
		{
			Class831 class10 = null;
			double num36 = 0.0;
			if (n == 0)
			{
				if (@class != null)
				{
					class10 = @class;
				}
			}
			else
			{
				class10 = class2.method_1(n - 1);
			}
			if (class10 != null)
			{
				class9 = class10.method_6();
				num36 = class10.Explosion / 100f;
			}
			float float_2 = ((!class9.method_0().method_2().IsVisible) ? ((float)class821_0.Width * 0.2f) : ((float)class821_0.Width * 0.175f));
			double double_ = array[0];
			SizeF sizeF = new SizeF(0f, 0f);
			sizeF = smethod_25(interface42_0, class821_0.method_7(), index, n - 1, double_, float_2, float_, array[0]);
			double double_2 = 0.0;
			double double_3 = 0.0;
			double num37 = 0.0;
			double num38;
			if (n < num9)
			{
				double_ = ((num13 == 0.0) ? 0.01 : (array[n] / num13));
				num15 = ((num11 == 0.0) ? 0.0 : (array[n] / num11 * 360.0));
				num38 = num16;
				num37 = num16 * num36;
			}
			else
			{
				double_ = ((num13 == 0.0) ? 0.01 : (array2[n - num9] / num13));
				if (n == num9)
				{
					num14 = ((num11 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num11 * 180.0));
					num35 = 0.0 - num14;
					if (num9 == 1)
					{
						num14 = 0.0;
					}
				}
				num15 = ((num12 == 0.0) ? 0.0 : (array2[n - num9] / num12 * 360.0));
				num38 = num18;
				num37 = num18 * num36;
			}
			if (num15 == 0.0)
			{
				continue;
			}
			double num39 = (num14 - num15 / 2.0) % 360.0;
			double num19 = num39 * Math.PI / 180.0;
			bool flag = false;
			Enum74 @enum = class9.vmethod_0();
			while (!flag)
			{
				double num40;
				switch (@enum)
				{
				case Enum74.const_9:
					num40 = num37 + num38 * 1.04;
					double_2 = num40 * Math.Cos(num19);
					double_3 = num40 * Math.Sin(num19);
					smethod_18(ref double_2, ref double_3, num39, sizeF);
					flag = true;
					continue;
				case Enum74.const_1:
					num40 = num37 + num38 * 0.5;
					double_2 = num40 * Math.Cos(num19);
					double_3 = num40 * Math.Sin(num19);
					double_2 -= (double)(sizeF.Width / 2f);
					double_3 += (double)(sizeF.Height / 2f);
					flag = true;
					continue;
				case Enum74.const_3:
					num40 = num37 + num38 * 0.96;
					double_2 = num40 * Math.Cos(num19);
					double_3 = num40 * Math.Sin(num19);
					smethod_19(ref double_2, ref double_3, num39, sizeF);
					flag = true;
					continue;
				case Enum74.const_4:
					num40 = num37 + num38 * 1.04;
					double_2 = num40 * Math.Cos(num19);
					double_3 = num40 * Math.Sin(num19);
					smethod_18(ref double_2, ref double_3, num39, sizeF);
					flag = true;
					continue;
				}
				num40 = num37 + num38 * 0.96;
				double_2 = num40 * Math.Cos(num19);
				double_3 = num40 * Math.Sin(num19);
				smethod_19(ref double_2, ref double_3, num39, sizeF);
				RectangleF rectangleF_ = new RectangleF((float)double_2, (float)double_3, sizeF.Width, sizeF.Height);
				if (smethod_20(interface42_0, (float)num35, (float)num14, (float)num15, (float)num38, (float)num37, rectangleF_, class9))
				{
					flag = true;
					continue;
				}
				PointF pointF = smethod_21(interface42_0, (float)num35, (float)num14, (float)num15, (float)num38, (float)num37, sizeF, class9);
				if (pointF.IsEmpty)
				{
					flag = false;
					@enum = Enum74.const_4;
				}
				else
				{
					double_2 = pointF.X;
					double_3 = pointF.Y;
					flag = true;
				}
			}
			if (n < num9)
			{
				double_2 = (double)num5 + double_2;
				double_3 = (double)num6 - double_3;
			}
			else
			{
				double_2 = (double)num7 + double_2;
				double_3 = (double)num8 - double_3;
			}
			if (class9.vmethod_0() == Enum74.const_9)
			{
				class9.method_0().rectangle_1 = new Rectangle(Struct63.smethod_3(double_2), Struct63.smethod_3(double_3), Struct63.smethod_3(sizeF.Width), Struct63.smethod_3(sizeF.Height));
				class9.method_0().method_9();
				double_2 = class9.method_0().rectangle_0.X;
				double_3 = class9.method_0().rectangle_0.Y;
			}
			RectangleF rectangleF_2 = new RectangleF((float)double_2, (float)double_3, sizeF.Width, sizeF.Height);
			smethod_26(interface42_0, class821_0, index, n - 1, double_, rectangleF_2, array[0]);
			num14 -= num15;
			num35 += num15;
		}
	}

	private static int smethod_11(double[] double_0, double[] double_1, double double_2)
	{
		int num = 0;
		while (true)
		{
			if (num < double_0.Length)
			{
				if (double_2 > double_0[num] % 360.0 && !(double_2 > double_0[num] + double_1[num] % 360.0))
				{
					break;
				}
				num++;
				continue;
			}
			double_2 += 360.0;
			int num2 = 0;
			while (true)
			{
				if (num2 < double_0.Length)
				{
					if (double_2 > double_0[num2] % 360.0 && !(double_2 > double_0[num2] + double_1[num2] % 360.0))
					{
						break;
					}
					num2++;
					continue;
				}
				return -1;
			}
			return num2;
		}
		return num;
	}

	private static void smethod_12(Interface42 interface42_0, Class821 class821_0, Rectangle rectangle_0, Class844 class844_0)
	{
		int num = class821_0.method_18();
		int num2 = class821_0.method_20();
		int num3 = class821_0.method_22();
		Class831 @class = class844_0.method_0();
		int num4 = rectangle_0.Width - (2 * num + num3 + num2);
		int num5 = rectangle_0.X + num4 / 2 + num;
		int num6 = rectangle_0.Y + rectangle_0.Height / 2;
		int num7 = rectangle_0.Right - num4 / 2 - num2;
		int num8 = num6;
		class821_0.method_7();
		int index = class844_0.Index;
		Class830 class2 = class844_0.method_9();
		int count = class2.Count;
		int num9 = 0;
		int num10 = 0;
		if (count == 1)
		{
			num9 = 1;
			num10 = 1;
		}
		else
		{
			if (class844_0.SplitType != 0 && class844_0.SplitValue > 0.0)
			{
				num10 = (int)class844_0.SplitValue;
				if (num10 > count)
				{
					num10 = count;
				}
			}
			else
			{
				num10 = Struct63.smethod_3((float)count / 3f);
			}
			num9 = count - num10 + 1;
		}
		double[] array = new double[num9];
		double[] array2 = new double[num10];
		double num11 = 0.0;
		double num12 = 0.0;
		double num13 = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (i + 1 < num9)
			{
				array[i + 1] = Math.Abs(class2[i].YValue);
				num11 += array[i + 1];
			}
			else
			{
				array2[i + 1 - num9] = Math.Abs(class2[i].YValue);
				num12 += array2[i + 1 - num9];
			}
			num13 += Math.Abs(class2[i].YValue);
		}
		array[0] = num12;
		num11 += num12;
		double num14 = ((num11 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num11 * 360.0 / 2.0));
		if (num9 == 1)
		{
			num14 = 0.0;
		}
		double num15 = 0.0;
		double num16 = (double)num / (double)(1f + class844_0.Explosion / 100f);
		RectangleF rectangleF = new RectangleF((float)((double)num5 - num16), (float)((double)num6 - num16), (float)(2.0 * num16), (float)(2.0 * num16));
		double num17 = 0.0 - num14;
		for (int j = 0; j < array.Length; j++)
		{
			Class831 class3 = null;
			if (array[j] == 0.0)
			{
				continue;
			}
			if (j == 0)
			{
				if (@class != null)
				{
					Color[] array3 = class821_0.method_16().method_0().method_4(class821_0.imethod_7(), count + 1);
					Color color_ = array3[count];
					@class.method_3().method_4(color_);
					class3 = @class;
				}
			}
			else
			{
				class3 = class2.method_1(j - 1);
			}
			num15 = smethod_23(array[j], num11);
			if (num15 == 0.0)
			{
				num15 = 0.001;
			}
			if (class3.Explosion > 0f)
			{
				smethod_8(class3, rectangleF, num14, (float)((num15 == 0.0) ? 0.01 : num15), num17);
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num14, (float)num15);
			class3.method_3().method_9(graphicsPath);
			if (class3.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num14 += num15;
			num17 -= num15;
		}
		num14 = ((num11 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num11 * 360.0 / 2.0));
		if (num9 == 1)
		{
			num14 = 0.0;
		}
		num17 = 0.0 - num14;
		for (int k = 0; k < array.Length; k++)
		{
			Class831 class4 = null;
			if (array[k] == 0.0)
			{
				continue;
			}
			if (k == 0)
			{
				if (@class != null)
				{
					class4 = @class;
				}
			}
			else
			{
				class4 = class2.method_1(k - 1);
			}
			num15 = smethod_23(array[k], num11);
			if (num15 == 0.0)
			{
				num15 = 0.001;
			}
			if (class4.Explosion > 0f)
			{
				smethod_8(class4, rectangleF, num14, (float)((num15 == 0.0) ? 0.01 : num15), num17);
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			if (num15 == 360.0)
			{
				graphicsPath2.AddArc(rectangleF, (float)num14, (float)num15);
			}
			else
			{
				graphicsPath2.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num14, (float)num15);
			}
			class4.method_4().method_11(graphicsPath2);
			if (class4.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num14 += num15;
			num17 -= num15;
		}
		double num18 = num8 - num2;
		for (int l = 0; l < array2.Length; l++)
		{
			if (array2[l] != 0.0)
			{
				int int_ = array.Length - 1 + l;
				Class831 class5 = class2.method_1(int_);
				double num19 = Math.Abs(array2[l]) / num12 * 2.0 * (double)num2;
				RectangleF rectangleF_ = new RectangleF(num7, (float)num18, num2, (float)num19);
				class5.method_3().method_8(rectangleF_);
				class5.method_4().method_10(rectangleF_);
				num18 += num19;
			}
		}
		if (class844_0.HasSeriesLines && num11 != 0.0)
		{
			PointF pointF_ = new PointF(num7, num8 - num2);
			PointF pointF_2 = new PointF(num7, num8 + num2);
			if (Math.Abs(array[0]) / num11 * 2.0 * Math.PI > Math.PI)
			{
				num14 = ((num11 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num11 * Math.PI));
				if (num9 == 1)
				{
					num14 = 0.0;
				}
				double num20 = Math.Sqrt(Math.Pow(num8 - num6, 2.0) + Math.Pow(num7 - num5, 2.0));
				double num21 = Math.Acos(num16 / num20) + Math.Asin((double)num2 / num20);
				PointF pointF_3 = new PointF((float)((double)num5 + num16 * Math.Cos(num21)), (float)((double)num6 - num16 * Math.Sin(num21)));
				PointF pointF_4 = new PointF((float)((double)num5 + num16 * Math.Cos(0.0 - num21)), (float)((double)num6 - num16 * Math.Sin(0.0 - num21)));
				if (@class.Explosion > 0f)
				{
					float num22 = (float)(num16 * (double)@class.Explosion / 100.0);
					pointF_3.X += num22;
					pointF_4.X += num22;
				}
				class844_0.method_17().method_8(pointF_3, pointF_);
				class844_0.method_17().method_8(pointF_4, pointF_2);
			}
			else
			{
				double num21 = Math.Abs(array[0]) / num11 * Math.PI;
				PointF pointF_5 = new PointF((float)((double)num5 + num16 * Math.Cos(num21)), (float)((double)num6 - num16 * Math.Sin(num21)));
				PointF pointF_6 = new PointF((float)((double)num5 + num16 * Math.Cos(0.0 - num21)), (float)((double)num6 - num16 * Math.Sin(0.0 - num21)));
				if (@class.Explosion > 0f)
				{
					float num23 = (float)(num16 * (double)@class.Explosion / 100.0);
					pointF_5.X += num23;
					pointF_6.X += num23;
				}
				class844_0.method_17().method_8(pointF_5, pointF_);
				class844_0.method_17().method_8(pointF_6, pointF_2);
			}
		}
		Class832 class6 = class844_0.method_2();
		double double_ = array[0];
		SizeF sizeF = new SizeF(0f, 0f);
		double num24 = 0.0;
		double num25 = 0.0;
		num14 = ((num11 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num11 * 180.0));
		double num26 = 0.0 - num14;
		if (num9 == 1)
		{
			num14 = 0.0;
		}
		num15 = 0.0;
		float float_ = class821_0.Height;
		for (int m = 0; m < array.Length; m++)
		{
			if (array[m] == 0.0)
			{
				continue;
			}
			Class831 class7 = null;
			double num27 = 0.0;
			if (m == 0)
			{
				if (@class != null)
				{
					class7 = @class;
				}
			}
			else
			{
				class7 = class2.method_1(m - 1);
			}
			if (class7 != null)
			{
				class6 = class7.method_6();
				num27 = class7.Explosion / 100f;
			}
			sizeF = smethod_25(float_2: (!class6.method_0().method_2().IsVisible) ? ((float)class821_0.Width * 0.2f) : ((float)class821_0.Width * 0.175f), interface42_0: interface42_0, class842_0: class821_0.method_7(), int_0: index, int_1: m - 1, double_0: double_, float_3: float_, double_1: array[0]);
			double_ = ((num13 == 0.0) ? 0.01 : (array[m] / num13));
			num15 = ((num11 == 0.0) ? 0.0 : (array[m] / num11 * 360.0));
			double num28 = (double)num * num27;
			double num29 = (num14 - num15 / 2.0) % 360.0;
			double num21 = num29 * Math.PI / 180.0;
			bool flag = false;
			Enum74 @enum = class6.vmethod_0();
			num24 = 0.0;
			num25 = 0.0;
			while (!flag)
			{
				double num30;
				switch (@enum)
				{
				case Enum74.const_9:
					num30 = num28 + num16 * 1.04;
					num24 = num30 * Math.Cos(num21);
					num25 = num30 * Math.Sin(num21);
					smethod_18(ref num24, ref num25, num29, sizeF);
					flag = true;
					continue;
				case Enum74.const_1:
					num30 = num28 + num16 * 0.5;
					num24 = num30 * Math.Cos(num21);
					num25 = num30 * Math.Sin(num21);
					num24 -= (double)(sizeF.Width / 2f);
					num25 += (double)(sizeF.Height / 2f);
					flag = true;
					continue;
				case Enum74.const_3:
					num30 = num28 + num16 * 0.96;
					num24 = num30 * Math.Cos(num21);
					num25 = num30 * Math.Sin(num21);
					smethod_19(ref num24, ref num25, num29, sizeF);
					flag = true;
					continue;
				case Enum74.const_4:
					num30 = num28 + num16 * 1.04;
					num24 = num30 * Math.Cos(num21);
					num25 = num30 * Math.Sin(num21);
					smethod_18(ref num24, ref num25, num29, sizeF);
					flag = true;
					continue;
				}
				num30 = num28 + num16 * 0.96;
				num24 = num30 * Math.Cos(num21);
				num25 = num30 * Math.Sin(num21);
				smethod_19(ref num24, ref num25, num29, sizeF);
				RectangleF rectangleF_2 = new RectangleF((float)num24, (float)num25, sizeF.Width, sizeF.Height);
				if (smethod_20(interface42_0, (float)num26, (float)num14, (float)num15, num, (float)num28, rectangleF_2, class6))
				{
					flag = true;
					continue;
				}
				PointF pointF = smethod_21(interface42_0, (float)num26, (float)num14, (float)num15, num, (float)num28, sizeF, class6);
				if (pointF.IsEmpty)
				{
					flag = false;
					@enum = Enum74.const_4;
				}
				else
				{
					num24 = pointF.X;
					num25 = pointF.Y;
					flag = true;
				}
			}
			num24 = (double)num5 + num24;
			num25 = (double)num6 - num25;
			if (class6.vmethod_0() == Enum74.const_9)
			{
				class6.method_0().rectangle_1 = new Rectangle(Struct63.smethod_3(num24), Struct63.smethod_3(num25), Struct63.smethod_3(sizeF.Width), Struct63.smethod_3(sizeF.Height));
				class6.method_0().method_9();
				num24 = class6.method_0().rectangle_0.X;
				num25 = class6.method_0().rectangle_0.Y;
			}
			RectangleF rectangleF_3 = new RectangleF((float)num24, (float)num25, sizeF.Width, sizeF.Height);
			smethod_26(interface42_0, class821_0, index, m - 1, double_, rectangleF_3, array[0]);
			num14 -= num15;
			num26 += num15;
		}
		num18 = num8 - num2;
		float_ = class821_0.Height;
		class6 = class844_0.method_2();
		for (int n = 0; n < array2.Length; n++)
		{
			if (array2[n] != 0.0)
			{
				Class831 class8 = null;
				int num31 = array.Length + n - 1;
				if (num31 < class844_0.method_9().Count)
				{
					class8 = class2.method_1(num31);
				}
				if (class8 != null)
				{
					class6 = class8.method_6();
				}
				float float_3 = ((!class6.method_0().method_2().IsVisible) ? ((float)class821_0.Width * 0.2f) : ((float)class821_0.Width * 0.175f));
				double num19 = Math.Abs(array2[n]) / num12 * 2.0 * (double)num2;
				num24 = num7;
				num25 = num18;
				num18 += num19;
				int int_2 = array.Length - 1 + n;
				double_ = ((num13 == 0.0) ? 0.01 : (array2[n] / num13));
				sizeF = smethod_25(interface42_0, class821_0.method_7(), index, int_2, double_, float_3, float_, array[0]);
				double num21 = 0.0;
				switch (class6.vmethod_0())
				{
				case Enum74.const_1:
					num24 += (double)(((float)num2 - sizeF.Width) / 2f);
					num25 += (num19 - (double)sizeF.Height) / 2.0;
					break;
				default:
					num24 = num24 + (double)num2 + 1.0;
					num25 += (num19 - (double)sizeF.Height) / 2.0;
					break;
				case Enum74.const_3:
					num24 += (double)(((float)num2 - sizeF.Width) / 2f);
					break;
				}
				if (class6.vmethod_0() == Enum74.const_9)
				{
					class6.method_0().rectangle_1 = new Rectangle(Struct63.smethod_3(num24), Struct63.smethod_3(num25), Struct63.smethod_3(sizeF.Width), Struct63.smethod_3(sizeF.Height));
					class6.method_0().method_9();
					num24 = class6.method_0().rectangle_0.X;
					num25 = class6.method_0().rectangle_0.Y;
				}
				RectangleF rectangleF_4 = new RectangleF((float)num24, (float)num25, sizeF.Width, sizeF.Height);
				smethod_26(interface42_0, class821_0, index, int_2, double_, rectangleF_4, array[0]);
			}
		}
	}

	private static void smethod_13(Interface42 interface42_0, Class821 class821_0, Rectangle rectangle_0, IList ilist_0)
	{
		Class844 @class = (Class844)ilist_0[0];
		int num = @class.vmethod_1();
		int doughnutHoleSize = @class.DoughnutHoleSize;
		double num2 = (double)rectangle_0.Width / 2.0;
		double num3 = num2 * (double)doughnutHoleSize / 100.0;
		double num4 = (num2 - num3) / (double)ilist_0.Count;
		double num5 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num6 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		rectangleF_.X += (float)(num2 - num3);
		rectangleF_.Y += (float)(num2 - num3);
		rectangleF_.Width -= 2f * (float)(num2 - num3);
		rectangleF_.Height -= 2f * (float)(num2 - num3);
		double num7 = num3;
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Class844 class2 = (Class844)ilist_0[i];
			_ = class2.Index;
			double num8 = 0.0;
			Class830 class3 = class2.method_9();
			_ = class3.Count;
			for (int j = 0; j < class3.Count; j++)
			{
				num8 += Math.Abs(class3[j].YValue);
			}
			double num9 = (float)num - 90f;
			double num10 = 0.0;
			for (int k = 0; k < class3.Count; k++)
			{
				Class831 class4 = class3.method_1(k);
				if (class3[k].YValue != 0.0)
				{
					num10 = smethod_23(class3[k].YValue, num8);
					if (num10 == 0.0)
					{
						num10 = 0.001;
					}
					if (i == ilist_0.Count - 1)
					{
						double num11 = (360.0 - num9 - num10 / 2.0) * Math.PI / 180.0;
						double num12 = num2 * (double)class4.Explosion / 100.0;
						double num13 = num12 * Math.Cos(num11);
						double num14 = num12 * Math.Sin(num11);
						num5 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0 + num13;
						num6 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0 - num14;
						rectangleF_.X = (float)(num5 - num7);
						rectangleF_.Y = (float)(num6 - num7);
						rectangleF_.Width = (float)(2.0 * num7);
						rectangleF_.Height = (float)(2.0 * num7);
					}
					GraphicsPath graphicsPath = new GraphicsPath();
					RectangleF rect = Struct63.smethod_20(rectangleF_);
					graphicsPath.AddArc(rect, (float)num9, (float)num10);
					double num15 = (360.0 - num9 - num10) * Math.PI / 180.0;
					double num16 = num7 * Math.Cos(num15);
					double num17 = num7 * Math.Sin(num15);
					num16 = num5 + num16;
					num17 = num6 - num17;
					PointF pt = new PointF((float)num16, (float)num17);
					num16 = (num7 + num4) * Math.Cos(num15);
					num17 = (num7 + num4) * Math.Sin(num15);
					num16 = num5 + num16;
					num17 = num6 - num17;
					PointF pt2 = new PointF((float)num16, (float)num17);
					graphicsPath.AddLine(pt, pt2);
					RectangleF rect2 = Struct63.smethod_20(rectangleF_);
					rect2.X -= (float)num4;
					rect2.Y -= (float)num4;
					rect2.Width += 2f * (float)num4;
					rect2.Height += 2f * (float)num4;
					graphicsPath.AddArc(rect2, (float)num9, (float)num10);
					num15 = (360.0 - num9) * Math.PI / 180.0;
					num16 = num7 * Math.Cos(num15);
					num17 = num7 * Math.Sin(num15);
					num16 = num5 + num16;
					num17 = num6 - num17;
					PointF pt3 = new PointF((float)num16, (float)num17);
					num16 = (num7 + num4) * Math.Cos(num15);
					num17 = (num7 + num4) * Math.Sin(num15);
					num16 = num5 + num16;
					num17 = num6 - num17;
					PointF pt4 = new PointF((float)num16, (float)num17);
					graphicsPath.AddLine(pt4, pt3);
					class4.method_3().method_9(graphicsPath);
					class4.method_4().method_11(graphicsPath);
					num9 += num10;
				}
			}
			num7 += num4;
			rectangleF_.X -= (float)num4;
			rectangleF_.Y -= (float)num4;
			rectangleF_.Width += 2f * (float)num4;
			rectangleF_.Height += 2f * (float)num4;
		}
		float float_ = class821_0.Height;
		for (int l = 0; l < ilist_0.Count; l++)
		{
			Class844 class5 = (Class844)ilist_0[l];
			int index = class5.Index;
			Class830 class6 = class5.method_9();
			double num18 = (float)num - 90f;
			double num19 = 0.0;
			double num20 = 0.0;
			for (int m = 0; m < class6.Count; m++)
			{
				num20 += Math.Abs(class6[m].YValue);
			}
			num7 = num3 + (double)l * num4 + num4 / 2.0;
			for (int n = 0; n < class6.Count; n++)
			{
				if (class6[n].YValue != 0.0)
				{
					Class832 class7 = class6.method_1(n).method_6();
					float float_2 = ((!class7.method_0().method_2().IsVisible) ? ((float)class821_0.Width * 0.2f) : ((float)class821_0.Width * 0.175f));
					double double_ = ((num20 == 0.0) ? 0.01 : (Math.Abs(class6[n].YValue) / num20));
					SizeF sizeF = smethod_25(interface42_0, class821_0.method_7(), index, n, double_, float_2, float_, 0.0);
					num19 = smethod_23(class6[n].YValue, num20);
					if (l == ilist_0.Count - 1)
					{
						double num21 = (360.0 - num18 - num19 / 2.0) * Math.PI / 180.0;
						double num22 = num2 * (double)class6[n].Explosion / 100.0;
						double num23 = num22 * Math.Cos(num21);
						double num24 = num22 * Math.Sin(num21);
						num5 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0 + num23;
						num6 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0 - num24;
					}
					double num25 = (360.0 - num18 - num19 / 2.0) * Math.PI / 180.0;
					double num26 = num7 * Math.Cos(num25);
					double num27 = num7 * Math.Sin(num25);
					num26 = num5 + num26;
					num27 = num6 - num27;
					num26 -= (double)(sizeF.Width / 2f);
					num27 -= (double)(sizeF.Height / 2f);
					if (class7.vmethod_0() == Enum74.const_9)
					{
						class7.method_0().rectangle_1 = new Rectangle(Struct63.smethod_3(num26), Struct63.smethod_3(num27), Struct63.smethod_3(sizeF.Width), Struct63.smethod_3(sizeF.Height));
						class7.method_0().method_9();
						num26 = class7.method_0().rectangle_0.X;
						num27 = class7.method_0().rectangle_0.Y;
					}
					RectangleF rectangleF_2 = new RectangleF((float)num26, (float)num27, sizeF.Width, sizeF.Height);
					smethod_26(interface42_0, class821_0, index, n, double_, rectangleF_2, 0.0);
					num18 += num19;
				}
			}
		}
	}

	private static void smethod_14(Interface42 interface42_0, Class821 class821_0, Rectangle rectangle_0, IList ilist_0)
	{
		Class844 @class = (Class844)ilist_0[0];
		int num = @class.vmethod_1();
		int doughnutHoleSize = @class.DoughnutHoleSize;
		double num2 = (double)rectangle_0.Width / 2.0 / (double)(1f + @class.Explosion / 100f);
		double num3 = num2 * (double)doughnutHoleSize / 100.0;
		double num4 = (num2 - num3) / (double)ilist_0.Count;
		double num5 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num6 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		double num7 = num3;
		RectangleF empty = RectangleF.Empty;
		empty.X = (float)(num5 - num7);
		empty.Y = (float)(num6 - num7);
		empty.Width = (float)(2.0 * num7);
		empty.Height = (float)(2.0 * num7);
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Class844 class2 = (Class844)ilist_0[i];
			_ = class2.Index;
			double num8 = 0.0;
			Class830 class3 = class2.method_9();
			for (int j = 0; j < class3.Count; j++)
			{
				num8 += Math.Abs(class3[j].YValue);
			}
			double num9 = (float)num - 90f;
			double num10 = 0.0;
			_ = class3.Count;
			for (int k = 0; k < class3.Count; k++)
			{
				Class831 class4 = class3.method_1(k);
				if (class3[k].YValue != 0.0)
				{
					num10 = smethod_23(class3[k].YValue, num8);
					if (num10 == 0.0)
					{
						num10 = 0.001;
					}
					if (i == ilist_0.Count - 1)
					{
						double num11 = (360.0 - num9 - num10 / 2.0) * Math.PI / 180.0;
						double num12 = num2 * (double)class4.Explosion / 100.0;
						double num13 = num12 * Math.Cos(num11);
						double num14 = num12 * Math.Sin(num11);
						num5 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0 + num13;
						num6 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0 - num14;
						empty.X = (float)(num5 - num7);
						empty.Y = (float)(num6 - num7);
						empty.Width = (float)(2.0 * num7);
						empty.Height = (float)(2.0 * num7);
					}
					GraphicsPath graphicsPath = new GraphicsPath();
					RectangleF rect = Struct63.smethod_20(empty);
					graphicsPath.AddArc(rect, (float)num9, (float)num10);
					double num15 = (360.0 - num9 - num10) * Math.PI / 180.0;
					double num16 = num7 * Math.Cos(num15);
					double num17 = num7 * Math.Sin(num15);
					num16 = num5 + num16;
					num17 = num6 - num17;
					PointF pt = new PointF((float)num16, (float)num17);
					num16 = (num7 + num4) * Math.Cos(num15);
					num17 = (num7 + num4) * Math.Sin(num15);
					num16 = num5 + num16;
					num17 = num6 - num17;
					PointF pt2 = new PointF((float)num16, (float)num17);
					graphicsPath.AddLine(pt, pt2);
					RectangleF rect2 = Struct63.smethod_20(empty);
					rect2.X -= (float)num4;
					rect2.Y -= (float)num4;
					rect2.Width += 2f * (float)num4;
					rect2.Height += 2f * (float)num4;
					graphicsPath.AddArc(rect2, (float)(num9 + num10), 0f - (float)num10);
					num15 = (360.0 - num9) * Math.PI / 180.0;
					num16 = num7 * Math.Cos(num15);
					num17 = num7 * Math.Sin(num15);
					num16 = num5 + num16;
					num17 = num6 - num17;
					PointF pt3 = new PointF((float)num16, (float)num17);
					num16 = (num7 + num4) * Math.Cos(num15);
					num17 = (num7 + num4) * Math.Sin(num15);
					num16 = num5 + num16;
					num17 = num6 - num17;
					PointF pt4 = new PointF((float)num16, (float)num17);
					graphicsPath.AddLine(pt4, pt3);
					class4.method_3().method_9(graphicsPath);
					class4.method_4().method_11(graphicsPath);
					num9 += num10;
				}
			}
			num7 += num4;
			empty.X -= (float)num4;
			empty.Y -= (float)num4;
			empty.Width += 2f * (float)num4;
			empty.Height += 2f * (float)num4;
		}
		num5 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		num6 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		float float_ = class821_0.Height;
		for (int l = 0; l < ilist_0.Count; l++)
		{
			Class844 class5 = (Class844)ilist_0[l];
			int index = class5.Index;
			Class830 class6 = class5.method_9();
			double num18 = (float)num - 90f;
			double num19 = 0.0;
			double num20 = 0.0;
			for (int m = 0; m < class6.Count; m++)
			{
				num20 += Math.Abs(class6[m].YValue);
			}
			num7 = num3 + (double)l * num4 + num4 / 2.0;
			for (int n = 0; n < class6.Count; n++)
			{
				if (class6[n].YValue != 0.0)
				{
					Class832 class7 = class6.method_1(n).method_6();
					float float_2 = ((!class7.method_0().method_2().IsVisible) ? ((float)class821_0.Width * 0.2f) : ((float)class821_0.Width * 0.175f));
					double double_ = ((num20 == 0.0) ? 0.01 : (Math.Abs(class6[n].YValue) / num20));
					SizeF sizeF = smethod_25(interface42_0, class821_0.method_7(), index, n, double_, float_2, float_, 0.0);
					num19 = smethod_23(class6[n].YValue, num20);
					if (l == ilist_0.Count - 1)
					{
						double num21 = (360.0 - num18 - num19 / 2.0) * Math.PI / 180.0;
						double num22 = num2 * (double)class6[n].Explosion / 100.0;
						double num23 = num22 * Math.Cos(num21);
						double num24 = num22 * Math.Sin(num21);
						num5 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0 + num23;
						num6 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0 - num24;
					}
					double num25 = (360.0 - num18 - num19 / 2.0) * Math.PI / 180.0;
					double num26 = num7 * Math.Cos(num25);
					double num27 = num7 * Math.Sin(num25);
					num26 = num5 + num26;
					num27 = num6 - num27;
					num26 -= (double)(sizeF.Width / 2f);
					num27 -= (double)(sizeF.Height / 2f);
					if (class7.vmethod_0() == Enum74.const_9)
					{
						class7.method_0().rectangle_1 = new Rectangle(Struct63.smethod_3(num26), Struct63.smethod_3(num27), Struct63.smethod_3(sizeF.Width), Struct63.smethod_3(sizeF.Height));
						class7.method_0().method_9();
						num26 = class7.method_0().rectangle_0.X;
						num27 = class7.method_0().rectangle_0.Y;
					}
					RectangleF rectangleF_ = new RectangleF((float)num26, (float)num27, sizeF.Width, sizeF.Height);
					smethod_26(interface42_0, class821_0, index, n, double_, rectangleF_, 0.0);
					num18 += num19;
				}
			}
		}
	}

	internal static void smethod_15(Class821 class821_0, ref Rectangle rectangle_0, Class844 class844_0)
	{
		if (rectangle_0.Width <= 0 || rectangle_0.Height <= 0 || !class844_0.method_33() || !class821_0.method_8().imethod_3())
		{
			return;
		}
		rectangle_0.X += 4;
		rectangle_0.Y += 4;
		rectangle_0.Width -= 2 * 4;
		rectangle_0.Height -= 2 * 4;
		bool flag = false;
		if (class844_0.Type != ChartType_Chart.Doughnut && class844_0.Type != ChartType_Chart.DoughnutExploded)
		{
			if (class844_0.method_37() && (class844_0.method_2().vmethod_0() == Enum74.const_4 || class844_0.method_2().vmethod_0() == Enum74.const_0))
			{
				flag = true;
			}
		}
		else if (class844_0.method_37())
		{
			flag = true;
		}
		if (flag)
		{
			int num = rectangle_0.Width;
			if (rectangle_0.Width > rectangle_0.Height)
			{
				num = rectangle_0.Height;
			}
			int num2 = Struct63.smethod_4((float)num / 100f * 7f);
			rectangle_0.X += num2;
			rectangle_0.Y += num2;
			rectangle_0.Width -= 2 * num2;
			rectangle_0.Height -= 2 * num2;
		}
		int num3 = 10;
		if (rectangle_0.Width < 10)
		{
			rectangle_0.Width = num3;
		}
		if (rectangle_0.Height < num3)
		{
			rectangle_0.Height = num3;
		}
	}

	internal static void smethod_16(Interface42 interface42_0, Class821 class821_0, Rectangle rectangle_0, Class844 class844_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		smethod_17(interface42_0, class821_0, rectangleF_, class844_0);
	}

	internal static void smethod_17(Interface42 interface42_0, Class821 class821_0, RectangleF rectangleF_0, Class844 class844_0)
	{
		int index = class844_0.Index;
		double num = 0.0;
		Class830 @class = class844_0.method_9();
		for (int i = 0; i < @class.Count; i++)
		{
			num += Math.Abs(@class[i].YValue);
		}
		double num2 = (double)rectangleF_0.X + (double)rectangleF_0.Width / 2.0;
		double num3 = (double)rectangleF_0.Y + (double)rectangleF_0.Height / 2.0;
		double num4 = 90f - (float)class844_0.vmethod_1();
		double num5 = 0.0;
		double num6 = 0.0 - num4;
		float float_ = class821_0.Height;
		for (int j = 0; j < @class.Count; j++)
		{
			Class831 class2 = @class.method_1(j);
			Class832 class3 = class2.method_6();
			float float_2 = ((!class3.method_0().method_2().IsVisible) ? ((float)class821_0.Width * 0.2f) : ((float)class821_0.Width * 0.175f));
			double double_ = ((num == 0.0) ? 0.01 : (Math.Abs(@class[j].YValue) / num));
			SizeF sizeF_ = smethod_25(interface42_0, class821_0.method_7(), index, j, double_, float_2, float_, 0.0);
			num5 = smethod_23(@class[j].YValue, num);
			double num7 = (num4 - num5 / 2.0) % 360.0;
			double num8 = (class3.double_0 = num7 * Math.PI / 180.0);
			double num9 = class2.Explosion / 100f;
			double num10 = ((class821_0.Type != ChartType_Chart.Pie) ? ((double)rectangleF_0.Width / 2.0 / (1.0 + num9)) : ((double)rectangleF_0.Width / 2.0));
			double num11 = num10 * num9;
			double double_2 = 0.0;
			double double_3 = 0.0;
			bool flag = false;
			Enum74 @enum = class3.vmethod_0();
			while (!flag)
			{
				double num12;
				switch (@enum)
				{
				case Enum74.const_9:
					num12 = num11 + num10 * 1.04;
					double_2 = num12 * Math.Cos(num8);
					double_3 = num12 * Math.Sin(num8);
					smethod_18(ref double_2, ref double_3, num7, sizeF_);
					flag = true;
					continue;
				case Enum74.const_1:
					num12 = num11 + num10 * 0.5;
					double_2 = num12 * Math.Cos(num8);
					double_3 = num12 * Math.Sin(num8);
					double_2 -= (double)(sizeF_.Width / 2f);
					double_3 += (double)(sizeF_.Height / 2f);
					flag = true;
					continue;
				case Enum74.const_3:
					num12 = num11 + num10 * 0.96;
					double_2 = num12 * Math.Cos(num8);
					double_3 = num12 * Math.Sin(num8);
					smethod_19(ref double_2, ref double_3, num7, sizeF_);
					flag = true;
					continue;
				case Enum74.const_4:
					num12 = num11 + num10 * 1.04;
					double_2 = num12 * Math.Cos(num8);
					double_3 = num12 * Math.Sin(num8);
					smethod_18(ref double_2, ref double_3, num7, sizeF_);
					flag = true;
					continue;
				}
				num12 = num11 + num10 * 0.96;
				double_2 = num12 * Math.Cos(num8);
				double_3 = num12 * Math.Sin(num8);
				smethod_19(ref double_2, ref double_3, num7, sizeF_);
				RectangleF rectangleF_ = new RectangleF((float)double_2, (float)double_3, sizeF_.Width, sizeF_.Height);
				if (smethod_20(interface42_0, (float)num6, (float)num4, (float)num5, (float)num10, (float)num11, rectangleF_, class3))
				{
					flag = true;
					continue;
				}
				PointF pointF = smethod_21(interface42_0, (float)num6, (float)num4, (float)num5, (float)num10, (float)num11, sizeF_, class3);
				if (pointF.IsEmpty)
				{
					flag = false;
					@enum = Enum74.const_4;
				}
				else
				{
					double_2 = pointF.X;
					double_3 = pointF.Y;
					flag = true;
				}
			}
			double_2 = num2 + double_2;
			double_3 = num3 - double_3;
			if (class3.vmethod_0() == Enum74.const_9)
			{
				class3.method_0().rectangle_1 = new Rectangle(Struct63.smethod_3(double_2), Struct63.smethod_3(double_3), Struct63.smethod_3(sizeF_.Width), Struct63.smethod_3(sizeF_.Height));
				class3.method_0().method_9();
				double_2 = class3.method_0().rectangle_0.X;
				double_3 = class3.method_0().rectangle_0.Y;
			}
			RectangleF rectangleF = new RectangleF((float)double_2, (float)double_3, sizeF_.Width, sizeF_.Height);
			num6 += num5;
			num4 -= num5;
			class3.rectangleF_0 = rectangleF;
			class3.rectangleF_1 = rectangleF;
		}
	}

	private static void smethod_18(ref double double_0, ref double double_1, double double_2, SizeF sizeF_0)
	{
		if (double_2 <= -67.5 && double_2 >= -112.5)
		{
			double_0 -= (-67.5 - double_2) * (double)sizeF_0.Width / 45.0;
		}
		else if (double_2 <= -112.5 && double_2 >= -247.5)
		{
			double_0 -= sizeF_0.Width;
		}
		else if (double_2 <= -247.5 && double_2 >= -292.5)
		{
			double_0 -= (double_2 - -292.5) * (double)sizeF_0.Width / 45.0;
		}
		else if (double_2 >= 67.5 && double_2 <= 90.0)
		{
			double_0 -= (double_2 - 67.5) * (double)sizeF_0.Width / 45.0;
		}
		if (double_2 <= -135.0 && double_2 >= -225.0)
		{
			double_1 += (-135.0 - double_2) * (double)sizeF_0.Height / 90.0;
		}
		else if ((double_2 <= -225.0 && double_2 >= -315.0) || (double_2 <= 90.0 && double_2 >= 45.0))
		{
			double_1 += sizeF_0.Height;
		}
		else if (double_2 < -315.0 && double_2 >= -360.0)
		{
			double_1 += (double_2 - -405.0) * (double)sizeF_0.Height / 90.0;
		}
		else if (double_2 <= 45.0 && double_2 >= -45.0)
		{
			double_1 += (double_2 - -45.0) * (double)sizeF_0.Height / 90.0;
		}
	}

	private static void smethod_19(ref double double_0, ref double double_1, double double_2, SizeF sizeF_0)
	{
		if (double_2 >= -112.5 && double_2 <= -67.5)
		{
			double_0 -= (double_2 - -112.5) * (double)sizeF_0.Width / 45.0;
		}
		else if (double_2 >= -292.5 && double_2 <= -247.5)
		{
			double_0 -= (-247.5 - double_2) * (double)sizeF_0.Width / 45.0;
		}
		else if (double_2 > 67.5 && double_2 <= 90.0)
		{
			double_0 -= (112.5 - double_2) * (double)sizeF_0.Width / 45.0;
		}
		else if ((double_2 >= -67.5 && double_2 <= 67.5) || double_2 <= -292.5)
		{
			double_0 -= sizeF_0.Width;
		}
		if (double_2 <= 22.5 && double_2 >= -22.5)
		{
			double_1 += (22.5 - double_2) * (double)sizeF_0.Height / 45.0;
		}
		else if (double_2 <= -337.5)
		{
			double_1 += (-337.5 - double_2) * (double)sizeF_0.Height / 45.0;
		}
		else if (double_2 >= -202.5 && double_2 <= -157.5)
		{
			double_1 += (double_2 - -202.5) * (double)sizeF_0.Height / 45.0;
		}
		else if (double_2 >= -157.5 && double_2 <= -22.5)
		{
			double_1 += sizeF_0.Height;
		}
	}

	private static bool smethod_20(Interface42 interface42_0, float float_2, float float_3, float float_4, float float_5, float float_6, RectangleF rectangleF_0, Class832 class832_0)
	{
		Class821 chart = class832_0.method_0().Chart;
		GraphicsPath graphicsPath = new GraphicsPath();
		RectangleF rect = new RectangleF(-chart.Width / 2, -chart.Height / 2, chart.Width, chart.Height);
		graphicsPath.AddRectangle(rect);
		GraphicsPath graphicsPath2 = new GraphicsPath();
		double num = (double)(float_3 - float_4 / 2f) * Math.PI / 180.0 % (Math.PI * 2.0);
		double num2 = (double)float_6 * Math.Cos(num);
		double num3 = (double)float_6 * Math.Sin(num);
		RectangleF rectangleF = new RectangleF((float)num2 - float_5, (float)num3 + float_5, 2f * float_5, 2f * float_5);
		graphicsPath2.AddPie(rectangleF.X, 0f - rectangleF.Y, rectangleF.Width, rectangleF.Height, float_2, float_4);
		Region region = new Region(graphicsPath);
		region.Xor(graphicsPath2);
		if (class832_0.method_0().method_2().Formatting == Enum71.const_0 || class832_0.method_0().method_2().Color.IsEmpty)
		{
			rectangleF_0.Inflate(-Struct51.int_0, -Struct51.int_0);
		}
		region.Intersect(new RectangleF(rectangleF_0.X, 0f - rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height));
		if (interface42_0.imethod_0().imethod_1(region))
		{
			region.Dispose();
			region = null;
			return true;
		}
		region.Dispose();
		region = null;
		return false;
	}

	private static PointF smethod_21(Interface42 interface42_0, float float_2, float float_3, float float_4, float float_5, float float_6, SizeF sizeF_0, Class832 class832_0)
	{
		float num = float_3 - float_4 / 2f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = -0.5f;
		bool flag = false;
		if ((num > -90f && num < 0f) || (num >= -270f && num < -180f))
		{
			flag = false;
			float num5 = num;
			while (num5 > float_3 - float_4)
			{
				num5 += num4;
				RectangleF rectangleF_ = smethod_22(float_5, num5, sizeF_0, float_3, float_4, float_6);
				num2 += num4;
				if (smethod_20(interface42_0, float_2, float_3, float_4, float_5, float_6, rectangleF_, class832_0))
				{
					num3 += num4;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					return smethod_22(float_5, num + num2 - num3 / 2f, sizeF_0, float_3, float_4, float_6).Location;
				}
			}
			if (flag)
			{
				return smethod_22(float_5, num + num2 - num3 / 2f, sizeF_0, float_3, float_4, float_6).Location;
			}
			flag = false;
			num5 = num;
			num2 = 0f;
			num3 = 0f;
			while (num5 < float_3)
			{
				num5 -= num4;
				RectangleF rectangleF_2 = smethod_22(float_5, num5, sizeF_0, float_3, float_4, float_6);
				num2 -= num4;
				if (smethod_20(interface42_0, float_2, float_3, float_4, float_5, float_6, rectangleF_2, class832_0))
				{
					num3 -= num4;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					return smethod_22(float_5, num + num2 - num3 / 2f, sizeF_0, float_3, float_4, float_6).Location;
				}
			}
			if (flag)
			{
				return smethod_22(float_5, num + num2 - num3 / 2f, sizeF_0, float_3, float_4, float_6).Location;
			}
		}
		else
		{
			flag = false;
			float num6 = num;
			while (num6 < float_3)
			{
				num6 -= num4;
				RectangleF rectangleF_3 = smethod_22(float_5, num6, sizeF_0, float_3, float_4, float_6);
				num2 -= num4;
				if (smethod_20(interface42_0, float_2, float_3, float_4, float_5, float_6, rectangleF_3, class832_0))
				{
					num3 -= num4;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					return smethod_22(float_5, num + num2 - num3 / 2f, sizeF_0, float_3, float_4, float_6).Location;
				}
			}
			if (flag)
			{
				return smethod_22(float_5, num + num2 - num3 / 2f, sizeF_0, float_3, float_4, float_6).Location;
			}
			flag = false;
			num6 = num;
			num2 = 0f;
			num3 = 0f;
			while (num6 > float_3 - float_4)
			{
				num6 += num4;
				RectangleF rectangleF_4 = smethod_22(float_5, num6, sizeF_0, float_3, float_4, float_6);
				num2 += num4;
				if (smethod_20(interface42_0, float_2, float_3, float_4, float_5, float_6, rectangleF_4, class832_0))
				{
					num3 += num4;
					if (!flag)
					{
						flag = true;
					}
				}
				else if (flag)
				{
					return smethod_22(float_5, num + num2 - num3 / 2f, sizeF_0, float_3, float_4, float_6).Location;
				}
			}
			if (flag)
			{
				return smethod_22(float_5, num + num2 - num3 / 2f, sizeF_0, float_3, float_4, float_6).Location;
			}
		}
		return PointF.Empty;
	}

	private static RectangleF smethod_22(double double_0, double double_1, SizeF sizeF_0, float float_2, float float_3, float float_4)
	{
		double_1 %= 360.0;
		double num = double_1 * Math.PI / 180.0;
		double_0 -= double_0 * 0.03;
		double num2 = double_0 * Math.Cos(num);
		double num3 = double_0 * Math.Sin(num);
		if ((double_1 < 90.0 && double_1 > -90.0) || double_1 < -270.0)
		{
			num2 -= (double)sizeF_0.Width;
		}
		if (double_1 > -180.0 && double_1 < 0.0)
		{
			num3 += (double)sizeF_0.Height;
		}
		num = (double)(float_2 - float_3 / 2f) * Math.PI / 180.0 % (Math.PI * 2.0);
		double num4 = (double)float_4 * Math.Cos(num);
		double num5 = (double)float_4 * Math.Sin(num);
		num2 += num4;
		num3 += num5;
		return new RectangleF((float)num2, (float)num3, sizeF_0.Width, sizeF_0.Height);
	}

	private static double smethod_23(double double_0, double double_1)
	{
		if (double_1 == 0.0)
		{
			return 0.0;
		}
		return Math.Abs(double_0) / double_1 * 360.0;
	}

	internal static RectangleF smethod_24(RectangleF rectangleF_0, double double_0, double double_1)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, (float)double_0, (float)double_1);
		graphicsPath.Widen(new Pen(Color.Black, 1f));
		return Class1181.smethod_1(graphicsPath);
	}

	internal static SizeF smethod_25(Interface42 interface42_0, Class842 class842_0, int int_0, int int_1, double double_0, float float_2, float float_3, double double_1)
	{
		Class844 @class = class842_0.method_9(int_0);
		Class821 chart = @class.Chart;
		Class831 class2 = @class.method_9().method_1(int_1);
		if (class2 == null)
		{
			class2 = @class.method_0();
		}
		Enum53 @enum = @class.method_20();
		Class823 class3;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class3 = chart.method_1();
			arrayList = chart.method_7().method_0();
		}
		else
		{
			class3 = chart.method_2();
			arrayList = chart.method_7().method_2();
		}
		Class832 class4 = class2.method_6();
		string name = @class.Name;
		_ = class4.LinkedSource;
		if (!class4.IsPercentageShown)
		{
		}
		string text = (class4.IsPercentageShown ? "" : class4.imethod_2());
		text = ((int_1 < 0 || int_1 >= arrayList.Count) ? "" : ((Class825)arrayList[int_1]).imethod_3());
		bool bool_ = int_1 >= 0 && int_1 < arrayList.Count && ((Class825)arrayList[int_1]).imethod_1();
		string text2 = ((int_1 < 0 || int_1 >= class3.arrayList_1.Count) ? "Other" : Struct51.smethod_5(chart.vmethod_2(), class3.arrayList_1[int_1], text, bool_));
		bool flag = class4.LinkedSource;
		if (class4.IsPercentageShown)
		{
			flag = true;
		}
		string string_ = (class4.IsPercentageShown ? "" : class4.imethod_2());
		string text3 = ((!flag) ? ((int_1 == -1) ? Struct51.smethod_5(chart.vmethod_2(), double_1, string_, class4.vmethod_1()) : Struct51.smethod_5(chart.vmethod_2(), class2.YValue, string_, class4.vmethod_1())) : ((int_1 == -1) ? Struct51.smethod_5(chart.vmethod_2(), double_1, string_, class4.vmethod_1()) : Struct51.smethod_5(chart.vmethod_2(), class2.YValue, class2.vmethod_6(), class2.vmethod_7())));
		string text4;
		if (class4.LinkedSource)
		{
			text4 = Struct51.smethod_5(chart.vmethod_2(), double_0, "0%", bool_0: false);
		}
		else
		{
			string string_2 = ((class4.imethod_2() == "") ? "0%" : class4.imethod_2());
			text4 = Struct51.smethod_5(chart.vmethod_2(), double_0, string_2, class4.vmethod_1());
		}
		string text5 = Struct51.smethod_4(class4);
		Font font = class4.method_0().Font;
		int rotation = class4.Rotation;
		Enum82 textHorizontalAlignment = class4.TextHorizontalAlignment;
		Enum82 textVerticalAlignment = class4.TextVerticalAlignment;
		SizeF sizeF = new SizeF(class4.method_4(), class4.method_6());
		string text6 = "";
		if (class4.Text == null)
		{
			if (class4.IsSeriesNameShown)
			{
				text6 += name;
			}
			if (class4.IsCategoryNameShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text2;
			}
			if (class4.IsValueShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text3;
			}
			if (class4.IsPercentageShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text4;
			}
		}
		else
		{
			text6 = class4.Text;
		}
		SizeF sizeF_ = new SizeF(float_2, float_3);
		Size size = Struct61.smethod_3(interface42_0, text6, rotation, font, sizeF_, textHorizontalAlignment, textVerticalAlignment);
		if (text6 == "")
		{
			return new SizeF(0f, 0f);
		}
		SizeF result = ((!class4.IsLegendKeyShown) ? new SizeF(size.Width, size.Height) : new SizeF((float)size.Width + sizeF.Width, size.Height));
		if (class4.IsLegendKeyShown)
		{
			result.Width += 2 * Struct51.int_0;
		}
		result.Height += 2 * Struct51.int_0;
		return result;
	}

	internal static void smethod_26(Interface42 interface42_0, Class821 class821_0, int int_0, int int_1, double double_0, RectangleF rectangleF_0, double double_1)
	{
		class821_0.method_29(ref rectangleF_0);
		Class844 @class = class821_0.method_7().method_9(int_0);
		Class831 class2 = @class.method_9().method_1(int_1);
		if (class2 == null)
		{
			class2 = @class.method_0();
		}
		Enum53 @enum = @class.method_20();
		Class823 class3;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class3 = class821_0.method_1();
			arrayList = class821_0.method_7().method_0();
		}
		else
		{
			class3 = class821_0.method_2();
			arrayList = class821_0.method_7().method_2();
		}
		Class832 class4 = class2.method_6();
		string name = @class.Name;
		_ = class4.LinkedSource;
		if (!class4.IsPercentageShown)
		{
		}
		string text = (class4.IsPercentageShown ? "" : class4.imethod_2());
		bool flag = false;
		text = ((int_1 < 0 || int_1 >= arrayList.Count) ? "" : ((Class825)arrayList[int_1]).imethod_3());
		bool bool_ = int_1 >= 0 && int_1 < arrayList.Count && ((Class825)arrayList[int_1]).imethod_1();
		string text2 = ((int_1 < 0 || int_1 >= class3.arrayList_1.Count) ? "Other" : Struct51.smethod_5(class821_0.vmethod_2(), class3.arrayList_1[int_1], text, bool_));
		if (int_1 >= 0 && int_1 < class3.arrayList_1.Count)
		{
			flag = Struct51.smethod_7(class3.arrayList_1[int_1], text);
		}
		bool flag2 = class4.LinkedSource;
		if (class4.IsPercentageShown)
		{
			flag2 = true;
		}
		string string_ = (class4.IsPercentageShown ? "" : class4.imethod_2());
		bool flag3 = false;
		string text3;
		if (flag2)
		{
			text3 = ((int_1 == -1) ? Struct51.smethod_5(class821_0.vmethod_2(), double_1, string_, class4.vmethod_1()) : Struct51.smethod_5(class821_0.vmethod_2(), class2.YValue, class2.vmethod_6(), class2.vmethod_7()));
			if (int_1 != -1)
			{
				flag3 = Struct51.smethod_7(class2.YValue, class2.vmethod_6());
			}
		}
		else
		{
			text3 = ((int_1 == -1) ? Struct51.smethod_5(class821_0.vmethod_2(), double_1, string_, class4.vmethod_1()) : Struct51.smethod_5(class821_0.vmethod_2(), class2.YValue, string_, class4.vmethod_1()));
		}
		string text4;
		if (class4.LinkedSource)
		{
			text4 = Struct51.smethod_5(class821_0.vmethod_2(), double_0, "0%", bool_0: false);
		}
		else
		{
			string string_2 = ((class4.imethod_2() == "") ? "0%" : class4.imethod_2());
			text4 = Struct51.smethod_5(class821_0.vmethod_2(), double_0, string_2, class4.vmethod_1());
		}
		string text5 = Struct51.smethod_4(class4);
		Font font = class4.method_0().Font;
		Color color_ = class4.method_0().FontColor;
		int rotation = class4.Rotation;
		Enum82 textHorizontalAlignment = class4.TextHorizontalAlignment;
		Enum82 textVerticalAlignment = class4.TextVerticalAlignment;
		SizeF sizeF = new SizeF(class4.method_4(), class4.method_6());
		class4.method_0().rectangle_1 = new Rectangle((int)rectangleF_0.X, (int)rectangleF_0.Y, (int)rectangleF_0.Width, (int)rectangleF_0.Height);
		class4.method_0().rectangle_0 = class4.method_0().rectangle_1;
		class4.method_0().method_19();
		int num = (class4.IsLegendKeyShown ? ((int)(rectangleF_0.X + (float)Struct51.int_0)) : ((int)rectangleF_0.X));
		int y = (int)rectangleF_0.Y + Struct51.int_0;
		int num2 = (class4.IsLegendKeyShown ? ((int)(rectangleF_0.Width - (float)(2 * Struct51.int_0))) : ((int)rectangleF_0.Width));
		int height = (int)rectangleF_0.Height - 2 * Struct51.int_0;
		if (class4.IsLegendKeyShown)
		{
			RectangleF rectangleF_ = new RectangleF(rectangleF_0.X + (float)Struct51.int_0, rectangleF_0.Y + (float)Struct51.int_0, sizeF.Width, sizeF.Height);
			Struct53.smethod_9(interface42_0, rectangleF_, @class, int_1);
			num += (int)sizeF.Width;
			num2 -= (int)sizeF.Width;
		}
		string text6 = "";
		if (class4.Text == null)
		{
			if (class4.IsSeriesNameShown)
			{
				text6 += name;
			}
			if (class4.IsCategoryNameShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text2;
			}
			if (class4.IsValueShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text3;
			}
			if (class4.IsPercentageShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text4;
			}
		}
		else
		{
			text6 = class4.Text;
		}
		if (text6 != "")
		{
			Rectangle rectangle_ = new Rectangle(num, y, num2, height);
			if (flag || flag3)
			{
				color_ = Color.Red;
			}
			smethod_27(interface42_0, class4, rectangle_, text6, rotation, font, color_, textHorizontalAlignment, textVerticalAlignment);
		}
	}

	public static void smethod_27(Interface42 interface42_0, Class832 class832_0, Rectangle rectangle_0, string string_0, int int_0, Font font_0, Color color_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		bool flag = false;
		TextRenderingHint textRenderingHint_ = interface42_0.imethod_56();
		if (class832_0.method_0().Chart.method_3().method_1().method_2() && class832_0.method_0().method_1().method_2() && class832_0.vmethod_0() == Enum74.const_4)
		{
			flag = true;
			interface42_0.imethod_57(TextRenderingHint.AntiAlias);
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = Struct61.smethod_13(enum82_0);
		stringFormat.LineAlignment = Struct61.smethod_13(enum82_1);
		Brush brush = new SolidBrush(color_0);
		switch (Math.Abs(int_0))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rectangle_0.Width, 2.0) + Math.Pow(rectangle_0.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = interface42_0.imethod_43(string_0, font_0, (int)num, stringFormat);
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_0);
			RectangleF rectangleF_ = new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height);
			interface42_0.imethod_27(string_0, font_0, brush, rectangleF_, stringFormat);
			interface42_0.ResetTransform();
			break;
		}
		case 90:
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_0);
			rectangle_0 = new Rectangle(-rectangle_0.Height / 2, -rectangle_0.Width / 2, rectangle_0.Height, rectangle_0.Width);
			interface42_0.imethod_28(string_0, font_0, brush, rectangle_0, stringFormat);
			interface42_0.ResetTransform();
			break;
		case 0:
			interface42_0.imethod_28(string_0, font_0, brush, rectangle_0, stringFormat);
			break;
		}
		brush.Dispose();
		if (flag)
		{
			interface42_0.imethod_57(textRenderingHint_);
		}
	}
}
