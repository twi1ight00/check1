using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns10;

internal class Class1217
{
	internal static void smethod_0(WorksheetCollection worksheetCollection_0, Hashtable hashtable_0, Class1737 class1737_0, byte[] byte_0, int int_0)
	{
		bool flag = (byte_0[int_0] & 1) != 0;
		int_0++;
		class1737_0.Text = smethod_5(byte_0, ref int_0);
		if (!flag)
		{
			return;
		}
		int num = BitConverter.ToInt32(byte_0, int_0);
		int_0 += 4;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = int_0;
		for (int i = 0; i < num; i++)
		{
			num4 = BitConverter.ToUInt16(byte_0, num5);
			num3 = ((num5 + 4 == byte_0.Length) ? class1737_0.Text.Length : BitConverter.ToUInt16(byte_0, num5 + 4));
			FontSetting fontSetting = class1737_0.Characters(num4, num3 - num4);
			num2 = BitConverter.ToUInt16(byte_0, num5 + 2);
			if (num2 < hashtable_0.Count)
			{
				num2 = (int)hashtable_0[num2];
				fontSetting.Font.Copy(worksheetCollection_0.method_53(num2));
			}
			num5 += 4;
		}
	}

	internal static CellArea smethod_1(byte[] byte_0, int int_0)
	{
		CellArea result = default(CellArea);
		result.StartRow = BitConverter.ToInt32(byte_0, int_0);
		result.EndRow = BitConverter.ToInt32(byte_0, int_0 + 4);
		result.StartColumn = BitConverter.ToInt32(byte_0, int_0 + 8);
		result.EndColumn = BitConverter.ToInt32(byte_0, int_0 + 12);
		return result;
	}

	internal static ArrayList smethod_2(byte[] byte_0, int int_0)
	{
		int num = BitConverter.ToInt32(byte_0, int_0);
		ArrayList arrayList = new ArrayList();
		int_0 += 4;
		for (int i = 0; i < num; i++)
		{
			CellArea cellArea = default(CellArea);
			cellArea.StartRow = BitConverter.ToInt32(byte_0, int_0);
			cellArea.EndRow = BitConverter.ToInt32(byte_0, int_0 + 4);
			cellArea.StartColumn = BitConverter.ToInt32(byte_0, int_0 + 8);
			cellArea.EndColumn = BitConverter.ToInt32(byte_0, int_0 + 12);
			arrayList.Add(cellArea);
			int_0 += 16;
		}
		return arrayList;
	}

	internal static void smethod_3(ArrayList arrayList_0, byte[] byte_0, int int_0)
	{
		Array.Copy(BitConverter.GetBytes(arrayList_0.Count), 0, byte_0, int_0, 4);
		int_0 += 4;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			CellArea cellArea = (CellArea)arrayList_0[i];
			Array.Copy(BitConverter.GetBytes(cellArea.StartRow), 0, byte_0, int_0, 4);
			Array.Copy(BitConverter.GetBytes(cellArea.EndRow), 0, byte_0, int_0 + 4, 4);
			Array.Copy(BitConverter.GetBytes(cellArea.StartColumn), 0, byte_0, int_0 + 8, 4);
			Array.Copy(BitConverter.GetBytes(cellArea.EndColumn), 0, byte_0, int_0 + 12, 4);
			int_0 += 16;
		}
	}

	internal static void smethod_4(CellArea cellArea_0, byte[] byte_0, int int_0)
	{
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartRow), 0, byte_0, int_0, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndRow), 0, byte_0, int_0 + 4, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.StartColumn), 0, byte_0, int_0 + 8, 4);
		Array.Copy(BitConverter.GetBytes(cellArea_0.EndColumn), 0, byte_0, int_0 + 12, 4);
	}

	[Attribute0(true)]
	internal static string smethod_5(byte[] byte_0, ref int int_0)
	{
		if (int_0 >= byte_0.Length)
		{
			return null;
		}
		int num = BitConverter.ToInt32(byte_0, int_0);
		int_0 += 4;
		if (num < 0)
		{
			return null;
		}
		if (num == 0)
		{
			return "";
		}
		string @string = Encoding.Unicode.GetString(byte_0, int_0, num * 2);
		int_0 += num * 2;
		return @string;
	}

	[Attribute0(true)]
	internal static DateTime smethod_6(byte[] byte_0, int int_0)
	{
		int year = BitConverter.ToUInt16(byte_0, int_0);
		int month = BitConverter.ToUInt16(byte_0, 2 + int_0);
		byte b = byte_0[4 + int_0];
		DateTime dateTime = new DateTime(1900, 1, 1);
		return (b != 0) ? new DateTime(year, month, byte_0[4 + int_0], byte_0[5 + int_0], byte_0[6 + int_0], byte_0[7 + int_0]) : new DateTime(year, month, 1);
	}

	[Attribute0(true)]
	internal static void smethod_7(byte[] byte_0, ref int int_0, string string_0)
	{
		if (string_0 == null)
		{
			for (int i = 0; i < 4; i++)
			{
				byte_0[int_0++] = byte.MaxValue;
			}
		}
		else if (string_0.Length == 0)
		{
			for (int j = 0; j < 4; j++)
			{
				byte_0[int_0++] = 0;
			}
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(string_0.Length), 0, byte_0, int_0, 4);
			int_0 += 4;
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			Array.Copy(bytes, 0, byte_0, int_0, bytes.Length);
			int_0 += bytes.Length;
		}
	}

	[Attribute0(true)]
	internal static string smethod_8(byte[] byte_0, int int_0)
	{
		int num = BitConverter.ToInt32(byte_0, int_0);
		int_0 += 4;
		if (num < 0)
		{
			return null;
		}
		if (num == 0)
		{
			return "";
		}
		return Encoding.Unicode.GetString(byte_0, int_0, num * 2);
	}

	[Attribute0(true)]
	internal static string smethod_9(byte[] byte_0, int int_0)
	{
		int num = BitConverter.ToInt16(byte_0, int_0);
		int_0 += 2;
		if (num < 0)
		{
			return null;
		}
		if (num == 0)
		{
			return "";
		}
		return Encoding.Unicode.GetString(byte_0, int_0, num * 2);
	}
}
