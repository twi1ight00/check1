using System.Runtime.InteropServices;

namespace Aspose.Slides;

[ComVisible(true)]
[Guid("C272B140-F4F7-4F97-B49E-E415078BB342")]
public interface IFontDataFactory
{
	IFontData CreateFontData(string fontName);
}
