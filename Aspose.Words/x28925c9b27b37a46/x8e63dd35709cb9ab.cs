using System;
using Aspose.Words;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x9db5f2e5af3d596e;

namespace x28925c9b27b37a46;

internal class x8e63dd35709cb9ab
{
	private readonly DocumentBuilder x800085dd555f7711;

	private xcf0e7d2892f7a07d xc2aa684fb5c5a694;

	private Table x4c2699b9ce14a4fb;

	private Row xce99a1a8858ede43;

	internal xcf0e7d2892f7a07d xcf0e7d2892f7a07d => xc2aa684fb5c5a694;

	internal x8e63dd35709cb9ab(DocumentBuilder builder)
	{
		if (builder == null)
		{
			throw new ArgumentOutOfRangeException("builder");
		}
		x800085dd555f7711 = builder;
	}

	internal Table x35ee6077b3c26c9f()
	{
		if (xc2aa684fb5c5a694 != 0)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("pghhkiohejfibjmipidjbjkjkdbkkiikiipkchglainlphemiclmggcnccjndhaonfholfoocgfpifmpabdagfkaifbbhaibifpbjegchencoeedipkdiecegejeadafaehfocofepeg", 341538604)));
		}
		if (!x800085dd555f7711.IsAtStartOfParagraph)
		{
			x800085dd555f7711.InsertParagraph();
		}
		x4c2699b9ce14a4fb = new Table(x800085dd555f7711.Document);
		x800085dd555f7711.xd6a6fa519f3374ab(x4c2699b9ce14a4fb);
		x800085dd555f7711.xf466d4a1b1e62ec8(x0d0bfe1511f626d9: false);
		xc2aa684fb5c5a694 = xcf0e7d2892f7a07d.x2d6a2917055d6f8b;
		return x4c2699b9ce14a4fb;
	}

	internal Table xee69ee8848255726()
	{
		if (xc2aa684fb5c5a694 == xcf0e7d2892f7a07d.x2f05f7a24ceff75c)
		{
			x2a78a52ede7f4385();
		}
		if (xc2aa684fb5c5a694 == xcf0e7d2892f7a07d.xeb397955ada4f074)
		{
			xbdbbc98113b6b783();
		}
		if (xc2aa684fb5c5a694 != xcf0e7d2892f7a07d.x2d6a2917055d6f8b)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ochpjeopdffaafmaoedbafkbjpacldicbepcedgdnomdlceehokeidcfccjfacaghchgnbogfnehlbmhnbdimmjinbbjoaijmapjdbgknlmknaellallfpbmfajmdppmjlgn", 646575851)));
		}
		Paragraph x41baca1d6c0c2e8e = (Paragraph)x4c2699b9ce14a4fb.xa6890a1cb2b8896e;
		x800085dd555f7711.x01b2723108ff3dfe(x41baca1d6c0c2e8e, 0);
		xc2aa684fb5c5a694 = xcf0e7d2892f7a07d.x4d0b9d4447ba7566;
		Table result = x4c2699b9ce14a4fb;
		x4c2699b9ce14a4fb = null;
		return result;
	}

	internal Row x5e3f44647fcfb8fc()
	{
		if (xc2aa684fb5c5a694 != xcf0e7d2892f7a07d.x2d6a2917055d6f8b)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("lmddgokdapbenoielopenogfgjnfgoegeolgomchmnjhlnaieihicmoiohfjnmmjhmdkmmkkchblililklpljggmklnmlkenjklnalcokfjokkapikhpcjopckfaajmagfdb", 407188360)));
		}
		Row lastRow = x4c2699b9ce14a4fb.LastRow;
		xedb0eb766e25e0c9 rowPr = ((lastRow != null) ? ((xedb0eb766e25e0c9)lastRow.xedb0eb766e25e0c9.x8b61531c8ea35b85()) : x800085dd555f7711.x79f94b97ce762fc2());
		xce99a1a8858ede43 = new Row(x800085dd555f7711.Document, rowPr);
		x4c2699b9ce14a4fb.AppendChild(xce99a1a8858ede43);
		xc2aa684fb5c5a694 = xcf0e7d2892f7a07d.xeb397955ada4f074;
		return xce99a1a8858ede43;
	}

	internal Row xbdbbc98113b6b783()
	{
		if (xc2aa684fb5c5a694 == xcf0e7d2892f7a07d.x2f05f7a24ceff75c)
		{
			x2a78a52ede7f4385();
		}
		if (xc2aa684fb5c5a694 != xcf0e7d2892f7a07d.xeb397955ada4f074)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hpidcbaembhejboehbffjbmfcmcgeakgkabhnphhglohepfialmippdjjpkjopbkekikkopkmoglljnlmoemnnlmlncncojnmiaomnhoknooemfpenmpcmdaiika", 1888499892)));
		}
		x800085dd555f7711.xf466d4a1b1e62ec8(x0d0bfe1511f626d9: true);
		xc2aa684fb5c5a694 = xcf0e7d2892f7a07d.x2d6a2917055d6f8b;
		Row result = xce99a1a8858ede43;
		xce99a1a8858ede43 = null;
		return result;
	}

	internal Cell xcbc713eb2e22657d()
	{
		if (xc2aa684fb5c5a694 != xcf0e7d2892f7a07d.xeb397955ada4f074)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mfdchhkcbibdohidmhpdohgehcnehheffhlfpfcgngjgmgahfbhhdfohpafipemioedjcfkjpebkaaikgepkieglhpmlieemjdlmhdcnodjniopnidhogdooacfpadmpobdaeoja", 1564877593)));
		}
		Cell cell = new Cell(x800085dd555f7711.Document, x800085dd555f7711.x292670b7c408ce0a());
		xce99a1a8858ede43.AppendChild(cell);
		Paragraph paragraph = new Paragraph(x800085dd555f7711.Document, x800085dd555f7711.x87c38d4df0b94981(), x800085dd555f7711.xdbd6535b15eacda9());
		cell.AppendChild(paragraph);
		x800085dd555f7711.x01b2723108ff3dfe(paragraph, 0);
		xc2aa684fb5c5a694 = xcf0e7d2892f7a07d.x2f05f7a24ceff75c;
		return cell;
	}

	internal void x2a78a52ede7f4385()
	{
		if (xc2aa684fb5c5a694 != xcf0e7d2892f7a07d.x2f05f7a24ceff75c)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("fjkealbfklifhlpfflgghlngagehcklhikciljjiefajcjhjoeojoifknimkbjdloiklpdbmfiimhipmgdgnhinniheoghlonhcphcjphhaafhhapfoapgfbnfmbdcdc", 1226656338)));
		}
		xc2aa684fb5c5a694 = xcf0e7d2892f7a07d.xeb397955ada4f074;
	}
}
