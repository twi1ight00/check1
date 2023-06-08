using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class289 : Class160
{
	internal Class289(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
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
				num = 0f;
				num2 = 0f;
			}
			num3 = num * 2f;
			RectangleF rect = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
			if (num != 0f && num2 != 0f)
			{
				switch (class913_0.int_3)
				{
				case 1:
				{
					ref PointF reference19 = ref array[0];
					reference19 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference20 = ref array[1];
					reference20 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
					ref PointF reference21 = ref array[2];
					reference21 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
					ref PointF reference22 = ref array[3];
					reference22 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference23 = ref array[4];
					reference23 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference24 = ref array[5];
					reference24 = new PointF(rectangleF_0.X, num + rectangleF_0.Y);
					graphicsPath.AddArc(rect, 180f, 90f);
					graphicsPath.AddLine(array[1], array[2]);
					graphicsPath.AddLine(array[2], array[3]);
					graphicsPath.AddLine(array[3], array[4]);
					break;
				}
				case 2:
				{
					ref PointF reference13 = ref array[0];
					reference13 = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference14 = ref array[1];
					reference14 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					ref PointF reference15 = ref array[2];
					reference15 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
					ref PointF reference16 = ref array[3];
					reference16 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
					ref PointF reference17 = ref array[4];
					reference17 = new PointF(num + rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference18 = ref array[5];
					reference18 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num);
					graphicsPath.AddLine(array[0], array[1]);
					graphicsPath.AddLine(array[1], array[2]);
					graphicsPath.AddLine(array[2], array[3]);
					rect.Y = rectangleF_0.Bottom - num3;
					graphicsPath.AddArc(rect, 90f, 90f);
					break;
				}
				case 3:
				{
					ref PointF reference7 = ref array[0];
					reference7 = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference8 = ref array[1];
					reference8 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					ref PointF reference9 = ref array[2];
					reference9 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num);
					ref PointF reference10 = ref array[3];
					reference10 = new PointF(rectangleF_0.Right - num, rectangleF_0.Bottom);
					ref PointF reference11 = ref array[4];
					reference11 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference12 = ref array[5];
					reference12 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
					graphicsPath.AddLine(array[0], array[1]);
					rect.X = rectangleF_0.Right - num3;
					rect.Y = rectangleF_0.Bottom - num3;
					graphicsPath.AddArc(rect, 0f, 90f);
					graphicsPath.AddLine(array[4], array[5]);
					graphicsPath.AddLine(array[5], array[0]);
					break;
				}
				case 4:
				{
					ref PointF reference = ref array[0];
					reference = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference2 = ref array[1];
					reference2 = new PointF(rectangleF_0.Right - num, rectangleF_0.Y);
					ref PointF reference3 = ref array[2];
					reference3 = new PointF(rectangleF_0.Right, num);
					ref PointF reference4 = ref array[3];
					reference4 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference5 = ref array[4];
					reference5 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference6 = ref array[5];
					reference6 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
					rect.X = rectangleF_0.Right - num3;
					graphicsPath.AddArc(rect, 270f, 90f);
					graphicsPath.AddLine(array[3], array[4]);
					graphicsPath.AddLine(array[4], array[5]);
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
					ref PointF reference40 = ref array[0];
					reference40 = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference41 = ref array[1];
					reference41 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
					ref PointF reference42 = ref array[2];
					reference42 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
					ref PointF reference43 = ref array[3];
					reference43 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference44 = ref array[4];
					reference44 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					break;
				}
				case 2:
				{
					ref PointF reference35 = ref array[0];
					reference35 = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference36 = ref array[1];
					reference36 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					ref PointF reference37 = ref array[2];
					reference37 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
					ref PointF reference38 = ref array[3];
					reference38 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
					ref PointF reference39 = ref array[4];
					reference39 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					break;
				}
				case 3:
				{
					ref PointF reference30 = ref array[0];
					reference30 = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference31 = ref array[1];
					reference31 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					ref PointF reference32 = ref array[2];
					reference32 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference33 = ref array[3];
					reference33 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference34 = ref array[4];
					reference34 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
					break;
				}
				case 4:
				{
					ref PointF reference25 = ref array[0];
					reference25 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference26 = ref array[1];
					reference26 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					ref PointF reference27 = ref array[2];
					reference27 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference28 = ref array[3];
					reference28 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference29 = ref array[4];
					reference29 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
					break;
				}
				}
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[4]);
				graphicsPath.AddLine(array[4], array[0]);
			}
			else if (num != 0f && num2 == 0f)
			{
				switch (class913_0.int_3)
				{
				case 1:
				{
					ref PointF reference60 = ref array[0];
					reference60 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference61 = ref array[1];
					reference61 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					ref PointF reference62 = ref array[2];
					reference62 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference63 = ref array[3];
					reference63 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference64 = ref array[4];
					reference64 = new PointF(rectangleF_0.X, num + rectangleF_0.Y);
					graphicsPath.AddArc(rect, 180f, 90f);
					graphicsPath.AddLine(array[1], array[2]);
					graphicsPath.AddLine(array[2], array[3]);
					break;
				}
				case 2:
				{
					ref PointF reference55 = ref array[0];
					reference55 = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference56 = ref array[1];
					reference56 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					ref PointF reference57 = ref array[2];
					reference57 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference58 = ref array[3];
					reference58 = new PointF(num + rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference59 = ref array[4];
					reference59 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num);
					graphicsPath.AddLine(array[0], array[1]);
					graphicsPath.AddLine(array[1], array[2]);
					rect.Y = rectangleF_0.Bottom - num3;
					graphicsPath.AddArc(rect, 90f, 90f);
					break;
				}
				case 3:
				{
					ref PointF reference50 = ref array[0];
					reference50 = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference51 = ref array[1];
					reference51 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
					ref PointF reference52 = ref array[2];
					reference52 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num);
					ref PointF reference53 = ref array[3];
					reference53 = new PointF(rectangleF_0.Right - num, rectangleF_0.Bottom);
					ref PointF reference54 = ref array[4];
					reference54 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					graphicsPath.AddLine(array[0], array[1]);
					rect.X = rectangleF_0.Right - num3;
					rect.Y = rectangleF_0.Bottom - num3;
					graphicsPath.AddArc(rect, 0f, 90f);
					graphicsPath.AddLine(array[3], array[4]);
					break;
				}
				case 4:
				{
					ref PointF reference45 = ref array[0];
					reference45 = new PointF(rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference46 = ref array[1];
					reference46 = new PointF(rectangleF_0.Right - num, rectangleF_0.Y);
					ref PointF reference47 = ref array[2];
					reference47 = new PointF(rectangleF_0.Right, num + rectangleF_0.Y);
					ref PointF reference48 = ref array[3];
					reference48 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
					ref PointF reference49 = ref array[4];
					reference49 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
					rect.X = rectangleF_0.Right - num3;
					graphicsPath.AddArc(rect, 270f, 90f);
					graphicsPath.AddLine(array[3], array[4]);
					graphicsPath.AddLine(array[4], array[0]);
					break;
				}
				}
			}
			else
			{
				graphicsPath.AddRectangle(rectangleF_0);
			}
		}
		else
		{
			num = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.16f;
			num2 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.16f;
			num3 = num * 2f;
			RectangleF rect2 = new RectangleF(size: new SizeF(num3, num3), location: rectangleF_0.Location);
			switch (class913_0.int_3)
			{
			case 1:
			{
				ref PointF reference83 = ref array[0];
				reference83 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference84 = ref array[1];
				reference84 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
				ref PointF reference85 = ref array[2];
				reference85 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
				ref PointF reference86 = ref array[3];
				reference86 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference87 = ref array[4];
				reference87 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference88 = ref array[5];
				reference88 = new PointF(rectangleF_0.X, num + rectangleF_0.Y);
				graphicsPath.AddArc(rect2, 180f, 90f);
				graphicsPath.AddLine(array[1], array[2]);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[4]);
				break;
			}
			case 2:
			{
				ref PointF reference77 = ref array[0];
				reference77 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference78 = ref array[1];
				reference78 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				ref PointF reference79 = ref array[2];
				reference79 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
				ref PointF reference80 = ref array[3];
				reference80 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
				ref PointF reference81 = ref array[4];
				reference81 = new PointF(num + rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference82 = ref array[5];
				reference82 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num);
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				graphicsPath.AddLine(array[2], array[3]);
				rect2.Y = rectangleF_0.Bottom - num3;
				graphicsPath.AddArc(rect2, 90f, 90f);
				break;
			}
			case 3:
			{
				ref PointF reference71 = ref array[0];
				reference71 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference72 = ref array[1];
				reference72 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				ref PointF reference73 = ref array[2];
				reference73 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num);
				ref PointF reference74 = ref array[3];
				reference74 = new PointF(rectangleF_0.Right - num, rectangleF_0.Bottom);
				ref PointF reference75 = ref array[4];
				reference75 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference76 = ref array[5];
				reference76 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
				graphicsPath.AddLine(array[0], array[1]);
				rect2.X = rectangleF_0.Right - num3;
				rect2.Y = rectangleF_0.Bottom - num3;
				graphicsPath.AddArc(rect2, 0f, 90f);
				graphicsPath.AddLine(array[4], array[5]);
				graphicsPath.AddLine(array[5], array[0]);
				break;
			}
			case 4:
			{
				ref PointF reference65 = ref array[0];
				reference65 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference66 = ref array[1];
				reference66 = new PointF(rectangleF_0.Right - num, rectangleF_0.Y);
				ref PointF reference67 = ref array[2];
				reference67 = new PointF(rectangleF_0.Right, num + rectangleF_0.Y);
				ref PointF reference68 = ref array[3];
				reference68 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference69 = ref array[4];
				reference69 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference70 = ref array[5];
				reference70 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				rect2.X = rectangleF_0.Right - num3;
				graphicsPath.AddArc(rect2, 270f, 90f);
				graphicsPath.AddLine(array[3], array[4]);
				graphicsPath.AddLine(array[4], array[5]);
				graphicsPath.AddLine(array[5], array[0]);
				break;
			}
			}
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
