using System;
using System.IO;

namespace ns233;

internal class Class6139
{
	private enum Enum784
	{
		const_0,
		const_1
	}

	private const int int_0 = 1;

	private const short short_0 = -1;

	private const short short_1 = -2;

	private const int int_1 = 4;

	private const int int_2 = 2;

	private static readonly short[] short_2 = new short[327]
	{
		10, 55, 0, 3, 2, 1, 2, 3, 2, 2,
		2, 3, 3, 3, 4, 4, 3, 5, 4, 2,
		6, 5, 3, 7, 6, 5, 8, 6, 4, 9,
		7, 4, 10, 7, 5, 11, 7, 7, 12, 8,
		4, 13, 8, 7, 14, 9, 24, 15, 10, 23,
		16, 10, 24, 17, 10, 8, 18, 11, 103, 19,
		11, 104, 20, 11, 108, 21, 11, 55, 22, 11,
		40, 23, 11, 23, 24, 11, 24, 25, 12, 202,
		26, 12, 203, 27, 12, 204, 28, 12, 205, 29,
		12, 104, 30, 12, 105, 31, 12, 106, 32, 12,
		107, 33, 12, 210, 34, 12, 211, 35, 12, 212,
		36, 12, 213, 37, 12, 214, 38, 12, 215, 39,
		12, 108, 40, 12, 109, 41, 12, 218, 42, 12,
		219, 43, 12, 84, 44, 12, 85, 45, 12, 86,
		46, 12, 87, 47, 12, 100, 48, 12, 101, 49,
		12, 82, 50, 12, 83, 51, 12, 36, 52, 12,
		55, 53, 12, 56, 54, 12, 39, 55, 12, 40,
		56, 12, 88, 57, 12, 89, 58, 12, 43, 59,
		12, 44, 60, 12, 90, 61, 12, 102, 62, 12,
		103, 63, 10, 15, 64, 12, 200, 128, 12, 201,
		192, 12, 91, 256, 12, 51, 320, 12, 52, 384,
		12, 53, 448, 13, 108, 512, 13, 109, 576, 13,
		74, 640, 13, 75, 704, 13, 76, 768, 13, 77,
		832, 13, 114, 896, 13, 115, 960, 13, 116, 1024,
		13, 117, 1088, 13, 118, 1152, 13, 119, 1216, 13,
		82, 1280, 13, 83, 1344, 13, 84, 1408, 13, 85,
		1472, 13, 90, 1536, 13, 91, 1600, 13, 100, 1664,
		13, 101, 1728, 11, 8, 1792, 11, 12, 1856, 11,
		13, 1920, 12, 18, 1984, 12, 19, 2048, 12, 20,
		2112, 12, 21, 2176, 12, 22, 2240, 12, 23, 2304,
		12, 28, 2368, 12, 29, 2432, 12, 30, 2496, 12,
		31, 2560, 12, 1, -1, 9, 1, -2, 10, 1,
		-2, 11, 1, -2, 12, 0, -2
	};

	private static readonly short[] short_3 = new short[327]
	{
		8, 53, 0, 6, 7, 1, 4, 7, 2, 4,
		8, 3, 4, 11, 4, 4, 12, 5, 4, 14,
		6, 4, 15, 7, 5, 19, 8, 5, 20, 9,
		5, 7, 10, 5, 8, 11, 6, 8, 12, 6,
		3, 13, 6, 52, 14, 6, 53, 15, 6, 42,
		16, 6, 43, 17, 7, 39, 18, 7, 12, 19,
		7, 8, 20, 7, 23, 21, 7, 3, 22, 7,
		4, 23, 7, 40, 24, 7, 43, 25, 7, 19,
		26, 7, 36, 27, 7, 24, 28, 8, 2, 29,
		8, 3, 30, 8, 26, 31, 8, 27, 32, 8,
		18, 33, 8, 19, 34, 8, 20, 35, 8, 21,
		36, 8, 22, 37, 8, 23, 38, 8, 40, 39,
		8, 41, 40, 8, 42, 41, 8, 43, 42, 8,
		44, 43, 8, 45, 44, 8, 4, 45, 8, 5,
		46, 8, 10, 47, 8, 11, 48, 8, 82, 49,
		8, 83, 50, 8, 84, 51, 8, 85, 52, 8,
		36, 53, 8, 37, 54, 8, 88, 55, 8, 89,
		56, 8, 90, 57, 8, 91, 58, 8, 74, 59,
		8, 75, 60, 8, 50, 61, 8, 51, 62, 8,
		52, 63, 5, 27, 64, 5, 18, 128, 6, 23,
		192, 7, 55, 256, 8, 54, 320, 8, 55, 384,
		8, 100, 448, 8, 101, 512, 8, 104, 576, 8,
		103, 640, 9, 204, 704, 9, 205, 768, 9, 210,
		832, 9, 211, 896, 9, 212, 960, 9, 213, 1024,
		9, 214, 1088, 9, 215, 1152, 9, 216, 1216, 9,
		217, 1280, 9, 218, 1344, 9, 219, 1408, 9, 152,
		1472, 9, 153, 1536, 9, 154, 1600, 6, 24, 1664,
		9, 155, 1728, 11, 8, 1792, 11, 12, 1856, 11,
		13, 1920, 12, 18, 1984, 12, 19, 2048, 12, 20,
		2112, 12, 21, 2176, 12, 22, 2240, 12, 23, 2304,
		12, 28, 2368, 12, 29, 2432, 12, 30, 2496, 12,
		31, 2560, 12, 1, -1, 9, 1, -2, 10, 1,
		-2, 11, 1, -2, 12, 0, -2
	};

