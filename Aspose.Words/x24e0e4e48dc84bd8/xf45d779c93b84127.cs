using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using x74500b509de15565;

namespace x24e0e4e48dc84bd8;

internal class xf45d779c93b84127 : x8a4357ae13046a35
{
	private Region x22ec4ec5d9dae8c4;

	public xf45d779c93b84127(RectangleF metafileBounds)
		: base(metafileBounds)
	{
	}

	public void x74f5a1ef3906e23c()
	{
		x22ec4ec5d9dae8c4 = null;
		xbb51cf398865871a();
	}

	public void x3ba89ef66ec1bfc3(Region xa4d52e34b62b5495, CombineMode xa4aa8b4150b11435)
	{
		xf0d3c9279444c480();
		switch (xa4aa8b4150b11435)
		{
		case CombineMode.Replace:
			x22ec4ec5d9dae8c4 = xa4d52e34b62b5495;
			break;
		case CombineMode.Intersect:
			x22ec4ec5d9dae8c4.Intersect(xa4d52e34b62b5495);
			break;
		case CombineMode.Union:
			x22ec4ec5d9dae8c4.Union(xa4d52e34b62b5495);
			break;
		case CombineMode.Xor:
			x22ec4ec5d9dae8c4.Xor(xa4d52e34b62b5495);
			break;
		case CombineMode.Exclude:
			x22ec4ec5d9dae8c4.Exclude(xa4d52e34b62b5495);
			break;
		case CombineMode.Complement:
			x22ec4ec5d9dae8c4.Complement(xa4d52e34b62b5495);
			break;
		default:
			throw new ArgumentOutOfRangeException("mode");
		}
		xbb51cf398865871a();
	}

	public void xf1d9b91c9700c401(SizeF x374ea4fe62468d0f)
	{
		if (!x374ea4fe62468d0f.IsEmpty && x22ec4ec5d9dae8c4 != null)
		{
			x22ec4ec5d9dae8c4.Translate(x374ea4fe62468d0f.Width, x374ea4fe62468d0f.Height);
			xbb51cf398865871a();
		}
	}

	public xf45d779c93b84127 x8b61531c8ea35b85()
	{
		xf45d779c93b84127 xf45d779c93b84128 = new xf45d779c93b84127(xa78054fab93d29c1);
		if (x22ec4ec5d9dae8c4 != null)
		{
			xf45d779c93b84128.x22ec4ec5d9dae8c4 = x22ec4ec5d9dae8c4.Clone();
		}
		return xf45d779c93b84128;
	}

	private void xf0d3c9279444c480()
	{
		if (x22ec4ec5d9dae8c4 == null)
		{
			x22ec4ec5d9dae8c4 = new Region();
		}
	}

	protected override Region GetCurrentClippingRegion()
	{
		return x22ec4ec5d9dae8c4;
	}
}
