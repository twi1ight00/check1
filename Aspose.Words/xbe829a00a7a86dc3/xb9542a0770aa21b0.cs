using System.Collections;
using Aspose.Words;
using Aspose.Words.Settings;
using x0a300997a0b66409;
using x1a3e96f4b89a7a77;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using xda075892eccab2ad;
using xf989f31a236ff98c;
using xf9a9481c3f63a419;

namespace xbe829a00a7a86dc3;

internal class xb9542a0770aa21b0
{
	private xb9542a0770aa21b0()
	{
	}

	internal static void x6210059f049f0d48(x4f037d20d40d8390 xbdfb620b7167944b)
	{
		Document document = (Document)xbdfb620b7167944b.x2c8c6741422a1298;
		xdade2366eaa6f915 xdade2366eaa6f = document.xdade2366eaa6f915;
		x873451caae5ad4ae xe1410f585439c7d = xbdfb620b7167944b.xe1410f585439c7d4;
		xe1410f585439c7d.x2307058321cdb62f("w:docPr");
		xe1410f585439c7d.x547195bcc386fe66("w:view", x89d497a9d94437ea.x761be663dee8597e(document.ViewOptions.ViewType));
		x4252174a1e986985(document.ViewOptions, xe1410f585439c7d);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:removePersonalInformation", xdade2366eaa6f.x329a4e432765a448);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:dontDisplayPageBoundaries", document.ViewOptions.DoNotDisplayPageBoundaries);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:displayBackgroundShape", document.ViewOptions.DisplayBackgroundShape);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:printFormsData", xdade2366eaa6f.x15b47472ae0f4bf5);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:embedTrueTypeFonts", xdade2366eaa6f.x26622336636caa4d);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:saveSubsetFonts", xdade2366eaa6f.xacad582ef7f5d121);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:saveFormsData", xdade2366eaa6f.xc64ebc14fbb01a1c);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:mirrorMargins", xdade2366eaa6f.xd02fc99dc9c3221e);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:alignBordersAndEdges", xdade2366eaa6f.xb460e2e11d4e8429);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:bordersDontSurroundHeader", xdade2366eaa6f.x8af0b297a9d474ad);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:bordersDontSurroundFooter", xdade2366eaa6f.x636013cbf60f10b8);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:gutterAtTop", xdade2366eaa6f.xe1c58df4343d599e);
		x0cd33fe10bad39b1(xdade2366eaa6f, xe1410f585439c7d);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:formsDesign", document.ViewOptions.FormsDesign);
		xe1410f585439c7d.xa639a651da945648("w:attachedTemplate", xdade2366eaa6f.x8c0ad447fda248da);
		xe1410f585439c7d.x547195bcc386fe66("w:documentType", x89d497a9d94437ea.xc92579e54c49e568(xdade2366eaa6f.x5cdb67c2d32f8a3a));
		if (xdade2366eaa6f.xfc32bf4854f4898d != 20516)
		{
			xe1410f585439c7d.x547195bcc386fe66("w:stylePaneFormatFilter", xca004f56614e2431.x7c1a0f9da8274fe8(xdade2366eaa6f.xfc32bf4854f4898d));
		}
		xa39c259117702bfd xa39c259117702bfd2 = new xa39c259117702bfd();
		xa39c259117702bfd2.x6210059f049f0d48(xdade2366eaa6f.xe690cef2446c7d46, xbdfb620b7167944b);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:trackRevisions", xdade2366eaa6f.x98c0ec6ac7570a99);
		x848e271d45c6375c(xdade2366eaa6f.xcadc354ab6a177f1, xe1410f585439c7d);
		xe1410f585439c7d.x547195bcc386fe66("w:defaultTabStop", xdade2366eaa6f.xd72f9bc5cc53fc1c);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:autoHyphenation", xdade2366eaa6f.xdf76d3eeb73027d7);
		xe1410f585439c7d.x67aa7400b293b13a("w:consecutiveHyphenLimit", xdade2366eaa6f.xfaa0f593a0704d95);
		xe1410f585439c7d.x24f8794502b580ff("w:hyphenationZone", xdade2366eaa6f.x91faf128d9e0425f, 360);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotHyphenateCaps", xdade2366eaa6f.xaca8557eea824bc0);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:evenAndOddHeaders", xdade2366eaa6f.x5ac0ad056c3fce83);
		xe1410f585439c7d.x24f8794502b580ff("w:drawingGridHorizontalSpacing", xdade2366eaa6f.xf0c98b9a5846f66c, 180);
		xe1410f585439c7d.x24f8794502b580ff("w:drawingGridVerticalSpacing", xdade2366eaa6f.xac305e755359cb11, 180);
		xe1410f585439c7d.x24f8794502b580ff("w:displayHorizontalDrawingGridEvery", xdade2366eaa6f.x95a4a50d4ad3f396, 1);
		xe1410f585439c7d.x24f8794502b580ff("w:displayVerticalDrawingGridEvery", xdade2366eaa6f.xc731b34015cd8a41, 1);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:useMarginsForDrawingGridOrigin", !xdade2366eaa6f.x5a27e3b345b6aa73);
		if (!xdade2366eaa6f.x5a27e3b345b6aa73)
		{
			xe1410f585439c7d.x24f8794502b580ff("w:drawingGridHorizontalOrigin", xdade2366eaa6f.x88b1df8cde4d7483, 1800);
			xe1410f585439c7d.x24f8794502b580ff("w:drawingGridVerticalOrigin", xdade2366eaa6f.xd4d02d35f9fd2c1a, 1440);
		}
		xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotShadeFormData", xdade2366eaa6f.x75c79d4f5c4f8bd1);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:punctuationKerning", xdade2366eaa6f.xa7c8accbf82b9f90);
		xe1410f585439c7d.x547195bcc386fe66("w:characterSpacingControl", x89d497a9d94437ea.x7c8ee007a210373d(xdade2366eaa6f.x2b3870f998fa2689));
		xe1410f585439c7d.x9601fe92a1b73d3f("w:printTwoOnOne", xdade2366eaa6f.xb8230cce4c519a2a);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:strictFirstAndLastChars", xdade2366eaa6f.x5478764877a094bc);
		x311bb10d5871a09f.x5d31016f933a128f(xdade2366eaa6f, xe1410f585439c7d, xf2a0216b53787578.xd16e1d14e9bd81a9((int)xdade2366eaa6f.xb63452877389667b, x5fbb1a9c98604ef5: false));
		xbdfb620b7167944b.xf65c32ef4443c2c5(xdade2366eaa6f.xc8949e68d489222b, x28ee2f81ab05fedb: true);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotEmbedSystemFonts", xdade2366eaa6f.x53c2568d1dfe1449);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:showEnvelope", xdade2366eaa6f.xb291c98fcefe576c);
		xe1410f585439c7d.x547195bcc386fe66("w:validateAgainstSchema", xdade2366eaa6f.x0171de9b8f68ad5c);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:saveInvalidXML", xdade2366eaa6f.x3b978168870d58e9);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:ignoreMixedContent", xdade2366eaa6f.x2cc4b92e8cd6e124);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:useXSLTWhenSaving", xdade2366eaa6f.x2c67db9a06eaf625);
		if (x0d299f323d241756.x5959bccb67bbf051(xdade2366eaa6f.x57a3ba5e84591507))
		{
			xe1410f585439c7d.x2307058321cdb62f("w:saveThroughXSLT");
			xe1410f585439c7d.xff520a0047c27122("w:xslt", xdade2366eaa6f.x57a3ba5e84591507);
			xe1410f585439c7d.x2dfde153f4ef96d0();
		}
		xe1410f585439c7d.x9601fe92a1b73d3f("w:optimizeForBrowser", xdade2366eaa6f.x35aefdf519d4db96);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:relyOnVML", xdade2366eaa6f.xc2d62826afc28ce5);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:allowPNG", xdade2366eaa6f.xbd16abbd8b896a52);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotRelyOnCSS", xdade2366eaa6f.x033ad91511e4e3ff);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotSaveWebPagesAsSingleFile", xdade2366eaa6f.x82cbf79051b7e083);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotOrganizeInFolder", xdade2366eaa6f.x43d1e7077fb85de6);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotUseLongFileNames", xdade2366eaa6f.x117cfa28c87eba97);
		if (xdade2366eaa6f.x1115d25f593044ad != 96)
		{
			xe1410f585439c7d.x547195bcc386fe66("w:pixelsPerInch", xdade2366eaa6f.x1115d25f593044ad);
		}
		if (xdade2366eaa6f.x86698283e3eda37c != x6cb5c57047e5f82d.xc56403b89ed080af)
		{
			xe1410f585439c7d.x547195bcc386fe66("w:targetScreenSz", x72a0c846678ecaf9.x485cb0bb4326c4bb(xdade2366eaa6f.x86698283e3eda37c));
		}
		xe1410f585439c7d.x9601fe92a1b73d3f("w:alwaysMergeEmptyNamespace", xdade2366eaa6f.xf53b772003bc9d00);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:alwaysShowPlaceholderText", xdade2366eaa6f.x6980630e657b6aad);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:autoFormatOverride", xdade2366eaa6f.xcadc354ab6a177f1.x84a58b01dbef401d);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:bookFoldPrinting", xdade2366eaa6f.x6116d416354a4a7e);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:bookFoldRevPrinting", xdade2366eaa6f.xcb55fa1ad5b5e650);
		if (xdade2366eaa6f.x6116d416354a4a7e || xdade2366eaa6f.xcb55fa1ad5b5e650)
		{
			xe1410f585439c7d.x547195bcc386fe66("w:bookFoldPrintingSheets", xdade2366eaa6f.xf62aa4c5d803502a);
		}
		xe1410f585439c7d.x9601fe92a1b73d3f("w:doNotUnderlineInvalidXML", xdade2366eaa6f.x02b20ac01ba667b2);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:linkStyles", xdade2366eaa6f.x25c2aa42b1eb10e5);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:printFractionalCharacterWidth", xdade2366eaa6f.x058f26e482f9ecb6);
		xe1410f585439c7d.x9601fe92a1b73d3f("w:printPostScriptOverText", xdade2366eaa6f.x4bf1c3bb4f850306);
		xcf4003bdb69a9052(xdade2366eaa6f.xe322902ca0e695f5, xe1410f585439c7d);
		xb3bdeab732951a66(document.Variables, xe1410f585439c7d);
		xe1410f585439c7d.x2dfde153f4ef96d0();
	}

	private static void x4252174a1e986985(ViewOptions xb12ae014b6f5e89a, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w:zoom");
		if (xb12ae014b6f5e89a.ZoomType != 0)
		{
			xd07ce4b74c5774a7.x943f6be3acf634db("w:val", x89d497a9d94437ea.xd9c235163fb5784d(xb12ae014b6f5e89a.ZoomType));
		}
		xd07ce4b74c5774a7.x943f6be3acf634db("w:percent", xb12ae014b6f5e89a.ZoomPercent);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void x0cd33fe10bad39b1(xdade2366eaa6f915 xe31d35d3e8fc8bf2, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.xc049ea80ee267201("w:proofState", "w:spelling", x89d497a9d94437ea.x82ba73c90bb53986(xe31d35d3e8fc8bf2.xf0881e4627ae16f9), "w:grammar", x89d497a9d94437ea.x82ba73c90bb53986(xe31d35d3e8fc8bf2.x2ee91d7d1f22f253));
	}

	private static void x848e271d45c6375c(xcadc354ab6a177f1 xbf3f761806abd61b, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		if (xbf3f761806abd61b.x5410a63599038a04 != ProtectionType.NoProtection)
		{
			xd07ce4b74c5774a7.x2307058321cdb62f("w:documentProtection");
			xd07ce4b74c5774a7.x943f6be3acf634db("w:edit", x89d497a9d94437ea.xc1e87f93efd4bfbb(xbf3f761806abd61b.x5410a63599038a04));
			xd07ce4b74c5774a7.x0ea3ef8dd3ae2f3f("w:formatting", xbf3f761806abd61b.x4eae8f1c9ec0d2ae);
			xd07ce4b74c5774a7.x0ea3ef8dd3ae2f3f("w:enforcement", xbf3f761806abd61b.x0cbff01514c02c1b);
			xd07ce4b74c5774a7.x943f6be3acf634db("w:unprotectPassword", xc1b08afa36bf580c.x0d28bf60e577f9e5(xbf3f761806abd61b.xf111d6890e7de382));
			xd07ce4b74c5774a7.x2dfde153f4ef96d0();
		}
	}

	private static void xcf4003bdb69a9052(CompatibilityOptions x87b12a2d3f48ccc8, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		xd07ce4b74c5774a7.x2307058321cdb62f("w:compat");
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:origWordTableRules", x87b12a2d3f48ccc8.UseSingleBorderforContiguousCells);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:wpJustification", x87b12a2d3f48ccc8.WPJustification);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:noTabHangInd", x87b12a2d3f48ccc8.NoTabHangInd);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:noLeading", x87b12a2d3f48ccc8.NoLeading);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:spaceForUL", x87b12a2d3f48ccc8.SpaceForUL);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:noColumnBalance", x87b12a2d3f48ccc8.NoColumnBalance);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:balanceSingleByteDoubleByteWidth", x87b12a2d3f48ccc8.BalanceSingleByteDoubleByteWidth);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:transparentMetafiles", x87b12a2d3f48ccc8.TransparentMetafiles);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:noExtraLineSpacing", x87b12a2d3f48ccc8.NoExtraLineSpacing);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:doNotLeaveBackslashAlone", x87b12a2d3f48ccc8.DoNotLeaveBackslashAlone);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:ulTrailSpace", x87b12a2d3f48ccc8.UlTrailSpace);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:doNotExpandShiftReturn", x87b12a2d3f48ccc8.DoNotExpandShiftReturn);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:spacingInWholePoints", x87b12a2d3f48ccc8.SpacingInWholePoints);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:lineWrapLikeWord6", x87b12a2d3f48ccc8.LineWrapLikeWord6);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:printBodyTextBeforeHeader", x87b12a2d3f48ccc8.PrintBodyTextBeforeHeader);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:printColBlack", x87b12a2d3f48ccc8.PrintColBlack);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:wpSpaceWidth", x87b12a2d3f48ccc8.WPSpaceWidth);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:showBreaksInFrames", x87b12a2d3f48ccc8.ShowBreaksInFrames);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:subFontBySize", x87b12a2d3f48ccc8.SubFontBySize);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:suppressBottomSpacing", x87b12a2d3f48ccc8.SuppressBottomSpacing);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:suppressTopSpacing", x87b12a2d3f48ccc8.SuppressTopSpacing);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:suppressTopSpacingMac5", x87b12a2d3f48ccc8.SuppressSpacingAtTopOfPage);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:suppressTopSpacingWP", x87b12a2d3f48ccc8.SuppressTopSpacingWP);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:suppressSpBfAfterPgBrk", x87b12a2d3f48ccc8.SuppressSpBfAfterPgBrk);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:swapBordersFacingPages", x87b12a2d3f48ccc8.SwapBordersFacingPgs);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:convMailMergeEsc", x87b12a2d3f48ccc8.ConvMailMergeEsc);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:truncateFontHeight", x87b12a2d3f48ccc8.TruncateFontHeightsLikeWP6);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:mwSmallCaps", x87b12a2d3f48ccc8.MWSmallCaps);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:usePrinterMetrics", x87b12a2d3f48ccc8.UsePrinterMetrics);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:ww6BorderRules", x87b12a2d3f48ccc8.DoNotSuppressParagraphBorders);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:wrapTrailSpaces", x87b12a2d3f48ccc8.WrapTrailSpaces);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:footnoteLayoutLikeWW8", x87b12a2d3f48ccc8.FootnoteLayoutLikeWW8);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:shapeLayoutLikeWW8", x87b12a2d3f48ccc8.ShapeLayoutLikeWW8);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:alignTablesRowByRow", x87b12a2d3f48ccc8.AlignTablesRowByRow);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:forgetLastTabAlignment", x87b12a2d3f48ccc8.ForgetLastTabAlignment);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:adjustLineHeightInTable", x87b12a2d3f48ccc8.AdjustLineHeightInTable);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:autoSpaceLikeWord95", x87b12a2d3f48ccc8.AutoSpaceLikeWord95);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:noSpaceRaiseLower", x87b12a2d3f48ccc8.NoSpaceRaiseLower);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:doNotUseHTMLParagraphAutoSpacing", x87b12a2d3f48ccc8.DoNotUseHTMLParagraphAutoSpacing);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:layoutRawTableWidth", x87b12a2d3f48ccc8.LayoutRawTableWidth);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:layoutTableRowsApart", x87b12a2d3f48ccc8.LayoutTableRowsApart);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:useWord97LineBreakingRules", x87b12a2d3f48ccc8.UseWord97LineBreakRules);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:breakWrappedTables", !x87b12a2d3f48ccc8.DoNotBreakWrappedTables);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:snapToGridInCell", !x87b12a2d3f48ccc8.DoNotSnapToGridInCell);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:dontAllowFieldEndSelect", x87b12a2d3f48ccc8.SelectFldWithFirstOrLastChar);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:applyBreakingRules", x87b12a2d3f48ccc8.ApplyBreakingRules);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:wrapTextWithPunct", !x87b12a2d3f48ccc8.DoNotWrapTextWithPunct);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:useAsianBreakRules", !x87b12a2d3f48ccc8.DoNotUseEastAsianBreakRules);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:useWord2002TableStyleRules", x87b12a2d3f48ccc8.UseWord2002TableStyleRules);
		xd07ce4b74c5774a7.x9601fe92a1b73d3f("w:dontGrowAutofit", !x87b12a2d3f48ccc8.GrowAutofit);
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}

	private static void xb3bdeab732951a66(VariableCollection x7c97c8b1642837f7, x873451caae5ad4ae xd07ce4b74c5774a7)
	{
		if (x7c97c8b1642837f7.Count <= 0)
		{
			return;
		}
		xd07ce4b74c5774a7.x2307058321cdb62f("w:docVars");
		foreach (DictionaryEntry item in x7c97c8b1642837f7)
		{
			xd07ce4b74c5774a7.xc049ea80ee267201("w:docVar", "w:name", item.Key.ToString(), "w:val", item.Value.ToString());
		}
		xd07ce4b74c5774a7.x2dfde153f4ef96d0();
	}
}
