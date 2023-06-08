using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class202 : Class160
{
	internal Class202(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		RectangleF rectangleF = new RectangleF(float_0, float_1, class913_0.method_8().Width, class913_0.method_8().Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		interface42_0.imethod_31(brush_, rectangleF);
		interface42_0.imethod_9(pen_, rectangleF);
		class913_0.Fill.method_2();
		interface42_0.imethod_32(brush_, class913_0.X + class913_0.method_8().Width * 0.3f + float_2, class913_0.Y + class913_0.method_8().Height * 0.3f + float_2, class913_0.method_8().Width * 0.1f, class913_0.method_8().Height * 0.1f);
		interface42_0.imethod_10(pen_, class913_0.X + class913_0.method_8().Width * 0.3f + float_2, class913_0.Y + class913_0.method_8().Height * 0.3f + float_2, class913_0.method_8().Width * 0.1f, class913_0.method_8().Height * 0.1f);
		interface42_0.imethod_32(brush_, class913_0.X + class913_0.method_8().Width * 0.6f + float_2, class913_0.Y + class913_0.method_8().Height * 0.3f + float_2, class913_0.method_8().Width * 0.1f, class913_0.method_8().Height * 0.1f);
		interface42_0.imethod_10(pen_, class913_0.X + class913_0.method_8().Width * 0.6f + float_2, class913_0.Y + class913_0.method_8().Height * 0.3f + float_2, class913_0.method_8().Width * 0.1f, class913_0.method_8().Height * 0.1f);
		float num = 2f * class913_0.method_8().Width / 9f;
		float num2 = 7f * class913_0.method_8().Height / 10f;
		float num3 = 5f * class913_0.method_8().Width / 9f;
		float num4 = 1f * class913_0.method_8().Height / 10f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		num5 = ((class913_0.class901_0 == null) ? (0.5f * num4) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (0.5f * num4) : (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 10000f * num4)));
		float num8 = Math.Abs(num5);
		if (num8 != 0f)
		{
			num6 = (16f * num8 * num8 + num3 * num3) / 16f / num8;
			num7 = Convert.ToSingle(180.0 * Math.Asin(num3 / 2f / num6) / Math.PI);
		}
		if (num5 < 0f)
		{
			interface42_0.imethod_5(pen_, num + num3 / 2f - num6 + float_2 + class913_0.X, num2 + num4 / 2f - num8 + float_2 + class913_0.Y, 2f * num6, 2f * num6, 270f - num7, 2f * num7);
		}
		else if (num5 > 0f)
		{
			interface42_0.imethod_5(pen_, num + num3 / 2f - num6 + float_2 + class913_0.X, num2 + num4 / 2f + num8 - 2f * num6 + float_2 + class913_0.Y, 2f * num6, 2f * num6, 90f - num7, 2f * num7);
		}
		else
		{
			interface42_0.imethod_16(pen_, num + float_2, num2 + num4 / 2f + float_2 + class913_0.Y, num + num3 + float_2 + class913_0.X, num2 + num4 / 2f + float_2 + class913_0.Y);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
