using System;
using Aspose.Cells;

namespace ns9;

internal class Class353 : Class316
{
	internal Class353(Protection protection_0)
	{
		int_0 = 669;
		byte_0 = new byte[10];
		Array.Copy(BitConverter.GetBytes(protection_0.method_2()), 0, byte_0, 0, 2);
		if (!protection_0.AllowEditingContent)
		{
			byte_0[2] = 1;
		}
		if (!protection_0.AllowEditingObject)
		{
			byte_0[6] = 1;
		}
	}
}
