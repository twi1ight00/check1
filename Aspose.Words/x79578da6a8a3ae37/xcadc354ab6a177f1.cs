using Aspose.Words;
using x5f3520a4b31ea90f;
using x6c95d9cf46ff5f25;

namespace x79578da6a8a3ae37;

internal class xcadc354ab6a177f1
{
	private const int xfda814c4c72806cc = 15;

	private ProtectionType x0abd974822e40566 = ProtectionType.NoProtection;

	private bool x351303d653362e0f;

	private bool x92b983c3e8ae85b3;

	private bool x82353cf293d429bd;

	private bool x1167062d93ea1d48;

	private int x66bbab603404f5cd;

	private x218603e609fcc201 x5975aea07b196748 = new x218603e609fcc201();

	private static readonly int[] xfb899e7889ded6b4 = new int[15]
	{
		57840, 7439, 52380, 33984, 4364, 3600, 61902, 12606, 6258, 57657,
		54287, 34041, 10252, 43370, 20163
	};

	private static readonly int[][] x44a6599a68110e28 = new int[15][]
	{
		new int[7] { 44796, 19929, 39858, 10053, 20106, 40212, 10761 },
		new int[7] { 31585, 63170, 64933, 60267, 50935, 40399, 11199 },
		new int[7] { 17763, 35526, 1453, 2906, 5812, 11624, 23248 },
		new int[7] { 885, 1770, 3540, 7080, 14160, 28320, 56640 },
		new int[7] { 55369, 41139, 20807, 41614, 21821, 43642, 17621 },
		new int[7] { 28485, 56970, 44341, 19019, 38038, 14605, 29210 },
		new int[7] { 60195, 50791, 40175, 10751, 21502, 43004, 24537 },
		new int[7] { 18387, 36774, 3949, 7898, 15796, 31592, 63184 },
		new int[7] { 47201, 24803, 49606, 37805, 14203, 28406, 56812 },
		new int[7] { 17824, 35648, 1697, 3394, 6788, 13576, 27152 },
		new int[7] { 43601, 17539, 35078, 557, 1114, 2228, 4456 },
		new int[7] { 30388, 60776, 51953, 34243, 7079, 14158, 28316 },
		new int[7] { 14128, 28256, 56512, 43425, 17251, 34502, 7597 },
		new int[7] { 13105, 26210, 52420, 35241, 883, 1766, 3532 },
		new int[7] { 4129, 8258, 16516, 33032, 4657, 9314, 18628 }
	};

	internal ProtectionType x5410a63599038a04
	{
		get
		{
			return x0abd974822e40566;
		}
		set
		{
			x0abd974822e40566 = value;
		}
	}

	internal bool x0cbff01514c02c1b
	{
		get
		{
			return x351303d653362e0f;
		}
		set
		{
			x351303d653362e0f = value;
		}
	}

	internal ProtectionType x491ce6cbe2c9a184
	{
		get
		{
			if (!x351303d653362e0f)
			{
				return ProtectionType.NoProtection;
			}
			return x0abd974822e40566;
		}
		set
		{
			x0abd974822e40566 = value;
			x351303d653362e0f = x0abd974822e40566 != ProtectionType.NoProtection;
		}
	}

	internal bool x4eae8f1c9ec0d2ae
	{
		get
		{
			return x92b983c3e8ae85b3;
		}
		set
		{
			x92b983c3e8ae85b3 = value;
		}
	}

	internal bool x3db5335cdcd5d88b
	{
		get
		{
			return x82353cf293d429bd;
		}
		set
		{
			x82353cf293d429bd = value;
		}
	}

	internal bool x84a58b01dbef401d
	{
		get
		{
			return x1167062d93ea1d48;
		}
		set
		{
			x1167062d93ea1d48 = value;
		}
	}

	internal int xf111d6890e7de382
	{
		get
		{
			return x66bbab603404f5cd;
		}
		set
		{
			x66bbab603404f5cd = value;
		}
	}

	internal x218603e609fcc201 x218603e609fcc201 => x5975aea07b196748;

	internal xcadc354ab6a177f1 x8b61531c8ea35b85()
	{
		xcadc354ab6a177f1 xcadc354ab6a177f2 = (xcadc354ab6a177f1)MemberwiseClone();
		xcadc354ab6a177f2.x5975aea07b196748 = x5975aea07b196748.x8b61531c8ea35b85();
		return xcadc354ab6a177f2;
	}

