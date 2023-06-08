using System.Collections.Generic;
using Aspose.Slides;
using ns4;
using ns60;
using ns62;
using ns63;

namespace ns15;

internal class Class1055
{
	internal static LayoutSlide smethod_0(Class2719 titleMasterSlideContainer, Class857 deserializationContext)
	{
		_ = deserializationContext.DomPresentation;
		BaseSlide baseSlide = deserializationContext.SlideIdToMasterOrLayoutSlide[titleMasterSlideContainer.SlideAtom.MasterIdRef];
		MasterSlide masterSlide = (MasterSlide)baseSlide;
		SlideLayoutType layoutType = SlideLayoutType.Title;
		LayoutSlide layoutSlide = (LayoutSlide)masterSlide.LayoutSlides.GetByType(SlideLayoutType.Title);
		if (layoutSlide == null)
		{
			layoutSlide = Class1081.smethod_1(masterSlide, layoutType, deserializationContext);
		}
		Class854 @class = new Class854(layoutSlide, titleMasterSlideContainer, deserializationContext);
		deserializationContext.DomPresentation.PPTXUnsupportedProps.method_3(titleMasterSlideContainer.SlideId);
		deserializationContext.SlideIdToMasterOrLayoutSlide.Add(titleMasterSlideContainer.SlideId, layoutSlide);
		List<Class2670> nonGroupSpContainers;
		List<Class2623> shapesSource = Class854.smethod_2(@class.DrawingContainer.OfficeArtDg, out nonGroupSpContainers);
		Class1048.smethod_0(layoutSlide, shapesSource, @class);
		layoutSlide.ShowMasterShapes = titleMasterSlideContainer.SlideAtom.FMasterObjects;
		Class1065.smethod_1(layoutSlide.PPTUnsupportedProps, titleMasterSlideContainer);
		return layoutSlide;
	}
}
