using System;
using System.Collections;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal sealed class xd8dc7bd7d15b58ea : xcd986872cf3bcf68
{
	private readonly bool x9bc44c00de51c757;

	public override bool IsFullFontEmbedded => false;

	public xd8dc7bd7d15b58ea(x6b1a899052c71a60 font, bool writeCffDataOnly)
		: base(font)
	{
		xb6954e766cee7b18();
		x9bc44c00de51c757 = writeCffDataOnly;
	}

	public override void WriteToStream(Stream dstStream)
	{
		x09ce2c02826e31a6 x09ce2c02826e31a = new x09ce2c02826e31a6();
		for (int i = 0; i < base.x8f0b229fb69d4269.xd44988f225497f3a; i++)
		{
			int num = (int)base.x8f0b229fb69d4269.x6d3720b962bd3112(i);
			x09ce2c02826e31a.set_xe6d4b1b411ed94b5(num, (object)num);
		}
		x6412d0c71c34c05c x6412d0c71c34c05c2 = new x6412d0c71c34c05c();
		x6412d0c71c34c05c2.xb9dd1993971153a6(base.x29f65b3e7616f6b3, x09ce2c02826e31a, dstStream, x9bc44c00de51c757);
	}

	public override Hashtable GetGlyphsDataSubset()
	{
		throw new InvalidOperationException("Parsing glyph data of OpenType(CFF) font is not supported.");
	}

	protected override int GetGlyphIndexInSubset(int glyphIndexInFont)
	{
		return glyphIndexInFont;
	}
}
