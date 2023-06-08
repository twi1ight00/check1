using System;
using System.Collections.Generic;
using Aspose.Slides.Theme;
using ns22;
using ns24;
using ns28;
using ns4;

namespace Aspose.Slides;

public class MasterSlide : BaseSlide, IPresentationComponent, ISlideComponent, IThemeable, IMasterThemeable, IBaseSlide, IMasterSlide
{
	private Class300 class300_0 = new Class300();

	private Class264 class264_0 = new Class264();

	internal MasterLayoutSlideCollection masterLayoutSlideCollection_0;

	internal TextStyle textStyle_0;

	internal TextStyle textStyle_1;

	internal TextStyle textStyle_2;

	internal bool bool_0;

	private readonly MasterThemeManager masterThemeManager_0;

	private string[] string_1 = new string[3]
	{
		"Evaluation only.",
		"Created with Aspose.Slides for .NET 4.0 15.1.0.0",
		"Copyright 2004-" + "2015.01.30".Substring(0, 4) + " Aspose Pty Ltd."
	};

	internal override Class296 BaseSlidePPTXUnsupportedProps => class300_0;

	internal override Class262 BaseSlidePPTUnsupportedProps => class264_0;

	internal Class300 PPTXUnsupportedProps => class300_0;

	internal Class264 PPTUnsupportedProps => class264_0;

	public ITextStyle TitleStyle => textStyle_0;

	public ITextStyle BodyStyle => textStyle_1;

	public ITextStyle OtherStyle => textStyle_2;

	public IMasterLayoutSlideCollection LayoutSlides => masterLayoutSlideCollection_0;

