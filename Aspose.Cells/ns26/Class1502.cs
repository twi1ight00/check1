using System.Collections;
using System.Drawing;
using ns12;
using ns15;

namespace ns26;

internal class Class1502
{
	internal string string_0;

	internal bool bool_0;

	internal int int_0;

	internal Enum214 enum214_0;

	internal ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal static string[] string_1 = new string[2] { "style", "long" };

	internal bool bool_1;

	internal Class1502()
	{
		enum214_0 = Enum214.const_7;
		arrayList_1 = new ArrayList();
		arrayList_0 = new ArrayList();
	}

	internal static int smethod_0(char[] char_0, char char_1, int int_1)
	{
		int_1++;
		while (true)
		{
			if (int_1 < char_0.Length)
			{
				char c = char_0[int_1];
				if (c == char_1)
				{
					break;
				}
				int_1++;
				continue;
			}
			return int_1;
		}
		return int_1;
	}

	internal static int smethod_1(char[] char_0, char char_1, int int_1)
	{
		int_1++;
		while (true)
		{
			if (int_1 < char_0.Length)
			{
				char c = char_0[int_1];
				if (c != char_1)
				{
					break;
				}
				int_1++;
				continue;
			}
			return int_1;
		}
		return int_1;
	}

	internal static int smethod_2(char[] char_0, char char_1, int int_1)
	{
		int_1++;
		while (true)
		{
			if (int_1 < char_0.Length)
			{
				char c = char_0[int_1];
				if (c != char_1 && c + 32 != char_1)
				{
					break;
				}
				int_1++;
				continue;
			}
			return int_1;
		}
		return int_1;
	}

	internal static int smethod_3(char[] char_0, int int_1, ref bool bool_2, ref bool bool_3, ref int int_2, ref int int_3)
	{
		while (int_1 < char_0.Length)
		{
			switch (char_0[int_1])
			{
			case ',':
				bool_2 = true;
				break;
			case '0':
				int_2++;
				int_3++;
				break;
			case '#':
				int_3++;
				break;
			case '.':
				bool_3 = true;
				return int_1;
			default:
				return int_1;
			}
			int_1++;
		}
		return int_1;
	}

	internal static int smethod_4(char[] char_0, int int_1, ref int int_2, ref bool bool_2)
	{
		while (int_1 < char_0.Length)
		{
			switch (char_0[int_1])
			{
			case '0':
				int_2++;
				bool_2 = false;
				break;
			case '#':
				int_2++;
				break;
			default:
				return int_1;
			}
			int_1++;
		}
		return int_1;
	}

	internal static int smethod_5(char[] char_0, int int_1, ref int int_2)
	{
		while (int_1 < char_0.Length)
		{
			switch (char_0[int_1])
			{
			case '#':
			case '0':
				int_2++;
				break;
			case '+':
			case '-':
				break;
			default:
				return int_1;
			}
			int_1++;
		}
		return int_1;
	}

