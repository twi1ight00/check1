using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;
using ns16;
using ns27;
using ns53;
using ns56;
using ns57;

namespace ns18;

internal class Class1019
{
	public static void smethod_0(Sequence sequence, Class2305 timeNodeSequenceElementData, Class233 timelineDeserializationContext)
	{
		if (timeNodeSequenceElementData == null)
		{
			throw new InvalidOperationException();
		}
		if (sequence.PPTXUnsupportedProps.SeqType == Enum303.const_5)
		{
			Class2301[] condList = timeNodeSequenceElementData.CTn.StCondLst.CondList;
			foreach (Class2301 @class in condList)
			{
				Enum277 evt = @class.Evt;
				if (evt == Enum277.const_5 && @class.Trigger.Object is Class2306 class2 && class2.Target.Name == "spTgt")
				{
					Class2294 class3 = class2.Target.Object as Class2294;
					sequence.TriggerShape = smethod_6(timelineDeserializationContext, class3.Spid);
				}
			}
		}
		if (timeNodeSequenceElementData.CTn.ChildTnLst != null)
		{
			Class2605[] nodeList = timeNodeSequenceElementData.CTn.ChildTnLst.NodeList;
			foreach (Class2605 class4 in nodeList)
			{
				if (class4.Name == "par")
				{
					Class2304 timeNodeParallelElementData = class4.Object as Class2304;
					smethod_2(sequence, null, timeNodeParallelElementData, timelineDeserializationContext);
					continue;
				}
				throw new PptxException("fail!");
			}
		}
		smethod_1(sequence, timeNodeSequenceElementData);
	}

	private static void smethod_1(Sequence sequence, Class2305 timeNodeSequenceElementData)
	{
		if (sequence == null || timeNodeSequenceElementData == null || timeNodeSequenceElementData.CTn.ChildTnLst == null || timeNodeSequenceElementData.CTn.ChildTnLst.NodeList == null)
		{
			return;
		}
		int num = 1;
		Class2605[] nodeList = timeNodeSequenceElementData.CTn.ChildTnLst.NodeList;
		foreach (Class2605 @class in nodeList)
		{
			if (!(@class.Object is Class2304 class2))
			{
				continue;
			}
			foreach (IEffect effect2 in sequence.PPTXUnsupportedProps.Effects)
			{
				Effect effect = (Effect)effect2;
				if (effect.PPTXUnsupportedProps.RootParRef == null)
				{
					effect.PPTXUnsupportedProps.TimelineGroupId = 0;
				}
				else if (effect.PPTXUnsupportedProps.RootParRef.CTn.Id > class2.CTn.Id)
				{
					effect.PPTXUnsupportedProps.TimelineGroupId = num;
				}
			}
			num++;
		}
	}

	public static void smethod_2(Sequence sequence, Class2304 rootTimeNodeParallelElementData, Class2304 timeNodeParallelElementData, Class233 timelineDeserializationContext)
	{
		Class2283 cTn = timeNodeParallelElementData.CTn;
		if (cTn.PresetID - -2147483648L != -1L)
		{
			Effect item = smethod_3(sequence, rootTimeNodeParallelElementData, cTn, timelineDeserializationContext);
			sequence.PPTXUnsupportedProps.Effects.Add(item);
		}
		if (cTn.ChildTnLst == null)
		{
			return;
		}
		Class2605[] nodeList = cTn.ChildTnLst.NodeList;
		foreach (Class2605 @class in nodeList)
		{
			if (@class.Object is Class2304 timeNodeParallelElementData2)
			{
				smethod_2(sequence, timeNodeParallelElementData, timeNodeParallelElementData2, timelineDeserializationContext);
			}
		}
	}

