using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class161 : Class160
{
	internal Class161(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	private void method_3(Interface42 interface42_1, Class913 class913_1)
	{
		if (!class913_1.Fill.method_0())
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(class913_1.method_8());
			Brush brush_ = Struct72.smethod_21(class913_1.Fill, graphicsPath);
			interface42_1.imethod_37(brush_, class913_1.method_8());
		}
		if (!class913_1.Line.method_0())
		{
			Enum114 enum114_ = class913_1.Line.method_2();
			Enum114 enum114_2 = class913_1.Line.method_8();
			class913_1.Line.method_3(Enum114.const_0);
			class913_1.Line.method_9(Enum114.const_0);
			Pen pen_ = Struct72.smethod_0(class913_1.Line);
			if (class913_1.Line.Weight <= 1f)
			{
				interface42_1.imethod_23(pen_, class913_1.method_25().X, class913_1.method_25().Y, class913_1.Width, class913_1.Height);
			}
			else
			{
				interface42_1.imethod_23(pen_, class913_1.X, class913_1.Y, class913_1.Width, class913_1.Height);
			}
			class913_1.Line.method_3(enum114_);
			class913_1.Line.method_9(enum114_2);
		}
	}

	internal override void vmethod_3()
	{
		method_3(interface42_0, class913_0);
		RectangleF rectangleF_ = class913_0.method_8();
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
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
		rectangleF_.X += (float)class913_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class913_0.TextFrame.TopMargin;
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
