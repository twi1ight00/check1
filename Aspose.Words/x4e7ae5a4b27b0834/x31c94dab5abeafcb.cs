using System;
using System.Collections;
using System.Text;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace x4e7ae5a4b27b0834;

internal class x31c94dab5abeafcb
{
	private const int xa80ed5bbe231350b = 0;

	private const int xf7c530bf6a00f81c = 21;

	private const int x53aa24a7c198052e = 12;

	private const int xebd534d59de4313b = 32;

	private const int x5bf02e7fb0357c4b = 246;

	private const int xeb72bff132eb5226 = 247;

	private const int x4e27ed20ebfca459 = 250;

	private const int x894695bab0ea4e45 = 251;

	private const int xb0254b1318c018bb = 254;

	private const int x6a398255aed66fb4 = 28;

	private const int x8b980aaf05cbab52 = 29;

	private const int xbba1a836c3d938ce = 30;

	private const int x8d5fdfc7d81443cc = 1200;

	private const int xc96d3d4c170e7fce = 10;

	private const int x4c2da589aec18ce3 = 11;

	private const int xc74060d5ed2a173e = 12;

	private const int x6fbff09ef14789b5 = 14;

	private const int x8b18006980276e6e = 15;

	private static readonly Hashtable xdedb42c1e09e4af4;

	private static readonly int[] x510e67e27ecc1ac7;

	public static x74fb8c43cb3523a2 x1f490eac106aee12(byte[] x88d77c00d1f74055)
	{
		x211ce3824f5f18f5 x211ce3824f5f18f6 = new x211ce3824f5f18f5(x88d77c00d1f74055);
		while (!x211ce3824f5f18f6.x779fe2de941a42cc)
		{
			xbecaeae1f3a39094(x211ce3824f5f18f6);
		}
		return new x74fb8c43cb3523a2(x211ce3824f5f18f6.x57bfe153dea0dabb);
	}

	public static void x8d81a984b7f0332e(x73087173962e3778 xbdfb620b7167944b, x74fb8c43cb3523a2 x273c212ea6c4689b)
	{
		foreach (int item in x6d6e5d34a128ee23(x273c212ea6c4689b))
		{
			x25a77ea43ea5e12b(xbdfb620b7167944b, item, (ArrayList)x273c212ea6c4689b.x57bfe153dea0dabb[item]);
		}
	}

	private static ArrayList x6d6e5d34a128ee23(x74fb8c43cb3523a2 x273c212ea6c4689b)
	{
		ArrayList arrayList = new ArrayList(x273c212ea6c4689b.x57bfe153dea0dabb.Keys);
		bool flag;
		do
		{
			flag = false;
			for (int i = 0; i < arrayList.Count - 1; i++)
			{
				if (!xda4699e25808ac4f((int)arrayList[i], (int)arrayList[i + 1]))
				{
					int num = (int)arrayList[i];
					arrayList[i] = arrayList[i + 1];
					arrayList[i + 1] = num;
					flag = true;
				}
			}
		}
		while (flag);
		return arrayList;
	}

	private static bool xda4699e25808ac4f(int x953c42bbfc97e5a6, int x3add5f54363a8808)
	{
		if (!xdedb42c1e09e4af4.ContainsKey(x953c42bbfc97e5a6) && !xdedb42c1e09e4af4.ContainsKey(x3add5f54363a8808))
		{
			return true;
		}
		if (!xdedb42c1e09e4af4.ContainsKey(x953c42bbfc97e5a6))
		{
			return false;
		}
		if (!xdedb42c1e09e4af4.ContainsKey(x3add5f54363a8808))
		{
			return true;
		}
		int num = (int)xdedb42c1e09e4af4[x953c42bbfc97e5a6];
		int num2 = (int)xdedb42c1e09e4af4[x3add5f54363a8808];
		return num <= num2;
	}

