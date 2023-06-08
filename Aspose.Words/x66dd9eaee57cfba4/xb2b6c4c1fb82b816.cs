using System;
using System.Collections;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class xb2b6c4c1fb82b816 : xcd986872cf3bcf68
{
	public override bool IsFullFontEmbedded => true;

	public xb2b6c4c1fb82b816(x6b1a899052c71a60 font)
		: base(font)
	{
		xb6954e766cee7b18();
		xbb24f298c1b2f5e7();
	}

	private void xbb24f298c1b2f5e7()
	{
		foreach (x7c1d47b289dfd9fa item in base.x29f65b3e7616f6b3.x1e6da4134d115607.xe4a88350013963a1)
		{
			base.x8f0b229fb69d4269.set_xe6d4b1b411ed94b5(item.xfea0b9f75f567474, (object)item.xf642ec8fe8ccb98e);
		}
	}

	protected override int GetGlyphIndexInSubset(int glyphIndexInFont)
	{
		return glyphIndexInFont;
	}

	public override void WriteToStream(Stream dstStream)
	{
		if (base.x29f65b3e7616f6b3.xbdb46eca7415042d)
		{
			x6412d0c71c34c05c x6412d0c71c34c05c2 = new x6412d0c71c34c05c();
			x6412d0c71c34c05c2.x81f3fe7a911999bc(base.x29f65b3e7616f6b3, dstStream);
			return;
		}
		using Stream x23cda4cfdf81f2cf = base.x29f65b3e7616f6b3.x6b73aa01aa019d3a.OpenStream();
		x0d299f323d241756.x3ad8e53785c39acd(x23cda4cfdf81f2cf, dstStream);
	}

	public override Hashtable GetGlyphsDataSubset()
	{
		throw new InvalidOperationException("Parsing glyph data of OpenType(CFF) font is not supported.");
	}
}
