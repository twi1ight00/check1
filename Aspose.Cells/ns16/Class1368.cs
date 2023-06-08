using System.Collections;
using System.IO;
using System.Xml;
using Aspose.Cells;
using ns22;
using ns25;

namespace ns16;

internal class Class1368
{
	private Workbook workbook_0;

	private Stream stream_0;

	private Class1547 class1547_0;

	private Class746 class746_0;

	private Class1610 class1610_0;

	private LoadDataOption loadDataOption_0;

	internal static void LoadData(Workbook workbook_1, Stream stream_1, LoadDataOption loadDataOption_1)
	{
		Class1368 @class = new Class1368(workbook_1, stream_1, loadDataOption_1);
		@class.Read();
	}

	internal static void LoadData(Workbook workbook_1, Class746 class746_1, LoadDataOption loadDataOption_1)
	{
		Class1368 @class = new Class1368(workbook_1, class746_1, loadDataOption_1);
		@class.Read();
	}

	internal Class1368(Workbook workbook_1, Stream stream_1, LoadDataOption loadDataOption_1)
	{
		workbook_0 = workbook_1;
		stream_0 = stream_1;
		class1547_0 = new Class1547(workbook_1);
		loadDataOption_0 = loadDataOption_1;
	}

	internal Class1368(Workbook workbook_1, Class746 class746_1, LoadDataOption loadDataOption_1)
	{
		workbook_0 = workbook_1;
		class746_0 = class746_1;
		class1547_0 = new Class1547(workbook_1);
		loadDataOption_0 = loadDataOption_1;
	}

	internal void Read()
	{
		method_3();
		method_2();
		method_5();
		method_0();
		method_1();
		method_4();
		if (!loadDataOption_0.OnlyCreateWorksheet)
		{
			method_6();
			method_7();
			method_8();
			method_9();
			workbook_0.class1558_0 = null;
			class746_0.Close();
		}
	}

	private void method_0()
	{
		string string_ = "xl/workbook.xml";
		string string_2 = "xl/workbook2.xml";
		if (class1547_0.string_0 != null)
		{
			string_ = class1547_0.string_0;
		}
		Class1616 @class = new Class1616(class1547_0, class746_0);
		XmlTextReader xmlTextReader = smethod_0(class746_0, string_);
		if (xmlTextReader == null)
		{
			xmlTextReader = smethod_0(class746_0, string_2);
		}
		@class.method_4(xmlTextReader);
		xmlTextReader.Close();
	}

