using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Properties;
using ns1;
using ns22;

namespace ns8;

internal class Class734
{
	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private Worksheet worksheet_0;

	private Cells cells_0;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	private Style style_0;

	private Style style_1;

	private ArrayList arrayList_0;

	private int int_0;

	private ArrayList arrayList_1;

	private Class777 class777_0;

	private readonly string string_0 = "#A0A0A0";

	private string string_1 = "15.0pt";

	private HTMLLoadOptions htmlloadOptions_0 = new HTMLLoadOptions();

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9;

	private int int_10;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private Style style_2;

	private Hashtable hashtable_2;

	private ICustomParser icustomParser_0;

	private ICustomParser icustomParser_1;

	private string string_2;

	private Class735 class735_0;

	private IStreamProvider istreamProvider_0;

	public WorksheetCollection Worksheets => worksheetCollection_0;

	public Workbook Workbook => workbook_0;

	[SpecialName]
	public void method_0(IStreamProvider istreamProvider_1)
	{
		istreamProvider_0 = istreamProvider_1;
	}

	public Class734(Workbook workbook_1, Class735 class735_1)
	{
		workbook_0 = workbook_1;
		worksheetCollection_0 = workbook_1.Worksheets;
		int_1 = -1;
		int_2 = -1;
		int_3 = 0;
		bool_0 = false;
		bool_9 = false;
		int_4 = 0;
		int_5 = 0;
		hashtable_0 = new Hashtable();
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
		hashtable_2 = new Hashtable();
		icustomParser_0 = workbook_0.Settings.method_3().method_7();
		icustomParser_1 = workbook_0.Settings.method_3().method_6();
		string_2 = "";
		class735_0 = class735_1;
	}

	public void method_1(Hashtable hashtable_3)
	{
		int_1++;
		int_2 = -1;
		if (hashtable_3 != null && hashtable_3.Count > 0)
		{
			method_2(hashtable_3);
		}
	}

	private void method_2(Hashtable hashtable_3)
	{
		string text = (string)hashtable_3["height"];
		if (text == null)
		{
			text = string_1;
		}
		int int_ = Class733.smethod_5(text);
		string text2 = (string)hashtable_3["style"];
		if (text2 != null)
		{
			method_3(text2, int_);
		}
	}

	private void method_3(string string_3, int int_11)
	{
		bool flag = false;
		Class728 @class = new Class728();
		@class.method_9(string_3);
		ArrayList arrayList = @class.method_3();
		foreach (Class724 item in arrayList)
		{
			switch (item.Name)
			{
			case "height":
				if (cells_0 == null)
				{
					workbook_0.Worksheets[0].Cells.SetRowHeightPixel(int_1, int_11);
				}
				break;
			case "mso-xlrowspan":
			{
				flag = true;
				int num = Convert.ToInt32(item.Value);
				for (int i = 0; i < num; i++)
				{
					cells_0.SetRowHeightPixel(int_1 + i, int_11 / num);
				}
				int_1 += num - 1;
				break;
			}
			}
		}
		if (!flag && cells_0 != null)
		{
			cells_0.SetRowHeightPixel(int_1, int_11);
		}
	}

	public void method_4(Hashtable hashtable_3)
	{
		int_2++;
		int num = -1;
		object obj = hashtable_3["width"];
		if (obj != null)
		{
			num = Convert.ToInt32((string)obj);
		}
		int num2 = 0;
		obj = hashtable_3["span"];
		if (obj != null)
		{
			num2 = Convert.ToInt32((string)obj);
		}
		if (num2 > 0)
		{
			int_2 += num2 - 1;
		}
		if (num == 0)
		{
			if (num2 > 0)
			{
				for (int i = 0; i < num2; i++)
				{
					cells_0.HideColumn(int_3);
					int_3++;
				}
			}
			else
			{
				cells_0.HideColumn(int_3);
				int_3++;
			}
		}
		else if (num2 > 0)
		{
			for (int j = 0; j < num2; j++)
			{
				if (cells_0 != null)
				{
					cells_0.SetColumnWidthPixel(int_3, num);
					int_3++;
				}
			}
		}
		else
		{
			cells_0.Columns[int_3].method_2(num);
			int_3++;
		}
	}

	public void method_5(Hashtable hashtable_3)
	{
		bool_0 = true;
		int_2++;
		if (arrayList_0.Count > 0)
		{
			method_60();
		}
		object obj = hashtable_3["colspan"];
		if (obj != null)
		{
			int_5 = Convert.ToInt32(method_6((string)obj));
		}
		else
		{
			int_5 = 0;
		}
		obj = hashtable_3["rowspan"];
		if (obj != null)
		{
			int_4 = Convert.ToInt32(method_6((string)obj));
		}
		else
		{
			int_4 = 0;
		}
		Cell cell = method_11();
		if (cell == null)
		{
			return;
		}
		object obj2 = hashtable_3["class"];
		if (obj2 != null)
		{
			int num = 15;
			if (hashtable_0 != null && hashtable_0.ContainsKey((string)obj2))
			{
				num = (int)hashtable_0[(string)obj2];
			}
			style_0 = Worksheets.method_58()[num];
		}
		cell.method_30(style_0);
		method_13();
	}

	private string method_6(string string_3)
	{
		if (string_3.StartsWith("'") && string_3.EndsWith("'"))
		{
			return string_3.Replace("'", "");
		}
		return string_3;
	}

