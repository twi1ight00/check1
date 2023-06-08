using System;
using ns171;

namespace ns181;

internal class Class4953 : Class4943
{
	private int int_17 = 133;

	private int int_18 = 1000;

	public void method_51(int style)
	{
		int_17 = style;
	}

	public void method_52(string style)
	{
		switch (style.ToLower())
		{
		case "dotted":
			method_51(36);
			break;
		case "dashed":
			method_51(31);
			break;
		case "solid":
			method_51(133);
			break;
		case "double":
			method_51(37);
			break;
		case "groove":
			method_51(55);
			break;
		case "ridge":
			method_51(119);
			break;
		case "none":
			method_51(95);
			break;
		}
	}

	public void method_53(int rt)
	{
		int_18 = rt;
	}

	public int method_54()
	{
		return int_17;
	}

	public string method_55()
	{
		return (Enum679)method_54() switch
		{
			Enum679.const_56 => "groove", 
			Enum679.const_37 => "dotted", 
			Enum679.const_38 => "double", 
			Enum679.const_32 => "dashed", 
			Enum679.const_220 => "solid", 
			Enum679.const_206 => "ridge", 
			Enum679.const_182 => "none", 
			_ => throw new InvalidOperationException("Unsupported rule style: " + method_54()), 
		};
	}

	public int method_56()
	{
		return int_18;
	}
}
