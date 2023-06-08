using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using ns2;

namespace ns14;

internal class Class502 : Class495
{
	private Interface3[] interface3_0;

	private bool bool_0;

	private bool bool_1;

	private int int_0;

	private DateTime dateTime_0;

	internal Class502(Class509 class509_1, string string_0)
		: base(class509_1, string_0)
	{
	}

	internal override Class518 Format(Class515 class515_0, DateTime dateTime_1, double double_0, bool bool_2)
	{
		if (bool_2 && int_0 != 0 && vmethod_4())
		{
			if (dateTime_1.CompareTo(dateTime_0) > 0)
			{
				Class518 @class = base.Format(class515_0, dateTime_1, double_0, bool_2);
				if (@class.method_5() == Enum136.const_7)
				{
					@class.method_3(class515_0.method_2());
				}
				return @class;
			}
			dateTime_1 = dateTime_1.AddMilliseconds(int_0);
		}
		Class518 class2 = base.Format(class515_0, dateTime_1, double_0, bool_0: false);
		if (class2.method_5() != Enum136.const_7)
		{
			return class2;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < interface3_0.Length; i++)
		{
			Enum136 @enum = interface3_0[i].imethod_0();
			if (@enum == Enum136.const_1)
			{
				Class518 class3 = ((Class505)interface3_0[i]).Format(class515_0, TypeCode.Double, 0.0);
				method_1(class2, class3, stringBuilder.Length);
				if (class3.Value != null)
				{
					stringBuilder.Append(class3.Value);
				}
			}
			else
			{
				Class518 class4 = ((Class495)interface3_0[i]).Format(class515_0, dateTime_1, double_0, bool_0: false);
				if (class4.Value != null)
				{
					stringBuilder.Append(class4.Value);
				}
			}
		}
		class2.method_0(Enum136.const_3, stringBuilder.ToString());
		return class2;
	}

