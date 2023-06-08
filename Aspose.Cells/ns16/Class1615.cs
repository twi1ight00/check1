using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using ns22;
using ns25;
using ns45;
using ns46;
using ns52;

namespace ns16;

internal class Class1615
{
	private Workbook workbook_0;

	private Class1547 class1547_0;

	private Class746 class746_0;

	private Class1610 class1610_0;

	internal Class1615(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		class1547_0 = new Class1547(workbook_1);
		class746_0 = workbook_1.class1558_0.class1553_0.class746_0;
	}

	internal void Read()
	{
		method_10();
		method_6();
		method_5();
		method_11();
		method_8();
		method_9();
		method_7();
		method_33();
		method_12();
		method_13();
		method_15();
		method_16();
		method_17();
		method_18();
		method_19();
		method_14();
		method_32();
		method_4();
		method_20();
		workbook_0.class1558_0.method_0();
		workbook_0.Worksheets.ExternalLinks.method_1(workbook_0.Worksheets.method_39());
		workbook_0.Worksheets.Names.method_4(bool_0: true);
		if (workbook_0.IsDigitallySigned)
		{
			workbook_0.class997_0 = new Class997(class746_0);
		}
		method_1();
		method_35();
		method_2();
		method_0();
	}

	[Attribute0(true)]
	private void method_0()
	{
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet = workbook_0.Worksheets[i];
			if (worksheet.class1557_0 != null && worksheet.class1557_0.arrayList_8.Count > 0)
			{
				for (int num = worksheet.Shapes.Count - 1; num >= 0; num--)
				{
					Shape shape = worksheet.Shapes[num];
					if (shape.class1556_0 != null && shape.class1556_0.string_3 != null && shape.class1556_0.string_3.Length > 0)
					{
						XmlDocument xmlDocument = Class1188.smethod_1(shape.class1556_0.string_3);
						XmlElement documentElement = xmlDocument.DocumentElement;
						if (xmlDocument != null && documentElement.LocalName == "AlternateContent")
						{
							string text = null;
							bool flag = false;
							string text2 = null;
							XmlNodeList elementsByTagName = documentElement.GetElementsByTagName("xdr:cNvPr");
							if (elementsByTagName != null && elementsByTagName.Count > 0)
							{
								XmlElement xmlNode_ = (XmlElement)elementsByTagName[0];
								text = Class1618.smethod_172(xmlNode_, "id");
								string text3 = Class1618.smethod_172(xmlNode_, "hidden");
								if (text3 == "1")
								{
									flag = true;
								}
							}
							if (text != null)
							{
								if (flag)
								{
									if (worksheet.class1557_0.arrayList_3.Count != 0)
									{
										XmlNodeList elementsByTagName2 = documentElement.GetElementsByTagName("a14:compatExt");
										if (elementsByTagName2 != null && elementsByTagName2.Count > 0)
										{
											XmlElement xmlNode_2 = (XmlElement)elementsByTagName2[0];
											text2 = Class1618.smethod_172(xmlNode_2, "spid");
											if (text2 != null)
											{
												text2 = Class1618.smethod_8(text2);
											}
										}
										if (text2 != null && worksheet.class1557_0.arrayList_8.Contains(text2))
										{
											bool flag2 = false;
											int num2 = worksheet.class1557_0.arrayList_3.Count - 1;
											while (num2 >= 0)
											{
												Class443 @class = (Class443)worksheet.class1557_0.arrayList_3[num2];
												if (!(@class.string_0 == text))
												{
													num2--;
													continue;
												}
												worksheet.class1557_0.arrayList_3.RemoveAt(num2);
												flag2 = true;
												break;
											}
											if (flag2)
											{
												worksheet.Shapes.RemoveAt(num);
											}
										}
									}
								}
								else
								{
									XmlNodeList elementsByTagName3 = documentElement.GetElementsByTagName("a14:cameraTool");
									if (elementsByTagName3 != null && elementsByTagName3.Count > 0)
									{
										XmlElement xmlNode_3 = (XmlElement)elementsByTagName3[0];
										text2 = Class1618.smethod_172(xmlNode_3, "spid");
										if (text2 != null)
										{
											text2 = Class1618.smethod_8(text2);
										}
									}
									if (text2 != null && worksheet.class1557_0.arrayList_8.Contains(text2))
									{
										worksheet.Shapes.RemoveAt(num);
									}
								}
							}
						}
					}
				}
			}
			for (int j = 0; j < worksheet.class1557_0.arrayList_3.Count; j++)
			{
				Class443 class2 = (Class443)worksheet.class1557_0.arrayList_3[j];
				if (!class2.bool_0)
				{
					worksheet.class1557_0.arrayList_3.RemoveAt(j--);
				}
			}
		}
	}

	private void method_1()
	{
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet = workbook_0.Worksheets[i];
			if (worksheet.ListObjects != null && worksheet.ListObjects.Count > 0)
			{
				worksheet.ListObjects.method_6();
			}
		}
	}

	private void method_2()
	{
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet = workbook_0.Worksheets[i];
			if (worksheet.pivotTableCollection_0 == null || worksheet.pivotTableCollection_0.Count <= 0)
			{
				continue;
			}
			for (int j = 0; j < worksheet.pivotTableCollection_0.Count; j++)
			{
				PivotTable pivotTable = worksheet.pivotTableCollection_0[j];
				pivotTable.class1141_0 = class1547_0.workbook_0.Worksheets.method_89().method_2(pivotTable.int_11);
				if (pivotTable.class1141_0 != null && pivotTable.class1141_0.arrayList_0 != null)
				{
					for (int k = 0; k < pivotTable.class1141_0.arrayList_0.Count; k++)
					{
						pivotTable.BaseFields[k].class1161_0 = (Class1161)pivotTable.class1141_0.arrayList_0[k];
					}
					method_3(pivotTable);
				}
			}
		}
	}

	private void method_3(PivotTable pivotTable_0)
	{
		for (int i = 0; i < pivotTable_0.BaseFields.Count; i++)
		{
			PivotField pivotField = pivotTable_0.BaseFields[i];
			if (!pivotField.method_11() || pivotTable_0.class1141_0.class988_0 == null)
			{
				continue;
			}
			Class988 class988_ = pivotTable_0.class1141_0.class988_0;
			for (int j = 0; j < class988_.Count; j++)
			{
				Class1148 @class = class988_[j];
				Class1162 class2 = (Class1162)@class.class1171_0.arrayList_0[0];
				if (class2.method_1() == pivotField.int_1)
				{
					if (pivotField.pivotFieldType_0 == PivotFieldType.Column)
					{
						class2.ushort_0 = 2;
					}
					else if (pivotField.pivotFieldType_0 == PivotFieldType.Page)
					{
						class2.ushort_0 = 4;
					}
					else if (pivotField.pivotFieldType_0 == PivotFieldType.Data)
					{
						class2.ushort_0 = 8;
					}
					@class.SetFormula(@class.method_0(), @class.method_5());
				}
			}
		}
	}

	private void method_4()
	{
		IEnumerator enumerator = class746_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if (@class.method_18())
			{
				continue;
			}
			string name = @class.Name;
			string text = Class1618.smethod_175(name);
			if (!name.EndsWith(".rels") && !name.EndsWith(".vml") && (text.Equals("drawings") || text.Equals("charts") || text.Equals("media") || text.Equals("customData") || text.EndsWith("ctrlProps")))
			{
				Class1366 class2 = new Class1366();
				class2.string_1 = name;
				class2.string_0 = text;
				string text2 = Class1618.smethod_176(name);
				if (class746_0.method_40(text2, bool_18: true) != -1)
				{
					XmlTextReader xmlTextReader = smethod_1(class746_0, text2);
					class2.arrayList_0 = Class1608.smethod_0(xmlTextReader);
					xmlTextReader.Close();
				}
				workbook_0.class1558_0.arrayList_4.Add(class2);
			}
		}
	}

	private void method_5()
	{
		string text = "_rels/.rels";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			Hashtable hashtable_ = Class1608.Read(xmlTextReader);
			xmlTextReader.Close();
			workbook_0.class1558_0.arrayList_3 = Class1608.smethod_7(hashtable_, "http://schemas.microsoft.com/office/2006/relationships/ui/userCustomization");
			Class1608.smethod_8(hashtable_, workbook_0.class1558_0.arrayList_3, "http://schemas.openxmlformats.org/package/2006/relationships/digital-signature/origin");
		}
	}

	private void method_6()
	{
		string string_ = "xl/workbook.xml";
		string string_2 = "xl/workbook2.xml";
		if (class1547_0.string_0 != null)
		{
			string_ = class1547_0.string_0;
		}
		try
		{
			if (class746_0.method_40(string_, bool_18: true) == -1 && class746_0.method_40(string_2, bool_18: true) == -1)
			{
				throw new CellsException(ExceptionType.FileFormat, "Invalid Excel2007Xlsx file format");
			}
		}
		catch
		{
			throw new CellsException(ExceptionType.FileFormat, "Invalid Excel2007Xlsx file format");
		}
	}

	private void method_7()
	{
		string string_ = "xl/workbook.xml";
		string string_2 = "xl/workbook2.xml";
		if (class1547_0.string_0 != null)
		{
			string_ = class1547_0.string_0;
		}
		Class1616 @class = new Class1616(class1547_0, class746_0);
		XmlTextReader xmlTextReader = smethod_1(class746_0, string_);
		if (xmlTextReader == null)
		{
			xmlTextReader = smethod_1(class746_0, string_2);
		}
		@class.Read(xmlTextReader);
		xmlTextReader.Close();
	}

	private void method_8()
	{
		string string_ = "xl/workbook.xml";
		string string_2 = "xl/workbook2.xml";
		if (class1547_0.string_0 != null)
		{
			string_ = class1547_0.string_0;
		}
		Class1616 @class = new Class1616(class1547_0, class746_0);
		XmlTextReader xmlTextReader = smethod_1(class746_0, string_);
		if (xmlTextReader == null)
		{
			xmlTextReader = smethod_1(class746_0, string_2);
		}
		@class.method_4(xmlTextReader);
		xmlTextReader.Close();
	}

	private void method_9()
	{
		ArrayList arrayList_ = class1547_0.arrayList_1;
		if (arrayList_.Count == 0)
		{
			return;
		}
		for (int i = 0; i < arrayList_.Count; i++)
		{
			Class1555 @class = (Class1555)arrayList_[i];
			if (@class.string_0.StartsWith("/xl/"))
			{
				@class.string_0 = @class.string_0.Substring(4);
			}
			string string_ = "xl/" + @class.string_0;
			string text = "xl/" + Path.GetDirectoryName(@class.string_0) + "/_rels/" + Path.GetFileName(@class.string_0) + ".rels";
			Hashtable hashtable_ = null;
			if (class746_0.method_40(text, bool_18: true) != -1)
			{
				XmlTextReader xmlTextReader = smethod_1(class746_0, text);
				hashtable_ = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			XmlTextReader xmlTextReader2 = smethod_1(class746_0, string_);
			Class1605 class2 = new Class1605(class1547_0, hashtable_);
			class2.Read(xmlTextReader2);
			xmlTextReader2.Close();
		}
	}

	private void method_10()
	{
		string string_ = "[Content_Types].xml";
		Class1600 @class = new Class1600(class1547_0);
		XmlTextReader xmlTextReader = smethod_1(class746_0, string_);
		@class.Read(xmlTextReader);
		xmlTextReader.Close();
	}

	private void method_11()
	{
		string string_ = "xl/_rels/workbook.xml.rels";
		string string_2 = "xl/_rels/workbook2.xml.rels";
		if (class1547_0.string_0 != null)
		{
			int num = class1547_0.string_0.LastIndexOf('/');
			string text = class1547_0.string_0;
			if (num != -1)
			{
				text = text.Substring(num + 1);
			}
			string_ = "xl/_rels/" + text + ".rels";
		}
		XmlTextReader xmlTextReader = smethod_1(class746_0, string_);
		if (xmlTextReader == null)
		{
			xmlTextReader = smethod_1(class746_0, string_2);
		}
		Hashtable hashtable = Class1608.Read(xmlTextReader);
		class1547_0.method_2(hashtable);
		xmlTextReader.Close();
		Class1564 @class = Class1608.smethod_4(hashtable, "http://schemas.microsoft.com/office/2006/relationships/vbaProject");
		if (@class != null)
		{
			workbook_0.class1558_0.string_0 = "xl/" + @class.string_3;
		}
		class1547_0.method_13(workbook_0.class1558_0.class1364_0.arrayList_0);
	}

	private void method_12()
	{
		Class1564 @class = Class1608.smethod_4(class1547_0.method_3(), "http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme");
		if (@class == null)
		{
			workbook_0.class1558_0.bool_1 = false;
			return;
		}
		string text = "xl/theme/" + Path.GetFileName(@class.string_3);
		workbook_0.class1558_0.string_1 = text;
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			workbook_0.class1558_0.bool_1 = true;
			Class744 class744_ = class746_0.method_38(text);
			Stream stream = class746_0.method_39(class744_);
			XmlDocument xmlDocument_ = Class1188.smethod_2(stream);
			stream.Close();
			Class1612 class2 = new Class1612(class1547_0, text);
			class2.Read(xmlDocument_);
		}
	}

	private void method_13()
	{
		string text = "customUI/customUI.xml";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			xmlTextReader.MoveToContent();
			workbook_0.RibbonXml = xmlTextReader.ReadOuterXml();
			xmlTextReader.Close();
		}
	}

	private void method_14()
	{
		string text = "xl/xmlMaps.xml";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			Class450 @class = new Class450(class1547_0);
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			@class.Read(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private void method_15()
	{
		string text = "docProps/core.xml";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			Class1602 @class = new Class1602(class1547_0);
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			@class.Read(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private void method_16()
	{
		string text = "docProps/app.xml";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			Class1601 @class = new Class1601(class1547_0);
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			@class.Read(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private void method_17()
	{
		string text = "docProps/custom.xml";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			Class1603 @class = new Class1603(class1547_0);
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			@class.Read(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private void method_18()
	{
		string text = "xl/styles.xml";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			Class1611 @class = new Class1611(class1547_0);
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			@class.method_0(xmlTextReader);
			xmlTextReader.Close();
			xmlTextReader = smethod_1(class746_0, text);
			@class.Read(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private void method_19()
	{
		string text = "xl/sharedStrings.xml";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			class1610_0 = new Class1610(class1547_0);
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			class1610_0.Read(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private void method_20()
	{
		if (class1610_0 == null)
		{
			class1610_0 = new Class1610(class1547_0);
		}
		Hashtable hashtable = class1547_0.method_3();
		IEnumerator enumerator = class1547_0.method_11().Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1548 @class = (Class1548)enumerator.Current;
			if (@class.string_1 != null && !(@class.string_1 == ""))
			{
				Class1564 class2 = (Class1564)hashtable[@class.string_1];
				string fileName = Path.GetFileName(class2.string_3);
				if (class2.string_3.IndexOf("worksheets/") != -1)
				{
					method_21(@class, fileName);
				}
			}
		}
		enumerator = class1547_0.method_11().Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1548 class3 = (Class1548)enumerator.Current;
			if (class3.string_1 != null && !(class3.string_1 == ""))
			{
				Class1564 class4 = (Class1564)hashtable[class3.string_1];
				string fileName2 = Path.GetFileName(class4.string_3);
				if (class4.string_3.IndexOf("worksheets/") != -1)
				{
					method_23(class3, fileName2);
				}
				else if (class4.string_3.IndexOf("chartsheets/") != -1 && Class1618.bool_1)
				{
					method_29(class3, fileName2);
				}
			}
		}
	}

	private void method_21(Class1548 class1548_0, string string_0)
	{
		method_31(class1548_0, SheetType.Worksheet, string_0);
		method_22(class1548_0);
		method_25(class1548_0);
	}

	private void method_22(Class1548 class1548_0)
	{
		ArrayList arrayList = Class1608.smethod_7(class1548_0.hashtable_0, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/queryTable");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1564 @class = (Class1564)arrayList[i];
			string text = "xl/queryTables/" + Path.GetFileName(@class.string_3);
			if (class746_0.method_40(text, bool_18: true) != -1)
			{
				Class744 class744_ = class746_0.method_38(text);
				Stream stream = class746_0.method_39(class744_);
				XmlDocument xmlDocument_ = Class1188.smethod_2(stream);
				stream.Close();
				Class449 class2 = new Class449(class1548_0, text);
				class2.Read(xmlDocument_);
			}
		}
	}

	private void method_23(Class1548 class1548_0, string string_0)
	{
		workbook_0.method_30();
		method_37(class1548_0);
		workbook_0.method_30();
		method_39(class1548_0);
		workbook_0.method_30();
		method_30(class1548_0, string_0);
		workbook_0.method_30();
		method_41(class1548_0);
		workbook_0.method_30();
		method_38(class1548_0);
		if (class1548_0.string_3 != null)
		{
			method_28(class1548_0);
		}
		if (class1548_0.string_5 != null)
		{
			method_27(class1548_0);
		}
		method_24(class1548_0);
		if (class1548_0.hashtable_1 != null)
		{
			method_26(class1548_0);
		}
	}

	private void method_24(Class1548 class1548_0)
	{
		if (class1548_0.string_6 != null)
		{
			string text = class1548_0.method_3(class1548_0.string_6);
			if (text != null)
			{
				string string_ = Class1618.smethod_212(text);
				Class744 class744_ = class746_0.method_38(string_);
				Stream stream_ = class746_0.method_39(class744_);
				byte[] byte_ = Class936.smethod_1(stream_, bool_0: false);
				class1548_0.worksheet_0.PageSetup.method_5(byte_);
			}
		}
		if (class1548_0.arrayList_0.Count == 0)
		{
			return;
		}
		for (int i = 0; i < class1548_0.arrayList_0.Count; i++)
		{
			Class1564 @class = (Class1564)class1548_0.arrayList_0[i];
			if (!(@class.string_1 == class1548_0.string_6))
			{
				string string_2 = Class1618.smethod_212(@class.string_3);
				Class744 class744_2 = class746_0.method_38(string_2);
				Stream stream_2 = class746_0.method_39(class744_2);
				byte[] value = Class936.smethod_1(stream_2, bool_0: false);
				class1548_0.worksheet_0.class1557_0.hashtable_1.Add(@class.string_1, value);
			}
		}
	}

	private void method_25(Class1548 class1548_0)
	{
		ArrayList arrayList = Class1608.smethod_7(class1548_0.hashtable_0, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/table");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1564 @class = (Class1564)arrayList[i];
			string string_ = "xl/tables/" + Path.GetFileName(@class.string_3);
			XmlTextReader xmlTextReader = smethod_1(class746_0, string_);
			Class1334 class2 = new Class1334(class1548_0);
			class2.Read(xmlTextReader);
			xmlTextReader.Close();
			string text = "xl/tables/_rels/" + Path.GetFileName(@class.string_3) + ".rels";
			if (class746_0.method_40(text, bool_18: false) != -1)
			{
				xmlTextReader = smethod_1(class746_0, text);
				class2.method_0().hashtable_0 = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
		}
	}

	private void method_26(Class1548 class1548_0)
	{
		IDictionaryEnumerator enumerator = class1548_0.hashtable_1.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string name = (string)enumerator.Key;
			string string_ = (string)enumerator.Value;
			string text = class1548_0.method_3(string_);
			if (text != null)
			{
				text = Class1618.smethod_212(text);
				Class744 @class = class746_0.method_38(text);
				Stream stream = class746_0.method_39(@class);
				byte[] array = new byte[(int)@class.Size];
				stream.Read(array, 0, (int)@class.Size);
				string @string = Encoding.Unicode.GetString(array);
				class1548_0.worksheet_0.CustomProperties.Add(name, @string);
			}
		}
	}

	private void method_27(Class1548 class1548_0)
	{
		string text = Class1618.smethod_212(class1548_0.method_3(class1548_0.string_5));
		Class744 @class = class746_0.method_38(text);
		Stream stream = class746_0.method_39(@class);
		byte[] array = new byte[(int)@class.Size];
		stream.Read(array, 0, (int)@class.Size);
		class1548_0.worksheet_0.SetBackground(array);
		workbook_0.class1558_0.arrayList_2.Add(Path.GetFileName(text));
	}

	private void method_28(Class1548 class1548_0)
	{
		string text = class1548_0.method_3(class1548_0.string_3);
		if (text == null)
		{
			return;
		}
		text = Class1618.smethod_212(text);
		XmlTextReader xmlTextReader = smethod_1(class746_0, text);
		Class1606 @class = new Class1606();
		ArrayList arrayList = @class.Read(xmlTextReader);
		xmlTextReader.Close();
		string text2 = "xl/drawings/_rels/" + Path.GetFileName(text) + ".rels";
		if (arrayList == null || class746_0.method_40(text2, bool_18: true) == -1)
		{
			return;
		}
		xmlTextReader = smethod_1(class746_0, text2);
		Hashtable hashtable = Class1608.Read(xmlTextReader);
		xmlTextReader.Close();
		if (hashtable != null && hashtable.Count != 0)
		{
			int num = 0;
			Class1545 class2;
			while (true)
			{
				if (num >= arrayList.Count)
				{
					return;
				}
				class2 = (Class1545)arrayList[num];
				if (class2.string_1 != null)
				{
					if (!hashtable.ContainsKey(class2.string_1))
					{
						break;
					}
					Class1564 class3 = (Class1564)hashtable[class2.string_1];
					string text3 = Class1618.smethod_212(class3.string_3);
					Class744 class4 = class746_0.method_38(text3);
					Stream stream = class746_0.method_39(class4);
					byte[] array = new byte[(int)class4.Size];
					stream.Read(array, 0, (int)class4.Size);
					Picture picture_ = class1548_0.worksheet_0.PageSetup.AddPicture(class2.method_0(), array);
					class2.method_2(picture_, workbook_0.Worksheets.method_75());
					workbook_0.class1558_0.arrayList_2.Add(Path.GetFileName(text3));
				}
				num++;
			}
			throw new CellsException(ExceptionType.InvalidData, text2 + " does not contains relId " + class2.string_1);
		}
		throw new CellsException(ExceptionType.InvalidData, text2 + " does not exist or is empty");
	}

	private void method_29(Class1548 class1548_0, string string_0)
	{
		method_31(class1548_0, SheetType.Chart, string_0);
		workbook_0.method_30();
		method_40(class1548_0, string_0);
		workbook_0.method_30();
		method_41(class1548_0);
		workbook_0.method_30();
		method_38(class1548_0);
		if (class1548_0.string_5 != null)
		{
			method_27(class1548_0);
		}
		if (class1548_0.string_6 != null)
		{
			method_24(class1548_0);
		}
	}

	private void method_30(Class1548 class1548_0, string string_0)
	{
		string string_ = "xl/worksheets/" + string_0;
		Class1617 @class = new Class1617(class1547_0, class1548_0);
		XmlTextReader xmlTextReader = smethod_1(class746_0, string_);
		@class.method_40(class1610_0);
		@class.Read(xmlTextReader);
		xmlTextReader.Close();
		class1548_0.worksheet_0.class1557_0.string_0 = string_;
	}

	private void method_31(Class1548 class1548_0, SheetType sheetType_0, string string_0)
	{
		string text = null;
		if (sheetType_0 == SheetType.Worksheet)
		{
			text = "xl/worksheets/_rels/" + string_0 + ".rels";
		}
		else
		{
			if (sheetType_0 != SheetType.Chart)
			{
				throw new CellsException(ExceptionType.SheetType, "Cells Internal error, unsupported sheet type");
			}
			text = "xl/chartsheets/_rels/" + string_0 + ".rels";
		}
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			class1548_0.hashtable_0 = Class1608.Read(xmlTextReader);
			xmlTextReader.Close();
			class1548_0.method_2(class1548_0.worksheet_0.class1557_0.arrayList_4);
		}
	}

	private void method_32()
	{
		Class1564 @class = Class1608.smethod_4(class1547_0.method_3(), "http://schemas.openxmlformats.org/officeDocument/2006/relationships/connections");
		if (@class != null)
		{
			string text = "xl/" + Path.GetFileName(@class.string_3);
			if (class746_0.method_40(text, bool_18: true) != -1)
			{
				Class744 class744_ = class746_0.method_38(text);
				Stream stream = class746_0.method_39(class744_);
				XmlDocument xmlDocument_ = Class1188.smethod_2(stream);
				stream.Close();
				Class447 class2 = new Class447(class1547_0, text);
				class2.Read(xmlDocument_);
			}
		}
	}

	private void method_33()
	{
		if (method_34())
		{
			return;
		}
		Hashtable hashtable_ = class1547_0.method_3();
		ArrayList arrayList = Class1608.smethod_7(hashtable_, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml");
		if (arrayList.Count != 0)
		{
			workbook_0.class1558_0.class1364_0.arrayList_0.AddRange(arrayList);
		}
		IEnumerator enumerator = class746_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if (@class.method_18())
			{
				continue;
			}
			string name = @class.Name;
			string text = Class1618.smethod_175(name);
			if (!name.EndsWith(".rels") && !name.EndsWith(".vml") && text.Equals("customXml"))
			{
				Class1366 class2 = new Class1366();
				class2.string_1 = name;
				class2.string_0 = text;
				string text2 = Class1618.smethod_176(name);
				if (class746_0.method_40(text2, bool_18: true) != -1)
				{
					XmlTextReader xmlTextReader = smethod_1(class746_0, text2);
					class2.arrayList_0 = Class1608.smethod_0(xmlTextReader);
					xmlTextReader.Close();
				}
				workbook_0.class1558_0.arrayList_4.Add(class2);
			}
		}
	}

	private bool method_34()
	{
		bool flag = false;
		Hashtable hashtable_ = class1547_0.method_3();
		ArrayList arrayList = Class1608.smethod_7(hashtable_, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml");
		if (arrayList.Count == 0)
		{
			return false;
		}
		XmlTextReader xmlTextReader = null;
		new Class1366();
		Class532 @class = new Class532(class1547_0);
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1564 class2 = (Class1564)arrayList[i];
			string text = "customXml/" + Path.GetFileName(class2.string_3);
			if (class746_0.method_40(text, bool_18: true) != -1)
			{
				xmlTextReader = smethod_1(class746_0, text);
				@class = new Class532(class1547_0);
				flag = @class.Read(xmlTextReader, arrayList.Count);
				xmlTextReader.Close();
				if (!flag)
				{
					xmlTextReader = smethod_1(class746_0, text);
					Class448 class3 = new Class448(class1547_0);
					flag = class3.Read(xmlTextReader);
					xmlTextReader.Close();
				}
			}
		}
		return flag;
	}

	private void method_35()
	{
		Hashtable hashtable = class1547_0.method_3();
		ArrayList arrayList_ = class1547_0.arrayList_0;
		int num = 0;
		Class1562 @class;
		while (true)
		{
			if (num < arrayList_.Count)
			{
				@class = (Class1562)arrayList_[num];
				if (!hashtable.ContainsKey(@class.string_2))
				{
					break;
				}
				Class1564 class2 = (Class1564)hashtable[@class.string_2];
				string fileName = Path.GetFileName(class2.string_3);
				Class1101 class3 = new Class1101(class1547_0, class2.string_3, @class.string_0, class746_0, fileName);
				Hashtable hashtable_ = method_36(fileName);
				string string_ = "xl/pivotCache/" + fileName;
				XmlTextReader xmlTextReader_ = smethod_1(class746_0, string_);
				class3.Read(xmlTextReader_);
				class3.method_0().hashtable_0 = hashtable_;
				class3.method_1();
				num++;
				continue;
			}
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "pivotCache rid " + @class.string_2 + " not found in workbook rels file");
	}

	private Hashtable method_36(string string_0)
	{
		string text = "xl/pivotCache/_rels/" + string_0 + ".rels";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			Hashtable hashtable_ = Class1608.Read(xmlTextReader);
			class1547_0.method_7(hashtable_);
			xmlTextReader.Close();
		}
		return class1547_0.method_6();
	}

	private void method_37(Class1548 class1548_0)
	{
		if (class1548_0.hashtable_0 == null || class1548_0.hashtable_0.Count == 0)
		{
			return;
		}
		class1548_0.worksheet_0.pivotTableCollection_0 = new PivotTableCollection(class1548_0.worksheet_0);
		ArrayList arrayList = Class1608.smethod_7(class1548_0.hashtable_0, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotTable");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1564 @class = (Class1564)arrayList[i];
			string string_ = "xl/pivotTables/" + Path.GetFileName(@class.string_3);
			XmlTextReader xmlTextReader = smethod_1(class746_0, string_);
			if (xmlTextReader != null)
			{
				Class1607 class2 = new Class1607(class1547_0, class1548_0, @class.string_3);
				class2.Read(xmlTextReader);
				xmlTextReader.Close();
			}
		}
	}

	private void method_38(Class1548 class1548_0)
	{
		string text = class1548_0.method_3(class1548_0.string_2);
		if (text != null)
		{
			XmlTextReader xmlTextReader = null;
			string text2 = "xl/drawings/_rels/" + Path.GetFileName(text) + ".rels";
			text = Class1618.smethod_212(text);
			Hashtable hashtable_ = null;
			if (class746_0.method_40(text2, bool_18: true) != -1)
			{
				xmlTextReader = smethod_1(class746_0, text2);
				hashtable_ = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			Class1613 @class = new Class1613(class1548_0, hashtable_, class746_0, text);
			@class.Read();
			class1548_0.worksheet_0.class1557_0.arrayList_10 = @class.method_26();
			workbook_0.class1558_0.method_4(text);
		}
	}

	private void method_39(Class1548 class1548_0)
	{
		string text = class1548_0.method_1();
		if (text != null)
		{
			XmlTextReader xmlTextReader = smethod_1(class746_0, text);
			Class1599 @class = new Class1599(class1547_0, class1548_0);
			@class.Read(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private void method_40(Class1548 class1548_0, string string_0)
	{
		string string_ = "xl/chartsheets/" + string_0;
		Class1598 @class = new Class1598(class1547_0, class1548_0);
		XmlTextReader xmlTextReader = smethod_1(class746_0, string_);
		@class.Read(xmlTextReader);
		xmlTextReader.Close();
		class1548_0.worksheet_0.class1557_0.string_0 = string_;
	}

	private void method_41(Class1548 class1548_0)
	{
		string text = class1548_0.method_3(class1548_0.string_4);
		if (text != null)
		{
			XmlTextReader xmlTextReader = null;
			string text2 = "xl/drawings/_rels/" + Path.GetFileName(text) + ".rels";
			text = Class1618.smethod_212(text);
			Hashtable hashtable_ = null;
			if (class746_0.method_40(text2, bool_18: false) != -1)
			{
				xmlTextReader = smethod_1(class746_0, text2);
				hashtable_ = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			Class744 class744_ = class746_0.method_38(text);
			Stream stream = class746_0.method_39(class744_);
			XmlDocument xmlDocument_ = Class1188.smethod_3(stream);
			stream.Close();
			Class1604 @class = new Class1604(class1548_0, xmlDocument_, hashtable_, class746_0);
			@class.method_0();
			if (@class.method_48().Count > 0)
			{
				class1548_0.worksheet_0.method_36().method_1(@class.method_48());
			}
			workbook_0.class1558_0.method_4(text);
		}
	}

	internal static Shape smethod_0(Shape shape_0)
	{
		Class746 @class = null;
		Workbook workbook = shape_0.method_25().Workbook;
		if (workbook.class1558_0 != null && workbook.class1558_0.class1553_0 != null)
		{
			workbook.class1558_0.class1553_0.method_1();
			@class = workbook.class1558_0.class1553_0.class746_0;
			string string_ = shape_0.string_1;
			XmlTextReader xmlTextReader = null;
			string text = "xl/diagrams/_rels/" + Path.GetFileName(string_) + ".rels";
			string_ = Class1618.smethod_212(string_);
			Hashtable hashtable_ = null;
			if (@class.method_40(text, bool_18: false) != -1)
			{
				xmlTextReader = smethod_1(@class, text);
				hashtable_ = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			Class744 class744_ = @class.method_38(string_);
			Stream stream = @class.method_39(class744_);
			XmlDocument xmlDocument_ = Class1188.smethod_3(stream);
			stream.Close();
			Worksheet worksheet = shape_0.method_26();
			Class1547 class1547_ = new Class1547(workbook);
			Class1548 class1548_ = new Class1548(class1547_, worksheet);
			Class1604 class2 = new Class1604(class1548_, xmlDocument_, hashtable_, @class);
			ShapeCollection shapeCollection_ = new ShapeCollection(worksheet.method_2(), worksheet, new Class1703(worksheet.method_2(), Enum181.const_0), worksheet, -1);
			class2.shapeCollection_0 = shapeCollection_;
			return class2.method_4(shape_0);
		}
		return null;
	}

	internal static XmlTextReader smethod_1(Class746 class746_1, string string_0)
	{
		return Class536.smethod_5(class746_1, string_0);
	}
}
