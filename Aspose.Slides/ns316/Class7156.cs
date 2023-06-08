using System;
using System.Drawing;

namespace ns316;

internal class Class7156
{
	internal class Class7157
	{
		internal int[] int_0;

		internal int[] int_1;

		public Class7157(int len, int basis, int stride, int startPos, int endPos, int slope, int tile, int endTile)
		{
			int_0 = new int[len + 1];
			int_1 = new int[len + 1];
			if (tile == endTile)
			{
				endPos -= slope;
			}
			for (int i = 0; i < len; i++)
			{
				int_0[i] = tile;
				int_1[i] = basis + startPos * stride;
				startPos++;
				if (startPos == endPos)
				{
					startPos = 0;
					tile++;
					if (tile == endTile)
					{
						endPos -= slope;
					}
				}
			}
			int_0[len] = int_0[len - 1];
			int_1[len] = int_1[len - 1];
		}
	}

	private const int int_0 = 10;

	private Class7143 class7143_0;

	private Class7143 class7143_1;

	private Bitmap bitmap_0;

	private Bitmap bitmap_1;

	private static bool bool_0;

	private float float_0;

	private float float_1;

	private int int_1;

	private int int_2;

	private Class7157[] class7157_0;

	private Class7157[] class7157_1;

	public Class7156(Bitmap image, Bitmap map, Class7143 widthChannel, Class7143 heightChannel, float scaleByWidth, float scaleByHeight)
	{
		bitmap_1 = map;
		float_0 = scaleByWidth;
		float_1 = scaleByHeight;
		class7143_0 = widthChannel;
		class7143_1 = heightChannel;
		int_1 = (int)Math.Ceiling(scaleByWidth / 2f);
		int_2 = (int)Math.Ceiling(scaleByHeight / 2f);
		new Rectangle(0, 0, image.Width, image.Height);
		Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
		rectangle.X -= int_1;
		rectangle.Width += 2 * int_1;
		rectangle.Y -= int_2;
		rectangle.Height += 2 * int_2;
		class7157_0 = new Class7157[0];
		class7157_1 = new Class7157[0];
	}

	public int[] method_0(Bitmap image, int xPos, int yPos, int size)
	{
		if (image == null)
		{
			image = new Bitmap(size, size);
		}
		Bitmap bitmap = image.Clone(new Rectangle(xPos, xPos, size - xPos, size - xPos), image.PixelFormat);
		new Rectangle(0, 0, bitmap.Width, bitmap.Height);
		Bitmap source = bitmap_1.Clone(new Rectangle(0, 0, bitmap_1.Width, bitmap_1.Height), bitmap_1.PixelFormat);
		Class7157 @class = method_1(xPos);
		Class7157 class2 = method_2(yPos);
		if (bool_0)
		{
			method_5(source, bitmap, @class.int_0, @class.int_1, class2.int_0, class2.int_1);
		}
		else if (@class != null && class2 != null)
		{
			method_4(source, bitmap, @class.int_0, @class.int_1, class2.int_0, class2.int_1);
		}
		return Class7177.smethod_3(bitmap);
	}

	public Class7157 method_1(int x)
	{
		return null;
	}

	public Class7157 method_2(int y)
	{
		return null;
	}

