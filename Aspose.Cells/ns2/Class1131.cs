using System;
using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1131
{
	internal static byte[] smethod_0(int int_0, string string_0, FontSetting[] fontSetting_0, WorksheetCollection worksheetCollection_0)
	{
		SortedList sortedList = new SortedList();
		foreach (FontSetting fontSetting in fontSetting_0)
		{
			if (fontSetting.method_2() == null)
			{
				continue;
			}
			worksheetCollection_0.method_63(fontSetting.method_2());
			int num;
			if (fontSetting.StartIndex + fontSetting.Length >= string_0.Length)
			{
				sortedList[fontSetting.StartIndex] = fontSetting.Font.method_21();
				num = sortedList.IndexOfKey(fontSetting.StartIndex);
				while (sortedList.Count - 1 > num)
				{
					sortedList.RemoveAt(sortedList.Count - 1);
				}
				continue;
			}
			sortedList[fontSetting.StartIndex] = fontSetting.Font.method_21();
			num = sortedList.IndexOfKey(fontSetting.StartIndex);
			if (num == sortedList.Count - 1)
			{
				sortedList[fontSetting.StartIndex + fontSetting.Length] = int_0;
				continue;
			}
			for (int j = num + 1; j < sortedList.Count - 1; j++)
			{
				int num2 = (int)sortedList.GetKey(j);
				if (num2 < fontSetting.StartIndex + fontSetting.Length)
				{
					num2 = (int)sortedList.GetKey(j + 1);
					if (num2 <= fontSetting.StartIndex + fontSetting.Length)
					{
						sortedList.RemoveAt(j);
						j--;
					}
					else if (num2 > fontSetting.StartIndex + fontSetting.Length)
					{
						sortedList[fontSetting.StartIndex + fontSetting.Length] = fontSetting.Font.method_21();
						break;
					}
				}
				else
				{
					if (num2 <= fontSetting.StartIndex + fontSetting.Length)
					{
						break;
					}
					sortedList[fontSetting.StartIndex + fontSetting.Length] = int_0;
				}
			}
		}
		byte[] array = new byte[sortedList.Count * 4];
		for (int k = 0; k < sortedList.Count; k++)
		{
			int num = (int)sortedList.GetKey(k);
			int num3 = (int)sortedList.GetByIndex(k);
			Array.Copy(BitConverter.GetBytes((ushort)num), 0, array, 4 * k, 2);
			Array.Copy(BitConverter.GetBytes((ushort)num3), 0, array, 4 * k + 2, 2);
		}
		return array;
	}

	internal static void smethod_1(ArrayList arrayList_0, int int_0, Font font_0, bool bool_0)
	{
		ArrayList arrayList = new ArrayList();
		if (!arrayList.Contains(0))
		{
			arrayList.Add(0);
		}
		if (!arrayList.Contains(int_0))
		{
			arrayList.Add(int_0);
		}
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			FontSetting fontSetting = (FontSetting)arrayList_0[i];
			if (!arrayList.Contains(fontSetting.StartIndex))
			{
				arrayList.Add(fontSetting.StartIndex);
			}
			if (!arrayList.Contains(fontSetting.StartIndex + fontSetting.Length))
			{
				arrayList.Add(fontSetting.StartIndex + fontSetting.Length);
			}
		}
		arrayList.Sort();
		Hashtable hashtable = new Hashtable();
		ArrayList arrayList2 = new ArrayList();
		for (int j = 0; j < arrayList.Count - 1; j++)
		{
			int num = (int)arrayList[j];
			int num2 = (int)arrayList[j + 1];
			if (num2 > num + int_0)
			{
				continue;
			}
			FontSetting fontSetting2 = null;
			bool flag = false;
			for (int k = 0; k < arrayList_0.Count; k++)
			{
				fontSetting2 = (FontSetting)arrayList_0[k];
				if (num >= fontSetting2.StartIndex && num2 <= fontSetting2.StartIndex + fontSetting2.Length)
				{
					if (hashtable.Contains(num))
					{
						((FontSetting)hashtable[num]).Font.method_26(fontSetting2.Font);
					}
					else
					{
						FontSetting fontSetting3 = new FontSetting(num, num2 - num, fontSetting2.worksheetCollection_0, fontSetting2.method_0());
						fontSetting3.Font.Copy(fontSetting2.Font);
						arrayList2.Add(fontSetting3);
						hashtable[num] = fontSetting3;
					}
					flag = true;
				}
			}
			if (!flag)
			{
				FontSetting fontSetting4 = new FontSetting(num, num2 - num, font_0.Sheets, bool_0);
				fontSetting4.method_3(font_0);
				arrayList2.Add(fontSetting4);
			}
		}
		arrayList_0.Clear();
		arrayList_0.AddRange(arrayList2);
	}
}