	public bool Preserve
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = false;
		}
	}

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
					if (((Slide)base.Presentation.Slides[num]).MasterSlide == this)
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

	public IMasterThemeManager ThemeManager => masterThemeManager_0;

	IBaseSlide IMasterSlide.AsIBaseSlide => this;

	IMasterThemeable IMasterSlide.AsIMasterThemeable => this;

	IThemeable IMasterThemeable.AsIThemeable => this;

	internal MasterSlide(Presentation parentPresentation)
		: base(parentPresentation)
	{
		PPTXUnsupportedProps.delegate13_0 = method_14;
		masterThemeManager_0 = new MasterThemeManager(this);
		masterLayoutSlideCollection_0 = new MasterLayoutSlideCollection(this);
		textStyle_0 = new TextStyle(this);
		textStyle_1 = new TextStyle(this);
		textStyle_2 = new TextStyle(this);
		InitSlideShowTransition();
	}

	internal ILayoutSlide method_14(SlideLayoutType layoutType)
	{
		return new LayoutSlide(this, layoutType);
	}

	public ISlide[] GetDependingSlides()
	{
		List<ISlide> list = new List<ISlide>();
		int count = base.Presentation.Slides.Count;
		for (int i = 0; i < count; i++)
		{
			if (((Slide)base.Presentation.Slides[i]).MasterSlide == this)
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

	internal void method_15(Class410 masterElem, Class476 package)
	{
		masterThemeManager_0.OverrideTheme.Name = masterElem.Name;
		method_12(masterElem, package);
		class518_0.method_2(this);
	}

	internal void method_16(Class476 odpPackage)
	{
		Name = "MasterSlide_" + PPTXUnsupportedProps.SlideId;
		foreach (LayoutSlide layoutSlide in LayoutSlides)
		{
			bool flag = false;
			foreach (Slide slide in base.ParentPresentation.Slides)
			{
				if (slide.MasterSlide == this && slide.LayoutSlideInternal == layoutSlide)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			Class410 @class = odpPackage.class465_0.method_13(Name + "_" + layoutSlide.Name);
			Class437 class2 = (odpPackage.class465_0.AutomaticStyles as Class438).method_36(string.Format("{0}{1}", "gp", odpPackage.int_0++));
			class2.method_36();
			@class.StyleName = class2;
			class2.Family = Enum84.const_10;
			class2.DrawingPageProperties.DisplayPageNumber = false;
			class2.DrawingPageProperties.DisplayDateTime = false;
			class2.DrawingPageProperties.DisplayFooter = false;
			class2.DrawingPageProperties.DisplayHeader = false;
			IBackground background = layoutSlide.Background;
			if (background.Type == BackgroundType.NotDefined && layoutSlide.MasterSlide != null)
			{
				background = layoutSlide.MasterSlide.Background;
			}
			Class469 class3 = new Class469(background.FillFormat);
			class3.method_1(class2.DrawingPageProperties.FillProperties, this, odpPackage, FloatColor.floatColor_0);
			if (layoutSlide.ShowMasterShapes)
			{
				((ShapeCollection)base.Shapes).method_20(@class, odpPackage, (Class438)odpPackage.class465_0.AutomaticStyles);
			}
			((ShapeCollection)layoutSlide.Shapes).method_20(@class, odpPackage, (Class438)odpPackage.class465_0.AutomaticStyles);
			if (Class1179.smethod_1() == Enum179.const_0)
			{
				string namespaceURI = "urn:oasis:names:tc:opendocument:xmlns:drawing:1.0";
				Class384 class4 = (Class384)@class.method_35("frame", namespaceURI);
				class4.Name = "evaluation" + odpPackage.int_0++;
				class4.Transform2D.Width = 504.8f;
				class4.Transform2D.Height = 123.6f;
				class4.Transform2D.X = ((float)(((SlideSize)base.Presentation.SlideSize).long_0 / 12700L) - 504.8f) / 2f;
				class4.Transform2D.Y = ((float)(((SlideSize)base.Presentation.SlideSize).long_1 / 12700L) - 123.6f) / 2f;
				string styleName = string.Format("{0}{1}", "gp", odpPackage.int_0++);
				string text = string.Format("{0}{1}", "T", odpPackage.int_0++);
				string text2 = string.Format("{0}{1}", "P", odpPackage.int_0++);
				Class437 class5 = (odpPackage.class465_0.AutomaticStyles as Class438).method_36(styleName);
				class5.Family = Enum84.const_11;
				Class437 class6 = (odpPackage.class465_0.AutomaticStyles as Class438).method_36(text);
				class6.Family = Enum84.const_1;
				Class437 class7 = (odpPackage.class465_0.AutomaticStyles as Class438).method_36(text2);
				class7.Family = Enum84.const_0;
				class5.InnerXml = "<style:graphic-properties fo:wrap-option=\"no-wrap\" fo:padding-top=\"0.05in\" fo:padding-bottom=\"0.05in\" fo:padding-left=\"0.1in\" fo:padding-right=\"0.1in\" draw:textarea-vertical-align=\"middle\" draw:textarea-horizontal-align=\"center\" draw:fill=\"none\" draw:stroke=\"none\" draw:auto-grow-width=\"true\" draw:auto-grow-height=\"true\" style:protect=\"position size\" draw:opacity=\"50%\"/>";
				class6.InnerXml = "<style:text-properties fo:color=\"#ff9999\" fo:font-family=\"Calibri\" style:font-family-generic=\"swiss\" fo:font-size=\"0.44444in\" style:font-size-asian=\"0.44444in\" style:font-size-complex=\"0.44444in\" fo:language=\"en\" fo:country=\"US\" fo:text-shadow=\"0.04167in 0in 0pc #000000\" fo:font-weight=\"bold\" style:font-weight-asian=\"bold\" style:font-weight-complex=\"bold\"/>";
				class7.InnerXml = "<style:paragraph-properties fo:line-height=\"150%\" fo:text-align=\"center\" style:tab-stop-distance=\"1in\" fo:margin-left=\"0in\" fo:margin-right=\"0in\" fo:text-indent=\"0in\" fo:margin-top=\"0in\" fo:margin-bottom=\"0in\" style:punctuation-wrap=\"hanging\" style:vertical-align=\"auto\" style:writing-mode=\"lr-tb\"/>";
				class4.ShapeProperties.DrawStyleName = class5;
				string text3 = "<draw:text-box>";
				string[] array = string_1;
				foreach (string arg in array)
				{
					text3 += string.Format("<text:p text:style-name=\"{0}\"><text:span text:style-name=\"{2}\">{1}</text:span></text:p>", text2, arg, text);
				}
				text3 += "</draw:text-box>";
				class4.InnerXml = text3;
			}
		}
	}

	[Obsolete("Use ThemeManager.ApplyColorScheme(..) method instead. Will be removed after 01.09.2013.")]
	public override void ApplyColorScheme(ExtraColorScheme scheme)
	{
		ThemeManager.ApplyColorScheme(scheme);
	}
}
