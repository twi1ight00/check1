using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Markup;
using Aspose.Cells.Pivot;
using ns1;
using ns2;
using ns22;
using ns25;
using ns27;

namespace ns16;

internal class Class1617
{
	private Class1547 class1547_0;

	private string string_0;

	private string string_1;

	private Worksheet worksheet_0;

	private Class1548 class1548_0;

	private Hashtable hashtable_0;

	private Class1301 class1301_0;

	private bool bool_0;

	private bool bool_1;

	private Class1610 class1610_0;

	internal Class1617(Class1547 class1547_1, Class1548 class1548_1)
	{
		class1547_0 = class1547_1;
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
		hashtable_0 = new Hashtable();
		class1301_0 = class1547_0.workbook_0.Worksheets.class1301_0;
		bool_0 = !class1547_0.workbook_0.Settings.bool_22;
		bool_1 = class1547_1.workbook_0.Settings.bool_23;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		method_49(xmlTextReader_0);
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
				continue;
			}
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null)
			{
				if (Class1742.dictionary_140 == null)
				{
					Class1742.dictionary_140 = new Dictionary<string, int>(30)
					{
						{ "sheetViews", 0 },
						{ "sheetFormatPr", 1 },
						{ "cols", 2 },
						{ "sheetData", 3 },
						{ "mergeCells", 4 },
						{ "dataValidations", 5 },
						{ "hyperlinks", 6 },
						{ "printOptions", 7 },
						{ "pageMargins", 8 },
						{ "pageSetup", 9 },
						{ "headerFooter", 10 },
						{ "ignoredErrors", 11 },
						{ "smartTags", 12 },
						{ "rowBreaks", 13 },
						{ "colBreaks", 14 },
						{ "legacyDrawing", 15 },
						{ "drawing", 16 },
						{ "conditionalFormatting", 17 },
						{ "autoFilter", 18 },
						{ "sheetProtection", 19 },
						{ "sheetPr", 20 },
						{ "controls", 21 },
						{ "oleObjects", 22 },
						{ "legacyDrawingHF", 23 },
						{ "picture", 24 },
						{ "customProperties", 25 },
						{ "customSheetViews", 26 },
						{ "extLst", 27 },
						{ "protectedRanges", 28 },
						{ "AlternateContent", 29 }
					};
				}
				if (Class1742.dictionary_140.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
						method_46(xmlTextReader_0);
						continue;
					case 1:
						method_22(xmlTextReader_0);
						continue;
					case 2:
						method_43(xmlTextReader_0);
						continue;
					case 3:
						method_38(xmlTextReader_0);
						continue;
					case 4:
						method_37(xmlTextReader_0);
						continue;
					case 5:
						method_26(xmlTextReader_0, bool_2: false);
						continue;
					case 6:
						method_24(xmlTextReader_0);
						continue;
					case 7:
						method_36(xmlTextReader_0);
						continue;
					case 8:
						method_35(xmlTextReader_0);
						continue;
					case 9:
						method_32(xmlTextReader_0);
						continue;
					case 10:
						method_31(xmlTextReader_0);
						continue;
					case 11:
						method_1(xmlTextReader_0);
						continue;
					case 12:
						method_2(xmlTextReader_0);
						continue;
					case 13:
						method_29(xmlTextReader_0, bool_2: true);
						continue;
					case 14:
						method_29(xmlTextReader_0, bool_2: false);
						continue;
					case 15:
						method_23(xmlTextReader_0);
						continue;
					case 16:
						method_17(xmlTextReader_0);
						continue;
					case 17:
						method_50(xmlTextReader_0, bool_2: false);
						continue;
					case 18:
						smethod_3(xmlTextReader_0, class1548_0.worksheet_0.AutoFilter);
						continue;
					case 19:
						method_16(xmlTextReader_0);
						continue;
					case 20:
						method_19(xmlTextReader_0);
						continue;
					case 21:
						method_14(xmlTextReader_0);
						continue;
					case 22:
						method_10(xmlTextReader_0);
						continue;
					case 23:
						method_18(xmlTextReader_0);
						continue;
					case 24:
						method_9(xmlTextReader_0);
						continue;
					case 25:
						method_8(xmlTextReader_0);
						continue;
					case 26:
						method_7(xmlTextReader_0);
						continue;
					case 27:
						method_6(xmlTextReader_0);
						continue;
					case 28:
						method_5(xmlTextReader_0);
						continue;
					case 29:
						method_0(xmlTextReader_0);
						continue;
					}
				}
			}
			xmlTextReader_0.Skip();
		}
	}

	[Attribute0(true)]
	private void method_0(XmlTextReader xmlTextReader_0)
	{
		string value = xmlTextReader_0.ReadOuterXml();
		XmlDocument xmlDocument = Class1188.smethod_1(value);
		XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("controls");
		if (elementsByTagName != null && elementsByTagName.Count == 1)
		{
			XmlElement xmlElement = (XmlElement)elementsByTagName[0];
			XmlNodeList childNodes = xmlElement.ChildNodes;
			for (int i = 0; i < childNodes.Count; i++)
			{
				if (!(childNodes[i] is XmlElement))
				{
					continue;
				}
				XmlElement xmlElement2 = (XmlElement)childNodes[i];
				Class443 @class = new Class443();
				@class.string_1 = Class536.smethod_1(xmlElement2);
				if (xmlElement2.LocalName == "control")
				{
					@class.string_0 = Class1618.smethod_172(xmlElement2, "shapeId");
				}
				else
				{
					XmlNodeList elementsByTagName2 = xmlElement2.GetElementsByTagName("control");
					if (elementsByTagName2 != null && elementsByTagName2.Count == 1)
					{
						XmlElement xmlNode_ = (XmlElement)elementsByTagName2[0];
						@class.string_0 = Class1618.smethod_172(xmlNode_, "shapeId");
					}
				}
				worksheet_0.class1557_0.arrayList_3.Add(@class);
			}
		}
		else
		{
			worksheet_0.class1557_0.arrayList_5.Add(value);
		}
	}

	private void method_1(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		ErrorCheckOptionCollection errorCheckOptions = worksheet_0.ErrorCheckOptions;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "ignoredError")
				{
					int index = errorCheckOptions.Add();
					ErrorCheckOption errorCheckOption = errorCheckOptions[index];
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						string localName;
						if ((localName = xmlTextReader_0.LocalName) == null)
						{
							continue;
						}
						if (Class1742.dictionary_141 == null)
						{
							Class1742.dictionary_141 = new Dictionary<string, int>(10)
							{
								{ "sqref", 0 },
								{ "numberStoredAsText", 1 },
								{ "emptyCellReference", 2 },
								{ "listDataValidation", 3 },
								{ "evalError", 4 },
								{ "twoDigitTextYear", 5 },
								{ "formulaRange", 6 },
								{ "unlockedFormula", 7 },
								{ "formula", 8 },
								{ "calculatedColumn", 9 }
							};
						}
						if (Class1742.dictionary_141.TryGetValue(localName, out var value))
						{
							switch (value)
							{
							case 0:
							{
								string value2 = xmlTextReader_0.Value;
								ArrayList arrayList_ = new ArrayList();
								method_28(value2, arrayList_);
								errorCheckOption.arrayList_0 = arrayList_;
								break;
							}
							case 1:
								errorCheckOption.SetErrorCheck(ErrorCheckType.TextNumber, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							case 2:
								errorCheckOption.SetErrorCheck(ErrorCheckType.EmptyCellRef, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							case 3:
								errorCheckOption.SetErrorCheck(ErrorCheckType.Validation, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							case 4:
								errorCheckOption.SetErrorCheck(ErrorCheckType.Calc, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							case 5:
								errorCheckOption.SetErrorCheck(ErrorCheckType.TextDate, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							case 6:
								errorCheckOption.SetErrorCheck(ErrorCheckType.InconsistRange, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							case 7:
								errorCheckOption.SetErrorCheck(ErrorCheckType.UnproctedFormula, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							case 8:
								errorCheckOption.SetErrorCheck(ErrorCheckType.InconsistFormula, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							case 9:
								errorCheckOption.SetErrorCheck(ErrorCheckType.CalculatedColumn, !Class1618.smethod_201(xmlTextReader_0.Value));
								break;
							}
						}
					}
					xmlTextReader_0.MoveToElement();
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

	private void method_2(XmlTextReader xmlTextReader_0)
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
				if (xmlTextReader_0.LocalName == "cellSmartTags")
				{
					method_3(xmlTextReader_0);
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
	private void method_3(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		string attribute = xmlTextReader_0.GetAttribute("r");
		int index = worksheet_0.SmartTagSetting.Add(attribute);
		SmartTagCollection smartTagCollection_ = worksheet_0.SmartTagSetting[index];
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "cellSmartTag")
				{
					method_4(xmlTextReader_0, smartTagCollection_);
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
	private void method_4(XmlTextReader xmlTextReader_0, SmartTagCollection smartTagCollection_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		string attribute = xmlTextReader_0.GetAttribute("type");
		int num = int.Parse(attribute);
		if (num > worksheet_0.method_2().method_92().Count)
		{
			xmlTextReader_0.Skip();
			return;
		}
		SmartTag smartTag = new SmartTag(smartTagCollection_0);
		smartTag.method_3(worksheet_0.method_2().method_92()[num]);
		smartTagCollection_0.Add(smartTag);
		string attribute2 = xmlTextReader_0.GetAttribute("deleted");
		if (attribute2 != null && attribute2 == "1")
		{
			smartTag.Deleted = true;
		}
		string attribute3 = xmlTextReader_0.GetAttribute("xmlBased");
		if (attribute3 != null && attribute3 == "1")
		{
			smartTag.method_1(bool_2: true);
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "cellSmartTagPr")
				{
					if (xmlTextReader_0.HasAttributes)
					{
						string text = null;
						string value = null;
						while (xmlTextReader_0.MoveToNextAttribute())
						{
							switch (xmlTextReader_0.LocalName)
							{
							case "val":
								value = xmlTextReader_0.Value;
								break;
							case "key":
								text = xmlTextReader_0.Value;
								break;
							}
						}
						if (text != null)
						{
							smartTag.Properties.Add(text, value);
						}
					}
					xmlTextReader_0.MoveToElement();
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && xmlTextReader_0.LocalName == "protectedRange")
			{
				string attribute = xmlTextReader_0.GetAttribute("name");
				string attribute2 = xmlTextReader_0.GetAttribute("sqref");
				string attribute3 = xmlTextReader_0.GetAttribute("password");
				string attribute4 = xmlTextReader_0.GetAttribute("securityDescriptor");
				if (attribute != null && attribute2 != null && attribute2.Length > 0)
				{
					ArrayList arrayList_ = new ArrayList();
					method_28(attribute2, arrayList_);
					int index = worksheet_0.AllowEditRanges.Add(attribute, arrayList_);
					ProtectedRange protectedRange = worksheet_0.AllowEditRanges[index];
					if (attribute3 != null && attribute3 != "")
					{
						protectedRange.method_2(ushort.Parse(attribute3, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
					}
					protectedRange.SecurityDescriptor = attribute4;
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

	private void method_6(XmlTextReader xmlTextReader_0)
	{
		Class1239 @class = new Class1239(class1547_0, class1548_0);
		@class.Read(xmlTextReader_0, this);
	}

	private void method_7(XmlTextReader xmlTextReader_0)
	{
		worksheet_0.class1557_0.string_4 = xmlTextReader_0.ReadOuterXml();
	}

	private void method_8(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		class1548_0.hashtable_1 = new Hashtable();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "customPr")
			{
				string attribute = xmlTextReader_0.GetAttribute("name");
				string attribute2 = xmlTextReader_0.GetAttribute("id", string_1);
				class1548_0.hashtable_1[attribute] = attribute2;
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_9(XmlTextReader xmlTextReader_0)
	{
		class1548_0.string_5 = xmlTextReader_0.GetAttribute("id", string_1);
		xmlTextReader_0.Skip();
		if (class1548_0.string_5 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid Picture r:id element");
		}
	}

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
			}
			else if (xmlTextReader_0.LocalName == "oleObject")
			{
				method_13(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "AlternateContent")
			{
				method_11(xmlTextReader_0, "oleObject");
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_11(XmlTextReader xmlTextReader_0, string string_2)
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
			else if (xmlTextReader_0.LocalName == "Fallback")
			{
				method_12(xmlTextReader_0, string_2);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_12(XmlTextReader xmlTextReader_0, string string_2)
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
			else if (xmlTextReader_0.LocalName == string_2)
			{
				if (string_2 == "oleObject")
				{
					method_13(xmlTextReader_0);
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

	private void method_13(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			Class1552 @class = new Class1552();
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "progId")
				{
					@class.string_0 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "id" && xmlTextReader_0.NamespaceURI == string_1)
				{
					string value = xmlTextReader_0.Value;
					Class1564 class2 = class1548_0.method_4(value);
					if (class2 != null)
					{
						@class.string_2 = class2.string_3;
						@class.string_3 = class2.string_2;
					}
				}
				else if (xmlTextReader_0.LocalName == "shapeId")
				{
					@class.string_1 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "link")
				{
					@class.string_4 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "oleUpdate")
				{
					@class.string_5 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "dvAspect")
				{
					@class.string_6 = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
			class1548_0.arrayList_1.Add(@class);
		}
		xmlTextReader_0.Skip();
	}

	private void method_14(XmlTextReader xmlTextReader_0)
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && (object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0) || xmlTextReader_0.NamespaceURI == "http://schemas.openxmlformats.org/markup-compatibility/2006"))
			{
				if (xmlTextReader_0.LocalName == "control")
				{
					if (xmlTextReader_0.HasAttributes)
					{
						Class1550 @class = new Class1550();
						while (xmlTextReader_0.MoveToNextAttribute())
						{
							if (xmlTextReader_0.LocalName == "shapeId")
							{
								@class.string_0 = xmlTextReader_0.Value;
							}
							else if (xmlTextReader_0.LocalName == "id" && xmlTextReader_0.NamespaceURI == string_1)
							{
								@class.string_4 = xmlTextReader_0.Value;
								@class.string_2 = class1548_0.method_3(@class.string_4);
							}
							else if (xmlTextReader_0.LocalName == "name")
							{
								@class.string_1 = xmlTextReader_0.Value;
							}
						}
						xmlTextReader_0.MoveToElement();
						worksheet_0.class1557_0.arrayList_2.Add(@class);
					}
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "AlternateContent")
				{
					if (xmlTextReader_0.IsEmptyElement)
					{
						xmlTextReader_0.Skip();
						continue;
					}
					xmlTextReader_0.Read();
					string text = null;
					int count = worksheet_0.class1557_0.arrayList_2.Count;
					int num = count;
					while (Class536.smethod_4(xmlTextReader_0))
					{
						switch (xmlTextReader_0.LocalName)
						{
						case "Fallback":
							method_14(xmlTextReader_0);
							num = worksheet_0.class1557_0.arrayList_2.Count;
							break;
						case "Choice":
							text = Class536.smethod_0(xmlTextReader_0.ReadInnerXml());
							break;
						default:
							xmlTextReader_0.Skip();
							break;
						}
					}
					if (num - count == 1)
					{
						Class1550 class2 = (Class1550)worksheet_0.class1557_0.arrayList_2[count];
						class2.string_5 = text;
					}
					if (text == null)
					{
						continue;
					}
					Class443 class3 = new Class443();
					class3.string_1 = text;
					int num2 = text.IndexOf("shapeId=\"");
					if (num2 != -1)
					{
						StringBuilder stringBuilder = new StringBuilder(4);
						for (num2 += 9; num2 < text.Length && text[num2] != '"'; num2++)
						{
							stringBuilder.Append(text[num2]);
						}
						class3.string_0 = stringBuilder.ToString();
						worksheet_0.class1557_0.arrayList_3.Add(class3);
						class3.bool_0 = num == count;
					}
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

	private void method_15()
	{
		Protection protection = worksheet_0.Protection;
		protection.AllowDeletingColumn = false;
		protection.AllowDeletingRow = false;
		protection.AllowEditingContent = true;
		protection.AllowEditingObject = true;
		protection.AllowEditingScenario = true;
		protection.AllowFiltering = false;
		protection.AllowFormattingCell = false;
		protection.AllowFormattingColumn = false;
		protection.AllowFormattingRow = false;
		protection.AllowInsertingColumn = false;
		protection.AllowInsertingHyperlink = false;
		protection.AllowInsertingRow = false;
		protection.AllowSelectingLockedCell = true;
		protection.AllowSelectingUnlockedCell = true;
		protection.AllowSorting = false;
		protection.AllowUsingPivotTable = false;
	}

	private void method_16(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			method_15();
			Protection protection = worksheet_0.Protection;
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "password")
					{
						protection.method_3(ushort.Parse(xmlTextReader_0.Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
					}
					else if (xmlTextReader_0.LocalName == "sheet")
					{
						protection.AllowEditingContent = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "objects")
					{
						protection.AllowEditingObject = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "scenarios")
					{
						protection.AllowEditingScenario = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "formatCells")
					{
						protection.AllowFormattingCell = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "formatColumns")
					{
						protection.AllowFormattingColumn = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "formatRows")
					{
						protection.AllowFormattingRow = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "insertColumns")
					{
						protection.AllowInsertingColumn = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "insertRows")
					{
						protection.AllowInsertingRow = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "insertHyperlinks")
					{
						protection.AllowInsertingHyperlink = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "deleteColumns")
					{
						protection.AllowDeletingColumn = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "deleteRows")
					{
						protection.AllowDeletingRow = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "selectLockedCells")
					{
						protection.AllowSelectingLockedCell = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "sort")
					{
						protection.AllowSorting = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "autoFilter")
					{
						protection.AllowFiltering = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "pivotTables")
					{
						protection.AllowUsingPivotTable = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "selectUnlockedCells")
					{
						protection.AllowSelectingUnlockedCell = !Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "algorithmName")
					{
						protection.method_0().string_0 = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "hashValue")
					{
						protection.method_0().byte_0 = Convert.FromBase64String(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "saltValue")
					{
						protection.method_0().byte_1 = Convert.FromBase64String(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "spinCount")
					{
						protection.method_0().int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	internal static void smethod_0(XmlTextReader xmlTextReader_0, DataSorter dataSorter_0)
	{
		smethod_2(xmlTextReader_0, dataSorter_0);
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
			else if (xmlTextReader_0.LocalName == "sortCondition")
			{
				smethod_1(xmlTextReader_0, dataSorter_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private static void smethod_1(XmlTextReader xmlTextReader_0, DataSorter dataSorter_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1108 @class = new Class1108(dataSorter_0);
		string text = null;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "customList")
			{
				@class.Value = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "descending")
			{
				@class.Order = (Class1618.smethod_201(xmlTextReader_0.Value) ? SortOrder.Descending : SortOrder.Ascending);
			}
			else if (xmlTextReader_0.LocalName == "dxfId")
			{
				int int_ = Class1618.smethod_87(xmlTextReader_0.Value);
				Style style = new Style(dataSorter_0.workbook_0.Worksheets);
				style.Copy(dataSorter_0.workbook_0.Worksheets.method_56()[int_]);
				@class.method_2(style);
			}
			else if (xmlTextReader_0.LocalName == "iconId")
			{
				@class.method_5(@class.IconSetType, Class1618.smethod_87(xmlTextReader_0.Value));
			}
			else if (xmlTextReader_0.LocalName == "iconSet")
			{
				@class.method_5(Class1618.smethod_135(xmlTextReader_0.Value), @class.IconId);
			}
			else if (xmlTextReader_0.LocalName == "ref")
			{
				text = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "sortBy")
			{
				switch (xmlTextReader_0.Value)
				{
				case "value":
					@class.method_1(Enum135.const_0);
					break;
				case "cellColor":
					@class.method_1(Enum135.const_1);
					break;
				case "fontColor":
					@class.method_1(Enum135.const_2);
					break;
				case "icon":
					@class.method_1(Enum135.const_3);
					break;
				}
			}
		}
		if (text != null)
		{
			dataSorter_0.AddKey(@class);
			CellArea cellArea = Class1618.smethod_17(text);
			int num;
			int num2;
			if (@class.method_0().SortLeftToRight)
			{
				num = cellArea.StartRow;
				num2 = cellArea.EndRow;
			}
			else
			{
				num = cellArea.StartColumn;
				num2 = cellArea.EndColumn;
			}
			@class.Index = num;
			while (num < num2)
			{
				num++;
				Class1108 class2 = new Class1108(dataSorter_0);
				class2.Copy(@class);
				class2.Index = num;
				dataSorter_0.AddKey(class2);
			}
			xmlTextReader_0.MoveToElement();
			xmlTextReader_0.Skip();
		}
	}

	private static void smethod_2(XmlTextReader xmlTextReader_0, DataSorter dataSorter_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "caseSensitive")
			{
				dataSorter_0.CaseSensitive = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "columnSort")
			{
				dataSorter_0.SortLeftToRight = Class1618.smethod_201(xmlTextReader_0.Value);
			}
			else if (xmlTextReader_0.LocalName == "ref")
			{
				dataSorter_0.method_1(Class1618.smethod_17(xmlTextReader_0.Value));
			}
			else if (xmlTextReader_0.LocalName == "sortMethod")
			{
				dataSorter_0.string_0 = xmlTextReader_0.Value;
			}
		}
		xmlTextReader_0.MoveToElement();
	}

	internal static void smethod_3(XmlTextReader xmlTextReader_0, AutoFilter autoFilter_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("ref", "");
		if (attribute == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid autoFilter element");
		}
		autoFilter_0.Range = attribute;
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
			else if (xmlTextReader_0.LocalName == "filterColumn")
			{
				smethod_4(xmlTextReader_0, autoFilter_0);
			}
			else if (xmlTextReader_0.LocalName == "sortState")
			{
				smethod_0(xmlTextReader_0, autoFilter_0.Sorter);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private static void smethod_4(XmlTextReader xmlTextReader_0, AutoFilter autoFilter_0)
	{
		int int_ = 0;
		string attribute = xmlTextReader_0.GetAttribute("colId", "");
		if (attribute != null)
		{
			int_ = Class1618.smethod_87(attribute);
		}
		string attribute2 = xmlTextReader_0.GetAttribute("hiddenButton");
		bool bool_ = false;
		if (attribute2 != null)
		{
			bool_ = attribute2 == "1";
		}
		attribute2 = xmlTextReader_0.GetAttribute("showButton");
		bool bool_2 = true;
		if (attribute2 != null)
		{
			bool_2 = attribute2 == "1";
		}
		FilterColumn filterColumn = null;
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
			string localName;
			if ((localName = xmlTextReader_0.LocalName) != null)
			{
				if (Class1742.dictionary_142 == null)
				{
					Class1742.dictionary_142 = new Dictionary<string, int>(6)
					{
						{ "top10", 0 },
						{ "customFilters", 1 },
						{ "filters", 2 },
						{ "dynamicFilter", 3 },
						{ "colorFilter", 4 },
						{ "iconFilter", 5 }
					};
				}
				if (Class1742.dictionary_142.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
					{
						filterColumn = new FilterColumn(autoFilter_0.method_5(), int_, bool_, bool_2);
						filterColumn.FilterType = FilterType.Top10;
						string attribute8 = xmlTextReader_0.GetAttribute("top");
						string attribute9 = xmlTextReader_0.GetAttribute("percent");
						string attribute10 = xmlTextReader_0.GetAttribute("val");
						string attribute11 = xmlTextReader_0.GetAttribute("filterVal");
						bool bool_3 = ((!(attribute8 == "0")) ? true : false);
						bool bool_4 = ((attribute9 == "1") ? true : false);
						int int_2 = 10;
						if (attribute10 != null)
						{
							int_2 = Class1618.smethod_87(attribute10);
						}
						Top10Filter top10Filter2 = (Top10Filter)(filterColumn.Filter = new Top10Filter(bool_3, bool_4, int_2));
						try
						{
							top10Filter2.Criteria = Class1618.smethod_85(attribute11);
						}
						catch
						{
						}
						xmlTextReader_0.Skip();
						continue;
					}
					case 1:
					{
						filterColumn = new FilterColumn(autoFilter_0.method_5(), int_, bool_, bool_2);
						filterColumn.FilterType = FilterType.CustomFilters;
						CustomFilterCollection customFilterCollection_ = (CustomFilterCollection)(filterColumn.Filter = new CustomFilterCollection());
						smethod_6(xmlTextReader_0, customFilterCollection_);
						continue;
					}
					case 2:
					{
						filterColumn = new FilterColumn(autoFilter_0.method_5(), int_, bool_, bool_2);
						filterColumn.FilterType = FilterType.MultipleFilters;
						MultipleFilterCollection multipleFilterCollection_ = (MultipleFilterCollection)(filterColumn.Filter = new MultipleFilterCollection());
						smethod_5(xmlTextReader_0, multipleFilterCollection_);
						continue;
					}
					case 3:
					{
						string attribute5 = xmlTextReader_0.GetAttribute("type");
						string attribute6 = xmlTextReader_0.GetAttribute("val");
						string attribute7 = xmlTextReader_0.GetAttribute("maxVal");
						filterColumn = new FilterColumn(autoFilter_0.method_5(), int_, bool_, bool_2);
						filterColumn.FilterType = FilterType.DynamicFilter;
						DynamicFilter dynamicFilter2 = (DynamicFilter)(filterColumn.Filter = new DynamicFilter());
						dynamicFilter2.DynamicFilterType = Class1618.smethod_179(attribute5);
						if (attribute6 != null && Class1677.smethod_19(attribute6))
						{
							dynamicFilter2.Value = Class1618.smethod_85(attribute6);
						}
						if (attribute7 != null && Class1677.smethod_19(attribute7))
						{
							dynamicFilter2.MaxValue = Class1618.smethod_85(attribute7);
						}
						xmlTextReader_0.Skip();
						continue;
					}
					case 4:
					{
						string attribute12 = xmlTextReader_0.GetAttribute("cellColor");
						string attribute13 = xmlTextReader_0.GetAttribute("dxfId");
						filterColumn = new FilterColumn(autoFilter_0.method_5(), int_, bool_, bool_2);
						filterColumn.FilterType = FilterType.ColorFilter;
						ColorFilter colorFilter2 = (ColorFilter)(filterColumn.Filter = new ColorFilter(filterColumn));
						colorFilter2.FilterByFillColor = attribute12 == null || attribute12 == "1";
						colorFilter2.method_2(Class1618.smethod_87(attribute13));
						xmlTextReader_0.Skip();
						continue;
					}
					case 5:
					{
						string attribute3 = xmlTextReader_0.GetAttribute("iconId");
						string attribute4 = xmlTextReader_0.GetAttribute("iconSet");
						filterColumn = new FilterColumn(autoFilter_0.method_5(), int_, bool_, bool_2);
						filterColumn.FilterType = FilterType.IconFilter;
						IconFilter iconFilter2 = (IconFilter)(filterColumn.Filter = new IconFilter(filterColumn));
						if (attribute4 != null)
						{
							iconFilter2.IconSetType = Class1618.smethod_135(attribute4);
						}
						if (attribute3 != null)
						{
							iconFilter2.IconId = Class1618.smethod_87(attribute3);
						}
						xmlTextReader_0.Skip();
						continue;
					}
					}
				}
			}
			xmlTextReader_0.Skip();
		}
		xmlTextReader_0.ReadEndElement();
		if (filterColumn != null)
		{
			autoFilter_0.method_5().method_0(filterColumn);
		}
	}

	private static void smethod_5(XmlTextReader xmlTextReader_0, MultipleFilterCollection multipleFilterCollection_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("blank", "");
		if (attribute == "1")
		{
			multipleFilterCollection_0.MatchBlank = true;
		}
		multipleFilterCollection_0.string_0 = xmlTextReader_0.GetAttribute("calendarType");
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
			switch (xmlTextReader_0.LocalName)
			{
			case "dateGroupItem":
			{
				DateTimeGroupItem dateTimeGroupItem = new DateTimeGroupItem();
				multipleFilterCollection_0.Add(dateTimeGroupItem);
				if (xmlTextReader_0.HasAttributes)
				{
					while (xmlTextReader_0.MoveToNextAttribute())
					{
						string localName;
						if ((localName = xmlTextReader_0.LocalName) == null)
						{
							continue;
						}
						if (Class1742.dictionary_143 == null)
						{
							Class1742.dictionary_143 = new Dictionary<string, int>(7)
							{
								{ "dateTimeGrouping", 0 },
								{ "year", 1 },
								{ "month", 2 },
								{ "day", 3 },
								{ "hour", 4 },
								{ "minute", 5 },
								{ "second", 6 }
							};
						}
						if (Class1742.dictionary_143.TryGetValue(localName, out var value))
						{
							switch (value)
							{
							case 0:
								dateTimeGroupItem.DateTimeGroupingType = Class1618.smethod_181(xmlTextReader_0.Value);
								break;
							case 1:
								dateTimeGroupItem.Year = Class1618.smethod_87(xmlTextReader_0.Value);
								break;
							case 2:
								dateTimeGroupItem.Month = Class1618.smethod_87(xmlTextReader_0.Value);
								break;
							case 3:
								dateTimeGroupItem.Day = Class1618.smethod_87(xmlTextReader_0.Value);
								break;
							case 4:
								dateTimeGroupItem.Hour = Class1618.smethod_87(xmlTextReader_0.Value);
								break;
							case 5:
								dateTimeGroupItem.Minute = Class1618.smethod_87(xmlTextReader_0.Value);
								break;
							case 6:
								dateTimeGroupItem.Second = Class1618.smethod_87(xmlTextReader_0.Value);
								break;
							}
						}
					}
					xmlTextReader_0.MoveToElement();
				}
				xmlTextReader_0.Skip();
				break;
			}
			case "filter":
				multipleFilterCollection_0.Add(xmlTextReader_0.GetAttribute("val"));
				xmlTextReader_0.Skip();
				break;
			default:
				xmlTextReader_0.Skip();
				break;
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private static void smethod_6(XmlTextReader xmlTextReader_0, CustomFilterCollection customFilterCollection_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("and", "");
		customFilterCollection_0.And = ((attribute == "1") ? true : false);
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
			else if (xmlTextReader_0.LocalName == "customFilter")
			{
				string attribute2 = xmlTextReader_0.GetAttribute("operator");
				string attribute3 = xmlTextReader_0.GetAttribute("val");
				CustomFilter customFilter = new CustomFilter();
				customFilterCollection_0.Add(customFilter);
				customFilter.FilterOperatorType = Class1618.smethod_186(attribute2);
				if (Class1677.smethod_19(attribute3))
				{
					customFilter.Criteria = Class1618.smethod_85(attribute3);
				}
				else
				{
					customFilter.Criteria = attribute3;
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

	private void method_17(XmlTextReader xmlTextReader_0)
	{
		class1548_0.string_4 = xmlTextReader_0.GetAttribute("id", string_1);
		xmlTextReader_0.Skip();
		if (class1548_0.string_4 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid DrawingRid element");
		}
		string text = class1548_0.method_3(class1548_0.string_4);
		worksheet_0.class1557_0.string_1 = "xl" + text.Substring(2);
	}

	private void method_18(XmlTextReader xmlTextReader_0)
	{
		class1548_0.string_3 = xmlTextReader_0.GetAttribute("id", string_1);
		xmlTextReader_0.Skip();
		if (class1548_0.string_3 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid LegacyDrawingHFRid element");
		}
	}

	private void method_19(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("codeName");
		if (attribute != null && attribute.Length > 0)
		{
			worksheet_0.method_46(attribute);
		}
		worksheet_0.class1557_0.string_3 = xmlTextReader_0.GetAttribute("published");
		string attribute2 = xmlTextReader_0.GetAttribute("transitionEvaluation");
		if (attribute2 != null)
		{
			if (attribute2 == "1")
			{
				worksheet_0.TransitionEvaluation = true;
			}
			else
			{
				worksheet_0.TransitionEvaluation = false;
			}
		}
		string attribute3 = xmlTextReader_0.GetAttribute("transitionEvaluation");
		if (attribute3 != null)
		{
			worksheet_0.TransitionEntry = Class1618.smethod_201(attribute3);
		}
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
				if (xmlTextReader_0.LocalName == "pageSetUpPr")
				{
					string attribute4 = xmlTextReader_0.GetAttribute("fitToPage");
					if (attribute4 != null)
					{
						worksheet_0.PageSetup.IsPercentScale = ((attribute4 == "0") ? true : false);
					}
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "tabColor")
				{
					worksheet_0.internalColor_0 = Class1611.smethod_2(xmlTextReader_0, class1547_0);
				}
				else if (xmlTextReader_0.LocalName == "outlinePr")
				{
					method_20(xmlTextReader_0);
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
	private void method_20(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "summaryBelow")
				{
					if (xmlTextReader_0.Value == "0")
					{
						worksheet_0.Outline.SummaryRowBelow = false;
					}
				}
				else if (xmlTextReader_0.LocalName == "summaryRight" && xmlTextReader_0.Value == "0")
				{
					worksheet_0.Outline.SummaryColumnRight = false;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
	}

	private void method_21(double double_0, bool bool_2)
	{
		if (Math.Abs(double_0 - 0.0) < 0.0001)
		{
			worksheet_0.Cells.method_8(0.0);
			return;
		}
		int num = class1547_0.workbook_0.Worksheets.method_72();
		double num2 = double_0 * (double)num;
		if (bool_2)
		{
			num2 += 10.0;
		}
		if (num2 > 5.0)
		{
			worksheet_0.Cells.method_8((num2 - 5.0) / (double)num);
			return;
		}
		worksheet_0.Cells.method_8(0.0);
		ColumnCollection columns = worksheet_0.Cells.Columns;
		if (columns.column_0 == null)
		{
			columns.method_0().method_2((int)(num2 + 0.5));
		}
	}

	[Attribute0(true)]
	private void method_22(XmlTextReader xmlTextReader_0)
	{
		bool flag = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				if (xmlTextReader_0.LocalName == "defaultRowHeight")
				{
					worksheet_0.Cells.StandardHeight = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "defaultColWidth")
				{
					double double_ = Class1618.smethod_85(xmlTextReader_0.Value);
					method_21(double_, bool_2: false);
				}
				else if (xmlTextReader_0.LocalName == "baseColWidth")
				{
					double num = Class1618.smethod_85(xmlTextReader_0.Value);
					if (num != 0.0)
					{
						method_21(num, bool_2: true);
					}
				}
				else if (xmlTextReader_0.LocalName == "outlineLevelRow")
				{
					worksheet_0.Cells.method_30((byte)Class1618.smethod_87(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "outlineLevelCol")
				{
					worksheet_0.Cells.method_28((byte)Class1618.smethod_87(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "zeroHeight" && xmlTextReader_0.Value == "1")
				{
					worksheet_0.Cells.method_26(bool_2: true);
				}
				else if (xmlTextReader_0.LocalName == "customHeight" && xmlTextReader_0.Value == "1")
				{
					flag = true;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		if (flag)
		{
			worksheet_0.Cells.IsDefaultRowHeightMatched = false;
		}
		else
		{
			worksheet_0.Cells.IsDefaultRowHeightMatched = true;
		}
	}

	[Attribute0(true)]
	private void method_23(XmlTextReader xmlTextReader_0)
	{
		class1548_0.string_2 = xmlTextReader_0.GetAttribute("id", string_1);
		xmlTextReader_0.Skip();
		if (class1548_0.string_2 == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid legacyDrawing element");
		}
		string text = class1548_0.method_3(class1548_0.string_2);
		if (text[0] == '/')
		{
			worksheet_0.class1557_0.string_2 = "xl" + text.Substring(3);
		}
		else
		{
			worksheet_0.class1557_0.string_2 = "xl" + text.Substring(2);
		}
	}

	private void method_24(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1618.smethod_41(xmlTextReader_0);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "hyperlink")
				{
					method_25(xmlTextReader_0);
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
	private void method_25(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid Hyperlink element");
		}
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "ref" && xmlTextReader_0.NamespaceURI == "")
			{
				text = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "id" && xmlTextReader_0.NamespaceURI == string_1)
			{
				text2 = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "location" && xmlTextReader_0.NamespaceURI == "")
			{
				text3 = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "display" && xmlTextReader_0.NamespaceURI == "")
			{
				text4 = xmlTextReader_0.Value;
			}
			else if (xmlTextReader_0.LocalName == "tooltip")
			{
				text5 = xmlTextReader_0.Value;
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
		if (text == null)
		{
			throw new CellsException(ExceptionType.InvalidData, "Invalid Hyperlink element");
		}
		CellArea cellArea = Class1618.smethod_17(text);
		if (text2 != null)
		{
			Hashtable hashtable = class1548_0.hashtable_0;
			if (hashtable != null && hashtable.ContainsKey(text2))
			{
				Class1564 @class = (Class1564)hashtable[text2];
				text3 = ((text3 != null) ? (@class.string_3 + "#" + text3) : @class.string_3);
			}
		}
		if (text3 != null)
		{
			int index = worksheet_0.Hyperlinks.method_1(cellArea.StartRow, cellArea.StartColumn, cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1, text3);
			Hyperlink hyperlink = worksheet_0.Hyperlinks[index];
			if (text4 != null)
			{
				hyperlink.method_3(text4);
			}
			if (text5 != null)
			{
				hyperlink.ScreenTip = text5;
			}
		}
	}

	internal void method_26(XmlTextReader xmlTextReader_0, bool bool_2)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1618.smethod_41(xmlTextReader_0);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "dataValidation")
			{
				method_27(xmlTextReader_0, bool_2);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_27(XmlTextReader xmlTextReader_0, bool bool_2)
	{
		Validation validation = worksheet_0.Validations[worksheet_0.Validations.Add()];
		validation.IgnoreBlank = false;
		validation.ShowInput = false;
		validation.ShowError = false;
		validation.Operator = OperatorType.Between;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "errorStyle")
					{
						validation.AlertStyle = Class1618.smethod_42(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "type")
					{
						validation.Type = Class1618.smethod_27(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "allowBlank" && xmlTextReader_0.Value == "1")
					{
						validation.IgnoreBlank = true;
					}
					else if (xmlTextReader_0.LocalName == "showInputMessage" && xmlTextReader_0.Value == "1")
					{
						validation.ShowInput = true;
					}
					else if (xmlTextReader_0.LocalName == "showErrorMessage" && xmlTextReader_0.Value == "1")
					{
						validation.ShowError = true;
					}
					else if (xmlTextReader_0.LocalName == "promptTitle")
					{
						validation.InputTitle = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "prompt")
					{
						validation.InputMessage = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "errorTitle")
					{
						validation.ErrorTitle = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "error")
					{
						validation.ErrorMessage = xmlTextReader_0.Value;
					}
					else if (xmlTextReader_0.LocalName == "imeMode")
					{
						validation.method_6(Class1618.smethod_43(xmlTextReader_0.Value));
					}
					else if (xmlTextReader_0.LocalName == "sqref")
					{
						method_28(xmlTextReader_0.Value, validation.AreaList);
					}
					else if (xmlTextReader_0.LocalName == "operator")
					{
						validation.Operator = Class1618.smethod_30(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "showDropDown" && xmlTextReader_0.Value == "1")
					{
						validation.InCellDropDown = false;
					}
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
		string text = null;
		string text2 = null;
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			if (xmlTextReader_0.NodeType == XmlNodeType.Comment)
			{
				xmlTextReader_0.Read();
				continue;
			}
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "formula1")
			{
				if (!bool_2)
				{
					text = xmlTextReader_0.ReadElementString();
					if (text != null && text != "" && text[0] != '=')
					{
						text = "=" + text;
					}
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
					else if (xmlTextReader_0.LocalName == "f")
					{
						text = xmlTextReader_0.ReadElementString();
						if (text != null && text != "" && text[0] != '=')
						{
							text = "=" + text;
						}
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
			}
			else if (xmlTextReader_0.LocalName == "formula2")
			{
				if (!bool_2)
				{
					text2 = xmlTextReader_0.ReadElementString();
					if (text2 != null && text2 != "" && text2[0] != '=')
					{
						text2 = "=" + text2;
					}
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
					else if (xmlTextReader_0.LocalName == "f")
					{
						text2 = xmlTextReader_0.ReadElementString();
						if (text2 != null && text2 != "" && text2[0] != '=')
						{
							text2 = "=" + text2;
						}
					}
					else
					{
						xmlTextReader_0.Skip();
					}
				}
				xmlTextReader_0.ReadEndElement();
			}
			else if (xmlTextReader_0.LocalName == "sqref")
			{
				string text3 = xmlTextReader_0.ReadElementString();
				if (text3 != null && text3.Length > 0)
				{
					method_28(text3, validation.AreaList);
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		if (text != null)
		{
			text = Class1618.smethod_8(text);
		}
		if (text2 != null)
		{
			text2 = Class1618.smethod_8(text2);
		}
		validation.method_13(text, text2);
		xmlTextReader_0.ReadEndElement();
	}

	private void method_28(string string_2, ArrayList arrayList_0)
	{
		string[] array = string_2.Split(' ');
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i].Trim();
			if (text.Length > 0)
			{
				CellArea cellArea = Class1618.smethod_17(text);
				arrayList_0.Add(cellArea);
			}
		}
	}

	private void method_29(XmlTextReader xmlTextReader_0, bool bool_2)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1618.smethod_41(xmlTextReader_0);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "brk")
				{
					if (bool_2)
					{
						int int_ = -1;
						int int_2 = -1;
						int int_3 = -1;
						method_30(xmlTextReader_0, ref int_, ref int_2, ref int_3);
						xmlTextReader_0.Skip();
						if (int_ == -1)
						{
							continue;
						}
						if (int_2 == -1 && int_3 == -1)
						{
							worksheet_0.HorizontalPageBreaks.Add(int_, 0);
							continue;
						}
						if (int_2 == -1)
						{
							int_2 = 0;
						}
						if (int_3 == -1 || int_3 > 255)
						{
							int_3 = 255;
						}
						worksheet_0.HorizontalPageBreaks.Add(int_, int_2, int_3);
						continue;
					}
					int int_4 = -1;
					int int_5 = -1;
					int int_6 = -1;
					method_30(xmlTextReader_0, ref int_4, ref int_5, ref int_6);
					xmlTextReader_0.Skip();
					if (int_4 == -1)
					{
						continue;
					}
					if (int_5 == -1 && int_6 == -1)
					{
						worksheet_0.VerticalPageBreaks.Add(0, int_4);
						continue;
					}
					if (int_5 == -1)
					{
						int_5 = 0;
					}
					if (int_6 == -1 || int_6 > 65535)
					{
						int_6 = 65535;
					}
					worksheet_0.VerticalPageBreaks.Add(int_5, int_6, int_4);
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
	private void method_30(XmlTextReader xmlTextReader_0, ref int int_0, ref int int_1, ref int int_2)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			return;
		}
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (!(xmlTextReader_0.NamespaceURI != ""))
			{
				if (xmlTextReader_0.LocalName == "id")
				{
					int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "min")
				{
					int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "max")
				{
					int_2 = Class1618.smethod_87(xmlTextReader_0.Value);
				}
			}
		}
		xmlTextReader_0.MoveToElement();
	}

	[Attribute0(true)]
	private void method_31(XmlTextReader xmlTextReader_0)
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "differentOddEven")
				{
					if (xmlTextReader_0.Value == "1")
					{
						pageSetup.IsHFDiffOddEven = true;
					}
				}
				else if (xmlTextReader_0.LocalName == "differentFirst")
				{
					if (xmlTextReader_0.Value == "1")
					{
						pageSetup.IsHFDiffFirst = true;
					}
				}
				else if (xmlTextReader_0.LocalName == "scaleWithDoc")
				{
					if (xmlTextReader_0.Value == "0")
					{
						pageSetup.IsHFScaleWithDoc = false;
					}
				}
				else if (xmlTextReader_0.LocalName == "alignWithMargins" && xmlTextReader_0.Value == "0")
				{
					pageSetup.IsHFAlignMargins = false;
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
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "oddHeader")
				{
					string[] array = smethod_7(xmlTextReader_0.ReadElementString().Replace("\r\n", "\n"));
					for (int i = 0; i < 3; i++)
					{
						if (array[i] != null)
						{
							pageSetup.SetHeader(i, array[i]);
						}
					}
				}
				else if (xmlTextReader_0.LocalName == "oddFooter")
				{
					string[] array2 = smethod_7(xmlTextReader_0.ReadElementString().Replace("\r\n", "\n"));
					for (int j = 0; j < 3; j++)
					{
						if (array2[j] != null)
						{
							pageSetup.SetFooter(j, array2[j]);
						}
					}
				}
				else if (xmlTextReader_0.LocalName == "evenHeader")
				{
					string[] array3 = smethod_7(xmlTextReader_0.ReadElementString().Replace("\r\n", "\n"));
					for (int k = 0; k < 3; k++)
					{
						if (array3[k] != null)
						{
							pageSetup.SetEvenHeader(k, array3[k]);
						}
					}
				}
				else if (xmlTextReader_0.LocalName == "evenFooter")
				{
					string[] array4 = smethod_7(xmlTextReader_0.ReadElementString().Replace("\r\n", "\n"));
					for (int l = 0; l < 3; l++)
					{
						if (array4[l] != null)
						{
							pageSetup.SetEvenFooter(l, array4[l]);
						}
					}
				}
				else if (xmlTextReader_0.LocalName == "firstHeader")
				{
					string[] array5 = smethod_7(xmlTextReader_0.ReadElementString().Replace("\r\n", "\n"));
					for (int m = 0; m < 3; m++)
					{
						if (array5[m] != null)
						{
							pageSetup.SetFirstPageHeader(m, array5[m]);
						}
					}
				}
				else if (xmlTextReader_0.LocalName == "firstFooter")
				{
					string[] array6 = smethod_7(xmlTextReader_0.ReadElementString().Replace("\r\n", "\n"));
					for (int n = 0; n < 3; n++)
					{
						if (array6[n] != null)
						{
							pageSetup.SetFirstPageFooter(n, array6[n]);
						}
					}
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

	private static string[] smethod_7(string string_2)
	{
		string[] array = new string[3];
		int num = 1;
		int num2 = 0;
		for (int i = 0; i < string_2.Length; i++)
		{
			if (string_2[i] != '&' || i + 1 >= string_2.Length)
			{
				continue;
			}
			char c = string_2[i + 1];
			if (c <= 'L')
			{
				if (c != '&')
				{
					if (c == 'C')
					{
						goto IL_0067;
					}
					if (c != 'L')
					{
						continue;
					}
					goto IL_007f;
				}
				i++;
				continue;
			}
			if (c <= 'c')
			{
				if (c != 'R')
				{
					if (c != 'c')
					{
						continue;
					}
					goto IL_0067;
				}
			}
			else
			{
				if (c == 'l')
				{
					goto IL_007f;
				}
				if (c != 'r')
				{
					continue;
				}
			}
			int num3 = 2;
			goto IL_0082;
			IL_0082:
			if (i - num2 > 0)
			{
				array[num] = string_2.Substring(num2, i - num2);
			}
			num = num3;
			num2 = i + 2;
			continue;
			IL_007f:
			num3 = 0;
			goto IL_0082;
			IL_0067:
			num3 = 1;
			goto IL_0082;
		}
		if (num2 < string_2.Length)
		{
			array[num] = string_2.Substring(num2);
		}
		return array;
	}

	[Attribute0(true)]
	private void method_32(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		PageSetup pageSetup = worksheet_0.PageSetup;
		method_34(pageSetup);
		bool flag = false;
		string text = null;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (xmlTextReader_0.LocalName == "id")
			{
				class1548_0.string_6 = xmlTextReader_0.Value;
			}
			else
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				if (xmlTextReader_0.LocalName == "blackAndWhite" && xmlTextReader_0.Value == "1")
				{
					pageSetup.BlackAndWhite = true;
				}
				else if (xmlTextReader_0.LocalName == "cellComments")
				{
					pageSetup.PrintComments = Class1618.smethod_21(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "draft" && xmlTextReader_0.Value == "1")
				{
					pageSetup.PrintDraft = true;
				}
				else if (xmlTextReader_0.LocalName == "errors")
				{
					pageSetup.PrintErrors = Class1618.smethod_23(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "useFirstPageNumber")
				{
					flag = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "firstPageNumber")
				{
					text = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "fitToHeight")
				{
					pageSetup.method_6(Class1618.smethod_87(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "fitToWidth")
				{
					pageSetup.method_7(Class1618.smethod_87(xmlTextReader_0.Value));
				}
				else if (xmlTextReader_0.LocalName == "horizontalDpi")
				{
					method_33(pageSetup, xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "verticalDpi")
				{
					method_33(pageSetup, xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "orientation")
				{
					pageSetup.Orientation = Class1618.smethod_19(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "pageOrder")
				{
					pageSetup.Order = Class1618.smethod_25(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "paperSize")
				{
					pageSetup.PaperSize = (PaperSizeType)Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "scale")
				{
					int num = Class1618.smethod_87(xmlTextReader_0.Value);
					if (num >= 10 && num <= 400)
					{
						pageSetup.method_10(num);
					}
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
		if (!flag || text == null)
		{
			return;
		}
		try
		{
			pageSetup.FirstPageNumber = Class1618.smethod_87(text);
		}
		catch
		{
		}
	}

	private void method_33(PageSetup pageSetup_0, string string_2)
	{
		if (string_2.Length <= 5)
		{
			try
			{
				pageSetup_0.PrintQuality = Class1618.smethod_87(string_2);
			}
			catch
			{
			}
		}
	}

	private void method_34(PageSetup pageSetup_0)
	{
		pageSetup_0.BlackAndWhite = false;
		pageSetup_0.PrintComments = PrintCommentsType.PrintNoComments;
		pageSetup_0.PrintDraft = false;
		pageSetup_0.PrintErrors = PrintErrorsType.PrintErrorsDisplayed;
		pageSetup_0.FirstPageNumber = 1;
		pageSetup_0.IsAutoFirstPageNumber = true;
		pageSetup_0.PrintQuality = 600;
		pageSetup_0.Order = PrintOrderType.DownThenOver;
		pageSetup_0.PaperSize = PaperSizeType.PaperLetter;
		pageSetup_0.IsHFScaleWithDoc = true;
		pageSetup_0.IsHFAlignMargins = true;
		pageSetup_0.IsHFDiffOddEven = false;
		pageSetup_0.IsHFDiffFirst = false;
		if (pageSetup_0.IsPercentScale)
		{
			pageSetup_0.Zoom = 100;
		}
	}

	[Attribute0(true)]
	private void method_35(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		PageSetup pageSetup = worksheet_0.PageSetup;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (!(xmlTextReader_0.NamespaceURI != ""))
			{
				if (xmlTextReader_0.LocalName == "left")
				{
					pageSetup.LeftMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "right")
				{
					pageSetup.RightMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "top")
				{
					pageSetup.TopMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "bottom")
				{
					pageSetup.BottomMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "header")
				{
					pageSetup.HeaderMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "footer")
				{
					pageSetup.FooterMarginInch = Class1618.smethod_85(xmlTextReader_0.Value);
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_36(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return;
		}
		PageSetup pageSetup = worksheet_0.PageSetup;
		pageSetup.PrintGridlines = false;
		pageSetup.PrintHeadings = false;
		pageSetup.CenterHorizontally = false;
		pageSetup.CenterVertically = false;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (!(xmlTextReader_0.NamespaceURI != ""))
			{
				if (xmlTextReader_0.LocalName == "gridLines" && xmlTextReader_0.Value == "1")
				{
					pageSetup.PrintGridlines = true;
				}
				else if (xmlTextReader_0.LocalName == "headings" && xmlTextReader_0.Value == "1")
				{
					pageSetup.PrintHeadings = true;
				}
				else if (xmlTextReader_0.LocalName == "horizontalCentered" && xmlTextReader_0.Value == "1")
				{
					pageSetup.CenterHorizontally = true;
				}
				else if (xmlTextReader_0.LocalName == "verticalCentered" && xmlTextReader_0.Value == "1")
				{
					pageSetup.CenterVertically = true;
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
	}

	[Attribute0(true)]
	private void method_37(XmlTextReader xmlTextReader_0)
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
				if (xmlTextReader_0.LocalName == "mergeCell")
				{
					string[] array = xmlTextReader_0.GetAttribute("ref").Split(':');
					xmlTextReader_0.Skip();
					CellArea cellArea_ = default(CellArea);
					if (array.Length > 1)
					{
						int column = 0;
						int column2 = 0;
						int row = cellArea_.StartRow;
						CellsHelper.CellNameToIndex(array[0], out row, out column);
						cellArea_.StartRow = row;
						int row2 = cellArea_.EndRow;
						CellsHelper.CellNameToIndex(array[1], out row2, out column2);
						cellArea_.EndRow = row2;
						cellArea_.StartColumn = column;
						cellArea_.EndColumn = column2;
					}
					else
					{
						CellsHelper.CellNameToIndex(array[0], out var row3, out var column3);
						cellArea_.StartRow = row3;
						cellArea_.StartColumn = column3;
						cellArea_.EndRow = cellArea_.StartRow;
						cellArea_.EndColumn = cellArea_.StartColumn;
					}
					worksheet_0.Cells.method_18().Add(cellArea_);
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

	private void method_38(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Workbook workbook = worksheet_0.method_2().Workbook;
		int int_ = -1;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (!(xmlTextReader_0.LocalName == "row"))
				{
					xmlTextReader_0.Skip();
					throw new CellsException(ExceptionType.InvalidData, "Invalid sheetData sub Element " + xmlTextReader_0.LocalName);
				}
				workbook.method_30();
				int_ = method_39(xmlTextReader_0, int_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private int method_39(XmlTextReader xmlTextReader_0, int int_0)
	{
		int num = int_0 + 1;
		int num2 = -1;
		double num3 = -1.0;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		short num4 = -1;
		bool flag5 = false;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != ""))
				{
					if (xmlTextReader_0.LocalName == "r")
					{
						num = Class1618.smethod_87(xmlTextReader_0.Value) - 1;
					}
					else if (xmlTextReader_0.LocalName == "s")
					{
						num2 = Class1618.smethod_87(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "customFormat")
					{
						flag = Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "ht")
					{
						num3 = Class1618.smethod_85(xmlTextReader_0.Value);
						flag4 = true;
					}
					else if (xmlTextReader_0.LocalName == "customHeight")
					{
						flag2 = Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "hidden")
					{
						flag3 = Class1618.smethod_201(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "outlineLevel")
					{
						num4 = Class1618.smethod_89(xmlTextReader_0.Value);
					}
					else if (xmlTextReader_0.LocalName == "collapsed")
					{
						flag5 = Class1618.smethod_201(xmlTextReader_0.Value);
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		Row row = worksheet_0.Cells.Rows.GetRow(num, bool_0: false, bool_1: false);
		if (num2 != -1 && flag)
		{
			object obj = class1547_0.hashtable_3[num2];
			if (obj == null)
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid row style Idx, rowid:" + num);
			}
			row.method_11((int)obj);
			row.method_21(bool_1: true);
		}
		row.method_19(flag5);
		if (num4 != -1)
		{
			row.method_25((byte)num4);
		}
		if (flag4)
		{
			if (num3 > 409.5)
			{
				num3 = 409.5;
			}
			row.method_12((ushort)(num3 * 20.0 + 0.5));
			row.IsHeightMatched = !flag2;
		}
		else if (!flag2)
		{
			row.IsHeightMatched = true;
		}
		row.method_17(flag3);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return num;
		}
		int int_ = -1;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "c")
			{
				int_ = method_41(xmlTextReader_0, row, num, int_);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return num;
	}

	[SpecialName]
	internal void method_40(Class1610 class1610_1)
	{
		class1610_0 = class1610_1;
	}

	private static int smethod_8(string string_2)
	{
		int num = 0;
		for (int i = 0; i < string_2.Length; i++)
		{
			char c = (char)(string_2[i] | 0x20u);
			if (c >= 'a' && c <= 'z')
			{
				num = num * 26 + c - 97 + 1;
			}
			else if (c != '$')
			{
				break;
			}
		}
		if (num > 0)
		{
			num--;
		}
		return num;
	}

	private int method_41(XmlTextReader xmlTextReader_0, Row row_0, int int_0, int int_1)
	{
		int num = -1;
		string text = "n";
		bool flag = false;
		string text2 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.NamespaceURI != "") && xmlTextReader_0.LocalName.Length == 1)
				{
					switch (xmlTextReader_0.LocalName[0])
					{
					case 'r':
						text2 = xmlTextReader_0.Value;
						break;
					case 's':
						num = Class1618.smethod_87(xmlTextReader_0.Value);
						flag = true;
						break;
					case 't':
						text = xmlTextReader_0.Value;
						break;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		int num2 = int_1 + 1;
		if (text2 != null)
		{
			num2 = smethod_8(text2);
			if (num2 < int_1 + 1)
			{
				throw new CellsException(ExceptionType.InvalidData, "Invalid cell name");
			}
		}
		int_1 = num2;
		int num3 = 15;
		if (num != -1)
		{
			object obj = class1547_0.hashtable_3[num];
			if (obj != null)
			{
				int num4 = (int)obj;
				num3 = num4;
			}
		}
		Cell cell = null;
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			if (bool_0 && (!bool_1 || class1547_0.hashtable_4[num] == null))
			{
				if (!flag)
				{
					cell = row_0.GetCell(worksheet_0.Cells.Rows, num2, bool_1: false, bool_2: false, bool_3: false, 0);
					cell.method_37(num3);
				}
				else if (num3 != 15)
				{
					cell = row_0.GetCell(worksheet_0.Cells.Rows, num2, bool_1: false, bool_2: false, bool_3: false, 0);
					cell.method_37(num3);
				}
			}
			return int_1;
		}
		cell = row_0.GetCell(worksheet_0.Cells.Rows, num2, bool_1: false, bool_2: false, bool_3: false, 0);
		cell.method_37(num3);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "f")
				{
					string attribute = xmlTextReader_0.GetAttribute("t");
					if (attribute == null)
					{
						string text3 = xmlTextReader_0.ReadElementString();
						if (text3.Length != 0)
						{
							cell.method_39(text3);
						}
						continue;
					}
					switch (attribute)
					{
					case "array":
					{
						string attribute8 = xmlTextReader_0.GetAttribute("ref");
						string text6 = xmlTextReader_0.ReadElementString();
						if (attribute8 != null && text6 != null)
						{
							int rownum = 0;
							int colnum = 0;
							smethod_10(attribute8, out rownum, out colnum);
							cell.SetArrayFormula("=" + text6, rownum, colnum);
						}
						break;
					}
					case "shared":
					{
						string attribute2 = xmlTextReader_0.GetAttribute("ref");
						string attribute3 = xmlTextReader_0.GetAttribute("si");
						string text5 = xmlTextReader_0.ReadElementString();
						if (attribute2 != null && text5 != null)
						{
							CellArea cellArea_ = Class1618.smethod_17(attribute2);
							byte[] value = cell.method_73("=" + text5, cellArea_);
							if (attribute3 != null)
							{
								hashtable_0[attribute3] = value;
							}
						}
						else if (attribute3 != null)
						{
							object obj2 = hashtable_0[attribute3];
							if (obj2 != null)
							{
								cell.method_74((byte[])obj2);
							}
						}
						break;
					}
					case "dataTable":
					{
						string attribute4 = xmlTextReader_0.GetAttribute("ref");
						CellArea cellArea = Class1618.smethod_17(attribute4);
						bool bool_ = false;
						string attribute5 = xmlTextReader_0.GetAttribute("del1");
						if (attribute5 != null)
						{
							bool_ = Class1618.smethod_201(attribute5);
						}
						bool bool_2 = false;
						attribute5 = xmlTextReader_0.GetAttribute("del2");
						if (attribute5 != null)
						{
							bool_2 = Class1618.smethod_201(attribute5);
						}
						bool flag2 = false;
						attribute5 = xmlTextReader_0.GetAttribute("dt2D");
						if (attribute5 != null)
						{
							flag2 = Class1618.smethod_201(attribute5);
						}
						bool flag3 = false;
						attribute5 = xmlTextReader_0.GetAttribute("dtr");
						if (attribute5 != null)
						{
							flag3 = Class1618.smethod_201(attribute5);
						}
						bool flag4 = false;
						attribute5 = xmlTextReader_0.GetAttribute("aca");
						if (attribute5 != null)
						{
							flag4 = Class1618.smethod_201(attribute5);
						}
						string attribute6 = xmlTextReader_0.GetAttribute("r1");
						string attribute7 = xmlTextReader_0.GetAttribute("r2");
						cell.method_49(cellArea.EndRow - cellArea.StartRow + 1, cellArea.EndColumn - cellArea.StartColumn + 1, flag2, flag3, attribute6, attribute7, bool_, bool_2);
						cell.method_52().method_2(flag4);
						xmlTextReader_0.Skip();
						break;
					}
					default:
					{
						string text4 = xmlTextReader_0.ReadElementString();
						if (text4.Length != 0)
						{
							cell.method_39(text4);
						}
						break;
					}
					}
				}
				else if (xmlTextReader_0.LocalName == "v")
				{
					xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
					string text7 = xmlTextReader_0.ReadElementString();
					if (text7 != null && text7.Length != 0)
					{
						method_42(cell, text7, text);
					}
					xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.None;
					if (xmlTextReader_0.NodeType == XmlNodeType.SignificantWhitespace)
					{
						xmlTextReader_0.Skip();
					}
				}
				else if (xmlTextReader_0.LocalName == "is")
				{
					if (text == "inlineStr" && class1610_0 != null)
					{
						int int_2 = class1610_0.method_0(xmlTextReader_0);
						class1301_0.method_5(cell, int_2);
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
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return int_1;
	}

	private void method_42(Cell cell_0, string string_2, string string_3)
	{
		switch (string_3)
		{
		case "b":
		{
			bool flag = string_2 == "1";
			cell_0.method_65(flag);
			break;
		}
		case "e":
			cell_0.method_65(string_2);
			break;
		case "str":
			if (!cell_0.IsFormula)
			{
				cell_0.PutValue(string_2);
			}
			else
			{
				cell_0.method_65(string_2);
			}
			break;
		case "s":
		{
			int num2 = Class1618.smethod_87(string_2);
			if (num2 >= 0)
			{
				class1547_0.workbook_0.Worksheets.class1301_0.method_5(cell_0, num2);
			}
			break;
		}
		case "n":
		{
			double num = Class1618.smethod_85(string_2);
			if (double.IsInfinity(num))
			{
				cell_0.method_65("#N/A");
			}
			else
			{
				cell_0.method_65(num);
			}
			break;
		}
		}
	}

	[Attribute0(true)]
	private void method_43(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		int int_ = -1;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "col")
				{
					int_ = method_44(xmlTextReader_0, int_);
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
	private int method_44(XmlTextReader xmlTextReader_0, int int_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return int_0;
		}
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		short num4 = -1;
		double double_ = -1.0;
		bool flag = false;
		bool isHidden = false;
		bool flag2 = false;
		bool flag3 = false;
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			string localName;
			if ((localName = xmlTextReader_0.LocalName) == null)
			{
				continue;
			}
			if (Class1742.dictionary_144 == null)
			{
				Class1742.dictionary_144 = new Dictionary<string, int>(9)
				{
					{ "min", 0 },
					{ "max", 1 },
					{ "width", 2 },
					{ "style", 3 },
					{ "hidden", 4 },
					{ "customWidth", 5 },
					{ "outlineLevel", 6 },
					{ "collapsed", 7 },
					{ "bestFit", 8 }
				};
			}
			if (Class1742.dictionary_144.TryGetValue(localName, out var value))
			{
				switch (value)
				{
				case 0:
					num = Class1618.smethod_87(xmlTextReader_0.Value) - 1;
					num2 = num;
					break;
				case 1:
					num2 = Class1618.smethod_87(xmlTextReader_0.Value) - 1;
					break;
				case 2:
					double_ = Class1618.smethod_85(xmlTextReader_0.Value);
					flag = true;
					break;
				case 3:
					num3 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 4:
					isHidden = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 6:
					num4 = Class1618.smethod_89(xmlTextReader_0.Value);
					break;
				case 7:
					flag2 = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				case 8:
					flag3 = Class1618.smethod_201(xmlTextReader_0.Value);
					break;
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
		ColumnCollection columns = worksheet_0.Cells.Columns;
		double width = columns.Width;
		double width2 = (flag ? method_45(double_) : width);
		int int_ = 15;
		if (num3 != -1)
		{
			object obj = class1547_0.hashtable_3[num3];
			if (obj != null)
			{
				int_ = (int)obj;
			}
		}
		for (int i = num; i <= num2; i++)
		{
			Column column = null;
			if (num2 < 16383)
			{
				column = ((num >= int_0) ? columns.method_6(i) : columns[i]);
			}
			else
			{
				column = columns.method_0();
				column.method_0(num);
			}
			if (flag)
			{
				column.Width = width2;
			}
			column.method_6(int_);
			if (num4 != -1)
			{
				column.method_4((byte)num4);
			}
			column.IsHidden = isHidden;
			column.method_15(flag2);
			column.method_17(flag3);
			if (num2 >= 16383)
			{
				break;
			}
		}
		if (int_0 <= num2)
		{
			return num2;
		}
		return int_0;
	}

	private double method_45(double double_0)
	{
		WorksheetCollection worksheets = class1547_0.workbook_0.Worksheets;
		int num = (int)(double_0 * (double)worksheets.method_72() + 0.5);
		int num2 = worksheets.method_72();
		int num3 = worksheets.method_71();
		int num4 = worksheets.method_73();
		double num5;
		if (num < num2 + num4)
		{
			num5 = 1.0 * (double)num / (double)(num2 + num4);
		}
		else
		{
			num5 = (double)(int)((double)(num - (int)((double)(num2 * num3) / 256.0 + 0.5)) * 100.0 / (double)num2 + 0.5) / 100.0;
			if (num5 > 255.0)
			{
				num5 = 255.0;
			}
		}
		return num5;
	}

	[Attribute0(true)]
	private void method_46(XmlTextReader xmlTextReader_0)
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
				if (xmlTextReader_0.LocalName == "sheetView")
				{
					method_47(xmlTextReader_0);
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
	private void method_47(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				if (xmlTextReader_0.LocalName == "showGridLines")
				{
					worksheet_0.IsGridlinesVisible = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "showRowColHeaders")
				{
					worksheet_0.IsRowColumnHeadersVisible = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "tabSelected")
				{
					worksheet_0.IsSelected = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "view")
				{
					worksheet_0.ViewType = Class1618.smethod_202(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "zoomScale")
				{
					worksheet_0.Zoom = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "zoomScaleNormal")
				{
					worksheet_0.method_39()[0] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "zoomScaleSheetLayoutView")
				{
					worksheet_0.method_39()[1] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "zoomScalePageLayoutView")
				{
					worksheet_0.method_39()[2] = Class1618.smethod_87(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "topLeftCell")
				{
					string value = xmlTextReader_0.Value;
					int row = 0;
					int column = 0;
					CellsHelper.CellNameToIndex(value, out row, out column);
					worksheet_0.FirstVisibleRow = row;
					worksheet_0.FirstVisibleColumn = column;
				}
				else if (xmlTextReader_0.LocalName == "showRuler")
				{
					worksheet_0.IsRulerVisible = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "showZeros")
				{
					worksheet_0.DisplayZeros = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "rightToLeft")
				{
					worksheet_0.DisplayRightToLeft = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "showOutlineSymbols")
				{
					worksheet_0.IsOutlineShown = Class1618.smethod_201(xmlTextReader_0.Value);
				}
				else if (!(xmlTextReader_0.LocalName == "defaultGridColor"))
				{
					if (xmlTextReader_0.LocalName == "colorId")
					{
						worksheet_0.method_45(Class1618.smethod_87(xmlTextReader_0.Value));
					}
					else if (xmlTextReader_0.LocalName == "showFormulas")
					{
						worksheet_0.method_12(Class1618.smethod_201(xmlTextReader_0.Value));
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		Class1566 @class = new Class1566();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "pane")
				{
					@class.class1567_0 = method_48(xmlTextReader_0);
				}
				else if (xmlTextReader_0.LocalName == "selection")
				{
					if (xmlTextReader_0.HasAttributes)
					{
						Class1568 class2 = new Class1568();
						class2.string_1 = xmlTextReader_0.GetAttribute("activeCell");
						class2.string_2 = xmlTextReader_0.GetAttribute("sqref");
						class2.string_0 = xmlTextReader_0.GetAttribute("pane");
						string attribute = xmlTextReader_0.GetAttribute("activeCellId");
						if (attribute != null)
						{
							class2.int_0 = Class1618.smethod_87(attribute);
						}
						@class.arrayList_0.Add(class2);
					}
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
		@class.method_0(worksheet_0);
	}

	[Attribute0(true)]
	private Class1567 method_48(XmlTextReader xmlTextReader_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			xmlTextReader_0.Skip();
			return null;
		}
		Class1567 @class = new Class1567();
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			if (!(xmlTextReader_0.NamespaceURI != ""))
			{
				if (xmlTextReader_0.LocalName == "activePane")
				{
					@class.string_2 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "state")
				{
					@class.string_0 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "topLeftCell")
				{
					@class.string_1 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "xSplit")
				{
					@class.double_0 = Class1618.smethod_85(xmlTextReader_0.Value);
				}
				else if (xmlTextReader_0.LocalName == "ySplit")
				{
					@class.double_1 = Class1618.smethod_85(xmlTextReader_0.Value);
				}
			}
		}
		xmlTextReader_0.MoveToElement();
		xmlTextReader_0.Skip();
		return @class;
	}

	[Attribute0(true)]
	private void method_49(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.None;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType == XmlNodeType.Element && !(xmlTextReader_0.LocalName != "worksheet"))
		{
			XmlNameTable nameTable = xmlTextReader_0.NameTable;
			string_0 = nameTable.Add(namespaceURI);
			string_1 = nameTable.Add("http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			if (!xmlTextReader_0.HasAttributes)
			{
				return;
			}
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (!(xmlTextReader_0.Name == "xmlns") && !(xmlTextReader_0.Name == "xmlns:r"))
				{
					worksheet_0.class1557_0.arrayList_0.Add(new Class927(xmlTextReader_0.Name, xmlTextReader_0.Value));
				}
			}
			xmlTextReader_0.MoveToElement();
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "worksheet root element eror");
	}

	internal void method_50(XmlTextReader xmlTextReader_0, bool bool_2)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		FormatConditionCollection formatConditionCollection = new FormatConditionCollection(worksheet_0);
		int index = 0;
		ArrayList arrayList = new ArrayList();
		bool flag = false;
		string attribute = xmlTextReader_0.GetAttribute("pivot", "");
		if (!bool_2)
		{
			string attribute2 = xmlTextReader_0.GetAttribute("sqref", "");
			if (attribute2 != null && attribute2.Length > 0)
			{
				method_28(attribute2, arrayList);
			}
			if (attribute == "1")
			{
				formatConditionCollection.arrayList_1.AddRange(arrayList);
			}
			else
			{
				formatConditionCollection.arrayList_1.AddRange(arrayList);
				index = worksheet_0.ConditionalFormattings.Add(formatConditionCollection);
				formatConditionCollection.conditionalFormattingCollection_0 = worksheet_0.ConditionalFormattings;
			}
			xmlTextReader_0.Read();
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				if (xmlTextReader_0.NodeType != XmlNodeType.Element)
				{
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "cfRule")
				{
					bool flag2 = method_54(xmlTextReader_0, formatConditionCollection, bool_2: false);
					if (!flag && flag2)
					{
						flag = true;
					}
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
			xmlTextReader_0.Read();
			while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
			{
				xmlTextReader_0.MoveToContent();
				if (xmlTextReader_0.NodeType != XmlNodeType.Element)
				{
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "cfRule")
				{
					bool flag3 = method_54(xmlTextReader_0, formatConditionCollection, bool_2: true);
					if (!flag && flag3)
					{
						flag = true;
					}
				}
				else if (xmlTextReader_0.LocalName == "sqref")
				{
					string text = xmlTextReader_0.ReadElementString();
					if (text != null && text.Length > 0)
					{
						method_28(text, arrayList);
					}
					if (attribute == "1")
					{
						formatConditionCollection.arrayList_1.AddRange(arrayList);
						continue;
					}
					formatConditionCollection.arrayList_1.AddRange(arrayList);
					if (formatConditionCollection.Count > 0)
					{
						index = worksheet_0.ConditionalFormattings.Add(formatConditionCollection);
						formatConditionCollection.conditionalFormattingCollection_0 = worksheet_0.ConditionalFormattings;
					}
				}
				else
				{
					xmlTextReader_0.Skip();
				}
			}
			xmlTextReader_0.ReadEndElement();
		}
		if (!flag)
		{
			worksheet_0.ConditionalFormattings.RemoveAt(index);
		}
		else if (method_51(formatConditionCollection))
		{
			method_52(formatConditionCollection);
		}
		if (!(attribute == "1") || worksheet_0.pivotTableCollection_0 == null || worksheet_0.pivotTableCollection_0.Count <= 0)
		{
			return;
		}
		PivotTable pivotTable = null;
		if (arrayList.Count > 0)
		{
			CellArea cellArea = (CellArea)arrayList[0];
			pivotTable = worksheet_0.pivotTableCollection_0[cellArea.StartRow, cellArea.StartColumn];
		}
		else
		{
			pivotTable = worksheet_0.pivotTableCollection_0[0];
		}
		if (pivotTable == null)
		{
			return;
		}
		PivotFormatConditionCollection pivotFormatConditions = pivotTable.PivotFormatConditions;
		if (pivotFormatConditions == null)
		{
			return;
		}
		for (int i = 0; i < pivotFormatConditions.Count; i++)
		{
			PivotFormatCondition pivotFormatCondition = pivotFormatConditions[i];
			if (formatConditionCollection.Count > 0 && pivotFormatCondition.int_0 == formatConditionCollection[0].Priority)
			{
				pivotFormatCondition.formatConditionCollection_0 = formatConditionCollection;
				pivotFormatCondition.formatConditionCollection_0.bool_1 = true;
			}
		}
	}

	private bool method_51(FormatConditionCollection formatConditionCollection_0)
	{
		if (formatConditionCollection_0.Count <= 1)
		{
			return false;
		}
		bool result = false;
		int priority = formatConditionCollection_0[0].Priority;
		for (int i = 1; i < formatConditionCollection_0.Count; i++)
		{
			FormatCondition formatCondition = formatConditionCollection_0[i];
			if (priority < formatCondition.Priority)
			{
				result = true;
			}
			else
			{
				priority = formatCondition.Priority;
			}
		}
		return result;
	}

	private void method_52(FormatConditionCollection formatConditionCollection_0)
	{
		int count = formatConditionCollection_0.Count;
		FormatCondition[] array = new FormatCondition[formatConditionCollection_0.Count];
		for (int i = 0; i < count; i++)
		{
			array[i] = formatConditionCollection_0[i];
		}
		IComparer comparer = new Class1191();
		Array.Sort(array, comparer);
		formatConditionCollection_0.method_0().Clear();
		for (int j = 0; j < count; j++)
		{
			formatConditionCollection_0.method_0().Add(array[j]);
		}
	}

	private void method_53(XmlTextReader xmlTextReader_0, FormatCondition formatCondition_0)
	{
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "ext")
			{
				xmlTextReader_0.Read();
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType != XmlNodeType.Element)
					{
						xmlTextReader_0.Skip();
					}
					else if (xmlTextReader_0.LocalName == "id")
					{
						formatCondition_0.method_3(xmlTextReader_0.ReadElementString());
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

	private bool method_54(XmlTextReader xmlTextReader_0, FormatConditionCollection formatConditionCollection_0, bool bool_2)
	{
		string text = null;
		OperatorType operatorType = OperatorType.None;
		bool stopIfTrue = false;
		string[] array = new string[2];
		int num = -1;
		int num2 = 0;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		string text6 = null;
		string text7 = null;
		string text8 = null;
		string text9 = null;
		string text10 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if ((localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_145 == null)
				{
					Class1742.dictionary_145 = new Dictionary<string, int>(14)
					{
						{ "priority", 0 },
						{ "type", 1 },
						{ "dxfId", 2 },
						{ "operator", 3 },
						{ "stopIfTrue", 4 },
						{ "text", 5 },
						{ "rank", 6 },
						{ "timePeriod", 7 },
						{ "percent", 8 },
						{ "bottom", 9 },
						{ "aboveAverage", 10 },
						{ "equalAverage", 11 },
						{ "stdDev", 12 },
						{ "id", 13 }
					};
				}
				if (!Class1742.dictionary_145.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					num2 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 1:
					text = xmlTextReader_0.Value;
					break;
				case 2:
					num = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case 3:
					if (text == "cellIs" || text == "expression")
					{
						operatorType = Class1618.smethod_30(xmlTextReader_0.Value);
					}
					break;
				case 4:
					stopIfTrue = true;
					break;
				case 5:
					text2 = xmlTextReader_0.Value;
					break;
				case 6:
					text4 = xmlTextReader_0.Value;
					break;
				case 7:
					text3 = xmlTextReader_0.Value;
					break;
				case 8:
					text5 = xmlTextReader_0.Value;
					break;
				case 9:
					text6 = xmlTextReader_0.Value;
					break;
				case 10:
					text7 = xmlTextReader_0.Value;
					break;
				case 11:
					text8 = xmlTextReader_0.Value;
					break;
				case 12:
					text9 = xmlTextReader_0.Value;
					break;
				case 13:
					text10 = xmlTextReader_0.Value;
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (Class1618.smethod_90(text))
		{
			FormatConditionType formatConditionType = Class1618.smethod_91(text);
			int index = 0;
			IconSet iconSet = null;
			ColorScale colorScale = null;
			DataBar dataBar = null;
			Style style = null;
			if (!xmlTextReader_0.IsEmptyElement)
			{
				xmlTextReader_0.Read();
				int num3 = 0;
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType != XmlNodeType.Element)
					{
						xmlTextReader_0.Skip();
					}
					else if ((xmlTextReader_0.LocalName == "formula" || xmlTextReader_0.LocalName == "f") && num3 < 2)
					{
						array[num3++] = "=" + xmlTextReader_0.ReadElementString();
					}
					else if (xmlTextReader_0.LocalName == "iconSet")
					{
						index = formatConditionCollection_0.AddCondition(formatConditionType);
						FormatCondition formatCondition = formatConditionCollection_0[index];
						iconSet = method_57(xmlTextReader_0, formatCondition);
						formatCondition.method_18(iconSet);
					}
					else if (xmlTextReader_0.LocalName == "colorScale")
					{
						index = formatConditionCollection_0.AddCondition(formatConditionType);
						FormatCondition formatCondition2 = formatConditionCollection_0[index];
						colorScale = method_58(xmlTextReader_0, formatCondition2);
						if (colorScale != null)
						{
							formatCondition2.method_20(colorScale);
						}
					}
					else if (xmlTextReader_0.LocalName == "dataBar")
					{
						if (!bool_2)
						{
							index = formatConditionCollection_0.AddCondition(formatConditionType);
							FormatCondition formatCondition3 = formatConditionCollection_0[index];
							dataBar = method_59(xmlTextReader_0, formatCondition3, bool_2);
							formatCondition3.method_19(dataBar);
							continue;
						}
						FormatCondition formatCondition4 = null;
						int count = worksheet_0.ConditionalFormattings.Count;
						if (count > 0)
						{
							for (int i = 0; i < count; i++)
							{
								FormatConditionCollection formatConditionCollection = worksheet_0.ConditionalFormattings[i];
								for (int j = 0; j < formatConditionCollection.Count; j++)
								{
									FormatCondition formatCondition5 = formatConditionCollection[j];
									if (formatCondition5.method_2() == text10)
									{
										formatCondition4 = formatCondition5;
										break;
									}
								}
								if (formatCondition4 != null)
								{
									break;
								}
							}
							if (formatCondition4 != null)
							{
								dataBar = method_59(xmlTextReader_0, formatCondition4, bool_2);
								formatCondition4.method_19(dataBar);
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
					else if (xmlTextReader_0.LocalName == "dxf")
					{
						Class1611 @class = new Class1611(class1548_0.class1547_0);
						Class1531 class1531_ = @class.method_33(xmlTextReader_0);
						style = new Style(worksheet_0.method_2());
						smethod_9(style, class1531_);
					}
					else if (xmlTextReader_0.LocalName == "extLst" && !bool_2)
					{
						FormatCondition formatCondition6 = formatConditionCollection_0[index];
						if (formatCondition6.Type == FormatConditionType.DataBar)
						{
							method_53(xmlTextReader_0, formatCondition6);
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
			else
			{
				xmlTextReader_0.Skip();
			}
			switch (formatConditionType)
			{
			default:
			{
				index = formatConditionCollection_0.AddCondition(formatConditionType);
				FormatCondition formatCondition7 = formatConditionCollection_0[index];
				switch (formatConditionType)
				{
				case FormatConditionType.Top10:
					if (text4 != null)
					{
						formatCondition7.Top10.Rank = Class1618.smethod_87(text4);
					}
					if (text6 == "1")
					{
						formatCondition7.Top10.IsBottom = true;
					}
					if (text5 == "1")
					{
						formatCondition7.Top10.IsPercent = true;
					}
					break;
				case FormatConditionType.AboveAverage:
					if (text7 == "0")
					{
						formatCondition7.AboveAverage.IsAboveAverage = false;
					}
					if (text8 == "1")
					{
						formatCondition7.AboveAverage.IsEqualAverage = true;
					}
					if (text9 != null)
					{
						formatCondition7.AboveAverage.StdDev = Class1618.smethod_87(text9);
					}
					break;
				}
				if (text2 != null)
				{
					formatCondition7.Text = text2;
				}
				if (text3 != null)
				{
					formatCondition7.TimePeriod = Class1618.smethod_143(text3);
				}
				if (array[0] != null)
				{
					formatCondition7.Formula1 = array[0];
				}
				if (array[1] != null)
				{
					formatCondition7.Formula2 = array[1];
				}
				break;
			}
			case FormatConditionType.CellValue:
			case FormatConditionType.Expression:
				index = formatConditionCollection_0.AddCondition(formatConditionType, operatorType, array[0], array[1]);
				break;
			case FormatConditionType.ColorScale:
			case FormatConditionType.DataBar:
			case FormatConditionType.IconSet:
				break;
			}
			if (formatConditionCollection_0.Count > 0)
			{
				formatConditionCollection_0[index].StopIfTrue = stopIfTrue;
				formatConditionCollection_0[index].Priority = (short)num2;
				if (num != -1 && num < worksheet_0.method_2().method_56().Count)
				{
					formatConditionCollection_0[index].method_7(num);
					formatConditionCollection_0[index].Style = new Style(worksheet_0.method_2());
					formatConditionCollection_0[index].Style.Copy(worksheet_0.method_2().method_56()[num]);
				}
				else if (style != null)
				{
					formatConditionCollection_0[index].Style = style;
				}
			}
			if (num2 > formatConditionCollection_0.worksheet_0.method_3())
			{
				formatConditionCollection_0.worksheet_0.method_4(num2);
			}
			return true;
		}
		xmlTextReader_0.Skip();
		return false;
	}

	private void method_55(XmlTextReader xmlTextReader_0, ConditionalFormattingIcon conditionalFormattingIcon_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("iconSet");
		string attribute2 = xmlTextReader_0.GetAttribute("iconId");
		conditionalFormattingIcon_0.Type = Class1618.smethod_135(attribute);
		conditionalFormattingIcon_0.Index = Convert.ToInt32(attribute2);
		xmlTextReader_0.Skip();
	}

	private ConditionalFormattingValue method_56(XmlTextReader xmlTextReader_0, FormatCondition formatCondition_0)
	{
		ConditionalFormattingValue conditionalFormattingValue = new ConditionalFormattingValue(formatCondition_0);
		string attribute = xmlTextReader_0.GetAttribute("gte");
		if (attribute == "0")
		{
			conditionalFormattingValue.IsGTE = false;
		}
		string attribute2 = xmlTextReader_0.GetAttribute("type");
		conditionalFormattingValue.Type = Class1618.smethod_141(attribute2);
		if (xmlTextReader_0.Prefix == "x14")
		{
			if (conditionalFormattingValue.Type != FormatConditionValueType.Min && conditionalFormattingValue.Type != FormatConditionValueType.Max && conditionalFormattingValue.Type != FormatConditionValueType.AutomaticMax && conditionalFormattingValue.Type != FormatConditionValueType.AutomaticMin)
			{
				xmlTextReader_0.Read();
				while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
				{
					xmlTextReader_0.MoveToContent();
					if (xmlTextReader_0.NodeType != XmlNodeType.Element)
					{
						xmlTextReader_0.Skip();
					}
					else if (xmlTextReader_0.LocalName == "f")
					{
						conditionalFormattingValue.method_4(xmlTextReader_0.ReadElementString());
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
				if (xmlTextReader_0.GetAttribute("type") != null)
				{
					conditionalFormattingValue.Type = Class1618.smethod_141(xmlTextReader_0.GetAttribute("type"));
				}
				xmlTextReader_0.Skip();
			}
		}
		else
		{
			if (xmlTextReader_0.GetAttribute("val") != null)
			{
				conditionalFormattingValue.method_4(xmlTextReader_0.GetAttribute("val"));
			}
			xmlTextReader_0.Skip();
		}
		return conditionalFormattingValue;
	}

	private IconSet method_57(XmlTextReader xmlTextReader_0, FormatCondition formatCondition_0)
	{
		IconSet iconSet = new IconSet(formatCondition_0);
		string attribute = xmlTextReader_0.GetAttribute("iconSet");
		string attribute2 = xmlTextReader_0.GetAttribute("showValue");
		string attribute3 = xmlTextReader_0.GetAttribute("reverse");
		if (attribute != null)
		{
			iconSet.method_2(Class1618.smethod_135(attribute));
		}
		if (attribute2 == "0")
		{
			iconSet.ShowValue = false;
		}
		if (attribute3 == "1")
		{
			iconSet.Reverse = true;
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return iconSet;
		}
		int num = 0;
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "cfvo")
			{
				ConditionalFormattingValue conditionalFormattingValue_ = method_56(xmlTextReader_0, formatCondition_0);
				iconSet.Cfvos.Add(conditionalFormattingValue_);
			}
			else if (xmlTextReader_0.LocalName == "cfIcon")
			{
				ConditionalFormattingIcon conditionalFormattingIcon_ = iconSet.CfIcons[num];
				method_55(xmlTextReader_0, conditionalFormattingIcon_);
				num++;
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return iconSet;
	}

	private ColorScale method_58(XmlTextReader xmlTextReader_0, FormatCondition formatCondition_0)
	{
		ColorScale colorScale = new ColorScale(worksheet_0.method_2().Workbook, formatCondition_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return null;
		}
		ConditionalFormattingValueCollection conditionalFormattingValueCollection = new ConditionalFormattingValueCollection(formatCondition_0);
		ArrayList arrayList = new ArrayList(3);
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_0))
			{
				if (xmlTextReader_0.LocalName == "cfvo")
				{
					ConditionalFormattingValue conditionalFormattingValue_ = method_56(xmlTextReader_0, formatCondition_0);
					conditionalFormattingValueCollection.Add(conditionalFormattingValue_);
				}
				else if (xmlTextReader_0.LocalName == "color")
				{
					InternalColor value = Class1611.smethod_2(xmlTextReader_0, class1547_0);
					arrayList.Add(value);
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
		if (conditionalFormattingValueCollection.Count == 2)
		{
			colorScale.conditionalFormattingValue_0 = conditionalFormattingValueCollection[0];
			colorScale.conditionalFormattingValue_2 = conditionalFormattingValueCollection[1];
			colorScale.method_2((InternalColor)arrayList[0]);
			colorScale.method_6((InternalColor)arrayList[1]);
		}
		else if (conditionalFormattingValueCollection.Count == 3)
		{
			colorScale.conditionalFormattingValue_0 = conditionalFormattingValueCollection[0];
			colorScale.conditionalFormattingValue_1 = conditionalFormattingValueCollection[1];
			colorScale.conditionalFormattingValue_2 = conditionalFormattingValueCollection[2];
			colorScale.method_2((InternalColor)arrayList[0]);
			colorScale.method_4((InternalColor)arrayList[1]);
			colorScale.method_6((InternalColor)arrayList[2]);
		}
		else
		{
			colorScale = null;
		}
		return colorScale;
	}

	private DataBar method_59(XmlTextReader xmlTextReader_0, FormatCondition formatCondition_0, bool bool_2)
	{
		DataBar dataBar = null;
		dataBar = (bool_2 ? formatCondition_0.DataBar : new DataBar(worksheet_0.method_2().Workbook, formatCondition_0));
		string attribute = xmlTextReader_0.GetAttribute("gradient");
		string attribute2 = xmlTextReader_0.GetAttribute("border");
		string attribute3 = xmlTextReader_0.GetAttribute("direction");
		string attribute4 = xmlTextReader_0.GetAttribute("negativeBarColorSameAsPositive");
		string attribute5 = xmlTextReader_0.GetAttribute("negativeBarBorderColorSameAsPositive");
		string attribute6 = xmlTextReader_0.GetAttribute("axisPosition");
		string attribute7 = xmlTextReader_0.GetAttribute("minLength");
		string attribute8 = xmlTextReader_0.GetAttribute("maxLength");
		string attribute9 = xmlTextReader_0.GetAttribute("showValue");
		if (attribute == null)
		{
			dataBar.BarFillType = DataBarFillType.DataBarFillGradient;
		}
		else
		{
			dataBar.BarFillType = DataBarFillType.DataBarFillSolid;
		}
		if (attribute2 != null)
		{
			dataBar.BarBorder.Type = DataBarBorderType.DataBarBorderSolid;
		}
		else
		{
			dataBar.BarBorder.Type = DataBarBorderType.DataBarBorderNone;
		}
		if (attribute3 != null)
		{
			dataBar.Direction = Class1618.smethod_137(attribute3);
		}
		if (attribute6 != null)
		{
			dataBar.AxisPosition = Class1618.smethod_139(attribute6);
		}
		if (attribute4 != null)
		{
			dataBar.NegativeBarFormat.ColorType = DataBarNegativeColorType.DataBarSameAsPositive;
		}
		else
		{
			dataBar.NegativeBarFormat.ColorType = DataBarNegativeColorType.DataBarColor;
		}
		if (attribute5 != null)
		{
			dataBar.NegativeBarFormat.BorderColorType = DataBarNegativeColorType.DataBarColor;
		}
		else
		{
			dataBar.NegativeBarFormat.BorderColorType = DataBarNegativeColorType.DataBarSameAsPositive;
		}
		if (attribute7 != null)
		{
			dataBar.MinLength = Class1618.smethod_87(attribute7);
		}
		if (attribute8 != null)
		{
			dataBar.MaxLength = Class1618.smethod_87(attribute8);
		}
		if (attribute9 == "0")
		{
			dataBar.ShowValue = false;
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return dataBar;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType != XmlNodeType.Element)
			{
				xmlTextReader_0.Skip();
			}
			else if (xmlTextReader_0.LocalName == "cfvo")
			{
				ConditionalFormattingValue conditionalFormattingValue = method_56(xmlTextReader_0, formatCondition_0);
				if (conditionalFormattingValue.Type == FormatConditionValueType.AutomaticMin)
				{
					dataBar.conditionalFormattingValue_0 = null;
				}
				if (dataBar.conditionalFormattingValue_0 == null)
				{
					dataBar.conditionalFormattingValue_0 = conditionalFormattingValue;
				}
				else
				{
					dataBar.conditionalFormattingValue_1 = conditionalFormattingValue;
				}
			}
			else if (xmlTextReader_0.LocalName == "color")
			{
				dataBar.method_5(Class1611.smethod_2(xmlTextReader_0, class1547_0));
			}
			else if (xmlTextReader_0.LocalName == "negativeBorderColor")
			{
				dataBar.NegativeBarFormat.method_1(Class1611.smethod_2(xmlTextReader_0, class1547_0));
			}
			else if (xmlTextReader_0.LocalName == "negativeFillColor")
			{
				dataBar.NegativeBarFormat.method_3(Class1611.smethod_2(xmlTextReader_0, class1547_0));
			}
			else if (xmlTextReader_0.LocalName == "axisColor")
			{
				dataBar.method_1(Class1611.smethod_2(xmlTextReader_0, class1547_0));
			}
			else if (xmlTextReader_0.LocalName == "borderColor")
			{
				dataBar.BarBorder.method_1(Class1611.smethod_2(xmlTextReader_0, class1547_0));
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		return dataBar;
	}

	internal static void smethod_9(Style style_0, Class1531 class1531_0)
	{
		if (class1531_0.class1535_0 != null)
		{
			if (class1531_0.class1535_0.class1528_0 != null)
			{
				Class1528.smethod_1(class1531_0.class1535_0.class1528_0, style_0);
			}
			else if (class1531_0.class1535_0.class1561_0 != null)
			{
				class1531_0.class1535_0.class1561_0.method_0(style_0);
			}
		}
		if (class1531_0.class1542_0 != null)
		{
			class1531_0.class1542_0.method_18(style_0);
		}
		if (class1531_0.class1526_0 != null)
		{
			class1531_0.class1526_0.method_1(style_0);
		}
		if (class1531_0.class639_0 != null)
		{
			Class639 class639_ = class1531_0.class639_0;
			if (class639_.Index > 0)
			{
				style_0.Number = class639_.Index;
			}
			if (class639_.Custom != null && class639_.Custom.Length > 0)
			{
				style_0.Custom = class639_.Custom;
			}
		}
		if (class1531_0.class1525_0 != null)
		{
			class1531_0.class1525_0.method_1(style_0, bool_2: true);
		}
		if (class1531_0.class1563_0 != null)
		{
			class1531_0.class1563_0.method_1(style_0);
		}
	}

	private static void smethod_10(string szFormulaRange, out int rownum, out int colnum)
	{
		int i;
		for (i = 0; i < szFormulaRange.Length && szFormulaRange[i] != ':'; i++)
		{
		}
		if (i == szFormulaRange.Length)
		{
			rownum = 1;
			colnum = 1;
			return;
		}
		int row = 0;
		int row2 = 0;
		int column = 0;
		int column2 = 0;
		CellsHelper.CellNameToIndex(szFormulaRange.Substring(0, i), out row, out column);
		CellsHelper.CellNameToIndex(szFormulaRange.Substring(i + 1), out row2, out column2);
		rownum = row2 - row + 1;
		colnum = column2 - column + 1;
	}
}