	private static void xbecaeae1f3a39094(x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		byte b = x0f7b23d1c393aed9.x672ed37ee25c078c();
		if (b >= 0 && b <= 21)
		{
			x1a6ba2d9ff6daa7b(b, x0f7b23d1c393aed9);
			return;
		}
		if (b >= 32 && b <= 246)
		{
			xbd551a7e804e983e(b, x0f7b23d1c393aed9);
			return;
		}
		if (b >= 247 && b <= 250)
		{
			x711d6535cc9a0328(b, x0f7b23d1c393aed9);
			return;
		}
		if (b >= 251 && b <= 254)
		{
			x75986e7eea8ccbc9(b, x0f7b23d1c393aed9);
			return;
		}
		switch (b)
		{
		case 28:
			x81fb933065516969(x0f7b23d1c393aed9);
			break;
		case 29:
			x7cd608f31cf7a1f1(x0f7b23d1c393aed9);
			break;
		case 30:
			x514b673af4bb33fb(x0f7b23d1c393aed9);
			break;
		}
	}

	private static void x25a77ea43ea5e12b(x73087173962e3778 xbdfb620b7167944b, int x8b5085d6778ff74e, ArrayList x730c9ff53cfe8b5f)
	{
		if (!xe088b040753bbe7d(x8b5085d6778ff74e))
		{
			throw new InvalidOperationException("Invalid operator.");
		}
		bool flag = x157953ff2c971d82(x8b5085d6778ff74e);
		foreach (object item in x730c9ff53cfe8b5f)
		{
			if (!flag)
			{
				xee21f30e3be3f5ad(xbdfb620b7167944b, item);
				continue;
			}
			if (item is int)
			{
				xa5e32652691cb42b(xbdfb620b7167944b, (int)item);
				continue;
			}
			throw new InvalidOperationException("Unsupported operand type.");
		}
		x696b931a57455aa1(xbdfb620b7167944b, x8b5085d6778ff74e);
	}

	private static bool xe088b040753bbe7d(int x8b5085d6778ff74e)
	{
		if (x8b5085d6778ff74e >= 0 && x8b5085d6778ff74e <= 21 && x8b5085d6778ff74e != 12)
		{
			return true;
		}
		if (x8b5085d6778ff74e >= 1200 && x8b5085d6778ff74e <= 1455)
		{
			return true;
		}
		return false;
	}

	private static bool x157953ff2c971d82(int x8b5085d6778ff74e)
	{
		int[] array = x510e67e27ecc1ac7;
		foreach (int num in array)
		{
			if (x8b5085d6778ff74e == num)
			{
				return true;
			}
		}
		return false;
	}

	private static void x1a6ba2d9ff6daa7b(byte x469ebd6f8ac26059, x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		if (x469ebd6f8ac26059 == 12)
		{
			x0f7b23d1c393aed9.x3d11dfe63c9c8329(1200 + x0f7b23d1c393aed9.x672ed37ee25c078c());
		}
		else
		{
			x0f7b23d1c393aed9.x3d11dfe63c9c8329(x469ebd6f8ac26059);
		}
	}

	private static void x696b931a57455aa1(x73087173962e3778 xbdfb620b7167944b, int x8b5085d6778ff74e)
	{
		if (x8b5085d6778ff74e >= 1200)
		{
			xbdfb620b7167944b.xc351d479ff7ee789(12);
			xbdfb620b7167944b.xc351d479ff7ee789((byte)(x8b5085d6778ff74e - 1200));
		}
		else
		{
			xbdfb620b7167944b.xc351d479ff7ee789((byte)x8b5085d6778ff74e);
		}
	}

	private static void xee21f30e3be3f5ad(x73087173962e3778 xbdfb620b7167944b, object x137ffa3012d6a67d)
	{
		if (x137ffa3012d6a67d is int)
		{
			xf2157ef3ccb9bf16(xbdfb620b7167944b, (int)x137ffa3012d6a67d);
			return;
		}
		if (x137ffa3012d6a67d is double)
		{
			x5aac1355efaa95f1(xbdfb620b7167944b, (double)x137ffa3012d6a67d);
			return;
		}
		throw new InvalidOperationException("Unsupported operand type.");
	}