	private static Effect smethod_3(Sequence sequence, Class2304 rootTimeNodeParallelElementData, Class2283 commonTimeNodeElementData, Class233 timelineDeserializationContext)
	{
		long presetID = commonTimeNodeElementData.PresetID;
		long presetSubtype = commonTimeNodeElementData.PresetSubtype;
		Effect effect = new Effect(sequence);
		effect.Timing.Accelerate = commonTimeNodeElementData.Accel / 100f;
		effect.Timing.Decelerate = commonTimeNodeElementData.Decel / 100f;
		effect.Timing.AutoReverse = commonTimeNodeElementData.AutoRev;
		effect.Timing.RepeatCount = Class1008.smethod_7(commonTimeNodeElementData.RepeatCount);
		effect.Timing.RepeatDuration = Class1008.smethod_7(commonTimeNodeElementData.RepeatDur);
		effect.Timing.Restart = (EffectRestartType)commonTimeNodeElementData.Restart;
		effect.Timing.Speed = commonTimeNodeElementData.Spd / 100f;
		effect.Timing.Duration = Class1008.smethod_7(commonTimeNodeElementData.Dur);
		effect.PPTXUnsupportedProps.RootParRef = rootTimeNodeParallelElementData;
		if (commonTimeNodeElementData.StCondLst != null)
		{
			Class2301[] condList = commonTimeNodeElementData.StCondLst.CondList;
			foreach (Class2301 @class in condList)
			{
				if (@class.Delay != "indefinite")
				{
					effect.Timing.TriggerDelayTime = Class1008.smethod_7(@class.Delay);
				}
			}
		}
		if (sequence.PPTXUnsupportedProps.ShapeRef != null)
		{
			effect.Timing.TriggerType = sequence.PPTXUnsupportedProps.TriggerNew;
		}
		else
		{
			switch (commonTimeNodeElementData.NodeType)
			{
			default:
				throw new PptxException("Not found approriate value!");
			case Enum303.const_1:
				effect.Timing.TriggerType = EffectTriggerType.OnClick;
				break;
			case Enum303.const_2:
				effect.Timing.TriggerType = EffectTriggerType.WithPrevious;
				break;
			case Enum303.const_3:
				effect.Timing.TriggerType = EffectTriggerType.AfterPrevious;
				break;
			}
		}
		Class2605[] nodeList = commonTimeNodeElementData.ChildTnLst.NodeList;
		foreach (Class2605 behaviorNode in nodeList)
		{
			IBehavior behavior = null;
			Class2281 behaviorElement = null;
			if (smethod_7(behaviorNode, sequence, out behavior, out behaviorElement))
			{
				((Behavior)behavior).PPTXUnsupportedProps.ParentEffect = effect;
				Class1010.smethod_0(behavior, behaviorNode, timelineDeserializationContext);
				effect.Behaviors.Add(behavior);
				smethod_4(sequence, behaviorElement, effect, behavior, timelineDeserializationContext);
			}
		}
		effect.PPTXUnsupportedProps.ListSubTn = commonTimeNodeElementData.SubTnLst;
		if (commonTimeNodeElementData.SubTnLst != null)
		{
			Class2605[] nodeList2 = commonTimeNodeElementData.SubTnLst.NodeList;
			foreach (Class2605 class2 in nodeList2)
			{
				if (class2.Object is Class2288 class3 && class3.CMediaNode.TgtEl != null && class3.CMediaNode.TgtEl.Target.Object is Class1838 class4)
				{
					effect.PPTXUnsupportedProps.EmbeddedSound = timelineDeserializationContext.method_0(class4.R_Embed);
				}
			}
		}
		if (commonTimeNodeElementData.Iterate != null)
		{
			effect.PPTXUnsupportedProps.IterateBackwards = commonTimeNodeElementData.Iterate.Backwards;
			effect.PPTXUnsupportedProps.IterateType = commonTimeNodeElementData.Iterate.Type;
			effect.PPTXUnsupportedProps.IterateTimeValue = smethod_8(commonTimeNodeElementData.Iterate.IterateInterval);
		}
		effect.PPTXUnsupportedProps.Fill = (EffectFillType)commonTimeNodeElementData.Fill;
		effect.PPTXUnsupportedProps.TnClassType = commonTimeNodeElementData.PresetClass;
		switch (effect.PPTXUnsupportedProps.TnClassType)
		{
		case Enum296.const_1:
			effect.PPTXUnsupportedProps.EffectClassType = EffectPresetClassType.Entrance;
			break;
		case Enum296.const_2:
			effect.PPTXUnsupportedProps.EffectClassType = EffectPresetClassType.Exit;
			break;
		case Enum296.const_3:
			effect.PPTXUnsupportedProps.EffectClassType = EffectPresetClassType.Emphasis;
			break;
		case Enum296.const_4:
			effect.PPTXUnsupportedProps.EffectClassType = EffectPresetClassType.Path;
			break;
		case Enum296.const_6:
			effect.PPTXUnsupportedProps.EffectClassType = EffectPresetClassType.MediaCall;
			break;
		}
		effect.PPTXUnsupportedProps.GrId = (int)commonTimeNodeElementData.GrpId;
		effect.PPTXUnsupportedProps.BAnimBg = smethod_9(Class1008.smethod_9(commonTimeNodeElementData.ChildTnLst.NodeList[0])) == Enum299.const_1;
		effect.PPTXUnsupportedProps.TypeInternal = Class363.smethod_4(presetID, commonTimeNodeElementData.PresetClass);
		effect.PPTXUnsupportedProps.SubtypeInternal = Class363.smethod_2(effect.PPTXUnsupportedProps.TnClassType, effect.PPTXUnsupportedProps.TypeInternal, presetSubtype);
		return effect;
	}

