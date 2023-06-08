using Aspose.Slides;

namespace ns4;

internal class Class52
{
	private readonly Enum2 enum2_0;

	private readonly IFontData ifontData_0;

	private readonly int? nullable_0;

	private IFontData ifontData_1;

	private bool bool_0;

	private IFontData ifontData_2;

	private FontSubstCondition fontSubstCondition_0 = FontSubstCondition.Always;

	public Enum2 FontClass => enum2_0;

	public IFontData FontData
	{
		get
		{
			if (SubstitutedForRendering)
			{
				if (fontSubstCondition_0 == FontSubstCondition.Always)
				{
					return ifontData_2;
				}
				if (fontSubstCondition_0 == FontSubstCondition.WhenInaccessible && Class54.smethod_2(ifontData_0.FontName))
				{
					return ifontData_2;
				}
			}
			if (Substituted)
			{
				return ifontData_1;
			}
			return ifontData_0;
		}
	}

	public int? PptFontTableIndex => nullable_0;

	public bool Substituted => ifontData_1 != null;

	public bool SubstitutedForRendering => ifontData_2 != null;

	public IFontData ReplaceWithFontData
	{
		get
		{
			return ifontData_1;
		}
		set
		{
			ifontData_1 = value;
		}
	}

	public IFontData ReplaceForRenderingWithFontData
	{
		get
		{
			return ifontData_2;
		}
		set
		{
			ifontData_2 = value;
		}
	}

	public FontSubstCondition ReplaceForRenderingFontSubstRule
	{
		get
		{
			return fontSubstCondition_0;
		}
		set
		{
			fontSubstCondition_0 = value;
		}
	}

	public bool IsFontModificator => ifontData_0.FontName.Contains("+m");

	public bool LocalPresentationFont
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Class52(Enum2 fontClass, IFontData fontData, int? pptFontTableIndex, bool localPresentationFont)
	{
		enum2_0 = fontClass;
		ifontData_0 = fontData;
		nullable_0 = pptFontTableIndex;
		bool_0 = localPresentationFont;
	}

	public void method_0()
	{
		ifontData_1 = null;
	}
}
