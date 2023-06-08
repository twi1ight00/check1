using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns1;
using ns22;

namespace ns8;

internal class Class735
{
	private Class734 class734_0;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	private Hashtable hashtable_2;

	private ArrayList arrayList_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private bool bool_0;

	private string string_3;

	private string string_4;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private int int_0;

	private IStreamProvider istreamProvider_0;

	[SpecialName]
	public void method_0(IStreamProvider istreamProvider_1)
	{
		istreamProvider_0 = istreamProvider_1;
		class734_0.method_0(istreamProvider_0);
	}

	public Class735(string string_5, Workbook workbook_0)
	{
		class734_0 = new Class734(workbook_0, this);
		class734_0.method_76(hashtable_1 = new Hashtable());
		string_0 = string_5;
		hashtable_0 = new Hashtable();
		hashtable_2 = new Hashtable();
		bool_0 = false;
		bool_1 = false;
		arrayList_0 = new ArrayList();
	}

	public Class735(string string_5, Workbook workbook_0, HTMLLoadOptions htmlloadOptions_0)
	{
		class734_0 = new Class734(workbook_0, this);
		class734_0.method_77(htmlloadOptions_0);
		string_1 = htmlloadOptions_0.AttachedFilesDirectory;
		string_0 = string_5;
		hashtable_0 = new Hashtable();
		hashtable_2 = new Hashtable();
		class734_0.method_76(hashtable_1 = new Hashtable());
		bool_0 = false;
		bool_1 = false;
		arrayList_0 = new ArrayList();
	}

	public Class735(Stream stream_0, Workbook workbook_0, HTMLLoadOptions htmlloadOptions_0)
	{
		class734_0 = new Class734(workbook_0, this);
		class734_0.method_77(htmlloadOptions_0);
		string_1 = htmlloadOptions_0.AttachedFilesDirectory;
		if (stream_0 is FileStream)
		{
			string_0 = ((FileStream)stream_0).Name;
		}
		hashtable_0 = new Hashtable();
		hashtable_2 = new Hashtable();
		class734_0.method_76(hashtable_1 = new Hashtable());
		bool_0 = false;
		bool_1 = false;
		arrayList_0 = new ArrayList();
	}

