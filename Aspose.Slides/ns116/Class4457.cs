using System.Globalization;
using System.Text;
using ns115;
using ns126;
using ns131;
using ns133;

namespace ns116;

internal class Class4457 : Class4455
{
	public Class4457(Class4552 pSProgram)
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
		case 0:
			return "version";
		case 1:
			return "Notice";
		case 2:
			return "FullName";
		case 3:
			return "FamilyName";
		case 4:
			return "Weight";
		case 5:
			return "FontBBox";
		default:
			return "N/A";
		case 12:
			if (int_0 + 1 < class4552_0.Length)
			{
				int_0++;
				return class4552_0[int_0] switch
				{
					0 => "Copyright", 
					1 => "isFixedPitch", 
					2 => "ItalicAngle", 
					3 => "UnderlinePosition", 
					4 => "UnderlineThickness", 
					5 => "PaintType", 
					6 => "CharstringType", 
					7 => "FontMatrix", 
					8 => "StrokeWidth", 
					20 => "SyntheticBase", 
					21 => "PostScript", 
					22 => "BaseFontName", 
					23 => "BaseFontBlend", 
					30 => "ROS", 
					31 => "CIDFontVersion", 
					32 => "CIDFontRevision", 
					33 => "CIDFontType", 
					34 => "CIDCount", 
					35 => "UIDBase", 
					36 => "FDArray", 
					37 => "FDSelect", 
					38 => "FontName", 
					_ => "N/A", 
				};
			}
			return "N/A";
		case 13:
			return "UniqueID";
		case 14:
			return "XUID";
		case 15:
			return "charset";
		case 16:
			return "Encoding";
		case 17:
			return "CharStrings";
		case 18:
			return "Private";
		}
	}

	public static byte[] smethod_0(int value)
	{
		return new byte[5]
		{
			29,
			(byte)(value >> 24),
			(byte)(value >> 16),
			(byte)(value >> 8),
			(byte)value
		};
	}
}
