using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Aspose.Cells;
using ns1;
using ns22;
using ns25;
using ns26;

namespace ns15;

internal class Class1518
{
	private XmlTextReader xmlTextReader_0;

	private Class1489 class1489_0;

	private WorksheetCollection worksheetCollection_0;

	private Palette palette_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private bool bool_0;

	private Regex regex_0 = new Regex("(\\d|[a-z|A-Z])+");

	private bool bool_1;

	private bool bool_2;

	internal Class1518(Class1489 class1489_1, bool bool_3)
	{
		class1489_0 = class1489_1;
		palette_0 = class1489_1.workbook_0.Worksheets.method_24();
		bool_0 = bool_3;
		worksheetCollection_0 = class1489_1.workbook_0.Worksheets;
	}

	internal void method_0(XmlTextReader xmlTextReader_1)
	{
		xmlTextReader_0 = xmlTextReader_1;
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
				if (Class1742.dictionary_116 == null)
				{
					Class1742.dictionary_116 = new Dictionary<string, int>(6)
					{
						{ "text-style", 0 },
						{ "number-style", 1 },
						{ "currency-style", 2 },
						{ "date-style", 3 },
						{ "time-style", 4 },
						{ "percentage-style", 5 }
					};
				}
				if (Class1742.dictionary_116.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
						method_2();
						continue;
					}
				}
			}
			xmlTextReader_1.Skip();
		}
	}

	internal void method_1(XmlTextReader xmlTextReader_1)
	{
		xmlTextReader_0 = xmlTextReader_1;
		if (xmlTextReader_1.IsEmptyElement)
		{
			xmlTextReader_1.Skip();
			return;
		}
		xmlTextReader_1.Read();
		while (Class536.smethod_4(xmlTextReader_1))
		{
			switch (xmlTextReader_1.LocalName.ToLower())
			{
			case "fill-image":
				method_9();
				break;
			case "style":
				method_8();
				break;
			case "default-style":
				method_7();
				break;
			default:
				xmlTextReader_1.Skip();
				break;
			}
		}
	}

	internal void Read(XmlTextReader xmlTextReader_1)
	{
		xmlTextReader_0 = xmlTextReader_1;
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
				if (Class1742.dictionary_117 == null)
				{
					Class1742.dictionary_117 = new Dictionary<string, int>(9)
					{
						{ "default-style", 0 },
						{ "text-style", 1 },
						{ "number-style", 2 },
						{ "currency-style", 3 },
						{ "date-style", 4 },
						{ "time-style", 5 },
						{ "percentage-style", 6 },
						{ "style", 7 },
						{ "fill-image", 8 }
					};
				}
				if (Class1742.dictionary_117.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						method_7();
						continue;
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						method_2();
						continue;
					case 7:
						method_8();
						continue;
					case 8:
						method_9();
						continue;
					}
				}
			}
			xmlTextReader_1.Skip();
		}
	}

	[Attribute0(true)]
	private void method_2()
	{
		string text = null;
		bool flag = true;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "truncate-on-overflow":
					flag = ((xmlTextReader_0.Value.ToLower() == "true") ? true : false);
					break;
				case "name":
					text = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			class1489_0.method_1(text, "", null);
			xmlTextReader_0.Skip();
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool_1 = false;
		ArrayList arrayList = new ArrayList();
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string key;
			if ((key = xmlTextReader_0.LocalName.ToLower()) != null)
			{
				if (Class1742.dictionary_118 == null)
				{
					Class1742.dictionary_118 = new Dictionary<string, int>(16)
					{
						{ "text", 0 },
						{ "text-properties", 1 },
						{ "number", 2 },
						{ "fraction", 3 },
						{ "scientific-number", 4 },
						{ "text-content", 5 },
						{ "hours", 6 },
						{ "minutes", 7 },
						{ "seconds", 8 },
						{ "month", 9 },
						{ "year", 10 },
						{ "day", 11 },
						{ "day-of-week", 12 },
						{ "am-pm", 13 },
						{ "currency-symbol", 14 },
						{ "map", 15 }
					};
				}
				if (Class1742.dictionary_118.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
					{
						string text2 = xmlTextReader_0.ReadElementString();
						if (text2 != null)
						{
							if (regex_0.IsMatch(text2))
							{
								stringBuilder.Append('"');
								stringBuilder.Append(text2);
								stringBuilder.Append('"');
							}
							else
							{
								stringBuilder.Append(text2);
							}
						}
						continue;
					}
					case 1:
						method_5(stringBuilder);
						continue;
					case 2:
					case 3:
						method_6(stringBuilder);
						continue;
					case 4:
						method_6(stringBuilder);
						continue;
					case 5:
						stringBuilder.Append('@');
						xmlTextReader_0.Skip();
						continue;
					case 6:
						if (!flag)
						{
							stringBuilder.Append("[h]");
							xmlTextReader_0.Skip();
						}
						else
						{
							method_4("h", stringBuilder);
						}
						continue;
					case 7:
						method_4("m", stringBuilder);
						continue;
					case 8:
						method_4("s", stringBuilder);
						continue;
					case 9:
						method_4("m", stringBuilder);
						continue;
					case 10:
						method_4("yy", stringBuilder);
						continue;
					case 11:
						method_4("d", stringBuilder);
						continue;
					case 12:
						stringBuilder.Append("dddd");
						xmlTextReader_0.Skip();
						continue;
					case 13:
						stringBuilder.Append("AM/PM");
						xmlTextReader_0.Skip();
						continue;
					case 14:
						if (xmlTextReader_0.IsEmptyElement)
						{
							stringBuilder.Append('$');
							xmlTextReader_0.Skip();
						}
						else
						{
							stringBuilder.Append('"');
							stringBuilder.Append(xmlTextReader_0.ReadElementString());
							stringBuilder.Append('"');
						}
						continue;
					case 15:
						method_3(arrayList);
						continue;
					}
				}
			}
			xmlTextReader_0.Skip();
		}
		if (stringBuilder.Length != 1 || stringBuilder[0] != '0' || bool_1)
		{
			class1489_0.method_1(text, stringBuilder.ToString(), arrayList);
		}
	}

	[Attribute0(true)]
	private void method_3(ArrayList arrayList_0)
	{
		Class1494 @class = new Class1494();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "apply-style-name":
					@class.string_1 = xmlTextReader_0.Value;
					break;
				case "condition":
					@class.string_0 = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (@class.string_0 != null)
		{
			arrayList_0.Add(@class);
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_4(string string_5, StringBuilder stringBuilder_0)
	{
		stringBuilder_0.Append(string_5);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "textual":
					stringBuilder_0.Append(string_5);
					stringBuilder_0.Append(string_5);
					break;
				case "style":
					if (xmlTextReader_0.Value.ToLower() == "long")
					{
						stringBuilder_0.Append(string_5);
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_5(StringBuilder stringBuilder_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string text;
				if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "color")
				{
					string text2 = Class1516.smethod_10(xmlTextReader_0.Value);
					if (text2 != null)
					{
						stringBuilder_0.Append('[');
						stringBuilder_0.Append(text2);
						stringBuilder_0.Append(']');
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_6(StringBuilder stringBuilder_0)
	{
		bool flag = false;
		int num = -1;
		int num2 = 0;
		int num3 = -1;
		int num4 = -1;
		int num5 = -1;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "grouping":
					flag = ((xmlTextReader_0.Value.ToLower() == "true") ? true : false);
					break;
				case "min-denominator-digits":
					num5 = (int)Class1516.smethod_16(xmlTextReader_0.Value);
					break;
				case "min-numerator-digits":
					num4 = (int)Class1516.smethod_16(xmlTextReader_0.Value);
					break;
				case "min-exponent-digits":
					num3 = (int)Class1516.smethod_16(xmlTextReader_0.Value);
					break;
				case "decimal-places":
					bool_1 = true;
					num2 = (int)Class1516.smethod_16(xmlTextReader_0.Value);
					break;
				case "min-integer-digits":
					num = (int)Class1516.smethod_16(xmlTextReader_0.Value);
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		if (flag)
		{
			stringBuilder_0.Append("#,");
			if (num < 3)
			{
				for (int i = 0; i < 3 - num; i++)
				{
					stringBuilder_0.Append('#');
				}
			}
		}
		if (num == 0)
		{
			if (!flag)
			{
				stringBuilder_0.Append('#');
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				stringBuilder_0.Append('0');
			}
		}
		if (num2 != 0)
		{
			if (!flag && num == -1)
			{
				stringBuilder_0.Append('0');
			}
			stringBuilder_0.Append('.');
			for (int k = 0; k < num2; k++)
			{
				stringBuilder_0.Append('0');
			}
		}
		if (num4 != -1 && num5 != -1)
		{
			for (int l = 0; l < num4; l++)
			{
				stringBuilder_0.Append('?');
			}
			stringBuilder_0.Append('/');
			for (int m = 0; m < num5; m++)
			{
				stringBuilder_0.Append('?');
			}
		}
		if (num3 != -1)
		{
			stringBuilder_0.Append("E+");
			for (int n = 0; n < num3; n++)
			{
				stringBuilder_0.Append('0');
			}
		}
	}

	private void method_7()
	{
		xmlTextReader_0.Skip();
	}

	private void method_8()
	{
		string_0 = (string_1 = (string_2 = (string_3 = (string_4 = null))));
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "data-style-name":
					string_4 = xmlTextReader_0.Value;
					break;
				case "master-page-name":
					string_2 = xmlTextReader_0.Value;
					break;
				case "parent-style-name":
					string_3 = xmlTextReader_0.Value;
					break;
				case "family":
					string_0 = xmlTextReader_0.Value;
					break;
				case "name":
					string_1 = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_119 == null)
			{
				Class1742.dictionary_119 = new Dictionary<string, int>(7)
				{
					{ "table-column", 0 },
					{ "table-row", 1 },
					{ "table", 2 },
					{ "table-cell", 3 },
					{ "text", 4 },
					{ "paragraph", 5 },
					{ "graphic", 6 }
				};
			}
			if (Class1742.dictionary_119.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					method_12();
					return;
				case 1:
					method_13();
					return;
				case 2:
					method_10();
					return;
				case 3:
					method_11();
					return;
				case 4:
					method_14();
					return;
				case 5:
					method_15();
					return;
				case 6:
					method_16();
					return;
				}
			}
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_9()
	{
		Class1096 @class = new Class1096();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "actuate":
					@class.method_4(Class1515.smethod_3(xmlTextReader_0.Value));
					break;
				case "show":
					@class.ShowType = Class1515.smethod_2(xmlTextReader_0.Value);
					break;
				case "href":
					@class.method_3(xmlTextReader_0.Value);
					break;
				case "name":
					@class.Name = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (@class.Name != null && class1489_0.hashtable_7[@class.Name] == null)
		{
			class1489_0.hashtable_7.Add(@class.Name, @class);
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_10()
	{
		Class1491 @class = new Class1491();
		@class.Name = string_1;
		@class.method_1(string_2);
		class1489_0.hashtable_9.Add(string_1, @class);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string text;
			if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "table-properties")
			{
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						switch (xmlTextReader_0.LocalName.ToLower())
						{
						case "writing-mode":
							@class.method_4(Class1515.smethod_1(xmlTextReader_0.Value));
							break;
						case "display":
							@class.method_3(xmlTextReader_0.Value == "true");
							break;
						}
					}
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	private void method_11()
	{
		Style style = null;
		int num = 0;
		bool_2 = false;
		if (string_1.ToLower() == "default")
		{
			style = class1489_0.workbook_0.Worksheets.DefaultStyle;
			class1489_0.string_0 = string_1;
		}
		else
		{
			style = new Style(class1489_0.workbook_0.Worksheets);
			style.Copy(class1489_0.workbook_0.Worksheets.DefaultStyle);
			if (bool_0)
			{
				style.Name = string_1;
				style.method_16(0);
				style.method_11(bool_0: false);
			}
		}
		if (string_3 != null && class1489_0.hashtable_0[string_3] != null)
		{
			num = (int)class1489_0.hashtable_0[string_3];
			if (num < worksheetCollection_0.method_58().Count)
			{
				Style style2 = worksheetCollection_0.method_58()[num];
				style.Copy(style2);
				style.method_16(0);
				if (!bool_0)
				{
					style.method_11(bool_0: true);
					style.method_13(num);
				}
			}
		}
		if (string_4 != null && string_4 != "")
		{
			string custom = class1489_0.method_0(string_4);
			style.Custom = custom;
		}
		if (!xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Read();
			while (Class536.smethod_4(xmlTextReader_0))
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "paragraph-properties":
				{
					Class1097 @class = new Class1097();
					@class.textAlignmentType_0 = TextAlignmentType.General;
					method_18(@class);
					style.HorizontalAlignment = @class.textAlignmentType_0;
					if (style.HorizontalAlignment == TextAlignmentType.Left || style.VerticalAlignment == TextAlignmentType.Right)
					{
						style.IndentLevel = @class.int_0;
					}
					break;
				}
				case "text-properties":
					method_19(style.Font);
					break;
				case "table-cell-properties":
					method_20(style);
					break;
				default:
					xmlTextReader_0.Skip();
					break;
				}
			}
		}
		else
		{
			xmlTextReader_0.Skip();
		}
		int num2 = 0;
		if (string_1.ToLower() == "default")
		{
			worksheetCollection_0.DefaultStyle = style;
		}
		else if (bool_0)
		{
			if (style.Name != null)
			{
				num2 = worksheetCollection_0.method_58().method_5(style);
			}
			else
			{
				worksheetCollection_0.method_58().method_0(style);
				num2 = worksheetCollection_0.method_58().Count - 1;
			}
		}
		else
		{
			num2 = worksheetCollection_0.method_58().method_1(style, num);
		}
		if (class1489_0.hashtable_0[string_1] != null)
		{
			class1489_0.hashtable_0[string_1] = num2;
		}
		else
		{
			class1489_0.hashtable_0.Add(string_1, num2);
		}
		bool_2 = false;
	}

	[Attribute0(true)]
	private void method_12()
	{
		Class1497 @class = new Class1497();
		class1489_0.hashtable_3.Add(string_1, @class);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string text;
			if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "table-column-properties")
			{
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						string text2;
						if ((text2 = xmlTextReader_0.LocalName.ToLower()) != null && text2 == "column-width")
						{
							@class.Width = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value);
						}
					}
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_13()
	{
		Class1503 @class = new Class1503();
		class1489_0.hashtable_1.Add(string_1, @class);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string text;
			if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "table-row-properties")
			{
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						switch (xmlTextReader_0.LocalName.ToLower())
						{
						case "break-before":
							switch (xmlTextReader_0.Value)
							{
							case "page":
								@class.method_3(Enum212.const_2);
								break;
							case "column":
								@class.method_3(Enum212.const_1);
								break;
							case "auto":
								@class.method_3(Enum212.const_0);
								break;
							}
							break;
						case "use-optimal-row-height":
							@class.method_1(xmlTextReader_0.Value == "true");
							break;
						case "row-height":
							@class.RowHeight = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value);
							break;
						}
					}
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_14()
	{
		Aspose.Cells.Font font = new Aspose.Cells.Font(class1489_0.workbook_0.Worksheets, null, bool_0: false);
		class1489_0.hashtable_4.Add(string_1, font);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string text;
			if ((text = xmlTextReader_0.LocalName.ToLower()) != null && text == "text-properties")
			{
				method_19(font);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_15()
	{
		Class1097 class1097_ = new Class1097();
		Class1352 @class = new Class1352();
		@class.class1097_0 = class1097_;
		class1489_0.hashtable_5.Add(string_1, @class);
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
			case "paragraph-properties":
				method_18(class1097_);
				break;
			case "text-properties":
				@class.font_0 = new Aspose.Cells.Font(class1489_0.workbook_0.Worksheets, null, bool_0: false);
				method_19(@class.font_0);
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	[Attribute0(true)]
	private void method_16()
	{
		Class1098 class1098_ = new Class1098();
		Class1097 class1097_ = new Class1097();
		Class1355 @class = new Class1355();
		@class.class1098_0 = class1098_;
		@class.class1097_0 = class1097_;
		if (class1489_0.hashtable_6[string_1] == null)
		{
			class1489_0.hashtable_6.Add(string_1, @class);
		}
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
			case "paragraph-properties":
				method_18(class1097_);
				break;
			case "graphic-properties":
				method_17(class1098_);
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	[Attribute0(true)]
	private void method_17(Class1098 class1098_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string key;
				if ((key = xmlTextReader_0.LocalName.ToLower()) == null)
				{
					continue;
				}
				if (Class1742.dictionary_120 == null)
				{
					Class1742.dictionary_120 = new Dictionary<string, int>(16)
					{
						{ "wrap-option", 0 },
						{ "padding-top", 1 },
						{ "padding-bottom", 2 },
						{ "padding-left", 3 },
						{ "padding-right", 4 },
						{ "textarea-vertical-align", 5 },
						{ "textarea-horizontal-align", 6 },
						{ "fill", 7 },
						{ "fill-image-name", 8 },
						{ "repeat", 9 },
						{ "stroke", 10 },
						{ "stroke-width", 11 },
						{ "stroke-color", 12 },
						{ "stroke-opacity", 13 },
						{ "auto-grow-width", 14 },
						{ "auto-grow-height", 15 }
					};
				}
				if (Class1742.dictionary_120.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						class1098_0.string_0 = xmlTextReader_0.Value;
						break;
					case 1:
						class1098_0.string_1 = xmlTextReader_0.Value;
						break;
					case 2:
						class1098_0.string_2 = xmlTextReader_0.Value;
						break;
					case 3:
						class1098_0.string_3 = xmlTextReader_0.Value;
						break;
					case 4:
						class1098_0.string_4 = xmlTextReader_0.Value;
						break;
					case 5:
						class1098_0.string_5 = xmlTextReader_0.Value;
						break;
					case 6:
						class1098_0.string_6 = xmlTextReader_0.Value;
						break;
					case 7:
						class1098_0.string_7 = xmlTextReader_0.Value;
						break;
					case 8:
						class1098_0.string_8 = xmlTextReader_0.Value;
						break;
					case 9:
						class1098_0.string_9 = xmlTextReader_0.Value;
						break;
					case 10:
						class1098_0.string_10 = xmlTextReader_0.Value;
						break;
					case 11:
						class1098_0.string_11 = xmlTextReader_0.Value;
						break;
					case 12:
						class1098_0.color_0 = Class1516.smethod_11(xmlTextReader_0.Value);
						break;
					case 13:
						class1098_0.string_12 = xmlTextReader_0.Value;
						break;
					case 14:
						class1098_0.string_13 = xmlTextReader_0.Value;
						break;
					case 15:
						class1098_0.string_14 = xmlTextReader_0.Value;
						break;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_18(Class1097 class1097_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName.ToLower())
				{
				case "margin-left":
					class1097_0.int_0 = (int)(Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) * 2.54 / 25.415999999999997);
					break;
				case "text-align":
					switch (xmlTextReader_0.Value)
					{
					case "justify":
						class1097_0.textAlignmentType_0 = TextAlignmentType.Justify;
						break;
					case "center":
						class1097_0.textAlignmentType_0 = TextAlignmentType.Center;
						break;
					case "end":
						class1097_0.textAlignmentType_0 = TextAlignmentType.Right;
						break;
					case "start":
						if (bool_2)
						{
							class1097_0.textAlignmentType_0 = TextAlignmentType.Fill;
						}
						else
						{
							class1097_0.textAlignmentType_0 = TextAlignmentType.Left;
						}
						break;
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	private void method_19(Aspose.Cells.Font font_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			string text = null;
			string text2 = null;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string key;
				if ((key = xmlTextReader_0.LocalName.ToLower()) != null)
				{
					if (Class1742.dictionary_121 == null)
					{
						Class1742.dictionary_121 = new Dictionary<string, int>(10)
						{
							{ "use-window-font-color", 0 },
							{ "font-name", 1 },
							{ "font-weight", 2 },
							{ "font-style", 3 },
							{ "text-line-through-style", 4 },
							{ "font-size", 5 },
							{ "color", 6 },
							{ "text-underline-style", 7 },
							{ "text-underline-type", 8 },
							{ "text-position", 9 }
						};
					}
					if (Class1742.dictionary_121.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							font_0.Color = Color.Empty;
							break;
						case 1:
							if (class1489_0.hashtable_10[xmlTextReader_0.Value] != null)
							{
								font_0.method_13((string)class1489_0.hashtable_10[xmlTextReader_0.Value]);
							}
							else
							{
								font_0.method_13(xmlTextReader_0.Value);
							}
							break;
						case 2:
							font_0.IsBold = xmlTextReader_0.Value.ToLower() == "bold";
							break;
						case 3:
							font_0.IsItalic = xmlTextReader_0.Value.ToLower() == "italic";
							break;
						case 4:
							font_0.IsStrikeout = xmlTextReader_0.Value.ToLower() == "solid";
							break;
						case 5:
							font_0.DoubleSize = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value);
							break;
						case 6:
							font_0.Color = Class1516.smethod_11(xmlTextReader_0.Value);
							break;
						case 7:
							text = xmlTextReader_0.Value;
							break;
						case 8:
							text2 = xmlTextReader_0.Value;
							break;
						case 9:
						{
							int num = xmlTextReader_0.Value.IndexOf(' ');
							if (num == -1 || xmlTextReader_0.Value.Equals("0% 100%"))
							{
								break;
							}
							string[] array = xmlTextReader_0.Value.Split(' ');
							if (array.Length >= 2)
							{
								if (array[0][0] == '-')
								{
									font_0.IsSubscript = true;
								}
								else
								{
									font_0.IsSuperscript = true;
								}
							}
							break;
						}
						}
					}
				}
				if (text != null && text == "solid")
				{
					font_0.Underline = FontUnderlineType.Single;
					if (text2 == "double")
					{
						font_0.Underline = FontUnderlineType.Double;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	private void method_20(Style style_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			double num = 0.0;
			bool flag = false;
			bool flag2 = false;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string key;
				if ((key = xmlTextReader_0.LocalName.ToLower()) == null)
				{
					continue;
				}
				if (Class1742.dictionary_122 == null)
				{
					Class1742.dictionary_122 = new Dictionary<string, int>(15)
					{
						{ "border", 0 },
						{ "border-left", 1 },
						{ "border-right", 2 },
						{ "border-top", 3 },
						{ "border-bottom", 4 },
						{ "diagonal-bl-tr", 5 },
						{ "diagonal-tl-br", 6 },
						{ "rotation-angle", 7 },
						{ "direction", 8 },
						{ "shrink-to-fit", 9 },
						{ "wrap-option", 10 },
						{ "vertical-align", 11 },
						{ "repeat-content", 12 },
						{ "background-color", 13 },
						{ "cell-protect", 14 }
					};
				}
				if (!Class1742.dictionary_122.TryGetValue(key, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					if (xmlTextReader_0.Value == "none")
					{
						if (style_0.method_9())
						{
							style_0.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.None;
							style_0.Borders[BorderType.TopBorder].LineStyle = CellBorderType.None;
							style_0.Borders[BorderType.RightBorder].LineStyle = CellBorderType.None;
							style_0.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.None;
						}
					}
					else
					{
						method_21(style_0.Borders[BorderType.LeftBorder], xmlTextReader_0.Value);
						style_0.Borders[BorderType.TopBorder].Copy(style_0.Borders[BorderType.LeftBorder]);
						style_0.Borders[BorderType.RightBorder].Copy(style_0.Borders[BorderType.LeftBorder]);
						style_0.Borders[BorderType.BottomBorder].Copy(style_0.Borders[BorderType.LeftBorder]);
					}
					break;
				case 1:
					if (xmlTextReader_0.Value != "none")
					{
						method_21(style_0.Borders[BorderType.LeftBorder], xmlTextReader_0.Value);
					}
					else if (style_0.method_9())
					{
						style_0.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.None;
					}
					break;
				case 2:
					if (xmlTextReader_0.Value != "none")
					{
						method_21(style_0.Borders[BorderType.RightBorder], xmlTextReader_0.Value);
					}
					else if (style_0.method_9())
					{
						style_0.Borders[BorderType.RightBorder].LineStyle = CellBorderType.None;
					}
					break;
				case 3:
					if (xmlTextReader_0.Value != "none")
					{
						method_21(style_0.Borders[BorderType.TopBorder], xmlTextReader_0.Value);
					}
					else if (style_0.method_9())
					{
						style_0.Borders[BorderType.TopBorder].LineStyle = CellBorderType.None;
					}
					break;
				case 4:
					if (xmlTextReader_0.Value != "none")
					{
						method_21(style_0.Borders[BorderType.BottomBorder], xmlTextReader_0.Value);
					}
					else if (style_0.method_9())
					{
						style_0.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.None;
					}
					break;
				case 5:
					if (xmlTextReader_0.Value != "none")
					{
						method_21(style_0.Borders[BorderType.DiagonalUp], xmlTextReader_0.Value);
					}
					else if (style_0.method_9())
					{
						style_0.Borders[BorderType.DiagonalUp].LineStyle = CellBorderType.None;
					}
					break;
				case 6:
					if (xmlTextReader_0.Value != "none")
					{
						method_21(style_0.Borders[BorderType.DiagonalDown], xmlTextReader_0.Value);
					}
					else if (style_0.method_9())
					{
						style_0.Borders[BorderType.DiagonalDown].LineStyle = CellBorderType.None;
					}
					break;
				case 7:
					flag = true;
					num = Class1516.smethod_16(xmlTextReader_0.Value);
					if (num > 90.0)
					{
						num -= 360.0;
					}
					break;
				case 8:
					if (xmlTextReader_0.Value == "ttb")
					{
						flag2 = true;
					}
					break;
				case 9:
					style_0.ShrinkToFit = xmlTextReader_0.Value == "true";
					break;
				case 10:
					style_0.IsTextWrapped = xmlTextReader_0.Value == "wrap";
					break;
				case 11:
					switch (xmlTextReader_0.Value)
					{
					case "baseline":
					case "center":
					case "middle":
						style_0.VerticalAlignment = TextAlignmentType.Center;
						break;
					case "automatic":
					case "bottom":
						style_0.VerticalAlignment = TextAlignmentType.Bottom;
						break;
					case "top":
						style_0.VerticalAlignment = TextAlignmentType.Top;
						break;
					}
					break;
				case 12:
					bool_2 = xmlTextReader_0.Value == "true";
					break;
				case 13:
				{
					string value2;
					if (xmlTextReader_0.Value[0] == '#')
					{
						style_0.ForegroundColor = Class1516.smethod_11(xmlTextReader_0.Value);
						style_0.Pattern = BackgroundType.Solid;
					}
					else if ((value2 = xmlTextReader_0.Value) != null && value2 == "transparent")
					{
						style_0.Pattern = BackgroundType.None;
					}
					break;
				}
				case 14:
					switch (xmlTextReader_0.Value)
					{
					case "protected":
						style_0.IsLocked = true;
						style_0.IsFormulaHidden = false;
						break;
					case "formula-hidden":
						style_0.IsLocked = false;
						style_0.IsFormulaHidden = true;
						break;
					case "none":
						style_0.IsLocked = false;
						style_0.IsFormulaHidden = false;
						break;
					case "protected formula-hidden":
					case "formula-hidden protected":
						style_0.IsFormulaHidden = true;
						style_0.IsLocked = true;
						break;
					}
					break;
				}
			}
			if (flag2)
			{
				style_0.RotationAngle = 255;
			}
			else if (flag)
			{
				style_0.RotationAngle = (int)num;
			}
		}
		xmlTextReader_0.Skip();
	}

	private void method_21(Border border_0, string string_5)
	{
		int num = string_5.IndexOf('#');
		if (num != -1)
		{
			string text = string_5.Substring(num + 1);
			border_0.Color = Class1516.smethod_11(text);
			string_5 = string_5.Substring(0, num).Trim();
		}
		num = string_5.IndexOf(' ');
		string text2 = string_5;
		if (num != -1)
		{
			text2 = string_5.Substring(num + 1).Trim();
			string_5 = string_5.Substring(0, num);
		}
		switch (text2)
		{
		case "double":
			border_0.LineStyle = CellBorderType.Double;
			return;
		case "none":
			border_0.LineStyle = CellBorderType.None;
			return;
		}
		border_0.LineStyle = CellBorderType.Thin;
		if (string_5 == null || !(string_5 != ""))
		{
			return;
		}
		switch (string_5)
		{
		case "hair":
			border_0.LineStyle = CellBorderType.Hair;
			return;
		case "medium":
			border_0.LineStyle = CellBorderType.Medium;
			return;
		case "thick":
			border_0.LineStyle = CellBorderType.Thick;
			return;
		case "thin":
			border_0.LineStyle = CellBorderType.Thin;
			return;
		}
		double num2 = Class1516.smethod_2(class1489_0.double_0, string_5);
		if (num2 <= 0.05)
		{
			border_0.LineStyle = CellBorderType.Hair;
		}
		else if (num2 <= 1.0)
		{
			border_0.LineStyle = CellBorderType.Thin;
		}
		else if (num2 <= 2.5)
		{
			border_0.LineStyle = CellBorderType.Medium;
		}
		else if (num2 <= 4.0)
		{
			border_0.LineStyle = CellBorderType.Thick;
		}
	}
}
