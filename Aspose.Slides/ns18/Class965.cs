using Aspose.Slides;
using Aspose.Slides.Theme;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class965
{
	public static void smethod_0(ILayoutSlide layoutSlide, Class2313 slideLayoutElementData, Class1031 slideSerializationContext)
	{
		Class297 pPTXUnsupportedProps = ((LayoutSlide)layoutSlide).PPTXUnsupportedProps;
		if (slideLayoutElementData.Timing == null)
		{
			slideLayoutElementData.delegate2524_0();
		}
		Class234 timelineSerializationContext = new Class234(slideSerializationContext.SerializationContext, slideSerializationContext.ShapeToShapeXmlId);
		Class1008.smethod_2(layoutSlide.Timeline, layoutSlide.Shapes, slideLayoutElementData.Timing, timelineSerializationContext);
		Class899.smethod_2(layoutSlide, slideLayoutElementData.CSld, slideSerializationContext);
		Class931.smethod_7(((BaseThemeManager)layoutSlide.ThemeManager).ColorMappingOverride, slideLayoutElementData.delegate1327_0());
		Class992.smethod_1(layoutSlide.SlideShowTransition, slideLayoutElementData.delegate21_0, slideSerializationContext.SerializationContext);
		slideLayoutElementData.Type = layoutSlide.LayoutType;
		Class963.smethod_1(pPTXUnsupportedProps.HeaderFooter, slideLayoutElementData.delegate2458_0);
		slideLayoutElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		slideLayoutElementData.ShowMasterSp = pPTXUnsupportedProps.ShowMasterShapes;
		slideLayoutElementData.ShowMasterPhAnim = pPTXUnsupportedProps.ShowMasterPlaceholderAnimations;
		slideLayoutElementData.MatchingName = pPTXUnsupportedProps.MatchingName;
		slideLayoutElementData.Preserve = pPTXUnsupportedProps.Preserve;
		slideLayoutElementData.UserDrawn = pPTXUnsupportedProps.IsUserDrawn;
	}
}
