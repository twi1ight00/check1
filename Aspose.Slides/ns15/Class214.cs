using System;
using ns16;
using ns56;
using ns57;
using ns63;
using ns64;

namespace ns15;

internal class Class214
{
	public static void smethod_0(Class2312 slideElementData, Class854 slideDeserializationContext)
	{
		Class2728 @class = (Class2728)slideDeserializationContext.ProgTags;
		if (@class != null && @class.PP10SlideBinaryTagExtension != null && @class.PP10SlideBinaryTagExtension.ExtTimeNodeContainer != null)
		{
			Class2259 class2 = slideElementData.delegate2524_0();
			Class2264 timeNodes = class2.delegate2539_0();
			Class227.smethod_0(timeNodes, new Class2650[1] { @class.PP10SlideBinaryTagExtension.ExtTimeNodeContainer }, slideDeserializationContext);
		}
	}

	public static void smethod_1(Class2259 timingElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (timingElementData != null)
		{
			if (timingElementData.TnLst.NodeList == null || timingElementData.TnLst.NodeList.Length != 1)
			{
				throw new InvalidOperationException();
			}
			Class2605 @class = timingElementData.TnLst.NodeList[0];
			if (!(@class.Object is Class2304 class2))
			{
				throw new InvalidOperationException();
			}
			if (class2.CTn.NodeType != Enum303.const_9)
			{
				throw new InvalidOperationException();
			}
			Class225.smethod_27(class2.CTn, timeNodeContainer, Enum398.const_0);
			Class225.smethod_28(class2.CTn, timeNodeContainer);
			Class227.smethod_5(class2.CTn.ChildTnLst, timeNodeContainer, timelineSerializationContext);
		}
	}
}
