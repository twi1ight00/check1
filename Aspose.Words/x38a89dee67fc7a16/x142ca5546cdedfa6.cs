using System;
using System.IO;

namespace x38a89dee67fc7a16;

internal class x142ca5546cdedfa6
{
	private enum x9e10ea2e70e7db1d
	{
		x19f1dcae7e3247ba,
		xf1810c0fff69031d
	}

	private const int x4b3523701496bcb7 = 1;

	private const short x9c983b3fbe672c69 = -1;

	private const short x02a13bf87cfbc83d = -2;

	private const int x16c54915dcb80b42 = 4;

	private const int x00a57a6507bfd95b = 2;

	private static readonly short[] x94df2247f6f192e8 = new short[327]
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

	private static readonly short[] x8341916a32034b30 = new short[327]
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

	private static readonly xcd20a6db055c59bf xa75d2a096fb40e6b = new xcd20a6db055c59bf(3, 1, 0);

	private static readonly int[] xcb0cb69d8b893841 = new int[9] { 0, 1, 3, 7, 15, 31, 63, 127, 255 };

	private static readonly byte[] x970586a917004cbd = new byte[256]
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

	private static readonly xcd20a6db055c59bf xdcbcb3327076d3d5 = new xcd20a6db055c59bf(4, 1, 0);

	private static readonly xcd20a6db055c59bf[] xa99e58aa2fbc422e = new xcd20a6db055c59bf[7]
	{
		new xcd20a6db055c59bf(7, 3, 0),
		new xcd20a6db055c59bf(6, 3, 0),
		new xcd20a6db055c59bf(3, 3, 0),
		new xcd20a6db055c59bf(1, 1, 0),
		new xcd20a6db055c59bf(3, 2, 0),
		new xcd20a6db055c59bf(6, 2, 0),
		new xcd20a6db055c59bf(7, 2, 0)
	};

	private static readonly byte[] x78fc584adb703c87 = new byte[256]
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

	private x79a2a2b1912e76bf xbe63ce924b03850f;

	private int x0072e110d37a0f02;

	private readonly int x1d8499b49e169191;

	private byte[] x4348c96b3a2259b3;

	private int x73f065a6b420cfe1;

	private bool xbd0b8bec7fb6b741;

	private bool xd07819797d96a94b;

	private x9e10ea2e70e7db1d x4800c8af96261435;

	private bool xcc90d343e053f58b;

	private xd3506b7c5c57eeb9 xddac07bf6c55d742;

	private int x42e5c99daad7b47e;

	private int x0ec2f946403639f7;

	private int x06daffaf8260f0c8;

	private int x62d9bfcf54e338cb;

	private Stream x6169576fb3c218d3;

	private byte[] x8827e5582ce52fa9;

	private int xb7789795fb30f693;

	private int xf9f5c3c1a0af8ace;

	private int xa51eb5aa5222c40b;

	private byte[] x0e85f8b67371795a;

	private int x185c63b9f929763d;

	private int xd44e5875fa7008a2;

	private x302a61bb21175bd5 x20650f9a1e8a75b3;

	private float xc01fd179bbea222c;

	public bool x4d18d829509725c2
	{
		get
		{
			return xd07819797d96a94b;
		}
		set
		{
			xd07819797d96a94b = value;
		}
	}

	public bool x9d4ba7c4540816af
	{
		get
		{
			return xbd0b8bec7fb6b741;
		}
		set
		{
			xbd0b8bec7fb6b741 = value;
		}
	}

	public x79a2a2b1912e76bf x9ba359ff37a3a63b
	{
		get
		{
			return xbe63ce924b03850f;
		}
		set
		{
			xbe63ce924b03850f = value;
		}
	}

	private bool xa7d20209be8eff86 => (xddac07bf6c55d742 & xd3506b7c5c57eeb9.x36b82d623394fb67) != 0;

	public x142ca5546cdedfa6()
	{
		x1d8499b49e169191 = 1;
	}

