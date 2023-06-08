using System.Drawing;
using ns218;

namespace ns233;

internal class Class6147
{
	private readonly int int_0;

	private readonly int int_1;

	private readonly int int_2;

	private readonly int int_3;

	private double double_0;

	private double double_1;

	private bool bool_0;

	public int Left => int_0;

	public int Top => int_1;

	public int Right => Left + Width;

	public int Bottom => Top + Height;

	public int Width => int_2;

	public int Height => int_3;

	public double HorizontalResolution => double_0;

	public double VerticalResolution => double_1;

	public bool IsOriginalResolutionZero => bool_0;

	public double WidthPoints => Class5955.smethod_10(int_2, double_0);

	public double HeightPoints => Class5955.smethod_10(int_3, double_1);

	public int WidthEmus => Class5955.smethod_38(WidthPoints);

	public int HeightEmus => Class5955.smethod_38(HeightPoints);

	public int WidthTwips => Class5955.smethod_11(Width, HorizontalResolution);

	public int HeightTwips => Class5955.smethod_11(Height, VerticalResolution);

	public Size Size => new Size(int_2, int_3);

	public static Class6147 smethod_0()
	{
		return new Class6147(0, 0, 0, 0, 0.0, 0.0);
	}

	public static Class6147 smethod_1(int width, int height, double hRes, double vRes)
	{
		return new Class6147(0, 0, width, height, hRes, vRes);
	}

	public static Class6147 smethod_2(int left, int top, int right, int bottom, double hRes, double vRes)
	{
		int width = right - left;
		int height = bottom - top;
		return new Class6147(left, top, width, height, hRes, vRes);
	}

	public static Class6147 smethod_3(int left, int top, int right, int bottom, int widthEmus, int heightEmus)
	{
		int num = right - left;
		int num2 = bottom - top;
		double hRes = ((widthEmus != 0) ? ((double)num / Class5955.smethod_47(widthEmus)) : 0.0);
		double vRes = ((heightEmus != 0) ? ((double)num2 / Class5955.smethod_47(heightEmus)) : 0.0);
		return new Class6147(left, top, num, num2, hRes, vRes);
	}

	private Class6147(int left, int top, int width, int height, double hRes, double vRes)
	{
		int_0 = left;
		int_1 = top;
		int_2 = width;
		int_3 = height;
		double_0 = hRes;
		double_1 = vRes;
		if (hRes == 0.0 || vRes == 0.0)
		{
			bool_0 = true;
			double_0 = 96.0;
			double_1 = 96.0;
		}
	}
}
