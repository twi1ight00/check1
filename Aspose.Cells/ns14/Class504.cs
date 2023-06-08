using System;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;

namespace ns14;

internal class Class504 : Class487
{
	private static readonly double[] double_0 = new double[17]
	{
		0.95, 9.5, 99.5, 999.5, 9999.5, 99999.5, 999999.5, 9999999.5, 99999999.5, 999999999.5,
		9999999999.5, 99999999999.5, 999999999999.5, 9999999999999.5, 99999999999999.5, 999999999999999.5, 10000000000000000.0
	};

	private Interface3 interface3_0;

	private Interface3 interface3_1;

	private char char_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	internal Class504(Class509 class509_1, Class487 class487_0, Class487 class487_1)
		: base(class509_1, "")
	{
		method_7(class509_0.method_0());
		interface3_0 = class487_0;
		interface3_1 = class487_1;
		bool_2 = false;
		bool_0 = false;
		bool_1 = false;
		if (class487_0 != null)
		{
			bool_2 = true;
			if (class487_0.imethod_0() == Enum136.const_3 && ((Class495)class487_0).vmethod_4())
			{
				bool_0 = true;
			}
		}
		if (class487_1 != null)
		{
			bool_2 = true;
			if (class487_1.imethod_0() == Enum136.const_3 && ((Class495)class487_1).vmethod_4())
			{
				bool_1 = true;
			}
		}
	}

