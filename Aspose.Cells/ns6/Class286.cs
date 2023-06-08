using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class286 : Class160
{
	internal Class286(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = 0f;
		float num2 = 0f;
		PointF[] array = new PointF[5];
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
		if (num != 0f && num2 != 0f)
		{
			if (class913_0.int_3 != 1 && class913_0.int_3 != 4)
			{
				if (class913_0.int_3 == 2 || class913_0.int_3 == 3)
				{
					RectangleF rect = new RectangleF(rectangleF_0.Location, new SizeF(num * 2f, num * 2f));
					RectangleF rect2 = new RectangleF(rectangleF_0.Location, new SizeF(num2 * 2f, num2 * 2f));
					graphicsPath.AddArc(rect2, 180f, 90f);
					rect2.X = rectangleF_0.Right - num2 * 2f;
					graphicsPath.AddArc(rect2, 270f, 90f);
					rect.X = rectangleF_0.Right - num * 2f;
					rect.Y = rectangleF_0.Bottom - num * 2f;
					graphicsPath.AddArc(rect, 0f, 90f);
					rect.X = rectangleF_0.Left;
					graphicsPath.AddArc(rect, 90f, 90f);
					graphicsPath.CloseFigure();
				}
			}
			else
			{
				RectangleF rect3 = new RectangleF(rectangleF_0.Location, new SizeF(num * 2f, num * 2f));
				RectangleF rect4 = new RectangleF(rectangleF_0.Location, new SizeF(num2 * 2f, num2 * 2f));
				graphicsPath.AddArc(rect3, 180f, 90f);
				rect3.X = rectangleF_0.Right - num * 2f;
				graphicsPath.AddArc(rect3, 270f, 90f);
				rect4.X = rectangleF_0.Right - num2 * 2f;
				rect4.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect4, 0f, 90f);
				rect4.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect4, 90f, 90f);
				graphicsPath.CloseFigure();
			}
		}
		else if (num != 0f && num2 == 0f)
		{
			if (class913_0.int_3 != 1 && class913_0.int_3 != 4)
			{
				if (class913_0.int_3 == 2 || class913_0.int_3 == 3)
				{
					RectangleF rect5 = new RectangleF(rectangleF_0.Location, new SizeF(num * 2f, num * 2f));
					rect5.X = rectangleF_0.Right - num * 2f;
					rect5.Y = rectangleF_0.Bottom - num * 2f;
					graphicsPath.AddArc(rect5, 0f, 90f);
					rect5.X = rectangleF_0.Left;
					graphicsPath.AddArc(rect5, 90f, 90f);
					ref PointF reference = ref array[0];
					reference = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference2 = ref array[1];
					reference2 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					graphicsPath.AddLine(array[0], array[1]);
					graphicsPath.CloseFigure();
				}
			}
			else
			{
				RectangleF rect6 = new RectangleF(rectangleF_0.Location, new SizeF(num * 2f, num * 2f));
				graphicsPath.AddArc(rect6, 180f, 90f);
				rect6.X = rectangleF_0.Right - num * 2f;
				graphicsPath.AddArc(rect6, 270f, 90f);
				ref PointF reference3 = ref array[0];
				reference3 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference4 = ref array[1];
				reference4 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.CloseFigure();
			}
		}
		else if (num == 0f && num2 != 0f)
		{
			if (class913_0.int_3 != 1 && class913_0.int_3 != 4)
			{
				if (class913_0.int_3 == 2 || class913_0.int_3 == 3)
				{
					RectangleF rect7 = new RectangleF(rectangleF_0.Location, new SizeF(num2 * 2f, num2 * 2f));
					graphicsPath.AddArc(rect7, 180f, 90f);
					rect7.X = rectangleF_0.Right - num2 * 2f;
					graphicsPath.AddArc(rect7, 270f, 90f);
					ref PointF reference5 = ref array[0];
					reference5 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference6 = ref array[1];
					reference6 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					graphicsPath.AddLine(array[0], array[1]);
					graphicsPath.CloseFigure();
				}
			}
			else
			{
				RectangleF rect8 = new RectangleF(rectangleF_0.Location, new SizeF(num2 * 2f, num2 * 2f));
				rect8.X = rectangleF_0.Right - num2 * 2f;
				rect8.Y = rectangleF_0.Bottom - num2 * 2f;
				graphicsPath.AddArc(rect8, 0f, 90f);
				rect8.X = rectangleF_0.Left;
				graphicsPath.AddArc(rect8, 90f, 90f);
				ref PointF reference7 = ref array[0];
				reference7 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference8 = ref array[1];
				reference8 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.CloseFigure();
			}
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
