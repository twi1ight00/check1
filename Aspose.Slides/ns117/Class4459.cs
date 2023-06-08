using ns115;
using ns126;
using ns131;
using ns133;

namespace ns117;

internal class Class4459 : Class4455
{
	public Class4459(Class4552 pSProgram)
		: base(pSProgram)
	{
	}

	public Enum650 method_0()
	{
		byte b = class4552_0[int_0];
		if (b <= 31)
		{
			return Enum650.const_0;
		}
		return Enum650.const_1;
	}

	public int method_1()
	{
		byte b = class4552_0[int_0];
		if (b <= 31)
		{
			throw new Exception50("Unexpected PS object type in PS program.");
		}
		if (b <= 246)
		{
			return b - 139;
		}
		if (b <= 250)
		{
			if (int_0 + 1 < class4552_0.Length)
			{
				int num = class4552_0[++int_0];
				return (b - 247) * 256 + num + 108;
			}
		}
		else if (b <= 254)
		{
			if (int_0 + 1 < class4552_0.Length)
			{
				int num2 = class4552_0[++int_0];
				return -((b - 251) * 256) - num2 - 108;
			}
		}
		else if (int_0 + 4 < class4552_0.Length)
		{
			int num3 = class4552_0[++int_0];
			int num4 = class4552_0[++int_0];
			int num5 = class4552_0[++int_0];
			int num6 = class4552_0[++int_0];
			return (num3 << 24) | (num4 << 16) | (num5 << 8) | num6;
		}
		return 0;
	}

	public double method_2()
	{
		return 0.0;
	}

	public string method_3()
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
		case 9:
			return "closepath";
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
					12 => "div", 
					0 => "dotsection", 
					1 => "vstem3", 
					2 => "hstem3", 
					6 => "seac", 
					7 => "sbw", 
					33 => "setcurrentpoint", 
					16 => "callothersubr", 
					17 => "pop", 
					_ => "N/A", 
				};
			}
			return "N/A";
		case 13:
			return "hsbw";
		case 14:
			return "endchar";
		case 21:
			return "rmoveto";
		case 22:
			return "hmoveto";
		default:
			return "N/A";
		case 30:
			return "vhcurveto";
		case 31:
			return "hvcurveto";
		}
	}
}
