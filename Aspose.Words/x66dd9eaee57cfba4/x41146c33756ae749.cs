using System.Collections;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal sealed class x41146c33756ae749 : xcd986872cf3bcf68
{
	private readonly x09ce2c02826e31a6 x7bc67a78b2b7a1e9 = new x09ce2c02826e31a6();

	public override bool IsFullFontEmbedded => false;

	public x41146c33756ae749(x6b1a899052c71a60 font)
		: base(font)
	{
		xb6954e766cee7b18();
	}

	public override void WriteToStream(Stream dstStream)
	{
		x6412d0c71c34c05c x6412d0c71c34c05c2 = new x6412d0c71c34c05c();
		x6412d0c71c34c05c2.x8451c08dacb59ada(base.x29f65b3e7616f6b3, base.x8f0b229fb69d4269, x7bc67a78b2b7a1e9, dstStream);
	}

	public override Hashtable GetGlyphsDataSubset()
	{
		x6412d0c71c34c05c x6412d0c71c34c05c2 = new x6412d0c71c34c05c();
		return x6412d0c71c34c05c2.x0154acd692bb64a0(base.x29f65b3e7616f6b3, x7bc67a78b2b7a1e9, base.x29f65b3e7616f6b3.xa25a0348a20dc6ca);
	}

	protected override int GetGlyphIndexInSubset(int glyphIndexInFont)
	{
		if (x7bc67a78b2b7a1e9.xbc5dc59d0d9b620d(glyphIndexInFont))
		{
			return (int)x7bc67a78b2b7a1e9.get_xe6d4b1b411ed94b5(glyphIndexInFont);
		}
		int xd44988f225497f3a = x7bc67a78b2b7a1e9.xd44988f225497f3a;
		x7bc67a78b2b7a1e9.xd6b6ed77479ef68c(glyphIndexInFont, xd44988f225497f3a);
		return xd44988f225497f3a;
	}
}
