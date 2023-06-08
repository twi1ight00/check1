using System;
using ns23;
using ns24;

namespace Aspose.Slides.SlideShow;

public class SlideShowTransition : ISlideShowTransition
{
	private const string string_0 = "Sound property is not assigned. Sound property must be assigned to use the SoundName property.";

	internal TransitionValueBase transitionValueBase_0;

	internal bool bool_0 = true;

	internal TransitionSpeed transitionSpeed_0;

	internal uint uint_0;

	internal Audio audio_0;

	internal BaseSlide baseSlide_0;

	private bool bool_1;

	private bool bool_2;

	internal TransitionSoundMode transitionSoundMode_0 = TransitionSoundMode.NotDefined;

	private readonly Class351 class351_0;

	private readonly Class260 class260_0;

	internal Class351 PPTXUnsupportedProps => class351_0;

	internal Class260 PPTUnsupportedProps => class260_0;

	public IAudio Sound
	{
		get
		{
			return audio_0;
		}
		set
		{
			audio_0 = (Audio)value;
		}
	}

	public TransitionSoundMode SoundMode
	{
		get
		{
			return transitionSoundMode_0;
		}
		set
		{
			transitionSoundMode_0 = value;
		}
	}

	[Obsolete("Use SoundIsBuiltIn property instead. Property will be removed after 01.09.2013.")]
	public bool BuiltInSound
	{
		get
		{
			return SoundIsBuiltIn;
		}
		set
		{
			SoundIsBuiltIn = value;
		}
	}

	public bool SoundLoop
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool AdvanceOnClick
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public uint AdvanceAfterTime
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public TransitionSpeed Speed
	{
		get
		{
			return transitionSpeed_0;
		}
		set
		{
			transitionSpeed_0 = value;
		}
	}

	public ITransitionValueBase Value => transitionValueBase_0;

