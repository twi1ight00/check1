using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class179 : Class160
{
	internal Class179(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
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
		RectangleF rectangleF_ = new RectangleF(class913_0.method_25().X + class913_0.method_25().Width * 0.3f, class913_0.method_25().Y + class913_0.method_25().Height * 0.3f, class913_0.method_25().Width * 0.4f, class913_0.method_25().Height * 0.4f);
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		float num = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num;
			}
		}
		else
		{
			rectangleF_.X += num;
		}
		rectangleF_.X += (float)class913_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class913_0.TextFrame.TopMargin;
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
