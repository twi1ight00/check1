using System;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using x8b1f7613579e78d0;
using xa6cc8e39f9a280d7;

namespace xa769c310fbec8a5a;

internal class x064e11d707aed84f : xa4e6507e0e2894c8, x36c3925dc7ec8012
{
	private static readonly float[] xbf67a115e5d87b71 = new float[4]
	{
		0f,
		1f / 3f,
		2f / 3f,
		1f
	};

	private static readonly float[] x0d909262ebfd7d5f = new float[2] { 0f, 1f };

	private static readonly float[] x44cfd0fd5f994770 = new float[4] { 0f, 0.6f, 0.8f, 1f };

	private static readonly float[] x5a6171656dbd1e79 = new float[4] { 0f, 0.2f, 0.4f, 1f };

	private static readonly float[] x95e014f520259edb = new float[6]
	{
		0f,
		1f / 6f,
		1f / 3f,
		2f / 3f,
		5f / 6f,
		1f
	};

	private x1d9eff2b003a1a1b x4c31ee44d0e9dcd4;

	private xa127f6c5c99ca9d4 x8d23809d9f475fa7;

	private x48d7478d49393961 xc67007a9d484cbb0;

	private xbc57111897b18f47 x1fea50a732bba01b;

	private xb70e93871f38b24c x3394de1bd75acdd0 = xb70e93871f38b24c.xb036e9f5325eb99f;

	private xcf2fe980acb3bf78 x54c790b8d7c79839;

	private xf589374d0be88b7e x590c935fb79ed979;

	private double xd74c65b8d28b1740;

	public x48d7478d49393961 x6a81a30bcaf20a97
	{
		get
		{
			return xc67007a9d484cbb0;
		}
		set
		{
			xc67007a9d484cbb0 = value;
		}
	}

	public double xdc1bf80853046136
	{
		get
		{
			return xd74c65b8d28b1740;
		}
		set
		{
			xd74c65b8d28b1740 = value;
		}
	}

	public x1d9eff2b003a1a1b x0f91c275a41355f8
	{
		get
		{
			return x4c31ee44d0e9dcd4;
		}
		set
		{
			x4c31ee44d0e9dcd4 = value;
		}
	}

	public xb70e93871f38b24c xc178619d06ec481b
	{
		get
		{
			return x3394de1bd75acdd0;
		}
		set
		{
			x3394de1bd75acdd0 = value;
		}
	}

	public xcf2fe980acb3bf78 x4d627450ee76e1ac
	{
		get
		{
			return x54c790b8d7c79839;
		}
		set
		{
			x54c790b8d7c79839 = value;
		}
	}

	public xa127f6c5c99ca9d4 x35078e8db43b001f
	{
		get
		{
			if (x8d23809d9f475fa7 == null)
			{
				x8d23809d9f475fa7 = new x72234568f2993bba();
			}
			return x8d23809d9f475fa7;
		}
		set
		{
			x8d23809d9f475fa7 = value;
		}
	}

	public xf589374d0be88b7e xa8e5d0ec145121c8
	{
		get
		{
			return x590c935fb79ed979;
		}
		set
		{
			x590c935fb79ed979 = value;
		}
	}

	public xbc57111897b18f47 xc9fdc51bd242ab7e
	{
		get
		{
			return x1fea50a732bba01b;
		}
		set
		{
			x1fea50a732bba01b = value;
		}
	}

	public x31c19fcb724dfaf5 x2f0c16e51db81725(x8b545195dd56c1c7 xf1125c563ec28c45)
	{
		x064e11d707aed84f x33e8d6fd18d7b8cf = (x064e11d707aed84f)xf1125c563ec28c45.xfe2178c1f916f36c.x74a6754675df4bc3(xf1125c563ec28c45);
		x845d6a068e0b03c5 x845d6a068e0b03c = x721d5677deb3e7f5(xf1125c563ec28c45, x33e8d6fd18d7b8cf);
		if (x845d6a068e0b03c.IsEmpty)
		{
			return null;
		}
		double num = xb556d1cd3d419a11(x33e8d6fd18d7b8cf);
		x31c19fcb724dfaf5 x31c19fcb724dfaf = new x31c19fcb724dfaf5(x845d6a068e0b03c, (float)num);
		x73de21233f294939(x31c19fcb724dfaf);
		x36c478324e301448(x31c19fcb724dfaf);
		x0d14dc8d0fdc189d(x31c19fcb724dfaf);
		x35078e8db43b001f.AdjustPen(x31c19fcb724dfaf);
		if (xc9fdc51bd242ab7e != null)
		{
			xc9fdc51bd242ab7e.AdjustPen(x31c19fcb724dfaf);
		}
		if (xa8e5d0ec145121c8 != null)
		{
			xa8e5d0ec145121c8.AdjustPen(x31c19fcb724dfaf);
		}
		return x31c19fcb724dfaf;
	}

