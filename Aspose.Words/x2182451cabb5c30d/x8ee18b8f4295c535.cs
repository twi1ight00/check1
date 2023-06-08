using Aspose.Words;
using x2845e7a1a7dc898b;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using xe5b37aee2c2a4d4e;
using xf9a9481c3f63a419;

namespace x2182451cabb5c30d;

internal class x8ee18b8f4295c535 : xe16295e98b4802cb
{
	private readonly x59a1e7b7667e1e09 x923843b01e6d833c;

	private xc1b2bac943a0f541 xc770e064ab9a43d5;

	private xc1b2bac943a0f541 xb97c454b6c347b3f;

	private x84d41ac121232475 x40feabaaa5810d68;

	private xeedad81aaed42a76 xeedad81aaed42a76 => xe5b3438572ead790.xeedad81aaed42a76;

	private x59a1e7b7667e1e09 xe5b3438572ead790
	{
		get
		{
			if (x923843b01e6d833c == null)
			{
				return base.x28fcdc775a1d069c.xa3a0cc3e91617aca.xffb3238a8fd59aa7;
			}
			return x923843b01e6d833c;
		}
	}

	private Shading x554aca059bdf6d48 => x4e5da2e11272a820.x55d54ac049a678c6(xeedad81aaed42a76, 370);

	private x52108cac3d36b123 xffb3238a8fd59aa7 => base.x28fcdc775a1d069c.xa3a0cc3e91617aca.xffb3238a8fd59aa7;

