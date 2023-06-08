using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Properties;
using ns1;
using ns16;
using ns2;
using ns22;
using ns25;
using ns29;

namespace ns50;

internal class Class1105
{
	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private Workbook workbook_0;

	private int int_0 = 55;

	private Hashtable hashtable_0 = new Hashtable();

	public void method_0(Stream stream_0, Workbook workbook_1)
	{
		XmlTextReader xmlTextReader = null;
		try
		{
			hashtable_0 = new Hashtable();
			long position = stream_0.Position;
			xmlTextReader = Class1029.smethod_1(stream_0);
			if (method_1(workbook_1, xmlTextReader))
			{
				method_2(xmlTextReader, workbook_1);
				stream_0.Position = position;
				xmlTextReader = Class1029.smethod_1(stream_0);
				method_1(workbook_1, xmlTextReader);
				method_3(xmlTextReader);
			}
		}
		finally
		{
			xmlTextReader?.Close();
		}
	}

	private bool method_1(Workbook workbook_1, XmlTextReader xmlTextReader_0)
	{
		workbook_0 = workbook_1;
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		string_0 = nameTable.Add("urn:schemas-microsoft-com:office:office");
		string_1 = nameTable.Add("urn:schemas-microsoft-com:office:excel");
		string_2 = nameTable.Add("urn:schemas-microsoft-com:office:spreadsheet");
		string_3 = nameTable.Add("urn:schemas-microsoft-com:office:excel2");
		string_4 = nameTable.Add("http://www.w3.org/TR/REC-html40");
		string_5 = nameTable.Add("uuid:C2F41010-65B3-11d1-A29F-00AA00C14882");
		try
		{
			xmlTextReader_0.MoveToContent();
		}
		catch
		{
			return false;
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || !(xmlTextReader_0.LocalName == "Workbook"))
		{
			method_35(null, xmlTextReader_0.LineNumber);
		}
		return true;
	}

