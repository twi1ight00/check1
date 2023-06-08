using System.Text;
using Aspose.Slides;
using ns22;
using ns62;
using ns63;

namespace ns15;

internal class Class1036
{
	internal static void smethod_0(Shape domShape, Class2669 sourceSpgrContainerFileBlock, Class854 slideDeserializationContext)
	{
		Class853 @class = new Class853();
		@class.class2669_0 = sourceSpgrContainerFileBlock;
		domShape.method_11(sourceSpgrContainerFileBlock.ShapeProp.Spid);
		domShape.AlternativeText = "";
		if (sourceSpgrContainerFileBlock.ShapePrimaryOptions != null)
		{
			smethod_1(domShape, sourceSpgrContainerFileBlock);
		}
		if (sourceSpgrContainerFileBlock.ClientData != null)
		{
			smethod_5(domShape, sourceSpgrContainerFileBlock, slideDeserializationContext);
		}
		smethod_6(domShape, sourceSpgrContainerFileBlock);
		if (sourceSpgrContainerFileBlock is Class2670 shapeContainer)
		{
			smethod_7(domShape, shapeContainer, sourceSpgrContainerFileBlock, slideDeserializationContext);
		}
	}

	private static void smethod_1(Shape domShape, Class2669 sourceSpgrContainerFileBlock)
	{
		if (sourceSpgrContainerFileBlock.ShapePrimaryOptions.Properties[Enum426.const_19] is Class2930 alternativeTextProp)
		{
			smethod_2(domShape, alternativeTextProp);
		}
		if (sourceSpgrContainerFileBlock.ShapePrimaryOptions.Properties[Enum426.const_18] is Class2930 nameProp)
		{
			smethod_3(domShape, nameProp);
		}
		if (sourceSpgrContainerFileBlock.ShapePrimaryOptions.Properties[Enum426.const_50] is Class2911 @class)
		{
			domShape.Hidden = (@class.Value & 2) != 0;
		}
		smethod_4(domShape, sourceSpgrContainerFileBlock.ShapePrimaryOptions.Properties);
	}

	private static void smethod_2(Shape domShape, Class2930 alternativeTextProp)
	{
		domShape.AlternativeText = smethod_8(alternativeTextProp.Value);
	}

	private static void smethod_3(Shape domShape, Class2930 nameProp)
	{
		domShape.Name = smethod_8(nameProp.Value);
	}

	private static void smethod_4(Shape domShape, Class2944 props)
	{
		if (props[Enum426.const_424] is Class2932 @class)
		{
			domShape.GeometryTextFont = smethod_8(@class.Value);
		}
		if (props[Enum426.const_420] is Class2931 class2)
		{
			domShape.GeometryText = smethod_8(class2.Value);
		}
	}

	private static void smethod_5(Shape domShape, Class2669 sourceSpgrContainerFileBlock, Class854 slideDeserializationContext)
	{
		if (sourceSpgrContainerFileBlock.ClientData.MouseClickInteractiveInfo != null)
		{
			Class2882 interactiveInfoAtom = sourceSpgrContainerFileBlock.ClientData.MouseClickInteractiveInfo.InteractiveInfoAtom;
			if (interactiveInfoAtom != null && interactiveInfoAtom.ExHyperlinkIdRef != 0)
			{
				Hyperlink hyperlinkClick = Class1054.smethod_0(interactiveInfoAtom, slideDeserializationContext.DeserializationContext);
				domShape.HyperlinkClick = hyperlinkClick;
			}
		}
		Class881.smethod_0(domShape.CustomData, sourceSpgrContainerFileBlock.ClientData.ProgTags);
		if (domShape.CustomData.Tags.Contains(Class2729.string_0))
		{
			domShape.method_9(domShape.CustomData.Tags[Class2729.string_0]);
			domShape.CustomData.Tags.Remove(Class2729.string_0);
		}
	}

