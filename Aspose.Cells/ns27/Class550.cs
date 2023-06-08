using System;
using Aspose.Cells;

namespace ns27;

internal class Class550 : Class538
{
	internal Class550()
	{
		method_2(2152);
	}

	internal void method_4(ErrorCheckOption errorCheckOption_0)
	{
		method_0((short)(errorCheckOption_0.arrayList_0.Count * 8 + 31));
		byte_0 = new byte[base.Length];
		int num = 0;
		byte_0[0] = 104;
		byte_0[0 + 1] = 8;
		num = 0 + 12;
		byte_0[12] = 3;
		num = 12 + 7;
		Array.Copy(BitConverter.GetBytes(errorCheckOption_0.arrayList_0.Count), 0, byte_0, 19, 2);
		num = 19 + 2;
		byte_0[21] = 4;
		num = 21 + 6;
		foreach (CellArea item in errorCheckOption_0.arrayList_0)
		{
			Array.Copy(BitConverter.GetBytes(item.StartRow), 0, byte_0, num, 2);
			Array.Copy(BitConverter.GetBytes(item.EndRow), 0, byte_0, num + 2, 2);
			Array.Copy(BitConverter.GetBytes(item.StartColumn), 0, byte_0, num + 4, 2);
			Array.Copy(BitConverter.GetBytes(item.EndColumn), 0, byte_0, num + 6, 2);
			num += 8;
		}
		Array.Copy(BitConverter.GetBytes(errorCheckOption_0.int_0), 0, byte_0, num, 2);
		num += 4;
	}
}
