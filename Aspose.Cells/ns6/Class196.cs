using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class196 : Class160
{
	internal Class196(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = ((class913_0.class901_0 == null) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.23958f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.23958f) : (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
		if (num <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		PointF[] array = new PointF[4];
		switch (class913_0.int_3)
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
		RectangleF rectangleF_ = class913_0.method_8();
		if (!class913_0.Line.method_0())
		{
			rectangleF_.Inflate(0f - class913_0.Line.Weight / 2f, 0f - class913_0.Line.Weight / 2f);
		}
		float num = class913_0.method_8().Width / 4f;
		float num2 = Struct72.smethod_9(class913_0.Font);
		if (class913_0.TextHorizontalAlignment != Enum104.const_7 && class913_0.TextHorizontalAlignment != Enum104.const_9)
		{
			if (class913_0.TextHorizontalAlignment == Enum104.const_0 || class913_0.TextHorizontalAlignment == Enum104.const_8)
			{
				rectangleF_.Width -= num2 + num;
			}
		}
		else
		{
			rectangleF_.X += num2 + num;
		}
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
