using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("400856dd-c56c-43cf-8b69-d844bb4b16a0")]
[ComVisible(true)]
public interface IMasterTheme : IPresentationComponent, ITheme
{
	IExtraColorSchemeCollection ExtraColorSchemes { get; }

	string Name { get; set; }

	ITheme AsITheme { get; }
}
