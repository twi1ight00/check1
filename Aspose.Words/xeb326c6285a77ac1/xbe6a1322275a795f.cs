using System;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;

namespace xeb326c6285a77ac1;

internal class xbe6a1322275a795f : x87fba3f79fbaf7ab
{
	private xb8ea2c3b3cf649a4 xc9403090249a8b88;

	private x4d94e8d9583fbd90 x0c596d5805c971d8;

	private x4d94e8d9583fbd90 x8a967c74a53b468e;

	private xb8ea2c3b3cf649a4 xd4d09547fd40922b;

	internal xb8ea2c3b3cf649a4 x611a32e0cc2af3c4
	{
		get
		{
			return xc9403090249a8b88;
		}
		set
		{
			xc9403090249a8b88 = value;
		}
	}

	internal xb8ea2c3b3cf649a4 x2a733472cd99828b
	{
		get
		{
			return xd4d09547fd40922b;
		}
		set
		{
			xd4d09547fd40922b = value;
		}
	}

	internal x4d94e8d9583fbd90 xba40a5b113d122a1
	{
		get
		{
			return x0c596d5805c971d8;
		}
		set
		{
			x0c596d5805c971d8 = value;
		}
	}

	internal x4d94e8d9583fbd90 xd0e1bc5fa1ad3709
	{
		get
		{
			return x8a967c74a53b468e;
		}
		set
		{
			x8a967c74a53b468e = value;
		}
	}

	public void xe406325e56f74b46(x9118c2b63bc20309 x0f7b23d1c393aed9, x1cab6af0a41b70e2 x6ac16bf6efd00832)
	{
		if (!(Math.Abs(x611a32e0cc2af3c4.x3f88a25febd23896(x0f7b23d1c393aed9.x2d4e614b9aa850f8)) < 1.0) && !(Math.Abs(x2a733472cd99828b.x3f88a25febd23896(x0f7b23d1c393aed9.x2d4e614b9aa850f8)) < 1.0))
		{
			double num = xba40a5b113d122a1.xcfcff08ef1b605a7(x0f7b23d1c393aed9.x2d4e614b9aa850f8);
			double xbdcb5f8a10694ec = xd0e1bc5fa1ad3709.xcfcff08ef1b605a7(x0f7b23d1c393aed9.x2d4e614b9aa850f8);
			PointF x06d6c4b9ca4d75f = x0f7b23d1c393aed9.x06d6c4b9ca4d75f0;
			double num2 = x0f7b23d1c393aed9.x704d4080dede6a41(x611a32e0cc2af3c4, x8a45f1122e39b31b: false);
			double num3 = x0f7b23d1c393aed9.x704d4080dede6a41(x2a733472cd99828b, x8a45f1122e39b31b: true);
			double num4 = Math.Atan2(1.0 / num2 * Math.Sin(num), 1.0 / num3 * Math.Cos(num));
			double num5 = Math.Round((double)x06d6c4b9ca4d75f.X - num3 * Math.Cos(num4));
			double num6 = Math.Round((double)x06d6c4b9ca4d75f.Y - num2 * Math.Sin(num4));
			double num7 = num5 - num3;
			double num8 = num6 - num2;
			RectangleF bounds = new RectangleF((float)num7, (float)num8, (float)(num3 * 2.0), (float)(num2 * 2.0));
			x1fb5d45c2d0b868a x1fb5d45c2d0b868a = new x1fb5d45c2d0b868a(bounds, x15e971129fd80714.xc9211137ad7bfa2a(num), x15e971129fd80714.xc9211137ad7bfa2a(xbdcb5f8a10694ec));
			x6ac16bf6efd00832.xb6e955ab98a0878c(x1fb5d45c2d0b868a);
			x0f7b23d1c393aed9.x06d6c4b9ca4d75f0 = x1fb5d45c2d0b868a.x0f74da0eed3dd981();
		}
	}
}
