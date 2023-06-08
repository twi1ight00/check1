using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Tables;
using x556d8f9846e43329;
using x9db5f2e5af3d596e;

namespace x2182451cabb5c30d;

internal class xc768a9c7b91a7f08 : xe16295e98b4802cb
{
	private int x8a4b2265340e19c9;

	private int xa585d57f6029b38d;

	private int xa8e32a7f85200335;

	private int x7f537b5a614f69ea;

	private int x34efad5bf01c47ee;

	private int xf9779de0eb22eda1;

	private int xdebaafaf5ab19034;

	private int xf7d5585688e4fa7e;

	private int x8f0d1cc8ee9cb897;

	private PreferredWidthType x350e39933f9a6b61;

	private readonly xedb0eb766e25e0c9 x1c8acc80cbbd1019 = new xedb0eb766e25e0c9();

	private xedb0eb766e25e0c9 xedb0eb766e25e0c9
	{
		get
		{
			if (base.x28fcdc775a1d069c.xa3a0cc3e91617aca.xd44988f225497f3a != base.x28fcdc775a1d069c.xde27e91a248c4c90.xccc71d0c3837217b)
			{
				return x1c8acc80cbbd1019;
			}
			return base.x28fcdc775a1d069c.xde27e91a248c4c90.xedb0eb766e25e0c9;
		}
	}