	public void method_1(string string_5, ArrayList arrayList_1)
	{
		if (string_5 == "!octype")
		{
			return;
		}
		Hashtable hashtable = method_18(arrayList_1);
		string key;
		if ((key = string_5) == null)
		{
			return;
		}
		if (Class1742.dictionary_22 == null)
		{
			Class1742.dictionary_22 = new Dictionary<string, int>(26)
			{
				{ "style", 0 },
				{ "link", 1 },
				{ "col", 2 },
				{ "table", 3 },
				{ "p", 4 },
				{ "tr", 5 },
				{ "td", 6 },
				{ "th", 7 },
				{ "html", 8 },
				{ "title", 9 },
				{ "a", 10 },
				{ "span", 11 },
				{ "img", 12 },
				{ "font", 13 },
				{ "sup", 14 },
				{ "sub", 15 },
				{ "s", 16 },
				{ "h1", 17 },
				{ "h2", 18 },
				{ "h3", 19 },
				{ "h4", 20 },
				{ "h5", 21 },
				{ "h6", 22 },
				{ "u", 23 },
				{ "br", 24 },
				{ "b", 25 }
			};
		}
		if (!Class1742.dictionary_22.TryGetValue(key, out var value))
		{
			return;
		}
		switch (value)
		{
		case 0:
			class734_0.method_35();
			break;
		case 1:
		{
			object obj2 = hashtable["id"];
			object obj3 = hashtable["href"];
			if (obj2 != null && obj2.Equals("shLink") && obj3 != null)
			{
				arrayList_0.Add(obj3);
			}
			break;
		}
		case 2:
			class734_0.method_4(hashtable);
			break;
		case 3:
		{
			object obj = hashtable["class"];
			if (obj != null)
			{
				class734_0.method_8(hashtable);
			}
			bool_3 = true;
			if (!bool_5)
			{
				int_0++;
			}
			break;
		}
		case 4:
			bool_4 = true;
			class734_0.method_26(hashtable);
			if (!bool_3)
			{
				class734_0.method_1(hashtable);
			}
			break;
		case 5:
			if (bool_1)
			{
				class734_0.method_14(hashtable);
			}
			else
			{
				class734_0.method_1(hashtable);
			}
			break;
		case 6:
			bool_5 = true;
			if (bool_1)
			{
				class734_0.method_16(hashtable);
			}
			else
			{
				class734_0.method_7(hashtable);
			}
			break;
		case 7:
			class734_0.method_5(hashtable);
			break;
		case 8:
			method_17(arrayList_1);
			break;
		case 9:
			class734_0.method_33();
			break;
		case 10:
			class734_0.method_18(hashtable);
			break;
		case 11:
		{
			class734_0.method_19(bool_18: true);
			string text = (string)hashtable["style"];
			if (text == null)
			{
				break;
			}
			if (!bool_3 && bool_4)
			{
				class734_0.method_28(hashtable);
				break;
			}
			if (text.Equals("mso-spacerun:yes"))
			{
				class734_0.method_29(hashtable);
				break;
			}
			if (text.Equals("display:none"))
			{
				class734_0.method_25(hashtable);
				break;
			}
			bool_1 = true;
			if (text.IndexOf("z-index") > -1)
			{
				class734_0.method_30(hashtable, method_16());
			}
			else
			{
				class734_0.method_27(hashtable);
			}
			break;
		}
		case 12:
			class734_0.method_21(hashtable);
			break;
		case 13:
			bool_6 = true;
			if (!bool_3 && bool_4)
			{
				class734_0.method_28(hashtable);
				break;
			}
			hashtable_2 = hashtable;
			class734_0.method_51(bool_18: false);
			class734_0.method_52(bool_18: true);
			class734_0.method_53(bool_18: true);
			class734_0.method_54();
			break;
		case 14:
			if (bool_5 && !bool_6)
			{
				class734_0.method_44();
			}
			else if (!hashtable_2.ContainsKey("sup"))
			{
				hashtable_2.Add("sup", true);
			}
			break;
		case 15:
			if (bool_5 && !bool_6)
			{
				class734_0.method_45();
			}
			else
			{
				hashtable_2.Add("sub", true);
			}
			break;
		case 16:
			if (bool_5 && !bool_6)
			{
				class734_0.method_48();
			}
			else
			{
				hashtable_2.Add("s", true);
			}
			break;
		case 17:
			method_2("h1", hashtable);
			break;
		case 18:
			method_2("h2", hashtable);
			break;
		case 19:
			method_2("h3", hashtable);
			break;
		case 20:
			method_2("h4", hashtable);
			break;
		case 21:
			method_2("h5", hashtable);
			break;
		case 22:
			method_2("h6", hashtable);
			break;
		case 23:
			class734_0.method_46();
			break;
		case 24:
			class734_0.method_37();
			break;
		case 25:
			class734_0.method_47();
			break;
		}
	}

	private void method_2(string string_5, Hashtable hashtable_3)
	{
		class734_0.method_1(hashtable_3);
		string value = null;
		string key;
		if ((key = string_5) != null)
		{
			if (Class1742.dictionary_23 == null)
			{
				Class1742.dictionary_23 = new Dictionary<string, int>(6)
				{
					{ "h1", 0 },
					{ "h2", 1 },
					{ "h3", 2 },
					{ "h4", 3 },
					{ "h5", 4 },
					{ "h6", 5 }
				};
			}
			if (Class1742.dictionary_23.TryGetValue(key, out var value2))
			{
				switch (value2)
				{
				case 0:
					value = "font-size:24pt;font-weight:bold";
					break;
				case 1:
					value = "font-size:18pt;font-weight:bold";
					break;
				case 2:
					value = "font-size:13.5pt;font-weight:bold";
					break;
				case 3:
					value = "font-size:12pt;font-weight:bold";
					break;
				case 4:
					value = "font-size:10pt;font-weight:bold";
					break;
				case 5:
					value = "font-size:7.5pt;font-weight:bold";
					break;
				}
			}
		}
		hashtable_3.Add("style", value);
		class734_0.method_7(hashtable_3);
	}

