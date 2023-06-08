using System;
using ns171;

namespace ns195;

internal class Class5676
{
	private Class5676()
	{
	}

	private static int smethod_0(int breakClass)
	{
		return (Enum679)breakClass switch
		{
			Enum679.const_29 => 1, 
			Enum679.const_10 => 0, 
			Enum679.const_191 => 2, 
			Enum679.const_187 => 3, 
			Enum679.const_45 => 3, 
			_ => throw new ArgumentException("Illegal value for breakClass: " + breakClass), 
		};
	}

	public static int smethod_1(int break1, int break2)
	{
		int num = smethod_0(break1);
		int num2 = smethod_0(break2);
		if (num < num2)
		{
			return break2;
		}
		return break1;
	}
}
