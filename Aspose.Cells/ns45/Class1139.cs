using System;
using System.Runtime.CompilerServices;
using Aspose.Cells;
using ns2;

namespace ns45;

internal class Class1139
{
	private Class1141 class1141_0;

	internal Worksheet worksheet_0;

	internal Range range_0;

	internal Range range_1;

	internal string string_0;

	internal bool bool_0;

	internal string string_1;

	internal Class1139(Class1141 class1141_1, Worksheet worksheet_1, string string_2)
	{
		class1141_0 = class1141_1;
		worksheet_0 = worksheet_1;
		string_0 = string_2;
	}

	internal string GetSource()
	{
		if (range_0 != null && range_0.Name == null && worksheet_0 != null)
		{
			return Class1156.smethod_9(range_0.Area, worksheet_0.Name);
		}
		return string_0;
	}

	[SpecialName]
	internal int method_0()
	{
		string text = null;
		int num = 0;
		if (range_0 == null)
		{
			if (string_0 == null)
			{
				return 0;
			}
			bool flag = Class1677.smethod_30(string_0);
			num += 4 + (flag ? (string_0.Length + 1) : (string_0.Length * 2 + 2));
		}
		if (worksheet_0 != null && range_0 != null)
		{
			text = worksheet_0.Name;
			text = Class1718.smethod_0(text, Enum188.const_0);
			bool flag2 = Class1677.smethod_30(text);
			num += 4 + (flag2 ? (text.Length + 1) : (text.Length * 2 + 2));
		}
		else if (string_0 == null || (range_0 != null && range_0.Name != null))
		{
			num += 2;
		}
		if (range_0 != null && range_0.Name != null)
		{
			return num + (6 + Class1677.smethod_29(range_0.Name));
		}
		return num + 10;
	}

	internal int method_1(byte[] byte_0, int int_0)
	{
		int num = int_0;
		if (range_0 == null)
		{
			if (string_0 != null)
			{
				int_0 += method_2(byte_0, int_0);
				return int_0 - num;
			}
			return 0;
		}
		int_0 = ((range_0.Name == null) ? (int_0 + method_2(byte_0, int_0)) : (int_0 + method_3(byte_0, int_0)));
		return int_0 - num;
	}

	internal int method_2(byte[] byte_0, int int_0)
	{
		int num = int_0;
		byte_0[int_0] = 81;
		byte_0[int_0 + 1] = 0;
		int_0 += 4;
		if (range_0 != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)range_0.FirstRow), 0, byte_0, int_0, 2);
			Array.Copy(BitConverter.GetBytes((ushort)(range_0.FirstRow + range_0.RowCount - 1)), 0, byte_0, int_0 + 2, 2);
			byte_0[int_0 + 4] = (byte)range_0.FirstColumn;
			byte_0[int_0 + 5] = (byte)(range_0.FirstColumn + range_0.ColumnCount - 1);
		}
		int_0 += 6;
		if (worksheet_0 != null)
		{
			int_0 += Class937.smethod_6(byte_0, int_0, worksheet_0.Name, 2, 2);
		}
		else
		{
			string string_ = string_0;
			string_ = Class1718.smethod_0(string_, Enum188.const_0);
			string_ = string_.Substring(1);
			int_0 += Class937.smethod_6(byte_0, int_0, string_, 2, 2);
		}
		Array.Copy(BitConverter.GetBytes((short)(int_0 - num - 4)), 0, byte_0, num + 2, 2);
		return int_0 - num;
	}

	internal int method_3(byte[] byte_0, int int_0)
	{
		int num = int_0;
		byte_0[int_0] = 82;
		byte_0[int_0 + 1] = 0;
		int_0 += 4;
		byte_0[int_0++] = (byte)range_0.Name.Length;
		int_0++;
		byte[] array = Class1677.smethod_15(range_0.Name);
		if (array != null)
		{
			byte_0[int_0++] = (byte)((array.Length != range_0.Name.Length) ? 1u : 0u);
			Array.Copy(array, 0, byte_0, int_0, array.Length);
			int_0 += array.Length;
		}
		else
		{
			byte_0[int_0++] = 0;
		}
		if (worksheet_0 != null)
		{
			int_0 += Class937.smethod_6(byte_0, int_0, worksheet_0.Name, 2, 2);
		}
		else
		{
			byte_0[int_0++] = 0;
			byte_0[int_0++] = 0;
		}
		Array.Copy(BitConverter.GetBytes((short)(int_0 - num - 4)), 0, byte_0, num + 2, 2);
		return int_0 - num;
	}
}