	public void method_3(string string_5, ArrayList arrayList_1)
	{
		string key;
		if ((key = string_5) == null)
		{
			return;
		}
		if (Class1742.dictionary_24 == null)
		{
			Class1742.dictionary_24 = new Dictionary<string, int>(17)
			{
				{ "/style", 0 },
				{ "/td", 1 },
				{ "/th", 2 },
				{ "/span", 3 },
				{ "/title", 4 },
				{ "/tr", 5 },
				{ "/font", 6 },
				{ "/table", 7 },
				{ "/p", 8 },
				{ "/body", 9 },
				{ "/a", 10 },
				{ "/h1", 11 },
				{ "/h2", 12 },
				{ "/h3", 13 },
				{ "/h4", 14 },
				{ "/h5", 15 },
				{ "/h6", 16 }
			};
		}
		if (!Class1742.dictionary_24.TryGetValue(key, out var value))
		{
			return;
		}
		switch (value)
		{
		case 0:
			class734_0.method_36();
			break;
		case 1:
		case 2:
			bool_5 = false;
			if (!bool_1)
			{
				method_4();
			}
			else
			{
				class734_0.method_17();
			}
			break;
		case 3:
			class734_0.method_19(bool_18: false);
			bool_1 = false;
			class734_0.method_31();
			break;
		case 4:
			class734_0.method_34();
			break;
		case 5:
			if (bool_1)
			{
				class734_0.method_15();
			}
			break;
		case 6:
			bool_6 = false;
			class734_0.method_43(hashtable_2);
			class734_0.method_49(bool_18: false);
			class734_0.method_50(bool_18: false);
			break;
		case 7:
			bool_3 = false;
			break;
		case 8:
			method_5();
			bool_4 = false;
			break;
		case 9:
			if (int_0 == 1)
			{
				class734_0.method_64();
			}
			break;
		case 10:
			class734_0.method_40();
			break;
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
			class734_0.method_41();
			class734_0.method_1(null);
			break;
		}
	}

	private void method_4()
	{
		if (class734_0.method_66() > 0)
		{
			class734_0.method_42();
			if (class734_0.method_11() != null)
			{
				class734_0.method_67();
			}
			class734_0.method_65();
		}
		else
		{
			class734_0.method_41();
		}
		class734_0.method_69(bool_18: false);
		class734_0.method_59();
		class734_0.method_75(0);
		class734_0.method_53(bool_18: false);
		bool_2 = false;
	}

	private void method_5()
	{
		if (class734_0.method_66() > 0)
		{
			class734_0.method_42();
			if (class734_0.method_11() != null && class734_0.method_11().Value != null)
			{
				class734_0.method_67();
			}
			class734_0.method_65();
		}
		else
		{
			class734_0.method_41();
		}
	}

	public void method_6(string string_5)
	{
		class734_0.method_39(string_5);
	}

	public void method_7(string string_5)
	{
		if (string_5.StartsWith("table"))
		{
			if (!bool_0)
			{
				method_9(string_5);
			}
		}
		else if (string_5.StartsWith("[if gte vml 1]"))
		{
			method_13(string_5);
		}
		else if (string_5.StartsWith("[if !mso & vml]"))
		{
			method_12(string_5);
		}
		else if (string_5.IndexOf("xml") != -1)
		{
			method_11(string_5);
		}
	}

	public void method_8(Stream stream_0)
	{
		ArrayList arrayList = new ArrayList();
		Class727 @class = new Class727();
		@class.method_8(stream_0);
		arrayList = @class.method_12();
		if (arrayList.Count > 0)
		{
			SetStyle(arrayList);
		}
	}

	public void method_9(string string_5)
	{
		if (!(string_5 == "/*") && !(string_5 == "*/") && !string_5.StartsWith("@import"))
		{
			ArrayList arrayList = new ArrayList();
			Class727 @class = new Class727();
			byte[] bytes = Encoding.Default.GetBytes(string_5);
			Stream stream_ = new MemoryStream(bytes);
			@class.method_8(stream_);
			arrayList = @class.method_12();
			if (arrayList.Count > 0)
			{
				SetStyle(arrayList);
			}
		}
	}

	private void SetStyle(ArrayList arrayList_1)
	{
		foreach (Class726 item in arrayList_1)
		{
			if (method_34().method_73() != null && !method_34().method_73().ContainsKey(item.method_9()) && !item.method_9().Equals("@page"))
			{
				int num = 0;
				Style style;
				if (item.method_9().Equals("style0"))
				{
					style = method_34().Workbook.DefaultStyle;
					num = 0;
				}
				else
				{
					style = method_34().Workbook.CreateStyle();
					num = -1;
				}
				method_10(item.method_0(), style);
				if (num < 0)
				{
					num = method_34().Workbook.Worksheets.method_58().method_3(style);
				}
				else
				{
					method_34().Workbook.DefaultStyle = style;
				}
				method_34().method_73().Add(item.method_9(), num);
			}
		}
	}

