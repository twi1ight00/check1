using System;
using System.Drawing;
using ns224;

namespace ns218;

internal static class Class5955
{
	public const double double_0 = 32767.99998474121;

	public const double double_1 = -32768.99998474121;

	public const double double_2 = 25.4;

	private const double double_3 = 72.0;

	public const float float_0 = 0.71999997f;

	public const float float_1 = 0.072000004f;

	private const double double_4 = 2.834645669291339;

	public const float float_2 = 0.28346458f;

	public const float float_3 = 0.028346457f;

	public const float float_4 = 0.0028346458f;

	private const double double_5 = 28.34645669291339;

	private const double double_6 = 12.0;

	public const double double_7 = 20.0;

	private const double double_8 = 1440.0;

	private const double double_9 = 56.69291338582678;

	private const double double_10 = 240.0;

	public const double double_11 = 0.05;

	public const double double_12 = 12700.0;

	private const double double_13 = 914400.0;

	private const double double_14 = 36000.00000000001;

	private const double double_15 = 635.0;

	public const int int_0 = 1000;

	private const int int_1 = 72000;

	public const int int_2 = 50;

	private const int int_3 = 500;

	public const double double_16 = 1584.0;

	public const int int_4 = 1584000;

	public const double double_17 = 60000.0;

	public static double smethod_0(double points)
	{
		return smethod_1(points, 96.0);
	}

	public static double smethod_1(double points, double resolution)
	{
		return points / 72.0 * resolution;
	}

	public static int smethod_2(double points)
	{
		return Class5964.smethod_29(smethod_0(points));
	}

	public static int smethod_3(double points, double resolution)
	{
		return Class5964.smethod_29(smethod_1(points, resolution));
	}

	public static int smethod_4(double points, double resolution)
	{
		return Math.Max((int)Math.Ceiling(smethod_1(points, resolution)), 1);
	}

	public static Size smethod_5(SizeF sizePoints, float scale, double dpi)
	{
		if (scale <= 0f)
		{
			throw new ArgumentOutOfRangeException("scale");
		}
		if (dpi <= 0.0)
		{
			throw new ArgumentOutOfRangeException("dpi");
		}
		return new Size(smethod_3(sizePoints.Width * scale, dpi), smethod_3(sizePoints.Height * scale, dpi));
	}

	public static double smethod_6(double points)
	{
		return points / 0.002834645882776876;
	}

	public static int smethod_7(double points)
	{
		return Class5964.smethod_29(smethod_6(points));
	}

	public static double smethod_8(double pixels)
	{
		return smethod_10(pixels, 96.0);
	}

	public static RectangleF smethod_9(RectangleF rectInPixel)
	{
		return RectangleF.FromLTRB((float)smethod_8(rectInPixel.Left), (float)smethod_8(rectInPixel.Top), (float)smethod_8(rectInPixel.Right), (float)smethod_8(rectInPixel.Bottom));
	}

	public static double smethod_10(double pixels, double resolution)
	{
		return pixels / resolution * 72.0;
	}

	public static int smethod_11(double pixels, double resolution)
	{
		return Class5964.smethod_29(pixels / resolution * 1440.0);
	}

	public static int smethod_12(double pixels, double oldDpi, double newDpi)
	{
		return Class5964.smethod_29(pixels * newDpi / oldDpi);
	}

	public static double smethod_13(double inches)
	{
		return inches * 72.0;
	}

	public static double smethod_14(double points)
	{
		return points / 72.0;
	}

	public static double smethod_15(double mm)
	{
		return mm * 2.834645669291339;
	}

	public static int smethod_16(double mm)
	{
		return Class5964.smethod_29(mm * 56.69291338582678);
	}

	public static int smethod_17(double mm)
	{
		return Class5964.smethod_29(smethod_18(mm));
	}

	public static double smethod_18(double mm)
	{
		return mm * 96.0 / 25.4;
	}

	public static double smethod_19(double inches)
	{
		return inches * 96.0;
	}

	public static double smethod_20(double cm)
	{
		return cm * 28.34645669291339;
	}

	public static double smethod_21(double lines)
	{
		return lines * 12.0;
	}

	public static int smethod_22(int lineHundredths)
	{
		return Class5964.smethod_29((double)lineHundredths * 240.0 / 100.0);
	}

	public static double smethod_23(double points)
	{
		return points / 12.0;
	}

	public static int smethod_24(double points)
	{
		return Class5964.smethod_29(points * 2.0);
	}

	public static double smethod_25(int halfPoints)
	{
		return (double)halfPoints / 2.0;
	}

	public static int smethod_26(double points)
	{
		return Class5964.smethod_29(points * 8.0);
	}

	public static double smethod_27(int eightsPoints)
	{
		return (double)eightsPoints / 8.0;
	}

	public static int smethod_28(int eightsPoint)
	{
		return Class5964.smethod_29((double)eightsPoint * 2.5);
	}

	public static int smethod_29(double points)
	{
		return Class5964.smethod_29(points * 20.0);
	}

	public static double smethod_30(int twips)
	{
		return (double)twips / 20.0;
	}

	public static double smethod_31(double twips)
	{
		return twips / 20.0;
	}

	public static double smethod_32(int twips)
	{
		return (double)twips / 56.69291338582678;
	}

	public static double smethod_33(int twips)
	{
		return (double)twips / 240.0;
	}

	public static int smethod_34(int twips)
	{
		return smethod_2(smethod_30(twips));
	}

