using System.Collections.Generic;
using System.Drawing;
using Aspose.Cells;
using ns1;
using ns16;

namespace ns8;

internal class Class732
{
	public static int int_0 = 0;

	public static int int_1 = 1;

	public static int int_2 = 72;

	public static double double_0 = 2.54;

	public static int int_3 = 96;

	public static int int_4 = 65536;

	public static int int_5 = 65535;

	public static int int_6 = 256;

	public static int int_7 = 409;

	public static int smethod_0(string string_0)
	{
		if (string_0.IndexOf('.') == -1 && string_0.IndexOf('-') == -1)
		{
			if (double.Parse(string_0) > 2147483647.0)
			{
				return int_0;
			}
			return int_1;
		}
		return int_0;
	}

	public static string smethod_1(string string_0)
	{
		return string_0.Replace("T", " ").Replace("Z", "");
	}

	public static string smethod_2(string string_0)
	{
		string text = string_0.Replace("%20", " ");
		return text.Replace("%26", "&").Replace("file:///", "");
	}

	private static string smethod_3(string string_0)
	{
		string text = string_0.Replace("\\\\\\\\\\\\/", "/");
		text = text.Replace("\\\\\\[ENG\\\\\\]", "");
		text = text.Replace("\\\\\\\\ ", " ");
		text = text.Replace("\\\\\\\\", "\r");
		text = text.Replace("\\\\", "");
		text = text.Replace("\r", "\\\\");
		text = text.Replace("\"", "").Replace("0027", "'");
		text = text.Replace("0022", "\\\"").Replace("00A3", "");
		return text.Replace("\\", "");
	}

