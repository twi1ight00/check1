using System;
using System.Collections;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns38;

internal class Class932
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
		if (class2.method_4() != null && ushort_2 >= 0 && ushort_2 < class2.method_4().Length)
		{
			string value = class2.method_4()[ushort_2];
			stringBuilder.Append('\'');
			if (int_1 == 1)
			{
				stringBuilder.Append('[');
				stringBuilder.Append(hashtable_0[ushort_]);
			}
			else
			{
				string text2 = class2.method_19(worksheetCollection_0.Workbook);
				int num = text2.LastIndexOf('\\');
				if (num != -1)
				{
					stringBuilder.Append(text2.Substring(0, num + 1));
					stringBuilder.Append('[');
					stringBuilder.Append(text2.Substring(num + 1));
				}
				else if (text2.Length > 2 && text2[1] == ':')
				{
					stringBuilder.Append(text2.Substring(0, 3));
					stringBuilder.Append('[');
					stringBuilder.Append(text2.Substring(3));
				}
				else
				{
					stringBuilder.Append('[');
					stringBuilder.Append(text2);
				}
			}
			stringBuilder.Append(']');
			stringBuilder.Append(value);
			stringBuilder.Append('\'');
			return stringBuilder.ToString();
		}
		return "#REF";
	}

	internal static int smethod_1(byte[] byte_0, int int_0, int int_1, byte byte_1)
	{
		if ((byte_1 & 0x80) == 0)
		{
			return BitConverter.ToUInt16(byte_0, int_0);
		}
		int num = BitConverter.ToInt16(byte_0, int_0);
		int num2 = num + int_1;
		if (num2 > 65535)
		{
			num2 = num2 - 65535 - 1;
		}
		return num2;
	}

	internal static int smethod_2(byte[] byte_0, int int_0, int int_1, byte byte_1)
	{
		if ((byte_1 & 0x40) == 0)
		{
			return byte_0[int_0] & 0xFF;
		}
		int num = byte_0[int_0] & 0xFF;
		int num2 = num + int_1;
		if (num2 > 255)
		{
			num2 = num2 - 255 - 1;
		}
		return num2;
	}
}
