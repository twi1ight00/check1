using System;
using System.Collections;
using Aspose.Cells;
using ns2;

namespace ns9;

internal class Class401 : Class316
{
	internal Class401()
	{
	}

	internal void method_6(bool bool_0, Cell cell_0, Hashtable hashtable_0)
	{
		double doubleValue = cell_0.DoubleValue;
		byte[] array = Class1132.smethod_3(doubleValue);
		int num = 0;
		if (array != null)
		{
			if (bool_0)
			{
				int_0 = 2;
				byte_0 = new byte[12];
				Array.Copy(BitConverter.GetBytes(cell_0.Column), 0, byte_0, num, 4);
				num += 4;
			}
			else
			{
				int_0 = 13;
				byte_0 = new byte[8];
			}
			int value = (int)hashtable_0[cell_0.method_35()];
			Array.Copy(BitConverter.GetBytes(value), 0, byte_0, num, 4);
			num += 4;
			Array.Copy(array, 0, byte_0, num, 4);
		}
		else
		{
			if (bool_0)
			{
				int_0 = 5;
				byte_0 = new byte[16];
				Array.Copy(BitConverter.GetBytes(cell_0.Column), 0, byte_0, num, 4);
				num += 4;
			}
			else
			{
				int_0 = 16;
				byte_0 = new byte[12];
			}
			int value2 = (int)hashtable_0[cell_0.method_35()];
			Array.Copy(BitConverter.GetBytes(value2), 0, byte_0, num, 4);
			num += 4;
			Array.Copy(BitConverter.GetBytes(doubleValue), 0, byte_0, num, 8);
		}
	}
}
