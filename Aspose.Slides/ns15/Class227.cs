using System;
using Aspose.Slides.Warnings;
using ns16;
using ns56;
using ns63;
using ns64;

namespace ns15;

internal class Class227
{
	public delegate void Delegate5(Class2662 propertyListContainer);

	public static void smethod_0(Class2264 timeNodes, Class2650[] timeNodeContainers, Class854 deserializationContext)
	{
		if (timeNodeContainers == null)
		{
			return;
		}
		foreach (Class2650 @class in timeNodeContainers)
		{
			switch (smethod_4(@class.TimeNodeAtom, deserializationContext.DeserializationContext))
			{
			case Enum398.const_0:
			{
				Class2304 class3 = (Class2304)timeNodes.delegate2773_0("par").Object;
				Class225.smethod_0(class3.CTn, class3.CTn.delegate2653_0, class3.CTn.delegate2653_1, @class, deserializationContext);
				break;
			}
			case Enum398.const_1:
			{
				Class2305 class2 = (Class2305)timeNodes.delegate2773_0("seq").Object;
				Class225.smethod_0(class2.CTn, class2.CTn.delegate2653_0, class2.CTn.delegate2653_1, @class, deserializationContext);
				break;
			}
			case Enum398.const_2:
				smethod_2(timeNodes, @class, deserializationContext);
				break;
			case Enum398.const_3:
			{
				Class2288 timeNodeMedia = (Class2288)timeNodes.delegate2773_0("audio").Object;
				Class224.smethod_1(timeNodeMedia, @class, deserializationContext);
				break;
			}
			default:
				throw new InvalidOperationException();
			}
		}
	}

	public static void smethod_1(Class2264 subTnElementData, Class2651[] timeNodeContainers, Class854 deserializationContext)
	{
		if (timeNodeContainers == null || timeNodeContainers.Length == 0)
		{
			return;
		}
		foreach (Class2651 @class in timeNodeContainers)
		{
			switch (smethod_4(@class.TimeNodeAtom, deserializationContext.DeserializationContext))
			{
			case Enum398.const_0:
			{
				Class2304 class3 = (Class2304)subTnElementData.delegate2773_0("par").Object;
				Class229.smethod_0(class3.CTn, class3.CTn.delegate2653_0, class3.CTn.delegate2653_1, @class, deserializationContext);
				break;
			}
			case Enum398.const_1:
			{
				Class2305 class2 = (Class2305)subTnElementData.delegate2773_0("seq").Object;
				Class229.smethod_0(class2.CTn, class2.CTn.delegate2653_0, class2.CTn.delegate2653_1, @class, deserializationContext);
				break;
			}
			case Enum398.const_2:
				smethod_3(subTnElementData, @class, deserializationContext);
				break;
			case Enum398.const_3:
			{
				Class2288 timeNodeMedia = (Class2288)subTnElementData.delegate2773_0("audio").Object;
				Class224.smethod_0(timeNodeMedia, @class, deserializationContext);
				break;
			}
			default:
				throw new InvalidOperationException();
			}
		}
	}

