using System;
using System.Collections;
using System.Drawing;
using Aspose.Cells;
using ns17;
using ns47;

namespace ns2;

internal class Class1190
{
	private static Graphics smethod_0()
	{
		using Bitmap image = new Bitmap(100, 2000);
		return Graphics.FromImage(image);
	}

	internal static void AutoFitColumn(Cells cells_0, int int_0, int int_1, int int_2, int int_3, AutoFitterOptions autoFitterOptions_0)
	{
		using Graphics graphics_ = smethod_0();
		cells_0.method_19().Workbook.Settings.bool_3 = true;
		smethod_4(graphics_, cells_0, int_0, int_1, int_2, int_3, autoFitterOptions_0);
		cells_0.method_19().Workbook.Settings.bool_3 = false;
	}

	private static int smethod_1(Graphics graphics_0, Style style_0, string string_0, int int_0, RectangleF rectangleF_0)
	{
		FontStyle fontStyle = FontStyle.Regular;
		int num = 10;
		string text = "Arial";
		if (style_0.method_40() != null)
		{
			Aspose.Cells.Font font = style_0.method_40();
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
			text = style_0.method_5().Workbook.method_0(font.Name);
			num = font.Size;
		}
		Class1460 @class = Class1462.smethod_3(text, fontStyle, bool_0: false);
		int num2 = Class1093.smethod_1(text, num, fontStyle);
		int num3 = 0;
		if (style_0.RotationAngle != 0 && style_0.RotationAngle != 255)
		{
			int num4 = Math.Abs(style_0.RotationAngle);
			if (num4 == 90)
			{
				return Class1460.smethod_0(text, num, "|", fontStyle).Height;
			}
			int num5 = num3;
			int height = Class1460.smethod_0(text, num, "|", fontStyle).Height;
			double num6 = Math.PI * (double)Math.Abs(style_0.RotationAngle) / 180.0;
			num3 = (int)((double)num5 * Math.Cos(num6) + (double)height * Math.Sin(num6) + 6.5);
			return num3 + num2 * 4 + 1;
		}
		for (int i = 0; i < string_0.Length; i++)
		{
			num3 += (int)@class.method_42(string_0[i], num);
		}
		return num3 + num2 * 4 + 1;
	}

	private static int smethod_2(Class10 class10_0, int int_0, RectangleF rectangleF_0)
	{
		int num = 0;
		for (int i = 0; i < class10_0.arrayList_0.Count; i++)
		{
			string text = (string)class10_0.arrayList_0[i];
			Class1460 @class = Class1462.smethod_3(class10_0.string_0, class10_0.fontStyle_0, bool_0: false);
			int num2 = Class1093.smethod_1(class10_0.string_0, class10_0.int_0, class10_0.fontStyle_0);
			int num3 = num2 * 4 + 1;
			for (int j = 0; j < text.Length; j++)
			{
				num3 += (int)@class.method_42(text[j], class10_0.int_0);
			}
			if (num < num3)
			{
				num = num3;
			}
		}
		return num;
	}

	private static bool smethod_3(Cells cells_0, int int_0, int int_1)
	{
		if (cells_0.method_3().method_24() > 0)
		{
			CellArea cellArea = cells_0.method_3().AutoFilter.method_7();
			if (int_0 == cellArea.StartRow && int_1 >= cellArea.StartColumn && int_1 <= cellArea.EndColumn)
			{
				return true;
			}
		}
		if (cells_0.method_3().ListObjects.Count > 0)
		{
			return cells_0.method_3().ListObjects.method_5(int_0, int_1);
		}
		return false;
	}

