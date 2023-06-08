using System;
using System.Drawing;
using System.Text;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns14;

internal class Class486
{
	private Class516 class516_0;

	private short short_0;

	private Enum136 enum136_0 = Enum136.const_7;

	private Class487 class487_0;

	private Class487 class487_1;

	private bool bool_0 = true;

	private bool bool_1;

	private bool bool_2;

	private int int_0 = -1;

	internal Class486(Class516 class516_1)
	{
		class516_0 = class516_1;
		short_0 = class516_1.method_3();
	}

	private void Reset()
	{
		enum136_0 = Enum136.const_7;
		bool_0 = true;
		bool_1 = false;
		bool_2 = false;
		int_0 = -1;
		class487_0 = null;
		class487_1 = null;
	}

	internal Interface3 method_0(string string_0, bool bool_3)
	{
		char[] array = string_0.ToCharArray();
		Interface3 @interface = null;
		Interface3[] array2 = new Interface3[4];
		Class517[] array3 = new Class517[4];
		int num = 0;
		Class509 @class = method_1();
		StringBuilder stringBuilder = new StringBuilder(array.Length);
		int num2 = 0;
		int i = 0;
		while (i < array.Length)
		{
			switch (array[i])
			{
			case '.':
				if (int_0 > -1)
				{
					bool_0 = false;
				}
				else
				{
					int_0 = stringBuilder.Length;
				}
				goto IL_0b15;
			case '/':
				if (enum136_0 == Enum136.const_2)
				{
					enum136_0 = Enum136.const_4;
				}
				else if (i > 1 && i + 2 < array.Length && array[i - 2] == Class1391.char_0[0] && array[i - 1] == Class1391.char_0[1] && array[i + 1] == Class1391.char_1[0] && array[i + 2] == Class1391.char_1[1])
				{
					enum136_0 = Enum136.const_3;
					bool_0 = false;
				}
				goto IL_0b15;
			case '#':
			case '0':
				switch (enum136_0)
				{
				case Enum136.const_7:
				{
					enum136_0 = Enum136.const_2;
					if (!bool_0)
					{
						break;
					}
					bool flag = i == 0;
					bool flag2 = true;
					bool flag3 = true;
					bool flag4 = false;
					if (array[i] == '0')
					{
						if (int_0 > -1)
						{
							flag3 = false;
						}
						else
						{
							flag2 = false;
							flag4 = true;
						}
					}
					else if (int_0 > -1)
					{
						flag4 = true;
					}
					stringBuilder.Append(array[i]);
					i++;
					while (i < array.Length)
					{
						switch (array[i])
						{
						case ',':
							stringBuilder.Append(array[i]);
							i++;
							continue;
						case '.':
							if (int_0 > -1)
							{
								bool_0 = false;
							}
							else
							{
								int_0 = stringBuilder.Length;
								flag4 = false;
							}
							stringBuilder.Append(array[i]);
							i++;
							continue;
						case '0':
							if (int_0 > -1)
							{
								flag3 = false;
								if (flag4)
								{
									bool_0 = false;
								}
							}
							else
							{
								flag4 = true;
								flag2 = false;
							}
							stringBuilder.Append(array[i]);
							i++;
							continue;
						case '#':
							if (int_0 > -1)
							{
								flag4 = true;
							}
							else if (flag4)
							{
								bool_0 = false;
							}
							stringBuilder.Append(array[i]);
							i++;
							continue;
						}
						break;
					}
					if (bool_0 && (flag2 || (int_0 > -1 && flag3)) && (!flag || i < array.Length))
					{
						bool_0 = false;
					}
					goto end_IL_0046;
				}
				case Enum136.const_2:
					bool_0 = false;
					break;
				case Enum136.const_4:
					bool_2 = true;
					break;
				}
				goto IL_0b15;
			case '%':
				bool_0 = false;
				goto IL_0b15;
			case 'T':
				if (Class519.smethod_2(7, short_0))
				{
					enum136_0 = Enum136.const_3;
					stringBuilder.Append('d');
					i++;
					break;
				}
				goto IL_0b15;
			case ';':
				@class.Pattern = new string(array, num2, i - num2);
				@interface = null;
				if (class516_0.method_14() != null)
				{
					object obj2 = class516_0.method_14()[@class.Pattern];
					if (obj2 != null)
					{
						@interface = (Interface3)obj2;
					}
				}
				if (@interface == null)
				{
					@interface = method_2(stringBuilder.ToString(), @class);
					if (bool_3)
					{
						class516_0.method_14().Add(@class.Pattern, @interface);
					}
				}
				stringBuilder.Length = 0;
				@class = method_1();
				Reset();
				array2[num] = @interface;
				num++;
				if (num >= array2.Length)
				{
					i = array.Length;
					break;
				}
				i++;
				num2 = i;
				break;
			case '?':
				switch (enum136_0)
				{
				case Enum136.const_7:
					enum136_0 = Enum136.const_2;
					bool_0 = false;
					break;
				case Enum136.const_4:
					bool_2 = true;
					break;
				}
				goto IL_0b15;
			case '@':
				enum136_0 = Enum136.const_1;
				goto IL_0b15;
			case 'J':
				if (Class519.smethod_2(7, short_0))
				{
					enum136_0 = Enum136.const_3;
					stringBuilder.Append('y');
					i++;
					break;
				}
				goto IL_0b15;
			case 'M':
			case 'm':
			{
				if (enum136_0 == Enum136.const_7)
				{
					enum136_0 = Enum136.const_3;
				}
				stringBuilder.Append(array[i]);
				i++;
				if (!bool_0)
				{
					break;
				}
				int num7 = 1;
				while (i < array.Length)
				{
					char c3 = array[i];
					if (c3 != 'M' && c3 != 'm')
					{
						break;
					}
					stringBuilder.Append(array[i]);
					i++;
					num7++;
				}
				if (num7 == 5)
				{
					bool_0 = false;
				}
				break;
			}
			case '[':
			{
				i++;
				if (i >= array.Length)
				{
					break;
				}
				OperatorType operatorType_ = OperatorType.None;
				int num5;
				double double_;
				switch (array[i])
				{
				case '<':
					i++;
					if (i < array.Length)
					{
						switch (array[i])
						{
						default:
							operatorType_ = OperatorType.LessThan;
							break;
						case '=':
							operatorType_ = OperatorType.LessOrEqual;
							i++;
							break;
						case '>':
							operatorType_ = OperatorType.NotEqual;
							i++;
							break;
						}
					}
					goto IL_0663;
				case '=':
					operatorType_ = OperatorType.Equal;
					i++;
					goto IL_0663;
				case '>':
					i++;
					if (i < array.Length)
					{
						if (array[i] == '=')
						{
							operatorType_ = OperatorType.GreaterOrEqual;
							i++;
						}
						else
						{
							operatorType_ = OperatorType.GreaterThan;
						}
					}
					goto IL_0663;
				default:
				{
					i = @class.method_3(array, i, array.Length, stringBuilder, bool_0: false);
					short num4 = @class.method_2();
					if (num4 == -3072 || num4 == -2048)
					{
						enum136_0 = Enum136.const_3;
					}
					break;
				}
				case 'H':
				case 'M':
				case 'S':
				case 'h':
				case 'm':
				case 's':
					{
						enum136_0 = Enum136.const_3;
						bool_0 = false;
						stringBuilder.Append('[');
						stringBuilder.Append(array[i]);
						i++;
						break;
					}
					IL_0663:
					num5 = i;
					double_ = 0.0;
					for (; i < array.Length; i++)
					{
						if (array[i] == ']')
						{
							try
							{
								double_ = Class1024.smethod_1(new string(array, num5, i - num5).Trim());
							}
							catch
							{
							}
							i++;
							break;
						}
					}
					array3[num] = new Class517(operatorType_, double_);
					break;
				}
				break;
			}
			case '"':
			case '\\':
				i = Class487.smethod_0(array, i, array.Length, stringBuilder);
				break;
			case '*':
			case '_':
				bool_0 = false;
				stringBuilder.Append(array[i]);
				i++;
				goto IL_0b15;
			case 'A':
			case 'a':
				stringBuilder.Append(array[i]);
				i++;
				if (i < array.Length)
				{
					switch (array[i])
					{
					case '/':
						stringBuilder.Append('/');
						i++;
						if (i < array.Length && (array[i] == 'p' || array[i] == 'P'))
						{
							enum136_0 = Enum136.const_3;
							bool_0 = false;
							stringBuilder.Append(array[i]);
							i++;
						}
						break;
					case 'A':
					case 'a':
					{
						stringBuilder.Append(array[i]);
						i++;
						int num3 = 0;
						for (; i < array.Length; i++)
						{
							char c2 = array[i];
							if (c2 != 'A' && c2 != 'a')
							{
								break;
							}
							num3++;
						}
						if (num3 > 0)
						{
							enum136_0 = Enum136.const_3;
							bool_0 = false;
							if (num3 > 1)
							{
								stringBuilder.Append("aa");
							}
							else
							{
								stringBuilder.Append('a');
							}
						}
						break;
					}
					case 'M':
					case 'm':
						if (array[i + 1] == '/' && i + 3 < array.Length && (array[i + 2] == 'p' || array[i + 2] == 'P') && (array[i + 3] == 'm' || array[i + 3] == 'M'))
						{
							enum136_0 = Enum136.const_3;
							bool_0 = false;
							stringBuilder.Append(array, i, 4);
							i += 4;
						}
						break;
					}
				}
				else
				{
					stringBuilder.Append(array[i - 1]);
				}
				break;
			case 'E':
			case 'e':
				if (enum136_0 == Enum136.const_2)
				{
					enum136_0 = Enum136.const_5;
				}
				else if (int_0 < 0)
				{
					enum136_0 = Enum136.const_3;
					stringBuilder.Append("yyyy");
					for (i++; i < array.Length; i++)
					{
						char c4 = array[i];
						if (c4 != 'E' && c4 != 'e')
						{
							break;
						}
					}
					break;
				}
				goto IL_0b15;
			case 'G':
			case 'g':
				if (i + 6 < array.Length && (array[i + 1] == 'e' || array[i + 1] == 'E') && (array[i + 2] == 'n' || array[i + 2] == 'N') && (array[i + 3] == 'e' || array[i + 3] == 'E') && (array[i + 4] == 'r' || array[i + 4] == 'R') && (array[i + 5] == 'a' || array[i + 5] == 'A') && (array[i + 6] == 'l' || array[i + 6] == 'L'))
				{
					if (!bool_1)
					{
						if (stringBuilder.Length > 0)
						{
							class487_0 = method_2(stringBuilder.ToString(), @class);
							stringBuilder.Length = 0;
						}
						enum136_0 = Enum136.const_7;
						bool_1 = true;
					}
					i += 7;
				}
				else if (Class519.smethod_2(16, short_0))
				{
					enum136_0 = Enum136.const_3;
					stringBuilder.Append('d');
					i++;
				}
				else
				{
					int num6 = i;
					for (i++; i < array.Length && (array[i] == 'g' || array[i] == 'G'); i++)
					{
					}
					enum136_0 = Enum136.const_3;
					stringBuilder.Append(Class1180.smethod_2(i - num6, short_0));
				}
				break;
			default:
				if (!bool_2 && enum136_0 == Enum136.const_4 && array[i] >= '0' && array[i] <= '9')
				{
					bool_2 = true;
				}
				goto IL_0b15;
			case 'D':
			case 'H':
			case 'Y':
			case 'd':
			case 'h':
			case 'y':
				if (enum136_0 == Enum136.const_7)
				{
					enum136_0 = Enum136.const_3;
				}
				goto IL_0b15;
			case 'S':
			case 's':
				{
					if (enum136_0 == Enum136.const_7)
					{
						enum136_0 = Enum136.const_3;
					}
					stringBuilder.Append(array[i]);
					for (i++; i < array.Length; i++)
					{
						char c = array[i];
						if (c <= '.')
						{
							if (c != ' ')
							{
								if (c == '.')
								{
									stringBuilder.Append(array[i]);
									i++;
									while (i < array.Length && array[i] == '0')
									{
										bool_0 = false;
										i++;
										stringBuilder.Append('0');
									}
								}
								break;
							}
						}
						else if (c != 'S' && c != 's')
						{
							break;
						}
						stringBuilder.Append(array[i]);
					}
					break;
				}
				IL_0b15:
				stringBuilder.Append(array[i]);
				i++;
				break;
				end_IL_0046:
				break;
			}
		}
		if (num < array2.Length)
		{
			@class.Pattern = ((num == 0) ? string_0 : new string(array, num2, i - num2));
			@interface = null;
			if (class516_0.method_14() != null)
			{
				object obj3 = class516_0.method_14()[@class.Pattern];
				if (obj3 != null)
				{
					@interface = (Interface3)obj3;
				}
			}
			if (@interface == null)
			{
				@interface = method_2(stringBuilder.ToString(), @class);
				if (bool_3)
				{
					class516_0.method_14().Add(@class.Pattern, @interface);
				}
			}
			array2[num] = @interface;
			num++;
		}
		if (num > 1)
		{
			int num8 = -1;
			int num9 = 0;
			for (int j = 0; j < num; j++)
			{
				if (array3[j] == null)
				{
					num8 = j;
					num9++;
				}
			}
			@interface = null;
			switch (num9)
			{
			case 0:
				if (num < array2.Length)
				{
					Interface3[] array6 = new Interface3[num];
					Class517[] array7 = new Class517[num];
					Array.Copy(array2, 0, array6, 0, num);
					Array.Copy(array3, 0, array7, 0, num);
					array2 = array6;
					array3 = array7;
				}
				break;
			case 1:
			{
				@interface = array2[num8];
				Interface3[] array4 = new Interface3[num - 1];
				Class517[] array5 = new Class517[num - 1];
				if (num8 > 0)
				{
					Array.Copy(array2, 0, array4, 0, num8);
					Array.Copy(array3, 0, array5, 0, num8);
				}
				if (num8 < num - 1)
				{
					Array.Copy(array2, num8 + 1, array4, num8, num - num8 - 1);
					Array.Copy(array3, num8 + 1, array5, num8, num - num8 - 1);
				}
				array2 = array4;
				array3 = array5;
				break;
			}
			default:
				switch (num)
				{
				case 2:
					array2 = new Interface3[2]
					{
						array2[0],
						array2[1]
					};
					array3 = new Class517[2]
					{
						new Class517(OperatorType.GreaterOrEqual, 0.0),
						new Class517(OperatorType.LessThan, 0.0)
					};
					break;
				case 3:
					if (array2[2].imethod_0() == Enum136.const_1 && !((Class505)array2[2]).method_4())
					{
						@interface = array2[2];
						array2 = new Interface3[2]
						{
							array2[0],
							array2[1]
						};
						array3 = new Class517[2]
						{
							new Class517(OperatorType.GreaterOrEqual, 0.0),
							new Class517(OperatorType.LessThan, 0.0)
						};
						break;
					}
					if (array2.Length > 3)
					{
						array2 = new Interface3[3]
						{
							array2[0],
							array2[1],
							array2[2]
						};
					}
					array3 = new Class517[3]
					{
						new Class517(OperatorType.GreaterThan, 0.0),
						new Class517(OperatorType.LessThan, 0.0),
						new Class517(OperatorType.Equal, 0.0)
					};
					break;
				case 4:
					@interface = array2[3];
					array3 = new Class517[3]
					{
						new Class517(OperatorType.GreaterThan, 0.0),
						new Class517(OperatorType.LessThan, 0.0),
						new Class517(OperatorType.Equal, 0.0)
					};
					array2 = new Interface3[3]
					{
						array2[0],
						array2[1],
						array2[2]
					};
					break;
				}
				break;
			}
			@class = method_1();
			@class.Pattern = string_0;
			@interface = new Class506(@class, array2, array3, @interface);
			if (bool_3)
			{
				class516_0.method_14().Add(string_0, @interface);
			}
		}
		return @interface;
	}

