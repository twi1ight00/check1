using System;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Text;
using ns175;
using ns183;
using ns186;

namespace ns195;

internal class Class5713
{
	public const string string_0 = "#CMYK";

	public const string string_1 = "#Separation";

	private static Hashtable hashtable_0;

	static Class5713()
	{
		smethod_13();
	}

	private Class5713()
	{
	}

	public static Color smethod_0(Class5738 foUserAgent, string value)
	{
		if (value == null)
		{
			return Color.Empty;
		}
		Color color = Color.Empty;
		if (hashtable_0.Contains(value.ToLower()))
		{
			color = (Color)hashtable_0[value.ToLower()];
		}
		if (color.IsEmpty)
		{
			if (value.StartsWith("#"))
			{
				color = smethod_8(value);
			}
			else if (value.StartsWith("rgb("))
			{
				color = smethod_3(value);
			}
			else
			{
				if (value.StartsWith("url("))
				{
					throw new Exception55("Colors starting with url( are not yet supported!");
				}
				if (value.StartsWith("java.awt.Color"))
				{
					color = smethod_2(value);
				}
				else if (value.StartsWith("system-color("))
				{
					color = smethod_1(value);
				}
				else
				{
					if (value.StartsWith("fop-rgb-icc"))
					{
						throw new Exception("Color space fop-rgb-icc is not supported");
					}
					if (value.StartsWith("fop-rgb-named-color"))
					{
						throw new Exception("Color space fop-rgb-named-color is not supported");
					}
					if (value.StartsWith("cie-lab-color"))
					{
						throw new Exception("Color space cie-lab-color is not supported");
					}
					if (value.StartsWith("cmyk"))
					{
						throw new Exception("Color space cmyk is not supported");
					}
				}
			}
			if (color.IsEmpty)
			{
				throw new Exception55("Unknown Color: " + value);
			}
			hashtable_0[value] = color;
		}
		return color;
	}

	private static Color smethod_1(string value)
	{
		int num = value.IndexOf("(");
		int num2 = value.IndexOf(")");
		if (num == -1 || num2 == -1)
		{
			throw new Exception55("Unknown color format: " + value + ". Must be system-color(x)");
		}
		value = Class5479.smethod_0(value, num + 1, num2);
		return (Color)hashtable_0[value];
	}

