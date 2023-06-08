using System;
using System.Text;

namespace ns22;

internal class Class1180
{
	internal static bool smethod_0(object object_0)
	{
		return object_0 is DateTime;
	}

	internal static int smethod_1(char[] char_0, int int_0, int int_1)
	{
		switch (char_0[int_0])
		{
		default:
			return int_0;
		case 'G':
		case 'H':
		case 'M':
		case 'd':
		case 'f':
		case 'g':
		case 'h':
		case 'm':
		case 's':
		case 't':
		case 'y':
		case 'z':
			return int_0 + 1;
		}
	}

	internal static string smethod_2(int int_0, short short_0)
	{
		return "gg";
	}

	internal static string smethod_3()
	{
		return "ddd";
	}

	internal static string smethod_4()
	{
		return "dddd";
	}

	internal static void smethod_5(StringBuilder stringBuilder_0, char char_0)
	{
		switch (char_0)
		{
		case '\'':
			if (stringBuilder_0.Length > 0)
			{
				char c2 = stringBuilder_0[stringBuilder_0.Length - 1];
				if (c2 == '"')
				{
					stringBuilder_0.Length--;
					stringBuilder_0.Append(char_0);
					stringBuilder_0.Append(c2);
					return;
				}
			}
			stringBuilder_0.Append('"');
			stringBuilder_0.Append(char_0);
			stringBuilder_0.Append('"');
			return;
		case '"':
			if (stringBuilder_0.Length > 0)
			{
				char c = stringBuilder_0[stringBuilder_0.Length - 1];
				if (c == '\'')
				{
					stringBuilder_0.Length--;
					stringBuilder_0.Append(char_0);
					stringBuilder_0.Append(c);
					return;
				}
			}
			stringBuilder_0.Append('\'');
			stringBuilder_0.Append(char_0);
			stringBuilder_0.Append('\'');
			return;
		}
		if (stringBuilder_0.Length > 0)
		{
			char c3 = stringBuilder_0[stringBuilder_0.Length - 1];
			if (c3 == '"' || c3 == '\'')
			{
				stringBuilder_0.Length--;
				stringBuilder_0.Append(char_0);
				stringBuilder_0.Append(c3);
				return;
			}
		}
		stringBuilder_0.Append('\'');
		stringBuilder_0.Append(char_0);
		stringBuilder_0.Append('\'');
	}

	internal static void smethod_6(StringBuilder stringBuilder_0, char[] char_0, int int_0, int int_1)
	{
		char c = ' ';
		if (stringBuilder_0.Length > 0 && (stringBuilder_0[stringBuilder_0.Length - 1] == '"' || stringBuilder_0[stringBuilder_0.Length - 1] == '\''))
		{
			c = stringBuilder_0[stringBuilder_0.Length - 1];
			stringBuilder_0.Length--;
		}
		else
		{
			c = ((char_0[int_0] != '\'') ? '\'' : '"');
			stringBuilder_0.Append(c);
			stringBuilder_0.Append(char_0[int_0]);
			int_0++;
		}
		while (int_0 < int_1)
		{
			if (char_0[int_0] == c)
			{
				stringBuilder_0.Append(c);
				switch (c)
				{
				case '\'':
					c = '"';
					break;
				case '"':
					c = '"';
					break;
				}
				stringBuilder_0.Append(c);
			}
			stringBuilder_0.Append(char_0[int_0]);
			int_0++;
		}
		stringBuilder_0.Append(c);
	}
}
