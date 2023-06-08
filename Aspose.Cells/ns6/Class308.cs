using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class308 : Class160
{
	internal Class308(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = class913_0.X;
		float y = class913_0.Y;
		float width = class913_0.Width;
		float height = class913_0.Height;
		return method_3(x, y, width, height);
	}

	private GraphicsPath method_3(float float_5, float float_6, float float_7, float float_8)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) * float_8 / 100000f;
				num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) * float_7 / 100000f;
			}
			else
			{
				num = 12500f * float_8 / 100000f;
				num2 = 0f * float_7 / 100000f;
			}
		}
		else
		{
			num = 12500f * float_8 / 100000f;
			num2 = 0f * float_7 / 100000f;
		}
		float num3 = float_7 - 2f * Math.Abs(num2);
		if (class913_0.method_23() == class913_0.method_21())
		{
			if (num2 >= 0f)
			{
				graphicsPath.AddBezier(float_5, float_6 + num, float_5 + num3 / 2f, float_6 - 2f * num, float_5 + 1f * num3 / 2f, float_6 + 4f * num, float_5 + num3, float_6 + num);
				graphicsPath.AddBezier(float_5 + float_7, float_6 + float_8 - num, float_5 + 2f * Math.Abs(num2) + 1f * num3 / 2f, float_6 + float_8 + 2f * num, float_5 + 2f * Math.Abs(num2) + num3 / 2f, float_6 + float_8 - 4f * num, float_5 + 2f * Math.Abs(num2), float_6 + float_8 - num);
				graphicsPath.CloseFigure();
			}
			else
			{
				graphicsPath.AddBezier(float_5 + 2f * Math.Abs(num2), float_6 + num, float_5 + 2f * Math.Abs(num2) + num3 / 2f, float_6 - 2f * num, float_5 + 2f * Math.Abs(num2) + num3 / 2f, float_6 + 4f * num, float_5 + float_7, float_6 + num);
				graphicsPath.AddBezier(float_5 + num3, float_6 + float_8 - num, float_5 + num3 / 2f, float_6 + float_8 + 2f * num, float_5 + num3 / 2f, float_6 + float_8 - 4f * num, float_5, float_6 + float_8 - num);
				graphicsPath.CloseFigure();
			}
		}
		return graphicsPath;
	}
}
