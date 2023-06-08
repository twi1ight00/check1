using System;
using System.Drawing;
using ns19;

namespace ns5;

internal class Class136 : Class18
{
	internal Class136(Interface42 interface42_1, float float_5, float float_6, Class898 class898_1)
		: base(interface42_1, float_5, float_6, class898_1)
	{
	}

	internal override void vmethod_3()
	{
		if (class898_0.Line.method_0())
		{
			return;
		}
		Pen pen_ = Struct69.smethod_4(class898_0.Line);
		double num = class898_0.Line.Weight;
		double num2 = 0.0;
		switch (class898_0.Line.method_2())
		{
		case Enum95.const_1:
		case Enum95.const_2:
			num2 = 0.0;
			break;
		case Enum95.const_3:
			num2 = 0.0;
			break;
		case Enum95.const_4:
			num2 = 0.0;
			break;
		case Enum95.const_5:
			num2 = num * 0.6000000238418579;
			break;
		}
		double num3 = 0.0;
		switch (class898_0.Line.method_8())
		{
		case Enum95.const_1:
		case Enum95.const_2:
			num3 = 0.0;
			break;
		case Enum95.const_3:
			num3 = 0.0;
			break;
		case Enum95.const_4:
			num3 = 0.0;
			break;
		case Enum95.const_5:
			num3 = num * 0.6000000238418579;
			break;
		}
		PointF pointF;
		PointF pointF2;
		if (class898_0.Width == 0f)
		{
			pointF = new PointF(class898_0.method_22().X + class898_0.method_22().Width / 2f, class898_0.method_22().Y);
			pointF2 = new PointF(class898_0.method_22().X + class898_0.method_22().Width / 2f, class898_0.method_7().Bottom);
			if (class898_0.int_2 != 1 && class898_0.int_2 != 4)
			{
				pointF2.Y -= (float)num2;
				pointF.Y += (float)num3;
				interface42_0.imethod_15(pen_, pointF2, pointF);
			}
			else
			{
				pointF.Y += (float)num2;
				pointF2.Y -= (float)num3;
				interface42_0.imethod_15(pen_, pointF, pointF2);
			}
			return;
		}
		if (class898_0.Height == 0f)
		{
			pointF = new PointF(class898_0.X, class898_0.Y - class898_0.method_22().Height / 2f);
			pointF2 = new PointF(class898_0.X + class898_0.Width, class898_0.Y - class898_0.method_22().Height / 2f);
			if (class898_0.int_2 != 1 && class898_0.int_2 != 2)
			{
				pointF2.X -= (float)num2;
				pointF.X += (float)num3;
				interface42_0.imethod_15(pen_, pointF2, pointF);
			}
			else
			{
				pointF.X += (float)num2;
				pointF2.X -= (float)num3;
				interface42_0.imethod_15(pen_, pointF, pointF2);
			}
			return;
		}
		double num4 = Math.Sqrt(Math.Pow(class898_0.Width, 2.0) + Math.Pow(class898_0.Height, 2.0));
		double num5 = (double)class898_0.Width * num2 / num4;
		double num6 = (double)class898_0.Height * num2 / num4;
		double num7 = (double)class898_0.Width * num3 / num4;
		double num8 = (double)class898_0.Height * num3 / num4;
		PointF pointF3 = new PointF(class898_0.method_22().X, class898_0.method_22().Y);
		PointF pointF4 = new PointF(class898_0.method_22().X, class898_0.method_22().Y + class898_0.Height);
		PointF pointF5 = new PointF(class898_0.method_22().X + class898_0.Width, class898_0.method_22().Y + class898_0.Height);
		PointF pointF6 = new PointF(class898_0.method_22().X + class898_0.Width, class898_0.method_22().Y);
		if (class898_0.int_2 == 1)
		{
			pointF3.X += (float)num5;
			pointF3.Y += (float)num6;
			pointF5.X -= (float)num7;
			pointF5.Y -= (float)num8;
			interface42_0.imethod_15(pen_, pointF3, pointF5);
			class898_0.pointF_1 = pointF3;
			class898_0.pointF_2 = pointF5;
		}
		else if (class898_0.int_2 == 2)
		{
			pointF4.X += (float)num5;
			pointF4.Y -= (float)num6;
			pointF6.X -= (float)num7;
			pointF6.Y += (float)num8;
			interface42_0.imethod_15(pen_, pointF4, pointF6);
			class898_0.pointF_1 = pointF4;
			class898_0.pointF_2 = pointF6;
		}
		else if (class898_0.int_2 == 3)
		{
			pointF5.X -= (float)num5;
			pointF5.Y -= (float)num6;
			pointF3.X += (float)num7;
			pointF3.Y += (float)num8;
			interface42_0.imethod_15(pen_, pointF5, pointF3);
			class898_0.pointF_1 = pointF5;
			class898_0.pointF_2 = pointF3;
		}
		else
		{
			pointF6.X -= (float)num5;
			pointF6.Y += (float)num6;
			pointF4.X += (float)num7;
			pointF4.Y -= (float)num8;
			interface42_0.imethod_15(pen_, pointF6, pointF4);
			class898_0.pointF_1 = pointF6;
			class898_0.pointF_2 = pointF4;
		}
	}
}
