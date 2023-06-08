using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x4adf554d20d941a6;

internal sealed class x8e3db3d2a7fdbd41 : xcf9d359063aa93f2
{
	private int x933fbdb4e4f6c448;

	private int x51556d800a83de54;

	private int xd74c65b8d28b1740;

	private int x8918dc7c534575e5;

	private int x977c118969ea68d5;

	private int xd4aad021218656e0;

	private int xfe5f89e803a8e243;

	private int x3ddfa14ec67be674;

	private RelativeVerticalPosition x5ba3b942bcbf9183;

	private VerticalAlignment x23fba42a1a90df45;

	private RelativeHorizontalPosition x9e2da29927d085b7;

	private HorizontalAlignment x84a671aa2782b9c8;

	private WrapType x6399ee126b4fd5aa;

	private TextOrientation x6dcb7e40b9f187cd;

	private bool x2386c550a82fa9c1;

	private WrapSide xc2e78072879ec621;

	internal int x72d92bd1aff02e37
	{
		get
		{
			return x933fbdb4e4f6c448;
		}
		set
		{
			x71c6d753219cc1b7();
			x933fbdb4e4f6c448 = value;
		}
	}

	internal int xe360b1885d8d4a41
	{
		get
		{
			return x51556d800a83de54;
		}
		set
		{
			x71c6d753219cc1b7();
			x51556d800a83de54 = value;
		}
	}

	internal int xdc1bf80853046136
	{
		get
		{
			return xd74c65b8d28b1740;
		}
		set
		{
			x71c6d753219cc1b7();
			xd74c65b8d28b1740 = value;
		}
	}

	internal int xb0f146032f47c24e
	{
		get
		{
			return x8918dc7c534575e5;
		}
		set
		{
			x71c6d753219cc1b7();
			x8918dc7c534575e5 = value;
		}
	}

	internal int xc9ee264fd8d7484e
	{
		get
		{
			return x977c118969ea68d5;
		}
		set
		{
			x71c6d753219cc1b7();
			x977c118969ea68d5 = value;
		}
	}

	internal int x027754ea63804113
	{
		get
		{
			return xd4aad021218656e0;
		}
		set
		{
			x71c6d753219cc1b7();
			xd4aad021218656e0 = value;
		}
	}

	internal int xb5465b18223f6375
	{
		get
		{
			return xfe5f89e803a8e243;
		}
		set
		{
			x71c6d753219cc1b7();
			xfe5f89e803a8e243 = value;
		}
	}

	internal int x4dc0360afcf78834
	{
		get
		{
			return x3ddfa14ec67be674;
		}
		set
		{
			x71c6d753219cc1b7();
			x3ddfa14ec67be674 = value;
		}
	}

	internal WrapSide x400dff62c6cef57f
	{
		get
		{
			return xc2e78072879ec621;
		}
		set
		{
			x71c6d753219cc1b7();
			xc2e78072879ec621 = value;
		}
	}

	internal WrapType xab6edfb47ff0b74c
	{
		get
		{
			return x6399ee126b4fd5aa;
		}
		set
		{
			x71c6d753219cc1b7();
			x6399ee126b4fd5aa = value;
		}
	}

	internal HorizontalAlignment xab67cb9464a3325b
	{
		get
		{
			return x84a671aa2782b9c8;
		}
		set
		{
			x71c6d753219cc1b7();
			x84a671aa2782b9c8 = value;
		}
	}

	internal RelativeHorizontalPosition x0fcdf9c7f9f2eb9e
	{
		get
		{
			return x9e2da29927d085b7;
		}
		set
		{
			x71c6d753219cc1b7();
			x9e2da29927d085b7 = value;
		}
	}

	internal VerticalAlignment xf6ce0e8106e6a1d8
	{
		get
		{
			return x23fba42a1a90df45;
		}
		set
		{
			x71c6d753219cc1b7();
			x23fba42a1a90df45 = value;
		}
	}

