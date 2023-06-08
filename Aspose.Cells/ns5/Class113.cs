using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class113 : Class18
{
	internal Class113(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[4]
		{
			new PointF(rectangleF_0.Width / 2f + float_3, float_4),
			new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4),
			new PointF(rectangleF_0.Width / 2f + float_3, rectangleF_0.Height + float_4),
			new PointF(float_3, rectangleF_0.Height / 2f + float_4)
		};
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
		RectangleF rectangleF_ = new RectangleF(class898_0.method_7().X, class898_0.method_7().Y, class898_0.method_7().Width * 0.47f, class898_0.method_7().Height * 0.6f);
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
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin + 0.26f * class898_0.Width;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin + 0.2f * class898_0.Height;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
