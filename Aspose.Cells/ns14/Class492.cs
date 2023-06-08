using System;
using ns22;

namespace ns14;

internal class Class492 : Class489
{
	private int int_10;

	private int int_11;

	private bool bool_1;

	internal Class492(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	protected override double vmethod_3(double double_0)
	{
		if (double_0 == 0.0)
		{
			return 0.0;
		}
		bool flag = false;
		if (double_0 < 0.0)
		{
			flag = true;
			double_0 = 0.0 - double_0;
		}
		int num = (int)Math.Floor(Math.Log10(double_0));
		double num2 = Math.Pow(10.0, num);
		double_0 /= num2;
		double_0 += 5E-15;
		double_0 = Class1024.smethod_0(double_0, int_11);
		double_0 *= num2;
		if (!flag)
		{
			return double_0;
		}
		return 0.0 - double_0;
	}

	protected override char[] vmethod_5(char[] char_2, int[] int_12, int[] int_13)
	{
		int_12[1] = -1;
		int num = 0;
		while (true)
		{
			if (num < char_2.Length)
			{
				if (char_2[num] == method_5())
				{
					int_12[1] = num;
					int_13[1] = 1;
				}
				else if (char_2[num] == 'e' || char_2[num] == 'E')
				{
					break;
				}
				num++;
				continue;
			}
			if (int_12[1] < 0)
			{
				int_12[1] = char_2.Length;
				int_13[1] = 0;
			}
			int_12[2] = char_2.Length;
			int_13[2] = 0;
			return char_2;
		}
		if (int_12[1] < 0)
		{
			int_12[1] = num;
			int_13[1] = 0;
		}
		int_12[2] = num;
		if (num + 1 < char_2.Length)
		{
			if (char_2[num + 1] != '-' && char_2[num + 1] != '+')
			{
				if (bool_1)
				{
					char[] array = new char[char_2.Length + 1];
					Array.Copy(char_2, 0, array, 0, num + 1);
					array[num + 1] = '+';
					Array.Copy(char_2, num + 1, array, num + 2, char_2.Length - num - 1);
					char_2 = array;
					int_13[2] = 2;
					int_12[3] = char_2.Length;
				}
				else
				{
					int_13[2] = 1;
				}
			}
			else
			{
				int_13[2] = 2;
			}
		}
		return char_2;
	}

	protected override void vmethod_6(char[] char_2, int int_12, int int_13, Class510 class510_0)
	{
		bool_1 = true;
		int_11 = class511_0.method_2();
		class511_0.method_5(-1);
		class511_0.method_9(-1);
		while (int_12 < int_13)
		{
			char c = char_2[int_12];
			if (c != 'E' && c != 'e')
			{
				int_12 = method_7(char_2, int_12, int_13, class510_0);
			}
			else if (class511_0.method_8() < 0)
			{
				if (class511_0.method_4() < 0)
				{
					int_10 = class510_0.method_4().Length;
					class510_0.method_1(bool_0: true, int_10);
					class510_0.method_1(bool_0: true, int_10);
				}
				else
				{
					int_10 = class511_0.method_4();
					class510_0.method_1(bool_0: false, class511_0.method_4() + 1);
				}
				class511_0.method_9(class510_0.method_4().Length);
				class510_0.method_4().Append('E');
				bool flag = false;
				bool flag2 = true;
				int_12++;
				while (int_12 < int_13)
				{
					switch (char_2[int_12])
					{
					case '?':
						class510_0.method_2(bool_0: false);
						class510_0.method_0();
						class510_0.method_4().Append(flag ? '0' : '#');
						break;
					case '+':
						if (flag2)
						{
							flag2 = false;
							break;
						}
						int_12 = method_7(char_2, int_12, int_13, class510_0);
						continue;
					case '-':
						if (flag2)
						{
							flag2 = false;
							bool_1 = false;
							break;
						}
						int_12 = method_7(char_2, int_12, int_13, class510_0);
						continue;
					case '.':
						class510_0.method_3().Append(method_5());
						for (int_12++; int_12 < int_13; int_12 = ((char_2[int_12] != '#') ? vmethod_2(char_2, int_12, int_13, class510_0.method_3()) : (int_12 + 1)))
						{
						}
						continue;
					default:
						int_12 = method_7(char_2, int_12, int_13, class510_0);
						continue;
					case '0':
						class510_0.method_0();
						flag = true;
						class510_0.method_4().Append('0');
						break;
					case '#':
						class510_0.method_0();
						class510_0.method_4().Append(flag ? '0' : '#');
						break;
					}
					int_12++;
				}
			}
			else
			{
				class510_0.method_3().Append(char_2[int_12]);
				int_12++;
			}
		}
		class510_0.method_1(bool_0: true, class510_0.method_4().Length);
		for (int num = class510_0.method_4().Length - 1; num > class511_0.method_8(); num--)
		{
			if (class510_0.method_4()[num] == '#')
			{
				class510_0.method_4().Remove(num, 1);
			}
		}
		if (class511_0.method_8() + 1 == class510_0.method_4().Length)
		{
			class510_0.method_4().Append('0');
		}
	}
}
