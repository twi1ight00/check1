using System;
using Aspose.Cells.Tables;
using ns10;

namespace ns27;

internal class Class545 : Class538
{
	internal Class545(TableStyleElement tableStyleElement_0)
	{
		method_2(2192);
		method_0(24);
		byte_0 = new byte[base.Length];
		byte_0[0] = 144;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes(Class1224.smethod_31(tableStyleElement_0.Type)), 0, byte_0, 12, 4);
		Array.Copy(BitConverter.GetBytes(tableStyleElement_0.Size), 0, byte_0, 16, 4);
		Array.Copy(BitConverter.GetBytes(tableStyleElement_0.int_1), 0, byte_0, 20, 4);
	}
}
