using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Aspose.Cells.Pivot;
using ns1;
using ns22;
using ns45;

namespace ns16;

internal class Class1585
{
	private Class1141 class1141_0;

	internal Class1585(Class1141 class1141_1)
	{
		class1141_0 = class1141_1;
	}

	internal void Write(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartDocument(standalone: true);
		xmlTextWriter_0.WriteStartElement("pivotCacheDefinition");
		xmlTextWriter_0.WriteAttributeString("xmlns", Class1618.string_0);
		method_16(xmlTextWriter_0);
		method_9(xmlTextWriter_0);
		method_3(xmlTextWriter_0);
		method_0(xmlTextWriter_0);
		if (class1141_0.string_5 != null)
		{
			xmlTextWriter_0.WriteRaw(class1141_0.string_5);
		}
		xmlTextWriter_0.WriteEndElement();
		xmlTextWriter_0.WriteEndDocument();
		xmlTextWriter_0.Flush();
	}

	[Attribute0(true)]
	private void method_0(XmlTextWriter xmlTextWriter_0)
	{
		if (class1141_0.class988_0 == null)
		{
			return;
		}
		int count = class1141_0.class988_0.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("calculatedItems");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			Class988 class988_ = class1141_0.class988_0;
			for (int i = 0; i < class988_.Count; i++)
			{
				Class1148 class1148_ = class988_[i];
				method_1(xmlTextWriter_0, class1148_);
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_1(XmlTextWriter xmlTextWriter_0, Class1148 class1148_0)
	{
		Class1171 class1171_ = class1148_0.class1171_0;
		ArrayList arrayList_ = class1171_.arrayList_0;
		int count = arrayList_.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("calculatedItem");
			string text = class1148_0.method_4();
			if (text.StartsWith("="))
			{
				text = text.Substring(1);
			}
			xmlTextWriter_0.WriteAttributeString("formula", text);
			xmlTextWriter_0.WriteStartElement("pivotArea");
			xmlTextWriter_0.WriteAttributeString("cacheIndex", Class1618.smethod_80(class1171_.method_8() ? 1 : 0));
			xmlTextWriter_0.WriteAttributeString("outline", Class1618.smethod_80(class1171_.method_14() ? 1 : 0));
			xmlTextWriter_0.WriteAttributeString("fieldPosition", Class1618.smethod_84(class1171_.byte_0));
			xmlTextWriter_0.WriteStartElement("references");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				Class1162 class1162_ = (Class1162)arrayList_[i];
				method_2(xmlTextWriter_0, class1162_);
			}
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_2(XmlTextWriter xmlTextWriter_0, Class1162 class1162_0)
	{
		ArrayList arrayList_ = class1162_0.arrayList_0;
		int count = arrayList_.Count;
		if (count != 0)
		{
			xmlTextWriter_0.WriteStartElement("reference");
			xmlTextWriter_0.WriteAttributeString("field", Class1618.smethod_80(class1162_0.method_1()));
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(count));
			for (int i = 0; i < count; i++)
			{
				xmlTextWriter_0.WriteStartElement("x");
				xmlTextWriter_0.WriteAttributeString("v", Class1618.smethod_80((int)class1162_0.arrayList_0[i]));
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_3(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("cacheFields");
		if (class1141_0.arrayList_0 != null)
		{
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(class1141_0.arrayList_0.Count));
			ArrayList arrayList_ = class1141_0.arrayList_0;
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class1161 class1161_ = (Class1161)arrayList_[i];
				method_6(xmlTextWriter_0, class1161_);
			}
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_4(XmlTextWriter xmlTextWriter_0, object object_0)
	{
		if (object_0 == null)
		{
			return;
		}
		Class1158 @class = (Class1158)object_0;
		object object_ = @class.object_0;
		bool bool_ = @class.bool_0;
		if (object_ == null)
		{
			xmlTextWriter_0.WriteElementString("m", null);
		}
		if (object_ is string)
		{
			string string_ = (string)object_;
			string text = Class1618.smethod_4(string_);
			string key;
			if ((key = text) != null)
			{
				if (Class1742.dictionary_126 == null)
				{
					Class1742.dictionary_126 = new Dictionary<string, int>(7)
					{
						{ "#DIV/0!", 0 },
						{ "#N/A", 1 },
						{ "#NAME?", 2 },
						{ "#NULL!", 3 },
						{ "#NUM!", 4 },
						{ "#REF!", 5 },
						{ "#VALUE!", 6 }
					};
				}
				if (Class1742.dictionary_126.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						xmlTextWriter_0.WriteStartElement("e");
						xmlTextWriter_0.WriteAttributeString("v", text);
						if (bool_)
						{
							xmlTextWriter_0.WriteAttributeString("f", "1");
						}
						xmlTextWriter_0.WriteEndElement();
						return;
					}
				}
			}
			xmlTextWriter_0.WriteStartElement("s");
			xmlTextWriter_0.WriteAttributeString("v", text);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is double)
		{
			string value2 = Class1618.smethod_79((double)object_);
			xmlTextWriter_0.WriteStartElement("n");
			xmlTextWriter_0.WriteAttributeString("v", value2);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is decimal num)
		{
			string value3 = num.ToString();
			xmlTextWriter_0.WriteStartElement("n");
			xmlTextWriter_0.WriteAttributeString("v", value3);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is int)
		{
			string value4 = Class1618.smethod_80((int)object_);
			xmlTextWriter_0.WriteStartElement("n");
			xmlTextWriter_0.WriteAttributeString("v", value4);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is DateTime dateTime)
		{
			string value5 = dateTime.ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
			xmlTextWriter_0.WriteStartElement("d");
			xmlTextWriter_0.WriteAttributeString("v", value5);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is bool)
		{
			string value6 = (((bool)object_) ? "1" : "0");
			xmlTextWriter_0.WriteStartElement("b");
			xmlTextWriter_0.WriteAttributeString("v", value6);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_5(XmlTextWriter xmlTextWriter_0, object object_0)
	{
		if (object_0 == null)
		{
			return;
		}
		Class1158 @class = (Class1158)object_0;
		object object_ = @class.object_0;
		bool bool_ = @class.bool_0;
		if (object_ == null)
		{
			xmlTextWriter_0.WriteElementString("m", null);
		}
		if (object_ is string)
		{
			xmlTextWriter_0.WriteStartElement("s");
			xmlTextWriter_0.WriteAttributeString("v", (string)object_);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is double)
		{
			string value = Class1618.smethod_79((double)object_);
			xmlTextWriter_0.WriteStartElement("n");
			xmlTextWriter_0.WriteAttributeString("v", value);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is int)
		{
			string value2 = Class1618.smethod_80((int)object_);
			xmlTextWriter_0.WriteStartElement("n");
			xmlTextWriter_0.WriteAttributeString("v", value2);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is short)
		{
			string value3 = Class1618.smethod_83((short)object_);
			xmlTextWriter_0.WriteStartElement("n");
			xmlTextWriter_0.WriteAttributeString("v", value3);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is DateTime dateTime)
		{
			string value4 = dateTime.ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture);
			xmlTextWriter_0.WriteStartElement("d");
			xmlTextWriter_0.WriteAttributeString("v", value4);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
		else if (object_ is bool)
		{
			string value5 = (((bool)object_) ? "1" : "0");
			xmlTextWriter_0.WriteStartElement("b");
			xmlTextWriter_0.WriteAttributeString("v", value5);
			if (bool_)
			{
				xmlTextWriter_0.WriteAttributeString("f", "1");
			}
			xmlTextWriter_0.WriteEndElement();
		}
	}

	[Attribute0(true)]
	private void method_6(XmlTextWriter xmlTextWriter_0, Class1161 class1161_0)
	{
		xmlTextWriter_0.WriteStartElement("cacheField");
		xmlTextWriter_0.WriteAttributeString("name", class1161_0.string_0);
		if (class1161_0.method_1() != null)
		{
			class1141_0.class1161_0 = class1161_0;
			xmlTextWriter_0.WriteAttributeString("formula", Class1618.smethod_93(class1161_0.method_1()));
			xmlTextWriter_0.WriteAttributeString("databaseField", "0");
		}
		else
		{
			if (class1161_0.bool_0)
			{
				xmlTextWriter_0.WriteAttributeString("databaseField", "0");
			}
			xmlTextWriter_0.WriteStartElement("sharedItems");
			if (class1161_0.method_31())
			{
				if (class1161_0.method_14())
				{
					if (!class1161_0.method_16())
					{
						xmlTextWriter_0.WriteAttributeString("containsNonDate", "0");
					}
					xmlTextWriter_0.WriteAttributeString("containsDate", "1");
				}
				xmlTextWriter_0.WriteAttributeString("containsString", "0");
				xmlTextWriter_0.WriteAttributeString("containsBlank", "1");
			}
			else
			{
				if (!class1161_0.method_26())
				{
					xmlTextWriter_0.WriteAttributeString("containsSemiMixedTypes", "0");
				}
				if (class1161_0.method_14())
				{
					if (!class1161_0.method_16())
					{
						xmlTextWriter_0.WriteAttributeString("containsNonDate", "0");
					}
					xmlTextWriter_0.WriteAttributeString("containsDate", "1");
				}
				if (!class1161_0.method_12())
				{
					xmlTextWriter_0.WriteAttributeString("containsString", "0");
				}
				if (class1161_0.method_29())
				{
					xmlTextWriter_0.WriteAttributeString("containsBlank", "1");
				}
				if (!class1161_0.method_25())
				{
					xmlTextWriter_0.WriteAttributeString("containsMixedTypes", "0");
				}
				else
				{
					xmlTextWriter_0.WriteAttributeString("containsMixedTypes", "1");
				}
				if (class1161_0.method_6())
				{
					xmlTextWriter_0.WriteAttributeString("containsNumber", "1");
					if (class1161_0.arrayList_0 != null)
					{
						class1161_0.method_9(bool_2: true);
						foreach (object item in class1161_0.arrayList_0)
						{
							Class1158 @class = (Class1158)item;
							if (@class.object_0 is int || @class.object_0 is double)
							{
								string text = "";
								text = ((!(@class.object_0 is int)) ? Class1618.smethod_79((double)@class.object_0) : Class1618.smethod_80((int)@class.object_0));
								if (text.IndexOf('.') != -1)
								{
									class1161_0.method_9(bool_2: false);
									class1161_0.method_11(bool_2: true);
									break;
								}
							}
						}
					}
				}
				if (class1161_0.method_8())
				{
					xmlTextWriter_0.WriteAttributeString("containsInteger", "1");
				}
				if (class1161_0.bool_1)
				{
					xmlTextWriter_0.WriteAttributeString("longText", "1");
				}
			}
			if (class1161_0.arrayList_0 != null)
			{
				xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(class1161_0.arrayList_0.Count));
				foreach (object item2 in class1161_0.arrayList_0)
				{
					method_4(xmlTextWriter_0, item2);
				}
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (class1161_0.sxRng_0 != null)
		{
			method_7(xmlTextWriter_0, class1161_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_7(XmlTextWriter xmlTextWriter_0, Class1161 class1161_0)
	{
		SxRng sxRng_ = class1161_0.sxRng_0;
		xmlTextWriter_0.WriteStartElement("fieldGroup");
		if (sxRng_.int_1 != -1)
		{
			xmlTextWriter_0.WriteAttributeString("par", Class1618.smethod_80(sxRng_.int_1));
		}
		if (sxRng_.int_0 != -1)
		{
			xmlTextWriter_0.WriteAttributeString("base", Class1618.smethod_80(sxRng_.int_0));
		}
		if (sxRng_.arrayList_1 == null)
		{
			if (sxRng_.arrayList_0 != null)
			{
				xmlTextWriter_0.WriteStartElement("rangePr");
				xmlTextWriter_0.WriteAttributeString("groupBy", Class1618.smethod_236(sxRng_.pivotGroupByType_0));
				if (sxRng_.bool_1)
				{
					xmlTextWriter_0.WriteAttributeString("autoEnd", "1");
				}
				else
				{
					xmlTextWriter_0.WriteAttributeString("autoEnd", "0");
				}
				if (sxRng_.bool_0)
				{
					xmlTextWriter_0.WriteAttributeString("autoStart", "1");
				}
				else
				{
					xmlTextWriter_0.WriteAttributeString("autoStart", "0");
				}
				if (sxRng_.pivotGroupByType_0 == PivotGroupByType.RangeOfValues)
				{
					xmlTextWriter_0.WriteAttributeString("startNum", Class1618.smethod_79(sxRng_.double_0));
					xmlTextWriter_0.WriteAttributeString("endNum", Class1618.smethod_79(sxRng_.double_1));
				}
				else
				{
					xmlTextWriter_0.WriteAttributeString("startDate", sxRng_.dateTime_0.ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture));
					xmlTextWriter_0.WriteAttributeString("endDate", sxRng_.dateTime_1.ToString("yyyy-MM-dd\\THH:mm:ss.fff", CultureInfo.InvariantCulture));
				}
				if (sxRng_.double_2 != 1.0)
				{
					xmlTextWriter_0.WriteAttributeString("groupInterval", Class1618.smethod_79(sxRng_.double_2));
				}
				xmlTextWriter_0.WriteEndElement();
			}
		}
		else
		{
			xmlTextWriter_0.WriteStartElement("discretePr");
			xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(sxRng_.arrayList_1.Count));
			for (int i = 0; i < sxRng_.arrayList_1.Count; i++)
			{
				xmlTextWriter_0.WriteStartElement("x");
				xmlTextWriter_0.WriteAttributeString("v", (string)sxRng_.arrayList_1[i]);
				xmlTextWriter_0.WriteEndElement();
			}
			xmlTextWriter_0.WriteEndElement();
		}
		if (sxRng_.arrayList_0 != null)
		{
			method_8(xmlTextWriter_0, sxRng_);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_8(XmlTextWriter xmlTextWriter_0, SxRng sxRng_0)
	{
		xmlTextWriter_0.WriteStartElement("groupItems");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(sxRng_0.arrayList_0.Count));
		foreach (object item in sxRng_0.arrayList_0)
		{
			method_5(xmlTextWriter_0, item);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_9(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("cacheSource");
		xmlTextWriter_0.WriteAttributeString("type", Class1618.smethod_146(class1141_0.pivotTableSourceType_0));
		if (class1141_0.pivotTableSourceType_0 == PivotTableSourceType.ListDatabase)
		{
			method_15(xmlTextWriter_0);
		}
		else if (class1141_0.pivotTableSourceType_0 == PivotTableSourceType.Consilidation)
		{
			method_10(xmlTextWriter_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	private void method_10(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("consolidation");
		if (!class1141_0.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("autoPage", "0");
		}
		if (class1141_0.string_0 != null)
		{
			method_11(xmlTextWriter_0);
		}
		if (class1141_0.int_0 != null)
		{
			method_13(xmlTextWriter_0);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_11(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("pages");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(class1141_0.string_0.Length));
		for (int i = 0; i < class1141_0.string_0.Length; i++)
		{
			string[] string_ = class1141_0.string_0[i];
			method_12(xmlTextWriter_0, string_);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_12(XmlTextWriter xmlTextWriter_0, string[] string_0)
	{
		xmlTextWriter_0.WriteStartElement("page");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(string_0.Length));
		foreach (string value in string_0)
		{
			xmlTextWriter_0.WriteStartElement("pageItem");
			xmlTextWriter_0.WriteAttributeString("name", value);
			xmlTextWriter_0.WriteEndElement();
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_13(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteStartElement("rangeSets");
		xmlTextWriter_0.WriteAttributeString("count", Class1618.smethod_80(class1141_0.int_0.Length));
		for (int i = 0; i < class1141_0.int_0.Length; i++)
		{
			int[] int_ = class1141_0.int_0[i];
			method_14(xmlTextWriter_0, int_, class1141_0.class1139_0[i]);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_14(XmlTextWriter xmlTextWriter_0, int[] int_0, Class1139 class1139_0)
	{
		xmlTextWriter_0.WriteStartElement("rangeSet");
		if (int_0.Length >= 4)
		{
			xmlTextWriter_0.WriteAttributeString("i4", Class1618.smethod_80(int_0[3]));
		}
		if (int_0.Length >= 3)
		{
			xmlTextWriter_0.WriteAttributeString("i3", Class1618.smethod_80(int_0[2]));
		}
		if (int_0.Length >= 2 && int_0[1] != -1)
		{
			xmlTextWriter_0.WriteAttributeString("i2", Class1618.smethod_80(int_0[1]));
		}
		if (int_0.Length >= 1)
		{
			xmlTextWriter_0.WriteAttributeString("i1", Class1618.smethod_80(int_0[0]));
		}
		if (class1139_0.range_0 != null)
		{
			if (class1139_0.range_0.Name != null && class1139_0.range_0.Name.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("name", class1139_0.range_0.Name);
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("ref", class1139_0.range_0.method_1());
			}
		}
		if (class1139_0.worksheet_0 != null)
		{
			xmlTextWriter_0.WriteAttributeString("sheet", class1139_0.worksheet_0.Name);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_15(XmlTextWriter xmlTextWriter_0)
	{
		if (class1141_0.class1139_0 == null)
		{
			if (class1141_0.string_3 != null)
			{
				xmlTextWriter_0.WriteStartElement("worksheetSource");
				xmlTextWriter_0.WriteAttributeString("name", class1141_0.string_3);
				xmlTextWriter_0.WriteEndElement();
			}
			return;
		}
		Class1139 @class = class1141_0.class1139_0[0];
		xmlTextWriter_0.WriteStartElement("worksheetSource");
		if (@class.range_0 != null)
		{
			if (@class.range_0.Name != null && @class.range_0.Name.Length > 0)
			{
				xmlTextWriter_0.WriteAttributeString("name", @class.range_0.Name);
			}
			else
			{
				xmlTextWriter_0.WriteAttributeString("ref", @class.range_0.method_1());
			}
		}
		else if (@class.range_1 != null && @class.range_1.Name != null && @class.range_1.Name.Length > 0)
		{
			xmlTextWriter_0.WriteAttributeString("name", @class.range_1.Name);
		}
		if (@class.worksheet_0 != null && !@class.bool_0)
		{
			xmlTextWriter_0.WriteAttributeString("sheet", @class.worksheet_0.Name);
		}
		if (@class.string_1 != null)
		{
			xmlTextWriter_0.WriteAttributeString("r:id", @class.string_1);
		}
		xmlTextWriter_0.WriteEndElement();
	}

	[Attribute0(true)]
	private void method_16(XmlTextWriter xmlTextWriter_0)
	{
		xmlTextWriter_0.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		if (class1141_0.class1144_0 != null)
		{
			xmlTextWriter_0.WriteAttributeString("r:id", "rId1");
		}
		if (class1141_0.int_9 != -1)
		{
			xmlTextWriter_0.WriteAttributeString("missingItemsLimit", Class1618.smethod_80(class1141_0.int_9));
		}
		xmlTextWriter_0.WriteAttributeString("createdVersion", class1141_0.string_2);
		if (class1141_0.method_12())
		{
			xmlTextWriter_0.WriteAttributeString("refreshOnLoad", "1");
		}
		if (!class1141_0.method_15(1) || class1141_0.class1144_0 == null)
		{
			xmlTextWriter_0.WriteAttributeString("saveData", "0");
		}
		xmlTextWriter_0.WriteAttributeString("recordCount", Class1618.smethod_80(class1141_0.int_4));
	}
}