	private static void smethod_4(Graphics graphics_0, Cells cells_0, int int_0, int int_1, int int_2, int int_3, AutoFitterOptions autoFitterOptions_0)
	{
		int int_4 = cells_0.method_19().method_73() + cells_0.method_19().method_72() + 2;
		Style defaultStyle = cells_0.method_19().DefaultStyle;
		Hashtable hashtable = new Hashtable();
		if (autoFitterOptions_0 != null)
		{
			for (int i = 0; i < cells_0.Columns.Count; i++)
			{
				Column columnByIndex = cells_0.Columns.GetColumnByIndex(i);
				if (columnByIndex.Index >= int_2 && columnByIndex.Index <= int_3 && autoFitterOptions_0.IgnoreHidden && columnByIndex.IsHidden)
				{
					hashtable[columnByIndex.Index] = true;
				}
			}
		}
		Hashtable hashtable2 = new Hashtable();
		Hashtable hashtable3 = new Hashtable();
		RectangleF rectangleF_ = new RectangleF(0f, 0f, 1800f, 100f);
		RowCollection rows = cells_0.Rows;
		for (int j = 0; j < rows.Count; j++)
		{
			Row rowByIndex = rows.GetRowByIndex(j);
			if (rowByIndex.int_0 < int_0)
			{
				continue;
			}
			if (rowByIndex.int_0 > int_1)
			{
				break;
			}
			ArrayList cells = rowByIndex.Cells;
			for (int k = 0; k < cells.Count; k++)
			{
				Cell cell = (Cell)cells[k];
				if (cell.Column < int_2)
				{
					continue;
				}
				if (cell.Column > int_3)
				{
					break;
				}
				if (hashtable[cell.Column] != null || smethod_6(cells_0, cell.Row, cell.Column))
				{
					continue;
				}
				if (hashtable2[cell.Column] == null)
				{
					hashtable2[cell.Column] = 0;
				}
				string text = cell.method_25(1, bool_0: false);
				if (text == null || text == "")
				{
					continue;
				}
				Style style = cell.method_33(defaultStyle);
				if (smethod_3(cells_0, cell.Row, cell.Column))
				{
					int num = smethod_1(graphics_0, style, text, int_4, rectangleF_);
					num += 20;
					int num2 = (int)hashtable2[cell.Column];
					if (num2 < num)
					{
						hashtable2[cell.Column] = num;
					}
					continue;
				}
				if (style.RotationAngle != 0 && style.RotationAngle != 255)
				{
					int num3 = smethod_1(graphics_0, style, text, int_4, rectangleF_);
					int num4 = (int)hashtable2[cell.Column];
					if (num4 < num3)
					{
						hashtable2[cell.Column] = num3;
					}
					continue;
				}
				ArrayList arrayList = (ArrayList)hashtable3[cell.Column];
				if (arrayList == null)
				{
					arrayList = new ArrayList();
					hashtable3[cell.Column] = arrayList;
				}
				if (style.HorizontalAlignment == TextAlignmentType.CenterAcross && k != rowByIndex.method_0() - 1)
				{
					Cell cellByIndex = rowByIndex.GetCellByIndex(k + 1);
					Style style2 = null;
					if (cellByIndex.Column == cell.Column + 1)
					{
						if (cellByIndex.IsBlank)
						{
							style2 = cellByIndex.method_33(defaultStyle);
						}
					}
					else
					{
						int num5 = rowByIndex.method_10();
						if (num5 < 0 || num5 == 15)
						{
							Column column = cells_0.Columns.method_5(cell.Column + 1);
							if (column != null)
							{
								num5 = column.method_5();
							}
						}
						style2 = ((num5 < 0 || num5 == 15) ? defaultStyle : cells_0.method_19().method_58()[num5]);
					}
					if (style2 != null && style2.HorizontalAlignment == TextAlignmentType.CenterAcross)
					{
						continue;
					}
				}
				smethod_5(arrayList, style, text);
			}
		}
		IDictionaryEnumerator enumerator = hashtable3.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ArrayList arrayList2 = (ArrayList)enumerator.Value;
			int num6 = (int)enumerator.Key;
			int num7 = 0;
			for (int l = 0; l < arrayList2.Count; l++)
			{
				Class10 class10_ = (Class10)arrayList2[l];
				int num8 = smethod_2(class10_, int_4, rectangleF_);
				if (num7 < num8)
				{
					num7 = num8;
				}
			}
			int num9 = (int)hashtable2[num6];
			if (num7 > num9)
			{
				hashtable2[num6] = num7;
			}
		}
		IDictionaryEnumerator enumerator2 = hashtable2.GetEnumerator();
		if (cells_0.method_19().Workbook.method_24())
		{
			_ = 1048575;
		}
		else
			_ = 65535;
		while (enumerator2.MoveNext())
		{
			int num10 = (int)enumerator2.Value;
			if (num10 != 0)
			{
				cells_0.method_16((int)enumerator2.Key, num10);
				cells_0.Columns[(int)enumerator2.Key].method_17(bool_0: true);
			}
		}
	}

	private static void smethod_5(ArrayList arrayList_0, Style style_0, string string_0)
	{
		FontStyle fontStyle = FontStyle.Regular;
		int num = 10;
		string text = "Arial";
		if (style_0.method_40() != null)
		{
			Aspose.Cells.Font font = style_0.method_40();
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
			text = font.Name;
			num = font.Size;
		}
		if (style_0.IsTextWrapped)
		{
			string[] array = string_0.Split('\n');
			if (array.Length > 1)
			{
				string_0 = ((array[0] == null) ? "" : array[0]);
				for (int i = 1; i < array.Length; i++)
				{
					if (array[i] != null && array[i].Length > string_0.Length)
					{
						string_0 = array[i];
					}
				}
			}
		}
		int num2 = 0;
		Class10 @class;
		while (true)
		{
			if (num2 < arrayList_0.Count)
			{
				@class = (Class10)arrayList_0[num2];
				if (@class.string_0 == text && @class.int_0 == num && @class.fontStyle_0 == fontStyle)
				{
					break;
				}
				num2++;
				continue;
			}
			Class10 class2 = new Class10();
			class2.string_0 = text;
			class2.int_0 = num;
			class2.fontStyle_0 = fontStyle;
			class2.arrayList_0.Add(string_0);
			arrayList_0.Add(class2);
			return;
		}
		int num3 = 0;
		while (true)
		{
			if (num3 < @class.arrayList_0.Count)
			{
				string text2 = (string)@class.arrayList_0[num3];
				if (!(text2 == string_0))
				{
					if (text2.Length < string_0.Length)
					{
						break;
					}
					num3++;
					continue;
				}
				return;
			}
			if (@class.arrayList_0.Count < 10)
			{
				@class.arrayList_0.Add(string_0);
			}
			return;
		}
		@class.arrayList_0.Insert(num3, string_0);
		if (@class.arrayList_0.Count > 10)
		{
			@class.arrayList_0.RemoveAt(10);
		}
	}

	private static bool smethod_6(Cells cells_0, int int_0, int int_1)
	{
		int num = 0;
		CellArea cellArea;
		while (true)
		{
			if (num < cells_0.method_18().Count)
			{
				cellArea = cells_0.method_18()[num];
				if (cellArea.StartRow <= int_0 && cellArea.EndRow >= int_0 && cellArea.StartColumn <= int_1 && cellArea.EndColumn >= int_1)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return cellArea.StartColumn != cellArea.EndColumn;
	}
}
