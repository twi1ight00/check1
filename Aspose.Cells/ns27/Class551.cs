using System;
using System.Collections;
using Aspose.Cells;

namespace ns27;

internal class Class551 : Class538
{
	internal Class551()
	{
		method_2(146);
		method_0(226);
	}

	internal void method_4(Palette palette_0)
	{
		SortedList sortedList = palette_0.method_0();
		byte_0 = new byte[base.Length];
		byte_0[0] = 56;
		int num = 2;
		for (int i = 8; i < 64; i++)
		{
			Array.Copy(BitConverter.GetBytes((int)sortedList[i]), 0, byte_0, num, 4);
			num += 4;
		}
	}
}
