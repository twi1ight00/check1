using Aspose.Words;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using xd2754ae26d400653;

namespace x2182451cabb5c30d;

internal class x9b74bc21072e1eb4 : x77fb5b1d5c73757b
{
	private List x870980ad82373217;

	private ListLevel x1fa4169cbf2b08e9;

	private bool x60a96ec1df0f970c;

	private x1a78664fa10a3755 x1a78664fa10a3755
	{
		get
		{
			if (x28fcdc775a1d069c.xa3a0cc3e91617aca.xcfc42ef22e03d2ce == null)
			{
				return base.xffb3238a8fd59aa7.x1a78664fa10a3755;
			}
			return x28fcdc775a1d069c.xa3a0cc3e91617aca.xcfc42ef22e03d2ce.x1a78664fa10a3755;
		}
	}

	internal x9b74bc21072e1eb4(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x9256a6c338f6cb6c)
		{
			x60a96ec1df0f970c = false;
			x1fa4169cbf2b08e9 = new ListLevel(base.x2c8c6741422a1298, 0);
			x1fa4169cbf2b08e9.xf9be1d0b8b44c7e8 = true;
			x1fa4169cbf2b08e9.xeedad81aaed42a76.x51cf23ce6e71b84c = (string)xeedad81aaed42a76.xb1e619009047280c(230);
			x1fa4169cbf2b08e9.xeedad81aaed42a76.xd08cbc518cf39317 = (string)xeedad81aaed42a76.xb1e619009047280c(240);
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x9256a6c338f6cb6c)
		{
			switch (x153c99a852375422.x1dafd189c5465293())
			{
			case "\\pnlvl":
			{
				int num = x153c99a852375422.xd6f9e3c5ae6509d7() - 1;
				x1a78664fa10a3755.xae20093bed1e48a8(1110, num);
				x1fa4169cbf2b08e9 = x870980ad82373217.ListLevels[num];
				x1fa4169cbf2b08e9.xf9be1d0b8b44c7e8 = true;
				break;
			}
			case "\\pnlvlcont":
				x60a96ec1df0f970c = true;
				break;
			case "\\pnlvlblt":
				x1fa4169cbf2b08e9.NumberStyle = NumberStyle.Bullet;
				break;
			case "\\pndec":
				x1fa4169cbf2b08e9.NumberStyle = NumberStyle.Arabic;
				x1fa4169cbf2b08e9.NumberFormat = "\0";
				break;
			case "\\pnstart":
				x1fa4169cbf2b08e9.xd62f9a1bfab2aceb(x153c99a852375422.xd6f9e3c5ae6509d7());
				break;
			case "\\pnf":
				x1fa4169cbf2b08e9.xeedad81aaed42a76.x51cf23ce6e71b84c = x28fcdc775a1d069c.x241e429ca27700bc(x153c99a852375422.xd6f9e3c5ae6509d7());
				x1fa4169cbf2b08e9.xeedad81aaed42a76.xd08cbc518cf39317 = x28fcdc775a1d069c.x241e429ca27700bc(x153c99a852375422.xd6f9e3c5ae6509d7());
				break;
			case "\\pncf":
				x1fa4169cbf2b08e9.xeedad81aaed42a76.xae20093bed1e48a8(160, x28fcdc775a1d069c.x88bf28725f671e38.get_xe6d4b1b411ed94b5(x153c99a852375422.xd6f9e3c5ae6509d7()));
				break;
			case "\\pnindent":
				x1fa4169cbf2b08e9.x5cf63f659ff5ee9f = x153c99a852375422.xd6f9e3c5ae6509d7();
				break;
			case "\\pnsp":
				x1fa4169cbf2b08e9.x42bf8be828fc1b33 = x153c99a852375422.xd6f9e3c5ae6509d7();
				break;
			case "\\pnprev":
				x1fa4169cbf2b08e9.x969abf858b3fe7e8 = x153c99a852375422.x1ad7968449b109cd();
				break;
			case "\\pnql":
				x1fa4169cbf2b08e9.Alignment = ListLevelAlignment.Left;
				break;
			case "\\pnqc":
				x1fa4169cbf2b08e9.Alignment = ListLevelAlignment.Center;
				break;
			case "\\pnqr":
				x1fa4169cbf2b08e9.Alignment = ListLevelAlignment.Right;
				break;
			default:
				x5b320f47843cd0dd(x153c99a852375422);
				break;
			}
		}
	}

	private void x5b320f47843cd0dd(x03f56b37a0050a82 x153c99a852375422)
	{
		object obj = xcb1f99bcd961367e.xed06528f6117d71b(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x1fa4169cbf2b08e9.NumberStyle = (NumberStyle)obj;
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xf71fbad3171c611c:
			x1fa4169cbf2b08e9.NumberFormat = x153c99a852375422.x9f1a6a3451a38d10() + x1fa4169cbf2b08e9.NumberFormat;
			break;
		case x25099a8bbbd55d1c.x2bb1565407c1dc98:
			x1fa4169cbf2b08e9.NumberFormat += x153c99a852375422.x9f1a6a3451a38d10();
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xf71fbad3171c611c:
		case x25099a8bbbd55d1c.x2bb1565407c1dc98:
			return this;
		default:
			return null;
		}
	}

	private int x7af082eaf8e0caa4()
	{
		List xed3a4a9e0daaedc = x28fcdc775a1d069c.xed3a4a9e0daaedc8;
		if (xed3a4a9e0daaedc == null || !List.xda93661a4158325a(x870980ad82373217, xed3a4a9e0daaedc))
		{
			x28fcdc775a1d069c.xed3a4a9e0daaedc8 = x870980ad82373217;
			return x870980ad82373217.ListId;
		}
		return x28fcdc775a1d069c.xed3a4a9e0daaedc8.ListId;
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x9256a6c338f6cb6c && !x60a96ec1df0f970c)
		{
			x870980ad82373217 = base.x2c8c6741422a1298.Lists.xcf5f82306ceb0bff(x902c8ac86fbaf048.x598f41525926b38a);
			x870980ad82373217.ListLevels[0] = x1fa4169cbf2b08e9;
			x1a78664fa10a3755.xae20093bed1e48a8(1120, x7af082eaf8e0caa4());
			x1a78664fa10a3755.xae20093bed1e48a8(1110, 0);
		}
	}
}
