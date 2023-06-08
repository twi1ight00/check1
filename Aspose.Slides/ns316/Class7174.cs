using System;
using System.Drawing;

namespace ns316;

internal class Class7174
{
	private int int_0;

	private int int_1;

	private bool bool_0;

	private int int_2;

	private int int_3;

	private void method_0(int buffer, int width, ref int next, int[] area, ref int a, ref int index)
	{
		for (int i = buffer + 2; i < width; i++)
		{
			next = area[i];
			if (smethod_0(next, a, bool_0))
			{
				a = next;
				index = i;
			}
		}
	}

	private void method_1(int count, ref int next, ref int[] buffer, ref int height, ref int pixel, ref int index, int size)
	{
		for (int i = 1; i < count; i++)
		{
			next = buffer[height];
			if (smethod_0(next, pixel, bool_0))
			{
				pixel = next;
				index = height;
			}
			height = (height + 1) % size;
		}
	}

	public void method_2(int radiusX, int radiusY, bool doExtension)
	{
		if (radiusX > 0 && radiusY > 0)
		{
			int_0 = radiusX;
			int_1 = radiusY;
			int_2 = 2 * radiusX + 1;
			int_3 = 2 * radiusY + 1;
			bool_0 = doExtension;
		}
	}

	public Rectangle method_3(Bitmap src)
	{
		return new Rectangle(0, 0, src.Width, src.Height);
	}

	public Rectangle method_4(Image src)
	{
		return new Rectangle(0, 0, src.Width, src.Height);
	}

	private static bool smethod_0(int inValue, int outValue, bool doExtension)
	{
		if (inValue > outValue)
		{
			return doExtension;
		}
		if (inValue < outValue)
		{
			return !doExtension;
		}
		return true;
	}