	internal void xde1927bac9d7e698()
	{
		if (x66bbab603404f5cd != 0 && x5975aea07b196748.x7149c962c02931b3)
		{
			x5975aea07b196748.x129b0b54f12e8dff(x66bbab603404f5cd);
		}
	}

	internal void x6cd27f17e64c23a1(ProtectionType x43163d22e8cd5a71, string xe8e4b5871d71a79a)
	{
		x491ce6cbe2c9a184 = x43163d22e8cd5a71;
		x66bbab603404f5cd = xb38b0710c9d2a22a(xe8e4b5871d71a79a);
		x5975aea07b196748.xf35aae0fa4a217a4 = null;
	}

	internal void x1af5508d5dfde22e(ProtectionType x43163d22e8cd5a71)
	{
		x491ce6cbe2c9a184 = x43163d22e8cd5a71;
		if (x0abd974822e40566 != ProtectionType.NoProtection && x66bbab603404f5cd == 0 && x5975aea07b196748.x7149c962c02931b3)
		{
			x66bbab603404f5cd = 1454256641;
			x5975aea07b196748.xf35aae0fa4a217a4 = null;
		}
	}

	internal void xfe6a949644368f06()
	{
		x491ce6cbe2c9a184 = ProtectionType.NoProtection;
	}

	internal bool xf4e3ad2be8a228ac(string xe8e4b5871d71a79a)
	{
		int num = xb38b0710c9d2a22a(xe8e4b5871d71a79a);
		x218603e609fcc201 x218603e609fcc202 = new x218603e609fcc201();
		if (!x5975aea07b196748.x7149c962c02931b3)
		{
			x218603e609fcc202.x129b0b54f12e8dff(num);
		}
		if (x66bbab603404f5cd != num)
		{
			if (!x5975aea07b196748.x7149c962c02931b3 && !x218603e609fcc202.x7149c962c02931b3)
			{
				return x66cdafe77e7aa42b.x8341ba999ffebb91(x5975aea07b196748.xf35aae0fa4a217a4) == x66cdafe77e7aa42b.x8341ba999ffebb91(x218603e609fcc202.xf35aae0fa4a217a4);
			}
			return false;
		}
		return true;
	}

	internal static int xb38b0710c9d2a22a(string xe8e4b5871d71a79a)
	{
		if (!x0d299f323d241756.x5959bccb67bbf051(xe8e4b5871d71a79a))
		{
			return 0;
		}
		if (xe8e4b5871d71a79a.Length > 15)
		{
			xe8e4b5871d71a79a = xe8e4b5871d71a79a.Substring(0, 15);
		}
		int length = xe8e4b5871d71a79a.Length;
		byte[] array = new byte[length];
		for (int i = 0; i < length; i++)
		{
			ushort num = xe8e4b5871d71a79a[i];
			byte b = (byte)num;
			if (b == 0)
			{
				b = (byte)(num >> 16);
			}
			array[i] = b;
		}
		int num2 = xfb899e7889ded6b4[length - 1];
		for (int j = 0; j < length; j++)
		{
			int[] array2 = x44a6599a68110e28[15 - length + j];
			byte b2 = array[j];
			for (int k = 0; k < 7; k++)
			{
				if (((uint)b2 & (true ? 1u : 0u)) != 0)
				{
					num2 ^= array2[k];
				}
				b2 = (byte)(b2 >> 1);
			}
		}
		int x399a997ec1273a = 0;
		for (int num3 = length - 1; num3 >= 0; num3--)
		{
			x399a997ec1273a = x846dd01c049c9669(x399a997ec1273a, array[num3]);
		}
		x399a997ec1273a = x846dd01c049c9669(x399a997ec1273a, length) ^ 0xCE4B;
		return (num2 << 16) | (x399a997ec1273a & 0xFFFF);
	}

	private static int x846dd01c049c9669(int x399a997ec1273a21, int x137ffa3012d6a67d)
	{
		return (((x399a997ec1273a21 >> 14) & 1) | ((x399a997ec1273a21 << 1) & 0x7FFF)) ^ x137ffa3012d6a67d;
	}
}
