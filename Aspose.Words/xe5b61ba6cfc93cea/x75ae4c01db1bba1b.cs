using x8b1f7613579e78d0;
using x9e34b6f7e9185197;

namespace xe5b61ba6cfc93cea;

internal class x75ae4c01db1bba1b : x3f3baa9ffdb01f3b
{
	private const int x2c4fcf15ae4e3766 = 1001;

	private const int x9fad24673216f2b4 = 1;

	private const int x215900ddcedf605d = 999;

	private int x61d7ca9f328c8750;

	public int x1aeff1183939b437
	{
		get
		{
			return x61d7ca9f328c8750;
		}
		set
		{
			x61d7ca9f328c8750 = value;
		}
	}

	public x48d7478d49393961 x6be3a2f836be35c5(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		x48d7478d49393961 x48d7478d = x11a25734aaf3e08d(xf1125c563ec28c45);
		x48d7478d.xbd7d8a7a0df4684a(base.x9b41425268471380);
		return x48d7478d;
	}

	private x48d7478d49393961 x11a25734aaf3e08d(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		x48d7478d49393961 x48d7478d = null;
		if (1 <= x1aeff1183939b437 && x1aeff1183939b437 <= 999)
		{
			x48d7478d = xd1f14cf530c25758(xf1125c563ec28c45.x2898a4fa3477fa50);
		}
		else if (x1aeff1183939b437 >= 1001)
		{
			x48d7478d = xf228dd422e1b3ad6(xf1125c563ec28c45.x2898a4fa3477fa50);
		}
		if (x48d7478d == null)
		{
			x48d7478d = new xcffce73ccb792506();
		}
		return x48d7478d;
	}

	private x48d7478d49393961 xf228dd422e1b3ad6(x6ecdfaec63740001 xaeae22d502c36c76)
	{
		if (xaeae22d502c36c76 == null)
		{
			return null;
		}
		int xc0c4c459c6ccbd = x1aeff1183939b437 - 1001;
		return xaeae22d502c36c76.xc9e90b46232365f3(xc0c4c459c6ccbd);
	}

	private x48d7478d49393961 xd1f14cf530c25758(x6ecdfaec63740001 xaeae22d502c36c76)
	{
		if (xaeae22d502c36c76 == null)
		{
			return null;
		}
		int xc0c4c459c6ccbd = x1aeff1183939b437 - 1;
		return xaeae22d502c36c76.x0cf64e0fb1cb423b(xc0c4c459c6ccbd);
	}
}
