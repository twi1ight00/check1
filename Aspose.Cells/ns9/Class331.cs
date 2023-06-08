using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class331 : Class316
{
	internal Class331()
	{
		int_0 = 465;
	}

	internal void method_6(IconSet iconSet_0)
	{
		byte_0 = new byte[6];
		Array.Copy(BitConverter.GetBytes(Class1224.smethod_15(iconSet_0.Type)), 0, byte_0, 0, 4);
		if (!iconSet_0.ShowValue)
		{
			byte_0[4] |= 2;
		}
		if (iconSet_0.Reverse)
		{
			byte_0[4] |= 4;
		}
	}
}
