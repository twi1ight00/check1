using System.Xml;
using Aspose.Slides.Warnings;
using ns16;
using ns56;
using ns63;

namespace ns15;

internal class Class210
{
	public static void smethod_0(Class2312 slideElementData, Class854 slideDeserializationContext)
	{
		if (slideDeserializationContext.ProgTags == null)
		{
			return;
		}
		Class2728 @class = (Class2728)slideDeserializationContext.ProgTags;
		if (@class.PP10SlideBinaryTagExtension == null || @class.PP10SlideBinaryTagExtension.BuildListContainer == null || @class.PP10SlideBinaryTagExtension.BuildListContainer.RgChildRec == null || @class.PP10SlideBinaryTagExtension.BuildListContainer.RgChildRec.Length == 0)
		{
			return;
		}
		Class2224 class2 = slideElementData.Timing.delegate2408_0();
		Class2645[] rgChildRec = @class.PP10SlideBinaryTagExtension.BuildListContainer.RgChildRec;
		foreach (Class2645 class3 in rgChildRec)
		{
			if (class3 is Class2646 class4)
			{
				Class2278 class5 = (Class2278)class2.delegate2773_0("bldP").Object;
				class5.Build = smethod_1(class4.ParaBuildAtom.ParaBuild);
				class5.Spid = XmlConvert.ToString(class4.BuildAtom.ShapeIdRef);
				class5.AnimBg = class4.ParaBuildAtom.FAnimBackground == 1;
				class5.BldLvl = class4.ParaBuildAtom.BuildLevel;
				class5.Rev = class4.ParaBuildAtom.FReverse == 1;
			}
		}
	}

	private static Enum359 smethod_1(uint paraBuildType)
	{
		return paraBuildType switch
		{
			0u => Enum359.const_1, 
			1u => Enum359.const_2, 
			2u => Enum359.const_3, 
			3u => Enum359.const_4, 
			_ => Enum359.const_0, 
		};
	}

	public static void smethod_2(Class2259 timingElementData, Class2673 binaryTagExtension, Class234 timelineSerializationContext)
	{
		if (timingElementData == null || timingElementData.BldLst == null || timingElementData.BldLst.BuildList.Length == 0)
		{
			return;
		}
		Class2684 @class = new Class2684();
		binaryTagExtension.Records.Add(@class);
		Class2605[] buildList = timingElementData.BldLst.BuildList;
		foreach (Class2605 class2 in buildList)
		{
			switch (class2.Name)
			{
			case "bldOleChart":
			{
				Class2290 buildParaElementData3 = (Class2290)class2.Object;
				Class211.smethod_2(buildParaElementData3, @class, timelineSerializationContext);
				break;
			}
			case "bldDgm":
			{
				Class2277 buildParaElementData2 = (Class2277)class2.Object;
				Class211.smethod_1(buildParaElementData2, @class, timelineSerializationContext);
				break;
			}
			case "bldP":
			{
				Class2278 buildParaElementData = (Class2278)class2.Object;
				Class211.smethod_0(buildParaElementData, @class, timelineSerializationContext);
				break;
			}
			default:
				timelineSerializationContext.method_3("Writing of the animation build list failed.", WarningType.DataLoss);
				break;
			}
		}
	}
}
