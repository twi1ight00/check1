using System;
using ns9;

namespace Aspose.Slides.Theme;

public class MasterThemeManager : BaseThemeManager, IThemeManager, IMasterThemeManager
{
	private BaseSlide baseSlide_0;

	private MasterTheme masterTheme_0;

	private bool bool_0;

	public IMasterTheme OverrideTheme
	{
		get
		{
			return masterTheme_0;
		}
		set
		{
			if (value == null || value.Presentation != masterTheme_0.Presentation)
			{
				throw new ArgumentException("Assined theme must be from the same presentation and must not be null.");
			}
			masterTheme_0 = (MasterTheme)value;
		}
	}

	private IMasterTheme InheritedTheme => baseSlide_0.Presentation.MasterTheme;

	internal IMasterTheme MasterThemeEffective
	{
		get
		{
			if (!IsOverrideThemeEnabled)
			{
				return InheritedTheme;
			}
			return OverrideTheme;
		}
	}

	public bool IsOverrideThemeEnabled
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (value && (masterTheme_0.Name == null || masterTheme_0.Name == ""))
			{
				masterTheme_0.Name = InheritedTheme.Name + " overriden";
			}
			bool_0 = value;
		}
	}

	IThemeManager IMasterThemeManager.AsIThemeManager => this;

	internal override Class153 ColorMapping
	{
		get
		{
			if (!base.ColorMappingOverride.On)
			{
				return ColorMappingInherited;
			}
			return base.ColorMappingOverride;
		}
	}

	private Class153 ColorMappingInherited => BaseThemeManager.class153_0;

	public IThemeEffectiveData CreateThemeEffective()
	{
		return new ThemeEffectiveData(MasterThemeEffective, baseSlide_0);
	}

	public void ApplyColorScheme(IExtraColorScheme scheme)
	{
		((ColorScheme)masterTheme_0.ColorScheme).method_0((ColorScheme)scheme.ColorScheme);
		base.ColorMappingOverride.method_3(((ExtraColorScheme)scheme).ColorMapping);
	}

	internal MasterThemeManager(BaseSlide parent)
	{
		baseSlide_0 = parent;
		masterTheme_0 = new MasterTheme(baseSlide_0.Presentation);
		base.ColorMappingOverride.On = true;
	}
}
