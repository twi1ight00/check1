using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Theme;
using ns22;
using ns60;
using ns63;

namespace ns15;

internal class Class1057
{
	internal static MasterSlide smethod_0(Class2718 masterContainer, Class857 deserializationContext)
	{
		MasterSlide masterSlide = new MasterSlide(deserializationContext.DomPresentation);
		Class854 @class = new Class854(masterSlide, masterContainer, deserializationContext);
		deserializationContext.DomPresentation.PPTXUnsupportedProps.method_3(masterContainer.SlideId);
		deserializationContext.SlideIdToMasterOrLayoutSlide.Add(masterContainer.SlideId, masterSlide);
		Class1058.smethod_0(masterSlide.ThemeManager.OverrideTheme, masterContainer, ((MasterThemeManager)masterSlide.ThemeManager).ColorMapping);
		masterSlide.ThemeManager.IsOverrideThemeEnabled = true;
		@class.TxMasterStyles = new Dictionary<int, TextStyle>();
		Class2894[] rgTextMasterStyle = masterContainer.RgTextMasterStyle;
		foreach (Class2894 class2 in rgTextMasterStyle)
		{
			TextStyle textStyle = null;
			textStyle = (Enum449)class2.Header.Instance switch
			{
				Enum449.const_0 => masterSlide.textStyle_0, 
				Enum449.const_1 => masterSlide.textStyle_1, 
				Enum449.const_3 => masterSlide.textStyle_2, 
				_ => new TextStyle(masterSlide), 
			};
			Class1070.smethod_2(textStyle, class2, deserializationContext);
			@class.TxMasterStyles[class2.Header.Instance] = textStyle;
		}
		List<Class2623> records = @class.GroupShapeContainer.Records;
		Class1048.smethod_0(masterSlide, records, @class);
		IMasterThemeManager themeManager = masterSlide.ThemeManager;
		themeManager.OverrideTheme.Name = masterContainer.TemplateName;
		themeManager.IsOverrideThemeEnabled = true;
		smethod_1(masterSlide.PPTUnsupportedProps, masterContainer);
		return masterSlide;
	}

	internal static void smethod_1(Class264 unsupportedProps, Class2718 masterSlide)
	{
		unsupportedProps.MainMasterContainer_RoundTripOArtTextStyles12Atom = masterSlide.RoundTripOArtTextStyles12Atom;
		unsupportedProps.MainMasterContainer_SlideShowSlideInfoAtom = masterSlide.SlideShowSlideInfoAtom;
		unsupportedProps.MainMasterContainer_PerSlideHeadersFootersContainer = masterSlide.PerSlideHeadersFootersContainer;
		unsupportedProps.MainMasterContainer_RoundTripOriginalMainMasterId12Atom = masterSlide.RoundTripOriginalMainMasterId12Atom;
		unsupportedProps.MainMasterContainer_RoundTripThemeAtom = masterSlide.RoundTripThemeAtom;
		unsupportedProps.MainMasterContainer_RoundTripColorMappingAtom = masterSlide.RoundTripColorMappingAtom;
		unsupportedProps.MainMasterContainer_RoundTripContentMasterInfo12Atom = masterSlide.RoundTripContentMasterInfo12Atom;
		unsupportedProps.MainMasterContainer_RoundTripAnimationHashAtom = masterSlide.RoundTripAnimationHashAtom;
		unsupportedProps.MainMasterContainer_RoundTripAnimationAtom = masterSlide.RoundTripAnimationAtom;
		unsupportedProps.MainMasterContainer_RoundTripCompositeMasterId12Atom = masterSlide.RoundTripCompositeMasterId12Atom;
	}
}
