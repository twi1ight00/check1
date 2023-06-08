using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class130 : Class18
{
	internal Class130(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		GraphicsPath graphicsPath = new GraphicsPath();
		switch (class898_0.int_2)
		{
		case 1:
		case 3:
			graphicsPath.AddArc(x, y, 0.5f * width, 0.2f * height, 180f, -180f);
			graphicsPath.AddArc(x + 0.5f * width, y, 0.5f * width, 0.2f * height, 180f, 180f);
			graphicsPath.AddLine(x + width, y + 0.1f * height, x + width, y + 0.9f * height);
			graphicsPath.AddArc(x + 0.5f * width, y + 0.8f * height, 0.5f * width, 0.2f * height, 0f, -180f);
			graphicsPath.AddArc(x, y + 0.8f * height, 0.5f * width, 0.2f * height, 0f, 180f);
			graphicsPath.AddLine(x, y + 0.9f * height, x, y + 0.1f * height);
			break;
		case 2:
		case 4:
			graphicsPath.AddArc(x, y, 0.5f * width, 0.2f * height, 180f, 180f);
			graphicsPath.AddArc(x + rectangleF_0.Width * 0.5f, y, 0.5f * width, 0.2f * height, 180f, -180f);
			graphicsPath.AddLine(x + width, y + 0.1f * height, x + width, y + 0.9f * height);
			graphicsPath.AddArc(x + rectangleF_0.Width * 0.5f, y + 0.8f * height, 0.5f * width, 0.2f * height, 0f, 180f);
			graphicsPath.AddArc(x, y + 0.8f * height, 0.5f * width, 0.2f * height, 0f, -180f);
			graphicsPath.AddLine(x, y + 0.9f * height, x, y + 0.1f * height);
			break;
		}
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
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
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin + 0.2f * class898_0.Height;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