	private void method_5(Bitmap src, Bitmap dest)
	{
		int width = src.Width;
		int height = src.Height;
		int next = 0;
		int next2 = 0;
		int next3 = 0;
		int next4 = 0;
		if (width <= int_0)
		{
			for (int i = 0; i < height; i++)
			{
				int num = i * src.Width;
				int num2 = i * dest.Width;
				int num3 = Class7177.smethod_2(Class7177.smethod_0(src, num++));
				int num4 = (int)(Convert.ToUInt32(num3) >> 24);
				int num5 = num3 & 0xFF0000;
				int num6 = num3 & 0xFF00;
				int num7 = num3 & 0xFF;
				for (int j = 1; j < width; j++)
				{
					int num8 = Class7177.smethod_2(Class7177.smethod_0(src, num++));
					next = (int)(Convert.ToUInt32(num8) >> 24);
					next2 = num8 & 0xFF0000;
					next3 = num8 & 0xFF00;
					next4 = num8 & 0xFF;
					if (smethod_0(next, num4, bool_0))
					{
						num4 = next;
					}
					if (smethod_0(next2, num5, bool_0))
					{
						num5 = next2;
					}
					if (smethod_0(next3, num6, bool_0))
					{
						num6 = next3;
					}
					if (smethod_0(next4, num7, bool_0))
					{
						num7 = next4;
					}
				}
				for (int k = 0; k < width; k++)
				{
					Class7177.smethod_1(ref dest, num2++, Color.FromArgb((byte)(num4 << 24), (byte)num5, (byte)num6, (byte)num7));
				}
			}
			return;
		}
		int[] array = new int[width];
		int[] array2 = new int[width];
		int[] array3 = new int[width];
		int[] array4 = new int[width];
		for (int l = 0; l < height; l++)
		{
			int num = l * src.Width;
			int num2 = l * dest.Width;
			int num9 = 0;
			int index = 0;
			int index2 = 0;
			int index3 = 0;
			int index4 = 0;
			int num3 = Class7177.smethod_2(Class7177.smethod_0(src, num++));
			int num4 = (int)(Convert.ToUInt32(num3) >> 24);
			int num5 = num3 & 0xFF0000;
			int num6 = num3 & 0xFF00;
			int num7 = num3 & 0xFF;
			array[0] = num4;
			array2[0] = num5;
			array3[0] = num6;
			array4[0] = num7;
			for (int m = 1; m <= int_0; m++)
			{
				int num8 = Class7177.smethod_2(Class7177.smethod_0(src, num++));
				next = (int)(Convert.ToUInt32(num8) >> 24);
				next2 = num8 & 0xFF0000;
				next3 = num8 & 0xFF00;
				next4 = num8 & 0xFF;
				array[m] = next;
				array2[m] = next2;
				array3[m] = next3;
				array4[m] = next4;
				if (smethod_0(next, num4, bool_0))
				{
					num4 = next;
					index = m;
				}
				if (smethod_0(next2, num5, bool_0))
				{
					num5 = next2;
					index2 = m;
				}
				if (smethod_0(next3, num6, bool_0))
				{
					num6 = next3;
					index3 = m;
				}
				if (smethod_0(next4, num7, bool_0))
				{
					num7 = next4;
					index4 = m;
				}
			}
			Class7177.smethod_1(ref dest, num2++, Color.FromArgb((byte)num4, (byte)num5, (byte)num6, (byte)num7));
			for (int n = 1; n <= width - int_0 - 1; n++)
			{
				int num10 = Class7177.smethod_2(Class7177.smethod_0(src, num++));
				num4 = array[index];
				next = (int)(Convert.ToUInt32(num10) >> 24);
				array[n + int_0] = next;
				if (smethod_0(next, num4, bool_0))
				{
					num4 = next;
					index = n + int_0;
				}
				num5 = array2[index2];
				next2 = num10 & 0xFF0000;
				array2[n + int_0] = next2;
				if (smethod_0(next2, num5, bool_0))
				{
					num5 = next2;
					index2 = n + int_0;
				}
				num6 = array3[index3];
				next3 = num10 & 0xFF00;
				array3[n + int_0] = next3;
				if (smethod_0(next3, num6, bool_0))
				{
					num6 = next3;
					index3 = n + int_0;
				}
				num7 = array4[index4];
				next4 = num10 & 0xFF;
				array4[n + int_0] = next4;
				if (smethod_0(next4, num7, bool_0))
				{
					num7 = next4;
					index4 = n + int_0;
				}
				Class7177.smethod_1(ref dest, num2++, Color.FromArgb((byte)num4, (byte)num5, (byte)num6, (byte)num7));
			}
			for (int num11 = width - int_0; num11 <= int_0; num11++)
			{
				Class7177.smethod_1(ref dest, num2, Class7177.smethod_0(dest, num2 - 1));
				num2++;
			}
			for (int num12 = int_0 + 1; num12 < width; num12++)
			{
				if (index == num9)
				{
					num4 = array[num9 + 1];
					index = num9 + 1;
					method_0(num9, width, ref next, array, ref num4, ref index);
				}
				else
				{
					num4 = array[index];
				}
				if (index2 == num9)
				{
					num5 = array2[num9 + 1];
					index2 = num9 + 1;
					method_0(num9, width, ref next2, array2, ref num5, ref index2);
				}
				else
				{
					num5 = array2[index2];
				}
				if (index3 == num9)
				{
					num6 = array3[num9 + 1];
					index3 = num9 + 1;
					method_0(num9, width, ref next3, array3, ref num6, ref index3);
				}
				else
				{
					num6 = array3[index3];
				}
				if (index4 == num9)
				{
					num7 = array4[num9 + 1];
					index4 = num9 + 1;
					method_0(num9, width, ref next4, array4, ref num7, ref index4);
				}
				else
				{
					num7 = array4[index4];
				}
				num9++;
				Class7177.smethod_1(ref dest, num2++, Color.FromArgb((byte)num4, (byte)num5, (byte)num6, (byte)num7));
			}
		}
	}