	private static void smethod_4(Sequence sequence, Class2281 commonBehavior, Effect effect, IBehavior behavior, Class233 timelineDeserializationContext)
	{
		Class360 pPTXUnsupportedProps = ((Behavior)behavior).PPTXUnsupportedProps;
		Class2283 cTn = commonBehavior.CTn;
		behavior.Timing.Duration = Class1008.smethod_7(cTn.Dur);
		behavior.Timing.Accelerate = cTn.Accel / 100f;
		behavior.Timing.Decelerate = cTn.Decel / 100f;
		behavior.Timing.AutoReverse = cTn.AutoRev;
		behavior.Timing.RepeatCount = Class1008.smethod_7(cTn.RepeatCount);
		behavior.Timing.RepeatDuration = Class1008.smethod_7(cTn.RepeatDur);
		behavior.Timing.Restart = (EffectRestartType)cTn.Restart;
		behavior.Timing.Speed = cTn.Spd / 100f;
		pPTXUnsupportedProps.Override = commonBehavior.Override;
		pPTXUnsupportedProps.TimeFilter = cTn.TmFilter;
		pPTXUnsupportedProps.FillType = (EffectFillType)cTn.Fill;
		pPTXUnsupportedProps.RuntimeContext = commonBehavior.Rctx;
		switch (commonBehavior.Accumulate)
		{
		case Enum284.const_0:
			behavior.Accumulate = NullableBool.NotDefined;
			break;
		case Enum284.const_1:
			behavior.Accumulate = NullableBool.False;
			break;
		case Enum284.const_2:
			behavior.Accumulate = NullableBool.True;
			break;
		}
		behavior.Additive = (BehaviorAdditiveType)commonBehavior.Additive;
		if (cTn.StCondLst != null)
		{
			Class2301[] condList = cTn.StCondLst.CondList;
			foreach (Class2301 @class in condList)
			{
				float num = Class1008.smethod_7(@class.Delay);
				if (!float.IsNaN(num))
				{
					behavior.Timing.TriggerDelayTime = num;
				}
			}
		}
		if (sequence.PPTXUnsupportedProps.ShapeRef != null)
		{
			effect.PPTXUnsupportedProps.ShapeTarget = sequence.PPTXUnsupportedProps.ShapeRef;
			return;
		}
		Class2306 tgtEl = commonBehavior.TgtEl;
		if (tgtEl.Target == null)
		{
			return;
		}
		switch (tgtEl.Target.Name)
		{
		case "spTgt":
		{
			Class2294 class2 = tgtEl.Target.Object as Class2294;
			effect.PPTXUnsupportedProps.ShapeTargetElement = class2;
			effect.PPTXUnsupportedProps.ShapeTarget = smethod_6(timelineDeserializationContext, class2.Spid);
			Class2605 targetShape = class2.TargetShape;
			if (targetShape == null || !(targetShape.Name == "txEl"))
			{
				break;
			}
			Class2298 class3 = targetShape.Object as Class2298;
			if (class3.Range.Name == "pRg" && effect.PPTXUnsupportedProps.ShapeTarget != null)
			{
				if (effect.PPTXUnsupportedProps.ShapeTarget is AutoShape autoShape)
				{
					IParagraphCollection paragraphs = autoShape.TextFrame.Paragraphs;
					try
					{
						Class2239 class4 = class3.Range.Object as Class2239;
						effect.method_1((Paragraph)paragraphs[(int)class4.St], (Paragraph)paragraphs[(int)class4.End]);
						break;
					}
					catch (IndexOutOfRangeException exception)
					{
						throw new PptxReadException("Animated paragraph index inconsistent", exception);
					}
				}
			}
			else if (class3.Range.Name == "charRg" && effect.PPTXUnsupportedProps.ShapeTarget != null)
			{
				effect.PPTXUnsupportedProps.CharRgRef = class3.Range.Object as Class2239;
			}
			break;
		}
		default:
			throw new PptxException("fail!");
		case "bg":
			break;
		case "inkTgt":
			break;
		case "sldTgt":
			break;
		case "sndTgt":
			break;
		}
	}

	internal static IShape smethod_5(Class233 timelineDeserializationContext, Class2306 target)
	{
		if (target.Target.Name == "spTgt")
		{
			Class2294 @class = target.Target.Object as Class2294;
			return smethod_6(timelineDeserializationContext, @class.Spid);
		}
		return null;
	}

