using System;
using Aspose.Slides;
using Aspose.Slides.SlideShow;
using ns63;

namespace ns15;

internal static class Class231
{
	private static readonly TransitionType[] transitionType_0;

	public static void smethod_0(BaseSlide domSlide, Class854 slidePptDeserializationContext)
	{
		Class857 deserializationContext = slidePptDeserializationContext.DeserializationContext;
		Class2893 slideShowSlideInfo = slidePptDeserializationContext.SlideShowSlideInfo;
		ISlideShowTransition slideShowTransition = domSlide.SlideShowTransition;
		if (slideShowSlideInfo != null)
		{
			if (domSlide is Slide)
			{
				((Slide)domSlide).Hidden = smethod_2(slideShowSlideInfo, 'C');
			}
			slideShowTransition.AdvanceAfterTime = (smethod_2(slideShowSlideInfo, 'K') ? ((uint)slideShowSlideInfo.SlideTime) : 0u);
			slideShowTransition.AdvanceOnClick = smethod_2(slideShowSlideInfo, 'A');
			if (slideShowSlideInfo.SoundIdRef != 0)
			{
				Class2733 soundContainer = deserializationContext.PowerPointDocumentStream.DocumentContainer.SoundCollection.method_5(slideShowSlideInfo.SoundIdRef);
				SlideShowTransition slideShowTransition2 = (SlideShowTransition)slideShowTransition;
				slideShowTransition2.PPTUnsupportedProps.SoundIdRef = (uint)slideShowSlideInfo.SoundIdRef;
				slideShowTransition.Sound = deserializationContext.method_0(soundContainer);
				slideShowTransition.SoundIsBuiltIn = false;
			}
			slideShowTransition.SoundLoop = smethod_2(slideShowSlideInfo, 'G');
			if (smethod_2(slideShowSlideInfo, 'I'))
			{
				slideShowTransition.SoundMode = TransitionSoundMode.StopPrevoiusSound;
			}
			else if (smethod_2(slideShowSlideInfo, 'E'))
			{
				slideShowTransition.SoundMode = TransitionSoundMode.StartSound;
			}
			else
			{
				slideShowTransition.SoundMode = TransitionSoundMode.NotDefined;
			}
			slideShowTransition.Type = ((slideShowSlideInfo.EffectType < transitionType_0.Length) ? transitionType_0[slideShowSlideInfo.EffectType] : TransitionType.None);
			smethod_4(slideShowTransition, slideShowSlideInfo);
			switch (slideShowSlideInfo.Speed)
			{
			case 0:
				slideShowTransition.Speed = TransitionSpeed.Slow;
				break;
			case 1:
				slideShowTransition.Speed = TransitionSpeed.Medium;
				break;
			case 2:
				slideShowTransition.Speed = TransitionSpeed.Fast;
				break;
			}
		}
	}

