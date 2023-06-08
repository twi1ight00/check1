using System.Runtime.InteropServices;

namespace Aspose.Slides.Theme;

[Guid("95cea239-6e24-4e25-8d3b-1cf6ede44559")]
[ComVisible(true)]
public interface IOverrideTheme : IPresentationComponent, ITheme
{
	bool IsEmpty { get; }

	ITheme AsITheme { get; }

	void InitColorScheme();

	void InitColorSchemeFrom(IColorScheme colorScheme);

	void InitColorSchemeFromInherited();

	void InitFontScheme();

	void InitFontSchemeFrom(IFontScheme fontScheme);

	void InitFontSchemeFromInherited();

	void InitFormatScheme();

	void InitFormatSchemeFrom(IFormatScheme formatScheme);

	void InitFormatSchemeFromInherited();

	void Clear();
}
