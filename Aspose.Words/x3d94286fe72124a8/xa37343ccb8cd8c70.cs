using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x3d94286fe72124a8;

internal class xa37343ccb8cd8c70
{
	private RectangleF xd9aa80aca64aabec = RectangleF.Empty;

	private x44f2b8bf33b16275[] xbcca09d49a9cc4a3;

	private PointF[] x7e860e67e98d3221;

	private xab391c46ff9a0a38 x792944894802ea12;

	private x4fdf549af9de6b97 x4ce86e278aed4879;

	private x1cab6af0a41b70e2 x452b030a6e9cfa9e;

	private PointF xd67cf4e82e5a9538 = PointF.Empty;

	private bool x74713e9129acc4be;

	private xb8e7e788f6d59708 x9b1777152cf410e1;

	private object x4d440edd8b06519d;

	private x31c19fcb724dfaf5 x82d1f4bb7f8733e0;

	private x845d6a068e0b03c5 x5b8ab301c1b1b5d8;

	private Fill x16b206bbb774bf52;

	private readonly SizeF xe9442bab8a59583a = SizeF.Empty;

	private readonly SizeF x9a0838632eaddb11 = SizeF.Empty;

	private readonly xa99f8d94adfe1070 x2a31f76f2898ca37;

	private x7721ad963b03c6eb x730a3c5f4afd73ef;

	private readonly x54b98d0096d7251a xa056586c1f99e199;

	private Shape x317be79405176667;

	internal xa99f8d94adfe1070 xaeddb4fe9ae94a6a => x2a31f76f2898ca37;

	internal xb8e7e788f6d59708 xa1eafe7821eb4aab
	{
		get
		{
			return x9b1777152cf410e1;
		}
		set
		{
			x9b1777152cf410e1 = value;
		}
	}

	internal x44f2b8bf33b16275[] xdb6e255971c32d6d
	{
		get
		{
			return xbcca09d49a9cc4a3;
		}
		set
		{
			xbcca09d49a9cc4a3 = value;
		}
	}

	internal PointF[] xdbed53246e7dd53a
	{
		get
		{
			return x7e860e67e98d3221;
		}
		set
		{
			x7e860e67e98d3221 = value;
		}
	}

	internal xab391c46ff9a0a38 x6cd7659ca2021746
	{
		get
		{
			if (x792944894802ea12 == null)
			{
				xb4b75316e3519575();
			}
			return x792944894802ea12;
		}
	}

	internal x1cab6af0a41b70e2 x9f2a8e5b70f0bda8
	{
		get
		{
			if (x452b030a6e9cfa9e == null)
			{
				x2fa88e7801380f5a();
			}
			return x452b030a6e9cfa9e;
		}
	}

	internal x31c19fcb724dfaf5 xa0640346645809ad
	{
		get
		{
			if (x82d1f4bb7f8733e0 == null)
			{
				x9105df3ee96fc499();
			}
			return x82d1f4bb7f8733e0;
		}
	}

	internal x845d6a068e0b03c5 x8dc20c37aa4b28ef
	{
		get
		{
			if (x5b8ab301c1b1b5d8 == null)
			{
				xda84a3ed50f59dc6();
			}
			return x5b8ab301c1b1b5d8;
		}
	}

	private Fill x821e31cafe0087c3
	{
		get
		{
			if (x16b206bbb774bf52 == null)
			{
				x16b206bbb774bf52 = new Fill(x317be79405176667);
			}
			return x16b206bbb774bf52;
		}
	}

	internal PointF x1219c4dfd5684616
	{
		get
		{
			return xd67cf4e82e5a9538;
		}
		set
		{
			xd67cf4e82e5a9538 = value;
		}
	}

	internal bool x5cce5b9d6bbc69c4
	{
		get
		{
			return x74713e9129acc4be;
		}
		set
		{
			x74713e9129acc4be = value;
		}
	}

	internal x4fdf549af9de6b97 x273b54138ed7e7a4
	{
		get
		{
			return x4ce86e278aed4879;
		}
		set
		{
			x4ce86e278aed4879 = value;
		}
	}

