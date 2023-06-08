using System;

namespace ns130;

internal class Class4590 : Class4585
{
	private const int int_1 = 0;

	private const int int_2 = 2;

	private const int int_3 = 4;

	private const int int_4 = 6;

	private const int int_5 = 8;

	private const int int_6 = 10;

	private const int int_7 = 12;

	private const int int_8 = 14;

	private const int int_9 = 16;

	private const int int_10 = 18;

	private const int int_11 = 20;

	private const int int_12 = 22;

	private const int int_13 = 24;

	private const int int_14 = 26;

	private const int int_15 = 28;

	private const int int_16 = 30;

	private const int int_17 = 32;

	private const int int_18 = 42;

	private const int int_19 = 46;

	private const int int_20 = 50;

	private const int int_21 = 54;

	private const int int_22 = 58;

	private const int int_23 = 62;

	private const int int_24 = 64;

	private const int int_25 = 66;

	private const int int_26 = 68;

	private const int int_27 = 70;

	private const int int_28 = 72;

	private const int int_29 = 74;

	private const int int_30 = 76;

	private const int int_31 = 78;

	private const int int_32 = 82;

	private const int int_33 = 86;

	private const int int_34 = 88;

	private const int int_35 = 90;

	private const int int_36 = 92;

	private const int int_37 = 94;

	private ushort ushort_0;

	private short short_0;

	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private short short_1;

	private short short_2;

	private short short_3;

	private short short_4;

	private short short_5;

	private short short_6;

	private short short_7;

	private short short_8;

	private short short_9;

	private short short_10;

	private short short_11;

	private byte[] byte_1;

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private byte[] byte_2;

	private ushort ushort_4;

	private ushort ushort_5;

	private ushort ushort_6;

	private short short_12;

	private short short_13;

	private short short_14;

	private ushort ushort_7;

	private ushort ushort_8;

	private uint uint_4;

	private uint uint_5;

	private short short_15;

	private short short_16;

	private ushort ushort_9;

	private ushort ushort_10;

	private ushort ushort_11;

	public ushort Version
	{
		get
		{
			return ushort_0;
		}
		set
		{
			method_3(0, value);
			ushort_0 = value;
		}
	}

	public short XAvgCharWidth
	{
		get
		{
			return short_0;
		}
		set
		{
			method_2(2, value);
			short_0 = value;
		}
	}

	public ushort UsWeightClass
	{
		get
		{
			return ushort_1;
		}
		set
		{
			method_3(4, value);
			ushort_1 = value;
		}
	}

	public ushort UsWidthClass
	{
		get
		{
			return ushort_2;
		}
		set
		{
			method_3(6, value);
			ushort_2 = value;
		}
	}

	public ushort FsType
	{
		get
		{
			return ushort_3;
		}
		set
		{
			method_3(8, value);
			ushort_3 = value;
		}
	}

	public short YSubscriptXSize
	{
		get
		{
			return short_1;
		}
		set
		{
			method_2(10, value);
			short_1 = value;
		}
	}

	public short YSubscriptYSize
	{
		get
		{
			return short_2;
		}
		set
		{
			method_2(12, value);
			short_2 = value;
		}
	}

	public short YSubscriptXOffset
	{
		get
		{
			return short_3;
		}
		set
		{
			method_2(14, value);
			short_3 = value;
		}
	}

	public short YSubscriptYOffset
	{
		get
		{
			return short_4;
		}
		set
		{
			method_2(16, value);
			short_4 = value;
		}
	}

	public short YSuperscriptXSize
	{
		get
		{
			return short_5;
		}
		set
		{
			method_2(18, value);
			short_5 = value;
		}
	}

	public short YSuperscriptYSize
	{
		get
		{
			return short_6;
		}
		set
		{
			method_2(20, value);
			short_6 = value;
		}
	}

	public short YSuperscriptXOffset
	{
		get
		{
			return short_7;
		}
		set
		{
			method_2(22, value);
			short_7 = value;
		}
	}

	public short YSuperscriptYOffset
	{
		get
		{
			return short_8;
		}
		set
		{
			method_2(24, value);
			short_8 = value;
		}
	}

	public short YStrikeoutSize
	{
		get
		{
			return short_9;
		}
		set
		{
			method_2(26, value);
			short_9 = value;
		}
	}

	public short YStrikeoutPosition
	{
		get
		{
			return short_10;
		}
		set
		{
			method_2(28, value);
			short_10 = value;
		}
	}

	public short SFamilyClass
	{
		get
		{
			return short_11;
		}
		set
		{
			method_2(30, value);
			short_11 = value;
		}
	}

