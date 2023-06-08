using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns31;

namespace ns32;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct23
{
	internal static void smethod_0(Interface42 interface42_0, Class793 class793_0, bool bool_0)
	{
		if (!class793_0.Chart.IsDataTableShown || class793_0.Chart.method_8().method_18())
		{
			return;
		}
		Class787 chart = class793_0.Chart;
		TextRenderingHint textRenderingHint_ = chart.imethod_0().imethod_56();
		if (chart.method_3().method_1().method_3())
		{
			chart.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
		}
		_ = chart.Type;
		bool isPlotOrderReversed = chart.method_1().IsPlotOrderReversed;
		int x = class793_0.rectangle_0.X;
		int y = class793_0.rectangle_0.Y;
		int width = class793_0.rectangle_0.Width;
		Size size = class793_0.method_7();
		int height = size.Height + class793_0.method_9();
		Struct28.smethod_2(interface42_0, class793_0.Chart.method_6());
		ArrayList arrayList = class793_0.LegendEntries.method_2(bool_0: true, bool_0);
		Rectangle rectangle_ = new Rectangle(x, y, width, height);
		Rectangle rectangle_2 = new Rectangle(x - size.Width, y + class793_0.method_9(), width + size.Width, size.Height);
		if (class793_0.IsOutlineShown)
		{
			Struct29.smethod_6(interface42_0, rectangle_, class793_0.method_0());
			Struct29.smethod_6(interface42_0, rectangle_2, class793_0.method_0());
		}
		if (class793_0.vmethod_1())
		{
			float num = rectangle_2.Top;
			for (int i = 0; i < arrayList.Count - 1; i++)
			{
				Class803 @class = (Class803)arrayList[i];
				Class810 class2 = @class.method_0();
				float float_ = rectangle_2.Left;
				num += (float)class2.size_0.Height;
				float float_2 = rectangle_2.Right;
				float float_3 = num;
				Struct29.smethod_0(interface42_0, float_, num, float_2, float_3, class793_0.method_0());
			}
		}
		int num2 = chart.method_7().method_10();
		Font font = class793_0.Font;
		using (Brush brush_ = new SolidBrush(class793_0.FontColor))
		{
			float num3 = (float)width / (float)num2;
			for (int j = 0; j < num2; j++)
			{
				if (class793_0.imethod_1())
				{
					float float_ = (float)x + num3 * (float)j;
					float num = rectangle_.Top;
					float float_2 = float_;
					float float_3 = num + (float)class793_0.method_11();
					Struct29.smethod_0(interface42_0, float_, num, float_2, float_3, class793_0.method_0());
				}
				int num4 = j;
				if (isPlotOrderReversed)
				{
					num4 = num2 - j - 1;
				}
				string string_ = ((num4 > chart.method_7().method_0().Count - 1) ? "" : ((Class791)chart.method_7().method_0()[num4]).imethod_0().ToString());
				RectangleF rectangleF_ = new RectangleF((float)x + (float)j * num3, y + class793_0.method_1(), num3, class793_0.method_11() - class793_0.method_1());
				StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
				stringFormat.LineAlignment = StringAlignment.Near;
				stringFormat.Alignment = StringAlignment.Center;
				interface42_0.imethod_27(string_, font, brush_, rectangleF_, stringFormat);
			}
			ArrayList[] array = chart.method_7().method_4();
			if (array != null && array.Length > 0 && chart.method_7().method_0().Count > 0)
			{
				Class789 class3 = chart.method_1();
				float float_4 = class793_0.method_1();
				IList list = array[0];
				Class791 class4 = (Class791)list[0];
				string string_2 = Struct26.smethod_6(chart.vmethod_2(), class4.imethod_0(), class4.imethod_3(), class4.imethod_1());
				Struct37.smethod_11(class3.Chart.imethod_0(), string_2, 0, font, new Size(width, class793_0.method_9()), Enum82.const_1, Enum82.const_1);
				float float_5 = y;
				bool bool_ = false;
				float float_6 = rectangle_2.Top;
				float num5 = 0f;
				num5 = (isPlotOrderReversed ? ((float)rectangle_.Right) : ((float)rectangle_.Left));
				smethod_2(interface42_0, array, num5, float_6, float_4, bool_, class3, num3, class793_0, Enum82.const_1, float_5, rectangle_, bool_1: false);
			}
			float num6 = rectangle_2.Top;
			for (int k = 0; k < arrayList.Count; k++)
			{
				Class803 class5 = (Class803)arrayList[k];
				Class810 class6 = class5.method_0();
				PointF pointF = new PointF(rectangle_2.Left + class793_0.method_2(), num6 + (float)class793_0.method_1());
				float num7 = class6.size_0.Width;
				float height2 = class6.size_0.Height;
				if (class793_0.vmethod_0())
				{
					RectangleF rectangleF_2 = new RectangleF(rectangle_2.Left + class793_0.method_3(), num6 + (float)class793_0.method_1(), class793_0.method_4(), class793_0.method_6());
					smethod_1(interface42_0, class793_0, rectangleF_2, class6);
					pointF.X += class793_0.method_3() + class793_0.method_4();
					num7 -= (float)(class793_0.method_3() + class793_0.method_4());
				}
				string name = class6.Name;
				RectangleF rectangleF_3 = new RectangleF(pointF.X, pointF.Y, num7, height2);
				StringFormat stringFormat_ = new StringFormat(StringFormat.GenericTypographic);
				interface42_0.imethod_27(name, font, brush_, rectangleF_3, stringFormat_);
				for (int l = 0; l < class6.method_10().Count; l++)
				{
					if (class793_0.imethod_1() && l < class6.method_10().Count - 1)
					{
						float float_ = (float)x + (float)(l + 1) * num3;
						float num = num6;
						float float_2 = float_;
						float float_3 = num6 + (float)class6.size_0.Height;
						Struct29.smethod_0(interface42_0, float_, num, float_2, float_3, class793_0.method_0());
					}
					int int_ = l;
					if (isPlotOrderReversed)
					{
						int_ = class6.method_10().Count - l - 1;
					}
					Class796 class7 = class6.method_10().method_1(int_);
					if (!class7.imethod_0())
					{
						string string_3 = class7.vmethod_6();
						bool bool_2 = class7.vmethod_7();
						name = Struct26.smethod_6(chart.vmethod_2(), class7.YValue, string_3, bool_2);
						RectangleF rectangleF_4 = new RectangleF((float)x + (float)l * num3, num6 + (float)class793_0.method_1(), num3, class6.size_0.Height - 2 * class793_0.method_1());
						StringFormat stringFormat2 = new StringFormat(StringFormat.GenericTypographic);
						stringFormat2.Alignment = StringAlignment.Center;
						stringFormat2.LineAlignment = StringAlignment.Near;
						interface42_0.imethod_27(name, font, brush_, rectangleF_4, stringFormat2);
					}
				}
				num6 += (float)class6.size_0.Height;
			}
		}
		if (chart.method_3().method_1().method_3())
		{
			chart.imethod_0().imethod_57(textRenderingHint_);
		}
	}

