using System;
using System.Drawing;
using ns249;
using ns250;
using ns252;
using ns258;

namespace ns253;

internal class Class6445
{
	internal class Class6446 : Interface277
	{
		private readonly Class6434 class6434_0;

		private readonly Class6450 class6450_0;

		public Interface276 ParentBag
		{
			get
			{
				int level = class6434_0.Properties.Level;
				Class6435 @class = class6450_0.method_0(level);
				return @class.DefaultRunProperties.class6325_0;
			}
		}

		public Class6446(Class6434 paragraph, Class6450 textListStyles)
		{
			class6434_0 = paragraph;
			class6450_0 = textListStyles;
		}
	}

	private static Interface277 interface277_0 = new Class6328(Class6327.Instance);

	private Class6325 class6325_0 = new Class6325();

	public string AlternativeLanguage
	{
		get
		{
			return (string)method_6(Enum824.const_0);
		}
		set
		{
			method_5(Enum824.const_0, value);
		}
	}

	public bool Bold
	{
		get
		{
			return (bool)method_6(Enum824.const_1);
		}
		set
		{
			method_5(Enum824.const_1, value);
		}
	}

	public Class6329 Baseline
	{
		get
		{
			return (Class6329)method_6(Enum824.const_2);
		}
		set
		{
			method_5(Enum824.const_2, value);
		}
	}

	public string BookmarkLinkTarget
	{
		get
		{
			return (string)method_6(Enum824.const_3);
		}
		set
		{
			method_5(Enum824.const_3, value);
		}
	}

	public Enum820 Capitalization
	{
		get
		{
			return (Enum820)method_6(Enum824.const_4);
		}
		set
		{
			method_5(Enum824.const_4, value);
		}
	}

	public bool IsDirty
	{
		get
		{
			return (bool)method_6(Enum824.const_5);
		}
		set
		{
			method_5(Enum824.const_5, value);
		}
	}

	public bool HasSpellingError
	{
		get
		{
			return (bool)method_6(Enum824.const_6);
		}
		set
		{
			method_5(Enum824.const_6, value);
		}
	}

	public bool Italics
	{
		get
		{
			return (bool)method_6(Enum824.const_7);
		}
		set
		{
			method_5(Enum824.const_7, value);
		}
	}

	public Class6330 Kerning
	{
		get
		{
			return (Class6330)method_6(Enum824.const_8);
		}
		set
		{
			method_5(Enum824.const_8, value);
		}
	}

	public bool Kumimoji
	{
		get
		{
			return (bool)method_6(Enum824.const_9);
		}
		set
		{
			method_5(Enum824.const_9, value);
		}
	}

	public string Language
	{
		get
		{
			return (string)method_6(Enum824.const_10);
		}
		set
		{
			method_5(Enum824.const_10, value);
		}
	}

	public bool NoProofing
	{
		get
		{
			return (bool)method_6(Enum824.const_11);
		}
		set
		{
			method_5(Enum824.const_11, value);
		}
	}

	public bool NormalizeHeights
	{
		get
		{
			return (bool)method_6(Enum824.const_12);
		}
		set
		{
			method_5(Enum824.const_12, value);
		}
	}

	public bool SmartTagsClean
	{
		get
		{
			return (bool)method_6(Enum824.const_13);
		}
		set
		{
			method_5(Enum824.const_13, value);
		}
	}

	public int SmartTagID
	{
		get
		{
			return (int)method_6(Enum824.const_14);
		}
		set
		{
			method_5(Enum824.const_14, value);
		}
	}

	public Class6330 Spacing
	{
		get
		{
			return (Class6330)method_6(Enum824.const_15);
		}
		set
		{
			method_5(Enum824.const_15, value);
		}
	}

	public Enum830 Strikethrough
	{
		get
		{
			return (Enum830)method_6(Enum824.const_16);
		}
		set
		{
			method_5(Enum824.const_16, value);
		}
	}

	public Class6330 FontSize
	{
		get
		{
			return (Class6330)method_6(Enum824.const_17);
		}
		set
		{
			method_5(Enum824.const_17, value);
		}
	}

	public Enum831 Underline
	{
		get
		{
			return (Enum831)method_6(Enum824.const_18);
		}
		set
		{
			method_5(Enum824.const_18, value);
		}
	}

	public Class6350 Fill
	{
		get
		{
			return (Class6350)method_6(Enum824.const_19);
		}
		set
		{
			method_5(Enum824.const_19, value);
		}
	}

	public Class6400 Outline
	{
		get
		{
			return (Class6400)method_6(Enum824.const_20);
		}
		set
		{
			method_5(Enum824.const_20, value);
		}
	}

	public Interface274 HighlightColor
	{
		get
		{
			return (Interface274)method_6(Enum824.const_21);
		}
		set
		{
			method_5(Enum824.const_21, value);
		}
	}

	public Class6431 LatinFont
	{
		get
		{
			return (Class6431)method_6(Enum824.const_22);
		}
		set
		{
			method_5(Enum824.const_22, value);
		}
	}

	public Class6430 EastAsianFont
	{
		get
		{
			return (Class6430)method_6(Enum824.const_23);
		}
		set
		{
			method_5(Enum824.const_23, value);
		}
	}

	public Class6432 SymbolFont
	{
		get
		{
			return (Class6432)method_6(Enum824.const_24);
		}
		set
		{
			method_5(Enum824.const_24, value);
		}
	}

	public Class6429 ComplexScriptFont
	{
		get
		{
			return (Class6429)method_6(Enum824.const_25);
		}
		set
		{
			method_5(Enum824.const_25, value);
		}
	}

	public Class6445()
	{
		class6325_0.ParentBagProvider = interface277_0;
	}

	public void method_0(Class6445 properties)
	{
		class6325_0.ParentBagProvider = new Class6328(properties.class6325_0);
	}

	public Class6428 method_1(Enum822 fontType)
	{
		return fontType switch
		{
			Enum822.const_0 => LatinFont, 
			Enum822.const_1 => EastAsianFont, 
			Enum822.const_2 => SymbolFont, 
			Enum822.const_3 => ComplexScriptFont, 
			_ => throw new ArgumentOutOfRangeException("fontType"), 
		};
	}

	internal FontStyle method_2()
	{
		FontStyle fontStyle = FontStyle.Regular;
		if (Bold)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (Underline != 0)
		{
			fontStyle |= FontStyle.Underline;
		}
		if (Italics)
		{
			fontStyle |= FontStyle.Italic;
		}
		if (Strikethrough != 0)
		{
			fontStyle |= FontStyle.Strikeout;
		}
		return fontStyle;
	}

	internal void method_3(Class6327 properties)
	{
		class6325_0.ParentBagProvider = new Class6328(properties);
	}

	internal void method_4(Class6434 paragraph, Class6450 textListStyles)
	{
		class6325_0.ParentBagProvider = new Class6446(paragraph, textListStyles);
	}

	private void method_5(Enum824 propertyId, object value)
	{
		class6325_0.imethod_1(propertyId, value);
	}

	private object method_6(Enum824 propertyId)
	{
		return class6325_0.imethod_0(propertyId);
	}
}
