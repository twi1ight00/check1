using System;
using Aspose.Cells;

namespace ns9;

internal class Class375 : Class316
{
	internal Class375(PageSetup pageSetup_0)
	{
		int_0 = 478;
		byte_0 = new byte[38];
		ushort num = 0;
		if (pageSetup_0.method_13())
		{
			if (pageSetup_0.Orientation == PageOrientationType.Landscape)
			{
				num = (ushort)(num | 2u);
			}
			Array.Copy(BitConverter.GetBytes(pageSetup_0.method_9()), 0, byte_0, 0, 4);
			Array.Copy(BitConverter.GetBytes(pageSetup_0.Zoom), 0, byte_0, 4, 4);
			Array.Copy(BitConverter.GetBytes(pageSetup_0.method_15()), 0, byte_0, 8, 4);
			Array.Copy(BitConverter.GetBytes(pageSetup_0.method_17()), 0, byte_0, 12, 4);
			Array.Copy(BitConverter.GetBytes(pageSetup_0.PrintCopies), 0, byte_0, 16, 4);
		}
		else
		{
			num = (ushort)(num | 4u);
		}
		if (!pageSetup_0.IsAutoFirstPageNumber)
		{
			Array.Copy(BitConverter.GetBytes(pageSetup_0.FirstPageNumber), 0, byte_0, 20, 4);
			num = (ushort)(num | 0x80u);
		}
		Array.Copy(BitConverter.GetBytes(pageSetup_0.FitToPagesWide), 0, byte_0, 24, 4);
		Array.Copy(BitConverter.GetBytes(pageSetup_0.FitToPagesTall), 0, byte_0, 28, 4);
		if (pageSetup_0.Order == PrintOrderType.OverThenDown)
		{
			num = (ushort)(num | 1u);
		}
		if (pageSetup_0.BlackAndWhite)
		{
			num = (ushort)(num | 8u);
		}
		if (pageSetup_0.PrintDraft)
		{
			num = (ushort)(num | 0x10u);
		}
		if (pageSetup_0.PrintComments != PrintCommentsType.PrintNoComments)
		{
			num = (ushort)(num | 0x20u);
			if (pageSetup_0.PrintComments == PrintCommentsType.PrintSheetEnd)
			{
				num = (ushort)(num | 0x100u);
			}
		}
		switch (pageSetup_0.PrintErrors)
		{
		case PrintErrorsType.PrintErrorsBlank:
			num = (ushort)(num | 0x100u);
			break;
		case PrintErrorsType.PrintErrorsDash:
			num = (ushort)(num | 0x200u);
			break;
		case PrintErrorsType.PrintErrorsNA:
			num = (ushort)(num | 0x300u);
			break;
		}
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 32, 2);
		byte[] sourceArray = new byte[4] { 255, 255, 255, 255 };
		Array.Copy(sourceArray, 0, byte_0, 34, 4);
	}
}
