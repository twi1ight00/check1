using System;
using System.IO;
using System.Text;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class x5a224cf027b1ffd9
{
	private const int x05fa01b7054704f7 = 8;

	private byte x4e14c75262d1645f;

	private int xe1615cd384268b40;

	private BinaryWriter x0eda88637a678099;

	public BinaryWriter x7fdc1bfc45368624 => x0eda88637a678099;

	public x5a224cf027b1ffd9(Stream output)
	{
		x0eda88637a678099 = new BinaryWriter(output);
	}

	public void xc351d479ff7ee789(int xbcea506a33cf9111)
	{
		x0eda88637a678099.Write((byte)xbcea506a33cf9111);
	}

	public void x4c116b70372a3c6d(byte[] x5cafa8d49ea71ea1)
	{
		x0eda88637a678099.Write(x5cafa8d49ea71ea1);
	}

	public void xab5f6b7526efa5be(int xbcea506a33cf9111)
	{
		x0eda88637a678099.Write((short)xbcea506a33cf9111);
	}

	public void x6ff7c65ed4805c27(int xbcea506a33cf9111)
	{
		x0eda88637a678099.Write(xbcea506a33cf9111);
	}

	public void x38dfb33b286626fa(double xbcea506a33cf9111)
	{
		x6ff7c65ed4805c27(x4574ea26106f0edb.x091b250f00534aae(xbcea506a33cf9111));
	}

	public void x1485d1261faf8961(bool x2dd7de7c7b0ddad5, bool xde809bbd71bb692c)
	{
		xe1615cd384268b40++;
		if (x2dd7de7c7b0ddad5)
		{
			x4e14c75262d1645f |= (byte)(1 << 8 - xe1615cd384268b40);
		}
		xd934bf598c87b7a6(xde809bbd71bb692c);
	}

	public void x4402da7591062ad7(int xbcea506a33cf9111, int x961016a387451f05, bool xde809bbd71bb692c)
	{
		x1485d1261faf8961(xbcea506a33cf9111 < 0, xde809bbd71bb692c: false);
		if (x961016a387451f05 > 1)
		{
			int xbcea506a33cf9112 = (int)((xbcea506a33cf9111 < 0) ? ((uint.MaxValue + xbcea506a33cf9111 + 1) & (4294967295L >> 32 - x961016a387451f05 + 1)) : Math.Abs(xbcea506a33cf9111));
			xbd9d4226f381e56d(xbcea506a33cf9112, x961016a387451f05 - 1, xde809bbd71bb692c);
		}
	}

	public void xbd9d4226f381e56d(int xbcea506a33cf9111, int x961016a387451f05, bool xde809bbd71bb692c)
	{
		int num = x961016a387451f05 / 8 + ((x961016a387451f05 % 8 > 0) ? 1 : 0);
		int x961016a387451f6 = 8 + x961016a387451f05 - num * 8;
		byte[] array = new byte[4];
		x0d299f323d241756.x3ae29f473f29ef2a(xbcea506a33cf9111, array, 0);
		int num2 = num - 1;
		for (int num3 = num2; num3 >= 0; num3--)
		{
			if (num3 == num2)
			{
				xc351d479ff7ee789(array[num3], x961016a387451f6, xde809bbd71bb692c: false);
			}
			else
			{
				xc351d479ff7ee789(array[num3], 8, xde809bbd71bb692c: false);
			}
		}
		xd934bf598c87b7a6(xde809bbd71bb692c);
	}

	public void xc11a255f6c1d250b(double xbcea506a33cf9111, int x961016a387451f05, bool xde809bbd71bb692c)
	{
		if (x961016a387451f05 < 17)
		{
			throw new ArgumentException("length cannot be less than 18");
		}
		bool flag = xbcea506a33cf9111 < 0.0;
		if (flag)
		{
			xbcea506a33cf9111 = 2147483647.0 + xbcea506a33cf9111 + 1.0;
		}
		int num = (int)xbcea506a33cf9111;
		double num2 = xbcea506a33cf9111 - (double)num;
		int xbcea506a33cf9112 = (int)(num2 * 65536.0);
		if (flag)
		{
			num -= int.MaxValue;
		}
		int x961016a387451f6 = x961016a387451f05 - 16;
		x4402da7591062ad7(num, x961016a387451f6, xde809bbd71bb692c: false);
		xbd9d4226f381e56d(xbcea506a33cf9112, 16, xde809bbd71bb692c: false);
		xd934bf598c87b7a6(xde809bbd71bb692c);
	}

	private void xc351d479ff7ee789(byte xbcea506a33cf9111, int x961016a387451f05, bool xde809bbd71bb692c)
	{
		while (x961016a387451f05 > 0)
		{
			x4e14c75262d1645f |= (byte)(xbcea506a33cf9111 << 8 - x961016a387451f05 >> xe1615cd384268b40);
			int num = xe1615cd384268b40;
			xe1615cd384268b40 += ((x961016a387451f05 < 8 - xe1615cd384268b40) ? x961016a387451f05 : (8 - xe1615cd384268b40));
			x961016a387451f05 -= xe1615cd384268b40 - num;
			xd934bf598c87b7a6(xde809bbd71bb692c: false);
		}
		xd934bf598c87b7a6(xde809bbd71bb692c);
	}

	public void xbb7550bbb62a218c()
	{
		if (xe1615cd384268b40 != 0)
		{
			if (xe1615cd384268b40 != 8)
			{
				xbd9d4226f381e56d(0, 8 - xe1615cd384268b40 - 1, xde809bbd71bb692c: false);
			}
			x0eda88637a678099.Write(x4e14c75262d1645f);
			x4e14c75262d1645f = 0;
			xe1615cd384268b40 = 0;
		}
	}

	private void xd934bf598c87b7a6(bool xde809bbd71bb692c)
	{
		if ((xde809bbd71bb692c && xe1615cd384268b40 != 0) || xe1615cd384268b40 == 8)
		{
			xbb7550bbb62a218c();
		}
	}

	public void xf2c2dbac0bb24ba0(string xbcea506a33cf9111)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(xbcea506a33cf9111);
		x0eda88637a678099.Write(bytes);
		x0eda88637a678099.Write((byte)0);
	}

	public void x374f83392c7b16a3(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		x0eda88637a678099.Write((byte)x6c50a99faab7d741.xc613adc4330033f3);
		x0eda88637a678099.Write((byte)x6c50a99faab7d741.x26463655896fd90a);
		x0eda88637a678099.Write((byte)x6c50a99faab7d741.x8e8f6cc6a0756b05);
	}

	public void x556a54698802f31f(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		x374f83392c7b16a3(x6c50a99faab7d741);
		x0eda88637a678099.Write((byte)x6c50a99faab7d741.xda71bf6f7c07c3bc);
	}

	public void x22842f72d2477779(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		x0eda88637a678099.Write((byte)x6c50a99faab7d741.xda71bf6f7c07c3bc);
		x374f83392c7b16a3(x6c50a99faab7d741);
	}

	public void xe62552de84356436(int xf0de582abde20d64, int xfa74463296fa6eb5, int xdcbb3b0c6ecb1f44, int x2f5accef9c426e67)
	{
		int num = xa639cb4b0a05e97c(new int[4] { xf0de582abde20d64, xfa74463296fa6eb5, xdcbb3b0c6ecb1f44, x2f5accef9c426e67 });
		xbd9d4226f381e56d(num, 5, xde809bbd71bb692c: false);
		x4402da7591062ad7(xf0de582abde20d64, num, xde809bbd71bb692c: false);
		x4402da7591062ad7(xfa74463296fa6eb5, num, xde809bbd71bb692c: false);
		x4402da7591062ad7(xdcbb3b0c6ecb1f44, num, xde809bbd71bb692c: false);
		x4402da7591062ad7(x2f5accef9c426e67, num, xde809bbd71bb692c: true);
	}

	public void x215d2a6f35e16d24(x54366fa5f75a02f7 xbdd44f2df0f1b707)
	{
		bool flag = xbdd44f2df0f1b707.xb4f54e8f080ddae5 != 1f || xbdd44f2df0f1b707.xcd7062a84a8f3162 != 1f;
		bool flag2 = xbdd44f2df0f1b707.xdde8182ef4f9942b != 0f || xbdd44f2df0f1b707.xa71255917a9143ca != 0f;
		x1485d1261faf8961(flag, xde809bbd71bb692c: false);
		if (flag)
		{
			xf1edcfeb42bb47aa(xbdd44f2df0f1b707.xb4f54e8f080ddae5, xbdd44f2df0f1b707.xcd7062a84a8f3162);
		}
		x1485d1261faf8961(flag2, xde809bbd71bb692c: false);
		if (flag2)
		{
			xf1edcfeb42bb47aa(xbdd44f2df0f1b707.xdde8182ef4f9942b, xbdd44f2df0f1b707.xa71255917a9143ca);
		}
		int num = x15e971129fd80714.x43fcc3f62534530b(xbdd44f2df0f1b707.x35fa2f38e277fdee);
		int num2 = x15e971129fd80714.x43fcc3f62534530b(xbdd44f2df0f1b707.x93f6f49bd53e2628);
		int num3 = xa639cb4b0a05e97c(new int[2] { num, num2 });
		xbd9d4226f381e56d(num3, 5, xde809bbd71bb692c: false);
		x4402da7591062ad7(num, num3, xde809bbd71bb692c: false);
		x4402da7591062ad7(num2, num3, xde809bbd71bb692c: true);
	}

	private void xf1edcfeb42bb47aa(float xb4093b8dabb31aba, float xf51494d9810b9972)
	{
		xb4093b8dabb31aba = ((xb4093b8dabb31aba < 0f) ? (xb4093b8dabb31aba - 1f) : xb4093b8dabb31aba);
		xf51494d9810b9972 = ((xf51494d9810b9972 < 0f) ? (xf51494d9810b9972 - 1f) : xf51494d9810b9972);
		int num = (int)xb4093b8dabb31aba;
		int num2 = (int)xf51494d9810b9972;
		int num3 = xa639cb4b0a05e97c(new int[2] { num, num2 }) + 16;
		xbd9d4226f381e56d(num3, 5, xde809bbd71bb692c: false);
		xc11a255f6c1d250b(xb4093b8dabb31aba, num3, xde809bbd71bb692c: false);
		xc11a255f6c1d250b(xf51494d9810b9972, num3, xde809bbd71bb692c: false);
	}

	public void x4eadf767e5f91a38(xf066f1f57515a14c x63d966043264a891, int xb3bea56f1f758203)
	{
		int num = 0;
		num |= (int)x63d966043264a891 << 6;
		num |= 0x3F;
		xab5f6b7526efa5be((short)num);
		x6ff7c65ed4805c27(xb3bea56f1f758203);
	}

	public static int xa639cb4b0a05e97c(int[] x0788cd5a9865fc16)
	{
		uint[] array = new uint[x0788cd5a9865fc16.Length];
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			array[i] = (uint)Math.Abs(x0788cd5a9865fc16[i]);
		}
		return xa639cb4b0a05e97c(array) + 1;
	}

	public static int xa639cb4b0a05e97c(uint[] x0788cd5a9865fc16)
	{
		uint num = x0788cd5a9865fc16[0];
		for (int i = 0; i < x0788cd5a9865fc16.Length; i++)
		{
			num = Math.Max(num, x0788cd5a9865fc16[i]);
		}
		return ((num != 0) ? ((int)Math.Log(num, 2.0)) : 0) + 1;
	}
}
