using System;
using System.IO;
using ns83;
using ns90;

namespace ns88;

internal abstract class Class4251 : IDisposable
{
	protected const int int_0 = -1;

	private StringReader stringReader_0;

	private string string_0;

	protected int int_1;

	private char[] char_0 = new char[128];

	private int int_2;

	protected int int_3;

	private int int_4;

	private int int_5;

	private bool bool_0;

	public string Content => string_0;

	protected Class4251(string text, bool skipWhitespace)
	{
		string_0 = text;
		bool_0 = skipWhitespace;
		stringReader_0 = new StringReader(Content);
		int_1 = method_1();
	}

	protected Class4251(Interface105 node)
		: this(node.Text, skipWhitespace: false)
	{
	}

	public static Class4251 smethod_0(Interface105 node)
	{
		return new Class4252(node);
	}

	public char[] method_0()
	{
		return char_0;
	}

	protected int method_1()
	{
		int_1 = stringReader_0.Read();
		if (bool_0 && int_1 == 32)
		{
			do
			{
				int_1 = stringReader_0.Read();
			}
			while (int_1 == 32);
		}
		if (int_1 == -1)
		{
			return int_1;
		}
		if (int_2 == char_0.Length)
		{
			Array.Resize(ref char_0, char_0.Length + char_0.Length);
		}
		char_0[int_2++] = (char)int_1;
		return int_1;
	}

	public string method_2()
	{
		return new string(char_0, int_4, int_5 - int_4);
	}

	public int method_3()
	{
		int_4 = int_2 - 1;
		vmethod_0();
		int_5 = int_2 - vmethod_1();
		return int_3;
	}

	protected abstract void vmethod_0();

	protected virtual int vmethod_1()
	{
		return 0;
	}

	protected void method_4()
	{
		do
		{
			method_1();
		}
		while (int_1 != -1);
	}

	public void Dispose()
	{
		if (stringReader_0 != null)
		{
			stringReader_0.Dispose();
			stringReader_0 = null;
		}
	}
}
