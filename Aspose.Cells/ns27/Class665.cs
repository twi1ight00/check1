using System;
using Aspose.Cells;

namespace ns27;

internal class Class665 : Class538
{
	internal Class665()
	{
		method_2(65);
	}

	internal void method_4(PaneCollection paneCollection_0)
	{
		method_0(10);
		byte_0 = new byte[10];
		Array.Copy(BitConverter.GetBytes((ushort)paneCollection_0.method_6()), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)paneCollection_0.method_4()), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)paneCollection_0.Row), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)paneCollection_0.Column), 0, byte_0, 6, 2);
		byte_0[8] = paneCollection_0.method_0();
	}

	internal void method_5(PaneCollection paneCollection_0)
	{
		method_0(10);
		byte_0 = new byte[10];
		Array.Copy(BitConverter.GetBytes((ushort)paneCollection_0.method_6()), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)paneCollection_0.method_4()), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)paneCollection_0.Row), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)paneCollection_0.Column), 0, byte_0, 6, 2);
		byte_0[8] = paneCollection_0.method_0();
	}
}
