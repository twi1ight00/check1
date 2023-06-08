using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class283 : Class160
{
	internal Class283(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		num = ((class913_0.class901_0 == null) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.16f) : ((class913_0.class901_0.arrayList_0.Count <= 0) ? (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.16f) : (Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f)));
		if (num <= 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		PointF[] array = new PointF[5];
		switch (class913_0.int_3)
		{
		case 1:
		{
			ref PointF reference16 = ref array[0];
			reference16 = new PointF(rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference17 = ref array[1];
			reference17 = new PointF(rectangleF_0.Right - num, rectangleF_0.Y);
			ref PointF reference18 = ref array[2];
			reference18 = new PointF(rectangleF_0.Right, num + rectangleF_0.Y);
			ref PointF reference19 = ref array[3];
			reference19 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
			ref PointF reference20 = ref array[4];
			reference20 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
			break;
		}
		case 2:
		{
			ref PointF reference11 = ref array[0];
			reference11 = new PointF(rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference12 = ref array[1];
			reference12 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
			ref PointF reference13 = ref array[2];
			reference13 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num);
			ref PointF reference14 = ref array[3];
			reference14 = new PointF(rectangleF_0.Right - num, rectangleF_0.Bottom);
			ref PointF reference15 = ref array[4];
			reference15 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
			break;
		}
		case 3:
		{
			ref PointF reference6 = ref array[0];
			reference6 = new PointF(rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference7 = ref array[1];
			reference7 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
			ref PointF reference8 = ref array[2];
			reference8 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
			ref PointF reference9 = ref array[3];
			reference9 = new PointF(num + rectangleF_0.X, rectangleF_0.Bottom);
			ref PointF reference10 = ref array[4];
			reference10 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num);
			break;
		}
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(rectangleF_0.X, num + rectangleF_0.Y);
			break;
		}
		}
		graphicsPath.AddLine(array[0], array[1]);
		graphicsPath.AddLine(array[1], array[2]);
		graphicsPath.AddLine(array[2], array[3]);
		graphicsPath.AddLine(array[3], array[4]);
		graphicsPath.AddLine(array[4], array[0]);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	internal override void vmethod_4()
	{
		RectangleF rectangleF_ = new RectangleF(float_3 + 10f, float_4, class913_0.method_8().Width, class913_0.method_8().Height);
		Struct72.smethod_3(interface42_0, class913_0, rectangleF_, class913_0.Text, class913_0.method_9(), class913_0.Font, class913_0.FontColor, class913_0.TextHorizontalAlignment, class913_0.TextVerticalAlignment);
	}
}
