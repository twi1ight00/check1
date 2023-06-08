using System.Collections;
using System.IO;
using Aspose.Words.Lists;
using x452f379ec5921195;
using x6c95d9cf46ff5f25;
using xa604c4d210ae0581;
using xd2754ae26d400653;
using xf989f31a236ff98c;

namespace xdc4a6e3b10426ae2;

internal class xe6daf81eea39f8f3
{
	private const int x1fb2a875e6411ef2 = 0;

	private const int x1e5325ab72cf7ec9 = 31680;

	private xe6daf81eea39f8f3()
	{
	}

	internal static x227665e444fb500a x06b0e25aa6ad68a9(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryReader xe134235b3526fa75, ListCollection x7d45a69b707b1582)
	{
		x3fdb33c580a0bef3 x3f309b0d37dff = xf0c8411938a86cbf.x01bd3f0735eb5899.x3f309b0d37dff647;
		if (x3f309b0d37dff.x04c290dc4d04369c == 0)
		{
			return null;
		}
		xe134235b3526fa75.BaseStream.Position = x3f309b0d37dff.xe53f0e68147463d1;
		Stack stack = new Stack();
		x227665e444fb500a x227665e444fb500a = null;
		x227665e444fb500a x227665e444fb500a2 = null;
		while (xe134235b3526fa75.BaseStream.Position - x3f309b0d37dff.xe53f0e68147463d1 < x3f309b0d37dff.x04c290dc4d04369c)
		{
			xe134235b3526fa75.ReadInt32();
			switch ((x975215e84bcf4ea2)xe134235b3526fa75.ReadInt32())
			{
			case x975215e84bcf4ea2.x75bdbdb9abd6ce53:
				x227665e444fb500a = new x227665e444fb500a();
				x227665e444fb500a2 = x227665e444fb500a;
				break;
			case x975215e84bcf4ea2.x10770fa355721ba5:
			{
				if (stack.Count > 0)
				{
					x227665e444fb500a2 = new x227665e444fb500a();
					((x227665e444fb500a)stack.Peek()).xf2453c298c5de6f5.xd6b6ed77479ef68c(x227665e444fb500a2);
				}
				x227665e444fb500a2.x92c54fd3d3742544 = (xd656a4828bafb8a2)xe134235b3526fa75.ReadInt32();
				x227665e444fb500a2.xb305c2eaafa86574 = xe134235b3526fa75.ReadInt32();
				x227665e444fb500a2.x5a5e07e9fa12451a = (x9826cda6c042c8ed)xe134235b3526fa75.ReadInt32();
				xe134235b3526fa75.ReadInt32();
				x227665e444fb500a2.x5982cde1fd0610eb = xe134235b3526fa75.ReadInt32();
				x227665e444fb500a2.x5e520cbf43b1907e = xe134235b3526fa75.ReadInt32();
				x227665e444fb500a2.x7c464f3c4155e7bb = (x11d526cb3a620392)xe134235b3526fa75.ReadInt32();
				int num4 = xe134235b3526fa75.ReadInt32();
				x227665e444fb500a2.x1891c445b78b044b = (num4 & 1) != 0;
				x227665e444fb500a2.x9e0b65219bafea05 = (num4 & 2) != 0;
				xe134235b3526fa75.ReadInt32();
				break;
			}
			case x975215e84bcf4ea2.x403209b602cc2a85:
				x227665e444fb500a2.xa39af5a82860a9a3 = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
				break;
			case x975215e84bcf4ea2.x1450ddb5f7124e57:
				x227665e444fb500a2.x759aa16c2016a289 = x93b05c1ad709a695.x602d3c3fbfa56f51(xe134235b3526fa75, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
				break;
			case x975215e84bcf4ea2.x6e71d35e818462f0:
				if (((uint)xe134235b3526fa75.ReadInt32() & (true ? 1u : 0u)) != 0)
				{
					stack.Push(x227665e444fb500a2);
				}
				else
				{
					x227665e444fb500a2 = (x227665e444fb500a)stack.Pop();
				}
				break;
			case x975215e84bcf4ea2.xdca997cd58578c0d:
			{
				x227665e444fb500a.x1da3d4a0edfe0291 = xe134235b3526fa75.ReadInt32();
				x227665e444fb500a.xab068b018026a18d = x195cb055715b526e.xfa7086ee0c6b6330(xe134235b3526fa75.ReadInt32());
				int num3 = xe134235b3526fa75.ReadInt32();
				bool flag = (num3 & 1) != 0;
				bool flag2 = (num3 & 2) != 0;
				if (flag)
				{
					x227665e444fb500a.x3650f9b73dc5111b = x3650f9b73dc5111b.x4d0b9d4447ba7566;
				}
				else if (flag2)
				{
					x227665e444fb500a.x3650f9b73dc5111b = x3650f9b73dc5111b.xe74f26d8f4cfb63f;
				}
				else
				{
					x227665e444fb500a.x3650f9b73dc5111b = x3650f9b73dc5111b.xefd793a3562fa636;
				}
				break;
			}
			case x975215e84bcf4ea2.xb46f8bfbb08b3a60:
			{
				int num = xe134235b3526fa75.ReadInt32();
				for (int i = 0; i < num; i++)
				{
					int xc0c4c459c6ccbd = xe134235b3526fa75.ReadInt16();
					int num2 = xe134235b3526fa75.ReadUInt16();
					int xc657ea789af2c1f = num2 & 0xFFF;
					x178ff6dcbf808c38 x178ff6dcbf808c = x7d45a69b707b1582.x3bfa6064d69ac0da(xc0c4c459c6ccbd);
					x178ff6dcbf808c.xc657ea789af2c1f0 = xc657ea789af2c1f;
				}
				break;
			}
			}
		}
		return x227665e444fb500a;
	}

	internal static void x6210059f049f0d48(x8aeace2bf92692ab xf0c8411938a86cbf, BinaryWriter xbdfb620b7167944b, ListCollection x7d45a69b707b1582, x227665e444fb500a x5319ac6190db58c3)
	{
		if (x5319ac6190db58c3 != null || x7d45a69b707b1582.xddf1da3d36406847 != 0)
		{
			xf0c8411938a86cbf.x01bd3f0735eb5899.x3f309b0d37dff647.xe53f0e68147463d1 = (int)xbdfb620b7167944b.BaseStream.Position;
			if (x5319ac6190db58c3 != null && x5319ac6190db58c3.x8864e5b3afde4d6e)
			{
				xbac006f11f0c58d7(xbdfb620b7167944b, x5319ac6190db58c3, x12f8e3199076f578: true);
			}
			if (x7d45a69b707b1582.xddf1da3d36406847 > 0)
			{
				xffa745c44d0f7345(xbdfb620b7167944b, x7d45a69b707b1582);
			}
			xf0c8411938a86cbf.x01bd3f0735eb5899.x3f309b0d37dff647.x04c290dc4d04369c = (int)(xbdfb620b7167944b.BaseStream.Position - xf0c8411938a86cbf.x01bd3f0735eb5899.x3f309b0d37dff647.xe53f0e68147463d1);
		}
	}

	private static void xffa745c44d0f7345(BinaryWriter xbdfb620b7167944b, ListCollection x7d45a69b707b1582)
	{
		long position = xbdfb620b7167944b.BaseStream.Position;
		x6ff7c65ed4805c27(xbdfb620b7167944b, 0);
		x6ff7c65ed4805c27(xbdfb620b7167944b, 6);
		x6ff7c65ed4805c27(xbdfb620b7167944b, x7d45a69b707b1582.xddf1da3d36406847);
		for (int i = 0; i < x7d45a69b707b1582.xddf1da3d36406847; i++)
		{
			x178ff6dcbf808c38 x178ff6dcbf808c = x7d45a69b707b1582.x3bfa6064d69ac0da(i);
			xbdfb620b7167944b.Write((short)i);
			int num = x178ff6dcbf808c.xc657ea789af2c1f0;
			if (x178ff6dcbf808c.xf81d0e09758457fe)
			{
				num |= 0x1000;
			}
			xbdfb620b7167944b.Write((short)num);
		}
		x2b41fca309ac65e4(xbdfb620b7167944b, position);
	}

	private static void xbac006f11f0c58d7(BinaryWriter xbdfb620b7167944b, x227665e444fb500a x5319ac6190db58c3, bool x12f8e3199076f578)
	{
		if (x12f8e3199076f578)
		{
			x89e921a240710c1e(xbdfb620b7167944b);
		}
		xcc9d89ac508aa703(xbdfb620b7167944b, x5319ac6190db58c3);
		x80452488cef69ae3(xbdfb620b7167944b, x975215e84bcf4ea2.x1450ddb5f7124e57, x5319ac6190db58c3.x759aa16c2016a289);
		x80452488cef69ae3(xbdfb620b7167944b, x975215e84bcf4ea2.x403209b602cc2a85, x5319ac6190db58c3.xa39af5a82860a9a3);
		if (x12f8e3199076f578)
		{
			x840be70cf4602528(xbdfb620b7167944b, x5319ac6190db58c3);
		}
		if (!x5319ac6190db58c3.x8864e5b3afde4d6e)
		{
			return;
		}
		x2cbf9c11b1c7015f(xbdfb620b7167944b, x74af43987605ea22: true);
		foreach (x227665e444fb500a item in x5319ac6190db58c3.xf2453c298c5de6f5)
		{
			xbac006f11f0c58d7(xbdfb620b7167944b, item, x12f8e3199076f578: false);
		}
		x2cbf9c11b1c7015f(xbdfb620b7167944b, x74af43987605ea22: false);
	}

	private static void x6ff7c65ed4805c27(BinaryWriter xbdfb620b7167944b, int xbcea506a33cf9111)
	{
		xbdfb620b7167944b.Write(xbcea506a33cf9111);
	}

	private static void x2b41fca309ac65e4(BinaryWriter xbdfb620b7167944b, long x4b31d35ff8d347dd)
	{
		long position = xbdfb620b7167944b.BaseStream.Position;
		xbdfb620b7167944b.BaseStream.Position = x4b31d35ff8d347dd;
		x6ff7c65ed4805c27(xbdfb620b7167944b, (int)(position - x4b31d35ff8d347dd));
		xbdfb620b7167944b.BaseStream.Position = position;
	}

	private static void x89e921a240710c1e(BinaryWriter xbdfb620b7167944b)
	{
		long position = xbdfb620b7167944b.BaseStream.Position;
		x6ff7c65ed4805c27(xbdfb620b7167944b, 0);
		x6ff7c65ed4805c27(xbdfb620b7167944b, 0);
		x2b41fca309ac65e4(xbdfb620b7167944b, position);
	}

	private static void x80452488cef69ae3(BinaryWriter xbdfb620b7167944b, x975215e84bcf4ea2 x5f38526825ccfa70, string xf6987a1745781d6f)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xf6987a1745781d6f))
		{
			long position = xbdfb620b7167944b.BaseStream.Position;
			x6ff7c65ed4805c27(xbdfb620b7167944b, 0);
			x6ff7c65ed4805c27(xbdfb620b7167944b, (int)x5f38526825ccfa70);
			x93b05c1ad709a695.x4a3c44ae9b1cf5ab(xf6987a1745781d6f, int.MaxValue, xbdfb620b7167944b, x5be1cad1d00af914: true, xac1baf51b3e43d13: true);
			x2b41fca309ac65e4(xbdfb620b7167944b, position);
		}
	}

	private static void xcc9d89ac508aa703(BinaryWriter xbdfb620b7167944b, x227665e444fb500a x5319ac6190db58c3)
	{
		long position = xbdfb620b7167944b.BaseStream.Position;
		x6ff7c65ed4805c27(xbdfb620b7167944b, 0);
		x6ff7c65ed4805c27(xbdfb620b7167944b, 1);
		x6ff7c65ed4805c27(xbdfb620b7167944b, (int)x5319ac6190db58c3.x92c54fd3d3742544);
		x6ff7c65ed4805c27(xbdfb620b7167944b, x5319ac6190db58c3.xb305c2eaafa86574);
		x6ff7c65ed4805c27(xbdfb620b7167944b, (int)x5319ac6190db58c3.x5a5e07e9fa12451a);
		x6ff7c65ed4805c27(xbdfb620b7167944b, x5319ac6190db58c3.x8864e5b3afde4d6e ? 1 : 2);
		x6ff7c65ed4805c27(xbdfb620b7167944b, x5319ac6190db58c3.x5982cde1fd0610eb);
		x6ff7c65ed4805c27(xbdfb620b7167944b, x5319ac6190db58c3.x5e520cbf43b1907e);
		x6ff7c65ed4805c27(xbdfb620b7167944b, (int)x5319ac6190db58c3.x7c464f3c4155e7bb);
		int num = 0;
		num |= (x5319ac6190db58c3.x1891c445b78b044b ? 1 : 0);
		num |= (x5319ac6190db58c3.x9e0b65219bafea05 ? 2 : 0);
		x6ff7c65ed4805c27(xbdfb620b7167944b, num);
		x6ff7c65ed4805c27(xbdfb620b7167944b, 6);
		x2b41fca309ac65e4(xbdfb620b7167944b, position);
	}

	private static void x840be70cf4602528(BinaryWriter xbdfb620b7167944b, x227665e444fb500a x5319ac6190db58c3)
	{
		if (!x5319ac6190db58c3.xab068b018026a18d.x7149c962c02931b3 || x5319ac6190db58c3.x1da3d4a0edfe0291 != 0 || x5319ac6190db58c3.x3650f9b73dc5111b != x3650f9b73dc5111b.xefd793a3562fa636)
		{
			int num = (int)xbdfb620b7167944b.BaseStream.Position;
			x6ff7c65ed4805c27(xbdfb620b7167944b, 0);
			x6ff7c65ed4805c27(xbdfb620b7167944b, 5);
			x6ff7c65ed4805c27(xbdfb620b7167944b, xdc05a4269819ed55(x5319ac6190db58c3.x1da3d4a0edfe0291, 0, 31680) ? x5319ac6190db58c3.x1da3d4a0edfe0291 : 0);
			x6ff7c65ed4805c27(xbdfb620b7167944b, x195cb055715b526e.x103636c839f725d7(x5319ac6190db58c3.xab068b018026a18d));
			switch (x5319ac6190db58c3.x3650f9b73dc5111b)
			{
			case x3650f9b73dc5111b.x4d0b9d4447ba7566:
				x6ff7c65ed4805c27(xbdfb620b7167944b, 1);
				break;
			case x3650f9b73dc5111b.xe74f26d8f4cfb63f:
				x6ff7c65ed4805c27(xbdfb620b7167944b, 2);
				break;
			default:
				x6ff7c65ed4805c27(xbdfb620b7167944b, 0);
				break;
			}
			x2b41fca309ac65e4(xbdfb620b7167944b, num);
		}
	}

	private static void x2cbf9c11b1c7015f(BinaryWriter xbdfb620b7167944b, bool x74af43987605ea22)
	{
		long position = xbdfb620b7167944b.BaseStream.Position;
		x6ff7c65ed4805c27(xbdfb620b7167944b, 0);
		x6ff7c65ed4805c27(xbdfb620b7167944b, 2);
		x6ff7c65ed4805c27(xbdfb620b7167944b, x74af43987605ea22 ? 1 : 0);
		x2b41fca309ac65e4(xbdfb620b7167944b, position);
	}

	private static bool xdc05a4269819ed55(int xbcea506a33cf9111, int xd088075e67f6ea91, int xffd6352b2e5d70e3)
	{
		if (xd088075e67f6ea91 <= xbcea506a33cf9111)
		{
			return xbcea506a33cf9111 <= xffd6352b2e5d70e3;
		}
		return false;
	}
}
