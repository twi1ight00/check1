using Aspose.Slides;
using Aspose.Slides.Theme;
using ns16;

namespace ns4;

internal class Class149
{
	private Enum275 enum275_0;

	private LineFormat lineFormat_0;

	private ColorFormat colorFormat_0;

	private uint uint_0;

	private uint uint_1;

	public Enum275 Source
	{
		get
		{
			return enum275_0;
		}
		set
		{
			enum275_0 = value;
			method_1();
		}
	}

	public ILineFormat LineFormat => lineFormat_0;

	public IColorFormat StyleColor => colorFormat_0;

	public uint LineIndex
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

	internal uint Version => uint_1 + lineFormat_0.Version + colorFormat_0.Version;

	internal Class149(IPresentationComponent parent)
	{
		lineFormat_0 = new LineFormat(parent);
		colorFormat_0 = new ColorFormat(parent as ISlideComponent);
	}

	internal ILineParamSource method_0(IBaseSlide slide, IThemeEffectiveData theme)
	{
		return enum275_0 switch
		{
			Enum275.const_1 => lineFormat_0, 
			Enum275.const_2 => ((ThemeEffectiveData)theme).method_5(slide, (int)uint_0, colorFormat_0), 
			_ => null, 
		};
	}

	private void method_1()
	{
		uint_1++;
	}
}
