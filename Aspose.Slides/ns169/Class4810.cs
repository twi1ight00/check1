using System;
using System.Drawing;
using ns161;
using ns166;
using ns167;
using ns224;

namespace ns169;

internal class Class4810
{
	private const float float_0 = 0.3f;

	private const float float_1 = 0.25f;

	private const float float_2 = 0.5f;

	internal const float float_3 = 0.65f;

	internal const float float_4 = 0.1f;

	internal const bool bool_0 = false;

	internal static bool smethod_0(Class4779 el1, Class4779 el2)
	{
		return smethod_5(el1, el2);
	}

	internal static bool smethod_1(Class4779 possibleSubPart, Class4784 textLine)
	{
		double num = Class4778.smethod_11(possibleSubPart, textLine);
		if (!(num > 0.30000001192092896))
		{
			return false;
		}
		return true;
	}

	internal static bool smethod_2(Class4779 mainLineEl, Class4779 subscriptEl, Class4786 sourceSpace)
	{
		if (mainLineEl != null && subscriptEl != null && sourceSpace != null)
		{
			bool result = true;
			RectangleF region = RectangleF.Union(mainLineEl.BoundingBox, subscriptEl.BoundingBox);
			Class4846 @class = sourceSpace.method_9(region, 0.1f);
			if (@class.Count > 2)
			{
				result = false;
			}
			return result;
		}
		return false;
	}

	internal static bool smethod_3(Class4779 mainLineEl, Class4779 subscriptEl)
	{
		if (mainLineEl != null && subscriptEl != null && subscriptEl != null)
		{
			bool result = false;
			if (mainLineEl.FontSize >= subscriptEl.FontSize && Class4778.smethod_7(mainLineEl, subscriptEl) < 0.6499999761581421 && Class4778.smethod_9(mainLineEl, subscriptEl) < 0.6499999761581421)
			{
				double num = Class4778.smethod_11(mainLineEl, subscriptEl);
				double num2 = Class4778.smethod_13(mainLineEl, subscriptEl);
				if (num >= 0.5 && num2 >= 0.5)
				{
					result = false;
				}
				else if (num > 0.30000001192092896 && num2 < 0.25)
				{
					result = true;
				}
			}
			return result;
		}
		return false;
	}

	internal static bool smethod_4(Class4779 el1, Class4779 el2)
	{
		Class4791 @class = el1 as Class4791;
		Class4791 class2 = el2 as Class4791;
		if (@class != null && class2 != null)
		{
			Class5999 apsGlyphFont = @class.ApsGlyphFont;
			Class5999 apsGlyphFont2 = class2.ApsGlyphFont;
			if (apsGlyphFont != null && apsGlyphFont2 != null)
			{
				return Math.Max(apsGlyphFont.SizePoints, apsGlyphFont2.SizePoints) / Math.Min(apsGlyphFont.SizePoints, apsGlyphFont2.SizePoints) < 1.5f;
			}
			return apsGlyphFont == apsGlyphFont2;
		}
		return @class == class2;
	}

	internal static bool smethod_5(Class4779 el1, Class4779 el2)
	{
		Class5999 @class = null;
		if (el2 is Class4791 class2)
		{
			@class = class2.Font;
		}
		if (smethod_4(el1, el2))
		{
			return Class4778.smethod_7(el1, el2) < (double)((@class == null) ? Class4860.Instance.RelativeHorizontalProximity : Class4778.smethod_41(@class));
		}
		return false;
	}
}
