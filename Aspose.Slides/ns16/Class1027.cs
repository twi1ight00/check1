using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using ns18;
using ns19;
using ns24;
using ns44;
using ns53;
using ns55;
using ns56;
using ns57;

namespace ns16;

internal class Class1027
{
	private Class1341 class1341_0;

	private Class1342 class1342_0;

	public void method_0(Presentation presentation, Stream stream)
	{
		Class1184 @class = new Class1184(stream);
		class1341_0 = new Class1341(presentation);
		Class350 pPTXUnsupportedProps = presentation.PPTXUnsupportedProps;
		class1342_0 = @class.Presentation;
		pPTXUnsupportedProps.PresentationType = Class889.smethod_0(class1342_0.ContentType.ContentType, Enum165.const_0);
		method_1(@class, presentation.LoadOptions);
		method_2(@class, presentation);
		method_3(presentation);
		method_4(@class, presentation);
		method_5(@class, presentation);
		method_6(@class, presentation);
		method_7(@class, presentation);
		method_8(@class, presentation);
		smethod_0(@class, class1341_0);
		method_9(@class, presentation);
		method_10(@class, presentation);
		method_11(@class, presentation);
		method_12(@class, presentation);
		smethod_1(@class, presentation, class1341_0);
		smethod_3(@class, presentation, class1341_0);
	}

	private void method_1(Class1184 package, ILoadOptions loadOptions)
	{
		if (package.RootRelationships.method_0(Class1336.class1338_0).Length > 0)
		{
			((LoadOptions)loadOptions).method_0();
			package.RootRelationships.method_3(Class1336.class1338_0);
		}
	}

	private void method_2(Class1184 package, IPresentation presentation)
	{
		if (presentation.ProtectionManager.EncryptDocumentProperties)
		{
			if (package.CoreProperties != null)
			{
				Class1213 @class = new Class1213(package.CoreProperties, class1341_0);
				@class.method_5(presentation.DocumentProperties);
			}
			if (package.ExtendedProperties != null)
			{
				Class1215 class2 = new Class1215(package.ExtendedProperties, class1341_0);
				class2.method_5(presentation.DocumentProperties);
			}
		}
		if (package.CustomProperties != null)
		{
			Class1214 class3 = new Class1214(package.CustomProperties, class1341_0);
			class3.method_5(presentation.DocumentProperties);
		}
	}

	private void method_3(IPresentation presentation)
	{
		Class1342[] array = class1342_0.method_2(new Class1241());
		if (array.Length > 0)
		{
			Class1198 @class = new Class1198(array[0], class1341_0);
			@class.method_5(presentation);
		}
	}

	private void method_4(Class1184 package, IPresentation presentation)
	{
		Class1342[] relationshipParts = package.RelationshipParts;
		foreach (Class1342 @class in relationshipParts)
		{
			Class1342[] array = @class.method_1(Class1305.class1338_0);
			Class1342[] array2 = array;
			foreach (Class1342 imagePart in array2)
			{
				class1341_0.method_1(imagePart);
			}
		}
	}

	private void method_5(Class1184 package, IPresentation presentation)
	{
		Class1342[] parts = package.Parts;
		foreach (Class1342 @class in parts)
		{
			if (@class.ContentType.ContentType.StartsWith("audio/"))
			{
				class1341_0.method_2(@class);
			}
		}
	}

	private void method_6(Class1184 package, IPresentation presentation)
	{
		Class1342[] parts = package.Parts;
		foreach (Class1342 @class in parts)
		{
			if (@class.ContentType.ContentType.StartsWith("video/"))
			{
				class1341_0.method_3(@class);
			}
		}
	}

	private void method_7(Class1184 package, IPresentation presentation)
	{
		if (package.TableStyles != null)
		{
			Class1206 @class = new Class1206(package.TableStyles, class1341_0);
			@class.method_5(((Presentation)presentation).PPTXUnsupportedProps.TableStyles);
		}
	}

	private void method_8(Class1184 package, IPresentation presentation)
	{
		Class1209 @class = new Class1209(package.Theme, class1341_0);
		@class.method_5(presentation);
	}