	public byte[] Panose
	{
		get
		{
			return byte_1;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Length != 10)
			{
				throw new ArgumentException("Length must be 10");
			}
			for (int i = 0; i < 10; i++)
			{
				method_4(32 + i, value[i]);
			}
			byte_1 = value;
		}
	}

	public uint UlUnicodeRange1
	{
		get
		{
			return uint_0;
		}
		set
		{
			method_1(42, value);
			uint_0 = value;
		}
	}

	public uint UlUnicodeRange2
	{
		get
		{
			return uint_1;
		}
		set
		{
			method_1(46, value);
			uint_1 = value;
		}
	}

	public uint UlUnicodeRange3
	{
		get
		{
			return uint_2;
		}
		set
		{
			method_1(50, value);
			uint_2 = value;
		}
	}

	public uint UlUnicodeRange4
	{
		get
		{
			return uint_3;
		}
		set
		{
			method_1(54, value);
			uint_3 = value;
		}
	}

	public byte[] AchVendID
	{
		get
		{
			return byte_2;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Length != 4)
			{
				throw new ArgumentException("Length must be 4");
			}
			for (int i = 0; i < 4; i++)
			{
				method_4(58 + i, value[i]);
			}
			byte_2 = value;
		}
	}

	public ushort FsSelection
	{
		get
		{
			return ushort_4;
		}
		set
		{
			method_3(62, value);
			ushort_4 = value;
		}
	}

	public ushort UsFirstCharIndex
	{
		get
		{
			return ushort_5;
		}
		set
		{
			method_3(64, value);
			ushort_5 = value;
		}
	}

	public ushort UsLastCharIndex
	{
		get
		{
			return ushort_6;
		}
		set
		{
			method_3(66, value);
			ushort_6 = value;
		}
	}

	public short STypoAscender
	{
		get
		{
			return short_12;
		}
		set
		{
			method_2(68, value);
			short_12 = value;
		}
	}

	public short STypoDescender
	{
		get
		{
			return short_13;
		}
		set
		{
			method_2(70, value);
			short_13 = value;
		}
	}

	public short STypoLineGap
	{
		get
		{
			return short_14;
		}
		set
		{
			method_2(72, value);
			short_14 = value;
		}
	}

	public ushort UsWinAscent
	{
		get
		{
			return ushort_7;
		}
		set
		{
			method_3(74, value);
			ushort_7 = value;
		}
	}

	public ushort UsWinDescent
	{
		get
		{
			return ushort_8;
		}
		set
		{
			method_3(76, value);
			ushort_8 = value;
		}
	}

	public uint UlCodePageRange1
	{
		get
		{
			return uint_4;
		}
		set
		{
			method_1(78, value);
			uint_4 = value;
		}
	}

	public uint UlCodePageRange2
	{
		get
		{
			return uint_5;
		}
		set
		{
			method_1(82, value);
			uint_5 = value;
		}
	}

	public short SxHeight
	{
		get
		{
			return short_15;
		}
		set
		{
			method_2(86, value);
			short_15 = value;
		}
	}

	public short SCapHeight
	{
		get
		{
			return short_16;
		}
		set
		{
			method_2(88, value);
			short_16 = value;
		}
	}

	public ushort UsDefaultChar
	{
		get
		{
			return ushort_9;
		}
		set
		{
			method_3(90, value);
			ushort_9 = value;
		}
	}

	public ushort UsBreakChar
	{
		get
		{
			return ushort_10;
		}
		set
		{
			method_3(92, value);
			ushort_10 = value;
		}
	}

	public ushort UsMaxContext
	{
		get
		{
			return ushort_11;
		}
		set
		{
			method_3(94, value);
			ushort_11 = value;
		}
	}

	public Class4590(byte[] data)
		: base(Class4593.string_7, data)
	{
		Class4572 @class = new Class4572(data);
		ushort_0 = @class.method_3();
		short_0 = @class.method_4();
		ushort_1 = @class.method_3();
		ushort_2 = @class.method_3();
		ushort_3 = @class.method_3();
		short_1 = @class.method_4();
		short_2 = @class.method_4();
		short_3 = @class.method_4();
		short_4 = @class.method_4();
		short_5 = @class.method_4();
		short_6 = @class.method_4();
		short_7 = @class.method_4();
		short_8 = @class.method_4();
		short_9 = @class.method_4();
		short_10 = @class.method_4();
		short_11 = @class.method_4();
		byte_1 = new byte[10];
		for (int i = 0; i < byte_1.Length; i++)
		{
			byte_1[i] = @class.ReadByte();
		}
		uint_0 = @class.method_1();
		uint_1 = @class.method_1();
		uint_2 = @class.method_1();
		uint_3 = @class.method_1();
		byte_2 = new byte[4];
		for (int j = 0; j < byte_2.Length; j++)
		{
			byte_2[j] = @class.ReadByte();
		}
		ushort_4 = @class.method_3();
		ushort_5 = @class.method_3();
		ushort_6 = @class.method_3();
		short_12 = @class.method_4();
		short_13 = @class.method_4();
		short_14 = @class.method_4();
		ushort_7 = @class.method_3();
		ushort_8 = @class.method_3();
		if (Version > 0)
		{
			uint_4 = @class.method_1();
			uint_5 = @class.method_1();
			if (Version > 1)
			{
				short_15 = @class.method_4();
				short_16 = @class.method_4();
				ushort_9 = @class.method_3();
				ushort_10 = @class.method_3();
				ushort_11 = @class.method_3();
			}
		}
		if (@class.Position != data.Length)
		{
			throw new InvalidOperationException("Incorrect length of 'OS/2' table");
		}
	}
}
