using System;
using Aspose;
using Aspose.Words;
using Aspose.Words.Tables;

namespace x4adf554d20d941a6;

internal class xe49914456d73f03a
{
	internal static int x795e09a07e435cf4(x694f001896973fe3 xa806b754814b9ae0)
	{
		if (!xa806b754814b9ae0.x2c8c6741422a1298.x80f061859cd048ae.xde015839cc88f18d.xbdfb47a8b2b25dd9 && !xa806b754814b9ae0.x6114c4bffcfcb303)
		{
			x387d31b7e6ea1182 xc22e54d85f137f3e = xa806b754814b9ae0.x838c6c67b5953bb0.xc22e54d85f137f3e;
			x694f001896973fe3 x694f001896973fe4 = ((xc22e54d85f137f3e != null) ? xc22e54d85f137f3e.xbc3a1ad7f75a88f9 : xa806b754814b9ae0.x838c6c67b5953bb0.x5d6d04c35215bc51);
			if (xa806b754814b9ae0.xc255c495fd9232ca.x954503abc583f675 == x954503abc583f675.x4c38e800e85b21ad && xa806b754814b9ae0.x957cd3867cc3a9f3)
			{
				x694f001896973fe4 = xa806b754814b9ae0.x838c6c67b5953bb0.x133f2db9e5b5690d.x5d6d04c35215bc51.x5d6d04c35215bc51;
			}
			return xa806b754814b9ae0.x8786efe6471e0521 ? (x694f001896973fe4.x419ba17a5322627b - xa806b754814b9ae0.xdc1bf80853046136) : x694f001896973fe4.x8df91a2f90079e88;
		}
		return x795e09a07e435cf4(xa806b754814b9ae0, xa806b754814b9ae0.xc255c495fd9232ca.x5c392d6ad6fe7e28, xa806b754814b9ae0.xc255c495fd9232ca.xdc1bf80853046136 - xa806b754814b9ae0.xc255c495fd9232ca.xf159a68356fd5b23);
	}

	private static bool xab2167262ab88efc(x694f001896973fe3 xa806b754814b9ae0)
	{
		return true;
	}

	internal static int x795e09a07e435cf4(x694f001896973fe3 xa806b754814b9ae0, int x046c3c7f1587ec21, int x8daa78cf95eabc80)
	{
		bool xbdfb47a8b2b25dd = xa806b754814b9ae0.x2c8c6741422a1298.x80f061859cd048ae.xde015839cc88f18d.xbdfb47a8b2b25dd9;
		if (xa7a98231d4a67a0f.x1f634e91b242c296(xa806b754814b9ae0) < 0)
		{
			if (xa806b754814b9ae0.xc255c495fd9232ca.x954503abc583f675 != x954503abc583f675.x11db8fc7f469a2fc)
			{
				return 0;
			}
			return xa3a992e8cf81dabe.x084819436cb905ef(xa806b754814b9ae0.x838c6c67b5953bb0.x133f2db9e5b5690d.x5d6d04c35215bc51.x96ac59f61797f5b9, BorderType.Left) / 2;
		}
		bool flag = xa806b754814b9ae0.xc255c495fd9232ca.x954503abc583f675 != x954503abc583f675.x11db8fc7f469a2fc;
		x387d31b7e6ea1182 x838c6c67b5953bb = xa806b754814b9ae0.x838c6c67b5953bb0;
		x387d31b7e6ea1182 x5d6d04c35215bc = x838c6c67b5953bb.x133f2db9e5b5690d.x5d6d04c35215bc51;
		int num = (xbdfb47a8b2b25dd ? x1a230fd898c649eb(x838c6c67b5953bb) : xb2d321e96d093f95(x838c6c67b5953bb.x133f2db9e5b5690d));
		int num2;
		switch (x838c6c67b5953bb.x768f9befb545345a.x9ba359ff37a3a63b)
		{
		case TableAlignment.Right:
			num2 = x8daa78cf95eabc80 - num;
			if (flag)
			{
				num2 += x838c6c67b5953bb.x96ac59f61797f5b9.xdfd0c9de0b4aa96a.xcad2e59522947ede;
			}
			break;
		case TableAlignment.Center:
		{
			int num3 = x8daa78cf95eabc80 - x046c3c7f1587ec21;
			num2 = x046c3c7f1587ec21 + (num3 - num) / 2;
			break;
		}
		default:
		{
			int xc0741c7ff92cf1aa = x5d6d04c35215bc.x768f9befb545345a.xc0741c7ff92cf1aa;
			num2 = xc0741c7ff92cf1aa + x046c3c7f1587ec21;
			if (flag)
			{
				num2 -= xa3a992e8cf81dabe.xa1de765ea88f71a2(x5d6d04c35215bc.x96ac59f61797f5b9);
			}
			break;
		}
		}
		if (xa806b754814b9ae0.x8786efe6471e0521)
		{
			num2 = xa806b754814b9ae0.xc255c495fd9232ca.xdc1bf80853046136 - (num2 + xa806b754814b9ae0.xdc1bf80853046136);
		}
		return num2;
	}

