using System.Drawing;
using Aspose;

namespace x4f4df92b75ba3b67;

internal abstract class x585f64260eb07f7b : x02cd5c9c8d54330e
{
	private const int x1de946bc1d4e792e = 1;

	private const int xf61e37187459ab34 = 3;

	protected abstract int TileWidth { get; }

	protected abstract int TileHeight { get; }

	protected override int PatternType => 1;

	internal x585f64260eb07f7b(x4882ae789be6e2ef context)
		: base(context)
	{
	}

	internal override void x0a2e1f2c2da67e52(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		base.x0a2e1f2c2da67e52(xbdfb620b7167944b);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/PaintType", 1);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/TilingType", 3);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/BBox", new RectangleF(0f, 0f, TileWidth, TileHeight));
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/XStep", TileWidth);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/YStep", TileHeight);
		xbdfb620b7167944b.x6210059f049f0d48("/Resources");
		xbdfb620b7167944b.xafb7e6f79ed43681();
		x2107de3fc2a21893.x0a2e1f2c2da67e52(xbdfb620b7167944b);
		xbdfb620b7167944b.x693a8d6d020474f2();
		xcf7a6694b0b373cb(xbdfb620b7167944b);
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		WriteStream();
		base.WriteToPdf(writer);
		x2107de3fc2a21893.x17c56662e4294017(writer);
	}

	protected override bool EqualsInternal(x02cd5c9c8d54330e other)
	{
		x585f64260eb07f7b x585f64260eb07f7b2 = (x585f64260eb07f7b)other;
		if (TileWidth == x585f64260eb07f7b2.TileWidth)
		{
			return TileHeight == x585f64260eb07f7b2.TileHeight;
		}
		return false;
	}

	[JavaThrows(true)]
	protected abstract void WriteStream();
}
