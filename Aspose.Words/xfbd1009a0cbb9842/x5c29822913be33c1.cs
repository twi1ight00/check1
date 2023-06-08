using System;
using System.Collections;
using Aspose.Words;
using Aspose.Words.Fields;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace xfbd1009a0cbb9842;

internal class x5c29822913be33c1
{
	private static readonly Hashtable xf7266aceb71249ff;

	internal static bool x6caf38183f332e86(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldNumPages:
		case FieldType.FieldPage:
		case FieldType.FieldPageRef:
		case FieldType.FieldSectionPages:
			return true;
		default:
			return false;
		}
	}

	internal static bool x04b61a8a6225198f(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldNone:
		case FieldType.FieldIndex:
		case FieldType.FieldTOC:
		case FieldType.FieldIncludeText:
		case FieldType.FieldTOA:
			return false;
		default:
			return true;
		}
	}

	internal static xcf417e2db4fe9ed3 x48ccce05802169c7(Field xe01ae93d9fe5a880)
	{
		if (xe01ae93d9fe5a880.x58daf9beaf8b1ae0())
		{
			return xcf417e2db4fe9ed3.x290a7f421b080483;
		}
		switch (xe01ae93d9fe5a880.Type)
		{
		case FieldType.FieldRef:
		{
			x730be1b1b0b78790 x730be1b1b0b78791 = (x730be1b1b0b78790)xe01ae93d9fe5a880;
			if (!x730be1b1b0b78791.x7ed59aa9825cfe0a && !x730be1b1b0b78791.x53d17e1647f72ed6 && !x730be1b1b0b78791.x72a9ca80a9b7f658)
			{
				return xcf417e2db4fe9ed3.xa370a6f48a445ff9;
			}
			return xcf417e2db4fe9ed3.x5a360e1cee7f2c61;
		}
		case FieldType.FieldStyleRef:
		case FieldType.FieldTOC:
			return xcf417e2db4fe9ed3.x5a360e1cee7f2c61;
		default:
			return xcf417e2db4fe9ed3.xa370a6f48a445ff9;
		}
	}

	internal static bool x3bb982278b787f27(FieldType x77ce91e5324df734)
	{
		if (x77ce91e5324df734 == FieldType.FieldIf)
		{
			return true;
		}
		return false;
	}

	internal static bool xc53b1fb81a461c42(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldIndexEntry:
		case FieldType.FieldTOCEntry:
		case FieldType.FieldRefDoc:
		case FieldType.FieldTOAEntry:
		case FieldType.FieldPrivate:
			return true;
		default:
			return false;
		}
	}

	internal static bool x7f8b7c1c90735bcf(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldFormTextInput:
		case FieldType.FieldFormCheckBox:
		case FieldType.FieldFormDropDown:
			return true;
		default:
			return false;
		}
	}

	internal static bool x4880d896f2583270(FieldType x77ce91e5324df734)
	{
		if (x77ce91e5324df734 == FieldType.FieldRef || x77ce91e5324df734 == FieldType.FieldPageRef || x77ce91e5324df734 == FieldType.FieldNoteRef)
		{
			return true;
		}
		return false;
	}

	internal static FieldType x338a5159d9aa7162(string x0e59413709b18038)
	{
		x0e59413709b18038 = x0e59413709b18038.Trim().ToUpper();
		if (!x0d299f323d241756.x5959bccb67bbf051(x0e59413709b18038))
		{
			return FieldType.FieldNone;
		}
		if (x0e59413709b18038[0] == '=')
		{
			return FieldType.FieldFormula;
		}
		for (int i = 0; i < x0e59413709b18038.Length; i++)
		{
			if (!char.IsLetter(x0e59413709b18038[i]))
			{
				x0e59413709b18038 = x0e59413709b18038.Substring(0, i);
				break;
			}
		}
		if (xf7266aceb71249ff[x0e59413709b18038] != null)
		{
			return (FieldType)xf7266aceb71249ff[x0e59413709b18038];
		}
		return FieldType.FieldNone;
	}

	internal static FieldType x3cfb5b1d26d86f4a(string x0e59413709b18038)
	{
		FieldType fieldType = x338a5159d9aa7162(x0e59413709b18038);
		if (fieldType != 0)
		{
			return fieldType;
		}
		throw new InvalidOperationException(string.Format(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cngmcpnmloenpolneoconjjonnapgohpinopgnfaoimacjdbdokbfjbcpnicgipcmhgdcmndjmeedhlejlcflljfamagikhgalogkkfhckmhlfdihkkihkbjcfijnjpjljgknjnkgeelgjllfjcmnijmkiangihngionfifodhmopgdpgdkp", 1875035788)), x0e59413709b18038));
	}

	internal static x5576a2206c3fc746 xd668adf9377c05ee(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldPrint:
		case FieldType.FieldGoToButton:
		case FieldType.FieldMacroButton:
		case FieldType.FieldAutoNumOutline:
		case FieldType.FieldAutoNumLegal:
		case FieldType.FieldAutoNum:
		case FieldType.FieldSymbol:
		case FieldType.FieldFormCheckBox:
		case FieldType.FieldFormDropDown:
		case FieldType.FieldAdvance:
		case FieldType.FieldListNum:
		case FieldType.FieldBidiOutline:
			return x5576a2206c3fc746.xf99e3386924fbeb6;
		case FieldType.FieldNone:
		case FieldType.FieldNext:
		case FieldType.FieldNextIf:
		case FieldType.FieldSkipIf:
			return x5576a2206c3fc746.xa84e6a80f55a63d3;
		default:
			if (xc53b1fb81a461c42(x77ce91e5324df734))
			{
				return x5576a2206c3fc746.xf99e3386924fbeb6;
			}
			return x5576a2206c3fc746.xd4d82c4665f71358;
		}
	}

	internal static bool xb2cdffc8e47588c8(FieldType x77ce91e5324df734)
	{
		if (x77ce91e5324df734 == FieldType.FieldSet || x77ce91e5324df734 == FieldType.FieldAsk)
		{
			return true;
		}
		return false;
	}

	internal static bool x5eaa4d0262a0cf5d(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldNext:
		case FieldType.FieldNextIf:
		case FieldType.FieldSkipIf:
		case FieldType.FieldMergeRec:
		case FieldType.FieldMergeField:
		case FieldType.FieldMergeSeq:
		case FieldType.FieldAddressBlock:
		case FieldType.FieldGreetingLine:
			return true;
		default:
			return false;
		}
	}

	internal static bool xa3cf2f66fe7bf817(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldCreateDate:
		case FieldType.FieldSaveDate:
		case FieldType.FieldPrintDate:
		case FieldType.FieldDate:
		case FieldType.FieldTime:
			return true;
		default:
			return false;
		}
	}

	internal static string x130349ecd69ef30b(FieldSeparator xed9a565596a6ae3f)
	{
		FieldStart fieldStart = (FieldStart)xed9a565596a6ae3f.x10b66a8c4aa7ed78(NodeType.FieldStart);
		FieldEnd fieldEnd = (FieldEnd)xed9a565596a6ae3f.x03a9a1b8afdf52f9(NodeType.FieldEnd);
		if (fieldStart != null && fieldEnd != null)
		{
			Field field = x3759c06a3a4cf5d1.x43fef3435fba7a66(fieldStart, xed9a565596a6ae3f, fieldEnd);
			if (field != null && field.xb452e2ee706d7a67.xcc2d426b867d703d("\\h"))
			{
				return field.xb452e2ee706d7a67.x642e37025c67edab(0);
			}
		}
		return null;
	}

	internal static int x4c08ecbb32dcf8cd(string x0e59413709b18038)
	{
		return x4c08ecbb32dcf8cd(x338a5159d9aa7162(x0e59413709b18038));
	}

	internal static int x4c08ecbb32dcf8cd(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldGoToButton:
		case FieldType.FieldMacroButton:
			return 1;
		default:
			return -1;
		}
	}

	internal static bool xbe3a0f5f2b0d8ea2(FieldType x77ce91e5324df734)
	{
		switch (x77ce91e5324df734)
		{
		case FieldType.FieldIf:
		case FieldType.FieldIncludePicture:
		case FieldType.FieldIncludeText:
			return true;
		default:
			return false;
		}
	}

	internal static bool xdd6a5784f801bb64(Field xe01ae93d9fe5a880)
	{
		if (xd668adf9377c05ee(xe01ae93d9fe5a880.Type) == x5576a2206c3fc746.xf99e3386924fbeb6)
		{
			return false;
		}
		string x19218ffab70283ef = xe01ae93d9fe5a880.xa890d2fd18bed2bc.xcb95a4eb398e8796.xe4f99d01c82052fc();
		return x0d299f323d241756.x90637a473b1ceaaa(x19218ffab70283ef, "mergeformat");
	}

	internal static bool x5580509afa07e28e(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\#":
		case "\\@":
			return true;
		default:
			return false;
		}
	}

	internal static bool x94810e522c4505da(string x724fbd227bfb6eda)
	{
		switch (x724fbd227bfb6eda)
		{
		case "\\#":
		case "\\@":
		case "\\*":
			return true;
		default:
			return false;
		}
	}

	internal static bool x65acaa0a43cc4d6c(Field xe01ae93d9fe5a880)
	{
		if (xe01ae93d9fe5a880.Type == FieldType.FieldIncludeText)
		{
			return !((x7eb306b7b40a0fd7)xe01ae93d9fe5a880).x72276a1e9d3609b7;
		}
		return false;
	}

	static x5c29822913be33c1()
	{
		xf7266aceb71249ff = new Hashtable();
		xf7266aceb71249ff.Add("=", FieldType.FieldFormula);
		xf7266aceb71249ff.Add("ADDIN", FieldType.FieldAddin);
		xf7266aceb71249ff.Add("ADDRESSBLOCK", FieldType.FieldAddressBlock);
		xf7266aceb71249ff.Add("ADVANCE", FieldType.FieldAdvance);
		xf7266aceb71249ff.Add("ASK", FieldType.FieldAsk);
		xf7266aceb71249ff.Add("AUTHOR", FieldType.FieldAuthor);
		xf7266aceb71249ff.Add("AUTONUM", FieldType.FieldAutoNum);
		xf7266aceb71249ff.Add("AUTONUMLGL", FieldType.FieldAutoNumLegal);
		xf7266aceb71249ff.Add("AUTONUMOUT", FieldType.FieldAutoNumOutline);
		xf7266aceb71249ff.Add("AUTOTEXT", FieldType.FieldAutoText);
		xf7266aceb71249ff.Add("AUTOTEXTLIST", FieldType.FieldAutoTextList);
		xf7266aceb71249ff.Add("BARCODE", FieldType.FieldBarCode);
		xf7266aceb71249ff.Add("BIDIOUTLINE", FieldType.FieldBidiOutline);
		xf7266aceb71249ff.Add("COMMENTS", FieldType.FieldComments);
		xf7266aceb71249ff.Add("COMPARE", FieldType.FieldCompare);
		xf7266aceb71249ff.Add("CREATEDATE", FieldType.FieldCreateDate);
		xf7266aceb71249ff.Add("DATA", FieldType.FieldData);
		xf7266aceb71249ff.Add("DATABASE", FieldType.FieldDatabase);
		xf7266aceb71249ff.Add("DATE", FieldType.FieldDate);
		xf7266aceb71249ff.Add("DDE", FieldType.FieldDDE);
		xf7266aceb71249ff.Add("DDEAUTO", FieldType.FieldDDEAuto);
		xf7266aceb71249ff.Add("DOCPROPERTY", FieldType.FieldDocProperty);
		xf7266aceb71249ff.Add("DOCVARIABLE", FieldType.FieldDocVariable);
		xf7266aceb71249ff.Add("EDITTIME", FieldType.FieldEditTime);
		xf7266aceb71249ff.Add("EMBED", FieldType.FieldEmbed);
		xf7266aceb71249ff.Add("EQ", FieldType.FieldEquation);
		xf7266aceb71249ff.Add("FILENAME", FieldType.FieldFileName);
		xf7266aceb71249ff.Add("FILESIZE", FieldType.FieldFileSize);
		xf7266aceb71249ff.Add("FILLIN", FieldType.FieldFillIn);
		xf7266aceb71249ff.Add("FOOTNOTEREF", FieldType.FieldFootnoteRef);
		xf7266aceb71249ff.Add("FORMTEXT", FieldType.FieldFormTextInput);
		xf7266aceb71249ff.Add("FORMCHECKBOX", FieldType.FieldFormCheckBox);
		xf7266aceb71249ff.Add("FORMDROPDOWN", FieldType.FieldFormDropDown);
		xf7266aceb71249ff.Add("GOTOBUTTON", FieldType.FieldGoToButton);
		xf7266aceb71249ff.Add("GREETINGLINE", FieldType.FieldGreetingLine);
		xf7266aceb71249ff.Add("HYPERLINK", FieldType.FieldHyperlink);
		xf7266aceb71249ff.Add("IF", FieldType.FieldIf);
		xf7266aceb71249ff.Add("INCLUDE", FieldType.FieldInclude);
		xf7266aceb71249ff.Add("INCLUDEPICTURE", FieldType.FieldIncludePicture);
		xf7266aceb71249ff.Add("INCLUDETEXT", FieldType.FieldIncludeText);
		xf7266aceb71249ff.Add("INDEX", FieldType.FieldIndex);
		xf7266aceb71249ff.Add("INFO", FieldType.FieldInfo);
		xf7266aceb71249ff.Add("KEYWORDS", FieldType.FieldKeyword);
		xf7266aceb71249ff.Add("LASTSAVEDBY", FieldType.FieldLastSavedBy);
		xf7266aceb71249ff.Add("LINK", FieldType.FieldLink);
		xf7266aceb71249ff.Add("LISTNUM", FieldType.FieldListNum);
		xf7266aceb71249ff.Add("MACROBUTTON", FieldType.FieldMacroButton);
		xf7266aceb71249ff.Add("MERGEFIELD", FieldType.FieldMergeField);
		xf7266aceb71249ff.Add("MERGEREC", FieldType.FieldMergeRec);
		xf7266aceb71249ff.Add("MERGESEQ", FieldType.FieldMergeSeq);
		xf7266aceb71249ff.Add("NEXT", FieldType.FieldNext);
		xf7266aceb71249ff.Add("NEXTIF", FieldType.FieldNextIf);
		xf7266aceb71249ff.Add("NOTEREF", FieldType.FieldNoteRef);
		xf7266aceb71249ff.Add("NUMCHARS", FieldType.FieldNumChars);
		xf7266aceb71249ff.Add("NUMPAGES", FieldType.FieldNumPages);
		xf7266aceb71249ff.Add("NUMWORDS", FieldType.FieldNumWords);
		xf7266aceb71249ff.Add("OCX", FieldType.FieldOcx);
		xf7266aceb71249ff.Add("PAGE", FieldType.FieldPage);
		xf7266aceb71249ff.Add("PAGEREF", FieldType.FieldPageRef);
		xf7266aceb71249ff.Add("PRINT", FieldType.FieldPrint);
		xf7266aceb71249ff.Add("PRINTDATE", FieldType.FieldPrintDate);
		xf7266aceb71249ff.Add("PRIVATE", FieldType.FieldPrivate);
		xf7266aceb71249ff.Add("PRIVE", FieldType.FieldPrivate);
		xf7266aceb71249ff.Add("PRIVATESPAN", FieldType.FieldPrivate);
		xf7266aceb71249ff.Add("QUOTE", FieldType.FieldQuote);
		xf7266aceb71249ff.Add("RD", FieldType.FieldRefDoc);
		xf7266aceb71249ff.Add("REF", FieldType.FieldRef);
		xf7266aceb71249ff.Add("REVNUM", FieldType.FieldRevisionNum);
		xf7266aceb71249ff.Add("SAVEDATE", FieldType.FieldSaveDate);
		xf7266aceb71249ff.Add("SECTION", FieldType.FieldSection);
		xf7266aceb71249ff.Add("SECTIONPAGES", FieldType.FieldSectionPages);
		xf7266aceb71249ff.Add("SEQ", FieldType.FieldSequence);
		xf7266aceb71249ff.Add("SET", FieldType.FieldSet);
		xf7266aceb71249ff.Add("SHAPE", FieldType.FieldShape);
		xf7266aceb71249ff.Add("SKIPIF", FieldType.FieldSkipIf);
		xf7266aceb71249ff.Add("STYLEREF", FieldType.FieldStyleRef);
		xf7266aceb71249ff.Add("SUBJECT", FieldType.FieldSubject);
		xf7266aceb71249ff.Add("SYMBOL", FieldType.FieldSymbol);
		xf7266aceb71249ff.Add("TA", FieldType.FieldTOAEntry);
		xf7266aceb71249ff.Add("TC", FieldType.FieldTOCEntry);
		xf7266aceb71249ff.Add("TE", FieldType.FieldTOCEntry);
		xf7266aceb71249ff.Add("INHALT", FieldType.FieldTOCEntry);
		xf7266aceb71249ff.Add("TEMPLATE", FieldType.FieldTemplate);
		xf7266aceb71249ff.Add("TIME", FieldType.FieldTime);
		xf7266aceb71249ff.Add("TITLE", FieldType.FieldTitle);
		xf7266aceb71249ff.Add("TOA", FieldType.FieldTOA);
		xf7266aceb71249ff.Add("TOC", FieldType.FieldTOC);
		xf7266aceb71249ff.Add("USERADDRESS", FieldType.FieldUserAddress);
		xf7266aceb71249ff.Add("USERINITIALS", FieldType.FieldUserInitials);
		xf7266aceb71249ff.Add("USERNAME", FieldType.FieldUserName);
		xf7266aceb71249ff.Add("XE", FieldType.FieldIndexEntry);
		xf7266aceb71249ff.Add("EX", FieldType.FieldIndexEntry);
		xf7266aceb71249ff.Add("E", FieldType.FieldIndexEntry);
		xf7266aceb71249ff.Add("IMPORT", FieldType.FieldImport);
	}
}
