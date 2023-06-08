using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using Aspose.Cells.Drawing;
using ns19;
using ns5;

namespace ns6;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct Struct71
{
	internal static void smethod_0(Interface42 interface42_0, Class913 class913_0)
	{
		if (class913_0.Line.method_0())
		{
			return;
		}
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		double num = class913_0.Line.Weight;
		double num2 = 0.0;
		switch (class913_0.Line.method_2())
		{
		case Enum114.const_1:
		case Enum114.const_2:
			num2 = 0.0;
			break;
		case Enum114.const_3:
			num2 = 0.0;
			break;
		case Enum114.const_4:
			num2 = 0.0;
			break;
		case Enum114.const_5:
			num2 = num * 0.6000000238418579;
			break;
		}
		double num3 = 0.0;
		switch (class913_0.Line.method_8())
		{
		case Enum114.const_1:
		case Enum114.const_2:
			num3 = 0.0;
			break;
		case Enum114.const_3:
			num3 = 0.0;
			break;
		case Enum114.const_4:
			num3 = 0.0;
			break;
		case Enum114.const_5:
			num3 = num * 0.6000000238418579;
			break;
		}
		if (class913_0.Width == 0f)
		{
			PointF pointF = new PointF(class913_0.X, class913_0.Y);
			PointF pointF2 = new PointF(class913_0.X, class913_0.method_8().Bottom);
			if (class913_0.int_3 != 1 && class913_0.int_3 != 4)
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
		if (class913_0.Height == 0f)
		{
			PointF pointF = new PointF(class913_0.X, class913_0.Y);
			PointF pointF2 = new PointF(class913_0.X + class913_0.Width, class913_0.Y);
			if (class913_0.int_3 != 1 && class913_0.int_3 != 2)
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
		double num4 = Math.Sqrt(Math.Pow(class913_0.Width, 2.0) + Math.Pow(class913_0.Height, 2.0));
		double num5 = (double)class913_0.Width * num2 / num4;
		double num6 = (double)class913_0.Height * num2 / num4;
		double num7 = (double)class913_0.Width * num3 / num4;
		double num8 = (double)class913_0.Height * num3 / num4;
		PointF pointF3 = new PointF(class913_0.X, class913_0.Y);
		PointF pointF4 = new PointF(class913_0.X, class913_0.Y + class913_0.Height);
		PointF pointF5 = new PointF(class913_0.X + class913_0.Width, class913_0.Y + class913_0.Height);
		PointF pointF6 = new PointF(class913_0.X + class913_0.Width, class913_0.Y);
		if (class913_0.int_3 == 1)
		{
			pointF3.X += (float)num5;
			pointF3.Y += (float)num6;
			pointF5.X -= (float)num7;
			pointF5.Y -= (float)num8;
			interface42_0.imethod_15(pen_, pointF3, pointF5);
			class913_0.pointF_1 = pointF3;
			class913_0.pointF_2 = pointF5;
		}
		else if (class913_0.int_3 == 2)
		{
			pointF4.X += (float)num5;
			pointF4.Y -= (float)num6;
			pointF6.X -= (float)num7;
			pointF6.Y += (float)num8;
			interface42_0.imethod_15(pen_, pointF4, pointF6);
			class913_0.pointF_1 = pointF4;
			class913_0.pointF_2 = pointF6;
		}
		else if (class913_0.int_3 == 3)
		{
			pointF5.X -= (float)num5;
			pointF5.Y -= (float)num6;
			pointF3.X += (float)num7;
			pointF3.Y += (float)num8;
			interface42_0.imethod_15(pen_, pointF5, pointF3);
			class913_0.pointF_1 = pointF5;
			class913_0.pointF_2 = pointF3;
		}
		else
		{
			pointF6.X -= (float)num5;
			pointF6.Y += (float)num6;
			pointF4.X += (float)num7;
			pointF4.Y -= (float)num8;
			interface42_0.imethod_15(pen_, pointF6, pointF4);
			class913_0.pointF_1 = pointF6;
			class913_0.pointF_2 = pointF4;
		}
	}

	internal static void smethod_1(Interface42 interface42_0, Class913 class913_0)
	{
		RectangleF rectangleF = class913_0.method_8();
		if (!class913_0.Fill.method_0())
		{
			Brush brush_ = Struct72.smethod_20(class913_0.Fill, class913_0.method_8());
			interface42_0.imethod_32(brush_, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		}
		if (!class913_0.Line.method_0())
		{
			class913_0.Line.method_3(Enum114.const_0);
			class913_0.Line.method_9(Enum114.const_0);
			Pen pen_ = Struct72.smethod_0(class913_0.Line);
			interface42_0.imethod_10(pen_, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		}
		RectangleF rectangleF_ = class913_0.method_8();
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		rectangleF_ = smethod_13(rectangleF_);
		if (rectangleF_.Height < (float)class913_0.Font.Height)
		{
			float num = ((float)class913_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num, rectangleF_.Width, class913_0.Font.Height);
		}
		float num2 = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num2;
			}
		}
		else
		{
			rectangleF_.X += num2;
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}

	internal static void smethod_2(Interface42 interface42_0, Class913 class913_0)
	{
		RectangleF rectangleF_ = class913_0.method_8();
		if (rectangleF_.Height < (float)class913_0.Font.Height)
		{
			float num = ((float)class913_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num, rectangleF_.Width, class913_0.Font.Height);
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, Enum107.const_2, class913_0.Font, Color.Black, Enum104.const_7, Enum104.const_9);
	}

	internal static void smethod_3(Interface42 interface42_0, Class913 class913_0)
	{
		float num = 8f;
		float num2 = 8f;
		Pen pen_ = new Pen(Color.Black);
		SizeF sizeF = interface42_0.imethod_39(class913_0.Text, class913_0.Font);
		RectangleF rectangleF = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
		if (sizeF.Width + num + num2 > class913_0.Width)
		{
			sizeF.Width = class913_0.Width - num - num2;
		}
		else
		{
			num2 = class913_0.Width - num - sizeF.Width;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rectangleF.X, rectangleF.Y, rectangleF.X + num, rectangleF.Y);
		graphicsPath.AddLine(rectangleF.X, rectangleF.Y, rectangleF.X, rectangleF.Bottom - 1f);
		graphicsPath.AddLine(rectangleF.X, rectangleF.Bottom - 1f, rectangleF.Right, rectangleF.Bottom - 1f);
		graphicsPath.AddLine(rectangleF.Right, rectangleF.Bottom - 1f, rectangleF.Right, rectangleF.Y);
		graphicsPath.AddLine(rectangleF.Right, rectangleF.Y, rectangleF.Right - num2, rectangleF.Y);
		interface42_0.imethod_18(pen_, graphicsPath);
		interface42_0.imethod_25(rectangleF_0: new RectangleF(rectangleF.X + num, rectangleF.Y - sizeF.Height / 2f, sizeF.Width, sizeF.Height), string_0: class913_0.Text, font_0: class913_0.Font, brush_0: new SolidBrush(Color.Black));
	}

	internal static void smethod_4(Interface42 interface42_0, Class913 class913_0)
	{
		Color color = Color.FromKnownColor(KnownColor.Control);
		Color color2 = Color.FromKnownColor(KnownColor.ControlDark);
		Color white = Color.White;
		Color black = Color.Black;
		RectangleF rectangleF = class913_0.method_8();
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
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_48(class913_0.method_8());
		Struct72.smethod_3(interface42_0, class913_0, class913_0.method_8(), class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
		interface42_0.imethod_44(graphicsState_);
	}

	internal static void smethod_5(Interface42 interface42_0, Class913 class913_0)
	{
		RectangleF rectangleF = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
		smethod_15(interface42_0, class913_0);
		float num = 5f;
		float num2 = 10f;
		RectangleF rectangleF2 = new RectangleF(rectangleF.X + num, rectangleF.Y + (rectangleF.Height - num2) / 2f, num2, num2);
		if (class913_0.method_14() == Enum120.const_1)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddLine(rectangleF2.X + 3f, rectangleF2.Y + 6f, rectangleF2.X + 5f, rectangleF2.Y + 8f);
			graphicsPath.AddLine(rectangleF2.X + 5f, rectangleF2.Y + 8f, rectangleF2.X + 7f, rectangleF2.Y + 4f);
			interface42_0.imethod_18(new Pen(Color.Black), graphicsPath);
		}
		else if (class913_0.method_14() == Enum120.const_2)
		{
			Brush brush_ = new HatchBrush(HatchStyle.Percent50, Color.Black, Color.White);
			interface42_0.imethod_38(brush_, rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height);
		}
		interface42_0.imethod_23(new Pen(Color.Black), rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height);
		SizeF sizeF = interface42_0.imethod_39(class913_0.Text, class913_0.Font);
		RectangleF rectangleF_ = new RectangleF(rectangleF2.Right + 1f, rectangleF.Y + (rectangleF.Height - sizeF.Height) / 2f, rectangleF.Right - rectangleF2.Right - 1f, sizeF.Height);
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_48(rectangleF_);
		interface42_0.imethod_24(class913_0.Text, class913_0.Font, new SolidBrush(class913_0.FontColor), rectangleF_.Location);
		interface42_0.imethod_44(graphicsState_);
	}

	internal static void smethod_6(Interface42 interface42_0, Class913 class913_0)
	{
		RectangleF rectangleF = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
		smethod_15(interface42_0, class913_0);
		float num = 5f;
		float num2 = 10f;
		RectangleF rectangleF2 = new RectangleF(rectangleF.X + num, rectangleF.Y + (rectangleF.Height - num2) / 2f, num2, num2);
		interface42_0.imethod_19(new Pen(Color.Black), rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height, 0f, 360f);
		Brush brush_ = new SolidBrush(Color.White);
		interface42_0.imethod_34(brush_, rectangleF2.X + 1f, rectangleF2.Y + 1f, rectangleF2.Width - 2f, rectangleF2.Height - 2f, -90f, 450f);
		if (class913_0.method_14() == Enum120.const_1)
		{
			interface42_0.imethod_34(new SolidBrush(Color.Black), rectangleF2.X + 2.5f, rectangleF2.Y + 2.5f, num2 / 2f, num2 / 2f, 0f, 360f);
		}
		SizeF sizeF = interface42_0.imethod_39(class913_0.Text, class913_0.Font);
		RectangleF rectangleF_ = new RectangleF(rectangleF2.Right + 1f, rectangleF.Y + (rectangleF.Height - sizeF.Height) / 2f, rectangleF.Right - rectangleF2.Right - 1f, sizeF.Height);
		GraphicsState graphicsState_ = interface42_0.Save();
		interface42_0.imethod_50();
		interface42_0.imethod_48(rectangleF_);
		interface42_0.imethod_24(class913_0.Text, class913_0.Font, new SolidBrush(class913_0.FontColor), rectangleF_.Location);
		interface42_0.imethod_44(graphicsState_);
	}

	internal static void smethod_7(Interface42 interface42_0, Class913 class913_0)
	{
		RectangleF rectangleF = class913_0.method_8();
		float num = 14f;
		RectangleF rectangleF2 = new RectangleF(rectangleF.X, rectangleF.Y, rectangleF.Width - num, rectangleF.Height);
		interface42_0.imethod_38(new SolidBrush(Color.White), rectangleF2.X, rectangleF2.Y, rectangleF2.Width, rectangleF2.Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(rectangleF2.X, rectangleF2.Y, rectangleF2.Right, rectangleF2.Y);
		graphicsPath.AddLine(rectangleF2.X, rectangleF2.Y, rectangleF2.X, rectangleF2.Bottom);
		graphicsPath.AddLine(rectangleF2.X, rectangleF2.Bottom, rectangleF2.Right, rectangleF2.Bottom);
		interface42_0.imethod_18(new Pen(Color.Black), graphicsPath);
		float height = interface42_0.imethod_39("a", class913_0.Font).Height;
		float num2 = rectangleF.Y + 1f;
		int num3 = class913_0.method_17();
		while (class913_0.method_16() != null && num3 < class913_0.method_16().Count && !(num2 >= rectangleF.Bottom - 1f))
		{
			string string_ = Convert.ToString(class913_0.method_16()[num3]);
			RectangleF rectangleF_ = new RectangleF(rectangleF.X + 1f, num2, rectangleF2.Width - 2f, height);
			interface42_0.imethod_25(string_, class913_0.Font, new SolidBrush(class913_0.FontColor), rectangleF_);
			if (class913_0.method_18() != null)
			{
				foreach (object item in class913_0.method_18())
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
		smethod_16(interface42_0, rectangleF_2);
		interface42_0.imethod_38(new SolidBrush(Color.Black), rectangleF_2.X + 5f, rectangleF_2.Y + 5f, 2f, 2f);
		if (class913_0.method_16() != null && num4 - class913_0.method_17() < class913_0.method_16().Count - 1)
		{
			float height2 = (float)((num4 + 1) / class913_0.method_16().Count) * (rectangleF.Height - rectangleF4.Height - rectangleF_2.Height);
			float num5 = (float)((class913_0.method_17() + 1) / class913_0.method_16().Count) * (rectangleF.Height - rectangleF4.Height - rectangleF_2.Height);
			RectangleF rectangleF_3 = new RectangleF(rectangleF3.X, rectangleF3.Y + rectangleF4.Height + num5, num, height2);
			smethod_16(interface42_0, rectangleF_3);
		}
	}

	internal static void smethod_8(Interface42 interface42_0, Class913 class913_0)
	{
		RectangleF rectangleF = class913_0.method_8();
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
			if (class913_0.SelectedValue != null && class913_0.SelectedValue != "")
			{
				RectangleF rectangleF_ = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
				rectangleF_.X += 5f;
				Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.SelectedValue, class913_0.method_9(), class913_0.Font, class913_0.FontColor, Enum104.const_7, Enum104.const_1);
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

	internal static void smethod_9(Interface42 interface42_0, Class913 class913_0)
	{
		smethod_15(interface42_0, class913_0);
		RectangleF rectangleF_ = class913_0.method_8();
		rectangleF_.Inflate(-3f, -1f);
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, Enum107.const_2, class913_0.Font, Color.Black, Enum104.const_7, Enum104.const_9);
		if (class913_0.pointF_1 != PointF.Empty)
		{
			RectangleF rectangleF = class913_0.method_8();
			PointF pointF = new PointF(rectangleF.X, rectangleF.Y);
			PointF pointF2 = new PointF(rectangleF.Right, rectangleF.Y);
			PointF pointF3 = new PointF(rectangleF.Right, rectangleF.Bottom);
			new PointF(rectangleF.X, rectangleF.Bottom);
			Pen pen = Struct72.smethod_0(class913_0.Line);
			pen.StartCap = LineCap.ArrowAnchor;
			interface42_0.imethod_15(pointF_1: (!(pointF.X <= class913_0.pointF_1.X)) ? pointF : ((!(pointF3.Y < class913_0.pointF_1.Y)) ? pointF2 : pointF3), pen_0: pen, pointF_0: class913_0.pointF_1);
		}
	}

	internal static void smethod_10(Interface42 interface42_0, Class913 class913_0)
	{
		RectangleF rectangleF_ = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
		if (!class913_0.Fill.method_0())
		{
			Brush brush_ = Struct72.smethod_20(class913_0.Fill, rectangleF_);
			interface42_0.imethod_37(brush_, rectangleF_);
		}
		Picture picture_ = (Picture)class913_0.shape_0;
		Image image = smethod_12(picture_);
		if (image == null)
		{
			return;
		}
		if (image != null)
		{
			double leftCrop = class913_0.shape_0.FormatPicture.LeftCrop;
			double rightCrop = class913_0.shape_0.FormatPicture.RightCrop;
			double topCrop = class913_0.shape_0.FormatPicture.TopCrop;
			double bottomCrop = class913_0.shape_0.FormatPicture.BottomCrop;
			float num = (float)((double)image.Size.Width * leftCrop);
			float num2 = (float)((double)image.Size.Height * topCrop);
			float num3 = (float)((double)image.Size.Width * (1.0 - leftCrop - rightCrop));
			float num4 = (float)((double)image.Size.Height * (1.0 - topCrop - bottomCrop));
			RectangleF rectangleF_2 = new RectangleF(num - 0.5f, num2 - 0.5f, num3 + 1f, num4 + 1f);
			if (leftCrop + rightCrop + topCrop + bottomCrop != 0.0)
			{
				interface42_0.imethod_14(image, rectangleF_, rectangleF_2, GraphicsUnit.Pixel);
			}
			else
			{
				interface42_0.imethod_12(image, class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
			}
		}
		image?.Dispose();
		if (!class913_0.Line.method_0())
		{
			Enum114 enum114_ = class913_0.Line.method_2();
			Enum114 enum114_2 = class913_0.Line.method_8();
			class913_0.Line.method_3(Enum114.const_0);
			class913_0.Line.method_9(Enum114.const_0);
			Pen pen_ = Struct72.smethod_0(class913_0.Line);
			rectangleF_.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
			interface42_0.imethod_23(pen_, rectangleF_.X, rectangleF_.Y, rectangleF_.Width, rectangleF_.Height);
			class913_0.Line.method_3(enum114_);
			class913_0.Line.method_9(enum114_2);
		}
	}

	internal static void smethod_11(Interface42 interface42_0, Class913 class913_0)
	{
		RectangleF rectangleF = new RectangleF(class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
		byte[] imageData = ((OleObject)class913_0.shape_0).ImageData;
		if (imageData != null)
		{
			Stream stream = new MemoryStream(imageData);
			if (stream != null && stream.Length != 0)
			{
				Image image = Image.FromStream(stream);
				interface42_0.imethod_12(image, class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
				image?.Dispose();
			}
			stream?.Close();
		}
		if (!class913_0.Line.method_0())
		{
			Enum114 enum114_ = class913_0.Line.method_2();
			Enum114 enum114_2 = class913_0.Line.method_8();
			class913_0.Line.method_3(Enum114.const_0);
			class913_0.Line.method_9(Enum114.const_0);
			Pen pen_ = Struct72.smethod_0(class913_0.Line);
			rectangleF.Inflate(class913_0.Line.Weight / 2f, class913_0.Line.Weight / 2f);
			interface42_0.imethod_23(pen_, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
			class913_0.Line.method_3(enum114_);
			class913_0.Line.method_9(enum114_2);
		}
	}

	internal static Image smethod_12(Picture picture_0)
	{
		if (picture_0 == null)
		{
			return null;
		}
		if (picture_0.Data != null)
		{
			Stream stream = new MemoryStream(picture_0.Data);
			if (stream != null && stream.Length != 0)
			{
				return Image.FromStream(stream);
			}
			return null;
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
				Stream stream2 = new WebClient().OpenRead(sourceFullName);
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

	private static RectangleF smethod_13(RectangleF rectangleF_0)
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
		RectangleF rectangleF = smethod_14(num, rectangleF_0.Location);
		RectangleF rectangleF2 = smethod_14(num2, rectangleF_0.Location);
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

	private static RectangleF smethod_14(float float_0, PointF pointF_0)
	{
		float num = pointF_0.X + float_0;
		float num2 = pointF_0.Y + float_0;
		double num3 = Math.PI / 4.0;
		float x = (float)((double)num - (double)float_0 * Math.Cos(num3));
		float y = (float)((double)num2 - (double)float_0 * Math.Sin(num3));
		float num4 = (float)((double)(2f * float_0) * Math.Cos(num3));
		return new RectangleF(x, y, num4, num4);
	}

	private static void smethod_15(Interface42 interface42_0, Class913 class913_0)
	{
		if (!class913_0.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(class913_0.method_8());
			Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
			interface42_0.imethod_37(brush_, class913_0.method_8());
		}
		if (!class913_0.Line.method_0())
		{
			Enum114 enum114_ = class913_0.Line.method_2();
			Enum114 enum114_2 = class913_0.Line.method_8();
			class913_0.Line.method_3(Enum114.const_0);
			class913_0.Line.method_9(Enum114.const_0);
			Pen pen_ = Struct72.smethod_0(class913_0.Line);
			if (class913_0.Line.Weight <= 1f)
			{
				interface42_0.imethod_23(pen_, class913_0.method_25().X, class913_0.method_25().Y, class913_0.Width, class913_0.Height);
			}
			else
			{
				interface42_0.imethod_23(pen_, class913_0.X, class913_0.Y, class913_0.Width, class913_0.Height);
			}
			class913_0.Line.method_3(enum114_);
			class913_0.Line.method_9(enum114_2);
		}
	}

	private static void smethod_16(Interface42 interface42_0, RectangleF rectangleF_0)
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

	internal static void smethod_17(Interface42 interface42_0, Class913 class913_0)
	{
		Class161 @class = new Class161(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_18(Interface42 interface42_0, Class913 class913_0)
	{
		Class162 @class = new Class162(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_19(Interface42 interface42_0, Class913 class913_0)
	{
		Class202 @class = new Class202(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_20(Interface42 interface42_0, Class913 class913_0)
	{
		Class285 @class = new Class285(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_21(Interface42 interface42_0, Class913 class913_0)
	{
		Class283 @class = new Class283(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_22(Interface42 interface42_0, Class913 class913_0)
	{
		Class206 @class = new Class206(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_23(Interface42 interface42_0, Class913 class913_0)
	{
		Class201 @class = new Class201(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_24(Interface42 interface42_0, Class913 class913_0)
	{
		Class196 @class = new Class196(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_25(Interface42 interface42_0, Class913 class913_0)
	{
		Class205 @class = new Class205(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_26(Interface42 interface42_0, Class913 class913_0)
	{
		Class179 @class = new Class179(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_27(Interface42 interface42_0, Class913 class913_0)
	{
		Class199 @class = new Class199(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_28(Interface42 interface42_0, Class913 class913_0)
	{
		Class189 @class = new Class189(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_29(Interface42 interface42_0, Class913 class913_0)
	{
		Class195 @class = new Class195(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_30(Interface42 interface42_0, Class913 class913_0)
	{
		Class290 @class = new Class290(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_31(Interface42 interface42_0, Class913 class913_0)
	{
		Class288 @class = new Class288(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_32(Interface42 interface42_0, Class913 class913_0)
	{
		Class289 @class = new Class289(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_33(Interface42 interface42_0, Class913 class913_0)
	{
		Class287 @class = new Class287(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_34(Interface42 interface42_0, Class913 class913_0)
	{
		Class286 @class = new Class286(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_35(Interface42 interface42_0, Class913 class913_0)
	{
		Class284 @class = new Class284(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_36(Interface42 interface42_0, Class913 class913_0)
	{
		Class279 @class = new Class279(interface42_0, class913_0.X, class913_0.Y, class913_0);
		if (class913_0.Line.Weight <= 1f)
		{
			@class.vmethod_3();
		}
		else
		{
			smethod_0(interface42_0, class913_0);
		}
	}

	internal static void smethod_37(Interface42 interface42_0, Class913 class913_0)
	{
		Class248 @class = new Class248(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_38(Interface42 interface42_0, Class913 class913_0)
	{
		Class247 @class = new Class247(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_39(Interface42 interface42_0, Class913 class913_0)
	{
		Class228 @class = new Class228(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_40(Interface42 interface42_0, Class913 class913_0)
	{
		Class218 @class = new Class218(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_41(Interface42 interface42_0, Class913 class913_0)
	{
		Class231 @class = new Class231(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_42(Interface42 interface42_0, Class913 class913_0)
	{
		Class216 @class = new Class216(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_43(Interface42 interface42_0, Class913 class913_0)
	{
		Class220 @class = new Class220(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_44(Interface42 interface42_0, Class913 class913_0)
	{
		Class232 @class = new Class232(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_45(Interface42 interface42_0, Class913 class913_0)
	{
		Class176 @class = new Class176(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_46(Interface42 interface42_0, Class913 class913_0)
	{
		Class172 @class = new Class172(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_47(Interface42 interface42_0, Class913 class913_0)
	{
		Class271 @class = new Class271(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_48(Interface42 interface42_0, Class913 class913_0)
	{
		Class175 @class = new Class175(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_49(Interface42 interface42_0, Class913 class913_0)
	{
		Class178 @class = new Class178(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_50(Interface42 interface42_0, Class913 class913_0)
	{
		Class185 @class = new Class185(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_51(Interface42 interface42_0, Class913 class913_0)
	{
		Class198 @class = new Class198(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_52(Interface42 interface42_0, Class913 class913_0)
	{
		Class169 @class = new Class169(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_53(Interface42 interface42_0, Class913 class913_0)
	{
		Class192 @class = new Class192(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_54(Interface42 interface42_0, Class913 class913_0)
	{
		Class186 @class = new Class186(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_55(Interface42 interface42_0, Class913 class913_0)
	{
		Class281 @class = new Class281(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_56(Interface42 interface42_0, Class913 class913_0)
	{
		Class163 @class = new Class163(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_57(Interface42 interface42_0, Class913 class913_0)
	{
		Class164 @class = new Class164(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_58(Interface42 interface42_0, Class913 class913_0)
	{
		Class165 @class = new Class165(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_59(Interface42 interface42_0, Class913 class913_0)
	{
		Class183 @class = new Class183(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_60(Interface42 interface42_0, Class913 class913_0)
	{
		Class182 @class = new Class182(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_61(Interface42 interface42_0, Class913 class913_0)
	{
		Class277 @class = new Class277(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_62(Interface42 interface42_0, Class913 class913_0)
	{
		Class275 @class = new Class275(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_63(Interface42 interface42_0, Class913 class913_0)
	{
		Class276 @class = new Class276(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_64(Interface42 interface42_0, Class913 class913_0)
	{
		Class274 @class = new Class274(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_65(Interface42 interface42_0, Class913 class913_0)
	{
		Class273 @class = new Class273(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_66(Interface42 interface42_0, Class913 class913_0)
	{
		Class190 @class = new Class190(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_67(Interface42 interface42_0, Class913 class913_0)
	{
		Class200 @class = new Class200(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_68(Interface42 interface42_0, Class913 class913_0)
	{
		Class188 @class = new Class188(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_69(Interface42 interface42_0, Class913 class913_0)
	{
		Class177 @class = new Class177(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_70(Interface42 interface42_0, Class913 class913_0)
	{
		Class180 @class = new Class180(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_71(Interface42 interface42_0, Class913 class913_0)
	{
		Class197 @class = new Class197(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_72(Interface42 interface42_0, Class913 class913_0)
	{
		Class173 @class = new Class173(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_73(Interface42 interface42_0, Class913 class913_0)
	{
		Class204 @class = new Class204(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_74(Interface42 interface42_0, Class913 class913_0)
	{
		Class187 @class = new Class187(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_75(Interface42 interface42_0, Class913 class913_0)
	{
		Class191 @class = new Class191(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_76(Interface42 interface42_0, Class913 class913_0)
	{
		Class170 @class = new Class170(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_77(Interface42 interface42_0, Class913 class913_0)
	{
		Class181 @class = new Class181(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_78(Interface42 interface42_0, Class913 class913_0)
	{
		Class171 @class = new Class171(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_79(Interface42 interface42_0, Class913 class913_0)
	{
		Class184 @class = new Class184(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_80(Interface42 interface42_0, Class913 class913_0)
	{
		Class265 @class = new Class265(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_81(Interface42 interface42_0, Class913 class913_0)
	{
		Class264 @class = new Class264(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_82(Interface42 interface42_0, Class913 class913_0)
	{
		Class257 @class = new Class257(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_83(Interface42 interface42_0, Class913 class913_0)
	{
		Class270 @class = new Class270(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_84(Interface42 interface42_0, Class913 class913_0)
	{
		Class259 @class = new Class259(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_85(Interface42 interface42_0, Class913 class913_0)
	{
		Class260 @class = new Class260(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_86(Interface42 interface42_0, Class913 class913_0)
	{
		Class263 @class = new Class263(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_87(Interface42 interface42_0, Class913 class913_0)
	{
		Class250 @class = new Class250(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_88(Interface42 interface42_0, Class913 class913_0)
	{
		Class266 @class = new Class266(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_89(Interface42 interface42_0, Class913 class913_0)
	{
		Class272 @class = new Class272(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_90(Interface42 interface42_0, Class913 class913_0)
	{
		Class251 @class = new Class251(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_91(Interface42 interface42_0, Class913 class913_0)
	{
		Class268 @class = new Class268(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_92(Interface42 interface42_0, Class913 class913_0)
	{
		Class261 @class = new Class261(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_93(Interface42 interface42_0, Class913 class913_0)
	{
		Class269 @class = new Class269(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_94(Interface42 interface42_0, Class913 class913_0)
	{
		Class253 @class = new Class253(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_95(Interface42 interface42_0, Class913 class913_0)
	{
		Class267 @class = new Class267(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_96(Interface42 interface42_0, Class913 class913_0)
	{
		Class258 @class = new Class258(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_97(Interface42 interface42_0, Class913 class913_0)
	{
		Class254 @class = new Class254(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_98(Interface42 interface42_0, Class913 class913_0)
	{
		Class255 @class = new Class255(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_99(Interface42 interface42_0, Class913 class913_0)
	{
		Class294 @class = new Class294(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_100(Interface42 interface42_0, Class913 class913_0)
	{
		Class293 @class = new Class293(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_101(Interface42 interface42_0, Class913 class913_0)
	{
		Class226 @class = new Class226(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_102(Interface42 interface42_0, Class913 class913_0)
	{
		Class174 @class = new Class174(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_103(Interface42 interface42_0, Class913 class913_0)
	{
		Class203 @class = new Class203(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_104(Interface42 interface42_0, Class913 class913_0)
	{
		Class221 @class = new Class221(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_105(Interface42 interface42_0, Class913 class913_0)
	{
		Class208 @class = new Class208(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_106(Interface42 interface42_0, Class913 class913_0)
	{
		Class233 @class = new Class233(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_107(Interface42 interface42_0, Class913 class913_0)
	{
		Class222 @class = new Class222(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_108(Interface42 interface42_0, Class913 class913_0)
	{
		Class209 @class = new Class209(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_109(Interface42 interface42_0, Class913 class913_0)
	{
		Class213 @class = new Class213(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_110(Interface42 interface42_0, Class913 class913_0)
	{
		Class223 @class = new Class223(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_111(Interface42 interface42_0, Class913 class913_0)
	{
		Class224 @class = new Class224(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_112(Interface42 interface42_0, Class913 class913_0)
	{
		Class210 @class = new Class210(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_113(Interface42 interface42_0, Class913 class913_0)
	{
		Class227 @class = new Class227(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_114(Interface42 interface42_0, Class913 class913_0)
	{
		Class215 @class = new Class215(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_115(Interface42 interface42_0, Class913 class913_0)
	{
		Class193 @class = new Class193(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_116(Interface42 interface42_0, Class913 class913_0)
	{
		Class301 @class = new Class301(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_117(Interface42 interface42_0, Class913 class913_0)
	{
		Class302 @class = new Class302(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_118(Interface42 interface42_0, Class913 class913_0)
	{
		Class303 @class = new Class303(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_119(Interface42 interface42_0, Class913 class913_0)
	{
		Class304 @class = new Class304(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_120(Interface42 interface42_0, Class913 class913_0)
	{
		Class305 @class = new Class305(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_121(Interface42 interface42_0, Class913 class913_0)
	{
		Class296 @class = new Class296(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_122(Interface42 interface42_0, Class913 class913_0)
	{
		Class297 @class = new Class297(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_123(Interface42 interface42_0, Class913 class913_0)
	{
		Class298 @class = new Class298(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_124(Interface42 interface42_0, Class913 class913_0)
	{
		Class299 @class = new Class299(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_125(Interface42 interface42_0, Class913 class913_0)
	{
		Class300 @class = new Class300(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_126(Interface42 interface42_0, Class913 class913_0)
	{
		Class249 @class = new Class249(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_127(Interface42 interface42_0, Class913 class913_0)
	{
		Class256 @class = new Class256(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_128(Interface42 interface42_0, Class913 class913_0)
	{
		Class262 @class = new Class262(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_129(Interface42 interface42_0, Class913 class913_0)
	{
		Class252 @class = new Class252(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_130(Interface42 interface42_0, Class913 class913_0)
	{
		Class194 @class = new Class194(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_131(Interface42 interface42_0, Class913 class913_0)
	{
		Class278 @class = new Class278(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_132(Interface42 interface42_0, Class913 class913_0)
	{
		Class217 @class = new Class217(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_133(Interface42 interface42_0, Class913 class913_0)
	{
		Class230 @class = new Class230(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_134(Interface42 interface42_0, Class913 class913_0)
	{
		Class219 @class = new Class219(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_135(Interface42 interface42_0, Class913 class913_0)
	{
		Class225 @class = new Class225(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_136(Interface42 interface42_0, Class913 class913_0)
	{
		Class229 @class = new Class229(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_137(Interface42 interface42_0, Class913 class913_0)
	{
		Class244 @class = new Class244(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_138(Interface42 interface42_0, Class913 class913_0)
	{
		Class241 @class = new Class241(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_139(Interface42 interface42_0, Class913 class913_0)
	{
		Class245 @class = new Class245(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_140(Interface42 interface42_0, Class913 class913_0)
	{
		Class242 @class = new Class242(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_141(Interface42 interface42_0, Class913 class913_0)
	{
		Class246 @class = new Class246(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_142(Interface42 interface42_0, Class913 class913_0)
	{
		Class243 @class = new Class243(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_143(Interface42 interface42_0, Class913 class913_0)
	{
		Class234 @class = new Class234(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_144(Interface42 interface42_0, Class913 class913_0)
	{
		Class237 @class = new Class237(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_145(Interface42 interface42_0, Class913 class913_0)
	{
		Class235 @class = new Class235(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_146(Interface42 interface42_0, Class913 class913_0)
	{
		Class238 @class = new Class238(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_147(Interface42 interface42_0, Class913 class913_0)
	{
		Class236 @class = new Class236(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_148(Interface42 interface42_0, Class913 class913_0)
	{
		Class239 @class = new Class239(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_149(Interface42 interface42_0, Class913 class913_0)
	{
		Class240 @class = new Class240(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_150(Interface42 interface42_0, Class913 class913_0)
	{
		Class307 @class = new Class307(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_151(Interface42 interface42_0, Class913 class913_0)
	{
		Class295 @class = new Class295(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_152(Interface42 interface42_0, Class913 class913_0)
	{
		Class306 @class = new Class306(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_153(Interface42 interface42_0, Class913 class913_0)
	{
		Class292 @class = new Class292(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_154(Interface42 interface42_0, Class913 class913_0)
	{
		Class308 @class = new Class308(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_155(Interface42 interface42_0, Class913 class913_0)
	{
		Class291 @class = new Class291(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_156(Interface42 interface42_0, Class913 class913_0)
	{
		Class280 @class = new Class280(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_157(Interface42 interface42_0, Class913 class913_0)
	{
		Class214 @class = new Class214(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_158(Interface42 interface42_0, Class913 class913_0)
	{
		Class211 @class = new Class211(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_159(Interface42 interface42_0, Class913 class913_0)
	{
		Class212 @class = new Class212(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_160(Interface42 interface42_0, Class913 class913_0)
	{
		Class282 @class = new Class282(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_161(Interface42 interface42_0, Class913 class913_0)
	{
		Class167 @class = new Class167(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_162(Interface42 interface42_0, Class913 class913_0)
	{
		Class168 @class = new Class168(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_163(Interface42 interface42_0, Class913 class913_0)
	{
		Class207 @class = new Class207(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}

	internal static void smethod_164(Interface42 interface42_0, Class913 class913_0)
	{
		Class166 @class = new Class166(interface42_0, class913_0.X, class913_0.Y, class913_0);
		@class.vmethod_3();
	}
}