	public void method_3(Bitmap source, Bitmap map, int[] tileX, int[] xArea, int[] tileY, int[] yArea)
	{
		int width = map.Width;
		int height = map.Height;
		int num = int_1;
		int num2 = int_2;
		int num3 = num + width;
		int num4 = num2 + height;
		int width2 = source.Width;
		int width3 = map.Width;
		int num5 = width2 - width;
		int num6 = width3 - width;
		int num7 = 0;
		int num8 = 0;
		int num9 = (int)((double)float_0 / 255.0 * 32768.0 + 0.5);
		int num10 = (int)(-127.5 * (double)num9 - 0.5);
		int num11 = (int)((double)float_1 / 255.0 * 32768.0 + 0.5);
		int num12 = (int)(-127.5 * (double)num11 - 0.5);
		int num13 = 0;
		int num14 = 0;
		int num15 = 0;
		int num16 = 0;
		int num17 = 0;
		int num18 = 0;
		int num19 = 0;
		int num20 = 0;
		int num21 = 0;
		int num22 = tileX[0] - 1;
		int num23 = tileY[0] - 1;
		int[] array = null;
		for (int i = num2; i < num4; i++)
		{
			int num24 = num;
			while (num24 < num3)
			{
				num21 = Class7177.smethod_2(Class7177.smethod_0(source, num8));
				int num25 = num9 * (num21 & 0xFF) + num10;
				int num26 = num11 * (num21 & 0xFF) + num12;
				int num27 = num24 + (num25 >> 15);
				int num28 = i + (num26 >> 15);
				if (num22 != tileX[num27] || num23 != tileY[num28])
				{
					num22 = tileX[num27];
					num23 = tileY[num28];
					array = method_0(bitmap_0, num22, num23, 10);
				}
				num13 = array[xArea[num27] + yArea[num28]];
				if (tileX.Length > num27 + 1 && tileY.Length > num28 + 1)
				{
					int num29 = tileX[num27 + 1];
					int num30 = tileY[num28 + 1];
					if (num23 == num30)
					{
						if (num22 == num29)
						{
							num15 = array[xArea[num27 + 1] + yArea[num28]];
							num14 = array[xArea[num27] + yArea[num28 + 1]];
							num16 = array[xArea[num27 + 1] + yArea[num28 + 1]];
						}
						else
						{
							num14 = array[xArea[num27] + yArea[num28 + 1]];
							array = method_0(bitmap_0, num29, num23, 10);
							num15 = array[xArea[num27 + 1] + yArea[num28]];
							num16 = array[xArea[num27 + 1] + yArea[num28 + 1]];
							num22 = num29;
						}
					}
					else if (num22 == num29)
					{
						num15 = array[xArea[num27 + 1] + yArea[num28]];
						array = method_0(bitmap_0, num22, num30, 10);
						num14 = array[xArea[num27] + yArea[num28 + 1]];
						num16 = array[xArea[num27 + 1] + yArea[num28 + 1]];
						num23 = num30;
					}
					else
					{
						array = method_0(bitmap_0, num22, num30, 10);
						num14 = array[xArea[num27] + yArea[num28 + 1]];
						array = method_0(bitmap_0, num29, num30, 10);
						num16 = array[xArea[num27 + 1] + yArea[num28 + 1]];
						array = method_0(bitmap_0, num29, num23, 10);
						num15 = array[xArea[num27 + 1] + yArea[num28]];
						num22 = num29;
					}
				}
				num17 = num25 & 0x7FFF;
				num18 = num26 & 0x7FFF;
				int num31 = (int)(((uint)num13 >> 16) & 0xFF00);
				int num32 = (int)(((uint)num15 >> 16) & 0xFF00);
				int num33 = (num31 + ((num32 - num31) * num17 + 16384 >> 15)) & 0xFFFF;
				num31 = (int)(((uint)num14 >> 16) & 0xFF00);
				num32 = (int)(((uint)num16 >> 16) & 0xFF00);
				num20 = (num31 + ((num32 - num31) * num17 + 16384 >> 15)) & 0xFFFF;
				num19 = (((num33 << 15) + (num20 - num33) * num18 + 4194304) & 0x7F800000) << 1;
				num31 = (num13 >> 8) & 0xFF00;
				num32 = (num15 >> 8) & 0xFF00;
				num33 = (num31 + ((num32 - num31) * num17 + 16384 >> 15)) & 0xFFFF;
				num31 = (num14 >> 8) & 0xFF00;
				num32 = (num16 >> 8) & 0xFF00;
				num20 = (num31 + ((num32 - num31) * num17 + 16384 >> 15)) & 0xFFFF;
				num19 |= (int)((uint)(((num33 << 15) + (num20 - num33) * num18 + 4194304) & 0x7F800000) >> 7);
				num31 = num13 & 0xFF00;
				num32 = num15 & 0xFF00;
				num33 = (num31 + ((num32 - num31) * num17 + 16384 >> 15)) & 0xFFFF;
				num31 = num14 & 0xFF00;
				num32 = num16 & 0xFF00;
				num20 = (num31 + ((num32 - num31) * num17 + 16384 >> 15)) & 0xFFFF;
				num19 |= (int)((uint)(((num33 << 15) + (num20 - num33) * num18 + 4194304) & 0x7F800000) >> 15);
				num31 = (num13 << 8) & 0xFF00;
				num32 = (num15 << 8) & 0xFF00;
				num33 = (num31 + ((num32 - num31) * num17 + 16384 >> 15)) & 0xFFFF;
				num31 = (num14 << 8) & 0xFF00;
				num32 = (num16 << 8) & 0xFF00;
				num20 = (num31 + ((num32 - num31) * num17 + 16384 >> 15)) & 0xFFFF;
				num19 |= (int)((uint)(((num33 << 15) + (num20 - num33) * num18 + 4194304) & 0x7F800000) >> 23);
				Class7177.smethod_1(ref map, num7, Color.FromArgb(num19));
				num24++;
				num7++;
				num8++;
			}
			num7 += num5;
			num8 += num6;
		}
	}

