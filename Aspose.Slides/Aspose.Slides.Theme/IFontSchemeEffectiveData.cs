using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("3830b6c3-7293-4f2b-9e7a-5f0ab05d05d7")]
public interface IFontSchemeEffectiveData
{
	IFontsEffectiveData Minor { get; }

	IFontsEffectiveData Major { get; }

	string Name { get; }
}
