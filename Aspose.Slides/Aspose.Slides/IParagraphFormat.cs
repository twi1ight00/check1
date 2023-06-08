using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("ec9f1f06-0db7-4bf4-a09d-33b5a7fd4a06")]
public interface IParagraphFormat
{
	IBulletFormat Bullet { get; }

	short Depth { get; set; }

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

	IPortionFormat DefaultPortionFormat { get; }
}
