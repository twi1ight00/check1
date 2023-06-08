using System;
using System.Runtime.CompilerServices;

namespace ns16;

internal class EventArgs0 : EventArgs
{
	private int int_0;

	private bool bool_0;

	private Class744 class744_0;

	private Enum25 enum25_0;

	private string string_0;

	private long long_0;

	private long long_1;

	internal EventArgs0()
	{
	}

	internal EventArgs0(string string_1, Enum25 enum25_1)
	{
		string_0 = string_1;
		enum25_0 = enum25_1;
	}

	[SpecialName]
	public void method_0(int int_1)
	{
		int_0 = int_1;
	}

	[SpecialName]
	public void method_1(Class744 class744_1)
	{
		class744_0 = class744_1;
	}

	[SpecialName]
	public bool method_2()
	{
		return bool_0;
	}

	[SpecialName]
	public void method_3(Enum25 enum25_1)
	{
		enum25_0 = enum25_1;
	}

	[SpecialName]
	public void method_4(string string_1)
	{
		string_0 = string_1;
	}

	[SpecialName]
	public void method_5(long long_2)
	{
		long_0 = long_2;
	}

	[SpecialName]
	public void method_6(long long_2)
	{
		long_1 = long_2;
	}
}
