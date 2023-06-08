using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("E4A308AD-0DD5-432E-B2F9-46E47BE93AFD")]
public class FontSubstRule : IFontSubstRule
{
	private readonly IFontData ifontData_0;

	private readonly IFontData ifontData_1;

	private readonly FontSubstCondition fontSubstCondition_0;

	public IFontData SourceFont => ifontData_0;

	public IFontData DestFont => ifontData_1;

	public FontSubstCondition ReplaceFontCondition => fontSubstCondition_0;

	public FontSubstRule(IFontData sourceFont, IFontData destFont)
	{
		ifontData_0 = sourceFont;
		ifontData_1 = destFont;
		fontSubstCondition_0 = FontSubstCondition.Always;
	}

	public FontSubstRule(IFontData sourceFont, IFontData destFont, FontSubstCondition fontSubstRule)
	{
		ifontData_0 = sourceFont;
		ifontData_1 = destFont;
		fontSubstCondition_0 = fontSubstRule;
	}
}
