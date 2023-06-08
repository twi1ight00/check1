using System;
using System.IO;
using System.Text;
using x6c95d9cf46ff5f25;
using xb92b7270f78a4e8d;
using xf9a9481c3f63a419;
using xfc5388ad7dff404f;

namespace xf989f31a236ff98c;

internal class x755940550ade8e52
{
	private const int xf1c7de13eab3aad1 = -1;

	private const int x3cc35559492e8da9 = 0;

	private const int x5cc6b71cf7856907 = 0;

	private const int x10069378b37de7e2 = 512;

	private static readonly byte[][] x7b94eaf262a53074 = new byte[7][]
	{
		xcd4bd3abd72ff2da.x2b0797e1bb4e840a,
		xe4b3641e8e4ef359.x4d66a37403aa6aa9,
		xe4b3641e8e4ef359.xd6b0a16910d96fdc,
		xe4b3641e8e4ef359.xa9d173629f3cd738,
		xe4b3641e8e4ef359.xb6a99e1e3ae82e06,
		xe4b3641e8e4ef359.xfe0d791ab77e8b8b,
		xe4b3641e8e4ef359.x2c4ac4f2ba6c3c58
	};

	private static readonly Encoding[] x6cd22b3954adac55 = new Encoding[7]
	{
		Encoding.GetEncoding(1252),
		Encoding.BigEndianUnicode,
		Encoding.Unicode,
		Encoding.GetEncoding(12001),
		Encoding.UTF32,
		Encoding.UTF7,
		Encoding.UTF8
	};

	private static readonly int[] xe18c549698298c2f = new int[6] { 0, 2, 5, 1, 4, 3 };

	private static readonly int xefb6a74c79f47f72 = x6cd22b3954adac55.Length - 1;

	private static readonly int x453f87a58a00d293 = xefb6a74c79f47f72 - 1;

	private readonly Stream xa49cef274042e702;

	private readonly long x660c33b694d748ba;

	private int x13e4fbc44be0d8c5;

	private byte[] x67c7273932efc6a2 = xcd4bd3abd72ff2da.x2b0797e1bb4e840a;

	private int x7e68a92dcd264988;

	private string xb0bf34075d465fd9;

	private int x39c8d5975890da55;

	private int xd23aa3fdfb30c2cb;

	private int x2c8133a02e411b72;

	private int x80a07e9c538f9a20 = -1;

	private int xc22011a10888d23a;

	private bool x61f0a6042cb990a1 = true;

	internal bool x5959bccb67bbf051
	{
		get
		{
			if (xc22011a10888d23a <= 0)
			{
				return false;
			}
			if (x39c8d5975890da55 < xb0bf34075d465fd9.Length)
			{
				return true;
			}
			if (!xb0c267d2db185074 && x3b9e775b237d15b8())
			{
				xb0bf34075d465fd9 = x9ee491ab5579b9fc.GetString(x67c7273932efc6a2, xd23aa3fdfb30c2cb, x7e68a92dcd264988 - xd23aa3fdfb30c2cb);
			}
			return x39c8d5975890da55 < xb0bf34075d465fd9.Length;
		}
	}

	internal bool xb0c267d2db185074 => x7e68a92dcd264988 != x67c7273932efc6a2.Length;

	internal Encoding x9ee491ab5579b9fc => x6cd22b3954adac55[x6955df2cb6b23ebf];

	private int x6955df2cb6b23ebf
	{
		get
		{
			if (x80a07e9c538f9a20 != -1)
			{
				return xe18c549698298c2f[x80a07e9c538f9a20];
			}
			return x2c8133a02e411b72;
		}
	}

	internal x755940550ade8e52(Stream stream)
	{
		x2bb95aedd2d8729f();
		xa49cef274042e702 = stream;
		x660c33b694d748ba = stream.Position;
		x3b9e775b237d15b8();
		xd43c5c7cc0edc48f();
	}

	internal void x0cb17c9decdb2ea1()
	{
		xa49cef274042e702.Position = x660c33b694d748ba + x13e4fbc44be0d8c5;
	}

	internal bool xbd833075798c6c66(string xff70cf3aee6f6e46)
	{
		if (x7e68a92dcd264988 < xff70cf3aee6f6e46.Length)
		{
			return false;
		}
		for (int i = 0; i < xff70cf3aee6f6e46.Length; i++)
		{
			if (x67c7273932efc6a2[i] != xff70cf3aee6f6e46[i])
			{
				return false;
			}
		}
		return true;
	}

	internal x252c4abfc5a8ee00 x41ceed55f7eb173f()
	{
		x3775fcb826de9dd6();
		return new x252c4abfc5a8ee00(xa49cef274042e702);
	}

	internal xd8c3135513b9115b x94bca3d4a5b94f61()
	{
		x3775fcb826de9dd6();
		if (!xd8c3135513b9115b.x995d1a25f2eac7ea(x67c7273932efc6a2, x7e68a92dcd264988))
		{
			return null;
		}
		return new xd8c3135513b9115b(xa49cef274042e702);
	}

