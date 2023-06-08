using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class189 : Class160
{
	private float float_5;

	internal Class189(Interface42 interface42_1, float float_6, float float_7, Class913 class913_1)
		: base(interface42_1, float_6, float_7, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				float_5 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
			}
			else
			{
				float_5 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24f;
			}
		}
		else
		{
			float_5 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.24f;
		}
		if (float_5 <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		PointF[] array = new PointF[6]
		{
			new PointF(float_5 + float_3, float_4),
			new PointF(rectangleF_0.Width - float_5 + float_3, float_4),
			new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height / 2f + float_4),
			new PointF(rectangleF_0.Width - float_5 + float_3, rectangleF_0.Height + float_4),
			new PointF(float_5 + float_3, rectangleF_0.Height + float_4),
			new PointF(float_3, rectangleF_0.Height / 2f + float_4)
		};
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[5]);
		graphicsPath.AddLine(array[5], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		RectangleF rectangleF_ = class913_0.method_8();
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
		rectangleF_.X += (float)class913_0.TextFrame.LeftMargin + float_5;
		rectangleF_.Y += (float)class913_0.TextFrame.TopMargin;
		rectangleF_.Width -= float_5 * 2f;
		if (rectangleF_.Height < (float)class913_0.Font.Height)
		{
			float num2 = ((float)class913_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class913_0.Font.Height);
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
