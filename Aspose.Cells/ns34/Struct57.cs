using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct57
{
	internal static void smethod_0(Class821 class821_0, ref Rectangle rectangle_0, Class844 class844_0)
	{
		if (rectangle_0.Width > 0 && rectangle_0.Height > 0 && (class821_0.Type == ChartType_Chart.Pie3D || class821_0.Type == ChartType_Chart.Pie3DExploded) && class821_0.method_8().imethod_3())
		{
			rectangle_0.X += 4;
			rectangle_0.Y += 4;
			rectangle_0.Width -= 2 * 4;
			rectangle_0.Height -= 2 * 4;
			if (class844_0.method_37() && (class844_0.method_2().vmethod_0() == Enum74.const_4 || class844_0.method_2().vmethod_0() == Enum74.const_0))
			{
				int num = Struct63.smethod_3((float)class821_0.Width / 100f * 6f);
				int num2 = Struct63.smethod_3((float)class821_0.Height / 100f * 6f);
				rectangle_0.X += num;
				rectangle_0.Y += num2;
				rectangle_0.Width -= 2 * num;
				rectangle_0.Height -= 2 * num2;
			}
		}
	}

	private static void smethod_1(ref Rectangle rectangle_0, Class821 class821_0)
	{
		int num = Struct63.smethod_3((float)rectangle_0.Width / 400f * 3f);
		int num2 = Struct63.smethod_3((float)rectangle_0.Height / 400f * 3f);
		rectangle_0.X += num;
		rectangle_0.Y += num2;
		rectangle_0.Width -= 2 * num;
		rectangle_0.Height -= 2 * num2;
		double num3 = 1.0 / 7.0 / Math.Cos(Math.PI / 18.0);
		double num4 = (double)class821_0.Elevation * Math.PI / 180.0;
		double num5 = (double)rectangle_0.Width * (Math.Sin(num4) + num3 * (double)class821_0.HeightPercent / 100.0 * Math.Cos(num4));
		double num6 = (double)rectangle_0.Height / (Math.Sin(num4) + num3 * (double)class821_0.HeightPercent / 100.0 * Math.Cos(num4));
		if (num5 <= (double)rectangle_0.Height)
		{
			rectangle_0.Y = Struct63.smethod_5((double)((float)rectangle_0.Y + (float)rectangle_0.Height / 2f) - num5 / 2.0);
			rectangle_0.Height = Struct63.smethod_5(num5);
		}
		else
		{
			rectangle_0.X = Struct63.smethod_5((double)((float)rectangle_0.X + (float)rectangle_0.Width / 2f) - num6 / 2.0);
			rectangle_0.Width = Struct63.smethod_5(num6);
		}
		double num7 = (double)rectangle_0.Width * num3 * (double)class821_0.HeightPercent / 100.0 * Math.Cos(num4);
		double num8 = num7 / (double)rectangle_0.Height;
		class821_0.method_26((float)num8);
	}

	internal static void smethod_2(Interface42 interface42_0, Class821 class821_0)
	{
		Class844 @class = (Class844)class821_0.method_7().method_16()[0];
		Class830 class2 = @class.method_9();
		Color[] array = new Color[class2.Count];
		Color[] array2 = class821_0.method_16().method_0().method_4(class821_0.imethod_7(), class2.Count);
		for (int i = 0; i < class2.Count; i++)
		{
			Class831 class3 = class2.method_1(i);
			if (@class.IsColorVaried)
			{
				class3.method_3().method_4(array2[i]);
			}
			else
			{
				class3.method_3().method_4(@class.method_6().ForegroundColor);
			}
			ref Color reference = ref array[i];
			reference = class3.method_3().ForegroundColor;
		}
		double[] array3 = new double[class2.Count];
		for (int j = 0; j < class2.Count; j++)
		{
			Class831 class4 = class2.method_1(j);
			array3[j] = class4.YValue;
		}
		string[] array4 = new string[class2.Count];
		double num = 0.0;
		for (int k = 0; k < class2.Count; k++)
		{
			num += Math.Abs(class2[k].YValue);
		}
		if (num == 0.0)
		{
			return;
		}
		for (int l = 0; l < class2.Count; l++)
		{
			Class831 class5 = class2.method_1(l);
			double yValue = class5.YValue;
			double double_ = 0.0;
			if (num != 0.0)
			{
				double_ = yValue / num;
			}
			array4[l] = smethod_3(@class, l, double_);
		}
		Rectangle rectangle_ = class821_0.method_8().rectangle_1;
		smethod_1(ref rectangle_, class821_0);
		using Class853 class6 = new Class853(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height, array3, array, class821_0.method_25(), array4, class2);
		class6.method_2(@class);
		class6.Draw(interface42_0);
		class6.vmethod_0(interface42_0);
	}

	private static string smethod_3(Class844 class844_0, int int_0, double double_0)
	{
		Class821 chart = class844_0.Chart;
		Class831 @class = class844_0.method_9().method_1(int_0);
		ArrayList arrayList = chart.method_7().method_0();
		Class823 class2 = chart.method_1();
		Class832 class3 = @class.method_6();
		bool bool_ = class3.vmethod_1();
		bool linkedSource = class3.LinkedSource;
		string string_ = (class3.IsPercentageShown ? "" : class3.imethod_2());
		string string_2 = ((class3.imethod_2() == "") ? "0%" : class3.imethod_2());
		string name = class844_0.Name;
		string text = ((int_0 < class2.arrayList_1.Count) ? Struct51.smethod_5(chart.vmethod_2(), class2.arrayList_1[int_0], string_, bool_) : "");
		if (linkedSource)
		{
			string string_3 = ((int_0 < 0 || int_0 >= arrayList.Count) ? "" : ((Class825)arrayList[int_0]).imethod_3());
			bool bool_2 = int_0 >= 0 && int_0 < arrayList.Count && ((Class825)arrayList[int_0]).imethod_1();
			text = ((int_0 < 0 || int_0 >= class2.arrayList_1.Count) ? "" : Struct51.smethod_5(chart.vmethod_2(), class2.arrayList_1[int_0], string_3, bool_2));
		}
		string text2 = Struct51.smethod_5(chart.vmethod_2(), @class.YValue, string_, bool_);
		if (linkedSource)
		{
			text2 = Struct51.smethod_5(chart.vmethod_2(), @class.YValue, @class.vmethod_6(), @class.vmethod_7());
		}
		string text3 = Struct51.smethod_5(chart.vmethod_2(), double_0, string_2, bool_);
		string text4 = Struct51.smethod_3(class3.Separator);
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
}