	private static void smethod_6(Shape domShape, Class2669 sourceSpgrContainerFileBlock)
	{
		Class273 pPTUnsupportedProps = domShape.PPTUnsupportedProps;
		pPTUnsupportedProps.OfficeArtSpContainer_ShapeProp = sourceSpgrContainerFileBlock.ShapeProp;
		pPTUnsupportedProps.OfficeArtSpContainer_ShapePrimaryOptions = sourceSpgrContainerFileBlock.ShapePrimaryOptions;
		pPTUnsupportedProps.OfficeArtSpContainer_ShapeSecondaryOptions = sourceSpgrContainerFileBlock.ShapeSecondaryOptions;
		pPTUnsupportedProps.OfficeArtSpContainer_ShapeTertiaryOptions = sourceSpgrContainerFileBlock.ShapeTertiaryOptions;
		if (sourceSpgrContainerFileBlock.ClientData == null)
		{
			return;
		}
		pPTUnsupportedProps.OfficeArtSpContainer_ClientData_ShapeFlagsAtom = sourceSpgrContainerFileBlock.ClientData.ShapeFlagsAtom;
		pPTUnsupportedProps.OfficeArtSpContainer_ClientData_ShapeFlags10Atom = sourceSpgrContainerFileBlock.ClientData.ShapeFlags10Atom;
		pPTUnsupportedProps.OfficeArtSpContainer_ClientData_MouseOverInteractiveInfo = sourceSpgrContainerFileBlock.ClientData.MouseOverInteractiveInfo;
		pPTUnsupportedProps.OfficeArtSpContainer_ClientData_RoundTripNewPlaceholderId12Atom = sourceSpgrContainerFileBlock.ClientData.RoundTripNewPlaceholderId12Atom;
		pPTUnsupportedProps.OfficeArtSpContainer_ClientData_RoundTripShapeId12Atom = sourceSpgrContainerFileBlock.ClientData.RoundTripShapeId12Atom;
		pPTUnsupportedProps.OfficeArtSpContainer_ClientData_RoundTripHFPlaceholder12Atom = sourceSpgrContainerFileBlock.ClientData.RoundTripHFPlaceholder12Atom;
		pPTUnsupportedProps.OfficeArtSpContainer_ClientData_RoundTripShapeCheckSumForCustomLayouts12Atom = sourceSpgrContainerFileBlock.ClientData.RoundTripShapeCheckSumForCustomLayouts12Atom;
		if (sourceSpgrContainerFileBlock.ClientData.AnimationInfo != null)
		{
			pPTUnsupportedProps.OfficeArtSpContainer_ClientData_AnimationInfo_AnimationAtom_DimColor = sourceSpgrContainerFileBlock.ClientData.AnimationInfo.AnimationAtom.DimColor;
			pPTUnsupportedProps.OfficeArtSpContainer_ClientData_AnimationInfo_AnimationAtom_Flags = sourceSpgrContainerFileBlock.ClientData.AnimationInfo.AnimationAtom.Flags;
			pPTUnsupportedProps.OfficeArtSpContainer_ClientData_AnimationInfo_AnimationAtom_OLEVerb = sourceSpgrContainerFileBlock.ClientData.AnimationInfo.AnimationAtom.OLEVerb;
		}
		if (sourceSpgrContainerFileBlock.ClientData.MouseClickInteractiveInfo != null)
		{
			pPTUnsupportedProps.OfficeArtSpContainer_ClientData_MouseClickInteractiveInfo_MacroName = sourceSpgrContainerFileBlock.ClientData.MouseClickInteractiveInfo.MacroName;
		}
		if (sourceSpgrContainerFileBlock.ClientData.ProgTags != null)
		{
			if (sourceSpgrContainerFileBlock.ClientData.ProgTags.PP10ShapeBinaryTagExtension != null)
			{
				pPTUnsupportedProps.OfficeArtSpContainer_ClientData_ProgTags_PP10ShapeBinaryTagExtension_StyleTextPropAtom = sourceSpgrContainerFileBlock.ClientData.ProgTags.PP10ShapeBinaryTagExtension.StyleTextPropAtom;
			}
			if (sourceSpgrContainerFileBlock.ClientData.ProgTags.PP11ShapeBinaryTagExtension != null)
			{
				pPTUnsupportedProps.OfficeArtSpContainer_ClientData_ProgTags_PP11ShapeBinaryTagExtension_StyleTextPropAtom = sourceSpgrContainerFileBlock.ClientData.ProgTags.PP11ShapeBinaryTagExtension.StyleTextPropAtom;
			}
		}
	}

