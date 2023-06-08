using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class288 : Class160
{
	internal Class288(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float num = 0f;
		float num2 = 0f;
		GraphicsPath graphicsPath = new GraphicsPath();
		PointF[] array = new PointF[6];
		PointF[] array2 = new PointF[8];
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
			if (num != 0f && num2 == 0f)
			{
				switch (class913_0.int_3)
				{
				case 1:
				{
					ref PointF reference19 = ref array[0];
					reference19 = new PointF(rectangleF_0.X, rectangleF_0.Y);
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
					break;
				}
				}
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[4]);
				graphicsPath.AddLine(array[4], array[5]);
				graphicsPath.AddLine(array[5], array[0]);
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
					break;
				}
				}
				graphicsPath.AddLine(array[0], array[1]);
				graphicsPath.AddLine(array[1], array[2]);
				graphicsPath.AddLine(array[2], array[3]);
				graphicsPath.AddLine(array[3], array[4]);
				graphicsPath.AddLine(array[4], array[5]);
				graphicsPath.AddLine(array[5], array[0]);
			}
			else if (num != 0f && num2 != 0f)
			{
				switch (class913_0.int_3)
				{
				case 1:
				{
					ref PointF reference73 = ref array2[0];
					reference73 = new PointF(num + rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference74 = ref array2[1];
					reference74 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
					ref PointF reference75 = ref array2[2];
					reference75 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
					ref PointF reference76 = ref array2[3];
					reference76 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num);
					ref PointF reference77 = ref array2[4];
					reference77 = new PointF(rectangleF_0.Right - num, rectangleF_0.Bottom);
					ref PointF reference78 = ref array2[5];
					reference78 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference79 = ref array2[6];
					reference79 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
					ref PointF reference80 = ref array2[7];
					reference80 = new PointF(rectangleF_0.X, num + rectangleF_0.Y);
					break;
				}
				case 2:
				{
					ref PointF reference65 = ref array2[0];
					reference65 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference66 = ref array2[1];
					reference66 = new PointF(rectangleF_0.Right - num, rectangleF_0.Y);
					ref PointF reference67 = ref array2[2];
					reference67 = new PointF(rectangleF_0.Right, num + rectangleF_0.Y);
					ref PointF reference68 = ref array2[3];
					reference68 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
					ref PointF reference69 = ref array2[4];
					reference69 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
					ref PointF reference70 = ref array2[5];
					reference70 = new PointF(num + rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference71 = ref array2[6];
					reference71 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num);
					ref PointF reference72 = ref array2[7];
					reference72 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
					break;
				}
				case 3:
				{
					ref PointF reference57 = ref array2[0];
					reference57 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference58 = ref array2[1];
					reference58 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
					ref PointF reference59 = ref array2[2];
					reference59 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
					ref PointF reference60 = ref array2[3];
					reference60 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num);
					ref PointF reference61 = ref array2[4];
					reference61 = new PointF(rectangleF_0.Right - num, rectangleF_0.Bottom);
					ref PointF reference62 = ref array2[5];
					reference62 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference63 = ref array2[6];
					reference63 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
					ref PointF reference64 = ref array2[7];
					reference64 = new PointF(rectangleF_0.X, num + rectangleF_0.Y);
					break;
				}
				case 4:
				{
					ref PointF reference49 = ref array2[0];
					reference49 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
					ref PointF reference50 = ref array2[1];
					reference50 = new PointF(rectangleF_0.Right - num, rectangleF_0.Y);
					ref PointF reference51 = ref array2[2];
					reference51 = new PointF(rectangleF_0.Right, num + rectangleF_0.Y);
					ref PointF reference52 = ref array2[3];
					reference52 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
					ref PointF reference53 = ref array2[4];
					reference53 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
					ref PointF reference54 = ref array2[5];
					reference54 = new PointF(num + rectangleF_0.X, rectangleF_0.Bottom);
					ref PointF reference55 = ref array2[6];
					reference55 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num);
					ref PointF reference56 = ref array2[7];
					reference56 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
					break;
				}
				}
				graphicsPath.AddLine(array2[0], array2[1]);
				graphicsPath.AddLine(array2[1], array2[2]);
				graphicsPath.AddLine(array2[2], array2[3]);
				graphicsPath.AddLine(array2[3], array2[4]);
				graphicsPath.AddLine(array2[4], array2[5]);
				graphicsPath.AddLine(array2[5], array2[6]);
				graphicsPath.AddLine(array2[6], array2[7]);
				graphicsPath.AddLine(array2[7], array2[0]);
			}
			else if (num == 0f && num2 == 0f)
			{
				graphicsPath.AddRectangle(rectangleF_0);
			}
		}
		else
		{
			num2 = Math.Min(rectangleF_0.Width, rectangleF_0.Height) * 0.16f;
			switch (class913_0.int_3)
			{
			case 1:
			{
				ref PointF reference99 = ref array[0];
				reference99 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference100 = ref array[1];
				reference100 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
				ref PointF reference101 = ref array[2];
				reference101 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
				ref PointF reference102 = ref array[3];
				reference102 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference103 = ref array[4];
				reference103 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference104 = ref array[5];
				reference104 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
				break;
			}
			case 2:
			{
				ref PointF reference93 = ref array[0];
				reference93 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference94 = ref array[1];
				reference94 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				ref PointF reference95 = ref array[2];
				reference95 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
				ref PointF reference96 = ref array[3];
				reference96 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
				ref PointF reference97 = ref array[4];
				reference97 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference98 = ref array[5];
				reference98 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				break;
			}
			case 3:
			{
				ref PointF reference87 = ref array[0];
				reference87 = new PointF(rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference88 = ref array[1];
				reference88 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Y);
				ref PointF reference89 = ref array[2];
				reference89 = new PointF(rectangleF_0.Right, num2 + rectangleF_0.Y);
				ref PointF reference90 = ref array[3];
				reference90 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom);
				ref PointF reference91 = ref array[4];
				reference91 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference92 = ref array[5];
				reference92 = new PointF(rectangleF_0.X, rectangleF_0.Bottom - num2);
				break;
			}
			case 4:
			{
				ref PointF reference81 = ref array[0];
				reference81 = new PointF(num2 + rectangleF_0.X, rectangleF_0.Y);
				ref PointF reference82 = ref array[1];
				reference82 = new PointF(rectangleF_0.Right, rectangleF_0.Y);
				ref PointF reference83 = ref array[2];
				reference83 = new PointF(rectangleF_0.Right, rectangleF_0.Bottom - num2);
				ref PointF reference84 = ref array[3];
				reference84 = new PointF(rectangleF_0.Right - num2, rectangleF_0.Bottom);
				ref PointF reference85 = ref array[4];
				reference85 = new PointF(rectangleF_0.X, rectangleF_0.Bottom);
				ref PointF reference86 = ref array[5];
				reference86 = new PointF(rectangleF_0.X, num2 + rectangleF_0.Y);
				break;
			}
			}
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[4]);
			graphicsPath.AddLine(array[4], array[5]);
			graphicsPath.AddLine(array[5], array[0]);
		}
		graphicsPath.CloseFigure();
		return graphicsPath;
	}
}
