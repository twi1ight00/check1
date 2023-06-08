using System;

namespace ns130;

internal class Class4589 : Class4585
{
	private const ushort ushort_0 = 26;

	private const ushort ushort_1 = 28;

	public int int_1;

	public ushort ushort_2;

	public ushort ushort_3;

	public ushort ushort_4;

	public ushort ushort_5;

	public ushort ushort_6;

	public ushort ushort_7;

	public ushort ushort_8;

	public ushort ushort_9;

	public ushort ushort_10;

	public ushort ushort_11;

	public ushort ushort_12;

	public ushort ushort_13;

	private ushort ushort_14;

	private ushort ushort_15;

	public ushort MaxSizeOfInstructions
	{
		get
		{
			return ushort_14;
		}
		set
		{
			method_3(26, value);
			ushort_14 = value;
		}
	}

	public ushort MaxComponentElements
	{
		get
		{
			return ushort_15;
		}
		set
		{
			method_3(28, value);
			ushort_15 = value;
		}
	}

	public Class4589(byte[] data)
		: base(Class4593.string_5, data)
	{
		Class4572 @class = new Class4572(data);
		int_1 = @class.method_2();
		if (int_1 != 20480 && int_1 != 65536)
		{
			throw new InvalidOperationException($"Version of 'maxp' table is incorrect: {int_1}, expected {20480} for v0.5 or {65536} for v1.0");
		}
		ushort_2 = @class.method_3();
		if (int_1 == 65536)
		{
			ushort_3 = @class.method_3();
			ushort_4 = @class.method_3();
			ushort_5 = @class.method_3();
			ushort_6 = @class.method_3();
			ushort_7 = @class.method_3();
			ushort_8 = @class.method_3();
			ushort_9 = @class.method_3();
			ushort_10 = @class.method_3();
			ushort_11 = @class.method_3();
			ushort_12 = @class.method_3();
			ushort_14 = @class.method_3();
			ushort_15 = @class.method_3();
			ushort_13 = @class.method_3();
		}
		if (data.Length != @class.Position)
		{
			throw new InvalidOperationException("Incorrect length of 'maxp' table");
		}
	}
}
