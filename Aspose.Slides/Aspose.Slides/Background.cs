using Aspose.Slides.Theme;
using ns22;
using ns24;
using ns28;

namespace Aspose.Slides;

public class Background : IPresentationComponent, ISlideComponent, IBackground
{
	private BaseSlide baseSlide_0;

	internal FillFormat fillFormat_0;

	private BackgroundType backgroundType_0 = BackgroundType.NotDefined;

	private ColorFormat colorFormat_0;

	private Class294 class294_0 = new Class294();

	private Class267 class267_0 = new Class267();

	public BackgroundType Type
	{
		get
		{
			return backgroundType_0;
		}
		set
		{
			backgroundType_0 = value;
		}
	}

	public IFillFormat FillFormat => fillFormat_0;

	public IColorFormat StyleColor => colorFormat_0;

	public ushort StyleIndex
	{
		get
		{
			return (ushort)(PPTXUnsupportedProps.Idx % 1000u);
		}
		set
		{
			if (value == 0)
			{
				PPTXUnsupportedProps.Idx = 0u;
			}
			else
			{
				PPTXUnsupportedProps.Idx = (uint)(1000 + value);
			}
		}
	}

	internal Class294 PPTXUnsupportedProps => class294_0;

	internal Class267 PPTUnsupportedProps => class267_0;

	public IBaseSlide Slide
	{
		get
		{
			if (baseSlide_0 == null)
			{
				return null;
			}
			return baseSlide_0;
		}
	}

	public IPresentation Presentation
	{
		get
		{
			if (baseSlide_0 == null)
			{
				return null;
			}
			return baseSlide_0.ParentPresentation;
		}
	}

	IPresentationComponent ISlideComponent.AsIPresentationComponent => this;

	ISlideComponent IBackground.AsISlideComponent => this;

	internal FillFormat method_0(BaseSlide slide)
	{
		if (backgroundType_0 == BackgroundType.OwnBackground)
		{
			return fillFormat_0;
		}
		if (backgroundType_0 == BackgroundType.Themed && StyleIndex > 0)
		{
			return (FillFormat)((ThemeEffectiveData)slide.CreateThemeEffective()).FormatSchemeInternal.BackgroundFillStyles[StyleIndex - 1];
		}
		return null;
	}

	internal Background(BaseSlide parent)
	{
		baseSlide_0 = parent;
		fillFormat_0 = new FillFormat(this);
		colorFormat_0 = new ColorFormat(this);
		PPTUnsupportedProps.CustomDataInternal = new CustomData();
	}

	internal void method_1(Class437 style, Class476 package)
	{
		if (style.DrawingPageProperties != null)
		{
			if (style.DrawingPageProperties.FillProperties.FillStyle != 0)
			{
				Type = BackgroundType.OwnBackground;
			}
			((FillFormat)FillFormat).method_2(style.DrawingPageProperties.FillProperties, package);
		}
	}
}