	protected override void vmethod_0(char[] char_0, int int_1, int int_2)
	{
		bool_0 = false;
		bool_1 = false;
		int_0 = 500;
		bool flag = false;
		bool flag2 = false;
		ArrayList arrayList = new ArrayList(3);
		StringBuilder stringBuilder = new StringBuilder(int_2 - int_1);
		method_5(char_0, int_1, int_2, stringBuilder);
		char_0 = stringBuilder.ToString().ToCharArray();
		stringBuilder.Length = 0;
		int_1 = 0;
		int_2 = char_0.Length;
		while (int_1 < int_2)
		{
			switch (char_0[int_1])
			{
			case '.':
				if (int_1 > 0 && char_0[int_1 - 1] == 's')
				{
					int_1++;
					int num = int_1;
					while (int_1 < int_2 && char_0[int_1] == '0')
					{
						int_1++;
					}
					if (int_1 > num)
					{
						method_8(arrayList, stringBuilder, flag, flag2, new Class500(class509_0, null, null, int_1 - num));
						flag = false;
						flag2 = false;
						switch (int_1 - num)
						{
						default:
							int_0 = 0;
							break;
						case 1:
							int_0 = Math.Min(50, int_0);
							break;
						case 2:
							int_0 = Math.Min(5, int_0);
							break;
						}
					}
					else
					{
						stringBuilder.Append('.');
					}
				}
				else
				{
					stringBuilder.Append('.');
					int_1++;
				}
				break;
			case '[':
				if (int_1 + 1 < int_2)
				{
					int num2 = -1;
					switch (char_0[int_1 + 1])
					{
					case 'S':
					case 's':
						num2 = 2;
						break;
					case 'M':
					case 'm':
						num2 = 1;
						break;
					case 'H':
					case 'h':
						num2 = 0;
						break;
					}
					if (num2 > -1)
					{
						bool_0 = true;
						int_1 += 2;
						int num3 = int_1;
						while (int_1 < int_2 && char_0[int_1] != ']')
						{
							int_1++;
						}
						int_1++;
						method_8(arrayList, stringBuilder, flag, flag2, new Class499(class509_0, null, null, num2, int_1 - num3));
						flag = false;
						flag2 = false;
						break;
					}
				}
				int_1 = class509_0.method_3(char_0, int_1, int_2, stringBuilder, bool_0: false);
				break;
			case 'M':
			{
				int j = int_1;
				int_1++;
				while (int_1 < int_2 && char_0[int_1] == 'M')
				{
					int_1++;
				}
				if (int_1 - j == 5)
				{
					method_8(arrayList, stringBuilder, flag, flag2, new Class498(class509_0, null, null));
					flag = false;
					flag2 = false;
					break;
				}
				if (flag2)
				{
					method_9(arrayList, stringBuilder);
					flag2 = false;
				}
				flag = true;
				for (; j < int_1; j++)
				{
					stringBuilder.Append('M');
				}
				break;
			}
			case '*':
			case '_':
				if (flag)
				{
					arrayList.Add(stringBuilder.ToString());
					stringBuilder.Length = 0;
					flag = false;
				}
				flag2 = true;
				stringBuilder.Append(char_0[int_1]);
				int_1++;
				stringBuilder.Append(char_0[int_1]);
				int_1++;
				break;
			case 'A':
			case 'a':
				if (int_1 + 2 < char_0.Length)
				{
					switch (char_0[int_1 + 1])
					{
					case '/':
						if (char_0[int_1 + 2] != 'p' && char_0[int_1 + 2] != 'P')
						{
							break;
						}
						method_8(arrayList, stringBuilder, flag, flag2, new Class497(class509_0, null, null, new string(char_0, int_1, 1), new string(char_0, int_1 + 2, 1)));
						flag = false;
						flag2 = false;
						int_1 += 3;
						method_7(128, bool_0: true);
						goto end_IL_0061;
					case 'A':
					case 'a':
					{
						int i;
						for (i = int_1 + 2; i < char_0.Length; i++)
						{
							char c = char_0[i];
							if (c != 'A' && c != 'a')
							{
								break;
							}
						}
						if (i - int_1 <= 2)
						{
							break;
						}
						method_8(arrayList, stringBuilder, flag, flag2, new Class501(class509_0, null, null, i - int_1 > 3));
						flag = false;
						flag2 = false;
						int_1 = i;
						goto end_IL_0061;
					}
					case 'M':
					case 'm':
						if (char_0[int_1 + 2] == '/' && int_1 + 4 < char_0.Length && (char_0[int_1 + 3] == 'p' || char_0[int_1 + 3] == 'P') && (char_0[int_1 + 4] == 'm' || char_0[int_1 + 4] == 'M'))
						{
							method_8(arrayList, stringBuilder, flag, flag2, new Class497(class509_0, null, null, new string(char_0, int_1, 2), new string(char_0, int_1 + 3, 2)));
							flag = false;
							flag2 = false;
							method_7(128, bool_0: true);
							int_1 += 5;
							goto end_IL_0061;
						}
						break;
					}
				}
				int_1 = vmethod_2(char_0, int_1, char_0.Length, stringBuilder);
				break;
			default:
				int_1 = vmethod_2(char_0, int_1, int_2, stringBuilder);
				break;
			case '上':
				if (int_1 + 5 < char_0.Length && char_0[int_1 + 1] == Class1391.char_0[1] && char_0[int_1 + 2] == '/' && char_0[int_1 + 3] == Class1391.char_1[0] && char_0[int_1 + 4] == Class1391.char_1[1])
				{
					method_8(arrayList, stringBuilder, flag, flag2, new Class497(class509_0, null, null, new string(char_0, int_1, 2), new string(char_0, int_1 + 3, 2)));
					flag = false;
					flag2 = false;
					method_7(128, bool_0: true);
					int_1 += 5;
				}
				else
				{
					stringBuilder.Append(char_0[int_1]);
					int_1++;
				}
				break;
			case 'G':
			case 'H':
			case 'd':
			case 'g':
			case 'h':
			case 'm':
			case 's':
			case 'y':
				{
					if (flag2)
					{
						method_9(arrayList, stringBuilder);
						flag2 = false;
					}
					flag = true;
					stringBuilder.Append(char_0[int_1]);
					int_1++;
					break;
				}
				end_IL_0061:
				break;
			}
		}
		if (flag)
		{
			arrayList.Add(stringBuilder.ToString());
		}
		else if (flag2)
		{
			method_9(arrayList, stringBuilder);
			flag2 = false;
		}
		else if (stringBuilder.Length > 0)
		{
			if (arrayList.Count > 0)
			{
				((Class496)arrayList[arrayList.Count - 1]).method_9(method_10(stringBuilder));
			}
			else
			{
				arrayList.Add(stringBuilder.ToString());
			}
		}
		if (arrayList.Count > 0)
		{
			interface3_0 = new Interface3[arrayList.Count];
			for (int k = 0; k < interface3_0.Length; k++)
			{
				if (arrayList[k] is string)
				{
					string text = (string)arrayList[k];
					char[] array = text.ToCharArray();
					if (method_6(128))
					{
						if (Class487.smethod_2(array, 0, array.Length, 'H', 'h'))
						{
							text = new string(array);
						}
					}
					else if (Class487.smethod_2(array, 0, array.Length, 'h', 'H'))
					{
						text = new string(array);
					}
					interface3_0[k] = new Class503(class509_0, text, bool_0: false);
					bool_1 = true;
				}
				else
				{
					interface3_0[k] = (Interface3)arrayList[k];
					if (!bool_1 && interface3_0[k].imethod_0() == Enum136.const_3)
					{
						bool_1 = ((Class495)interface3_0[k]).vmethod_4();
					}
				}
			}
		}
		if (int_0 > 0)
		{
			dateTime_0 = DateTime.MaxValue.AddMilliseconds(-int_0);
		}
	}