	internal x8ee18b8f4295c535(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal x8ee18b8f4295c535(xe5e546ef5f0503b2 context, x59a1e7b7667e1e09 attrProvider)
		: base(context)
	{
		x923843b01e6d833c = attrProvider;
	}

	protected override bool ParseSingleToken(x03f56b37a0050a82 token)
	{
		switch (token.x1dafd189c5465293())
		{
		case "\\plain":
			xa2a7b403588cebcd();
			break;
		case "\\animtext":
			xeedad81aaed42a76.xae20093bed1e48a8(310, (TextEffect)token.xd6f9e3c5ae6509d7());
			break;
		case "\\caps":
			xeedad81aaed42a76.xae20093bed1e48a8(120, token.xc55827845a964d45());
			break;
		case "\\charscalex":
			xeedad81aaed42a76.xae20093bed1e48a8(290, token.xd6f9e3c5ae6509d7());
			break;
		case "\\embo":
			xeedad81aaed42a76.xae20093bed1e48a8(170, token.xc55827845a964d45());
			break;
		case "\\impr":
			xeedad81aaed42a76.xae20093bed1e48a8(180, token.xc55827845a964d45());
			break;
		case "\\noproof":
			xeedad81aaed42a76.xae20093bed1e48a8(440, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
			break;
		case "\\outl":
			xeedad81aaed42a76.xae20093bed1e48a8(90, token.xc55827845a964d45());
			break;
		case "\\scaps":
			xeedad81aaed42a76.xae20093bed1e48a8(110, token.xc55827845a964d45());
			break;
		case "\\shad":
			xeedad81aaed42a76.xae20093bed1e48a8(100, token.xc55827845a964d45());
			break;
		case "\\v":
			xeedad81aaed42a76.xae20093bed1e48a8(130, token.xc55827845a964d45());
			break;
		case "\\webhidden":
			xeedad81aaed42a76.xae20093bed1e48a8(132, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
			break;
		case "\\cs":
			xeedad81aaed42a76.xae20093bed1e48a8(50, base.x28fcdc775a1d069c.xc9b7340b035562c6(token.xd6f9e3c5ae6509d7(), 10));
			break;
		case "\\cf":
			xeedad81aaed42a76.xae20093bed1e48a8(160, base.x28fcdc775a1d069c.x88bf28725f671e38.get_xe6d4b1b411ed94b5(token.xd6f9e3c5ae6509d7()));
			break;
		case "\\insrsid":
			xeedad81aaed42a76.xae20093bed1e48a8(40, token.xd6f9e3c5ae6509d7());
			break;
		case "\\charrsid":
			xeedad81aaed42a76.xae20093bed1e48a8(30, token.xd6f9e3c5ae6509d7());
			break;
		case "\\highlight":
			xeedad81aaed42a76.xae20093bed1e48a8(20, base.x28fcdc775a1d069c.x88bf28725f671e38.get_xe6d4b1b411ed94b5(token.xd6f9e3c5ae6509d7()));
			break;
		case "\\ulc":
			xeedad81aaed42a76.xae20093bed1e48a8(450, base.x28fcdc775a1d069c.x88bf28725f671e38.get_xe6d4b1b411ed94b5(token.xd6f9e3c5ae6509d7()));
			break;
		case "\\strike":
			xeedad81aaed42a76.xae20093bed1e48a8(80, token.xc55827845a964d45());
			break;
		case "\\striked":
			xeedad81aaed42a76.xae20093bed1e48a8(300, token.xc55827845a964d45());
			break;
		case "\\kerning":
			xeedad81aaed42a76.xae20093bed1e48a8(220, token.xd6f9e3c5ae6509d7());
			break;
		case "\\lbr":
			xeedad81aaed42a76.xae20093bed1e48a8(45, (xb298f2d4a3b9607a)token.xd6f9e3c5ae6509d7());
			break;
		case "\\chbrdr":
			base.x28fcdc775a1d069c.x2cf1761602871e10(xeedad81aaed42a76, 360);
			break;
		case "\\sub":
			xeedad81aaed42a76.xae20093bed1e48a8(210, x7af53bbecc5ccdd5.x1b1f4712a1a0c38c);
			break;
		case "\\super":
			xeedad81aaed42a76.xae20093bed1e48a8(210, x7af53bbecc5ccdd5.xab66d68facbadf18);
			break;
		case "\\nosupersub":
			xeedad81aaed42a76.xae20093bed1e48a8(210, x7af53bbecc5ccdd5.x139412b8dea2f02b);
			break;
		case "\\ltrch":
			xffb3238a8fd59aa7.xb632b7255fb382c2.xa806e7163396d99d();
			xeedad81aaed42a76.xae20093bed1e48a8(265, x9b28b1f7f0cc963f.x12642456c7bf0815);
			break;
		case "\\rtlch":
			xffb3238a8fd59aa7.xb632b7255fb382c2.x2e8924793c89f2e9();
			xeedad81aaed42a76.xae20093bed1e48a8(265, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
			break;
		case "\\fcs":
		{
			bool flag = token.x1ad7968449b109cd();
			xffb3238a8fd59aa7.xb632b7255fb382c2.x107220b07d0a1548(flag);
			xeedad81aaed42a76.xae20093bed1e48a8(268, x9b28b1f7f0cc963f.x1e5f5c3e4c508bf0(flag));
			break;
		}
		case "\\loch":
			xffb3238a8fd59aa7.xb632b7255fb382c2.xb764d68be36a7794();
			break;
		case "\\hich":
			xffb3238a8fd59aa7.xb632b7255fb382c2.x51e1e51888390896();
			break;
		case "\\dbch":
			xffb3238a8fd59aa7.xb632b7255fb382c2.xc8502ac364533b2e();
			break;
		case "\\f":
		{
			int num3 = token.xd6f9e3c5ae6509d7();
			if (!base.x28fcdc775a1d069c.x515f532dcc4ad30e)
			{
				xffb3238a8fd59aa7.xad3f7e139bf1b10a = num3;
			}
			x799e7416bbfffcfb(num3);
			break;
		}
		case "\\af":
			x799e7416bbfffcfb(token.xd6f9e3c5ae6509d7());
			break;
		case "\\alang":
		case "\\lang":
		{
			int num2 = token.xd6f9e3c5ae6509d7();
			if (num2 == 1024)
			{
				xeedad81aaed42a76.xae20093bed1e48a8(440, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
			}
			else
			{
				xefbb42e3f84c83e5(380, 340, num2);
			}
			break;
		}
		case "\\langfe":
		{
			int num = token.xd6f9e3c5ae6509d7();
			if (num == 1024)
			{
				xeedad81aaed42a76.xae20093bed1e48a8(440, x9b28b1f7f0cc963f.xbbad6bbe73c6b1dc);
			}
			else
			{
				xeedad81aaed42a76.xae20093bed1e48a8(390, num);
			}
			break;
		}
		case "\\langnp":
			xefbb42e3f84c83e5(380, 340, token.xd6f9e3c5ae6509d7());
			break;
		case "\\langfenp":
			xeedad81aaed42a76.xae20093bed1e48a8(390, token.xd6f9e3c5ae6509d7());
			break;
		case "\\fs":
		case "\\afs":
			xeedad81aaed42a76.xae20093bed1e48a8(xffb3238a8fd59aa7.xb632b7255fb382c2.xcd1cf2e763ca917e ? 350 : 190, token.xd6f9e3c5ae6509d7());
			break;
		case "\\b":
		case "\\ab":
			xeedad81aaed42a76.xae20093bed1e48a8(xffb3238a8fd59aa7.xb632b7255fb382c2.xcd1cf2e763ca917e ? 250 : 60, token.xc55827845a964d45());
			break;
		case "\\i":
		case "\\ai":
			xeedad81aaed42a76.xae20093bed1e48a8(xffb3238a8fd59aa7.xb632b7255fb382c2.xcd1cf2e763ca917e ? 260 : 70, token.xc55827845a964d45());
			break;
		case "\\up":
			xeedad81aaed42a76.xae20093bed1e48a8(200, token.xd6f9e3c5ae6509d7());
			break;
		case "\\dn":
			xeedad81aaed42a76.xae20093bed1e48a8(200, -token.xd6f9e3c5ae6509d7());
			break;
		case "\\expnd":
			xeedad81aaed42a76.xae20093bed1e48a8(150, xa0d3611565b2a1f2.xcaea8b7a31c4f21f(token.xd6f9e3c5ae6509d7()));
			break;
		case "\\expndtw":
			xeedad81aaed42a76.xae20093bed1e48a8(150, token.xd6f9e3c5ae6509d7());
			break;
		case "\\chshdng":
			x4e5da2e11272a820.x8afbf301967d3fb1(x554aca059bdf6d48, token);
			break;
		case "\\chcbpat":
			x4e5da2e11272a820.x959d3c962e8ead5a(base.x28fcdc775a1d069c, x554aca059bdf6d48, token);
			break;
		case "\\chcfpat":
			x4e5da2e11272a820.xe86c81ecd859a448(base.x28fcdc775a1d069c, x554aca059bdf6d48, token);
			break;
		case "\\revised":
			xc770e064ab9a43d5 = new xc1b2bac943a0f541(x91bb72ac77aa7230.xf059562f878b500e);
			xeedad81aaed42a76.xae20093bed1e48a8(14, xc770e064ab9a43d5);
			break;
		case "\\revauth":
			xc770e064ab9a43d5.xb063bbfcfeade526 = base.x28fcdc775a1d069c.x2086e697b5620586.get_xe6d4b1b411ed94b5(token.xd6f9e3c5ae6509d7());
			break;
		case "\\revdttm":
			xc770e064ab9a43d5.x242851e6278ed355 = xa0d3611565b2a1f2.x9a175459d1b055a7(token.xd6f9e3c5ae6509d7());
			break;
		case "\\deleted":
			xb97c454b6c347b3f = new xc1b2bac943a0f541(x91bb72ac77aa7230.x1f522a512716a2ae);
			xeedad81aaed42a76.xae20093bed1e48a8(12, xb97c454b6c347b3f);
			break;
		case "\\revauthdel":
			xb97c454b6c347b3f.xb063bbfcfeade526 = base.x28fcdc775a1d069c.x2086e697b5620586.get_xe6d4b1b411ed94b5(token.xd6f9e3c5ae6509d7());
			break;
		case "\\revdttmdel":
			xb97c454b6c347b3f.x242851e6278ed355 = xa0d3611565b2a1f2.x9a175459d1b055a7(token.xd6f9e3c5ae6509d7());
			break;
		case "\\accnone":
		case "\\accdot":
		case "\\acccircle":
		case "\\acccomma":
		case "\\accunderdot":
			xeedad81aaed42a76.xae20093bed1e48a8(770, x394368855a08b8ce.xb17c9eac2ec5751b(token.x1dafd189c5465293()));
			break;
		case "\\horzvert":
		{
			xf80d6ac0b6a56f39 xf80d6ac0b6a56f2 = new xf80d6ac0b6a56f39();
			xf80d6ac0b6a56f2.x61c108cc44ef385a = true;
			xf80d6ac0b6a56f2.x8983dff00ce7e17a = token.xd6f9e3c5ae6509d7() != 0;
			xeedad81aaed42a76.xae20093bed1e48a8(780, xf80d6ac0b6a56f2);
			break;
		}
		case "\\twoinone":
		{
			xf80d6ac0b6a56f39 xf80d6ac0b6a56f = new xf80d6ac0b6a56f39();
			xf80d6ac0b6a56f.xcc75e504ef58a07f = true;
			xf80d6ac0b6a56f.x69ec038defa753a8 = (x69ec038defa753a8)token.xd6f9e3c5ae6509d7();
			xeedad81aaed42a76.xae20093bed1e48a8(780, xf80d6ac0b6a56f);
			break;
		}
		case "\\ptabldot":
		case "\\ptablminus":
		case "\\ptabluscore":
		case "\\ptablmdot":
		case "\\ptablnone":
			x40feabaaa5810d68 = xa0d3611565b2a1f2.xbe670088e64558c9(token.x1dafd189c5465293());
			break;
		case "\\pmartabql":
		case "\\pmartabqc":
		case "\\pmartabqr":
		case "\\pindtabql":
		case "\\pindtabqc":
		case "\\pindtabqr":
			x5ea3f81617f9c786(token.x1dafd189c5465293());
			break;
		case "\\mnor":
			xeedad81aaed42a76.x60c60b1f72126a4c = true;
			break;
		case "\\mscr":
			xeedad81aaed42a76.x1380d412169e361b = (x1380d412169e361b)token.xd6f9e3c5ae6509d7();
			break;
		case "\\msty":
			xeedad81aaed42a76.x65251a26aa8f6af1 = (x65251a26aa8f6af1)token.xd6f9e3c5ae6509d7();
			break;
		case "\\crauth":
			base.x28fcdc775a1d069c.x3c5cf62121f6ba42 = base.x28fcdc775a1d069c.x2086e697b5620586.get_xe6d4b1b411ed94b5(token.xd6f9e3c5ae6509d7());
			break;
		case "\\crdate":
			base.x28fcdc775a1d069c.x125b1f8e1ea06d76 = xa0d3611565b2a1f2.x9a175459d1b055a7(token.xd6f9e3c5ae6509d7());
			break;
		default:
			return x9b55a22443f7470d(token);
		}
		return true;
	}

	private void xefbb42e3f84c83e5(int xba08ce632055a1d9, int xce8d3b2118f18fa8, int xbcea506a33cf9111)
	{
		if (x426f159f8d17c613(xbcea506a33cf9111))
		{
			xffb3238a8fd59aa7.xb632b7255fb382c2.x2e8924793c89f2e9();
		}
		xeedad81aaed42a76.xae20093bed1e48a8(xffb3238a8fd59aa7.xb632b7255fb382c2.xcd1cf2e763ca917e ? xce8d3b2118f18fa8 : xba08ce632055a1d9, xbcea506a33cf9111);
	}

	private bool x426f159f8d17c613(int xc1690d3515e1ed6c)
	{
		if (xc1690d3515e1ed6c != 1037)
		{
			return xc1690d3515e1ed6c == 1085;
		}
		return true;
	}

	private void x5ea3f81617f9c786(string x13d4cb8d1bd20347)
	{
		AbsolutePositionTab absolutePositionTab = new AbsolutePositionTab(base.x28fcdc775a1d069c.x2c8c6741422a1298, xeedad81aaed42a76);
		absolutePositionTab.x9ba359ff37a3a63b = xa0d3611565b2a1f2.x1cbe436dac074235(x13d4cb8d1bd20347);
		absolutePositionTab.x7073c129de8d5e65 = xa0d3611565b2a1f2.x4444feaf6a1a4708(x13d4cb8d1bd20347);
		absolutePositionTab.x312ff11290b951a5 = x40feabaaa5810d68;
		base.x28fcdc775a1d069c.xe1410f585439c7d4.xfc1c33c63bf625fc(absolutePositionTab);
		x40feabaaa5810d68 = x84d41ac121232475.x4d0b9d4447ba7566;
	}

	private bool x9b55a22443f7470d(x03f56b37a0050a82 x153c99a852375422)
	{
		bool result = true;
		switch (base.x28fcdc775a1d069c.xa3a0cc3e91617aca.xffb3238a8fd59aa7.x1a55de3a01c1c82d.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x488a5f49abd86bb8:
		{
			x488a5f49abd86bb8 x488a5f49abd86bb = new x488a5f49abd86bb8();
			x488a5f49abd86bb.x9ba359ff37a3a63b = xca004f56614e2431.x912616ee70b2d94d(x153c99a852375422.x9f1a6a3451a38d10().Trim());
			base.x28fcdc775a1d069c.xa3a0cc3e91617aca.xcfc42ef22e03d2ce.xeedad81aaed42a76.x488a5f49abd86bb8 = x488a5f49abd86bb;
			break;
		}
		default:
			result = false;
			break;
		case x25099a8bbbd55d1c.x6efe0dc00696056d:
			break;
		}
		return result;
	}

	private void x799e7416bbfffcfb(int x3d2dde7c72e020a4)
	{
		string xbcea506a33cf = base.x28fcdc775a1d069c.x241e429ca27700bc(x3d2dde7c72e020a4);
		switch (xffb3238a8fd59aa7.xb632b7255fb382c2.xad98d2ceb0921f0a)
		{
		case xe9cfb7994474c363.x175297738c8b8d1e:
			xeedad81aaed42a76.xae20093bed1e48a8(230, xbcea506a33cf);
			xeedad81aaed42a76.xae20093bed1e48a8(400, x000f21cbda739311.x22a0fbb9469b35e1);
			break;
		case xe9cfb7994474c363.xd52f550f8cfc3073:
			xeedad81aaed42a76.xae20093bed1e48a8(240, xbcea506a33cf);
			xeedad81aaed42a76.xae20093bed1e48a8(400, x000f21cbda739311.x22a0fbb9469b35e1);
			break;
		case xe9cfb7994474c363.xd4e922ceeed89b74:
			xeedad81aaed42a76.xae20093bed1e48a8(270, xbcea506a33cf);
			xeedad81aaed42a76.xae20093bed1e48a8(400, x000f21cbda739311.xd4e922ceeed89b74);
			break;
		case xe9cfb7994474c363.x7c8c2d13fa5b79fa:
			xeedad81aaed42a76.xae20093bed1e48a8(235, xbcea506a33cf);
			xeedad81aaed42a76.xae20093bed1e48a8(400, x000f21cbda739311.x7c8c2d13fa5b79fa);
			break;
		default:
			xeedad81aaed42a76.xae20093bed1e48a8(230, xbcea506a33cf);
			xeedad81aaed42a76.xae20093bed1e48a8(240, xbcea506a33cf);
			break;
		}
	}

	protected override bool SearchInEnums(x03f56b37a0050a82 token)
	{
		object obj = x394368855a08b8ce.xbc7564cadceec1c0(token.x1dafd189c5465293(), xeedad81aaed42a76.x9bd0b4c41657450b(140), token.x1ad7968449b109cd());
		if (obj != null)
		{
			xeedad81aaed42a76.xae20093bed1e48a8(140, obj);
			return true;
		}
		obj = x394368855a08b8ce.x2e021ec350b917d6(token.x1dafd189c5465293());
		if (obj != null)
		{
			x4e5da2e11272a820.x64e0c305de9ff291(x554aca059bdf6d48, (TextureIndex)obj);
			return true;
		}
		return false;
	}

	private void xa2a7b403588cebcd()
	{
		xeedad81aaed42a76.ClearAttrs();
		xffb3238a8fd59aa7.x2ddab4ad01316604();
		xeedad81aaed42a76.xae20093bed1e48a8(190, 24);
		xeedad81aaed42a76.xae20093bed1e48a8(350, 24);
		xffb3238a8fd59aa7.xb632b7255fb382c2.x74f5a1ef3906e23c();
		x40feabaaa5810d68 = x84d41ac121232475.x4d0b9d4447ba7566;
	}
}
