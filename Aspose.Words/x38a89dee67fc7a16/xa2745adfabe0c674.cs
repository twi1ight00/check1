using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x38a89dee67fc7a16;

internal class xa2745adfabe0c674
{
	private readonly int x933fbdb4e4f6c448;

	private readonly int x51556d800a83de54;

	private readonly int xd74c65b8d28b1740;

	private readonly int x8918dc7c534575e5;

	private double x2d1c271174d2f5d5;

	private double xc01fd179bbea222c;

	private bool x5cf5da33ffcd8d6b;

	public int x72d92bd1aff02e37 => x933fbdb4e4f6c448;

	public int xe360b1885d8d4a41 => x51556d800a83de54;

	public int x419ba17a5322627b => x72d92bd1aff02e37 + xdc1bf80853046136;

	public int x9bcb07e204e30218 => xe360b1885d8d4a41 + xb0f146032f47c24e;

	public int xdc1bf80853046136 => xd74c65b8d28b1740;

	public int xb0f146032f47c24e => x8918dc7c534575e5;

	public double xf2b3620f7bfc9ed5 => x2d1c271174d2f5d5;

	public double x5c6fc5693c6898cd => xc01fd179bbea222c;

	public bool xc16040ff4dc683ab => x5cf5da33ffcd8d6b;

	public double xd0c3f0768d960161 => x4574ea26106f0edb.xad2dd08366e0faf5(xd74c65b8d28b1740, x2d1c271174d2f5d5);

	public double xeb129b9a992183c5 => x4574ea26106f0edb.xad2dd08366e0faf5(x8918dc7c534575e5, xc01fd179bbea222c);

	public int xf0dac309e0310811 => x4574ea26106f0edb.x3aa08882c9feaf96(xd0c3f0768d960161);

	public int x46df0eb1a743eced => x4574ea26106f0edb.x3aa08882c9feaf96(xeb129b9a992183c5);

	public int x2293d3e399e86e50 => x4574ea26106f0edb.xad0a638147bf044e(xdc1bf80853046136, xf2b3620f7bfc9ed5);

	public int x2a8c8b799b415917 => x4574ea26106f0edb.xad0a638147bf044e(xb0f146032f47c24e, x5c6fc5693c6898cd);

	public Size x437e3b626c0fdd43 => new Size(xd74c65b8d28b1740, x8918dc7c534575e5);

	public SizeF xc6da7d30336037ec => new SizeF(xd74c65b8d28b1740, x8918dc7c534575e5);

	public static xa2745adfabe0c674 xb4f2f2cd9736c886()
	{
		return new xa2745adfabe0c674(0, 0, 0, 0, 0.0, 0.0);
	}

	public static xa2745adfabe0c674 xe6a756f8b9f6fe18(int x9b0739496f8b5475, int x4d5aabc7a55b12ba, double x6088974b0138bee7, double x722d7c3d74d98c33)
	{
		return new xa2745adfabe0c674(0, 0, x9b0739496f8b5475, x4d5aabc7a55b12ba, x6088974b0138bee7, x722d7c3d74d98c33);
	}

	public static xa2745adfabe0c674 xe6a756f8b9f6fe18(int xa447fc54e41dfe06, int xc941868c59399d3e, int xfc2074a859a5db8c, int xaf9a0436a70689de, double x6088974b0138bee7, double x722d7c3d74d98c33)
	{
		int width = xfc2074a859a5db8c - xa447fc54e41dfe06;
		int height = xaf9a0436a70689de - xc941868c59399d3e;
		return new xa2745adfabe0c674(xa447fc54e41dfe06, xc941868c59399d3e, width, height, x6088974b0138bee7, x722d7c3d74d98c33);
	}

	public static xa2745adfabe0c674 xa0a47601432e91a8(int xa447fc54e41dfe06, int xc941868c59399d3e, int xfc2074a859a5db8c, int xaf9a0436a70689de, int x1c991b839ad1125f, int xf578678e53bd422f)
	{
		int num = xfc2074a859a5db8c - xa447fc54e41dfe06;
		int num2 = xaf9a0436a70689de - xc941868c59399d3e;
		double hRes = ((x1c991b839ad1125f != 0) ? ((double)num / x4574ea26106f0edb.x7c938cd3c8eb5262(x1c991b839ad1125f)) : 0.0);
		double vRes = ((xf578678e53bd422f != 0) ? ((double)num2 / x4574ea26106f0edb.x7c938cd3c8eb5262(xf578678e53bd422f)) : 0.0);
		return new xa2745adfabe0c674(xa447fc54e41dfe06, xc941868c59399d3e, num, num2, hRes, vRes);
	}

	private xa2745adfabe0c674(int left, int top, int width, int height, double hRes, double vRes)
	{
		x933fbdb4e4f6c448 = left;
		x51556d800a83de54 = top;
		xd74c65b8d28b1740 = width;
		x8918dc7c534575e5 = height;
		x2d1c271174d2f5d5 = hRes;
		xc01fd179bbea222c = vRes;
		if (hRes == 0.0 || vRes == 0.0)
		{
			x5cf5da33ffcd8d6b = true;
			x2d1c271174d2f5d5 = 96.0;
			xc01fd179bbea222c = 96.0;
		}
	}
}
