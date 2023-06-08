using System.Collections;
using Aspose.Words;
using Aspose.Words.Settings;
using x28925c9b27b37a46;
using x556d8f9846e43329;
using x79578da6a8a3ae37;
using xda075892eccab2ad;
using xe5b37aee2c2a4d4e;

namespace x2182451cabb5c30d;

internal class xb0f3f9760f35314a : xe16295e98b4802cb
{
	private static readonly Hashtable x84d7f7643f9e3f6a;

	internal xb0f3f9760f35314a(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	protected override bool ParseSingleToken(x03f56b37a0050a82 token)
	{
		xdade2366eaa6f915 xdade2366eaa6f = base.x28fcdc775a1d069c.x2c8c6741422a1298.xdade2366eaa6f915;
		if (x2662145c25648a64(xdade2366eaa6f, token))
		{
			return true;
		}
		if (x0167d5656f8b5eea(xdade2366eaa6f, token))
		{
			return true;
		}
		if (x35076043c993ad48(xdade2366eaa6f.xc8949e68d489222b, token))
		{
			return true;
		}
		if (x49357e227d20d7ed(xdade2366eaa6f, token))
		{
			return true;
		}
		if (xfb5a2ccef33c9bfe(token))
		{
			return true;
		}
		if (xa51e75129d9a3d3b(xdade2366eaa6f, token))
		{
			return true;
		}
		if (xab16172b49f147ec(xdade2366eaa6f, token))
		{
			return true;
		}
		if (x91fdcd9aaa8cfb8f(xdade2366eaa6f, token))
		{
			return true;
		}
		if (x896a21bc771e42f8(xdade2366eaa6f, token))
		{
			return true;
		}
		if (xd8f29f1b8971d8a8(xdade2366eaa6f, token))
		{
			return true;
		}
		if (x2f302c7edc249303(xdade2366eaa6f, token))
		{
			return true;
		}
		if (x1265c32d649bb425(xdade2366eaa6f, token))
		{
			return true;
		}
		if (x1f9a75fccfc1f6e2(xdade2366eaa6f, token))
		{
			return true;
		}
		if (xfb5a2ccef33c9bfe(token))
		{
			return true;
		}
		if (xa71cdb48853bf163(xdade2366eaa6f, token))
		{
			return true;
		}
		return false;
	}

	private static bool x2662145c25648a64(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		object obj = x27d6a0b6a88a5be5.x404534c61bdc50d0(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			xe31d35d3e8fc8bf2.x2b3870f998fa2689 = (xd659df342ea4c461)obj;
			return true;
		}
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\deftab":
			xe31d35d3e8fc8bf2.xd72f9bc5cc53fc1c = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\hyphauto":
			xe31d35d3e8fc8bf2.xdf76d3eeb73027d7 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\hyphhotz":
			xe31d35d3e8fc8bf2.x91faf128d9e0425f = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\hyphconsec":
			xe31d35d3e8fc8bf2.xfaa0f593a0704d95 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\hyphcaps":
			xe31d35d3e8fc8bf2.xaca8557eea824bc0 = !x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\fracwidth":
			xe31d35d3e8fc8bf2.x058f26e482f9ecb6 = true;
			break;
		case "\\psover":
			xe31d35d3e8fc8bf2.x4bf1c3bb4f850306 = true;
			break;
		case "\\doctype":
			xe31d35d3e8fc8bf2.x5cdb67c2d32f8a3a = (x760e7af47aae1b61)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\showplaceholdtext":
			xe31d35d3e8fc8bf2.x6980630e657b6aad = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\showxmlerrors":
			xe31d35d3e8fc8bf2.x02b20ac01ba667b2 = !x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\validatexml":
			xe31d35d3e8fc8bf2.x0171de9b8f68ad5c = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\ignoremixedcontent":
			xe31d35d3e8fc8bf2.x2cc4b92e8cd6e124 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\saveinvalidxml":
			xe31d35d3e8fc8bf2.x3b978168870d58e9 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\usexform":
			xe31d35d3e8fc8bf2.x2c67db9a06eaf625 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\stylelockqfset":
			xe31d35d3e8fc8bf2.x7c692ff62009f114 = true;
			break;
		case "\\stylelocktheme":
			xe31d35d3e8fc8bf2.x8749385938ab4a85 = true;
			break;
		case "\\stylesortmethod":
			xe31d35d3e8fc8bf2.x9b603ddcf603293d = x72a0c846678ecaf9.x4ad35d0edf2d7b05(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\relyonvml":
			xe31d35d3e8fc8bf2.xc2d62826afc28ce5 = x153c99a852375422.x1ad7968449b109cd();
			break;
		default:
			return false;
		case "\\doctemp":
			break;
		}
		return true;
	}

	private static bool x0167d5656f8b5eea(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\viewkind":
			xe31d35d3e8fc8bf2.x17bade2eb7f9764f.ViewType = (ViewType)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\viewscale":
			xe31d35d3e8fc8bf2.x17bade2eb7f9764f.ZoomPercent = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\viewzk":
			xe31d35d3e8fc8bf2.x17bade2eb7f9764f.ZoomType = (ZoomType)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\viewbksp":
			xe31d35d3e8fc8bf2.x17bade2eb7f9764f.DisplayBackgroundShape = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\viewnobound":
			xe31d35d3e8fc8bf2.x17bade2eb7f9764f.DoNotDisplayPageBoundaries = x153c99a852375422.x1ad7968449b109cd();
			break;
		default:
			return false;
		}
		return true;
	}