	private static void xf2157ef3ccb9bf16(x73087173962e3778 xbdfb620b7167944b, int x137ffa3012d6a67d)
	{
		if (x137ffa3012d6a67d >= -107 && x137ffa3012d6a67d <= 107)
		{
			xf0e8a6ba3b564629(xbdfb620b7167944b, x137ffa3012d6a67d);
		}
		else if (x137ffa3012d6a67d >= 108 && x137ffa3012d6a67d <= 1131)
		{
			xfccb144f0fe22d4d(xbdfb620b7167944b, x137ffa3012d6a67d);
		}
		else if (x137ffa3012d6a67d >= -1131 && x137ffa3012d6a67d <= -108)
		{
			x08b289efe5009194(xbdfb620b7167944b, x137ffa3012d6a67d);
		}
		else if (x137ffa3012d6a67d >= -32768 && x137ffa3012d6a67d <= 32767)
		{
			xdf520d5650d70ffc(xbdfb620b7167944b, x137ffa3012d6a67d);
		}
		else
		{
			xa5e32652691cb42b(xbdfb620b7167944b, x137ffa3012d6a67d);
		}
	}

	private static void xbd551a7e804e983e(byte x469ebd6f8ac26059, x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		x0f7b23d1c393aed9.xa4de9ee8a5ef1b1b(xe58bc4b6a0a16e34(x469ebd6f8ac26059));
	}

	private static void xf0e8a6ba3b564629(x73087173962e3778 xbdfb620b7167944b, int x137ffa3012d6a67d)
	{
		short num = (short)(x137ffa3012d6a67d + 139);
		xbdfb620b7167944b.xc351d479ff7ee789((byte)num);
	}

	private static int xe58bc4b6a0a16e34(int x469ebd6f8ac26059)
	{
		return x469ebd6f8ac26059 - 139;
	}

	private static void x711d6535cc9a0328(byte x469ebd6f8ac26059, x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		byte x01ec8535a377ff = x0f7b23d1c393aed9.x672ed37ee25c078c();
		x0f7b23d1c393aed9.xa4de9ee8a5ef1b1b(x3b4f23beaeb8fdf8(x469ebd6f8ac26059, x01ec8535a377ff));
	}

	private static void xfccb144f0fe22d4d(x73087173962e3778 xbdfb620b7167944b, int x137ffa3012d6a67d)
	{
		short num = (short)((x137ffa3012d6a67d - 108) / 256 + 247);
		short num2 = (short)((x137ffa3012d6a67d - 108) % 256);
		xbdfb620b7167944b.xc351d479ff7ee789((byte)num);
		xbdfb620b7167944b.xc351d479ff7ee789((byte)num2);
	}

	private static int x3b4f23beaeb8fdf8(int x469ebd6f8ac26059, int x01ec8535a377ff25)
	{
		return (x469ebd6f8ac26059 - 247) * 256 + x01ec8535a377ff25 + 108;
	}

	private static void x75986e7eea8ccbc9(byte x469ebd6f8ac26059, x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		byte x01ec8535a377ff = x0f7b23d1c393aed9.x672ed37ee25c078c();
		x0f7b23d1c393aed9.xa4de9ee8a5ef1b1b(xd0f4fcfe10d96508(x469ebd6f8ac26059, x01ec8535a377ff));
	}

	private static void x08b289efe5009194(x73087173962e3778 xbdfb620b7167944b, int x137ffa3012d6a67d)
	{
		short num = (short)((-x137ffa3012d6a67d - 108) / 256 + 251);
		short num2 = (short)((-x137ffa3012d6a67d - 108) % 256);
		xbdfb620b7167944b.xc351d479ff7ee789((byte)num);
		xbdfb620b7167944b.xc351d479ff7ee789((byte)num2);
	}

	private static int xd0f4fcfe10d96508(int x469ebd6f8ac26059, int x01ec8535a377ff25)
	{
		return -(x469ebd6f8ac26059 - 251) * 256 - x01ec8535a377ff25 - 108;
	}

