using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[ComVisible(true)]
[Guid("f057d28d-1be0-4fde-ab31-9c7c6221a20c")]
public interface ITheme : IPresentationComponent
{
	IColorScheme ColorScheme { get; }

	IFontScheme FontScheme { get; }

	IFormatScheme FormatScheme { get; }

	IPresentationComponent AsIPresentationComponent { get; }
}
