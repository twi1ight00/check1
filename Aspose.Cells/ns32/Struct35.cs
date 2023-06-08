using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns22;
using ns3;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct35
{
	private static float float_0 = 0.05f;

	private static float float_1 = 0.6f;

	internal static void smethod_0(Interface42 interface42_0, Rectangle rectangle_0, Class810 class810_0)
	{
		Class787 chart = class810_0.Chart;
		IList ilist_ = chart.method_7().method_17(class810_0.method_21(), new ChartType_Chart[1] { class810_0.Type });
		if (chart.method_7().method_19(class810_0, class810_0.method_21(), new ChartType_Chart[1] { class810_0.Type }) == 0)
		{
			switch (class810_0.Type)
			{
			case ChartType_Chart.Pie:
				smethod_16(interface42_0, chart, ref rectangle_0, class810_0);
				chart.method_8().rectangle_1 = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
				Struct24.smethod_0(interface42_0, chart.method_8());
				smethod_2(interface42_0, chart, rectangle_0, class810_0);
				break;
			case ChartType_Chart.PiePie:
				smethod_11(interface42_0, chart, rectangle_0, class810_0);
				break;
			case ChartType_Chart.PieExploded:
				smethod_16(interface42_0, chart, ref rectangle_0, class810_0);
				chart.method_8().rectangle_1 = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
				Struct24.smethod_0(interface42_0, chart.method_8());
				smethod_10(interface42_0, chart, rectangle_0, class810_0);
				break;
			case ChartType_Chart.PieBar:
				smethod_13(interface42_0, chart, rectangle_0, class810_0);
				break;
			case ChartType_Chart.Doughnut:
				smethod_14(interface42_0, chart, rectangle_0, ilist_);
				break;
			case ChartType_Chart.DoughnutExploded:
				smethod_15(interface42_0, chart, rectangle_0, ilist_);
				break;
			}
		}
	}

	internal static void smethod_1(Class787 class787_0, ref Rectangle rectangle_0, Class810 class810_0)
	{
		if (rectangle_0.Width > 0 && rectangle_0.Height > 0 && class810_0.method_34() && class787_0.method_8().imethod_3())
		{
			rectangle_0.X += 9;
			rectangle_0.Y += 9;
			rectangle_0.Width -= 2 * 9;
			rectangle_0.Height -= 2 * 9;
			int num = 0;
			int num2 = rectangle_0.Width;
			if (rectangle_0.Width > rectangle_0.Height)
			{
				num2 = rectangle_0.Height;
			}
			num = ((num2 < 80) ? (-Struct40.smethod_4((float)(80 - num2) / 100f * 6f)) : ((num2 >= 200) ? Struct40.smethod_4((float)(num2 - 80) / 100f * 7f) : Struct40.smethod_3((float)(num2 - 80) / 100f * 7f)));
			rectangle_0.X += num;
			rectangle_0.Y += num;
			rectangle_0.Width -= 2 * num;
			rectangle_0.Height -= 2 * num;
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
	}

	private static void smethod_2(Interface42 interface42_0, Class787 class787_0, Rectangle rectangle_0, Class810 class810_0)
	{
		int index = class810_0.Index;
		double num = 0.0;
		Class795 @class = class810_0.method_10();
		for (int i = 0; i < @class.Count; i++)
		{
			num += Math.Abs(@class[i].YValue);
		}
		double num2 = (float)class810_0.vmethod_1() - 90f;
		double num3 = 0.0;
		double num4 = 90 - class810_0.vmethod_1();
		GraphicsPath graphicsPath = new GraphicsPath();
		ArrayList arrayList = new ArrayList();
		double num5 = (double)rectangle_0.Width / 2.0 / (double)(1f + class810_0.Explosion / 100f);
		double num6 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num7 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		RectangleF rectangleF = new RectangleF((float)(num6 - num5), (float)(num7 - num5), (float)(2.0 * num5), (float)(2.0 * num5));
		for (int j = 0; j < @class.Count; j++)
		{
			Class796 class2 = @class.method_1(j);
			num3 = smethod_36(@class[j].YValue, num);
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num2, (float)((num3 == 0.0) ? 0.01 : num3));
			RectangleF rectangleF_ = smethod_37(rectangleF, (float)num2, (float)((num3 == 0.0) ? 0.01 : num3));
			using (Brush brush_ = Struct18.smethod_1(class2.method_3(), rectangleF_))
			{
				if (class2.Explosion > 0f)
				{
					smethod_9(class2, rectangleF, num2, (float)((num3 == 0.0) ? 0.01 : num3), num4);
					interface42_0.imethod_33(brush_, graphicsPath2);
					graphicsPath.AddPath(graphicsPath2, connect: false);
					arrayList.Add(graphicsPath2);
					interface42_0.ResetTransform();
				}
				else
				{
					interface42_0.imethod_33(brush_, graphicsPath2);
					graphicsPath.AddPath(graphicsPath2, connect: false);
					arrayList.Add(graphicsPath2);
				}
			}
			num2 += num3;
			num4 -= num3;
		}
		num2 = (float)class810_0.vmethod_1() - 90f;
		num3 = 0.0;
		PointF pt = PointF.Empty;
		PointF pointF = PointF.Empty;
		PointF pointF2 = new PointF((float)num6, (float)num7);
		num4 = 90 - class810_0.vmethod_1();
		bool flag = false;
		for (int k = 0; k < @class.Count; k++)
		{
			Class796 class3 = @class.method_1(k);
			using (Pen pen_ = Struct29.smethod_5(class3.method_4()))
			{
				num3 = smethod_36(@class[k].YValue, num);
				if (k == 0)
				{
					pt = smethod_6(num6, num7, num4, num5);
				}
				pointF = smethod_6(num6, num7, num4 - num3, num5);
				if (class3.Explosion > 0f)
				{
					smethod_9(class3, rectangleF, num2, (float)((num3 == 0.0) ? 0.01 : num3), num4);
				}
				if (num3 == 0.0 && class3.method_4().IsVisible)
				{
					interface42_0.imethod_16(pen_, pointF2.X, pointF2.Y, pointF.X, pointF.Y);
				}
				else if (class3.method_4().IsVisible)
				{
					GraphicsPath graphicsPath3 = new GraphicsPath();
					if (num3 == 360.0)
					{
						graphicsPath3.AddArc(rectangleF, (float)num2, (float)num3);
					}
					else
					{
						graphicsPath3.AddLine(pointF2, pt);
						graphicsPath3.AddArc(rectangleF, (float)num2, (float)num3);
						graphicsPath3.AddLine(pointF, pointF2);
					}
					interface42_0.imethod_18(pen_, graphicsPath3);
				}
			}
			if (!flag && class3.method_4().IsVisible && class3.Explosion <= 0f)
			{
				interface42_0.imethod_34(new SolidBrush(Color.Black), pointF2.X - 0.5f, pointF2.Y - 0.5f, 1f, 1f, 0f, 360f);
				flag = true;
			}
			if (class3.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num2 += num3;
			num4 -= num3;
			pt = pointF;
		}
		num2 = 90f - (float)class810_0.vmethod_1();
		num3 = 0.0;
		_ = @class.Count;
		float float_ = (float)(num5 * (double)float_0);
		RectangleF rectangleF_2 = Class1181.smethod_1(graphicsPath);
		for (int l = 0; l < @class.Count; l++)
		{
			Class796 class4 = @class.method_1(l);
			Class798 class5 = class4.method_6();
			if (class5.IsVisible)
			{
				double double_ = ((num == 0.0) ? 0.01 : (Math.Abs(@class[l].YValue) / num));
				num3 = smethod_36(@class[l].YValue, num);
				double num8 = (num2 - num3 / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
				double num9 = class4.Explosion / 100f;
				double num10 = (1.0 + num9) * num5 * Math.Cos(num8);
				double num11 = (1.0 + num9) * num5 * Math.Sin(num8);
				class5.pointF_0 = new PointF((float)(num6 + num10), (float)(num7 - num11));
				RectangleF rectangleF_3 = class5.rectangleF_1;
				smethod_39(interface42_0, class787_0, index, l, double_, rectangleF_3, 0.0);
				if (class810_0.HasLeaderLines && !class5.pointF_1.IsEmpty && !class5.pointF_2.IsEmpty)
				{
					smethod_3(interface42_0, rectangleF_2, arrayList, class810_0.method_15(), rectangleF_3, class5.pointF_0, float_);
				}
				num2 -= num3;
			}
		}
	}

	private static void smethod_3(Interface42 interface42_0, RectangleF rectangleF_0, ArrayList arrayList_0, Class806 class806_0, RectangleF rectangleF_1, PointF pointF_0, float float_2)
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
		PointF pt2 = new PointF(rectangleF_1.Left, rectangleF_1.Top + rectangleF_1.Height / 2f);
		PointF pt3 = new PointF(rectangleF_1.Left + rectangleF_1.Width / 2f, rectangleF_1.Top);
		PointF pt4 = new PointF(rectangleF_1.Right, rectangleF_1.Top + rectangleF_1.Height / 2f);
		PointF pt5 = new PointF(rectangleF_1.Left + rectangleF_1.Width / 2f, rectangleF_1.Bottom);
		int num = smethod_5(pointF_0, rectangleF_1);
		using Pen pen = Struct29.smethod_5(class806_0);
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF empty = PointF.Empty;
		switch (num)
		{
		case 1:
			empty = new PointF(pt4.X + float_2, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath7 = new GraphicsPath();
				graphicsPath7.AddLine(pt4, empty);
				graphicsPath7.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath7);
				graphicsPath7.Dispose();
			}
			break;
		case 2:
			empty = new PointF(pt4.X + float_2, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.X <= pointF_0.X)
			{
				GraphicsPath graphicsPath8 = new GraphicsPath();
				graphicsPath8.AddLine(pt4, empty);
				graphicsPath8.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath8);
				graphicsPath8.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + float_2);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath9 = new GraphicsPath();
				graphicsPath9.AddLine(pt5, empty);
				graphicsPath9.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath9);
				graphicsPath9.Dispose();
			}
			break;
		case 3:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt5.X, pt5.Y + float_2);
			graphicsPath.AddLine(pt5, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.Y <= pointF_0.Y)
			{
				GraphicsPath graphicsPath6 = new GraphicsPath();
				graphicsPath6.AddLine(pt5, empty);
				graphicsPath6.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath6);
				graphicsPath6.Dispose();
			}
			break;
		case 4:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - float_2, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.X >= pointF_0.X)
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
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.Y <= pointF_0.Y)
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
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath10 = new GraphicsPath();
				graphicsPath10.AddLine(pt2, empty);
				graphicsPath10.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath10);
				graphicsPath10.Dispose();
			}
			break;
		case 6:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt2.X - float_2, pt2.Y);
			graphicsPath.AddLine(pt2, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.X >= pointF_0.X)
			{
				GraphicsPath graphicsPath4 = new GraphicsPath();
				graphicsPath4.AddLine(pt2, empty);
				graphicsPath4.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath4);
				graphicsPath4.Dispose();
				break;
			}
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - float_2);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath5 = new GraphicsPath();
				graphicsPath5.AddLine(pt3, empty);
				graphicsPath5.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath5);
				graphicsPath5.Dispose();
			}
			break;
		case 7:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt3.X, pt3.Y - float_2);
			graphicsPath.AddLine(pt3, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath11 = new GraphicsPath();
				graphicsPath11.AddLine(pt3, empty);
				graphicsPath11.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath11);
				graphicsPath11.Dispose();
			}
			break;
		case 8:
			graphicsPath = new GraphicsPath();
			empty = new PointF(pt4.X + float_2, pt4.Y);
			graphicsPath.AddLine(pt4, empty);
			graphicsPath.AddLine(empty, pt);
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.X <= pointF_0.X)
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
			graphicsPath.Widen(pen);
			if (smethod_4(interface42_0, graphicsPath, arrayList_0) && empty.Y >= pointF_0.Y)
			{
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddLine(pt3, empty);
				graphicsPath3.AddLine(empty, pointF_0);
				interface42_0.imethod_18(pen, graphicsPath3);
				graphicsPath3.Dispose();
			}
			break;
		}
	}

	private static bool smethod_4(Interface42 interface42_0, GraphicsPath graphicsPath_0, ArrayList arrayList_0)
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

	private static int smethod_5(PointF pointF_0, RectangleF rectangleF_0)
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

	private static PointF smethod_6(double double_0, double double_1, double double_2, double double_3)
	{
		double num = double_2 * Math.PI / 180.0 % (Math.PI * 2.0);
		double num2 = double_3 * Math.Cos(num);
		double num3 = double_3 * Math.Sin(num);
		num2 = double_0 + num2;
		num3 = double_1 - num3;
		return new PointF((float)num2, (float)num3);
	}

	private static bool smethod_7(RectangleF rectangleF_0, Rectangle rectangle_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		return smethod_8(rectangleF_0, rectangleF_);
	}

	private static bool smethod_8(RectangleF rectangleF_0, RectangleF rectangleF_1)
	{
		if (rectangleF_0.Left >= rectangleF_1.Left && rectangleF_0.Right <= rectangleF_1.Right && rectangleF_0.Top >= rectangleF_1.Top && rectangleF_0.Bottom <= rectangleF_1.Bottom)
		{
			return true;
		}
		return false;
	}

	private static void smethod_9(Class796 class796_0, RectangleF rectangleF_0, double double_0, double double_1, double double_2)
	{
		Class787 chart = class796_0.Chart;
		Interface42 @interface = chart.imethod_0();
		Rectangle rectangle_ = new Rectangle(0, 0, chart.Width, chart.Height);
		float num = class796_0.Explosion;
		double num2 = (double)rectangleF_0.X + (double)rectangleF_0.Width / 2.0;
		double num3 = (double)rectangleF_0.Y + (double)rectangleF_0.Height / 2.0;
		double num4 = (double)rectangleF_0.Width / 2.0;
		double double_3 = num4 * (double)num / 100.0;
		PointF pointF = smethod_6(num2, num3, double_2 - double_1 / 2.0, double_3);
		RectangleF rectangleF_ = new RectangleF((float)((double)pointF.X - num4), (float)((double)pointF.Y - num4), rectangleF_0.Width, rectangleF_0.Height);
		RectangleF rectangleF_2 = smethod_37(rectangleF_, double_0, double_1);
		if (num > 0f)
		{
			while (!smethod_7(rectangleF_2, rectangle_) && !(num <= 0f))
			{
				num -= 1f;
				double_3 = num4 * (double)num / 100.0;
				pointF = smethod_6(num2, num3, double_2 - double_1 / 2.0, double_3);
				rectangleF_ = new RectangleF((float)((double)pointF.X - num4), (float)((double)pointF.Y - num4), rectangleF_0.Width, rectangleF_0.Height);
				rectangleF_2 = smethod_37(rectangleF_, double_0, double_1);
			}
		}
		else
		{
			while (!smethod_7(rectangleF_2, rectangle_) && !(num >= 0f))
			{
				num += 1f;
				double_3 = num4 * (double)num / 100.0;
				pointF = smethod_6(num2, num3, double_2 - double_1 / 2.0, double_3);
				rectangleF_ = new RectangleF((float)((double)pointF.X - num4), (float)((double)pointF.Y - num4), rectangleF_0.Width, rectangleF_0.Height);
				rectangleF_2 = smethod_37(rectangleF_, double_0, double_1);
			}
		}
		Matrix matrix = new Matrix();
		matrix.Translate((float)((double)pointF.X - num2), (float)((double)pointF.Y - num3));
		@interface.imethod_58(matrix);
	}

	private static void smethod_10(Interface42 interface42_0, Class787 class787_0, Rectangle rectangle_0, Class810 class810_0)
	{
		class787_0.method_7();
		int index = class810_0.Index;
		double num = 0.0;
		Class795 @class = class810_0.method_10();
		for (int i = 0; i < @class.Count; i++)
		{
			num += Math.Abs(@class[i].YValue);
		}
		double num2 = (double)rectangle_0.X + (double)rectangle_0.Width / 2.0;
		double num3 = (double)rectangle_0.Y + (double)rectangle_0.Height / 2.0;
		double num4 = (float)class810_0.vmethod_1() - 90f;
		double num5 = 0.0;
		double num6 = 90f - (float)class810_0.vmethod_1();
		GraphicsPath graphicsPath = new GraphicsPath();
		ArrayList arrayList = new ArrayList();
		double num7 = (double)rectangle_0.Width / 2.0 / (double)(1f + class810_0.Explosion / 100f);
		for (int j = 0; j < @class.Count; j++)
		{
			@class.method_1(j).method_6();
			num5 = smethod_36(@class[j].YValue, num);
			double num8 = (num6 - num5 / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
			Class796 class2 = @class.method_1(j);
			double num9 = class2.Explosion / 100f;
			double num10 = num7 * num9;
			double num11 = num10 * Math.Cos(num8);
			double num12 = num10 * Math.Sin(num8);
			double num13 = num2 + num11;
			double num14 = num3 - num12;
			RectangleF rectangleF_ = new RectangleF((float)(num13 - num7), (float)(num14 - num7), (float)(2.0 * num7), (float)(2.0 * num7));
			if (num5 == 0.0)
			{
				num5 = 0.001;
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			graphicsPath2.AddPie(rectangleF_.X, rectangleF_.Y, rectangleF_.Width, rectangleF_.Height, (float)num4, (float)num5);
			RectangleF rectangleF_2 = smethod_37(rectangleF_, (float)num4, (float)num5);
			using (Brush brush_ = Struct18.smethod_1(class2.method_3(), rectangleF_2))
			{
				interface42_0.imethod_33(brush_, graphicsPath2);
			}
			graphicsPath.AddPath(graphicsPath2, connect: false);
			arrayList.Add(graphicsPath2);
			using (Pen pen_ = Struct29.smethod_5(class2.method_4()))
			{
				interface42_0.imethod_18(pen_, graphicsPath2);
			}
			num4 += num5;
			num6 -= num5;
		}
		num6 = 90f - (float)class810_0.vmethod_1();
		RectangleF rectangleF_3 = Class1181.smethod_1(graphicsPath);
		for (int k = 0; k < @class.Count; k++)
		{
			Class796 class3 = @class.method_1(k);
			Class798 class4 = class3.method_6();
			double double_ = ((num == 0.0) ? 0.01 : (Math.Abs(class3.YValue) / num));
			num5 = smethod_36(@class[k].YValue, num);
			double num15 = (num6 - num5 / 2.0) % 360.0;
			double num16 = (class4.double_0 = num15 * Math.PI / 180.0);
			double num17 = class3.Explosion / 100f;
			double num18 = (1.0 + num17) * num7 * Math.Cos(num16);
			double num19 = (1.0 + num17) * num7 * Math.Sin(num16);
			num18 = num2 + num18;
			num19 = num3 - num19;
			RectangleF rectangleF_4 = class4.rectangleF_1;
			smethod_39(interface42_0, class787_0, index, k, double_, rectangleF_4, 0.0);
			class4.pointF_0 = new PointF((float)num18, (float)num19);
			float float_ = (float)(num7 * (double)float_0);
			if (class810_0.HasLeaderLines && (class4.vmethod_0() == Enum74.const_9 || class4.vmethod_0() == Enum74.const_0))
			{
				smethod_3(interface42_0, rectangleF_3, arrayList, class810_0.method_15(), rectangleF_4, class4.pointF_0, float_);
			}
			num6 -= num5;
		}
	}

	private static void smethod_11(Interface42 interface42_0, Class787 class787_0, Rectangle rectangle_0, Class810 class810_0)
	{
		int num = class787_0.method_17();
		int num2 = class787_0.method_19();
		class787_0.method_21();
		Class796 @class = class810_0.method_0();
		int num3 = rectangle_0.X + num;
		int num4 = rectangle_0.Y + rectangle_0.Height / 2;
		int num5 = rectangle_0.X + rectangle_0.Width - num2;
		int num6 = rectangle_0.Y + rectangle_0.Height / 2;
		class787_0.method_7();
		int index = class810_0.Index;
		Class795 class2 = class810_0.method_10();
		int count = class2.Count;
		int num7 = 0;
		int num8 = 0;
		if (count == 1)
		{
			num7 = 1;
			num8 = 1;
		}
		else
		{
			if (class810_0.SplitType != 0 && class810_0.SplitValue > 0.0)
			{
				num8 = (int)class810_0.SplitValue;
				if (num8 > count)
				{
					num8 = count;
				}
			}
			else
			{
				num8 = Struct40.smethod_3((float)count / 3f);
			}
			num7 = count - num8 + 1;
		}
		double[] array = new double[num7];
		double[] array2 = new double[num8];
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (i + 1 < num7)
			{
				array[i + 1] = Math.Abs(class2[i].YValue);
				num9 += array[i + 1];
			}
			else
			{
				array2[i + 1 - num7] = Math.Abs(class2[i].YValue);
				num10 += array2[i + 1 - num7];
			}
			num11 += Math.Abs(class2[i].YValue);
		}
		array[0] = num10;
		num9 += num10;
		double num12 = ((num9 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num9 * 360.0 / 2.0));
		if (num7 == 1)
		{
			num12 = 0.0;
		}
		double num13 = 0.0;
		double num14 = (double)num / (double)(1f + class810_0.Explosion / 100f);
		RectangleF rectangleF = new RectangleF((float)((double)num3 - num14), (float)((double)num4 - num14), (float)(2.0 * num14), (float)(2.0 * num14));
		double num15 = 0.0 - num12;
		for (int j = 0; j < array.Length; j++)
		{
			Class796 class3 = null;
			if (array[j] == 0.0)
			{
				continue;
			}
			Color color;
			if (j == 0)
			{
				color = class787_0.method_14(class810_0.vmethod_7()).GetColor(count);
				if (@class != null)
				{
					@class.method_3().method_1(color);
					class3 = @class;
				}
			}
			else
			{
				class3 = class2.method_1(j - 1);
				color = class787_0.method_14(class810_0.vmethod_7()).GetColor(j - 1);
			}
			num13 = smethod_36(array[j], num9);
			if (num13 == 0.0)
			{
				num13 = 0.001;
			}
			if (class3.Explosion > 0f)
			{
				smethod_9(class3, rectangleF, num12, (float)((num13 == 0.0) ? 0.01 : num13), num15);
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num12, (float)num13);
			Brush brush;
			if (class3 != null)
			{
				RectangleF rectangleF_ = smethod_37(rectangleF, (float)num12, (float)num13);
				brush = Struct18.smethod_1(class3.method_3(), rectangleF_);
			}
			else
			{
				brush = new SolidBrush(color);
			}
			interface42_0.imethod_33(brush, graphicsPath);
			brush?.Dispose();
			if (class3.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num12 += num13;
			num15 -= num13;
		}
		num12 = ((num9 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num9 * 360.0 / 2.0));
		if (num7 == 1)
		{
			num12 = 0.0;
		}
		num15 = 0.0 - num12;
		for (int k = 0; k < array.Length; k++)
		{
			Class796 class4 = null;
			if (array[k] == 0.0)
			{
				continue;
			}
			Color color;
			if (k == 0)
			{
				color = Color.Black;
				if (@class != null)
				{
					@class.method_4().method_0(color);
					class4 = @class;
				}
			}
			else
			{
				class4 = class2.method_1(k - 1);
				color = class4.method_4().Color;
			}
			Pen pen = ((class4 == null) ? new Pen(color) : Struct29.smethod_5(class4.method_4()));
			num13 = smethod_36(array[k], num9);
			if (num13 == 0.0)
			{
				num13 = 0.001;
			}
			if (class4.Explosion > 0f)
			{
				smethod_9(class4, rectangleF, num12, (float)((num13 == 0.0) ? 0.01 : num13), num15);
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			if (num13 == 360.0)
			{
				graphicsPath2.AddArc(rectangleF, (float)num12, (float)num13);
			}
			else
			{
				graphicsPath2.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num12, (float)num13);
			}
			interface42_0.imethod_18(pen, graphicsPath2);
			if (class4.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			pen?.Dispose();
			num12 += num13;
			num15 -= num13;
		}
		num12 = ((num9 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num9 * 360.0 / 2.0));
		if (num7 == 1)
		{
			num12 = 0.0;
		}
		double num16 = (double)num2 / (double)(1f + class810_0.Explosion / 100f);
		RectangleF rectangleF2 = new RectangleF((float)((double)num5 - num16), (float)((double)num6 - num16), (float)(2.0 * num16), (float)(2.0 * num16));
		num15 = 0.0 - num12;
		for (int l = 0; l < array2.Length; l++)
		{
			if (array2[l] != 0.0)
			{
				int int_ = array.Length - 1 + l;
				Color color = class787_0.method_14(class810_0.vmethod_7()).GetColor(int_);
				Class796 class5 = class2.method_1(int_);
				num13 = smethod_36(array2[l], num10);
				if (num13 == 0.0)
				{
					num13 = 0.001;
				}
				if (class5.Explosion > 0f)
				{
					smethod_9(class5, rectangleF2, num12, (float)((num13 == 0.0) ? 0.01 : num13), num15);
				}
				GraphicsPath graphicsPath3 = new GraphicsPath();
				graphicsPath3.AddPie(rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height, (float)num12, (float)num13);
				RectangleF rectangleF_2 = smethod_37(rectangleF2, (float)num12, (float)num13);
				using (Brush brush_ = Struct18.smethod_1(class5.method_3(), rectangleF_2))
				{
					interface42_0.imethod_33(brush_, graphicsPath3);
				}
				if (class5.Explosion > 0f)
				{
					interface42_0.ResetTransform();
				}
				num12 += num13;
				num15 -= num13;
			}
		}
		num12 = ((num9 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num9 * 360.0 / 2.0));
		if (num7 == 1)
		{
			num12 = 0.0;
		}
		num15 = 0.0 - num12;
		double[] array3 = new double[array2.Length];
		double[] array4 = new double[array2.Length];
		for (int m = 0; m < array2.Length; m++)
		{
			if (array2[m] == 0.0)
			{
				continue;
			}
			int int_2 = array.Length - 1 + m;
			Class796 class6 = class2.method_1(int_2);
			using (Pen pen_ = Struct29.smethod_5(class6.method_4()))
			{
				num13 = smethod_36(array2[m], num10);
				if (num13 == 0.0)
				{
					num13 = 0.001;
				}
				if (class6.Explosion > 0f)
				{
					smethod_9(class6, rectangleF2, num12, (float)((num13 == 0.0) ? 0.01 : num13), num15);
				}
				GraphicsPath graphicsPath4 = new GraphicsPath();
				if (num13 == 360.0)
				{
					graphicsPath4.AddArc(rectangleF2, (float)num12, (float)num13);
				}
				else
				{
					graphicsPath4.AddPie(rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height, (float)num12, (float)num13);
				}
				interface42_0.imethod_18(pen_, graphicsPath4);
				if (class6.Explosion > 0f)
				{
					interface42_0.ResetTransform();
				}
			}
			array3[m] = num12;
			array4[m] = num13;
			num12 += num13;
			num15 -= num13;
		}
		if (class810_0.HasSeriesLines && num9 != 0.0)
		{
			if (Math.Abs(array[0]) / num9 * 2.0 * Math.PI > Math.PI)
			{
				double num17 = Math.Acos((num14 - (double)num2) / (double)(num5 - num3));
				PointF pointF_ = new PointF((float)((double)num3 + num14 * Math.Cos(num17)), (float)((double)num4 - num14 * Math.Sin(num17)));
				PointF pointF_2 = new PointF((float)((double)num5 + num16 * Math.Cos(num17)), (float)((double)num6 - num16 * Math.Sin(num17)));
				PointF pointF_3 = new PointF((float)((double)num3 + num14 * Math.Cos(0.0 - num17)), (float)((double)num4 - num14 * Math.Sin(0.0 - num17)));
				PointF pointF_4 = new PointF((float)((double)num5 + num16 * Math.Cos(0.0 - num17)), (float)((double)num6 - num16 * Math.Sin(0.0 - num17)));
				if (@class.Explosion > 0f)
				{
					float num18 = (float)(num14 * (double)@class.Explosion / 100.0);
					pointF_.X += num18;
					pointF_3.X += num18;
				}
				int num19 = smethod_12(array3, array4, num17 * 180.0 / Math.PI);
				Class796 class7 = class810_0.method_10().method_1(array.Length - 1 + num19);
				if (class7.Explosion > 0f)
				{
					float num20 = (float)(num16 * (double)class7.Explosion / 100.0);
					double num21 = (360.0 - array3[num19] - array4[num19] / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
					pointF_4.X += (float)((double)num20 * Math.Cos(num21));
					pointF_4.Y -= (float)((double)num20 * Math.Sin(num21));
				}
				num19 = smethod_12(array3, array4, 360.0 - num17 * 180.0 / Math.PI);
				class7 = class810_0.method_10().method_1(array.Length - 1 + num19);
				if (class7.Explosion > 0f)
				{
					float num22 = (float)(num16 * (double)class7.Explosion / 100.0);
					double num23 = (360.0 - array3[num19] - array4[num19] / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
					pointF_2.X += (float)((double)num22 * Math.Cos(num23));
					pointF_2.Y -= (float)((double)num22 * Math.Sin(num23));
				}
				Struct29.smethod_1(interface42_0, pointF_, pointF_2, class810_0.method_18());
				Struct29.smethod_1(interface42_0, pointF_3, pointF_4, class810_0.method_18());
			}
			else
			{
				num12 = ((num9 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num9 * Math.PI));
				if (num7 == 1)
				{
					num12 = 0.0;
				}
				double num24 = (double)num3 + num14 * Math.Cos(num12);
				double num25 = (double)num4 - num14 * Math.Sin(num12);
				double num26 = Math.Sqrt(Math.Pow(num25 - (double)num6, 2.0) + Math.Pow(num24 - (double)num5, 2.0));
				double num17 = Math.Acos(((double)num5 - num24) / num26) + Math.Acos(num16 / num26);
				PointF pointF_5 = new PointF((float)num24, (float)num25);
				PointF pointF_6 = new PointF((float)((double)num5 + num16 * Math.Cos(Math.PI - num17)), (float)((double)num6 - num16 * Math.Sin(Math.PI - num17)));
				PointF pointF_7 = new PointF((float)((double)num3 + num14 * Math.Cos(0.0 - num12)), (float)((double)num4 - num14 * Math.Sin(0.0 - num12)));
				PointF pointF_8 = new PointF((float)((double)num5 + num16 * Math.Cos(num17 + Math.PI)), (float)((double)num6 - num16 * Math.Sin(num17 + Math.PI)));
				if (@class.Explosion > 0f)
				{
					float num27 = (float)(num14 * (double)@class.Explosion / 100.0);
					pointF_5.X += num27;
					pointF_7.X += num27;
				}
				int num28 = smethod_12(array3, array4, num17 * 180.0 / Math.PI);
				Class796 class8 = class810_0.method_10().method_1(array.Length - 1 + num28);
				if (class8.Explosion > 0f)
				{
					float num29 = (float)(num16 * (double)class8.Explosion / 100.0);
					double num30 = (360.0 - array3[num28] - array4[num28] / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
					pointF_8.X += (float)((double)num29 * Math.Cos(num30));
					pointF_8.Y -= (float)((double)num29 * Math.Sin(num30));
				}
				num28 = smethod_12(array3, array4, 360.0 - num17 * 180.0 / Math.PI);
				class8 = class810_0.method_10().method_1(array.Length - 1 + num28);
				if (class8.Explosion > 0f)
				{
					float num31 = (float)(num16 * (double)class8.Explosion / 100.0);
					double num32 = (360.0 - array3[num28] - array4[num28] / 2.0) * Math.PI / 180.0 % (Math.PI * 2.0);
					pointF_6.X += (float)((double)num31 * Math.Cos(num32));
					pointF_6.Y -= (float)((double)num31 * Math.Sin(num32));
				}
				Struct29.smethod_1(interface42_0, pointF_5, pointF_6, class810_0.method_18());
				Struct29.smethod_1(interface42_0, pointF_7, pointF_8, class810_0.method_18());
			}
		}
		Class798 class9 = class810_0.method_3();
		num12 = ((num9 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num9 * 180.0));
		if (num7 == 1)
		{
			num12 = 0.0;
		}
		num13 = 0.0;
		float float_ = class787_0.Height;
		for (int n = 0; n < array.Length + array2.Length; n++)
		{
			Class796 class10 = null;
			double num33 = 0.0;
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
				num33 = class10.Explosion / 100f;
			}
			float float_2 = ((!class9.method_0().method_2().IsVisible) ? ((float)class787_0.Width * 0.2f) : ((float)class787_0.Width * 0.175f));
			double double_ = array[0];
			SizeF sizeF = new SizeF(0f, 0f);
			sizeF = smethod_38(interface42_0, class787_0.method_7(), index, n - 1, double_, float_2, float_, array[0]);
			double num34 = 0.0;
			double num35 = 0.0;
			double num36 = 0.0;
			double num37;
			if (n < num7)
			{
				double_ = ((num11 == 0.0) ? 0.01 : (array[n] / num11));
				num13 = ((num9 == 0.0) ? 0.0 : (array[n] / num9 * 360.0));
				num37 = num14;
				num36 = num14 * num33;
			}
			else
			{
				double_ = ((num11 == 0.0) ? 0.01 : (array2[n - num7] / num11));
				if (n == num7)
				{
					num12 = ((num9 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num9 * 180.0));
					if (num7 == 1)
					{
						num12 = 0.0;
					}
				}
				num13 = ((num10 == 0.0) ? 0.0 : (array2[n - num7] / num10 * 360.0));
				num37 = num16;
				num36 = num16 * num33;
			}
			if (num13 == 0.0)
			{
				continue;
			}
			double num38 = (num12 - num13 / 2.0) % 360.0;
			double num17 = num38 * Math.PI / 180.0;
			switch (class9.vmethod_0())
			{
			case Enum74.const_1:
			{
				double num39 = num36 + num37 * 0.5;
				num34 = num39 * Math.Cos(num17);
				num35 = num39 * Math.Sin(num17);
				num34 -= (double)(sizeF.Width / 2f);
				num35 += (double)(sizeF.Height / 2f);
				break;
			}
			default:
			{
				double num39 = num36 + num37 * 1.03;
				num34 = num39 * Math.Cos(num17);
				num35 = num39 * Math.Sin(num17);
				smethod_21(ref num34, ref num35, num38, sizeF);
				if (class9.vmethod_0() == Enum74.const_9)
				{
					if (!class9.method_0().imethod_0())
					{
						num17 -= (double)class9.method_0().X * Math.PI / 180.0;
						num17 %= Math.PI * 2.0;
					}
					if (!class9.method_0().vmethod_2())
					{
						num39 += num37 * (double)class9.method_0().Y / 500.0;
					}
					num34 = num39 * Math.Cos(num17);
					num35 = num39 * Math.Sin(num17);
					smethod_21(ref num34, ref num35, num38, sizeF);
				}
				break;
			}
			case Enum74.const_3:
			{
				double num39 = num36 + num37 * 0.97;
				num34 = num39 * Math.Cos(num17);
				num35 = num39 * Math.Sin(num17);
				smethod_22(ref num34, ref num35, num38, sizeF);
				break;
			}
			}
			if (n < num7)
			{
				num34 = (double)num3 + num34;
				num35 = (double)num4 - num35;
			}
			else
			{
				num34 = (double)num5 + num34;
				num35 = (double)num6 - num35;
			}
			RectangleF rectangleF_3 = new RectangleF((float)num34, (float)num35, sizeF.Width, sizeF.Height);
			smethod_39(interface42_0, class787_0, index, n - 1, double_, rectangleF_3, array[0]);
			num12 -= num13;
		}
	}

	private static int smethod_12(double[] double_0, double[] double_1, double double_2)
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

	private static void smethod_13(Interface42 interface42_0, Class787 class787_0, Rectangle rectangle_0, Class810 class810_0)
	{
		int num = class787_0.method_17();
		int num2 = class787_0.method_19();
		class787_0.method_21();
		Class796 @class = class810_0.method_0();
		int num3 = rectangle_0.X + num;
		int num4 = rectangle_0.Y + rectangle_0.Height / 2;
		int num5 = rectangle_0.X + rectangle_0.Width - num2;
		int num6 = rectangle_0.Y + rectangle_0.Height / 2;
		class787_0.method_7();
		int index = class810_0.Index;
		Class795 class2 = class810_0.method_10();
		int count = class2.Count;
		int num7 = 0;
		int num8 = 0;
		if (count == 1)
		{
			num7 = 1;
			num8 = 1;
		}
		else
		{
			if (class810_0.SplitType != 0 && class810_0.SplitValue > 0.0)
			{
				num8 = (int)class810_0.SplitValue;
				if (num8 > count)
				{
					num8 = count;
				}
			}
			else
			{
				num8 = Struct40.smethod_3((float)count / 3f);
			}
			num7 = count - num8 + 1;
		}
		double[] array = new double[num7];
		double[] array2 = new double[num8];
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		for (int i = 0; i < count; i++)
		{
			if (i + 1 < num7)
			{
				array[i + 1] = Math.Abs(class2[i].YValue);
				num9 += array[i + 1];
			}
			else
			{
				array2[i + 1 - num7] = Math.Abs(class2[i].YValue);
				num10 += array2[i + 1 - num7];
			}
			num11 += Math.Abs(class2[i].YValue);
		}
		array[0] = num10;
		num9 += num10;
		double num12 = ((num9 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num9 * 360.0 / 2.0));
		if (num7 == 1)
		{
			num12 = 0.0;
		}
		double num13 = 0.0;
		double num14 = (double)num / (double)(1f + class810_0.Explosion / 100f);
		RectangleF rectangleF = new RectangleF((float)((double)num3 - num14), (float)((double)num4 - num14), (float)(2.0 * num14), (float)(2.0 * num14));
		double num15 = 0.0 - num12;
		for (int j = 0; j < array.Length; j++)
		{
			Class796 class3 = null;
			if (array[j] == 0.0)
			{
				continue;
			}
			Color color;
			if (j == 0)
			{
				color = class787_0.method_14(class810_0.vmethod_7()).GetColor(count);
				if (@class != null)
				{
					@class.method_3().method_1(color);
					class3 = @class;
				}
			}
			else
			{
				class3 = class2.method_1(j - 1);
				color = class787_0.method_14(class810_0.vmethod_7()).GetColor(j - 1);
			}
			num13 = smethod_36(array[j], num9);
			if (num13 == 0.0)
			{
				num13 = 0.001;
			}
			if (class3.Explosion > 0f)
			{
				smethod_9(class3, rectangleF, num12, (float)((num13 == 0.0) ? 0.01 : num13), num15);
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height, (float)num12, (float)num13);
			Brush brush;
			if (class3 != null)
			{
				smethod_37(rectangleF, (float)num12, (float)num13);
				brush = Struct18.smethod_1(class3.method_3(), Class1181.smethod_1(graphicsPath));
			}
			else
			{
				brush = new SolidBrush(color);
			}
			interface42_0.imethod_33(brush, graphicsPath);
			brush?.Dispose();
			if (class3.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num12 += num13;
			num15 -= num13;
		}
		num12 = ((num9 == 0.0) ? 0.0 : ((0.0 - Math.Abs(array[0])) / num9 * 360.0 / 2.0));
		if (num7 == 1)
		{
			num12 = 0.0;
		}
		num15 = 0.0 - num12;
		for (int k = 0; k < array.Length; k++)
		{
			Class796 class4 = null;
			if (array[k] == 0.0)
			{
				continue;
			}
			Color color;
			if (k == 0)
			{
				color = Color.Black;
				if (@class != null)
				{
					@class.method_4().method_0(color);
					class4 = @class;
				}
			}
			else
			{
				class4 = class2.method_1(k - 1);
				color = class4.method_4().Color;
			}
			Pen pen = ((class4 == null) ? new Pen(color) : Struct29.smethod_5(class4.method_4()));
			num13 = smethod_36(array[k], num9);
			if (num13 == 0.0)
			{
				num13 = 0.001;
			}
			if (class4.Explosion > 0f)
			{
				smethod_9(class4, rectangleF, num12, (float)((num13 == 0.0) ? 0.01 : num13), num15);
			}
			GraphicsPath graphicsPath2 = new GraphicsPath();
			if (num13 == 360.0)
			{
				graphicsPath2.AddArc(rectangleF, (float)num12, (float)num13);
			}
			else
			{
				graphicsPath2.AddPie(rectangleF.X, rectangleF.Y, rectangleF.Width, rectangle_0.Height, (float)num12, (float)num13);
			}
			interface42_0.imethod_18(pen, graphicsPath2);
			pen?.Dispose();
			if (class4.Explosion > 0f)
			{
				interface42_0.ResetTransform();
			}
			num12 += num13;
			num15 -= num13;
		}
		double num16 = num6 - num2;
		for (int l = 0; l < array2.Length; l++)
		{
			if (array2[l] != 0.0)
			{
				int int_ = array.Length - 1 + l;
				Color color = class787_0.method_14(class810_0.vmethod_7()).GetColor(int_);
				Class796 class5 = class2.method_1(int_);
				class5.method_3().method_1(color);
				double num17 = Math.Abs(array2[l]) / num10 * 2.0 * (double)num2;
				RectangleF rectangleF_ = new RectangleF(num5, (float)num16, num2, (float)num17);
				using (Brush brush_ = Struct18.smethod_1(class5.method_3(), rectangleF_))
				{
					interface42_0.imethod_37(brush_, rectangleF_);
				}
				using (Pen pen_ = Struct29.smethod_5(class5.method_4()))
				{
					interface42_0.imethod_23(pen_, num5, (float)num16, num2, (float)num17);
				}
				num16 += num17;
			}
		}
		if (class810_0.HasSeriesLines && num9 != 0.0)
		{
			PointF pointF_ = new PointF(num5, num6 - num2);
			PointF pointF_2 = new PointF(num5, num6 + num2);
			if (Math.Abs(array[0]) / num9 * 2.0 * Math.PI > Math.PI)
			{
				num12 = ((num9 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num9 * Math.PI));
				if (num7 == 1)
				{
					num12 = 0.0;
				}
				double num18 = Math.Sqrt(Math.Pow(num6 - num4, 2.0) + Math.Pow(num5 - num3, 2.0));
				double num19 = Math.Acos(num14 / num18) + Math.Asin((double)num2 / num18);
				PointF pointF_3 = new PointF((float)((double)num3 + num14 * Math.Cos(num19)), (float)((double)num4 - num14 * Math.Sin(num19)));
				PointF pointF_4 = new PointF((float)((double)num3 + num14 * Math.Cos(0.0 - num19)), (float)((double)num4 - num14 * Math.Sin(0.0 - num19)));
				if (@class.Explosion > 0f)
				{
					float num20 = (float)(num14 * (double)@class.Explosion / 100.0);
					pointF_3.X += num20;
					pointF_4.X += num20;
				}
				Struct29.smethod_1(interface42_0, pointF_3, pointF_, class810_0.method_18());
				Struct29.smethod_1(interface42_0, pointF_4, pointF_2, class810_0.method_18());
			}
			else
			{
				double num19 = Math.Abs(array[0]) / num9 * Math.PI;
				PointF pointF_5 = new PointF((float)((double)num3 + num14 * Math.Cos(num19)), (float)((double)num4 - num14 * Math.Sin(num19)));
				PointF pointF_6 = new PointF((float)((double)num3 + num14 * Math.Cos(0.0 - num19)), (float)((double)num4 - num14 * Math.Sin(0.0 - num19)));
				if (@class.Explosion > 0f)
				{
					float num21 = (float)(num14 * (double)@class.Explosion / 100.0);
					pointF_5.X += num21;
					pointF_6.X += num21;
				}
				Struct29.smethod_1(interface42_0, pointF_5, pointF_, class810_0.method_18());
				Struct29.smethod_1(interface42_0, pointF_6, pointF_2, class810_0.method_18());
			}
		}
		Class798 class6 = class810_0.method_3();
		double double_ = array[0];
		SizeF sizeF = new SizeF(0f, 0f);
		double num22 = 0.0;
		double num23 = 0.0;
		num12 = ((num9 == 0.0) ? 0.0 : (Math.Abs(array[0]) / num9 * 180.0));
		if (num7 == 1)
		{
			num12 = 0.0;
		}
		num13 = 0.0;
		float float_ = class787_0.Height;
		for (int m = 0; m < array.Length; m++)
		{
			if (array[m] == 0.0)
			{
				continue;
			}
			Class796 class7 = null;
			double num24 = 0.0;
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
				num24 = class7.Explosion / 100f;
			}
			sizeF = smethod_38(float_2: (!class6.method_0().method_2().IsVisible) ? ((float)class787_0.Width * 0.2f) : ((float)class787_0.Width * 0.175f), interface42_0: interface42_0, class808_0: class787_0.method_7(), int_0: index, int_1: m - 1, double_0: double_, float_3: float_, double_1: array[0]);
			double_ = ((num11 == 0.0) ? 0.01 : (array[m] / num11));
			num13 = ((num9 == 0.0) ? 0.0 : (array[m] / num9 * 2.0 * 180.0));
			double num25 = (double)num * num24;
			double num26 = (num12 - num13 / 2.0) % 360.0;
			double num19 = num26 * Math.PI / 180.0;
			num22 = 0.0;
			num23 = 0.0;
			switch (class6.vmethod_0())
			{
			case Enum74.const_1:
			{
				double num27 = num25 + num14 * 0.5;
				num22 = num27 * Math.Cos(num19);
				num23 = num27 * Math.Sin(num19);
				num22 -= (double)(sizeF.Width / 2f);
				num23 += (double)(sizeF.Height / 2f);
				break;
			}
			default:
			{
				double num27 = num25 + num14 * 1.03;
				num22 = num27 * Math.Cos(num19);
				num23 = num27 * Math.Sin(num19);
				smethod_21(ref num22, ref num23, num26, sizeF);
				if (class6.vmethod_0() == Enum74.const_9)
				{
					if (!class6.method_0().imethod_0())
					{
						num19 -= (double)class6.method_0().X * Math.PI / 180.0;
						num19 %= Math.PI * 2.0;
					}
					if (!class6.method_0().vmethod_2())
					{
						num27 += num14 * (double)class6.method_0().Y / 500.0;
					}
					num22 = num27 * Math.Cos(num19);
					num23 = num27 * Math.Sin(num19);
					smethod_21(ref num22, ref num23, num26, sizeF);
				}
				break;
			}
			case Enum74.const_3:
			{
				double num27 = num25 + num14 * 0.97;
				num22 = num27 * Math.Cos(num19);
				num23 = num27 * Math.Sin(num19);
				smethod_22(ref num22, ref num23, num26, sizeF);
				break;
			}
			}
			num22 = (double)num3 + num22;
			num23 = (double)num4 - num23;
			RectangleF rectangleF_2 = new RectangleF((float)num22, (float)num23, sizeF.Width, sizeF.Height);
			smethod_39(interface42_0, class787_0, index, m - 1, double_, rectangleF_2, array[0]);
			num12 -= num13;
		}
		num16 = num6 - num2;
		class6 = class810_0.method_3();
		for (int n = 0; n < array2.Length; n++)
		{
			if (array2[n] != 0.0)
			{
				Class796 class8 = null;
				int num28 = array.Length + n - 1;
				if (num28 < class810_0.method_10().Count)
				{
					class8 = class2.method_1(num28);
				}
				if (class8 != null)
				{
					class6 = class8.method_6();
				}
				float float_3 = ((!class6.method_0().method_2().IsVisible) ? ((float)class787_0.Width * 0.2f) : ((float)class787_0.Width * 0.175f));
				double num17 = Math.Abs(array2[n]) / num10 * 2.0 * (double)num2;
				num22 = num5;
				num23 = num16;
				num16 += num17;
				int int_2 = array.Length - 1 + n;
				double_ = ((num11 == 0.0) ? 0.01 : (array2[n] / num11));
				sizeF = smethod_38(interface42_0, class787_0.method_7(), index, int_2, double_, float_3, float_, array[0]);
				double num19 = 0.0;
				switch (class6.vmethod_0())
				{
				case Enum74.const_1:
					num22 += (double)(((float)num2 - sizeF.Width) / 2f);
					num23 += (num17 - (double)sizeF.Height) / 2.0;
					break;
				default:
					num22 = num22 + (double)num2 + 1.0;
					num23 += (num17 - (double)sizeF.Height) / 2.0;
					break;
				case Enum74.const_3:
					num22 += (double)(((float)num2 - sizeF.Width) / 2f);
					break;
				}
				RectangleF rectangleF_3 = new RectangleF((float)num22, (float)num23, sizeF.Width, sizeF.Height);
				smethod_39(interface42_0, class787_0, index, int_2, double_, rectangleF_3, array[0]);
			}
		}
	}

	private static void smethod_14(Interface42 interface42_0, Class787 class787_0, Rectangle rectangle_0, IList ilist_0)
	{
		Class810 @class = (Class810)ilist_0[0];
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
			Class810 class2 = (Class810)ilist_0[i];
			_ = class2.Index;
			double num8 = 0.0;
			Class795 class3 = class2.method_10();
			for (int j = 0; j < class3.Count; j++)
			{
				num8 += Math.Abs(class3[j].YValue);
			}
			double num9 = (float)num - 90f;
			double num10 = 0.0;
			for (int k = 0; k < class3.Count; k++)
			{
				Class796 class4 = class3.method_1(k);
				if (class3[k].YValue != 0.0)
				{
					num10 = smethod_36(class3[k].YValue, num8);
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
					RectangleF rect = Struct40.smethod_21(rectangleF_);
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
					RectangleF rect2 = Struct40.smethod_21(rectangleF_);
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
					RectangleF rectangleF_2 = Class1181.smethod_1(graphicsPath);
					using (Brush brush_ = Struct18.smethod_1(class4.method_3(), rectangleF_2))
					{
						interface42_0.imethod_33(brush_, graphicsPath);
					}
					using (Pen pen_ = Struct29.smethod_5(class4.method_4()))
					{
						interface42_0.imethod_18(pen_, graphicsPath);
					}
					num9 += num10;
				}
			}
			num7 += num4;
			rectangleF_.X -= (float)num4;
			rectangleF_.Y -= (float)num4;
			rectangleF_.Width += 2f * (float)num4;
			rectangleF_.Height += 2f * (float)num4;
		}
		float float_ = ((!class787_0.method_8().imethod_0()) ? ((float)class787_0.Width * 0.2f) : ((float)(2.0 * num2)));
		float float_2 = class787_0.Height;
		for (int l = 0; l < ilist_0.Count; l++)
		{
			Class810 class5 = (Class810)ilist_0[l];
			int index = class5.Index;
			Class795 class6 = class5.method_10();
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
					double double_ = ((num20 == 0.0) ? 0.01 : (Math.Abs(class6[n].YValue) / num20));
					SizeF sizeF = smethod_38(interface42_0, class787_0.method_7(), index, n, double_, float_, float_2, 0.0);
					num19 = smethod_36(class6[n].YValue, num20);
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
					RectangleF rectangleF_3 = new RectangleF((float)num26, (float)num27, sizeF.Width, sizeF.Height);
					smethod_39(interface42_0, class787_0, index, n, double_, rectangleF_3, 0.0);
					num18 += num19;
				}
			}
		}
	}

	private static void smethod_15(Interface42 interface42_0, Class787 class787_0, Rectangle rectangle_0, IList ilist_0)
	{
		Class810 @class = (Class810)ilist_0[0];
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
			Class810 class2 = (Class810)ilist_0[i];
			_ = class2.Index;
			double num8 = 0.0;
			Class795 class3 = class2.method_10();
			for (int j = 0; j < class3.Count; j++)
			{
				num8 += Math.Abs(class3[j].YValue);
			}
			double num9 = (float)num - 90f;
			double num10 = 0.0;
			for (int k = 0; k < class3.Count; k++)
			{
				Class796 class4 = class3.method_1(k);
				if (class3[k].YValue != 0.0)
				{
					num10 = smethod_36(class3[k].YValue, num8);
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
					RectangleF rect = Struct40.smethod_21(empty);
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
					RectangleF rect2 = Struct40.smethod_21(empty);
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
					RectangleF rectangleF_ = Class1181.smethod_1(graphicsPath);
					using (Brush brush_ = Struct18.smethod_1(class4.method_3(), rectangleF_))
					{
						interface42_0.imethod_33(brush_, graphicsPath);
					}
					using (Pen pen_ = Struct29.smethod_5(class4.method_4()))
					{
						interface42_0.imethod_18(pen_, graphicsPath);
					}
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
		float float_ = ((!class787_0.method_8().imethod_0()) ? ((float)class787_0.Width * 0.2f) : ((float)(2.0 * num7)));
		float float_2 = class787_0.Height;
		for (int l = 0; l < ilist_0.Count; l++)
		{
			Class810 class5 = (Class810)ilist_0[l];
			int index = class5.Index;
			Class795 class6 = class5.method_10();
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
					double double_ = ((num20 == 0.0) ? 0.01 : (Math.Abs(class6[n].YValue) / num20));
					SizeF sizeF = smethod_38(interface42_0, class787_0.method_7(), index, n, double_, float_, float_2, 0.0);
					num19 = smethod_36(class6[n].YValue, num20);
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
					RectangleF rectangleF_2 = new RectangleF((float)num26, (float)num27, sizeF.Width, sizeF.Height);
					smethod_39(interface42_0, class787_0, index, n, double_, rectangleF_2, 0.0);
					num18 += num19;
				}
			}
		}
	}

	internal static void smethod_16(Interface42 interface42_0, Class787 class787_0, ref Rectangle rectangle_0, Class810 class810_0)
	{
		smethod_19(interface42_0, class787_0, rectangle_0, class810_0);
		ArrayList arrayList;
		if (class810_0.Chart.method_8().imethod_0())
		{
			float num = 0f;
			num = smethod_17(rectangle_0, class810_0);
			if (num > (float)rectangle_0.Width * 0.3f)
			{
				num = (float)rectangle_0.Width * 0.3f;
			}
			RectangleF rectangleF_ = default(RectangleF);
			rectangleF_.X = (float)rectangle_0.X + num;
			rectangleF_.Width = (float)rectangle_0.Width - 2f * num;
			rectangleF_.Y = (float)rectangle_0.Y + num;
			rectangleF_.Height = (float)rectangle_0.Height - 2f * num;
			smethod_20(interface42_0, class787_0, rectangleF_, class810_0);
			arrayList = smethod_31(class810_0, rectangle_0);
			smethod_19(interface42_0, class787_0, rectangle_0, class810_0);
			float float_ = 0f;
			for (int i = 0; i < class810_0.method_10().Count; i++)
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
				if (flag)
				{
					continue;
				}
				Class796 @class = class810_0.method_10().method_1(i);
				Class798 class2 = @class.method_6();
				if (class2.vmethod_0() != 0 && class2.vmethod_0() != Enum74.const_4)
				{
					if (class2.vmethod_0() == Enum74.const_9)
					{
						smethod_34(rectangle_0, class2.rectangleF_0, ref float_);
					}
				}
				else
				{
					smethod_34(rectangle_0, class2.rectangleF_1, ref float_);
				}
			}
			if (float_ > (float)rectangle_0.Width * 0.3f)
			{
				float_ = (float)rectangle_0.Width * 0.3f;
			}
			rectangle_0.X += (int)float_;
			rectangle_0.Width -= (int)(float_ * 2f);
			rectangle_0.Y += (int)float_;
			rectangle_0.Height -= (int)(float_ * 2f);
		}
		smethod_19(interface42_0, class787_0, rectangle_0, class810_0);
		smethod_23(class810_0, rectangle_0.Width / 2);
		arrayList = smethod_31(class810_0, rectangle_0);
		for (int l = 0; l < 10; l++)
		{
			if (arrayList.Count <= 0)
			{
				break;
			}
			smethod_24(class810_0, rectangle_0.Width / 2, arrayList);
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
			smethod_26(class810_0, arrayList, rectangle_0, rectangle_0, arrayList6);
			smethod_25(class810_0, rectangle_0.Width / 2, arrayList3, arrayList6);
			arrayList = smethod_31(class810_0, rectangle_0);
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

	internal static float smethod_17(Rectangle rectangle_0, Class810 class810_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		return smethod_18(rectangleF_, class810_0);
	}

	internal static float smethod_18(RectangleF rectangleF_0, Class810 class810_0)
	{
		ArrayList arrayList = smethod_32(class810_0, rectangleF_0);
		float float_ = 0f;
		for (int i = 0; i < class810_0.method_10().Count; i++)
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
			if (flag)
			{
				continue;
			}
			Class796 @class = class810_0.method_10().method_1(i);
			Class798 class2 = @class.method_6();
			if (class2.vmethod_0() != 0 && class2.vmethod_0() != Enum74.const_4)
			{
				if (class2.vmethod_0() == Enum74.const_9)
				{
					smethod_35(rectangleF_0, class2.rectangleF_0, ref float_);
				}
			}
			else
			{
				smethod_35(rectangleF_0, class2.rectangleF_1, ref float_);
			}
		}
		return float_;
	}

	internal static void smethod_19(Interface42 interface42_0, Class787 class787_0, Rectangle rectangle_0, Class810 class810_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		smethod_20(interface42_0, class787_0, rectangleF_, class810_0);
	}

	internal static void smethod_20(Interface42 interface42_0, Class787 class787_0, RectangleF rectangleF_0, Class810 class810_0)
	{
		int index = class810_0.Index;
		double num = 0.0;
		Class795 @class = class810_0.method_10();
		for (int i = 0; i < @class.Count; i++)
		{
			num += Math.Abs(@class[i].YValue);
		}
		double num2 = (double)rectangleF_0.X + (double)rectangleF_0.Width / 2.0;
		double num3 = (double)rectangleF_0.Y + (double)rectangleF_0.Height / 2.0;
		double num4 = 90f - (float)class810_0.vmethod_1();
		double num5 = 0.0;
		for (int j = 0; j < @class.Count; j++)
		{
			Class796 class2 = @class.method_1(j);
			Class798 class3 = class2.method_6();
			float float_ = ((!class3.method_0().method_2().IsVisible) ? ((float)class787_0.Width * 0.2f) : ((float)class787_0.Width * 0.175f));
			float float_2 = class787_0.Height;
			double double_ = ((num == 0.0) ? 0.01 : (Math.Abs(@class[j].YValue) / num));
			SizeF sizeF_ = smethod_38(interface42_0, class787_0.method_7(), index, j, double_, float_, float_2, 0.0);
			num5 = smethod_36(@class[j].YValue, num);
			double num6 = (num4 - num5 / 2.0) % 360.0;
			double num7 = (class3.double_0 = num6 * Math.PI / 180.0);
			double num8 = class2.Explosion / 100f;
			double num9 = ((class787_0.Type != ChartType_Chart.Pie) ? ((double)rectangleF_0.Width / 2.0 / (1.0 + num8)) : ((double)rectangleF_0.Width / 2.0));
			double num10 = num9 * num8;
			double num11 = (num8 + 1.0) * num9 * Math.Cos(num7);
			double num12 = (num8 + 1.0) * num9 * Math.Sin(num7);
			class3.pointF_0 = new PointF((float)(num2 + num11), (float)(num3 - num12));
			double num13 = 0.0;
			double num14 = 0.0;
			switch (class3.vmethod_0())
			{
			case Enum74.const_1:
			{
				double num15 = num10 + num9 * 0.5;
				num13 = num15 * Math.Cos(num7);
				num14 = num15 * Math.Sin(num7);
				num13 -= (double)(sizeF_.Width / 2f);
				num14 += (double)(sizeF_.Height / 2f);
				break;
			}
			default:
			{
				double num15 = num10 + num9 * 1.03;
				num13 = num15 * Math.Cos(num7);
				num14 = num15 * Math.Sin(num7);
				new PointF((float)num13, (float)num14);
				smethod_21(ref num13, ref num14, num6, sizeF_);
				class3.rectangleF_0 = new RectangleF((float)(num2 + num13), (float)(num3 - num14), sizeF_.Width, sizeF_.Height);
				if (class3.vmethod_0() == Enum74.const_9)
				{
					if (!class3.method_0().imethod_0())
					{
						num7 -= (double)class3.method_0().X * Math.PI / 180.0;
						num7 %= Math.PI * 2.0;
					}
					if (!class3.method_0().vmethod_2())
					{
						num15 += num9 * (double)class3.method_0().Y / 500.0;
					}
					num13 = num15 * Math.Cos(num7);
					num14 = num15 * Math.Sin(num7);
					smethod_21(ref num13, ref num14, num6, sizeF_);
				}
				break;
			}
			case Enum74.const_3:
			{
				double num15 = num10 + num9 * 0.97;
				num13 = num15 * Math.Cos(num7);
				num14 = num15 * Math.Sin(num7);
				smethod_22(ref num13, ref num14, num6, sizeF_);
				break;
			}
			}
			num13 = num2 + num13;
			num14 = num3 - num14;
			RectangleF rectangleF = new RectangleF((float)num13, (float)num14, sizeF_.Width, sizeF_.Height);
			num4 -= num5;
			class3.rectangleF_1 = rectangleF;
			class3.rectangleF_2 = rectangleF;
		}
	}

	private static void smethod_21(ref double double_0, ref double double_1, double double_2, SizeF sizeF_0)
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

	private static void smethod_22(ref double double_0, ref double double_1, double double_2, SizeF sizeF_0)
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

	private static void smethod_23(Class810 class810_0, double double_0)
	{
		Class795 @class = class810_0.method_10();
		double num = double_0 * (double)float_0;
		ArrayList arrayList = new ArrayList();
		if (!class810_0.HasLeaderLines)
		{
			return;
		}
		for (int i = 0; i < @class.Count; i++)
		{
			if (@class.method_1(i).method_6().vmethod_0() != Enum74.const_9)
			{
				continue;
			}
			arrayList.Add(i);
			Class796 class2 = @class.method_1(i);
			Class798 class3 = class2.method_6();
			class3.bool_8 = true;
			if (class3.pointF_1.IsEmpty)
			{
				if (!class3.method_7())
				{
					class3.pointF_2 = new PointF(class3.rectangleF_1.X, class3.rectangleF_1.Y + class3.rectangleF_1.Height / 2f);
					class3.pointF_1 = new PointF(class3.rectangleF_1.X - (float)num, class3.pointF_2.Y);
				}
				else
				{
					class3.pointF_2 = new PointF(class3.rectangleF_1.Right, class3.rectangleF_1.Top + class3.rectangleF_1.Height / 2f);
					class3.pointF_1 = new PointF(class3.rectangleF_1.Right + (float)num, class3.pointF_2.Y);
				}
			}
		}
	}

	private static void smethod_24(Class810 class810_0, double double_0, ArrayList arrayList_0)
	{
		double num = double_0 * (double)float_0;
		double num2 = num;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			ArrayList arrayList = (ArrayList)arrayList_0[i];
			for (int j = 0; j < arrayList.Count; j++)
			{
				Class796 @class = class810_0.method_10().method_1((int)arrayList[j]);
				Class798 class2 = @class.method_6();
				class2.bool_8 = true;
				if (class2.pointF_1.IsEmpty)
				{
					if (!class2.method_7())
					{
						class2.rectangleF_1.X = (float)((double)class2.pointF_0.X + num + num2 * Math.Abs(Math.Cos(class2.double_0)));
					}
					else
					{
						class2.rectangleF_1.X = (float)((double)(class2.pointF_0.X - class2.rectangleF_1.Width) - num - num2 * Math.Abs(Math.Cos(class2.double_0)));
					}
					if (class2.method_8())
					{
						class2.rectangleF_1.Y = (float)((double)class2.pointF_0.Y + num2 * Math.Abs(Math.Sin(class2.double_0)) - (double)(class2.rectangleF_1.Height / 2f));
					}
					else
					{
						class2.rectangleF_1.Y = (float)((double)class2.pointF_0.Y - num2 * Math.Abs(Math.Sin(class2.double_0)) - (double)(class2.rectangleF_1.Height / 2f));
					}
					if (!class2.method_7())
					{
						class2.pointF_2 = new PointF(class2.rectangleF_1.X, class2.rectangleF_1.Y + class2.rectangleF_1.Height / 2f);
						class2.pointF_1 = new PointF(class2.rectangleF_1.X - (float)num, class2.pointF_2.Y);
					}
					else
					{
						class2.pointF_2 = new PointF(class2.rectangleF_1.Right, class2.rectangleF_1.Top + class2.rectangleF_1.Height / 2f);
						class2.pointF_1 = new PointF(class2.rectangleF_1.Right + (float)num, class2.pointF_2.Y);
					}
				}
			}
		}
	}

	private static void smethod_25(Class810 class810_0, double double_0, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		double num = double_0 * (double)float_0;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			ArrayList arrayList = (ArrayList)arrayList_0[i];
			for (int j = 0; j < arrayList.Count; j++)
			{
				int k;
				for (k = 0; k < arrayList_1.Count && (int)arrayList[j] != (int)arrayList_1[k]; k++)
				{
				}
				if (k == arrayList_1.Count)
				{
					Class796 @class = class810_0.method_10().method_1((int)arrayList[j]);
					Class798 class2 = @class.method_6();
					if (!class2.method_7())
					{
						class2.pointF_2 = new PointF(class2.rectangleF_1.X, class2.rectangleF_1.Y + class2.rectangleF_1.Height / 2f);
						class2.pointF_1 = new PointF(class2.rectangleF_1.X - (float)num, class2.pointF_2.Y);
					}
					else
					{
						class2.pointF_2 = new PointF(class2.rectangleF_1.Right, class2.rectangleF_1.Top + class2.rectangleF_1.Height / 2f);
						class2.pointF_1 = new PointF(class2.rectangleF_1.Right + (float)num, class2.pointF_2.Y);
					}
				}
			}
		}
	}

	private static void smethod_26(Class810 class810_0, ArrayList arrayList_0, Rectangle rectangle_0, Rectangle rectangle_1, ArrayList arrayList_1)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			ArrayList arrayList_2 = (ArrayList)arrayList_0[i];
			smethod_27(class810_0, arrayList_2, rectangle_0, rectangle_1, arrayList_1);
		}
		for (int j = 0; j < arrayList_1.Count; j++)
		{
			Class798 @class = class810_0.method_10().method_1((int)arrayList_1[j]).method_6();
			@class.rectangleF_1 = @class.rectangleF_2;
			@class.pointF_2 = PointF.Empty;
			@class.pointF_1 = PointF.Empty;
		}
	}

	private static void smethod_27(Class810 class810_0, ArrayList arrayList_0, Rectangle rectangle_0, Rectangle rectangle_1, ArrayList arrayList_1)
	{
		Class787 chart = class810_0.Chart;
		if (arrayList_0.Count < 1)
		{
			return;
		}
		float num = float_1;
		Class795 @class = class810_0.method_10();
		int num2 = (int)arrayList_0[0];
		Class798 class2 = @class.method_1(num2).method_6();
		arrayList_0.RemoveAt(0);
		ArrayList arrayList = new ArrayList();
		arrayList.Add(num2);
		smethod_28(class810_0, arrayList, arrayList_0, class2);
		switch (class2.method_9())
		{
		case 1:
		{
			if (class810_0.method_10().method_1((int)arrayList[0]).method_6()
				.double_0 >= 0.0)
			{
				smethod_29(class810_0, arrayList, 0, arrayList.Count - 1, bool_0: true);
			}
			else
			{
				smethod_29(class810_0, arrayList, 0, arrayList.Count - 1, bool_0: true);
			}
			Class798 class3 = class810_0.method_10().method_1((int)arrayList[0]).method_6();
			Class798 class4 = (((int)arrayList[0] != @class.Count - 1) ? @class.method_1((int)arrayList[0] + 1).method_6() : @class.method_1(0).method_6());
			if (smethod_30(class3.rectangleF_1, class4.rectangleF_1, num))
			{
				float num9 = Math.Abs(class4.rectangleF_1.Y - class3.rectangleF_1.Bottom);
				float num10 = (num9 + num) / 2f;
				if (class4.bool_8)
				{
					class3.rectangleF_1.Y -= num10;
					class4.rectangleF_1.Y += num10;
				}
				else
				{
					class3.rectangleF_1.Y -= num9 + num;
				}
			}
			for (int m = 1; m < arrayList.Count; m++)
			{
				Class798 class8 = class810_0.method_10().method_1((int)arrayList[m]).method_6();
				float num11 = Math.Abs(class3.rectangleF_1.Y - class8.rectangleF_1.Bottom);
				class8.rectangleF_1.Y -= num11 + num;
				class3 = class8;
			}
			Class798 class6 = class810_0.method_10().method_1((int)arrayList[arrayList.Count - 1]).method_6();
			if (class6.rectangleF_1.Y < 0f)
			{
				for (int n = 0; n < arrayList.Count; n++)
				{
					arrayList_1.Add((int)arrayList[n]);
				}
			}
			break;
		}
		case 2:
		{
			smethod_29(class810_0, arrayList, 0, arrayList.Count - 1, bool_0: false);
			Class798 class3 = class810_0.method_10().method_1((int)arrayList[0]).method_6();
			Class798 class4 = (((int)arrayList[0] != 0) ? @class.method_1((int)arrayList[0] - 1).method_6() : @class.method_1(@class.Count - 1).method_6());
			if (smethod_30(class3.rectangleF_1, class4.rectangleF_1, num))
			{
				float num12 = Math.Abs(class4.rectangleF_1.Bottom - class3.rectangleF_1.Y);
				float num13 = (num12 + num) / 2f;
				if (class4.bool_8)
				{
					class3.rectangleF_1.Y += num13;
					class4.rectangleF_1.Y -= num13;
				}
				else
				{
					class3.rectangleF_1.Y += num12 + num;
				}
			}
			for (int num14 = 1; num14 < arrayList.Count; num14++)
			{
				Class798 class9 = class810_0.method_10().method_1((int)arrayList[num14]).method_6();
				float num15 = Math.Abs(class3.rectangleF_1.Bottom - class9.rectangleF_1.Y);
				class9.rectangleF_1.Y += num15 + num;
				class3 = class9;
			}
			Class798 class6 = class810_0.method_10().method_1((int)arrayList[arrayList.Count - 1]).method_6();
			if (class6.rectangleF_1.Y > (float)chart.Height)
			{
				for (int num16 = 0; num16 < arrayList.Count; num16++)
				{
					arrayList_1.Add((int)arrayList[num16]);
				}
			}
			break;
		}
		case 3:
		{
			smethod_29(class810_0, arrayList, 0, arrayList.Count - 1, bool_0: true);
			Class798 class3 = class810_0.method_10().method_1((int)arrayList[0]).method_6();
			Class798 class4 = (((int)arrayList[0] != @class.Count - 1) ? @class.method_1((int)arrayList[0] + 1).method_6() : @class.method_1(0).method_6());
			if (smethod_30(class3.rectangleF_1, class4.rectangleF_1, num))
			{
				float num6 = Math.Abs(class4.rectangleF_1.Bottom - class3.rectangleF_1.Y);
				float num7 = (num6 + num) / 2f;
				if (class4.bool_8)
				{
					class3.rectangleF_1.Y += num7;
					class4.rectangleF_1.Y -= num7;
				}
				else
				{
					class3.rectangleF_1.Y += num6 + num;
				}
			}
			for (int k = 1; k < arrayList.Count; k++)
			{
				Class798 class7 = class810_0.method_10().method_1((int)arrayList[k]).method_6();
				float num8 = Math.Abs(class3.rectangleF_1.Bottom - class7.rectangleF_1.Y);
				class7.rectangleF_1.Y += num8 + num;
				class3 = class7;
			}
			Class798 class6 = class810_0.method_10().method_1((int)arrayList[arrayList.Count - 1]).method_6();
			if (class6.rectangleF_1.Y > (float)chart.Height)
			{
				for (int l = 0; l < arrayList.Count; l++)
				{
					arrayList_1.Add((int)arrayList[l]);
				}
			}
			break;
		}
		case 4:
		{
			smethod_29(class810_0, arrayList, 0, arrayList.Count - 1, bool_0: false);
			Class798 class3 = class810_0.method_10().method_1((int)arrayList[0]).method_6();
			Class798 class4 = (((int)arrayList[0] != 0) ? @class.method_1((int)arrayList[0] - 1).method_6() : @class.method_1(@class.Count - 1).method_6());
			if (smethod_30(class3.rectangleF_1, class4.rectangleF_1, num))
			{
				float num3 = Math.Abs(class4.rectangleF_1.Y - class3.rectangleF_1.Bottom);
				float num4 = (num3 + num) / 2f;
				if (class4.bool_8)
				{
					class3.rectangleF_1.Y -= num4;
					class4.rectangleF_1.Y += num4;
				}
				else
				{
					class3.rectangleF_1.Y -= num3 + num;
				}
			}
			for (int i = 1; i < arrayList.Count; i++)
			{
				Class798 class5 = class810_0.method_10().method_1((int)arrayList[i]).method_6();
				float num5 = Math.Abs(class3.rectangleF_1.Y - class5.rectangleF_1.Bottom);
				class5.rectangleF_1.Y -= num5 + num;
				class3 = class5;
			}
			Class798 class6 = class810_0.method_10().method_1((int)arrayList[arrayList.Count - 1]).method_6();
			if (class6.rectangleF_1.Y < 0f)
			{
				for (int j = 0; j < arrayList.Count; j++)
				{
					arrayList_1.Add((int)arrayList[j]);
				}
			}
			break;
		}
		}
		smethod_27(class810_0, arrayList_0, rectangle_0, rectangle_1, arrayList_1);
	}

	private static ArrayList smethod_28(Class810 class810_0, ArrayList arrayList_0, ArrayList arrayList_1, Class798 class798_0)
	{
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class798 @class = class810_0.method_10().method_1((int)arrayList_1[i]).method_6();
			if (@class.method_9() == class798_0.method_9())
			{
				arrayList_0.Add(arrayList_1[i]);
				arrayList_1.RemoveAt(i);
				i--;
			}
		}
		return arrayList_0;
	}

	private static void smethod_29(Class810 class810_0, ArrayList arrayList_0, int int_0, int int_1, bool bool_0)
	{
		if (int_1 >= arrayList_0.Count || int_0 >= arrayList_0.Count || int_1 <= int_0)
		{
			return;
		}
		Class798 @class = class810_0.method_10().method_1((int)arrayList_0[int_0]).method_6();
		int num = 0;
		for (int i = int_0 + 1; i <= int_1; i++)
		{
			Class798 class2 = class810_0.method_10().method_1((int)arrayList_0[i]).method_6();
			if (bool_0)
			{
				if (class2.double_0 < @class.double_0)
				{
					arrayList_0.Insert(int_0, arrayList_0[i]);
					arrayList_0.RemoveAt(i + 1);
					num++;
				}
			}
			else if (class2.double_0 > @class.double_0)
			{
				arrayList_0.Insert(int_0, arrayList_0[i]);
				arrayList_0.RemoveAt(i + 1);
				num++;
			}
		}
		smethod_29(class810_0, arrayList_0, int_0, int_1 + num - 1, bool_0);
		smethod_29(class810_0, arrayList_0, int_0 + num + 1, int_1, bool_0);
	}

	private static bool smethod_30(RectangleF rectangleF_0, RectangleF rectangleF_1, float float_2)
	{
		rectangleF_0 = new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
		rectangleF_1 = new RectangleF(rectangleF_1.X, rectangleF_1.Y, rectangleF_1.Width, rectangleF_1.Height);
		if (rectangleF_0.Width != 0f && rectangleF_0.Height != 0f && rectangleF_0.Width != 0f && rectangleF_0.Height != 0f)
		{
			rectangleF_0.Inflate(float_2 / 2f, float_2 / 2f);
			rectangleF_1.Inflate(float_2 / 2f, float_2 / 2f);
			if (((rectangleF_1.Left >= rectangleF_0.Left && rectangleF_1.Left <= rectangleF_0.Right) || (rectangleF_1.Right >= rectangleF_0.Left && rectangleF_1.Right <= rectangleF_0.Right)) && ((rectangleF_1.Bottom >= rectangleF_0.Top && rectangleF_1.Bottom <= rectangleF_0.Bottom) || (rectangleF_1.Top >= rectangleF_0.Top && rectangleF_1.Top <= rectangleF_0.Bottom)))
			{
				return true;
			}
			RectangleF rectangleF = rectangleF_0;
			rectangleF_0 = rectangleF_1;
			rectangleF_1 = rectangleF;
			if (((rectangleF_1.Left >= rectangleF_0.Left && rectangleF_1.Left <= rectangleF_0.Right) || (rectangleF_1.Right >= rectangleF_0.Left && rectangleF_1.Right <= rectangleF_0.Right)) && ((rectangleF_1.Bottom >= rectangleF_0.Top && rectangleF_1.Bottom <= rectangleF_0.Bottom) || (rectangleF_1.Top >= rectangleF_0.Top && rectangleF_1.Top <= rectangleF_0.Bottom)))
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static ArrayList smethod_31(Class810 class810_0, Rectangle rectangle_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		return smethod_32(class810_0, rectangleF_);
	}

	private static ArrayList smethod_32(Class810 class810_0, RectangleF rectangleF_0)
	{
		float float_ = float_1;
		Class795 @class = class810_0.method_10();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < @class.Count; i++)
		{
			if (@class.method_1(i).method_6().vmethod_0() != 0)
			{
				continue;
			}
			ArrayList arrayList2 = new ArrayList();
			bool flag = false;
			for (int j = 0; j < @class.Count; j++)
			{
				if (i != j && smethod_30(@class.method_1(i).method_6().rectangleF_1, @class.method_1(j).method_6().rectangleF_1, float_))
				{
					flag = true;
					if (@class.method_1(j).method_6().vmethod_0() == Enum74.const_0)
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
					if (smethod_33(arrayList3, arrayList4))
					{
						arrayList.RemoveAt(k);
						k--;
						break;
					}
				}
				else if (smethod_33(arrayList4, arrayList3))
				{
					arrayList.RemoveAt(l);
					break;
				}
			}
		}
		return arrayList;
	}

	private static bool smethod_33(ArrayList arrayList_0, ArrayList arrayList_1)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				if (!arrayList_1.Contains(arrayList_0[num]))
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

	private static void smethod_34(Rectangle rectangle_0, RectangleF rectangleF_0, ref float float_2)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		smethod_35(rectangleF_, rectangleF_0, ref float_2);
	}

	private static void smethod_35(RectangleF rectangleF_0, RectangleF rectangleF_1, ref float float_2)
	{
		if (rectangleF_1.Left < rectangleF_0.Left)
		{
			float num = rectangleF_0.Left - rectangleF_1.Left;
			if (num > float_2)
			{
				float_2 = num;
			}
		}
		if (rectangleF_1.Top < rectangleF_0.Top)
		{
			float num2 = rectangleF_0.Top - rectangleF_1.Top;
			if (num2 > float_2)
			{
				float_2 = num2;
			}
		}
		if (rectangleF_1.Right > rectangleF_0.Right)
		{
			float num3 = rectangleF_1.Right - rectangleF_0.Right;
			if (num3 > float_2)
			{
				float_2 = num3;
			}
		}
		if (rectangleF_1.Bottom > rectangleF_0.Bottom)
		{
			float num4 = rectangleF_1.Bottom - rectangleF_0.Bottom;
			if (num4 > float_2)
			{
				float_2 = num4;
			}
		}
	}

	private static double smethod_36(double double_0, double double_1)
	{
		if (double_1 == 0.0)
		{
			return 0.0;
		}
		return Math.Abs(double_0) / double_1 * 360.0;
	}

	internal static RectangleF smethod_37(RectangleF rectangleF_0, double double_0, double double_1)
	{
		using Pen pen = new Pen(Color.Black, 1f);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddPie(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height, (float)double_0, (float)double_1);
		graphicsPath.Widen(pen);
		return Class1181.smethod_1(graphicsPath);
	}

	internal static SizeF smethod_38(Interface42 interface42_0, Class808 class808_0, int int_0, int int_1, double double_0, float float_2, float float_3, double double_1)
	{
		Class810 @class = class808_0.method_9(int_0);
		Class787 chart = @class.Chart;
		Class796 class2 = @class.method_10().method_1(int_1);
		if (class2 == null)
		{
			class2 = @class.method_0();
		}
		Enum53 @enum = @class.method_21();
		Class789 class3;
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
		Class798 class4 = class2.method_6();
		bool bool_ = class4.vmethod_1();
		bool linkedSource = class4.LinkedSource;
		string string_ = (class4.IsPercentageShown ? "" : class4.imethod_2());
		string string_2 = ((class4.imethod_2() == "") ? "0%" : class4.imethod_2());
		string name = @class.Name;
		string text = "";
		if (int_1 == -1)
		{
			text = "Other";
		}
		else if (int_1 < class3.arrayList_1.Count)
		{
			text = Struct26.smethod_6(chart.vmethod_2(), class3.arrayList_1[int_1], string_, bool_);
		}
		if (linkedSource)
		{
			string string_3 = ((int_1 < 0 || int_1 >= arrayList.Count) ? "" : ((Class791)arrayList[int_1]).imethod_3());
			bool bool_2 = int_1 >= 0 && int_1 < arrayList.Count && ((Class791)arrayList[int_1]).imethod_1();
			if (int_1 == -1)
			{
				text = "Other";
			}
			else if (int_1 < class3.arrayList_1.Count)
			{
				text = Struct26.smethod_6(chart.vmethod_2(), class3.arrayList_1[int_1], string_3, bool_2);
			}
		}
		string text2 = ((int_1 == -1) ? Struct26.smethod_6(chart.vmethod_2(), double_1, string_, bool_) : Struct26.smethod_6(chart.vmethod_2(), class2.YValue, string_, bool_));
		if (linkedSource)
		{
			text2 = ((int_1 == -1) ? Struct26.smethod_6(chart.vmethod_2(), double_1, string_, bool_) : Struct26.smethod_6(chart.vmethod_2(), class2.YValue, class2.vmethod_6(), class2.vmethod_7()));
		}
		string text3 = Struct26.smethod_6(chart.vmethod_2(), double_0, string_2, bool_);
		string text4 = Struct26.smethod_5(class4);
		Font font = class4.method_0().Font;
		int rotation = class4.Rotation;
		Enum82 textHorizontalAlignment = class4.TextHorizontalAlignment;
		Enum82 textVerticalAlignment = class4.TextVerticalAlignment;
		SizeF sizeF = new SizeF(class4.method_4(), class4.method_6());
		string text5 = "";
		if (class4.Text == null)
		{
			if (class4.IsSeriesNameShown)
			{
				text5 += name;
			}
			if (class4.IsCategoryNameShown)
			{
				if (text5 != "")
				{
					text5 += text4;
				}
				text5 += text;
			}
			if (class4.IsValueShown)
			{
				if (text5 != "")
				{
					text5 += text4;
				}
				text5 += text2;
			}
			if (class4.IsPercentageShown)
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
			text5 = class4.Text;
		}
		SizeF sizeF_ = new SizeF(float_2, float_3);
		Size size = Struct37.smethod_0(interface42_0, text5, rotation, font, sizeF_, textHorizontalAlignment, textVerticalAlignment);
		if (text5 == "")
		{
			return new SizeF(0f, 0f);
		}
		SizeF result = ((!class4.IsLegendKeyShown) ? new SizeF(size.Width, size.Height) : new SizeF((float)size.Width + sizeF.Width, size.Height));
		if (class4.IsLegendKeyShown)
		{
			result.Width += 2 * Struct26.int_0;
		}
		result.Height += 2 * Struct26.int_0;
		return result;
	}

	internal static void smethod_39(Interface42 interface42_0, Class787 class787_0, int int_0, int int_1, double double_0, RectangleF rectangleF_0, double double_1)
	{
		Class810 @class = class787_0.method_7().method_9(int_0);
		Class796 class2 = @class.method_10().method_1(int_1);
		if (class2 == null)
		{
			class2 = @class.method_0();
		}
		Enum53 @enum = @class.method_21();
		Class789 class3;
		ArrayList arrayList;
		if (@enum == Enum53.const_0)
		{
			class3 = class787_0.method_1();
			arrayList = class787_0.method_7().method_0();
		}
		else
		{
			class3 = class787_0.method_2();
			arrayList = class787_0.method_7().method_2();
		}
		Class798 class4 = class2.method_6();
		bool bool_ = class4.vmethod_1();
		bool linkedSource = class4.LinkedSource;
		string string_ = (class4.IsPercentageShown ? "" : class4.imethod_2());
		string string_2 = ((class4.imethod_2() == "") ? "0%" : class4.imethod_2());
		string name = @class.Name;
		string text = "";
		if (int_1 == -1)
		{
			text = "Other";
		}
		else if (int_1 < class3.arrayList_1.Count)
		{
			text = Struct26.smethod_6(class787_0.vmethod_2(), class3.arrayList_1[int_1], string_, bool_);
		}
		bool flag = false;
		if (linkedSource)
		{
			string string_3 = ((int_1 < 0 || int_1 >= arrayList.Count) ? "" : ((Class791)arrayList[int_1]).imethod_3());
			bool bool_2 = int_1 >= 0 && int_1 < arrayList.Count && ((Class791)arrayList[int_1]).imethod_1();
			if (int_1 == -1)
			{
				text = "Other";
			}
			else if (int_1 < class3.arrayList_1.Count)
			{
				text = Struct26.smethod_6(class787_0.vmethod_2(), class3.arrayList_1[int_1], string_3, bool_2);
			}
			if (int_1 >= 0 && int_1 < class3.arrayList_1.Count)
			{
				flag = Struct26.smethod_8(class3.arrayList_1[int_1], string_3);
			}
		}
		string text2 = ((int_1 == -1) ? Struct26.smethod_6(class787_0.vmethod_2(), double_1, string_, bool_) : Struct26.smethod_6(class787_0.vmethod_2(), class2.YValue, string_, bool_));
		bool flag2 = false;
		if (linkedSource)
		{
			text2 = ((int_1 == -1) ? Struct26.smethod_6(class787_0.vmethod_2(), double_1, string_, bool_) : Struct26.smethod_6(class787_0.vmethod_2(), class2.YValue, class2.vmethod_6(), class2.vmethod_7()));
			if (int_1 != -1)
			{
				flag2 = Struct26.smethod_8(class2.YValue, class2.vmethod_6());
			}
		}
		string text3 = Struct26.smethod_6(class787_0.vmethod_2(), double_0, string_2, bool_);
		string text4 = Struct26.smethod_5(class4);
		Font font = class4.method_0().Font;
		Color color_ = class4.method_0().FontColor;
		int rotation = class4.Rotation;
		Enum82 textHorizontalAlignment = class4.TextHorizontalAlignment;
		Enum82 textVerticalAlignment = class4.TextVerticalAlignment;
		SizeF sizeF = new SizeF(class4.method_4(), class4.method_6());
		class4.method_0().rectangle_1 = new Rectangle((int)rectangleF_0.X, (int)rectangleF_0.Y, (int)rectangleF_0.Width, (int)rectangleF_0.Height);
		class4.method_0().rectangle_0 = class4.method_0().rectangle_1;
		Struct24.smethod_0(interface42_0, class4.method_0());
		int num = (class4.IsLegendKeyShown ? ((int)(rectangleF_0.X + (float)Struct26.int_0)) : ((int)rectangleF_0.X));
		int y = (int)rectangleF_0.Y + Struct26.int_0;
		int num2 = (class4.IsLegendKeyShown ? ((int)(rectangleF_0.Width - (float)(2 * Struct26.int_0))) : ((int)rectangleF_0.Width));
		int height = (int)rectangleF_0.Height - 2 * Struct26.int_0;
		if (class4.IsLegendKeyShown)
		{
			RectangleF rectangleF_ = new RectangleF(rectangleF_0.X + (float)Struct26.int_0, rectangleF_0.Y + (float)Struct26.int_0, sizeF.Width, sizeF.Height);
			Struct28.smethod_13(interface42_0, rectangleF_, @class, int_1);
			num += (int)sizeF.Width;
			num2 -= (int)sizeF.Width;
		}
		string text5 = "";
		if (class4.Text == null)
		{
			if (class4.IsSeriesNameShown)
			{
				text5 += name;
			}
			if (class4.IsCategoryNameShown)
			{
				if (text5 != "")
				{
					text5 += text4;
				}
				text5 += text;
			}
			if (class4.IsValueShown)
			{
				if (text5 != "")
				{
					text5 += text4;
				}
				text5 += text2;
			}
			if (class4.IsPercentageShown)
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
			text5 = class4.Text;
		}
		if (text5 != "")
		{
			Rectangle rectangle_ = new Rectangle(num, y, num2, height);
			if (flag || flag2)
			{
				color_ = Color.Red;
			}
			Struct26.smethod_13(interface42_0, class4, rectangle_, text5, rotation, font, color_, textHorizontalAlignment, textVerticalAlignment);
		}
	}
}