	internal static void smethod_1(Interface42 interface42_0, Class793 class793_0, RectangleF rectangleF_0, Class810 class810_0)
	{
		if (class810_0.Type != ChartType_Chart.Bubble && class810_0.Type != ChartType_Chart.Bubble3D)
		{
			if (class810_0.method_27())
			{
				if (class810_0.method_6().IsVisible)
				{
					Struct29.smethod_0(interface42_0, rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f, rectangleF_0.X + rectangleF_0.Width, rectangleF_0.Y + rectangleF_0.Height / 2f, class810_0.method_6());
				}
				if (class810_0.method_8().MarkerStyle == Enum65.const_5)
				{
					return;
				}
				float float_ = rectangleF_0.X + rectangleF_0.Width / 2f;
				float float_2 = rectangleF_0.Y + rectangleF_0.Height / 2f;
				float float_3;
				if (class810_0.method_8().MarkerSize == 0)
				{
					float_3 = rectangleF_0.Height * Struct28.float_0;
				}
				else
				{
					int num = (int)((float)(class810_0.Marker.MarkerSize * 72) / interface42_0.imethod_51());
					if ((float)num <= rectangleF_0.Height * Struct28.float_0)
					{
						float_3 = class810_0.method_8().MarkerSize;
					}
					else
					{
						float num2 = num / class810_0.Chart.method_3().Height;
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						float_3 = rectangleF_0.Height * Struct28.float_0 * (1f + num2);
						float_3 = (int)((double)(float_3 * interface42_0.imethod_51() / 72f) + 0.5);
					}
				}
				Struct28.smethod_8(interface42_0, float_, float_2, class810_0.method_8(), float_3, bool_0: true);
			}
			else
			{
				float width = rectangleF_0.Width;
				float num3 = class793_0.method_5();
				RectangleF rectangleF_ = new RectangleF(rectangleF_0.X, rectangleF_0.Y + rectangleF_0.Height / 2f - num3 / 2f, width, num3);
				Struct18.smethod_0(interface42_0, rectangleF_, class810_0.method_7());
				Struct29.smethod_2(interface42_0, rectangleF_, class810_0.method_6());
			}
			return;
		}
		float num4 = class793_0.method_5();
		RectangleF rectangleF_2 = new RectangleF(rectangleF_0.X, rectangleF_0.Y + (rectangleF_0.Height - num4) / 2f, num4, num4);
		using (Brush brush_ = Struct18.smethod_1(class810_0.method_7(), rectangleF_2))
		{
			interface42_0.imethod_31(brush_, rectangleF_2);
		}
		using Pen pen_ = Struct29.smethod_5(class810_0.method_6());
		interface42_0.imethod_9(pen_, rectangleF_2);
	}

