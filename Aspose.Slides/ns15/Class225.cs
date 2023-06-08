using System;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns16;
using ns18;
using ns56;
using ns57;
using ns60;
using ns63;
using ns64;

namespace ns15;

internal class Class225
{
	public static void smethod_0(Class2283 timeNodeElementData, Class2302.Delegate2653 addStCondLstDelegate, Class2302.Delegate2653 addEndCondLstDelegate, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeElementData == null)
		{
			return;
		}
		smethod_15(timeNodeElementData, timeNodeContainer.TimeNodeAtom, deserializationContext.DeserializationContext);
		smethod_1(timeNodeElementData, timeNodeContainer.TimePropertyList, deserializationContext.DeserializationContext);
		Class212.smethod_0(addStCondLstDelegate, timeNodeContainer.RgBeginTimeCondition, deserializationContext);
		Class212.smethod_0(addEndCondLstDelegate, timeNodeContainer.RgEndTimeCondition, deserializationContext);
		smethod_21(timeNodeElementData, timeNodeContainer.RgTimeModifierAtom);
		if (timeNodeContainer.TimeEndSyncTimeCondition != null)
		{
			Class2301 condElementData = timeNodeElementData.delegate2650_0();
			Class213.smethod_0(condElementData, timeNodeContainer.TimeEndSyncTimeCondition, deserializationContext);
		}
		if (timeNodeContainer.TimeIterateDataAtom != null)
		{
			Class2285 @class = timeNodeElementData.delegate2602_0();
			switch (timeNodeContainer.TimeIterateDataAtom.IterateIntervalType)
			{
			case 0u:
			{
				Class2287 class3 = (Class2287)@class.delegate2773_0("tmAbs").Object;
				class3.Val = smethod_18(BitConverter.ToSingle(BitConverter.GetBytes(timeNodeContainer.TimeIterateDataAtom.IterateInterval), 0));
				break;
			}
			case 1u:
			{
				Class2286 class2 = (Class2286)@class.delegate2773_0("tmPct").Object;
				class2.Val = BitConverter.ToSingle(BitConverter.GetBytes(timeNodeContainer.TimeIterateDataAtom.IterateInterval), 0);
				break;
			}
			}
			@class.Type = smethod_25(timeNodeContainer.TimeIterateDataAtom.IterateType);
			@class.Backwards = timeNodeContainer.TimeIterateDataAtom.IterateDirection == 0;
		}
		if (timeNodeContainer.RgExtTimeNodeChildren != null && timeNodeContainer.RgExtTimeNodeChildren.Length > 0)
		{
			Class2264 timeNodes = timeNodeElementData.delegate2539_0();
			Class227.smethod_0(timeNodes, timeNodeContainer.RgExtTimeNodeChildren, deserializationContext);
		}
		if (timeNodeContainer.RgSubEffect != null && timeNodeContainer.RgSubEffect.Length > 0)
		{
			Class2264 subTnElementData = timeNodeElementData.delegate2539_1();
			Class227.smethod_1(subTnElementData, timeNodeContainer.RgSubEffect, deserializationContext);
		}
	}

	public static void smethod_1(Class2283 timeNode, Class2662 timePropertyList, Class857 deserializationContext)
	{
		timeNode.PresetClass = smethod_9(timePropertyList, deserializationContext);
		timeNode.PresetID = smethod_2(timePropertyList, deserializationContext) + -2147483648L;
		timeNode.PresetSubtype = smethod_3(timePropertyList, deserializationContext) + -2147483648L;
		timeNode.TmFilter = smethod_4(timePropertyList, deserializationContext);
		timeNode.EvtFilter = smethod_5(timePropertyList, deserializationContext);
		timeNode.Display = smethod_8(timePropertyList, deserializationContext);
		timeNode.GrpId = (uint)smethod_12(timePropertyList, Enum399.const_11, deserializationContext);
		timeNode.AfterEffect = smethod_7(timePropertyList, deserializationContext);
		timeNode.NodeType = smethod_13(timePropertyList, deserializationContext);
		timeNode.NodePh = smethod_6(timePropertyList, deserializationContext);
		timeNode.MasterRel = smethod_11(timePropertyList, deserializationContext);
	}

	private static long smethod_2(Class2662 properties, Class857 deserializationContext)
	{
		long num = smethod_12(properties, Enum399.const_3, deserializationContext);
		if (num != -1L)
		{
			return num - -2147483648L;
		}
		return num;
	}

	private static long smethod_3(Class2662 properties, Class857 deserializationContext)
	{
		long num = smethod_12(properties, Enum399.const_4, deserializationContext);
		if (num != -1L)
		{
			return num - -2147483648L;
		}
		return num;
	}

	private static string smethod_4(Class2662 properties, Class857 deserializationContext)
	{
		if (properties == null)
		{
			deserializationContext.method_4("TimePropertyList4TimeNodeContainer is not exists.", WarningType.SourceFileCorruption);
			return null;
		}
		if (!(properties.method_5(Enum399.const_8) is Class2764 @class))
		{
			return null;
		}
		return @class.Value;
	}

	private static string smethod_5(Class2662 properties, Class857 deserializationContext)
	{
		if (properties == null)
		{
			deserializationContext.method_4("TimePropertyList4TimeNodeContainer is not exists.", WarningType.SourceFileCorruption);
			return null;
		}
		if (!(properties.method_5(Enum399.const_9) is Class2764 @class))
		{
			return null;
		}
		return @class.Value;
	}

	private static NullableBool smethod_6(Class2662 properties, Class857 deserializationContext)
	{
		if (properties == null)
		{
			deserializationContext.method_4("TimePropertyList4TimeNodeContainer is not exists.", WarningType.SourceFileCorruption);
			return NullableBool.NotDefined;
		}
		if (!(properties.method_5(Enum399.const_13) is Class2761 @class))
		{
			return NullableBool.NotDefined;
		}
		if (!@class.Value)
		{
			return NullableBool.False;
		}
		return NullableBool.True;
	}

	private static NullableBool smethod_7(Class2662 properties, Class857 deserializationContext)
	{
		if (properties == null)
		{
			deserializationContext.method_4("TimePropertyList4TimeNodeContainer is not exists.", WarningType.SourceFileCorruption);
			return NullableBool.NotDefined;
		}
		if (!(properties.method_5(Enum399.const_6) is Class2761 @class))
		{
			return NullableBool.NotDefined;
		}
		if (!@class.Value)
		{
			return NullableBool.False;
		}
		return NullableBool.True;
	}

	private static NullableBool smethod_8(Class2662 properties, Class857 deserializationContext)
	{
		if (properties == null)
		{
			deserializationContext.method_4("TimePropertyList4TimeNodeContainer is not exists.", WarningType.SourceFileCorruption);
			return NullableBool.NotDefined;
		}
		if (!(properties.method_5(Enum399.const_0) is Class2763 @class))
		{
			return NullableBool.NotDefined;
		}
		if (@class.Value != 0)
		{
			return NullableBool.False;
		}
		return NullableBool.True;
	}

	private static Enum296 smethod_9(Class2662 properties, Class857 deserializationContext)
	{
		return smethod_12(properties, Enum399.const_5, deserializationContext) switch
		{
			1 => Enum296.const_1, 
			2 => Enum296.const_2, 
			3 => Enum296.const_3, 
			4 => Enum296.const_4, 
			5 => Enum296.const_5, 
			6 => Enum296.const_6, 
			_ => Enum296.const_0, 
		};
	}

	private static int smethod_10(Enum296 presetClass)
	{
		return presetClass switch
		{
			Enum296.const_1 => 1, 
			Enum296.const_2 => 2, 
			Enum296.const_3 => 3, 
			Enum296.const_4 => 4, 
			Enum296.const_5 => 5, 
			Enum296.const_6 => 6, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static Enum293 smethod_11(Class2662 properties, Class857 deserializationContext)
	{
		if (properties == null)
		{
			deserializationContext.method_4("TimePropertyList4TimeNodeContainer is not exists.", WarningType.SourceFileCorruption);
			return Enum293.const_0;
		}
		if (!(properties.method_5(Enum399.const_1) is Class2763 @class))
		{
			return Enum293.const_0;
		}
		return @class.Value switch
		{
			0 => Enum293.const_1, 
			1 => Enum293.const_3, 
			_ => Enum293.const_0, 
		};
	}

	private static int smethod_12(Class2662 properties, Enum399 type, Class857 deserializationContext)
	{
		if (properties == null)
		{
			deserializationContext.method_4("TimePropertyList4TimeNodeContainer is not exists.", WarningType.SourceFileCorruption);
			return -1;
		}
		if (!(properties.method_5(type) is Class2763 @class))
		{
			return -1;
		}
		return @class.Value;
	}

	private static Enum303 smethod_13(Class2662 properties, Class857 deserializationContext)
	{
		return smethod_12(properties, Enum399.const_12, deserializationContext) switch
		{
			1 => Enum303.const_1, 
			2 => Enum303.const_2, 
			3 => Enum303.const_3, 
			4 => Enum303.const_4, 
			5 => Enum303.const_5, 
			6 => Enum303.const_6, 
			7 => Enum303.const_7, 
			8 => Enum303.const_8, 
			9 => Enum303.const_9, 
			_ => Enum303.const_0, 
		};
	}

	internal static int smethod_14(Enum303 type)
	{
		return type switch
		{
			Enum303.const_1 => 1, 
			Enum303.const_2 => 2, 
			Enum303.const_3 => 3, 
			Enum303.const_4 => 4, 
			Enum303.const_5 => 5, 
			Enum303.const_6 => 6, 
			Enum303.const_7 => 7, 
			Enum303.const_8 => 8, 
			Enum303.const_9 => 9, 
			_ => throw new NotImplementedException(), 
		};
	}

	public static void smethod_15(Class2283 timeNodeElementData, Class2755 timeNodeAtom, Class857 deserializationContext)
	{
		if (timeNodeAtom == null)
		{
			deserializationContext.method_4("TimeNodeAtom is not exists.", WarningType.SourceFileCorruption);
			return;
		}
		if (timeNodeAtom.FDurationProperty)
		{
			timeNodeElementData.Dur = smethod_18(smethod_16(timeNodeAtom));
		}
		if (timeNodeAtom.FRestartProperty)
		{
			timeNodeElementData.Restart = smethod_19(timeNodeAtom);
		}
		if (timeNodeAtom.FFillProperty)
		{
			timeNodeElementData.Fill = smethod_20(timeNodeAtom);
		}
	}

	internal static float smethod_16(Class2755 timeNode)
	{
		if (!timeNode.FDurationProperty)
		{
			return float.NaN;
		}
		return (float)timeNode.Duration / 1000f;
	}

	internal static int smethod_17(float value)
	{
		if (float.IsPositiveInfinity(value))
		{
			return -1;
		}
		return Convert.ToInt32(value * 1000f);
	}

	internal static string smethod_18(float value)
	{
		if (float.IsPositiveInfinity(value))
		{
			return "indefinite";
		}
		return XmlConvert.ToString((long)Math.Round(value * 1000f));
	}

	private static Enum298 smethod_19(Class2755 timeNodeAtom)
	{
		if (!timeNodeAtom.FRestartProperty)
		{
			return Enum298.const_0;
		}
		switch (timeNodeAtom.Restart)
		{
		default:
			return Enum298.const_0;
		case 1u:
			return Enum298.const_1;
		case 2u:
			return Enum298.const_2;
		case 0u:
		case 3u:
			return Enum298.const_3;
		}
	}

	private static Enum289 smethod_20(Class2755 timeNode)
	{
		switch (timeNode.Fill)
		{
		case 1u:
			return Enum289.const_1;
		default:
			return Enum289.const_0;
		case 0u:
		case 3u:
			return Enum289.const_3;
		}
	}

	public static void smethod_21(Class2283 timeNodeElementData, Class2753[] rgTimeModifierAtom)
	{
		timeNodeElementData.RepeatCount = smethod_18(1f);
		timeNodeElementData.RepeatDur = smethod_18(float.NaN);
		timeNodeElementData.Spd = 100f;
		timeNodeElementData.Accel = 0f;
		timeNodeElementData.Decel = 0f;
		timeNodeElementData.AutoRev = false;
		if (rgTimeModifierAtom != null)
		{
			foreach (Class2753 timeModifier in rgTimeModifierAtom)
			{
				smethod_22(timeNodeElementData, timeModifier);
			}
		}
	}

	private static void smethod_22(Class2283 timeNodeElementData, Class2753 timeModifier)
	{
		switch (timeModifier.TimeModifierType)
		{
		case 0u:
			timeNodeElementData.RepeatCount = smethod_18(smethod_23(timeModifier.Value));
			break;
		case 1u:
			timeNodeElementData.RepeatDur = smethod_18(BitConverter.ToSingle(BitConverter.GetBytes(timeModifier.Value), 0));
			break;
		case 2u:
			timeNodeElementData.Spd = BitConverter.ToSingle(BitConverter.GetBytes(timeModifier.Value), 0);
			break;
		case 3u:
			timeNodeElementData.Accel = BitConverter.ToSingle(BitConverter.GetBytes(timeModifier.Value), 0) * 100f;
			break;
		case 4u:
			timeNodeElementData.Decel = BitConverter.ToSingle(BitConverter.GetBytes(timeModifier.Value), 0) * 100f;
			break;
		case 5u:
			timeNodeElementData.AutoRev = timeModifier.Value != 0;
			break;
		}
	}

	private static float smethod_23(uint value)
	{
		return value switch
		{
			1077936128u => 3f, 
			1073741824u => 2f, 
			1065353216u => 1f, 
			1084227584u => 5f, 
			1082130432u => 4f, 
			2139095039u => 0f, 
			1092616192u => 10f, 
			_ => 1f, 
		};
	}

	private static uint smethod_24(float value)
	{
		if (value == 1f)
		{
			return 1065353216u;
		}
		if (value == 0f)
		{
			return 2139095039u;
		}
		if (value == 2f)
		{
			return 1073741824u;
		}
		if (value == 3f)
		{
			return 1077936128u;
		}
		if (value == 4f)
		{
			return 1082130432u;
		}
		if (value == 5f)
		{
			return 1084227584u;
		}
		if (value == 10f)
		{
			return 1092616192u;
		}
		return 1065353216u;
	}

	private static Enum276 smethod_25(uint type)
	{
		return type switch
		{
			0u => Enum276.const_0, 
			1u => Enum276.const_1, 
			2u => Enum276.const_2, 
			_ => Enum276.const_0, 
		};
	}

	public static void smethod_26(Class2305 sequenceElementData, Class2650 timeNodeContainer)
	{
		if (sequenceElementData != null && (sequenceElementData.Concurrent != NullableBool.NotDefined || sequenceElementData.PrevAc != Enum297.const_0 || sequenceElementData.NextAc != Enum294.const_0))
		{
			Class2758 @class = new Class2758();
			timeNodeContainer.Records.Add(@class);
			if (sequenceElementData.Concurrent != NullableBool.NotDefined)
			{
				@class.FConcurrencyPropertyUsed = true;
				@class.Concurrency = ((sequenceElementData.Concurrent == NullableBool.True) ? 1u : 0u);
			}
			else
			{
				@class.FConcurrencyPropertyUsed = false;
				@class.Concurrency = 0u;
			}
			if (sequenceElementData.NextAc != Enum294.const_0)
			{
				@class.FNextActionPropertyUsed = true;
				@class.NextAction = ((sequenceElementData.NextAc != 0) ? 1u : 0u);
			}
			else
			{
				@class.FNextActionPropertyUsed = false;
				@class.NextAction = 0u;
			}
			if (sequenceElementData.PrevAc != Enum297.const_0)
			{
				@class.FPreviousActionPropertyUsed = true;
				@class.PreviousAction = ((sequenceElementData.PrevAc != 0) ? 1u : 0u);
			}
			else
			{
				@class.FPreviousActionPropertyUsed = false;
				@class.PreviousAction = 0u;
			}
		}
	}

	public static void smethod_27(Class2283 commonElementData, Class2650 timeNodeContainer, Enum398 type)
	{
		if (commonElementData == null)
		{
			return;
		}
		Class2755 @class = new Class2755();
		timeNodeContainer.Records.Add(@class);
		@class.TimeNodeType = type;
		if (!string.IsNullOrEmpty(commonElementData.Dur))
		{
			@class.FDurationProperty = true;
			@class.Duration = smethod_17(Class1008.smethod_7(commonElementData.Dur));
		}
		else
		{
			@class.FDurationProperty = false;
			@class.Duration = 0;
		}
		if (commonElementData.Restart != Enum298.const_0)
		{
			@class.FRestartProperty = true;
			switch (commonElementData.Restart)
			{
			default:
				throw new NotImplementedException();
			case Enum298.const_1:
				@class.Restart = 1u;
				break;
			case Enum298.const_2:
				@class.Restart = 2u;
				break;
			case Enum298.const_3:
				@class.Restart = 3u;
				break;
			}
		}
		else
		{
			@class.FRestartProperty = false;
			@class.Restart = 0u;
		}
		if (commonElementData.Fill != Enum289.const_0)
		{
			@class.FFillProperty = true;
			switch (commonElementData.Fill)
			{
			case Enum289.const_1:
				@class.Fill = 1u;
				break;
			default:
				throw new NotImplementedException();
			case Enum289.const_3:
				@class.Fill = 3u;
				break;
			}
		}
		else
		{
			@class.FFillProperty = false;
			@class.Fill = 0u;
		}
		if (type == Enum398.const_2)
		{
			@class.FGroupingTypeProperty = true;
		}
		else
		{
			@class.FGroupingTypeProperty = false;
		}
	}

	public static void smethod_28(Class2283 commonElementData, Class2650 timeNodeContainer)
	{
		if (commonElementData != null)
		{
			Class2662 @class = new Class2662();
			timeNodeContainer.Records.Add(@class);
			if (commonElementData.PresetID != -2147483649L)
			{
				Class2763 class2 = new Class2763((int)commonElementData.PresetID);
				class2.Header.Instance = 9;
				@class.Records.Add(class2);
			}
			if (commonElementData.PresetClass != Enum296.const_0)
			{
				Class2763 class3 = new Class2763(smethod_10(commonElementData.PresetClass));
				class3.Header.Instance = 11;
				@class.Records.Add(class3);
			}
			if (commonElementData.PresetSubtype != -2147483649L)
			{
				Class2763 class4 = new Class2763((int)commonElementData.PresetSubtype);
				class4.Header.Instance = 10;
				@class.Records.Add(class4);
			}
			if (commonElementData.NodeType != Enum303.const_0)
			{
				Class2763 class5 = new Class2763(smethod_14(commonElementData.NodeType));
				class5.Header.Instance = 20;
				@class.Records.Add(class5);
			}
			if (commonElementData.GrpId != uint.MaxValue)
			{
				Class2763 class6 = new Class2763((int)commonElementData.GrpId);
				class6.Header.Instance = 19;
				@class.Records.Add(class6);
			}
			if (!string.IsNullOrEmpty(commonElementData.EvtFilter))
			{
				Class2764 class7 = new Class2764(commonElementData.EvtFilter);
				class7.Header.Instance = 17;
				@class.Records.Add(class7);
			}
			if (!string.IsNullOrEmpty(commonElementData.TmFilter))
			{
				Class2764 class8 = new Class2764(commonElementData.TmFilter);
				class8.Header.Instance = 16;
				@class.Records.Add(class8);
			}
			if (commonElementData.Display != NullableBool.NotDefined)
			{
				Class2763 class9 = new Class2763((commonElementData.Display == NullableBool.True) ? 1 : 0);
				class9.Header.Instance = 2;
				@class.Records.Add(class9);
			}
			if (commonElementData.AfterEffect != NullableBool.NotDefined)
			{
				Class2761 class10 = new Class2761(commonElementData.AfterEffect == NullableBool.True);
				class10.Header.Instance = 13;
				@class.Records.Add(class10);
			}
			if (commonElementData.NodePh != NullableBool.NotDefined)
			{
				Class2761 class11 = new Class2761(commonElementData.NodePh == NullableBool.True);
				class11.Header.Instance = 21;
				@class.Records.Add(class11);
			}
		}
	}

	public static void smethod_29(Class2283 commonElementData, Class2650 timeNodeContainer)
	{
		if (commonElementData != null && smethod_31(commonElementData))
		{
			if (!string.IsNullOrEmpty(commonElementData.RepeatCount))
			{
				Class2753 @class = new Class2753();
				@class.TimeModifierType = 0u;
				@class.Value = smethod_24((float)XmlConvert.ToUInt32(commonElementData.RepeatCount) / 1000f);
				timeNodeContainer.Records.Add(@class);
			}
			if (!string.IsNullOrEmpty(commonElementData.RepeatDur))
			{
				Class2753 class2 = new Class2753();
				class2.TimeModifierType = 1u;
				class2.Value = XmlConvert.ToUInt32(commonElementData.RepeatDur);
				timeNodeContainer.Records.Add(class2);
			}
			if (commonElementData.Spd != 100f)
			{
				Class2753 class3 = new Class2753();
				class3.TimeModifierType = 2u;
				class3.Value = Convert.ToUInt32(commonElementData.Spd) / 1000u;
				timeNodeContainer.Records.Add(class3);
			}
			if (commonElementData.Accel != 0f)
			{
				Class2753 class4 = new Class2753();
				class4.TimeModifierType = 3u;
				class4.Value = Convert.ToUInt32(commonElementData.Accel) / 1000u;
				timeNodeContainer.Records.Add(class4);
			}
			if (commonElementData.Decel != 0f)
			{
				Class2753 class5 = new Class2753();
				class5.TimeModifierType = 4u;
				class5.Value = Convert.ToUInt32(commonElementData.Decel) / 1000u;
				timeNodeContainer.Records.Add(class5);
			}
			if (commonElementData.AutoRev)
			{
				Class2753 class6 = new Class2753();
				class6.TimeModifierType = 5u;
				class6.Value = (commonElementData.AutoRev ? 1u : 0u);
				timeNodeContainer.Records.Add(class6);
			}
		}
	}

	private static bool smethod_30(Class2283 commonTnElementData)
	{
		if (commonTnElementData.Display == NullableBool.NotDefined && commonTnElementData.PresetSubtype == -2147483649L && commonTnElementData.PresetID == -2147483649L && commonTnElementData.PresetClass == Enum296.const_0 && commonTnElementData.AfterEffect == NullableBool.NotDefined && string.IsNullOrEmpty(commonTnElementData.TmFilter) && string.IsNullOrEmpty(commonTnElementData.EvtFilter) && commonTnElementData.GrpId == uint.MaxValue && commonTnElementData.NodeType == Enum303.const_0 && commonTnElementData.NodePh == NullableBool.NotDefined)
		{
			return false;
		}
		return true;
	}

	private static bool smethod_31(Class2283 commonTnElementData)
	{
		if (!(commonTnElementData.RepeatCount != "1000") && string.IsNullOrEmpty(commonTnElementData.RepeatDur) && commonTnElementData.Spd == 100f && commonTnElementData.Accel == 0f && commonTnElementData.Decel == 0f && !commonTnElementData.AutoRev)
		{
			return false;
		}
		return true;
	}

	internal static void smethod_32(Class2281 commonBehaviorElementData, Class2654 timeBehaviorContainer, Class234 timelineSerializationContext)
	{
		if (commonBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class222.smethod_5(commonBehaviorElementData, timeBehaviorContainer);
		Class222.smethod_6(commonBehaviorElementData, timeBehaviorContainer);
		Class228.smethod_8(commonBehaviorElementData.TgtEl, timeBehaviorContainer, timelineSerializationContext);
	}
}
