using System;
using System.Text;
using ns2;

namespace ns14;

internal class Class493 : Class488
{
	private Class488 class488_0;

	private Class488 class488_1;

	private Class488 class488_2;

	private Class487 class487_0;

	private int int_0;

	internal Class493(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	protected override void vmethod_0(char[] char_0, int int_1, int int_2)
	{
		StringBuilder stringBuilder = new StringBuilder(int_2 - int_1);
		method_4(char_0, int_1, int_2, stringBuilder);
		char_0 = stringBuilder.ToString().ToCharArray();
		int_1 = 0;
		int_2 = char_0.Length;
		stringBuilder.Length = 0;
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		bool flag = false;
		bool flag2 = false;
		while (int_1 < int_2)
		{
			switch (char_0[int_1])
			{
			default:
				int_1 = Class487.smethod_1(char_0, int_1, int_2);
				break;
			case '?':
				if (num3 > 0 && num3 < int_1)
				{
					num = num3;
				}
				flag = true;
				int_1++;
				num3 = int_1;
				break;
			case '/':
			{
				num2 = int_1;
				if (num < 0)
				{
					flag = false;
					int_1 = int_2;
					break;
				}
				if (flag)
				{
					flag2 = true;
					int_1 = int_2;
					break;
				}
				int_1++;
				num3 = -1;
				bool flag3 = true;
				while (int_1 < int_2)
				{
					switch (char_0[int_1])
					{
					case '?':
						flag2 = true;
						int_1++;
						num3 = int_1;
						continue;
					case '#':
					case '0':
						int_1++;
						num3 = int_1;
						if (!flag2)
						{
							flag3 = false;
						}
						continue;
					}
					if (num3 > -1)
					{
						if (char_0[int_1] > '0' && char_0[int_1] <= '9')
						{
							int_1++;
							num3 = int_1;
						}
						else
						{
							int_1 = int_2;
						}
					}
					else
					{
						int_1 = Class487.smethod_1(char_0, int_1, int_2);
					}
				}
				if (flag2 && flag3)
				{
					flag = true;
				}
				break;
			}
			case '#':
			case '0':
				if (num3 > 0 && num3 < int_1)
				{
					num = num3;
					flag = false;
				}
				int_1++;
				num3 = int_1;
				break;
			}
		}
		bool flag4 = true;
		bool flag5 = false;
		StringBuilder stringBuilder2 = null;
		bool flag6 = true;
		num3 = -1;
		int_1 = 0;
		if (num > -1)
		{
			stringBuilder.Length = 0;
			while (int_1 < num)
			{
				switch (char_0[int_1])
				{
				case '0':
					if (num3 > -1 && num3 < int_1)
					{
						flag4 = false;
					}
					flag5 = true;
					stringBuilder.Append('0');
					num3 = int_1 + 1;
					break;
				case '#':
					if (num3 > -1 && num3 < int_1)
					{
						flag4 = false;
					}
					stringBuilder.Append(flag5 ? '0' : '#');
					num3 = int_1 + 1;
					break;
				default:
					int_1 = vmethod_2(char_0, int_1, int_2, stringBuilder);
					continue;
				case '*':
				case '_':
					flag4 = false;
					stringBuilder.Append(char_0[int_1]);
					int_1++;
					if (int_1 < int_2)
					{
						stringBuilder.Append(char_0[int_1]);
						int_1++;
					}
					continue;
				case '[':
					int_1 = class509_0.method_3(char_0, int_1, int_2, stringBuilder, bool_0: false);
					continue;
				case '?':
					stringBuilder.Append('?');
					flag4 = false;
					num3 = int_1 + 1;
					break;
				}
				int_1++;
			}
			if (flag2)
			{
				stringBuilder2 = new StringBuilder(char_0.Length);
				stringBuilder2.Append(stringBuilder.ToString());
				if (!flag5)
				{
					stringBuilder2[num - 1] = '0';
				}
				stringBuilder2.Append(' ');
				flag6 = flag4;
			}
			else if (!flag5)
			{
				stringBuilder[num - 1] = '0';
			}
			if (flag4)
			{
				class488_0 = new Class494(class509_0, stringBuilder.ToString());
			}
			else
			{
				Class491 @class = new Class491(class509_0, stringBuilder.ToString());
				class488_0 = @class;
			}
		}
		flag4 = true;
		flag5 = false;
		stringBuilder.Length = 0;
		num3 = -1;
		while (int_1 < num2)
		{
			switch (char_0[int_1])
			{
			case '0':
				flag5 = true;
				stringBuilder.Append('0');
				if (flag)
				{
					flag6 = false;
					stringBuilder2.Append("_0");
				}
				break;
			case '#':
				if (flag5)
				{
					stringBuilder.Append('0');
				}
				else
				{
					num3 = -stringBuilder.Length - 2;
				}
				break;
			default:
				if (flag)
				{
					flag6 = false;
					method_5(char_0, int_1, int_2, stringBuilder2);
				}
				int_1 = vmethod_2(char_0, int_1, int_2, stringBuilder);
				continue;
			case '*':
			case '_':
				flag4 = false;
				stringBuilder.Append(char_0[int_1]);
				if (flag)
				{
					flag6 = false;
					stringBuilder2.Append(char_0[int_1]);
				}
				int_1++;
				if (int_1 < int_2)
				{
					stringBuilder.Append(char_0[int_1]);
					if (flag)
					{
						stringBuilder2.Append(char_0[int_1]);
					}
					int_1++;
				}
				continue;
			case '[':
				int_1 = class509_0.method_3(char_0, int_1, int_2, stringBuilder, bool_0: false);
				continue;
			case '?':
				stringBuilder.Append('?');
				flag4 = false;
				if (flag)
				{
					stringBuilder2.Append(' ');
				}
				num3 = stringBuilder.Length;
				break;
			}
			int_1++;
		}
		if (!flag5)
		{
			if (num3 > 0)
			{
				stringBuilder[num3 - 1] = '0';
			}
			else if (num3 < -1)
			{
				stringBuilder.Insert(-num3 - 2, '0');
			}
		}
		if (flag4)
		{
			class488_2 = new Class494(class509_0, stringBuilder.ToString());
		}
		else
		{
			Class491 class2 = new Class491(class509_0, stringBuilder.ToString());
			class488_2 = class2;
		}
		if (flag)
		{
			stringBuilder2.Append("_/");
		}
		flag4 = true;
		flag5 = false;
		stringBuilder.Length = 0;
		num3 = -1;
		int_0 = 0;
		int num4 = 0;
		int_1++;
		while (int_1 < int_2)
		{
			switch (char_0[int_1])
			{
			case '0':
				if (num3 > -1 && num3 < int_1)
				{
					stringBuilder.Append("\\0");
				}
				else
				{
					flag5 = true;
					stringBuilder.Append('0');
					num4++;
					if (int_0 > 0)
					{
						int_0 *= 10;
					}
					num3 = int_1 + 1;
				}
				if (flag2)
				{
					flag6 = false;
					stringBuilder2.Append("_0");
				}
				break;
			case '#':
				if (num3 > -1 && num3 < int_1)
				{
					stringBuilder.Append("\\0");
					break;
				}
				stringBuilder.Append(flag5 ? '0' : '#');
				num4++;
				num3 = int_1 + 1;
				break;
			default:
				if ((num3 < 0 || num3 == int_1) && char_0[int_1] > '0' && char_0[int_1] <= '9')
				{
					if (int_0 <= 0)
					{
						int_0 = char_0[int_1] - 48;
					}
					else
					{
						int_0 = int_0 * 10 + (char_0[int_1] - 48);
					}
					stringBuilder.Append(char_0[int_1]);
					num3 = int_1 + 1;
					break;
				}
				if (flag2 && num3 > -1)
				{
					flag6 = false;
					method_5(char_0, int_1, int_2, stringBuilder2);
				}
				int_1 = vmethod_2(char_0, int_1, int_2, stringBuilder);
				continue;
			case '*':
			case '_':
				flag4 = false;
				stringBuilder.Append(char_0[int_1]);
				if (flag2)
				{
					flag6 = false;
					stringBuilder2.Append(char_0[int_1]);
				}
				int_1++;
				if (int_1 < int_2)
				{
					stringBuilder.Append(char_0[int_1]);
					if (flag2)
					{
						stringBuilder2.Append(char_0[int_1]);
					}
					int_1++;
				}
				continue;
			case '[':
				int_1 = class509_0.method_3(char_0, int_1, int_2, stringBuilder, bool_0: false);
				continue;
			case '?':
				if (num3 > -1 && num3 < int_1)
				{
					stringBuilder.Append("\\0");
					break;
				}
				stringBuilder.Append('?');
				num4++;
				flag4 = false;
				if (flag2)
				{
					stringBuilder2.Append(' ');
				}
				num3 = int_1 + 1;
				break;
			}
			int_1++;
		}
		if (int_0 == 0)
		{
			if (flag4)
			{
				class487_0 = new Class494(class509_0, stringBuilder.ToString());
			}
			else
			{
				class487_0 = new Class490(class509_0, stringBuilder.ToString());
			}
			stringBuilder.Length = 0;
		}
		else
		{
			class487_0 = new Class505(class509_0, stringBuilder.ToString());
		}
		if (int_0 == 0)
		{
			int_0 = -num4;
		}
		if (flag2)
		{
			if (flag6)
			{
				class488_1 = new Class494(class509_0, stringBuilder2.ToString());
				return;
			}
			Class491 class3 = new Class491(class509_0, stringBuilder2.ToString());
			class488_1 = class3;
		}
		else if (class488_0 != null)
		{
			class488_1 = class488_0;
		}
	}

	private void method_5(char[] char_0, int int_1, int int_2, StringBuilder stringBuilder_0)
	{
		switch (char_0[int_1])
		{
		default:
			stringBuilder_0.Append('_');
			stringBuilder_0.Append(char_0[int_1]);
			int_1++;
			break;
		case '\\':
			stringBuilder_0.Append('_');
			int_1++;
			if (int_1 < int_2)
			{
				stringBuilder_0.Append(char_0[int_1]);
				int_1++;
			}
			break;
		case '"':
			int_1++;
			while (true)
			{
				if (int_1 < int_2)
				{
					if (char_0[int_1] == '"')
					{
						break;
					}
					stringBuilder_0.Append('_');
					stringBuilder_0.Append(char_0[int_1]);
					int_1++;
					continue;
				}
				return;
			}
			int_1++;
			break;
		}
	}

	protected override double vmethod_3(double double_0)
	{
		if (double_0 == 0.0)
		{
			return 0.0;
		}
		bool flag;
		if (flag = double_0 < 0.0)
		{
			double_0 = 0.0 - double_0;
		}
		int num = ((int_0 <= 0) ? method_7(double_0 - Math.Floor(double_0)) : int_0);
		double_0 = Math.Floor(double_0 * (double)num + 0.5) / (double)num;
		if (!flag)
		{
			return double_0;
		}
		return 0.0 - double_0;
	}

	internal override void vmethod_4(Class515 class515_0, double double_0, Class518 class518_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		bool flag;
		if (flag = double_0 < 0.0)
		{
			double_0 = 0.0 - double_0;
		}
		double num = Math.Floor(double_0);
		if (class488_0 != null)
		{
			double_0 -= num;
			if (double_0 == 0.0)
			{
				method_6(class515_0, flag ? (0.0 - num) : num, class518_1, stringBuilder);
				return;
			}
		}
		double num2;
		int num4;
		if (int_0 > 0)
		{
			num2 = double_0 * (double)int_0;
			if (num2 >= 32767.5)
			{
				class518_1.method_3(class515_0.method_2());
				return;
			}
			if (class488_0 != null)
			{
				int num3 = (int)(num2 + 0.5);
				if (num3 == 0)
				{
					method_6(class515_0, flag ? (0.0 - num) : num, class518_1, stringBuilder);
					return;
				}
				if (num3 == int_0)
				{
					method_6(class515_0, flag ? (0.0 - num - 1.0) : (num + 1.0), class518_1, stringBuilder);
					return;
				}
			}
			num4 = int_0;
		}
		else
		{
			if (double_0 == 0.0)
			{
				num2 = 0.0;
				num4 = 1;
			}
			else
			{
				num4 = method_7((class488_0 != null) ? double_0 : (double_0 - num));
				num2 = double_0 * (double)num4;
			}
			int num5 = (int)(num2 + 0.5);
			if (num5 == 0)
			{
				if (class488_0 != null)
				{
					method_6(class515_0, flag ? (0.0 - num) : num, class518_1, stringBuilder);
					return;
				}
				num4 = 1;
			}
			else if (num5 == num4)
			{
				if (class488_0 != null)
				{
					method_6(class515_0, flag ? (0.0 - num - 1.0) : (num + 1.0), class518_1, stringBuilder);
					return;
				}
				num2 = 1.0;
				num4 = 1;
			}
		}
		Class518 @class;
		if (class488_0 != null)
		{
			if (flag)
			{
				stringBuilder.Append('-');
			}
			@class = class488_0.Format(class515_0, TypeCode.Double, num);
			method_1(class518_1, @class, stringBuilder.Length);
			if (@class.Value != null)
			{
				stringBuilder.Append(@class.Value);
			}
			flag = false;
		}
		@class = class488_2.Format(class515_0, TypeCode.Double, flag ? (0.0 - num2) : num2);
		method_1(class518_1, @class, stringBuilder.Length);
		if (@class.Value != null)
		{
			stringBuilder.Append(@class.Value);
		}
		stringBuilder.Append('/');
		if (class487_0 != null)
		{
			@class = class487_0.Format(class515_0, TypeCode.Int32, num4);
			method_1(class518_1, @class, stringBuilder.Length);
			if (@class.Value != null)
			{
				stringBuilder.Append(@class.Value);
			}
		}
		class518_1.method_1(Enum136.const_4, stringBuilder.ToString().ToCharArray());
	}

	private void method_6(Class515 class515_0, double double_0, Class518 class518_1, StringBuilder stringBuilder_0)
	{
		Class518 @class = class488_1.Format(class515_0, TypeCode.Double, double_0);
		method_1(class518_1, @class, stringBuilder_0.Length);
		if (@class.Value != null)
		{
			stringBuilder_0.Append(@class.Value);
		}
		class518_1.method_1(Enum136.const_4, stringBuilder_0.ToString().ToCharArray());
	}

	private int method_7(double double_0)
	{
		int num = (int)Math.Pow(10.0, -int_0);
		int result = 2;
		double num2 = 1.0;
		for (int i = 2; i < num; i++)
		{
			double num3 = double_0 * (double)i;
			num3 -= Math.Floor(num3);
			if (num3 < 0.5)
			{
				if (num3 < num2)
				{
					num2 = num3;
					result = i;
				}
				continue;
			}
			num3 = 1.0 - num3;
			if (num3 < num2)
			{
				num2 = num3;
				result = i;
			}
		}
		return result;
	}
}
