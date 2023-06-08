using System;
using Aspose.Cells.Tables;
using ns10;

namespace ns9;

internal class Class339 : Class316
{
	internal Class339(TableStyleCollection tableStyleCollection_0)
	{
		int_0 = 508;
		int num = 4;
		num = ((tableStyleCollection_0.method_2() == null) ? (num + 4) : (num + (4 + tableStyleCollection_0.method_2().Length * 2)));
		byte_0 = new byte[(tableStyleCollection_0.method_0() == null) ? (num + 4) : (num + (4 + tableStyleCollection_0.method_0().Length * 2))];
		byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
		Array.Copy(BitConverter.GetBytes(tableStyleCollection_0.Count), 0, byte_0, 0, 4);
		int num2 = 4;
		if (tableStyleCollection_0.method_0() != null)
		{
			Class1217.smethod_7(byte_0, ref num2, tableStyleCollection_0.method_0());
		}
		else
		{
			Array.Copy(sourceArray, 0, byte_0, num2, 4);
			num2 += 4;
		}
		if (tableStyleCollection_0.method_2() != null)
		{
			Class1217.smethod_7(byte_0, ref num2, tableStyleCollection_0.method_2());
			return;
		}
		Array.Copy(sourceArray, 0, byte_0, num2, 4);
		num2 += 4;
	}
}
