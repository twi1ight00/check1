using System.Runtime.InteropServices;

namespace Aspose.Slides.Export;

[Guid("C995885E-5346-4DA0-9272-12A34598D1B8")]
[ComVisible(true)]
public interface IHtmlFormattingController
{
	void WriteDocumentStart(IHtmlGenerator generator, IPresentation presentation);

	void WriteDocumentEnd(IHtmlGenerator generator, IPresentation presentation);

	void WriteSlideStart(IHtmlGenerator generator, ISlide slide);

	void WriteSlideEnd(IHtmlGenerator generator, ISlide slide);

	void WriteShapeStart(IHtmlGenerator generator, IShape shape);

	void WriteShapeEnd(IHtmlGenerator generator, IShape shape);
}
