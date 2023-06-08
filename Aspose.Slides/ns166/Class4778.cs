using System;
using System.Drawing;
using ns161;
using ns167;
using ns218;
using ns224;
using ns271;

namespace ns166;

internal class Class4778
{
	internal const float float_0 = 2f;

	internal const float float_1 = 0.3f;

	internal const float float_2 = 0.025f;

	internal const float float_3 = 0.75f;

	internal const float float_4 = 0.05f;

	internal const float float_5 = 0.15f;

	internal const float float_6 = 0.95f;

	internal const float float_7 = 0.75f;

	internal const float float_8 = 0.3f;

	internal const float float_9 = 0.3f;

	internal const float float_10 = 1.05f;

	internal const float float_11 = 0.35f;

	private static readonly Class5971 class5971_0 = new Class5971();

	internal static bool smethod_0(float x, float y)
	{
		return smethod_1(x, y, 0.02500000037252903);
	}

	internal static bool smethod_1(double x, double y, double epsilon)
	{
		return Math.Abs(x - y) <= epsilon;
	}

	internal static double smethod_2(PointF from, PointF to)
	{
		double num = 0.0;
		num += Math.Pow(from.X - to.X, 2.0);
		num += Math.Pow(from.Y - to.Y, 2.0);
		return Math.Sqrt(num);
	}

	internal static double smethod_3(PointF from, PointF to)
	{
		double x = to.X - from.X;
		double y = to.Y - from.Y;
		return Math.Atan2(y, x);
	}

	internal static float smethod_4(RectangleF rect)
	{
		return rect.Width * rect.Height;
	}

	internal static bool smethod_5(RectangleF rect1, RectangleF rect2, float fontSize)
	{
		return RectangleF.Intersect(rect1, rect2).Height > fontSize * 0.75f;
	}

	internal static double smethod_6(RectangleF rect1, RectangleF rect2, double meanFontSize)
	{
		double val = Math.Min(Math.Abs(rect1.Left - rect2.Left), Math.Abs(rect1.Left - rect2.Right));
		val = Math.Min(val, Math.Abs(rect1.Right - rect2.Left));
		val = Math.Min(val, Math.Abs(rect1.Right - rect2.Right));
		return val / meanFontSize;
	}

	internal static double smethod_7(Class4779 text1, Class4779 text2)
	{
		if (text1 != null && text2 != null)
		{
			return smethod_6(text1.BoundingBox, text2.BoundingBox, smethod_43(text1, text2));
		}
		return 0.0;
	}

	internal static double smethod_8(RectangleF rect1, RectangleF rect2, double meanFontSize)
	{
		double val = Math.Min(Math.Abs(rect1.Top - rect2.Top), Math.Abs(rect1.Top - rect2.Bottom));
		val = Math.Min(val, Math.Abs(rect1.Bottom - rect2.Top));
		val = Math.Min(val, Math.Abs(rect1.Bottom - rect2.Bottom));
		return val / meanFontSize;
	}

	internal static double smethod_9(Class4779 text1, Class4779 text2)
	{
		if (text1 != null && text2 != null)
		{
			return smethod_8(text1.BoundingBox, text2.BoundingBox, smethod_43(text1, text2));
		}
		return 0.0;
	}

	internal static bool smethod_10(Class4779 text1, Class4779 text2)
	{
		return smethod_13(text1, text2) == 1f;
	}

	internal static float smethod_11(Class4779 text1, Class4779 text2)
	{
		if (text1 != null && text2 != null)
		{
			return smethod_12(text1.BoundingBox, text2.BoundingBox);
		}
		return 0f;
	}

