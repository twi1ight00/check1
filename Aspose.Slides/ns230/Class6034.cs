using System;
using ns226;
using ns229;

namespace ns230;

internal class Class6034 : Class6026
{
	internal class Class6063 : Class6056
	{
		private int int_0 = -1;

		private int int_1 = -1;

		public static Class6063 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6063(header, data);
		}

		protected Class6063(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		protected Class6063(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6034(method_16(), data, int_0, int_1);
		}

		public void method_18(int numHMetrics)
		{
			if (numHMetrics < 0)
			{
				throw new InvalidOperationException("Number of metrics can't be negative.");
			}
			int_0 = numHMetrics;
			((Class6034)method_17()).int_0 = numHMetrics;
		}

		public void method_19(int numGlyphs)
		{
			if (numGlyphs < 0)
			{
				throw new InvalidOperationException("Number of glyphs can't be negative.");
			}
			int_1 = numGlyphs;
			((Class6034)method_17()).int_1 = numGlyphs;
		}
	}

	private enum Enum765
	{
		const_0 = 0,
		const_1 = 4,
		const_2 = 0,
		const_3 = 2,
		const_4 = 2
	}

	private int int_0;

	private int int_1;

	private Class6034(Class6110 header, Class6016 data, int numHMetrics, int numGlyphs)
		: base(header, data)
	{
		int_0 = numHMetrics;
		int_1 = numGlyphs;
	}

	public int method_12()
	{
		return int_0;
	}

	public int method_13()
	{
		return int_1 - int_0;
	}

	public int method_14(int entry)
	{
		if (entry > int_0)
		{
			throw new IndexOutOfRangeException();
		}
		int index = entry * 4;
		return class6016_0.method_16(index);
	}

	public int method_15(int entry)
	{
		if (entry > int_0)
		{
			throw new IndexOutOfRangeException();
		}
		int index = entry * 4 + 2;
		return class6016_0.method_17(index);
	}

	public int method_16(int entry)
	{
		if (entry > method_13())
		{
			throw new IndexOutOfRangeException();
		}
		int index = int_0 * 4 + entry * 2;
		return class6016_0.method_17(index);
	}

	public int method_17(int glyphId)
	{
		if (glyphId < int_0)
		{
			return method_14(glyphId);
		}
		return method_14(int_0 - 1);
	}

	public int method_18(int glyphId)
	{
		if (glyphId < int_0)
		{
			return method_15(glyphId);
		}
		return method_16(glyphId - int_0);
	}
}