	internal static IShape smethod_6(Class233 timelineDeserializationContext, string spId)
	{
		if (spId == null)
		{
			return null;
		}
		if (timelineDeserializationContext.ShapeXmlIdToShape.ContainsKey(spId))
		{
			return (IShape)timelineDeserializationContext.ShapeXmlIdToShape[spId];
		}
		return null;
	}

	private static bool smethod_7(Class2605 behaviorNode, Sequence sequence, out IBehavior behavior, out Class2281 behaviorElement)
	{
		if (behaviorNode.Name == "animMotion")
		{
			Class2268 @class = behaviorNode.Object as Class2268;
			behaviorElement = @class.CBhvr;
			behavior = sequence.PPTXUnsupportedProps.BehaviorFactory.CreateMotionEffect();
		}
		else if (behaviorNode.Name == "set")
		{
			Class2293 class2 = behaviorNode.Object as Class2293;
			behaviorElement = class2.CBhvr;
			behavior = sequence.PPTXUnsupportedProps.BehaviorFactory.CreateSetEffect();
		}
		else if (behaviorNode.Name == "animEffect")
		{
			Class2267 class3 = behaviorNode.Object as Class2267;
			behaviorElement = class3.CBhvr;
			behavior = sequence.PPTXUnsupportedProps.BehaviorFactory.CreateFilterEffect();
		}
		else if (behaviorNode.Name == "anim")
		{
			Class2265 class4 = behaviorNode.Object as Class2265;
			behaviorElement = class4.CBhvr;
			behavior = sequence.PPTXUnsupportedProps.BehaviorFactory.CreatePropertyEffect();
		}
		else if (behaviorNode.Name == "animClr")
		{
			Class2266 class5 = behaviorNode.Object as Class2266;
			behaviorElement = class5.CBhvr;
			behavior = sequence.PPTXUnsupportedProps.BehaviorFactory.CreateColorEffect();
		}
		else if (behaviorNode.Name == "animScale")
		{
			Class2270 class6 = behaviorNode.Object as Class2270;
			behaviorElement = class6.CBhvr;
			behavior = sequence.PPTXUnsupportedProps.BehaviorFactory.CreateScaleEffect();
		}
		else if (behaviorNode.Name == "animRot")
		{
			Class2269 class7 = behaviorNode.Object as Class2269;
			behaviorElement = class7.CBhvr;
			behavior = sequence.PPTXUnsupportedProps.BehaviorFactory.CreateRotationEffect();
		}
		else if (behaviorNode.Name == "cmd")
		{
			Class2280 class8 = behaviorNode.Object as Class2280;
			behaviorElement = class8.CBhvr;
			behavior = sequence.PPTXUnsupportedProps.BehaviorFactory.CreateCommandEffect();
		}
		else
		{
			behavior = null;
			behaviorElement = null;
		}
		return behavior != null;
	}

	private static float smethod_8(Class2605 iterateTime)
	{
		switch (iterateTime.Name)
		{
		case "tmPct":
		{
			Class2286 class2 = (Class2286)iterateTime.Object;
			return 0f - class2.Val;
		}
		default:
			throw new Exception("Unknown element \"" + iterateTime.Name + "\"");
		case "tmAbs":
		{
			Class2287 @class = (Class2287)iterateTime.Object;
			return Class1008.smethod_7(@class.Val);
		}
		}
	}

	private static Enum299 smethod_9(Class2281 commonBehavior)
	{
		if (commonBehavior != null && commonBehavior.TgtEl != null && commonBehavior.TgtEl.Target != null)
		{
			if (commonBehavior.TgtEl.Target.Object is Class2294 @class && @class.TargetShape != null)
			{
				return @class.TargetShape.Name switch
				{
					"graphicEl" => Enum299.const_5, 
					"txEl" => Enum299.const_4, 
					"oleChartEl" => Enum299.const_3, 
					"subSp" => Enum299.const_2, 
					"bg" => Enum299.const_1, 
					_ => throw new InvalidOperationException("Unknown element"), 
				};
			}
			return Enum299.const_0;
		}
		return Enum299.const_0;
	}

