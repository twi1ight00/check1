using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using Aspose.Cells.Render;
using ns19;
using ns22;
using ns3;
using ns31;

namespace ns32;

internal class Class817
{
	public static int int_0 = 10;

	public static int int_1 = 8;

	public static int int_2 = 5;

	public static int int_3 = 16;

	internal static void Calculate(Class787 class787_0)
	{
		Interface42 interface42_ = class787_0.imethod_0();
		Class808 @class = class787_0.method_7();
		if (class787_0.method_7().Count == 0 || smethod_29(class787_0.method_7().method_15()) == 0)
		{
			return;
		}
		string text = smethod_1(class787_0);
		if (text != "")
		{
			throw new ArgumentException(text);
		}
		Class808 class2 = new Class808(class787_0);
		Class808 class3 = new Class808(class787_0);
		foreach (Class810 item in @class)
		{
			if (item.method_21() == Enum53.const_0)
			{
				class2.Add(item);
			}
			else
			{
				class3.Add(item);
			}
		}
		if (!class787_0.imethod_3().IsVisible && smethod_78(class787_0))
		{
			class787_0.method_2().bool_13 = true;
			class787_0.method_1().bool_13 = true;
		}
		smethod_3(class787_0, class2, class3);
		smethod_6(class787_0);
		if (class787_0.NSeries.imethod_0().Count > 0)
		{
			class787_0.method_7().bool_0 = true;
		}
		if (class787_0.NSeries.imethod_1().Count > 0)
		{
			class787_0.method_7().bool_1 = true;
		}
		class787_0.method_7().method_5(smethod_81(class787_0.method_7().imethod_0()));
		class787_0.method_7().method_8(smethod_81(class787_0.method_7().imethod_1()));
		class787_0.method_7().method_1(smethod_82(class787_0.method_7().imethod_0()));
		class787_0.method_7().method_3(smethod_82(class787_0.method_7().imethod_1()));
		if (class787_0.method_2().bool_13)
		{
			smethod_79(class787_0.imethod_3(), class787_0.CategoryAxis);
			smethod_80(class787_0);
		}
		Struct40.smethod_1(class787_0.method_1(), class787_0.method_7().method_0(), class2);
		Struct40.smethod_1(class787_0.method_2(), class787_0.method_7().method_2(), class3);
		Class810 class5 = class2.method_9(0);
		Class810 class6 = new Class810(class787_0, null, ChartType_Chart.Column);
		if (class3.Count > 0)
		{
			class6 = (Class810)class3[0];
		}
		Struct40.smethod_6(class787_0.method_1(), class787_0.method_9(), class2, class5);
		Struct40.smethod_6(class787_0.method_2(), class787_0.method_10(), class3, class6);
		bool flag = smethod_8(class5.method_22());
		bool flag2 = smethod_8(class6.method_22());
		smethod_22(class787_0, flag, flag2);
		bool flag3 = Struct28.smethod_9(class787_0);
		class787_0.method_6().bool_0 = flag3;
		smethod_5(class787_0);
		Rectangle rectangle_ = new Rectangle(int_0, int_0, class787_0.Width - int_0 * 2, class787_0.Height - int_0 * 2);
		if (class787_0.method_12().IsVisible)
		{
			Size size = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_.Width * 0.8f, (float)rectangle_.Height * 0.5f), interface42_0: interface42_, class812_0: class787_0.method_12());
			class787_0.method_12().method_0().rectangle_1.X = (class787_0.Width - size.Width) / 2;
			class787_0.method_12().method_0().rectangle_1.Y = int_0;
			class787_0.method_12().method_0().rectangle_1.Size = size;
			rectangle_.Y += size.Height + int_1;
			rectangle_.Height -= size.Height + int_1;
		}
		if (class787_0.IsLegendShown)
		{
			if (class3.Count == 0 && (class5.method_22() == ChartType_Chart.Pie || class5.method_22() == ChartType_Chart.Doughnut || flag3))
			{
				Class810 class7 = class5;
				if (class5.Type == ChartType_Chart.Doughnut || class5.Type == ChartType_Chart.DoughnutExploded)
				{
					for (int i = 1; i < class787_0.method_7().Count; i++)
					{
						if (class787_0.method_7()[i].Points != null && class7.method_10() != null && class787_0.method_7()[i].Points.Count > class7.method_10().Count)
						{
							class7 = class787_0.method_7().method_9(i);
						}
					}
				}
				Struct28.smethod_18(interface42_, class787_0.method_6(), class7, ref rectangle_);
			}
			else
			{
				smethod_27(class787_0);
				Struct28.smethod_22(interface42_, class787_0.method_6(), ref rectangle_);
			}
		}
		if (class787_0.method_1().method_10().IsVisible)
		{
			smethod_9(class787_0.method_1(), flag);
			SizeF sizeF = default(SizeF);
			Size size_ = Struct38.smethod_3(sizeF_0: (!flag) ? new SizeF((float)rectangle_.Width * 0.9f, (float)rectangle_.Height * 0.2f) : new SizeF((float)rectangle_.Width * 0.2f, (float)rectangle_.Height * 0.9f), interface42_0: interface42_, class812_0: class787_0.method_1().method_10());
			if (class787_0.method_9().CrossType == Enum66.const_1 && !class787_0.method_9().IsPlotOrderReversed)
			{
				class787_0.method_1().bool_10 = false;
			}
			else if (class787_0.method_9().CrossType != Enum66.const_1 && class787_0.method_9().IsPlotOrderReversed)
			{
				class787_0.method_1().bool_10 = false;
			}
			smethod_11(class787_0.method_1(), ref rectangle_, flag, size_);
		}
		if (class787_0.method_9().method_10().IsVisible)
		{
			smethod_9(class787_0.method_9(), flag);
			SizeF sizeF2 = default(SizeF);
			Size size_2 = Struct38.smethod_3(sizeF_0: flag ? new SizeF((float)rectangle_.Width * 0.9f, (float)rectangle_.Height * 0.2f) : new SizeF((float)rectangle_.Width * 0.2f, (float)rectangle_.Height * 0.9f), interface42_0: interface42_, class812_0: class787_0.method_9().method_10());
			if (class787_0.method_1().CrossType == Enum66.const_1 && !class787_0.method_1().IsPlotOrderReversed)
			{
				class787_0.method_9().bool_10 = false;
			}
			else if (class787_0.method_1().CrossType != Enum66.const_1 && class787_0.method_1().IsPlotOrderReversed)
			{
				class787_0.method_9().bool_10 = false;
			}
			smethod_11(class787_0.method_9(), ref rectangle_, flag, size_2);
		}
		if (class787_0.method_2().method_10().IsVisible && class3.Count > 0)
		{
			smethod_9(class787_0.method_2(), flag2);
			SizeF sizeF3 = default(SizeF);
			Size size_3 = Struct38.smethod_3(sizeF_0: (!flag2) ? new SizeF((float)rectangle_.Width * 0.9f, (float)rectangle_.Height * 0.2f) : new SizeF((float)rectangle_.Width * 0.2f, (float)rectangle_.Height * 0.9f), interface42_0: interface42_, class812_0: class787_0.method_2().method_10());
			if (flag == flag2)
			{
				class787_0.method_2().bool_10 = !class787_0.method_1().bool_10;
			}
			else
			{
				class787_0.method_2().bool_10 = !class787_0.method_9().bool_10;
			}
			smethod_11(class787_0.method_2(), ref rectangle_, flag2, size_3);
		}
		if (class787_0.method_10().method_10().IsVisible && class3.Count > 0)
		{
			smethod_9(class787_0.method_10(), flag2);
			SizeF sizeF4 = default(SizeF);
			Size size_4 = Struct38.smethod_3(sizeF_0: flag2 ? new SizeF((float)rectangle_.Width * 0.9f, (float)rectangle_.Height * 0.2f) : new SizeF((float)rectangle_.Width * 0.2f, (float)rectangle_.Height * 0.9f), interface42_0: interface42_, class812_0: class787_0.method_10().method_10());
			if (flag == flag2)
			{
				class787_0.method_10().bool_10 = !class787_0.method_9().bool_10;
			}
			else
			{
				class787_0.method_10().bool_10 = !class787_0.method_1().bool_10;
			}
			smethod_11(class787_0.method_10(), ref rectangle_, flag2, size_4);
		}
		if (!class787_0.method_8().imethod_3())
		{
			class787_0.method_28(class787_0.method_8().vmethod_1());
			class787_0.rectangle_1 = class787_0.method_8().vmethod_1();
			if (class787_0.method_8().vmethod_1().Y < 0)
			{
				class787_0.method_8().Height += class787_0.method_8().vmethod_1().Y;
				class787_0.method_8().Y = 0;
			}
			if (class787_0.method_8().vmethod_1().X < 0)
			{
				class787_0.method_8().Width += class787_0.method_8().vmethod_1().X;
				class787_0.method_8().X = 0;
			}
			if (class787_0.method_8().Width + class787_0.method_8().X > 4000)
			{
				class787_0.method_8().Width = 4000 - class787_0.method_8().X;
			}
			if (class787_0.method_8().Height + class787_0.method_8().Y > 4000)
			{
				class787_0.method_8().Height = 4000 - class787_0.method_8().Y;
			}
			rectangle_.X = class787_0.method_8().method_7();
			rectangle_.Y = class787_0.method_8().method_8();
			rectangle_.Width = class787_0.method_8().method_5();
			rectangle_.Height = class787_0.method_8().method_6();
			rectangle_.X += int_2;
			rectangle_.Y += int_2;
			if (rectangle_.Right + int_2 > class787_0.Width)
			{
				rectangle_.Width = class787_0.Width - int_2 - rectangle_.X;
			}
			if (rectangle_.Bottom + int_2 > class787_0.Height)
			{
				rectangle_.Height = class787_0.Height - int_2 - rectangle_.Y;
			}
			if (class787_0.method_1().method_10().IsVisible)
			{
				smethod_12(class787_0.method_1(), rectangle_, flag);
			}
			if (class787_0.method_2().method_10().IsVisible && class3.Count > 0)
			{
				smethod_12(class787_0.method_2(), rectangle_, flag2);
			}
			if (class787_0.method_9().method_10().IsVisible)
			{
				smethod_12(class787_0.method_9(), rectangle_, flag);
			}
			if (class787_0.method_10().method_10().IsVisible && class3.Count > 0)
			{
				smethod_12(class787_0.method_10(), rectangle_, flag2);
			}
		}
		else
		{
			class787_0.method_28(new Rectangle(rectangle_.X - int_2, rectangle_.Y - int_2, Struct40.smethod_5(rectangle_.Width), Struct40.smethod_5(rectangle_.Height)));
		}
		Rectangle rectangle_2 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		class787_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		bool flag4 = false;
		bool flag5 = smethod_64(class787_0.method_1()) || smethod_66(class787_0.Type);
		if (class787_0.IsDataTableShown)
		{
			smethod_26(class787_0);
			if (!flag && !flag2 && class787_0.CategoryAxis.CategoryType != Enum64.const_2 && class787_0.imethod_3().CategoryType != Enum64.const_2)
			{
				class787_0.method_1().int_4 = 0;
				class787_0.CategoryAxis.MajorTickMark = Enum84.const_2;
				class787_0.CategoryAxis.MinorTickMark = Enum84.const_2;
				class787_0.method_2().int_4 = 0;
				class787_0.imethod_3().MajorTickMark = Enum84.const_2;
				class787_0.imethod_3().MinorTickMark = Enum84.const_2;
				flag4 = true;
			}
			Size size_5 = Struct23.smethod_5(interface42_, class787_0.method_4(), rectangle_);
			class787_0.method_4().method_8(size_5);
			int num = Struct23.smethod_6(interface42_, class787_0.method_4(), rectangle_);
			class787_0.method_4().method_10(num);
			int num2 = size_5.Height + num;
			rectangle_.X += size_5.Width;
			rectangle_.Width -= size_5.Width;
			rectangle_.Height -= num2;
			if (flag5)
			{
				class787_0.method_4().rectangle_0.X = rectangle_.X;
				class787_0.method_4().rectangle_0.Y = rectangle_.Bottom;
				class787_0.method_4().rectangle_0.Width = rectangle_.Width;
				rectangle_.Height -= int_1;
			}
		}
		int num3 = smethod_29(class2.method_15());
		int num4 = smethod_29(class3.method_15());
		bool flag6 = false;
		double minValue;
		double maxValue;
		if (smethod_35(class787_0, class2.method_15(), class3.method_15()))
		{
			Class789 class8 = smethod_36(class787_0);
			flag6 = smethod_38(class2.method_15(), class3.method_15(), out minValue, out maxValue, class8);
			class787_0.double_0 = minValue;
			class787_0.double_1 = maxValue;
			class787_0.bool_7 = true;
			class787_0.class789_5 = class8;
		}
		else
		{
			flag6 = smethod_30(class2.method_15(), out minValue, out maxValue, class787_0.method_9());
		}
		double double_ = maxValue;
		double double_2 = minValue;
		bool flag7 = class787_0.method_9().imethod_7();
		bool flag8 = class787_0.method_9().imethod_9();
		bool flag9 = class787_0.method_9().imethod_5();
		bool flag10 = class787_0.method_9().imethod_3();
		if (class787_0.bool_7)
		{
			if (class787_0.class789_5 == class787_0.method_9())
			{
				smethod_44(interface42_, class787_0.method_9(), maxValue, minValue, flag6, class787_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
			}
			else
			{
				smethod_44(interface42_, class787_0.method_10(), maxValue, minValue, flag6, class787_0.method_10().arrayList_1, class6.method_22(), rectangle_, flag2, class3.method_9(0));
			}
			if (class5.method_36() && class6.method_36())
			{
				bool bool_ = smethod_30(class2.method_15(), out var minValue2, out var maxValue2, class787_0.method_9());
				smethod_44(interface42_, class787_0.method_9(), maxValue2, minValue2, bool_, class787_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
				bool_ = smethod_30(class3.method_15(), out minValue2, out maxValue2, class787_0.method_10());
				smethod_44(interface42_, class787_0.method_10(), maxValue2, minValue2, bool_, class787_0.method_10().arrayList_1, class6.method_22(), rectangle_, flag2, class3.method_9(0));
				smethod_41(class787_0.method_9());
				smethod_41(class787_0.method_10());
			}
			Class789 class789_ = smethod_37(class787_0);
			smethod_40(class789_, class787_0.class789_5);
		}
		else if (class5.method_22() != ChartType_Chart.Pie && class5.method_22() != ChartType_Chart.Doughnut)
		{
			smethod_44(interface42_, class787_0.method_9(), maxValue, minValue, flag6, class787_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
		}
		bool flag11 = class787_0.method_1().imethod_7();
		bool flag12 = class787_0.method_1().imethod_9();
		bool flag13 = class787_0.method_1().imethod_5();
		bool flag14 = class787_0.method_1().imethod_3();
		new Class808(class787_0);
		if (class787_0.method_1().bool_13)
		{
			smethod_62(interface42_, class787_0.method_1(), class787_0.method_1().arrayList_1, rectangle_, class5.method_22(), @class, flag);
		}
		else
		{
			smethod_62(interface42_, class787_0.method_1(), class787_0.method_1().arrayList_1, rectangle_, class5.method_22(), class2, flag);
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_9().IsVisible && !class5.method_36())
		{
			smethod_16(class787_0.method_9(), class787_0.method_1(), class2, class787_0);
			Size size_6 = Struct19.smethod_19(interface42_, class787_0.method_9(), class5, flag);
			smethod_10(class787_0.method_9(), flag);
			SizeF sizeF5 = default(SizeF);
			Size size_7 = Struct38.smethod_2(sizeF_0: flag ? new SizeF((float)rectangle_.Width * 0.9f, (float)rectangle_.Height * 0.2f) : new SizeF((float)rectangle_.Width * 0.2f, (float)rectangle_.Height * 0.9f), class787_0: class787_0, class799_0: class787_0.method_9().method_11(), rectangle_0: rectangle_2);
			smethod_17(class787_0, interface42_, class787_0.method_9(), size_6, size_7, ref rectangle_, flag);
		}
		if (!Struct40.smethod_19(rectangle_) && !flag4 && class787_0.method_1().IsVisible && !class5.method_36())
		{
			smethod_16(class787_0.method_1(), class787_0.method_9(), class2, class787_0);
			bool flag15 = false;
			if (rectangle_.Height <= 15 || rectangle_.Height <= class787_0.method_1().TickLabels.Font.Height)
			{
				flag15 = true;
			}
			Rectangle rectangle_3 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
			if (flag15)
			{
				rectangle_3.Height += 2 * class787_0.method_1().TickLabels.Font.Height;
			}
			Size size_8 = Struct19.smethod_20(interface42_, class787_0.method_1(), rectangle_3, num3, flag, class5);
			int num5 = (int)((double)(class787_0.method_1().method_9().method_1() + class787_0.method_1().method_18() + class787_0.method_1().method_20()) + 0.5);
			if (class787_0.method_7().method_4() != null)
			{
				num5 += num5 * class787_0.method_7().method_4().Length;
			}
			if (class5.method_22() == ChartType_Chart.Scatter || class5.method_22() == ChartType_Chart.Bubble)
			{
				smethod_10(class787_0.method_1(), flag);
				SizeF sizeF6 = default(SizeF);
				num5 += Struct38.smethod_2(sizeF_0: (!flag) ? new SizeF((float)rectangle_.Width * 0.9f, (float)rectangle_.Height * 0.2f) : new SizeF((float)rectangle_.Width * 0.2f, (float)rectangle_.Height * 0.9f), class787_0: class787_0, class799_0: class787_0.method_1().method_11(), rectangle_0: rectangle_2).Height;
			}
			if (!flag15)
			{
				smethod_18(class787_0, interface42_, class787_0.method_1(), size_8, num5, ref rectangle_, flag);
			}
		}
		if (class3.Count > 0)
		{
			if (class787_0.bool_7)
			{
				double double_3 = class787_0.double_0;
				double double_4 = class787_0.double_1;
			}
			else
			{
				double double_3;
				double double_4;
				bool bool_2 = smethod_30(class3.method_15(), out double_3, out double_4, class787_0.method_10());
				smethod_44(interface42_, class787_0.method_10(), double_4, double_3, bool_2, class787_0.method_10().arrayList_1, class6.method_22(), rectangle_, flag2, class3.method_9(0));
			}
			smethod_21(class787_0.method_10(), class3);
			if (class787_0.method_1().bool_13)
			{
				class787_0.method_2().arrayList_1 = class787_0.method_1().arrayList_1;
				class787_0.method_2().MaxValue = class787_0.method_1().MaxValue;
				class787_0.method_2().MinValue = class787_0.method_1().MinValue;
				class787_0.method_2().MajorUnit = class787_0.method_1().MajorUnit;
				class787_0.method_2().MinorUnit = class787_0.method_1().MinorUnit;
			}
			else
			{
				smethod_62(interface42_, class787_0.method_2(), class787_0.method_2().arrayList_1, rectangle_, class6.method_22(), class3, flag2);
			}
			smethod_21(class787_0.method_2(), class3);
			if (!Struct40.smethod_19(rectangle_) && class787_0.method_10().IsVisible && !class6.method_36())
			{
				smethod_16(class787_0.method_10(), class787_0.method_2(), class3, class787_0);
				Size size_9 = Struct19.smethod_19(interface42_, class787_0.method_10(), class6, flag2);
				smethod_10(class787_0.method_10(), flag2);
				SizeF sizeF7 = default(SizeF);
				Size size_10 = Struct38.smethod_2(sizeF_0: flag2 ? new SizeF((float)rectangle_.Width * 0.9f, (float)rectangle_.Height * 0.2f) : new SizeF((float)rectangle_.Width * 0.2f, (float)rectangle_.Height * 0.9f), class787_0: class787_0, class799_0: class787_0.method_10().method_11(), rectangle_0: rectangle_2);
				if (flag == flag2)
				{
					if (class787_0.method_10().int_4 != 3 && class787_0.method_10().int_4 == class787_0.method_9().int_4)
					{
						class787_0.method_10().int_4 = 0;
					}
				}
				else if (class787_0.method_10().int_4 != 3 && class787_0.method_10().int_4 == class787_0.method_1().int_4)
				{
					class787_0.method_10().int_4 = 0;
				}
				smethod_17(class787_0, interface42_, class787_0.method_10(), size_9, size_10, ref rectangle_, flag2);
			}
			if (!Struct40.smethod_19(rectangle_) && !flag4 && class787_0.method_2().IsVisible && !class6.method_36())
			{
				smethod_16(class787_0.method_2(), class787_0.method_10(), class3, class787_0);
				Size size_11 = Struct19.smethod_20(interface42_, class787_0.method_2(), rectangle_, num4, flag2, class6);
				int num6 = (int)((double)(class787_0.method_2().method_9().method_1() + class787_0.method_2().method_18() + class787_0.method_2().method_20()) + 0.5);
				if (class6.method_22() == ChartType_Chart.Scatter || class6.method_22() == ChartType_Chart.Bubble)
				{
					smethod_10(class787_0.method_1(), flag2);
					SizeF sizeF8 = default(SizeF);
					num6 += Struct38.smethod_2(sizeF_0: (!flag2) ? new SizeF((float)rectangle_.Width * 0.9f, (float)rectangle_.Height * 0.2f) : new SizeF((float)rectangle_.Width * 0.2f, (float)rectangle_.Height * 0.9f), class787_0: class787_0, class799_0: class787_0.method_1().method_11(), rectangle_0: rectangle_2).Height;
				}
				if (flag == flag2)
				{
					if (class787_0.method_2().int_4 != 3 && class787_0.method_2().int_4 == class787_0.method_1().int_4)
					{
						class787_0.method_2().int_4 = 0;
					}
				}
				else if (class787_0.method_2().int_4 != 3 && class787_0.method_2().int_4 == class787_0.method_9().int_4)
				{
					class787_0.method_2().int_4 = 0;
				}
				smethod_18(class787_0, interface42_, class787_0.method_2(), size_11, num6, ref rectangle_, flag2);
			}
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_9().IsVisible && class787_0.method_9().TickLabelPosition != Enum83.const_3 && !class5.method_36())
		{
			bool flag16 = false;
			if (rectangle_.Height <= 15 || rectangle_.Height <= class787_0.method_9().TickLabels.Font.Height)
			{
				flag16 = true;
			}
			if (!flag16)
			{
				Struct19.smethod_25(interface42_, class787_0.method_9(), class5, flag);
				float float_ = class787_0.method_9().float_4;
				float float_2 = class787_0.method_9().float_5;
				if (!flag)
				{
					if ((float)(rectangle_.Y - rectangle_2.Y) < float_2)
					{
						int num7 = (int)(float_2 - (float)(rectangle_.Y - rectangle_2.Y));
						rectangle_.Y += num7;
						rectangle_.Height -= num7;
					}
					if ((float)(rectangle_2.Bottom - rectangle_.Bottom) < float_)
					{
						int num8 = (int)(float_ - (float)(rectangle_2.Bottom - rectangle_.Bottom));
						rectangle_.Height -= num8;
					}
				}
				else
				{
					if ((float)(rectangle_.X - rectangle_2.X) < float_)
					{
						int num9 = (int)(float_ - (float)(rectangle_.X - rectangle_2.X));
						rectangle_.X += num9;
						rectangle_.Width -= num9;
					}
					if ((float)(rectangle_2.Right - rectangle_.Right) < float_2)
					{
						int num10 = (int)(float_2 - (float)(rectangle_2.Right - rectangle_.Right));
						rectangle_.Width -= num10;
					}
				}
			}
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_1().IsVisible && class787_0.method_1().TickLabelPosition != Enum83.const_3 && !class5.method_36() && (class787_0.method_1().float_4 > 0f || class787_0.method_1().float_5 > 0f))
		{
			float float_3 = class787_0.method_1().float_4;
			float float_4 = class787_0.method_1().float_5;
			if (flag)
			{
				if ((float)(rectangle_.Y - rectangle_2.Y) < float_4)
				{
					int num11 = (int)(float_4 - (float)(rectangle_.Y - rectangle_2.Y));
					rectangle_.Y += num11;
					rectangle_.Height -= num11;
				}
				if ((float)(rectangle_2.Bottom - rectangle_.Bottom) < float_3)
				{
					int num12 = (int)(float_3 - (float)(rectangle_2.Bottom - rectangle_.Bottom));
					rectangle_.Height -= num12;
				}
			}
			else
			{
				if ((float)(rectangle_.X - rectangle_2.X) < float_3)
				{
					int num13 = (int)(float_3 - (float)(rectangle_.X - rectangle_2.X));
					rectangle_.X += num13;
					rectangle_.Width -= num13;
				}
				if ((float)(rectangle_2.Right - rectangle_.Right) < float_4)
				{
					int num14 = (int)(float_4 - (float)(rectangle_2.Right - rectangle_.Right));
					rectangle_.Width -= num14;
				}
			}
		}
		if (class3.Count > 0)
		{
			if (!Struct40.smethod_19(rectangle_) && class787_0.method_10().IsVisible && class787_0.method_10().TickLabelPosition != Enum83.const_3 && !class6.method_36())
			{
				if (!flag2)
				{
					float num15 = class787_0.method_10().float_1 / 2f;
					if ((float)(rectangle_.Y - rectangle_2.Y) < num15)
					{
						int num16 = (int)(num15 - (float)(rectangle_.Y - rectangle_2.Y));
						rectangle_.Y += num16;
						rectangle_.Height -= num16;
					}
					if ((float)(rectangle_2.Bottom - rectangle_.Bottom) < num15)
					{
						int num17 = (int)(num15 - (float)(rectangle_2.Bottom - rectangle_.Bottom));
						rectangle_.Height -= num17;
					}
				}
				else
				{
					float num18 = class787_0.method_10().float_0 / 2f;
					if ((float)(rectangle_.X - rectangle_2.X) < num18)
					{
						int num19 = (int)(num18 - (float)(rectangle_.X - rectangle_2.X));
						rectangle_.X += num19;
						rectangle_.Width -= num19;
					}
					if ((float)(rectangle_2.Right - rectangle_.Right) < num18)
					{
						int num20 = (int)(num18 - (float)(rectangle_2.Right - rectangle_.Right));
						rectangle_.Width -= num20;
					}
				}
			}
			if (!Struct40.smethod_19(rectangle_) && class787_0.method_2().IsVisible && class787_0.method_2().TickLabelPosition != Enum83.const_3 && !class6.method_36() && (class787_0.method_2().float_4 > 0f || class787_0.method_2().float_5 > 0f))
			{
				if (flag2)
				{
					float num21 = class787_0.method_2().float_1 / 2f;
					if ((float)(rectangle_.Y - rectangle_2.Y) < num21)
					{
						int num22 = (int)(num21 - (float)(rectangle_.Y - rectangle_2.Y));
						rectangle_.Y += num22;
						rectangle_.Height -= num22;
					}
					if ((float)(rectangle_2.Bottom - rectangle_.Bottom) < num21)
					{
						int num23 = (int)(num21 - (float)(rectangle_2.Bottom - rectangle_.Bottom));
						rectangle_.Height -= num23;
					}
				}
				else
				{
					float num24 = class787_0.method_2().float_0 / 2f;
					if ((float)(rectangle_.X - rectangle_2.X) < num24)
					{
						int num25 = (int)(num24 - (float)(rectangle_.X - rectangle_2.X));
						rectangle_.X += num25;
						rectangle_.Width -= num25;
					}
					if ((float)(rectangle_2.Right - rectangle_.Right) < num24)
					{
						int num26 = (int)(num24 - (float)(rectangle_2.Right - rectangle_.Right));
						rectangle_.Width -= num26;
					}
				}
			}
		}
		class787_0.method_24(new RectangleF(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height));
		if (!Struct40.smethod_19(rectangle_))
		{
			smethod_20(interface42_, class787_0, class5, class6, ref rectangle_);
		}
		class787_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		Struct28.smethod_3(class787_0.method_6(), rectangle_);
		if (class787_0.method_1().method_10().IsVisible)
		{
			smethod_13(class787_0.method_1(), flag);
		}
		if (class787_0.method_9().method_10().IsVisible)
		{
			smethod_13(class787_0.method_9(), flag);
		}
		if (class787_0.method_2().method_10().IsVisible && class3.Count > 0)
		{
			smethod_13(class787_0.method_2(), flag2);
		}
		if (class787_0.method_10().method_10().IsVisible && class3.Count > 0)
		{
			smethod_13(class787_0.method_10(), flag2);
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_9().IsVisible && !class5.method_36())
		{
			int num27 = smethod_48(interface42_, class787_0.method_9(), flag, class5, rectangle_);
			int num28 = 0;
			num28 = ((!flag) ? rectangle_.Height : rectangle_.Width);
			bool flag17 = false;
			if (rectangle_.Height <= 15 || rectangle_.Height <= class787_0.method_9().TickLabels.Font.Height)
			{
				flag17 = true;
			}
			int num29 = 3;
			if (flag17)
			{
				num29 = 2;
			}
			if (flag7 && class787_0.method_9().arrayList_1.Count > num29 && num27 > num28 && num28 != 0)
			{
				double maxValue3 = class787_0.ValueAxis.MaxValue;
				class787_0.method_9().arrayList_1.Clear();
				class787_0.method_9().imethod_8(flag7);
				class787_0.method_9().imethod_10(flag8);
				class787_0.method_9().imethod_6(flag9);
				class787_0.method_9().imethod_4(flag10);
				smethod_44(interface42_, class787_0.method_9(), maxValue, minValue, flag6, class787_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
				if (class787_0.method_9().MaxValue > maxValue3)
				{
					Struct19.smethod_19(interface42_, class787_0.method_9(), class5, flag);
				}
			}
		}
		if (class787_0.method_8().imethod_3() && class787_0.method_1().IsVisible && class5.method_22() == ChartType_Chart.Scatter)
		{
			int num30 = smethod_48(interface42_, class787_0.method_1(), bool_0: true, class5, rectangle_);
			int num31 = 0;
			num31 = ((!flag) ? rectangle_.Height : rectangle_.Width);
			if (flag11 && class787_0.method_1().arrayList_1.Count > 3 && num30 > num31 && num31 != 0)
			{
				class787_0.method_1().arrayList_1.Clear();
				class787_0.method_1().imethod_8(flag11);
				class787_0.method_1().imethod_10(flag12);
				class787_0.method_1().imethod_6(flag13);
				class787_0.method_1().imethod_4(flag14);
				smethod_62(interface42_, class787_0.method_1(), class787_0.method_1().arrayList_1, rectangle_, class5.method_22(), class2, flag);
			}
		}
		if (!Struct40.smethod_19(rectangle_) && flag && flag7)
		{
			smethod_59(class787_0.method_9(), double_, double_2, class787_0.Type, rectangle_.Width, flag, @class.method_9(0), flag9, flag10, flag7);
		}
		if (!Struct40.smethod_19(rectangle_) && smethod_56(class787_0.Type))
		{
			Struct21.smethod_5(interface42_, @class, rectangle_, @class.method_10(), flag11, flag12, flag13, flag14, flag7, flag8, flag9, flag10);
		}
		class787_0.method_8().method_9();
		rectangle_ = class787_0.method_8().rectangle_0;
		float x = smethod_14(class787_0.method_9(), rectangle_.X, rectangle_.Width, flag);
		_ = class787_0.method_9().CrossAt;
		smethod_14(class787_0.method_10(), rectangle_.X, rectangle_.Width, flag2);
		_ = class787_0.method_10().CrossAt;
		float y = smethod_14(class787_0.method_9(), rectangle_.Y, rectangle_.Height, flag);
		smethod_14(class787_0.method_10(), rectangle_.Y, rectangle_.Height, flag2);
		float y2 = smethod_15(class787_0.method_1(), rectangle_.Y, rectangle_.Height, flag, class2);
		smethod_15(class787_0.method_2(), rectangle_.Y, rectangle_.Height, flag2, class3);
		float num32 = 0f;
		num32 = ((class5.method_22() == ChartType_Chart.Bubble || class5.method_22() == ChartType_Chart.Scatter) ? smethod_14(class787_0.method_1(), rectangle_.X, rectangle_.Width, !flag) : smethod_15(class787_0.method_1(), rectangle_.X, rectangle_.Width, flag, class2));
		if (class6.method_22() != ChartType_Chart.Bubble && class6.method_22() != ChartType_Chart.Scatter)
		{
			smethod_15(class787_0.method_2(), rectangle_.X, rectangle_.Width, flag2, class3);
		}
		else
		{
			smethod_14(class787_0.method_2(), rectangle_.X, rectangle_.Width, !flag2);
		}
		if (flag)
		{
			PointF pointF_ = new PointF(x, rectangle_.Y);
			PointF pointF_2 = new PointF(x, rectangle_.Bottom);
			if (class787_0.method_1().IsPlotOrderReversed)
			{
				class787_0.method_1().method_22(pointF_);
				class787_0.method_1().method_23(pointF_2);
			}
			else
			{
				class787_0.method_1().method_22(pointF_2);
				class787_0.method_1().method_23(pointF_);
			}
		}
		else
		{
			PointF pointF_3 = new PointF(rectangle_.X, y);
			PointF pointF_4 = new PointF(rectangle_.Right, y);
			if (!class787_0.method_1().IsPlotOrderReversed)
			{
				class787_0.method_1().method_22(pointF_3);
				class787_0.method_1().method_23(pointF_4);
			}
			else
			{
				class787_0.method_1().method_22(pointF_4);
				class787_0.method_1().method_23(pointF_3);
			}
		}
		if (flag2)
		{
			PointF pointF_5 = new PointF(x, rectangle_.Y);
			PointF pointF_6 = new PointF(x, rectangle_.Bottom);
			if (class787_0.method_2().IsPlotOrderReversed)
			{
				class787_0.method_2().method_22(pointF_5);
				class787_0.method_2().method_23(pointF_6);
			}
			else
			{
				class787_0.method_2().method_22(pointF_6);
				class787_0.method_2().method_23(pointF_5);
			}
		}
		else
		{
			PointF pointF_7 = new PointF(rectangle_.X, y);
			PointF pointF_8 = new PointF(rectangle_.Right, y);
			if (!class787_0.method_2().IsPlotOrderReversed)
			{
				class787_0.method_2().method_22(pointF_7);
				class787_0.method_2().method_23(pointF_8);
			}
			else
			{
				class787_0.method_2().method_22(pointF_8);
				class787_0.method_2().method_23(pointF_7);
			}
		}
		if (flag)
		{
			PointF pointF_9 = new PointF(rectangle_.X, y2);
			PointF pointF_10 = new PointF(rectangle_.Right, y2);
			if (!class787_0.method_9().IsPlotOrderReversed)
			{
				class787_0.method_9().method_22(pointF_9);
				class787_0.method_9().method_23(pointF_10);
			}
			else
			{
				class787_0.method_9().method_22(pointF_10);
				class787_0.method_9().method_23(pointF_9);
			}
		}
		else
		{
			PointF pointF_11 = new PointF(num32, rectangle_.Y);
			PointF pointF_12 = new PointF(num32, rectangle_.Bottom);
			if (class787_0.method_9().IsPlotOrderReversed)
			{
				class787_0.method_9().method_22(pointF_11);
				class787_0.method_9().method_23(pointF_12);
			}
			else
			{
				class787_0.method_9().method_22(pointF_12);
				class787_0.method_9().method_23(pointF_11);
			}
		}
		if (flag2)
		{
			PointF pointF_13 = new PointF(rectangle_.X, y2);
			PointF pointF_14 = new PointF(rectangle_.Right, y2);
			if (!class787_0.method_10().IsPlotOrderReversed)
			{
				class787_0.method_10().method_22(pointF_13);
				class787_0.method_10().method_23(pointF_14);
			}
			else
			{
				class787_0.method_10().method_22(pointF_14);
				class787_0.method_10().method_23(pointF_13);
			}
		}
		else
		{
			PointF pointF_15 = new PointF(num32, rectangle_.Y);
			PointF pointF_16 = new PointF(num32, rectangle_.Bottom);
			if (class787_0.method_10().IsPlotOrderReversed)
			{
				class787_0.method_10().method_22(pointF_15);
				class787_0.method_10().method_23(pointF_16);
			}
			else
			{
				class787_0.method_10().method_22(pointF_16);
				class787_0.method_10().method_23(pointF_15);
			}
		}
		smethod_24(class787_0);
		class787_0.bool_8 = true;
	}

	internal static void smethod_0(Class787 class787_0)
	{
		if (!class787_0.bool_8)
		{
			Calculate(class787_0);
		}
		TextRenderingHint textRenderingHint_ = class787_0.imethod_0().imethod_56();
		Struct39.smethod_0(class787_0);
		Interface42 interface42_ = class787_0.imethod_0();
		Class808 @class = class787_0.method_7();
		if (class787_0.method_7().Count == 0 || smethod_29(class787_0.method_7().method_15()) == 0)
		{
			return;
		}
		Class808 class2 = new Class808(class787_0);
		Class808 class3 = new Class808(class787_0);
		foreach (Class810 item in @class)
		{
			if (item.method_21() == Enum53.const_0)
			{
				class2.Add(item);
			}
			else
			{
				class3.Add(item);
			}
		}
		Class810 class5 = class2.method_9(0);
		Class810 class6 = new Class810(class787_0, null, ChartType_Chart.Column);
		if (class3.Count > 0)
		{
			class6 = (Class810)class3[0];
		}
		bool flag = smethod_8(class5.method_22());
		bool flag2 = smethod_8(class6.method_22());
		int num = smethod_29(class2.method_15());
		int num2 = smethod_29(class3.method_15());
		_ = class787_0.method_1().bool_13;
		bool flag3 = class787_0.method_8().method_18();
		if (class5.Type != ChartType_Chart.Pie && class5.Type != ChartType_Chart.PieExploded)
		{
			Struct24.smethod_0(interface42_, class787_0.method_8());
		}
		else
		{
			class787_0.method_8().method_9();
		}
		Rectangle rectangle_ = class787_0.method_8().rectangle_0;
		float num3 = smethod_14(class787_0.method_9(), rectangle_.X, rectangle_.Width, flag);
		double crossAt = class787_0.method_9().CrossAt;
		float num4 = smethod_14(class787_0.method_10(), rectangle_.X, rectangle_.Width, flag2);
		double crossAt2 = class787_0.method_10().CrossAt;
		float num5 = smethod_14(class787_0.method_9(), rectangle_.Y, rectangle_.Height, flag);
		float num6 = smethod_14(class787_0.method_10(), rectangle_.Y, rectangle_.Height, flag2);
		float float_ = smethod_15(class787_0.method_1(), rectangle_.Y, rectangle_.Height, flag, class2);
		float float_2 = smethod_15(class787_0.method_2(), rectangle_.Y, rectangle_.Height, flag2, class3);
		float num7 = 0f;
		float num8 = 0f;
		num7 = ((class5.method_22() == ChartType_Chart.Bubble || class5.method_22() == ChartType_Chart.Scatter) ? smethod_14(class787_0.method_1(), rectangle_.X, rectangle_.Width, !flag) : smethod_15(class787_0.method_1(), rectangle_.X, rectangle_.Width, flag, class2));
		num8 = ((class6.method_22() == ChartType_Chart.Bubble || class6.method_22() == ChartType_Chart.Scatter) ? smethod_14(class787_0.method_2(), rectangle_.X, rectangle_.Width, !flag2) : smethod_15(class787_0.method_2(), rectangle_.X, rectangle_.Width, flag2, class3));
		if (class5.method_36())
		{
			Struct19.smethod_1(interface42_, class787_0.method_9(), rectangle_, num);
		}
		else
		{
			Struct19.smethod_0(interface42_, class787_0.method_1(), rectangle_, flag, class5);
			Struct19.smethod_0(interface42_, class787_0.method_9(), rectangle_, flag, class5);
		}
		if (class6.method_36())
		{
			Struct19.smethod_1(interface42_, class787_0.method_10(), rectangle_, num2);
		}
		else
		{
			Struct19.smethod_0(interface42_, class787_0.method_2(), rectangle_, flag2, class6);
			Struct19.smethod_0(interface42_, class787_0.method_10(), rectangle_, flag2, class6);
		}
		for (int i = 0; i < @class.Count; i++)
		{
			Class798 class7 = @class.method_9(i).method_3();
			class7.method_0().method_10(class787_0.method_8().rectangle_0.Width);
			class7.method_0().method_11(class787_0.method_8().rectangle_0.Height);
			for (int j = 0; j < @class[i].Points.Count; j++)
			{
				Class798 class8 = @class.method_9(i).method_10().method_1(j)
					.method_6();
				class8.method_0().method_10(class787_0.method_8().rectangle_0.Width);
				class8.method_0().method_11(class787_0.method_8().rectangle_0.Height);
			}
			for (int k = 0; k < @class.method_9(i).method_11().Count; k++)
			{
				Class815 class9 = @class.method_9(i).method_11().method_1(k);
				class9.method_3().method_0().method_10(class787_0.method_8().rectangle_0.Width);
				class9.method_3().method_0().method_11(class787_0.method_8().rectangle_0.Height);
			}
		}
		int num9 = 0;
		float num10 = 0f;
		float num11 = 0f;
		double num12 = 0.0;
		IList list = @class.method_16();
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		bool flag4 = false;
		for (int l = 0; l < list.Count; l++)
		{
			if (flag3)
			{
				break;
			}
			Class810 class10 = (Class810)list[l];
			if (class10.method_21() == Enum53.const_0)
			{
				num9 = num;
				num10 = num3;
				num12 = crossAt;
				num11 = num5;
			}
			else
			{
				num9 = num2;
				num10 = num4;
				num12 = crossAt2;
				num11 = num6;
			}
			if (class787_0.bool_7)
			{
				if (class787_0.method_9() == class787_0.class789_5)
				{
					num10 = num3;
					num12 = crossAt;
					num11 = num5;
				}
				else
				{
					num10 = num4;
					num12 = crossAt2;
					num11 = num6;
				}
			}
			if (class10.method_24(new ChartType_Chart[1] { ChartType_Chart.Column }))
			{
				ArrayList c = Struct25.smethod_0(interface42_, class10, rectangle_, num11, num12, num9);
				arrayList.AddRange(c);
				continue;
			}
			if (class10.method_24(new ChartType_Chart[1] { ChartType_Chart.ColumnStacked }))
			{
				ArrayList c2 = Struct25.smethod_23(interface42_, class10, rectangle_, num9);
				arrayList.AddRange(c2);
				continue;
			}
			if (class10.method_24(new ChartType_Chart[1] { ChartType_Chart.Column100PercentStacked }))
			{
				ArrayList c3 = Struct25.smethod_28(interface42_, class10, rectangle_, num9);
				arrayList.AddRange(c3);
				continue;
			}
			if (class10.method_24(new ChartType_Chart[2]
			{
				ChartType_Chart.Line,
				ChartType_Chart.LineWithDataMarkers
			}))
			{
				ArrayList c4 = Struct25.smethod_17(interface42_, class10, rectangle_, num11, num12, num9);
				arrayList2.AddRange(c4);
				continue;
			}
			if (class10.method_24(new ChartType_Chart[2]
			{
				ChartType_Chart.LineStacked,
				ChartType_Chart.LineStackedWithDataMarkers
			}))
			{
				ArrayList c5 = Struct25.smethod_26(interface42_, class10, rectangle_, num11, num9);
				arrayList2.AddRange(c5);
				continue;
			}
			if (class10.method_24(new ChartType_Chart[2]
			{
				ChartType_Chart.Line100PercentStacked,
				ChartType_Chart.Line100PercentStackedWithDataMarkers
			}))
			{
				ArrayList c6 = Struct25.smethod_30(interface42_, class10, rectangle_, num11, num9);
				arrayList2.AddRange(c6);
				continue;
			}
			if (class10.method_24(new ChartType_Chart[1] { ChartType_Chart.Bar }))
			{
				ArrayList c7 = Struct20.smethod_0(interface42_, class787_0, class10, rectangle_, num10, num12, num9);
				arrayList3.AddRange(c7);
				continue;
			}
			if (class10.method_24(new ChartType_Chart[1] { ChartType_Chart.BarStacked }))
			{
				ArrayList c8 = Struct20.smethod_5(interface42_, class787_0, class10, rectangle_, num9);
				arrayList3.AddRange(c8);
				continue;
			}
			if (class10.method_24(new ChartType_Chart[1] { ChartType_Chart.Bar100PercentStacked }))
			{
				ArrayList c9 = Struct20.smethod_8(interface42_, class787_0, class10, rectangle_, num9);
				arrayList3.AddRange(c9);
				continue;
			}
			if (class10.method_25(new ChartType_Chart[1] { ChartType_Chart.Scatter }))
			{
				ArrayList c10 = Struct41.smethod_0(interface42_, class10, rectangle_, num11, num12, num9);
				arrayList2.AddRange(c10);
				continue;
			}
			ChartType_Chart[] chartType_Chart_ = new ChartType_Chart[1];
			if (class10.method_24(chartType_Chart_))
			{
				ArrayList c11 = Struct17.smethod_0(interface42_, class787_0, class10, rectangle_, num11, num12, num9);
				arrayList2.AddRange(c11);
			}
			else if (class10.method_24(new ChartType_Chart[1] { ChartType_Chart.AreaStacked }))
			{
				ArrayList c12 = Struct17.smethod_2(interface42_, class787_0, class10, rectangle_, num11, num9);
				arrayList2.AddRange(c12);
			}
			else if (class10.method_24(new ChartType_Chart[1] { ChartType_Chart.Area100PercentStacked }))
			{
				ArrayList c13 = Struct17.smethod_4(interface42_, class787_0, class10, rectangle_, num11, num9);
				arrayList2.AddRange(c13);
			}
			else if (class10.method_25(new ChartType_Chart[2]
			{
				ChartType_Chart.Pie,
				ChartType_Chart.Doughnut
			}) && !flag4)
			{
				Struct35.smethod_0(interface42_, rectangle_, class10);
				flag4 = true;
			}
			else if (class10.method_36())
			{
				ArrayList c14 = Struct36.smethod_0(interface42_, class10, rectangle_, num9);
				arrayList4.AddRange(c14);
			}
			else if (class10.method_24(new ChartType_Chart[2]
			{
				ChartType_Chart.Bubble,
				ChartType_Chart.Bubble3D
			}))
			{
				ArrayList c15 = Struct21.smethod_0(interface42_, class10, rectangle_, num11, num12, num9);
				arrayList2.AddRange(c15);
			}
		}
		for (int m = 0; m < list.Count; m++)
		{
			Class810 class11 = (Class810)list[m];
			Struct40.smethod_0(interface42_, class11.method_4(), class11.method_22(), rectangle_);
			Struct40.smethod_0(interface42_, class11.method_5(), class11.method_22(), rectangle_);
		}
		for (int n = 0; n < list.Count; n++)
		{
			Class810 class12 = (Class810)list[n];
			if (class12.method_21() == Enum53.const_0)
			{
				num9 = num;
				num10 = num3;
				num12 = crossAt;
				num11 = num5;
			}
			else
			{
				num9 = num2;
				num10 = num4;
				num12 = crossAt2;
				num11 = num6;
			}
			if (class12.method_11().Count > 0)
			{
				if (class12.method_22() != ChartType_Chart.Bar && class12.method_22() != ChartType_Chart.BarStacked && class12.method_22() != ChartType_Chart.Bar100PercentStacked)
				{
					Struct39.smethod_1(interface42_, class12, rectangle_, num11, num12);
				}
				else
				{
					Struct39.smethod_5(interface42_, class12, rectangle_, num10, num12);
				}
			}
		}
		Struct25.smethod_4(interface42_, class787_0, arrayList);
		Struct25.smethod_19(interface42_, class787_0, arrayList2);
		Struct20.smethod_2(interface42_, class787_0, rectangle_, arrayList3);
		Struct36.smethod_1(interface42_, class787_0, arrayList4);
		if (class787_0.method_12().IsVisible)
		{
			Struct38.smethod_0(class787_0, class787_0.method_12());
		}
		if (class787_0.method_3().method_1().method_3())
		{
			class787_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
		}
		if (class5.method_36())
		{
			Struct19.smethod_17(interface42_, class2, class787_0.method_1(), rectangle_);
		}
		else if (class787_0.method_1().IsVisible)
		{
			if (flag)
			{
				Struct19.smethod_11(interface42_, class787_0.method_1(), class787_0.method_9().IsPlotOrderReversed, num3, rectangle_, num);
			}
			else if (class5.method_38())
			{
				Struct19.smethod_16(interface42_, class787_0.method_1(), class787_0.method_9().IsPlotOrderReversed, num5, rectangle_, class5);
			}
			else
			{
				Struct19.smethod_5(interface42_, class787_0.method_1(), class787_0.method_9().IsPlotOrderReversed, num5, rectangle_, num, flag);
			}
		}
		if (class6.method_36())
		{
			Struct19.smethod_17(interface42_, class3, class787_0.method_2(), rectangle_);
		}
		else if (class787_0.method_2().IsVisible)
		{
			if (flag2)
			{
				Struct19.smethod_11(interface42_, class787_0.method_2(), class787_0.method_10().IsPlotOrderReversed, num4, rectangle_, num2);
			}
			else if (class6.method_38())
			{
				Struct19.smethod_16(interface42_, class787_0.method_2(), class787_0.method_10().IsPlotOrderReversed, num6, rectangle_, class6);
			}
			else
			{
				Struct19.smethod_5(interface42_, class787_0.method_2(), class787_0.method_10().IsPlotOrderReversed, num6, rectangle_, num2, flag2);
			}
		}
		if (class787_0.method_9().IsVisible)
		{
			if (flag)
			{
				Struct19.smethod_9(interface42_, class787_0.method_9(), class787_0.method_1().IsPlotOrderReversed, float_, rectangle_, class5);
			}
			else if (class5.method_36())
			{
				Struct19.smethod_18(interface42_, class2, class787_0.method_9(), rectangle_);
			}
			else
			{
				Struct19.smethod_2(interface42_, class787_0.method_9(), class787_0.method_1().IsPlotOrderReversed, num7, rectangle_, class5);
			}
		}
		if (class787_0.method_10().IsVisible)
		{
			if (flag2)
			{
				Struct19.smethod_9(interface42_, class787_0.method_10(), class787_0.method_2().IsPlotOrderReversed, float_2, rectangle_, class6);
			}
			else if (class6.method_36())
			{
				Struct19.smethod_18(interface42_, class3, class787_0.method_10(), rectangle_);
			}
			else
			{
				Struct19.smethod_2(interface42_, class787_0.method_10(), class787_0.method_1().IsPlotOrderReversed, num8, rectangle_, class6);
			}
		}
		if (class787_0.method_3().method_1().method_3())
		{
			class787_0.imethod_0().imethod_57(textRenderingHint_);
		}
		for (int num13 = 0; num13 < list.Count; num13++)
		{
			Class810 class810_ = (Class810)list[num13];
			Struct39.smethod_20(interface42_, class810_);
		}
		if (class787_0.method_1().method_10().IsVisible)
		{
			class787_0.method_1().method_10().method_0()
				.method_11(class787_0.method_8().rectangle_0.Height);
			class787_0.method_1().method_10().method_0()
				.method_10(class787_0.method_8().rectangle_0.Width);
			Struct38.smethod_0(class787_0, class787_0.method_1().method_10());
		}
		if (class787_0.method_9().method_10().IsVisible)
		{
			class787_0.method_9().method_10().method_0()
				.method_11(class787_0.method_8().rectangle_0.Height);
			class787_0.method_9().method_10().method_0()
				.method_10(class787_0.method_8().rectangle_0.Width);
			Struct38.smethod_0(class787_0, class787_0.method_9().method_10());
		}
		if (class787_0.method_2().method_10().IsVisible && class3.Count > 0)
		{
			class787_0.method_2().method_10().method_0()
				.method_11(class787_0.method_8().rectangle_0.Height);
			class787_0.method_2().method_10().method_0()
				.method_10(class787_0.method_8().rectangle_0.Width);
			Struct38.smethod_0(class787_0, class787_0.method_2().method_10());
		}
		if (class787_0.method_10().method_10().IsVisible && class3.Count > 0)
		{
			class787_0.method_10().method_10().method_0()
				.method_11(class787_0.method_8().rectangle_0.Height);
			class787_0.method_10().method_10().method_0()
				.method_10(class787_0.method_8().rectangle_0.Width);
			Struct38.smethod_0(class787_0, class787_0.method_10().method_10());
		}
		if (class787_0.IsDataTableShown)
		{
			if (class787_0.method_3().method_1().method_3())
			{
				class787_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
			}
			if (smethod_64(class787_0.method_1()) || smethod_66(class787_0.Type))
			{
				class787_0.method_4().rectangle_0.X = class787_0.method_8().rectangle_0.X;
				class787_0.method_4().rectangle_0.Width = class787_0.method_8().rectangle_0.Width;
			}
			else
			{
				class787_0.method_4().rectangle_0.X = class787_0.method_8().rectangle_0.X;
				class787_0.method_4().rectangle_0.Y = class787_0.method_8().rectangle_0.Bottom;
				class787_0.method_4().rectangle_0.Width = class787_0.method_8().rectangle_0.Width;
			}
			Struct23.smethod_0(interface42_, class787_0.method_4(), flag);
			if (class787_0.method_3().method_1().method_3())
			{
				class787_0.imethod_0().imethod_57(textRenderingHint_);
			}
		}
		bool bool_ = class787_0.method_6().bool_0;
		if (!class787_0.IsLegendShown)
		{
			return;
		}
		if (class787_0.method_3().method_1().method_3() && class787_0.method_6().method_0().method_1()
			.method_3())
		{
			class787_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
		}
		if (class3.Count == 0 && (class5.method_22() == ChartType_Chart.Pie || class5.method_22() == ChartType_Chart.Doughnut || bool_))
		{
			Class810 class13 = class5;
			if (class5.Type == ChartType_Chart.Doughnut || class5.Type == ChartType_Chart.DoughnutExploded)
			{
				for (int num14 = 1; num14 < class787_0.method_7().Count; num14++)
				{
					if (class787_0.method_7()[num14].Points != null && class13.method_10() != null && class787_0.method_7()[num14].Points.Count > class13.method_10().Count)
					{
						class13 = class787_0.method_7().method_9(num14);
					}
				}
			}
			Struct28.smethod_11(interface42_, class787_0.method_6(), class13);
		}
		else
		{
			Struct28.smethod_27(interface42_, class787_0.method_6(), flag, class5);
		}
		if (class787_0.method_3().method_1().method_3() && class787_0.method_6().method_0().method_1()
			.method_3())
		{
			class787_0.imethod_0().imethod_57(textRenderingHint_);
		}
	}

	internal static string smethod_1(Class787 class787_0)
	{
		Class808 @class = class787_0.method_7();
		Class808 class2 = new Class808(class787_0);
		Class808 class3 = new Class808(class787_0);
		foreach (Class810 item in @class)
		{
			if (item.method_21() == Enum53.const_0)
			{
				class2.Add(item);
			}
			else
			{
				class3.Add(item);
			}
		}
		if (class2.Count == 0)
		{
			return "Plot series are all on secondary axis. Must set one or more of Plot series on primary axis!";
		}
		smethod_2(@class);
		new Class810(class787_0, null, ChartType_Chart.Column);
		if (class3.Count > 0)
		{
			class3.method_9(0);
		}
		else
		{
			class787_0.method_2().IsVisible = false;
			class787_0.method_2().method_10().Text = "";
			class787_0.method_10().IsVisible = false;
			class787_0.method_10().method_10().Text = "";
		}
		return "";
	}

	private static void smethod_2(Class808 class808_0)
	{
		foreach (Class810 item in class808_0)
		{
			item.method_23(item.Type);
			switch (item.Type)
			{
			case ChartType_Chart.Bar:
				item.method_23(ChartType_Chart.Bar);
				break;
			case ChartType_Chart.BarStacked:
				item.method_23(ChartType_Chart.BarStacked);
				break;
			case ChartType_Chart.Bar100PercentStacked:
				item.method_23(ChartType_Chart.Bar100PercentStacked);
				break;
			case ChartType_Chart.Bar3DStacked:
				item.method_23(ChartType_Chart.Bar3DStacked);
				break;
			case ChartType_Chart.Bar3D100PercentStacked:
				item.method_23(ChartType_Chart.Bar3D100PercentStacked);
				break;
			case ChartType_Chart.Bubble:
			case ChartType_Chart.Bubble3D:
				item.method_23(ChartType_Chart.Bubble);
				break;
			case ChartType_Chart.Column3DStacked:
				item.method_23(ChartType_Chart.Column3DStacked);
				break;
			case ChartType_Chart.Column3D100PercentStacked:
				item.method_23(ChartType_Chart.Column3D100PercentStacked);
				break;
			case ChartType_Chart.Area:
			case ChartType_Chart.Column:
			case ChartType_Chart.Line:
			case ChartType_Chart.LineWithDataMarkers:
				item.method_23(ChartType_Chart.Column);
				break;
			case ChartType_Chart.AreaStacked:
			case ChartType_Chart.ColumnStacked:
			case ChartType_Chart.LineStacked:
			case ChartType_Chart.LineStackedWithDataMarkers:
				item.method_23(ChartType_Chart.ColumnStacked);
				break;
			case ChartType_Chart.Area100PercentStacked:
			case ChartType_Chart.Column100PercentStacked:
			case ChartType_Chart.Line100PercentStacked:
			case ChartType_Chart.Line100PercentStackedWithDataMarkers:
				item.method_23(ChartType_Chart.Column100PercentStacked);
				break;
			case ChartType_Chart.Doughnut:
			case ChartType_Chart.DoughnutExploded:
			case ChartType_Chart.Pie3DExploded:
				item.method_23(ChartType_Chart.Doughnut);
				break;
			case ChartType_Chart.Pie:
			case ChartType_Chart.Pie3D:
			case ChartType_Chart.PiePie:
			case ChartType_Chart.PieExploded:
			case ChartType_Chart.PieBar:
				item.method_23(ChartType_Chart.Pie);
				break;
			case ChartType_Chart.Radar:
			case ChartType_Chart.RadarWithDataMarkers:
				item.method_23(ChartType_Chart.Radar);
				break;
			case ChartType_Chart.RadarFilled:
				item.method_23(ChartType_Chart.RadarFilled);
				break;
			case ChartType_Chart.Scatter:
			case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
			case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
			case ChartType_Chart.ScatterConnectedByLinesWithDataMarker:
			case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
				item.method_23(ChartType_Chart.Scatter);
				break;
			}
		}
	}

	private static void smethod_3(Class787 class787_0, Class808 class808_0, Class808 class808_1)
	{
		Class808 @class = class787_0.method_7();
		foreach (Class810 item in @class)
		{
			if (item.method_22() != ChartType_Chart.Scatter && item.method_22() != ChartType_Chart.Bubble)
			{
				item.method_5().DisplayType = Enum68.const_2;
			}
			switch (item.method_22())
			{
			case ChartType_Chart.Bubble:
				if (item.method_21() == Enum53.const_0)
				{
					class787_0.method_1().AxisBetweenCategories = false;
				}
				else
				{
					class787_0.method_2().AxisBetweenCategories = false;
				}
				break;
			case ChartType_Chart.Radar:
			case ChartType_Chart.RadarFilled:
				class787_0.IsDataTableShown = false;
				if (item.method_21() == Enum53.const_0)
				{
					class787_0.method_1().CategoryType = Enum64.const_1;
					class787_0.method_1().method_10().Text = "";
					class787_0.method_9().method_10().Text = "";
					class787_0.method_1().method_7().Formatting = Enum71.const_0;
					class787_0.method_1().method_8().Formatting = Enum71.const_0;
				}
				else
				{
					class787_0.method_2().CategoryType = Enum64.const_1;
					class787_0.method_2().method_10().Text = "";
					class787_0.method_10().method_10().Text = "";
					class787_0.method_2().method_7().Formatting = Enum71.const_0;
					class787_0.method_2().method_8().Formatting = Enum71.const_0;
				}
				break;
			case ChartType_Chart.Doughnut:
			case ChartType_Chart.Pie:
				if (item.method_12())
				{
					item.IsColorVaried = true;
				}
				class787_0.IsDataTableShown = false;
				if (item.method_21() == Enum53.const_0)
				{
					class787_0.method_1().IsVisible = false;
					class787_0.method_1().method_10().Text = "";
					class787_0.method_9().IsVisible = false;
					class787_0.method_9().method_10().Text = "";
					class787_0.method_1().method_7().Formatting = Enum71.const_0;
					class787_0.method_1().method_8().Formatting = Enum71.const_0;
					class787_0.method_9().method_7().Formatting = Enum71.const_0;
					class787_0.method_9().method_8().Formatting = Enum71.const_0;
				}
				else
				{
					class787_0.method_2().IsVisible = false;
					class787_0.method_2().method_10().Text = "";
					class787_0.method_10().IsVisible = false;
					class787_0.method_10().method_10().Text = "";
					class787_0.method_2().method_7().Formatting = Enum71.const_0;
					class787_0.method_2().method_8().Formatting = Enum71.const_0;
					class787_0.method_10().method_7().Formatting = Enum71.const_0;
					class787_0.method_10().method_8().Formatting = Enum71.const_0;
				}
				break;
			}
		}
		if (class787_0.method_1().bool_13)
		{
			smethod_4(@class, class787_0.method_1());
			class787_0.method_2().bool_12 = class787_0.method_1().bool_12;
			class787_0.method_2().AxisBetweenCategories = class787_0.method_1().AxisBetweenCategories;
		}
		else
		{
			smethod_4(class808_0, class787_0.method_1());
			smethod_4(class808_1, class787_0.method_2());
		}
	}

	private static void smethod_4(Class808 class808_0, Class789 class789_0)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (Class810 item in class808_0)
		{
			if (item.method_22() == ChartType_Chart.Scatter)
			{
				flag = true;
			}
			else
			{
				flag2 = true;
			}
		}
		if (flag && !flag2)
		{
			class789_0.AxisBetweenCategories = false;
		}
		if (flag && flag2)
		{
			class789_0.bool_12 = true;
		}
	}

	internal static void smethod_5(Class787 class787_0)
	{
		if (class787_0.method_8().method_1().Formatting == Enum71.const_1)
		{
			class787_0.method_15();
		}
		Class808 @class = class787_0.method_7();
		for (int i = 0; i < @class.Count; i++)
		{
			Class810 class2 = @class.method_9(i);
			int num = class2.vmethod_5();
			ChartType_Chart type = class2.Type;
			bool flag = class2.method_27();
			Color color = class787_0.method_14(class2.vmethod_7()).GetColor(num);
			int num2 = num;
			if (!class2.vmethod_7())
			{
				num2 += 8;
			}
			Color color2 = class787_0.method_14(class2.vmethod_7()).GetColor(num2);
			Color color3 = color2;
			class2.method_7().method_1(color);
			if (class2.vmethod_7())
			{
				if ((class2.method_6().Formatting == Enum71.const_1 || (class2.method_6().vmethod_0() && class2.method_6().Formatting != 0)) && (type == ChartType_Chart.Line || type == ChartType_Chart.LineStacked || type == ChartType_Chart.Line100PercentStacked || type == ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker || type == ChartType_Chart.Radar))
				{
					class2.method_6().method_0(color2);
				}
				if (flag)
				{
					if (class2.method_8().MarkerStyle != Enum65.const_5)
					{
						class2.method_8().method_1().method_0(Color.Black);
						class2.method_8().method_0().method_1(color3);
					}
					class2.method_8().MarkerStyle = Enum65.const_7;
				}
			}
			else
			{
				if ((class2.method_6().Formatting == Enum71.const_1 || (class2.method_6().vmethod_0() && class2.method_6().Formatting != 0)) && (type == ChartType_Chart.Line || type == ChartType_Chart.Line100PercentStacked || type == ChartType_Chart.Line100PercentStackedWithDataMarkers || type == ChartType_Chart.LineStacked || type == ChartType_Chart.LineStackedWithDataMarkers || type == ChartType_Chart.LineWithDataMarkers || type == ChartType_Chart.Scatter || type == ChartType_Chart.ScatterConnectedByLinesWithDataMarker || type == ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker || type == ChartType_Chart.Radar || type == ChartType_Chart.RadarWithDataMarkers))
				{
					class2.method_6().method_0(color2);
				}
				if (flag)
				{
					if (class2.method_8().MarkerStyle == Enum65.const_0)
					{
						class2.method_8().method_1().method_0(color3);
						if (num % 9 != 3 && num % 9 != 4 && num % 9 != 6 && num % 9 != 7 && num % 9 != 8)
						{
							class2.method_8().method_0().method_1(color3);
						}
						else
						{
							class2.method_8().method_0().method_1(Color.Empty);
						}
					}
					else if (class2.method_8().MarkerStyle != Enum65.const_5)
					{
						class2.method_8().method_1().method_0(color3);
						if (class2.method_8().MarkerStyle != Enum65.const_10 && class2.method_8().MarkerStyle != Enum65.const_8 && class2.method_8().MarkerStyle != Enum65.const_6 && class2.method_8().MarkerStyle != Enum65.const_4 && class2.method_8().MarkerStyle != Enum65.const_2)
						{
							class2.method_8().method_0().method_1(color3);
						}
						else
						{
							class2.method_8().method_0().method_1(Color.Empty);
						}
					}
					if (class2.method_8().MarkerStyle == Enum65.const_0)
					{
						class2.method_8().MarkerStyle = Struct28.smethod_7(class2, num);
					}
				}
			}
			bool flag2 = false;
			if (class2.Type == ChartType_Chart.Pie || class2.Type == ChartType_Chart.Pie3D || class2.Type == ChartType_Chart.Pie3DExploded || class2.Type == ChartType_Chart.PieBar || class2.Type == ChartType_Chart.PieExploded || class2.Type == ChartType_Chart.PiePie || class2.Type == ChartType_Chart.Doughnut || class2.Type == ChartType_Chart.DoughnutExploded)
			{
				flag2 = true;
			}
			Class795 class3 = class2.method_10();
			for (int j = 0; j < class3.Count; j++)
			{
				Class796 class4 = class3.method_1(j);
				int num3 = j;
				if (class4 == null)
				{
					continue;
				}
				if ((flag2 && class2.IsColorVaried) || (!flag2 && class2.IsColorVaried && @class.Count == 1))
				{
					Color color4 = class787_0.method_14(class2.vmethod_7()).GetColor(num3);
					int num4 = num3;
					if (!class2.vmethod_7())
					{
						num4 += 8;
					}
					Color color5 = class787_0.method_14(class2.vmethod_7()).GetColor(num4);
					Color color6 = color5;
					class4.method_3().method_1(color4);
					if (class2.vmethod_7())
					{
						if ((class4.method_4().Formatting == Enum71.const_1 || (class4.method_4().vmethod_0() && class4.method_4().Formatting != 0)) && (type == ChartType_Chart.Line || type == ChartType_Chart.LineStacked || type == ChartType_Chart.Line100PercentStacked || type == ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker || type == ChartType_Chart.Radar))
						{
							class4.method_4().method_0(color5);
						}
						if (flag)
						{
							if (class4.method_5().MarkerStyle != Enum65.const_5)
							{
								class4.method_5().method_1().method_0(color6);
								class4.method_5().method_0().method_1(Color.Black);
							}
							class4.method_5().MarkerStyle = Enum65.const_7;
						}
						continue;
					}
					if ((class4.method_4().Formatting == Enum71.const_1 || (class4.method_4().vmethod_0() && class4.method_4().Formatting != 0)) && (type == ChartType_Chart.Line || type == ChartType_Chart.Line100PercentStacked || type == ChartType_Chart.Line100PercentStackedWithDataMarkers || type == ChartType_Chart.LineStacked || type == ChartType_Chart.LineStackedWithDataMarkers || type == ChartType_Chart.LineWithDataMarkers || type == ChartType_Chart.Scatter || type == ChartType_Chart.ScatterConnectedByCurvesWithDataMarker || type == ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker || type == ChartType_Chart.Radar || type == ChartType_Chart.RadarFilled || type == ChartType_Chart.RadarWithDataMarkers))
					{
						class4.method_4().method_0(color5);
					}
					if (!flag)
					{
						continue;
					}
					if (class4.method_5().MarkerStyle == Enum65.const_0)
					{
						class4.method_5().method_1().method_0(color6);
						if (num3 % 9 != 3 && num3 % 9 != 4 && num3 % 9 != 6 && num3 % 9 != 7 && num3 % 9 != 8)
						{
							class4.method_5().method_0().method_1(color6);
						}
						else
						{
							class4.method_5().method_0().method_1(Color.Empty);
						}
					}
					else if (class4.method_5().MarkerStyle != Enum65.const_5)
					{
						class4.method_5().method_1().method_0(color3);
						if (class4.method_5().MarkerStyle != Enum65.const_10 && class4.method_5().MarkerStyle != Enum65.const_8 && class4.method_5().MarkerStyle != Enum65.const_6 && class4.method_5().MarkerStyle != Enum65.const_4 && class4.method_5().MarkerStyle != Enum65.const_2)
						{
							class4.method_5().method_0().method_1(color3);
						}
						else
						{
							class4.method_5().method_0().method_1(Color.Empty);
						}
					}
					if (class4.method_5().MarkerStyle == Enum65.const_0)
					{
						class4.method_5().MarkerStyle = Struct28.smethod_7(class2, num3);
					}
					continue;
				}
				class4.method_3().method_1(color);
				if (class2.vmethod_7())
				{
					if ((class4.method_4().Formatting == Enum71.const_1 || (class4.method_4().vmethod_0() && class4.method_4().Formatting != 0)) && (type == ChartType_Chart.Line || type == ChartType_Chart.LineStacked || type == ChartType_Chart.Line100PercentStacked || type == ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker || type == ChartType_Chart.Radar))
					{
						class4.method_4().method_0(color2);
					}
					if (flag)
					{
						if (class4.method_5().MarkerStyle != Enum65.const_5)
						{
							class4.method_5().method_1().method_0(Color.Black);
							class4.method_5().method_0().method_1(color3);
						}
						class4.method_5().MarkerStyle = Enum65.const_7;
					}
					continue;
				}
				if ((class4.method_4().Formatting == Enum71.const_1 || (class4.method_4().vmethod_0() && class4.method_4().Formatting != 0)) && (type == ChartType_Chart.Line || type == ChartType_Chart.Line100PercentStacked || type == ChartType_Chart.Line100PercentStackedWithDataMarkers || type == ChartType_Chart.LineStacked || type == ChartType_Chart.LineStackedWithDataMarkers || type == ChartType_Chart.LineWithDataMarkers || type == ChartType_Chart.Scatter || type == ChartType_Chart.ScatterConnectedByCurvesWithDataMarker || type == ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithDataMarker || type == ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker || type == ChartType_Chart.Radar || type == ChartType_Chart.RadarFilled || type == ChartType_Chart.RadarWithDataMarkers))
				{
					class4.method_4().method_0(color2);
				}
				if (!flag)
				{
					continue;
				}
				if (class4.method_5().MarkerStyle == Enum65.const_0)
				{
					class4.method_5().method_1().method_0(color3);
					if (num % 9 != 3 && num % 9 != 4 && num % 9 != 6 && num % 9 != 7 && num % 9 != 8)
					{
						class4.method_5().method_0().method_1(color3);
					}
					else
					{
						class4.method_5().method_0().method_1(Color.Empty);
					}
				}
				else if (class4.method_5().MarkerStyle != Enum65.const_5)
				{
					class4.method_5().method_1().method_0(color3);
					if (class4.method_5().MarkerStyle != Enum65.const_10 && class4.method_5().MarkerStyle != Enum65.const_8 && class4.method_5().MarkerStyle != Enum65.const_6 && class4.method_5().MarkerStyle != Enum65.const_4 && class4.method_5().MarkerStyle != Enum65.const_2)
					{
						class4.method_5().method_0().method_1(color3);
					}
					else
					{
						class4.method_5().method_0().method_1(Color.Empty);
					}
				}
				if (class4.method_5().MarkerStyle == Enum65.const_0)
				{
					class4.method_5().MarkerStyle = Struct28.smethod_7(class2, num);
				}
			}
		}
	}

	internal static void smethod_6(Class787 class787_0)
	{
		smethod_7(class787_0.method_1());
		smethod_7(class787_0.method_9());
		smethod_7(class787_0.method_2());
		smethod_7(class787_0.method_10());
		smethod_7(class787_0.method_11());
	}

	private static void smethod_7(Class789 class789_0)
	{
		Class811 @class = class789_0.method_9();
		class789_0.method_19(((int)@class.Font.Size - 1) / 3 + 1);
		class789_0.method_21((int)((float)class789_0.method_18() * 0.7f + 0.5f));
		if (class789_0.method_20() == class789_0.method_18())
		{
			class789_0.method_21(class789_0.method_18() - 1);
		}
		if (class789_0.method_20() < 1)
		{
			class789_0.method_21(1);
		}
	}

	internal static bool smethod_8(ChartType_Chart chartType_Chart_0)
	{
		switch (chartType_Chart_0)
		{
		default:
			return false;
		case ChartType_Chart.Bar:
		case ChartType_Chart.BarStacked:
		case ChartType_Chart.Bar100PercentStacked:
		case ChartType_Chart.Bar3DClustered:
		case ChartType_Chart.Bar3DStacked:
		case ChartType_Chart.Bar3D100PercentStacked:
		case ChartType_Chart.ConicalBar:
		case ChartType_Chart.ConicalBarStacked:
		case ChartType_Chart.ConicalBar100PercentStacked:
		case ChartType_Chart.CylindricalBar:
		case ChartType_Chart.CylindricalBarStacked:
		case ChartType_Chart.CylindricalBar100PercentStacked:
		case ChartType_Chart.PyramidBar:
		case ChartType_Chart.PyramidBarStacked:
		case ChartType_Chart.PyramidBar100PercentStacked:
			return true;
		}
	}

	private static void smethod_9(Class789 class789_0, bool bool_0)
	{
		_ = class789_0.Chart;
		if (class789_0.method_3() == Enum61.const_1 || class789_0.method_3() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0 && class789_0.method_10().bool_0)
		{
			class789_0.method_10().Rotation = 90;
		}
	}

	private static void smethod_10(Class789 class789_0, bool bool_0)
	{
		_ = class789_0.Chart;
		if (class789_0.method_3() == Enum61.const_1 || class789_0.method_3() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0 && class789_0.method_11().method_0())
		{
			class789_0.method_11().Rotation = 90;
		}
	}

	private static void smethod_11(Class789 class789_0, ref Rectangle rectangle_0, bool bool_0, Size size_0)
	{
		Size size = new Size(size_0.Width, size_0.Height);
		_ = class789_0.Chart;
		if (class789_0.method_3() == Enum61.const_1 || class789_0.method_3() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0)
		{
			if (class789_0.bool_10)
			{
				class789_0.method_10().method_0().rectangle_1.X = rectangle_0.X;
				rectangle_0.X += size.Width + int_1;
				rectangle_0.Width -= size.Width + int_1;
			}
			else
			{
				class789_0.method_10().method_0().rectangle_1.X = rectangle_0.Right - size.Width;
				rectangle_0.Width -= size.Width + int_1;
			}
		}
		else if (class789_0.bool_10)
		{
			class789_0.method_10().method_0().rectangle_1.Y = rectangle_0.Bottom - size.Height;
			rectangle_0.Height -= size.Height + int_1;
		}
		else
		{
			class789_0.method_10().method_0().rectangle_1.Y = rectangle_0.Y;
			rectangle_0.Y += size.Height + int_1;
			rectangle_0.Height -= size.Height + int_1;
		}
		class789_0.method_10().method_0().rectangle_1.Size = size;
	}

	private static void smethod_12(Class789 class789_0, Rectangle rectangle_0, bool bool_0)
	{
		Size size = new Size(class789_0.method_10().method_0().rectangle_1.Size.Width, class789_0.method_10().method_0().rectangle_1.Size.Height);
		Class787 chart = class789_0.Chart;
		if (class789_0.method_3() == Enum61.const_1 || class789_0.method_3() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0)
		{
			if (class789_0.bool_10)
			{
				if (!class789_0.method_10().method_0().imethod_0())
				{
					class789_0.method_10().method_0().rectangle_1.X = rectangle_0.X - size.Width - int_0;
				}
				else if (rectangle_0.X >= size.Width + int_0)
				{
					class789_0.method_10().method_0().rectangle_1.X = rectangle_0.X - size.Width;
				}
				else
				{
					class789_0.method_10().method_0().rectangle_1.X = rectangle_0.X - size.Width;
				}
			}
			else if (chart.Width - rectangle_0.Right < size.Width + int_0 && class789_0.method_10().method_0().imethod_0())
			{
				class789_0.method_10().method_0().rectangle_1.X = chart.Width - size.Width - int_0;
			}
			else
			{
				class789_0.method_10().method_0().rectangle_1.X = rectangle_0.Right;
			}
		}
		else if (class789_0.bool_10)
		{
			if (chart.Height - rectangle_0.Bottom < size.Height + int_0 && class789_0.method_10().method_0().vmethod_2())
			{
				class789_0.method_10().method_0().rectangle_1.Y = chart.Height - size.Height - int_0;
			}
			else
			{
				class789_0.method_10().method_0().rectangle_1.Y = rectangle_0.Bottom;
			}
		}
		else if (rectangle_0.Y < size.Height + int_0 && class789_0.method_10().method_0().vmethod_2())
		{
			class789_0.method_10().method_0().rectangle_1.Y = size.Height + int_0;
		}
		else
		{
			class789_0.method_10().method_0().rectangle_1.Y = rectangle_0.Y - size.Height;
		}
	}

	private static void smethod_13(Class789 class789_0, bool bool_0)
	{
		Class787 chart = class789_0.Chart;
		if (class789_0.method_3() == Enum61.const_1 || class789_0.method_3() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0)
		{
			class789_0.method_10().method_0().rectangle_1.Y = chart.method_8().rectangle_1.Y + (chart.method_8().rectangle_1.Height - class789_0.method_10().method_0().rectangle_1.Height) / 2;
		}
		else
		{
			class789_0.method_10().method_0().rectangle_1.X = chart.method_8().rectangle_1.X + (chart.method_8().rectangle_1.Width - class789_0.method_10().method_0().rectangle_1.Width) / 2;
		}
	}

	internal static float smethod_14(Class789 class789_0, int int_4, int int_5, bool bool_0)
	{
		float num = 0f;
		bool flag = (bool_0 ? ((!class789_0.IsPlotOrderReversed) ? true : false) : (class789_0.IsPlotOrderReversed ? true : false));
		double num2 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.CrossAt) : class789_0.CrossAt);
		double num3 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.MaxValue) : class789_0.MaxValue);
		double num4 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.MinValue) : class789_0.MinValue);
		if (class789_0.CrossType == Enum66.const_1)
		{
			num2 = num3;
		}
		if (num2 > num3)
		{
			num2 = num3;
		}
		if (num2 < num4)
		{
			num2 = num4;
		}
		class789_0.CrossAt = (class789_0.IsLogarithmic ? Struct40.smethod_8(num2) : num2);
		if (!flag)
		{
			return (float)((double)int_4 + (num3 - num2) / (num3 - num4) * (double)int_5);
		}
		return (float)((double)int_4 + (num2 - num4) / (num3 - num4) * (double)int_5);
	}

	internal static float smethod_15(Class789 class789_0, int int_4, int int_5, bool bool_0, Class808 class808_0)
	{
		if (class808_0.Count == 0)
		{
			return 0f;
		}
		float num = 0f;
		bool flag = (bool_0 ? ((!class789_0.IsPlotOrderReversed) ? true : false) : (class789_0.IsPlotOrderReversed ? true : false));
		Class787 chart = class789_0.Chart;
		if (class789_0.CategoryType != Enum64.const_2)
		{
			int num2 = smethod_29(class808_0.method_15());
			int num3 = num2;
			if (class789_0.AxisBetweenCategories || chart.IsDataTableShown)
			{
				num3++;
			}
			int num4 = 1;
			if (num3 <= 1)
			{
				num3 = 2;
			}
			double num5 = class789_0.CrossAt;
			if (class789_0.CrossType == Enum66.const_1)
			{
				num5 = num3;
			}
			if (num5 > (double)num3)
			{
				num5 = num3;
			}
			else if (num5 < (double)num4)
			{
				num5 = num4;
			}
			if (class808_0.method_9(0).method_38())
			{
				num5 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.CrossAt) : class789_0.CrossAt);
				double num6 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.MaxValue) : class789_0.MaxValue);
				double num7 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.MinValue) : class789_0.MinValue);
				if (class789_0.CrossType == Enum66.const_1)
				{
					num5 = num6;
				}
				if (num5 > num6)
				{
					num5 = num6;
				}
				if (num5 < num7)
				{
					num5 = num7;
				}
				class789_0.CrossAt = (class789_0.IsLogarithmic ? Struct40.smethod_8(num5) : num5);
				if (flag)
				{
					return (float)((double)int_4 + (num6 - num5) / (num6 - num7) * (double)int_5);
				}
				return (float)((double)int_4 + (num5 - num7) / (num6 - num7) * (double)int_5);
			}
			class789_0.CrossAt = num5;
			if (flag)
			{
				return (float)((double)int_4 + ((double)num3 - num5) / (double)(num3 - num4) * (double)int_5);
			}
			return (float)((double)int_4 + (num5 - (double)num4) / (double)(num3 - num4) * (double)int_5);
		}
		Enum87 baseUnitScale = class789_0.BaseUnitScale;
		int num8 = (int)class789_0.MaxValue;
		int num9 = (int)class789_0.MinValue;
		int num10 = 0;
		if (!class789_0.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num10 = Struct19.smethod_29(baseUnitScale, num8, num9, class789_0.Chart.vmethod_0());
			if (num10 == 0)
			{
				num10 = 1;
			}
		}
		else
		{
			num8 = Struct19.smethod_31(baseUnitScale, baseUnitScale, 1, num8, chart.vmethod_0());
			num10 = Struct19.smethod_29(baseUnitScale, num8, num9, class789_0.Chart.vmethod_0());
		}
		int num11 = Struct19.smethod_32(baseUnitScale, (int)class789_0.CrossAt, chart.vmethod_0());
		if (class789_0.CrossType == Enum66.const_1)
		{
			num11 = num8;
		}
		if (num11 > num8)
		{
			num11 = num8;
		}
		else if (num11 < num9)
		{
			num11 = num9;
		}
		class789_0.CrossAt = num11;
		if (flag)
		{
			return (float)(int_4 + int_5) - (float)Struct19.smethod_29(baseUnitScale, num11, num9, class789_0.Chart.vmethod_0()) / (float)num10 * (float)int_5;
		}
		return (float)int_4 + (float)Struct19.smethod_29(baseUnitScale, num11, num9, class789_0.Chart.vmethod_0()) / (float)num10 * (float)int_5;
	}

	private static void smethod_16(Class789 class789_0, Class789 class789_1, Class808 class808_0, Class787 class787_0)
	{
		ChartType_Chart chartType_Chart_ = class808_0.method_9(0).method_22();
		switch (class789_0.TickLabelPosition)
		{
		case Enum83.const_0:
			class789_0.int_4 = 2;
			if (class789_1.IsPlotOrderReversed)
			{
				class789_0.int_4 = 1;
			}
			break;
		case Enum83.const_1:
			class789_0.int_4 = 1;
			if (class789_1.IsPlotOrderReversed)
			{
				class789_0.int_4 = 2;
			}
			break;
		case Enum83.const_2:
		{
			class789_0.int_4 = 3;
			if (class789_1.CrossType == Enum66.const_1)
			{
				if (!class789_1.IsPlotOrderReversed)
				{
					class789_0.int_4 = 2;
				}
				else
				{
					class789_0.int_4 = 1;
				}
			}
			else if (class789_1.CrossType == Enum66.const_0)
			{
				if (class789_1.method_3() != Enum61.const_1 && class789_1.method_3() != Enum61.const_3)
				{
					if (class789_1.method_3() == Enum61.const_0 || class789_1.method_3() == Enum61.const_2)
					{
						if (smethod_54(chartType_Chart_))
						{
							class789_1.CrossAt = 0.0;
						}
						else
						{
							class789_1.CrossAt = class789_1.MinValue;
						}
					}
				}
				else
				{
					class789_1.CrossAt = 0.0;
				}
			}
			if (class789_1.CrossType != Enum66.const_2)
			{
				break;
			}
			if (class789_1.CategoryType != Enum64.const_2 && (class789_1.method_3() == Enum61.const_0 || class789_1.method_3() == Enum61.const_2) && class808_0.method_9(0).method_22() != ChartType_Chart.Bubble && class808_0.method_9(0).method_22() != ChartType_Chart.Scatter)
			{
				int num = smethod_29(class808_0.method_15());
				int num2 = num;
				if (class789_1.AxisBetweenCategories || class787_0.IsDataTableShown)
				{
					num2++;
				}
				int num3 = 1;
				if (num2 <= 1)
				{
					num2 = 2;
				}
				double num4 = class789_1.CrossAt;
				if (class789_1.CrossType == Enum66.const_1)
				{
					num4 = num2;
				}
				if (num4 > (double)num2)
				{
					num4 = num2;
				}
				else if (num4 < (double)num3)
				{
					num4 = num3;
				}
				if (!class789_1.IsPlotOrderReversed)
				{
					if (num4 == (double)num3)
					{
						class789_0.int_4 = 1;
					}
				}
				else if (num4 == (double)num3)
				{
					class789_0.int_4 = 2;
				}
				break;
			}
			double minValue = class789_1.MinValue;
			if (class789_1.CrossAt <= minValue)
			{
				if (!class789_1.IsPlotOrderReversed)
				{
					class789_0.int_4 = 1;
				}
				else
				{
					class789_0.int_4 = 2;
				}
			}
			break;
		}
		case Enum83.const_3:
			class789_0.int_4 = 0;
			break;
		}
	}

	private static void smethod_17(Class787 class787_0, Interface42 interface42_0, Class789 class789_0, Size size_0, Size size_1, ref Rectangle rectangle_0, bool bool_0)
	{
		if (bool_0)
		{
			switch (class789_0.int_4)
			{
			case 1:
				rectangle_0.Height -= size_0.Height;
				rectangle_0.Height -= size_1.Height;
				break;
			case 2:
				rectangle_0.Y += size_0.Height;
				rectangle_0.Height -= size_0.Height;
				rectangle_0.Y += size_1.Height;
				rectangle_0.Height -= size_1.Height;
				break;
			case 3:
				if (class787_0.IsDataTableShown)
				{
					rectangle_0.Height -= 5;
				}
				break;
			}
		}
		else
		{
			switch (class789_0.int_4)
			{
			case 1:
			{
				if (!class787_0.IsDataTableShown)
				{
					rectangle_0.X += size_0.Width;
					rectangle_0.Width -= size_0.Width;
					rectangle_0.X += size_1.Width;
					rectangle_0.Width -= size_1.Width;
					break;
				}
				Size size = class787_0.method_4().method_7();
				if (size_0.Width + size_1.Width > size.Width)
				{
					rectangle_0.X += size_0.Width + size_1.Width - size.Width;
					rectangle_0.Width -= size_0.Width + size_1.Width - size.Width;
				}
				break;
			}
			case 2:
				rectangle_0.Width -= size_0.Width;
				rectangle_0.Width -= size_1.Width;
				break;
			}
		}
		Struct40.smethod_20(ref rectangle_0);
	}

	private static void smethod_18(Class787 class787_0, Interface42 interface42_0, Class789 class789_0, Size size_0, int int_4, ref Rectangle rectangle_0, bool bool_0)
	{
		if (bool_0)
		{
			switch (class789_0.int_4)
			{
			case 1:
			{
				if (!class787_0.IsDataTableShown)
				{
					rectangle_0.X += size_0.Width + int_4;
					rectangle_0.Width -= size_0.Width + int_4;
					break;
				}
				Size size = class787_0.method_4().method_7();
				if (size_0.Width + int_4 > size.Width)
				{
					rectangle_0.X += size_0.Width + int_4 - size.Width;
					rectangle_0.Width -= size_0.Width + int_4 - size.Width;
				}
				break;
			}
			case 2:
				rectangle_0.Width -= size_0.Width + int_4;
				break;
			case 3:
				smethod_19(Struct19.smethod_36(class789_0), ref rectangle_0, bool_0, size_0, int_4);
				break;
			}
		}
		else
		{
			if (class787_0.IsDataTableShown && class789_0.CategoryType != Enum64.const_2)
			{
				class789_0.int_4 = 0;
				class789_0.MajorTickMark = Enum84.const_2;
				class789_0.MinorTickMark = Enum84.const_2;
				int_4 = 0;
			}
			switch (class789_0.int_4)
			{
			case 1:
				rectangle_0.Height -= size_0.Height + int_4;
				break;
			case 2:
				if (class787_0.IsDataTableShown && class789_0.CategoryType == Enum64.const_2)
				{
					rectangle_0.Y += size_0.Height + int_4;
					rectangle_0.Height -= size_0.Height + int_4 + int_1;
				}
				else
				{
					rectangle_0.Y += size_0.Height + int_4;
					rectangle_0.Height -= size_0.Height + int_4;
				}
				break;
			case 3:
				if (class787_0.IsDataTableShown && class789_0.CategoryType == Enum64.const_2)
				{
					rectangle_0.Height -= int_1;
				}
				else
				{
					smethod_19(Struct19.smethod_36(class789_0), ref rectangle_0, bool_0, size_0, int_4);
				}
				break;
			}
		}
		Struct40.smethod_20(ref rectangle_0);
	}

	internal static void smethod_19(Class789 class789_0, ref Rectangle rectangle_0, bool bool_0, Size size_0, int int_4)
	{
		Size size = new Size(size_0.Width, size_0.Height);
		size.Width += int_4;
		size.Height += int_4;
		_ = rectangle_0.Y;
		float num = rectangle_0.Height;
		if (bool_0)
		{
			_ = rectangle_0.X;
			num = rectangle_0.Width;
		}
		double num2 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.CrossAt) : class789_0.CrossAt);
		double num3 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.MaxValue) : class789_0.MaxValue);
		double num4 = (class789_0.IsLogarithmic ? Struct40.smethod_7(class789_0.MinValue) : class789_0.MinValue);
		if (class789_0.CrossType == Enum66.const_1)
		{
			num2 = num3;
		}
		if (num2 > num3)
		{
			num2 = num3;
		}
		if (num2 < num4)
		{
			num2 = num4;
		}
		float num5 = (float)((num2 - num4) / (num3 - num4) * (double)num);
		if (bool_0)
		{
			int num6 = 2;
			Rectangle rectangle = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
			while (num6 > 0)
			{
				rectangle_0 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
				int num7 = (int)((float)size.Width - num5);
				if (num7 > 0)
				{
					if (class789_0.IsPlotOrderReversed)
					{
						rectangle_0.Width -= num7;
					}
					else
					{
						rectangle_0.X += num7;
						rectangle_0.Width -= num7;
					}
				}
				num5 = (float)rectangle_0.Width * num5 / (float)rectangle.Width;
				num6--;
			}
			return;
		}
		int num8 = 2;
		Rectangle rectangle2 = new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
		while (num8 > 0)
		{
			rectangle_0 = new Rectangle(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
			int num9 = (int)((float)size.Height - num5);
			if (num9 > 0)
			{
				if (class789_0.IsPlotOrderReversed)
				{
					rectangle_0.Y += num9;
					rectangle_0.Height -= num9;
				}
				else
				{
					rectangle_0.Height -= num9;
				}
			}
			num5 = (float)rectangle_0.Height * num5 / (float)rectangle2.Height;
			num8--;
		}
	}

	private static void smethod_20(Interface42 interface42_0, Class787 class787_0, Class810 class810_0, Class810 class810_1, ref Rectangle rectangle_0)
	{
		ChartType_Chart type = class810_0.Type;
		ChartType_Chart type2 = class810_1.Type;
		if (!class810_0.method_34() && !class810_1.method_34())
		{
			if (!class810_0.method_36() && !class810_1.method_36())
			{
				return;
			}
			SizeF sizeF_ = new SizeF((float)class787_0.Width * 0.3f, class787_0.Height);
			bool flag = class787_0.method_1().TickLabelPosition != Enum83.const_3;
			bool flag2 = class787_0.method_2().TickLabelPosition != Enum83.const_3;
			if (class787_0.method_8().imethod_3())
			{
				rectangle_0.Inflate(-13, -13);
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				if (class810_0.method_36() && flag)
				{
					Size size = Struct37.smethod_3(interface42_0, "a", class787_0.method_1().method_9().Font);
					class787_0.method_1().method_9().method_2(size.Width / 2);
					num3 = class787_0.method_1().method_9().method_1();
					for (int i = 0; i < class787_0.method_1().arrayList_1.Count; i++)
					{
						string string_ = class787_0.method_1().arrayList_1[i].ToString();
						Font font = class787_0.method_1().method_9().Font;
						int rotation = class787_0.method_1().method_9().Rotation;
						Size size2 = Struct37.smethod_0(class787_0.imethod_0(), string_, rotation, font, sizeF_, Enum82.const_1, Enum82.const_1);
						if (size2.Width > num)
						{
							num = size2.Width;
						}
						if (size2.Height > num2)
						{
							num2 = size2.Height;
						}
					}
					class787_0.method_1().float_0 = sizeF_.Width;
					class787_0.method_1().float_1 = sizeF_.Height;
				}
				if (class810_1.method_36() && flag2)
				{
					Size size3 = Struct37.smethod_3(interface42_0, "a", class787_0.method_2().method_9().Font);
					class787_0.method_2().method_9().method_2(size3.Width / 2);
					num4 = class787_0.method_2().method_9().method_1();
					for (int j = 0; j < class787_0.method_2().arrayList_1.Count; j++)
					{
						string string_2 = class787_0.method_2().arrayList_1[j].ToString();
						Font font2 = class787_0.method_2().method_9().Font;
						int rotation2 = class787_0.method_2().method_9().Rotation;
						Size size4 = Struct37.smethod_0(class787_0.imethod_0(), string_2, rotation2, font2, sizeF_, Enum82.const_1, Enum82.const_1);
						if (size4.Width > num)
						{
							num = size4.Width;
						}
						if (size4.Height > num2)
						{
							num2 = size4.Height;
						}
					}
					class787_0.method_2().float_0 = sizeF_.Width;
					class787_0.method_2().float_1 = sizeF_.Height;
				}
				if (num2 > 0)
				{
					if (num3 < num4)
					{
						num3 = num4;
					}
					num2 += num3;
				}
				rectangle_0.Inflate(-num, -num2);
			}
			else
			{
				if (class810_0.method_36() && flag)
				{
					class787_0.method_1().float_0 = sizeF_.Width;
					class787_0.method_1().float_1 = sizeF_.Height;
				}
				if (class810_1.method_36() && flag2)
				{
					class787_0.method_2().float_0 = sizeF_.Width;
					class787_0.method_2().float_1 = sizeF_.Height;
				}
			}
			Struct40.smethod_18(ref rectangle_0);
			int num5 = 15;
			if (rectangle_0.Width < 15)
			{
				rectangle_0.Width = num5;
			}
			if (rectangle_0.Height < num5)
			{
				rectangle_0.Height = num5;
			}
			return;
		}
		int num6 = 75;
		int num7 = 100;
		Struct35.smethod_1(class787_0, ref rectangle_0, class810_0);
		Struct35.smethod_1(class787_0, ref rectangle_0, class810_1);
		if (type != ChartType_Chart.PiePie && type2 != ChartType_Chart.PiePie)
		{
			if (type != ChartType_Chart.PieBar && type2 != ChartType_Chart.PieBar)
			{
				Struct40.smethod_18(ref rectangle_0);
				return;
			}
			if (type == ChartType_Chart.PieBar)
			{
				num6 = class810_0.vmethod_2();
				num7 = class810_0.GapWidth / 2;
			}
			if (type2 == ChartType_Chart.PieBar)
			{
				num6 = class810_1.vmethod_2();
				num7 = class810_1.GapWidth / 2;
			}
			int num8 = 100 * rectangle_0.Width / (200 + num6 + num7);
			if (num6 <= 100)
			{
				if (num8 <= rectangle_0.Height / 2)
				{
					class787_0.method_18(num8);
				}
				else
				{
					class787_0.method_18(rectangle_0.Height / 2);
				}
				class787_0.method_20((int)((float)(class787_0.method_17() * num6) / 100f));
				class787_0.method_22((int)((float)(class787_0.method_17() * num7) / 100f));
				int num9 = rectangle_0.Width - (2 * class787_0.method_17() + class787_0.method_21() + class787_0.method_19());
				int num10 = rectangle_0.Height - 2 * class787_0.method_17();
				rectangle_0.Inflate(-num9 / 2, -num10 / 2);
				return;
			}
			int num11 = num6 * num8 / 100;
			if (num11 <= rectangle_0.Height / 2)
			{
				class787_0.method_20(num11);
			}
			else
			{
				class787_0.method_20(rectangle_0.Height / 2);
			}
			class787_0.method_18(class787_0.method_19() * 100 / num6);
			class787_0.method_22((int)((float)(class787_0.method_17() * num7) / 100f));
			int num12 = rectangle_0.Width - (2 * class787_0.method_17() + class787_0.method_21() + 2 * class787_0.method_19());
			int num13 = rectangle_0.Height - 2 * class787_0.method_19();
			rectangle_0.Inflate(-num12 / 2, -num13 / 2);
			return;
		}
		if (type == ChartType_Chart.PiePie)
		{
			num6 = class810_0.vmethod_2();
			num7 = class810_0.GapWidth;
		}
		if (type2 == ChartType_Chart.PiePie)
		{
			num6 = class810_1.vmethod_2();
			num7 = class810_1.GapWidth;
		}
		int num14 = 100 * rectangle_0.Width / (200 + 2 * num6 + num7);
		if (num6 <= 100)
		{
			if (num14 <= rectangle_0.Height / 2)
			{
				class787_0.method_18(num14);
			}
			else
			{
				class787_0.method_18(rectangle_0.Height / 2);
			}
			class787_0.method_20((int)((float)(class787_0.method_17() * num6) / 100f));
			class787_0.method_22((int)((float)(class787_0.method_17() * num7) / 100f));
			int num15 = rectangle_0.Width - (2 * class787_0.method_17() + class787_0.method_21() + 2 * class787_0.method_19());
			int num16 = rectangle_0.Height - 2 * class787_0.method_17();
			rectangle_0.Inflate(-num15 / 2, -num16 / 2);
			return;
		}
		int num17 = num6 * num14 / 100;
		if (num17 <= rectangle_0.Height / 2)
		{
			class787_0.method_20(num17);
		}
		else
		{
			class787_0.method_20(rectangle_0.Height / 2);
		}
		class787_0.method_18(class787_0.method_19() * 100 / num6);
		class787_0.method_22((int)((float)(class787_0.method_17() * num7) / 100f));
		int num18 = rectangle_0.Width - (2 * class787_0.method_17() + class787_0.method_21() + 2 * class787_0.method_19());
		int num19 = rectangle_0.Height - 2 * class787_0.method_19();
		rectangle_0.Inflate(-num18 / 2, -num19 / 2);
	}

	private static void smethod_21(Class789 class789_0, Class808 class808_0)
	{
		ArrayList arrayList_ = class789_0.arrayList_1;
		bool flag = ((class789_0.method_3() == Enum61.const_1 || class789_0.method_3() == Enum61.const_3) ? true : false);
		IList list = class808_0.method_16();
		for (int i = 0; i < list.Count; i++)
		{
			Class810 @class = (Class810)list[i];
			ChartType_Chart chartType_Chart = @class.method_22();
			Class800 class2 = ((!flag) ? @class.method_5() : @class.method_4());
			if (class2 == null || class2.DisplayType == Enum68.const_2)
			{
				continue;
			}
			for (int j = 0; j < @class.method_10().Count; j++)
			{
				Class796 class3 = @class.method_10().method_1(j);
				double num = 0.0;
				num = ((!flag) ? class3.XValue : class3.YValue);
				double num2 = 0.0;
				double num3 = 0.0;
				switch (class2.Type)
				{
				case Enum69.const_0:
				{
					double num4 = ((class2.MinusValue.Count > j) ? class2.method_2(class2.MinusValue[j]) : 0.0);
					num2 = num4;
					num4 = ((class2.PlusValue.Count > j) ? class2.method_2(class2.PlusValue[j]) : 0.0);
					num3 = num4;
					break;
				}
				case Enum69.const_1:
					num2 = class2.Amount;
					num3 = num2;
					break;
				case Enum69.const_2:
					num2 = class2.Amount * Math.Abs(num) / 100.0;
					num3 = class2.Amount * Math.Abs(num) / 100.0;
					break;
				}
				if (flag && (chartType_Chart == ChartType_Chart.ColumnStacked || chartType_Chart == ChartType_Chart.BarStacked))
				{
					double num5 = num;
					for (int k = 0; k < i; k++)
					{
						Class796 class4 = ((Class810)list[k]).method_10().method_1(j);
						if (class4 != null)
						{
							double yValue = class4.YValue;
							if (yValue > 0.0 && num > 0.0)
							{
								num5 += yValue;
							}
							if (yValue <= 0.0 && num <= 0.0)
							{
								num5 += yValue;
							}
						}
					}
					num = num5;
				}
				else if (flag && (chartType_Chart == ChartType_Chart.Column100PercentStacked || chartType_Chart == ChartType_Chart.Bar100PercentStacked))
				{
					double num6 = num;
					double num7 = 0.0;
					for (int l = 0; l < i; l++)
					{
						Class796 class5 = ((Class810)list[l]).method_10().method_1(j);
						if (class5 != null)
						{
							double yValue2 = class5.YValue;
							if (yValue2 > 0.0 && num > 0.0)
							{
								num6 += yValue2;
							}
							if (yValue2 <= 0.0 && num <= 0.0)
							{
								num6 += yValue2;
							}
						}
					}
					for (int m = 0; m < list.Count; m++)
					{
						Class796 class6 = ((Class810)list[m]).method_10().method_1(j);
						if (class6 != null)
						{
							double yValue3 = class6.YValue;
							num7 += Math.Abs(yValue3);
						}
					}
					num = num6 * 100.0 / num7;
					num3 = num3 * 100.0 / num7;
					num2 = num2 * 100.0 / num7;
				}
				if (num3 > 0.0 && num3 + num >= class789_0.MaxValue && (class2.DisplayType == Enum68.const_0 || class2.DisplayType == Enum68.const_3))
				{
					for (double num8 = class789_0.MaxValue + class789_0.MajorUnit; num8 <= num3 + num + class789_0.MajorUnit; num8 += class789_0.MajorUnit)
					{
						arrayList_.Insert(0, num8);
					}
					class789_0.MaxValue = (double)arrayList_[0];
				}
				if (num2 < 0.0 && 0.0 - num2 + num >= class789_0.MaxValue && (class2.DisplayType == Enum68.const_0 || class2.DisplayType == Enum68.const_1))
				{
					for (double num9 = class789_0.MaxValue + class789_0.MajorUnit; num9 <= 0.0 - num2 + num + class789_0.MajorUnit; num9 += class789_0.MajorUnit)
					{
						arrayList_.Insert(0, num9);
					}
					class789_0.MaxValue = (double)arrayList_[0];
				}
				if (num2 > 0.0 && num - num2 <= class789_0.MinValue && (class2.DisplayType == Enum68.const_0 || class2.DisplayType == Enum68.const_1))
				{
					for (double num10 = class789_0.MinValue - class789_0.MajorUnit; num10 >= num - num2 - class789_0.MajorUnit; num10 -= class789_0.MajorUnit)
					{
						arrayList_.Add(num10);
					}
					class789_0.MinValue = (double)arrayList_[arrayList_.Count - 1];
				}
				if (num3 < 0.0 && num + num3 <= class789_0.MinValue && (class2.DisplayType == Enum68.const_0 || class2.DisplayType == Enum68.const_3))
				{
					for (double num11 = class789_0.MinValue - class789_0.MajorUnit; num11 >= num + num3 - class789_0.MajorUnit; num11 -= class789_0.MajorUnit)
					{
						arrayList_.Add(num11);
					}
					class789_0.MinValue = (double)arrayList_[arrayList_.Count - 1];
				}
			}
		}
	}

	private static void smethod_22(Class787 class787_0, bool bool_0, bool bool_1)
	{
		smethod_23(class787_0.method_1(), bool_0);
		smethod_23(class787_0.method_2(), bool_1);
		smethod_23(class787_0.method_9(), bool_0);
		smethod_23(class787_0.method_10(), bool_1);
	}

	internal static void smethod_23(Class789 class789_0, bool bool_0)
	{
		Class789 @class = Struct19.smethod_36(class789_0);
		if (@class == null)
		{
			return;
		}
		if (@class.CrossType == Enum66.const_1 && !@class.IsPlotOrderReversed)
		{
			if (!bool_0)
			{
				if (class789_0.method_2())
				{
					class789_0.method_1(Enum54.const_3);
				}
				else
				{
					class789_0.method_1(Enum54.const_2);
				}
			}
			else if (class789_0.method_2())
			{
				class789_0.method_1(Enum54.const_2);
			}
			else
			{
				class789_0.method_1(Enum54.const_3);
			}
		}
		else if (@class.CrossType != Enum66.const_1 && @class.IsPlotOrderReversed)
		{
			if (!bool_0)
			{
				if (class789_0.method_2())
				{
					class789_0.method_1(Enum54.const_3);
				}
				else
				{
					class789_0.method_1(Enum54.const_2);
				}
			}
			else if (class789_0.method_2())
			{
				class789_0.method_1(Enum54.const_2);
			}
			else
			{
				class789_0.method_1(Enum54.const_3);
			}
		}
		else if (!bool_0)
		{
			if (class789_0.method_2())
			{
				class789_0.method_1(Enum54.const_0);
			}
			else
			{
				class789_0.method_1(Enum54.const_1);
			}
		}
		else if (class789_0.method_2())
		{
			class789_0.method_1(Enum54.const_1);
		}
		else
		{
			class789_0.method_1(Enum54.const_0);
		}
		if (class789_0.TickLabelPosition == Enum83.const_0)
		{
			switch (class789_0.method_0())
			{
			case Enum54.const_0:
				class789_0.method_1(Enum54.const_3);
				break;
			case Enum54.const_1:
				class789_0.method_1(Enum54.const_2);
				break;
			case Enum54.const_2:
				class789_0.method_1(Enum54.const_1);
				break;
			case Enum54.const_3:
				class789_0.method_1(Enum54.const_0);
				break;
			}
		}
	}

	private static void smethod_24(Class787 class787_0)
	{
		smethod_25(class787_0.method_1());
		smethod_25(class787_0.method_2());
		smethod_25(class787_0.method_9());
		smethod_25(class787_0.method_10());
	}

	private static void smethod_25(Class789 class789_0)
	{
		if (class789_0.method_0() == Enum54.const_1)
		{
			if (class789_0.bool_10)
			{
				class789_0.method_5(Enum0.const_0);
			}
			else
			{
				class789_0.method_5(Enum0.const_1);
			}
		}
		if (class789_0.method_0() == Enum54.const_2)
		{
			if (class789_0.bool_10)
			{
				class789_0.method_5(Enum0.const_0);
			}
			else
			{
				class789_0.method_5(Enum0.const_1);
			}
		}
		if (class789_0.method_0() == Enum54.const_0)
		{
			if (class789_0.bool_10)
			{
				class789_0.method_5(Enum0.const_3);
			}
			else
			{
				class789_0.method_5(Enum0.const_2);
			}
		}
		if (class789_0.method_0() == Enum54.const_3)
		{
			if (class789_0.bool_10)
			{
				class789_0.method_5(Enum0.const_3);
			}
			else
			{
				class789_0.method_5(Enum0.const_2);
			}
		}
	}

	internal static void smethod_26(Class787 class787_0)
	{
		ArrayList arrayList = class787_0.method_7().method_16();
		Class802 legendEntries = class787_0.method_4().LegendEntries;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class810 @class = (Class810)arrayList[i];
			Class803 class2 = new Class803(class787_0, class787_0.ChartDataTable, i);
			class2.Name = @class.Name;
			class2.Type = Enum56.const_0;
			class2.method_1(@class);
			legendEntries.Add(class2);
		}
	}

	internal static void smethod_27(Class787 class787_0)
	{
		ArrayList arrayList = class787_0.method_7().method_16();
		Class804 @class = class787_0.method_6();
		Class802 class2 = @class.method_2();
		Class802 class3 = @class.method_1();
		bool flag = true;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class810 class4 = (Class810)arrayList[i];
			if (i == 0 && class4.PlotOnSecondAxis)
			{
				flag = false;
			}
			int num = class4.vmethod_6();
			Class803 class5 = class2.method_3(num);
			if (class5 == null)
			{
				Class803 class6 = new Class803(class787_0, @class, num);
				class6.Name = class4.Name;
				class6.Type = Enum56.const_0;
				class6.method_1(class4);
				class3.Add(class6);
			}
			else if (!class5.IsDeleted)
			{
				Class803 class7 = new Class803(class787_0, @class, num);
				class7.Name = class4.Name;
				class7.Type = Enum56.const_0;
				class7.method_1(class4);
				class7.Font = class5.Font;
				class3.Add(class7);
			}
		}
		if (flag)
		{
			ArrayList arrayList2 = class787_0.method_7().method_21();
			int int_ = ((class3.Count > 0) ? (class3.Count - 1) : 0);
			for (int j = 0; j < arrayList2.Count; j++)
			{
				Class815 class8 = (Class815)arrayList2[j];
				int num2 = arrayList.Count + class8.vmethod_0();
				Class803 class9 = class2.method_3(num2);
				if (class9 == null)
				{
					Class803 class10 = new Class803(class787_0, @class, num2);
					class10.Name = class8.Name;
					class10.Type = Enum56.const_1;
					class10.method_1(class8.method_1().method_0());
					class10.method_3(class8);
					smethod_28(class10, class3, int_);
				}
				else if (!class9.IsDeleted)
				{
					Class803 class11 = new Class803(class787_0, @class, num2);
					class11.Name = class8.Name;
					class11.Type = Enum56.const_1;
					class11.method_1(class8.method_1().method_0());
					class11.method_3(class8);
					class11.Font = class9.Font;
					smethod_28(class11, class3, int_);
				}
			}
			return;
		}
		ArrayList arrayList3 = class787_0.method_7().method_22();
		int int_2 = ((class3.Count > 0) ? (class3.Count - 1) : 0);
		for (int k = 0; k < arrayList3.Count; k++)
		{
			Class815 class12 = (Class815)arrayList3[k];
			int num3 = arrayList.Count + class12.vmethod_0();
			Class803 class13 = class2.method_3(num3);
			if (class13 == null)
			{
				Class803 class14 = new Class803(class787_0, @class, num3);
				class14.Name = class12.Name;
				class14.Type = Enum56.const_1;
				class14.method_1(class12.method_1().method_0());
				class14.method_3(class12);
				smethod_28(class14, class3, int_2);
			}
			else if (!class13.IsDeleted)
			{
				Class803 class15 = new Class803(class787_0, @class, num3);
				class15.Name = class12.Name;
				class15.Type = Enum56.const_1;
				class15.method_1(class12.method_1().method_0());
				class15.method_3(class12);
				class15.Font = class13.Font;
				smethod_28(class15, class3, int_2);
			}
		}
	}

	private static void smethod_28(Class803 class803_0, Class802 class802_0, int int_4)
	{
		if (class802_0.Count == 0)
		{
			class802_0.Add(class803_0);
			return;
		}
		bool flag = false;
		for (int i = int_4; i < class802_0.Count; i++)
		{
			if (class802_0[i].vmethod_0() > class803_0.vmethod_0())
			{
				class802_0.Insert(i, class803_0);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			class802_0.Add(class803_0);
		}
	}

	internal static int smethod_29(IList ilist_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			arrayList.Add(((Class810)ilist_0[i]).method_10().Count);
		}
		arrayList.Sort();
		if (arrayList.Count == 0)
		{
			return 0;
		}
		return (int)arrayList[arrayList.Count - 1];
	}

	internal static bool smethod_30(IList list, out double minValue, out double maxValue, Class789 axis)
	{
		ArrayList arrayList = smethod_31(list);
		minValue = 0.0;
		maxValue = 0.0;
		int num = 0;
		for (int i = 0; i < arrayList.Count; i++)
		{
			double minValue2;
			double maxValue2;
			bool flag = smethod_32((ArrayList)arrayList[i], out minValue2, out maxValue2, axis);
			if (i == num && !flag)
			{
				num++;
				continue;
			}
			if (i == num)
			{
				minValue = minValue2;
				maxValue = maxValue2;
				continue;
			}
			if (minValue2 < minValue)
			{
				minValue = minValue2;
			}
			if (maxValue2 > maxValue)
			{
				maxValue = maxValue2;
			}
		}
		if (!axis.imethod_3())
		{
			minValue = (axis.IsLogarithmic ? Struct40.smethod_7(axis.MinValue) : axis.MinValue);
		}
		if (!axis.imethod_5())
		{
			maxValue = (axis.IsLogarithmic ? Struct40.smethod_7(axis.MaxValue) : axis.MaxValue);
		}
		return smethod_42(list);
	}

	private static ArrayList smethod_31(IList ilist_0)
	{
		Class810 @class = (Class810)ilist_0[0];
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		foreach (Class810 item in ilist_0)
		{
			if (item.method_24(new ChartType_Chart[1] { @class.Type }))
			{
				arrayList3.Add(item);
			}
			else
			{
				arrayList2.Add(item);
			}
		}
		if (arrayList3.Count > 0)
		{
			arrayList.Add(arrayList3);
		}
		ArrayList arrayList4 = new ArrayList();
		if (arrayList2.Count > 0)
		{
			@class = (Class810)arrayList2[0];
			ArrayList arrayList5 = new ArrayList();
			arrayList5.AddRange(arrayList2);
			arrayList2.Clear();
			foreach (Class810 item2 in arrayList5)
			{
				if (item2.method_24(new ChartType_Chart[1] { @class.Type }))
				{
					arrayList4.Add(item2);
				}
				else
				{
					arrayList2.Add(item2);
				}
			}
		}
		if (arrayList4.Count > 0)
		{
			arrayList.Add(arrayList4);
		}
		if (arrayList2.Count > 0)
		{
			arrayList.Add(arrayList2);
		}
		return arrayList;
	}

	private static bool smethod_32(ArrayList list, out double minValue, out double maxValue, Class789 axis)
	{
		bool result = false;
		Class809 comparer = new Class809();
		list.Sort(comparer);
		minValue = 0.0;
		maxValue = 0.0;
		Class810 @class = (Class810)list[0];
		if (@class.method_30())
		{
			result = true;
			if (@class.method_31())
			{
				int num = smethod_29(list);
				for (int i = 0; i < num; i++)
				{
					double num2 = 0.0;
					for (int j = 0; j < list.Count; j++)
					{
						Class810 class2 = (Class810)list[j];
						if (!class2.method_30())
						{
							break;
						}
						Class796 class3 = class2.method_10().method_1(i);
						if (class3 == null)
						{
							continue;
						}
						double num3 = (axis.IsLogarithmic ? class3.method_8() : class3.YValue);
						if (@class.Type == ChartType_Chart.Area3DStacked)
						{
							num3 = Math.Abs(num3);
						}
						num2 += num3;
						if (j == 0 && i == 0)
						{
							minValue = num2;
							maxValue = num2;
							continue;
						}
						if (num2 < minValue)
						{
							minValue = num2;
						}
						if (num2 > maxValue)
						{
							maxValue = num2;
						}
					}
				}
			}
			else
			{
				int num4 = smethod_33(list, axis);
				new ArrayList();
				int num5 = smethod_29(list);
				for (int k = 0; k < num5; k++)
				{
					double num6 = 0.0;
					double num7 = 0.0;
					bool flag = false;
					bool flag2 = false;
					for (int l = 0; l < list.Count; l++)
					{
						Class810 class4 = (Class810)list[l];
						if (!class4.method_30())
						{
							break;
						}
						Class796 class5 = class4.method_10().method_1(k);
						if (class5 == null)
						{
							continue;
						}
						double num8 = (axis.IsLogarithmic ? class5.method_8() : class5.YValue);
						if (l == 0 && k == 0)
						{
							switch (num4)
							{
							case 1:
								minValue = num8;
								break;
							case 2:
								maxValue = num8;
								break;
							}
						}
						else if (l == 0)
						{
							if (num4 == 1 && num8 < minValue)
							{
								minValue = num8;
							}
							else if (num4 == 2 && num8 > maxValue)
							{
								maxValue = num8;
							}
						}
						if (num8 < 0.0)
						{
							flag2 = true;
							num7 += num8;
						}
						if (num8 > 0.0)
						{
							flag = true;
							num6 += num8;
						}
					}
					if (flag2 && num7 < minValue)
					{
						minValue = num7;
					}
					if (flag && num6 > maxValue)
					{
						maxValue = num6;
					}
				}
			}
			if (axis.IsLogarithmic)
			{
				maxValue = Struct40.smethod_7(maxValue);
				minValue = Struct40.smethod_7(minValue);
			}
		}
		else if (@class.method_32())
		{
			result = true;
			if (@class.method_33())
			{
				int num9 = smethod_29(list);
				for (int m = 0; m < num9; m++)
				{
					double num10 = 0.0;
					double num11 = 0.0;
					double num12 = 0.0;
					double num13 = 0.0;
					for (int n = 0; n < list.Count; n++)
					{
						Class810 class6 = (Class810)list[n];
						if (!class6.method_32())
						{
							break;
						}
						Class796 class7 = class6.method_10().method_1(m);
						if (class7 != null)
						{
							double num14 = class7.YValue;
							if (@class.Type == ChartType_Chart.Area3D100PercentStacked)
							{
								num14 = Math.Abs(num14);
							}
							num10 += num14;
							num11 += Math.Abs(num14);
							if (num10 < num12)
							{
								num12 = num10;
							}
							if (num10 > num13)
							{
								num13 = num10;
							}
						}
					}
					if (num11 != 0.0)
					{
						int num15 = (int)(100.0 * num12 / num11);
						if ((double)num15 < minValue)
						{
							minValue = num15;
						}
						num15 = (int)(100.0 * num13 / num11);
						if ((double)num15 > maxValue)
						{
							maxValue = num15;
						}
					}
				}
			}
			else
			{
				int num16 = smethod_29(list);
				for (int num17 = 0; num17 < num16; num17++)
				{
					double num18 = 0.0;
					double num19 = 0.0;
					double num20 = 0.0;
					for (int num21 = 0; num21 < list.Count; num21++)
					{
						Class810 class8 = (Class810)list[num21];
						if (!class8.method_32())
						{
							break;
						}
						Class796 class9 = class8.method_10().method_1(num17);
						if (class9 != null)
						{
							double yValue = class9.YValue;
							num18 += Math.Abs(yValue);
							if (yValue < 0.0)
							{
								num20 += yValue;
							}
							if (yValue > 0.0)
							{
								num19 += yValue;
							}
						}
					}
					if (num18 != 0.0)
					{
						if ((double)(int)(100.0 * num20 / num18) < minValue)
						{
							minValue = (int)(100.0 * num20 / num18);
						}
						if ((double)(int)(100.0 * num19 / num18) > maxValue)
						{
							maxValue = (int)(100.0 * num19 / num18);
						}
					}
				}
			}
		}
		else
		{
			bool flag3 = true;
			for (int num22 = 0; num22 < list.Count; num22++)
			{
				Class795 class10 = ((Class810)list[num22]).method_10();
				for (int num23 = 0; num23 < class10.Count; num23++)
				{
					if (class10[num23] != null && class10[num23].imethod_0())
					{
						continue;
					}
					if (class10[num23] != null && class10[num23].imethod_6())
					{
						result = true;
						continue;
					}
					double num24 = ((class10[num23] == null) ? 0.0 : class10[num23].YValue);
					if (flag3)
					{
						minValue = num24;
						maxValue = num24;
						result = true;
						flag3 = false;
						continue;
					}
					if (num24 < minValue)
					{
						minValue = num24;
					}
					if (num24 > maxValue)
					{
						maxValue = num24;
					}
				}
			}
		}
		return result;
	}

	internal static int smethod_33(ArrayList arrayList_0, Class789 class789_0)
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class795 @class = ((Class810)arrayList_0[i]).method_10();
			for (int j = 0; j < @class.Count; j++)
			{
				Class796 class2 = @class.method_1(j);
				if (class2 != null)
				{
					double num = (class789_0.IsLogarithmic ? class2.method_8() : class2.YValue);
					if (num > 0.0)
					{
						flag = true;
					}
					else if (num < 0.0)
					{
						flag2 = true;
					}
				}
			}
		}
		if (flag && !flag2)
		{
			return 1;
		}
		if (!flag && flag2)
		{
			return 2;
		}
		return 3;
	}

	private static bool smethod_34(IList list, out double minValue, out double maxValue, Class789 axis)
	{
		minValue = 2147483647.0;
		maxValue = -2147483648.0;
		for (int i = 0; i < list.Count; i++)
		{
			Class810 @class = (Class810)list[i];
			Class795 class2 = @class.method_10();
			double num = 2147483647.0;
			double num2 = -2147483648.0;
			bool flag = true;
			for (int j = 0; j < class2.Count; j++)
			{
				if (class2[j] != null && !class2[j].imethod_2())
				{
					double xValue = class2[j].XValue;
					if (flag)
					{
						num = xValue;
						num2 = xValue;
						flag = false;
					}
					if (xValue < num)
					{
						num = xValue;
					}
					if (xValue > num2)
					{
						num2 = xValue;
					}
				}
			}
			if (flag)
			{
				num = 0.0;
				num2 = 0.0;
			}
			double num3 = 0.0;
			double num4 = 0.0;
			for (int k = 0; k < @class.method_11().Count; k++)
			{
				Class815 class3 = @class.method_11().method_1(k);
				if (class3.method_0().IsVisible)
				{
					if (class3.Forward > num3)
					{
						num3 = class3.Forward;
					}
					if (class3.Backward > num4)
					{
						num4 = class3.Backward;
					}
				}
			}
			num -= num4;
			num2 += num3;
			if (num < minValue)
			{
				minValue = num;
			}
			if (num2 > maxValue)
			{
				maxValue = num2;
			}
		}
		if (!axis.imethod_3())
		{
			minValue = (axis.IsLogarithmic ? Struct40.smethod_7(axis.MinValue) : axis.MinValue);
		}
		if (!axis.imethod_5())
		{
			maxValue = (axis.IsLogarithmic ? Struct40.smethod_7(axis.MaxValue) : axis.MaxValue);
		}
		return smethod_43(list);
	}

	private static bool smethod_35(Class787 class787_0, IList ilist_0, IList ilist_1)
	{
		if (ilist_1.Count > 0 && ilist_0.Count > 0)
		{
			Class789 @class = class787_0.method_9();
			Class789 class2 = class787_0.method_10();
			Class810 class3 = (Class810)ilist_0[0];
			Class810 class4 = (Class810)ilist_1[0];
			if (class3.method_22() != ChartType_Chart.Column && class3.method_22() != ChartType_Chart.ColumnStacked && class3.method_22() != ChartType_Chart.Column100PercentStacked && class3.method_22() != ChartType_Chart.Scatter)
			{
				if (class3.method_22() != ChartType_Chart.Bar && class3.method_22() != ChartType_Chart.BarStacked && class3.method_22() != ChartType_Chart.Bar100PercentStacked)
				{
					if (class3.method_22() != ChartType_Chart.Radar)
					{
						return false;
					}
					if (class4.method_22() != ChartType_Chart.Radar)
					{
						return false;
					}
				}
				else if (class4.method_22() != ChartType_Chart.Bar && class4.method_22() != ChartType_Chart.BarStacked && class4.method_22() != ChartType_Chart.Bar100PercentStacked)
				{
					return false;
				}
			}
			else if (class4.method_22() != ChartType_Chart.Column && class4.method_22() != ChartType_Chart.ColumnStacked && class4.method_22() != ChartType_Chart.Column100PercentStacked && class4.method_22() != ChartType_Chart.Scatter)
			{
				return false;
			}
			if (@class.IsVisible && class2.IsVisible)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private static Class789 smethod_36(Class787 class787_0)
	{
		Class789 @class = class787_0.method_9();
		Class789 class2 = class787_0.method_10();
		if (!@class.IsVisible && class2.IsVisible)
		{
			return class2;
		}
		return @class;
	}

	private static Class789 smethod_37(Class787 class787_0)
	{
		Class789 @class = class787_0.method_9();
		Class789 class2 = class787_0.method_10();
		if (!@class.IsVisible && class2.IsVisible)
		{
			return @class;
		}
		return class2;
	}

	internal static bool smethod_38(ArrayList primarySeries, ArrayList secondarySeries, out double minValue, out double maxValue, Class789 axis)
	{
		smethod_39(primarySeries, out var minValue2, out var maxValue2, axis);
		smethod_39(secondarySeries, out var minValue3, out var maxValue3, axis);
		if (minValue2 < minValue3)
		{
			minValue = minValue2;
		}
		else
		{
			minValue = minValue3;
		}
		if (maxValue2 < maxValue3)
		{
			maxValue = maxValue3;
		}
		else
		{
			maxValue = maxValue2;
		}
		if (!axis.imethod_3())
		{
			minValue = (axis.IsLogarithmic ? Struct40.smethod_7(axis.MinValue) : axis.MinValue);
		}
		if (!axis.imethod_5())
		{
			maxValue = (axis.IsLogarithmic ? Struct40.smethod_7(axis.MaxValue) : axis.MaxValue);
		}
		if (smethod_42(primarySeries))
		{
			return smethod_42(secondarySeries);
		}
		return false;
	}

	internal static void smethod_39(ArrayList list, out double minValue, out double maxValue, Class789 axis)
	{
		ArrayList arrayList = smethod_31(list);
		minValue = 0.0;
		maxValue = 0.0;
		for (int i = 0; i < arrayList.Count; i++)
		{
			smethod_32((ArrayList)arrayList[i], out var minValue2, out var maxValue2, axis);
			if (i == 0)
			{
				minValue = minValue2;
				maxValue = maxValue2;
				continue;
			}
			if (minValue2 < minValue)
			{
				minValue = minValue2;
			}
			if (maxValue2 > maxValue)
			{
				maxValue = maxValue2;
			}
		}
	}

	private static void smethod_40(Class789 class789_0, Class789 class789_1)
	{
		class789_0.arrayList_1 = class789_1.arrayList_1;
		class789_0.MaxValue = class789_1.MaxValue;
		class789_0.MinValue = class789_1.MinValue;
		class789_0.MajorUnitScale = class789_1.MajorUnitScale;
		class789_0.MajorUnit = class789_1.MajorUnit;
		class789_0.MinorUnitScale = class789_1.MinorUnitScale;
		class789_0.MinorUnit = class789_1.MinorUnit;
	}

	private static void smethod_41(Class789 class789_0)
	{
		class789_0.arrayList_0 = class789_0.arrayList_1;
		class789_0.double_5 = class789_0.MaxValue;
		class789_0.double_6 = class789_0.MinValue;
		class789_0.double_7 = class789_0.MajorUnit;
		class789_0.double_8 = class789_0.MinorUnit;
	}

	private static bool smethod_42(IList ilist_0)
	{
		bool result = true;
		foreach (Class810 item in ilist_0)
		{
			if (!item.method_20())
			{
				result = false;
			}
		}
		return result;
	}

	private static bool smethod_43(IList ilist_0)
	{
		bool result = true;
		foreach (Class810 item in ilist_0)
		{
			if (!item.method_19())
			{
				result = false;
			}
		}
		return result;
	}

	internal static void smethod_44(Interface42 interface42_0, Class789 class789_0, double double_0, double double_1, bool bool_0, ArrayList arrayList_0, ChartType_Chart chartType_Chart_0, Rectangle rectangle_0, bool bool_1, Class810 class810_0)
	{
		if (class789_0.IsLogarithmic)
		{
			smethod_72(interface42_0, class789_0, double_0, double_1, arrayList_0, chartType_Chart_0, rectangle_0, bool_1, class810_0);
			return;
		}
		double num = double_0;
		double num2 = double_1;
		Class787 chart = class789_0.Chart;
		bool flag = smethod_53(chartType_Chart_0);
		if (double_0 == double_1 && double_0 == 0.0)
		{
			double num3 = 1.2;
			if (smethod_55(chartType_Chart_0) || flag || class789_0.Chart.method_15() || smethod_57(chartType_Chart_0) || !bool_0)
			{
				num3 = 1.0;
			}
			class789_0.MaxValue = num3;
			double_0 = num3;
			num = num3;
			class789_0.MinValue = 0.0;
			if (flag && class789_0.TickLabels.imethod_0() == "")
			{
				class789_0.TickLabels.imethod_1("0.00%");
				class789_0.TickLabels.LinkedSource = false;
			}
		}
		else if (double_0 <= double_1)
		{
			if (!class789_0.imethod_5() && class789_0.imethod_3())
			{
				class789_0.MinValue = double_0 - 1.0;
				double_1 = class789_0.MinValue;
			}
			else if (class789_0.imethod_5() && !class789_0.imethod_3())
			{
				class789_0.MaxValue = double_1 + 1.0;
				double_0 = class789_0.MaxValue;
			}
		}
		bool flag2 = class789_0.imethod_5();
		bool flag3 = class789_0.imethod_3();
		double double_2 = 0.0;
		int int_ = 1;
		if (flag)
		{
			if (double_0 == 100.0 && class789_0.imethod_5())
			{
				class789_0.MaxValue = 100.0;
			}
			if (double_1 == -100.0 && class789_0.imethod_3())
			{
				class789_0.MinValue = -100.0;
			}
		}
		double double_3 = 0.0;
		double double_4 = 0.0;
		smethod_45(ref double_3, ref double_4, ref double_1, ref double_0, ref double_2, ref int_, class789_0, bool_1, num, num2, flag2, flag3, flag);
		if (!class789_0.imethod_9())
		{
			if (!class789_0.imethod_7() && class789_0.MajorUnit < class789_0.MinorUnit)
			{
				throw new ArgumentException("The numbers you specified can't be used because the interval for the minor unittick marks must be less than or equal to the interval for the major unit tick marks!");
			}
			if (double_2 < class789_0.MinorUnit)
			{
				double_2 = class789_0.MinorUnit;
			}
		}
		smethod_47(class789_0, int_, double_2, double_4, double_3, arrayList_0, num, num2, flag2, flag3, flag);
		int num4 = smethod_48(interface42_0, class789_0, bool_1, class810_0, rectangle_0);
		int num5 = 0;
		num5 = (class789_0.Chart.method_15() ? ((!bool_1) ? ((int)class789_0.Chart.method_13().Height) : ((int)class789_0.Chart.method_13().Width)) : ((!bool_1) ? rectangle_0.Height : rectangle_0.Width));
		bool flag4 = false;
		if (rectangle_0.Height <= 15 || rectangle_0.Height <= chart.method_9().TickLabels.Font.Height)
		{
			flag4 = true;
		}
		int num6 = 3;
		if (flag4)
		{
			num6 = 2;
		}
		while (class789_0.imethod_7() && arrayList_0.Count > num6 && num4 > num5 && num5 != 0)
		{
			smethod_49(double_2, out double_2, out var _);
			double_2 *= 10.0;
			smethod_47(class789_0, int_, double_2, double_4, double_3, arrayList_0, num, num2, flag2, flag3, flag);
			num4 = smethod_48(interface42_0, class789_0, bool_1, class810_0, rectangle_0);
		}
		if (arrayList_0.Count >= 2)
		{
			class789_0.MaxValue = (double)arrayList_0[0];
			class789_0.MinValue = (double)arrayList_0[arrayList_0.Count - 1];
			if (class789_0.imethod_7())
			{
				class789_0.MajorUnit = double_2;
			}
			if (class789_0.imethod_9())
			{
				class789_0.MinorUnit = class789_0.MajorUnit / 5.0;
			}
		}
	}

	private static void smethod_45(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref int int_4, Class789 class789_0, bool bool_0, double double_5, double double_6, bool bool_1, bool bool_2, bool bool_3)
	{
		double num = Struct40.smethod_11(double_3, Struct40.smethod_9(double_3));
		double num2 = Struct40.smethod_11(double_2, Struct40.smethod_9(double_2));
		if (class789_0.imethod_7())
		{
			bool flag = true;
			smethod_49(double_2, out var step, out var maxScale);
			smethod_49(double_3, out var step2, out var maxScale2);
			double_1 = ((double_2 < maxScale) ? double_2 : maxScale);
			double_0 = ((double_3 > maxScale2) ? double_3 : maxScale2);
			if (Math.Abs(step2) > Math.Abs(step))
			{
				double_4 = Math.Abs(step2);
			}
			else
			{
				double_4 = Math.Abs(step);
			}
			if (num != num2 && double_3 > 0.0 && double_2 > 0.0)
			{
				double num3 = Struct40.smethod_10(double_3, double_2);
				smethod_49(num3, out var step3, out var maxScale3);
				if (double_2 / num3 >= 5.0)
				{
					double_1 = Struct40.smethod_10(double_2, maxScale3) / 2.0;
					double_0 = double_2 + maxScale3;
					double_4 = Math.Abs(step3);
					if (Struct40.smethod_10(double_3, double_2) / double_4 >= 8.0)
					{
						smethod_51(ref double_4);
					}
					double double_7 = double_4;
					int int_5 = Struct40.smethod_9(double_7);
					double num4 = 0.0;
					num4 = Struct40.smethod_11(Math.Floor((3.0 * double_2 - double_3) / (2.0 * double_4)) * double_4, int_5);
					if (class789_0.imethod_3() && class789_0.imethod_5())
					{
						class789_0.MinValue = num4;
						double_1 = num4;
					}
				}
				else
				{
					if (class789_0.imethod_3() && class789_0.imethod_5())
					{
						class789_0.MinValue = 0.0;
					}
					double_1 = 0.0;
				}
			}
			else if (num != num2 && double_3 < 0.0 && double_2 < 0.0)
			{
				double num5 = double_2 - double_3;
				smethod_49(num5, out var step4, out var maxScale4);
				if (double_2 / num5 >= 5.0)
				{
					double_0 = double_3 - maxScale4 / 2.0;
					double_1 = double_3 + maxScale4;
					double_4 = Math.Abs(step4);
					if ((double_3 - double_2) / double_4 >= 8.0)
					{
						smethod_51(ref double_4);
					}
					double double_8 = double_4;
					int int_6 = Struct40.smethod_9(double_8);
					double num6 = 0.0;
					while (num6 - 3.0 * double_4 > double_3)
					{
						num6 = Struct40.smethod_11(num6, int_6);
						num6 -= double_4;
					}
					if (class789_0.imethod_5() && class789_0.imethod_3())
					{
						class789_0.MaxValue = num6;
						double_0 = num6;
					}
				}
				else
				{
					if (class789_0.imethod_5() && class789_0.imethod_3())
					{
						class789_0.MaxValue = 0.0;
					}
					double_0 = 0.0;
				}
			}
			else if (num != num2 && double_3 > 0.0 && double_2 < 0.0)
			{
				double val = double_3 - double_2;
				smethod_49(val, out var step5, out var _);
				double_4 = Math.Abs(step5);
				if ((double_3 - double_2) / double_4 > 8.5)
				{
					smethod_51(ref double_4);
				}
			}
			if (class789_0.imethod_5() && class789_0.imethod_3())
			{
				int_4 = 3;
				if (double_2 == 0.0 || (double_3 == double_2 && double_3 > 0.0))
				{
					class789_0.MinValue = 0.0;
					int_4 = 2;
					double_1 = 0.0;
				}
				if (double_3 == 0.0 || (double_3 == double_2 && double_3 < 0.0))
				{
					class789_0.MaxValue = 0.0;
					int_4 = 1;
					double_0 = 0.0;
				}
			}
			else if (!class789_0.imethod_5() && class789_0.imethod_3())
			{
				int_4 = 1;
				double_0 = class789_0.MaxValue;
				double_3 = class789_0.MaxValue;
			}
			else if (class789_0.imethod_5() && !class789_0.imethod_3())
			{
				int_4 = 2;
				double_1 = class789_0.MinValue;
				double_2 = class789_0.MinValue;
			}
			else
			{
				int_4 = 2;
				double_1 = class789_0.MinValue;
				double_0 = class789_0.MaxValue;
				double_2 = class789_0.MinValue;
				double_3 = class789_0.MaxValue;
				double val2 = Struct40.smethod_10(double_3, double_2);
				smethod_49(val2, out var step6, out var _);
				double_4 = step6;
			}
			if ((!bool_0 || smethod_56(class789_0.Chart.Type)) && flag)
			{
				smethod_58(class789_0, double_1, double_0, ref double_4, int_4, double_5, double_6, bool_1, bool_2, bool_3);
			}
			return;
		}
		double_4 = class789_0.MajorUnit;
		double_1 = double_2;
		double_0 = double_3;
		if (num != num2 && double_3 > 0.0 && double_2 > 0.0)
		{
			double num7 = double_3 - double_2;
			smethod_49(num7, out var step7, out var maxScale7);
			if (double_2 / num7 >= 5.0)
			{
				double_1 = double_2 - maxScale7 / 2.0;
				double_0 = double_2 + maxScale7;
				double num8 = Math.Abs(step7);
				int int_7 = Struct40.smethod_9(num8);
				double num9;
				for (num9 = 0.0; num9 < double_1; num9 += num8)
				{
					num9 = Struct40.smethod_11(num9, int_7);
				}
				if (class789_0.imethod_3() && class789_0.imethod_5())
				{
					double double_9 = double_4;
					int_7 = Struct40.smethod_9(double_9);
					double num10;
					for (num10 = 0.0; num10 <= num9; num10 += double_4)
					{
						num10 = Struct40.smethod_11(num10, int_7);
					}
					class789_0.MinValue = num10 - double_4;
					double_2 = class789_0.MinValue;
					double_1 = class789_0.MinValue;
				}
			}
			else
			{
				if (class789_0.imethod_3() && class789_0.imethod_5())
				{
					class789_0.MinValue = 0.0;
					double_2 = class789_0.MinValue;
				}
				double_1 = 0.0;
			}
		}
		else if (num != num2 && double_3 < 0.0 && double_2 < 0.0)
		{
			double num11 = double_2 - double_3;
			smethod_49(num11, out var step8, out var maxScale8);
			if (double_2 / num11 >= 5.0)
			{
				double_0 = double_3 - maxScale8 / 2.0;
				double_1 = double_3 + maxScale8;
				double num12 = Math.Abs(step8);
				int int_8 = Struct40.smethod_9(num12);
				double num13;
				for (num13 = 0.0; num13 > double_0; num13 -= num12)
				{
					num13 = Struct40.smethod_11(num13, int_8);
				}
				if (class789_0.imethod_5() && class789_0.imethod_3())
				{
					double double_10 = double_4;
					int_8 = Struct40.smethod_9(double_10);
					double num14;
					for (num14 = 0.0; num14 >= num13; num14 -= double_4)
					{
						num14 = Struct40.smethod_11(num14, int_8);
					}
					class789_0.MaxValue = num14 + double_4;
					double_3 = class789_0.MaxValue;
					double_0 = class789_0.MaxValue;
				}
			}
			else
			{
				if (class789_0.imethod_5() && class789_0.imethod_3())
				{
					class789_0.MaxValue = 0.0;
					double_3 = class789_0.MaxValue;
				}
				double_0 = 0.0;
			}
		}
		if (class789_0.imethod_5() && class789_0.imethod_3())
		{
			int_4 = 3;
			if (double_2 == 0.0)
			{
				class789_0.MinValue = 0.0;
				int_4 = 2;
				double_1 = 0.0;
			}
			if (double_3 == 0.0)
			{
				class789_0.MaxValue = 0.0;
				int_4 = 1;
				double_0 = 0.0;
			}
		}
		else if (!class789_0.imethod_5() && class789_0.imethod_3())
		{
			int_4 = 1;
			double_0 = class789_0.MaxValue;
			double_3 = class789_0.MaxValue;
		}
		else if (class789_0.imethod_5() && !class789_0.imethod_3())
		{
			int_4 = 2;
			double_1 = class789_0.MinValue;
			double_2 = class789_0.MinValue;
		}
		else
		{
			int_4 = 2;
			double_1 = class789_0.MinValue;
			double_0 = class789_0.MaxValue;
			double_2 = class789_0.MinValue;
			double_3 = class789_0.MaxValue;
		}
	}

	private static bool smethod_46(Class787 class787_0)
	{
		if (class787_0.Type != ChartType_Chart.Area3D100PercentStacked && class787_0.Type != ChartType_Chart.Area3DStacked)
		{
			if (!class787_0.method_15() && class787_0.Type != ChartType_Chart.Radar && class787_0.Type != ChartType_Chart.RadarFilled && class787_0.Type != ChartType_Chart.RadarWithDataMarkers)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private static void smethod_47(Class789 class789_0, int int_4, double double_0, double double_1, double double_2, ArrayList arrayList_0, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		Class787 chart = class789_0.Chart;
		bool flag = smethod_56(chart.Type) && class789_0.method_2();
		bool flag2 = smethod_46(class789_0.Chart);
		Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		arrayList_0.Clear();
		switch (int_4)
		{
		case 1:
		{
			double num6 = double_2;
			int int_7 = Struct40.smethod_9(double_0);
			while (num6 >= double_1 || Struct40.smethod_10(double_1, num6) < double_0 || (double_1 == double_0 && num6 > 0.0) || double_1 == num6)
			{
				num6 = Struct40.smethod_11(num6, int_7);
				if (!class789_0.imethod_3() && num6 < class789_0.MinValue)
				{
					arrayList_0.Add(class789_0.MinValue);
				}
				else
				{
					arrayList_0.Add(num6);
				}
				num6 -= double_0;
			}
			if (!bool_1)
			{
				break;
			}
			double num7 = 2147483647.0;
			if (arrayList_0.Count > 0)
			{
				num7 = (double)arrayList_0[arrayList_0.Count - 1];
			}
			if (Struct40.smethod_10(double_4, num7) > double_0 && (num7 != 0.0 || flag))
			{
				num7 += double_0;
				if ((double_4 - double_2) / (num7 - double_2) <= 20.0 / 21.0)
				{
					arrayList_0.RemoveAt(arrayList_0.Count - 1);
				}
			}
			else if ((double_4 - double_2) / (num7 - double_2) > 20.0 / 21.0 && (num7 != 0.0 || flag))
			{
				num6 = Struct40.smethod_11(num7 - double_0, int_7);
				arrayList_0.Add(num6);
			}
			break;
		}
		case 2:
		{
			double num4 = double_1;
			int int_6 = Struct40.smethod_9(double_0);
			while (num4 <= double_2 || num4 < double_2 + double_0 || (num4 == double_0 && double_2 > 0.0) || num4 == double_2)
			{
				num4 = Struct40.smethod_11(num4, int_6);
				if (!class789_0.imethod_5() && num4 > class789_0.MaxValue)
				{
					arrayList_0.Add(class789_0.MaxValue);
				}
				else
				{
					arrayList_0.Add(num4);
				}
				num4 += double_0;
			}
			if (bool_0)
			{
				double num5 = -2147483648.0;
				if (arrayList_0.Count > 0)
				{
					num5 = (double)arrayList_0[arrayList_0.Count - 1];
				}
				if (Struct40.smethod_10(num5, double_3) > double_0 && (num5 != 0.0 || flag))
				{
					num5 -= double_0;
					if ((double_3 - double_1) / (num5 - double_1) <= 20.0 / 21.0)
					{
						arrayList_0.RemoveAt(arrayList_0.Count - 1);
					}
				}
				else if ((double_3 - double_1) / (num5 - double_1) > 20.0 / 21.0 && (num5 != 0.0 || flag))
				{
					num4 = Struct40.smethod_11(num5 + double_0, int_6);
					arrayList_0.Add(num4);
				}
			}
			arrayList_0.Reverse();
			break;
		}
		default:
		{
			double num = 0.0;
			int int_5 = Struct40.smethod_9(double_0);
			while (num <= double_2 || Struct40.smethod_10(num, double_2) < double_0 || (num == double_0 && double_2 > 0.0) || num == double_2)
			{
				num = Struct40.smethod_11(num, int_5);
				if (!class789_0.imethod_5() && num > class789_0.MaxValue)
				{
					arrayList_0.Add(class789_0.MaxValue);
				}
				else
				{
					arrayList_0.Add(num);
				}
				num += double_0;
			}
			if (bool_0)
			{
				double num2 = -2147483648.0;
				if (arrayList_0.Count > 0)
				{
					num2 = (double)arrayList_0[arrayList_0.Count - 1];
				}
				if (num2 - double_3 > double_0)
				{
					num2 -= double_0;
					if ((double_3 - double_4) / (num2 - double_4) <= 20.0 / 21.0)
					{
						arrayList_0.RemoveAt(arrayList_0.Count - 1);
					}
				}
				else if ((double_3 - double_4) / (num2 - double_4) > 20.0 / 21.0)
				{
					num = Struct40.smethod_11(num2 + double_0, int_5);
					arrayList_0.Add(num);
				}
			}
			arrayList_0.Reverse();
			num = 0.0 - double_0;
			while (num >= double_1 || Struct40.smethod_10(double_1, num) < double_0 || (double_1 == double_0 && num > 0.0) || double_1 == num)
			{
				num = Struct40.smethod_11(num, int_5);
				if (!class789_0.imethod_3() && num < class789_0.MinValue)
				{
					arrayList_0.Add(class789_0.MinValue);
				}
				else
				{
					arrayList_0.Add(num);
				}
				num -= double_0;
			}
			if (!bool_1)
			{
				break;
			}
			double num3 = 2147483647.0;
			if (arrayList_0.Count > 0)
			{
				num3 = (double)arrayList_0[arrayList_0.Count - 1];
			}
			if (double_4 - num3 > double_0)
			{
				num3 += double_0;
				if ((double_4 - double_3) / (num3 - double_3) <= 20.0 / 21.0)
				{
					arrayList_0.RemoveAt(arrayList_0.Count - 1);
				}
			}
			else if ((double_4 - double_3) / (num3 - double_3) > 20.0 / 21.0)
			{
				num = Struct40.smethod_11(num3 - double_0, int_5);
				arrayList_0.Add(num);
			}
			break;
		}
		}
		if (arrayList_0.Count >= 2)
		{
			if ((bool_2 || flag2) && (double)arrayList_0[0] >= double_3 + double_0 && (double)arrayList_0[0] != 0.0 && bool_0 && arrayList_0.Count >= 3)
			{
				arrayList_0.RemoveAt(0);
			}
			if ((bool_2 || flag2) && (double)arrayList_0[arrayList_0.Count - 1] <= Struct40.smethod_10(double_4, double_0) && (double)arrayList_0[arrayList_0.Count - 1] != 0.0 && bool_1 && arrayList_0.Count >= 3)
			{
				arrayList_0.RemoveAt(arrayList_0.Count - 1);
			}
		}
	}

	internal static int smethod_48(Interface42 interface42_0, Class789 class789_0, bool bool_0, Class810 class810_0, Rectangle rectangle_0)
	{
		if (class789_0.TickLabelPosition == Enum83.const_3)
		{
			return 0;
		}
		ChartType_Chart chartType_Chart_ = class810_0.method_22();
		Class811 @class = class789_0.method_9();
		Class796 class2 = class810_0.method_10().method_1(0);
		string string_ = class2.vmethod_6();
		bool bool_ = class2.vmethod_7();
		bool flag = false;
		if (@class.LinkedSource && class2 != null)
		{
			flag = true;
		}
		string text = "";
		for (int i = 0; i < class789_0.arrayList_1.Count; i++)
		{
			double num = Convert.ToDouble(class789_0.arrayList_1[i]);
			if (smethod_53(chartType_Chart_))
			{
				num /= 100.0;
				string_ = "0%";
			}
			string text2 = "";
			num *= Math.Pow(10.0, (double)class789_0.method_11().vmethod_0());
			text2 = ((!flag) ? Struct19.smethod_28(class789_0, num) : Struct26.smethod_6(class789_0.Chart.vmethod_2(), num, string_, bool_));
			if (text2.Length > text.Length)
			{
				text = text2;
			}
		}
		Size size_ = new Size(rectangle_0.Width, rectangle_0.Height);
		Size size = default(Size);
		size = ((@class.Rotation != 0) ? Struct37.smethod_11(class789_0.Chart.imethod_0(), text, @class.Rotation, @class.Font, size_, Enum82.const_1, Enum82.const_1) : Struct37.smethod_11(class789_0.Chart.imethod_0(), text, @class.Rotation, @class.Font, size_, Enum82.const_1, Enum82.const_1));
		float num2 = 0f;
		num2 = ((!bool_0) ? ((float)(size.Height * (class789_0.arrayList_1.Count - 1))) : ((float)(size.Width * (class789_0.arrayList_1.Count - 1))));
		return (int)((double)num2 + 0.5);
	}

	private static void smethod_49(double val, out double step, out double maxScale)
	{
		bool flag = true;
		if (val < 0.0)
		{
			flag = false;
		}
		val = Math.Abs(val);
		step = 0.0;
		maxScale = 0.0;
		if (val > 1.0)
		{
			smethod_50(val, out step, out maxScale);
		}
		else
		{
			if (val == 0.0)
			{
				return;
			}
			int num = Struct40.smethod_9(val);
			double val2 = val * Math.Pow(10.0, num);
			smethod_50(val2, out step, out maxScale);
			step /= Math.Pow(10.0, num);
			maxScale /= Math.Pow(10.0, num);
		}
		if (!flag)
		{
			step = 0.0 - step;
			maxScale = 0.0 - maxScale;
		}
	}

	private static void smethod_50(double val, out double step, out double maxScale)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		val = Math.Abs(val);
		step = 1.0;
		maxScale = 1.0;
		string text = val.ToString();
		string text2 = "";
		if (text.IndexOf("E") > 0)
		{
			string[] array = text.Split('E');
			text = array[0];
			text2 = "E" + array[1];
		}
		int num = int.Parse(text[0].ToString());
		int num2 = 0;
		if (text.Length > 1)
		{
			num2 = ((text[1] == c) ? int.Parse(text[2].ToString()) : int.Parse(text[1].ToString()));
		}
		if (num == 1)
		{
			int num3 = num2 / 2;
			num3++;
			num2 = num3 * 2;
			step = 2.0;
		}
		else if (num < 5)
		{
			if (num2 % 5 > 0)
			{
				num++;
				num2 = 0;
			}
			else
			{
				num2 = 5;
			}
			step = 5.0;
		}
		else
		{
			num++;
			step = 10.0;
			num2 = 0;
		}
		int num4 = text.Length;
		int num5 = text.IndexOf(c, 0);
		if (num5 > 0)
		{
			num4 = num5;
		}
		if (text2 == "")
		{
			step *= Math.Pow(10.0, num4 - 2);
			maxScale = (double)(num * 10 + num2) * Math.Pow(10.0, num4 - 2);
			return;
		}
		step *= Math.Pow(10.0, num4 - 2);
		maxScale = (double)(num * 10 + num2) * Math.Pow(10.0, num4 - 2);
		step = Convert.ToDouble(step + text2);
		maxScale = Convert.ToDouble(maxScale + text2);
	}

	private static void smethod_51(ref double double_0)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		bool flag = true;
		if (double_0 < 0.0)
		{
			flag = false;
		}
		double_0 = Math.Abs(double_0);
		int num = 1;
		if (double_0 > 1.0)
		{
			string text = double_0.ToString();
			num = int.Parse(text[0].ToString());
		}
		else if (double_0 == 0.0)
		{
			double_0 = 0.0;
			return;
		}
		if (double_0 < 1.0)
		{
			string text2 = double_0.ToString();
			for (int i = 0; i < text2.Length; i++)
			{
				if (text2[i] != '0' && text2[i] != c)
				{
					num = int.Parse(text2[i].ToString());
					break;
				}
			}
		}
		if (num != 1 && num != 5)
		{
			double_0 = double_0 * 5.0 / 2.0;
		}
		else
		{
			double_0 = 2.0 * double_0;
		}
		if (!flag)
		{
			double_0 = 0.0 - double_0;
		}
	}

	private static void smethod_52(ref double double_0)
	{
		char c = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		bool flag = true;
		if (double_0 < 0.0)
		{
			flag = false;
		}
		double_0 = Math.Abs(double_0);
		int num = 1;
		if (double_0 > 1.0)
		{
			string text = double_0.ToString();
			num = int.Parse(text[0].ToString());
		}
		else if (double_0 == 0.0)
		{
			double_0 = 0.0;
			return;
		}
		if (double_0 < 1.0)
		{
			string text2 = double_0.ToString();
			for (int i = 0; i < text2.Length; i++)
			{
				if (text2[i] != '0' && text2[i] != c)
				{
					num = int.Parse(text2[i].ToString());
					break;
				}
			}
		}
		if (num != 1 && num != 2)
		{
			double_0 = double_0 * 2.0 / 5.0;
		}
		else
		{
			double_0 /= 2.0;
		}
		if (!flag)
		{
			double_0 = 0.0 - double_0;
		}
	}

	internal static bool smethod_53(ChartType_Chart chartType_Chart_0)
	{
		switch (chartType_Chart_0)
		{
		default:
			return false;
		case ChartType_Chart.Area100PercentStacked:
		case ChartType_Chart.Area3D100PercentStacked:
		case ChartType_Chart.Bar100PercentStacked:
		case ChartType_Chart.Bar3D100PercentStacked:
		case ChartType_Chart.Column100PercentStacked:
		case ChartType_Chart.Column3D100PercentStacked:
		case ChartType_Chart.Cone100PercentStacked:
		case ChartType_Chart.ConicalBar100PercentStacked:
		case ChartType_Chart.Cylinder100PercentStacked:
		case ChartType_Chart.CylindricalBar100PercentStacked:
		case ChartType_Chart.Line100PercentStacked:
		case ChartType_Chart.Line100PercentStackedWithDataMarkers:
		case ChartType_Chart.Pyramid100PercentStacked:
		case ChartType_Chart.PyramidBar100PercentStacked:
			return true;
		}
	}

	internal static bool smethod_54(ChartType_Chart chartType_Chart_0)
	{
		switch (chartType_Chart_0)
		{
		default:
			return false;
		case ChartType_Chart.Bubble:
		case ChartType_Chart.Bubble3D:
		case ChartType_Chart.Scatter:
		case ChartType_Chart.ScatterConnectedByCurvesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByCurvesWithoutDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithDataMarker:
		case ChartType_Chart.ScatterConnectedByLinesWithoutDataMarker:
			return true;
		}
	}

	private static bool smethod_55(ChartType_Chart chartType_Chart_0)
	{
		switch (chartType_Chart_0)
		{
		default:
			return false;
		case ChartType_Chart.AreaStacked:
		case ChartType_Chart.Area3DStacked:
		case ChartType_Chart.BarStacked:
		case ChartType_Chart.Bar3DStacked:
		case ChartType_Chart.ColumnStacked:
		case ChartType_Chart.Column3DStacked:
		case ChartType_Chart.ConeStacked:
		case ChartType_Chart.ConicalBarStacked:
		case ChartType_Chart.CylinderStacked:
		case ChartType_Chart.CylindricalBarStacked:
		case ChartType_Chart.LineStacked:
		case ChartType_Chart.LineStackedWithDataMarkers:
		case ChartType_Chart.PyramidStacked:
		case ChartType_Chart.PyramidBarStacked:
			return true;
		}
	}

	private static bool smethod_56(ChartType_Chart chartType_Chart_0)
	{
		if (chartType_Chart_0 != ChartType_Chart.Bubble3D && chartType_Chart_0 != ChartType_Chart.Bubble)
		{
			return false;
		}
		return true;
	}

	private static bool smethod_57(ChartType_Chart chartType_Chart_0)
	{
		if (chartType_Chart_0 != ChartType_Chart.Radar && chartType_Chart_0 != ChartType_Chart.RadarWithDataMarkers && chartType_Chart_0 != ChartType_Chart.RadarFilled)
		{
			return false;
		}
		return true;
	}

	internal static void smethod_58(Class789 class789_0, double double_0, double double_1, ref double double_2, int int_4, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		double num = double_0;
		double num2 = double_1;
		bool flag = smethod_56(class789_0.Chart.Type) && class789_0.method_2();
		smethod_46(class789_0.Chart);
		double double_5 = double_2;
		int int_5 = Struct40.smethod_9(double_5);
		switch (int_4)
		{
		case 1:
		{
			double num5 = double_1;
			if (!class789_0.imethod_3())
			{
				num = class789_0.MinValue;
				break;
			}
			while (num5 >= double_0 || double_0 - num5 < double_2)
			{
				num5 = Struct40.smethod_11(num5, int_5);
				num = num5;
				double_5 = double_2;
				num5 = Struct40.smethod_10(num5, double_5);
			}
			double_5 = double_2;
			if ((bool_2 || smethod_46(class789_0.Chart)) && num <= Struct40.smethod_10(double_4, double_5) && num != 0.0 && bool_1)
			{
				double_5 = double_2;
				num = Struct40.smethod_12(num, double_5);
				double_5 = double_2;
			}
			if ((!(Struct40.smethod_10(double_4, num) > double_2) || (num == 0.0 && !flag)) && (double_4 - double_1) / (num - double_1) > 20.0 / 21.0 && (num != 0.0 || flag))
			{
				num = Struct40.smethod_11(num - double_2, int_5);
			}
			break;
		}
		case 2:
		{
			double num4 = double_0;
			if (!class789_0.imethod_5())
			{
				num2 = class789_0.MaxValue;
				break;
			}
			double_5 = double_2;
			while (num4 <= double_1 || num4 < double_1 + double_2)
			{
				num4 = Struct40.smethod_11(num4, int_5);
				num2 = num4;
				num4 = Struct40.smethod_12(num4, double_5);
			}
			if ((bool_2 || smethod_46(class789_0.Chart)) && num2 >= double_3 + double_2 && num2 != 0.0 && bool_0)
			{
				num2 = Struct40.smethod_10(num2, double_5);
			}
			if ((!(Struct40.smethod_10(num2, double_3) > double_2) || (num2 == 0.0 && !flag)) && (double_3 - double_0) / (num2 - double_0) > 20.0 / 21.0 && (num2 != 0.0 || flag))
			{
				num2 = Struct40.smethod_11(num2 + double_2, int_5);
			}
			break;
		}
		default:
		{
			double num3 = 0.0;
			if (!class789_0.imethod_3())
			{
				num = class789_0.MinValue;
			}
			else
			{
				double_5 = double_2;
				while (num3 >= double_0 || double_0 - num3 < double_2)
				{
					num3 = Struct40.smethod_11(num3, int_5);
					num = num3;
					num3 = Struct40.smethod_10(num3, double_5);
				}
				double_5 = double_2;
				if ((bool_2 || smethod_46(class789_0.Chart)) && num <= Struct40.smethod_10(double_4, double_5) && num != 0.0 && bool_1)
				{
					num = Struct40.smethod_12(num, double_5);
				}
				if ((!(Struct40.smethod_10(double_4, num) > double_2) || num == 0.0) && (double_4 - double_1) / (num - double_1) > 20.0 / 21.0 && num != 0.0)
				{
					num = Struct40.smethod_11(num - double_2, int_5);
				}
			}
			num3 = 0.0;
			if (!class789_0.imethod_5())
			{
				num2 = class789_0.MinValue;
				break;
			}
			double_5 = double_2;
			while (num3 <= double_1 || num3 < double_1 + double_2)
			{
				num3 = Struct40.smethod_11(num3, int_5);
				num2 = num3;
				num3 = Struct40.smethod_12(num3, double_5);
			}
			if ((bool_2 || smethod_46(class789_0.Chart)) && num2 >= double_3 + double_2 && num2 != 0.0 && bool_0)
			{
				num2 = Struct40.smethod_10(num2, double_5);
			}
			if ((!(Struct40.smethod_10(num2, double_3) > double_2) || num2 == 0.0) && (double_3 - double_0) / (num2 - double_0) > 20.0 / 21.0 && num2 != 0.0)
			{
				num2 = Struct40.smethod_11(num2 + double_2, int_5);
			}
			break;
		}
		}
		double num6 = double_2;
		double num7 = (num2 - num) / double_2;
		int num8 = (smethod_56(class789_0.Chart.Type) ? 10 : 11);
		if (num7 >= (double)num8)
		{
			smethod_51(ref double_2);
			return;
		}
		smethod_52(ref double_2);
		if (num2 - num > 10.0 * double_2)
		{
			double_2 = num6;
		}
	}

	internal static void smethod_59(Class789 class789_0, double double_0, double double_1, ChartType_Chart chartType_Chart_0, float float_0, bool bool_0, Class810 class810_0, bool bool_1, bool bool_2, bool bool_3)
	{
		_ = class789_0.Chart;
		ArrayList arrayList_ = class789_0.arrayList_1;
		if (class789_0.TickLabelPosition == Enum83.const_3 || arrayList_.Count <= 2)
		{
			return;
		}
		double double_2 = double_0;
		if (double_0 == double_1 && double_0 == 0.0)
		{
			class789_0.MaxValue = 1.0;
			double_0 = 1.0;
			double_2 = 1.0;
			class789_0.MinValue = 0.0;
			bool_1 = false;
			bool_2 = false;
		}
		if (!bool_0 || !bool_3)
		{
			return;
		}
		bool bool_4;
		if (bool_4 = smethod_53(chartType_Chart_0))
		{
			if (double_0 == 100.0 && bool_1)
			{
				class789_0.MaxValue = 100.0;
			}
			if (double_1 == -100.0 && bool_2)
			{
				class789_0.MinValue = -100.0;
			}
		}
		int num = 1;
		double num2 = (double)class789_0.arrayList_1[class789_0.arrayList_1.Count - 1];
		double num3 = (double)class789_0.arrayList_1[0];
		if (!bool_1 || !bool_2)
		{
			num = ((!bool_1 && bool_2) ? 1 : 2);
		}
		else
		{
			num = 3;
			if (num2 == 0.0)
			{
				num = 2;
			}
			if (num3 == 0.0)
			{
				num = 1;
			}
		}
		double double_3 = class789_0.MajorUnit;
		smethod_60(ref double_3, class789_0, class810_0, float_0, num, num2, num3, double_2, double_1, bool_1, bool_2, bool_4);
		if (arrayList_.Count >= 2)
		{
			class789_0.MaxValue = (double)arrayList_[0];
			class789_0.MinValue = (double)arrayList_[arrayList_.Count - 1];
			class789_0.MajorUnit = double_3;
			if (class789_0.imethod_9())
			{
				class789_0.MinorUnit = class789_0.MajorUnit / 5.0;
			}
		}
	}

	private static void smethod_60(ref double double_0, Class789 class789_0, Class810 class810_0, float float_0, int int_4, double double_1, double double_2, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		Class787 chart = class789_0.Chart;
		ArrayList arrayList_ = class789_0.arrayList_1;
		if (class789_0.TickLabelPosition == Enum83.const_3 || arrayList_.Count <= 2)
		{
			return;
		}
		float num = 0f;
		num = class789_0.method_9().method_3();
		float num2 = float_0 / (float)(class789_0.arrayList_1.Count - 1);
		if (num2 / num > 9f && (smethod_46(chart) || !bool_0 || !bool_1))
		{
			smethod_52(ref double_0);
			if ((double)arrayList_[0] - (double)arrayList_[arrayList_.Count - 1] > 11.0 * double_0)
			{
				smethod_51(ref double_0);
				return;
			}
			double double_5 = double_0;
			smethod_61(class789_0, int_4, double_5, double_1, double_2, arrayList_, double_3, double_4, bool_0, bool_1, bool_2);
		}
		else if (num2 / num < 3f)
		{
			smethod_51(ref double_0);
			double double_6 = double_0;
			smethod_61(class789_0, int_4, double_6, double_1, double_2, arrayList_, double_3, double_4, bool_0, bool_1, bool_2);
			smethod_60(ref double_0, class789_0, class810_0, float_0, int_4, double_1, double_2, double_3, double_4, bool_0, bool_1, bool_2);
		}
	}

	private static void smethod_61(Class789 class789_0, int int_4, double double_0, double double_1, double double_2, ArrayList arrayList_0, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		Class787 chart = class789_0.Chart;
		smethod_46(class789_0.Chart);
		Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		arrayList_0.Clear();
		switch (int_4)
		{
		case 1:
		{
			double num6 = double_2;
			int int_7 = Struct40.smethod_9(double_0);
			while (num6 >= double_1 || double_1 - num6 < double_0)
			{
				num6 = Struct40.smethod_11(num6, int_7);
				if (!bool_1 && num6 < class789_0.MinValue)
				{
					arrayList_0.Add(class789_0.MinValue);
				}
				else
				{
					arrayList_0.Add(num6);
				}
				num6 -= double_0;
			}
			if (!bool_1)
			{
				break;
			}
			double num7 = 2147483647.0;
			if (arrayList_0.Count > 0)
			{
				num7 = (double)arrayList_0[arrayList_0.Count - 1];
			}
			if (double_4 - num7 > double_0 && num7 != 0.0)
			{
				num7 += double_0;
				if ((double_4 - double_2) / (num7 - double_2) <= 20.0 / 21.0)
				{
					arrayList_0.RemoveAt(arrayList_0.Count - 1);
				}
			}
			else if ((double_4 - double_2) / (num7 - double_2) > 20.0 / 21.0 && num7 != 0.0)
			{
				num6 = Struct40.smethod_11(num7 - double_0, int_7);
				arrayList_0.Add(num6);
			}
			break;
		}
		case 2:
		{
			double num4 = double_1;
			int int_6 = Struct40.smethod_9(double_0);
			while (num4 <= double_2 || num4 < double_2 + double_0)
			{
				num4 = Struct40.smethod_11(num4, int_6);
				if (!bool_0 && num4 > class789_0.MaxValue)
				{
					arrayList_0.Add(class789_0.MaxValue);
				}
				else
				{
					arrayList_0.Add(num4);
				}
				num4 += double_0;
			}
			if (bool_0)
			{
				double num5 = -2147483648.0;
				if (arrayList_0.Count > 0)
				{
					num5 = (double)arrayList_0[arrayList_0.Count - 1];
				}
				if (num5 - double_3 > double_0 && num5 != 0.0)
				{
					num5 -= double_0;
					if ((double_3 - double_1) / (num5 - double_1) <= 20.0 / 21.0)
					{
						arrayList_0.RemoveAt(arrayList_0.Count - 1);
					}
				}
				else if ((double_3 - double_1) / (num5 - double_1) > 20.0 / 21.0 && num5 != 0.0)
				{
					num4 = Struct40.smethod_11(num5 + double_0, int_6);
					arrayList_0.Add(num4);
				}
			}
			arrayList_0.Reverse();
			break;
		}
		default:
		{
			double num = 0.0;
			int int_5 = Struct40.smethod_9(double_0);
			while (num <= double_2 || num - double_2 < double_0)
			{
				num = Struct40.smethod_11(num, int_5);
				arrayList_0.Add(num);
				num += double_0;
			}
			if (bool_0)
			{
				double num2 = -2147483648.0;
				if (arrayList_0.Count > 0)
				{
					num2 = (double)arrayList_0[arrayList_0.Count - 1];
				}
				if (num2 - double_3 > double_0)
				{
					num2 -= double_0;
					if ((double_3 - double_4) / (num2 - double_4) <= 20.0 / 21.0)
					{
						arrayList_0.RemoveAt(arrayList_0.Count - 1);
					}
				}
				else if ((double_3 - double_4) / (num2 - double_4) > 20.0 / 21.0)
				{
					num = Struct40.smethod_11(num2 + double_0, int_5);
					arrayList_0.Add(num);
				}
			}
			arrayList_0.Reverse();
			num = 0.0 - double_0;
			while (num >= double_1 || double_1 - num < double_0)
			{
				num = Struct40.smethod_11(num, int_5);
				arrayList_0.Add(num);
				num -= double_0;
			}
			if (!bool_1)
			{
				break;
			}
			double num3 = 2147483647.0;
			if (arrayList_0.Count > 0)
			{
				num3 = (double)arrayList_0[arrayList_0.Count - 1];
			}
			if (double_4 - num3 > double_0)
			{
				num3 += double_0;
				if ((double_4 - double_3) / (num3 - double_3) <= 20.0 / 21.0)
				{
					arrayList_0.RemoveAt(arrayList_0.Count - 1);
				}
			}
			else if ((double_4 - double_3) / (num3 - double_3) > 20.0 / 21.0)
			{
				num = Struct40.smethod_11(num3 - double_0, int_5);
				arrayList_0.Add(num);
			}
			break;
		}
		}
		if (arrayList_0.Count >= 2)
		{
			if ((bool_2 || smethod_46(chart)) && (double)arrayList_0[0] >= double_3 + double_0 && (double)arrayList_0[0] != 0.0 && bool_0 && arrayList_0.Count > 3)
			{
				arrayList_0.RemoveAt(0);
			}
			if ((bool_2 || smethod_46(chart)) && (double)arrayList_0[arrayList_0.Count - 1] <= double_4 - double_0 && (double)arrayList_0[arrayList_0.Count - 1] != 0.0 && bool_1 && arrayList_0.Count > 3)
			{
				arrayList_0.RemoveAt(arrayList_0.Count - 1);
			}
		}
	}

	internal static void smethod_62(Interface42 interface42_0, Class789 class789_0, ArrayList arrayList_0, Rectangle rectangle_0, ChartType_Chart chartType_Chart_0, Class808 class808_0, bool bool_0)
	{
		arrayList_0.Clear();
		Class787 chart = class789_0.Chart;
		int num = smethod_29(class808_0.method_15());
		if (smethod_54(chartType_Chart_0) && !class789_0.bool_12)
		{
			class789_0.imethod_5();
			class789_0.imethod_3();
			double minValue;
			double maxValue;
			bool bool_ = smethod_34(class808_0.method_15(), out minValue, out maxValue, class789_0);
			smethod_44(interface42_0, class789_0, maxValue, minValue, bool_, arrayList_0, chartType_Chart_0, rectangle_0, bool_1: true, class808_0.method_9(0));
			return;
		}
		Class808 @class = new Class808(chart);
		Class808 class2 = new Class808(chart);
		new ArrayList();
		double maxValue2 = 0.0;
		if (class789_0.bool_12)
		{
			foreach (Class810 item in class808_0)
			{
				if (item.method_22() == ChartType_Chart.Scatter)
				{
					@class.Add(item);
				}
				else
				{
					class2.Add(item);
				}
			}
			class789_0.imethod_5();
			class789_0.imethod_3();
			smethod_34(@class.method_15(), out var _, out maxValue2, class789_0);
			maxValue2 = Math.Ceiling(maxValue2);
		}
		else
		{
			class2 = class808_0;
		}
		smethod_63(class789_0);
		if (class789_0.CategoryType == Enum64.const_2)
		{
			smethod_67(interface42_0, class789_0, rectangle_0, chartType_Chart_0, class2, bool_0);
			return;
		}
		ArrayList arrayList = new ArrayList();
		arrayList = ((class789_0.method_3() != 0) ? chart.method_7().method_2() : chart.method_7().method_0());
		if (arrayList.Count > 0)
		{
			for (int i = 0; i < arrayList.Count && i < num; i++)
			{
				Class791 class4 = (Class791)arrayList[i];
				arrayList_0.Add(class4.imethod_0());
			}
			for (int j = 0; j < class2.Count; j++)
			{
				Class810 class5 = class2.method_9(j);
				for (int k = 0; k < class5.method_10().Count; k++)
				{
					class5.method_10().method_1(k).XValue = k + 1;
				}
			}
		}
		else if (chartType_Chart_0 == ChartType_Chart.Pie)
		{
			for (int l = 1; l <= class2[0].Points.Count; l++)
			{
				arrayList_0.Add(l);
				Class791 value = new Class791(null, l);
				arrayList.Add(value);
			}
		}
		else
		{
			for (int m = 1; m <= num; m++)
			{
				arrayList_0.Add(m);
				Class791 value2 = new Class791(null, m);
				arrayList.Add(value2);
			}
			if (class789_0.bool_12)
			{
				for (int n = num + 1; (double)n <= maxValue2; n++)
				{
					arrayList_0.Add(n);
					Class791 value3 = new Class791(null, n);
					arrayList.Add(value3);
				}
			}
			for (int num2 = 0; num2 < class2.Count; num2++)
			{
				Class810 class6 = class2.method_9(num2);
				for (int num3 = 0; num3 < class6.method_10().Count; num3++)
				{
					class6.method_10().method_1(num3).XValue = num3 + 1;
				}
			}
		}
		if (class789_0.bool_12)
		{
			class789_0.MinValue = 1.0;
			class789_0.MaxValue = (((double)num > maxValue2) ? ((double)num) : maxValue2);
		}
		else
		{
			class789_0.MinValue = 1.0;
			class789_0.MaxValue = num;
		}
		class789_0.MajorUnit = 1.0;
		class789_0.MinorUnit = class789_0.MajorUnit / 2.0;
	}

	private static void smethod_63(Class789 class789_0)
	{
		if (class789_0.CategoryType != 0)
		{
			return;
		}
		Class787 chart = class789_0.Chart;
		ArrayList arrayList = new ArrayList();
		ArrayList[] array;
		if (class789_0.method_3() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			array = chart.method_7().method_4();
		}
		else
		{
			arrayList = chart.method_7().method_2();
			array = chart.method_7().method_7();
		}
		if (array != null || arrayList.Count <= 0)
		{
			return;
		}
		Class791 @class = (Class791)arrayList[0];
		if (!@class.imethod_5() || !smethod_65(@class.imethod_3()))
		{
			return;
		}
		bool flag = true;
		for (int i = 1; i < arrayList.Count; i++)
		{
			Class791 class2 = (Class791)arrayList[i];
			if (!class2.imethod_7())
			{
				bool flag2 = false;
				if (class2.imethod_0() == null)
				{
					flag2 = true;
				}
				if (class2.imethod_0().Equals(""))
				{
					flag2 = true;
				}
				if (flag2)
				{
					flag = false;
					break;
				}
				bool flag3 = false;
				switch (Type.GetTypeCode(class2.imethod_0().GetType()))
				{
				case TypeCode.Boolean:
				case TypeCode.Int32:
				case TypeCode.Double:
				case TypeCode.DateTime:
					flag3 = true;
					break;
				}
				if (!flag3)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			class789_0.CategoryType = Enum64.const_2;
		}
	}

	private static bool smethod_64(Class789 class789_0)
	{
		if (class789_0.CategoryType != 0)
		{
			if (class789_0.CategoryType != Enum64.const_2)
			{
				return false;
			}
			return true;
		}
		Class787 chart = class789_0.Chart;
		ArrayList arrayList = new ArrayList();
		ArrayList[] array;
		if (class789_0.method_3() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			array = chart.method_7().method_4();
		}
		else
		{
			arrayList = chart.method_7().method_2();
			array = chart.method_7().method_7();
		}
		if (array != null)
		{
			return false;
		}
		if (arrayList.Count > 0)
		{
			Class791 @class = (Class791)arrayList[0];
			if (@class.imethod_5() && smethod_65(@class.imethod_3()))
			{
				bool flag = true;
				bool flag2 = true;
				for (int i = 1; i < arrayList.Count; i++)
				{
					Class791 class2 = (Class791)arrayList[i];
					if (!class2.imethod_7())
					{
						bool flag3 = false;
						if (class2.imethod_0() == null)
						{
							flag3 = true;
						}
						if (class2.imethod_0().Equals(""))
						{
							flag3 = true;
						}
						flag2 = false;
						if (flag3)
						{
							flag = false;
							break;
						}
						bool flag4 = false;
						switch (Type.GetTypeCode(class2.imethod_0().GetType()))
						{
						case TypeCode.Boolean:
						case TypeCode.Int32:
						case TypeCode.Double:
						case TypeCode.DateTime:
							flag4 = true;
							break;
						}
						if (!flag4)
						{
							flag = false;
							break;
						}
					}
				}
				if (flag && !flag2)
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool smethod_65(string string_0)
	{
		if (string_0 == null)
		{
			return false;
		}
		string_0 = string_0.ToLower();
		if (string_0.IndexOf("y") == -1 && string_0.IndexOf("d") == -1 && (string_0.IndexOf("m") == -1 || string_0.IndexOf("h") != -1 || string_0.IndexOf("s") != -1))
		{
			return false;
		}
		return true;
	}

	private static bool smethod_66(ChartType_Chart chartType_Chart_0)
	{
		switch (chartType_Chart_0)
		{
		default:
			return false;
		case ChartType_Chart.Bar:
		case ChartType_Chart.BarStacked:
		case ChartType_Chart.Bar100PercentStacked:
		case ChartType_Chart.Bar3DClustered:
		case ChartType_Chart.Bar3DStacked:
		case ChartType_Chart.Bar3D100PercentStacked:
			return true;
		}
	}

	private static void smethod_67(Interface42 interface42_0, Class789 class789_0, Rectangle rectangle_0, ChartType_Chart chartType_Chart_0, Class808 class808_0, bool bool_0)
	{
		Class787 chart = class789_0.Chart;
		ArrayList arrayList_ = class789_0.arrayList_1;
		ArrayList arrayList = new ArrayList();
		arrayList = ((class789_0.method_3() != 0) ? chart.method_7().method_2() : chart.method_7().method_0());
		int num = smethod_29(class808_0.method_15());
		bool flag = false;
		if (arrayList.Count == 0)
		{
			flag = true;
		}
		ArrayList arrayList2 = new ArrayList();
		if (arrayList.Count > 0)
		{
			if (num < arrayList.Count)
			{
				arrayList.RemoveRange(num, arrayList.Count - num);
			}
			ArrayList arrayList3 = new ArrayList();
			arrayList3 = (ArrayList)arrayList.Clone();
			for (int i = 0; i < arrayList3.Count; i++)
			{
				Class791 @class = (Class791)arrayList3[i];
				int num2 = smethod_69(@class.imethod_0(), class789_0.Chart.vmethod_0());
				if (num2 >= 0)
				{
					arrayList2.Add(num2);
				}
				else if (!@class.imethod_7())
				{
					flag = true;
					arrayList2.Clear();
					arrayList.Clear();
					break;
				}
			}
		}
		if (flag)
		{
			string text = "";
			text = ((class789_0.BaseUnitScale == Enum87.const_0) ? "M/d/yyyy" : ((class789_0.BaseUnitScale != Enum87.const_1) ? "yyyy" : "MMM-yy"));
			for (int j = 1; j <= num; j++)
			{
				Class791 class2 = new Class791(null, j);
				class2.imethod_2(bool_3: false);
				class2.imethod_4(text);
				arrayList.Add(class2);
				arrayList2.Add(j);
			}
		}
		for (int k = 0; k < class808_0.Count; k++)
		{
			Class810 class3 = class808_0.method_9(k);
			for (int l = 0; l < arrayList.Count; l++)
			{
				Class796 class4 = class3.method_10().method_1(l);
				if (class4 != null)
				{
					Class791 class5 = (Class791)arrayList[l];
					int num3 = smethod_69(class5.imethod_0(), class789_0.Chart.vmethod_0());
					class4.XValue = num3;
				}
			}
		}
		ArrayList arrayList4 = new ArrayList();
		arrayList4.AddRange(arrayList2);
		arrayList4.Sort();
		if (class789_0.imethod_5())
		{
			class789_0.MaxValue = Struct19.smethod_32(class789_0.BaseUnitScale, (int)arrayList4[arrayList4.Count - 1], chart.vmethod_0());
		}
		if (class789_0.imethod_3())
		{
			class789_0.MinValue = Struct19.smethod_32(class789_0.BaseUnitScale, (int)arrayList4[0], chart.vmethod_0());
		}
		if (class789_0.imethod_0())
		{
			Enum87 baseUnitScale = smethod_68(arrayList4, chart.vmethod_0());
			class789_0.BaseUnitScale = baseUnitScale;
		}
		smethod_70(interface42_0, class789_0, rectangle_0, chartType_Chart_0, bool_0, flag);
		int num4 = (int)class789_0.MinValue;
		int num5 = (int)class789_0.MaxValue;
		int num6 = num4;
		arrayList_.Clear();
		arrayList_.Add(num4);
		num6 = Struct19.smethod_31(class789_0.BaseUnitScale, class789_0.MajorUnitScale, (int)class789_0.MajorUnit, num6, chart.vmethod_0());
		while (num5 - num6 >= 0)
		{
			arrayList_.Add(num6);
			num6 = Struct19.smethod_31(class789_0.BaseUnitScale, class789_0.MajorUnitScale, (int)class789_0.MajorUnit, num6, chart.vmethod_0());
		}
	}

	private static Enum87 smethod_68(IList ilist_0, bool bool_0)
	{
		Enum87 @enum = Enum87.const_2;
		int num = 28;
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			DateTime dateTime = Struct19.smethod_26((int)ilist_0[i], bool_0);
			DateTime dateTime2 = Struct19.smethod_26((int)ilist_0[i + 1], bool_0);
			if (dateTime.AddDays(num) > dateTime2)
			{
				@enum = Enum87.const_0;
			}
			else if (dateTime.AddYears(1) > dateTime2 && @enum == Enum87.const_2)
			{
				@enum = Enum87.const_1;
			}
		}
		return @enum;
	}

	[Attribute0(true)]
	internal static int smethod_69(object object_0, bool bool_0)
	{
		int num = -10000;
		if (object_0 == null)
		{
			return num;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.DateTime:
		{
			DateTime dateTime_ = Convert.ToDateTime(object_0);
			return Struct19.smethod_27(dateTime_, bool_0);
		}
		default:
			return Struct40.smethod_22(object_0, num);
		case TypeCode.String:
			return Struct40.smethod_22(object_0, num);
		case TypeCode.Boolean:
		case TypeCode.Int32:
		case TypeCode.Double:
			return Convert.ToInt32(object_0);
		}
	}

	private static void smethod_70(Interface42 interface42_0, Class789 class789_0, Rectangle rectangle_0, ChartType_Chart chartType_Chart_0, bool bool_0, bool bool_1)
	{
		Class787 chart = class789_0.Chart;
		float num = 0f;
		string string_ = Struct19.smethod_28(class789_0, class789_0.MaxValue);
		SizeF sizeF_ = new SizeF(rectangle_0.Width, rectangle_0.Height);
		bool flag = class789_0.method_9().vmethod_1();
		Size size = Struct37.smethod_4(chart.imethod_0(), string_, 0, class789_0.method_9().Font, sizeF_, Enum82.const_1, Enum82.const_1);
		float num2;
		float num3;
		if (bool_0)
		{
			num2 = rectangle_0.Height;
			num3 = ((!flag) ? ((float)size.Height) : ((float)size.Height));
		}
		else
		{
			num2 = rectangle_0.Width;
			num3 = (flag ? ((float)size.Width) : ((class789_0.method_9().Rotation == 0) ? ((float)size.Width) : ((class789_0.method_9().Rotation == 90 || class789_0.method_9().Rotation == -90) ? ((float)size.Height) : ((float)((double)size.Height / Math.Sin((double)Math.Abs(class789_0.method_9().Rotation) * Math.PI / 180.0))))));
		}
		int num4 = (int)class789_0.MaxValue;
		int num5 = (int)class789_0.MinValue;
		Enum87 baseUnitScale = class789_0.BaseUnitScale;
		int num6;
		if (!class789_0.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num6 = Struct19.smethod_29(baseUnitScale, num4, num5, class789_0.Chart.vmethod_0());
			if (num6 == 0)
			{
				num6 = 1;
			}
		}
		else
		{
			num6 = Struct19.smethod_29(baseUnitScale, num4, num5, class789_0.Chart.vmethod_0()) + 1;
		}
		if (class789_0.imethod_7() && class789_0.imethod_9())
		{
			while (true)
			{
				if (!((float)num6 * (num3 + num) < num2))
				{
					if (!flag || bool_1)
					{
						break;
					}
					if (class789_0.method_9().Rotation == 0)
					{
						class789_0.method_9().Rotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(class789_0.method_9().Rotation) * Math.PI / 180.0));
						continue;
					}
					if (class789_0.method_9().Rotation == 45)
					{
						class789_0.method_9().Rotation = 90;
						num3 = size.Height;
					}
					break;
				}
				class789_0.MajorUnit = 1.0;
				class789_0.MinorUnit = 1.0;
				class789_0.MajorUnitScale = class789_0.BaseUnitScale;
				class789_0.MinorUnitScale = class789_0.BaseUnitScale;
				return;
			}
			if (flag && !bool_1 && class789_0.method_9().Rotation > 0)
			{
				num3 *= 2f;
			}
			int num7 = (int)(num2 / (num3 + num));
			int num8 = ((num6 % num7 == 0) ? (num6 / num7) : (num6 / num7 + 1));
			if (class789_0.BaseUnitScale == Enum87.const_0)
			{
				if (num8 <= 2)
				{
					class789_0.MajorUnit = num8;
					class789_0.MinorUnit = 1.0;
					class789_0.MajorUnitScale = class789_0.BaseUnitScale;
					class789_0.MinorUnitScale = class789_0.BaseUnitScale;
				}
				else if (num8 > 2 && num8 <= 7)
				{
					class789_0.MajorUnit = 7.0;
					class789_0.MinorUnit = 1.0;
					class789_0.MajorUnitScale = class789_0.BaseUnitScale;
					class789_0.MinorUnitScale = class789_0.BaseUnitScale;
				}
				else if (num8 > 7 && num8 <= 14)
				{
					class789_0.MajorUnit = 14.0;
					class789_0.MinorUnit = 7.0;
					class789_0.MajorUnitScale = class789_0.BaseUnitScale;
					class789_0.MinorUnitScale = class789_0.BaseUnitScale;
				}
				else if (num8 > 14 && num8 <= 30)
				{
					class789_0.MajorUnit = 1.0;
					class789_0.MinorUnit = 1.0;
					class789_0.MajorUnitScale = Enum87.const_1;
					class789_0.MinorUnitScale = Enum87.const_1;
				}
				else if (num8 > 30 && num8 <= 360)
				{
					class789_0.MajorUnit = ((num8 % 30 == 0) ? (num8 / 30) : (num8 / 30 + 1));
					class789_0.MinorUnit = (((int)(class789_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class789_0.MajorUnit / 2.0)));
					class789_0.MajorUnitScale = Enum87.const_1;
					class789_0.MinorUnitScale = Enum87.const_1;
				}
				else
				{
					class789_0.MajorUnit = ((num8 % 360 == 0) ? (num8 / 360) : (num8 / 360 + 1));
					class789_0.MinorUnit = (((int)(class789_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class789_0.MajorUnit / 2.0)));
					class789_0.MajorUnitScale = Enum87.const_2;
					class789_0.MinorUnitScale = Enum87.const_2;
				}
			}
			else if (class789_0.BaseUnitScale == Enum87.const_1)
			{
				if (num8 < 12)
				{
					class789_0.MajorUnit = num8;
					class789_0.MinorUnit = (((int)(class789_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class789_0.MajorUnit / 2.0)));
					class789_0.MajorUnitScale = Enum87.const_1;
					class789_0.MinorUnitScale = Enum87.const_1;
				}
				else
				{
					class789_0.MajorUnit = ((num8 % 12 == 0) ? (num8 / 12) : (num8 / 12 + 1));
					class789_0.MinorUnit = (((int)(class789_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class789_0.MajorUnit / 2.0)));
					class789_0.MajorUnitScale = Enum87.const_2;
					class789_0.MinorUnitScale = Enum87.const_2;
				}
			}
			else
			{
				class789_0.MajorUnit = num8;
				class789_0.MinorUnit = (((int)(class789_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class789_0.MajorUnit / 2.0)));
				class789_0.MajorUnitScale = Enum87.const_2;
				class789_0.MinorUnitScale = Enum87.const_2;
			}
		}
		else if (class789_0.imethod_7() && !class789_0.imethod_9())
		{
			int num9 = Struct40.smethod_3((float)((double)Struct19.smethod_30(class789_0.MinorUnitScale, num4, num5, class789_0.Chart.vmethod_0()) / class789_0.MinorUnit));
			if (!class789_0.AxisBetweenCategories && !chart.IsDataTableShown)
			{
				num6 = num9;
				if (num6 == 0)
				{
					num6 = 1;
				}
			}
			else
			{
				num6 = num9 + 1;
			}
			while (true)
			{
				if (!((float)num6 * (num3 + num) < num2))
				{
					if (!flag || bool_1)
					{
						break;
					}
					if (class789_0.method_9().Rotation == 0)
					{
						class789_0.method_9().Rotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(class789_0.method_9().Rotation) * Math.PI / 180.0));
						continue;
					}
					if (class789_0.method_9().Rotation == 45)
					{
						class789_0.method_9().Rotation = 90;
						num3 = size.Height;
					}
					break;
				}
				class789_0.MajorUnitScale = class789_0.MinorUnitScale;
				class789_0.MajorUnit = class789_0.MinorUnit;
				return;
			}
			if (flag && !bool_1 && class789_0.method_9().Rotation > 0)
			{
				num3 *= 2f;
			}
			int num10 = (int)(num2 / (num3 + num));
			int num11 = ((num6 % num10 == 0) ? (num6 / num10) : (num6 / num10 + 1));
			if (class789_0.BaseUnitScale == Enum87.const_0)
			{
				if (num11 <= 2)
				{
					if (class789_0.MinorUnitScale > class789_0.BaseUnitScale)
					{
						class789_0.MajorUnitScale = class789_0.MinorUnitScale;
						class789_0.MajorUnit = class789_0.MinorUnit;
						return;
					}
					class789_0.MajorUnitScale = class789_0.BaseUnitScale;
					class789_0.MajorUnit = num11;
					if (class789_0.MajorUnit < class789_0.MinorUnit)
					{
						class789_0.MajorUnit = class789_0.MinorUnit;
					}
				}
				else if (num11 > 2 && num11 <= 7)
				{
					if (class789_0.MinorUnitScale > class789_0.BaseUnitScale)
					{
						class789_0.MajorUnitScale = class789_0.MinorUnitScale;
						class789_0.MajorUnit = class789_0.MinorUnit;
						return;
					}
					class789_0.MajorUnitScale = class789_0.BaseUnitScale;
					class789_0.MajorUnit = 7.0;
					if (class789_0.MajorUnit < class789_0.MinorUnit)
					{
						class789_0.MajorUnit = class789_0.MinorUnit;
					}
				}
				else if (num11 > 7 && num11 <= 14)
				{
					if (class789_0.MinorUnitScale > class789_0.BaseUnitScale)
					{
						class789_0.MajorUnitScale = class789_0.MinorUnitScale;
						class789_0.MajorUnit = class789_0.MinorUnit;
						return;
					}
					class789_0.MajorUnitScale = class789_0.BaseUnitScale;
					class789_0.MajorUnit = 14.0;
					if (class789_0.MajorUnit < class789_0.MinorUnit)
					{
						class789_0.MajorUnit = class789_0.MinorUnit;
					}
				}
				else if (num11 > 14 && num11 <= 30)
				{
					if (class789_0.MinorUnitScale == Enum87.const_2)
					{
						class789_0.MajorUnitScale = class789_0.MinorUnitScale;
						class789_0.MajorUnit = class789_0.MinorUnit;
						return;
					}
					class789_0.MajorUnitScale = Enum87.const_1;
					class789_0.MajorUnit = 1.0;
					if (class789_0.MajorUnit < class789_0.MinorUnit && class789_0.MinorUnitScale == Enum87.const_1)
					{
						class789_0.MajorUnit = class789_0.MinorUnit;
					}
				}
				else if (num11 > 30 && num11 <= 360)
				{
					if (class789_0.MinorUnitScale == Enum87.const_2)
					{
						class789_0.MajorUnitScale = class789_0.MinorUnitScale;
						class789_0.MajorUnit = class789_0.MinorUnit;
						return;
					}
					class789_0.MajorUnitScale = Enum87.const_1;
					class789_0.MajorUnit = ((num11 % 30 == 0) ? (num11 / 30) : (num11 / 30 + 1));
					if (class789_0.MajorUnit < class789_0.MinorUnit && class789_0.MinorUnitScale == Enum87.const_1)
					{
						class789_0.MajorUnit = class789_0.MinorUnit;
					}
				}
				else
				{
					class789_0.MajorUnit = ((num11 % 360 == 0) ? (num11 / 360) : (num11 / 360 + 1));
					class789_0.MajorUnitScale = Enum87.const_2;
					if (class789_0.MajorUnit < class789_0.MinorUnit && class789_0.MinorUnitScale == Enum87.const_2)
					{
						class789_0.MajorUnit = class789_0.MinorUnit;
					}
				}
			}
			else if (class789_0.BaseUnitScale == Enum87.const_1)
			{
				if (num11 < 12)
				{
					if (class789_0.MinorUnitScale == Enum87.const_1)
					{
						if (class789_0.MinorUnit <= (double)num11)
						{
							class789_0.MajorUnit = num11;
							class789_0.MajorUnitScale = Enum87.const_1;
						}
						else
						{
							class789_0.MajorUnit = class789_0.MinorUnit;
							class789_0.MajorUnitScale = Enum87.const_1;
						}
					}
					else
					{
						class789_0.MajorUnit = class789_0.MinorUnit;
						class789_0.MajorUnitScale = Enum87.const_2;
					}
					return;
				}
				num11 = ((num11 % 12 == 0) ? (num11 / 12) : (num11 / 12 + 1));
				if (class789_0.MinorUnitScale == Enum87.const_1)
				{
					class789_0.MajorUnit = num11;
					class789_0.MajorUnitScale = Enum87.const_2;
				}
				else if (class789_0.MinorUnit <= (double)num11)
				{
					class789_0.MajorUnit = num11;
					class789_0.MajorUnitScale = Enum87.const_2;
				}
				else
				{
					class789_0.MajorUnit = class789_0.MinorUnit;
					class789_0.MajorUnitScale = Enum87.const_2;
				}
			}
			else
			{
				if (class789_0.MinorUnit <= (double)num11)
				{
					class789_0.MajorUnit = num11;
				}
				else
				{
					class789_0.MajorUnit = class789_0.MinorUnit;
				}
				class789_0.MajorUnitScale = Enum87.const_2;
			}
		}
		else if (!class789_0.imethod_7() && class789_0.imethod_9())
		{
			class789_0.MinorUnit = (((int)(class789_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class789_0.MajorUnit / 2.0)));
			class789_0.MinorUnitScale = class789_0.MajorUnitScale;
			if (!flag || bool_1)
			{
				return;
			}
			int num12 = Struct40.smethod_3((float)((double)Struct19.smethod_30(class789_0.MajorUnitScale, num4, num5, class789_0.Chart.vmethod_0()) / class789_0.MajorUnit));
			if (!class789_0.AxisBetweenCategories && !chart.IsDataTableShown)
			{
				num6 = num12;
				if (num6 == 0)
				{
					num6 = 1;
				}
			}
			else
			{
				num6 = num12 + 1;
			}
			while (true)
			{
				if ((float)num6 * (num3 + num) > num2)
				{
					if (class789_0.method_9().Rotation == 0)
					{
						class789_0.method_9().Rotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(class789_0.method_9().Rotation) * Math.PI / 180.0));
					}
					else if (class789_0.method_9().Rotation == 45)
					{
						break;
					}
					continue;
				}
				return;
			}
			class789_0.method_9().Rotation = 90;
		}
		else
		{
			if (!flag || bool_1)
			{
				return;
			}
			int num13 = Struct40.smethod_3((float)((double)Struct19.smethod_30(class789_0.MajorUnitScale, num4, num5, class789_0.Chart.vmethod_0()) / class789_0.MajorUnit));
			if (!class789_0.AxisBetweenCategories && !chart.IsDataTableShown)
			{
				num6 = num13;
				if (num6 == 0)
				{
					num6 = 1;
				}
			}
			else
			{
				num6 = num13 + 1;
			}
			while (true)
			{
				if ((float)num6 * (num3 + num) > num2)
				{
					if (class789_0.method_9().Rotation == 0)
					{
						class789_0.method_9().Rotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(class789_0.method_9().Rotation) * Math.PI / 180.0));
					}
					else if (class789_0.method_9().Rotation == 45)
					{
						break;
					}
					continue;
				}
				return;
			}
			class789_0.method_9().Rotation = 90;
		}
	}

	internal static ArrayList smethod_71(IList ilist_0, bool bool_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			int num = smethod_69(((Class791)ilist_0[i]).imethod_0(), bool_0);
			arrayList.Add(num);
		}
		return arrayList;
	}

	internal static void smethod_72(Interface42 interface42_0, Class789 class789_0, double double_0, double double_1, ArrayList arrayList_0, ChartType_Chart chartType_Chart_0, Rectangle rectangle_0, bool bool_0, Class810 class810_0)
	{
		double double_2 = double_0;
		double double_3 = double_1;
		_ = class789_0.Chart;
		if (double_0 == double_1 && double_0 == 0.0)
		{
			class789_0.MaxValue = 10.0;
			double_0 = 10.0;
			double_2 = 10.0;
			class789_0.MinValue = 1.0;
		}
		bool bool_ = class789_0.imethod_5();
		bool bool_2 = class789_0.imethod_3();
		double double_4 = 0.0;
		int int_ = 1;
		bool bool_3;
		if (bool_3 = class810_0.method_32())
		{
			if (double_0 == 100.0 && class789_0.imethod_5())
			{
				class789_0.MaxValue = 100.0;
			}
			if (double_1 >= 1.0 && class789_0.imethod_3())
			{
				class789_0.MinValue = 1.0;
			}
		}
		double double_5 = 0.0;
		double double_6 = 0.0;
		smethod_73(ref double_5, ref double_6, ref double_1, ref double_0, ref double_4, ref int_, class789_0, bool_0);
		smethod_74(class789_0, int_, double_4, double_6, double_5, arrayList_0, double_2, double_3, bool_, bool_2, bool_3);
		int num = smethod_75(interface42_0, class789_0, bool_0, class810_0, rectangle_0);
		int num2 = 0;
		num2 = (class789_0.Chart.method_15() ? ((!bool_0) ? ((int)class789_0.Chart.method_13().Height) : ((int)class789_0.Chart.method_13().Width)) : ((!bool_0) ? rectangle_0.Height : rectangle_0.Width));
		while (class789_0.imethod_7() && arrayList_0.Count > 3 && num > num2 && num2 != 0)
		{
			double_4 += 1.0;
			smethod_74(class789_0, int_, double_4, double_6, double_5, arrayList_0, double_2, double_3, bool_, bool_2, bool_3);
			num = smethod_75(interface42_0, class789_0, bool_0, class810_0, rectangle_0);
		}
		if (arrayList_0.Count >= 2)
		{
			class789_0.MaxValue = Struct40.smethod_8((double)arrayList_0[0]);
			class789_0.MinValue = Struct40.smethod_8((double)arrayList_0[arrayList_0.Count - 1]);
			if (class789_0.imethod_7())
			{
				class789_0.MajorUnit = Struct40.smethod_8(double_4);
			}
			if (class789_0.imethod_9())
			{
				class789_0.MinorUnit = class789_0.MajorUnit;
			}
		}
	}

	private static void smethod_73(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref int int_4, Class789 class789_0, bool bool_0)
	{
		double_4 = 1.0;
		double num;
		double num2;
		if (class789_0.imethod_7())
		{
			num = smethod_77(double_2);
			num2 = smethod_76(double_3);
			double_1 = num;
			double_0 = num2;
			if (class789_0.imethod_5() && class789_0.imethod_3())
			{
				int_4 = 3;
				if (num >= 0.0 && num2 >= 0.0)
				{
					class789_0.MinValue = Struct40.smethod_8(0.0);
					int_4 = 2;
					double_1 = 0.0;
				}
				else
				{
					class789_0.MinValue = Struct40.smethod_8(num);
					int_4 = 2;
					double_1 = num;
				}
			}
			else if (!class789_0.imethod_5() && class789_0.imethod_3())
			{
				int_4 = 1;
				double_0 = Struct40.smethod_7(class789_0.MaxValue);
				double_3 = double_0;
			}
			else if (class789_0.imethod_5() && !class789_0.imethod_3())
			{
				int_4 = 2;
				double_1 = Struct40.smethod_7(class789_0.MinValue);
				double_2 = double_1;
			}
			else
			{
				int_4 = 2;
				double_1 = Struct40.smethod_7(class789_0.MinValue);
				double_0 = Struct40.smethod_7(class789_0.MaxValue);
				double_2 = Struct40.smethod_7(class789_0.MinValue);
				double_3 = Struct40.smethod_7(class789_0.MaxValue);
			}
			return;
		}
		double_4 = Struct40.smethod_7(class789_0.MajorUnit);
		num = (int)double_2;
		num2 = (double)(int)double_3 + double_4;
		double_1 = num;
		double_0 = num2;
		if (class789_0.imethod_5() && class789_0.imethod_3())
		{
			int_4 = 3;
			if (num >= 0.0 && num2 >= 0.0)
			{
				class789_0.MinValue = Struct40.smethod_8(0.0);
				int_4 = 2;
				double_1 = 0.0;
			}
			else
			{
				class789_0.MinValue = Struct40.smethod_8(num);
				int_4 = 2;
				double_1 = num;
			}
		}
		else if (!class789_0.imethod_5() && class789_0.imethod_3())
		{
			int_4 = 1;
			double_0 = Struct40.smethod_7(class789_0.MaxValue);
			double_3 = double_0;
		}
		else if (class789_0.imethod_5() && !class789_0.imethod_3())
		{
			int_4 = 2;
			double_1 = Struct40.smethod_7(class789_0.MinValue);
			double_2 = double_1;
		}
		else
		{
			int_4 = 2;
			double_1 = Struct40.smethod_7(class789_0.MinValue);
			double_0 = Struct40.smethod_7(class789_0.MaxValue);
			double_2 = Struct40.smethod_7(class789_0.MinValue);
			double_3 = Struct40.smethod_7(class789_0.MaxValue);
		}
	}

	private static void smethod_74(Class789 class789_0, int int_4, double double_0, double double_1, double double_2, ArrayList arrayList_0, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		arrayList_0.Clear();
		switch (int_4)
		{
		case 1:
		{
			double num = double_2;
			while (num >= double_1 || Struct40.smethod_10(double_1, num) < double_0)
			{
				if (!class789_0.imethod_3() && num < class789_0.method_13())
				{
					arrayList_0.Add(class789_0.method_13());
				}
				else
				{
					arrayList_0.Add(num);
				}
				num -= double_0;
			}
			return;
		}
		case 2:
		{
			for (double num2 = double_1; num2 <= double_2 || num2 < double_2 + double_0; num2 += double_0)
			{
				if (!class789_0.imethod_5() && num2 > class789_0.method_12())
				{
					arrayList_0.Add(class789_0.method_12());
				}
				else
				{
					arrayList_0.Add(num2);
				}
			}
			arrayList_0.Reverse();
			return;
		}
		}
		double num3;
		for (num3 = 0.0; num3 <= double_2 || Struct40.smethod_10(num3, double_2) < double_0; num3 += double_0)
		{
			if (!class789_0.imethod_5() && num3 > class789_0.method_12())
			{
				arrayList_0.Add(class789_0.method_12());
			}
			else
			{
				arrayList_0.Add(num3);
			}
		}
		arrayList_0.Reverse();
		num3 = 0.0 - double_0;
		while (num3 >= double_1 || Struct40.smethod_10(double_1, num3) < double_0)
		{
			if (!class789_0.imethod_3() && num3 < class789_0.method_13())
			{
				arrayList_0.Add(class789_0.method_13());
			}
			else
			{
				arrayList_0.Add(num3);
			}
			num3 -= double_0;
		}
	}

	private static int smethod_75(Interface42 interface42_0, Class789 class789_0, bool bool_0, Class810 class810_0, Rectangle rectangle_0)
	{
		if (class789_0.TickLabelPosition == Enum83.const_3)
		{
			return 0;
		}
		Class811 @class = class789_0.method_9();
		Class796 class2 = class810_0.method_10().method_1(0);
		string string_ = class2.vmethod_6();
		bool bool_ = class2.vmethod_7();
		bool flag = false;
		if (@class.LinkedSource && class2 != null)
		{
			flag = true;
		}
		int num = 0;
		for (int i = 0; i < class789_0.arrayList_1.Count; i++)
		{
			double num2 = Struct40.smethod_8((double)class789_0.arrayList_1[i]);
			if (class810_0.method_32())
			{
				num2 /= 100.0;
				string_ = "0%";
			}
			string text = "";
			Size size = Struct37.smethod_12(string_0: (!flag) ? Struct19.smethod_28(class789_0, num2) : Struct26.smethod_6(class789_0.Chart.vmethod_2(), num2, string_, bool_), size_0: new Size(rectangle_0.Width, rectangle_0.Height), interface42_0: class789_0.Chart.imethod_0(), int_0: @class.Rotation, font_0: @class.Font, enum82_0: Enum82.const_1, enum82_1: Enum82.const_1);
			num = ((!bool_0) ? ((i == 0 || i == class789_0.arrayList_1.Count - 1) ? (num + size.Height / 2) : (num + size.Height)) : ((i == 0 || i == class789_0.arrayList_1.Count - 1) ? (num + size.Width / 2) : (num + size.Width)));
			num = ((i == 0 || i == class789_0.arrayList_1.Count - 1) ? (num - 1) : (num - 2));
		}
		return (int)((double)num + 0.5);
	}

	private static double smethod_76(double double_0)
	{
		bool flag = true;
		if (double_0 < 0.0)
		{
			flag = false;
		}
		double_0 = Math.Abs(double_0);
		if (flag)
		{
			double num = Struct40.smethod_4(double_0);
			if (num != double_0)
			{
				num += 1.0;
			}
			return num;
		}
		double num2 = Struct40.smethod_4(double_0);
		return 0.0 - num2;
	}

	private static double smethod_77(double double_0)
	{
		bool flag = true;
		if (double_0 < 0.0)
		{
			flag = false;
		}
		double_0 = Math.Abs(double_0);
		if (!flag)
		{
			double num = Struct40.smethod_4(double_0);
			if (num != double_0)
			{
				num += 1.0;
			}
			return 0.0 - num;
		}
		return Struct40.smethod_4(double_0);
	}

	private static bool smethod_78(Class787 class787_0)
	{
		int num = 0;
		while (true)
		{
			if (num < class787_0.NSeries.Count)
			{
				Interface28 @interface = class787_0.NSeries[num];
				if (@interface.Type == ChartType_Chart.Radar || @interface.Type == ChartType_Chart.RadarFilled || @interface.Type == ChartType_Chart.RadarWithDataMarkers)
				{
					break;
				}
				num++;
				continue;
			}
			int num2 = 0;
			while (true)
			{
				if (num2 < class787_0.NSeries.Count)
				{
					Interface28 interface2 = class787_0.NSeries[num2];
					if (interface2.PlotOnSecondAxis)
					{
						break;
					}
					num2++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private static void smethod_79(Interface9 interface9_0, Interface9 interface9_1)
	{
		if (!interface9_0.IsVisible)
		{
			interface9_0.AxisBetweenCategories = interface9_1.AxisBetweenCategories;
			interface9_0.CategoryType = interface9_1.CategoryType;
			interface9_0.imethod_1(interface9_1.imethod_0());
			if (!interface9_1.imethod_0())
			{
				interface9_0.BaseUnitScale = interface9_1.BaseUnitScale;
			}
			interface9_0.MajorUnitScale = interface9_1.MajorUnitScale;
			interface9_0.MinorUnitScale = interface9_1.MinorUnitScale;
			interface9_0.IsPlotOrderReversed = interface9_1.IsPlotOrderReversed;
			interface9_0.imethod_8(interface9_1.imethod_7());
			if (!interface9_1.imethod_7())
			{
				interface9_0.MajorUnit = interface9_1.MajorUnit;
			}
			interface9_0.imethod_10(interface9_1.imethod_9());
			if (!interface9_1.imethod_9())
			{
				interface9_0.MinorUnit = interface9_1.MinorUnit;
			}
			interface9_0.imethod_6(interface9_1.imethod_5());
			if (!interface9_1.imethod_5())
			{
				interface9_0.MaxValue = interface9_1.MaxValue;
			}
			interface9_0.imethod_4(interface9_1.imethod_3());
			if (!interface9_1.imethod_3())
			{
				interface9_0.MinValue = interface9_1.MinValue;
			}
		}
	}

	private static void smethod_80(Class787 class787_0)
	{
		for (int i = 0; i < class787_0.method_7().method_2().Count; i++)
		{
			Interface11 @interface = (Interface11)class787_0.method_7().method_2()[i];
			Interface11 interface2 = new Class791(null, @interface.imethod_0());
			interface2.imethod_2(@interface.imethod_1());
			interface2.imethod_6(@interface.imethod_5());
			interface2.imethod_8(@interface.imethod_7());
			interface2.imethod_4(@interface.imethod_3());
			class787_0.method_7().method_6().Add(interface2);
		}
		class787_0.method_7().method_2().Clear();
		for (int j = 0; j < class787_0.method_7().method_0().Count; j++)
		{
			Interface11 interface3 = (Interface11)class787_0.method_7().method_0()[j];
			Interface11 interface4 = new Class791(null, interface3.imethod_0());
			interface4.imethod_2(interface3.imethod_1());
			interface4.imethod_6(interface3.imethod_5());
			interface4.imethod_8(interface3.imethod_7());
			interface4.imethod_4(interface3.imethod_3());
			class787_0.method_7().method_2().Add(interface4);
		}
	}

	internal static ArrayList[] smethod_81(Interface10 interface10_0)
	{
		ArrayList[] array = null;
		int num = smethod_83(interface10_0);
		if (num > 1)
		{
			array = new ArrayList[num - 1];
			for (int i = 0; i < num - 1; i++)
			{
				array[i] = new ArrayList();
				smethod_84(interface10_0, i, 0, array[i]);
			}
		}
		return array;
	}

	internal static ArrayList smethod_82(Interface10 interface10_0)
	{
		ArrayList arrayList = null;
		arrayList = new ArrayList();
		int num = smethod_83(interface10_0);
		smethod_84(interface10_0, num - 1, 0, arrayList);
		return arrayList;
	}

	private static int smethod_83(Interface10 interface10_0)
	{
		if (interface10_0.Count == 0)
		{
			return 0;
		}
		Interface11 @interface = interface10_0[0];
		int num = 1;
		while (@interface.imethod_9().Count > 0)
		{
			num++;
			@interface = @interface.imethod_9()[0];
		}
		return num;
	}

	private static void smethod_84(Interface10 interface10_0, int int_4, int int_5, ArrayList arrayList_0)
	{
		if (int_4 == int_5)
		{
			for (int i = 0; i < interface10_0.Count; i++)
			{
				Interface11 value = interface10_0[i];
				arrayList_0.Add(value);
			}
		}
		else
		{
			for (int j = 0; j < interface10_0.Count; j++)
			{
				Interface11 @interface = interface10_0[j];
				smethod_84(@interface.imethod_9(), int_4, int_5 + 1, arrayList_0);
			}
		}
	}
}
