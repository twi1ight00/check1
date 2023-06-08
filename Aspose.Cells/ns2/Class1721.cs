using System;
using System.Collections;
using System.Drawing;
using System.Text;
using Aspose.Cells;
using ns13;
using ns16;
using ns17;
using ns19;
using ns47;

namespace ns2;

internal class Class1721
{
	private static Graphics smethod_0()
	{
		using Bitmap image = new Bitmap(800, 600);
		return Graphics.FromImage(image);
	}

	internal static void AutoFitRow(Cells cells_0, int int_0, int int_1, int int_2, int int_3, AutoFitterOptions autoFitterOptions_0)
	{
		using Graphics graphics_ = smethod_0();
		smethod_10(graphics_, cells_0, int_0, int_1, int_2, int_3, autoFitterOptions_0);
	}

	internal static string smethod_1(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		char[] array = string_0.ToCharArray();
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (array[i])
			{
			case '/':
				stringBuilder.Append('W');
				break;
			default:
				stringBuilder.Append(array[i]);
				break;
			case ' ':
				if (i != 0)
				{
					switch (array[i - 1])
					{
					case '%':
					case '&':
						stringBuilder.Append(array[i]);
						break;
					case 'd':
					case 'l':
					case 'r':
						stringBuilder.Append(array[i - 1]);
						break;
					}
				}
				stringBuilder.Append(array[i]);
				break;
			}
		}
		return stringBuilder.ToString();
	}

	private static int smethod_2(Cell cell_0, Style style_0, ArrayList arrayList_0, int int_0, int int_1)
	{
		Class456.smethod_3(arrayList_0, cell_0.method_4().method_19().Workbook, "Arial");
		foreach (Class1544 item in arrayList_0)
		{
			item.font_0.Name = Class1462.smethod_5(item.font_0.Name);
		}
		Class1620 class2 = new Class1620(cell_0.Row, cell_0.Column);
		class2.method_18(cell_0);
		class2.method_8(style_0);
		Class1621 class3 = new Class1621(arrayList_0, class2, int_0, 600f, new double[2] { 1.0, 1.0 }, bool_1: false);
		return (int)(class3.float_3 * 96f / 72f);
	}

	private static int smethod_3(Graphics graphics_0, Style style_0, string string_0, float float_0, int int_0, bool bool_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			if (!style_0.IsTextWrapped && (style_0.RotationAngle == 0 || style_0.RotationAngle == 255))
			{
				return smethod_5(graphics_0, style_0.Font);
			}
			Aspose.Cells.Font font = style_0.Font;
			if (string_0[string_0.Length - 1] == '\n')
			{
				string_0 += "a";
			}
			int size = font.Size;
			FontStyle fontStyle = FontStyle.Regular;
			if (font.IsBold)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (font.IsItalic)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (font.IsStrikeout)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			if (font.Underline != 0)
			{
				fontStyle |= FontStyle.Underline;
			}
			if (bool_0 && font.Name == "Times New Roman")
			{
				string_0 = smethod_1(string_0);
			}
			using System.Drawing.Font font2 = new System.Drawing.Font(font.Name, size, fontStyle);
			CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
			{
				new CharacterRange(0, string_0.Length)
			};
			float x = 0f;
			float y = 0f;
			float height = 600f;
			if (!style_0.IsTextWrapped)
			{
				float_0 = 600f;
			}
			else if (float_0 < 100f)
			{
				switch (style_0.HorizontalAlignment)
				{
				case TextAlignmentType.Left:
				case TextAlignmentType.Right:
					float_0 -= 1f;
					break;
				}
			}
			else
			{
				float_0 -= 2f;
			}
			RectangleF layoutRect = new RectangleF(x, y, float_0, height);
			StringFormat stringFormat = new StringFormat();
			stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
			stringFormat.Trimming = StringTrimming.None;
			stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
			Region[] array = graphics_0.MeasureCharacterRanges(string_0, font2, layoutRect, stringFormat);
			RectangleF bounds = array[0].GetBounds(graphics_0);
			int num = (int)((double)bounds.Height * 1.1 + 0.5);
			if (font.Size >= 20 || num > 100)
			{
				num++;
			}
			if (style_0.IsTextWrapped)
			{
				if (size >= 10)
				{
					return num;
				}
				int num2 = smethod_6(graphics_0, font);
				float num3 = bounds.Height;
				if (num3 > 100f)
				{
					num3 += 1f;
				}
				int num4 = (int)Math.Ceiling((double)num3 * 1.0 / (double)num2);
				if (num3 > 100f)
				{
					num4 = (int)((double)num3 * 1.0 / (double)num2) + 1;
				}
				if (num4 == 1)
				{
					return smethod_5(graphics_0, font);
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < num4; i++)
				{
					stringBuilder.Append("\n0");
				}
				return smethod_4(graphics_0, style_0, stringBuilder.ToString(), float_0);
			}
			int num5 = Math.Abs(style_0.RotationAngle);
			if (num5 == 90)
			{
				return (int)((double)bounds.Width + 0.5) + int_0;
			}
			int num6 = (int)((double)bounds.Width + 0.5) + int_0;
			int num7 = (int)((double)font2.GetHeight(graphics_0) * 1.1 + 0.5);
			return (int)((double)num6 * Math.Sin(Math.PI * (double)num5 / 180.0) + (double)num7 * Math.Cos(Math.PI * (double)num5 / 180.0) + 6.5);
		}
		return 0;
	}

	private static int smethod_4(Graphics graphics_0, Style style_0, string string_0, float float_0)
	{
		if (string_0 == "")
		{
			return 0;
		}
		int num = style_0.Font.Size;
		string name;
		if (((name = style_0.Font.Name) == null || !(name == "Calibri")) && num < 10)
		{
			num = (int)((double)num * 1.1 + 0.5);
			if (num > 10)
			{
				num = 10;
			}
		}
		using System.Drawing.Font font = new System.Drawing.Font(style_0.Font.Name, num);
		CharacterRange[] measurableCharacterRanges = new CharacterRange[1]
		{
			new CharacterRange(0, string_0.Length)
		};
		float x = 0f;
		float y = 0f;
		float height = 600f;
		if (!style_0.IsTextWrapped)
		{
			float_0 = 600f;
		}
		RectangleF layoutRect = new RectangleF(x, y, float_0, height);
		StringFormat stringFormat = new StringFormat();
		stringFormat.SetMeasurableCharacterRanges(measurableCharacterRanges);
		Region[] array = new Region[1];
		array = graphics_0.MeasureCharacterRanges(string_0, font, layoutRect, stringFormat);
		return (int)((double)array[0].GetBounds(graphics_0).Height * 1.1 + 0.5);
	}

	private static int smethod_5(Graphics graphics_0, Aspose.Cells.Font font_0)
	{
		int size = font_0.Size;
		FontStyle fontStyle = FontStyle.Regular;
		string text = "Arial";
		if (font_0.IsBold)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (font_0.IsItalic)
		{
			fontStyle |= FontStyle.Italic;
		}
		if (font_0.IsStrikeout)
		{
			fontStyle |= FontStyle.Strikeout;
		}
		if (font_0.Underline != 0)
		{
			fontStyle |= FontStyle.Underline;
		}
		text = font_0.Name;
		using System.Drawing.Font font = new System.Drawing.Font(text, size, fontStyle);
		float height = font.GetHeight(graphics_0);
		int num = (int)((double)height * 1.1 + 0.5);
		if (font_0.Size >= 20 || num > 100 || (font_0.Size == 12 && font_0.IsBold))
		{
			num++;
		}
		int size2 = font_0.Size;
		if (size2 == 8)
		{
			num += 2;
		}
		else if (font_0.Size < 10)
		{
			num++;
		}
		return num;
	}

	private static int smethod_6(Graphics graphics_0, Aspose.Cells.Font font_0)
	{
		int size = font_0.Size;
		FontStyle fontStyle = FontStyle.Regular;
		string text = "Arial";
		if (font_0.IsBold)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (font_0.IsItalic)
		{
			fontStyle |= FontStyle.Italic;
		}
		if (font_0.IsStrikeout)
		{
			fontStyle |= FontStyle.Strikeout;
		}
		if (font_0.Underline != 0)
		{
			fontStyle |= FontStyle.Underline;
		}
		text = font_0.Name;
		using System.Drawing.Font font = new System.Drawing.Font(text, size, fontStyle);
		float height = font.GetHeight(graphics_0);
		return (int)Math.Ceiling(height);
	}

	private static bool smethod_7(Cells cells, int row, int column, out CellArea ca)
	{
		int num = 0;
		CellArea cellArea;
		while (true)
		{
			if (num < cells.method_18().Count)
			{
				cellArea = cells.method_18()[num];
				if (cellArea.StartRow <= row && cellArea.EndRow >= row && cellArea.StartColumn <= column && cellArea.EndColumn >= column)
				{
					break;
				}
				num++;
				continue;
			}
			ca = default(CellArea);
			return false;
		}
		ca = cellArea;
		return true;
	}

	private static object smethod_8(Cells cells_0, Hashtable hashtable_0, int int_0, int int_1)
	{
		object obj = hashtable_0[int_0];
		if (obj == null)
		{
			return null;
		}
		Class933 @class = (Class933)obj;
		int num = 0;
		CellArea cellArea;
		while (true)
		{
			if (num < @class.Count)
			{
				cellArea = cells_0.method_18()[@class[num]];
				if (cellArea.StartColumn <= int_1 && cellArea.EndColumn >= int_1)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return cellArea;
	}

	private static Hashtable smethod_9(Cells cells_0, int int_0, int int_1, int int_2, int int_3)
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < cells_0.method_18().Count; i++)
		{
			CellArea cellArea = cells_0.method_18()[i];
			if (cellArea.StartRow > int_1 || cellArea.EndRow < int_0)
			{
				continue;
			}
			for (int j = cellArea.StartRow; j <= cellArea.EndRow; j++)
			{
				if (j >= int_0)
				{
					if (j > int_1)
					{
						break;
					}
					object obj = hashtable[j];
					if (obj == null)
					{
						obj = new Class933(4);
						hashtable[j] = obj;
					}
					((Class933)obj).Add(i);
				}
			}
		}
		return hashtable;
	}

	private static void smethod_10(Graphics graphics_0, Cells cells_0, int int_0, int int_1, int int_2, int int_3, AutoFitterOptions autoFitterOptions_0)
	{
		int int_4 = cells_0.method_19().method_73() + cells_0.method_19().method_72() + 2;
		_ = cells_0.method_19().DefaultStyle;
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = new Hashtable();
		int num = smethod_5(graphics_0, cells_0.method_19().DefaultFont);
		hashtable2.Add(-1, num);
		hashtable2.Add(15, num);
		int num2 = Class1625.smethod_19("   ", cells_0.method_19().DefaultFont, 1.0);
		RowCollection rows = cells_0.Rows;
		Worksheet worksheet = cells_0.method_3();
		CellArea cellArea = default(CellArea);
		bool flag = false;
		if (worksheet.method_24() != 0)
		{
			flag = true;
			cellArea = worksheet.AutoFilter.method_7();
		}
		Hashtable hashtable3 = null;
		if (cells_0.method_18().Count > 1024)
		{
			hashtable3 = smethod_9(cells_0, int_0, int_1, int_2, int_3);
		}
		for (int i = 0; i < rows.Count; i++)
		{
			Row rowByIndex = rows.GetRowByIndex(i);
			if (rowByIndex.int_0 < int_0 || rowByIndex.int_0 > int_1)
			{
				continue;
			}
			hashtable3?.Remove(rowByIndex.int_0 - 1);
			if ((rowByIndex.IsHidden && autoFitterOptions_0.IgnoreHidden) || (autoFitterOptions_0.OnlyAuto && !rowByIndex.IsHeightMatched))
			{
				continue;
			}
			int num3 = num;
			if (rowByIndex.IsHidden && flag && rowByIndex.int_0 >= cellArea.StartRow && rowByIndex.int_0 <= cellArea.EndRow)
			{
				continue;
			}
			if (rowByIndex.method_27())
			{
				int num4 = rowByIndex.method_10();
				if (hashtable2[num4] != null)
				{
					num3 = (int)hashtable2[num4];
				}
				else
				{
					Style style = cells_0.method_19().method_58()[num4];
					num3 = smethod_5(graphics_0, rowByIndex.method_26().Font);
					if (!style.IsTextWrapped)
					{
						hashtable2[num4] = num3;
					}
				}
			}
			int num5 = 0;
			ArrayList cells = rowByIndex.Cells;
			for (int j = 0; j < cells.Count; j++)
			{
				Cell cell = (Cell)cells[j];
				if (cell.Column < int_2)
				{
					continue;
				}
				if (cell.Column > int_3)
				{
					break;
				}
				bool flag2 = false;
				CellArea ca;
				if (hashtable3 == null)
				{
					flag2 = smethod_7(cells_0, cell.Row, cell.Column, out ca);
				}
				else
				{
					object obj = smethod_8(cells_0, hashtable3, cell.Row, cell.Column);
					if (obj != null)
					{
						ca = (CellArea)obj;
						flag2 = true;
					}
					else
					{
						ca = default(CellArea);
					}
				}
				if (flag2 && (ca.StartRow != ca.EndRow || !autoFitterOptions_0.AutoFitMergedCells || cell.Row != ca.StartRow || cell.Column != ca.StartColumn))
				{
					continue;
				}
				int num6 = cell.method_35();
				cell.IsRichText();
				Style style2 = cells_0.method_19().method_58()[num6];
				if (cell.Type == CellValueType.IsString && (style2.IsTextWrapped || style2.RotationAngle != 0))
				{
					string stringValue = cell.StringValue;
					if (stringValue == null || stringValue == "")
					{
						continue;
					}
					object obj2 = hashtable[cell.Column];
					if (obj2 == null)
					{
						obj2 = cells_0.method_17(cell.Column);
						hashtable[cell.Column] = obj2;
					}
					int num7 = (int)obj2;
					if (flag2)
					{
						for (int k = ca.StartColumn + 1; k <= ca.EndColumn; k++)
						{
							obj2 = hashtable[k];
							if (obj2 == null)
							{
								obj2 = cells_0.GetColumnWidthPixel(k);
								hashtable[k] = obj2;
							}
							num7 += (int)obj2;
						}
					}
					if (style2.HorizontalAlignment == TextAlignmentType.CenterAcross)
					{
						int column = cell.Column;
						for (int l = j + 1; l < cells.Count; l++)
						{
							Cell cell2 = (Cell)cells[l];
							if (column + 1 != cell2.Column || cell2.Type != CellValueType.IsNull || cell2.GetStyle().HorizontalAlignment != TextAlignmentType.CenterAcross)
							{
								break;
							}
							object obj3 = hashtable[cell2.Column];
							if (obj3 == null)
							{
								obj3 = cells_0.method_17(cell2.Column);
								hashtable[cell2.Column] = obj3;
							}
							num7 += (int)obj3;
							column = cell2.Column;
						}
					}
					if (style2.IndentLevel != 0)
					{
						int num8 = num2 * style2.IndentLevel;
						if (num7 > num8)
						{
							num7 -= num8;
						}
					}
					num5 = ((style2.RotationAngle != 0) ? smethod_3(graphics_0, style2, stringValue, num7, int_4, cell.Type == CellValueType.IsString) : smethod_2(cell, style2, cell.method_69(), num7, cells_0.method_19().method_75()));
				}
				else if (hashtable2[num6] != null)
				{
					num5 = (int)hashtable2[num6];
				}
				else
				{
					num5 = smethod_2(cell, style2, cell.method_69(), int.MaxValue, cells_0.method_19().method_75());
					hashtable2[num6] = num5;
				}
				if (num5 > num3)
				{
					num3 = num5;
				}
			}
			int num9 = (int)((double)((float)(num3 * 72) * 20f / (float)cells_0.method_19().method_75()) + 0.5);
			if ((double)num9 > 8190.0)
			{
				num9 = 8190;
			}
			rowByIndex.method_14((ushort)num9);
			if (autoFitterOptions_0.bool_3 && !autoFitterOptions_0.AutoFitMergedCells)
			{
				rowByIndex.IsHeightMatched = true;
			}
			else
			{
				rowByIndex.IsHeightMatched = false;
			}
		}
	}
}
