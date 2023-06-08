using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class58 : Class18
{
	internal Class58(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = float_3;
		float y = float_4;
		float width = class898_0.method_7().Width;
		float height = class898_0.method_7().Height;
		float num = 0f;
		num = ((class898_0.class885_0.arrayList_0.Count <= 0) ? 0.25f : (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) / 21600f));
		GraphicsPath graphicsPath = new GraphicsPath();
		RectangleF rect = new RectangleF(x, y, width, height);
		graphicsPath.AddEllipse(rect);
		rect.Inflate((0f - num) * width, (0f - num) * height);
		graphicsPath.AddEllipse(rect);
		return graphicsPath;
	}
}
