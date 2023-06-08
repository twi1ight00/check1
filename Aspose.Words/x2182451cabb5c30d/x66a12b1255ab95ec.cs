using System;
using System.IO;
using Aspose.Words;
using Aspose.Words.Settings;
using Aspose.Words.Tables;
using x13f1efc79617a47b;
using x79578da6a8a3ae37;
using xf989f31a236ff98c;

namespace x2182451cabb5c30d;

internal class x66a12b1255ab95ec
{
	private readonly xe5e546ef5f0503b2 x8cedcaa9a62c6e39;

	private readonly xc2ede0fa9eb3936b xecc95f1d9e2a527a;

	private bool x12631894e0b82fa2;

	private bool x93b57daa9fdb4073;

	private bool x572b3b60acd3cc96;

	private readonly x03f56b37a0050a82 x6381445d0f5e75e5 = new x03f56b37a0050a82(xe47a4d4f9d1aa906.x08c5d9f4b0653c8d);

	private static readonly x03f56b37a0050a82 x677d69df55a98473;

	private bool x700ee24405039e9a => xffb3238a8fd59aa7.x9e0d5f7859d0eba8.x700ee24405039e9a;

	private x52108cac3d36b123 xffb3238a8fd59aa7 => xa3a0cc3e91617aca.xffb3238a8fd59aa7;

	private x49d9c71d05ebee3d xa3a0cc3e91617aca => x8cedcaa9a62c6e39.xa3a0cc3e91617aca;

	internal xe5e546ef5f0503b2 x28fcdc775a1d069c => x8cedcaa9a62c6e39;

	internal x66a12b1255ab95ec(Stream stream, Document doc, LoadOptions loadOptions)
		: this(new xc2ede0fa9eb3936b(stream), doc, loadOptions)
	{
	}

	internal x66a12b1255ab95ec(string rtf, Document doc)
		: this(rtf, doc, null)
	{
	}

	internal x66a12b1255ab95ec(string rtf, Document doc, LoadOptions loadOptions)
		: this(new xc2ede0fa9eb3936b(rtf), doc, loadOptions)
	{
	}

	private x66a12b1255ab95ec(xc2ede0fa9eb3936b tokenizer, Document doc, LoadOptions loadOptions)
	{
		xecc95f1d9e2a527a = tokenizer;
		x8cedcaa9a62c6e39 = new xe5e546ef5f0503b2(doc, loadOptions);
	}

