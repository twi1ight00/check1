using System;
using Aspose.Cells;

namespace ns9;

internal class Class351 : Class316
{
	internal Class351(PageSetup pageSetup_0)
	{
		int_0 = 652;
		byte_0 = new byte[24];
		ushort num = 0;
		if (pageSetup_0.method_13())
		{
			if (pageSetup_0.Orientation == PageOrientationType.Landscape)
			{
				num = (ushort)(num | 1u);
			}
			Array.Copy(BitConverter.GetBytes(pageSetup_0.method_9()), 0, byte_0, 0, 4);
			Array.Copy(BitConverter.GetBytes(pageSetup_0.method_15()), 0, byte_0, 4, 4);
			Array.Copy(BitConverter.GetBytes(pageSetup_0.method_17()), 0, byte_0, 8, 4);
			Array.Copy(BitConverter.GetBytes(pageSetup_0.PrintCopies), 0, byte_0, 12, 4);
		}
		if (!pageSetup_0.IsAutoFirstPageNumber)
		{
			Array.Copy(BitConverter.GetBytes((ushort)pageSetup_0.FirstPageNumber), 0, byte_0, 16, 2);
			num = (ushort)(num | 0x10u);
		}
		if (pageSetup_0.BlackAndWhite)
		{
			num = (ushort)(num | 4u);
		}
		if (pageSetup_0.PrintDraft)
		{
			num = (ushort)(num | 0x20u);
		}
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 18, 2);
		byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
		Array.Copy(sourceArray, 0, byte_0, 20, 4);
	}
}
