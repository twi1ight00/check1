using System;

namespace ns14;

internal class Class490 : Class489
{
	internal Class490(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	protected override double vmethod_3(double double_0)
	{
		return Math.Round(double_0);
	}

	protected override char[] vmethod_5(char[] char_2, int[] int_10, int[] int_11)
	{
		return char_2;
	}

	protected override void vmethod_6(char[] char_2, int int_10, int int_11, Class510 class510_0)
	{
		class511_0.method_5(-1);
		while (int_10 < int_11)
		{
			int_10 = method_7(char_2, int_10, int_11, class510_0);
		}
		class510_0.method_1(bool_0: false, 0);
	}
}