	internal static int x29b834e8e9ff09ed(x694f001896973fe3 xa806b754814b9ae0)
	{
		x398b3bd0acd94b61 x398b3bd0acd94b62 = xa7a98231d4a67a0f.xd242606bb2edd94a(xa806b754814b9ae0);
		if (x398b3bd0acd94b62 != null)
		{
			return x398b3bd0acd94b62.xc821290d7ecc08bf + x398b3bd0acd94b62.x319720dedc082a9d;
		}
		int num = ((!xa7a98231d4a67a0f.xdd724c73394f5594(xa806b754814b9ae0)) ? xa806b754814b9ae0.xc255c495fd9232ca.x3dcafc2d758260e1 : 0);
		int num2 = ((!xa806b754814b9ae0.x838c6c67b5953bb0.x768f9befb545345a.x0f709e8a26f5dccd) ? xa806b754814b9ae0.x838c6c67b5953bb0.x133f2db9e5b5690d.x46557be7fe69f982 : 0);
		return num + num2;
	}

	internal static int xc7c6550a888abaf3(x387d31b7e6ea1182 x2612f62f94df47de)
	{
		return x2612f62f94df47de.xc1277af2cd8d654e.x419ba17a5322627b;
	}

	internal static int xb2d321e96d093f95(x7c1e2b821e8b8220 x1ec770899c98a268)
	{
		return xf3c4d89d30e6d73d(x1ec770899c98a268.x03bb6a33fcd217b4, 0, 0);
	}

	private static int x1a230fd898c649eb(x387d31b7e6ea1182 xa806b754814b9ae0)
	{
		return xf3c4d89d30e6d73d(xa806b754814b9ae0.x133f2db9e5b5690d.x03bb6a33fcd217b4, xa806b754814b9ae0.x768f9befb545345a.x0364c07ad4dcfe0c, xa806b754814b9ae0.x768f9befb545345a.x851fcfc17df82b1b);
	}

	private static int xf3c4d89d30e6d73d(int[] x3040c866fac95193, int x29fc2c141ca2d4d9, int x54414f8df8e10b50)
	{
		int num = 0;
		int num2 = x3040c866fac95193.Length - x54414f8df8e10b50;
		for (int i = x29fc2c141ca2d4d9; i < num2; i++)
		{
			num += x3040c866fac95193[i];
		}
		return num;
	}

	internal static int x6be2ce937644ef37(x694f001896973fe3 xa806b754814b9ae0)
	{
		if (xa806b754814b9ae0.x1b4884baf08c8d62)
		{
			return 0;
		}
		int num = xdab87d3e2c659d95(xa806b754814b9ae0);
		if (xa806b754814b9ae0.x72376d6f76e1c4e5)
		{
			num += xa806b754814b9ae0.x7fe0bd4f21a85330;
		}
		return num;
	}

	internal static int x99c80529a1c59616(x694f001896973fe3 xa806b754814b9ae0)
	{
		int num = 0;
		bool flag = xa806b754814b9ae0.xe5764fe5359a6d91 && xa806b754814b9ae0.xc255c495fd9232ca.xe5764fe5359a6d91 && xa806b754814b9ae0.xd40b2068334ae37c;
		x86accec882b7012a x86accec882b7012a2 = xa806b754814b9ae0.x96ac59f61797f5b9;
		while (x86accec882b7012a2 != null && !x86accec882b7012a2.xd40b2068334ae37c)
		{
			if (!x86accec882b7012a2.xc5464084edc8e226.x01bc5527a261f633 && (x86accec882b7012a2.x3e8d56eefc6dfdad == null || x86accec882b7012a2.x3e8d56eefc6dfdad.xc255c495fd9232ca != x86accec882b7012a2.xc255c495fd9232ca) && (x86accec882b7012a2.xc5464084edc8e226.x6c68e8efd3a92e85 == x6c68e8efd3a92e85.x4d0b9d4447ba7566 || (flag && x86accec882b7012a2.xc5464084edc8e226.x6c68e8efd3a92e85 == x6c68e8efd3a92e85.x38ced5a01a389303)))
			{
				num = Math.Max(num, x86accec882b7012a2.xbcd477821fdbd81b);
			}
			x86accec882b7012a2 = (x86accec882b7012a)x86accec882b7012a2.xf432ece93e450408();
		}
		return num;
	}

