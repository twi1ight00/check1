using System;
using Aspose.Words.Fonts;

namespace x4b4f8b01ec4cb4b2;

internal class x393d198b88cf5ed5
{
	private readonly byte[] x73f065a6b420cfe1;

	private readonly EmbeddedFontFormat xb7378cf08fa15006;

	private readonly EmbeddedFontStyle x5d9fbd9603e9dee5;

	private readonly bool xabd275edb44d0798;

	internal byte[] x6b73aa01aa019d3a => x73f065a6b420cfe1;

	internal EmbeddedFontFormat xa890d2fd18bed2bc => xb7378cf08fa15006;

	internal EmbeddedFontStyle xfe2178c1f916f36c => x5d9fbd9603e9dee5;

	internal bool xf485d4dac21a6985 => xabd275edb44d0798;

	internal x393d198b88cf5ed5(byte[] fontData, EmbeddedFontFormat format, EmbeddedFontStyle style, bool isSubsetted)
	{
		if (fontData == null)
		{
			throw new ArgumentNullException("fontData");
		}
		x73f065a6b420cfe1 = fontData;
		xb7378cf08fa15006 = format;
		x5d9fbd9603e9dee5 = style;
		xabd275edb44d0798 = isSubsetted;
	}
}