	private void method_10(ArrayList arrayList_1, Style style_0)
	{
		Aspose.Cells.Font font = style_0.Font;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		foreach (Class724 item in arrayList_1)
		{
			string name;
			if ((name = item.Name) == null)
			{
				continue;
			}
			if (Class1742.dictionary_25 == null)
			{
				Class1742.dictionary_25 = new Dictionary<string, int>(29)
				{
					{ "color", 0 },
					{ "background", 1 },
					{ "background-color", 2 },
					{ "mso-number-format", 3 },
					{ "white-space", 4 },
					{ "font-size", 5 },
					{ "text-align", 6 },
					{ "vertical-align", 7 },
					{ "font-family", 8 },
					{ "font-style", 9 },
					{ "font-weight", 10 },
					{ "text-underline-style", 11 },
					{ "border-top", 12 },
					{ "border-right", 13 },
					{ "border-bottom", 14 },
					{ "border-left", 15 },
					{ "mso-diagonal-down", 16 },
					{ "mso-diagonal-up", 17 },
					{ "border", 18 },
					{ "border-width", 19 },
					{ "border-style", 20 },
					{ "border-color", 21 },
					{ "mso-pattern", 22 },
					{ "mso-rotate", 23 },
					{ "mso-char-indent-count", 24 },
					{ "mso-protection", 25 },
					{ "text-decoration", 26 },
					{ "mso-text-underline", 27 },
					{ "ms-text-underline", 28 }
				};
			}
			if (!Class1742.dictionary_25.TryGetValue(name, out var value))
			{
				continue;
			}
			switch (value)
			{
			case 0:
				font.Color = Class732.smethod_10(item.Value);
				break;
			case 1:
			case 2:
				if (item.Value != "auto")
				{
					text = item.Value;
				}
				break;
			case 3:
				Class732.smethod_12(style_0, item.Value);
				break;
			case 4:
				style_0.IsTextWrapped = item.Value.Equals("normal");
				break;
			case 5:
				if (item.Value.EndsWith("pt"))
				{
					string value2 = item.Value.Substring(0, item.Value.Length - 2);
					font.DoubleSize = Convert.ToDouble(value2);
				}
				break;
			case 6:
			{
				TextAlignmentType verticalAlignment = Class732.smethod_4(item.Value);
				style_0.HorizontalAlignment = verticalAlignment;
				break;
			}
			case 7:
			{
				TextAlignmentType verticalAlignment = Class732.smethod_5(item.Value);
				style_0.VerticalAlignment = verticalAlignment;
				break;
			}
			case 8:
				Class733.smethod_8(item.Value, font);
				break;
			case 9:
				font.IsItalic = item.Value.Equals("italic");
				break;
			case 10:
				if (item.Value == "bold")
				{
					font.IsBold = true;
				}
				else if (item.Value == "plain")
				{
					font.IsBold = false;
				}
				else if (item.Value == "normal")
				{
					font.IsBold = false;
				}
				else
				{
					font.IsBold = Convert.ToInt32(item.Value) >= 700;
				}
				break;
			case 11:
				Class732.smethod_6(font, item.Value);
				break;
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
				Class731.SetBorder(item.Name, item.Value, style_0);
				break;
			case 19:
				text3 = item.Value;
				break;
			case 20:
				text4 = item.Value;
				break;
			case 21:
			{
				string value3 = item.Value;
				text5 = ((value3.IndexOf(" ") == -1) ? item.Value : item.Value.Substring(0, value3.IndexOf(" ")));
				break;
			}
			case 22:
				text2 = item.Value;
				break;
			case 23:
				style_0.RotationAngle = Convert.ToInt32(item.Value);
				break;
			case 24:
				style_0.IndentLevel = Convert.ToInt32(item.Value);
				break;
			case 25:
				if (item.Value.IndexOf("unlocked") != -1)
				{
					style_0.IsLocked = false;
				}
				if (item.Value.IndexOf("hidden") != -1)
				{
					style_0.IsFormulaHidden = true;
				}
				break;
			case 26:
				if (item.Value == "underline")
				{
					font.Underline = Class732.smethod_7(item.Value);
				}
				if (item.Value == "line-through")
				{
					font.IsStrikeout = true;
				}
				break;
			case 27:
				font.Underline = Class732.smethod_7(item.Value);
				break;
			case 28:
				font.Underline = Class732.smethod_7(item.Value);
				break;
			}
		}
		if (text != null && text2 == null)
		{
			style_0.ForegroundColor = Class732.smethod_10(text);
			style_0.BackgroundColor = style_0.ForegroundColor;
			style_0.Pattern = BackgroundType.Solid;
		}
		if (text == null && text2 != null)
		{
			Class732.smethod_8(text2, style_0);
		}
		if (text != null && text2 != null)
		{
			Color color_ = Class732.smethod_10(text);
			Class732.smethod_9(text2, style_0, color_);
		}
		if (text3 != null && text5 != null && text4 != null)
		{
			Class731.SetBorder(text3, text4, text5, style_0);
		}
	}

