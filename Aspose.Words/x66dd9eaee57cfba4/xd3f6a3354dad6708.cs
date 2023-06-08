using System;
using System.Drawing;
using x13f1efc79617a47b;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class xd3f6a3354dad6708 : xba15250b3f24fd3a
{
	internal uint x77fa6322561797a0;

	internal uint x8de74e31564e64c5;

	internal uint xdd16a0c1d2683acf;

	internal uint xb10d05bc0e744d16;

	internal ushort x586b7652ac7cefe0;

	internal ushort x0b1ef6b23d680fe3;

	internal long x006489c62fdcb656;

	internal long x15e2702e23e71188;

	internal short x9462c8df936efa39;

	internal short x5b051452efe1bbe3;

	internal short x11f73230b9b436a7;

	internal short xbed6b6abe5a7fcce;

	internal ushort x503e75bdd1af87ea;

	internal ushort x0ab4daadd7204883;

	internal short x671661f3a12f2c52;

	internal short x4d70d1472f8dc4ff;

	internal short xac3eb8b61b067115;

	internal bool x3ac3494a627eff42
	{
		get
		{
			return x4d70d1472f8dc4ff == 0;
		}
		set
		{
			x4d70d1472f8dc4ff = (short)((!value) ? 1 : 0);
		}
	}

	internal FontStyle xfe2178c1f916f36c
	{
		get
		{
			FontStyle fontStyle = FontStyle.Regular;
			fontStyle |= ((((uint)x503e75bdd1af87ea & (true ? 1u : 0u)) != 0) ? FontStyle.Bold : FontStyle.Regular);
			fontStyle |= (((x503e75bdd1af87ea & 2u) != 0) ? FontStyle.Italic : FontStyle.Regular);
			return fontStyle | (((x503e75bdd1af87ea & 4u) != 0) ? FontStyle.Underline : FontStyle.Regular);
		}
	}

	internal static xd3f6a3354dad6708 x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75)
	{
		xd3f6a3354dad6708 xd3f6a3354dad6709 = new xd3f6a3354dad6708();
		xd3f6a3354dad6709.x77fa6322561797a0 = xe134235b3526fa75.x2aa9a7ff4efa6ddf();
		if (xd3f6a3354dad6709.x77fa6322561797a0 != 65536)
		{
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("coijippjkpgkjpnkbpeloollkocmkojmjoanhnhndnonmifopmmofndpbnkpenbanhiacmpamlgbflnbflecoglcbmcdnkjdhlaeflheikoelkffhkmfegdg", 1916901517)));
		}
		xd3f6a3354dad6709.x8de74e31564e64c5 = xe134235b3526fa75.x2aa9a7ff4efa6ddf();
		xd3f6a3354dad6709.xdd16a0c1d2683acf = xe134235b3526fa75.x2aa9a7ff4efa6ddf();
		xd3f6a3354dad6709.xb10d05bc0e744d16 = xe134235b3526fa75.x2aa9a7ff4efa6ddf();
		if (xd3f6a3354dad6709.xb10d05bc0e744d16 != 1594834165)
		{
			throw new NotSupportedException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("hchgndogpdfhodmhgddiddkipcbjpcijocpjmbgkibnkbndlebllkbcmgbjmjbancmgnhaonbafokplokpcpdljpnpaaoohabpoaapfbhombbkdcmokcapbdfoidhnpdhngebonekjef", 86009554)));
		}
		xd3f6a3354dad6709.x586b7652ac7cefe0 = xe134235b3526fa75.xdb264d863790ee7b();
		xd3f6a3354dad6709.x0b1ef6b23d680fe3 = xe134235b3526fa75.xdb264d863790ee7b();
		xd3f6a3354dad6709.x006489c62fdcb656 = xe134235b3526fa75.xadf3d86ee4125c04();
		xd3f6a3354dad6709.x15e2702e23e71188 = xe134235b3526fa75.xadf3d86ee4125c04();
		xd3f6a3354dad6709.x9462c8df936efa39 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xd3f6a3354dad6709.x5b051452efe1bbe3 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xd3f6a3354dad6709.x11f73230b9b436a7 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xd3f6a3354dad6709.xbed6b6abe5a7fcce = xe134235b3526fa75.x2e6b89ad8001e18f();
		xd3f6a3354dad6709.x503e75bdd1af87ea = xe134235b3526fa75.xdb264d863790ee7b();
		xd3f6a3354dad6709.x0ab4daadd7204883 = xe134235b3526fa75.xdb264d863790ee7b();
		xd3f6a3354dad6709.x671661f3a12f2c52 = xe134235b3526fa75.x2e6b89ad8001e18f();
		xd3f6a3354dad6709.x4d70d1472f8dc4ff = xe134235b3526fa75.x2e6b89ad8001e18f();
		xd3f6a3354dad6709.xac3eb8b61b067115 = xe134235b3526fa75.x2e6b89ad8001e18f();
		return xd3f6a3354dad6709;
	}

	internal override void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x04aa082effd9db6b(x77fa6322561797a0);
		xbdfb620b7167944b.x04aa082effd9db6b(x8de74e31564e64c5);
		xbdfb620b7167944b.x04aa082effd9db6b(xdd16a0c1d2683acf);
		xbdfb620b7167944b.x04aa082effd9db6b(xb10d05bc0e744d16);
		xbdfb620b7167944b.xb0c682b9901a2443(x586b7652ac7cefe0);
		xbdfb620b7167944b.xb0c682b9901a2443(x0b1ef6b23d680fe3);
		xbdfb620b7167944b.x1cc8cfe834f421cf(x006489c62fdcb656);
		xbdfb620b7167944b.x1cc8cfe834f421cf(x15e2702e23e71188);
		xbdfb620b7167944b.xab5f6b7526efa5be(x9462c8df936efa39);
		xbdfb620b7167944b.xab5f6b7526efa5be(x5b051452efe1bbe3);
		xbdfb620b7167944b.xab5f6b7526efa5be(x11f73230b9b436a7);
		xbdfb620b7167944b.xab5f6b7526efa5be(xbed6b6abe5a7fcce);
		xbdfb620b7167944b.xb0c682b9901a2443(x503e75bdd1af87ea);
		xbdfb620b7167944b.xb0c682b9901a2443(x0ab4daadd7204883);
		xbdfb620b7167944b.xab5f6b7526efa5be(x671661f3a12f2c52);
		xbdfb620b7167944b.xab5f6b7526efa5be(x4d70d1472f8dc4ff);
		xbdfb620b7167944b.xab5f6b7526efa5be(xac3eb8b61b067115);
	}
}
