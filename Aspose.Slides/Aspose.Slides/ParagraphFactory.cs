using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("433F6A50-4B40-4049-9A8D-430AB48DD0DC")]
[ClassInterface(ClassInterfaceType.None)]
public class ParagraphFactory : IParagraphFactory
{
	public IParagraph CreateParagraph()
	{
		return new Paragraph();
	}

	public IParagraph CreateParagraph(IParagraph paragraph)
	{
		return new Paragraph(paragraph as Paragraph);
	}
}
