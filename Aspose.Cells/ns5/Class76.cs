using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class76 : Class18
{
	internal Class76(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		RectangleF rectangleF = new RectangleF(float_0, float_1, class898_0.method_7().Width, class898_0.method_7().Height);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rectangleF);
		Brush brush_ = Struct69.smethod_0(class898_0.Fill, graphicsPath);
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		interface42_0.imethod_31(brush_, rectangleF);
		interface42_0.imethod_9(Struct69.smethod_4(class898_0.Line), rectangleF);
		class898_0.Fill.method_2();
		GraphicsPath graphicsPath2 = new GraphicsPath();
		graphicsPath2.AddEllipse(class898_0.X + class898_0.method_7().Width * 0.3f + float_2, class898_0.Y + class898_0.method_7().Height * 0.3f + float_2, class898_0.method_7().Width * 0.1f, class898_0.method_7().Height * 0.1f);
		Brush brush = null;
		brush = ((!class898_0.Fill.method_5()) ? Struct69.smethod_3(class898_0.Fill, rectangleF, 0.8f, 0f) : Struct69.smethod_1(class898_0.Fill, graphicsPath2, 0.8f, 0f));
		interface42_0.imethod_32(brush, class898_0.X + class898_0.method_7().Width * 0.3f + float_2, class898_0.Y + class898_0.method_7().Height * 0.3f + float_2, class898_0.method_7().Width * 0.1f, class898_0.method_7().Height * 0.1f);
		interface42_0.imethod_10(pen_, class898_0.X + class898_0.method_7().Width * 0.3f + float_2, class898_0.Y + class898_0.method_7().Height * 0.3f + float_2, class898_0.method_7().Width * 0.1f, class898_0.method_7().Height * 0.1f);
		GraphicsPath graphicsPath3 = new GraphicsPath();
		graphicsPath3.AddEllipse(class898_0.X + class898_0.method_7().Width * 0.6f + float_2, class898_0.Y + class898_0.method_7().Height * 0.3f + float_2, class898_0.method_7().Width * 0.1f, class898_0.method_7().Height * 0.1f);
		Brush brush2 = null;
		brush2 = ((!class898_0.Fill.method_5()) ? Struct69.smethod_3(class898_0.Fill, rectangleF, 0.8f, 0f) : Struct69.smethod_1(class898_0.Fill, graphicsPath3, 0.8f, 0f));
		interface42_0.imethod_32(brush2, class898_0.X + class898_0.method_7().Width * 0.6f + float_2, class898_0.Y + class898_0.method_7().Height * 0.3f + float_2, class898_0.method_7().Width * 0.1f, class898_0.method_7().Height * 0.1f);
		interface42_0.imethod_10(pen_, class898_0.X + class898_0.method_7().Width * 0.6f + float_2, class898_0.Y + class898_0.method_7().Height * 0.3f + float_2, class898_0.method_7().Width * 0.1f, class898_0.method_7().Height * 0.1f);
		float num = 2f * class898_0.method_7().Width / 9f;
		float num2 = 7f * class898_0.method_7().Height / 10f;
		float num3 = 5f * class898_0.method_7().Width / 9f;
		float num4 = 1f * class898_0.method_7().Height / 10f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 0f;
		if (class898_0.class885_0.arrayList_0.Count > 0)
		{
			float num8 = Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value);
			num5 = ((num8 < 16473f) ? ((0f - (16473f - num8) / 1888f) * num4) : ((num8 != 16473f) ? ((num8 - 16473f) / 1888f * num4) : 0f));
		}
		else
		{
			num5 = 0.5f * num4;
		}
		float num9 = Math.Abs(num5);
		if (num9 != 0f)
		{
			num6 = (16f * num9 * num9 + num3 * num3) / 16f / num9;
			num7 = Convert.ToSingle(180.0 * Math.Asin(num3 / 2f / num6) / Math.PI);
		}
		if (num5 < 0f)
		{
			interface42_0.imethod_5(pen_, num + num3 / 2f - num6 + float_2 + class898_0.X, num2 + num4 / 2f - num9 + float_2 + class898_0.Y, 2f * num6, 2f * num6, 270f - num7, 2f * num7);
		}
		else if (num5 > 0f)
		{
			interface42_0.imethod_5(pen_, num + num3 / 2f - num6 + float_2 + class898_0.X, num2 + num4 / 2f + num9 - 2f * num6 + float_2 + class898_0.Y, 2f * num6, 2f * num6, 90f - num7, 2f * num7);
		}
		else
		{
			interface42_0.imethod_16(pen_, num + float_2, num2 + num4 / 2f + float_2 + class898_0.Y, num + num3 + float_2 + class898_0.X, num2 + num4 / 2f + float_2 + class898_0.Y);
		}
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
