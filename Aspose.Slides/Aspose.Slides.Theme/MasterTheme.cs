using ns24;
using ns9;

namespace Aspose.Slides.Theme;

public class MasterTheme : Theme, IPresentationComponent, ITheme, IMasterTheme
{
	private string string_0;

	private Class152 class152_0;

	private ExtraColorSchemeCollection extraColorSchemeCollection_0;

	private Class358 class358_0 = new Class358();

	private uint uint_0;

	internal Class358 PPTXUnsupportedProps => class358_0;

	public override IColorScheme ColorScheme => class152_0.colorScheme_0;

	public override IFontScheme FontScheme => class152_0.fontScheme_0;

	public override IFormatScheme FormatScheme => class152_0.formatScheme_0;

	public IExtraColorSchemeCollection ExtraColorSchemes => extraColorSchemeCollection_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			method_0();
		}
	}

	internal override uint Version => uint_0 + class152_0.Version + extraColorSchemeCollection_0.Version;

	ITheme IMasterTheme.AsITheme => this;

	internal MasterTheme(IPresentation presentation)
		: base(presentation)
	{
		class152_0 = new Class152(this);
		extraColorSchemeCollection_0 = new ExtraColorSchemeCollection();
	}

	private void method_0()
	{
		uint_0++;
	}
}