	public void method_7(Hashtable hashtable_3)
	{
		bool_0 = true;
		int_2++;
		if (arrayList_0.Count > 0)
		{
			method_60();
		}
		object obj = hashtable_3["colspan"];
		if (obj != null)
		{
			int_5 = Convert.ToInt32(method_6((string)obj));
		}
		else
		{
			int_5 = 0;
		}
		obj = hashtable_3["rowspan"];
		if (obj != null)
		{
			int_4 = Convert.ToInt32(method_6((string)obj));
		}
		else
		{
			int_4 = 0;
		}
		object obj2 = hashtable_3["class"];
		if (obj2 == null)
		{
			obj2 = hashtable_3["CLASS"];
		}
		int num = 15;
		if (obj2 != null)
		{
			if (hashtable_0 != null && hashtable_0.ContainsKey((string)obj2))
			{
				num = (int)hashtable_0[(string)obj2];
			}
		}
		else if (hashtable_0 != null && hashtable_0.ContainsKey("td"))
		{
			num = (int)hashtable_0["td"];
		}
		style_0 = Worksheets.method_58()[num];
		if (style_0 == null)
		{
			style_0 = new Style();
		}
		Cell cell = method_11();
		if (cell == null)
		{
			return;
		}
		cell.method_37(num);
		if (style_1 != null)
		{
			cell.method_30(style_1);
		}
		object obj3 = hashtable_3["width"];
		obj = hashtable_3["style"];
		Style style = null;
		if (obj != null)
		{
			string text = (string)obj;
			if ((!text.StartsWith("width") && !text.StartsWith("height")) || !text.EndsWith("pt"))
			{
				style = method_9(text, style_0, cell);
				if (int_10 == 1)
				{
					Range range = new Range(int_1, int_2, 1, int_5, cells_0);
					range.method_2(num);
				}
			}
		}
		else if (obj3 != null && obj3.ToString().IndexOf("%") == -1)
		{
			int pixel = Class733.smethod_5(obj3.ToString());
			cells_0.SetColumnWidthPixel(int_2, pixel);
		}
		if (style == null)
		{
			method_12(obj2, style_0);
		}
		else
		{
			method_12(obj2, style);
		}
		object obj4 = hashtable_3["align"];
		if (obj4 != null)
		{
			Style style2 = cell.GetStyle();
			style2.HorizontalAlignment = method_10(obj4.ToString());
			cell.method_30(style2);
		}
		object obj5 = hashtable_3["valign"];
		if (obj5 != null)
		{
			Style style3 = cell.GetStyle();
			style3.VerticalAlignment = method_10(obj5.ToString());
			cell.method_30(style3);
		}
		method_57(obj2, cell);
		if (htmlloadOptions_0.LoadFormulas)
		{
			obj = hashtable_3["x:fmla"];
			method_61(obj, cell, hashtable_3);
		}
		obj = hashtable_3["x:num"];
		method_63(obj, cell);
		obj = hashtable_3["x:bool"];
		obj = hashtable_3["x:str"];
		obj = hashtable_3["x:err"];
	}

	public void method_8(Hashtable hashtable_3)
	{
		if (hashtable_0 == null)
		{
			return;
		}
		object obj = hashtable_3["class"];
		string text = (string)obj;
		if (text != null)
		{
			int num = 15;
			if (hashtable_0.ContainsKey(text))
			{
				num = (int)hashtable_0[text];
				style_1 = Worksheets.method_58()[num];
			}
		}
	}

