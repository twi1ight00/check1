using System.IO;
using ns218;

namespace ns233;

internal class Class6149
{
	private const ushort ushort_0 = 1;

	private const ushort ushort_1 = 4;

	private readonly long long_0;

	private uint uint_0;

	private uint uint_1;

	private double double_0;

	private double double_1;

	private Enum791 enum791_0 = Enum791.const_8;

	private Enum793 enum793_0 = Enum793.const_1;

	private Enum789 enum789_0 = Enum789.const_0;

	private Enum792 enum792_0 = Enum792.const_0;

	private Enum790 enum790_0 = Enum790.const_0;

	private ushort ushort_2 = 1;

	private ushort ushort_3 = 4;

	private ushort[] ushort_4 = new ushort[1];

	public int ImageWidth
	{
		get
		{
			if (uint_0 == 0)
			{
				return 100;
			}
			return (int)uint_0;
		}
	}

	public int ImageHeight
	{
		get
		{
			if (uint_1 == 0)
			{
				return 100;
			}
			return (int)uint_1;
		}
	}

	public double ImageXResolution => double_0;

	public double ImageYResolution => double_1;

	public bool IsConformXpsSpecification
	{
		get
		{
			if (enum793_0 != Enum793.const_0 && enum793_0 != Enum793.const_1 && enum793_0 != Enum793.const_2)
			{
				return false;
			}
			if (!IsValidBilevelTiff && !IsValidGrayscaleTiff && !IsValidPaleteColorTiff && !IsValidRgbTiff)
			{
				return IsValidCmykTiff;
			}
			return true;
		}
	}

	private bool IsValidBilevelTiff
	{
		get
		{
			if ((enum791_0 == Enum791.const_0 || enum791_0 == Enum791.const_1) && ushort_4[0] == 0)
			{
				if (enum789_0 != Enum789.const_0 && enum789_0 != Enum789.const_1 && enum789_0 != Enum789.const_3 && enum789_0 != Enum789.const_4 && enum789_0 != Enum789.const_2)
				{
					return enum789_0 == Enum789.const_6;
				}
				return true;
			}
			return false;
		}
	}

	private bool IsValidGrayscaleTiff
	{
		get
		{
			if ((enum791_0 != 0 && enum791_0 != Enum791.const_1) || (ushort_4[0] != 4 && ushort_4[0] != 8 && ushort_4[0] != 16))
			{
				return false;
			}
			if (enum789_0 != Enum789.const_0 && enum789_0 != Enum789.const_1)
			{
				return enum789_0 == Enum789.const_6;
			}
			return true;
		}
	}

	private bool IsValidPaleteColorTiff
	{
		get
		{
			if (enum791_0 == Enum791.const_3 && (ushort_4[0] == 1 || ushort_4[0] == 4 || ushort_4[0] == 8))
			{
				if (enum789_0 != Enum789.const_0 && enum789_0 != Enum789.const_2)
				{
					return enum789_0 == Enum789.const_6;
				}
				return true;
			}
			return false;
		}
	}

	private bool IsValidRgbTiff
	{
		get
		{
			if (enum791_0 == Enum791.const_2 && enum792_0 == Enum792.const_0 && ushort_4.Length == ushort_2 && IsBitsPerSampleValid)
			{
				if (enum789_0 != Enum789.const_0 && enum789_0 != Enum789.const_2 && enum789_0 != Enum789.const_5)
				{
					return enum789_0 == Enum789.const_6;
				}
				return true;
			}
			return false;
		}
	}

	private bool IsValidCmykTiff
	{
		get
		{
			if (enum791_0 == Enum791.const_5 && enum792_0 == Enum792.const_0 && enum790_0 == Enum790.const_0 && ushort_3 == 4 && ushort_4.Length == ushort_2 && IsBitsPerSampleValid)
			{
				if (enum789_0 != Enum789.const_0 && enum789_0 != Enum789.const_2 && enum789_0 != Enum789.const_5)
				{
					return enum789_0 == Enum789.const_6;
				}
				return true;
			}
			return false;
		}
	}

