using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class284 : Class160
{
	internal Class284(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = 0f;
		float num2 = 0f;
		PointF[] array = new PointF[6];
		GraphicsPath graphicsPath = new GraphicsPath();
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				num2 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
			}
			else
			{
				num = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.16f;
				num2 = 0f;
			}
		}
		else
		{
			num = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.16f;
			num2 = 0f;
		}
		if (num <= 0f && num2 == 0f)
		{
			graphicsPath.AddRectangle(rectangleF_0);
			graphicsPath.CloseFigure();
			return graphicsPath;
		}
		RectangleF rect = new RectangleF(rectangleF_0.Location, new SizeF(num * 2f, num * 2f));
		RectangleF rect2 = new RectangleF(rectangleF_0.Location, new SizeF(num2 * 2f, num2 * 2f));
		if (num != 0f && num2 != 0f)
		{
			switch (class913_0.int_3)
			{
			case 1:
				graphicsPath.AddArc(rect, 180f, 90f);
				rect2.X = rectangleF_0.Right - num2 * 2f;
				graphicsPath.AddArc(rect2, 270f, 90f);
				rect.X = rectangleF_0.Right - num * 2f;
				rect.Y = rectangleF_0.Bottom - num * 2f;
				graphicsPath.AddArc(rect, 0f, 90f);
				rect2.X = rectangleF_0.Left;
				rect2.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect2, 90f, 90f);
				break;
			case 2:
				graphicsPath.AddArc(rect2, 180f, 90f);
				rect.X = rectangleF_0.Right - num * 2f;
				graphicsPath.AddArc(rect, 270f, 90f);
				rect2.X = rectangleF_0.Right - num2 * 2f;
				rect2.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect2, 0f, 90f);
				rect.X = rectangleF_0.Left;
				rect.Y = rectangleF_0.Bottom - num * 2f;
				graphicsPath.AddArc(rect, 90f, 90f);
				break;
			case 3:
				graphicsPath.AddArc(rect, 180f, 90f);
				rect2.X = rectangleF_0.Right - num2 * 2f;
				graphicsPath.AddArc(rect2, 270f, 90f);
				rect.X = rectangleF_0.Right - num * 2f;
				rect.Y = rectangleF_0.Bottom - num * 2f;
				graphicsPath.AddArc(rect, 0f, 90f);
				rect2.X = rectangleF_0.Left;
				rect2.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect2, 90f, 90f);
				break;
			case 4:
				graphicsPath.AddArc(rect2, 180f, 90f);
				rect.X = rectangleF_0.Right - num * 2f;
				graphicsPath.AddArc(rect, 270f, 90f);
				rect2.X = rectangleF_0.Right - num2 * 2f;
				rect2.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect2, 0f, 90f);
				rect.X = rectangleF_0.Left;
				rect.Y = rectangleF_0.Bottom - num * 2f;
				graphicsPath.AddArc(rect, 90f, 90f);
				break;
			}
		}
		else if (num != 0f && num2 == 0f)
		{
			switch (class913_0.int_3)
			{
			case 1:
			{
				ref PointF reference19 = ref array[0];
				reference19 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference20 = ref array[1];
				reference20 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				ref PointF reference21 = ref array[2];
				reference21 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num);
				ref PointF reference22 = ref array[3];
				reference22 = new PointF(rectangleF_0.Right - num, rectangleF_0.Bottom);
				ref PointF reference23 = ref array[4];
				reference23 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference24 = ref array[5];
				reference24 = new PointF(rectangleF_0.X, num + rectangleF_0.Y);
				graphicsPath.AddArc(rect, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect.X = rectangleF_0.Right - num * 2f;
				rect.Y = rectangleF_0.Bottom - num * 2f;
				graphicsPath.AddArc(rect, 0f, 90f);
				graphicsPath.AddLine(array[3], array[4]);
				graphicsPath.AddLine(array[4], array[5]);
				break;
			}
			case 2:
			{
				ref PointF reference13 = ref array[0];
				reference13 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference14 = ref array[1];
				reference14 = new PointF(rectangleF_0.Right - num, rectangleF_0.Y);
				ref PointF reference15 = ref array[2];
				reference15 = new PointF(rectangleF_0.Right, num + rectangleF_0.Y);
				ref PointF reference16 = ref array[3];
				reference16 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference17 = ref array[4];
				reference17 = new PointF(num + rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference18 = ref array[5];
				reference18 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num);
				graphicsPath.AddLine(array[0], array[1]);
				rect.X = rectangleF_0.Right - num * 2f;
				graphicsPath.AddArc(rect, 270f, 90f);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[4]);
				rect.X = rectangleF_0.Left;
				rect.Y = rectangleF_0.Bottom - num * 2f;
				graphicsPath.AddArc(rect, 90f, 90f);
				graphicsPath.AddLine(array[5], array[0]);
				break;
			}
			case 3:
			{
				ref PointF reference7 = ref array[0];
				reference7 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference8 = ref array[1];
				reference8 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				ref PointF reference9 = ref array[2];
				reference9 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num);
				ref PointF reference10 = ref array[3];
				reference10 = new PointF(rectangleF_0.Right - num, rectangleF_0.Bottom);
				ref PointF reference11 = ref array[4];
				reference11 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference12 = ref array[5];
				reference12 = new PointF(rectangleF_0.X, num + rectangleF_0.Y);
				graphicsPath.AddArc(rect, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect.X = rectangleF_0.Right - num * 2f;
				rect.Y = rectangleF_0.Bottom - num * 2f;
				graphicsPath.AddArc(rect, 0f, 90f);
				graphicsPath.AddLine(array[3], array[4]);
				graphicsPath.AddLine(array[4], array[5]);
				break;
			}
			case 4:
			{
				ref PointF reference = ref array[0];
				reference = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference2 = ref array[1];
				reference2 = new PointF(rectangleF_0.Right - num, rectangleF_0.Y);
				ref PointF reference3 = ref array[2];
				reference3 = new PointF(rectangleF_0.Right, num + rectangleF_0.Y);
				ref PointF reference4 = ref array[3];
				reference4 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference5 = ref array[4];
				reference5 = new PointF(num + rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference6 = ref array[5];
				reference6 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num);
				graphicsPath.AddLine(array[0], array[1]);
				rect.X = rectangleF_0.Right - num * 2f;
				graphicsPath.AddArc(rect, 270f, 90f);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[4]);
				rect.X = rectangleF_0.Left;
				rect.Y = rectangleF_0.Bottom - num * 2f;
				graphicsPath.AddArc(rect, 90f, 90f);
				graphicsPath.AddLine(array[5], array[0]);
				break;
			}
			}
		}
		else if (num == 0f && num2 != 0f)
		{
			switch (class913_0.int_3)
			{
			case 1:
			{
				ref PointF reference43 = ref array[0];
				reference43 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference44 = ref array[1];
				reference44 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
				ref PointF reference45 = ref array[2];
				reference45 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
				ref PointF reference46 = ref array[3];
				reference46 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference47 = ref array[4];
				reference47 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference48 = ref array[5];
				reference48 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
				graphicsPath.AddLine(array[0], array[1]);
				rect2.X = rectangleF_0.Right - num2 * 2f;
				graphicsPath.AddArc(rect2, 270f, 90f);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[4]);
				rect2.X = rectangleF_0.Left;
				rect2.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect2, 90f, 90f);
				graphicsPath.AddLine(array[5], array[0]);
				break;
			}
			case 2:
			{
				ref PointF reference37 = ref array[0];
				reference37 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference38 = ref array[1];
				reference38 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				ref PointF reference39 = ref array[2];
				reference39 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
				ref PointF reference40 = ref array[3];
				reference40 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
				ref PointF reference41 = ref array[4];
				reference41 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference42 = ref array[5];
				reference42 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				graphicsPath.AddArc(rect2, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect2.X = rectangleF_0.Right - num2 * 2f;
				rect2.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect2, 0f, 90f);
				graphicsPath.AddLine(array[3], array[4]);
				graphicsPath.AddLine(array[4], array[5]);
				break;
			}
			case 3:
			{
				ref PointF reference31 = ref array[0];
				reference31 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference32 = ref array[1];
				reference32 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
				ref PointF reference33 = ref array[2];
				reference33 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
				ref PointF reference34 = ref array[3];
				reference34 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference35 = ref array[4];
				reference35 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference36 = ref array[5];
				reference36 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
				graphicsPath.AddLine(array[0], array[1]);
				rect2.X = rectangleF_0.Right - num2 * 2f;
				graphicsPath.AddArc(rect2, 270f, 90f);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[4]);
				rect2.X = rectangleF_0.Left;
				rect2.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect2, 90f, 90f);
				graphicsPath.AddLine(array[5], array[0]);
				break;
			}
			case 4:
			{
				ref PointF reference25 = ref array[0];
				reference25 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference26 = ref array[1];
				reference26 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				ref PointF reference27 = ref array[2];
				reference27 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
				ref PointF reference28 = ref array[3];
				reference28 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
				ref PointF reference29 = ref array[4];
				reference29 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference30 = ref array[5];
				reference30 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				graphicsPath.AddArc(rect2, 180f, 90f);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				rect2.X = rectangleF_0.Right - num2 * 2f;
				rect2.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect2, 0f, 90f);
				graphicsPath.AddLine(array[3], array[4]);
				graphicsPath.AddLine(array[4], array[5]);
				break;
			}
			}
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