	internal static void smethod_0(Class1184 package, Class1341 deserializationContext)
	{
		Class1342[] layouts = package.Layouts;
		foreach (Class1342 @class in layouts)
		{
			Class1347[] array = @class.Relationships.method_0(Class1248.class1338_0);
			if (array != null && array.Length > 0)
			{
				SortedList<string, SortedList<string, Class1342>> masterSlidePartPathToBackLinksFromLayouts = deserializationContext.MasterSlidePartPathToBackLinksFromLayouts;
				if (!masterSlidePartPathToBackLinksFromLayouts.ContainsKey(array[0].Target))
				{
					deserializationContext.MasterSlidePartPathToBackLinksFromLayouts.Add(array[0].Target, new SortedList<string, Class1342>());
				}
				masterSlidePartPathToBackLinksFromLayouts[array[0].Target].Add(@class.PartPath, @class);
			}
		}
	}

	private void method_9(Class1184 package, IPresentation presentation)
	{
		Class1200 @class = new Class1200(package.Presentation, class1341_0);
		@class.method_5(presentation);
	}

	private void method_10(Class1184 package, IPresentation presentation)
	{
		if (package.VbaProject != null)
		{
			Class246 @class = new Class246();
			@class.method_0(package.VbaProject.Data, presentation);
			package.VbaProject.Processed = true;
		}
	}

	private void method_11(Class1184 package, IPresentation presentation)
	{
		if (package.PresProps != null)
		{
			((Presentation)presentation).PPTXUnsupportedProps.PresPropsPart = package.PresProps.Data;
			package.PresProps.Processed = true;
		}
	}

	private void method_12(Class1184 package, IPresentation presentation)
	{
		if (package.ViewProps == null)
		{
			return;
		}
		Class1211 @class = new Class1211(package.ViewProps, class1341_0);
		@class.method_5(presentation);
		Class367 viewProps = ((Presentation)presentation).PPTXUnsupportedProps.ViewProps;
		if (viewProps != null && viewProps.ViewPropertiesElementData != null)
		{
			Enum361 lastView = viewProps.ViewPropertiesElementData.LastView;
			switch (lastView)
			{
			default:
				throw new PptxReadException("Unknown view type: " + lastView);
			case Enum361.const_0:
				presentation.ViewProperties.LastView = ViewType.NotDefined;
				break;
			case Enum361.const_1:
				presentation.ViewProperties.LastView = ViewType.SlideView;
				break;
			case Enum361.const_2:
				presentation.ViewProperties.LastView = ViewType.SlideMasterView;
				break;
			case Enum361.const_3:
				presentation.ViewProperties.LastView = ViewType.NotesView;
				break;
			case Enum361.const_4:
				presentation.ViewProperties.LastView = ViewType.HandoutView;
				break;
			case Enum361.const_5:
				presentation.ViewProperties.LastView = ViewType.NotesMasterView;
				break;
			case Enum361.const_6:
				presentation.ViewProperties.LastView = ViewType.OutlineView;
				break;
			case Enum361.const_7:
				presentation.ViewProperties.LastView = ViewType.SlideSorterView;
				break;
			case Enum361.const_8:
				presentation.ViewProperties.LastView = ViewType.SlideThumbnailView;
				break;
			}
			presentation.ViewProperties.ShowComments = (viewProps.ViewPropertiesElementData.ShowComments ? NullableBool.True : NullableBool.False);
		}
	}

