using ns218;
using ns221;
using ns271;

namespace ns272;

internal class Class6649 : Class6644
{
	private ushort ushort_2;

	private ushort ushort_3;

	private ushort[] ushort_4;

	public Class6649(Class6634 baseTable)
		: base(3, 1, baseTable)
	{
	}

	public Class6649(ushort platformID, ushort platformSpecificID, Class6634 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	[Attribute7(true)]
	internal override void vmethod_0(Class5950 ttfReader)
	{
		ttfReader.method_3();
		ttfReader.method_3();
		ushort_2 = ttfReader.method_3();
		ushort_3 = ttfReader.method_3();
		ushort_4 = new ushort[ushort_3];
		for (int i = 0; i < ushort_3; i++)
		{
			ushort_4[i] = ttfReader.method_3();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_3(char charCode)
	{
		if (charCode >= ushort_2 && charCode < ushort_2 + ushort_3)
		{
			return ushort_4[charCode - ushort_2];
		}
		return 0;
	}

	internal override Class6735 vmethod_2(Class6728 hMetrics)
	{
		Class6735 @class = new Class6735(((Class6636)base.BaseTable).IsSymbolicFont);
		for (char c = (char)ushort_2; c <= ushort_2 + ushort_3; c = (char)(c + 1))
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
