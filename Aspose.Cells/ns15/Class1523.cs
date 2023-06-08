using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Aspose.Cells;
using ns1;
using ns22;
using ns25;
using ns26;

namespace ns15;

internal class Class1523
{
	private XmlTextReader xmlTextReader_0;

	private Class1489 class1489_0;

	private Worksheet worksheet_0;

	private Class1490 class1490_0;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	private int int_6;

	private int int_7;

	private int int_8;

	private int int_9 = 255;

	internal Class1523(Class1489 class1489_1)
	{
		class1489_0 = class1489_1;
	}

	private void method_0()
	{
		int_5 = -1;
		int_4 = -1;
		int_1 = -1;
		int_0 = -1;
		int_3 = -1;
		int_2 = -1;
		hashtable_1 = new Hashtable();
		hashtable_0 = new Hashtable();
	}

	private void method_1()
	{
		if (worksheet_0 == null)
		{
			return;
		}
		if (int_1 != -1)
		{
			worksheet_0.PageSetup.PrintTitleRows = "$" + (int_0 + 1) + ":$" + (int_1 + 1);
		}
		if (int_3 != -1)
		{
			worksheet_0.PageSetup.PrintTitleColumns = "$" + CellsHelper.ColumnIndexToName(int_2) + ":$" + CellsHelper.ColumnIndexToName(int_3);
		}
		int num = int_7 + 255 - int_8;
		double num2 = 64.8;
		IEnumerator enumerator = hashtable_1.Keys.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string key = (string)enumerator.Current;
			int num3 = (int)hashtable_1[key];
			if (num3 > num)
			{
				num3 = num;
				Class1497 @class = (Class1497)class1489_0.hashtable_3[key];
				if (@class != null)
				{
					num2 = @class.Width;
				}
			}
		}
		class1490_0.double_0 = num2;
		class1490_0.worksheet_0.Cells.StandardWidthInch = num2 / 72.0;
		class1490_0.method_0(int_4);
		double num4 = 13.68;
		num = int_7;
		IEnumerator enumerator2 = hashtable_0.Keys.GetEnumerator();
		while (enumerator2.MoveNext())
		{
			string key2 = (string)enumerator2.Current;
			int num5 = (int)hashtable_0[key2];
			if (num5 > num)
			{
				Class1503 class2 = (Class1503)class1489_0.hashtable_1[key2];
				if (class2 != null)
				{
					num4 = class2.RowHeight;
					num = num5;
				}
			}
		}
		class1490_0.worksheet_0.Cells.double_0 = (int)(ushort)(num4 * 20.0 + 0.5);
	}

	private void method_2(string string_0)
	{
		string_0 = string_0.Replace(worksheet_0.Name + ".", "");
		string_0 = string_0.Replace(' ', ',');
		string_0 = string_0.Replace(":.", ":");
		worksheet_0.PageSetup.PrintArea = string_0;
	}

	internal void Read(XmlTextReader xmlTextReader_1)
	{
		xmlTextReader_0 = xmlTextReader_1;
		method_0();
		string key = null;
		string text = null;
		if (xmlTextReader_1.HasAttributes)
		{
			string text2 = null;
			while (xmlTextReader_1.MoveToNextAttribute())
			{
				switch (xmlTextReader_1.LocalName.ToLower())
				{
				case "print-ranges":
					text = xmlTextReader_1.Value;
					break;
				case "style-name":
					key = xmlTextReader_1.Value;
					break;
				case "name":
					text2 = xmlTextReader_1.Value;
					break;
				}
			}
			if (text2 != null)
			{
				int index = class1489_0.workbook_0.Worksheets.method_38(text2);
				worksheet_0 = class1489_0.workbook_0.Worksheets[index];
			}
			else
			{
				int index2 = class1489_0.workbook_0.Worksheets.Add();
				worksheet_0 = class1489_0.workbook_0.Worksheets[index2];
			}
			xmlTextReader_1.MoveToElement();
		}
		class1490_0 = new Class1490(class1489_0, worksheet_0);
		class1489_0.arrayList_0.Add(class1490_0);
		Class1491 @class = (Class1491)class1489_0.hashtable_9[key];
		if (!@class.method_2())
		{
			worksheet_0.method_28(bool_1: false, bool_2: false);
		}
		if (@class.method_0() != null)
		{
			((Class1351)class1489_0.hashtable_8[@class.method_0()])?.method_0(worksheet_0.PageSetup, class1489_0);
		}
		if (text != null)
		{
			method_2(text);
		}
		if (xmlTextReader_1.IsEmptyElement)
		{
			xmlTextReader_1.Skip();
			return;
		}
		xmlTextReader_1.Read();
		while (Class536.smethod_4(xmlTextReader_1))
		{
			string key2;
			if ((key2 = xmlTextReader_1.LocalName.ToLower()) != null)
			{
				if (Class1742.dictionary_123 == null)
				{
					Class1742.dictionary_123 = new Dictionary<string, int>(6)
					{
						{ "table-column", 0 },
						{ "table-row", 1 },
						{ "table-header-rows", 2 },
						{ "table-header-columns", 3 },
						{ "table-column-group", 4 },
						{ "table-row-group", 5 }
					};
				}
				if (Class1742.dictionary_123.TryGetValue(key2, out var value))
				{
					switch (value)
					{
					case 0:
						method_5();
						continue;
					case 1:
						method_8();
						continue;
					case 2:
						method_6();
						continue;
					case 3:
						method_3();
						continue;
					case 4:
						method_4();
						continue;
					case 5:
						method_7();
						continue;
					}
				}
			}
			xmlTextReader_1.Skip();
		}
		method_1();
	}

	[Attribute0(true)]
	private void method_3()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		if (int_2 == -1)
		{
			int_2 = int_5 + 1;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "table-column-group":
				method_4();
				break;
			case "table-header-columns":
				method_3();
				break;
			case "table-column":
				method_5();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		int_3 = int_5;
	}

	[Attribute0(true)]
	private void method_4()
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
				method_4();
				break;
			case "table-header-columns":
				method_3();
				break;
			case "table-column":
				method_5();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	private void method_5()
	{
		string text = null;
		int num = 1;
		string text2 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "default-cell-style-name":
					text2 = xmlTextReader_0.Value;
					break;
				case "number-columns-repeated":
					num = int.Parse(xmlTextReader_0.Value);
					break;
				case "style-name":
					text = xmlTextReader_0.Value;
					break;
				}
			}
		}
		xmlTextReader_0.Skip();
		if (text == null)
		{
			int_6 += num;
		}
		else
		{
			Class1497 @class = (Class1497)class1489_0.hashtable_3[text];
			if (@class != null && Math.Abs(@class.Width - 64.8) >= 0.0001)
			{
				if (hashtable_1[text] == null)
				{
					hashtable_1.Add(text, num);
				}
				else
				{
					int num2 = (int)hashtable_1[text];
					hashtable_1[text] = num2 + num;
				}
			}
			else
			{
				int_6 += num;
			}
		}
		Class1488 class2 = new Class1488();
		if (text2 == null)
		{
			class2.string_0 = class1489_0.string_0;
			class2.int_2 = 15;
		}
		else
		{
			class2.string_0 = text2;
			object obj = class1489_0.hashtable_0[text2];
			if (obj != null)
			{
				Style style = class1489_0.workbook_0.Worksheets.method_58()[(int)obj];
				if (style.Name != null && style.Name != "")
				{
					class2.int_2 = class1489_0.workbook_0.Worksheets.method_58().method_1(style, (int)obj);
				}
				else
				{
					class2.int_2 = (int)obj;
				}
			}
		}
		class2.int_1 = int_5 + 1;
		class2.int_0 = num;
		int_5 += num;
		class1490_0.arrayList_0.Add(class2);
	}

	[Attribute0(true)]
	private void method_6()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		if (int_0 == -1)
		{
			int_0 = int_4 + 1;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "table-row-group":
				method_7();
				break;
			case "table-header-rows":
				method_6();
				break;
			case "table-row":
				method_8();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		int_1 = int_4;
	}

	[Attribute0(true)]
	private void method_7()
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
				method_7();
				break;
			case "table-header-rows":
				method_6();
				break;
			case "table-row":
				method_8();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	[Attribute0(true)]
	private void method_8()
	{
		int num = method_9();
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			string string_ = class1489_0.string_0;
			for (int i = 0; i < class1490_0.arrayList_0.Count; i++)
			{
				Class1488 @class = (Class1488)class1490_0.arrayList_0[i];
				Hashtable hashtable = @class.hashtable_0;
				if (hashtable[string_] != null)
				{
					int num2 = (int)hashtable[string_];
					hashtable[string_] = num2 + num;
				}
				else
				{
					hashtable.Add(string_, num);
				}
			}
			int_4 += num;
			return;
		}
		int_5 = -1;
		Hashtable hashtable2 = new Hashtable();
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "table-cell":
			case "covered-table-cell":
				method_10(hashtable2, num);
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		if (int_5 > int_9)
		{
			int_9 = 1023;
		}
		if (hashtable2.Count != 0)
		{
			string text = null;
			int num3 = 0;
			bool flag = false;
			if (int_5 < int_9)
			{
				if (hashtable2["default"] != null)
				{
					int num4 = (int)hashtable2["default"];
					num4 += int_9 - int_5;
					hashtable2["default"] = num4;
				}
				else
				{
					hashtable2.Add("default", int_9 - int_5);
				}
			}
			IEnumerator enumerator = hashtable2.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text2 = (string)enumerator.Current;
				int num5 = (int)hashtable2[text2];
				if (text2.ToLower() == "default")
				{
					if (int_5 < int_8)
					{
						num5 += int_8 - int_5 + 1;
					}
					flag = true;
				}
				if (num5 > num3)
				{
					num3 = num5;
					text = text2;
				}
			}
			if (!flag && int_5 <= int_9 && num3 <= int_9 - int_5 + 1)
			{
				text = null;
			}
			if (text != null && text.ToLower() != "default")
			{
				Class1354 class2 = new Class1354();
				class2.int_0 = int_4 + 1;
				class2.int_1 = num;
				class2.string_0 = text;
				class1490_0.arrayList_1.Add(class2);
			}
		}
		int_4 += num;
	}

	[Attribute0(true)]
	private int method_9()
	{
		if (int_4 == -1)
		{
			int_8 = int_5;
		}
		string text = null;
		int num = 1;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "number-rows-repeated":
					num = int.Parse(xmlTextReader_0.Value);
					break;
				case "style-name":
					text = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (text == null)
		{
			int_7 += num;
		}
		else
		{
			Class1503 @class = (Class1503)class1489_0.hashtable_1[text];
			if (@class != null && Math.Abs(@class.RowHeight - 13.68) >= 0.0001)
			{
				if (hashtable_0[text] == null)
				{
					hashtable_0.Add(text, num);
				}
				else
				{
					int num2 = (int)hashtable_0[text];
					hashtable_0[text] = num2 + num;
				}
			}
			else
			{
				int_7 += num;
			}
		}
		return num;
	}

	[Attribute0(true)]
	private void method_10(Hashtable hashtable_2, int int_10)
	{
		int num = 1;
		string text = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "style-name":
					text = xmlTextReader_0.Value;
					break;
				case "number-columns-repeated":
					num = int.Parse(xmlTextReader_0.Value);
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		string key = text;
		if (text == null || string.Compare(text, "defaut", ignoreCase: true) == 0)
		{
			key = "default";
		}
		if (hashtable_2[key] != null)
		{
			int num2 = (int)hashtable_2[key];
			hashtable_2[key] = num2 + num;
		}
		else
		{
			hashtable_2.Add(key, num);
		}
		int num3;
		for (num3 = 0; num3 < num; num3++)
		{
			int num4 = int_5 + num3 + 1;
			string key2 = text;
			if (text == null)
			{
				Class1488 @class = class1490_0.method_3(num4);
				key2 = ((@class == null || @class.string_0 == null) ? class1489_0.string_0 : @class.string_0);
			}
			Class1488 class2 = class1490_0.method_4(num4, num - num3);
			Hashtable hashtable = class2.hashtable_0;
			if (hashtable[key2] != null)
			{
				int num5 = (int)hashtable[key2];
				hashtable[key2] = num5 + int_10;
			}
			else
			{
				hashtable.Add(key2, int_10);
			}
			num3 += class2.int_0 - 1;
		}
		int_5 += num;
	}
}
