using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Warnings;
using ns16;
using ns56;
using ns57;
using ns63;

namespace ns15;

internal class Class216
{
	public static void smethod_0(Class2266 timeNodeAnimateColorBehavior, Class2651 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer.TimeColorBehavior == null)
		{
			throw new InvalidOperationException();
		}
		Class2655 timeColorBehavior = timeNodeContainer.TimeColorBehavior;
		Class222.smethod_0(timeNodeAnimateColorBehavior.CBhvr, timeNodeContainer, timeColorBehavior.Behavior, deserializationContext);
		smethod_2(timeNodeAnimateColorBehavior, timeColorBehavior, deserializationContext);
	}

	public static void smethod_1(Class2266 timeNodeAnimateColorBehavior, Class2650 timeNodeContainer, Class854 deserializationContext)
	{
		if (timeNodeContainer.TimeColorBehavior == null)
		{
			throw new InvalidOperationException();
		}
		Class2655 timeColorBehavior = timeNodeContainer.TimeColorBehavior;
		Class222.smethod_1(timeNodeAnimateColorBehavior.CBhvr, timeNodeContainer, timeColorBehavior.Behavior, deserializationContext);
		smethod_2(timeNodeAnimateColorBehavior, timeColorBehavior, deserializationContext);
	}

	private static void smethod_2(Class2266 timeNodeAnimateColorBehavior, Class2655 timeColorBehavior, Class854 deserializationContext)
	{
		if (timeColorBehavior == null)
		{
			throw new InvalidOperationException();
		}
		if (timeColorBehavior.ColorBehaviorAtom.FFromPropertyUsed)
		{
			Class1814 @class = timeNodeAnimateColorBehavior.delegate1321_0();
			smethod_3(@class.delegate2773_0, timeColorBehavior.ColorBehaviorAtom.ColorFrom, deserializationContext);
		}
		if (timeColorBehavior.ColorBehaviorAtom.FToPropertyUsed)
		{
			Class1814 class2 = timeNodeAnimateColorBehavior.delegate1321_1();
			smethod_3(class2.delegate2773_0, timeColorBehavior.ColorBehaviorAtom.ColorTo, deserializationContext);
		}
	}

	private static void smethod_3(Class2605.Delegate2773 addColorDelegate, Class2937 color, Class854 deserializationContext)
	{
		switch (color.Model)
		{
		case 0u:
		{
			Class1926 class2 = (Class1926)addColorDelegate("srgbClr").Object;
			class2.Val = smethod_4(color);
			break;
		}
		default:
			throw new NotImplementedException();
		case 2u:
		{
			Class1917 @class = (Class1917)addColorDelegate("schemeClr").Object;
			@class.Val = SchemeColor.Background1;
			deserializationContext.DeserializationContext.method_4("Color scheme is not parsed.", WarningType.DataLoss);
			break;
		}
		}
	}

	private static uint smethod_4(Class2937 color)
	{
		int num = Color.FromArgb(color.Value1, color.Value2, color.Value3).ToArgb();
		num &= 0xFFFFFF;
		return checked((uint)num);
	}

	public static void smethod_5(Class2266 animateColorBehaviorElementData, Class2650 timeNodeContainer, Class234 timelineSerializationContext)
	{
		if (animateColorBehaviorElementData != null)
		{
			if (timeNodeContainer == null)
			{
				throw new InvalidOperationException();
			}
			Class2655 @class = new Class2655();
			timeNodeContainer.Records.Add(@class);
			smethod_6(animateColorBehaviorElementData, @class, timelineSerializationContext);
			smethod_7(animateColorBehaviorElementData, @class, timelineSerializationContext);
		}
	}

	private static void smethod_6(Class2266 animateColorBehaviorElementData, Class2655 timeColorBehaviorContainer, Class234 timelineSerializationContext)
	{
		if (animateColorBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeColorBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2748 @class = new Class2748();
		timeColorBehaviorContainer.Records.Add(@class);
		if (animateColorBehaviorElementData.By != null)
		{
			@class.FByPropertyUsed = true;
			if (animateColorBehaviorElementData.By.ColorTransform == null)
			{
				throw new InvalidOperationException();
			}
			if (animateColorBehaviorElementData.By.ColorTransform.Name == "rgb")
			{
				Class1776 class2 = (Class1776)animateColorBehaviorElementData.By.ColorTransform.Object;
				Class2937 colorBy = new Class2937(0u, Class225.smethod_17(class2.R), Class225.smethod_17(class2.G), Class225.smethod_17(class2.B));
				@class.ColorBy = colorBy;
			}
			else
			{
				timelineSerializationContext.method_3("Writing of the animation color behavior failed.", WarningType.DataLoss);
			}
		}
		else
		{
			@class.FByPropertyUsed = false;
		}
		if (animateColorBehaviorElementData.From != null)
		{
			@class.FFromPropertyUsed = true;
			if (animateColorBehaviorElementData.From.Color == null)
			{
				throw new InvalidOperationException();
			}
			if (animateColorBehaviorElementData.From.Color.Name == "srgbClr")
			{
				Color color = Color.FromArgb((int)(((Class1926)animateColorBehaviorElementData.From.Color.Object).Val &= 16777215u));
				Class2937 colorFrom = new Class2937(0u, color.R, color.G, color.B);
				@class.ColorFrom = colorFrom;
			}
			else
			{
				timelineSerializationContext.method_3("Writing of the animation color behavior failed.", WarningType.DataLoss);
			}
		}
		else
		{
			@class.FFromPropertyUsed = false;
		}
		if (animateColorBehaviorElementData.To != null)
		{
			@class.FToPropertyUsed = true;
			if (animateColorBehaviorElementData.To.Color == null)
			{
				throw new InvalidOperationException();
			}
			if (animateColorBehaviorElementData.To.Color.Name == "srgbClr")
			{
				Color color2 = Color.FromArgb((int)(((Class1926)animateColorBehaviorElementData.To.Color.Object).Val &= 16777215u));
				Class2937 colorTo = new Class2937(0u, color2.R, color2.G, color2.B);
				@class.ColorTo = colorTo;
			}
			else
			{
				timelineSerializationContext.method_3("Writing of the animation color behavior failed.", WarningType.DataLoss);
			}
		}
		else
		{
			@class.FToPropertyUsed = false;
		}
		if (animateColorBehaviorElementData.ClrSpc != Enum279.const_0)
		{
			@class.FColorSpacePropertyUsed = true;
		}
		else
		{
			@class.FColorSpacePropertyUsed = false;
		}
		if (animateColorBehaviorElementData.Dir != Enum280.const_0)
		{
			@class.FDirectionPropertyUsed = true;
		}
		else
		{
			@class.FDirectionPropertyUsed = false;
		}
	}

	private static void smethod_7(Class2266 animateColorBehaviorElementData, Class2655 timeColorBehaviorContainer, Class234 timelineSerializationContext)
	{
		if (animateColorBehaviorElementData == null)
		{
			throw new ArgumentNullException();
		}
		if (timeColorBehaviorContainer == null)
		{
			throw new ArgumentNullException();
		}
		Class2281 cBhvr = animateColorBehaviorElementData.CBhvr;
		Class2654 @class = new Class2654();
		timeColorBehaviorContainer.Records.Add(@class);
		Class222.smethod_5(cBhvr, @class);
		Class222.smethod_6(cBhvr, @class);
		Class2661 class2 = new Class2661();
		if (animateColorBehaviorElementData.ClrSpc != Enum279.const_0)
		{
			if (!timeColorBehaviorContainer.ColorBehaviorAtom.FColorSpacePropertyUsed)
			{
				throw new InvalidOperationException();
			}
			Class2763 item = new Class2763((animateColorBehaviorElementData.ClrSpc != 0) ? 1 : 0);
			class2.Records.Add(item);
		}
		if (animateColorBehaviorElementData.Dir != Enum280.const_0)
		{
			if (!timeColorBehaviorContainer.ColorBehaviorAtom.FDirectionPropertyUsed)
			{
				throw new InvalidOperationException();
			}
			Class2763 item2 = new Class2763((animateColorBehaviorElementData.Dir != 0) ? 1 : 0);
			class2.Records.Add(item2);
		}
		if (class2.Records.Count > 0)
		{
			@class.Records.Add(class2);
		}
		Class228.smethod_8(cBhvr.TgtEl, @class, timelineSerializationContext);
	}
}
