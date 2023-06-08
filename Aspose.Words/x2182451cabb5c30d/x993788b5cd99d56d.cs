using System;
using System.Collections;
using System.Text;
using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x993788b5cd99d56d : xe16295e98b4802cb
{
	private TabStop xfe0dcbd6c719ddb1 = new TabStop();

	private readonly x59a1e7b7667e1e09 x923843b01e6d833c;

	private x978620a99b6d5014 x55df142229d4371d;

	private int x2522f79609327f79;

	private ArrayList x0ebdd4092389c6bf;

	private int xe1c490eeb26d97e7;

	private int x85cbdd85c7fe2ad9;

	private int x33fed098ef94b417;

	private int x5305b517809b7b9a;

	private x1a78664fa10a3755 x1a78664fa10a3755 => xe5b3438572ead790.x1a78664fa10a3755;

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

	private Shading x554aca059bdf6d48 => x4e5da2e11272a820.x55d54ac049a678c6(x1a78664fa10a3755, 1460);

	internal x993788b5cd99d56d(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	internal x993788b5cd99d56d(xe5e546ef5f0503b2 context, x59a1e7b7667e1e09 attrProvider)
		: base(context)
	{
		x923843b01e6d833c = attrProvider;
	}

	protected override bool ParseSingleToken(x03f56b37a0050a82 token)
	{
		switch (token.x1dafd189c5465293())
		{
		case "\\pard":
			xa2a7b403588cebcd();
			break;
		case "\\intbl":
			if (token.x12576604d05c627a > 0 && token.xd6f9e3c5ae6509d7() == 0)
			{
				base.x28fcdc775a1d069c.xde27e91a248c4c90.xc7ae5256463a3132();
			}
			else
			{
				base.x28fcdc775a1d069c.xde27e91a248c4c90.xb8e4673a0e9aac73();
			}
			break;
		case "\\itap":
		{
			int x8a61868fbfcf5edd = token.xd6f9e3c5ae6509d7();
			base.x28fcdc775a1d069c.xde27e91a248c4c90.x6683111c3a6459ee(x8a61868fbfcf5edd);
			break;
		}
		case "\\hyphpar":
			x1a78664fa10a3755.xae20093bed1e48a8(1410, !token.x1ad7968449b109cd());
			break;
		case "\\noline":
			x1a78664fa10a3755.xae20093bed1e48a8(1130, true);
			break;
		case "\\nowidctlpar":
			x1a78664fa10a3755.xae20093bed1e48a8(1470, false);
			break;
		case "\\nocwrap":
			x1a78664fa10a3755.xae20093bed1e48a8(1070, false);
			break;
		case "\\widctlpar":
			x1a78664fa10a3755.xae20093bed1e48a8(1470, true);
			break;
		case "\\pagebb":
			x1a78664fa10a3755.xae20093bed1e48a8(1060, true);
			break;
		case "\\sbys":
			x1a78664fa10a3755.xae20093bed1e48a8(1030, true);
			break;
		case "\\s":
			x1a78664fa10a3755.xae20093bed1e48a8(1000, base.x28fcdc775a1d069c.xc9b7340b035562c6(token.xd6f9e3c5ae6509d7(), 0));
			break;
		case "\\fi":
			x1a78664fa10a3755.xae20093bed1e48a8(1170, token.xd6f9e3c5ae6509d7());
			break;
		case "\\sb":
			x1a78664fa10a3755.xae20093bed1e48a8(1200, token.xd6f9e3c5ae6509d7());
			break;
		case "\\sa":
			x1a78664fa10a3755.xae20093bed1e48a8(1220, token.xd6f9e3c5ae6509d7());
			break;
		case "\\lisb":
			x1a78664fa10a3755.xae20093bed1e48a8(1205, token.xd6f9e3c5ae6509d7());
			break;
		case "\\lisa":
			x1a78664fa10a3755.xae20093bed1e48a8(1225, token.xd6f9e3c5ae6509d7());
			break;
		case "\\culi":
			x1a78664fa10a3755.xae20093bed1e48a8(1165, token.xd6f9e3c5ae6509d7());
			break;
		case "\\curi":
			x1a78664fa10a3755.xae20093bed1e48a8(1155, token.xd6f9e3c5ae6509d7());
			break;
		case "\\cufi":
			x1a78664fa10a3755.xae20093bed1e48a8(1175, token.xd6f9e3c5ae6509d7());
			break;
		case "\\adjustright":
			x1a78664fa10a3755.xae20093bed1e48a8(1270, true);
			break;
		case "\\sbauto":
			x1a78664fa10a3755.xae20093bed1e48a8(1210, token.x1ad7968449b109cd());
			break;
		case "\\saauto":
			x1a78664fa10a3755.xae20093bed1e48a8(1230, token.x1ad7968449b109cd());
			break;
		case "\\nosnaplinegrid":
			x1a78664fa10a3755.xae20093bed1e48a8(1260, false);
			break;
		case "\\nooverflow":
			x1a78664fa10a3755.xae20093bed1e48a8(1090, false);
			break;
		case "\\nowwrap":
			x1a78664fa10a3755.xae20093bed1e48a8(1080, false);
			break;
		case "\\aspalpha":
			x1a78664fa10a3755.xae20093bed1e48a8(1240, true);
			break;
		case "\\aspnum":
			x1a78664fa10a3755.xae20093bed1e48a8(1250, true);
			break;
		case "\\toplinepunct":
			x1a78664fa10a3755.xae20093bed1e48a8(1100, true);
			break;
		case "\\pararsid":
			x1a78664fa10a3755.xae20093bed1e48a8(1580, token.xd6f9e3c5ae6509d7());
			break;
		case "\\keep":
			x1a78664fa10a3755.xae20093bed1e48a8(1040, true);
			break;
		case "\\keepn":
			x1a78664fa10a3755.xae20093bed1e48a8(1050, true);
			break;
		case "\\brdrl":
			base.x28fcdc775a1d069c.x2cf1761602871e10(x1a78664fa10a3755, 1360);
			break;
		case "\\brdrr":
			base.x28fcdc775a1d069c.x2cf1761602871e10(x1a78664fa10a3755, 1380);
			break;
		case "\\brdrt":
			base.x28fcdc775a1d069c.x2cf1761602871e10(x1a78664fa10a3755, 1350);
			break;
		case "\\brdrb":
			base.x28fcdc775a1d069c.x2cf1761602871e10(x1a78664fa10a3755, 1370);
			break;
		case "\\brdrbtw":
			base.x28fcdc775a1d069c.x2cf1761602871e10(x1a78664fa10a3755, 1390);
			break;
		case "\\brdrbar":
			base.x28fcdc775a1d069c.x2cf1761602871e10(x1a78664fa10a3755, 1400);
			break;
		case "\\ls":
			x1a78664fa10a3755.xae20093bed1e48a8(1120, token.xd6f9e3c5ae6509d7());
			break;
		case "\\ilvl":
			x1a78664fa10a3755.xae20093bed1e48a8(1110, token.xd6f9e3c5ae6509d7());
			break;
		case "\\dropcapt":
			x1a78664fa10a3755.xae20093bed1e48a8(1440, (DropCapPosition)token.xd6f9e3c5ae6509d7());
			break;
		case "\\dropcapli":
			x1a78664fa10a3755.xae20093bed1e48a8(1450, token.xd6f9e3c5ae6509d7());
			break;
		case "\\contextualspace":
			x1a78664fa10a3755.xae20093bed1e48a8(1022, true);
			break;
		case "\\ltrpar":
			x1a78664fa10a3755.xae20093bed1e48a8(1560, false);
			break;
		case "\\rtlpar":
			x1a78664fa10a3755.xae20093bed1e48a8(1560, true);
			break;
		case "\\li":
			x1a78664fa10a3755.xae20093bed1e48a8(base.x28fcdc775a1d069c.x515f532dcc4ad30e ? 1160 : 1620, token.xd6f9e3c5ae6509d7());
			break;
		case "\\ri":
			x1a78664fa10a3755.xae20093bed1e48a8(base.x28fcdc775a1d069c.x515f532dcc4ad30e ? 1150 : 1630, token.xd6f9e3c5ae6509d7());
			break;
		case "\\lin":
			x1a78664fa10a3755.xae20093bed1e48a8(1160, token.xd6f9e3c5ae6509d7());
			break;
		case "\\rin":
			x1a78664fa10a3755.xae20093bed1e48a8(1150, token.xd6f9e3c5ae6509d7());
			break;
		case "\\sl":
		{
			int num = token.xd6f9e3c5ae6509d7();
			x1a78664fa10a3755.x84bbacdc1fc0efd2 = Math.Abs(num);
			x1a78664fa10a3755.x6ecc1a11cfc2c359 = ((num < 0) ? LineSpacingRule.Exactly : LineSpacingRule.AtLeast);
			break;
		}
		case "\\slmult":
			if (token.x1ad7968449b109cd())
			{
				x1a78664fa10a3755.x6ecc1a11cfc2c359 = LineSpacingRule.Multiple;
			}
			break;
		case "\\level":
		case "\\outlinelevel":
			x1a78664fa10a3755.xae20093bed1e48a8(1280, (OutlineLevel)token.xd6f9e3c5ae6509d7());
			break;
		case "\\tqr":
			xfe0dcbd6c719ddb1.Alignment = TabAlignment.Right;
			break;
		case "\\tqc":
			xfe0dcbd6c719ddb1.Alignment = TabAlignment.Center;
			break;
		case "\\tqdec":
			xfe0dcbd6c719ddb1.Alignment = TabAlignment.Decimal;
			break;
		case "\\tb":
			xfe0dcbd6c719ddb1.Alignment = TabAlignment.Bar;
			x81aa9179bc2997f1(token);
			break;
		case "\\tx":
			x81aa9179bc2997f1(token);
			break;
		case "\\absw":
			x1a78664fa10a3755.xae20093bed1e48a8(1310, token.xd6f9e3c5ae6509d7());
			break;
		case "\\absh":
			x1a78664fa10a3755.xae20093bed1e48a8(1420, Math.Abs(token.xd6f9e3c5ae6509d7()));
			x1a78664fa10a3755.xae20093bed1e48a8(1430, xdf0bcfa68ba4810c(token.xd6f9e3c5ae6509d7()));
			break;
		case "\\posnegx":
		case "\\posx":
			x1a78664fa10a3755.xae20093bed1e48a8(1292, token.xd6f9e3c5ae6509d7());
			break;
		case "\\posnegy":
		case "\\posy":
			x1a78664fa10a3755.xae20093bed1e48a8(1302, token.xd6f9e3c5ae6509d7());
			break;
		case "\\nowrap":
		case "\\overlay":
		case "\\wrapdefault":
		case "\\wraparound":
		case "\\wraptight":
		case "\\wrapthrough":
			x1a78664fa10a3755.xae20093bed1e48a8(1340, xa0d3611565b2a1f2.xed75ef2aa99e76d3(token.x1dafd189c5465293()));
			break;
		case "\\abslock":
			x1a78664fa10a3755.xae20093bed1e48a8(1520, token.x1ad7968449b109cd());
			break;
		case "\\dfrmtxtx":
			x1a78664fa10a3755.xae20093bed1e48a8(1500, token.xd6f9e3c5ae6509d7());
			break;
		case "\\dfrmtxty":
			x1a78664fa10a3755.xae20093bed1e48a8(1490, token.xd6f9e3c5ae6509d7());
			break;
		case "\\shading":
			x4e5da2e11272a820.x8afbf301967d3fb1(x554aca059bdf6d48, token);
			break;
		case "\\cbpat":
			x4e5da2e11272a820.x959d3c962e8ead5a(base.x28fcdc775a1d069c, x554aca059bdf6d48, token);
			break;
		case "\\cfpat":
			x4e5da2e11272a820.xe86c81ecd859a448(base.x28fcdc775a1d069c, x554aca059bdf6d48, token);
			break;
		case "\\prauth":
			base.x28fcdc775a1d069c.x3c5cf62121f6ba42 = base.x28fcdc775a1d069c.x2086e697b5620586.get_xe6d4b1b411ed94b5(token.xd6f9e3c5ae6509d7());
			break;
		case "\\prdate":
			base.x28fcdc775a1d069c.x125b1f8e1ea06d76 = xa0d3611565b2a1f2.x9a175459d1b055a7(token.xd6f9e3c5ae6509d7());
			break;
		case "\\absnoovrlp":
			x1a78664fa10a3755.xae20093bed1e48a8(1660, token.x1ad7968449b109cd());
			break;
		case "\\indmirror":
			x1a78664fa10a3755.xae20093bed1e48a8(1145, true);
			break;
		case "\\spv":
		case "\\qk":
		case "\\qt":
		case "\\fafixed":
		case "\\txbxtwno":
		case "\\txbxtwalways":
		case "\\txbxtwfirstlast":
		case "\\txbxtwfirst":
		case "\\txbxtwlast":
		case "\\tleq":
		case "\\brdrdashdot":
		case "\\brdrdashdotdot":
			base.x28fcdc775a1d069c.xbd5e5733680bbfc8(token.x1dafd189c5465293());
			break;
		default:
			return x5f15d3f95e847ae4(token);
		}
		return true;
	}

	private bool x5f15d3f95e847ae4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\pnrauth":
			xd6dc0876868db753();
			x55df142229d4371d.xb063bbfcfeade526 = base.x28fcdc775a1d069c.x2086e697b5620586.get_xe6d4b1b411ed94b5(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\pnrdate":
			xd6dc0876868db753();
			x55df142229d4371d.x242851e6278ed355 = xa0d3611565b2a1f2.x9a175459d1b055a7(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\pnrnot":
			xd6dc0876868db753();
			x55df142229d4371d.x713b07324dddc470 = false;
			x55df142229d4371d.x55e2dcfc986cb10b = true;
			break;
		case "\\pnrstart":
			x576cce088cbdd165(x153c99a852375422);
			break;
		case "\\pnrstop":
			xaed4393c91216b8e(x153c99a852375422);
			break;
		case "\\pnrxst":
			x0ebdd4092389c6bf.Add((byte)x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\pnrrgb":
			if (xe1c490eeb26d97e7 < 9)
			{
				x55df142229d4371d.x044891ce086d094b[xe1c490eeb26d97e7++] = (byte)x153c99a852375422.xd6f9e3c5ae6509d7();
			}
			break;
		case "\\pnrnfc":
			if (x85cbdd85c7fe2ad9 < 18)
			{
				int num3 = x85cbdd85c7fe2ad9 & 1;
				x33fed098ef94b417 |= (byte)x153c99a852375422.xd6f9e3c5ae6509d7() << num3 * 8;
				if (x0d299f323d241756.x7e32f71c3f39b6bc(x85cbdd85c7fe2ad9))
				{
					x55df142229d4371d.x7e30db41abd34a71[x85cbdd85c7fe2ad9 / 2] = (NumberStyle)x33fed098ef94b417;
					x33fed098ef94b417 = 0;
				}
				x85cbdd85c7fe2ad9++;
			}
			break;
		case "\\pnrpnbr":
			if (x5305b517809b7b9a < 36)
			{
				int num = x5305b517809b7b9a / 4;
				int num2 = x5305b517809b7b9a & 3;
				x55df142229d4371d.x632f31cdeda76ff9[num] |= (byte)x153c99a852375422.xd6f9e3c5ae6509d7() << num2 * 8;
				x5305b517809b7b9a++;
			}
			break;
		default:
			return false;
		}
		return true;
	}

	private void x576cce088cbdd165(x03f56b37a0050a82 x153c99a852375422)
	{
		x2522f79609327f79 = x153c99a852375422.xd6f9e3c5ae6509d7();
		switch (x2522f79609327f79)
		{
		case 0:
			x0ebdd4092389c6bf = new ArrayList();
			break;
		case 1:
			xe1c490eeb26d97e7 = 0;
			break;
		case 2:
			x33fed098ef94b417 = 0;
			x85cbdd85c7fe2ad9 = 0;
			break;
		case 3:
			x5305b517809b7b9a = 0;
			break;
		}
	}

	private void xaed4393c91216b8e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x2522f79609327f79 == 0)
		{
			x70ec6ea78bfe681d();
		}
	}

	private void x70ec6ea78bfe681d()
	{
		int num = x0ebdd4092389c6bf.Count - 2;
		if (num > 0)
		{
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (byte)x0ebdd4092389c6bf[i + 2];
			}
			x55df142229d4371d.x5051a4a3b273ffce = Encoding.Unicode.GetString(array);
		}
	}

	private void xd6dc0876868db753()
	{
		if (x55df142229d4371d == null)
		{
			x55df142229d4371d = new x978620a99b6d5014();
		}
		x55df142229d4371d.x713b07324dddc470 = true;
		x1a78664fa10a3755.x978620a99b6d5014 = x55df142229d4371d;
	}

	private void xa2a7b403588cebcd()
	{
		x1a78664fa10a3755.ClearAttrs();
		xa0d3611565b2a1f2.x339a4889e0bd1111(x1a78664fa10a3755, xbcea506a33cf9111: false);
		xfe0dcbd6c719ddb1 = new TabStop();
		base.x28fcdc775a1d069c.xde27e91a248c4c90.xc7ae5256463a3132();
		x55df142229d4371d = null;
	}

	private HeightRule xdf0bcfa68ba4810c(int x43b2d5c197d86e52)
	{
		if (x43b2d5c197d86e52 < 0)
		{
			return HeightRule.Exactly;
		}
		if (x43b2d5c197d86e52 > 0)
		{
			return HeightRule.AtLeast;
		}
		return HeightRule.Auto;
	}

	private void x81aa9179bc2997f1(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x1a78664fa10a3755.x8df6f6ca274123b0 == null)
		{
			x1a78664fa10a3755.x8df6f6ca274123b0 = new TabStopCollection();
		}
		xfe0dcbd6c719ddb1.PositionTwips = x153c99a852375422.xd6f9e3c5ae6509d7();
		x1a78664fa10a3755.x8df6f6ca274123b0.Add(xfe0dcbd6c719ddb1);
		xfe0dcbd6c719ddb1 = new TabStop();
	}

	protected override bool SearchInEnums(x03f56b37a0050a82 token)
	{
		object obj = xcb1f99bcd961367e.xc67a9427a070a659(token.x1dafd189c5465293());
		if (obj != null)
		{
			x1a78664fa10a3755.xae20093bed1e48a8(1610, (ParagraphAlignment)obj);
			return true;
		}
		obj = xcb1f99bcd961367e.xfe6f7a54eb4ab8eb(token.x1dafd189c5465293());
		if (obj != null)
		{
			x1a78664fa10a3755.xae20093bed1e48a8(1510, (x8fdc64e3f5579ea8)obj);
			return true;
		}
		obj = xcb1f99bcd961367e.x0ffdc1fb5bd738f9(token.x1dafd189c5465293());
		if (obj != null)
		{
			xfe0dcbd6c719ddb1.Leader = (TabLeader)obj;
			return true;
		}
		obj = xcb1f99bcd961367e.x8e8007ec91fc6ef6(token.x1dafd189c5465293());
		if (obj != null)
		{
			x1a78664fa10a3755.xae20093bed1e48a8(1290, (HorizontalAlignment)obj);
			return true;
		}
		obj = xcb1f99bcd961367e.x6bc7d765aa7c05c7(token.x1dafd189c5465293());
		if (obj != null)
		{
			x1a78664fa10a3755.xae20093bed1e48a8(1300, (VerticalAlignment)obj);
			return true;
		}
		obj = xcb1f99bcd961367e.x1349f6b2c2f5156d(token.x1dafd189c5465293());
		if (obj != null)
		{
			x1a78664fa10a3755.xae20093bed1e48a8(1320, (RelativeHorizontalPosition)obj);
			return true;
		}
		obj = xcb1f99bcd961367e.xb223821a507a8658(token.x1dafd189c5465293());
		if (obj != null)
		{
			x1a78664fa10a3755.xae20093bed1e48a8(1330, (RelativeVerticalPosition)obj);
			return true;
		}
		obj = xcb1f99bcd961367e.x2e021ec350b917d6(token.x1dafd189c5465293());
		if (obj != null)
		{
			x4e5da2e11272a820.x64e0c305de9ff291(x554aca059bdf6d48, (TextureIndex)obj);
			return true;
		}
		obj = xcb1f99bcd961367e.x3f8ccfec1853c0e0(token.x1dafd189c5465293());
		if (obj != null)
		{
			x1a78664fa10a3755.xae20093bed1e48a8(1480, (TextOrientation)obj);
			return true;
		}
		return false;
	}
}
