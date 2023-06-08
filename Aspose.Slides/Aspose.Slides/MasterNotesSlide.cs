using System;
using Aspose.Slides.Theme;
using ns22;
using ns24;

namespace Aspose.Slides;

public class MasterNotesSlide : BaseSlide, IPresentationComponent, ISlideComponent, IThemeable, IMasterThemeable, IBaseSlide, IMasterNotesSlide
{
	private Class299 class299_0 = new Class299();

	private Class265 class265_0 = new Class265();

	private readonly MasterThemeManager masterThemeManager_0;

	internal override Class296 BaseSlidePPTXUnsupportedProps => class299_0;

	internal override Class262 BaseSlidePPTUnsupportedProps => class265_0;

	internal Class299 PPTXUnsupportedProps => class299_0;

	internal Class265 PPTUnsupportedProps => class265_0;

	public IMasterThemeManager ThemeManager => masterThemeManager_0;

	IBaseSlide IMasterNotesSlide.AsIBaseSlide => this;

	IMasterThemeable IMasterNotesSlide.AsIMasterThemeable => this;

	IThemeable IMasterThemeable.AsIThemeable => this;

	internal MasterNotesSlide(Presentation parentPresentation)
		: base(parentPresentation)
	{
		masterThemeManager_0 = new MasterThemeManager(this);
	}

	[Obsolete("Use ThemeManager.ApplyColorScheme(..) method instead. Will be removed after 01.09.2013.")]
	public override void ApplyColorScheme(ExtraColorScheme scheme)
	{
		ThemeManager.ApplyColorScheme(scheme);
	}
}
