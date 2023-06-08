using System;
using Aspose.Cells;

namespace ns9;

internal class Class372 : Class316
{
	internal Class372(PageSetup pageSetup_0)
	{
		int_0 = 476;
		byte_0 = new byte[48];
		Array.Copy(BitConverter.GetBytes(pageSetup_0.LeftMarginInch), 0, byte_0, 0, 8);
		Array.Copy(BitConverter.GetBytes(pageSetup_0.RightMarginInch), 0, byte_0, 8, 8);
		Array.Copy(BitConverter.GetBytes(pageSetup_0.TopMarginInch), 0, byte_0, 16, 8);
		Array.Copy(BitConverter.GetBytes(pageSetup_0.BottomMarginInch), 0, byte_0, 24, 8);
		Array.Copy(BitConverter.GetBytes(pageSetup_0.HeaderMarginInch), 0, byte_0, 32, 8);
		Array.Copy(BitConverter.GetBytes(pageSetup_0.FooterMarginInch), 0, byte_0, 40, 8);
	}
}
