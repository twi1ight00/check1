using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct53
{
	internal static int int_0 = 4;

	internal static float float_0 = 0.4f;

	private static SizeF smethod_0(Interface42 interface42_0, Class838 class838_0)
	{
		Class842 @class = class838_0.method_0().Chart.method_7();
		SizeF result = new SizeF(0f, 0f);
		for (int i = 0; i < @class.Count; i++)
		{
			Class844 class2 = @class.method_9(i);
			SizeF sizeF = interface42_0.imethod_39(class2.Name, class838_0.method_0().Font);
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

	private static bool smethod_1(Class842 class842_0)
	{
		bool result = false;
		for (int i = 0; i < class842_0.Count; i++)
		{
			Class844 @class = class842_0.method_9(i);
			if (@class.method_5().IsVisible && @class.method_26())
			{
				result = true;
				break;
			}
		}
		return result;
	}

	internal static SizeF smethod_2(Interface42 interface42_0, Class838 class838_0)
	{
		SizeF sizeF = smethod_0(interface42_0, class838_0);
		bool flag = smethod_1(class838_0.method_0().Chart.method_7());
		if (sizeF.Width == 0f)
		{
			if (flag)
			{
				return new SizeF(Class827.int_0, class838_0.method_0().method_15());
			}
			return new SizeF(class838_0.method_7(), class838_0.method_0().method_15());
		}
		float width = sizeF.Height * Class827.float_0;
		float height = sizeF.Height;
		if (flag)
		{
			width = Class827.int_0;
		}
		return new SizeF(width, height);
	}

	internal static void smethod_3(Class838 class838_0, Rectangle rectangle_0)
	{
		Size size = class838_0.method_0().rectangle_1.Size;
		int height = rectangle_0.Height;
		int width = rectangle_0.Width;
		switch (class838_0.vmethod_0())
		{
		case Enum76.const_0:
			class838_0.method_0().rectangle_1.X = rectangle_0.X + (width - size.Width) / 2;
			break;
		case Enum76.const_2:
			class838_0.method_0().rectangle_1.Y = rectangle_0.Y + (height - size.Height) / 2;
			break;
		case Enum76.const_4:
			class838_0.method_0().rectangle_1.Y = rectangle_0.Y + (height - size.Height) / 2;
			break;
		case Enum76.const_5:
			class838_0.method_0().rectangle_1.X = rectangle_0.X + (width - size.Width) / 2;
			break;
		case Enum76.const_1:
		case Enum76.const_3:
			break;
		}
	}

	internal static void smethod_4(Interface42 interface42_0, RectangleF rectangleF_0, Class844 class844_0)
	{
		_ = class844_0.Type;
		Class840 @class = (Class840)class844_0.method_5().Clone();
		int num = @class.Width;
		if (num > 2)
		{
			num = 2;
		}
		@class.method_0().Width = num;
		if (class844_0.method_35())
		{
			float width = rectangleF_0.Width;
			RectangleF rect = new RectangleF(rectangleF_0.X, rectangleF_0.Y + (rectangleF_0.Height - width) / 2f, width, width);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(rect);
			class844_0.method_6().method_9(graphicsPath);
			@class.method_11(graphicsPath);
			return;
		}
		if (!class844_0.method_26())
		{
			float width2 = rectangleF_0.Width;
			RectangleF rectangleF_ = new RectangleF(rectangleF_0.X, rectangleF_0.Y + (rectangleF_0.Height - width2) / 2f, width2, width2);
			class844_0.method_6().method_8(rectangleF_);
			@class.method_10(rectangleF_);
			return;
		}
		if (class844_0.method_5().IsVisible)
		{
			@class.method_8(new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f), new PointF(rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f));
		}
		if (class844_0.method_7().IsVisible)
		{
			float num2 = rectangleF_0.X + rectangleF_0.Width / 2f;
			float float_ = rectangleF_0.Y + rectangleF_0.Height / 2f;
			float num3 = rectangleF_0.Height * Class827.float_0;
			float num4 = class844_0.method_7().MarkerSize;
			if (num4 > num3)
			{
				num4 = num3;
			}
			class844_0.method_7().method_7(num2, float_, num4);
		}
	}

	internal static Enum65 smethod_5(Class844 class844_0, int int_1)
	{
		if (int_1 == -1)
		{
			return Enum65.const_7;
		}
		if (class844_0.Type == ChartType_Chart.Bubble)
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

	internal static bool smethod_6(Class821 class821_0)
	{
		if (class821_0.method_7().Count != 1)
		{
			return false;
		}
		Class844 @class = class821_0.method_7().method_9(0);
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
		Class830 class2 = @class.method_9();
		_ = @class.Type;
		if (@class.IsColorVaried)
		{
			return true;
		}
		if (class2.Count > 0 && !smethod_7(class2))
		{
			return true;
		}
		return false;
	}

	private static bool smethod_7(Class830 class830_0)
	{
		int num = 1;
		while (true)
		{
			if (num < class830_0.Count)
			{
				if (!class830_0.method_1(0).method_3().method_3(class830_0.method_1(num).method_3()) || !class830_0.method_1(0).method_4().method_4(class830_0.method_1(num).method_4()) || !class830_0.method_1(0).method_5().method_3(class830_0.method_1(num).method_5()))
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

	internal static void smethod_8(Interface42 interface42_0, Class838 class838_0, Class844 class844_0)
	{
		class838_0.method_0().method_9();
		Class821 chart = class838_0.method_0().Chart;
		_ = chart.Type;
		Class830 @class = class844_0.method_9();
		_ = chart.method_9().IsPlotOrderReversed;
		class838_0.method_0().method_19();
		SizeF sizeF = smethod_2(interface42_0, class838_0);
		SizeF sizeF2 = smethod_10(interface42_0, class838_0, class844_0);
		int num = (int)(sizeF.Width + sizeF2.Width);
		int width = class838_0.method_0().rectangle_0.Width;
		int height = class838_0.method_0().rectangle_0.Height;
		int num2 = 0;
		num2 = ((num == 0) ? 1 : ((width - int_0) / num));
		if (num2 <= 0)
		{
			num2 = 1;
		}
		int num3 = Struct63.smethod_3((float)@class.Count / (float)num2);
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
		SizeF sizeF3 = smethod_13(interface42_0, class838_0, class844_0);
		int num6 = (int)(sizeF.Width * (float)@class.Count + sizeF3.Width);
		if (num6 <= width - int_0)
		{
			num2 = 1;
			num3 = 1;
			num4 = (width - int_0 - num6) / @class.Count;
			num5 = (int)(((float)height - sizeF2.Height * 1f) / 1f);
		}
		float num7 = class838_0.method_0().rectangle_0.X + int_0;
		float num8 = class838_0.method_0().rectangle_0.Y;
		num7 += num4 / 2f;
		num8 += num5 / 2f;
		ArrayList arrayList = ((class844_0.method_20() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		for (int i = 1; i <= @class.Count; i++)
		{
			if (!(num8 + sizeF.Height * (1f - float_0) <= (float)(class838_0.method_0().rectangle_0.Y + class838_0.method_0().rectangle_0.Height)))
			{
				break;
			}
			RectangleF rectangleF_ = new RectangleF(num7, num8, sizeF.Width, sizeF.Height);
			smethod_9(interface42_0, rectangleF_, class844_0, i - 1);
			string string_ = i.ToString();
			if (i - 1 < arrayList.Count)
			{
				string_ = smethod_11(chart, (Class825)arrayList[i - 1], chart.vmethod_0());
			}
			else if (arrayList.Count != 0)
			{
				string_ = " ";
			}
			float width2 = (width - int_0) / num2;
			float num9 = sizeF2.Height;
			if (num8 + sizeF.Height > (float)(class838_0.method_0().rectangle_0.Y + class838_0.method_0().rectangle_0.Height))
			{
				num9 -= num8 + sizeF.Height - (float)(class838_0.method_0().rectangle_0.Y + class838_0.method_0().rectangle_0.Height);
			}
			RectangleF rectangleF_2 = new RectangleF(num7 + sizeF.Width, num8, width2, num9);
			SizeF sizeF4 = interface42_0.imethod_39(string_, class838_0.method_0().Font);
			interface42_0.imethod_25(string_, class838_0.method_0().Font, new SolidBrush(class838_0.method_0().FontColor), rectangleF_2);
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
				num7 = (float)(class838_0.method_0().rectangle_0.X + int_0) + num4 / 2f;
				num8 += sizeF2.Height;
				num8 += num5;
			}
		}
	}

	internal static void smethod_9(Interface42 interface42_0, RectangleF rectangleF_0, Class844 class844_0, int int_1)
	{
		_ = class844_0.Type;
		Class831 @class = class844_0.method_9().method_1(int_1);
		if (@class == null)
		{
			@class = class844_0.method_0();
		}
		if (class844_0.method_35())
		{
			float num = class844_0.Chart.method_6().method_7();
			RectangleF rect = new RectangleF(rectangleF_0.X, rectangleF_0.Y + (rectangleF_0.Height - num) / 2f, num, num);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(rect);
			@class.method_3().method_9(graphicsPath);
			@class.method_4().method_11(graphicsPath);
			return;
		}
		if (!class844_0.method_26())
		{
			float width = rectangleF_0.Width;
			float width2 = rectangleF_0.Width;
			RectangleF rectangleF_ = new RectangleF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f - width2 / 2f, width, width2);
			@class.method_3().method_8(rectangleF_);
			@class.method_4().method_10(rectangleF_);
			return;
		}
		if (class844_0.method_5().IsVisible)
		{
			@class.method_4().method_7(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f, rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f);
		}
		if (!@class.method_5().IsVisible)
		{
			return;
		}
		float num2 = rectangleF_0.X + rectangleF_0.Width / 2f;
		float float_ = rectangleF_0.Y + rectangleF_0.Height / 2f;
		float float_2;
		if (class844_0.method_7().MarkerSize == 0)
		{
			float_2 = rectangleF_0.Height * float_0;
		}
		else if ((float)class844_0.method_7().MarkerSize <= rectangleF_0.Height * float_0)
		{
			float_2 = class844_0.method_7().MarkerSize;
		}
		else
		{
			float num3 = class844_0.method_7().MarkerSize / class844_0.Chart.method_3().Height;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			float_2 = rectangleF_0.Height * float_0 * (1f + num3);
		}
		@class.method_5().method_7(num2, float_, float_2);
	}

	internal static SizeF smethod_10(Interface42 interface42_0, Class838 class838_0, Class844 class844_0)
	{
		Class830 @class = class844_0.method_9();
		SizeF result = new SizeF(0f, 0f);
		Class821 chart = class838_0.method_0().Chart;
		ArrayList arrayList = ((class844_0.method_20() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < @class.Count; i++)
			{
				SizeF sizeF;
				if (arrayList.Count >= @class.Count)
				{
					Class825 interface11_ = (Class825)arrayList[i];
					string string_ = smethod_11(chart, interface11_, chart.vmethod_0());
					sizeF = interface42_0.imethod_39(string_, class838_0.method_0().Font);
				}
				else
				{
					sizeF = interface42_0.imethod_39(" ", class838_0.method_0().Font);
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
				SizeF sizeF = interface42_0.imethod_39(j.ToString(), class838_0.method_0().Font);
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
			return new SizeF(0f, class838_0.method_0().method_15());
		}
		return result;
	}

	private static string smethod_11(Class821 class821_0, Interface11 interface11_0, bool bool_0)
	{
		string text = smethod_12(class821_0, interface11_0, bool_0);
		while (interface11_0.imethod_10() != null)
		{
			interface11_0 = interface11_0.imethod_10();
			text = smethod_12(class821_0, interface11_0, bool_0) + " " + text;
		}
		return text;
	}

	private static string smethod_12(Class821 class821_0, Interface11 interface11_0, bool bool_0)
	{
		string string_ = interface11_0.imethod_3();
		if (interface11_0.imethod_5())
		{
			double double_ = Convert.ToDouble(interface11_0.imethod_0());
			DateTime dateTimeFromDouble = Struct63.GetDateTimeFromDouble(double_, bool_0);
			return Struct65.smethod_0(class821_0.vmethod_2(), dateTimeFromDouble, string_);
		}
		return Struct65.smethod_0(class821_0.vmethod_2(), interface11_0.imethod_0(), string_);
	}

	internal static SizeF smethod_13(Interface42 interface42_0, Class838 class838_0, Class844 class844_0)
	{
		Class821 chart = class838_0.method_0().Chart;
		Class830 @class = class844_0.method_9();
		SizeF result = new SizeF(0f, 0f);
		ArrayList arrayList = ((class844_0.method_20() != Enum53.const_0) ? chart.method_7().method_2() : chart.method_7().method_0());
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				SizeF sizeF;
				if (arrayList.Count >= @class.Count)
				{
					Class825 interface11_ = (Class825)arrayList[i];
					string string_ = smethod_11(chart, interface11_, chart.vmethod_0());
					sizeF = interface42_0.imethod_39(string_, class838_0.method_0().Font);
				}
				else
				{
					sizeF = interface42_0.imethod_39(" ", class838_0.method_0().Font);
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
				SizeF sizeF = interface42_0.imethod_39(j.ToString(), class838_0.method_0().Font);
				result.Width += sizeF.Width;
				if (result.Height < sizeF.Height)
				{
					result.Height = sizeF.Height;
				}
			}
		}
		return result;
	}

	internal static Size smethod_14(Interface42 interface42_0, Class838 class838_0, Class844 class844_0)
	{
		if (!class838_0.method_0().imethod_3())
		{
			return class838_0.method_0().method_4();
		}
		Class830 @class = class844_0.method_9();
		int num;
		int num2;
		if (class838_0.vmethod_0() != Enum76.const_5 && class838_0.vmethod_0() != 0)
		{
			SizeF sizeF = smethod_2(interface42_0, class838_0);
			SizeF sizeF2 = smethod_10(interface42_0, class838_0, class844_0);
			num = (int)((float)int_0 + sizeF.Width + sizeF2.Width) + 1;
			num2 = (int)(sizeF2.Height + (float)(2 * int_0) + (float)(@class.Count - 1) * sizeF2.Height);
			if (num > class838_0.method_0().Chart.Width)
			{
				num = class838_0.method_0().Chart.Width;
			}
			if (num2 > class838_0.method_0().Chart.method_3().Height - 2 * Struct47.int_0)
			{
				num2 = class838_0.method_0().Chart.method_3().Height - 2 * Struct47.int_0;
			}
		}
		else
		{
			SizeF sizeF3 = smethod_2(interface42_0, class838_0);
			SizeF sizeF4 = smethod_10(interface42_0, class838_0, class844_0);
			int num3 = (int)(sizeF3.Width + sizeF4.Width) + 1;
			int num4 = class838_0.method_0().Chart.method_3().Width - 2 * Struct47.int_0 - int_0;
			int num5 = num4 / num3;
			if (num5 == 0)
			{
				num5 = 1;
			}
			SizeF sizeF2 = smethod_13(interface42_0, class838_0, class844_0);
			int num6 = (int)(sizeF3.Width * (float)class844_0.method_9().Count + sizeF2.Width) + 1;
			if (num6 <= num4)
			{
				num = int_0 + num6;
				num2 = (int)sizeF2.Height + 2 * int_0;
			}
			else
			{
				int num7 = Struct63.smethod_3((double)class844_0.method_9().Count / (double)num5);
				int num8 = Struct63.smethod_3((double)class844_0.method_9().Count / (double)num7);
				num = int_0 + num8 * num3;
				num2 = num7 * (int)sizeF2.Height + 2 * int_0;
			}
			if (num2 > class838_0.method_0().Chart.method_3().Height - 2 * Struct47.int_0)
			{
				num2 = class838_0.method_0().Chart.method_3().Height - 2 * Struct47.int_0;
			}
		}
		return new Size(num, num2);
	}

	internal static Point smethod_15(Interface42 interface42_0, Class838 class838_0, Class844 class844_0, ref Rectangle rectangle_0)
	{
		Class821 chart = class838_0.method_0().Chart;
		float num = 0f;
		float num2 = 0f;
		Size size = smethod_14(interface42_0, class838_0, class844_0);
		int num3 = Struct47.int_0;
		int int_ = Struct47.int_1;
		class838_0.method_0().rectangle_1.Size = size;
		switch (class838_0.vmethod_0())
		{
		case Enum76.const_0:
			num = (chart.Width - size.Width) / 2;
			num2 = chart.Position.Bottom - num3 - size.Height;
			rectangle_0.Height -= size.Height + int_;
			break;
		case Enum76.const_1:
			num = chart.Position.Right - num3 - size.Width;
			num2 = ((!class838_0.method_0().Chart.method_12().IsVisible) ? ((float)(chart.Position.Y + num3)) : ((float)(chart.Position.Y + num3 + class838_0.method_0().Chart.method_12().method_0().rectangle_1.Height + int_)));
			rectangle_0.Width -= size.Width + int_;
			break;
		case Enum76.const_2:
			num = chart.Position.X + num3;
			num2 = (chart.Height - size.Height) / 2;
			rectangle_0.X += size.Width + int_;
			rectangle_0.Width -= size.Width + int_;
			break;
		case Enum76.const_3:
			num = class838_0.method_0().X * chart.Position.Width / 4000;
			num2 = class838_0.method_0().Y * chart.Position.Height / 4000;
			class838_0.method_0().rectangle_1.X = (int)num;
			class838_0.method_0().rectangle_1.Y = (int)num2;
			class838_0.method_0().rectangle_1.Size = size;
			return new Point(class838_0.method_0().rectangle_1.X, class838_0.method_0().rectangle_1.Y);
		case Enum76.const_4:
			num = chart.Position.Right - num3 - size.Width;
			num2 = (chart.Height - size.Height) / 2;
			rectangle_0.Width -= size.Width + int_;
			break;
		case Enum76.const_5:
			num = (chart.Width - size.Width) / 2;
			num2 = chart.Position.Y + num3 + class838_0.method_0().Chart.method_12().method_0().rectangle_1.Height + int_;
			rectangle_0.Y += size.Height + int_;
			rectangle_0.Height -= size.Height + int_;
			break;
		}
		class838_0.method_0().rectangle_1.X = (int)num;
		class838_0.method_0().rectangle_1.Y = (int)num2;
		class838_0.method_0().rectangle_1.Size = size;
		return new Point(class838_0.method_0().rectangle_1.X, class838_0.method_0().rectangle_1.Y);
	}

	internal static Point smethod_16(Interface42 interface42_0, Class838 class838_0, ref Rectangle rectangle_0)
	{
		float num = 0f;
		float num2 = 0f;
		Size size = smethod_17(interface42_0, class838_0);
		int height = class838_0.method_0().Chart.Height;
		int width = class838_0.method_0().Chart.Width;
		int num3 = Struct47.int_0;
		int int_ = Struct47.int_1;
		switch (class838_0.vmethod_0())
		{
		case Enum76.const_0:
			num = (width - size.Width) / 2;
			num2 = height - num3 - size.Height;
			rectangle_0.Height -= size.Height + int_;
			break;
		case Enum76.const_1:
			num = width - num3 - size.Width;
			num2 = ((!class838_0.method_0().Chart.method_12().IsVisible) ? ((float)num3) : ((float)(num3 + class838_0.method_0().Chart.method_12().method_0().rectangle_1.Height + int_)));
			rectangle_0.Width -= size.Width + int_;
			if (rectangle_0.Height > size.Height * 3)
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
			num = class838_0.method_0().method_7();
			num2 = class838_0.method_0().method_8();
			class838_0.method_0().rectangle_1.X = (int)num;
			class838_0.method_0().rectangle_1.Y = (int)num2;
			class838_0.method_0().rectangle_1.Size = size;
			return new Point(class838_0.method_0().rectangle_1.X, class838_0.method_0().rectangle_1.Y);
		case Enum76.const_4:
			num = width - num3 - size.Width;
			num2 = (height - size.Height) / 2;
			rectangle_0.Width -= size.Width + int_;
			break;
		case Enum76.const_5:
			num = (width - size.Width) / 2;
			num2 = num3 + class838_0.method_0().Chart.method_12().method_0().rectangle_1.Height + int_;
			rectangle_0.Y += size.Height + int_;
			rectangle_0.Height -= size.Height + int_;
			break;
		}
		class838_0.method_0().rectangle_1.X = (int)num;
		class838_0.method_0().rectangle_1.Y = (int)num2;
		class838_0.method_0().rectangle_1.Size = size;
		return new Point(class838_0.method_0().rectangle_1.X, class838_0.method_0().rectangle_1.Y);
	}

	internal static Size smethod_17(Interface42 interface42_0, Class838 class838_0)
	{
		SizeF sizeF = smethod_19(interface42_0, class838_0);
		Class821 chart = class838_0.method_0().Chart;
		Class829 @class = class838_0.method_0();
		if (!@class.imethod_3())
		{
			Size result = @class.method_4();
			SizeF sizeF2 = smethod_20(interface42_0, class838_0, new SizeF(chart.Width, chart.Height));
			Struct63.smethod_3(sizeF.Width + sizeF2.Width);
			switch (class838_0.vmethod_0())
			{
			case Enum76.const_3:
				class838_0.method_4(class838_0.vmethod_1());
				break;
			case Enum76.const_1:
			case Enum76.const_2:
			case Enum76.const_4:
				class838_0.method_4(bool_4: true);
				break;
			case Enum76.const_0:
			case Enum76.const_5:
				class838_0.method_4(bool_4: false);
				break;
			}
			return result;
		}
		int num = class838_0.method_5();
		int num2 = class838_0.method_6();
		class838_0.method_0().Chart.method_7();
		int num3 = class838_0.method_1().method_0();
		int num6;
		int num7;
		if (class838_0.vmethod_0() != Enum76.const_5 && class838_0.vmethod_0() != 0 && (class838_0.vmethod_0() != Enum76.const_3 || class838_0.vmethod_1()))
		{
			class838_0.method_4(bool_4: true);
			int num4 = chart.method_3().Height - 2 * Struct47.int_0;
			int num5 = chart.Width / 3;
			SizeF sizeF_ = new SizeF(num5, num4);
			SizeF sizeF3 = smethod_20(interface42_0, class838_0, sizeF_);
			num6 = Struct63.smethod_3((float)num + sizeF.Width + sizeF3.Width);
			num7 = Struct63.smethod_3((float)(2 * num) + (float)num3 * (sizeF3.Height + (float)num2));
			if (num6 > num5)
			{
				num6 = num5;
			}
			if (num7 > num4)
			{
				num7 = num4;
			}
		}
		else
		{
			SizeF sizeF_ = new SizeF(class838_0.method_0().Chart.Width - 2 * Struct47.int_0, class838_0.method_0().Chart.method_3().Height / 2 - Struct47.int_0);
			SizeF sizeF3 = smethod_20(interface42_0, class838_0, sizeF_);
			int num8 = Struct63.smethod_3(sizeF.Width + sizeF3.Width);
			int num9 = Struct63.smethod_5(sizeF_.Width) - num;
			int num10 = num9 / num8;
			if (num10 == 0)
			{
				num10 = 1;
			}
			SizeF sizeF4 = smethod_18(interface42_0, class838_0, sizeF_);
			int num11 = Struct63.smethod_3(sizeF.Width * (float)num3 + sizeF4.Width);
			if (num11 <= num9)
			{
				class838_0.method_4(bool_4: false);
				num6 = num + num11 + num2;
				num7 = Struct63.smethod_3(sizeF4.Height + (float)(2 * num));
			}
			else
			{
				class838_0.method_4(bool_4: false);
				num6 = num + num10 * num8 + num2;
				num7 = Struct63.smethod_3((float)num3 / (float)num10) * (Struct63.smethod_3(sizeF3.Height) + num2) + 2 * num;
				int num12 = chart.method_3().Height / 2 - Struct47.int_0;
				if (num7 > num12)
				{
					int num13 = 0;
					int num14 = 0;
					while (num13 <= num12 && num14 <= num3)
					{
						num13 = Struct63.smethod_3((float)num14 / (float)num10) * (Struct63.smethod_3(sizeF3.Height) + num2) + 2 * num;
						num14 += num10;
					}
					if (num14 < num3 && num13 != num12)
					{
						if (num13 > num12)
						{
							num7 = num13 - (Struct63.smethod_3(sizeF3.Height) + num2);
						}
					}
					else
					{
						num7 = num13;
					}
				}
			}
			if (num7 > chart.method_3().Height - 2 * Struct47.int_0)
			{
				num7 = chart.method_3().Height - 2 * Struct47.int_0;
			}
		}
		return new Size(num6, num7);
	}

	internal static SizeF smethod_18(Interface42 interface42_0, Class838 class838_0, SizeF sizeF_0)
	{
		_ = class838_0.method_0().Chart;
		Class836 @class = class838_0.method_1();
		SizeF result = new SizeF(0f, 0f);
		int num = class838_0.method_6();
		for (int i = 0; i < @class.Count; i++)
		{
			string name = @class[i].Name;
			if (!@class[i].IsDeleted)
			{
				SizeF sizeF = Struct61.smethod_12(interface42_0, name, class838_0.method_0().Font, sizeF_0);
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

	internal static SizeF smethod_19(Interface42 interface42_0, Class838 class838_0)
	{
		if (class838_0.method_1().method_5())
		{
			return class838_0.method_9();
		}
		return new SizeF(class838_0.method_7(), class838_0.method_0().method_15());
	}

	internal static SizeF smethod_20(Interface42 interface42_0, Class838 class838_0, SizeF sizeF_0)
	{
		sizeF_0 = new SizeF(sizeF_0.Width, sizeF_0.Height);
		Class836 @class = class838_0.method_1();
		SizeF result = new SizeF(0f, 0f);
		int num = class838_0.method_6();
		for (int i = 0; i < @class.Count; i++)
		{
			Class837 class2 = @class[i];
			if (!class2.IsDeleted)
			{
				SizeF sizeF = Struct61.smethod_12(interface42_0, class2.Name, class838_0.method_0().Font, sizeF_0);
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

	internal static void smethod_21(Interface42 interface42_0, Class838 class838_0, bool bool_0, Class844 class844_0)
	{
		class838_0.method_0().method_9();
		ArrayList arrayList = class838_0.method_1().method_2(class838_0.method_3(), bool_0);
		int count = arrayList.Count;
		Class821 chart = class838_0.method_0().Chart;
		class838_0.method_0().method_19();
		float height = (float)chart.Height / 3f;
		SizeF sizeF = smethod_19(interface42_0, class838_0);
		int num = class838_0.method_5();
		int num2 = class838_0.method_6();
		float num3 = class838_0.method_10();
		float num4 = class838_0.method_11();
		int num5 = 1;
		int width = class838_0.method_0().rectangle_0.Width;
		int height2 = class838_0.method_0().rectangle_0.Height;
		float num6 = 0f;
		float num7 = 0f;
		SizeF sizeF2 = SizeF.Empty;
		int num8 = 0;
		SizeF sizeF_ = SizeF.Empty;
		SizeF sizeF3 = smethod_18(interface42_0, class838_0, new SizeF(chart.Width, chart.Height));
		int num9 = (int)(sizeF.Width * (float)count + sizeF3.Width);
		bool flag = false;
		int num10;
		if (num9 <= width - num)
		{
			num10 = count;
			int num11 = 1;
			num6 = (float)(width - num - num9) / (float)num10;
			num7 = ((float)height2 - class838_0.method_0().method_15() * 1f) / 1f;
			flag = true;
		}
		else
		{
			int num12 = class838_0.method_0().rectangle_0.Width - num;
			int num13 = num12 - (int)sizeF.Width;
			sizeF_ = new SizeF(num13, height);
			sizeF2 = smethod_20(interface42_0, class838_0, sizeF_);
			num8 = (int)(sizeF.Width + sizeF2.Width);
			num10 = Struct63.smethod_4((float)num12 / (float)num8);
			if (num10 < 1)
			{
				num10 = 1;
			}
			int num11 = Struct63.smethod_3((float)count / (float)num10);
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
			num5 = Struct63.smethod_3(sizeF2.Height / class838_0.method_0().method_15());
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
		float num15 = class838_0.method_0().rectangle_0.X;
		float num16 = class838_0.method_0().rectangle_0.Y;
		num15 += (float)num;
		num15 += num6 / 2f;
		num16 += num7 / 2f;
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_47(class838_0.method_0().rectangle_0);
		StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class837 @class = (Class837)arrayList[i];
			if (num16 > (float)class838_0.method_0().rectangle_0.Bottom)
			{
				break;
			}
			RectangleF rectangleF_ = new RectangleF(num15, num16, sizeF.Width, sizeF.Height);
			smethod_22(interface42_0, class838_0, rectangleF_, @class);
			string name = @class.Name;
			PointF pointF = new PointF(num15 + sizeF.Width + (float)num2, num16);
			if (flag)
			{
				interface42_0.imethod_30(name, @class.Font, new SolidBrush(@class.FontColor), pointF.X, pointF.Y, stringFormat_);
				Size size = class838_0.method_0().rectangle_0.Size;
				if ((float)size.Height < class838_0.method_0().method_15())
				{
					size.Height = Struct63.smethod_5(class838_0.method_0().method_15() + 1f);
				}
				SizeF sizeF4 = Struct61.smethod_11(interface42_0, name, @class.Font, size);
				num15 += sizeF.Width + sizeF4.Width + (float)(2 * num2);
				num15 += num6;
				continue;
			}
			float width2 = Struct63.smethod_3(sizeF_.Width);
			float height3 = Struct63.smethod_3(sizeF_.Height);
			interface42_0.imethod_27(rectangleF_0: new RectangleF(pointF.X, pointF.Y, width2, height3), string_0: name, font_0: @class.Font, brush_0: new SolidBrush(@class.FontColor), stringFormat_0: stringFormat_);
			num15 += (float)num8;
			num15 += num6;
			if ((i + 1) % num10 == 0)
			{
				num15 = (float)(class838_0.method_0().rectangle_0.X + num) + num6 / 2f;
				num16 += sizeF2.Height;
				num16 += num7;
			}
		}
		interface42_0.imethod_44(graphicsState_);
	}

	internal static void smethod_22(Interface42 interface42_0, Class838 class838_0, RectangleF rectangleF_0, Class837 class837_0)
	{
		int num = smethod_23(class838_0);
		if (class837_0.Type == Enum56.const_1)
		{
			PointF pointF_ = new PointF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f);
			PointF pointF_2 = new PointF(rectangleF_0.Right, rectangleF_0.Y + rectangleF_0.Height / 2f);
			Class840 @class = (Class840)class837_0.method_2().method_1().Clone();
			if (@class.Width > num)
			{
				@class.method_0().Width = num;
			}
			@class.method_8(pointF_, pointF_2);
		}
		else
		{
			if (class837_0.Type != Enum56.const_0)
			{
				return;
			}
			Class844 class2 = class837_0.method_0();
			Class840 class3 = (Class840)class2.method_5().Clone();
			if (class3.Width > num)
			{
				class3.method_0().Width = num;
			}
			if (class2.method_35())
			{
				float num2 = class838_0.method_7();
				RectangleF rect = new RectangleF(rectangleF_0.X, rectangleF_0.Y + (rectangleF_0.Height - num2) / 2f, num2, num2);
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(rect);
				class2.method_6().method_9(graphicsPath);
				class3.method_11(graphicsPath);
			}
			else if (class2.method_26())
			{
				if (class3.IsVisible)
				{
					class3.method_7(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f, rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f);
				}
				if (class2.method_7().MarkerStyle != Enum65.const_5)
				{
					float num3 = rectangleF_0.X + rectangleF_0.Width / 2f;
					float float_ = rectangleF_0.Y + rectangleF_0.Height / 2f;
					float float_2 = ((class2.method_7().MarkerSize == 0) ? (rectangleF_0.Height * Class827.float_0) : ((!((float)class2.method_7().MarkerSize <= rectangleF_0.Height * Class827.float_0)) ? (rectangleF_0.Height * Class827.float_0) : ((float)class2.method_7().MarkerSize)));
					class2.method_7().method_7(num3, float_, float_2);
				}
			}
			else
			{
				float width = rectangleF_0.Width;
				float num4 = class838_0.method_7();
				RectangleF rectangleF_ = new RectangleF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f - num4 / 2f, width, num4);
				class2.method_6().method_8(rectangleF_);
				class3.method_10(rectangleF_);
			}
		}
	}

	private static int smethod_23(Class838 class838_0)
	{
		if (class838_0.method_0().method_15() <= 8f)
		{
			return 1;
		}
		int num = Struct63.smethod_5(class838_0.method_0().Font.Size) - 8;
		int num2 = Struct63.smethod_3((double)num / 5.0) * 2;
		switch (num % 5)
		{
		default:
			return num2 + 1;
		case 1:
		case 2:
			return num2;
		}
	}
}
