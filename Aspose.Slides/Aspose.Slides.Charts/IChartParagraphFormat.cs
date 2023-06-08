using System.Runtime.InteropServices;

namespace Aspose.Slides.Charts;

[ComVisible(true)]
[Guid("64cd6f0f-1845-44a3-bf74-28d3c78ba4a4")]
public interface IChartParagraphFormat
{
	TextAlignment Alignment { get; set; }

	float SpaceWithin { get; set; }

	float SpaceBefore { get; set; }

	float SpaceAfter { get; set; }

	NullableBool EastAsianLineBreak { get; set; }

	NullableBool RightToLeft { get; set; }

	NullableBool LatinLineBreak { get; set; }

	NullableBool HangingPunctuation { get; set; }

	float MarginLeft { get; set; }

	float MarginRight { get; set; }

	float Indent { get; set; }

	float DefaultTabSize { get; set; }

	ITabCollection Tabs { get; }

	FontAlignment FontAlignment { get; set; }
}
