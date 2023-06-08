using Aspose.Words;
using Aspose.Words.Tables;
using x556d8f9846e43329;
using x9db5f2e5af3d596e;

namespace x2182451cabb5c30d;

internal class xa0e37ef375d9f69e : xe16295e98b4802cb
{
	private xf8cef531dae89ea3 xede608e9bc344cf9;

	private int x8f0d1cc8ee9cb897;

	private PreferredWidthType x350e39933f9a6b61;

	private bool xd55d7b1d37bd1a9a;

	private xedb0eb766e25e0c9 xedb0eb766e25e0c9 => base.x28fcdc775a1d069c.xde27e91a248c4c90.xedb0eb766e25e0c9;

	private Shading x554aca059bdf6d48 => x4e5da2e11272a820.x55d54ac049a678c6(xede608e9bc344cf9, 3170);

	internal xa0e37ef375d9f69e(xe5e546ef5f0503b2 context)
		: base(context)
	{
		xa2a7b403588cebcd();
	}

	protected override bool ParseSingleToken(x03f56b37a0050a82 token)
	{
		switch (token.x1dafd189c5465293())
		{
		case "\\tcelld":
			base.x28fcdc775a1d069c.xde27e91a248c4c90.xe02d79c539b6382d = xedb0eb766e25e0c9.xc0741c7ff92cf1aa;
			xa2a7b403588cebcd();
			break;
		case "\\clmgf":
			xede608e9bc344cf9.xae20093bed1e48a8(3040, CellMerge.First);
			break;
		case "\\clmrg":
			xede608e9bc344cf9.xae20093bed1e48a8(3040, CellMerge.Previous);
			break;
		case "\\clvmgf":
			xede608e9bc344cf9.xae20093bed1e48a8(3030, CellMerge.First);
			break;
		case "\\clvmrg":
			xede608e9bc344cf9.xae20093bed1e48a8(3030, CellMerge.Previous);
			break;
		case "\\clFitText":
			xede608e9bc344cf9.xae20093bed1e48a8(3190, true);
			break;
		case "\\clNoWrap":
			xede608e9bc344cf9.xae20093bed1e48a8(3180, false);
			break;
		case "\\clhidemark":
			xede608e9bc344cf9.xae20093bed1e48a8(3220, true);
			break;
		case "\\clbrdrl":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xede608e9bc344cf9, 3120);
			break;
		case "\\clbrdrr":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xede608e9bc344cf9, 3140);
			break;
		case "\\clbrdrt":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xede608e9bc344cf9, 3110);
			break;
		case "\\clbrdrb":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xede608e9bc344cf9, 3130);
			break;
		case "\\cldgll":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xede608e9bc344cf9, 3160);
			break;
		case "\\cldglu":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xede608e9bc344cf9, 3150);
			break;
		case "\\clpadt":
			xede608e9bc344cf9.xae20093bed1e48a8(3090, token.xd6f9e3c5ae6509d7());
			break;
		case "\\clpadr":
			xede608e9bc344cf9.xae20093bed1e48a8(3100, token.xd6f9e3c5ae6509d7());
			break;
		case "\\clpadl":
			xede608e9bc344cf9.xae20093bed1e48a8(3070, token.xd6f9e3c5ae6509d7());
			break;
		case "\\clpadb":
			xede608e9bc344cf9.xae20093bed1e48a8(3080, token.xd6f9e3c5ae6509d7());
			break;
		case "\\clwWidth":
			x8f0d1cc8ee9cb897 = token.xd6f9e3c5ae6509d7();
			break;
		case "\\clftsWidth":
			x350e39933f9a6b61 = (PreferredWidthType)token.xd6f9e3c5ae6509d7();
			xd55d7b1d37bd1a9a = true;
			break;
		case "\\cellx":
			x82ffd2af3bb35eae(token);
			break;
		case "\\clshdng":
			x4e5da2e11272a820.x8afbf301967d3fb1(x554aca059bdf6d48, token);
			break;
		case "\\clcbpat":
			x4e5da2e11272a820.x959d3c962e8ead5a(base.x28fcdc775a1d069c, x554aca059bdf6d48, token);
			break;
		case "\\clcfpat":
			x4e5da2e11272a820.xe86c81ecd859a448(base.x28fcdc775a1d069c, x554aca059bdf6d48, token);
			break;
		case "\\clshdrawnil":
			xede608e9bc344cf9.x52b190e626f65140(3170);
			break;
		case "\\clspl":
		case "\\clspt":
		case "\\clspb":
		case "\\clspr":
		case "\\clspfl":
		case "\\clspft":
		case "\\clspfb":
		case "\\clspfr":
			base.x28fcdc775a1d069c.xbd5e5733680bbfc8(token.x1dafd189c5465293());
			break;
		default:
			return false;
		case "\\clpadft":
		case "\\clpadfr":
		case "\\clpadfl":
		case "\\clpadfb":
			break;
		}
		return true;
	}

	protected override bool SearchInEnums(x03f56b37a0050a82 token)
	{
		object obj = x6e170ce4c1e43b64.x89d30e020b4ec58d(token.x1dafd189c5465293());
		if (obj != null)
		{
			xede608e9bc344cf9.xae20093bed1e48a8(3060, (CellVerticalAlignment)obj);
			return true;
		}
		obj = x6e170ce4c1e43b64.xe5374a7cb6aa1c2d(token.x1dafd189c5465293());
		if (obj != null)
		{
			xede608e9bc344cf9.xae20093bed1e48a8(3050, (TextOrientation)obj);
			return true;
		}
		return false;
	}

	private void x82ffd2af3bb35eae(x03f56b37a0050a82 x2754258cc9728b96)
	{
		xdb4d596cc6b8659f xdb4d596cc6b8659f = xc9a4a1dedfcee074();
		if (xdb4d596cc6b8659f.Count == 0 && !xedb0eb766e25e0c9.xbc5dc59d0d9b620d(4340) && xedb0eb766e25e0c9.x9ba359ff37a3a63b != TableAlignment.Center)
		{
			xedb0eb766e25e0c9.xc0741c7ff92cf1aa = base.x28fcdc775a1d069c.xde27e91a248c4c90.xe02d79c539b6382d + xedb0eb766e25e0c9.x041b3af1d4359b5a(xede608e9bc344cf9, base.x28fcdc775a1d069c.xde27e91a248c4c90.xe388359ed363cdcf);
		}
		int num = x2754258cc9728b96.xd6f9e3c5ae6509d7();
		if (!xd55d7b1d37bd1a9a)
		{
			x350e39933f9a6b61 = PreferredWidthType.Points;
			x8f0d1cc8ee9cb897 = num - base.x28fcdc775a1d069c.xde27e91a248c4c90.xe02d79c539b6382d;
		}
		xede608e9bc344cf9.xae20093bed1e48a8(3020, PreferredWidth.x6b44e3efc21fd5b4(x350e39933f9a6b61, x8f0d1cc8ee9cb897));
		xede608e9bc344cf9.xae20093bed1e48a8(3010, num - base.x28fcdc775a1d069c.xde27e91a248c4c90.xe02d79c539b6382d);
		base.x28fcdc775a1d069c.xde27e91a248c4c90.xe02d79c539b6382d = num;
		xdb4d596cc6b8659f.Add(xede608e9bc344cf9);
		xa2a7b403588cebcd();
	}

	private void xa2a7b403588cebcd()
	{
		xede608e9bc344cf9 = new xf8cef531dae89ea3();
		xede608e9bc344cf9.xae20093bed1e48a8(3120, new Border());
		xede608e9bc344cf9.xae20093bed1e48a8(3140, new Border());
		xede608e9bc344cf9.xae20093bed1e48a8(3110, new Border());
		xede608e9bc344cf9.xae20093bed1e48a8(3130, new Border());
		x8f0d1cc8ee9cb897 = 0;
		x350e39933f9a6b61 = PreferredWidthType.Auto;
		xd55d7b1d37bd1a9a = false;
	}

	private xdb4d596cc6b8659f xc9a4a1dedfcee074()
	{
		if (xedb0eb766e25e0c9.xeeac8c23df57dd1d == null)
		{
			xedb0eb766e25e0c9.xae20093bed1e48a8(5100, new xdb4d596cc6b8659f());
		}
		return xedb0eb766e25e0c9.xeeac8c23df57dd1d;
	}
}
