using System;
using Aspose.Words;
using Aspose.Words.Settings;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x79578da6a8a3ae37;
using x909757d9fd2dd6ae;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class xa193b87bb5ca0dde
{
	private xa193b87bb5ca0dde()
	{
	}

	internal static void x06b0e25aa6ad68a9(x11e1346c12ead315 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3c85359e1389ad = xe134235b3526fa75.x1b1aeab2a2e668c4("http://schemas.openxmlformats.org/officeDocument/2006/relationships/settings");
		if (x3c85359e1389ad == null)
		{
			return;
		}
		DocumentBase x2c8c6741422a = xe134235b3526fa75.x2c8c6741422a1298;
		xdade2366eaa6f915 xdade2366eaa6f = x2c8c6741422a.xdade2366eaa6f915;
		ViewOptions x17bade2eb7f9764f = xdade2366eaa6f.x17bade2eb7f9764f;
		CompatibilityOptions xe322902ca0e695f = xdade2366eaa6f.xe322902ca0e695f5;
		xdade2366eaa6f.xa7c8accbf82b9f90 = true;
		x17bade2eb7f9764f.ViewType = ViewType.PageLayout;
		while (x3c85359e1389ad.x152cbadbfa8061b1("settings"))
		{
			switch (x3c85359e1389ad.xa66385d80d4d296f)
			{
			case "writeProtection":
				x896a21bc771e42f8(x3c85359e1389ad, xdade2366eaa6f);
				break;
			case "alwaysMergeEmptyNamespace":
				xdade2366eaa6f.xf53b772003bc9d00 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "alwaysShowPlaceholderText":
				xdade2366eaa6f.x6980630e657b6aad = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "autoFormatOverride":
				xdade2366eaa6f.xcadc354ab6a177f1.x84a58b01dbef401d = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "bookFoldPrinting":
				xdade2366eaa6f.x6116d416354a4a7e = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "bookFoldRevPrinting":
				xdade2366eaa6f.xcb55fa1ad5b5e650 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "bookFoldPrintingSheets":
				xdade2366eaa6f.xf62aa4c5d803502a = x3c85359e1389ad.xb8ac33c25776194c();
				break;
			case "embedSystemFonts":
				xdade2366eaa6f.x53c2568d1dfe1449 = !x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "printFractionalCharacterWidth":
				xdade2366eaa6f.x058f26e482f9ecb6 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "printPostScriptOverText":
				xdade2366eaa6f.x4bf1c3bb4f850306 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "removePersonalInformation":
				xdade2366eaa6f.x329a4e432765a448 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "showEnvelope":
				xdade2366eaa6f.xb291c98fcefe576c = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "doNotValidateAgainstSchema":
				xdade2366eaa6f.x0171de9b8f68ad5c = !x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "saveInvalidXml":
				xdade2366eaa6f.x3b978168870d58e9 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "saveXmlDataOnly":
				xdade2366eaa6f.x1a8b9b3f9527c259 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "showXMLTags":
				xdade2366eaa6f.xd9032140ccaf16ca = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "ignoreMixedContent":
				xdade2366eaa6f.x2cc4b92e8cd6e124 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "useXSLTWhenSaving":
				xdade2366eaa6f.x2c67db9a06eaf625 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "saveThroughXslt":
				xdade2366eaa6f.x57a3ba5e84591507 = xe134235b3526fa75.x052a6c2e603b1662(x3c85359e1389ad.xf3ea3ee1c9ee5265());
				break;
			case "view":
				x17bade2eb7f9764f.ViewType = xa4dfc7b68138d280.x21236a732c36a512(x3c85359e1389ad.xbbfc54380705e01e());
				break;
			case "zoom":
				x31675e89f2d245dc(x3c85359e1389ad, x17bade2eb7f9764f);
				break;
			case "doNotDisplayPageBoundaries":
				x17bade2eb7f9764f.DoNotDisplayPageBoundaries = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "displayBackgroundShape":
				x17bade2eb7f9764f.DisplayBackgroundShape = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "printFormsData":
				xdade2366eaa6f.x15b47472ae0f4bf5 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "embedTrueTypeFonts":
				xdade2366eaa6f.x26622336636caa4d = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "saveSubsetFonts":
				xdade2366eaa6f.xacad582ef7f5d121 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "saveFormsData":
				xdade2366eaa6f.xc64ebc14fbb01a1c = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "mirrorMargins":
				xdade2366eaa6f.xd02fc99dc9c3221e = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "alignBordersAndEdges":
				xdade2366eaa6f.xb460e2e11d4e8429 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "bordersDoNotSurroundHeader":
				xdade2366eaa6f.x8af0b297a9d474ad = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "bordersDoNotSurroundFooter":
				xdade2366eaa6f.x636013cbf60f10b8 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "doNotDemarcateInvalidXml":
				xdade2366eaa6f.x02b20ac01ba667b2 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "doNotEmbedSmartTags":
				xdade2366eaa6f.x434c293eda734492 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "gutterAtTop":
				xdade2366eaa6f.xe1c58df4343d599e = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "proofState":
				xe639302235a07825(x3c85359e1389ad, xdade2366eaa6f);
				break;
			case "formsDesign":
				x17bade2eb7f9764f.FormsDesign = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "attachedTemplate":
				xdade2366eaa6f.x8c0ad447fda248da = xe134235b3526fa75.x052a6c2e603b1662(x3c85359e1389ad.xf3ea3ee1c9ee5265());
				break;
			case "linkStyles":
				xdade2366eaa6f.x25c2aa42b1eb10e5 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "documentType":
				xdade2366eaa6f.x5cdb67c2d32f8a3a = xa4dfc7b68138d280.x71012ae2de47dadf(x3c85359e1389ad.xbbfc54380705e01e());
				break;
			case "mailMerge":
				xe122c3c179df9ea0.x06b0e25aa6ad68a9(xe134235b3526fa75, xdade2366eaa6f.xe690cef2446c7d46);
				break;
			case "mathPr":
				xa71cdb48853bf163(x3c85359e1389ad, xdade2366eaa6f.x1c605672f036e9e1);
				break;
			case "styleLockQFSet":
				xdade2366eaa6f.x7c692ff62009f114 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "styleLockTheme":
				xdade2366eaa6f.x8749385938ab4a85 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "stylePaneFormatFilter":
			{
				string xbcea506a33cf = x3c85359e1389ad.xbbfc54380705e01e();
				if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
				{
					xdade2366eaa6f.xfc32bf4854f4898d = xc1b08afa36bf580c.x5c612ff105e66e13(xbcea506a33cf);
				}
				xdade2366eaa6f.x6fa1ff078af722c3 = new x6fa1ff078af722c3(xdade2366eaa6f.xfc32bf4854f4898d);
				x806a9d4510ac6b91(x3c85359e1389ad, xdade2366eaa6f.x6fa1ff078af722c3);
				break;
			}
			case "stylePaneSortMethod":
				xdade2366eaa6f.x9b603ddcf603293d = xa4dfc7b68138d280.x1d97d790ffd781e0(x3c85359e1389ad.xbbfc54380705e01e());
				break;
			case "trackRevisions":
				xdade2366eaa6f.x98c0ec6ac7570a99 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "doNotTrackMoves":
				xdade2366eaa6f.x6747b7bda27e8094 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "documentProtection":
				x91fdcd9aaa8cfb8f(x3c85359e1389ad, xdade2366eaa6f.xcadc354ab6a177f1);
				break;
			case "defaultTabStop":
				xdade2366eaa6f.xd72f9bc5cc53fc1c = x3c85359e1389ad.x714de9655a456160();
				break;
			case "autoHyphenation":
				xdade2366eaa6f.xdf76d3eeb73027d7 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "consecutiveHyphenLimit":
				xdade2366eaa6f.xfaa0f593a0704d95 = x3c85359e1389ad.xb8ac33c25776194c();
				break;
			case "hyphenationZone":
				xdade2366eaa6f.x91faf128d9e0425f = x3c85359e1389ad.x714de9655a456160();
				break;
			case "doNotHyphenateCaps":
				xdade2366eaa6f.xaca8557eea824bc0 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "evenAndOddHeaders":
				xdade2366eaa6f.x5ac0ad056c3fce83 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "drawingGridHorizontalSpacing":
				xdade2366eaa6f.xf0c98b9a5846f66c = x3c85359e1389ad.x714de9655a456160();
				break;
			case "drawingGridVerticalSpacing":
				xdade2366eaa6f.xac305e755359cb11 = x3c85359e1389ad.x714de9655a456160();
				break;
			case "displayHorizontalDrawingGridEvery":
				xdade2366eaa6f.x95a4a50d4ad3f396 = x3c85359e1389ad.xb8ac33c25776194c();
				break;
			case "displayVerticalDrawingGridEvery":
				xdade2366eaa6f.xc731b34015cd8a41 = x3c85359e1389ad.xb8ac33c25776194c();
				break;
			case "doNotUseMarginsForDrawingGridOrigin":
				xdade2366eaa6f.x5a27e3b345b6aa73 = !x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "drawingGridHorizontalOrigin":
				xdade2366eaa6f.x88b1df8cde4d7483 = x3c85359e1389ad.x714de9655a456160();
				break;
			case "drawingGridVerticalOrigin":
				xdade2366eaa6f.xd4d02d35f9fd2c1a = x3c85359e1389ad.x714de9655a456160();
				break;
			case "doNotShadeFormData":
				xdade2366eaa6f.x75c79d4f5c4f8bd1 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "noPunctuationKerning":
				xdade2366eaa6f.xa7c8accbf82b9f90 = !x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "characterSpacingControl":
				xdade2366eaa6f.x2b3870f998fa2689 = xa4dfc7b68138d280.x6b50e51a56595797(x3c85359e1389ad.xbbfc54380705e01e());
				break;
			case "printTwoOnOne":
				xdade2366eaa6f.xb8230cce4c519a2a = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "strictFirstAndLastChars":
				xdade2366eaa6f.x5478764877a094bc = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "noLineBreaksAfter":
				xdade2366eaa6f.x466141be69711980 = x4b02b38270513306(x3c85359e1389ad, xdade2366eaa6f);
				break;
			case "noLineBreaksBefore":
				xdade2366eaa6f.xfc71ac47a3606511 = x4b02b38270513306(x3c85359e1389ad, xdade2366eaa6f);
				break;
			case "footnotePr":
			case "endnotePr":
				xdc71cdfc66231158(x3c85359e1389ad, x3c85359e1389ad.xa66385d80d4d296f, xdade2366eaa6f.xc8949e68d489222b);
				break;
			case "compat":
				x7a885e021080bee3(x3c85359e1389ad, xe322902ca0e695f);
				break;
			case "docVars":
				x14dd67f66e3ba7a5(x3c85359e1389ad, x2c8c6741422a.x8513e2047b99ae50);
				break;
			case "uiCompat97To2003":
				xe322902ca0e695f.UICompat97To2003 = x3c85359e1389ad.xe04906126da94dd1();
				break;
			case "revisionView":
				xe9e4abd8717b527f(x3c85359e1389ad, xdade2366eaa6f);
				break;
			case "themeFontLang":
				xcc15ac5810157ff3(x3c85359e1389ad, xdade2366eaa6f.xfafa4c90da1436a5);
				break;
			case "clrSchemeMapping":
				x3c85359e1389ad.xcd9275cfaac59c99();
				break;
			case "attachedSchema":
				xdade2366eaa6f.xf6915d468ae54ed1.Add(x3c85359e1389ad.xbbfc54380705e01e());
				break;
			case "schemaLibrary":
				x5cc8016b1dac1760(x3c85359e1389ad, xdade2366eaa6f);
				break;
			default:
				x3c85359e1389ad.IgnoreElement();
				break;
			}
		}
		xe134235b3526fa75.xc8ab4e294c74831b();
	}

	private static void x806a9d4510ac6b91(x3c85359e1389ad43 x97bf2eeabd4abc7b, x6fa1ff078af722c3 xb6b3da7953a69f26)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "allStyles":
				xb6b3da7953a69f26.xc496754c334766b3 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "alternateStyleNames":
				xb6b3da7953a69f26.x8f9263bfb9e7f92c = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "clearFormatting":
				xb6b3da7953a69f26.xd624a386058f0afd = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "customStyles":
				xb6b3da7953a69f26.x34d587653660d86b = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "directFormattingOnNumbering":
				xb6b3da7953a69f26.xf2559e592e7a9af5 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "directFormattingOnParagraphs":
				xb6b3da7953a69f26.x46408b303701669f = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "directFormattingOnRuns":
				xb6b3da7953a69f26.x46408b303701669f = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "directFormattingOnTables":
				xb6b3da7953a69f26.xcab45abc77a085d5 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "headingStyles":
				xb6b3da7953a69f26.x920bc0871ab66650 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "latentStyles":
				xb6b3da7953a69f26.x90347bcd8deede01 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "numberingStyles":
				xb6b3da7953a69f26.xb1c23288f17ff767 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "stylesInUse":
				xb6b3da7953a69f26.x519e9145d248e232 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "tableStyles":
				xb6b3da7953a69f26.x41dc878128a87ac3 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "top3HeadingStyles":
				xb6b3da7953a69f26.xf813e32bfaa8982c = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "visibleStyles":
				xb6b3da7953a69f26.x5743277d9b776a74 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			default:
				x97bf2eeabd4abc7b.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Docx, x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private static string x4b02b38270513306(x3c85359e1389ad43 x97bf2eeabd4abc7b, xdade2366eaa6f915 xe31d35d3e8fc8bf2)
	{
		string result = string.Empty;
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "val":
				result = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
				break;
			case "lang":
				xe31d35d3e8fc8bf2.xb63452877389667b = (x448900fcb384c333)xf2a0216b53787578.xae88295ea6bfc819(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, x5fbb1a9c98604ef5: true);
				break;
			default:
				x97bf2eeabd4abc7b.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Docx, x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			}
		}
		return result;
	}

	private static void x5cc8016b1dac1760(x3c85359e1389ad43 x97bf2eeabd4abc7b, xdade2366eaa6f915 xe31d35d3e8fc8bf2)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("schemaLibrary"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) == null || !(xa66385d80d4d296f == "schema"))
			{
				continue;
			}
			xe40873f9fe5f5022 xe40873f9fe5f = new xe40873f9fe5f5022();
			while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
			{
				switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
				{
				case "uri":
					xe40873f9fe5f.xb405a444ca77e2d4 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
					break;
				case "manifestLocation":
					xe40873f9fe5f.x8441ed6b8afd4b93 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
					break;
				case "schemaLocation":
					xe40873f9fe5f.xa6d0aef50ec37518 = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
					break;
				default:
					x97bf2eeabd4abc7b.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Docx, x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
					break;
				case "schemaLanguage":
					break;
				}
			}
			xe31d35d3e8fc8bf2.xba72c3b7f240dac0.xd6b6ed77479ef68c(xe40873f9fe5f);
		}
	}

	private static void xa71cdb48853bf163(x3c85359e1389ad43 x97bf2eeabd4abc7b, x1c605672f036e9e1 x76335127ca565ebf)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("mathPr"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "brkBin":
				x76335127ca565ebf.x3b85abfed6d4424f = xa4dfc7b68138d280.xfaab545f73c7515b(x97bf2eeabd4abc7b.xbbfc54380705e01e());
				break;
			case "brkBinSub":
				x76335127ca565ebf.xb56517bd05ef77f6 = xa4dfc7b68138d280.xafb68785d2e34ba8(x97bf2eeabd4abc7b.xbbfc54380705e01e());
				break;
			case "defJc":
				x76335127ca565ebf.x78266b0e9c142786 = xc62574be95c1c918.x644cb83fa42445a4(x97bf2eeabd4abc7b.xbbfc54380705e01e());
				break;
			case "dispDef":
				x76335127ca565ebf.x92447f7677982e86 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "interSp":
				x76335127ca565ebf.x0adbbc56413a8e57 = x97bf2eeabd4abc7b.x714de9655a456160();
				break;
			case "intLim":
				x76335127ca565ebf.x8b277d8dd2e2d7af = xc62574be95c1c918.xbc8913cc2c4a85ed(x97bf2eeabd4abc7b.xbbfc54380705e01e());
				break;
			case "intraSp":
				x76335127ca565ebf.x2c78840c9608859b = x97bf2eeabd4abc7b.x714de9655a456160();
				break;
			case "lMargin":
				x76335127ca565ebf.xc8a7b7ce5c5279ee = x97bf2eeabd4abc7b.x714de9655a456160();
				break;
			case "mathFont":
				x76335127ca565ebf.xddffcb24e864cfcc = x97bf2eeabd4abc7b.xbbfc54380705e01e();
				break;
			case "naryLim":
				x76335127ca565ebf.x07f824b6513692d8 = xc62574be95c1c918.xbc8913cc2c4a85ed(x97bf2eeabd4abc7b.xbbfc54380705e01e());
				break;
			case "postSp":
				x76335127ca565ebf.x4a1d08cff27d9916 = x97bf2eeabd4abc7b.x714de9655a456160();
				break;
			case "preSp":
				x76335127ca565ebf.xb2853935633b60e2 = x97bf2eeabd4abc7b.x714de9655a456160();
				break;
			case "rMargin":
				x76335127ca565ebf.x3fa6fa3075fd558f = x97bf2eeabd4abc7b.x714de9655a456160();
				break;
			case "smallFrac":
				x76335127ca565ebf.xaf8d6a43346515c6 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "wrapIndent":
				x76335127ca565ebf.x3810b9f8f9111f8a = x97bf2eeabd4abc7b.x714de9655a456160();
				break;
			case "wrapRight":
				x76335127ca565ebf.x11227fd74d91663d = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}

	private static void x31675e89f2d245dc(x3c85359e1389ad43 x97bf2eeabd4abc7b, ViewOptions xb12ae014b6f5e89a)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "val":
				xb12ae014b6f5e89a.ZoomType = xa4dfc7b68138d280.xbfac763c15626116(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			case "percent":
				xb12ae014b6f5e89a.ZoomPercent = x97bf2eeabd4abc7b.xf2f856bffb5c6cf3(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private static void xe639302235a07825(x3c85359e1389ad43 x97bf2eeabd4abc7b, xdade2366eaa6f915 xe31d35d3e8fc8bf2)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "spelling":
				xe31d35d3e8fc8bf2.xf0881e4627ae16f9 = xa4dfc7b68138d280.xb306b6511dc6b3ee(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			case "grammar":
				xe31d35d3e8fc8bf2.x2ee91d7d1f22f253 = xa4dfc7b68138d280.xb306b6511dc6b3ee(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			}
		}
	}

	private static void x896a21bc771e42f8(x3c85359e1389ad43 x97bf2eeabd4abc7b, xdade2366eaa6f915 xe31d35d3e8fc8bf2)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "recommended")
			{
				xe31d35d3e8fc8bf2.xc57807e17cfa13d2.ReadOnlyRecommended = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
			}
			else
			{
				x781bc0529a04e0df(x97bf2eeabd4abc7b, xe31d35d3e8fc8bf2.xc57807e17cfa13d2.x218603e609fcc201);
			}
		}
	}

	private static void x91fdcd9aaa8cfb8f(x3c85359e1389ad43 x97bf2eeabd4abc7b, xcadc354ab6a177f1 xbf3f761806abd61b)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "edit":
				xbf3f761806abd61b.x5410a63599038a04 = xa4dfc7b68138d280.x519727c4405dc705(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
				break;
			case "formatting":
				xbf3f761806abd61b.x4eae8f1c9ec0d2ae = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "enforcement":
				xbf3f761806abd61b.x0cbff01514c02c1b = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			default:
				x781bc0529a04e0df(x97bf2eeabd4abc7b, xbf3f761806abd61b.x218603e609fcc201);
				break;
			}
		}
	}

	private static void x781bc0529a04e0df(x3c85359e1389ad43 x97bf2eeabd4abc7b, x218603e609fcc201 x4cf087e9fa308673)
	{
		switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
		{
		case "cryptAlgorithmSid":
			x4cf087e9fa308673.xc69c1bca8baaf933 = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
			break;
		case "algorithmName":
			x4cf087e9fa308673.xc69c1bca8baaf933 = x218603e609fcc201.x33df0e9a6206a982(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
			break;
		case "cryptSpinCount":
		case "spinCount":
			x4cf087e9fa308673.xe45f03ec1cfa61ea = x97bf2eeabd4abc7b.xbba6773b8ce56a01;
			break;
		case "hash":
		case "hashValue":
			x4cf087e9fa308673.xf35aae0fa4a217a4 = Convert.FromBase64String(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
			break;
		case "salt":
		case "saltValue":
			x4cf087e9fa308673.x005dbd4d94ca4423 = Convert.FromBase64String(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb);
			break;
		case "cryptProviderType":
		case "cryptAlgorithmClass":
		case "cryptAlgorithmType":
			break;
		}
	}

	private static void x7a885e021080bee3(x3c85359e1389ad43 x97bf2eeabd4abc7b, CompatibilityOptions xf8db83af629654c9)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("compat"))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "adjustLineHeightInTable":
				xf8db83af629654c9.AdjustLineHeightInTable = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "alignTablesRowByRow":
				xf8db83af629654c9.AlignTablesRowByRow = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "allowSpaceOfSameStyleInTable":
				xf8db83af629654c9.AllowSpaceOfSameStyleInTable = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "applyBreakingRules":
				xf8db83af629654c9.ApplyBreakingRules = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "autofitToFirstFixedWidthCell":
				xf8db83af629654c9.AutofitToFirstFixedWidthCell = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "autoSpaceLikeWord95":
				xf8db83af629654c9.AutoSpaceLikeWord95 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "balanceSingleByteDoubleByteWidth":
				xf8db83af629654c9.BalanceSingleByteDoubleByteWidth = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "cachedColBalance":
				xf8db83af629654c9.CachedColBalance = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "convMailMergeEsc":
				xf8db83af629654c9.ConvMailMergeEsc = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "displayHangulFixedWidth":
				xf8db83af629654c9.DisplayHangulFixedWidth = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotAutofitConstrainedTables":
				xf8db83af629654c9.DoNotAutofitConstrainedTables = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotBreakConstrainedForcedTable":
				xf8db83af629654c9.DoNotBreakConstrainedForcedTable = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotBreakWrappedTables":
				xf8db83af629654c9.DoNotBreakWrappedTables = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotExpandShiftReturn":
				xf8db83af629654c9.DoNotExpandShiftReturn = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotLeaveBackslashAlone":
				xf8db83af629654c9.DoNotLeaveBackslashAlone = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotSnapToGridInCell":
				xf8db83af629654c9.DoNotSnapToGridInCell = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotSuppressIndentation":
				xf8db83af629654c9.DoNotSuppressIndentation = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotSuppressParagraphBorders":
				xf8db83af629654c9.DoNotSuppressParagraphBorders = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotUseEastAsianBreakRules":
				xf8db83af629654c9.DoNotUseEastAsianBreakRules = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotUseHTMLParagraphAutoSpacing":
				xf8db83af629654c9.DoNotUseHTMLParagraphAutoSpacing = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotUseIndentAsNumberingTabStop":
				xf8db83af629654c9.DoNotUseIndentAsNumberingTabStop = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotVertAlignCellWithSp":
				xf8db83af629654c9.DoNotVertAlignCellWithSp = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotVertAlignInTxbx":
				xf8db83af629654c9.DoNotVertAlignInTxbx = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "doNotWrapTextWithPunct":
				xf8db83af629654c9.DoNotWrapTextWithPunct = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "footnoteLayoutLikeWW8":
				xf8db83af629654c9.FootnoteLayoutLikeWW8 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "forgetLastTabAlignment":
				xf8db83af629654c9.ForgetLastTabAlignment = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "growAutofit":
				xf8db83af629654c9.GrowAutofit = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "layoutRawTableWidth":
				xf8db83af629654c9.LayoutRawTableWidth = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "layoutTableRowsApart":
				xf8db83af629654c9.LayoutTableRowsApart = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "lineWrapLikeWord6":
				xf8db83af629654c9.LineWrapLikeWord6 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "mwSmallCaps":
				xf8db83af629654c9.MWSmallCaps = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "noColumnBalance":
				xf8db83af629654c9.NoColumnBalance = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "noExtraLineSpacing":
				xf8db83af629654c9.NoExtraLineSpacing = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "noLeading":
				xf8db83af629654c9.NoLeading = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "noSpaceRaiseLower":
				xf8db83af629654c9.NoSpaceRaiseLower = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "noTabHangInd":
				xf8db83af629654c9.NoTabHangInd = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "printBodyTextBeforeHeader":
				xf8db83af629654c9.PrintBodyTextBeforeHeader = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "printColBlack":
				xf8db83af629654c9.PrintColBlack = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "selectFldWithFirstOrLastChar":
				xf8db83af629654c9.SelectFldWithFirstOrLastChar = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "shapeLayoutLikeWW8":
				xf8db83af629654c9.ShapeLayoutLikeWW8 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "showBreaksInFrames":
				xf8db83af629654c9.ShowBreaksInFrames = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "spaceForUL":
				xf8db83af629654c9.SpaceForUL = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "spacingInWholePoints":
				xf8db83af629654c9.SpacingInWholePoints = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "splitPgBreakAndParaMark":
				xf8db83af629654c9.SplitPgBreakAndParaMark = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "subFontBySize":
				xf8db83af629654c9.SubFontBySize = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "suppressBottomSpacing":
				xf8db83af629654c9.SuppressBottomSpacing = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "suppressSpacingAtTopOfPage":
				xf8db83af629654c9.SuppressSpacingAtTopOfPage = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "suppressSpBfAfterPgBrk":
				xf8db83af629654c9.SuppressSpBfAfterPgBrk = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "suppressTopSpacing":
				xf8db83af629654c9.SuppressTopSpacing = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "suppressTopSpacingWP":
				xf8db83af629654c9.SuppressTopSpacingWP = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "swapBordersFacingPages":
				xf8db83af629654c9.SwapBordersFacingPgs = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "truncateFontHeightsLikeWP6":
				xf8db83af629654c9.TruncateFontHeightsLikeWP6 = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "ulTrailSpace":
				xf8db83af629654c9.UlTrailSpace = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "underlineTabInNumList":
				xf8db83af629654c9.UnderlineTabInNumList = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "useAltKinsokuLineBreakRules":
				xf8db83af629654c9.UseAltKinsokuLineBreakRules = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "useAnsiKerningPairs":
				xf8db83af629654c9.UseAnsiKerningPairs = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "useFELayout":
				xf8db83af629654c9.UseFELayout = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "useNormalStyleForList":
				xf8db83af629654c9.UseNormalStyleForList = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "usePrinterMetrics":
				xf8db83af629654c9.UsePrinterMetrics = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "useSingleBorderforContiguousCells":
				xf8db83af629654c9.UseSingleBorderforContiguousCells = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "useWord2002TableStyleRules":
				xf8db83af629654c9.UseWord2002TableStyleRules = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "useWord97LineBreakRules":
				xf8db83af629654c9.UseWord97LineBreakRules = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "wpJustification":
				xf8db83af629654c9.WPJustification = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "wpSpaceWidth":
				xf8db83af629654c9.WPSpaceWidth = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "wrapTrailSpaces":
				xf8db83af629654c9.WrapTrailSpaces = x97bf2eeabd4abc7b.xe04906126da94dd1();
				break;
			case "compatSetting":
				xd0f4399d8bb71d81(xf8db83af629654c9, x97bf2eeabd4abc7b);
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}

	private static void xd0f4399d8bb71d81(CompatibilityOptions xf8db83af629654c9, x3c85359e1389ad43 x97bf2eeabd4abc7b)
	{
		string name = "";
		string uri = "";
		string value = "";
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "name":
				name = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
				break;
			case "uri":
				uri = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
				break;
			case "val":
				value = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
				break;
			}
		}
		xf8db83af629654c9.x1ba69e6683d9effc.xd6b6ed77479ef68c(new x4e1b8abc07d6c49d(name, uri, value));
	}

	private static void x14dd67f66e3ba7a5(x3c85359e1389ad43 x97bf2eeabd4abc7b, VariableCollection x6ff9fb6dd2f96576)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("docVars"))
		{
			if (x97bf2eeabd4abc7b.xa66385d80d4d296f == "docVar")
			{
				string text = null;
				string value = null;
				while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
				{
					switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
					{
					case "name":
						text = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
						break;
					case "val":
						value = x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb;
						break;
					}
				}
				if (text != null)
				{
					x6ff9fb6dd2f96576.Add(text, value);
				}
			}
			else if (x97bf2eeabd4abc7b.xa66385d80d4d296f == "docVars")
			{
				x14dd67f66e3ba7a5(x97bf2eeabd4abc7b, x6ff9fb6dd2f96576);
			}
			else
			{
				x97bf2eeabd4abc7b.IgnoreElement();
			}
		}
	}

	private static void xe9e4abd8717b527f(x3c85359e1389ad43 x97bf2eeabd4abc7b, xdade2366eaa6f915 xe31d35d3e8fc8bf2)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "comments":
				xe31d35d3e8fc8bf2.x445faafef4d65da6 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "formatting":
				xe31d35d3e8fc8bf2.x78187b055ec235b4 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "inkAnnotations":
				xe31d35d3e8fc8bf2.x809d83e59e8bfabb = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "insDel":
				xe31d35d3e8fc8bf2.x4fa98f9c55cbae19 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			case "markup":
				xe31d35d3e8fc8bf2.xf858f41dbb36ed12 = x97bf2eeabd4abc7b.xc3be6b142c6aca84;
				break;
			}
		}
	}

	internal static void xdc71cdfc66231158(x3c85359e1389ad43 x97bf2eeabd4abc7b, string x4c12babe29167a55, x4c1e058c67948d6a xe9707cb1ec88db49)
	{
		int num = ((x4c12babe29167a55 == "endnotePr") ? 100 : 0);
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1(x4c12babe29167a55))
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "pos":
				xe9707cb1ec88db49.xae20093bed1e48a8(2500 + num, x93625b0e8808b0cc.xca6198d7a4a5b555(x97bf2eeabd4abc7b.xbbfc54380705e01e()));
				break;
			case "numFmt":
				xe9707cb1ec88db49.xae20093bed1e48a8(2530 + num, xc62574be95c1c918.x5dabea7b873aecb0(x97bf2eeabd4abc7b.xbbfc54380705e01e()));
				break;
			case "numStart":
				xe9707cb1ec88db49.xae20093bed1e48a8(2520 + num, x97bf2eeabd4abc7b.xb8ac33c25776194c());
				break;
			case "numRestart":
				xe9707cb1ec88db49.xae20093bed1e48a8(2510 + num, x93625b0e8808b0cc.x9bf4da22006dc80e(x97bf2eeabd4abc7b.xbbfc54380705e01e()));
				break;
			case "footnote":
			case "endnote":
				x97bf2eeabd4abc7b.xcd9275cfaac59c99();
				break;
			default:
				x97bf2eeabd4abc7b.IgnoreElement();
				break;
			}
		}
	}

	private static void xcc15ac5810157ff3(x3c85359e1389ad43 x97bf2eeabd4abc7b, xfafa4c90da1436a5 x09629217d911c27e)
	{
		while (x97bf2eeabd4abc7b.x1ac1960adc8c4c39())
		{
			switch (x97bf2eeabd4abc7b.xa66385d80d4d296f)
			{
			case "bidi":
				x09629217d911c27e.xcedf9c82728ad579 = (x448900fcb384c333)xf2a0216b53787578.xae88295ea6bfc819(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, x5fbb1a9c98604ef5: true);
				break;
			case "eastAsia":
				x09629217d911c27e.x5f503f1ab9a38748 = (x448900fcb384c333)xf2a0216b53787578.xae88295ea6bfc819(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, x5fbb1a9c98604ef5: true);
				break;
			case "val":
				x09629217d911c27e.x94edc0d9bd2a8401 = (x448900fcb384c333)xf2a0216b53787578.xae88295ea6bfc819(x97bf2eeabd4abc7b.xd2f68ee6f47e9dfb, x5fbb1a9c98604ef5: true);
				break;
			}
		}
	}
}
