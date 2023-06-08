using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class70 : Class18
{
	internal Class70(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? (rectangleF_0.Width * 0.25444445f) : (rectangleF_0.Width * Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f));
		if (num <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		PointF[] array = new PointF[4];
		switch (class898_0.int_2)
		{
		case 1:
		{
			ref PointF reference13 = ref array[0];
			reference13 = new PointF(num + float_3, float_4);
			ref PointF reference14 = ref array[1];
			reference14 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference15 = ref array[2];
			reference15 = new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height + float_4);
			ref PointF reference16 = ref array[3];
			reference16 = new PointF(float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 2:
		{
			ref PointF reference9 = ref array[0];
			reference9 = new PointF(float_3, float_4);
			ref PointF reference10 = ref array[1];
			reference10 = new PointF(rectangleF_0.Width - num + float_3, float_4);
			ref PointF reference11 = ref array[2];
			reference11 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			ref PointF reference12 = ref array[3];
			reference12 = new PointF(num + float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 3:
		{
			ref PointF reference5 = ref array[0];
			reference5 = new PointF(num + float_3, float_4);
			ref PointF reference6 = ref array[1];
			reference6 = new PointF(rectangleF_0.Width + float_3, float_4);
			ref PointF reference7 = ref array[2];
			reference7 = new PointF(rectangleF_0.Width - num + float_3, rectangleF_0.Height + float_4);
			ref PointF reference8 = ref array[3];
			reference8 = new PointF(float_3, rectangleF_0.Height + float_4);
			break;
		}
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(float_3, float_4);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Width - num + float_3, float_4);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.Width + float_3, rectangleF_0.Height + float_4);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(num + float_3, rectangleF_0.Height + float_4);
			break;
		}
		}
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
		RectangleF rectangleF_ = class898_0.method_7();
		if (!class898_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class898_0.Line.Weight / 2f, 0f - class898_0.Line.Weight / 2f);
		}
		float num = class898_0.method_7().Width / 4f;
		float num2 = Struct69.smethod_12(class898_0.Font);
		if (class898_0.TextHorizontalAlignment != Enum104.const_7 && class898_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class898_0.TextHorizontalAlignment == Enum104.const_0 || class898_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num2 + num;
			}
		}
		else
		{
			rectangleF_.X += num2 + num;
		}
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin;
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
