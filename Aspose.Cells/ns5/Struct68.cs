using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using Aspose.Cells.Drawing;
using ns19;
using ns22;

namespace ns5;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct68
{
	internal static void smethod_0(Interface42 interface42_0, Class898 class898_0)
	{
		smethod_19(interface42_0, class898_0);
		RectangleF rectangleF_ = class898_0.method_22();
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		float num = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}

	internal static void smethod_1(Interface42 interface42_0, Class898 class898_0)
	{
		if (class898_0.Line.method_0())
		{
			return;
		}
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		double num = class898_0.Line.Weight;
		double num2 = 0.0;
		switch (class898_0.Line.method_2())
		{
		case Enum95.const_1:
		case Enum95.const_2:
			num2 = 0.0;
			break;
		case Enum95.const_3:
			num2 = 0.0;
			break;
		case Enum95.const_4:
			num2 = 0.0;
			break;
		case Enum95.const_5:
			num2 = num * 0.6000000238418579;
			break;
		}
		double num3 = 0.0;
		switch (class898_0.Line.method_8())
		{
		case Enum95.const_1:
		case Enum95.const_2:
			num3 = 0.0;
			break;
		case Enum95.const_3:
			num3 = 0.0;
			break;
		case Enum95.const_4:
			num3 = 0.0;
			break;
		case Enum95.const_5:
			num3 = num * 0.6000000238418579;
			break;
		}
		if (class898_0.Width == 0f)
		{
			PointF pointF = new PointF(class898_0.method_22().X, class898_0.method_22().Y);
			PointF pointF2 = new PointF(class898_0.method_22().X, class898_0.method_7().Bottom);
			if (class898_0.int_2 != 1 && class898_0.int_2 != 4)
			{
				pointF2.Y -= (float)num2;
				pointF.Y += (float)num3;
				interface42_0.imethod_15(pen_, pointF2, pointF);
			}
			else
			{
				pointF.Y += (float)num2;
				pointF2.Y -= (float)num3;
				interface42_0.imethod_15(pen_, pointF, pointF2);
			}
			return;
		}
		if (class898_0.Height == 0f)
		{
			PointF pointF = new PointF(class898_0.X, class898_0.Y);
			PointF pointF2 = new PointF(class898_0.X + class898_0.Width, class898_0.Y);
			if (class898_0.int_2 != 1 && class898_0.int_2 != 2)
			{
				pointF2.X -= (float)num2;
				pointF.X += (float)num3;
				interface42_0.imethod_15(pen_, pointF2, pointF);
			}
			else
			{
				pointF.X += (float)num2;
				pointF2.X -= (float)num3;
				interface42_0.imethod_15(pen_, pointF, pointF2);
			}
			return;
		}
		double num4 = Math.Sqrt(Math.Pow(class898_0.Width, 2.0) + Math.Pow(class898_0.Height, 2.0));
		double num5 = (double)class898_0.Width * num2 / num4;
		double num6 = (double)class898_0.Height * num2 / num4;
		double num7 = (double)class898_0.Width * num3 / num4;
		double num8 = (double)class898_0.Height * num3 / num4;
		PointF pointF3 = new PointF(class898_0.method_22().X, class898_0.method_22().Y);
		PointF pointF4 = new PointF(class898_0.method_22().X, class898_0.method_22().Y + class898_0.Height);
		PointF pointF5 = new PointF(class898_0.method_22().X + class898_0.Width, class898_0.method_22().Y + class898_0.Height);
		PointF pointF6 = new PointF(class898_0.method_22().X + class898_0.Width, class898_0.method_22().Y);
		if (class898_0.int_2 == 1)
		{
			pointF3.X += (float)num5;
			pointF3.Y += (float)num6;
			pointF5.X -= (float)num7;
			pointF5.Y -= (float)num8;
			interface42_0.imethod_15(pen_, pointF3, pointF5);
			class898_0.pointF_1 = pointF3;
			class898_0.pointF_2 = pointF5;
		}
		else if (class898_0.int_2 == 2)
		{
			pointF4.X += (float)num5;
			pointF4.Y -= (float)num6;
			pointF6.X -= (float)num7;
			pointF6.Y += (float)num8;
			interface42_0.imethod_15(pen_, pointF4, pointF6);
			class898_0.pointF_1 = pointF4;
			class898_0.pointF_2 = pointF6;
		}
		else if (class898_0.int_2 == 3)
		{
			pointF5.X -= (float)num5;
			pointF5.Y -= (float)num6;
			pointF3.X += (float)num7;
			pointF3.Y += (float)num8;
			interface42_0.imethod_15(pen_, pointF5, pointF3);
			class898_0.pointF_1 = pointF5;
			class898_0.pointF_2 = pointF3;
		}
		else
		{
			pointF6.X -= (float)num5;
			pointF6.Y += (float)num6;
			pointF4.X += (float)num7;
			pointF4.Y -= (float)num8;
			interface42_0.imethod_15(pen_, pointF6, pointF4);
			class898_0.pointF_1 = pointF6;
			class898_0.pointF_2 = pointF4;
		}
	}

	internal static void smethod_2(Interface42 interface42_0, Class898 class898_0)
	{
		smethod_19(interface42_0, class898_0);
		RectangleF rectangleF_ = class898_0.method_7();
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		float num = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num + 5f;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}

