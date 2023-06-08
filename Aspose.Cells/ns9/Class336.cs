using System;
using Aspose.Cells.Tables;
using ns10;

namespace ns9;

internal class Class336 : Class316
{
	internal Class336(ListColumn listColumn_0)
	{
		int_0 = 347;
		int num = 48;
		byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
		string name = listColumn_0.Name;
		if (name != null)
		{
			num += name.Length * 2;
		}
		name = listColumn_0.method_16();
		if (name != null)
		{
			num += name.Length * 2;
		}
		byte_0 = new byte[num];
		Array.Copy(BitConverter.GetBytes(listColumn_0.int_5), 0, byte_0, 0, 4);
		int value = Class1224.smethod_29(listColumn_0.TotalsCalculation);
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(listColumn_0.int_3[0]), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(listColumn_0.int_3[1]), 0, byte_0, 12, 4);
		Array.Copy(BitConverter.GetBytes(listColumn_0.int_3[2]), 0, byte_0, 16, 4);
		if (listColumn_0.method_21() != -1)
		{
			Array.Copy(BitConverter.GetBytes(listColumn_0.method_21()), 0, byte_0, 20, 4);
		}
		int num2 = 24;
		name = listColumn_0.method_14();
		if (name != null)
		{
			Class1217.smethod_7(byte_0, ref num2, name);
		}
		else
		{
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		name = listColumn_0.Name;
		if (name != null)
		{
			Class1217.smethod_7(byte_0, ref num2, name);
		}
		else
		{
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		name = listColumn_0.method_16();
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
}
