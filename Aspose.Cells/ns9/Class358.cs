using System;
using Aspose.Cells;
using ns10;

namespace ns9;

internal class Class358 : Class316
{
	internal Class358()
	{
		int_0 = 171;
	}

	internal void method_6(DynamicFilter dynamicFilter_0)
	{
		byte_0 = new byte[21];
		Array.Copy(BitConverter.GetBytes(Class1224.smethod_18(dynamicFilter_0.DynamicFilterType)), 0, byte_0, 0, 4);
		if (dynamicFilter_0.MaxValue != null)
		{
			byte_0[4] = 1;
		}
		Array.Copy(BitConverter.GetBytes((double)dynamicFilter_0.Value), 0, byte_0, 5, 8);
		if (dynamicFilter_0.MaxValue != null)
		{
			Array.Copy(BitConverter.GetBytes((double)dynamicFilter_0.MaxValue), 0, byte_0, 13, 8);
		}
	}
}