	internal void method_0(string string_2, int int_1, string string_3)
	{
		arrayList_1 = new ArrayList();
		string_0 = string_2;
		int_0 = int_1;
		char[] array = string_3.ToCharArray();
		Class1506 @class = null;
		int num = -1;
		string text = null;
		int int_2 = 0;
		int int_3 = 0;
		int int_4 = 0;
		bool bool_ = false;
		bool bool_2 = false;
		for (int i = 0; i < array.Length; i++)
		{
			char c = array[i];
			switch (c)
			{
			case '?':
				num = smethod_0(array, '/', i);
				if (num < array.Length)
				{
					enum214_0 = Enum214.const_1;
					@class = new Class1506(Enum213.const_13, null);
					@class.arrayList_0.Add(new string[2]
					{
						"min-numerator-digits",
						Class1516.smethod_13(num - i)
					});
					i = num;
					num = smethod_1(array, '?', num);
					@class.arrayList_0.Add(new string[2]
					{
						"min-denominator-digits",
						Class1516.smethod_13(num - i)
					});
					arrayList_1.Add(@class);
					i = num - 1;
				}
				break;
			case '@':
				if (enum214_0 == Enum214.const_7)
				{
					enum214_0 = Enum214.const_5;
				}
				@class = new Class1506(Enum213.const_1, null);
				arrayList_1.Add(@class);
				break;
			case '.':
				if (enum214_0 == Enum214.const_7)
				{
					enum214_0 = Enum214.const_1;
				}
				if (enum214_0 != Enum214.const_2 && enum214_0 != Enum214.const_3)
				{
					num = smethod_4(array, i + 1, ref int_2, ref bool_2);
					if (@class == null)
					{
						@class = new Class1506(Enum213.const_4, null);
						arrayList_1.Add(@class);
						@class.arrayList_0.Add(new string[2] { "min-integer-digits", "0" });
					}
					@class.arrayList_0.Add(new string[2]
					{
						"decimal-places",
						Class1516.smethod_13(int_2)
					});
					if (bool_2)
					{
						@class.arrayList_0.Add(new string[2] { "decimal-replacement", "" });
					}
					i = num - 1;
				}
				else
				{
					@class = new Class1506(Enum213.const_0, ".");
					arrayList_1.Add(@class);
				}
				break;
			case '"':
				num = smethod_0(array, c, i);
				@class = new Class1506(Enum213.const_0, string_3.Substring(i + 1, num - i - 1));
				arrayList_1.Add(@class);
				i = num;
				break;
			case '#':
			case '0':
			{
				bool bool_3 = false;
				if (enum214_0 == Enum214.const_7)
				{
					enum214_0 = Enum214.const_1;
				}
				num = smethod_3(array, i, ref bool_, ref bool_3, ref int_3, ref int_4);
				@class = new Class1506(Enum213.const_4, null);
				arrayList_1.Add(@class);
				@class.arrayList_0.Add(new string[2]
				{
					"min-integer-digits",
					Class1516.smethod_13(int_3)
				});
				if (bool_)
				{
					@class.arrayList_0.Add(new string[2] { "grouping", "true" });
				}
				if (!bool_3)
				{
					@class.arrayList_0.Insert(0, new string[2] { "decimal-places", "0" });
				}
				i = num - 1;
				break;
			}
			case '%':
				enum214_0 = Enum214.const_6;
				@class = new Class1506(Enum213.const_0, "%");
				arrayList_1.Add(@class);
				break;
			case '[':
				num = smethod_0(array, ']', i);
				text = string_3.Substring(i + 1, num - i - 1);
				if (text.Length == 1 && (text[0] == 'H' || text[0] == 'h'))
				{
					arrayList_0.Add(new string[2] { "number:truncate-on-overflow", "false" });
					@class = new Class1506(Enum213.const_9, null);
					arrayList_1.Add(@class);
				}
				else if (text[0] != '$' && Class740.smethod_3(text.ToLower()))
				{
					Color color_ = Color.FromName(text);
					if (!color_.IsEmpty)
					{
						@class = new Class1506(Enum213.const_2, null);
						@class.arrayList_0.Add(new string[2]
						{
							"color",
							Class1516.smethod_9(color_)
						});
						arrayList_1.Add(@class);
					}
				}
				i = num;
				break;
			case '\\':
				i++;
				if (i < string_3.Length)
				{
					@class = new Class1506(Enum213.const_0, "" + string_3[i]);
					arrayList_1.Add(@class);
				}
				break;
			case '_':
				i++;
				if (@class != null && @class.enum213_0 == Enum213.const_0)
				{
					@class.string_0 += " ";
					break;
				}
				@class = new Class1506(Enum213.const_0, " ");
				arrayList_1.Add(@class);
				break;
			case 'A':
			case 'a':
				if (i != array.Length - 1 && (array[i + 1] == 'M' || array[i + 1] == 'm'))
				{
					@class = new Class1506(Enum213.const_12, null);
					arrayList_1.Add(@class);
					i += 4;
				}
				else
				{
					@class = new Class1506(Enum213.const_0, c.ToString());
					arrayList_1.Add(@class);
				}
				break;
			case 'D':
			case 'd':
			{
				num = smethod_2(array, 'd', i);
				enum214_0 = Enum214.const_2;
				int num2 = num - i;
				int num3 = num2;
				@class = ((num3 != 4) ? new Class1506(Enum213.const_8, null) : new Class1506(Enum213.const_15, null));
				if (num - i >= 2)
				{
					@class.arrayList_0.Add(string_1);
				}
				arrayList_1.Add(@class);
				i = num - 1;
				break;
			}
			case 'E':
			case 'e':
				if (@class == null)
				{
					@class = new Class1506(Enum213.const_0, c.ToString());
					arrayList_1.Add(@class);
				}
				else
				{
					@class.enum213_0 = Enum213.const_14;
					int int_5 = 0;
					num = smethod_5(array, i + 1, ref int_5);
					@class.arrayList_0.Add(new string[2]
					{
						"min-exponent-digits",
						Class1516.smethod_13(int_5)
					});
				}
				if (int_4 != int_3)
				{
					for (int j = 0; j < @class.arrayList_0.Count; j++)
					{
						string[] array2 = (string[])@class.arrayList_0[j];
						if (array2[0] == "min-integer-digits")
						{
							@class.arrayList_0.RemoveAt(j);
							@class.arrayList_0.Add(new string[2]
							{
								"min-integer-digits",
								Class1516.smethod_13(int_4)
							});
							break;
						}
					}
				}
				i = num - 1;
				break;
			case 'S':
			case 's':
				num = smethod_2(array, 's', i);
				@class = new Class1506(Enum213.const_11, null);
				if (enum214_0 == Enum214.const_7)
				{
					enum214_0 = Enum214.const_3;
				}
				if (num - i >= 2)
				{
					@class.arrayList_0.Add(string_1);
				}
				i = num;
				if (num != array.Length && array[num] == '.')
				{
					num = smethod_1(array, '0', i);
					@class.arrayList_0.Add(new string[2]
					{
						"decimal-places",
						Class1516.smethod_13(num - i - 1)
					});
				}
				arrayList_1.Add(@class);
				i = num - 1;
				break;
			case 'M':
			case 'm':
				num = smethod_2(array, 'm', i);
				if ((num < array.Length && array[num] == ':') || (i != 0 && array[i - 1] == ':') || enum214_0 == Enum214.const_3)
				{
					if (enum214_0 == Enum214.const_7)
					{
						enum214_0 = Enum214.const_3;
					}
					@class = new Class1506(Enum213.const_10, null);
					if (num - i >= 2)
					{
						@class.arrayList_0.Add(string_1);
					}
					arrayList_1.Add(@class);
				}
				else
				{
					enum214_0 = Enum214.const_2;
					@class = new Class1506(Enum213.const_7, null);
					switch (num - i)
					{
					case 2:
						@class.arrayList_0.Add(string_1);
						break;
					case 3:
						@class.arrayList_0.Add(new string[2] { "textual", "true" });
						break;
					default:
						@class.arrayList_0.Add(new string[2] { "textual", "true" });
						@class.arrayList_0.Add(string_1);
						break;
					case 5:
						@class.arrayList_0.Add(new string[2] { "textual", "true" });
						break;
					case 1:
						break;
					}
					arrayList_1.Add(@class);
				}
				i = num - 1;
				break;
			case 'H':
			case 'h':
				num = smethod_2(array, 'h', i);
				@class = new Class1506(Enum213.const_9, null);
				if (enum214_0 == Enum214.const_7)
				{
					enum214_0 = Enum214.const_3;
				}
				if (num - i >= 2)
				{
					@class.arrayList_0.Add(string_1);
				}
				arrayList_1.Add(@class);
				i = num - 1;
				break;
			case 'Y':
			case 'y':
				num = smethod_2(array, 'y', i);
				enum214_0 = Enum214.const_2;
				@class = new Class1506(Enum213.const_6, null);
				if (num - i > 2)
				{
					@class.arrayList_0.Add(string_1);
				}
				arrayList_1.Add(@class);
				i = num - 1;
				break;
			default:
				if (@class != null && @class.enum213_0 == Enum213.const_0)
				{
					@class.string_0 += c;
					break;
				}
				@class = new Class1506(Enum213.const_0, c.ToString());
				arrayList_1.Add(@class);
				break;
			case '$':
			case '€':
			case '￡':
			case '￥':
				@class = new Class1506(Enum213.const_3, c.ToString());
				arrayList_1.Add(@class);
				enum214_0 = Enum214.const_0;
				break;
			case '*':
				break;
			}
		}
	}

