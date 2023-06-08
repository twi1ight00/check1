using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns14;
using ns19;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct51
{
	internal static int int_0 = 2;

	internal static SizeF smethod_0(Interface42 interface42_0, Class823 class823_0, Class842 class842_0, int int_1, int int_2, int int_3)
	{
		Class844 @class = class842_0.method_9(int_1);
		Class821 chart = @class.Chart;
		Class831 class2 = @class.method_9().method_1(int_2);
		Class832 class3 = class2.method_6();
		if (!class3.method_1())
		{
			return new SizeF(0f, 0f);
		}
		bool flag = false;
		ArrayList arrayList;
		ArrayList arrayList2;
		if (class823_0.method_4() == Enum61.const_0)
		{
			flag = chart.method_7().bool_0;
			arrayList = chart.method_7().method_0();
			arrayList2 = arrayList;
		}
		else
		{
			flag = chart.method_7().bool_1;
			arrayList = chart.method_7().method_2();
			arrayList2 = arrayList;
			if (!chart.method_2().IsVisible && flag)
			{
				arrayList2 = chart.method_7().method_6();
			}
		}
		string string_ = class3.imethod_2();
		bool bool_ = class3.vmethod_1();
		bool linkedSource = class3.LinkedSource;
		string name = @class.Name;
		string text = "";
		if (smethod_10(@class.method_22()))
		{
			object object_ = class2.vmethod_3();
			text = smethod_5(chart.vmethod_2(), object_, string_, bool_);
			if (linkedSource)
			{
				text = smethod_5(chart.vmethod_2(), object_, class2.imethod_10(), class2.imethod_12());
			}
		}
		else if (flag)
		{
			string text2 = ((int_2 < arrayList.Count) ? ((Class825)arrayList2[int_2]).imethod_3() : "");
			bool flag2 = int_2 < arrayList.Count && ((Class825)arrayList2[int_2]).imethod_1();
			if (linkedSource)
			{
				string_ = text2;
				bool_ = flag2;
			}
			if (int_2 < arrayList.Count)
			{
				object object_2 = ((Class825)arrayList[int_2]).imethod_0();
				int num = Struct47.smethod_73(object_2, chart.vmethod_0());
				object object_3 = ((Class825)arrayList2[int_2]).imethod_0();
				text = ((num != -1) ? smethod_5(chart.vmethod_2(), object_3, string_, bool_) : "");
			}
			else
			{
				text = "";
			}
		}
		else
		{
			text = ((int_2 >= class823_0.arrayList_1.Count) ? "" : smethod_5(chart.vmethod_2(), class823_0.arrayList_1[int_2], string_, bool_));
		}
		Class823 class4 = Struct44.smethod_36(class823_0);
		double yValue = class2.YValue;
		yValue = (class4.IsLogarithmic ? class4.method_7(yValue) : yValue);
		yValue = (class4.IsLogarithmic ? yValue : (yValue * Math.Pow(10.0, (double)class4.method_12().vmethod_0())));
		string text3 = smethod_5(chart.vmethod_2(), yValue, string_, bool_);
		if (linkedSource)
		{
			text3 = smethod_5(chart.vmethod_2(), yValue, class2.vmethod_6(), class2.vmethod_7());
		}
		string text4 = smethod_5(chart.vmethod_2(), class2.vmethod_8(), string_, bool_);
		if (linkedSource)
		{
			text4 = smethod_5(chart.vmethod_2(), class2.vmethod_8(), class2.vmethod_9(), class2.vmethod_10());
		}
		string text5 = smethod_3(class3.Separator);
		Font font = class3.method_0().Font;
		int rotation = class3.Rotation;
		Enum82 textHorizontalAlignment = class3.TextHorizontalAlignment;
		Enum82 textVerticalAlignment = class3.TextVerticalAlignment;
		SizeF sizeF = new SizeF(0f, 0f);
		if (class3.IsLegendKeyShown)
		{
			sizeF = new SizeF(class3.method_4(), class3.method_6());
		}
		string text6 = "";
		if (class3.Text == null)
		{
			if (class3.IsSeriesNameShown)
			{
				text6 += name;
			}
			if (class3.IsCategoryNameShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text;
			}
			if (class3.IsValueShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text3;
			}
			if (class3.IsBubbleSizeShown)
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
			text6 = class3.Text;
		}
		SizeF sizeF_ = new SizeF(int_3, (float)chart.Position.Height * 0.5f);
		Size size = Struct61.smethod_3(interface42_0, text6, rotation, font, sizeF_, textHorizontalAlignment, textVerticalAlignment);
		if (text6 == "")
		{
			return new SizeF(0f, 0f);
		}
		if (class3.IsLegendKeyShown)
		{
			return new SizeF((float)size.Width + sizeF.Width, size.Height);
		}
		return new SizeF(size.Width, size.Height);
	}

	internal static void smethod_1(Interface42 interface42_0, Class823 class823_0, Class842 class842_0, int int_1, int int_2, Rectangle rectangle_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		smethod_2(interface42_0, class823_0, class842_0, int_1, int_2, rectangleF_);
	}

	internal static void smethod_2(Interface42 interface42_0, Class823 class823_0, Class842 class842_0, int int_1, int int_2, RectangleF rectangleF_0)
	{
		Class844 @class = class842_0.method_9(int_1);
		Class821 chart = @class.Chart;
		Class831 class2 = @class.method_9().method_1(int_2);
		Class832 class3 = class2.method_6();
		if (!class3.method_1())
		{
			return;
		}
		chart.method_29(ref rectangleF_0);
		bool flag = false;
		ArrayList arrayList;
		ArrayList arrayList2;
		if (class823_0.method_4() == Enum61.const_0)
		{
			flag = chart.method_7().bool_0;
			arrayList = chart.method_7().method_0();
			arrayList2 = arrayList;
		}
		else
		{
			flag = chart.method_7().bool_1;
			arrayList = chart.method_7().method_2();
			arrayList2 = arrayList;
			if (!chart.method_2().IsVisible && flag)
			{
				arrayList2 = chart.method_7().method_6();
			}
		}
		string string_ = class3.imethod_2();
		bool bool_ = class3.vmethod_1();
		bool linkedSource = class3.LinkedSource;
		string name = @class.Name;
		string text = "";
		bool flag2 = false;
		if (smethod_10(@class.method_22()))
		{
			object object_ = class2.vmethod_3();
			text = smethod_5(chart.vmethod_2(), object_, string_, bool_);
			if (linkedSource)
			{
				text = smethod_5(chart.vmethod_2(), object_, class2.imethod_10(), class2.imethod_12());
				flag2 = smethod_7(object_, class2.imethod_10());
			}
		}
		else if (flag)
		{
			string text2 = ((int_2 < arrayList.Count) ? ((Class825)arrayList2[int_2]).imethod_3() : "");
			bool flag3 = int_2 < arrayList.Count && ((Class825)arrayList2[int_2]).imethod_1();
			if (linkedSource)
			{
				string_ = text2;
				bool_ = flag3;
			}
			if (int_2 < arrayList.Count)
			{
				object object_2 = ((Class825)arrayList[int_2]).imethod_0();
				int num = Struct47.smethod_73(object_2, chart.vmethod_0());
				object object_3 = ((Class825)arrayList2[int_2]).imethod_0();
				text = ((num != -1) ? smethod_5(chart.vmethod_2(), object_3, string_, bool_) : "");
				if (linkedSource)
				{
					flag2 = smethod_7(object_2, string_);
				}
			}
			else
			{
				text = "";
			}
		}
		else
		{
			text = ((int_2 >= class823_0.arrayList_1.Count) ? "" : smethod_5(chart.vmethod_2(), class823_0.arrayList_1[int_2], string_, bool_));
			if (int_2 < class823_0.arrayList_1.Count && linkedSource)
			{
				flag2 = smethod_7(class823_0.arrayList_1[int_2], string_);
			}
		}
		Class823 class4 = Struct44.smethod_36(class823_0);
		double yValue = class2.YValue;
		yValue = (class4.IsLogarithmic ? class4.method_7(yValue) : yValue);
		yValue = (class4.IsLogarithmic ? yValue : (yValue * Math.Pow(10.0, (double)class4.method_12().vmethod_0())));
		string text3 = smethod_5(chart.vmethod_2(), yValue, string_, bool_);
		bool flag4 = false;
		if (linkedSource)
		{
			text3 = smethod_5(chart.vmethod_2(), yValue, class2.vmethod_6(), class2.vmethod_7());
			flag4 = smethod_7(yValue, class2.vmethod_6());
		}
		string text4 = smethod_5(chart.vmethod_2(), class2.vmethod_8(), string_, bool_);
		if (linkedSource)
		{
			text4 = smethod_5(chart.vmethod_2(), class2.vmethod_8(), class2.vmethod_9(), class2.vmethod_10());
		}
		string text5 = smethod_3(class3.Separator);
		Font font = class3.method_0().Font;
		Color color_ = class3.method_0().FontColor;
		int rotation = class3.Rotation;
		Enum82 textHorizontalAlignment = class3.TextHorizontalAlignment;
		Enum82 textVerticalAlignment = class3.TextVerticalAlignment;
		SizeF sizeF = new SizeF(class3.method_4(), class3.method_6());
		int num2 = (int)rectangleF_0.X;
		int num3 = (int)rectangleF_0.Y;
		int num4 = (int)rectangleF_0.Width;
		int num5 = (int)rectangleF_0.Height;
		int num6 = (class3.IsLegendKeyShown ? (num2 - int_0) : num2);
		int num7 = num3 - int_0;
		int width = (class3.IsLegendKeyShown ? (num4 + 2 * int_0) : num4);
		int height = num5 + 2 * int_0;
		class3.method_0().rectangle_0 = new Rectangle(num6, num7, width, height);
		if (class3.method_0().rectangle_0.Width > 0 && class3.method_0().rectangle_0.Height > 0)
		{
			class3.method_0().method_1().method_7(class3.method_0().rectangle_0);
			class3.method_0().method_2().method_9(class3.method_0().rectangle_0);
		}
		int num8 = class3.method_0().rectangle_0.X - num6;
		int num9 = class3.method_0().rectangle_0.Y - num7;
		num2 += num8;
		num3 += num9;
		if (class3.IsLegendKeyShown)
		{
			RectangleF rectangleF_ = new RectangleF(rectangleF_0.X, rectangleF_0.Y, sizeF.Width, sizeF.Height);
			Struct53.smethod_4(interface42_0, rectangleF_, @class);
			num2 += (int)sizeF.Width;
			num4 -= (int)sizeF.Width;
		}
		string text6 = "";
		if (class3.Text == null)
		{
			if (class3.IsSeriesNameShown)
			{
				text6 += name;
			}
			if (class3.IsCategoryNameShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text;
			}
			if (class3.IsValueShown)
			{
				if (text6 != "")
				{
					text6 += text5;
				}
				text6 += text3;
			}
			if (class3.IsBubbleSizeShown)
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
			text6 = class3.Text;
		}
		Rectangle rectangle_ = new Rectangle(num2, num3, num4, num5);
		if (flag2 || flag4)
		{
			color_ = Color.Red;
		}
		TextRenderingHint textRenderingHint_ = chart.imethod_0().imethod_56();
		if (chart.method_3().method_1().method_2() && class3.method_0().method_1().method_2())
		{
			chart.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
		}
		smethod_12(interface42_0, class3, rectangle_, text6, rotation, font, color_, textHorizontalAlignment, textVerticalAlignment);
		if (chart.method_3().method_1().method_2() && class3.method_0().method_1().method_2())
		{
			chart.imethod_0().imethod_57(textRenderingHint_);
		}
	}

	internal static string smethod_3(Enum75 enum75_0)
	{
		string result = "";
		switch (enum75_0)
		{
		case Enum75.const_1:
			result = " ";
			break;
		case Enum75.const_0:
		case Enum75.const_2:
			result = ", ";
			break;
		case Enum75.const_3:
			result = "; ";
			break;
		case Enum75.const_4:
			result = ". ";
			break;
		case Enum75.const_5:
			result = "\n";
			break;
		}
		return result;
	}

	internal static string smethod_4(Class832 class832_0)
	{
		Enum75 separator = class832_0.Separator;
		string result = "";
		switch (separator)
		{
		case Enum75.const_0:
			result = ((!class832_0.IsCategoryNameShown || !class832_0.IsPercentageShown || class832_0.IsSeriesNameShown || class832_0.IsValueShown) ? ", " : "\n");
			break;
		case Enum75.const_1:
			result = " ";
			break;
		case Enum75.const_2:
			result = ", ";
			break;
		case Enum75.const_3:
			result = "; ";
			break;
		case Enum75.const_4:
			result = ". ";
			break;
		case Enum75.const_5:
			result = "\n";
			break;
		}
		return result;
	}

	internal static string smethod_5(Class516 class516_0, object object_0, string string_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return "";
		}
		if (string_0 == null && object_0 != null)
		{
			return object_0.ToString();
		}
		string text = "";
		TypeCode typeCode = Type.GetTypeCode(object_0.GetType());
		if (smethod_8(string_0) && (typeCode == TypeCode.Double || typeCode == TypeCode.Int32))
		{
			switch (typeCode)
			{
			case TypeCode.Double:
			{
				double double_ = (double)object_0;
				DateTime dateTime = smethod_9(double_);
				return Struct65.smethod_0(class516_0, dateTime, string_0);
			}
			case TypeCode.Int32:
			{
				double double_ = (int)object_0;
				DateTime dateTime = smethod_9(double_);
				return Struct65.smethod_0(class516_0, dateTime, string_0);
			}
			}
		}
		return Struct65.smethod_0(class516_0, object_0, string_0);
	}

	internal static Color smethod_6(object object_0, string string_0, Color color_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			TypeCode typeCode = Type.GetTypeCode(object_0.GetType());
			if ((typeCode == TypeCode.Double || typeCode == TypeCode.Int32) && string_0.ToLower().IndexOf("[red]") > 0)
			{
				if (!((double)object_0 < 0.0))
				{
					return color_0;
				}
				return Color.Red;
			}
			return color_0;
		}
		return color_0;
	}

	internal static bool smethod_7(object object_0, string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			TypeCode typeCode = Type.GetTypeCode(object_0.GetType());
			if ((typeCode == TypeCode.Double || typeCode == TypeCode.Int32) && string_0.ToLower().IndexOf("[red]") > 0 && (double)object_0 < 0.0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool smethod_8(string string_0)
	{
		string[] array = new string[32]
		{
			"MMM", "DD", "YYYY", "M/", "/M", "/D", "D/", "/Y", "Y/", "-M",
			"M-", "-D", "D-", "-Y", "Y-", "MM/DD", "DD/MM", "M/D", "D/M", "MM-DD",
			"DD-MM", "M-D", "D-M", "H:MM", "MM:SS", "年", "月", "日", "时", "分",
			"秒", "MM"
		};
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (string_0.IndexOf(array[num]) != -1 || string_0.ToUpper().IndexOf(array[num]) != -1)
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

	private static DateTime smethod_9(double double_0)
	{
		DateTime dateTime = new DateTime(1899, 12, 30, 0, 0, 1);
		if (double_0 < 0.0)
		{
			return dateTime;
		}
		if (double_0 > 2958465.99)
		{
			return new DateTime(9999, 12, 31, 23, 59, 59);
		}
		if (double_0 < 60.0)
		{
			double_0 += 1.0;
		}
		return dateTime + TimeSpan.FromDays(double_0);
	}

	internal static bool smethod_10(ChartType_Chart chartType_Chart_0)
	{
		if (chartType_Chart_0 != ChartType_Chart.Scatter && chartType_Chart_0 != ChartType_Chart.Bubble)
		{
			return false;
		}
		return true;
	}

	internal static Enum74 smethod_11(ChartType_Chart chartType_Chart_0)
	{
		switch (chartType_Chart_0)
		{
		case ChartType_Chart.Pie:
		case ChartType_Chart.Pie3D:
		case ChartType_Chart.PiePie:
		case ChartType_Chart.PieExploded:
		case ChartType_Chart.Pie3DExploded:
		case ChartType_Chart.PieBar:
			return Enum74.const_4;
		case ChartType_Chart.Area:
		case ChartType_Chart.AreaStacked:
		case ChartType_Chart.Area100PercentStacked:
		case ChartType_Chart.Area3D:
		case ChartType_Chart.Area3DStacked:
		case ChartType_Chart.Area3D100PercentStacked:
		case ChartType_Chart.BarStacked:
		case ChartType_Chart.Bar100PercentStacked:
		case ChartType_Chart.Bar3DStacked:
		case ChartType_Chart.Bar3D100PercentStacked:
		case ChartType_Chart.ColumnStacked:
		case ChartType_Chart.Column100PercentStacked:
		case ChartType_Chart.Column3DStacked:
		case ChartType_Chart.Column3D100PercentStacked:
		case ChartType_Chart.ConeStacked:
		case ChartType_Chart.Cone100PercentStacked:
		case ChartType_Chart.ConicalBarStacked:
		case ChartType_Chart.ConicalBar100PercentStacked:
		case ChartType_Chart.CylinderStacked:
		case ChartType_Chart.Cylinder100PercentStacked:
		case ChartType_Chart.CylindricalBarStacked:
		case ChartType_Chart.CylindricalBar100PercentStacked:
		case ChartType_Chart.Doughnut:
		case ChartType_Chart.DoughnutExploded:
		case ChartType_Chart.PyramidStacked:
		case ChartType_Chart.Pyramid100PercentStacked:
		case ChartType_Chart.PyramidBarStacked:
		case ChartType_Chart.PyramidBar100PercentStacked:
			return Enum74.const_1;
		case ChartType_Chart.Bar:
		case ChartType_Chart.Bar3DClustered:
		case ChartType_Chart.Column:
		case ChartType_Chart.Column3D:
		case ChartType_Chart.Column3DClustered:
		case ChartType_Chart.Cone:
		case ChartType_Chart.ConicalBar:
		case ChartType_Chart.ConicalColumn3D:
		case ChartType_Chart.Cylinder:
		case ChartType_Chart.CylindricalBar:
		case ChartType_Chart.CylindricalColumn3D:
		case ChartType_Chart.Pyramid:
		case ChartType_Chart.PyramidBar:
		case ChartType_Chart.PyramidColumn3D:
			return Enum74.const_4;
		default:
			return Enum74.const_1;
		case ChartType_Chart.Bubble:
		case ChartType_Chart.Bubble3D:
		case ChartType_Chart.Line:
		case ChartType_Chart.LineStacked:
		case ChartType_Chart.Line100PercentStacked:
		case ChartType_Chart.LineWithDataMarkers:
		case ChartType_Chart.LineStackedWithDataMarkers:
		case ChartType_Chart.Line100PercentStackedWithDataMarkers:
		case ChartType_Chart.Line3D:
		case ChartType_Chart.Scatter:
		case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
			return Enum74.const_8;
		}
	}

	public static void smethod_12(Interface42 interface42_0, Class832 class832_0, Rectangle rectangle_0, string string_0, int int_1, Font font_0, Color color_0, Enum82 enum82_0, Enum82 enum82_1)
	{
		bool flag = false;
		TextRenderingHint textRenderingHint_ = interface42_0.imethod_56();
		if (class832_0.method_0().Chart.method_3().method_1().method_2() && class832_0.method_0().method_1().method_2())
		{
			flag = true;
			interface42_0.imethod_57(TextRenderingHint.AntiAlias);
		}
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = Struct61.smethod_13(enum82_0);
		stringFormat.LineAlignment = Struct61.smethod_13(enum82_1);
		switch (Math.Abs(int_1))
		{
		default:
		{
			double num = Math.Sqrt(Math.Pow(rectangle_0.Width, 2.0) + Math.Pow(rectangle_0.Height, 2.0));
			stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			SizeF sizeF = interface42_0.imethod_43(string_0, font_0, (int)num, stringFormat);
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_1);
			interface42_0.imethod_27(rectangleF_0: new RectangleF((0f - sizeF.Width) / 2f, (0f - sizeF.Height) / 2f, sizeF.Width, sizeF.Height), string_0: string_0, font_0: font_0, brush_0: new SolidBrush(color_0), stringFormat_0: stringFormat);
			interface42_0.ResetTransform();
			break;
		}
		case 90:
			interface42_0.imethod_49(rectangle_0.Left + rectangle_0.Width / 2, rectangle_0.Top + rectangle_0.Height / 2);
			interface42_0.imethod_45(-int_1);
			rectangle_0 = new Rectangle(-rectangle_0.Height / 2, -rectangle_0.Width / 2, rectangle_0.Height, rectangle_0.Width);
			interface42_0.imethod_28(string_0, font_0, new SolidBrush(color_0), rectangle_0, stringFormat);
			interface42_0.ResetTransform();
			break;
		case 0:
			interface42_0.imethod_28(string_0, font_0, new SolidBrush(color_0), rectangle_0, stringFormat);
			break;
		}
		if (flag)
		{
			interface42_0.imethod_57(textRenderingHint_);
		}
	}
}
