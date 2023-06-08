using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal class x10da90eb9c780c82
{
	internal int xd2905906dc0619f2;

	internal PreferredWidth x9962ec7871050cbf;

	internal int x40a8cd925e306f1b;

	internal int x1e5325ab72cf7ec9;

	internal int x1fb2a875e6411ef2;

	internal ArrayList x973206e6579fce8f;

	internal bool x31487d0887f08f2b;

	private readonly x7c1e2b821e8b8220 x7ba62dd108937352;

	private readonly x5fe4b2f32948ed58[] x660741034f534cfd;

	private readonly ArrayList x00b023d6a2bf9648 = new ArrayList();

	internal int xb5024700d83d02f9 => x00b023d6a2bf9648.Count;

	internal int x6e1eb96b81362ebc => x660741034f534cfd.Length;

	internal x10da90eb9c780c82(x7c1e2b821e8b8220 tableLayout)
	{
		x7ba62dd108937352 = tableLayout;
		x9962ec7871050cbf = x7ba62dd108937352.xeb54885ba753f70e.x9962ec7871050cbf;
		xd2905906dc0619f2 = 0;
		x40a8cd925e306f1b = 0;
		int num = x78bc24b1832f704d(x7ba62dd108937352);
		int num2 = 0;
		for (x387d31b7e6ea1182 x387d31b7e6ea1183 = x7ba62dd108937352.x5d6d04c35215bc51; x387d31b7e6ea1183 != null; x387d31b7e6ea1183 = x387d31b7e6ea1183.xebb8ac1152da9a1f)
		{
			xb24f38e84324adff xb24f38e84324adff2 = new xb24f38e84324adff();
			x00b023d6a2bf9648.Add(xb24f38e84324adff2);
			int num3 = x387d31b7e6ea1183.x768f9befb545345a.x0364c07ad4dcfe0c;
			if (0 < x387d31b7e6ea1183.x768f9befb545345a.x0364c07ad4dcfe0c)
			{
				xb24f38e84324adff2.xd6b6ed77479ef68c(new xd9db44bb47d1be90(x387d31b7e6ea1183.x96ac59f61797f5b9, 0, num2, -1));
			}
			x56b4eac69b5fa65b x56b4eac69b5fa65b2 = x387d31b7e6ea1183.x96ac59f61797f5b9;
			while (x56b4eac69b5fa65b2 != null && !x56b4eac69b5fa65b2.x55b6066f30988caf)
			{
				xd9db44bb47d1be90 xd9db44bb47d1be91 = new xd9db44bb47d1be90(x56b4eac69b5fa65b2, num3, num2, 0);
				if (x7ba62dd108937352.xeb54885ba753f70e.xc61c6fcfb0c6e3c3)
				{
					xd9db44bb47d1be91.x1fb2a875e6411ef2 = Math.Max(xd9db44bb47d1be91.x1fb2a875e6411ef2, x56b4eac69b5fa65b2.x1fb2a875e6411ef2);
					xd9db44bb47d1be91.x1e5325ab72cf7ec9 = Math.Max(xd9db44bb47d1be91.x1e5325ab72cf7ec9, x56b4eac69b5fa65b2.x1e5325ab72cf7ec9);
				}
				else if (x56b4eac69b5fa65b2.xdfd0c9de0b4aa96a.x9962ec7871050cbf.x08428aa3999da322 && 0 < x56b4eac69b5fa65b2.xdfd0c9de0b4aa96a.x9962ec7871050cbf.x7680505e84ce0354)
				{
					xd9db44bb47d1be91.x1fb2a875e6411ef2 = (xd9db44bb47d1be91.x1e5325ab72cf7ec9 = x56b4eac69b5fa65b2.xdfd0c9de0b4aa96a.x9962ec7871050cbf.x7680505e84ce0354);
				}
				if (xd9db44bb47d1be91.x1e5325ab72cf7ec9 == 0)
				{
					xd9db44bb47d1be91.x1e5325ab72cf7ec9 = 1440;
				}
				xd9db44bb47d1be91.x1fb2a875e6411ef2 = Math.Max(xd9db44bb47d1be91.x1fb2a875e6411ef2, 20);
				xd9db44bb47d1be91.x1e5325ab72cf7ec9 = Math.Max(xd9db44bb47d1be91.x1e5325ab72cf7ec9, xd9db44bb47d1be91.x1fb2a875e6411ef2);
				xb24f38e84324adff2.xd6b6ed77479ef68c(xd9db44bb47d1be91);
				num3 += x56b4eac69b5fa65b2.xdfd0c9de0b4aa96a.x6e1eb96b81362ebc;
				x56b4eac69b5fa65b2 = x56b4eac69b5fa65b2.xb2e852052ab1c1be;
			}
			if (0 < x387d31b7e6ea1183.x768f9befb545345a.x851fcfc17df82b1b)
			{
				xb24f38e84324adff2.xd6b6ed77479ef68c(new xd9db44bb47d1be90(x387d31b7e6ea1183.xc1277af2cd8d654e.x2f5fd09b3d327fb0, num3, num2, 1));
			}
			num2++;
		}
		x660741034f534cfd = new x5fe4b2f32948ed58[num];
		while (0 < num--)
		{
			x660741034f534cfd[num] = new x5fe4b2f32948ed58();
		}
	}

	internal xd9db44bb47d1be90 xfeb19f1007c0b581(int x78a7603cacf2ae22, int xc0c4c459c6ccbd00)
	{
		return ((xb24f38e84324adff)x00b023d6a2bf9648[x78a7603cacf2ae22]).xfeb19f1007c0b581(xc0c4c459c6ccbd00);
	}

	internal x5fe4b2f32948ed58 xcda9277b4d19fd44(int xbeb0e74fd1e3aefb)
	{
		return x660741034f534cfd[xbeb0e74fd1e3aefb];
	}

	internal xb24f38e84324adff x347dc9bef5d90d7d(int x78a7603cacf2ae22)
	{
		return (xb24f38e84324adff)x00b023d6a2bf9648[x78a7603cacf2ae22];
	}

	internal int xe23673a90a622986(int x2cc5a5e4a819826f, int x1c17494aa5161fa9)
	{
		int val;
		if (x9962ec7871050cbf.x08428aa3999da322 && x9962ec7871050cbf.x40aae25d22abf007)
		{
			val = x9962ec7871050cbf.xdf4645c89f0e47f6;
		}
		else
		{
			int num = x4574ea26106f0edb.x5df565b312141b2b(x431837e8d8f834cd());
			val = ((!x9962ec7871050cbf.x368bd9f7b8c336b4 || !x9962ec7871050cbf.x40aae25d22abf007) ? Math.Min(num, x1c17494aa5161fa9) : ((int)((double)num * x9962ec7871050cbf.Value / 100.0)));
		}
		return Math.Max(val, x2cc5a5e4a819826f);
	}

	internal int x431837e8d8f834cd()
	{
		x1073233de8252b3e xc255c495fd9232ca = x7ba62dd108937352.x5d6d04c35215bc51.x8b8a0a04b3aeaf3a.xc255c495fd9232ca;
		int num;
		switch (xc255c495fd9232ca.x954503abc583f675)
		{
		case x954503abc583f675.x11db8fc7f469a2fc:
		{
			x86accec882b7012a x86accec882b7012a2 = (x86accec882b7012a)xc255c495fd9232ca;
			num = x86accec882b7012a2.xdc1bf80853046136;
			num -= x86accec882b7012a2.x5c392d6ad6fe7e28 + x86accec882b7012a2.xf159a68356fd5b23;
			break;
		}
		case x954503abc583f675.x4c38e800e85b21ad:
		{
			x852fe8bb5ac31098 x852fe8bb5ac31099 = (x852fe8bb5ac31098)xc255c495fd9232ca;
			xacf1bb6be5092987 xf48cd6e82340ac = x852fe8bb5ac31099.x3c1c340351d94fbd.xf48cd6e82340ac70;
			num = x852fe8bb5ac31099.xdc1bf80853046136;
			if (1 < xf48cd6e82340ac.x6e1eb96b81362ebc && !xf48cd6e82340ac.xdd217215207b7605)
			{
				for (int i = 0; i < xf48cd6e82340ac.x6e1eb96b81362ebc; i++)
				{
					num = Math.Min(num, xf48cd6e82340ac.x78427d61ba29da6a[i]);
				}
			}
			num += xb558216e35a71edf();
			break;
		}
		case x954503abc583f675.x924e4e3967c494db:
		case x954503abc583f675.x77f91d2130d08599:
			num = xc255c495fd9232ca.xdc1bf80853046136 + xb558216e35a71edf();
			break;
		case x954503abc583f675.x69d28a4aeef83a6f:
		case x954503abc583f675.xd90ac7fcbe961761:
			num = xc255c495fd9232ca.xc255c495fd9232ca.xdc1bf80853046136;
			break;
		default:
			throw new NotImplementedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ihgedjnenjefkjlfijcgkjjgdeahdihhmiohhifihimijidjfikjdhbklcikphpkogglggnldhemeglmjbcnfgjnjfaoabho", 1177896501)) + xc255c495fd9232ca.ToString());
		}
		num -= x7ba62dd108937352.xeb54885ba753f70e.xc0741c7ff92cf1aa;
		return Math.Max(0, num);
	}

	internal int xb558216e35a71edf()
	{
		return x7ba62dd108937352.x5d6d04c35215bc51.x96ac59f61797f5b9.xdfd0c9de0b4aa96a.xcad2e59522947ede + xa3a992e8cf81dabe.x084819436cb905ef(x7ba62dd108937352.x5d6d04c35215bc51.x96ac59f61797f5b9, BorderType.Left) / 2 + x7ba62dd108937352.x5d6d04c35215bc51.xc1277af2cd8d654e.x2f5fd09b3d327fb0.xdfd0c9de0b4aa96a.x41c99cca24bc80be + xa3a992e8cf81dabe.x084819436cb905ef(x7ba62dd108937352.x5d6d04c35215bc51.xc1277af2cd8d654e.x2f5fd09b3d327fb0, BorderType.Right) / 2;
	}

	internal bool xee1f4cca4b0b2b8b()
	{
		bool result = true;
		x7c1e2b821e8b8220 x7c1e2b821e8b8221 = x7ba62dd108937352;
		while (x7c1e2b821e8b8221 != null)
		{
			PreferredWidth preferredWidth = x7c1e2b821e8b8221.xeb54885ba753f70e.x9962ec7871050cbf;
			if (preferredWidth.x08428aa3999da322)
			{
				break;
			}
			x56b4eac69b5fa65b x56b4eac69b5fa65b2 = (x56b4eac69b5fa65b)x7c1e2b821e8b8221.x5c76a7629364cf4d(x5a5e07e9fa12451a.x11db8fc7f469a2fc);
			if (x56b4eac69b5fa65b2 == null || x56b4eac69b5fa65b2.xdfd0c9de0b4aa96a.x9962ec7871050cbf.x08428aa3999da322)
			{
				break;
			}
			if (preferredWidth.x368bd9f7b8c336b4)
			{
				result = false;
				break;
			}
			x7c1e2b821e8b8220 x7c1e2b821e8b8222 = (x7c1e2b821e8b8220)x56b4eac69b5fa65b2.x5c76a7629364cf4d(x5a5e07e9fa12451a.x25af49e7b49ea0bc);
			if (x56b4eac69b5fa65b2.xdfd0c9de0b4aa96a.x6e1eb96b81362ebc > 1 || x7c1e2b821e8b8222.xeb54885ba753f70e.x9962ec7871050cbf.xa72bf798a679c0aa)
			{
				result = false;
				break;
			}
			x7c1e2b821e8b8221 = x7c1e2b821e8b8222;
		}
		return result;
	}

	internal static int x78bc24b1832f704d(x7c1e2b821e8b8220 x7ba62dd108937352)
	{
		int num = 0;
		for (x387d31b7e6ea1182 x387d31b7e6ea1183 = x7ba62dd108937352.x5d6d04c35215bc51; x387d31b7e6ea1183 != null; x387d31b7e6ea1183 = x387d31b7e6ea1183.xebb8ac1152da9a1f)
		{
			int num2 = x387d31b7e6ea1183.x768f9befb545345a.x0364c07ad4dcfe0c + x387d31b7e6ea1183.x768f9befb545345a.x851fcfc17df82b1b;
			x56b4eac69b5fa65b x56b4eac69b5fa65b2 = x387d31b7e6ea1183.x96ac59f61797f5b9;
			while (x56b4eac69b5fa65b2 != null && !x56b4eac69b5fa65b2.x55b6066f30988caf)
			{
				num2 += x56b4eac69b5fa65b2.xdfd0c9de0b4aa96a.x6e1eb96b81362ebc;
				x56b4eac69b5fa65b2 = x56b4eac69b5fa65b2.xb2e852052ab1c1be;
			}
			num = Math.Max(num, num2);
		}
		return num;
	}
}
