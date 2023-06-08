using Aspose.Slides;
using ns56;

namespace ns18;

internal class Class982
{
	public static void smethod_0(IShapeBevel shapeBevel, Class1806 bevelElementData)
	{
		if (bevelElementData != null)
		{
			shapeBevel.Width = bevelElementData.W;
			shapeBevel.Height = bevelElementData.H;
			shapeBevel.BevelType = bevelElementData.Prst;
		}
	}

	public static void smethod_1(IShapeBevel shapeBevel, Class1806.Delegate1297 addBevel)
	{
		if (shapeBevel.BevelType != BevelPresetType.NotDefined)
		{
			Class1806 @class = addBevel();
			@class.W = shapeBevel.Width;
			@class.H = shapeBevel.Height;
			@class.Prst = shapeBevel.BevelType;
		}
	}
}