	private void method_11(string string_5)
	{
		int num = string_5.IndexOf("<xml>");
		string text = "<![endif]";
		if (string_5.EndsWith(text))
		{
			string string_6 = string_5.Substring(num, string_5.Length - text.Length - num);
			string string_7 = method_19(string_6);
			XmlDocument xmlDocument = Class1188.smethod_1(method_14(string_7));
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("o:DocumentProperties");
			if (elementsByTagName.Count > 0)
			{
				BuiltInDocumentPropertyCollection builtInDocumentProperties = method_34().Worksheets.BuiltInDocumentProperties;
				Class733.smethod_0(elementsByTagName, builtInDocumentProperties);
			}
			XmlNodeList elementsByTagName2 = xmlDocument.GetElementsByTagName("o:CustomDocumentProperties");
			if (elementsByTagName2.Count > 0)
			{
				CustomDocumentPropertyCollection customDocumentProperties = method_34().Worksheets.CustomDocumentProperties;
				Class733.smethod_13(elementsByTagName2, customDocumentProperties);
			}
			method_21(xmlDocument);
			method_23(xmlDocument);
			method_24(xmlDocument);
			if (method_34().method_70() != null)
			{
				method_22(xmlDocument);
			}
		}
	}

	[Attribute0(true)]
	private void method_12(string string_5)
	{
		int length = "[if !mso & vml]>".Length;
		string text = "<![endif]";
		if (!string_5.EndsWith(text))
		{
			return;
		}
		string string_6 = string_5.Substring(length, string_5.Length - text.Length - length);
		string string_7 = method_20(string_6);
		XmlDocument xmlDocument = Class1188.smethod_1(method_15(string_7));
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("ele");
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			XmlElement xmlElement = (XmlElement)elementsByTagName[i];
			XmlNodeList childNodes = xmlElement.ChildNodes;
			for (int j = 0; j < childNodes.Count; j++)
			{
				object obj = childNodes[j];
				if (obj is XmlText)
				{
					continue;
				}
				XmlElement xmlElement2 = (XmlElement)obj;
				string localName = xmlElement2.LocalName;
				string text2;
				if ((text2 = localName) == null || !(text2 == "span"))
				{
					continue;
				}
				string attribute = xmlElement2.GetAttribute("style");
				string[] array = attribute.Split(';');
				string[] array2 = array;
				foreach (string text3 in array2)
				{
					string[] array3 = text3.Split(':');
					string text4 = Class733.smethod_9(array3[0]);
					string text5;
					if ((text5 = text4) != null && text5 == "width")
					{
						class734_0.method_32(Class733.smethod_5(array3[1]));
					}
				}
			}
		}
	}

	private void method_13(string string_5)
	{
		int length = "[if gte vml 1]>".Length;
		string text = "<![endif]";
		if (string_5.EndsWith(text))
		{
			string string_6 = string_5.Substring(length, string_5.Length - text.Length - length);
			string string_7 = method_20(string_6);
			XmlDocument xmlDocument = Class1188.smethod_1(method_15(string_7));
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("ele");
			if (elementsByTagName.Count > 0)
			{
				string text2 = method_16();
				Class733.smethod_1(elementsByTagName, hashtable_1, text2, istreamProvider_0);
			}
			XmlNodeList elementsByTagName2 = xmlDocument.GetElementsByTagName("o:CustomDocumentProperties");
			if (elementsByTagName2.Count > 0)
			{
				CustomDocumentPropertyCollection customDocumentProperties = method_34().Worksheets.CustomDocumentProperties;
				Class733.smethod_13(elementsByTagName2, customDocumentProperties);
			}
		}
	}

	private string method_14(string string_5)
	{
		return string_5.Replace("&", "&amp;").Replace("<=", "&lt;").Replace("<br>", "\n")
			.Replace("<![if excel]>", "<SkipEle>")
			.Replace("<![if gte mso 9]>", "<SkipEle>")
			.Replace("<![endif]>", "</SkipEle>");
	}

	private string method_15(string string_5)
	{
		return string_5.Replace("<=", "&lt;").Replace("<br>", "\n").Replace("<![if excel]>", "<SkipEle>")
			.Replace("<![if gte mso 9]>", "<SkipEle>")
			.Replace("<![endif]>", "</SkipEle>");
	}

	private string method_16()
	{
		string text = null;
		if (string_4 == null)
		{
			if (string_1 == null)
			{
				if (string_0 == null)
				{
					return null;
				}
				if (string_0.LastIndexOf("\\") == -1)
				{
					return string_0.Substring(0, string_0.LastIndexOf("/")) + "/";
				}
				return string_0.Substring(0, string_0.LastIndexOf("\\")) + "\\";
			}
			return string_1;
		}
		return string_4;
	}

	private void method_17(ArrayList arrayList_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<html ");
		foreach (Class724 item in arrayList_1)
		{
			stringBuilder.Append(item.Name);
			stringBuilder.Append("=\"");
			stringBuilder.Append(item.Value);
			stringBuilder.Append("\" ");
		}
		stringBuilder.Append(">");
		string_2 = stringBuilder.ToString();
	}

	private Hashtable method_18(ArrayList arrayList_1)
	{
		Hashtable hashtable = new Hashtable();
		foreach (Class724 item in arrayList_1)
		{
			if (item.Name != "" && hashtable[item.Name] == null)
			{
				hashtable.Add(item.Name, item.Value);
			}
		}
		return hashtable;
	}

	private string method_19(string string_5)
	{
		StringBuilder stringBuilder = new StringBuilder();
		return stringBuilder.Append(string_2).Append(string_5).Append("</html>")
			.ToString();
	}

	private string method_20(string string_5)
	{
		StringBuilder stringBuilder = new StringBuilder();
		return stringBuilder.Append(string_2).Append("<ele>").Append(string_5)
			.Append("</ele></html>")
			.ToString();
	}

	private void method_21(XmlDocument xmlDocument_0)
	{
		Class733.smethod_10(xmlDocument_0, method_34().Workbook);
	}

	private void method_22(XmlDocument xmlDocument_0)
	{
		Class733.smethod_11(xmlDocument_0, method_34());
	}

	private void method_23(XmlDocument xmlDocument_0)
	{
		XmlNodeList elementsByTagName = xmlDocument_0.GetElementsByTagName("x:Stylesheet");
		if (elementsByTagName.Count != 1)
		{
			return;
		}
		bool_0 = true;
		string parsedPath = "";
		XmlElement xmlElement = (XmlElement)elementsByTagName.Item(0);
		string origPath = xmlElement.GetAttribute("HRef");
		if (origPath.StartsWith("file:///"))
		{
			parsedPath = Class732.smethod_2(origPath);
		}
		else
		{
			if (string_0 != null)
			{
				parsedPath = Path.GetDirectoryName(string_0) + "\\" + Class732.smethod_2(origPath);
			}
			if (string_1 != null)
			{
				parsedPath = string_1 + "\\" + Class732.smethod_2(origPath);
			}
		}
		ArrayList arrayList = new ArrayList();
		Class727 @class = new Class727();
		@class.method_8(istreamProvider_0.GetStream(ref origPath, parsedPath));
		if (@class.Source != null)
		{
			arrayList = @class.method_12();
			SetStyle(arrayList);
		}
	}

	private void method_24(XmlDocument xmlDocument_0)
	{
		SheetType type = SheetType.Worksheet;
		XmlNodeList elementsByTagName = xmlDocument_0.GetElementsByTagName("x:ExcelWorksheet");
		if (elementsByTagName.Count > 0)
		{
			method_34().Worksheets.Clear();
		}
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			string text = "";
			Stream stream = null;
			string origPath = null;
			int index = method_34().Worksheets.Add();
			Worksheet worksheet = method_34().Worksheets[index];
			XmlElement xmlElement = (XmlElement)elementsByTagName[i];
			XmlNodeList childNodes = xmlElement.ChildNodes;
			for (int j = 0; j < childNodes.Count; j++)
			{
				object obj = childNodes[j];
				if (obj is XmlText)
				{
					continue;
				}
				XmlElement xmlElement2 = (XmlElement)obj;
				string innerText = xmlElement2.InnerText;
				switch (xmlElement2.LocalName)
				{
				case "ConditionalFormatting":
				{
					XmlNodeList childNodes2 = xmlElement2.ChildNodes;
					method_28(childNodes2, worksheet);
					break;
				}
				case "WorksheetOptions":
				{
					XmlNodeList childNodes3 = xmlElement2.ChildNodes;
					method_25(childNodes3, worksheet);
					break;
				}
				case "Name":
					worksheet.Name = innerText;
					break;
				case "WorksheetSource":
					origPath = xmlElement2.GetAttribute("HRef");
					if (origPath.StartsWith("file:///"))
					{
						text = Class732.smethod_2(origPath);
					}
					else
					{
						string text2 = origPath.Substring(0, (origPath.LastIndexOf("/") == -1) ? origPath.LastIndexOf("\\") : origPath.LastIndexOf("/"));
						if (string_0 != null)
						{
							text = Path.GetDirectoryName(string_0) + "\\" + Class732.smethod_2(origPath);
							string_4 = Path.GetDirectoryName(string_0) + "\\" + text2 + "\\";
						}
						if (string_1 != null)
						{
							text = string_1 + "\\" + Class732.smethod_2(origPath);
							string_4 = string_1 + text2 + "\\";
						}
					}
					stream = istreamProvider_0.GetStream(ref origPath, text);
					break;
				case "WorksheetType":
					if (innerText.Equals("Chart"))
					{
						type = SheetType.Chart;
					}
					break;
				}
			}
			worksheet.Type = type;
			type = SheetType.Worksheet;
			if (stream != null)
			{
				string text3 = ((text == "") ? origPath : text);
				hashtable_0.Add(worksheet.Name + '\b' + text3, stream);
			}
		}
		if (elementsByTagName.Count == 1 || hashtable_0.Count == 0)
		{
			method_34().method_71(method_34().Worksheets[0]);
			method_34().method_72(method_34().method_70().Cells);
		}
	}

	private void method_25(XmlNodeList xmlNodeList_0, Worksheet worksheet_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			string localName = xmlElement.LocalName;
			string key;
			if ((key = localName) == null)
			{
				continue;
			}
			if (Class1742.dictionary_26 == null)
			{
				Class1742.dictionary_26 = new Dictionary<string, int>(7)
				{
					{ "DefaultRowHeight", 0 },
					{ "CodeName", 1 },
					{ "Selected", 2 },
					{ "Panes", 3 },
					{ "ProtectContents", 4 },
					{ "ProtectObjects", 5 },
					{ "ProtectScenarios", 6 }
				};
			}
			if (Class1742.dictionary_26.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 3:
				{
					XmlNodeList childNodes = xmlElement.ChildNodes;
					method_26(childNodes, worksheet_0);
					break;
				}
				}
			}
		}
	}

	private void method_26(XmlNodeList xmlNodeList_0, Worksheet worksheet_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (!(obj is XmlText))
			{
				XmlElement xmlElement = (XmlElement)obj;
				string localName = xmlElement.LocalName;
				string text;
				if ((text = localName) != null && text == "Pane")
				{
					XmlNodeList childNodes = xmlElement.ChildNodes;
					method_27(childNodes, worksheet_0);
				}
			}
		}
	}

	private void method_27(XmlNodeList xmlNodeList_0, Worksheet worksheet_0)
	{
		string text = null;
		string text2 = null;
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (!(obj is XmlText))
			{
				XmlElement xmlElement = (XmlElement)obj;
				string innerText = xmlElement.InnerText;
				switch (xmlElement.LocalName)
				{
				case "ActiveCol":
					text2 = innerText;
					break;
				case "ActiveRow":
					text = innerText;
					break;
				}
			}
		}
		if (text != null && text != "" && text2 != null && text2 != "")
		{
			worksheet_0.ActiveCell = CellsHelper.CellIndexToName(int.Parse(text), int.Parse(text2));
		}
	}

	private void method_28(XmlNodeList xmlNodeList_0, Worksheet worksheet_0)
	{
		string string_ = null;
		OperatorType qualifier = OperatorType.None;
		string value = null;
		string value2 = null;
		string format = null;
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (!(obj is XmlText))
			{
				XmlElement xmlElement = (XmlElement)obj;
				string innerText = xmlElement.InnerText;
				switch (xmlElement.LocalName)
				{
				case "Condition":
				{
					XmlNodeList childNodes = xmlElement.ChildNodes;
					method_30(childNodes, out qualifier, out value, out value2, out format);
					break;
				}
				case "Range":
					string_ = innerText;
					break;
				}
			}
		}
		int index = worksheet_0.ConditionalFormattings.Add();
		FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[index];
		method_29(string_, formatConditionCollection);
		FormatCondition formatCondition = new FormatCondition(formatConditionCollection);
		formatCondition.Type = FormatConditionType.ColorScale;
		formatCondition.Operator = qualifier;
		formatConditionCollection.AddCondition(formatCondition);
	}

	private void method_29(string string_5, FormatConditionCollection formatConditionCollection_0)
	{
		string_5 = string_5.Replace("$", "");
		string[] array = string_5.Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(':');
			string startCellName = array2[0];
			string endCellName = array2[array2.Length - 1];
			CellArea cellArea = CellArea.CreateCellArea(startCellName, endCellName);
			formatConditionCollection_0.arrayList_1.Add(cellArea);
		}
	}

	private void method_30(XmlNodeList nls, out OperatorType qualifier, out string value1, out string value2, out string format)
	{
		qualifier = OperatorType.None;
		value1 = null;
		value2 = null;
		format = null;
		for (int i = 0; i < nls.Count; i++)
		{
			object obj = nls[i];
			if (!(obj is XmlText))
			{
				XmlElement xmlElement = (XmlElement)obj;
				string innerText = xmlElement.InnerText;
				switch (xmlElement.LocalName)
				{
				case "Format":
					format = xmlElement.GetAttribute("Style");
					break;
				case "Value2":
					value2 = innerText;
					break;
				case "Value1":
					value1 = innerText;
					break;
				case "Qualifier":
					qualifier = method_31(innerText);
					break;
				}
			}
		}
	}

	private OperatorType method_31(string string_5)
	{
		string key;
		if ((key = string_5) != null)
		{
			if (Class1742.dictionary_27 == null)
			{
				Class1742.dictionary_27 = new Dictionary<string, int>(9)
				{
					{ "Between", 0 },
					{ "Equal", 1 },
					{ "GreaterOrEqual", 2 },
					{ "GreaterThan", 3 },
					{ "LessOrEqual", 4 },
					{ "LessThan", 5 },
					{ "NotBetween", 6 },
					{ "NotEqual", 7 },
					{ "None", 8 }
				};
			}
			if (Class1742.dictionary_27.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return OperatorType.Between;
				case 1:
					return OperatorType.Equal;
				case 2:
					return OperatorType.GreaterOrEqual;
				case 3:
					return OperatorType.GreaterThan;
				case 4:
					return OperatorType.LessOrEqual;
				case 5:
					return OperatorType.LessThan;
				case 6:
					return OperatorType.NotBetween;
				case 7:
					return OperatorType.NotEqual;
				}
			}
		}
		return OperatorType.None;
	}

	public void method_32()
	{
		class734_0.method_68();
	}

	[SpecialName]
	public Hashtable method_33()
	{
		return hashtable_0;
	}

	[SpecialName]
	public Class734 method_34()
	{
		return class734_0;
	}

	[SpecialName]
	public void method_35(string string_5)
	{
		string_3 = string_5;
	}

	public void method_36()
	{
		hashtable_1.Clear();
	}

	[SpecialName]
	public ArrayList method_37()
	{
		return arrayList_0;
	}
}
