using System;
using System.Drawing;

namespace ns3;

internal class Class861
{
	private int int_0;

	public bool method_0(Bitmap bitmap_0, Bitmap bitmap_1)
	{
		bool flag = true;
		if (bitmap_0.Size != bitmap_1.Size)
		{
			flag = false;
		}
		else
		{
			for (int i = 0; i < bitmap_0.Width; i++)
			{
				for (int j = 0; j < bitmap_0.Height; j++)
				{
					Color pixel = bitmap_0.GetPixel(i, j);
					Color pixel2 = bitmap_1.GetPixel(i, j);
					if (!method_1(pixel, pixel2, int_0))
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
		}
		bitmap_0?.Dispose();
		bitmap_1?.Dispose();
		return flag;
	}

	private bool method_1(Color color_0, Color color_1, int int_1)
	{
		if (!method_2(color_0.A, color_1.A, int_1))
		{
			return false;
		}
		if (!method_2(color_0.R, color_1.R, int_1))
		{
			return false;
		}
		if (!method_2(color_0.G, color_1.G, int_1))
		{
			return false;
		}
		if (!method_2(color_0.B, color_1.B, int_1))
		{
			return false;
		}
		return true;
	}

	private bool method_2(int int_1, int int_2, int int_3)
	{
		return Math.Abs(int_1 - int_2) <= int_3;
	}
}
