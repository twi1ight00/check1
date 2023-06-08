using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using ns19;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct49
{
	internal static void smethod_0(Interface42 interface42_0, Class828 class828_0, int int_0, int int_1, int int_2, bool bool_0)
	{
		if (!class828_0.Chart.IsDataTableShown || class828_0.Chart.method_8().method_16())
		{
			return;
		}
		int num = Struct61.smethod_6(interface42_0, "a", class828_0.Font).Width * class828_0.Chart.method_1().TickLabels.Offset / 300;
		Class821 chart = class828_0.Chart;
		TextRenderingHint textRenderingHint_ = chart.imethod_0().imethod_56();
		if (chart.method_3().method_1().method_2())
		{
			chart.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
		}
		_ = chart.Type;
		bool isPlotOrderReversed = chart.method_1().IsPlotOrderReversed;
		Size size = class828_0.method_1();
		int height = size.Height + class828_0.method_3();
		SizeF sizeF = Struct53.smethod_2(interface42_0, class828_0.Chart.method_6());
		ArrayList arrayList = class828_0.LegendEntries.method_2(bool_0: true, bool_0);
		Rectangle rectangle_ = new Rectangle(int_0, int_1, int_2, height);
		Rectangle rectangle_2 = new Rectangle(int_0 - size.Width, int_1 + class828_0.method_3(), int_2 + size.Width, size.Height);
		if (class828_0.IsOutlineShown)
		{
			class828_0.method_0().method_9(rectangle_);
			class828_0.method_0().method_9(rectangle_2);
		}
		float num2 = (float)size.Height / (float)arrayList.Count;
		if (class828_0.vmethod_1())
		{
			for (int i = 1; i < arrayList.Count; i++)
			{
				float float_ = rectangle_2.Left;
				float num3 = (float)rectangle_2.Top + (float)i * num2;
				float float_2 = rectangle_2.Right;
				float float_3 = num3;
				class828_0.method_0().method_7(float_, num3, float_2, float_3);
			}
		}
		int num4 = chart.method_7().method_10();
		Font font = class828_0.Font;
		Brush brush = new SolidBrush(class828_0.FontColor);
		float num5 = (float)int_2 / (float)num4;
		bool flag = false;
		Class823 @class = chart.method_1();
		ArrayList arrayList2 = chart.method_7().method_0();
		ArrayList[] array = chart.method_7().method_4();
		Class847 class2 = @class.method_10();
		if (class2.LinkedSource && arrayList2.Count > 0)
		{
			flag = true;
		}
		if (array != null && array.Length > 0 && arrayList2.Count > 0)
		{
			flag = true;
		}
		for (int j = 0; j < num4; j++)
		{
			if (class828_0.imethod_1())
			{
				float float_ = (float)int_0 + num5 * (float)j;
				float num3 = rectangle_.Top;
				float float_2 = float_;
				float float_3 = num3 + (float)class828_0.method_5();
				class828_0.method_0().method_7(float_, num3, float_2, float_3);
			}
			int num6 = j;
			if (isPlotOrderReversed)
			{
				num6 = num4 - j - 1;
			}
			string string_ = "";
			if (num6 <= chart.method_7().method_0().Count - 1)
			{
				Class825 class3 = (Class825)arrayList2[num6];
				if (!flag)
				{
					string_ = Struct44.smethod_28(@class, class3.imethod_0());
				}
				else
				{
					string text = "";
					bool flag2 = false;
					text = ((num6 < arrayList2.Count) ? class3.imethod_3() : "");
					flag2 = num6 < arrayList2.Count && class3.imethod_1();
					string_ = Struct51.smethod_5(chart.vmethod_2(), class3.imethod_0(), text, flag2);
				}
			}
			RectangleF rectangleF_ = new RectangleF((float)int_0 + (float)j * num5, int_1 + num, num5, class828_0.method_5() - num);
			StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
			stringFormat.LineAlignment = StringAlignment.Near;
			stringFormat.Alignment = StringAlignment.Center;
			interface42_0.imethod_27(string_, font, brush, rectangleF_, stringFormat);
		}
		if (array != null && array.Length > 0 && chart.method_7().method_0().Count > 0)
		{
			Class823 class4 = chart.method_1();
			float float_4 = num;
			IList list = array[0];
			Class825 class5 = (Class825)list[0];
			string string_2 = Struct51.smethod_5(chart.vmethod_2(), class5.imethod_0(), class5.imethod_3(), class5.imethod_1());
			Struct61.smethod_2(class4.Chart.imethod_0(), string_2, 0, font, new Size(int_2, class828_0.method_3()), Enum82.const_1, Enum82.const_1);
			float float_5 = int_1;
			bool bool_ = false;
			float float_6 = rectangle_2.Top;
			float num7 = 0f;
			num7 = (isPlotOrderReversed ? ((float)rectangle_.Right) : ((float)rectangle_.Left));
			smethod_1(interface42_0, array, num7, float_6, float_4, bool_, class4, num5, class828_0, Enum82.const_1, float_5, rectangle_, bool_1: false);
		}
		for (int k = 0; k < arrayList.Count; k++)
		{
			Class837 class6 = (Class837)arrayList[k];
			Class844 class7 = class6.method_0();
			float num8 = (float)rectangle_2.Top + (float)k * num2;
			float num9 = 0f;
			if (class828_0.vmethod_0())
			{
				Struct53.smethod_22(rectangleF_0: new RectangleF(rectangle_2.Left + Struct53.int_0, num8, sizeF.Width, num2), interface42_0: interface42_0, class838_0: chart.method_6(), class837_0: class6);
				num9 = sizeF.Width + (float)Struct53.int_0;
			}
			string name = class7.Name;
			SizeF sizeF2 = Struct61.smethod_10(interface42_0, name, font);
			PointF pointF_ = new PointF((float)(int_0 - size.Width) + num9, num8 + num2 / 2f - sizeF2.Height / 2f);
			interface42_0.imethod_24(name, font, brush, pointF_);
			for (int l = 0; l < num4; l++)
			{
				if (class828_0.imethod_1() && l < num4 - 1)
				{
					float float_ = (float)int_0 + (float)(l + 1) * num5;
					float num3 = num8;
					float float_2 = float_;
					float float_3 = num8 + num2;
					class828_0.method_0().method_7(float_, num3, float_2, float_3);
				}
				if (l <= class7.method_9().Count - 1)
				{
					int int_3 = l;
					if (isPlotOrderReversed)
					{
						int_3 = class7.method_9().Count - l - 1;
					}
					Class831 class8 = class7.method_9().method_1(int_3);
					if (!class8.imethod_0() && (class8.vmethod_5() == null || !class8.vmethod_5().ToString().Equals("#N/A")))
					{
						string string_3 = class8.vmethod_6();
						bool bool_2 = class8.vmethod_7();
						name = Struct51.smethod_5(chart.vmethod_2(), class8.YValue, string_3, bool_2);
						sizeF2 = Struct61.smethod_10(interface42_0, name, font);
						pointF_ = new PointF((float)int_0 + (float)l * num5 + num5 / 2f - sizeF2.Width / 2f, num8 + num2 / 2f - sizeF2.Height / 2f);
						interface42_0.imethod_26(name, font, brush, pointF_, new StringFormat(StringFormat.GenericTypographic));
					}
				}
			}
		}
		brush?.Dispose();
		if (chart.method_3().method_1().method_2())
		{
			chart.imethod_0().imethod_57(textRenderingHint_);
		}
	}

	private static void smethod_1(Interface42 interface42_0, ArrayList[] arrayList_0, float float_0, float float_1, float float_2, bool bool_0, Class823 class823_0, double double_0, Class828 class828_0, Enum82 enum82_0, float float_3, Rectangle rectangle_0, bool bool_1)
	{
		Class821 chart = class828_0.Chart;
		int int_ = 0;
		float num = float_1;
		SizeF sizeF_ = new SizeF((float)double_0, (float)rectangle_0.Height / 2f);
		foreach (IList list in arrayList_0)
		{
			Size size = smethod_2(interface42_0, list, int_, class828_0, sizeF_);
			float num2 = float_0;
			for (int j = 0; j < list.Count; j++)
			{
				Class825 @class = (Class825)list[j];
				string string_ = Struct51.smethod_5(chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
				int num3 = Struct44.smethod_33(@class);
				float num4 = (float)((double)num3 * double_0);
				float x = (class823_0.IsPlotOrderReversed ? (num2 - num4 / 2f - (float)(size.Width / 2)) : (num2 + num4 / 2f - (float)(size.Width / 2)));
				float y = (bool_0 ? num : (num - (float)size.Height));
				RectangleF value = new RectangleF(x, y, size.Width, size.Height);
				Struct44.smethod_38(interface42_0, Rectangle.Round(value), string_, int_, class828_0.Font, class828_0.FontColor, Enum82.const_1, enum82_0);
				if (class823_0.Chart.ChartDataTable.imethod_1())
				{
					class828_0.method_0().method_7(num2, float_3, num2, num);
				}
				if (class823_0.Chart.ChartDataTable.imethod_1())
				{
					float num5 = num;
					num5 = (bool_0 ? (num + (float_2 + (float)size.Height)) : (num - (float_2 + (float)size.Height)));
					smethod_3(interface42_0, @class.imethod_9(), num2, float_3, num5, bool_0, class823_0, double_0);
				}
				num2 = (class823_0.IsPlotOrderReversed ? (num2 - num4) : (num2 + num4));
			}
			if (class823_0.Chart.ChartDataTable.imethod_1())
			{
				class828_0.method_0().method_7(num2, float_3, num2, num);
			}
			num = ((!bool_0) ? (num - (float_2 + (float)size.Height)) : (num + (float_2 + (float)size.Height)));
		}
	}

	internal static Size smethod_2(Interface42 interface42_0, IList ilist_0, int int_0, Class828 class828_0, SizeF sizeF_0)
	{
		Class821 chart = class828_0.Chart;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Class825 @class = (Class825)ilist_0[i];
			string string_ = Struct51.smethod_5(chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
			Size size = Struct61.smethod_3(interface42_0, string_, int_0, class828_0.Font, sizeF_0, Enum82.const_1, Enum82.const_1);
			if (size.Width > num)
			{
				num = size.Width;
			}
			if (size.Height > num2)
			{
				num2 = size.Height;
			}
		}
		return new Size(num, num2);
	}

	private static void smethod_3(Interface42 interface42_0, Interface10 interface10_0, float float_0, float float_1, float float_2, bool bool_0, Class823 class823_0, double double_0)
	{
		float num = float_0;
		for (int i = 0; i < interface10_0.Count; i++)
		{
			Class825 interface11_ = (Class825)interface10_0[i];
			int num2 = Struct44.smethod_33(interface11_);
			float num3 = (float)((double)num2 * double_0);
			num = (class823_0.IsPlotOrderReversed ? (num - num3) : (num + num3));
			class823_0.Chart.method_4().method_0().method_7(num, float_1, num, float_2);
		}
	}

	internal static Size smethod_4(Interface42 interface42_0, Class828 class828_0)
	{
		SizeF sizeF = smethod_5(interface42_0, class828_0);
		int num;
		if (class828_0.vmethod_0())
		{
			num = (int)(Struct53.smethod_2(interface42_0, class828_0.Chart.method_6()).Width + sizeF.Width) + Struct53.int_0 + 1;
		}
		else
		{
			num = (int)sizeF.Width + 1;
			if (sizeF.Width == 0f)
			{
				num += Struct53.int_0;
			}
		}
		int num2 = ((sizeF.Height != 0f) ? ((int)((double)sizeF.Height + 0.5) + 1 + Struct53.int_0) : ((int)((double)interface42_0.imethod_39("A", class828_0.Font).Height + 0.5) + 1 + Struct53.int_0));
		if (num > class828_0.Chart.Width)
		{
			num = class828_0.Chart.Width;
		}
		if (num > class828_0.Chart.method_3().Width - 2 * Struct47.int_0)
		{
			num = class828_0.Chart.method_3().Width - 2 * Struct47.int_0;
		}
		return new Size(num, num2 * class828_0.Chart.NSeries.Count);
	}

	private static SizeF smethod_5(Interface42 interface42_0, Class828 class828_0)
	{
		Class842 @class = class828_0.Chart.method_7();
		SizeF result = new SizeF(0f, 0f);
		for (int i = 0; i < @class.Count; i++)
		{
			Class844 class2 = @class.method_9(i);
			SizeF sizeF = interface42_0.imethod_39(class2.Name, class828_0.Font);
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

	internal static int smethod_6(Interface42 interface42_0, Class828 class828_0, Rectangle rectangle_0)
	{
		Class821 chart = class828_0.Chart;
		int num = Struct61.smethod_6(interface42_0, "a", class828_0.Font).Width * class828_0.Chart.method_1().TickLabels.Offset / 300;
		int num2 = 0;
		num2 = 0 + num;
		Font font = class828_0.Font;
		Class821 chart2 = class828_0.Chart;
		ArrayList arrayList = chart2.method_7().method_0();
		ArrayList[] array = chart2.method_7().method_4();
		float width = (float)rectangle_0.Width / (float)arrayList.Count;
		SizeF sizeF_ = new SizeF(width, (float)rectangle_0.Height / 2f);
		Size size = new Size(0, 0);
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				Class825 @class = (Class825)arrayList[i];
				string string_ = Struct51.smethod_5(chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
				Size size2 = Struct61.smethod_3(interface42_0, string_, 0, font, sizeF_, Enum82.const_1, Enum82.const_1);
				if (size2.Width > size.Width)
				{
					size.Width = size2.Width;
				}
				if (size2.Height > size.Height)
				{
					size.Height = size2.Height;
				}
			}
		}
		else
		{
			size = Struct61.smethod_3(interface42_0, "123", 0, font, sizeF_, Enum82.const_1, Enum82.const_1);
		}
		num2 += size.Height;
		class828_0.method_6(num2);
		int num3 = 0;
		if (array != null && array.Length > 0 && arrayList.Count > 0)
		{
			num2 += num * array.Length;
			foreach (IList ilist_ in array)
			{
				num3 += smethod_2(interface42_0, ilist_, 0, class828_0, sizeF_).Height;
			}
		}
		return num2 + num3;
	}
}
