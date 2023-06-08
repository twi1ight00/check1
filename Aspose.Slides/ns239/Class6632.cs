using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ns239;

internal class Class6632
{
	private const int int_0 = 1440;

	public const string string_0 = "{";

	public const string string_1 = "}";

	public const string string_2 = " ";

	private static Graphics graphics_0 = Graphics.FromImage(new Bitmap(1, 1));

	public static readonly float float_0 = graphics_0.DpiX;

	public static readonly float float_1 = graphics_0.DpiY;

	public static PointF smethod_0(PointF point)
	{
		PointF result = default(PointF);
		result.X = 1440f / float_0 * point.X;
		result.Y = 1440f / float_1 * point.Y;
		return result;
	}

	public static SizeF smethod_1(SizeF size)
	{
		SizeF result = default(SizeF);
		result.Width = 1440f / float_0 * size.Width;
		result.Height = 1440f / float_1 * size.Height;
		return result;
	}

	public static RectangleF smethod_2(RectangleF rect)
	{
		RectangleF result = default(RectangleF);
		result.X = 1440f / float_0 * rect.X;
		result.Y = 1440f / float_1 * rect.Y;
		result.Width = 1440f / float_0 * rect.Width;
		result.Height = 1440f / float_1 * rect.Height;
		return result;
	}

	public static SizeF smethod_3(PointF startPoint, PointF controlPoint1, PointF controlPoint2, PointF EndPoint)
	{
		List<PointF> list = new List<PointF>();
		list.Add(startPoint);
		list.Add(controlPoint1);
		list.Add(controlPoint2);
		list.Add(EndPoint);
		return smethod_4(list);
	}

	public static SizeF smethod_4(List<PointF> points)
	{
		SizeF result = default(SizeF);
		foreach (PointF point in points)
		{
			if (point.X > result.Width)
			{
				result.Width = point.X;
			}
			if (point.Y > result.Height)
			{
				result.Height = point.Y;
			}
		}
		return result;
	}

	public static byte[] smethod_5(Image image)
	{
		MemoryStream memoryStream = new MemoryStream();
		image.Save(memoryStream, ImageFormat.Bmp);
		return memoryStream.ToArray();
	}
}