	private Class509 method_1()
	{
		Class509 @class = new Class509();
		@class.method_1(class516_0);
		return @class;
	}

	private Class487 method_2(string string_0, Class509 class509_0)
	{
		short num = class509_0.method_2();
		if (num != -3072 && num != -2048)
		{
			if (bool_1)
			{
				if (string_0.Length > 0)
				{
					bool_1 = false;
					class487_1 = method_2(string_0, class509_0);
				}
				else if (class487_0 == null && object.Equals(Color.Empty, class509_0.Color))
				{
					return class516_0.method_12();
				}
				return new Class504(class509_0, class487_0, class487_1);
			}
			if (int_0 > -1 && enum136_0 == Enum136.const_7)
			{
				enum136_0 = Enum136.const_2;
			}
			switch (enum136_0)
			{
			default:
				return new Class505(class509_0, string_0);
			case Enum136.const_2:
				if (bool_0 && int_0 > -1)
				{
					if (int_0 != 0 && int_0 != string_0.Length - 1)
					{
						if (!method_3(string_0[int_0 - 1]))
						{
							bool_0 = false;
						}
						else if (!method_3(string_0[int_0 + 1]))
						{
							bool_0 = false;
						}
					}
					else
					{
						bool_0 = false;
					}
				}
				if (bool_0)
				{
					return new Class494(class509_0, string_0);
				}
				return new Class491(class509_0, string_0);
			case Enum136.const_3:
				if (bool_0)
				{
					char[] array = string_0.ToCharArray();
					if (Class487.smethod_2(array, 0, array.Length, 'h', 'H'))
					{
						string_0 = new string(array);
					}
					return new Class503(class509_0, string_0, bool_0: true);
				}
				return new Class502(class509_0, string_0);
			case Enum136.const_4:
				if (bool_2)
				{
					return new Class493(class509_0, string_0);
				}
				if (bool_0)
				{
					return new Class494(class509_0, string_0);
				}
				return new Class491(class509_0, string_0);
			case Enum136.const_5:
				return new Class492(class509_0, string_0);
			}
		}
		return new Class503(class509_0, string_0, bool_0: false);
	}

	private bool method_3(char char_0)
	{
		if (char_0 != '0')
		{
			return char_0 == '#';
		}
		return true;
	}
}
