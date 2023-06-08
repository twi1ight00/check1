namespace Aspose.Slides.Theme;

public abstract class Theme : IPresentationComponent, ITheme
{
	private IPresentation ipresentation_0;

	public abstract IColorScheme ColorScheme { get; }

	public abstract IFontScheme FontScheme { get; }

	public abstract IFormatScheme FormatScheme { get; }

	public IPresentation Presentation => ipresentation_0;

	internal abstract uint Version { get; }

	IPresentationComponent ITheme.AsIPresentationComponent => this;

	internal Theme(IPresentation presentation)
	{
		ipresentation_0 = presentation;
	}

	internal static IThemeManager smethod_0(IThemeable themeableObj)
	{
		if (themeableObj is IMasterThemeable)
		{
			return ((IMasterThemeable)themeableObj).ThemeManager;
		}
		if (themeableObj is IOverrideThemeable)
		{
			return ((IOverrideThemeable)themeableObj).ThemeManager;
		}
		return null;
	}
}
