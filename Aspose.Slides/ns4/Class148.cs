using Aspose.Slides;
using Aspose.Slides.Theme;
using ns16;

namespace ns4;

internal class Class148
{
	private Enum273 enum273_0;

	private FillFormat fillFormat_0;

	private ColorFormat colorFormat_0;

	private uint uint_0;

	private uint uint_1;

	public uint FillStyleIndex
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
			method_1();
		}
	}

	public IFillFormat FillFormat => fillFormat_0;

	public IColorFormat StyleColor => colorFormat_0;

	public Enum273 Source
	{
		get
		{
			return enum273_0;
		}
		set
		{
			enum273_0 = value;
			method_1();
		}
	}

	internal uint Version => uint_1 + fillFormat_0.Version + colorFormat_0.Version;

	internal Class148(IPresentationComponent parent)
	{
		fillFormat_0 = new FillFormat(parent);
		colorFormat_0 = new ColorFormat(parent as ISlideComponent);
		enum273_0 = Enum273.const_0;
	}

	internal IFillParamSource method_0(BaseSlide colorMappingSlide, IThemeEffectiveData theme)
	{
		return enum273_0 switch
		{
			Enum273.const_1 => fillFormat_0, 
			Enum273.const_2 => ((ThemeEffectiveData)theme).method_3(colorMappingSlide, (int)uint_0, colorFormat_0), 
			_ => null, 
		};
	}

	private void method_1()
	{
		uint_1++;
	}
}