	internal static void smethod_1(Class1184 package, IPresentation presentation, Class1341 deserializationContext)
	{
		Class350 pPTXUnsupportedProps = ((Presentation)presentation).PPTXUnsupportedProps;
		Class1342[] parts = package.Parts;
		foreach (Class1342 @class in parts)
		{
			if (!@class.Processed && !(@class.ContentType is Class1296))
			{
				pPTXUnsupportedProps.UnknownParts.Add(@class.PartPath, @class.Data, @class.ContentType.ContentType, (@class.ContentType.TypeAttributeOfSourceRelationship != null) ? @class.ContentType.TypeAttributeOfSourceRelationship.Type : "", @class.Relationships);
				@class.Processed = true;
			}
		}
		switch (deserializationContext.Mode)
		{
		default:
			throw new ArgumentOutOfRangeException();
		case Enum168.const_0:
		{
			Class1347[] array = package.Presentation.Relationships.method_2();
			foreach (Class1347 relationship in array)
			{
				smethod_2(pPTXUnsupportedProps, pPTXUnsupportedProps.RelsToUnknownParts, relationship);
			}
			break;
		}
		case Enum168.const_1:
		case Enum168.const_2:
		case Enum168.const_3:
			break;
		}
		List<Class1342> list = new List<Class1342>();
		Class1342[] handoutMasters = package.HandoutMasters;
		foreach (Class1342 item in handoutMasters)
		{
			list.Add(item);
		}
		Class1342[] layouts = package.Layouts;
		foreach (Class1342 item2 in layouts)
		{
			list.Add(item2);
		}
		Class1342[] masters = package.Masters;
		foreach (Class1342 item3 in masters)
		{
			list.Add(item3);
		}
		Class1342[] notes = package.Notes;
		foreach (Class1342 item4 in notes)
		{
			list.Add(item4);
		}
		Class1342[] notesMasters = package.NotesMasters;
		foreach (Class1342 item5 in notesMasters)
		{
			list.Add(item5);
		}
		Class1342[] slides = package.Slides;
		foreach (Class1342 item6 in slides)
		{
			list.Add(item6);
		}
		foreach (Class1342 item7 in list)
		{
			if (deserializationContext.SlidePartPathToSlide.ContainsKey(item7.PartPath))
			{
				IBaseSlide baseSlide = deserializationContext.SlidePartPathToSlide[item7.PartPath];
				Class296 baseSlidePPTXUnsupportedProps = ((BaseSlide)baseSlide).BaseSlidePPTXUnsupportedProps;
				Class1347[] array2 = item7.Relationships.method_2();
				foreach (Class1347 relationship2 in array2)
				{
					smethod_2(pPTXUnsupportedProps, baseSlidePPTXUnsupportedProps.RelsToUnknownParts, relationship2);
				}
			}
		}
	}

	private static void smethod_2(Class350 presentationUnsupported, List<object[]> relsToUnknownParts, Class1347 relationship)
	{
		Class248 @class = presentationUnsupported.UnknownParts[relationship.Target];
		if (@class != null)
		{
			if (string.IsNullOrEmpty(@class.TypeAttributeOfSourceRelationship))
			{
				@class.TypeAttributeOfSourceRelationship = relationship.Type;
			}
			relsToUnknownParts.Add(new object[4] { relationship.Id, relationship.Type, relationship.Target, relationship.TargetMode });
		}
		else
		{
			relsToUnknownParts.Add(new object[4] { relationship.Id, relationship.Type, relationship.Target, relationship.TargetMode });
		}
	}

	internal static void smethod_3(Class1184 package, IPresentation presentation, Class1341 deserializationContext)
	{
		foreach (IShape shape in deserializationContext.Shapes)
		{
			if (shape is IAudioFrame)
			{
				smethod_7((IAudioFrame)shape);
			}
			else if (shape is IVideoFrame)
			{
				smethod_4((IVideoFrame)shape);
			}
			else if (shape is IAutoShape)
			{
				((AutoShape)shape).method_26();
			}
		}
		foreach (KeyValuePair<string, List<IHyperlink>> slidePartPathToUnresolvedHyperink in deserializationContext.SlidePartPathToUnresolvedHyperinks)
		{
			string key = slidePartPathToUnresolvedHyperink.Key;
			ISlide targetSlide;
			List<IHyperlink> value;
			switch (deserializationContext.Mode)
			{
			case Enum168.const_1:
			case Enum168.const_2:
				targetSlide = Class964.smethod_5(key, deserializationContext);
				goto IL_00ce;
			case Enum168.const_0:
			case Enum168.const_3:
				targetSlide = (ISlide)deserializationContext.SlidePartPathToSlide[key];
				goto IL_00ce;
			default:
				{
					throw new ArgumentOutOfRangeException();
				}
				IL_00ce:
				value = slidePartPathToUnresolvedHyperink.Value;
				foreach (IHyperlink item in value)
				{
					((Hyperlink)item).PPTXUnsupportedProps.TargetSlide = targetSlide;
				}
				break;
			}
		}
	}

