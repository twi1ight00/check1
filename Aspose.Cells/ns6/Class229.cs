using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class229 : Class160
{
	internal Class229(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		float num = float_3;
		float num2 = float_4;
		float width = class913_0.Width;
		float height = class913_0.Height;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = Math.Min(width, height);
		RectangleF rect = new RectangleF(num, num2, width, height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rect);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num3 = num5 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num4 = num5 * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
			}
			else
			{
				num3 = num5 * 0.5f;
				num4 = num5 * 0.5f;
			}
		}
		else
		{
			num3 = num5 * 0.5f;
			num4 = num5 * 0.5f;
		}
		float num6 = width - num4;
		float num7 = (height - num3) / 2f;
		float height2 = height - 2f * num7;
		float num8 = ((width > height) ? height : width);
		float width2 = 0.03333f * num8;
		float width3 = 0.06065f * num8;
		RectangleF rectangleF_ = new RectangleF(num, num2 + num7, width2, height2);
		RectangleF rectangleF_2 = new RectangleF(num + 0.06444f * num8, num2 + num7, width3, height2);
		PointF[] array = new PointF[7];
		GraphicsPath graphicsPath2 = new GraphicsPath();
		ref PointF reference = ref array[0];
		reference = new PointF(num + 0.15777f * num8, num2 + num7);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(num + num6, num2 + num7);
		ref PointF reference3 = ref array[2];
		reference3 = new PointF(num + num6, num2);
		ref PointF reference4 = ref array[3];
		reference4 = new PointF(num + width, num2 + height / 2f);
		ref PointF reference5 = ref array[4];
		reference5 = new PointF(num + num6, num2 + height);
		ref PointF reference6 = ref array[5];
		reference6 = new PointF(num + num6, num2 + height - num7);
		ref PointF reference7 = ref array[6];
		reference7 = new PointF(num + 0.15777f * num8, num2 + height - num7);
		graphicsPath2.AddPolygon(array);
		if (!class913_0.Fill.method_0())
		{
			interface42_0.imethod_37(brush_, rectangleF_);
			interface42_0.imethod_37(brush_, rectangleF_2);
			interface42_0.imethod_33(brush_, graphicsPath2);
		}
		if (!class913_0.Line.method_0())
		{
			interface42_0.imethod_23(pen_, num, num2 + num7, width2, height2);
			interface42_0.imethod_23(pen_, num + 0.06444f * num8, num2 + num7, width3, height2);
			interface42_0.imethod_18(pen_, graphicsPath2);
		}
		base.vmethod_4();
	}
}
