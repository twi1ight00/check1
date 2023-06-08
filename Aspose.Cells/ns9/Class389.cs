using System;
using Aspose.Cells.Tables;
using ns10;

namespace ns9;

internal class Class389 : Class316
{
	internal Class389(TableStyleElement tableStyleElement_0)
	{
		int_0 = 512;
		byte_0 = new byte[12];
		Array.Copy(BitConverter.GetBytes(Class1224.smethod_31(tableStyleElement_0.Type)), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(tableStyleElement_0.Size), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(tableStyleElement_0.int_1), 0, byte_0, 8, 4);
	}
}
