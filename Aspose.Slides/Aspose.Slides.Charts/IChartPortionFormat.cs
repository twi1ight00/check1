using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[Guid("4390c872-a26e-48ba-86c0-d030ca3e8a51")]
[ComVisible(true)]
public interface IChartPortionFormat
{
	ILineFormat LineFormat { get; }

	IFillFormat FillFormat { get; }

	IEffectFormat EffectFormat { get; }

	IColorFormat HighlightColor { get; }

	ILineFormat UnderlineLineFormat { get; }

	IFillFormat UnderlineFillFormat { get; }

	NullableBool FontBold { get; set; }

	NullableBool FontItalic { get; set; }

	NullableBool Kumimoji { get; set; }

	NullableBool NormaliseHeight { get; set; }

	NullableBool ProofDisabled { get; set; }

	TextUnderlineType FontUnderline { get; set; }

	TextCapType TextCapType { get; set; }

	TextStrikethroughType StrikethroughType { get; set; }

	NullableBool IsHardUnderlineLine { get; set; }

	NullableBool IsHardUnderlineFill { get; set; }

	float FontHeight { get; set; }

	IFontData LatinFont { get; set; }

	IFontData EastAsianFont { get; set; }

	IFontData ComplexScriptFont { get; set; }

	IFontData SymbolFont { get; set; }

	float Escapement { get; set; }

	float KerningMinimalSize { get; set; }

	string LanguageId { get; set; }

	string AlternativeLanguageId { get; set; }

	float Spacing { get; set; }
}
