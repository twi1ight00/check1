using System;
using ns226;
using ns230;

namespace ns232;

internal class Class6131
{
	private enum Enum781
	{
		const_0 = 0,
		const_1 = 4,
		const_2 = 8,
		const_3 = 12,
		const_4 = 16,
		const_5 = 18,
		const_6 = 20,
		const_7 = 28,
		const_8 = 36,
		const_9 = 38,
		const_10 = 40,
		const_11 = 42,
		const_12 = 44,
		const_13 = 46,
		const_14 = 48,
		const_15 = 50,
		const_16 = 52
	}

	private static int int_0 = 54;

	private Class6017 class6017_0;

	public Class6131()
	{
		class6017_0 = Class6017.smethod_1(int_0);
	}

	public void method_0(Class6031 src)
	{
		if (src == null)
		{
			throw new InvalidOperationException("source table must not be null");
		}
		((Class6016)src.method_0().vmethod_0(0, int_0)).CopyTo(class6017_0);
	}

	public Class6131 method_1(int fmt)
	{
		class6017_0.method_37(50, fmt);
		return this;
	}

	public Class6016 method_2()
	{
		return class6017_0;
	}
}