	private static void x81fb933065516969(x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		byte b = x0f7b23d1c393aed9.x672ed37ee25c078c();
		byte b2 = x0f7b23d1c393aed9.x672ed37ee25c078c();
		x0f7b23d1c393aed9.xa4de9ee8a5ef1b1b((b << 8) | b2);
	}

	private static void xdf520d5650d70ffc(x73087173962e3778 xbdfb620b7167944b, int x137ffa3012d6a67d)
	{
		xbdfb620b7167944b.xc351d479ff7ee789(28);
		xbdfb620b7167944b.xab5f6b7526efa5be((short)x137ffa3012d6a67d);
	}

	private static void x7cd608f31cf7a1f1(x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		byte b = x0f7b23d1c393aed9.x672ed37ee25c078c();
		byte b2 = x0f7b23d1c393aed9.x672ed37ee25c078c();
		byte b3 = x0f7b23d1c393aed9.x672ed37ee25c078c();
		byte b4 = x0f7b23d1c393aed9.x672ed37ee25c078c();
		x0f7b23d1c393aed9.xa4de9ee8a5ef1b1b((b << 24) | (b2 << 16) | (b3 << 8) | b4);
	}

	private static void xa5e32652691cb42b(x73087173962e3778 xbdfb620b7167944b, int x137ffa3012d6a67d)
	{
		xbdfb620b7167944b.xc351d479ff7ee789(29);
		xbdfb620b7167944b.x6ff7c65ed4805c27(x137ffa3012d6a67d);
	}

	private static void x514b673af4bb33fb(x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		ArrayList x34eaeea04bcc0cbb = x73a150704d1670a5(x0f7b23d1c393aed9);
		x0f7b23d1c393aed9.x9f95c541c346e6f8(x7b77f1d6789f154e(x34eaeea04bcc0cbb));
	}

	private static ArrayList x73a150704d1670a5(x211ce3824f5f18f5 x0f7b23d1c393aed9)
	{
		ArrayList arrayList = new ArrayList();
		while (true)
		{
			byte b = x0f7b23d1c393aed9.x672ed37ee25c078c();
			int num = (b & 0xF0) >> 4;
			int num2 = b & 0xF;
			if (num == 15)
			{
				break;
			}
			arrayList.Add(num);
			if (num2 == 15)
			{
				break;
			}
			arrayList.Add(num2);
		}
		return arrayList;
	}

