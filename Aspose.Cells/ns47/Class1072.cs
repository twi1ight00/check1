using System.Runtime.CompilerServices;

namespace ns47;

internal class Class1072
{
	private readonly int[] int_0;

	private readonly byte[] byte_0;

	private readonly int int_1;

	private readonly Class1073 class1073_0;

	private readonly short short_0;

	internal Class1072(Class1073 class1073_1)
	{
		class1073_0 = class1073_1;
		int_1 = class1073_0.method_1();
		short_0 = class1073_0.method_2();
		int_0 = class1073_0.method_3(short_0, int_1 + 1);
		byte_0 = class1073_0.method_4().method_5(int_0[int_1] - 1);
	}

	[SpecialName]
	internal byte[] method_0()
	{
		return byte_0;
	}
}
