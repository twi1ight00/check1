using System;
using System.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Drawing;

public class Fill
{
	private readonly x7b71245a33212e76 xc454c03c23d4b4d9;

	internal xeba92971120d3e5a xeba92971120d3e5a
	{
		get
		{
			return (xeba92971120d3e5a)xfe91eeeafcb3026a(384);
		}
		set
		{
			xae20093bed1e48a8(384, value);
		}
	}

	internal bool xc9cb2de01432549c
	{
		get
		{
			return (xd56eb9f05f589be5)xfe91eeeafcb3026a(405) != xd56eb9f05f589be5.xb9715d2f06b63cf0;
		}
		set
		{
			xae20093bed1e48a8(405, value ? xd56eb9f05f589be5.x88214142ac77dd11 : xd56eb9f05f589be5.xb9715d2f06b63cf0);
		}
	}

	public Color Color
	{
		get
		{
			return x63b1a7c31a962459.xc7656a130b2889c7();
		}
		set
		{
			x63b1a7c31a962459 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d x63b1a7c31a962459
	{
		get
		{
			return (x26d9ecb4bdf0456d)xfe91eeeafcb3026a(385);
		}
		set
		{
			xae20093bed1e48a8(385, value);
		}
	}

	internal Color x94bdef4042073f5c
	{
		get
		{
			return x5424d51d40e7c452.xc7656a130b2889c7();
		}
		set
		{
			x5424d51d40e7c452 = x26d9ecb4bdf0456d.xcd907c08c553c15c(value);
		}
	}

	internal x26d9ecb4bdf0456d x5424d51d40e7c452
	{
		get
		{
			return (x26d9ecb4bdf0456d)xfe91eeeafcb3026a(387);
		}
		set
		{
			xae20093bed1e48a8(387, value);
		}
	}

	public double Opacity
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(386));
		}
		set
		{
			xa8859089a187aeeb(value, 386);
		}
	}

	internal double xf317e5a4f28798af
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(388));
		}
		set
		{
			xa8859089a187aeeb(value, 388);
		}
	}

	internal int xe2631b5200d4f95c
	{
		get
		{
			return (int)xfe91eeeafcb3026a(396);
		}
		set
		{
			if (value < -100 || value > 100)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(396, value);
		}
	}

	internal double xd870ef2502e0b7c6
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(397));
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(397, x4574ea26106f0edb.x091b250f00534aae(value));
		}
	}

	internal double xe37a18eec85366de
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(398));
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xae20093bed1e48a8(398, x4574ea26106f0edb.x091b250f00534aae(value));
		}
	}

	internal x9fb6ff04f20b10d0[] x7efed8bb5b845184 => (x9fb6ff04f20b10d0[])xfe91eeeafcb3026a(407);

	internal double x6b1fe03343d9a6a4
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(395));
		}
		set
		{
			xae20093bed1e48a8(395, x4574ea26106f0edb.x091b250f00534aae(value));
		}
	}

	public bool On
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(443);
		}
		set
		{
			xae20093bed1e48a8(443, value);
		}
	}

	public byte[] ImageBytes => (byte[])xfe91eeeafcb3026a(4111);

	internal Fill(x7b71245a33212e76 parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	internal void x7debc73bf6a9d65e(byte[] x43e181e083db6cdf)
	{
		xae20093bed1e48a8(4111, x43e181e083db6cdf);
		xeba92971120d3e5a = xeba92971120d3e5a.x7f4d496937f8c24c;
	}

	private void xa8859089a187aeeb(double xbcea506a33cf9111, int xba08ce632055a1d9)
	{
		if (xbcea506a33cf9111 < 0.0 || xbcea506a33cf9111 > 1.0)
		{
			throw new ArgumentOutOfRangeException("value");
		}
		xae20093bed1e48a8(xba08ce632055a1d9, x4574ea26106f0edb.x091b250f00534aae(xbcea506a33cf9111));
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xfc928672852cc4c4(xba08ce632055a1d9);
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
