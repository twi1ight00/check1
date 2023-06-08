using System;
using Aspose.Cells;

namespace ns27;

internal class Class628 : Class538
{
	internal Class628()
	{
		method_2(434);
		method_0(18);
		byte_0 = new byte[18];
		byte_0[0] = 4;
		for (int i = 10; i < 14; i++)
		{
			byte_0[i] = byte.MaxValue;
		}
	}

	internal bool method_4(ValidationCollection validationCollection_0)
	{
		int num = 0;
		for (int i = 0; i < validationCollection_0.Count; i++)
		{
			Validation validation = validationCollection_0[i];
			if (validation.method_0())
			{
				continue;
			}
			for (int j = 0; j < validation.AreaList.Count; j++)
			{
				object obj = validation.AreaList[j];
				if (obj is CellArea)
				{
					num++;
					break;
				}
			}
		}
		Array.Copy(BitConverter.GetBytes(validationCollection_0.method_6()), 0, byte_0, 10, 4);
		if (num == 0)
		{
			return false;
		}
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 14, 4);
		return true;
	}
}