	private Style method_9(string string_3, Style style_3, Cell cell_0)
	{
		Style style = new Style(worksheetCollection_0);
		if (style_3 != null)
		{
			style.Copy(style_3);
		}
		Class728 @class = new Class728();
		@class.method_9(string_3);
		ArrayList arrayList = @class.method_3();
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		foreach (Class724 item in arrayList)
		{
			string name;
			if ((name = item.Name) == null)
			{
				continue;
			}
			if (Class1742.dictionary_18 == null)
			{
				Class1742.dictionary_18 = new Dictionary<string, int>(23)
				{
					{ "mso-ignore", 0 },
					{ "background", 1 },
					{ "mso-pattern", 2 },
					{ "border-right", 3 },
					{ "border-bottom", 4 },
					{ "border-bottom-color", 5 },
					{ "border-bottom-style", 6 },
					{ "border-bottom-width", 7 },
					{ "white-space", 8 },
					{ "border", 9 },
					{ "border-color", 10 },
					{ "vertical-align", 11 },
					{ "font-size", 12 },
					{ "font-family", 13 },
					{ "font-weight", 14 },
					{ "color", 15 },
					{ "background-color", 16 },
					{ "width", 17 },
					{ "border-top", 18 },
					{ "border-top-color", 19 },
					{ "border-left", 20 },
					{ "border-left-color", 21 },
					{ "text-decoration", 22 }
				};
			}
			if (!Class1742.dictionary_18.TryGetValue(name, out var value))
			{
				continue;
			}
			switch (value)
			{
			case 0:
				if (item.Value.Equals("colspan"))
				{
					int_10 = 1;
				}
				else if (item.Value.Equals("colspan-rowspan"))
				{
					int_10 = 2;
				}
				else
				{
					int_10 = 0;
				}
				break;
			case 1:
				if (item.Value != "auto")
				{
					text = item.Value;
				}
				break;
			case 2:
				text3 = item.Value;
				break;
			case 3:
			{
				string[] array5 = item.Value.Split(' ');
				Border border6 = style.Borders[BorderType.RightBorder];
				if (array5.Length == 3)
				{
					string text19 = array5[0];
					string text20 = array5[1];
					string text21 = array5[2];
					border6.Color = Class732.smethod_10(text21);
					CellBorderType lineStyle9 = Class731.smethod_0(text19 + " " + text20);
					border6.LineStyle = lineStyle9;
				}
				else if (array5.Length == 2)
				{
					CellBorderType lineStyle10 = Class731.smethod_0(item.Value);
					border6.LineStyle = lineStyle10;
				}
				else
				{
					border6.LineStyle = CellBorderType.None;
				}
				break;
			}
			case 4:
			{
				string[] array2 = item.Value.Split(' ');
				Border border3 = style.Borders[BorderType.BottomBorder];
				if (array2.Length == 3)
				{
					if (item.Value.IndexOf("px") > -1)
					{
						string text9 = array2[1];
						string text10 = array2[2];
						string text11 = array2[0];
						border3.Color = Class732.smethod_10(text11);
						CellBorderType lineStyle3 = Class731.smethod_0(text9 + " " + text10);
						border3.LineStyle = lineStyle3;
					}
					else
					{
						string text12 = array2[0];
						string text13 = array2[1];
						string text14 = array2[2];
						border3.Color = Class732.smethod_10(text14);
						CellBorderType lineStyle4 = Class731.smethod_0(text12 + " " + text13);
						border3.LineStyle = lineStyle4;
					}
				}
				else if (array2.Length == 2)
				{
					CellBorderType lineStyle5 = Class731.smethod_0(item.Value);
					border3.LineStyle = lineStyle5;
				}
				else
				{
					border3.LineStyle = CellBorderType.None;
				}
				break;
			}
			case 5:
				style.Borders[BorderType.BottomBorder].Color = Class732.smethod_10(item.Value);
				break;
			case 6:
				text4 = item.Value;
				break;
			case 7:
				text5 = item.Value;
				break;
			case 9:
			{
				string[] array4 = item.Value.Split(' ');
				if (array4.Length == 3)
				{
					CellBorderType lineStyle8 = Class731.smethod_0(array4[0] + " " + array4[1]);
					style.Borders[BorderType.BottomBorder].LineStyle = lineStyle8;
					style.Borders[BorderType.TopBorder].LineStyle = lineStyle8;
					style.Borders[BorderType.LeftBorder].LineStyle = lineStyle8;
					style.Borders[BorderType.RightBorder].LineStyle = lineStyle8;
					string text18 = array4[2];
					if (text18 == "windowtext")
					{
						Color color = Class732.smethod_10(string_0);
						style.Borders[BorderType.BottomBorder].Color = color;
						style.Borders[BorderType.TopBorder].Color = color;
						style.Borders[BorderType.LeftBorder].Color = color;
						style.Borders[BorderType.RightBorder].Color = color;
					}
					else
					{
						Color color2 = Class732.smethod_10(text18);
						style.Borders[BorderType.BottomBorder].Color = color2;
						style.Borders[BorderType.TopBorder].Color = color2;
						style.Borders[BorderType.LeftBorder].Color = color2;
						style.Borders[BorderType.RightBorder].Color = color2;
					}
				}
				break;
			}
			case 12:
				style.Font.DoubleSize = Class733.smethod_6(item.Value);
				break;
			case 13:
				Class733.smethod_8(item.Value, style.Font);
				break;
			case 14:
				if (item.Value.ToLower() == "bold")
				{
					style.Font.IsBold = true;
				}
				else
				{
					style.Font.Weight = Class733.smethod_7(item.Value);
				}
				break;
			case 15:
				style.Font.Color = Class732.smethod_10(item.Value);
				break;
			case 16:
				if (item.Value != "auto")
				{
					text2 = item.Value;
				}
				break;
			case 17:
			{
				if (item.Value.IndexOf("%") != -1)
				{
					break;
				}
				int num = Class733.smethod_5(item.Value);
				object obj = hashtable_2[int_2];
				if (int_5 <= 1)
				{
					if (obj == null)
					{
						hashtable_2.Add(int_2, num);
					}
					else if ((int)obj < num)
					{
						hashtable_2[int_2] = num;
					}
				}
				break;
			}
			case 18:
			{
				string[] array3 = item.Value.Split(' ');
				Border border5 = style.Borders[BorderType.TopBorder];
				if (array3.Length == 3)
				{
					string text15 = array3[0];
					string text16 = array3[1];
					string text17 = array3[2];
					border5.Color = Class732.smethod_10(text17);
					CellBorderType lineStyle6 = Class731.smethod_0(text15 + " " + text16);
					border5.LineStyle = lineStyle6;
				}
				else if (array3.Length == 2)
				{
					CellBorderType lineStyle7 = Class731.smethod_0(item.Value);
					border5.LineStyle = lineStyle7;
				}
				else
				{
					border5.LineStyle = CellBorderType.None;
				}
				break;
			}
			case 19:
			{
				Border border4 = style.Borders[BorderType.TopBorder];
				border4.Color = Class732.smethod_10(item.Value);
				break;
			}
			case 20:
			{
				string[] array = item.Value.Split(' ');
				Border border2 = style.Borders[BorderType.LeftBorder];
				if (array.Length == 3)
				{
					string text6 = array[0];
					string text7 = array[1];
					string text8 = array[2];
					border2.Color = Class732.smethod_10(text8);
					CellBorderType lineStyle = Class731.smethod_0(text6 + " " + text7);
					border2.LineStyle = lineStyle;
				}
				else if (array.Length == 2)
				{
					CellBorderType lineStyle2 = Class731.smethod_0(item.Value);
					border2.LineStyle = lineStyle2;
				}
				else
				{
					border2.LineStyle = CellBorderType.None;
				}
				break;
			}
			case 21:
			{
				Border border = style.Borders[BorderType.LeftBorder];
				border.Color = Class732.smethod_10(item.Value);
				break;
			}
			case 22:
				if (item.Value.Trim() == "underline")
				{
					style.Font.Underline = Class732.smethod_7(item.Value);
				}
				else if (item.Value.Trim() == "line-through")
				{
					style.Font.IsStrikeout = true;
				}
				break;
			}
		}
		if (text4 != null && text5 != null)
		{
			style.Borders[BorderType.BottomBorder].LineStyle = Class731.smethod_0(text5 + " " + text4);
		}
		if ((text != null || text2 != null) && text3 == null)
		{
			style.Pattern = BackgroundType.Solid;
			style.ForegroundColor = Class732.smethod_10((text == null) ? text2 : text);
		}
		if (text == null && text2 == null && text3 != null)
		{
			Class732.smethod_8(text3, style);
		}
		if ((text != null || text2 != null) && text3 != null)
		{
			Color color_ = Class732.smethod_10((text == null) ? text2 : text);
			Class732.smethod_9(text3, style, color_);
		}
		cell_0.method_30(style);
		return style;
	}

	private TextAlignmentType method_10(string string_3)
	{
		return string_3 switch
		{
			"bottom" => TextAlignmentType.Bottom, 
			"top" => TextAlignmentType.Top, 
			"center" => TextAlignmentType.Center, 
			"right" => TextAlignmentType.Right, 
			"left" => TextAlignmentType.Left, 
			_ => TextAlignmentType.Right, 
		};
	}

	public Cell method_11()
	{
		if (cells_0 == null)
		{
			cells_0 = Worksheets[0].Cells;
		}
		if (cells_0 != null && int_1 != -1 && int_2 != -1)
		{
			return cells_0[int_1, int_2];
		}
		return null;
	}

