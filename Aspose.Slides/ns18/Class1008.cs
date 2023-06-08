using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Animation;
using ns16;
using ns27;
using ns56;
using ns57;

namespace ns18;

internal class Class1008
{
	[CompilerGenerated]
	private sealed class Class1009
	{
		public IVideoFrame ivideoFrame_0;

		public bool method_0(Class2605 vo)
		{
			if (!(vo.Object is Class2289 @class))
			{
				return false;
			}
			if (!(@class.CMediaNode.TgtEl.Target.Object is Class2294 class2))
			{
				return false;
			}
			return XmlConvert.ToUInt32(class2.Spid) == ivideoFrame_0.UniqueId;
		}
	}

	private static readonly List<string> list_0;

	public static void smethod_0(IAnimationTimeLine animationTimeLine, Class2259 timingElementData, Class233 timelineDeserializationContext)
	{
		if (timingElementData == null || timingElementData.TnLst == null || timingElementData.TnLst.NodeList.Length == 0)
		{
			return;
		}
		Class2283 @class = smethod_1(timingElementData.TnLst.NodeList[0]);
		if (@class.NodeType != Enum303.const_9)
		{
			throw new PptxReadException("TimeLine.Load, error reading slide.");
		}
		if (@class.ChildTnLst == null || @class.ChildTnLst.NodeList.Length == 0)
		{
			return;
		}
		Class2605[] nodeList = @class.ChildTnLst.NodeList;
		foreach (Class2605 class2 in nodeList)
		{
			Class2283 class3 = smethod_1(class2);
			if (class3.NodeType == Enum303.const_4)
			{
				Class1019.smethod_0((Sequence)animationTimeLine.MainSequence, class2.Object as Class2305, timelineDeserializationContext);
			}
			else if (class3.NodeType == Enum303.const_5)
			{
				Sequence sequence = (Sequence)animationTimeLine.InteractiveSequences.Add(null);
				Class1019.smethod_0(sequence, class2.Object as Class2305, timelineDeserializationContext);
			}
			else if (class2.Name == "video")
			{
				Class364 pPTXUnsupportedProps = ((Sequence)animationTimeLine.MainSequence).PPTXUnsupportedProps;
				pPTXUnsupportedProps.VideoObjects.Add(class2);
			}
		}
		try
		{
			List<ISequence> list = new List<ISequence>();
			list.Add(animationTimeLine.MainSequence);
			foreach (ISequence interactiveSequence in animationTimeLine.InteractiveSequences)
			{
				list.Add(interactiveSequence);
			}
			foreach (Sequence item in list)
			{
				foreach (Effect effect3 in item.PPTXUnsupportedProps.Effects)
				{
					if (effect3.PPTXUnsupportedProps.GrId < 0)
					{
						TextAnimation textAnimation = new TextAnimation();
						textAnimation.bool_0 = true;
						textAnimation.SeqOwner = item;
						textAnimation.PPTXUnsupportedProps.ListEffects.Add(effect3);
						if (effect3.PPTXUnsupportedProps.BAnimBg)
						{
							textAnimation.PPTXUnsupportedProps.EffectAnimBg = effect3;
						}
						textAnimation.PPTXUnsupportedProps.ShapeRef = effect3.PPTXUnsupportedProps.ShapeTarget;
						textAnimation.method_0();
						((AnimationTimeLine)animationTimeLine).textAnimationCollection_0.Add(textAnimation);
					}
				}
			}
			if (timingElementData.BldLst == null)
			{
				return;
			}
			Class2605[] buildList = timingElementData.BldLst.BuildList;
			foreach (Class2605 class4 in buildList)
			{
				switch (class4.Name)
				{
				case "bldP":
				{
					Class2278 class5 = (Class2278)class4.Object;
					int num = XmlConvert.ToInt32(class5.Spid);
					IShape shape = null;
					if (timelineDeserializationContext.ShapeXmlIdToShape.ContainsKey(num.ToString()))
					{
						shape = (IShape)timelineDeserializationContext.ShapeXmlIdToShape[num.ToString()];
					}
					uint grpId = class5.GrpId;
					TextAnimation textAnimation2 = ((TextAnimationCollection)animationTimeLine.TextAnimationCollection).Add();
					foreach (Sequence item2 in list)
					{
						IEffect[] effectsByShape = item2.GetEffectsByShape(shape);
						if (effectsByShape.Length > 0)
						{
							textAnimation2.SeqOwner = item2;
						}
					}
					if (textAnimation2.SeqOwner != null)
					{
						IEffect[] effectsByShape2 = textAnimation2.SeqOwner.GetEffectsByShape(shape);
						IEffect[] array = effectsByShape2;
						for (int k = 0; k < array.Length; k++)
						{
							Effect effect2 = (Effect)array[k];
							if (effect2.PPTXUnsupportedProps.GrId == grpId)
							{
								textAnimation2.PPTXUnsupportedProps.ListEffects.Add(effect2);
								if (effect2.PPTXUnsupportedProps.BAnimBg)
								{
									textAnimation2.PPTXUnsupportedProps.EffectAnimBg = effect2;
								}
							}
						}
						textAnimation2.PPTXUnsupportedProps.ShapeRef = ((Effect)effectsByShape2[0]).PPTXUnsupportedProps.ShapeTarget;
					}
					string text = ((class5.AdvAuto != null) ? class5.AdvAuto : "indefinite");
					textAnimation2.PPTXUnsupportedProps.AdvAuto = ((text == "indefinite") ? int.MinValue : int.Parse(text));
					textAnimation2.PPTXUnsupportedProps.BRev = class5.Rev;
					textAnimation2.method_0();
					switch (class5.Build)
					{
					case Enum359.const_1:
						textAnimation2.BuildType = BuildType.AllParagraphsAtOnce;
						break;
					case Enum359.const_2:
						switch (class5.BldLvl)
						{
						case 1u:
							textAnimation2.BuildType = BuildType.ByLevelParagraphs1;
							break;
						case 2u:
							textAnimation2.BuildType = BuildType.ByLevelParagraphs2;
							break;
						case 3u:
							textAnimation2.BuildType = BuildType.ByLevelParagraphs3;
							break;
						case 4u:
							textAnimation2.BuildType = BuildType.ByLevelParagraphs4;
							break;
						case 5u:
							textAnimation2.BuildType = BuildType.ByLevelParagraphs5;
							break;
						}
						break;
					case Enum359.const_3:
					case Enum359.const_4:
						textAnimation2.BuildType = BuildType.AsOneObject;
						break;
					}
					break;
				}
				case "bldDgm":
				case "bldOleChart":
				case "bldGraphic":
					break;
				default:
					throw new Exception();
				}
			}
		}
		catch (Exception exception)
		{
			throw new PptxException("reading animation group failed.", exception);
		}
	}

