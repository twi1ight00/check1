using ns24;

namespace Aspose.Slides.Theme;

public class ColorScheme : IPresentationComponent, ISlideComponent, IColorScheme
{
	private IPresentationComponent ipresentationComponent_0;

	private Class330 class330_0 = new Class330();

	private uint uint_0;

	internal ColorFormat[] colorFormat_0 = new ColorFormat[12];

	private string string_0 = "";

	internal Class330 PPTXUnsupportedProps => class330_0;

	public IColorFormat this[ColorSchemeIndex index]
	{
		get
		{
			int num = (int)index;
			if (num >= 0 && num < colorFormat_0.Length)
			{
				return colorFormat_0[num];
			}
			return null;
		}
	}

	public IColorFormat Dark1 => this[ColorSchemeIndex.Dark1];

	public IColorFormat Light1 => this[ColorSchemeIndex.Light1];

	public IColorFormat Dark2 => this[ColorSchemeIndex.Dark2];

	public IColorFormat Light2 => this[ColorSchemeIndex.Light2];

	public IColorFormat Accent1 => this[ColorSchemeIndex.Accent1];

	public IColorFormat Accent2 => this[ColorSchemeIndex.Accent2];

	public IColorFormat Accent3 => this[ColorSchemeIndex.Accent3];

	public IColorFormat Accent4 => this[ColorSchemeIndex.Accent4];

	public IColorFormat Accent5 => this[ColorSchemeIndex.Accent5];

	public IColorFormat Accent6 => this[ColorSchemeIndex.Accent6];

	public IColorFormat Hyperlink => this[ColorSchemeIndex.Hyperlink];

	public IColorFormat FollowedHyperlink => this[ColorSchemeIndex.FollowedHyperlink];

	internal uint Version
	{
		get
		{
			uint num = uint_0;
			ColorFormat[] array = colorFormat_0;
			foreach (ColorFormat colorFormat in array)
			{
				num += colorFormat.Version;
			}
			return num;
		}
	}

	public IBaseSlide Slide => null;

	public IPresentation Presentation => ipresentationComponent_0.Presentation;

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	ISlideComponent IColorScheme.AsISlideComponent => this;

	internal string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			method_1();
		}
	}

	internal ColorScheme(IPresentationComponent parent)
	{
		ipresentationComponent_0 = parent;
		for (int i = 0; i < colorFormat_0.Length; i++)
		{
			colorFormat_0[i] = new ColorFormat(this);
		}
	}

	internal void method_0(ColorScheme source)
	{
		for (int i = 0; i < source.colorFormat_0.Length; i++)
		{
			colorFormat_0[i].method_0(source.colorFormat_0[i]);
		}
		string_0 = source.string_0;
		PPTXUnsupportedProps.method_0(source.PPTXUnsupportedProps);
		method_1();
	}

	private void method_1()
	{
		uint_0++;
	}
}
