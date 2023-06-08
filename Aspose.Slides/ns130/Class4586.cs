using System;

namespace ns130;

internal class Class4586 : Class4585
{
	public const int int_1 = 8;

	private const byte byte_1 = 0;

	private const byte byte_2 = 4;

	private const byte byte_3 = 8;

	private const byte byte_4 = 12;

	private const byte byte_5 = 16;

	private const byte byte_6 = 18;

	private const byte byte_7 = 20;

	private const byte byte_8 = 28;

	private const byte byte_9 = 36;

	private const byte byte_10 = 38;

	private const byte byte_11 = 40;

	private const byte byte_12 = 42;

	private const byte byte_13 = 44;

	private const byte byte_14 = 46;

	private const byte byte_15 = 48;

	private const byte byte_16 = 50;

	private const byte byte_17 = 52;

	private const int int_2 = 16;

	public int int_3;

	public int int_4;

	public uint uint_0;

	public ushort ushort_0;

	public long long_0;

	public long long_1;

	public ushort ushort_1;

	public ushort ushort_2;

	public short short_0;

	public short short_1;

	private uint uint_1;

	private ushort ushort_3;

	private short short_2;

	private short short_3;

	private short short_4;

	private short short_5;

	private short short_6;

	public uint ChekSumAdjustment
	{
		get
		{
			return uint_1;
		}
		set
		{
			method_1(8, value);
			uint_1 = value;
		}
	}

	public ushort Flags
	{
		get
		{
			return ushort_3;
		}
		set
		{
			method_3(16, value);
			ushort_3 = value;
		}
	}

	public short XMin
	{
		get
		{
			return short_2;
		}
		set
		{
			method_2(36, value);
			short_2 = value;
		}
	}

	public short YMin
	{
		get
		{
			return short_3;
		}
		set
		{
			method_2(38, value);
			short_3 = value;
		}
	}

	public short XMax
	{
		get
		{
			return short_2;
		}
		set
		{
			method_2(40, value);
			short_4 = value;
		}
	}

	public short YMax
	{
		get
		{
			return short_3;
		}
		set
		{
			method_2(42, value);
			short_5 = value;
		}
	}

	public short IndexToLocFormat
	{
		get
		{
			return short_6;
		}
		set
		{
			method_2(50, value);
			short_6 = value;
		}
	}

	public bool HasNonLinearScaling
	{
		get
		{
			return (Flags & 0x10) == 16;
		}
		set
		{
			if (value)
			{
				Flags |= 16;
			}
			else
			{
				Flags = (ushort)(Flags & 0xFFFFFFEFu);
			}
		}
	}

	public Class4586(byte[] data)
		: base(Class4593.string_2, data)
	{
		Class4572 @class = new Class4572(data);
		int_3 = @class.method_2();
		if (int_3 != 65536)
		{
			throw new InvalidOperationException($"Version of 'head' table is incorrect: {int_3}, expected {65536} for v1.0");
		}
		int_4 = @class.method_2();
		ChekSumAdjustment = 0u;
		@class.Position += 4;
		uint_0 = @class.method_1();
		if (uint_0 != 1594834165)
		{
			throw new InvalidOperationException($"Magic number of 'head' table is incorrect: {uint_0}, expected {1594834165}");
		}
		ushort_3 = @class.method_3();
		ushort_0 = @class.method_3();
		long_0 = @class.method_0();
		long_1 = @class.method_0();
		short_2 = @class.method_4();
		short_3 = @class.method_4();
		short_4 = @class.method_4();
		short_5 = @class.method_4();
		ushort_1 = @class.method_3();
		ushort_2 = @class.method_3();
		short_0 = @class.method_4();
		short_6 = @class.method_4();
		short_1 = @class.method_4();
		if (data.Length != @class.Position)
		{
			throw new InvalidOperationException("Incorrect length of 'head' table");
		}
	}
}
