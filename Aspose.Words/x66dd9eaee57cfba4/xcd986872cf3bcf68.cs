using System.Collections;
using System.IO;
using Aspose;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal abstract class xcd986872cf3bcf68
{
	private readonly x6b1a899052c71a60 x83cd810ab70afec3;

	private readonly x09ce2c02826e31a6 x140d084bd67907b4 = new x09ce2c02826e31a6();

	public x6b1a899052c71a60 x29f65b3e7616f6b3 => x83cd810ab70afec3;

	public x09ce2c02826e31a6 x8f0b229fb69d4269 => x140d084bd67907b4;

	public abstract bool IsFullFontEmbedded { get; }

	protected xcd986872cf3bcf68(x6b1a899052c71a60 font)
	{
		x83cd810ab70afec3 = font;
	}

	protected void xb6954e766cee7b18()
	{
		x3452aa488cc9006d(x29f65b3e7616f6b3.x1e6da4134d115607.x03efdcbb7b70d603.xfea0b9f75f567474);
	}

	public int x3452aa488cc9006d(int x3c4da2980d043c95)
	{
		if (x140d084bd67907b4.xbc5dc59d0d9b620d(x3c4da2980d043c95))
		{
			return (int)x140d084bd67907b4.get_xe6d4b1b411ed94b5(x3c4da2980d043c95);
		}
		x7c1d47b289dfd9fa x7c1d47b289dfd9fa2 = x29f65b3e7616f6b3.x1e6da4134d115607.x12f49b36ab885c48(x3c4da2980d043c95);
		int glyphIndexInSubset = GetGlyphIndexInSubset(x7c1d47b289dfd9fa2.xf642ec8fe8ccb98e);
		x140d084bd67907b4.set_xe6d4b1b411ed94b5(x3c4da2980d043c95, (object)glyphIndexInSubset);
		return glyphIndexInSubset;
	}

	[JavaThrows(true)]
	public abstract void WriteToStream(Stream dstStream);

	[JavaThrows(true)]
	public abstract Hashtable GetGlyphsDataSubset();

	protected abstract int GetGlyphIndexInSubset(int glyphIndexInFont);
}
