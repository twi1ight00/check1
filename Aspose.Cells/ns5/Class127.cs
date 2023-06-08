using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class127 : Class18
{
	internal Class127(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		RectangleF rectangleF = new RectangleF(num, num2, width, height);
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		if (!class898_0.Fill.method_0())
		{
			interface42_0.imethod_37(brush_, rectangleF);
		}
		if (!class898_0.Line.method_0())
		{
			interface42_0.imethod_23(pen_, num, num2, width, height);
			interface42_0.imethod_16(pen_, num + width / 8f, num2, num + width / 8f, num2 + height);
			interface42_0.imethod_16(pen_, num + 7f * width / 8f, num2, num + 7f * width / 8f, num2 + height);
		}
		vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
		RectangleF rectangleF_ = new RectangleF(class898_0.method_7().X, class898_0.method_7().Y, class898_0.method_7().Width * 3f / 4f, class898_0.method_7().Height);
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
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin + class898_0.Width / 8f;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
