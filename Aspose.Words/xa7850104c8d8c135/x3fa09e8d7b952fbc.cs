using System;
using System.Drawing;
using System.IO;
using x0097836593a6a96a;
using x38a89dee67fc7a16;
using x6c95d9cf46ff5f25;
using x74500b509de15565;

namespace xa7850104c8d8c135;

internal class x3fa09e8d7b952fbc
{
	public const float xee73df016561e715 = 96f;

	private readonly Stream xa49cef274042e702;

	private readonly x3ad1f4cb1f0990ad x065f09505b5cc65a;

	private x32d60f0ed8eff6a5 x94770d5ae54872b6;

	private xdbd746c24197fec5 xbc980dfe7cfef988;

	private xfad9e03fe21035af xdbc415e5ffa09754;

	private int x66ae6280fa146a7e;

	private RectangleF x17810d149838b5a2 = RectangleF.Empty;

	public static readonly RectangleF x43187c96760d3ef8 = new RectangleF(0f, 0f, 1280f, 1024f);

	public static SizeF x66183e70f3039753 = new SizeF(1280f, 1024f);

	internal Stream xb8a774e0111d0fbe => xa49cef274042e702;

	internal int xeb1dab4c802b7198 => x66ae6280fa146a7e;

	internal x3ad1f4cb1f0990ad x33bca70acf5ccba8 => x065f09505b5cc65a;

	internal bool x44459133b0e072ae => x065f09505b5cc65a == x3ad1f4cb1f0990ad.x054b6b6a51ff7486;

	internal bool xa6f8ac4b51ef185d => x065f09505b5cc65a == x3ad1f4cb1f0990ad.x6b99da0700ba955b;

	internal bool xc47664a5c3cbfcde => x065f09505b5cc65a == x3ad1f4cb1f0990ad.x93a6fe984442be6b;

	internal bool x2f0ff51ad9f7b574 => x065f09505b5cc65a == x3ad1f4cb1f0990ad.xd82e588b84205868;

	internal bool x1cb6731bbcba6edc
	{
		get
		{
			if (!xc47664a5c3cbfcde)
			{
				return x2f0ff51ad9f7b574;
			}
			return true;
		}
	}

	internal bool xa9de928a73ac4410
	{
		get
		{
			if (!xa6f8ac4b51ef185d)
			{
				return x1cb6731bbcba6edc;
			}
			return true;
		}
	}

	internal float xf2b3620f7bfc9ed5
	{
		get
		{
			switch (x065f09505b5cc65a)
			{
			case x3ad1f4cb1f0990ad.xb5fe04c34562f438:
			case x3ad1f4cb1f0990ad.x054b6b6a51ff7486:
				return x801574a4c7fad18d();
			case x3ad1f4cb1f0990ad.x6b99da0700ba955b:
			case x3ad1f4cb1f0990ad.xd82e588b84205868:
			case x3ad1f4cb1f0990ad.x93a6fe984442be6b:
				return xdbc415e5ffa09754.xf2b3620f7bfc9ed5;
			default:
				throw new InvalidOperationException("Unknown metafile type.");
			}
		}
	}

	internal float x5c6fc5693c6898cd
	{
		get
		{
			switch (x065f09505b5cc65a)
			{
			case x3ad1f4cb1f0990ad.xb5fe04c34562f438:
			case x3ad1f4cb1f0990ad.x054b6b6a51ff7486:
				return x801574a4c7fad18d();
			case x3ad1f4cb1f0990ad.x6b99da0700ba955b:
			case x3ad1f4cb1f0990ad.xd82e588b84205868:
			case x3ad1f4cb1f0990ad.x93a6fe984442be6b:
				return xdbc415e5ffa09754.x5c6fc5693c6898cd;
			default:
				throw new InvalidOperationException("Unknown metafile type.");
			}
		}
	}

	internal float x75b719605e4aef36 => xf2b3620f7bfc9ed5 / 96f;

	internal float xc474586f58d78a36 => x5c6fc5693c6898cd / 96f;

	internal SizeF xd72aaca54f51ce54
	{
		get
		{
			switch (x065f09505b5cc65a)
			{
			case x3ad1f4cb1f0990ad.xb5fe04c34562f438:
			case x3ad1f4cb1f0990ad.x054b6b6a51ff7486:
				return x66183e70f3039753;
			case x3ad1f4cb1f0990ad.x6b99da0700ba955b:
			case x3ad1f4cb1f0990ad.xd82e588b84205868:
			case x3ad1f4cb1f0990ad.x93a6fe984442be6b:
				return xdbc415e5ffa09754.xd72aaca54f51ce54;
			default:
				throw new InvalidOperationException("Unknown metafile type.");
			}
		}
	}

