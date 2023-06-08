using ns218;
using ns221;
using ns271;

namespace ns272;

internal class Class6645 : Class6644
{
	private byte[] byte_0;

	public Class6645(ushort platformID, ushort platformSpecificID, Class6634 baseTable)
		: base(platformID, platformSpecificID, baseTable)
	{
	}

	[Attribute7(true)]
	internal override void vmethod_0(Class5950 ttfReader)
	{
		ttfReader.method_3();
		ttfReader.method_3();
		byte_0 = new byte[256];
		for (int i = 0; i < byte_0.Length; i++)
		{
			byte_0[i] = ttfReader.ReadByte();
		}
		base.vmethod_0(ttfReader);
	}

	public override int vmethod_3(char charCode)
	{
		if (charCode >= '\0' && charCode <= 'ÿ')
		{
			return byte_0[(uint)charCode];
		}
		return 0;
	}

	internal override Class6735 vmethod_2(Class6728 hMetrics)
	{
		Class6735 @class = new Class6735(((Class6636)base.BaseTable).IsSymbolicFont);
		for (char c = '\0'; c <= 'ÿ'; c = (char)(c + 1))
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
