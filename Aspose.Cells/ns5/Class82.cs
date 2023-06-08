using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class82 : Class18
{
	internal Class82(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		float num = 0f;
		num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? (width - width * 0.7343981f) : (width - width * (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f)));
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[6];
		switch (class898_0.int_2)
		{
		case 1:
		case 2:
		{
			ref PointF reference7 = ref array[0];
			reference7 = new PointF(x, y);
			ref PointF reference8 = ref array[1];
			reference8 = new PointF(x + width - num, y);
			ref PointF reference9 = ref array[2];
			reference9 = new PointF(x + width, y + height / 2f);
			ref PointF reference10 = ref array[3];
			reference10 = new PointF(x + width - num, y + height);
			ref PointF reference11 = ref array[4];
			reference11 = new PointF(x, y + height);
			ref PointF reference12 = ref array[5];
			reference12 = new PointF(x + num, y + height / 2f);
			graphicsPath.AddPolygon(array);
			break;
		}
		case 3:
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x + width, y);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + num, y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x, y + height / 2f);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x + num, y + height);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(x + width, y + height);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(x + width - num, y + height / 2f);
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[4]);
			graphicsPath.AddLine(array[4], array[5]);
			graphicsPath.AddLine(array[5], array[0]);
			break;
		}
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
		float num = class898_0.method_7().Width / 9f;
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
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
