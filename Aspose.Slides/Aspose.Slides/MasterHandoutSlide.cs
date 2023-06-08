using System;
using Aspose.Slides.Theme;
using ns22;
using ns24;

namespace Aspose.Slides;

public class MasterHandoutSlide : BaseSlide, IPresentationComponent, ISlideComponent, IThemeable, IMasterThemeable, IBaseSlide, IMasterHandoutSlide
{
	private Class298 class298_0 = new Class298();

	private Class263 class263_0 = new Class263();

	private readonly MasterThemeManager masterThemeManager_0;

	internal override Class296 BaseSlidePPTXUnsupportedProps => class298_0;

	internal override Class262 BaseSlidePPTUnsupportedProps => class263_0;

	internal Class298 PPTXUnsupportedProps => class298_0;

	internal Class263 PPTUnsupportedProps => class263_0;

	public IMasterThemeManager ThemeManager => masterThemeManager_0;

	IBaseSlide IMasterHandoutSlide.AsIBaseSlide => this;

	IMasterThemeable IMasterHandoutSlide.AsIMasterThemeable => this;

	IThemeable IMasterThemeable.AsIThemeable => this;

	internal MasterHandoutSlide(Presentation parentPresentation)
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