	private static void smethod_4(IVideoFrame videoFrame)
	{
		Class284 pPTXUnsupportedProps = ((VideoFrame)videoFrame).PPTXUnsupportedProps;
		Class2259 timingElementData = ((BaseSlide)videoFrame.Slide).BaseSlidePPTXUnsupportedProps.TimingElementData;
		Class2289 @class = null;
		Class2605[] array = smethod_8(timingElementData.TnLst, videoFrame);
		pPTXUnsupportedProps.PlayModeInternal = VideoPlayModePreset.Mixed;
		Class2605[] array2 = array;
		foreach (Class2605 class2 in array2)
		{
			if (class2.Object is Class2289)
			{
				@class = (Class2289)class2.Object;
				videoFrame.HideAtShowing = !@class.CMediaNode.ShowWhenStopped;
				videoFrame.PlayLoopMode = Class1008.smethod_7(@class.CMediaNode.CTn.RepeatCount) == float.PositiveInfinity;
				videoFrame.FullScreenMode = @class.FullScrn;
				videoFrame.RewindVideo = @class.CMediaNode.CTn.Fill == Enum289.const_1;
				if (@class.CMediaNode.Mute)
				{
					videoFrame.Volume = AudioVolumeMode.Mute;
				}
				else
				{
					videoFrame.Volume = smethod_6(@class.CMediaNode.Vol);
				}
			}
			List<IEffect> list = new List<IEffect>();
			foreach (ISequence interactiveSequence in videoFrame.Slide.Timeline.InteractiveSequences)
			{
				IEffect[] effectsByShape = interactiveSequence.GetEffectsByShape(videoFrame);
				IEffect[] array3 = effectsByShape;
				foreach (IEffect item in array3)
				{
					list.Add(item);
				}
			}
			IEffect[] effectsByShape2 = videoFrame.Slide.Timeline.MainSequence.GetEffectsByShape(videoFrame);
			if (effectsByShape2.Length == 1 && list.Count == 1)
			{
				if (@class != null)
				{
					pPTXUnsupportedProps.PlayModeInternal = ((@class.CMediaNode.NumSld == 999) ? VideoPlayModePreset.AllSlides : VideoPlayModePreset.Auto);
				}
				else
				{
					pPTXUnsupportedProps.PlayModeInternal = VideoPlayModePreset.Auto;
				}
			}
			else if (list.Count == 1)
			{
				pPTXUnsupportedProps.PlayModeInternal = VideoPlayModePreset.OnClick;
			}
			if (@class == null)
			{
				videoFrame.Volume = AudioVolumeMode.Mixed;
			}
		}
	}

	internal static float smethod_5(AudioVolumeMode mode)
	{
		return mode switch
		{
			AudioVolumeMode.Loud => 0.8f, 
			AudioVolumeMode.Medium => 0.5f, 
			AudioVolumeMode.Low => 0.2f, 
			_ => 0f, 
		};
	}

	internal static AudioVolumeMode smethod_6(float value)
	{
		if ((double)value >= 0.8)
		{
			return AudioVolumeMode.Loud;
		}
		if ((double)value >= 0.5)
		{
			return AudioVolumeMode.Medium;
		}
		if ((double)value >= 0.2)
		{
			return AudioVolumeMode.Low;
		}
		return AudioVolumeMode.Mute;
	}

