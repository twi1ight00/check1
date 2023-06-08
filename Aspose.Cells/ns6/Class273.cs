using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class273 : Class160
{
	internal Class273(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override void vmethod_3()
	{
		SmoothingMode smoothingMode_ = interface42_0.imethod_54();
		interface42_0.imethod_55(SmoothingMode.AntiAlias);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 1f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Math.Min(class913_0.Width, class913_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				num2 = Math.Min(class913_0.Width, class913_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f * num4;
				num3 = Math.Min(class913_0.Width, class913_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
			}
			else
			{
				num = Math.Min(class913_0.Width, class913_0.Height) * 23520f / 100000f;
				num2 = Math.Min(class913_0.Width, class913_0.Height) * 2930f / 100000f;
				num3 = Math.Min(class913_0.Width, class913_0.Height) * 11760f / 100000f;
			}
		}
		else
		{
			num = Math.Min(class913_0.Width, class913_0.Height) * 23520f / 100000f;
			num2 = Math.Min(class913_0.Width, class913_0.Height) * 2930f / 100000f;
			num3 = Math.Min(class913_0.Width, class913_0.Height) * 11760f / 100000f;
		}
		float num5 = 2f * num3;
		float num6 = num;
		float num7 = num2;
		float num8 = num3;
		RectangleF rectangleF = new RectangleF(float_3 + 0.135f * class913_0.method_8().Width, float_4 + (class913_0.method_8().Height - num6) / 2f, 0.73f * class913_0.method_8().Width, num6);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddRectangle(rectangleF);
		Brush brush_ = Struct72.smethod_21(class913_0.Fill, graphicsPath);
		Pen pen_ = Struct72.smethod_0(class913_0.Line);
		interface42_0.imethod_37(brush_, rectangleF);
		interface42_0.imethod_23(pen_, float_3 + 0.135f * class913_0.method_8().Width, float_4 + (class913_0.method_8().Height - num6) / 2f, 0.73f * class913_0.method_8().Width, num6);
		interface42_0.imethod_32(brush_, float_3 + class913_0.method_8().Width / 2f - num8, float_4 + (class913_0.method_8().Height - (num6 + num5 * 2f + num7 * 2f)) / 2f, num5, num5);
		interface42_0.imethod_10(pen_, float_3 + class913_0.method_8().Width / 2f - num8, float_4 + (class913_0.method_8().Height - (num6 + num5 * 2f + num7 * 2f)) / 2f, num5, num5);
		interface42_0.imethod_32(brush_, float_3 + class913_0.method_8().Width / 2f - num8, float_4 + class913_0.method_8().Height - num5 - (class913_0.method_8().Height - (num6 + num5 * 2f + num7 * 2f)) / 2f, num5, num5);
		interface42_0.imethod_10(pen_, float_3 + class913_0.method_8().Width / 2f - num8, float_4 + class913_0.method_8().Height - num5 - (class913_0.method_8().Height - (num6 + num5 * 2f + num7 * 2f)) / 2f, num5, num5);
		base.vmethod_4();
		interface42_0.imethod_55(smoothingMode_);
	}
}