	internal RelativeVerticalPosition x5d0ebb82ae68cc43
	{
		get
		{
			return x5ba3b942bcbf9183;
		}
		set
		{
			x71c6d753219cc1b7();
			x5ba3b942bcbf9183 = value;
		}
	}

	internal TextOrientation x2c5926113e101674
	{
		get
		{
			return x6dcb7e40b9f187cd;
		}
		set
		{
			x71c6d753219cc1b7();
			x6dcb7e40b9f187cd = value;
		}
	}

	internal bool xed344a170caf7ac3
	{
		get
		{
			return x2386c550a82fa9c1;
		}
		set
		{
			x71c6d753219cc1b7();
			x2386c550a82fa9c1 = value;
		}
	}

	internal bool x6f6877b222ed4153 => xab6edfb47ff0b74c != WrapType.Inline;

	internal bool x5885cb220c00df36
	{
		get
		{
			switch (xab6edfb47ff0b74c)
			{
			case WrapType.TopBottom:
			case WrapType.Square:
			case WrapType.Tight:
			case WrapType.Through:
				return true;
			default:
				return false;
			}
		}
	}

	internal bool x01bc5527a261f633
	{
		get
		{
			switch (x2c5926113e101674)
			{
			case TextOrientation.Downward:
			case TextOrientation.Upward:
			case TextOrientation.VerticalFarEast:
				return true;
			default:
				return false;
			}
		}
	}