	private void method_8(ArrayList arrayList_0, StringBuilder stringBuilder_0, bool bool_2, bool bool_3, Class496 class496_0)
	{
		if (bool_2)
		{
			arrayList_0.Add(stringBuilder_0.ToString());
			stringBuilder_0.Length = 0;
		}
		else if (bool_3)
		{
			method_9(arrayList_0, stringBuilder_0);
		}
		else if (stringBuilder_0.Length > 0)
		{
			class496_0.method_8(method_10(stringBuilder_0));
		}
		arrayList_0.Add(class496_0);
	}

	private void method_9(ArrayList arrayList_0, StringBuilder stringBuilder_0)
	{
		Class505 value = new Class505(class509_0, stringBuilder_0.ToString());
		stringBuilder_0.Length = 0;
		arrayList_0.Add(value);
	}

	private string method_10(StringBuilder stringBuilder_0)
	{
		for (int i = 0; i < stringBuilder_0.Length; i++)
		{
			switch (stringBuilder_0[i])
			{
			case '\\':
				stringBuilder_0.Remove(i, 1);
				break;
			case '"':
				stringBuilder_0.Remove(i, 1);
				for (; i < stringBuilder_0.Length; i++)
				{
					if (stringBuilder_0[i] == '"')
					{
						stringBuilder_0.Remove(i, 1);
						i--;
						break;
					}
				}
				break;
			}
		}
		string result = stringBuilder_0.ToString();
		stringBuilder_0.Length = 0;
		return result;
	}

	[SpecialName]
	public override bool vmethod_3()
	{
		return bool_0;
	}

	[SpecialName]
	public override bool vmethod_4()
	{
		return bool_1;
	}

	[SpecialName]
	public override Enum136 imethod_0()
	{
		return Enum136.const_3;
	}
}
