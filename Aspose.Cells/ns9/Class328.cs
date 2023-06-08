using Aspose.Cells;

namespace ns9;

internal class Class328 : Class316
{
	internal Class328(DataBar dataBar_0)
	{
		int_0 = 467;
		byte_0 = new byte[3];
		byte_0[0] = (byte)dataBar_0.MinLength;
		byte_0[1] = (byte)dataBar_0.MaxLength;
		if (dataBar_0.ShowValue)
		{
			byte_0[2] = 1;
		}
	}
}