	internal float x5a6eef65b4348cac
	{
		get
		{
			if (x4d440edd8b06519d == null)
			{
				x4d440edd8b06519d = x317be79405176667.xffa1fc725bf36690;
			}
			return (float)x4d440edd8b06519d;
		}
	}

	internal Shape xa9993ed2e0c64574
	{
		get
		{
			return x317be79405176667;
		}
		set
		{
			x317be79405176667 = value;
		}
	}

	internal RectangleF x22346b9b537191fa
	{
		get
		{
			return xd9aa80aca64aabec;
		}
		set
		{
			xd9aa80aca64aabec = value;
		}
	}

	internal SizeF x1f2f266ad77d3736 => xe9442bab8a59583a;

	internal SizeF xe90b7db0328556d9 => x9a0838632eaddb11;

	internal x54b98d0096d7251a xf69ca7a9bb4a4a51 => xa056586c1f99e199;

	internal xa37343ccb8cd8c70(x7721ad963b03c6eb info, x54366fa5f75a02f7 parentCenterTransform, float parentScaleX, float parentScaleY, float parentAngle, x54b98d0096d7251a warningCallback)
	{
		x730a3c5f4afd73ef = info;
		xa056586c1f99e199 = warningCallback;
		x317be79405176667 = (Shape)info.xa9993ed2e0c64574;
		x2a31f76f2898ca37 = new xa99f8d94adfe1070(x317be79405176667, info.x178374f0600f2696, parentCenterTransform, parentScaleX, parentScaleY, parentAngle);
		if (info.x178374f0600f2696.IsEmpty)
		{
			xe9442bab8a59583a = info.xa9993ed2e0c64574.x437e3b626c0fdd43;
			x9a0838632eaddb11 = info.xa9993ed2e0c64574.SizeInPoints;
		}
		else
		{
			xe9442bab8a59583a = info.x178374f0600f2696;
			x9a0838632eaddb11 = info.x178374f0600f2696;
		}
		x9b1777152cf410e1 = new xb8e7e788f6d59708();
		x04c28a4b961182d2.x4fe2e6db635d321d(this);
	}

	private void xb4b75316e3519575()
	{
		x792944894802ea12 = new xab391c46ff9a0a38();
		x792944894802ea12.x9e5d5f9128c69a8f = xa0640346645809ad;
		x792944894802ea12.x60465f602599d327 = x8dc20c37aa4b28ef;
		x9b1777152cf410e1.xd6b6ed77479ef68c(x792944894802ea12);
	}

	private void x2fa88e7801380f5a()
	{
		x452b030a6e9cfa9e = new x1cab6af0a41b70e2();
		x452b030a6e9cfa9e.x5e6c52cb3256cc85 = false;
		x6cd7659ca2021746.xd6b6ed77479ef68c(x452b030a6e9cfa9e);
	}