	internal xc5d5cabda4535c40 x59a8246b79e928e3()
	{
		x3775fcb826de9dd6();
		if (!xbd833075798c6c66("PK"))
		{
			return null;
		}
		return new xc5d5cabda4535c40(xa49cef274042e702);
	}

	internal void x399093d970c2cf4f()
	{
		x3775fcb826de9dd6();
		x80a07e9c538f9a20 = 0;
		xb0bf34075d465fd9 = x9ee491ab5579b9fc.GetString(x67c7273932efc6a2, xd23aa3fdfb30c2cb, x7e68a92dcd264988 - xd23aa3fdfb30c2cb);
	}

	internal void x880181c35bd690f5()
	{
		x3775fcb826de9dd6();
		x80a07e9c538f9a20 = -1;
		xb0bf34075d465fd9 = x9ee491ab5579b9fc.GetString(x67c7273932efc6a2, xd23aa3fdfb30c2cb, x7e68a92dcd264988 - xd23aa3fdfb30c2cb);
	}

	internal bool xcdbb4957df38d59b()
	{
		x3775fcb826de9dd6();
		x80a07e9c538f9a20++;
		if (x80a07e9c538f9a20 == xe18c549698298c2f.Length)
		{
			return false;
		}
		if (xe18c549698298c2f[x80a07e9c538f9a20] == x2c8133a02e411b72)
		{
			x80a07e9c538f9a20++;
		}
		if (x80a07e9c538f9a20 == xe18c549698298c2f.Length)
		{
			return false;
		}
		xb0bf34075d465fd9 = x9ee491ab5579b9fc.GetString(x67c7273932efc6a2, xd23aa3fdfb30c2cb, x7e68a92dcd264988 - xd23aa3fdfb30c2cb);
		return true;
	}

	internal void x2bb95aedd2d8729f()
	{
		if (x61f0a6042cb990a1)
		{
			xc22011a10888d23a = 512;
		}
	}

	internal bool x263d579af1d0d43f(string xbcea506a33cf9111)
	{
		return xb0bf34075d465fd9.IndexOf(xbcea506a33cf9111, 0, Math.Min(xb0bf34075d465fd9.Length, 512)) != -1;
	}

	internal void x0e5c2b2252b3794a()
	{
		x61f0a6042cb990a1 = false;
	}

	internal char xb079f24d79abc35e()
	{
		if (!x5959bccb67bbf051)
		{
			return '\0';
		}
		xc22011a10888d23a--;
		return xb0bf34075d465fd9[x39c8d5975890da55++];
	}

	internal void x299147f04b6b58b8()
	{
		_ = x39c8d5975890da55;
		xc22011a10888d23a++;
		x39c8d5975890da55--;
	}

	public void x22f29aa43d600533()
	{
		x39c8d5975890da55 = 0;
		x61f0a6042cb990a1 = true;
		x2bb95aedd2d8729f();
	}

	private void x3775fcb826de9dd6()
	{
		xa49cef274042e702.Position = x660c33b694d748ba;
		xb0bf34075d465fd9 = null;
		x39c8d5975890da55 = 0;
		x61f0a6042cb990a1 = true;
		x2bb95aedd2d8729f();
	}

	private bool x3b9e775b237d15b8()
	{
		if (xb0c267d2db185074)
		{
			return false;
		}
		int num = x7e68a92dcd264988;
		x67c7273932efc6a2 = new byte[(x67c7273932efc6a2.Length == 0) ? 512 : (x67c7273932efc6a2.Length * 4)];
		xb1dfac195ab5ed68();
		return x7e68a92dcd264988 > num;
	}

	private void xb1dfac195ab5ed68()
	{
		xa49cef274042e702.Position = x660c33b694d748ba;
		x7e68a92dcd264988 = 0;
		int num;
		while ((num = xa49cef274042e702.Read(x67c7273932efc6a2, x7e68a92dcd264988, x67c7273932efc6a2.Length - x7e68a92dcd264988)) > 0)
		{
			x7e68a92dcd264988 += num;
		}
	}

	private void xd43c5c7cc0edc48f()
	{
		if (x7e68a92dcd264988 < xe4b3641e8e4ef359.xfe0d791ab77e8b8b.Length)
		{
			return;
		}
		for (x2c8133a02e411b72 = x7b94eaf262a53074.Length - 1; x2c8133a02e411b72 >= 0; x2c8133a02e411b72--)
		{
			byte[] array = x7b94eaf262a53074[x2c8133a02e411b72];
			xd23aa3fdfb30c2cb = array.Length;
			int i;
			for (i = 0; i < xd23aa3fdfb30c2cb && array[i] == x67c7273932efc6a2[i]; i++)
			{
			}
			if (i == xd23aa3fdfb30c2cb)
			{
				break;
			}
		}
		x13e4fbc44be0d8c5 = ((x2c8133a02e411b72 == x453f87a58a00d293) ? xd23aa3fdfb30c2cb : 0);
	}
}