	public static void smethod_1(BaseSlide domSlide, Class2717 slideContainer, Class856 context)
	{
		ISlideShowTransition slideShowTransition = domSlide.SlideShowTransition;
		slideContainer.AutoInit = true;
		if (domSlide is Slide && ((Slide)domSlide).Hidden)
		{
			smethod_3(slideContainer.SlideShowSlideInfoAtom, 'C', value: true);
		}
		if (slideShowTransition.Type != 0 || slideShowTransition.Sound != null)
		{
			Class2893 slideShowSlideInfoAtom = slideContainer.SlideShowSlideInfoAtom;
			slideShowSlideInfoAtom.SlideTime = (int)slideShowTransition.AdvanceAfterTime;
			smethod_3(slideShowSlideInfoAtom, 'K', slideShowTransition.AdvanceAfterTime != 0);
			smethod_3(slideShowSlideInfoAtom, 'A', slideShowTransition.AdvanceOnClick);
			if (slideShowTransition.Sound != null)
			{
				slideShowSlideInfoAtom.SoundIdRef = Class209.smethod_0(slideShowTransition.Sound, context);
			}
			smethod_3(slideShowSlideInfoAtom, 'G', slideShowTransition.SoundLoop);
			switch (slideShowTransition.SoundMode)
			{
			case TransitionSoundMode.NotDefined:
				smethod_3(slideShowSlideInfoAtom, 'I', value: false);
				smethod_3(slideShowSlideInfoAtom, 'E', value: false);
				break;
			case TransitionSoundMode.StartSound:
				smethod_3(slideShowSlideInfoAtom, 'I', value: false);
				smethod_3(slideShowSlideInfoAtom, 'E', value: true);
				break;
			case TransitionSoundMode.StopPrevoiusSound:
				smethod_3(slideShowSlideInfoAtom, 'I', value: true);
				smethod_3(slideShowSlideInfoAtom, 'E', value: false);
				break;
			}
			slideShowSlideInfoAtom.EffectType = ((slideShowTransition.Type != 0) ? ((byte)Array.IndexOf(transitionType_0, slideShowTransition.Type)) : byte.MaxValue);
			smethod_5(slideShowTransition, slideShowSlideInfoAtom);
			switch (slideShowTransition.Speed)
			{
			case TransitionSpeed.Fast:
				slideShowSlideInfoAtom.Speed = 2;
				break;
			case TransitionSpeed.Medium:
				slideShowSlideInfoAtom.Speed = 1;
				break;
			case TransitionSpeed.Slow:
				slideShowSlideInfoAtom.Speed = 0;
				break;
			}
			slideShowSlideInfoAtom.method_1();
		}
	}

	static Class231()
	{
		transitionType_0 = new TransitionType[28];
		transitionType_0[0] = TransitionType.Cut;
		transitionType_0[1] = TransitionType.Random;
		transitionType_0[2] = TransitionType.Blinds;
		transitionType_0[3] = TransitionType.Checker;
		transitionType_0[4] = TransitionType.Cover;
		transitionType_0[5] = TransitionType.Dissolve;
		transitionType_0[6] = TransitionType.Fade;
		transitionType_0[7] = TransitionType.Pull;
		transitionType_0[8] = TransitionType.RandomBar;
		transitionType_0[9] = TransitionType.Strips;
		transitionType_0[10] = TransitionType.Wipe;
		transitionType_0[11] = TransitionType.Zoom;
		transitionType_0[13] = TransitionType.Split;
		transitionType_0[17] = TransitionType.Diamond;
		transitionType_0[18] = TransitionType.Plus;
		transitionType_0[19] = TransitionType.Wedge;
		transitionType_0[20] = TransitionType.Push;
		transitionType_0[21] = TransitionType.Comb;
		transitionType_0[22] = TransitionType.Newsflash;
		transitionType_0[23] = TransitionType.Fade;
		transitionType_0[26] = TransitionType.Wheel;
		transitionType_0[27] = TransitionType.Circle;
	}

	private static bool smethod_2(Class2893 atomRecord, char flag)
	{
		int num = flag - 65;
		return (atomRecord.BuildFlags & (1 << num)) != 0;
	}

	private static void smethod_3(Class2893 atomRecord, char flag, bool value)
	{
		int num = flag - 65;
		short num2 = (short)(1 << num);
		if (value)
		{
			atomRecord.BuildFlags |= num2;
		}
		else
		{
			atomRecord.BuildFlags &= (short)(~num2);
		}
	}

