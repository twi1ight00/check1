using System;
using System.Collections;
using System.Xml;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns16;
using ns22;
using ns58;

namespace ns2;

internal class Class1741
{
	internal static int int_0 = 0;

	internal static int int_1 = 0;

	internal static int int_2 = 0;

	internal static string string_0 = "";

	internal static Hashtable hashtable_0 = new Hashtable();

	internal static Hashtable hashtable_1 = new Hashtable();

	internal static ArrayList arrayList_0 = new ArrayList();

	internal static ArrayList arrayList_1 = new ArrayList();

	internal static void smethod_0(XmlMap xmlMap_0, ListObject listObject_0, string string_1, int int_3, string string_2)
	{
		ListColumn listColumn = new ListColumn(listObject_0.ListColumns, string_2, int_3);
		listColumn.method_15(string_2);
		listColumn.xmlColumnProperty_0 = new XmlColumnProperty();
		listColumn.xmlColumnProperty_0.int_0 = xmlMap_0.int_0;
		listColumn.xmlColumnProperty_0.string_1 = "string";
		if (string_2.Length > 0)
		{
			listColumn.xmlColumnProperty_0.string_0 = string_1 + "/@" + string_2;
		}
		else
		{
			listColumn.method_2(string_1.Substring(string_1.LastIndexOf("/") + 1));
			listColumn.xmlColumnProperty_0.string_0 = string_1;
		}
		listObject_0.ListColumns.Add(listColumn);
	}

	internal static void smethod_1(string string_1, object object_0, int int_3, string string_2, Class1740 class1740_0)
	{
		class1740_0.string_2 = string_1;
		class1740_0.arrayList_0.Add(object_0);
		class1740_0.int_0 = int_3;
		class1740_0.string_0 = string_2;
		int length = string_2.LastIndexOf('/');
		class1740_0.string_1 = string_2.Substring(0, length);
		if (int_3 > int_0)
		{
			int_0 = int_3;
		}
	}

	internal static bool smethod_2(XmlAttributeCollection xmlAttributeCollection_0)
	{
		if (xmlAttributeCollection_0.Count == 1)
		{
			XmlAttribute xmlAttribute = xmlAttributeCollection_0[0];
			if (xmlAttribute.Name.StartsWith("xmlns"))
			{
				return true;
			}
		}
		return false;
	}

