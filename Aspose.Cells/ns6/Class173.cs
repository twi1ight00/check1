using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class173 : Class160
{
	internal Class173(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = float_3;
		float y = float_4;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 60000f;
				num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 60000f;
			}
			else
			{
				num = 38f;
				num2 = 270f;
			}
		}
		else
		{
			num = 38f;
			num2 = 270f;
		}
		graphicsPath.AddArc(x, y, width, height, num, num2 - num);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
