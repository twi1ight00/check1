using System;
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
internal struct Struct22
{
	private static int int_0 = Class817.int_0;

	private static int int_1 = Class817.int_1;

	private static int int_2 = 2;

	internal static void Calculate(Class787 class787_0)
	{
		Interface42 interface42_ = class787_0.imethod_0();
		class787_0.imethod_0().imethod_56();
		Class808 @class = class787_0.method_7();
		if (class787_0.method_7().Count == 0 || Class817.smethod_29(class787_0.method_7().method_15()) == 0)
		{
			return;
		}
		if (class787_0.NSeries.imethod_0().Count > 0)
		{
			class787_0.method_7().bool_0 = true;
		}
		if (class787_0.NSeries.imethod_1().Count > 0)
		{
			class787_0.method_7().bool_1 = true;
		}
		class787_0.method_7().method_5(Class817.smethod_81(class787_0.method_7().imethod_0()));
		class787_0.method_7().method_8(Class817.smethod_81(class787_0.method_7().imethod_1()));
		class787_0.method_7().method_1(Class817.smethod_82(class787_0.method_7().imethod_0()));
		class787_0.method_7().method_3(Class817.smethod_82(class787_0.method_7().imethod_1()));
		string text = Class817.smethod_1(class787_0);
		if (text != "")
		{
			throw new ArgumentException(text);
		}
		smethod_1(class787_0);
		Class817.smethod_6(class787_0);
		smethod_11(class787_0);
		Struct40.smethod_6(class787_0.method_1(), class787_0.method_9(), class787_0.method_7(), class787_0.method_7().method_9(0));
		bool flag = Class817.smethod_8(class787_0.Type);
		bool flag2 = Struct27.smethod_8(class787_0);
		if (flag)
		{
			if (class787_0.Elevation < 0)
			{
				class787_0.Elevation = 0;
			}
			if (class787_0.Elevation > 44)
			{
				class787_0.Elevation = 44;
			}
			if (class787_0.Rotation < 0)
			{
				class787_0.Rotation = 0;
			}
			if (class787_0.Rotation > 44)
			{
				class787_0.Rotation = 44;
			}
		}
		if (!flag2)
		{
			class787_0.method_11().method_10().Text = "";
			class787_0.method_11().IsVisible = false;
		}
		int num = Class817.int_1;
		Rectangle rectangle_ = new Rectangle(int_0, int_0, class787_0.Width - int_0 * 2, class787_0.Height - int_0 * 2);
		if (rectangle_.Height < 0)
		{
			rectangle_.Height = 0;
		}
		if (class787_0.method_12().IsVisible)
		{
			Size size = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_.Width * 0.8f, (float)rectangle_.Height * 0.8f), interface42_0: interface42_, class812_0: class787_0.method_12());
			class787_0.method_12().method_0().rectangle_1.X = (class787_0.Width - size.Width) / 2;
			class787_0.method_12().method_0().rectangle_1.Y = int_0;
			class787_0.method_12().method_0().rectangle_1.Size = size;
			rectangle_.Y += size.Height + num;
			rectangle_.Height -= size.Height + num;
		}
		bool flag3 = Struct28.smethod_9(class787_0);
		class787_0.method_6().bool_0 = flag3;
		Class817.smethod_5(class787_0);
		if (class787_0.IsLegendShown)
		{
			if (class787_0.Type != ChartType_Chart.Pie3DExploded && class787_0.Type != ChartType_Chart.Pie3D && !flag3)
			{
				Class817.smethod_27(class787_0);
				Struct28.smethod_22(interface42_, class787_0.method_6(), ref rectangle_);
			}
			else
			{
				Class810 class810_ = (Class810)class787_0.method_7().method_16()[0];
				Struct28.smethod_18(interface42_, class787_0.method_6(), class810_, ref rectangle_);
			}
		}
		Struct33.smethod_0(class787_0, ref rectangle_);
		class787_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		if (!class787_0.method_8().imethod_3())
		{
			class787_0.method_28(class787_0.method_8().vmethod_1());
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
			rectangle_.X += 5;
			rectangle_.Y += 5;
			if (rectangle_.Right + 5 > class787_0.Width)
			{
				rectangle_.Width = class787_0.Width - 5 - rectangle_.X;
			}
			if (rectangle_.Bottom + 5 > class787_0.Height)
			{
				rectangle_.Height = class787_0.Height - 5 - rectangle_.Y;
			}
			if (class787_0.Type == ChartType_Chart.Pie3D || class787_0.Type == ChartType_Chart.Pie3DExploded)
			{
				Struct33.smethod_1(ref rectangle_, class787_0, 0);
				int num2 = Class817.int_2;
				class787_0.method_28(new Rectangle(rectangle_.X - num2, rectangle_.Y - num2, Struct40.smethod_5((float)rectangle_.Width * (1f - 2f * (float)num2 / (float)class787_0.Width)), Struct40.smethod_5((float)rectangle_.Height * (1f - 2f * (float)num2 / (float)class787_0.Height))));
			}
			class787_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		}
		else
		{
			int num3 = Class817.int_2;
			class787_0.method_28(new Rectangle(rectangle_.X - num3, rectangle_.Y - num3, Struct40.smethod_5((float)rectangle_.Width * (1f - 2f * (float)num3 / (float)class787_0.Width)), Struct40.smethod_5((float)rectangle_.Height * (1f - 2f * (float)num3 / (float)class787_0.Height))));
		}
		class787_0.method_24(new RectangleF(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height));
		class787_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		double minValue;
		double maxValue;
		bool bool_ = Class817.smethod_30(@class.method_15(), out minValue, out maxValue, class787_0.method_9());
		bool flag4 = class787_0.method_9().imethod_7();
		bool bool_2 = class787_0.method_9().imethod_9();
		bool flag5 = class787_0.method_9().imethod_5();
		bool flag6 = class787_0.method_9().imethod_3();
		double double_ = maxValue;
		double double_2 = minValue;
		Class817.smethod_44(interface42_, class787_0.method_9(), maxValue, minValue, bool_, class787_0.method_9().arrayList_1, class787_0.Type, rectangle_, flag, @class.method_9(0));
		Class817.smethod_62(interface42_, class787_0.method_1(), class787_0.method_1().arrayList_1, rectangle_, class787_0.Type, @class, flag);
		if (flag2)
		{
			smethod_10(class787_0);
		}
		rectangle_.X += int_2;
		rectangle_.Y += int_2;
		rectangle_.Width -= 2 * int_2;
		rectangle_.Height -= 2 * int_2;
		Struct27.smethod_0(class787_0, rectangle_, flag);
		Struct19.smethod_39(class787_0);
		Rectangle rectangle_2 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_1().method_10().IsVisible && class787_0.method_1().IsVisible)
		{
			smethod_7(interface42_, class787_0.method_1(), rectangle_2, ref rectangle_, flag);
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_9().method_10().IsVisible && class787_0.method_9().IsVisible)
		{
			smethod_7(interface42_, class787_0.method_9(), rectangle_2, ref rectangle_, flag);
		}
		if (!Struct40.smethod_19(rectangle_) && flag2 && class787_0.method_11().method_10().IsVisible && class787_0.method_11().IsVisible)
		{
			smethod_8(interface42_, class787_0.method_11(), ref rectangle_);
		}
		bool flag7 = false;
		_ = class787_0.Rotation % 90;
		int num4 = class787_0.Rotation / 45;
		if (!Struct40.smethod_19(rectangle_) && class787_0.IsDataTableShown)
		{
			Class817.smethod_26(class787_0);
			Size size_ = Struct23.smethod_5(interface42_, class787_0.method_4(), rectangle_);
			class787_0.method_4().method_8(size_);
			int num5 = Struct23.smethod_6(interface42_, class787_0.method_4(), rectangle_);
			class787_0.method_4().method_10(num5);
			int num6 = size_.Height + num5;
			class787_0.method_4().rectangle_0.Height = num6;
			smethod_2(class787_0);
			if (class787_0.Elevation > 0 && !flag)
			{
				switch (num4)
				{
				case 1:
				case 2:
				case 5:
				case 6:
					rectangle_.Height -= num6;
					class787_0.method_4().rectangle_0.X = rectangle_.X + size_.Width;
					class787_0.method_4().rectangle_0.Y = rectangle_.Bottom;
					class787_0.method_4().rectangle_0.Width = rectangle_.Width - size_.Width;
					break;
				case 0:
				case 3:
				case 4:
				case 7:
				case 8:
					rectangle_.Height -= num6 + int_2;
					rectangle_.X += size_.Width;
					rectangle_.Width -= size_.Width;
					class787_0.method_1().TickLabelPosition = Enum83.const_3;
					class787_0.method_1().MajorTickMark = Enum84.const_2;
					class787_0.method_1().MinorTickMark = Enum84.const_2;
					break;
				}
			}
			else
			{
				rectangle_.Height -= num6;
				class787_0.method_4().rectangle_0.X = rectangle_.X + size_.Width;
				class787_0.method_4().rectangle_0.Y = rectangle_.Bottom;
				class787_0.method_4().rectangle_0.Width = rectangle_.Width - size_.Width;
			}
			Struct27.smethod_0(class787_0, rectangle_, flag);
		}
		Rectangle rectangle = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		int num7 = class787_0.method_7().method_10();
		Size size2 = Struct19.smethod_40(interface42_, class787_0.method_11(), rectangle_, @class.Count, bool_0: false, @class.method_9(0));
		int num8 = class787_0.method_11().method_9().method_1();
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_11().TickLabelPosition != Enum83.const_3 && class787_0.method_11().IsVisible && flag2)
		{
			Rectangle rectangle2 = Struct19.smethod_42(interface42_, class787_0.method_11(), num7, flag);
			if (!rectangle2.IsEmpty && rectangle2.Width > 0 && rectangle2.Height > 0)
			{
				int num9 = num;
				if (rectangle2.Right > rectangle.Right - num9)
				{
					rectangle_.Width -= rectangle2.Right - (rectangle.Right - num9);
				}
				if (rectangle2.Bottom > rectangle.Bottom - num9)
				{
					rectangle_.Height -= rectangle2.Bottom - (rectangle.Bottom - num9);
				}
				if (rectangle2.X < rectangle.X + num9)
				{
					int num10 = rectangle.X + num9 - rectangle2.X;
					rectangle_.X += num10;
					rectangle_.Width -= num10;
				}
				if (rectangle2.Y < rectangle.Y + num9)
				{
					int num11 = rectangle.Y + num9 - rectangle2.Y;
					rectangle_.Y += num11;
					rectangle_.Height -= num11;
				}
			}
			Struct27.smethod_0(class787_0, rectangle_, bool_0: false);
		}
		Size size_2 = Struct19.smethod_19(interface42_, class787_0.method_9(), @class.method_9(0), flag);
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_9().TickLabelPosition != Enum83.const_3 && class787_0.method_9().IsVisible)
		{
			if (!flag)
			{
				PointF pointF = smethod_4(class787_0);
				if (pointF.X < class787_0.method_13().method_2())
				{
					int num12 = (int)(pointF.X - (float)rectangle_.X);
					if (!flag7)
					{
						num12 -= class787_0.method_9().method_10().method_0()
							.rectangle_1.Size.Width;
					}
					if (num12 < size_2.Width)
					{
						rectangle_.X += size_2.Width;
						rectangle_.Width -= size_2.Width;
					}
				}
				else
				{
					int num13 = (int)((float)rectangle_.Right - pointF.X);
					if (num13 < size_2.Width)
					{
						rectangle_.Width -= size_2.Width;
					}
				}
				if (class787_0.Elevation >= 0)
				{
					if (class787_0.method_23().Bottom - pointF.Y < (float)(size_2.Height / 2))
					{
						rectangle_.Height -= size_2.Height / 2;
					}
				}
				else if (pointF.Y - class787_0.method_13().Height - class787_0.method_23().Y < (float)(size_2.Height / 2))
				{
					rectangle_.Y += size_2.Height / 2;
					rectangle_.Height -= size_2.Height / 2;
				}
			}
			else
			{
				PointF[] array = smethod_2(class787_0);
				int height = size_2.Height;
				if (rectangle_.Bottom - (int)array[0].Y < height)
				{
					rectangle_.Height = rectangle_.Height - height + (rectangle_.Bottom - (int)array[0].Y);
				}
			}
			Struct27.smethod_0(class787_0, rectangle_, flag);
		}
		if (flag && flag4)
		{
			Class817.smethod_59(class787_0.method_9(), double_, double_2, class787_0.Type, class787_0.method_13().Width, flag, @class.method_9(0), flag5, flag6, flag4);
			Struct19.smethod_19(interface42_, class787_0.method_9(), @class.method_9(0), flag);
		}
		Size size_3 = Struct19.smethod_40(interface42_, class787_0.method_1(), rectangle_, num7, flag, @class.method_9(0));
		int num14 = class787_0.method_1().method_9().method_1();
		if (class787_0.method_7().method_4() != null)
		{
			num14 += num14 * class787_0.method_7().method_4().Length;
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_1().TickLabelPosition != Enum83.const_3 && class787_0.method_1().IsVisible)
		{
			if (!flag)
			{
				Rectangle rectangle3 = Struct19.smethod_42(interface42_, class787_0.method_1(), num7, flag);
				if (!rectangle3.IsEmpty && rectangle3.Width > 0 && rectangle3.Height > 0)
				{
					int num15 = num;
					if (rectangle3.Right > rectangle.Right - num15)
					{
						rectangle_.Width -= rectangle3.Right - (rectangle.Right - num15);
					}
					if (rectangle3.Bottom > rectangle.Bottom - num15)
					{
						rectangle_.Height -= rectangle3.Bottom - (rectangle.Bottom - num15);
					}
					if (rectangle3.X < rectangle.X + num15)
					{
						int num16 = rectangle.X + num15 - rectangle3.X;
						rectangle_.X += num16;
						rectangle_.Width -= num16;
					}
					if (rectangle3.Y < rectangle.Y + num15)
					{
						int num17 = rectangle.Y + num15 - rectangle3.Y;
						rectangle_.Y += num17;
						rectangle_.Height -= num17;
					}
				}
			}
			else
			{
				PointF pointF2 = smethod_4(class787_0);
				int num18 = size_3.Width + num14;
				int num19 = (int)(pointF2.X - (float)rectangle.X);
				if (num19 < num18)
				{
					rectangle_.X += num18;
					rectangle_.Width -= num18;
				}
			}
			Struct27.smethod_0(class787_0, rectangle_, flag);
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.IsDataTableShown)
		{
			int num20 = Struct23.smethod_6(interface42_, class787_0.method_4(), rectangle_);
			if (num20 > class787_0.method_4().method_9())
			{
				class787_0.method_4().method_10(num20);
				int num21 = num20 - class787_0.method_4().method_9();
				class787_0.method_4().rectangle_0.Height += num21;
				smethod_2(class787_0);
				if (class787_0.Elevation > 0 && !flag)
				{
					switch (num4)
					{
					case 1:
					case 2:
					case 5:
					case 6:
						rectangle_.Height -= num21;
						class787_0.method_4().rectangle_0.Y -= num21;
						break;
					case 0:
					case 3:
					case 4:
					case 7:
					case 8:
						rectangle_.Height -= num21 + int_2;
						class787_0.method_1().TickLabelPosition = Enum83.const_3;
						class787_0.method_1().MajorTickMark = Enum84.const_2;
						class787_0.method_1().MinorTickMark = Enum84.const_2;
						break;
					}
				}
				else
				{
					rectangle_.Height -= num21;
					class787_0.method_4().rectangle_0.Y -= num21;
				}
				Struct27.smethod_0(class787_0, rectangle_, flag);
			}
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_9().IsVisible)
		{
			int num22 = Class817.smethod_48(interface42_, class787_0.method_9(), flag, class787_0.method_7().method_9(0), rectangle_);
			int num23 = 0;
			num23 = ((!flag) ? Struct40.smethod_3(class787_0.method_13().Height) : Struct40.smethod_3(class787_0.method_13().Width));
			if (flag4 && class787_0.method_9().arrayList_1.Count > 3 && num22 > num23 && num23 != 0)
			{
				class787_0.method_9().arrayList_1.Clear();
				class787_0.method_9().imethod_8(flag4);
				class787_0.method_9().imethod_10(bool_2);
				class787_0.method_9().imethod_6(flag5);
				class787_0.method_9().imethod_4(flag6);
				Class817.smethod_44(interface42_, class787_0.method_9(), maxValue, minValue, bool_, class787_0.method_9().arrayList_1, class787_0.method_7().method_9(0).method_22(), rectangle_, flag, class787_0.method_7().method_9(0));
			}
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_1().method_10().IsVisible && class787_0.method_1().IsVisible)
		{
			smethod_9(class787_0.method_1(), rectangle_, flag, size_2, size_3, num14);
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_9().method_10().IsVisible && class787_0.method_9().IsVisible)
		{
			smethod_9(class787_0.method_9(), rectangle_, flag, size_2, size_3, num14);
		}
		if (!Struct40.smethod_19(rectangle_) && class787_0.method_11().method_10().IsVisible && class787_0.method_11().IsVisible)
		{
			Size size_4 = size2;
			if (class787_0.method_11().TickLabelPosition != Enum83.const_3)
			{
				size_4.Width += num8;
			}
			PointF[] array2 = smethod_3(class787_0);
			if (array2[0].Y == array2[1].Y)
			{
				if (class787_0.Elevation >= 0)
				{
					class787_0.method_11().method_10().method_0()
						.rectangle_1.X = (int)((array2[0].X + array2[1].X) / 2f - (float)(class787_0.method_11().method_10().method_0()
						.rectangle_1.Width / 2));
				}
			}
			else
			{
				if (!(array2[0].X >= array2[1].X))
				{
					_ = array2[0].X;
				}
				else
				{
					_ = array2[1].X;
				}
				if (!(array2[0].X >= array2[1].X))
				{
					_ = array2[1].X;
				}
				else
				{
					_ = array2[0].X;
				}
				switch (num4)
				{
				case 3:
				case 7:
					class787_0.method_11().method_10().method_0()
						.rectangle_1.X = (int)(Math.Abs(array2[0].X + array2[1].X) / 2f - (float)class787_0.method_11().method_10().method_0()
						.rectangle_1.Width - (float)smethod_6(class787_0, size_4));
					break;
				case 0:
				case 4:
				case 8:
					class787_0.method_11().method_10().method_0()
						.rectangle_1.X = (int)(Math.Abs(array2[0].X + array2[1].X) / 2f + (float)smethod_6(class787_0, size_4));
					break;
				}
				class787_0.method_11().method_10().method_0()
					.rectangle_1.Y = (int)(Math.Abs(array2[0].Y + array2[1].Y) / 2f);
			}
		}
		if (Struct40.smethod_19(rectangle_) || !class787_0.IsDataTableShown || flag)
		{
			return;
		}
		PointF[] array3 = smethod_2(class787_0);
		if (class787_0.Elevation > 0)
		{
			switch (num4)
			{
			case 0:
			case 3:
			case 4:
			case 7:
			case 8:
			{
				int num24 = ((!(array3[0].X < array3[1].X)) ? 1 : 0);
				class787_0.method_4().rectangle_0.X = (int)array3[num24].X;
				class787_0.method_4().rectangle_0.Y = (int)array3[num24].Y;
				class787_0.method_4().rectangle_0.Width = (int)Math.Abs(array3[1].X - array3[0].X);
				break;
			}
			case 1:
			case 2:
			case 5:
			case 6:
				break;
			}
		}
	}

	internal static void smethod_0(Class787 class787_0)
	{
		Calculate(class787_0);
		Interface42 interface42_ = class787_0.imethod_0();
		TextRenderingHint textRenderingHint_ = class787_0.imethod_0().imethod_56();
		Class808 @class = class787_0.method_7();
		if (class787_0.method_7().Count == 0 || Class817.smethod_29(class787_0.method_7().method_15()) == 0)
		{
			return;
		}
		bool flag = Class817.smethod_8(class787_0.Type);
		class787_0.method_8().method_18();
		int num = class787_0.method_7().method_10();
		float float_ = Class817.smethod_14(class787_0.method_9(), (int)class787_0.method_13().X, (int)class787_0.method_13().Width, flag);
		double crossAt = class787_0.method_9().CrossAt;
		float float_2 = Class817.smethod_14(class787_0.method_9(), (int)(class787_0.method_13().Y - class787_0.method_13().Height), (int)class787_0.method_13().Height, flag);
		Class817.smethod_15(class787_0.method_1(), (int)(class787_0.method_13().Y - class787_0.method_13().Height), (int)class787_0.method_13().Height, flag, class787_0.method_7());
		Class817.smethod_15(class787_0.method_1(), (int)class787_0.method_13().X, (int)class787_0.method_13().Width, flag, class787_0.method_7());
		Class810 class2 = (Class810)class787_0.method_7().method_16()[0];
		if (class2.method_35())
		{
			class787_0.method_8().method_9();
		}
		else
		{
			Struct24.smethod_0(interface42_, class787_0.method_8());
		}
		Rectangle rectangle_ = class787_0.method_8().rectangle_0;
		for (int i = 0; i < @class.Count; i++)
		{
			Class798 class3 = @class.method_9(i).method_3();
			class3.method_0().method_10(class787_0.method_8().rectangle_0.Width);
			class3.method_0().method_11(class787_0.method_8().rectangle_0.Height);
			for (int j = 0; j < @class[i].Points.Count; j++)
			{
				Class798 class4 = @class.method_9(i).method_10().method_1(j)
					.method_6();
				class4.method_0().method_10(class787_0.method_8().rectangle_0.Width);
				class4.method_0().method_11(class787_0.method_8().rectangle_0.Height);
			}
		}
		Struct27.smethod_3(interface42_, class787_0, flag);
		if (!class787_0.method_8().method_18())
		{
			switch (class787_0.Type)
			{
			case ChartType_Chart.Area3D:
				Struct17.smethod_11(interface42_, class787_0, float_2, crossAt, num);
				break;
			case ChartType_Chart.Area3DStacked:
				Struct17.smethod_13(interface42_, class787_0, float_2, crossAt, num, bool_0: false);
				break;
			case ChartType_Chart.Area3D100PercentStacked:
				Struct17.smethod_13(interface42_, class787_0, float_2, crossAt, num, bool_0: true);
				break;
			case ChartType_Chart.Line3D:
				Struct25.smethod_40(interface42_, class787_0, float_2, crossAt, num);
				break;
			case ChartType_Chart.Pie3D:
			case ChartType_Chart.Pie3DExploded:
				Struct33.smethod_2(interface42_, class787_0);
				break;
			case ChartType_Chart.Column3DClustered:
			case ChartType_Chart.Cone:
			case ChartType_Chart.Cylinder:
			case ChartType_Chart.Pyramid:
				Struct25.smethod_32(interface42_, class787_0, float_2, crossAt, num);
				break;
			case ChartType_Chart.Column3DStacked:
			case ChartType_Chart.ConeStacked:
			case ChartType_Chart.CylinderStacked:
			case ChartType_Chart.PyramidStacked:
				Struct25.smethod_34(interface42_, class787_0, crossAt, num);
				break;
			case ChartType_Chart.Column3D100PercentStacked:
			case ChartType_Chart.Cone100PercentStacked:
			case ChartType_Chart.Cylinder100PercentStacked:
			case ChartType_Chart.Pyramid100PercentStacked:
				Struct25.smethod_36(interface42_, class787_0, crossAt, num);
				break;
			case ChartType_Chart.Bar3DClustered:
			case ChartType_Chart.ConicalBar:
			case ChartType_Chart.CylindricalBar:
			case ChartType_Chart.PyramidBar:
				Struct20.smethod_10(interface42_, class787_0, float_, crossAt, num);
				break;
			case ChartType_Chart.Bar3DStacked:
			case ChartType_Chart.ConicalBarStacked:
			case ChartType_Chart.CylindricalBarStacked:
			case ChartType_Chart.PyramidBarStacked:
				Struct20.smethod_12(interface42_, class787_0, crossAt, num);
				break;
			case ChartType_Chart.Bar3D100PercentStacked:
			case ChartType_Chart.ConicalBar100PercentStacked:
			case ChartType_Chart.CylindricalBar100PercentStacked:
			case ChartType_Chart.PyramidBar100PercentStacked:
				Struct20.smethod_14(interface42_, class787_0, crossAt, num);
				break;
			case ChartType_Chart.Column3D:
			case ChartType_Chart.ConicalColumn3D:
			case ChartType_Chart.CylindricalColumn3D:
			case ChartType_Chart.PyramidColumn3D:
				Struct25.smethod_38(interface42_, class787_0, float_2, crossAt, num);
				break;
			}
		}
		if (class787_0.method_3().method_1().method_3() && class787_0.method_8().method_1().method_3())
		{
			class787_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
		}
		if (class787_0.method_9().IsVisible)
		{
			if (flag)
			{
				Struct19.smethod_50(interface42_, class787_0.method_9());
			}
			else
			{
				Struct19.smethod_43(interface42_, class787_0.method_9());
			}
		}
		if (class787_0.method_1().IsVisible)
		{
			if (flag)
			{
				Struct19.smethod_52(interface42_, class787_0.method_1(), num, rectangle_);
			}
			else
			{
				Struct19.smethod_46(interface42_, class787_0.method_1(), num, rectangle_, flag);
			}
		}
		if (class787_0.method_11().IsVisible)
		{
			Struct19.smethod_56(interface42_, class787_0.method_11());
		}
		if (class787_0.method_3().method_1().method_3() && class787_0.method_8().method_1().method_3())
		{
			class787_0.imethod_0().imethod_57(textRenderingHint_);
		}
		if (class787_0.method_9().method_10().IsVisible && class787_0.method_9().IsVisible)
		{
			smethod_5(class787_0, interface42_, class787_0.method_9());
		}
		if (class787_0.method_1().method_10().IsVisible && class787_0.method_1().IsVisible)
		{
			smethod_5(class787_0, interface42_, class787_0.method_1());
		}
		if (class787_0.method_11().method_10().IsVisible && class787_0.method_11().IsVisible)
		{
			smethod_5(class787_0, interface42_, class787_0.method_11());
		}
		if (class787_0.method_12().IsVisible)
		{
			Struct38.smethod_0(class787_0, class787_0.method_12());
		}
		if (class787_0.IsDataTableShown)
		{
			if (class787_0.method_3().method_1().method_3() && class787_0.method_8().method_1().method_3())
			{
				class787_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
			}
			Struct23.smethod_0(interface42_, class787_0.method_4(), flag);
			if (class787_0.method_3().method_1().method_3() && class787_0.method_8().method_1().method_3())
			{
				class787_0.imethod_0().imethod_57(textRenderingHint_);
			}
		}
		if (class787_0.IsLegendShown)
		{
			if (class787_0.method_3().method_1().method_3() && class787_0.method_6().method_0().method_1()
				.method_3())
			{
				class787_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
			}
			if (class787_0.Type != ChartType_Chart.Pie3DExploded && class787_0.Type != ChartType_Chart.Pie3D && !class787_0.method_6().bool_0)
			{
				Struct28.smethod_27(interface42_, class787_0.method_6(), flag, class2);
			}
			else
			{
				Struct28.smethod_11(interface42_, class787_0.method_6(), class2);
			}
			if (class787_0.method_3().method_1().method_3() && class787_0.method_6().method_0().method_1()
				.method_3())
			{
				class787_0.imethod_0().imethod_57(textRenderingHint_);
			}
		}
	}

	private static void smethod_1(Class787 class787_0)
	{
		ChartType_Chart type = class787_0.Type;
		if (type != ChartType_Chart.Pie3D && type != ChartType_Chart.Pie3DExploded)
		{
			return;
		}
		foreach (Class810 item in class787_0.method_7())
		{
			if (item.method_12())
			{
				item.IsColorVaried = true;
			}
			class787_0.IsDataTableShown = false;
			class787_0.method_1().IsVisible = false;
			class787_0.method_1().method_10().Text = "";
			class787_0.method_9().IsVisible = false;
			class787_0.method_9().method_10().Text = "";
			class787_0.method_1().method_7().Formatting = Enum71.const_0;
			class787_0.method_1().method_8().Formatting = Enum71.const_0;
			class787_0.method_9().method_7().Formatting = Enum71.const_0;
			class787_0.method_9().method_8().Formatting = Enum71.const_0;
		}
		if (class787_0.Elevation < 1)
		{
			class787_0.Elevation = 1;
		}
		if (class787_0.Elevation > 90)
		{
			class787_0.Elevation = 90;
		}
	}

	internal static PointF[] smethod_2(Class787 class787_0)
	{
		PointF pointF = new PointF(class787_0.method_13().method_2(), class787_0.method_13().Y);
		int num = class787_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = class787_0.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = class787_0.method_13().Depth;
			num4 = class787_0.method_13().Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = class787_0.method_13().Width;
			num4 = class787_0.method_13().Depth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)class787_0.Elevation * Math.PI / 180.0);
		PointF[] array = new PointF[4];
		PointF[] array2 = new PointF[4];
		switch (num2)
		{
		case 1:
		{
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference29 = ref array2[0];
			reference29 = array[0];
			ref PointF reference30 = ref array2[1];
			reference30 = array[1];
			ref PointF reference31 = ref array2[2];
			reference31 = array[3];
			ref PointF reference32 = ref array2[3];
			reference32 = array[2];
			break;
		}
		case 2:
		{
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference25 = ref array2[0];
			reference25 = array[3];
			ref PointF reference26 = ref array2[1];
			reference26 = array[2];
			ref PointF reference27 = ref array2[2];
			reference27 = array[0];
			ref PointF reference28 = ref array2[3];
			reference28 = array[1];
			break;
		}
		case 3:
		{
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			ref PointF reference21 = ref array2[0];
			reference21 = array[3];
			ref PointF reference22 = ref array2[1];
			reference22 = array[2];
			ref PointF reference23 = ref array2[2];
			reference23 = array[0];
			ref PointF reference24 = ref array2[3];
			reference24 = array[1];
			break;
		}
		case 4:
		{
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			ref PointF reference17 = ref array2[0];
			reference17 = array[3];
			ref PointF reference18 = ref array2[1];
			reference18 = array[2];
			ref PointF reference19 = ref array2[2];
			reference19 = array[0];
			ref PointF reference20 = ref array2[3];
			reference20 = array[1];
			break;
		}
		case 5:
		{
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference13 = ref array2[0];
			reference13 = array[3];
			ref PointF reference14 = ref array2[1];
			reference14 = array[2];
			ref PointF reference15 = ref array2[2];
			reference15 = array[0];
			ref PointF reference16 = ref array2[3];
			reference16 = array[1];
			break;
		}
		case 6:
		{
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference9 = ref array2[0];
			reference9 = array[0];
			ref PointF reference10 = ref array2[1];
			reference10 = array[1];
			ref PointF reference11 = ref array2[2];
			reference11 = array[3];
			ref PointF reference12 = ref array2[3];
			reference12 = array[2];
			break;
		}
		case 7:
		{
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			ref PointF reference5 = ref array2[0];
			reference5 = array[0];
			ref PointF reference6 = ref array2[1];
			reference6 = array[1];
			ref PointF reference7 = ref array2[2];
			reference7 = array[3];
			ref PointF reference8 = ref array2[3];
			reference8 = array[2];
			break;
		}
		case 0:
		case 8:
		{
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[0].X + num5;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			ref PointF reference = ref array2[0];
			reference = array[0];
			ref PointF reference2 = ref array2[1];
			reference2 = array[1];
			ref PointF reference3 = ref array2[2];
			reference3 = array[3];
			ref PointF reference4 = ref array2[3];
			reference4 = array[2];
			break;
		}
		}
		return array2;
	}

	internal static PointF[] smethod_3(Class787 class787_0)
	{
		PointF pointF = new PointF(class787_0.method_13().method_2(), class787_0.method_13().Y);
		int num = class787_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = class787_0.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = class787_0.method_13().Depth;
			num4 = class787_0.method_13().Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = class787_0.method_13().Width;
			num4 = class787_0.method_13().Depth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)class787_0.Elevation * Math.PI / 180.0);
		PointF[] array = new PointF[4];
		PointF[] array2 = new PointF[2];
		switch (num2)
		{
		case 1:
		{
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference15 = ref array2[0];
			reference15 = array[1];
			ref PointF reference16 = ref array2[1];
			reference16 = array[2];
			break;
		}
		case 2:
		{
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference13 = ref array2[0];
			reference13 = array[1];
			ref PointF reference14 = ref array2[1];
			reference14 = array[2];
			break;
		}
		case 3:
		{
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			ref PointF reference11 = ref array2[0];
			reference11 = array[1];
			ref PointF reference12 = ref array2[1];
			reference12 = array[2];
			break;
		}
		case 4:
		{
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			ref PointF reference9 = ref array2[0];
			reference9 = array[0];
			ref PointF reference10 = ref array2[1];
			reference10 = array[3];
			break;
		}
		case 5:
		{
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference7 = ref array2[0];
			reference7 = array[0];
			ref PointF reference8 = ref array2[1];
			reference8 = array[3];
			break;
		}
		case 6:
		{
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			ref PointF reference5 = ref array2[0];
			reference5 = array[0];
			ref PointF reference6 = ref array2[1];
			reference6 = array[3];
			break;
		}
		case 7:
		{
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			ref PointF reference3 = ref array2[0];
			reference3 = array[0];
			ref PointF reference4 = ref array2[1];
			reference4 = array[3];
			break;
		}
		case 0:
		case 8:
		{
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[0].X + num5;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			ref PointF reference = ref array2[0];
			reference = array[1];
			ref PointF reference2 = ref array2[1];
			reference2 = array[2];
			break;
		}
		}
		return array2;
	}

	internal static PointF smethod_4(Class787 class787_0)
	{
		PointF pointF = new PointF(class787_0.method_13().method_2(), class787_0.method_13().Y);
		int num = class787_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = class787_0.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = class787_0.method_13().Depth;
			num4 = class787_0.method_13().Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = class787_0.method_13().Width;
			num4 = class787_0.method_13().Depth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)class787_0.Elevation * Math.PI / 180.0);
		PointF[] array = new PointF[4];
		PointF result = PointF.Empty;
		switch (num2)
		{
		case 1:
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			result = array[2];
			break;
		case 2:
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num5;
			array[2].X = array[1].X + num3;
			array[3].X = array[0].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y + num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			result = array[1];
			break;
		case 3:
			array[1].X = pointF.X - (num3 + num5) / 2f;
			array[0].X = array[1].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			result = array[3];
			break;
		case 4:
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X + num3;
			array[0].Y = pointF.Y - num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y + num6;
			array[3].Y = array[2].Y;
			result = array[2];
			break;
		case 5:
			array[0].X = pointF.X + (num3 + num5) / 2f;
			array[1].X = array[0].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			result = array[0];
			break;
		case 6:
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num5;
			array[2].X = array[1].X - num3;
			array[3].X = array[0].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y - num6;
			array[2].Y = array[1].Y;
			array[3].Y = array[0].Y;
			result = array[3];
			break;
		case 7:
			array[1].X = pointF.X + (num3 + num5) / 2f;
			array[0].X = array[1].X - num3;
			array[2].X = array[1].X - num5;
			array[3].X = array[2].X - num3;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			result = array[1];
			break;
		case 0:
		case 8:
			array[0].X = pointF.X - (num3 + num5) / 2f;
			array[1].X = array[0].X + num3;
			array[2].X = array[1].X + num5;
			array[3].X = array[0].X + num5;
			array[0].Y = pointF.Y + num6 / 2f;
			array[1].Y = array[0].Y;
			array[2].Y = array[1].Y - num6;
			array[3].Y = array[2].Y;
			result = array[0];
			break;
		}
		return result;
	}

	private static void smethod_5(Class787 class787_0, Interface42 interface42_0, Class789 class789_0)
	{
		if (!class789_0.Chart.method_8().method_18())
		{
			Struct38.smethod_0(class787_0, class789_0.method_10());
		}
	}

	private static int smethod_6(Class787 class787_0, Size size_0)
	{
		int num = class787_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2;
		int num3;
		switch (class787_0.Rotation / 45)
		{
		default:
			num2 = size_0.Height;
			num3 = size_0.Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num2 = size_0.Width;
			num3 = size_0.Height;
			break;
		}
		int num4 = (int)((double)num3 * Math.Sin((double)num * Math.PI / 180.0));
		return num2 + num4;
	}

	private static void smethod_7(Interface42 interface42_0, Class789 class789_0, Rectangle rectangle_0, ref Rectangle rectangle_1, bool bool_0)
	{
		bool flag = bool_0;
		Size empty = Size.Empty;
		Class787 chart = class789_0.Chart;
		if (class789_0.method_3() == Enum61.const_1)
		{
			bool_0 = !bool_0;
		}
		if (bool_0)
		{
			empty = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_1.Width * 0.8f, (float)rectangle_1.Height * 0.8f), interface42_0: chart.imethod_0(), class812_0: class789_0.method_10());
			class789_0.method_10().method_0().rectangle_1.Size = empty;
			PointF pointF = smethod_4(chart);
			if (pointF.X < chart.method_13().method_2())
			{
				int num = (int)(pointF.X - (float)rectangle_0.X);
				if (num < empty.Width)
				{
					rectangle_1.X += empty.Width;
					rectangle_1.Width -= empty.Width;
				}
			}
			else
			{
				int num2 = (int)((float)rectangle_1.Right - pointF.X);
				if (num2 < empty.Width)
				{
					class789_0.method_10().method_0().rectangle_1.X = rectangle_1.Right - empty.Width;
					class789_0.method_10().method_0().rectangle_1.Y = rectangle_1.Y + (rectangle_1.Height - empty.Height) / 2;
					rectangle_1.Width -= empty.Width;
				}
			}
			Struct27.smethod_0(chart, rectangle_1, bool_0);
			return;
		}
		PointF[] array = smethod_2(chart);
		if (chart.Elevation == 0)
		{
			empty = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_1.Width * 0.8f, (float)rectangle_1.Height * 0.7f), interface42_0: interface42_0, class812_0: class789_0.method_10());
			class789_0.method_10().method_0().rectangle_1.Size = empty;
			class789_0.method_10().method_0().rectangle_1.Y = rectangle_1.Bottom - empty.Height - int_2;
			int num3 = rectangle_1.Bottom - (int)array[0].Y;
			if (num3 < empty.Height + int_2)
			{
				rectangle_1.Height -= empty.Height + int_2 - num3;
			}
		}
		else if (chart.Elevation > 0)
		{
			if (array[0].Y == array[1].Y)
			{
				empty = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_1.Width * 0.8f, (float)rectangle_1.Height * 0.7f), interface42_0: interface42_0, class812_0: class789_0.method_10());
				class789_0.method_10().method_0().rectangle_1.Size = empty;
				int num4 = 0;
				if (flag)
				{
					class789_0.method_10().method_0().rectangle_1.Y = rectangle_1.Bottom - empty.Height - int_2;
				}
				else
				{
					class789_0.method_10().method_0().rectangle_1.Y = rectangle_0.Bottom - empty.Height - int_2 * 4;
				}
				num4 = rectangle_1.Bottom - (int)array[0].Y;
				if (num4 < empty.Height + int_2)
				{
					rectangle_1.Height -= empty.Height + int_2 - num4;
				}
			}
			else
			{
				empty = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_1.Width * 0.3f, (float)rectangle_1.Height * 0.3f), interface42_0: interface42_0, class812_0: class789_0.method_10());
				class789_0.method_10().method_0().rectangle_1.Size = empty;
				switch (chart.Rotation / 45)
				{
				case 1:
				case 5:
					if ((int)Math.Abs(array[0].X + array[1].X) / 2 - rectangle_1.X < empty.Width)
					{
						int num6 = empty.Width - ((int)Math.Abs(array[0].X + array[1].X) / 2 - rectangle_1.X);
						rectangle_1.X += num6;
						rectangle_1.Width -= num6;
					}
					break;
				case 2:
				case 6:
					if (rectangle_1.Right - (int)Math.Abs(array[0].X + array[1].X) / 2 < empty.Width)
					{
						int num5 = empty.Width - (rectangle_1.Right - (int)Math.Abs(array[0].X + array[1].X) / 2);
						rectangle_1.Width -= num5;
					}
					break;
				}
				if (rectangle_1.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2 < empty.Height)
				{
					rectangle_1.Height -= empty.Height + int_2 - (rectangle_1.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2);
				}
			}
			Struct27.smethod_0(chart, rectangle_1, bool_0);
		}
		else
		{
			class789_0.method_10().Text = "";
		}
	}

	private static void smethod_8(Interface42 interface42_0, Class789 class789_0, ref Rectangle rectangle_0)
	{
		Size empty = Size.Empty;
		Class787 chart = class789_0.Chart;
		PointF[] array = smethod_3(chart);
		if (chart.Elevation == 0)
		{
			empty = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_0.Width * 0.8f, (float)rectangle_0.Height * 0.7f), interface42_0: interface42_0, class812_0: class789_0.method_10());
			class789_0.method_10().method_0().rectangle_1.Size = empty;
			class789_0.method_10().method_0().rectangle_1.Y = rectangle_0.Bottom - empty.Height - int_2;
			int num = rectangle_0.Bottom - (int)array[0].Y;
			if (num < empty.Height + int_2)
			{
				rectangle_0.Height -= empty.Height + int_2 - num;
			}
		}
		if (chart.Elevation > 0)
		{
			if (array[0].Y == array[1].Y)
			{
				empty = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_0.Width * 0.8f, (float)rectangle_0.Height * 0.7f), interface42_0: interface42_0, class812_0: class789_0.method_10());
				class789_0.method_10().method_0().rectangle_1.Size = empty;
				int num2 = 0;
				class789_0.method_10().method_0().rectangle_1.Y = rectangle_0.Bottom - empty.Height - int_2;
				num2 = rectangle_0.Bottom - (int)array[0].Y;
				if (num2 < empty.Height + int_2)
				{
					rectangle_0.Height -= empty.Height + int_2 - num2;
				}
			}
			else
			{
				empty = Struct38.smethod_3(sizeF_0: new SizeF((float)rectangle_0.Width * 0.3f, (float)rectangle_0.Height * 0.3f), interface42_0: interface42_0, class812_0: class789_0.method_10());
				class789_0.method_10().method_0().rectangle_1.Size = empty;
				switch (chart.Rotation / 45)
				{
				case 3:
				case 7:
					if ((int)Math.Abs(array[0].X + array[1].X) / 2 - rectangle_0.X < empty.Width)
					{
						int num4 = empty.Width - ((int)Math.Abs(array[0].X + array[1].X) / 2 - rectangle_0.X);
						rectangle_0.X += num4;
						rectangle_0.Width -= num4;
					}
					break;
				case 0:
				case 4:
				case 8:
					if (rectangle_0.Right - (int)Math.Abs(array[0].X + array[1].X) / 2 < empty.Width)
					{
						int num3 = empty.Width - (rectangle_0.Right - (int)Math.Abs(array[0].X + array[1].X) / 2);
						rectangle_0.Width -= num3;
					}
					break;
				}
				if (rectangle_0.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2 < empty.Height)
				{
					rectangle_0.Height -= empty.Height + int_2 - (rectangle_0.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2);
				}
			}
			Struct27.smethod_0(chart, rectangle_0, bool_0: false);
		}
		else
		{
			class789_0.method_10().Text = "";
		}
	}

	private static void smethod_9(Class789 class789_0, Rectangle rectangle_0, bool bool_0, Size size_0, Size size_1, int int_3)
	{
		bool flag = bool_0;
		Size empty = Size.Empty;
		Class787 chart = class789_0.Chart;
		if (class789_0.method_3() == Enum61.const_1)
		{
			empty = size_0;
			flag = !bool_0;
		}
		else
		{
			empty = size_1;
			if (class789_0.TickLabelPosition != Enum83.const_3)
			{
				empty.Width += int_3;
			}
		}
		if (flag)
		{
			Size size = class789_0.method_10().method_0().rectangle_1.Size;
			PointF pointF = smethod_4(chart);
			if (pointF.X < chart.method_13().method_2())
			{
				class789_0.method_10().method_0().rectangle_1.X = ((class789_0.TickLabelPosition == Enum83.const_3) ? ((int)(pointF.X - (float)size.Width)) : ((int)(pointF.X - (float)empty.Width - (float)size.Width)));
				class789_0.method_10().method_0().rectangle_1.Y = (int)(pointF.Y - chart.method_13().Height / 2f - (float)(size.Height / 2));
				return;
			}
			int num = (int)((float)rectangle_0.Right - pointF.X);
			if (num >= size.Width)
			{
				class789_0.method_10().method_0().rectangle_1.X = ((class789_0.TickLabelPosition == Enum83.const_3) ? ((int)pointF.X) : ((int)(pointF.X + (float)empty.Width)));
				class789_0.method_10().method_0().rectangle_1.Y = (int)(pointF.Y - chart.method_13().Height / 2f - (float)(size.Height / 2));
			}
			return;
		}
		PointF[] array = smethod_2(chart);
		if (array[0].Y == array[1].Y)
		{
			if (chart.Elevation >= 0)
			{
				class789_0.method_10().method_0().rectangle_1.X = (int)((array[0].X + array[1].X) / 2f - (float)(class789_0.method_10().method_0().rectangle_1.Width / 2));
			}
			return;
		}
		if (!(array[0].X >= array[1].X))
		{
			_ = array[0].X;
		}
		else
		{
			_ = array[1].X;
		}
		if (!(array[0].X >= array[1].X))
		{
			_ = array[1].X;
		}
		else
		{
			_ = array[0].X;
		}
		if ((chart.Rotation >= 45 && chart.Rotation < 90) || (chart.Rotation >= 225 && chart.Rotation < 270))
		{
			class789_0.method_10().method_0().rectangle_1.X = (int)(Math.Abs(array[0].X + array[1].X) / 2f - (float)class789_0.method_10().method_0().rectangle_1.Width - (float)smethod_6(chart, empty));
		}
		else
		{
			class789_0.method_10().method_0().rectangle_1.X = (int)(Math.Abs(array[0].X + array[1].X) / 2f + (float)smethod_6(chart, empty));
		}
		class789_0.method_10().method_0().rectangle_1.Y = (int)(Math.Abs(array[0].Y + array[1].Y) / 2f);
	}

	private static void smethod_10(Class787 class787_0)
	{
		Class789 @class = class787_0.method_11();
		ArrayList arrayList_ = class787_0.method_11().arrayList_1;
		IList list = class787_0.method_7().method_16();
		for (int i = 0; i < list.Count; i++)
		{
			Class810 class2 = (Class810)list[i];
			arrayList_.Add(class2.method_9());
		}
		@class.MinValue = 0.0;
		@class.MaxValue = list.Count;
		@class.MajorUnit = @class.TickMarkSpacing;
		@class.MinorUnit = @class.MajorUnit / 2.0;
	}

	private static void smethod_11(Class787 class787_0)
	{
		if (class787_0.Type == ChartType_Chart.Area3DStacked || class787_0.Type == ChartType_Chart.Area3D100PercentStacked)
		{
			class787_0.GapWidth = 20;
		}
	}
}
