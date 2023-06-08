using ns9;

namespace Aspose.Slides.Theme;

public abstract class BaseThemeManager
{
	internal static readonly Class153 class153_0 = new Class153();

	private Class153 class153_1 = new Class153();

	internal abstract Class153 ColorMapping { get; }

	internal Class153 ColorMappingOverride => class153_1;

	internal BaseThemeManager()
	{
	}
}
