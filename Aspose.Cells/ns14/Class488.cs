using System;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;

namespace ns14;

internal abstract class Class488 : Class487
{
	protected Class511 class511_0;

	internal Class488(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	internal double method_2(double double_0)
	{
		return vmethod_3(double_0 * class511_0.method_0()) / class511_0.method_0();
	}

	protected abstract double vmethod_3(double double_0);

	internal abstract void vmethod_4(Class515 class515_0, double double_0, Class518 class518_1);

	public override Class518 Format(Class515 class515_0, TypeCode typeCode_0, object object_0)
	{
		Class518 @class = base.Format(class515_0, typeCode_0, object_0);
		if (@class.method_5() != Enum136.const_7)
		{
			return @class;
		}
		switch (typeCode_0)
		{
		case TypeCode.Double:
			vmethod_4(class515_0, (double)object_0 * class511_0.method_0(), @class);
			return @class;
		default:
			method_0(object_0, typeCode_0, @class);
			return @class;
		case TypeCode.DateTime:
			vmethod_4(class515_0, ToDouble((DateTime)object_0) * class511_0.method_0(), @class);
			return @class;
		case TypeCode.Int32:
			vmethod_4(class515_0, (double)(int)object_0 * class511_0.method_0(), @class);
			return @class;
		}
	}

	protected void method_3(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		method_4(char_0, int_0, int_1, stringBuilder_0);
		char_0 = stringBuilder_0.ToString().ToCharArray();
		stringBuilder_0.Length = 0;
		int_0 = 0;
		int_1 = char_0.Length;
		while (int_0 < int_1)
		{
			int_0 = vmethod_1(char_0, int_0, int_1, stringBuilder_0);
		}
	}

	protected void method_4(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		class511_0 = new Class511();
		int num = 0;
		bool flag = false;
		bool flag2 = false;
		int num2 = 0;
		int[] array = new int[int_1 - int_0];
		while (int_0 < int_1)
		{
			switch (char_0[int_0])
			{
			case ',':
			{
				if (int_0 <= 0)
				{
					break;
				}
				char c = char_0[int_0 - 1];
				if (c == '#' || c == '0')
				{
					int_0++;
					Class511 @class = class511_0;
					@class.method_1(@class.method_0() * 0.001);
					while (int_0 < int_1 && char_0[int_0] == ',')
					{
						Class511 class2 = class511_0;
						class2.method_1(class2.method_0() * 0.001);
						int_0++;
					}
					continue;
				}
				break;
			}
			case '.':
				if (class511_0.method_4() < 0)
				{
					class511_0.method_5(stringBuilder_0.Length);
					flag2 = true;
				}
				break;
			case '/':
				flag = false;
				flag2 = false;
				break;
			case '0':
				if (flag2)
				{
					num++;
					class511_0.method_11(bool_0: false);
				}
				else if (class511_0.method_4() < 0)
				{
					class511_0.method_10(bool_0: false);
					if (class511_0.method_0() < 1.0)
					{
						class511_0.method_7(bool_0: true);
					}
					array[num2] = stringBuilder_0.Length;
					num2++;
				}
				class511_0.method_1(1.0);
				break;
			case '%':
				if (!flag)
				{
					flag = true;
				}
				break;
			default:
				int_0 = vmethod_2(char_0, int_0, int_1, stringBuilder_0);
				continue;
			case 'E':
			case 'e':
				class511_0.method_9(stringBuilder_0.Length);
				flag = false;
				flag2 = false;
				break;
			case '#':
			case '?':
				if (class511_0.method_4() < 0)
				{
					if (class511_0.method_0() < 1.0)
					{
						class511_0.method_7(bool_0: true);
					}
					array[num2] = stringBuilder_0.Length;
					num2++;
				}
				else if (flag2)
				{
					num++;
				}
				class511_0.method_1(1.0);
				break;
			}
			stringBuilder_0.Append(char_0[int_0]);
			int_0++;
		}
		if (flag)
		{
			Class511 class3 = class511_0;
			class3.method_1(class3.method_0() * 100.0);
		}
		class511_0.method_3(num);
		if (!class511_0.method_6())
		{
			return;
		}
		if (num2 < 4)
		{
			stringBuilder_0.Insert(array[0], num2 switch
			{
				1 => "#,##", 
				2 => "#,#", 
				_ => "#,", 
			});
			return;
		}
		for (num2 -= 3; num2 > 0; num2 -= 3)
		{
			stringBuilder_0.Insert(array[num2], ',');
		}
	}

	protected override int vmethod_1(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		switch (char_0[int_0])
		{
		default:
			int_0 = base.vmethod_1(char_0, int_0, int_1, stringBuilder_0);
			break;
		case '#':
		case '+':
		case ',':
		case '-':
		case '.':
		case '0':
		case 'E':
		case 'e':
			stringBuilder_0.Append(char_0[int_0]);
			int_0++;
			break;
		}
		return int_0;
	}

	[SpecialName]
	public override Enum136 imethod_0()
	{
		return Enum136.const_2;
	}
}
