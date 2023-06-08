using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using Aspose.Cells.Pivot;
using ns1;
using ns2;
using ns21;
using ns22;
using ns25;
using ns45;

namespace ns16;

internal class Class1540
{
	internal Workbook workbook_0;

	internal Class521 class521_0;

	internal ArrayList arrayList_0;

	internal Class1539 class1539_0;

	internal ArrayList arrayList_1;

	internal Hashtable hashtable_0 = new Hashtable();

	internal Hashtable hashtable_1;

	internal Hashtable hashtable_2;

	internal Hashtable hashtable_3;

	internal int int_0;

	internal bool bool_0 = true;

	private int int_1 = 1;

	private ArrayList arrayList_2 = new ArrayList();

	internal Class746 class746_0;

	internal ArrayList arrayList_3 = new ArrayList();

	internal ArrayList arrayList_4 = new ArrayList();

	internal string string_0 = ".xml";

	internal bool bool_1 = true;

	private int int_2 = 1;

	private int int_3 = 1;

	private int int_4 = 1;

	private int int_5 = 1;

	private int int_6 = 1;

	private FileFormatType fileFormatType_0;

	internal Hashtable hashtable_4 = new Hashtable();

	internal Class978 class978_0;

	internal int int_7 = 1;

	internal bool bool_2;

	internal bool bool_3;

	internal Class1540(Workbook workbook_1, Class746 class746_1, bool bool_4, bool bool_5)
	{
		workbook_0 = workbook_1;
		class746_0 = class746_1;
		bool_0 = bool_4;
		string_0 = (bool_5 ? ".xml" : ".bin");
		bool_1 = bool_5;
		method_11();
	}

	internal Class1540(Workbook workbook_1, Class746 class746_1, bool bool_4, FileFormatType fileFormatType_1)
	{
		workbook_0 = workbook_1;
		class746_0 = class746_1;
		bool_0 = bool_4;
		fileFormatType_0 = fileFormatType_1;
		method_11();
	}

