using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("3ac0a339-947b-4a01-8d45-fd5df99df046")]
[ComVisible(true)]
public interface ITextFrame : IPresentationComponent, ISlideComponent
{
	IParagraphCollection Paragraphs { get; }

	string Text { get; set; }

	ITextFrameFormat TextFrameFormat { get; }

	IHyperlinkQueries HyperlinkQueries { get; }

	ISlideComponent AsISlideComponent { get; }

	void JoinPortionsWithSameFormatting();
}