	public RectangleF xee6354c7044d841a
	{
		get
		{
			switch (x065f09505b5cc65a)
			{
			case x3ad1f4cb1f0990ad.xb5fe04c34562f438:
				return xcca90507a8e1adef();
			case x3ad1f4cb1f0990ad.x054b6b6a51ff7486:
				if (xbc980dfe7cfef988.xbc6217e5154e192c)
				{
					return xbc980dfe7cfef988.x6ae4612a8469678e;
				}
				return x43187c96760d3ef8;
			case x3ad1f4cb1f0990ad.x6b99da0700ba955b:
			case x3ad1f4cb1f0990ad.xd82e588b84205868:
			case x3ad1f4cb1f0990ad.x93a6fe984442be6b:
				return new RectangleF(xdbc415e5ffa09754.x535d3b35c3a3e8ea.X, xdbc415e5ffa09754.x535d3b35c3a3e8ea.Y, xdbc415e5ffa09754.x535d3b35c3a3e8ea.Width + 1f, xdbc415e5ffa09754.x535d3b35c3a3e8ea.Height + 1f);
			default:
				throw new InvalidOperationException("Unknown metafile type.");
			}
		}
	}

	public SizeF x2ae4e44a2787f337 => xee6354c7044d841a.Size;

	public SizeF x53531537bb3331e6 => new SizeF((float)x4574ea26106f0edb.xad2dd08366e0faf5(x2ae4e44a2787f337.Width, xf2b3620f7bfc9ed5), (float)x4574ea26106f0edb.xad2dd08366e0faf5(x2ae4e44a2787f337.Height, x5c6fc5693c6898cd));

	internal int x1140b8d044d38bb6
	{
		get
		{
			if (xa9de928a73ac4410)
			{
				return 0;
			}
			return x94770d5ae54872b6.x1140b8d044d38bb6;
		}
	}

	public x3fa09e8d7b952fbc(byte[] imageBytes)
		: this(new MemoryStream(imageBytes))
	{
	}

	public x3fa09e8d7b952fbc(Stream stream)
	{
		xa49cef274042e702 = stream;
		x065f09505b5cc65a = xdd1b8f14cc8ba86d.x7d51d162df026657(stream);
		x8bbd82447e9055e4();
	}

	private void x8bbd82447e9055e4()
	{
		xa49cef274042e702.Position = 0L;
		BinaryReader xe134235b3526fa = new BinaryReader(xa49cef274042e702);
		if (xa9de928a73ac4410)
		{
			xdbc415e5ffa09754 = new xfad9e03fe21035af();
			xdbc415e5ffa09754.x06b0e25aa6ad68a9(xe134235b3526fa);
		}
		else
		{
			if (x44459133b0e072ae)
			{
				xbc980dfe7cfef988 = new xdbd746c24197fec5();
				xbc980dfe7cfef988.x06b0e25aa6ad68a9(xe134235b3526fa);
			}
			x94770d5ae54872b6 = new x32d60f0ed8eff6a5();
			x94770d5ae54872b6.x06b0e25aa6ad68a9(xe134235b3526fa);
		}
		x66ae6280fa146a7e = (int)xa49cef274042e702.Position;
		if (x065f09505b5cc65a == x3ad1f4cb1f0990ad.xb5fe04c34562f438)
		{
			xa1d6f48f51de617c();
		}
	}

	private float x801574a4c7fad18d()
	{
		if (x44459133b0e072ae)
		{
			return xbc980dfe7cfef988.x12a36b56521f3632;
		}
		return 96f;
	}

	private void xa1d6f48f51de617c()
	{
		x055feb40a6f16001 x055feb40a6f = new x055feb40a6f16001(this);
		x17810d149838b5a2 = x055feb40a6f.xa49375d14353c60f();
	}

	private RectangleF xcca90507a8e1adef()
	{
		if (!x17810d149838b5a2.IsEmpty)
		{
			return x17810d149838b5a2;
		}
		return x43187c96760d3ef8;
	}

	public byte[] x4e7f5d5a42ec39f1()
	{
		if (xa9de928a73ac4410)
		{
			return null;
		}
		x2244346d6dd1a19e x2244346d6dd1a19e = new x2244346d6dd1a19e(this);
		return x2244346d6dd1a19e.x2226c0b12a7471f1();
	}
}