	protected override void vmethod_0(char[] char_1, int int_0, int int_1)
	{
	}

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
			method_2(class515_0, (double)object_0, @class);
			return @class;
		default:
			method_0(object_0, typeCode_0, @class);
			return @class;
		case TypeCode.DateTime:
			method_2(class515_0, ToDouble((DateTime)object_0), @class);
			return @class;
		case TypeCode.Int32:
		{
			int num = (int)object_0;
			method_2(class515_0, num, @class);
			return @class;
		}
		}
	}

	private void method_2(Class515 class515_0, double double_1, Class518 class518_1)
	{
		bool flag;
		if (double_1 < 0.0)
		{
			flag = true;
			double_1 = 0.0 - double_1;
		}
		else
		{
			flag = false;
		}
		Class518 @class = null;
		Class518 class2 = null;
		if (bool_2)
		{
			if (flag && (bool_0 || bool_1))
			{
				class518_1.method_3(class515_0.method_2());
				return;
			}
			if (interface3_0 != null)
			{
				@class = interface3_0.Format(class515_0, TypeCode.Double, double_1);
				if (@class.method_4())
				{
					class518_1.method_3(class515_0.method_2());
					return;
				}
			}
			if (interface3_1 != null)
			{
				class2 = interface3_1.Format(class515_0, TypeCode.Double, double_1);
				if (class2.method_4())
				{
					class518_1.method_3(class515_0.method_2());
					return;
				}
			}
		}
		int num;
		if (class515_0.method_0() == null)
		{
			num = class509_0.method_0().method_13();
		}
		else
		{
			StringBuilder stringBuilder = null;
			if (bool_2)
			{
				stringBuilder = new StringBuilder();
				if (@class != null)
				{
					stringBuilder.Append(@class.method_6(0, bool_1: false));
				}
				if (class2 != null)
				{
					stringBuilder.Append(class2.method_6(0, bool_1: false));
				}
			}
			num = class515_0.method_0().imethod_0(stringBuilder?.ToString(), flag);
		}
		if (num < 1)
		{
			class518_1.method_3(class515_0.method_2());
			return;
		}
		string text = null;
		if (double_1 == 0.0)
		{
			text = "0";
		}
		else
		{
			text = method_3(class515_0, double_1, num);
			if (text == null)
			{
				class518_1.method_3(class515_0.method_2());
				return;
			}
		}
		char[] array = text.ToCharArray();
		if (bool_2)
		{
			char[] array2 = new char[(flag ? 1 : 0) + ((@class != null && @class.Value != null) ? @class.Value.Length : 0) + array.Length + ((class2 != null && class2.Value != null) ? class2.Value.Length : 0)];
			int num2 = 0;
			if (flag)
			{
				array2[0] = '-';
				num2 = 1;
			}
			if (@class != null)
			{
				method_1(class518_1, @class, num2);
				char[] value = @class.Value;
				if (value != null)
				{
					Array.Copy(value, array2, value.Length);
					num2 += value.Length;
				}
			}
			Array.Copy(array, 0, array2, num2, array.Length);
			num2 += array.Length;
			if (class2 != null)
			{
				method_1(class518_1, class2, num2);
				char[] value2 = class2.Value;
				if (value2 != null)
				{
					Array.Copy(value2, 0, array2, num2, value2.Length);
					num2 += value2.Length;
				}
			}
			array = array2;
		}
		else if (flag)
		{
			char[] array3 = new char[array.Length + 1];
			array3[0] = '-';
			Array.Copy(array, 0, array3, 1, array.Length);
			array = array3;
		}
		class518_1.method_1(Enum136.const_2, array);
	}

	private string method_3(Class515 class515_0, double double_1, int int_0)
	{
		if (double_1 == 0.0)
		{
			return "0";
		}
		if (double_1 >= 9999.5)
		{
			if (int_0 < 5)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder(int_0);
			int num = (int)Math.Log10(double_1);
			if (double_1 >= double_0[int_0])
			{
				int_0 -= ((num > 99) ? 7 : 6);
				double_1 = ((int_0 <= 0) ? (double_1 / Math.Pow(10.0, num)) : (double_1 / Math.Pow(10.0, num - int_0)));
				stringBuilder.Append((long)(double_1 + 0.5));
				if (stringBuilder.Length > ((int_0 <= 0) ? 1 : (int_0 + 1)))
				{
					num++;
				}
				method_4(stringBuilder, 0);
				method_6(stringBuilder, num);
			}
			else
			{
				if (int_0 > num + 2)
				{
					double_1 *= Math.Pow(10.0, int_0 - (num + 2));
				}
				stringBuilder.Append((long)(double_1 + 0.5));
				if (stringBuilder.Length > ((int_0 >= num + 2) ? (int_0 - 1) : int_0))
				{
					num++;
				}
				method_4(stringBuilder, num);
				if (stringBuilder.Length > num + 1)
				{
					stringBuilder.Insert(num + 1, char_0);
				}
			}
			return stringBuilder.ToString();
		}
		if (double_1 < 1.0)
		{
			int num2 = -(int)Math.Floor(Math.Log10(double_1));
			if (num2 < int_0 - 1)
			{
				StringBuilder stringBuilder2 = new StringBuilder(int_0);
				if (int_0 >= 5 && num2 >= 4 && int_0 != 6)
				{
					if (num2 == 4)
					{
						string text = ((long)(double_1 * Math.Pow(10.0, int_0 - 2) + 0.5)).ToString();
						if (text.Length > int_0 - 5)
						{
							method_5(stringBuilder2, 3);
							stringBuilder2.Append(text[0]);
							return stringBuilder2.ToString();
						}
					}
					double_1 = ((int_0 <= 6) ? (double_1 * Math.Pow(10.0, num2)) : (double_1 * Math.Pow(10.0, int_0 + num2 - 6)));
					stringBuilder2.Append((long)(double_1 + 0.5));
					bool flag = false;
					if (stringBuilder2.Length > int_0 - 5)
					{
						num2--;
						flag = true;
					}
					method_4(stringBuilder2, 0);
					if (!flag && stringBuilder2.Length < int_0 - num2)
					{
						string value = stringBuilder2.ToString();
						stringBuilder2.Length = 0;
						method_5(stringBuilder2, num2);
						stringBuilder2.Append(value);
					}
					else
					{
						method_6(stringBuilder2, -num2);
					}
					return stringBuilder2.ToString();
				}
				method_5(stringBuilder2, num2);
				int num3 = stringBuilder2.Length;
				stringBuilder2.Append((long)(double_1 * Math.Pow(10.0, int_0 - 2) + 0.5));
				if (stringBuilder2.Length - num3 > int_0 - 1 - num2)
				{
					if (num2 > 1)
					{
						stringBuilder2.Remove(num3 - 1, 1);
						num3 -= 2;
					}
					else
					{
						stringBuilder2.Remove(0, 2);
						num3 = 0;
					}
				}
				method_4(stringBuilder2, num3);
				return stringBuilder2.ToString();
			}
			if (int_0 < 5)
			{
				return "0";
			}
			StringBuilder stringBuilder3 = new StringBuilder(int_0);
			int_0 -= ((num2 > 99) ? 7 : 6);
			double_1 = ((int_0 <= 0) ? (double_1 * Math.Pow(10.0, num2)) : (double_1 * Math.Pow(10.0, int_0 + num2)));
			stringBuilder3.Append((long)(double_1 + 0.5));
			if (stringBuilder3.Length > ((int_0 <= 0) ? 1 : (int_0 + 1)))
			{
				num2--;
			}
			method_4(stringBuilder3, 0);
			method_6(stringBuilder3, -num2);
			return stringBuilder3.ToString();
		}
		if (double_1 >= double_0[int_0])
		{
			return null;
		}
		int num4 = ((double_1 >= 1000.0) ? 3 : ((double_1 >= 100.0) ? 2 : ((double_1 >= 10.0) ? 1 : 0)));
		if (int_0 > num4 + 2)
		{
			double_1 *= Math.Pow(10.0, int_0 - num4 - 2);
		}
		StringBuilder stringBuilder4 = new StringBuilder(int_0);
		stringBuilder4.Append((long)(double_1 + 0.5));
		if (stringBuilder4.Length > ((int_0 >= num4 + 2) ? (int_0 - 1) : int_0))
		{
			num4++;
		}
		method_4(stringBuilder4, num4);
		if (stringBuilder4.Length > num4 + 1)
		{
			stringBuilder4.Insert(num4 + 1, char_0);
		}
		return stringBuilder4.ToString();
	}

	private void method_4(StringBuilder stringBuilder_0, int int_0)
	{
		int num = stringBuilder_0.Length - 1;
		while (num > int_0 && stringBuilder_0[num] == '0')
		{
			num--;
		}
		stringBuilder_0.Length = num + 1;
	}

	private void method_5(StringBuilder stringBuilder_0, int int_0)
	{
		stringBuilder_0.Append('0');
		stringBuilder_0.Append(char_0);
		for (int i = 1; i < int_0; i++)
		{
			stringBuilder_0.Append('0');
		}
	}

	private void method_6(StringBuilder stringBuilder_0, int int_0)
	{
		if (stringBuilder_0.Length > 1)
		{
			stringBuilder_0.Insert(1, char_0);
		}
		stringBuilder_0.Append("E");
		if (int_0 >= 0)
		{
			stringBuilder_0.Append('+');
		}
		else
		{
			stringBuilder_0.Append('-');
			int_0 = -int_0;
		}
		if (int_0 < 10)
		{
			stringBuilder_0.Append('0');
		}
		stringBuilder_0.Append(int_0);
	}

	[SpecialName]
	public override Enum136 imethod_0()
	{
		return Enum136.const_0;
	}

	private void method_7(Class516 class516_0)
	{
		char_0 = class516_0.method_4().method_2();
	}
}
