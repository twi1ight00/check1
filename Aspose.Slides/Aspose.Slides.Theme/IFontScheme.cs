using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("cfaf023e-4b1c-45b0-b21c-61f641c4070d")]
public interface IFontScheme
{
	IFonts Minor { get; }

	IFonts Major { get; }

	string Name { get; set; }
}
