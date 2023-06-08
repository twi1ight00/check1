using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns16;
using ns2;

namespace ns10;

internal class Class1229
{
	private Workbook workbook_0;

	private Stream stream_0;

	private Stream6 stream6_0;

	private Class1540 class1540_0;

	private bool bool_0 = true;

	private Class746 class746_0;

	internal Class1229(Workbook workbook_1, bool bool_1)
	{
		workbook_0 = workbook_1;
		bool_0 = bool_1;
	}

	internal void Write(Stream stream_1)
	{
		stream_0 = stream_1;
		try
		{
			Write();
		}
		finally
		{
			if (workbook_0.class1558_0 != null && workbook_0.class1558_0.class1553_0 != null)
			{
				workbook_0.class1558_0.class1553_0.Close();
			}
		}
	}

	private void Write()
	{
		method_33();
		method_2();
		method_28();
		method_27();
		method_26();
		method_25();
		method_7();
		method_6(stream6_0);
		string string_ = "xl/workbook.bin";
		Class1226 @class = new Class1226(this, class1540_0);
		@class.Write(string_, stream6_0);
		string string_2 = "xl/styles.bin";
		Class1221 class2 = new Class1221(this, class1540_0);
		class2.Write(string_2, stream6_0);
		if (workbook_0.Worksheets.class1301_0.method_2() != 0)
		{
			string string_3 = "xl/sharedStrings.bin";
			Class1219 class3 = new Class1219(this, workbook_0);
			class3.Write(string_3, stream6_0);
		}
		method_24();
		method_23();
		method_10();
		method_1();
		method_29();
		stream6_0.method_22();
	}

	private void method_0()
	{
		string string_ = workbook_0.class1558_0.string_0;
		method_31(string_, "xl/vbaProject.bin");
		method_31("xl/_rels/" + Path.GetFileName(string_) + ".rels", "xl/_rels/vbaProject.bin.rels");
		Class1530 @class = workbook_0.class1558_0.method_7("application/vnd.ms-office.vbaProjectSignature");
		if (@class != null)
		{
			string text = @class.string_1;
			if (text[0] == '/')
			{
				text = text.Substring(1);
			}
			method_31(text, text);
		}
	}

