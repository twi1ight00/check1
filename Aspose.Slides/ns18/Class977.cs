using Aspose.Slides;
using ns16;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class977
{
	internal static void smethod_0(ISlidesPicture picture, Class1809 blipElementData, Class1341 deserializationContext)
	{
		if (blipElementData == null)
		{
			return;
		}
		Class1348 relationshipsOfCurrentPartEntry = deserializationContext.RelationshipsOfCurrentPartEntry;
		if (blipElementData.R_Embed != null && blipElementData.R_Embed.Length > 0)
		{
			Class1347 @class = relationshipsOfCurrentPartEntry[blipElementData.R_Embed];
			if (@class != null)
			{
				picture.Image = deserializationContext.method_1(@class.TargetPart);
			}
		}
		picture.LinkPathLong = blipElementData.R_Link;
		if (picture.LinkPathLong != null && picture.LinkPathLong.Length > 0)
		{
			picture.LinkPathLong = relationshipsOfCurrentPartEntry[picture.LinkPathLong].Target;
		}
		Class942.smethod_0(picture.ImageTransform, blipElementData.EffectList, deserializationContext);
		((Picture)picture).PPTXUnsupportedProps.ExtLst = blipElementData.ExtLst;
	}

	internal static void smethod_1(ISlidesPicture picture, Class1809.Delegate1306 addBlip, Class1346 serializationContext)
	{
		if (picture != null)
		{
			Class1809 blipElementData = addBlip();
			smethod_2(picture, blipElementData, serializationContext);
		}
	}

	internal static void smethod_2(ISlidesPicture picture, Class1809 blipElementData, Class1346 serializationContext)
	{
		if (picture != null)
		{
			Class1342 @class = null;
			if (picture.Image != null)
			{
				@class = serializationContext.method_2(picture.Image);
			}
			if (@class != null)
			{
				blipElementData.R_Embed = serializationContext.RelationshipsOfCurrentPartEntry.method_4(@class).Id;
			}
			else if (picture.LinkPathLong != null)
			{
				blipElementData.R_Link = serializationContext.RelationshipsOfCurrentPartEntry.method_6(Class1305.class1338_0.Type, picture.LinkPathLong, Enum180.const_2).Id;
			}
			else
			{
				blipElementData.R_Embed = serializationContext.RelationshipsOfCurrentPartEntry.method_4(serializationContext.method_1(((ImageCollection)picture.Presentation.Images).NoImage)).Id;
			}
			Class942.smethod_1(picture.ImageTransform, blipElementData.delegate2773_0, serializationContext);
			blipElementData.delegate1535_0(((Picture)picture).PPTXUnsupportedProps.ExtLst);
		}
	}
}