	private void method_12(object object_0, Style style_3)
	{
		if (int_10 != 1 && (int_4 > 0 || int_5 > 0))
		{
			if (object_0 != null)
			{
				StyleFlag styleFlag = new StyleFlag();
				styleFlag.All = true;
				if (int_4 == 0)
				{
					Range range = cells_0.CreateRange(int_1, int_2, 1, int_5);
					range.ApplyStyle(style_3, styleFlag);
				}
				else if (int_5 == 0)
				{
					Range range2 = cells_0.CreateRange(int_1, int_2, int_4, 1);
					range2.ApplyStyle(style_3, styleFlag);
				}
				else
				{
					Range range3 = cells_0.CreateRange(int_1, int_2, int_4, int_5);
					range3.ApplyStyle(style_3, styleFlag);
				}
			}
			if (int_5 == 0)
			{
				if (int_10 == 0)
				{
					cells_0.Merge(int_1, int_2, int_4, 1);
				}
				CellArea cellArea_ = default(CellArea);
				method_58(int_1, int_2, int_1 + int_4 - 1, int_2, ref cellArea_);
				arrayList_0.Add(cellArea_);
			}
			else if (int_4 == 0)
			{
				if (int_10 == 0 && !cells_0.method_18().method_1(int_1, int_2))
				{
					cells_0.Merge(int_1, int_2, 1, int_5);
				}
				CellArea cellArea_2 = default(CellArea);
				method_58(int_1, int_2, int_1, int_2 + int_4 - 1, ref cellArea_2);
				arrayList_0.Add(cellArea_2);
			}
			else
			{
				if (int_10 == 0)
				{
					cells_0.Merge(int_1, int_2, int_4, int_5);
				}
				CellArea cellArea_3 = default(CellArea);
				method_58(int_1, int_2, int_1 + int_4 - 1, int_2 + int_5 - 1, ref cellArea_3);
				arrayList_0.Add(cellArea_3);
			}
			bool_8 = true;
		}
		else
		{
			bool_8 = false;
		}
	}

	private void method_13()
	{
		if (int_10 != 1 && (int_4 > 0 || int_5 > 0))
		{
			if (int_5 == 0)
			{
				if (int_10 == 0)
				{
					cells_0.Merge(int_1, int_2, int_4, 1);
				}
				CellArea cellArea_ = default(CellArea);
				method_58(int_1, int_2, int_1 + int_4 - 1, int_2, ref cellArea_);
				arrayList_0.Add(cellArea_);
			}
			else if (int_4 == 0)
			{
				if (int_10 == 0 && !cells_0.method_18().method_1(int_1, int_2))
				{
					cells_0.Merge(int_1, int_2, 1, int_5);
				}
				CellArea cellArea_2 = default(CellArea);
				method_58(int_1, int_2, int_1, int_2 + int_4 - 1, ref cellArea_2);
				arrayList_0.Add(cellArea_2);
			}
			else
			{
				if (int_10 == 0)
				{
					cells_0.Merge(int_1, int_2, int_4, int_5);
				}
				CellArea cellArea_3 = default(CellArea);
				method_58(int_1, int_2, int_1 + int_4 - 1, int_2 + int_5 - 1, ref cellArea_3);
				arrayList_0.Add(cellArea_3);
			}
			bool_8 = true;
		}
		else
		{
			bool_8 = false;
		}
	}

	public void method_14(Hashtable hashtable_3)
	{
	}

	public void method_15()
	{
		int_6 = 0;
		int_7 = 0;
	}

	public void method_16(Hashtable hashtable_3)
	{
		object obj = hashtable_3["colspan"];
		object obj2 = hashtable_3["rowspan"];
		if (obj != null)
		{
			int_9 = int.Parse((string)obj) - 1;
		}
		if (obj2 != null)
		{
			int_8 = int.Parse((string)obj2);
		}
	}

	public void method_17()
	{
		int_9 = 0;
		int_8 = 0;
	}

	public void method_18(Hashtable hashtable_3)
	{
		if (worksheet_0 != null && !bool_16)
		{
			if (hashtable_3["href"] != null && int_1 > -1 && int_2 > -1)
			{
				worksheet_0.Hyperlinks.Add(int_1, int_2, 1, 1, method_20((string)hashtable_3["href"]));
				bool_4 = true;
			}
			if (hashtable_3["name"] != null && int_1 > -1 && int_2 > -1)
			{
				int index = worksheetCollection_0.Names.Add((string)hashtable_3["name"]);
				Name name = worksheetCollection_0.Names[index];
				CellArea cellArea_ = default(CellArea);
				cellArea_.StartColumn = int_2;
				cellArea_.EndColumn = int_2;
				cellArea_.StartRow = int_1;
				cellArea_.EndRow = int_1;
				name.SetRange(worksheet_0.Index, cellArea_);
			}
		}
	}

	public void method_19(bool bool_18)
	{
		bool_16 = bool_18;
	}

	private string method_20(string string_3)
	{
		if (!(string_3 == "../#") && !(string_3 == "#"))
		{
			if (string_3.IndexOf("&#") > 0)
			{
				string_3 = string_3.Replace("&#47;", "/").Replace("&#58;", ":").Replace("&#61;", "=")
					.Replace("&#63;", "?");
			}
			if (string_3.IndexOf("#") > -1)
			{
				if (!string_3.StartsWith("#") && !string_3.StartsWith("null#"))
				{
					string[] array = string_3.Split('#');
					if (array.Length < 2)
					{
						return string_3;
					}
					string[] array2 = array[0].Split('.');
					string[] array3 = array2[0].Split('t');
					if (array3.Length < 2)
					{
						return string_3;
					}
					string[] array4 = array[1].Split('!');
					if (array4.Length < 2)
					{
						return string_3;
					}
					int index = int.Parse(array3[1]) - 1;
					return "'" + worksheetCollection_0[index].Name + "'!" + array4[1];
				}
				string[] array5 = string_3.Split('!');
				if (array5.Length < 2)
				{
					return string_3;
				}
				return array5[1];
			}
			if (string_3.IndexOf("../") > -1)
			{
				return string_3.Substring(3);
			}
			if (string_3.StartsWith("http://"))
			{
				return string_3;
			}
			return string_3 + "!A1";
		}
		return string_3;
	}

