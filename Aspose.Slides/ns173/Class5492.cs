using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using ns171;
using ns176;
using ns205;

namespace ns173;

internal class Class5492
{
	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	private static Class5492 class5492_0 = new Class5492(1.0, 0.0, 0.0, 1.0, 0.0, 0.0);

	private static Class5492 class5492_1 = new Class5492(1.0, 0.0, 0.0, 1.0, 0.0, 0.0);

	private static Class5492 class5492_2 = new Class5492(0.0, 1.0, -1.0, 0.0, 0.0, 0.0);

	public Class5492()
	{
		double_0 = 1.0;
		double_1 = 0.0;
		double_2 = 0.0;
		double_3 = 1.0;
		double_4 = 0.0;
		double_5 = 0.0;
	}

	public Class5492(double a, double b, double c, double d, double e, double f)
	{
		double_0 = a;
		double_1 = b;
		double_2 = c;
		double_3 = d;
		double_4 = e;
		double_5 = f;
	}

	public Class5492(double x, double y)
	{
		double_0 = 1.0;
		double_1 = 0.0;
		double_2 = 0.0;
		double_3 = 1.0;
		double_4 = x;
		double_5 = y;
	}

	protected Class5492(Class5492 ctm)
	{
		double_0 = ctm.double_0;
		double_1 = ctm.double_1;
		double_2 = ctm.double_2;
		double_3 = ctm.double_3;
		double_4 = ctm.double_4;
		double_5 = ctm.double_5;
	}

	public Class5492(Matrix at)
	{
		float[] array = new float[6];
		array = at.Elements;
		double_0 = array[0];
		double_1 = array[1];
		double_2 = array[2];
		double_3 = array[3];
		double_4 = array[4];
		double_5 = array[5];
	}

	public static Class5492 smethod_0(Class5445 wm, int ipd, int bpd)
	{
		switch ((Enum679)wm.method_1())
		{
		case Enum679.const_208:
			return new Class5492(class5492_1);
		case Enum679.const_80:
			return new Class5492(class5492_0);
		default:
			return null;
		case Enum679.const_227:
		case Enum679.const_292:
		{
			Class5492 @class = new Class5492(class5492_2);
			@class.double_4 = bpd;
			return @class;
		}
		}
	}

	public Class5492 method_0(Class5492 premult)
	{
		return new Class5492(premult.double_0 * double_0 + premult.double_1 * double_2, premult.double_0 * double_1 + premult.double_1 * double_3, premult.double_2 * double_0 + premult.double_3 * double_2, premult.double_2 * double_1 + premult.double_3 * double_3, premult.double_4 * double_0 + premult.double_5 * double_2 + double_4, premult.double_4 * double_1 + premult.double_5 * double_3 + double_5);
	}

	public Class5492 method_1(double angle)
	{
		double num2;
		double num3;
		if (angle != 90.0 && angle != -270.0)
		{
			if (angle != 270.0 && angle != -90.0)
			{
				if (angle != 180.0 && angle != -180.0)
				{
					double num = angle * 0.017444;
					num2 = Math.Cos(num);
					num3 = Math.Sin(num);
				}
				else
				{
					num2 = -1.0;
					num3 = 0.0;
				}
			}
			else
			{
				num2 = 0.0;
				num3 = -1.0;
			}
		}
		else
		{
			num2 = 0.0;
			num3 = 1.0;
		}
		Class5492 premult = new Class5492(num2, 0.0 - num3, num3, num2, 0.0, 0.0);
		return method_0(premult);
	}

	public Class5492 method_2(double x, double y)
	{
		Class5492 premult = new Class5492(1.0, 0.0, 0.0, 1.0, x, y);
		return method_0(premult);
	}

	public Class5492 method_3(double x, double y)
	{
		Class5492 premult = new Class5492(x, 0.0, 0.0, y, 0.0, 0.0);
		return method_0(premult);
	}

	public RectangleF method_4(RectangleF inRect)
	{
		int num = (int)((double)inRect.X * double_0 + (double)inRect.Y * double_2 + double_4);
		int num2 = (int)((double)inRect.X * double_1 + (double)inRect.Y * double_3 + double_5);
		int num3 = (int)((double)(inRect.X + inRect.Width) * double_0 + (double)(inRect.Y + inRect.Height) * double_2 + double_4);
		int num4 = (int)((double)(inRect.X + inRect.Width) * double_1 + (double)(inRect.Y + inRect.Height) * double_3 + double_5);
		if (num > num3)
		{
			int num5 = num3;
			num3 = num;
			num = num5;
		}
		if (num2 > num4)
		{
			int num6 = num4;
			num4 = num2;
			num2 = num6;
		}
		return new Rectangle(num, num2, num3 - num, num4 - num2);
	}

	public override string ToString()
	{
		return "[" + double_0 + " " + double_1 + " " + double_2 + " " + double_3 + " " + double_4 + " " + double_5 + "]";
	}

	public double[] method_5()
	{
		return new double[6] { double_0, double_1, double_2, double_3, double_4, double_5 };
	}

	public Matrix method_6()
	{
		double[] array = method_5();
		return new Matrix((float)array[0], (float)array[1], (float)array[2], (float)array[3], (float)array[4], (float)array[5]);
	}

	public static Class5492 smethod_1(int absRefOrient, Class5445 writingMode, RectangleF absVPrect, Class5728 reldims)
	{
		int num;
		int num2;
		if (absRefOrient % 180 == 0)
		{
			num = (int)absVPrect.Width;
			num2 = (int)absVPrect.Height;
		}
		else
		{
			num2 = (int)absVPrect.Width;
			num = (int)absVPrect.Height;
		}
		Class5492 @class = new Class5492(absVPrect.X, absVPrect.Y);
		if (absRefOrient != 0)
		{
			switch (absRefOrient)
			{
			default:
				throw new Exception();
			case -90:
			case 270:
				@class = @class.method_2(num2, 0.0);
				break;
			case -180:
			case 180:
				@class = @class.method_2(num, num2);
				break;
			case -270:
			case 90:
				@class = @class.method_2(0.0, num);
				break;
			}
			@class = @class.method_1(absRefOrient);
		}
		switch ((Enum679)writingMode.method_1())
		{
		default:
			reldims.int_0 = num;
			reldims.int_1 = num2;
			break;
		case Enum679.const_227:
		case Enum679.const_292:
			reldims.int_0 = num2;
			reldims.int_1 = num;
			break;
		}
		return @class.method_0(smethod_0(writingMode, reldims.int_0, reldims.int_1));
	}
}
