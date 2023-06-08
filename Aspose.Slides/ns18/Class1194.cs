using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class1194 : Class1190
{
	internal void method_7(IMasterSlide parentMasterSlide, out ILayoutSlide layoutSlide)
	{
		method_0();
		layoutSlide = null;
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "sldLayout")
			{
				Class2313 @class = new Class2313(base.XmlPartReader);
				layoutSlide = ((MasterSlide)parentMasterSlide).PPTXUnsupportedProps.delegate13_0(@class.Type);
				Class899.smethod_0(layoutSlide, @class.CSld, base.SlideDeserializationContext);
				Class931.smethod_2(layoutSlide.ThemeManager, @class.ClrMapOvr);
				Class992.smethod_0(layoutSlide.SlideShowTransition, @class.Transition, base.DeserializationContext);
				method_8(layoutSlide, @class);
				Class900.smethod_0(layoutSlide.ThemeManager, base.DeserializationContext);
			}
		}
		method_2();
	}

	private void method_8(ILayoutSlide layoutSlide, Class2313 slideLayoutElementData)
	{
		Class297 pPTXUnsupportedProps = ((LayoutSlide)layoutSlide).PPTXUnsupportedProps;
		Class233 timelineDeserializationContext = new Class233(base.SlideDeserializationContext.DeserializationContext, base.SlideDeserializationContext.ShapeXmlIdToShape);
		Class1008.smethod_0(layoutSlide.Timeline, slideLayoutElementData.Timing, timelineDeserializationContext);
		Class963.smethod_0(pPTXUnsupportedProps.HeaderFooter, slideLayoutElementData.Hf);
		pPTXUnsupportedProps.ExtensionList = slideLayoutElementData.ExtLst;
		pPTXUnsupportedProps.ShowMasterShapes = slideLayoutElementData.ShowMasterSp;
		pPTXUnsupportedProps.ShowMasterPlaceholderAnimations = slideLayoutElementData.ShowMasterPhAnim;
		pPTXUnsupportedProps.MatchingName = slideLayoutElementData.MatchingName;
		pPTXUnsupportedProps.Preserve = slideLayoutElementData.Preserve;
		pPTXUnsupportedProps.IsUserDrawn = slideLayoutElementData.UserDrawn;
	}

	internal void method_9(ILayoutSlide layoutSlide)
	{
		method_3();
		Class2313 @class = new Class2313();
		base.SerializationContext.SlideToSlidePart.Add(layoutSlide, base.Part);
		method_6(layoutSlide.Shapes, base.SlideSerializationContext);
		Class965.smethod_0(layoutSlide, @class, base.SlideSerializationContext);
		@class.vmethod_4(null, base.XmlPartWriter, "sldLayout");
		method_4();
	}

	public Class1194(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1194(Class1342 part, Class1346 serializationContext, IBaseSlide slide)
		: base(part, serializationContext, slide)
	{
	}
}
