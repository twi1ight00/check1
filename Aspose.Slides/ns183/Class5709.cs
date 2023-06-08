using System;

namespace ns183;

internal class Class5709 : Interface238
{
	private char[] char_0;

	public Class5709(char[] buf)
	{
		char_0 = buf;
	}

	public int imethod_0()
	{
		return char_0.Length;
	}

	public char imethod_1(int index)
	{
		return char_0[index];
	}

	public Interface238 imethod_2(int start, int end)
	{
		char[] array = new char[end - start + 1];
		Array.Copy(char_0, start, array, 0, array.Length);
		return new Class5709(array);
	}

	public override string ToString()
	{
		return new string(char_0);
	}
}
