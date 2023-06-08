using System;
using Aspose.Words;
using x13f1efc79617a47b;
using x28925c9b27b37a46;

namespace xda075892eccab2ad;

internal class x93625b0e8808b0cc
{
	private x93625b0e8808b0cc()
	{
	}

	internal static FootnoteNumberingRule x9bf4da22006dc80e(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"continuous" => FootnoteNumberingRule.Continuous, 
			"eachSect" => FootnoteNumberingRule.RestartSection, 
			"each-sect" => FootnoteNumberingRule.RestartSection, 
			"eachPage" => FootnoteNumberingRule.RestartPage, 
			"each-page" => FootnoteNumberingRule.RestartPage, 
			_ => FootnoteNumberingRule.Continuous, 
		};
	}

	internal static string xd0ad27372997d1d3(FootnoteNumberingRule xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		if (xbcea506a33cf9111 == FootnoteNumberingRule.Continuous)
		{
			return "";
		}
		switch (xbcea506a33cf9111)
		{
		case FootnoteNumberingRule.Continuous:
			return "continuous";
		case FootnoteNumberingRule.RestartSection:
			if (!x5fbb1a9c98604ef5)
			{
				return "each-sect";
			}
			return "eachSect";
		case FootnoteNumberingRule.RestartPage:
			if (!x5fbb1a9c98604ef5)
			{
				return "each-page";
			}
			return "eachPage";
		default:
			return "";
		}
	}

	internal static x704ea28be0f90278 xbe53f95e31b85211(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "linesAndChars":
		case "lines-and-chars":
			return x704ea28be0f90278.x512029e749695a74;
		case "lines":
			return x704ea28be0f90278.x734991a6e63a780b;
		case "snapToChars":
		case "snap-to-chars":
			return x704ea28be0f90278.xc2ff8852503eb45d;
		default:
			return x704ea28be0f90278.xb9715d2f06b63cf0;
		}
	}

	internal static string x1d700be36115046f(x704ea28be0f90278 xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case x704ea28be0f90278.x512029e749695a74:
			if (!x5fbb1a9c98604ef5)
			{
				return "lines-and-chars";
			}
			return "linesAndChars";
		case x704ea28be0f90278.x734991a6e63a780b:
			return "lines";
		case x704ea28be0f90278.xc2ff8852503eb45d:
			if (!x5fbb1a9c98604ef5)
			{
				return "snap-to-chars";
			}
			return "snapToChars";
		default:
			return "";
		}
	}

	internal static HeaderFooterType x188cbe5b54678d25(string xbcea506a33cf9111, bool x59c6d00e0898f6b8)
	{
		switch (xbcea506a33cf9111)
		{
		case "even":
			if (x59c6d00e0898f6b8)
			{
				return HeaderFooterType.HeaderEven;
			}
			return HeaderFooterType.FooterEven;
		case "first":
			if (x59c6d00e0898f6b8)
			{
				return HeaderFooterType.HeaderFirst;
			}
			return HeaderFooterType.FooterFirst;
		default:
			if (x59c6d00e0898f6b8)
			{
				return HeaderFooterType.HeaderPrimary;
			}
			return HeaderFooterType.FooterPrimary;
		}
	}

	internal static string x9705b85b99f335f9(HeaderFooterType xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case HeaderFooterType.HeaderEven:
		case HeaderFooterType.FooterEven:
			return "even";
		case HeaderFooterType.HeaderFirst:
		case HeaderFooterType.FooterFirst:
			return "first";
		case HeaderFooterType.HeaderPrimary:
		case HeaderFooterType.FooterPrimary:
			if (!x5fbb1a9c98604ef5)
			{
				return "odd";
			}
			return "default";
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("llgbbnnblmeclmlcjmcdomjdcmaebhhegloealffjkmfjkdghkkgblbhmfihpjphfkgickniekejcjljmjckhejkijalkjhloiolaifmgemm", 165811814)));
		}
	}

	internal static FootnoteLocation xca6198d7a4a5b555(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "sectEnd":
		case "sect-end":
			return FootnoteLocation.EndOfSection;
		case "pageBottom":
		case "page-bottom":
			return FootnoteLocation.BottomOfPage;
		case "beneathText":
		case "beneath-text":
			return FootnoteLocation.BeneathText;
		case "docEnd":
		case "doc-end":
			return FootnoteLocation.EndOfDocument;
		default:
			return FootnoteLocation.EndOfSection;
		}
	}

	internal static string x54b498efdd18d7e2(FootnoteLocation xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case FootnoteLocation.EndOfSection:
			if (!x5fbb1a9c98604ef5)
			{
				return "sect-end";
			}
			return "sectEnd";
		case FootnoteLocation.BottomOfPage:
			if (!x5fbb1a9c98604ef5)
			{
				return "page-bottom";
			}
			return "pageBottom";
		case FootnoteLocation.BeneathText:
			if (!x5fbb1a9c98604ef5)
			{
				return "beneath-text";
			}
			return "beneathText";
		case FootnoteLocation.EndOfDocument:
			if (!x5fbb1a9c98604ef5)
			{
				return "doc-end";
			}
			return "docEnd";
		default:
			return "";
		}
	}

	internal static PageVerticalAlignment xa0fb3530f89d4d71(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"top" => PageVerticalAlignment.Top, 
			"center" => PageVerticalAlignment.Center, 
			"both" => PageVerticalAlignment.Justify, 
			"bottom" => PageVerticalAlignment.Bottom, 
			_ => PageVerticalAlignment.Top, 
		};
	}

	internal static string x77c962ff7ad4c74f(PageVerticalAlignment xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			PageVerticalAlignment.Top => "top", 
			PageVerticalAlignment.Center => "center", 
			PageVerticalAlignment.Justify => "both", 
			PageVerticalAlignment.Bottom => "bottom", 
			_ => "", 
		};
	}

	internal static xbdc85485688e2cf3 xefd54afbbe139da4(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "hyphen":
			return xbdc85485688e2cf3.x8e836880cbe4ad3d;
		case "period":
			return xbdc85485688e2cf3.x136412bb3a52aead;
		case "colon":
			return xbdc85485688e2cf3.x29f5b4fa024bb4ab;
		case "emDash":
		case "em-dash":
			return xbdc85485688e2cf3.x874a532590635ec5;
		case "enDash":
		case "en-dash":
			return xbdc85485688e2cf3.x6693558653dc26ba;
		default:
			return xbdc85485688e2cf3.x8e836880cbe4ad3d;
		}
	}

	internal static string x3d5f56a80ed53f22(xbdc85485688e2cf3 xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case xbdc85485688e2cf3.x8e836880cbe4ad3d:
			return "hyphen";
		case xbdc85485688e2cf3.x136412bb3a52aead:
			return "period";
		case xbdc85485688e2cf3.x29f5b4fa024bb4ab:
			return "colon";
		case xbdc85485688e2cf3.x874a532590635ec5:
			if (!x5fbb1a9c98604ef5)
			{
				return "em-dash";
			}
			return "emDash";
		case xbdc85485688e2cf3.x6693558653dc26ba:
			if (!x5fbb1a9c98604ef5)
			{
				return "en-dash";
			}
			return "enDash";
		default:
			return "";
		}
	}

	internal static LineNumberRestartMode x73d1b9b1a07e8505(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "continuous":
			return LineNumberRestartMode.Continuous;
		case "newPage":
		case "new-page":
			return LineNumberRestartMode.RestartPage;
		case "newSection":
		case "new-section":
			return LineNumberRestartMode.RestartSection;
		default:
			return LineNumberRestartMode.RestartPage;
		}
	}

	internal static string x44022575e103c89c(LineNumberRestartMode xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case LineNumberRestartMode.Continuous:
			return "continuous";
		case LineNumberRestartMode.RestartPage:
			if (!x5fbb1a9c98604ef5)
			{
				return "new-page";
			}
			return "newPage";
		case LineNumberRestartMode.RestartSection:
			if (!x5fbb1a9c98604ef5)
			{
				return "new-section";
			}
			return "newSection";
		default:
			return "";
		}
	}

	internal static PageBorderDistanceFrom xe162baa3fc1b526f(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"page" => PageBorderDistanceFrom.PageEdge, 
			"text" => PageBorderDistanceFrom.Text, 
			_ => PageBorderDistanceFrom.PageEdge, 
		};
	}

	internal static string x8e3b97700f64ed41(PageBorderDistanceFrom xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			PageBorderDistanceFrom.PageEdge => "page", 
			PageBorderDistanceFrom.Text => "text", 
			_ => "", 
		};
	}

	internal static PageBorderAppliesTo xc85890fabe91a528(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "allPages":
		case "all-pages":
			return PageBorderAppliesTo.AllPages;
		case "firstPage":
		case "first-page":
			return PageBorderAppliesTo.FirstPage;
		case "notFirstPage":
		case "not-first-page":
			return PageBorderAppliesTo.OtherPages;
		default:
			return PageBorderAppliesTo.AllPages;
		}
	}

	internal static string x9ad683bb9269c7e6(PageBorderAppliesTo xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case PageBorderAppliesTo.AllPages:
			if (!x5fbb1a9c98604ef5)
			{
				return "all-pages";
			}
			return "allPages";
		case PageBorderAppliesTo.FirstPage:
			if (!x5fbb1a9c98604ef5)
			{
				return "first-page";
			}
			return "firstPage";
		case PageBorderAppliesTo.OtherPages:
			if (!x5fbb1a9c98604ef5)
			{
				return "not-first-page";
			}
			return "notFirstPage";
		default:
			return "";
		}
	}

	internal static Orientation x3c8305a64db58186(string xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			"landscape" => Orientation.Landscape, 
			"portrait" => Orientation.Portrait, 
			_ => Orientation.Portrait, 
		};
	}

	internal static string x7a93588696d51464(Orientation xbcea506a33cf9111)
	{
		return xbcea506a33cf9111 switch
		{
			Orientation.Landscape => "landscape", 
			Orientation.Portrait => "portrait", 
			_ => "", 
		};
	}

	internal static SectionStart x1e1ba0c92e3db5b5(string xbcea506a33cf9111)
	{
		switch (xbcea506a33cf9111)
		{
		case "continuous":
			return SectionStart.Continuous;
		case "evenPage":
		case "even-page":
			return SectionStart.EvenPage;
		case "nextColumn":
		case "next-column":
			return SectionStart.NewColumn;
		case "nextPage":
		case "next-page":
			return SectionStart.NewPage;
		case "oddPage":
		case "odd-page":
			return SectionStart.OddPage;
		default:
			return SectionStart.NewPage;
		}
	}

	internal static string xc934493ed158282d(SectionStart xbcea506a33cf9111, bool x5fbb1a9c98604ef5)
	{
		switch (xbcea506a33cf9111)
		{
		case SectionStart.Continuous:
			return "continuous";
		case SectionStart.EvenPage:
			if (!x5fbb1a9c98604ef5)
			{
				return "even-page";
			}
			return "evenPage";
		case SectionStart.NewColumn:
			if (!x5fbb1a9c98604ef5)
			{
				return "next-column";
			}
			return "nextColumn";
		case SectionStart.NewPage:
			if (!x5fbb1a9c98604ef5)
			{
				return "next-page";
			}
			return "nextPage";
		case SectionStart.OddPage:
			if (!x5fbb1a9c98604ef5)
			{
				return "odd-page";
			}
			return "oddPage";
		default:
			return "";
		}
	}
}
