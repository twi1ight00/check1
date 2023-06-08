using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using ns284;
using ns305;

namespace ns301;

internal sealed class Class6969
{
	private const string string_0 = "(?<pix>[-+]?\\d*\\.?\\d+)(?<ed>pt|px|em|ex|in|cm|mm|pc|%)?";

	private const string string_1 = "pix";

	private const string string_2 = "ed";

	private const string string_3 = "auto";

	private const string string_4 = "inherit";

	internal static float[] float_0 = new float[10] { 16f, 19.5f, 22.5f, 27.5f, 33.5f, 39.5f, 48f, 56.5f, 68.5f, 83f };

	private static float float_1 = Graphics.FromImage(new Bitmap(1, 1)).DpiX;

	private Class6969()
	{
	}

	public static bool smethod_0(string value, ref float result, float size, ref Interface329 style)
	{
		if (Class6973.smethod_0(value))
		{
			throw new ArgumentNullException("value");
		}
		string input = value;
		if (value == "larger")
		{
			input = style.FontSize + "pt";
		}
		if (Regex.IsMatch(input, "(?<pix>[-+]?\\d*\\.?\\d+)(?<ed>pt|px|em|ex|in|cm|mm|pc|%)?"))
		{
			Match match = Regex.Match(input, "(?<pix>[-+]?\\d*\\.?\\d+)(?<ed>pt|px|em|ex|in|cm|mm|pc|%)?");
			string value2 = match.Groups["pix"].Value;
			object obj = Class6974.smethod_0(value2);
			if (obj == null)
			{
				return false;
			}
			result = (float)obj;
			switch (match.Groups["ed"].Value.ToLower(CultureInfo.InvariantCulture))
			{
			case "%":
				result = smethod_4(result, size);
				break;
			case "em":
				result = smethod_5(result, style.FontSize);
				break;
			case "px":
				result = smethod_6(result);
				break;
			}
			if (value == "larger")
			{
				style.FontLarger++;
				float num = 1f;
				num = ((style.FontLarger <= float_0.Length - 1) ? (float_0[style.FontLarger] / float_0[style.FontLarger - 1]) : 1.2f);
				result *= num;
			}
			return true;
		}
		return false;
	}

	public static bool smethod_1(string value, ref float result, float size, ref Interface329 style, Class6983 element)
	{
		Class6892.smethod_0(value, "value");
		string input = value;
		if (value == "larger")
		{
			input = style.FontSize + "pt";
		}
		if (Regex.IsMatch(input, "(?<pix>[-+]?\\d*\\.?\\d+)(?<ed>pt|px|em|ex|in|cm|mm|pc|%)?"))
		{
			Match match = Regex.Match(input, "(?<pix>[-+]?\\d*\\.?\\d+)(?<ed>pt|px|em|ex|in|cm|mm|pc|%)?");
			string value2 = match.Groups["pix"].Value;
			object obj = Class6974.smethod_0(value2);
			if (obj == null)
			{
				return false;
			}
			result = (float)obj;
			switch (match.Groups["ed"].Value.ToLower(CultureInfo.InvariantCulture))
			{
			case "%":
				result = smethod_4(result, size);
				break;
			case "em":
			{
				float size2 = size;
				if (element.ParentElement != null && element.ParentElement.NodeType == Enum969.const_0)
				{
					size2 = element.ParentElement.Style.FontSize;
				}
				result = smethod_5(result, size2);
				break;
			}
			case "px":
				result = smethod_6(result);
				break;
			}
			if (value == "larger")
			{
				style.FontLarger++;
				float num = 1f;
				num = ((style.FontLarger <= float_0.Length - 1) ? (float_0[style.FontLarger] / float_0[style.FontLarger - 1]) : 1.2f);
				result *= num;
			}
			return true;
		}
		return false;
	}

	public static bool smethod_2(string value, ref float result)
	{
		if (Class6973.smethod_0(value))
		{
			result = 0f;
			return false;
		}
		if (Regex.IsMatch(value, "(?<pix>[-+]?\\d*\\.?\\d+)(?<ed>pt|px|em|ex|in|cm|mm|pc|%)?"))
		{
			Match match = Regex.Match(value, "(?<pix>[-+]?\\d*\\.?\\d+)(?<ed>pt|px|em|ex|in|cm|mm|pc|%)?");
			string value2 = match.Groups["pix"].Value;
			object obj = Class6974.smethod_0(value2);
			if (obj == null)
			{
				return false;
			}
			result = (float)obj;
			switch (match.Groups["ed"].Value.ToLower(CultureInfo.InvariantCulture))
			{
			case "%":
				result = smethod_3(result);
				break;
			case "em":
				result = smethod_5(result, 0f);
				break;
			case "px":
				result = smethod_6(result);
				break;
			}
			return true;
		}
		return false;
	}