	internal static void smethod_10(Sequence sequence, ref int nodeCounter, Class2264 parChilds, Class234 timelineSerializationContext)
	{
		if (sequence.Count == 0)
		{
			return;
		}
		Class2305 @class = null;
		if (sequence.PPTXUnsupportedProps.SeqType == Enum303.const_4)
		{
			nodeCounter++;
			@class = smethod_16(parChilds.delegate2773_0, nodeCounter);
		}
		else if (sequence.PPTXUnsupportedProps.SeqType == Enum303.const_5)
		{
			if (!timelineSerializationContext.method_0(sequence.TriggerShape))
			{
				return;
			}
			nodeCounter++;
			@class = smethod_17(sequence, parChilds.delegate2773_0, nodeCounter);
		}
		Class2264 sequenceChildsElementData = @class.CTn.delegate2539_0();
		sequence.PPTXUnsupportedProps.NNodeCounter = nodeCounter;
		sequence.PPTXUnsupportedProps.ParLastEffect = null;
		if (sequence.PPTXUnsupportedProps.Effects.Count == 0)
		{
			smethod_12(sequence, sequenceChildsElementData);
		}
		else
		{
			Dictionary<int, Class2304> dictionary = new Dictionary<int, Class2304>();
			Class2304 class2 = null;
			for (int i = 0; i < sequence.PPTXUnsupportedProps.Effects.Count; i++)
			{
				Effect effect = (Effect)sequence.PPTXUnsupportedProps.Effects[i];
				if (timelineSerializationContext.method_0(effect.PPTXUnsupportedProps.ShapeTarget))
				{
					if (!dictionary.ContainsKey(effect.PPTXUnsupportedProps.TimelineGroupId))
					{
						class2 = smethod_12(sequence, sequenceChildsElementData);
						class2.CTn.delegate2539_0();
						dictionary.Add(effect.PPTXUnsupportedProps.TimelineGroupId, class2);
					}
					else
					{
						class2 = dictionary[effect.PPTXUnsupportedProps.TimelineGroupId];
					}
					if (i > 0 && effect.Timing.TriggerType == EffectTriggerType.OnClick)
					{
						smethod_11(sequence, class2.CTn.ChildTnLst.delegate2773_0);
					}
					smethod_14(sequence, effect, class2.CTn.ChildTnLst.delegate2773_0, timelineSerializationContext);
				}
			}
		}
		nodeCounter = sequence.PPTXUnsupportedProps.NNodeCounter;
	}

	internal static Class2304 smethod_11(Sequence sequence, Class2605.Delegate2773 addNodeDelegate)
	{
		sequence.PPTXUnsupportedProps.FDelaySum = 0f;
		sequence.PPTXUnsupportedProps.FDelayEffectLast = 0f;
		Class2304 @class = (Class2304)addNodeDelegate("par").Object;
		sequence.PPTXUnsupportedProps.ParLastJoint = @class;
		@class.CTn.Id = ++sequence.PPTXUnsupportedProps.NNodeCounter;
		@class.CTn.Fill = Enum289.const_3;
		Class2302 class2 = @class.CTn.delegate2653_0();
		Class2301 class3 = class2.delegate2650_0();
		class3.Delay = Class1008.smethod_6(float.PositiveInfinity);
		return @class;
	}

	private static Class2304 smethod_12(Sequence sequence, Class2264 sequenceChildsElementData)
	{
		Class2304 @class = smethod_11(sequence, sequenceChildsElementData.delegate2773_0);
		if (sequence.PPTXUnsupportedProps.SeqType == Enum303.const_5)
		{
			@class.CTn.StCondLst.CondList[0].Delay = Class1008.smethod_6(0f);
		}
		smethod_13(sequence, @class.CTn.StCondLst.delegate2650_0);
		return @class;
	}

	private static void smethod_13(Sequence sequence, Class2301.Delegate2650 addConditionDelegate)
	{
		Effect effect = (Effect)sequence.PPTXUnsupportedProps.Effects[0];
		if (effect.Timing.TriggerType == EffectTriggerType.AfterPrevious || effect.Timing.TriggerType == EffectTriggerType.WithPrevious)
		{
			Class2301 @class = addConditionDelegate();
			@class.Delay = Class1008.smethod_6(0f);
			@class.Evt = Enum277.const_1;
			Class2308 class2 = (Class2308)@class.delegate2773_0("tn").Object;
			if (sequence.PPTXUnsupportedProps.NNodeCounter != 1)
			{
				class2.Val = sequence.PPTXUnsupportedProps.NNodeCounter - 1;
			}
		}
	}

