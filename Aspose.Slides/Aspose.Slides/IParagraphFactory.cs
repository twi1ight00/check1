using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("591B58B3-CE88-41BA-AC2D-6E06B634666B")]
[ComVisible(true)]
public interface IParagraphFactory
{
	IParagraph CreateParagraph();

	IParagraph CreateParagraph(IParagraph paragraph);
}
