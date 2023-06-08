using System.Collections.Generic;
using System.Xml;
using Aspose.Cells;
using ns1;
using ns2;
using ns22;
using ns25;
using ns26;

namespace ns15;

internal class Class1507
{
	private Class1489 class1489_0;

	private XmlTextReader xmlTextReader_0;

	internal Class1507(Class1489 class1489_1)
	{
		class1489_0 = class1489_1;
	}

	[Attribute0(true)]
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
			switch (xmlTextReader_1.LocalName.ToLower())
			{
			case "style":
				method_4();
				break;
			case "page-layout":
				method_0();
				break;
			default:
				xmlTextReader_1.Skip();
				break;
			}
		}
	}

	[Attribute0(true)]
	private void method_0()
	{
		Class1099 @class = new Class1099();
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) != null && localName == "name")
				{
					@class.string_0 = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (@class.string_0 == null)
		{
			xmlTextReader_0.Skip();
			return;
		}
		class1489_0.class1350_0.hashtable_0.Add(@class.string_0, @class);
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName.ToLower())
			{
			case "footer-style":
				method_2(@class, bool_0: false);
				break;
			case "header-style":
				method_2(@class, bool_0: true);
				break;
			case "page-layout-properties":
				method_1(@class);
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
	}

	[Attribute0(true)]
	private void method_1(Class1099 class1099_0)
	{
		bool flag = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_106 == null)
				{
					Class1742.dictionary_106 = new Dictionary<string, int>(16)
					{
						{ "page-width", 0 },
						{ "page-height", 1 },
						{ "num-format", 2 },
						{ "print-orientation", 3 },
						{ "margin-top", 4 },
						{ "margin-bottom", 5 },
						{ "margin-left", 6 },
						{ "margin-right", 7 },
						{ "first-page-number", 8 },
						{ "scale-to", 9 },
						{ "scale-to-X", 10 },
						{ "scale-to-Y", 11 },
						{ "table-centering", 12 },
						{ "writing-mode", 13 },
						{ "print", 14 },
						{ "print-page-order", 15 }
					};
				}
				if (!Class1742.dictionary_106.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					flag = true;
					class1099_0.double_0 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					break;
				case 1:
					flag = true;
					class1099_0.double_1 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					break;
				case 2:
					class1099_0.int_0 = int.Parse(xmlTextReader_0.Value);
					break;
				case 3:
					class1099_0.pageOrientationType_0 = ((xmlTextReader_0.Value.ToLower() == "portrait") ? PageOrientationType.Portrait : PageOrientationType.Landscape);
					break;
				case 4:
					class1099_0.double_2 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					break;
				case 5:
					class1099_0.double_4 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					break;
				case 6:
					class1099_0.double_3 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					break;
				case 7:
					class1099_0.double_5 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					break;
				case 8:
					if (Class1677.smethod_19(xmlTextReader_0.Value))
					{
						class1099_0.int_1 = int.Parse(xmlTextReader_0.Value);
						class1099_0.bool_0 = false;
					}
					else
					{
						class1099_0.bool_0 = true;
					}
					break;
				case 9:
				{
					class1099_0.bool_1 = true;
					string text = xmlTextReader_0.Value;
					if (text.EndsWith("%"))
					{
						text = text.Substring(0, text.Length - 1);
					}
					class1099_0.double_10 = Class1516.smethod_16(text);
					break;
				}
				case 10:
					class1099_0.bool_1 = false;
					class1099_0.double_12 = int.Parse(xmlTextReader_0.Value);
					break;
				case 11:
					class1099_0.bool_1 = false;
					class1099_0.double_11 = int.Parse(xmlTextReader_0.Value);
					break;
				case 12:
					switch (xmlTextReader_0.Value)
					{
					case "vertical":
						class1099_0.bool_3 = true;
						break;
					case "horizontal":
						class1099_0.bool_2 = true;
						break;
					case "both":
						class1099_0.bool_2 = true;
						class1099_0.bool_3 = true;
						break;
					}
					break;
				case 14:
				{
					string value2 = xmlTextReader_0.Value;
					string[] array = value2.Split(' ');
					for (int i = 0; i < array.Length; i++)
					{
						switch (array[i])
						{
						case "grid":
							class1099_0.bool_5 = true;
							break;
						case "headers":
							class1099_0.bool_4 = true;
							break;
						case "charts":
						case "drawings":
						case "objects":
							class1099_0.bool_6 = false;
							break;
						case "annotations":
							class1099_0.bool_7 = true;
							break;
						}
					}
					break;
				}
				case 15:
					class1099_0.printOrderType_0 = ((xmlTextReader_0.Value == "ltr") ? PrintOrderType.OverThenDown : PrintOrderType.DownThenOver);
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (flag)
		{
			class1099_0.method_0();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_2(Class1099 class1099_0, bool bool_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null && localName == "header-footer-properties")
			{
				method_3(class1099_0, bool_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_3(Class1099 class1099_0, bool bool_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "margin-top":
					if (!bool_0)
					{
						class1099_0.double_9 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					}
					break;
				case "margin-bottom":
					if (bool_0)
					{
						class1099_0.double_8 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					}
					break;
				case "min-height":
					if (bool_0)
					{
						class1099_0.double_6 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					}
					else
					{
						class1099_0.double_7 = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value) / 72.0;
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_4()
	{
		string text = null;
		string key = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "family":
					text = xmlTextReader_0.Value;
					break;
				case "name":
					key = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (text == null || text != "text" || xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		Font font = new Font(class1489_0.workbook_0.Worksheets, null, bool_0: false);
		class1489_0.class1350_0.hashtable_1.Add(key, font);
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null && localName == "text-properties")
			{
				method_5(font);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_5(Font font_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			string text = null;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string key;
				if ((key = xmlTextReader_0.LocalName.ToLower()) != null)
				{
					if (Class1742.dictionary_107 == null)
					{
						Class1742.dictionary_107 = new Dictionary<string, int>(9)
						{
							{ "font-name", 0 },
							{ "font-weight", 1 },
							{ "font-style", 2 },
							{ "text-line-through-style", 3 },
							{ "font-size", 4 },
							{ "color", 5 },
							{ "text-underline-style", 6 },
							{ "text-underline-type", 7 },
							{ "text-position", 8 }
						};
					}
					if (Class1742.dictionary_107.TryGetValue(key, out var value))
					{
						switch (value)
						{
						case 0:
							if (class1489_0.hashtable_10[xmlTextReader_0.Value] != null)
							{
								font_0.method_13((string)class1489_0.hashtable_10[xmlTextReader_0.Value]);
							}
							else
							{
								font_0.method_13(xmlTextReader_0.Value);
							}
							break;
						case 1:
							font_0.IsBold = xmlTextReader_0.Value.ToLower() == "bold";
							break;
						case 2:
							font_0.IsItalic = xmlTextReader_0.Value.ToLower() == "italic";
							break;
						case 3:
							font_0.IsStrikeout = xmlTextReader_0.Value.ToLower() == "solid";
							break;
						case 4:
							font_0.DoubleSize = Class1516.smethod_2(class1489_0.double_0, xmlTextReader_0.Value);
							break;
						case 5:
							font_0.Color = Class1516.smethod_11(xmlTextReader_0.Value);
							break;
						case 6:
							text = xmlTextReader_0.Value;
							break;
						case 7:
							_ = xmlTextReader_0.Value;
							break;
						case 8:
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
					if (text == "double")
					{
						font_0.Underline = FontUnderlineType.Double;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}
}
