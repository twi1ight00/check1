using Aspose.Cells;

namespace ns2;

internal class Class1381
{
	public int[] int_0 = new int[4] { -1, -1, -1, -1 };

	public Worksheet worksheet_0;

	public Class1381(Worksheet worksheet_1, int int_1, int int_2, int int_3, int int_4)
	{
		int_0[0] = int_1;
		int_0[1] = int_2;
		int_0[2] = int_3;
		int_0[3] = int_4;
		worksheet_0 = worksheet_1;
	}

	public bool method_0(Worksheet worksheet_1, int int_1, int int_2)
	{
		if (worksheet_0 == worksheet_1 && int_2 >= int_0[0] && int_2 <= int_0[2] && int_1 >= int_0[1] && int_1 <= int_0[3])
		{
			return true;
		}
		return false;
	}
}
