using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class x70ab1b2dd0ee9d13 : x0096796e2eb81db6
{
	public x70ab1b2dd0ee9d13(x34b34bf589d8ec1e context)
		: base(context)
	{
	}

	public void xf5fe5bf90a2f2397(x31c19fcb724dfaf5 x90279591611601bc)
	{
		base.x5aa326f374b3d0ef.xc351d479ff7ee789(1);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be((short)x15e971129fd80714.x43fcc3f62534530b(x90279591611601bc.xdc1bf80853046136));
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(x10fdb45fe0eb17db(x90279591611601bc.x1e0dcb2cdd562cb2), 2, xde809bbd71bb692c: false);
		int num = x947c2065b15d3a96(x90279591611601bc.x03a8df074279275f);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(num, 2, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: true, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: false, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: false, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: false, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(0, 5, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.x1485d1261faf8961(x2dd7de7c7b0ddad5: false, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(x10fdb45fe0eb17db(x90279591611601bc.xec7c14446b693774), 2, xde809bbd71bb692c: false);
		if (num == 2)
		{
			base.x5aa326f374b3d0ef.xab5f6b7526efa5be((short)x15e971129fd80714.x43fcc3f62534530b(x90279591611601bc.x3372c2e5fab45e9a));
		}
		xd2b8802a6a96b2c7 xd2b8802a6a96b2c8 = new xd2b8802a6a96b2c7(base.x28fcdc775a1d069c);
		xd2b8802a6a96b2c8.x6210059f049f0d48(x90279591611601bc.x60465f602599d327);
	}

	public void x7b8e1a6b85aa6d44()
	{
		base.x5aa326f374b3d0ef.xc351d479ff7ee789(0);
	}

	private static int x10fdb45fe0eb17db(LineCap x924d47924ddd687d)
	{
		switch (x924d47924ddd687d)
		{
		case LineCap.Round:
		case LineCap.RoundAnchor:
			return 0;
		case LineCap.Square:
		case LineCap.SquareAnchor:
			return 2;
		default:
			return 1;
		}
	}

	private static int x947c2065b15d3a96(LineJoin x116dc3c08b623a0b)
	{
		switch (x116dc3c08b623a0b)
		{
		case LineJoin.Round:
			return 0;
		case LineJoin.Bevel:
			return 1;
		case LineJoin.Miter:
		case LineJoin.MiterClipped:
			return 2;
		default:
			return 1;
		}
	}
}
