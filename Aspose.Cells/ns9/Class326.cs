using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class326 : Class316
{
	internal Class326()
	{
		int_0 = 461;
	}

	internal void method_6(FormatConditionCollection formatConditionCollection_0)
	{
		int num = 12 + formatConditionCollection_0.arrayList_1.Count * 16;
		byte_0 = new byte[num];
		Array.Copy(BitConverter.GetBytes(formatConditionCollection_0.Count), 0, byte_0, 0, 4);
		Class1217.smethod_3(formatConditionCollection_0.arrayList_1, byte_0, 8);
	}
}
