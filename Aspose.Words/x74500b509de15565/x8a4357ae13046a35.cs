using System.Drawing;
using x1c8faa688b1f0b0c;
using xf9a9481c3f63a419;

namespace x74500b509de15565;

internal abstract class x8a4357ae13046a35
{
	protected RectangleF xa78054fab93d29c1;

	private xab391c46ff9a0a38 x2b9332479c7c0fcf;

	public xab391c46ff9a0a38 x385638247aa8a54b
	{
		get
		{
			if (x2b9332479c7c0fcf != null)
			{
				return x2b9332479c7c0fcf;
			}
			Region currentClippingRegion = GetCurrentClippingRegion();
			if (currentClippingRegion == null)
			{
				return null;
			}
			currentClippingRegion = currentClippingRegion.Clone();
			currentClippingRegion.Intersect(xa78054fab93d29c1);
			x2b9332479c7c0fcf = x8ebf543aaab29d16.x2ffd000f9d74db27(currentClippingRegion);
			return x2b9332479c7c0fcf;
		}
	}

	protected x8a4357ae13046a35(RectangleF metafileBouds)
	{
		xa78054fab93d29c1 = metafileBouds;
	}

	protected void xbb51cf398865871a()
	{
		x2b9332479c7c0fcf = null;
	}

	protected abstract Region GetCurrentClippingRegion();
}