	public static Class2283 smethod_1(Class2605 namedObject)
	{
		if (!smethod_11(namedObject.Name))
		{
			throw new ArgumentException($"namedObject {namedObject.Name} is not allowed");
		}
		if (namedObject.Name == "par")
		{
			Class2304 @class = namedObject.Object as Class2304;
			return @class.CTn;
		}
		if (namedObject.Name == "seq")
		{
			Class2305 class2 = namedObject.Object as Class2305;
			return class2.CTn;
		}
		if (namedObject.Name == "excl")
		{
			Class2303 class3 = namedObject.Object as Class2303;
			return class3.CTn;
		}
		if (namedObject.Name == "audio")
		{
			Class2288 class4 = namedObject.Object as Class2288;
			return class4.CMediaNode.CTn;
		}
		if (!(namedObject.Name == "video"))
		{
			throw new InvalidOperationException("CommonTimeNodeParent inconsistency");
		}
		Class2289 class5 = namedObject.Object as Class2289;
		return class5.CMediaNode.CTn;
	}

	public static void smethod_2(IAnimationTimeLine animationTimeLine, IShapeCollection shapes, Class2259 slideTimingElementData, Class234 timelineSerializationContext)
	{
		if (slideTimingElementData == null)
		{
			throw new InvalidOperationException();
		}
		int num = 0;
		if (animationTimeLine.InteractiveSequences.Count == 0 && animationTimeLine.MainSequence.Count == 0)
		{
			return;
		}
		Class2264 @class = slideTimingElementData.delegate2539_0();
		Class2304 class2 = (Class2304)@class.delegate2773_0("par").Object;
		class2.CTn.NodeType = Enum303.const_9;
		num = (class2.CTn.Id = num + 1);
		class2.CTn.Fill = Enum289.const_0;
		class2.CTn.Dur = smethod_6(float.PositiveInfinity);
		class2.CTn.Restart = Enum298.const_3;
		if (animationTimeLine.InteractiveSequences.Count == 0 && animationTimeLine.MainSequence.Count == 0)
		{
			return;
		}
		Class2264 class3 = class2.CTn.delegate2539_0();
		if (animationTimeLine.MainSequence.Count > 0)
		{
			Class1019.smethod_10((Sequence)animationTimeLine.MainSequence, ref num, class3, timelineSerializationContext);
		}
		foreach (Class2605 videoObject in ((Sequence)animationTimeLine.MainSequence).PPTXUnsupportedProps.VideoObjects)
		{
			smethod_3(videoObject, class3);
		}
		smethod_4(animationTimeLine, shapes, class3, timelineSerializationContext);
		foreach (ISequence interactiveSequence in animationTimeLine.InteractiveSequences)
		{
			Class1019.smethod_10((Sequence)interactiveSequence, ref num, class3, timelineSerializationContext);
		}
		Class2224 bldLst = slideTimingElementData.BldLst;
		slideTimingElementData.delegate2410_0(null);
		slideTimingElementData.delegate2408_0();
		if (bldLst != null)
		{
			Class2605[] buildList = bldLst.BuildList;
			foreach (Class2605 class4 in buildList)
			{
				if (class4.Name != "bldP")
				{
					slideTimingElementData.BldLst.method_4(class4);
				}
			}
		}
		int num3 = 0;
		foreach (TextAnimation item in animationTimeLine.TextAnimationCollection)
		{
			bool flag = false;
			foreach (Effect listEffect in item.PPTXUnsupportedProps.ListEffects)
			{
				if (!(flag = listEffect.PPTXUnsupportedProps.ParRef == null) && listEffect.StartParagraph != null && listEffect.EndParagraph != null)
				{
					flag = listEffect.StartParagraph.paragraphCollection_0 == null || listEffect.EndParagraph.paragraphCollection_0 == null;
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				continue;
			}
			foreach (Effect listEffect2 in item.PPTXUnsupportedProps.ListEffects)
			{
				if (!item.bool_0)
				{
					listEffect2.PPTXUnsupportedProps.ParRef.CTn.GrpId = (uint)num3;
					if (item.buildType_0 == BuildType.AsOneObject)
					{
						continue;
					}
				}
				if (listEffect2.PPTXUnsupportedProps.ParRef.CTn.ChildTnLst == null)
				{
					continue;
				}
				Class2605[] nodeList = listEffect2.PPTXUnsupportedProps.ParRef.CTn.ChildTnLst.NodeList;
				foreach (Class2605 behaviorElem in nodeList)
				{
					Class2281 class5 = smethod_9(behaviorElem);
					if (class5 != null && !listEffect2.PPTXUnsupportedProps.BAnimBg && class5.TgtEl.Target.Object is Class2294 class6)
					{
						if (listEffect2.StartParagraph != null && listEffect2.EndParagraph != null)
						{
							Class2298 class7 = (Class2298)class6.delegate2773_0("txEl").Object;
							Class2239 class8 = (Class2239)class7.delegate2773_0("pRg").Object;
							class8.St = (uint)listEffect2.StartParagraph.method_11();
							class8.End = (uint)listEffect2.EndParagraph.method_11();
						}
						else if (listEffect2.PPTXUnsupportedProps.CharRgRef != null && class6.TargetShape == null)
						{
							Class2298 class9 = (Class2298)class6.delegate2773_0("txEl").Object;
							Class2239 class10 = (Class2239)class9.delegate2773_0("charRg").Object;
							class10.St = listEffect2.PPTXUnsupportedProps.CharRgRef.St;
							class10.End = listEffect2.PPTXUnsupportedProps.CharRgRef.End;
						}
					}
				}
			}
			if (!item.bool_0)
			{
				if (slideTimingElementData.BldLst == null)
				{
					throw new PptxException("Internal error: animation build list is not initialized");
				}
				Class2278 class11 = (Class2278)slideTimingElementData.BldLst.delegate2773_0("bldP").Object;
				if (item.PPTXUnsupportedProps.ShapeRef != null)
				{
					class11.Spid = smethod_10(item.PPTXUnsupportedProps.ShapeRef);
				}
				class11.GrpId = (uint)num3;
				class11.UiExpand = item.PPTXUnsupportedProps.ListEffects.Count > 1;
				class11.AdvAuto = ((item.PPTXUnsupportedProps.AdvAuto == int.MinValue) ? "indefinite" : item.PPTXUnsupportedProps.AdvAuto.ToString());
				class11.Rev = item.PPTXUnsupportedProps.BRev;
				Enum359 build = Enum359.const_3;
				switch (item.BuildType)
				{
				case BuildType.AsOneObject:
					build = Enum359.const_4;
					break;
				case BuildType.AllParagraphsAtOnce:
					build = Enum359.const_1;
					break;
				case BuildType.ByLevelParagraphs1:
					build = Enum359.const_2;
					class11.BldLvl = 1u;
					break;
				case BuildType.ByLevelParagraphs2:
					build = Enum359.const_2;
					class11.BldLvl = 2u;
					break;
				case BuildType.ByLevelParagraphs3:
					build = Enum359.const_2;
					class11.BldLvl = 3u;
					break;
				case BuildType.ByLevelParagraphs4:
					build = Enum359.const_2;
					class11.BldLvl = 4u;
					break;
				case BuildType.ByLevelParagraphs5:
					build = Enum359.const_2;
					class11.BldLvl = 5u;
					break;
				}
				class11.Build = build;
				class11.AnimBg = item.PPTXUnsupportedProps.EffectAnimBg != null;
				num3++;
			}
		}
	}

	private static void smethod_3(Class2605 videoObject, Class2264 parChildsElementData)
	{
		Class2289 @class = videoObject.Object as Class2289;
		Class2289 class2 = (Class2289)parChildsElementData.delegate2773_0("video").Object;
		class2.CMediaNode.CTn.delegate2655_0(@class.CMediaNode.CTn.StCondLst);
		class2.CMediaNode.TgtEl.Target = @class.CMediaNode.TgtEl.Target;
	}

	private static void smethod_4(IAnimationTimeLine animationTimeLine, IShapeCollection shapes, Class2264 parChildsElementData, Class234 timelineSerializationContext)
	{
		if (shapes == null)
		{
			return;
		}
		List<Class2605> videoObjects = ((Sequence)animationTimeLine.MainSequence).PPTXUnsupportedProps.VideoObjects;
		foreach (IShape shape in shapes)
		{
			IVideoFrame ivideoFrame_0 = shape as IVideoFrame;
			if (ivideoFrame_0 != null && !videoObjects.Exists(delegate(Class2605 vo)
			{
				if (!(vo.Object is Class2289 @class))
				{
					return false;
				}
				return @class.CMediaNode.TgtEl.Target.Object is Class2294 class2 && XmlConvert.ToUInt32(class2.Spid) == ivideoFrame_0.UniqueId;
			}))
			{
				smethod_5(ivideoFrame_0, parChildsElementData, timelineSerializationContext);
			}
		}
	}

	internal static void smethod_5(IVideoFrame videoFrame, Class2264 parChildsElementData, Class234 timelineSerializationContext)
	{
		if (videoFrame == null)
		{
			throw new ArgumentNullException("videoFrame");
		}
		if (timelineSerializationContext.ShapeToShapeXmlId.ContainsKey(videoFrame))
		{
			Class2289 @class = (Class2289)parChildsElementData.delegate2773_0("video").Object;
			@class.CMediaNode.Vol = Class1027.smethod_5(videoFrame.Volume) * 100f;
			Class2294 class2 = @class.CMediaNode.TgtEl.delegate2773_0("spTgt").Object as Class2294;
			class2.Spid = XmlConvert.ToString(timelineSerializationContext.ShapeToShapeXmlId[videoFrame]);
		}
	}

	internal static string smethod_6(float value)
	{
		if (float.IsPositiveInfinity(value))
		{
			return "indefinite";
		}
		return XmlConvert.ToString((long)Math.Round(value * 1000f));
	}

	internal static float smethod_7(string val)
	{
		if (val == null)
		{
			return float.NaN;
		}
		if (val == "indefinite")
		{
			return float.PositiveInfinity;
		}
		return (float)XmlConvert.ToInt64(val) / 1000f;
	}

	internal static void smethod_8(Class2292.Delegate2623 addDelegate, PointF point)
	{
		Class2292 @class = addDelegate();
		@class.X = point.X;
		@class.Y = point.Y;
	}

	internal static Class2281 smethod_9(Class2605 behaviorElem)
	{
		Class2281 result = null;
		object @object = behaviorElem.Object;
		if (@object is Class2266)
		{
			result = ((Class2266)@object).CBhvr;
		}
		else if (@object is Class2280)
		{
			result = ((Class2280)@object).CBhvr;
		}
		else if (@object is Class2267)
		{
			result = ((Class2267)@object).CBhvr;
		}
		else if (@object is Class2268)
		{
			result = ((Class2268)@object).CBhvr;
		}
		else if (@object is Class2265)
		{
			result = ((Class2265)@object).CBhvr;
		}
		else if (@object is Class2269)
		{
			result = ((Class2269)@object).CBhvr;
		}
		else if (@object is Class2270)
		{
			result = ((Class2270)@object).CBhvr;
		}
		else if (@object is Class2293)
		{
			result = ((Class2293)@object).CBhvr;
		}
		return result;
	}

	internal static string smethod_10(IShape shape)
	{
		return XmlConvert.ToString(((Shape)shape).PPTXUnsupportedProps.ShapeId);
	}

	public static bool smethod_11(string name)
	{
		return list_0.Contains(name);
	}

	internal static void smethod_12(Class2605 node, ref uint id)
	{
		if (!smethod_11(node.Name))
		{
			return;
		}
		Class2283 @class = smethod_1(node);
		id = (uint)@class.Id;
		if (@class.ChildTnLst != null && @class.ChildTnLst.NodeList != null)
		{
			Class2605[] nodeList = @class.ChildTnLst.NodeList;
			foreach (Class2605 node2 in nodeList)
			{
				smethod_12(node2, ref id);
			}
		}
	}

	internal static uint smethod_13(Slide slide)
	{
		uint id = 0u;
		Class2259 timingElementData = slide.PPTXUnsupportedProps.TimingElementData;
		if (timingElementData != null && timingElementData.TnLst != null && timingElementData.TnLst.NodeList != null)
		{
			Class2605[] nodeList = timingElementData.TnLst.NodeList;
			foreach (Class2605 node in nodeList)
			{
				smethod_12(node, ref id);
			}
			return id;
		}
		return id;
	}

	static Class1008()
	{
		list_0 = new List<string>();
		list_0.Add("par");
		list_0.Add("seq");
		list_0.Add("excl");
		list_0.Add("audio");
		list_0.Add("video");
	}
}