	private static Color smethod_2(string value)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		int num4 = value.IndexOf("[");
		int num5 = value.IndexOf("]");
		try
		{
			if (num4 == -1 || num5 == -1)
			{
				throw new ArgumentException("Invalid format for a java.awt.Color: " + value);
			}
			value = Class5479.smethod_0(value, num4 + 1, num5);
			string[] array = value.Split(',');
			if (array.Length != 3)
			{
				throw new Exception55("Invalid number of arguments for a java.awt.Color: " + value);
			}
			num = float.Parse(array[0].Trim().Substring(2), NumberStyles.Any, Class4985.smethod_0().Ci) / 255f;
			num2 = float.Parse(array[1].Trim().Substring(2), NumberStyles.Any, Class4985.smethod_0().Ci) / 255f;
			num3 = float.Parse(array[2].Trim().Substring(2), NumberStyles.Any, Class4985.smethod_0().Ci) / 255f;
			if ((double)num < 0.0 || (double)num > 1.0 || (double)num2 < 0.0 || (double)num2 > 1.0 || (double)num3 < 0.0 || (double)num3 > 1.0)
			{
				throw new Exception55("Color values out of range");
			}
		}
		catch (Exception ex)
		{
			throw new Exception55(ex.Message);
		}
		return Color.FromArgb((int)(num * 255f + 0.5f), (int)(num2 * 255f + 0.5f), (int)(num3 * 255f + 0.5f));
	}

	private static Color smethod_3(string value)
	{
		int num = value.IndexOf("(");
		int num2 = value.IndexOf(")");
		if (num != -1 && num2 != -1)
		{
			value = Class5479.smethod_0(value, num + 1, num2);
			try
			{
				string[] array = value.Split(',');
				if (array.Length != 3)
				{
					throw new Exception55("Invalid number of arguments: rgb(" + value + ")");
				}
				float num3 = smethod_4(array[0], value);
				float num4 = smethod_4(array[1], value);
				float num5 = smethod_4(array[2], value);
				int red = (int)((double)(num3 * 255f) + 0.5);
				int green = (int)((double)(num4 * 255f) + 0.5);
				int blue = (int)((double)(num5 * 255f) + 0.5);
				return Color.FromArgb(red, green, blue);
			}
			catch (Exception ex)
			{
				throw new Exception55(ex.Message);
			}
		}
		throw new Exception55("Unknown color format: " + value + ". Must be rgb(r,g,b)");
	}

	private static float smethod_4(string str, string function)
	{
		str = str.Trim();
		float num = ((!str.EndsWith("%")) ? (float.Parse(str, NumberStyles.Any, Class4985.smethod_0().Ci) / 255f) : (float.Parse(Class5479.smethod_0(str, 0, str.Length - 1), NumberStyles.Any, Class4985.smethod_0().Ci) / 100f));
		if ((double)num < 0.0 || (double)num > 1.0)
		{
			throw new Exception55("Color value out of range for " + function + ": " + str + ". Valid range: [0..255] or [0%..100%]");
		}
		return num;
	}

	private static float smethod_5(string argument, string function)
	{
		return smethod_6(argument, 0f, 1f, function);
	}

	private static float smethod_6(string argument, float min, float max, string function)
	{
		float num = float.Parse(argument.Trim(), NumberStyles.Any, Class4985.smethod_0().Ci);
		if (num < min || num > max)
		{
			throw new Exception55("Color value out of range for " + function + ": " + argument + ". Valid range: [" + min + ".." + max + "]");
		}
		return num;
	}

	private static Color smethod_7(string[] args, string value)
	{
		float num = smethod_5(args[0], value);
		float num2 = smethod_5(args[1], value);
		float num3 = smethod_5(args[2], value);
		return Color.FromArgb((int)(num * 255f + 0.5f), (int)(num2 * 255f + 0.5f), (int)(num3 * 255f + 0.5f));
	}

	private static Color smethod_8(string value)
	{
		try
		{
			int length = value.Length;
			int alpha = ((length == 5 || length == 9) ? int.Parse(value.Substring((length == 5) ? 3 : 7), NumberStyles.HexNumber) : 255);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			switch (length)
			{
			default:
				throw new Exception();
			case 7:
			case 9:
				num = int.Parse(Class5479.smethod_0(value, 1, 3), NumberStyles.HexNumber);
				num2 = int.Parse(Class5479.smethod_0(value, 3, 5), NumberStyles.HexNumber);
				num3 = int.Parse(Class5479.smethod_0(value, 5, 7), NumberStyles.HexNumber);
				break;
			case 4:
			case 5:
				num = int.Parse(Class5479.smethod_0(value, 1, 2), NumberStyles.HexNumber) * 17;
				num2 = int.Parse(Class5479.smethod_0(value, 2, 3), NumberStyles.HexNumber) * 17;
				num3 = int.Parse(Class5479.smethod_0(value, 3, 4), NumberStyles.HexNumber) * 17;
				break;
			}
			return Color.FromArgb(alpha, num, num2, num3);
		}
		catch (Exception)
		{
			throw new Exception55("Unknown color format: " + value + ". Must be #RGB. #RGBA, #RRGGBB, or #RRGGBBAA");
		}
	}

	private static string smethod_9(string iccProfileSrc)
	{
		if (iccProfileSrc.StartsWith("\"") || iccProfileSrc.StartsWith("'"))
		{
			iccProfileSrc = iccProfileSrc.Substring(1);
		}
		if (iccProfileSrc.EndsWith("\"") || iccProfileSrc.EndsWith("'"))
		{
			iccProfileSrc = Class5479.smethod_0(iccProfileSrc, 0, iccProfileSrc.Length - 1);
		}
		return iccProfileSrc;
	}

	public static string smethod_10(Color color)
	{
		return smethod_11(color);
	}

	private static string smethod_11(Color color)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('#');
		string text = color.R.ToString("X");
		if (text.Length == 1)
		{
			stringBuilder.Append('0');
		}
		stringBuilder.Append(text);
		text = color.G.ToString("X");
		if (text.Length == 1)
		{
			stringBuilder.Append('0');
		}
		stringBuilder.Append(text);
		text = color.B.ToString("X");
		if (text.Length == 1)
		{
			stringBuilder.Append('0');
		}
		stringBuilder.Append(text);
		if (color.A != byte.MaxValue)
		{
			text = color.A.ToString("X");
			if (text.Length == 1)
			{
				stringBuilder.Append('0');
			}
			stringBuilder.Append(text);
		}
		return stringBuilder.ToString();
	}

	private static Color smethod_12(int r, int g, int b)
	{
		return Color.FromArgb(r, g, b);
	}

	private static void smethod_13()
	{
		hashtable_0 = new Hashtable();
		hashtable_0.Add("aliceblue", smethod_12(240, 248, 255));
		hashtable_0.Add("antiquewhite", smethod_12(250, 235, 215));
		hashtable_0.Add("aqua", smethod_12(0, 255, 255));
		hashtable_0.Add("aquamarine", smethod_12(127, 255, 212));
		hashtable_0.Add("azure", smethod_12(240, 255, 255));
		hashtable_0.Add("beige", smethod_12(245, 245, 220));
		hashtable_0.Add("bisque", smethod_12(255, 228, 196));
		hashtable_0.Add("black", smethod_12(0, 0, 0));
		hashtable_0.Add("blanchedalmond", smethod_12(255, 235, 205));
		hashtable_0.Add("blue", smethod_12(0, 0, 255));
		hashtable_0.Add("blueviolet", smethod_12(138, 43, 226));
		hashtable_0.Add("brown", smethod_12(165, 42, 42));
		hashtable_0.Add("burlywood", smethod_12(222, 184, 135));
		hashtable_0.Add("cadetblue", smethod_12(95, 158, 160));
		hashtable_0.Add("chartreuse", smethod_12(127, 255, 0));
		hashtable_0.Add("chocolate", smethod_12(210, 105, 30));
		hashtable_0.Add("coral", smethod_12(255, 127, 80));
		hashtable_0.Add("cornflowerblue", smethod_12(100, 149, 237));
		hashtable_0.Add("cornsilk", smethod_12(255, 248, 220));
		hashtable_0.Add("crimson", smethod_12(220, 20, 60));
		hashtable_0.Add("cyan", smethod_12(0, 255, 255));
		hashtable_0.Add("darkblue", smethod_12(0, 0, 139));
		hashtable_0.Add("darkcyan", smethod_12(0, 139, 139));
		hashtable_0.Add("darkgoldenrod", smethod_12(184, 134, 11));
		hashtable_0.Add("darkgray", smethod_12(169, 169, 169));
		hashtable_0.Add("darkgreen", smethod_12(0, 100, 0));
		hashtable_0.Add("darkgrey", smethod_12(169, 169, 169));
		hashtable_0.Add("darkkhaki", smethod_12(189, 183, 107));
		hashtable_0.Add("darkmagenta", smethod_12(139, 0, 139));
		hashtable_0.Add("darkolivegreen", smethod_12(85, 107, 47));
		hashtable_0.Add("darkorange", smethod_12(255, 140, 0));
		hashtable_0.Add("darkorchid", smethod_12(153, 50, 204));
		hashtable_0.Add("darkred", smethod_12(139, 0, 0));
		hashtable_0.Add("darksalmon", smethod_12(233, 150, 122));
		hashtable_0.Add("darkseagreen", smethod_12(143, 188, 143));
		hashtable_0.Add("darkslateblue", smethod_12(72, 61, 139));
		hashtable_0.Add("darkslategray", smethod_12(47, 79, 79));
		hashtable_0.Add("darkslategrey", smethod_12(47, 79, 79));
		hashtable_0.Add("darkturquoise", smethod_12(0, 206, 209));
		hashtable_0.Add("darkviolet", smethod_12(148, 0, 211));
		hashtable_0.Add("deeppink", smethod_12(255, 20, 147));
		hashtable_0.Add("deepskyblue", smethod_12(0, 191, 255));
		hashtable_0.Add("dimgray", smethod_12(105, 105, 105));
		hashtable_0.Add("dimgrey", smethod_12(105, 105, 105));
		hashtable_0.Add("dodgerblue", smethod_12(30, 144, 255));
		hashtable_0.Add("firebrick", smethod_12(178, 34, 34));
		hashtable_0.Add("floralwhite", smethod_12(255, 250, 240));
		hashtable_0.Add("forestgreen", smethod_12(34, 139, 34));
		hashtable_0.Add("fuchsia", smethod_12(255, 0, 255));
		hashtable_0.Add("gainsboro", smethod_12(220, 220, 220));
		hashtable_0.Add("ghostwhite", smethod_12(248, 248, 255));
		hashtable_0.Add("gold", smethod_12(255, 215, 0));
		hashtable_0.Add("goldenrod", smethod_12(218, 165, 32));
		hashtable_0.Add("gray", smethod_12(128, 128, 128));
		hashtable_0.Add("green", smethod_12(0, 128, 0));
		hashtable_0.Add("greenyellow", smethod_12(173, 255, 47));
		hashtable_0.Add("grey", smethod_12(128, 128, 128));
		hashtable_0.Add("honeydew", smethod_12(240, 255, 240));
		hashtable_0.Add("hotpink", smethod_12(255, 105, 180));
		hashtable_0.Add("indianred", smethod_12(205, 92, 92));
		hashtable_0.Add("indigo", smethod_12(75, 0, 130));
		hashtable_0.Add("ivory", smethod_12(255, 255, 240));
		hashtable_0.Add("khaki", smethod_12(240, 230, 140));
		hashtable_0.Add("lavender", smethod_12(230, 230, 250));
		hashtable_0.Add("lavenderblush", smethod_12(255, 240, 245));
		hashtable_0.Add("lawngreen", smethod_12(124, 252, 0));
		hashtable_0.Add("lemonchiffon", smethod_12(255, 250, 205));
		hashtable_0.Add("lightblue", smethod_12(173, 216, 230));
		hashtable_0.Add("lightcoral", smethod_12(240, 128, 128));
		hashtable_0.Add("lightcyan", smethod_12(224, 255, 255));
		hashtable_0.Add("lightgoldenrodyellow", smethod_12(250, 250, 210));
		hashtable_0.Add("lightgray", smethod_12(211, 211, 211));
		hashtable_0.Add("lightgreen", smethod_12(144, 238, 144));
		hashtable_0.Add("lightgrey", smethod_12(211, 211, 211));
		hashtable_0.Add("lightpink", smethod_12(255, 182, 193));
		hashtable_0.Add("lightsalmon", smethod_12(255, 160, 122));
		hashtable_0.Add("lightseagreen", smethod_12(32, 178, 170));
		hashtable_0.Add("lightskyblue", smethod_12(135, 206, 250));
		hashtable_0.Add("lightslategray", smethod_12(119, 136, 153));
		hashtable_0.Add("lightslategrey", smethod_12(119, 136, 153));
		hashtable_0.Add("lightsteelblue", smethod_12(176, 196, 222));
		hashtable_0.Add("lightyellow", smethod_12(255, 255, 224));
		hashtable_0.Add("lime", smethod_12(0, 255, 0));
		hashtable_0.Add("limegreen", smethod_12(50, 205, 50));
		hashtable_0.Add("linen", smethod_12(250, 240, 230));
		hashtable_0.Add("magenta", smethod_12(255, 0, 255));
		hashtable_0.Add("maroon", smethod_12(128, 0, 0));
		hashtable_0.Add("mediumaquamarine", smethod_12(102, 205, 170));
		hashtable_0.Add("mediumblue", smethod_12(0, 0, 205));
		hashtable_0.Add("mediumorchid", smethod_12(186, 85, 211));
		hashtable_0.Add("mediumpurple", smethod_12(147, 112, 219));
		hashtable_0.Add("mediumseagreen", smethod_12(60, 179, 113));
		hashtable_0.Add("mediumslateblue", smethod_12(123, 104, 238));
		hashtable_0.Add("mediumspringgreen", smethod_12(0, 250, 154));
		hashtable_0.Add("mediumturquoise", smethod_12(72, 209, 204));
		hashtable_0.Add("mediumvioletred", smethod_12(199, 21, 133));
		hashtable_0.Add("midnightblue", smethod_12(25, 25, 112));
		hashtable_0.Add("mintcream", smethod_12(245, 255, 250));
		hashtable_0.Add("mistyrose", smethod_12(255, 228, 225));
		hashtable_0.Add("moccasin", smethod_12(255, 228, 181));
		hashtable_0.Add("navajowhite", smethod_12(255, 222, 173));
		hashtable_0.Add("navy", smethod_12(0, 0, 128));
		hashtable_0.Add("oldlace", smethod_12(253, 245, 230));
		hashtable_0.Add("olive", smethod_12(128, 128, 0));
		hashtable_0.Add("olivedrab", smethod_12(107, 142, 35));
		hashtable_0.Add("orange", smethod_12(255, 165, 0));
		hashtable_0.Add("orangered", smethod_12(255, 69, 0));
		hashtable_0.Add("orchid", smethod_12(218, 112, 214));
		hashtable_0.Add("palegoldenrod", smethod_12(238, 232, 170));
		hashtable_0.Add("palegreen", smethod_12(152, 251, 152));
		hashtable_0.Add("paleturquoise", smethod_12(175, 238, 238));
		hashtable_0.Add("palevioletred", smethod_12(219, 112, 147));
		hashtable_0.Add("papayawhip", smethod_12(255, 239, 213));
		hashtable_0.Add("peachpuff", smethod_12(255, 218, 185));
		hashtable_0.Add("peru", smethod_12(205, 133, 63));
		hashtable_0.Add("pink", smethod_12(255, 192, 203));
		hashtable_0.Add("plum ", smethod_12(221, 160, 221));
		hashtable_0.Add("plum", smethod_12(221, 160, 221));
		hashtable_0.Add("powderblue", smethod_12(176, 224, 230));
		hashtable_0.Add("purple", smethod_12(128, 0, 128));
		hashtable_0.Add("red", smethod_12(255, 0, 0));
		hashtable_0.Add("rosybrown", smethod_12(188, 143, 143));
		hashtable_0.Add("royalblue", smethod_12(65, 105, 225));
		hashtable_0.Add("saddlebrown", smethod_12(139, 69, 19));
		hashtable_0.Add("salmon", smethod_12(250, 128, 114));
		hashtable_0.Add("sandybrown", smethod_12(244, 164, 96));
		hashtable_0.Add("seagreen", smethod_12(46, 139, 87));
		hashtable_0.Add("seashell", smethod_12(255, 245, 238));
		hashtable_0.Add("sienna", smethod_12(160, 82, 45));
		hashtable_0.Add("silver", smethod_12(192, 192, 192));
		hashtable_0.Add("skyblue", smethod_12(135, 206, 235));
		hashtable_0.Add("slateblue", smethod_12(106, 90, 205));
		hashtable_0.Add("slategray", smethod_12(112, 128, 144));
		hashtable_0.Add("slategrey", smethod_12(112, 128, 144));
		hashtable_0.Add("snow", smethod_12(255, 250, 250));
		hashtable_0.Add("springgreen", smethod_12(0, 255, 127));
		hashtable_0.Add("steelblue", smethod_12(70, 130, 180));
		hashtable_0.Add("tan", smethod_12(210, 180, 140));
		hashtable_0.Add("teal", smethod_12(0, 128, 128));
		hashtable_0.Add("thistle", smethod_12(216, 191, 216));
		hashtable_0.Add("tomato", smethod_12(255, 99, 71));
		hashtable_0.Add("turquoise", smethod_12(64, 224, 208));
		hashtable_0.Add("violet", smethod_12(238, 130, 238));
		hashtable_0.Add("wheat", smethod_12(245, 222, 179));
		hashtable_0.Add("white", smethod_12(255, 255, 255));
		hashtable_0.Add("whitesmoke", smethod_12(245, 245, 245));
		hashtable_0.Add("yellow", smethod_12(255, 255, 0));
		hashtable_0.Add("yellowgreen", smethod_12(154, 205, 50));
		hashtable_0.Add("transparent", Color.FromArgb(0, 0, 0, 0));
	}

	public static Color smethod_14(Color originalColor, float lightFactor)
	{
		if (smethod_15(lightFactor))
		{
			return originalColor;
		}
		if (smethod_16(lightFactor))
		{
			return Color.White;
		}
		if (smethod_17(lightFactor))
		{
			return smethod_18(originalColor, lightFactor);
		}
		return smethod_19(originalColor, lightFactor);
	}

	private static bool smethod_15(float lightFactor)
	{
		float num = lightFactor - 1f;
		if (num < 0.01f)
		{
			return num > -0.01f;
		}
		return false;
	}

	private static bool smethod_16(float lightFactor)
	{
		return lightFactor >= 2f;
	}

	private static bool smethod_17(float lightFactor)
	{
		return lightFactor < 1f;
	}

	private static Color smethod_18(Color color, float lightFactor)
	{
		int red = smethod_21(color.R, lightFactor);
		int green = smethod_21(color.G, lightFactor);
		int blue = smethod_21(color.B, lightFactor);
		return Color.FromArgb(red, green, blue);
	}

	private static Color smethod_19(Color color, float lightFactor)
	{
		float num = lightFactor;
		if (num > 1f)
		{
			num -= 1f;
		}
		int red = smethod_20(color.R, num);
		int green = smethod_20(color.G, num);
		int blue = smethod_20(color.B, num);
		return Color.FromArgb(red, green, blue);
	}

	private static byte smethod_20(byte colorComponent, float fFactor)
	{
		int num = 255 - colorComponent;
		colorComponent = (byte)(colorComponent + (byte)((float)num * fFactor));
		if (colorComponent >= byte.MaxValue)
		{
			return byte.MaxValue;
		}
		return colorComponent;
	}

	private static byte smethod_21(byte colorComponent, float fFactor)
	{
		int num = (int)((float)(int)colorComponent - (float)(int)colorComponent * (0f - fFactor));
		if (num >= 255)
		{
			return byte.MaxValue;
		}
		return (byte)num;
	}

	public static bool smethod_22(string colorProfileName)
	{
		string text = colorProfileName.ToLower();
		if (!("#CMYK".ToLower() == text))
		{
			return "#Separation".ToLower() == text;
		}
		return true;
	}
}
