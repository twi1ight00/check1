using System;
using System.Drawing;
using System.Text;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns25;

internal class Class1619
{
	internal static string[] smethod_0(string string_0)
	{
		string[] array = new string[3];
		int num = 1;
		int num2 = 0;
		for (int i = 0; i < string_0.Length; i++)
		{
			if (string_0[i] != '&' || i + 1 >= string_0.Length)
			{
				continue;
			}
			char c = string_0[i + 1];
			if (c <= 'R')
			{
				if (c != 'C')
				{
					if (c != 'L')
					{
						if (c != 'R')
						{
							continue;
						}
						goto IL_005e;
					}
					goto IL_0063;
				}
			}
			else if (c != 'c')
			{
				if (c != 'l')
				{
					if (c != 'r')
					{
						continue;
					}
					goto IL_005e;
				}
				goto IL_0063;
			}
			int num3 = 1;
			goto IL_006b;
			IL_0063:
			num3 = 0;
			goto IL_006b;
			IL_006b:
			if (i - num2 > 0)
			{
				array[num] = string_0.Substring(num2, i - num2);
			}
			num = num3;
			num2 = i + 2;
			continue;
			IL_005e:
			num3 = 2;
			goto IL_006b;
		}
		if (num2 < string_0.Length)
		{
			array[num] = string_0.Substring(num2);
		}
		return array;
	}

	public static string smethod_1(Color color_0)
	{
		StringBuilder stringBuilder = new StringBuilder(8);
		stringBuilder.Append('#');
		stringBuilder.Append(Class1025.smethod_5(color_0.R));
		stringBuilder.Append(Class1025.smethod_5(color_0.G));
		stringBuilder.Append(Class1025.smethod_5(color_0.B));
		return stringBuilder.ToString();
	}

	public static string smethod_2(Cell cell_0)
	{
		Class1667 @class = new Class1667(cell_0.method_4().method_19());
		return @class.method_0(cell_0);
	}

	public static string[] smethod_3(FormatCondition formatCondition_0)
	{
		formatCondition_0.method_11();
		Class1667 @class = new Class1667(formatCondition_0.formatConditionCollection_0.conditionalFormattingCollection_0.worksheet_0.method_2());
		if (formatCondition_0.formatConditionCollection_0.RangeCount == 0)
		{
			return null;
		}
		int[] array = formatCondition_0.formatConditionCollection_0.method_9();
		int int_ = array[0];
		int int_2 = array[1];
		string[] array2 = new string[2];
		if (formatCondition_0.method_0() != null)
		{
			byte[] byte_ = formatCondition_0.method_0();
			array2[0] = @class.method_1(-1, byte_, int_, int_2, bool_0: true);
		}
		if (formatCondition_0.method_4() != null && (formatCondition_0.Operator == OperatorType.Between || formatCondition_0.Operator == OperatorType.NotBetween))
		{
			byte[] byte_2 = formatCondition_0.method_4();
			array2[1] = @class.method_1(-1, byte_2, int_, int_2, bool_0: true);
		}
		return array2;
	}

	public static string[] smethod_4(Validation validation_0, Worksheet worksheet_0)
	{
		int row = 0;
		int column = 0;
		validation_0.method_12(out row, out column);
		Class1667 @class = new Class1667(worksheet_0.method_2());
		if (validation_0.AreaList.Count == 0)
		{
			return null;
		}
		string[] array = new string[2];
		if (validation_0.method_7() != null)
		{
			byte[] byte_ = validation_0.method_7();
			array[0] = @class.method_1(0, byte_, row, column, bool_0: true);
		}
		if (validation_0.method_9() != null)
		{
			byte[] byte_2 = validation_0.method_9();
			array[1] = @class.method_1(0, byte_2, row, column, bool_0: true);
		}
		return array;
	}

	public static string smethod_5(Name name_0, WorksheetCollection worksheetCollection_0)
	{
		Class1667 @class = new Class1667(worksheetCollection_0);
		if (name_0.method_2() != null)
		{
			return @class.method_2(-1, -1, name_0.method_2(), 0, 0, bool_0: true);
		}
		return null;
	}

