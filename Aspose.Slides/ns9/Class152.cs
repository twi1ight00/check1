using Aspose.Slides;
using Aspose.Slides.Theme;

namespace ns9;

internal class Class152 : IPresentationComponent
{
	private MasterTheme masterTheme_0;

	internal ColorScheme colorScheme_0;

	internal FontScheme fontScheme_0;

	internal FormatScheme formatScheme_0;

	internal uint Version => colorScheme_0.Version + fontScheme_0.Version + formatScheme_0.Version;

	public IPresentation Presentation => masterTheme_0.Presentation;

	internal Class152(MasterTheme parent)
	{
		masterTheme_0 = parent;
		colorScheme_0 = new ColorScheme(this);
		fontScheme_0 = new FontScheme(((Presentation)parent.Presentation).FontsListManager.FontsList);
		formatScheme_0 = new FormatScheme(parent);
	}
}
