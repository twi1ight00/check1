using System;
using Aspose.Cells;
using ns10;
using ns16;

namespace ns9;

internal class Class365 : Class316
{
	protected Workbook workbook_0;

	internal Class365(Workbook workbook_1)
	{
		int_0 = 45;
		workbook_0 = workbook_1;
	}

	internal void method_6(Class1535 class1535_0)
	{
		byte_0 = new byte[68];
		Array.Copy(BitConverter.GetBytes(Class1224.smethod_12(Class1618.smethod_34(class1535_0.class1561_0.string_0))), 0, byte_0, 0, 4);
		if (Class1618.smethod_34(class1535_0.class1561_0.string_0) != 0)
		{
			method_4(byte_0, 4, class1535_0.class1561_0.internalColor_0, 64, workbook_0);
			if (Class1618.smethod_34(class1535_0.class1561_0.string_0) != BackgroundType.Solid)
			{
				method_4(byte_0, 12, class1535_0.class1561_0.internalColor_1, 64, workbook_0);
			}
		}
	}
}
