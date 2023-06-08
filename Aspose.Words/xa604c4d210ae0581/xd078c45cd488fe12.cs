using System.Collections.Specialized;
using System.IO;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal class xd078c45cd488fe12
{
	private const int x6781204d0435d100 = 5;

	private readonly StringCollection x0055d03d8785e4bd = new StringCollection();

	private readonly xc37be8b55e20f825 x54a771c21ed9f640 = new xc37be8b55e20f825();

	internal xc37be8b55e20f825 x6fa6e31d93cf837a => x54a771c21ed9f640;

	internal int xd44988f225497f3a => x0055d03d8785e4bd.Count;

	internal xd078c45cd488fe12()
	{
	}

	internal xd078c45cd488fe12(x8aeace2bf92692ab fib, BinaryReader reader)
	{
		if (fib.x955a03f821588c52.xc37be8b55e20f825.x04c290dc4d04369c != 0)
		{
			x54a771c21ed9f640.x06b0e25aa6ad68a9(reader, fib.x955a03f821588c52.xc37be8b55e20f825);
		}
	}

	internal void x93b0c46ec754e6da(xb4278d25e0406614 xa3c36daac9d9cc00, string x2203195bfd781fc2)
	{
		for (int i = 0; i < x54a771c21ed9f640.x23719734cf1f138c; i++)
		{
			x60bfea98467c8fef x60bfea98467c8fef2 = (x60bfea98467c8fef)x54a771c21ed9f640.xe84e6ff66aac2a0e(i);
			x0055d03d8785e4bd.Add(x0d4d45882065c63e.xbb8e765da244dfdd(x2203195bfd781fc2, xa3c36daac9d9cc00.x72bca3f242b46d61(x60bfea98467c8fef2.xb2c71475f39bdeb3)));
		}
	}

	internal void x6210059f049f0d48(x8aeace2bf92692ab xf0c8411938a86cbf, xb4278d25e0406614 xa3c36daac9d9cc00, BinaryWriter xbdfb620b7167944b)
	{
		if (x0055d03d8785e4bd.Count != 0)
		{
			for (int i = 0; i < x54a771c21ed9f640.x23719734cf1f138c; i++)
			{
				x60bfea98467c8fef x60bfea98467c8fef2 = (x60bfea98467c8fef)x54a771c21ed9f640.xe84e6ff66aac2a0e(i);
				x60bfea98467c8fef2.xb2c71475f39bdeb3 = xa3c36daac9d9cc00.x3710c228da65de24(5, x0055d03d8785e4bd[i]);
			}
			xf0c8411938a86cbf.x955a03f821588c52.xc37be8b55e20f825.xe53f0e68147463d1 = (int)xbdfb620b7167944b.BaseStream.Position;
			x54a771c21ed9f640.x6210059f049f0d48(xbdfb620b7167944b);
			xf0c8411938a86cbf.x955a03f821588c52.xc37be8b55e20f825.x04c290dc4d04369c = (int)(xbdfb620b7167944b.BaseStream.Position - xf0c8411938a86cbf.x955a03f821588c52.xc37be8b55e20f825.xe53f0e68147463d1);
		}
	}

	internal void xd6b6ed77479ef68c(int x18d1054d82981887, SubDocument x099a571ab336faf8)
	{
		x54a771c21ed9f640.xd6b6ed77479ef68c(x18d1054d82981887, new x60bfea98467c8fef());
		x0055d03d8785e4bd.Add(x099a571ab336faf8.xa39af5a82860a9a3);
	}

	internal void x2369ec465d328eba(xd078c45cd488fe12 x50a18ad2656e7181, int x03d82212f016d5f9)
	{
		if (x50a18ad2656e7181.xd44988f225497f3a != 0)
		{
			for (int i = 0; i < x50a18ad2656e7181.xd44988f225497f3a; i++)
			{
				int num = x50a18ad2656e7181.x6fa6e31d93cf837a.xed8a0d4499d6f292(i);
				x54a771c21ed9f640.xd6b6ed77479ef68c(num + x03d82212f016d5f9, new x60bfea98467c8fef());
				x0055d03d8785e4bd.Add(x50a18ad2656e7181.x72bca3f242b46d61(i));
			}
		}
	}

	internal void x8ffe90e7fbccfccd(int x881407805cd3b591)
	{
		if (x0055d03d8785e4bd.Count != 0)
		{
			x54a771c21ed9f640.xd6b6ed77479ef68c(x881407805cd3b591);
		}
	}

	internal string x72bca3f242b46d61(int xc0c4c459c6ccbd00)
	{
		if (xc0c4c459c6ccbd00 < xd44988f225497f3a)
		{
			return x0055d03d8785e4bd[xc0c4c459c6ccbd00];
		}
		return null;
	}
}
