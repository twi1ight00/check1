using System;
using Aspose.Slides;
using Aspose.Slides.SlideShow;
using ns16;
using ns24;
using ns46;
using ns56;

namespace ns18;

internal class Class992
{
	public static void smethod_0(ISlideShowTransition slideShowTransition, Class1353 AlternateContentOf_transitionElementData, Class1341 deserializationContext)
	{
		if (AlternateContentOf_transitionElementData == null)
		{
			return;
		}
		Class2260 @class = ((Class1120.list_0.Contains("http://schemas.microsoft.com/office/powerpoint/2012/main") && AlternateContentOf_transitionElementData.Choice_p15 != null) ? AlternateContentOf_transitionElementData.Choice_p15 : ((!Class1120.list_0.Contains("http://schemas.microsoft.com/office/powerpoint/2010/main") || AlternateContentOf_transitionElementData.Choice_p14 == null) ? AlternateContentOf_transitionElementData.Fallback : AlternateContentOf_transitionElementData.Choice_p14));
		Class2605 transition = @class.Transition;
		if (transition != null)
		{
			switch (transition.Name)
			{
			case "blinds":
			{
				Class2245 orientationTransitionElementData6 = (Class2245)transition.Object;
				slideShowTransition.Type = TransitionType.Blinds;
				Class989.smethod_0((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData6);
				break;
			}
			case "checker":
			{
				Class2245 orientationTransitionElementData5 = (Class2245)transition.Object;
				slideShowTransition.Type = TransitionType.Checker;
				Class989.smethod_0((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData5);
				break;
			}
			case "circle":
				slideShowTransition.Type = TransitionType.Circle;
				break;
			case "comb":
			{
				Class2245 orientationTransitionElementData4 = (Class2245)transition.Object;
				slideShowTransition.Type = TransitionType.Comb;
				Class989.smethod_0((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData4);
				break;
			}
			case "cover":
			{
				Class2233 eightDirectionTransitionElementData2 = (Class2233)transition.Object;
				slideShowTransition.Type = TransitionType.Cover;
				Class986.smethod_0((IEightDirectionTransition)slideShowTransition.Value, eightDirectionTransitionElementData2);
				break;
			}
			case "cut":
			{
				Class2244 optionalBlackTransitionElementData2 = (Class2244)transition.Object;
				slideShowTransition.Type = TransitionType.Cut;
				Class988.smethod_0((IOptionalBlackTransition)slideShowTransition.Value, optionalBlackTransitionElementData2);
				break;
			}
			case "diamond":
				slideShowTransition.Type = TransitionType.Diamond;
				break;
			case "dissolve":
				slideShowTransition.Type = TransitionType.Dissolve;
				break;
			case "fade":
			{
				Class2244 optionalBlackTransitionElementData = (Class2244)transition.Object;
				slideShowTransition.Type = TransitionType.Fade;
				Class988.smethod_0((IOptionalBlackTransition)slideShowTransition.Value, optionalBlackTransitionElementData);
				break;
			}
			case "newsflash":
				slideShowTransition.Type = TransitionType.Newsflash;
				break;
			case "plus":
				slideShowTransition.Type = TransitionType.Plus;
				break;
			case "pull":
			{
				Class2233 eightDirectionTransitionElementData = (Class2233)transition.Object;
				slideShowTransition.Type = TransitionType.Pull;
				Class986.smethod_0((IEightDirectionTransition)slideShowTransition.Value, eightDirectionTransitionElementData);
				break;
			}
			case "push":
			{
				Class2250 sideDirectionTransitionElementData4 = (Class2250)transition.Object;
				slideShowTransition.Type = TransitionType.Push;
				Class990.smethod_0((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData4);
				break;
			}
			case "random":
				slideShowTransition.Type = TransitionType.Random;
				break;
			case "randomBar":
			{
				Class2245 orientationTransitionElementData3 = (Class2245)transition.Object;
				slideShowTransition.Type = TransitionType.RandomBar;
				Class989.smethod_0((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData3);
				break;
			}
			case "split":
			{
				Class2261 splitElementData = (Class2261)transition.Object;
				slideShowTransition.Type = TransitionType.Split;
				Class991.smethod_0((ISplitTransition)slideShowTransition.Value, splitElementData);
				break;
			}
			case "strips":
			{
				Class2230 cornerDirectionTransitionElementData = (Class2230)transition.Object;
				slideShowTransition.Type = TransitionType.Strips;
				Class985.smethod_0((ICornerDirectionTransition)slideShowTransition.Value, cornerDirectionTransitionElementData);
				break;
			}
			case "wedge":
				slideShowTransition.Type = TransitionType.Wedge;
				break;
			case "wheel":
			{
				Class2311 wheelElementData2 = (Class2311)transition.Object;
				slideShowTransition.Type = TransitionType.Wheel;
				Class993.smethod_0((IWheelTransition)slideShowTransition.Value, wheelElementData2);
				break;
			}
			case "wipe":
			{
				Class2250 sideDirectionTransitionElementData3 = (Class2250)transition.Object;
				slideShowTransition.Type = TransitionType.Wipe;
				Class990.smethod_0((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData3);
				break;
			}
			case "zoom":
			{
				Class2240 inOutTransitionElementData2 = (Class2240)transition.Object;
				slideShowTransition.Type = TransitionType.Zoom;
				Class987.smethod_0((IInOutTransition)slideShowTransition.Value, inOutTransitionElementData2);
				break;
			}
			case "vortex":
			{
				Class2250 sideDirectionTransitionElementData2 = (Class2250)transition.Object;
				slideShowTransition.Type = TransitionType.Vortex;
				Class990.smethod_0((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData2);
				break;
			}
			case "switch":
			{
				Class1360 leftRightDirectionTransitionElementData5 = (Class1360)transition.Object;
				slideShowTransition.Type = TransitionType.Switch;
				Class244.smethod_0((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData5);
				break;
			}
			case "flip":
			{
				Class1360 leftRightDirectionTransitionElementData4 = (Class1360)transition.Object;
				slideShowTransition.Type = TransitionType.Flip;
				Class244.smethod_0((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData4);
				break;
			}
			case "ripple":
			{
				Class1364 rippleTransitionElementData2 = (Class1364)transition.Object;
				slideShowTransition.Type = TransitionType.Ripple;
				Class243.smethod_0((IRippleTransition)slideShowTransition.Value, rippleTransitionElementData2);
				break;
			}
			case "honeycomb":
				slideShowTransition.Type = TransitionType.Honeycomb;
				break;
			case "prism":
			{
				Class1362 rippleTransitionElementData = (Class1362)transition.Object;
				Class242.smethod_0(slideShowTransition, rippleTransitionElementData);
				break;
			}
			case "doors":
			{
				Class2245 orientationTransitionElementData2 = (Class2245)transition.Object;
				slideShowTransition.Type = TransitionType.Doors;
				Class989.smethod_0((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData2);
				break;
			}
			case "window":
			{
				Class2245 orientationTransitionElementData = (Class2245)transition.Object;
				slideShowTransition.Type = TransitionType.Window;
				Class989.smethod_0((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData);
				break;
			}
			case "ferris":
			{
				Class1360 leftRightDirectionTransitionElementData3 = (Class1360)transition.Object;
				slideShowTransition.Type = TransitionType.Ferris;
				Class244.smethod_0((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData3);
				break;
			}
			case "gallery":
			{
				Class1360 leftRightDirectionTransitionElementData2 = (Class1360)transition.Object;
				slideShowTransition.Type = TransitionType.Gallery;
				Class244.smethod_0((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData2);
				break;
			}
			case "conveyor":
			{
				Class1360 leftRightDirectionTransitionElementData = (Class1360)transition.Object;
				slideShowTransition.Type = TransitionType.Conveyor;
				Class244.smethod_0((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData);
				break;
			}
			case "pan":
			{
				Class2250 sideDirectionTransitionElementData = (Class2250)transition.Object;
				slideShowTransition.Type = TransitionType.Pan;
				Class990.smethod_0((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData);
				break;
			}
			case "glitter":
			{
				Class1359 glitterTransitionElementData = (Class1359)transition.Object;
				slideShowTransition.Type = TransitionType.Glitter;
				Class241.smethod_0((IGlitterTransition)slideShowTransition.Value, glitterTransitionElementData);
				break;
			}
			case "warp":
			{
				Class2240 inOutTransitionElementData = (Class2240)transition.Object;
				slideShowTransition.Type = TransitionType.Warp;
				Class987.smethod_0((IInOutTransition)slideShowTransition.Value, inOutTransitionElementData);
				break;
			}
			case "flythrough":
			{
				Class1358 flyThroughTransitionElementData = (Class1358)transition.Object;
				slideShowTransition.Type = TransitionType.Flythrough;
				Class240.smethod_0((IFlyThroughTransition)slideShowTransition.Value, flyThroughTransitionElementData);
				break;
			}
			case "flash":
				slideShowTransition.Type = TransitionType.Flash;
				break;
			case "shred":
			{
				Class1365 shredElementData = (Class1365)transition.Object;
				slideShowTransition.Type = TransitionType.Shred;
				Class239.smethod_0((IShredTransition)slideShowTransition.Value, shredElementData);
				break;
			}
			case "reveal":
			{
				Class1363 revealElementData = (Class1363)transition.Object;
				slideShowTransition.Type = TransitionType.Reveal;
				Class238.smethod_0((IRevealTransition)slideShowTransition.Value, revealElementData);
				break;
			}
			case "wheelReverse":
			{
				Class2311 wheelElementData = (Class2311)transition.Object;
				slideShowTransition.Type = TransitionType.WheelReverse;
				Class993.smethod_0((IWheelTransition)slideShowTransition.Value, wheelElementData);
				break;
			}
			case "prstTrans":
			{
				Class1366 presetTransitionElementData = (Class1366)transition.Object;
				Class237.smethod_0(slideShowTransition, presetTransitionElementData);
				break;
			}
			default:
				throw new Exception("Unknown element \"" + transition.Name + "\"");
			}
		}
		if (@class.SndAc != null)
		{
			Class2605 action = @class.SndAc.Action;
			switch (action.Name)
			{
			case "endSnd":
				slideShowTransition.SoundMode = TransitionSoundMode.StopPrevoiusSound;
				break;
			case "stSnd":
			{
				Class2310 class2 = (Class2310)action.Object;
				slideShowTransition.SoundMode = TransitionSoundMode.StartSound;
				slideShowTransition.SoundLoop = class2.Loop;
				slideShowTransition.SoundIsBuiltIn = class2.Snd.BuiltIn;
				slideShowTransition.Sound = deserializationContext.method_2(deserializationContext.RelationshipsOfCurrentPartEntry[class2.Snd.R_Embed].TargetPart);
				if (slideShowTransition.Sound != null)
				{
					slideShowTransition.SoundName = class2.Snd.Name;
				}
				break;
			}
			default:
				throw new Exception("Unknown element \"" + action.Name + "\"");
			}
		}
		Class351 pPTXUnsupportedProps = ((SlideShowTransition)slideShowTransition).PPTXUnsupportedProps;
		pPTXUnsupportedProps.Duration = @class.P14_Dur;
		pPTXUnsupportedProps.ExtensionList = @class.ExtLst;
		slideShowTransition.AdvanceOnClick = @class.AdvClick;
		slideShowTransition.AdvanceAfterTime = ((@class.AdvTm != uint.MaxValue) ? @class.AdvTm : 0u);
		switch (@class.Spd)
		{
		case Enum360.const_1:
			slideShowTransition.Speed = TransitionSpeed.Slow;
			break;
		case Enum360.const_2:
			slideShowTransition.Speed = TransitionSpeed.Medium;
			break;
		default:
			slideShowTransition.Speed = TransitionSpeed.Fast;
			break;
		}
	}

	public static void smethod_1(ISlideShowTransition slideShowTransition, Class1353.Delegate21 addTransition, Class1346 serializationContext)
	{
		Class1353 @class = addTransition();
		bool flag = smethod_4(slideShowTransition);
		bool flag2 = smethod_3(slideShowTransition);
		Class2260 class2 = null;
		Class2260 class3 = null;
		if (flag)
		{
			class3 = @class.delegate2527_1();
		}
		else if (flag2)
		{
			class2 = @class.delegate2527_2();
		}
		Class2260 class4 = @class.delegate2527_0();
		switch (slideShowTransition.Type)
		{
		default:
			throw new Exception();
		case TransitionType.Blinds:
		{
			Class2245 orientationTransitionElementData4;
			if (class2 != null)
			{
				orientationTransitionElementData4 = (Class2245)class2.delegate2773_0("blinds").Object;
				Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData4);
			}
			orientationTransitionElementData4 = (Class2245)class4.delegate2773_0("blinds").Object;
			Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData4);
			break;
		}
		case TransitionType.Checker:
		{
			Class2245 orientationTransitionElementData3;
			if (class2 != null)
			{
				orientationTransitionElementData3 = (Class2245)class2.delegate2773_0("checker").Object;
				Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData3);
			}
			orientationTransitionElementData3 = (Class2245)class4.delegate2773_0("checker").Object;
			Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData3);
			break;
		}
		case TransitionType.Circle:
			class2?.delegate2773_0("circle");
			class4.delegate2773_0("circle");
			break;
		case TransitionType.Comb:
		{
			Class2245 orientationTransitionElementData5;
			if (class2 != null)
			{
				orientationTransitionElementData5 = (Class2245)class2.delegate2773_0("comb").Object;
				Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData5);
			}
			orientationTransitionElementData5 = (Class2245)class4.delegate2773_0("comb").Object;
			Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData5);
			break;
		}
		case TransitionType.Cover:
		{
			Class2233 eightDirectionTransitionElementData2;
			if (class2 != null)
			{
				eightDirectionTransitionElementData2 = (Class2233)class2.delegate2773_0("cover").Object;
				Class986.smethod_1((IEightDirectionTransition)slideShowTransition.Value, eightDirectionTransitionElementData2);
			}
			eightDirectionTransitionElementData2 = (Class2233)class4.delegate2773_0("cover").Object;
			Class986.smethod_1((IEightDirectionTransition)slideShowTransition.Value, eightDirectionTransitionElementData2);
			break;
		}
		case TransitionType.Cut:
		{
			Class2244 optionalBlackTransitionElementData2;
			if (class2 != null)
			{
				optionalBlackTransitionElementData2 = (Class2244)class2.delegate2773_0("cut").Object;
				Class988.smethod_1((IOptionalBlackTransition)slideShowTransition.Value, optionalBlackTransitionElementData2);
			}
			optionalBlackTransitionElementData2 = (Class2244)class4.delegate2773_0("cut").Object;
			Class988.smethod_1((IOptionalBlackTransition)slideShowTransition.Value, optionalBlackTransitionElementData2);
			break;
		}
		case TransitionType.Diamond:
			class2?.delegate2773_0("diamond");
			class4.delegate2773_0("diamond");
			break;
		case TransitionType.Dissolve:
			class2?.delegate2773_0("dissolve");
			class4.delegate2773_0("dissolve");
			break;
		case TransitionType.Fade:
		{
			Class2244 optionalBlackTransitionElementData;
			if (class2 != null)
			{
				optionalBlackTransitionElementData = (Class2244)class2.delegate2773_0("fade").Object;
				Class988.smethod_1((IOptionalBlackTransition)slideShowTransition.Value, optionalBlackTransitionElementData);
			}
			optionalBlackTransitionElementData = (Class2244)class4.delegate2773_0("fade").Object;
			Class988.smethod_1((IOptionalBlackTransition)slideShowTransition.Value, optionalBlackTransitionElementData);
			break;
		}
		case TransitionType.Newsflash:
			class2?.delegate2773_0("newsflash");
			class4.delegate2773_0("newsflash");
			break;
		case TransitionType.Plus:
			class2?.delegate2773_0("plus");
			class4.delegate2773_0("plus");
			break;
		case TransitionType.Pull:
		{
			Class2233 eightDirectionTransitionElementData;
			if (class2 != null)
			{
				eightDirectionTransitionElementData = (Class2233)class2.delegate2773_0("pull").Object;
				Class986.smethod_1((IEightDirectionTransition)slideShowTransition.Value, eightDirectionTransitionElementData);
			}
			eightDirectionTransitionElementData = (Class2233)class4.delegate2773_0("pull").Object;
			Class986.smethod_1((IEightDirectionTransition)slideShowTransition.Value, eightDirectionTransitionElementData);
			break;
		}
		case TransitionType.Push:
		{
			Class2250 sideDirectionTransitionElementData4;
			if (class2 != null)
			{
				sideDirectionTransitionElementData4 = (Class2250)class2.delegate2773_0("push").Object;
				Class990.smethod_1((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData4);
			}
			sideDirectionTransitionElementData4 = (Class2250)class4.delegate2773_0("push").Object;
			Class990.smethod_1((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData4);
			break;
		}
		case TransitionType.Random:
			class2?.delegate2773_0("random");
			class4.delegate2773_0("random");
			break;
		case TransitionType.RandomBar:
		{
			Class2245 orientationTransitionElementData6;
			if (class2 != null)
			{
				orientationTransitionElementData6 = (Class2245)class2.delegate2773_0("randomBar").Object;
				Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData6);
			}
			orientationTransitionElementData6 = (Class2245)class4.delegate2773_0("randomBar").Object;
			Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData6);
			break;
		}
		case TransitionType.Split:
		{
			Class2261 splitElementData;
			if (class2 != null)
			{
				splitElementData = (Class2261)class2.delegate2773_0("split").Object;
				Class991.smethod_1((ISplitTransition)slideShowTransition.Value, splitElementData);
			}
			splitElementData = (Class2261)class4.delegate2773_0("split").Object;
			Class991.smethod_1((ISplitTransition)slideShowTransition.Value, splitElementData);
			break;
		}
		case TransitionType.Strips:
		{
			Class2230 cornerDirectionTransitionElementData;
			if (class2 != null)
			{
				cornerDirectionTransitionElementData = (Class2230)class2.delegate2773_0("strips").Object;
				Class985.smethod_1((ICornerDirectionTransition)slideShowTransition.Value, cornerDirectionTransitionElementData);
			}
			cornerDirectionTransitionElementData = (Class2230)class4.delegate2773_0("strips").Object;
			Class985.smethod_1((ICornerDirectionTransition)slideShowTransition.Value, cornerDirectionTransitionElementData);
			break;
		}
		case TransitionType.Wedge:
			class2?.delegate2773_0("wedge");
			class4.delegate2773_0("wedge");
			break;
		case TransitionType.Wheel:
		{
			Class2311 wheelElementData2;
			if (class2 != null)
			{
				wheelElementData2 = (Class2311)class2.delegate2773_0("wheel").Object;
				Class993.smethod_1((IWheelTransition)slideShowTransition.Value, wheelElementData2);
			}
			wheelElementData2 = (Class2311)class4.delegate2773_0("wheel").Object;
			Class993.smethod_1((IWheelTransition)slideShowTransition.Value, wheelElementData2);
			break;
		}
		case TransitionType.Wipe:
		{
			Class2250 sideDirectionTransitionElementData3;
			if (class2 != null)
			{
				sideDirectionTransitionElementData3 = (Class2250)class2.delegate2773_0("wipe").Object;
				Class990.smethod_1((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData3);
			}
			sideDirectionTransitionElementData3 = (Class2250)class4.delegate2773_0("wipe").Object;
			Class990.smethod_1((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData3);
			break;
		}
		case TransitionType.Zoom:
		{
			Class2240 inOutTransitionElementData2;
			if (class2 != null)
			{
				inOutTransitionElementData2 = (Class2240)class2.delegate2773_0("zoom").Object;
				Class987.smethod_1((IInOutTransition)slideShowTransition.Value, inOutTransitionElementData2);
			}
			inOutTransitionElementData2 = (Class2240)class4.delegate2773_0("zoom").Object;
			Class987.smethod_1((IInOutTransition)slideShowTransition.Value, inOutTransitionElementData2);
			break;
		}
		case TransitionType.Vortex:
		{
			Class2250 sideDirectionTransitionElementData2 = (Class2250)class2.delegate2773_0("vortex").Object;
			Class990.smethod_1((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData2);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Switch:
		{
			Class1360 leftRightDirectionTransitionElementData5 = (Class1360)class2.delegate2773_0("switch").Object;
			Class244.smethod_1((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData5);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Flip:
		{
			Class1360 leftRightDirectionTransitionElementData4 = (Class1360)class2.delegate2773_0("flip").Object;
			Class244.smethod_1((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData4);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Ripple:
		{
			Class1364 rippleTransitionElementData2 = (Class1364)class2.delegate2773_0("ripple").Object;
			Class243.smethod_1((IRippleTransition)slideShowTransition.Value, rippleTransitionElementData2);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Honeycomb:
			class2.delegate2773_0("honeycomb");
			class4.delegate2773_0("fade");
			break;
		case TransitionType.Cube:
		case TransitionType.Box:
		case TransitionType.Rotate:
		case TransitionType.Orbit:
		{
			Class1362 rippleTransitionElementData = (Class1362)class2.delegate2773_0("prism").Object;
			Class242.smethod_1(slideShowTransition, rippleTransitionElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Doors:
		{
			Class2245 orientationTransitionElementData2 = (Class2245)class2.delegate2773_0("doors").Object;
			Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData2);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Window:
		{
			Class2245 orientationTransitionElementData = (Class2245)class2.delegate2773_0("window").Object;
			Class989.smethod_1((IOrientationTransition)slideShowTransition.Value, orientationTransitionElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Ferris:
		{
			Class1360 leftRightDirectionTransitionElementData3 = (Class1360)class2.delegate2773_0("ferris").Object;
			Class244.smethod_1((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData3);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Gallery:
		{
			Class1360 leftRightDirectionTransitionElementData2 = (Class1360)class2.delegate2773_0("gallery").Object;
			Class244.smethod_1((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData2);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Conveyor:
		{
			Class1360 leftRightDirectionTransitionElementData = (Class1360)class2.delegate2773_0("conveyor").Object;
			Class244.smethod_1((ILeftRightDirectionTransition)slideShowTransition.Value, leftRightDirectionTransitionElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Pan:
		{
			Class2250 sideDirectionTransitionElementData = (Class2250)class2.delegate2773_0("pan").Object;
			Class990.smethod_1((ISideDirectionTransition)slideShowTransition.Value, sideDirectionTransitionElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Glitter:
		{
			Class1359 glitterTransitionElementData = (Class1359)class2.delegate2773_0("glitter").Object;
			Class241.smethod_1((IGlitterTransition)slideShowTransition.Value, glitterTransitionElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Warp:
		{
			Class2240 inOutTransitionElementData = (Class2240)class2.delegate2773_0("warp").Object;
			Class987.smethod_1((IInOutTransition)slideShowTransition.Value, inOutTransitionElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Flythrough:
		{
			Class1358 flyThroughTransitionElementData = (Class1358)class2.delegate2773_0("flythrough").Object;
			Class240.smethod_1((IFlyThroughTransition)slideShowTransition.Value, flyThroughTransitionElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Flash:
			class2.delegate2773_0("flash");
			class4.delegate2773_0("fade");
			break;
		case TransitionType.Shred:
		{
			Class1365 shredElementData = (Class1365)class2.delegate2773_0("shred").Object;
			Class239.smethod_1((IShredTransition)slideShowTransition.Value, shredElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.Reveal:
		{
			Class1363 revealElementData = (Class1363)class2.delegate2773_0("reveal").Object;
			Class238.smethod_1((IRevealTransition)slideShowTransition.Value, revealElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.WheelReverse:
		{
			Class2311 wheelElementData = (Class2311)class2.delegate2773_0("wheelReverse").Object;
			Class993.smethod_1((IWheelTransition)slideShowTransition.Value, wheelElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.FallOver:
		case TransitionType.Drape:
		case TransitionType.Curtains:
		case TransitionType.Wind:
		case TransitionType.Prestige:
		case TransitionType.Fracture:
		case TransitionType.Crush:
		case TransitionType.PeelOff:
		case TransitionType.PageCurlDouble:
		case TransitionType.PageCurlSingle:
		case TransitionType.Airplane:
		case TransitionType.Origami:
		{
			Class1366 presetTransitionElementData = (Class1366)class3.delegate2773_0("prstTrans").Object;
			Class237.smethod_1(slideShowTransition, presetTransitionElementData);
			class4.delegate2773_0("fade");
			break;
		}
		case TransitionType.None:
			break;
		}
		switch (slideShowTransition.Speed)
		{
		case TransitionSpeed.Fast:
			if (class2 != null)
			{
				class2.Spd = Enum360.const_3;
			}
			else if (class3 != null)
			{
				class3.Spd = Enum360.const_3;
			}
			class4.Spd = Enum360.const_3;
			break;
		case TransitionSpeed.Medium:
			if (class2 != null)
			{
				class2.Spd = Enum360.const_2;
			}
			else if (class3 != null)
			{
				class3.Spd = Enum360.const_2;
			}
			class4.Spd = Enum360.const_2;
			break;
		case TransitionSpeed.Slow:
			if (class2 != null)
			{
				class2.Spd = Enum360.const_1;
			}
			else if (class3 != null)
			{
				class3.Spd = Enum360.const_1;
			}
			class4.Spd = Enum360.const_1;
			break;
		}
		if (class2 != null)
		{
			class2.AdvClick = slideShowTransition.AdvanceOnClick;
		}
		else if (class3 != null)
		{
			class3.AdvClick = slideShowTransition.AdvanceOnClick;
		}
		class4.AdvClick = slideShowTransition.AdvanceOnClick;
		if (slideShowTransition.AdvanceAfterTime != 0)
		{
			if (class2 != null)
			{
				class2.AdvTm = slideShowTransition.AdvanceAfterTime;
			}
			else if (class3 != null)
			{
				class3.AdvTm = slideShowTransition.AdvanceAfterTime;
			}
			class4.AdvTm = slideShowTransition.AdvanceAfterTime;
		}
		switch (slideShowTransition.SoundMode)
		{
		case TransitionSoundMode.StartSound:
			if (slideShowTransition.Sound != null)
			{
				Class2309 soundActionElementData;
				if (class2 != null)
				{
					soundActionElementData = class2.delegate2674_0();
					smethod_2(slideShowTransition, soundActionElementData, serializationContext);
				}
				else if (class3 != null)
				{
					soundActionElementData = class3.delegate2674_0();
					smethod_2(slideShowTransition, soundActionElementData, serializationContext);
				}
				soundActionElementData = class4.delegate2674_0();
				smethod_2(slideShowTransition, soundActionElementData, serializationContext);
			}
			break;
		case TransitionSoundMode.StopPrevoiusSound:
			if (class2 != null)
			{
				class2.delegate2674_0().delegate2773_0("endSnd");
			}
			else
			{
				class3?.delegate2674_0().delegate2773_0("endSnd");
			}
			class4.delegate2674_0().delegate2773_0("endSnd");
			break;
		}
		Class351 pPTXUnsupportedProps = ((SlideShowTransition)slideShowTransition).PPTXUnsupportedProps;
		if (class2 != null)
		{
			class2.P14_Dur = pPTXUnsupportedProps.Duration;
		}
		else if (class3 != null)
		{
			class3.P14_Dur = pPTXUnsupportedProps.Duration;
		}
		class4.P14_Dur = null;
		if (class2 != null)
		{
			class2.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
		else
		{
			class3?.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
		class4.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	private static void smethod_2(ISlideShowTransition slideShowTransition, Class2309 soundActionElementData, Class1346 serializationContext)
	{
		Class2310 @class = (Class2310)soundActionElementData.delegate2773_0("stSnd").Object;
		@class.Loop = slideShowTransition.SoundLoop;
		if (slideShowTransition.Sound != null)
		{
			@class.Snd.Name = slideShowTransition.SoundName;
		}
		@class.Snd.BuiltIn = slideShowTransition.SoundIsBuiltIn;
		@class.Snd.R_Embed = serializationContext.RelationshipsOfCurrentPartEntry.method_4(serializationContext.method_5(slideShowTransition.Sound)).Id;
	}

	private static bool smethod_3(ISlideShowTransition slideShowTransition)
	{
		if (smethod_4(slideShowTransition))
		{
			return false;
		}
		bool flag;
		switch (slideShowTransition.Type)
		{
		default:
			flag = false;
			break;
		case TransitionType.Vortex:
		case TransitionType.Switch:
		case TransitionType.Flip:
		case TransitionType.Ripple:
		case TransitionType.Honeycomb:
		case TransitionType.Cube:
		case TransitionType.Box:
		case TransitionType.Rotate:
		case TransitionType.Orbit:
		case TransitionType.Doors:
		case TransitionType.Window:
		case TransitionType.Ferris:
		case TransitionType.Gallery:
		case TransitionType.Conveyor:
		case TransitionType.Pan:
		case TransitionType.Glitter:
		case TransitionType.Warp:
		case TransitionType.Flythrough:
		case TransitionType.Flash:
		case TransitionType.Shred:
		case TransitionType.Reveal:
		case TransitionType.WheelReverse:
			flag = true;
			break;
		}
		Class351 pPTXUnsupportedProps = ((SlideShowTransition)slideShowTransition).PPTXUnsupportedProps;
		bool result = pPTXUnsupportedProps.Duration != null && !(pPTXUnsupportedProps.Duration == "1000");
		if (!flag)
		{
			return result;
		}
		return true;
	}

	private static bool smethod_4(ISlideShowTransition slideShowTransition)
	{
		switch (slideShowTransition.Type)
		{
		default:
			return false;
		case TransitionType.FallOver:
		case TransitionType.Drape:
		case TransitionType.Curtains:
		case TransitionType.Wind:
		case TransitionType.Prestige:
		case TransitionType.Fracture:
		case TransitionType.Crush:
		case TransitionType.PeelOff:
		case TransitionType.PageCurlDouble:
		case TransitionType.PageCurlSingle:
		case TransitionType.Airplane:
		case TransitionType.Origami:
			return true;
		}
	}
}