	internal static float smethod_12(RectangleF el1, RectangleF el2)
	{
		float result = 0f;
		if (!el1.IsEmpty && !el2.IsEmpty)
		{
			if (smethod_0(el1.Y, el2.Y))
			{
				result = ((el1.Height <= el2.Height) ? 1f : (el2.Height / el1.Height));
			}
			else
			{
				RectangleF rectangleF;
				RectangleF rectangleF2;
				bool flag;
				if (el1.Y < el2.Y)
				{
					rectangleF = el1;
					rectangleF2 = el2;
					flag = true;
				}
				else
				{
					rectangleF = el2;
					rectangleF2 = el1;
					flag = false;
				}
				float num = rectangleF.Bottom - rectangleF2.Top;
				if (num > 0f)
				{
					result = ((!(num > rectangleF2.Height)) ? (num / el1.Height) : (flag ? (el2.Height / el1.Height) : 1f));
				}
			}
			return result;
		}
		return result;
	}

	internal static float smethod_13(Class4779 text1, Class4779 text2)
	{
		if (text1 != null && text2 != null)
		{
			return smethod_14(text1.BoundingBox, text2.BoundingBox);
		}
		return 0f;
	}

	internal static float smethod_14(RectangleF el1, RectangleF el2)
	{
		float result = 0f;
		if (!el1.IsEmpty && !el2.IsEmpty)
		{
			if (smethod_0(el1.X, el2.X))
			{
				result = ((el1.Width <= el2.Width) ? 1f : (el2.Width / el1.Width));
			}
			else
			{
				RectangleF rectangleF;
				RectangleF rectangleF2;
				bool flag;
				if (el1.X < el2.X)
				{
					rectangleF = el1;
					rectangleF2 = el2;
					flag = true;
				}
				else
				{
					rectangleF = el2;
					rectangleF2 = el1;
					flag = false;
				}
				float num = rectangleF.Right - rectangleF2.Left;
				if (num > 0f)
				{
					result = ((!(num > rectangleF2.Width)) ? (num / el1.Width) : (flag ? (el2.Width / el1.Width) : 1f));
				}
			}
			return result;
		}
		return result;
	}

	internal static bool smethod_15(Class4779 testedEl, Class4779 mainEl)
	{
		if (testedEl != null && mainEl != null)
		{
			float num = smethod_13(testedEl, mainEl);
			float num2 = smethod_11(testedEl, mainEl);
			return num * num2 >= 0.05f;
		}
		return false;
	}

	internal static bool smethod_16(RectangleF testedEl, RectangleF mainEl)
	{
		float num = smethod_14(testedEl, mainEl);
		float num2 = smethod_12(testedEl, mainEl);
		return num * num2 >= 0.05f;
	}

	internal static bool smethod_17(Class4779 testedEl, Class4779 mainEl)
	{
		float num = smethod_13(mainEl, testedEl);
		return num > 0.95f;
	}

	internal static bool smethod_18(RectangleF testedEl, RectangleF mainEl)
	{
		float num = smethod_14(mainEl, testedEl);
		return num > 0.95f;
	}

	internal static bool smethod_19(Class4779 testedEl, Class4779 mainEl)
	{
		float num = smethod_13(mainEl, testedEl);
		return num > 0.75f;
	}

	internal static bool smethod_20(RectangleF testedEl, RectangleF mainEl)
	{
		float num = smethod_14(mainEl, testedEl);
		return num > 0.75f;
	}

	internal static bool smethod_21(Class4779 testedEl, Class4779 mainEl)
	{
		float num = smethod_11(mainEl, testedEl);
		return num > 0.75f;
	}

	internal static bool smethod_22(RectangleF testedEl, RectangleF mainEl)
	{
		float num = smethod_12(mainEl, testedEl);
		return num > 0.75f;
	}

	internal static bool smethod_23(Class4779 testedEl, Class4779 mainEl)
	{
		float num = smethod_13(testedEl, mainEl);
		return num < 0.05f;
	}

	internal static bool smethod_24(RectangleF testedEl, RectangleF mainEl)
	{
		float num = smethod_14(testedEl, mainEl);
		return num < 0.05f;
	}

	internal static bool smethod_25(Class4779 testedEl, Class4779 mainEl)
	{
		float num = smethod_11(testedEl, mainEl);
		return num < 0.05f;
	}

	internal static bool smethod_26(RectangleF testedEl, RectangleF mainEl)
	{
		float num = smethod_12(testedEl, mainEl);
		return num < 0.05f;
	}