	internal void x06b0e25aa6ad68a9()
	{
		x9be8ac2349de06b5(x8cedcaa9a62c6e39.x2c8c6741422a1298);
		xecc95f1d9e2a527a.xd3d72812bb7aaf65();
		if (xecc95f1d9e2a527a.xd420ac3415caa02b.x77dc43988eaceb1c != xe47a4d4f9d1aa906.x612a143b812c1686)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ckpedlgfnknffgeglklgnkchmkjhokaikkhidfoijjfjakmjkedkfjkkdjblfjilodplmhgmidnmliendhlnlhcofhjongapgchpffopeffademakbdblfkbdgbceficdgpcifgdnenddfeegflenacf", 866275150)));
		}
		xecc95f1d9e2a527a.xd3d72812bb7aaf65();
		if (xecc95f1d9e2a527a.xd420ac3415caa02b.x77dc43988eaceb1c != xe47a4d4f9d1aa906.xbb3b746e67ad7684 || xecc95f1d9e2a527a.xd420ac3415caa02b.x1dafd189c5465293() != "\\rtf")
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nlddomkdimbeaiiegmpeimgfhmnfjmegfmlgogcheljhllaifghialoiokfjalmjjfdkhjkkdfblgkiloiplgjgmajnmiienbelnahcopgjoofapfdhpghopohfapgmaohdbdhkbigbcogicbhpcicgd", 964047721)));
		}
		x8cedcaa9a62c6e39.xe1410f585439c7d4.xf3a409990d06c568();
		xffb3238a8fd59aa7.x9e0d5f7859d0eba8.x41e7a76e7e854e6e(xecc95f1d9e2a527a.xd420ac3415caa02b);
		bool flag = false;
		while (xa3a0cc3e91617aca.xd44988f225497f3a > 0 && !flag)
		{
			xecc95f1d9e2a527a.x1e59773e12a1edd8(x28fcdc775a1d069c.xe5e92784f3f9ed17());
			xecc95f1d9e2a527a.xd3d72812bb7aaf65();
			switch (xecc95f1d9e2a527a.xd420ac3415caa02b.x77dc43988eaceb1c)
			{
			case xe47a4d4f9d1aa906.x612a143b812c1686:
				x1088bfef2e9a50ec();
				break;
			case xe47a4d4f9d1aa906.x479f6421165579eb:
				xd75ccb1b8e728140();
				break;
			case xe47a4d4f9d1aa906.xbb3b746e67ad7684:
				xa2d8e36cb99ac0f4(xecc95f1d9e2a527a.xd420ac3415caa02b);
				break;
			case xe47a4d4f9d1aa906.x08c5d9f4b0653c8d:
				xbd6083b329527c4e(xecc95f1d9e2a527a.xd420ac3415caa02b);
				break;
			case xe47a4d4f9d1aa906.xeababaadceb43553:
				flag = true;
				break;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ekpoklgpelnpeleacllahlcblkjbkfaclkhcdkocmjfddjmdjjdeiekejjbfljifpipfbiggheng", 1896148815)));
			}
		}
		x8cedcaa9a62c6e39.xe1410f585439c7d4.x3c06113138282067();
		x7eed84428a9fbf72(x8cedcaa9a62c6e39.x2c8c6741422a1298);
		StyleCollection styles = x8cedcaa9a62c6e39.x2c8c6741422a1298.Styles;
		styles.x0fdd6762da0945d8();
		x20eec3666a2dc8d0.xb07a1ad51e61e4f3(x8cedcaa9a62c6e39.x2c8c6741422a1298.Styles, xdd0280d7d3660ad1: true);
		xcad75876395dfce5 xcad75876395dfce6 = new xcad75876395dfce5(styles);
		xcad75876395dfce6.x61a426bf2696399a();
	}

	private void x1088bfef2e9a50ec()
	{
		if (x12631894e0b82fa2)
		{
			x29150dee2c785174();
		}
		x12631894e0b82fa2 = true;
		x93b57daa9fdb4073 = false;
	}

	private void xd75ccb1b8e728140()
	{
		while (xffb3238a8fd59aa7.xa6aa08c98104c3ae)
		{
			x3c6a75c94820122f();
		}
		x3c6a75c94820122f();
	}

	private void x3c6a75c94820122f()
	{
		if (x12631894e0b82fa2)
		{
			x29150dee2c785174();
		}
		bool x17e2667b = xffb3238a8fd59aa7.x17e2667b58377368;
		if (x17e2667b && !x572b3b60acd3cc96)
		{
			if (!x700ee24405039e9a)
			{
				xa339c5b92e70ca48();
			}
			xffb3238a8fd59aa7.x9e0d5f7859d0eba8.xa4085ff83f9ddeeb();
		}
		xa3a0cc3e91617aca.x47c79a4d207183de();
		if (!x17e2667b && !x572b3b60acd3cc96)
		{
			xffb3238a8fd59aa7.x9e0d5f7859d0eba8.x1d4c43383d15306d();
		}
	}

	private void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x12631894e0b82fa2)
		{
			if (x153c99a852375422.x1dafd189c5465293() == "\\stylesheet" && xa3a0cc3e91617aca.xcfc42ef22e03d2ce != null)
			{
				x0ba94d0c092010a8();
			}
			else if (x153c99a852375422.x1dafd189c5465293() == "\\*")
			{
				if (x93b57daa9fdb4073)
				{
					x049062f47ea6c658(x153c99a852375422);
				}
				else
				{
					x93b57daa9fdb4073 = true;
				}
			}
			else if (x3aafa83aeef65d6e(x153c99a852375422.x1dafd189c5465293()))
			{
				x0ba94d0c092010a8();
			}
			else
			{
				x72119ad95258918e(x153c99a852375422);
			}
			return;
		}
		if (x153c99a852375422.x1dafd189c5465293() == "\\f")
		{
			xa339c5b92e70ca48();
		}
		if (!x572b3b60acd3cc96)
		{
			if (x5858aa7cbfa48a5a(x153c99a852375422))
			{
				xffb3238a8fd59aa7.xa6aa08c98104c3ae = true;
			}
			else
			{
				xffb3238a8fd59aa7.x9e0d5f7859d0eba8.xa2d8e36cb99ac0f4(x153c99a852375422);
			}
		}
	}

	private bool x5858aa7cbfa48a5a(x03f56b37a0050a82 x153c99a852375422)
	{
		bool result = false;
		xbf575e106f2f2373 xbf575e106f2f2374 = x8f29675e2802bda2.xa068edde3a4fac55(x153c99a852375422.x1dafd189c5465293());
		if (xbf575e106f2f2374 != null)
		{
			xa3a0cc3e91617aca.x1914eddf1fde1228(xbf575e106f2f2374);
			if (!x5a449627054e6f08(xbf575e106f2f2374.x3146d638ec378671))
			{
				x28fcdc775a1d069c.xed3a4a9e0daaedc8 = null;
			}
			if (xffb3238a8fd59aa7.x9e0d5f7859d0eba8 != null)
			{
				if (!xf3926b91d75eddcb(xbf575e106f2f2374) && !x572b3b60acd3cc96)
				{
					xffb3238a8fd59aa7.x9e0d5f7859d0eba8.x41e7a76e7e854e6e(x153c99a852375422);
				}
				x12631894e0b82fa2 = false;
				result = true;
			}
			else
			{
				xa3a0cc3e91617aca.x47c79a4d207183de();
			}
		}
		return result;
	}

	private void xbd6083b329527c4e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x12631894e0b82fa2)
		{
			x29150dee2c785174();
		}
		if (x572b3b60acd3cc96)
		{
			return;
		}
		if (x700ee24405039e9a)
		{
			xffb3238a8fd59aa7.x9e0d5f7859d0eba8.xbd6083b329527c4e(x153c99a852375422);
			return;
		}
		x6381445d0f5e75e5.xd373314879c5ac75(x153c99a852375422.x9f1a6a3451a38d10());
		if (x153c99a852375422.x5c3e5f6c95f2f83a)
		{
			xa339c5b92e70ca48();
		}
	}

	private void x72119ad95258918e(x03f56b37a0050a82 x153c99a852375422)
	{
		xbf575e106f2f2373 xbf575e106f2f2374 = x8f29675e2802bda2.xa068edde3a4fac55(x153c99a852375422.x1dafd189c5465293());
		if (xbf575e106f2f2374 != null)
		{
			xa339c5b92e70ca48();
			if (!x5858aa7cbfa48a5a(x153c99a852375422))
			{
				xbb3171a340e79cc5(x153c99a852375422);
			}
		}
		else
		{
			xbb3171a340e79cc5(x153c99a852375422);
		}
	}

	private static bool x5a449627054e6f08(x25099a8bbbd55d1c x43163d22e8cd5a71)
	{
		switch (x43163d22e8cd5a71)
		{
		case x25099a8bbbd55d1c.x9256a6c338f6cb6c:
		case x25099a8bbbd55d1c.xf71fbad3171c611c:
		case x25099a8bbbd55d1c.x2bb1565407c1dc98:
			return true;
		default:
			return false;
		}
	}

	private bool xf3926b91d75eddcb(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		switch (x8d3f74e5f925679c.x3146d638ec378671)
		{
		case x25099a8bbbd55d1c.x25abc19257451256:
			x572b3b60acd3cc96 = true;
			return true;
		case x25099a8bbbd55d1c.x026b175db0b397b2:
			x572b3b60acd3cc96 = false;
			return true;
		default:
			return false;
		}
	}

	private void xbb3171a340e79cc5(x03f56b37a0050a82 x153c99a852375422)
	{
		if (x93b57daa9fdb4073)
		{
			x0ba94d0c092010a8();
		}
		else
		{
			x049062f47ea6c658(x153c99a852375422);
		}
	}

	private void x049062f47ea6c658(x03f56b37a0050a82 x153c99a852375422)
	{
		x29150dee2c785174();
		if (!x572b3b60acd3cc96)
		{
			xffb3238a8fd59aa7.x9e0d5f7859d0eba8.xa2d8e36cb99ac0f4(x153c99a852375422);
		}
	}

	private void x29150dee2c785174()
	{
		if (!x572b3b60acd3cc96)
		{
			xffb3238a8fd59aa7.x9e0d5f7859d0eba8.x7cf86f9ad985db0c();
		}
		xa3a0cc3e91617aca.x1914eddf1fde1228(null);
		if (x93b57daa9fdb4073 && !x572b3b60acd3cc96)
		{
			xffb3238a8fd59aa7.x9e0d5f7859d0eba8.xa2d8e36cb99ac0f4(x677d69df55a98473);
		}
		x12631894e0b82fa2 = false;
	}

	internal void x0ba94d0c092010a8()
	{
		int num = 1;
		while (num > 0)
		{
			xecc95f1d9e2a527a.xd3d72812bb7aaf65();
			switch (xecc95f1d9e2a527a.xd420ac3415caa02b.x77dc43988eaceb1c)
			{
			case xe47a4d4f9d1aa906.x612a143b812c1686:
				num++;
				break;
			case xe47a4d4f9d1aa906.x479f6421165579eb:
				num--;
				break;
			default:
				throw new InvalidOperationException("Unexpected RTF token type.");
			case xe47a4d4f9d1aa906.xbb3b746e67ad7684:
			case xe47a4d4f9d1aa906.x08c5d9f4b0653c8d:
				break;
			}
		}
		x12631894e0b82fa2 = false;
	}

	private void x724224a979764ab0()
	{
		x6381445d0f5e75e5.x74f5a1ef3906e23c(xe47a4d4f9d1aa906.x08c5d9f4b0653c8d);
	}

	private void xa339c5b92e70ca48()
	{
		if (x6381445d0f5e75e5.xf1e97d28a3ee95a9 > 0)
		{
			xffb3238a8fd59aa7.x9e0d5f7859d0eba8.xbd6083b329527c4e(x6381445d0f5e75e5);
			x724224a979764ab0();
		}
	}

	private static bool x3aafa83aeef65d6e(string xc15bd84e01929885)
	{
		switch (xc15bd84e01929885)
		{
		case "\\pntext":
		case "\\listtext":
		case "\\nonshppict":
		case "\\nonesttables":
		case "\\shprslt":
		case "\\comment":
		case "\\mmathPict":
			return true;
		default:
			return false;
		}
	}

	private static void x7eed84428a9fbf72(CompositeNode xda5bf54deb817e37)
	{
		foreach (Table childNode in xda5bf54deb817e37.GetChildNodes(NodeType.Table, isDeep: true))
		{
			if (childNode.FirstRow == null || childNode.FirstRow.xedb0eb766e25e0c9 == null)
			{
				childNode.Remove();
			}
		}
	}

	private static void x9be8ac2349de06b5(Document x6beba47238e0ade6)
	{
		xdade2366eaa6f915 xdade2366eaa6f = x6beba47238e0ade6.xdade2366eaa6f915;
		xdade2366eaa6f.xa7c8accbf82b9f90 = true;
		xdade2366eaa6f.x8af0b297a9d474ad = true;
		xdade2366eaa6f.x636013cbf60f10b8 = true;
		xdade2366eaa6f.x75c79d4f5c4f8bd1 = true;
		xdade2366eaa6f.xa7e6dbdb484bb52e = false;
		CompatibilityOptions xe322902ca0e695f = xdade2366eaa6f.xe322902ca0e695f5;
		xe322902ca0e695f.AlignTablesRowByRow = true;
		xe322902ca0e695f.GrowAutofit = true;
		xe322902ca0e695f.LayoutTableRowsApart = true;
		xe322902ca0e695f.BalanceSingleByteDoubleByteWidth = true;
		xe322902ca0e695f.DoNotWrapTextWithPunct = true;
		xe322902ca0e695f.DoNotBreakWrappedTables = true;
		xe322902ca0e695f.DoNotUseEastAsianBreakRules = true;
		xe322902ca0e695f.DoNotUseHTMLParagraphAutoSpacing = true;
		xe322902ca0e695f.ForgetLastTabAlignment = true;
		xe322902ca0e695f.ShapeLayoutLikeWW8 = true;
		xe322902ca0e695f.FootnoteLayoutLikeWW8 = true;
		xe322902ca0e695f.LayoutRawTableWidth = true;
		xe322902ca0e695f.SelectFldWithFirstOrLastChar = true;
		xe322902ca0e695f.UseWord2002TableStyleRules = true;
		xe322902ca0e695f.UseWord97LineBreakRules = true;
		xe322902ca0e695f.DoNotLeaveBackslashAlone = true;
		xe322902ca0e695f.DoNotExpandShiftReturn = true;
		xe322902ca0e695f.DoNotSnapToGridInCell = true;
		xe322902ca0e695f.SpaceForUL = true;
		xe322902ca0e695f.AdjustLineHeightInTable = true;
		xe322902ca0e695f.UlTrailSpace = true;
		xe322902ca0e695f.UICompat97To2003 = true;
	}

	static x66a12b1255ab95ec()
	{
		x677d69df55a98473 = new x03f56b37a0050a82(xe47a4d4f9d1aa906.xbb3b746e67ad7684);
		x677d69df55a98473.xc351d479ff7ee789(92);
		x677d69df55a98473.xc351d479ff7ee789(42);
	}
}