	[Attribute0(true)]
	private void method_2(XmlTextReader xmlTextReader_0, Workbook workbook_1)
	{
		workbook_1.Worksheets.Clear();
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Worksheet")
			{
				string text = null;
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						if (xmlTextReader_0.LocalName == "Name")
						{
							text = xmlTextReader_0.Value;
						}
					}
				}
				if (text == null)
				{
					method_35("A worksheet must have a name.", xmlTextReader_0.LineNumber);
				}
				if (xmlTextReader_0.IsEmptyElement)
				{
					break;
				}
				xmlTextReader_0.Skip();
				Worksheet worksheet = workbook_1.Worksheets[workbook_1.Worksheets.Add()];
				worksheet.method_7(text);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	private void method_3(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		Class1129.smethod_1();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "DocumentProperties")
			{
				method_8(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "CustomDocumentProperties")
			{
				method_9(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "ExcelWorkbook")
			{
				method_10(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "Styles")
			{
				method_11(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "Names")
			{
				method_7(xmlTextReader_0, workbook_0);
			}
			else if (xmlTextReader_0.LocalName == "Worksheet")
			{
				method_18(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "OfficeDocumentSettings")
			{
				method_4(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_4(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "Colors")
			{
				method_5(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_5(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "Color")
			{
				method_6(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_6(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		string text = null;
		string text2 = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Index")
			{
				text = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "RGB")
			{
				text2 = xmlTextReader_0.ReadElementString();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (text == null || text2 == null)
		{
			return;
		}
		try
		{
			if (text2[0] == '#')
			{
				text2 = text2.Substring(1);
			}
			Color color = Class1618.smethod_63(text2);
			int index = int.Parse(text);
			workbook_0.ChangePalette(color, index);
		}
		catch
		{
		}
	}

	private void method_7(XmlTextReader xmlTextReader_0, Workbook workbook_1)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else
			{
				if (!(xmlTextReader_0.LocalName == "NamedRange") || !xmlTextReader_0.HasAttributes)
				{
					continue;
				}
				string text = null;
				string text2 = null;
				while (xmlTextReader_0.MoveToNextAttribute())
				{
					if (xmlTextReader_0.LocalName == "Name")
					{
						text = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "RefersTo")
					{
						text2 = Class1619.smethod_10(xmlTextReader_0.Value, -1, -1);
					}
				}
				if (text != null && text2 != null)
				{
					int index = workbook_1.Worksheets.Names.method_0(-1, text);
					Name name = workbook_1.Worksheets.Names[index];
					name.RefersTo = text2;
				}
				xmlTextReader_0.MoveToElement();
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_8(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
				continue;
			}
			for (int i = 0; i < Class1631.string_0.Length; i++)
			{
				if (xmlTextReader_0.LocalName != Class1631.string_0[i])
				{
					if (i == Class1631.string_0.Length - 1)
					{
						method_36(xmlTextReader_0.LineNumber, xmlTextReader_0.LocalName);
					}
					continue;
				}
				string text = xmlTextReader_0.ReadElementString();
				BuiltInDocumentPropertyCollection builtInDocumentProperties = workbook_0.Worksheets.BuiltInDocumentProperties;
				try
				{
					switch (i)
					{
					case 0:
						builtInDocumentProperties.Title = text;
						break;
					case 1:
						builtInDocumentProperties.Subject = text;
						break;
					case 2:
						builtInDocumentProperties.Author = text;
						break;
					case 3:
						builtInDocumentProperties.Keywords = text;
						break;
					case 4:
						builtInDocumentProperties.Comments = text;
						break;
					case 5:
						builtInDocumentProperties.LastSavedBy = text;
						break;
					case 6:
						builtInDocumentProperties.RevisionNumber = int.Parse(text);
						break;
					case 7:
						builtInDocumentProperties.NameOfApplication = text;
						break;
					case 8:
						builtInDocumentProperties.TotalEditingTime = int.Parse(text);
						break;
					case 9:
						builtInDocumentProperties.LastPrinted = DateTime.Parse(text);
						break;
					case 10:
						builtInDocumentProperties.CreatedTime = DateTime.Parse(text);
						break;
					case 11:
						builtInDocumentProperties.LastSavedTime = DateTime.Parse(text);
						break;
					case 12:
						builtInDocumentProperties.Pages = int.Parse(text);
						break;
					case 13:
						builtInDocumentProperties.Words = int.Parse(text);
						break;
					case 14:
						builtInDocumentProperties.Characters = int.Parse(text);
						break;
					case 15:
						builtInDocumentProperties.Category = text;
						break;
					case 17:
						builtInDocumentProperties.Manager = text;
						break;
					case 18:
						builtInDocumentProperties.Company = text;
						break;
					case 20:
						builtInDocumentProperties.HyperlinkBase = text;
						break;
					case 21:
						builtInDocumentProperties.Bytes = int.Parse(text);
						break;
					case 22:
						builtInDocumentProperties.Lines = int.Parse(text);
						break;
					case 23:
						builtInDocumentProperties.Paragraphs = int.Parse(text);
						break;
					case 16:
					case 19:
						break;
					}
				}
				catch (FormatException)
				{
				}
				break;
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_9(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
				continue;
			}
			CustomDocumentPropertyCollection customDocumentProperties = workbook_0.Worksheets.CustomDocumentProperties;
			string text = null;
			string text2 = null;
			if (xmlTextReader_0.HasAttributes)
			{
				text2 = xmlTextReader_0.GetAttribute("link");
				text = xmlTextReader_0.GetAttribute("dt", string_5);
			}
			if (text == "string")
			{
				text = null;
			}
			int lineNumber = xmlTextReader_0.LineNumber;
			string localName = xmlTextReader_0.LocalName;
			string text3 = xmlTextReader_0.ReadElementString();
			DocumentProperty documentProperty = null;
			if (text2 != null)
			{
				documentProperty = customDocumentProperties.AddLinkToContent(localName, text2);
			}
			try
			{
				switch (text)
				{
				default:
					method_35("Invalid dt value \"" + text + "\"", xmlTextReader_0.LineNumber);
					break;
				case "boolean":
					if (documentProperty == null)
					{
						customDocumentProperties.Add(localName, (!(text3 == "0")) ? true : false);
					}
					else
					{
						documentProperty.Value = ((!(text3 == "0")) ? true : false);
					}
					break;
				case "float":
					if (documentProperty == null)
					{
						customDocumentProperties.Add(localName, Class1618.smethod_85(text3));
					}
					else
					{
						documentProperty.Value = Class1618.smethod_85(text3);
					}
					break;
				case "dateTime.tz":
					if (documentProperty == null)
					{
						customDocumentProperties.Add(localName, DateTime.Parse(text3));
					}
					else
					{
						documentProperty.Value = DateTime.Parse(text3);
					}
					break;
				case null:
					if (documentProperty == null)
					{
						customDocumentProperties.Add(localName, text3);
					}
					else
					{
						documentProperty.Value = text3;
					}
					break;
				}
			}
			catch (FormatException)
			{
				method_35("\"" + text3 + "\" is not a valid " + text, lineNumber);
				break;
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_10(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
				continue;
			}
			string text = null;
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null)
			{
				if (Class1742.dictionary_37 == null)
				{
					Class1742.dictionary_37 = new Dictionary<string, int>(6)
					{
						{ "HideHorizontalScrollBar", 0 },
						{ "HideVerticalScrollBar", 1 },
						{ "HideWorkbookTabs", 2 },
						{ "ActiveSheet", 3 },
						{ "Calculation", 4 },
						{ "DoNotCalculateBeforeSave", 5 }
					};
				}
				if (Class1742.dictionary_37.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
						workbook_0.Settings.IsHScrollBarVisible = false;
						xmlTextReader_0.Skip();
						continue;
					case 1:
						workbook_0.Settings.IsVScrollBarVisible = false;
						xmlTextReader_0.Skip();
						continue;
					case 2:
						workbook_0.Settings.ShowTabs = false;
						xmlTextReader_0.Skip();
						continue;
					case 3:
						text = xmlTextReader_0.ReadElementString();
						workbook_0.Worksheets.ActiveSheetIndex = int.Parse(text);
						continue;
					case 4:
						switch (xmlTextReader_0.ReadElementString())
						{
						case "ManualCalculation":
							workbook_0.Settings.CalcMode = CalcModeType.Manual;
							break;
						case "SemiAutomaticCalculation":
							workbook_0.Settings.CalcMode = CalcModeType.AutomaticExceptTable;
							break;
						}
						continue;
					case 5:
						xmlTextReader_0.Skip();
						continue;
					}
				}
			}
			xmlTextReader_0.Skip();
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_11(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Style")
			{
				method_12(xmlTextReader_0);
			}
			else
			{
				method_36(xmlTextReader_0.LineNumber, xmlTextReader_0.LocalName);
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_12(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("ID", string_2);
		if (attribute == null)
		{
			method_35("ID is required for \"Style\" element.", xmlTextReader_0.LineNumber);
		}
		if (hashtable_0.Contains(attribute))
		{
			method_35("Duplicate Style ID \"" + attribute + "\"", xmlTextReader_0.LineNumber);
		}
		string text = attribute;
		Style style = new Style(workbook_0.Worksheets);
		string attribute2 = xmlTextReader_0.GetAttribute("Parent", string_2);
		int int_ = 0;
		if (attribute2 != null)
		{
			int_ = (int)hashtable_0[attribute2];
			Style style2 = workbook_0.Worksheets.method_45(int_);
			if (style2 == null)
			{
				method_35("Can not find the specified Parent \"" + attribute2 + "\"", xmlTextReader_0.LineNumber);
			}
			style.Copy(style2);
		}
		string attribute3 = xmlTextReader_0.GetAttribute("Name", string_2);
		style.method_3(attribute3);
		style.method_13(int_);
		if (xmlTextReader_0.IsEmptyElement)
		{
			int num = workbook_0.Worksheets.method_59(style);
			hashtable_0.Add(text, num);
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
				continue;
			}
			for (int i = 0; i < Class1631.string_2.Length; i++)
			{
				if (xmlTextReader_0.LocalName != Class1631.string_2[i])
				{
					if (i == Class1631.string_2.Length - 1)
					{
						method_36(xmlTextReader_0.LineNumber, xmlTextReader_0.LocalName);
					}
					continue;
				}
				switch (i)
				{
				case 0:
					method_13(xmlTextReader_0, style);
					break;
				case 1:
					method_14(xmlTextReader_0, style);
					break;
				case 2:
					method_15(xmlTextReader_0, style);
					break;
				case 3:
					method_16(xmlTextReader_0, style);
					break;
				case 4:
					method_17(xmlTextReader_0, style);
					break;
				case 5:
					attribute = xmlTextReader_0.GetAttribute("Protected", string_2);
					style.IsLocked = ((!(attribute == "0") && !(attribute == "")) ? true : false);
					attribute = xmlTextReader_0.GetAttribute("HideFormula", string_1);
					if (attribute != null)
					{
						style.IsFormulaHidden = ((!(attribute == "0") && !(attribute == "")) ? true : false);
					}
					xmlTextReader_0.Skip();
					break;
				}
				break;
			}
		}
		if (style.Name != null && style.Name == "Normal")
		{
			workbook_0.Worksheets.method_58()[0] = style;
			style.method_11(bool_0: false);
			Style style3 = new Style(workbook_0.Worksheets);
			style3.Copy(style);
			style3.method_11(bool_0: true);
			workbook_0.Worksheets.DefaultStyle = style3;
			hashtable_0.Add(text, 15);
		}
		else if (text == "Default")
		{
			workbook_0.Worksheets.method_58()[15] = style;
			hashtable_0.Add(text, 15);
		}
		else
		{
			int num2 = workbook_0.Worksheets.method_59(style);
			hashtable_0.Add(text, num2);
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_13(XmlTextReader xmlTextReader_0, Style style_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			string text = null;
			try
			{
				text = xmlTextReader_0.GetAttribute("Horizontal", string_2);
				if (text != null)
				{
					string key;
					if ((key = text) != null)
					{
						if (Class1742.dictionary_38 == null)
						{
							Class1742.dictionary_38 = new Dictionary<string, int>(9)
							{
								{ "CenterAcrossSelection", 0 },
								{ "Fill", 1 },
								{ "Left", 2 },
								{ "Right", 3 },
								{ "Justify", 4 },
								{ "JustifyDistributed", 5 },
								{ "Distributed", 6 },
								{ "Center", 7 },
								{ "Automatic", 8 }
							};
						}
						if (Class1742.dictionary_38.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								style_0.HorizontalAlignment = TextAlignmentType.CenterAcross;
								goto IL_0149;
							case 1:
								style_0.HorizontalAlignment = TextAlignmentType.Fill;
								goto IL_0149;
							case 2:
								style_0.HorizontalAlignment = TextAlignmentType.Left;
								goto IL_0149;
							case 3:
								style_0.HorizontalAlignment = TextAlignmentType.Right;
								goto IL_0149;
							case 4:
							case 5:
								style_0.HorizontalAlignment = TextAlignmentType.Justify;
								goto IL_0149;
							case 6:
								style_0.HorizontalAlignment = TextAlignmentType.Distributed;
								goto IL_0149;
							case 7:
								style_0.HorizontalAlignment = TextAlignmentType.Center;
								goto IL_0149;
							case 8:
								goto IL_0149;
							}
						}
					}
					method_35("Invalid attribute value \"" + text + "\"", xmlTextReader_0.LineNumber);
				}
				goto IL_0149;
				IL_0149:
				text = xmlTextReader_0.GetAttribute("Vertical", string_2);
				string key2;
				if (text != null && (key2 = text) != null)
				{
					if (Class1742.dictionary_39 == null)
					{
						Class1742.dictionary_39 = new Dictionary<string, int>(7)
						{
							{ "Automatic", 0 },
							{ "Top", 1 },
							{ "Bottom", 2 },
							{ "Center", 3 },
							{ "Justify", 4 },
							{ "JustifyDistributed", 5 },
							{ "Distributed", 6 }
						};
					}
					if (Class1742.dictionary_39.TryGetValue(key2, out var value2))
					{
						switch (value2)
						{
						case 1:
							style_0.VerticalAlignment = TextAlignmentType.Top;
							break;
						case 2:
							style_0.VerticalAlignment = TextAlignmentType.Bottom;
							break;
						case 3:
							style_0.VerticalAlignment = TextAlignmentType.Center;
							break;
						case 4:
						case 5:
							style_0.VerticalAlignment = TextAlignmentType.Justify;
							break;
						case 6:
							style_0.VerticalAlignment = TextAlignmentType.Distributed;
							break;
						}
					}
				}
				text = xmlTextReader_0.GetAttribute("Rotate", string_2);
				if (text != null)
				{
					style_0.RotationAngle = (int)Class1618.smethod_85(text);
				}
				text = xmlTextReader_0.GetAttribute("ReadingOrder", string_2);
				if (text != null)
				{
					switch (text)
					{
					case "RightToLeft":
						style_0.TextDirection = TextDirectionType.RightToLeft;
						break;
					case "LeftToRight":
						style_0.TextDirection = TextDirectionType.LeftToRight;
						break;
					}
				}
				text = xmlTextReader_0.GetAttribute("VerticalText", string_2);
				if (text != null)
				{
					style_0.RotationAngle = 255;
				}
				text = xmlTextReader_0.GetAttribute("ShrinkToFit", string_2);
				if (text != null)
				{
					style_0.ShrinkToFit = ((!(text == "0") && !(text == "")) ? true : false);
				}
				text = xmlTextReader_0.GetAttribute("WrapText", string_2);
				if (text != null)
				{
					style_0.IsTextWrapped = ((!(text == "0") && !(text == "")) ? true : false);
				}
				text = xmlTextReader_0.GetAttribute("Indent", string_2);
				if (text != null)
				{
					style_0.IndentLevel = int.Parse(text);
				}
			}
			catch (FormatException)
			{
				method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
			}
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_14(XmlTextReader xmlTextReader_0, Style style_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			if (style_0.method_12() > 0 && style_0.IsModified(StyleModifyFlag.Borders))
			{
				style_0.Borders.SetStyle(CellBorderType.None);
			}
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		string text = null;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
				continue;
			}
			try
			{
				BorderType borderType;
				if (xmlTextReader_0.LocalName == "Border")
				{
					borderType = BorderType.LeftBorder;
					text = xmlTextReader_0.GetAttribute("Position", string_2);
					string key;
					if ((key = text) != null)
					{
						if (Class1742.dictionary_40 == null)
						{
							Class1742.dictionary_40 = new Dictionary<string, int>(6)
							{
								{ "Left", 0 },
								{ "Top", 1 },
								{ "Right", 2 },
								{ "Bottom", 3 },
								{ "DiagonalLeft", 4 },
								{ "DiagonalRight", 5 }
							};
						}
						if (Class1742.dictionary_40.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
								break;
							case 1:
								goto IL_011d;
							case 2:
								goto IL_0121;
							case 3:
								goto IL_0125;
							case 4:
								goto IL_0129;
							case 5:
								goto IL_012e;
							default:
								goto IL_0133;
							}
							borderType = BorderType.LeftBorder;
							goto IL_0150;
						}
					}
					goto IL_0133;
				}
				method_36(xmlTextReader_0.LineNumber, xmlTextReader_0.LocalName);
				goto end_IL_0056;
				IL_02bf:
				double num;
				CellBorderType lineStyle = ((!(num <= 1.0)) ? CellBorderType.MediumDashed : CellBorderType.Dashed);
				goto IL_0343;
				IL_0326:
				method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
				goto IL_0343;
				IL_02d5:
				lineStyle = ((!(num <= 0.8)) ? CellBorderType.Dotted : CellBorderType.Hair);
				goto IL_0343;
				IL_0303:
				lineStyle = ((!(num <= 1.0)) ? CellBorderType.MediumDashDotDot : CellBorderType.DashDotDot);
				goto IL_0343;
				IL_0343:
				style_0.Borders[borderType].LineStyle = lineStyle;
				text = xmlTextReader_0.GetAttribute("Color", string_2);
				if (text != null)
				{
					style_0.Borders[borderType].Color = method_30(ColorTranslator.FromHtml(text));
				}
				xmlTextReader_0.Skip();
				goto end_IL_0056;
				IL_012e:
				borderType = BorderType.DiagonalUp;
				goto IL_0150;
				IL_0129:
				borderType = BorderType.DiagonalDown;
				goto IL_0150;
				IL_0125:
				borderType = BorderType.BottomBorder;
				goto IL_0150;
				IL_0121:
				borderType = BorderType.RightBorder;
				goto IL_0150;
				IL_011d:
				borderType = BorderType.TopBorder;
				goto IL_0150;
				IL_02eb:
				lineStyle = ((!(num <= 1.0)) ? CellBorderType.MediumDashDot : CellBorderType.DashDot);
				goto IL_0343;
				IL_0133:
				method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
				goto IL_0150;
				IL_0150:
				string text2 = "None";
				num = 1.0;
				text = xmlTextReader_0.GetAttribute("LineStyle", string_2);
				if (text != null)
				{
					text2 = text;
				}
				text = xmlTextReader_0.GetAttribute("Weight", string_2);
				num = ((text == null) ? 0.0 : Class1618.smethod_85(text));
				lineStyle = CellBorderType.None;
				string key2;
				if ((key2 = text2) != null)
				{
					if (Class1742.dictionary_41 == null)
					{
						Class1742.dictionary_41 = new Dictionary<string, int>(9)
						{
							{ "None", 0 },
							{ "", 1 },
							{ "Continuous", 2 },
							{ "Dash", 3 },
							{ "Dot", 4 },
							{ "DashDot", 5 },
							{ "DashDotDot", 6 },
							{ "SlantDashDot", 7 },
							{ "Double", 8 }
						};
					}
					if (Class1742.dictionary_41.TryGetValue(key2, out var value2))
					{
						switch (value2)
						{
						case 0:
							lineStyle = CellBorderType.None;
							goto IL_0343;
						case 2:
							break;
						case 3:
							goto IL_02bf;
						case 4:
							goto IL_02d5;
						case 5:
							goto IL_02eb;
						case 6:
							goto IL_0303;
						case 7:
							lineStyle = CellBorderType.SlantedDashDot;
							goto IL_0343;
						case 8:
							lineStyle = CellBorderType.Double;
							goto IL_0343;
						default:
							goto IL_0326;
						case 1:
							goto IL_0343;
						}
						lineStyle = ((num <= 0.5) ? CellBorderType.Hair : ((num <= 1.0) ? CellBorderType.Thin : ((!(num <= 2.0)) ? CellBorderType.Thick : CellBorderType.Medium)));
						goto IL_0343;
					}
				}
				goto IL_0326;
				end_IL_0056:;
			}
			catch (FormatException)
			{
				method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_15(XmlTextReader xmlTextReader_0, Style style_0)
	{
		Aspose.Cells.Font font = style_0.Font;
		string text = null;
		try
		{
			text = xmlTextReader_0.GetAttribute("Bold", string_2);
			int isBold;
			switch (text)
			{
			default:
				isBold = 1;
				break;
			case null:
			case "0":
			case "":
				isBold = 0;
				break;
			}
			font.IsBold = (byte)isBold != 0;
			text = xmlTextReader_0.GetAttribute("Color", string_2);
			if (text != null && text != "" && text.ToUpper() != "AUTOMATIC")
			{
				font.Color = method_30(ColorTranslator.FromHtml(text));
			}
			text = xmlTextReader_0.GetAttribute("FontName", string_2);
			if (text != null)
			{
				font.method_13(text);
			}
			text = xmlTextReader_0.GetAttribute("Italic", string_2);
			int isItalic;
			switch (text)
			{
			default:
				isItalic = 1;
				break;
			case null:
			case "0":
			case "":
				isItalic = 0;
				break;
			}
			font.IsItalic = (byte)isItalic != 0;
			text = xmlTextReader_0.GetAttribute("Size", string_2);
			if (text != null)
			{
				font.DoubleSize = Class1618.smethod_85(text);
			}
			text = xmlTextReader_0.GetAttribute("StrikeThrough", string_2);
			int isStrikeout;
			switch (text)
			{
			default:
				isStrikeout = 1;
				break;
			case null:
			case "0":
			case "":
				isStrikeout = 0;
				break;
			}
			font.IsStrikeout = (byte)isStrikeout != 0;
			text = xmlTextReader_0.GetAttribute("Underline", string_2);
			if (text != null)
			{
				FontUnderlineType underline = FontUnderlineType.None;
				switch (text)
				{
				case "DoubleAccounting":
					underline = FontUnderlineType.DoubleAccounting;
					break;
				case "SingleAccounting":
					underline = FontUnderlineType.Accounting;
					break;
				case "Double":
					underline = FontUnderlineType.Double;
					break;
				case "Single":
					underline = FontUnderlineType.Single;
					break;
				case "None":
					underline = FontUnderlineType.None;
					break;
				default:
					method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
					break;
				}
				font.Underline = underline;
			}
			text = xmlTextReader_0.GetAttribute("VerticalAlign", string_2);
			switch (text)
			{
			default:
				method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
				break;
			case "Superscript":
				font.IsSuperscript = true;
				break;
			case "Subscript":
				font.IsSubscript = true;
				break;
			case "None":
				font.IsSubscript = false;
				font.IsSuperscript = false;
				break;
			}
		}
		catch (FormatException)
		{
			method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_16(XmlTextReader xmlTextReader_0, Style style_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("Pattern", string_2);
		string key;
		if ((key = attribute) == null)
		{
			goto IL_0271;
		}
		if (Class1742.dictionary_42 == null)
		{
			Class1742.dictionary_42 = new Dictionary<string, int>(20)
			{
				{ "None", 0 },
				{ "Solid", 1 },
				{ "Gray75", 2 },
				{ "Gray50", 3 },
				{ "Gray25", 4 },
				{ "Gray125", 5 },
				{ "Gray0625", 6 },
				{ "HorzStripe", 7 },
				{ "VertStripe", 8 },
				{ "ReverseDiagStripe", 9 },
				{ "DiagStripe", 10 },
				{ "DiagCross", 11 },
				{ "ThickDiagCross", 12 },
				{ "ThinHorzStripe", 13 },
				{ "ThinVertStripe", 14 },
				{ "ThinReverseDiagStripe", 15 },
				{ "ThinDiagStripe", 16 },
				{ "ThinHorzCross", 17 },
				{ "ThinDiagCross", 18 }
			};
		}
		if (!Class1742.dictionary_42.TryGetValue(key, out var value))
		{
			goto IL_0252;
		}
		switch (value)
		{
		case 1:
			break;
		case 2:
			goto IL_019a;
		case 3:
			goto IL_01a6;
		case 4:
			goto IL_01b2;
		case 5:
			goto IL_01be;
		case 6:
			goto IL_01cb;
		case 7:
			goto IL_01d8;
		case 8:
			goto IL_01e4;
		case 9:
			goto IL_01f0;
		case 10:
			goto IL_01f9;
		case 11:
			goto IL_0202;
		case 12:
			goto IL_020c;
		case 13:
			goto IL_0216;
		case 14:
			goto IL_0220;
		case 15:
			goto IL_022a;
		case 16:
			goto IL_0234;
		case 17:
			goto IL_023e;
		case 18:
			goto IL_0248;
		default:
			goto IL_0252;
		case 0:
			goto IL_0271;
		}
		style_0.Pattern = BackgroundType.Solid;
		goto IL_0278;
		IL_019a:
		style_0.Pattern = BackgroundType.Gray75;
		goto IL_0278;
		IL_0252:
		method_35("Invalid value \"" + attribute + "\"", xmlTextReader_0.LineNumber);
		goto IL_0278;
		IL_0278:
		string attribute2 = xmlTextReader_0.GetAttribute("Color", string_2);
		string attribute3 = xmlTextReader_0.GetAttribute("PatternColor", string_2);
		if (style_0.Pattern != BackgroundType.Solid)
		{
			if (attribute3 != null && attribute3 != "" && attribute3.ToUpper() != "AUTOMATIC")
			{
				style_0.ForegroundColor = method_30(ColorTranslator.FromHtml(attribute3));
			}
			if (attribute2 != null && attribute2 != "" && attribute2.ToUpper() != "AUTOMATIC")
			{
				style_0.BackgroundColor = method_30(ColorTranslator.FromHtml(attribute2));
			}
		}
		else if (attribute2 != null && attribute2 != "" && attribute2.ToUpper() != "AUTOMATIC")
		{
			style_0.ForegroundColor = method_30(ColorTranslator.FromHtml(attribute2));
		}
		xmlTextReader_0.Skip();
		return;
		IL_0271:
		style_0.Pattern = BackgroundType.None;
		goto IL_0278;
		IL_0248:
		style_0.Pattern = BackgroundType.ThinDiagonalCrosshatch;
		goto IL_0278;
		IL_023e:
		style_0.Pattern = BackgroundType.ThinHorizontalCrosshatch;
		goto IL_0278;
		IL_0234:
		style_0.Pattern = BackgroundType.ThinDiagonalStripe;
		goto IL_0278;
		IL_022a:
		style_0.Pattern = BackgroundType.ThinReverseDiagonalStripe;
		goto IL_0278;
		IL_0220:
		style_0.Pattern = BackgroundType.ThinVerticalStripe;
		goto IL_0278;
		IL_0216:
		style_0.Pattern = BackgroundType.ThinHorizontalStripe;
		goto IL_0278;
		IL_020c:
		style_0.Pattern = BackgroundType.ThickDiagonalCrosshatch;
		goto IL_0278;
		IL_0202:
		style_0.Pattern = BackgroundType.DiagonalCrosshatch;
		goto IL_0278;
		IL_01f9:
		style_0.Pattern = BackgroundType.DiagonalStripe;
		goto IL_0278;
		IL_01f0:
		style_0.Pattern = BackgroundType.ReverseDiagonalStripe;
		goto IL_0278;
		IL_01e4:
		style_0.Pattern = BackgroundType.VerticalStripe;
		goto IL_0278;
		IL_01d8:
		style_0.Pattern = BackgroundType.HorizontalStripe;
		goto IL_0278;
		IL_01cb:
		style_0.Pattern = BackgroundType.Gray6;
		goto IL_0278;
		IL_01be:
		style_0.Pattern = BackgroundType.Gray12;
		goto IL_0278;
		IL_01b2:
		style_0.Pattern = BackgroundType.Gray25;
		goto IL_0278;
		IL_01a6:
		style_0.Pattern = BackgroundType.Gray50;
		goto IL_0278;
	}

	private void method_17(XmlTextReader xmlTextReader_0, Style style_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("Format", string_2);
		if (attribute == null)
		{
			xmlTextReader_0.Skip();
			style_0.Number = 0;
			return;
		}
		string key;
		if ((key = attribute) != null)
		{
			if (Class1742.dictionary_43 == null)
			{
				Class1742.dictionary_43 = new Dictionary<string, int>(19)
				{
					{ "", 0 },
					{ "General", 1 },
					{ "General Number", 2 },
					{ "General Date", 3 },
					{ "Long Date", 4 },
					{ "Medium Date", 5 },
					{ "Short Date", 6 },
					{ "Long Time", 7 },
					{ "Medium Time", 8 },
					{ "Short Time", 9 },
					{ "Currency", 10 },
					{ "Euro Currency", 11 },
					{ "Fixed", 12 },
					{ "Standard", 13 },
					{ "Percent", 14 },
					{ "Scientific", 15 },
					{ "Yes/No", 16 },
					{ "True/False", 17 },
					{ "On/Off", 18 }
				};
			}
			if (Class1742.dictionary_43.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 1:
					style_0.Number = 0;
					goto IL_02bb;
				case 2:
					style_0.Number = 1;
					goto IL_02bb;
				case 3:
					style_0.Custom = DateTimeFormatInfo.CurrentInfo.UniversalSortableDateTimePattern;
					goto IL_02bb;
				case 4:
					style_0.Custom = DateTimeFormatInfo.CurrentInfo.LongDatePattern;
					goto IL_02bb;
				case 5:
					style_0.Number = 15;
					goto IL_02bb;
				case 6:
					style_0.Custom = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
					goto IL_02bb;
				case 7:
					style_0.Number = 19;
					goto IL_02bb;
				case 8:
					style_0.Number = 18;
					goto IL_02bb;
				case 9:
					style_0.Number = 20;
					goto IL_02bb;
				case 10:
					style_0.Custom = "$#,##0.00_);[Red]($#,##0.00)";
					goto IL_02bb;
				case 11:
					style_0.Custom = "[$€-2] #,##0.00_);[Red]([$€-2] #,##0.00)";
					goto IL_02bb;
				case 12:
					style_0.Number = 2;
					goto IL_02bb;
				case 13:
					style_0.Number = 4;
					goto IL_02bb;
				case 14:
					style_0.Number = 10;
					goto IL_02bb;
				case 15:
					style_0.Number = 11;
					goto IL_02bb;
				case 16:
					style_0.Custom = "\"Yes\";\"Yes\";\"No\"";
					goto IL_02bb;
				case 17:
					style_0.Custom = "\"True\";\"True\";\"False\"";
					goto IL_02bb;
				case 18:
					style_0.Custom = "\"On\";\"On\";\"Off\"";
					goto IL_02bb;
				case 0:
					goto IL_02bb;
				}
			}
		}
		style_0.Custom = ((attribute[0] != '[' || attribute[4] != ']') ? attribute : attribute.Substring(5));
		goto IL_02bb;
		IL_02bb:
		xmlTextReader_0.Skip();
	}

	private void method_18(XmlTextReader xmlTextReader_0)
	{
		string text = null;
		bool flag = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "Name")
				{
					text = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "Protected")
				{
					flag = xmlTextReader_0.Value != "0";
				}
				else
				{
					_ = xmlTextReader_0.LocalName == "RightToLeft";
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (text == null)
		{
			method_35("A worksheet must have a name.", xmlTextReader_0.LineNumber);
		}
		Worksheet worksheet = workbook_0.Worksheets[text];
		if (flag)
		{
			worksheet.Protect(ProtectionType.All);
		}
		else
		{
			worksheet.Unprotect();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		Class1629 @class = null;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Table")
			{
				method_19(worksheet, xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "WorksheetOptions")
			{
				method_20(worksheet, xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "PageBreaks")
			{
				method_22(worksheet, xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "Names")
			{
				method_26(worksheet, xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "AutoFilter")
			{
				method_23(worksheet, xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "DataValidation")
			{
				method_29(xmlTextReader_0, worksheet);
			}
			else if (xmlTextReader_0.LocalName == "ConditionalFormatting")
			{
				if (xmlTextReader_0.IsEmptyElement)
				{
					xmlTextReader_0.Skip();
					continue;
				}
				if (@class == null)
				{
					@class = new Class1629(worksheet);
				}
				@class.Read(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_19(Worksheet worksheet_0, XmlTextReader xmlTextReader_0)
	{
		double num = 0.0;
		using (Bitmap image = new Bitmap(10, 10))
		{
			using Graphics graphics = Graphics.FromImage(image);
			num = graphics.DpiX;
		}
		double num2 = 72.0 / num;
		Class1106 @class = new Class1106();
		string text = null;
		if (xmlTextReader_0.HasAttributes)
		{
			int bool_;
			switch (xmlTextReader_0.GetAttribute("AutoFitWidth", string_2))
			{
			default:
				bool_ = 1;
				break;
			case null:
			case "":
			case "0":
				bool_ = 0;
				break;
			}
			@class.bool_0 = (byte)bool_ != 0;
			int bool_2;
			switch (xmlTextReader_0.GetAttribute("AutoFitHeight", string_2))
			{
			default:
				bool_2 = 1;
				break;
			case null:
			case "":
			case "0":
				bool_2 = 0;
				break;
			}
			@class.bool_1 = (byte)bool_2 != 0;
			text = xmlTextReader_0.GetAttribute("DefaultColumnWidth", string_2);
			if (text != null)
			{
				@class.double_0 = Class1618.smethod_85(text);
				double num3 = Class1677.smethod_0(@class.double_0 / num2, worksheet_0.method_2());
				if (num3 == 0.0)
				{
					worksheet_0.Cells.Columns.method_0().IsHidden = true;
				}
				else
				{
					worksheet_0.Cells.Columns.Width = num3;
				}
			}
			text = xmlTextReader_0.GetAttribute("DefaultRowHeight", string_2);
			if (text != null)
			{
				worksheet_0.Cells.StandardHeight = (@class.double_1 = Class1618.smethod_85(text));
			}
			@class.string_0 = xmlTextReader_0.GetAttribute("StyleID", string_2);
			if (@class.string_0 != null && @class.string_0 != "")
			{
				object obj = hashtable_0[@class.string_0];
				worksheet_0.Cells.Columns.method_0().method_6((int)obj);
			}
			text = xmlTextReader_0.GetAttribute("LeftCell", string_2);
			if (text != null)
			{
				@class.int_0 = int.Parse(text) - 2;
			}
			text = xmlTextReader_0.GetAttribute("TopCell", string_2);
			if (text != null)
			{
				@class.int_1 = int.Parse(text) - 2;
			}
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		int num4 = 0;
		int num5 = 0;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Column")
			{
				if (xmlTextReader_0.HasAttributes)
				{
					text = xmlTextReader_0.GetAttribute("Index", string_2);
					if (text != null)
					{
						num4 = int.Parse(text) - 1;
					}
					text = xmlTextReader_0.GetAttribute("Span", string_2);
					int num6 = 0;
					if (text != null)
					{
						num6 = int.Parse(text);
					}
					text = xmlTextReader_0.GetAttribute("StyleID", string_2);
					int int_ = 15;
					if (text != null)
					{
						object obj2 = hashtable_0[text];
						if (obj2 != null)
						{
							int_ = (int)obj2;
						}
					}
					bool flag = false;
					text = xmlTextReader_0.GetAttribute("Width", string_2);
					double double_ = 0.0;
					if (text != null)
					{
						flag = true;
						double_ = Class1677.smethod_0(Class1618.smethod_85(text) / num2, worksheet_0.method_2());
					}
					text = xmlTextReader_0.GetAttribute("Hidden", string_2);
					bool isHidden = false;
					if (text != null && text != "" && text != "0")
					{
						isHidden = true;
					}
					for (int i = 0; i <= num6; i++)
					{
						Column column = worksheet_0.Cells.Columns[i + num4];
						if (flag)
						{
							column.double_0 = double_;
						}
						column.IsHidden = isHidden;
						column.method_6(int_);
					}
					text = xmlTextReader_0.GetAttribute("AutoFitWidth", string_2);
					bool flag2 = text != null && text != "" && text != "0" && !flag;
					if (@class.bool_0 != flag2)
					{
						Class1104 class2 = new Class1104();
						class2.int_0 = @class.int_0 + num4;
						class2.int_1 = num6;
						class2.bool_0 = flag2;
						@class.arrayList_1.Add(class2);
					}
					num4 += num6 + 1;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Row")
			{
				num5++;
				if (xmlTextReader_0.HasAttributes)
				{
					text = xmlTextReader_0.GetAttribute("Index", string_2);
					if (text != null)
					{
						num5 = int.Parse(text);
					}
					text = xmlTextReader_0.GetAttribute("Span", string_2);
					int num7 = 0;
					if (text != null)
					{
						num7 = int.Parse(text);
					}
					text = xmlTextReader_0.GetAttribute("StyleID", string_2);
					if (text != null)
					{
						object obj3 = hashtable_0[text];
						if (obj3 == null)
						{
							method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
						}
						else
						{
							worksheet_0.Cells.Rows.GetRow(@class.int_1 + num5, bool_0: false, bool_1: false).method_11((int)obj3);
						}
					}
					bool flag3 = false;
					text = xmlTextReader_0.GetAttribute("Height", string_2);
					if (text != null)
					{
						flag3 = true;
						worksheet_0.Cells.SetRowHeight(@class.int_1 + num5, Class1618.smethod_85(text));
					}
					text = xmlTextReader_0.GetAttribute("Hidden", string_2);
					if (text != null)
					{
						for (int j = 0; j <= num7; j++)
						{
							worksheet_0.Cells.Rows.GetRow(@class.int_1 + num5 + j, bool_0: false, bool_1: false).IsHidden = true;
						}
					}
					text = xmlTextReader_0.GetAttribute("AutoFitHeight", string_2);
					bool flag4 = text != null && text != "" && text != "0" && !flag3;
					if (@class.bool_1 != flag4)
					{
						Class1104 class3 = new Class1104();
						class3.int_0 = @class.int_1 + num5;
						class3.int_1 = num7;
						class3.bool_0 = flag4;
						@class.arrayList_0.Add(class3);
					}
					num5 += num7;
				}
				if (xmlTextReader_0.IsEmptyElement)
				{
					xmlTextReader_0.Skip();
					continue;
				}
				xmlTextReader_0.Read();
				int num8 = 0;
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType != XmlNodeType.Element)
					{
						xmlTextReader_0.Skip();
						continue;
					}
					num8++;
					if (xmlTextReader_0.LocalName == "Cell")
					{
						int num9 = 0;
						int num10 = 0;
						bool flag5 = false;
						int num11 = -1;
						string text2 = null;
						string text3 = null;
						string screenTip = null;
						string text4 = null;
						while (xmlTextReader_0.MoveToNextAttribute())
						{
							if (xmlTextReader_0.LocalName == "StyleID")
							{
								text = xmlTextReader_0.Value;
								object obj4 = hashtable_0[text];
								if (obj4 == null)
								{
									method_35("Invalid value \"" + text + "\"", xmlTextReader_0.LineNumber);
								}
								num11 = (int)obj4;
							}
							else if (xmlTextReader_0.LocalName == "Index")
							{
								num8 = int.Parse(xmlTextReader_0.Value);
							}
							else if (xmlTextReader_0.LocalName == "MergeAcross")
							{
								num9 = int.Parse(xmlTextReader_0.Value);
								flag5 = true;
							}
							else if (xmlTextReader_0.LocalName == "MergeDown")
							{
								num10 = int.Parse(xmlTextReader_0.Value);
								flag5 = true;
							}
							else if (xmlTextReader_0.LocalName == "Formula")
							{
								text2 = xmlTextReader_0.Value;
							}
							else if (xmlTextReader_0.LocalName == "ArrayRange")
							{
								text4 = xmlTextReader_0.Value;
							}
							else if (xmlTextReader_0.LocalName == "HRef")
							{
								text3 = xmlTextReader_0.Value;
							}
							else if (xmlTextReader_0.LocalName == "HRefScreenTip")
							{
								screenTip = xmlTextReader_0.Value;
							}
						}
						Cell cell = worksheet_0.Cells.GetCell(num5 + @class.int_1, num8 + @class.int_0, bool_2: false);
						if (text2 != null)
						{
							string text5 = Class1619.smethod_10(text2, cell.Row, cell.Column);
							if (text4 != null)
							{
								CellArea cellArea = Class1631.smethod_9(text4, cell.Row, cell.Column);
								cell.SetArrayFormula(text5, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1);
							}
							else
							{
								cell.Formula = text5;
							}
						}
						Hyperlink hyperlink = null;
						if (text3 != null && text3 != "")
						{
							if (text3[0] == '#')
							{
								text3 = text3.Substring(1);
							}
							int index = worksheet_0.Hyperlinks.method_1(cell.Row, cell.Column, 1, 1, text3);
							hyperlink = worksheet_0.Hyperlinks[index];
							hyperlink.method_3("");
							hyperlink.ScreenTip = screenTip;
						}
						if (num11 != -1)
						{
							cell.method_37(num11);
						}
						if (flag5 && num10 + num9 != 0)
						{
							worksheet_0.Cells.Merge(num5 + @class.int_1, num8 + @class.int_0, num10 + 1, num9 + 1);
							if (num11 != -1)
							{
								for (int k = num5 + @class.int_1; k <= num5 + @class.int_1 + num10; k++)
								{
									for (int l = num8 + @class.int_0; l <= num8 + @class.int_0 + num9; l++)
									{
										worksheet_0.Cells.GetCell(k, l, bool_2: false).method_37(num11);
									}
								}
							}
						}
						xmlTextReader_0.MoveToElement();
						if (xmlTextReader_0.IsEmptyElement)
						{
							xmlTextReader_0.Skip();
							num8 += num9;
							continue;
						}
						xmlTextReader_0.Read();
						while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
						{
							xmlTextReader_0.MoveToContent();
							if (xmlTextReader_0.NodeType != XmlNodeType.Element)
							{
								xmlTextReader_0.Skip();
							}
							else if (xmlTextReader_0.LocalName == "Data")
							{
								string text6 = null;
								while (xmlTextReader_0.MoveToNextAttribute())
								{
									if (xmlTextReader_0.LocalName == "Type")
									{
										text6 = xmlTextReader_0.Value;
									}
								}
								xmlTextReader_0.MoveToElement();
								if (text6 == null)
								{
									text6 = "String";
								}
								bool flag6 = false;
								text = null;
								if (!xmlTextReader_0.IsEmptyElement)
								{
									if (text6 != "String")
									{
										text = xmlTextReader_0.ReadElementString();
									}
									else if (xmlTextReader_0.GetAttribute("xmlns") != null)
									{
										ArrayList arrayList_ = new ArrayList();
										Aspose.Cells.Font font_ = cell.method_32().method_40();
										Aspose.Cells.Font font = new Aspose.Cells.Font(worksheet_0.method_2(), null, bool_0: false);
										font.Copy(font_);
										method_33(xmlTextReader_0, arrayList_, font_, font, worksheet_0.method_2(), bool_0: false);
										flag6 = true;
										method_31(cell, arrayList_, worksheet_0.method_2());
									}
									else
									{
										StringBuilder stringBuilder = new StringBuilder();
										method_34(xmlTextReader_0, stringBuilder, bool_0: false);
										text = stringBuilder.ToString();
									}
								}
								else
								{
									xmlTextReader_0.Skip();
								}
								if (flag6)
								{
									continue;
								}
								object obj5 = null;
								switch (text6)
								{
								case "Boolean":
								{
									int num12;
									switch (text)
									{
									default:
										num12 = 1;
										goto IL_0b63;
									case "0":
										num12 = 0;
										goto IL_0b63;
									case null:
									case "":
										{
											obj5 = false;
											break;
										}
										IL_0b63:
										obj5 = (byte)num12 != 0;
										break;
									}
									break;
								}
								case "DateTime":
									obj5 = ((text == null || text == "") ? ((object)0.0) : ((object)DateTime.Parse(text)));
									break;
								case "Number":
									obj5 = ((text == null || text == "") ? ((object)0.0) : ((object)Class1618.smethod_85(text)));
									break;
								case "String":
									obj5 = ((text != null) ? text : "");
									break;
								}
								if (cell.IsFormula)
								{
									cell.method_66(obj5, 0);
								}
								else
								{
									cell.PutValue(obj5);
								}
								hyperlink?.method_3(obj5.ToString());
							}
							else if (xmlTextReader_0.LocalName == "Comment")
							{
								int index2 = worksheet_0.Comments.Add(num5 + @class.int_1, num8 + @class.int_0);
								Comment comment = worksheet_0.Comments[index2];
								while (xmlTextReader_0.MoveToNextAttribute())
								{
									string localName;
									if ((localName = xmlTextReader_0.LocalName) != null && localName == "ShowAlways")
									{
										comment.IsVisible = xmlTextReader_0.Value == "1";
									}
								}
								xmlTextReader_0.MoveToElement();
								if (xmlTextReader_0.IsEmptyElement)
								{
									xmlTextReader_0.Skip();
									continue;
								}
								xmlTextReader_0.Read();
								while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
								{
									xmlTextReader_0.MoveToContent();
									if (xmlTextReader_0.NodeType != XmlNodeType.Element)
									{
										xmlTextReader_0.Skip();
									}
									else if (xmlTextReader_0.LocalName == "Data")
									{
										ArrayList arrayList_2 = new ArrayList();
										Aspose.Cells.Font font2 = comment.Font;
										Aspose.Cells.Font font3 = new Aspose.Cells.Font(worksheet_0.method_2(), null, bool_0: false);
										font3.Copy(font2);
										method_33(xmlTextReader_0, arrayList_2, font2, font3, worksheet_0.method_2(), bool_0: false);
										method_32(comment, arrayList_2, worksheet_0.method_2());
									}
									else
									{
										xmlTextReader_0.Skip();
									}
								}
								xmlTextReader_0.ReadEndElement();
							}
							else if (xmlTextReader_0.LocalName == "NamedCell")
							{
								xmlTextReader_0.Skip();
							}
							else
							{
								xmlTextReader_0.Skip();
							}
						}
						num8 += num9;
						xmlTextReader_0.ReadEndElement();
					}
					else
					{
						method_36(xmlTextReader_0.LineNumber, xmlTextReader_0.LocalName);
					}
				}
				xmlTextReader_0.ReadEndElement();
			}
			else
			{
				method_36(xmlTextReader_0.LineNumber, xmlTextReader_0.LocalName);
			}
		}
		if (!@class.bool_0)
		{
			foreach (Class1104 item in @class.arrayList_1)
			{
				for (int m = item.int_0; m <= item.int_0 + item.int_1; m++)
				{
					worksheet_0.AutoFitColumn(m);
				}
			}
		}
		else
		{
			IEnumerator enumerator2 = @class.arrayList_1.GetEnumerator();
			Class1104 class5 = (enumerator2.MoveNext() ? ((Class1104)enumerator2.Current) : null);
			for (int n = worksheet_0.Cells.MinColumn; n <= worksheet_0.Cells.method_22(0); n++)
			{
				bool flag7 = true;
				if (class5 != null)
				{
					switch (class5.Contains(n))
					{
					case 0:
						flag7 = false;
						break;
					case 1:
						class5 = (enumerator2.MoveNext() ? ((Class1104)enumerator2.Current) : null);
						break;
					}
				}
				if (flag7)
				{
					worksheet_0.AutoFitColumn(n);
				}
			}
		}
		if (!@class.bool_1)
		{
			foreach (Class1104 item2 in @class.arrayList_0)
			{
				for (int num13 = item2.int_0; num13 <= item2.int_0 + item2.int_1; num13++)
				{
					worksheet_0.AutoFitRow(num13);
				}
			}
		}
		else
		{
			IEnumerator enumerator3 = @class.arrayList_0.GetEnumerator();
			Class1104 class7 = (enumerator3.MoveNext() ? ((Class1104)enumerator3.Current) : null);
			for (int num14 = worksheet_0.Cells.MinRow; num14 <= worksheet_0.Cells.method_20(0); num14++)
			{
				bool flag8 = true;
				if (class7 != null)
				{
					switch (class7.Contains(num14))
					{
					case 0:
						flag8 = false;
						break;
					case 1:
						class7 = (enumerator3.MoveNext() ? ((Class1104)enumerator3.Current) : null);
						break;
					}
				}
				if (flag8)
				{
					worksheet_0.AutoFitRow(num14);
				}
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_20(Worksheet worksheet_0, XmlTextReader xmlTextReader_0)
	{
		bool isPercentScale = true;
		bool flag = false;
		int int_ = 0;
		int int_2 = 0;
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "DoNotDisplayGridlines")
			{
				worksheet_0.IsGridlinesVisible = false;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "PageSetup")
			{
				method_27(worksheet_0, xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "Print")
			{
				method_28(worksheet_0, xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "FitToPage")
			{
				isPercentScale = false;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "DoNotDisplayZeros")
			{
				worksheet_0.DisplayZeros = false;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Visible")
			{
				string text = xmlTextReader_0.ReadElementString();
				if (text == "SheetHidden")
				{
					worksheet_0.method_28(bool_1: false, bool_2: false);
				}
				else if (text == "SheetVeryHidden")
				{
					worksheet_0.method_28(bool_1: false, bool_2: true);
				}
			}
			else if (xmlTextReader_0.LocalName == "DoNotDisplayHeadings")
			{
				worksheet_0.IsRowColumnHeadersVisible = false;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Zoom")
			{
				worksheet_0.Zoom = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "FreezePanes")
			{
				flag = true;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "SplitHorizontal")
			{
				num = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "TopRowBottomPane")
			{
				int_ = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "SplitVertical")
			{
				num2 = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "LeftColumnRightPane")
			{
				int_2 = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "TabColorIndex")
			{
				int num4 = int.Parse(xmlTextReader_0.ReadElementString());
				if (num4 < 64)
				{
					worksheet_0.method_40(num4);
				}
			}
			else if (xmlTextReader_0.LocalName == "TopRowVisible")
			{
				string text2 = xmlTextReader_0.ReadElementString();
				if (text2 != null)
				{
					worksheet_0.FirstVisibleRow = int.Parse(text2);
				}
			}
			else if (xmlTextReader_0.LocalName == "LeftColumnVisible")
			{
				string text3 = xmlTextReader_0.ReadElementString();
				if (text3 != null)
				{
					worksheet_0.FirstVisibleColumn = int.Parse(text3);
				}
			}
			else if (xmlTextReader_0.LocalName == "ActivePane")
			{
				num3 = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "Panes")
			{
				method_21(worksheet_0, xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		worksheet_0.PageSetup.IsPercentScale = isPercentScale;
		if (flag)
		{
			worksheet_0.method_14(bool_1: true);
		}
		if (num != -1 || num2 != -1)
		{
			PaneCollection paneCollection = worksheet_0.method_1();
			paneCollection.method_2(int_);
			paneCollection.method_3(int_2);
			if (num2 != -1)
			{
				paneCollection.method_7(num2);
			}
			if (num != -1)
			{
				paneCollection.method_5(num);
			}
			if (num3 != -1)
			{
				paneCollection.method_1(Convert.ToByte(num3));
			}
		}
	}

	[Attribute0(true)]
	private void method_21(Worksheet worksheet_0, XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1733 @class = new Class1733(worksheet_0);
		worksheet_0.method_35(@class);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Pane")
			{
				if (xmlTextReader_0.IsEmptyElement)
				{
					xmlTextReader_0.Skip();
					continue;
				}
				int num = -1;
				int num2 = -1;
				int num3 = -1;
				string text = null;
				xmlTextReader_0.Read();
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType != XmlNodeType.Element)
					{
						xmlTextReader_0.Skip();
					}
					else if (xmlTextReader_0.LocalName == "Number")
					{
						num = int.Parse(xmlTextReader_0.ReadElementString());
					}
					else if (xmlTextReader_0.LocalName == "ActiveRow")
					{
						num2 = int.Parse(xmlTextReader_0.ReadElementString());
					}
					else if (xmlTextReader_0.LocalName == "ActiveCol")
					{
						num3 = int.Parse(xmlTextReader_0.ReadElementString());
					}
					else if (xmlTextReader_0.LocalName == "RangeSelection")
					{
						text = xmlTextReader_0.ReadElementString();
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
				if (num == -1)
				{
					continue;
				}
				Class1732 class2 = new Class1732(num);
				@class.Add(class2);
				if (num2 != -1)
				{
					class2.method_6(num2);
				}
				if (num3 != -1)
				{
					class2.method_8(num3);
				}
				class2.method_10(0);
				if (text != null && text != "")
				{
					string[] array = text.Split(',');
					for (int i = 0; i < array.Length; i++)
					{
						string text2 = array[i].Trim();
						if (text2.Length > 0)
						{
							CellArea cellArea = Class1631.smethod_10(text2);
							class2.method_3().Add(cellArea);
						}
					}
				}
				else
				{
					CellArea cellArea2 = default(CellArea);
					if (num2 != -1)
					{
						cellArea2.StartRow = (cellArea2.EndRow = num2);
					}
					if (num3 != -1)
					{
						cellArea2.StartColumn = (cellArea2.EndColumn = num3);
					}
					class2.method_3().Add(cellArea2);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_22(Worksheet worksheet_0, XmlTextReader xmlTextReader_0)
	{
		worksheet_0.HorizontalPageBreaks.Clear();
		worksheet_0.VerticalPageBreaks.Clear();
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "ColBreaks")
			{
				if (xmlTextReader_0.IsEmptyElement)
				{
					xmlTextReader_0.Skip();
					continue;
				}
				xmlTextReader_0.Read();
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType != XmlNodeType.Element)
					{
						xmlTextReader_0.Skip();
					}
					else if (xmlTextReader_0.LocalName == "ColBreak")
					{
						if (xmlTextReader_0.IsEmptyElement)
						{
							xmlTextReader_0.Skip();
							continue;
						}
						xmlTextReader_0.Read();
						int num = -1;
						int num2 = -1;
						int num3 = -1;
						while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
						{
							xmlTextReader_0.MoveToContent();
							if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
							{
								if (xmlTextReader_0.LocalName == "Column")
								{
									num = int.Parse(xmlTextReader_0.ReadElementString());
								}
								else if (xmlTextReader_0.LocalName == "RowStart")
								{
									num2 = int.Parse(xmlTextReader_0.ReadElementString());
								}
								else if (xmlTextReader_0.LocalName == "RowEnd")
								{
									num3 = int.Parse(xmlTextReader_0.ReadElementString());
								}
								else
								{
									xmlTextReader_0.Skip();
								}
							}
							else
							{
								xmlTextReader_0.Skip();
							}
						}
						if (num != -1)
						{
							if (num2 == -1 && num3 == -1)
							{
								worksheet_0.VerticalPageBreaks.Add(0, num);
							}
							else
							{
								if (num2 == -1)
								{
									num2 = 0;
								}
								if (num3 == -1)
								{
									num3 = 255;
								}
								worksheet_0.VerticalPageBreaks.Add(num2, num3, num);
							}
						}
						xmlTextReader_0.ReadEndElement();
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
			}
			else if (xmlTextReader_0.LocalName == "RowBreaks")
			{
				if (xmlTextReader_0.IsEmptyElement)
				{
					xmlTextReader_0.Skip();
					continue;
				}
				xmlTextReader_0.Read();
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType != XmlNodeType.Element)
					{
						xmlTextReader_0.Skip();
					}
					else if (xmlTextReader_0.LocalName == "RowBreak")
					{
						if (xmlTextReader_0.IsEmptyElement)
						{
							xmlTextReader_0.Skip();
							continue;
						}
						xmlTextReader_0.Read();
						int num4 = -1;
						int num5 = -1;
						int num6 = -1;
						while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
						{
							xmlTextReader_0.MoveToContent();
							if (xmlTextReader_0.NodeType == XmlNodeType.Element && !xmlTextReader_0.IsEmptyElement)
							{
								if (xmlTextReader_0.LocalName == "Row")
								{
									num4 = int.Parse(xmlTextReader_0.ReadElementString());
								}
								else if (xmlTextReader_0.LocalName == "ColStart")
								{
									num5 = int.Parse(xmlTextReader_0.ReadElementString());
								}
								else if (xmlTextReader_0.LocalName == "ColEnd")
								{
									num6 = int.Parse(xmlTextReader_0.ReadElementString());
								}
								else
								{
									xmlTextReader_0.Skip();
								}
							}
							else
							{
								xmlTextReader_0.Skip();
							}
						}
						if (num4 != -1)
						{
							if (num5 == -1 && num6 == -1)
							{
								worksheet_0.HorizontalPageBreaks.Add(num4, 0);
							}
							else
							{
								if (num5 == -1)
								{
									num5 = 0;
								}
								if (num6 == -1)
								{
									num6 = 255;
								}
								worksheet_0.HorizontalPageBreaks.Add(num4, num5, num6);
							}
						}
						xmlTextReader_0.ReadEndElement();
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_23(Worksheet worksheet_0, XmlTextReader xmlTextReader_0)
	{
		if (worksheet_0.method_2().Names.method_9("_FilterDatabase", worksheet_0.Index) != -1)
		{
			CellArea cellArea = Class1631.smethod_10(xmlTextReader_0.GetAttribute("Range", string_1));
			worksheet_0.AutoFilter.SetRange(cellArea.StartRow, cellArea.StartColumn, cellArea.EndColumn);
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		int int_ = -1;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "AutoFilterColumn")
			{
				int_ = method_24(xmlTextReader_0, worksheet_0.AutoFilter, int_);
			}
		}
		worksheet_0.AutoFilter.bool_0 = false;
		xmlTextReader_0.ReadEndElement();
	}

	private int method_24(XmlTextReader xmlTextReader_0, AutoFilter autoFilter_0, int int_1)
	{
		int num = int_1 + 1;
		string attribute = xmlTextReader_0.GetAttribute("Index", string_1);
		if (attribute != null)
		{
			num = Class1618.smethod_87(attribute) - 1;
		}
		string attribute2 = xmlTextReader_0.GetAttribute("Type", string_1);
		if (attribute2 == null)
		{
			xmlTextReader_0.Skip();
			return num;
		}
		string key;
		if ((key = attribute2) != null)
		{
			if (Class1742.dictionary_44 == null)
			{
				Class1742.dictionary_44 = new Dictionary<string, int>(7)
				{
					{ "Custom", 0 },
					{ "Top", 1 },
					{ "Bottom", 2 },
					{ "TopPercent", 3 },
					{ "BottomPercent", 4 },
					{ "Blanks", 5 },
					{ "NonBlanks", 6 }
				};
			}
			if (Class1742.dictionary_44.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					if (xmlTextReader_0.IsEmptyElement)
					{
						xmlTextReader_0.Skip();
						return num;
					}
					xmlTextReader_0.Read();
					while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
					{
						xmlTextReader_0.MoveToContent();
						if (xmlTextReader_0.NodeType != XmlNodeType.Element)
						{
							xmlTextReader_0.Skip();
							continue;
						}
						string localName = xmlTextReader_0.LocalName;
						switch (localName)
						{
						case "AutoFilterOr":
						case "AutoFilterAnd":
						{
							bool isAnd = localName == "AutoFilterAnd";
							if (xmlTextReader_0.IsEmptyElement)
							{
								xmlTextReader_0.Skip();
								break;
							}
							xmlTextReader_0.Read();
							object[] array2 = null;
							object[] array3 = null;
							while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
							{
								xmlTextReader_0.MoveToContent();
								string localName2;
								if (xmlTextReader_0.NodeType != XmlNodeType.Element)
								{
									xmlTextReader_0.Skip();
								}
								else if ((localName2 = xmlTextReader_0.LocalName) != null && localName2 == "AutoFilterCondition")
								{
									if (array2 == null)
									{
										array2 = method_25(xmlTextReader_0);
									}
									else
									{
										array3 = method_25(xmlTextReader_0);
									}
								}
							}
							autoFilter_0.Custom(num, (FilterOperatorType)array2[0], array2[1], isAnd, (FilterOperatorType)array3[0], array3[1]);
							xmlTextReader_0.ReadEndElement();
							break;
						}
						case "AutoFilterCondition":
						{
							object[] array = method_25(xmlTextReader_0);
							autoFilter_0.Custom(num, (FilterOperatorType)array[0], array[1]);
							break;
						}
						}
					}
					xmlTextReader_0.ReadEndElement();
					return num;
				case 1:
				{
					string attribute6 = xmlTextReader_0.GetAttribute("Value", string_1);
					int itemCount4 = Class1618.smethod_87(attribute6);
					autoFilter_0.FilterTop10(num, isTop: true, isPercent: false, itemCount4);
					xmlTextReader_0.Skip();
					return num;
				}
				case 2:
				{
					string attribute5 = xmlTextReader_0.GetAttribute("Value", string_1);
					int itemCount3 = Class1618.smethod_87(attribute5);
					autoFilter_0.FilterTop10(num, isTop: false, isPercent: false, itemCount3);
					xmlTextReader_0.Skip();
					return num;
				}
				case 3:
				{
					string attribute4 = xmlTextReader_0.GetAttribute("Value", string_1);
					int itemCount2 = Class1618.smethod_87(attribute4);
					autoFilter_0.FilterTop10(num, isTop: true, isPercent: true, itemCount2);
					xmlTextReader_0.Skip();
					return num;
				}
				case 4:
				{
					string attribute3 = xmlTextReader_0.GetAttribute("Value", string_1);
					int itemCount = Class1618.smethod_87(attribute3);
					autoFilter_0.FilterTop10(num, isTop: false, isPercent: true, itemCount);
					xmlTextReader_0.Skip();
					return num;
				}
				case 5:
					autoFilter_0.MatchBlanks(num);
					xmlTextReader_0.Skip();
					return num;
				case 6:
					autoFilter_0.MatchNonBlanks(num);
					xmlTextReader_0.Skip();
					return num;
				}
			}
		}
		xmlTextReader_0.Skip();
		return num;
	}

	[Attribute0(true)]
	private object[] method_25(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("Operator", string_1);
		string attribute2 = xmlTextReader_0.GetAttribute("Value", string_1);
		xmlTextReader_0.Skip();
		FilterOperatorType filterOperatorType = FilterOperatorType.Equal;
		object[] array = new object[2];
		string key;
		if ((key = attribute) != null)
		{
			if (Class1742.dictionary_45 == null)
			{
				Class1742.dictionary_45 = new Dictionary<string, int>(7)
				{
					{ "GreaterThan", 0 },
					{ "GreaterThanOrEqual", 1 },
					{ "LessThan", 2 },
					{ "LessThanOrEqual", 3 },
					{ "DoesNotEqual", 4 },
					{ "Equals", 5 },
					{ "None", 6 }
				};
			}
			if (Class1742.dictionary_45.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					break;
				case 1:
					goto IL_00e1;
				case 2:
					goto IL_00e5;
				case 3:
					goto IL_00e9;
				case 4:
					goto IL_00ed;
				case 5:
					goto IL_00f1;
				case 6:
					goto IL_00f5;
				default:
					goto IL_00f9;
				}
				filterOperatorType = FilterOperatorType.GreaterThan;
				goto IL_00fb;
			}
		}
		goto IL_00f9;
		IL_00e5:
		filterOperatorType = FilterOperatorType.LessThan;
		goto IL_00fb;
		IL_00fb:
		array[0] = filterOperatorType;
		if (attribute2 != null)
		{
			if (Class1677.smethod_19(attribute2))
			{
				double num = Class1618.smethod_85(attribute2);
				array[1] = num;
			}
			else
			{
				array[1] = attribute2;
			}
		}
		return array;
		IL_00e1:
		filterOperatorType = FilterOperatorType.GreaterOrEqual;
		goto IL_00fb;
		IL_00f9:
		filterOperatorType = FilterOperatorType.Equal;
		goto IL_00fb;
		IL_00f5:
		filterOperatorType = FilterOperatorType.None;
		goto IL_00fb;
		IL_00f1:
		filterOperatorType = FilterOperatorType.Equal;
		goto IL_00fb;
		IL_00ed:
		filterOperatorType = FilterOperatorType.NotEqual;
		goto IL_00fb;
		IL_00e9:
		filterOperatorType = FilterOperatorType.LessOrEqual;
		goto IL_00fb;
	}

	private void method_26(Worksheet worksheet_0, XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else
			{
				if (!(xmlTextReader_0.LocalName == "NamedRange"))
				{
					continue;
				}
				string attribute = xmlTextReader_0.GetAttribute("Name", string_2);
				if (attribute == "Print_Area")
				{
					attribute = xmlTextReader_0.GetAttribute("RefersTo", string_2);
					if (attribute != null)
					{
						int num = attribute.IndexOf(',');
						if (num != -1)
						{
							attribute = attribute.Substring(0, num);
						}
						num = attribute.LastIndexOf('!');
						if (num != -1)
						{
							attribute = attribute.Substring(num + 1, attribute.Length - num - 1);
						}
						StringBuilder stringBuilder = new StringBuilder(16);
						int num2 = -1;
						int num3 = -1;
						int num4 = -1;
						bool flag = false;
						for (int i = 0; i < attribute.Length; i++)
						{
							char c = attribute[i];
							switch (c)
							{
							case '0':
							case '1':
							case '2':
							case '3':
							case '4':
							case '5':
							case '6':
							case '7':
							case '8':
							case '9':
								if (i == attribute.Length - 1)
								{
									num4 = i + 1;
								}
								break;
							default:
								num4 = i;
								break;
							case 'C':
							case 'c':
								num3 = i;
								break;
							case 'R':
							case 'r':
								num2 = i;
								break;
							}
							if (num2 != -1 && num3 - num2 > 1 && num4 - num3 > 1)
							{
								int num5 = int.Parse(attribute.Substring(num2 + 1, num3 - num2 - 1));
								int num6 = int.Parse(attribute.Substring(num3 + 1, num4 - num3 - 1)) - 1;
								if (num5 >= 0 && num5 <= 65535 && num6 >= 0 && num6 <= 255)
								{
									stringBuilder.Append(CellsHelper.ColumnIndexToName(num6));
									stringBuilder.Append(num5);
								}
							}
							if (c == ':')
							{
								flag = true;
								stringBuilder.Append(c);
							}
							if (num4 != -1)
							{
								num2 = (num4 = (num3 = -1));
							}
						}
						attribute = stringBuilder.ToString();
						if (!flag)
						{
							stringBuilder.Append(':');
							stringBuilder.Append(attribute);
							attribute = stringBuilder.ToString();
						}
						worksheet_0.PageSetup.PrintArea = attribute;
					}
				}
				else if (attribute == "Print_Titles")
				{
					attribute = xmlTextReader_0.GetAttribute("RefersTo", string_2);
					if (attribute != null && attribute.Length > 0)
					{
						string[] array = attribute.Split(',');
						for (int j = 0; j < array.Length; j++)
						{
							string text = array[j];
							int num7 = text.LastIndexOf('!');
							if (num7 != -1)
							{
								text = text.Substring(num7 + 1, text.Length - num7 - 1);
							}
							if (text.Length < 2)
							{
								continue;
							}
							bool flag2 = false;
							if (text.LastIndexOf('[') != -1)
							{
								text = text.Replace("[", "");
								text = text.Replace("]", "");
								flag2 = true;
							}
							StringBuilder stringBuilder2 = new StringBuilder(16);
							int num8 = -1;
							int num9 = -1;
							bool flag3 = false;
							int num10 = 0;
							for (int k = 0; k < text.Length; k++)
							{
								char c2 = text[k];
								switch (c2)
								{
								case '0':
								case '1':
								case '2':
								case '3':
								case '4':
								case '5':
								case '6':
								case '7':
								case '8':
								case '9':
									if (k == text.Length - 1)
									{
										num9 = k + 1;
									}
									break;
								default:
									num9 = k;
									break;
								case 'C':
								case 'c':
									num8 = k;
									num10 = 2;
									break;
								case 'R':
								case 'r':
									num8 = k;
									num10 = 1;
									break;
								}
								if (num8 != -1 && num9 - num8 > 1)
								{
									int num11 = int.Parse(text.Substring(num8 + 1, num9 - num8 - 1));
									if (num10 == 1 && num11 >= 0 && num11 <= 65535)
									{
										if (flag2)
										{
											num11++;
										}
										stringBuilder2.Append('$');
										stringBuilder2.Append(num11);
									}
									else if (num10 == 2 && num11 >= 0 && num11 <= 255)
									{
										if (!flag2)
										{
											num11--;
										}
										stringBuilder2.Append('$');
										stringBuilder2.Append(CellsHelper.ColumnIndexToName(num11));
									}
								}
								if (c2 == ':')
								{
									flag3 = true;
									stringBuilder2.Append(c2);
								}
								if (num9 != -1)
								{
									num8 = (num9 = -1);
								}
							}
							text = stringBuilder2.ToString();
							if (!flag3)
							{
								stringBuilder2.Append(':');
								stringBuilder2.Append(text);
								text = stringBuilder2.ToString();
							}
							switch (num10)
							{
							case 1:
								worksheet_0.PageSetup.PrintTitleRows = text;
								break;
							case 2:
								worksheet_0.PageSetup.PrintTitleColumns = text;
								break;
							}
						}
					}
				}
				else
				{
					string text2 = attribute;
					string attribute2 = xmlTextReader_0.GetAttribute("RefersTo", string_2);
					if (text2 != null && attribute2 != null)
					{
						try
						{
							int index = workbook_0.Worksheets.Names.method_0(worksheet_0.Index, text2);
							Name name = workbook_0.Worksheets.Names[index];
							string text3;
							if ((text3 = text2.ToUpper()) != null && text3 == "_FILTERDATABASE")
							{
								name.method_15("_FILTERDATABASE");
							}
							name.RefersTo = Class1619.smethod_10(attribute2, -1, -1);
						}
						catch
						{
						}
					}
				}
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_27(Worksheet worksheet_0, XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Layout")
			{
				string attribute = xmlTextReader_0.GetAttribute("Orientation", string_1);
				if (attribute != null)
				{
					if (attribute == "Landscape")
					{
						worksheet_0.PageSetup.Orientation = PageOrientationType.Landscape;
					}
					else
					{
						worksheet_0.PageSetup.Orientation = PageOrientationType.Portrait;
					}
				}
				switch (xmlTextReader_0.GetAttribute("CenterHorizontal", string_1))
				{
				default:
					worksheet_0.PageSetup.CenterHorizontally = true;
					break;
				case "":
				case "0":
					worksheet_0.PageSetup.CenterHorizontally = false;
					break;
				case null:
					break;
				}
				switch (xmlTextReader_0.GetAttribute("CenterVertical", string_1))
				{
				default:
					worksheet_0.PageSetup.CenterVertically = true;
					break;
				case "":
				case "0":
					worksheet_0.PageSetup.CenterVertically = false;
					break;
				case null:
					break;
				}
				attribute = xmlTextReader_0.GetAttribute("StartPageNumber", string_1);
				if (attribute != null)
				{
					worksheet_0.PageSetup.FirstPageNumber = int.Parse(attribute);
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "PageMargins")
			{
				string attribute2 = xmlTextReader_0.GetAttribute("Bottom", string_1);
				if (attribute2 != null && attribute2.Length > 0)
				{
					worksheet_0.PageSetup.BottomMargin = Class1618.smethod_85(attribute2) * 2.54;
				}
				attribute2 = xmlTextReader_0.GetAttribute("Left", string_1);
				if (attribute2 != null && attribute2.Length > 0)
				{
					worksheet_0.PageSetup.LeftMargin = Class1618.smethod_85(attribute2) * 2.54;
				}
				attribute2 = xmlTextReader_0.GetAttribute("Right", string_1);
				if (attribute2 != null && attribute2.Length > 0)
				{
					worksheet_0.PageSetup.RightMargin = Class1618.smethod_85(attribute2) * 2.54;
				}
				attribute2 = xmlTextReader_0.GetAttribute("Top", string_1);
				if (attribute2 != null && attribute2.Length > 0)
				{
					worksheet_0.PageSetup.TopMargin = Class1618.smethod_85(attribute2) * 2.54;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Header")
			{
				string attribute3 = xmlTextReader_0.GetAttribute("Data", string_1);
				if (attribute3 != null)
				{
					int section = 1;
					int num = 0;
					for (int i = 0; i < attribute3.Length; i++)
					{
						if (attribute3[i] != '&' || i + 1 >= attribute3.Length)
						{
							continue;
						}
						char c = attribute3[i + 1];
						if (c <= 'R')
						{
							if (c != 'C')
							{
								if (c != 'L')
								{
									if (c != 'R')
									{
										continue;
									}
									goto IL_02da;
								}
								goto IL_02df;
							}
						}
						else if (c != 'c')
						{
							if (c != 'l')
							{
								if (c != 'r')
								{
									continue;
								}
								goto IL_02da;
							}
							goto IL_02df;
						}
						int num2 = 1;
						goto IL_02e7;
						IL_02df:
						num2 = 0;
						goto IL_02e7;
						IL_02e7:
						if (i - num > 0)
						{
							worksheet_0.PageSetup.SetHeader(section, attribute3.Substring(num, i - num));
						}
						section = num2;
						num = i + 2;
						continue;
						IL_02da:
						num2 = 2;
						goto IL_02e7;
					}
					if (num < attribute3.Length)
					{
						worksheet_0.PageSetup.SetHeader(section, attribute3.Substring(num));
					}
				}
				string attribute4 = xmlTextReader_0.GetAttribute("Margin", string_1);
				if (attribute4 != null && attribute4.Length > 0)
				{
					worksheet_0.PageSetup.HeaderMargin = Class1618.smethod_85(attribute4) * 2.54;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Footer")
			{
				string attribute5 = xmlTextReader_0.GetAttribute("Data", string_1);
				if (attribute5 != null)
				{
					int section2 = 1;
					int num3 = 0;
					for (int j = 0; j < attribute5.Length; j++)
					{
						if (attribute5[j] != '&' || j + 1 >= attribute5.Length)
						{
							continue;
						}
						char c2 = attribute5[j + 1];
						if (c2 <= 'R')
						{
							if (c2 != 'C')
							{
								if (c2 != 'L')
								{
									if (c2 != 'R')
									{
										continue;
									}
									goto IL_041f;
								}
								goto IL_0424;
							}
						}
						else if (c2 != 'c')
						{
							if (c2 != 'l')
							{
								if (c2 != 'r')
								{
									continue;
								}
								goto IL_041f;
							}
							goto IL_0424;
						}
						int num4 = 1;
						goto IL_042c;
						IL_0424:
						num4 = 0;
						goto IL_042c;
						IL_042c:
						if (j - num3 > 0)
						{
							worksheet_0.PageSetup.SetFooter(section2, attribute5.Substring(num3, j - num3));
						}
						section2 = num4;
						num3 = j + 2;
						continue;
						IL_041f:
						num4 = 2;
						goto IL_042c;
					}
					if (num3 < attribute5.Length)
					{
						worksheet_0.PageSetup.SetFooter(section2, attribute5.Substring(num3));
					}
				}
				string attribute6 = xmlTextReader_0.GetAttribute("Margin", string_1);
				if (attribute6 != null && attribute6.Length > 0)
				{
					worksheet_0.PageSetup.FooterMargin = Class1618.smethod_85(attribute6) * 2.54;
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_28(Worksheet worksheet_0, XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		bool flag = false;
		int num = -1;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "FitWidth")
			{
				string s = xmlTextReader_0.ReadElementString();
				worksheet_0.PageSetup.FitToPagesWide = int.Parse(s);
			}
			else if (xmlTextReader_0.LocalName == "FitHeight")
			{
				string s2 = xmlTextReader_0.ReadElementString();
				worksheet_0.PageSetup.FitToPagesTall = int.Parse(s2);
			}
			else if (xmlTextReader_0.LocalName == "LeftToRight")
			{
				worksheet_0.PageSetup.Order = PrintOrderType.OverThenDown;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "BlackAndWhite")
			{
				worksheet_0.PageSetup.BlackAndWhite = true;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "DraftQuality")
			{
				worksheet_0.PageSetup.PrintDraft = true;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "CommentsLayout")
			{
				string text = xmlTextReader_0.ReadElementString();
				if (text == "SheetEnd")
				{
					worksheet_0.PageSetup.PrintComments = PrintCommentsType.PrintSheetEnd;
				}
				else if (text == "InPlace")
				{
					worksheet_0.PageSetup.PrintComments = PrintCommentsType.PrintInPlace;
				}
				else
				{
					worksheet_0.PageSetup.PrintComments = PrintCommentsType.PrintNoComments;
				}
			}
			else if (xmlTextReader_0.LocalName == "PrintErrors")
			{
				switch (xmlTextReader_0.ReadElementString())
				{
				case "NA":
					worksheet_0.PageSetup.PrintErrors = PrintErrorsType.PrintErrorsNA;
					break;
				case "Dash":
					worksheet_0.PageSetup.PrintErrors = PrintErrorsType.PrintErrorsDash;
					break;
				case "Blank":
					worksheet_0.PageSetup.PrintErrors = PrintErrorsType.PrintErrorsBlank;
					break;
				default:
					worksheet_0.PageSetup.PrintErrors = PrintErrorsType.PrintErrorsDisplayed;
					break;
				}
			}
			else if (xmlTextReader_0.LocalName == "Scale")
			{
				worksheet_0.PageSetup.Zoom = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "ValidPrinterInfo")
			{
				flag = true;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "PaperSizeIndex")
			{
				num = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "HorizontalResolution")
			{
				worksheet_0.PageSetup.PrintQuality = int.Parse(xmlTextReader_0.ReadElementString());
			}
			else if (xmlTextReader_0.LocalName == "Gridlines")
			{
				worksheet_0.PageSetup.PrintGridlines = true;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "RowColHeadings")
			{
				worksheet_0.PageSetup.PrintHeadings = true;
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (flag)
		{
			int num2 = num;
			if (num2 != -1 && num2 != 119)
			{
				worksheet_0.PageSetup.PaperSize = (PaperSizeType)num;
			}
			else
			{
				worksheet_0.PageSetup.PaperSize = PaperSizeType.PaperLetter;
			}
		}
	}

	private void method_29(XmlTextReader xmlTextReader_0, Worksheet worksheet_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		Validation validation = worksheet_0.Validations[worksheet_0.Validations.Add()];
		string string_ = null;
		string string_2 = null;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			if (xmlTextReader_0.NodeType == XmlNodeType.Comment)
			{
				xmlTextReader_0.Skip();
				continue;
			}
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Range")
			{
				string text = xmlTextReader_0.ReadElementString();
				ArrayList arrayList = new ArrayList();
				if (text != null && text.Length > 0)
				{
					Class1631.smethod_12(text, arrayList);
				}
				for (int i = 0; i < arrayList.Count; i++)
				{
					validation.AreaList.Add((CellArea)arrayList[i]);
				}
			}
			else if (xmlTextReader_0.LocalName == "Type")
			{
				string text2 = xmlTextReader_0.ReadElementString();
				string key;
				if ((key = text2) == null)
				{
					continue;
				}
				if (Class1742.dictionary_46 == null)
				{
					Class1742.dictionary_46 = new Dictionary<string, int>(8)
					{
						{ "Custom", 0 },
						{ "Date", 1 },
						{ "Decimal", 2 },
						{ "List", 3 },
						{ "TextLength", 4 },
						{ "Time", 5 },
						{ "Whole", 6 },
						{ "AnyValue", 7 }
					};
				}
				if (Class1742.dictionary_46.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
						validation.Type = Aspose.Cells.ValidationType.Custom;
						break;
					case 1:
						validation.Type = Aspose.Cells.ValidationType.Date;
						break;
					case 2:
						validation.Type = Aspose.Cells.ValidationType.Decimal;
						break;
					case 3:
						validation.Type = Aspose.Cells.ValidationType.List;
						break;
					case 4:
						validation.Type = Aspose.Cells.ValidationType.TextLength;
						break;
					case 5:
						validation.Type = Aspose.Cells.ValidationType.Time;
						break;
					case 6:
						validation.Type = Aspose.Cells.ValidationType.WholeNumber;
						break;
					case 7:
						validation.Type = Aspose.Cells.ValidationType.AnyValue;
						break;
					}
				}
			}
			else if (xmlTextReader_0.LocalName == "CellRangeList")
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Qualifier")
			{
				string text2 = xmlTextReader_0.ReadElementString();
				string key2;
				if ((key2 = text2) == null)
				{
					continue;
				}
				if (Class1742.dictionary_47 == null)
				{
					Class1742.dictionary_47 = new Dictionary<string, int>(8)
					{
						{ "Between", 0 },
						{ "NotBetween", 1 },
						{ "Equal", 2 },
						{ "NotEqual", 3 },
						{ "Greater", 4 },
						{ "Less", 5 },
						{ "GreaterOrEqual", 6 },
						{ "LessOrEqual", 7 }
					};
				}
				if (Class1742.dictionary_47.TryGetValue(key2, out var value2))
				{
					switch (value2)
					{
					case 0:
						validation.Operator = OperatorType.Between;
						break;
					case 1:
						validation.Operator = OperatorType.NotBetween;
						break;
					case 2:
						validation.Operator = OperatorType.Equal;
						break;
					case 3:
						validation.Operator = OperatorType.NotEqual;
						break;
					case 4:
						validation.Operator = OperatorType.GreaterThan;
						break;
					case 5:
						validation.Operator = OperatorType.LessThan;
						break;
					case 6:
						validation.Operator = OperatorType.GreaterOrEqual;
						break;
					case 7:
						validation.Operator = OperatorType.LessOrEqual;
						break;
					}
				}
			}
			else if (xmlTextReader_0.LocalName == "UseBlank")
			{
				validation.IgnoreBlank = false;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "Min")
			{
				if (validation.Operator == OperatorType.None)
				{
					validation.Operator = OperatorType.Between;
				}
				string text2 = xmlTextReader_0.ReadElementString();
				if (validation.AreaList.Count > 0)
				{
					CellArea cellArea = (CellArea)validation.AreaList[0];
					string_ = "=" + Class1619.smethod_10(text2, cellArea.StartRow, cellArea.StartColumn);
				}
				else
				{
					string_ = "=" + Class1619.smethod_10(text2, 0, 0);
				}
			}
			else if (xmlTextReader_0.LocalName == "Max")
			{
				if (validation.Operator == OperatorType.None)
				{
					validation.Operator = OperatorType.Between;
				}
				string text2 = xmlTextReader_0.ReadElementString();
				if (validation.AreaList.Count > 0)
				{
					CellArea cellArea2 = (CellArea)validation.AreaList[0];
					string_2 = "=" + Class1619.smethod_10(text2, cellArea2.StartRow, cellArea2.StartColumn);
				}
				else
				{
					string_2 = "=" + Class1619.smethod_10(text2, 0, 0);
				}
			}
			else if (xmlTextReader_0.LocalName == "Value")
			{
				string text2 = xmlTextReader_0.ReadElementString();
				if (validation.AreaList.Count > 0)
				{
					CellArea cellArea3 = (CellArea)validation.AreaList[0];
					string_ = "=" + Class1619.smethod_10(text2, cellArea3.StartRow, cellArea3.StartColumn);
				}
				else
				{
					string_ = "=" + Class1619.smethod_10(text2, 0, 0);
				}
			}
			else if (xmlTextReader_0.LocalName == "ComboHide")
			{
				validation.InCellDropDown = false;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "IMEMode")
			{
				switch (xmlTextReader_0.ReadElementString())
				{
				case "2":
					validation.method_6(Enum228.const_2);
					break;
				case "1":
					validation.method_6(Enum228.const_1);
					break;
				case "0":
					validation.method_6(Enum228.const_0);
					break;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "InputHide")
			{
				validation.ShowInput = false;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "InputTitle")
			{
				validation.InputTitle = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "InputMessage")
			{
				validation.InputMessage = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "ErrorHide")
			{
				validation.ShowError = false;
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "ErrorStyle")
			{
				switch (xmlTextReader_0.ReadElementString())
				{
				case "Warn":
					validation.AlertStyle = ValidationAlertType.Warning;
					break;
				case "Info":
					validation.AlertStyle = ValidationAlertType.Information;
					break;
				case "Stop":
					validation.AlertStyle = ValidationAlertType.Stop;
					break;
				}
			}
			else if (xmlTextReader_0.LocalName == "ErrorMessage")
			{
				validation.ErrorMessage = xmlTextReader_0.ReadElementString();
			}
			else if (xmlTextReader_0.LocalName == "ErrorTitle")
			{
				validation.ErrorTitle = xmlTextReader_0.ReadElementString();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		validation.method_13(string_, string_2);
		xmlTextReader_0.ReadEndElement();
	}

	private Color method_30(Color color_0)
	{
		if (workbook_0.IsColorInPalette(color_0))
		{
			return color_0;
		}
		if (int_0 < 0)
		{
			int_0 = 55;
		}
		workbook_0.ChangePalette(color_0, int_0--);
		return color_0;
	}

	private void method_31(Cell cell_0, ArrayList arrayList_0, WorksheetCollection worksheetCollection_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1372 @class = (Class1372)arrayList_0[i];
			if (@class.string_0 != null && !(@class.string_0 == ""))
			{
				FontSetting fontSetting = new FontSetting(stringBuilder.Length, @class.string_0.Length, worksheetCollection_0, bool_1: false);
				stringBuilder.Append(@class.string_0);
				fontSetting.method_3(@class.font_0);
				arrayList.Add(fontSetting);
			}
		}
		if (cell_0.IsFormula)
		{
			cell_0.method_66(stringBuilder.ToString(), 0);
		}
		else
		{
			cell_0.method_67(stringBuilder.ToString(), arrayList);
		}
	}

	private void method_32(Comment comment_0, ArrayList arrayList_0, WorksheetCollection worksheetCollection_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1372 @class = (Class1372)arrayList_0[i];
			if (@class.string_0 != null && !(@class.string_0 == ""))
			{
				FontSetting fontSetting = new FontSetting(stringBuilder.Length, @class.string_0.Length, worksheetCollection_0, bool_1: false);
				stringBuilder.Append(@class.string_0);
				fontSetting.method_3(@class.font_0);
				arrayList.Add(fontSetting);
			}
		}
		comment_0.method_2().Text = stringBuilder.ToString();
		comment_0.method_2().method_13(arrayList);
	}

	private void method_33(XmlTextReader xmlTextReader_0, ArrayList arrayList_0, Aspose.Cells.Font font_0, Aspose.Cells.Font font_1, WorksheetCollection worksheetCollection_0, bool bool_0)
	{
		if (!bool_0)
		{
			if (xmlTextReader_0.IsEmptyElement)
			{
				xmlTextReader_0.Skip();
				return;
			}
			xmlTextReader_0.Read();
		}
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			if (xmlTextReader_0.NodeType == XmlNodeType.Whitespace)
			{
				xmlTextReader_0.Skip();
				continue;
			}
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				if (xmlTextReader_0.NodeType == XmlNodeType.Text)
				{
					Class1372 @class = new Class1372();
					@class.string_0 = xmlTextReader_0.Value;
					@class.font_0 = new Aspose.Cells.Font(worksheetCollection_0, null, bool_0: false);
					@class.font_0.Copy(font_1);
					arrayList_0.Add(@class);
				}
				xmlTextReader_0.Skip();
				continue;
			}
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null)
			{
				if (Class1742.dictionary_48 == null)
				{
					Class1742.dictionary_48 = new Dictionary<string, int>(7)
					{
						{ "U", 0 },
						{ "I", 1 },
						{ "B", 2 },
						{ "S", 3 },
						{ "Sub", 4 },
						{ "Sup", 5 },
						{ "Font", 6 }
					};
				}
				if (Class1742.dictionary_48.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
					{
						font_1.Underline = FontUnderlineType.Single;
						string attribute = xmlTextReader_0.GetAttribute("html:Style");
						if (attribute == null || attribute.Length <= 14)
						{
							break;
						}
						attribute = attribute.Substring(15);
						if (attribute != null)
						{
							switch (attribute)
							{
							case "double-accounting":
								font_1.Underline = FontUnderlineType.DoubleAccounting;
								break;
							case "single-accounting":
								font_1.Underline = FontUnderlineType.Accounting;
								break;
							case "double":
								font_1.Underline = FontUnderlineType.Double;
								break;
							}
						}
						break;
					}
					case 1:
						font_1.IsItalic = true;
						break;
					case 2:
						font_1.IsBold = true;
						break;
					case 3:
						font_1.IsStrikeout = true;
						break;
					case 4:
						font_1.IsSuperscript = true;
						break;
					case 5:
						font_1.IsSuperscript = true;
						break;
					case 6:
						if (!xmlTextReader_0.HasAttributes)
						{
							break;
						}
						while (xmlTextReader_0.MoveToNextAttribute())
						{
							switch (xmlTextReader_0.LocalName)
							{
							case "Size":
								font_1.DoubleSize = Class1618.smethod_85(xmlTextReader_0.Value);
								break;
							case "Color":
								font_1.Color = ColorTranslator.FromHtml(xmlTextReader_0.Value);
								break;
							case "Face":
								font_1.method_13(xmlTextReader_0.Value);
								break;
							}
						}
						xmlTextReader_0.MoveToElement();
						break;
					}
				}
			}
			method_33(xmlTextReader_0, arrayList_0, font_0, font_1, worksheetCollection_0, bool_0: false);
		}
		string localName2;
		if ((localName2 = xmlTextReader_0.LocalName) != null)
		{
			if (Class1742.dictionary_49 == null)
			{
				Class1742.dictionary_49 = new Dictionary<string, int>(7)
				{
					{ "U", 0 },
					{ "I", 1 },
					{ "B", 2 },
					{ "S", 3 },
					{ "Sub", 4 },
					{ "Sup", 5 },
					{ "Font", 6 }
				};
			}
			if (Class1742.dictionary_49.TryGetValue(localName2, out var value2))
			{
				switch (value2)
				{
				case 0:
					font_1.Underline = FontUnderlineType.None;
					break;
				case 1:
					font_1.IsItalic = false;
					break;
				case 2:
					font_1.IsBold = false;
					break;
				case 3:
					font_1.IsStrikeout = false;
					break;
				case 4:
					font_1.IsSuperscript = false;
					break;
				case 5:
					font_1.IsSuperscript = false;
					break;
				case 6:
					font_1.method_13(font_0.Name);
					font_1.Color = font_0.Color;
					font_1.Size = font_0.Size;
					break;
				}
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_34(XmlTextReader xmlTextReader_0, StringBuilder stringBuilder_0, bool bool_0)
	{
		if (!bool_0)
		{
			if (xmlTextReader_0.IsEmptyElement)
			{
				xmlTextReader_0.Skip();
				return;
			}
			xmlTextReader_0.Read();
		}
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				stringBuilder_0.Append(xmlTextReader_0.Value);
				xmlTextReader_0.Skip();
			}
			else
			{
				method_34(xmlTextReader_0, stringBuilder_0, bool_0: false);
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private string method_35(string string_6, int int_1)
	{
		throw new CellsException(ExceptionType.InvalidData, "Line " + int_1 + ": " + string_6 + " in the SpreadsheetML file.");
	}

	private void method_36(int int_1, string string_6)
	{
		throw new CellsException(ExceptionType.InvalidData, "Line " + int_1 + ": Invalid tag \"" + string_6 + "\" in the SpreadsheetML file.");
	}
}
