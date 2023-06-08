using xeb665d1aeef09d64;

namespace Aspose.Words.Fonts;

public class MemoryFontSource : FontSourceBase
{
	private readonly byte[] xfcd01e1d46e15910;

	public byte[] FontData => xfcd01e1d46e15910;

	public override FontSourceType Type => FontSourceType.MemoryFont;

	public MemoryFontSource(byte[] fontData)
	{
		xfcd01e1d46e15910 = fontData;
	}

	internal override x551d3b1862a114b1 x5eff1f3a09faac7e()
	{
		return new x6fe21b8d63477deb(xfcd01e1d46e15910);
	}
}
