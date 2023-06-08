using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Theme;
using Aspose.Slides.Warnings;
using ns16;
using ns18;
using ns22;
using ns24;
using ns33;
using ns4;
using ns56;
using ns60;
using ns62;
using ns63;
using ns9;

namespace ns15;

internal class Class1065
{
	internal static Slide smethod_0(Class2719 slideContainer, Class857 deserializationContext)
	{
		Presentation domPresentation = deserializationContext.DomPresentation;
		Slide slide = new Slide(domPresentation);
		Class854 @class = new Class854(slide, slideContainer, deserializationContext);
		BaseSlide baseSlide = deserializationContext.SlideIdToMasterOrLayoutSlide[slideContainer.SlideAtom.MasterIdRef];
		if (baseSlide is MasterSlide masterSlide)
		{
			SlideLayoutType slideLayoutType = Class232.smethod_11(slideContainer.SlideAtom.Geom);
			LayoutSlide layoutSlide = (LayoutSlide)masterSlide.LayoutSlides.GetByType(slideLayoutType);
			if (layoutSlide == null)
			{
				layoutSlide = Class1081.smethod_1(masterSlide, slideLayoutType, deserializationContext);
			}
			slide.LayoutSlideInternal = layoutSlide;
		}
		else if (baseSlide is LayoutSlide layoutSlideInternal)
		{
			slide.LayoutSlideInternal = layoutSlideInternal;
		}
		List<Class2670> nonGroupSpContainers;
		List<Class2623> shapesSource = Class854.smethod_2(@class.DrawingContainer.OfficeArtDg, out nonGroupSpContainers);
		slide.Hidden = false;
		Class1048.smethod_0(slide, shapesSource, @class);
		slide.PPTXUnsupportedProps.ShowMasterShapes = slideContainer.SlideAtom.FMasterObjects;
		smethod_3(slide, nonGroupSpContainers);
		slide.PPTUnsupportedProps.IsMasterTheme = slideContainer.SlideAtom.FMasterScheme;
		if (!slide.PPTUnsupportedProps.IsMasterTheme)
		{
			smethod_2(slide.ThemeManager, slideContainer);
		}
		smethod_1(slide.PPTUnsupportedProps, slideContainer);
		smethod_4(slide, @class);
		return slide;
	}

	internal static void smethod_1(Class266 unsupportedProps, Class2719 slide)
	{
		unsupportedProps.SlideContainer_RtSlideSyncInfo12 = slide.RtSlideSyncInfo12;
		unsupportedProps.SlideContainer_RoundTripThemeAtom = slide.RoundTripThemeAtom;
		unsupportedProps.SlideContainer_RoundTripColorMappingAtom = slide.RoundTripColorMappingAtom;
		unsupportedProps.SlideContainer_RoundTripCompositeMasterId12Atom = slide.RoundTripCompositeMasterId12Atom;
		unsupportedProps.SlideContainer_RoundTripSlideSyncInfo12Container = slide.RoundTripSlideSyncInfo12Container;
		unsupportedProps.SlideContainer_RoundTripAnimationHashAtom = slide.RoundTripAnimationHashAtom;
		unsupportedProps.SlideContainer_RoundTripAnimationAtom = slide.RoundTripAnimationAtom;
		unsupportedProps.SlideContainer_RoundTripContentMasterId12Atom = slide.RoundTripContentMasterId12Atom;
		unsupportedProps.SlideContainer_ColorSchemeAtom = slide.SlideSchemeColorSchemeAtom;
	}

	internal static void smethod_2(IOverrideThemeManager themeOverrideManager, Class2719 slideContainer)
	{
		IOverrideTheme overrideTheme = themeOverrideManager.OverrideTheme;
		if (slideContainer.SlideSchemeColorSchemeAtom != null)
		{
			Class153 colorMap = new Class153();
			overrideTheme.InitColorScheme();
			Class1050.smethod_0((ColorScheme)overrideTheme.ColorScheme, slideContainer.SlideSchemeColorSchemeAtom, colorMap);
		}
	}

	private static void smethod_3(Slide resultDomSlide, List<Class2670> nonGroupSpContainers)
	{
		if (nonGroupSpContainers != null && nonGroupSpContainers.Count == 1)
		{
			Class2670 @class = nonGroupSpContainers[0];
			if (resultDomSlide.Background != null && resultDomSlide.Shapes.Count > 0 && @class.ShapePrimaryOptions.Properties[Enum426.const_81] is Class2911 class2 && class2.Value == 6)
			{
				Class294 pPTXUnsupportedProps = ((Background)resultDomSlide.Background).PPTXUnsupportedProps;
				pPTXUnsupportedProps.ShadeToTitle = true;
				pPTXUnsupportedProps.ShadeToShape = resultDomSlide.Shapes[0];
			}
		}
	}

	private static void smethod_4(Slide slide, Class854 slideDeserializationContext)
	{
		try
		{
			smethod_5(slide, slideDeserializationContext);
			Class2312 @class = new Class2312();
			Class214.smethod_0(@class, slideDeserializationContext);
			Class210.smethod_0(@class, slideDeserializationContext);
			Class233 timelineDeserializationContext = new Class233(slideDeserializationContext.DeserializationContext, smethod_6(slideDeserializationContext.Shapes));
			Class1008.smethod_0(slide.Timeline, @class.Timing, timelineDeserializationContext);
			if (@class.Timing != null)
			{
				Class302 pPTXUnsupportedProps = slide.PPTXUnsupportedProps;
				pPTXUnsupportedProps.BuildListOfTiming = @class.Timing.BldLst;
				pPTXUnsupportedProps.ExtensionListOfTiming = @class.Timing.ExtLst;
			}
		}
		catch (InvalidOperationException ex)
		{
			slideDeserializationContext.DeserializationContext.method_4("Loading of the animation info failed.", WarningType.DataLoss);
			Class1165.smethod_28(ex);
			smethod_7(slide.Timeline);
		}
		catch (NotImplementedException ex2)
		{
			slideDeserializationContext.DeserializationContext.method_4("Loading of the animation info failed.", WarningType.DataLoss);
			Class1165.smethod_28(ex2);
			smethod_7(slide.Timeline);
		}
	}

	private static void smethod_5(Slide slide, Class854 deserializationContext)
	{
		foreach (Shape shape in slide.Shapes)
		{
			deserializationContext.Shapes[shape.ShapeId] = shape;
		}
	}

	private static SortedList<string, ISlideComponent> smethod_6(IDictionary<uint, IShape> shapes)
	{
		SortedList<string, ISlideComponent> sortedList = new SortedList<string, ISlideComponent>(shapes.Count);
		foreach (KeyValuePair<uint, IShape> shape in shapes)
		{
			sortedList.Add(shape.Key.ToString(), shape.Value);
		}
		return sortedList;
	}

	private static void smethod_7(IAnimationTimeLine timeline)
	{
		timeline.MainSequence.Clear();
	}
}