	public void x8291881ef07bb5c7(byte[] x5cafa8d49ea71ea1, x302a61bb21175bd5 x5ef231ffdec1346f, float x2463e0aa6364c53a, int xb28e4e0b2e9dba92, Stream xf823f0edaa261f3b)
	{
		x6169576fb3c218d3 = xf823f0edaa261f3b;
		xc01fd179bbea222c = x2463e0aa6364c53a;
		x42e5c99daad7b47e = xb28e4e0b2e9dba92;
		xd586e0c16bdae7fc(x5ef231ffdec1346f);
		x33077023b5ba77f6();
		x8eaa1257492440ab();
		if (xcc90d343e053f58b)
		{
			x2fbc74fb44323735(x5cafa8d49ea71ea1, 0, x5cafa8d49ea71ea1.Length);
		}
		else
		{
			xe9be81d63f50c077(x5cafa8d49ea71ea1, 0, x5cafa8d49ea71ea1.Length);
		}
		x73b856861ad43572();
		x8ffe90e7fbccfccd();
	}

	private void xd586e0c16bdae7fc(x302a61bb21175bd5 x5ef231ffdec1346f)
	{
		x20650f9a1e8a75b3 = x5ef231ffdec1346f;
		switch (x20650f9a1e8a75b3)
		{
		case x302a61bb21175bd5.x3f9c4affa0938c06:
			x02f9d82c16276d32();
			break;
		case x302a61bb21175bd5.x5137051dbacd8f06:
			x60f86617f354ed77();
			break;
		case x302a61bb21175bd5.x810adcc346e1d17e:
			x90f23f8a6ccc8383();
			break;
		case x302a61bb21175bd5.x1693cc0f7e432616:
			x2d1f1bb4b18f7920();
			break;
		}
	}

	private void x8eaa1257492440ab()
	{
		x0072e110d37a0f02 = 8;
		x73f065a6b420cfe1 = 0;
		x4800c8af96261435 = x9e10ea2e70e7db1d.x19f1dcae7e3247ba;
		if (x0e85f8b67371795a != null)
		{
			Array.Clear(x0e85f8b67371795a, 0, x0e85f8b67371795a.Length);
		}
		if (xa7d20209be8eff86)
		{
			x06daffaf8260f0c8 = ((xc01fd179bbea222c > 150f) ? 4 : 2);
			x0ec2f946403639f7 = x06daffaf8260f0c8 - 1;
		}
		else
		{
			x06daffaf8260f0c8 = 0;
			x0ec2f946403639f7 = 0;
		}
		x6136d74f0e2a1e03(null, -1);
	}

	private void x73b856861ad43572()
	{
		if (xcc90d343e053f58b)
		{
			x53a43891a857ad66();
		}
		else
		{
			x34c5aa230b8f39eb();
		}
	}

	private void x8ffe90e7fbccfccd()
	{
		if (!x4d18d829509725c2)
		{
			int num = 1;
			int num2 = 12;
			if (xa7d20209be8eff86)
			{
				num = (((num << 1 != 0) | (x4800c8af96261435 == x9e10ea2e70e7db1d.x19f1dcae7e3247ba)) ? 1 : 0);
				num2++;
			}
			for (int i = 0; i < 6; i++)
			{
				x0ff0ad565534daa6(num, num2);
			}
			x26af3224a80cf248();
		}
		if (xf9f5c3c1a0af8ace >= 0)
		{
			x9e23d62aa606bec2();
		}
	}

	private static bool xf6d1e4e97df6c4f3(int x374ea4fe62468d0f)
	{
		return x374ea4fe62468d0f % 4 == 0;
	}

	private static bool x1257280df5a058ef(int x374ea4fe62468d0f)
	{
		return x374ea4fe62468d0f % 2 == 0;
	}

