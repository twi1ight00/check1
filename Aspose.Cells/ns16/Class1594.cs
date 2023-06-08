using System;
using System.Collections;
using System.IO;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Pivot;
using Aspose.Cells.Properties;
using Aspose.Cells.Tables;
using ns2;
using ns22;
using ns45;

namespace ns16;

internal class Class1594
{
	private Workbook workbook_0;

	private Stream stream_0;

	private Stream6 stream6_0;

	private Class1540 class1540_0;

	private bool bool_0;

	private Class746 class746_0;

	private FileFormatType fileFormatType_0 = FileFormatType.Xlsx;

	private OoxmlSaveOptions ooxmlSaveOptions_0;

	private Class1590 class1590_0;

	internal Class1594(Workbook workbook_1, Stream stream_1, FileFormatType fileFormatType_1, OoxmlSaveOptions ooxmlSaveOptions_1)
	{
		workbook_0 = workbook_1;
		stream_0 = stream_1;
		fileFormatType_0 = fileFormatType_1;
		if (fileFormatType_1 == FileFormatType.Xltm || fileFormatType_1 == FileFormatType.Xlsm)
		{
			bool_0 = true;
		}
		workbook_0.FileFormat = FileFormatType.Xlsx;
		ooxmlSaveOptions_0 = ooxmlSaveOptions_1;
	}

	internal void Write()
	{
		workbook_0.Worksheets.method_4().method_0();
		method_55();
		try
		{
			method_48();
			method_43();
			method_0();
			method_42();
			method_41();
			method_40();
			method_39();
			method_45();
			method_34();
			method_5();
			method_33();
			method_29();
			method_30();
			method_28();
			method_3();
			class1590_0 = new Class1590(workbook_0, class1540_0.class1539_0);
			method_7();
			method_32();
			method_31();
			method_1();
			method_44();
			stream6_0.method_22();
			workbook_0.Worksheets.method_4().method_1();
			workbook_0.method_31(stream_0);
		}
		finally
		{
			if (workbook_0.class1558_0 != null && workbook_0.class1558_0.class1553_0 != null)
			{
				workbook_0.class1558_0.class1553_0.Close();
			}
		}
	}

	private void method_0()
	{
		if (class1540_0.workbook_0.RibbonXml != null && class1540_0.workbook_0.RibbonXml.Length > 0)
		{
			string string_ = "customUI/customUI.xml";
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			xmlTextWriter.WriteRaw(class1540_0.workbook_0.RibbonXml);
			xmlTextWriter.Flush();
		}
	}

	private void method_1()
	{
		if (workbook_0.HasMacro && bool_0)
		{
			if (workbook_0.class1558_0 != null && workbook_0.class1558_0.string_0 != null)
			{
				method_47();
				return;
			}
			Stream stream = workbook_0.Worksheets.method_13();
			int num = (int)stream.Length;
			byte[] array = new byte[num];
			stream.Read(array, 0, num);
			stream.Close();
			string string_ = "xl/vbaProject.bin";
			Class744 @class = stream6_0.method_18(string_);
			@class.method_5(DateTime.Now);
			stream6_0.Write(array, 0, array.Length);
			stream6_0.Flush();
		}
	}

