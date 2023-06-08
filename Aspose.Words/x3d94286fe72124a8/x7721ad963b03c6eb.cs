using System;
using System.Drawing;
using Aspose.Words.Drawing;
using x120d4bb5c80fb10c;

namespace x3d94286fe72124a8;

internal class x7721ad963b03c6eb : xe973e6aa8aca7f14
{
	private float x3ebe5f3018800e96;

	private byte[] x4740484584c01f8d;

	private bool xf6790bb8e15f87a1;

	private bool x3458506527ed94b0;

	private bool xd7590daad2e0f17e;

	private bool x27894b7f31d4c51e;

	private bool x417601408fb3a32c;

	private SizeF xd256001595a5f3ad = SizeF.Empty;

	private RectangleF xbbb61bb1f3d245fb = RectangleF.Empty;

	private ShapeBase x317be79405176667;

	private readonly DrawingML xfa47956e895ee573;

	private readonly x2edb8efcf734419a xc320ff654fad5129 = new x2edb8efcf734419a();

	internal float x8b3e254648679663 => x3ebe5f3018800e96;

	public RectangleF xfe502558fa04ffb1
	{
		get
		{
			return xbbb61bb1f3d245fb;
		}
		set
		{
			xbbb61bb1f3d245fb = value;
		}
	}

	internal ShapeBase xa9993ed2e0c64574 => x317be79405176667;

	internal SizeF x178374f0600f2696
	{
		get
		{
			return xd256001595a5f3ad;
		}
		set
		{
			xd256001595a5f3ad = value;
		}
	}

	internal bool xbc54ad0db5dd5f54 => x417601408fb3a32c;

	internal bool x7d3f5b36733451fa => x27894b7f31d4c51e;

	internal bool x3e68ffe1419e6481 => xd7590daad2e0f17e;

	internal bool x6ffa01a29fd5c940 => x3458506527ed94b0;

	internal bool x2cd066fdf892c9fb => xf6790bb8e15f87a1;

	internal byte[] xb4ea914a0dc4328c => x4740484584c01f8d;

	internal x2edb8efcf734419a x2edb8efcf734419a
	{
		get
		{
			if (xb2e6daabb895b37f && xfa47956e895ee573.xf7125312c7ee115c.xab6edfb47ff0b74c == WrapType.Tight)
			{
				return xc320ff654fad5129;
			}
			if (!xb2e6daabb895b37f && x317be79405176667.xf7125312c7ee115c.xab6edfb47ff0b74c == WrapType.Tight)
			{
				return xc320ff654fad5129;
			}
			return null;
		}
	}

	internal DrawingML x9345853531733647 => xfa47956e895ee573;

	internal bool xb2e6daabb895b37f => x9345853531733647 != null;

	internal x7721ad963b03c6eb(ShapeBase shape)
	{
		if (shape == null)
		{
			throw new ArgumentNullException("shape");
		}
		x317be79405176667 = shape;
		x3ebe5f3018800e96 = (float)shape.Width;
	}

	internal x7721ad963b03c6eb(ShapeBase shape, SizeF alteredSize)
		: this(shape)
	{
		xd256001595a5f3ad = alteredSize;
	}

	internal x7721ad963b03c6eb(ShapeBase shape, SizeF alteredSize, float containerWidth)
		: this(shape, alteredSize)
	{
		if (containerWidth > 0f)
		{
			x3ebe5f3018800e96 = containerWidth;
		}
	}

	internal x7721ad963b03c6eb(SizeF alteredSize, float containerWidth)
	{
		xd256001595a5f3ad = alteredSize;
		if (containerWidth > 0f)
		{
			x3ebe5f3018800e96 = containerWidth;
		}
	}

	internal x7721ad963b03c6eb(ShapeBase shape, SizeF alteredSize, float containerWidth, byte[] alteredImage, bool isLeftBorderIgnored, bool isTopBorderIgnored, bool isRightBorderIgnored, bool isBottomBorderIgnored)
		: this(shape, alteredSize, containerWidth)
	{
		x4740484584c01f8d = alteredImage;
		xd7590daad2e0f17e = isLeftBorderIgnored;
		xf6790bb8e15f87a1 = isTopBorderIgnored;
		x27894b7f31d4c51e = isRightBorderIgnored;
		x3458506527ed94b0 = isBottomBorderIgnored;
	}

	internal x7721ad963b03c6eb(DrawingML dmlShape)
	{
		xfa47956e895ee573 = dmlShape;
	}

	internal x7721ad963b03c6eb x8b61531c8ea35b85()
	{
		return (x7721ad963b03c6eb)MemberwiseClone();
	}
}
