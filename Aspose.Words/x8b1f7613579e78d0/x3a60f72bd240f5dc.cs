using System.Drawing;
using System.Drawing.Drawing2D;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace x8b1f7613579e78d0;

internal class x3a60f72bd240f5dc : xc9689b5f2fdc3c03
{
	private x60eea316590e7fe7 x8611c85cf142e7cb;

	public x60eea316590e7fe7 x7cfc143904bcbd0a
	{
		get
		{
			if (x8611c85cf142e7cb == null)
			{
				x8611c85cf142e7cb = new x60eea316590e7fe7();
			}
			return x8611c85cf142e7cb;
		}
		set
		{
			x8611c85cf142e7cb = value;
		}
	}

	public xc9689b5f2fdc3c03 x8b61531c8ea35b85()
	{
		x3a60f72bd240f5dc x3a60f72bd240f5dc2 = new x3a60f72bd240f5dc();
		x3a60f72bd240f5dc2.x7cfc143904bcbd0a = x7cfc143904bcbd0a.x8b61531c8ea35b85();
		return x3a60f72bd240f5dc2;
	}

	public void x99abbb429861fb9d(x5e9754e56a4f759f xd8f1949f8950238a, x8b545195dd56c1c7 xf1125c563ec28c45, xa2745adfabe0c674 x95dac044246123ac)
	{
		xd8f1949f8950238a.x349ff0df1e641b4e = WrapMode.Clamp;
		RectangleF x26545669838eb36e = x4574ea26106f0edb.xa23e6b6c3169521d(xf1125c563ec28c45.x6a1f9e96254c40aa);
		RectangleF x3ed4f4f0195b98d = x7cfc143904bcbd0a.xfaab97dd0218026f(x26545669838eb36e);
		x54366fa5f75a02f7 x470ecea91abfd1aa = x54366fa5f75a02f7.x6698fc0971e66ffb(xd8f1949f8950238a.x42eb8f4390d1e7ba, x3ed4f4f0195b98d);
		xd8f1949f8950238a.xaccac17571a8d9fa.x490e30087768649f(x470ecea91abfd1aa, MatrixOrder.Append);
	}
}
