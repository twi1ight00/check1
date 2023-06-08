using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;
using ns5;

namespace ns6;

internal class Class297 : Class160
{
	internal Class297(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		float num = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				if (width > height)
				{
					float num2 = Math.Min(width, height);
					num = num2 * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				}
				else
				{
					float num3 = Math.Max(width, height);
					num = num3 * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				}
			}
			else if (width > height)
			{
				float num4 = Math.Min(width, height);
				num = num4 * 38541f / 100000f;
			}
			else
			{
				float num5 = Math.Max(width, height);
				num = num5 * 38541f / 100000f;
			}
		}
		else if (width > height)
		{
			float num6 = Math.Min(width, height);
			num = num6 * 38541f / 100000f;
		}
		else
		{
			float num7 = Math.Max(width, height);
			num = num7 * 38541f / 100000f;
		}
		float num8 = rectangleF_0.Height / 2f - num;
		float num9 = height - 2f * num8;
		float num10 = num9 * width / height;
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[3];
		for (int i = 0; i < 12; i++)
		{
			ref PointF reference = ref array[0];
			reference = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0(i * 30)) * (double)width / 2.0), (int)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct70.smethod_0(i * 30))) * (double)height / 2.0));
			ref PointF reference2 = ref array[2];
			reference2 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0((i + 1) * 30)) * (double)width / 2.0), (int)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct70.smethod_0((i + 1) * 30))) * (double)height / 2.0));
			ref PointF reference3 = ref array[1];
			reference3 = new PointF((int)((double)(x + width / 2f) + Math.Cos(Struct70.smethod_0(15 + i * 30)) * (double)num10 / 2.0), (int)((double)(y + height / 2f) + (0.0 - Math.Sin(Struct70.smethod_0(15 + i * 30))) * (double)num9 / 2.0));
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
		}
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		RectangleF rectangleF_ = new RectangleF(class913_0.method_25().X + class913_0.method_25().Width * 0.26f, class913_0.method_25().Y + class913_0.method_25().Height * 0.27f, class913_0.method_25().Width * 0.48f, class913_0.method_25().Height * 0.48f);
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
