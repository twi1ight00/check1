using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;
using ns16;
using ns56;

namespace ns18;

internal class Class1010
{
	private static SortedList<PropertyType, string> sortedList_0;

	public static void smethod_0(IBehavior behavior, Class2605 behaviorNode, Class233 timelineDeserializationContext)
	{
		Class2281 @class = null;
		if (behavior is IColorEffect)
		{
			Class2266 class2 = behaviorNode.Object as Class2266;
			@class = class2.CBhvr;
			Class1011.smethod_0((IColorEffect)behavior, class2);
		}
		else if (behavior is ICommandEffect)
		{
			Class2280 class3 = behaviorNode.Object as Class2280;
			@class = class3.CBhvr;
			Class1012.smethod_0((ICommandEffect)behavior, class3, timelineDeserializationContext);
		}
		else if (behavior is IFilterEffect)
		{
			Class2267 class4 = behaviorNode.Object as Class2267;
			@class = class4.CBhvr;
			Class1013.smethod_0((IFilterEffect)behavior, behaviorNode.Object as Class2267);
		}
		else if (behavior is IMotionEffect)
		{
			Class2268 class5 = behaviorNode.Object as Class2268;
			@class = class5.CBhvr;
			Class245.smethod_0((IMotionEffect)behavior, class5);
		}
		else if (behavior is IPropertyEffect)
		{
			Class2265 class6 = behaviorNode.Object as Class2265;
			@class = class6.CBhvr;
			Class1015.smethod_0((IPropertyEffect)behavior, behaviorNode.Object as Class2265);
		}
		else if (behavior is IRotationEffect)
		{
			Class2269 class7 = behaviorNode.Object as Class2269;
			@class = class7.CBhvr;
			Class1017.smethod_0((IRotationEffect)behavior, behaviorNode.Object as Class2269);
		}
		else if (behavior is IScaleEffect)
		{
			Class2270 class8 = behaviorNode.Object as Class2270;
			@class = class8.CBhvr;
			Class1018.smethod_0((IScaleEffect)behavior, behaviorNode.Object as Class2270);
		}
		else
		{
			if (!(behavior is ISetEffect))
			{
				throw new Exception();
			}
			Class2293 class9 = behaviorNode.Object as Class2293;
			@class = class9.CBhvr;
			Class1020.smethod_0((ISetEffect)behavior, behaviorNode.Object as Class2293);
		}
		if (@class.AttrNameLst != null && @class.AttrNameLst.AttrNameList.Length > 0)
		{
			string[] attrNameList = @class.AttrNameLst.AttrNameList;
			foreach (string attr in attrNameList)
			{
				PropertyType item = smethod_3(attr);
				behavior.Properties.Add(item);
			}
		}
	}

	public static void smethod_1(IBehavior behavior, Class2605.Delegate2773 addNodeDelegate, ref Class2281 commonBehaviorElementData)
	{
		if (behavior is IColorEffect)
		{
			Class1011.smethod_1((IColorEffect)behavior, addNodeDelegate, ref commonBehaviorElementData);
		}
		else if (behavior is ICommandEffect)
		{
			Class1012.smethod_1((ICommandEffect)behavior, addNodeDelegate, ref commonBehaviorElementData);
		}
		else if (behavior is IFilterEffect)
		{
			Class1013.smethod_1((IFilterEffect)behavior, addNodeDelegate, ref commonBehaviorElementData);
		}
		else if (behavior is IMotionEffect)
		{
			Class245.smethod_1((IMotionEffect)behavior, addNodeDelegate, ref commonBehaviorElementData);
		}
		else if (behavior is IPropertyEffect)
		{
			Class1015.smethod_1((IPropertyEffect)behavior, addNodeDelegate, ref commonBehaviorElementData);
		}
		else if (behavior is IRotationEffect)
		{
			Class1017.smethod_1((IRotationEffect)behavior, addNodeDelegate, ref commonBehaviorElementData);
		}
		else if (behavior is IScaleEffect)
		{
			Class1018.smethod_1((IScaleEffect)behavior, addNodeDelegate, ref commonBehaviorElementData);
		}
		else
		{
			if (!(behavior is ISetEffect))
			{
				throw new Exception();
			}
			Class1020.smethod_1((ISetEffect)behavior, addNodeDelegate, ref commonBehaviorElementData);
		}
		smethod_2(behavior, ref commonBehaviorElementData);
	}

	private static void smethod_2(IBehavior behavior, ref Class2281 commonBehaviorDataElement)
	{
		if (behavior.Properties.Count <= 0)
		{
			return;
		}
		Class2276 @class = commonBehaviorDataElement.delegate2575_0();
		foreach (PropertyType property in behavior.Properties)
		{
			@class.method_3(sortedList_0[property]);
		}
	}

	internal static PropertyType smethod_3(string attr)
	{
		attr = attr.Trim();
		int num = sortedList_0.IndexOfValue(attr);
		if (num == -1)
		{
			throw new PptxException("value not found");
		}
		return sortedList_0.Keys[num];
	}

	static Class1010()
	{
		sortedList_0 = new SortedList<PropertyType, string>();
		sortedList_0.Add(PropertyType.NotDefined, "");
		sortedList_0.Add(PropertyType.Visibility, "style.visibility");
		sortedList_0.Add(PropertyType.Color, "style.color");
		sortedList_0.Add(PropertyType.ShapeFillColor, "fillcolor");
		sortedList_0.Add(PropertyType.ShapeFillColor2, "fillColor");
		sortedList_0.Add(PropertyType.ShapeFillOn, "fill.on");
		sortedList_0.Add(PropertyType.ShapeFillType, "fill.type");
		sortedList_0.Add(PropertyType.ShapeStrokeColor, "stroke.color");
		sortedList_0.Add(PropertyType.PptX, "ppt_x");
		sortedList_0.Add(PropertyType.PptY, "ppt_y");
		sortedList_0.Add(PropertyType.PptWidth, "ppt_w");
		sortedList_0.Add(PropertyType.PptHeight, "ppt_h");
		sortedList_0.Add(PropertyType.Rotation, "style.rotation");
		sortedList_0.Add(PropertyType.RotationPPT, "r");
		sortedList_0.Add(PropertyType.XShear, "xshear");
		sortedList_0.Add(PropertyType.TextFontSize, "style.fontSize");
		sortedList_0.Add(PropertyType.TextFontStyle, "style.fontStyle");
		sortedList_0.Add(PropertyType.TextFontWeight, "style.fontWeight");
		sortedList_0.Add(PropertyType.TextFontUnderline, "style.textDecorationUnderline");
		sortedList_0.Add(PropertyType.Opacity, "style.opacity");
		sortedList_0.Add(PropertyType.TextFontName, "style.fontFamily");
		sortedList_0.Add(PropertyType.StrokeOn, "stroke.on");
	}
}