	internal static void smethod_14(Sequence sequence, Effect effect, Class2605.Delegate2773 addNodeDelegate, Class234 timelineSerializationContext)
	{
		Class2304 @class = ((effect.Timing.TriggerType != EffectTriggerType.WithPrevious || sequence.PPTXUnsupportedProps.ParLastEffect == null) ? smethod_15(effect, sequence, addNodeDelegate) : sequence.PPTXUnsupportedProps.ParLastEffect);
		Class2264 class2 = @class.CTn.ChildTnLst;
		if (class2 == null)
		{
			class2 = @class.CTn.delegate2539_0();
		}
		Class2304 class3 = (Class2304)class2.delegate2773_0("par").Object;
		class3.CTn.Id = ++sequence.PPTXUnsupportedProps.NNodeCounter;
		class3.CTn.PresetID = Class363.smethod_0(effect.PPTXUnsupportedProps.TypeInternal, effect.PPTXUnsupportedProps.TnClassType);
		class3.CTn.PresetSubtype = Class363.smethod_3(effect.PPTXUnsupportedProps.SubtypeInternal);
		class3.CTn.PresetClass = effect.PPTXUnsupportedProps.TnClassType;
		class3.CTn.Accel = effect.Timing.Accelerate * 100f;
		class3.CTn.Decel = effect.Timing.Decelerate * 100f;
		class3.CTn.AutoRev = effect.Timing.AutoReverse;
		class3.CTn.Restart = (Enum298)effect.Timing.Restart;
		class3.CTn.Spd = effect.Timing.Speed * 100f;
		if (effect.PPTXUnsupportedProps.GrId != -1)
		{
			class3.CTn.GrpId = (uint)effect.PPTXUnsupportedProps.GrId;
		}
		if (!float.IsNaN(effect.Timing.Duration))
		{
			class3.CTn.Dur = Class1008.smethod_6(effect.Timing.Duration);
		}
		if (effect.Timing.RepeatCount != 1f)
		{
			class3.CTn.RepeatCount = Class1008.smethod_6(effect.Timing.RepeatCount);
		}
		class3.CTn.Fill = (Enum289)effect.PPTXUnsupportedProps.Fill;
		if (effect.PPTXUnsupportedProps.IterateBackwards || effect.PPTXUnsupportedProps.IterateType != 0 || effect.PPTXUnsupportedProps.IterateTimeValue != 0f)
		{
			Class2285 class4 = class3.CTn.delegate2602_0();
			class4.Backwards = effect.PPTXUnsupportedProps.IterateBackwards;
			class4.Type = effect.PPTXUnsupportedProps.IterateType;
			smethod_20(class4.delegate2773_0, effect.PPTXUnsupportedProps.IterateTimeValue);
		}
		effect.PPTXUnsupportedProps.ParRef = class3;
		switch (effect.Timing.TriggerType)
		{
		default:
			throw new PptxException("fail.");
		case EffectTriggerType.AfterPrevious:
			class3.CTn.NodeType = Enum303.const_3;
			break;
		case EffectTriggerType.OnClick:
			class3.CTn.NodeType = Enum303.const_1;
			break;
		case EffectTriggerType.WithPrevious:
			class3.CTn.NodeType = Enum303.const_2;
			break;
		}
		Class2301 class5 = smethod_21(class3.CTn.delegate2653_0);
		class5.Delay = Class1008.smethod_6(effect.Timing.TriggerDelayTime);
		sequence.PPTXUnsupportedProps.FDelayEffect = 0f;
		Class2264 class6 = null;
		if (effect.Behaviors.Count > 0)
		{
			class6 = class3.CTn.delegate2539_0();
		}
		foreach (IBehavior behavior in effect.Behaviors)
		{
			Class360 pPTXUnsupportedProps = ((Behavior)behavior).PPTXUnsupportedProps;
			Class2281 commonBehaviorElementData = null;
			Class1010.smethod_1(behavior, class6.delegate2773_0, ref commonBehaviorElementData);
			if (commonBehaviorElementData != null)
			{
				switch (behavior.Accumulate)
				{
				case NullableBool.NotDefined:
					commonBehaviorElementData.Accumulate = Enum284.const_0;
					break;
				case NullableBool.False:
					commonBehaviorElementData.Accumulate = Enum284.const_1;
					break;
				case NullableBool.True:
					commonBehaviorElementData.Accumulate = Enum284.const_2;
					break;
				}
				commonBehaviorElementData.Rctx = pPTXUnsupportedProps.RuntimeContext;
				if (!float.IsNaN(behavior.Timing.Duration))
				{
					commonBehaviorElementData.CTn.Dur = Class1008.smethod_6(behavior.Timing.Duration);
				}
				commonBehaviorElementData.CTn.Spd = behavior.Timing.Speed * 100f;
				commonBehaviorElementData.CTn.Accel = behavior.Timing.Accelerate * 100f;
				commonBehaviorElementData.CTn.Decel = behavior.Timing.Decelerate * 100f;
				commonBehaviorElementData.CTn.AutoRev = behavior.Timing.AutoReverse;
				if (behavior.Timing.RepeatCount != 1f)
				{
					commonBehaviorElementData.CTn.RepeatCount = Class1008.smethod_6(behavior.Timing.RepeatCount);
				}
				commonBehaviorElementData.Additive = (Enum285)behavior.Additive;
				Class2294 class7 = (Class2294)commonBehaviorElementData.TgtEl.delegate2773_0("spTgt").Object;
				class7.Spid = Class1008.smethod_10(effect.PPTXUnsupportedProps.ShapeTarget);
				if (effect.PPTXUnsupportedProps.BAnimBg && class7.TargetShape == null)
				{
					class7.delegate2773_0("bg");
				}
				if (effect.PPTXUnsupportedProps.ShapeTargetElement != null && effect.PPTXUnsupportedProps.ShapeTargetElement.TargetShape != null && effect.PPTXUnsupportedProps.ShapeTargetElement.TargetShape.Object is Class1797 obj)
				{
					class7.TargetShape = new Class2605("graphicEl", obj);
				}
				commonBehaviorElementData.CTn.Fill = (Enum289)pPTXUnsupportedProps.FillType;
				commonBehaviorElementData.Override = pPTXUnsupportedProps.Override;
				commonBehaviorElementData.CTn.TmFilter = pPTXUnsupportedProps.TimeFilter;
				commonBehaviorElementData.CTn.Id = ++sequence.PPTXUnsupportedProps.NNodeCounter;
				float num = (float.IsNaN(behavior.Timing.TriggerDelayTime) ? 0f : behavior.Timing.TriggerDelayTime);
				if (num + behavior.Timing.Duration > sequence.PPTXUnsupportedProps.FDelayEffect)
				{
					sequence.PPTXUnsupportedProps.FDelayEffect = num + behavior.Timing.Duration;
				}
				if (!float.IsNaN(behavior.Timing.TriggerDelayTime))
				{
					Class2301 class8 = smethod_21(commonBehaviorElementData.CTn.delegate2653_0);
					class8.Delay = Class1008.smethod_6(behavior.Timing.TriggerDelayTime);
				}
				continue;
			}
			throw new PptxException("fail.");
		}
		class3.CTn.delegate2541_1(effect.PPTXUnsupportedProps.ListSubTn);
		if (class3.CTn.SubTnLst != null)
		{
			Class2605[] nodeList = class3.CTn.SubTnLst.NodeList;
			foreach (Class2605 class9 in nodeList)
			{
				if (!(class9.Object is Class2288 class10) || class10.CMediaNode.CTn.StCondLst == null)
				{
					continue;
				}
				Class2301[] condList = class10.CMediaNode.CTn.StCondLst.CondList;
				foreach (Class2301 class11 in condList)
				{
					if (class11.Evt == Enum277.const_3)
					{
						Class2308 class12 = class11.Trigger.Object as Class2308;
						class12.Val = class3.CTn.Id;
						break;
					}
				}
				if (class10.CMediaNode.TgtEl != null && class10.CMediaNode.TgtEl.Target.Object is Class1838 class13)
				{
					Class1342 class14 = timelineSerializationContext.method_2(effect.PPTXUnsupportedProps.EmbeddedSound);
					if (class14 != null)
					{
						class13.R_Embed = timelineSerializationContext.method_1(timelineSerializationContext.method_2(effect.PPTXUnsupportedProps.EmbeddedSound)).Id;
					}
				}
			}
		}
		float num2 = (float.IsNaN(effect.Timing.TriggerDelayTime) ? 0f : effect.Timing.TriggerDelayTime);
		if (effect.Timing.TriggerType == EffectTriggerType.WithPrevious)
		{
			float num3 = sequence.PPTXUnsupportedProps.FDelayEffect + num2;
			if (num3 > sequence.PPTXUnsupportedProps.FDelayEffectLast)
			{
				sequence.PPTXUnsupportedProps.FDelaySum -= sequence.PPTXUnsupportedProps.FDelayEffectLast;
				sequence.PPTXUnsupportedProps.FDelaySum += num3;
				sequence.PPTXUnsupportedProps.FDelayEffect = num3;
			}
		}
		else
		{
			sequence.PPTXUnsupportedProps.FDelayEffectLast = sequence.PPTXUnsupportedProps.FDelayEffect + num2;
			sequence.PPTXUnsupportedProps.FDelayEffect += sequence.PPTXUnsupportedProps.FDelayEffectLast;
		}
	}

