using ns218;
using ns221;
using ns271;

namespace ns272;

internal class Class6646 : Class6644
{
	private ushort[] ushort_2;

	private uint uint_0;

	private uint uint_1;

	public Class6646(ushort platformID, ushort platformSpecificID, Class6634 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	[Attribute7(true)]
	internal override void vmethod_0(Class5950 ttfReader)
	{
		ttfReader.method_1();
		ttfReader.method_1();
		uint_0 = ttfReader.method_1();
		uint_1 = ttfReader.method_1();
		ushort_2 = new ushort[uint_1];
		for (int i = 0; i < uint_1; i++)
		{
			ushort_2[i] = ttfReader.method_3();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_3(char charCode)
	{
		if (charCode >= uint_0 && charCode < uint_0 + uint_1)
		{
			return ushort_2[charCode - uint_0];
		}
		return 0;
	}

	internal override Class6735 vmethod_2(Class6728 hMetrics)
	{
		Class6735 @class = new Class6735(((Class6636)base.BaseTable).IsSymbolicFont);
		for (char c = (char)uint_0; c <= uint_0 + uint_1; c = (char)(c + 1))
		{
			int num = vmethod_3(c);
			if (num != 0)
			{
				Struct223 @struct = hMetrics.method_0(num);
				Class6734 class2 = new Class6734(c, num, @struct.ushort_0, @struct.short_0);
				@class.Add(class2);
				if (class2.OldGlyphIndex == 0)
				{
					@class.MissingGlyph = class2;
				}
			}
		}
		return @class;
	}
}
