using System;
using System.Xml;
using Aspose.Slides;
using ns16;
using ns24;
using ns53;
using ns56;

namespace ns18;

internal class Class1195 : Class1190
{
	internal void method_7(IMasterSlide masterSlide)
	{
		method_0();
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "sldMaster")
			{
				Class2314 @class = new Class2314(base.XmlPartReader);
				Class899.smethod_0(masterSlide, @class.CSld, base.SlideDeserializationContext);
				Class931.smethod_1(masterSlide.ThemeManager, @class.ClrMap);
				Class992.smethod_0(masterSlide.SlideShowTransition, @class.Transition, base.DeserializationContext);
				Class2257 txStyles = @class.TxStyles;
				if (txStyles != null)
				{
					Class1003.smethod_0(masterSlide.TitleStyle, txStyles.TitleStyle, base.DeserializationContext);
					Class1003.smethod_0(masterSlide.BodyStyle, txStyles.BodyStyle, base.DeserializationContext);
					Class1003.smethod_0(masterSlide.OtherStyle, txStyles.OtherStyle, base.DeserializationContext);
				}
				masterSlide.Preserve = @class.Preserve;
				method_9(masterSlide, @class);
				method_8(masterSlide, @class);
				method_5(masterSlide.ThemeManager);
			}
		}
		method_2();
	}

	private void method_8(IMasterSlide masterSlide, Class2314 masterElementData)
	{
		base.DeserializationContext.MasterSlidePartPathToBackLinksFromLayouts.TryGetValue(base.Part.PartPath, out var value);
		if (masterElementData.SldLayoutIdLst != null)
		{
			Class2254[] sldLayoutIdList = masterElementData.SldLayoutIdLst.SldLayoutIdList;
			foreach (Class2254 @class in sldLayoutIdList)
			{
				string r_Id = @class.R_Id;
				Class1342 targetPart = base.DeserializationContext.RelationshipsOfCurrentPartEntry[r_Id].TargetPart;
				Class1194 class2 = new Class1194(targetPart, base.DeserializationContext);
				class2.method_7(masterSlide, out var layoutSlide);
				switch (base.DeserializationContext.Mode)
				{
				case Enum168.const_0:
					((LayoutSlide)layoutSlide).PPTXUnsupportedProps.SlideId = @class.Id;
					break;
				case Enum168.const_1:
					((LayoutSlide)layoutSlide).PPTXUnsupportedProps.SlideId = ((Presentation)masterSlide.Presentation).PPTXUnsupportedProps.method_2();
					break;
				case Enum168.const_2:
				case Enum168.const_3:
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				((Presentation)masterSlide.Presentation).PPTXUnsupportedProps.method_3(@class.Id);
				base.DeserializationContext.SlidePartPathToSlide.Add(targetPart.PartPath, layoutSlide);
				((LayoutSlide)layoutSlide).PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry = @class.ExtLst;
				value.Remove(targetPart.PartPath);
			}
		}
		if (value == null)
		{
			return;
		}
		foreach (Class1342 value2 in value.Values)
		{
			Class1194 class3 = new Class1194(value2, base.DeserializationContext);
			class3.method_7(masterSlide, out var layoutSlide2);
			base.DeserializationContext.SlidePartPathToSlide.Add(value2.PartPath, layoutSlide2);
		}
	}

	private void method_9(IMasterSlide masterSlide, Class2314 masterElementData)
	{
		Class300 pPTXUnsupportedProps = ((MasterSlide)masterSlide).PPTXUnsupportedProps;
		Class233 timelineDeserializationContext = new Class233(base.SlideDeserializationContext.DeserializationContext, base.SlideDeserializationContext.ShapeXmlIdToShape);
		Class1008.smethod_0(masterSlide.Timeline, masterElementData.Timing, timelineDeserializationContext);
		Class963.smethod_0(pPTXUnsupportedProps.HeaderFooter, masterElementData.Hf);
		pPTXUnsupportedProps.ExtensionList = masterElementData.ExtLst;
		Class2257 txStyles = masterElementData.TxStyles;
		if (txStyles != null)
		{
			pPTXUnsupportedProps.ExtensionListOfStyles = txStyles.ExtLst;
		}
	}

	internal void method_10(IMasterSlide masterSlide, bool writeLinkedLayouts)
	{
		method_3();
		Class2314 @class = new Class2314();
		Class300 pPTXUnsupportedProps = ((MasterSlide)masterSlide).PPTXUnsupportedProps;
		base.SerializationContext.SlideToSlidePart.Add(masterSlide, base.Part);
		method_6(masterSlide.Shapes, base.SlideSerializationContext);
		if (@class.Timing == null)
		{
			@class.delegate2524_0();
		}
		Class234 timelineSerializationContext = new Class234(base.SlideSerializationContext.SerializationContext, base.SlideSerializationContext.ShapeToShapeXmlId);
		Class1008.smethod_2(masterSlide.Timeline, masterSlide.Shapes, @class.Timing, timelineSerializationContext);
		Class899.smethod_2(masterSlide, @class.CSld, base.SlideSerializationContext);
		Class931.smethod_5(masterSlide.ThemeManager, @class.ClrMap);
		if (masterSlide.LayoutSlides.Count > 0 && writeLinkedLayouts)
		{
			Class2253 class2 = @class.delegate2506_0();
			foreach (LayoutSlide layoutSlide in masterSlide.LayoutSlides)
			{
				Class2254 class3 = class2.delegate2509_0();
				class3.Id = layoutSlide.PPTXUnsupportedProps.SlideId;
				class3.R_Id = base.Part.Relationships.method_1(base.SerializationContext.SlideToSlidePart[layoutSlide]).Id;
				class3.delegate1535_0(layoutSlide.PPTXUnsupportedProps.ExtensionListOfSlideIdListEntry);
			}
		}
		Class992.smethod_1(masterSlide.SlideShowTransition, @class.delegate21_0, base.SerializationContext);
		Class2257 class4 = @class.delegate2518_0();
		Class1003.smethod_1(masterSlide.TitleStyle, class4.delegate1741_0, base.SerializationContext);
		Class1003.smethod_1(masterSlide.BodyStyle, class4.delegate1741_1, base.SerializationContext);
		Class1003.smethod_1(masterSlide.OtherStyle, class4.delegate1741_2, base.SerializationContext);
		@class.Preserve = masterSlide.Preserve;
		Class963.smethod_1(pPTXUnsupportedProps.HeaderFooter, @class.delegate2458_0);
		@class.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		@class.TxStyles.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfStyles);
		@class.vmethod_4(null, base.XmlPartWriter, "sldMaster");
		method_4();
	}

	public Class1195(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1195(Class1342 part, Class1346 serializationContext, IBaseSlide slide)
		: base(part, serializationContext, slide)
	{
	}
}
