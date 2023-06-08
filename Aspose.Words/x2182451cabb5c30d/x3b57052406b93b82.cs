using System;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Markup;
using xf9a9481c3f63a419;

namespace x2182451cabb5c30d;

internal abstract class x3b57052406b93b82 : x77fb5b1d5c73757b
{
	private static readonly char[] xe2e7f264258a58d9 = new char[5] { '\u0005', '\u0002', '\u0003', '\u0004', '\u2002' };

	private readonly xce37787c235be908 xe0d2c28e4d16b98c;

	private readonly x192bb7b8a30d64cd x6ce20e3c774f843d;

	private BookmarkStart x8408170975a63c2a;

	private BookmarkEnd xd6a7d07cb70f9923;

	private Shape x317be79405176667;

	private MarkupLevel x02cda388eff4f556;

	private string xb7b7b94deaea1c86;

	private CustomXmlPropertyCollection x08a845ff18128cdb;

	private CustomXmlMarkup xa8638ccc88c0a062;

	private string x726d3ba1320c25a1;

	private string x7e32ca845d81e3a7;

	private string x77d03f05bf1d1714;

	internal override bool x700ee24405039e9a => true;

	internal x3b57052406b93b82(xe5e546ef5f0503b2 context)
		: base(context)
	{
		xe0d2c28e4d16b98c = new xce37787c235be908(context);
		x6ce20e3c774f843d = new x192bb7b8a30d64cd(context);
	}

