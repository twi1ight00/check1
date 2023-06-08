using System;
using ns218;
using ns252;
using ns253;
using ns263;

namespace ns248;

internal class Class6283 : Interface272
{
	private Interface264 interface264_0;

	private Interface266 interface266_0;

	private Interface268 interface268_0;

	private Class5944 class5944_0;

	private Class6451 class6451_0;

	private Interface316 interface316_0;

	public Interface316 TransformBuilder
	{
		get
		{
			if (interface316_0 == null)
			{
				interface316_0 = new Class6476();
			}
			return interface316_0;
		}
		set
		{
			interface316_0 = value;
		}
	}

	public Interface266 FillBuilder
	{
		get
		{
			if (interface266_0 == null)
			{
				interface266_0 = new Class6274();
			}
			return interface266_0;
		}
	}

	public Interface268 OutlineBuilder
	{
		get
		{
			if (interface268_0 == null)
			{
				interface268_0 = new Class6278();
			}
			return interface268_0;
		}
	}

	public Interface264 ColorBuilder
	{
		get
		{
			if (interface264_0 == null)
			{
				interface264_0 = new Class6271();
			}
			return interface264_0;
		}
	}

	public Class6451 imethod_0(Class5944 reader)
	{
		class5944_0 = reader;
		if (reader.LocalName != "txSp")
		{
			return null;
		}
		class6451_0 = new Class6451();
		while (reader.method_0("txSp"))
		{
			switch (reader.LocalName)
			{
			case "xfrm":
				class6451_0.Transform = TransformBuilder.imethod_1(class5944_0);
				break;
			case "useSpRect":
				class6451_0.UseShapeTextRectangle = true;
				break;
			case "txBody":
				method_0();
				break;
			default:
				reader.method_2();
				break;
			}
		}
		return class6451_0;
	}