	private static double x7b77f1d6789f154e(ArrayList x34eaeea04bcc0cbb)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (int item in x34eaeea04bcc0cbb)
		{
			switch (item)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
				stringBuilder.Append(xca004f56614e2431.xc8ba948e0d631490(item));
				break;
			case 10:
				stringBuilder.Append(".");
				break;
			case 11:
				stringBuilder.Append("E");
				break;
			case 12:
				stringBuilder.Append("E-");
				break;
			case 14:
				stringBuilder.Append("-");
				break;
			default:
				throw new ArgumentException("Invalid nibble value.");
			}
		}
		return xca004f56614e2431.xec25d08a2af152f0(stringBuilder.ToString());
	}

	private static void x5aac1355efaa95f1(x73087173962e3778 xbdfb620b7167944b, double x137ffa3012d6a67d)
	{
		string text = xca004f56614e2431.xcaaeec2e96b2cecc(x137ffa3012d6a67d);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < text.Length; i++)
		{
			switch (text[i])
			{
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				arrayList.Add(xca004f56614e2431.xa93402510be8434e(text.Substring(i, 1)));
				break;
			case '.':
				arrayList.Add(10);
				break;
			case '-':
				arrayList.Add(14);
				break;
			case 'E':
				if (text[i + 1] == '-')
				{
					arrayList.Add(12);
					i++;
				}
				else if (text[i + 1] == '+')
				{
					arrayList.Add(11);
					i++;
				}
				else
				{
					arrayList.Add(11);
				}
				break;
			}
		}
		arrayList.Add(15);
		if (arrayList.Count % 2 == 1)
		{
			arrayList.Add(15);
		}
		xbdfb620b7167944b.xc351d479ff7ee789(30);
		for (int j = 0; j < arrayList.Count / 2; j++)
		{
			int num = (int)arrayList[2 * j];
			int num2 = (int)arrayList[2 * j + 1];
			short num3 = (short)((num << 4) | num2);
			xbdfb620b7167944b.xc351d479ff7ee789((byte)num3);
		}
	}

	static x31c94dab5abeafcb()
	{
		x510e67e27ecc1ac7 = new int[7] { 15, 16, 17, 18, 19, 1236, 1237 };
		xdedb42c1e09e4af4 = new Hashtable();
		int num = 0;
		xdedb42c1e09e4af4.Add(1220, num++);
		xdedb42c1e09e4af4.Add(1230, num++);
		xdedb42c1e09e4af4.Add(0, num++);
		xdedb42c1e09e4af4.Add(1, num++);
		xdedb42c1e09e4af4.Add(1200, num++);
		xdedb42c1e09e4af4.Add(2, num++);
		xdedb42c1e09e4af4.Add(3, num++);
		xdedb42c1e09e4af4.Add(4, num++);
		xdedb42c1e09e4af4.Add(1201, num++);
		xdedb42c1e09e4af4.Add(1202, num++);
		xdedb42c1e09e4af4.Add(1203, num++);
		xdedb42c1e09e4af4.Add(1204, num++);
		xdedb42c1e09e4af4.Add(1205, num++);
		xdedb42c1e09e4af4.Add(1206, num++);
		xdedb42c1e09e4af4.Add(1207, num++);
		xdedb42c1e09e4af4.Add(13, num++);
		xdedb42c1e09e4af4.Add(5, num++);
		xdedb42c1e09e4af4.Add(1208, num++);
		xdedb42c1e09e4af4.Add(14, num++);
		xdedb42c1e09e4af4.Add(15, num++);
		xdedb42c1e09e4af4.Add(16, num++);
		xdedb42c1e09e4af4.Add(17, num++);
		xdedb42c1e09e4af4.Add(1221, num++);
		xdedb42c1e09e4af4.Add(1222, num++);
		xdedb42c1e09e4af4.Add(1223, num++);
		xdedb42c1e09e4af4.Add(1231, num++);
		xdedb42c1e09e4af4.Add(1232, num++);
		xdedb42c1e09e4af4.Add(1233, num++);
		xdedb42c1e09e4af4.Add(1234, num++);
		xdedb42c1e09e4af4.Add(1235, num++);
		xdedb42c1e09e4af4.Add(1237, num++);
		xdedb42c1e09e4af4.Add(1236, num++);
		xdedb42c1e09e4af4.Add(1238, num++);
		xdedb42c1e09e4af4.Add(18, num++);
		xdedb42c1e09e4af4.Add(6, num++);
		xdedb42c1e09e4af4.Add(7, num++);
		xdedb42c1e09e4af4.Add(8, num++);
		xdedb42c1e09e4af4.Add(9, num++);
		xdedb42c1e09e4af4.Add(1209, num++);
		xdedb42c1e09e4af4.Add(1210, num++);
		xdedb42c1e09e4af4.Add(1211, num++);
		xdedb42c1e09e4af4.Add(10, num++);
		xdedb42c1e09e4af4.Add(11, num++);
		xdedb42c1e09e4af4.Add(1212, num++);
		xdedb42c1e09e4af4.Add(1213, num++);
		xdedb42c1e09e4af4.Add(1214, num++);
		xdedb42c1e09e4af4.Add(1217, num++);
		xdedb42c1e09e4af4.Add(1218, num++);
		xdedb42c1e09e4af4.Add(1219, num++);
		xdedb42c1e09e4af4.Add(20, num++);
		xdedb42c1e09e4af4.Add(21, num++);
		xdedb42c1e09e4af4.Add(19, num);
	}
}