	private static void smethod_7(Shape domShape, Class2670 shapeContainer, Class2669 sourceSpgrContainerFileBlock, Class854 slideDeserializationContext)
	{
		slideDeserializationContext.DeserializationContext.ShapeIdToFrame[domShape.PPTXUnsupportedProps.ShapeId] = sourceSpgrContainerFileBlock;
		if (sourceSpgrContainerFileBlock.ShapePrimaryOptions != null && shapeContainer.ClientData != null && shapeContainer.ClientData.PlaceholderAtom != null)
		{
			Class852 @class = null;
			if (slideDeserializationContext.FrameToPlaceholder.ContainsKey(shapeContainer))
			{
				@class = slideDeserializationContext.FrameToPlaceholder[shapeContainer];
			}
			if (@class != null)
			{
				Class1062.smethod_0(domShape, @class, slideDeserializationContext);
			}
			else
			{
				Class1062.smethod_0(domShape, new Class852(uint.MaxValue, null, shapeContainer), slideDeserializationContext);
			}
			if (@class != null)
			{
				Class1062.smethod_0(domShape, @class, slideDeserializationContext);
			}
			else
			{
				Class1062.smethod_0(domShape, new Class852(uint.MaxValue, null, shapeContainer), slideDeserializationContext);
			}
		}
		domShape.RawFrameImpl = Class230.smethod_0(shapeContainer);
	}

	internal static string smethod_8(byte[] value)
	{
		if (value != null && value.Length != 0)
		{
			UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
			char[] chars = unicodeEncoding.GetChars(value);
			if (chars != null && chars.Length > 0)
			{
				if (chars[chars.Length - 1] == '\0')
				{
					return new string(chars, 0, chars.Length - 1);
				}
				return new string(chars);
			}
			return null;
		}
		return null;
	}

	internal static void smethod_9(ITextFrame domTextFrame, Class2731 slideListWithTextContainer, Enum449 textType, Class201 shapeSerializationContext)
	{
		if (domTextFrame != null)
		{
			Class2642 @class = shapeSerializationContext.method_5();
			if (slideListWithTextContainer == null)
			{
				smethod_10((TextFrame)domTextFrame, @class.ContentRecords.ParentList, textType, shapeSerializationContext);
				return;
			}
			smethod_10((TextFrame)domTextFrame, slideListWithTextContainer.ContentRecords, textType, shapeSerializationContext);
			Class2951 currentSubTextFrame = slideListWithTextContainer.ContentRecords.CurrentSubTextFrame;
			Class2854 class2 = new Class2854(null);
			@class.ContentRecords.Add(class2);
			class2.Index = currentSubTextFrame.TextHeader.Header.Instance;
			slideListWithTextContainer.ContentRecords.method_4().CTexts = class2.Index + 1;
		}
	}

	internal static void smethod_10(TextFrame domTextFrame, Class2982 textSubRecordsList, Enum449 textType, Class201 shapeSerializationContext)
	{
		Class2859 @class = new Class2859(null);
		textSubRecordsList.method_2(@class);
		@class.TextType = textType;
		Class1066.smethod_16(domTextFrame, @class, shapeSerializationContext);
		Class1066.smethod_11(domTextFrame, textSubRecordsList, shapeSerializationContext);
	}

	internal static void smethod_11(IAutoShape domAutoShape, Class2834 odrawFopt, Class856 pptSerializationContext)
	{
		if (domAutoShape != null && domAutoShape.TextFrame != null)
		{
			TextFrame textFrame = (TextFrame)domAutoShape.TextFrame;
			Class2911 property = new Class2911(Enum426.const_405, pptSerializationContext.method_10());
			odrawFopt.Properties.method_0(property);
			Class1066.smethod_15(textFrame.TextFrameFormat, odrawFopt, pptSerializationContext);
		}
	}
}
