using System;
using Aspose.Words;
using x28925c9b27b37a46;

namespace x4adf554d20d941a6;

internal class xc1231aad908a60dd
{
	public readonly int xc23e48392ede9acb;

	public readonly TabAlignment x9ba359ff37a3a63b;

	public readonly TabLeader x902d63c74e3c13c4;

	public readonly bool xd3798e6f6f855196;

	internal static xc1231aad908a60dd x38758cbbee49e4cb(xf6937c72cebe4ad1 x311e7a92306d7199, x56410a8dd70087c5 x5906905c888d3d98, int x6475f0bcaa202a8f)
	{
		int x08c3e4e0729e675a = x5906905c888d3d98.x08c3e4e0729e675a;
		int num = x6475f0bcaa202a8f + x08c3e4e0729e675a;
		x41ccdd7753312e4f xa79651e2f1a1416e = x311e7a92306d7199.x406d8cd2af514771.xa79651e2f1a1416e;
		int num2 = x747da236bb42cee4(xa79651e2f1a1416e, num);
		int x4cba4ba1e17f1c = x5d30045af3da9a92.x7e6d0ee377757a83(x311e7a92306d7199.x332a8eedb847940d);
		int num3 = xebe2dd4b308b1122(x4cba4ba1e17f1c, num);
		int num4 = ((num2 < 0) ? (-1) : (xa79651e2f1a1416e.xcda2d9a027b80cd0[num2] - num));
		if (x311e7a92306d7199.x708cb8686d32e467 && xa79651e2f1a1416e.xc7d7e186f0ace1e0 < 0)
		{
			int num5 = x08c3e4e0729e675a + xa79651e2f1a1416e.xc0741c7ff92cf1aa + -xa79651e2f1a1416e.xc7d7e186f0ace1e0 - num;
			if (num5 > 0)
			{
				bool flag = xa79651e2f1a1416e.x2e7a2ea5da15ce85 && x311e7a92306d7199.x2c8c6741422a1298.x80f061859cd048ae.xde015839cc88f18d.x14dac37d0479fbd0;
				if ((flag && num2 < 0 && num5 < num3) || (!flag && (num2 < 0 || num5 < num4)))
				{
					return new xc1231aad908a60dd(num5, TabAlignment.Left, TabLeader.None, custom: false);
				}
			}
		}
		if (num2 >= 0)
		{
			return new xc1231aad908a60dd(xa79651e2f1a1416e.xcda2d9a027b80cd0[num2] - x6475f0bcaa202a8f, (xfc6971c7d8314663.xe9605a4bea014f21 != x5906905c888d3d98.xfc6971c7d8314663) ? xa79651e2f1a1416e.xb367d01ee0a9434c[num2] : TabAlignment.Left, xa79651e2f1a1416e.x3f2d62428d975f86[num2], custom: true);
		}
		return new xc1231aad908a60dd(x08c3e4e0729e675a + num3, TabAlignment.Left, TabLeader.None, custom: false);
	}

	internal static xc1231aad908a60dd x859bba88f7c4aefd(xf6937c72cebe4ad1 x311e7a92306d7199, x55d93e4cdc939ebf xf476cf5d47b0cb4c, int x6475f0bcaa202a8f)
	{
		int num;
		int num2;
		switch (xf476cf5d47b0cb4c.x9ba359ff37a3a63b)
		{
		case TabAlignment.Left:
			num = x311e7a92306d7199.x8df91a2f90079e88;
			num2 = 0;
			break;
		case TabAlignment.Center:
			if (xf476cf5d47b0cb4c.x7073c129de8d5e65 == x932d11b236987c0e.x941a43d4a5637fd0)
			{
				num = (x311e7a92306d7199.xc255c495fd9232ca.xdc1bf80853046136 + x311e7a92306d7199.x8df91a2f90079e88) / 2;
				x41ccdd7753312e4f xa79651e2f1a1416e = x311e7a92306d7199.x406d8cd2af514771.xa79651e2f1a1416e;
				if (x311e7a92306d7199.x708cb8686d32e467 && xa79651e2f1a1416e.xc7d7e186f0ace1e0 > 0)
				{
					num -= xa79651e2f1a1416e.xc7d7e186f0ace1e0 / 2;
				}
			}
			else
			{
				num = x311e7a92306d7199.xc255c495fd9232ca.xdc1bf80853046136 / 2;
			}
			num2 = xf476cf5d47b0cb4c.x08c3e4e0729e675a;
			break;
		case TabAlignment.Right:
			num = x311e7a92306d7199.x419ba17a5322627b;
			num2 = xf476cf5d47b0cb4c.x08c3e4e0729e675a + xf476cf5d47b0cb4c.x18a5b26861559704;
			break;
		default:
			throw new InvalidOperationException("Unexpected alignment value.");
		}
		int delta = ((num >= x6475f0bcaa202a8f + num2) ? (num - x6475f0bcaa202a8f) : (x311e7a92306d7199.x419ba17a5322627b - x6475f0bcaa202a8f + 1));
		return new xc1231aad908a60dd(delta, xf476cf5d47b0cb4c.x9ba359ff37a3a63b, xf476cf5d47b0cb4c.x902d63c74e3c13c4, custom: true);
	}

	private xc1231aad908a60dd(int delta, TabAlignment alignment, TabLeader leader, bool custom)
	{
		xc23e48392ede9acb = delta;
		x9ba359ff37a3a63b = alignment;
		x902d63c74e3c13c4 = leader;
		xd3798e6f6f855196 = custom;
	}

	private static int xebe2dd4b308b1122(int x4cba4ba1e17f1c21, int x08db3aeabb253cb1)
	{
		if (x4cba4ba1e17f1c21 <= 0)
		{
			return 0;
		}
		int num = (int)Math.Ceiling((double)x08db3aeabb253cb1 / (double)x4cba4ba1e17f1c21) * x4cba4ba1e17f1c21 - x08db3aeabb253cb1;
		if (num == 0)
		{
			num = x4cba4ba1e17f1c21;
		}
		return num;
	}

	private static int x747da236bb42cee4(x41ccdd7753312e4f x94aec03cf2ae750b, int x08db3aeabb253cb1)
	{
		for (int i = 0; i < x94aec03cf2ae750b.xf395c3c043d1a6cf; i++)
		{
			if (x94aec03cf2ae750b.xcda2d9a027b80cd0[i] > x08db3aeabb253cb1 && x94aec03cf2ae750b.xb367d01ee0a9434c[i] != TabAlignment.Bar)
			{
				return i;
			}
			if (x94aec03cf2ae750b.xcda2d9a027b80cd0[i] >= x08db3aeabb253cb1 && x94aec03cf2ae750b.xb367d01ee0a9434c[i] == TabAlignment.List)
			{
				return i;
			}
		}
		return -1;
	}
}