	private bool IsBitsPerSampleValid
	{
		get
		{
			bool flag = ushort_4[0] == 8 || ushort_4[0] == 16;
			for (int i = 0; i < ushort_4.Length; i++)
			{
				flag = flag && ushort_4[i] == ushort_4[0];
			}
			return flag;
		}
	}

	public Class6149(byte[] imageBytes)
		: this(new Class5950(new MemoryStream(imageBytes)))
	{
	}

	public Class6149(Class5950 reader)
	{
		long_0 = reader.BaseStream.Position;
		method_0(reader);
	}

	private void method_0(Class5950 reader)
	{
		short num = reader.method_2();
		bool isBigEndian = num == 19789;
		ushort num2 = smethod_1(reader, isBigEndian);
		if (num2 != 42)
		{
			return;
		}
		uint num3 = smethod_2(reader, isBigEndian);
		reader.BaseStream.Position = long_0 + num3;
		ushort num4 = smethod_1(reader, isBigEndian);
		long num5 = reader.BaseStream.Position;
		for (int i = 0; i < num4; i++)
		{
			reader.BaseStream.Position = num5;
			num5 += 12L;
			ushort num6 = smethod_1(reader, isBigEndian);
			ushort num7 = smethod_1(reader, isBigEndian);
			uint num8 = smethod_2(reader, isBigEndian);
			if (((num7 == 1 || num7 == 2) && num8 > 4) || (num7 == 3 && num8 > 2) || (num7 == 4 && num8 > 1) || num7 == 5)
			{
				uint num9 = smethod_2(reader, isBigEndian);
				reader.BaseStream.Position = long_0 + num9;
			}
			switch (num6)
			{
			case 277:
				ushort_2 = smethod_1(reader, isBigEndian);
				break;
			case 256:
				uint_0 = ((num7 == 3) ? smethod_1(reader, isBigEndian) : smethod_2(reader, isBigEndian));
				break;
			case 257:
				uint_1 = ((num7 == 3) ? smethod_1(reader, isBigEndian) : smethod_2(reader, isBigEndian));
				break;
			case 258:
				ushort_4 = smethod_3(reader, isBigEndian, num8);
				break;
			case 259:
				enum789_0 = (Enum789)smethod_1(reader, isBigEndian);
				break;
			case 262:
				enum791_0 = (Enum791)smethod_1(reader, isBigEndian);
				break;
			case 332:
				enum790_0 = (Enum790)smethod_1(reader, isBigEndian);
				break;
			case 334:
				ushort_3 = smethod_1(reader, isBigEndian);
				break;
			case 296:
				enum793_0 = (Enum793)smethod_1(reader, isBigEndian);
				break;
			case 282:
				double_0 = smethod_4(reader, isBigEndian);
				break;
			case 283:
				double_1 = smethod_4(reader, isBigEndian);
				break;
			case 284:
				enum792_0 = (Enum792)smethod_1(reader, isBigEndian);
				break;
			}
		}
	}

	public static bool smethod_0(byte[] data)
	{
		using MemoryStream input = new MemoryStream(data);
		BinaryReader binaryReader = new BinaryReader(input);
		int num = binaryReader.ReadInt16();
		return num == 18761 || num == 19789;
	}

	private static ushort smethod_1(Class5950 reader, bool isBigEndian)
	{
		ushort num = reader.method_3();
		if (!isBigEndian)
		{
			num = Class5952.smethod_3(num);
		}
		return num;
	}

	private static uint smethod_2(Class5950 reader, bool isBigEndian)
	{
		uint num = reader.method_1();
		if (!isBigEndian)
		{
			num = Class5952.smethod_1(num);
		}
		return num;
	}

	private static ushort[] smethod_3(Class5950 reader, bool isBigEndian, uint numberOfItems)
	{
		ushort[] array = new ushort[numberOfItems];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = smethod_1(reader, isBigEndian);
		}
		return array;
	}

	private static double smethod_4(Class5950 reader, bool isBigEndian)
	{
		uint num = smethod_2(reader, isBigEndian);
		uint num2 = smethod_2(reader, isBigEndian);
		return (num2 != 0) ? (num / num2) : 0u;
	}
}