	internal x8e3db3d2a7fdbd41(x17dcbf5fe3c0d2d2 context, bool initKey)
		: base(context)
	{
		if (initKey)
		{
			GetHashCode();
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!x39f156868f37b760(obj))
		{
			return false;
		}
		x8e3db3d2a7fdbd41 x8e3db3d2a7fdbd42 = (x8e3db3d2a7fdbd41)obj;
		return x72d92bd1aff02e37.Equals(x8e3db3d2a7fdbd42.x72d92bd1aff02e37) && xe360b1885d8d4a41.Equals(x8e3db3d2a7fdbd42.xe360b1885d8d4a41) && xdc1bf80853046136.Equals(x8e3db3d2a7fdbd42.xdc1bf80853046136) && xb0f146032f47c24e.Equals(x8e3db3d2a7fdbd42.xb0f146032f47c24e) && xc9ee264fd8d7484e.Equals(x8e3db3d2a7fdbd42.xc9ee264fd8d7484e) && x027754ea63804113.Equals(x8e3db3d2a7fdbd42.x027754ea63804113) && xb5465b18223f6375.Equals(x8e3db3d2a7fdbd42.xb5465b18223f6375) && x4dc0360afcf78834.Equals(x8e3db3d2a7fdbd42.x4dc0360afcf78834) && xab67cb9464a3325b == x8e3db3d2a7fdbd42.xab67cb9464a3325b && x0fcdf9c7f9f2eb9e == x8e3db3d2a7fdbd42.x0fcdf9c7f9f2eb9e && xf6ce0e8106e6a1d8 == x8e3db3d2a7fdbd42.xf6ce0e8106e6a1d8 && x5d0ebb82ae68cc43 == x8e3db3d2a7fdbd42.x5d0ebb82ae68cc43 && xab6edfb47ff0b74c == x8e3db3d2a7fdbd42.xab6edfb47ff0b74c && x2c5926113e101674 == x8e3db3d2a7fdbd42.x2c5926113e101674 && xed344a170caf7ac3 == x8e3db3d2a7fdbd42.xed344a170caf7ac3 && x400dff62c6cef57f == x8e3db3d2a7fdbd42.x400dff62c6cef57f;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected override void AddKeysToHashCode()
	{
		x1e94bce19c84490b(x72d92bd1aff02e37);
		x1e94bce19c84490b(xe360b1885d8d4a41);
		x1e94bce19c84490b(xdc1bf80853046136);
		x1e94bce19c84490b(xb0f146032f47c24e);
		x1e94bce19c84490b(xc9ee264fd8d7484e);
		x1e94bce19c84490b(x027754ea63804113);
		x1e94bce19c84490b(xb5465b18223f6375);
		x1e94bce19c84490b(x4dc0360afcf78834);
		x1e94bce19c84490b(xab67cb9464a3325b);
		x1e94bce19c84490b(x0fcdf9c7f9f2eb9e);
		x1e94bce19c84490b(xf6ce0e8106e6a1d8);
		x1e94bce19c84490b(x5d0ebb82ae68cc43);
		x1e94bce19c84490b(xab6edfb47ff0b74c);
		x1e94bce19c84490b(x2c5926113e101674);
		x1e94bce19c84490b(xed344a170caf7ac3);
		x1e94bce19c84490b(x400dff62c6cef57f);
	}

	internal static x8e3db3d2a7fdbd41 xdb83cd4968ca9d31(x8e3db3d2a7fdbd41 xdcf7b74ddd6caa25)
	{
		if (xdcf7b74ddd6caa25 == null)
		{
			return new x8e3db3d2a7fdbd41(null, initKey: true);
		}
		x8e3db3d2a7fdbd41 x8e3db3d2a7fdbd42 = new x8e3db3d2a7fdbd41(xdcf7b74ddd6caa25.x17dcbf5fe3c0d2d2, initKey: false);
		x8e3db3d2a7fdbd42.x72d92bd1aff02e37 = xdcf7b74ddd6caa25.x72d92bd1aff02e37;
		x8e3db3d2a7fdbd42.xe360b1885d8d4a41 = xdcf7b74ddd6caa25.xe360b1885d8d4a41;
		x8e3db3d2a7fdbd42.xdc1bf80853046136 = xdcf7b74ddd6caa25.xdc1bf80853046136;
		x8e3db3d2a7fdbd42.xb0f146032f47c24e = xdcf7b74ddd6caa25.xb0f146032f47c24e;
		x8e3db3d2a7fdbd42.xc9ee264fd8d7484e = xdcf7b74ddd6caa25.xc9ee264fd8d7484e;
		x8e3db3d2a7fdbd42.x027754ea63804113 = xdcf7b74ddd6caa25.x027754ea63804113;
		x8e3db3d2a7fdbd42.xb5465b18223f6375 = xdcf7b74ddd6caa25.xb5465b18223f6375;
		x8e3db3d2a7fdbd42.x4dc0360afcf78834 = xdcf7b74ddd6caa25.x4dc0360afcf78834;
		x8e3db3d2a7fdbd42.xab67cb9464a3325b = xdcf7b74ddd6caa25.xab67cb9464a3325b;
		x8e3db3d2a7fdbd42.x0fcdf9c7f9f2eb9e = xdcf7b74ddd6caa25.x0fcdf9c7f9f2eb9e;
		x8e3db3d2a7fdbd42.xf6ce0e8106e6a1d8 = xdcf7b74ddd6caa25.xf6ce0e8106e6a1d8;
		x8e3db3d2a7fdbd42.x5d0ebb82ae68cc43 = xdcf7b74ddd6caa25.x5d0ebb82ae68cc43;
		x8e3db3d2a7fdbd42.xab6edfb47ff0b74c = xdcf7b74ddd6caa25.xab6edfb47ff0b74c;
		x8e3db3d2a7fdbd42.x2c5926113e101674 = xdcf7b74ddd6caa25.x2c5926113e101674;
		x8e3db3d2a7fdbd42.xed344a170caf7ac3 = xdcf7b74ddd6caa25.xed344a170caf7ac3;
		x8e3db3d2a7fdbd42.x400dff62c6cef57f = xdcf7b74ddd6caa25.x400dff62c6cef57f;
		return x8e3db3d2a7fdbd42;
	}

	internal static x8e3db3d2a7fdbd41 x38758cbbee49e4cb(x8e3db3d2a7fdbd41 x50a18ad2656e7181)
	{
		if (x50a18ad2656e7181 == null)
		{
			x50a18ad2656e7181 = new x8e3db3d2a7fdbd41(null, initKey: true);
		}
		if (x50a18ad2656e7181.x17dcbf5fe3c0d2d2 == null)
		{
			return x50a18ad2656e7181;
		}
		if (x50a18ad2656e7181.xe76bdd563aa52beb)
		{
			return x50a18ad2656e7181;
		}
		if (x50a18ad2656e7181.Equals(x41ccdd7753312e4f.x017043e01a3905d0))
		{
			return x41ccdd7753312e4f.x017043e01a3905d0;
		}
		if (x50a18ad2656e7181.Equals(x8f0e2f0364ae18aa.x017043e01a3905d0))
		{
			return x8f0e2f0364ae18aa.x017043e01a3905d0;
		}
		if (x50a18ad2656e7181.Equals(xdeab92faa2eb558b.x017043e01a3905d0))
		{
			return xdeab92faa2eb558b.x017043e01a3905d0;
		}
		x8e3db3d2a7fdbd41 x8e3db3d2a7fdbd42 = (x8e3db3d2a7fdbd41)x50a18ad2656e7181.x17dcbf5fe3c0d2d2.x0835032f8b0cc5b7[x50a18ad2656e7181];
		if (x8e3db3d2a7fdbd42 == null)
		{
			x50a18ad2656e7181.x17dcbf5fe3c0d2d2.x0835032f8b0cc5b7.Add(x50a18ad2656e7181, x8e3db3d2a7fdbd42 = x50a18ad2656e7181);
		}
		return x8e3db3d2a7fdbd42;
	}

	internal static int x6be2ce937644ef37(int x4d5aabc7a55b12ba, HeightRule xe529c1588eada8b4)
	{
		if (xe529c1588eada8b4 == HeightRule.Auto)
		{
			return 0;
		}
		x4d5aabc7a55b12ba = Math.Max(0, x4d5aabc7a55b12ba);
		if (xe529c1588eada8b4 == HeightRule.AtLeast)
		{
			x4d5aabc7a55b12ba = -x4d5aabc7a55b12ba;
		}
		return x4574ea26106f0edb.x370502bb60141209(x4d5aabc7a55b12ba);
	}

	internal static x8e3db3d2a7fdbd41 xb6976ad77474f1fe(object xf0f5907c77eeefed)
	{
		if (xf0f5907c77eeefed is x7c1e2b821e8b8220)
		{
			return ((x7c1e2b821e8b8220)xf0f5907c77eeefed).xeb54885ba753f70e.x109e3389933c23a8;
		}
		if (xf0f5907c77eeefed is x8d9303345f12a846)
		{
			return ((x8d9303345f12a846)xf0f5907c77eeefed).xa79651e2f1a1416e.x109e3389933c23a8;
		}
		if (xf0f5907c77eeefed is xa67197c42bddc7dc)
		{
			return ((xa67197c42bddc7dc)xf0f5907c77eeefed).x34251722ab416841.x109e3389933c23a8;
		}
		if (xf0f5907c77eeefed is xf6937c72cebe4ad1)
		{
			return ((xf6937c72cebe4ad1)xf0f5907c77eeefed).x406d8cd2af514771.xa79651e2f1a1416e.x109e3389933c23a8;
		}
		if (xf0f5907c77eeefed is x694f001896973fe3)
		{
			return ((x694f001896973fe3)xf0f5907c77eeefed).x838c6c67b5953bb0.x133f2db9e5b5690d.xeb54885ba753f70e.x109e3389933c23a8;
		}
		throw new ArgumentOutOfRangeException("anchor", string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ahcdlijdfjaecjheajoecjffldmfphdgkhkggibhpcihchphfhgifhniegejehljcgckmgjkhbaleghldgolnffmlfmmnednhfkngfboieiobepomegpgpmpjdeacelamdcbhdjbhopbidhcjcocdcfdlnldlcdefckehbbfcbiffbpfpaggpangiaehealhnlbimajimppikpgjgpnjaafkaplkgpcliojlhoampjhmloomlnfnaomnindodnkobobpijip", 1921462829)));
	}
}