	private void method_2()
	{
		if (workbook_0.class1558_0 == null)
		{
			return;
		}
		ArrayList arrayList_ = workbook_0.class1558_0.class1364_0.arrayList_1;
		for (int i = 0; i < arrayList_.Count; i++)
		{
			Class1562 @class = (Class1562)arrayList_[i];
			string fileName = Path.GetFileName(@class.string_1);
			string text = "xl/pivotCache/" + fileName;
			method_53(text, text, bool_1: false);
			string text2 = "xl/pivotCache/_rels/" + fileName + ".rels";
			method_53(text2, text2, bool_1: false);
			if (class746_0 == null)
			{
				break;
			}
			if (class746_0.method_40(text2, bool_18: true) == -1)
			{
				continue;
			}
			XmlTextReader xmlTextReader = Class1615.smethod_1(class746_0, text2);
			Hashtable hashtable = Class1608.Read(xmlTextReader);
			xmlTextReader.Close();
			if (hashtable == null || hashtable.Count <= 0)
			{
				continue;
			}
			IEnumerator enumerator = hashtable.Values.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class1564 class2 = (Class1564)enumerator.Current;
				if (class2 != null)
				{
					string string_ = class2.string_3;
					string_ = "xl/pivotCache/" + string_;
					method_53(string_, string_, bool_1: false);
				}
			}
		}
	}

	private void method_3()
	{
		if (workbook_0.class1558_0 != null)
		{
			ArrayList arrayList_ = workbook_0.class1558_0.class1364_0.arrayList_1;
			if (arrayList_.Count > 0)
			{
				method_2();
			}
		}
		Hashtable hashtable_ = class1540_0.hashtable_2;
		if (hashtable_ == null)
		{
			return;
		}
		IDictionaryEnumerator enumerator = hashtable_.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1141 @class = (Class1141)enumerator.Key;
			if (@class.bool_1)
			{
				continue;
			}
			Class1562 class2 = (Class1562)enumerator.Value;
			string string_;
			string string_2;
			string text2;
			if (class2.string_3 != null)
			{
				string text = "";
				int num = class2.string_3.IndexOf(".");
				if (num != -1)
				{
					text = class2.string_3.Substring(0, num);
					text2 = "xl/pivotCache/" + text + ".xml";
					string_ = "xl/pivotCache/_rels/" + text + ".xml.rels";
					string_2 = "xl/pivotCache/pivotCacheRecords" + text.Substring(20) + ".xml";
				}
				else
				{
					text2 = "xl/pivotCache/" + class2.string_3;
					string_ = "xl/pivotCache/_rels/" + class2.string_3 + ".rels";
					string_2 = "xl/pivotCache/pivotCacheRecords" + class2.string_3.Substring(20);
				}
			}
			else
			{
				text2 = "xl/pivotCache/pivotCacheDefinition" + class2.int_0 + ".xml";
				string_ = "xl/pivotCache/_rels/pivotCacheDefinition" + class2.int_0 + ".xml.rels";
				string_2 = "xl/pivotCache/pivotCacheRecords" + class2.int_0 + ".xml";
			}
			Class1585 class3 = new Class1585(@class);
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(text2, stream6_0);
			class3.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			if (@class.hashtable_0 != null && @class.hashtable_0.Count > 0)
			{
				ArrayList arrayList = new ArrayList();
				IEnumerator enumerator2 = @class.hashtable_0.Keys.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					string key = (string)enumerator2.Current;
					Class1564 class4 = (Class1564)@class.hashtable_0[key];
					int num2 = class4.string_3.IndexOf(".");
					if (num2 != -1)
					{
						string string_3 = class4.string_3.Substring(0, num2) + class1540_0.string_0;
						class4.string_3 = string_3;
					}
					arrayList.Add(@class.hashtable_0[key]);
				}
				int num3 = text2.LastIndexOf("/");
				text2 = "xl/pivotCache/_rels/" + text2.Substring(num3 + 1) + ".rels";
				xmlTextWriter = Class1029.smethod_5(text2, stream6_0);
				Class1588.smethod_2(xmlTextWriter, arrayList);
				xmlTextWriter.Flush();
			}
			else
			{
				string string_4 = "pivotCacheRecords" + class2.int_0 + ".xml";
				method_4(string_, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotCacheRecords", string_4, null);
			}
			if (@class.class1144_0 != null)
			{
				Class1586 class5 = new Class1586(@class);
				xmlTextWriter = Class1029.smethod_5(string_2, stream6_0);
				class5.Write(xmlTextWriter);
				xmlTextWriter.Flush();
			}
		}
	}

	private void method_4(string string_0, string string_1, string string_2, string string_3)
	{
		ArrayList arrayList = new ArrayList();
		Class1564 value = new Class1564("rId1", string_1, string_2, string_3);
		arrayList.Add(value);
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_0, stream6_0);
		Class1588.smethod_2(xmlTextWriter, arrayList);
		xmlTextWriter.Flush();
	}

	private void method_5()
	{
		Class1303 @class = workbook_0.Worksheets.method_39();
		if (!class1540_0.method_38())
		{
			return;
		}
		int num = 0;
		for (int i = 0; i < @class.Count; i++)
		{
			Class1718 class2 = @class[i];
			string text = class2.method_25();
			if (text == null || text.Trim().Length == 0 || (class2.Type != Enum194.const_3 && class2.Type != 0 && class2.Type != Enum194.const_4))
			{
				continue;
			}
			num++;
			string string_ = "xl/externalLinks/externalLink" + num + ".xml";
			string string_2 = "xl/externalLinks/_rels/externalLink" + num + ".xml.rels";
			if (class2.Type == Enum194.const_0 || class2.Type == Enum194.const_4)
			{
				string text2 = null;
				string string_3 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/externalLinkPath";
				if (class2.Type == Enum194.const_4)
				{
					class2.method_22(out var _, out var fileName);
					text2 = fileName;
					string_3 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/oleObject";
				}
				else
				{
					text2 = class2.method_26();
				}
				text2 = text2.Replace(" ", "%20");
				if (text2 != null && text2 != "")
				{
					method_4(string_2, string_3, text2, "External");
				}
			}
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class1581 class3 = new Class1581(class1540_0, class2);
			class3.Write(xmlTextWriter);
			xmlTextWriter.Flush();
		}
	}

	private void method_6(Class1541 class1541_0)
	{
		if (class1541_0.class1534_1.string_0 == null)
		{
			return;
		}
		string string_ = "xl/drawings/" + class1541_0.class1534_1.string_1;
		Class1592 @class = new Class1592(class1541_0);
		@class.Write(stream6_0, string_);
		string text = "xl/drawings/_rels/";
		string string_2 = text + class1541_0.class1534_1.string_1 + ".rels";
		if (class1541_0.class1534_1.arrayList_0.Count > 0)
		{
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_2, stream6_0);
			Class1588.smethod_2(xmlTextWriter, class1541_0.class1534_1.arrayList_0);
			xmlTextWriter.Flush();
		}
		int count = class1541_0.class1534_1.arrayList_2.Count;
		if (count != 0)
		{
			for (int i = 0; i < count; i++)
			{
				Class1357 class2 = (Class1357)class1541_0.class1534_1.arrayList_2[i];
				method_19(class2);
				class1540_0.method_22(class2.string_0);
			}
		}
	}

	private void method_7()
	{
		for (int i = 0; i < class1540_0.arrayList_0.Count; i++)
		{
			Class1541 @class = (Class1541)class1540_0.arrayList_0[i];
			method_8(@class);
			if (workbook_0.SaveOptions.ClearData)
			{
				@class.worksheet_0.Cells.Clear();
			}
		}
	}

	private void method_8(Class1541 class1541_0)
	{
		if (class1541_0.worksheet_0.Type == SheetType.Worksheet)
		{
			method_27(class1541_0);
		}
		else if (class1541_0.worksheet_0.Type == SheetType.Chart)
		{
			method_26(class1541_0);
		}
		method_25(class1541_0);
		method_24(class1541_0);
		method_23(class1541_0);
		method_6(class1541_0);
		method_16(class1541_0.class1358_0.arrayList_1);
		method_22(class1541_0);
		method_15(class1541_0);
		method_13(class1541_0);
		method_12(class1541_0);
		method_10(class1541_0);
		method_11(class1541_0);
		method_14(class1541_0);
		method_9(class1541_0);
	}

	private void method_9(Class1541 class1541_0)
	{
		Worksheet worksheet_ = class1541_0.worksheet_0;
		QueryTableCollection queryTables = worksheet_.QueryTables;
		if (queryTables.Count == 0)
		{
			return;
		}
		for (int i = 0; i < queryTables.Count; i++)
		{
			QueryTable queryTable = queryTables[i];
			string string_ = queryTable.string_0;
			if (string_ != null)
			{
				XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
				Class445 @class = new Class445(class1540_0, queryTable);
				@class.Write(xmlTextWriter);
				xmlTextWriter.Flush();
			}
		}
	}

	private void method_10(Class1541 class1541_0)
	{
		int count = class1541_0.arrayList_5.Count;
		if (count != 0)
		{
			for (int i = 0; i < count; i++)
			{
				Class1361 @class = (Class1361)class1541_0.arrayList_5[i];
				string string_ = "xl/" + @class.string_2;
				Class744 class2 = stream6_0.method_18(string_);
				class2.method_5(DateTime.Now);
				stream6_0.Write(@class.byte_0, 0, @class.byte_0.Length);
				stream6_0.Flush();
			}
		}
	}

	private void method_11(Class1541 class1541_0)
	{
		if (class1541_0.hashtable_1 != null && class1541_0.hashtable_1.Count != 0)
		{
			IEnumerator enumerator = class1541_0.hashtable_1.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text = (string)enumerator.Current;
				Class744 @class = stream6_0.method_18(text);
				@class.method_5(DateTime.Now);
				byte[] array = (byte[])class1541_0.hashtable_1[text];
				stream6_0.Write(array, 0, array.Length);
				stream6_0.Flush();
			}
		}
	}

	private void method_12(Class1541 class1541_0)
	{
		if (workbook_0.class1558_0 == null || class1541_0.worksheet_0.class1557_0 == null)
		{
			return;
		}
		int count = class1541_0.arrayList_1.Count;
		for (int i = 0; i < count; i++)
		{
			Class1564 @class = (Class1564)class1541_0.arrayList_1[i];
			if (@class.string_2 == "http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotTable")
			{
				object obj = class1541_0.worksheet_0.class1557_0.hashtable_0[@class.string_3];
				if (obj != null)
				{
					Class1554 class2 = (Class1554)obj;
					Class1583 class3 = new Class1583(class1541_0, class2.string_1);
					string string_ = "xl/pivotTables/" + Path.GetFileName(@class.string_3);
					class3.Write(stream6_0, string_);
					string text = "xl/pivotTables/_rels/" + Path.GetFileName(@class.string_3) + ".rels";
					method_52(text, text);
				}
			}
		}
	}

	private void method_13(Class1541 class1541_0)
	{
		int count = class1541_0.arrayList_3.Count;
		if (count == 0)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			Class1538 @class = (Class1538)class1541_0.arrayList_3[i];
			if (!@class.oleObject_0.IsLink)
			{
				byte[] array = @class.oleObject_0.method_80();
				string string_ = "xl/embeddings/" + @class.string_2;
				Class744 class2 = stream6_0.method_18(string_);
				class2.method_5(DateTime.Now);
				stream6_0.Write(array, 0, array.Length);
				stream6_0.Flush();
			}
		}
	}

	private void method_14(Class1541 class1541_0)
	{
		if (class1541_0.hashtable_2.Count == 0)
		{
			return;
		}
		IDictionaryEnumerator enumerator = class1541_0.hashtable_2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			ListObject listObject = (ListObject)enumerator.Key;
			string string_ = (string)enumerator.Value;
			Class1564 @class = Class1608.smethod_6(class1541_0.arrayList_1, string_);
			string text = "xl" + @class.string_3.Substring(2);
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(text, stream6_0);
			Class1333 class2 = new Class1333(class1541_0, listObject);
			class2.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			class1540_0.method_20("/" + text, "application/vnd.openxmlformats-officedocument.spreadsheetml.table+xml");
			if (listObject.hashtable_0 != null && listObject.hashtable_0.Count > 0)
			{
				ArrayList arrayList = new ArrayList();
				IEnumerator enumerator2 = listObject.hashtable_0.Keys.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					string key = (string)enumerator2.Current;
					arrayList.Add(listObject.hashtable_0[key]);
				}
				int num = text.LastIndexOf("/");
				text = "xl/tables/_rels/" + text.Substring(num + 1) + ".rels";
				xmlTextWriter = Class1029.smethod_5(text, stream6_0);
				Class1588.smethod_2(xmlTextWriter, arrayList);
				xmlTextWriter.Flush();
			}
		}
	}

	private void method_15(Class1541 class1541_0)
	{
		PivotTableCollection pivotTableCollection_ = class1541_0.worksheet_0.pivotTableCollection_0;
		if (pivotTableCollection_ == null || pivotTableCollection_.Count == 0)
		{
			return;
		}
		for (int i = 0; i < pivotTableCollection_.Count; i++)
		{
			PivotTable pivotTable = pivotTableCollection_[i];
			int num = (int)class1540_0.hashtable_3[pivotTable];
			string string_ = "xl/pivotTables/pivotTable" + num + ".xml";
			string string_2 = "xl/pivotTables/_rels/pivotTable" + num + ".xml.rels";
			if (pivotTable.class1141_0 != null)
			{
				Class1562 @class = (Class1562)class1540_0.hashtable_2[pivotTable.class1141_0];
				XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
				Class1587 class2 = new Class1587(pivotTable, @class.string_0);
				class2.Write(xmlTextWriter);
				xmlTextWriter.Flush();
				string string_3 = "../pivotCache/pivotCacheDefinition" + @class.int_0 + ".xml";
				method_4(string_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotCacheDefinition", string_3, null);
				continue;
			}
			break;
		}
	}

	private void method_16(ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1533 @class = (Class1533)arrayList_0[i];
			string string_ = "xl/charts/chart" + Class1618.smethod_80(@class.int_0) + ".xml";
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class1572 class2 = new Class1572(@class);
			class2.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			method_17(@class);
			if (@class.arrayList_1.Count != 0)
			{
				method_20(@class);
			}
			if (@class.class1358_0 != null)
			{
				method_21(@class);
			}
		}
	}

	private void method_17(Class1533 class1533_0)
	{
		int count = class1533_0.arrayList_0.Count;
		if (count != 0)
		{
			for (int i = 0; i < count; i++)
			{
				Class1357 @class = (Class1357)class1533_0.arrayList_0[i];
				method_19(@class);
				class1540_0.method_22(@class.string_0);
			}
		}
	}

	private void method_18(Class1358 class1358_0)
	{
		int count = class1358_0.arrayList_2.Count;
		if (count != 0)
		{
			for (int i = 0; i < count; i++)
			{
				Class1357 @class = (Class1357)class1358_0.arrayList_2[i];
				method_19(@class);
				class1540_0.method_22(@class.string_0);
			}
		}
	}

	private void method_19(Class1357 class1357_0)
	{
		string string_ = "xl/media/" + class1357_0.string_0;
		Class744 @class = stream6_0.method_18(string_);
		@class.method_5(DateTime.Now);
		stream6_0.Write(class1357_0.byte_0, 0, class1357_0.byte_0.Length);
		stream6_0.Flush();
	}

	private void method_20(Class1533 class1533_0)
	{
		int int_ = class1533_0.int_0;
		string string_ = "xl/charts/_rels/chart" + Class1618.smethod_80(int_) + ".xml.rels";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1588.smethod_2(xmlTextWriter, class1533_0.arrayList_1);
		xmlTextWriter.Flush();
	}

	private void method_21(Class1533 class1533_0)
	{
		string text = "xl/drawings/" + class1533_0.class1358_0.string_1;
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(text, stream6_0);
		Class1579 @class = new Class1579(class1533_0.class1358_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
		ArrayList arrayList_ = class1533_0.class1358_0.arrayList_0;
		if (arrayList_ != null && arrayList_.Count > 0)
		{
			string string_ = "xl/drawings/_rels/" + class1533_0.class1358_0.string_1 + ".rels";
			xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class1588.smethod_2(xmlTextWriter, arrayList_);
			xmlTextWriter.Flush();
		}
		class1540_0.method_20("/" + text, "application/vnd.openxmlformats-officedocument.drawingml.chartshapes+xml");
		if (class1533_0.class1358_0.arrayList_1.Count != 0)
		{
			method_16(class1533_0.class1358_0.arrayList_1);
		}
	}

	private void method_22(Class1541 class1541_0)
	{
		Class1534 class1534_ = class1541_0.class1534_0;
		if (class1534_ != null && class1534_.arrayList_0 != null && class1534_.arrayList_0.Count != 0)
		{
			string string_ = "xl/drawings/" + class1534_.string_1;
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class1582 @class = new Class1582(class1541_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			if (class1534_.arrayList_0 != null && class1534_.arrayList_0.Count > 0)
			{
				string string_2 = "xl/drawings/_rels/" + class1534_.string_1 + ".rels";
				xmlTextWriter = Class1029.smethod_5(string_2, stream6_0);
				Class1588.smethod_2(xmlTextWriter, class1534_.arrayList_0);
				xmlTextWriter.Flush();
			}
		}
	}

	private void method_23(Class1541 class1541_0)
	{
		if (class1541_0.class1358_0.string_0 != null)
		{
			string string_ = "xl/drawings/" + class1541_0.class1358_0.string_1;
			string string_2 = "xl/drawings/_rels/" + class1541_0.class1358_0.string_1 + ".rels";
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class1579 @class = new Class1579(class1541_0.class1358_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			method_18(class1541_0.class1358_0);
			if (class1541_0.class1358_0.arrayList_0 != null && class1541_0.class1358_0.arrayList_0.Count > 0)
			{
				xmlTextWriter = Class1029.smethod_5(string_2, stream6_0);
				Class1588.smethod_2(xmlTextWriter, class1541_0.class1358_0.arrayList_0);
				xmlTextWriter.Flush();
			}
		}
	}

	private void method_24(Class1541 class1541_0)
	{
		if (class1541_0.method_17())
		{
			string string_ = "xl/" + class1541_0.string_0;
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class1574 @class = new Class1574(class1541_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
		}
	}

	private void method_25(Class1541 class1541_0)
	{
		if (class1541_0.arrayList_1 != null && class1541_0.arrayList_1.Count != 0)
		{
			string string_ = "xl/worksheets/_rels/sheet" + Class1618.smethod_80(class1541_0.int_1) + ".xml.rels";
			if (class1541_0.worksheet_0.Type == SheetType.Chart)
			{
				string_ = "xl/chartsheets/_rels/sheet" + Class1618.smethod_80(class1541_0.int_1) + ".xml.rels";
			}
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class1588.smethod_2(xmlTextWriter, class1541_0.arrayList_1);
			xmlTextWriter.Flush();
		}
	}

	private void method_26(Class1541 class1541_0)
	{
		string string_ = "xl/chartsheets/sheet" + Class1618.smethod_80(class1541_0.int_1) + ".xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1573 @class = new Class1573(class1541_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_27(Class1541 class1541_0)
	{
		string string_ = "xl/worksheets/sheet" + Class1618.smethod_80(class1541_0.int_1) + ".xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1596 @class = new Class1596(class1541_0, class1540_0.class1539_0, ooxmlSaveOptions_0);
		@class.class1590_0 = class1590_0;
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_28()
	{
		string string_ = "xl/_rels/workbook.xml.rels";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1588.smethod_2(xmlTextWriter, class1540_0.arrayList_1);
		xmlTextWriter.Flush();
	}

	private void method_29()
	{
		string string_ = "xl/theme/theme1.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1591 @class = new Class1591(class1540_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
		if (workbook_0.class1558_0 != null)
		{
			string string_2 = "xl/theme/_rels/" + Path.GetFileName(workbook_0.class1558_0.string_1) + ".rels";
			string string_3 = "xl/theme/_rels/theme1.xml.rels";
			method_50(string_2, string_3);
		}
	}

	private void method_30()
	{
		if (workbook_0.class442_0 != null)
		{
			string string_ = "xl/connections.xml";
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class444 @class = new Class444(class1540_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
		}
	}

	private void method_31()
	{
		string string_ = "xl/sharedStrings.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1589 @class = new Class1589(class1540_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_32()
	{
		string string_ = "xl/styles.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		class1590_0.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_33()
	{
		string string_ = "xl/workbook.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1595 @class = new Class1595(class1540_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_34()
	{
		Class1584 @class = new Class1584(class1540_0);
		@class.method_0(stream6_0);
	}

	private void method_35()
	{
		string string_ = "customXml/item2.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.WriteStartElement("FormTemplates");
		xmlTextWriter.WriteAttributeString("xmlns", null, "http://schemas.microsoft.com/sharepoint/v3/contenttype/forms");
		xmlTextWriter.WriteElementString("Display", "DocumentLibraryForm");
		xmlTextWriter.WriteElementString("Edit", "DocumentLibraryForm");
		xmlTextWriter.WriteElementString("New", "DocumentLibraryForm");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
	}

	private void method_36()
	{
		string string_ = "customXml/itemProps1.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.WriteStartElement("ds:datastoreItem");
		xmlTextWriter.WriteAttributeString("ds:itemID", null, "{BBB4F38B-0799-4886-B61C-8DBB46B47F73}");
		xmlTextWriter.WriteAttributeString("xmlns", "ds", null, "http://schemas.openxmlformats.org/officeDocument/2006/customXml");
		xmlTextWriter.WriteStartElement("ds:schemaRefs", null);
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/office/2006/metadata/properties");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://purl.org/dc/elements/1.1/");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://purl.org/dc/dcmitype/");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/office/2006/documentManagement/types");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://purl.org/dc/terms/");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://www.w3.org/XML/1998/namespace");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "f0ee3e2c-6582-4549-9afa-575e8dac0aa5");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
	}

	private void method_37()
	{
		string string_ = "customXml/itemProps2.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.WriteStartElement("ds:datastoreItem");
		xmlTextWriter.WriteAttributeString("ds:itemID", null, "{3847F8EF-8AAF-48C9-9DFE-A66AC49D528B}");
		xmlTextWriter.WriteAttributeString("xmlns", "ds", null, "http://schemas.openxmlformats.org/officeDocument/2006/customXml");
		xmlTextWriter.WriteStartElement("ds:schemaRefs", null);
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/sharepoint/v3/contenttype/forms");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
	}

	private void method_38()
	{
		string string_ = "customXml/itemProps3.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		xmlTextWriter.WriteStartDocument(standalone: true);
		xmlTextWriter.WriteStartElement("ds:datastoreItem");
		xmlTextWriter.WriteAttributeString("ds:itemID", null, "{CFA01330-14A1-4347-A117-D4993E0979C9}");
		xmlTextWriter.WriteAttributeString("xmlns", "ds", null, "http://schemas.openxmlformats.org/officeDocument/2006/customXml");
		xmlTextWriter.WriteStartElement("ds:schemaRefs", null);
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/office/2006/metadata/contentType");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/office/2006/metadata/properties/metaAttributes");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://www.w3.org/2001/XMLSchema");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/office/2006/metadata/properties");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "f0ee3e2c-6582-4549-9afa-575e8dac0aa5");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/office/2006/documentManagement/types");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/office/infopath/2007/PartnerControls");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.openxmlformats.org/package/2006/metadata/core-properties");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://purl.org/dc/elements/1.1/");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://purl.org/dc/terms/");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("ds:schemaRef", null);
		xmlTextWriter.WriteAttributeString("ds:uri", "http://schemas.microsoft.com/internal/obd");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Flush();
	}

	private void method_39()
	{
		Class1558 class1558_ = workbook_0.class1558_0;
		if (class1558_ != null)
		{
			ArrayList arrayList_ = class1558_.arrayList_4;
			foreach (Class1366 item in arrayList_)
			{
				if (item.string_1.IndexOf("customXml") != -1)
				{
					return;
				}
			}
		}
		bool flag = class1540_0.method_36(class1540_0.arrayList_1, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml");
		ContentTypePropertyCollection contentTypeProperties = class1540_0.workbook_0.ContentTypeProperties;
		if (contentTypeProperties.Count != 0 || flag)
		{
			string string_ = "customXml/item1.xml";
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class533 class2 = new Class533(class1540_0);
			class2.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			method_35();
			string_ = "customXml/item3.xml";
			xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class531 class3 = new Class531(class1540_0);
			class3.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			method_36();
			method_37();
			method_38();
			ArrayList arrayList = new ArrayList();
			Class1564 class4 = new Class1564();
			class4.string_1 = "rId1";
			class4.string_2 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXmlProps";
			class4.string_3 = "itemProps1.xml";
			arrayList.Add(class4);
			string string_2 = "customXml/_rels/item1.xml.rels";
			xmlTextWriter = Class1029.smethod_5(string_2, stream6_0);
			Class1588.smethod_2(xmlTextWriter, arrayList);
			xmlTextWriter.Flush();
			arrayList = new ArrayList();
			class4 = new Class1564();
			class4.string_1 = "rId1";
			class4.string_2 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXmlProps";
			class4.string_3 = "itemProps2.xml";
			arrayList.Add(class4);
			string_2 = "customXml/_rels/item2.xml.rels";
			xmlTextWriter = Class1029.smethod_5(string_2, stream6_0);
			Class1588.smethod_2(xmlTextWriter, arrayList);
			xmlTextWriter.Flush();
			arrayList = new ArrayList();
			class4 = new Class1564();
			class4.string_1 = "rId1";
			class4.string_2 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXmlProps";
			class4.string_3 = "itemProps3.xml";
			arrayList.Add(class4);
			string_2 = "customXml/_rels/item3.xml.rels";
			xmlTextWriter = Class1029.smethod_5(string_2, stream6_0);
			Class1588.smethod_2(xmlTextWriter, arrayList);
			xmlTextWriter.Flush();
		}
	}

	private void method_40()
	{
		if (class1540_0.method_35())
		{
			string string_ = "docProps/custom.xml";
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class1578 @class = new Class1578(class1540_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
		}
	}

	private void method_41()
	{
		string string_ = "docProps/app.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1576 @class = new Class1576(class1540_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_42()
	{
		string string_ = "docProps/core.xml";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1577 @class = new Class1577(class1540_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_43()
	{
		string string_ = "_rels/.rels";
		XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
		Class1588.smethod_0(class1540_0, xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_44()
	{
		XmlTextWriter xmlTextWriter = Class1029.smethod_5("[Content_Types].xml", stream6_0);
		Class1575 @class = new Class1575(class1540_0);
		@class.method_0(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_45()
	{
		XmlMapCollection xmlMaps = class1540_0.workbook_0.Worksheets.XmlMaps;
		if (xmlMaps != null && xmlMaps.Count != 0)
		{
			string string_ = "xl/xmlMaps.xml";
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_, stream6_0);
			Class446 @class = new Class446(class1540_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
		}
	}

	private void method_46()
	{
		if (class746_0 == null)
		{
			return;
		}
		string value = "xl/embeddings";
		IEnumerator enumerator = class746_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if (@class.Name.StartsWith(value) && !workbook_0.class1558_0.method_6(Path.GetFileName(@class.Name)))
			{
				CopyData(@class, @class.Name);
			}
		}
	}

	private void method_47()
	{
		string string_ = workbook_0.class1558_0.string_0;
		method_52(string_, "xl/vbaProject.bin");
		method_52("xl/_rels/" + Path.GetFileName(string_) + ".rels", "xl/_rels/vbaProject.bin.rels");
		Class1530 @class = workbook_0.class1558_0.method_7("application/vnd.ms-office.vbaProjectSignature");
		if (@class != null)
		{
			string text = @class.string_1;
			if (text[0] == '/')
			{
				text = text.Substring(1);
			}
			method_52(text, text);
		}
	}

	private void method_48()
	{
		if (workbook_0.class1558_0 != null)
		{
			method_51("xl/diagrams/");
			method_51("xl/activeX");
			if (workbook_0.Settings.method_7())
			{
				method_51("xl/revisions/");
			}
			method_51("userCustomization/");
			if (workbook_0.IsDigitallySigned)
			{
				method_51("_xmlsignatures/");
			}
			method_51("ctrlProps/");
			method_51("xl/slicerCaches/");
			method_51("xl/slicers/");
			method_51("xl/ink/");
			method_52("xl/attachedToolbars.bin", "xl/attachedToolbars.bin");
			method_51("vstoDataStore/");
			method_46();
			method_49();
		}
	}

	private void method_49()
	{
		if (workbook_0.class1558_0 != null && workbook_0.class1558_0.arrayList_4.Count != 0)
		{
			ArrayList arrayList_ = workbook_0.class1558_0.arrayList_4;
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class1366 @class = (Class1366)arrayList_[i];
				method_52(@class.string_1, @class.string_2);
				string string_ = Class1618.smethod_176(@class.string_1);
				string string_2 = Class1618.smethod_176(@class.string_2);
				method_50(string_, string_2);
			}
		}
	}

	private void method_50(string string_0, string string_1)
	{
		if (class746_0 != null && class746_0.method_40(string_0, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader = Class1615.smethod_1(class746_0, string_0);
			ArrayList arrayList = Class1608.smethod_0(xmlTextReader);
			xmlTextReader.Close();
			workbook_0.class1558_0.method_5(arrayList);
			XmlTextWriter xmlTextWriter = Class1029.smethod_5(string_1, stream6_0);
			Class1588.smethod_2(xmlTextWriter, arrayList);
			xmlTextWriter.Flush();
		}
	}

	private void method_51(string string_0)
	{
		method_53(string_0, string_0, bool_1: true);
	}

	private void method_52(string string_0, string string_1)
	{
		method_53(string_0, string_1, bool_1: false);
	}

	private void method_53(string string_0, string string_1, bool bool_1)
	{
		method_54(string_0, string_1, bool_1, null);
	}

	private void method_54(string string_0, string string_1, bool bool_1, string string_2)
	{
		if (class746_0 == null)
		{
			return;
		}
		IEnumerator enumerator = class746_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if ((!bool_1 && @class.Name != string_0) || (bool_1 && !@class.Name.StartsWith(string_0)) || (string_2 != null && @class.Name.IndexOf(string_2) != -1))
			{
				continue;
			}
			if (bool_1)
			{
				string_1 = @class.Name;
			}
			if (!@class.method_18())
			{
				if (string_1.EndsWith(".rels"))
				{
					method_50(@class.Name, string_1);
				}
				else
				{
					CopyData(@class, string_1);
				}
			}
		}
	}

	private void CopyData(Class744 class744_0, string string_0)
	{
		Class744 @class = stream6_0.method_18(string_0);
		@class.method_5(DateTime.Now);
		byte[] array = new byte[1024];
		int num = 0;
		Stream stream = class746_0.method_39(class744_0);
		do
		{
			num = stream.Read(array, 0, array.Length);
			stream6_0.Write(array, 0, num);
		}
		while (num > 0);
		stream6_0.Flush();
	}

	private void method_55()
	{
		smethod_0(workbook_0.Worksheets);
		workbook_0.Worksheets.method_27();
		if (workbook_0.class1558_0 != null && workbook_0.class1558_0.class1553_0 != null)
		{
			workbook_0.class1558_0.class1553_0.method_1();
			class746_0 = workbook_0.class1558_0.class1553_0.class746_0;
		}
		class1540_0 = new Class1540(workbook_0, class746_0, bool_0, fileFormatType_0);
		if (class1540_0.arrayList_0.Count == 0)
		{
			throw new CellsException(ExceptionType.InvalidData, "Dot not support export a wbook without normal worksheet to excel 2007 format");
		}
		stream6_0 = new Stream6(stream_0);
		stream6_0.method_6(Enum42.const_4);
		stream6_0.method_10(Enum32.const_0);
	}

	private static void smethod_0(WorksheetCollection worksheetCollection_0)
	{
		if (Class972.smethod_0() == Enum134.const_0)
		{
			for (int i = 0; i < worksheetCollection_0.Count; i++)
			{
				worksheetCollection_0[i].IsSelected = false;
			}
			Worksheet worksheet_ = worksheetCollection_0[worksheetCollection_0.Add()];
			Class1677.smethod_36(worksheet_);
		}
	}
}