	private static void smethod_7(IAudioFrame audioFrame)
	{
		Class296 baseSlidePPTXUnsupportedProps = ((BaseSlide)audioFrame.Slide).BaseSlidePPTXUnsupportedProps;
		if (baseSlidePPTXUnsupportedProps.TimingElementData == null)
		{
			baseSlidePPTXUnsupportedProps.TimingElementData = new Class2259();
		}
		Class2259 timingElementData = baseSlidePPTXUnsupportedProps.TimingElementData;
		Class2605[] array = smethod_8(timingElementData.TnLst, audioFrame);
		Class2288 @class = null;
		Class2605[] array2 = array;
		foreach (Class2605 class2 in array2)
		{
			if (class2.Object is Class2288)
			{
				@class = (Class2288)class2.Object;
				audioFrame.HideAtShowing = !@class.CMediaNode.ShowWhenStopped;
				audioFrame.PlayLoopMode = Class1008.smethod_7(@class.CMediaNode.CTn.RepeatCount) == float.PositiveInfinity;
				if (@class.CMediaNode.Mute)
				{
					audioFrame.Volume = AudioVolumeMode.Mute;
				}
				else if ((double)@class.CMediaNode.Vol >= 0.8)
				{
					audioFrame.Volume = AudioVolumeMode.Loud;
				}
				else if ((double)@class.CMediaNode.Vol >= 0.5)
				{
					audioFrame.Volume = AudioVolumeMode.Medium;
				}
				else if ((double)@class.CMediaNode.Vol >= 0.2)
				{
					audioFrame.Volume = AudioVolumeMode.Low;
				}
			}
		}
		List<IEffect> list = new List<IEffect>();
		foreach (ISequence interactiveSequence in audioFrame.Slide.Timeline.InteractiveSequences)
		{
			IEffect[] effectsByShape = interactiveSequence.GetEffectsByShape(audioFrame);
			IEffect[] array3 = effectsByShape;
			foreach (IEffect item in array3)
			{
				list.Add(item);
			}
		}
		IEffect[] effectsByShape2 = audioFrame.Slide.Timeline.MainSequence.GetEffectsByShape(audioFrame);
		audioFrame.PlayMode = AudioPlayModePreset.Mixed;
		if (effectsByShape2.Length == 1 && list.Count == 0)
		{
			if (@class != null)
			{
				audioFrame.PlayMode = ((@class.CMediaNode.NumSld == 999) ? AudioPlayModePreset.AllSlides : AudioPlayModePreset.Auto);
			}
			else
			{
				audioFrame.PlayMode = AudioPlayModePreset.Auto;
			}
		}
		if (list.Count == 1)
		{
			audioFrame.PlayMode = AudioPlayModePreset.OnClick;
		}
		if (@class == null)
		{
			audioFrame.Volume = AudioVolumeMode.Mixed;
		}
	}

	private static Class2605[] smethod_8(Class2264 nodes, IShape shape)
	{
		List<Class2605> list = new List<Class2605>();
		smethod_9(list, nodes, shape);
		return list.ToArray();
	}

	private static void smethod_9(List<Class2605> found, Class2264 nodes, IShape shape)
	{
		if (nodes == null)
		{
			return;
		}
		for (int i = 0; i < nodes.NodeList.Length; i++)
		{
			Class2605 @class = nodes.NodeList[i];
			if (@class.Object is Class2306)
			{
				Class2306 class2 = (Class2306)@class.Object;
				smethod_10(found, class2.Target, @class, shape);
			}
			else if (@class.Object is Class2288)
			{
				Class2288 class3 = (Class2288)@class.Object;
				smethod_10(found, class3.CMediaNode.TgtEl.Target, @class, shape);
			}
			else if (@class.Object is Class2289)
			{
				Class2289 class4 = (Class2289)@class.Object;
				smethod_10(found, class4.CMediaNode.TgtEl.Target, @class, shape);
			}
			if (!Class1008.smethod_11(@class.Name))
			{
				continue;
			}
			Class2283 class5 = Class1008.smethod_1(@class);
			if (class5 != null)
			{
				if (class5.ChildTnLst != null)
				{
					smethod_9(found, class5.ChildTnLst, shape);
				}
				if (class5.SubTnLst != null)
				{
					smethod_9(found, class5.SubTnLst, shape);
				}
			}
		}
	}

	private static void smethod_10(List<Class2605> found, Class2605 target, Class2605 root, IShape shape)
	{
		if (target != null && !(target.Name != "spTgt") && shape is Shape shape2)
		{
			Class2294 @class = (Class2294)target.Object;
			if (@class.Spid == shape2.ShapeId.ToString())
			{
				found.Add(root);
			}
		}
	}
}
