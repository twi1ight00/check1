using System;
using System.Collections;
using Aspose.Cells;

namespace ns9;

internal class Class402 : Class316
{
	internal Class402()
	{
	}

	internal void method_6(bool bool_0, Cell cell_0, Hashtable hashtable_0)
	{
		int num = 0;
		if (bool_0)
		{
			int_0 = 7;
			byte_0 = new byte[12];
			Array.Copy(BitConverter.GetBytes(cell_0.Column), 0, byte_0, 0, 4);
			num = 4;
		}
		else
		{
			int_0 = 18;
			byte_0 = new byte[8];
		}
		int value = (int)hashtable_0[cell_0.method_35()];
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, num, 4);
		num += 4;
		Array.Copy(BitConverter.GetBytes(cell_0.method_21()), 0, byte_0, num, 4);
	}
}
