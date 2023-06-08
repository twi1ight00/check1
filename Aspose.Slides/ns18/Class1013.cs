using System.Collections.Generic;
using Aspose.Slides.Animation;
using ns27;
using ns56;
using ns57;

namespace ns18;

internal class Class1013
{
	private static SortedList<FilterEffectType, string> sortedList_0;

	private static SortedList<FilterEffectSubtype, string> sortedList_1;

	public static void smethod_0(IFilterEffect filterEffect, Class2267 animateEffectBehaviorElementData)
	{
		Class362 pPTXUnsupportedProps = ((FilterEffect)filterEffect).PPTXUnsupportedProps;
		filterEffect.Reveal = (FilterEffectRevealType)animateEffectBehaviorElementData.Transition;
		pPTXUnsupportedProps.PrList = animateEffectBehaviorElementData.PrLst;
		filterEffect.Type = smethod_2(animateEffectBehaviorElementData.Filter);
		filterEffect.Subtype = smethod_3(animateEffectBehaviorElementData.Filter);
	}

	public static void smethod_1(IFilterEffect filterEffect, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		Class362 pPTXUnsupportedProps = ((FilterEffect)filterEffect).PPTXUnsupportedProps;
		Class2267 @class = (Class2267)addNodeDelegate("animEffect").Object;
		commonBehaviorElementData = @class.CBhvr;
		@class.Transition = (Enum281)filterEffect.Reveal;
		@class.PrLst = pPTXUnsupportedProps.PrList;
		string text = "";
		text = ((filterEffect.Subtype != 0) ? (sortedList_0[filterEffect.Type] + '(' + sortedList_1[filterEffect.Subtype] + ')') : sortedList_0[filterEffect.Type]);
		@class.Filter = text;
	}

	private static FilterEffectType smethod_2(string filter)
	{
		if (filter == null)
		{
			return FilterEffectType.None;
		}
		string text = filter.Trim();
		int num = text.IndexOf('(');
		if (num == -1)
		{
			return sortedList_0.Keys[sortedList_0.IndexOfValue(text)];
		}
		text = text.Substring(0, num);
		return sortedList_0.Keys[sortedList_0.IndexOfValue(text)];
	}

	private static FilterEffectSubtype smethod_3(string filter)
	{
		if (filter == null)
		{
			return FilterEffectSubtype.None;
		}
		string text = filter.Trim();
		int num = text.IndexOf('(');
		if (num == -1)
		{
			return FilterEffectSubtype.None;
		}
		int num2 = text.IndexOf(')');
		text = text.Substring(num + 1, num2 - num - 1);
		return sortedList_1.Keys[sortedList_1.IndexOfValue(text)];
	}

	static Class1013()
	{
		sortedList_0 = new SortedList<FilterEffectType, string>();
		sortedList_1 = new SortedList<FilterEffectSubtype, string>();
		sortedList_0.Add(FilterEffectType.None, "");
		sortedList_0.Add(FilterEffectType.Barn, "barn");
		sortedList_0.Add(FilterEffectType.Blinds, "blinds");
		sortedList_0.Add(FilterEffectType.Box, "box");
		sortedList_0.Add(FilterEffectType.Checkerboard, "checkerboard");
		sortedList_0.Add(FilterEffectType.Circle, "circle");
		sortedList_0.Add(FilterEffectType.Diamond, "diamond");
		sortedList_0.Add(FilterEffectType.Dissolve, "dissolve");
		sortedList_0.Add(FilterEffectType.Fade, "fade");
		sortedList_0.Add(FilterEffectType.Image, "image");
		sortedList_0.Add(FilterEffectType.Pixelate, "pixelate");
		sortedList_0.Add(FilterEffectType.Plus, "plus");
		sortedList_0.Add(FilterEffectType.RandomBar, "randombar");
		sortedList_0.Add(FilterEffectType.Slide, "slide");
		sortedList_0.Add(FilterEffectType.Stretch, "stretch");
		sortedList_0.Add(FilterEffectType.Strips, "strips");
		sortedList_0.Add(FilterEffectType.Wedge, "wedge");
		sortedList_0.Add(FilterEffectType.Wheel, "wheel");
		sortedList_0.Add(FilterEffectType.Wipe, "wipe");
		sortedList_1.Add(FilterEffectSubtype.None, "");
		sortedList_1.Add(FilterEffectSubtype.Across, "across");
		sortedList_1.Add(FilterEffectSubtype.Down, "down");
		sortedList_1.Add(FilterEffectSubtype.DownLeft, "downLeft");
		sortedList_1.Add(FilterEffectSubtype.DownRight, "downRight");
		sortedList_1.Add(FilterEffectSubtype.FromBottom, "fromBottom");
		sortedList_1.Add(FilterEffectSubtype.FromLeft, "fromLeft");
		sortedList_1.Add(FilterEffectSubtype.FromRight, "fromRight");
		sortedList_1.Add(FilterEffectSubtype.FromTop, "fromTop");
		sortedList_1.Add(FilterEffectSubtype.Horizontal, "horizontal");
		sortedList_1.Add(FilterEffectSubtype.In, "in");
		sortedList_1.Add(FilterEffectSubtype.InHorizontal, "inHorizontal");
		sortedList_1.Add(FilterEffectSubtype.InVertical, "inVertical");
		sortedList_1.Add(FilterEffectSubtype.Left, "left");
		sortedList_1.Add(FilterEffectSubtype.Out, "out");
		sortedList_1.Add(FilterEffectSubtype.OutHorizontal, "outHorizontal");
		sortedList_1.Add(FilterEffectSubtype.OutVertical, "outVertical");
		sortedList_1.Add(FilterEffectSubtype.Right, "right");
		sortedList_1.Add(FilterEffectSubtype.Spokes1, "1");
		sortedList_1.Add(FilterEffectSubtype.Spokes2, "2");
		sortedList_1.Add(FilterEffectSubtype.Spokes3, "3");
		sortedList_1.Add(FilterEffectSubtype.Spokes4, "4");
		sortedList_1.Add(FilterEffectSubtype.Spokes8, "8");
		sortedList_1.Add(FilterEffectSubtype.Up, "up");
		sortedList_1.Add(FilterEffectSubtype.UpLeft, "upLeft");
		sortedList_1.Add(FilterEffectSubtype.UpRight, "upRight");
		sortedList_1.Add(FilterEffectSubtype.Vertical, "vertical");
	}
}