	public static string smethod_6(string string_0, int int_0, int int_1)
	{
		if (string_0.StartsWith("=#"))
		{
			if (string_0.StartsWith("=#NULL!"))
			{
				return "=#NULL!";
			}
			if (string_0.StartsWith("=#DIV/0!"))
			{
				return "=#DIV/0!";
			}
			if (string_0.StartsWith("=#VALUE!"))
			{
				return "=#VALUE!";
			}
			if (string_0.StartsWith("=#REF!"))
			{
				return "=#REF!";
			}
			if (string_0.StartsWith("=#NAME?"))
			{
				return "=#NAME?";
			}
			if (string_0.StartsWith("=#NUM!"))
			{
				return "=#NUM!";
			}
			if (string_0.StartsWith("=#N/A"))
			{
				return "=#N/A";
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < string_0.Length; i++)
		{
			char c = string_0[i];
			if (c == '"')
			{
				for (i++; i < string_0.Length && string_0[i] != '"'; i++)
				{
				}
			}
			else
			{
				if (!char.IsDigit(c))
				{
					continue;
				}
				bool flag = false;
				int num3 = num;
				int num4 = string_0.Length - 1;
				for (int j = i + 1; j < string_0.Length; j++)
				{
					char c2 = string_0[j];
					if (!char.IsDigit(c2))
					{
						if (c2 == '!')
						{
							flag = true;
						}
						num4 = j - 1;
						break;
					}
				}
				if (flag)
				{
					stringBuilder.Append(string_0, num, num4 - num + 2);
					num = num4 + 2;
					i = num4 + 1;
					num2 = i;
					flag = false;
					continue;
				}
				int num5 = i - 1;
				while (num5 >= 0 && (char.IsLetter(string_0, num5) || string_0[num5] == '$'))
				{
					num3 = num5;
					num5--;
				}
				if (num3 != num)
				{
					smethod_7(stringBuilder, string_0, num, num3 - 1);
				}
				if ((num3 > 0 && string_0[num3 - 1] == '_') || (num4 < string_0.Length - 1 && string_0[num4 + 1] == '_'))
				{
					stringBuilder.Append(string_0, num3, num4 - num3 + 1);
				}
				else
				{
					smethod_8(stringBuilder, string_0, num3, num4, int_0, int_1);
				}
				i = num4;
				num = num4 + 1;
				num2 = num4;
			}
		}
		_ = string_0.Length;
		if (num2 != string_0.Length - 1)
		{
			smethod_7(stringBuilder, string_0, num2 + 1, string_0.Length - 1);
		}
		return stringBuilder.ToString();
	}

	private static void smethod_7(StringBuilder stringBuilder_0, string string_0, int int_0, int int_1)
	{
		for (int i = int_0; i <= int_1; i++)
		{
			if (string_0[i] == '$' && i != int_1 && char.IsLetter(string_0[i + 1]))
			{
				int num = int_1;
				for (int j = i + 2; j <= int_1; j++)
				{
					if (!char.IsLetter(string_0[j]))
					{
						num = j - 1;
						break;
					}
				}
				int num2 = smethod_9(string_0, i + 1, num);
				stringBuilder_0.Append('C');
				stringBuilder_0.Append(num2 + 1);
				i = num;
			}
			else
			{
				stringBuilder_0.Append(string_0[i]);
			}
		}
	}

	private static void smethod_8(StringBuilder stringBuilder_0, string string_0, int int_0, int int_1, int int_2, int int_3)
	{
		bool flag = false;
		bool flag2;
		if (flag2 = string_0[int_0] == '$')
		{
			int_0++;
		}
		if (flag2 && char.IsDigit(string_0[int_0]))
		{
			stringBuilder_0.Append('R');
			stringBuilder_0.Append(string_0, int_0, int_1 - int_0 + 1);
			return;
		}
		if (!char.IsLetter(string_0[int_0]))
		{
			smethod_7(stringBuilder_0, string_0, int_0, int_1);
			return;
		}
		int num = -1;
		int num2 = -1;
		for (int i = int_0 + 1; i <= int_1; i++)
		{
			char c = string_0[i];
			if (!char.IsDigit(c))
			{
				if (c == '$')
				{
					num = i - 1;
					flag = true;
					num2 = i + 1;
					break;
				}
				continue;
			}
			num = i - 1;
			num2 = i;
			break;
		}
		if (num != -1 && num2 != -1 && num2 <= int_1 && num - int_0 <= 3)
		{
			stringBuilder_0.Append('R');
			int num3 = int.Parse(string_0.Substring(num2, int_1 - num2 + 1));
			if (!flag && int_2 != -1)
			{
				stringBuilder_0.Append('[');
				stringBuilder_0.Append(num3 - int_2 - 1);
				stringBuilder_0.Append(']');
			}
			else
			{
				stringBuilder_0.Append(num3);
			}
			stringBuilder_0.Append('C');
			int num4 = smethod_9(string_0, int_0, num);
			if (!flag2 && int_3 != -1)
			{
				stringBuilder_0.Append('[');
				stringBuilder_0.Append(num4 - int_3);
				stringBuilder_0.Append(']');
			}
			else
			{
				stringBuilder_0.Append(num4 + 1);
			}
		}
		else
		{
			smethod_7(stringBuilder_0, string_0, int_0, int_1);
		}
	}

	private static int smethod_9(string string_0, int int_0, int int_1)
	{
		if (string_0 != null && int_0 <= int_1 && int_1 - int_0 <= 1)
		{
			int num = int_0;
			int num2 = 0;
			while (true)
			{
				if (num <= int_1)
				{
					char c = string_0[num];
					if (c >= 'A' && c <= 'Z')
					{
						num2 = num2 * 26 + c - 65 + 1;
					}
					else
					{
						if (c < 'a' || c > 'z')
						{
							throw new ApplicationException("Invalid column expression: " + string_0);
						}
						num2 = num2 * 26 + c - 97 + 1;
					}
					num++;
					continue;
				}
				if (num2 > 0)
				{
					num2--;
				}
				break;
			}
			return num2;
		}
		throw new ApplicationException("Invalid column expression: " + string_0);
	}

	public static string smethod_10(string string_0, int int_0, int int_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < string_0.Length; i++)
		{
			switch (string_0[i])
			{
			case '\'':
				for (i++; i < string_0.Length; i++)
				{
					char c3 = string_0[i];
					if (c3 == '\'' && (i + 1 >= string_0.Length || string_0[i + 1] != '\''))
					{
						break;
					}
				}
				break;
			case '"':
				for (i++; i < string_0.Length; i++)
				{
					char c3 = string_0[i];
					if (c3 == '"' && (i + 1 >= string_0.Length || string_0[i + 1] != '"'))
					{
						break;
					}
				}
				break;
			case 'C':
			case 'c':
				if (i > 0 && char.IsLetter(string_0[i - 1]))
				{
					break;
				}
				if (i + 1 < string_0.Length && (char.IsDigit(string_0[i + 1]) || string_0[i + 1] == '['))
				{
					if (smethod_11(stringBuilder, string_0, num, ref i, int_0, int_1))
					{
						num = i + 1;
						num2 = i;
					}
				}
				else if (i + 2 < string_0.Length && string_0[i + 1] == ':' && string_0[i + 2] == 'C' && smethod_11(stringBuilder, string_0, num, ref i, int_0, int_1))
				{
					num = i + 1;
					num2 = i;
				}
				break;
			case 'R':
			case 'r':
			{
				if (i > 0)
				{
					if (char.IsLetter(string_0[i - 1]))
					{
						break;
					}
					char c = string_0[i - 1];
					if (c == '_')
					{
						break;
					}
				}
				if (i + 1 < string_0.Length && char.IsLetter(string_0[i + 1]) && string_0[i + 1] != 'C' && string_0[i + 1] != 'c')
				{
					break;
				}
				if (i != num)
				{
					stringBuilder.Append(string_0, num, i - num);
				}
				int int_2 = string_0.Length - 1;
				bool flag = false;
				for (int j = i + 1; j < string_0.Length; j++)
				{
					char c2 = string_0[j];
					switch (c2)
					{
					case '[':
						flag = true;
						continue;
					case ']':
						flag = false;
						continue;
					default:
						if (flag || char.IsLetterOrDigit(c2) || c2 == '[' || c2 == ']')
						{
							continue;
						}
						break;
					}
					int_2 = j - 1;
					break;
				}
				if (flag)
				{
					smethod_14(string_0, int_0, int_1);
				}
				smethod_12(stringBuilder, string_0, i, ref int_2, int_0, int_1);
				i = int_2;
				num = int_2 + 1;
				num2 = int_2;
				break;
			}
			}
		}
		if (num2 != string_0.Length - 1)
		{
			stringBuilder.Append(string_0, num2 + 1, string_0.Length - num2 - 1);
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_11(StringBuilder stringBuilder_0, string string_0, int int_0, ref int int_1, int int_2, int int_3)
	{
		bool flag = false;
		bool flag2 = false;
		int num = string_0.Length - 1;
		int num2 = string_0.Length - 1;
		bool flag3 = false;
		for (int i = int_1 + 1; i < string_0.Length; i++)
		{
			char c = string_0[i];
			switch (c)
			{
			case '[':
				flag = true;
				flag3 = true;
				continue;
			case ']':
				flag = false;
				continue;
			default:
				if (flag)
				{
					continue;
				}
				if (c == ':' && i + 1 < string_0.Length && (string_0[i + 1] == 'C' || string_0[i + 1] == 'c'))
				{
					num = i - 1;
					i++;
					flag2 = true;
					continue;
				}
				if (char.IsDigit(c) || c == '[' || c == ']')
				{
					continue;
				}
				break;
			}
			num2 = i - 1;
			if (!flag2)
			{
				num = i - 1;
			}
			break;
		}
		if (!flag3 && !flag2 && num + 1 < string_0.Length)
		{
			char c2 = string_0[num + 1];
			if (c2 == '.')
			{
				return false;
			}
		}
		if (int_0 != int_1)
		{
			stringBuilder_0.Append(string_0, int_0, int_1 - int_0);
		}
		bool flag4 = true;
		int num3 = 0;
		for (int j = 0; j < 2; j++)
		{
			flag4 = true;
			if (j == 1)
			{
				stringBuilder_0.Append(':');
				if (!flag2)
				{
					smethod_13(stringBuilder_0, num3);
					break;
				}
				int_1 = num + 2;
				num = num2;
			}
			int num4 = int_1;
			if (num4 != num && string_0[num4 + 1] == '[')
			{
				flag4 = false;
			}
			try
			{
				if (!flag4 && int_3 != -1)
				{
					num3 = int_3 + int.Parse(string_0.Substring(num4 + 2, num - num4 - 2));
					if (num3 > 16383 || num3 < 0)
					{
						smethod_14(string_0, int_2, int_3);
					}
					smethod_13(stringBuilder_0, num3);
					continue;
				}
				if (num4 == num)
				{
					if (int_3 == -1)
					{
						stringBuilder_0.Append('A');
					}
					else
					{
						smethod_13(stringBuilder_0, int_3);
					}
					continue;
				}
				stringBuilder_0.Append('$');
				num3 = ((!flag4) ? (int.Parse(string_0.Substring(num4 + 2, num - num4 - 2)) - 1) : (int.Parse(string_0.Substring(num4 + 1, num - num4)) - 1));
				if (num3 > 16383 || num3 < 0)
				{
					smethod_14(string_0, int_2, int_3);
				}
				smethod_13(stringBuilder_0, num3);
			}
			catch (Exception)
			{
				smethod_14(string_0, int_2, int_3);
			}
		}
		int_1 = num2;
		return true;
	}

	private static void smethod_12(StringBuilder stringBuilder_0, string string_0, int int_0, ref int int_1, int int_2, int int_3)
	{
		bool flag = true;
		bool flag2 = true;
		int num = -1;
		for (int i = int_0; i <= int_1; i++)
		{
			if (string_0[i] == 'C' || string_0[i] == 'c')
			{
				num = i;
				break;
			}
		}
		int num2 = int_0;
		if (num == -1)
		{
			if (int_1 + 1 != string_0.Length && string_0[int_1 + 1] == ':')
			{
				for (int j = 0; j < 2; j++)
				{
					if (j == 1)
					{
						stringBuilder_0.Append(':');
						num2 = int_1 + 2;
						bool flag3 = false;
						for (int k = num2 + 1; k < string_0.Length; k++)
						{
							char c = string_0[k];
							switch (c)
							{
							case '[':
								flag3 = true;
								continue;
							case ']':
								flag3 = false;
								continue;
							default:
								if (flag3 || char.IsDigit(c) || c == '[' || c == ']')
								{
									continue;
								}
								break;
							}
							int_1 = k - 1;
							break;
						}
						if (num2 > int_1)
						{
							int_1 = string_0.Length - 1;
						}
					}
					if (string_0[num2 + 1] == '[' || string_0[num2 + 1] == ':')
					{
						flag = false;
					}
					if (!flag && int_2 != -1)
					{
						int num3 = int_2 + 1;
						if (int_1 > num2 + 2)
						{
							num3 += int.Parse(string_0.Substring(num2 + 2, int_1 - num2 - 2));
						}
						if (num3 > 1048575 || num3 < 1)
						{
							smethod_14(string_0, int_2, int_3);
						}
						stringBuilder_0.Append(num3);
						continue;
					}
					stringBuilder_0.Append('$');
					int num4 = 0;
					if (int_1 > num2)
					{
						num4 = int.Parse(string_0.Substring(num2 + 1, int_1 - num2));
					}
					if (num4 > 1048575 || num4 < 1)
					{
						smethod_14(string_0, int_2, int_3);
					}
					stringBuilder_0.Append(num4);
				}
				return;
			}
			if (string_0[num2 + 1] == '[' || num2 == int_1)
			{
				flag = false;
			}
			int num5 = 0;
			if (!flag && int_2 != -1)
			{
				num5 = int_2 + 1;
				if (int_1 > num2 + 2)
				{
					num5 += int.Parse(string_0.Substring(num2 + 2, int_1 - num2 - 2));
				}
				if (num5 > 1048575 || num5 < 1)
				{
					smethod_14(string_0, int_2, int_3);
				}
				stringBuilder_0.Append(num5);
			}
			else
			{
				stringBuilder_0.Append('$');
				if (int_1 > num2)
				{
					num5 = int.Parse(string_0.Substring(num2 + 1, int_1 - num2));
				}
				if (num5 > 1048575 || num5 < 1)
				{
					smethod_14(string_0, int_2, int_3);
				}
				stringBuilder_0.Append(num5);
			}
			stringBuilder_0.Append(':');
			if (flag || int_2 == -1)
			{
				stringBuilder_0.Append('$');
			}
			stringBuilder_0.Append(num5);
			return;
		}
		if (string_0[num2 + 1] == '[')
		{
			flag = false;
		}
		if (num != int_1 && string_0[num + 1] == '[')
		{
			flag2 = false;
		}
		try
		{
			if (flag2)
			{
				if (num == int_1)
				{
					if (int_3 == -1)
					{
						stringBuilder_0.Append('A');
					}
					else
					{
						smethod_13(stringBuilder_0, int_3);
					}
				}
				else
				{
					stringBuilder_0.Append('$');
					int num6 = int.Parse(string_0.Substring(num + 1, int_1 - num)) - 1;
					if (num6 > 16383 || num6 < 0)
					{
						smethod_14(string_0, int_2, int_3);
					}
					smethod_13(stringBuilder_0, num6);
				}
			}
			else
			{
				int num7 = int_3 + int.Parse(string_0.Substring(num + 2, int_1 - num - 2));
				if (num7 > 16383 || num7 < 0)
				{
					smethod_14(string_0, int_2, int_3);
				}
				smethod_13(stringBuilder_0, num7);
			}
			if (flag)
			{
				if (num2 + 1 == num)
				{
					if (int_2 == -1)
					{
						stringBuilder_0.Append('1');
					}
					else
					{
						stringBuilder_0.Append(int_2 + 1);
					}
					return;
				}
				stringBuilder_0.Append('$');
				int num8 = int.Parse(string_0.Substring(num2 + 1, num - num2 - 1));
				if (num8 > 1048575 || num8 < 1)
				{
					smethod_14(string_0, int_2, int_3);
				}
				stringBuilder_0.Append(num8);
			}
			else
			{
				int num9 = int_2 + int.Parse(string_0.Substring(num2 + 2, num - num2 - 3)) + 1;
				if (num9 > 1048575 || num9 < 1)
				{
					smethod_14(string_0, int_2, int_3);
				}
				stringBuilder_0.Append(num9);
			}
		}
		catch (Exception)
		{
			smethod_14(string_0, int_2, int_3);
		}
	}

	private static void smethod_13(StringBuilder stringBuilder_0, int int_0)
	{
		stringBuilder_0.Append(CellsHelper.ColumnIndexToName(int_0));
	}

	private static void smethod_14(string string_0, int int_0, int int_1)
	{
		throw new CellsException(ExceptionType.Formula, "Invalid formula in cell " + CellsHelper.CellIndexToName(int_0, int_1) + ": " + string_0);
	}

	public static bool smethod_15(string string_0)
	{
		if (string_0 != null)
		{
			return string_0.Length == 0;
		}
		return true;
	}
}