	private static Class2304 smethod_15(Effect effect, Sequence sequence, Class2605.Delegate2773 addNodeDelegate)
	{
		Class2304 @class = (Class2304)addNodeDelegate("par").Object;
		sequence.PPTXUnsupportedProps.ParLastEffect = @class;
		@class.CTn.Id = ++sequence.PPTXUnsupportedProps.NNodeCounter;
		@class.CTn.Fill = Enum289.const_3;
		Class2302 class2 = @class.CTn.delegate2653_0();
		Class2301 class3 = class2.delegate2650_0();
		if (effect.PPTXUnsupportedProps.RootParRef != null && effect.PPTXUnsupportedProps.RootParRef.CTn.StCondLst != null && effect.PPTXUnsupportedProps.RootParRef.CTn.StCondLst.CondList != null && effect.PPTXUnsupportedProps.RootParRef.CTn.StCondLst.CondList.Length > 0)
		{
			class3.Delay = effect.PPTXUnsupportedProps.RootParRef.CTn.StCondLst.CondList[0].Delay;
		}
		else
		{
			class3.Delay = Class1008.smethod_6(sequence.PPTXUnsupportedProps.FDelaySum);
		}
		return @class;
	}

	private static Class2305 smethod_16(Class2605.Delegate2773 addNodeDelegate, int nodeId)
	{
		Class2305 @class = (Class2305)addNodeDelegate("seq").Object;
		@class.CTn.Id = nodeId;
		@class.Concurrent = NullableBool.True;
		@class.NextAc = Enum294.const_2;
		@class.CTn.Dur = Class1008.smethod_6(float.PositiveInfinity);
		@class.CTn.NodeType = Enum303.const_4;
		Class2302 conditions = @class.delegate2653_0();
		smethod_18(conditions, Enum277.const_10);
		Class2302 conditions2 = @class.delegate2653_1();
		smethod_18(conditions2, Enum277.const_9);
		return @class;
	}

