using ns22;

namespace ns14;

internal class Class491 : Class489
{
	internal Class491(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	protected override double vmethod_3(double double_0)
	{
		if (double_0 == 0.0)
		{
			return 0.0;
		}
		return Class1024.smethod_0(double_0, class511_0.method_2());
	}

	protected override char[] vmethod_5(char[] char_2, int[] int_10, int[] int_11)
	{
		for (int i = 0; i < char_2.Length; i++)
		{
			if (char_2[i] == method_5())
			{
				int_10[1] = i;
				int_11[1] = 1;
				break;
			}
		}
		return char_2;
	}

	protected override void vmethod_6(char[] char_2, int int_10, int int_11, Class510 class510_0)
	{
		class511_0.method_5(-1);
		while (int_10 < int_11)
		{
			int_10 = method_7(char_2, int_10, int_11, class510_0);
		}
		if (class511_0.method_4() < 0)
		{
			class510_0.method_1(bool_0: true, class510_0.method_4().Length);
		}
		else
		{
			class510_0.method_1(bool_0: false, class511_0.method_4() + 1);
		}
	}
}
