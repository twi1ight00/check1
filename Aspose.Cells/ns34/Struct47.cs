using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns22;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct47
{
	public static int int_0 = 10;

	public static int int_1 = 8;

	public static int int_2 = 14;

	internal static void Calculate(Class821 class821_0)
	{
		Interface42 interface42_ = class821_0.imethod_0();
		Class842 @class = class821_0.method_7();
		if (class821_0.method_7().Count == 0 || smethod_32(class821_0.method_7().method_15()) == 0)
		{
			return;
		}
		string text = smethod_1(class821_0);
		if (text != "")
		{
			throw new ArgumentException(text);
		}
		Class842 class2 = new Class842(class821_0);
		Class842 class3 = new Class842(class821_0);
		foreach (Class844 item in @class)
		{
			if (item.method_20() == Enum53.const_0)
			{
				class2.Add(item);
			}
			else
			{
				class3.Add(item);
			}
		}
		if (!class821_0.imethod_3().IsVisible && smethod_82(class821_0))
		{
			class821_0.method_2().bool_13 = true;
			class821_0.method_1().bool_13 = true;
		}
		smethod_3(class821_0, class2, class3);
		smethod_8(class821_0);
		if (class821_0.NSeries.imethod_0().Count > 0)
		{
			class821_0.method_7().bool_0 = true;
		}
		if (class821_0.NSeries.imethod_1().Count > 0)
		{
			class821_0.method_7().bool_1 = true;
		}
		class821_0.method_7().method_5(smethod_85(class821_0.method_7().imethod_0()));
		class821_0.method_7().method_8(smethod_85(class821_0.method_7().imethod_1()));
		class821_0.method_7().method_1(smethod_86(class821_0.method_7().imethod_0()));
		class821_0.method_7().method_3(smethod_86(class821_0.method_7().imethod_1()));
		if (!class821_0.imethod_3().IsVisible && smethod_82(class821_0))
		{
			smethod_83(class821_0.imethod_3(), class821_0.CategoryAxis);
			smethod_84(class821_0);
		}
		Struct63.smethod_1(class821_0.method_1(), class821_0.method_7().method_0(), class2);
		Struct63.smethod_1(class821_0.method_2(), class821_0.method_7().method_2(), class3);
		Class844 class5 = class2.method_9(0);
		Class844 class6 = new Class844(class821_0, null, ChartType_Chart.Column);
		if (class3.Count > 0)
		{
			class6 = (Class844)class3[0];
		}
		Struct63.smethod_6(class821_0.method_1(), class821_0.method_9(), class2, class5);
		Struct63.smethod_6(class821_0.method_2(), class821_0.method_10(), class3, class6);
		bool flag = smethod_10(class5.method_22());
		bool flag2 = smethod_10(class6.method_22());
		smethod_27(class821_0, flag, flag2);
		bool flag3 = Struct53.smethod_6(class821_0);
		class821_0.method_6().bool_0 = flag3;
		smethod_6(class821_0);
		Rectangle rectangle_ = new Rectangle(int_0 + class821_0.Position.X, int_0 + class821_0.Position.Y, class821_0.Position.Width - int_0 * 2, class821_0.Position.Height - int_0 * 2);
		if (class821_0.method_12().IsVisible)
		{
			SizeF sizeF_ = new SizeF((float)rectangle_.Width * 0.8f, (float)rectangle_.Height * 0.5f);
			Size size = class821_0.method_12().method_3(sizeF_);
			class821_0.method_12().method_0().rectangle_1.X = (class821_0.Width - size.Width) / 2;
			class821_0.method_12().method_0().rectangle_1.Y = class821_0.Position.Y + int_0;
			class821_0.method_12().method_0().rectangle_1.Size = size;
			rectangle_.Y += size.Height + int_1;
			rectangle_.Height -= size.Height + int_1;
		}
		if (class821_0.IsLegendShown)
		{
			if (class3.Count == 0 && (class5.method_22() == ChartType_Chart.Pie || class5.method_22() == ChartType_Chart.Doughnut || flag3))
			{
				Class844 class7 = class5;
				if (class5.Type == ChartType_Chart.Doughnut || class5.Type == ChartType_Chart.DoughnutExploded)
				{
					for (int i = 1; i < class821_0.method_7().Count; i++)
					{
						if (class821_0.method_7()[i].Points != null && class7.method_9() != null && class821_0.method_7()[i].Points.Count > class7.method_9().Count)
						{
							class7 = class821_0.method_7().method_9(i);
						}
					}
				}
				Struct53.smethod_15(interface42_, class821_0.method_6(), class7, ref rectangle_);
			}
			else
			{
				smethod_30(class821_0);
				Struct53.smethod_16(interface42_, class821_0.method_6(), ref rectangle_);
			}
		}
		if (class821_0.method_1().method_11().IsVisible)
		{
			smethod_11(class821_0.method_1(), flag);
			SizeF sizeF = default(SizeF);
			sizeF = ((!flag) ? new SizeF((float)class821_0.Width * 0.9f, (float)class821_0.Height * 0.9f) : new SizeF((float)class821_0.Width * 0.9f, (float)class821_0.Height * 0.9f));
			Size size_ = class821_0.method_1().method_11().method_3(sizeF);
			if (class821_0.method_9().CrossType == Enum66.const_1 && !class821_0.method_9().IsPlotOrderReversed)
			{
				class821_0.method_1().bool_10 = false;
			}
			else if (class821_0.method_9().CrossType != Enum66.const_1 && class821_0.method_9().IsPlotOrderReversed)
			{
				class821_0.method_1().bool_10 = false;
			}
			smethod_13(class821_0.method_1(), ref rectangle_, flag, size_);
		}
		if (class821_0.method_9().method_11().IsVisible)
		{
			smethod_11(class821_0.method_9(), flag);
			SizeF sizeF2 = default(SizeF);
			sizeF2 = ((!flag) ? new SizeF((float)class821_0.Width * 0.9f, (float)class821_0.Height * 0.9f) : new SizeF((float)class821_0.Width * 0.9f, (float)class821_0.Height * 0.9f));
			Size size_2 = class821_0.method_9().method_11().method_3(sizeF2);
			if (class821_0.method_1().CrossType == Enum66.const_1 && !class821_0.method_1().IsPlotOrderReversed)
			{
				class821_0.method_9().bool_10 = false;
			}
			else if (class821_0.method_1().CrossType != Enum66.const_1 && class821_0.method_1().IsPlotOrderReversed)
			{
				class821_0.method_9().bool_10 = false;
			}
			smethod_13(class821_0.method_9(), ref rectangle_, flag, size_2);
		}
		if (class821_0.method_2().method_11().IsVisible && class3.Count > 0)
		{
			smethod_11(class821_0.method_2(), flag2);
			SizeF sizeF3 = default(SizeF);
			sizeF3 = ((!flag) ? new SizeF((float)class821_0.Width * 0.9f, (float)class821_0.Height * 0.9f) : new SizeF((float)class821_0.Width * 0.9f, (float)class821_0.Height * 0.9f));
			Size size_3 = class821_0.method_2().method_11().method_3(sizeF3);
			if (flag == flag2)
			{
				class821_0.method_2().bool_10 = !class821_0.method_1().bool_10;
			}
			else
			{
				class821_0.method_2().bool_10 = !class821_0.method_9().bool_10;
			}
			smethod_13(class821_0.method_2(), ref rectangle_, flag2, size_3);
		}
		if (class821_0.method_10().method_11().IsVisible && class3.Count > 0)
		{
			smethod_11(class821_0.method_10(), flag2);
			SizeF sizeF4 = default(SizeF);
			sizeF4 = ((!flag) ? new SizeF((float)class821_0.Width * 0.9f, (float)class821_0.Height * 0.9f) : new SizeF((float)class821_0.Width * 0.9f, (float)class821_0.Height * 0.9f));
			Size size_4 = class821_0.method_10().method_11().method_3(sizeF4);
			if (flag == flag2)
			{
				class821_0.method_10().bool_10 = !class821_0.method_9().bool_10;
			}
			else
			{
				class821_0.method_10().bool_10 = !class821_0.method_1().bool_10;
			}
			smethod_13(class821_0.method_10(), ref rectangle_, flag2, size_4);
		}
		Struct53.smethod_3(class821_0.method_6(), rectangle_);
		Rectangle rectangle_2 = new Rectangle(0, 0, class821_0.Width, class821_0.Height);
		if (!class821_0.method_8().imethod_3())
		{
			if (class821_0.method_8().vmethod_0().Y < 0)
			{
				class821_0.method_8().Height += class821_0.method_8().vmethod_0().Y;
				class821_0.method_8().Y = 0;
			}
			if (class821_0.method_8().vmethod_0().X < 0)
			{
				class821_0.method_8().Width += class821_0.method_8().vmethod_0().X;
				class821_0.method_8().X = 0;
			}
			if (class821_0.method_8().Width + class821_0.method_8().X > 4000)
			{
				class821_0.method_8().Width = 4000 - class821_0.method_8().X;
			}
			if (class821_0.method_8().Height + class821_0.method_8().Y > 4000)
			{
				class821_0.method_8().Height = 4000 - class821_0.method_8().Y;
			}
			rectangle_.X = class821_0.method_8().method_7();
			rectangle_.Y = class821_0.method_8().method_8();
			rectangle_.Width = class821_0.method_8().method_5();
			rectangle_.Height = class821_0.method_8().method_6();
			if (rectangle_.Right > class821_0.Width)
			{
				rectangle_.Width = class821_0.Width - rectangle_.X;
			}
			if (rectangle_.Bottom > class821_0.Height)
			{
				rectangle_.Height = class821_0.Height - rectangle_.Y;
			}
		}
		class821_0.method_28(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		class821_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		Rectangle rectangle = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		bool flag4 = false;
		bool flag5 = smethod_68(class821_0.method_1()) || smethod_70(class821_0.Type);
		int num = 0;
		if (!Struct63.smethod_18(rectangle_) && class821_0.IsDataTableShown)
		{
			smethod_29(class821_0);
			if (!flag && !flag2 && !flag5)
			{
				class821_0.method_1().int_4 = 0;
				class821_0.CategoryAxis.MajorTickMark = Enum84.const_2;
				class821_0.CategoryAxis.MinorTickMark = Enum84.const_2;
				class821_0.method_2().int_4 = 0;
				class821_0.imethod_3().MajorTickMark = Enum84.const_2;
				class821_0.imethod_3().MinorTickMark = Enum84.const_2;
				flag4 = true;
			}
			Size size_5 = Struct49.smethod_4(interface42_, class821_0.method_4());
			class821_0.method_4().method_2(size_5);
			int num2 = Struct49.smethod_6(interface42_, class821_0.method_4(), rectangle_);
			class821_0.method_4().method_4(num2);
			num = size_5.Height + num2;
			if (class821_0.method_8().imethod_3())
			{
				rectangle_.X += size_5.Width;
				rectangle_.Width -= size_5.Width;
				rectangle_.Height -= num;
				if (flag5)
				{
					class821_0.method_4().rectangle_0.X = rectangle_.X;
					class821_0.method_4().rectangle_0.Y = rectangle_.Bottom;
					class821_0.method_4().rectangle_0.Width = rectangle_.Width;
					rectangle_.Height -= int_2;
				}
			}
			else if (class821_0.IsInnerMode)
			{
				class821_0.int_12 -= size_5.Width;
				class821_0.int_14 += size_5.Width;
				class821_0.int_15 += num;
				if (flag5)
				{
					class821_0.method_4().rectangle_0.Y = rectangle_.Bottom + int_2;
				}
			}
			else
			{
				rectangle_.X += size_5.Width;
				rectangle_.Width -= size_5.Width;
				rectangle_.Height -= num;
				if (flag5)
				{
					class821_0.method_4().rectangle_0.X = rectangle_.X;
					class821_0.method_4().rectangle_0.Y = rectangle_.Bottom;
					class821_0.method_4().rectangle_0.Width = rectangle_.Width;
					rectangle_.Height -= int_2;
				}
			}
		}
		int num3 = smethod_32(class2.method_15());
		int num4 = smethod_32(class3.method_15());
		bool flag6 = false;
		double minValue;
		double maxValue;
		if (smethod_38(class821_0, class2.method_15(), class3.method_15()))
		{
			Class823 class8 = smethod_39(class821_0);
			flag6 = smethod_41(class2.method_15(), class3.method_15(), out minValue, out maxValue, class8);
			class821_0.double_0 = minValue;
			class821_0.double_1 = maxValue;
			class821_0.bool_8 = true;
			class821_0.class823_5 = class8;
		}
		else
		{
			flag6 = smethod_33(class2.method_15(), out minValue, out maxValue, class821_0.method_9());
		}
		double double_ = maxValue;
		double double_2 = minValue;
		bool flag7 = class821_0.method_9().imethod_7();
		bool flag8 = class821_0.method_9().imethod_9();
		bool flag9 = class821_0.method_9().imethod_5();
		bool flag10 = class821_0.method_9().imethod_3();
		if (class821_0.bool_8)
		{
			if (class821_0.class823_5 == class821_0.method_9())
			{
				smethod_47(interface42_, class821_0.method_9(), maxValue, minValue, flag6, class821_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
			}
			else
			{
				smethod_47(interface42_, class821_0.method_10(), maxValue, minValue, flag6, class821_0.method_10().arrayList_1, class6.method_22(), rectangle_, flag2, class3.method_9(0));
			}
			if (class5.method_34() && class6.method_34())
			{
				double minValue2;
				double maxValue2;
				bool bool_ = smethod_33(class2.method_15(), out minValue2, out maxValue2, class821_0.method_9());
				smethod_47(interface42_, class821_0.method_9(), maxValue2, minValue2, bool_, class821_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
				flag6 = smethod_33(class3.method_15(), out minValue2, out maxValue2, class821_0.method_10());
				smethod_47(interface42_, class821_0.method_10(), maxValue2, minValue2, bool_, class821_0.method_10().arrayList_1, class6.method_22(), rectangle_, flag2, class3.method_9(0));
				smethod_44(class821_0.method_9());
				smethod_44(class821_0.method_10());
			}
			Class823 class823_ = smethod_40(class821_0);
			smethod_43(class823_, class821_0.class823_5);
		}
		else
		{
			smethod_47(interface42_, class821_0.method_9(), maxValue, minValue, flag6, class821_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
		}
		bool flag11 = class821_0.method_1().imethod_7();
		bool flag12 = class821_0.method_1().imethod_9();
		bool flag13 = class821_0.method_1().imethod_5();
		bool flag14 = class821_0.method_1().imethod_3();
		new Class842(class821_0);
		if (class821_0.method_1().bool_13)
		{
			smethod_64(interface42_, class821_0.method_1(), class821_0.method_1().arrayList_1, rectangle_, class5.method_22(), @class, flag);
		}
		else
		{
			smethod_64(interface42_, class821_0.method_1(), class821_0.method_1().arrayList_1, rectangle_, class5.method_22(), class2, flag);
		}
		if (!Struct63.smethod_18(rectangle_) && class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled)
		{
			smethod_20(class821_0.method_9(), class821_0.method_1(), class2, class821_0);
			Size size_6 = Struct44.smethod_19(interface42_, class821_0.method_9(), class5, flag);
			smethod_12(class821_0.method_9(), flag);
			SizeF sizeF5 = default(SizeF);
			sizeF5 = (flag ? new SizeF(rectangle.Width, rectangle.Height) : new SizeF(rectangle.Width, rectangle.Height));
			Size size_7 = class821_0.method_9().method_12().method_4(sizeF5);
			smethod_21(class821_0, interface42_, class821_0.method_9(), size_6, size_7, ref rectangle_, flag);
		}
		if (!Struct63.smethod_18(rectangle_) && !flag4 && class821_0.method_1().IsVisible && class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled)
		{
			smethod_20(class821_0.method_1(), class821_0.method_9(), class2, class821_0);
			Size size_8 = Struct44.smethod_20(interface42_, class821_0.method_1(), rectangle_, rectangle_2, num3, flag, class5);
			int num5 = (int)((double)(class821_0.method_1().method_10().method_1() + class821_0.method_1().method_19() + class821_0.method_1().method_21()) + 0.5);
			if (class821_0.method_7().method_4() != null)
			{
				num5 += num5 * class821_0.method_7().method_4().Length;
			}
			if (class5.method_22() == ChartType_Chart.Scatter || class5.method_22() == ChartType_Chart.Bubble)
			{
				smethod_12(class821_0.method_1(), flag);
				SizeF sizeF6 = default(SizeF);
				sizeF6 = ((!flag) ? new SizeF(rectangle.Width, rectangle.Height) : new SizeF(rectangle.Width, rectangle.Height));
				num5 += class821_0.method_1().method_12().method_4(sizeF6)
					.Height;
			}
			smethod_23(class821_0, interface42_, class821_0.method_1(), size_8, num5, ref rectangle_, flag, flag5);
			if (class821_0.method_8().imethod_3() && class821_0.method_9().IsVisible && class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled)
			{
				int num6 = smethod_51(interface42_, class821_0.method_9(), flag, class5, rectangle_);
				int num7 = 0;
				num7 = ((!flag) ? rectangle_.Height : rectangle_.Width);
				if (flag7 && class821_0.method_9().arrayList_1.Count > 3 && num6 > num7 && num7 != 0)
				{
					double maxValue3 = class821_0.method_9().MaxValue;
					class821_0.method_9().arrayList_1.Clear();
					class821_0.method_9().imethod_8(flag7);
					class821_0.method_9().imethod_10(flag8);
					class821_0.method_9().imethod_6(flag9);
					class821_0.method_9().imethod_4(flag10);
					smethod_47(interface42_, class821_0.method_9(), maxValue, minValue, flag6, class821_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
					if (class821_0.method_9().MaxValue > maxValue3)
					{
						Struct44.smethod_19(interface42_, class821_0.method_9(), class5, flag);
					}
				}
			}
		}
		if (class3.Count > 0)
		{
			if (class821_0.bool_8)
			{
				double double_3 = class821_0.double_0;
				double double_4 = class821_0.double_1;
			}
			else
			{
				double double_3;
				double double_4;
				bool bool_2 = smethod_33(class3.method_15(), out double_3, out double_4, class821_0.method_10());
				smethod_47(interface42_, class821_0.method_10(), double_4, double_3, bool_2, class821_0.method_10().arrayList_1, class6.method_22(), rectangle_, flag2, class3.method_9(0));
			}
			smethod_26(class821_0.method_10(), class3);
			if (class821_0.method_1().bool_13)
			{
				class821_0.method_2().arrayList_1 = class821_0.method_1().arrayList_1;
				class821_0.method_2().MaxValue = class821_0.method_1().MaxValue;
				class821_0.method_2().MinValue = class821_0.method_1().MinValue;
				class821_0.method_2().MajorUnit = class821_0.method_1().MajorUnit;
				class821_0.method_2().MinorUnit = class821_0.method_1().MinorUnit;
			}
			else
			{
				smethod_64(interface42_, class821_0.method_2(), class821_0.method_2().arrayList_1, rectangle_, class6.method_22(), class3, flag2);
			}
			smethod_26(class821_0.method_2(), class3);
			if (!Struct63.smethod_18(rectangle_) && class821_0.method_10().IsVisible && class6.method_22() != ChartType_Chart.Radar && class6.method_22() != ChartType_Chart.RadarFilled)
			{
				smethod_20(class821_0.method_10(), class821_0.method_2(), class3, class821_0);
				Size size_9 = Struct44.smethod_19(interface42_, class821_0.method_10(), class6, flag2);
				smethod_12(class821_0.method_10(), flag2);
				SizeF sizeF7 = default(SizeF);
				sizeF7 = (flag2 ? new SizeF(rectangle.Width, rectangle.Height) : new SizeF(rectangle.Width, rectangle.Height));
				Size size_10 = class821_0.method_10().method_12().method_4(sizeF7);
				if (flag == flag2)
				{
					if (class821_0.method_10().int_4 != 3 && class821_0.method_10().int_4 == class821_0.method_9().int_4)
					{
						class821_0.method_10().int_4 = 0;
					}
				}
				else if (class821_0.method_10().int_4 != 3 && class821_0.method_10().int_4 == class821_0.method_1().int_4)
				{
					class821_0.method_10().int_4 = 0;
				}
				smethod_21(class821_0, interface42_, class821_0.method_10(), size_9, size_10, ref rectangle_, flag2);
			}
			if (!Struct63.smethod_18(rectangle_) && !flag4 && class821_0.method_2().IsVisible && class6.method_22() != ChartType_Chart.Radar && class6.method_22() != ChartType_Chart.RadarFilled)
			{
				smethod_20(class821_0.method_2(), class821_0.method_10(), class3, class821_0);
				Size size_11 = Struct44.smethod_20(interface42_, class821_0.method_2(), rectangle_, rectangle_2, num4, flag2, class6);
				int num8 = (int)((double)(class821_0.method_2().method_10().method_1() + class821_0.method_2().method_19() + class821_0.method_2().method_21()) + 0.5);
				if (class6.method_22() == ChartType_Chart.Scatter || class6.method_22() == ChartType_Chart.Bubble)
				{
					smethod_12(class821_0.method_1(), flag2);
					SizeF sizeF8 = default(SizeF);
					sizeF8 = ((!flag2) ? new SizeF(rectangle.Width, rectangle.Height) : new SizeF(rectangle.Width, rectangle.Height));
					num8 += class821_0.method_1().method_12().method_4(sizeF8)
						.Height;
				}
				if (flag == flag2)
				{
					if (class821_0.method_2().int_4 != 3 && class821_0.method_2().int_4 == class821_0.method_1().int_4)
					{
						class821_0.method_2().int_4 = 0;
					}
				}
				else if (class821_0.method_2().int_4 != 3 && class821_0.method_2().int_4 == class821_0.method_9().int_4)
				{
					class821_0.method_2().int_4 = 0;
				}
				smethod_23(class821_0, interface42_, class821_0.method_2(), size_11, num8, ref rectangle_, flag2, flag5);
			}
		}
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_9().IsVisible && class821_0.method_9().TickLabelPosition != Enum83.const_3 && class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled)
		{
			Struct44.smethod_25(interface42_, class821_0.method_9(), class5, flag);
			float float_ = class821_0.method_9().float_4;
			float float_2 = class821_0.method_9().float_5;
			if (!flag)
			{
				if (class821_0.method_8().imethod_3())
				{
					if ((float)(rectangle_.Y - rectangle.Y) < float_2)
					{
						int num9 = (int)(float_2 - (float)(rectangle_.Y - rectangle.Y));
						rectangle_.Y += num9;
						rectangle_.Height -= num9;
					}
					if ((float)(rectangle.Bottom - rectangle_.Bottom) < float_)
					{
						int num10 = (int)(float_ - (float)(rectangle.Bottom - rectangle_.Bottom));
						rectangle_.Height -= num10;
					}
				}
				else
				{
					if ((float)(rectangle_.Y - class821_0.int_13) < float_2)
					{
						int num11 = (int)(float_2 - (float)(rectangle_.Y - class821_0.int_13));
						class821_0.int_13 -= num11;
						class821_0.int_15 += num11;
					}
					if ((float)(class821_0.int_13 + class821_0.int_15 - rectangle_.Bottom) < float_)
					{
						int num12 = (int)(float_ - (float)(class821_0.int_13 + class821_0.int_15 - rectangle_.Bottom));
						class821_0.int_15 += num12;
					}
				}
			}
			else if (class821_0.method_8().imethod_3())
			{
				if ((float)(rectangle_.X - rectangle.X) < float_)
				{
					int num13 = (int)(float_ - (float)(rectangle_.X - rectangle.X));
					rectangle_.X += num13;
					rectangle_.Width -= num13;
				}
				if ((float)(rectangle.Right - rectangle_.Right) < float_2)
				{
					int num14 = (int)(float_2 - (float)(rectangle.Right - rectangle_.Right));
					rectangle_.Width -= num14;
				}
			}
			else
			{
				if ((float)(rectangle_.X - class821_0.int_12) < float_)
				{
					int num15 = (int)(float_ - (float)(rectangle_.X - class821_0.int_12));
					class821_0.int_12 -= num15;
					class821_0.int_14 += num15;
				}
				if ((float)(class821_0.int_12 + class821_0.int_14 - rectangle_.Right) < float_2)
				{
					int num16 = (int)(float_2 - (float)(class821_0.int_12 + class821_0.int_14 - rectangle_.Right));
					class821_0.int_14 += num16;
				}
			}
		}
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_1().IsVisible && class821_0.method_1().TickLabelPosition != Enum83.const_3 && class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled && (class821_0.method_1().float_4 > 0f || class821_0.method_1().float_5 > 0f))
		{
			float float_3 = class821_0.method_1().float_4;
			float float_4 = class821_0.method_1().float_5;
			if (flag)
			{
				if (class821_0.method_8().imethod_3())
				{
					if ((float)(rectangle_.Y - rectangle.Y) < float_4)
					{
						int num17 = (int)(float_4 - (float)(rectangle_.Y - rectangle.Y));
						rectangle_.Y += num17;
						rectangle_.Height -= num17;
					}
					if ((float)(rectangle.Bottom - rectangle_.Bottom) < float_3)
					{
						int num18 = (int)(float_3 - (float)(rectangle.Bottom - rectangle_.Bottom));
						rectangle_.Height -= num18;
					}
				}
				else
				{
					if ((float)(rectangle_.Y - class821_0.int_13) < float_4)
					{
						int num19 = (int)(float_4 - (float)(rectangle_.Y - class821_0.int_13));
						class821_0.int_13 -= num19;
						class821_0.int_15 += num19;
					}
					if ((float)(class821_0.int_13 + class821_0.int_15 - rectangle_.Bottom) < float_3)
					{
						int num20 = (int)(float_3 - (float)(class821_0.int_13 + class821_0.int_15 - rectangle_.Bottom));
						class821_0.int_15 += num20;
					}
				}
			}
			else if (class821_0.method_8().imethod_3())
			{
				if ((float)(rectangle_.X - rectangle.X) < float_3)
				{
					int num21 = (int)(float_3 - (float)(rectangle_.X - rectangle.X));
					rectangle_.X += num21;
					rectangle_.Width -= num21;
				}
				if ((float)(rectangle.Right - rectangle_.Right) < float_4)
				{
					int num22 = (int)(float_4 - (float)(rectangle.Right - rectangle_.Right));
					rectangle_.Width -= num22;
				}
			}
			else
			{
				if ((float)(rectangle_.X - class821_0.int_12) < float_3)
				{
					int num23 = (int)(float_3 - (float)(rectangle_.X - class821_0.int_12));
					class821_0.int_12 -= num23;
					class821_0.int_14 += num23;
				}
				if ((float)(class821_0.int_12 + class821_0.int_14 - rectangle_.Right) < float_4)
				{
					int num24 = (int)(float_4 - (float)(class821_0.int_12 + class821_0.int_14 - rectangle_.Right));
					class821_0.int_14 += num24;
				}
			}
		}
		if (class3.Count > 0)
		{
			if (!Struct63.smethod_18(rectangle_) && class821_0.method_8().imethod_3() && class821_0.method_10().IsVisible && class821_0.method_10().TickLabelPosition != Enum83.const_3 && class6.method_22() != ChartType_Chart.Radar && class6.method_22() != ChartType_Chart.RadarFilled)
			{
				if (!flag2)
				{
					float num25 = class821_0.method_10().float_1 / 2f;
					if ((float)(rectangle_.Y - rectangle.Y) < num25)
					{
						int num26 = (int)(num25 - (float)(rectangle_.Y - rectangle.Y));
						rectangle_.Y += num26;
						rectangle_.Height -= num26;
					}
					if ((float)(rectangle.Bottom - rectangle_.Bottom) < num25)
					{
						int num27 = (int)(num25 - (float)(rectangle.Bottom - rectangle_.Bottom));
						rectangle_.Height -= num27;
					}
				}
				else
				{
					float num28 = class821_0.method_10().float_0 / 2f;
					if ((float)(rectangle_.X - rectangle.X) < num28)
					{
						int num29 = (int)(num28 - (float)(rectangle_.X - rectangle.X));
						rectangle_.X += num29;
						rectangle_.Width -= num29;
					}
					if ((float)(rectangle.Right - rectangle_.Right) < num28)
					{
						int num30 = (int)(num28 - (float)(rectangle.Right - rectangle_.Right));
						rectangle_.Width -= num30;
					}
				}
			}
			if (!Struct63.smethod_18(rectangle_) && class821_0.method_8().imethod_3() && class821_0.method_2().IsVisible && class821_0.method_2().TickLabelPosition != Enum83.const_3 && class6.method_22() != ChartType_Chart.Radar && class6.method_22() != ChartType_Chart.RadarFilled && (class821_0.method_2().float_4 > 0f || class821_0.method_2().float_5 > 0f))
			{
				if (flag2)
				{
					float num31 = class821_0.method_2().float_1 / 2f;
					if ((float)(rectangle_.Y - rectangle.Y) < num31)
					{
						int num32 = (int)(num31 - (float)(rectangle_.Y - rectangle.Y));
						rectangle_.Y += num32;
						rectangle_.Height -= num32;
					}
					if ((float)(rectangle.Bottom - rectangle_.Bottom) < num31)
					{
						int num33 = (int)(num31 - (float)(rectangle.Bottom - rectangle_.Bottom));
						rectangle_.Height -= num33;
					}
				}
				else
				{
					float num34 = class821_0.method_2().float_0 / 2f;
					if ((float)(rectangle_.X - rectangle.X) < num34)
					{
						int num35 = (int)(num34 - (float)(rectangle_.X - rectangle.X));
						rectangle_.X += num35;
						rectangle_.Width -= num35;
					}
					if ((float)(rectangle.Right - rectangle_.Right) < num34)
					{
						int num36 = (int)(num34 - (float)(rectangle.Right - rectangle_.Right));
						rectangle_.Width -= num36;
					}
				}
			}
		}
		if (!Struct63.smethod_18(rectangle_))
		{
			smethod_22(class821_0, ref rectangle_);
			class821_0.method_24(new RectangleF(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height));
			smethod_25(interface42_, class821_0, class5, class6, ref rectangle_);
		}
		else
		{
			class821_0.method_24(new RectangleF(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height));
		}
		class821_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		Rectangle rectangle_3 = new Rectangle(class821_0.int_12, class821_0.int_13, class821_0.int_14, class821_0.int_15);
		if (class821_0.IsInnerMode && class821_0.IsDataTableShown && flag5 && num != 0)
		{
			rectangle_3.Height -= num - int_1;
		}
		if (!Struct63.smethod_18(rectangle_) && !class821_0.method_8().imethod_3())
		{
			if (class821_0.method_1().method_11().IsVisible)
			{
				smethod_14(class821_0.method_1(), rectangle_3, flag);
			}
			if (class821_0.method_2().method_11().IsVisible && class3.Count > 0)
			{
				smethod_14(class821_0.method_2(), rectangle_3, flag2);
			}
			if (class821_0.method_9().method_11().IsVisible)
			{
				smethod_14(class821_0.method_9(), rectangle_3, flag);
			}
			if (class821_0.method_10().method_11().IsVisible && class3.Count > 0)
			{
				smethod_14(class821_0.method_10(), rectangle_3, flag2);
			}
		}
		class821_0.method_8().method_9();
		Rectangle rectangle_4 = class821_0.method_8().rectangle_0;
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_1().method_11().IsVisible)
		{
			smethod_15(class821_0.method_1(), flag, rectangle_4);
		}
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_9().method_11().IsVisible)
		{
			smethod_15(class821_0.method_9(), flag, rectangle_4);
		}
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_2().method_11().IsVisible && class3.Count > 0)
		{
			smethod_15(class821_0.method_2(), flag2, rectangle_4);
		}
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_10().method_11().IsVisible && class3.Count > 0)
		{
			smethod_15(class821_0.method_10(), flag2, rectangle_4);
		}
		if (class821_0.method_8().imethod_3() && class821_0.method_9().IsVisible && class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled)
		{
			int num37 = smethod_51(interface42_, class821_0.method_9(), flag, class5, rectangle_);
			int num38 = 0;
			num38 = ((!flag) ? rectangle_.Height : rectangle_.Width);
			if (flag7 && class821_0.method_9().arrayList_1.Count > 3 && num37 > num38 && num38 != 0)
			{
				double maxValue4 = class821_0.method_9().MaxValue;
				class821_0.method_9().arrayList_1.Clear();
				class821_0.method_9().imethod_8(flag7);
				class821_0.method_9().imethod_10(flag8);
				class821_0.method_9().imethod_6(flag9);
				class821_0.method_9().imethod_4(flag10);
				smethod_47(interface42_, class821_0.method_9(), maxValue, minValue, flag6, class821_0.method_9().arrayList_1, class5.method_22(), rectangle_, flag, class2.method_9(0));
				if (class821_0.method_9().MaxValue > maxValue4)
				{
					Struct44.smethod_19(interface42_, class821_0.method_9(), class5, flag);
				}
			}
		}
		if (class821_0.method_8().imethod_3() && class821_0.method_1().IsVisible && class5.method_22() == ChartType_Chart.Scatter)
		{
			int num39 = smethod_51(interface42_, class821_0.method_1(), bool_0: true, class5, rectangle_);
			int num40 = 0;
			num40 = ((!flag) ? rectangle_.Height : rectangle_.Width);
			if (flag11 && class821_0.method_1().arrayList_1.Count > 3 && num39 > num40 && num40 != 0)
			{
				class821_0.method_1().arrayList_1.Clear();
				class821_0.method_1().imethod_8(flag11);
				class821_0.method_1().imethod_10(flag12);
				class821_0.method_1().imethod_6(flag13);
				class821_0.method_1().imethod_4(flag14);
				smethod_64(interface42_, class821_0.method_1(), class821_0.method_1().arrayList_1, rectangle_, class5.method_22(), class2, flag);
			}
		}
		if (flag && flag7)
		{
			smethod_61(class821_0.method_9(), double_, double_2, class821_0.Type, rectangle_.Width, flag, @class.method_9(0), flag9, flag10, flag7);
		}
		if (smethod_58(class821_0.Type))
		{
			Struct46.smethod_5(interface42_, @class, rectangle_, @class.method_10(), flag11, flag12, flag13, flag14, flag7, flag8, flag9, flag10);
		}
		class821_0.method_8().method_9();
		rectangle_ = class821_0.method_8().rectangle_0;
		float x = smethod_18(class821_0.method_9(), rectangle_.X, rectangle_.Width, flag);
		_ = class821_0.method_9().CrossAt;
		smethod_18(class821_0.method_10(), rectangle_.X, rectangle_.Width, flag2);
		_ = class821_0.method_10().CrossAt;
		float y = smethod_18(class821_0.method_9(), rectangle_.Y, rectangle_.Height, flag);
		smethod_18(class821_0.method_10(), rectangle_.Y, rectangle_.Height, flag2);
		float y2 = smethod_19(class821_0.method_1(), rectangle_.Y, rectangle_.Height, flag, class2);
		smethod_19(class821_0.method_2(), rectangle_.Y, rectangle_.Height, flag2, class3);
		float num41 = 0f;
		num41 = ((class5.method_22() == ChartType_Chart.Bubble || class5.method_22() == ChartType_Chart.Scatter) ? smethod_18(class821_0.method_1(), rectangle_.X, rectangle_.Width, !flag) : smethod_19(class821_0.method_1(), rectangle_.X, rectangle_.Width, flag, class2));
		if (class6.method_22() != ChartType_Chart.Bubble && class6.method_22() != ChartType_Chart.Scatter)
		{
			smethod_19(class821_0.method_2(), rectangle_.X, rectangle_.Width, flag2, class3);
		}
		else
		{
			smethod_18(class821_0.method_2(), rectangle_.X, rectangle_.Width, !flag2);
		}
		if (flag)
		{
			PointF pointF_ = new PointF(x, rectangle_.Y);
			PointF pointF_2 = new PointF(x, rectangle_.Bottom);
			if (class821_0.method_1().IsPlotOrderReversed)
			{
				class821_0.method_1().method_23(pointF_);
				class821_0.method_1().method_24(pointF_2);
			}
			else
			{
				class821_0.method_1().method_23(pointF_2);
				class821_0.method_1().method_24(pointF_);
			}
		}
		else
		{
			PointF pointF_3 = new PointF(rectangle_.X, y);
			PointF pointF_4 = new PointF(rectangle_.Right, y);
			if (!class821_0.method_1().IsPlotOrderReversed)
			{
				class821_0.method_1().method_23(pointF_3);
				class821_0.method_1().method_24(pointF_4);
			}
			else
			{
				class821_0.method_1().method_23(pointF_4);
				class821_0.method_1().method_24(pointF_3);
			}
		}
		if (flag2)
		{
			PointF pointF_5 = new PointF(x, rectangle_.Y);
			PointF pointF_6 = new PointF(x, rectangle_.Bottom);
			if (class821_0.method_2().IsPlotOrderReversed)
			{
				class821_0.method_2().method_23(pointF_5);
				class821_0.method_2().method_24(pointF_6);
			}
			else
			{
				class821_0.method_2().method_23(pointF_6);
				class821_0.method_2().method_24(pointF_5);
			}
		}
		else
		{
			PointF pointF_7 = new PointF(rectangle_.X, y);
			PointF pointF_8 = new PointF(rectangle_.Right, y);
			if (!class821_0.method_2().IsPlotOrderReversed)
			{
				class821_0.method_2().method_23(pointF_7);
				class821_0.method_2().method_24(pointF_8);
			}
			else
			{
				class821_0.method_2().method_23(pointF_8);
				class821_0.method_2().method_24(pointF_7);
			}
		}
		if (flag)
		{
			PointF pointF_9 = new PointF(rectangle_.X, y2);
			PointF pointF_10 = new PointF(rectangle_.Right, y2);
			if (!class821_0.method_9().IsPlotOrderReversed)
			{
				class821_0.method_9().method_23(pointF_9);
				class821_0.method_9().method_24(pointF_10);
			}
			else
			{
				class821_0.method_9().method_23(pointF_10);
				class821_0.method_9().method_24(pointF_9);
			}
		}
		else
		{
			PointF pointF_11 = new PointF(num41, rectangle_.Y);
			PointF pointF_12 = new PointF(num41, rectangle_.Bottom);
			if (class821_0.method_9().IsPlotOrderReversed)
			{
				class821_0.method_9().method_23(pointF_11);
				class821_0.method_9().method_24(pointF_12);
			}
			else
			{
				class821_0.method_9().method_23(pointF_12);
				class821_0.method_9().method_24(pointF_11);
			}
		}
		if (flag2)
		{
			PointF pointF_13 = new PointF(rectangle_.X, y2);
			PointF pointF_14 = new PointF(rectangle_.Right, y2);
			if (!class821_0.method_10().IsPlotOrderReversed)
			{
				class821_0.method_10().method_23(pointF_13);
				class821_0.method_10().method_24(pointF_14);
			}
			else
			{
				class821_0.method_10().method_23(pointF_14);
				class821_0.method_10().method_24(pointF_13);
			}
		}
		else
		{
			PointF pointF_15 = new PointF(num41, rectangle_.Y);
			PointF pointF_16 = new PointF(num41, rectangle_.Bottom);
			if (class821_0.method_10().IsPlotOrderReversed)
			{
				class821_0.method_10().method_23(pointF_15);
				class821_0.method_10().method_24(pointF_16);
			}
			else
			{
				class821_0.method_10().method_23(pointF_16);
				class821_0.method_10().method_24(pointF_15);
			}
		}
		smethod_16(class821_0);
		class821_0.bool_9 = true;
	}

	internal static void smethod_0(Class821 class821_0)
	{
		if (!class821_0.bool_9)
		{
			Calculate(class821_0);
		}
		TextRenderingHint textRenderingHint_ = class821_0.imethod_0().imethod_56();
		Struct62.smethod_0(class821_0);
		Interface42 interface42_ = class821_0.imethod_0();
		Class842 @class = class821_0.method_7();
		if (class821_0.method_7().Count == 0 || smethod_32(class821_0.method_7().method_15()) == 0)
		{
			return;
		}
		Class842 class2 = new Class842(class821_0);
		Class842 class3 = new Class842(class821_0);
		foreach (Class844 item in @class)
		{
			if (item.method_20() == Enum53.const_0)
			{
				class2.Add(item);
			}
			else
			{
				class3.Add(item);
			}
		}
		Class844 class5 = class2.method_9(0);
		Class844 class6 = new Class844(class821_0, null, ChartType_Chart.Column);
		if (class3.Count > 0)
		{
			class6 = (Class844)class3[0];
		}
		bool flag = smethod_10(class5.method_22());
		bool flag2 = smethod_10(class6.method_22());
		int num = smethod_32(class2.method_15());
		int num2 = smethod_32(class3.method_15());
		_ = class821_0.method_1().bool_13;
		bool flag3 = class821_0.method_8().method_16();
		class821_0.method_8().method_19();
		Rectangle rectangle_ = class821_0.method_8().rectangle_0;
		float num3 = smethod_18(class821_0.method_9(), rectangle_.X, rectangle_.Width, flag);
		double crossAt = class821_0.method_9().CrossAt;
		float num4 = smethod_18(class821_0.method_10(), rectangle_.X, rectangle_.Width, flag2);
		double crossAt2 = class821_0.method_10().CrossAt;
		float num5 = smethod_18(class821_0.method_9(), rectangle_.Y, rectangle_.Height, flag);
		float num6 = smethod_18(class821_0.method_10(), rectangle_.Y, rectangle_.Height, flag2);
		float float_ = smethod_19(class821_0.method_1(), rectangle_.Y, rectangle_.Height, flag, class2);
		float float_2 = smethod_19(class821_0.method_2(), rectangle_.Y, rectangle_.Height, flag2, class3);
		float num7 = 0f;
		float num8 = 0f;
		num7 = ((class5.method_22() == ChartType_Chart.Bubble || class5.method_22() == ChartType_Chart.Scatter) ? smethod_18(class821_0.method_1(), rectangle_.X, rectangle_.Width, !flag) : smethod_19(class821_0.method_1(), rectangle_.X, rectangle_.Width, flag, class2));
		num8 = ((class6.method_22() == ChartType_Chart.Bubble || class6.method_22() == ChartType_Chart.Scatter) ? smethod_18(class821_0.method_2(), rectangle_.X, rectangle_.Width, !flag2) : smethod_19(class821_0.method_2(), rectangle_.X, rectangle_.Width, flag2, class3));
		if (class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled)
		{
			Struct44.smethod_0(interface42_, class821_0.method_1(), rectangle_, flag, class5);
			Struct44.smethod_0(interface42_, class821_0.method_9(), rectangle_, flag, class5);
		}
		else
		{
			Struct44.smethod_1(interface42_, class821_0.method_9(), rectangle_, num);
		}
		if (class6.method_22() != ChartType_Chart.Radar && class6.method_22() != ChartType_Chart.RadarFilled)
		{
			Struct44.smethod_0(interface42_, class821_0.method_2(), rectangle_, flag2, class6);
			Struct44.smethod_0(interface42_, class821_0.method_10(), rectangle_, flag2, class6);
		}
		else
		{
			Struct44.smethod_1(interface42_, class821_0.method_10(), rectangle_, num2);
		}
		int num9 = 0;
		float num10 = 0f;
		float num11 = 0f;
		double num12 = 0.0;
		IList list = @class.method_16();
		_ = (Class844)list[0];
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		ArrayList arrayList4 = new ArrayList();
		bool flag4 = false;
		for (int i = 0; i < list.Count; i++)
		{
			if (flag3)
			{
				break;
			}
			Class844 class7 = (Class844)list[i];
			if (class7.method_20() == Enum53.const_0)
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
			if (class821_0.bool_8)
			{
				if (class821_0.method_9() == class821_0.class823_5)
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
			if (class7.method_24(new ChartType_Chart[1] { ChartType_Chart.Column }))
			{
				ArrayList c = Struct50.smethod_0(interface42_, class7, rectangle_, num11, num12, num9);
				arrayList.AddRange(c);
				continue;
			}
			if (class7.method_24(new ChartType_Chart[1] { ChartType_Chart.ColumnStacked }))
			{
				ArrayList c2 = Struct50.smethod_23(interface42_, class7, rectangle_, num9);
				arrayList.AddRange(c2);
				continue;
			}
			if (class7.method_24(new ChartType_Chart[1] { ChartType_Chart.Column100PercentStacked }))
			{
				ArrayList c3 = Struct50.smethod_27(interface42_, class7, rectangle_, num9);
				arrayList.AddRange(c3);
				continue;
			}
			if (class7.method_24(new ChartType_Chart[2]
			{
				ChartType_Chart.Line,
				ChartType_Chart.LineWithDataMarkers
			}))
			{
				ArrayList c4 = Struct50.smethod_18(interface42_, class7, rectangle_, num11, num12, num9);
				arrayList2.AddRange(c4);
				continue;
			}
			if (class7.method_24(new ChartType_Chart[2]
			{
				ChartType_Chart.LineStacked,
				ChartType_Chart.LineStackedWithDataMarkers
			}))
			{
				ArrayList c5 = Struct50.smethod_25(interface42_, class7, rectangle_, num11, num9);
				arrayList2.AddRange(c5);
				continue;
			}
			if (class7.method_24(new ChartType_Chart[2]
			{
				ChartType_Chart.Line100PercentStacked,
				ChartType_Chart.Line100PercentStackedWithDataMarkers
			}))
			{
				ArrayList c6 = Struct50.smethod_30(interface42_, class7, rectangle_, num11, num9);
				arrayList2.AddRange(c6);
				continue;
			}
			if (class7.method_24(new ChartType_Chart[1] { ChartType_Chart.Bar }))
			{
				ArrayList c7 = Struct45.smethod_0(interface42_, class821_0, class7, rectangle_, num10, num12, num9);
				arrayList3.AddRange(c7);
				continue;
			}
			if (class7.method_24(new ChartType_Chart[1] { ChartType_Chart.BarStacked }))
			{
				ArrayList c8 = Struct45.smethod_5(interface42_, class821_0, class7, rectangle_, num9);
				arrayList3.AddRange(c8);
				continue;
			}
			if (class7.method_24(new ChartType_Chart[1] { ChartType_Chart.Bar100PercentStacked }))
			{
				ArrayList c9 = Struct45.smethod_8(interface42_, class821_0, class7, rectangle_, num9);
				arrayList3.AddRange(c9);
				continue;
			}
			if (class7.method_25(new ChartType_Chart[1] { ChartType_Chart.Scatter }))
			{
				ArrayList c10 = Struct64.smethod_0(interface42_, class7, rectangle_, num11, num12, num9);
				arrayList2.AddRange(c10);
				continue;
			}
			ChartType_Chart[] chartType_Chart_ = new ChartType_Chart[1];
			if (class7.method_24(chartType_Chart_))
			{
				ArrayList c11 = Struct43.smethod_0(interface42_, class821_0, class7, rectangle_, num11, num12, num9);
				arrayList2.AddRange(c11);
			}
			else if (class7.method_24(new ChartType_Chart[1] { ChartType_Chart.AreaStacked }))
			{
				ArrayList c12 = Struct43.smethod_2(interface42_, class821_0, class7, rectangle_, num11, num9);
				arrayList2.AddRange(c12);
			}
			else if (class7.method_24(new ChartType_Chart[1] { ChartType_Chart.Area100PercentStacked }))
			{
				ArrayList c13 = Struct43.smethod_4(interface42_, class821_0, class7, rectangle_, num11, num9);
				arrayList2.AddRange(c13);
			}
			else if (class7.method_25(new ChartType_Chart[2]
			{
				ChartType_Chart.Pie,
				ChartType_Chart.Doughnut
			}) && !flag4)
			{
				Struct59.smethod_0(interface42_, rectangle_, class7);
				flag4 = true;
			}
			else if (class7.method_25(new ChartType_Chart[2]
			{
				ChartType_Chart.Radar,
				ChartType_Chart.RadarFilled
			}))
			{
				ArrayList c14 = Struct60.smethod_0(interface42_, class7, rectangle_, num9);
				arrayList4.AddRange(c14);
			}
			else if (class7.method_24(new ChartType_Chart[2]
			{
				ChartType_Chart.Bubble,
				ChartType_Chart.Bubble3D
			}))
			{
				ArrayList c15 = Struct46.smethod_0(interface42_, class7, rectangle_, num11, num12, num9);
				arrayList2.AddRange(c15);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			Class844 class8 = (Class844)list[j];
			Struct63.smethod_0(interface42_, class8.method_3(), class8.method_22(), rectangle_);
			Struct63.smethod_0(interface42_, class8.method_4(), class8.method_22(), rectangle_);
		}
		for (int k = 0; k < list.Count; k++)
		{
			Class844 class9 = (Class844)list[k];
			if (class9.method_20() == Enum53.const_0)
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
			if (class9.method_10().Count > 0)
			{
				if (class9.method_22() != ChartType_Chart.Bar && class9.method_22() != ChartType_Chart.BarStacked && class9.method_22() != ChartType_Chart.Bar100PercentStacked)
				{
					Struct62.smethod_1(interface42_, class9, rectangle_, num11, num12);
				}
				else
				{
					Struct62.smethod_5(interface42_, class9, rectangle_, num10, num12);
				}
			}
		}
		Struct50.smethod_5(interface42_, class821_0, arrayList);
		Struct50.smethod_20(interface42_, class821_0, arrayList2);
		Struct45.smethod_2(interface42_, class821_0, rectangle_, arrayList3);
		Struct60.smethod_1(interface42_, class821_0, arrayList4);
		if (class821_0.method_12().IsVisible)
		{
			class821_0.method_12().method_2();
		}
		if (class821_0.method_3().method_1().method_2())
		{
			class821_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
		}
		if (class5.method_34())
		{
			Struct44.smethod_17(interface42_, class2, class821_0.method_1(), rectangle_);
		}
		else if (class821_0.method_1().IsVisible && class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled)
		{
			if (flag)
			{
				Struct44.smethod_11(interface42_, class821_0.method_1(), class821_0.method_9().IsPlotOrderReversed, num3, rectangle_, num);
			}
			else if (class5.method_22() != ChartType_Chart.Scatter && class5.method_22() != ChartType_Chart.Bubble)
			{
				Struct44.smethod_5(interface42_, class821_0.method_1(), class821_0.method_9().IsPlotOrderReversed, num5, rectangle_, num, flag);
			}
			else
			{
				Struct44.smethod_16(interface42_, class821_0.method_1(), class821_0.method_9().IsPlotOrderReversed, num5, rectangle_, class5);
			}
		}
		if (class6.method_34())
		{
			Struct44.smethod_17(interface42_, class3, class821_0.method_2(), rectangle_);
		}
		else if (class821_0.method_2().IsVisible && class6.method_22() != ChartType_Chart.Radar && class6.method_22() != ChartType_Chart.RadarFilled)
		{
			if (flag2)
			{
				Struct44.smethod_11(interface42_, class821_0.method_2(), class821_0.method_10().IsPlotOrderReversed, num4, rectangle_, num2);
			}
			else if (class6.method_22() != ChartType_Chart.Scatter && class6.method_22() != ChartType_Chart.Bubble)
			{
				Struct44.smethod_5(interface42_, class821_0.method_2(), class821_0.method_10().IsPlotOrderReversed, num6, rectangle_, num2, flag2);
			}
			else
			{
				Struct44.smethod_16(interface42_, class821_0.method_2(), class821_0.method_10().IsPlotOrderReversed, num6, rectangle_, class6);
			}
		}
		if (class821_0.method_9().IsVisible)
		{
			if (flag)
			{
				Struct44.smethod_9(interface42_, class821_0.method_9(), class821_0.method_1().IsPlotOrderReversed, float_, rectangle_, class5);
			}
			else if (class5.method_22() != ChartType_Chart.Radar && class5.method_22() != ChartType_Chart.RadarFilled)
			{
				Struct44.smethod_2(interface42_, class821_0.method_9(), class821_0.method_1().IsPlotOrderReversed, num7, rectangle_, class5);
			}
			else
			{
				Struct44.smethod_18(interface42_, class2, class821_0.method_9(), rectangle_);
			}
		}
		if (class821_0.method_10().IsVisible)
		{
			if (flag2)
			{
				Struct44.smethod_9(interface42_, class821_0.method_10(), class821_0.method_2().IsPlotOrderReversed, float_2, rectangle_, class6);
			}
			else if (class6.method_22() != ChartType_Chart.Radar && class6.method_22() != ChartType_Chart.RadarFilled)
			{
				Struct44.smethod_2(interface42_, class821_0.method_10(), class821_0.method_1().IsPlotOrderReversed, num8, rectangle_, class6);
			}
			else
			{
				Struct44.smethod_18(interface42_, class3, class821_0.method_10(), rectangle_);
			}
		}
		if (class821_0.method_3().method_1().method_2())
		{
			class821_0.imethod_0().imethod_57(textRenderingHint_);
		}
		for (int l = 0; l < list.Count; l++)
		{
			if (class821_0.method_3().method_1().method_2() && class821_0.method_8().method_1().method_2())
			{
				class821_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
			}
			Class844 class844_ = (Class844)list[l];
			Struct62.smethod_20(interface42_, class844_);
			if (class821_0.method_3().method_1().method_2() && class821_0.method_8().method_1().method_2())
			{
				class821_0.imethod_0().imethod_57(textRenderingHint_);
			}
		}
		if (class821_0.method_1().method_11().IsVisible)
		{
			class821_0.method_1().method_11().method_2();
		}
		if (class821_0.method_9().method_11().IsVisible)
		{
			class821_0.method_9().method_11().method_2();
		}
		if (class821_0.method_2().method_11().IsVisible && class3.Count > 0)
		{
			class821_0.method_2().method_11().method_2();
		}
		if (class821_0.method_10().method_11().IsVisible && class3.Count > 0)
		{
			class821_0.method_10().method_11().method_2();
		}
		if (class821_0.IsDataTableShown)
		{
			if (smethod_68(class821_0.method_1()) || smethod_70(class821_0.Type))
			{
				class821_0.method_4().rectangle_0.X = class821_0.method_8().rectangle_0.X;
				class821_0.method_4().rectangle_0.Width = class821_0.method_8().rectangle_0.Width;
			}
			else
			{
				class821_0.method_4().rectangle_0.X = class821_0.method_8().rectangle_0.X;
				class821_0.method_4().rectangle_0.Y = class821_0.method_8().rectangle_0.Bottom;
				class821_0.method_4().rectangle_0.Width = class821_0.method_8().rectangle_0.Width;
			}
			Struct49.smethod_0(interface42_, class821_0.method_4(), class821_0.method_4().rectangle_0.X, class821_0.method_4().rectangle_0.Y, class821_0.method_4().rectangle_0.Width, flag);
		}
		bool bool_ = class821_0.method_6().bool_0;
		if (class821_0.IsLegendShown)
		{
			if (class821_0.method_3().method_1().method_2() && class821_0.method_6().method_0().method_1()
				.method_2())
			{
				class821_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
			}
			if (class3.Count == 0 && (class5.method_22() == ChartType_Chart.Pie || class5.method_22() == ChartType_Chart.Doughnut || bool_))
			{
				Class844 class10 = class5;
				if (class5.Type == ChartType_Chart.Doughnut || class5.Type == ChartType_Chart.DoughnutExploded)
				{
					for (int m = 1; m < class821_0.method_7().Count; m++)
					{
						if (class821_0.method_7()[m].Points != null && class10.method_9() != null && class821_0.method_7()[m].Points.Count > class10.method_9().Count)
						{
							class10 = class821_0.method_7().method_9(m);
						}
					}
				}
				Struct53.smethod_8(interface42_, class821_0.method_6(), class10);
			}
			else
			{
				Struct53.smethod_21(interface42_, class821_0.method_6(), flag, class5);
			}
			if (class821_0.method_3().method_1().method_2() && class821_0.method_6().method_0().method_1()
				.method_2())
			{
				class821_0.imethod_0().imethod_57(textRenderingHint_);
			}
		}
		class821_0.method_3().method_2().method_9(class821_0.method_3().rectangle_0);
	}

	internal static string smethod_1(Class821 class821_0)
	{
		Class842 @class = class821_0.method_7();
		Class842 class2 = new Class842(class821_0);
		Class842 class3 = new Class842(class821_0);
		foreach (Class844 item in @class)
		{
			if (item.method_20() == Enum53.const_0)
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
		Class844 class5 = class2.method_9(0);
		for (int i = 1; i < class2.Count; i++)
		{
			Class844 class6 = class2.method_9(i);
			if (class6.method_22() != class5.method_22())
			{
				class6.method_21(Enum53.const_1);
				class3.Add(class6);
			}
		}
		Class844 class7 = new Class844(class821_0, null, ChartType_Chart.Column);
		if (class3.Count > 0)
		{
			class7 = class3.method_9(0);
		}
		else
		{
			class821_0.method_2().IsVisible = false;
			class821_0.method_2().method_11().Text = "";
			class821_0.method_10().IsVisible = false;
			class821_0.method_10().method_11().Text = "";
		}
		int num = 1;
		while (true)
		{
			if (num < class3.Count)
			{
				Class844 class8 = class3.method_9(num);
				if (class8.method_22() != class7.method_22())
				{
					break;
				}
				num++;
				continue;
			}
			return "";
		}
		return "Some chart types cannot be combined with other types!";
	}

	private static void smethod_2(Class842 class842_0)
	{
		foreach (Class844 item in class842_0)
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

	private static void smethod_3(Class821 class821_0, Class842 class842_0, Class842 class842_1)
	{
		Class842 @class = class821_0.method_7();
		foreach (Class844 item in @class)
		{
			if (item.method_22() != ChartType_Chart.Scatter && item.method_22() != ChartType_Chart.Bubble)
			{
				item.method_4().DisplayType = Enum68.const_2;
			}
			switch (item.method_22())
			{
			case ChartType_Chart.Radar:
			case ChartType_Chart.RadarFilled:
				class821_0.IsDataTableShown = false;
				if (item.method_20() == Enum53.const_0)
				{
					class821_0.method_1().CategoryType = Enum64.const_1;
					class821_0.method_1().method_11().Text = "";
					class821_0.method_9().method_11().Text = "";
					class821_0.method_1().method_8().Formatting = Enum71.const_0;
					class821_0.method_1().method_9().Formatting = Enum71.const_0;
				}
				else
				{
					class821_0.method_2().CategoryType = Enum64.const_1;
					class821_0.method_2().method_11().Text = "";
					class821_0.method_10().method_11().Text = "";
					class821_0.method_2().method_8().Formatting = Enum71.const_0;
					class821_0.method_2().method_9().Formatting = Enum71.const_0;
				}
				break;
			case ChartType_Chart.Doughnut:
			case ChartType_Chart.Pie:
				if (item.method_11())
				{
					item.IsColorVaried = true;
				}
				class821_0.IsDataTableShown = false;
				if (item.method_20() == Enum53.const_0)
				{
					class821_0.method_1().IsVisible = false;
					class821_0.method_1().method_11().Text = "";
					class821_0.method_9().IsVisible = false;
					class821_0.method_9().method_11().Text = "";
					class821_0.method_1().method_8().Formatting = Enum71.const_0;
					class821_0.method_1().method_9().Formatting = Enum71.const_0;
					class821_0.method_9().method_8().Formatting = Enum71.const_0;
					class821_0.method_9().method_9().Formatting = Enum71.const_0;
				}
				else
				{
					class821_0.method_2().IsVisible = false;
					class821_0.method_2().method_11().Text = "";
					class821_0.method_10().IsVisible = false;
					class821_0.method_10().method_11().Text = "";
					class821_0.method_2().method_8().Formatting = Enum71.const_0;
					class821_0.method_2().method_9().Formatting = Enum71.const_0;
					class821_0.method_10().method_8().Formatting = Enum71.const_0;
					class821_0.method_10().method_9().Formatting = Enum71.const_0;
				}
				break;
			}
		}
		if (class821_0.method_1().bool_13)
		{
			smethod_4(@class, class821_0.method_1());
			class821_0.method_2().bool_12 = class821_0.method_1().bool_12;
			class821_0.method_2().AxisBetweenCategories = class821_0.method_1().AxisBetweenCategories;
		}
		else
		{
			smethod_4(class842_0, class821_0.method_1());
			smethod_4(class842_1, class821_0.method_2());
		}
	}

	private static void smethod_4(Class842 class842_0, Class823 class823_0)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (Class844 item in class842_0)
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
			class823_0.AxisBetweenCategories = false;
		}
		if (flag && flag2)
		{
			class823_0.bool_12 = true;
		}
	}

	private static void smethod_5(Class840 class840_0, int int_3)
	{
		if (class840_0.Formatting == Enum71.const_1)
		{
			Class839 @class = class840_0.method_0();
			@class.Width = int_3;
		}
	}

	internal static void smethod_6(Class821 class821_0)
	{
		Class842 @class = class821_0.method_7();
		int count = @class.Count;
		Color[] array = class821_0.method_16().method_0().method_4(class821_0.imethod_7(), @class.method_22());
		Color color_ = class821_0.method_16().method_0().method_2("lt1");
		Color color_2 = class821_0.method_16().method_0().method_2("dk1");
		for (int i = 0; i < count; i++)
		{
			Class844 class2 = @class.method_9(i);
			int num = class2.vmethod_4();
			_ = class2.Type;
			Color color_3 = array[num];
			Color color = array[num];
			Color color2 = color;
			class2.method_6().method_4(color_3);
			if (class2.method_26())
			{
				class2.method_5().method_5(color);
				if (class821_0.imethod_7() <= 8)
				{
					smethod_5(class2.method_5(), 3);
				}
				else if (class821_0.imethod_7() <= 24)
				{
					smethod_5(class2.method_5(), 5);
				}
				else if (class821_0.imethod_7() <= 32)
				{
					smethod_5(class2.method_5(), 7);
				}
				else if (class821_0.imethod_7() <= 48)
				{
					smethod_5(class2.method_5(), 5);
				}
			}
			else
			{
				if (class821_0.imethod_7() >= 9 && class821_0.imethod_7() <= 16)
				{
					class2.method_5().method_5(Color.FromArgb(255, smethod_7(color_)));
					smethod_5(class2.method_5(), 1);
				}
				else if (class821_0.imethod_7() == 33)
				{
					Color baseColor = class821_0.method_16().method_0().method_6(color_2, 0.925);
					baseColor = Color.FromArgb(255, baseColor);
					class2.method_5().method_5(baseColor);
					smethod_5(class2.method_5(), 1);
				}
				else if (class821_0.imethod_7() == 34)
				{
					Color baseColor2 = class821_0.method_16().method_0().method_7(color, 0.5);
					baseColor2 = Color.FromArgb(255, baseColor2);
					class2.method_5().method_5(baseColor2);
					smethod_5(class2.method_5(), 1);
				}
				if (class821_0.imethod_7() >= 35 && class821_0.imethod_7() <= 40)
				{
					int num2 = class821_0.imethod_7() - 34;
					Color color_4 = class821_0.method_16().method_0().method_2("accent" + num2);
					color_4 = class821_0.method_16().method_0().method_7(color_4, 0.5);
					color_4 = Color.FromArgb(255, color_4);
					class2.method_5().method_5(color_4);
					smethod_5(class2.method_5(), 1);
				}
			}
			if (class2.method_26())
			{
				class2.method_7().method_2().method_5(color2);
				if (class821_0.imethod_7() <= 8)
				{
					class2.method_7().method_5(7);
				}
				else if (class821_0.imethod_7() <= 24)
				{
					class2.method_7().method_5(9);
				}
				else if (class821_0.imethod_7() <= 32)
				{
					class2.method_7().method_5(13);
				}
				else if (class821_0.imethod_7() <= 48)
				{
					class2.method_7().method_5(9);
				}
				class2.method_7().method_4(Struct53.smethod_5(class2, num));
				int markerStyle = (int)class2.method_7().MarkerStyle;
				if (markerStyle != 5 && markerStyle != 6 && markerStyle != 8)
				{
					class2.method_7().method_1().method_4(color2);
				}
				else
				{
					class2.method_7().method_1().method_4(Color.Empty);
				}
			}
			Class830 class3 = class2.method_9();
			int count2 = class3.Count;
			Color[] array2 = class821_0.method_16().method_0().method_4(class821_0.imethod_7(), count2);
			bool flag = false;
			if (class2.Type == ChartType_Chart.Pie || class2.Type == ChartType_Chart.Pie3D || class2.Type == ChartType_Chart.Pie3DExploded || class2.Type == ChartType_Chart.PieBar || class2.Type == ChartType_Chart.PieExploded || class2.Type == ChartType_Chart.PiePie || class2.Type == ChartType_Chart.Doughnut || class2.Type == ChartType_Chart.DoughnutExploded)
			{
				flag = true;
			}
			int count3 = class3.Count;
			for (int j = 0; j < count3; j++)
			{
				Class831 class4 = class3.method_1(j);
				if (class4 == null)
				{
					continue;
				}
				if ((flag && class2.IsColorVaried) || (!flag && class2.IsColorVaried && count == 1))
				{
					Color color_5 = array2[j];
					Color color3 = array2[j];
					Color color4 = color3;
					class4.method_3().method_4(color_5);
					if (class2.method_26())
					{
						class4.method_4().method_5(color3);
						if (class821_0.imethod_7() <= 8)
						{
							smethod_5(class4.method_4(), 3);
						}
						else if (class821_0.imethod_7() <= 24)
						{
							smethod_5(class4.method_4(), 5);
						}
						else if (class821_0.imethod_7() <= 32)
						{
							smethod_5(class4.method_4(), 7);
						}
						else if (class821_0.imethod_7() <= 48)
						{
							smethod_5(class4.method_4(), 5);
						}
					}
					else
					{
						if (class821_0.imethod_7() >= 9 && class821_0.imethod_7() <= 16)
						{
							class4.method_4().method_5(Color.FromArgb(255, smethod_7(color_)));
							smethod_5(class4.method_4(), 1);
						}
						else if (class821_0.imethod_7() == 33)
						{
							Color baseColor3 = class821_0.method_16().method_0().method_6(color_2, 0.925);
							baseColor3 = Color.FromArgb(255, baseColor3);
							class4.method_4().method_5(baseColor3);
							smethod_5(class4.method_4(), 1);
						}
						else if (class821_0.imethod_7() == 34)
						{
							Color baseColor4 = class821_0.method_16().method_0().method_7(color, 0.5);
							baseColor4 = Color.FromArgb(255, baseColor4);
							class4.method_4().method_5(baseColor4);
							smethod_5(class4.method_4(), 1);
						}
						if (class821_0.imethod_7() >= 35 && class821_0.imethod_7() <= 40)
						{
							int num3 = class821_0.imethod_7() - 34;
							Color color_6 = class821_0.method_16().method_0().method_2("accent" + num3);
							color_6 = class821_0.method_16().method_0().method_7(color_6, 0.5);
							color_6 = Color.FromArgb(255, color_6);
							class4.method_4().method_5(color_6);
							smethod_5(class4.method_4(), 1);
						}
					}
					if (class2.method_26())
					{
						class4.method_5().method_2().method_5(color4);
						if (class821_0.imethod_7() <= 8)
						{
							class4.method_5().method_5(7);
						}
						else if (class821_0.imethod_7() <= 24)
						{
							class4.method_5().method_5(9);
						}
						else if (class821_0.imethod_7() <= 32)
						{
							class4.method_5().method_5(13);
						}
						else if (class821_0.imethod_7() <= 48)
						{
							class4.method_5().method_5(9);
						}
						class4.method_5().method_4(Struct53.smethod_5(class2, j));
						int markerStyle2 = (int)class4.method_5().MarkerStyle;
						if (markerStyle2 != 5 && markerStyle2 != 6 && markerStyle2 != 8)
						{
							class4.method_5().method_1().method_4(color4);
						}
						else
						{
							class4.method_5().method_1().method_4(Color.Empty);
						}
					}
					continue;
				}
				class4.method_3().method_4(color_3);
				if (class2.method_26())
				{
					class4.method_4().method_5(color);
					if (class821_0.imethod_7() <= 8)
					{
						smethod_5(class4.method_4(), 3);
					}
					else if (class821_0.imethod_7() <= 24)
					{
						smethod_5(class4.method_4(), 5);
					}
					else if (class821_0.imethod_7() <= 32)
					{
						smethod_5(class4.method_4(), 7);
					}
					else if (class821_0.imethod_7() <= 48)
					{
						smethod_5(class4.method_4(), 5);
					}
				}
				else
				{
					if (class821_0.imethod_7() >= 9 && class821_0.imethod_7() <= 16)
					{
						class4.method_4().method_5(Color.FromArgb(255, smethod_7(color_)));
						smethod_5(class4.method_4(), 1);
					}
					else if (class821_0.imethod_7() == 33)
					{
						Color baseColor5 = class821_0.method_16().method_0().method_6(color_2, 0.925);
						baseColor5 = Color.FromArgb(255, baseColor5);
						class4.method_4().method_5(baseColor5);
						smethod_5(class4.method_4(), 1);
					}
					else if (class821_0.imethod_7() == 34)
					{
						Color baseColor6 = class821_0.method_16().method_0().method_7(color, 0.5);
						baseColor6 = Color.FromArgb(255, baseColor6);
						class4.method_4().method_5(baseColor6);
						smethod_5(class4.method_4(), 1);
					}
					if (class821_0.imethod_7() >= 35 && class821_0.imethod_7() <= 40)
					{
						int num4 = class821_0.imethod_7() - 34;
						Color color_7 = class821_0.method_16().method_0().method_2("accent" + num4);
						color_7 = class821_0.method_16().method_0().method_7(color_7, 0.5);
						color_7 = Color.FromArgb(255, color_7);
						class4.method_4().method_5(color_7);
						smethod_5(class4.method_4(), 1);
					}
				}
				if (class2.method_26())
				{
					class4.method_5().method_2().method_5(color2);
					if (class821_0.imethod_7() <= 8)
					{
						class4.method_5().method_5(7);
					}
					else if (class821_0.imethod_7() <= 24)
					{
						class4.method_5().method_5(9);
					}
					else if (class821_0.imethod_7() <= 32)
					{
						class4.method_5().method_5(13);
					}
					else if (class821_0.imethod_7() <= 48)
					{
						class4.method_5().method_5(9);
					}
					class4.method_5().method_4(Struct53.smethod_5(class2, num));
					int markerStyle3 = (int)class4.method_5().MarkerStyle;
					if (markerStyle3 != 5 && markerStyle3 != 6 && markerStyle3 != 8)
					{
						class4.method_5().method_1().method_4(color2);
					}
					else
					{
						class4.method_5().method_1().method_4(Color.Empty);
					}
				}
			}
		}
	}

	private static Color smethod_7(Color color_0)
	{
		Class852 @class = new Class852("r", color_0.R);
		Class852 class2 = new Class852("g", color_0.G);
		Class852 class3 = new Class852("b", color_0.B);
		if (@class.method_0() != 0 && class2.method_0() != 0 && class3.method_0() != 0)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add(@class);
			arrayList.Add(class2);
			arrayList.Add(class3);
			arrayList.Sort();
			Class852 class4 = (Class852)arrayList[0];
			Class852 class5 = (Class852)arrayList[1];
			Class852 class6 = (Class852)arrayList[2];
			int num = class4.method_0();
			foreach (Class852 item in arrayList)
			{
				item.method_3(num - item.method_0());
			}
			int num2 = class4.method_0() + class5.method_0() + class6.method_0();
			int num3 = class4.method_2() + class5.method_2() + class6.method_2();
			int num4 = Struct63.smethod_5((float)num2 / 42f);
			if (num2 > 30)
			{
				if (class6.method_2() == 0)
				{
					int num5 = Struct63.smethod_3(num4 / 3);
					class4.method_1(class4.method_0() - num5);
					class5.method_1(class5.method_0() - num5);
					class6.method_1(class6.method_0() - num5);
				}
				else
				{
					class4.method_1(class4.method_0() - 1);
					num4--;
					if (class5.method_2() == 0)
					{
						class5.method_1(class5.method_0() - 1);
						num4--;
						if (num4 > 0)
						{
							class6.method_1(class6.method_0() - num4);
						}
						else
						{
							class6.method_1(class6.method_0() - 1);
						}
					}
					else
					{
						int num6 = Struct63.smethod_3((float)class5.method_2() / (float)num3 * (float)num4);
						class5.method_1(class5.method_0() - num6);
						num4 -= num6;
						if (num4 > 0)
						{
							class6.method_1(class6.method_0() - num4);
						}
						else
						{
							class6.method_1(class6.method_0() - 1);
						}
					}
				}
			}
		}
		return Color.FromArgb(@class.method_0(), class2.method_0(), class3.method_0());
	}

	internal static void smethod_8(Class821 class821_0)
	{
		smethod_9(class821_0.method_1());
		smethod_9(class821_0.method_9());
		smethod_9(class821_0.method_2());
		smethod_9(class821_0.method_10());
		smethod_9(class821_0.method_11());
	}

	private static void smethod_9(Class823 class823_0)
	{
		Class847 @class = class823_0.method_10();
		class823_0.method_20(((int)@class.Font.Size - 1) / 3 + 1);
		class823_0.method_22((int)((float)class823_0.method_19() * 0.7f + 0.5f));
		if (class823_0.method_21() == class823_0.method_19())
		{
			class823_0.method_22(class823_0.method_19() - 1);
		}
		if (class823_0.method_21() < 1)
		{
			class823_0.method_22(1);
		}
	}

	internal static bool smethod_10(ChartType_Chart chartType_Chart_0)
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

	private static void smethod_11(Class823 class823_0, bool bool_0)
	{
		_ = class823_0.Chart;
		if (class823_0.method_4() == Enum61.const_1 || class823_0.method_4() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0 && class823_0.method_11().bool_0)
		{
			class823_0.method_11().Rotation = 90;
		}
	}

	private static void smethod_12(Class823 class823_0, bool bool_0)
	{
		_ = class823_0.Chart;
		if (class823_0.method_4() == Enum61.const_1 || class823_0.method_4() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0 && class823_0.method_12().method_0())
		{
			class823_0.method_12().Rotation = 90;
		}
	}

	private static void smethod_13(Class823 class823_0, ref Rectangle rectangle_0, bool bool_0, Size size_0)
	{
		Size size = new Size(size_0.Width, size_0.Height);
		_ = class823_0.Chart;
		if (class823_0.method_4() == Enum61.const_1 || class823_0.method_4() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0)
		{
			if (class823_0.bool_10)
			{
				class823_0.method_11().method_0().rectangle_1.X = rectangle_0.X;
				rectangle_0.X += size.Width + int_1;
				rectangle_0.Width -= size.Width + int_1;
			}
			else
			{
				class823_0.method_11().method_0().rectangle_1.X = rectangle_0.Right - size.Width;
				rectangle_0.Width -= size.Width + int_1;
			}
		}
		else if (class823_0.bool_10)
		{
			class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Bottom - size.Height;
			rectangle_0.Height -= size.Height + int_1;
		}
		else
		{
			class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Y;
			rectangle_0.Y += size.Height + int_1;
			rectangle_0.Height -= size.Height + int_1;
		}
		class823_0.method_11().method_0().rectangle_1.Size = size;
	}

	private static void smethod_14(Class823 class823_0, Rectangle rectangle_0, bool bool_0)
	{
		Size size = new Size(class823_0.method_11().method_0().rectangle_1.Size.Width, class823_0.method_11().method_0().rectangle_1.Size.Height);
		Class821 chart = class823_0.Chart;
		if (class823_0.method_4() == Enum61.const_1 || class823_0.method_4() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0)
		{
			if (class823_0.bool_10)
			{
				if (rectangle_0.X < size.Width + int_0 && class823_0.method_11().method_0().imethod_0())
				{
					class823_0.method_11().method_0().rectangle_1.X = rectangle_0.X - size.Width;
				}
				else
				{
					class823_0.method_11().method_0().rectangle_1.X = rectangle_0.X - size.Width;
				}
			}
			else if (chart.Position.Right - rectangle_0.Right < size.Width + int_0 && class823_0.method_11().method_0().imethod_0())
			{
				class823_0.method_11().method_0().rectangle_1.X = chart.Position.Right - size.Width - int_0;
			}
			else
			{
				class823_0.method_11().method_0().rectangle_1.X = rectangle_0.Right;
			}
		}
		else if (class823_0.bool_10)
		{
			if (chart.Position.Bottom - rectangle_0.Bottom < size.Height + int_0 && class823_0.method_11().method_0().vmethod_1())
			{
				class823_0.method_11().method_0().rectangle_1.Y = chart.Position.Bottom - size.Height - int_0;
			}
			else
			{
				class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Bottom;
			}
		}
		else if (rectangle_0.Y < size.Height + int_0 && class823_0.method_11().method_0().vmethod_1())
		{
			class823_0.method_11().method_0().rectangle_1.Y = size.Height + int_0;
		}
		else
		{
			class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Y - size.Height;
		}
		if (class823_0.method_11().method_0().rectangle_1.X < 0)
		{
			class823_0.method_11().method_0().rectangle_1.X = 0;
		}
		else if (class823_0.method_11().method_0().rectangle_1.Right > chart.Width)
		{
			class823_0.method_11().method_0().X = chart.Width - class823_0.method_11().method_0().rectangle_1.Width;
		}
		if (class823_0.method_11().method_0().rectangle_1.Y < 0)
		{
			class823_0.method_11().method_0().rectangle_1.Y = 0;
		}
		else if (class823_0.method_11().method_0().rectangle_1.Bottom > chart.Height)
		{
			class823_0.method_11().method_0().rectangle_1.Y = chart.Height - class823_0.method_11().method_0().rectangle_1.Height;
		}
	}

	private static void smethod_15(Class823 class823_0, bool bool_0, Rectangle rectangle_0)
	{
		_ = class823_0.Chart;
		if (class823_0.method_4() == Enum61.const_1 || class823_0.method_4() == Enum61.const_3)
		{
			bool_0 = !bool_0;
		}
		if (bool_0)
		{
			class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Y + (rectangle_0.Height - class823_0.method_11().method_0().rectangle_1.Height) / 2;
			if (class823_0.method_11().method_0().rectangle_1.Y < rectangle_0.Y)
			{
				class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Y;
			}
		}
		else
		{
			class823_0.method_11().method_0().rectangle_1.X = rectangle_0.X + (rectangle_0.Width - class823_0.method_11().method_0().rectangle_1.Width) / 2;
			if (class823_0.method_11().method_0().rectangle_1.X < rectangle_0.X)
			{
				class823_0.method_11().method_0().rectangle_1.X = rectangle_0.X;
			}
		}
	}

	private static void smethod_16(Class821 class821_0)
	{
		smethod_17(class821_0.method_1());
		smethod_17(class821_0.method_2());
		smethod_17(class821_0.method_9());
		smethod_17(class821_0.method_10());
	}

	private static void smethod_17(Class823 class823_0)
	{
		if (class823_0.method_0() == Enum54.const_1)
		{
			if (class823_0.bool_10)
			{
				class823_0.method_2(Enum0.const_0);
			}
			else
			{
				class823_0.method_2(Enum0.const_1);
			}
		}
		if (class823_0.method_0() == Enum54.const_2)
		{
			if (class823_0.bool_10)
			{
				class823_0.method_2(Enum0.const_0);
			}
			else
			{
				class823_0.method_2(Enum0.const_1);
			}
		}
		if (class823_0.method_0() == Enum54.const_0)
		{
			if (class823_0.bool_10)
			{
				class823_0.method_2(Enum0.const_3);
			}
			else
			{
				class823_0.method_2(Enum0.const_2);
			}
		}
		if (class823_0.method_0() == Enum54.const_3)
		{
			if (class823_0.bool_10)
			{
				class823_0.method_2(Enum0.const_3);
			}
			else
			{
				class823_0.method_2(Enum0.const_2);
			}
		}
	}

	internal static float smethod_18(Class823 class823_0, int int_3, int int_4, bool bool_0)
	{
		float num = 0f;
		bool flag = (bool_0 ? ((!class823_0.IsPlotOrderReversed) ? true : false) : (class823_0.IsPlotOrderReversed ? true : false));
		double num2 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.CrossAt) : class823_0.CrossAt);
		double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num4 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
		if (class823_0.CrossType == Enum66.const_1)
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
		class823_0.CrossAt = (class823_0.IsLogarithmic ? class823_0.method_7(num2) : num2);
		if (!flag)
		{
			return (float)((double)int_3 + (num3 - num2) / (num3 - num4) * (double)int_4);
		}
		return (float)((double)int_3 + (num2 - num4) / (num3 - num4) * (double)int_4);
	}

	internal static float smethod_19(Class823 class823_0, int int_3, int int_4, bool bool_0, Class842 class842_0)
	{
		if (class842_0.Count == 0)
		{
			return 0f;
		}
		float num = 0f;
		bool flag = (bool_0 ? ((!class823_0.IsPlotOrderReversed) ? true : false) : (class823_0.IsPlotOrderReversed ? true : false));
		Class821 chart = class823_0.Chart;
		if (class823_0.CategoryType != Enum64.const_2)
		{
			int num2 = smethod_32(class842_0.method_15());
			int num3 = num2;
			if (class823_0.AxisBetweenCategories || chart.IsDataTableShown)
			{
				num3++;
			}
			int num4 = 1;
			if (num3 <= 1)
			{
				num3 = 2;
			}
			double num5 = class823_0.CrossAt;
			if (class823_0.CrossType == Enum66.const_1)
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
			if (class842_0.method_9(0).method_36())
			{
				num5 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.CrossAt) : class823_0.CrossAt);
				double num6 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
				double num7 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
				if (class823_0.CrossType == Enum66.const_1)
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
				class823_0.CrossAt = (class823_0.IsLogarithmic ? class823_0.method_7(num5) : num5);
				if (flag)
				{
					return (float)((double)int_3 + (num6 - num5) / (num6 - num7) * (double)int_4);
				}
				return (float)((double)int_3 + (num5 - num7) / (num6 - num7) * (double)int_4);
			}
			class823_0.CrossAt = num5;
			if (flag)
			{
				return (float)((double)int_3 + ((double)num3 - num5) / (double)(num3 - num4) * (double)int_4);
			}
			return (float)((double)int_3 + (num5 - (double)num4) / (double)(num3 - num4) * (double)int_4);
		}
		Enum87 baseUnitScale = class823_0.BaseUnitScale;
		int num8 = (int)class823_0.MaxValue;
		int num9 = (int)class823_0.MinValue;
		int num10 = 0;
		if (!class823_0.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num10 = Struct44.smethod_29(baseUnitScale, num8, num9, class823_0.Chart.vmethod_0());
			if (num10 == 0)
			{
				num10 = 1;
			}
		}
		else
		{
			num8 = Struct44.smethod_31(baseUnitScale, baseUnitScale, 1, num8, chart.vmethod_0());
			num10 = Struct44.smethod_29(baseUnitScale, num8, num9, class823_0.Chart.vmethod_0());
		}
		int num11 = Struct44.smethod_32(baseUnitScale, (int)class823_0.CrossAt, chart.vmethod_0());
		if (class823_0.CrossType == Enum66.const_1)
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
		class823_0.CrossAt = num11;
		if (flag)
		{
			return (float)(int_3 + int_4) - (float)Struct44.smethod_29(baseUnitScale, num11, num9, class823_0.Chart.vmethod_0()) / (float)num10 * (float)int_4;
		}
		return (float)int_3 + (float)Struct44.smethod_29(baseUnitScale, num11, num9, class823_0.Chart.vmethod_0()) / (float)num10 * (float)int_4;
	}

	private static void smethod_20(Class823 class823_0, Class823 class823_1, Class842 class842_0, Class821 class821_0)
	{
		ChartType_Chart chartType_Chart = class842_0.method_9(0).method_22();
		switch (class823_0.TickLabelPosition)
		{
		case Enum83.const_0:
			class823_0.int_4 = 2;
			if (class823_1.IsPlotOrderReversed)
			{
				class823_0.int_4 = 1;
			}
			break;
		case Enum83.const_1:
			class823_0.int_4 = 1;
			if (class823_1.IsPlotOrderReversed)
			{
				class823_0.int_4 = 2;
			}
			break;
		case Enum83.const_2:
		{
			class823_0.int_4 = 3;
			if (class823_1.CrossType == Enum66.const_1)
			{
				if (!class823_1.IsPlotOrderReversed)
				{
					class823_0.int_4 = 2;
				}
				else
				{
					class823_0.int_4 = 1;
				}
			}
			else if (class823_1.CrossType == Enum66.const_0)
			{
				if (class823_1.method_4() != Enum61.const_1 && class823_1.method_4() != Enum61.const_3)
				{
					if (class823_1.method_4() == Enum61.const_0 || class823_1.method_4() == Enum61.const_2)
					{
						if (chartType_Chart != ChartType_Chart.Scatter && chartType_Chart != ChartType_Chart.Bubble)
						{
							class823_1.CrossAt = class823_1.MinValue;
						}
						else
						{
							class823_1.CrossAt = 0.0;
						}
					}
				}
				else
				{
					class823_1.CrossAt = 0.0;
				}
			}
			if (class823_1.CrossType != Enum66.const_2)
			{
				break;
			}
			if (class823_1.CategoryType != Enum64.const_2 && (class823_1.method_4() == Enum61.const_0 || class823_1.method_4() == Enum61.const_2) && class842_0.method_9(0).method_22() != ChartType_Chart.Bubble && class842_0.method_9(0).method_22() != ChartType_Chart.Scatter)
			{
				int num = smethod_32(class842_0.method_15());
				int num2 = num;
				if (class823_1.AxisBetweenCategories || class821_0.IsDataTableShown)
				{
					num2++;
				}
				int num3 = 1;
				if (num2 <= 1)
				{
					num2 = 2;
				}
				double num4 = class823_1.CrossAt;
				if (class823_1.CrossType == Enum66.const_1)
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
				if (!class823_1.IsPlotOrderReversed)
				{
					if (num4 == (double)num3)
					{
						class823_0.int_4 = 1;
					}
				}
				else if (num4 == (double)num3)
				{
					class823_0.int_4 = 2;
				}
				break;
			}
			double minValue = class823_1.MinValue;
			if (class823_1.CrossAt <= minValue)
			{
				if (!class823_1.IsPlotOrderReversed)
				{
					class823_0.int_4 = 1;
				}
				else
				{
					class823_0.int_4 = 2;
				}
			}
			break;
		}
		case Enum83.const_3:
			class823_0.int_4 = 0;
			break;
		}
	}

	private static void smethod_21(Class821 class821_0, Interface42 interface42_0, Class823 class823_0, Size size_0, Size size_1, ref Rectangle rectangle_0, bool bool_0)
	{
		if (bool_0)
		{
			switch (class823_0.int_4)
			{
			case 1:
				if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
				{
					class821_0.int_15 += size_0.Height;
					class821_0.int_15 += size_1.Height;
					class821_0.method_4().rectangle_0.Y += size_0.Height + size_1.Height;
				}
				else
				{
					rectangle_0.Height -= size_0.Height;
					rectangle_0.Height -= size_1.Height;
				}
				break;
			case 2:
				if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
				{
					class821_0.int_13 -= size_0.Height;
					class821_0.int_15 += size_0.Height;
					class821_0.int_13 -= size_1.Height;
					class821_0.int_15 += size_1.Height;
				}
				else
				{
					rectangle_0.Y += size_0.Height;
					rectangle_0.Height -= size_0.Height;
					rectangle_0.Y += size_1.Height;
					rectangle_0.Height -= size_1.Height;
				}
				break;
			case 3:
				if (class821_0.method_8().imethod_3() && class821_0.IsDataTableShown)
				{
					rectangle_0.Height -= 5;
				}
				break;
			case 0:
				break;
			}
			return;
		}
		switch (class823_0.int_4)
		{
		case 1:
			if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
			{
				if (!class821_0.IsDataTableShown)
				{
					class821_0.int_12 -= size_0.Width;
					class821_0.int_14 += size_0.Width;
					class821_0.int_12 -= size_1.Width;
					class821_0.int_14 += size_1.Width;
					break;
				}
				Size size = class821_0.method_4().method_1();
				if (size_0.Width + size_1.Width > size.Width)
				{
					class821_0.int_12 -= size_0.Width + size_1.Width - size.Width;
					class821_0.int_14 += size_0.Width + size_1.Width - size.Width;
				}
			}
			else if (!class821_0.IsDataTableShown)
			{
				rectangle_0.X += size_0.Width;
				rectangle_0.Width -= size_0.Width;
				rectangle_0.X += size_1.Width;
				rectangle_0.Width -= size_1.Width;
			}
			else
			{
				Size size2 = class821_0.method_4().method_1();
				if (size_0.Width + size_1.Width > size2.Width)
				{
					rectangle_0.X += size_0.Width + size_1.Width - size2.Width;
					rectangle_0.Width -= size_0.Width + size_1.Width - size2.Width;
				}
			}
			break;
		case 2:
			if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
			{
				class821_0.int_14 += size_0.Width;
				class821_0.int_14 += size_1.Width;
			}
			else
			{
				rectangle_0.Width -= size_0.Width;
				rectangle_0.Width -= size_1.Width;
			}
			break;
		case 0:
		case 3:
			break;
		}
	}

	private static void smethod_22(Class821 class821_0, ref Rectangle rectangle_0)
	{
		int x = rectangle_0.X - class821_0.int_12;
		int num = class821_0.int_12 + class821_0.int_14 - rectangle_0.Right;
		int y = rectangle_0.Y - class821_0.int_13;
		int num2 = class821_0.int_13 + class821_0.int_15 - rectangle_0.Bottom;
		if (class821_0.int_12 < 0)
		{
			class821_0.int_12 = 0;
			int right = rectangle_0.Right;
			rectangle_0.X = x;
			rectangle_0.Width = right - rectangle_0.X;
		}
		if (class821_0.int_14 > class821_0.Width)
		{
			class821_0.int_14 = class821_0.Width;
		}
		int num3 = class821_0.Width - num;
		if (rectangle_0.Right > num3)
		{
			rectangle_0.Width = num3 - rectangle_0.X;
		}
		if (class821_0.int_13 < 0)
		{
			class821_0.int_13 = 0;
			int bottom = rectangle_0.Bottom;
			rectangle_0.Y = y;
			rectangle_0.Height = bottom - rectangle_0.Y;
		}
		if (class821_0.int_15 > class821_0.Height)
		{
			class821_0.int_15 = class821_0.Height;
		}
		int num4 = class821_0.Height - num2;
		if (rectangle_0.Height > num4)
		{
			rectangle_0.Height = num4 - rectangle_0.Y;
		}
	}

	private static void smethod_23(Class821 class821_0, Interface42 interface42_0, Class823 class823_0, Size size_0, int int_3, ref Rectangle rectangle_0, bool bool_0, bool bool_1)
	{
		if (bool_0)
		{
			switch (class823_0.int_4)
			{
			case 1:
				if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
				{
					if (!class821_0.IsDataTableShown)
					{
						class821_0.int_12 -= size_0.Width + int_3;
						class821_0.int_14 += size_0.Width + int_3;
						break;
					}
					Size size = class821_0.method_4().method_1();
					if (size_0.Width + int_3 > size.Width)
					{
						class821_0.int_12 -= size_0.Width + int_3 - size.Width;
						class821_0.int_14 += size_0.Width + int_3 - size.Width;
					}
				}
				else if (!class821_0.IsDataTableShown)
				{
					rectangle_0.X += size_0.Width + int_3;
					rectangle_0.Width -= size_0.Width + int_3;
				}
				else
				{
					Size size2 = class821_0.method_4().method_1();
					if (size_0.Width + int_3 > size2.Width)
					{
						rectangle_0.X += size_0.Width + int_3 - size2.Width;
						rectangle_0.Width -= size_0.Width + int_3 - size2.Width;
					}
				}
				break;
			case 2:
				if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
				{
					class821_0.int_14 += size_0.Width + int_3;
				}
				else
				{
					rectangle_0.Width -= size_0.Width + int_3;
				}
				break;
			case 3:
				smethod_24(Struct44.smethod_36(class823_0), ref rectangle_0, bool_0, size_0, int_3);
				break;
			case 0:
				break;
			}
			return;
		}
		if (class821_0.IsDataTableShown && class823_0.CategoryType != Enum64.const_2)
		{
			class823_0.int_4 = 0;
			class823_0.MajorTickMark = Enum84.const_2;
			class823_0.MinorTickMark = Enum84.const_2;
			int_3 = 0;
		}
		switch (class823_0.int_4)
		{
		case 1:
			if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
			{
				class821_0.int_15 += size_0.Height + int_3;
				class821_0.method_4().rectangle_0.Y += size_0.Height + int_3;
			}
			else
			{
				rectangle_0.Height -= size_0.Height + int_3;
			}
			break;
		case 2:
			if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
			{
				if (class821_0.IsDataTableShown && class823_0.CategoryType == Enum64.const_2)
				{
					class821_0.int_13 -= size_0.Height + int_3;
					class821_0.int_15 += size_0.Height + int_3 + int_1;
				}
				else
				{
					class821_0.int_13 -= size_0.Height + int_3;
					class821_0.int_15 += size_0.Height + int_3;
				}
			}
			else if (class821_0.IsDataTableShown && class823_0.CategoryType == Enum64.const_2)
			{
				rectangle_0.Y += size_0.Height + int_3;
				rectangle_0.Height -= size_0.Height + int_3 + int_1;
			}
			else
			{
				rectangle_0.Y += size_0.Height + int_3;
				rectangle_0.Height -= size_0.Height + int_3;
			}
			break;
		case 3:
			if (!class821_0.method_8().imethod_3() && (class821_0.PlotArea.imethod_3() || class821_0.IsInnerMode))
			{
				if (class821_0.IsDataTableShown && class823_0.CategoryType == Enum64.const_2)
				{
					class821_0.int_15 += int_1;
				}
				else
				{
					smethod_24(Struct44.smethod_36(class823_0), ref rectangle_0, bool_0, size_0, int_3);
				}
			}
			else if (class821_0.IsDataTableShown && class823_0.CategoryType == Enum64.const_2)
			{
				rectangle_0.Height -= int_1;
			}
			else
			{
				smethod_24(Struct44.smethod_36(class823_0), ref rectangle_0, bool_0, size_0, int_3);
			}
			break;
		case 0:
			break;
		}
	}

	internal static void smethod_24(Class823 class823_0, ref Rectangle rectangle_0, bool bool_0, Size size_0, int int_3)
	{
		Size size = Class1181.smethod_2(size_0);
		Class821 chart = class823_0.Chart;
		size.Width += int_3;
		size.Height += int_3;
		_ = rectangle_0.Y;
		float num = rectangle_0.Height;
		if (bool_0)
		{
			_ = rectangle_0.X;
			num = rectangle_0.Width;
		}
		double num2 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.CrossAt) : class823_0.CrossAt);
		double num3 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MaxValue) : class823_0.MaxValue);
		double num4 = (class823_0.IsLogarithmic ? class823_0.method_6(class823_0.MinValue) : class823_0.MinValue);
		if (class823_0.CrossType == Enum66.const_1)
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
			Rectangle rectangle = Class1181.smethod_4(rectangle_0);
			while (num6 > 0)
			{
				rectangle_0 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
				int num7 = (int)((float)size.Width - num5);
				if (num7 > 0)
				{
					if (chart.method_8().imethod_3())
					{
						if (class823_0.IsPlotOrderReversed)
						{
							rectangle_0.Width -= num7;
						}
						else
						{
							rectangle_0.X += num7;
							rectangle_0.Width -= num7;
						}
					}
					else if (class823_0.IsPlotOrderReversed)
					{
						chart.int_14 += num7;
					}
					else
					{
						chart.int_12 -= num7;
						chart.int_14 += num7;
					}
				}
				num5 = (float)rectangle_0.Width * num5 / (float)rectangle.Width;
				num6--;
			}
			return;
		}
		int num8 = 2;
		Rectangle rectangle2 = Class1181.smethod_4(rectangle_0);
		while (num8 > 0)
		{
			rectangle_0 = new Rectangle(rectangle2.X, rectangle2.Y, rectangle2.Width, rectangle2.Height);
			int num9 = (int)((float)size.Height - num5);
			if (num9 > 0)
			{
				if (chart.method_8().imethod_3())
				{
					if (class823_0.IsPlotOrderReversed)
					{
						rectangle_0.Y += num9;
						rectangle_0.Height -= num9;
					}
					else
					{
						rectangle_0.Height -= num9;
					}
				}
				else if (class823_0.IsPlotOrderReversed)
				{
					chart.int_13 -= num9;
					chart.int_15 += num9;
				}
				else
				{
					chart.int_15 += num9;
				}
			}
			num5 = (float)rectangle_0.Height * num5 / (float)rectangle2.Height;
			num8--;
		}
	}

	private static void smethod_25(Interface42 interface42_0, Class821 class821_0, Class844 class844_0, Class844 class844_1, ref Rectangle rectangle_0)
	{
		if (!class844_0.method_33() && !class844_1.method_33())
		{
			if (!class844_0.method_34() && !class844_1.method_34())
			{
				return;
			}
			SizeF sizeF_ = new SizeF((float)class821_0.Width * 0.2f, class821_0.Height);
			bool flag = class821_0.method_1().TickLabelPosition != Enum83.const_3;
			bool flag2 = class821_0.method_2().TickLabelPosition != Enum83.const_3;
			if (class821_0.method_8().imethod_3())
			{
				Size empty = Size.Empty;
				int num = 0;
				int num2 = 0;
				if (class844_0.method_34() && flag)
				{
					class821_0.method_1().float_0 = sizeF_.Width;
					class821_0.method_1().float_1 = sizeF_.Height;
					Size size = Struct61.smethod_6(interface42_0, "a", class821_0.method_1().method_10().Font);
					class821_0.method_1().method_10().method_2(size.Width / 2);
					num = class821_0.method_1().method_10().method_1();
					for (int i = 0; i < class821_0.method_1().arrayList_1.Count; i++)
					{
						string string_ = class821_0.method_1().arrayList_1[i].ToString();
						Font font = class821_0.method_1().method_10().Font;
						int rotation = class821_0.method_1().method_10().Rotation;
						Size size2 = Struct61.smethod_8(class821_0.imethod_0(), string_, rotation, font, sizeF_, Enum82.const_1, Enum82.const_1);
						if (size2.Width > empty.Width)
						{
							empty.Width = size2.Width;
						}
						if (size2.Height > empty.Height)
						{
							empty.Height = size2.Height;
						}
					}
				}
				if (class844_1.method_34() && flag2)
				{
					class821_0.method_2().float_0 = sizeF_.Width;
					class821_0.method_2().float_1 = sizeF_.Height;
					Size size3 = Struct61.smethod_6(interface42_0, "a", class821_0.method_2().method_10().Font);
					class821_0.method_2().method_10().method_2(size3.Width / 2);
					num2 = class821_0.method_2().method_10().method_1();
					for (int j = 0; j < class821_0.method_2().arrayList_1.Count; j++)
					{
						string string_2 = class821_0.method_2().arrayList_1[j].ToString();
						Font font2 = class821_0.method_2().method_10().Font;
						int rotation2 = class821_0.method_2().method_10().Rotation;
						Size size4 = Struct61.smethod_8(class821_0.imethod_0(), string_2, rotation2, font2, sizeF_, Enum82.const_1, Enum82.const_1);
						if (size4.Width > empty.Width)
						{
							empty.Width = size4.Width;
						}
						if (size4.Height > empty.Height)
						{
							empty.Height = size4.Height;
						}
					}
				}
				if (empty != Size.Empty)
				{
					if (num < num2)
					{
						num = num2;
					}
					empty.Width += num;
					empty.Height += num;
				}
				rectangle_0.Inflate(-empty.Width, -empty.Height);
			}
			else
			{
				if (class844_0.method_34() && flag)
				{
					class821_0.method_1().float_0 = sizeF_.Width;
					class821_0.method_1().float_1 = sizeF_.Height;
				}
				if (class844_1.method_34() && flag2)
				{
					class821_0.method_2().float_0 = sizeF_.Width;
					class821_0.method_2().float_1 = sizeF_.Height;
				}
			}
			Struct63.smethod_17(ref rectangle_0);
			int num3 = 15;
			if (rectangle_0.Width < 15)
			{
				rectangle_0.Width = num3;
			}
			if (rectangle_0.Height < num3)
			{
				rectangle_0.Height = num3;
			}
			return;
		}
		ChartType_Chart type = class844_0.Type;
		ChartType_Chart type2 = class844_1.Type;
		int num4 = 75;
		int num5 = 100;
		Struct59.smethod_15(class821_0, ref rectangle_0, class844_0);
		Struct59.smethod_15(class821_0, ref rectangle_0, class844_1);
		if (type != ChartType_Chart.PiePie && type2 != ChartType_Chart.PiePie)
		{
			if (type != ChartType_Chart.PieBar && type2 != ChartType_Chart.PieBar)
			{
				Struct63.smethod_17(ref rectangle_0);
				return;
			}
			if (type == ChartType_Chart.PieBar)
			{
				num4 = class844_0.vmethod_2();
				num5 = class844_0.GapWidth / 2;
			}
			if (type2 == ChartType_Chart.PieBar)
			{
				num4 = class844_1.vmethod_2();
				num5 = class844_1.GapWidth / 2;
			}
			int num6 = 100 * rectangle_0.Width / (100 + num4 + num5);
			if (num4 <= 100)
			{
				if (num6 <= rectangle_0.Height / 2)
				{
					class821_0.method_19(num6);
				}
				else
				{
					class821_0.method_19(rectangle_0.Height / 2);
				}
				class821_0.method_21((int)((float)(class821_0.method_18() * num4) / 100f));
				class821_0.method_23((int)((float)(class821_0.method_18() * num5) / 100f));
				return;
			}
			int num7 = num4 * num6 / 100;
			if (num7 <= rectangle_0.Height / 2)
			{
				class821_0.method_21(num7);
			}
			else
			{
				class821_0.method_21(rectangle_0.Height / 2);
			}
			class821_0.method_19(class821_0.method_20() * 100 / num4);
			class821_0.method_23((int)((float)(class821_0.method_18() * num5) / 100f));
			return;
		}
		if (type == ChartType_Chart.PiePie)
		{
			num4 = class844_0.vmethod_2();
			num5 = class844_0.GapWidth;
		}
		if (type2 == ChartType_Chart.PiePie)
		{
			num4 = class844_1.vmethod_2();
			num5 = class844_1.GapWidth;
		}
		int num8 = 100 * rectangle_0.Width / (200 + 2 * num4 + num5);
		if (num4 <= 100)
		{
			if (num8 <= rectangle_0.Height / 2)
			{
				class821_0.method_19(num8);
			}
			else
			{
				class821_0.method_19(rectangle_0.Height / 2);
			}
			class821_0.method_21((int)((float)(class821_0.method_18() * num4) / 100f));
			class821_0.method_23((int)((float)(class821_0.method_18() * num5) / 100f));
			return;
		}
		int num9 = num4 * num8 / 100;
		if (num9 <= rectangle_0.Height / 2)
		{
			class821_0.method_21(num9);
		}
		else
		{
			class821_0.method_21(rectangle_0.Height / 2);
		}
		class821_0.method_19(class821_0.method_20() * 100 / num4);
		class821_0.method_23((int)((float)(class821_0.method_18() * num5) / 100f));
	}

	private static void smethod_26(Class823 class823_0, Class842 class842_0)
	{
		ArrayList arrayList_ = class823_0.arrayList_1;
		bool flag = ((class823_0.method_4() == Enum61.const_1 || class823_0.method_4() == Enum61.const_3) ? true : false);
		IList list = class842_0.method_16();
		for (int i = 0; i < list.Count; i++)
		{
			Class844 @class = (Class844)list[i];
			ChartType_Chart chartType_Chart = @class.method_22();
			Class834 class2 = ((!flag) ? @class.method_4() : @class.method_3());
			if (class2 == null || class2.DisplayType == Enum68.const_2)
			{
				continue;
			}
			for (int j = 0; j < @class.method_9().Count; j++)
			{
				Class831 class3 = @class.method_9().method_1(j);
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
						Class831 class4 = ((Class844)list[k]).method_9().method_1(j);
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
						Class831 class5 = ((Class844)list[l]).method_9().method_1(j);
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
						Class831 class6 = ((Class844)list[m]).method_9().method_1(j);
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
				if (num3 > 0.0 && num3 + num >= class823_0.MaxValue && (class2.DisplayType == Enum68.const_0 || class2.DisplayType == Enum68.const_3))
				{
					for (double num8 = class823_0.MaxValue + class823_0.MajorUnit; num8 <= num3 + num + class823_0.MajorUnit; num8 += class823_0.MajorUnit)
					{
						arrayList_.Insert(0, num8);
					}
					class823_0.MaxValue = (double)arrayList_[0];
				}
				if (num2 < 0.0 && 0.0 - num2 + num >= class823_0.MaxValue && (class2.DisplayType == Enum68.const_0 || class2.DisplayType == Enum68.const_1))
				{
					for (double num9 = class823_0.MaxValue + class823_0.MajorUnit; num9 <= 0.0 - num2 + num + class823_0.MajorUnit; num9 += class823_0.MajorUnit)
					{
						arrayList_.Insert(0, num9);
					}
					class823_0.MaxValue = (double)arrayList_[0];
				}
				if (num2 > 0.0 && num - num2 <= class823_0.MinValue && (class2.DisplayType == Enum68.const_0 || class2.DisplayType == Enum68.const_1))
				{
					for (double num10 = class823_0.MinValue - class823_0.MajorUnit; num10 >= num - num2 - class823_0.MajorUnit; num10 -= class823_0.MajorUnit)
					{
						arrayList_.Add(num10);
					}
					class823_0.MinValue = (double)arrayList_[arrayList_.Count - 1];
				}
				if (num3 < 0.0 && num + num3 <= class823_0.MinValue && (class2.DisplayType == Enum68.const_0 || class2.DisplayType == Enum68.const_3))
				{
					for (double num11 = class823_0.MinValue - class823_0.MajorUnit; num11 >= num + num3 - class823_0.MajorUnit; num11 -= class823_0.MajorUnit)
					{
						arrayList_.Add(num11);
					}
					class823_0.MinValue = (double)arrayList_[arrayList_.Count - 1];
				}
			}
		}
	}

	private static void smethod_27(Class821 class821_0, bool bool_0, bool bool_1)
	{
		smethod_28(class821_0.method_1(), bool_0);
		smethod_28(class821_0.method_2(), bool_1);
		smethod_28(class821_0.method_9(), bool_0);
		smethod_28(class821_0.method_10(), bool_1);
	}

	private static void smethod_28(Class823 class823_0, bool bool_0)
	{
		Class823 @class = Struct44.smethod_36(class823_0);
		if (@class == null)
		{
			return;
		}
		if (@class.CrossType == Enum66.const_1 && !@class.IsPlotOrderReversed)
		{
			if (!bool_0)
			{
				if (class823_0.method_3())
				{
					class823_0.method_1(Enum54.const_3);
				}
				else
				{
					class823_0.method_1(Enum54.const_2);
				}
			}
			else if (class823_0.method_3())
			{
				class823_0.method_1(Enum54.const_2);
			}
			else
			{
				class823_0.method_1(Enum54.const_3);
			}
		}
		else if (@class.CrossType != Enum66.const_1 && @class.IsPlotOrderReversed)
		{
			if (!bool_0)
			{
				if (class823_0.method_3())
				{
					class823_0.method_1(Enum54.const_3);
				}
				else
				{
					class823_0.method_1(Enum54.const_2);
				}
			}
			else if (class823_0.method_3())
			{
				class823_0.method_1(Enum54.const_2);
			}
			else
			{
				class823_0.method_1(Enum54.const_3);
			}
		}
		else if (!bool_0)
		{
			if (class823_0.method_3())
			{
				class823_0.method_1(Enum54.const_0);
			}
			else
			{
				class823_0.method_1(Enum54.const_1);
			}
		}
		else if (class823_0.method_3())
		{
			class823_0.method_1(Enum54.const_1);
		}
		else
		{
			class823_0.method_1(Enum54.const_0);
		}
		if (class823_0.TickLabelPosition == Enum83.const_0)
		{
			switch (class823_0.method_0())
			{
			case Enum54.const_0:
				class823_0.method_1(Enum54.const_3);
				break;
			case Enum54.const_1:
				class823_0.method_1(Enum54.const_2);
				break;
			case Enum54.const_2:
				class823_0.method_1(Enum54.const_1);
				break;
			case Enum54.const_3:
				class823_0.method_1(Enum54.const_0);
				break;
			}
		}
	}

	internal static void smethod_29(Class821 class821_0)
	{
		ArrayList arrayList = class821_0.method_7().method_16();
		Class836 legendEntries = class821_0.method_4().LegendEntries;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class844 @class = (Class844)arrayList[i];
			Class837 class2 = new Class837(class821_0, class821_0.ChartDataTable, i);
			class2.Name = @class.Name;
			class2.Type = Enum56.const_0;
			class2.method_1(@class);
			legendEntries.Add(class2);
		}
	}

	internal static void smethod_30(Class821 class821_0)
	{
		ArrayList arrayList = class821_0.method_7().method_16();
		Class838 @class = class821_0.method_6();
		Class836 class2 = @class.method_2();
		Class836 class3 = @class.method_1();
		bool flag = true;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class844 class4 = (Class844)arrayList[i];
			if (i == 0 && class4.PlotOnSecondAxis)
			{
				flag = false;
			}
			int num = class4.vmethod_5();
			Class837 class5 = class2.method_1(num);
			if (class5 == null)
			{
				Class837 class6 = new Class837(class821_0, @class, num);
				class6.Name = class4.Name;
				class6.Type = Enum56.const_0;
				class6.method_1(class4);
				class3.Add(class6);
			}
			else if (!class5.IsDeleted)
			{
				Class837 class7 = new Class837(class821_0, @class, num);
				class7.Name = class4.Name;
				class7.Type = Enum56.const_0;
				class7.method_1(class4);
				class7.Font = class5.Font;
				class7.FontColor = class5.FontColor;
				class3.Add(class7);
			}
		}
		if (flag)
		{
			ArrayList arrayList2 = class821_0.method_7().method_20();
			int int_ = ((class3.Count > 0) ? (class3.Count - 1) : 0);
			for (int j = 0; j < arrayList2.Count; j++)
			{
				Class850 class8 = (Class850)arrayList2[j];
				int num2 = arrayList.Count + class8.vmethod_0();
				Class837 class9 = class2.method_1(num2);
				if (class9 == null)
				{
					Class837 class10 = new Class837(class821_0, @class, num2);
					class10.Name = class8.Name;
					class10.Type = Enum56.const_1;
					class10.method_1(class8.method_0().method_0());
					class10.method_3(class8);
					smethod_31(class10, class3, int_);
				}
				else if (!class9.IsDeleted)
				{
					Class837 class11 = new Class837(class821_0, @class, num2);
					class11.Name = class8.Name;
					class11.Type = Enum56.const_1;
					class11.method_1(class8.method_0().method_0());
					class11.method_3(class8);
					class11.Font = class9.Font;
					class11.FontColor = class9.FontColor;
					smethod_31(class11, class3, int_);
				}
			}
			return;
		}
		ArrayList arrayList3 = class821_0.method_7().method_21();
		int int_2 = ((class3.Count > 0) ? (class3.Count - 1) : 0);
		for (int k = 0; k < arrayList3.Count; k++)
		{
			Class850 class12 = (Class850)arrayList3[k];
			int num3 = arrayList.Count + class12.vmethod_0();
			Class837 class13 = class2.method_1(num3);
			if (class13 == null)
			{
				Class837 class14 = new Class837(class821_0, @class, num3);
				class14.Name = class12.Name;
				class14.Type = Enum56.const_1;
				class14.method_1(class12.method_0().method_0());
				class14.method_3(class12);
				smethod_31(class14, class3, int_2);
			}
			else if (!class13.IsDeleted)
			{
				Class837 class15 = new Class837(class821_0, @class, num3);
				class15.Name = class12.Name;
				class15.Type = Enum56.const_1;
				class15.method_1(class12.method_0().method_0());
				class15.method_3(class12);
				class15.Font = class13.Font;
				class15.FontColor = class13.FontColor;
				smethod_31(class15, class3, int_2);
			}
		}
	}

	private static void smethod_31(Class837 class837_0, Class836 class836_0, int int_3)
	{
		if (class836_0.Count == 0)
		{
			class836_0.Add(class837_0);
			return;
		}
		bool flag = false;
		for (int i = int_3; i < class836_0.Count; i++)
		{
			if (class836_0[i].vmethod_0() > class837_0.vmethod_0())
			{
				class836_0.Insert(i, class837_0);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			class836_0.Add(class837_0);
		}
	}

	internal static int smethod_32(IList ilist_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < ilist_0.Count; i++)
		{
			arrayList.Add(((Class844)ilist_0[i]).method_9().Count);
		}
		arrayList.Sort();
		if (arrayList.Count == 0)
		{
			return 0;
		}
		return (int)arrayList[arrayList.Count - 1];
	}

	internal static bool smethod_33(IList list, out double minValue, out double maxValue, Class823 axis)
	{
		IList list2 = smethod_34(list);
		minValue = 0.0;
		maxValue = 0.0;
		int num = 0;
		for (int i = 0; i < list2.Count; i++)
		{
			double minValue2;
			double maxValue2;
			bool flag = smethod_35((ArrayList)list2[i], out minValue2, out maxValue2);
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
		if (num == list2.Count && axis.imethod_3() != axis.imethod_5())
		{
			minValue = 0.0;
			maxValue = 1.0;
			if (!axis.imethod_3())
			{
				axis.MinValue = 0.0;
			}
			if (!axis.imethod_5())
			{
				axis.MaxValue = 1.0;
			}
		}
		else
		{
			if (!axis.imethod_3())
			{
				minValue = (axis.IsLogarithmic ? axis.method_6(axis.MinValue) : axis.MinValue);
			}
			if (!axis.imethod_5())
			{
				maxValue = (axis.IsLogarithmic ? axis.method_6(axis.MaxValue) : axis.MaxValue);
			}
		}
		return smethod_45(list);
	}

	private static IList smethod_34(IList ilist_0)
	{
		Class844 @class = (Class844)ilist_0[0];
		ArrayList arrayList = new ArrayList();
		ArrayList arrayList2 = new ArrayList();
		ArrayList arrayList3 = new ArrayList();
		foreach (Class844 item in ilist_0)
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
			@class = (Class844)arrayList2[0];
			ArrayList arrayList5 = new ArrayList();
			arrayList5.AddRange(arrayList2);
			arrayList2.Clear();
			foreach (Class844 item2 in arrayList5)
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

	private static bool smethod_35(ArrayList list, out double minValue, out double maxValue)
	{
		bool result = false;
		Class843 comparer = new Class843();
		list.Sort(comparer);
		minValue = 0.0;
		maxValue = 0.0;
		Class844 @class = (Class844)list[0];
		if (@class.method_29())
		{
			if (@class.method_30())
			{
				int num = smethod_32(list);
				bool flag = true;
				for (int i = 0; i < num; i++)
				{
					double num2 = 0.0;
					for (int j = 0; j < list.Count; j++)
					{
						Class844 class2 = (Class844)list[j];
						if (!class2.method_29())
						{
							break;
						}
						Class831 class3 = class2.method_9().method_1(i);
						if (class3 == null || class3.imethod_0() || class3 == null)
						{
							continue;
						}
						double yValue = class3.YValue;
						num2 += yValue;
						if (flag)
						{
							flag = false;
							result = true;
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
				int num3 = smethod_36(list);
				new ArrayList();
				int num4 = smethod_32(list);
				bool flag2 = true;
				for (int k = 0; k < num4; k++)
				{
					double num5 = 0.0;
					double num6 = 0.0;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = true;
					for (int l = 0; l < list.Count; l++)
					{
						Class844 class4 = (Class844)list[l];
						if (!class4.method_29())
						{
							break;
						}
						Class831 class5 = class4.method_9().method_1(k);
						if (class5 == null || class5.imethod_0() || class5 == null)
						{
							continue;
						}
						double yValue2 = class5.YValue;
						if (flag2)
						{
							flag2 = false;
							flag5 = false;
							result = true;
							switch (num3)
							{
							case 1:
								minValue = yValue2;
								break;
							case 2:
								maxValue = yValue2;
								break;
							}
						}
						else if (flag5)
						{
							flag5 = false;
							if (num3 == 1 && yValue2 < minValue)
							{
								minValue = yValue2;
							}
							else if (num3 == 2 && yValue2 > maxValue)
							{
								maxValue = yValue2;
							}
						}
						if (yValue2 < 0.0)
						{
							flag4 = true;
							num6 += yValue2;
						}
						if (yValue2 > 0.0)
						{
							flag3 = true;
							num5 += yValue2;
						}
					}
					if (flag4 && num6 < minValue)
					{
						minValue = num6;
					}
					if (flag3 && num5 > maxValue)
					{
						maxValue = num5;
					}
				}
			}
		}
		else if (@class.method_31())
		{
			result = true;
			if (@class.method_32())
			{
				int num7 = smethod_32(list);
				for (int m = 0; m < num7; m++)
				{
					double num8 = 0.0;
					double num9 = 0.0;
					double num10 = 0.0;
					double num11 = 0.0;
					for (int n = 0; n < list.Count; n++)
					{
						Class844 class6 = (Class844)list[n];
						if (!class6.method_31())
						{
							break;
						}
						Class831 class7 = class6.method_9().method_1(m);
						if (class7 != null)
						{
							double yValue3 = class7.YValue;
							num8 += yValue3;
							num9 += Math.Abs(yValue3);
							if (num8 < num10)
							{
								num10 = num8;
							}
							if (num8 > num11)
							{
								num11 = num8;
							}
						}
					}
					if (num9 != 0.0)
					{
						int num12 = (int)(100.0 * num10 / num9);
						if ((double)num12 < minValue)
						{
							minValue = num12;
						}
						num12 = (int)(100.0 * num11 / num9);
						if ((double)num12 > maxValue)
						{
							maxValue = num12;
						}
					}
				}
			}
			else
			{
				int num13 = smethod_32(list);
				for (int num14 = 0; num14 < num13; num14++)
				{
					double num15 = 0.0;
					double num16 = 0.0;
					double num17 = 0.0;
					for (int num18 = 0; num18 < list.Count; num18++)
					{
						Class844 class8 = (Class844)list[num18];
						if (!class8.method_31())
						{
							break;
						}
						Class831 class9 = class8.method_9().method_1(num14);
						if (class9 != null)
						{
							double yValue4 = class9.YValue;
							num15 += Math.Abs(yValue4);
							if (yValue4 < 0.0)
							{
								num17 += yValue4;
							}
							if (yValue4 > 0.0)
							{
								num16 += yValue4;
							}
						}
					}
					if (num15 != 0.0)
					{
						if ((double)(int)(100.0 * num17 / num15) < minValue)
						{
							minValue = (int)(100.0 * num17 / num15);
						}
						if ((double)(int)(100.0 * num16 / num15) > maxValue)
						{
							maxValue = (int)(100.0 * num16 / num15);
						}
					}
				}
			}
		}
		else
		{
			bool flag6 = true;
			for (int num19 = 0; num19 < list.Count; num19++)
			{
				Class830 class10 = ((Class844)list[num19]).method_9();
				for (int num20 = 0; num20 < class10.Count; num20++)
				{
					if (class10[num20] != null && class10[num20].imethod_0())
					{
						continue;
					}
					if (class10[num20] != null && class10[num20].imethod_6())
					{
						result = true;
						continue;
					}
					double num21 = ((class10[num20] == null) ? 0.0 : class10[num20].YValue);
					if (flag6)
					{
						minValue = num21;
						maxValue = num21;
						result = true;
						flag6 = false;
						continue;
					}
					if (num21 < minValue)
					{
						minValue = num21;
					}
					if (num21 > maxValue)
					{
						maxValue = num21;
					}
				}
			}
		}
		return result;
	}

	internal static int smethod_36(ArrayList arrayList_0)
	{
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class830 @class = ((Class844)arrayList_0[i]).method_9();
			for (int j = 0; j < @class.Count; j++)
			{
				if (@class[j] != null)
				{
					double yValue = @class[j].YValue;
					if (yValue > 0.0)
					{
						flag = true;
					}
					else if (yValue < 0.0)
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

	private static bool smethod_37(IList list, out double minValue, out double maxValue, Class823 axis)
	{
		minValue = 2147483647.0;
		maxValue = -2147483648.0;
		for (int i = 0; i < list.Count; i++)
		{
			Class844 @class = (Class844)list[i];
			Class830 class2 = @class.method_9();
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
			for (int k = 0; k < @class.method_10().Count; k++)
			{
				Class850 class3 = @class.method_10().method_1(k);
				if (class3.method_1().IsVisible)
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
			minValue = (axis.IsLogarithmic ? axis.method_6(axis.MinValue) : axis.MinValue);
		}
		if (!axis.imethod_5())
		{
			maxValue = (axis.IsLogarithmic ? axis.method_6(axis.MaxValue) : axis.MaxValue);
		}
		return smethod_46(list);
	}

	private static bool smethod_38(Class821 class821_0, IList ilist_0, IList ilist_1)
	{
		if (ilist_1.Count > 0 && ilist_0.Count > 0)
		{
			Class823 @class = class821_0.method_9();
			Class823 class2 = class821_0.method_10();
			Class844 class3 = (Class844)ilist_0[0];
			Class844 class4 = (Class844)ilist_1[0];
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

	private static Class823 smethod_39(Class821 class821_0)
	{
		Class823 @class = class821_0.method_9();
		Class823 class2 = class821_0.method_10();
		if (!@class.IsVisible && class2.IsVisible)
		{
			return class2;
		}
		return @class;
	}

	private static Class823 smethod_40(Class821 class821_0)
	{
		Class823 @class = class821_0.method_9();
		Class823 class2 = class821_0.method_10();
		if (!@class.IsVisible && class2.IsVisible)
		{
			return @class;
		}
		return class2;
	}

	internal static bool smethod_41(IList primarySeries, IList secondarySeries, out double minValue, out double maxValue, Class823 axis)
	{
		smethod_42(primarySeries, out var minValue2, out var maxValue2);
		smethod_42(secondarySeries, out var minValue3, out var maxValue3);
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
			minValue = (axis.IsLogarithmic ? axis.method_6(axis.MinValue) : axis.MinValue);
		}
		if (!axis.imethod_5())
		{
			maxValue = (axis.IsLogarithmic ? axis.method_6(axis.MaxValue) : axis.MaxValue);
		}
		if (smethod_45(primarySeries))
		{
			return smethod_45(secondarySeries);
		}
		return false;
	}

	internal static void smethod_42(IList list, out double minValue, out double maxValue)
	{
		IList list2 = smethod_34(list);
		minValue = 0.0;
		maxValue = 0.0;
		for (int i = 0; i < list2.Count; i++)
		{
			smethod_35((ArrayList)list2[i], out var minValue2, out var maxValue2);
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

	private static void smethod_43(Class823 class823_0, Class823 class823_1)
	{
		class823_0.arrayList_1 = class823_1.arrayList_1;
		class823_0.MaxValue = class823_1.MaxValue;
		class823_0.MinValue = class823_1.MinValue;
		class823_0.MajorUnitScale = class823_1.MajorUnitScale;
		class823_0.MajorUnit = class823_1.MajorUnit;
		class823_0.MinorUnitScale = class823_1.MinorUnitScale;
		class823_0.MinorUnit = class823_1.MinorUnit;
	}

	private static void smethod_44(Class823 class823_0)
	{
		class823_0.arrayList_0 = class823_0.arrayList_1;
		class823_0.double_5 = class823_0.MaxValue;
		class823_0.double_6 = class823_0.MinValue;
		class823_0.double_7 = class823_0.MajorUnit;
		class823_0.double_8 = class823_0.MinorUnit;
	}

	private static bool smethod_45(IList ilist_0)
	{
		bool result = true;
		foreach (Class844 item in ilist_0)
		{
			if (!item.method_19())
			{
				result = false;
			}
		}
		return result;
	}

	private static bool smethod_46(IList ilist_0)
	{
		bool result = true;
		foreach (Class844 item in ilist_0)
		{
			if (!item.method_18())
			{
				result = false;
			}
		}
		return result;
	}

	internal static void smethod_47(Interface42 interface42_0, Class823 class823_0, double double_0, double double_1, bool bool_0, ArrayList arrayList_0, ChartType_Chart chartType_Chart_0, Rectangle rectangle_0, bool bool_1, Class844 class844_0)
	{
		if (class823_0.IsLogarithmic)
		{
			smethod_76(interface42_0, class823_0, double_0, double_1, arrayList_0, chartType_Chart_0, rectangle_0, bool_1, class844_0);
			return;
		}
		double num = double_0;
		double num2 = double_1;
		_ = class823_0.Chart;
		bool flag = smethod_56(chartType_Chart_0);
		if (double_0 == double_1 && double_0 == 0.0)
		{
			double num3 = 1.2;
			if (!bool_0 || smethod_59(class844_0.Type))
			{
				num3 = 1.0;
			}
			if (flag)
			{
				num3 = 100.0;
			}
			class823_0.MaxValue = num3;
			double_0 = num3;
			num = num3;
			class823_0.MinValue = 0.0;
		}
		else if (double_0 <= double_1)
		{
			if (!class823_0.imethod_5() && class823_0.imethod_3())
			{
				class823_0.MinValue = double_0 - 1.0;
				double_1 = class823_0.MinValue;
			}
			else if (class823_0.imethod_5() && !class823_0.imethod_3())
			{
				class823_0.MaxValue = double_1 + 1.0;
				double_0 = class823_0.MaxValue;
			}
		}
		bool flag2 = class823_0.imethod_5();
		bool flag3 = class823_0.imethod_3();
		double double_2 = 0.0;
		int int_ = 1;
		if (flag)
		{
			if (double_0 == 100.0 && class823_0.imethod_5())
			{
				class823_0.MaxValue = 100.0;
			}
			if (double_1 == -100.0 && class823_0.imethod_3())
			{
				class823_0.MinValue = -100.0;
			}
		}
		double double_3 = 0.0;
		double double_4 = 0.0;
		smethod_48(ref double_3, ref double_4, ref double_1, ref double_0, ref double_2, ref int_, class823_0, bool_1, num, num2, flag2, flag3);
		if (!class823_0.imethod_9())
		{
			if (!class823_0.imethod_7() && class823_0.MajorUnit < class823_0.MinorUnit)
			{
				throw new ArgumentException("The numbers you specified can't be used because the interval for the minor unittick marks must be less than or equal to the interval for the major unit tick marks!");
			}
			if (double_2 < class823_0.MinorUnit)
			{
				double_2 = class823_0.MinorUnit;
			}
		}
		smethod_50(class823_0, int_, double_2, double_4, double_3, arrayList_0, num, num2, flag2, flag3, flag);
		int num4 = smethod_51(interface42_0, class823_0, bool_1, class844_0, rectangle_0);
		int num5 = 0;
		num5 = (class823_0.Chart.method_17() ? ((!bool_1) ? ((int)class823_0.Chart.method_13().Height) : ((int)class823_0.Chart.method_13().Width)) : ((!bool_1) ? rectangle_0.Height : rectangle_0.Width));
		while (class823_0.imethod_7() && arrayList_0.Count > 3 && num4 > num5 && num5 != 0)
		{
			smethod_52(double_2, out double_2, out var _);
			double_2 *= 10.0;
			smethod_50(class823_0, int_, double_2, double_4, double_3, arrayList_0, num, num2, flag2, flag3, flag);
			num4 = smethod_51(interface42_0, class823_0, bool_1, class844_0, rectangle_0);
		}
		if (arrayList_0.Count >= 2)
		{
			class823_0.MaxValue = (double)arrayList_0[0];
			class823_0.MinValue = (double)arrayList_0[arrayList_0.Count - 1];
			if (class823_0.imethod_7())
			{
				class823_0.MajorUnit = double_2;
			}
			if (class823_0.imethod_9())
			{
				class823_0.MinorUnit = class823_0.MajorUnit / 5.0;
			}
		}
	}

	private static void smethod_48(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref int int_3, Class823 class823_0, bool bool_0, double double_5, double double_6, bool bool_1, bool bool_2)
	{
		double num = Struct63.smethod_10(double_3, Struct63.smethod_7(double_3));
		double num2 = Struct63.smethod_10(double_2, Struct63.smethod_7(double_2));
		if (class823_0.imethod_7())
		{
			bool flag = true;
			smethod_52(double_2, out var step, out var maxScale);
			smethod_52(double_3, out var step2, out var maxScale2);
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
				double num3 = Struct63.smethod_9(double_3, double_2);
				smethod_52(num3, out var step3, out var maxScale3);
				if (double_2 / num3 >= 5.0)
				{
					double_1 = Struct63.smethod_9(double_2, maxScale3) / 2.0;
					double_0 = double_2 + maxScale3;
					double_4 = Math.Abs(step3);
					if (Struct63.smethod_9(double_3, double_2) / double_4 >= 8.0)
					{
						smethod_54(ref double_4);
					}
					int int_4 = Struct63.smethod_7(double_4);
					double num4 = 0.0;
					num4 = Struct63.smethod_10(Math.Floor((3.0 * double_2 - double_3) / (2.0 * double_4)) * double_4, int_4);
					if (class823_0.imethod_3() && class823_0.imethod_5())
					{
						if (class823_0.method_4() == Enum61.const_0 || class823_0.method_4() == Enum61.const_2)
						{
							for (; !(Struct63.smethod_9(double_6, num4) <= double_4) && num4 != 0.0; num4 += double_4)
							{
							}
						}
						class823_0.MinValue = num4;
						double_1 = num4;
					}
				}
				else
				{
					if (class823_0.imethod_3() && class823_0.imethod_5())
					{
						class823_0.MinValue = 0.0;
					}
					double_1 = 0.0;
				}
			}
			else if (num != num2 && double_3 < 0.0 && double_2 < 0.0)
			{
				double num5 = double_2 - double_3;
				smethod_52(num5, out var step4, out var maxScale4);
				if (double_2 / num5 >= 5.0)
				{
					double_0 = double_3 - maxScale4 / 2.0;
					double_1 = double_3 + maxScale4;
					double_4 = Math.Abs(step4);
					if ((double_3 - double_2) / double_4 >= 8.0)
					{
						smethod_54(ref double_4);
					}
					int int_5 = Struct63.smethod_7(double_4);
					double num6 = 0.0;
					while (num6 - 3.0 * double_4 > double_3)
					{
						num6 = Struct63.smethod_10(num6, int_5);
						num6 -= double_4;
					}
					if (class823_0.imethod_5() && class823_0.imethod_3())
					{
						if (class823_0.method_4() == Enum61.const_0 || class823_0.method_4() == Enum61.const_2)
						{
							while (!(Struct63.smethod_9(num6, double_5) <= double_4) && num6 != 0.0)
							{
								num6 -= double_4;
							}
						}
						class823_0.MaxValue = num6;
						double_0 = num6;
					}
				}
				else
				{
					if (class823_0.imethod_5() && class823_0.imethod_3())
					{
						class823_0.MaxValue = 0.0;
					}
					double_0 = 0.0;
				}
			}
			else if (num != num2 && double_3 > 0.0 && double_2 < 0.0)
			{
				double val = double_3 - double_2;
				smethod_52(val, out var step5, out var _);
				double_4 = Math.Abs(step5);
				if ((double_3 - double_2) / double_4 > 8.5)
				{
					smethod_54(ref double_4);
				}
			}
			if (class823_0.imethod_5() && class823_0.imethod_3())
			{
				int_3 = 3;
				if (double_2 == 0.0 || (double_3 == double_2 && double_3 > 0.0))
				{
					class823_0.MinValue = 0.0;
					int_3 = 2;
					double_1 = 0.0;
				}
				if (double_3 == 0.0 || (double_3 == double_2 && double_3 < 0.0))
				{
					class823_0.MaxValue = 0.0;
					int_3 = 1;
					double_0 = 0.0;
				}
			}
			else if (!class823_0.imethod_5() && class823_0.imethod_3())
			{
				int_3 = 1;
				double_0 = class823_0.MaxValue;
				double_3 = class823_0.MaxValue;
			}
			else if (class823_0.imethod_5() && !class823_0.imethod_3())
			{
				int_3 = 2;
				double_1 = class823_0.MinValue;
				double_2 = class823_0.MinValue;
			}
			else
			{
				int_3 = 2;
				double_1 = class823_0.MinValue;
				double_0 = class823_0.MaxValue;
				double_2 = class823_0.MinValue;
				double_3 = class823_0.MaxValue;
				double val2 = Struct63.smethod_9(double_3, double_2);
				smethod_52(val2, out var step6, out var _);
				double_4 = step6;
			}
			if ((!bool_0 || smethod_58(class823_0.Chart.Type)) && flag)
			{
				smethod_60(class823_0, double_1, double_0, ref double_4, int_3, double_5, double_6, bool_1, bool_2);
			}
			return;
		}
		double_4 = class823_0.MajorUnit;
		double_1 = double_2;
		double_0 = double_3;
		if (num != num2 && double_3 > 0.0 && double_2 > 0.0)
		{
			double num7 = double_3 - double_2;
			smethod_52(num7, out var step7, out var maxScale7);
			if (double_2 / num7 >= 5.0)
			{
				double_1 = double_2 - maxScale7 / 2.0;
				double_0 = double_2 + maxScale7;
				double num8 = Math.Abs(step7);
				int int_6 = Struct63.smethod_7(num8);
				double num9;
				for (num9 = 0.0; num9 < double_1; num9 += num8)
				{
					num9 = Struct63.smethod_10(num9, int_6);
				}
				if (class823_0.imethod_3() && class823_0.imethod_5())
				{
					int_6 = Struct63.smethod_7(double_4);
					double num10;
					for (num10 = 0.0; num10 <= num9; num10 += double_4)
					{
						num10 = Struct63.smethod_10(num10, int_6);
					}
					class823_0.MinValue = num10 - double_4;
					double_2 = class823_0.MinValue;
					double_1 = class823_0.MinValue;
				}
			}
			else
			{
				if (class823_0.imethod_3() && class823_0.imethod_5())
				{
					class823_0.MinValue = 0.0;
					double_2 = class823_0.MinValue;
				}
				double_1 = 0.0;
			}
		}
		else if (num != num2 && double_3 < 0.0 && double_2 < 0.0)
		{
			double num11 = double_2 - double_3;
			smethod_52(num11, out var step8, out var maxScale8);
			if (double_2 / num11 >= 5.0)
			{
				double_0 = double_3 - maxScale8 / 2.0;
				double_1 = double_3 + maxScale8;
				double num12 = Math.Abs(step8);
				int int_7 = Struct63.smethod_7(num12);
				double num13;
				for (num13 = 0.0; num13 > double_0; num13 -= num12)
				{
					num13 = Struct63.smethod_10(num13, int_7);
				}
				if (class823_0.imethod_5() && class823_0.imethod_3())
				{
					int_7 = Struct63.smethod_7(double_4);
					double num14;
					for (num14 = 0.0; num14 >= num13; num14 -= double_4)
					{
						num14 = Struct63.smethod_10(num14, int_7);
					}
					class823_0.MaxValue = num14 + double_4;
					double_3 = class823_0.MaxValue;
					double_0 = class823_0.MaxValue;
				}
			}
			else
			{
				if (class823_0.imethod_5() && class823_0.imethod_3())
				{
					class823_0.MaxValue = 0.0;
					double_3 = class823_0.MaxValue;
				}
				double_0 = 0.0;
			}
		}
		if (class823_0.imethod_5() && class823_0.imethod_3())
		{
			int_3 = 3;
			if (double_2 == 0.0)
			{
				class823_0.MinValue = 0.0;
				int_3 = 2;
				double_1 = 0.0;
			}
			if (double_3 == 0.0)
			{
				class823_0.MaxValue = 0.0;
				int_3 = 1;
				double_0 = 0.0;
			}
		}
		else if (!class823_0.imethod_5() && class823_0.imethod_3())
		{
			int_3 = 1;
			double_0 = class823_0.MaxValue;
			double_3 = class823_0.MaxValue;
		}
		else if (class823_0.imethod_5() && !class823_0.imethod_3())
		{
			int_3 = 2;
			double_1 = class823_0.MinValue;
			double_2 = class823_0.MinValue;
		}
		else
		{
			int_3 = 2;
			double_1 = class823_0.MinValue;
			double_0 = class823_0.MaxValue;
			double_2 = class823_0.MinValue;
			double_3 = class823_0.MaxValue;
		}
	}

	private static bool smethod_49(Class821 class821_0)
	{
		if (!class821_0.method_17() && class821_0.Type != ChartType_Chart.Radar && class821_0.Type != ChartType_Chart.RadarFilled && class821_0.Type != ChartType_Chart.RadarWithDataMarkers)
		{
			return false;
		}
		return true;
	}

	private static void smethod_50(Class823 class823_0, int int_3, double double_0, double double_1, double double_2, ArrayList arrayList_0, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		Class821 chart = class823_0.Chart;
		smethod_49(class823_0.Chart);
		Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		arrayList_0.Clear();
		switch (int_3)
		{
		case 1:
		{
			double num6 = double_2;
			int int_6 = Struct63.smethod_7(double_0);
			while (num6 >= double_1 || Struct63.smethod_9(double_1, num6) < double_0 || (double_1 == double_0 && num6 > 0.0) || double_1 == num6)
			{
				num6 = Struct63.smethod_10(num6, int_6);
				if (!class823_0.imethod_3() && num6 < class823_0.MinValue)
				{
					arrayList_0.Add(class823_0.MinValue);
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
			if (Struct63.smethod_9(double_4, num7) > double_0 && num7 != 0.0)
			{
				num7 += double_0;
				if ((double_4 - double_2) / (num7 - double_2) <= 20.0 / 21.0)
				{
					arrayList_0.RemoveAt(arrayList_0.Count - 1);
				}
			}
			else if ((double_4 - double_2) / (num7 - double_2) > 20.0 / 21.0 && num7 != 0.0)
			{
				num6 = Struct63.smethod_10(num7 - double_0, int_6);
				arrayList_0.Add(num6);
			}
			break;
		}
		case 2:
		{
			double num4 = double_1;
			int int_5 = Struct63.smethod_7(double_0);
			while (num4 <= double_2 || num4 < double_2 + double_0 || (num4 == double_0 && double_2 > 0.0) || num4 == double_2)
			{
				num4 = Struct63.smethod_10(num4, int_5);
				if (!class823_0.imethod_5() && num4 > class823_0.MaxValue)
				{
					arrayList_0.Add(class823_0.MaxValue);
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
				if (Struct63.smethod_9(num5, double_3) > double_0 && num5 != 0.0)
				{
					num5 -= double_0;
					if ((double_3 - double_1) / (num5 - double_1) <= 20.0 / 21.0)
					{
						arrayList_0.RemoveAt(arrayList_0.Count - 1);
					}
				}
				else if ((double_3 - double_1) / (num5 - double_1) > 20.0 / 21.0 && num5 != 0.0)
				{
					num4 = Struct63.smethod_10(num5 + double_0, int_5);
					arrayList_0.Add(num4);
				}
			}
			arrayList_0.Reverse();
			break;
		}
		default:
		{
			double num = 0.0;
			int int_4 = Struct63.smethod_7(double_0);
			while (num <= double_2 || Struct63.smethod_9(num, double_2) < double_0 || (num == double_0 && double_2 > 0.0) || num == double_2)
			{
				num = Struct63.smethod_10(num, int_4);
				if (!class823_0.imethod_5() && num > class823_0.MaxValue)
				{
					arrayList_0.Add(class823_0.MaxValue);
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
					num = Struct63.smethod_10(num2 + double_0, int_4);
					arrayList_0.Add(num);
				}
			}
			arrayList_0.Reverse();
			num = 0.0 - double_0;
			while (num >= double_1 || Struct63.smethod_9(double_1, num) < double_0 || (double_1 == double_0 && num > 0.0) || double_1 == num)
			{
				num = Struct63.smethod_10(num, int_4);
				if (!class823_0.imethod_3() && num < class823_0.MinValue)
				{
					arrayList_0.Add(class823_0.MinValue);
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
				num = Struct63.smethod_10(num3 - double_0, int_4);
				arrayList_0.Add(num);
			}
			break;
		}
		}
		if (arrayList_0.Count >= 2)
		{
			if ((bool_2 || smethod_49(chart)) && (double)arrayList_0[0] >= double_3 + double_0 && (double)arrayList_0[0] != 0.0 && bool_0 && arrayList_0.Count >= 3)
			{
				arrayList_0.RemoveAt(0);
			}
			if ((bool_2 || smethod_49(chart)) && (double)arrayList_0[arrayList_0.Count - 1] <= Struct63.smethod_9(double_4, double_0) && (double)arrayList_0[arrayList_0.Count - 1] != 0.0 && bool_1 && arrayList_0.Count >= 3)
			{
				arrayList_0.RemoveAt(arrayList_0.Count - 1);
			}
		}
	}

	internal static int smethod_51(Interface42 interface42_0, Class823 class823_0, bool bool_0, Class844 class844_0, Rectangle rectangle_0)
	{
		if (class823_0.TickLabelPosition == Enum83.const_3)
		{
			return 0;
		}
		ChartType_Chart chartType_Chart = class844_0.method_22();
		Class821 chart = class823_0.Chart;
		Class847 @class = class823_0.method_10();
		Class831 class2 = class844_0.method_9().method_1(0);
		string string_ = class2.vmethod_6();
		bool bool_ = class2.vmethod_7();
		bool flag = false;
		if (@class.LinkedSource && class2 != null)
		{
			flag = true;
		}
		string text = "";
		for (int i = 0; i < class823_0.arrayList_1.Count; i++)
		{
			double num = (double)class823_0.arrayList_1[i];
			if (chartType_Chart == ChartType_Chart.Bar100PercentStacked || chartType_Chart == ChartType_Chart.Column100PercentStacked)
			{
				num /= 100.0;
				string_ = "0%";
			}
			string text2 = "";
			num *= Math.Pow(10.0, (double)class823_0.method_12().vmethod_0());
			text2 = ((!flag) ? Struct44.smethod_28(class823_0, num) : Struct51.smethod_5(chart.vmethod_2(), num, string_, bool_));
			if (text2.Length > text.Length)
			{
				text = text2;
			}
		}
		Size size_ = new Size(rectangle_0.Width, rectangle_0.Height);
		Size size = default(Size);
		size = ((@class.Rotation != 0) ? Struct61.smethod_2(class823_0.Chart.imethod_0(), text, @class.Rotation, @class.Font, size_, Enum82.const_1, Enum82.const_1) : Struct61.smethod_2(class823_0.Chart.imethod_0(), text, @class.Rotation, @class.Font, size_, Enum82.const_1, Enum82.const_1));
		float num2 = 0f;
		int num3 = class823_0.arrayList_1.Count - 1;
		num2 = ((!bool_0) ? ((float)(size.Height * num3)) : ((float)(size.Width * num3)));
		return (int)((double)num2 + 0.5);
	}

	private static void smethod_52(double val, out double step, out double maxScale)
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
			smethod_53(val, out step, out maxScale);
		}
		else
		{
			if (val == 0.0)
			{
				return;
			}
			int num = Struct63.smethod_7(val);
			double val2 = val * Math.Pow(10.0, num);
			smethod_53(val2, out step, out maxScale);
			step /= Math.Pow(10.0, num);
			maxScale /= Math.Pow(10.0, num);
		}
		if (!flag)
		{
			step = 0.0 - step;
			maxScale = 0.0 - maxScale;
		}
	}

	private static void smethod_53(double val, out double step, out double maxScale)
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

	private static void smethod_54(ref double double_0)
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

	private static void smethod_55(ref double double_0)
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

	internal static bool smethod_56(ChartType_Chart chartType_Chart_0)
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

	internal static bool smethod_57(ChartType_Chart chartType_Chart_0)
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

	private static bool smethod_58(ChartType_Chart chartType_Chart_0)
	{
		if (chartType_Chart_0 != ChartType_Chart.Bubble3D && chartType_Chart_0 != ChartType_Chart.Bubble)
		{
			return false;
		}
		return true;
	}

	private static bool smethod_59(ChartType_Chart chartType_Chart_0)
	{
		if (chartType_Chart_0 != ChartType_Chart.AreaStacked && chartType_Chart_0 != ChartType_Chart.Area3DStacked)
		{
			return false;
		}
		return true;
	}

	internal static void smethod_60(Class823 class823_0, double double_0, double double_1, ref double double_2, int int_3, double double_3, double double_4, bool bool_0, bool bool_1)
	{
		double num = double_0;
		double num2 = double_1;
		int int_4 = Struct63.smethod_7(double_2);
		switch (int_3)
		{
		case 1:
		{
			double num5 = double_1;
			if (!class823_0.imethod_3())
			{
				num = class823_0.MinValue;
				break;
			}
			while (num5 >= double_0 || double_0 - num5 < double_2)
			{
				num5 = Struct63.smethod_10(num5, int_4);
				num = num5;
				double double_8 = double_2;
				num5 = Struct63.smethod_9(num5, double_8);
			}
			if ((!(Struct63.smethod_9(double_4, num) > double_2) || num == 0.0) && (double_4 - double_1) / (num - double_1) > 20.0 / 21.0 && num != 0.0)
			{
				num = Struct63.smethod_10(num - double_2, int_4);
			}
			break;
		}
		case 2:
		{
			double num4 = double_0;
			if (!class823_0.imethod_5())
			{
				num2 = class823_0.MaxValue;
				break;
			}
			while (num4 <= double_1 || num4 < double_1 + double_2)
			{
				num4 = Struct63.smethod_10(num4, int_4);
				num2 = num4;
				double double_7 = double_2;
				num4 = Struct63.smethod_11(num4, double_7);
			}
			if ((!(Struct63.smethod_9(num2, double_3) > double_2) || num2 == 0.0) && (double_3 - double_0) / (num2 - double_0) > 20.0 / 21.0 && num2 != 0.0)
			{
				num2 = Struct63.smethod_10(num2 + double_2, int_4);
			}
			break;
		}
		default:
		{
			double num3 = 0.0;
			if (!class823_0.imethod_3())
			{
				num = class823_0.MinValue;
			}
			else
			{
				while (num3 >= double_0 || double_0 - num3 < double_2)
				{
					num3 = Struct63.smethod_10(num3, int_4);
					num = num3;
					double double_5 = double_2;
					num3 = Struct63.smethod_9(num3, double_5);
				}
				if ((!(Struct63.smethod_9(double_4, num) > double_2) || num == 0.0) && (double_4 - double_1) / (num - double_1) > 20.0 / 21.0 && num != 0.0)
				{
					num = Struct63.smethod_10(num - double_2, int_4);
				}
			}
			num3 = 0.0;
			if (!class823_0.imethod_5())
			{
				num2 = class823_0.MinValue;
				break;
			}
			while (num3 <= double_1 || num3 < double_1 + double_2)
			{
				num3 = Struct63.smethod_10(num3, int_4);
				num2 = num3;
				double double_6 = double_2;
				num3 = Struct63.smethod_11(num3, double_6);
			}
			if ((!(Struct63.smethod_9(num2, double_3) > double_2) || num2 == 0.0) && (double_3 - double_0) / (num2 - double_0) > 20.0 / 21.0 && num2 != 0.0)
			{
				num2 = Struct63.smethod_10(num2 + double_2, int_4);
			}
			break;
		}
		}
		double num6 = double_2;
		double num7 = (num2 - num) / double_2;
		int num8 = (smethod_58(class823_0.Chart.Type) ? 10 : 11);
		if (num7 >= (double)num8)
		{
			smethod_54(ref double_2);
			return;
		}
		smethod_55(ref double_2);
		if (num2 - num > 10.0 * double_2)
		{
			double_2 = num6;
		}
	}

	internal static void smethod_61(Class823 class823_0, double double_0, double double_1, ChartType_Chart chartType_Chart_0, float float_0, bool bool_0, Class844 class844_0, bool bool_1, bool bool_2, bool bool_3)
	{
		Class821 chart = class823_0.Chart;
		ArrayList arrayList_ = class823_0.arrayList_1;
		if (class823_0.TickLabelPosition == Enum83.const_3 || arrayList_.Count <= 2)
		{
			return;
		}
		double double_2 = double_0;
		if (double_0 == double_1 && double_0 == 0.0)
		{
			class823_0.MaxValue = 1.0;
			double_0 = 1.0;
			double_2 = 1.0;
			class823_0.MinValue = 0.0;
			bool_1 = false;
			bool_2 = false;
		}
		if (!bool_0 || !bool_3)
		{
			return;
		}
		bool flag = false;
		if (chartType_Chart_0 == ChartType_Chart.Bar100PercentStacked || chartType_Chart_0 == ChartType_Chart.Column100PercentStacked || chart.Type == ChartType_Chart.Column3D100PercentStacked || chart.Type == ChartType_Chart.Bar3D100PercentStacked)
		{
			flag = true;
		}
		if (flag)
		{
			if (double_0 == 100.0 && bool_1)
			{
				class823_0.MaxValue = 100.0;
			}
			if (double_1 == -100.0 && bool_2)
			{
				class823_0.MinValue = -100.0;
			}
		}
		int num = 1;
		double num2 = (double)class823_0.arrayList_1[class823_0.arrayList_1.Count - 1];
		double num3 = (double)class823_0.arrayList_1[0];
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
		double double_3 = class823_0.MajorUnit;
		smethod_62(ref double_3, class823_0, class844_0, float_0, num, num2, num3, double_2, double_1, bool_1, bool_2, flag);
		if (arrayList_.Count >= 2)
		{
			class823_0.MaxValue = (double)arrayList_[0];
			class823_0.MinValue = (double)arrayList_[arrayList_.Count - 1];
			class823_0.MajorUnit = double_3;
			if (class823_0.imethod_9())
			{
				class823_0.MinorUnit = class823_0.MajorUnit / 5.0;
			}
		}
	}

	private static void smethod_62(ref double double_0, Class823 class823_0, Class844 class844_0, float float_0, int int_3, double double_1, double double_2, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		Class821 chart = class823_0.Chart;
		ArrayList arrayList_ = class823_0.arrayList_1;
		if (class823_0.TickLabelPosition == Enum83.const_3 || arrayList_.Count <= 2)
		{
			return;
		}
		float num = 0f;
		num = class823_0.method_10().method_3();
		float num2 = float_0 / (float)(class823_0.arrayList_1.Count - 1);
		if (num2 / num > 9f && (smethod_49(chart) || !bool_0 || !bool_1))
		{
			smethod_55(ref double_0);
			if ((double)arrayList_[0] - (double)arrayList_[arrayList_.Count - 1] > 11.0 * double_0)
			{
				smethod_54(ref double_0);
				return;
			}
			double double_5 = double_0;
			smethod_63(class823_0, int_3, double_5, double_1, double_2, arrayList_, double_3, double_4, bool_0, bool_1, bool_2);
		}
		else if (num2 / num < 3f)
		{
			smethod_54(ref double_0);
			double double_6 = double_0;
			smethod_63(class823_0, int_3, double_6, double_1, double_2, arrayList_, double_3, double_4, bool_0, bool_1, bool_2);
			smethod_62(ref double_0, class823_0, class844_0, float_0, int_3, double_1, double_2, double_3, double_4, bool_0, bool_1, bool_2);
		}
	}

	private static void smethod_63(Class823 class823_0, int int_3, double double_0, double double_1, double double_2, ArrayList arrayList_0, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		Class821 chart = class823_0.Chart;
		smethod_49(class823_0.Chart);
		Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
		arrayList_0.Clear();
		switch (int_3)
		{
		case 1:
		{
			double num6 = double_2;
			int int_6 = Struct63.smethod_7(double_0);
			while (num6 >= double_1 || double_1 - num6 < double_0)
			{
				num6 = Struct63.smethod_10(num6, int_6);
				if (!bool_1 && num6 < class823_0.MinValue)
				{
					arrayList_0.Add(class823_0.MinValue);
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
				num6 = Struct63.smethod_10(num7 - double_0, int_6);
				arrayList_0.Add(num6);
			}
			break;
		}
		case 2:
		{
			double num4 = double_1;
			int int_5 = Struct63.smethod_7(double_0);
			while (num4 <= double_2 || num4 < double_2 + double_0)
			{
				num4 = Struct63.smethod_10(num4, int_5);
				if (!bool_0 && num4 > class823_0.MaxValue)
				{
					arrayList_0.Add(class823_0.MaxValue);
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
					num4 = Struct63.smethod_10(num5 + double_0, int_5);
					arrayList_0.Add(num4);
				}
			}
			arrayList_0.Reverse();
			break;
		}
		default:
		{
			double num = 0.0;
			int int_4 = Struct63.smethod_7(double_0);
			while (num <= double_2 || num - double_2 < double_0)
			{
				num = Struct63.smethod_10(num, int_4);
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
					num = Struct63.smethod_10(num2 + double_0, int_4);
					arrayList_0.Add(num);
				}
			}
			arrayList_0.Reverse();
			num = 0.0 - double_0;
			while (num >= double_1 || double_1 - num < double_0)
			{
				num = Struct63.smethod_10(num, int_4);
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
				num = Struct63.smethod_10(num3 - double_0, int_4);
				arrayList_0.Add(num);
			}
			break;
		}
		}
		if (arrayList_0.Count >= 2)
		{
			if ((bool_2 || smethod_49(chart)) && (double)arrayList_0[0] >= double_3 + double_0 && (double)arrayList_0[0] != 0.0 && bool_0 && arrayList_0.Count > 3)
			{
				arrayList_0.RemoveAt(0);
			}
			if ((bool_2 || smethod_49(chart)) && (double)arrayList_0[arrayList_0.Count - 1] <= double_4 - double_0 && (double)arrayList_0[arrayList_0.Count - 1] != 0.0 && bool_1 && arrayList_0.Count > 3)
			{
				arrayList_0.RemoveAt(arrayList_0.Count - 1);
			}
		}
	}

	internal static void smethod_64(Interface42 interface42_0, Class823 class823_0, ArrayList arrayList_0, Rectangle rectangle_0, ChartType_Chart chartType_Chart_0, Class842 class842_0, bool bool_0)
	{
		arrayList_0.Clear();
		Class821 chart = class823_0.Chart;
		int num = smethod_32(class842_0.method_15());
		if (smethod_57(chartType_Chart_0) && !class823_0.bool_12)
		{
			smethod_37(class842_0.method_15(), out var minValue, out var maxValue, class823_0);
			if (chartType_Chart_0 == ChartType_Chart.Bubble && minValue == 0.0 && maxValue == 0.0)
			{
				class823_0.MajorUnit = 1.0;
			}
			for (int i = 0; i < class842_0.Count; i++)
			{
				Class844 @class = class842_0.method_9(i);
				double minValue2 = 0.0;
				double maxValue2 = 0.0;
				Class842 class2 = new Class842(chart);
				class2.Add(@class);
				smethod_37(class2.method_15(), out minValue2, out maxValue2, class823_0);
				if (minValue2 == 0.0 && maxValue2 == 0.0)
				{
					Class830 class3 = @class.method_9();
					for (int j = 0; j < class3.Count; j++)
					{
						class3[j].XValue = j + 1;
					}
				}
			}
			class823_0.imethod_5();
			class823_0.imethod_3();
			bool bool_ = smethod_37(class842_0.method_15(), out minValue, out maxValue, class823_0);
			smethod_47(interface42_0, class823_0, maxValue, minValue, bool_, arrayList_0, chartType_Chart_0, rectangle_0, bool_1: true, class842_0.method_9(0));
			return;
		}
		Class842 class4 = new Class842(chart);
		Class842 class5 = new Class842(chart);
		new ArrayList();
		double maxValue3 = 0.0;
		if (class823_0.bool_12)
		{
			foreach (Class844 item in class842_0)
			{
				if (item.method_22() == ChartType_Chart.Scatter)
				{
					class4.Add(item);
				}
				else
				{
					class5.Add(item);
				}
			}
			class823_0.imethod_5();
			class823_0.imethod_3();
			double minValue3;
			bool bool_2 = smethod_37(class4.method_15(), out minValue3, out maxValue3, class823_0);
			maxValue3 = Math.Ceiling(maxValue3);
			if (class823_0.vmethod_1() == "valAx")
			{
				smethod_47(interface42_0, class823_0, maxValue3, minValue3, bool_2, arrayList_0, ChartType_Chart.Scatter, rectangle_0, bool_1: true, class4.method_9(0));
				return;
			}
		}
		else
		{
			class5 = class842_0;
		}
		smethod_66(class823_0);
		if (class823_0.CategoryType == Enum64.const_2)
		{
			smethod_71(interface42_0, class823_0, rectangle_0, chartType_Chart_0, class5, bool_0);
			return;
		}
		ArrayList arrayList = ((class823_0.method_4() != 0) ? chart.method_7().method_2() : chart.method_7().method_0());
		if (arrayList.Count > 0)
		{
			bool flag = smethod_65(arrayList);
			for (int k = 0; k < arrayList.Count && k < num; k++)
			{
				Class825 class7 = (Class825)arrayList[k];
				if (class7.imethod_5() && flag)
				{
					DateTime dateTimeFromDouble = Struct63.GetDateTimeFromDouble(Convert.ToDouble(class7.imethod_0()), chart.vmethod_0());
					string value = Struct65.smethod_0(chart.vmethod_2(), dateTimeFromDouble, class7.imethod_3());
					arrayList_0.Add(value);
				}
				else
				{
					arrayList_0.Add(class7.imethod_0());
				}
			}
			for (int l = 0; l < class5.Count; l++)
			{
				Class844 class8 = class5.method_9(l);
				for (int m = 0; m < class8.method_9().Count; m++)
				{
					class8.method_9().method_1(m).XValue = m + 1;
				}
			}
		}
		else if (chartType_Chart_0 == ChartType_Chart.Pie)
		{
			for (int n = 1; n <= class5[0].Points.Count; n++)
			{
				arrayList_0.Add(Convert.ToDouble(n));
				Class825 value2 = new Class825(null, n);
				arrayList.Add(value2);
			}
		}
		else
		{
			for (int num2 = 1; num2 <= num; num2++)
			{
				arrayList_0.Add(Convert.ToDouble(num2));
				Class825 value3 = new Class825(null, num2);
				arrayList.Add(value3);
			}
			if (class823_0.bool_12)
			{
				for (int num3 = num + 1; (double)num3 <= maxValue3; num3++)
				{
					arrayList_0.Add(Convert.ToDouble(num3));
					Class825 value4 = new Class825(null, num3);
					arrayList.Add(value4);
				}
			}
			for (int num4 = 0; num4 < class5.Count; num4++)
			{
				Class844 class9 = class5.method_9(num4);
				for (int num5 = 0; num5 < class9.method_9().Count; num5++)
				{
					class9.method_9().method_1(num5).XValue = num5 + 1;
				}
			}
		}
		if (class823_0.bool_12)
		{
			class823_0.MinValue = 1.0;
			class823_0.MaxValue = (((double)num > maxValue3) ? ((double)num) : maxValue3);
		}
		else
		{
			class823_0.MinValue = 1.0;
			class823_0.MaxValue = num;
		}
		class823_0.MajorUnit = 1.0;
		class823_0.MinorUnit = class823_0.MajorUnit / 2.0;
	}

	private static bool smethod_65(ArrayList arrayList_0)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				Class825 @class = (Class825)arrayList_0[num];
				if (@class.imethod_0() != null)
				{
					TypeCode typeCode = Type.GetTypeCode(@class.imethod_0().GetType());
					if (typeCode == TypeCode.String)
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
		return true;
	}

	private static void smethod_66(Class823 class823_0)
	{
		Class821 chart = class823_0.Chart;
		ArrayList arrayList;
		ArrayList[] array;
		if (class823_0.method_4() == Enum61.const_0)
		{
			arrayList = chart.method_7().method_0();
			array = chart.method_7().method_4();
		}
		else
		{
			arrayList = chart.method_7().method_2();
			array = chart.method_7().method_7();
		}
		if (array != null || arrayList.Count == 0)
		{
			return;
		}
		bool flag = smethod_69(arrayList, class823_0.CategoryType);
		if (class823_0.CategoryType == Enum64.const_0)
		{
			if (flag)
			{
				class823_0.CategoryType = Enum64.const_2;
			}
		}
		else if (!flag && arrayList.Count > 0)
		{
			class823_0.CategoryType = Enum64.const_1;
		}
	}

	private static bool smethod_67(string string_0)
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

	private static bool smethod_68(Class823 class823_0)
	{
		if (class823_0.CategoryType == Enum64.const_1)
		{
			return false;
		}
		Class821 chart = class823_0.Chart;
		ArrayList arrayList;
		ArrayList[] array;
		if (class823_0.method_4() == Enum61.const_0)
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
		bool flag = smethod_69(arrayList, class823_0.CategoryType);
		if (class823_0.CategoryType == Enum64.const_0)
		{
			if (flag)
			{
				return true;
			}
			return false;
		}
		if (!flag && arrayList.Count > 0)
		{
			return false;
		}
		return true;
	}

	private static bool smethod_69(ArrayList arrayList_0, Enum64 enum64_0)
	{
		if (arrayList_0.Count > 0)
		{
			Class825 @class = (Class825)arrayList_0[0];
			if ((@class.imethod_5() && smethod_67(@class.imethod_3())) || enum64_0 == Enum64.const_2)
			{
				bool flag = true;
				bool flag2 = true;
				for (int i = 0; i < arrayList_0.Count; i++)
				{
					Class825 class2 = (Class825)arrayList_0[i];
					if (!class2.imethod_7() && (class2.imethod_0() == null || !class2.imethod_0().ToString().Equals("#N/A")))
					{
						flag2 = false;
						bool flag3 = false;
						if (class2.imethod_0() == null)
						{
							flag3 = true;
						}
						if (class2.imethod_0().Equals(""))
						{
							flag3 = true;
						}
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

	private static bool smethod_70(ChartType_Chart chartType_Chart_0)
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

	private static void smethod_71(Interface42 interface42_0, Class823 class823_0, Rectangle rectangle_0, ChartType_Chart chartType_Chart_0, Class842 class842_0, bool bool_0)
	{
		Class821 chart = class823_0.Chart;
		ArrayList arrayList_ = class823_0.arrayList_1;
		ArrayList arrayList = ((class823_0.method_4() != 0) ? chart.method_7().method_2() : chart.method_7().method_0());
		int num = smethod_32(class842_0.method_15());
		bool flag = false;
		if (arrayList.Count == 0)
		{
			flag = true;
		}
		ArrayList arrayList2 = new ArrayList();
		if (arrayList.Count > 0)
		{
			while (arrayList.Count > num)
			{
				arrayList.RemoveAt(arrayList.Count - 1);
			}
			for (int i = 0; i < arrayList.Count; i++)
			{
				Interface11 @interface = (Interface11)arrayList[i];
				if (@interface.imethod_0() != null && @interface.imethod_0().ToString().Equals("#N/A"))
				{
					arrayList.RemoveAt(i);
					i--;
					continue;
				}
				int num2 = smethod_73(@interface.imethod_0(), class823_0.Chart.vmethod_0());
				if (num2 >= 0)
				{
					arrayList2.Add(num2);
				}
				else if (!@interface.imethod_7())
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
			text = ((class823_0.BaseUnitScale == Enum87.const_0) ? "M/d/yyyy" : ((class823_0.BaseUnitScale != Enum87.const_1) ? "yyyy" : "MMM-yy"));
			for (int j = 1; j <= num; j++)
			{
				Class825 @class = new Class825(null, j);
				@class.imethod_2(bool_3: false);
				@class.imethod_4(text);
				arrayList.Add(@class);
				arrayList2.Add(j);
			}
		}
		for (int k = 0; k < class842_0.Count; k++)
		{
			Class844 class2 = class842_0.method_9(k);
			for (int l = 0; l < arrayList.Count; l++)
			{
				Class831 class3 = class2.method_9().method_1(l);
				if (class3 != null)
				{
					Class825 class4 = (Class825)arrayList[l];
					int num3 = smethod_73(class4.imethod_0(), class823_0.Chart.vmethod_0());
					class3.XValue = num3;
				}
			}
		}
		ArrayList arrayList3 = new ArrayList();
		arrayList3.AddRange(arrayList2);
		arrayList3.Sort();
		if (class823_0.imethod_5())
		{
			class823_0.MaxValue = Struct44.smethod_32(class823_0.BaseUnitScale, (int)arrayList3[arrayList3.Count - 1], chart.vmethod_0());
		}
		if (class823_0.imethod_3())
		{
			class823_0.MinValue = Struct44.smethod_32(class823_0.BaseUnitScale, (int)arrayList3[0], chart.vmethod_0());
		}
		if (class823_0.imethod_0())
		{
			Enum87 baseUnitScale = smethod_72(arrayList3, chart.vmethod_0());
			class823_0.BaseUnitScale = baseUnitScale;
		}
		smethod_74(interface42_0, class823_0, rectangle_0, chartType_Chart_0, bool_0, flag);
		int num4 = (int)class823_0.MinValue;
		int num5 = (int)class823_0.MaxValue;
		int num6 = num4;
		arrayList_.Clear();
		arrayList_.Add(num4);
		num6 = Struct44.smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num6, chart.vmethod_0());
		while (num5 - num6 >= 0)
		{
			arrayList_.Add(num6);
			num6 = Struct44.smethod_31(class823_0.BaseUnitScale, class823_0.MajorUnitScale, (int)class823_0.MajorUnit, num6, chart.vmethod_0());
		}
	}

	private static Enum87 smethod_72(IList ilist_0, bool bool_0)
	{
		Enum87 @enum = Enum87.const_2;
		int num = 28;
		for (int i = 0; i < ilist_0.Count - 1; i++)
		{
			DateTime dateTime = Struct44.smethod_26((int)ilist_0[i], bool_0);
			DateTime dateTime2 = Struct44.smethod_26((int)ilist_0[i + 1], bool_0);
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
	internal static int smethod_73(object object_0, bool bool_0)
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
			return Struct44.smethod_27(dateTime_, bool_0);
		}
		default:
			return Struct63.smethod_22(object_0, num);
		case TypeCode.String:
			return Struct63.smethod_22(object_0, num);
		case TypeCode.Boolean:
		case TypeCode.Int32:
		case TypeCode.Double:
			return Convert.ToInt32(object_0);
		}
	}

	private static void smethod_74(Interface42 interface42_0, Class823 class823_0, Rectangle rectangle_0, ChartType_Chart chartType_Chart_0, bool bool_0, bool bool_1)
	{
		Class821 chart = class823_0.Chart;
		float num = 0f;
		string string_ = Struct44.smethod_28(class823_0, class823_0.MaxValue);
		SizeF sizeF_ = new SizeF(rectangle_0.Width, rectangle_0.Height);
		bool flag = class823_0.method_10().vmethod_1();
		Size size = Struct61.smethod_8(chart.imethod_0(), string_, 0, class823_0.method_10().Font, sizeF_, Enum82.const_1, Enum82.const_1);
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
			num3 = (flag ? ((float)size.Width) : ((class823_0.method_10().Rotation == 0) ? ((float)size.Width) : ((class823_0.method_10().Rotation == 90 || class823_0.method_10().Rotation == -90) ? ((float)size.Height) : ((float)((double)size.Height / Math.Sin((double)Math.Abs(class823_0.method_10().Rotation) * Math.PI / 180.0))))));
		}
		int num4 = (int)class823_0.MaxValue;
		int num5 = (int)class823_0.MinValue;
		Enum87 baseUnitScale = class823_0.BaseUnitScale;
		int num6;
		if (!class823_0.AxisBetweenCategories && !chart.IsDataTableShown)
		{
			num6 = Struct44.smethod_29(baseUnitScale, num4, num5, class823_0.Chart.vmethod_0());
			if (num6 == 0)
			{
				num6 = 1;
			}
		}
		else
		{
			num6 = Struct44.smethod_29(baseUnitScale, num4, num5, class823_0.Chart.vmethod_0()) + 1;
		}
		if (class823_0.imethod_7() && class823_0.imethod_9())
		{
			while (true)
			{
				if (!((float)num6 * (num3 + num) < num2))
				{
					if (!flag || bool_1)
					{
						break;
					}
					if (class823_0.method_10().Rotation == 0)
					{
						class823_0.method_10().Rotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(class823_0.method_10().Rotation) * Math.PI / 180.0));
						continue;
					}
					if (class823_0.method_10().Rotation == 45)
					{
						class823_0.method_10().Rotation = 90;
						num3 = size.Height;
					}
					break;
				}
				class823_0.MajorUnit = 1.0;
				class823_0.MinorUnit = 1.0;
				class823_0.MajorUnitScale = class823_0.BaseUnitScale;
				class823_0.MinorUnitScale = class823_0.BaseUnitScale;
				return;
			}
			if (flag && !bool_1 && class823_0.method_10().Rotation > 0)
			{
				num3 *= 2f;
			}
			int num7 = (int)(num2 / (num3 + num));
			int num8 = ((num6 % num7 == 0) ? (num6 / num7) : (num6 / num7 + 1));
			if (class823_0.BaseUnitScale == Enum87.const_0)
			{
				if (num8 <= 2)
				{
					class823_0.MajorUnit = num8;
					class823_0.MinorUnit = 1.0;
					class823_0.MajorUnitScale = class823_0.BaseUnitScale;
					class823_0.MinorUnitScale = class823_0.BaseUnitScale;
				}
				else if (num8 > 2 && num8 <= 7)
				{
					class823_0.MajorUnit = 7.0;
					class823_0.MinorUnit = 1.0;
					class823_0.MajorUnitScale = class823_0.BaseUnitScale;
					class823_0.MinorUnitScale = class823_0.BaseUnitScale;
				}
				else if (num8 > 7 && num8 <= 14)
				{
					class823_0.MajorUnit = 14.0;
					class823_0.MinorUnit = 7.0;
					class823_0.MajorUnitScale = class823_0.BaseUnitScale;
					class823_0.MinorUnitScale = class823_0.BaseUnitScale;
				}
				else if (num8 > 14 && num8 <= 30)
				{
					class823_0.MajorUnit = 1.0;
					class823_0.MinorUnit = 1.0;
					class823_0.MajorUnitScale = Enum87.const_1;
					class823_0.MinorUnitScale = Enum87.const_1;
				}
				else if (num8 > 30 && num8 <= 360)
				{
					class823_0.MajorUnit = ((num8 % 30 == 0) ? (num8 / 30) : (num8 / 30 + 1));
					class823_0.MinorUnit = (((int)(class823_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class823_0.MajorUnit / 2.0)));
					class823_0.MajorUnitScale = Enum87.const_1;
					class823_0.MinorUnitScale = Enum87.const_1;
				}
				else
				{
					class823_0.MajorUnit = ((num8 % 360 == 0) ? (num8 / 360) : (num8 / 360 + 1));
					class823_0.MinorUnit = (((int)(class823_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class823_0.MajorUnit / 2.0)));
					class823_0.MajorUnitScale = Enum87.const_2;
					class823_0.MinorUnitScale = Enum87.const_2;
				}
			}
			else if (class823_0.BaseUnitScale == Enum87.const_1)
			{
				if (num8 < 12)
				{
					class823_0.MajorUnit = num8;
					class823_0.MinorUnit = (((int)(class823_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class823_0.MajorUnit / 2.0)));
					class823_0.MajorUnitScale = Enum87.const_1;
					class823_0.MinorUnitScale = Enum87.const_1;
				}
				else
				{
					class823_0.MajorUnit = ((num8 % 12 == 0) ? (num8 / 12) : (num8 / 12 + 1));
					class823_0.MinorUnit = (((int)(class823_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class823_0.MajorUnit / 2.0)));
					class823_0.MajorUnitScale = Enum87.const_2;
					class823_0.MinorUnitScale = Enum87.const_2;
				}
			}
			else
			{
				class823_0.MajorUnit = num8;
				class823_0.MinorUnit = (((int)(class823_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class823_0.MajorUnit / 2.0)));
				class823_0.MajorUnitScale = Enum87.const_2;
				class823_0.MinorUnitScale = Enum87.const_2;
			}
		}
		else if (class823_0.imethod_7() && !class823_0.imethod_9())
		{
			int num9 = Struct63.smethod_3((float)((double)Struct44.smethod_30(class823_0.MinorUnitScale, num4, num5, class823_0.Chart.vmethod_0()) / class823_0.MinorUnit));
			if (!class823_0.AxisBetweenCategories && !chart.IsDataTableShown)
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
					if (class823_0.method_10().Rotation == 0)
					{
						class823_0.method_10().Rotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(class823_0.method_10().Rotation) * Math.PI / 180.0));
						continue;
					}
					if (class823_0.method_10().Rotation == 45)
					{
						class823_0.method_10().Rotation = 90;
						num3 = size.Height;
					}
					break;
				}
				class823_0.MajorUnitScale = class823_0.MinorUnitScale;
				class823_0.MajorUnit = class823_0.MinorUnit;
				return;
			}
			if (flag && !bool_1 && class823_0.method_10().Rotation > 0)
			{
				num3 *= 2f;
			}
			int num10 = (int)(num2 / (num3 + num));
			int num11 = ((num6 % num10 == 0) ? (num6 / num10) : (num6 / num10 + 1));
			if (class823_0.BaseUnitScale == Enum87.const_0)
			{
				if (num11 <= 2)
				{
					if (class823_0.MinorUnitScale > class823_0.BaseUnitScale)
					{
						class823_0.MajorUnitScale = class823_0.MinorUnitScale;
						class823_0.MajorUnit = class823_0.MinorUnit;
						return;
					}
					class823_0.MajorUnitScale = class823_0.BaseUnitScale;
					class823_0.MajorUnit = num11;
					if (class823_0.MajorUnit < class823_0.MinorUnit)
					{
						class823_0.MajorUnit = class823_0.MinorUnit;
					}
				}
				else if (num11 > 2 && num11 <= 7)
				{
					if (class823_0.MinorUnitScale > class823_0.BaseUnitScale)
					{
						class823_0.MajorUnitScale = class823_0.MinorUnitScale;
						class823_0.MajorUnit = class823_0.MinorUnit;
						return;
					}
					class823_0.MajorUnitScale = class823_0.BaseUnitScale;
					class823_0.MajorUnit = 7.0;
					if (class823_0.MajorUnit < class823_0.MinorUnit)
					{
						class823_0.MajorUnit = class823_0.MinorUnit;
					}
				}
				else if (num11 > 7 && num11 <= 14)
				{
					if (class823_0.MinorUnitScale > class823_0.BaseUnitScale)
					{
						class823_0.MajorUnitScale = class823_0.MinorUnitScale;
						class823_0.MajorUnit = class823_0.MinorUnit;
						return;
					}
					class823_0.MajorUnitScale = class823_0.BaseUnitScale;
					class823_0.MajorUnit = 14.0;
					if (class823_0.MajorUnit < class823_0.MinorUnit)
					{
						class823_0.MajorUnit = class823_0.MinorUnit;
					}
				}
				else if (num11 > 14 && num11 <= 30)
				{
					if (class823_0.MinorUnitScale == Enum87.const_2)
					{
						class823_0.MajorUnitScale = class823_0.MinorUnitScale;
						class823_0.MajorUnit = class823_0.MinorUnit;
						return;
					}
					class823_0.MajorUnitScale = Enum87.const_1;
					class823_0.MajorUnit = 1.0;
					if (class823_0.MajorUnit < class823_0.MinorUnit && class823_0.MinorUnitScale == Enum87.const_1)
					{
						class823_0.MajorUnit = class823_0.MinorUnit;
					}
				}
				else if (num11 > 30 && num11 <= 360)
				{
					if (class823_0.MinorUnitScale == Enum87.const_2)
					{
						class823_0.MajorUnitScale = class823_0.MinorUnitScale;
						class823_0.MajorUnit = class823_0.MinorUnit;
						return;
					}
					class823_0.MajorUnitScale = Enum87.const_1;
					class823_0.MajorUnit = ((num11 % 30 == 0) ? (num11 / 30) : (num11 / 30 + 1));
					if (class823_0.MajorUnit < class823_0.MinorUnit && class823_0.MinorUnitScale == Enum87.const_1)
					{
						class823_0.MajorUnit = class823_0.MinorUnit;
					}
				}
				else
				{
					class823_0.MajorUnit = ((num11 % 360 == 0) ? (num11 / 360) : (num11 / 360 + 1));
					class823_0.MajorUnitScale = Enum87.const_2;
					if (class823_0.MajorUnit < class823_0.MinorUnit && class823_0.MinorUnitScale == Enum87.const_2)
					{
						class823_0.MajorUnit = class823_0.MinorUnit;
					}
				}
			}
			else if (class823_0.BaseUnitScale == Enum87.const_1)
			{
				if (num11 < 12)
				{
					if (class823_0.MinorUnitScale == Enum87.const_1)
					{
						if (class823_0.MinorUnit <= (double)num11)
						{
							class823_0.MajorUnit = num11;
							class823_0.MajorUnitScale = Enum87.const_1;
						}
						else
						{
							class823_0.MajorUnit = class823_0.MinorUnit;
							class823_0.MajorUnitScale = Enum87.const_1;
						}
					}
					else
					{
						class823_0.MajorUnit = class823_0.MinorUnit;
						class823_0.MajorUnitScale = Enum87.const_2;
					}
					return;
				}
				num11 = ((num11 % 12 == 0) ? (num11 / 12) : (num11 / 12 + 1));
				if (class823_0.MinorUnitScale == Enum87.const_1)
				{
					class823_0.MajorUnit = num11;
					class823_0.MajorUnitScale = Enum87.const_2;
				}
				else if (class823_0.MinorUnit <= (double)num11)
				{
					class823_0.MajorUnit = num11;
					class823_0.MajorUnitScale = Enum87.const_2;
				}
				else
				{
					class823_0.MajorUnit = class823_0.MinorUnit;
					class823_0.MajorUnitScale = Enum87.const_2;
				}
			}
			else
			{
				if (class823_0.MinorUnit <= (double)num11)
				{
					class823_0.MajorUnit = num11;
				}
				else
				{
					class823_0.MajorUnit = class823_0.MinorUnit;
				}
				class823_0.MajorUnitScale = Enum87.const_2;
			}
		}
		else if (!class823_0.imethod_7() && class823_0.imethod_9())
		{
			class823_0.MinorUnit = (((int)(class823_0.MajorUnit / 2.0) == 0) ? 1 : ((int)(class823_0.MajorUnit / 2.0)));
			class823_0.MinorUnitScale = class823_0.MajorUnitScale;
			if (!flag || bool_1)
			{
				return;
			}
			int num12 = Struct63.smethod_3((float)((double)Struct44.smethod_30(class823_0.MajorUnitScale, num4, num5, class823_0.Chart.vmethod_0()) / class823_0.MajorUnit));
			if (!class823_0.AxisBetweenCategories && !chart.IsDataTableShown)
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
					if (class823_0.method_10().Rotation == 0)
					{
						class823_0.method_10().Rotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(class823_0.method_10().Rotation) * Math.PI / 180.0));
					}
					else if (class823_0.method_10().Rotation == 45)
					{
						break;
					}
					continue;
				}
				return;
			}
			class823_0.method_10().Rotation = 90;
		}
		else
		{
			if (!flag || bool_1)
			{
				return;
			}
			int num13 = Struct63.smethod_3((float)((double)Struct44.smethod_30(class823_0.MajorUnitScale, num4, num5, class823_0.Chart.vmethod_0()) / class823_0.MajorUnit));
			if (!class823_0.AxisBetweenCategories && !chart.IsDataTableShown)
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
					if (class823_0.method_10().Rotation == 0)
					{
						class823_0.method_10().Rotation = 45;
						num3 = (float)((double)size.Height / Math.Sin((double)Math.Abs(class823_0.method_10().Rotation) * Math.PI / 180.0));
					}
					else if (class823_0.method_10().Rotation == 45)
					{
						break;
					}
					continue;
				}
				return;
			}
			class823_0.method_10().Rotation = 90;
		}
	}

	internal static ArrayList smethod_75(ArrayList arrayList_0, bool bool_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			int num = smethod_73(((Interface11)arrayList_0[i]).imethod_0(), bool_0);
			arrayList.Add(num);
		}
		return arrayList;
	}

	internal static void smethod_76(Interface42 interface42_0, Class823 class823_0, double double_0, double double_1, ArrayList arrayList_0, ChartType_Chart chartType_Chart_0, Rectangle rectangle_0, bool bool_0, Class844 class844_0)
	{
		double double_2 = double_0;
		double double_3 = double_1;
		_ = class823_0.Chart;
		if (double_0 == double_1 && double_0 == 0.0)
		{
			class823_0.MaxValue = 10.0;
			double_0 = 10.0;
			double_2 = 10.0;
			class823_0.MinValue = 1.0;
		}
		bool bool_ = class823_0.imethod_5();
		bool bool_2 = class823_0.imethod_3();
		double double_4 = 0.0;
		int int_ = 1;
		bool bool_3;
		if (bool_3 = class844_0.method_31())
		{
			if (double_0 == 100.0 && class823_0.imethod_5())
			{
				class823_0.MaxValue = 100.0;
			}
			if (double_1 >= 1.0 && class823_0.imethod_3())
			{
				class823_0.MinValue = 1.0;
			}
		}
		double double_5 = 0.0;
		double double_6 = 0.0;
		smethod_77(ref double_5, ref double_6, ref double_1, ref double_0, ref double_4, ref int_, class823_0, bool_0);
		smethod_78(class823_0, int_, double_4, double_6, double_5, arrayList_0, double_2, double_3, bool_, bool_2, bool_3);
		int num = smethod_79(interface42_0, class823_0, bool_0, class844_0, rectangle_0);
		int num2 = 0;
		num2 = (class823_0.Chart.method_17() ? ((!bool_0) ? ((int)class823_0.Chart.method_13().Height) : ((int)class823_0.Chart.method_13().Width)) : ((!bool_0) ? rectangle_0.Height : rectangle_0.Width));
		while (class823_0.imethod_7() && arrayList_0.Count > 3 && num > num2 && num2 != 0)
		{
			double_4 += 1.0;
			smethod_78(class823_0, int_, double_4, double_6, double_5, arrayList_0, double_2, double_3, bool_, bool_2, bool_3);
			num = smethod_79(interface42_0, class823_0, bool_0, class844_0, rectangle_0);
		}
		if (arrayList_0.Count >= 2)
		{
			class823_0.MaxValue = class823_0.method_7((double)arrayList_0[0]);
			class823_0.MinValue = class823_0.method_7((double)arrayList_0[arrayList_0.Count - 1]);
			if (class823_0.imethod_7())
			{
				class823_0.MajorUnit = class823_0.method_7(double_4);
			}
			if (class823_0.imethod_9())
			{
				class823_0.MinorUnit = class823_0.MajorUnit;
			}
		}
	}

	private static void smethod_77(ref double double_0, ref double double_1, ref double double_2, ref double double_3, ref double double_4, ref int int_3, Class823 class823_0, bool bool_0)
	{
		double_4 = 1.0;
		double num;
		double num2;
		if (class823_0.imethod_7())
		{
			num = smethod_81(double_2);
			num2 = smethod_80(double_3);
			double_1 = num;
			double_0 = num2;
			if (class823_0.imethod_5() && class823_0.imethod_3())
			{
				int_3 = 3;
				if (num >= 0.0 && num2 >= 0.0)
				{
					class823_0.MinValue = class823_0.method_7(0.0);
					int_3 = 2;
					double_1 = 0.0;
				}
				else
				{
					class823_0.MinValue = class823_0.method_7(num);
					int_3 = 2;
					double_1 = num;
				}
			}
			else if (!class823_0.imethod_5() && class823_0.imethod_3())
			{
				int_3 = 1;
				double_0 = class823_0.method_6(class823_0.MaxValue);
				double_3 = double_0;
			}
			else if (class823_0.imethod_5() && !class823_0.imethod_3())
			{
				int_3 = 2;
				double_1 = class823_0.method_6(class823_0.MinValue);
				double_2 = double_1;
			}
			else
			{
				int_3 = 2;
				double_1 = class823_0.method_6(class823_0.MinValue);
				double_0 = class823_0.method_6(class823_0.MaxValue);
				double_2 = class823_0.method_6(class823_0.MinValue);
				double_3 = class823_0.method_6(class823_0.MaxValue);
			}
			return;
		}
		double_4 = class823_0.method_6(class823_0.MajorUnit);
		num = (int)double_2;
		num2 = (double)(int)double_3 + double_4;
		double_1 = num;
		double_0 = num2;
		if (class823_0.imethod_5() && class823_0.imethod_3())
		{
			int_3 = 3;
			if (num >= 0.0 && num2 >= 0.0)
			{
				class823_0.MinValue = class823_0.method_7(0.0);
				int_3 = 2;
				double_1 = 0.0;
			}
			else
			{
				class823_0.MinValue = class823_0.method_7(num);
				int_3 = 2;
				double_1 = num;
			}
		}
		else if (!class823_0.imethod_5() && class823_0.imethod_3())
		{
			int_3 = 1;
			double_0 = class823_0.method_6(class823_0.MaxValue);
			double_3 = double_0;
		}
		else if (class823_0.imethod_5() && !class823_0.imethod_3())
		{
			int_3 = 2;
			double_1 = class823_0.method_6(class823_0.MinValue);
			double_2 = double_1;
		}
		else
		{
			int_3 = 2;
			double_1 = class823_0.method_6(class823_0.MinValue);
			double_0 = class823_0.method_6(class823_0.MaxValue);
			double_2 = class823_0.method_6(class823_0.MinValue);
			double_3 = class823_0.method_6(class823_0.MaxValue);
		}
	}

	private static void smethod_78(Class823 class823_0, int int_3, double double_0, double double_1, double double_2, ArrayList arrayList_0, double double_3, double double_4, bool bool_0, bool bool_1, bool bool_2)
	{
		arrayList_0.Clear();
		switch (int_3)
		{
		case 1:
		{
			double num = double_2;
			while (num >= double_1 || Struct63.smethod_9(double_1, num) < double_0)
			{
				if (!class823_0.imethod_3() && num < class823_0.method_14())
				{
					arrayList_0.Add(class823_0.method_14());
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
				if (!class823_0.imethod_5() && num2 > class823_0.method_13())
				{
					arrayList_0.Add(class823_0.method_13());
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
		for (num3 = 0.0; num3 <= double_2 || Struct63.smethod_9(num3, double_2) < double_0; num3 += double_0)
		{
			if (!class823_0.imethod_5() && num3 > class823_0.method_13())
			{
				arrayList_0.Add(class823_0.method_13());
			}
			else
			{
				arrayList_0.Add(num3);
			}
		}
		arrayList_0.Reverse();
		num3 = 0.0 - double_0;
		while (num3 >= double_1 || Struct63.smethod_9(double_1, num3) < double_0)
		{
			if (!class823_0.imethod_3() && num3 < class823_0.method_14())
			{
				arrayList_0.Add(class823_0.method_14());
			}
			else
			{
				arrayList_0.Add(num3);
			}
			num3 -= double_0;
		}
	}

	private static int smethod_79(Interface42 interface42_0, Class823 class823_0, bool bool_0, Class844 class844_0, Rectangle rectangle_0)
	{
		if (class823_0.TickLabelPosition == Enum83.const_3)
		{
			return 0;
		}
		Class821 chart = class823_0.Chart;
		Class847 @class = class823_0.method_10();
		Class831 class2 = class844_0.method_9().method_1(0);
		string string_ = class2.vmethod_6();
		bool bool_ = class2.vmethod_7();
		bool flag = false;
		if (@class.LinkedSource && class2 != null)
		{
			flag = true;
		}
		int num = 0;
		for (int i = 0; i < class823_0.arrayList_1.Count; i++)
		{
			double num2 = class823_0.method_7((double)class823_0.arrayList_1[i]);
			if (class844_0.method_31())
			{
				num2 /= 100.0;
				string_ = "0%";
			}
			string text = "";
			Size size = Struct61.smethod_7(string_0: (!flag) ? Struct44.smethod_28(class823_0, num2) : Struct51.smethod_5(chart.vmethod_2(), num2, string_, bool_), size_0: new Size(rectangle_0.Width, rectangle_0.Height), interface42_0: class823_0.Chart.imethod_0(), int_0: @class.Rotation, font_0: @class.Font, enum82_0: Enum82.const_1, enum82_1: Enum82.const_1);
			num = ((!bool_0) ? ((i == 0 || i == class823_0.arrayList_1.Count - 1) ? (num + size.Height / 2) : (num + size.Height)) : ((i == 0 || i == class823_0.arrayList_1.Count - 1) ? (num + size.Width / 2) : (num + size.Width)));
			num = ((i == 0 || i == class823_0.arrayList_1.Count - 1) ? (num - 1) : (num - 2));
		}
		return (int)((double)num + 0.5);
	}

	private static double smethod_80(double double_0)
	{
		bool flag = true;
		if (double_0 < 0.0)
		{
			flag = false;
		}
		double_0 = Math.Abs(double_0);
		if (flag)
		{
			double num = Struct63.smethod_4(double_0);
			if (num != double_0)
			{
				num += 1.0;
			}
			return num;
		}
		double num2 = Struct63.smethod_4(double_0);
		return 0.0 - num2;
	}

	private static double smethod_81(double double_0)
	{
		bool flag = true;
		if (double_0 < 0.0)
		{
			flag = false;
		}
		double_0 = Math.Abs(double_0);
		if (!flag)
		{
			double num = Struct63.smethod_4(double_0);
			if (num != double_0)
			{
				num += 1.0;
			}
			return 0.0 - num;
		}
		return Struct63.smethod_4(double_0);
	}

	private static bool smethod_82(Class821 class821_0)
	{
		int num = 0;
		while (true)
		{
			if (num < class821_0.NSeries.Count)
			{
				Interface28 @interface = class821_0.NSeries[num];
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
				if (num2 < class821_0.NSeries.Count)
				{
					Interface28 interface2 = class821_0.NSeries[num2];
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

	private static void smethod_83(Interface9 interface9_0, Interface9 interface9_1)
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

	private static void smethod_84(Class821 class821_0)
	{
		for (int i = 0; i < class821_0.method_7().method_2().Count; i++)
		{
			Interface11 @interface = (Interface11)class821_0.method_7().method_2()[i];
			Interface11 interface2 = new Class825(null, @interface.imethod_0());
			interface2.imethod_2(@interface.imethod_1());
			interface2.imethod_6(@interface.imethod_5());
			interface2.imethod_8(@interface.imethod_7());
			interface2.imethod_4(@interface.imethod_3());
			class821_0.method_7().method_6().Add(interface2);
		}
		class821_0.method_7().method_2().Clear();
		for (int j = 0; j < class821_0.method_7().method_0().Count; j++)
		{
			Interface11 interface3 = (Interface11)class821_0.method_7().method_0()[j];
			Interface11 interface4 = new Class825(null, interface3.imethod_0());
			interface4.imethod_2(interface3.imethod_1());
			interface4.imethod_6(interface3.imethod_5());
			interface4.imethod_8(interface3.imethod_7());
			interface4.imethod_4(interface3.imethod_3());
			class821_0.method_7().method_2().Add(interface4);
		}
	}

	internal static ArrayList[] smethod_85(Interface10 interface10_0)
	{
		ArrayList[] array = null;
		int num = smethod_87(interface10_0);
		if (num > 1)
		{
			array = new ArrayList[num - 1];
			for (int i = 0; i < num - 1; i++)
			{
				array[i] = new ArrayList();
				smethod_88(interface10_0, i, 0, array[i]);
			}
		}
		return array;
	}

	internal static ArrayList smethod_86(Interface10 interface10_0)
	{
		ArrayList arrayList = null;
		arrayList = new ArrayList();
		int num = smethod_87(interface10_0);
		smethod_88(interface10_0, num - 1, 0, arrayList);
		return arrayList;
	}

	private static int smethod_87(Interface10 interface10_0)
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

	private static void smethod_88(Interface10 interface10_0, int int_3, int int_4, ArrayList arrayList_0)
	{
		if (int_3 == int_4)
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
				smethod_88(@interface.imethod_9(), int_3, int_4 + 1, arrayList_0);
			}
		}
	}
}
