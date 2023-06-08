using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using ns47;

namespace ns22;

internal class Class1181
{
	internal static int[] smethod_0(bool bool_0, byte[] byte_0, int int_0)
	{
		MemoryStream memoryStream = new MemoryStream(byte_0);
		Image image = Image.FromStream(memoryStream);
		int[] array = new int[2];
		bool flag = (image.Flags & 0x1000) == 4096;
		double num = 96.0;
		double num2 = 96.0;
		if (flag)
		{
			num = image.HorizontalResolution;
			num2 = image.VerticalResolution;
		}
		if (bool_0)
		{
			if (flag)
			{
				array[0] = (int)((double)(image.Width * int_0) / num + 0.5);
				array[1] = (int)((double)(image.Height * int_0) / num2 + 0.5);
			}
			else
			{
				array[0] = image.Width;
				array[1] = image.Height;
			}
		}
		else
		{
			array[0] = (int)((double)(image.Width * int_0) / num + 0.5);
			array[1] = (int)((double)(image.Height * int_0) / num2 + 0.5);
		}
		image.Dispose();
		memoryStream.Close();
		return array;
	}

	internal static RectangleF smethod_1(GraphicsPath graphicsPath_0)
	{
		return graphicsPath_0.GetBounds();
	}

	internal static Size smethod_2(Size size_0)
	{
		return new Size(size_0.Width, size_0.Height);
	}

	internal static RectangleF smethod_3(RectangleF rectangleF_0)
	{
		return new RectangleF(rectangleF_0.X, rectangleF_0.Y, rectangleF_0.Width, rectangleF_0.Height);
	}

	internal static Rectangle smethod_4(Rectangle rectangle_0)
	{
		return new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width, rectangle_0.Height);
	}

	internal static RectangleF smethod_5(Rectangle rectangle_0)
	{
		return rectangle_0;
	}

	internal static SizeF smethod_6(Size size_0)
	{
		return size_0;
	}

	internal static Class1460 smethod_7(string string_0, FontStyle fontStyle_0)
	{
		return Class1462.smethod_3(string_0, fontStyle_0, bool_0: false);
	}

	internal static int smethod_8(string string_0, Class1460 class1460_0, int int_0)
	{
		return class1460_0.method_44(string_0, int_0);
	}

	internal static int smethod_9(string string_0, string string_1, int int_0, FontStyle fontStyle_0)
	{
		Class1460 @class = Class1462.smethod_3(string_1, fontStyle_0, bool_0: false);
		return @class.method_44(string_0, int_0);
	}

	internal static float smethod_10(char char_0, Class1460 class1460_0, int int_0)
	{
		return class1460_0.method_42(char_0, int_0);
	}

	internal static float smethod_11(char char_0, string string_0, int int_0, FontStyle fontStyle_0)
	{
		Class1460 @class = Class1462.smethod_3(string_0, fontStyle_0, bool_0: false);
		return @class.method_42(char_0, int_0);
	}
}