	private void method_1()
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
				XmlTextReader xmlTextReader = smethod_0(class746_0, text);
				hashtable_ = Class1608.Read(xmlTextReader);
				xmlTextReader.Close();
			}
			XmlTextReader xmlTextReader2 = smethod_0(class746_0, string_);
			Class1605 class2 = new Class1605(class1547_0, hashtable_);
			class2.Read(xmlTextReader2);
			xmlTextReader2.Close();
		}
	}

	private void method_2()
	{
		workbook_0.class1558_0 = new Class1558(workbook_0);
	}

	private void method_3()
	{
		string string_ = "xl/workbook.xml";
		try
		{
			if (class746_0 == null)
			{
				class746_0 = Class746.Read(stream_0);
			}
			if (class746_0.method_40(string_, bool_18: true) == -1)
			{
				throw new CellsException(ExceptionType.FileFormat, "Invalid Excel2007Xlsx file format");
			}
		}
		catch
		{
			throw new CellsException(ExceptionType.FileFormat, "Invalid Excel2007Xlsx file format");
		}
	}

	private void method_4()
	{
		string string_ = "xl/workbook.xml";
		Class1369 @class = new Class1369(class1547_0);
		XmlTextReader xmlTextReader = smethod_0(class746_0, string_);
		@class.Read(xmlTextReader);
		xmlTextReader.Close();
	}

	private void method_5()
	{
		string string_ = "xl/_rels/workbook.xml.rels";
		XmlTextReader xmlTextReader = smethod_0(class746_0, string_);
		Hashtable hashtable_ = Class1608.Read(xmlTextReader);
		class1547_0.method_2(hashtable_);
		xmlTextReader.Close();
	}

	private void method_6()
	{
		Class1564 @class = Class1608.smethod_4(class1547_0.method_3(), "http://schemas.openxmlformats.org/officeDocument/2006/relationships/theme");
		if (@class != null)
		{
			string text = "xl/theme/" + Path.GetFileName(@class.string_3);
			if (class746_0.method_40(text, bool_18: true) != -1)
			{
				Class744 class744_ = class746_0.method_38(text);
				Stream stream = class746_0.method_39(class744_);
				XmlDocument xmlDocument_ = Class1188.smethod_2(stream);
				stream.Close();
				Class1612 class2 = new Class1612(class1547_0, text);
				class2.Read(xmlDocument_);
			}
		}
	}

	private void method_7()
	{
		string string_ = "xl/styles.xml";
		Class1611 @class = new Class1611(class1547_0);
		XmlTextReader xmlTextReader = smethod_0(class746_0, string_);
		@class.method_0(xmlTextReader);
		xmlTextReader.Close();
		xmlTextReader = smethod_0(class746_0, string_);
		@class.Read(xmlTextReader);
		xmlTextReader.Close();
	}

	private void method_8()
	{
		string text = "xl/sharedStrings.xml";
		if (class746_0.method_40(text, bool_18: true) != -1)
		{
			class1610_0 = new Class1610(class1547_0);
			XmlTextReader xmlTextReader = smethod_0(class746_0, text);
			class1610_0.Read(xmlTextReader);
			xmlTextReader.Close();
		}
	}

	private void method_9()
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
			Class1564 class2 = (Class1564)hashtable[@class.string_1];
			string fileName = Path.GetFileName(class2.string_3);
			if (class2.string_3.IndexOf("worksheets/") != -1)
			{
				if (method_10(@class))
				{
					method_11(@class, fileName);
				}
			}
			else if (class2.string_3.IndexOf("chartsheets/") == -1)
			{
			}
		}
	}

	private bool method_10(Class1548 class1548_0)
	{
		if (loadDataOption_0 == null)
		{
			return true;
		}
		if (loadDataOption_0.SheetIndexes != null)
		{
			int num = 0;
			while (true)
			{
				if (num < loadDataOption_0.SheetIndexes.Length)
				{
					int num2 = loadDataOption_0.SheetIndexes[num];
					if (class1548_0.int_0 == num2)
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
		if (loadDataOption_0.SheetNames != null)
		{
			int num3 = 0;
			while (true)
			{
				if (num3 < loadDataOption_0.SheetNames.Length)
				{
					string text = loadDataOption_0.SheetNames[num3];
					if (text != null && class1548_0.worksheet_0.Name.ToLower() == text.ToLower())
					{
						break;
					}
					num3++;
					continue;
				}
				return false;
			}
			return true;
		}
		return true;
	}

	private void method_11(Class1548 class1548_0, string string_0)
	{
		method_12(class1548_0, string_0);
	}

	private void method_12(Class1548 class1548_0, string string_0)
	{
		bool bool_ = true;
		if (loadDataOption_0 != null)
		{
			bool_ = loadDataOption_0.ImportFormula;
		}
		string string_ = "xl/worksheets/" + string_0;
		Class1370 @class = new Class1370(class1547_0, class1548_0, bool_);
		XmlTextReader xmlTextReader = smethod_0(class746_0, string_);
		@class.method_2(class1610_0);
		@class.Read(xmlTextReader);
		xmlTextReader.Close();
	}

	internal static XmlTextReader smethod_0(Class746 class746_1, string string_0)
	{
		return Class536.smethod_5(class746_1, string_0);
	}
}
