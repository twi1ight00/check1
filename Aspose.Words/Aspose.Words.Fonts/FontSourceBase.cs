using System;
using xeb665d1aeef09d64;

namespace Aspose.Words.Fonts;

public abstract class FontSourceBase
{
	public abstract FontSourceType Type { get; }

	internal abstract x551d3b1862a114b1 x5eff1f3a09faac7e();

	internal static FontSourceBase xef3486beca5d0ebc(x551d3b1862a114b1 x337e217cb3ba0627)
	{
		if (x337e217cb3ba0627 is x829cfec1381601a4)
		{
			return new SystemFontSource();
		}
		if (x337e217cb3ba0627 is xb3852af4ba803ccd)
		{
			return new FileFontSource(((xb3852af4ba803ccd)x337e217cb3ba0627).xa11af9961708073c);
		}
		if (x337e217cb3ba0627 is x6fe21b8d63477deb)
		{
			return new MemoryFontSource(((x6fe21b8d63477deb)x337e217cb3ba0627).xa7975e4945915df1);
		}
		if (x337e217cb3ba0627 is xcd3dbac2a50827fa)
		{
			xcd3dbac2a50827fa xcd3dbac2a50827fa = (xcd3dbac2a50827fa)x337e217cb3ba0627;
			return new FolderFontSource(xcd3dbac2a50827fa.xc7faa4629ea73ace, xcd3dbac2a50827fa.x9e0d704480302933);
		}
		throw new InvalidOperationException("Unexpected font source type.");
	}
}
