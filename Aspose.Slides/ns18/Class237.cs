using System;
using Aspose.Slides;
using Aspose.Slides.SlideShow;
using ns56;

namespace ns18;

internal class Class237
{
	public static void smethod_0(ISlideShowTransition slideShowTransition, Class1366 presetTransitionElementData)
	{
		if (presetTransitionElementData != null)
		{
			switch (presetTransitionElementData.Prst)
			{
			case "fallOver":
				slideShowTransition.Type = TransitionType.FallOver;
				((LeftRightDirectionTransition)slideShowTransition.Value).Direction = (presetTransitionElementData.InvX ? TransitionLeftRightDirectionType.Right : TransitionLeftRightDirectionType.Left);
				break;
			case "drape":
				slideShowTransition.Type = TransitionType.Drape;
				((LeftRightDirectionTransition)slideShowTransition.Value).Direction = (presetTransitionElementData.InvX ? TransitionLeftRightDirectionType.Right : TransitionLeftRightDirectionType.Left);
				break;
			case "curtains":
				slideShowTransition.Type = TransitionType.Curtains;
				break;
			case "wind":
				slideShowTransition.Type = TransitionType.Wind;
				((LeftRightDirectionTransition)slideShowTransition.Value).Direction = ((!presetTransitionElementData.InvX) ? TransitionLeftRightDirectionType.Right : TransitionLeftRightDirectionType.Left);
				break;
			case "prestige":
				slideShowTransition.Type = TransitionType.Prestige;
				break;
			case "fracture":
				slideShowTransition.Type = TransitionType.Fracture;
				break;
			case "crush":
				slideShowTransition.Type = TransitionType.Crush;
				break;
			case "peelOff":
				slideShowTransition.Type = TransitionType.PeelOff;
				((LeftRightDirectionTransition)slideShowTransition.Value).Direction = (presetTransitionElementData.InvX ? TransitionLeftRightDirectionType.Right : TransitionLeftRightDirectionType.Left);
				break;
			case "pageCurlDouble":
				slideShowTransition.Type = TransitionType.PageCurlDouble;
				((LeftRightDirectionTransition)slideShowTransition.Value).Direction = (presetTransitionElementData.InvX ? TransitionLeftRightDirectionType.Right : TransitionLeftRightDirectionType.Left);
				break;
			case "pageCurlSingle":
				slideShowTransition.Type = TransitionType.PageCurlSingle;
				((LeftRightDirectionTransition)slideShowTransition.Value).Direction = (presetTransitionElementData.InvX ? TransitionLeftRightDirectionType.Right : TransitionLeftRightDirectionType.Left);
				break;
			case "airplane":
				slideShowTransition.Type = TransitionType.Airplane;
				((LeftRightDirectionTransition)slideShowTransition.Value).Direction = ((!presetTransitionElementData.InvX) ? TransitionLeftRightDirectionType.Right : TransitionLeftRightDirectionType.Left);
				break;
			case "origami":
				slideShowTransition.Type = TransitionType.Origami;
				((LeftRightDirectionTransition)slideShowTransition.Value).Direction = ((!presetTransitionElementData.InvX) ? TransitionLeftRightDirectionType.Right : TransitionLeftRightDirectionType.Left);
				break;
			default:
				throw new ArgumentException("Unknown preset \"" + presetTransitionElementData.Prst + "\"");
			}
		}
	}

	public static void smethod_1(ISlideShowTransition slideShowTransition, Class1366 presetTransitionElementData)
	{
		switch (slideShowTransition.Type)
		{
		default:
			throw new ArgumentException("Unknown preset transition type \"" + presetTransitionElementData.Prst + "\"");
		case TransitionType.FallOver:
			presetTransitionElementData.Prst = "fallOver";
			presetTransitionElementData.InvX = ((LeftRightDirectionTransition)slideShowTransition.Value).Direction == TransitionLeftRightDirectionType.Right;
			break;
		case TransitionType.Drape:
			presetTransitionElementData.Prst = "drape";
			presetTransitionElementData.InvX = ((LeftRightDirectionTransition)slideShowTransition.Value).Direction == TransitionLeftRightDirectionType.Right;
			break;
		case TransitionType.Curtains:
			presetTransitionElementData.Prst = "curtains";
			break;
		case TransitionType.Wind:
			presetTransitionElementData.Prst = "wind";
			presetTransitionElementData.InvX = ((LeftRightDirectionTransition)slideShowTransition.Value).Direction == TransitionLeftRightDirectionType.Left;
			break;
		case TransitionType.Prestige:
			presetTransitionElementData.Prst = "prestige";
			break;
		case TransitionType.Fracture:
			presetTransitionElementData.Prst = "fracture";
			break;
		case TransitionType.Crush:
			presetTransitionElementData.Prst = "crush";
			break;
		case TransitionType.PeelOff:
			presetTransitionElementData.Prst = "peelOff";
			presetTransitionElementData.InvX = ((LeftRightDirectionTransition)slideShowTransition.Value).Direction == TransitionLeftRightDirectionType.Right;
			break;
		case TransitionType.PageCurlDouble:
			presetTransitionElementData.Prst = "pageCurlDouble";
			presetTransitionElementData.InvX = ((LeftRightDirectionTransition)slideShowTransition.Value).Direction == TransitionLeftRightDirectionType.Right;
			break;
		case TransitionType.PageCurlSingle:
			presetTransitionElementData.Prst = "pageCurlSingle";
			presetTransitionElementData.InvX = ((LeftRightDirectionTransition)slideShowTransition.Value).Direction == TransitionLeftRightDirectionType.Right;
			break;
		case TransitionType.Airplane:
			presetTransitionElementData.Prst = "airplane";
			presetTransitionElementData.InvX = ((LeftRightDirectionTransition)slideShowTransition.Value).Direction == TransitionLeftRightDirectionType.Left;
			break;
		case TransitionType.Origami:
			presetTransitionElementData.Prst = "origami";
			presetTransitionElementData.InvX = ((LeftRightDirectionTransition)slideShowTransition.Value).Direction == TransitionLeftRightDirectionType.Left;
			break;
		}
	}
}
