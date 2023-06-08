using System;
using Aspose.Cells;
using Aspose.Cells.Charts;
using ns7;

namespace ns27;

internal class Class693 : Class538
{
	internal Class693(FileFormatType fileFormatType_1, Class1387 class1387_0)
	{
		method_2(4123);
		fileFormatType_0 = fileFormatType_1;
		method_0(6);
		byte_0 = new byte[6];
		if (ChartCollection.smethod_11(class1387_0.method_11()))
		{
			byte_0[0] = 100;
			byte_0[2] = 1;
			return;
		}
		Array.Copy(BitConverter.GetBytes((ushort)class1387_0.BubbleScale), 0, byte_0, 0, 2);
		switch (class1387_0.SizeRepresents)
		{
		case BubbleSizeRepresents.SizeIsArea:
			byte_0[2] = 1;
			break;
		case BubbleSizeRepresents.SizeIsWidth:
			byte_0[2] = 2;
			break;
		}
		byte_0[4] = 1;
		if (class1387_0.ShowNegativeBubbles)
		{
			byte_0[4] |= 2;
		}
		if (class1387_0.method_22())
		{
			byte_0[4] |= 4;
		}
	}
}
