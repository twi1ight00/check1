using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using Aspose.Cells.Tables;
using ns1;
using ns12;
using ns2;
using ns22;
using ns45;

namespace ns16;

internal class Class1101
{
	private string string_0;

	private Class1142 class1142_0;

	private Class1141 class1141_0;

	private Worksheet worksheet_0;

	private Workbook workbook_0;

	private string string_1;

	private Class746 class746_0;

	private Class1547 class1547_0;

	private string string_2;

	private string string_3;

	private string string_4;

	[SpecialName]
	public Class1141 method_0()
	{
		return class1141_0;
	}

	internal Class1101(Class1547 class1547_1, string string_5, string string_6, Class746 class746_1, string string_7)
	{
		class1547_0 = class1547_1;
		string_0 = string_5;
		class1142_0 = class1547_1.workbook_0.Worksheets.method_89();
		workbook_0 = class1547_1.workbook_0;
		string_3 = string_6;
		class746_0 = class746_1;
		string_4 = string_7;
	}

	internal void Read(XmlTextReader xmlTextReader_0)
	{
		class1141_0 = new Class1141(class1142_0);
		class1141_0.int_6 = Class1618.smethod_87(string_3);
		class1141_0.int_7 = class1142_0.Count;
		class1141_0.string_4 = string_4;
		class1142_0.method_1(class1141_0);
		if (class1141_0.int_6 > class1142_0.int_0)
		{
			class1142_0.int_0 = class1141_0.int_6;
		}
		method_22(xmlTextReader_0);
		if (xmlTextReader_0.IsEmptyElement)
		{
			return;
		}
		if (xmlTextReader_0.LocalName == "pivotCacheDefinition" && xmlTextReader_0.NodeType == XmlNodeType.Element)
		{
			method_14(xmlTextReader_0);
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "cacheSource" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_15(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "cacheFields" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_7(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "calculatedItems" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_2(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "extLst" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				class1141_0.string_5 = xmlTextReader_0.ReadOuterXml();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	internal void method_1()
	{
		Hashtable hashtable = class1547_0.method_6();
		if (hashtable != null && string_2 != null)
		{
			if (!hashtable.ContainsKey(string_2))
			{
				throw new CellsException(ExceptionType.InvalidData, "pivotCacheRecord rid " + string_2 + " not found in pivotCache rels file");
			}
			Class1564 @class = (Class1564)hashtable[string_2];
			Class1102 class2 = new Class1102(class1547_0, class1141_0, @class.string_3, class746_0);
			string text = "xl/pivotCache/" + Path.GetFileName(@class.string_3);
			XmlTextReader xmlTextReader = Class1615.smethod_1(class746_0, text);
			if (xmlTextReader != null)
			{
				class2.Read(xmlTextReader);
			}
		}
	}

	[Attribute0(true)]
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
			if (xmlTextReader_0.LocalName == "calculatedItem" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_3(xmlTextReader_0);
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
		Class1148 @class = new Class1148(class1141_0);
		if (class1141_0.class988_0 == null)
		{
			class1141_0.class988_0 = new Class988();
		}
		class1141_0.class988_0.Add(@class);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (!(xmlTextReader_0.NamespaceURI != "") && (localName = xmlTextReader_0.LocalName) != null && localName == "formula")
				{
					string text = xmlTextReader_0.Value;
					if (!text.StartsWith("="))
					{
						text = "=" + text;
					}
					@class.SetFormula(text);
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
			if (xmlTextReader_0.LocalName == "pivotArea" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_4(xmlTextReader_0, @class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_4(XmlTextReader xmlTextReader_0, Class1148 class1148_0)
	{
		Class1171 @class = (class1148_0.class1171_0 = new Class1171());
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				switch (xmlTextReader_0.LocalName)
				{
				case "fieldPosition":
					@class.byte_0 = (byte)Class1618.smethod_89(xmlTextReader_0.Value);
					break;
				case "outline":
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_15(bool_1: true);
					}
					else
					{
						@class.method_15(bool_1: false);
					}
					break;
				case "cacheIndex":
					if (xmlTextReader_0.Value == "1")
					{
						@class.method_9(bool_1: true);
					}
					break;
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
			{
				if (xmlTextReader_0.LocalName == "references" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_5(xmlTextReader_0, @class, class1148_0);
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
	private void method_5(XmlTextReader xmlTextReader_0, Class1171 class1171_0, Class1148 class1148_0)
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
			if (xmlTextReader_0.LocalName == "reference" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_6(xmlTextReader_0, class1171_0, class1148_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_6(XmlTextReader xmlTextReader_0, Class1171 class1171_0, Class1148 class1148_0)
	{
		Class1162 @class = new Class1162();
		class1171_0.arrayList_0.Add(@class);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (!(xmlTextReader_0.NamespaceURI != "") && (localName = xmlTextReader_0.LocalName) != null && localName == "field")
				{
					@class.method_2((ushort)Class1618.smethod_89(xmlTextReader_0.Value));
					class1148_0.method_1(Class1618.smethod_89(xmlTextReader_0.Value));
					@class.ushort_1 = (ushort)((uint)class1148_0.method_0() | 0x400u);
					@class.Function = 1;
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
			{
				if (xmlTextReader_0.LocalName == "x" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					string attribute = xmlTextReader_0.GetAttribute("v");
					if (@class.arrayList_0 == null)
					{
						@class.arrayList_0 = new ArrayList();
					}
					@class.arrayList_0.Add(Class1618.smethod_87(attribute));
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
	private void method_7(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (!(xmlTextReader_0.NamespaceURI != "") && (localName = xmlTextReader_0.LocalName) != null && localName == "count")
				{
					Class1618.smethod_87(xmlTextReader_0.Value);
					class1141_0.int_1 = 0;
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
			if (xmlTextReader_0.LocalName == "cacheField" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_8(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		int int_ = Math.Max(class1141_0.int_3, class1141_0.int_4);
		class1141_0.class1144_0 = new Class1144(class1141_0, int_, class1141_0.int_1);
	}

	[Attribute0(true)]
	private void method_8(XmlTextReader xmlTextReader_0)
	{
		Class1161 @class = new Class1161(class1141_0);
		class1141_0.int_1++;
		@class.method_13(bool_2: true);
		if (class1141_0.arrayList_0 == null)
		{
			class1141_0.arrayList_0 = new ArrayList();
		}
		class1141_0.arrayList_0.Add(@class);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.NamespaceURI != "")
				{
					continue;
				}
				switch (xmlTextReader_0.LocalName)
				{
				case "formula":
					@class.method_19(bool_2: true);
					@class.string_1 = "=" + xmlTextReader_0.Value;
					@class.arrayList_1 = new ArrayList();
					try
					{
						WorksheetCollection worksheetCollection_ = class1142_0.worksheetCollection_0;
						worksheetCollection_.method_3(class1141_0);
						@class.byte_0 = worksheetCollection_.Formula.method_3(@class.string_1, 0, 0, Enum226.const_0, Enum227.const_1, bool_0: false, bool_1: false);
						worksheetCollection_.method_3(null);
					}
					catch (Exception)
					{
					}
					break;
				case "databaseField":
					if (xmlTextReader_0.Value == "0")
					{
						@class.bool_0 = true;
						class1141_0.int_1--;
					}
					break;
				case "name":
					@class.string_0 = xmlTextReader_0.Value;
					if (@class.method_2() && !@class.method_18())
					{
						@class.arrayList_0 = new ArrayList();
					}
					break;
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
			if (xmlTextReader_0.LocalName == "sharedItems" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_13(xmlTextReader_0, @class);
			}
			else if (xmlTextReader_0.LocalName == "fieldGroup" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_9(xmlTextReader_0, @class);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_9(XmlTextReader xmlTextReader_0, Class1161 class1161_0)
	{
		SxRng sxRng = (class1161_0.sxRng_0 = new SxRng(class1161_0));
		class1161_0.method_21(bool_2: true);
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				switch (xmlTextReader_0.LocalName)
				{
				case "par":
					sxRng.int_1 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
				case "base":
					sxRng.int_0 = Class1618.smethod_87(xmlTextReader_0.Value);
					break;
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
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
			{
				if (xmlTextReader_0.LocalName == "rangePr" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_11(xmlTextReader_0, sxRng);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "discretePr" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_10(xmlTextReader_0, sxRng);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "groupItems" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					method_12(xmlTextReader_0, sxRng);
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
	private void method_10(XmlTextReader xmlTextReader_0, SxRng sxRng_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		sxRng_0.arrayList_1 = new ArrayList();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
			{
				if (xmlTextReader_0.LocalName == "x" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					sxRng_0.arrayList_1.Add(xmlTextReader_0.GetAttribute("v"));
					xmlTextReader_0.Skip();
				}
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
	}

	[Attribute0(true)]
	private void method_11(XmlTextReader xmlTextReader_0, SxRng sxRng_0)
	{
		if (!xmlTextReader_0.HasAttributes)
		{
			return;
		}
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			string localName;
			if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
			{
				continue;
			}
			if (Class1742.dictionary_34 == null)
			{
				Class1742.dictionary_34 = new Dictionary<string, int>(8)
				{
					{ "groupBy", 0 },
					{ "autoEnd", 1 },
					{ "autoStart", 2 },
					{ "startDate", 3 },
					{ "endDate", 4 },
					{ "startNum", 5 },
					{ "endNum", 6 },
					{ "groupInterval", 7 }
				};
			}
			if (!Class1742.dictionary_34.TryGetValue(localName, out var value))
			{
				continue;
			}
			switch (value)
			{
			case 0:
				sxRng_0.pivotGroupByType_0 = Class1618.smethod_237(xmlTextReader_0.Value);
				break;
			case 1:
				if (xmlTextReader_0.Value == "1")
				{
					sxRng_0.bool_1 = true;
				}
				else
				{
					sxRng_0.bool_1 = false;
				}
				break;
			case 2:
				if (xmlTextReader_0.Value == "1")
				{
					sxRng_0.bool_0 = true;
				}
				else
				{
					sxRng_0.bool_0 = false;
				}
				break;
			case 3:
				sxRng_0.dateTime_0 = DateTime.Parse(xmlTextReader_0.Value);
				break;
			case 4:
				sxRng_0.dateTime_1 = DateTime.Parse(xmlTextReader_0.Value);
				break;
			case 5:
				sxRng_0.double_0 = Class1618.smethod_85(xmlTextReader_0.Value);
				break;
			case 6:
				sxRng_0.double_1 = Class1618.smethod_85(xmlTextReader_0.Value);
				break;
			case 7:
				sxRng_0.double_2 = Class1618.smethod_85(xmlTextReader_0.Value);
				break;
			}
		}
		xmlTextReader_0.MoveToElement();
	}

	[Attribute0(true)]
	private void method_12(XmlTextReader xmlTextReader_0, SxRng sxRng_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		sxRng_0.arrayList_0 = new ArrayList();
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
			{
				if (xmlTextReader_0.LocalName == "s" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 @class = new Class1158();
					@class.object_0 = xmlTextReader_0.GetAttribute("v");
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						@class.bool_0 = true;
					}
					sxRng_0.arrayList_0.Add(@class);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "n" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class2 = new Class1158();
					class2.object_0 = Class1618.smethod_85(xmlTextReader_0.GetAttribute("v"));
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class2.bool_0 = true;
					}
					sxRng_0.arrayList_0.Add(class2);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "d" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class3 = new Class1158();
					class3.object_0 = Convert.ToDateTime(xmlTextReader_0.GetAttribute("v"));
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class3.bool_0 = true;
					}
					sxRng_0.arrayList_0.Add(class3);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "b" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class4 = new Class1158();
					class4.object_0 = xmlTextReader_0.GetAttribute("v") == "1";
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class4.bool_0 = true;
					}
					sxRng_0.arrayList_0.Add(class4);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "m" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class5 = new Class1158();
					class5.object_0 = null;
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class5.bool_0 = true;
					}
					sxRng_0.arrayList_0.Add(class5);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "e" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class6 = new Class1158();
					class6.object_0 = xmlTextReader_0.GetAttribute("v");
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class6.bool_0 = true;
					}
					sxRng_0.arrayList_0.Add(class6);
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
	private void method_13(XmlTextReader xmlTextReader_0, Class1161 class1161_0)
	{
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_35 == null)
				{
					Class1742.dictionary_35 = new Dictionary<string, int>(9)
					{
						{ "containsBlank", 0 },
						{ "containsDate", 1 },
						{ "containsMixedTypes", 2 },
						{ "containsNumber", 3 },
						{ "containsInteger", 4 },
						{ "containsNonDate", 5 },
						{ "containsString", 6 },
						{ "containsSemiMixedTypes", 7 },
						{ "longText", 8 }
					};
				}
				if (!Class1742.dictionary_35.TryGetValue(localName, out var value))
				{
					continue;
				}
				switch (value)
				{
				case 0:
					if (xmlTextReader_0.Value == "1")
					{
						class1161_0.method_30(bool_2: true);
					}
					else
					{
						class1161_0.method_30(bool_2: false);
					}
					break;
				case 1:
					if (xmlTextReader_0.Value == "1")
					{
						class1161_0.method_15(bool_2: true);
					}
					else
					{
						class1161_0.method_15(bool_2: false);
					}
					break;
				case 3:
					if (xmlTextReader_0.Value == "1")
					{
						class1161_0.method_7(bool_2: true);
					}
					else
					{
						class1161_0.method_7(bool_2: false);
					}
					break;
				case 4:
					if (xmlTextReader_0.Value == "1")
					{
						class1161_0.method_9(bool_2: true);
					}
					else
					{
						class1161_0.method_9(bool_2: false);
					}
					break;
				case 6:
					if (xmlTextReader_0.Value == "1")
					{
						class1161_0.method_13(bool_2: true);
					}
					else
					{
						class1161_0.method_13(bool_2: false);
					}
					break;
				case 8:
					if (xmlTextReader_0.Value == "1")
					{
						class1161_0.bool_1 = true;
					}
					else
					{
						class1161_0.bool_1 = false;
					}
					break;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		if (xmlTextReader_0.IsEmptyElement)
		{
			class1161_0.method_3(bool_2: false);
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.NodeType == XmlNodeType.Element && object.ReferenceEquals(xmlTextReader_0.NamespaceURI, string_1))
			{
				class1161_0.method_3(bool_2: true);
				if (xmlTextReader_0.LocalName == "s" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 @class = new Class1158();
					string attribute = xmlTextReader_0.GetAttribute("v");
					@class.object_0 = Class1618.smethod_8(attribute);
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						@class.bool_0 = true;
					}
					class1161_0.arrayList_0.Add(@class);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "n" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class2 = new Class1158();
					string attribute2 = xmlTextReader_0.GetAttribute("v");
					if ((attribute2.Length > 16 || attribute2.IndexOf('.') == -1) && attribute2.IndexOf("e") == -1 && attribute2.IndexOf("E") == -1)
					{
						class2.object_0 = (double)Class1618.smethod_86(attribute2);
					}
					else
					{
						class2.object_0 = Class1618.smethod_85(attribute2);
					}
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class2.bool_0 = true;
					}
					class1161_0.arrayList_0.Add(class2);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "d" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class3 = new Class1158();
					class3.object_0 = Convert.ToDateTime(xmlTextReader_0.GetAttribute("v"));
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class3.bool_0 = true;
					}
					class1161_0.arrayList_0.Add(class3);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "b" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class4 = new Class1158();
					class4.object_0 = xmlTextReader_0.GetAttribute("v") == "1";
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class4.bool_0 = true;
					}
					class1161_0.arrayList_0.Add(class4);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "m" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class5 = new Class1158();
					class5.object_0 = null;
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class5.bool_0 = true;
					}
					class1161_0.arrayList_0.Add(class5);
					xmlTextReader_0.Skip();
				}
				else if (xmlTextReader_0.LocalName == "e" && xmlTextReader_0.NodeType == XmlNodeType.Element)
				{
					Class1158 class6 = new Class1158();
					class6.object_0 = xmlTextReader_0.GetAttribute("v");
					if (xmlTextReader_0.GetAttribute("f") == "1")
					{
						class6.bool_0 = true;
					}
					class1161_0.arrayList_0.Add(class6);
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
	private void method_14(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		class1141_0.method_14(bool_2: true, 1);
		if (!xmlTextReader_0.HasAttributes)
		{
			return;
		}
		while (xmlTextReader_0.MoveToNextAttribute())
		{
			switch (xmlTextReader_0.LocalName)
			{
			case "missingItemsLimit":
				class1141_0.int_9 = Class1618.smethod_87(xmlTextReader_0.Value);
				break;
			case "recordCount":
				class1141_0.int_4 = Class1618.smethod_87(xmlTextReader_0.Value);
				break;
			case "saveData":
				if (xmlTextReader_0.Value == "0")
				{
					class1141_0.method_14(bool_2: false, 1);
				}
				break;
			case "refreshOnLoad":
				if (xmlTextReader_0.Value == "1")
				{
					class1141_0.method_13(bool_2: true);
				}
				break;
			case "createdVersion":
				class1141_0.string_2 = xmlTextReader_0.Value;
				break;
			case "id":
				string_2 = xmlTextReader_0.Value;
				break;
			}
		}
		xmlTextReader_0.MoveToElement();
	}

	private void method_15(XmlTextReader xmlTextReader_0)
	{
		string attribute = xmlTextReader_0.GetAttribute("type");
		class1141_0.pivotTableSourceType_0 = Class1618.smethod_147(attribute);
		if (class1141_0.pivotTableSourceType_0 != PivotTableSourceType.ListDatabase && class1141_0.pivotTableSourceType_0 != PivotTableSourceType.Consilidation)
		{
			Class1562 @class = new Class1562();
			@class.string_1 = string_0;
			@class.string_0 = string_3;
			workbook_0.class1558_0.class1364_0.arrayList_1.Add(@class);
			class1141_0.bool_1 = true;
			xmlTextReader_0.Skip();
			return;
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
			if (xmlTextReader_0.LocalName == "worksheetSource" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_21(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "consolidation" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_16(xmlTextReader_0);
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_16(XmlTextReader xmlTextReader_0)
	{
		if (xmlTextReader_0.GetAttribute("autoPage") == "0")
		{
			class1141_0.bool_0 = false;
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
			if (xmlTextReader_0.LocalName == "pages" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_18(xmlTextReader_0);
			}
			else if (xmlTextReader_0.LocalName == "rangeSets" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_17(xmlTextReader_0);
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
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = Class1618.smethod_87(xmlTextReader_0.GetAttribute("count"));
		class1141_0.int_0 = new int[num2][];
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "rangeSet" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_20(xmlTextReader_0, arrayList, num);
				num++;
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
		if (arrayList.Count != 0)
		{
			class1141_0.class1139_0 = new Class1139[arrayList.Count];
			for (int i = 0; i < arrayList.Count; i++)
			{
				class1141_0.class1139_0[i] = (Class1139)arrayList[i];
			}
		}
	}

	[Attribute0(true)]
	private void method_18(XmlTextReader xmlTextReader_0)
	{
		int num = 0;
		int num2 = Class1618.smethod_87(xmlTextReader_0.GetAttribute("count"));
		if (!class1141_0.bool_0)
		{
			class1141_0.string_0 = new string[num2][];
		}
		else
		{
			class1141_0.string_0 = new string[1][];
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
			if (xmlTextReader_0.LocalName == "page" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				method_19(xmlTextReader_0, num);
				num++;
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	[Attribute0(true)]
	private void method_19(XmlTextReader xmlTextReader_0, int int_0)
	{
		int num = 0;
		int num2 = Class1618.smethod_87(xmlTextReader_0.GetAttribute("count"));
		string[] array = (class1141_0.string_0[int_0] = new string[num2]);
		if (xmlTextReader_0.IsEmptyElement)
		{
			xmlTextReader_0.Skip();
			return;
		}
		xmlTextReader_0.Read();
		while (xmlTextReader_0.NodeType != XmlNodeType.EndElement)
		{
			xmlTextReader_0.MoveToContent();
			if (xmlTextReader_0.LocalName == "pageItem" && xmlTextReader_0.NodeType == XmlNodeType.Element)
			{
				array[num] = xmlTextReader_0.GetAttribute("name");
				num++;
				xmlTextReader_0.Skip();
			}
			else
			{
				xmlTextReader_0.Skip();
			}
		}
		xmlTextReader_0.ReadEndElement();
	}

	private void method_20(XmlTextReader xmlTextReader_0, ArrayList arrayList_0, int int_0)
	{
		Class1139 @class = null;
		string address = null;
		string text = null;
		string text2 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			if (xmlTextReader_0.GetAttribute("i4") != null)
			{
				class1141_0.int_0[int_0] = new int[4];
			}
			else if (xmlTextReader_0.GetAttribute("i3") != null)
			{
				class1141_0.int_0[int_0] = new int[3];
			}
			else if (xmlTextReader_0.GetAttribute("i2") != null)
			{
				class1141_0.int_0[int_0] = new int[2];
			}
			else
			{
				class1141_0.int_0[int_0] = new int[1];
			}
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				string localName;
				if (xmlTextReader_0.NamespaceURI != "" || (localName = xmlTextReader_0.LocalName) == null)
				{
					continue;
				}
				if (Class1742.dictionary_36 == null)
				{
					Class1742.dictionary_36 = new Dictionary<string, int>(7)
					{
						{ "i1", 0 },
						{ "i2", 1 },
						{ "i3", 2 },
						{ "i4", 3 },
						{ "ref", 4 },
						{ "name", 5 },
						{ "sheet", 6 }
					};
				}
				if (Class1742.dictionary_36.TryGetValue(localName, out var value))
				{
					switch (value)
					{
					case 0:
						class1141_0.int_0[int_0][0] = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 1:
						class1141_0.int_0[int_0][1] = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 2:
						class1141_0.int_0[int_0][2] = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 3:
						class1141_0.int_0[int_0][3] = Class1618.smethod_87(xmlTextReader_0.Value);
						break;
					case 4:
						address = xmlTextReader_0.Value;
						break;
					case 5:
						text = xmlTextReader_0.Value;
						break;
					case 6:
						text2 = xmlTextReader_0.Value;
						break;
					}
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		if (text == null && text2 != null)
		{
			worksheet_0 = workbook_0.Worksheets[text2];
			if (worksheet_0 == null)
			{
				Class1562 class2 = new Class1562();
				class2.string_1 = string_0;
				class2.string_0 = string_3;
				workbook_0.class1558_0.class1364_0.arrayList_1.Add(class2);
				class1141_0.bool_1 = true;
				return;
			}
			@class = new Class1139(class1141_0, worksheet_0, address);
			Range range = (@class.range_1 = (@class.range_0 = worksheet_0.Cells.CreateRange(address)));
			arrayList_0.Add(@class);
			@class.worksheet_0.Name = text2;
			class1141_0.int_2 = (class1141_0.int_1 = range.ColumnCount);
			class1141_0.int_3 = range.RowCount - 1;
			class1141_0.worksheet_0 = worksheet_0;
			class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
			int int_ = Math.Max(class1141_0.int_3, class1141_0.int_4);
			class1141_0.class1144_0 = new Class1144(class1141_0, int_, class1141_0.int_1);
			return;
		}
		bool flag;
		if (!(flag = text2 == null))
		{
			worksheet_0 = workbook_0.Worksheets[text2];
			if (worksheet_0 == null)
			{
				Class1562 class3 = new Class1562();
				class3.string_1 = string_0;
				class3.string_0 = string_3;
				workbook_0.class1558_0.class1364_0.arrayList_1.Add(class3);
				class1141_0.bool_1 = true;
				return;
			}
		}
		bool flag2 = false;
		int int_2 = (flag ? (-1) : worksheet_0.Index);
		Name name = workbook_0.Worksheets.Names[text, int_2];
		Range range2 = null;
		if (name == null)
		{
			flag2 = true;
			name = workbook_0.Worksheets.Names[text];
		}
		if (name != null)
		{
			if (flag2)
			{
				worksheet_0 = name.GetRange().Worksheet;
			}
			range2 = name.CreateRange();
			if (range2 == null)
			{
				Class1562 class4 = new Class1562();
				class4.string_1 = string_0;
				class4.string_0 = string_3;
				workbook_0.class1558_0.class1364_0.arrayList_1.Add(class4);
				class1141_0.bool_1 = true;
				return;
			}
			if (!flag)
			{
				if (Class1677.smethod_21(worksheet_0.Name))
				{
					_ = "'" + worksheet_0.Name + "'!" + range2.method_1();
				}
				else
				{
					_ = worksheet_0.Name + "!" + range2.method_1();
				}
			}
			Class1139 class5 = new Class1139(class1141_0, worksheet_0, text);
			class5.range_0 = range2;
			class5.range_1 = range2;
			arrayList_0.Add(class5);
			class1141_0.int_2 = (class1141_0.int_1 = range2.ColumnCount);
			class1141_0.int_3 = range2.RowCount - 1;
			class1141_0.worksheet_0 = worksheet_0;
			class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
			class1141_0.class1144_0 = new Class1144(class1141_0, class1141_0.int_3, class1141_0.int_1);
		}
		else
		{
			Class1562 class6 = new Class1562();
			class6.string_1 = string_0;
			class6.string_0 = string_3;
			workbook_0.class1558_0.class1364_0.arrayList_1.Add(class6);
			class1141_0.bool_1 = true;
		}
	}

	private void method_21(XmlTextReader xmlTextReader_0)
	{
		ArrayList arrayList = new ArrayList();
		Class1139 @class = null;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		if (xmlTextReader_0.HasAttributes)
		{
			while (xmlTextReader_0.MoveToNextAttribute())
			{
				if (xmlTextReader_0.LocalName == "ref")
				{
					text = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "name")
				{
					text2 = xmlTextReader_0.Value;
					if (text2.StartsWith("="))
					{
						text2 = text2.Substring(1);
					}
				}
				else if (xmlTextReader_0.LocalName == "sheet")
				{
					text3 = xmlTextReader_0.Value;
				}
				else if (xmlTextReader_0.LocalName == "id")
				{
					text4 = xmlTextReader_0.Value;
				}
			}
			xmlTextReader_0.MoveToElement();
		}
		xmlTextReader_0.Skip();
		if (text2 == null && text3 != null)
		{
			worksheet_0 = workbook_0.Worksheets[text3];
			if (text4 != null && text4.Length > 0)
			{
				Hashtable hashtable = class1547_0.method_6();
				if (hashtable == null)
				{
					return;
				}
				if (!hashtable.ContainsKey(text4))
				{
					throw new CellsException(ExceptionType.InvalidData, "pivotCacheRecord rid " + string_2 + " not found in pivotCache rels file");
				}
				Class1564 class2 = (Class1564)hashtable[text4];
				@class = new Class1139(class1141_0, null, text);
				arrayList.Add(@class);
				string text5 = class2.string_3;
				string text6 = "";
				if (text5.StartsWith("/"))
				{
					text5 = text5.Substring(1);
				}
				if (text5.IndexOf("/") != -1 && text5.EndsWith(".xls"))
				{
					int num = text5.LastIndexOf("/");
					text6 = text5.Substring(0, num + 1) + "[" + text5.Substring(num + 1) + "]";
				}
				@class.string_0 = text6.Replace("%20", " ") + text3;
				class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
				if (arrayList.Count != 0)
				{
					class1141_0.class1139_0 = new Class1139[arrayList.Count];
					for (int i = 0; i < arrayList.Count; i++)
					{
						class1141_0.class1139_0[i] = (Class1139)arrayList[i];
					}
				}
				Class1562 class3 = new Class1562();
				class3.string_1 = string_0;
				class3.string_0 = string_3;
				workbook_0.class1558_0.class1364_0.arrayList_1.Add(class3);
				class1141_0.bool_1 = true;
				return;
			}
			if (worksheet_0 == null)
			{
				Class1562 class4 = new Class1562();
				class4.string_1 = string_0;
				class4.string_0 = string_3;
				workbook_0.class1558_0.class1364_0.arrayList_1.Add(class4);
				class1141_0.bool_1 = true;
				return;
			}
			if (text != null)
			{
				@class = new Class1139(class1141_0, worksheet_0, text);
				Range range = (@class.range_1 = (@class.range_0 = worksheet_0.Cells.CreateRange(text)));
				@class.string_1 = text4;
				arrayList.Add(@class);
				@class.worksheet_0.Name = text3;
				class1141_0.int_2 = (class1141_0.int_1 = range.ColumnCount);
				class1141_0.int_3 = range.RowCount - 1;
				class1141_0.worksheet_0 = worksheet_0;
				class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
			}
		}
		else
		{
			bool flag;
			if (!(flag = text3 == null))
			{
				worksheet_0 = workbook_0.Worksheets[text3];
				if (worksheet_0 == null)
				{
					Class1562 class5 = new Class1562();
					class5.string_1 = string_0;
					class5.string_0 = string_3;
					workbook_0.class1558_0.class1364_0.arrayList_1.Add(class5);
					class1141_0.bool_1 = true;
					return;
				}
			}
			bool flag2 = false;
			int int_ = (flag ? (-1) : worksheet_0.Index);
			Name name = workbook_0.Worksheets.Names[text2, int_];
			Range range2 = null;
			if (name == null)
			{
				flag2 = true;
				name = workbook_0.Worksheets.Names[text2];
			}
			if (name != null)
			{
				if (flag2)
				{
					worksheet_0 = name.GetRange().Worksheet;
				}
				range2 = name.CreateRange();
				if (range2 == null)
				{
					Class1562 class6 = new Class1562();
					class6.string_1 = string_0;
					class6.string_0 = string_3;
					workbook_0.class1558_0.class1364_0.arrayList_1.Add(class6);
					class1141_0.bool_1 = true;
					return;
				}
			}
			else
			{
				bool flag3 = false;
				for (int j = 0; j < workbook_0.Worksheets.Count; j++)
				{
					if (flag3)
					{
						break;
					}
					Worksheet worksheet = workbook_0.Worksheets[j];
					if (worksheet.ListObjects.Count <= 0)
					{
						continue;
					}
					for (int k = 0; k < worksheet.ListObjects.Count; k++)
					{
						ListObject listObject = worksheet.ListObjects[k];
						if (!text2.Equals(listObject.DisplayName))
						{
							if (text2.Length < listObject.DisplayName.Length || text2.IndexOf(':') == -1 || !text2.EndsWith("]"))
							{
								continue;
							}
							string text7 = text2.Replace("'[", "[").Replace("']", "]");
							string text8 = text7.Substring(0, listObject.DisplayName.Length);
							if (text8 == listObject.DisplayName)
							{
								int num2 = text7.IndexOf(':');
								string text9 = text7.Substring(text8.Length + 2, num2 - text8.Length - 3);
								string text10 = text7.Substring(num2 + 2, text7.Length - num2 - 4);
								int num3 = listObject.ListColumns.method_0(text9);
								int num4 = listObject.ListColumns.method_0(text10);
								if (num3 != -1 && num4 != -1)
								{
									range2 = worksheet.Cells.CreateRange(listObject.StartRow, num3, listObject.EndRow - listObject.StartRow + 1, num4 + 1);
									range2.method_0(text2);
									worksheet_0 = listObject.DataRange.Worksheet;
									flag3 = true;
									break;
								}
							}
							continue;
						}
						range2 = worksheet.Cells.CreateRange(listObject.StartRow, listObject.StartColumn, listObject.EndRow - listObject.StartRow + 1, listObject.EndColumn - listObject.StartColumn + 1);
						range2.method_0(listObject.Name);
						worksheet_0 = listObject.DataRange.Worksheet;
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					Class1562 class7 = new Class1562();
					class7.string_1 = string_0;
					class7.string_0 = string_3;
					workbook_0.class1558_0.class1364_0.arrayList_1.Add(class7);
					class1141_0.bool_1 = true;
					return;
				}
			}
			range2.method_0(text2);
			if (!flag)
			{
				if (Class1677.smethod_21(worksheet_0.Name))
				{
					_ = "'" + worksheet_0.Name + "'!" + range2.method_1();
				}
				else
				{
					_ = worksheet_0.Name + "!" + range2.method_1();
				}
			}
			Class1139 class8 = new Class1139(class1141_0, worksheet_0, text2);
			if (text3 == null)
			{
				class8.bool_0 = true;
			}
			class8.range_0 = range2;
			class8.range_1 = range2;
			arrayList.Add(class8);
			class1141_0.int_2 = (class1141_0.int_1 = range2.ColumnCount);
			class1141_0.int_3 = range2.RowCount - 1;
			class1141_0.worksheet_0 = worksheet_0;
			class1141_0.arrayList_0 = new ArrayList(class1141_0.int_1);
		}
		if (arrayList.Count != 0)
		{
			class1141_0.class1139_0 = new Class1139[arrayList.Count];
			for (int l = 0; l < arrayList.Count; l++)
			{
				class1141_0.class1139_0[l] = (Class1139)arrayList[l];
			}
		}
	}

	private void method_22(XmlTextReader xmlTextReader_0)
	{
		xmlTextReader_0.WhitespaceHandling = WhitespaceHandling.Significant;
		xmlTextReader_0.MoveToContent();
		string namespaceURI = xmlTextReader_0.NamespaceURI;
		if (!Class1618.smethod_0(namespaceURI))
		{
			throw new CellsException(ExceptionType.InvalidData, "Error xml namespace " + namespaceURI);
		}
		if (xmlTextReader_0.NodeType != XmlNodeType.Element || xmlTextReader_0.LocalName != "pivotCacheDefinition")
		{
			throw new ApplicationException("pivotCacheDefinition root element eror");
		}
		XmlNameTable nameTable = xmlTextReader_0.NameTable;
		string_1 = nameTable.Add(namespaceURI);
	}
}
