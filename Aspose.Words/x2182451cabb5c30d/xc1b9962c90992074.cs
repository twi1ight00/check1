using Aspose.Words;
using Aspose.Words.Lists;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class xc1b9962c90992074 : x77fb5b1d5c73757b, x59a1e7b7667e1e09
{
	private readonly ListLevelCollection x6f536e3f20231fe4;

	private readonly x8ee18b8f4295c535 x41df766edde5529a;

	private readonly x993788b5cd99d56d x6afc37d326b2e946;

	private ListLevel x1fa4169cbf2b08e9;

	xeedad81aaed42a76 x59a1e7b7667e1e09.xde260d73421dc90a => x1fa4169cbf2b08e9.xeedad81aaed42a76;

	x1a78664fa10a3755 x59a1e7b7667e1e09.x6048c795873de899 => x1fa4169cbf2b08e9.x1a78664fa10a3755;

	private xc1b9962c90992074(xe5e546ef5f0503b2 context)
		: base(context)
	{
		x41df766edde5529a = new x8ee18b8f4295c535(context, this);
		x6afc37d326b2e946 = new x993788b5cd99d56d(context, this);
	}

	internal xc1b9962c90992074(xe5e546ef5f0503b2 context, ListLevel listLevel)
		: this(context)
	{
		x1fa4169cbf2b08e9 = listLevel;
	}

	internal xc1b9962c90992074(xe5e546ef5f0503b2 context, ListLevelCollection listLevels)
		: this(context)
	{
		x6f536e3f20231fe4 = listLevels;
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xf13a626e550cef8f && x1fa4169cbf2b08e9 == null)
		{
			x1fa4169cbf2b08e9 = new ListLevel(base.x2c8c6741422a1298, x6f536e3f20231fe4.Count);
			x6f536e3f20231fe4.xd6b6ed77479ef68c(x1fa4169cbf2b08e9);
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xf13a626e550cef8f)
		{
			if (x1fa4169cbf2b08e9.x1a78664fa10a3755.xbc5dc59d0d9b620d(1000))
			{
				x1fa4169cbf2b08e9.x4a1340b0df048976 = x1fa4169cbf2b08e9.x1a78664fa10a3755.x8301ab10c226b0c2;
				x1fa4169cbf2b08e9.x1a78664fa10a3755.x52b190e626f65140(1000);
			}
			x1fa4169cbf2b08e9.xeedad81aaed42a76.x52b190e626f65140(370);
			x1fa4169cbf2b08e9.xeedad81aaed42a76.x52b190e626f65140(360);
		}
		base.xa4085ff83f9ddeeb();
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\levelnfc":
		case "\\levelnfcn":
			x1fa4169cbf2b08e9.NumberStyle = (NumberStyle)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\leveljc":
		case "\\leveljcn":
			x1fa4169cbf2b08e9.Alignment = (ListLevelAlignment)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\levelstartat":
			x1fa4169cbf2b08e9.xd62f9a1bfab2aceb(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\levelold":
			x1fa4169cbf2b08e9.xf9be1d0b8b44c7e8 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\levelprev":
			x1fa4169cbf2b08e9.x969abf858b3fe7e8 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\levelprevspace":
			x1fa4169cbf2b08e9.x91bd46873c858a0c = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\levelindent":
			x1fa4169cbf2b08e9.x5cf63f659ff5ee9f = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\levelspace":
			x1fa4169cbf2b08e9.x42bf8be828fc1b33 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\levelfollow":
			x1fa4169cbf2b08e9.TrailingCharacter = (ListTrailingCharacter)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\levellegal":
			x1fa4169cbf2b08e9.IsLegal = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\levelnorestart":
			x1fa4169cbf2b08e9.RestartAfterLevel = -1;
			break;
		case "\\levelpicture":
			x1fa4169cbf2b08e9.x4d819daa8b29e86b = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		default:
			x97129b72920db2eb(x153c99a852375422);
			break;
		}
	}

	private void x97129b72920db2eb(x03f56b37a0050a82 x153c99a852375422)
	{
		if (!x6afc37d326b2e946.x06b0e25aa6ad68a9(x153c99a852375422))
		{
			x41df766edde5529a.x06b0e25aa6ad68a9(x153c99a852375422);
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.xab357f60bbc88a8b)
		{
			xfe494f5d83a95b21(x153c99a852375422.x8b1c61c709b6f253());
		}
	}

	private void xfe494f5d83a95b21(string xb41faee6912a2313)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			x1fa4169cbf2b08e9.xcf5f81ead54b5e79(xb41faee6912a2313.Substring(1, xb41faee6912a2313.Length - 1));
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		x25099a8bbbd55d1c x3146d638ec = x8d3f74e5f925679c.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.xab357f60bbc88a8b)
		{
			return this;
		}
		return null;
	}
}
