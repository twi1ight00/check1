using System;
using Aspose.Cells;

namespace ns9;

internal class Class343 : Class316
{
	internal Class343()
	{
		int_0 = 396;
	}

	internal void method_6(HorizontalPageBreak horizontalPageBreak_0)
	{
		byte_0 = new byte[20];
		Array.Copy(BitConverter.GetBytes(horizontalPageBreak_0.Row), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(horizontalPageBreak_0.StartColumn), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(horizontalPageBreak_0.EndColumn), 0, byte_0, 8, 4);
		byte_0[12] = 1;
	}

	internal void method_7(VerticalPageBreak verticalPageBreak_0)
	{
		byte_0 = new byte[20];
		Array.Copy(BitConverter.GetBytes(verticalPageBreak_0.Column), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(verticalPageBreak_0.StartRow), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(verticalPageBreak_0.EndRow), 0, byte_0, 8, 4);
		byte_0[12] = 1;
	}
}