	private void method_1()
	{
		if (workbook_0.HasMacro)
		{
			if (workbook_0.class1558_0 != null && workbook_0.class1558_0.string_0 != null)
			{
				method_0();
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
		if (workbook_0.class1558_0 != null)
		{
			method_30("xl/diagrams/");
			method_30("xl/printerSettings/");
			method_30("xl/activeX");
			method_30("xl/queryTables");
			if (workbook_0.Settings.method_7())
			{
				method_30("xl/revisions/");
			}
			method_30("userCustomization/");
			if (workbook_0.IsDigitallySigned)
			{
				method_30("_xmlsignatures/");
			}
			method_30("customXml/");
			method_30("xl/slicerCaches/");
			method_30("xl/slicers/");
			method_31("xl/connections.bin", "xl/connections.bin");
			method_31("xl/attachedToolbars.bin", "xl/attachedToolbars.bin");
			method_30("vstoDataStore/");
			method_3();
			method_4();
		}
	}

	private void method_3()
	{
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

	private void method_4()
	{
		if (workbook_0.class1558_0 == null || workbook_0.class1558_0.arrayList_4.Count == 0)
		{
			return;
		}
		ArrayList arrayList_ = workbook_0.class1558_0.arrayList_4;
		for (int i = 0; i < arrayList_.Count; i++)
		{
			Class1366 @class = (Class1366)arrayList_[i];
			if (!@class.string_2.StartsWith("customXml"))
			{
				method_31(@class.string_1, @class.string_2);
				string string_ = Class1618.smethod_176(@class.string_1);
				string string_2 = Class1618.smethod_176(@class.string_2);
				method_5(string_, string_2);
			}
		}
	}

	private void method_5(string string_0, string string_1)
	{
		if (class746_0.method_40(string_0, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader = Class1615.smethod_1(class746_0, string_0);
			ArrayList arrayList = Class1608.smethod_0(xmlTextReader);
			xmlTextReader.Close();
			workbook_0.class1558_0.method_5(arrayList);
			XmlTextWriter xmlTextWriter = smethod_0(string_1, stream6_0);
			Class1588.smethod_2(xmlTextWriter, arrayList);
			xmlTextWriter.Flush();
		}
	}

	private void method_6(Stream6 stream6_1)
	{
		Class1303 @class = workbook_0.Worksheets.method_39();
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
			string string_ = "xl/externalLinks/externalLink" + num + ".bin";
			string string_2 = "xl/externalLinks/_rels/externalLink" + num + ".bin.rels";
			if (class2.Type == Enum194.const_0 || class2.Type == Enum194.const_4)
			{
				string text2 = class2.method_26();
				text2 = text2.Replace(" ", "%20");
				string string_3 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/externalLinkPath";
				if (class2.Type == Enum194.const_4)
				{
					class2.method_20(out var _, out var fileName);
					text2 = fileName;
					string_3 = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/oleObject";
				}
				if (text2 != null && text2 != "")
				{
					method_34(string_2, string_3, text2, "External");
				}
			}
			Class1211 class3 = new Class1211(this, class2);
			class3.Write(string_, stream6_1);
		}
	}

	private void method_7()
	{
		Class1584 @class = new Class1584(class1540_0);
		@class.method_0(stream6_0);
	}

	private void method_8(Class1541 class1541_0)
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
			XmlTextWriter xmlTextWriter = smethod_0(string_2, stream6_0);
			Class1588.smethod_2(xmlTextWriter, class1541_0.class1534_1.arrayList_0);
			xmlTextWriter.Flush();
		}
		int count = class1541_0.class1534_1.arrayList_2.Count;
		if (count != 0)
		{
			for (int i = 0; i < count; i++)
			{
				Class1357 class2 = (Class1357)class1541_0.class1534_1.arrayList_2[i];
				method_9(class2);
				class1540_0.method_22(class2.string_0);
			}
		}
	}

	private void method_9(Class1357 class1357_0)
	{
		string string_ = "xl/media/" + class1357_0.string_0;
		Class744 @class = stream6_0.method_18(string_);
		@class.method_5(DateTime.Now);
		stream6_0.Write(class1357_0.byte_0, 0, class1357_0.byte_0.Length);
		stream6_0.Flush();
	}

	private void method_10()
	{
		for (int i = 0; i < class1540_0.arrayList_0.Count; i++)
		{
			Class1541 class1541_ = (Class1541)class1540_0.arrayList_0[i];
			method_11(class1541_);
		}
	}

	private void method_11(Class1541 class1541_0)
	{
		if (class1541_0.worksheet_0.Type == SheetType.Worksheet)
		{
			method_22(class1541_0);
		}
		else if (class1541_0.worksheet_0.Type == SheetType.Chart)
		{
			method_21(class1541_0);
		}
		method_20(class1541_0);
		method_19(class1541_0);
		method_18(class1541_0);
		method_8(class1541_0);
		method_14(class1541_0);
		method_13(class1541_0);
		method_12(class1541_0);
	}

	private void method_12(Class1541 class1541_0)
	{
		if (class1541_0.hashtable_2.Count != 0)
		{
			IDictionaryEnumerator enumerator = class1541_0.hashtable_2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ListObject listObject_ = (ListObject)enumerator.Key;
				string string_ = (string)enumerator.Value;
				Class1564 @class = Class1608.smethod_6(class1541_0.arrayList_1, string_);
				string text = "xl" + @class.string_3.Substring(2);
				Class1223 class2 = new Class1223(this, listObject_);
				class2.Write(text, stream6_0);
				class1540_0.method_20("/" + text, "application/vnd.ms-excel.table");
			}
		}
	}

