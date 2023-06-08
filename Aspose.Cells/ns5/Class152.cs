using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns5;

internal class Class152 : Class18
{
	internal Class152(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = class898_0.X;
		float y = class898_0.Y;
		float width = class898_0.Width;
		float height = class898_0.Height;
		return method_3(x, y, width, height);
	}

	private GraphicsPath method_3(float float_5, float float_6, float float_7, float float_8)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		switch (class898_0.class885_0.arrayList_0.Count)
		{
		default:
			num = 2880f * float_8 / 21600f;
			num2 = 0f * float_7 / 21600f;
			break;
		case 1:
			if (((Class882)class898_0.class885_0.arrayList_0[0]).method_0() == 327)
			{
				num = Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) * float_8 / 21600f;
				num2 = 0f * float_7 / 21600f;
			}
			else
			{
				num = 2880f * float_8 / 21600f;
				num2 = (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) - 10800f) * float_7 / 21600f;
			}
			break;
		case 2:
			num = Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[0]).Value) * float_8 / 21600f;
			num2 = (Convert.ToSingle(((Class882)class898_0.class885_0.arrayList_0[1]).Value) - 10800f) * float_7 / 21600f;
			break;
		}
		float num3 = float_7 - 2f * Math.Abs(num2);
		if (class898_0.method_20() == class898_0.method_18())
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