	private static bool x35076043c993ad48(x4c1e058c67948d6a x7c301806dc7e4f32, x03f56b37a0050a82 x153c99a852375422)
	{
		object obj = x27d6a0b6a88a5be5.x83f6f85fa4803d5b(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x7c301806dc7e4f32.xae20093bed1e48a8(2500, (FootnoteLocation)obj);
			return true;
		}
		obj = x27d6a0b6a88a5be5.x52a44b54a476c893(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x7c301806dc7e4f32.xae20093bed1e48a8(2600, (FootnoteLocation)obj);
			return true;
		}
		obj = x27d6a0b6a88a5be5.xc564832c63111a37(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x7c301806dc7e4f32.xae20093bed1e48a8(2510, (FootnoteNumberingRule)obj);
			return true;
		}
		obj = x27d6a0b6a88a5be5.x6d975995ee3c0c2d(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x7c301806dc7e4f32.xae20093bed1e48a8(2610, (FootnoteNumberingRule)obj);
			return true;
		}
		obj = x27d6a0b6a88a5be5.x0e18340ee87d81ff(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x7c301806dc7e4f32.xae20093bed1e48a8(2530, (NumberStyle)obj);
			return true;
		}
		obj = x27d6a0b6a88a5be5.xcc44b4ac06c98352(x153c99a852375422.x1dafd189c5465293());
		if (obj != null)
		{
			x7c301806dc7e4f32.xae20093bed1e48a8(2630, (NumberStyle)obj);
			return true;
		}
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\ftnstart":
			x7c301806dc7e4f32.xae20093bed1e48a8(2520, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\aftnstart":
			x7c301806dc7e4f32.xae20093bed1e48a8(2620, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		default:
			return false;
		}
		return true;
	}

	private static bool x49357e227d20d7ed(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		string text;
		if ((text = x153c99a852375422.x1dafd189c5465293()) != null && text == "\\linkstyles")
		{
			xe31d35d3e8fc8bf2.x25c2aa42b1eb10e5 = true;
			return true;
		}
		return false;
	}

	private bool xfb5a2ccef33c9bfe(x03f56b37a0050a82 x153c99a852375422)
	{
		xdade2366eaa6f915 xdade2366eaa6f = base.x28fcdc775a1d069c.x2c8c6741422a1298.xdade2366eaa6f915;
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\facingp":
			xdade2366eaa6f.x5ac0ad056c3fce83 = true;
			break;
		case "\\margmirror":
			xdade2366eaa6f.xd02fc99dc9c3221e = true;
			break;
		case "\\gutterprl":
			xdade2366eaa6f.xe1c58df4343d599e = true;
			break;
		case "\\widowctrl":
			xdade2366eaa6f.xa7e6dbdb484bb52e = true;
			break;
		case "\\twoonone":
			xdade2366eaa6f.xb8230cce4c519a2a = true;
			break;
		case "\\bookfold":
			xdade2366eaa6f.x6116d416354a4a7e = true;
			break;
		case "\\bookfoldrev":
			xdade2366eaa6f.xcb55fa1ad5b5e650 = true;
			break;
		case "\\bookfoldsheets":
			xdade2366eaa6f.xf62aa4c5d803502a = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\gutter":
		case "\\paperw":
		case "\\paperh":
		case "\\margl":
		case "\\margr":
		case "\\margt":
		case "\\margb":
		{
			int xba08ce632055a1d = (int)x84d7f7643f9e3f6a[x153c99a852375422.x1dafd189c5465293()];
			base.x28fcdc775a1d069c.xbfc3dda117a540e4(xba08ce632055a1d, x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		}
		case "\\landscape":
			base.x28fcdc775a1d069c.xbfc3dda117a540e4(2210, Orientation.Landscape);
			break;
		default:
			return false;
		}
		return true;
	}

	private static bool xa51e75129d9a3d3b(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		CompatibilityOptions xe322902ca0e695f = xe31d35d3e8fc8bf2.xe322902ca0e695f5;
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\nospaceforul":
			xe322902ca0e695f.SpaceForUL = false;
			break;
		case "\\nolnhtadjtbl":
			xe322902ca0e695f.AdjustLineHeightInTable = false;
			break;
		case "\\alntblind":
			xe322902ca0e695f.AlignTablesRowByRow = false;
			break;
		case "\\lyttblrtgr":
			xe322902ca0e695f.LayoutTableRowsApart = false;
			break;
		case "\\nogrowautofit":
			xe322902ca0e695f.GrowAutofit = false;
			break;
		case "\\oldas":
			xe322902ca0e695f.AutoSpaceLikeWord95 = true;
			break;
		case "\\dntblnsbdb":
			xe322902ca0e695f.BalanceSingleByteDoubleByteWidth = false;
			break;
		case "\\otblrul":
			xe322902ca0e695f.UseSingleBorderforContiguousCells = true;
			break;
		case "\\noxlattoyen":
			xe322902ca0e695f.DoNotLeaveBackslashAlone = false;
			break;
		case "\\wpjst":
			xe322902ca0e695f.WPJustification = true;
			break;
		case "\\notabind":
			xe322902ca0e695f.NoTabHangInd = true;
			break;
		case "\\noextrasprl":
			xe322902ca0e695f.NoSpaceRaiseLower = true;
			break;
		case "\\nolead":
			xe322902ca0e695f.NoLeading = true;
			break;
		case "\\wrppunct":
			xe322902ca0e695f.DoNotWrapTextWithPunct = false;
			break;
		case "\\nocolbal":
			xe322902ca0e695f.NoColumnBalance = true;
			break;
		case "\\transmf":
			xe322902ca0e695f.TransparentMetafiles = true;
			break;
		case "\\nobrkwrptbl":
			xe322902ca0e695f.DoNotBreakWrappedTables = false;
			break;
		case "\\lytexcttp":
			xe322902ca0e695f.NoExtraLineSpacing = true;
			break;
		case "\\expshrtn":
			xe322902ca0e695f.DoNotExpandShiftReturn = false;
			break;
		case "\\snaptogridincell":
			xe322902ca0e695f.DoNotSnapToGridInCell = false;
			break;
		case "\\asianbrkrule":
			xe322902ca0e695f.DoNotUseEastAsianBreakRules = false;
			break;
		case "\\htmautsp":
			xe322902ca0e695f.DoNotUseHTMLParagraphAutoSpacing = false;
			break;
		case "\\noultrlspc":
			xe322902ca0e695f.UlTrailSpace = false;
			break;
		case "\\truncex":
			xe322902ca0e695f.SpacingInWholePoints = true;
			break;
		case "\\useltbaln":
			xe322902ca0e695f.ForgetLastTabAlignment = false;
			break;
		case "\\splytwnine":
			xe322902ca0e695f.ShapeLayoutLikeWW8 = false;
			break;
		case "\\ftnlytwnine":
			xe322902ca0e695f.FootnoteLayoutLikeWW8 = false;
			break;
		case "\\lytcalctblwd":
			xe322902ca0e695f.LayoutRawTableWidth = false;
			break;
		case "\\oldlinewrap":
			xe322902ca0e695f.LineWrapLikeWord6 = true;
			break;
		case "\\bdbfhdr":
			xe322902ca0e695f.PrintBodyTextBeforeHeader = true;
			break;
		case "\\prcolbl":
			xe322902ca0e695f.PrintColBlack = true;
			break;
		case "\\allowfieldendsel":
			xe322902ca0e695f.SelectFldWithFirstOrLastChar = false;
			break;
		case "\\wpsp":
			xe322902ca0e695f.WPSpaceWidth = true;
			break;
		case "\\brkfrm":
			xe322902ca0e695f.ShowBreaksInFrames = true;
			break;
		case "\\subfontbysize":
			xe322902ca0e695f.SubFontBySize = true;
			break;
		case "\\sprsbsp":
			xe322902ca0e695f.SuppressBottomSpacing = true;
			break;
		case "\\sprstsp":
			xe322902ca0e695f.SuppressTopSpacing = true;
			break;
		case "\\sprstsm":
			xe322902ca0e695f.SuppressSpacingAtTopOfPage = true;
			break;
		case "\\sprslnsp":
			xe322902ca0e695f.SuppressTopSpacingWP = true;
			break;
		case "\\sprsspbf":
			xe322902ca0e695f.SuppressSpBfAfterPgBrk = true;
			break;
		case "\\swpbdr":
			xe322902ca0e695f.SwapBordersFacingPgs = true;
			break;
		case "\\cvmme":
			xe322902ca0e695f.ConvMailMergeEsc = true;
			break;
		case "\\truncatefontheight":
			xe322902ca0e695f.TruncateFontHeightsLikeWP6 = true;
			break;
		case "\\msmcap":
			xe322902ca0e695f.MWSmallCaps = true;
			break;
		case "\\ApplyBrkRules":
			xe322902ca0e695f.ApplyBreakingRules = true;
			break;
		case "\\lytprtmet":
			xe322902ca0e695f.UsePrinterMetrics = true;
			break;
		case "\\newtblstyruls":
			xe322902ca0e695f.UseWord2002TableStyleRules = false;
			break;
		case "\\bdrrlswsix":
			xe322902ca0e695f.DoNotSuppressParagraphBorders = true;
			break;
		case "\\lnbrkrule":
			xe322902ca0e695f.UseWord97LineBreakRules = false;
			break;
		case "\\wraptrsp":
			xe322902ca0e695f.WrapTrailSpaces = true;
			break;
		case "\\nouicompat":
			xe322902ca0e695f.UICompat97To2003 = false;
			break;
		case "\\nofeaturethrottle":
			xe322902ca0e695f.UICompat97To2003 = !x153c99a852375422.x1ad7968449b109cd();
			break;
		default:
			return false;
		}
		return true;
	}

