using System;
using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x2c0c9a4fb5b11521
{
	private readonly xb1f375aa1b12d10f[] x3d26df6f8b783006 = new xb1f375aa1b12d10f[6];

	internal xb1f375aa1b12d10f xf2752069362a145a(x4e2f8bff72d83f71 x25c880b62d33ccbc, StoryType xdbbf47b5e620c262, bool x5aa7d09b258e0f23)
	{
		int num = xdd17d7cb3cbfb097(xdbbf47b5e620c262);
		xb1f375aa1b12d10f xb1f375aa1b12d10f2 = x3d26df6f8b783006[num];
		if (xb1f375aa1b12d10f2 == null && x25c880b62d33ccbc != null && x5aa7d09b258e0f23)
		{
			xb1f375aa1b12d10f2 = new xb1f375aa1b12d10f(x25c880b62d33ccbc, xdbbf47b5e620c262);
			x3d26df6f8b783006[num] = xb1f375aa1b12d10f2;
		}
		return xb1f375aa1b12d10f2;
	}

	internal static xb1f375aa1b12d10f xa2711a6fcb6054d5(xc7f90d9c7c51cede xbbe2f7d7c86e0379, bool x59c6d00e0898f6b8)
	{
		StoryType storyType = xa802d73ed2227056(xbbe2f7d7c86e0379, x59c6d00e0898f6b8);
		xb1f375aa1b12d10f xb1f375aa1b12d10f2 = x0484e9c10bfbc40a(xbbe2f7d7c86e0379.x3c1c340351d94fbd, storyType, x5aa7d09b258e0f23: true);
		if (xb1f375aa1b12d10f2 == null)
		{
			return null;
		}
		xb1f375aa1b12d10f xb1f375aa1b12d10f3 = new xb1f375aa1b12d10f(xbbe2f7d7c86e0379.x2c8c6741422a1298, storyType);
		xc99ce4f545e9c120.xc1d98b06788daae1(xb1f375aa1b12d10f2, xb1f375aa1b12d10f3);
		xb1f375aa1b12d10f3.xa65184d44a47025b = xbbe2f7d7c86e0379;
		return xb1f375aa1b12d10f3;
	}

	internal static xb1f375aa1b12d10f x0484e9c10bfbc40a(xf6689e0eed33812c x2612f62f94df47de, StoryType xdbbf47b5e620c262, bool x5aa7d09b258e0f23)
	{
		xb1f375aa1b12d10f xb1f375aa1b12d10f2 = null;
		while (x2612f62f94df47de != null && xb1f375aa1b12d10f2 == null)
		{
			if (x2612f62f94df47de.x2c0c9a4fb5b11521 != null)
			{
				xb1f375aa1b12d10f2 = x2612f62f94df47de.x2c0c9a4fb5b11521.xf2752069362a145a(null, xdbbf47b5e620c262, x5aa7d09b258e0f23);
			}
			x2612f62f94df47de = x2612f62f94df47de.x488a096134880397;
		}
		return xb1f375aa1b12d10f2;
	}

	private int xdd17d7cb3cbfb097(StoryType xdbbf47b5e620c262)
	{
		int num = (int)(xdbbf47b5e620c262 - 6);
		if (0 > num || num > x3d26df6f8b783006.Length)
		{
			throw new ArgumentOutOfRangeException("storyType");
		}
		return num;
	}

	private static StoryType xa802d73ed2227056(xc7f90d9c7c51cede xbbe2f7d7c86e0379, bool x59c6d00e0898f6b8)
	{
		StoryType result = (x59c6d00e0898f6b8 ? StoryType.PrimaryHeader : StoryType.PrimaryFooter);
		xf6689e0eed33812c x3c1c340351d94fbd = xbbe2f7d7c86e0379.x3c1c340351d94fbd;
		if (x3c1c340351d94fbd.xf48cd6e82340ac70.xa46d60033c09b60d && xbbe2f7d7c86e0379 == xbbe2f7d7c86e0379.x3c1c340351d94fbd.xb78c16d5f2d4f2f7.xe38820c59d60221a)
		{
			result = (x59c6d00e0898f6b8 ? StoryType.FirstPageHeader : StoryType.FirstPageFooter);
		}
		else if (x3c1c340351d94fbd.x874c84c476778297.xde015839cc88f18d.x1b0b470b47c0d859)
		{
			int num = x5c28fdcd27dee7d9.xb5da8902547ab3e9(xbbe2f7d7c86e0379);
			if (!x0d299f323d241756.x7e32f71c3f39b6bc(num))
			{
				result = (x59c6d00e0898f6b8 ? StoryType.EvenPagesHeader : StoryType.EvenPagesFooter);
			}
		}
		return result;
	}
}
