using System;

namespace Aspose.Slides.Theme;

public class OverrideTheme : Theme, IPresentationComponent, ITheme, IOverrideTheme
{
	private BaseOverrideThemeManager baseOverrideThemeManager_0;

	private ColorScheme colorScheme_0;

	private FontScheme fontScheme_0;

	private FormatScheme formatScheme_0;

	private uint uint_0;

	public override IColorScheme ColorScheme => colorScheme_0;

	public override IFontScheme FontScheme => fontScheme_0;

	public override IFormatScheme FormatScheme => formatScheme_0;

	public bool IsEmpty
	{
		get
		{
			if (colorScheme_0 == null && fontScheme_0 == null)
			{
				return formatScheme_0 == null;
			}
			return false;
		}
	}

	internal override uint Version => uint_0 + ((colorScheme_0 != null) ? colorScheme_0.Version : 0) + ((fontScheme_0 != null) ? fontScheme_0.Version : 0) + ((formatScheme_0 != null) ? formatScheme_0.Version : 0);

	ITheme IOverrideTheme.AsITheme => this;

	internal OverrideTheme(BaseOverrideThemeManager parentManager)
		: base(parentManager.Parent.Presentation)
	{
		baseOverrideThemeManager_0 = parentManager;
	}

	public void InitColorScheme()
	{
		uint_0 = Version;
		method_2();
		if (colorScheme_0 != null)
		{
			throw new InvalidOperationException();
		}
		colorScheme_0 = new ColorScheme(this);
	}

	public void InitColorSchemeFrom(IColorScheme colorScheme)
	{
		if (colorScheme == null)
		{
			throw new ArgumentNullException("colorScheme");
		}
		InitColorScheme();
		colorScheme_0.method_0((ColorScheme)colorScheme);
	}

	public void InitColorSchemeFromInherited()
	{
		InitColorScheme();
		colorScheme_0.method_0((ColorScheme)((ThemeEffectiveData)baseOverrideThemeManager_0.InheritedTheme).ColorSchemeInternal);
	}

	public void InitFontScheme()
	{
		uint_0 = Version;
		method_2();
		if (fontScheme_0 != null)
		{
			throw new InvalidOperationException();
		}
		fontScheme_0 = new FontScheme(((Presentation)base.Presentation).FontsListManager.FontsList);
	}

	public void InitFontSchemeFrom(IFontScheme fontScheme)
	{
		if (fontScheme == null)
		{
			throw new ArgumentNullException("fontScheme");
		}
		InitFontScheme();
		fontScheme_0.method_1((FontScheme)fontScheme);
	}

	public void InitFontSchemeFromInherited()
	{
		InitFontScheme();
		fontScheme_0.method_1((FontScheme)((ThemeEffectiveData)baseOverrideThemeManager_0.InheritedTheme).FontSchemeInternal);
	}

	public void InitFormatScheme()
	{
		uint_0 = Version;
		method_2();
		if (formatScheme_0 != null)
		{
			throw new InvalidOperationException();
		}
		formatScheme_0 = new FormatScheme(this);
	}

	public void InitFormatSchemeFrom(IFormatScheme formatScheme)
	{
		if (formatScheme == null)
		{
			throw new ArgumentNullException("formatScheme");
		}
		InitFormatScheme();
		formatScheme_0.method_0((FormatScheme)formatScheme);
	}

	public void InitFormatSchemeFromInherited()
	{
		InitFormatScheme();
		formatScheme_0.method_0((FormatScheme)((ThemeEffectiveData)baseOverrideThemeManager_0.InheritedTheme).FormatSchemeInternal);
	}

	internal ColorScheme method_0()
	{
		if (colorScheme_0 == null)
		{
			InitColorScheme();
		}
		return colorScheme_0;
	}

	public void Clear()
	{
		uint_0 = Version;
		method_2();
		colorScheme_0 = null;
		fontScheme_0 = null;
		formatScheme_0 = null;
	}

	internal void method_1(ThemeEffectiveData theme)
	{
		colorScheme_0.method_0((ColorScheme)theme.ColorSchemeInternal);
		fontScheme_0.method_1((FontScheme)theme.FontSchemeInternal);
		formatScheme_0.method_0((FormatScheme)theme.FormatSchemeInternal);
		method_2();
	}

	private void method_2()
	{
		uint_0++;
	}
}
