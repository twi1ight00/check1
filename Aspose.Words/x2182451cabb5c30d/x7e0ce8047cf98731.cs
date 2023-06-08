using Aspose.Words;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using xf9a9481c3f63a419;

namespace x2182451cabb5c30d;

internal class x7e0ce8047cf98731 : xe16295e98b4802cb
{
	private TextColumn xf3fbabf0ef3f47d9;

	private readonly xfc72d4c9b765cad7 x6dc8dd913f68e980;

	private xfc72d4c9b765cad7 xfc72d4c9b765cad7
	{
		get
		{
			if (x6dc8dd913f68e980 == null)
			{
				return base.x28fcdc775a1d069c.xa3a0cc3e91617aca.xffb3238a8fd59aa7.xfc72d4c9b765cad7;
			}
			return x6dc8dd913f68e980;
		}
	}

	internal x7e0ce8047cf98731(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal x7e0ce8047cf98731(xe5e546ef5f0503b2 context, xfc72d4c9b765cad7 sectPr)
		: base(context)
	{
		x6dc8dd913f68e980 = sectPr;
	}

	protected override bool ParseSingleToken(x03f56b37a0050a82 token)
	{
		switch (token.x1dafd189c5465293())
		{
		case "\\sectd":
			xa2a7b403588cebcd();
			break;
		case "\\ltrsect":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2450, false);
			break;
		case "\\rtlsect":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2450, true);
			break;
		case "\\binfsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2070, token.xd6f9e3c5ae6509d7());
			break;
		case "\\binsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2080, token.xd6f9e3c5ae6509d7());
			break;
		case "\\sectunlocked":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2390, true);
			break;
		case "\\cols":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2350, token.xd6f9e3c5ae6509d7());
			break;
		case "\\colsx":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2370, token.xd6f9e3c5ae6509d7());
			break;
		case "\\linebetcol":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2060, true);
			break;
		case "\\linemod":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2120, token.xd6f9e3c5ae6509d7());
			break;
		case "\\linex":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2400, token.xd6f9e3c5ae6509d7());
			break;
		case "\\linestarts":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2180, token.xd6f9e3c5ae6509d7());
			break;
		case "\\pgwsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2260, token.xd6f9e3c5ae6509d7());
			break;
		case "\\pghsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2270, token.xd6f9e3c5ae6509d7());
			break;
		case "\\marglsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2280, token.xd6f9e3c5ae6509d7());
			break;
		case "\\margrsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2290, token.xd6f9e3c5ae6509d7());
			break;
		case "\\margtsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2300, token.xd6f9e3c5ae6509d7());
			break;
		case "\\margbsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2310, token.xd6f9e3c5ae6509d7());
			break;
		case "\\guttersxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2312, token.xd6f9e3c5ae6509d7());
			break;
		case "\\headery":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2320, token.xd6f9e3c5ae6509d7());
			break;
		case "\\footery":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2330, token.xd6f9e3c5ae6509d7());
			break;
		case "\\pgnstarts":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2200, token.xd6f9e3c5ae6509d7());
			break;
		case "\\pgnrestart":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2050, true);
			break;
		case "\\titlepg":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2040, true);
			break;
		case "\\pgnhn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2190, token.xd6f9e3c5ae6509d7());
			break;
		case "\\stextflow":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2440, (x6d434087bc06a37d)token.xd6f9e3c5ae6509d7());
			break;
		case "\\rtlgutter":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2410, true);
			break;
		case "\\pgbrdrl":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xfc72d4c9b765cad7, 2140);
			break;
		case "\\pgbrdrr":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xfc72d4c9b765cad7, 2160);
			break;
		case "\\pgbrdrt":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xfc72d4c9b765cad7, 2130);
			break;
		case "\\pgbrdrb":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xfc72d4c9b765cad7, 2150);
			break;
		case "\\psz":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2090, token.xd6f9e3c5ae6509d7());
			break;
		case "\\endnhere":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2100, false);
			break;
		case "\\colno":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2360, false);
			xf3fbabf0ef3f47d9 = x5b5a70d82c2cb376(token.xd6f9e3c5ae6509d7() - 1);
			break;
		case "\\colw":
			xe88f939907193347();
			xf3fbabf0ef3f47d9.x7219de950d4b708a = token.xd6f9e3c5ae6509d7();
			break;
		case "\\colsr":
			xe88f939907193347();
			xf3fbabf0ef3f47d9.xbe8b68828bd16a4b = token.xd6f9e3c5ae6509d7();
			break;
		case "\\lndscpsxn":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2210, Orientation.Landscape);
			break;
		case "\\pgbrdropt":
			xe0161eb932938b13(token.xd6f9e3c5ae6509d7());
			break;
		case "\\sftnstart":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2520, token.xd6f9e3c5ae6509d7());
			break;
		case "\\saftnstart":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2620, token.xd6f9e3c5ae6509d7());
			break;
		case "\\sectlinegrid":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2170, token.xd6f9e3c5ae6509d7());
			break;
		case "\\sectexpand":
			xfc72d4c9b765cad7.xae20093bed1e48a8(2420, token.xd6f9e3c5ae6509d7());
			break;
		case "\\srauth":
			base.x28fcdc775a1d069c.x3c5cf62121f6ba42 = xca004f56614e2431.xc8ba948e0d631490(token.xd6f9e3c5ae6509d7());
			break;
		case "\\srdate":
			base.x28fcdc775a1d069c.x125b1f8e1ea06d76 = xa0d3611565b2a1f2.x9a175459d1b055a7(token.xd6f9e3c5ae6509d7());
			break;
		default:
			return false;
		}
		return true;
	}

	protected override bool SearchInEnums(x03f56b37a0050a82 token)
	{
		object obj = x118bad6798799e1b.x5cf6fd3d17adb2fc(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2030, (SectionStart)obj);
			return true;
		}
		obj = x118bad6798799e1b.x7f1609c8ef323c30(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2110, (LineNumberRestartMode)obj);
			return true;
		}
		obj = x118bad6798799e1b.x24eaaadaf38d1f3b(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2010, (NumberStyle)obj);
			return true;
		}
		obj = x118bad6798799e1b.x79c45be508b7681a(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2340, (PageVerticalAlignment)obj);
			return true;
		}
		obj = x118bad6798799e1b.xa3603aeec729ffc0(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2020, (xbdc85485688e2cf3)obj);
			return true;
		}
		obj = x118bad6798799e1b.x83f6f85fa4803d5b(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2500, (FootnoteLocation)obj);
			return true;
		}
		obj = x118bad6798799e1b.xc564832c63111a37(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2510, (FootnoteNumberingRule)obj);
			return true;
		}
		obj = x118bad6798799e1b.x6d975995ee3c0c2d(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2610, (FootnoteNumberingRule)obj);
			return true;
		}
		obj = x118bad6798799e1b.x0e18340ee87d81ff(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2530, (NumberStyle)obj);
			return true;
		}
		obj = x118bad6798799e1b.xcc44b4ac06c98352(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2630, (NumberStyle)obj);
			return true;
		}
		obj = x118bad6798799e1b.x8b9c7c22f5de7bf0(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2430, (x704ea28be0f90278)obj);
			return true;
		}
		return false;
	}

	private void xa2a7b403588cebcd()
	{
		xfc72d4c9b765cad7.ClearAttrs();
		base.x28fcdc775a1d069c.x35f98fe7237b5ee4(xfc72d4c9b765cad7);
		xf3fbabf0ef3f47d9 = null;
	}

	private void xe0161eb932938b13(int xbcea506a33cf9111)
	{
		if (((uint)xbcea506a33cf9111 & (true ? 1u : 0u)) != 0)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2220, PageBorderAppliesTo.FirstPage);
		}
		if (((uint)xbcea506a33cf9111 & 2u) != 0)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2220, PageBorderAppliesTo.OtherPages);
		}
		if (((uint)xbcea506a33cf9111 & 8u) != 0)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2230, false);
		}
		if (((uint)xbcea506a33cf9111 & 0x20u) != 0)
		{
			xfc72d4c9b765cad7.xae20093bed1e48a8(2240, PageBorderDistanceFrom.PageEdge);
		}
	}

	private x28980d9c5ec3f471 x304c29b36f50f30b()
	{
		object obj = xfc72d4c9b765cad7.xf7866f89640a29a3(2380);
		if (obj == null)
		{
			obj = new x28980d9c5ec3f471();
			xfc72d4c9b765cad7.xae20093bed1e48a8(2380, obj);
		}
		return obj as x28980d9c5ec3f471;
	}

	private TextColumn x5b5a70d82c2cb376(int xc0c4c459c6ccbd00)
	{
		x28980d9c5ec3f471 x28980d9c5ec3f = x304c29b36f50f30b();
		while (x28980d9c5ec3f.xd44988f225497f3a <= xc0c4c459c6ccbd00)
		{
			x28980d9c5ec3f.xd6b6ed77479ef68c(new TextColumn());
		}
		return x28980d9c5ec3f.get_xe6d4b1b411ed94b5(xc0c4c459c6ccbd00);
	}

	private void xe88f939907193347()
	{
		if (xf3fbabf0ef3f47d9 == null)
		{
			xf3fbabf0ef3f47d9 = x5b5a70d82c2cb376(0);
		}
	}
}
