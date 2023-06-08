using System;
using System.Collections;
using System.IO;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using ns16;
using ns2;
using ns22;
using ns25;
using ns45;

namespace ns10;

internal class Class1218
{
	internal Workbook workbook_0;

	internal Class1547 class1547_0;

	internal Class746 class746_0;

	internal static XmlTextReader smethod_0(Class746 class746_1, string string_0)
	{
		return Class536.smethod_5(class746_1, string_0);
	}

	internal static Class1212 smethod_1(Class746 class746_1, string string_0)
	{
		Class744 @class = class746_1.method_38(string_0);
		if (@class == null)
		{
			return null;
		}
		Stream stream = class746_1.method_39(@class);
		byte[] array = new byte[(int)@class.Size];
		stream.Read(array, 0, array.Length);
		try
		{
			stream.Close();
		}
		catch
		{
		}
		return new Class1212(array);
	}

	internal Class1218(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		class1547_0 = new Class1547(workbook_1);
		class746_0 = workbook_1.class1558_0.class1553_0.class746_0;
	}

	internal byte[] method_0(Class1212 class1212_0)
	{
		int int_ = class1212_0.method_1();
		return class1212_0.method_2(int_);
	}

	internal void Read()
	{
		XmlTextReader xmlTextReader = null;
		try
		{
			string text = "xl/workbook.bin";
			try
			{
				if (class746_0.method_40(text, bool_18: true) == -1)
				{
					throw new CellsException(ExceptionType.FileFormat, "Invalid Excel2007Xlsb file format");
				}
			}
			catch
			{
				throw new CellsException(ExceptionType.FileFormat, "Invalid Excel2007Xlsb file format");
			}
			string string_ = "xl/_rels/workbook.bin.rels";
			xmlTextReader = smethod_0(class746_0, string_);
			class1547_0.method_5(Class1608.Read(xmlTextReader));
			xmlTextReader.Close();
			class1547_0.method_12(workbook_0.class1558_0.class1364_0.arrayList_0);
			Class1225 @class = new Class1225(this);
			@class.Read(smethod_1(class746_0, text), class746_0);
			method_7(class746_0);
			method_5(class746_0);
			string string_2 = "docProps/core.xml";
			Class1602 class2 = new Class1602(class1547_0);
			xmlTextReader = smethod_0(class746_0, string_2);
			class2.Read(xmlTextReader);
			xmlTextReader.Close();
			string text2 = "docProps/app.xml";
			if (class746_0.method_40(text2, bool_18: false) != -1)
			{
				Class1601 class3 = new Class1601(class1547_0);
				xmlTextReader = smethod_0(class746_0, text2);
				class3.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			string text3 = "docProps/custom.xml";
			if (class746_0.method_40(text3, bool_18: false) != -1)
			{
				Class1603 class4 = new Class1603(class1547_0);
				xmlTextReader = smethod_0(class746_0, text3);
				class4.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			string string_3 = "xl/styles.bin";
			Class1220 class5 = new Class1220(this);
			class5.Read(smethod_1(class746_0, string_3));
			string text4 = "xl/sharedStrings.bin";
			if (class746_0.method_40(text4, bool_18: false) != -1)
			{
				method_19(smethod_1(class746_0, text4));
			}
			method_6(class746_0);
			method_8(class746_0);
			workbook_0.class1558_0.method_0();
			method_3();
			method_1();
		}
		finally
		{
			xmlTextReader?.Close();
			workbook_0.class1558_0.class1553_0.Close();
		}
	}

	private void method_1()
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
					method_2(pivotTable);
				}
			}
		}
	}

	private void method_2(PivotTable pivotTable_0)
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

	private void method_3()
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
				Class411 class3 = new Class411(this, class1547_0, class2.string_3, @class.string_0, class746_0, fileName);
				Hashtable hashtable_ = method_4(fileName);
				string string_ = "xl/pivotCache/" + fileName;
				class3.Read(smethod_1(class746_0, string_));
				class3.method_0().hashtable_0 = hashtable_;
				class3.method_17();
				num++;
				continue;
			}
			return;
		}
		throw new CellsException(ExceptionType.InvalidData, "pivotCache rid " + @class.string_2 + " not found in workbook rels file");
	}

	private Hashtable method_4(string string_0)
	{
		string text = "xl/pivotCache/_rels/" + string_0 + ".rels";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader = Class1615.smethod_1(class746_0, text);
			Hashtable hashtable_ = Class1608.Read(xmlTextReader);
			class1547_0.method_7(hashtable_);
			xmlTextReader.Close();
		}
		return class1547_0.method_6();
	}

	private void method_5(Class746 class746_1)
	{
		Class1564 @class = Class1608.smethod_4(class1547_0.method_3(), "http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme");
		if (@class == null)
		{
			workbook_0.class1558_0.bool_1 = false;
			return;
		}
		string text = "xl/theme/" + Path.GetFileName(@class.string_3);
		workbook_0.class1558_0.string_1 = text;
		if (class746_1.method_40(text, bool_18: true) != -1)
		{
			workbook_0.class1558_0.bool_1 = true;
			Class744 class744_ = class746_1.method_38(text);
			Stream stream = class746_1.method_39(class744_);
			XmlDocument xmlDocument_ = Class1188.smethod_2(stream);
			stream.Close();
			Class1612 class2 = new Class1612(class1547_0, text);
			class2.Read(xmlDocument_);
		}
	}

	private void method_6(Class746 class746_1)
	{
		IEnumerator enumerator = class746_1.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if (@class.method_18())
			{
				continue;
			}
			string name = @class.Name;
			string text = Class1618.smethod_175(name);
			if (!name.EndsWith(".rels") && !name.EndsWith(".vml") && (text.Equals("drawings") || text.Equals("charts") || text.Equals("media")))
			{
				Class1366 class2 = new Class1366();
				class2.string_1 = name;
				class2.string_0 = text;
				string text2 = Class1618.smethod_176(name);
				if (class746_1.method_40(text2, bool_18: true) != -1)
				{
					XmlTextReader xmlTextReader = smethod_0(class746_1, text2);
					class2.arrayList_0 = Class1608.smethod_0(xmlTextReader);
					xmlTextReader.Close();
				}
				workbook_0.class1558_0.arrayList_4.Add(class2);
			}
		}
	}

	private void method_7(Class746 class746_1)
	{
		string string_ = "[Content_Types].xml";
		Class1600 @class = new Class1600(class1547_0);
		XmlTextReader xmlTextReader = smethod_0(class746_1, string_);
		@class.Read(xmlTextReader);
		xmlTextReader.Close();
	}

	internal void method_8(Class746 class746_1)
	{
		IEnumerator enumerator = class1547_0.method_8().Values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1548 @class = (Class1548)enumerator.Current;
			@class.class1547_0 = class1547_0;
			Class1564 class2 = (Class1564)class1547_0.method_4()[@class.string_1];
			string fileName = Path.GetFileName(class2.string_3);
			if (class2.string_3.StartsWith("worksheets/"))
			{
				method_10(@class, fileName, class746_1);
				string text = "xl/worksheets/_rels/" + fileName + ".rels";
				if (class746_1.method_40(text, bool_18: false) != -1)
				{
					XmlTextReader xmlTextReader = smethod_0(class746_1, text);
					@class.hashtable_0 = Class1608.Read(xmlTextReader);
					xmlTextReader.Close();
				}
			}
			else if (class2.string_3.StartsWith("chartsheets/") && Class1618.bool_1)
			{
				method_9(@class, fileName, class746_1);
			}
			else
			{
				class1547_0.workbook_0.Worksheets.RemoveAt(@class.worksheet_0.Name);
			}
		}
	}

	private void method_9(Class1548 class1548_0, string string_0, Class746 class746_1)
	{
		method_18(class1548_0, SheetType.Chart, string_0, class746_1);
		string string_ = "xl/chartsheets/" + string_0;
		Class1213 @class = new Class1213(this);
		@class.Read(class1548_0, smethod_1(class746_1, string_));
		method_15(class1548_0, class746_1);
		method_17(class1548_0, class746_1);
		if (class1548_0.string_5 != null)
		{
			method_11(class1548_0, class746_1);
		}
	}

	private void method_10(Class1548 class1548_0, string string_0, Class746 class746_1)
	{
		method_18(class1548_0, SheetType.Worksheet, string_0, class746_1);
		method_13(class1548_0, class746_1);
		method_14(class1548_0, class746_1);
		method_12(class1548_0, class746_1);
		string text = class1548_0.method_1();
		if (text != null)
		{
			Class1215 @class = new Class1215(this);
			@class.Read(class1548_0, smethod_1(class746_1, text));
		}
		string string_ = "xl/worksheets/" + string_0;
		Class1227 class2 = new Class1227(this);
		class2.Read(class1548_0, smethod_1(class746_1, string_));
		method_15(class1548_0, class746_1);
		method_17(class1548_0, class746_1);
		method_16(class1548_0, class746_1);
		if (class1548_0.string_5 != null)
		{
			method_11(class1548_0, class746_1);
		}
	}

	private void method_11(Class1548 class1548_0, Class746 class746_1)
	{
		string text = Class1618.smethod_212(class1548_0.method_3(class1548_0.string_5));
		Class744 @class = class746_1.method_38(text);
		Stream stream = class746_1.method_39(@class);
		byte[] array = new byte[(int)@class.Size];
		stream.Read(array, 0, (int)@class.Size);
		class1548_0.worksheet_0.SetBackground(array);
		workbook_0.class1558_0.arrayList_2.Add(Path.GetFileName(text));
	}

	private void method_12(Class1548 class1548_0, Class746 class746_1)
	{
		ArrayList arrayList = Class1608.smethod_7(class1548_0.hashtable_0, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotTable");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1564 @class = (Class1564)arrayList[i];
			string string_ = "xl/pivotTables/" + Path.GetFileName(@class.string_3);
			Class441 class2 = new Class441(this);
			Class1212 class3 = smethod_1(class746_1, string_);
			if (class3 != null)
			{
				class2.Read(class1548_0, class3);
			}
		}
	}

	private void method_13(Class1548 class1548_0, Class746 class746_1)
	{
		ArrayList arrayList = Class1608.smethod_7(class1548_0.hashtable_0, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/queryTable");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1564 @class = (Class1564)arrayList[i];
			string string_ = "xl/queryTables/" + Path.GetFileName(@class.string_3);
			Class413 class2 = new Class413(this);
			Class1212 class3 = smethod_1(class746_1, string_);
			if (class3 != null)
			{
				class2.Read(class1548_0, class3);
			}
		}
	}

	private void method_14(Class1548 class1548_0, Class746 class746_1)
	{
		ArrayList arrayList = Class1608.smethod_7(class1548_0.hashtable_0, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/table");
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1564 @class = (Class1564)arrayList[i];
			string string_ = "xl/tables/" + Path.GetFileName(@class.string_3);
			Class1222 class2 = new Class1222(this);
			class2.Read(class1548_0, smethod_1(class746_1, string_));
			XmlTextReader xmlTextReader = null;
			string text = "xl/tables/_rels/" + Path.GetFileName(@class.string_3) + ".rels";
			if (class746_1.method_40(text, bool_18: false) != -1)
			{
				xmlTextReader = smethod_0(class746_1, text);
				Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
		}
	}

	private void method_15(Class1548 class1548_0, Class746 class746_1)
	{
		string text = class1548_0.method_3(class1548_0.string_2);
		if (text != null)
		{
			XmlTextReader xmlTextReader = null;
			string text2 = "xl/drawings/_rels/" + Path.GetFileName(text) + ".rels";
			text = Class1618.smethod_212(text);
			Hashtable hashtable_ = null;
			if (class746_1.method_40(text2, bool_18: true) != -1)
			{
				xmlTextReader = smethod_0(class746_1, text2);
				hashtable_ = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			Class1613 @class = new Class1613(class1548_0, hashtable_, class746_1, text);
			@class.Read();
			class1548_0.worksheet_0.class1557_0.arrayList_10 = @class.method_26();
			workbook_0.class1558_0.method_4(text);
		}
	}

	private void method_16(Class1548 class1548_0, Class746 class746_1)
	{
		string text = class1548_0.method_3(class1548_0.string_3);
		if (text == null)
		{
			return;
		}
		text = Class1618.smethod_212(text);
		XmlTextReader xmlTextReader = smethod_0(class746_1, text);
		Class1606 @class = new Class1606();
		ArrayList arrayList = @class.Read(xmlTextReader);
		xmlTextReader.Close();
		string text2 = "xl/drawings/_rels/" + Path.GetFileName(text) + ".rels";
		if (arrayList == null || class746_1.method_40(text2, bool_18: true) == -1)
		{
			return;
		}
		xmlTextReader = smethod_0(class746_1, text2);
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
					string string_ = Class1618.smethod_212(class3.string_3);
					Class744 class4 = class746_1.method_38(string_);
					Stream stream = class746_1.method_39(class4);
					byte[] array = new byte[(int)class4.Size];
					stream.Read(array, 0, (int)class4.Size);
					Picture picture_ = class1548_0.worksheet_0.PageSetup.AddPicture(class2.method_0(), array);
					class2.method_2(picture_, workbook_0.Worksheets.method_75());
				}
				num++;
			}
			throw new CellsException(ExceptionType.InvalidData, text2 + " does not contains relId " + class2.string_1);
		}
		throw new CellsException(ExceptionType.InvalidData, text2 + " does not exist or is empty");
	}

	private void method_17(Class1548 class1548_0, Class746 class746_1)
	{
		string text = class1548_0.method_3(class1548_0.string_4);
		if (text != null)
		{
			XmlTextReader xmlTextReader = null;
			string text2 = "xl/drawings/_rels/" + Path.GetFileName(text) + ".rels";
			text = Class1618.smethod_212(text);
			Hashtable hashtable_ = null;
			if (class746_1.method_40(text2, bool_18: false) != -1)
			{
				xmlTextReader = smethod_0(class746_1, text2);
				hashtable_ = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			Class744 class744_ = class746_1.method_38(text);
			Stream stream = class746_1.method_39(class744_);
			XmlDocument xmlDocument_ = Class1188.smethod_2(stream);
			stream.Close();
			Class1604 @class = new Class1604(class1548_0, xmlDocument_, hashtable_, class746_1);
			@class.method_0();
			if (@class.method_48().Count > 0)
			{
				class1548_0.worksheet_0.method_36().method_1(@class.method_48());
			}
			workbook_0.class1558_0.method_4(text);
		}
	}

	private void method_18(Class1548 class1548_0, SheetType sheetType_0, string string_0, Class746 class746_1)
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
		if (class746_1.method_40(text, bool_18: false) != -1)
		{
			XmlTextReader xmlTextReader = smethod_0(class746_1, text);
			class1548_0.hashtable_0 = Class1608.Read(xmlTextReader);
			xmlTextReader.Close();
			class1548_0.method_2(class1548_0.worksheet_0.class1557_0.arrayList_4);
		}
	}

	internal void method_19(Class1212 class1212_0)
	{
		int num = class1212_0.method_0();
		if (num != 159)
		{
			return;
		}
		Class1301 class1301_ = workbook_0.Worksheets.class1301_0;
		byte[] value = method_0(class1212_0);
		int num2 = BitConverter.ToInt32(value, 0);
		bool flag = false;
		string text = null;
		int num3 = 0;
		for (int i = 0; i < num2; i++)
		{
			num = class1212_0.method_0();
			if (num != 19)
			{
				break;
			}
			value = method_0(class1212_0);
			flag = (value[0] & 1) != 0;
			int int_ = 1;
			text = Class1217.smethod_5(value, ref int_);
			if (flag)
			{
				num3 = BitConverter.ToInt32(value, int_);
				byte[] array = new byte[num3 * 4];
				int_ += 4;
				for (int j = 0; j < num3; j++)
				{
					Array.Copy(value, int_, array, j * 4, 4);
					int num4 = BitConverter.ToUInt16(value, int_ + 2);
					if (num4 < class1547_0.method_9().Count)
					{
						int num5 = (int)class1547_0.method_9()[num4];
						Array.Copy(BitConverter.GetBytes((ushort)num5), 0, array, j * 4 + 2, 2);
					}
					int_ += 4;
				}
				class1301_.method_7(text, i, array);
			}
			else
			{
				Class1719 class1719_ = new Class1719(text, 0);
				class1301_.method_6(class1719_, i);
			}
		}
	}
}
