using System.Drawing;
using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("757186f8-22ed-4c02-83c5-05b5037610b3")]
public interface IPortionFormatEffectiveData
{
	ILineFormatEffectiveData LineFormat { get; }

	IFillFormatEffectiveData FillFormat { get; }

	IEffectFormatEffectiveData EffectFormat { get; }

	Color HighlightColor { get; }

	ILineFormatEffectiveData UnderlineLineFormat { get; }

	IFillFormatEffectiveData UnderlineFillFormat { get; }

	string BookmarkId { get; }

	IHyperlink HyperlinkClick { get; }

	IHyperlink HyperlinkMouseOver { get; }

	bool FontBold { get; }

	bool FontItalic { get; }

	bool Kumimoji { get; }

	bool NormaliseHeight { get; }

	bool ProofDisabled { get; }

	TextUnderlineType FontUnderline { get; }

	TextCapType TextCapType { get; }

	TextStrikethroughType StrikethroughType { get; }

	bool SmartTagClean { get; }

	bool IsHardUnderlineLine { get; }

	bool IsHardUnderlineFill { get; }

	float FontHeight { get; }

	IFontData LatinFont { get; }

	IFontData EastAsianFont { get; }

	IFontData ComplexScriptFont { get; }

	IFontData SymbolFont { get; }

	float Escapement { get; }

	float KerningMinimalSize { get; }

	string LanguageId { get; }

	string AlternativeLanguageId { get; }

	float Spacing { get; }
}
