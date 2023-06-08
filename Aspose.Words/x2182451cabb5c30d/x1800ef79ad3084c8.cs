using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x1800ef79ad3084c8 : x92b42501109671de
{
	private bool x41583ff79124ed66;

	private bool x68364576df85c8d4;

	private string xc7682ca9d0dbb95b;

	private string x6f62c98759246ec3;

	private string xf51d7fbd0ad7745b;

	private string x77f70e8519f7f00a;

	protected override string FieldTypeName => " XE ";

	internal x1800ef79ad3084c8(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xb71d01e7dfce7552)
		{
			x0769cdcc579bd707(x153c99a852375422);
		}
		base.x41e7a76e7e854e6e(x153c99a852375422);
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xb71d01e7dfce7552)
		{
			xbbbbc5ea4258e1a4();
		}
		base.xa4085ff83f9ddeeb();
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 != x25099a8bbbd55d1c.xb71d01e7dfce7552)
		{
			base.xa2d8e36cb99ac0f4(x153c99a852375422);
		}
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\bxe":
			x41583ff79124ed66 = true;
			break;
		case "\\ixe":
			x68364576df85c8d4 = true;
			break;
		case "\\xef":
			xc7682ca9d0dbb95b = ((char)x153c99a852375422.xd6f9e3c5ae6509d7()).ToString();
			break;
		case "\\yxe":
		case "\\*\\pxe":
			x77f70e8519f7f00a = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x21b352f5e2a8e107:
			xf51d7fbd0ad7745b = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.xa01bf89203d2b0f3:
			x6f62c98759246ec3 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		default:
			base.xbd6083b329527c4e(x153c99a852375422);
			break;
		}
	}

	protected override void WriteSwitches()
	{
		if (x41583ff79124ed66)
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f("\\b ");
		}
		if (x68364576df85c8d4)
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f("\\i ");
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xc7682ca9d0dbb95b))
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f($"\\f {xc7682ca9d0dbb95b} ");
		}
		if (x0d299f323d241756.x5959bccb67bbf051(xf51d7fbd0ad7745b))
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f($"\\t {xf51d7fbd0ad7745b} ");
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x6f62c98759246ec3))
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f($"\\r {x6f62c98759246ec3} ");
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x77f70e8519f7f00a))
		{
			base.xe1410f585439c7d4.x93a8c149d218a60f($"\\y {x77f70e8519f7f00a} ");
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x21b352f5e2a8e107:
		case x25099a8bbbd55d1c.xa01bf89203d2b0f3:
			return this;
		default:
			return base.x3e0bce851c12a688(x8d3f74e5f925679c);
		}
	}
}
