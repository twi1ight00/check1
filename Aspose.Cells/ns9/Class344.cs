using System;
using Aspose.Cells;
using ns2;

namespace ns9;

internal class Class344 : Class316
{
	internal Class344(WorksheetCollection worksheetCollection_0)
	{
		int_0 = 362;
		int num = 0;
		int count = worksheetCollection_0.method_32().Count;
		byte_0 = new byte[4 + count * 12];
		Array.Copy(BitConverter.GetBytes(count), 0, byte_0, 0, 4);
		num = 0 + 4;
		for (int i = 0; i < count; i++)
		{
			Class1246 @class = worksheetCollection_0.method_32()[i];
			Array.Copy(BitConverter.GetBytes((int)(short)@class.ushort_0), 0, byte_0, num, 4);
			num += 4;
			Array.Copy(BitConverter.GetBytes((int)(short)@class.ushort_1), 0, byte_0, num, 4);
			num += 4;
			Array.Copy(BitConverter.GetBytes((int)(short)@class.ushort_2), 0, byte_0, num, 4);
			num += 4;
		}
	}
}