	public void method_21(Hashtable hashtable_3)
	{
		string text = (string)hashtable_3["v:shapes"];
		string origPath = (string)hashtable_3["src"];
		if (origPath.StartsWith("file:///") && origPath.IndexOf("\\") > -1)
		{
			origPath = origPath.Replace("\\", "/");
		}
		if (text == null)
		{
			Class736 @class = (Class736)hashtable_1["SavedByAspose"];
			if (@class != null)
			{
				int num = -1;
				if (@class.method_2() == null)
				{
					Stream stream = istreamProvider_0.GetStream(ref origPath, @class.method_6() + origPath);
					if (stream == null)
					{
						return;
					}
					num = worksheet_0.Pictures.Add(int_1, int_2, stream);
				}
				else
				{
					num = worksheet_0.Pictures.Add(int_1, int_2, @class.method_2());
				}
				Picture picture = worksheet_0.Pictures[num];
				int width = @class.Width;
				int height = @class.Height;
				int top = @class.Top;
				int left = @class.Left;
				int[] array = picture.method_40(int_1, 0, top);
				int[] array2 = picture.method_45(int_2, 0, left);
				picture.Placement = PlacementType.Move;
				picture.method_19(array[0], array[1], array2[0], array2[1], height, width);
				hashtable_1.Remove("SavedByAspose");
				return;
			}
			if (worksheet_0 == null)
			{
				worksheet_0 = worksheetCollection_0[0];
			}
			if (Path.IsPathRooted(origPath))
			{
				if (File.Exists(origPath))
				{
					worksheet_0.Pictures.Add(int_1, int_2, origPath);
				}
				return;
			}
			string text2 = htmlloadOptions_0.AttachedFilesDirectory;
			if (text2 != null && !text2.EndsWith("/") && !text2.EndsWith("\\"))
			{
				text2 += "\\";
			}
			if (text2 == null)
			{
				text2 = "";
			}
			string text3 = text2 + origPath;
			if (File.Exists(text3))
			{
				worksheet_0.Pictures.Add(int_1, int_2, text2 + origPath);
				return;
			}
			try
			{
				method_22(text3);
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		string[] array3 = text.Split(' ');
		string[] array4 = array3;
		foreach (string key in array4)
		{
			Class736 class2 = null;
			try
			{
				class2 = (Class736)hashtable_1[key];
				if (class2 != null)
				{
					int num2 = -1;
					num2 = ((class2.method_2() != null) ? worksheet_0.Pictures.Add(int_1, int_2, class2.method_2()) : worksheet_0.Pictures.Add(int_1, int_2, istreamProvider_0.GetStream(ref origPath, class2.method_6() + origPath)));
					Picture picture2 = worksheet_0.Pictures[num2];
					int width2 = class2.Width;
					int height2 = class2.Height;
					int top2 = class2.Top;
					int left2 = class2.Left;
					int[] array5 = picture2.method_40(int_1, 0, top2);
					int[] array6 = picture2.method_45(int_2, 0, left2);
					picture2.method_19(array5[0], array5[1], array6[0], array6[1], height2, width2);
					picture2.Placement = class2.Placement;
					picture2.IsPrintable = class2.IsPrintable;
					picture2.IsLocked = class2.IsLocked;
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (class2 != null && class2.method_2() != null)
				{
					class2.method_2().Close();
				}
			}
		}
	}

	private void method_22(string string_3)
	{
		if (method_23(string_3))
		{
			byte[] buffer = Convert.FromBase64String(string_3.Substring(string_3.IndexOf(',') + 1));
			Stream stream = new MemoryStream(buffer);
			worksheet_0.Pictures.Add(int_1, int_2, stream);
		}
		if (method_24(string_3))
		{
			Stream stream2 = Class1186.smethod_8(string_3);
			if (stream2 != null)
			{
				worksheet_0.Pictures.Add(int_1, int_2, stream2);
			}
		}
	}

	private bool method_23(string string_3)
	{
		if (string_3.StartsWith("data:image") && string_3.IndexOf("base64") > -1)
		{
			return true;
		}
		return false;
	}

	private bool method_24(string string_3)
	{
		if (!string_3.StartsWith("http://") && !string_3.StartsWith("file://") && !string_3.StartsWith("ftp://"))
		{
			return false;
		}
		return true;
	}

	public void method_25(Hashtable hashtable_3)
	{
		bool_14 = true;
		bool_15 = true;
	}

	public void method_26(Hashtable hashtable_3)
	{
		object obj = hashtable_3["style"];
		if (obj == null)
		{
			return;
		}
		Cell cell = method_11();
		if (cell == null)
		{
			return;
		}
		Style style = new Style(worksheetCollection_0);
		if (cell.GetStyle() != null)
		{
			style.Copy(cell.GetStyle());
		}
		Class728 @class = new Class728();
		@class.method_9((string)obj);
		ArrayList arrayList = @class.method_3();
		foreach (Class724 item in arrayList)
		{
			string name;
			if ((name = item.Name) != null && name == "margin")
			{
				string[] array = item.Value.Split(' ');
				if (array.Length == 4 && array[3] == "18pt")
				{
					style.IndentLevel = 1;
				}
			}
		}
		cell.method_30(style);
	}

	public void method_27(Hashtable hashtable_3)
	{
		object obj = hashtable_3["style"];
		if (obj == null)
		{
			return;
		}
		Cell cell = method_11();
		if (cell == null)
		{
			return;
		}
		Style style = new Style(worksheetCollection_0);
		if (cell.GetStyle() != null)
		{
			style.Copy(cell.GetStyle());
		}
		Class728 @class = new Class728();
		@class.method_9((string)obj);
		ArrayList arrayList = @class.method_3();
		foreach (Class724 item in arrayList)
		{
			switch (item.Name)
			{
			case "vertical-align":
				if (item.Value == "super")
				{
					style.Font.IsSuperscript = true;
				}
				if (item.Value == "sub")
				{
					style.Font.IsSubscript = true;
				}
				if (item.Value == "top")
				{
					style.VerticalAlignment = TextAlignmentType.Top;
				}
				break;
			case "font-family":
				Class733.smethod_8(item.Value, style.Font);
				break;
			case "font-weight":
				if (item.Value.ToLower() == "bold")
				{
					style.Font.IsBold = true;
				}
				break;
			case "font-size":
				style.Font.DoubleSize = Class733.smethod_6(item.Value);
				break;
			}
		}
		cell.method_30(style);
	}

	public void method_28(Hashtable hashtable_3)
	{
		bool_17 = true;
		int_2 = 0;
		object obj = hashtable_3["style"];
		if (obj == null)
		{
			return;
		}
		method_11();
		style_2 = new Style(worksheetCollection_0);
		if (style_0 != null)
		{
			style_2.Copy(style_0);
		}
		Class728 @class = new Class728();
		@class.method_9((string)obj);
		ArrayList arrayList = @class.method_3();
		foreach (Class724 item in arrayList)
		{
			string name;
			if ((name = item.Name) == null)
			{
				continue;
			}
			if (Class1742.dictionary_19 == null)
			{
				Class1742.dictionary_19 = new Dictionary<string, int>(7)
				{
					{ "color", 0 },
					{ "font-size", 1 },
					{ "font-weight", 2 },
					{ "font-family", 3 },
					{ "font-style", 4 },
					{ "text-decoration", 5 },
					{ "vertical-align", 6 }
				};
			}
			if (!Class1742.dictionary_19.TryGetValue(name, out var value))
			{
				continue;
			}
			switch (value)
			{
			case 0:
				style_2.Font.Color = Class732.smethod_10(item.Value);
				break;
			case 1:
				style_2.Font.DoubleSize = Class733.smethod_6(item.Value);
				break;
			case 2:
				if (item.Value.ToLower() == "bold")
				{
					style_2.Font.IsBold = true;
				}
				break;
			case 3:
				Class733.smethod_8(item.Value, style_2.Font);
				break;
			case 6:
				if (item.Value == "super")
				{
					style_2.Font.IsSuperscript = true;
				}
				if (item.Value == "sub")
				{
					style_2.Font.IsSubscript = true;
				}
				break;
			}
		}
	}

	public void method_29(Hashtable hashtable_3)
	{
		bool_17 = true;
		object obj = hashtable_3["style"];
		if (obj != null)
		{
			method_11();
			style_2 = new Style(worksheetCollection_0);
			if (style_0 != null)
			{
				style_2.Copy(style_0);
			}
		}
	}

	public void method_30(Hashtable hashtable_3, string string_3)
	{
		string text = (string)hashtable_3["style"];
		if (text.IndexOf("z-index") <= -1 || hashtable_1.Count != 0)
		{
			return;
		}
		string[] array = text.Split(';');
		Class736 @class = new Class736();
		@class.method_1("SavedByAspose");
		@class.method_7(string_3);
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':');
			string text2 = array2[0].Trim();
			string text3 = array2[1].Trim();
			string key;
			if ((key = text2) == null)
			{
				continue;
			}
			if (Class1742.dictionary_20 == null)
			{
				Class1742.dictionary_20 = new Dictionary<string, int>(7)
				{
					{ "mso-ignore", 0 },
					{ "position", 1 },
					{ "z-index", 2 },
					{ "margin-left", 3 },
					{ "margin-top", 4 },
					{ "width", 5 },
					{ "height", 6 }
				};
			}
			if (Class1742.dictionary_20.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 3:
					@class.Left = Class733.smethod_5(text3);
					break;
				case 4:
					@class.Top = Class733.smethod_5(text3);
					break;
				case 5:
					@class.Width = Class733.smethod_5(text3);
					break;
				case 6:
					@class.Height = Class733.smethod_5(text3);
					break;
				}
			}
		}
		hashtable_1.Add(@class.method_0(), @class);
	}

