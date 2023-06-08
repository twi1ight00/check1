using System.Collections.Generic;
using System.Text;
using System.Xml;
using Aspose.Cells;
using ns1;
using ns22;
using ns25;
using ns26;

namespace ns15;

internal class Class1511
{
	private Class1489 class1489_0;

	private XmlTextReader xmlTextReader_0;

	private Font font_0;

	internal Class1511(Class1489 class1489_1)
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
			string localName;
			if ((localName = xmlTextReader_1.LocalName) != null && localName == "master-page")
			{
				method_0();
			}
			else
			{
				xmlTextReader_1.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_0()
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1351 @class = new Class1351();
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "page-layout-name":
					@class.string_1 = xmlTextReader_0.Value;
					break;
				case "name":
					@class.string_0 = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		class1489_0.hashtable_8.Add(@class.string_0, @class);
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			font_0 = null;
			switch (xmlTextReader_0.LocalName)
			{
			case "footer-left":
				if (@class.string_5 == null)
				{
					@class.string_5 = new string[3];
				}
				if (method_1(@class.string_5))
				{
					@class.bool_1 = true;
				}
				break;
			case "footer":
				if (@class.string_3 == null)
				{
					@class.string_3 = new string[3];
				}
				method_1(@class.string_3);
				break;
			case "header-left":
				if (@class.string_4 == null)
				{
					@class.string_4 = new string[3];
				}
				if (method_1(@class.string_4))
				{
					@class.bool_0 = true;
				}
				break;
			case "header":
				if (@class.string_2 == null)
				{
					@class.string_2 = new string[3];
				}
				method_1(@class.string_2);
				break;
			}
		}
	}

	private bool method_1(string[] string_0)
	{
		bool result = true;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return false;
		}
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) != null && localName == "display")
				{
					result = bool.Parse(xmlTextReader_0.Value);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		StringBuilder stringBuilder = new StringBuilder();
		font_0 = null;
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName)
			{
			case "region-center":
				method_2(string_0, 1);
				break;
			case "region-right":
				method_2(string_0, 2);
				break;
			case "region-left":
				method_2(string_0, 0);
				break;
			case "p":
				method_3(stringBuilder);
				break;
			case "span":
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						string localName2;
						if ((localName2 = xmlTextReader_0.LocalName) != null && localName2 == "style-name")
						{
							_ = xmlTextReader_0.Value;
						}
					}
					xmlTextReader_0.MoveToElement();
				}
				method_3(stringBuilder);
				break;
			}
		}
		if (stringBuilder.Length != 0)
		{
			string_0[1] = stringBuilder.ToString();
		}
		return result;
	}

	[Attribute0(true)]
	private void method_2(string[] string_0, int int_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		StringBuilder stringBuilder = new StringBuilder();
		font_0 = null;
		xmlTextReader_0.Read();
		while (Class536.smethod_4(xmlTextReader_0))
		{
			switch (xmlTextReader_0.LocalName)
			{
			case "p":
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append('\n');
				}
				method_3(stringBuilder);
				break;
			case "span":
			{
				string text = null;
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						string localName;
						if ((localName = xmlTextReader_0.LocalName) != null && localName == "style-name")
						{
							text = xmlTextReader_0.Value;
						}
					}
					xmlTextReader_0.MoveToElement();
				}
				Font font_ = null;
				if (text != null)
				{
					font_ = (Font)class1489_0.class1350_0.hashtable_1[text];
				}
				method_4(font_0, font_, stringBuilder);
				font_0 = font_;
				method_3(stringBuilder);
				break;
			}
			}
		}
		if (stringBuilder != null && stringBuilder.Length != 0)
		{
			string_0[int_0] = stringBuilder.ToString();
		}
	}

	[Attribute0(true)]
	private void method_3(StringBuilder stringBuilder_0)
	{
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
				stringBuilder_0.Append(' ');
				xmlTextReader_0.Skip();
				continue;
			}
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				string text = xmlTextReader_0.Value.Replace("&", "&&");
				if (text.Length > 1 && text[0] >= '0' && text[0] <= '9')
				{
					bool flag = false;
					int num = stringBuilder_0.Length - 1;
					while (num >= 0)
					{
						if (stringBuilder_0[num] != '&')
						{
							if (stringBuilder_0[num] < '0' || stringBuilder_0[num] > '9')
							{
								break;
							}
							num--;
							continue;
						}
						flag = true;
						break;
					}
					if (flag)
					{
						stringBuilder_0.Append(' ');
					}
				}
				stringBuilder_0.Append(text);
				xmlTextReader_0.Skip();
				continue;
			}
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null)
			{
				if (Class1742.dictionary_112 == null)
				{
					Class1742.dictionary_112 = new Dictionary<string, int>(8)
					{
						{ "p", 0 },
						{ "page-number", 1 },
						{ "page-count", 2 },
						{ "sheet-name", 3 },
						{ "date", 4 },
						{ "time", 5 },
						{ "file-name", 6 },
						{ "span", 7 }
					};
				}
				if (Class1742.dictionary_112.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
						if (stringBuilder_0.Length != 0)
						{
							stringBuilder_0.Append('\n');
						}
						method_3(stringBuilder_0);
						continue;
					case 1:
						stringBuilder_0.Append("&P");
						xmlTextReader_0.Skip();
						continue;
					case 2:
						stringBuilder_0.Append("&N");
						xmlTextReader_0.Skip();
						continue;
					case 3:
						stringBuilder_0.Append("&A");
						xmlTextReader_0.Skip();
						continue;
					case 4:
						stringBuilder_0.Append("&D");
						xmlTextReader_0.Skip();
						continue;
					case 5:
						stringBuilder_0.Append("&T");
						xmlTextReader_0.Skip();
						continue;
					case 6:
					{
						bool flag2 = false;
						if (xmlTextReader_0.HasAttributes)
						{
							while (xmlTextReader_0.MoveToNextAttribute())
							{
								string localName3;
								if ((localName3 = xmlTextReader_0.LocalName) != null && localName3 == "display")
								{
									flag2 = xmlTextReader_0.Value == "full";
								}
							}
							xmlTextReader_0.MoveToElement();
						}
						if (flag2)
						{
							stringBuilder_0.Append("&Z");
						}
						else
						{
							stringBuilder_0.Append("&F");
						}
						xmlTextReader_0.Skip();
						continue;
					}
					case 7:
					{
						string text2 = null;
						if (xmlTextReader_0.HasAttributes)
						{
							while (xmlTextReader_0.MoveToNextAttribute())
							{
								string localName2;
								if ((localName2 = xmlTextReader_0.LocalName) != null && localName2 == "style-name")
								{
									text2 = xmlTextReader_0.Value;
								}
							}
							xmlTextReader_0.MoveToElement();
						}
						Font font_ = null;
						if (text2 != null)
						{
							font_ = (Font)class1489_0.class1350_0.hashtable_1[text2];
						}
						method_4(font_0, font_, stringBuilder_0);
						font_0 = font_;
						method_3(stringBuilder_0);
						continue;
					}
					}
				}
			}
			xmlTextReader_0.Skip();
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_4(Font font_1, Font font_2, StringBuilder stringBuilder_0)
	{
		if (font_1 == null && font_2 == null)
		{
			return;
		}
		if (font_1 == null && font_2 != null)
		{
			if (font_2.Name != class1489_0.workbook_0.Worksheets.DefaultFont.Name)
			{
				stringBuilder_0.Append("&\"");
				stringBuilder_0.Append(font_2.Name);
				stringBuilder_0.Append("\"");
			}
			if (font_2.IsModified(StyleModifyFlag.FontSize))
			{
				stringBuilder_0.Append("&");
				stringBuilder_0.Append(font_2.Size);
			}
			if (font_2.IsBold)
			{
				stringBuilder_0.Append("&B");
			}
			if (font_2.IsItalic)
			{
				stringBuilder_0.Append("&I");
			}
			switch (font_2.Underline)
			{
			case FontUnderlineType.Single:
			case FontUnderlineType.Accounting:
				stringBuilder_0.Append("&U");
				break;
			case FontUnderlineType.Double:
			case FontUnderlineType.DoubleAccounting:
				stringBuilder_0.Append("&E");
				break;
			}
			if (font_2.IsStrikeout)
			{
				stringBuilder_0.Append("&S");
			}
			if (font_2.IsSubscript)
			{
				stringBuilder_0.Append("&Y");
			}
			if (font_2.IsSuperscript)
			{
				stringBuilder_0.Append("&X");
			}
		}
		else if (font_1 != null && font_2 == null)
		{
			if (font_1.IsBold)
			{
				stringBuilder_0.Append("&B");
			}
			if (font_1.IsItalic)
			{
				stringBuilder_0.Append("&I");
			}
			switch (font_1.Underline)
			{
			case FontUnderlineType.Single:
			case FontUnderlineType.Accounting:
				stringBuilder_0.Append("&U");
				break;
			case FontUnderlineType.Double:
			case FontUnderlineType.DoubleAccounting:
				stringBuilder_0.Append("&E");
				break;
			}
			if (font_1.IsStrikeout)
			{
				stringBuilder_0.Append("&S");
			}
			if (font_1.IsSubscript)
			{
				stringBuilder_0.Append("&Y");
			}
			if (font_1.IsSuperscript)
			{
				stringBuilder_0.Append("&X");
			}
		}
		else
		{
			if (font_1.method_18(font_2))
			{
				return;
			}
			if (font_1.IsSubscript && !font_2.IsSubscript)
			{
				stringBuilder_0.Append("&X");
			}
			if (font_1.IsSuperscript && !font_2.IsSuperscript)
			{
				stringBuilder_0.Append("&Y");
			}
			if (font_1.IsStrikeout && !font_2.IsStrikeout)
			{
				stringBuilder_0.Append("&S");
			}
			if (font_1.Underline != font_2.Underline)
			{
				switch (font_1.Underline)
				{
				case FontUnderlineType.Single:
				case FontUnderlineType.Accounting:
					stringBuilder_0.Append("&U");
					break;
				case FontUnderlineType.Double:
				case FontUnderlineType.DoubleAccounting:
					stringBuilder_0.Append("&E");
					break;
				}
			}
			if (font_1.IsItalic && !font_2.IsItalic)
			{
				stringBuilder_0.Append("&I");
			}
			if (font_1.IsBold && !font_2.IsBold)
			{
				stringBuilder_0.Append("&B");
			}
			if (font_1.Name != font_2.Name)
			{
				stringBuilder_0.Append("&\"");
				stringBuilder_0.Append(font_2.Name);
				stringBuilder_0.Append("\"");
			}
			if (font_1.Size != font_2.Size)
			{
				stringBuilder_0.Append("&");
				stringBuilder_0.Append(font_2.Size);
			}
			if (font_2.IsItalic && !font_1.IsItalic)
			{
				stringBuilder_0.Append("&I");
			}
			if (font_2.IsBold && !font_1.IsBold)
			{
				stringBuilder_0.Append("&B");
			}
			if (font_2.Underline != font_1.Underline)
			{
				switch (font_2.Underline)
				{
				case FontUnderlineType.Single:
				case FontUnderlineType.Accounting:
					stringBuilder_0.Append("&U");
					break;
				case FontUnderlineType.Double:
				case FontUnderlineType.DoubleAccounting:
					stringBuilder_0.Append("&E");
					break;
				}
			}
			if (font_2.IsStrikeout && !font_1.IsStrikeout)
			{
				stringBuilder_0.Append("&S");
			}
			if (font_2.IsSubscript && !font_1.IsSubscript)
			{
				stringBuilder_0.Append("&Y");
			}
			if (font_2.IsSuperscript && !font_1.IsSuperscript)
			{
				stringBuilder_0.Append("&X");
			}
			if (font_2.IsModified(StyleModifyFlag.FontColor))
			{
				stringBuilder_0.Append("&");
				stringBuilder_0.Append(Class1516.smethod_8(font_2.Color));
			}
		}
	}
}