	private static void smethod_4(ISlideShowTransition transition, Class2893 atomRecord)
	{
		switch (transition.Type)
		{
		case TransitionType.Blinds:
		{
			OrientationTransition orientationTransition3 = transition.Value as OrientationTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				orientationTransition3.Direction = Orientation.Vertical;
				break;
			case 1:
				orientationTransition3.Direction = Orientation.Horizontal;
				break;
			}
			break;
		}
		case TransitionType.Checker:
		{
			OrientationTransition orientationTransition2 = transition.Value as OrientationTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				orientationTransition2.Direction = Orientation.Horizontal;
				break;
			case 1:
				orientationTransition2.Direction = Orientation.Vertical;
				break;
			}
			break;
		}
		case TransitionType.Comb:
		{
			OrientationTransition orientationTransition = transition.Value as OrientationTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				orientationTransition.Direction = Orientation.Horizontal;
				break;
			case 1:
				orientationTransition.Direction = Orientation.Vertical;
				break;
			}
			break;
		}
		case TransitionType.Cover:
		{
			EightDirectionTransition eightDirectionTransition = transition.Value as EightDirectionTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				eightDirectionTransition.Direction = TransitionEightDirectionType.Left;
				break;
			case 1:
				eightDirectionTransition.Direction = TransitionEightDirectionType.Up;
				break;
			case 2:
				eightDirectionTransition.Direction = TransitionEightDirectionType.Right;
				break;
			case 3:
				eightDirectionTransition.Direction = TransitionEightDirectionType.Down;
				break;
			case 4:
				eightDirectionTransition.Direction = TransitionEightDirectionType.LeftUp;
				break;
			case 5:
				eightDirectionTransition.Direction = TransitionEightDirectionType.RightUp;
				break;
			case 6:
				eightDirectionTransition.Direction = TransitionEightDirectionType.LeftDown;
				break;
			case 7:
				eightDirectionTransition.Direction = TransitionEightDirectionType.RightDown;
				break;
			}
			break;
		}
		case TransitionType.Cut:
		{
			OptionalBlackTransition optionalBlackTransition = transition.Value as OptionalBlackTransition;
			optionalBlackTransition.FromBlack = atomRecord.EffectDirection == 1;
			break;
		}
		case TransitionType.Fade:
		{
			OptionalBlackTransition optionalBlackTransition2 = transition.Value as OptionalBlackTransition;
			optionalBlackTransition2.FromBlack = atomRecord.EffectType == 6;
			break;
		}
		case TransitionType.Pull:
		{
			EightDirectionTransition eightDirectionTransition2 = transition.Value as EightDirectionTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				eightDirectionTransition2.Direction = TransitionEightDirectionType.Left;
				break;
			case 1:
				eightDirectionTransition2.Direction = TransitionEightDirectionType.Up;
				break;
			case 2:
				eightDirectionTransition2.Direction = TransitionEightDirectionType.Right;
				break;
			case 3:
				eightDirectionTransition2.Direction = TransitionEightDirectionType.Down;
				break;
			case 4:
				eightDirectionTransition2.Direction = TransitionEightDirectionType.LeftUp;
				break;
			case 5:
				eightDirectionTransition2.Direction = TransitionEightDirectionType.RightUp;
				break;
			case 6:
				eightDirectionTransition2.Direction = TransitionEightDirectionType.LeftDown;
				break;
			case 7:
				eightDirectionTransition2.Direction = TransitionEightDirectionType.RightDown;
				break;
			}
			break;
		}
		case TransitionType.Push:
		{
			SideDirectionTransition sideDirectionTransition2 = transition.Value as SideDirectionTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				sideDirectionTransition2.Direction = TransitionSideDirectionType.Left;
				break;
			case 1:
				sideDirectionTransition2.Direction = TransitionSideDirectionType.Up;
				break;
			case 2:
				sideDirectionTransition2.Direction = TransitionSideDirectionType.Right;
				break;
			case 3:
				sideDirectionTransition2.Direction = TransitionSideDirectionType.Down;
				break;
			}
			break;
		}
		case TransitionType.RandomBar:
		{
			OrientationTransition orientationTransition4 = transition.Value as OrientationTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				orientationTransition4.Direction = Orientation.Horizontal;
				break;
			case 1:
				orientationTransition4.Direction = Orientation.Vertical;
				break;
			}
			break;
		}
		case TransitionType.Split:
		{
			SplitTransition splitTransition = transition.Value as SplitTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				splitTransition.Orientation = Orientation.Horizontal;
				splitTransition.Direction = TransitionInOutDirectionType.Out;
				break;
			case 1:
				splitTransition.Orientation = Orientation.Horizontal;
				splitTransition.Direction = TransitionInOutDirectionType.In;
				break;
			case 2:
				splitTransition.Orientation = Orientation.Vertical;
				splitTransition.Direction = TransitionInOutDirectionType.Out;
				break;
			case 3:
				splitTransition.Orientation = Orientation.Vertical;
				splitTransition.Direction = TransitionInOutDirectionType.In;
				break;
			}
			break;
		}
		case TransitionType.Strips:
		{
			CornerDirectionTransition cornerDirectionTransition = transition.Value as CornerDirectionTransition;
			switch (atomRecord.EffectDirection)
			{
			case 4:
				cornerDirectionTransition.Direction = TransitionCornerDirectionType.LeftUp;
				break;
			case 5:
				cornerDirectionTransition.Direction = TransitionCornerDirectionType.RightUp;
				break;
			case 6:
				cornerDirectionTransition.Direction = TransitionCornerDirectionType.LeftDown;
				break;
			case 7:
				cornerDirectionTransition.Direction = TransitionCornerDirectionType.RightDown;
				break;
			}
			break;
		}
		case TransitionType.Wheel:
		{
			WheelTransition wheelTransition = transition.Value as WheelTransition;
			if (atomRecord.EffectDirection == 1 || atomRecord.EffectDirection == 2 || atomRecord.EffectDirection == 3 || atomRecord.EffectDirection == 4 || atomRecord.EffectDirection == 8)
			{
				wheelTransition.Spokes = atomRecord.EffectDirection;
			}
			break;
		}
		case TransitionType.Circle:
		case TransitionType.Diamond:
		case TransitionType.Dissolve:
		case TransitionType.Newsflash:
		case TransitionType.Plus:
		case TransitionType.Random:
		case TransitionType.Wedge:
			break;
		case TransitionType.Wipe:
		{
			SideDirectionTransition sideDirectionTransition = transition.Value as SideDirectionTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				sideDirectionTransition.Direction = TransitionSideDirectionType.Left;
				break;
			case 1:
				sideDirectionTransition.Direction = TransitionSideDirectionType.Up;
				break;
			case 2:
				sideDirectionTransition.Direction = TransitionSideDirectionType.Right;
				break;
			case 3:
				sideDirectionTransition.Direction = TransitionSideDirectionType.Down;
				break;
			}
			break;
		}
		case TransitionType.Zoom:
		{
			InOutTransition inOutTransition = transition.Value as InOutTransition;
			switch (atomRecord.EffectDirection)
			{
			case 0:
				inOutTransition.Direction = TransitionInOutDirectionType.Out;
				break;
			case 1:
				inOutTransition.Direction = TransitionInOutDirectionType.In;
				break;
			}
			break;
		}
		}
	}

	private static void smethod_5(ISlideShowTransition transition, Class2893 atomRecord)
	{
		switch (transition.Type)
		{
		case TransitionType.Blinds:
		{
			OrientationTransition orientationTransition = transition.Value as OrientationTransition;
			atomRecord.EffectDirection = (byte)((orientationTransition.Direction == Orientation.Horizontal) ? 1u : 0u);
			break;
		}
		case TransitionType.Cut:
		{
			OptionalBlackTransition optionalBlackTransition = transition.Value as OptionalBlackTransition;
			atomRecord.EffectDirection = (byte)(optionalBlackTransition.FromBlack ? 1u : 0u);
			break;
		}
		case TransitionType.Fade:
		{
			OptionalBlackTransition optionalBlackTransition2 = transition.Value as OptionalBlackTransition;
			atomRecord.EffectType = (byte)(optionalBlackTransition2.FromBlack ? 6u : 23u);
			atomRecord.EffectDirection = 0;
			break;
		}
		case TransitionType.Cover:
		case TransitionType.Pull:
		{
			EightDirectionTransition eightDirectionTransition = transition.Value as EightDirectionTransition;
			switch (eightDirectionTransition.Direction)
			{
			case TransitionEightDirectionType.LeftDown:
				atomRecord.EffectDirection = 6;
				break;
			case TransitionEightDirectionType.LeftUp:
				atomRecord.EffectDirection = 4;
				break;
			case TransitionEightDirectionType.RightDown:
				atomRecord.EffectDirection = 7;
				break;
			case TransitionEightDirectionType.RightUp:
				atomRecord.EffectDirection = 5;
				break;
			case TransitionEightDirectionType.Left:
				atomRecord.EffectDirection = 0;
				break;
			case TransitionEightDirectionType.Up:
				atomRecord.EffectDirection = 1;
				break;
			case TransitionEightDirectionType.Down:
				atomRecord.EffectDirection = 3;
				break;
			case TransitionEightDirectionType.Right:
				atomRecord.EffectDirection = 2;
				break;
			}
			break;
		}
		case TransitionType.Checker:
		case TransitionType.Comb:
		case TransitionType.RandomBar:
		{
			OrientationTransition orientationTransition2 = transition.Value as OrientationTransition;
			atomRecord.EffectDirection = ((orientationTransition2.Direction == Orientation.Vertical) ? ((byte)1) : ((byte)0));
			break;
		}
		case TransitionType.Split:
		{
			SplitTransition splitTransition = transition.Value as SplitTransition;
			if (splitTransition.Orientation == Orientation.Horizontal)
			{
				atomRecord.EffectDirection = (byte)((splitTransition.Direction == TransitionInOutDirectionType.In) ? 1u : 0u);
			}
			else
			{
				atomRecord.EffectDirection = (byte)((splitTransition.Direction == TransitionInOutDirectionType.In) ? 3u : 2u);
			}
			break;
		}
		case TransitionType.Strips:
		{
			CornerDirectionTransition cornerDirectionTransition = transition.Value as CornerDirectionTransition;
			switch (cornerDirectionTransition.Direction)
			{
			case TransitionCornerDirectionType.LeftDown:
				atomRecord.EffectDirection = 6;
				break;
			case TransitionCornerDirectionType.LeftUp:
				atomRecord.EffectDirection = 4;
				break;
			case TransitionCornerDirectionType.RightDown:
				atomRecord.EffectDirection = 7;
				break;
			case TransitionCornerDirectionType.RightUp:
				atomRecord.EffectDirection = 5;
				break;
			}
			break;
		}
		case TransitionType.Wheel:
		{
			WheelTransition wheelTransition = transition.Value as WheelTransition;
			atomRecord.EffectDirection = (byte)wheelTransition.Spokes;
			break;
		}
		case TransitionType.Push:
		case TransitionType.Wipe:
		{
			SideDirectionTransition sideDirectionTransition = transition.Value as SideDirectionTransition;
			switch (sideDirectionTransition.Direction)
			{
			case TransitionSideDirectionType.Left:
				atomRecord.EffectDirection = 0;
				break;
			case TransitionSideDirectionType.Up:
				atomRecord.EffectDirection = 1;
				break;
			case TransitionSideDirectionType.Down:
				atomRecord.EffectDirection = 3;
				break;
			case TransitionSideDirectionType.Right:
				atomRecord.EffectDirection = 2;
				break;
			}
			break;
		}
		case TransitionType.Zoom:
		{
			InOutTransition inOutTransition = transition.Value as InOutTransition;
			atomRecord.EffectDirection = (byte)((inOutTransition.Direction == TransitionInOutDirectionType.In) ? 1u : 0u);
			break;
		}
		case TransitionType.Circle:
		case TransitionType.Diamond:
		case TransitionType.Dissolve:
		case TransitionType.Newsflash:
		case TransitionType.Plus:
		case TransitionType.Random:
		case TransitionType.Wedge:
			break;
		}
	}
}