	private void x0d14dc8d0fdc189d(x31c19fcb724dfaf5 x90279591611601bc)
	{
		switch (x4d627450ee76e1ac)
		{
		case xcf2fe980acb3bf78.xc1d71aceeda48828:
			x90279591611601bc.x9ba359ff37a3a63b = PenAlignment.Center;
			break;
		case xcf2fe980acb3bf78.x22b9fd76d0291a7d:
			x90279591611601bc.x9ba359ff37a3a63b = PenAlignment.Inset;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private x845d6a068e0b03c5 x721d5677deb3e7f5(x8b545195dd56c1c7 xf1125c563ec28c45, x064e11d707aed84f x33e8d6fd18d7b8cf)
	{
		x48d7478d49393961 x48d7478d = x6a81a30bcaf20a97;
		if (x48d7478d == null && x33e8d6fd18d7b8cf != null)
		{
			x48d7478d = x33e8d6fd18d7b8cf.x6a81a30bcaf20a97;
		}
		if (x48d7478d == null)
		{
			x48d7478d = new xcffce73ccb792506();
		}
		return x48d7478d.CreateBrush(xf1125c563ec28c45);
	}

	private double xb556d1cd3d419a11(x064e11d707aed84f x33e8d6fd18d7b8cf)
	{
		double num = xdc1bf80853046136;
		if (num == 0.0 && x33e8d6fd18d7b8cf != null)
		{
			num = x33e8d6fd18d7b8cf.xdc1bf80853046136;
		}
		return num;
	}

	public x36c3925dc7ec8012 x8b61531c8ea35b85()
	{
		x064e11d707aed84f x064e11d707aed84f2 = new x064e11d707aed84f();
		if (x6a81a30bcaf20a97 != null)
		{
			x064e11d707aed84f2.x6a81a30bcaf20a97 = x6a81a30bcaf20a97.Clone();
		}
		x064e11d707aed84f2.xdc1bf80853046136 = xdc1bf80853046136;
		if (x064e11d707aed84f2.xa8e5d0ec145121c8 != null)
		{
			x064e11d707aed84f2.xa8e5d0ec145121c8 = (xf589374d0be88b7e)xa8e5d0ec145121c8.Clone();
		}
		if (x064e11d707aed84f2.xc9fdc51bd242ab7e != null)
		{
			x064e11d707aed84f2.xc9fdc51bd242ab7e = (xbc57111897b18f47)xc9fdc51bd242ab7e.Clone();
		}
		x064e11d707aed84f2.x4d627450ee76e1ac = x4d627450ee76e1ac;
		x064e11d707aed84f2.xc178619d06ec481b = xc178619d06ec481b;
		x064e11d707aed84f2.x0f91c275a41355f8 = x0f91c275a41355f8;
		x064e11d707aed84f2.x35078e8db43b001f = x35078e8db43b001f.Clone();
		return x064e11d707aed84f2;
	}

	private void x36c478324e301448(x31c19fcb724dfaf5 x90279591611601bc)
	{
		switch (xc178619d06ec481b)
		{
		case xb70e93871f38b24c.xa4399d7641f08688:
			x90279591611601bc.x1e0dcb2cdd562cb2 = LineCap.Square;
			x90279591611601bc.xec7c14446b693774 = LineCap.Square;
			x90279591611601bc.x9526ba50e2183e01 = DashCap.Flat;
			break;
		case xb70e93871f38b24c.xb036e9f5325eb99f:
			x90279591611601bc.x1e0dcb2cdd562cb2 = LineCap.Flat;
			x90279591611601bc.xec7c14446b693774 = LineCap.Flat;
			x90279591611601bc.x9526ba50e2183e01 = DashCap.Flat;
			break;
		case xb70e93871f38b24c.x8168cd75fdee54e0:
			x90279591611601bc.x1e0dcb2cdd562cb2 = LineCap.Round;
			x90279591611601bc.xec7c14446b693774 = LineCap.Round;
			x90279591611601bc.x9526ba50e2183e01 = DashCap.Round;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	private void x73de21233f294939(x31c19fcb724dfaf5 x90279591611601bc)
	{
		switch (x0f91c275a41355f8)
		{
		case x1d9eff2b003a1a1b.x6c91ff700098ae78:
			x90279591611601bc.x6fd1e71abf8b8121 = x0d909262ebfd7d5f;
			break;
		case x1d9eff2b003a1a1b.x318d8e0c95dd806f:
			x90279591611601bc.x6fd1e71abf8b8121 = xbf67a115e5d87b71;
			break;
		case x1d9eff2b003a1a1b.xeed2af758d645623:
			x90279591611601bc.x6fd1e71abf8b8121 = x44cfd0fd5f994770;
			break;
		case x1d9eff2b003a1a1b.xef84abac71c755f7:
			x90279591611601bc.x6fd1e71abf8b8121 = x5a6171656dbd1e79;
			break;
		case x1d9eff2b003a1a1b.x1e50f9248368bd10:
			x90279591611601bc.x6fd1e71abf8b8121 = x95e014f520259edb;
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public void xbd7d8a7a0df4684a(xd7e8497b32a408b8 x8b80cdce7a15befe)
	{
		if (x6a81a30bcaf20a97 != null)
		{
			x6a81a30bcaf20a97.xbd7d8a7a0df4684a(x8b80cdce7a15befe);
		}
	}
}