	internal xc768a9c7b91a7f08(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	protected override bool ParseSingleToken(x03f56b37a0050a82 token)
	{
		switch (token.x1dafd189c5465293())
		{
		case "\\trowd":
			xa2a7b403588cebcd();
			break;
		case "\\lastrow":
			base.x28fcdc775a1d069c.xde27e91a248c4c90.x5fed4f8aefdd1554 = true;
			break;
		case "\\trleft":
			base.x28fcdc775a1d069c.xde27e91a248c4c90.xe02d79c539b6382d = token.xd6f9e3c5ae6509d7();
			break;
		case "\\tblind":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4340, token.xd6f9e3c5ae6509d7());
			break;
		case "\\trautofit":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4240, token.x1ad7968449b109cd());
			break;
		case "\\trhdr":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4040, true);
			break;
		case "\\trkeep":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4360, false);
			break;
		case "\\trbrdrl":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xedb0eb766e25e0c9, 4060);
			break;
		case "\\trbrdrr":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xedb0eb766e25e0c9, 4080);
			break;
		case "\\trbrdrt":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xedb0eb766e25e0c9, 4050);
			break;
		case "\\trbrdrb":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xedb0eb766e25e0c9, 4070);
			break;
		case "\\trbrdrh":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xedb0eb766e25e0c9, 4090);
			break;
		case "\\trbrdrv":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xedb0eb766e25e0c9, 4100);
			break;
		case "\\tdfrmtxtLeft":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4210, token.xd6f9e3c5ae6509d7());
			break;
		case "\\tdfrmtxtRight":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4270, token.xd6f9e3c5ae6509d7());
			break;
		case "\\tdfrmtxtTop":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4220, token.xd6f9e3c5ae6509d7());
			break;
		case "\\tdfrmtxtBottom":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4280, token.xd6f9e3c5ae6509d7());
			break;
		case "\\tabsnoovrlp":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4350, !token.x1ad7968449b109cd());
			break;
		case "\\ltrrow":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4380, false);
			break;
		case "\\rtlrow":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4380, true);
			break;
		case "\\trgaph":
			xedb0eb766e25e0c9.xcad2e59522947ede = token.xd6f9e3c5ae6509d7();
			xedb0eb766e25e0c9.x41c99cca24bc80be = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trpaddl":
			x8a4b2265340e19c9 = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trpaddfl":
			if (token.xd6f9e3c5ae6509d7() == 3)
			{
				xedb0eb766e25e0c9.xcad2e59522947ede = x8a4b2265340e19c9;
			}
			break;
		case "\\trpaddr":
			xa585d57f6029b38d = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trpaddfr":
			if (token.xd6f9e3c5ae6509d7() == 3)
			{
				xedb0eb766e25e0c9.x41c99cca24bc80be = xa585d57f6029b38d;
			}
			break;
		case "\\trpaddt":
			xa8e32a7f85200335 = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trpaddft":
			if (token.xd6f9e3c5ae6509d7() == 3)
			{
				xedb0eb766e25e0c9.xdf2361611d684889 = xa8e32a7f85200335;
			}
			break;
		case "\\trpaddb":
			x7f537b5a614f69ea = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trpaddfb":
			if (token.xd6f9e3c5ae6509d7() == 3)
			{
				xedb0eb766e25e0c9.x425c70a737882333 = x7f537b5a614f69ea;
			}
			break;
		case "\\trspdfl":
			if (token.xd6f9e3c5ae6509d7() == 3)
			{
				xedb0eb766e25e0c9.xae20093bed1e48a8(4290, x34efad5bf01c47ee);
			}
			break;
		case "\\trspdfr":
			if (token.xd6f9e3c5ae6509d7() == 3)
			{
				xedb0eb766e25e0c9.xae20093bed1e48a8(4290, xf9779de0eb22eda1);
			}
			break;
		case "\\trspdtr":
			if (token.xd6f9e3c5ae6509d7() == 3)
			{
				xedb0eb766e25e0c9.xae20093bed1e48a8(4290, xdebaafaf5ab19034);
			}
			break;
		case "\\trspdbr":
			if (token.xd6f9e3c5ae6509d7() == 3)
			{
				xedb0eb766e25e0c9.xae20093bed1e48a8(4290, xf7d5585688e4fa7e);
			}
			break;
		case "\\trspdl":
			x34efad5bf01c47ee = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trspdr":
			xf9779de0eb22eda1 = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trspdt":
			xdebaafaf5ab19034 = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trspdb":
			xf7d5585688e4fa7e = token.xd6f9e3c5ae6509d7();
			break;
		case "\\trwWidth":
			x8f0d1cc8ee9cb897 = token.xd6f9e3c5ae6509d7();
			xedb0eb766e25e0c9.xae20093bed1e48a8(4230, PreferredWidth.x6b44e3efc21fd5b4(x350e39933f9a6b61, x8f0d1cc8ee9cb897));
			break;
		case "\\trftsWidth":
			x350e39933f9a6b61 = (PreferredWidthType)token.xd6f9e3c5ae6509d7();
			xedb0eb766e25e0c9.xae20093bed1e48a8(4230, PreferredWidth.x6b44e3efc21fd5b4(x350e39933f9a6b61, x8f0d1cc8ee9cb897));
			break;
		case "\\trwWidthA":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4260, token.xd6f9e3c5ae6509d7());
			break;
		case "\\trwWidthB":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4250, token.xd6f9e3c5ae6509d7());
			break;
		case "\\trrh":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4120, Math.Abs(token.xd6f9e3c5ae6509d7()));
			xedb0eb766e25e0c9.xae20093bed1e48a8(4110, x37cc5083abfbfb01(token.xd6f9e3c5ae6509d7()));
			break;
		case "\\tposx":
		case "\\tposnegx":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4170, token.xd6f9e3c5ae6509d7());
			break;
		case "\\tposy":
		case "\\tposnegy":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4190, token.xd6f9e3c5ae6509d7());
			break;
		case "\\ts":
		case "\\yts":
			xedb0eb766e25e0c9.xae20093bed1e48a8(4005, token.xd6f9e3c5ae6509d7());
			break;
		case "\\tbllkborder":
		case "\\tbllkshading":
		case "\\tbllkfont":
		case "\\tbllkcolor":
		case "\\tbllkbestfit":
		case "\\tbllkhdrrows":
		case "\\tbllklastrow":
		case "\\tbllkhdrcols":
		case "\\tbllklastcol":
		case "\\tbllknorowband":
		case "\\tbllknocolband":
		case "\\taprtl":
		case "\\trkeepfollow":
		case "\\trspdfb":
		case "\\trspdft":
		case "\\trpadob":
		case "\\trpadol":
		case "\\trpador":
		case "\\trpadot":
		case "\\trpadofb":
		case "\\trpadofl":
		case "\\trpadofr":
		case "\\trpadoft":
		case "\\trspob":
		case "\\trspol":
		case "\\trspor":
		case "\\trspofb":
		case "\\trspofl":
		case "\\trspofr":
		case "\\trspoft":
		case "\\tblindtype":
		case "\\trcbpat":
		case "\\trcfpat":
		case "\\trpat":
		case "\\trshdng":
		case "\\trbgbdiag":
		case "\\trbgdcross":
		case "\\trbgcross":
		case "\\trbgdkbdiag":
		case "\\trbgdkcross":
		case "\\trbgdkdcross":
		case "\\trbgdkhor":
		case "\\trbgdkvert":
		case "\\trbgfdiag":
		case "\\trbghoriz":
		case "\\trbgvert":
		case "\\clshdngraw":
		case "\\rawclbghoriz":
		case "\\rawclbgvert":
		case "\\rawclbgfdiag":
		case "\\rawclbgbdiag":
		case "\\rawclbgcross":
		case "\\rawclbgdcross":
		case "\\rawclbgdkhor":
		case "\\rawclbgdkvert":
		case "\\rawclbgdkfdiag":
		case "\\rawclbgdkbdiag":
		case "\\rawclbgdkcross":
		case "\\rawclbgdkdcross":
		case "\\clcfpatraw":
		case "\\clcbpatraw":
			base.x28fcdc775a1d069c.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, "Table style is not supported in Rtf by Aspose.Words.");
			break;
		default:
			return false;
		case "\\trftsWidthA":
		case "\\trftsWidthB":
		case "\\tposyil":
			break;
		}
		return true;
	}

	protected override bool SearchInEnums(x03f56b37a0050a82 token)
	{
		object obj = x88449d6466e04295.xb62d8f13cf83eb54(token.x1dafd189c5465293());
		if (obj != null)
		{
			xedb0eb766e25e0c9.xae20093bed1e48a8(5101, (TableAlignment)obj);
			return true;
		}
		obj = x88449d6466e04295.x8e8007ec91fc6ef6(token.x1dafd189c5465293());
		if (obj != null)
		{
			xedb0eb766e25e0c9.xae20093bed1e48a8(4180, (HorizontalAlignment)obj);
			return true;
		}
		obj = x88449d6466e04295.x6bc7d765aa7c05c7(token.x1dafd189c5465293());
		if (obj != null)
		{
			xedb0eb766e25e0c9.xae20093bed1e48a8(4200, (VerticalAlignment)obj);
			return true;
		}
		obj = x88449d6466e04295.x1349f6b2c2f5156d(token.x1dafd189c5465293());
		if (obj != null)
		{
			xedb0eb766e25e0c9.xae20093bed1e48a8(4150, (RelativeHorizontalPosition)obj);
			return true;
		}
		obj = x88449d6466e04295.xb223821a507a8658(token.x1dafd189c5465293());
		if (obj != null)
		{
			xedb0eb766e25e0c9.xae20093bed1e48a8(4160, (RelativeVerticalPosition)obj);
			return true;
		}
		return false;
	}

	private static HeightRule x37cc5083abfbfb01(int x4d5aabc7a55b12ba)
	{
		if (x4d5aabc7a55b12ba < 0)
		{
			return HeightRule.Exactly;
		}
		if (x4d5aabc7a55b12ba > 0)
		{
			return HeightRule.AtLeast;
		}
		return HeightRule.Auto;
	}

	private void xa2a7b403588cebcd()
	{
		x8a4b2265340e19c9 = 0;
		xa585d57f6029b38d = 0;
		xa8e32a7f85200335 = 0;
		x7f537b5a614f69ea = 0;
		x8f0d1cc8ee9cb897 = 0;
		base.x28fcdc775a1d069c.xde27e91a248c4c90.xc8a20a3049e15fc4(base.x28fcdc775a1d069c.xa3a0cc3e91617aca.xd44988f225497f3a);
	}
}