	private static void smethod_2(Class2264 timeNodes, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer.TimeAnimateBehavior != null)
		{
			Class2265 animBehaviorElementData = (Class2265)timeNodes.delegate2773_0("anim").Object;
			Class215.smethod_0(animBehaviorElementData, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeColorBehavior != null)
		{
			Class2266 timeNodeAnimateColorBehavior = (Class2266)timeNodes.delegate2773_0("animClr").Object;
			Class216.smethod_1(timeNodeAnimateColorBehavior, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeEffectBehavior != null)
		{
			Class2267 timeNodeAnimateEffectBehavior = (Class2267)timeNodes.delegate2773_0("animEffect").Object;
			Class217.smethod_0(timeNodeAnimateEffectBehavior, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeMotionBehavior != null)
		{
			Class2268 timeNodeAnimateMotion = (Class2268)timeNodes.delegate2773_0("animMotion").Object;
			Class218.smethod_0(timeNodeAnimateMotion, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeRotationBehavior != null)
		{
			Class2269 timeNodeAnimateRotationBehavior = (Class2269)timeNodes.delegate2773_0("animRot").Object;
			Class219.smethod_0(timeNodeAnimateRotationBehavior, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeScaleBehavior != null)
		{
			Class2270 timeNodeAnimateScaleBehavior = (Class2270)timeNodes.delegate2773_0("animScale").Object;
			Class220.smethod_0(timeNodeAnimateScaleBehavior, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeSetBehavior != null)
		{
			Class2293 timeNodeSetBehavior = (Class2293)timeNodes.delegate2773_0("set").Object;
			Class226.smethod_1(timeNodeSetBehavior, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeCommandBehavior != null)
		{
			Class2280 timeNodeCommandBehavior = (Class2280)timeNodes.delegate2773_0("cmd").Object;
			Class223.smethod_1(timeNodeCommandBehavior, timeNodeContainer, deserializationContext);
		}
	}

	private static void smethod_3(Class2264 timeNodes, Class2651 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer.TimeColorBehavior != null)
		{
			Class2266 timeNodeAnimateColorBehavior = (Class2266)timeNodes.delegate2773_0("animClr").Object;
			Class216.smethod_0(timeNodeAnimateColorBehavior, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeSetBehavior != null)
		{
			Class2293 timeNodeSetBehavior = (Class2293)timeNodes.delegate2773_0("set").Object;
			Class226.smethod_0(timeNodeSetBehavior, timeNodeContainer, deserializationContext);
		}
		if (timeNodeContainer.TimeCommandBehavior != null)
		{
			Class2280 timeNodeCommandBehavior = (Class2280)timeNodes.delegate2773_0("cmd").Object;
			Class223.smethod_0(timeNodeCommandBehavior, timeNodeContainer, deserializationContext);
		}
	}

	private static Enum398 smethod_4(Class2755 timeNode, Class857 deserializationContext)
	{
		if (timeNode == null)
		{
			deserializationContext.method_4("TimeNodeAtom is not exists.", WarningType.SourceFileCorruption);
			return Enum398.const_0;
		}
		if (!timeNode.FGroupingTypeProperty)
		{
			return Enum398.const_0;
		}
		return timeNode.TimeNodeType;
	}

	public static void smethod_5(Class2264 timeNodeListElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		smethod_6(timeNodeListElementData, timeNodeContainer, timelineSerializationContext, null);
	}

	public static void smethod_6(Class2264 timeNodeListElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext, Delegate5 writePropertyListEntryDelegate)
	{
		if (timeNodeListElementData == null)
		{
			return;
		}
		Class2605[] nodeList = timeNodeListElementData.NodeList;
		foreach (Class2605 @class in nodeList)
		{
			Class2650 class2 = new Class2650();
			timeNodeContainer.Records.Add(class2);
			switch (@class.Name)
			{
			case "par":
			{
				Class2304 class12 = (Class2304)@class.Object;
				Class225.smethod_27(class12.CTn, class2, Enum398.const_0);
				Class225.smethod_28(class12.CTn, class2);
				writePropertyListEntryDelegate?.Invoke(class2.TimePropertyList);
				Class212.smethod_1(class12.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class12.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class12.CTn, class2);
				smethod_5(class12.CTn.ChildTnLst, class2, timelineSerializationContext);
				break;
			}
			case "seq":
			{
				Class2305 class11 = (Class2305)@class.Object;
				Class225.smethod_27(class11.CTn, class2, Enum398.const_1);
				class2.TimeNodeAtom.FGroupingTypeProperty = true;
				Class225.smethod_28(class11.CTn, class2);
				Class225.smethod_26(class11, class2);
				Class212.smethod_1(class11.NextCondLst, class2, Enum396.const_3, timelineSerializationContext);
				Class212.smethod_1(class11.PrevCondLst, class2, Enum396.const_4, timelineSerializationContext);
				Class225.smethod_29(class11.CTn, class2);
				smethod_5(class11.CTn.ChildTnLst, class2, timelineSerializationContext);
				break;
			}
			case "anim":
			{
				Class2265 class10 = (Class2265)@class.Object;
				Class225.smethod_27(class10.CBhvr.CTn, class2, Enum398.const_2);
				Class225.smethod_28(class10.CBhvr.CTn, class2);
				Class215.smethod_7(class10, class2, timelineSerializationContext);
				Class212.smethod_1(class10.CBhvr.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class10.CBhvr.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class10.CBhvr.CTn, class2);
				break;
			}
			case "animClr":
			{
				Class2266 class9 = (Class2266)@class.Object;
				Class225.smethod_27(class9.CBhvr.CTn, class2, Enum398.const_2);
				Class225.smethod_28(class9.CBhvr.CTn, class2);
				Class216.smethod_5(class9, class2, timelineSerializationContext);
				Class212.smethod_1(class9.CBhvr.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class9.CBhvr.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class9.CBhvr.CTn, class2);
				break;
			}
			case "animEffect":
			{
				Class2267 class8 = (Class2267)@class.Object;
				Class225.smethod_27(class8.CBhvr.CTn, class2, Enum398.const_2);
				Class225.smethod_28(class8.CBhvr.CTn, class2);
				Class217.smethod_4(class8, class2, timelineSerializationContext);
				Class212.smethod_1(class8.CBhvr.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class8.CBhvr.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class8.CBhvr.CTn, class2);
				break;
			}
			case "animMotion":
			{
				Class2268 class7 = (Class2268)@class.Object;
				Class225.smethod_27(class7.CBhvr.CTn, class2, Enum398.const_2);
				Class225.smethod_28(class7.CBhvr.CTn, class2);
				Class218.smethod_3(class7, class2, timelineSerializationContext);
				Class212.smethod_1(class7.CBhvr.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class7.CBhvr.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class7.CBhvr.CTn, class2);
				break;
			}
			case "animRot":
			{
				Class2269 class6 = (Class2269)@class.Object;
				Class225.smethod_27(class6.CBhvr.CTn, class2, Enum398.const_2);
				Class225.smethod_28(class6.CBhvr.CTn, class2);
				Class219.smethod_1(class6, class2, timelineSerializationContext);
				Class212.smethod_1(class6.CBhvr.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class6.CBhvr.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class6.CBhvr.CTn, class2);
				break;
			}
			case "animScale":
			{
				Class2270 class5 = (Class2270)@class.Object;
				Class225.smethod_27(class5.CBhvr.CTn, class2, Enum398.const_2);
				Class225.smethod_28(class5.CBhvr.CTn, class2);
				Class220.smethod_1(class5, class2, timelineSerializationContext);
				Class212.smethod_1(class5.CBhvr.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class5.CBhvr.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class5.CBhvr.CTn, class2);
				break;
			}
			case "set":
			{
				Class2293 class4 = (Class2293)@class.Object;
				Class225.smethod_27(class4.CBhvr.CTn, class2, Enum398.const_2);
				Class225.smethod_28(class4.CBhvr.CTn, class2);
				Class226.smethod_3(class4, class2, timelineSerializationContext);
				Class212.smethod_1(class4.CBhvr.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class4.CBhvr.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class4.CBhvr.CTn, class2);
				break;
			}
			case "cmd":
			{
				Class2280 class3 = (Class2280)@class.Object;
				Class225.smethod_27(class3.CBhvr.CTn, class2, Enum398.const_2);
				Class225.smethod_28(class3.CBhvr.CTn, class2);
				Class223.smethod_5(class3, class2, timelineSerializationContext);
				Class212.smethod_1(class3.CBhvr.CTn.StCondLst, class2, Enum396.const_1, timelineSerializationContext);
				Class212.smethod_1(class3.CBhvr.CTn.EndCondLst, class2, Enum396.const_2, timelineSerializationContext);
				Class225.smethod_29(class3.CBhvr.CTn, class2);
				break;
			}
			case "audio":
				_ = (Class2288)@class.Object;
				timelineSerializationContext.method_3("Writing of the animation sound failed.", WarningType.DataLoss);
				break;
			default:
				throw new InvalidOperationException();
			}
		}
	}

	private static void smethod_7(Class2662 propertyListContainer)
	{
		Class2763 @class = new Class2763(6);
		@class.Header.Instance = 20;
		propertyListContainer.Records.Add(@class);
	}

	private static void smethod_8(Class2662 propertyListContainer)
	{
		Class2763 @class = new Class2763(7);
		@class.Header.Instance = 20;
		propertyListContainer.Records.Add(@class);
	}
}