	private static void smethod_2(Interface42 interface42_0, ArrayList[] arrayList_0, float float_0, float float_1, float float_2, bool bool_0, Class789 class789_0, double double_0, Class793 class793_0, Enum82 enum82_0, float float_3, Rectangle rectangle_0, bool bool_1)
	{
		Class787 chart = class793_0.Chart;
		int int_ = 0;
		float num = float_1;
		SizeF sizeF_ = new SizeF((float)double_0, (float)rectangle_0.Height / 2f);
		foreach (IList list in arrayList_0)
		{
			Size size = smethod_3(interface42_0, list, int_, class793_0, sizeF_);
			float num2 = float_0;
			for (int j = 0; j < list.Count; j++)
			{
				Class791 @class = (Class791)list[j];
				string string_ = Struct26.smethod_6(chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
				int num3 = Struct19.smethod_33(@class);
				float num4 = (float)((double)num3 * double_0);
				float x = (class789_0.IsPlotOrderReversed ? (num2 - num4 / 2f - (float)(size.Width / 2)) : (num2 + num4 / 2f - (float)(size.Width / 2)));
				float y = (bool_0 ? num : (num - (float)size.Height));
				RectangleF value = new RectangleF(x, y, size.Width, size.Height);
				Struct19.smethod_37(interface42_0, Rectangle.Round(value), string_, int_, class793_0.Font, class793_0.FontColor, Enum82.const_1, enum82_0);
				if (class789_0.Chart.ChartDataTable.imethod_1())
				{
					Struct29.smethod_0(interface42_0, num2, float_3, num2, num, class793_0.method_0());
				}
				if (class789_0.Chart.ChartDataTable.imethod_1())
				{
					float num5 = num;
					num5 = (bool_0 ? (num + (float_2 + (float)size.Height)) : (num - (float_2 + (float)size.Height)));
					smethod_4(interface42_0, @class.imethod_9(), num2, float_3, num5, bool_0, class789_0, double_0);
				}
				num2 = (class789_0.IsPlotOrderReversed ? (num2 - num4) : (num2 + num4));
			}
			if (class789_0.Chart.ChartDataTable.imethod_1())
			{
				Struct29.smethod_0(interface42_0, num2, float_3, num2, num, class793_0.method_0());
			}
			num = ((!bool_0) ? (num - (float_2 + (float)size.Height)) : (num + (float_2 + (float)size.Height)));
		}
	}

	internal static Size smethod_3(Interface42 interface42_0, IList ilist_0, int int_0, Class793 class793_0, SizeF sizeF_0)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < ilist_0.Count; i++)
		{
			Class791 @class = (Class791)ilist_0[i];
			string string_ = Struct26.smethod_6(class793_0.Chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
			Size size = Struct37.smethod_0(interface42_0, string_, int_0, class793_0.Font, sizeF_0, Enum82.const_1, Enum82.const_1);
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

	private static void smethod_4(Interface42 interface42_0, Interface10 interface10_0, float float_0, float float_1, float float_2, bool bool_0, Class789 class789_0, double double_0)
	{
		float num = float_0;
		for (int i = 0; i < interface10_0.Count; i++)
		{
			Class791 class791_ = (Class791)interface10_0[i];
			int num2 = Struct19.smethod_33(class791_);
			float num3 = (float)((double)num2 * double_0);
			num = (class789_0.IsPlotOrderReversed ? (num - num3) : (num + num3));
			Struct29.smethod_0(interface42_0, num, float_1, num, float_2, class789_0.Chart.method_4().method_0());
		}
	}

	internal static Size smethod_5(Interface42 interface42_0, Class793 class793_0, Rectangle rectangle_0)
	{
		if (!class793_0.Chart.IsDataTableShown)
		{
			return new Size(0, 0);
		}
		_ = class793_0.Chart;
		SizeF sizeF_ = new SizeF(rectangle_0.Width / 3, rectangle_0.Height / 3);
		int num = class793_0.method_4();
		if (class793_0.vmethod_0())
		{
			sizeF_.Width -= class793_0.method_3() + num;
		}
		SizeF sizeF = new SizeF(0f, 0f);
		Class802 legendEntries = class793_0.LegendEntries;
		for (int i = 0; i < legendEntries.Count; i++)
		{
			Class803 @class = legendEntries.method_3(i);
			Class810 class2 = @class.method_0();
			string name = class2.Name;
			SizeF sizeF2 = Struct37.smethod_7(interface42_0, name, class793_0.Font, sizeF_);
			sizeF2.Width += 2 * class793_0.method_2();
			sizeF2.Height += 2 * class793_0.method_1();
			if (class793_0.vmethod_0())
			{
				sizeF2.Width += class793_0.method_3() + num;
			}
			class2.size_0 = new Size(Struct40.smethod_3(sizeF2.Width), Struct40.smethod_3(sizeF2.Height));
			if (sizeF.Width < sizeF2.Width)
			{
				sizeF.Width = sizeF2.Width;
			}
			sizeF.Height += sizeF2.Height;
		}
		return new Size(Struct40.smethod_3(sizeF.Width), Struct40.smethod_3(sizeF.Height));
	}

	internal static int smethod_6(Interface42 interface42_0, Class793 class793_0, Rectangle rectangle_0)
	{
		Size size = Struct37.smethod_3(interface42_0, "a", class793_0.Font);
		int num = 0;
		Font font = class793_0.Font;
		Class787 chart = class793_0.Chart;
		ArrayList arrayList = chart.method_7().method_0();
		ArrayList[] array = chart.method_7().method_4();
		float width = (float)rectangle_0.Width / (float)arrayList.Count;
		SizeF sizeF_ = new SizeF(width, (float)rectangle_0.Height / 2f);
		Size size2 = new Size(0, 0);
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < arrayList.Count; i++)
			{
				Class791 @class = (Class791)arrayList[i];
				string string_ = Struct26.smethod_6(class793_0.Chart.vmethod_2(), @class.imethod_0(), @class.imethod_3(), @class.imethod_1());
				Size size3 = Struct37.smethod_0(interface42_0, string_, 0, font, sizeF_, Enum82.const_1, Enum82.const_1);
				if (size3.Width > size2.Width)
				{
					size2.Width = size3.Width;
				}
				if (size3.Height > size2.Height)
				{
					size2.Height = size3.Height;
				}
			}
		}
		else
		{
			size2 = Struct37.smethod_0(interface42_0, "123", 0, font, sizeF_, Enum82.const_1, Enum82.const_1);
		}
		if (size2.Height > size.Height * 2)
		{
			size2.Height = size.Height * 2;
		}
		class793_0.method_12(size2.Height + class793_0.method_1() * 2);
		num += class793_0.method_11();
		int num2 = 0;
		if (array != null && array.Length > 0 && arrayList.Count > 0)
		{
			num += class793_0.method_1() * array.Length;
			foreach (IList ilist_ in array)
			{
				num2 += smethod_3(interface42_0, ilist_, 0, class793_0, sizeF_).Height;
			}
		}
		return num + num2;
	}
}
