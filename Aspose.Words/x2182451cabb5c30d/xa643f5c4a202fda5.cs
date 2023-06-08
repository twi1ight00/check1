using System;
using Aspose.Words;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class xa643f5c4a202fda5 : x77fb5b1d5c73757b, x59a1e7b7667e1e09
{
	private readonly x8ee18b8f4295c535 x41df766edde5529a;

	private readonly x993788b5cd99d56d x6afc37d326b2e946;

	private readonly x8a31fc9888704a72 xac44741bdb344b18;

	private readonly xc25c28c64aadfd1b x1dacd46ba2dcd424;

	private int x3e99b3fb6a3e2e63;

	private Style x5d9fbd9603e9dee5;

	private x22510822ff0a46e1 xaa4cad59ac5e33ce;

	xeedad81aaed42a76 x59a1e7b7667e1e09.xde260d73421dc90a => x5d9fbd9603e9dee5.xeedad81aaed42a76;

	x1a78664fa10a3755 x59a1e7b7667e1e09.x6048c795873de899 => x5d9fbd9603e9dee5.x1a78664fa10a3755;

	internal xa643f5c4a202fda5(xe5e546ef5f0503b2 context)
		: base(context)
	{
		x41df766edde5529a = new x8ee18b8f4295c535(context, this);
		x6afc37d326b2e946 = new x993788b5cd99d56d(context, this);
		xac44741bdb344b18 = new x8a31fc9888704a72(context);
		x1dacd46ba2dcd424 = new xc25c28c64aadfd1b();
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xfcffbd79482d97c7:
			xb5b081b5c009f31d(StyleType.Paragraph, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case x25099a8bbbd55d1c.xcdd1fdba92902f20:
			xb5b081b5c009f31d(StyleType.Character, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case x25099a8bbbd55d1c.x6c19282943d32085:
			xb5b081b5c009f31d(StyleType.Table, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xd5208d8e1e3a3e5f)
		{
			x1dacd46ba2dcd424.x5f3c0783a74b5d80(x28fcdc775a1d069c);
		}
	}

	internal override void x7cf86f9ad985db0c()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xd5208d8e1e3a3e5f)
		{
			xb5b081b5c009f31d(StyleType.Paragraph, 0);
		}
	}

	internal override void x1d4c43383d15306d()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xd5208d8e1e3a3e5f && x5d9fbd9603e9dee5 != null)
		{
			x81682464c0c4247a("Normal", null);
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x5d9fbd9603e9dee5 != null)
		{
			switch (x153c99a852375422.x1dafd189c5465293())
			{
			case "\\sbasedon":
				xaa4cad59ac5e33ce.x4c48a782e25bce54 = x153c99a852375422.xd6f9e3c5ae6509d7();
				break;
			case "\\snext":
				xaa4cad59ac5e33ce.xbc13914359462815 = x153c99a852375422.xd6f9e3c5ae6509d7();
				break;
			case "\\slink":
				xaa4cad59ac5e33ce.xe014cc494bbbb1d4 = x153c99a852375422.xd6f9e3c5ae6509d7();
				break;
			case "\\sautoupd":
				x5d9fbd9603e9dee5.x913ff5916b187824 = true;
				break;
			case "\\shidden":
				x5d9fbd9603e9dee5.x96e55b5d052d1279 = true;
				break;
			case "\\ssemihidden":
				x5d9fbd9603e9dee5.x45101ac87546632f = true;
				break;
			case "\\sqformat":
				x5d9fbd9603e9dee5.xebe0f6c7e6f4ae3a = true;
				break;
			case "\\spriority":
				x5d9fbd9603e9dee5.x9eb07da9aa5bbf9e = x153c99a852375422.xd6f9e3c5ae6509d7();
				break;
			case "\\sunhideused":
				x5d9fbd9603e9dee5.x5356a3af7e7ecdfa = true;
				break;
			case "\\slocked":
				x5d9fbd9603e9dee5.x2d8aaa05bddcf40c = true;
				break;
			case "\\spersonal":
				x5d9fbd9603e9dee5.xdf3672ec434b4524 = true;
				break;
			case "\\scompose":
				x5d9fbd9603e9dee5.xde61abbe9514a1ee = true;
				break;
			case "\\sreply":
				x5d9fbd9603e9dee5.x3bbb21ee843f081c = true;
				break;
			case "\\styrsid":
				x5d9fbd9603e9dee5.xe12a6bc6d222e782 = x153c99a852375422.xd6f9e3c5ae6509d7();
				break;
			default:
				x97129b72920db2eb(x153c99a852375422);
				break;
			}
		}
	}

	private void x97129b72920db2eb(x03f56b37a0050a82 x153c99a852375422)
	{
		if (!x6afc37d326b2e946.x06b0e25aa6ad68a9(x153c99a852375422) && !x41df766edde5529a.x06b0e25aa6ad68a9(x153c99a852375422))
		{
			xac44741bdb344b18.x06b0e25aa6ad68a9(x153c99a852375422);
		}
	}

	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (!x153c99a852375422.x01175ba8d76995be)
		{
			string text = x153c99a852375422.x8b1c61c709b6f253();
			string[] array = text.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].Trim();
			}
			string[] array2 = new string[array.Length - 1];
			Array.Copy(array, 1, array2, 0, array2.Length);
			x81682464c0c4247a(array[0], array2);
		}
	}

	private void xb5b081b5c009f31d(StyleType x4320c3ef9926c38d, int xd154f74ce25deec0)
	{
		x3e99b3fb6a3e2e63 = xd154f74ce25deec0;
		x5d9fbd9603e9dee5 = Style.xebcf83b00134300b(x4320c3ef9926c38d);
		x5d9fbd9603e9dee5.x9eb07da9aa5bbf9e = 99;
		xaa4cad59ac5e33ce = new x22510822ff0a46e1(x5d9fbd9603e9dee5);
	}

	private void x81682464c0c4247a(string xc15bd84e01929885, string[] x4bb79322d6f07955)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xc15bd84e01929885) && x5d9fbd9603e9dee5 != null)
		{
			xa0d3611565b2a1f2.x339a4889e0bd1111(x5d9fbd9603e9dee5.x1a78664fa10a3755, xbcea506a33cf9111: false);
			x2a19dee8776aaa44.x5d14aa99881b11fb(xc15bd84e01929885, base.x2c8c6741422a1298.Styles, x5409eeb7bc334110: false, x5d9fbd9603e9dee5);
			x28fcdc775a1d069c.x214a3d715a732d1d(x3e99b3fb6a3e2e63, x5d9fbd9603e9dee5.x8301ab10c226b0c2);
			base.x2c8c6741422a1298.Styles.x4880cad9f3196627(x5d9fbd9603e9dee5, x4bb79322d6f07955);
			x5d9fbd9603e9dee5 = null;
			x1dacd46ba2dcd424.Add(xaa4cad59ac5e33ce);
			xaa4cad59ac5e33ce = null;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xfcffbd79482d97c7:
		case x25099a8bbbd55d1c.xcdd1fdba92902f20:
		case x25099a8bbbd55d1c.x6c19282943d32085:
			return this;
		default:
			return null;
		}
	}
}
