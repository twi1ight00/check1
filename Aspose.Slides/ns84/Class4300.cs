using System;

namespace ns84;

internal sealed class Class4300 : ICloneable
{
	private readonly string string_0;

	private int int_0;

	public string Identifier => string_0;

	public int Value => int_0;

	internal Class4300(string identifier, int value)
	{
		string_0 = identifier;
		int_0 = value;
	}

	internal void Reset()
	{
		Reset(0);
	}

	internal void Reset(int value)
	{
		int_0 = value;
	}

	internal void method_0()
	{
		method_1(1);
	}

	internal void method_1(int value)
	{
		int_0 += value;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	internal Class4300 Clone()
	{
		return new Class4300(string_0, int_0);
	}
}
