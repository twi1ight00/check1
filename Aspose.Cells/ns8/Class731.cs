using System.Collections.Generic;
using Aspose.Cells;
using ns1;

namespace ns8;

internal class Class731
{
	public static CellBorderType smethod_0(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_9 == null)
			{
				Class1742.dictionary_9 = new Dictionary<string, int>(16)
				{
					{ ".5pt solid", 0 },
					{ "0.5pt solid", 1 },
					{ "1.0pt solid", 2 },
					{ ".5pt dashed", 3 },
					{ ".5pt dotted", 4 },
					{ "1.5pt solid", 5 },
					{ "2.0pt double", 6 },
					{ "4px double", 7 },
					{ "1.5pt double", 8 },
					{ ".5pt hairline", 9 },
					{ "1.0pt dashed", 10 },
					{ ".5pt dot-dash", 11 },
					{ "1.0pt dot-dash", 12 },
					{ ".5pt dot-dot-dash", 13 },
					{ "1.0pt dot-dot-dash", 14 },
					{ "1.0pt dot-dash-slanted", 15 }
				};
			}
			if (Class1742.dictionary_9.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
					return CellBorderType.Thin;
				case 2:
					return CellBorderType.Medium;
				case 3:
					return CellBorderType.Dashed;
				case 4:
					return CellBorderType.Dotted;
				case 5:
					return CellBorderType.Thick;
				case 6:
				case 7:
				case 8:
					return CellBorderType.Double;
				case 9:
					return CellBorderType.Hair;
				case 10:
					return CellBorderType.MediumDashed;
				case 11:
					return CellBorderType.DashDot;
				case 12:
					return CellBorderType.MediumDashDot;
				case 13:
					return CellBorderType.DashDotDot;
				case 14:
					return CellBorderType.MediumDashDotDot;
				case 15:
					return CellBorderType.SlantedDashDot;
				}
			}
		}
		return CellBorderType.None;
	}

	private static BorderType smethod_1(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_10 == null)
			{
				Class1742.dictionary_10 = new Dictionary<string, int>(6)
				{
					{ "border-top", 0 },
					{ "border-right", 1 },
					{ "border-bottom", 2 },
					{ "border-left", 3 },
					{ "mso-diagonal-up", 4 },
					{ "mso-diagonal-down", 5 }
				};
			}
			if (Class1742.dictionary_10.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return BorderType.TopBorder;
				case 1:
					return BorderType.RightBorder;
				case 2:
					return BorderType.BottomBorder;
				case 3:
					return BorderType.LeftBorder;
				case 4:
					return BorderType.DiagonalUp;
				case 5:
					return BorderType.DiagonalDown;
				}
			}
		}
		return BorderType.Vertical;
	}

	public static void SetBorder(string string_0, string string_1, Style style_0)
	{
		int num = string_1.IndexOf(" ");
		if (num != -1)
		{
			string text = string_1.Substring(num + 1, string_1.Length - num - 1);
			int num2 = text.IndexOf(" ");
			if (num2 != -1)
			{
				CellBorderType lineStyle = smethod_0(string_1.Substring(0, num + num2 + 1));
				string string_2 = string_1.Substring(num + num2 + 2);
				if (!string_0.Equals("border"))
				{
					BorderType borderType = smethod_1(string_0);
					style_0.Borders[borderType].Color = Class732.smethod_10(string_2);
					style_0.Borders[borderType].LineStyle = lineStyle;
					return;
				}
				style_0.Borders[BorderType.BottomBorder].Color = Class732.smethod_10(string_2);
				style_0.Borders[BorderType.BottomBorder].LineStyle = lineStyle;
				style_0.Borders[BorderType.LeftBorder].Color = Class732.smethod_10(string_2);
				style_0.Borders[BorderType.LeftBorder].LineStyle = lineStyle;
				style_0.Borders[BorderType.RightBorder].Color = Class732.smethod_10(string_2);
				style_0.Borders[BorderType.RightBorder].LineStyle = lineStyle;
				style_0.Borders[BorderType.TopBorder].Color = Class732.smethod_10(string_2);
				style_0.Borders[BorderType.TopBorder].LineStyle = lineStyle;
			}
		}
		else
		{
			string_1.Equals("none");
		}
	}

	private static BorderType smethod_2(int int_0)
	{
		return int_0 switch
		{
			0 => BorderType.LeftBorder, 
			1 => BorderType.RightBorder, 
			2 => BorderType.BottomBorder, 
			3 => BorderType.TopBorder, 
			_ => BorderType.Vertical, 
		};
	}

	public static void SetBorder(string string_0, string string_1, string string_2, Style style_0)
	{
		string[] array = string_0.Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			BorderType borderType = smethod_2(i);
			if (array[i] != "0")
			{
				style_0.Borders[borderType].Color = Class732.smethod_10(string_2);
				if (array[i] == "4px")
				{
					style_0.Borders[borderType].LineStyle = CellBorderType.Thick;
				}
				else if (array[i] == "1px")
				{
					style_0.Borders[borderType].LineStyle = CellBorderType.Medium;
				}
			}
		}
	}
}
