using System;
using Aspose.Cells.Tables;
using ns2;
using ns59;

namespace ns27;

internal class Class691 : Class538
{
	private int int_0;

	internal Class691()
	{
		method_2(2162);
	}

	internal int method_4(int int_1, ListObject listObject_0)
	{
		int num = 101 + method_5(listObject_0.Name) + method_5(listObject_0.method_0().ToString());
		for (int i = 0; i < listObject_0.ListColumns.Count; i++)
		{
			num += method_7(listObject_0.ListColumns[i], i);
		}
		return num;
	}

	internal int method_5(string string_0)
	{
		return 2 + Class1677.smethod_29(string_0);
	}

	internal void method_6(int int_1, ListObject listObject_0)
	{
		if (listObject_0.byte_0 != null)
		{
			int_0 = listObject_0.byte_0.Length;
			byte_0 = listObject_0.byte_0;
			return;
		}
		int_0 = method_4(int_1, listObject_0);
		byte_0 = new byte[int_0];
		int num = 0;
		byte[] array = byte_0;
		num = 0 + 1;
		array[0] = 114;
		byte[] array2 = byte_0;
		num = 1 + 1;
		array2[1] = 8;
		byte[] array3 = byte_0;
		num = 2 + 1;
		array3[2] = 1;
		num = 3 + 1;
		Array.Copy(BitConverter.GetBytes((ushort)listObject_0.StartRow), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)listObject_0.EndRow), 0, byte_0, 4 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)listObject_0.StartColumn), 0, byte_0, 4 + 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)listObject_0.EndColumn), 0, byte_0, 4 + 6, 2);
		num = 4 + 8;
		byte_0[12] = 5;
		byte_0[12 + 7] = 1;
		num = 12 + 15;
		Array.Copy(BitConverter.GetBytes((ushort)listObject_0.StartRow), 0, byte_0, 27, 2);
		Array.Copy(BitConverter.GetBytes((ushort)listObject_0.EndRow), 0, byte_0, 27 + 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)listObject_0.StartColumn), 0, byte_0, 27 + 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)listObject_0.EndColumn), 0, byte_0, 27 + 6, 2);
		num = 27 + 8;
		num = 35 + 4;
		byte_0[39] = (byte)listObject_0.method_0();
		num = 39 + 4;
		byte_0[43] = 1;
		num = 43 + 4;
		byte_0[47] = (byte)(listObject_0.ShowTotals ? 1u : 0u);
		num += 4;
		byte_0[num] = 0;
		num += 4;
		byte_0[num] = 64;
		num += 4;
		byte_0[num] = 102;
		byte_0[num + 1] = 50;
		num += 4;
		byte_0[num] = 0;
		if (listObject_0.method_53())
		{
			byte_0[num] = 6;
		}
		byte_0[num + 1] = 0;
		if (listObject_0.method_53())
		{
			byte_0[num + 1] = 8;
		}
		byte_0[num + 2] = 222;
		num += 4;
		num += 32;
		num = method_9(listObject_0.Name, num);
		Array.Copy(BitConverter.GetBytes((ushort)(listObject_0.EndColumn - listObject_0.StartColumn + 1)), 0, byte_0, num, 2);
		num += 2;
		num = method_9(listObject_0.method_0().ToString(), num);
		for (int i = 0; i < listObject_0.ListColumns.Count; i++)
		{
			num = method_8(listObject_0.ListColumns[i], i, num);
		}
	}

	internal static int smethod_0(Class578 class578_0, Class1685 class1685_0)
	{
		int num = 0;
		if (class578_0 != null)
		{
			num += class578_0.Length;
		}
		if (class1685_0 != null)
		{
			num += 8 + Class588.smethod_0(class1685_0);
		}
		return num;
	}

	internal int method_7(ListColumn listColumn_0, int int_1)
	{
		int num = 36 + method_5(0.ToString()) + method_5(listColumn_0.Name);
		if (listColumn_0.style_1 != null)
		{
			Class578 class578_ = new Class578(listColumn_0.method_20());
			num += smethod_0(class578_, listColumn_0.method_18(listColumn_0.method_20()));
		}
		if (listColumn_0.style_0 != null)
		{
			Class578 class578_2 = new Class578(listColumn_0.method_19());
			num += smethod_0(class578_2, listColumn_0.method_18(listColumn_0.method_19()));
		}
		if (listColumn_0.method_0())
		{
			num += 6;
		}
		return num;
	}

	internal static int smethod_1(Class578 class578_0, Class1685 class1685_0, byte[] byte_1, int int_1)
	{
		if (class578_0 != null)
		{
			Array.Copy(class578_0.Data, 0, byte_1, int_1, class578_0.Length);
			int_1 += class578_0.Length;
		}
		if (class1685_0 != null)
		{
			int_1 += 6;
			Array.Copy(BitConverter.GetBytes((ushort)class1685_0.Count), 0, byte_1, int_1, 2);
			int_1 += 2;
			int_1 = Class588.Write(class1685_0, byte_1, int_1);
		}
		return int_1;
	}

	internal int method_8(ListColumn listColumn_0, int int_1, int int_2)
	{
		byte[] array = new byte[36]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			255, 255, 255, 255, 1, 0, 0, 0, 0, 0,
			0, 0, 255, 255, 255, 255
		};
		array[0] = (byte)listColumn_0.int_5;
		array[12] = (byte)listColumn_0.TotalsCalculation;
		Class578 class578_ = null;
		Class578 class578_2 = null;
		if (listColumn_0.style_1 != null)
		{
			class578_ = new Class578(listColumn_0.method_20());
		}
		if (listColumn_0.style_0 != null)
		{
			class578_2 = new Class578(listColumn_0.method_19());
		}
		if (listColumn_0.style_1 != null)
		{
			array[16] = (byte)smethod_0(class578_, listColumn_0.method_18(listColumn_0.method_20()));
		}
		if (listColumn_0.style_0 != null)
		{
			array[28] = (byte)smethod_0(class578_2, listColumn_0.method_18(listColumn_0.method_19()));
		}
		if (!listColumn_0.method_0())
		{
			array[24] = 0;
		}
		Array.Copy(array, 0, byte_0, int_2, array.Length);
		int_2 += array.Length;
		string string_ = 0.ToString();
		int_2 = method_9(string_, int_2);
		string_ = listColumn_0.Name;
		int_2 = method_9(string_, int_2);
		if (listColumn_0.style_1 != null)
		{
			int_2 = smethod_1(class578_, listColumn_0.method_18(listColumn_0.method_20()), byte_0, int_2);
		}
		if (listColumn_0.style_0 != null)
		{
			int_2 = smethod_1(class578_2, listColumn_0.method_18(listColumn_0.method_19()), byte_0, int_2);
		}
		if (listColumn_0.method_0())
		{
			int_2 += 4;
			byte_0[int_2] = byte.MaxValue;
			byte_0[int_2 + 1] = byte.MaxValue;
			int_2 += 2;
		}
		return int_2;
	}

	private int method_9(string string_0, int int_1)
	{
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, byte_0, int_1, 2);
		int_1 += 2;
		byte[] array = Class1677.smethod_15(string_0);
		byte_0[int_1++] = (byte)((array.Length != string_0.Length) ? 1u : 0u);
		Array.Copy(array, 0, byte_0, int_1, array.Length);
		int_1 += array.Length;
		return int_1;
	}

	internal void method_10(Class1725 class1725_0)
	{
		byte[] array = null;
		if (int_0 > 8224)
		{
			array = new byte[4];
			Array.Copy(BitConverter.GetBytes(method_1()), 0, array, 0, 2);
			Array.Copy(BitConverter.GetBytes((short)8224), 0, array, 2, 2);
			class1725_0.method_3(array);
			class1725_0.method_2(byte_0, 0, 8224);
			array = new byte[16];
			byte[] array2 = array;
			array[4] = 117;
			array2[0] = 117;
			byte[] array3 = array;
			array[5] = 8;
			array3[1] = 8;
			int num = 8224;
			int num2;
			while (true)
			{
				num2 = byte_0.Length - num;
				if (num2 <= 8212)
				{
					break;
				}
				Array.Copy(BitConverter.GetBytes((short)8224), 0, array, 2, 2);
				class1725_0.method_3(array);
				class1725_0.method_2(byte_0, num, 8212);
				num += 8212;
			}
			Array.Copy(BitConverter.GetBytes(num2 + 12), 0, array, 2, 2);
			class1725_0.method_3(array);
			class1725_0.method_2(byte_0, num, num2);
		}
		else
		{
			array = new byte[4];
			Array.Copy(BitConverter.GetBytes(method_1()), 0, array, 0, 2);
			Array.Copy(BitConverter.GetBytes(int_0), 0, array, 2, 2);
			class1725_0.method_3(array);
			class1725_0.method_3(byte_0);
		}
	}
}