	internal static void smethod_3(XmlMap xmlMap_0, ListObject listObject_0, XmlElement xmlElement_0, int int_3, string string_1, Worksheet worksheet_0, int int_4, int int_5, int int_6)
	{
		ArrayList arrayList = new ArrayList();
		bool flag = false;
		string_1 = string_1 + "/" + xmlElement_0.LocalName;
		XmlAttributeCollection attributes = xmlElement_0.Attributes;
		XmlNodeList childNodes = xmlElement_0.ChildNodes;
		if (attributes.Count > 0 && !smethod_2(attributes))
		{
			int_4 = 0;
			for (int i = 0; i < attributes.Count; i++)
			{
				XmlAttribute xmlAttribute = attributes[i];
				_ = listObject_0.ListColumns.Count;
				if (!hashtable_0.Contains(string_1))
				{
					Class1740 @class = new Class1740();
					smethod_1(xmlAttribute.Name, xmlAttribute.Value, int_6, string_1, @class);
					arrayList.Add(@class);
					continue;
				}
				ArrayList arrayList2 = (ArrayList)hashtable_0[string_1];
				for (int j = 0; j < arrayList2.Count; j++)
				{
					Class1740 class2 = (Class1740)arrayList2[j];
					if (class2.string_2 == xmlAttribute.Name)
					{
						class2.arrayList_0.Add(xmlAttribute.Value);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					string value = xmlAttribute.Value;
					if (value.Length > 0 && value.IndexOf("\n") == -1)
					{
						Class1740 class3 = new Class1740();
						smethod_1(xmlAttribute.Name, value, int_6, string_1, class3);
						arrayList2.Add(class3);
					}
				}
			}
			if (arrayList.Count > 0)
			{
				hashtable_0.Add(string_1, arrayList);
				hashtable_1.Add(string_1, int_2);
				int_2++;
			}
		}
		else if (childNodes != null && childNodes.Count == 1)
		{
			object obj = childNodes[0];
			if (obj is XmlText)
			{
				Class1740 class4 = new Class1740();
				smethod_1(xmlElement_0.Name, xmlElement_0.InnerText, int_6, string_1, class4);
				arrayList.Add(class4);
			}
		}
		if (childNodes.Count <= 0)
		{
			return;
		}
		for (int k = 0; k < childNodes.Count; k++)
		{
			object obj2 = childNodes[k];
			if (!(obj2 is XmlElement) && !(obj2 is XmlComment))
			{
				if (!hashtable_0.Contains(string_1))
				{
					if (arrayList.Count > 0)
					{
						hashtable_0.Add(string_1, arrayList);
						hashtable_1.Add(string_1, int_2);
						int_2++;
					}
				}
				else
				{
					if (!(obj2 is XmlText))
					{
						continue;
					}
					string name = ((XmlText)obj2).ParentNode.Name;
					ArrayList arrayList3 = (ArrayList)hashtable_0[string_1];
					for (int l = 0; l < arrayList3.Count; l++)
					{
						Class1740 class5 = (Class1740)arrayList3[l];
						if (class5.string_2 == name)
						{
							class5.arrayList_0.Add(((XmlText)obj2).Value);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						string value2 = ((XmlText)obj2).Value;
						if (value2.Length > 0 && value2.IndexOf("\n") == -1)
						{
							Class1740 class6 = new Class1740();
							smethod_1(name, value2, int_6, string_1, class6);
							arrayList3.Add(class6);
						}
					}
				}
			}
			else if (obj2 is XmlElement)
			{
				XmlElement xmlElement_ = (XmlElement)obj2;
				smethod_3(xmlMap_0, listObject_0, xmlElement_, int_3, string_1, worksheet_0, int_4, int_5, int_6 + 1);
			}
		}
	}

	private static void smethod_4(Hashtable hashtable_2)
	{
		ArrayList arrayList = new ArrayList(hashtable_0.Keys);
		arrayList.Sort();
		for (int i = 0; i < arrayList.Count; i++)
		{
			string key = (string)arrayList[i];
			ArrayList arrayList2 = (ArrayList)hashtable_0[key];
			Class1740 @class = (Class1740)arrayList2[0];
			int count = @class.arrayList_0.Count;
			if (count <= 1)
			{
				continue;
			}
			string string_ = @class.string_1;
			for (int j = 0; j < arrayList.Count; j++)
			{
				string text = (string)arrayList[j];
				string text2 = text.Substring(0, text.LastIndexOf('/'));
				if (string_.IndexOf(text) == -1 && !(text2 == string_))
				{
					continue;
				}
				ArrayList arrayList3 = (ArrayList)hashtable_0[text];
				for (int k = 0; k < arrayList3.Count; k++)
				{
					Class1740 class2 = (Class1740)arrayList3[k];
					int count2 = class2.arrayList_0.Count;
					if (count2 == 1)
					{
						class2.int_2 += count;
					}
				}
			}
		}
	}

	private static int smethod_5(Hashtable hashtable_2)
	{
		int num = 0;
		int num2 = 0;
		ArrayList arrayList = new ArrayList(hashtable_0.Keys);
		arrayList.Sort();
		for (int i = 0; i < arrayList.Count; i++)
		{
			string key = (string)arrayList[i];
			ArrayList arrayList2 = (ArrayList)hashtable_0[key];
			for (int j = 0; j < arrayList2.Count; j++)
			{
				Class1740 @class = (Class1740)arrayList2[j];
				int count = @class.arrayList_0.Count;
				if (int_0 == 2)
				{
					if (@class.int_0 == int_0)
					{
						num2 += count;
					}
				}
				else if (@class.int_0 < int_0)
				{
					if (!(@class.string_1 == string_0) && @class.string_1.IndexOf(string_0) == -1)
					{
						num += count;
						string_0 = @class.string_1;
					}
					else if (num < count && count > 1)
					{
						num = count;
						string_0 = @class.string_1;
					}
				}
				else if (num2 < count)
				{
					num2 = count;
				}
			}
		}
		return num2 + num;
	}

	private static string smethod_6(ListObject listObject_0)
	{
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = listObject_0.StartRow;
		cellArea_.StartColumn = listObject_0.StartColumn;
		cellArea_.EndRow = listObject_0.EndRow;
		if (listObject_0.EndRow - listObject_0.StartRow == 0)
		{
			cellArea_.EndRow++;
		}
		cellArea_.EndColumn = listObject_0.EndColumn;
		return Class1618.smethod_15(cellArea_);
	}

	internal static void smethod_7(XmlMap xmlMap_0, string string_1, Worksheet worksheet_0, ListObject listObject_0, int int_3, int int_4)
	{
		try
		{
			int int_5 = 0;
			int num = 0;
			int num2 = 0;
			string text = "";
			string text2 = "";
			int num3 = 0;
			int num4 = int_3 + 1;
			XmlDocument xmlDocument = Class1188.smethod_0(string_1);
			XmlElement documentElement = xmlDocument.DocumentElement;
			if (documentElement == null)
			{
				return;
			}
			xmlMap_0.string_1 = documentElement.LocalName;
			xmlMap_0.string_0 = documentElement.LocalName + "_map";
			int num5 = 0;
			num = int_3 + 1;
			num2 = int_4;
			smethod_3(xmlMap_0, listObject_0, documentElement, 0, "", worksheet_0, num, num2, int_5);
			int num6 = smethod_5(hashtable_0);
			smethod_4(hashtable_0);
			ArrayList arrayList = new ArrayList(hashtable_1.Values);
			ArrayList arrayList2 = new ArrayList();
			arrayList.Sort();
			foreach (int item in arrayList)
			{
				IDictionaryEnumerator enumerator2 = hashtable_1.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					int num8 = (int)enumerator2.Value;
					if (item == num8)
					{
						arrayList2.Add(enumerator2.Key);
					}
				}
			}
			for (int i = 0; i < arrayList2.Count; i++)
			{
				string text3 = (string)arrayList2[i];
				text3.Substring(0, text3.LastIndexOf('/'));
				if (i > 0)
				{
					text = (string)arrayList2[i - 1];
					text2 = text.Substring(0, text.LastIndexOf('/'));
				}
				ArrayList arrayList3 = (ArrayList)hashtable_0[text3];
				num4 = ((!(text2 != ((Class1740)arrayList3[0]).string_1) || ((Class1740)arrayList3[0]).string_1.IndexOf(text2) != -1 || ((Class1740)arrayList3[0]).arrayList_0.Count <= 1) ? (int_3 + 1) : (num4 + num3));
				num = num4;
				for (int j = 0; j < arrayList3.Count; j++)
				{
					Class1740 @class = (Class1740)arrayList3[j];
					ListColumn listColumn = listObject_0.ListColumns[@class.string_2];
					if (listColumn == null)
					{
						smethod_0(xmlMap_0, listObject_0, text3, num5, @class.string_2);
					}
					else
					{
						listColumn.int_0++;
						smethod_0(xmlMap_0, listObject_0, text3, num5, @class.string_2 + (listColumn.int_0 + 1));
					}
					ArrayList arrayList4 = @class.arrayList_0;
					if (arrayList4.Count > 1)
					{
						for (int k = 0; k < arrayList4.Count; k++)
						{
							worksheet_0.Cells[num, num2].PutValue(arrayList4[k]);
							num++;
						}
					}
					else if (@class.int_2 > 0)
					{
						for (int l = 0; l < @class.int_2; l++)
						{
							worksheet_0.Cells[num, num2].PutValue(arrayList4[0]);
							num++;
						}
					}
					else
					{
						for (int m = 0; m < num6; m++)
						{
							worksheet_0.Cells[num, num2].PutValue(arrayList4[0]);
							num++;
						}
					}
					num5++;
					num2++;
					num = num4;
					if (@class.int_2 != 0)
					{
						num3 = @class.int_2;
					}
					else if (@class.arrayList_0.Count > 0)
					{
						num3 = @class.arrayList_0.Count;
					}
				}
			}
			for (int n = 0; n < listObject_0.ListColumns.Count; n++)
			{
				worksheet_0.Cells[0, n].PutValue(listObject_0.ListColumns[n].Name);
			}
			worksheet_0.AutoFitColumns();
			listObject_0.method_2(int_3);
			listObject_0.method_3(int_4);
			listObject_0.method_4(num6);
			listObject_0.method_5(listObject_0.ListColumns.Count - 1);
			worksheet_0.method_2().int_11++;
			listObject_0.method_34(1);
			listObject_0.AutoFilter.Range = smethod_6(listObject_0);
			listObject_0.TableStyleType = TableStyleType.TableStyleMedium2;
			listObject_0.method_46(worksheet_0.ListObjects.Count);
			listObject_0.method_14(Enum234.const_2);
		}
		catch (Exception)
		{
		}
	}
}
