using System;
using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1303 : CollectionBase
{
	public Class1718 this[int int_0] => (Class1718)base.InnerList[int_0];

	public int[] method_0(WorksheetCollection worksheetCollection_0)
	{
		int num = -1;
		for (int i = 0; i < base.Count; i++)
		{
			Class1718 @class = this[i];
			if (@class.Type == Enum194.const_5)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Class1718 value = new Class1718(Enum194.const_5);
			base.InnerList.Add(value);
			num = base.InnerList.Count - 1;
		}
		int num2 = worksheetCollection_0.method_32().method_2((ushort)num, 65534, 65534);
		return new int[4] { num2, num, 65534, 65534 };
	}

	public int Add(Class1718 class1718_0)
	{
		base.InnerList.Add(class1718_0);
		return base.Count - 1;
	}

	internal int method_1(string string_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1718 @class = this[num];
				if (@class.method_25() == string_0)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal int method_2(Class1718 class1718_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1718 @class = this[num];
				if (@class.Type == class1718_0.Type)
				{
					if (@class.method_16() == null)
					{
						if (class1718_0.method_16() == null)
						{
							return num;
						}
					}
					else if (class1718_0.method_16() != null && @class.method_16().ToLower() == class1718_0.method_16().ToLower())
					{
						break;
					}
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal int AddCopy(WorksheetCollection worksheetCollection_0, WorksheetCollection worksheetCollection_1, int int_0, Hashtable hashtable_0)
	{
		Class1718 @class = worksheetCollection_1.method_39()[int_0];
		string[] array = null;
		int num = -1;
		if (@class.method_12())
		{
			Class1718 class2 = new Class1718();
			num = base.InnerList.Count;
			base.InnerList.Add(class2);
			string text = worksheetCollection_1.Workbook.FileName;
			if (text == null || text == "")
			{
				text = "Book1" + (worksheetCollection_1.Workbook.method_24() ? ".xlsx" : ".xls");
			}
			array = new string[worksheetCollection_1.Count];
			for (int i = 0; i < worksheetCollection_1.Count; i++)
			{
				array[i] = worksheetCollection_1[i].Name;
			}
			class2.method_24(text, array, Enum188.const_0);
		}
		else
		{
			Class1718 class3 = new Class1718();
			class3.method_17(@class.method_16());
			class3.Type = @class.Type;
			num = base.InnerList.Count;
			base.InnerList.Add(class3);
			if (@class.method_4() != null)
			{
				array = new string[@class.method_4().Length];
				Array.Copy(@class.method_4(), array, array.Length);
				class3.method_5(array);
			}
			class3.method_1(@class.method_0());
		}
		for (int j = 0; j < worksheetCollection_1.method_32().Count; j++)
		{
			Class1246 class4 = worksheetCollection_1.method_32()[j];
			if (class4.ushort_0 == int_0)
			{
				int num2 = worksheetCollection_0.method_32().method_2((ushort)num, class4.ushort_1, class4.ushort_2);
				if (hashtable_0[j] == null)
				{
					hashtable_0.Add(j, num2);
				}
			}
		}
		return num;
	}

	internal static int[] smethod_0(WorksheetCollection worksheetCollection_0, string string_0)
	{
		string[] array = string_0.Split('!');
		string_0 = array[0];
		string text = array[1];
		if (text[0] == '\'')
		{
			text = text.Substring(1, text.Length - 2);
		}
		int num = -1;
		Class1303 @class = worksheetCollection_0.method_39();
		int num2 = -1;
		Class1718 class2 = null;
		if (string_0 != null && string_0.Length > 2 && string_0[0] == '[' && string_0[string_0.Length - 1] == ']' && Class1677.smethod_19(string_0.Substring(1, string_0.Length - 2)))
		{
			string_0 = string_0.Substring(1, string_0.Length - 2);
			num = int.Parse(string_0);
			class2 = @class[num];
			num2 = worksheetCollection_0.method_32().method_10(num, 65534, 65534);
		}
		else
		{
			string[] array2 = string_0.Split('|');
			for (int i = 0; i < @class.Count; i++)
			{
				Class1718 class3 = @class[i];
				if (class3.Type == Enum194.const_3 || class3.Type == Enum194.const_4)
				{
					class3.method_20(out var progId, out var fileName);
					if (progId == array2[0] && fileName == array2[1])
					{
						num = i;
						break;
					}
				}
			}
			if (num != -1)
			{
				class2 = @class[num];
				num2 = worksheetCollection_0.method_32().method_10(num, 65534, 65534);
			}
			else
			{
				class2 = new Class1718(Enum194.const_3);
				class2.method_21(array2[0], array2[1]);
				@class.Add(class2);
				num = @class.Count - 1;
				num2 = worksheetCollection_0.method_32().method_3((ushort)num, 65534, 65534);
			}
		}
		ArrayList arrayList = class2.method_0();
		int num3 = -1;
		for (int j = 0; j < arrayList.Count; j++)
		{
			Class1653 class4 = (Class1653)arrayList[j];
			if (class4.Name == text)
			{
				num3 = j;
				break;
			}
		}
		if (num3 == -1)
		{
			if (arrayList.Count == 0)
			{
				num3 = 0;
				Class1653 class5 = new Class1653(class2);
				class5.Name = text;
				arrayList.Add(class5);
				class5 = new Class1653(class2);
				class5.Name = "StdDocumentName";
				arrayList.Add(class5);
			}
			else
			{
				Class1653 class6 = new Class1653(class2);
				class6.Name = text;
				if (((Class1653)arrayList[arrayList.Count - 1]).Name == "StdDocumentName")
				{
					num3 = arrayList.Count - 1;
					arrayList.Insert(num3, class6);
				}
				else
				{
					arrayList.Add(class6);
					num3 = arrayList.Count - 1;
				}
			}
		}
		return new int[2]
		{
			num2,
			num3 + 1
		};
	}
}