	private static bool xab16172b49f147ec(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\formshade":
			xe31d35d3e8fc8bf2.x75c79d4f5c4f8bd1 = false;
			break;
		case "\\printdata":
			xe31d35d3e8fc8bf2.x15b47472ae0f4bf5 = true;
			break;
		default:
			return false;
		}
		return true;
	}

	private static bool x91fdcd9aaa8cfb8f(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		xcadc354ab6a177f1 xcadc354ab6a177f = xe31d35d3e8fc8bf2.xcadc354ab6a177f1;
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\revprot":
			xcadc354ab6a177f.x491ce6cbe2c9a184 = ProtectionType.AllowOnlyRevisions;
			break;
		case "\\annotprot":
			xcadc354ab6a177f.x491ce6cbe2c9a184 = ProtectionType.AllowOnlyComments;
			break;
		case "\\formprot":
			xcadc354ab6a177f.x491ce6cbe2c9a184 = ProtectionType.AllowOnlyFormFields;
			break;
		case "\\readprot":
			xcadc354ab6a177f.x491ce6cbe2c9a184 = ProtectionType.ReadOnly;
			break;
		case "\\enforceprot":
			xcadc354ab6a177f.x0cbff01514c02c1b = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\stylelock":
			xcadc354ab6a177f.x4eae8f1c9ec0d2ae = true;
			break;
		case "\\autofmtoverride":
			xe31d35d3e8fc8bf2.xcadc354ab6a177f1.x84a58b01dbef401d = true;
			break;
		default:
			return false;
		case "\\protlevel":
			break;
		}
		return true;
	}

	private static bool x896a21bc771e42f8(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		string text;
		if ((text = x153c99a852375422.x1dafd189c5465293()) != null && text == "\\readonlyrecommended")
		{
			xe31d35d3e8fc8bf2.xc57807e17cfa13d2.ReadOnlyRecommended = true;
			return true;
		}
		return false;
	}

	private static bool xd8f29f1b8971d8a8(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		string text;
		if ((text = x153c99a852375422.x1dafd189c5465293()) != null && text == "\\revisions")
		{
			xe31d35d3e8fc8bf2.x98c0ec6ac7570a99 = true;
			return true;
		}
		return false;
	}

	private static bool x2f302c7edc249303(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		string text;
		if ((text = x153c99a852375422.x1dafd189c5465293()) != null && text == "\\nojkernpunct")
		{
			xe31d35d3e8fc8bf2.xa7c8accbf82b9f90 = false;
			return true;
		}
		return false;
	}

	private static bool x1265c32d649bb425(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\dghspace":
			xe31d35d3e8fc8bf2.xf0c98b9a5846f66c = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\dgvspace":
			xe31d35d3e8fc8bf2.xac305e755359cb11 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\dghorigin":
			xe31d35d3e8fc8bf2.x88b1df8cde4d7483 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\dgvorigin":
			xe31d35d3e8fc8bf2.xd4d02d35f9fd2c1a = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\dghshow":
			xe31d35d3e8fc8bf2.x95a4a50d4ad3f396 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\dgvshow":
			xe31d35d3e8fc8bf2.xc731b34015cd8a41 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\dgmargin":
			xe31d35d3e8fc8bf2.x5a27e3b345b6aa73 = true;
			break;
		default:
			return false;
		}
		return true;
	}

	private static bool x1f9a75fccfc1f6e2(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\pgbrdrhead":
			xe31d35d3e8fc8bf2.x8af0b297a9d474ad = false;
			break;
		case "\\pgbrdrfoot":
			xe31d35d3e8fc8bf2.x636013cbf60f10b8 = false;
			break;
		case "\\pgbrdrsnap":
			xe31d35d3e8fc8bf2.xb460e2e11d4e8429 = true;
			break;
		default:
			return false;
		}
		return true;
	}

	private bool xa71cdb48853bf163(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x03f56b37a0050a82 x153c99a852375422)
	{
		x1c605672f036e9e1 x1c605672f036e9e = xe31d35d3e8fc8bf2.x1c605672f036e9e1;
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\mbrkBin":
			x1c605672f036e9e.x3b85abfed6d4424f = (x8cc5e7c82a5cfe7a)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mbrkBinSub":
			x1c605672f036e9e.xb56517bd05ef77f6 = (x64749a01847a82ed)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mdefJc":
			x1c605672f036e9e.x78266b0e9c142786 = (x2cdbcd6273a149f1)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mdispDef":
			x1c605672f036e9e.x92447f7677982e86 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\minterSp":
			x1c605672f036e9e.x0adbbc56413a8e57 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mintLim":
			x1c605672f036e9e.x8b277d8dd2e2d7af = (xf47bac63068c8fd6)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mintraSp":
			x1c605672f036e9e.x2c78840c9608859b = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mlMargin":
			x1c605672f036e9e.xc8a7b7ce5c5279ee = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mmathFont":
			x1c605672f036e9e.xddffcb24e864cfcc = base.x28fcdc775a1d069c.x241e429ca27700bc(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		case "\\mnaryLim":
			x1c605672f036e9e.x07f824b6513692d8 = (xf47bac63068c8fd6)x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mpostSp":
			x1c605672f036e9e.x4a1d08cff27d9916 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mpreSp":
			x1c605672f036e9e.xb2853935633b60e2 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mrMargin":
			x1c605672f036e9e.x3fa6fa3075fd558f = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\msmallFrac":
			x1c605672f036e9e.xaf8d6a43346515c6 = x153c99a852375422.x1ad7968449b109cd();
			break;
		case "\\mwrapIndent":
			x1c605672f036e9e.x3810b9f8f9111f8a = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\mwrapRight":
			x1c605672f036e9e.x11227fd74d91663d = x153c99a852375422.x1ad7968449b109cd();
			break;
		default:
			return false;
		}
		return true;
	}

	protected override bool SearchInEnums(x03f56b37a0050a82 token)
	{
		return false;
	}

	static xb0f3f9760f35314a()
	{
		x84d7f7643f9e3f6a = new Hashtable();
		x84d7f7643f9e3f6a.Add("\\gutter", 2312);
		x84d7f7643f9e3f6a.Add("\\paperw", 2260);
		x84d7f7643f9e3f6a.Add("\\paperh", 2270);
		x84d7f7643f9e3f6a.Add("\\margl", 2280);
		x84d7f7643f9e3f6a.Add("\\margr", 2290);
		x84d7f7643f9e3f6a.Add("\\margt", 2300);
		x84d7f7643f9e3f6a.Add("\\margb", 2310);
	}
}
