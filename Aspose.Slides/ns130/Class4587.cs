using System;

namespace ns130;

internal class Class4587 : Class4585
{
	private const byte byte_1 = 0;

	private const byte byte_2 = 4;

	private const byte byte_3 = 6;

	private const byte byte_4 = 8;

	private const byte byte_5 = 10;

	private const byte byte_6 = 12;

	private const byte byte_7 = 14;

	private const byte byte_8 = 16;

	private const byte byte_9 = 18;

	private const byte byte_10 = 20;

	private const byte byte_11 = 22;

	private const byte byte_12 = 32;

	private const byte byte_13 = 34;

	public int int_1;

	public short short_0;

	public short short_1;

	public short short_2;

	public short short_3;

	public short short_4;

	public ushort ushort_0;

	private short short_5;

	private short short_6;

	private ushort ushort_1;

	private short short_7;

	private short short_8;

	private short short_9;

	public short Ascender
	{
		get
		{
			return short_5;
		}
		set
		{
			method_2(4, value);
			short_5 = value;
		}
	}

	public short Descender
	{
		get
		{
			return short_6;
		}
		set
		{
			method_2(6, value);
			short_6 = value;
		}
	}

	public ushort AdvanceWidthMax
	{
		get
		{
			return ushort_1;
		}
		set
		{
			method_3(10, value);
			ushort_1 = value;
		}
	}

	public short MinLeftSideBearing
	{
		get
		{
			return short_7;
		}
		set
		{
			method_2(12, value);
			short_7 = value;
		}
	}

	public short MinRightSideBearing
	{
		get
		{
			return short_8;
		}
		set
		{
			method_2(14, value);
			short_8 = value;
		}
	}

	public short XMaxExtent
	{
		get
		{
			return short_9;
		}
		set
		{
			method_2(16, value);
			short_9 = value;
		}
	}

	public Class4587(byte[] data)
		: base(Class4593.string_3, data)
	{
		Class4572 @class = new Class4572(data);
		int_1 = @class.method_2();
		if (int_1 != 65536)
		{
			throw new InvalidOperationException($"Version of 'hhea' table is incorrect: {int_1}, expected {65536} for v1.0");
		}
		short_5 = @class.method_4();
		short_6 = @class.method_4();
		short_0 = @class.method_4();
		ushort_1 = @class.method_3();
		short_7 = @class.method_4();
		short_8 = @class.method_4();
		short_9 = @class.method_4();
		short_1 = @class.method_4();
		short_2 = @class.method_4();
		short_3 = @class.method_4();
		for (int i = 0; i < 4; i++)
		{
			@class.method_4();
		}
		short_4 = @class.method_4();
		ushort_0 = @class.method_3();
		if (data.Length != @class.Position)
		{
			throw new InvalidOperationException("Incorrect length of 'hhea' table");
		}
	}
}
