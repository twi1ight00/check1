using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns1;
using ns2;
using ns22;
using ns25;
using ns26;

namespace ns15;

internal class Class1508
{
	private XmlTextReader xmlTextReader_0;

	private Class1489 class1489_0;

	private Class1490 class1490_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private Worksheet worksheet_0;

	private Cells cells_0;

	private Class1100 class1100_0;

	private Class1356 class1356_0;

	internal Class1508(Class1489 class1489_1)
	{
		class1489_0 = class1489_1;
		class1100_0 = new Class1100(class1489_1);
		class1356_0 = new Class1356(class1489_1);
	}

	private void method_0()
	{
		int_2 = -1;
		int_1 = -1;
		int_0 = 0;
	}

	internal void Read(XmlTextReader xmlTextReader_1, Class1490 class1490_1)
	{
		xmlTextReader_0 = xmlTextReader_1;
		class1490_0 = class1490_1;
		worksheet_0 = class1490_1.worksheet_0;
		cells_0 = class1490_1.worksheet_0.Cells;
		method_0();
		if (xmlTextReader_1.IsEmptyElement)
		{
			xmlTextReader_1.Skip();
			return;
		}
		xmlTextReader_1.Read();
		while (Class536.smethod_4(xmlTextReader_1))
		{
			string key;
			if ((key = xmlTextReader_1.LocalName.ToLower()) != null)
			{
				if (Class1742.dictionary_108 == null)
				{
					Class1742.dictionary_108 = new Dictionary<string, int>(6)
					{
						{ "table-column", 0 },
						{ "table-row", 1 },
						{ "table-header-rows", 2 },
						{ "table-header-columns", 3 },
						{ "table-column-group", 4 },
						{ "table-row-group", 5 }
					};
				}
				if (Class1742.dictionary_108.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						method_4();
						continue;
					case 1:
						method_7();
						continue;
					case 2:
						method_5();
						continue;
					case 3:
						method_1();
						continue;
					case 4:
						method_2();
						continue;
					case 5:
						method_6();
						continue;
					}
				}
			}
			xmlTextReader_1.Skip();
		}
	}

	private void method_1()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "table-column-group":
				method_2();
				break;
			case "table-header-columns":
				method_1();
				break;
			case "table-column":
				method_4();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	private void method_2()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int_0++;
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "table-column-group":
				method_2();
				break;
			case "table-header-columns":
				method_1();
				break;
			case "table-column":
				method_4();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		int_0--;
	}

	private double method_3(double double_0)
	{
		int num = (int)(double_0 * class1489_0.double_0 / 72.0);
		WorksheetCollection worksheets = class1489_0.workbook_0.Worksheets;
		int num2 = worksheets.method_72();
		int num3 = worksheets.method_71();
		int num4 = worksheets.method_73();
		double num5 = 0.0;
		if (num < num2 + num4)
		{
			return 1.0 * (double)num / (double)(num2 + num4);
		}
		return (double)(int)((double)(num - (int)((double)(num2 * num3) / 256.0 + 0.5)) * 100.0 / (double)num2 + 0.5) / 100.0;
	}

	private void method_4()
	{
		string text = null;
		int num = 1;
		bool flag = true;
		bool bool_ = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "visibility":
					switch (xmlTextReader_0.Value)
					{
					case "filter":
						flag = false;
						bool_ = false;
						break;
					case "collapse":
						flag = false;
						bool_ = true;
						break;
					case "visible":
						flag = true;
						break;
					}
					break;
				case "default-cell-style-name":
					_ = xmlTextReader_0.Value;
					break;
				case "number-columns-repeated":
					num = int.Parse(xmlTextReader_0.Value);
					break;
				case "style-name":
					text = xmlTextReader_0.Value.ToLower();
					break;
				}
			}
		}
		xmlTextReader_0.Skip();
		double num2 = 64.8;
		if (text != null)
		{
			Class1497 @class = (Class1497)class1489_0.hashtable_3[text];
			num2 = @class.Width;
		}
		int num3 = 15;
		if (int_0 > cells_0.method_27())
		{
			cells_0.method_28((byte)int_0);
		}
		for (int i = 0; i < num; i++)
		{
			Class1488 class2 = class1490_0.method_3(int_2 + i + 1);
			num3 = class2.int_3;
			if (!flag || int_0 != 0 || Math.Abs(num2 - class1490_0.double_0) > 0.0001 || num3 != 15)
			{
				Column column = cells_0.Columns[int_2 + i + 1];
				column.Width = method_3(num2);
				column.method_6(num3);
				column.method_4((byte)int_0);
				column.IsHidden = !flag;
				column.method_15(bool_);
			}
		}
		int_2 += num;
	}

	private void method_5()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "table-row-group":
				method_6();
				break;
			case "table-header-rows":
				method_5();
				break;
			case "table-row":
				method_7();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	private void method_6()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int_0++;
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "table-row-group":
				method_6();
				break;
			case "table-header-rows":
				method_5();
				break;
			case "table-row":
				method_7();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		int_0--;
	}

	private void method_7()
	{
		int repeated = 1;
		int xfIndex = 15;
		method_8(out repeated, out xfIndex);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			int_1 += repeated;
			return;
		}
		int_2 = -1;
		int_1++;
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "covered-table-cell":
				method_9(repeated, xfIndex, bool_0: true);
				break;
			case "table-cell":
				method_9(repeated, xfIndex, bool_0: false);
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		int_1 += repeated - 1;
	}

	[Attribute0(true)]
	private void method_8(out int repeated, out int xfIndex)
	{
		string text = null;
		xfIndex = 15;
		repeated = 1;
		bool flag = true;
		bool bool_ = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "visibility":
					switch (xmlTextReader_0.Value)
					{
					case "filter":
						flag = false;
						bool_ = false;
						break;
					case "collapse":
						flag = false;
						bool_ = true;
						break;
					case "visible":
						flag = true;
						break;
					}
					break;
				case "number-rows-repeated":
					repeated = int.Parse(xmlTextReader_0.Value);
					break;
				case "style-name":
					text = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		double num = 13.68;
		bool isHeightMatched = true;
		if (text != null && text != "")
		{
			Class1503 @class = (Class1503)class1489_0.hashtable_1[text];
			if (@class != null)
			{
				num = @class.RowHeight;
				isHeightMatched = @class.method_0();
			}
		}
		Class1354 row = class1490_0.GetRow(int_1 + 1);
		if (row != null && row.string_0 != null)
		{
			object obj = class1489_0.hashtable_0[row.string_0];
			if (obj != null)
			{
				xfIndex = (int)obj;
			}
		}
		if (int_0 > cells_0.method_29())
		{
			cells_0.method_30((byte)int_0);
		}
		if (int_0 != 0 || Math.Abs(num * 20.0 - cells_0.method_0()) > 1.0 || xfIndex != 15 || !flag)
		{
			for (int i = 0; i < repeated; i++)
			{
				Row row2 = cells_0.Rows.GetRow(int_1 + i + 1, bool_0: false, bool_1: false);
				row2.method_25((byte)int_0);
				row2.method_11(xfIndex);
				row2.method_14((ushort)(num * 20.0 + 0.5));
				row2.IsHeightMatched = isHeightMatched;
				row2.IsHidden = !flag;
				row2.method_16(bool_);
			}
		}
	}

	private void method_9(int int_3, int int_4, bool bool_0)
	{
		int num = 1;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		int num2 = 1;
		int num3 = 1;
		int num4 = -1;
		int num5 = -1;
		int_2++;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string key;
				if ((key = xmlTextReader_0.LocalName.ToLower()) == null)
				{
					continue;
				}
				if (Class1742.dictionary_109 == null)
				{
					Class1742.dictionary_109 = new Dictionary<string, int>(12)
					{
						{ "number-matrix-columns-spanned", 0 },
						{ "number-matrix-rows-spanned", 1 },
						{ "number-columns-repeated", 2 },
						{ "style-name", 3 },
						{ "value-type", 4 },
						{ "time-value", 5 },
						{ "value", 6 },
						{ "date-value", 7 },
						{ "boolean-value", 8 },
						{ "number-columns-spanned", 9 },
						{ "number-rows-spanned", 10 },
						{ "formula", 11 }
					};
				}
				if (!Class1742.dictionary_109.TryGetValue(key, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					num5 = int.Parse(xmlTextReader_0.Value);
					break;
				case 1:
					num4 = int.Parse(xmlTextReader_0.Value);
					break;
				case 2:
					num = int.Parse(xmlTextReader_0.Value);
					break;
				case 3:
					if (xmlTextReader_0.Value != null && xmlTextReader_0.Value != "")
					{
						text = xmlTextReader_0.Value;
					}
					break;
				case 4:
					text2 = xmlTextReader_0.Value;
					break;
				case 5:
				case 6:
				case 7:
				case 8:
					text3 = xmlTextReader_0.Value;
					break;
				case 9:
					num3 = int.Parse(xmlTextReader_0.Value);
					break;
				case 10:
					num2 = int.Parse(xmlTextReader_0.Value);
					break;
				case 11:
					text4 = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		Cell cell = null;
		if (text2 == null && text4 == null)
		{
			if (!bool_0)
			{
				int num6 = ((text == null || class1489_0.hashtable_0[text] == null) ? 15 : ((int)class1489_0.hashtable_0[text]));
				int[] array = new int[num];
				bool flag = false;
				for (int i = 0; i < num; i++)
				{
					array[i] = -1;
					if (text == null)
					{
						if (int_4 != 15)
						{
							array[i] = num6;
							flag = true;
						}
					}
					else if (int_4 != 15)
					{
						if (int_4 == num6)
						{
							array[i] = -1;
							continue;
						}
						array[i] = num6;
						flag = true;
					}
					else if (class1490_0.method_1(int_2 + i) == num6)
					{
						array[i] = -1;
					}
					else
					{
						array[i] = num6;
						flag = true;
					}
				}
				if (flag)
				{
					for (int j = 0; j < int_3; j++)
					{
						for (int k = 0; k < num; k++)
						{
							if (array[k] != -1)
							{
								Cell cell2 = cells_0.GetCell(int_1 + j, int_2 + k, bool_2: false);
								cell2.method_37(num6);
								if (k == 0 && j == 0)
								{
									cell = cell2;
								}
							}
						}
					}
				}
			}
		}
		else
		{
			int num7 = 15;
			if (text == null)
			{
				num7 = class1490_0.method_2(int_2);
			}
			else
			{
				object obj = class1489_0.hashtable_0[text];
				if (obj != null)
				{
					num7 = (int)obj;
				}
			}
			cell = cells_0.GetCell(int_1, int_2, bool_2: false);
			cell.method_37(num7);
			bool flag2 = false;
			try
			{
				if (text4 != null)
				{
					if (num4 != -1 && num5 != -1)
					{
						cell.SetArrayFormula(smethod_0(text4, worksheet_0.Name), num4, num5);
					}
					else
					{
						string text5 = smethod_0(text4, worksheet_0.Name);
						if (text5 != null && text5.Length > 1)
						{
							cell.Formula = text5;
						}
					}
					flag2 = true;
				}
				else
				{
					flag2 = cell.IsFormula;
				}
			}
			catch
			{
			}
			string key2;
			if ((key2 = text2) != null)
			{
				if (Class1742.dictionary_110 == null)
				{
					Class1742.dictionary_110 = new Dictionary<string, int>(7)
					{
						{ "boolean", 0 },
						{ "date", 1 },
						{ "time", 2 },
						{ "currency", 3 },
						{ "percentage", 4 },
						{ "float", 5 },
						{ "string", 6 }
					};
				}
				if (Class1742.dictionary_110.TryGetValue(key2, out var value2))
				{
					switch (value2)
					{
					case 0:
						if (flag2)
						{
							cell.method_65(text3.ToLower() == "true");
						}
						else
						{
							cell.PutValue(text3.ToLower() == "true");
						}
						break;
					case 1:
						try
						{
							if (flag2)
							{
								cell.method_65(DateTime.Parse(text3));
								break;
							}
							text3 = text3.Replace('T', ' ');
							cell.PutValue(DateTime.Parse(text3));
						}
						catch
						{
						}
						break;
					case 2:
						try
						{
							if (flag2)
							{
								cell.method_65(Class1516.smethod_20(text3));
							}
							else
							{
								cell.PutValue(Class1516.smethod_20(text3));
							}
						}
						catch
						{
						}
						break;
					case 3:
					case 4:
					case 5:
						try
						{
							if (flag2)
							{
								cell.method_65(Class1516.smethod_16(text3));
							}
							else
							{
								cell.PutValue(Class1516.smethod_16(text3));
							}
						}
						catch
						{
						}
						break;
					case 6:
						if (text3 != null)
						{
							if (flag2)
							{
								cell.method_65(text3);
							}
							else
							{
								cell.PutValue(text3);
							}
						}
						break;
					}
				}
			}
		}
		bool flag3 = false;
		if (num3 != 1 || num2 != 1)
		{
			flag3 = true;
			cells_0.Merge(int_1, int_2, num2, num3);
			if (cell != null && cell.method_36() != -1 && cell.method_36() != 15)
			{
				Style style = cell.method_32();
				if (style.method_9())
				{
					for (int l = 0; l < num2; l++)
					{
						for (int m = 0; m < num3; m++)
						{
							if (l + m != 0)
							{
								cells_0.GetCell(int_1 + l, int_2 + m, bool_2: false).method_37(cell.method_36());
							}
						}
					}
				}
			}
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			int_2 += num - 1;
			return;
		}
		ArrayList arrayList = new ArrayList();
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string key3;
			if ((key3 = xmlTextReader_0.LocalName.ToLower()) != null)
			{
				if (Class1742.dictionary_111 == null)
				{
					Class1742.dictionary_111 = new Dictionary<string, int>(7)
					{
						{ "span", 0 },
						{ "rect", 1 },
						{ "ellipse", 2 },
						{ "custom-shape", 3 },
						{ "frame", 4 },
						{ "p", 5 },
						{ "annotation", 6 }
					};
				}
				if (Class1742.dictionary_111.TryGetValue(key3, out var value3))
				{
					switch (value3)
					{
					case 0:
						method_12(arrayList, null, cell, num2, num3);
						continue;
					case 1:
						class1356_0.method_0(worksheet_0, "rect", int_1, int_2, xmlTextReader_0);
						continue;
					case 2:
						class1356_0.method_0(worksheet_0, "ellipse", int_1, int_2, xmlTextReader_0);
						continue;
					case 3:
						class1356_0.method_0(worksheet_0, "custom-shape", int_1, int_2, xmlTextReader_0);
						continue;
					case 4:
						class1356_0.method_0(worksheet_0, null, int_1, int_2, xmlTextReader_0);
						continue;
					case 5:
						if (text2 != null && !(text2 == "string"))
						{
							xmlTextReader_0.Skip();
						}
						else
						{
							method_11(cell, arrayList, int_3, num);
						}
						continue;
					case 6:
					{
						int index = worksheet_0.Comments.Add(int_1, int_2);
						class1100_0.method_0(worksheet_0.Comments[index].CommentShape, xmlTextReader_0);
						continue;
					}
					}
				}
			}
			xmlTextReader_0.Skip();
		}
		if (arrayList.Count != 0)
		{
			if (cell == null)
			{
				cell = cells_0.GetCell(int_1, int_2, bool_2: false);
			}
			method_10(cell, arrayList);
		}
		else if (text2 == "string" && text3 == null)
		{
			if (cell.IsFormula)
			{
				cell.method_66("", 0);
			}
			else if (cell.IsBlank)
			{
				cell.PutValue("");
			}
		}
		if (cell != null && num > 1 && !flag3)
		{
			Cell cell3 = cell;
			for (int n = 1; n < num; n++)
			{
				cell = cells_0.Rows.GetCell(int_1, int_2 + n, bool_0: false, bool_1: false, bool_2: false);
				cell.Copy(cell3);
			}
		}
		int_2 += num - 1;
	}

	internal static string smethod_0(string string_0, string string_1)
	{
		if (string_0.StartsWith("msoxl:"))
		{
			return string_0.Substring("msoxl:".Length);
		}
		StringBuilder stringBuilder = new StringBuilder();
		int i = 0;
		if (string_0.StartsWith("oooc:"))
		{
			i = 5;
		}
		else if (string_0.StartsWith("of:"))
		{
			i = 3;
		}
		if (string_0.Length <= i)
		{
			return null;
		}
		if (string_0[i] != '=')
		{
			stringBuilder.Append('=');
		}
		for (; i < string_0.Length; i++)
		{
			char c = string_0[i];
			switch (c)
			{
			case '[':
			{
				int num = smethod_2(']', string_0, i + 1);
				if (num == -1)
				{
					stringBuilder.Append(c);
					break;
				}
				string text = string_0.Substring(i + 1, num - (i + 1));
				if (text.IndexOf("#REF") != -1)
				{
					stringBuilder.Append("#REF!");
				}
				else
				{
					int num2 = smethod_2(':', text, 0);
					if (num2 == -1)
					{
						smethod_4(stringBuilder, text);
					}
					else
					{
						string string_2 = text.Substring(0, num2);
						string string_3 = text.Substring(num2 + 1);
						smethod_3(stringBuilder, string_1, string_2, string_3);
					}
				}
				i = num;
				break;
			}
			default:
				stringBuilder.Append(c);
				break;
			case ';':
				stringBuilder.Append(',');
				break;
			case '"':
				stringBuilder.Append(c);
				for (i++; i < string_0.Length; i++)
				{
					c = string_0[i];
					stringBuilder.Append(c);
					if (c == '"')
					{
						break;
					}
				}
				break;
			}
		}
		return stringBuilder.ToString();
	}

	private static string[] smethod_1(char char_0, string string_0)
	{
		int num = smethod_2(char_0, string_0, 0);
		return num switch
		{
			-1 => new string[1] { string_0 }, 
			0 => new string[2]
			{
				"",
				string_0.Substring(1)
			}, 
			_ => new string[2]
			{
				string_0.Substring(0, num),
				string_0.Substring(num + 1)
			}, 
		};
	}

	private static int smethod_2(char char_0, string string_0, int int_3)
	{
		while (int_3 < string_0.Length)
		{
			char c = string_0[int_3];
			switch (c)
			{
			default:
				if (c == char_0)
				{
					return int_3;
				}
				break;
			case '\'':
				for (int_3++; int_3 < string_0.Length; int_3++)
				{
					c = string_0[int_3];
					if (c == '\'')
					{
						break;
					}
				}
				break;
			case '"':
				for (int_3++; int_3 < string_0.Length; int_3++)
				{
					c = string_0[int_3];
					if (c == '"')
					{
						break;
					}
				}
				break;
			}
			int_3++;
		}
		return -1;
	}

	private static void smethod_3(StringBuilder stringBuilder_0, string string_0, string string_1, string string_2)
	{
		string[] array = smethod_1('.', string_1);
		string text = ((array.Length == 1) ? null : ((array[0] == "") ? null : array[0]));
		bool flag = false;
		if (text != null)
		{
			if (text[0] == '$')
			{
				text = text.Substring(1);
			}
			if (text[0] == '\'')
			{
				text = text.Substring(1, text.Length - 2);
			}
			flag = Class1677.smethod_21(text);
		}
		string value = ((array.Length == 1) ? string_1 : array[1]);
		array = string_2.Split('.');
		string text2 = ((array.Length == 1) ? null : ((array[0] == "") ? null : array[0]));
		if (text2 != null)
		{
			if (text2[0] == '$')
			{
				text2 = text2.Substring(1);
			}
			if (text2[0] == '\'')
			{
				text2 = text2.Substring(1, text2.Length - 2);
			}
			if (!flag)
			{
				flag = Class1677.smethod_21(text2);
			}
		}
		string value2 = ((array.Length == 1) ? string_2 : array[1]);
		if (text != null || text2 != null)
		{
			if (flag)
			{
				stringBuilder_0.Append('\'');
			}
			if (text == null)
			{
				if (text2 == string_0)
				{
					stringBuilder_0.Append(text2);
				}
				else
				{
					stringBuilder_0.Append(string_0);
					stringBuilder_0.Append(':');
					stringBuilder_0.Append(text2);
				}
			}
			else if (text2 != null && !(text == text2))
			{
				stringBuilder_0.Append(text);
				stringBuilder_0.Append(':');
				stringBuilder_0.Append(text2);
			}
			else
			{
				stringBuilder_0.Append(text);
			}
			if (flag)
			{
				stringBuilder_0.Append('\'');
			}
			stringBuilder_0.Append('!');
		}
		stringBuilder_0.Append(value);
		stringBuilder_0.Append(':');
		stringBuilder_0.Append(value2);
	}

	private static void smethod_4(StringBuilder stringBuilder_0, string string_0)
	{
		if (string_0.IndexOf("#REF") != -1)
		{
			stringBuilder_0.Append("#REF!");
			return;
		}
		int num = smethod_2('.', string_0, 0);
		switch (num)
		{
		case -1:
			stringBuilder_0.Append(string_0);
			return;
		case 0:
			stringBuilder_0.Append(string_0.Substring(1));
			return;
		}
		string[] array = new string[2]
		{
			string_0.Substring(0, num),
			string_0.Substring(num + 1)
		};
		if (array[0][0] == '$')
		{
			array[0] = array[0].Substring(1);
		}
		if (array[0][0] != '\'')
		{
			if (Class1677.smethod_21(array[0]))
			{
				stringBuilder_0.Append('\'');
				stringBuilder_0.Append(array[0]);
				stringBuilder_0.Append('\'');
			}
			else
			{
				stringBuilder_0.Append(array[0]);
			}
		}
		else if (array[0][array[0].Length - 1] != '\'')
		{
			num = array[0].LastIndexOf('\'');
			if (num != -1)
			{
				stringBuilder_0.Append('\'');
				stringBuilder_0.Append('[');
				stringBuilder_0.Append(array[0].Substring(1, num - 1));
				stringBuilder_0.Append(']');
				if (array[0][num + 1] == '$')
				{
					stringBuilder_0.Append(array[0].Substring(num + 2));
				}
				else
				{
					stringBuilder_0.Append(array[0].Substring(num + 3));
				}
				stringBuilder_0.Append('\'');
			}
			else
			{
				stringBuilder_0.Append(array[0]);
			}
		}
		else
		{
			stringBuilder_0.Append(array[0]);
		}
		stringBuilder_0.Append('!');
		stringBuilder_0.Append(array[1]);
	}

	private void method_10(Cell cell_0, ArrayList arrayList_0)
	{
		if (arrayList_0.Count == 1)
		{
			if (cell_0.IsFormula)
			{
				cell_0.method_65(((Class1353)arrayList_0[0]).string_0);
			}
			else
			{
				cell_0.PutValue(((Class1353)arrayList_0[0]).string_0);
			}
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1353 @class = (Class1353)arrayList_0[i];
			FontSetting fontSetting = new FontSetting(stringBuilder.Length, @class.string_0.Length, class1489_0.workbook_0.Worksheets, bool_1: false);
			arrayList.Add(fontSetting);
			stringBuilder.Append(@class.string_0);
			if (@class.font_0 == null)
			{
				fontSetting.Font.Copy(cell_0.method_32().Font);
			}
			else
			{
				fontSetting.Font.Copy(@class.font_0);
			}
		}
		cell_0.method_67(stringBuilder.ToString(), arrayList);
	}

	[Attribute0(true)]
	internal void method_11(Cell cell_0, ArrayList arrayList_0, int int_3, int int_4)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		if (arrayList_0.Count != 0)
		{
			Class1353 @class = (Class1353)arrayList_0[arrayList_0.Count - 1];
			@class.string_0 += "\n";
			arrayList_0[arrayList_0.Count - 1] = @class;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			if (xmlTextReader_0.NodeType == XmlNodeType.Whitespace)
			{
				Class1353 class2 = new Class1353();
				class2.string_0 = " ";
				arrayList_0.Add(class2);
				xmlTextReader_0.Skip();
				continue;
			}
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				if (xmlTextReader_0.NodeType == XmlNodeType.Text)
				{
					Class1353 class3 = new Class1353();
					class3.string_0 = xmlTextReader_0.Value;
					arrayList_0.Add(class3);
				}
				xmlTextReader_0.Skip();
				continue;
			}
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "a":
				method_13(cell_0, null, int_3, int_4);
				break;
			case "span":
				method_12(arrayList_0, null, cell_0, int_3, int_4);
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	internal void method_12(ArrayList arrayList_0, Font font_0, Cell cell_0, int int_3, int int_4)
	{
		Class1353 @class = new Class1353();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) != null && localName == "style-name")
				{
					@class.font_0 = (Font)class1489_0.hashtable_4[xmlTextReader_0.Value];
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			if (xmlTextReader_0.NodeType == XmlNodeType.Whitespace)
			{
				@class.string_0 = " ";
				arrayList_0.Add(@class);
				xmlTextReader_0.Skip();
				continue;
			}
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				if (xmlTextReader_0.NodeType == XmlNodeType.Text)
				{
					@class.string_0 = xmlTextReader_0.Value;
					arrayList_0.Add(@class);
				}
				xmlTextReader_0.Skip();
				continue;
			}
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "a":
				method_13(cell_0, @class.font_0, int_3, int_4);
				break;
			case "span":
				method_12(arrayList_0, @class.font_0, cell_0, int_3, int_4);
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	internal void method_13(Cell cell_0, Font font_0, int int_3, int int_4)
	{
		string text = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) != null && localName == "href")
				{
					text = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		string text2 = xmlTextReader_0.ReadElementString();
		if (text != null && text != "")
		{
			HyperlinkCollection hyperlinks = class1490_0.worksheet_0.Hyperlinks;
			if (text[0] == '#')
			{
				text = text.Substring(1);
				if (text.IndexOf('.') != -1)
				{
					text = text.Replace('.', '!');
				}
				else if (class1489_0.workbook_0.Worksheets[text] != null)
				{
					text = text + "!" + class1489_0.workbook_0.Worksheets[text].ActiveCell;
				}
			}
			int index = hyperlinks.method_1(int_1, int_2, int_3, int_4, text);
			hyperlinks[index].TextToDisplay = text2;
		}
		cell_0.PutValue(text2);
		if (font_0 != null)
		{
			Style style = cell_0.method_28();
			style.Font.Copy(font_0);
			cell_0.method_30(style);
		}
	}
}
