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
internal struct Struct28
{
	internal static int int_0 = 4;

	internal static float float_0 = 0.4f;

	internal static float float_1 = 5f;

	private static SizeF smethod_0(Interface42 interface42_0, Class804 class804_0)
	{
		Class808 @class = class804_0.method_0().Chart.method_7();
		SizeF result = new SizeF(0f, 0f);
		for (int i = 0; i < @class.Count; i++)
		{
			Class810 class2 = @class.method_9(i);
			SizeF sizeF = interface42_0.imethod_39(class2.Name, class804_0.method_0().Font);
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

	private static bool smethod_1(Class808 class808_0)
	{
		if (class808_0.method_23())
		{
			return true;
		}
		bool result = false;
		for (int i = 0; i < class808_0.Count; i++)
		{
			Class810 @class = class808_0.method_9(i);
			if (@class.method_6().IsVisible && !smethod_4(@class.Type) && !@class.method_37())
			{
				result = true;
				break;
			}
		}
		return result;
	}

	internal static SizeF smethod_2(Interface42 interface42_0, Class804 class804_0)
	{
		SizeF sizeF = smethod_0(interface42_0, class804_0);
		bool flag = smethod_1(class804_0.method_0().Chart.method_7());
		if (sizeF.Width == 0f)
		{
			if (flag)
			{
				return new SizeF(28f, class804_0.method_7());
			}
			return new SizeF(class804_0.method_10(), class804_0.method_7());
		}
		if (sizeF.Width != 0f)
		{
			float width = sizeF.Height * float_0;
			float height = sizeF.Height;
			if (flag)
			{
				width = 3f * height / 2f;
			}
			return new SizeF(width, height);
		}
		Size size = Struct37.smethod_3(interface42_0, "This is a girl", class804_0.method_0().Font);
		float width2 = (float)size.Height * float_0;
		float num = size.Height;
		if (flag)
		{
			width2 = 3f * num / 2f;
		}
		return new SizeF(width2, num);
	}

	internal static void smethod_3(Class804 class804_0, Rectangle rectangle_0)
	{
		Size size = class804_0.method_0().rectangle_1.Size;
		int height = rectangle_0.Height;
		int width = rectangle_0.Width;
		switch (class804_0.vmethod_0())
		{
		case Enum76.const_2:
		case Enum76.const_4:
			if (height > size.Height)
			{
				class804_0.method_0().rectangle_1.Y = rectangle_0.Y + (height - size.Height) / 2;
			}
			break;
		case Enum76.const_0:
		case Enum76.const_5:
			if (width > size.Width)
			{
				class804_0.method_0().rectangle_1.X = rectangle_0.X + (width - size.Width) / 2;
			}
			break;
		case Enum76.const_1:
		case Enum76.const_3:
			break;
		}
	}

	private static bool smethod_4(ChartType_Chart chartType_Chart_0)
	{
		if (chartType_Chart_0 != ChartType_Chart.Line && chartType_Chart_0 != ChartType_Chart.LineWithDataMarkers && chartType_Chart_0 != ChartType_Chart.LineStackedWithDataMarkers && chartType_Chart_0 != ChartType_Chart.Line100PercentStackedWithDataMarkers && chartType_Chart_0 != ChartType_Chart.LineStacked && chartType_Chart_0 != ChartType_Chart.Line100PercentStacked && chartType_Chart_0 != ChartType_Chart.Scatter && chartType_Chart_0 != ChartType_Chart.ScatterConnectedByLinesWithDataMarker && chartType_Chart_0 != ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker && chartType_Chart_0 != ChartType_Chart.ScatterConnectedByCurvesWithDataMarker && chartType_Chart_0 != ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker && chartType_Chart_0 != ChartType_Chart.Radar && chartType_Chart_0 != ChartType_Chart.Bubble)
		{
			return true;
		}
		return false;
	}

	internal static bool smethod_5(ChartType_Chart chartType_Chart_0)
	{
		if (chartType_Chart_0 != ChartType_Chart.LineWithDataMarkers && chartType_Chart_0 != ChartType_Chart.LineStackedWithDataMarkers && chartType_Chart_0 != ChartType_Chart.Line100PercentStackedWithDataMarkers && chartType_Chart_0 != ChartType_Chart.Scatter && chartType_Chart_0 != ChartType_Chart.ScatterConnectedByLinesWithDataMarker && chartType_Chart_0 != ChartType_Chart.ScatterConnectedByCurvesWithDataMarker && chartType_Chart_0 != ChartType_Chart.RadarWithDataMarkers && chartType_Chart_0 != ChartType_Chart.Bubble)
		{
			return false;
		}
		return true;
	}

	internal static void smethod_6(Interface42 interface42_0, RectangleF rectangleF_0, Class810 class810_0)
	{
		ChartType_Chart type = class810_0.Type;
		if (smethod_4(type))
		{
			float width = rectangleF_0.Width;
			RectangleF rectangleF_ = new RectangleF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f - width / 2f, width, width);
			Struct18.smethod_0(interface42_0, rectangleF_, class810_0.method_7());
			Struct29.smethod_2(interface42_0, rectangleF_, class810_0.method_6());
			return;
		}
		if (class810_0.method_6().IsVisible)
		{
			Struct29.smethod_0(interface42_0, rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f, rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f, class810_0.method_6());
		}
		if (!smethod_5(type))
		{
			return;
		}
		float float_ = rectangleF_0.X + rectangleF_0.Width / 2f;
		float float_2 = rectangleF_0.Y + rectangleF_0.Height / 2f;
		float num;
		if (class810_0.method_8().MarkerSize == 0)
		{
			num = rectangleF_0.Height * float_0;
		}
		else
		{
			int num2 = (int)((float)(class810_0.Marker.MarkerSize * 72) / interface42_0.imethod_51());
			if ((float)num2 <= rectangleF_0.Height * float_0)
			{
				num = class810_0.method_8().MarkerSize;
			}
			else
			{
				float num3 = num2 / class810_0.Chart.method_3().Height;
				if (num3 > 1f)
				{
					num3 = 1f;
				}
				num = rectangleF_0.Height * float_0 * (1f + num3);
				num = (int)((double)(num * interface42_0.imethod_51() / 72f) + 0.5);
			}
		}
		class810_0.method_8().MarkerSize = (int)num;
		smethod_8(interface42_0, float_, float_2, class810_0.method_8(), class810_0.method_8().MarkerSize, bool_0: true);
	}

	internal static Enum65 smethod_7(Class810 class810_0, int int_1)
	{
		if (int_1 == -1)
		{
			return Enum65.const_7;
		}
		if (class810_0.Type == ChartType_Chart.Bubble)
		{
			return Enum65.const_1;
		}
		int_1 %= 9;
		int_1 += 2;
		return int_1 switch
		{
			2 => Enum65.const_3, 
			3 => Enum65.const_7, 
			4 => Enum65.const_9, 
			5 => Enum65.const_10, 
			6 => Enum65.const_8, 
			7 => Enum65.const_1, 
			8 => Enum65.const_6, 
			9 => Enum65.const_4, 
			10 => Enum65.const_2, 
			_ => Enum65.const_5, 
		};
	}

	internal static void smethod_8(Interface42 interface42_0, float float_2, float float_3, Class807 class807_0, float float_4, bool bool_0)
	{
		if (class807_0.MarkerStyle == Enum65.const_5)
		{
			return;
		}
		using Brush brush_2 = new SolidBrush(class807_0.method_0().ForegroundColor);
		using Pen pen_ = new Pen(class807_0.method_1().Color);
		using Brush brush_ = new SolidBrush(class807_0.method_1().Color);
		switch (class807_0.MarkerStyle)
		{
		case Enum65.const_3:
		{
			float_4 -= 1f;
			PointF[] array2 = new PointF[4];
			array2[0].X = float_2 - float_4 / 2f;
			array2[0].Y = float_3;
			array2[1].X = float_2;
			array2[1].Y = float_3 - float_4 / 2f;
			array2[2].X = float_2 + float_4 / 2f;
			array2[2].Y = float_3;
			array2[3].X = float_2;
			array2[3].Y = float_3 + float_4 / 2f;
			interface42_0.imethod_35(brush_2, array2);
			interface42_0.imethod_20(pen_, array2);
			break;
		}
		case Enum65.const_7:
		{
			float_4 -= 2f;
			float num = float_4;
			float num2 = float_4;
			float_2 -= num / 2f;
			float_3 -= num2 / 2f;
			interface42_0.imethod_38(brush_2, float_2, float_3, num, num2);
			interface42_0.imethod_23(pen_, float_2, float_3, num, num2);
			break;
		}
		case Enum65.const_9:
		{
			float_4 -= 1f;
			PointF[] array = new PointF[3];
			array[0].X = float_2 - float_4 / 2f;
			array[0].Y = float_3 + float_4 / 2f;
			array[1].X = float_2;
			array[1].Y = float_3 - float_4 / 2f;
			array[2].X = float_2 + float_4 / 2f;
			array[2].Y = float_3 + float_4 / 2f;
			interface42_0.imethod_35(brush_2, array);
			interface42_0.imethod_20(pen_, array);
			break;
		}
		case Enum65.const_10:
		{
			float num = float_4;
			float num2 = float_4;
			float_2 -= num / 2f;
			float_3 -= num2 / 2f;
			interface42_0.imethod_38(brush_2, float_2, float_3, num, num2);
			interface42_0.imethod_16(pen_, float_2 + 2f, float_3 + 2f, float_2 + float_4 - 2f, float_3 + float_4 - 2f);
			interface42_0.imethod_16(pen_, float_2 + 2f, float_3 + float_4 - 2f, float_2 + float_4 - 2f, float_3 + 2f);
			break;
		}
		case Enum65.const_8:
		{
			float_4 -= 2f;
			float num = float_4;
			float num2 = float_4;
			float_2 -= num / 2f;
			float_3 -= num2 / 2f;
			interface42_0.imethod_38(brush_2, float_2, float_3, num, num2);
			interface42_0.imethod_16(pen_, float_2, float_3, float_2 + num, float_3 + num2);
			interface42_0.imethod_16(pen_, float_2, float_3 + num2, float_2 + num, float_3);
			interface42_0.imethod_16(pen_, float_2 + num / 2f, float_3, float_2 + num / 2f, float_3 + num2);
			break;
		}
		case Enum65.const_1:
		{
			float_4 = ((!bool_0) ? (float_4 - 1f) : ((!(float_4 <= 4f)) ? (float_4 - 2f) : (float_4 - 1f)));
			float num = float_4;
			float num2 = float_4;
			float_2 -= num / 2f;
			float_3 -= num2 / 2f;
			interface42_0.imethod_32(brush_2, float_2, float_3, num, num2);
			interface42_0.imethod_10(pen_, float_2, float_3, num, num2);
			break;
		}
		case Enum65.const_6:
		{
			float_4 -= 2f;
			float num = float_4;
			float num2 = float_4;
			float_2 -= num / 2f;
			float_3 -= num2 / 2f;
			interface42_0.imethod_38(brush_2, float_2, float_3, num, num2);
			interface42_0.imethod_16(pen_, float_2, float_3 + num2 / 2f, float_2 + num, float_3 + num2 / 2f);
			interface42_0.imethod_16(pen_, float_2 + num / 2f, float_3, float_2 + num / 2f, float_3 + num2);
			break;
		}
		case Enum65.const_4:
		{
			float num = (int)(Math.Ceiling(float_4) / 2.0 + 1.0);
			float num2 = (int)(float_4 / 5f) / 2 * 2;
			num2 = ((num2 < 2f) ? 2f : num2);
			float_3 -= num2 / 2f;
			interface42_0.imethod_38(brush_, float_2, float_3, num, num2);
			break;
		}
		case Enum65.const_2:
		{
			float num = (int)(Math.Ceiling(float_4) / 2.0 + 1.0);
			num *= 2f;
			float num2 = (int)(float_4 / 5f) / 2 * 2;
			num2 = ((num2 < 2f) ? 2f : num2);
			float_2 -= num / 2f;
			float_3 -= num2 / 2f;
			interface42_0.imethod_38(brush_, float_2, float_3, num, num2);
			break;
		}
		}
	}

	internal static bool smethod_9(Class787 class787_0)
	{
		if (class787_0.method_7().Count != 1)
		{
			return false;
		}
		Class810 @class = class787_0.method_7().method_9(0);
		ChartType_Chart[] array = new ChartType_Chart[50]
		{
			ChartType_Chart.Column,
			ChartType_Chart.Column100PercentStacked,
			ChartType_Chart.Column3D,
			ChartType_Chart.Column3D100PercentStacked,
			ChartType_Chart.Column3DClustered,
			ChartType_Chart.Column3DStacked,
			ChartType_Chart.ColumnStacked,
			ChartType_Chart.Bar,
			ChartType_Chart.Bar100PercentStacked,
			ChartType_Chart.Bar3D100PercentStacked,
			ChartType_Chart.Bar3DClustered,
			ChartType_Chart.BarStacked,
			ChartType_Chart.Line,
			ChartType_Chart.Line100PercentStacked,
			ChartType_Chart.Line100PercentStackedWithDataMarkers,
			ChartType_Chart.Line3D,
			ChartType_Chart.LineStacked,
			ChartType_Chart.LineStackedWithDataMarkers,
			ChartType_Chart.LineWithDataMarkers,
			ChartType_Chart.Scatter,
			ChartType_Chart.ScatterConnectedByCurvesWithDataMarker,
			ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker,
			ChartType_Chart.ScatterConnectedByLinesWithDataMarker,
			ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker,
			ChartType_Chart.Radar,
			ChartType_Chart.RadarFilled,
			ChartType_Chart.RadarWithDataMarkers,
			ChartType_Chart.Bubble,
			ChartType_Chart.Bubble3D,
			ChartType_Chart.Cylinder,
			ChartType_Chart.Cylinder100PercentStacked,
			ChartType_Chart.CylindricalBar,
			ChartType_Chart.CylindricalBar100PercentStacked,
			ChartType_Chart.CylindricalBarStacked,
			ChartType_Chart.CylindricalColumn3D,
			ChartType_Chart.CylinderStacked,
			ChartType_Chart.Cone,
			ChartType_Chart.Cone100PercentStacked,
			ChartType_Chart.ConeStacked,
			ChartType_Chart.ConicalBar,
			ChartType_Chart.ConicalBar100PercentStacked,
			ChartType_Chart.ConicalBarStacked,
			ChartType_Chart.ConicalColumn3D,
			ChartType_Chart.Pyramid,
			ChartType_Chart.Pyramid100PercentStacked,
			ChartType_Chart.PyramidBar,
			ChartType_Chart.PyramidBar100PercentStacked,
			ChartType_Chart.PyramidBarStacked,
			ChartType_Chart.PyramidColumn3D,
			ChartType_Chart.PyramidStacked
		};
		int i;
		for (i = 0; i < array.Length && @class.Type != array[i]; i++)
		{
		}
		if (i == array.Length)
		{
			return false;
		}
		Class795 class2 = @class.method_10();
		_ = @class.Type;
		if (@class.IsColorVaried)
		{
			return true;
		}
		if (class2.Count > 0 && !smethod_10(class2))
		{
			return true;
		}
		return false;
	}

	private static bool smethod_10(Class795 class795_0)
	{
		int num = 1;
		while (true)
		{
			if (num < class795_0.Count)
			{
				if (!class795_0.method_1(0).method_3().method_4(class795_0.method_1(num).method_3()) || !class795_0.method_1(0).method_4().method_1(class795_0.method_1(num).method_4()) || !class795_0.method_1(0).method_5().method_2(class795_0.method_1(num).method_5()))
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

	internal static void smethod_11(Interface42 interface42_0, Class804 class804_0, Class810 class810_0)
	{
		if (!class804_0.method_0().imethod_3())
		{
			smethod_12(interface42_0, class804_0, class810_0);
			return;
		}
		class804_0.method_0().method_9();
		int num = class804_0.method_3(class810_0);
		Class787 chart = class804_0.method_0().Chart;
		_ = chart.Type;
		Class795 @class = class810_0.method_10();
		_ = chart.method_9().IsPlotOrderReversed;
		Struct24.smethod_0(interface42_0, class804_0.method_0());
		float height = (float)chart.Height / 3f;
		SizeF sizeF = smethod_2(interface42_0, class804_0);
		int num2 = class804_0.method_0().rectangle_0.Width - int_0 - (int)sizeF.Width;
		SizeF sizeF_ = new SizeF(num2, height);
		SizeF sizeF2 = smethod_14(interface42_0, class804_0, class810_0, sizeF_);
		int num3 = (int)(sizeF.Width + sizeF2.Width);
		int width = class804_0.method_0().rectangle_0.Width;
		int height2 = class804_0.method_0().rectangle_0.Height;
		int num4 = Struct40.smethod_4((float)(width - int_0) / (float)num3);
		if (num4 < 1)
		{
			num4 = 1;
		}
		int num5 = Struct40.smethod_3((float)num / (float)num4);
		float num6 = (width - int_0 - num3 * num4) / num4;
		if (num6 < 0f)
		{
			num6 = 0f;
		}
		float num7 = (int)(((float)(height2 - 2 * int_0) - sizeF2.Height * (float)num5) / (float)num5);
		if (num7 < 0f)
		{
			num7 = 0f;
		}
		SizeF sizeF3 = smethod_16(interface42_0, class804_0, class810_0);
		int num8 = (int)(sizeF.Width * (float)num + sizeF3.Width);
		if (num8 <= width - int_0)
		{
			num4 = 1;
			num5 = 1;
			num6 = (width - int_0 - num8) / num;
			num7 = (int)(((float)height2 - sizeF2.Height * 1f) / 1f);
		}
		float num9 = class804_0.method_0().rectangle_0.X + int_0;
		float num10 = class804_0.method_0().rectangle_0.Y;
		num9 += num6 / 2f;
		num10 += num7 / 2f;
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_47(class804_0.method_0().rectangle_0);
		float num11 = 0f;
		StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
		num11 = interface42_0.imethod_39("AA BB", class804_0.method_0().Font).Width - interface42_0.imethod_43("AA BB", class804_0.method_0().Font, int.MaxValue, stringFormat_).Width;
		num11 /= 2f;
		num11 = int_0;
		float height3 = interface42_0.imethod_43("AA BB", class804_0.method_0().Font, int.MaxValue, stringFormat_).Height;
		ArrayList arrayList = ((class810_0.method_21() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		for (int i = 1; i <= @class.Count; i++)
		{
			if (class804_0.method_4(i - 1))
			{
				continue;
			}
			if (num10 + sizeF.Height * (1f - float_0) > (float)(class804_0.method_0().rectangle_0.Y + class804_0.method_0().rectangle_0.Height))
			{
				break;
			}
			RectangleF rectangleF_ = new RectangleF(num9, num10, sizeF.Width, sizeF.Height);
			smethod_13(interface42_0, rectangleF_, class810_0, i - 1);
			string string_ = i.ToString();
			if (i - 1 < arrayList.Count)
			{
				string_ = smethod_15(chart, (Class791)arrayList[i - 1], chart.vmethod_0());
			}
			else if (arrayList.Count != 0)
			{
				string_ = " ";
			}
			float num12 = (width - int_0) / num4;
			float num13 = sizeF2.Height;
			if (num10 + sizeF.Height > (float)(class804_0.method_0().rectangle_0.Y + class804_0.method_0().rectangle_0.Height))
			{
				num13 -= num10 + sizeF.Height - (float)(class804_0.method_0().rectangle_0.Y + class804_0.method_0().rectangle_0.Height);
			}
			RectangleF rectangleF = new RectangleF(num9 + sizeF.Width, num10, num12, num13);
			SizeF sizeF4 = interface42_0.imethod_40(string_, class804_0.method_0().Font, new SizeF(num2, height));
			SizeF sizeF5 = interface42_0.imethod_42(string_, class804_0.method_0().Font, new SizeF(num12 - num11 * 2f, height), stringFormat_);
			float num14 = rectangleF.Y + sizeF.Height / 2f;
			RectangleF rectangleF_2 = new RectangleF(rectangleF.X + num11, num14 - height3 / 2f - 0.5f, sizeF5.Width, sizeF5.Height);
			rectangleF_2.Height += 1f;
			interface42_0.imethod_27(string_, class804_0.method_0().Font, new SolidBrush(class804_0.method_0().FontColor), rectangleF_2, stringFormat_);
			if (num8 <= width - int_0)
			{
				num9 += sizeF.Width + sizeF4.Width;
				num9 += num6;
				continue;
			}
			num9 += (float)num3;
			num9 += num6;
			if (i % num4 == 0)
			{
				num9 = (float)(class804_0.method_0().rectangle_0.X + int_0) + num6 / 2f;
				num10 += sizeF2.Height;
				num10 += num7;
			}
		}
		interface42_0.imethod_44(graphicsState_);
	}

	internal static void smethod_12(Interface42 interface42_0, Class804 class804_0, Class810 class810_0)
	{
		class804_0.method_0().method_9();
		int num = class804_0.method_3(class810_0);
		Class787 chart = class804_0.method_0().Chart;
		_ = chart.Type;
		Class795 @class = class810_0.method_10();
		_ = chart.method_9().IsPlotOrderReversed;
		Struct24.smethod_0(interface42_0, class804_0.method_0());
		float height = (float)chart.Height / 3f;
		SizeF sizeF = smethod_21(class804_0);
		int num2 = class804_0.method_8();
		int num3 = class804_0.method_9();
		float num4 = class804_0.method_13();
		float num5 = class804_0.method_14();
		int num6 = 1;
		int width = class804_0.method_0().rectangle_0.Width;
		int height2 = class804_0.method_0().rectangle_0.Height;
		float num7 = 0f;
		float num8 = 0f;
		SizeF sizeF2 = SizeF.Empty;
		int num9 = 0;
		SizeF sizeF_ = SizeF.Empty;
		SizeF sizeF3 = smethod_20(interface42_0, class804_0, class810_0);
		int num10 = (int)(sizeF.Width * (float)num + sizeF3.Width);
		bool flag = false;
		int num11;
		if (num10 <= width - num2)
		{
			num11 = num;
			int num12 = 1;
			num7 = (float)(width - num2 - num10) / (float)num11;
			num8 = (float)(height2 - class804_0.method_7() * 1) / 1f;
			flag = true;
		}
		else
		{
			int num13 = class804_0.method_0().rectangle_0.Width - num2 - num3;
			int num14 = num13 - (int)sizeF.Width;
			sizeF_ = new SizeF(num14, height);
			sizeF2 = smethod_19(interface42_0, class804_0, class810_0, sizeF_);
			num9 = (int)(sizeF.Width + sizeF2.Width + (float)(2 * num3));
			num11 = Struct40.smethod_4((float)num13 / (float)num9);
			if (num11 < 1)
			{
				num11 = 1;
			}
			int num12 = Struct40.smethod_3((float)num / (float)num11);
			num7 = (float)(num13 - num9 * num11) / (float)num11;
			num8 = ((float)height2 - sizeF2.Height * (float)num12) / (float)num12;
			num6 = Struct40.smethod_3(sizeF2.Height / class804_0.method_0().method_17());
		}
		if (num7 < 0f)
		{
			num7 = 0f;
		}
		if (num6 > 1)
		{
			if (num8 < num5)
			{
				num8 = num5;
			}
		}
		else if (num8 < num4)
		{
			num8 = num4;
		}
		float num15 = class804_0.method_0().rectangle_0.X;
		float num16 = class804_0.method_0().rectangle_0.Y;
		num15 += (float)num2;
		num15 += num7 / 2f;
		if (num8 > 0f)
		{
			num16 += num8 / 2f;
		}
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_47(class804_0.method_0().rectangle_0);
		StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
		ArrayList arrayList = ((class810_0.method_21() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		for (int i = 1; i <= @class.Count; i++)
		{
			if (class804_0.method_4(i - 1))
			{
				continue;
			}
			if (num16 > (float)class804_0.method_0().rectangle_0.Bottom)
			{
				break;
			}
			RectangleF rectangleF_ = new RectangleF(num15, num16, sizeF.Width, sizeF.Height);
			smethod_13(interface42_0, rectangleF_, class810_0, i - 1);
			string string_ = i.ToString();
			if (i - 1 < arrayList.Count)
			{
				string_ = smethod_15(chart, (Class791)arrayList[i - 1], chart.vmethod_0());
			}
			else if (arrayList.Count != 0)
			{
				string_ = " ";
			}
			PointF pointF = new PointF(num15 + sizeF.Width + (float)num3, num16);
			if (flag)
			{
				interface42_0.imethod_30(string_, class804_0.method_0().Font, new SolidBrush(class804_0.method_0().FontColor), pointF.X, pointF.Y, stringFormat_);
				SizeF sizeF4 = Struct37.smethod_14(interface42_0, string_, class804_0.method_0().Font, class804_0.method_0().rectangle_0.Size);
				num15 += sizeF.Width + sizeF4.Width + (float)(2 * num3);
				num15 += num7;
				continue;
			}
			float width2 = Struct40.smethod_3(sizeF_.Width);
			float height3 = Struct40.smethod_3(sizeF_.Height);
			interface42_0.imethod_27(rectangleF_0: new RectangleF(pointF.X, pointF.Y, width2, height3), string_0: string_, font_0: class804_0.method_0().Font, brush_0: new SolidBrush(class804_0.method_0().FontColor), stringFormat_0: stringFormat_);
			num15 += (float)num9;
			num15 += num7;
			if (i % num11 == 0)
			{
				num15 = (float)(class804_0.method_0().rectangle_0.X + num2) + num7 / 2f;
				num16 += sizeF2.Height;
				num16 += num8;
			}
		}
		interface42_0.imethod_44(graphicsState_);
	}

	internal static void smethod_13(Interface42 interface42_0, RectangleF rectangleF_0, Class810 class810_0, int int_1)
	{
		ChartType_Chart type = class810_0.Type;
		class810_0.Chart.method_14(class810_0.vmethod_7()).GetColor(class810_0.Index);
		Class796 @class = class810_0.method_10().method_1(int_1);
		if (@class == null)
		{
			@class = class810_0.method_0();
		}
		if (class810_0.method_37())
		{
			float num = class810_0.Chart.method_6().method_10();
			RectangleF rectangleF_ = new RectangleF(rectangleF_0.X, rectangleF_0.Y + (rectangleF_0.Height - num) / 2f, num, num);
			using (Brush brush_ = Struct18.smethod_1(@class.method_3(), rectangleF_))
			{
				interface42_0.imethod_31(brush_, rectangleF_);
			}
			using Pen pen_ = Struct29.smethod_5(@class.method_4());
			interface42_0.imethod_9(pen_, rectangleF_);
			return;
		}
		if (smethod_4(type))
		{
			float width = rectangleF_0.Width;
			RectangleF rectangleF_2 = new RectangleF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f - width / 2f, width, width);
			Struct18.smethod_0(interface42_0, rectangleF_2, @class.method_3());
			Struct29.smethod_2(interface42_0, rectangleF_2, @class.method_4());
			return;
		}
		if (class810_0.method_6().IsVisible && class810_0.Type != ChartType_Chart.Bubble && class810_0.Type != ChartType_Chart.Bubble3D)
		{
			Struct29.smethod_0(interface42_0, rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f, rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f, @class.method_4());
		}
		if (!smethod_5(type))
		{
			return;
		}
		float float_ = rectangleF_0.X + rectangleF_0.Width / 2f;
		float float_2 = rectangleF_0.Y + rectangleF_0.Height / 2f;
		float float_3;
		if (class810_0.method_8().MarkerSize == 0)
		{
			float_3 = rectangleF_0.Height * float_0;
		}
		else
		{
			int num2 = (int)((float)(class810_0.Marker.MarkerSize * 72) / interface42_0.imethod_51());
			if ((float)num2 <= rectangleF_0.Height * float_0)
			{
				float_3 = class810_0.method_8().MarkerSize;
			}
			else
			{
				float num3 = num2 / class810_0.Chart.method_3().Height;
				if (num3 > 1f)
				{
					num3 = 1f;
				}
				float_3 = rectangleF_0.Height * float_0 * (1f + num3);
				float_3 = (int)((double)(float_3 * interface42_0.imethod_51() / 72f) + 0.5);
			}
		}
		smethod_8(interface42_0, float_, float_2, @class.method_5(), float_3, bool_0: true);
	}

	internal static SizeF smethod_14(Interface42 interface42_0, Class804 class804_0, Class810 class810_0, SizeF sizeF_0)
	{
		Class795 @class = class810_0.method_10();
		SizeF result = new SizeF(0f, 0f);
		Class787 chart = class804_0.method_0().Chart;
		ArrayList arrayList = ((class810_0.method_21() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < @class.Count; i++)
			{
				SizeF sizeF;
				if (arrayList.Count >= @class.Count)
				{
					Class791 class791_ = (Class791)arrayList[i];
					string string_ = smethod_15(chart, class791_, chart.vmethod_0());
					sizeF = Class1181.smethod_6(Struct37.smethod_0(interface42_0, string_, 0, class804_0.method_0().Font, sizeF_0, Enum82.const_1, Enum82.const_1));
				}
				else
				{
					sizeF = interface42_0.imethod_39(" ", class804_0.method_0().Font);
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
			for (int j = 1; j <= @class.Count; j++)
			{
				SizeF sizeF = Class1181.smethod_6(Struct37.smethod_0(interface42_0, j.ToString(), 0, class804_0.method_0().Font, sizeF_0, Enum82.const_1, Enum82.const_1));
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
		if (result.Width == 0f)
		{
			return new SizeF(0f, class804_0.method_7());
		}
		return result;
	}

	private static string smethod_15(Class787 class787_0, Class791 class791_0, bool bool_0)
	{
		string string_ = class791_0.imethod_3();
		if (class791_0.imethod_5())
		{
			double double_ = Convert.ToDouble(class791_0.imethod_0());
			DateTime dateTimeFromDouble = Struct40.GetDateTimeFromDouble(double_, bool_0);
			return Struct65.smethod_0(class787_0.vmethod_2(), dateTimeFromDouble, string_);
		}
		return Struct65.smethod_0(class787_0.vmethod_2(), class791_0.imethod_0(), string_);
	}

	internal static SizeF smethod_16(Interface42 interface42_0, Class804 class804_0, Class810 class810_0)
	{
		Class787 chart = class804_0.method_0().Chart;
		Class795 @class = class810_0.method_10();
		SizeF result = new SizeF(0f, 0f);
		ArrayList arrayList = ((class810_0.method_21() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				SizeF sizeF;
				if (arrayList.Count >= @class.Count)
				{
					Class791 class791_ = (Class791)arrayList[i];
					string string_ = smethod_15(chart, class791_, chart.vmethod_0());
					sizeF = interface42_0.imethod_39(string_, class804_0.method_0().Font);
				}
				else
				{
					sizeF = interface42_0.imethod_39(" ", class804_0.method_0().Font);
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
			for (int j = 1; j <= @class.Count; j++)
			{
				SizeF sizeF = interface42_0.imethod_39(j.ToString(), class804_0.method_0().Font);
				result.Width += sizeF.Width;
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		return result;
	}

	internal static Size smethod_17(Interface42 interface42_0, Class804 class804_0, Class810 class810_0)
	{
		if (!class804_0.method_0().imethod_3())
		{
			return class804_0.method_0().method_4();
		}
		class810_0.method_10();
		int num = class804_0.method_3(class810_0);
		int num4;
		int num5;
		if (class804_0.vmethod_0() != Enum76.const_5 && class804_0.vmethod_0() != 0 && (class804_0.vmethod_0() != Enum76.const_3 || class804_0.vmethod_1()))
		{
			int num2 = class804_0.Chart.ChartArea.Height - 2 * Class817.int_0;
			int num3 = class804_0.Chart.Width / 3;
			SizeF sizeF_ = new SizeF(num3, num2);
			SizeF sizeF = smethod_2(interface42_0, class804_0);
			SizeF sizeF2 = smethod_14(interface42_0, class804_0, class810_0, sizeF_);
			num4 = (int)((float)(2 * int_0) + sizeF.Width + sizeF2.Width) + 1;
			num5 = (int)(sizeF2.Height + (float)(2 * int_0) + (float)(num - 1) * sizeF2.Height);
			if (num4 > num3)
			{
				num4 = num3;
			}
			if (num5 > num2)
			{
				num5 = num2;
			}
		}
		else
		{
			SizeF sizeF_ = new SizeF(class804_0.Chart.Width - 2 * Class817.int_0, class804_0.Chart.ChartArea.Height / 2 - Class817.int_0);
			SizeF sizeF3 = smethod_2(interface42_0, class804_0);
			SizeF sizeF4 = smethod_14(interface42_0, class804_0, class810_0, sizeF_);
			int num6 = (int)(sizeF3.Width + sizeF4.Width) + 1;
			int num7 = class804_0.Chart.ChartArea.Width - 2 * Class817.int_0 - int_0;
			int num8 = num7 / num6;
			if (num8 == 0)
			{
				num8 = 1;
			}
			SizeF sizeF2 = smethod_16(interface42_0, class804_0, class810_0);
			int num9 = (int)(sizeF3.Width * (float)num + sizeF2.Width) + 1;
			if (num9 <= num7)
			{
				num4 = int_0 + num9;
				num5 = (int)sizeF2.Height + 2 * int_0;
			}
			else
			{
				num4 = int_0 + num8 * num6;
				num5 = Struct40.smethod_3((float)num / (float)num8) * (int)sizeF2.Height + 2 * int_0;
				int num10 = class804_0.Chart.ChartArea.Height / 2 - Class817.int_0;
				if (num5 > num10)
				{
					int num11 = 0;
					int num12 = 0;
					while (num11 <= num10 && num12 <= num)
					{
						num11 = Struct40.smethod_3((float)num12 / (float)num8) * (int)sizeF2.Height + 2 * int_0;
						num12 += num8;
					}
					if (num12 < num && num11 != num10)
					{
						if (num11 > num10)
						{
							num5 = num11 - (int)sizeF2.Height;
						}
					}
					else
					{
						num5 = num11;
					}
				}
			}
			if (num5 > class804_0.Chart.ChartArea.Height - 2 * Class817.int_0)
			{
				num5 = class804_0.Chart.ChartArea.Height - 2 * Class817.int_0;
			}
		}
		return new Size(num4, num5);
	}

	internal static Point smethod_18(Interface42 interface42_0, Class804 class804_0, Class810 class810_0, ref Rectangle rectangle_0)
	{
		float num = 0f;
		float num2 = 0f;
		Size size = smethod_17(interface42_0, class804_0, class810_0);
		int height = class804_0.Chart.Height;
		int width = class804_0.Chart.Width;
		int num3 = Class817.int_0;
		int int_ = Class817.int_1;
		class804_0.method_0().rectangle_1.Size = size;
		switch (class804_0.vmethod_0())
		{
		case Enum76.const_0:
			num = (width - size.Width) / 2;
			num2 = height - num3 - size.Height;
			rectangle_0.Height -= size.Height + int_;
			break;
		case Enum76.const_1:
			num = width - num3 - size.Width;
			num2 = ((!class804_0.Chart.method_12().IsVisible) ? ((float)num3) : ((float)(num3 + class804_0.Chart.method_12().method_0().rectangle_1.Height + int_)));
			rectangle_0.Width -= size.Width + int_;
			if (size.Height * 2 < rectangle_0.Height)
			{
				rectangle_0.Height -= size.Height + int_;
			}
			break;
		case Enum76.const_2:
			num = num3;
			num2 = (height - size.Height) / 2;
			rectangle_0.X += size.Width + int_;
			rectangle_0.Width -= size.Width + int_;
			break;
		case Enum76.const_3:
			num = class804_0.method_0().X * class804_0.Chart.Width / 4000;
			num2 = class804_0.method_0().Y * class804_0.Chart.Height / 4000;
			class804_0.method_0().rectangle_1.X = (int)num;
			class804_0.method_0().rectangle_1.Y = (int)num2;
			class804_0.method_0().rectangle_1.Size = size;
			return new Point(class804_0.method_0().rectangle_1.X, class804_0.method_0().rectangle_1.Y);
		case Enum76.const_4:
			num = width - num3 - size.Width;
			num2 = (height - size.Height) / 2;
			rectangle_0.Width -= size.Width + int_;
			break;
		case Enum76.const_5:
			num = (width - size.Width) / 2;
			num2 = num3 + class804_0.Chart.method_12().method_0().rectangle_1.Height + int_;
			rectangle_0.Y += size.Height + int_;
			rectangle_0.Height -= size.Height + int_;
			break;
		}
		class804_0.method_0().rectangle_1.X = (int)num;
		class804_0.method_0().rectangle_1.Y = (int)num2;
		class804_0.method_0().rectangle_1.Size = size;
		return new Point(class804_0.method_0().rectangle_1.X, class804_0.method_0().rectangle_1.Y);
	}

	internal static SizeF smethod_19(Interface42 interface42_0, Class804 class804_0, Class810 class810_0, SizeF sizeF_0)
	{
		Class795 @class = class810_0.method_10();
		SizeF result = new SizeF(0f, 0f);
		Class787 chart = class804_0.method_0().Chart;
		ArrayList arrayList = ((class810_0.method_21() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < @class.Count; i++)
			{
				string text = "";
				if (arrayList.Count >= @class.Count)
				{
					Class791 class791_ = (Class791)arrayList[i];
					text = smethod_15(chart, class791_, chart.vmethod_0());
				}
				else
				{
					text = " ";
				}
				SizeF sizeF = Struct37.smethod_7(interface42_0, text, class804_0.method_0().Font, sizeF_0);
				if (sizeF.Width > result.Width)
				{
					result.Width = sizeF.Width;
				}
				if (sizeF.Height > result.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		else
		{
			for (int j = 1; j <= @class.Count; j++)
			{
				string string_ = j.ToString();
				SizeF sizeF = Struct37.smethod_7(interface42_0, string_, class804_0.method_0().Font, sizeF_0);
				if (sizeF.Width > result.Width)
				{
					result.Width = sizeF.Width;
				}
				if (sizeF.Height > result.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		return result;
	}

	internal static SizeF smethod_20(Interface42 interface42_0, Class804 class804_0, Class810 class810_0)
	{
		int num = class804_0.method_9();
		Class787 chart = class804_0.method_0().Chart;
		Class795 @class = class810_0.method_10();
		SizeF result = new SizeF(0f, 0f);
		ArrayList arrayList = ((class810_0.method_21() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				string text = "";
				if (arrayList.Count >= @class.Count)
				{
					Class791 class791_ = (Class791)arrayList[i];
					text = smethod_15(chart, class791_, chart.vmethod_0());
				}
				else
				{
					text = " ";
				}
				SizeF sizeF = Struct37.smethod_14(interface42_0, text, class804_0.method_0().Font, class804_0.method_0().rectangle_0.Size);
				sizeF.Width += 2 * num;
				result.Width += sizeF.Width;
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		else
		{
			for (int j = 1; j <= @class.Count; j++)
			{
				string string_ = j.ToString();
				SizeF sizeF = Struct37.smethod_14(interface42_0, string_, class804_0.method_0().Font, class804_0.method_0().rectangle_0.Size);
				sizeF.Width += 2 * num;
				result.Width += sizeF.Width;
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		return result;
	}

	internal static SizeF smethod_21(Class804 class804_0)
	{
		return new SizeF(class804_0.method_10() - 1, class804_0.method_7());
	}

	internal static Point smethod_22(Interface42 interface42_0, Class804 class804_0, ref Rectangle rectangle_0)
	{
		float num = 0f;
		float num2 = 0f;
		Size size = smethod_23(interface42_0, class804_0);
		int height = class804_0.method_0().Chart.Height;
		int width = class804_0.method_0().Chart.Width;
		int num3 = Class817.int_0;
		int int_ = Class817.int_1;
		switch (class804_0.vmethod_0())
		{
		case Enum76.const_0:
			num = (width - size.Width) / 2;
			num2 = height - num3 - size.Height;
			rectangle_0.Height -= size.Height + int_;
			break;
		case Enum76.const_1:
			num = width - num3 - size.Width;
			num2 = ((!class804_0.method_0().Chart.method_12().IsVisible) ? ((float)num3) : ((float)(num3 + class804_0.method_0().Chart.method_12().method_0().rectangle_1.Height + int_)));
			rectangle_0.Width -= size.Width + int_;
			if (rectangle_0.Height > size.Height * 2)
			{
				rectangle_0.Y += size.Height + int_;
				rectangle_0.Height -= size.Height + int_;
			}
			break;
		case Enum76.const_2:
			num = num3;
			num2 = (height - size.Height) / 2;
			rectangle_0.X += size.Width + int_;
			rectangle_0.Width -= size.Width + int_;
			break;
		case Enum76.const_3:
			num = class804_0.method_0().method_7();
			num2 = class804_0.method_0().method_8();
			class804_0.method_0().rectangle_1.X = (int)num;
			class804_0.method_0().rectangle_1.Y = (int)num2;
			class804_0.method_0().rectangle_1.Size = size;
			return new Point(class804_0.method_0().rectangle_1.X, class804_0.method_0().rectangle_1.Y);
		case Enum76.const_4:
			num = width - num3 - size.Width;
			num2 = (height - size.Height) / 2;
			rectangle_0.Width -= size.Width + int_;
			break;
		case Enum76.const_5:
			num = (width - size.Width) / 2;
			num2 = num3 + class804_0.method_0().Chart.method_12().method_0().rectangle_1.Height + int_;
			rectangle_0.Y += size.Height + int_;
			rectangle_0.Height -= size.Height + int_;
			break;
		}
		class804_0.method_0().rectangle_1.X = (int)num;
		class804_0.method_0().rectangle_1.Y = (int)num2;
		class804_0.method_0().rectangle_1.Size = size;
		return new Point(class804_0.method_0().rectangle_1.X, class804_0.method_0().rectangle_1.Y);
	}

	internal static Size smethod_23(Interface42 interface42_0, Class804 class804_0)
	{
		SizeF sizeF = smethod_25(interface42_0, class804_0);
		if (!class804_0.method_0().imethod_3())
		{
			Size result = class804_0.method_0().method_4();
			SizeF sizeF2 = smethod_26(interface42_0, class804_0, new SizeF(class804_0.method_0().Chart.Width, class804_0.method_0().Chart.Height));
			int num = Struct40.smethod_3(sizeF.Width + sizeF2.Width);
			if (Struct40.smethod_4(result.Width / num) >= 2)
			{
				class804_0.method_6(bool_4: false);
			}
			else
			{
				class804_0.method_6(bool_4: true);
			}
			return result;
		}
		int num2 = class804_0.method_8();
		int num3 = class804_0.method_9();
		class804_0.method_0().Chart.method_7();
		int num4 = class804_0.method_1().method_1();
		int num7;
		int num8;
		if (class804_0.vmethod_0() != Enum76.const_5 && class804_0.vmethod_0() != 0 && (class804_0.vmethod_0() != Enum76.const_3 || class804_0.vmethod_1()))
		{
			class804_0.method_6(bool_4: true);
			int num5 = class804_0.method_0().Chart.ChartArea.Height - 2 * Class817.int_0;
			int num6 = class804_0.method_0().Chart.Width / 3;
			SizeF sizeF_ = new SizeF(num6, num5);
			SizeF sizeF3 = smethod_26(interface42_0, class804_0, sizeF_);
			num7 = Struct40.smethod_3((float)num2 + sizeF.Width + sizeF3.Width);
			num8 = Struct40.smethod_3((float)(2 * num2) + (float)num4 * (sizeF3.Height + (float)num3));
			if (num7 > num6)
			{
				num7 = num6;
			}
			if (num8 > num5)
			{
				num8 = num5;
			}
		}
		else
		{
			SizeF sizeF_ = new SizeF(class804_0.method_0().Chart.Width - 2 * Class817.int_0, class804_0.method_0().Chart.ChartArea.Height / 2 - Class817.int_0);
			SizeF sizeF3 = smethod_26(interface42_0, class804_0, sizeF_);
			int num9 = Struct40.smethod_3(sizeF.Width + sizeF3.Width);
			int num10 = Struct40.smethod_5(sizeF_.Width) - num2;
			int num11 = num10 / num9;
			if (num11 == 0)
			{
				num11 = 1;
			}
			SizeF sizeF4 = smethod_24(interface42_0, class804_0, sizeF_);
			int num12 = Struct40.smethod_3(sizeF.Width * (float)num4 + sizeF4.Width);
			if (num12 <= num10)
			{
				class804_0.method_6(bool_4: false);
				num7 = num2 + num12 + num3;
				num8 = Struct40.smethod_3(sizeF4.Height + (float)(2 * num2));
			}
			else
			{
				if (num11 > 1)
				{
					class804_0.method_6(bool_4: false);
				}
				num7 = num2 + num11 * num9 + num3;
				num8 = Struct40.smethod_3((float)num4 / (float)num11) * (Struct40.smethod_3(sizeF3.Height) + num3) + 2 * num2;
				int num13 = class804_0.method_0().Chart.ChartArea.Height / 2 - Class817.int_0;
				if (num8 > num13)
				{
					int num14 = 0;
					int num15 = 0;
					while (num14 <= num13 && num15 <= num4)
					{
						num14 = Struct40.smethod_3((float)num15 / (float)num11) * (Struct40.smethod_3(sizeF3.Height) + num3) + 2 * num2;
						num15 += num11;
					}
					if (num15 < num4 && num14 != num13)
					{
						if (num14 > num13)
						{
							num8 = num14 - (Struct40.smethod_3(sizeF3.Height) + num3);
						}
					}
					else
					{
						num8 = num14;
					}
				}
			}
			if (num8 > class804_0.method_0().Chart.ChartArea.Height - 2 * Class817.int_0)
			{
				num8 = class804_0.method_0().Chart.ChartArea.Height - 2 * Class817.int_0;
			}
		}
		return new Size(num7, num8);
	}

	internal static SizeF smethod_24(Interface42 interface42_0, Class804 class804_0, SizeF sizeF_0)
	{
		_ = class804_0.method_0().Chart;
		Class802 @class = class804_0.method_1();
		SizeF result = new SizeF(0f, 0f);
		int num = class804_0.method_9();
		for (int i = 0; i < @class.Count; i++)
		{
			string name = @class[i].Name;
			if (!@class[i].IsDeleted)
			{
				SizeF sizeF = Struct37.smethod_7(interface42_0, name, class804_0.method_0().Font, sizeF_0);
				sizeF.Width += 2 * num;
				result.Width += sizeF.Width;
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		return result;
	}

	internal static SizeF smethod_25(Interface42 interface42_0, Class804 class804_0)
	{
		if (class804_0.method_1().method_6())
		{
			return class804_0.method_12();
		}
		return new SizeF(class804_0.method_10(), class804_0.method_0().method_17());
	}

	internal static SizeF smethod_26(Interface42 interface42_0, Class804 class804_0, SizeF sizeF_0)
	{
		Class802 @class = class804_0.method_1();
		SizeF result = new SizeF(0f, 0f);
		int num = class804_0.method_9();
		for (int i = 0; i < @class.Count; i++)
		{
			Class803 class2 = @class[i];
			if (!class2.IsDeleted)
			{
				SizeF sizeF = Struct37.smethod_7(interface42_0, class2.Name, class804_0.method_0().Font, sizeF_0);
				sizeF.Width += 2 * num;
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

	internal static void smethod_27(Interface42 interface42_0, Class804 class804_0, bool bool_0, Class810 class810_0)
	{
		class804_0.method_0().method_9();
		ArrayList arrayList = class804_0.method_1().method_2(class804_0.method_5(), bool_0);
		int count = arrayList.Count;
		Class787 chart = class804_0.Chart;
		Struct24.smethod_0(interface42_0, class804_0.method_0());
		float height = (float)chart.Height / 3f;
		SizeF sizeF = smethod_25(interface42_0, class804_0);
		int num = class804_0.method_8();
		int num2 = class804_0.method_9();
		float num3 = class804_0.method_13();
		float num4 = class804_0.method_14();
		int num5 = 1;
		int width = class804_0.method_0().rectangle_0.Width;
		int height2 = class804_0.method_0().rectangle_0.Height;
		float num6 = 0f;
		float num7 = 0f;
		SizeF sizeF2 = SizeF.Empty;
		int num8 = 0;
		SizeF sizeF_ = SizeF.Empty;
		SizeF sizeF3 = smethod_24(interface42_0, class804_0, new SizeF(chart.Width, chart.Height));
		int num9 = (int)(sizeF.Width * (float)count + sizeF3.Width);
		bool flag = false;
		int num10;
		if (num9 <= width - num)
		{
			num10 = count;
			int num11 = 1;
			num6 = (float)(width - num - num9) / (float)num10;
			num7 = (float)(height2 - class804_0.method_7() * 1) / 1f;
			flag = true;
		}
		else
		{
			int num12 = class804_0.method_0().rectangle_0.Width - num;
			int num13 = num12 - (int)sizeF.Width;
			sizeF_ = new SizeF(num13, height);
			sizeF2 = smethod_26(interface42_0, class804_0, sizeF_);
			num8 = (int)(sizeF.Width + sizeF2.Width);
			num10 = ((num8 == 0) ? 1 : Struct40.smethod_4((float)num12 / (float)num8));
			if (num10 < 1)
			{
				num10 = 1;
			}
			int num11 = Struct40.smethod_3((float)count / (float)num10);
			if (num11 > 1 && num10 > num11)
			{
				int num14 = (int)Math.Ceiling((float)count / (float)num11);
				if (num14 < num10)
				{
					num10 = num14;
				}
			}
			num6 = (float)(num12 - num8 * num10) / (float)num10;
			num7 = ((float)height2 - sizeF2.Height * (float)num11) / (float)num11;
			num5 = Struct40.smethod_3(sizeF2.Height / class804_0.method_0().method_17());
		}
		if (num6 < 0f)
		{
			num6 = 0f;
		}
		if (num5 > 1)
		{
			if (num7 < num4)
			{
				num7 = num4;
			}
		}
		else if (num7 < num3)
		{
			num7 = num3;
		}
		float num15 = class804_0.method_0().rectangle_0.X;
		float num16 = class804_0.method_0().rectangle_0.Y;
		num15 += (float)num;
		num15 += num6 / 2f;
		num16 += Math.Abs(num7) / 2f;
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_47(class804_0.method_0().rectangle_0);
		StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class803 @class = (Class803)arrayList[i];
			if (num16 > (float)class804_0.method_0().rectangle_0.Bottom)
			{
				break;
			}
			RectangleF rectangleF_ = new RectangleF(num15, num16, sizeF.Width, sizeF.Height);
			smethod_28(interface42_0, class804_0, rectangleF_, @class);
			string name = @class.Name;
			PointF pointF = new PointF(num15 + sizeF.Width + (float)num2, num16);
			if (flag)
			{
				interface42_0.imethod_30(name, class804_0.method_0().Font, new SolidBrush(class804_0.method_0().FontColor), pointF.X, pointF.Y, stringFormat_);
				Size size = class804_0.method_0().rectangle_0.Size;
				if ((float)size.Height < class804_0.method_0().method_17())
				{
					size.Height = Struct40.smethod_5(class804_0.method_0().method_17() + 1f);
				}
				SizeF sizeF4 = Struct37.smethod_14(interface42_0, name, class804_0.method_0().Font, size);
				num15 += sizeF.Width + sizeF4.Width + (float)(2 * num2);
				num15 += num6;
				continue;
			}
			float width2 = Struct40.smethod_3(sizeF_.Width);
			float height3 = Struct40.smethod_3(sizeF_.Height);
			interface42_0.imethod_27(rectangleF_0: new RectangleF(pointF.X, pointF.Y, width2, height3), string_0: name, font_0: class804_0.method_0().Font, brush_0: new SolidBrush(class804_0.method_0().FontColor), stringFormat_0: stringFormat_);
			num15 += (float)num8;
			num15 += num6;
			if ((i + 1) % num10 == 0)
			{
				num15 = (float)(class804_0.method_0().rectangle_0.X + num) + num6 / 2f;
				num16 += sizeF2.Height;
				num16 += num7;
			}
		}
		interface42_0.imethod_44(graphicsState_);
	}

	internal static void smethod_28(Interface42 interface42_0, Class804 class804_0, RectangleF rectangleF_0, Class803 class803_0)
	{
		if (class803_0.Type == Enum56.const_1)
		{
			PointF pointF_ = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f);
			PointF pointF_2 = new PointF(rectangleF_0.Right, rectangleF_0.Y + rectangleF_0.Height / 2f);
			Struct29.smethod_1(interface42_0, pointF_, pointF_2, class803_0.method_2().method_0());
		}
		else
		{
			if (class803_0.Type != Enum56.const_0)
			{
				return;
			}
			Class810 @class = class803_0.method_0();
			if (@class.method_37())
			{
				float num = class804_0.method_10();
				RectangleF rectangleF_ = new RectangleF(rectangleF_0.X, rectangleF_0.Y + (rectangleF_0.Height - num) / 2f, num, num);
				using (Brush brush_ = Struct18.smethod_1(@class.method_7(), rectangleF_))
				{
					interface42_0.imethod_31(brush_, rectangleF_);
				}
				using Pen pen_ = Struct29.smethod_5(@class.method_6());
				interface42_0.imethod_9(pen_, rectangleF_);
				return;
			}
			if (@class.method_27())
			{
				if (@class.method_6().IsVisible)
				{
					Struct29.smethod_0(interface42_0, rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f, rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f, @class.method_6());
				}
				if (@class.method_8().MarkerStyle == Enum65.const_5)
				{
					return;
				}
				float float_ = rectangleF_0.X + rectangleF_0.Width / 2f;
				float float_2 = rectangleF_0.Y + rectangleF_0.Height / 2f;
				float float_3;
				if (@class.method_8().MarkerSize == 0)
				{
					float_3 = rectangleF_0.Height * float_0;
				}
				else
				{
					int num2 = (int)((float)(@class.Marker.MarkerSize * 72) / interface42_0.imethod_51());
					if ((float)num2 <= rectangleF_0.Height * float_0)
					{
						float_3 = @class.method_8().MarkerSize;
					}
					else
					{
						float num3 = num2 / @class.Chart.method_3().Height;
						if (num3 > 1f)
						{
							num3 = 1f;
						}
						float_3 = rectangleF_0.Height * float_0 * (1f + num3);
						float_3 = (int)((double)(float_3 * interface42_0.imethod_51() / 72f) + 0.5);
					}
				}
				smethod_8(interface42_0, float_, float_2, @class.method_8(), float_3, bool_0: true);
			}
			else
			{
				float width = rectangleF_0.Width;
				float num4 = class804_0.method_10();
				RectangleF rectangleF_2 = new RectangleF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f - num4 / 2f, width, num4);
				Struct18.smethod_0(interface42_0, rectangleF_2, @class.method_7());
				Struct29.smethod_2(interface42_0, rectangleF_2, @class.method_6());
			}
		}
	}
}
