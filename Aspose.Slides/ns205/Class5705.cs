using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using ns175;
using ns186;
using ns187;
using ns195;

namespace ns205;

internal class Class5705
{
	public static int int_0 = 0;

	public static int int_1 = 1;

	public static int int_2 = 2;

	public int int_3;

	public Color color_0;

	public int int_4;

	public int int_5;

	internal Class5702 class5702_0;

	public Class5705(int style, int width, Color color, int mode, Class5702 borderRadiuses)
	{
		int_3 = style;
		int_4 = width;
		color_0 = color;
		int_5 = mode;
		class5702_0 = borderRadiuses;
	}

	public Class5705(string style, int width, Color color, int mode, Class5702 borderRadiuses)
		: this(smethod_1(style), width, color, mode, borderRadiuses)
	{
	}

	public static int smethod_0(Class5705 bp)
	{
		if (bp != null && bp.int_5 != int_0)
		{
			return bp.int_4 / 2;
		}
		return 0;
	}

	private string method_0()
	{
		return Class5443.smethod_1(int_3).method_0();
	}

	private static int smethod_1(string style)
	{
		return Class5443.smethod_0(style).method_1();
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj == this)
		{
			return true;
		}
		if (obj is Class5705)
		{
			Class5705 @class = (Class5705)obj;
			if (int_3 == @class.int_3 && color_0.Equals(@class.color_0) && int_4 == @class.int_4)
			{
				return int_5 == @class.int_5;
			}
			return false;
		}
		return false;
	}

	public static Class5705 smethod_2(Class5738 foUserAgent, string s)
	{
		if (s.StartsWith("(") && s.EndsWith(")"))
		{
			s = Class5479.smethod_0(s, 1, s.Length - 1);
			Match match = Regex.Match(s, "([^,\\(]+(?:\\(.*\\))?)", RegexOptions.IgnoreCase);
			string value = match.Groups[1].Value;
			match = Regex.Match(match.Groups[2].Value, "([^,\\(]+(?:\\(.*\\))?)", RegexOptions.IgnoreCase);
			string value2 = match.Groups[1].Value;
			match = Regex.Match(match.Groups[2].Value, "([^,\\(]+(?:\\(.*\\))?)", RegexOptions.IgnoreCase);
			int width = int.Parse(match.Groups[1].Value);
			match = Regex.Match(match.Groups[2].Value, "([^,\\(]+(?:\\(.*\\))?)", RegexOptions.IgnoreCase);
			int mode = int_0;
			if (match.Success)
			{
				string text = match.Groups[1].Value.ToLower();
				if (text == "collapse-inner")
				{
					mode = int_1;
				}
				else if (text == "collapse-outer")
				{
					mode = int_2;
				}
			}
			Color color;
			try
			{
				color = Class5713.smethod_0(foUserAgent, value2);
			}
			catch (Exception55 exception)
			{
				throw new ArgumentException(exception.vmethod_0());
			}
			return new Class5705(value, width, color, mode, null);
		}
		throw new ArgumentException("BorderProps must be surrounded by parentheses");
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('(');
		stringBuilder.Append(method_0());
		stringBuilder.Append(',');
		stringBuilder.Append(Class5713.smethod_10(color_0));
		stringBuilder.Append(',');
		stringBuilder.Append(int_4);
		if (int_5 != int_0)
		{
			stringBuilder.Append(',');
			if (int_5 == int_1)
			{
				stringBuilder.Append("collapse-inner");
			}
			else
			{
				stringBuilder.Append("collapse-outer");
			}
		}
		stringBuilder.Append(')');
		return stringBuilder.ToString();
	}
}
