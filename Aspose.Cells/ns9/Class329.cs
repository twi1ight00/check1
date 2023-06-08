using System;
using Aspose.Cells;

namespace ns9;

internal class Class329 : Class316
{
	internal Class329(FilterColumn filterColumn_0)
	{
		int_0 = 163;
		byte_0 = new byte[6];
		Array.Copy(BitConverter.GetBytes(filterColumn_0.FieldIndex), 0, byte_0, 0, 4);
		byte b = 0;
		if (filterColumn_0.method_0())
		{
			b = (byte)(b | 1u);
		}
		if (!filterColumn_0.method_2())
		{
			b = (byte)(b | 2u);
		}
		byte_0[4] = b;
	}
}
