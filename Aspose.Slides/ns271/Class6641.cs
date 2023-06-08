namespace ns271;

internal class Class6641
{
	private readonly int[] int_0;

	private readonly byte[] byte_0;

	private readonly int int_1;

	private readonly Class6642 class6642_0;

	private readonly short short_0;

	internal byte[] DataArray => byte_0;

	internal Class6641(Class6642 reader)
	{
		class6642_0 = reader;
		int_1 = class6642_0.method_1();
		short_0 = class6642_0.method_2();
		int_0 = class6642_0.method_3(short_0, int_1 + 1);
		byte_0 = class6642_0.BaseReader.method_8(int_0[int_1] - 1);
	}
}
