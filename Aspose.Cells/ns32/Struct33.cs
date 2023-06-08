using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct33
{
	internal static void smethod_0(Class787 class787_0, ref Rectangle rectangle_0)
	{
		if (rectangle_0.Width > 0 && rectangle_0.Height > 0 && (class787_0.Type == ChartType_Chart.Pie3D || class787_0.Type == ChartType_Chart.Pie3DExploded))
		{
			int num = class787_0.Width;
			if (class787_0.Height < num)
			{
				num = class787_0.Height;
			}
			int num2 = 6;
			num2 = 6 + Struct40.smethod_3((float)(num - 70) * 14f / 230f);
			if (class787_0.method_8().imethod_3())
			{
				rectangle_0.X += num2;
				rectangle_0.Y += num2;
				rectangle_0.Width -= 2 * num2;
				rectangle_0.Height -= 2 * num2;
			}
			smethod_1(ref rectangle_0, class787_0, num2);
		}
	}

	internal static void smethod_1(ref Rectangle rectangle_0, Class787 class787_0, int int_0)
	{
		double num = 1.0 / 7.0 / Math.Cos(Math.PI / 18.0);
		double num2 = (double)class787_0.Elevation * Math.PI / 180.0;
		double num3 = (double)rectangle_0.Width * (Math.Sin(num2) + num * (double)class787_0.HeightPercent / 100.0 * Math.Cos(num2));
		double num4 = (double)rectangle_0.Height / (Math.Sin(num2) + num * (double)class787_0.HeightPercent / 100.0 * Math.Cos(num2));
		if (num3 <= (double)rectangle_0.Height)
		{
			rectangle_0.X += int_0;
			rectangle_0.Y += int_0;
			rectangle_0.Width -= 2 * int_0;
			rectangle_0.Height -= 2 * int_0;
			num3 = (double)rectangle_0.Width * (Math.Sin(num2) + num * (double)class787_0.HeightPercent / 100.0 * Math.Cos(num2));
			rectangle_0.Y = Struct40.smethod_5((double)((float)rectangle_0.Y + (float)rectangle_0.Height / 2f) - num3 / 2.0);
			rectangle_0.Height = Struct40.smethod_5(num3);
		}
		else
		{
			rectangle_0.X = Struct40.smethod_5((double)((float)rectangle_0.X + (float)rectangle_0.Width / 2f) - num4 / 2.0);
			rectangle_0.Width = Struct40.smethod_5(num4);
		}
		double num5 = (double)rectangle_0.Width * num * (double)class787_0.HeightPercent / 100.0 * Math.Cos(num2);
		double num6 = num5 / (double)rectangle_0.Height;
		class787_0.method_26((float)num6);
	}

	internal static void smethod_2(Interface42 interface42_0, Class787 class787_0)
	{
		Class810 @class = (Class810)class787_0.method_7().method_16()[0];
		Class795 class2 = @class.method_10();
		Color[] array = new Color[class2.Count];
		for (int i = 0; i < class2.Count; i++)
		{
			Class796 class3 = class2.method_1(i);
			if (@class.IsColorVaried)
			{
				class3.method_3().method_1(class787_0.method_14(@class.vmethod_7()).GetColor(i));
			}
			else
			{
				class3.method_3().method_1(@class.method_7().ForegroundColor);
			}
			ref Color reference = ref array[i];
			reference = class3.method_3().ForegroundColor;
		}
		double[] array2 = new double[class2.Count];
		for (int j = 0; j < class2.Count; j++)
		{
			Class796 class4 = class2.method_1(j);
			array2[j] = class4.YValue;
		}
		string[] array3 = new string[class2.Count];
		double num = 0.0;
		for (int k = 0; k < class2.Count; k++)
		{
			num += Math.Abs(class2[k].YValue);
		}
		for (int l = 0; l < class2.Count; l++)
		{
			Class796 class5 = class2.method_1(l);
			double yValue = class5.YValue;
			double double_ = yValue / num;
			array3[l] = smethod_3(@class, l, double_);
		}
		Rectangle rectangle_ = class787_0.method_8().rectangle_1;
		if (class787_0.Type == ChartType_Chart.Pie3DExploded)
		{
			rectangle_.Y += 5;
			rectangle_.Height -= 10;
		}
		rectangle_ = smethod_4(interface42_0, @class, rectangle_, array2, array, array3);
		class787_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		Struct24.smethod_0(interface42_0, class787_0.method_8());
		Class818 class6 = new Class818(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height, array2, array, class787_0.method_25(), array3, class2);
		class6.method_4(@class);
		class6.Draw(interface42_0);
		class6.vmethod_0(interface42_0);
	}

	private static string smethod_3(Class810 class810_0, int int_0, double double_0)
	{
		Class787 chart = class810_0.Chart;
		Class796 @class = class810_0.method_10().method_1(int_0);
		ArrayList arrayList = chart.method_7().method_0();
		Class789 class2 = chart.method_1();
		Class798 class3 = @class.method_6();
		bool bool_ = class3.vmethod_1();
		bool linkedSource = class3.LinkedSource;
		string string_ = (class3.IsPercentageShown ? "" : class3.imethod_2());
		string string_2 = ((class3.imethod_2() == "") ? "0%" : class3.imethod_2());
		string name = class810_0.Name;
		string text = ((int_0 < class2.arrayList_1.Count) ? Struct26.smethod_6(chart.vmethod_2(), class2.arrayList_1[int_0], string_, bool_) : "");
		if (linkedSource)
		{
			string string_3 = ((int_0 < 0 || int_0 >= arrayList.Count) ? "" : ((Class791)arrayList[int_0]).imethod_3());
			bool bool_2 = int_0 >= 0 && int_0 < arrayList.Count && ((Class791)arrayList[int_0]).imethod_1();
			text = ((int_0 < 0 || int_0 >= class2.arrayList_1.Count) ? "" : Struct26.smethod_6(chart.vmethod_2(), class2.arrayList_1[int_0], string_3, bool_2));
		}
		string text2 = Struct26.smethod_6(chart.vmethod_2(), @class.YValue, string_, bool_);
		if (linkedSource)
		{
			text2 = Struct26.smethod_6(chart.vmethod_2(), @class.YValue, @class.vmethod_6(), @class.vmethod_7());
		}
		string text3 = Struct26.smethod_6(chart.vmethod_2(), double_0, string_2, bool_);
		string text4 = Struct26.smethod_4(class3.Separator);
		_ = class3.method_0().Font;
		_ = class3.Rotation;
		_ = class3.TextHorizontalAlignment;
		_ = class3.TextVerticalAlignment;
		string text5 = "";
		if (class3.IsSeriesNameShown)
		{
			text5 += name;
		}
		if (class3.IsCategoryNameShown)
		{
			if (text5 != "")
			{
				text5 += text4;
			}
			text5 += text;
		}
		if (class3.IsValueShown)
		{
			if (text5 != "")
			{
				text5 += text4;
			}
			text5 += text2;
		}
		if (class3.IsPercentageShown)
		{
			if (text5 != "")
			{
				text5 += text4;
			}
			text5 += text3;
		}
		return text5;
	}

	internal static Rectangle smethod_4(Interface42 interface42_0, Class810 class810_0, Rectangle rectangle_0, double[] double_0, Color[] color_0, string[] string_0)
	{
		Class787 chart = class810_0.Chart;
		Class795 class795_ = class810_0.method_10();
		Class818 @class = new Class818(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height, double_0, color_0, chart.method_25(), string_0, class795_);
		@class.method_4(class810_0);
		Rectangle rectangle = default(Rectangle);
		rectangle = rectangle_0;
		smethod_5(interface42_0, @class);
		if (class810_0.Chart.method_8().imethod_0())
		{
			SizeF sizeF = smethod_7(rectangle_0, class810_0);
			if (sizeF.Width > (float)rectangle_0.Width * 0.3f)
			{
				sizeF.Width = (float)rectangle_0.Width * 0.3f;
			}
			if (sizeF.Height > (float)rectangle_0.Height * 0.3f)
			{
				sizeF.Height = (float)rectangle_0.Height * 0.3f;
			}
			rectangle.X = rectangle_0.X + (int)sizeF.Width;
			rectangle.Width = rectangle_0.Width - 2 * (int)sizeF.Width;
			rectangle.Y = rectangle_0.Y + (int)sizeF.Height;
			rectangle.Height = rectangle_0.Height - 2 * (int)sizeF.Height;
			smethod_1(ref rectangle, chart, 0);
		}
		return rectangle;
	}

	private static ArrayList smethod_5(Interface42 interface42_0, Class818 class818_0)
	{
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = StringAlignment.Center;
		stringFormat.LineAlignment = StringAlignment.Center;
		Class787 chart = class818_0.method_0().Chart;
		double num = 0.0;
		double[] values = class818_0.Values;
		foreach (double num2 in values)
		{
			num += num2;
		}
		ArrayList arrayList = new ArrayList();
		Class819[] array = class818_0.method_3();
		foreach (Class819 @class in array)
		{
			if (@class == null || @class.Text.Length < 1)
			{
				continue;
			}
			Class796 class2 = @class.method_14();
			Class810 class3 = class2.method_1().method_0();
			Class798 class4 = class2.method_6();
			double double_ = ((num != 0.0) ? (Math.Abs(class2.YValue) / num) : 0.01);
			float float_ = (chart.method_8().imethod_0() ? ((!class4.method_0().method_2().IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f)) : ((!class4.method_0().method_2().IsVisible) ? ((float)chart.Width * 0.2f) : ((float)chart.Width * 0.175f)));
			float float_2 = chart.Height;
			SizeF size = Struct35.smethod_38(interface42_0, chart.method_7(), class3.Index, class2.Index, double_, float_, float_2, 0.0);
			RectangleF empty = RectangleF.Empty;
			PointF location;
			float dlAngle;
			switch (class4.vmethod_0())
			{
			case Enum74.const_1:
				location = @class.vmethod_0(0.25f, out dlAngle);
				location.X -= size.Width / 2f;
				location.Y -= size.Height / 2f;
				break;
			default:
				location = @class.vmethod_0(0.5f, out dlAngle);
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
					location.Y += @class.method_4();
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
			case Enum74.const_3:
			{
				location = @class.vmethod_0(0.5f, out dlAngle);
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
			class4.rectangleF_1 = new RectangleF(empty.X, empty.Y, empty.Width, empty.Height);
			arrayList.Add(empty);
		}
		return arrayList;
	}

	private static SizeF smethod_6(RectangleF rectangleF_0, Class810 class810_0)
	{
		SizeF sizeF_ = new SizeF(0f, 0f);
		for (int i = 0; i < class810_0.method_10().Count; i++)
		{
			Class796 @class = class810_0.method_10().method_1(i);
			Class798 class2 = @class.method_6();
			if (class2.vmethod_0() == Enum74.const_0 || class2.vmethod_0() == Enum74.const_4 || class2.vmethod_0() == Enum74.const_9)
			{
				smethod_8(rectangleF_0, class2.rectangleF_1, ref sizeF_);
			}
		}
		return sizeF_;
	}

	private static SizeF smethod_7(Rectangle rectangle_0, Class810 class810_0)
	{
		RectangleF rectangleF_ = new RectangleF(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		return smethod_6(rectangleF_, class810_0);
	}

	private static void smethod_8(RectangleF rectangleF_0, RectangleF rectangleF_1, ref SizeF sizeF_0)
	{
		if (rectangleF_1.IsEmpty)
		{
			return;
		}
		if (rectangleF_1.Left < rectangleF_0.Left)
		{
			float num = rectangleF_0.Left - rectangleF_1.Left;
			if (num > sizeF_0.Width)
			{
				sizeF_0.Width = num;
			}
		}
		if (rectangleF_1.Right > rectangleF_0.Right)
		{
			float num2 = rectangleF_1.Right - rectangleF_0.Right;
			if (num2 > sizeF_0.Width)
			{
				sizeF_0.Width = num2;
			}
		}
		if (rectangleF_1.Top < rectangleF_0.Top)
		{
			float num3 = rectangleF_0.Top - rectangleF_1.Top;
			if (num3 > sizeF_0.Height)
			{
				sizeF_0.Height = num3;
			}
		}
		if (rectangleF_1.Bottom > rectangleF_0.Bottom)
		{
			float num4 = rectangleF_1.Bottom - rectangleF_0.Bottom;
			if (num4 > sizeF_0.Height)
			{
				sizeF_0.Height = num4;
			}
		}
	}
}
