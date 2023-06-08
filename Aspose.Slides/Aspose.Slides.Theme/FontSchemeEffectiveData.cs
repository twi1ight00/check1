namespace Aspose.Slides.Theme;

public class FontSchemeEffectiveData : IFontSchemeEffectiveData, IEffectiveData
{
	private FontsEffectiveData fontsEffectiveData_0 = new FontsEffectiveData();

	private FontsEffectiveData fontsEffectiveData_1 = new FontsEffectiveData();

	private string string_0;

	public IFontsEffectiveData Minor => fontsEffectiveData_1;

	public IFontsEffectiveData Major => fontsEffectiveData_0;

	public string Name => string_0;

	internal FontSchemeEffectiveData(IFontScheme source)
	{
		method_0(source);
	}

	internal void method_0(IFontScheme source)
	{
		fontsEffectiveData_0.method_0(source.Major);
		fontsEffectiveData_1.method_0(source.Minor);
		string_0 = source.Name;
	}

	internal void method_1(IFontScheme source)
	{
		fontsEffectiveData_0.method_0(source.Major);
		fontsEffectiveData_1.method_0(source.Minor);
		string_0 = source.Name;
	}
}
