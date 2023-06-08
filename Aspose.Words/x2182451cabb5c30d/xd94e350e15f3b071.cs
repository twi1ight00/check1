using Aspose.Words.Fonts;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class xd94e350e15f3b071 : x77fb5b1d5c73757b
{
	private FontInfo xd7b4532b0bf80bea = new FontInfo();

	private int x8520bd59e7159a87 = -1;

	internal xd94e350e15f3b071(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.xc2d4efc42998d87b)
		{
			xf65ad57e7ed864d0(x153c99a852375422);
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x1f12cbed334321cb)
		{
			xe48a3ca1def945ae();
			xeedad81aaed42a76 x27096df7ca0cfe2e = base.x2c8c6741422a1298.Styles.x27096df7ca0cfe2e;
			x27096df7ca0cfe2e.x759aa16c2016a289 = x28fcdc775a1d069c.x241e429ca27700bc(x28fcdc775a1d069c.x1ea60bde2b5d0d28.x2ddab4ad01316604);
			xeedad81aaed42a76 xf1034b7f118809b = x28fcdc775a1d069c.x1ea60bde2b5d0d28.xf1034b7f118809b3;
			for (int i = 0; i < xf1034b7f118809b.xd44988f225497f3a; i++)
			{
				x27096df7ca0cfe2e.xae20093bed1e48a8(xf1034b7f118809b.xf15263674eb297bb(i), x28fcdc775a1d069c.x241e429ca27700bc((int)xf1034b7f118809b.x6d3720b962bd3112(i)));
			}
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\f":
			xf65ad57e7ed864d0(x153c99a852375422);
			break;
		case "\\fcharset":
			xd7b4532b0bf80bea.Charset = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\fnil":
			xd7b4532b0bf80bea.Family = FontFamily.Auto;
			break;
		case "\\froman":
			xd7b4532b0bf80bea.Family = FontFamily.Roman;
			break;
		case "\\fswiss":
			xd7b4532b0bf80bea.Family = FontFamily.Swiss;
			break;
		case "\\fmodern":
			xd7b4532b0bf80bea.Family = FontFamily.Modern;
			break;
		case "\\fscript":
			xd7b4532b0bf80bea.Family = FontFamily.Script;
			break;
		case "\\fdecor":
			xd7b4532b0bf80bea.Family = FontFamily.Decorative;
			break;
		case "\\fprq":
			xd7b4532b0bf80bea.Pitch = (FontPitch)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		}
	}

	private void xf65ad57e7ed864d0(x03f56b37a0050a82 x153c99a852375422)
	{
		xe48a3ca1def945ae();
		xd7b4532b0bf80bea = new FontInfo();
		x8520bd59e7159a87 = x153c99a852375422.xd6f9e3c5ae6509d7();
	}

	private void xe48a3ca1def945ae()
	{
		if (x8520bd59e7159a87 > -1 && x0d299f323d241756.x5959bccb67bbf051(xd7b4532b0bf80bea.Name))
		{
			x28fcdc775a1d069c.x6671391caefa5949.xd6b6ed77479ef68c(x8520bd59e7159a87, xd7b4532b0bf80bea);
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x1f12cbed334321cb:
			if (xd7b4532b0bf80bea != null)
			{
				xb937f7b52169d837(x153c99a852375422);
			}
			break;
		case x25099a8bbbd55d1c.xc2d4efc42998d87b:
			xb937f7b52169d837(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x2eba0d3ba8ad5a6d:
			xd7b4532b0bf80bea.AltName = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x5d9755713fc0cbea:
			xd7b4532b0bf80bea.Panose = x153c99a852375422.xbfeb690f3f95a932();
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xc2d4efc42998d87b:
		case x25099a8bbbd55d1c.x2eba0d3ba8ad5a6d:
		case x25099a8bbbd55d1c.x5d9755713fc0cbea:
			return this;
		default:
			return null;
		}
	}

	private void xb937f7b52169d837(x03f56b37a0050a82 x153c99a852375422)
	{
		if (!x153c99a852375422.x01175ba8d76995be)
		{
			xd7b4532b0bf80bea.x54f99ef1e934e59c(x153c99a852375422.x8b1c61c709b6f253());
		}
	}
}
