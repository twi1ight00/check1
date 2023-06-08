using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class369 : Class316
{
	internal Class369()
	{
		int_0 = 169;
	}

	internal void method_6(IconFilter iconFilter_0)
	{
		byte_0 = new byte[8];
		Array.Copy(BitConverter.GetBytes(Class1224.smethod_15(iconFilter_0.IconSetType)), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(iconFilter_0.IconId), 0, byte_0, 4, 4);
	}
}