	internal void method_1(int int_1)
	{
		bool_0 = true;
		int_0 = int_1;
		string_0 = "N" + int_1;
	}

	internal void method_2(int int_1)
	{
		bool_1 = true;
		Class1506 @class = null;
		string text = "condition";
		string text2 = "apply-style-name";
		switch (int_1)
		{
		case 2:
			@class = new Class1506(Enum213.const_5, null);
			@class.arrayList_0.Add(new string[2] { text, "value()>=0" });
			@class.arrayList_0.Add(new string[2]
			{
				text2,
				"N" + int_0 + "P" + 0
			});
			arrayList_1.Add(@class);
			break;
		case 3:
		case 4:
			@class = new Class1506(Enum213.const_5, null);
			@class.arrayList_0.Add(new string[2] { text, "value()>0" });
			@class.arrayList_0.Add(new string[2]
			{
				text2,
				"N" + int_0 + "P" + 0
			});
			arrayList_1.Add(@class);
			@class = new Class1506(Enum213.const_5, null);
			@class.arrayList_0.Add(new string[2] { text, "value()<0" });
			@class.arrayList_0.Add(new string[2]
			{
				text2,
				"N" + int_0 + "P" + 1
			});
			arrayList_1.Add(@class);
			if (int_1 == 4)
			{
				@class = new Class1506(Enum213.const_5, null);
				@class.arrayList_0.Add(new string[2] { text, "value()=0" });
				@class.arrayList_0.Add(new string[2]
				{
					text2,
					"N" + int_0 + "P" + 2
				});
				arrayList_1.Add(@class);
			}
			break;
		}
	}
}