	private static readonly Struct217 struct217_0 = new Struct217(3, 1, 0);

	private static readonly int[] int_3 = new int[9] { 0, 1, 3, 7, 15, 31, 63, 127, 255 };

	private static readonly byte[] byte_0 = new byte[256]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 2, 2, 2, 2, 2, 2, 2, 2,
		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
		2, 2, 2, 2, 3, 3, 3, 3, 3, 3,
		3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
		4, 4, 4, 4, 4, 4, 4, 4, 5, 5,
		5, 5, 6, 6, 7, 8
	};

	private static readonly Struct217 struct217_1 = new Struct217(4, 1, 0);

	private static readonly Struct217[] struct217_2 = new Struct217[7]
	{
		new Struct217(7, 3, 0),
		new Struct217(6, 3, 0),
		new Struct217(3, 3, 0),
		new Struct217(1, 1, 0),
		new Struct217(3, 2, 0),
		new Struct217(6, 2, 0),
		new Struct217(7, 2, 0)
	};

	private static readonly byte[] byte_1 = new byte[256]
	{
		8, 7, 6, 6, 5, 5, 5, 5, 4, 4,
		4, 4, 4, 4, 4, 4, 3, 3, 3, 3,
		3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
		3, 3, 2, 2, 2, 2, 2, 2, 2, 2,
		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
		2, 2, 2, 2, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
		1, 1, 1, 1, 1, 1, 1, 1, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0
	};

	private Enum782 enum782_0;

	private int int_4;

	private readonly int int_5;

	private byte[] byte_2;

	private int int_6;

	private bool bool_0;

	private bool bool_1;

	private Enum784 enum784_0;

	private bool bool_2;

	private Enum785 enum785_0;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private Stream stream_0;

	private byte[] byte_3;

	private int int_11;

	private int int_12;

	private int int_13;

	private byte[] byte_4;

	private int int_14;

	private int int_15;

	private Enum783 enum783_0;

	private float float_0;

	public bool DontWriteRtc
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool DontWriteEol
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Enum782 Alignment
	{
		get
		{
			return enum782_0;
		}
		set
		{
			enum782_0 = value;
		}
	}

	private bool Is2DEncoding => (enum785_0 & Enum785.const_1) != 0;

	public Class6139()
	{
		int_5 = 1;
	}

	public void method_0(byte[] buffer, Enum783 scheme, float verticalResolution, int imageWidth, Stream outputStream)
	{
		stream_0 = outputStream;
		float_0 = verticalResolution;
		int_7 = imageWidth;
		method_1(scheme);
		method_5();
		method_2();
		if (bool_2)
		{
			method_21(buffer, 0, buffer.Length);
		}
		else
		{
			method_9(buffer, 0, buffer.Length);
		}
		method_3();
		Close();
	}

	private void method_1(Enum783 scheme)
	{
		enum783_0 = scheme;
		switch (enum783_0)
		{
		case Enum783.const_5:
			method_19();
			break;
		case Enum783.const_0:
			method_18();
			break;
		case Enum783.const_1:
			method_11();
			break;
		case Enum783.const_3:
			method_20();
			break;
		}
	}

	private void method_2()
	{
		int_4 = 8;
		int_6 = 0;
		enum784_0 = Enum784.const_0;
		if (byte_4 != null)
		{
			Array.Clear(byte_4, 0, byte_4.Length);
		}
		if (Is2DEncoding)
		{
			int_9 = ((float_0 > 150f) ? 4 : 2);
			int_8 = int_9 - 1;
		}
		else
		{
			int_9 = 0;
			int_8 = 0;
		}
		method_6(null, -1);
	}

	private void method_3()
	{
		if (bool_2)
		{
			method_22();
		}
		else
		{
			method_10();
		}
	}

	private void Close()
	{
		if (!DontWriteRtc)
		{
			int num = 1;
			int num2 = 12;
			if (Is2DEncoding)
			{
				num = (((num << 1 != 0) | (enum784_0 == Enum784.const_0)) ? 1 : 0);
				num2++;
			}
			for (int i = 0; i < 6; i++)
			{
				method_14(num, num2);
			}
			method_13();
		}
		if (int_12 >= 0)
		{
			method_12();
		}
	}

	private static bool smethod_0(int offset)
	{
		return offset % 4 == 0;
	}

	private static bool smethod_1(int offset)
	{
		return offset % 2 == 0;
	}

	private static int smethod_2(byte[] bp, int bpOffset, int bs, int be)
	{
		int i = bpOffset + (bs >> 3);
		int num = be - bs;
		int num2 = bs & 7;
		int num3 = 0;
		if (num > 0 && num2 != 0)
		{
			num3 = byte_1[(bp[i] << num2) & 0xFF];
			if (num3 > 8 - num2)
			{
				num3 = 8 - num2;
			}
			if (num3 > num)
			{
				num3 = num;
			}
			if (num2 + num3 < 8)
			{
				return num3;
			}
			num -= num3;
			i++;
		}
		if (num >= 64)
		{
			for (; !smethod_0(i); i++)
			{
				if (bp[i] == 0)
				{
					num3 += 8;
					num -= 8;
					continue;
				}
				return num3 + byte_1[bp[i]];
			}
			while (num >= 32)
			{
				bool flag = true;
				for (int j = 0; j < 4; j++)
				{
					if (bp[i + j] != 0)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num3 += 32;
				num -= 32;
				i += 4;
			}
		}
		while (true)
		{
			if (num >= 8)
			{
				if (bp[i] != 0)
				{
					break;
				}
				num3 += 8;
				num -= 8;
				i++;
				continue;
			}
			if (num > 0)
			{
				num2 = byte_1[bp[i]];
				num3 += ((num2 > num) ? num : num2);
			}
			return num3;
		}
		return num3 + byte_1[bp[i]];
	}

	private static int smethod_3(byte[] bp, int bpOffset, int bs, int be)
	{
		int i = bpOffset + (bs >> 3);
		int num = bs & 7;
		int num2 = 0;
		int num3 = be - bs;
		if (num3 > 0 && num != 0)
		{
			num2 = byte_0[(bp[i] << num) & 0xFF];
			if (num2 > 8 - num)
			{
				num2 = 8 - num;
			}
			if (num2 > num3)
			{
				num2 = num3;
			}
			if (num + num2 < 8)
			{
				return num2;
			}
			num3 -= num2;
			i++;
		}
		if (num3 >= 64)
		{
			for (; !smethod_0(i); i++)
			{
				if (bp[i] == byte.MaxValue)
				{
					num2 += 8;
					num3 -= 8;
					continue;
				}
				return num2 + byte_0[bp[i]];
			}
			while (num3 >= 32)
			{
				bool flag = true;
				for (int j = 0; j < 4; j++)
				{
					if (bp[i + j] != byte.MaxValue)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
				num2 += 32;
				num3 -= 32;
				i += 4;
			}
		}
		while (true)
		{
			if (num3 >= 8)
			{
				if (bp[i] != byte.MaxValue)
				{
					break;
				}
				num2 += 8;
				num3 -= 8;
				i++;
				continue;
			}
			if (num3 > 0)
			{
				num = byte_0[bp[i]];
				num2 += ((num > num3) ? num3 : num);
			}
			return num2;
		}
		return num2 + byte_0[bp[i]];
	}

	private static int smethod_4(byte[] bp, int bpOffset, int bs, int be, int color)
	{
		if (color != 0)
		{
			return bs + smethod_3(bp, bpOffset, bs, be);
		}
		return bs + smethod_2(bp, bpOffset, bs, be);
	}

	private static int smethod_5(byte[] bp, int bpOffset, int bs, int be, int color)
	{
		if (bs < be)
		{
			return smethod_4(bp, bpOffset, bs, be, color);
		}
		return be;
	}

	private static int smethod_6(int x, int y)
	{
		long num = (x + (y - 1L)) / y;
		if (num > 2147483647L)
		{
			return 0;
		}
		return (int)num;
	}

	private static int smethod_7(int x, int y)
	{
		return smethod_6(x, y) * y;
	}

	private int method_4()
	{
		return smethod_8(smethod_9(int_7, int_5));
	}

	private static int smethod_8(int x)
	{
		if ((x & 7) == 0)
		{
			return x >> 3;
		}
		return (x >> 3) + 1;
	}

	private static int smethod_9(int nmemb, int elemSize)
	{
		int num = nmemb * elemSize;
		if (elemSize != 0 && num / elemSize != nmemb)
		{
			num = 0;
		}
		return num;
	}

	private void method_5()
	{
		int num = method_4();
		int x = int_7;
		int_14 = num;
		int_15 = x;
		bool flag = (enum785_0 & Enum785.const_1) != 0 || enum783_0 == Enum783.const_3;
		int num2 = smethod_7(x, 32);
		if (flag)
		{
			long num3 = num2 * 2L;
			if (num3 > 2147483647L)
			{
				return;
			}
			num2 = (int)num3;
		}
		if (num2 != 0 && num2 * 2L <= 2147483647L)
		{
			if (enum783_0 == Enum783.const_1)
			{
				_ = Is2DEncoding;
			}
			if (flag)
			{
				byte_4 = new byte[num + 1];
			}
			else
			{
				byte_4 = null;
			}
		}
	}

	private void method_6(byte[] buffer, int size)
	{
		if (size == -1)
		{
			if (size < 8192)
			{
				size = 8192;
			}
			buffer = null;
		}
		if (buffer == null)
		{
			buffer = new byte[size];
		}
		byte_3 = buffer;
		int_11 = size;
		int_12 = 0;
		int_13 = 0;
	}

	private void method_7()
	{
		int num = 0;
		do
		{
			int num2 = smethod_2(byte_2, int_10, num, int_15);
			method_16(num2, useBlack: false);
			num += num2;
			if (num >= int_15)
			{
				break;
			}
			num2 = smethod_3(byte_2, int_10, num, int_15);
			method_16(num2, useBlack: true);
			num += num2;
		}
		while (num < int_15);
		if (Alignment != 0)
		{
			if (int_4 != 8)
			{
				method_13();
			}
			if (Alignment == Enum782.const_2 && !smethod_1(int_13))
			{
				method_13();
			}
		}
	}

	private void method_8()
	{
		int num = 0;
		int num2 = ((smethod_10(byte_2, int_10, 0) == 0) ? smethod_4(byte_2, int_10, 0, int_15, 0) : 0);
		int num3 = ((smethod_10(byte_4, 0, 0) == 0) ? smethod_4(byte_4, 0, 0, int_15, 0) : 0);
		while (true)
		{
			int num4 = smethod_5(byte_4, 0, num3, int_15, smethod_10(byte_4, 0, num3));
			if (num4 < num2)
			{
				method_15(struct217_1);
				num = num4;
			}
			else
			{
				int num5 = num3 - num2;
				if (-3 <= num5 && num5 <= 3)
				{
					method_15(struct217_2[num5 + 3]);
					num = num2;
				}
				else
				{
					int num6 = smethod_5(byte_2, int_10, num2, int_15, smethod_10(byte_2, int_10, num2));
					method_15(struct217_0);
					if (num + num2 != 0 && smethod_10(byte_2, int_10, num) != 0)
					{
						method_16(num2 - num, useBlack: true);
						method_16(num6 - num2, useBlack: false);
					}
					else
					{
						method_16(num2 - num, useBlack: false);
						method_16(num6 - num2, useBlack: true);
					}
					num = num6;
				}
			}
			if (num < int_15)
			{
				num2 = smethod_4(byte_2, int_10, num, int_15, smethod_10(byte_2, int_10, num));
				num3 = smethod_4(color: (smethod_10(byte_2, int_10, num) == 0) ? 1 : 0, bp: byte_4, bpOffset: 0, bs: num, be: int_15);
				num3 = smethod_4(byte_4, 0, num3, int_15, smethod_10(byte_2, int_10, num));
				continue;
			}
			break;
		}
	}

	private static int smethod_10(byte[] buf, int bufOffset, int ix)
	{
		return (buf[Math.Min(bufOffset + (ix >> 3), buf.Length - 1)] >> 7 - (ix & 7)) & 1;
	}

	private void method_9(byte[] buffer, int offset, int count)
	{
		byte_2 = buffer;
		int_10 = offset;
		while (count > 0)
		{
			if (!DontWriteEol)
			{
				method_17();
			}
			if (Is2DEncoding)
			{
				if (enum784_0 == Enum784.const_0)
				{
					method_7();
					enum784_0 = Enum784.const_1;
				}
				else
				{
					method_8();
					int_8--;
				}
				if (int_8 == 0)
				{
					enum784_0 = Enum784.const_0;
					int_8 = int_9 - 1;
				}
				else
				{
					Buffer.BlockCopy(byte_2, int_10, byte_4, 0, int_14);
				}
			}
			else
			{
				method_7();
			}
			int_10 += int_14;
			count -= int_14;
		}
	}

	private void method_10()
	{
		if (int_4 != 8)
		{
			method_13();
		}
	}

	private void method_11()
	{
		enum785_0 = (Enum785)0;
		byte_4 = null;
		bool_2 = false;
	}

	private void method_12()
	{
		if (int_12 > 0)
		{
			stream_0.Write(byte_3, 0, int_12);
			int_12 = 0;
			int_13 = 0;
		}
	}

	private void method_13()
	{
		if (int_12 >= int_11)
		{
			method_12();
		}
		byte_3[int_13] = (byte)int_6;
		int_13++;
		int_12++;
		int_6 = 0;
		int_4 = 8;
	}

	private void method_14(int bits, int length)
	{
		while (length > int_4)
		{
			int_6 |= bits >> length - int_4;
			length -= int_4;
			method_13();
		}
		int_6 |= (bits & int_3[length]) << int_4 - length;
		int_4 -= length;
		if (int_4 == 0)
		{
			method_13();
		}
	}

	private void method_15(Struct217 te)
	{
		method_14(te.short_0, te.short_1);
	}

	private void method_16(int span, bool useBlack)
	{
		short[] array = ((!useBlack) ? short_3 : short_2);
		Struct217 @struct = Struct217.smethod_0(array, 103);
		while (span >= 2624)
		{
			method_14(@struct.short_0, @struct.short_1);
			span -= @struct.short_2;
		}
		if (span >= 64)
		{
			@struct = Struct217.smethod_0(array, 63 + (span >> 6));
			method_14(@struct.short_0, @struct.short_1);
			span -= @struct.short_2;
		}
		@struct = Struct217.smethod_0(array, span);
		method_14(@struct.short_0, @struct.short_1);
	}

	private void method_17()
	{
		if ((enum785_0 & Enum785.const_3) != 0)
		{
			int num = 4;
			if (4 != int_4)
			{
				num = ((num <= int_4) ? (int_4 - num) : (int_4 + (8 - num)));
				method_14(0, num);
			}
		}
		int num2 = 1;
		int num3 = 12;
		if (Is2DEncoding)
		{
			num2 <<= 1;
			if (enum784_0 == Enum784.const_0)
			{
				num2++;
			}
			num3++;
		}
		method_14(num2, num3);
	}

	private void method_18()
	{
		method_11();
		Alignment = Enum782.const_1;
		DontWriteEol = true;
		DontWriteRtc = true;
	}

	private void method_19()
	{
		method_11();
		Alignment = Enum782.const_2;
		DontWriteEol = true;
		DontWriteRtc = true;
	}

	private void method_20()
	{
		method_11();
		bool_2 = true;
	}

	private void method_21(byte[] buffer, int offset, int count)
	{
		byte_2 = buffer;
		int_10 = offset;
		while (count > 0)
		{
			method_8();
			Buffer.BlockCopy(byte_2, int_10, byte_4, 0, int_14);
			int_10 += int_14;
			count -= int_14;
		}
	}

	private void method_22()
	{
		method_14(1, 12);
		method_14(1, 12);
		if (int_4 != 8)
		{
			method_13();
		}
	}
}
