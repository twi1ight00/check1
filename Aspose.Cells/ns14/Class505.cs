using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;

namespace ns14;

internal class Class505 : Class487
{
	private char[][] char_0;

	private int int_0;

	private int[] int_1;

	private int[] int_2;

	private int[] int_3;

	private int int_4;

	private int int_5;

	internal Class505(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	[SpecialName]
	internal int[] method_2()
	{
		return int_3;
	}

	[SpecialName]
	internal int method_3()
	{
		return int_0;
	}

	[SpecialName]
	internal bool method_4()
	{
		return char_0.Length < 2;
	}

	protected override void vmethod_0(char[] char_1, int int_6, int int_7)
	{
		ArrayList arrayList = new ArrayList(3);
		ArrayList arrayList2 = null;
		ArrayList arrayList3 = null;
		ArrayList arrayList4 = null;
		StringBuilder stringBuilder = new StringBuilder(int_7 - int_6);
		while (int_6 < int_7)
		{
			switch (char_1[int_6])
			{
			case '"':
				int_6++;
				while (int_6 < int_7 && char_1[int_6] != '"')
				{
					stringBuilder.Append(char_1[int_6]);
					int_6++;
				}
				break;
			case '[':
				int_6 = class509_0.method_3(char_1, int_6, int_7, null, bool_0: true);
				continue;
			case '\\':
				int_6++;
				if (int_6 < int_7)
				{
					stringBuilder.Append(char_1[int_6]);
				}
				break;
			default:
				stringBuilder.Append(char_1[int_6]);
				break;
			case '*':
			case '_':
				if (int_6 + 1 < int_7)
				{
					if (arrayList2 == null)
					{
						arrayList2 = new ArrayList(3);
						arrayList3 = new ArrayList(3);
						arrayList4 = new ArrayList(3);
					}
					arrayList2.Add(arrayList.Count);
					arrayList3.Add(stringBuilder.Length);
					arrayList4.Add(Class518.smethod_0(char_1[int_6] == '*', stringBuilder.Length, char_1[int_6 + 1]));
					int_6++;
				}
				break;
			case '@':
				if (stringBuilder.Length > 0)
				{
					arrayList.Add(stringBuilder.ToString());
					stringBuilder.Length = 0;
				}
				else
				{
					arrayList.Add(null);
				}
				break;
			}
			int_6++;
		}
		if (stringBuilder.Length > 0)
		{
			arrayList.Add(stringBuilder.ToString());
		}
		else
		{
			arrayList.Add(null);
		}
		char_0 = new char[arrayList.Count][];
		int_0 = 0;
		for (int i = 0; i < char_0.Length; i++)
		{
			object obj = arrayList[i];
			if (obj != null)
			{
				char_0[i] = ((string)obj).ToCharArray();
				int_0 += char_0[i].Length;
			}
		}
		if (arrayList4 != null)
		{
			int_3 = new int[arrayList4.Count];
			int_1 = new int[int_3.Length];
			int_2 = new int[int_3.Length];
			for (int j = 0; j < int_3.Length; j++)
			{
				int_1[j] = (int)arrayList2[j];
				int_2[j] = (int)arrayList3[j];
				int_3[j] = (int)arrayList4[j];
			}
		}
	}

	public override Class518 Format(Class515 class515_0, TypeCode typeCode_0, object object_0)
	{
		return Format(class515_0, typeCode_0, object_0, bool_0: false);
	}

	internal Class518 Format(Class515 class515_0, TypeCode typeCode_0, object object_0, bool bool_0)
	{
		Class518 @class = base.Format(class515_0, typeCode_0, object_0);
		if (@class.method_5() != Enum136.const_7)
		{
			return @class;
		}
		switch (typeCode_0)
		{
		case TypeCode.Double:
			method_5(class515_0, (double)object_0, @class, bool_0);
			break;
		default:
			method_6(class515_0, object_0.ToString(), @class, bool_0);
			break;
		case TypeCode.DateTime:
			ToDouble((DateTime)object_0);
			method_5(class515_0, ToDouble((DateTime)object_0), @class, bool_0);
			break;
		case TypeCode.Int32:
			method_5(class515_0, (int)object_0, @class, bool_0);
			break;
		case TypeCode.Boolean:
			method_6(class515_0, object_0.ToString().ToUpper(), @class, bool_0);
			break;
		}
		return @class;
	}

	private void method_5(Class515 class515_0, double double_0, Class518 class518_1, bool bool_0)
	{
		if (method_4())
		{
			method_8(class518_1, double_0 < 0.0);
		}
		else
		{
			method_7(class518_1, bool_0 ? "" : class509_0.method_0().method_12().Format(class515_0, TypeCode.Double, double_0)
				.StringValue);
		}
	}

	private void method_6(Class515 class515_0, string string_0, Class518 class518_1, bool bool_0)
	{
		if (method_4())
		{
			if (bool_0)
			{
				method_8(class518_1, bool_0: false);
			}
			else
			{
				method_7(class518_1, string_0);
			}
			return;
		}
		if (int_3 != null)
		{
			class518_1.method_7(int_3);
		}
		char[] array = string_0.ToCharArray();
		char[] array2 = new char[int_0 + array.Length * (char_0.Length - 1)];
		int_4 = 0;
		int_5 = 0;
		method_9(array2, 0, class518_1);
		for (int i = 1; i < char_0.Length; i++)
		{
			Array.Copy(array, 0, array2, int_4, array.Length);
			int_4 += array.Length;
			method_9(array2, i, class518_1);
		}
		class518_1.method_1(Enum136.const_1, array2);
	}

	private void method_7(Class518 class518_1, string string_0)
	{
		class518_1.method_7(null);
		class518_1.SetColor(Color.Empty);
		class518_1.method_0(Enum136.const_1, string_0);
	}

	private void method_8(Class518 class518_1, bool bool_0)
	{
		if (int_3 != null)
		{
			class518_1.method_7(int_3);
			for (int i = 0; i < int_3.Length; i++)
			{
				class518_1.method_12(i, bool_0 ? (1 + int_2[i]) : int_2[i]);
			}
		}
		char[] array;
		if (!bool_0)
		{
			array = ((char_0[0] != null) ? char_0[0] : new char[0]);
		}
		else if (char_0[0] == null)
		{
			array = new char[1] { '-' };
		}
		else
		{
			array = new char[char_0[0].Length + 1];
			Array.Copy(char_0[0], 0, array, 1, char_0[0].Length);
			array[0] = '-';
		}
		class518_1.method_1(Enum136.const_1, array);
	}

	private void method_9(char[] char_1, int int_6, Class518 class518_1)
	{
		if (int_3 != null)
		{
			while (int_5 < int_1.Length && int_1[int_5] == int_6)
			{
				class518_1.method_12(int_5, int_4 + int_2[int_5]);
				int_5++;
			}
		}
		char[] array = char_0[int_6];
		if (array != null)
		{
			Array.Copy(array, 0, char_1, int_4, array.Length);
			int_4 += array.Length;
		}
	}

	[SpecialName]
	public override Enum136 imethod_0()
	{
		return Enum136.const_1;
	}
}