	private void method_6(Bitmap src, Bitmap dest)
	{
		int width = src.Width;
		int height = src.Height;
		int num = 0;
		int num2 = 0;
		int next = 0;
		int next2 = 0;
		int next3 = 0;
		int next4 = 0;
		if (height <= int_1)
		{
			for (int i = 0; i < width; i++)
			{
				int num3 = num + i;
				int num4 = num + i;
				int num5 = Class7177.smethod_2(Class7177.smethod_0(dest, num4));
				num4 += num2;
				int num6 = (int)(Convert.ToUInt32(num5) >> 24);
				int num7 = num5 & 0xFF0000;
				int num8 = num5 & 0xFF00;
				int num9 = num5 & 0xFF;
				for (int j = 1; j < height; j++)
				{
					int num10 = Class7177.smethod_2(Class7177.smethod_0(dest, num4));
					num4 += num2;
					next = (int)(Convert.ToUInt32(num10) >> 24);
					next2 = num10 & 0xFF0000;
					next3 = num10 & 0xFF00;
					next4 = num10 & 0xFF;
					if (smethod_0(next, num6, bool_0))
					{
						num6 = next;
					}
					if (smethod_0(next2, num7, bool_0))
					{
						num7 = next2;
					}
					if (smethod_0(next3, num8, bool_0))
					{
						num8 = next3;
					}
					if (smethod_0(next4, num9, bool_0))
					{
						num9 = next4;
					}
				}
				for (int k = 0; k < height; k++)
				{
					Class7177.smethod_1(ref dest, num3, Color.FromArgb((byte)num6, (byte)num7, (byte)num8, (byte)num9));
					num3 += dest.Width;
				}
			}
			return;
		}
		int[] array = new int[height];
		int[] array2 = new int[height];
		int[] array3 = new int[height];
		int[] array4 = new int[height];
		for (int l = 0; l < width; l++)
		{
			int num3 = num + l;
			int num4 = num + l;
			int num11 = 0;
			int index = 0;
			int index2 = 0;
			int index3 = 0;
			int index4 = 0;
			int num5 = Class7177.smethod_2(Class7177.smethod_0(dest, num4));
			num4 += num2;
			int num6 = (int)(Convert.ToUInt32(num5) >> 24);
			int num7 = num5 & 0xFF0000;
			int num8 = num5 & 0xFF00;
			int num9 = num5 & 0xFF;
			array[0] = num6;
			array2[0] = num7;
			array3[0] = num8;
			array4[0] = num9;
			for (int m = 1; m <= int_1; m++)
			{
				int num10 = Class7177.smethod_2(Class7177.smethod_0(dest, num4));
				num4 += num2;
				next = (int)(Convert.ToUInt32(num10) >> 24);
				next2 = num10 & 0xFF0000;
				next3 = num10 & 0xFF00;
				next4 = num10 & 0xFF;
				array[m] = next;
				array2[m] = next2;
				array3[m] = next3;
				array4[m] = next4;
				if (smethod_0(next, num6, bool_0))
				{
					num6 = next;
					index = m;
				}
				if (smethod_0(next2, num7, bool_0))
				{
					num7 = next2;
					index2 = m;
				}
				if (smethod_0(next3, num8, bool_0))
				{
					num8 = next3;
					index3 = m;
				}
				if (smethod_0(next4, num9, bool_0))
				{
					num9 = next4;
					index4 = m;
				}
			}
			Class7177.smethod_1(ref dest, num3, Color.FromArgb((byte)num6, (byte)num7, (byte)num8, (byte)num9));
			num3 += num2;
			for (int n = 1; n <= height - int_1 - 1; n++)
			{
				int num12 = Class7177.smethod_2(Class7177.smethod_0(dest, num4));
				num4 += num2;
				num6 = array[index];
				next = (int)(Convert.ToUInt32(num12) >> 24);
				array[n + int_1] = next;
				if (smethod_0(next, num6, bool_0))
				{
					num6 = next;
					index = n + int_1;
				}
				num7 = array2[index2];
				next2 = num12 & 0xFF0000;
				array2[n + int_1] = next2;
				if (smethod_0(next2, num7, bool_0))
				{
					num7 = next2;
					index2 = n + int_1;
				}
				num8 = array3[index3];
				next3 = num12 & 0xFF00;
				array3[n + int_1] = next3;
				if (smethod_0(next3, num8, bool_0))
				{
					num8 = next3;
					index3 = n + int_1;
				}
				num9 = array4[index4];
				next4 = num12 & 0xFF;
				array4[n + int_1] = next4;
				if (smethod_0(next4, num9, bool_0))
				{
					num9 = next4;
					index4 = n + int_1;
				}
				Class7177.smethod_1(ref dest, num3, Color.FromArgb((byte)num6, (byte)num7, (byte)num8, (byte)num9));
				num3 += num2;
			}
			for (int num13 = height - int_1; num13 <= int_1; num13++)
			{
				Class7177.smethod_1(ref dest, num3, Class7177.smethod_0(dest, num3 - dest.Width));
				num3 += num2;
			}
			for (int num14 = int_1 + 1; num14 < height; num14++)
			{
				if (index == num11)
				{
					num6 = array[num11 + 1];
					index = num11 + 1;
					method_0(num11, height, ref next, array, ref num6, ref index);
				}
				else
				{
					num6 = array[index];
				}
				if (index2 == num11)
				{
					num7 = array2[num11 + 1];
					index2 = num11 + 1;
					method_0(num11, height, ref next2, array2, ref num7, ref index2);
				}
				else
				{
					num7 = array2[index2];
				}
				if (index3 == num11)
				{
					num8 = array3[num11 + 1];
					index3 = num11 + 1;
					method_0(num11, height, ref next3, array3, ref num8, ref index3);
				}
				else
				{
					num8 = array3[index3];
				}
				if (index4 == num11)
				{
					num9 = array4[num11 + 1];
					index4 = num11 + 1;
					method_0(num11, height, ref next4, array4, ref num9, ref index4);
				}
				else
				{
					num9 = array4[index4];
				}
				num11++;
				Class7177.smethod_1(ref dest, num3, Color.FromArgb((byte)num6, (byte)num7, (byte)num8, (byte)num9));
				num3 += dest.Width;
			}
		}
	}