	public TransitionType Type
	{
		get
		{
			return transitionValueBase_0.transitionType_0;
		}
		set
		{
			switch (value)
			{
			case TransitionType.None:
				transitionValueBase_0 = new TransitionValueBase(TransitionType.None);
				break;
			case TransitionType.Blinds:
				transitionValueBase_0 = new OrientationTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1600";
				((OrientationTransition)transitionValueBase_0).Direction = Orientation.Vertical;
				break;
			case TransitionType.Checker:
				transitionValueBase_0 = new OrientationTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2500";
				break;
			case TransitionType.Circle:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "800";
				break;
			case TransitionType.Comb:
				transitionValueBase_0 = new OrientationTransition(value);
				break;
			case TransitionType.Cover:
				transitionValueBase_0 = new EightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.Cut:
				transitionValueBase_0 = new OptionalBlackTransition(value);
				transitionSpeed_0 = TransitionSpeed.Fast;
				class351_0.Duration = "100";
				break;
			case TransitionType.Diamond:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "800";
				break;
			case TransitionType.Dissolve:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1200";
				break;
			case TransitionType.Fade:
				transitionValueBase_0 = new OptionalBlackTransition(value);
				transitionSpeed_0 = TransitionSpeed.Medium;
				class351_0.Duration = "700";
				break;
			case TransitionType.Newsflash:
				transitionValueBase_0 = new EmptyTransition(value);
				break;
			case TransitionType.Plus:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.Pull:
				transitionValueBase_0 = new EightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.Push:
				transitionValueBase_0 = new SideDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				((SideDirectionTransition)transitionValueBase_0).Direction = TransitionSideDirectionType.Up;
				break;
			case TransitionType.Random:
				transitionValueBase_0 = new EmptyTransition(value);
				break;
			case TransitionType.RandomBar:
				transitionValueBase_0 = new OrientationTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				((OrientationTransition)transitionValueBase_0).Direction = Orientation.Vertical;
				break;
			case TransitionType.Split:
				transitionValueBase_0 = new SplitTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1500";
				((SplitTransition)transitionValueBase_0).Orientation = Orientation.Vertical;
				break;
			case TransitionType.Strips:
				transitionValueBase_0 = new CornerDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.Wedge:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.Wheel:
				transitionValueBase_0 = new WheelTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.Wipe:
				transitionValueBase_0 = new SideDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.Zoom:
				transitionValueBase_0 = new InOutTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1200";
				break;
			case TransitionType.Vortex:
				transitionValueBase_0 = new SideDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "4000";
				((SideDirectionTransition)transitionValueBase_0).Direction = TransitionSideDirectionType.Right;
				break;
			case TransitionType.Switch:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1100";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Right;
				break;
			case TransitionType.Flip:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1200";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Right;
				break;
			case TransitionType.Ripple:
				transitionValueBase_0 = new RippleTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1400";
				break;
			case TransitionType.Honeycomb:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "4400";
				break;
			case TransitionType.Cube:
				transitionValueBase_0 = new SideDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1200";
				break;
			case TransitionType.Box:
				transitionValueBase_0 = new SideDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1600";
				break;
			case TransitionType.Rotate:
				transitionValueBase_0 = new SideDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2000";
				break;
			case TransitionType.Orbit:
				transitionValueBase_0 = new SideDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1600";
				break;
			case TransitionType.Doors:
				transitionValueBase_0 = new OrientationTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1400";
				((OrientationTransition)transitionValueBase_0).Direction = Orientation.Vertical;
				break;
			case TransitionType.Window:
				transitionValueBase_0 = new OrientationTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1500";
				((OrientationTransition)transitionValueBase_0).Direction = Orientation.Vertical;
				break;
			case TransitionType.Ferris:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2000";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Left;
				break;
			case TransitionType.Gallery:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1600";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Left;
				break;
			case TransitionType.Conveyor:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1600";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Left;
				break;
			case TransitionType.Pan:
				transitionValueBase_0 = new SideDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1300";
				((SideDirectionTransition)transitionValueBase_0).Direction = TransitionSideDirectionType.Up;
				break;
			case TransitionType.Glitter:
				transitionValueBase_0 = new GlitterTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "3900";
				((GlitterTransition)transitionValueBase_0).Direction = TransitionSideDirectionType.Left;
				((GlitterTransition)transitionValueBase_0).Pattern = TransitionPattern.Hexagon;
				break;
			case TransitionType.Warp:
				transitionValueBase_0 = new InOutTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "900";
				((InOutTransition)transitionValueBase_0).Direction = TransitionInOutDirectionType.In;
				break;
			case TransitionType.Flythrough:
				transitionValueBase_0 = new FlyThroughTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "800";
				((FlyThroughTransition)transitionValueBase_0).Direction = TransitionInOutDirectionType.In;
				break;
			case TransitionType.Flash:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.Shred:
				transitionValueBase_0 = new ShredTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "3000";
				break;
			case TransitionType.Reveal:
				transitionValueBase_0 = new RevealTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "3400";
				((RevealTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Right;
				break;
			case TransitionType.WheelReverse:
				transitionValueBase_0 = new WheelTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1000";
				break;
			case TransitionType.FallOver:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2000";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Left;
				break;
			case TransitionType.Drape:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2000";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Left;
				break;
			case TransitionType.Curtains:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "6000";
				break;
			case TransitionType.Wind:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2000";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Right;
				break;
			case TransitionType.Prestige:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2000";
				break;
			case TransitionType.Fracture:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2000";
				break;
			case TransitionType.Crush:
				transitionValueBase_0 = new EmptyTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "2000";
				break;
			case TransitionType.PeelOff:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1250";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Left;
				break;
			case TransitionType.PageCurlDouble:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1250";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Left;
				break;
			case TransitionType.PageCurlSingle:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1250";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Left;
				break;
			case TransitionType.Airplane:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "1250";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Right;
				break;
			case TransitionType.Origami:
				transitionValueBase_0 = new LeftRightDirectionTransition(value);
				transitionSpeed_0 = TransitionSpeed.Slow;
				class351_0.Duration = "3250";
				((LeftRightDirectionTransition)transitionValueBase_0).Direction = TransitionLeftRightDirectionType.Right;
				break;
			}
			PPTXUnsupportedProps.method_0();
		}
	}

	public bool SoundIsBuiltIn
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public string SoundName
	{
		get
		{
			if (audio_0 == null)
			{
				throw new PptxException("Sound property is not assigned. Sound property must be assigned to use the SoundName property.");
			}
			return audio_0.PPTUnsupportedProps.SoundName;
		}
		set
		{
			if (audio_0 == null)
			{
				throw new PptxException("Sound property is not assigned. Sound property must be assigned to use the SoundName property.");
			}
			audio_0.PPTUnsupportedProps.SoundName = value;
		}
	}

	internal SlideShowTransition(BaseSlide slide)
	{
		baseSlide_0 = slide;
		transitionValueBase_0 = new TransitionValueBase(TransitionType.None);
		class351_0 = new Class351(this);
		class260_0 = new Class260();
	}

	public override bool Equals(object obj)
	{
		if (obj is SlideShowTransition)
		{
			return Equals((SlideShowTransition)obj);
		}
		return false;
	}

	internal bool Equals(ISlideShowTransition transition)
	{
		if (transition == null)
		{
			return false;
		}
		SlideShowTransition slideShowTransition = (SlideShowTransition)transition;
		if ((audio_0 == null) ^ (slideShowTransition.audio_0 == null))
		{
			return false;
		}
		if (transitionValueBase_0.Equals(slideShowTransition.transitionValueBase_0) && bool_0 == slideShowTransition.bool_0 && transitionSpeed_0 == slideShowTransition.transitionSpeed_0 && uint_0 == slideShowTransition.uint_0 && (audio_0 == null || audio_0.CRC == slideShowTransition.audio_0.CRC) && bool_1 == slideShowTransition.bool_1 && bool_2 == slideShowTransition.bool_2 && transitionSoundMode_0 == slideShowTransition.transitionSoundMode_0 && class351_0.Equals(slideShowTransition.class351_0))
		{
			return class260_0.Equals(slideShowTransition.class260_0);
		}
		return false;
	}
}
