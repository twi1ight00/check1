using System;
using ns226;
using ns229;

namespace ns230;

internal class Class6032 : Class6026
{
	internal class Class6061 : Class6056
	{
		private int int_0 = -1;

		public static Class6061 smethod_1(Class6110 header, Class6017 data)
		{
			return new Class6061(header, data);
		}

		protected Class6061(Class6110 header, Class6017 data)
			: base(header, data)
		{
		}

		protected Class6061(Class6110 header, Class6016 data)
			: base(header, data)
		{
		}

		protected override Class6025 vmethod_6(Class6016 data)
		{
			return new Class6032(method_16(), data, int_0);
		}

		public void method_18(int numGlyphs)
		{
			if (numGlyphs < 0)
			{
				throw new InvalidOperationException("Number of glyphs can't be negative.");
			}
			int_0 = numGlyphs;
			((Class6032)method_17()).int_0 = numGlyphs;
		}
	}

	private enum Enum763
	{
		const_0 = 0,
		const_1 = 2,
		const_2 = 4,
		const_3 = 8,
		const_4 = 0,
		const_5 = 1,
		const_6 = 2
	}

	private int int_0;

	private Class6032(Class6110 header, Class6016 data, int numGlyphs)
		: base(header, data)
	{
		int_0 = numGlyphs;
	}

	public int method_12()
	{
		return class6016_0.method_16(0);
	}

	public int method_13()
	{
		return class6016_0.method_17(2);
	}

	public int method_14()
	{
		return class6016_0.method_22(4);
	}

	public int method_15(int recordIx)
	{
		if (recordIx < 0 || recordIx >= method_13())
		{
			throw new IndexOutOfRangeException();
		}
		return class6016_0.method_13(8 + recordIx * method_14());
	}

	public int method_16(int recordIx)
	{
		if (recordIx < 0 || recordIx >= method_13())
		{
			throw new IndexOutOfRangeException();
		}
		return class6016_0.method_13(8 + recordIx * method_14() + 1);
	}

	public int method_17(int recordIx, int glyphNum)
	{
		if (recordIx < 0 || recordIx >= method_13() || glyphNum < 0 || glyphNum >= int_0)
		{
			throw new IndexOutOfRangeException();
		}
		return class6016_0.method_13(8 + recordIx * method_14() + 2 + glyphNum);
	}
}
