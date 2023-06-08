using System;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;
using ns22;

namespace ns14;

internal abstract class Class495 : Class487
{
	private short short_0;

	internal Class495(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	public override Class518 Format(Class515 class515_0, TypeCode typeCode_0, object object_0)
	{
		switch (typeCode_0)
		{
		case TypeCode.Double:
			return method_3(class515_0, (double)object_0);
		default:
		{
			Class518 @class = base.Format(class515_0, typeCode_0, object_0);
			if (@class.method_5() != Enum136.const_7)
			{
				return @class;
			}
			method_0(object_0, typeCode_0, @class);
			return @class;
		}
		case TypeCode.DateTime:
			return method_2(class515_0, (DateTime)object_0);
		case TypeCode.Int32:
			return method_3(class515_0, (int)object_0);
		}
	}

	internal virtual Class518 Format(Class515 class515_0, DateTime dateTime_0, double double_0, bool bool_0)
	{
		Class518 @class = base.Format(class515_0, TypeCode.DateTime, dateTime_0);
		if (@class.method_5() != Enum136.const_7)
		{
			return @class;
		}
		if (double_0 < 0.0 && vmethod_4())
		{
			@class.method_3(class515_0.method_2());
			return @class;
		}
		return @class;
	}

	private Class518 method_2(Class515 class515_0, DateTime dateTime_0)
	{
		return Format(class515_0, dateTime_0, vmethod_3() ? ToDouble(dateTime_0) : 0.0, bool_0: true);
	}

	private Class518 method_3(Class515 class515_0, double double_0)
	{
		if (double_0 > 2958465.999994)
		{
			Class518 @class = base.Format(class515_0, TypeCode.Double, double_0);
			@class.method_3(class515_0.method_2());
			return @class;
		}
		return Format(class515_0, (!vmethod_4() || double_0 < 0.0) ? DateTime.MinValue : ToDateTime(double_0), double_0, bool_0: true);
	}

	protected void method_4(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		int length = stringBuilder_0.Length;
		method_5(char_0, int_0, int_1, stringBuilder_0);
		char_0 = stringBuilder_0.ToString().Substring(length).ToCharArray();
		stringBuilder_0.Length = length;
		int_0 = 0;
		int_1 = char_0.Length;
		while (int_0 < int_1)
		{
			char c = char_0[int_0];
			if (c == 'A' || c == 'a')
			{
				int num = Class1180.smethod_1(char_0, int_0, int_1);
				if (num > int_0)
				{
					Class1180.smethod_6(stringBuilder_0, char_0, int_0, num);
					int_0 = num;
					continue;
				}
			}
			int_0 = vmethod_1(char_0, int_0, int_1, stringBuilder_0);
		}
	}

	protected void method_5(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		int i = -1;
		char c = ' ';
		bool flag = false;
		while (int_0 < int_1)
		{
			switch (char_0[int_0])
			{
			case '[':
				if (int_0 + 1 < int_1)
				{
					switch (char_0[int_0 + 1])
					{
					case 'M':
					case 'm':
						flag = true;
						method_7(16, bool_0: true);
						break;
					case 'H':
					case 'h':
						c = char_0[int_0 + 1];
						method_7(8, bool_0: true);
						break;
					}
				}
				int_0 = vmethod_2(char_0, int_0, int_1, stringBuilder_0);
				continue;
			case 'A':
			case 'a':
				stringBuilder_0.Append(char_0[int_0]);
				break;
			case 'B':
			case 'b':
				if (Class519.smethod_2(30, class509_0.method_0().method_3()))
				{
					stringBuilder_0.Append('y');
					method_7(1, bool_0: true);
				}
				else
				{
					stringBuilder_0.Append(char_0[int_0]);
				}
				break;
			case 'D':
			case 'd':
				i = -1;
				stringBuilder_0.Append('d');
				c = 'd';
				method_7(4, bool_0: true);
				break;
			case 'E':
			case 'e':
				stringBuilder_0.Append("yyyy");
				method_7(1, bool_0: true);
				int_0++;
				while (int_0 < int_1 && (char_0[int_0] == 'e' || char_0[int_0] == 'E'))
				{
					int_0++;
				}
				continue;
			case 'G':
			case 'g':
				if (Class519.smethod_2(16, class509_0.method_0().method_3()))
				{
					stringBuilder_0.Append('d');
					method_7(4, bool_0: true);
				}
				else
				{
					method_7(256, bool_0: true);
					stringBuilder_0.Append(char_0[int_0]);
				}
				break;
			case 'H':
			case 'h':
				i = -1;
				c = char_0[int_0];
				stringBuilder_0.Append(char_0[int_0]);
				method_7(8, bool_0: true);
				break;
			case 'J':
				if (Class519.smethod_2(7, class509_0.method_0().method_3()))
				{
					stringBuilder_0.Append('y');
					method_7(1, bool_0: true);
				}
				else
				{
					stringBuilder_0.Append(char_0[int_0]);
				}
				break;
			case 'M':
			case 'm':
				if (int_0 > 0 && int_0 + 3 < int_1 && char_0[int_0 + 1] == '/' && (char_0[int_0 - 1] == 'a' || char_0[int_0 - 1] == 'A') && (char_0[int_0 + 2] == 'p' || char_0[int_0 + 2] == 'P') && (char_0[int_0 + 3] == 'm' || char_0[int_0 + 3] == 'M'))
				{
					stringBuilder_0.Append(char_0, int_0, 4);
					int_0 += 4;
					method_7(128, bool_0: true);
					continue;
				}
				i = int_0;
				for (int_0++; int_0 < int_1; int_0++)
				{
					char c2 = char_0[int_0];
					if (c2 != 'M' && c2 != 'm')
					{
						break;
					}
				}
				i = int_0 - i;
				switch (i)
				{
				case 1:
				case 2:
				{
					char value = 'M';
					bool flag2 = false;
					switch (c)
					{
					case 's':
						if (!flag)
						{
							value = 'm';
							flag = true;
							method_7(16, bool_0: true);
						}
						flag2 = true;
						break;
					case 'H':
					case 'h':
						value = 'm';
						flag = true;
						flag2 = true;
						method_7(16, bool_0: true);
						break;
					}
					for (int j = 0; j < i; j++)
					{
						stringBuilder_0.Append(value);
					}
					i = ((!flag2) ? (stringBuilder_0.Length - i) : (-1));
					break;
				}
				case 3:
					i = -1;
					stringBuilder_0.Append("MMM");
					method_7(2, bool_0: true);
					method_7(64, bool_0: true);
					break;
				default:
					i = -1;
					stringBuilder_0.Append("MMMM");
					method_7(2, bool_0: true);
					method_7(64, bool_0: true);
					break;
				case 5:
					i = -1;
					stringBuilder_0.Append("MMMMM");
					method_7(2, bool_0: true);
					method_7(64, bool_0: true);
					break;
				}
				continue;
			case 'T':
				if (Class519.smethod_2(7, class509_0.method_0().method_3()))
				{
					stringBuilder_0.Append('d');
					method_7(4, bool_0: true);
				}
				else
				{
					stringBuilder_0.Append(char_0[int_0]);
				}
				break;
			default:
				int_0 = vmethod_2(char_0, int_0, int_1, stringBuilder_0);
				continue;
			case 'ด':
				if (Class519.smethod_2(30, class509_0.method_0().method_3()))
				{
					stringBuilder_0.Append('M');
					method_7(2, bool_0: true);
				}
				else
				{
					stringBuilder_0.Append(char_0[int_0]);
				}
				break;
			case 'Y':
			case 'y':
				i = -1;
				stringBuilder_0.Append('y');
				c = 'y';
				method_7(1, bool_0: true);
				break;
			case 'R':
			case 'r':
				if (!Class519.smethod_2(17, class509_0.method_0().method_3()) && !Class519.smethod_2(2052, class509_0.method_0().method_3()))
				{
					stringBuilder_0.Append(char_0[int_0]);
					break;
				}
				stringBuilder_0.Append("yyyy");
				method_7(1, bool_0: true);
				int_0++;
				while (int_0 < int_1 && (char_0[int_0] == 'r' || char_0[int_0] == 'R'))
				{
					int_0++;
				}
				continue;
			case 'S':
			case 's':
				if (i > -1)
				{
					for (int length = stringBuilder_0.Length; i < length && stringBuilder_0[i] == 'M'; i++)
					{
						stringBuilder_0[i] = 'm';
						method_7(16, bool_0: true);
					}
					i = -1;
					flag = true;
				}
				c = 's';
				stringBuilder_0.Append('s');
				method_7(32, bool_0: true);
				break;
			}
			int_0++;
		}
		if (i > -1)
		{
			method_7(2, bool_0: true);
		}
	}

	protected override int vmethod_2(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		int num = Class1180.smethod_1(char_0, int_0, int_1);
		if (num > int_0)
		{
			while (int_0 < num)
			{
				stringBuilder_0.Append('\\');
				stringBuilder_0.Append(char_0[int_0]);
				int_0++;
			}
			return int_0;
		}
		return base.vmethod_2(char_0, int_0, int_1, stringBuilder_0);
	}

	protected override int vmethod_1(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0)
	{
		int num = Class1180.smethod_1(char_0, int_0, int_1);
		if (num > int_0)
		{
			stringBuilder_0.Append(char_0, int_0, num - int_0);
			return num;
		}
		char c = char_0[int_0];
		if (c == '/')
		{
			stringBuilder_0.Append(class509_0.method_0().method_4().method_5());
			int_0++;
		}
		else
		{
			int_0 = base.vmethod_1(char_0, int_0, int_1, stringBuilder_0);
		}
		return int_0;
	}

	[SpecialName]
	public virtual bool vmethod_3()
	{
		return false;
	}

	[SpecialName]
	public virtual bool vmethod_4()
	{
		return true;
	}

	[SpecialName]
	public override Enum136 imethod_0()
	{
		return Enum136.const_3;
	}

	internal bool method_6(short short_1)
	{
		return (short_0 & short_1) != 0;
	}

	protected void method_7(short short_1, bool bool_0)
	{
		if (bool_0)
		{
			short_0 |= short_1;
		}
		else
		{
			short_0 &= (short)(~short_1);
		}
	}
}