	private void method_0()
	{
		hashtable_3 = new Hashtable();
		int num = method_1();
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet = workbook_0.Worksheets[i];
			PivotTableCollection pivotTableCollection_ = worksheet.pivotTableCollection_0;
			if (worksheet.Type == SheetType.Worksheet && pivotTableCollection_ != null && pivotTableCollection_.Count > 0)
			{
				for (int j = 0; j < pivotTableCollection_.Count; j++)
				{
					PivotTable key = pivotTableCollection_[j];
					hashtable_3[key] = num;
					num++;
				}
			}
		}
	}

	private int method_1()
	{
		if (class746_0 == null)
		{
			return 1;
		}
		int num = 1;
		IEnumerator enumerator = class746_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class744 @class = (Class744)enumerator.Current;
			if (@class.method_18())
			{
				continue;
			}
			string fileName = Path.GetFileName(@class.Name);
			if (fileName.StartsWith("pivotTable") && fileName.EndsWith(".xml"))
			{
				int length = fileName.LastIndexOf('.');
				fileName = fileName.Substring(0, length);
				int num2 = Class1618.smethod_145(fileName);
				if (num2 >= num)
				{
					num = num2 + 1;
				}
			}
		}
		return num;
	}

	internal int method_2()
	{
		return int_2++;
	}

	internal int method_3()
	{
		return int_3++;
	}

	internal int method_4()
	{
		return int_0 + int_5++;
	}

	internal int method_5()
	{
		int num = int_1;
		while (arrayList_2.Contains(num))
		{
			num = ++int_1;
		}
		int_1++;
		return num;
	}

	internal int method_6()
	{
		return int_6++;
	}

	internal int method_7()
	{
		return int_4++;
	}

	private void method_8()
	{
		int num = 1;
		int num2 = 1;
		int num3 = 1;
		for (int i = 0; i < workbook_0.Worksheets.Count; i++)
		{
			Worksheet worksheet = workbook_0.Worksheets[i];
			if (worksheet.Type == SheetType.Worksheet)
			{
				Class1541 @class = new Class1541(this, worksheet, num, num2);
				arrayList_0.Add(@class);
				string string_ = "worksheets/sheet" + Class1618.smethod_80(num2) + string_0;
				@class.string_1 = method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet", string_);
				num++;
				num2++;
			}
			else if (worksheet.Type == SheetType.Chart && (Class1618.smethod_123(worksheet.Charts[0]) || worksheet.class1557_0 != null))
			{
				Class1541 class2 = new Class1541(this, worksheet, num, num3);
				arrayList_0.Add(class2);
				string string_2 = "chartsheets/sheet" + num3 + string_0;
				class2.string_1 = method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/chartsheet", string_2);
				num++;
				num3++;
			}
		}
	}

	private void method_9()
	{
		hashtable_4 = new Hashtable();
		Class1303 @class = workbook_0.Worksheets.method_39();
		int num = 0;
		for (int i = 0; i < @class.Count; i++)
		{
			Class1718 class2 = @class[i];
			if (class2.Type == Enum194.const_3 || class2.Type == Enum194.const_0 || class2.Type == Enum194.const_4)
			{
				num++;
				string value = method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/externalLink", "externalLinks/externalLink" + num + string_0);
				hashtable_4.Add(class2, value);
			}
		}
	}

	private void method_10()
	{
		if (workbook_0.class1558_0 != null)
		{
			ArrayList arrayList = workbook_0.class1558_0.class1364_0.arrayList_1;
			for (int i = 0; i < arrayList.Count; i++)
			{
				Class1562 @class = (Class1562)arrayList[i];
				@class.string_2 = method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotCacheDefinition", @class.string_1);
			}
		}
	}

	private void method_11()
	{
		workbook_0.method_32(this);
		class521_0 = new Class521(workbook_0);
		class1539_0 = Class1539.smethod_0(this);
		workbook_0.Worksheets.method_27();
		arrayList_0 = new ArrayList();
		arrayList_1 = new ArrayList();
		bool_3 = method_30();
		method_14();
		method_33();
		method_34();
		method_17();
		method_0();
		method_8();
		if (bool_1)
		{
			method_10();
		}
		method_16();
		if (bool_0 && workbook_0.HasMacro)
		{
			method_37("http://schemas.microsoft.com/office/2006/relationships/vbaProject", "vbaProject.bin");
		}
		method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles", "styles" + string_0);
		method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/sharedStrings", "sharedStrings" + string_0);
		method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme", "theme/theme1.xml");
		method_26();
		method_9();
		if (workbook_0.class442_0 != null)
		{
			method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/connections", "connections.xml");
		}
		if (workbook_0.Worksheets.XmlMaps != null && workbook_0.Worksheets.XmlMaps.Count > 0)
		{
			method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/xmlMaps", "xmlMaps.xml");
		}
		if (bool_1)
		{
			method_32();
			method_23();
			method_15();
			method_12();
		}
		else
		{
			method_32();
			method_29();
			method_15();
			method_12();
		}
		if (workbook_0.method_16() is OoxmlSaveOptions)
		{
			LightCellsDataProvider lightCellsDataProvider = ((OoxmlSaveOptions)workbook_0.method_16()).LightCellsDataProvider;
			if (lightCellsDataProvider != null)
			{
				class978_0 = new Class979(this, lightCellsDataProvider);
			}
		}
	}

	private void method_12()
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1541 @class = (Class1541)arrayList_0[i];
			@class.method_1();
		}
	}

	private bool method_13(Class1366 class1366_0)
	{
		Class744 class744_ = class746_0.method_38(class1366_0.string_1);
		Stream stream = class746_0.method_39(class744_);
		XmlDocument xmlDocument = Class1188.smethod_2(stream);
		stream.Close();
		if (xmlDocument.DocumentElement.LocalName == "userShapes")
		{
			return true;
		}
		return false;
	}

	private void method_14()
	{
		if (workbook_0.class1558_0 == null || workbook_0.class1558_0.arrayList_4.Count == 0)
		{
			return;
		}
		ArrayList arrayList = workbook_0.class1558_0.arrayList_4;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1366 @class = (Class1366)arrayList[i];
			if (@class.string_0.Equals("media"))
			{
				string string_ = @class.string_1;
				int num = string_.LastIndexOf('/');
				int num2 = string_.LastIndexOf('.');
				string s = ((num >= num2) ? string_.Substring(num + 6) : string_.Substring(num + 6, num2 - num - 6));
				try
				{
					arrayList_2.Add(int.Parse(s));
				}
				catch
				{
				}
			}
		}
	}

	private void method_15()
	{
		if (workbook_0.class1558_0 == null || workbook_0.class1558_0.arrayList_4.Count == 0)
		{
			return;
		}
		ArrayList arrayList = workbook_0.class1558_0.arrayList_4;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1366 @class = (Class1366)arrayList[i];
			if (@class.string_0.Equals("drawings"))
			{
				int num = method_3();
				@class.string_2 = "xl/drawings/drawing" + num + ".xml";
				if (method_13(@class))
				{
					method_20("/" + @class.string_2, "application/vnd.openxmlformats-officedocument.drawingml.chartshapes+xml");
				}
				else
				{
					method_20("/" + @class.string_2, "application/vnd.openxmlformats-officedocument.drawing+xml");
				}
			}
			else if (@class.string_0.Equals("charts"))
			{
				int num2 = method_4();
				@class.string_2 = "xl/charts/chart" + num2 + ".xml";
				method_20("/" + @class.string_2, "application/vnd.openxmlformats-officedocument.drawingml.chart+xml");
			}
			else if (@class.string_0.Equals("media"))
			{
				@class.string_2 = @class.string_1;
			}
			else
			{
				@class.string_2 = @class.string_1;
			}
		}
	}

	private void method_16()
	{
		if (hashtable_2 == null || hashtable_2.Count == 0)
		{
			return;
		}
		IDictionaryEnumerator enumerator = hashtable_2.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1562 @class = (Class1562)enumerator.Value;
			Class1141 class2 = (Class1141)enumerator.Key;
			if (class2.bool_1)
			{
				continue;
			}
			string string_ = null;
			if (class2.string_4 != null)
			{
				int num = class2.string_4.IndexOf(".");
				if (num != -1)
				{
					string text = class2.string_4.Substring(0, num) + string_0;
					string_ = "pivotCache/" + text;
				}
			}
			else
			{
				string_ = "pivotCache/pivotCacheDefinition" + @class.int_0 + string_0;
			}
			string string_2 = method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotCacheDefinition", string_);
			@class.string_2 = string_2;
		}
	}

	private void method_17()
	{
		int num = 1;
		Class1142 @class = workbook_0.Worksheets.method_89();
		int count = @class.Count;
		if (count == 0)
		{
			return;
		}
		hashtable_2 = new Hashtable(count);
		for (int i = 0; i < count; i++)
		{
			Class1141 class2 = @class[i];
			int num2 = num + i;
			Class1562 class3 = new Class1562();
			class3.string_3 = class2.string_4;
			class3.int_0 = num2;
			if (class3.string_3 != null)
			{
				int length = class3.string_3.LastIndexOf('.');
				string string_ = class3.string_3.Substring(0, length);
				int num3 = Class1618.smethod_145(string_);
				if (num3 != num2)
				{
					num2 = num3;
				}
				class3.int_0 = num2;
			}
			class3.string_0 = Class1618.smethod_80(class2.int_6);
			hashtable_2[class2] = class3;
		}
	}

	private void method_18(string string_1, string string_2)
	{
		if (!method_19(string_1))
		{
			Class1530 @class = new Class1530();
			@class.bool_0 = true;
			@class.string_0 = string_1;
			@class.string_2 = string_2;
			arrayList_4.Add(@class);
		}
	}

	private bool method_19(string string_1)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_4.Count)
			{
				Class1530 @class = (Class1530)arrayList_4[num];
				if (@class.string_0 == string_1)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	internal void method_20(string string_1, string string_2)
	{
		Class1530 @class = new Class1530();
		@class.bool_0 = false;
		@class.string_1 = string_1;
		@class.string_2 = string_2;
		arrayList_4.Add(@class);
	}

	private void method_21()
	{
		if ((hashtable_0 != null && hashtable_0.Count != 0) || (hashtable_1 != null && hashtable_1.Count != 0) || arrayList_3.Count != 0)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(arrayList_3);
			if (hashtable_0 != null)
			{
				arrayList.AddRange(hashtable_0.Values);
			}
			if (hashtable_1 != null)
			{
				arrayList.AddRange(hashtable_1.Values);
			}
			for (int i = 0; i < arrayList.Count; i++)
			{
				string string_ = (string)arrayList[i];
				method_22(string_);
			}
		}
	}

	internal void method_22(string string_1)
	{
		string text = null;
		string text2 = null;
		try
		{
			text2 = Path.GetExtension(string_1);
			if (text2.Length < 2)
			{
				return;
			}
			text2 = text2.Substring(1);
			switch (text2)
			{
			case "jpeg":
				text = "image/" + text2;
				break;
			case "png":
				text = "image/" + text2;
				break;
			case "emf":
				text = "image/x-emf";
				break;
			case "wmf":
				text = "image/x-wmf";
				break;
			case "bmp":
				text = "image/" + text2;
				break;
			}
		}
		catch
		{
			if (string_1.IndexOf(".jpg") != -1)
			{
				text2 = "jpeg";
				text = "image/" + text2;
			}
		}
		if (text != null)
		{
			method_18(text2, text);
		}
	}

	private void method_23()
	{
		method_18("rels", "application/vnd.openxmlformats-package.relationships+xml");
		method_18("xml", "application/xml");
		method_21();
		method_20("/xl/theme/theme1.xml", "application/vnd.openxmlformats-officedocument.theme+xml");
		method_20("/xl/styles.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml");
		if (bool_0)
		{
			if (fileFormatType_0 == FileFormatType.Xltm)
			{
				method_20("/xl/workbook.xml", "application/vnd.ms-excel.template.macroEnabled.main+xml");
			}
			else
			{
				method_20("/xl/workbook.xml", "application/vnd.ms-excel.sheet.macroEnabled.main+xml");
			}
			if (workbook_0.HasMacro)
			{
				method_20("/xl/vbaProject.bin", "application/vnd.ms-office.vbaProject");
			}
		}
		else if (fileFormatType_0 == FileFormatType.Xltx)
		{
			method_20("/xl/workbook.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.template.main+xml");
		}
		else
		{
			method_20("/xl/workbook.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml");
		}
		method_20("/docProps/app.xml", "application/vnd.openxmlformats-officedocument.extended-properties+xml");
		bool flag = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1541 @class = (Class1541)arrayList_0[i];
			if (@class.worksheet_0.Type == SheetType.Worksheet)
			{
				string string_ = "/xl/worksheets/sheet" + Class1618.smethod_80(@class.int_1) + ".xml";
				method_20(string_, "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml");
			}
			else if (@class.worksheet_0.Type == SheetType.Chart)
			{
				string string_2 = "/xl/chartsheets/sheet" + Class1618.smethod_80(@class.int_1) + ".xml";
				method_20(string_2, "application/vnd.openxmlformats-officedocument.spreadsheetml.chartsheet+xml");
			}
			if (@class.string_0 != null && @class.string_0.Length > 0)
			{
				method_20("/xl/" + @class.string_0, "application/vnd.openxmlformats-officedocument.spreadsheetml.comments+xml");
			}
			if (!flag && (@class.class1534_1.string_0 != null || @class.class1534_0.string_0 != null))
			{
				method_18("vml", "application/vnd.openxmlformats-officedocument.vmlDrawing");
				flag = true;
			}
			if (@class.class1358_0.string_0 != null)
			{
				string string_3 = "/xl/drawings/" + @class.class1358_0.string_1;
				method_20(string_3, "application/vnd.openxmlformats-officedocument.drawing+xml");
			}
		}
		for (int j = 1; j <= int_0; j++)
		{
			string string_4 = "/xl/charts/chart" + Class1618.smethod_80(j) + ".xml";
			method_20(string_4, "application/vnd.openxmlformats-officedocument.drawingml.chart+xml");
		}
		method_20("/xl/sharedStrings.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml");
		method_20("/docProps/core.xml", "application/vnd.openxmlformats-package.core-properties+xml");
		if (method_35())
		{
			method_20("/docProps/custom.xml", "application/vnd.openxmlformats-officedocument.custom-properties+xml");
		}
		if (workbook_0.class442_0 != null)
		{
			method_20("/xl/connections.xml", "application/vnd.openxmlformats-officedocument.spreadsheetml.connections+xml");
		}
		method_27();
		method_28();
		method_24();
		method_31();
		method_25();
	}

	private void method_24()
	{
		Class1303 @class = workbook_0.Worksheets.method_39();
		int num = 0;
		for (int i = 0; i < @class.Count; i++)
		{
			Class1718 class2 = @class[i];
			if (class2.Type == Enum194.const_3 || class2.Type == Enum194.const_0 || class2.Type == Enum194.const_4)
			{
				num++;
				string string_ = "/xl/externalLinks/externalLink" + num + string_0;
				if (bool_1)
				{
					method_20(string_, "application/vnd.openxmlformats-officedocument.spreadsheetml.externalLink+xml");
				}
				else
				{
					method_20(string_, "application/vnd.ms-excel.externalLink");
				}
			}
		}
	}

	private void method_25()
	{
		int count = arrayList_0.Count;
		for (int i = 0; i < count; i++)
		{
			Class1541 @class = (Class1541)arrayList_0[i];
			int count2 = @class.arrayList_3.Count;
			for (int j = 0; j < count2; j++)
			{
				Class1538 class2 = (Class1538)@class.arrayList_3[j];
				string text = null;
				string text2 = null;
				if (class2.string_2 != null && class2.string_2 != "")
				{
					text = Path.GetExtension(class2.string_2);
					if (text.Length > 0)
					{
						text = text.Substring(1);
					}
					string key;
					if ((key = text) != null)
					{
						if (Class1742.dictionary_124 == null)
						{
							Class1742.dictionary_124 = new Dictionary<string, int>(10)
							{
								{ "xls", 0 },
								{ "xltx", 1 },
								{ "xltm", 2 },
								{ "xlsx", 3 },
								{ "xlsm", 4 },
								{ "doc", 5 },
								{ "docx", 6 },
								{ "ppt", 7 },
								{ "pptx", 8 },
								{ "sldx", 9 }
							};
						}
						if (Class1742.dictionary_124.TryGetValue(key, out var value))
						{
							switch (value)
							{
							case 0:
							case 1:
							case 2:
								text2 = "application/vnd.ms-excel";
								break;
							case 3:
								text2 = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
								break;
							case 4:
								text2 = "application/vnd.ms-excel.sheet.macroEnabled.12";
								break;
							case 5:
								text2 = "application/msword";
								break;
							case 6:
								text2 = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
								break;
							case 7:
								text2 = "application/vnd.ms-powerpoint";
								break;
							case 8:
								text2 = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
								break;
							case 9:
								text2 = "application/vnd.openxmlformats-officedocument.presentationml.slide";
								break;
							}
						}
					}
				}
				if (text2 != null)
				{
					if (!method_19(text))
					{
						method_18(text, text2);
					}
				}
				else if (!class2.oleObject_0.IsLink)
				{
					method_20("/xl/embeddings/" + class2.string_2, "application/vnd.openxmlformats-officedocument.oleObject");
				}
			}
		}
	}

	private void method_26()
	{
		bool flag = method_36(arrayList_1, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml");
		if ((workbook_0.ContentTypeProperties != null && workbook_0.ContentTypeProperties.Count > 0) || flag)
		{
			method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml", "../customXml/item1.xml");
			method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml", "../customXml/item2.xml");
			method_37("http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml", "../customXml/item3.xml");
		}
	}

	private void method_27()
	{
		bool flag = method_36(arrayList_1, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml");
		if ((workbook_0.ContentTypeProperties != null && workbook_0.ContentTypeProperties.Count > 0) || flag)
		{
			method_20("/customXml/itemProps1.xml", "application/vnd.openxmlformats-officedocument.customXmlProperties+xml");
			method_20("/customXml/itemProps2.xml", "application/vnd.openxmlformats-officedocument.customXmlProperties+xml");
			method_20("/customXml/itemProps3.xml", "application/vnd.openxmlformats-officedocument.customXmlProperties+xml");
		}
	}

	private void method_28()
	{
		if (hashtable_2 != null && hashtable_2.Count > 0)
		{
			IDictionaryEnumerator enumerator = hashtable_2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class1562 @class = (Class1562)enumerator.Value;
				Class1141 class2 = (Class1141)enumerator.Key;
				string string_ = "/xl/pivotCache/pivotCacheDefinition" + @class.int_0 + ".xml";
				if (class2.class1144_0 != null || (workbook_0.class1558_0 != null && workbook_0.class1558_0.class1364_0.arrayList_1.Count > 0))
				{
					string string_2 = "/xl/pivotCache/pivotCacheRecords" + @class.int_0 + ".xml";
					method_20(string_2, "application/vnd.openxmlformats-officedocument.spreadsheetml.pivotCacheRecords+xml");
				}
				method_20(string_, "application/vnd.openxmlformats-officedocument.spreadsheetml.pivotCacheDefinition+xml");
			}
		}
		if (hashtable_3 != null && hashtable_3.Count > 0)
		{
			IEnumerator enumerator2 = hashtable_3.Values.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				int num = (int)enumerator2.Current;
				string string_3 = "/xl/pivotTables/pivotTable" + num + ".xml";
				method_20(string_3, "application/vnd.openxmlformats-officedocument.spreadsheetml.pivotTable+xml");
			}
		}
	}

	private void method_29()
	{
		method_18("rels", "application/vnd.openxmlformats-package.relationships+xml");
		method_18("xml", "application/xml");
		method_18("bin", "application/vnd.ms-excel.sheet.binary.macroEnabled.main");
		method_21();
		method_20("/xl/theme/theme1.xml", "application/vnd.openxmlformats-officedocument.theme+xml");
		method_20("/xl/styles.bin", "application/vnd.ms-excel.styles");
		if (bool_0 && workbook_0.HasMacro)
		{
			method_20("/xl/vbaProject.bin", "application/vnd.ms-office.vbaProject");
		}
		else
		{
			method_20("/xl/bin", "application/vnd.ms-excel.sheet.binary.macroEnabled.main");
		}
		method_20("/docProps/app.xml", "application/vnd.openxmlformats-officedocument.extended-properties+xml");
		bool flag = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1541 @class = (Class1541)arrayList_0[i];
			if (@class.worksheet_0.Type == SheetType.Worksheet)
			{
				string string_ = "/xl/worksheets/sheet" + Class1618.smethod_80(@class.int_1) + ".bin";
				method_20(string_, "application/vnd.ms-excel.worksheet");
			}
			else if (@class.worksheet_0.Type == SheetType.Chart)
			{
				string string_2 = "/xl/chartsheets/sheet" + Class1618.smethod_80(@class.int_1) + ".bin";
				method_20(string_2, "application/application/vnd.ms-excel.chartsheet");
			}
			if (@class.string_0 != null && @class.string_0.Length > 0)
			{
				method_20("/xl/" + @class.string_0, "application/vnd.ms-excel.comments");
			}
			if (!flag && (@class.class1534_1.string_0 != null || @class.class1534_0.string_0 != null))
			{
				method_18("vml", "application/vnd.openxmlformats-officedocument.vmlDrawing");
				flag = true;
			}
			if (@class.class1358_0.string_0 != null)
			{
				string string_3 = "/xl/drawings/" + @class.class1358_0.string_1;
				method_20(string_3, "application/vnd.openxmlformats-officedocument.drawing+xml");
			}
		}
		for (int j = 1; j <= int_0; j++)
		{
			string string_4 = "/xl/charts/chart" + Class1618.smethod_80(j) + ".xml";
			method_20(string_4, "application/vnd.openxmlformats-officedocument.drawingml.chart+xml");
		}
		method_20("/xl/sharedStrings.bin", "application/vnd.ms-excel.sharedStrings");
		method_20("/docProps/core.xml", "application/vnd.openxmlformats-package.core-properties+xml");
		if (method_35())
		{
			method_20("/docProps/custom.xml", "application/vnd.openxmlformats-officedocument.custom-properties+xml");
		}
		method_24();
		method_31();
	}

	private bool method_30()
	{
		if (workbook_0.class1558_0 == null)
		{
			return false;
		}
		ArrayList arrayList = workbook_0.class1558_0.arrayList_0;
		int num = 0;
		while (true)
		{
			if (num < arrayList.Count)
			{
				Class1530 @class = (Class1530)arrayList[num];
				if (@class.string_2 != "application/vnd.openxmlformats-officedocument.spreadsheetml.printerSettings" && @class.string_0 != null && @class.string_0.ToLower() == "bin")
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	private void method_31()
	{
		if (workbook_0.class1558_0 == null)
		{
			return;
		}
		ArrayList arrayList = workbook_0.class1558_0.arrayList_0;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1530 @class = (Class1530)arrayList[i];
			if (@class.bool_0 && method_19(@class.string_0))
			{
				continue;
			}
			if (!workbook_0.Settings.method_7())
			{
				switch (@class.string_2)
				{
				case "application/vnd.openxmlformats-officedocument.spreadsheetml.revisionLog+xml":
				case "application/vnd.openxmlformats-officedocument.spreadsheetml.userNames+xml":
				case "application/vnd.openxmlformats-officedocument.spreadsheetml.revisionHeaders+xml":
					continue;
				}
			}
			arrayList_4.Add(@class);
		}
	}

	private void method_32()
	{
		if (workbook_0.class1558_0 == null)
		{
			return;
		}
		ArrayList arrayList = workbook_0.class1558_0.class1364_0.arrayList_0;
		for (int i = 0; i < arrayList.Count; i++)
		{
			Class1564 @class = (Class1564)arrayList[i];
			if (!workbook_0.Settings.method_7())
			{
				switch (@class.string_2)
				{
				case "http://schemas.openxmlformats.org/officeDocument/2006/relationships/revisionHeaders":
				case "http://schemas.openxmlformats.org/officeDocument/2006/relationships/usernames":
					continue;
				}
			}
			@class.string_0 = @class.string_1;
			@class.string_1 = method_37(@class.string_2, @class.string_3);
		}
	}

	private void method_33()
	{
		hashtable_0.Clear();
		Class1716 @class = new Class1716();
		@class.method_1(workbook_0.Worksheets);
		int count = @class.Count;
		hashtable_0 = new Hashtable();
		for (int i = 0; i < count; i++)
		{
			Class1715 class2 = @class[i];
			if (class2.Data != null)
			{
				int num = method_5();
				string value = Class1618.smethod_45("image", num, class2.Type);
				hashtable_0.Add(i + 1, value);
			}
		}
		for (int j = 0; j < workbook_0.Worksheets.Count; j++)
		{
			Worksheet worksheet = workbook_0.Worksheets[j];
			PictureCollection pictures = worksheet.Pictures;
			for (int k = 0; k < pictures.Count; k++)
			{
				Picture picture = pictures[k];
				if (picture.method_74() && !hashtable_0.ContainsKey(picture.SourceFullName))
				{
					hashtable_0.Add(picture.SourceFullName, picture.SourceFullName);
				}
			}
		}
	}

	private void method_34()
	{
		hashtable_1 = null;
		Class1716 @class = new Class1716();
		@class.method_2(workbook_0.Worksheets);
		int count = @class.Count;
		if (count == 0)
		{
			return;
		}
		hashtable_1 = new Hashtable(count);
		for (int i = 0; i < count; i++)
		{
			Class1715 class2 = @class[i];
			if (class2.Data != null)
			{
				int num = method_5();
				string value = Class1618.smethod_45("image", num, class2.Type);
				hashtable_1.Add(i + 1, value);
			}
		}
	}

	internal bool method_35()
	{
		if (workbook_0.Worksheets.CustomDocumentProperties.Count <= 0)
		{
			return false;
		}
		return true;
	}

	internal bool method_36(ArrayList arrayList_5, string string_1)
	{
		if (arrayList_5 != null && arrayList_5.Count != 0)
		{
			IEnumerator enumerator = arrayList_5.GetEnumerator();
			Class1564 @class;
			do
			{
				if (enumerator.MoveNext())
				{
					@class = (Class1564)enumerator.Current;
					continue;
				}
				return false;
			}
			while (!@class.string_2.Equals(string_1));
			return true;
		}
		return false;
	}

	private string method_37(string string_1, string string_2)
	{
		string text = "rId" + (arrayList_1.Count + 1);
		Class1564 value = new Class1564(text, string_1, string_2, null);
		arrayList_1.Add(value);
		return text;
	}

	internal bool method_38()
	{
		Class1303 @class = workbook_0.Worksheets.method_39();
		if (@class != null && @class.Count > 1)
		{
			int num = 0;
			while (true)
			{
				if (num < @class.Count)
				{
					Class1718 class2 = @class[num];
					string text = class2.method_25();
					if (text != null && text.Trim().Length != 0 && (class2.Type == Enum194.const_3 || class2.Type == Enum194.const_0 || class2.Type == Enum194.const_4))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}
}
