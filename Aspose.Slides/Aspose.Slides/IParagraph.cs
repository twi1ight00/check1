using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("9df54953-04be-466c-a019-6bd19bf70ccf")]
[ComVisible(true)]
public interface IParagraph : IPresentationComponent, ISlideComponent
{
	IPortionCollection Portions { get; }

	IParagraphFormat ParagraphFormat { get; }

	string Text { get; set; }

	ISlideComponent AsISlideComponent { get; }

	IParagraphFormatEffectiveData CreateParagraphFormatEffective();

	void JoinPortionsWithSameFormatting();
}