	public void method_4(Bitmap source, Bitmap map, int[] tileX, int[] xSize, int[] tileY, int[] ySize)
	{
		int width = map.Width;
		int height = map.Height;
		int num = int_1;
		int num2 = int_2;
		int num3 = num + width;
		int num4 = num2 + height;
		int num5 = -width;
		int num6 = -width;
		int num7 = class7143_0.method_0() * 8;
		int num8 = class7143_1.method_0() * 8;
		int num9 = 0;
		int num10 = 0;
		int num11 = (int)((double)float_0 / 255.0 * 32768.0 + 0.5);
		int num12 = (int)(-127.5 * (double)num11 - 0.5);
		int num13 = (int)((double)float_1 / 255.0 * 32768.0 + 0.5);
		int num14 = (int)(-127.5 * (double)num13 - 0.5);
		int num15 = 0;
		int num16 = 0;
		int num17 = 0;
		int num18 = 0;
		int num19 = 0;
		int num20 = 0;
		int num21 = 0;
		int num22 = 65793;
		int num23 = tileX[0] - 1;
		int num24 = tileY[0] - 1;
		int[] array = null;
		for (int i = num2; i < num4; i++)
		{
			int num25 = num;
			while (num25 < num3)
			{
				int num26 = Class7177.smethod_2(Class7177.smethod_0(source, num10));
				int num27 = num11 * ((num26 >> num7) & 0xFF) + num12;
				int num28 = num13 * ((num26 >> num8) & 0xFF) + num14;
				int num29 = num25 + (num27 >> 15);
				int num30 = i + (num28 >> 15);
				if (num23 != tileX[num29] || num24 != tileY[num30])
				{
					num23 = tileX[num29];
					num24 = tileY[num30];
					array = method_0(bitmap_0, num23, num24, 10);
				}
				num15 = array[xSize[num29] + ySize[num30]];
				if (tileX.Length > num29 + 1 && tileY.Length > num30 + 1)
				{
					int num31 = tileX[num29 + 1];
					int num32 = tileY[num30 + 1];
					if (num24 == num32)
					{
						if (num23 == num31)
						{
							num17 = array[xSize[num29 + 1] + ySize[num30]];
							num16 = array[xSize[num29] + ySize[num30 + 1]];
							num18 = array[xSize[num29 + 1] + ySize[num30 + 1]];
						}
						else
						{
							num16 = array[xSize[num29] + ySize[num30 + 1]];
							array = method_0(bitmap_0, num31, num24, 10);
							num17 = array[xSize[num29 + 1] + ySize[num30]];
							num18 = array[xSize[num29 + 1] + ySize[num30 + 1]];
							num23 = num31;
						}
					}
					else if (num23 == num31)
					{
						num17 = array[xSize[num29 + 1] + ySize[num30]];
						array = method_0(bitmap_0, num23, num32, 10);
						num16 = array[xSize[num29] + ySize[num30 + 1]];
						num18 = array[xSize[num29 + 1] + ySize[num30 + 1]];
						num24 = num32;
					}
					else
					{
						array = method_0(bitmap_0, num23, num32, 10);
						num16 = array[xSize[num29] + ySize[num30 + 1]];
						array = method_0(bitmap_0, num31, num32, 10);
						num18 = array[xSize[num29 + 1] + ySize[num30 + 1]];
						array = method_0(bitmap_0, num31, num24, 10);
						num17 = array[xSize[num29 + 1] + ySize[num30]];
						num23 = num31;
					}
				}
				num19 = num27 & 0x7FFF;
				num20 = num28 & 0x7FFF;
				int num33 = (int)(((uint)num15 >> 16) & 0xFF00);
				int num34 = (int)(((uint)num17 >> 16) & 0xFF00);
				int num35 = (num33 + ((num34 - num33) * num19 + 16384 >> 15)) & 0xFFFF;
				int num36 = (num33 >> 8) * num22 + 128 >> 8;
				int num37 = (num34 >> 8) * num22 + 128 >> 8;
				num33 = (int)(((uint)num16 >> 16) & 0xFF00);
				num34 = (int)(((uint)num18 >> 16) & 0xFF00);
				int num38 = (num33 + ((num34 - num33) * num19 + 16384 >> 15)) & 0xFFFF;
				int num39 = (num33 >> 8) * num22 + 128 >> 8;
				int num40 = (num34 >> 8) * num22 + 128 >> 8;
				num21 = (((num35 << 15) + (num38 - num35) * num20 + 4194304) & 0x7F800000) << 1;
				num33 = ((num15 >> 16) & 0xFF) * num36 + 128 >> 8;
				num34 = ((num17 >> 16) & 0xFF) * num37 + 128 >> 8;
				num35 = (num33 + ((num34 - num33) * num19 + 16384 >> 15)) & 0xFFFF;
				num33 = ((num16 >> 16) & 0xFF) * num39 + 128 >> 8;
				num34 = ((num18 >> 16) & 0xFF) * num40 + 128 >> 8;
				num38 = (num33 + ((num34 - num33) * num19 + 16384 >> 15)) & 0xFFFF;
				num21 |= (int)((uint)(((num35 << 15) + (num38 - num35) * num20 + 4194304) & 0x7F800000) >> 7);
				num33 = ((num15 >> 8) & 0xFF) * num36 + 128 >> 8;
				num34 = ((num17 >> 8) & 0xFF) * num37 + 128 >> 8;
				num35 = (num33 + ((num34 - num33) * num19 + 16384 >> 15)) & 0xFFFF;
				num33 = ((num16 >> 8) & 0xFF) * num39 + 128 >> 8;
				num34 = ((num18 >> 8) & 0xFF) * num40 + 128 >> 8;
				num38 = (num33 + ((num34 - num33) * num19 + 16384 >> 15)) & 0xFFFF;
				num21 |= (int)((uint)(((num35 << 15) + (num38 - num35) * num20 + 4194304) & 0x7F800000) >> 15);
				num33 = (num15 & 0xFF) * num36 + 128 >> 8;
				num34 = (num17 & 0xFF) * num37 + 128 >> 8;
				num35 = (num33 + ((num34 - num33) * num19 + 16384 >> 15)) & 0xFFFF;
				num33 = (num16 & 0xFF) * num39 + 128 >> 8;
				num34 = (num18 & 0xFF) * num40 + 128 >> 8;
				num38 = (num33 + ((num34 - num33) * num19 + 16384 >> 15)) & 0xFFFF;
				num21 |= (int)((uint)(((num35 << 15) + (num38 - num35) * num20 + 4194304) & 0x7F800000) >> 23);
				Class7177.smethod_1(ref map, num9, Color.FromArgb(num21));
				num25++;
				num9++;
				num10++;
			}
			num9 += num5;
			num10 += num6;
		}
	}