	private static Class2305 smethod_17(Sequence sequence, Class2605.Delegate2773 addNodeDelegate, int nodeId)
	{
		Class2305 @class = (Class2305)addNodeDelegate("seq").Object;
		@class.CTn.Id = nodeId;
		@class.Concurrent = NullableBool.True;
		@class.NextAc = Enum294.const_2;
		@class.CTn.NodeType = Enum303.const_5;
		@class.CTn.Restart = Enum298.const_2;
		@class.CTn.Fill = Enum289.const_3;
		@class.CTn.EvtFilter = "cancelBubble";
		Class2302 conditions = @class.CTn.delegate2653_0();
		smethod_19(conditions, Class1008.smethod_10(sequence.TriggerShape));
		Class2302 conditions2 = @class.delegate2653_1();
		smethod_19(conditions2, Class1008.smethod_10(sequence.TriggerShape));
		Class2301 class2 = @class.CTn.delegate2650_0();
		class2.Evt = Enum277.const_4;
		class2.Delay = Class1008.smethod_6(0f);
		Class2307 class3 = (Class2307)class2.delegate2773_0("rtn").Object;
		class3.Val = Enum182.const_3;
		return @class;
	}

	private static void smethod_18(Class2302 conditions, Enum277 triggerEvent)
	{
		Class2301 @class = conditions.delegate2650_0();
		@class.Evt = triggerEvent;
		@class.Delay = Class1008.smethod_6(0f);
		Class2306 class2 = (Class2306)@class.delegate2773_0("tgtEl").Object;
		class2.delegate2773_0("sldTgt");
	}

	private static void smethod_19(Class2302 conditions, string shapeId)
	{
		Class2301 @class = conditions.delegate2650_0();
		@class.Evt = Enum277.const_5;
		@class.Delay = Class1008.smethod_6(0f);
		Class2306 class2 = (Class2306)@class.delegate2773_0("tgtEl").Object;
		Class2294 class3 = (Class2294)class2.delegate2773_0("spTgt").Object;
		class3.Spid = shapeId;
	}

	private static void smethod_20(Class2605.Delegate2773 addIntervalDelegate, float time)
	{
		if (time <= 0f)
		{
			Class2286 @class = (Class2286)addIntervalDelegate("tmPct").Object;
			@class.Val = 0f - time;
			return;
		}
		Class2287 class2 = (Class2287)addIntervalDelegate("tmAbs").Object;
		if (!float.IsNaN(time))
		{
			class2.Val = Class1008.smethod_6(time);
		}
	}

	private static Class2301 smethod_21(Class2302.Delegate2653 addConditionsDelegate)
	{
		Class2302 @class = addConditionsDelegate();
		return @class.delegate2650_0();
	}
}
