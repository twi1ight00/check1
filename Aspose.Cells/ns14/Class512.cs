using System;
using System.Globalization;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns14;

internal class Class512 : ICustomParser
{
	private StringBuilder stringBuilder_0 = new StringBuilder(50);

	private Class530 class530_0 = new Class530();

	private CultureInfo cultureInfo_0;

	private Class529 class529_0;

	private Class520 class520_0;

	private Interface4 interface4_0;

	internal Class512(CultureInfo cultureInfo_1, Class529 class529_1, Class520 class520_1)
	{
		cultureInfo_0 = cultureInfo_1;
		class529_0 = class529_1;
		class520_0 = class520_1;
		interface4_0 = class520_1.method_1();
		if (interface4_0 == null)
		{
			interface4_0 = new Class528(cultureInfo_1, class529_1);
		}
	}

	public object ParseObject(string value)
	{
		stringBuilder_0.Length = 0;
		class530_0.Reset();
		if (value != null && !(value == ""))
		{
			char[] array = value.ToCharArray();
			int num = 0;
			int num2 = array.Length;
			bool flag = false;
			bool flag2 = false;
			while (num < num2)
			{
				switch (array[num])
				{
				case '-':
					if (!flag2 && !flag)
					{
						flag = true;
						num++;
						continue;
					}
					return null;
				case '(':
					if (!flag2 && !flag && class520_0.method_3())
					{
						flag2 = true;
						stringBuilder_0.Append('(');
						num++;
						continue;
					}
					return null;
				case ' ':
					stringBuilder_0.Append(' ');
					num++;
					continue;
				}
				if (class530_0.method_5() != null)
				{
					break;
				}
				int num3 = interface4_0.imethod_3(array, num, bool_0: false);
				if (num3 <= 0)
				{
					break;
				}
				if (num + num3 < array.Length)
				{
					class530_0.method_4(new string(array, num, num3));
					stringBuilder_0.Append(array, num, num3);
					num += num3;
					continue;
				}
				return null;
			}
			bool flag3 = false;
			int num4 = -1;
			while (num2 > num)
			{
				switch (array[num2 - 1])
				{
				case ')':
					if (flag2 && !flag3)
					{
						num2--;
						continue;
					}
					return null;
				case ' ':
					num2--;
					continue;
				}
				if (num4 > -1 || class530_0.method_5() != null)
				{
					break;
				}
				int num3 = interface4_0.imethod_3(array, num2 - 1, bool_0: true);
				if (num3 > 0)
				{
					num2 -= num3;
					if (num2 > num)
					{
						class530_0.method_4(new string(array, num2, num3));
						continue;
					}
					return null;
				}
				num3 = interface4_0.imethod_2(array, num2 - 1, bool_0: true);
				if (num3 <= 0)
				{
					break;
				}
				num4 = num2;
				num2 -= num3;
				if (num2 > num)
				{
					class530_0.method_6(new string(array, num2, num3));
					continue;
				}
				return null;
			}
			if (num >= num2)
			{
				return null;
			}
			int length = stringBuilder_0.Length;
			bool flag4;
			if ((flag4 = array[num] == '0') && ++num < num2)
			{
				stringBuilder_0.Append('0');
				while (array[num] == '0')
				{
					stringBuilder_0.Append('0');
					num++;
					if (num == num2)
					{
						break;
					}
				}
			}
			double num5 = 0.0;
			bool flag5 = false;
			if (num < num2)
			{
				int num6 = -1;
				while (true)
				{
					if (array[num] < '0' || array[num] > '9')
					{
						int num3 = interface4_0.imethod_0(array, num);
						if (num3 > 0)
						{
							if (num6 > -1)
							{
								if (num - num6 != 4)
								{
									return null;
								}
								num6 = -1;
							}
							num += num3;
							if (stringBuilder_0.Length > length)
							{
								stringBuilder_0.Append('.');
							}
							else if (length > 0 || num2 < array.Length || num == num2 || (!flag4 && num5 < 0.1))
							{
								stringBuilder_0.Append("#.");
							}
							break;
						}
						if (!flag4 && !(num5 >= 0.1))
						{
							return null;
						}
						num3 = interface4_0.imethod_1(array, num);
						if (num3 <= 0)
						{
							if (num6 > -1)
							{
								if (num - num6 != 4)
								{
									return null;
								}
								num6 = -1;
							}
							char c = array[num];
							if (c != 'E' && c != 'e')
							{
								return null;
							}
							if (stringBuilder_0.Length == length)
							{
								stringBuilder_0.Append("#");
							}
							num5 = method_1(array, num, num2, num5);
							if (stringBuilder_0.Length == 0)
							{
								return null;
							}
							flag5 = true;
							num = num2;
							break;
						}
						if (num6 < 0)
						{
							if (!flag4 && (stringBuilder_0.Length < 1 || stringBuilder_0[stringBuilder_0.Length - 1] != '#'))
							{
								stringBuilder_0.Append('#');
							}
							stringBuilder_0.Append(',');
							if (flag4)
							{
								stringBuilder_0.Append("000");
							}
							else
							{
								stringBuilder_0.Append("###");
							}
						}
						else
						{
							if (num - num6 != 4)
							{
								return null;
							}
							if (flag4)
							{
								stringBuilder_0.Append(",000");
							}
						}
						num6 = num;
						num += num3;
						if (num >= num2)
						{
							break;
						}
					}
					else
					{
						num5 = num5 * 10.0 + (double)(array[num] - 48);
						if (flag4 && num6 < 0)
						{
							stringBuilder_0.Append('0');
						}
						num++;
						if (num >= num2)
						{
							break;
						}
					}
				}
				if (num6 > -1 && num - num6 != 4)
				{
					return null;
				}
				if (num >= num2)
				{
					if (!flag4 && !flag5 && num5 < 0.1)
					{
						return null;
					}
				}
				else
				{
					int num7 = num;
					double num8 = 0.0;
					do
					{
						if (array[num] >= '0' && array[num] <= '9')
						{
							num8 = num8 * 10.0 + (double)(array[num] - 48);
							num++;
							continue;
						}
						if (!flag4 && num5 < 0.1 && num7 == num)
						{
							return null;
						}
						char c2 = array[num];
						if (c2 != 'E' && c2 != 'e')
						{
							return null;
						}
						if (stringBuilder_0.Length == length)
						{
							stringBuilder_0.Append("#.");
						}
						char value2 = ((array[num - 1] == '0') ? '0' : '#');
						for (int num9 = num - num7; num9 > 0; num9--)
						{
							stringBuilder_0.Append(value2);
						}
						num5 += num8 / Math.Pow(10.0, num - num7);
						num5 = method_1(array, num, num2, num5);
						if (stringBuilder_0.Length == 0)
						{
							return null;
						}
						flag5 = true;
						num = num2;
						break;
					}
					while (num < num2);
					if (!flag5)
					{
						num5 += num8 / Math.Pow(10.0, num - num7);
						if (stringBuilder_0.Length > 0 || array[num - 1] == '0')
						{
							if (stringBuilder_0.Length == length)
							{
								stringBuilder_0.Append("#.");
							}
							char value3 = ((array[num - 1] == '0') ? '0' : '#');
							for (int num10 = num - num7; num10 > 0; num10--)
							{
								stringBuilder_0.Append(value3);
							}
						}
					}
				}
			}
			if (num2 < array.Length)
			{
				if (stringBuilder_0.Length == length)
				{
					stringBuilder_0.Append('0');
				}
				num = num2;
				num2 = array.Length;
				if (num4 > -1)
				{
					num5 /= 100.0;
					if (flag5)
					{
						num2 = num4 - class530_0.method_7().Length;
					}
				}
				for (; num < num2; num++)
				{
					stringBuilder_0.Append(array[num]);
				}
				if (num2 < array.Length && num4 < array.Length)
				{
					num = num4;
					for (num2 = array.Length; num < num2; num++)
					{
						stringBuilder_0.Append(array[num]);
					}
				}
			}
			if (stringBuilder_0.Length > 0)
			{
				if (stringBuilder_0.Length == length)
				{
					stringBuilder_0.Append('0');
				}
				class530_0.method_2(stringBuilder_0.ToString());
				if (flag2)
				{
					stringBuilder_0.Replace("(", "");
					stringBuilder_0.Replace(")", "");
					stringBuilder_0.Append(";");
					stringBuilder_0.Append(class530_0.method_3());
					class530_0.method_2(stringBuilder_0.ToString());
				}
			}
			if (flag || flag2)
			{
				num5 = 0.0 - num5;
			}
			class530_0.method_0(CellValueType.IsNumeric, num5);
			return num5;
		}
		return null;
	}

