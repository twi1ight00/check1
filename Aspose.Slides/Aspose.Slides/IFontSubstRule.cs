using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("032B161D-495E-488D-80E0-FA74B42BB8A0")]
[ComVisible(true)]
public interface IFontSubstRule
{
	IFontData SourceFont { get; }

	IFontData DestFont { get; }

	FontSubstCondition ReplaceFontCondition { get; }
}
