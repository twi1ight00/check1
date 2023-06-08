using System;
using ns9;

namespace Aspose.Slides.Theme;

public abstract class BaseOverrideThemeManager : BaseThemeManager, IThemeManager, IOverrideThemeManager
{
	private IThemeable ithemeable_0;

	private OverrideTheme overrideTheme_0;

	private bool bool_0;

	public IOverrideTheme OverrideTheme
	{
		get
		{
			return overrideTheme_0;
		}
		set
		{
			if (value == null || value.Presentation != overrideTheme_0.Presentation)
			{
				throw new ArgumentException("Assined theme must be from the same presentation and must not be null.");
			}
			overrideTheme_0 = (OverrideTheme)value;
		}
	}

	internal IThemeEffectiveData InheritedTheme
	{
		get
		{
			if (OwnerOfInheritedTheme == null)
			{
				return new ThemeEffectiveData(Parent.Presentation.MasterTheme, null);
			}
			return OwnerOfInheritedTheme.CreateThemeEffective();
		}
	}

	public bool IsOverrideThemeEnabled => !overrideTheme_0.IsEmpty;

	IThemeManager IOverrideThemeManager.AsIThemeManager => this;

	protected abstract IThemeable OwnerOfInheritedTheme { get; }

	internal IThemeable Parent => ithemeable_0;

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

	private Class153 ColorMappingInherited
	{
		get
		{
			if (OwnerOfInheritedTheme == null)
			{
				return BaseThemeManager.class153_0;
			}
			return ((BaseThemeManager)Theme.smethod_0(OwnerOfInheritedTheme)).ColorMapping;
		}
	}

	public IThemeEffectiveData CreateThemeEffective()
	{
		ThemeEffectiveData themeEffectiveData = new ThemeEffectiveData(InheritedTheme, ithemeable_0.Slide);
		themeEffectiveData.method_2(overrideTheme_0);
		return themeEffectiveData;
	}

	public void ApplyColorScheme(IExtraColorScheme scheme)
	{
		overrideTheme_0.method_0().method_0((ColorScheme)scheme.ColorScheme);
		base.ColorMappingOverride.On = ((ExtraColorScheme)scheme).ColorMapping.On;
		if (base.ColorMappingOverride.On)
		{
			base.ColorMappingOverride.method_3(((ExtraColorScheme)scheme).ColorMapping);
		}
	}

	internal BaseOverrideThemeManager(IThemeable parent)
	{
		ithemeable_0 = parent;
		overrideTheme_0 = new OverrideTheme(this);
	}
}
