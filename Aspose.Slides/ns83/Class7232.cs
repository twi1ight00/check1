using System.Text;

namespace ns83;

internal class Class7232
{
	public const int int_0 = -1;

	public const int int_1 = 1;

	public const int int_2 = 2;

	public const int int_3 = 3;

	public const int int_4 = 4;

	public const int int_5 = 5;

	public const int int_6 = 6;

	public const int int_7 = 7;

	protected string string_0;

	protected int int_8 = -1;

	protected int int_9;

	protected int int_10;

	public StringBuilder stringBuilder_0 = new StringBuilder();

	public bool bool_0;

	public Class7232(string pattern)
	{
		string_0 = pattern;
		int_10 = pattern.Length;
		method_1();
	}

	public int method_0()
	{
		stringBuilder_0.Length = 0;
		while (true)
		{
			if (int_9 != -1)
			{
				if (int_9 != 32 && int_9 != 10 && int_9 != 13 && int_9 != 9)
				{
					break;
				}
				method_1();
				continue;
			}
			return -1;
		}
		if ((int_9 >= 97 && int_9 <= 122) || (int_9 >= 65 && int_9 <= 90) || int_9 == 95)
		{
			stringBuilder_0.Append((char)int_9);
			method_1();
			while ((int_9 >= 97 && int_9 <= 122) || (int_9 >= 65 && int_9 <= 90) || (int_9 >= 48 && int_9 <= 57) || int_9 == 95)
			{
				stringBuilder_0.Append((char)int_9);
				method_1();
			}
			return 3;
		}
		if (int_9 == 40)
		{
			method_1();
			return 1;
		}
		if (int_9 == 41)
		{
			method_1();
			return 2;
		}
		if (int_9 == 37)
		{
			method_1();
			return 5;
		}
		if (int_9 == 58)
		{
			method_1();
			return 6;
		}
		if (int_9 == 46)
		{
			method_1();
			return 7;
		}
		if (int_9 == 91)
		{
			method_1();
			while (int_9 != 93)
			{
				if (int_9 == 92)
				{
					method_1();
					if (int_9 != 93)
					{
						stringBuilder_0.Append('\\');
					}
					stringBuilder_0.Append((char)int_9);
				}
				else
				{
					stringBuilder_0.Append((char)int_9);
				}
				method_1();
			}
			method_1();
			return 4;
		}
		method_1();
		bool_0 = true;
		return -1;
	}

	protected void method_1()
	{
		int_8++;
		if (int_8 >= int_10)
		{
			int_9 = -1;
		}
		else
		{
			int_9 = string_0[int_8];
		}
	}
}