	internal static void smethod_3(Interface42 interface42_0, Class898 class898_0)
	{
		RectangleF rectangleF = class898_0.method_7();
		if (!class898_0.Fill.method_0())
		{
			Brush brush_ = Struct69.smethod_2(class898_0.Fill, class898_0.method_7());
			interface42_0.imethod_32(brush_, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		}
		if (!class898_0.Line.method_0())
		{
			class898_0.Line.method_3(Enum95.const_0);
			class898_0.Line.method_9(Enum95.const_0);
			Pen pen_ = Struct69.smethod_4(class898_0.Line);
			interface42_0.imethod_10(pen_, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		}
		RectangleF rectangleF_ = class898_0.method_7();
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		rectangleF_ = smethod_17(rectangleF_, class898_0.Font.Height);
		float num = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}

	internal static void smethod_4(Interface42 interface42_0, Class898 class898_0)
	{
		RectangleF rectangleF_ = class898_0.method_7();
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, Enum107.const_2, class898_0.Font, Color.Black, Enum104.const_7, Enum104.const_9);
	}

	internal static void smethod_5(Interface42 interface42_0, Class898 class898_0)
	{
		float num = 8f;
		float num2 = 8f;
		Pen pen_ = new Pen(Color.Black);
		SizeF sizeF = interface42_0.imethod_39(class898_0.Text, class898_0.Font);
		RectangleF rectangleF = new RectangleF(class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
		if (sizeF.Width + num + num2 > class898_0.Width)
		{
			sizeF.Width = class898_0.Width - num - num2;
		}
		else
		{
			num2 = class898_0.Width - num - sizeF.Width;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rectangleF.X, rectangleF.Y, rectangleF.X + num, rectangleF.Y);
		graphicsPath.AddLine(rectangleF.X, rectangleF.Y, rectangleF.X, rectangleF.Bottom - 1f);
		graphicsPath.AddLine(rectangleF.X, rectangleF.Bottom - 1f, rectangleF.Right, rectangleF.Bottom - 1f);
		graphicsPath.AddLine(rectangleF.Right, rectangleF.Bottom - 1f, rectangleF.Right, rectangleF.Y);
		graphicsPath.AddLine(rectangleF.Right, rectangleF.Y, rectangleF.Right - num2, rectangleF.Y);
		interface42_0.imethod_18(pen_, graphicsPath);
		interface42_0.imethod_25(rectangleF_0: new RectangleF(rectangleF.X + num, rectangleF.Y - sizeF.Height / 2f, sizeF.Width, sizeF.Height), string_0: class898_0.Text, font_0: class898_0.Font, brush_0: new SolidBrush(Color.Black));
	}

	internal static void smethod_6(Interface42 interface42_0, Class898 class898_0)
	{
		Color color = Color.FromKnownColor(KnownColor.Control);
		Color color2 = Color.FromKnownColor(KnownColor.ControlDark);
		Color white = Color.White;
		Color black = Color.Black;
		RectangleF rectangleF = class898_0.method_7();
		interface42_0.imethod_38(new SolidBrush(color), rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rectangleF.X + 1f, rectangleF.Bottom - 1f, rectangleF.Right - 1f, rectangleF.Bottom - 1f);
		graphicsPath.AddLine(rectangleF.Right - 1f, rectangleF.Y + 1f, rectangleF.Right - 1f, rectangleF.Bottom - 1f);
		interface42_0.imethod_18(new Pen(color2), graphicsPath);
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddLine(rectangleF.X, rectangleF.Y, rectangleF.Right, rectangleF.Y);
		graphicsPath2.AddLine(rectangleF.X, rectangleF.Y, rectangleF.X, rectangleF.Bottom);
		interface42_0.imethod_18(new Pen(white), graphicsPath2);
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath3.AddLine(rectangleF.X, rectangleF.Bottom, rectangleF.Right, rectangleF.Bottom);
		graphicsPath3.AddLine(rectangleF.Right, rectangleF.Y, rectangleF.Right, rectangleF.Bottom);
		interface42_0.imethod_18(new Pen(black), graphicsPath3);
		RectangleF rectangleF_ = interface42_0.imethod_50();
		interface42_0.imethod_48(class898_0.method_7());
		Struct69.smethod_6(interface42_0, class898_0, class898_0.method_7(), class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
		interface42_0.imethod_48(rectangleF_);
	}

	internal static void smethod_7(Interface42 interface42_0, Class898 class898_0)
	{
		RectangleF rectangleF = new RectangleF(class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
		smethod_19(interface42_0, class898_0);
		float num = 5f;
		float num2 = 10f;
		RectangleF rectangleF2 = new RectangleF(rectangleF.X + num, rectangleF.Y + (rectangleF.Height - num2) / 2f, num2, num2);
		if (class898_0.method_11() == Enum101.const_1)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(rectangleF2.X + 3f, rectangleF2.Y + 6f, rectangleF2.X + 5f, rectangleF2.Y + 8f);
			graphicsPath.AddLine(rectangleF2.X + 5f, rectangleF2.Y + 8f, rectangleF2.X + 7f, rectangleF2.Y + 4f);
			interface42_0.imethod_18(new Pen(Color.Black), graphicsPath);
		}
		else if (class898_0.method_11() == Enum101.const_2)
		{
			Brush brush_ = new HatchBrush(HatchStyle.Percent50, Color.Black, Color.White);
			interface42_0.imethod_38(brush_, rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height);
		}
		interface42_0.imethod_23(new Pen(Color.Black), rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height);
		SizeF sizeF = interface42_0.imethod_39(class898_0.Text, class898_0.Font);
		RectangleF rectangleF_ = new RectangleF(rectangleF2.Right + 1f, rectangleF.Y + (rectangleF.Height - sizeF.Height) / 2f, rectangleF.Right - rectangleF2.Right - 1f, sizeF.Height);
		RectangleF rectangleF_2 = interface42_0.imethod_50();
		interface42_0.imethod_48(rectangleF_);
		interface42_0.imethod_24(class898_0.Text, class898_0.Font, new SolidBrush(class898_0.FontColor), rectangleF_.Location);
		interface42_0.imethod_48(rectangleF_2);
	}

	internal static void smethod_8(Interface42 interface42_0, Class898 class898_0)
	{
		RectangleF rectangleF = new RectangleF(class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
		smethod_19(interface42_0, class898_0);
		float num = 5f;
		float num2 = 10f;
		RectangleF rectangleF2 = new RectangleF(rectangleF.X + num, rectangleF.Y + (rectangleF.Height - num2) / 2f, num2, num2);
		interface42_0.imethod_19(new Pen(Color.Black), rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height, 0f, 360f);
		Brush brush_ = new SolidBrush(Color.White);
		interface42_0.imethod_34(brush_, rectangleF2.X + 1f, rectangleF2.Y + 1f, rectangleF2.Width - 2f, rectangleF2.Height - 2f, -90f, 450f);
		if (class898_0.method_11() == Enum101.const_1)
		{
			interface42_0.imethod_34(new SolidBrush(Color.Black), rectangleF2.X + 2.5f, rectangleF2.Y + 2.5f, num2 / 2f, num2 / 2f, 0f, 360f);
		}
		SizeF sizeF = interface42_0.imethod_39(class898_0.Text, class898_0.Font);
		RectangleF rectangleF_ = new RectangleF(rectangleF2.Right + 1f, rectangleF.Y + (rectangleF.Height - sizeF.Height) / 2f, rectangleF.Right - rectangleF2.Right - 1f, sizeF.Height);
		RectangleF rectangleF_2 = interface42_0.imethod_50();
		interface42_0.imethod_48(rectangleF_);
		interface42_0.imethod_24(class898_0.Text, class898_0.Font, new SolidBrush(class898_0.FontColor), rectangleF_.Location);
		interface42_0.imethod_48(rectangleF_2);
	}

	internal static void smethod_9(Interface42 interface42_0, Class898 class898_0)
	{
		RectangleF rectangleF = class898_0.method_7();
		float num = 14f;
		RectangleF rectangleF2 = new RectangleF(rectangleF.X, rectangleF.Y, rectangleF.Width - num, rectangleF.Height);
		interface42_0.imethod_38(new SolidBrush(Color.White), rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rectangleF2.X, rectangleF2.Y, rectangleF2.Right, rectangleF2.Y);
		graphicsPath.AddLine(rectangleF2.X, rectangleF2.Y, rectangleF2.X, rectangleF2.Bottom);
		graphicsPath.AddLine(rectangleF2.X, rectangleF2.Bottom, rectangleF2.Right, rectangleF2.Bottom);
		interface42_0.imethod_18(new Pen(Color.Black), graphicsPath);
		float height = interface42_0.imethod_39("a", class898_0.Font).Height;
		float num2 = rectangleF.Y + 1f;
		int num3 = class898_0.method_14();
		while (class898_0.method_13() != null && num3 < class898_0.method_13().Count && !(num2 >= rectangleF.Bottom - 1f))
		{
			string string_ = Convert.ToString(class898_0.method_13()[num3]);
			RectangleF rectangleF_ = new RectangleF(rectangleF.X + 1f, num2, rectangleF2.Width - 2f, height);
			interface42_0.imethod_25(string_, class898_0.Font, new SolidBrush(class898_0.FontColor), rectangleF_);
			if (class898_0.method_15() != null)
			{
				foreach (object item in class898_0.method_15())
				{
					if (Convert.ToInt16(item) == num3)
					{
						interface42_0.imethod_23(new Pen(Color.Black), rectangleF_.X, rectangleF_.Y, rectangleF_.Width, rectangleF_.Height);
					}
				}
			}
			num2 += height;
			num3++;
		}
		int num4 = num3 - 1;
		RectangleF rectangleF3 = new RectangleF(rectangleF2.Right + 1f, rectangleF2.Y, num, rectangleF.Height);
		interface42_0.imethod_38(new SolidBrush(Color.FromArgb(212, 208, 200)), rectangleF3.X, rectangleF3.Y, rectangleF3.Width, rectangleF3.Height + 1f);
		RectangleF rectangleF4 = new RectangleF(rectangleF3.X, rectangleF3.Y, num, 11f);
		interface42_0.imethod_38(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rectangleF4.X, rectangleF4.Y, rectangleF4.Width, rectangleF4.Height);
		interface42_0.imethod_16(new Pen(Color.White), rectangleF4.X + 1f, rectangleF4.Y + 1f, rectangleF4.X + 1f, rectangleF4.Bottom - 1f);
		interface42_0.imethod_16(new Pen(Color.FromKnownColor(KnownColor.ControlDark)), rectangleF4.X + 1f, rectangleF4.Bottom, rectangleF4.Right - 2f, rectangleF4.Bottom);
		interface42_0.imethod_16(new Pen(Color.FromKnownColor(KnownColor.ControlDark)), rectangleF4.Right - 1f, rectangleF4.Y + 1f, rectangleF4.Right - 1f, rectangleF4.Bottom - 1f);
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddLine(rectangleF4.Right, rectangleF4.Y, rectangleF4.Right, rectangleF4.Bottom);
		graphicsPath2.AddLine(rectangleF4.Right - 1f, rectangleF4.Bottom, rectangleF4.Right, rectangleF4.Bottom);
		interface42_0.imethod_18(new Pen(Color.Black), graphicsPath2);
		interface42_0.imethod_38(new SolidBrush(Color.Black), rectangleF4.X + 5f, rectangleF4.Y + 5f, 2f, 2f);
		RectangleF rectangleF_2 = new RectangleF(rectangleF3.X, rectangleF3.Bottom - 11f, num, 11f);
		smethod_10(interface42_0, rectangleF_2);
		interface42_0.imethod_38(new SolidBrush(Color.Black), rectangleF_2.X + 5f, rectangleF_2.Y + 5f, 2f, 2f);
		if (class898_0.method_13() != null && num4 - class898_0.method_14() < class898_0.method_13().Count - 1)
		{
			float height2 = (float)((num4 + 1) / class898_0.method_13().Count) * (rectangleF.Height - rectangleF4.Height - rectangleF_2.Height);
			float num5 = (float)((class898_0.method_14() + 1) / class898_0.method_13().Count) * (rectangleF.Height - rectangleF4.Height - rectangleF_2.Height);
			RectangleF rectangleF_3 = new RectangleF(rectangleF3.X, rectangleF3.Y + rectangleF4.Height + num5, num, height2);
			smethod_10(interface42_0, rectangleF_3);
		}
	}

	private static void smethod_10(Interface42 interface42_0, RectangleF rectangleF_0)
	{
		interface42_0.imethod_38(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
		interface42_0.imethod_16(new Pen(Color.White), rectangleF_0.X + 1f, rectangleF_0.Y + 1f, rectangleF_0.X + 1f, rectangleF_0.Bottom - 1f);
		interface42_0.imethod_16(new Pen(Color.FromKnownColor(KnownColor.ControlDark)), rectangleF_0.X + 1f, rectangleF_0.Bottom, rectangleF_0.Right - 2f, rectangleF_0.Bottom);
		interface42_0.imethod_16(new Pen(Color.FromKnownColor(KnownColor.ControlDark)), rectangleF_0.Right - 1f, rectangleF_0.Y + 1f, rectangleF_0.Right - 1f, rectangleF_0.Bottom - 1f);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rectangleF_0.Right, rectangleF_0.Y, rectangleF_0.Right, rectangleF_0.Bottom);
		graphicsPath.AddLine(rectangleF_0.Right - 1f, rectangleF_0.Bottom, rectangleF_0.Right, rectangleF_0.Bottom);
		graphicsPath.AddLine(rectangleF_0.Right - 1f, rectangleF_0.Bottom, rectangleF_0.Right - 1f, rectangleF_0.Bottom + 1f);
		graphicsPath.AddLine(rectangleF_0.X, rectangleF_0.Bottom + 1f, rectangleF_0.Right - 1f, rectangleF_0.Bottom + 1f);
		interface42_0.imethod_18(new Pen(Color.Black), graphicsPath);
	}

	internal static void smethod_11(Interface42 interface42_0, Class898 class898_0)
	{
		RectangleF rectangleF = class898_0.method_7();
		interface42_0.imethod_38(new SolidBrush(Color.White), rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		float num = 0f;
		num = ((!(rectangleF.Width > rectangleF.Height)) ? rectangleF.Width : rectangleF.Height);
		if (rectangleF.Width > rectangleF.Height)
		{
			RectangleF rectangleF2 = new RectangleF(rectangleF.X, rectangleF.Y, rectangleF.Width - num, rectangleF.Height);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(rectangleF2.X, rectangleF2.Y, rectangleF2.Right, rectangleF2.Y);
			graphicsPath.AddLine(rectangleF2.X, rectangleF2.Y, rectangleF2.X, rectangleF2.Bottom);
			graphicsPath.AddLine(rectangleF2.X, rectangleF2.Bottom, rectangleF2.Right, rectangleF2.Bottom);
			interface42_0.imethod_18(new Pen(Color.Black), graphicsPath);
			if (class898_0.SelectedValue != null && class898_0.SelectedValue != "")
			{
				RectangleF rectangleF_ = new RectangleF(class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
				rectangleF_.X += 5f;
				Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.SelectedValue, class898_0.method_8(), class898_0.Font, class898_0.FontColor, Enum104.const_7, Enum104.const_1);
			}
		}
		RectangleF rectangleF3 = new RectangleF(rectangleF.Right - num, rectangleF.Y, num, rectangleF.Height);
		interface42_0.imethod_38(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rectangleF3.X, rectangleF3.Y, rectangleF3.Width, rectangleF3.Height);
		interface42_0.imethod_16(new Pen(Color.White), rectangleF3.X + 1f, rectangleF3.Y + 1f, rectangleF3.X + 1f, rectangleF3.Bottom - 2f);
		interface42_0.imethod_16(new Pen(Color.FromKnownColor(KnownColor.ControlDark)), rectangleF3.X + 1f, rectangleF3.Bottom - 1f, rectangleF3.Right - 1f, rectangleF3.Bottom - 1f);
		interface42_0.imethod_16(new Pen(Color.FromKnownColor(KnownColor.ControlDark)), rectangleF3.Right - 1f, rectangleF3.Y + 1f, rectangleF3.Right - 1f, rectangleF3.Bottom - 2f);
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddLine(rectangleF3.Right, rectangleF3.Y, rectangleF3.Right, rectangleF3.Bottom);
		graphicsPath2.AddLine(rectangleF3.Right, rectangleF3.Bottom, rectangleF3.X, rectangleF3.Bottom);
		interface42_0.imethod_18(new Pen(Color.Black), graphicsPath2);
		PointF pointF = new PointF(rectangleF3.X + 7f * rectangleF3.Width / 25f, rectangleF.Y + 10f * rectangleF3.Height / 25f);
		float num2 = 6f * num / 25f;
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath3.AddLine(pointF, new PointF(pointF.X + 2f * num2, pointF.Y));
		graphicsPath3.AddLine(new PointF(pointF.X + 2f * num2, pointF.Y), new PointF(pointF.X + num2, pointF.Y + num2));
		graphicsPath3.AddLine(new PointF(pointF.X + num2, pointF.Y + num2), pointF);
		interface42_0.imethod_33(new SolidBrush(Color.Black), graphicsPath3);
	}

	internal static void smethod_12(Interface42 interface42_0, Class898 class898_0)
	{
		smethod_19(interface42_0, class898_0);
		RectangleF rectangleF_ = class898_0.method_7();
		rectangleF_.Inflate(-3f, -1f);
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, Enum107.const_2, class898_0.Font, Color.Black, Enum104.const_7, Enum104.const_9);
		if (class898_0.pointF_1 != PointF.Empty)
		{
			RectangleF rectangleF = class898_0.method_7();
			PointF pointF = new PointF(rectangleF.X, rectangleF.Y);
			PointF pointF2 = new PointF(rectangleF.Right, rectangleF.Y);
			PointF pointF3 = new PointF(rectangleF.Right, rectangleF.Bottom);
			new PointF(rectangleF.X, rectangleF.Bottom);
			Pen pen = Struct69.smethod_4(class898_0.Line);
			pen.StartCap = LineCap.ArrowAnchor;
			interface42_0.imethod_15(pointF_1: (!(pointF.X <= class898_0.pointF_1.X)) ? pointF : ((!(pointF3.Y < class898_0.pointF_1.Y)) ? pointF2 : pointF3), pen_0: pen, pointF_0: class898_0.pointF_1);
		}
	}

	internal static void smethod_13(Interface42 interface42_0, Class898 class898_0)
	{
		RectangleF rectangleF_ = new RectangleF(class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
		if (!class898_0.Fill.method_0())
		{
			Brush brush_ = Struct69.smethod_2(class898_0.Fill, rectangleF_);
			interface42_0.imethod_37(brush_, rectangleF_);
		}
		Picture picture = (Picture)class898_0.shape_0;
		Image image = smethod_16(picture);
		if (image == null)
		{
			return;
		}
		MsoFormatPicture formatPicture = picture.FormatPicture;
		double leftCrop = formatPicture.LeftCrop;
		double rightCrop = formatPicture.RightCrop;
		double topCrop = formatPicture.TopCrop;
		double bottomCrop = formatPicture.BottomCrop;
		float float_ = (float)((double)image.Size.Width * leftCrop);
		float float_2 = (float)((double)image.Size.Height * topCrop);
		float float_3 = (float)((double)image.Size.Width * (1.0 - leftCrop - rightCrop));
		float float_4 = (float)((double)image.Size.Height * (1.0 - topCrop - bottomCrop));
		if (leftCrop + rightCrop + topCrop + bottomCrop != 0.0)
		{
			if (image != null)
			{
				interface42_0.imethod_13(image, new Rectangle((int)class898_0.X, (int)class898_0.Y, (int)class898_0.Width, (int)class898_0.Height), float_, float_2, float_3, float_4, GraphicsUnit.Pixel);
			}
		}
		else if (image != null)
		{
			if (!formatPicture.IsBiLevel && !formatPicture.IsGray)
			{
				interface42_0.imethod_12(image, class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
			}
			else
			{
				image = smethod_14(image, class898_0);
				interface42_0.imethod_12(image, class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
			}
		}
		image?.Dispose();
		if (!class898_0.Line.method_0())
		{
			Enum95 enum95_ = class898_0.Line.method_2();
			Enum95 enum95_2 = class898_0.Line.method_8();
			class898_0.Line.method_3(Enum95.const_0);
			class898_0.Line.method_9(Enum95.const_0);
			Pen pen_ = Struct69.smethod_4(class898_0.Line);
			rectangleF_.Inflate(class898_0.Line.Weight / 2f, class898_0.Line.Weight / 2f);
			interface42_0.imethod_23(pen_, rectangleF_.X, rectangleF_.Y, rectangleF_.Width, rectangleF_.Height);
			class898_0.Line.method_3(enum95_);
			class898_0.Line.method_9(enum95_2);
		}
	}

	private static Bitmap smethod_14(Image image_0, Class898 class898_0)
	{
		Bitmap bitmap = new Bitmap(image_0, (int)class898_0.Width, (int)class898_0.Height);
		float num = 0.8f;
		for (int num2 = bitmap.Width - 1; num2 >= 0; num2--)
		{
			for (int num3 = bitmap.Height - 1; num3 >= 0; num3--)
			{
				Color pixel = bitmap.GetPixel(num2, num3);
				int a = pixel.A;
				int num4 = pixel.R;
				int num5 = pixel.G;
				int num6 = pixel.B;
				if (a != 0)
				{
					if (num4 + num6 + num5 == 0)
					{
						num4 = 255;
						num5 = 255;
						num6 = 255;
					}
					int num7 = ((int)((float)num4 * num) + (int)((float)num6 * num) + (int)((float)num5 * num)) / 3;
					bitmap.SetPixel(num2, num3, Color.FromArgb(255, num7, num7, num7));
				}
			}
		}
		return bitmap;
	}

	internal static void smethod_15(Interface42 interface42_0, Class898 class898_0)
	{
		RectangleF rectangleF = new RectangleF(class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
		byte[] imageData = ((OleObject)class898_0.shape_0).ImageData;
		if (imageData != null)
		{
			Stream stream = new MemoryStream(imageData);
			if (stream != null && stream.Length != 0)
			{
				Image image = Image.FromStream(stream);
				interface42_0.imethod_12(image, class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
				image?.Dispose();
			}
			stream?.Close();
		}
		if (!class898_0.Line.method_0())
		{
			Enum95 enum95_ = class898_0.Line.method_2();
			Enum95 enum95_2 = class898_0.Line.method_8();
			class898_0.Line.method_3(Enum95.const_0);
			class898_0.Line.method_9(Enum95.const_0);
			Pen pen_ = Struct69.smethod_4(class898_0.Line);
			rectangleF.Inflate(class898_0.Line.Weight / 2f, class898_0.Line.Weight / 2f);
			interface42_0.imethod_23(pen_, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
			class898_0.Line.method_3(enum95_);
			class898_0.Line.method_9(enum95_2);
		}
	}

	internal static Image smethod_16(Picture picture_0)
	{
		if (picture_0 == null)
		{
			return null;
		}
		byte[] data = picture_0.Data;
		if (data != null && data.Length > 0)
		{
			Stream stream = new MemoryStream(data);
			return Image.FromStream(stream);
		}
		if (picture_0.method_74())
		{
			string sourceFullName = picture_0.SourceFullName;
			if (sourceFullName.IndexOf("http:") < 0)
			{
				if (File.Exists(sourceFullName))
				{
					return Image.FromFile(sourceFullName);
				}
				return null;
			}
			try
			{
				Stream stream2 = Class1186.smethod_8(sourceFullName);
				if (stream2 == null)
				{
					return null;
				}
				return Image.FromStream(stream2);
			}
			catch
			{
			}
		}
		return null;
	}

	private static RectangleF smethod_17(RectangleF rectangleF_0, int int_0)
	{
		float num = 0f;
		float num2 = 0f;
		bool flag = true;
		if (rectangleF_0.Width > rectangleF_0.Height)
		{
			flag = true;
			num = rectangleF_0.Height / 2f;
			num2 = rectangleF_0.Width / 2f;
		}
		else
		{
			flag = false;
			num = rectangleF_0.Width / 2f;
			num2 = rectangleF_0.Height / 2f;
		}
		RectangleF rectangleF = smethod_18(num, rectangleF_0.Location);
		RectangleF rectangleF2 = smethod_18(num2, rectangleF_0.Location);
		PointF location = default(PointF);
		SizeF size = default(SizeF);
		if (flag)
		{
			location.X = rectangleF2.Left;
			location.Y = rectangleF.Top;
			size.Width = rectangleF2.Width;
			size.Height = rectangleF.Height;
		}
		else
		{
			location.X = rectangleF.Left;
			location.Y = rectangleF2.Top;
			size.Width = rectangleF.Width;
			size.Height = rectangleF2.Height;
		}
		return new RectangleF(location, size);
	}

	private static RectangleF smethod_18(float float_0, PointF pointF_0)
	{
		float num = pointF_0.X + float_0;
		float num2 = pointF_0.Y + float_0;
		double num3 = Math.PI / 4.0;
		float x = (float)((double)num - (double)float_0 * Math.Cos(num3));
		float y = (float)((double)num2 - (double)float_0 * Math.Sin(num3));
		float num4 = (float)((double)(2f * float_0) * Math.Cos(num3));
		return new RectangleF(x, y, num4, num4);
	}

	private static void smethod_19(Interface42 interface42_0, Class898 class898_0)
	{
		if (!class898_0.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(class898_0.method_7());
			Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
			interface42_0.imethod_37(brush_, class898_0.method_7());
		}
		if (!class898_0.Line.method_0())
		{
			Enum95 enum95_ = class898_0.Line.method_2();
			Enum95 enum95_2 = class898_0.Line.method_8();
			class898_0.Line.method_3(Enum95.const_0);
			class898_0.Line.method_9(Enum95.const_0);
			Pen pen_ = Struct69.smethod_4(class898_0.Line);
			interface42_0.imethod_23(pen_, class898_0.X, class898_0.Y, class898_0.Width, class898_0.Height);
			class898_0.Line.method_3(enum95_);
			class898_0.Line.method_9(enum95_2);
		}
	}

	internal static void smethod_20(Interface42 interface42_0, Class898 class898_0)
	{
		Class136 @class = new Class136(interface42_0, class898_0.X, class898_0.Y, class898_0);
		if (class898_0.Line.Weight <= 1f)
		{
			@class.vmethod_3();
		}
		else
		{
			smethod_1(interface42_0, class898_0);
		}
	}

	internal static void smethod_21(Interface42 interface42_0, Class898 class898_0)
	{
		Class137 @class = new Class137(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_22(Interface42 interface42_0, Class898 class898_0)
	{
		Class138 @class = new Class138(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_23(Interface42 interface42_0, Class898 class898_0)
	{
		Class43 @class = new Class43(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_24(Interface42 interface42_0, Class898 class898_0)
	{
		Class44 @class = new Class44(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_25(Interface42 interface42_0, Class898 class898_0)
	{
		Class42 @class = new Class42(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_26(Interface42 interface42_0, Class898 class898_0)
	{
		Class46 @class = new Class46(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_27(Interface42 interface42_0, Class898 class898_0)
	{
		Class45 @class = new Class45(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_28(Interface42 interface42_0, Class898 class898_0)
	{
		Class47 @class = new Class47(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_29(Interface42 interface42_0, Class898 class898_0)
	{
		Class48 @class = new Class48(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_30(Interface42 interface42_0, Class898 class898_0)
	{
		Class97 @class = new Class97(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_31(Interface42 interface42_0, Class898 class898_0)
	{
		Class87 @class = new Class87(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_32(Interface42 interface42_0, Class898 class898_0)
	{
		Class89 @class = new Class89(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_33(Interface42 interface42_0, Class898 class898_0)
	{
		Class85 @class = new Class85(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_34(Interface42 interface42_0, Class898 class898_0)
	{
		Class100 @class = new Class100(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_35(Interface42 interface42_0, Class898 class898_0)
	{
		Class102 @class = new Class102(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_36(Interface42 interface42_0, Class898 class898_0)
	{
		Class95 @class = new Class95(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_37(Interface42 interface42_0, Class898 class898_0)
	{
		Class80 @class = new Class80(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_38(Interface42 interface42_0, Class898 class898_0)
	{
		Class91 @class = new Class91(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_39(Interface42 interface42_0, Class898 class898_0)
	{
		Class81 @class = new Class81(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_40(Interface42 interface42_0, Class898 class898_0)
	{
		Class92 @class = new Class92(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_41(Interface42 interface42_0, Class898 class898_0)
	{
		Class93 @class = new Class93(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_42(Interface42 interface42_0, Class898 class898_0)
	{
		Class82 @class = new Class82(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_43(Interface42 interface42_0, Class898 class898_0)
	{
		Class98 @class = new Class98(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_44(Interface42 interface42_0, Class898 class898_0)
	{
		Class96 @class = new Class96(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_45(Interface42 interface42_0, Class898 class898_0)
	{
		Class86 @class = new Class86(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_46(Interface42 interface42_0, Class898 class898_0)
	{
		Class99 @class = new Class99(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_47(Interface42 interface42_0, Class898 class898_0)
	{
		Class84 @class = new Class84(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_48(Interface42 interface42_0, Class898 class898_0)
	{
		Class88 @class = new Class88(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_49(Interface42 interface42_0, Class898 class898_0)
	{
		Class101 @class = new Class101(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_50(Interface42 interface42_0, Class898 class898_0)
	{
		Class94 @class = new Class94(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_51(Interface42 interface42_0, Class898 class898_0)
	{
		Class90 @class = new Class90(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_52(Interface42 interface42_0, Class898 class898_0)
	{
		Class129 @class = new Class129(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_53(Interface42 interface42_0, Class898 class898_0)
	{
		Class109 @class = new Class109(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_54(Interface42 interface42_0, Class898 class898_0)
	{
		Class110 @class = new Class110(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_55(Interface42 interface42_0, Class898 class898_0)
	{
		Class112 @class = new Class112(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_56(Interface42 interface42_0, Class898 class898_0)
	{
		Class114 @class = new Class114(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_57(Interface42 interface42_0, Class898 class898_0)
	{
		Class115 @class = new Class115(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_58(Interface42 interface42_0, Class898 class898_0)
	{
		Class116 @class = new Class116(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_59(Interface42 interface42_0, Class898 class898_0)
	{
		Class117 @class = new Class117(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_60(Interface42 interface42_0, Class898 class898_0)
	{
		Class119 @class = new Class119(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_61(Interface42 interface42_0, Class898 class898_0)
	{
		Class120 @class = new Class120(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_62(Interface42 interface42_0, Class898 class898_0)
	{
		Class121 @class = new Class121(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_63(Interface42 interface42_0, Class898 class898_0)
	{
		Class122 @class = new Class122(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_64(Interface42 interface42_0, Class898 class898_0)
	{
		Class123 @class = new Class123(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_65(Interface42 interface42_0, Class898 class898_0)
	{
		Class124 @class = new Class124(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_66(Interface42 interface42_0, Class898 class898_0)
	{
		Class125 @class = new Class125(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_67(Interface42 interface42_0, Class898 class898_0)
	{
		Class127 @class = new Class127(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_68(Interface42 interface42_0, Class898 class898_0)
	{
		Class130 @class = new Class130(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_69(Interface42 interface42_0, Class898 class898_0)
	{
		Class131 @class = new Class131(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_70(Interface42 interface42_0, Class898 class898_0)
	{
		Class132 @class = new Class132(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_71(Interface42 interface42_0, Class898 class898_0)
	{
		Class133 @class = new Class133(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_72(Interface42 interface42_0, Class898 class898_0)
	{
		Class135 @class = new Class135(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_73(Interface42 interface42_0, Class898 class898_0)
	{
		Class126 @class = new Class126(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_74(Interface42 interface42_0, Class898 class898_0)
	{
		Class134 @class = new Class134(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_75(Interface42 interface42_0, Class898 class898_0)
	{
		Class113 @class = new Class113(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_76(Interface42 interface42_0, Class898 class898_0)
	{
		Class108 @class = new Class108(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_77(Interface42 interface42_0, Class898 class898_0)
	{
		Class118 @class = new Class118(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_78(Interface42 interface42_0, Class898 class898_0)
	{
		Class128 @class = new Class128(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_79(Interface42 interface42_0, Class898 class898_0)
	{
		Class111 @class = new Class111(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_80(Interface42 interface42_0, Class898 class898_0)
	{
		Class20 @class = new Class20(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_81(Interface42 interface42_0, Class898 class898_0)
	{
		Class70 @class = new Class70(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_82(Interface42 interface42_0, Class898 class898_0)
	{
		Class78 @class = new Class78(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_83(Interface42 interface42_0, Class898 class898_0)
	{
		Class57 @class = new Class57(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_84(Interface42 interface42_0, Class898 class898_0)
	{
		Class75 @class = new Class75(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_85(Interface42 interface42_0, Class898 class898_0)
	{
		Class68 @class = new Class68(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_86(Interface42 interface42_0, Class898 class898_0)
	{
		Class79 @class = new Class79(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_87(Interface42 interface42_0, Class898 class898_0)
	{
		Class74 @class = new Class74(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_88(Interface42 interface42_0, Class898 class898_0)
	{
		Class69 @class = new Class69(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_89(Interface42 interface42_0, Class898 class898_0)
	{
		Class63 @class = new Class63(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_90(Interface42 interface42_0, Class898 class898_0)
	{
		Class55 @class = new Class55(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_91(Interface42 interface42_0, Class898 class898_0)
	{
		Class72 @class = new Class72(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_92(Interface42 interface42_0, Class898 class898_0)
	{
		Class54 @class = new Class54(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_93(Interface42 interface42_0, Class898 class898_0)
	{
		Class56 @class = new Class56(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_94(Interface42 interface42_0, Class898 class898_0)
	{
		Class52 @class = new Class52(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_95(Interface42 interface42_0, Class898 class898_0)
	{
		Class61 @class = new Class61(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_96(Interface42 interface42_0, Class898 class898_0)
	{
		Class76 @class = new Class76(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_97(Interface42 interface42_0, Class898 class898_0)
	{
		Class58 @class = new Class58(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_98(Interface42 interface42_0, Class898 class898_0)
	{
		Class65 @class = new Class65(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_99(Interface42 interface42_0, Class898 class898_0)
	{
		Class77 @class = new Class77(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_100(Interface42 interface42_0, Class898 class898_0)
	{
		Class71 @class = new Class71(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_101(Interface42 interface42_0, Class898 class898_0)
	{
		Class64 @class = new Class64(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_102(Interface42 interface42_0, Class898 class898_0)
	{
		Class73 @class = new Class73(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_103(Interface42 interface42_0, Class898 class898_0)
	{
		Class59 @class = new Class59(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_104(Interface42 interface42_0, Class898 class898_0)
	{
		Class51 @class = new Class51(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_105(Interface42 interface42_0, Class898 class898_0)
	{
		Class60 @class = new Class60(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_106(Interface42 interface42_0, Class898 class898_0)
	{
		Class150 @class = new Class150(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_107(Interface42 interface42_0, Class898 class898_0)
	{
		Class140 @class = new Class140(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_108(Interface42 interface42_0, Class898 class898_0)
	{
		Class53 @class = new Class53(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_109(Interface42 interface42_0, Class898 class898_0)
	{
		Class66 @class = new Class66(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_110(Interface42 interface42_0, Class898 class898_0)
	{
		Class62 @class = new Class62(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_111(Interface42 interface42_0, Class898 class898_0)
	{
		Class83 @class = new Class83(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_112(Interface42 interface42_0, Class898 class898_0)
	{
		Class24 @class = new Class24(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_113(Interface42 interface42_0, Class898 class898_0)
	{
		Class23 @class = new Class23(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_114(Interface42 interface42_0, Class898 class898_0)
	{
		Class25 @class = new Class25(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_115(Interface42 interface42_0, Class898 class898_0)
	{
		Class22 @class = new Class22(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_116(Interface42 interface42_0, Class898 class898_0)
	{
		Class67 @class = new Class67(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_117(Interface42 interface42_0, Class898 class898_0)
	{
		Class19 @class = new Class19(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_118(Interface42 interface42_0, Class898 class898_0)
	{
		Class21 @class = new Class21(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_119(Interface42 interface42_0, Class898 class898_0)
	{
		Class141 @class = new Class141(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_120(Interface42 interface42_0, Class898 class898_0)
	{
		Class142 @class = new Class142(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_121(Interface42 interface42_0, Class898 class898_0)
	{
		Class147 @class = new Class147(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_122(Interface42 interface42_0, Class898 class898_0)
	{
		Class148 @class = new Class148(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_123(Interface42 interface42_0, Class898 class898_0)
	{
		Class149 @class = new Class149(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_124(Interface42 interface42_0, Class898 class898_0)
	{
		Class144 @class = new Class144(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_125(Interface42 interface42_0, Class898 class898_0)
	{
		Class145 @class = new Class145(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_126(Interface42 interface42_0, Class898 class898_0)
	{
		Class146 @class = new Class146(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_127(Interface42 interface42_0, Class898 class898_0)
	{
		Class151 @class = new Class151(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_128(Interface42 interface42_0, Class898 class898_0)
	{
		Class143 @class = new Class143(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_129(Interface42 interface42_0, Class898 class898_0)
	{
		Class152 @class = new Class152(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_130(Interface42 interface42_0, Class898 class898_0)
	{
		Class139 @class = new Class139(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_131(Interface42 interface42_0, Class898 class898_0)
	{
		Class103 @class = new Class103(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_132(Interface42 interface42_0, Class898 class898_0)
	{
		Class49 @class = new Class49(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_133(Interface42 interface42_0, Class898 class898_0)
	{
		Class50 @class = new Class50(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_134(Interface42 interface42_0, Class898 class898_0)
	{
		Class105 @class = new Class105(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_135(Interface42 interface42_0, Class898 class898_0)
	{
		Class106 @class = new Class106(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_136(Interface42 interface42_0, Class898 class898_0)
	{
		Class107 @class = new Class107(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_137(Interface42 interface42_0, Class898 class898_0)
	{
		Class104 @class = new Class104(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_138(Interface42 interface42_0, Class898 class898_0)
	{
		Class26 @class = new Class26(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_139(Interface42 interface42_0, Class898 class898_0)
	{
		Class39 @class = new Class39(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_140(Interface42 interface42_0, Class898 class898_0)
	{
		Class40 @class = new Class40(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_141(Interface42 interface42_0, Class898 class898_0)
	{
		Class41 @class = new Class41(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_142(Interface42 interface42_0, Class898 class898_0)
	{
		Class27 @class = new Class27(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_143(Interface42 interface42_0, Class898 class898_0)
	{
		Class28 @class = new Class28(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_144(Interface42 interface42_0, Class898 class898_0)
	{
		Class29 @class = new Class29(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_145(Interface42 interface42_0, Class898 class898_0)
	{
		Class30 @class = new Class30(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_146(Interface42 interface42_0, Class898 class898_0)
	{
		Class35 @class = new Class35(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_147(Interface42 interface42_0, Class898 class898_0)
	{
		Class36 @class = new Class36(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_148(Interface42 interface42_0, Class898 class898_0)
	{
		Class37 @class = new Class37(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_149(Interface42 interface42_0, Class898 class898_0)
	{
		Class38 @class = new Class38(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_150(Interface42 interface42_0, Class898 class898_0)
	{
		Class31 @class = new Class31(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_151(Interface42 interface42_0, Class898 class898_0)
	{
		Class32 @class = new Class32(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_152(Interface42 interface42_0, Class898 class898_0)
	{
		Class33 @class = new Class33(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_153(Interface42 interface42_0, Class898 class898_0)
	{
		Class34 @class = new Class34(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}

	internal static void smethod_154(Interface42 interface42_0, Class898 class898_0)
	{
		Class153 @class = new Class153(interface42_0, class898_0.X, class898_0.Y, class898_0);
		@class.vmethod_3();
	}
}