	public void method_5(Bitmap source, Bitmap result, int[] tileX, int[] xSize, int[] tileY, int[] ySize)
	{
		int width = result.Width;
		int height = result.Height;
		int num = int_1;
		int num2 = int_2;
		int num3 = num + width;
		int num4 = num2 + height;
		int width2 = result.Width;
		int width3 = bitmap_1.Width;
		int num5 = width2 - width;
		int num6 = width3 - width;
		int num7 = class7143_0.method_0() * 8;
		int num8 = class7143_1.method_0() * 8;
		int num9 = (int)((double)float_0 / 255.0 * 32768.0 + 0.5);
		int num10 = (int)((double)float_1 / 255.0 * 32768.0 + 0.5);
		int num11 = (int)(-127.5 * (double)num9 - 0.5) + 16384;
		int num12 = (int)(-127.5 * (double)num10 - 0.5) + 16384;
		int num13 = 0;
		int num14 = 0;
		int i = num2;
		int num15 = tileX[0] - 1;
		int num16 = tileY[0] - 1;
		int[] array = null;
		for (; i < num4; i++)
		{
			for (int j = num; j < num3; j++)
			{
				int num17 = Class7177.smethod_2(Class7177.smethod_0(source, num14));
				int num18 = num9 * ((num17 >> num7) & 0xFF) + num11;
				int num19 = num10 * ((num17 >> num8) & 0xFF) + num12;
				int num20 = j + (num18 >> 15);
				int num21 = i + (num19 >> 15);
				if (num15 != tileX[num20] || num16 != tileY[num21])
				{
					num15 = tileX[num20];
					num16 = tileY[num21];
					array = method_0(bitmap_0, num15, num16, 10);
				}
				Class7177.smethod_1(ref result, num13, Color.FromArgb(array[xSize[num20] + ySize[num21]]));
				num13++;
				num14++;
			}
			num13 += num5;
			num14 += num6;
		}
	}
}
