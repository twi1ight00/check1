using System;
using Aspose.Cells;

namespace ns9;

internal class Class396 : Class316
{
	internal Class396()
	{
		int_0 = 573;
	}

	internal void method_6(ValidationCollection validationCollection_0)
	{
		byte_0 = new byte[18];
		Array.Copy(BitConverter.GetBytes(validationCollection_0.Count), 0, byte_0, 14, 4);
	}
}