	private void x9105df3ee96fc499()
	{
		Stroke stroke = x317be79405176667.Stroke;
		if (!stroke.On)
		{
			x82d1f4bb7f8733e0 = null;
			return;
		}
		switch (stroke.x6d4b101fe08bc376)
		{
		case x6d4b101fe08bc376.xd265a220a45d3124:
		{
			x845d6a068e0b03c5 brush3 = x72b16d0062c5ac6b.x72e575a6c02e65f9(stroke.ImageBytes, null, stroke.x63b1a7c31a962459, stroke.x5424d51d40e7c452);
			x82d1f4bb7f8733e0 = new x31c19fcb724dfaf5(brush3);
			break;
		}
		case x6d4b101fe08bc376.x7b6a6d281546db99:
		case x6d4b101fe08bc376.x7f4d496937f8c24c:
		{
			x5e9754e56a4f759f brush2 = new x5e9754e56a4f759f(stroke.ImageBytes);
			x82d1f4bb7f8733e0 = new x31c19fcb724dfaf5(brush2);
			break;
		}
		default:
		{
			x845d6a068e0b03c5 brush = x72b16d0062c5ac6b.xf450254daa20a6cc(stroke.x63b1a7c31a962459, stroke.Opacity);
			x82d1f4bb7f8733e0 = new x31c19fcb724dfaf5(brush);
			break;
		}
		}
		x82d1f4bb7f8733e0.x03a8df074279275f = x7ad8b429df4d1783.x643f6e244067ba21(stroke.JoinStyle);
		x82d1f4bb7f8733e0.xdc1bf80853046136 = x5a6eef65b4348cac;
		xda5c4285196fdf5e(stroke);
		x0181a89a5cd2d5e9(stroke);
		LineCap lineCap = x7ad8b429df4d1783.x0e0c641273c637f8(stroke.EndCap);
		x82d1f4bb7f8733e0.x9526ba50e2183e01 = x7ad8b429df4d1783.xea700875cdbbe3e1(stroke.EndCap);
		x82d1f4bb7f8733e0.x1e0dcb2cdd562cb2 = lineCap;
		x82d1f4bb7f8733e0.xec7c14446b693774 = lineCap;
	}

	private void xda5c4285196fdf5e(Stroke xb1ed72b81a89125c)
	{
		switch (xb1ed72b81a89125c.LineStyle)
		{
		case ShapeLineStyle.Double:
			x82d1f4bb7f8733e0.x6fd1e71abf8b8121 = new float[4]
			{
				0f,
				1f / 3f,
				2f / 3f,
				1f
			};
			break;
		case ShapeLineStyle.Single:
			x82d1f4bb7f8733e0.x6fd1e71abf8b8121 = new float[2] { 0f, 1f };
			break;
		case ShapeLineStyle.ThickThin:
			x82d1f4bb7f8733e0.x6fd1e71abf8b8121 = new float[4] { 0f, 0.6f, 0.8f, 1f };
			break;
		case ShapeLineStyle.ThinThick:
			x82d1f4bb7f8733e0.x6fd1e71abf8b8121 = new float[4] { 0f, 0.2f, 0.4f, 1f };
			break;
		case ShapeLineStyle.Triple:
			x82d1f4bb7f8733e0.x6fd1e71abf8b8121 = new float[6]
			{
				0f,
				1f / 6f,
				1f / 3f,
				2f / 3f,
				5f / 6f,
				1f
			};
			break;
		}
	}

	private void x0181a89a5cd2d5e9(Stroke xb1ed72b81a89125c)
	{
		switch (xb1ed72b81a89125c.DashStyle)
		{
		case Aspose.Words.Drawing.DashStyle.Dash:
			x82d1f4bb7f8733e0.x358988d12e56bf69 = new float[2] { 4f, 3f };
			break;
		case Aspose.Words.Drawing.DashStyle.DashDot:
			x82d1f4bb7f8733e0.x358988d12e56bf69 = new float[4] { 4f, 3f, 1f, 3f };
			break;
		case Aspose.Words.Drawing.DashStyle.LongDash:
			x82d1f4bb7f8733e0.x358988d12e56bf69 = new float[2] { 8f, 3f };
			break;
		case Aspose.Words.Drawing.DashStyle.LongDashDot:
			x82d1f4bb7f8733e0.x358988d12e56bf69 = new float[4] { 8f, 3f, 1f, 3f };
			break;
		case Aspose.Words.Drawing.DashStyle.LongDashDotDot:
			x82d1f4bb7f8733e0.x358988d12e56bf69 = new float[6] { 8f, 3f, 1f, 3f, 1f, 3f };
			break;
		case Aspose.Words.Drawing.DashStyle.ShortDash:
			x82d1f4bb7f8733e0.xca08e8eb525b8a1a = System.Drawing.Drawing2D.DashStyle.Dash;
			break;
		case Aspose.Words.Drawing.DashStyle.ShortDashDot:
			x82d1f4bb7f8733e0.xca08e8eb525b8a1a = System.Drawing.Drawing2D.DashStyle.DashDot;
			break;
		case Aspose.Words.Drawing.DashStyle.ShortDashDotDot:
			x82d1f4bb7f8733e0.xca08e8eb525b8a1a = System.Drawing.Drawing2D.DashStyle.DashDotDot;
			break;
		case Aspose.Words.Drawing.DashStyle.ShortDot:
			x82d1f4bb7f8733e0.xca08e8eb525b8a1a = System.Drawing.Drawing2D.DashStyle.Dot;
			break;
		case Aspose.Words.Drawing.DashStyle.Solid:
			x82d1f4bb7f8733e0.xca08e8eb525b8a1a = System.Drawing.Drawing2D.DashStyle.Solid;
			break;
		case Aspose.Words.Drawing.DashStyle.Dot:
			break;
		}
	}

