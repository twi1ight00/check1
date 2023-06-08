using System.Collections;
using System.Xml;
using Aspose.Cells;
using ns22;
using ns25;

namespace ns16;

internal class Class1364
{
	internal Class1558 class1558_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal ArrayList arrayList_0 = new ArrayList();

	internal ArrayList arrayList_1 = new ArrayList();

	internal ArrayList arrayList_2 = new ArrayList();

	internal ArrayList arrayList_3 = new ArrayList();

	internal string string_5;

	internal string string_6;

	internal Class1364(Class1558 class1558_1)
	{
		class1558_0 = class1558_1;
	}

	internal void method_0()
	{
		ArrayList arrayList_ = new ArrayList();
		ArrayList arrayList = new ArrayList();
		method_1(arrayList_, arrayList);
		method_3(arrayList);
		method_5(arrayList_);
	}

	private void method_1(ArrayList arrayList_4, ArrayList arrayList_5)
	{
		WorksheetCollection worksheets = class1558_0.workbook_0.Worksheets;
		for (int i = 0; i < worksheets.Count; i++)
		{
			Worksheet worksheet = worksheets[i];
			if (worksheet.class1557_0 == null || worksheet.class1557_0.hashtable_0.Count == 0)
			{
				continue;
			}
			IDictionaryEnumerator enumerator = worksheet.class1557_0.hashtable_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Class1554 @class = (Class1554)enumerator.Value;
				if (@class != null)
				{
					string text = Class1185.smethod_1(@class.string_0);
					arrayList_4.Add("/xl/pivotTables/" + text);
					string string_ = "xl/pivotTables/_rels/" + text + ".rels";
					string text2 = method_2(string_, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotCacheDefinition");
					if (text2 != null)
					{
						arrayList_5.Add(text2);
					}
				}
			}
		}
	}

	private string method_2(string string_7, string string_8)
	{
		if (class1558_0.class1553_0.class746_0.method_40(string_7, bool_18: true) != -1)
		{
			XmlTextReader xmlTextReader = Class536.smethod_5(class1558_0.class1553_0.class746_0, string_7);
			Hashtable hashtable = Class1608.Read(xmlTextReader);
			xmlTextReader.Close();
			if (hashtable != null && hashtable.Count > 0)
			{
				Class1564 @class = Class1608.smethod_4(hashtable, string_8);
				if (@class != null)
				{
					string text = @class.string_3;
					if (text.StartsWith("../"))
					{
						text = text.Substring(3);
					}
					return text;
				}
			}
		}
		return null;
	}

	private void method_3(ArrayList arrayList_4)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			Class1562 @class = (Class1562)arrayList_1[i];
			bool flag = false;
			for (int j = 0; j < arrayList_4.Count; j++)
			{
				string text = (string)arrayList_4[j];
				if (Class1185.smethod_1(text) == Class1185.smethod_1(@class.string_1) && Class1185.smethod_2(text) == Class1185.smethod_2(@class.string_1))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				arrayList.Add(@class);
			}
		}
		ArrayList arrayList2 = new ArrayList();
		for (int k = 0; k < arrayList.Count; k++)
		{
			Class1562 class2 = (Class1562)arrayList[k];
			arrayList_1.Remove(class2);
			arrayList2.Add(Class1185.smethod_1(class2.string_1));
			string string_ = "xl/pivotCache/_rels/" + Class1185.smethod_1(class2.string_1) + ".rels";
			string text2 = method_2(string_, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotCacheRecords");
			if (text2 != null)
			{
				arrayList2.Add(text2);
			}
		}
		ArrayList arrayList3 = new ArrayList();
		int count = class1558_0.arrayList_0.Count;
		for (int l = 0; l < count; l++)
		{
			Class1530 class3 = (Class1530)class1558_0.arrayList_0[l];
			if (!class3.bool_0 && (class3.string_2 == "application/vnd.openxmlformats-officedocument.spreadsheetml.pivotCacheDefinition+xml" || class3.string_2 == "application/vnd.openxmlformats-officedocument.spreadsheetml.pivotCacheRecords+xml") && method_4(class3.string_1, arrayList2))
			{
				arrayList3.Add(class3);
			}
		}
		for (int m = 0; m < arrayList3.Count; m++)
		{
			Class1530 obj = (Class1530)arrayList3[m];
			class1558_0.arrayList_0.Remove(obj);
		}
	}

	private bool method_4(string string_7, ArrayList arrayList_4)
	{
		int num = 0;
		while (true)
		{
			if (num < arrayList_4.Count)
			{
				string value = Class1185.smethod_1((string)arrayList_4[num]);
				if (string_7.IndexOf(value) != -1)
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

	private void method_5(ArrayList arrayList_4)
	{
		ArrayList arrayList = new ArrayList();
		int count = class1558_0.arrayList_0.Count;
		for (int i = 0; i < count; i++)
		{
			Class1530 @class = (Class1530)class1558_0.arrayList_0[i];
			if (@class.bool_0 || !(@class.string_2 == "application/vnd.openxmlformats-officedocument.spreadsheetml.pivotTable+xml"))
			{
				continue;
			}
			bool flag = false;
			for (int j = 0; j < arrayList_4.Count; j++)
			{
				string text = (string)arrayList_4[j];
				if (Class1185.smethod_1(text) == Class1185.smethod_1(@class.string_1) && Class1185.smethod_2(text) == Class1185.smethod_2(@class.string_1))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				arrayList.Add(@class);
			}
		}
		for (int k = 0; k < arrayList.Count; k++)
		{
			Class1530 obj = (Class1530)arrayList[k];
			class1558_0.arrayList_0.Remove(obj);
		}
	}
}