	public static float smethod_3(float val)
	{
		return (float)Math.Round(val / 100f * 12f, MidpointRounding.AwayFromZero);
	}

	public static float smethod_4(float val, float size)
	{
		return size * (val / 100f);
	}

	public static float smethod_5(float val, float size)
	{
		return val * size;
	}

	public static float smethod_6(float val)
	{
		return val * 0.75f;
	}

	public static IList smethod_7(string value)
	{
		IList list = new List<Class6959>();
		if (Class6973.smethod_0(value))
		{
			list.Add(new Class6959(isAuto: true));
			return list;
		}
		MatchCollection matchCollection = Regex.Matches(value, "(?<pix>[-+]?\\d*\\.?\\d+)(?<ed>pt|px|em|ex|in|cm|mm|pc|%)?");
		for (int i = 0; i < matchCollection.Count; i++)
		{
			Match match = matchCollection[i];
			if (match.Success)
			{
				Class6959 @class = new Class6959(0f, Enum955.const_0, isAuto: true, isInherit: false);
				string value2 = match.Groups["pix"].Value;
				object obj = Class6974.smethod_0(value2);
				if (obj == null)
				{
					list.Add(new Class6959(isAuto: true));
					continue;
				}
				float val = (float)obj;
				list.Add(match.Groups["ed"].Value.ToLower(CultureInfo.InvariantCulture) switch
				{
					"pt" => new Class6959(val, Enum955.const_0), 
					"em" => new Class6959(val, Enum955.const_1), 
					"ex" => new Class6959(val, Enum955.const_2), 
					"%" => new Class6959(val, Enum955.const_3), 
					"px" => new Class6959(val, Enum955.const_4), 
					"in" => new Class6959(val, Enum955.const_5), 
					"cm" => new Class6959(val, Enum955.const_6), 
					"mm" => new Class6959(val, Enum955.const_7), 
					"pc" => new Class6959(val, Enum955.const_4), 
					_ => new Class6959(val, Enum955.const_0), 
				});
			}
		}
		return list;
	}

	public static Class6959 smethod_8(string value)
	{
		if (Class6973.smethod_0(value))
		{
			return new Class6959(isAuto: true);
		}
		if (value.Equals("auto", StringComparison.OrdinalIgnoreCase))
		{
			return new Class6959(isAuto: true);
		}
		if (value.Equals("inherit", StringComparison.OrdinalIgnoreCase))
		{
			Class6959 @class = new Class6959(0f);
			@class.IsInherit = true;
			return @class;
		}
		IList list = smethod_7(value);
		if (list.Count == 0)
		{
			return new Class6959(isAuto: true);
		}
		return (Class6959)list[0];
	}

	public static float smethod_9(Class6959 value, float maxValue)
	{
		if (value.IsInherit)
		{
			return maxValue;
		}
		return value.Unit switch
		{
			Enum955.const_0 => value.Value, 
			Enum955.const_1 => value.Value * maxValue, 
			Enum955.const_2 => value.Value * maxValue / 2f, 
			Enum955.const_3 => maxValue * (value.Value / 100f), 
			Enum955.const_4 => value.Value * 72f / float_1, 
			Enum955.const_5 => value.Value * 72f, 
			Enum955.const_6 => (float)((double)value.Value * 28.3464567), 
			Enum955.const_7 => (float)((double)value.Value * 2.83464567), 
			Enum955.const_8 => value.Value * 12f, 
			_ => value.Value, 
		};
	}

	public static float smethod_10(Class6959 value)
	{
		return smethod_9(value, 12f);
	}

	public static float smethod_11(Class6959 value, float maxValue)
	{
		if (value.IsInherit)
		{
			return maxValue;
		}
		return value.Unit switch
		{
			Enum955.const_4 => value.Value, 
			Enum955.const_5 => value.Value * float_1 * float_1 / 72f, 
			Enum955.const_0 => value.Value * float_1 / 72f, 
			_ => value.Value, 
		};
	}

	public static float smethod_12(float value)
	{
		return value * float_1 / 72f;
	}

	public static float smethod_13(float value)
	{
		return value * 72f / float_1;
	}

	public static float smethod_14(Class6959 value)
	{
		return smethod_11(value, 12f);
	}

	public static float smethod_15(float point)
	{
		return point / (72f / float_1);
	}
}
