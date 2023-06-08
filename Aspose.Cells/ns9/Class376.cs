using Aspose.Cells;

namespace ns9;

internal class Class376 : Class316
{
	internal Class376(PageSetup pageSetup_0)
	{
		int_0 = 477;
		byte_0 = new byte[2];
		if (pageSetup_0.CenterHorizontally)
		{
			byte_0[0] |= 1;
		}
		if (pageSetup_0.CenterVertically)
		{
			byte_0[0] |= 2;
		}
		if (pageSetup_0.PrintHeadings)
		{
			byte_0[0] |= 4;
		}
		if (pageSetup_0.PrintGridlines)
		{
			byte_0[0] |= 24;
		}
	}
}
