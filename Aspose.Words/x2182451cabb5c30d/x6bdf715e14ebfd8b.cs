using System;
using Aspose.Words.Properties;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x6bdf715e14ebfd8b : x77fb5b1d5c73757b
{
	private int xcdaa1c36eaf1cdfb;

	private int xeac82df1d62b054c;

	private int x039f0d67180f0c69;

	private int xbdfb389e43af25ba;

	private int x14a4b50c4529d395;

	private int x92085659785aa689;

	private BuiltInDocumentProperties xb96b7778f41658ef => base.x2c8c6741422a1298.BuiltInDocumentProperties;

	internal x6bdf715e14ebfd8b(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x3495c9728d107e27:
		case x25099a8bbbd55d1c.x46d7a886a16e7d52:
		case x25099a8bbbd55d1c.x412556343b1cb75e:
			xcdaa1c36eaf1cdfb = 0;
			xeac82df1d62b054c = 0;
			x039f0d67180f0c69 = 0;
			xbdfb389e43af25ba = 0;
			x14a4b50c4529d395 = 0;
			x92085659785aa689 = 0;
			break;
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x3495c9728d107e27:
			xb96b7778f41658ef.CreatedTime = x6bfe39ecf058bc42();
			break;
		case x25099a8bbbd55d1c.x46d7a886a16e7d52:
			xb96b7778f41658ef.LastSavedTime = x6bfe39ecf058bc42();
			break;
		case x25099a8bbbd55d1c.x412556343b1cb75e:
			xb96b7778f41658ef.LastPrinted = x6bfe39ecf058bc42();
			break;
		}
	}

	private DateTime x6bfe39ecf058bc42()
	{
		return x7546e38fbb25d738.xfde53ea35dfda4e6(xcdaa1c36eaf1cdfb, xeac82df1d62b054c, x039f0d67180f0c69, xbdfb389e43af25ba, x14a4b50c4529d395, x92085659785aa689, 0);
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x8b1cb9d9e99957fd:
			x5c2e54fbd3bbaf49(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x3495c9728d107e27:
		case x25099a8bbbd55d1c.x46d7a886a16e7d52:
		case x25099a8bbbd55d1c.x412556343b1cb75e:
			xf4553a982d370799(x153c99a852375422);
			break;
		}
	}

	private void x5c2e54fbd3bbaf49(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\version":
			xb96b7778f41658ef.RevisionNumber = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\edmins":
			xb96b7778f41658ef.xcc3f5a7a232023b9(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\nofpages":
			xb96b7778f41658ef.Pages = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\nofwords":
			xb96b7778f41658ef.Words = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\nofchars":
			xb96b7778f41658ef.Characters = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\nofcharsws":
			xb96b7778f41658ef.CharactersWithSpaces = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		}
	}

	private void xf4553a982d370799(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\yr":
			xcdaa1c36eaf1cdfb = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mo":
			xeac82df1d62b054c = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\dy":
			x039f0d67180f0c69 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\hr":
			xbdfb389e43af25ba = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\min":
			x14a4b50c4529d395 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\sec":
			x92085659785aa689 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x238bf167ccfdd282:
			xb96b7778f41658ef.Title = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x191dcb88c409b8dd:
			xb96b7778f41658ef.Subject = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.xb063bbfcfeade526:
			xb96b7778f41658ef.Author = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x460ab163f44a604d:
			xb96b7778f41658ef.Manager = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.xcd76cf11e368bbb7:
			xb96b7778f41658ef.Company = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x3924d9c4d0914f45:
			xb96b7778f41658ef.HyperlinkBase = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x65f1c5fa03df41d5:
			xb96b7778f41658ef.LastSavedBy = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x9ee8adcec1e2f351:
			xb96b7778f41658ef.Category = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x514c0ea24ce40ef0:
			xb96b7778f41658ef.Keywords = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x4e020dae918bd2ce:
			xb96b7778f41658ef.Comments = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x13964cbdcc2ac7cf:
			xc97fd5d1822c8273(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		case x25099a8bbbd55d1c.x97fd7ee24073e9ef:
			x7364ac353cb5a0c9.x06b0e25aa6ad68a9(x153c99a852375422.x9f1a6a3451a38d10(), base.x2c8c6741422a1298.xdade2366eaa6f915.xcadc354ab6a177f1.x218603e609fcc201);
			break;
		}
	}

	private void xc97fd5d1822c8273(string xbcea506a33cf9111)
	{
		x2dce569e9052de2d x2dce569e9052de2d2 = new x2dce569e9052de2d(xbcea506a33cf9111);
		base.x2c8c6741422a1298.xdade2366eaa6f915.xcadc354ab6a177f1.xf111d6890e7de382 = x2dce569e9052de2d2.x95ea7d23cc8ee04d();
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x238bf167ccfdd282:
		case x25099a8bbbd55d1c.x191dcb88c409b8dd:
		case x25099a8bbbd55d1c.xb063bbfcfeade526:
		case x25099a8bbbd55d1c.x460ab163f44a604d:
		case x25099a8bbbd55d1c.xcd76cf11e368bbb7:
		case x25099a8bbbd55d1c.x3924d9c4d0914f45:
		case x25099a8bbbd55d1c.x65f1c5fa03df41d5:
		case x25099a8bbbd55d1c.x9ee8adcec1e2f351:
		case x25099a8bbbd55d1c.x514c0ea24ce40ef0:
		case x25099a8bbbd55d1c.x4e020dae918bd2ce:
		case x25099a8bbbd55d1c.x3495c9728d107e27:
		case x25099a8bbbd55d1c.x46d7a886a16e7d52:
		case x25099a8bbbd55d1c.x412556343b1cb75e:
		case x25099a8bbbd55d1c.x13964cbdcc2ac7cf:
		case x25099a8bbbd55d1c.x97fd7ee24073e9ef:
			return this;
		default:
			return null;
		}
	}
}
