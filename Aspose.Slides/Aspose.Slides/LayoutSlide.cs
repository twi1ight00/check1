using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Theme;
using ns22;
using ns24;

namespace Aspose.Slides;

public sealed class LayoutSlide : BaseSlide, IPresentationComponent, ISlideComponent, IThemeable, IOverrideThemeable, IBaseSlide, ILayoutSlide
{
	private Class297 class297_0 = new Class297();

	private Class266 class266_0 = new Class266();

	private MasterSlide masterSlide_0;

	private SlideLayoutType slideLayoutType_0;

	private readonly LayoutSlideThemeManager layoutSlideThemeManager_0;

	ISlideComponent IThemeable.AsISlideComponent => this;

	internal override Class296 BaseSlidePPTXUnsupportedProps => class297_0;

	internal override Class262 BaseSlidePPTUnsupportedProps => class266_0;

	internal Class297 PPTXUnsupportedProps => class297_0;

	internal Class266 PPTUnsupportedProps => class266_0;

	public IMasterSlide MasterSlide
	{
		get
		{
			return masterSlide_0;
		}
		set
		{
			if (masterSlide_0 != value)
			{
				if (value != null && value.Presentation != base.Presentation)
				{
					throw new PptxEditException("Master slide must be from the same presentation.");
				}
				if (masterSlide_0 != null)
				{
					Remove();
				}
				masterSlide_0 = (MasterSlide)value;
				if (value != null)
				{
					method_14();
					((LayoutSlideCollection)masterSlide_0.LayoutSlides).Add(this);
				}
			}
		}
	}

	[Obsolete("Use ThemeManager.OverrideTheme property instead. Property will be removed after 01.09.2013.")]
	public OverrideTheme OverrideTheme => (OverrideTheme)ThemeManager.OverrideTheme;

	public IOverrideThemeManager ThemeManager => layoutSlideThemeManager_0;

	public SlideLayoutType LayoutType => slideLayoutType_0;

	public bool HasDependingSlides
	{
		get
		{
			int count = base.Presentation.Slides.Count;
			int num = 0;
			while (true)
			{
				if (num < count)
				{
					if (((Slide)base.Presentation.Slides[num]).LayoutSlide == this)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
	}

	internal bool ShowMasterShapes
	{
		get
		{
			return PPTXUnsupportedProps.ShowMasterShapes;
		}
		set
		{
			PPTXUnsupportedProps.ShowMasterShapes = value;
		}
	}

	IBaseSlide ILayoutSlide.AsIBaseSlide => this;

	IOverrideThemeable ILayoutSlide.AsIOverrideThemeable => this;

	IThemeable IOverrideThemeable.AsIThemeable => this;

	internal LayoutSlide(IMasterSlide masterSlide, SlideLayoutType layoutType)
		: this((Presentation)masterSlide.Presentation)
	{
		MasterSlide = masterSlide;
		slideLayoutType_0 = layoutType;
		InitSlideShowTransition();
	}

	internal LayoutSlide(Presentation parentPresentation)
		: base(parentPresentation)
	{
		layoutSlideThemeManager_0 = new LayoutSlideThemeManager(this);
		((LayoutSlideCollection)parentPresentation.LayoutSlides).Add(this);
	}

	public void Remove()
	{
		if (base.PresentationInternal == null)
		{
			throw new PptxEditException("Slide is already removed from presentation.");
		}
		lock (((ICollection)((LayoutSlideCollection)base.PresentationInternal.LayoutSlides).list_0).SyncRoot)
		{
			if (HasDependingSlides)
			{
				throw new PptxEditException("Error removing layout slide: this layout slide is used in presentation.");
			}
			method_15();
			((LayoutSlideCollection)masterSlide_0.LayoutSlides).list_0.Remove(this);
			((LayoutSlideCollection)base.PresentationInternal.LayoutSlides).list_0.Remove(this);
			masterSlide_0 = null;
			base.PresentationInternal = null;
		}
	}

	internal void method_14()
	{
		if (masterSlide_0 != null)
		{
			masterSlide_0.class518_0.m_textPropsChanged += class518_0.method_4;
		}
	}

	private void method_15()
	{
		if (masterSlide_0 != null)
		{
			masterSlide_0.class518_0.m_textPropsChanged -= class518_0.method_4;
		}
	}

	public ISlide[] GetDependingSlides()
	{
		List<ISlide> list = new List<ISlide>();
		int count = base.Presentation.Slides.Count;
		for (int i = 0; i < count; i++)
		{
			if (((Slide)base.Presentation.Slides[i]).LayoutSlideInternal == this)
			{
				list.Add(base.Presentation.Slides[i]);
			}
		}
		if (list.Count > 0)
		{
			return list.ToArray();
		}
		return SlideCollection.slide_0;
	}

	internal override Shape[] vmethod_0(IPlaceholder placeholder)
	{
		if (masterSlide_0 == null)
		{
			return BaseSlide.shape_0;
		}
		Shape shape = masterSlide_0.class518_0.method_1(placeholder, null);
		if (shape == null)
		{
			return BaseSlide.shape_0;
		}
		return new Shape[1] { shape };
	}

	[Obsolete("Use ThemeManager.ApplyColorScheme(..) method instead. Will be removed after 01.09.2013.")]
	public override void ApplyColorScheme(ExtraColorScheme scheme)
	{
		ThemeManager.ApplyColorScheme(scheme);
	}
}
