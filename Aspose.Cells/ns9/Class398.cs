using System;
using System.Collections;
using Aspose.Cells;

namespace ns9;

internal class Class398 : Class316
{
	internal Class398()
	{
	}

	internal void method_6(bool bool_0, Cell cell_0, Hashtable hashtable_0)
	{
		int num = 0;
		if (bool_0)
		{
			int_0 = 4;
			byte_0 = new byte[9];
			Array.Copy(BitConverter.GetBytes(cell_0.Column), 0, byte_0, 0, 4);
			num = 4;
		}
		else
		{
			int_0 = 15;
			byte_0 = new byte[5];
		}
		int value = (int)hashtable_0[cell_0.method_35()];
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, num, 4);
		num += 4;
		if (cell_0.BoolValue)
		{
			byte_0[num] = 1;
		}
		else
		{
			byte_0[num] = 0;
		}
	}
}
