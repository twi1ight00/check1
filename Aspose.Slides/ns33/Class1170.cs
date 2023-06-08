using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ns224;

namespace ns33;

internal class Class1170
{
	private static readonly int[] int_0 = new int[511]
	{
		0, 1, 1, 2, 2, 2, 3, 3, 4, 4,
		4, 5, 5, 6, 6, 6, 7, 7, 8, 8,
		8, 9, 9, 10, 10, 10, 11, 11, 11, 12,
		12, 13, 13, 13, 14, 14, 15, 15, 15, 16,
		16, 17, 17, 17, 18, 18, 19, 19, 19, 20,
		20, 20, 21, 21, 22, 22, 22, 23, 23, 24,
		24, 24, 25, 25, 26, 26, 26, 27, 27, 28,
		28, 28, 29, 29, 30, 30, 30, 31, 31, 31,
		32, 32, 33, 33, 33, 34, 34, 35, 35, 35,
		36, 36, 37, 37, 37, 38, 38, 39, 39, 39,
		40, 40, 40, 41, 41, 42, 42, 42, 43, 43,
		44, 44, 44, 45, 45, 46, 46, 46, 47, 47,
		48, 48, 48, 49, 49, 50, 50, 50, 51, 51,
		51, 52, 52, 53, 53, 53, 54, 54, 55, 55,
		55, 56, 56, 57, 57, 57, 58, 58, 59, 59,
		59, 60, 60, 60, 61, 61, 62, 62, 62, 63,
		63, 64, 64, 64, 65, 65, 66, 66, 66, 67,
		67, 68, 68, 68, 69, 69, 70, 70, 70, 71,
		71, 71, 72, 72, 73, 73, 73, 74, 74, 75,
		75, 75, 76, 76, 77, 77, 77, 78, 78, 79,
		79, 79, 80, 80, 80, 81, 81, 82, 82, 82,
		83, 83, 84, 84, 84, 85, 85, 86, 86, 86,
		87, 87, 88, 88, 88, 89, 89, 90, 90, 90,
		91, 91, 91, 92, 92, 93, 93, 93, 94, 94,
		95, 95, 95, 96, 96, 97, 97, 97, 98, 98,
		98, 99, 99, 99, 99, 100, 99, 99, 99, 99,
		98, 98, 98, 97, 97, 97, 96, 96, 95, 95,
		95, 94, 94, 93, 93, 93, 92, 92, 91, 91,
		91, 90, 90, 90, 89, 89, 88, 88, 88, 87,
		87, 86, 86, 86, 85, 85, 84, 84, 84, 83,
		83, 82, 82, 82, 81, 81, 80, 80, 80, 79,
		79, 79, 78, 78, 77, 77, 77, 76, 76, 75,
		75, 75, 74, 74, 73, 73, 73, 72, 72, 71,
		71, 71, 70, 70, 70, 69, 69, 68, 68, 68,
		67, 67, 66, 66, 66, 65, 65, 64, 64, 64,
		63, 63, 62, 62, 62, 61, 61, 60, 60, 60,
		59, 59, 59, 58, 58, 57, 57, 57, 56, 56,
		55, 55, 55, 54, 54, 53, 53, 53, 52, 52,
		51, 51, 51, 50, 50, 50, 49, 49, 48, 48,
		48, 47, 47, 46, 46, 46, 45, 45, 44, 44,
		44, 43, 43, 42, 42, 42, 41, 41, 40, 40,
		40, 39, 39, 39, 38, 38, 37, 37, 37, 36,
		36, 35, 35, 35, 34, 34, 33, 33, 33, 32,
		32, 31, 31, 31, 30, 30, 30, 29, 29, 28,
		28, 28, 27, 27, 26, 26, 26, 25, 25, 24,
		24, 24, 23, 23, 22, 22, 22, 21, 21, 20,
		20, 20, 19, 19, 19, 18, 18, 17, 17, 17,
		16, 16, 15, 15, 15, 14, 14, 13, 13, 13,
		12, 12, 11, 11, 11, 10, 10, 10, 9, 9,
		8, 8, 8, 7, 7, 6, 6, 6, 5, 5,
		4, 4, 4, 3, 3, 2, 2, 2, 1, 1,
		0
	};

	internal static Class6002 smethod_0(Matrix matrix)
	{
		return new Class6002(matrix.Elements[0], matrix.Elements[1], matrix.Elements[2], matrix.Elements[3], matrix.Elements[4], matrix.Elements[5]);
	}

	public static Class6002 smethod_1(Class6002 drMatrix)
	{
		Matrix matrix = smethod_3(drMatrix);
		matrix.Invert();
		return smethod_0(matrix);
	}

	public static Class6002 smethod_2(Class6002 drMatrix, float shearX, float shearY, MatrixOrder matrixOrder)
	{
		Matrix matrix = smethod_3(drMatrix);
		matrix.Shear(shearX, shearY, matrixOrder);
		return smethod_0(matrix);
	}

	public static Matrix smethod_3(Class6002 drMatrix)
	{
		return new Matrix(drMatrix.M11, drMatrix.M12, drMatrix.M21, drMatrix.M22, drMatrix.M31, drMatrix.M32);
	}

	public static Matrix smethod_4(float scaleX, float scaleY, float x, float y)
	{
		return new Matrix(scaleX, 0f, 0f, scaleY, x * (1f - scaleX), y * (1f - scaleY));
	}

	public static Class6002 smethod_5(float scaleX, float scaleY, float x, float y)
	{
		return new Class6002(scaleX, 0f, 0f, scaleY, x * (1f - scaleX), y * (1f - scaleY));
	}

	public static void smethod_6(Class6002 drMatrix, Point[] points)
	{
		Matrix matrix = smethod_3(drMatrix);
		matrix.TransformPoints(points);
	}

	public static void smethod_7(Class6002 drMatrix, PointF[] vectors)
	{
		Matrix matrix = smethod_3(drMatrix);
		matrix.TransformVectors(vectors);
	}

	public static void smethod_8(Bitmap bitmap, Color transparentColor, int quality)
	{
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
		int num = bitmap.Width * 4;
		int num2 = bitmapData.Stride - num;
		int num3 = bitmapData.Stride * bitmapData.Height;
		byte[] array = new byte[num3];
		Marshal.Copy(bitmapData.Scan0, array, 0, num3);
		byte b = transparentColor.B;
		byte g = transparentColor.G;
		byte r = transparentColor.R;
		int num4 = 0;
		for (int i = 0; i < bitmapData.Height; i++)
		{
			for (int j = 0; j < bitmapData.Width; j++)
			{
				int num5 = smethod_9(b, array[num4]);
				int num6 = smethod_9(g, array[num4 + 1]);
				int num7 = smethod_9(r, array[num4 + 2]);
				if (num5 >= quality && num6 >= quality && num7 >= quality)
				{
					array[num4 + 3] = 0;
				}
				num4 += 4;
			}
			num4 += num2;
		}
		Marshal.Copy(array, 0, bitmapData.Scan0, num3);
		bitmap.UnlockBits(bitmapData);
	}

	internal static int smethod_9(byte a, byte b)
	{
		return int_0[a - b + 255];
	}
}
