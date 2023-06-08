using System;
using ns194;
using ns214;

namespace ns184;

internal class Class5680 : Interface235
{
	private string string_0;

	private char[] char_0;

	private char[] char_1;

	private char[] char_2;

	private char[] char_3;

	private string[] string_1;

	private char char_4;

	public static string string_2 = ".notdef";

	public Class5680(string name, int[] table)
		: this(name, table, null)
	{
	}

	public Class5680(string name, int[] table, string[] charNameMap)
	{
		string_0 = name;
		method_0(table);
		if (charNameMap == null)
		{
			return;
		}
		string_1 = new string[256];
		for (int i = 0; i < 256; i++)
		{
			string text = charNameMap[i];
			if (text == null)
			{
				string_1[i] = string_2;
			}
			else
			{
				string_1[i] = text;
			}
		}
	}

	protected void method_0(int[] table)
	{
		int num = 0;
		char_0 = new char[256];
		char_3 = new char[256];
		for (int i = 0; i < char_3.Length; i++)
		{
			char_3[i] = '\uffff';
		}
		for (int j = 0; j < table.Length; j += 2)
		{
			char c = (char)table[j + 1];
			if (c < 'Ā')
			{
				if (char_0[(uint)c] == '\0')
				{
					char_0[(uint)c] = (char)table[j];
				}
			}
			else
			{
				num++;
			}
			if (char_3[table[j]] == '\uffff')
			{
				char_3[table[j]] = c;
			}
		}
		char_1 = new char[num];
		char_2 = new char[num];
		int num2 = 0;
		for (int k = 0; k < table.Length; k += 2)
		{
			char c2 = (char)table[k + 1];
			if (c2 < 'Ā')
			{
				continue;
			}
			num2++;
			int num3 = num2 - 1;
			while (num3 >= 0)
			{
				if (num3 > 0 && char_1[num3 - 1] >= c2)
				{
					char_1[num3] = char_1[num3 - 1];
					char_2[num3] = char_2[num3 - 1];
					num3--;
					continue;
				}
				char_1[num3] = c2;
				char_2[num3] = (char)table[k];
				break;
			}
		}
	}

	public string imethod_0()
	{
		return string_0;
	}

	public char imethod_1(char c)
	{
		if (c < 'Ā')
		{
			char c2 = char_0[(uint)c];
			if (c2 > '\0')
			{
				return c2;
			}
		}
		int num = 0;
		int num2 = char_1.Length - 1;
		int num3;
		while (true)
		{
			if (num2 >= num)
			{
				num3 = (num + num2) / 2;
				char c3 = char_1[num3];
				if (c == c3)
				{
					break;
				}
				if (c < c3)
				{
					num2 = num3 - 1;
				}
				else
				{
					num = num3 + 1;
				}
				continue;
			}
			return char_4;
		}
		return char_2[num3];
	}

	public char method_1(int idx)
	{
		return char_3[idx];
	}

	public char[] imethod_3()
	{
		char[] array = new char[char_3.Length];
		Array.Copy(char_3, 0, array, 0, char_3.Length);
		return array;
	}

	public short method_2(string charName)
	{
		string[] array = string_1;
		if (array == null)
		{
			array = imethod_2();
		}
		short num = 0;
		short num2 = (short)array.Length;
		while (true)
		{
			if (num < num2)
			{
				if (array[num].Equals(charName))
				{
					break;
				}
				num = (short)(num + 1);
				continue;
			}
			return -1;
		}
		return num;
	}

	public string[] imethod_2()
	{
		if (string_1 != null)
		{
			string[] array = new string[string_1.Length];
			Array.Copy(string_1, 0, array, 0, string_1.Length);
			return array;
		}
		string[] array2 = new string[256];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = string_2;
		}
		for (int j = 0; j < 256; j++)
		{
			char c = method_1(j);
			if (c != '\uffff')
			{
				string text = Class5774.smethod_1(c.ToString());
				if (text.Length > 0)
				{
					array2[j] = text;
				}
			}
		}
		return array2;
	}

	public override string ToString()
	{
		return imethod_0();
	}
}
