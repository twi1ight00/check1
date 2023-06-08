using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns19;

namespace ns6;

internal class Class278 : Class160
{
	internal Class278(Interface42 interface42_1, float float_5, float float_6, Class913 class913_1)
		: base(interface42_1, float_5, float_6, class913_1)
	{
		switch (class913_0.int_3)
		{
		case 2:
		{
			Matrix matrix_3 = new Matrix(1f, 0f, 0f, -1f, 0f, class913_0.method_25().Height);
			interface42_0.imethod_58(matrix_3);
			break;
		}
		case 3:
		{
			Matrix matrix_2 = new Matrix(-1f, 0f, 0f, -1f, class913_0.method_25().Width, class913_0.method_25().Height);
			interface42_0.imethod_58(matrix_2);
			break;
		}
		case 4:
		{
			Matrix matrix_ = new Matrix(-1f, 0f, 0f, 1f, class913_0.method_25().Width, 0f);
			interface42_0.imethod_58(matrix_);
			break;
		}
		case 1:
			break;
		}
	}

	internal override GraphicsPath vmethod_0(RectangleF rectangleF_0)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		if (class913_0.class901_0 != null)
		{
			if (class913_0.class901_0.arrayList_0.Count > 0)
			{
				num = class913_0.Height * Convert.ToSingle(class913_0.class901_0.arrayList_0[0]) / 100000f;
				num2 = Convert.ToSingle(class913_0.class901_0.arrayList_0[1]) / 60000f;
				num3 = class913_0.Height * Convert.ToSingle(class913_0.class901_0.arrayList_0[2]) / 100000f;
			}
			else
			{
				num = class913_0.Height * 23520f / 100000f;
				num2 = 110f;
				num3 = class913_0.Height * 11759f / 100000f;
			}
		}
		else
		{
			num = class913_0.Height * 23520f / 100000f;
			num2 = 110f;
			num3 = class913_0.Height * 11759f / 100000f;
		}
		float num4 = 0f;
		num4 = ((!(num2 < 90f)) ? ((float)Struct70.smethod_0(180f - num2)) : ((float)Struct70.smethod_0(num2)));
		float num5 = 0.135f * rectangleF_0.Width;
		float num6 = rectangleF_0.Width - num5;
		float num7 = (rectangleF_0.Height - num * 2f - num3) / 2f;
		float num8 = rectangleF_0.Height - num7;
		float num9 = 0f;
		float num10 = 0f;
		float num11 = num;
		num9 = (float)((double)num11 * Math.Cos(num4));
		num10 = (float)((double)num11 * Math.Sin(num4));
		float num12 = 0f;
		float num13 = 0f;
		num13 = num7 - num9;
		num12 = (float)((double)num13 / Math.Tan(num4));
		float num14 = 0f;
		float num15 = 0f;
		num14 = rectangleF_0.Height - num7;
		num15 = (float)((double)num14 / Math.Tan(num4));
		float num16 = (rectangleF_0.Width - num10 - num15) / 2f;
		float num17 = 0f;
		float num18 = 0f;
		float num19 = 0f;
		float num20 = 0f;
		float num21 = 0f;
		float num22 = 0f;
		float num23 = 0f;
		float num24 = 0f;
		float num25 = 0f;
		if (num2 < 90f)
		{
			num17 = rectangleF_0.Width - num16 - (num * 2f + num3 + num13) / (float)Math.Tan(num4);
			num18 = rectangleF_0.Width - num16 - (num13 + num + num3) / (float)Math.Tan(num4);
			num19 = rectangleF_0.Width - num16 - (num13 + num) / (float)Math.Tan(num4);
			num20 = rectangleF_0.Width - num16 - num13 / (float)Math.Tan(num4);
			num21 = rectangleF_0.Width - num16;
			num25 = (num13 + 2f * num + num3) / (float)Math.Tan(num4) + num16;
			num22 = (num13 + num * 2f + num3) / (float)Math.Tan(num4) + num16;
			num23 = (num13 + num + num3) / (float)Math.Tan(num4) + num16;
			num24 = (num13 + num) / (float)Math.Tan(num4) + num16;
		}
		else
		{
			num17 = rectangleF_0.Width - num16 - num12;
			num18 = rectangleF_0.Width - num16 - (num13 + num) / (float)Math.Tan(num4);
			num19 = rectangleF_0.Width - num16 - (num13 + num + num3) / (float)Math.Tan(num4);
			num20 = rectangleF_0.Width - num16 - (num13 + num * 2f + num3) / (float)Math.Tan(num4);
			num21 = rectangleF_0.Width - num16 - (num13 + num * 2f + num3 + num7) / (float)Math.Tan(num4);
			num22 = (num13 + num * 2f + num3) / (float)Math.Tan(num4) + num16;
			num23 = (num13 + num) / (float)Math.Tan(num4) + num16;
			num24 = (num13 + num + num3) / (float)Math.Tan(num4) + num16;
		}
		PointF[] array = new PointF[20];
		if (!(num <= 0f))
		{
			if (num2 < 90f)
			{
				ref PointF reference = ref array[0];
				reference = new PointF(float_3 + num5, float_4 + num7);
				ref PointF reference2 = ref array[1];
				reference2 = new PointF(float_3 + num16 + num12, float_4 + num7);
				ref PointF reference3 = ref array[2];
				reference3 = new PointF(float_3 + num16, float_4 + num9);
				ref PointF reference4 = ref array[3];
				reference4 = new PointF(float_3 + num16 + num10, float_4);
				ref PointF reference5 = ref array[4];
				reference5 = new PointF(float_3 + num17 + num12, float_4 + num7);
				ref PointF reference6 = ref array[5];
				reference6 = new PointF(float_3 + num6, float_4 + num7);
				ref PointF reference7 = ref array[6];
				reference7 = new PointF(float_3 + num6, float_4 + num7 + num);
				ref PointF reference8 = ref array[7];
				reference8 = new PointF(float_3 + num18 + num12, float_4 + num7 + num);
				ref PointF reference9 = ref array[8];
				reference9 = new PointF(float_3 + num19 + num12, float_4 + num7 + num + num3);
				ref PointF reference10 = ref array[9];
				reference10 = new PointF(float_3 + num6, float_4 + num7 + num + num3);
				ref PointF reference11 = ref array[10];
				reference11 = new PointF(float_3 + num6, float_4 + num7 + 2f * num + num3);
				ref PointF reference12 = ref array[11];
				reference12 = new PointF(float_3 + num20 + num12, float_4 + num7 + 2f * num + num3);
				ref PointF reference13 = ref array[12];
				reference13 = new PointF(float_3 + num21 + num12, float_4 + rectangleF_0.Height - num9);
				ref PointF reference14 = ref array[13];
				reference14 = new PointF(float_3 + rectangleF_0.Width - num16 - num10 + num12, float_4 + rectangleF_0.Height);
				ref PointF reference15 = ref array[14];
				reference15 = new PointF(float_3 + num25, float_4 + num8);
				ref PointF reference16 = ref array[15];
				reference16 = new PointF(float_3 + num5, float_4 + num8);
				ref PointF reference17 = ref array[16];
				reference17 = new PointF(float_3 + num5, float_4 + num7 + num + num3);
				ref PointF reference18 = ref array[17];
				reference18 = new PointF(float_3 + num23, float_4 + num7 + num + num3);
				ref PointF reference19 = ref array[18];
				reference19 = new PointF(float_3 + num24, float_4 + num7 + num);
				ref PointF reference20 = ref array[19];
				reference20 = new PointF(float_3 + num5, float_4 + num7 + num);
			}
			else
			{
				ref PointF reference21 = ref array[0];
				reference21 = new PointF(float_3 + num5, float_4 + num7);
				ref PointF reference22 = ref array[1];
				reference22 = new PointF(float_3 + num22 - num12, float_4 + num7);
				ref PointF reference23 = ref array[2];
				reference23 = new PointF(float_3 + num16 + num15, float_4);
				ref PointF reference24 = ref array[3];
				reference24 = new PointF(float_3 + num16 + num15 + num10, float_4 + num9);
				ref PointF reference25 = ref array[4];
				reference25 = new PointF(float_3 + num17, float_4 + num7);
				ref PointF reference26 = ref array[5];
				reference26 = new PointF(float_3 + num6, float_4 + num7);
				ref PointF reference27 = ref array[6];
				reference27 = new PointF(float_3 + num6, float_4 + num7 + num);
				ref PointF reference28 = ref array[7];
				reference28 = new PointF(float_3 + num18, float_4 + num7 + num);
				ref PointF reference29 = ref array[8];
				reference29 = new PointF(float_3 + num19, float_4 + num7 + num + num3);
				ref PointF reference30 = ref array[9];
				reference30 = new PointF(float_3 + num6, float_4 + num7 + num + num3);
				ref PointF reference31 = ref array[10];
				reference31 = new PointF(float_3 + num6, float_4 + num7 + 2f * num + num3);
				ref PointF reference32 = ref array[11];
				reference32 = new PointF(float_3 + num20, float_4 + num7 + 2f * num + num3);
				ref PointF reference33 = ref array[12];
				reference33 = new PointF(float_3 + num21, float_4 + rectangleF_0.Height);
				ref PointF reference34 = ref array[13];
				reference34 = new PointF(float_3 + num16 - num12, float_4 + rectangleF_0.Height - num9);
				ref PointF reference35 = ref array[14];
				reference35 = new PointF(float_3 + num16, float_4 + num8);
				ref PointF reference36 = ref array[15];
				reference36 = new PointF(float_3 + num5, float_4 + num8);
				ref PointF reference37 = ref array[16];
				reference37 = new PointF(float_3 + num5, float_4 + num7 + num + num3);
				ref PointF reference38 = ref array[17];
				reference38 = new PointF(float_3 + num23 - num12, float_4 + num7 + num + num3);
				ref PointF reference39 = ref array[18];
				reference39 = new PointF(float_3 + num24 - num12, float_4 + num7 + num);
				ref PointF reference40 = ref array[19];
				reference40 = new PointF(float_3 + num5, float_4 + num7 + num);
			}
			graphicsPath.AddLine(array[0], array[1]);
			graphicsPath.AddLine(array[1], array[2]);
			graphicsPath.AddLine(array[2], array[3]);
			graphicsPath.AddLine(array[3], array[4]);
			graphicsPath.AddLine(array[4], array[5]);
			graphicsPath.AddLine(array[5], array[6]);
			graphicsPath.AddLine(array[6], array[7]);
			graphicsPath.AddLine(array[7], array[8]);
			graphicsPath.AddLine(array[8], array[9]);
			graphicsPath.AddLine(array[9], array[10]);
			graphicsPath.AddLine(array[10], array[11]);
			graphicsPath.AddLine(array[11], array[12]);
			graphicsPath.AddLine(array[12], array[13]);
			graphicsPath.AddLine(array[13], array[14]);
			graphicsPath.AddLine(array[15], array[16]);
			graphicsPath.AddLine(array[16], array[17]);
			graphicsPath.AddLine(array[17], array[18]);
			graphicsPath.AddLine(array[18], array[19]);
			graphicsPath.AddLine(array[19], array[0]);
			graphicsPath.CloseFigure();
		}
		return graphicsPath;
	}
}
