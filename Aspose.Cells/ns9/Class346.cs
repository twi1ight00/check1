using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class346 : Class316
{
	internal Class346(ConditionalFormattingValue conditionalFormattingValue_0)
	{
		int_0 = 471;
		byte[] array = null;
		if (conditionalFormattingValue_0.IsFormula)
		{
			array = conditionalFormattingValue_0.method_6();
		}
		if (array != null)
		{
			byte_0 = new byte[24 + array.Length];
		}
		else
		{
			byte_0 = new byte[24];
		}
		Array.Copy(BitConverter.GetBytes(Class1224.smethod_25(conditionalFormattingValue_0.Type)), 0, byte_0, 0, 4);
		double value = conditionalFormattingValue_0.method_5();
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 4, 8);
		if (conditionalFormattingValue_0.IsGTE)
		{
			byte_0[12] = 1;
			byte_0[16] = 1;
		}
		if (array != null)
		{
			Array.Copy(BitConverter.GetBytes(array.Length), 0, byte_0, 20, 4);
			Array.Copy(array, 0, byte_0, 24, array.Length);
		}
	}
}
