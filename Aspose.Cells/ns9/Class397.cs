using System;
using System.Collections;
using Aspose.Cells;

namespace ns9;

internal class Class397 : Class316
{
	internal Class397()
	{
	}

	internal void method_6(bool bool_0, Cell cell_0, Hashtable hashtable_0)
	{
		int destinationIndex = 0;
		if (bool_0)
		{
			int_0 = 1;
			byte_0 = new byte[8];
			Array.Copy(BitConverter.GetBytes(cell_0.Column), 0, byte_0, 0, 4);
			destinationIndex = 4;
		}
		else
		{
			int_0 = 12;
			byte_0 = new byte[4];
		}
		int value = (int)hashtable_0[cell_0.method_35()];
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, destinationIndex, 4);
	}
}
