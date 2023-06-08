using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class222 : Class160
{
	internal Class222(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		float x = rectangleF_0.X;
		float y = rectangleF_0.Y;
		float width = rectangleF_0.Width;
		float height = rectangleF_0.Height;
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = Math.Min(width, height);
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = num4 * (Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f);
				num2 = num4 * Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 100000f;
				num3 = num4 * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
			}
			else
			{
				num = num4 * 0.25f;
				num2 = num4 * 0.25f;
				num3 = num4 * 0.25f;
			}
		}
		else
		{
			num = num4 * 0.25f;
			num2 = num4 * 0.25f;
			num3 = num4 * 0.25f;
		}
		GraphicsPath graphicsPath = new GraphicsPath();
		float num5 = num2 - num / 2f;
		PointF[] array = new PointF[12];
		switch (class913_0.int_3)
		{
		case 1:
		{
			ref PointF reference37 = ref array[0];
			reference37 = new PointF(x + (width - 2f * num2), y + num3);
			ref PointF reference38 = ref array[1];
			reference38 = new PointF(x + (width - num2), y);
			ref PointF reference39 = ref array[2];
			reference39 = new PointF(x + width, y + num3);
			ref PointF reference40 = ref array[3];
			reference40 = new PointF(x + (width - num5), y + num3);
			ref PointF reference41 = ref array[4];
			reference41 = new PointF(x + (width - num5), y + (height - num5));
			ref PointF reference42 = ref array[5];
			reference42 = new PointF(x + num3, y + (height - num5));
			ref PointF reference43 = ref array[6];
			reference43 = new PointF(x + num3, y + height);
			ref PointF reference44 = ref array[7];
			reference44 = new PointF(x, y + (height - num2));
			ref PointF reference45 = ref array[8];
			reference45 = new PointF(x + num3, y + (height - 2f * num2));
			ref PointF reference46 = ref array[9];
			reference46 = new PointF(x + num3, y + (height - 2f * num2 + num5));
			ref PointF reference47 = ref array[10];
			reference47 = new PointF(x + (width - 2f * num2 + num5), y + (height - 2f * num2 + num5));
			ref PointF reference48 = ref array[11];
			reference48 = new PointF(x + (width - 2f * num2 + num5), y + num3);
			break;
		}
		case 2:
		{
			ref PointF reference25 = ref array[0];
			reference25 = new PointF(x + (width - 2f * num2), y + height - num3);
			ref PointF reference26 = ref array[1];
			reference26 = new PointF(x + (width - num2), y + height);
			ref PointF reference27 = ref array[2];
			reference27 = new PointF(x + width, y + height - num3);
			ref PointF reference28 = ref array[3];
			reference28 = new PointF(x + (width - num5), y + height - num3);
			ref PointF reference29 = ref array[4];
			reference29 = new PointF(x + (width - num5), y + num5);
			ref PointF reference30 = ref array[5];
			reference30 = new PointF(x + num3, y + num5);
			ref PointF reference31 = ref array[6];
			reference31 = new PointF(x + num3, y);
			ref PointF reference32 = ref array[7];
			reference32 = new PointF(x, y + num2);
			ref PointF reference33 = ref array[8];
			reference33 = new PointF(x + num3, y + 2f * num2);
			ref PointF reference34 = ref array[9];
			reference34 = new PointF(x + num3, y + 2f * num2 - num5);
			ref PointF reference35 = ref array[10];
			reference35 = new PointF(x + (width - 2f * num2 + num5), y + 2f * num2 - num5);
			ref PointF reference36 = ref array[11];
			reference36 = new PointF(x + (width - 2f * num2 + num5), y + height - num3);
			break;
		}
		case 3:
		{
			ref PointF reference13 = ref array[0];
			reference13 = new PointF(x + 2f * num2, y + height - num3);
			ref PointF reference14 = ref array[1];
			reference14 = new PointF(x + num2, y + height);
			ref PointF reference15 = ref array[2];
			reference15 = new PointF(x, y + height - num3);
			ref PointF reference16 = ref array[3];
			reference16 = new PointF(x + num5, y + height - num3);
			ref PointF reference17 = ref array[4];
			reference17 = new PointF(x + num5, y + num5);
			ref PointF reference18 = ref array[5];
			reference18 = new PointF(x + width - num3, y + num5);
			ref PointF reference19 = ref array[6];
			reference19 = new PointF(x + width - num3, y);
			ref PointF reference20 = ref array[7];
			reference20 = new PointF(x + width, y + num2);
			ref PointF reference21 = ref array[8];
			reference21 = new PointF(x + width - num3, y + 2f * num2);
			ref PointF reference22 = ref array[9];
			reference22 = new PointF(x + width - num3, y + 2f * num2 - num5);
			ref PointF reference23 = ref array[10];
			reference23 = new PointF(x + 2f * num2 - num5, y + 2f * num2 - num5);
			ref PointF reference24 = ref array[11];
			reference24 = new PointF(x + 2f * num2 - num5, y + height - num3);
			break;
		}
		case 4:
		{
			ref PointF reference = ref array[0];
			reference = new PointF(x + 2f * num2, y + num3);
			ref PointF reference2 = ref array[1];
			reference2 = new PointF(x + num2, y);
			ref PointF reference3 = ref array[2];
			reference3 = new PointF(x, y + num3);
			ref PointF reference4 = ref array[3];
			reference4 = new PointF(x + num5, y + num3);
			ref PointF reference5 = ref array[4];
			reference5 = new PointF(x + num5, y + height - num5);
			ref PointF reference6 = ref array[5];
			reference6 = new PointF(x + width - num3, y + height - num5);
			ref PointF reference7 = ref array[6];
			reference7 = new PointF(x + width - num3, y + height);
			ref PointF reference8 = ref array[7];
			reference8 = new PointF(x + width, y + height - num2);
			ref PointF reference9 = ref array[8];
			reference9 = new PointF(x + width - num3, y + height - 2f * num2);
			ref PointF reference10 = ref array[9];
			reference10 = new PointF(x + width - num3, y + height - 2f * num2 + num5);
			ref PointF reference11 = ref array[10];
			reference11 = new PointF(x + 2f * num2 - num5, y + height - 2f * num2 + num5);
			ref PointF reference12 = ref array[11];
			reference12 = new PointF(x + 2f * num2 - num5, y + num3);
			break;
		}
		}
		graphicsPath.AddPolygon(array);
		return graphicsPath;
	}
}
