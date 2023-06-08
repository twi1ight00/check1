using System.Globalization;
using System.Text;
using ns115;
using ns126;
using ns131;
using ns133;

namespace ns116;

internal class Class4458 : Class4455
{
	public Class4458(Class4552 pSProgram)
		: base(pSProgram)
	{
	}

	public Enum650 method_0()
	{
		byte b = class4552_0[int_0];
		if ((b >= 28 && b <= 29) || (b >= 32 && b <= 254))
		{
			return Enum650.const_1;
		}
		if (b == 30)
		{
			return Enum650.const_2;
		}
		return Enum650.const_0;
	}

	public int method_1()
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
		else if (b == 29)
		{
			if (int_0 + 4 < class4552_0.Length)
			{
				int num3 = class4552_0[++int_0];
				int num4 = class4552_0[++int_0];
				int num5 = class4552_0[++int_0];
				int num6 = class4552_0[++int_0];
				return (num3 << 24) | (num4 << 16) | (num5 << 8) | num6;
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
					int num7 = class4552_0[++int_0];
					return (b - 247) * 256 + num7 + 108;
				}
			}
			else if (b <= 254 && int_0 + 1 < class4552_0.Length)
			{
				int num8 = class4552_0[++int_0];
				return -((b - 251) * 256) - num8 - 108;
			}
		}
		return 0;
	}

	public double method_2()
	{
		byte b = class4552_0[++int_0];
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		bool flag2 = false;
		while (!flag2)
		{
			byte b2 = ((!flag) ? ((byte)(b & 0xFu)) : ((byte)(b >> 4)));
			if (b2 >= 0 && b2 <= 9)
			{
				stringBuilder.Append(b2);
			}
			else
			{
				switch (b2)
				{
				case 10:
					stringBuilder.Append(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
					break;
				case 11:
					stringBuilder.Append("E");
					break;
				case 12:
					stringBuilder.Append("E-");
					break;
				case 14:
					stringBuilder.Append("-");
					break;
				case 15:
					flag2 = true;
					break;
				}
			}
			if (flag2)
			{
				break;
			}
			if (flag = !flag)
			{
				b = class4552_0[++int_0];
			}
		}
		return double.Parse(stringBuilder.ToString(), CultureInfo.InvariantCulture);
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
		case 6:
			return "BlueValues";
		case 7:
			return "OtherBlues";
		case 8:
			return "FamilyBlues";
		case 9:
			return "FamilyOtherBlues";
		case 10:
			return "StdHW";
		case 11:
			return "StdVW";
		case 12:
			if (int_0 + 1 < class4552_0.Length)
			{
				int_0++;
				return class4552_0[int_0] switch
				{
					9 => "BlueScale", 
					10 => "BlueShift", 
					11 => "BlueFuzz", 
					12 => "StemSnapH", 
					13 => "StemSnapV", 
					14 => "ForceBold", 
					17 => "LanguageGroup", 
					18 => "ExpansionFactor", 
					19 => "initialRandomSeed", 
					_ => "N/A", 
				};
			}
			return "N/A";
		default:
			return "N/A";
		case 19:
			return "Subrs";
		case 20:
			return "defaultWidthX";
		case 21:
			return "nominalWidthX";
		}
	}
}
