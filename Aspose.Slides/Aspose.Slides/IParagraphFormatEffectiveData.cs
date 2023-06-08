using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("448aebbb-1f0e-4b9e-9862-21ef5f7401f4")]
[ComVisible(true)]
public interface IParagraphFormatEffectiveData : IPresentationComponent, ISlideComponent
{
	IBulletFormatEffectiveData Bullet { get; }

	short Depth { get; }

	TextAlignment Alignment { get; }

	float SpaceWithin { get; }

	float SpaceBefore { get; }

	float SpaceAfter { get; }

	bool EastAsianLineBreak { get; }

	bool RightToLeft { get; }

	bool LatinLineBreak { get; }

	bool HangingPunctuation { get; }

	float MarginLeft { get; }

	float MarginRight { get; }

	float Indent { get; }

	float DefaultTabSize { get; }

	ITabEffectiveData[] Tabs { get; }

	FontAlignment FontAlignment { get; }

	IPortionFormatEffectiveData DefaultPortionFormat { get; }

	ISlideComponent AsISlideComponent { get; }
}