	internal static int x2e60ee82bf08b364(x694f001896973fe3 xa806b754814b9ae0)
	{
		return x6be2ce937644ef37(xa806b754814b9ae0);
	}

	internal static int x97761a9f20472ac6(x694f001896973fe3 xa806b754814b9ae0)
	{
		int num = x701c22185168376d(xa806b754814b9ae0);
		return num + xa806b754814b9ae0.x887a0c79ecbe5ee3 + xa806b754814b9ae0.x79a071bfba0c5e7d;
	}

	internal static int x701c22185168376d(x694f001896973fe3 xa806b754814b9ae0)
	{
		int num = xa3a992e8cf81dabe.x26f8a702152631c7(xa806b754814b9ae0, xa806b754814b9ae0.x838c6c67b5953bb0);
		if (xa806b754814b9ae0.x838c6c67b5953bb0.x768f9befb545345a.x85e9ab4255d7e70c != HeightRule.Exactly)
		{
			num += Math.Max(0, x3618324910f79f58(xa806b754814b9ae0) - num);
		}
		return num;
	}

	internal static int xdab87d3e2c659d95(x694f001896973fe3 xa806b754814b9ae0)
	{
		int num = x701c22185168376d(xa806b754814b9ae0);
		return num + (xa806b754814b9ae0.x887a0c79ecbe5ee3 + xa806b754814b9ae0.x3f614010338b985b);
	}

	internal static int x718661739aaa907b(x694f001896973fe3 xa806b754814b9ae0, bool x41537952ab630933)
	{
		if (xa806b754814b9ae0.x332a8eedb847940d.x332a8eedb847940d.x332a8eedb847940d.x5a5e07e9fa12451a == x5a5e07e9fa12451a.x11db8fc7f469a2fc)
		{
			x41537952ab630933 = true;
		}
		int num = 0;
		x86accec882b7012a x86accec882b7012a2 = xa806b754814b9ae0.x96ac59f61797f5b9;
		while (x86accec882b7012a2 != null && !x86accec882b7012a2.xd40b2068334ae37c)
		{
			num = Math.Max(num, xa3a992e8cf81dabe.x718661739aaa907b(x86accec882b7012a2, x41537952ab630933, x39df78691dbb02b2: false));
			x86accec882b7012a2 = (x86accec882b7012a)x86accec882b7012a2.xf432ece93e450408();
		}
		return num;
	}

	[JavaThrows(true)]
	private static int x3618324910f79f58(x694f001896973fe3 xa806b754814b9ae0)
	{
		int num = 0;
		x86accec882b7012a x86accec882b7012a2 = xa806b754814b9ae0.x96ac59f61797f5b9;
		while (x86accec882b7012a2 != null && !x86accec882b7012a2.xfdc6650195492419)
		{
			if (x86accec882b7012a2.xc5464084edc8e226.x6c68e8efd3a92e85 == x6c68e8efd3a92e85.xed3e432f7c9bf846 && !x86accec882b7012a2.xc5464084edc8e226.x01bc5527a261f633)
			{
				xa6c6ed003f022075.xdc225c5ddc3ad3bb(x86accec882b7012a2, x85eafb71f618c3ae: false, out var x38c4721daa07b, out var x54fc596d5a45962d);
				num = Math.Max(num, x54fc596d5a45962d.xc255c495fd9232ca.xc821290d7ecc08bf + xa3a992e8cf81dabe.x97761a9f20472ac6(x38c4721daa07b) - xa806b754814b9ae0.x7fe0bd4f21a85330 - xa806b754814b9ae0.xc821290d7ecc08bf - xa806b754814b9ae0.x887a0c79ecbe5ee3);
			}
			x86accec882b7012a2 = (x86accec882b7012a)x86accec882b7012a2.xf432ece93e450408();
		}
		return num;
	}
}
