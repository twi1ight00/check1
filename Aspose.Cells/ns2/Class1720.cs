using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1720 : Class1719
{
	private byte[] byte_0;

	private ArrayList arrayList_0;

	internal Class1720(string string_1, byte[] byte_1)
	{
		string_0 = string_1;
		byte_0 = byte_1;
	}

	internal Class1720(string string_1, byte[] byte_1, int int_2)
	{
		string_0 = string_1;
		byte_0 = byte_1;
		int_0 = int_2;
	}

	[SpecialName]
	internal byte[] method_2()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_3(byte[] byte_1)
	{
		byte_0 = byte_1;
		arrayList_0 = null;
	}

	[SpecialName]
	internal ArrayList method_4()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_5(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	[SpecialName]
	internal bool method_6()
	{
		return byte_0 != null;
	}

	internal void ApplyStyle(Cell cell_0, Style style_0, StyleFlag styleFlag_0)
	{
		if (arrayList_0 != null && arrayList_0.Count > 0)
		{
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				FontSetting fontSetting = (FontSetting)arrayList_0[i];
				Class1677.ApplyStyle(style_0, fontSetting.Font, styleFlag_0);
			}
		}
		if (byte_0 == null || byte_0.Length <= 0)
		{
			return;
		}
		for (int j = 0; j < byte_0.Length; j += 4)
		{
			int num = BitConverter.ToUInt16(byte_0, j);
			if (num < string_0.Length)
			{
				int int_ = BitConverter.ToUInt16(byte_0, j + 2);
				Font font_ = cell_0.method_4().method_19().method_53(int_);
				Class1677.ApplyStyle(style_0, font_, styleFlag_0);
				int_ = cell_0.method_4().method_19().method_64(font_);
				Array.Copy(BitConverter.GetBytes(int_), 0, byte_0, j + 2, 2);
				continue;
			}
			break;
		}
	}

	internal void method_7(Class1720 class1720_0, Cell cell_0)
	{
		method_8(class1720_0.byte_0, cell_0);
	}

	internal void method_8(byte[] byte_1, Cell cell_0)
	{
		byte_0 = null;
		if (byte_1 != null)
		{
			ArrayList arrayList = new ArrayList();
			int num = 0;
			while (true)
			{
				if (num < byte_1.Length)
				{
					int num2 = BitConverter.ToUInt16(byte_1, num);
					if (num2 >= string_0.Length)
					{
						break;
					}
					if (num == 0 && num2 != 0)
					{
						FontSetting fontSetting = new FontSetting(0, num2, cell_0.method_4().method_19(), bool_1: false);
						fontSetting.Font.Copy(cell_0.method_32().Font);
						arrayList.Add(fontSetting);
					}
					int int_ = BitConverter.ToUInt16(byte_1, num + 2);
					int num3 = 0;
					num3 = ((num + 4 < byte_1.Length) ? (BitConverter.ToUInt16(byte_1, num + 4) - num2) : (string_0.Length - num2));
					FontSetting fontSetting2 = new FontSetting(num2, num3, cell_0.method_4().method_19(), bool_1: false);
					fontSetting2.Font.Copy(cell_0.method_4().method_19().method_53(int_));
					arrayList.Add(fontSetting2);
					num += 4;
					continue;
				}
				arrayList_0 = arrayList;
				return;
			}
			method_5(arrayList);
		}
		else
		{
			arrayList_0 = new ArrayList();
		}
	}

	internal void method_9(Cell cell_0)
	{
		method_8(byte_0, cell_0);
		byte_0 = null;
	}

	internal void Copy(Cell cell_0, Class1720 class1720_0, Cell cell_1)
	{
		string_0 = class1720_0.string_0;
		arrayList_0 = new ArrayList();
		byte_0 = null;
		ArrayList characters = class1720_0.GetCharacters(cell_0.method_4().method_19(), cell_0);
		for (int i = 0; i < characters.Count; i++)
		{
			FontSetting fontSetting = (FontSetting)characters[i];
			FontSetting fontSetting2 = new FontSetting(fontSetting.StartIndex, fontSetting.Length, cell_1.method_4().method_19(), bool_1: false);
			fontSetting2.Font.Copy(fontSetting.method_2());
			arrayList_0.Add(fontSetting2);
		}
	}

	internal ArrayList GetCharacters(WorksheetCollection worksheetCollection_0, Cell cell_0)
	{
		if (arrayList_0 != null && arrayList_0.Count != 0)
		{
			Class1131.smethod_1(arrayList_0, cell_0.StringValue.Length, cell_0.GetStyle().Font, bool_0: false);
			FontSetting fontSetting = (FontSetting)arrayList_0[0];
			if (fontSetting.StartIndex != 0)
			{
				FontSetting fontSetting2 = new FontSetting(0, fontSetting.StartIndex, worksheetCollection_0, bool_1: false);
				fontSetting2.Font.Copy(cell_0.GetStyle().Font);
				arrayList_0.Insert(0, fontSetting2);
			}
			return arrayList_0;
		}
		if (byte_0 != null)
		{
			byte[] array = byte_0;
			ArrayList arrayList = new ArrayList();
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					int num2 = BitConverter.ToUInt16(array, num);
					if (num2 >= string_0.Length)
					{
						break;
					}
					if (num == 0 && num2 != 0)
					{
						FontSetting fontSetting3 = new FontSetting(0, num2, worksheetCollection_0, bool_1: false);
						fontSetting3.Font.Copy(cell_0.method_32().Font);
						arrayList.Add(fontSetting3);
					}
					int num3 = BitConverter.ToUInt16(array, num + 2);
					int num4 = 0;
					num4 = ((num + 4 < array.Length) ? (BitConverter.ToUInt16(array, num + 4) - num2) : (string_0.Length - num2));
					if (num2 + num4 > string_0.Length)
					{
						num4 = string_0.Length - num2;
					}
					if (num4 > 0)
					{
						Font font = null;
						if (num3 < 0)
						{
							font = null;
						}
						else
						{
							if (num3 > 4)
							{
								num3--;
							}
							font = ((num3 < worksheetCollection_0.method_52().Count) ? ((Font)worksheetCollection_0.method_52()[num3]) : ((Font)worksheetCollection_0.method_52()[0]));
						}
						FontSetting fontSetting4 = new FontSetting(num2, num4, worksheetCollection_0, bool_1: false);
						if (font != null)
						{
							fontSetting4.Font.Copy(font);
						}
						arrayList.Add(fontSetting4);
					}
					num += 4;
					continue;
				}
				return arrayList;
			}
			if (num == 0)
			{
				FontSetting fontSetting5 = new FontSetting(0, string_0.Length, worksheetCollection_0, bool_1: false);
				fontSetting5.Font.Copy(cell_0.method_32().Font);
				arrayList.Add(fontSetting5);
			}
			return arrayList;
		}
		return null;
	}

	internal bool method_10(string string_1, byte[] byte_1)
	{
		if (string_0 == string_1 && byte_0 != null)
		{
			byte[] array = byte_0;
			if (array.Length == byte_1.Length)
			{
				bool flag = true;
				for (int i = 0; i < byte_1.Length; i++)
				{
					if (array[i] != byte_1[i])
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return true;
				}
			}
		}
		return false;
	}
}