	public Bitmap method_7(Bitmap src, Bitmap dest)
	{
		int num = 0;
		int num2 = 0;
		int width = src.Width;
		int height = src.Height;
		int width2 = src.Width;
		int width3 = dest.Width;
		if (int_2 == 0)
		{
			int_2 = src.Width;
		}
		if (int_3 == 0)
		{
			int_3 = src.Height;
		}
		int next = 0;
		int next2 = 0;
		int next3 = 0;
		int next4 = 0;
		if (width <= 2 * int_0)
		{
			method_5(src, dest);
		}
		else
		{
			int[] buffer = new int[int_2];
			int[] buffer2 = new int[int_2];
			int[] buffer3 = new int[int_2];
			int[] buffer4 = new int[int_2];
			for (int i = 0; i < height; i++)
			{
				int num3 = num + i * width2;
				int num4 = num2 + i * width3;
				int num5 = 0;
				int index = 0;
				int index2 = 0;
				int index3 = 0;
				int index4 = 0;
				int num6 = Class7177.smethod_2(Class7177.smethod_0(src, num3++));
				int pixel = (int)(Convert.ToUInt32(num6) >> 24);
				int pixel2 = num6 & 0xFF0000;
				int pixel3 = num6 & 0xFF00;
				int pixel4 = num6 & 0xFF;
				buffer[0] = pixel;
				buffer2[0] = pixel2;
				buffer3[0] = pixel3;
				buffer4[0] = pixel4;
				for (int j = 1; j <= int_0; j++)
				{
					int num7 = Class7177.smethod_2(Class7177.smethod_0(src, num3++));
					next = (int)(Convert.ToUInt32(num7) >> 24);
					next2 = num7 & 0xFF0000;
					next3 = num7 & 0xFF00;
					next4 = num7 & 0xFF;
					buffer[j] = next;
					buffer2[j] = next2;
					buffer3[j] = next3;
					buffer4[j] = next4;
					if (smethod_0(next, pixel, bool_0))
					{
						pixel = next;
						index = j;
					}
					if (smethod_0(next2, pixel2, bool_0))
					{
						pixel2 = next2;
						index2 = j;
					}
					if (smethod_0(next3, pixel3, bool_0))
					{
						pixel3 = next3;
						index3 = j;
					}
					if (smethod_0(next4, pixel4, bool_0))
					{
						pixel4 = next4;
						index4 = j;
					}
				}
				if (pixel <= 255 && pixel2 <= 255 && pixel3 <= 255 && pixel4 <= 255)
				{
					Class7177.smethod_1(ref dest, num4++, Color.FromArgb(pixel, pixel2, pixel3, pixel4));
				}
				for (int k = 1; k <= int_0; k++)
				{
					int num8 = Class7177.smethod_2(Class7177.smethod_0(src, num3++));
					pixel = buffer[index];
					next = (int)(Convert.ToUInt32(num8) >> 24);
					buffer[k + int_0] = next;
					if (smethod_0(next, pixel, bool_0))
					{
						pixel = next;
						index = k + int_0;
					}
					pixel2 = buffer2[index2];
					next2 = num8 & 0xFF0000;
					buffer2[k + int_0] = next2;
					if (smethod_0(next2, pixel2, bool_0))
					{
						pixel2 = next2;
						index2 = k + int_0;
					}
					pixel3 = buffer3[index3];
					next3 = num8 & 0xFF00;
					buffer3[k + int_0] = next3;
					if (smethod_0(next3, pixel3, bool_0))
					{
						pixel3 = next3;
						index3 = k + int_0;
					}
					pixel4 = buffer4[index4];
					next4 = num8 & 0xFF;
					buffer4[k + int_0] = next4;
					if (smethod_0(next4, pixel4, bool_0))
					{
						pixel4 = next4;
						index4 = k + int_0;
					}
					Class7177.smethod_1(ref dest, num4++, Color.FromArgb((byte)pixel, (byte)pixel2, (byte)pixel3, (byte)pixel4));
				}
				for (int l = int_0 + 1; l <= width - 1 - int_0; l++)
				{
					int num8 = Class7177.smethod_2(Class7177.smethod_0(src, num3++));
					next = (int)(Convert.ToUInt32(num8) >> 24);
					next2 = num8 & 0xFF0000;
					next3 = num8 & 0xFF00;
					next4 = num8 & 0xFF;
					buffer[num5] = next;
					buffer2[num5] = next2;
					buffer3[num5] = next3;
					buffer4[num5] = next4;
					if (index == num5)
					{
						pixel = buffer[0];
						index = 0;
						for (int m = 1; m < int_2; m++)
						{
							next = buffer[m];
							if (smethod_0(next, pixel, bool_0))
							{
								pixel = next;
								index = m;
							}
						}
					}
					else
					{
						pixel = buffer[index];
						if (smethod_0(next, pixel, bool_0))
						{
							pixel = next;
							index = num5;
						}
					}
					if (index2 == num5)
					{
						pixel2 = buffer2[0];
						index2 = 0;
						for (int n = 1; n < int_2; n++)
						{
							next2 = buffer2[n];
							if (smethod_0(next2, pixel2, bool_0))
							{
								pixel2 = next2;
								index2 = n;
							}
						}
					}
					else
					{
						pixel2 = buffer2[index2];
						if (smethod_0(next2, pixel2, bool_0))
						{
							pixel2 = next2;
							index2 = num5;
						}
					}
					if (index3 == num5)
					{
						pixel3 = buffer3[0];
						index3 = 0;
						for (int num9 = 1; num9 < int_2; num9++)
						{
							next3 = buffer3[num9];
							if (smethod_0(next3, pixel3, bool_0))
							{
								pixel3 = next3;
								index3 = num9;
							}
						}
					}
					else
					{
						pixel3 = buffer3[index3];
						if (smethod_0(next3, pixel3, bool_0))
						{
							pixel3 = next3;
							index3 = num5;
						}
					}
					if (index4 == num5)
					{
						pixel4 = buffer4[0];
						index4 = 0;
						for (int num10 = 1; num10 < int_2; num10++)
						{
							next4 = buffer4[num10];
							if (smethod_0(next4, pixel4, bool_0))
							{
								pixel4 = next4;
								index4 = num10;
							}
						}
					}
					else
					{
						pixel4 = buffer4[index4];
						if (smethod_0(next4, pixel4, bool_0))
						{
							pixel4 = next4;
							index4 = num5;
						}
					}
					Class7177.smethod_1(ref dest, num4++, Color.FromArgb((byte)pixel, (byte)pixel2, (byte)pixel3, (byte)pixel4));
					num5 = (num5 + 1) % int_2;
				}
				int num11 = ((num5 == 0) ? (int_2 - 1) : (num5 - 1));
				int num12 = int_2 - 1;
				for (int num13 = width - int_0; num13 < width; num13++)
				{
					int num14 = (num5 + 1) % int_2;
					if (index == num5)
					{
						pixel = buffer[num11];
						int height2 = num14;
						method_1(num12, ref next, ref buffer, ref height2, ref pixel, ref index, int_2);
					}
					if (index2 == num5)
					{
						pixel2 = buffer2[num11];
						int height3 = num14;
						method_1(num12, ref next2, ref buffer2, ref height3, ref pixel2, ref index2, int_2);
					}
					if (index3 == num5)
					{
						pixel3 = buffer3[num11];
						int height4 = num14;
						method_1(num12, ref next3, ref buffer3, ref height4, ref pixel3, ref index3, int_2);
					}
					if (index4 == num5)
					{
						pixel4 = buffer4[num11];
						int height5 = num14;
						method_1(num12, ref next4, ref buffer4, ref height5, ref pixel4, ref index4, int_2);
					}
					Class7177.smethod_1(ref dest, num4++, Color.FromArgb((byte)pixel, (byte)pixel2, (byte)pixel3, (byte)pixel4));
					num5 = (num5 + 1) % int_2;
					num12--;
				}
			}
		}
		if (height <= 2 * int_1)
		{
			method_6(src, dest);
		}
		else
		{
			int[] buffer5 = new int[int_3];
			int[] buffer6 = new int[int_3];
			int[] buffer7 = new int[int_3];
			int[] buffer8 = new int[int_3];
			for (int num15 = 0; num15 < width; num15++)
			{
				int num4 = num2 + num15;
				int num16 = num2 + num15;
				int num5 = 0;
				int index = 0;
				int index2 = 0;
				int index3 = 0;
				int index4 = 0;
				int num6 = Class7177.smethod_2(Class7177.smethod_0(dest, num16));
				num16 += width3;
				int pixel = (int)(Convert.ToUInt32(num6) >> 24);
				int pixel2 = num6 & 0xFF0000;
				int pixel3 = num6 & 0xFF00;
				int pixel4 = num6 & 0xFF;
				buffer5[0] = pixel;
				buffer6[0] = pixel2;
				buffer7[0] = pixel3;
				buffer8[0] = pixel4;
				for (int num17 = 1; num17 <= int_1; num17++)
				{
					int num7 = Class7177.smethod_2(Class7177.smethod_0(dest, num16));
					num16 += width3;
					next = (int)(Convert.ToUInt32(num7) >> 24);
					next2 = num7 & 0xFF0000;
					next3 = num7 & 0xFF00;
					next4 = num7 & 0xFF;
					buffer5[num17] = next;
					buffer6[num17] = next2;
					buffer7[num17] = next3;
					buffer8[num17] = next4;
					if (smethod_0(next, pixel, bool_0))
					{
						pixel = next;
						index = num17;
					}
					if (smethod_0(next2, pixel2, bool_0))
					{
						pixel2 = next2;
						index2 = num17;
					}
					if (smethod_0(next3, pixel3, bool_0))
					{
						pixel3 = next3;
						index3 = num17;
					}
					if (smethod_0(next4, pixel4, bool_0))
					{
						pixel4 = next4;
						index4 = num17;
					}
				}
				if (pixel <= 255 && pixel2 <= 255 && pixel3 <= 255 && pixel4 <= 255)
				{
					Class7177.smethod_1(ref dest, num4, Color.FromArgb(pixel, pixel2, pixel3, pixel4));
				}
				num4 += dest.Width;
				for (int num18 = 1; num18 <= int_1; num18++)
				{
					int num19 = num18 + int_1;
					int num8 = Class7177.smethod_2(Class7177.smethod_0(dest, num16));
					num16 += width3;
					pixel = buffer5[index];
					next = (buffer5[num19] = (int)(Convert.ToUInt32(num8) >> 24));
					if (smethod_0(next, pixel, bool_0))
					{
						pixel = next;
						index = num19;
					}
					pixel2 = buffer6[index2];
					next2 = (buffer6[num19] = num8 & 0xFF0000);
					if (smethod_0(next2, pixel2, bool_0))
					{
						pixel2 = next2;
						index2 = num19;
					}
					pixel3 = buffer7[index3];
					next3 = (buffer7[num19] = num8 & 0xFF00);
					if (smethod_0(next3, pixel3, bool_0))
					{
						pixel3 = next3;
						index3 = num19;
					}
					pixel4 = buffer8[index4];
					next4 = (buffer8[num19] = num8 & 0xFF);
					if (smethod_0(next4, pixel4, bool_0))
					{
						pixel4 = next4;
						index4 = num19;
					}
					Class7177.smethod_1(ref dest, num4, Color.FromArgb((byte)pixel, (byte)pixel2, (byte)pixel3, (byte)pixel4));
					num4 += width3;
				}
				for (int num20 = int_1 + 1; num20 <= height - 1 - int_1; num20++)
				{
					int num8 = Class7177.smethod_2(Class7177.smethod_0(dest, num16));
					num16 += width3;
					next = (int)(Convert.ToUInt32(num8) >> 24);
					next2 = num8 & 0xFF0000;
					next3 = num8 & 0xFF00;
					next4 = num8 & 0xFF;
					buffer5[num5] = next;
					buffer6[num5] = next2;
					buffer7[num5] = next3;
					buffer8[num5] = next4;
					if (index == num5)
					{
						pixel = buffer5[0];
						index = 0;
						for (int num21 = 1; num21 <= 2 * int_1; num21++)
						{
							next = buffer5[num21];
							if (smethod_0(next, pixel, bool_0))
							{
								pixel = next;
								index = num21;
							}
						}
					}
					else
					{
						pixel = buffer5[index];
						if (smethod_0(next, pixel, bool_0))
						{
							pixel = next;
							index = num5;
						}
					}
					if (index2 == num5)
					{
						pixel2 = buffer6[0];
						index2 = 0;
						for (int num22 = 1; num22 <= 2 * int_1; num22++)
						{
							next2 = buffer6[num22];
							if (smethod_0(next2, pixel2, bool_0))
							{
								pixel2 = next2;
								index2 = num22;
							}
						}
					}
					else
					{
						pixel2 = buffer6[index2];
						if (smethod_0(next2, pixel2, bool_0))
						{
							pixel2 = next2;
							index2 = num5;
						}
					}
					if (index3 == num5)
					{
						pixel3 = buffer7[0];
						index3 = 0;
						for (int num23 = 1; num23 <= 2 * int_1; num23++)
						{
							next3 = buffer7[num23];
							if (smethod_0(next3, pixel3, bool_0))
							{
								pixel3 = next3;
								index3 = num23;
							}
						}
					}
					else
					{
						pixel3 = buffer7[index3];
						if (smethod_0(next3, pixel3, bool_0))
						{
							pixel3 = next3;
							index3 = num5;
						}
					}
					if (index4 == num5)
					{
						pixel4 = buffer8[0];
						index4 = 0;
						for (int num24 = 1; num24 <= 2 * int_1; num24++)
						{
							next4 = buffer8[num24];
							if (smethod_0(next4, pixel4, bool_0))
							{
								pixel4 = next4;
								index4 = num24;
							}
						}
					}
					else
					{
						pixel4 = buffer8[index4];
						if (smethod_0(next4, pixel4, bool_0))
						{
							pixel4 = next4;
							index4 = num5;
						}
					}
					Class7177.smethod_1(ref dest, num4, Color.FromArgb((byte)pixel, (byte)pixel2, (byte)pixel3, (byte)pixel4));
					num4 += width3;
					num5 = (num5 + 1) % int_3;
				}
				int num25 = ((num5 == 0) ? (2 * int_1) : (num5 - 1));
				int num26 = int_3 - 1;
				for (int num27 = height - int_1; num27 < height - 1; num27++)
				{
					int num28 = (num5 + 1) % int_3;
					if (index == num5)
					{
						pixel = buffer5[num25];
						int height6 = num28;
						method_1(num26, ref next, ref buffer5, ref height6, ref pixel, ref index, int_3);
					}
					if (index2 == num5)
					{
						pixel2 = buffer6[num25];
						int height7 = num28;
						method_1(num26, ref next2, ref buffer6, ref height7, ref pixel2, ref index2, int_3);
					}
					if (index3 == num5)
					{
						pixel3 = buffer7[num25];
						int height8 = num28;
						method_1(num26, ref next3, ref buffer7, ref height8, ref pixel3, ref index3, int_3);
					}
					if (index4 == num5)
					{
						pixel4 = buffer8[num25];
						int height9 = num28;
						method_1(num26, ref next4, ref buffer8, ref height9, ref pixel4, ref index4, int_3);
					}
					Class7177.smethod_1(ref dest, num4, Color.FromArgb((byte)pixel, (byte)pixel2, (byte)pixel3, (byte)pixel4));
					num4 += width3;
					num5 = (num5 + 1) % int_3;
					num26--;
				}
			}
		}
		return dest;
	}
}