	[JavaThrows(true)]
	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x724e8b0eb9767138:
			x8408170975a63c2a = new BookmarkStart(base.x2c8c6741422a1298);
			base.xe1410f585439c7d4.xa5c8bd4eb8264c5b(x8408170975a63c2a);
			break;
		case x25099a8bbbd55d1c.x1148fa1778bbfd56:
			xd6a7d07cb70f9923 = new BookmarkEnd(base.x2c8c6741422a1298);
			base.xe1410f585439c7d4.x6d5145c03507a8ad(xd6a7d07cb70f9923);
			break;
		case x25099a8bbbd55d1c.xc9d0b7c9b6633f23:
			x02cda388eff4f556 = MarkupLevel.Unknown;
			xb7b7b94deaea1c86 = "";
			x08a845ff18128cdb = null;
			break;
		case x25099a8bbbd55d1c.x1765dc44848570d6:
			base.xe1410f585439c7d4.xee59bcd855a217ab();
			break;
		case x25099a8bbbd55d1c.x9a9a16139e924916:
			x726d3ba1320c25a1 = "";
			x7e32ca845d81e3a7 = "";
			x77d03f05bf1d1714 = "";
			break;
		}
	}

	[JavaThrows(true)]
	internal override void xa4085ff83f9ddeeb()
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x9a9a16139e924916:
			if (x7e32ca845d81e3a7 == "placeholder" && xa8638ccc88c0a062 != null)
			{
				xa8638ccc88c0a062.Placeholder = x77d03f05bf1d1714;
			}
			else
			{
				x08a845ff18128cdb.x1cd8943d02c5342f(new CustomXmlProperty(x7e32ca845d81e3a7, x726d3ba1320c25a1, x77d03f05bf1d1714));
			}
			break;
		case x25099a8bbbd55d1c.x5ab5a058833da74f:
			if (base.x2c8c6741422a1298.BackgroundShape.WrapType == WrapType.Inline)
			{
				base.x2c8c6741422a1298.BackgroundShape.WrapType = WrapType.None;
			}
			break;
		}
	}

	[JavaThrows(true)]
	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x724e8b0eb9767138:
			xccaabd45f9158ca2(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.xc9d0b7c9b6633f23:
			switch (x153c99a852375422.x1dafd189c5465293())
			{
			case "\\xmlns":
				xb7b7b94deaea1c86 = x28fcdc775a1d069c.x16b059bd238cdf9d(x153c99a852375422.xd6f9e3c5ae6509d7());
				break;
			case "\\xmlsdttregular":
				x02cda388eff4f556 = MarkupLevel.Inline;
				break;
			case "\\xmlsdttpara":
			case "\\xmlsdttunknown":
				x02cda388eff4f556 = MarkupLevel.Block;
				break;
			case "\\xmlsdttcell":
				x02cda388eff4f556 = MarkupLevel.Cell;
				break;
			case "\\xmlsdttrow":
				x02cda388eff4f556 = MarkupLevel.Row;
				break;
			case "\\xmlattr":
				throw new InvalidOperationException("Don't know how to handle \\xmlattr.");
			case "\\xmlname":
				x28fcdc775a1d069c.xa3a0cc3e91617aca.x1914eddf1fde1228(new xbf575e106f2f2373("\\xmlname", x25099a8bbbd55d1c.x7033ba0eff1db833));
				break;
			case "\\factoidname":
				x28fcdc775a1d069c.xa3a0cc3e91617aca.x1914eddf1fde1228(new xbf575e106f2f2373("\\factoidname", x25099a8bbbd55d1c.x248bc9f31924b729));
				break;
			default:
				x28fcdc775a1d069c.x3dc950453374051a(x153c99a852375422.x1dafd189c5465293());
				break;
			}
			break;
		case x25099a8bbbd55d1c.x9a9a16139e924916:
			if (x153c99a852375422.x1dafd189c5465293() == "\\xmlattrns")
			{
				x726d3ba1320c25a1 = x28fcdc775a1d069c.x16b059bd238cdf9d(x153c99a852375422.xd6f9e3c5ae6509d7());
			}
			break;
		default:
			x88d1ce95a1b4106d(x153c99a852375422);
			break;
		case x25099a8bbbd55d1c.x1148fa1778bbfd56:
			break;
		}
	}

	private void x88d1ce95a1b4106d(x03f56b37a0050a82 x153c99a852375422)
	{
		if (!xe0d2c28e4d16b98c.x06b0e25aa6ad68a9(x153c99a852375422) && !x6ce20e3c774f843d.x06b0e25aa6ad68a9(x153c99a852375422))
		{
			x28fcdc775a1d069c.xbd5e5733680bbfc8(x153c99a852375422.x1dafd189c5465293());
		}
	}

	private void xccaabd45f9158ca2(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\bkmkcolf":
			x8408170975a63c2a.xb78c16d5f2d4f2f7 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\bkmkcoll":
			x8408170975a63c2a.x279da4adfba57f2d = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		}
	}

	[JavaThrows(true)]
	internal override void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (base.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x724e8b0eb9767138:
			x8408170975a63c2a.x54f99ef1e934e59c(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		case x25099a8bbbd55d1c.x1148fa1778bbfd56:
			xd6a7d07cb70f9923.x54f99ef1e934e59c(x153c99a852375422.x9f1a6a3451a38d10());
			break;
		case x25099a8bbbd55d1c.xe5f47478966fa764:
			x28fcdc775a1d069c.xe5f47478966fa764 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.xe728a5f2c3443632:
			x28fcdc775a1d069c.xe728a5f2c3443632 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x248bc9f31924b729:
			if (base.xffb3238a8fd59aa7.xcfc42ef22e03d2ce.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xc9d0b7c9b6633f23)
			{
				SmartTag smartTag = new SmartTag(base.x2c8c6741422a1298);
				smartTag.Element = x153c99a852375422.x9f1a6a3451a38d10();
				smartTag.Uri = xb7b7b94deaea1c86;
				x08a845ff18128cdb = smartTag.Properties;
				base.xe1410f585439c7d4.xdd43764a658cd8b8(smartTag);
			}
			break;
		case x25099a8bbbd55d1c.x7033ba0eff1db833:
			if (base.xffb3238a8fd59aa7.xcfc42ef22e03d2ce.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.xc9d0b7c9b6633f23)
			{
				CustomXmlMarkup customXmlMarkup = new CustomXmlMarkup(base.x2c8c6741422a1298, x02cda388eff4f556);
				customXmlMarkup.Element = x153c99a852375422.x9f1a6a3451a38d10();
				customXmlMarkup.Uri = xb7b7b94deaea1c86;
				x08a845ff18128cdb = customXmlMarkup.Properties;
				xa8638ccc88c0a062 = customXmlMarkup;
				base.xe1410f585439c7d4.x7006763b9e6195b1(customXmlMarkup);
			}
			break;
		case x25099a8bbbd55d1c.xc94e499bd313918e:
			x7e32ca845d81e3a7 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x7c1b658c67695fb7:
			x77d03f05bf1d1714 = x153c99a852375422.x9f1a6a3451a38d10();
			break;
		case x25099a8bbbd55d1c.x8b19047a78e496bb:
		{
			int num2 = xca004f56614e2431.x912616ee70b2d94d(x153c99a852375422.x9f1a6a3451a38d10());
			if (num2 != int.MinValue)
			{
				base.xe1410f585439c7d4.xdd60a22c09048adc(new CommentRangeStart(base.x2c8c6741422a1298, num2));
			}
			break;
		}
		case x25099a8bbbd55d1c.x8bf5fd63cbeb4d46:
		{
			int num = xca004f56614e2431.x912616ee70b2d94d(x153c99a852375422.x9f1a6a3451a38d10());
			if (num != int.MinValue)
			{
				base.xe1410f585439c7d4.x2bb903ec31d0096a(new CommentRangeEnd(base.x2c8c6741422a1298, num));
			}
			break;
		}
		default:
			xc3a6fb8513d320a3(x153c99a852375422);
			break;
		}
	}

	private void xc3a6fb8513d320a3(x03f56b37a0050a82 x153c99a852375422)
	{
		string text = x153c99a852375422.x9f1a6a3451a38d10();
		int num = 0;
		string[] array = text.Split(xe2e7f264258a58d9);
		string[] array2 = array;
		foreach (string text2 in array2)
		{
			if (text2 != "")
			{
				x52deea03ee587093(text2);
				num += text2.Length;
			}
			if (text.Length > num)
			{
				char c = text[num++];
				if (xb58cc863c6f425c8(c))
				{
					base.xe1410f585439c7d4.x27442410230d2b1f(c);
				}
			}
		}
	}

	private bool x7541ff6579836fee(char x3c4da2980d043c95)
	{
		Node lastChild = base.xe1410f585439c7d4.xc255c495fd9232ca.LastChild;
		if (lastChild == null || lastChild.NodeType != NodeType.SpecialChar)
		{
			return false;
		}
		string text = lastChild.GetText();
		if (text[0] == x3c4da2980d043c95)
		{
			lastChild.Remove();
			return true;
		}
		return false;
	}

	private bool xb58cc863c6f425c8(char x3c4da2980d043c95)
	{
		char c = x3c4da2980d043c95;
		if (c == '\u0005')
		{
			return base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x9d15246d8a1e92f8;
		}
		return true;
	}

	private void x52deea03ee587093(string xafb09e6a27bcb959)
	{
		base.xe1410f585439c7d4.x93a8c149d218a60f(xafb09e6a27bcb959);
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.xd1b40af56a8385d4:
			return new x6f13b38f12ea9b30(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.xd438a3a8968e57e1:
			return new xfdc8f878f6175822(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x9d15246d8a1e92f8:
			x7541ff6579836fee('\u0005');
			return new xa1a1c25b83cc6510(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x69d28a4aeef83a6f:
			return new x2646ecbecee87fe6(x28fcdc775a1d069c, x7541ff6579836fee('\u0002'));
		case x25099a8bbbd55d1c.xa9993ed2e0c64574:
			return x92e9ca271095fc22();
		case x25099a8bbbd55d1c.x0bd1211c8c0ee25f:
			return x92e9ca271095fc22(new GroupShape(base.x2c8c6741422a1298));
		case x25099a8bbbd55d1c.x7f4d496937f8c24c:
			return x4cd1606f4912152b();
		case x25099a8bbbd55d1c.x71d39fdf56861cca:
			return new xc201253ba36819ef(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x9256a6c338f6cb6c:
			return new x9b74bc21072e1eb4(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x1f66870c9a2c74a4:
			return new xaa8e066abda92f6a(x28fcdc775a1d069c, isOmitPageNumbers: false);
		case x25099a8bbbd55d1c.xa4008c69a7504f0b:
			return new xaa8e066abda92f6a(x28fcdc775a1d069c, isOmitPageNumbers: true);
		case x25099a8bbbd55d1c.xb71d01e7dfce7552:
			return new x1800ef79ad3084c8(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x724e8b0eb9767138:
		case x25099a8bbbd55d1c.x1148fa1778bbfd56:
		case x25099a8bbbd55d1c.xe5f47478966fa764:
		case x25099a8bbbd55d1c.xe728a5f2c3443632:
		case x25099a8bbbd55d1c.x8b19047a78e496bb:
		case x25099a8bbbd55d1c.x8bf5fd63cbeb4d46:
		case x25099a8bbbd55d1c.xe10ebc334117c0e2:
		case x25099a8bbbd55d1c.x603f0fb008b78869:
		case x25099a8bbbd55d1c.xc9d0b7c9b6633f23:
		case x25099a8bbbd55d1c.x1765dc44848570d6:
		case x25099a8bbbd55d1c.x248bc9f31924b729:
		case x25099a8bbbd55d1c.x7033ba0eff1db833:
		case x25099a8bbbd55d1c.x9a9a16139e924916:
		case x25099a8bbbd55d1c.xc94e499bd313918e:
		case x25099a8bbbd55d1c.x7c1b658c67695fb7:
			return this;
		case x25099a8bbbd55d1c.x54652a7b53727ce9:
		case x25099a8bbbd55d1c.x52642f91ccdeeb35:
			return new x5d1232981a45ab99(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x9c4de0778fd2688e:
		case x25099a8bbbd55d1c.xa665a9c85df19cc1:
		case x25099a8bbbd55d1c.x278a75a7b5b21b1e:
		case x25099a8bbbd55d1c.x5a1ada856267b1b9:
			return new x085056bea47ae474(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x6a8244bb7ecc4905:
			return new x304639ab40e89271(x28fcdc775a1d069c);
		case x25099a8bbbd55d1c.x106d5cf266c05fe5:
		case x25099a8bbbd55d1c.x3a8ea104579f33dd:
		case x25099a8bbbd55d1c.xd5120223ff7c774b:
		case x25099a8bbbd55d1c.x619d737e24cc495c:
		case x25099a8bbbd55d1c.x70e3108c63609f9e:
		case x25099a8bbbd55d1c.x82962f6bb1451ce5:
		case x25099a8bbbd55d1c.x0b17118b3159159e:
		case x25099a8bbbd55d1c.xb32ddc79f209b771:
		case x25099a8bbbd55d1c.x12fc2571922fe274:
		case x25099a8bbbd55d1c.x0f22c92bec862cb0:
		case x25099a8bbbd55d1c.x9287475b6f65d3c9:
			return new x74840b7c92907a2c(x28fcdc775a1d069c);
		default:
			return null;
		}
	}

	private x77fb5b1d5c73757b x92e9ca271095fc22()
	{
		x317be79405176667 = new Shape(base.x2c8c6741422a1298);
		x25099a8bbbd55d1c x3146d638ec = base.x1a55de3a01c1c82d.x3146d638ec378671;
		if (x3146d638ec == x25099a8bbbd55d1c.x5ab5a058833da74f)
		{
			base.x2c8c6741422a1298.xffc75a489655380b(x317be79405176667);
			return new x7210e80256b3610c(x28fcdc775a1d069c, x317be79405176667, shouldEndShape: true);
		}
		return x92e9ca271095fc22(x317be79405176667);
	}

	private x77fb5b1d5c73757b x92e9ca271095fc22(ShapeBase x5770cdefd8931aa9)
	{
		base.xe1410f585439c7d4.xa00b7e8964d655b2(x5770cdefd8931aa9);
		return new x7210e80256b3610c(x28fcdc775a1d069c, x5770cdefd8931aa9, shouldEndShape: true);
	}

	private x77fb5b1d5c73757b x4cd1606f4912152b()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 != x25099a8bbbd55d1c.xa9993ed2e0c64574 && base.x1a55de3a01c1c82d.x3146d638ec378671 != x25099a8bbbd55d1c.x0bd1211c8c0ee25f)
		{
			x317be79405176667 = new Shape(base.x2c8c6741422a1298);
			x317be79405176667.x88d1b78392d1a0ab(ShapeType.Image);
			x317be79405176667.WrapType = WrapType.Inline;
			base.xe1410f585439c7d4.xa00b7e8964d655b2(x317be79405176667);
		}
		return new xc71a5c7f64b2230d(x28fcdc775a1d069c, x317be79405176667, shouldEndShape: true);
	}
}
