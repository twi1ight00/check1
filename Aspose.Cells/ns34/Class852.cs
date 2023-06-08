using System;
using System.Runtime.CompilerServices;

namespace ns34;

internal class Class852 : IComparable
{
	private string string_0;

	private int int_0;

	private int int_1;

	internal string Name => string_0;

	internal Class852(string string_1, int int_2)
	{
		string_0 = string_1;
		int_0 = int_2;
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal int method_2()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_3(int int_2)
	{
		int_1 = int_2;
	}

	public int CompareTo(object obj)
	{
		Class852 @class = (Class852)obj;
		if (@class.method_0() == method_0())
		{
			return 0;
		}
		if (@class.method_0() > method_0())
		{
			return 1;
		}
		return -1;
	}

	public override bool Equals(object obj)
	{
		Class852 @class = (Class852)obj;
		return Name.Equals(@class.Name);
	}

	public override int GetHashCode()
	{
		return string_0.GetHashCode();
	}
}
