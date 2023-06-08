using System;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns10;

namespace ns9;

internal class Class337 : Class316
{
	internal Class337(ListObject listObject_0)
	{
		int_0 = 343;
		int num = 88;
		byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
		string name = listObject_0.Name;
		if (name != null)
		{
			num += name.Length * 2;
		}
		name = listObject_0.DisplayName;
		if (name != null)
		{
			num += name.Length * 2;
		}
		name = listObject_0.Comment;
		if (name != null)
		{
			num += name.Length * 2;
		}
		byte_0 = new byte[num];
		byte b = 0;
		Class1217.smethod_4(method_6(listObject_0), byte_0, 0);
		int value = Class1224.smethod_27(listObject_0.method_13());
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 16, 4);
		Array.Copy(BitConverter.GetBytes(listObject_0.method_0()), 0, byte_0, 20, 4);
		Array.Copy(BitConverter.GetBytes((listObject_0.method_48() == -1) ? 1 : listObject_0.method_48()), 0, byte_0, 24, 4);
		if (!listObject_0.method_19())
		{
			b = b;
		}
		else
		{
			b = (byte)(b | 1u);
			Array.Copy(BitConverter.GetBytes((listObject_0.method_51() <= 1) ? 1 : listObject_0.method_51()), 0, byte_0, 28, 4);
		}
		if (listObject_0.method_21())
		{
			b = (byte)(b | 2u);
		}
		if (listObject_0.method_25())
		{
			b = (byte)(b | 0x10u);
		}
		if (listObject_0.method_17())
		{
			b = (byte)(b | 8u);
		}
		byte_0[32] = b;
		Array.Copy(BitConverter.GetBytes(listObject_0.int_10[0]), 0, byte_0, 36, 4);
		Array.Copy(BitConverter.GetBytes(listObject_0.int_10[1]), 0, byte_0, 40, 4);
		Array.Copy(BitConverter.GetBytes(listObject_0.int_10[2]), 0, byte_0, 44, 4);
		Array.Copy(BitConverter.GetBytes(listObject_0.int_10[3]), 0, byte_0, 48, 4);
		Array.Copy(BitConverter.GetBytes(listObject_0.int_10[4]), 0, byte_0, 52, 4);
		Array.Copy(BitConverter.GetBytes(listObject_0.int_10[5]), 0, byte_0, 56, 4);
		if (listObject_0.method_33() != -1)
		{
			Array.Copy(BitConverter.GetBytes(listObject_0.method_33()), 0, byte_0, 60, 4);
		}
		int num2 = 64;
		name = listObject_0.Name;
		if (name != null)
		{
			Class1217.smethod_7(byte_0, ref num2, name);
		}
		else
		{
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		name = listObject_0.DisplayName;
		if (name != null)
		{
			Class1217.smethod_7(byte_0, ref num2, name);
		}
		else
		{
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		name = listObject_0.Comment;
		if (name != null)
		{
			Class1217.smethod_7(byte_0, ref num2, name);
		}
		else
		{
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		Array.Copy(sourceArray, 0, byte_0, num2, 4);
		num2 += 4;
		Array.Copy(sourceArray, 0, byte_0, num2, 4);
		num2 += 4;
		Array.Copy(sourceArray, 0, byte_0, num2, 4);
		num2 += 4;
	}

	private CellArea method_6(ListObject listObject_0)
	{
		CellArea result = default(CellArea);
		result.StartRow = listObject_0.StartRow;
		result.StartColumn = listObject_0.StartColumn;
		result.EndRow = listObject_0.EndRow;
		result.EndColumn = listObject_0.EndColumn;
		return result;
	}
}
