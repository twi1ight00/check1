using System;

namespace ns130;

internal class Class4588 : Class4585
{
	public int int_1;

	private ushort[] ushort_0;

	private short[] short_0;

	public Class4588(int numberOfMetrics, byte[] data)
		: base(Class4593.string_4, data)
	{
		if (numberOfMetrics <= 0)
		{
			throw new ArgumentException("Number of metrics in 'htmx' table must be more than zero");
		}
		Class4572 @class = new Class4572(data);
		int_1 = numberOfMetrics;
		ushort_0 = new ushort[numberOfMetrics];
		short_0 = new short[numberOfMetrics];
		for (int i = 0; i < numberOfMetrics; i++)
		{
			ushort_0[i] = @class.method_3();
			short_0[i] = @class.method_4();
		}
	}

	public ushort method_5(int glyphId)
	{
		if (glyphId < int_1)
		{
			return ushort_0[glyphId];
		}
		return ushort_0[int_1 - 1];
	}

	public short method_6(int glyphId)
	{
		if (glyphId < int_1)
		{
			return short_0[glyphId];
		}
		return short_0[int_1 - 1];
	}
}
