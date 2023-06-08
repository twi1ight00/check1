using ns9;

namespace Aspose.Slides.Theme;

public class ExtraColorScheme : IExtraColorScheme
{
	private ColorScheme colorScheme_0;

	private Class153 class153_0;

	public string Name => colorScheme_0.Name;

	public IColorScheme ColorScheme => colorScheme_0;

	internal Class153 ColorMapping => class153_0;

	internal uint Version => colorScheme_0.Version + class153_0.Version;

	internal ExtraColorScheme(IPresentationComponent parent)
	{
		colorScheme_0 = new ColorScheme(parent);
		class153_0 = new Class153();
	}
}
