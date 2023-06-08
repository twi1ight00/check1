using System.Runtime.InteropServices;

namespace Aspose.Slides;

[Guid("4F1A30AD-F1D0-4FAD-AA92-088E2F535404")]
[ClassInterface(ClassInterfaceType.None)]
[ComVisible(true)]
public class FontDataFactory : IFontDataFactory
{
	public IFontData CreateFontData(string fontName)
	{
		return new FontData(fontName);
	}
}
