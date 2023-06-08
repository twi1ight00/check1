using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Aspose.Cells.Render;
using ns19;
using ns3;
using ns33;

namespace ns34;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct48
{
	private static int int_0 = 10;

	private static int int_1 = 8;

	private static int int_2 = 3;

	internal static void Calculate(Class821 class821_0)
	{
		Interface42 interface42_ = class821_0.imethod_0();
		Class842 @class = class821_0.method_7();
		if (class821_0.method_7().Count == 0 || Struct47.smethod_32(class821_0.method_7().method_15()) == 0)
		{
			return;
		}
		if (class821_0.NSeries.imethod_0().Count > 0)
		{
			class821_0.method_7().bool_0 = true;
		}
		if (class821_0.NSeries.imethod_1().Count > 0)
		{
			class821_0.method_7().bool_1 = true;
		}
		class821_0.method_7().method_5(Struct47.smethod_85(class821_0.method_7().imethod_0()));
		class821_0.method_7().method_8(Struct47.smethod_85(class821_0.method_7().imethod_1()));
		class821_0.method_7().method_1(Struct47.smethod_86(class821_0.method_7().imethod_0()));
		class821_0.method_7().method_3(Struct47.smethod_86(class821_0.method_7().imethod_1()));
		string text = Struct47.smethod_1(class821_0);
		if (text != "")
		{
			throw new ArgumentException(text);
		}
		smethod_1(class821_0);
		Struct47.smethod_8(class821_0);
		smethod_11(class821_0);
		Struct63.smethod_6(class821_0.method_1(), class821_0.method_9(), class821_0.method_7(), class821_0.method_7().method_9(0));
		bool flag = Struct47.smethod_10(class821_0.Type);
		bool flag2 = Struct52.smethod_8(class821_0);
		Class844 class844_ = (Class844)class821_0.method_7().method_16()[0];
		if (flag)
		{
			if (class821_0.Elevation < 0)
			{
				class821_0.Elevation = 0;
			}
			if (class821_0.Elevation > 44)
			{
				class821_0.Elevation = 44;
			}
			if (class821_0.Rotation < 0)
			{
				class821_0.Rotation = 0;
			}
			if (class821_0.Rotation > 44)
			{
				class821_0.Rotation = 44;
			}
		}
		if (!flag2)
		{
			class821_0.method_11().method_11().Text = "";
			class821_0.method_11().IsVisible = false;
		}
		Rectangle rectangle_ = new Rectangle(int_0 + class821_0.Position.X, int_0 + class821_0.Position.Y, class821_0.Position.Width - int_0 * 2, class821_0.Position.Height - int_0 * 2);
		if (class821_0.method_12().IsVisible)
		{
			SizeF sizeF_ = new SizeF((float)rectangle_.Width * 0.8f, (float)rectangle_.Height * 0.8f);
			Size size = class821_0.method_12().method_3(sizeF_);
			class821_0.method_12().method_0().rectangle_1.X = (class821_0.Position.Width - size.Width) / 2;
			class821_0.method_12().method_0().rectangle_1.Y = int_0;
			class821_0.method_12().method_0().rectangle_1.Size = size;
			rectangle_.Y += size.Height + int_1;
			rectangle_.Height -= size.Height + int_1;
		}
		bool flag3 = Struct53.smethod_6(class821_0);
		class821_0.method_6().bool_0 = flag3;
		Struct47.smethod_6(class821_0);
		if (class821_0.IsLegendShown)
		{
			if (class821_0.Type != ChartType_Chart.Pie3DExploded && class821_0.Type != ChartType_Chart.Pie3D && !flag3)
			{
				Struct47.smethod_30(class821_0);
				Struct53.smethod_16(interface42_, class821_0.method_6(), ref rectangle_);
			}
			else
			{
				Class844 class844_2 = (Class844)class821_0.method_7().method_16()[0];
				Struct53.smethod_15(interface42_, class821_0.method_6(), class844_2, ref rectangle_);
			}
		}
		Struct52.smethod_0(class821_0, rectangle_, flag);
		Rectangle rectangle_2 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		if (class821_0.method_1().method_11().IsVisible && class821_0.method_1().IsVisible)
		{
			smethod_7(interface42_, class821_0.method_1(), rectangle_2, ref rectangle_, flag);
		}
		if (class821_0.method_9().method_11().IsVisible && class821_0.method_9().IsVisible)
		{
			smethod_7(interface42_, class821_0.method_9(), rectangle_2, ref rectangle_, flag);
		}
		Struct57.smethod_0(class821_0, ref rectangle_, class844_);
		class821_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		if (!class821_0.method_8().imethod_3())
		{
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
		class821_0.method_8().rectangle_1 = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
		double minValue;
		double maxValue;
		bool bool_ = Struct47.smethod_33(@class.method_15(), out minValue, out maxValue, class821_0.method_9());
		bool flag4 = class821_0.method_9().imethod_7();
		bool bool_2 = class821_0.method_9().imethod_9();
		bool bool_3 = class821_0.method_9().imethod_5();
		bool bool_4 = class821_0.method_9().imethod_3();
		Struct47.smethod_47(interface42_, class821_0.method_9(), maxValue, minValue, bool_, class821_0.method_9().arrayList_1, class821_0.Type, rectangle_, flag, @class.method_9(0));
		Struct47.smethod_64(interface42_, class821_0.method_1(), class821_0.method_1().arrayList_1, rectangle_, class821_0.Type, @class, flag);
		if (flag2)
		{
			smethod_10(class821_0);
		}
		if (!Struct63.smethod_18(rectangle_))
		{
			rectangle_.X += int_2;
			rectangle_.Y += int_2;
			rectangle_.Width -= 2 * int_2;
			rectangle_.Height -= 2 * int_2;
			Struct52.smethod_0(class821_0, rectangle_, flag);
		}
		Struct44.smethod_40(class821_0);
		if (flag2 && class821_0.method_11().method_11().IsVisible && class821_0.method_11().IsVisible)
		{
			smethod_8(interface42_, class821_0.method_11(), ref rectangle_);
		}
		bool flag5 = false;
		int num = class821_0.Rotation / 45;
		if (!Struct63.smethod_18(rectangle_) && class821_0.IsDataTableShown)
		{
			Struct47.smethod_29(class821_0);
			Size size_ = Struct49.smethod_4(interface42_, class821_0.method_4());
			class821_0.method_4().method_2(size_);
			int num2 = Struct49.smethod_6(interface42_, class821_0.method_4(), rectangle_);
			class821_0.method_4().method_4(num2);
			int num3 = size_.Height + num2;
			class821_0.method_4().rectangle_0.Height = num3;
			smethod_2(class821_0);
			if (class821_0.Elevation > 0 && !flag)
			{
				switch (num)
				{
				case 1:
				case 2:
				case 5:
				case 6:
					if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
					{
						class821_0.method_4().rectangle_0.X = rectangle_.X + size_.Width;
						class821_0.method_4().rectangle_0.Y = rectangle_.Bottom;
						class821_0.method_4().rectangle_0.Width = rectangle_.Width - size_.Width;
						rectangle_.Height += num3;
					}
					else
					{
						rectangle_.Height -= num3;
						class821_0.method_4().rectangle_0.X = rectangle_.X + size_.Width;
						class821_0.method_4().rectangle_0.Y = rectangle_.Bottom;
						class821_0.method_4().rectangle_0.Width = rectangle_.Width - size_.Width;
					}
					break;
				case 0:
				case 3:
				case 4:
				case 7:
				case 8:
					if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
					{
						rectangle_.Height += num3 + int_2;
						rectangle_.X -= size_.Width;
						rectangle_.Width += size_.Width;
					}
					else
					{
						rectangle_.Height -= num3 + int_2;
						rectangle_.X += size_.Width;
						rectangle_.Width -= size_.Width;
					}
					class821_0.method_1().TickLabelPosition = Enum83.const_3;
					class821_0.method_1().MajorTickMark = Enum84.const_2;
					class821_0.method_1().MinorTickMark = Enum84.const_2;
					break;
				}
			}
			else if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
			{
				class821_0.method_4().rectangle_0.X = rectangle_.X + size_.Width;
				class821_0.method_4().rectangle_0.Y = rectangle_.Bottom;
				class821_0.method_4().rectangle_0.Width = rectangle_.Width - size_.Width;
				rectangle_.Height += num3;
			}
			else
			{
				rectangle_.Height -= num3;
				class821_0.method_4().rectangle_0.X = rectangle_.X + size_.Width;
				class821_0.method_4().rectangle_0.Y = rectangle_.Bottom;
				class821_0.method_4().rectangle_0.Width = rectangle_.Width - size_.Width;
			}
			if (class821_0.method_8().imethod_3() || !class821_0.IsInnerMode)
			{
				Struct52.smethod_0(class821_0, rectangle_, flag);
			}
		}
		int num4 = class821_0.method_7().method_10();
		Size size2 = Struct44.smethod_41(interface42_, class821_0.method_11(), class821_0.method_11().arrayList_1, rectangle_);
		int num5 = class821_0.method_11().method_10().Offset * class821_0.Position.Height / 4000;
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_11().TickLabelPosition != Enum83.const_3 && class821_0.method_11().IsVisible)
		{
			Size size3 = new Size(0, 0);
			if (class821_0.method_11().IsVisible)
			{
				size3 = class821_0.method_11().method_11().method_0()
					.rectangle_1.Size;
			}
			if (!flag)
			{
				PointF[] array = smethod_3(class821_0);
				int num6 = 0;
				if (array[0].Y < array[1].Y)
				{
					num6 = 1;
				}
				float num7 = Math.Abs((array[1].Y - array[0].Y) / (float)num4);
				int num8 = size2.Height + num5;
				if (class821_0.Elevation > 0)
				{
					if (array[0].Y == array[1].Y)
					{
						if (rectangle_.Bottom - size3.Height - (int)array[0].Y < num8)
						{
							if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
							{
								rectangle_.Height += num8 - (rectangle_.Bottom - size3.Height - (int)array[0].Y);
							}
							else
							{
								rectangle_.Height -= num8 - (rectangle_.Bottom - size3.Height - (int)array[0].Y);
							}
						}
					}
					else
					{
						Size size_2 = size2;
						if (class821_0.method_1().TickLabelPosition != Enum83.const_3)
						{
							size_2.Width += num5;
						}
						int num9 = size3.Width + smethod_6(class821_0, size_2);
						switch (num)
						{
						case 3:
						case 7:
							if ((int)Math.Abs(array[0].X + array[1].X) / 2 - rectangle_.X < num9)
							{
								int num11 = num9 - ((int)Math.Abs(array[0].X + array[1].X) / 2 - rectangle_.X);
								if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
								{
									rectangle_.X -= num11;
									rectangle_.Width += num11;
								}
								else
								{
									rectangle_.X += num11;
									rectangle_.Width -= num11;
								}
							}
							break;
						case 0:
						case 4:
						case 8:
							if (rectangle_.Right - (int)Math.Abs(array[0].X + array[1].X) / 2 < num9)
							{
								int num10 = num9 - (rectangle_.Right - (int)Math.Abs(array[0].X + array[1].X) / 2);
								if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
								{
									rectangle_.Width += num10;
								}
								else
								{
									rectangle_.Width -= num10;
								}
							}
							break;
						}
						float num12 = num7 * (float)Math.Sin((double)class821_0.Elevation * Math.PI / 180.0);
						if ((int)((float)rectangle_.Bottom - array[num6].Y + num12) < size2.Height)
						{
							if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
							{
								rectangle_.Height += size2.Height - (int)((float)rectangle_.Bottom - array[num6].Y + num12);
							}
							else
							{
								rectangle_.Height -= size2.Height - (int)((float)rectangle_.Bottom - array[num6].Y + num12);
							}
						}
					}
				}
			}
			else
			{
				PointF pointF = smethod_4(class821_0);
				int num13 = size2.Width + num5;
				int num14 = (int)(pointF.X - (float)rectangle_.X);
				if (num14 < num13)
				{
					if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
					{
						rectangle_.X -= num13;
						rectangle_.Width += num13;
					}
					else
					{
						rectangle_.X += num13;
						rectangle_.Width -= num13;
					}
				}
			}
			if (class821_0.method_8().imethod_3() || !class821_0.IsInnerMode)
			{
				Struct52.smethod_0(class821_0, rectangle_, bool_0: false);
			}
		}
		Size size_3 = Struct44.smethod_19(interface42_, class821_0.method_9(), @class.method_9(0), flag);
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_9().TickLabelPosition != Enum83.const_3 && class821_0.method_9().IsVisible)
		{
			if (!flag)
			{
				PointF pointF2 = smethod_4(class821_0);
				if (pointF2.X < class821_0.method_13().method_2())
				{
					int num15 = (int)(pointF2.X - (float)rectangle_.X);
					if (!flag5)
					{
						num15 -= class821_0.method_9().method_11().method_0()
							.rectangle_1.Size.Width;
					}
					int num16 = size_3.Width;
					if (class821_0.IsDataTableShown)
					{
						num16 -= class821_0.method_4().method_1().Width;
					}
					if (num15 < num16)
					{
						if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
						{
							rectangle_.X -= num16;
							rectangle_.Width += num16;
						}
						else
						{
							rectangle_.X += num16;
							rectangle_.Width -= num16;
						}
					}
				}
				else
				{
					int num17 = (int)((float)rectangle_.Right - pointF2.X);
					if (num17 < size_3.Width)
					{
						if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
						{
							rectangle_.Width += size_3.Width;
						}
						else
						{
							rectangle_.Width -= size_3.Width;
						}
					}
				}
				if (class821_0.Elevation >= 0)
				{
					switch (num)
					{
					case 1:
					case 2:
					case 5:
					case 6:
						if ((float)rectangle_.Bottom - pointF2.Y < (float)(size_3.Height / 2))
						{
							if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
							{
								rectangle_.Height += size_3.Height / 2;
							}
							else
							{
								rectangle_.Height -= size_3.Height / 2;
							}
						}
						break;
					}
				}
				else
				{
					if (pointF2.Y - class821_0.method_13().Height - (float)rectangle_.Y < (float)(size_3.Height / 2))
					{
						if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
						{
							rectangle_.Y -= size_3.Height / 2;
						}
						else
						{
							rectangle_.Y += size_3.Height / 2;
						}
					}
					if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
					{
						rectangle_.Height += size_3.Height / 2;
					}
					else
					{
						rectangle_.Height -= size_3.Height / 2;
					}
				}
			}
			else
			{
				PointF[] array2 = smethod_2(class821_0);
				int height = size_3.Height;
				if (rectangle_.Bottom - (int)array2[0].Y < height)
				{
					if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
					{
						rectangle_.Height += height - (rectangle_.Bottom - (int)array2[0].Y);
					}
					else
					{
						rectangle_.Height -= height - (rectangle_.Bottom - (int)array2[0].Y);
					}
				}
			}
			if (class821_0.method_8().imethod_3() || !class821_0.IsInnerMode)
			{
				Struct52.smethod_0(class821_0, rectangle_, flag);
			}
		}
		Size size4 = Struct44.smethod_20(interface42_, class821_0.method_1(), rectangle_, rectangle_, num4, flag, @class.method_9(0));
		int num18 = (int)((double)(class821_0.method_1().method_10().method_1() + class821_0.method_1().method_19() + class821_0.method_1().method_21()) + 0.5);
		if (class821_0.method_7().method_4() != null)
		{
			num18 += num18 * class821_0.method_7().method_4().Length;
		}
		if (!Struct63.smethod_18(rectangle_) && class821_0.method_1().TickLabelPosition != Enum83.const_3 && class821_0.method_1().IsVisible)
		{
			Size size5 = new Size(0, 0);
			if (class821_0.method_1().method_11().IsVisible)
			{
				size5 = class821_0.method_1().method_11().method_0()
					.rectangle_1.Size;
			}
			if (!flag)
			{
				PointF[] array3 = smethod_2(class821_0);
				int num19 = 0;
				if (array3[0].Y < array3[1].Y)
				{
					num19 = 1;
				}
				float num20 = Math.Abs((array3[1].Y - array3[0].Y) / (float)num4);
				int num21 = size4.Height + num18;
				if (class821_0.Elevation >= 0)
				{
					if (array3[0].Y == array3[1].Y)
					{
						if (rectangle_.Bottom - size5.Height - (int)array3[0].Y < num21)
						{
							if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
							{
								rectangle_.Height += num21 - (rectangle_.Bottom - size5.Height - (int)array3[0].Y);
							}
							else
							{
								rectangle_.Height -= num21 - (rectangle_.Bottom - size5.Height - (int)array3[0].Y);
							}
						}
					}
					else
					{
						Size size_4 = size4;
						if (class821_0.method_1().TickLabelPosition != Enum83.const_3)
						{
							size_4.Width += num18;
						}
						int num22 = size5.Width + smethod_6(class821_0, size_4);
						switch (num)
						{
						case 1:
						case 5:
							if ((int)Math.Abs(array3[0].X + array3[1].X) / 2 - rectangle_.X < num22)
							{
								int num24 = num22 - ((int)Math.Abs(array3[0].X + array3[1].X) / 2 - rectangle_.X);
								if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
								{
									rectangle_.X -= num24;
									rectangle_.Width += num24;
								}
								else
								{
									rectangle_.X += num24;
									rectangle_.Width -= num24;
								}
							}
							break;
						case 2:
						case 6:
							if (rectangle_.Right - (int)Math.Abs(array3[0].X + array3[1].X) / 2 < num22)
							{
								int num23 = num22 - (rectangle_.Right - (int)Math.Abs(array3[0].X + array3[1].X) / 2);
								if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
								{
									rectangle_.Width += num23;
								}
								else
								{
									rectangle_.Width -= num23;
								}
							}
							break;
						}
						float num25 = num20 * (float)Math.Sin((double)class821_0.Elevation * Math.PI / 180.0);
						if ((int)((float)rectangle_.Bottom - array3[num19].Y + num25) < size4.Height)
						{
							if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
							{
								rectangle_.Height += size4.Height - (int)((float)rectangle_.Bottom - array3[num19].Y + num25);
							}
							else
							{
								rectangle_.Height -= size4.Height - (int)((float)rectangle_.Bottom - array3[num19].Y + num25);
							}
						}
					}
				}
			}
			else
			{
				PointF pointF3 = smethod_4(class821_0);
				int num26 = size4.Width + num18;
				int num27 = (int)(pointF3.X - (float)rectangle_.X);
				if (num27 < num26)
				{
					if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
					{
						rectangle_.X -= num26;
						rectangle_.Width += num26;
					}
					else
					{
						rectangle_.X += num26;
						rectangle_.Width -= num26;
					}
				}
			}
			if (class821_0.method_8().imethod_3() || !class821_0.IsInnerMode)
			{
				Struct52.smethod_0(class821_0, rectangle_, flag);
			}
		}
		if (!Struct63.smethod_18(rectangle_) && class821_0.IsDataTableShown)
		{
			int num28 = Struct49.smethod_6(interface42_, class821_0.method_4(), rectangle_);
			if (num28 > class821_0.method_4().method_3())
			{
				class821_0.method_4().method_4(num28);
				int num29 = num28 - class821_0.method_4().method_3();
				class821_0.method_4().rectangle_0.Height += num29;
				smethod_2(class821_0);
				if (class821_0.Elevation > 0 && !flag)
				{
					switch (num)
					{
					case 1:
					case 2:
					case 5:
					case 6:
						if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
						{
							class821_0.method_4().rectangle_0.Y += num29;
							rectangle_.Height += num29;
						}
						else
						{
							rectangle_.Height -= num29;
							class821_0.method_4().rectangle_0.Y -= num29;
						}
						break;
					case 0:
					case 3:
					case 4:
					case 7:
					case 8:
						if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
						{
							rectangle_.Height += num29 + int_2;
						}
						else
						{
							rectangle_.Height -= num29 + int_2;
						}
						class821_0.method_1().TickLabelPosition = Enum83.const_3;
						class821_0.method_1().MajorTickMark = Enum84.const_2;
						class821_0.method_1().MinorTickMark = Enum84.const_2;
						break;
					}
				}
				else if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode)
				{
					class821_0.method_4().rectangle_0.Y += num29;
					rectangle_.Height += num29;
				}
				else
				{
					rectangle_.Height -= num29;
					class821_0.method_4().rectangle_0.Y -= num29;
				}
				if (class821_0.method_8().imethod_3() || !class821_0.IsInnerMode)
				{
					Struct52.smethod_0(class821_0, rectangle_, flag);
				}
			}
		}
		if (class821_0.method_9().IsVisible)
		{
			int num30 = Struct47.smethod_51(interface42_, class821_0.method_9(), flag, class821_0.method_7().method_9(0), rectangle_);
			int num31 = 0;
			num31 = ((!flag) ? Struct63.smethod_3(class821_0.method_13().Height) : Struct63.smethod_3(class821_0.method_13().Width));
			if (flag4 && class821_0.method_9().arrayList_1.Count > 3 && num30 > num31 && num31 != 0)
			{
				class821_0.method_9().arrayList_1.Clear();
				class821_0.method_9().imethod_8(flag4);
				class821_0.method_9().imethod_10(bool_2);
				class821_0.method_9().imethod_6(bool_3);
				class821_0.method_9().imethod_4(bool_4);
				Struct47.smethod_47(interface42_, class821_0.method_9(), maxValue, minValue, bool_, class821_0.method_9().arrayList_1, class821_0.method_7().method_9(0).method_22(), rectangle_, flag, class821_0.method_7().method_9(0));
			}
		}
		if (!class821_0.method_8().imethod_3() && class821_0.IsInnerMode && class821_0.Type != ChartType_Chart.Pie3D && class821_0.Type != ChartType_Chart.Pie3DExploded)
		{
			Rectangle rectangle = new Rectangle(rectangle_.X, rectangle_.Y, rectangle_.Width, rectangle_.Height);
			rectangle_ = new Rectangle(class821_0.method_8().rectangle_1.X, class821_0.method_8().rectangle_1.Y, class821_0.method_8().rectangle_1.Width, class821_0.method_8().rectangle_1.Height);
			class821_0.method_8().rectangle_1 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
		}
		if (class821_0.method_1().method_11().IsVisible && class821_0.method_1().IsVisible)
		{
			smethod_9(class821_0.method_1(), rectangle_, flag, size_3, size4, num18);
		}
		if (class821_0.method_9().method_11().IsVisible && class821_0.method_9().IsVisible)
		{
			smethod_9(class821_0.method_9(), rectangle_, flag, size_3, size4, num18);
		}
		if (class821_0.method_11().method_11().IsVisible && class821_0.method_11().IsVisible)
		{
			Size size_5 = size2;
			if (class821_0.method_11().TickLabelPosition != Enum83.const_3)
			{
				size_5.Width += num5;
			}
			PointF[] array4 = smethod_3(class821_0);
			if (array4[0].Y == array4[1].Y)
			{
				if (class821_0.Elevation >= 0)
				{
					class821_0.method_11().method_11().method_0()
						.rectangle_1.X = (int)((array4[0].X + array4[1].X) / 2f - (float)(class821_0.method_11().method_11().method_0()
						.rectangle_1.Width / 2));
				}
			}
			else
			{
				if (!(array4[0].X >= array4[1].X))
				{
					_ = array4[0].X;
				}
				else
				{
					_ = array4[1].X;
				}
				if (!(array4[0].X >= array4[1].X))
				{
					_ = array4[1].X;
				}
				else
				{
					_ = array4[0].X;
				}
				switch (num)
				{
				case 3:
				case 7:
					class821_0.method_11().method_11().method_0()
						.rectangle_1.X = (int)(Math.Abs(array4[0].X + array4[1].X) / 2f - (float)class821_0.method_11().method_11().method_0()
						.rectangle_1.Width - (float)smethod_6(class821_0, size_5));
					break;
				case 0:
				case 4:
				case 8:
					class821_0.method_11().method_11().method_0()
						.rectangle_1.X = (int)(Math.Abs(array4[0].X + array4[1].X) / 2f + (float)smethod_6(class821_0, size_5));
					break;
				}
				class821_0.method_11().method_11().method_0()
					.rectangle_1.Y = (int)(Math.Abs(array4[0].Y + array4[1].Y) / 2f);
			}
		}
		if (!class821_0.IsDataTableShown || flag)
		{
			return;
		}
		PointF[] array5 = smethod_2(class821_0);
		if (class821_0.Elevation > 0)
		{
			switch (num)
			{
			case 0:
			case 3:
			case 4:
			case 7:
			case 8:
			{
				int num32 = ((!(array5[0].X < array5[1].X)) ? 1 : 0);
				class821_0.method_4().rectangle_0.X = (int)array5[num32].X;
				class821_0.method_4().rectangle_0.Y = (int)array5[num32].Y;
				class821_0.method_4().rectangle_0.Width = (int)Math.Abs(array5[1].X - array5[0].X);
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

	internal static void smethod_0(Class821 class821_0)
	{
		Calculate(class821_0);
		Interface42 interface42_ = class821_0.imethod_0();
		TextRenderingHint textRenderingHint_ = class821_0.imethod_0().imethod_56();
		class821_0.method_7();
		if (class821_0.method_7().Count == 0 || Struct47.smethod_32(class821_0.method_7().method_15()) == 0)
		{
			return;
		}
		bool flag = Struct47.smethod_10(class821_0.Type);
		bool flag2 = class821_0.method_8().method_16();
		int num = class821_0.method_7().method_10();
		float float_ = Struct47.smethod_18(class821_0.method_9(), (int)class821_0.method_13().X, (int)class821_0.method_13().Width, flag);
		double crossAt = class821_0.method_9().CrossAt;
		float float_2 = Struct47.smethod_18(class821_0.method_9(), (int)(class821_0.method_13().Y - class821_0.method_13().Height), (int)class821_0.method_13().Height, flag);
		Struct47.smethod_19(class821_0.method_1(), (int)(class821_0.method_13().Y - class821_0.method_13().Height), (int)class821_0.method_13().Height, flag, class821_0.method_7());
		Struct47.smethod_19(class821_0.method_1(), (int)class821_0.method_13().X, (int)class821_0.method_13().Width, flag, class821_0.method_7());
		class821_0.method_8().method_19();
		Rectangle rectangle_ = class821_0.method_8().rectangle_0;
		Struct52.smethod_3(interface42_, class821_0, flag);
		Class844 class844_ = (Class844)class821_0.method_7().method_16()[0];
		if (!flag2)
		{
			switch (class821_0.Type)
			{
			case ChartType_Chart.Area3D:
				Struct43.smethod_9(interface42_, class821_0, float_2, crossAt, num);
				break;
			case ChartType_Chart.Area3DStacked:
				Struct43.smethod_11(interface42_, class821_0, float_2, crossAt, num, bool_0: false);
				break;
			case ChartType_Chart.Area3D100PercentStacked:
				Struct43.smethod_11(interface42_, class821_0, float_2, crossAt, num, bool_0: true);
				break;
			case ChartType_Chart.Line3D:
				Struct50.smethod_40(interface42_, class821_0, float_2, crossAt, num);
				break;
			case ChartType_Chart.Pie3D:
			case ChartType_Chart.Pie3DExploded:
				Struct57.smethod_2(interface42_, class821_0);
				break;
			case ChartType_Chart.Column3DClustered:
			case ChartType_Chart.Cone:
			case ChartType_Chart.Cylinder:
			case ChartType_Chart.Pyramid:
				Struct50.smethod_32(interface42_, class821_0, float_2, crossAt, num);
				break;
			case ChartType_Chart.Column3DStacked:
			case ChartType_Chart.ConeStacked:
			case ChartType_Chart.CylinderStacked:
			case ChartType_Chart.PyramidStacked:
				Struct50.smethod_34(interface42_, class821_0, crossAt, num);
				break;
			case ChartType_Chart.Column3D100PercentStacked:
			case ChartType_Chart.Cone100PercentStacked:
			case ChartType_Chart.Cylinder100PercentStacked:
			case ChartType_Chart.Pyramid100PercentStacked:
				Struct50.smethod_36(interface42_, class821_0, crossAt, num);
				break;
			case ChartType_Chart.Bar3DClustered:
			case ChartType_Chart.ConicalBar:
			case ChartType_Chart.CylindricalBar:
			case ChartType_Chart.PyramidBar:
				Struct45.smethod_10(interface42_, class821_0, float_, crossAt, num);
				break;
			case ChartType_Chart.Bar3DStacked:
			case ChartType_Chart.ConicalBarStacked:
			case ChartType_Chart.CylindricalBarStacked:
			case ChartType_Chart.PyramidBarStacked:
				Struct45.smethod_12(interface42_, class821_0, crossAt, num);
				break;
			case ChartType_Chart.Bar3D100PercentStacked:
			case ChartType_Chart.ConicalBar100PercentStacked:
			case ChartType_Chart.CylindricalBar100PercentStacked:
			case ChartType_Chart.PyramidBar100PercentStacked:
				Struct45.smethod_14(interface42_, class821_0, crossAt, num);
				break;
			case ChartType_Chart.Column3D:
			case ChartType_Chart.ConicalColumn3D:
			case ChartType_Chart.CylindricalColumn3D:
			case ChartType_Chart.PyramidColumn3D:
				Struct50.smethod_38(interface42_, class821_0, float_2, crossAt, num);
				break;
			}
		}
		if (class821_0.method_3().method_1().method_2() && class821_0.method_8().method_1().method_2())
		{
			class821_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
		}
		if (class821_0.method_9().IsVisible)
		{
			if (flag)
			{
				Struct44.smethod_49(interface42_, class821_0.method_9());
			}
			else
			{
				Struct44.smethod_42(interface42_, class821_0.method_9());
			}
		}
		if (class821_0.method_1().IsVisible)
		{
			if (flag)
			{
				Struct44.smethod_51(interface42_, class821_0.method_1(), num, rectangle_);
			}
			else
			{
				Struct44.smethod_45(interface42_, class821_0.method_1(), num, rectangle_, flag);
			}
		}
		if (class821_0.method_11().IsVisible)
		{
			Struct44.smethod_55(interface42_, class821_0.method_11());
		}
		if (class821_0.method_3().method_1().method_2() && class821_0.method_8().method_1().method_2())
		{
			class821_0.imethod_0().imethod_57(textRenderingHint_);
		}
		if (class821_0.method_9().method_11().IsVisible && class821_0.method_9().IsVisible)
		{
			smethod_5(class821_0, interface42_, class821_0.method_9());
		}
		if (class821_0.method_1().method_11().IsVisible && class821_0.method_1().IsVisible)
		{
			smethod_5(class821_0, interface42_, class821_0.method_1());
		}
		if (class821_0.method_11().method_11().IsVisible && class821_0.method_11().IsVisible)
		{
			smethod_5(class821_0, interface42_, class821_0.method_11());
		}
		if (class821_0.method_12().IsVisible)
		{
			class821_0.method_12().method_2();
		}
		if (class821_0.IsDataTableShown)
		{
			Struct49.smethod_0(interface42_, class821_0.method_4(), class821_0.method_4().rectangle_0.X, class821_0.method_4().rectangle_0.Y, class821_0.method_4().rectangle_0.Width, flag);
		}
		if (class821_0.IsLegendShown)
		{
			if (class821_0.method_3().method_1().method_2() && class821_0.method_6().method_0().method_1()
				.method_2())
			{
				class821_0.imethod_0().imethod_57(TextRenderingHint.AntiAlias);
			}
			if (class821_0.Type != ChartType_Chart.Pie3DExploded && class821_0.Type != ChartType_Chart.Pie3D && !class821_0.method_6().bool_0)
			{
				Struct53.smethod_21(interface42_, class821_0.method_6(), flag, class844_);
			}
			else
			{
				Struct53.smethod_8(interface42_, class821_0.method_6(), class844_);
			}
			if (class821_0.method_3().method_1().method_2() && class821_0.method_6().method_0().method_1()
				.method_2())
			{
				class821_0.imethod_0().imethod_57(textRenderingHint_);
			}
		}
	}

	private static void smethod_1(Class821 class821_0)
	{
		ChartType_Chart type = class821_0.Type;
		if (type != ChartType_Chart.Pie3D && type != ChartType_Chart.Pie3DExploded)
		{
			return;
		}
		foreach (Class844 item in class821_0.method_7())
		{
			if (item.method_11())
			{
				item.IsColorVaried = true;
			}
			class821_0.IsDataTableShown = false;
			class821_0.method_1().IsVisible = false;
			class821_0.method_1().method_11().Text = "";
			class821_0.method_9().IsVisible = false;
			class821_0.method_9().method_11().Text = "";
			class821_0.method_1().method_8().Formatting = Enum71.const_0;
			class821_0.method_1().method_9().Formatting = Enum71.const_0;
			class821_0.method_9().method_8().Formatting = Enum71.const_0;
			class821_0.method_9().method_9().Formatting = Enum71.const_0;
		}
		if (class821_0.Elevation < 1)
		{
			class821_0.Elevation = 1;
		}
		if (class821_0.Elevation > 90)
		{
			class821_0.Elevation = 90;
		}
	}

	internal static PointF[] smethod_2(Class821 class821_0)
	{
		PointF pointF = new PointF(class821_0.method_13().method_2(), class821_0.method_13().Y);
		int num = class821_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = class821_0.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = class821_0.method_13().Depth;
			num4 = class821_0.method_13().Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = class821_0.method_13().Width;
			num4 = class821_0.method_13().Depth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)class821_0.Elevation * Math.PI / 180.0);
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

	internal static PointF[] smethod_3(Class821 class821_0)
	{
		PointF pointF = new PointF(class821_0.method_13().method_2(), class821_0.method_13().Y);
		int num = class821_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = class821_0.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = class821_0.method_13().Depth;
			num4 = class821_0.method_13().Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = class821_0.method_13().Width;
			num4 = class821_0.method_13().Depth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)class821_0.Elevation * Math.PI / 180.0);
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

	internal static PointF smethod_4(Class821 class821_0)
	{
		PointF pointF = new PointF(class821_0.method_13().method_2(), class821_0.method_13().Y);
		int num = class821_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2 = class821_0.Rotation / 45;
		float num3;
		float num4;
		switch (num2)
		{
		default:
			num3 = class821_0.method_13().Depth;
			num4 = class821_0.method_13().Width;
			break;
		case 0:
		case 3:
		case 4:
		case 7:
		case 8:
			num3 = class821_0.method_13().Width;
			num4 = class821_0.method_13().Depth;
			break;
		}
		float num5 = num4 * (float)Math.Sin((double)num * Math.PI / 180.0);
		float num6 = num4 * (float)Math.Sin((double)class821_0.Elevation * Math.PI / 180.0);
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

	private static void smethod_5(Class821 class821_0, Interface42 interface42_0, Class823 class823_0)
	{
		if (!class821_0.method_8().method_16())
		{
			class823_0.method_11().method_2();
		}
	}

	private static int smethod_6(Class821 class821_0, Size size_0)
	{
		int num = class821_0.Rotation % 90;
		if (num >= 45)
		{
			num = 90 - num;
		}
		int num2;
		int num3;
		switch (class821_0.Rotation / 45)
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

	private static void smethod_7(Interface42 interface42_0, Class823 class823_0, Rectangle rectangle_0, ref Rectangle rectangle_1, bool bool_0)
	{
		bool flag = bool_0;
		Size empty = Size.Empty;
		Class821 chart = class823_0.Chart;
		if (class823_0.method_4() == Enum61.const_1)
		{
			bool_0 = !bool_0;
		}
		if (bool_0)
		{
			SizeF sizeF_ = new SizeF((float)rectangle_1.Width * 0.8f, (float)rectangle_1.Height * 0.8f);
			empty = class823_0.method_11().method_3(sizeF_);
			class823_0.method_11().method_0().rectangle_1.Size = empty;
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
					class823_0.method_11().method_0().rectangle_1.X = rectangle_1.Right - empty.Width;
					class823_0.method_11().method_0().rectangle_1.Y = rectangle_1.Y + (rectangle_1.Height - empty.Height) / 2;
					rectangle_1.Width -= empty.Width;
				}
			}
			Struct52.smethod_0(chart, rectangle_1, bool_0);
			return;
		}
		PointF[] array = smethod_2(chart);
		if (chart.Elevation == 0)
		{
			SizeF sizeF_2 = new SizeF((float)rectangle_1.Width * 0.8f, (float)rectangle_1.Height * 0.7f);
			empty = class823_0.method_11().method_3(sizeF_2);
			class823_0.method_11().method_0().rectangle_1.Size = empty;
			class823_0.method_11().method_0().rectangle_1.Y = rectangle_1.Bottom - empty.Height - int_2;
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
				SizeF sizeF_3 = new SizeF((float)rectangle_1.Width * 0.8f, (float)rectangle_1.Height * 0.7f);
				empty = class823_0.method_11().method_3(sizeF_3);
				class823_0.method_11().method_0().rectangle_1.Size = empty;
				int num4 = 0;
				if (flag)
				{
					class823_0.method_11().method_0().rectangle_1.Y = rectangle_1.Bottom - empty.Height - int_2;
				}
				else
				{
					class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Bottom - empty.Height - int_2 * 4;
				}
				num4 = rectangle_1.Bottom - (int)array[0].Y;
				if (num4 < empty.Height + int_2)
				{
					rectangle_1.Height -= empty.Height + int_2 - num4;
				}
			}
			else
			{
				SizeF sizeF_4 = new SizeF((float)rectangle_1.Width * 0.3f, (float)rectangle_1.Height * 0.3f);
				empty = class823_0.method_11().method_3(sizeF_4);
				class823_0.method_11().method_0().rectangle_1.Size = empty;
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
		}
		Struct52.smethod_0(chart, rectangle_1, bool_0);
	}

	private static void smethod_8(Interface42 interface42_0, Class823 class823_0, ref Rectangle rectangle_0)
	{
		if (Struct63.smethod_18(rectangle_0))
		{
			return;
		}
		Size empty = Size.Empty;
		Class821 chart = class823_0.Chart;
		PointF[] array = smethod_3(chart);
		if (chart.Elevation == 0)
		{
			SizeF sizeF_ = new SizeF((float)rectangle_0.Width * 0.8f, (float)rectangle_0.Height * 0.7f);
			empty = class823_0.method_11().method_3(sizeF_);
			class823_0.method_11().method_0().rectangle_1.Size = empty;
			class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Bottom - empty.Height - int_2;
			if (!chart.method_8().imethod_3() && chart.IsInnerMode)
			{
				int num = rectangle_0.Bottom - (int)array[0].Y;
				if (num < empty.Height + int_2)
				{
					rectangle_0.Height += empty.Height + int_2 - num;
				}
			}
			else
			{
				int num2 = rectangle_0.Bottom - (int)array[0].Y;
				if (num2 < empty.Height + int_2)
				{
					rectangle_0.Height -= empty.Height + int_2 - num2;
				}
			}
		}
		if (chart.Elevation > 0)
		{
			if (array[0].Y == array[1].Y)
			{
				SizeF sizeF_2 = new SizeF((float)rectangle_0.Width * 0.8f, (float)rectangle_0.Height * 0.7f);
				empty = class823_0.method_11().method_3(sizeF_2);
				class823_0.method_11().method_0().rectangle_1.Size = empty;
				int num3 = 0;
				class823_0.method_11().method_0().rectangle_1.Y = rectangle_0.Bottom - empty.Height - int_2;
				if (!chart.method_8().imethod_3() && chart.IsInnerMode)
				{
					num3 = rectangle_0.Bottom - (int)array[0].Y;
					if (num3 < empty.Height + int_2)
					{
						rectangle_0.Height += empty.Height + int_2 - num3;
					}
				}
				else
				{
					num3 = rectangle_0.Bottom - (int)array[0].Y;
					if (num3 < empty.Height + int_2)
					{
						rectangle_0.Height -= empty.Height + int_2 - num3;
					}
				}
			}
			else
			{
				SizeF sizeF_3 = new SizeF((float)rectangle_0.Width * 0.3f, (float)rectangle_0.Height * 0.3f);
				empty = class823_0.method_11().method_3(sizeF_3);
				class823_0.method_11().method_0().rectangle_1.Size = empty;
				switch (chart.Rotation / 45)
				{
				case 3:
				case 7:
					if ((int)Math.Abs(array[0].X + array[1].X) / 2 - rectangle_0.X < empty.Width)
					{
						int num5 = empty.Width - ((int)Math.Abs(array[0].X + array[1].X) / 2 - rectangle_0.X);
						if (!chart.method_8().imethod_3() && chart.IsInnerMode)
						{
							rectangle_0.X -= num5;
							rectangle_0.Width += num5;
						}
						else
						{
							rectangle_0.X += num5;
							rectangle_0.Width -= num5;
						}
					}
					break;
				case 0:
				case 4:
				case 8:
					if (rectangle_0.Right - (int)Math.Abs(array[0].X + array[1].X) / 2 < empty.Width)
					{
						int num4 = empty.Width - (rectangle_0.Right - (int)Math.Abs(array[0].X + array[1].X) / 2);
						if (!chart.method_8().imethod_3() && chart.IsInnerMode)
						{
							rectangle_0.Width += num4;
						}
						else
						{
							rectangle_0.Width -= num4;
						}
					}
					break;
				}
				if (rectangle_0.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2 < empty.Height)
				{
					if (!chart.method_8().imethod_3() && chart.IsInnerMode)
					{
						rectangle_0.Height += empty.Height + int_2 - (rectangle_0.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2);
					}
					else
					{
						rectangle_0.Height -= empty.Height + int_2 - (rectangle_0.Bottom - (int)Math.Abs(array[0].Y + array[1].Y) / 2);
					}
				}
			}
			if (chart.method_8().imethod_3() || !chart.IsInnerMode)
			{
				Struct52.smethod_0(chart, rectangle_0, bool_0: false);
			}
		}
		else
		{
			class823_0.method_11().Text = "";
		}
	}

	private static void smethod_9(Class823 class823_0, Rectangle rectangle_0, bool bool_0, Size size_0, Size size_1, int int_3)
	{
		bool flag = bool_0;
		Size empty = Size.Empty;
		Class821 chart = class823_0.Chart;
		if (class823_0.method_4() == Enum61.const_1)
		{
			empty = size_0;
			flag = !bool_0;
		}
		else
		{
			empty = size_1;
			if (class823_0.TickLabelPosition != Enum83.const_3)
			{
				empty.Width += int_3;
			}
		}
		if (flag)
		{
			Size size = class823_0.method_11().method_0().rectangle_1.Size;
			PointF pointF = smethod_4(chart);
			if (pointF.X < chart.method_13().method_2())
			{
				class823_0.method_11().method_0().rectangle_1.X = ((class823_0.TickLabelPosition == Enum83.const_3) ? ((int)(pointF.X - (float)size.Width)) : ((int)(pointF.X - (float)empty.Width - (float)size.Width)));
				class823_0.method_11().method_0().rectangle_1.Y = (int)(pointF.Y - chart.method_13().Height / 2f - (float)(size.Height / 2));
				return;
			}
			int num = (int)((float)rectangle_0.Right - pointF.X);
			if (num >= size.Width)
			{
				class823_0.method_11().method_0().rectangle_1.X = ((class823_0.TickLabelPosition == Enum83.const_3) ? ((int)pointF.X) : ((int)(pointF.X + (float)empty.Width)));
				class823_0.method_11().method_0().rectangle_1.Y = (int)(pointF.Y - chart.method_13().Height / 2f - (float)(size.Height / 2));
			}
			return;
		}
		PointF[] array = smethod_2(chart);
		if (array[0].Y == array[1].Y)
		{
			if (chart.Elevation >= 0)
			{
				class823_0.method_11().method_0().rectangle_1.X = (int)((array[0].X + array[1].X) / 2f - (float)(class823_0.method_11().method_0().rectangle_1.Width / 2));
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
			class823_0.method_11().method_0().rectangle_1.X = (int)(Math.Abs(array[0].X + array[1].X) / 2f - (float)class823_0.method_11().method_0().rectangle_1.Width - (float)smethod_6(chart, empty));
		}
		else
		{
			class823_0.method_11().method_0().rectangle_1.X = (int)(Math.Abs(array[0].X + array[1].X) / 2f + (float)smethod_6(chart, empty));
		}
		class823_0.method_11().method_0().rectangle_1.Y = (int)(Math.Abs(array[0].Y + array[1].Y) / 2f);
	}

	private static void smethod_10(Class821 class821_0)
	{
		Class823 @class = class821_0.method_11();
		ArrayList arrayList_ = class821_0.method_11().arrayList_1;
		IList list = class821_0.method_7().method_16();
		for (int i = 0; i < list.Count; i++)
		{
			Class844 class2 = (Class844)list[i];
			arrayList_.Add(class2.method_8());
		}
		@class.MinValue = 0.0;
		@class.MaxValue = list.Count;
		@class.MajorUnit = @class.TickMarkSpacing;
		@class.MinorUnit = @class.MajorUnit / 2.0;
	}

	private static void smethod_11(Class821 class821_0)
	{
		if (class821_0.Type == ChartType_Chart.Area3DStacked || class821_0.Type == ChartType_Chart.Area3D100PercentStacked)
		{
			class821_0.GapWidth = 20;
		}
	}
}
