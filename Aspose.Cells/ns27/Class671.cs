using Aspose.Cells;

namespace ns27;

internal class Class671 : Class538
{
	internal Class671(PrintSizeType printSizeType_0)
	{
		method_2(51);
		method_0(2);
		byte_0 = new byte[2];
		switch (printSizeType_0)
		{
		case PrintSizeType.Full:
			byte_0[0] = 3;
			break;
		case PrintSizeType.Fit:
			byte_0[0] = 2;
			break;
		case PrintSizeType.Custom:
			byte_0[0] = 1;
			break;
		}
	}
}