	internal static bool smethod_27(Class4779 el1, Class4779 el2)
	{
		if (smethod_21(el1, el2))
		{
			return smethod_21(el2, el1);
		}
		return false;
	}

	internal static bool smethod_28(Class4779 el1, Class4779 el2)
	{
		if (smethod_17(el1, el2))
		{
			return smethod_17(el2, el1);
		}
		return false;
	}

	internal static bool smethod_29(Class4779 el)
	{
		if (el == null)
		{
			return false;
		}
		return el.BoundingBox.Height > 2f * el.FontSize;
	}

	internal static bool smethod_30(Class4779 el)
	{
		if (el == null)
		{
			return false;
		}
		if (!(el.BoundingBox.Width > 0f))
		{
			return false;
		}
		return el.BoundingBox.Height / el.BoundingBox.Width > 1.05f;
	}

	internal static float smethod_31(Class4779 el)
	{
		if (el == null)
		{
			return 0f;
		}
		if (el.FontSize == 0f)
		{
			return 0f;
		}
		return el.BoundingBox.Height / el.FontSize;
	}

	internal static bool smethod_32(Class4779 el1, Class4779 el2)
	{
		if (!(smethod_9(el1, el2) <= 0.30000001192092896))
		{
			return smethod_34(el1, el2);
		}
		return true;
	}

	internal static bool smethod_33(Class4779 el1, Class4779 el2)
	{
		return smethod_13(el1, el2) > 0f;
	}

	internal static bool smethod_34(Class4779 el1, Class4779 el2)
	{
		return smethod_11(el1, el2) > 0f;
	}

	internal static bool smethod_35(float fontSize1, float fontSize2)
	{
		return Math.Abs(fontSize1 - fontSize2) < 1f;
	}

	internal static bool smethod_36(Class4779 el1, Class4779 el2)
	{
		if (el1 != null && el2 != null)
		{
			return smethod_35(el1.FontSize, el2.FontSize);
		}
		return false;
	}

	internal static bool smethod_37(Class4779 testedEl, Class4779 mainEl)
	{
		if (smethod_38(testedEl, mainEl))
		{
			return smethod_39(testedEl, mainEl);
		}
		return false;
	}

	internal static bool smethod_38(Class4779 testedEl, Class4779 mainEl)
	{
		return smethod_13(testedEl, mainEl) > 0.75f;
	}

	internal static bool smethod_39(Class4779 testedEl, Class4779 mainEl)
	{
		return smethod_11(testedEl, mainEl) > 0.75f;
	}

	internal static bool smethod_40(Class4779 el)
	{
		if (el == null)
		{
			return false;
		}
		return el.BoundingBox.Width / el.BoundingBox.Height > 2f;
	}

	internal static float smethod_41(Class5999 font)
	{
		if (font == null)
		{
			return 0f;
		}
		try
		{
			if (Class4860.Instance.WhitSpaceSizes.ContainsKey(font))
			{
				return Class4860.Instance.WhitSpaceSizes[font];
			}
			float num = class5971_0.method_1(" ", font).Width * 0.35f;
			Class4860.Instance.WhitSpaceSizes[font] = num;
			return num;
		}
		catch (Exception)
		{
			Class5999 font2 = Class6652.Instance.method_1(font.FamilyName, font.SizePoints, FontStyle.Regular);
			float num2 = class5971_0.method_1(" ", font2).Width * 0.35f;
			Class4860.Instance.WhitSpaceSizes[font] = num2;
			return num2;
		}
	}

	internal static double smethod_42(float fontSize1, float fontSize2)
	{
		double num = ((fontSize1 == 0f) ? 1f : fontSize1);
		double num2 = ((fontSize1 == 0f) ? 1f : fontSize2);
		if (num + num2 != 0.0)
		{
			return (num + num2) / 2.0;
		}
		return 1.0;
	}

	private static double smethod_43(Class4779 text1, Class4779 text2)
	{
		if (text1 != null && text2 != null)
		{
			return smethod_42(text1.FontSize, text2.FontSize);
		}
		return 0.0;
	}
}
