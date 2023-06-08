using System;
using Aspose.Cells.Tables;

namespace ns9;

internal class Class386 : Class316
{
	internal Class386(ListColumn listColumn_0)
	{
		int_0 = 351;
		int num = 0;
		if (listColumn_0.byte_0 != null)
		{
			num = listColumn_0.byte_0.Length;
		}
		byte_0 = new byte[5 + num + 4];
		if (listColumn_0.byte_0 != null)
		{
			Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 1, 4);
			Array.Copy(listColumn_0.byte_0, 0, byte_0, 5, num);
		}
	}
}