	public void method_31()
	{
		bool_14 = false;
	}

	public void method_32(int int_11)
	{
		if (worksheet_0 != null)
		{
			Picture picture = new Picture(worksheet_0.Shapes);
			int[] array = picture.method_45(int_2, 0, int_11);
			int_2 = array[0];
		}
	}

	public void method_33()
	{
		bool_1 = true;
	}

	public void method_34()
	{
		bool_1 = false;
	}

	public void method_35()
	{
		bool_2 = true;
	}

	public void method_36()
	{
		bool_2 = false;
	}

	public void method_37()
	{
		string_2 += "\r\n";
	}

	private string method_38(string string_3)
	{
		if (string_3.Length > 0 && string_3.Trim() == "")
		{
			int length = string_3.Length;
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				char c = string_3[i];
				if (c == ' ')
				{
					stringBuilder2.Append(c);
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			if (stringBuilder2.Length > 1)
			{
				stringBuilder.Append(" ");
			}
		}
		if (string_3.IndexOf('\r') > -1)
		{
			int length2 = string_3.Length;
			StringBuilder stringBuilder3 = new StringBuilder();
			for (int j = 0; j < length2; j++)
			{
				char c2 = string_3[j];
				if (c2 == '\r' && j + 1 < length2)
				{
					char c3 = string_3[++j];
					if (c3 == '\n')
					{
						StringBuilder stringBuilder4 = new StringBuilder();
						while (smethod_0(string_3, ++j) > '\0' && smethod_0(string_3, j) == ' ')
						{
							stringBuilder4.Append(' ');
						}
						if (stringBuilder4.Length > 0)
						{
							stringBuilder3.Append(' ');
						}
						if (smethod_0(string_3, j) != 0)
						{
							stringBuilder3.Append(smethod_0(string_3, j));
						}
					}
					else
					{
						stringBuilder3.Append(c3);
					}
				}
				else
				{
					stringBuilder3.Append(c2);
				}
			}
			return stringBuilder3.ToString();
		}
		return string_3;
	}

	private static char smethod_0(string string_3, int int_11)
	{
		if (int_11 < string_3.Length)
		{
			return string_3[int_11];
		}
		return '\0';
	}

	public void method_39(string string_3)
	{
		string_3 = method_38(string_3);
		if (bool_2)
		{
			class735_0.method_9(string_3);
		}
		else if (bool_1)
		{
			method_56(string_3);
			bool_1 = false;
		}
		else if (bool_17)
		{
			class777_0 = new Class777();
			if (string_2 == "")
			{
				class777_0.method_3(0);
				class777_0.SetLength(string_3.Length);
			}
			else
			{
				class777_0.method_3(string_2.Length);
				class777_0.SetLength(string_3.Length);
			}
			if (style_2 != null)
			{
				Aspose.Cells.Font font = style_2.Font;
				class777_0.method_1(font);
			}
			arrayList_1.Add(class777_0);
			string_2 += string_3;
			bool_17 = false;
		}
		else
		{
			if (!bool_0)
			{
				return;
			}
			if (bool_9)
			{
				class777_0 = new Class777();
				if (string_2 != "")
				{
					class777_0.method_3(string_2.Length);
					class777_0.SetLength(string_3.Length);
				}
				string_2 += string_3;
			}
			else if (bool_14)
			{
				string_2 += string_3;
			}
			else if (bool_4)
			{
				string_2 += string_3;
				bool_4 = false;
			}
			else
			{
				string_2 += string_3;
			}
		}
	}

	public void method_40()
	{
		if (cells_0 != null && cells_0.Hyperlinks.Count > 0)
		{
			cells_0.Hyperlinks[cells_0.Hyperlinks.Count - 1].TextToDisplay = method_55(string_2);
			string_2 = "";
		}
	}

	public void method_41()
	{
		Cell cell = method_11();
		if (cell != null && cell.Value == null && !(string_2 == ""))
		{
			if (string_2.ToLower().Equals("true"))
			{
				cell.PutValue(boolValue: true);
				string_2 = "";
				return;
			}
			if (string_2.ToLower().Equals("false") && !cell.IsFormula)
			{
				cell.PutValue(boolValue: false);
				string_2 = "";
				return;
			}
			string text = null;
			string text2 = null;
			bool flag = true;
			if (string_2 == " ")
			{
				text2 = string_2;
			}
			else if (string_2.EndsWith(" ") && bool_15)
			{
				text2 = method_55(string_2);
				bool_15 = false;
			}
			else
			{
				text = string_2.Trim(' ', '\n', '\r');
				if (string_2.StartsWith(" "))
				{
					text = " " + text;
				}
				if (string_2.EndsWith(" "))
				{
					text += " ";
				}
				text2 = method_55(text);
				flag = text == text2;
			}
			string_2 = "";
			if (text2 == "")
			{
				return;
			}
			try
			{
				if (htmlloadOptions_0.ConvertNumericData && flag)
				{
					object obj = icustomParser_1.ParseObject(text2.Trim());
					if (obj != null)
					{
						if (cell.IsFormula)
						{
							cell.method_66(obj, 0);
							return;
						}
						cell.PutValue(obj);
						Style style = cell.GetStyle();
						if (style.Number == 0 && method_62(style.Custom))
						{
							style.Custom = icustomParser_1.GetFormat();
							cell.method_30(style);
						}
						return;
					}
				}
				if (htmlloadOptions_0.ConvertDateTimeData && flag)
				{
					Style style2 = cell.GetStyle();
					if (style2.Custom == "General")
					{
						if (cell.IsFormula)
						{
							cell.method_66(text2, 0);
						}
						else
						{
							cell.PutValue(text2);
						}
						return;
					}
					object obj2 = icustomParser_0.ParseObject(text2.Trim());
					if (obj2 != null && CellsHelper.GetDoubleFromDateTime((DateTime)obj2, workbook_0.Settings.Date1904) >= 0.0)
					{
						if (cell.IsFormula)
						{
							cell.method_66(obj2, 0);
							return;
						}
						cell.PutValue(obj2);
						style2.Custom = icustomParser_0.GetFormat();
						cell.method_30(style2);
						return;
					}
				}
				if (cell.IsFormula)
				{
					cell.method_66(text2, 0);
				}
				else
				{
					cell.PutValue(text2);
				}
				return;
			}
			catch (Exception)
			{
				cell.PutValue(text2);
				return;
			}
		}
		string_2 = "";
	}

	public void method_42()
	{
		if (string_2 == "")
		{
			return;
		}
		Cell cell = method_11();
		if (cell == null)
		{
			return;
		}
		string text = null;
		string text2 = null;
		if (string_2 == " ")
		{
			text2 = string_2;
		}
		else if (string_2.EndsWith(" ") && bool_15)
		{
			text2 = string_2;
			bool_15 = false;
		}
		else
		{
			text = string_2.Trim(' ', '\n', '\r');
			if (string_2.StartsWith(" "))
			{
				text = " " + text;
			}
			if (string_2.EndsWith(" "))
			{
				text += " ";
			}
			text2 = text;
		}
		cell.PutValue(method_55(text2));
		string_2 = "";
	}

	public void method_43(Hashtable hashtable_3)
	{
		if (hashtable_3["class"] != null)
		{
			string key = (string)hashtable_3["class"];
			if (hashtable_0[key] == null)
			{
				return;
			}
			Style style = worksheetCollection_0.method_58()[(int)hashtable_0[key]];
			Aspose.Cells.Font font = style.Font;
			if (bool_12)
			{
				font.IsStrikeout = true;
				bool_12 = false;
			}
			if (hashtable_3["sup"] != null)
			{
				font.IsSuperscript = true;
			}
			if (hashtable_3["sub"] != null)
			{
				font.IsSubscript = true;
			}
			if (hashtable_3["s"] != null)
			{
				font.IsStrikeout = true;
			}
			if (class777_0.method_4() > 0)
			{
				class777_0.method_1(font);
				arrayList_1.Add(class777_0);
			}
		}
		if (hashtable_3["style"] == null)
		{
			return;
		}
		Style style2 = new Style(worksheetCollection_0);
		string text = (string)hashtable_3["style"];
		string[] array = text.Split(';');
		double num = -1.0;
		foreach (string text2 in array)
		{
			string[] array2 = text2.Split(':');
			string text3 = array2[0].Trim();
			string text4 = array2[1].Trim();
			string key2;
			if ((key2 = text3) == null)
			{
				continue;
			}
			if (Class1742.dictionary_21 == null)
			{
				Class1742.dictionary_21 = new Dictionary<string, int>(6)
				{
					{ "font-family", 0 },
					{ "font-size", 1 },
					{ "font-weight", 2 },
					{ "font-style", 3 },
					{ "text-decoration", 4 },
					{ "vertical-align", 5 }
				};
			}
			if (!Class1742.dictionary_21.TryGetValue(key2, out var value))
			{
				continue;
			}
			switch (value)
			{
			case 0:
				Class733.smethod_8(text4, style2.Font);
				break;
			case 1:
				num = Class733.smethod_6(text4);
				break;
			case 2:
				if (text4.ToLower() == "bold")
				{
					style_2.Font.IsBold = true;
				}
				break;
			case 5:
				if (text4 == "super")
				{
					style2.Font.IsSuperscript = true;
				}
				if (text4 == "sub")
				{
					style2.Font.IsSubscript = true;
				}
				break;
			}
		}
		if (!style2.Font.IsSubscript && !style2.Font.IsSuperscript && num > -1.0)
		{
			style2.Font.DoubleSize = num;
		}
		if (class777_0.method_4() > 0)
		{
			class777_0.method_1(style2.Font);
			arrayList_1.Add(class777_0);
		}
	}

	public void method_44()
	{
		Cell cell = method_11();
		Style style = cell.GetStyle();
		style.Font.IsSuperscript = true;
		cell.method_30(style);
	}

	public void method_45()
	{
		Cell cell = method_11();
		Style style = cell.GetStyle();
		style.Font.IsSubscript = true;
		cell.method_30(style);
	}

	public void method_46()
	{
		Cell cell = method_11();
		Style style = cell.GetStyle();
		style.Font.Underline = FontUnderlineType.Single;
		cell.method_30(style);
	}

	public void method_47()
	{
		Cell cell = method_11();
		if (cell != null)
		{
			Style style = cell.GetStyle();
			style.Font.IsBold = true;
			cell.method_30(style);
		}
	}

	public void method_48()
	{
		Cell cell = method_11();
		Style style = cell.GetStyle();
		style.Font.IsStrikeout = true;
		cell.method_30(style);
	}

	public void method_49(bool bool_18)
	{
		bool_10 = bool_18;
	}

	public void method_50(bool bool_18)
	{
		bool_11 = bool_18;
	}

	public void method_51(bool bool_18)
	{
		bool_13 = bool_18;
	}

	public void method_52(bool bool_18)
	{
		bool_7 = bool_18;
	}

	public void method_53(bool bool_18)
	{
		bool_9 = bool_18;
	}

	public void method_54()
	{
		class777_0 = new Class777();
	}

	private string method_55(string string_3)
	{
		if (string_3.IndexOf("&") > -1)
		{
			string_3 = Class429.smethod_0(string_3);
		}
		return string_3;
	}

	private void method_56(string string_3)
	{
		BuiltInDocumentPropertyCollection builtInDocumentProperties = worksheetCollection_0.BuiltInDocumentProperties;
		try
		{
			builtInDocumentProperties.Title = string_3;
		}
		catch (Exception)
		{
		}
	}

	private void method_57(object object_0, Cell cell_0)
	{
	}

	private void method_58(int int_11, int int_12, int int_13, int int_14, ref CellArea cellArea_0)
	{
		cellArea_0.StartRow = int_11;
		cellArea_0.StartColumn = int_12;
		cellArea_0.EndRow = int_13;
		cellArea_0.EndColumn = int_14;
	}

	public void method_59()
	{
		if (int_5 > 0 && int_4 == 0)
		{
			int_2 += int_5 - 1;
		}
	}

	private void method_60()
	{
		if (arrayList_0.Count > int_0)
		{
			arrayList_0.Sort();
			int_0 = arrayList_0.Count;
		}
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_0[i];
			if (int_1 >= cellArea.StartRow && int_1 <= cellArea.EndRow)
			{
				if (int_2 == cellArea.StartColumn)
				{
					int_2 += cellArea.EndColumn - cellArea.StartColumn + 1;
				}
				else if (int_2 >= cellArea.StartColumn && int_2 <= cellArea.EndColumn)
				{
					int_2 += cellArea.EndColumn - cellArea.StartColumn;
				}
			}
		}
	}

