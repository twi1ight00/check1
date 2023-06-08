using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Properties;
using ns1;
using ns22;

namespace ns8;

internal class Class733
{
	public static void smethod_0(XmlNodeList xmlNodeList_0, BuiltInDocumentPropertyCollection builtInDocumentPropertyCollection_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			XmlElement xmlElement = (XmlElement)xmlNodeList_0[i];
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
				string localName = xmlElement2.LocalName;
				string key;
				if ((key = localName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_15 == null)
				{
					Class1742.dictionary_15 = new Dictionary<string, int>(8)
					{
						{ "Subject", 0 },
						{ "LastAuthor", 1 },
						{ "Keywords", 2 },
						{ "Description", 3 },
						{ "Category", 4 },
						{ "Manager", 5 },
						{ "Company", 6 },
						{ "Version", 7 }
					};
				}
				if (Class1742.dictionary_15.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						builtInDocumentPropertyCollection_0.Subject = innerText;
						break;
					case 1:
						builtInDocumentPropertyCollection_0.Author = innerText;
						break;
					case 2:
						builtInDocumentPropertyCollection_0.Keywords = innerText;
						break;
					case 3:
						builtInDocumentPropertyCollection_0.Comments = innerText;
						break;
					case 4:
						builtInDocumentPropertyCollection_0.Category = innerText;
						break;
					case 5:
						builtInDocumentPropertyCollection_0.Manager = innerText;
						break;
					case 6:
						builtInDocumentPropertyCollection_0.Company = innerText;
						break;
					case 7:
						builtInDocumentPropertyCollection_0.Version = (int)(Convert.ToDouble(innerText) + 0.01);
						break;
					}
				}
			}
		}
	}

	public static void smethod_1(XmlNodeList xmlNodeList_0, Hashtable hashtable_0, string string_0, IStreamProvider istreamProvider_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			XmlElement xmlElement = (XmlElement)xmlNodeList_0[i];
			XmlNodeList childNodes = xmlElement.ChildNodes;
			for (int j = 0; j < childNodes.Count; j++)
			{
				object obj = childNodes[j];
				if (!(obj is XmlText))
				{
					XmlElement xmlElement2 = (XmlElement)obj;
					switch (xmlElement2.LocalName)
					{
					case "shape":
					{
						Class736 @class = new Class736();
						@class.method_1(xmlElement2.GetAttribute("id"));
						@class.method_7(string_0);
						smethod_2(xmlElement2.GetAttribute("style"), @class);
						smethod_3(xmlElement2.ChildNodes, @class, string_0, istreamProvider_0);
						hashtable_0.Add(@class.method_0(), @class);
						break;
					}
					}
				}
			}
		}
	}

	private static void smethod_2(string string_0, Class736 class736_0)
	{
		string[] array = string_0.Split(';');
		string[] array2 = array;
		foreach (string text in array2)
		{
			string[] array3 = text.Split(':');
			string text2 = smethod_9(array3[0]);
			string key;
			if ((key = text2) == null)
			{
				continue;
			}
			if (Class1742.dictionary_16 == null)
			{
				Class1742.dictionary_16 = new Dictionary<string, int>(7)
				{
					{ "position", 0 },
					{ "margin-left", 1 },
					{ "margin-top", 2 },
					{ "width", 3 },
					{ "height", 4 },
					{ "z-index", 5 },
					{ "visibility", 6 }
				};
			}
			if (Class1742.dictionary_16.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 1:
					class736_0.Left = smethod_5(array3[1]);
					break;
				case 2:
					class736_0.Top = smethod_5(array3[1]);
					break;
				case 3:
					class736_0.Width = smethod_5(array3[1]);
					break;
				case 4:
					class736_0.Height = smethod_5(array3[1]);
					break;
				}
			}
		}
	}

	private static void smethod_3(XmlNodeList xmlNodeList_0, Class736 class736_0, string string_0, IStreamProvider istreamProvider_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			object obj = xmlNodeList_0[i];
			if (obj is XmlText)
			{
				continue;
			}
			XmlElement xmlElement = (XmlElement)obj;
			switch (xmlElement.LocalName)
			{
			case "ClientData":
				smethod_4(xmlElement.ChildNodes, class736_0);
				break;
			case "imagedata":
			{
				string origPath = xmlElement.GetAttribute("src");
				class736_0.method_5(string_0 + origPath);
				if (!File.Exists(class736_0.method_4()))
				{
					Stream stream = istreamProvider_0.GetStream(ref origPath, class736_0.method_4());
					if (stream != null)
					{
						class736_0.method_3(stream);
					}
				}
				else
				{
					FileStream stream_ = File.OpenRead(class736_0.method_4());
					class736_0.method_3(stream_);
				}
				break;
			}
			}
		}
	}

	private static void smethod_4(XmlNodeList xmlNodeList_0, Class736 class736_0)
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
			if (Class1742.dictionary_17 == null)
			{
				Class1742.dictionary_17 = new Dictionary<string, int>(6)
				{
					{ "MoveWithCells", 0 },
					{ "SizeWithCells", 1 },
					{ "Locked", 2 },
					{ "PrintObject", 3 },
					{ "CF", 4 },
					{ "AutoPict", 5 }
				};
			}
			if (!Class1742.dictionary_17.TryGetValue(key, out var value))
			{
				continue;
			}
			switch (value)
			{
			case 0:
				class736_0.Placement = PlacementType.FreeFloating;
				break;
			case 1:
				if (class736_0.Placement != 0)
				{
					class736_0.Placement = PlacementType.Move;
				}
				break;
			case 2:
				class736_0.IsLocked = bool.Parse(xmlElement.InnerText);
				break;
			case 3:
				class736_0.IsPrintable = bool.Parse(xmlElement.InnerText);
				break;
			}
		}
	}

	public static int smethod_5(string string_0)
	{
		if (string_0.ToLower().IndexOf("pt") > -1)
		{
			return (int)(double.Parse(string_0.Substring(0, string_0.Length - 2)) * 96.0 / 72.0 + 0.005);
		}
		if (string_0.ToLower().IndexOf("in") > -1)
		{
			return (int)(double.Parse(string_0.Substring(0, string_0.Length - 2)) * 96.0);
		}
		if (string_0.ToLower().IndexOf("px") > -1)
		{
			return (int)double.Parse(string_0.Substring(0, string_0.Length - 2));
		}
		return (int)double.Parse(string_0);
	}

	public static double smethod_6(string string_0)
	{
		if (string_0.ToLower().IndexOf("pt") > -1)
		{
			return double.Parse(string_0.Substring(0, string_0.Length - 2));
		}
		return double.Parse(string_0);
	}

	public static int smethod_7(string string_0)
	{
		if (string_0.ToLower().IndexOf("pt") > -1)
		{
			return (int)double.Parse(string_0.Substring(0, string_0.Length - 2));
		}
		return (int)double.Parse(string_0);
	}

	public static void smethod_8(string string_0, Font font_0)
	{
		string_0 = string_0.Replace("\"", "").Replace("'", "");
		string[] array = string_0.Split(',');
		if (array.Length > 1)
		{
			font_0.Name = array[0];
		}
		else
		{
			font_0.Name = string_0;
		}
	}

	public static string smethod_9(string string_0)
	{
		return string_0.Replace("\t", "").Replace("\n", "").Replace("\r", "")
			.Replace(" ", "");
	}

	public static void smethod_10(XmlDocument xmlDocument_0, Workbook workbook_0)
	{
		XmlNodeList elementsByTagName = xmlDocument_0.GetElementsByTagName("x:HideWorkbookTabs");
		workbook_0.Settings.ShowTabs = elementsByTagName.Count <= 0;
		XmlNodeList elementsByTagName2 = xmlDocument_0.GetElementsByTagName("x:HideHorizontalScrollBar");
		workbook_0.Settings.IsHScrollBarVisible = elementsByTagName2.Count <= 0;
		XmlNodeList elementsByTagName3 = xmlDocument_0.GetElementsByTagName("x:HideVerticalScrollBar");
		workbook_0.Settings.IsVScrollBarVisible = elementsByTagName3.Count <= 0;
	}

	public static void smethod_11(XmlDocument xmlDocument_0, Class734 class734_0)
	{
		XmlNodeList elementsByTagName = xmlDocument_0.GetElementsByTagName("x:WorksheetOptions");
		if (elementsByTagName.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < elementsByTagName.Count; i++)
		{
			XmlElement xmlElement = (XmlElement)elementsByTagName[i];
			XmlNodeList elementsByTagName2 = xmlElement.GetElementsByTagName("x:DoNotDisplayGridlines");
			if (elementsByTagName2.Count > 0)
			{
				class734_0.method_70().IsGridlinesVisible = false;
			}
			else
			{
				class734_0.method_70().IsGridlinesVisible = true;
			}
			XmlNodeList elementsByTagName3 = xmlElement.GetElementsByTagName("x:TopRowVisible");
			if (elementsByTagName3.Count > 0)
			{
				class734_0.method_70().FirstVisibleRow = Convert.ToInt32(Class1188.smethod_13(elementsByTagName3[0]));
			}
			XmlNodeList elementsByTagName4 = xmlElement.GetElementsByTagName("x:LeftColumnVisible");
			if (elementsByTagName4.Count > 0)
			{
				class734_0.method_70().FirstVisibleColumn = Convert.ToInt32(Class1188.smethod_13(elementsByTagName4[0]));
			}
			XmlNodeList elementsByTagName5 = xmlElement.GetElementsByTagName("x:FreezePanes");
			if (elementsByTagName5.Count > 0)
			{
				smethod_12(xmlElement, class734_0.method_70());
			}
			XmlNodeList elementsByTagName6 = xmlElement.GetElementsByTagName("x:DefaultRowHeight");
			if (elementsByTagName6.Count > 0)
			{
				double num = Convert.ToDouble(Class1188.smethod_13(elementsByTagName6[0])) / 15.0;
				class734_0.method_70().Cells.StandardHeight = num * (double)Class732.int_2 / (double)Class732.int_3;
			}
			XmlNodeList elementsByTagName7 = xmlElement.GetElementsByTagName("x:StandardWidth");
			_ = elementsByTagName7.Count;
			XmlNodeList elementsByTagName8 = xmlElement.GetElementsByTagName("x:Zoom");
			if (elementsByTagName8.Count > 0)
			{
				class734_0.method_70().Zoom = Convert.ToInt16(elementsByTagName8[0].InnerText);
			}
			XmlNodeList elementsByTagName9 = xmlElement.GetElementsByTagName("x:TabColorIndex");
			if (elementsByTagName9.Count > 0)
			{
				int int_ = Convert.ToInt32(Class1188.smethod_13(elementsByTagName9[0]));
				class734_0.method_70().method_40(int_);
			}
			XmlNodeList elementsByTagName10 = xmlElement.GetElementsByTagName("x:DoNotDisplayHeadings");
			if (elementsByTagName10.Count > 0)
			{
				class734_0.method_70().IsRowColumnHeadersVisible = false;
			}
			XmlNodeList elementsByTagName11 = xmlElement.GetElementsByTagName("x:Visible");
			if (elementsByTagName11.Count > 0)
			{
				string text = Class1188.smethod_13(elementsByTagName11[0]);
				if (!text.Equals("SheetHidden") && !text.Equals("SheetVeryHidden"))
				{
					class734_0.method_70().IsVisible = true;
				}
				else
				{
					class734_0.method_70().IsVisible = false;
				}
			}
			XmlNodeList elementsByTagName12 = xmlElement.GetElementsByTagName("x:ShowPageBreakZoom");
			if (elementsByTagName12.Count > 0)
			{
				class734_0.method_70().IsPageBreakPreview = true;
				XmlNodeList elementsByTagName13 = xmlElement.GetElementsByTagName("x:PageBreakZoom");
				if (elementsByTagName13.Count > 0)
				{
					class734_0.method_70().Zoom = Convert.ToInt32(Class1188.smethod_13(elementsByTagName13[0]));
				}
			}
		}
	}

	private static void smethod_12(XmlElement xmlElement_0, Worksheet worksheet_0)
	{
		int row = 0;
		int column = 0;
		int freezedRows = 0;
		int freezedColumns = 0;
		XmlNodeList elementsByTagName = xmlElement_0.GetElementsByTagName("x:SplitHorizontal");
		if (elementsByTagName.Count > 0)
		{
			freezedRows = Convert.ToInt32(Class1188.smethod_13(elementsByTagName[0]));
		}
		XmlNodeList elementsByTagName2 = xmlElement_0.GetElementsByTagName("x:TopRowBottomPane");
		if (elementsByTagName2.Count > 0)
		{
			row = Convert.ToInt32(Class1188.smethod_13(elementsByTagName2[0]));
		}
		XmlNodeList elementsByTagName3 = xmlElement_0.GetElementsByTagName("x:SplitVertical");
		if (elementsByTagName3.Count > 0)
		{
			freezedColumns = Convert.ToInt32(Class1188.smethod_13(elementsByTagName3[0]));
		}
		XmlNodeList elementsByTagName4 = xmlElement_0.GetElementsByTagName("x:LeftColumnRightPane");
		if (elementsByTagName4.Count > 0)
		{
			column = Convert.ToInt32(Class1188.smethod_13(elementsByTagName4[0]));
		}
		worksheet_0.FreezePanes(row, column, freezedRows, freezedColumns);
	}

	[Attribute0(true)]
	public static void smethod_13(XmlNodeList xmlNodeList_0, CustomDocumentPropertyCollection customDocumentPropertyCollection_0)
	{
		for (int i = 0; i < xmlNodeList_0.Count; i++)
		{
			XmlElement xmlElement = (XmlElement)xmlNodeList_0[i];
			XmlNodeList childNodes = xmlElement.ChildNodes;
			for (int j = 0; j < childNodes.Count; j++)
			{
				object obj = childNodes[j];
				if (!(obj is XmlText))
				{
					XmlElement xmlElement2 = (XmlElement)obj;
					string attribute = xmlElement2.GetAttribute("dt:dt");
					smethod_14(xmlElement2.LocalName, xmlElement2.InnerText, attribute, customDocumentPropertyCollection_0);
				}
			}
		}
	}

	[Attribute0(true)]
	private static void smethod_14(string string_0, string string_1, string string_2, CustomDocumentPropertyCollection customDocumentPropertyCollection_0)
	{
		string_0 = smethod_15(string_0);
		switch (string_2)
		{
		case "string":
			customDocumentPropertyCollection_0.Add(string_0, string_1);
			break;
		case "float":
		{
			double value2 = Convert.ToDouble(string_1);
			customDocumentPropertyCollection_0.Add(string_0, value2);
			break;
		}
		case "boolean":
			customDocumentPropertyCollection_0.Add(string_0, string_1.Equals("1"));
			break;
		case "dateTime.tz":
		{
			string s = Class732.smethod_1(string_1);
			DateTime value = DateTime.Parse(s);
			customDocumentPropertyCollection_0.Add(string_0, value);
			break;
		}
		}
	}

	private static string smethod_15(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (string_0.StartsWith("o:"))
		{
			string_0 = string_0.Substring(2);
		}
		int length = string_0.Length;
		for (int i = 0; i < length; i++)
		{
			char c = string_0[i];
			if (c == '_' && i + 6 < length && string_0[i + 1] == 'x' && string_0[i + 6] == '_')
			{
				bool flag = true;
				StringBuilder stringBuilder2 = new StringBuilder();
				for (int j = i + 2; j < i + 6; j++)
				{
					char char_ = string_0[j];
					if (smethod_16(char_))
					{
						stringBuilder2.Append(string_0[j]);
						continue;
					}
					flag = false;
					break;
				}
				if (flag)
				{
					int num = Convert.ToInt32(stringBuilder2.ToString(), 16);
					char value = (char)num;
					stringBuilder.Append(value);
					i += 6;
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_16(char char_0)
	{
		if ((char_0 >= '0' && char_0 <= '9') || (char_0 >= 'a' && char_0 <= 'f') || (char_0 >= 'A' && char_0 <= 'F'))
		{
			return true;
		}
		return false;
	}
}
