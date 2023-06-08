using System.Collections;
using System.Text;
using Aspose.Cells;
using ns2;

namespace ns12;

internal class Class1278
{
	private WorksheetCollection worksheetCollection_0;

	private static string string_0 = "Invalid formula:";

	internal Class1278(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	internal Class1661 method_0(string string_1, int int_0)
	{
		Class1127 @class = new Class1127();
		char[] array = string_1.ToCharArray();
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		while (int_0 < array.Length)
		{
			switch (array[int_0])
			{
			case ' ':
			{
				num = int_0;
				for (num = int_0 + 1; num < array.Length && array[num] == ' '; num++)
				{
				}
				bool flag;
				if (!(flag = int_0 == 0))
				{
					switch (array[int_0 - 1])
					{
					case ' ':
					case '%':
					case '&':
					case '(':
					case ')':
					case '*':
					case '+':
					case ',':
					case '-':
					case '/':
					case ':':
					case '<':
					case '=':
					case '>':
					case '^':
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					flag = num == array.Length;
				}
				if (!flag)
				{
					switch (array[num])
					{
					case ' ':
					case '%':
					case '&':
					case '(':
					case ')':
					case '*':
					case '+':
					case ',':
					case '-':
					case '/':
					case ':':
					case '<':
					case '=':
					case '>':
					case '^':
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					@class.method_2(stringBuilder, " ", 15, null);
				}
				int_0 = num - 1;
				break;
			}
			case '"':
				int_0 = method_8(array, stringBuilder, int_0);
				break;
			case '#':
				if (stringBuilder.Length == 0)
				{
					int_0 = method_2(stringBuilder, array, int_0);
				}
				else
				{
					stringBuilder.Append(array[int_0]);
				}
				break;
			case '%':
				if (!@class.method_0(stringBuilder))
				{
					throw new CellsException(ExceptionType.Formula, string_0);
				}
				break;
			case '&':
				@class.method_2(stringBuilder, "&", 2, Class1128.byte_10);
				break;
			case '\'':
				int_0 = method_7(array, stringBuilder, int_0);
				break;
			case '(':
			{
				Class1661 class1661_2 = new Class1661();
				int_0 = method_5(class1661_2, stringBuilder, array, int_0);
				@class.method_3(class1661_2);
				break;
			}
			case '*':
				@class.method_2(stringBuilder, "*", 4, Class1128.byte_7);
				break;
			case '+':
				if (!smethod_0(array, int_0))
				{
					@class.method_1(stringBuilder, "+", bool_0: true);
				}
				break;
			case ',':
				@class.method_2(stringBuilder, ",", 9, null);
				break;
			case '-':
				if (smethod_0(array, int_0))
				{
					stringBuilder.Append(array[int_0]);
				}
				else
				{
					@class.method_1(stringBuilder, "-", bool_0: false);
				}
				break;
			case '/':
				@class.method_2(stringBuilder, "/", 4, Class1128.byte_8);
				break;
			case ':':
				if (stringBuilder.Length != 0 && !method_6(array, int_0, stringBuilder))
				{
					stringBuilder.Append(array[int_0]);
				}
				else
				{
					@class.method_2(stringBuilder, ":", 17, null);
				}
				break;
			case '<':
				if (int_0 + 1 != array.Length)
				{
					switch (array[int_0 + 1])
					{
					default:
						@class.method_2(stringBuilder, "<", 1, Class1128.byte_11);
						break;
					case '=':
						@class.method_2(stringBuilder, "<=", 1, Class1128.byte_12);
						int_0++;
						break;
					case '>':
						@class.method_2(stringBuilder, "<>", 1, Class1128.byte_16);
						int_0++;
						break;
					}
				}
				break;
			case '=':
				@class.method_2(stringBuilder, "=", 1, Class1128.byte_13);
				break;
			case '>':
				if (int_0 + 1 != array.Length && array[int_0 + 1] == '=')
				{
					@class.method_2(stringBuilder, ">=", 1, Class1128.byte_14);
					int_0++;
				}
				else
				{
					@class.method_2(stringBuilder, ">", 1, Class1128.byte_15);
				}
				break;
			default:
				stringBuilder.Append(array[int_0]);
				break;
			case '{':
				if (stringBuilder.Length == 0)
				{
					Class1661 class1661_ = new Class1661();
					int_0 = method_3(class1661_, array, int_0);
					@class.method_3(class1661_);
					break;
				}
				throw new CellsException(ExceptionType.Formula, string_0);
			case '^':
				@class.method_2(stringBuilder, "^", 5, Class1128.byte_9);
				break;
			case '[':
				int_0 = method_1(stringBuilder, array, int_0);
				break;
			case '\n':
			case '\r':
				break;
			}
			int_0++;
		}
		if (stringBuilder.Length != 0)
		{
			@class.method_4(stringBuilder);
		}
		switch (@class.Count)
		{
		default:
		{
			Class1661[] array2 = new Class1661[@class.Count];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = @class[i];
			}
			return method_10(array2, 0, array2.Length - 1, 1);
		}
		case 0:
			return null;
		case 1:
			return @class[0];
		}
	}

	private static bool smethod_0(char[] char_0, int int_0)
	{
		if (int_0 - 1 > 0 && (char_0[int_0 - 1] == 'E' || char_0[int_0 - 1] == 'e'))
		{
			return char.IsDigit(char_0[int_0 - 2]);
		}
		return false;
	}

	private int method_1(StringBuilder stringBuilder_0, char[] char_0, int int_0)
	{
		int num = 1;
		stringBuilder_0.Append(char_0[int_0]);
		for (int_0++; int_0 < char_0.Length; int_0++)
		{
			switch (char_0[int_0])
			{
			case '[':
				stringBuilder_0.Append(char_0[int_0]);
				num++;
				break;
			default:
				stringBuilder_0.Append(char_0[int_0]);
				break;
			case ']':
				stringBuilder_0.Append(char_0[int_0]);
				num--;
				if (num == 0)
				{
					return int_0;
				}
				break;
			case '\'':
				int_0 = method_7(char_0, stringBuilder_0, int_0);
				break;
			case '"':
				int_0 = method_8(char_0, stringBuilder_0, int_0);
				break;
			}
		}
		return int_0;
	}

	private int method_2(StringBuilder stringBuilder_0, char[] char_0, int int_0)
	{
		switch (char_0[int_0 + 1])
		{
		case 'N':
			switch (char_0[int_0 + 2])
			{
			case 'U':
				if (char_0[int_0 + 3] == 'L' && char_0[int_0 + 4] == 'L' && char_0[int_0 + 5] == '!')
				{
					stringBuilder_0.Append("#NULL!");
					int_0 += 5;
					return int_0;
				}
				if (char_0[int_0 + 3] == 'M' && char_0[int_0 + 4] == '!')
				{
					stringBuilder_0.Append("#NUM!");
					int_0 += 4;
					return int_0;
				}
				break;
			case 'A':
				if (char_0[int_0 + 3] == 'M' && char_0[int_0 + 4] == 'E' && char_0[int_0 + 5] == '?')
				{
					stringBuilder_0.Append("#NAME?");
					int_0 += 5;
					return int_0;
				}
				break;
			case '/':
				if (char_0[int_0 + 3] == 'A')
				{
					stringBuilder_0.Append("#N/A");
					int_0 += 3;
					return int_0;
				}
				break;
			}
			goto default;
		case 'D':
			if (char_0[int_0 + 2] == 'I' && char_0[int_0 + 3] == 'V' && char_0[int_0 + 4] == '/' && char_0[int_0 + 5] == '0' && char_0[int_0 + 6] == '!')
			{
				stringBuilder_0.Append("#DIV/0!");
				int_0 += 6;
				return int_0;
			}
			goto default;
		case 'V':
			if (char_0[int_0 + 2] == 'A' && char_0[int_0 + 3] == 'L' && char_0[int_0 + 4] == 'U' && char_0[int_0 + 5] == 'E' && char_0[int_0 + 6] == '!')
			{
				stringBuilder_0.Append("#VALUE!");
				int_0 += 6;
				return int_0;
			}
			goto default;
		case 'R':
			if (char_0[int_0 + 2] == 'E' && char_0[int_0 + 3] == 'F' && char_0[int_0 + 4] == '!')
			{
				stringBuilder_0.Append("#REF!");
				int_0 += 4;
				return int_0;
			}
			goto default;
		default:
			throw new CellsException(ExceptionType.Formula, string_0);
		}
	}

	private int method_3(Class1661 class1661_0, char[] char_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		int_0 = method_4(arrayList, char_0, int_0);
		int num = -1;
		int num2 = 0;
		Class1661[][] array;
		while (true)
		{
			if (num2 < arrayList.Count)
			{
				ArrayList arrayList2 = (ArrayList)arrayList[num2];
				if (num == -1)
				{
					num = arrayList2.Count;
				}
				else if (arrayList2.Count != num)
				{
					throw new CellsException(ExceptionType.Formula, "Invalid formula");
				}
				num2++;
				continue;
			}
			class1661_0.method_4("{}");
			class1661_0.Type = Enum180.const_0;
			array = new Class1661[arrayList.Count][];
			for (int i = 0; i < array.Length; i++)
			{
				ArrayList arrayList3 = (ArrayList)arrayList[i];
				array[i] = new Class1661[arrayList3.Count];
				for (int j = 0; j < arrayList3.Count; j++)
				{
					string string_ = (string)arrayList3[j];
					Class1661 @class = new Class1661();
					@class.method_6(class1661_0);
					@class.method_4(string_);
					@class.Type = Enum180.const_1;
					array[i][j] = @class;
				}
			}
			break;
		}
		class1661_0.method_2(array);
		return int_0;
	}

	private int method_4(ArrayList arrayList_0, char[] char_0, int int_0)
	{
		ArrayList arrayList = new ArrayList();
		arrayList_0.Add(arrayList);
		StringBuilder stringBuilder = new StringBuilder();
		for (int_0++; int_0 < char_0.Length; int_0++)
		{
			switch (char_0[int_0])
			{
			case '"':
				int_0 = method_8(char_0, stringBuilder, int_0);
				break;
			case ',':
				arrayList.Add(stringBuilder.ToString());
				stringBuilder.Remove(0, stringBuilder.Length);
				break;
			case '\'':
				int_0 = method_7(char_0, stringBuilder, int_0);
				break;
			default:
				stringBuilder.Append(char_0[int_0]);
				break;
			case ';':
				arrayList.Add(stringBuilder.ToString());
				stringBuilder.Remove(0, stringBuilder.Length);
				arrayList = new ArrayList();
				arrayList_0.Add(arrayList);
				break;
			case '\n':
			case '\r':
				break;
			case '}':
				arrayList.Add(stringBuilder.ToString());
				stringBuilder.Remove(0, stringBuilder.Length);
				return int_0;
			}
		}
		return int_0;
	}

	private int method_5(Class1661 class1661_0, StringBuilder stringBuilder_0, char[] char_0, int int_0)
	{
		if (stringBuilder_0.Length == 0)
		{
			class1661_0.method_4("()");
			class1661_0.Type = Enum180.const_7;
		}
		else
		{
			class1661_0.Type = Enum180.const_3;
			class1661_0.method_4(stringBuilder_0.ToString().ToUpper());
			class1661_0.string_2 = stringBuilder_0.ToString();
			stringBuilder_0.Remove(0, stringBuilder_0.Length);
		}
		Class1127 @class = new Class1127();
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		int num2 = 0;
		int num3 = int_0;
		for (int_0++; int_0 < char_0.Length; int_0++)
		{
			switch (char_0[int_0])
			{
			case ' ':
			{
				num = int_0;
				int num4 = int_0;
				num = int_0 - 1;
				while (num >= 0 && (char_0[num] == '\r' || char_0[num] == '\n'))
				{
					int_0--;
					num--;
				}
				for (num = num4 + 1; num < char_0.Length && (char_0[num] == ' ' || char_0[num] == '\r' || char_0[num] == '\n'); num++)
				{
				}
				num2 += num - int_0;
				bool flag;
				if (!(flag = int_0 == 0))
				{
					switch (char_0[int_0 - 1])
					{
					case ' ':
					case '%':
					case '&':
					case '(':
					case ')':
					case '*':
					case '+':
					case ',':
					case '-':
					case '/':
					case ':':
					case '<':
					case '=':
					case '>':
					case '^':
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					flag = num == char_0.Length;
				}
				if (!flag)
				{
					switch (char_0[num])
					{
					case ' ':
					case '%':
					case '&':
					case '(':
					case ')':
					case '*':
					case '+':
					case ',':
					case '-':
					case '/':
					case ':':
					case '<':
					case '=':
					case '>':
					case '^':
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					@class.method_2(stringBuilder, " ", 15, null);
				}
				int_0 = num - 1;
				break;
			}
			case '"':
				int_0 = method_8(char_0, stringBuilder, int_0);
				break;
			case '#':
				if (stringBuilder.Length == 0)
				{
					int_0 = method_2(stringBuilder, char_0, int_0);
				}
				else
				{
					stringBuilder.Append(char_0[int_0]);
				}
				break;
			case '%':
				if (!@class.method_0(stringBuilder))
				{
					throw new CellsException(ExceptionType.Formula, string_0);
				}
				break;
			case '&':
				@class.method_2(stringBuilder, "&", 2, Class1128.byte_10);
				break;
			case '\'':
				int_0 = method_7(char_0, stringBuilder, int_0);
				break;
			case '(':
			{
				Class1661 class1661_2 = new Class1661();
				int_0 = method_5(class1661_2, stringBuilder, char_0, int_0);
				@class.method_3(class1661_2);
				break;
			}
			case '*':
				@class.method_2(stringBuilder, "*", 4, Class1128.byte_7);
				break;
			case '+':
				if (!smethod_0(char_0, int_0))
				{
					@class.method_1(stringBuilder, "+", bool_0: true);
				}
				break;
			case ',':
				if (stringBuilder.Length != 0)
				{
					@class.method_4(stringBuilder);
				}
				else if (num3 + num2 + 1 == int_0)
				{
					Class1661 class3 = new Class1661();
					class3.Type = Enum180.const_1;
					class1661_0.method_1(class3);
					num3 = int_0;
					num2 = 0;
					break;
				}
				num3 = int_0;
				num2 = 0;
				if (@class.Count != 0)
				{
					class1661_0.method_1(method_9(@class));
					@class.Clear();
				}
				break;
			case '-':
				if (smethod_0(char_0, int_0))
				{
					stringBuilder.Append(char_0[int_0]);
				}
				else
				{
					@class.method_1(stringBuilder, "-", bool_0: false);
				}
				break;
			case '/':
				@class.method_2(stringBuilder, "/", 4, Class1128.byte_8);
				break;
			case ':':
				if (stringBuilder.Length != 0 && !method_6(char_0, int_0, stringBuilder))
				{
					stringBuilder.Append(char_0[int_0]);
				}
				else
				{
					@class.method_2(stringBuilder, ":", 17, null);
				}
				break;
			case '<':
				if (int_0 + 1 != char_0.Length)
				{
					switch (char_0[int_0 + 1])
					{
					default:
						@class.method_2(stringBuilder, "<", 1, Class1128.byte_11);
						break;
					case '=':
						@class.method_2(stringBuilder, "<=", 1, Class1128.byte_12);
						int_0++;
						break;
					case '>':
						@class.method_2(stringBuilder, "<>", 1, Class1128.byte_16);
						int_0++;
						break;
					}
				}
				break;
			case '=':
				@class.method_2(stringBuilder, "=", 1, Class1128.byte_13);
				break;
			case '>':
				if (int_0 + 1 != char_0.Length && char_0[int_0 + 1] == '=')
				{
					@class.method_2(stringBuilder, ">=", 1, Class1128.byte_14);
					int_0++;
				}
				else
				{
					@class.method_2(stringBuilder, ">", 1, Class1128.byte_15);
				}
				break;
			default:
				stringBuilder.Append(char_0[int_0]);
				break;
			case '{':
				if (stringBuilder.Length == 0)
				{
					Class1661 class1661_ = new Class1661();
					int_0 = method_3(class1661_, char_0, int_0);
					@class.method_3(class1661_);
					break;
				}
				throw new CellsException(ExceptionType.Formula, string_0);
			case '^':
				@class.method_2(stringBuilder, "^", 5, Class1128.byte_9);
				break;
			case '[':
				int_0 = method_1(stringBuilder, char_0, int_0);
				break;
			case '\n':
			case '\r':
				break;
			case ')':
				if (stringBuilder.Length != 0)
				{
					@class.method_4(stringBuilder);
				}
				else if (num3 + num2 + 1 == int_0 && char_0[num3] == ',')
				{
					Class1661 class2 = new Class1661();
					class2.Type = Enum180.const_1;
					class1661_0.method_1(class2);
					if (class1661_0.Type == Enum180.const_7 && class1661_0.method_7().Count == 1)
					{
						class1661_0.Type = Enum180.const_1;
					}
					return int_0;
				}
				if (@class.Count != 0)
				{
					class1661_0.method_1(method_9(@class));
				}
				if (class1661_0.Type == Enum180.const_7 && class1661_0.method_7().Count == 1)
				{
					class1661_0.Type = Enum180.const_1;
				}
				return int_0;
			}
		}
		if (class1661_0.Type == Enum180.const_7 && class1661_0.method_7().Count == 1)
		{
			class1661_0.Type = Enum180.const_1;
		}
		return int_0;
	}

	internal bool method_6(char[] char_0, int int_0, StringBuilder stringBuilder_0)
	{
		for (int_0++; int_0 < char_0.Length; int_0++)
		{
			switch (char_0[int_0])
			{
			case '!':
			case '\'':
				return worksheetCollection_0.method_6()[stringBuilder_0.ToString().ToUpper()] == null;
			case '"':
			case '(':
			case ':':
				return true;
			case ' ':
			case '%':
			case '&':
			case ')':
			case '*':
			case '+':
			case ',':
			case '-':
			case '/':
			case '<':
			case '=':
			case '>':
			case '^':
			case '{':
			case '}':
				return false;
			}
		}
		return false;
	}

	internal int method_7(char[] char_0, StringBuilder stringBuilder_0, int int_0)
	{
		stringBuilder_0.Append(char_0[int_0]);
		for (int_0++; int_0 < char_0.Length; int_0++)
		{
			stringBuilder_0.Append(char_0[int_0]);
			if (char_0[int_0] == '\'')
			{
				if (int_0 + 1 == char_0.Length || char_0[int_0 + 1] != '\'')
				{
					break;
				}
				int_0++;
			}
		}
		return int_0;
	}

	internal int method_8(char[] char_0, StringBuilder stringBuilder_0, int int_0)
	{
		stringBuilder_0.Append(char_0[int_0]);
		for (int_0++; int_0 < char_0.Length; int_0++)
		{
			stringBuilder_0.Append(char_0[int_0]);
			if (char_0[int_0] == '"')
			{
				if (int_0 + 1 == char_0.Length || char_0[int_0 + 1] != '"')
				{
					break;
				}
				int_0++;
			}
		}
		if (int_0 == char_0.Length)
		{
			throw new CellsException(ExceptionType.Formula, string_0);
		}
		return int_0;
	}

	internal Class1661 method_9(Class1127 class1127_0)
	{
		switch (class1127_0.Count)
		{
		default:
		{
			Class1661[] array = new Class1661[class1127_0.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = class1127_0[i];
			}
			return method_10(array, 0, array.Length - 1, 1);
		}
		case 0:
			return null;
		case 1:
			return class1127_0[0];
		}
	}

	internal Class1661 method_10(Class1661[] class1661_0, int int_0, int int_1, int int_2)
	{
		int num = 255;
		int num2 = -1;
		for (int num3 = int_1; num3 >= int_0; num3--)
		{
			Class1661 @class = class1661_0[num3];
			if (@class.Type == Enum180.const_2)
			{
				if (@class.int_0 == int_2)
				{
					num = int_2;
					num2 = num3;
					break;
				}
				if (@class.int_0 < num)
				{
					num = @class.int_0;
					num2 = num3;
				}
			}
		}
		if (num2 != -1)
		{
			Class1661 class2 = class1661_0[num2];
			if (num2 - 1 == int_0)
			{
				class2.method_1(class1661_0[num2 - 1]);
			}
			else
			{
				class2.method_1(method_10(class1661_0, int_0, num2 - 1, num));
			}
			if (num2 + 1 == int_1)
			{
				class2.method_1(class1661_0[num2 + 1]);
			}
			else
			{
				class2.method_1(method_10(class1661_0, num2 + 1, int_1, num));
			}
			return class2;
		}
		return class1661_0[int_0];
	}
}
