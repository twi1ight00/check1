using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns51;

internal class Class1268
{
	internal static string smethod_0(int int_0, WorksheetCollection worksheetCollection_0, int int_1, Hashtable hashtable_0)
	{
		Class1246 @class = worksheetCollection_0.method_32()[int_0];
		int ushort_ = @class.ushort_0;
		int ushort_2 = @class.ushort_1;
		int ushort_3 = @class.ushort_2;
		if (ushort_ == worksheetCollection_0.method_36())
		{
			if (ushort_2 >= 0 && ushort_2 < worksheetCollection_0.Count)
			{
				string text = worksheetCollection_0[ushort_2].Name;
				if (ushort_2 != ushort_3)
				{
					text = text + ":" + worksheetCollection_0[ushort_3].Name;
				}
				if (text.IndexOf('\'') != -1)
				{
					return "'" + text.Replace("'", "''") + "'";
				}
				if (Class1677.smethod_21(text))
				{
					text = "'" + text + "'";
				}
				return text;
			}
			return "#REF";
		}
		StringBuilder stringBuilder = new StringBuilder();
		Class1718 class2 = worksheetCollection_0.method_39()[ushort_];
		if (class2.Type == Enum194.const_5)
		{
			return "";
		}
		if (class2.method_4() != null && ushort_2 >= 0 && ushort_2 < class2.method_4().Length)
		{
			string text2 = class2.method_4()[ushort_2];
			stringBuilder.Append('\'');
			if (int_1 == 1)
			{
				stringBuilder.Append('[');
				stringBuilder.Append(hashtable_0[ushort_]);
			}
			else
			{
				string text3 = class2.method_19(worksheetCollection_0.Workbook);
				text3 = text3.Replace('/', '\\');
				int num = text3.LastIndexOf('\\');
				if (num != -1)
				{
					stringBuilder.Append(text3.Substring(0, num + 1));
					stringBuilder.Append('[');
					stringBuilder.Append(text3.Substring(num + 1));
				}
				else if (text3.Length > 2 && text3[1] == ':')
				{
					stringBuilder.Append(text3.Substring(0, 3));
					stringBuilder.Append('[');
					stringBuilder.Append(text3.Substring(3));
				}
				else
				{
					stringBuilder.Append('[');
					stringBuilder.Append(text3);
				}
			}
			stringBuilder.Append(']');
			if (text2.IndexOf('\'') != -1)
			{
				text2 = text2.Replace("'", "''");
			}
			stringBuilder.Append(text2);
			if (ushort_2 != ushort_3)
			{
				stringBuilder.Append(':');
				text2 = class2.method_4()[ushort_3];
				if (text2.IndexOf('\'') != -1)
				{
					text2 = text2.Replace("'", "''");
				}
				stringBuilder.Append(text2);
			}
			stringBuilder.Append('\'');
			return stringBuilder.ToString();
		}
		return "#REF";
	}

	internal static int smethod_1(byte[] byte_0, int int_0)
	{
		return BitConverter.ToUInt16(byte_0, int_0) & 0x3FFF;
	}

	internal static int smethod_2(byte[] byte_0, int int_0, int int_1, byte byte_1)
	{
		if ((byte_1 & 0x80) == 0)
		{
			return BitConverter.ToInt32(byte_0, int_0);
		}
		int num = BitConverter.ToInt32(byte_0, int_0);
		if (num + int_1 > 1048575)
		{
			return num + int_1 - 1048575 - 1;
		}
		return num + int_1;
	}

	internal static void smethod_3(byte[] byte_0, int int_0, int int_1, int int_2, bool bool_0, bool bool_1)
	{
		if (!bool_0 && bool_1)
		{
			int num = int_1 - int_2;
			byte[] bytes = BitConverter.GetBytes(num);
			if (num < 0)
			{
				bytes[3] = 0;
				bytes[2] &= 15;
			}
			Array.Copy(bytes, 0, byte_0, int_0, 4);
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(int_1), 0, byte_0, int_0, 4);
		}
	}

	internal static void smethod_4(byte[] byte_0, int int_0, int int_1, int int_2, bool bool_0, bool bool_1)
	{
		byte[] array = null;
		array = ((bool_0 || !bool_1) ? BitConverter.GetBytes((short)int_1) : BitConverter.GetBytes((short)(int_1 - int_2)));
		byte_0[int_0] = array[0];
		byte_0[int_0 + 1] = (byte)((array[1] & 0x3Fu) | (byte_0[int_0 + 1] & 0xC0u));
	}

	internal static void smethod_5(byte[] byte_0, int int_0, int int_1, int int_2, bool bool_0, bool bool_1)
	{
		byte[] array = null;
		array = ((bool_0 || !bool_1) ? BitConverter.GetBytes((short)int_1) : BitConverter.GetBytes((short)(int_1 - int_2)));
		byte_0[int_0] = array[0];
		byte_0[int_0 + 1] = (byte)((array[1] & 0x3Fu) | (byte_0[int_0 + 1] & 0xC0u));
	}

	internal static int smethod_6(byte[] byte_0, int int_0, int int_1, byte byte_1)
	{
		if ((byte_1 & 0x40) == 0)
		{
			return BitConverter.ToUInt16(byte_0, int_0) & 0x3FFF;
		}
		int num = BitConverter.ToUInt16(byte_0, int_0) & 0x3FFF;
		if (num + int_1 > 16383)
		{
			return num + int_1 - 16383 - 1;
		}
		return num + int_1;
	}
}
