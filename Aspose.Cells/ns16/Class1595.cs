using System.Collections;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Markup;
using ns2;
using ns22;
using ns45;
using ns56;

namespace ns16;

internal class Class1595
{
	private Workbook workbook_0;

	private Class1540 class1540_0;

	internal Class1595(Class1540 class1540_1)
	{
		class1540_0 = class1540_1;
		workbook_0 = class1540_1.workbook_0;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("workbook");
		if (Class1618.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		}
		else
		{
			xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_1);
		}
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		method_13(xmlTextWriter_0);
		method_0(xmlTextWriter_0);
		method_15(xmlTextWriter_0);
		method_14(xmlTextWriter_0);
		method_10(xmlTextWriter_0);
		method_6(xmlTextWriter_0);
		method_16(xmlTextWriter_0);
		method_17(xmlTextWriter_0);
		method_5(xmlTextWriter_0);
		method_1(xmlTextWriter_0);
		method_2(xmlTextWriter_0);
		method_4(xmlTextWriter_0);
		method_12(xmlTextWriter_0);
		method_3(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		if (workbook_0.Settings.IsWriteProtected)
		{
			xmlTextWriter_0.WriteStartElement("fileSharing");
			if (workbook_0.Settings.RecommendReadOnly)
			{
				xmlTextWriter_0.WriteAttributeString("readOnlyRecommended", "1");
			}
			string text = workbook_0.Worksheets.Author;
			if (text == null)
			{
				text = "Aspose";
			}
			xmlTextWriter_0.WriteAttributeString("userName", text);
			xmlTextWriter_0.WriteAttributeString("reservationPassword", Class1025.smethod_4(workbook_0.Settings.method_4()));
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0)
	{
		SmartTagOptions smartTagOptions = workbook_0.Settings.method_10();
		if (smartTagOptions != null)
		{
			xmlTextWriter_0.WriteStartElement("smartTagPr");
			xmlTextWriter_0.WriteAttributeString("embed", smartTagOptions.EmbedSmartTags ? "1" : "0");
			switch (smartTagOptions.ShowType)
			{
			case SmartTagShowType.NoSmartTagIndicator:
				xmlTextWriter_0.WriteAttributeString("show", "noIndicator");
				break;
			case SmartTagShowType.None:
				xmlTextWriter_0.WriteAttributeString("show", "none");
				break;
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0)
	{
		Class1283 @class = workbook_0.Worksheets.method_93();
		if (@class == null || @class.Count == 0)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("smartTagTypes");
		for (int i = 0; i < @class.Count; i++)
		{
			Class1282 class2 = @class[i];
			xmlTextWriter_0.WriteStartElement("smartTagType");
			xmlTextWriter_0.WriteAttributeString("namespaceUri", class2.Uri);
			xmlTextWriter_0.WriteAttributeString("name", class2.Name);
			if (class2.string_2 != null)
			{
				xmlTextWriter_0.WriteAttributeString("url", class2.string_2);
			}
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_3(XmlTextWriter xmlTextWriter_0)
	{
		if (workbook_0.class1558_0 == null || workbook_0.class1558_0.class1364_0 == null || workbook_0.class1558_0.class1364_0.string_6 == null)
		{
			return;
		}
		XmlDocument xmlDocument = Class1188.smethod_1(workbook_0.class1558_0.class1364_0.string_6);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("slicerCache", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
		foreach (XmlNode item in elementsByTagName)
		{
			XmlElement xmlElement_ = (XmlElement)item;
			XmlAttribute xmlAttribute = Class1188.smethod_7(xmlElement_, "id", Class1618.string_2);
			if (xmlAttribute == null)
			{
				continue;
			}
			foreach (object item2 in workbook_0.class1558_0.class1364_0.arrayList_0)
			{
				Class1564 @class = (Class1564)item2;
				if (@class.string_0 == xmlAttribute.Value)
				{
					xmlAttribute.Value = @class.string_1;
					break;
				}
			}
		}
		xmlTextWriter_0.WriteRaw(Class1188.smethod_8(xmlDocument).OuterXml);
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0)
	{
		if (workbook_0.class1558_0 != null && workbook_0.class1558_0.class1364_0 != null && workbook_0.class1558_0.class1364_0.string_5 != null)
		{
			xmlTextWriter_0.WriteRaw(workbook_0.class1558_0.class1364_0.string_5);
		}
	}

	[Attribute0(true)]
	private void method_5(XmlTextWriter xmlTextWriter_0)
	{
		if (class1540_0.bool_2)
		{
			xmlTextWriter_0.WriteStartElement("calcPr");
			xmlTextWriter_0.WriteAttributeString("calcId", "125725");
			xmlTextWriter_0.WriteAttributeString("calcMode", Class1618.smethod_194(CalcModeType.Manual));
			xmlTextWriter_0.WriteAttributeString("calcCompleted", "0");
			xmlTextWriter_0.WriteAttributeString("calcOnSave", "0");
			xmlTextWriter_0.WriteEndElement();
			return;
		}
		xmlTextWriter_0.WriteStartElement("calcPr");
		if (!workbook_0.Settings.ReCalculateOnOpen)
		{
			xmlTextWriter_0.WriteAttributeString("calcId", workbook_0.Settings.CalculationId);
		}
		if (workbook_0.Settings.CalcMode != 0)
		{
			xmlTextWriter_0.WriteAttributeString("calcMode", Class1618.smethod_194(workbook_0.Settings.CalcMode));
		}
		else if (workbook_0.Settings.ReCalculateOnOpen)
		{
			xmlTextWriter_0.WriteAttributeString("fullCalcOnLoad", "1");
		}
		if (workbook_0.Settings.PrecisionAsDisplayed)
		{
			xmlTextWriter_0.WriteAttributeString("fullPrecision", "0");
		}
		if (workbook_0.Settings.CalcMode == CalcModeType.Manual && !workbook_0.Settings.RecalculateBeforeSave)
		{
			xmlTextWriter_0.WriteAttributeString("calcCompleted", "0");
			xmlTextWriter_0.WriteAttributeString("calcOnSave", "0");
		}
		if (workbook_0.Settings.Iteration)
		{
			xmlTextWriter_0.WriteAttributeString("iterate", "1");
			xmlTextWriter_0.WriteAttributeString("iterateCount", workbook_0.Settings.MaxIteration.ToString());
			xmlTextWriter_0.WriteAttributeString("iterateDelta", workbook_0.Settings.MaxChange.ToString());
		}
		if (workbook_0.Settings.method_1())
		{
			xmlTextWriter_0.WriteAttributeString("refMode", "R1C1");
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("sheets");
		int int_ = 0;
		for (int i = 0; i < class1540_0.arrayList_0.Count; i++)
		{
			Class1541 @class = (Class1541)class1540_0.arrayList_0[i];
			xmlTextWriter_0.WriteStartElement("sheet");
			xmlTextWriter_0.WriteAttributeString("name", @class.worksheet_0.Name);
			string value = method_7(ref int_, @class.worksheet_0);
			xmlTextWriter_0.WriteAttributeString("sheetId", value);
			if (!@class.worksheet_0.IsVisible)
			{
				string value2 = "hidden";
				if (@class.worksheet_0.method_29())
				{
					value2 = "veryHidden";
				}
				xmlTextWriter_0.WriteAttributeString("state", value2);
			}
			xmlTextWriter_0.WriteAttributeString("r:id", null, @class.string_1);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private string method_7(ref int int_0, Worksheet worksheet_0)
	{
		if (worksheet_0.class1557_0 != null && (worksheet_0.class1557_0.class1363_0.hashtable_0.Count > 0 || worksheet_0.class1557_0.string_5 != null))
		{
			return worksheet_0.class1557_0.string_5;
		}
		int_0 = method_8(int_0);
		return Class1618.smethod_80(int_0);
	}

	private int method_8(int int_0)
	{
		int i;
		for (i = int_0 + 1; method_9(i); i++)
		{
		}
		return i;
	}

	private bool method_9(int int_0)
	{
		if (workbook_0.class1558_0 == null)
		{
			return false;
		}
		foreach (Worksheet worksheet in workbook_0.Worksheets)
		{
			if (worksheet.class1557_0 != null && (worksheet.class1557_0.class1363_0.hashtable_0.Count > 0 || worksheet.class1557_0.string_5 != null) && worksheet.class1557_0.string_5 == Class1618.smethod_80(int_0))
			{
				return true;
			}
		}
		return false;
	}

	[Attribute0(true)]
	private void method_10(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("bookViews");
		xmlTextWriter_0.WriteStartElement("workbookView");
		if (workbook_0.Settings.IsHidden)
		{
			xmlTextWriter_0.WriteAttributeString("visibility", "hidden");
		}
		if (workbook_0.Settings.IsMinimized)
		{
			xmlTextWriter_0.WriteAttributeString("minimized", "1");
		}
		if (!workbook_0.Settings.IsHScrollBarVisible)
		{
			xmlTextWriter_0.WriteAttributeString("showHorizontalScroll", "0");
		}
		if (!workbook_0.Settings.IsVScrollBarVisible)
		{
			xmlTextWriter_0.WriteAttributeString("showVerticalScroll", "0");
		}
		if (!workbook_0.Settings.ShowTabs)
		{
			xmlTextWriter_0.WriteAttributeString("showSheetTabs", "0");
		}
		xmlTextWriter_0.WriteAttributeString("xWindow", Class1618.smethod_80(workbook_0.Settings.method_12()));
		xmlTextWriter_0.WriteAttributeString("yWindow", Class1618.smethod_80(workbook_0.Settings.method_14()));
		xmlTextWriter_0.WriteAttributeString("windowWidth", Class1618.smethod_80(workbook_0.Settings.method_16()));
		xmlTextWriter_0.WriteAttributeString("windowHeight", Class1618.smethod_80(workbook_0.Settings.method_18()));
		if (workbook_0.Settings.SheetTabBarWidth != 600)
		{
			xmlTextWriter_0.WriteAttributeString("tabRatio", Class1618.smethod_80(workbook_0.Settings.SheetTabBarWidth));
		}
		if (workbook_0.Worksheets.FirstVisibleTab != 0)
		{
			for (int i = 0; i < class1540_0.arrayList_0.Count; i++)
			{
				Class1541 @class = (Class1541)class1540_0.arrayList_0[i];
				if (@class.worksheet_0.SheetIndex == workbook_0.Worksheets.FirstVisibleTab)
				{
					xmlTextWriter_0.WriteAttributeString("firstSheet", Class1618.smethod_80(@class.int_0 - 1));
					break;
				}
			}
		}
		if (workbook_0.Worksheets.ActiveSheetIndex >= 0)
		{
			for (int j = 0; j < class1540_0.arrayList_0.Count; j++)
			{
				Class1541 class2 = (Class1541)class1540_0.arrayList_0[j];
				if (class2.worksheet_0.SheetIndex == workbook_0.Worksheets.ActiveSheetIndex)
				{
					xmlTextWriter_0.WriteAttributeString("activeTab", Class1618.smethod_80(class2.int_0 - 1));
				}
			}
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_11(XmlTextWriter xmlTextWriter_0, string string_0, string string_1)
	{
		xmlTextWriter_0.WriteStartElement("pivotCache");
		xmlTextWriter_0.WriteAttributeString("cacheId", string_0);
		xmlTextWriter_0.WriteAttributeString("r:id", string_1);
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_12(XmlTextWriter xmlTextWriter_0)
	{
		if ((workbook_0.class1558_0 == null || workbook_0.class1558_0.class1364_0.arrayList_1.Count == 0) && class1540_0.hashtable_2 == null)
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("pivotCaches");
		if (workbook_0.class1558_0 != null)
		{
			ArrayList arrayList_ = workbook_0.class1558_0.class1364_0.arrayList_1;
			if (arrayList_.Count > 0)
			{
				for (int i = 0; i < arrayList_.Count; i++)
				{
					Class1562 @class = (Class1562)arrayList_[i];
					method_11(xmlTextWriter_0, @class.string_0, @class.string_2);
				}
			}
		}
		Hashtable hashtable_ = class1540_0.hashtable_2;
		if (hashtable_ != null)
		{
			IEnumerator enumerator = hashtable_.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class1141 class2 = (Class1141)enumerator.Current;
				if (!class2.bool_1)
				{
					Class1562 class3 = (Class1562)hashtable_[class2];
					method_11(xmlTextWriter_0, class3.string_0, class3.string_2);
				}
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextWriter xmlTextWriter_0)
	{
		Class1551 @class = workbook_0.Settings.method_23();
		if (@class == null)
		{
			string data = "<fileVersion appName=\"xl\" lastEdited=\"4\" lowestEdited=\"4\" rupBuild=\"9302\" />";
			xmlTextWriter_0.WriteRaw(data);
		}
		else if (@class != null)
		{
			xmlTextWriter_0.WriteStartElement("fileVersion");
			if (@class.string_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("appName", @class.string_0);
			}
			if (@class.string_1 != null)
			{
				xmlTextWriter_0.WriteAttributeString("lastEdited", @class.string_1);
			}
			if (@class.string_2 != null)
			{
				xmlTextWriter_0.WriteAttributeString("lowestEdited", @class.string_2);
			}
			if (@class.string_3 != null)
			{
				xmlTextWriter_0.WriteAttributeString("rupBuild", @class.string_3);
			}
			if (@class.string_4 != null)
			{
				xmlTextWriter_0.WriteAttributeString("codeName", @class.string_4);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	private void method_14(XmlTextWriter xmlTextWriter_0)
	{
		if (workbook_0.Worksheets.method_79() || workbook_0.Worksheets.method_77())
		{
			xmlTextWriter_0.WriteStartElement("workbookProtection");
			if (workbook_0.Worksheets.method_81() != 0)
			{
				xmlTextWriter_0.WriteAttributeString("workbookPassword", Class1025.smethod_6(workbook_0.Worksheets.method_81()));
			}
			if (workbook_0.Worksheets.method_79())
			{
				xmlTextWriter_0.WriteAttributeString("lockStructure", "1");
			}
			if (workbook_0.Worksheets.method_77())
			{
				xmlTextWriter_0.WriteAttributeString("lockWindows", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_15(XmlTextWriter xmlTextWriter_0)
	{
		string text = null;
		string codeName = workbook_0.Worksheets.CodeName;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		if (workbook_0.class1558_0 != null)
		{
			Class1364 class1364_ = workbook_0.class1558_0.class1364_0;
			text = class1364_.string_0;
			text2 = class1364_.string_1;
			text3 = class1364_.string_3;
			text4 = class1364_.string_4;
		}
		xmlTextWriter_0.WriteStartElement("workbookPr");
		if (workbook_0.Settings.Date1904)
		{
			xmlTextWriter_0.WriteAttributeString("date1904", "1");
		}
		if (text3 != null)
		{
			xmlTextWriter_0.WriteAttributeString("updateLinks", text3);
		}
		if (codeName != null)
		{
			xmlTextWriter_0.WriteAttributeString("codeName", codeName);
		}
		if (text2 != null)
		{
			xmlTextWriter_0.WriteAttributeString("filterPrivacy", text2);
		}
		if (workbook_0.Worksheets.HidePivotFieldList)
		{
			xmlTextWriter_0.WriteAttributeString("hidePivotFieldList", "1");
		}
		if (workbook_0.Worksheets.IsRefreshAllConnections)
		{
			xmlTextWriter_0.WriteAttributeString("refreshAllConnections", "1");
		}
		if (text4 != null)
		{
			xmlTextWriter_0.WriteAttributeString("publishItems", text4);
		}
		if (text != null && !workbook_0.method_18())
		{
			xmlTextWriter_0.WriteAttributeString("defaultThemeVersion", text);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_16(XmlTextWriter xmlTextWriter_0)
	{
		Class1303 @class = workbook_0.Worksheets.method_39();
		if (!class1540_0.method_38())
		{
			return;
		}
		xmlTextWriter_0.WriteStartElement("externalReferences");
		for (int i = 0; i < @class.Count; i++)
		{
			Class1718 class2 = @class[i];
			string text = class2.method_25();
			if (text != null && text.Trim().Length != 0 && (class2.Type == Enum194.const_3 || class2.Type == Enum194.const_0 || class2.Type == Enum194.const_4))
			{
				xmlTextWriter_0.WriteStartElement("externalReference");
				string value = (string)class1540_0.hashtable_4[class2];
				xmlTextWriter_0.WriteAttributeString("r:id", null, value);
				xmlTextWriter_0.WriteEndElement();
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_17(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("definedNames");
		foreach (Name name in workbook_0.Worksheets.Names)
		{
			if (name.Type == Enum184.const_1)
			{
				continue;
			}
			string refersTo = name.RefersTo;
			if (refersTo == null || refersTo.Length <= 1)
			{
				continue;
			}
			refersTo = refersTo.Substring(1);
			if (refersTo.Equals("{}"))
			{
				refersTo = "#REF!";
			}
			if (name.Type == Enum184.const_0 && refersTo.StartsWith("#REF!"))
			{
				continue;
			}
			int int_ = -1;
			if (name.SheetIndex != 0)
			{
				for (int i = 0; i < class1540_0.arrayList_0.Count; i++)
				{
					Class1541 @class = (Class1541)class1540_0.arrayList_0[i];
					if (name.SheetIndex - 1 == @class.worksheet_0.SheetIndex)
					{
						int_ = @class.int_0 - 1;
						break;
					}
				}
			}
			string text = name.Text;
			if (string.Compare(text, "_FilterDatabase", ignoreCase: true) == 0)
			{
				text = "_xlnm._FilterDatabase";
			}
			else if (string.Compare(text, "Print_Area", ignoreCase: true) == 0)
			{
				text = "_xlnm.Print_Area";
			}
			else if (string.Compare(text, "Print_Titles", ignoreCase: true) == 0)
			{
				text = "_xlnm.Print_Titles";
			}
			if (name.class1365_0 == null)
			{
				method_19(xmlTextWriter_0, text, int_, refersTo, name.IsHidden, null, null, name.Comment);
			}
			else
			{
				method_19(xmlTextWriter_0, text, int_, refersTo, name.IsHidden, name.class1365_0.string_1, name.class1365_0.string_0, name.Comment);
			}
		}
		method_18(xmlTextWriter_0);
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_18(XmlTextWriter xmlTextWriter_0)
	{
		if (workbook_0.class1558_0 == null || workbook_0.class1558_0.class1364_0.arrayList_3.Count == 0)
		{
			return;
		}
		ArrayList arrayList_ = workbook_0.class1558_0.class1364_0.arrayList_3;
		for (int i = 0; i < arrayList_.Count; i++)
		{
			int int_ = -1;
			Class1560 @class = (Class1560)arrayList_[i];
			if (@class.worksheet_0 != null)
			{
				for (int j = 0; j < class1540_0.arrayList_0.Count; j++)
				{
					Class1541 class2 = (Class1541)class1540_0.arrayList_0[j];
					if (@class.worksheet_0 == class2.worksheet_0)
					{
						int_ = class2.int_0 - 1;
						break;
					}
				}
			}
			method_19(xmlTextWriter_0, @class.string_0, int_, @class.string_1, bool_0: false, @class.string_3, @class.string_2, null);
		}
	}

	[Attribute0(true)]
	private void method_19(XmlTextWriter xmlTextWriter_0, string string_0, int int_0, string string_1, bool bool_0, string string_2, string string_3, string string_4)
	{
		xmlTextWriter_0.WriteStartElement("definedName");
		xmlTextWriter_0.WriteAttributeString("name", string_0);
		if (int_0 != -1)
		{
			xmlTextWriter_0.WriteAttributeString("localSheetId", Class1618.smethod_80(int_0));
		}
		if (bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("hidden", "1");
		}
		if (string_2 != null)
		{
			xmlTextWriter_0.WriteAttributeString("publishToServer", string_2);
		}
		if (string_3 != null)
		{
			xmlTextWriter_0.WriteAttributeString("workbookParameter", string_3);
		}
		if (string_4 != null)
		{
			xmlTextWriter_0.WriteAttributeString("comment", string_4);
		}
		xmlTextWriter_0.WriteString(string_1);
		xmlTextWriter_0.WriteEndElement();
	}
}
