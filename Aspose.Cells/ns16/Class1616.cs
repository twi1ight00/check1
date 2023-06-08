using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Markup;
using ns12;
using ns22;
using ns29;

namespace ns16;

internal class Class1616
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private int int_0;

	private Class746 class746_0;

	internal Class1616(Class1547 class1547_1, Class746 class746_1)
	{
		class1547_0 = class1547_1;
		class746_0 = class746_1;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_15(xmlTextReader_0);
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
			else if (xmlTextReader_0.LocalName == "bookViews" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_10(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "sheets" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_11(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "externalReferences" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "definedNames" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_13(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "workbookPr" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_9(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "fileVersion" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_6(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "fileSharing" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_5(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "pivotCaches" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_8(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "workbookProtection" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_3(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "calcPr" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_2(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "customWorkbookViews" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				class1547_0.workbook_0.class1558_0.class1364_0.string_5 = xmlTextReader_0.ReadOuterXml();
			}
			else if (xmlTextReader_0.LocalName == "extLst")
			{
				class1547_0.workbook_0.class1558_0.class1364_0.string_6 = xmlTextReader_0.ReadOuterXml();
			}
			else if (xmlTextReader_0.LocalName == "smartTagPr")
			{
				method_0(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "smartTagTypes")
			{
				method_1(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		class1547_0.workbook_0.Worksheets.ActiveSheetIndex = int_0;
	}

	[Attribute0(true)]
	private void method_0(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			Workbook workbook_ = class1547_0.workbook_0;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "show":
					switch (xmlTextReader_0.Value)
					{
					case "noIndicator":
						workbook_.Settings.method_9().ShowType = SmartTagShowType.NoSmartTagIndicator;
						break;
					case "none":
						workbook_.Settings.method_9().ShowType = SmartTagShowType.None;
						break;
					case "all":
						workbook_.Settings.method_9().ShowType = SmartTagShowType.All;
						break;
					}
					break;
				case "embed":
					if (xmlTextReader_0.Value == "1")
					{
						workbook_.Settings.method_9().EmbedSmartTags = true;
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_1(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "smartTagType" && xmlTextReader_0.HasAttributes)
				{
					string text = null;
					string text2 = null;
					string string_ = null;
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						switch (xmlTextReader_0.LocalName)
						{
						case "url":
							string_ = xmlTextReader_0.Value;
							break;
						case "name":
							text2 = xmlTextReader_0.Value;
							break;
						case "namespaceUri":
							text = xmlTextReader_0.Value;
							break;
						}
					}
					xmlTextReader_0.MoveToElement();
					if (text != null && text2 != null)
					{
						class1547_0.workbook_0.Worksheets.method_92().Add(text, text2, string_);
					}
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
	private void method_2(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			WorksheetCollection worksheets = class1547_0.workbook_0.Worksheets;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "calcMode")
				{
					class1547_0.workbook_0.Settings.CalcMode = Class1618.smethod_195(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "fullPrecision")
				{
					worksheets.Workbook.Settings.PrecisionAsDisplayed = !Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "calcOnSave")
				{
					class1547_0.workbook_0.Settings.RecalculateBeforeSave = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "fullCalcOnLoad")
				{
					class1547_0.workbook_0.Settings.ReCalculateOnOpen = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "iterate")
				{
					class1547_0.workbook_0.Settings.Iteration = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "iterateCount")
				{
					class1547_0.workbook_0.Settings.MaxIteration = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "iterateDelta")
				{
					class1547_0.workbook_0.Settings.MaxChange = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "refMode")
				{
					class1547_0.workbook_0.Settings.method_2(xmlTextReader_0.Value == "R1C1");
				}
				else if (xmlTextReader_0.LocalName == "calcId")
				{
					class1547_0.workbook_0.Settings.CalculationId = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	private void method_3(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			WorksheetCollection worksheets = class1547_0.workbook_0.Worksheets;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "workbookPassword")
				{
					worksheets.method_82(ushort.Parse(xmlTextReader_0.Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
				}
				else if (xmlTextReader_0.LocalName == "lockStructure" && xmlTextReader_0.Value == "1")
				{
					worksheets.method_80(bool_4: true);
				}
				else if (xmlTextReader_0.LocalName == "lockWindows" && xmlTextReader_0.Value == "1")
				{
					worksheets.method_78(bool_4: true);
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	internal void method_4(XmlTextReader xmlTextReader_0)
	{
		method_15(xmlTextReader_0);
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
				if (xmlTextReader_0.NodeType == XmlNodeType.EndElement)
				{
					break;
				}
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "externalReferences" && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				method_7(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		class1547_0.workbook_0.Worksheets.ActiveSheetIndex = int_0;
	}

	[Attribute0(true)]
	private void method_5(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "readOnlyRecommended")
				{
					if (xmlTextReader_0.Value == "1")
					{
						class1547_0.workbook_0.Settings.RecommendReadOnly = true;
					}
				}
				else if (xmlTextReader_0.LocalName == "reservationPassword" && xmlTextReader_0.Value != "0")
				{
					class1547_0.workbook_0.Settings.method_5(Convert.ToUInt16(xmlTextReader_0.Value, 16));
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_6(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			Class1551 @class = new Class1551(bool_0: false);
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "appName")
				{
					@class.string_0 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "lastEdited")
				{
					@class.string_1 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "lowestEdited")
				{
					@class.string_2 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "rupBuild")
				{
					@class.string_3 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "codeName")
				{
					@class.string_4 = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
			class1547_0.workbook_0.Settings.method_22(@class);
		}
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_7(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "externalReference")
				{
					Class1555 @class = new Class1555();
					string attribute = xmlTextReader_0.GetAttribute("id", string_1);
					Hashtable hashtable = class1547_0.method_4();
					if (!hashtable.ContainsKey(attribute))
					{
						throw new CellsException(ExceptionType.InvalidData, "externalReference rid " + attribute + " not found in workbook rels file");
					}
					Class1564 class2 = (Class1564)hashtable[attribute];
					@class.string_0 = class2.string_3;
					class1547_0.arrayList_1.Add(@class);
					xmlTextReader_0.Skip();
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
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "pivotCache")
				{
					Class1562 @class = new Class1562();
					@class.string_0 = xmlTextReader_0.GetAttribute("cacheId");
					string attribute = xmlTextReader_0.GetAttribute("id", string_1);
					Hashtable hashtable = class1547_0.method_3();
					if (!hashtable.ContainsKey(attribute))
					{
						throw new CellsException(ExceptionType.InvalidData, "pivotCache rid " + attribute + " not found in workbook rels file");
					}
					@class.string_2 = attribute;
					class1547_0.arrayList_0.Add(@class);
					xmlTextReader_0.Skip();
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
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_9(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			Class1364 class1364_ = class1547_0.workbook_0.class1558_0.class1364_0;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "codeName")
				{
					class1547_0.workbook_0.Worksheets.method_17(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "defaultThemeVersion")
				{
					class1364_.string_0 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "filterPrivacy")
				{
					class1364_.string_1 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "hidePivotFieldList" && xmlTextReader_0.Value == "1")
				{
					class1547_0.workbook_0.Worksheets.HidePivotFieldList = true;
				}
				else if (xmlTextReader_0.LocalName == "refreshAllConnections")
				{
					if (xmlTextReader_0.Value == "1")
					{
						class1547_0.workbook_0.Worksheets.IsRefreshAllConnections = true;
					}
				}
				else if (xmlTextReader_0.LocalName == "updateLinks")
				{
					class1364_.string_3 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "publishItems")
				{
					class1364_.string_4 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "date1904" && xmlTextReader_0.Value == "1")
				{
					class1547_0.workbook_0.Settings.Date1904 = true;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
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
				if (xmlTextReader_0.NodeType == XmlNodeType.EndElement)
				{
					break;
				}
				xmlTextReader_0.Skip();
			}
			else
			{
				if (!(xmlTextReader_0.LocalName == "workbookView") || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					continue;
				}
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						if (xmlTextReader_0.NamespaceURI != "")
						{
							continue;
						}
						if (xmlTextReader_0.LocalName == "activeTab")
						{
							int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
						}
						else if (xmlTextReader_0.LocalName == "firstSheet")
						{
							class1547_0.workbook_0.Worksheets.FirstVisibleTab = Class1618.smethod_87(xmlTextReader_0.Value);
						}
						else if (xmlTextReader_0.LocalName == "showHorizontalScroll" && xmlTextReader_0.Value == "0")
						{
							class1547_0.workbook_0.Settings.IsVScrollBarVisible = false;
						}
						else if (xmlTextReader_0.LocalName == "showVerticalScroll" && xmlTextReader_0.Value == "0")
						{
							class1547_0.workbook_0.Settings.IsVScrollBarVisible = false;
						}
						else if (xmlTextReader_0.LocalName == "showSheetTabs" && xmlTextReader_0.Value == "0")
						{
							class1547_0.workbook_0.Settings.ShowTabs = false;
						}
						else if (xmlTextReader_0.LocalName == "minimized" && xmlTextReader_0.Value == "1")
						{
							class1547_0.workbook_0.Settings.IsMinimized = true;
						}
						else if (xmlTextReader_0.LocalName == "visibility")
						{
							if (xmlTextReader_0.Value == "hidden")
							{
								class1547_0.workbook_0.Settings.IsHidden = true;
							}
							else if (xmlTextReader_0.Value == "veryHidden")
							{
								class1547_0.workbook_0.Settings.IsHidden = true;
							}
						}
						else if (xmlTextReader_0.LocalName == "tabRatio")
						{
							class1547_0.workbook_0.Settings.SheetTabBarWidth = Class1618.smethod_87(xmlTextReader_0.Value);
						}
						else if (xmlTextReader_0.LocalName == "windowHeight")
						{
							class1547_0.workbook_0.Settings.method_19(Class1618.smethod_87(xmlTextReader_0.Value));
						}
						else if (xmlTextReader_0.LocalName == "windowWidth")
						{
							class1547_0.workbook_0.Settings.method_17(Class1618.smethod_87(xmlTextReader_0.Value));
						}
						else if (xmlTextReader_0.LocalName == "xWindow")
						{
							class1547_0.workbook_0.Settings.method_13(Class1618.smethod_87(xmlTextReader_0.Value));
						}
						else if (xmlTextReader_0.LocalName == "yWindow")
						{
							class1547_0.workbook_0.Settings.method_15(Class1618.smethod_87(xmlTextReader_0.Value));
						}
					}
					xmlTextReader_0.MoveToElement();
				}
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_11(XmlTextReader xmlTextReader_0)
	{
		class1547_0.workbook_0.Worksheets.Clear();
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1129.smethod_1();
		int num = 0;
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
				if (!(xmlTextReader_0.LocalName == "sheet") || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					continue;
				}
				if (xmlTextReader_0.HasAttributes)
				{
					string text = null;
					string text2 = null;
					string string_ = null;
					string text3 = null;
					string text4 = null;
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						if (xmlTextReader_0.LocalName == "name" && xmlTextReader_0.NamespaceURI == "")
						{
							text = xmlTextReader_0.Value;
						}
						else if (xmlTextReader_0.LocalName == "sheetId" && xmlTextReader_0.NamespaceURI == "")
						{
							Class1618.smethod_87(xmlTextReader_0.Value);
							text2 = xmlTextReader_0.Value;
						}
						else if (xmlTextReader_0.LocalName == "id" && object.ReferenceEquals(string_1, xmlTextReader_0.NamespaceURI))
						{
							string_ = xmlTextReader_0.Value;
						}
						else if (xmlTextReader_0.LocalName == "type" && xmlTextReader_0.NamespaceURI == "")
						{
							text3 = xmlTextReader_0.Value;
						}
						else if (xmlTextReader_0.LocalName == "state")
						{
							text4 = xmlTextReader_0.Value;
						}
					}
					if (text3 == null || text3 == "chartsheet")
					{
						if (text == null || text.Length == 0 || text2 == null)
						{
							throw new CellsException(ExceptionType.InvalidData, "invalid sheet attributes data");
						}
						Worksheet worksheet = class1547_0.workbook_0.Worksheets[class1547_0.workbook_0.Worksheets.Add()];
						worksheet.method_7(text);
						worksheet.class1557_0 = new Class1557(worksheet);
						worksheet.class1557_0.string_5 = text2;
						switch (text4)
						{
						case "hidden":
							worksheet.method_28(bool_1: false, bool_2: false);
							break;
						case "veryHidden":
							worksheet.method_28(bool_1: false, bool_2: true);
							break;
						}
						class1547_0.method_0(worksheet, num, text2, string_);
					}
					xmlTextReader_0.MoveToElement();
					num++;
				}
				xmlTextReader_0.Skip();
			}
		}
		class1547_0.workbook_0.Worksheets.method_32().method_0(class1547_0.workbook_0.Worksheets.method_36());
		xmlTextReader_0.ReadEndElement();
	}

	private string method_12(string string_2)
	{
		int num = 0;
		if (string_2.IndexOf(',') != -1)
		{
			string[] array = Class1660.smethod_17(string_2);
			if (array != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < array.Length; i++)
				{
					num = array[i].LastIndexOf('!');
					stringBuilder.Append(array[i].Substring(num + 1));
					if (i != array.Length - 1)
					{
						stringBuilder.Append(',');
					}
				}
				return stringBuilder.ToString();
			}
		}
		num = string_2.LastIndexOf('!');
		return string_2.Substring(num + 1);
	}

	private void method_13(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		WorksheetCollection worksheets = class1547_0.workbook_0.Worksheets;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else
			{
				if (!(xmlTextReader_0.LocalName == "definedName") || !object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
				{
					continue;
				}
				int num = -1;
				bool isHidden = false;
				string text = null;
				string text2 = null;
				string text3 = null;
				string text4 = null;
				string comment = null;
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						if (xmlTextReader_0.LocalName == "name" && xmlTextReader_0.NamespaceURI == "")
						{
							text = xmlTextReader_0.Value;
						}
						else if (xmlTextReader_0.LocalName == "localSheetId" && xmlTextReader_0.NamespaceURI == "")
						{
							num = Class1618.smethod_87(xmlTextReader_0.Value);
						}
						else if (xmlTextReader_0.LocalName == "hidden" && xmlTextReader_0.NamespaceURI == "")
						{
							isHidden = ((xmlTextReader_0.Value == "1") ? true : false);
						}
						else if (xmlTextReader_0.LocalName == "publishToServer")
						{
							text3 = xmlTextReader_0.Value;
						}
						else if (xmlTextReader_0.LocalName == "workbookParameter")
						{
							text4 = xmlTextReader_0.Value;
						}
						else if (xmlTextReader_0.LocalName == "comment")
						{
							comment = xmlTextReader_0.Value;
						}
					}
					xmlTextReader_0.MoveToElement();
				}
				text2 = xmlTextReader_0.ReadElementString();
				if (text == null || text2 == null)
				{
					throw new CellsException(ExceptionType.InvalidData, "Invalid name data");
				}
				if (text.ToUpper().Equals("_xlnm.Print_Area".ToUpper()) && class1547_0.method_8().ContainsKey(num))
				{
					if (text2.ToUpper().IndexOf("#REF") == -1)
					{
						Worksheet worksheet = class1547_0.method_1(num);
						text2 = method_12(text2);
						worksheet.PageSetup.PrintArea = text2;
					}
					continue;
				}
				if (text.ToUpper().Equals("_xlnm.Print_Titles".ToUpper()) && class1547_0.method_8().ContainsKey(num))
				{
					if (text2.ToUpper().IndexOf("#REF") != -1)
					{
						continue;
					}
					Worksheet worksheet2 = class1547_0.method_1(num);
					int num2 = text2.IndexOf(',');
					if (num2 != -1)
					{
						string text5 = text2.Substring(0, num2);
						int startIndex = text5.LastIndexOf('!') + 1;
						worksheet2.PageSetup.PrintTitleColumns = text5.Substring(startIndex);
						text5 = text2.Substring(num2 + 1);
						startIndex = text5.LastIndexOf('!') + 1;
						worksheet2.PageSetup.PrintTitleRows = text5.Substring(startIndex);
						continue;
					}
					int startIndex2 = text2.LastIndexOf('!') + 1;
					string text6 = text2.Substring(startIndex2);
					switch (method_14(text6))
					{
					case 1:
						worksheet2.PageSetup.PrintTitleRows = text6;
						break;
					case 2:
						worksheet2.PageSetup.PrintTitleColumns = text6;
						break;
					}
					continue;
				}
				string text7 = text.ToUpper();
				bool flag;
				if (flag = text7.StartsWith("_XLNM."))
				{
					text = text.Substring(6);
					text7 = text.ToUpper();
				}
				if (num != -1)
				{
					num = class1547_0.method_1(num).Index;
				}
				int index = worksheets.Names.method_0(num, text);
				Name name = worksheets.Names[index];
				name.Comment = comment;
				if (flag)
				{
					name.method_15(text7);
				}
				name.string_6 = "=" + text2;
				name.IsHidden = isHidden;
				if (text3 != null || text4 != null)
				{
					name.class1365_0 = new Class1365();
					name.class1365_0.string_0 = text4;
					name.class1365_0.string_1 = text3;
				}
			}
		}
		worksheets.Names.method_4(bool_0: false);
		xmlTextReader_0.ReadEndElement();
	}

	private int method_14(string string_2)
	{
		bool flag = false;
		bool flag2 = false;
		int num = 0;
		while (true)
		{
			if (num < string_2.Length)
			{
				char c = string_2[num];
				char c2 = c;
				if (c2 != '$' && c2 != ':')
				{
					if (char.IsDigit(c))
					{
						flag = true;
					}
					else
					{
						if (!char.IsLetter(c))
						{
							break;
						}
						flag2 = true;
					}
				}
				num++;
				continue;
			}
			if (flag)
			{
				if (flag2)
				{
					return 0;
				}
				return 1;
			}
			if (flag2)
			{
				return 2;
			}
			return 0;
		}
		return 0;
	}

	private void method_15(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.None;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "workbook")
		{
			throw new CellsException(ExceptionType.InvalidData, "workbook root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_0 = nameTable.Add(namespaceURI);
		string_1 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/relationships");
	}
}