	public static TextAlignmentType smethod_4(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_11 == null)
			{
				Class1742.dictionary_11 = new Dictionary<string, int>(10)
				{
					{ "center", 0 },
					{ "distributed", 1 },
					{ "justify", 2 },
					{ "left", 3 },
					{ "right", 4 },
					{ "center-across", 5 },
					{ "fill", 6 },
					{ "general", 7 },
					{ "010", 8 },
					{ "121", 9 }
				};
			}
			if (Class1742.dictionary_11.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TextAlignmentType.Center;
				case 1:
					return TextAlignmentType.Distributed;
				case 2:
					return TextAlignmentType.Justify;
				case 3:
					return TextAlignmentType.Left;
				case 4:
					return TextAlignmentType.Right;
				case 5:
					return TextAlignmentType.CenterAcross;
				case 6:
					return TextAlignmentType.Fill;
				case 7:
					return TextAlignmentType.General;
				case 8:
					return TextAlignmentType.Justify;
				case 9:
					return TextAlignmentType.Distributed;
				}
			}
		}
		return TextAlignmentType.General;
	}

	public static TextAlignmentType smethod_5(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_12 == null)
			{
				Class1742.dictionary_12 = new Dictionary<string, int>(6)
				{
					{ "middle", 0 },
					{ "distributed", 1 },
					{ "justify", 2 },
					{ "top", 3 },
					{ "bottom", 4 },
					{ "121", 5 }
				};
			}
			if (Class1742.dictionary_12.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TextAlignmentType.Center;
				case 1:
					return TextAlignmentType.Distributed;
				case 2:
					return TextAlignmentType.Justify;
				case 3:
					return TextAlignmentType.Top;
				case 4:
					return TextAlignmentType.Bottom;
				case 5:
					return TextAlignmentType.Distributed;
				}
			}
		}
		return TextAlignmentType.General;
	}

	public static void smethod_6(Aspose.Cells.Font font_0, string string_0)
	{
		switch (string_0)
		{
		case "double-accounting":
			font_0.Underline = FontUnderlineType.DoubleAccounting;
			break;
		case "single-accounting":
			font_0.Underline = FontUnderlineType.Accounting;
			break;
		case "double":
			font_0.Underline = FontUnderlineType.Double;
			break;
		case "single":
			font_0.Underline = FontUnderlineType.Single;
			break;
		}
	}

	public static FontUnderlineType smethod_7(string string_0)
	{
		return string_0 switch
		{
			"single-accounting" => FontUnderlineType.Accounting, 
			"double-accounting" => FontUnderlineType.DoubleAccounting, 
			"double" => FontUnderlineType.Double, 
			"none" => FontUnderlineType.None, 
			_ => FontUnderlineType.Single, 
		};
	}

	public static void smethod_8(string string_0, Style style_0)
	{
		string[] array = string_0.Split(' ');
		if (array.Length == 2)
		{
			style_0.Pattern = smethod_11(array[1]);
		}
	}

	public static void smethod_9(string string_0, Style style_0, Color color_0)
	{
		string[] array = string_0.Split(' ');
		if (array.Length == 2)
		{
			style_0.Pattern = smethod_11(array[1]);
			if (string_0 == "auto none")
			{
				style_0.ForegroundColor = color_0;
			}
			else if (array[1] != "none")
			{
				style_0.ForegroundColor = smethod_10(array[0]);
				style_0.BackgroundColor = color_0;
			}
			else
			{
				style_0.ForegroundColor = color_0;
			}
		}
	}

	public static Color smethod_10(string string_0)
	{
		if (string_0 == null)
		{
			return Color.Empty;
		}
		if (string_0.StartsWith("#"))
		{
			return ColorTranslator.FromHtml(string_0);
		}
		if (string_0.StartsWith("rgb"))
		{
			string text = string_0.Substring(4);
			string text2 = text.Substring(0, text.Length - 1);
			string[] array = text2.Trim().Split(',');
			int red = Class1618.smethod_87(array[0].Trim());
			int green = Class1618.smethod_87(array[1].Trim());
			int blue = Class1618.smethod_87(array[2].Trim());
			return Color.FromArgb(red, green, blue);
		}
		return Color.FromName(string_0);
	}

	public static BackgroundType smethod_11(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_13 == null)
			{
				Class1742.dictionary_13 = new Dictionary<string, int>(18)
				{
					{ "none", 0 },
					{ "gray-75", 1 },
					{ "gray-50", 2 },
					{ "gray-25", 3 },
					{ "gray-125", 4 },
					{ "gray-0625", 5 },
					{ "horz-stripe", 6 },
					{ "vert-stripe", 7 },
					{ "reverse-diag-stripe", 8 },
					{ "diag-stripe", 9 },
					{ "diag-cross", 10 },
					{ "thick-diag-cross", 11 },
					{ "thin-horz-stripe", 12 },
					{ "thin-vert-stripe", 13 },
					{ "thin-reverse-diag-stripe", 14 },
					{ "thin-diag-stripe", 15 },
					{ "thin-horz-cross", 16 },
					{ "thin-diag-cross", 17 }
				};
			}
			if (Class1742.dictionary_13.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return BackgroundType.Solid;
				case 1:
					return BackgroundType.Gray75;
				case 2:
					return BackgroundType.Gray50;
				case 3:
					return BackgroundType.Gray25;
				case 4:
					return BackgroundType.Gray12;
				case 5:
					return BackgroundType.Gray6;
				case 6:
					return BackgroundType.HorizontalStripe;
				case 7:
					return BackgroundType.VerticalStripe;
				case 8:
					return BackgroundType.ReverseDiagonalStripe;
				case 9:
					return BackgroundType.DiagonalStripe;
				case 10:
					return BackgroundType.DiagonalCrosshatch;
				case 11:
					return BackgroundType.ThickDiagonalCrosshatch;
				case 12:
					return BackgroundType.ThinHorizontalStripe;
				case 13:
					return BackgroundType.ThinVerticalStripe;
				case 14:
					return BackgroundType.ThinReverseDiagonalStripe;
				case 15:
					return BackgroundType.ThinDiagonalStripe;
				case 16:
					return BackgroundType.ThinHorizontalCrosshatch;
				case 17:
					return BackgroundType.ThinDiagonalCrosshatch;
				}
			}
		}
		return BackgroundType.None;
	}

	public static void smethod_12(Style style_0, string string_0)
	{
		string custom = smethod_3(string_0);
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_14 == null)
			{
				Class1742.dictionary_14 = new Dictionary<string, int>(12)
				{
					{ "Percent", 0 },
					{ "Fixed", 1 },
					{ "\"Short Date\"", 2 },
					{ "\"Medium Date\"", 3 },
					{ "\"Long Date\"", 4 },
					{ "\"Short Time\"", 5 },
					{ "\"Medium Time\"", 6 },
					{ "\"Long Time\"", 7 },
					{ "\"Currency\"", 8 },
					{ "\"General Date\"", 9 },
					{ "\"Scientific\"", 10 },
					{ "Scientific", 11 }
				};
			}
			if (Class1742.dictionary_14.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					style_0.Number = 10;
					return;
				case 1:
					style_0.Number = 2;
					return;
				case 2:
					style_0.Number = 14;
					return;
				case 3:
					style_0.Number = 15;
					return;
				case 4:
					style_0.Number = 31;
					return;
				case 5:
					style_0.Number = 20;
					return;
				case 6:
					style_0.Number = 18;
					return;
				case 7:
					style_0.Number = 19;
					return;
				case 8:
					style_0.Number = 43;
					return;
				case 9:
					style_0.Number = 22;
					return;
				case 10:
					style_0.Number = 48;
					return;
				case 11:
					style_0.Number = 11;
					return;
				}
			}
		}
		if (string_0.IndexOf("Standard") != -1)
		{
			style_0.Number = 4;
		}
		else
		{
			style_0.Custom = custom;
		}
	}
}
