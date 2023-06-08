using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class149 : Class18
{
	private float float_5;

	internal Class149(Interface42 interface42_1, float float_6, float float_7, Class898 class898_1)
		: base(interface42_1, float_6, float_7, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			float_5 = height / 2f * (1f - Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 10800f);
		}
		else
		{
			float_5 = height / 2f * 0.7364815f;
		}
		float num = rectangleF_0.Height / 2f - float_5;
		float num2 = height - 2f * num;
		float num3 = num2 * width / height;
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[3];
		for (int i = 0; i < 8; i++)
		{
			ref PointF reference = ref array[0];
			reference = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(i * 45)) * (double)width / 2.0), (int)((double)(y + height / 2f) - Math.Sin(Struct67.smethod_0(i * 45)) * (double)height / 2.0));
			ref PointF reference2 = ref array[2];
			reference2 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0((i + 1) * 45)) * (double)width / 2.0), (int)((double)(y + height / 2f) - Math.Sin(Struct67.smethod_0((i + 1) * 45)) * (double)height / 2.0));
			ref PointF reference3 = ref array[1];
			reference3 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct67.smethod_0(22.5 + (double)(i * 45))) * (double)num3 / 2.0), (int)((double)(y + height / 2f) - Math.Sin(Struct67.smethod_0(22.5 + (double)(i * 45))) * (double)num2 / 2.0));
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
		}
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		interface42_0.ResetTransform();
		RectangleF rectangleF_ = class898_0.method_7();
		rectangleF_.Width -= float_5;
		rectangleF_.Height -= float_5;
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
		rectangleF_.X += (float)class898_0.TextFrame.LeftMargin + float_5 / 2f;
		rectangleF_.Y += (float)class898_0.TextFrame.TopMargin + float_5 / 2f;
		if (rectangleF_.Height < (float)class898_0.Font.Height)
		{
			float num2 = ((float)class898_0.Font.Height - rectangleF_.Height) / 2f;
			rectangleF_ = new RectangleF(rectangleF_.X, rectangleF_.Y - num2, rectangleF_.Width, class898_0.Font.Height);
		}
		Struct69.smethod_6(interface42_0, class898_0, rectangleF_, class898_0.Text, class898_0.method_8(), class898_0.Font, class898_0.FontColor, class898_0.TextHorizontalAlignment, class898_0.TextVerticalAlignment);
	}
}
