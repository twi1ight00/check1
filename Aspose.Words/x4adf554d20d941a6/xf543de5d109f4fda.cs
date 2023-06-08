using Aspose;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class xf543de5d109f4fda : x56410a8dd70087c5
{
	private string xed4a7b1500064e12 = string.Empty;

	private int x994a87ed734ca811 = int.MinValue;

	private x4a1a6d8b0aafa0fe x946dfed0f9c4a02e;

	internal override int x5566e2d2acbd1fbe => 9217;

	internal override int x1be93eed8950d961 => xed4a7b1500064e12.Length;

	internal override string xf9ad6fb78355fe13
	{
		get
		{
			if (base.x705ed5f9769744e5 == null || base.x705ed5f9769744e5.xa6417f0b87702333 == xa79d032ee44aba11.x4d0b9d4447ba7566)
			{
				return xed4a7b1500064e12;
			}
			return xed4a7b1500064e12.ToUpper();
		}
	}

	[JavaThrows(false)]
	internal override x4a1a6d8b0aafa0fe x4a1a6d8b0aafa0fe
	{
		get
		{
			if (x946dfed0f9c4a02e == x4a1a6d8b0aafa0fe.x4d0b9d4447ba7566)
			{
				x946dfed0f9c4a02e = x34a37b5a89c466fd.x517e646bc90695b3(xf9ad6fb78355fe13[0]);
			}
			return x946dfed0f9c4a02e;
		}
	}

	internal override int xdc1bf80853046136 => base.xdc1bf80853046136 + x06a601a353e11e7b;

	internal int x06a601a353e11e7b
	{
		get
		{
			if (x994a87ed734ca811 == int.MinValue)
			{
				x994a87ed734ca811 = x3bdb684b3034cecb();
			}
			return x994a87ed734ca811;
		}
	}

	internal xf543de5d109f4fda(string spanText)
	{
		xed4a7b1500064e12 = spanText;
	}

	internal override x56410a8dd70087c5 x3df13c9311a0ba9b(int xa5e2f199f263bb67, xf3f447691ab38eee x250b730873d21d7e)
	{
		xf543de5d109f4fda xf543de5d109f4fda2 = new xf543de5d109f4fda(xf9ad6fb78355fe13.Substring(0, xa5e2f199f263bb67));
		xf543de5d109f4fda2.x626efc37c410c502 = base.x626efc37c410c502;
		xed4a7b1500064e12 = xed4a7b1500064e12.Substring(xa5e2f199f263bb67, x1be93eed8950d961 - xa5e2f199f263bb67);
		x177e1a50bb5d875e(xf543de5d109f4fda2, x250b730873d21d7e);
		return xf543de5d109f4fda2;
	}

	internal override bool xd5da23b762ce52a2()
	{
		if (!x6e4910c886fbecbd(xfc6971c7d8314663.xf9ad6fb78355fe13))
		{
			return false;
		}
		if (base.x61712f0b4f5455af is xf543de5d109f4fda)
		{
			x994a87ed734ca811 = ((xf543de5d109f4fda)base.x61712f0b4f5455af).x06a601a353e11e7b;
		}
		xed4a7b1500064e12 += base.x61712f0b4f5455af.xf9ad6fb78355fe13;
		xb84f3af21cca2d16();
		return true;
	}

	internal override int xc7c6550a888abaf3(int xc0c4c459c6ccbd00)
	{
		int num = base.x705ed5f9769744e5.x7537b54a407680bd(base.x705ed5f9769744e5.xc2d4efc42998d87b.xbd8bafb15a2ab581(xf9ad6fb78355fe13[xc0c4c459c6ccbd00]), 1);
		return num + xa89bfdfab6890022(xc0c4c459c6ccbd00);
	}

	internal override int x795e09a07e435cf4(int xc0c4c459c6ccbd00)
	{
		int num = 0;
		while (0 <= --xc0c4c459c6ccbd00)
		{
			num += xc7c6550a888abaf3(xc0c4c459c6ccbd00);
		}
		return num;
	}

	private int x3bdb684b3034cecb()
	{
		if (base.x5a7799e1836857e3 == null)
		{
			return 0;
		}
		x56410a8dd70087c5 x56410a8dd70087c6 = base.xbd2e6df53b2331ee;
		if (!(x56410a8dd70087c6 is xf543de5d109f4fda))
		{
			return 0;
		}
		if (x4a1a6d8b0aafa0fe == x4a1a6d8b0aafa0fe.xb70c4e1b6bf793bc && x56410a8dd70087c6.x4a1a6d8b0aafa0fe == x4a1a6d8b0aafa0fe.xb70c4e1b6bf793bc)
		{
			return 0;
		}
		if (x4c9611eb45221239.x040f590ccd593b63(xf9ad6fb78355fe13[xf9ad6fb78355fe13.Length - 1], x56410a8dd70087c6.xf9ad6fb78355fe13[0], base.x406d8cd2af514771.xa79651e2f1a1416e.xfa3f9506eeba503d, base.x406d8cd2af514771.xa79651e2f1a1416e.x4ffde28f0399ee1b))
		{
			return x4574ea26106f0edb.x8d50b8a62ba1cd84(base.x705ed5f9769744e5.xc2d4efc42998d87b.x53531537bb3331e6) / 4;
		}
		return 0;
	}

	internal override x56410a8dd70087c5 xa9d7e8f6fbdcbcfc(x56410a8dd70087c5 x7d95d971d8923f4c)
	{
		if (x7d95d971d8923f4c == null)
		{
			x7d95d971d8923f4c = new xf543de5d109f4fda(xf9ad6fb78355fe13);
		}
		x7d95d971d8923f4c.x626efc37c410c502 = base.x626efc37c410c502;
		return base.xa9d7e8f6fbdcbcfc(x7d95d971d8923f4c);
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		base.x7012609bcdb39574(x672ff13faf031f3d);
		x672ff13faf031f3d.x5e3c9e6ae8d36dd1(this);
	}
}
