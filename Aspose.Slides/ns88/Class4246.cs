using System;
using ns83;

namespace ns88;

internal static class Class4246
{
	private static readonly uint[] uint_0 = new uint[4] { 0u, 0u, 2281701374u, 134217726u };

	private static readonly uint[] uint_1 = new uint[4] { 0u, 67051520u, 2281701374u, 134217726u };

	public static bool smethod_0(char c)
	{
		if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'))
		{
			return true;
		}
		if (c >= 'A')
		{
			return c <= 'F';
		}
		return false;
	}

	public static int smethod_1(char c)
	{
		if (c >= '0' && c <= '9')
		{
			return c - 48;
		}
		return c - 97 + 10;
	}

	public static bool smethod_2(char c)
	{
		if (c < '\u0080')
		{
			return (uint_0[(int)c >> 5] & (1 << (int)c)) != 0L;
		}
		return true;
	}

	public static bool smethod_3(char c)
	{
		if (c < '\u0080')
		{
			return (uint_1[(int)c >> 5] & (1 << (int)c)) != 0L;
		}
		return true;
	}

	public static Exception11 smethod_4(Exception e)
	{
		return new Exception11(e.Message);
	}

	public static Exception11 smethod_5(string exception)
	{
		return new Exception11(exception);
	}

	public static Exception11 smethod_6(Interface105 node)
	{
		return new Exception11($"Invalid color '{node.Text}' at line {node.Line}:{node.CharPositionInLine}");
	}

	public static Exception11 smethod_7(string ident)
	{
		string message = $"Invalid identifier '{ident}'.";
		return new Exception11(message);
	}

	public static Exception11 smethod_8(string ident)
	{
		string message = $"Invalid identifier '{ident}'.";
		return new Exception11(message);
	}

	public static Exception11 smethod_9(Interface105 token)
	{
		return smethod_10(token.Type, token.Text);
	}

	public static Exception11 smethod_10(int token, string text)
	{
		string message = $"Invalid token '{text}'.";
		return new Exception11(message);
	}

	public static Exception11 smethod_11(short type)
	{
		string message = $"Lexical unit '{type}' is not supported.";
		return new Exception11(message);
	}

	public static Exception11 smethod_12(string name)
	{
		string message = $"Invalid property name '{name}'.";
		return new Exception11(message);
	}

	public static Exception11 smethod_13(string name)
	{
		string message = $"Invalid property value '{name}'.";
		return new Exception11(message);
	}

	public static Exception11 smethod_14(string name)
	{
		string message = $"Invalid property values '{name}'.";
		return new Exception11(message);
	}

	public static Exception11 smethod_15(string name)
	{
		string message = $"Malformed function '{name}'.";
		return new Exception11(message);
	}
}