	private void method_0()
	{
		while (class5944_0.method_0("txBody"))
		{
			switch (class5944_0.LocalName)
			{
			case "bodyPr":
				method_1(class6451_0.TextBody.Properties);
				break;
			case "lstStyle":
				method_7(class6451_0.TextBody.TextListStyles);
				break;
			case "p":
				class6451_0.TextBody.method_0(method_8());
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
	}

	private void method_1(Class6448 props)
	{
		while (class5944_0.method_10())
		{
			switch (class5944_0.LocalName)
			{
			case "anchor":
				props.Anchor = method_6();
				break;
			case "anchorCtr":
				props.AnchorCenter = class5944_0.ValueAsBool;
				break;
			case "bIns":
				props.Insets.Bottom = class5944_0.ValueAsInt;
				break;
			case "lIns":
				props.Insets.Left = class5944_0.ValueAsInt;
				break;
			case "tIns":
				props.Insets.Top = class5944_0.ValueAsInt;
				break;
			case "rIns":
				props.Insets.Right = class5944_0.ValueAsInt;
				break;
			case "forceAA":
				props.ForceAntiAlias = class5944_0.ValueAsBool;
				break;
			case "fromWordArt":
				props.FromWordArt = class5944_0.ValueAsBool;
				break;
			case "rot":
				props.Rotation = new Class6323(class5944_0.ValueAsDouble);
				break;
			case "numCol":
				props.ColumnNumber = class5944_0.ValueAsInt;
				break;
			case "rtlCol":
				props.ColumnOrder = (class5944_0.ValueAsBool ? Enum827.const_1 : Enum827.const_0);
				break;
			case "spcCol":
				props.SpaceBetweenColumns = class5944_0.ValueAsInt;
				break;
			case "compatLnSpc":
				props.UseCompatibleLineSpacing = class5944_0.ValueAsBool;
				break;
			case "spcFirstLastPara":
				props.AreFirstAndLastParagraphsUseSpacing = class5944_0.ValueAsBool;
				break;
			case "horzOverflow":
				props.TextHorizontalOverflow = method_5();
				break;
			case "upright":
				props.IsTextUpright = class5944_0.ValueAsBool;
				break;
			case "vert":
				props.TextVerticalType = method_4();
				break;
			case "vertOverflow":
				props.TextVerticalOverflow = method_3();
				break;
			case "wrap":
				props.TextWrappingType = method_2();
				break;
			}
		}
		while (class5944_0.method_0("bodyPr"))
		{
			switch (class5944_0.LocalName)
			{
			}
			class5944_0.method_2();
		}
	}

	private Enum834 method_2()
	{
		return class5944_0.Value switch
		{
			"square" => Enum834.const_1, 
			"none" => Enum834.const_0, 
			_ => Enum834.const_1, 
		};
	}

	private Enum832 method_3()
	{
		return class5944_0.Value switch
		{
			"ellipsis" => Enum832.const_1, 
			"clip" => Enum832.const_2, 
			"overflow" => Enum832.const_0, 
			_ => Enum832.const_0, 
		};
	}

	private Enum833 method_4()
	{
		return class5944_0.Value switch
		{
			"horz" => Enum833.const_0, 
			"vert" => Enum833.const_1, 
			"vert270" => Enum833.const_2, 
			"wordArtVert" => Enum833.const_3, 
			"eaVert" => Enum833.const_4, 
			"mongolianVert" => Enum833.const_5, 
			"wordArtVertRtl" => Enum833.const_6, 
			_ => Enum833.const_0, 
		};
	}

	private Enum828 method_5()
	{
		return class5944_0.Value switch
		{
			"clip" => Enum828.const_1, 
			"overflow" => Enum828.const_0, 
			_ => Enum828.const_0, 
		};
	}

	private Enum826 method_6()
	{
		return class5944_0.Value switch
		{
			"dist" => Enum826.const_4, 
			"just" => Enum826.const_3, 
			"b" => Enum826.const_2, 
			"ctr" => Enum826.const_1, 
			"t" => Enum826.const_0, 
			_ => Enum826.const_0, 
		};
	}

	private void method_7(Class6450 styles)
	{
		while (class5944_0.method_0("lstStyle"))
		{
			switch (class5944_0.LocalName)
			{
			case "defPPr":
				method_17(styles.DefaultParagraphProperties);
				break;
			case "lvl1pPr":
				method_17(styles.ListLevel1Style);
				break;
			case "lvl2pPr":
				method_17(styles.ListLevel2Style);
				break;
			case "lvl3pPr":
				method_17(styles.ListLevel3Style);
				break;
			case "lvl4pPr":
				method_17(styles.ListLevel4Style);
				break;
			case "lvl5pPr":
				method_17(styles.ListLevel5Style);
				break;
			case "lvl6pPr":
				method_17(styles.ListLevel6Style);
				break;
			case "lvl7pPr":
				method_17(styles.ListLevel7Style);
				break;
			case "lvl8pPr":
				method_17(styles.ListLevel8Style);
				break;
			case "lvl9pPr":
				method_17(styles.ListLevel9Style);
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
	}

	private Class6434 method_8()
	{
		Class6434 @class = new Class6434();
		while (class5944_0.method_0("p"))
		{
			switch (class5944_0.LocalName)
			{
			case "br":
				@class.method_0(method_21());
				break;
			case "fld":
				@class.method_0(method_16());
				break;
			case "r":
				@class.method_0(method_10());
				break;
			case "m":
				@class.method_0(method_9());
				break;
			case "pPr":
				method_17(@class.Properties);
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return @class;
	}

	private Class6441 method_9()
	{
		Class6441 result = new Class6441();
		class5944_0.method_2();
		return result;
	}

	private Class6438 method_10()
	{
		Class6438 @class = new Class6438();
		while (class5944_0.method_0("r"))
		{
			switch (class5944_0.LocalName)
			{
			case "rPr":
				method_11(@class.RunProperties);
				break;
			case "t":
				@class.Text += class5944_0.method_11();
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return @class;
	}

	private void method_11(Class6445 properties)
	{
		string localName = class5944_0.LocalName;
		while (class5944_0.method_10())
		{
			switch (class5944_0.LocalName)
			{
			case "altLang":
				properties.AlternativeLanguage = class5944_0.Value;
				break;
			case "b":
				properties.Bold = class5944_0.ValueAsBool;
				break;
			case "baseline":
				properties.Baseline = new Class6329(class5944_0.ValueAsDouble);
				break;
			case "bmk":
				properties.BookmarkLinkTarget = class5944_0.Value;
				break;
			case "cap":
				properties.Capitalization = method_15();
				break;
			case "dirty":
				properties.IsDirty = class5944_0.ValueAsBool;
				break;
			case "err":
				properties.HasSpellingError = class5944_0.ValueAsBool;
				break;
			case "i":
				properties.Italics = class5944_0.ValueAsBool;
				break;
			case "kern":
				properties.Kerning = new Class6330(class5944_0.ValueAsInt);
				break;
			case "kumimoji":
				properties.Kumimoji = class5944_0.ValueAsBool;
				break;
			case "lang":
				properties.Language = class5944_0.Value;
				break;
			case "noProof":
				properties.NoProofing = class5944_0.ValueAsBool;
				break;
			case "normalizeH":
				properties.NormalizeHeights = class5944_0.ValueAsBool;
				break;
			case "smtClean":
				properties.SmartTagsClean = class5944_0.ValueAsBool;
				break;
			case "smtId":
				properties.SmartTagID = class5944_0.ValueAsInt;
				break;
			case "spc":
				properties.Spacing = new Class6330(class5944_0.ValueAsInt);
				break;
			case "strike":
				properties.Strikethrough = method_14();
				break;
			case "sz":
				properties.FontSize = new Class6330(class5944_0.ValueAsInt);
				break;
			case "u":
				properties.Underline = method_12();
				break;
			}
		}
		while (class5944_0.method_0(localName))
		{
			switch (class5944_0.LocalName)
			{
			case "blipFill":
			case "gradFill":
			case "grpFill":
			case "noFill":
			case "pattFill":
			case "solidFill":
				properties.Fill = FillBuilder.imethod_0(class5944_0);
				break;
			case "ln":
				properties.Outline = OutlineBuilder.imethod_0(class5944_0);
				break;
			case "highlight":
				while (class5944_0.method_0("highlight"))
				{
					properties.HighlightColor = ColorBuilder.imethod_1(class5944_0);
				}
				break;
			case "cs":
				properties.ComplexScriptFont = (Class6429)method_13(new Class6429());
				break;
			case "ea":
				properties.EastAsianFont = (Class6430)method_13(new Class6430());
				break;
			case "sym":
				properties.SymbolFont = (Class6432)method_13(new Class6432());
				break;
			case "latin":
				properties.LatinFont = (Class6431)method_13(new Class6431());
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
	}

	private Enum831 method_12()
	{
		return class5944_0.Value switch
		{
			"none" => Enum831.const_0, 
			"words" => Enum831.const_1, 
			"sng" => Enum831.const_2, 
			"dbl" => Enum831.const_3, 
			"heavy" => Enum831.const_4, 
			"dotted" => Enum831.const_5, 
			"dottedHeavy" => Enum831.const_6, 
			"dash" => Enum831.const_7, 
			"dashHeavy" => Enum831.const_8, 
			"dashLong" => Enum831.const_9, 
			"dashLongHeavy" => Enum831.const_10, 
			"dotDash" => Enum831.const_11, 
			"dotDashHeavy" => Enum831.const_12, 
			"dotDotDash" => Enum831.const_13, 
			"dotDotDashHeavy" => Enum831.const_14, 
			"wavy" => Enum831.const_15, 
			"wavyHeavy" => Enum831.const_16, 
			"wavyDbl" => Enum831.const_17, 
			_ => Enum831.const_0, 
		};
	}

	private Class6428 method_13(Class6428 font)
	{
		while (class5944_0.method_10())
		{
			switch (class5944_0.LocalName)
			{
			case "typeface":
				font.TextTypeface = class5944_0.Value;
				break;
			case "pitchFamily":
				font.SimilarFontFamily = class5944_0.ValueAsInt;
				break;
			case "panose":
				font.PanoseSetting = class5944_0.Value;
				break;
			case "charset":
				font.SimilarCharacterSet = class5944_0.ValueAsInt;
				break;
			}
		}
		return font;
	}

	private Enum830 method_14()
	{
		return class5944_0.Value switch
		{
			"dblStrike" => Enum830.const_2, 
			"sngStrike" => Enum830.const_1, 
			"noStrike" => Enum830.const_0, 
			_ => Enum830.const_0, 
		};
	}

	private Enum820 method_15()
	{
		return class5944_0.Value switch
		{
			"all" => Enum820.const_2, 
			"small" => Enum820.const_1, 
			"none" => Enum820.const_0, 
			_ => Enum820.const_0, 
		};
	}

	private Class6440 method_16()
	{
		Class6440 @class = new Class6440();
		@class.Id = class5944_0.method_8("id", Guid.Empty);
		@class.Type = class5944_0.method_4("type", string.Empty);
		while (class5944_0.method_0("fld"))
		{
			switch (class5944_0.LocalName)
			{
			case "t":
				@class.Text += class5944_0.method_11();
				break;
			case "pPr":
				method_17(@class.ParagraphProperties);
				break;
			case "rPr":
				method_11(@class.RunProperties);
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
		return @class;
	}

	private void method_17(Class6435 properties)
	{
		string localName = class5944_0.LocalName;
		while (class5944_0.method_10())
		{
			switch (class5944_0.LocalName)
			{
			case "algn":
				properties.Alignment = method_20();
				break;
			case "defTabSz":
				properties.DefaultTabSize = class5944_0.ValueAsInt;
				break;
			case "eaLnBrk":
				properties.IsEastAsianLineBreakAllowed = class5944_0.ValueAsBool;
				break;
			case "hangingPunct":
				properties.IsHangingPunctuationAllowed = class5944_0.ValueAsBool;
				break;
			case "fontAlgn":
				properties.FontAlignment = method_19();
				break;
			case "indent":
				properties.TextIdentation = class5944_0.ValueAsInt;
				break;
			case "latinLnBrk":
				properties.IsLatinLineBreakAllowed = class5944_0.ValueAsBool;
				break;
			case "lvl":
				properties.Level = class5944_0.ValueAsInt;
				break;
			case "marL":
				properties.LeftMargin = class5944_0.ValueAsInt;
				break;
			case "marR":
				properties.RightMargin = class5944_0.ValueAsInt;
				break;
			case "rtl":
				properties.RightToLeftFlowDirection = class5944_0.ValueAsBool;
				break;
			}
		}
		while (class5944_0.method_0(localName))
		{
			switch (class5944_0.LocalName)
			{
			case "defRPr":
				method_11(properties.DefaultRunProperties);
				break;
			case "lnSpc":
				properties.LineSpacing = method_18();
				break;
			case "spcAft":
				properties.SpaceAfter = method_18();
				break;
			case "spcBef":
				properties.SpaceBefore = method_18();
				break;
			default:
				class5944_0.method_2();
				break;
			}
		}
	}

	private Interface299 method_18()
	{
		Interface299 result = null;
		string localName = class5944_0.LocalName;
		while (class5944_0.method_0(localName))
		{
			switch (class5944_0.LocalName)
			{
			case "spcPts":
			{
				int num = class5944_0.method_5("val", -1);
				if (num > 0)
				{
					Class6443 class2 = new Class6443();
					class2.Value = new Class6330(num);
					result = class2;
				}
				break;
			}
			case "spcPct":
			{
				double value = class5944_0.method_6("val", 100000.0);
				Class6442 @class = new Class6442();
				@class.Value = new Class6329(value);
				result = @class;
				break;
			}
			default:
				class5944_0.method_2();
				break;
			}
		}
		return result;
	}

	private Enum821 method_19()
	{
		return class5944_0.Value switch
		{
			"base" => Enum821.const_3, 
			"b" => Enum821.const_4, 
			"ctr" => Enum821.const_2, 
			"t" => Enum821.const_1, 
			"auto" => Enum821.const_0, 
			_ => Enum821.const_3, 
		};
	}

	private Enum825 method_20()
	{
		return class5944_0.Value switch
		{
			"l" => Enum825.const_0, 
			"ctr" => Enum825.const_1, 
			"r" => Enum825.const_2, 
			"just" => Enum825.const_3, 
			"justLow" => Enum825.const_4, 
			"dist" => Enum825.const_5, 
			"thaiDist" => Enum825.const_6, 
			_ => Enum825.const_0, 
		};
	}

	private Class6439 method_21()
	{
		Class6439 @class = new Class6439();
		while (class5944_0.method_0("br"))
		{
			string localName;
			if ((localName = class5944_0.LocalName) != null && localName == "rPr")
			{
				method_11(@class.RunProperties);
			}
			else
			{
				class5944_0.method_2();
			}
		}
		return @class;
	}
}
