using System.IO;
using System.Text;

namespace x2182451cabb5c30d;

internal class xa373bfe0feb3bdb4 : x793a0d37961cea91
{
	private int x023c308f3fe07673;

	private Encoding xcce637b6f486a407;

	internal xa373bfe0feb3bdb4(Stream stream)
		: base(stream)
	{
		x1e59773e12a1edd8(1252);
	}

	internal void x1e59773e12a1edd8(int xc1690d3515e1ed6c)
	{
		if (xc1690d3515e1ed6c != x023c308f3fe07673)
		{
			xcce637b6f486a407 = Encoding.GetEncoding(xc1690d3515e1ed6c);
			x023c308f3fe07673 = xc1690d3515e1ed6c;
		}
	}

	internal override void xd3d72812bb7aaf65()
	{
		base.xd3d72812bb7aaf65();
		switch (base.xd420ac3415caa02b.x77dc43988eaceb1c)
		{
		case xe47a4d4f9d1aa906.x08c5d9f4b0653c8d:
			base.xd420ac3415caa02b.xadbb31d0e87f1677(xcce637b6f486a407);
			break;
		case xe47a4d4f9d1aa906.xbb3b746e67ad7684:
			xcd6bf286ee0d6715();
			break;
		}
	}

	private void xcd6bf286ee0d6715()
	{
		switch (base.xd420ac3415caa02b.x1dafd189c5465293())
		{
		case "\\u":
			base.xd420ac3415caa02b.xae40f82718c98fb1((char)base.xd420ac3415caa02b.xd6f9e3c5ae6509d7());
			break;
		case "\\page":
			x4899f2d3188b5eb0('\f');
			break;
		case "\\column":
			x4899f2d3188b5eb0('\u000e');
			break;
		case "\\line":
			x4899f2d3188b5eb0('\v');
			break;
		case "\\tab":
			x4899f2d3188b5eb0('\t');
			break;
		case "\\emdash":
			x4899f2d3188b5eb0('—');
			break;
		case "\\endash":
			x4899f2d3188b5eb0('–');
			break;
		case "\\emspace":
			x4899f2d3188b5eb0('\u2003');
			break;
		case "\\enspace":
			x4899f2d3188b5eb0('\u2002');
			break;
		case "\\qmspace":
			x4899f2d3188b5eb0('\u2005');
			break;
		case "\\bullet":
			x4899f2d3188b5eb0('•');
			break;
		case "\\lquote":
			x4899f2d3188b5eb0('‘');
			break;
		case "\\rquote":
			x4899f2d3188b5eb0('’');
			break;
		case "\\ldblquote":
			x4899f2d3188b5eb0('“');
			break;
		case "\\rdblquote":
			x4899f2d3188b5eb0('”');
			break;
		case "\\~":
			x4899f2d3188b5eb0('\u00a0');
			break;
		case "\\-":
			x4899f2d3188b5eb0('\u001f');
			break;
		case "\\_":
			x4899f2d3188b5eb0('\u001e');
			break;
		case "\\\\":
			x4899f2d3188b5eb0('\\');
			break;
		case "\\{":
			x4899f2d3188b5eb0('{');
			break;
		case "\\}":
			x4899f2d3188b5eb0('}');
			break;
		case "\\:":
			x4899f2d3188b5eb0(':');
			break;
		case "\\ltrmark":
			x4899f2d3188b5eb0('\u200e');
			break;
		case "\\rtlmark":
			x4899f2d3188b5eb0('\u200f');
			break;
		case "\\zwbo":
			x4899f2d3188b5eb0('\u200c');
			break;
		case "\\zwnbo":
			x4899f2d3188b5eb0('\u200d');
			break;
		case "\\zwj":
			x4899f2d3188b5eb0('\ufeff');
			break;
		case "\\zwnj":
			x4899f2d3188b5eb0('\u200b');
			break;
		case "\\|":
			x4899f2d3188b5eb0('\\');
			break;
		case "\\sectnum":
			x4899f2d3188b5eb0('\f');
			break;
		case "\\chftn":
			x4899f2d3188b5eb0('\u0002');
			break;
		case "\\chatn":
			x4899f2d3188b5eb0('\u0005');
			break;
		case "\\chftnsep":
			x4899f2d3188b5eb0('\u0003');
			break;
		case "\\chftnsepc":
			x4899f2d3188b5eb0('\u0004');
			break;
		case "\\'":
			break;
		}
	}

	private void x4899f2d3188b5eb0(char x3c4da2980d043c95)
	{
		base.xd420ac3415caa02b.xae40f82718c98fb1(x3c4da2980d043c95);
	}
}
