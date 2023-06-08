using System;
using System.Drawing;
using ns218;
using ns223;
using ns234;

namespace ns233;

internal class Class6145
{
	private readonly double double_0;

	private readonly double double_1;

	private readonly double double_2;

	private readonly double double_3;

	public bool IsEmpty
	{
		get
		{
			if (double_0 == 0.0 && double_1 == 0.0 && double_2 == 0.0)
			{
				return double_3 == 0.0;
			}
			return false;
		}
	}

	public bool HasPositiveCrop
	{
		get
		{
			if (!(double_0 > 0.0) && !(double_1 > 0.0) && !(double_2 > 0.0))
			{
				return double_3 > 0.0;
			}
			return true;
		}
	}

	public bool HasNegativeCrop
	{
		get
		{
			if (!(double_0 < 0.0) && !(double_1 < 0.0) && !(double_2 < 0.0))
			{
				return double_3 < 0.0;
			}
			return true;
		}
	}

	internal double CropLeft => double_0;

	internal double CropRight => double_1;

	internal double CropTop => double_2;

	internal double CropBottom => double_3;

	public Class6145(double cropLeft, double cropRight, double cropTop, double cropBottom)
	{
		double_0 = cropLeft;
		double_1 = cropRight;
		double_2 = cropTop;
		double_3 = cropBottom;
	}

	public RectangleF method_0(RectangleF srcRect)
	{
		double num = (double)srcRect.Left + (double)srcRect.Width * double_0;
		double num2 = (double)srcRect.Left + (double)srcRect.Width * (1.0 - double_1);
		double num3 = (double)srcRect.Top + (double)srcRect.Height * double_2;
		double num4 = (double)srcRect.Top + (double)srcRect.Height * (1.0 - double_3);
		return RectangleF.FromLTRB((float)num, (float)num3, (float)num2, (float)num4);
	}

	public Rectangle method_1(Rectangle srcRect)
	{
		double value = (double)srcRect.Left + (double)srcRect.Width * Math.Max(0.0, double_0);
		double value2 = (double)srcRect.Left + (double)srcRect.Width * (1.0 - Math.Max(0.0, double_1));
		double value3 = (double)srcRect.Top + (double)srcRect.Height * Math.Max(0.0, double_2);
		double value4 = (double)srcRect.Top + (double)srcRect.Height * (1.0 - Math.Max(0.0, double_3));
		return Rectangle.FromLTRB(Class5964.smethod_29(value), Class5964.smethod_29(value3), Class5964.smethod_29(value2), Class5964.smethod_29(value4));
	}

	public RectangleF method_2(RectangleF dstRect)
	{
		double num = 1.0 / (1.0 - Math.Min(0.0, double_0 + double_1));
		double num2 = 1.0 / (1.0 - Math.Min(0.0, double_2 + double_3));
		double num3 = 0.0 - Math.Min(0.0, double_0);
		double num4 = 0.0 - Math.Min(0.0, double_1);
		double num5 = 0.0 - Math.Min(0.0, double_2);
		double num6 = 0.0 - Math.Min(0.0, double_3);
		double num7 = (double)dstRect.Left + (double)dstRect.Width * num3 * num;
		double num8 = (double)dstRect.Left + (double)dstRect.Width * (1.0 - num4 * num);
		double num9 = (double)dstRect.Top + (double)dstRect.Height * num5 * num2;
		double num10 = (double)dstRect.Top + (double)dstRect.Height * (1.0 - num6 * num2);
		return RectangleF.FromLTRB((float)num7, (float)num9, (float)num8, (float)num10);
	}

	public Class6150 method_3(byte[] imageBytes)
	{
		using Class6150 @class = new Class6150(imageBytes);
		Rectangle srcRect = method_1(new Rectangle(0, 0, @class.Width, @class.Height));
		return @class.method_6(srcRect);
	}

	public override int GetHashCode()
	{
		return (Class6157.GetHashCode(double_0) >> 1) ^ (Class6157.GetHashCode(double_1) << 3) ^ (Class6157.GetHashCode(double_2) << 1) ^ (Class6157.GetHashCode(double_3) >> 3);
	}

	public static bool smethod_0(Class6145 crop)
	{
		return crop?.IsEmpty ?? true;
	}

	public static int smethod_1(byte[] imageBytes, Class6145 crop)
	{
		int hashCode = Class5981.smethod_0(imageBytes).GetHashCode();
		int num = ((crop != null && crop.HasPositiveCrop) ? crop.GetHashCode() : 0);
		return hashCode ^ num;
	}

	public static int smethod_2(byte[] imageBytes, Class6145 crop, Class6140 chromaKey)
	{
		int num = smethod_1(imageBytes, crop);
		if (chromaKey != null)
		{
			num = (num * 397) ^ chromaKey.GetHashCode();
		}
		return num;
	}
}
