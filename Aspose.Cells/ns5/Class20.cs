using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class20 : Class18
{
	internal Class20(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	private static void smethod_1(Interface42 interface42_1, Class898 class898_1)
	{
		if (!class898_1.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(class898_1.method_7());
			Brush brush_ = Struct69.smethod_0(class898_1.Fill, graphicsPath);
			interface42_1.imethod_37(brush_, class898_1.method_7());
		}
		if (!class898_1.Line.method_0())
		{
			Enum95 enum95_ = class898_1.Line.method_2();
			Enum95 enum95_2 = class898_1.Line.method_8();
			class898_1.Line.method_3(Enum95.const_0);
			class898_1.Line.method_9(Enum95.const_0);
			Pen pen_ = Struct69.smethod_4(class898_1.Line);
			interface42_1.imethod_23(pen_, class898_1.X, class898_1.Y, class898_1.Width, class898_1.Height);
			class898_1.Line.method_3(enum95_);
			class898_1.Line.method_9(enum95_2);
		}
	}

	internal override void vmethod_3()
	{
		smethod_1(interface42_0, class898_0);
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
}
