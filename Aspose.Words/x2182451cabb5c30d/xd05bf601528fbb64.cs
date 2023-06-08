using System.Collections;
using Aspose.Words;
using x1495530f35d79681;
using xd2754ae26d400653;
using xda075892eccab2ad;

namespace x2182451cabb5c30d;

internal class xd05bf601528fbb64 : x77fb5b1d5c73757b
{
	private readonly Hashtable x873e474df27816d8;

	private readonly Hashtable xcc3d2f99f97ebfc0;

	private x178ff6dcbf808c38 xc1e8aac83e2f5781;

	internal xd05bf601528fbb64(xe5e546ef5f0503b2 context, Hashtable listStyles)
		: base(context)
	{
		x873e474df27816d8 = listStyles;
		xcc3d2f99f97ebfc0 = new Hashtable();
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x06ca69422bbb7502:
			xc1e8aac83e2f5781 = new x178ff6dcbf808c38(base.x2c8c6741422a1298);
			break;
		case x25099a8bbbd55d1c.xe4d315abfbcb57b5:
			x28fcdc775a1d069c.xb778e4a87af27d7a = true;
			break;
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x06ca69422bbb7502)
		{
			base.x2c8c6741422a1298.Lists.x3698cb58c2e87a72(xc1e8aac83e2f5781);
			return;
		}
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xe4d315abfbcb57b5)
		{
			x28fcdc775a1d069c.xb778e4a87af27d7a = false;
		}
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 != x25099a8bbbd55d1c.xccc4aace2acc681c)
		{
			return;
		}
		foreach (DictionaryEntry item in xcc3d2f99f97ebfc0)
		{
			int x6b9cdc3a87f7e = (int)item.Key;
			x178ff6dcbf808c38 x178ff6dcbf808c = base.x2c8c6741422a1298.Lists.x44c0fd1f259e7914(x6b9cdc3a87f7e);
			x178ff6dcbf808c38 x178ff6dcbf808c2 = (x178ff6dcbf808c38)item.Value;
			x178ff6dcbf808c2.xc657ea789af2c1f0 = x178ff6dcbf808c.xc657ea789af2c1f0;
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\listid":
			xc1e8aac83e2f5781.xd0e9f66f8c4d99a4(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\listtemplateid":
			xc1e8aac83e2f5781.xb194d434d9f9f2fe(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\listsimple":
			xc1e8aac83e2f5781.x570106e08534c22d((!x153c99a852375422.x1ad7968449b109cd()) ? x902c8ac86fbaf048.x7e86ac926e2dc940 : x902c8ac86fbaf048.xabed123f43874357);
			break;
		case "\\listhybrid":
			xc1e8aac83e2f5781.x570106e08534c22d(x902c8ac86fbaf048.x598f41525926b38a);
			break;
		case "\\liststyleid":
			xcc3d2f99f97ebfc0[x153c99a852375422.xd6f9e3c5ae6509d7()] = xc1e8aac83e2f5781;
			break;
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x0e32cd4b5c1e6066:
			xc1e8aac83e2f5781.x759aa16c2016a289 = x153c99a852375422.x8b1c61c709b6f253().Trim();
			break;
		case x25099a8bbbd55d1c.xcd9b4175b0c537a1:
			x8ee06e9ac5beea4e(x153c99a852375422.x8b1c61c709b6f253().Trim());
			break;
		}
	}

	private void x8ee06e9ac5beea4e(string xc0ac61b6b7451e53)
	{
		Style style = Style.xebcf83b00134300b(StyleType.List);
		string xc15bd84e = x72a0c846678ecaf9.x9f0d5871d8820eaa(xc0ac61b6b7451e53);
		x2a19dee8776aaa44.x5d14aa99881b11fb(xc15bd84e, base.x2c8c6741422a1298.Styles, x5409eeb7bc334110: false, style);
		style.xe709b224f455b863 = 12;
		base.x2c8c6741422a1298.Styles.x4880cad9f3196627(style, null);
		xc1e8aac83e2f5781.xc657ea789af2c1f0 = style.x8301ab10c226b0c2;
		x873e474df27816d8.Add(xc1e8aac83e2f5781.x1eac770549050632, style);
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x06ca69422bbb7502:
		case x25099a8bbbd55d1c.x0e32cd4b5c1e6066:
		case x25099a8bbbd55d1c.xcd9b4175b0c537a1:
			return this;
		case x25099a8bbbd55d1c.xe4d315abfbcb57b5:
		case x25099a8bbbd55d1c.x603f0fb008b78869:
			return this;
		case x25099a8bbbd55d1c.x7f4d496937f8c24c:
			return new x06bdd5a0c5e58c38(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.xf13a626e550cef8f:
			return new xc1b9962c90992074(x28fcdc775a1d069c, xc1e8aac83e2f5781.x438a2a8db4b2d07b);
		default:
			return null;
		}
	}
}