	private void method_61(object object_0, Cell cell_0, Hashtable hashtable_3)
	{
		if (object_0 != null)
		{
			string string_ = (string)object_0;
			string_ = method_55(string_);
			bool_6 = true;
			string text = (string)hashtable_3["x:arrayrange"];
			try
			{
				if (text != null)
				{
					SetArrayFormula(text, string_, cell_0);
				}
				else
				{
					cell_0.Formula = string_;
				}
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		bool_6 = cell_0.IsFormula;
	}

	private void SetArrayFormula(string string_3, string string_4, Cell cell_0)
	{
		string[] array = string_3.Split(':');
		if (array.Length > 1)
		{
			int rowNumber = Class738.smethod_0(array[1]) - Class738.smethod_0(array[0]) + 1;
			int columnNumber = Class738.ColumnNameToIndex(array[1]) - Class738.ColumnNameToIndex(array[0]) + 1;
			cell_0.SetArrayFormula(method_55(string_4), rowNumber, columnNumber);
		}
		else
		{
			cell_0.SetArrayFormula(method_55(string_4), 1, 1);
		}
	}

	private bool method_62(string string_3)
	{
		if (string_3 != null && !(string_3 == ""))
		{
			return false;
		}
		return true;
	}

	private void method_63(object object_0, Cell cell_0)
	{
		if (object_0 == null)
		{
			bool_3 = false;
		}
		else if (object_0.Equals("#DEFAULT"))
		{
			bool_3 = true;
			bool_5 = false;
		}
		else if (!bool_6)
		{
			bool_3 = false;
			bool_5 = true;
			string text = (string)object_0;
			if (text.Length == 0)
			{
				bool_3 = true;
				bool_5 = false;
			}
			else if (Class732.smethod_0(text) == Class732.int_0)
			{
				cell_0.PutValue(Convert.ToDouble(text));
			}
			else
			{
				cell_0.PutValue(Convert.ToInt32(text));
			}
		}
	}

	public void method_64()
	{
		IDictionaryEnumerator enumerator = hashtable_2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			cells_0.SetColumnWidthPixel((int)enumerator.Key, (int)enumerator.Value);
		}
		hashtable_2.Clear();
	}

	public void Clear()
	{
		int_2 = -1;
		int_1 = -1;
		int_3 = 0;
		method_68();
		arrayList_1.Clear();
		hashtable_2.Clear();
	}

	public void method_65()
	{
		arrayList_1.Clear();
		class777_0.SetLength(0);
	}

	public int method_66()
	{
		return arrayList_1.Count;
	}

	public void method_67()
	{
		Cell cell = method_11();
		if (cell.Type != CellValueType.IsString)
		{
			return;
		}
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class777 @class = (Class777)arrayList_1[i];
			if (@class.method_4() != string_2.Length || cell.Type != CellValueType.IsNumeric)
			{
				FontSetting fontSetting = cell.Characters(@class.method_2(), @class.method_4());
				fontSetting.method_3(@class.method_0());
			}
		}
	}

	public void method_68()
	{
		arrayList_0.Clear();
	}

	[SpecialName]
	public void method_69(bool bool_18)
	{
		bool_0 = bool_18;
	}

	[SpecialName]
	public Worksheet method_70()
	{
		return worksheet_0;
	}

	[SpecialName]
	public void method_71(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	public void method_72(Cells cells_1)
	{
		cells_0 = cells_1;
	}

	[SpecialName]
	public Hashtable method_73()
	{
		return hashtable_0;
	}

	[SpecialName]
	public void method_74(Hashtable hashtable_3)
	{
		hashtable_0 = hashtable_3;
	}

	[SpecialName]
	public void method_75(int int_11)
	{
		int_10 = int_11;
	}

	[SpecialName]
	public void method_76(Hashtable hashtable_3)
	{
		hashtable_1 = hashtable_3;
	}

	[SpecialName]
	public void method_77(HTMLLoadOptions htmlloadOptions_1)
	{
		htmlloadOptions_0 = htmlloadOptions_1;
	}
}