	public static int smethod_35(double inches)
	{
		return Class5964.smethod_29(inches * 1440.0);
	}

	public static int smethod_36(int emus)
	{
		return Class5964.smethod_29((double)emus / 635.0);
	}

	public static int smethod_37(int twips)
	{
		return Class5964.smethod_29((double)twips * 635.0);
	}

	public static int smethod_38(double points)
	{
		return Class5964.smethod_29(points * 12700.0);
	}

	public static RectangleF smethod_39(RectangleF rectInPoints)
	{
		return RectangleF.FromLTRB(smethod_38(rectInPoints.Left), smethod_38(rectInPoints.Top), smethod_38(rectInPoints.Right), smethod_38(rectInPoints.Bottom));
	}

	public static double smethod_40(int emus)
	{
		return (double)emus / 12700.0;
	}

	public static double smethod_41(double emus)
	{
		return emus / 12700.0;
	}

	public static RectangleF smethod_42(RectangleF rectInEmu)
	{
		return new RectangleF((float)smethod_41(rectInEmu.Left), (float)smethod_41(rectInEmu.Top), (float)smethod_41(rectInEmu.Width), (float)smethod_41(rectInEmu.Height));
	}

	public static double smethod_43(int pixels)
	{
		return smethod_38(smethod_8(pixels));
	}

	public static double smethod_44(int pixels, double resolution)
	{
		return smethod_38(smethod_10(pixels, resolution));
	}

	public static RectangleF smethod_45(RectangleF rectInPixels, double resolution)
	{
		return RectangleF.FromLTRB((float)smethod_44((int)rectInPixels.Left, resolution), (float)smethod_44((int)rectInPixels.Top, resolution), (float)smethod_44((int)rectInPixels.Right, resolution), (float)smethod_44((int)rectInPixels.Bottom, resolution));
	}

	public static RectangleF smethod_46(RectangleF rectInPixels)
	{
		return new RectangleF((float)smethod_43((int)rectInPixels.Left), (float)smethod_43((int)rectInPixels.Top), (float)smethod_43((int)rectInPixels.Width), (float)smethod_43((int)rectInPixels.Height));
	}

	public static double smethod_47(int emus)
	{
		return (double)emus / 914400.0;
	}

	public static float smethod_48(int emu)
	{
		return (float)smethod_0((double)emu / 12700.0);
	}

	public static RectangleF smethod_49(RectangleF rectInEmu)
	{
		return RectangleF.FromLTRB(smethod_48((int)rectInEmu.Left), smethod_48((int)rectInEmu.Top), smethod_48((int)rectInEmu.Right), smethod_48((int)rectInEmu.Bottom));
	}

	public static double smethod_50(int emus)
	{
		return (double)emus / 36000.00000000001;
	}

	public static int smethod_51(double lis, double resolution)
	{
		return Class5964.smethod_29(resolution * lis / 72000.0);
	}

	public static int smethod_52(int width)
	{
		return smethod_51(width, 96.0);
	}

	public static int smethod_53(double points)
	{
		return Class5964.smethod_29(points * 1000.0);
	}

	public static float smethod_54(int lis)
	{
		return (float)lis / 1000f;
	}

	public static int smethod_55(int twips)
	{
		return twips * 50;
	}

	public static int smethod_56(int lis)
	{
		return lis / 50;
	}

	public static int smethod_57(double halfPoints)
	{
		return Class5964.smethod_29(halfPoints * 500.0);
	}

	public static float smethod_58(int lis)
	{
		return (float)lis / 500f;
	}

	public static RectangleF smethod_59(Rectangle li)
	{
		return new RectangleF(smethod_54(li.X), smethod_54(li.Y), smethod_54(li.Width), smethod_54(li.Height));
	}

	public static PointF smethod_60(Point li)
	{
		return new PointF(smethod_54(li.X), smethod_54(li.Y));
	}

	public static SizeF smethod_61(Size li)
	{
		return new SizeF(smethod_54(li.Width), smethod_54(li.Height));
	}

	public static Rectangle smethod_62(RectangleF pt)
	{
		return new Rectangle(smethod_53(pt.X), smethod_53(pt.Y), smethod_53(pt.Width), smethod_53(pt.Height));
	}

	public static Point smethod_63(PointF pt)
	{
		return new Point(smethod_53(pt.X), smethod_53(pt.Y));
	}

	public static float smethod_64(int lis)
	{
		return (float)lis / 1000f / 12f;
	}

	public static Class5998 smethod_65(Class5998 color)
	{
		if (!color.IsEmpty)
		{
			return new Class5998(color.R, color.G, color.B);
		}
		return color;
	}

	public static double smethod_66(int value)
	{
		return (double)value / 65536.0;
	}

	public static int smethod_67(double value)
	{
		if (value > 32767.99998474121)
		{
			value = 32767.99998474121;
		}
		else if (value < -32768.99998474121)
		{
			value = -32768.99998474121;
		}
		return Class5964.smethod_29(value * 65536.0);
	}

	public static double smethod_68(double dmlAngle)
	{
		return Class5963.smethod_0(dmlAngle / 60000.0);
	}

	public static double smethod_69(double value)
	{
		return Class5963.smethod_1(value) * 60000.0;
	}

	public static double smethod_70(double value)
	{
		return value * 60000.0;
	}

	public static double smethod_71(double value)
	{
		return value / 60000.0;
	}
}
