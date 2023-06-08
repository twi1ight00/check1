using System;
using Aspose.Cells.Tables;

namespace ns9;

internal class Class390 : Class316
{
	internal Class390(ListColumn listColumn_0)
	{
		int_0 = 352;
		int num = 0;
		if (listColumn_0.byte_1 != null)
		{
			num = listColumn_0.byte_1.Length;
		}
		byte_0 = new byte[5 + num + 4];
		if (listColumn_0.byte_1 != null)
		{
			Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 1, 4);
			Array.Copy(listColumn_0.byte_1, 0, byte_0, 5, num);
		}
	}
}