	private void method_13(Class1541 class1541_0)
	{
		Class1534 class1534_ = class1541_0.class1534_0;
		if (class1534_ != null && class1534_.arrayList_0 != null && class1534_.arrayList_0.Count != 0)
		{
			string string_ = "xl/drawings/" + class1534_.string_1;
			XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
			Class1582 @class = new Class1582(class1541_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			if (class1534_.arrayList_0 != null && class1534_.arrayList_0.Count > 0)
			{
				string string_2 = "xl/drawings/_rels/" + class1534_.string_1 + ".rels";
				xmlTextWriter = smethod_0(string_2, stream6_0);
				Class1588.smethod_2(xmlTextWriter, class1534_.arrayList_0);
				xmlTextWriter.Flush();
			}
		}
	}

	private void method_14(Class1541 class1541_0)
	{
		for (int i = 0; i < class1541_0.class1358_0.arrayList_1.Count; i++)
		{
			Class1533 @class = (Class1533)class1541_0.class1358_0.arrayList_1[i];
			string string_ = "xl/charts/chart" + Class1618.smethod_80(@class.int_0) + ".xml";
			XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
			Class1572 class2 = new Class1572(@class);
			class2.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			method_15(@class);
			if (@class.arrayList_1.Count != 0)
			{
				method_16(@class);
			}
			if (@class.class1358_0 != null)
			{
				method_17(@class);
			}
		}
	}

	private void method_15(Class1533 class1533_0)
	{
		int count = class1533_0.arrayList_0.Count;
		if (count != 0)
		{
			for (int i = 0; i < count; i++)
			{
				Class1357 @class = (Class1357)class1533_0.arrayList_0[i];
				method_9(@class);
				class1540_0.method_22(@class.string_0);
			}
		}
	}

	private void method_16(Class1533 class1533_0)
	{
		int int_ = class1533_0.int_0;
		string string_ = "xl/charts/_rels/chart" + Class1618.smethod_80(int_) + ".xml.rels";
		XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
		Class1588.smethod_2(xmlTextWriter, class1533_0.arrayList_1);
		xmlTextWriter.Flush();
	}

	private void method_17(Class1533 class1533_0)
	{
		string text = "xl/drawings/" + class1533_0.class1358_0.string_1;
		XmlTextWriter xmlTextWriter = smethod_0(text, stream6_0);
		Class1579 @class = new Class1579(class1533_0.class1358_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
		ArrayList arrayList_ = class1533_0.class1358_0.arrayList_0;
		if (arrayList_ != null && arrayList_.Count > 0)
		{
			string string_ = "xl/drawings/_rels/" + class1533_0.class1358_0.string_1 + ".rels";
			xmlTextWriter = smethod_0(string_, stream6_0);
			Class1588.smethod_2(xmlTextWriter, arrayList_);
			xmlTextWriter.Flush();
		}
		class1540_0.method_20("/" + text, "application/vnd.openxmlformats-officedocument.drawingml.chartshapes+xml");
	}

	private void method_18(Class1541 class1541_0)
	{
		if (class1541_0.class1358_0.string_0 != null)
		{
			string string_ = "xl/drawings/" + class1541_0.class1358_0.string_1;
			string string_2 = "xl/drawings/_rels/" + class1541_0.class1358_0.string_1 + ".rels";
			XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
			Class1579 @class = new Class1579(class1541_0.class1358_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
			if (class1541_0.class1358_0.arrayList_0 != null && class1541_0.class1358_0.arrayList_0.Count > 0)
			{
				xmlTextWriter = smethod_0(string_2, stream6_0);
				Class1588.smethod_2(xmlTextWriter, class1541_0.class1358_0.arrayList_0);
				xmlTextWriter.Flush();
			}
		}
	}

	private void method_19(Class1541 class1541_0)
	{
		if (class1541_0.method_17())
		{
			string string_ = "xl/" + class1541_0.string_0;
			Class1216 @class = new Class1216(this, class1541_0);
			@class.Write(string_, stream6_0);
		}
	}

	private void method_20(Class1541 class1541_0)
	{
		if (class1541_0.arrayList_1 != null && class1541_0.arrayList_1.Count != 0)
		{
			string string_ = "xl/worksheets/_rels/sheet" + class1541_0.int_1 + ".bin.rels";
			if (class1541_0.worksheet_0.Type == SheetType.Chart)
			{
				string_ = "xl/chartsheets/_rels/sheet" + class1541_0.int_1 + ".bin.rels";
			}
			XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
			Class1588.smethod_2(xmlTextWriter, class1541_0.arrayList_1);
			xmlTextWriter.Flush();
		}
	}

	private void method_21(Class1541 class1541_0)
	{
		string string_ = "xl/chartsheets/sheet" + class1541_0.int_1 + ".bin";
		Class1214 @class = new Class1214(this, class1540_0);
		@class.Write(class1541_0, string_, stream6_0);
	}

	private void method_22(Class1541 class1541_0)
	{
		string string_ = "xl/worksheets/sheet" + class1541_0.int_1 + ".bin";
		Class1228 @class = new Class1228(this, class1540_0);
		@class.Write(class1541_0, string_, stream6_0);
	}

	private void method_23()
	{
		string string_ = "xl/_rels/workbook.bin.rels";
		XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
		Class1588.smethod_2(xmlTextWriter, class1540_0.arrayList_1);
		xmlTextWriter.Flush();
	}

	private void method_24()
	{
		string string_ = "xl/theme/theme1.xml";
		XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
		Class1591 @class = new Class1591(class1540_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
		if (workbook_0.class1558_0 != null)
		{
			string string_2 = "xl/theme/_rels/" + Path.GetFileName(workbook_0.class1558_0.string_1) + ".rels";
			string string_3 = "xl/theme/_rels/theme1.xml.rels";
			method_31(string_2, string_3);
		}
	}

	private void method_25()
	{
		if (class1540_0.method_35())
		{
			string string_ = "docProps/custom.xml";
			XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
			Class1578 @class = new Class1578(class1540_0);
			@class.Write(xmlTextWriter);
			xmlTextWriter.Flush();
		}
	}

	private void method_26()
	{
		string string_ = "docProps/app.xml";
		XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
		Class1576 @class = new Class1576(class1540_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_27()
	{
		string string_ = "docProps/core.xml";
		XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
		Class1577 @class = new Class1577(class1540_0);
		@class.Write(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_28()
	{
		string string_ = "_rels/.rels";
		XmlTextWriter xmlTextWriter = smethod_0(string_, stream6_0);
		Class1588.smethod_1(class1540_0, xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_29()
	{
		XmlTextWriter xmlTextWriter = smethod_0("[Content_Types].xml", stream6_0);
		Class1575 @class = new Class1575(class1540_0);
		@class.method_0(xmlTextWriter);
		xmlTextWriter.Flush();
	}

	private void method_30(string string_0)
	{
		method_32(string_0, string_0, bool_1: true);
	}

	private void method_31(string string_0, string string_1)
	{
		method_32(string_0, string_1, bool_1: false);
	}

	private void method_32(string string_0, string string_1, bool bool_1)
	{
		IEnumerator enumerator = class746_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if ((bool_1 || !(@class.Name != string_0)) && (!bool_1 || @class.Name.StartsWith(string_0)))
			{
				if (bool_1)
				{
					string_1 = @class.Name;
				}
				Class744 class2 = stream6_0.method_18(string_1);
				class2.method_5(DateTime.Now);
				byte[] array = new byte[1024];
				int num = 0;
				Stream stream = class746_0.method_39(@class);
				do
				{
					num = stream.Read(array, 0, array.Length);
					stream6_0.Write(array, 0, num);
				}
				while (num > 0);
				stream6_0.Flush();
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

	private void method_33()
	{
		smethod_2(workbook_0.Worksheets);
		workbook_0.Worksheets.method_27();
		if (workbook_0.class1558_0 != null)
		{
			workbook_0.class1558_0.class1553_0.method_1();
			class746_0 = workbook_0.class1558_0.class1553_0.class746_0;
		}
		class1540_0 = new Class1540(workbook_0, class746_0, bool_0, bool_5: false);
		if (class1540_0.arrayList_0.Count == 0)
		{
			throw new CellsException(ExceptionType.InvalidData, "Dot not support export a wbook without normal worksheet to excel 2007 format");
		}
		stream6_0 = new Stream6(stream_0);
		stream6_0.method_6(Enum42.const_12);
	}

	private static XmlTextWriter smethod_0(string string_0, Stream6 stream6_1)
	{
		Class744 @class = stream6_1.method_18(string_0);
		@class.method_5(DateTime.Now);
		XmlTextWriter xmlTextWriter = new XmlTextWriter(stream6_1, Encoding.UTF8);
		xmlTextWriter.Formatting = Formatting.Indented;
		return xmlTextWriter;
	}

	internal void method_34(string string_0, string string_1, string string_2, string string_3)
	{
		ArrayList arrayList = new ArrayList();
		Class1564 value = new Class1564("rId1", string_1, string_2, string_3);
		arrayList.Add(value);
		XmlTextWriter xmlTextWriter = smethod_0(string_0, stream6_0);
		Class1588.smethod_2(xmlTextWriter, arrayList);
		xmlTextWriter.Flush();
	}

	internal static void smethod_1(string string_0, MemoryStream memoryStream_0, Stream6 stream6_1)
	{
		Class744 @class = stream6_1.method_18(string_0);
		@class.method_5(DateTime.Now);
		memoryStream_0.Position = 0L;
		byte[] array = new byte[1024];
		int num = 0;
		do
		{
			num = memoryStream_0.Read(array, 0, array.Length);
			stream6_1.Write(array, 0, num);
		}
		while (num > 0);
	}

	private static void smethod_2(WorksheetCollection worksheetCollection_0)
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