	private static int x986b407f19e73734(byte[] x0c494e2b69d1a1bf, int xe90948374812a4c0, int x8d95d592d0a4e89b, int x652c6345a0b388d2)
	{
		int i = xe90948374812a4c0 + (x8d95d592d0a4e89b >> 3);
		int num = x652c6345a0b388d2 - x8d95d592d0a4e89b;
		int num2 = x8d95d592d0a4e89b & 7;
		int num3 = 0;
		if (num > 0 && num2 != 0)
		{
			num3 = x78fc584adb703c87[(x0c494e2b69d1a1bf[i] << num2) & 0xFF];
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
			for (; !xf6d1e4e97df6c4f3(i); i++)
			{
				if (x0c494e2b69d1a1bf[i] != 0)
				{
					return num3 + x78fc584adb703c87[x0c494e2b69d1a1bf[i]];
				}
				num3 += 8;
				num -= 8;
			}
			while (num >= 32)
			{
				bool flag = true;
				for (int j = 0; j < 4; j++)
				{
					if (x0c494e2b69d1a1bf[i + j] != 0)
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
		while (num >= 8)
		{
			if (x0c494e2b69d1a1bf[i] != 0)
			{
				return num3 + x78fc584adb703c87[x0c494e2b69d1a1bf[i]];
			}
			num3 += 8;
			num -= 8;
			i++;
		}
		if (num > 0)
		{
			num2 = x78fc584adb703c87[x0c494e2b69d1a1bf[i]];
			num3 += ((num2 > num) ? num : num2);
		}
		return num3;
	}

	private static int x75129a0c2ccadf3e(byte[] x0c494e2b69d1a1bf, int xe90948374812a4c0, int x8d95d592d0a4e89b, int x652c6345a0b388d2)
	{
		int i = xe90948374812a4c0 + (x8d95d592d0a4e89b >> 3);
		int num = x8d95d592d0a4e89b & 7;
		int num2 = 0;
		int num3 = x652c6345a0b388d2 - x8d95d592d0a4e89b;
		if (num3 > 0 && num != 0)
		{
			num2 = x970586a917004cbd[(x0c494e2b69d1a1bf[i] << num) & 0xFF];
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
			for (; !xf6d1e4e97df6c4f3(i); i++)
			{
				if (x0c494e2b69d1a1bf[i] != byte.MaxValue)
				{
					return num2 + x970586a917004cbd[x0c494e2b69d1a1bf[i]];
				}
				num2 += 8;
				num3 -= 8;
			}
			while (num3 >= 32)
			{
				bool flag = true;
				for (int j = 0; j < 4; j++)
				{
					if (x0c494e2b69d1a1bf[i + j] != byte.MaxValue)
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
		while (num3 >= 8)
		{
			if (x0c494e2b69d1a1bf[i] != byte.MaxValue)
			{
				return num2 + x970586a917004cbd[x0c494e2b69d1a1bf[i]];
			}
			num2 += 8;
			num3 -= 8;
			i++;
		}
		if (num3 > 0)
		{
			num = x970586a917004cbd[x0c494e2b69d1a1bf[i]];
			num2 += ((num > num3) ? num3 : num);
		}
		return num2;
	}

	private static int x1b2763544abd6ef2(byte[] x0c494e2b69d1a1bf, int xe90948374812a4c0, int x8d95d592d0a4e89b, int x652c6345a0b388d2, int x6c50a99faab7d741)
	{
		if (x6c50a99faab7d741 != 0)
		{
			return x8d95d592d0a4e89b + x75129a0c2ccadf3e(x0c494e2b69d1a1bf, xe90948374812a4c0, x8d95d592d0a4e89b, x652c6345a0b388d2);
		}
		return x8d95d592d0a4e89b + x986b407f19e73734(x0c494e2b69d1a1bf, xe90948374812a4c0, x8d95d592d0a4e89b, x652c6345a0b388d2);
	}

	private static int x20dddd1f6ee802b7(byte[] x0c494e2b69d1a1bf, int xe90948374812a4c0, int x8d95d592d0a4e89b, int x652c6345a0b388d2, int x6c50a99faab7d741)
	{
		if (x8d95d592d0a4e89b < x652c6345a0b388d2)
		{
			return x1b2763544abd6ef2(x0c494e2b69d1a1bf, xe90948374812a4c0, x8d95d592d0a4e89b, x652c6345a0b388d2, x6c50a99faab7d741);
		}
		return x652c6345a0b388d2;
	}

	private static int xfc61f4c50dcc296f(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
	{
		long num = (x08db3aeabb253cb1 + ((long)x1e218ceaee1bb583 - 1L)) / x1e218ceaee1bb583;
		if (num > int.MaxValue)
		{
			return 0;
		}
		return (int)num;
	}

	private static int x8b2ecf3d830a9342(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
	{
		return xfc61f4c50dcc296f(x08db3aeabb253cb1, x1e218ceaee1bb583) * x1e218ceaee1bb583;
	}

	private int x5dfd718ad310c66f()
	{
		return x4e5203198bdcb824(x490e30087768649f(x42e5c99daad7b47e, x1d8499b49e169191));
	}

	private static int x4e5203198bdcb824(int x08db3aeabb253cb1)
	{
		if ((x08db3aeabb253cb1 & 7) == 0)
		{
			return x08db3aeabb253cb1 >> 3;
		}
		return (x08db3aeabb253cb1 >> 3) + 1;
	}

	private static int x490e30087768649f(int x1b8fc2a57ddcd275, int x891d12f1350c2584)
	{
		int num = x1b8fc2a57ddcd275 * x891d12f1350c2584;
		if (x891d12f1350c2584 != 0 && num / x891d12f1350c2584 != x1b8fc2a57ddcd275)
		{
			num = 0;
		}
		return num;
	}

	private void x33077023b5ba77f6()
	{
		int num = x5dfd718ad310c66f();
		int x08db3aeabb253cb = x42e5c99daad7b47e;
		x185c63b9f929763d = num;
		xd44e5875fa7008a2 = x08db3aeabb253cb;
		bool flag = (xddac07bf6c55d742 & xd3506b7c5c57eeb9.x36b82d623394fb67) != 0 || x20650f9a1e8a75b3 == x302a61bb21175bd5.x1693cc0f7e432616;
		int num2 = x8b2ecf3d830a9342(x08db3aeabb253cb, 32);
		if (flag)
		{
			long num3 = (long)num2 * 2L;
			if (num3 > int.MaxValue)
			{
				return;
			}
			num2 = (int)num3;
		}
		if (num2 != 0 && (long)num2 * 2L <= int.MaxValue)
		{
			if (x20650f9a1e8a75b3 == x302a61bb21175bd5.x810adcc346e1d17e)
			{
				_ = xa7d20209be8eff86;
			}
			if (flag)
			{
				x0e85f8b67371795a = new byte[num + 1];
			}
			else
			{
				x0e85f8b67371795a = null;
			}
		}
	}

	private void x6136d74f0e2a1e03(byte[] x5cafa8d49ea71ea1, int x0ceec69a97f73617)
	{
		if (x0ceec69a97f73617 == -1)
		{
			if (x0ceec69a97f73617 < 8192)
			{
				x0ceec69a97f73617 = 8192;
			}
			x5cafa8d49ea71ea1 = null;
		}
		if (x5cafa8d49ea71ea1 == null)
		{
			x5cafa8d49ea71ea1 = new byte[x0ceec69a97f73617];
		}
		x8827e5582ce52fa9 = x5cafa8d49ea71ea1;
		xb7789795fb30f693 = x0ceec69a97f73617;
		xf9f5c3c1a0af8ace = 0;
		xa51eb5aa5222c40b = 0;
	}

	private void x8cb45d3f8f715e9c()
	{
		int num = 0;
		do
		{
			int num2 = x986b407f19e73734(x4348c96b3a2259b3, x62d9bfcf54e338cb, num, xd44e5875fa7008a2);
			x1f2084f4dd06cd8e(num2, x8817783956c850fc: false);
			num += num2;
			if (num >= xd44e5875fa7008a2)
			{
				break;
			}
			num2 = x75129a0c2ccadf3e(x4348c96b3a2259b3, x62d9bfcf54e338cb, num, xd44e5875fa7008a2);
			x1f2084f4dd06cd8e(num2, x8817783956c850fc: true);
			num += num2;
		}
		while (num < xd44e5875fa7008a2);
		if (x9ba359ff37a3a63b != 0)
		{
			if (x0072e110d37a0f02 != 8)
			{
				x26af3224a80cf248();
			}
			if (x9ba359ff37a3a63b == x79a2a2b1912e76bf.xe89828e8b8199286 && !x1257280df5a058ef(xa51eb5aa5222c40b))
			{
				x26af3224a80cf248();
			}
		}
	}

	private void x8950679064806386()
	{
		int num = 0;
		int num2 = ((x05c283464b179d05(x4348c96b3a2259b3, x62d9bfcf54e338cb, 0) == 0) ? x1b2763544abd6ef2(x4348c96b3a2259b3, x62d9bfcf54e338cb, 0, xd44e5875fa7008a2, 0) : 0);
		int num3 = ((x05c283464b179d05(x0e85f8b67371795a, 0, 0) == 0) ? x1b2763544abd6ef2(x0e85f8b67371795a, 0, 0, xd44e5875fa7008a2, 0) : 0);
		while (true)
		{
			int num4 = x20dddd1f6ee802b7(x0e85f8b67371795a, 0, num3, xd44e5875fa7008a2, x05c283464b179d05(x0e85f8b67371795a, 0, num3));
			if (num4 >= num2)
			{
				int num5 = num3 - num2;
				if (-3 > num5 || num5 > 3)
				{
					int num6 = x20dddd1f6ee802b7(x4348c96b3a2259b3, x62d9bfcf54e338cb, num2, xd44e5875fa7008a2, x05c283464b179d05(x4348c96b3a2259b3, x62d9bfcf54e338cb, num2));
					xb1d1e08caceefb56(xa75d2a096fb40e6b);
					if (num + num2 == 0 || x05c283464b179d05(x4348c96b3a2259b3, x62d9bfcf54e338cb, num) == 0)
					{
						x1f2084f4dd06cd8e(num2 - num, x8817783956c850fc: false);
						x1f2084f4dd06cd8e(num6 - num2, x8817783956c850fc: true);
					}
					else
					{
						x1f2084f4dd06cd8e(num2 - num, x8817783956c850fc: true);
						x1f2084f4dd06cd8e(num6 - num2, x8817783956c850fc: false);
					}
					num = num6;
				}
				else
				{
					xb1d1e08caceefb56(xa99e58aa2fbc422e[num5 + 3]);
					num = num2;
				}
			}
			else
			{
				xb1d1e08caceefb56(xdcbcb3327076d3d5);
				num = num4;
			}
			if (num >= xd44e5875fa7008a2)
			{
				break;
			}
			num2 = x1b2763544abd6ef2(x4348c96b3a2259b3, x62d9bfcf54e338cb, num, xd44e5875fa7008a2, x05c283464b179d05(x4348c96b3a2259b3, x62d9bfcf54e338cb, num));
			num3 = x1b2763544abd6ef2(x6c50a99faab7d741: (x05c283464b179d05(x4348c96b3a2259b3, x62d9bfcf54e338cb, num) == 0) ? 1 : 0, x0c494e2b69d1a1bf: x0e85f8b67371795a, xe90948374812a4c0: 0, x8d95d592d0a4e89b: num, x652c6345a0b388d2: xd44e5875fa7008a2);
			num3 = x1b2763544abd6ef2(x0e85f8b67371795a, 0, num3, xd44e5875fa7008a2, x05c283464b179d05(x4348c96b3a2259b3, x62d9bfcf54e338cb, num));
		}
	}

	private static int x05c283464b179d05(byte[] x1ef26dbdd5d13d24, int x1628e2f8172842fd, int xdcd21dec40332493)
	{
		return (x1ef26dbdd5d13d24[Math.Min(x1628e2f8172842fd + (xdcd21dec40332493 >> 3), x1ef26dbdd5d13d24.Length - 1)] >> 7 - (xdcd21dec40332493 & 7)) & 1;
	}

	private void xe9be81d63f50c077(byte[] x5cafa8d49ea71ea1, int x374ea4fe62468d0f, int x10f4d88af727adbc)
	{
		x4348c96b3a2259b3 = x5cafa8d49ea71ea1;
		x62d9bfcf54e338cb = x374ea4fe62468d0f;
		while (x10f4d88af727adbc > 0)
		{
			if (!x9d4ba7c4540816af)
			{
				xf09d9305a4625374();
			}
			if (xa7d20209be8eff86)
			{
				if (x4800c8af96261435 == x9e10ea2e70e7db1d.x19f1dcae7e3247ba)
				{
					x8cb45d3f8f715e9c();
					x4800c8af96261435 = x9e10ea2e70e7db1d.xf1810c0fff69031d;
				}
				else
				{
					x8950679064806386();
					x0ec2f946403639f7--;
				}
				if (x0ec2f946403639f7 == 0)
				{
					x4800c8af96261435 = x9e10ea2e70e7db1d.x19f1dcae7e3247ba;
					x0ec2f946403639f7 = x06daffaf8260f0c8 - 1;
				}
				else
				{
					Buffer.BlockCopy(x4348c96b3a2259b3, x62d9bfcf54e338cb, x0e85f8b67371795a, 0, x185c63b9f929763d);
				}
			}
			else
			{
				x8cb45d3f8f715e9c();
			}
			x62d9bfcf54e338cb += x185c63b9f929763d;
			x10f4d88af727adbc -= x185c63b9f929763d;
		}
	}

	private void x34c5aa230b8f39eb()
	{
		if (x0072e110d37a0f02 != 8)
		{
			x26af3224a80cf248();
		}
	}

	private void x90f23f8a6ccc8383()
	{
		xddac07bf6c55d742 = (xd3506b7c5c57eeb9)0;
		x0e85f8b67371795a = null;
		xcc90d343e053f58b = false;
	}

	private void x9e23d62aa606bec2()
	{
		if (xf9f5c3c1a0af8ace > 0)
		{
			x6169576fb3c218d3.Write(x8827e5582ce52fa9, 0, xf9f5c3c1a0af8ace);
			xf9f5c3c1a0af8ace = 0;
			xa51eb5aa5222c40b = 0;
		}
	}

	private void x26af3224a80cf248()
	{
		if (xf9f5c3c1a0af8ace >= xb7789795fb30f693)
		{
			x9e23d62aa606bec2();
		}
		x8827e5582ce52fa9[xa51eb5aa5222c40b] = (byte)x73f065a6b420cfe1;
		xa51eb5aa5222c40b++;
		xf9f5c3c1a0af8ace++;
		x73f065a6b420cfe1 = 0;
		x0072e110d37a0f02 = 8;
	}

	private void x0ff0ad565534daa6(int x4b8b317913377903, int x961016a387451f05)
	{
		while (x961016a387451f05 > x0072e110d37a0f02)
		{
			x73f065a6b420cfe1 |= x4b8b317913377903 >> x961016a387451f05 - x0072e110d37a0f02;
			x961016a387451f05 -= x0072e110d37a0f02;
			x26af3224a80cf248();
		}
		x73f065a6b420cfe1 |= (x4b8b317913377903 & xcb0cb69d8b893841[x961016a387451f05]) << x0072e110d37a0f02 - x961016a387451f05;
		x0072e110d37a0f02 -= x961016a387451f05;
		if (x0072e110d37a0f02 == 0)
		{
			x26af3224a80cf248();
		}
	}

	private void xb1d1e08caceefb56(xcd20a6db055c59bf xdccaaba63bb4f10b)
	{
		x0ff0ad565534daa6(xdccaaba63bb4f10b.xb0b4ff1622a01d12, xdccaaba63bb4f10b.x1be93eed8950d961);
	}

	private void x1f2084f4dd06cd8e(int x5906905c888d3d98, bool x8817783956c850fc)
	{
		short[] x9d5750eb2d6373bc = ((!x8817783956c850fc) ? x8341916a32034b30 : x94df2247f6f192e8);
		xcd20a6db055c59bf xcd20a6db055c59bf2 = xcd20a6db055c59bf.xf38f54ad368a4a36(x9d5750eb2d6373bc, 103);
		while (x5906905c888d3d98 >= 2624)
		{
			x0ff0ad565534daa6(xcd20a6db055c59bf2.xb0b4ff1622a01d12, xcd20a6db055c59bf2.x1be93eed8950d961);
			x5906905c888d3d98 -= xcd20a6db055c59bf2.x30b362a3009d1d63;
		}
		if (x5906905c888d3d98 >= 64)
		{
			xcd20a6db055c59bf2 = xcd20a6db055c59bf.xf38f54ad368a4a36(x9d5750eb2d6373bc, 63 + (x5906905c888d3d98 >> 6));
			x0ff0ad565534daa6(xcd20a6db055c59bf2.xb0b4ff1622a01d12, xcd20a6db055c59bf2.x1be93eed8950d961);
			x5906905c888d3d98 -= xcd20a6db055c59bf2.x30b362a3009d1d63;
		}
		xcd20a6db055c59bf2 = xcd20a6db055c59bf.xf38f54ad368a4a36(x9d5750eb2d6373bc, x5906905c888d3d98);
		x0ff0ad565534daa6(xcd20a6db055c59bf2.xb0b4ff1622a01d12, xcd20a6db055c59bf2.x1be93eed8950d961);
	}

	private void xf09d9305a4625374()
	{
		if ((xddac07bf6c55d742 & xd3506b7c5c57eeb9.x8e286ac1c480dfb3) != 0)
		{
			int num = 4;
			if (num != x0072e110d37a0f02)
			{
				num = ((num <= x0072e110d37a0f02) ? (x0072e110d37a0f02 - num) : (x0072e110d37a0f02 + (8 - num)));
				x0ff0ad565534daa6(0, num);
			}
		}
		int num2 = 1;
		int num3 = 12;
		if (xa7d20209be8eff86)
		{
			num2 <<= 1;
			if (x4800c8af96261435 == x9e10ea2e70e7db1d.x19f1dcae7e3247ba)
			{
				num2++;
			}
			num3++;
		}
		x0ff0ad565534daa6(num2, num3);
	}

	private void x02f9d82c16276d32()
	{
		x90f23f8a6ccc8383();
		x9ba359ff37a3a63b = x79a2a2b1912e76bf.xc0f9b651d77da240;
		x9d4ba7c4540816af = true;
		x4d18d829509725c2 = true;
	}

	private void x60f86617f354ed77()
	{
		x90f23f8a6ccc8383();
		x9ba359ff37a3a63b = x79a2a2b1912e76bf.xe89828e8b8199286;
		x9d4ba7c4540816af = true;
		x4d18d829509725c2 = true;
	}

	private void x2d1f1bb4b18f7920()
	{
		x90f23f8a6ccc8383();
		xcc90d343e053f58b = true;
	}

	private void x2fbc74fb44323735(byte[] x5cafa8d49ea71ea1, int x374ea4fe62468d0f, int x10f4d88af727adbc)
	{
		x4348c96b3a2259b3 = x5cafa8d49ea71ea1;
		x62d9bfcf54e338cb = x374ea4fe62468d0f;
		while (x10f4d88af727adbc > 0)
		{
			x8950679064806386();
			Buffer.BlockCopy(x4348c96b3a2259b3, x62d9bfcf54e338cb, x0e85f8b67371795a, 0, x185c63b9f929763d);
			x62d9bfcf54e338cb += x185c63b9f929763d;
			x10f4d88af727adbc -= x185c63b9f929763d;
		}
	}

	private void x53a43891a857ad66()
	{
		x0ff0ad565534daa6(1, 12);
		x0ff0ad565534daa6(1, 12);
		if (x0072e110d37a0f02 != 8)
		{
			x26af3224a80cf248();
		}
	}
}