	private void xda84a3ed50f59dc6()
	{
		Fill fill = x821e31cafe0087c3;
		if (!fill.On)
		{
			x5b8ab301c1b1b5d8 = null;
			return;
		}
		float x5fa921135f3d5de = (x317be79405176667.x22d2b300aac1d857 ? ((float)x317be79405176667.Rotation) : 0f);
		switch (fill.xeba92971120d3e5a)
		{
		case xeba92971120d3e5a.xd265a220a45d3124:
			x5b8ab301c1b1b5d8 = x72b16d0062c5ac6b.x72e575a6c02e65f9(fill.ImageBytes, x730a3c5f4afd73ef.xb4ea914a0dc4328c, fill.x63b1a7c31a962459, fill.x5424d51d40e7c452);
			break;
		case xeba92971120d3e5a.x7b6a6d281546db99:
			x5b8ab301c1b1b5d8 = x72b16d0062c5ac6b.xa903f8f328b4c169(fill, x730a3c5f4afd73ef.xb4ea914a0dc4328c, x5fa921135f3d5de);
			break;
		case xeba92971120d3e5a.x7f4d496937f8c24c:
			x5b8ab301c1b1b5d8 = x72b16d0062c5ac6b.xec4f084465a18f01(fill, x730a3c5f4afd73ef.xb4ea914a0dc4328c, x2a31f76f2898ca37);
			break;
		case xeba92971120d3e5a.xaf29dc5ca8be8da4:
			x5b8ab301c1b1b5d8 = (xa9993ed2e0c64574.IsWordArt ? x72b16d0062c5ac6b.x755ff959ec7c69dd(x317be79405176667, x9a0838632eaddb11) : x72b16d0062c5ac6b.x7f3743a5bb962d40(x792944894802ea12, fill, new PointF(x9a0838632eaddb11.Width * 0.5f, x9a0838632eaddb11.Height * 0.5f)));
			break;
		case xeba92971120d3e5a.xca1af54f5cfd812d:
			x5b8ab301c1b1b5d8 = x72b16d0062c5ac6b.x755ff959ec7c69dd(x317be79405176667, x9a0838632eaddb11);
			break;
		case xeba92971120d3e5a.xd4d9335470be4176:
		case xeba92971120d3e5a.x8ee64abc2e3e8f45:
		case xeba92971120d3e5a.x408710144185f184:
			x5b8ab301c1b1b5d8 = x72b16d0062c5ac6b.xb9d757f2231cc2a8(x317be79405176667, x9a0838632eaddb11);
			break;
		default:
			x5b8ab301c1b1b5d8 = x72b16d0062c5ac6b.xf450254daa20a6cc(fill.x63b1a7c31a962459, fill.Opacity);
			break;
		}
	}

	internal void x7c3d8cb25cd19d2f()
	{
		x792944894802ea12 = null;
		x82d1f4bb7f8733e0 = null;
		x4d440edd8b06519d = null;
		xc71837477ad7a361();
	}

	internal void xc71837477ad7a361()
	{
		x452b030a6e9cfa9e = null;
		xd67cf4e82e5a9538 = PointF.Empty;
		x74713e9129acc4be = false;
		x4ce86e278aed4879 = null;
	}
}
