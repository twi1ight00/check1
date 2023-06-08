using ns115;
using ns126;
using ns131;
using ns133;

namespace ns116;

internal class Class4456 : Class4455
{
	private int int_1;

	public Class4456(Class4552 pSProgram, int charStringType)
		: base(pSProgram)
	{
		int_1 = charStringType;
	}

	public Enum650 method_0()
	{
		byte b = class4552_0[int_0];
		if (b != 28 && (b < 32 || b >= byte.MaxValue))
		{
			if (b == byte.MaxValue)
			{
				if (int_1 == 2)
				{
					return Enum650.const_2;
				}
				return Enum650.const_1;
			}
			return Enum650.const_0;
		}
		return Enum650.const_1;
	}

	public int method_1()
	{
		return class4552_0[int_0];
	}

	public int method_2()
	{
		byte b = class4552_0[int_0];
		if (b == 28)
		{
			if (int_0 + 2 < class4552_0.Length)
			{
				int num = class4552_0[++int_0];
				int num2 = class4552_0[++int_0];
				return (short)((num << 8) | num2);
			}
		}
		else
		{
			if (b <= 246)
			{
				return b - 139;
			}
			if (b <= 250)
			{
				if (int_0 + 1 < class4552_0.Length)
				{
					int num3 = class4552_0[++int_0];
					return (b - 247) * 256 + num3 + 108;
				}
			}
			else if (b <= 254)
			{
				if (int_0 + 1 < class4552_0.Length)
				{
					int num4 = class4552_0[++int_0];
					return -((b - 251) * 256) - num4 - 108;
				}
			}
			else if (b == byte.MaxValue && int_0 + 4 < class4552_0.Length)
			{
				int num5 = class4552_0[++int_0];
				int num6 = class4552_0[++int_0];
				int num7 = class4552_0[++int_0];
				int num8 = class4552_0[++int_0];
				return (num5 << 24) | (num6 << 16) | (num7 << 8) | num8;
			}
		}
		return 0;
	}

	public double method_3()
	{
		byte b = class4552_0[int_0];
		if (b == byte.MaxValue && int_0 + 4 < class4552_0.Length)
		{
			int num = class4552_0[++int_0];
			int num2 = class4552_0[++int_0];
			int num3 = class4552_0[++int_0];
			int num4 = class4552_0[++int_0];
			short num5 = (short)((num << 8) | num2);
			int num6 = (num3 << 8) | num4;
			return (double)num5 + (double)num6 / 65536.0;
		}
		return 0.0;
	}

	public string method_4()
	{
		byte b = class4552_0[int_0];
		if (b > 31)
		{
			throw new Exception50("Unexpected PS object type in PS program.");
		}
		switch (b)
		{
		case 1:
			return "hstem";
		case 3:
			return "vstem";
		case 4:
			return "vmoveto";
		case 5:
			return "rlineto";
		case 6:
			return "hlineto";
		case 7:
			return "vlineto";
		case 8:
			return "rrcurveto";
		case 10:
			return "callsubr";
		case 11:
			return "return";
		case 12:
			if (int_0 + 1 < class4552_0.Length)
			{
				int_0++;
				return class4552_0[int_0] switch
				{
					3 => "and", 
					4 => "or", 
					5 => "not", 
					9 => "abs", 
					10 => "add", 
					11 => "sub", 
					12 => "div", 
					14 => "neg", 
					15 => "eq", 
					18 => "drop", 
					20 => "put", 
					21 => "get", 
					22 => "ifelse", 
					23 => "random", 
					24 => "mul", 
					26 => "sqrt", 
					27 => "dup", 
					28 => "exch", 
					29 => "index", 
					30 => "roll", 
					34 => "hflex", 
					35 => "flex", 
					36 => "hflex1", 
					37 => "flex1", 
					_ => "N/A", 
				};
			}
			return "N/A";
		case 14:
			return "endchar";
		case 18:
			return "hstemhm";
		case 19:
			return "hintmask";
		case 20:
			return "cntrmask";
		case 21:
			return "rmoveto";
		case 22:
			return "hmoveto";
		case 23:
			return "vstemhm";
		case 24:
			return "rcurveline";
		case 25:
			return "rlinecurve";
		case 26:
			return "vvcurveto";
		case 27:
			return "hhcurveto";
		default:
			return "N/A";
		case 29:
			return "callgsubr";
		case 30:
			return "vhcurveto";
		case 31:
			return "hvcurveto";
		}
	}
}