	internal Class530 method_0()
	{
		return class530_0;
	}

	private double method_1(char[] char_0, int int_0, int int_1, double double_0)
	{
		stringBuilder_0.Append("E+");
		int_0++;
		if (int_0 == int_1)
		{
			stringBuilder_0.Length = 0;
			return double_0;
		}
		bool flag = double_0 == 0.0;
		bool flag2 = false;
		switch (char_0[int_0])
		{
		case '+':
		case '-':
			flag2 = char_0[int_0] == '-';
			int_0++;
			if (int_0 == int_1)
			{
				stringBuilder_0.Length = 0;
				return double_0;
			}
			break;
		}
		bool flag3 = char_0[int_0] == '0';
		int num = 0;
		int num2 = -1;
		int num3 = 0;
		while (true)
		{
			if (int_0 < int_1)
			{
				if (char_0[int_0] < '0' || char_0[int_0] > '9')
				{
					break;
				}
				if (flag3)
				{
					stringBuilder_0.Append('0');
				}
				num = num * 10 + (char_0[int_0] - 48);
				if (num2 < 0)
				{
					if (flag)
					{
						num2 = (flag2 ? 307 : 309);
					}
					else
					{
						num3 = (int)Math.Floor(Math.Log10(double_0));
						num2 = (flag2 ? (309 + num3) : (307 - num3));
					}
				}
				if (num <= num2)
				{
					int_0++;
					continue;
				}
				stringBuilder_0.Length = 0;
				return double_0;
			}
			if (!flag3)
			{
				stringBuilder_0.Append("0");
			}
			if (flag)
			{
				return double_0;
			}
			if (flag2)
			{
				if (num > 309)
				{
					return double_0 / Math.Pow(10.0, num3) * Math.Pow(10.0, num3 - num);
				}
			}
			else if (num > 307)
			{
				return double_0 / Math.Pow(10.0, num3) * Math.Pow(10.0, num3 + num);
			}
			return double_0 * Math.Pow(10.0, flag2 ? (-num) : num);
		}
		stringBuilder_0.Length = 0;
		return double_0;
	}

	public string GetFormat()
	{
		return class530_0.method_3();
	}
}
