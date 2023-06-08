using System;
using System.Drawing;
using Aspose.Words;
using x13f1efc79617a47b;
using x1c8faa688b1f0b0c;
using x28925c9b27b37a46;
using x5794c252ba25e723;
using x6a42c37b95e9caa1;
using x6c95d9cf46ff5f25;

namespace x06e283fdfa5dc5f0;

internal class xaadf1ef8176ba89f
{
	private xe841d221096c0643 x92be23f9da255ff5;

	private xe841d221096c0643 x1eb0f2079082dc31;

	private float x764ec755b84fd3b7;

	private float x7fb097f4c63f3200;

	private float xf176f4fb26a1a10d;

	private float xc41984edda8958f8;

	private bool x7de5b88d5d11f601;

	private bool x70f7e6a46a8d4365;

	private static readonly int[] x182d2283a31036d8 = new int[3] { 3, 0, 1 };

	private static readonly int[] x2e44ae8b62e042be = new int[3] { 1, 0, 3 };

	private static readonly int[] x288c37c96ee2a533 = new int[3] { 1, 0, 1 };

	private static readonly int[] xa4cb7853f4a243a2 = new int[5] { 5, 0, 3, 0, 1 };

	private static readonly int[] xd76944ae6b16f4b1 = new int[5] { 1, 0, 3, 0, 5 };

	private static readonly int[] xdc778b9405dc87bb = new int[5] { 1, 0, 3, 0, 1 };

	private bool x4cb9a8bff1ec4dc0
	{
		get
		{
			switch (x63da2c280ec96749)
			{
			case BorderType.Left:
				return false;
			case BorderType.Right:
			case BorderType.Vertical:
				return true;
			case BorderType.Top:
				return false;
			case BorderType.Bottom:
			case BorderType.Horizontal:
				return true;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("mijgckahmjhhmjohkjfipjmidjdjcekjbibkliiklipkkhglihnlciemnclmohcnaijnehaogghomcoo", 526936375)));
			}
		}
	}

	private bool x112fa1f2de214ac6
	{
		get
		{
			switch (x63da2c280ec96749)
			{
			case BorderType.Left:
				return true;
			case BorderType.Right:
			case BorderType.Vertical:
				return false;
			case BorderType.Top:
				return true;
			case BorderType.Bottom:
			case BorderType.Horizontal:
				return false;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("amebgnlbanccanjcomaddnhdhmodghfeflmepldfplkfokbgmkigglpgbgghclnheleiiklikjcjagjj", 1882723435)));
			}
		}
	}

	private bool x976bd365acc15c27
	{
		get
		{
			switch (x63da2c280ec96749)
			{
			case BorderType.Bottom:
			case BorderType.Right:
				return xd7021bbd10567d53.x227665e444fb500a;
			case BorderType.Left:
			case BorderType.Top:
			case BorderType.Horizontal:
			case BorderType.Vertical:
				return false;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ianpobeaiblaibcbgbjblbacpahcolncnpedhamdhadegpjeepafophfjkofkpfgmpmgapdhcokhikbi", 395574451)));
			}
		}
	}

	private bool xfd9dfeea07d1eb36
	{
		get
		{
			switch (x63da2c280ec96749)
			{
			case BorderType.Left:
				if (x1eb0f2079082dc31.x0cefdba378e0d261)
				{
					return xd7021bbd10567d53.x227665e444fb500a;
				}
				return false;
			case BorderType.Right:
				if (!x1eb0f2079082dc31.x0cefdba378e0d261)
				{
					return xd7021bbd10567d53.x227665e444fb500a;
				}
				return false;
			case BorderType.Vertical:
				return false;
			case BorderType.Top:
				return xd7021bbd10567d53.x227665e444fb500a;
			case BorderType.Bottom:
				return false;
			case BorderType.Horizontal:
				return xd7021bbd10567d53.x227665e444fb500a;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("ncmddedendkendbfldifaepfedggdomgccehmclhmccilbjijbajdchjomnjpbfkbcmkfbdlhaklnmam", 37043160)));
			}
		}
	}

	private bool xf7b787cec86778e1
	{
		get
		{
			switch (x63da2c280ec96749)
			{
			case BorderType.Left:
			case BorderType.Top:
				return false;
			case BorderType.Bottom:
			case BorderType.Right:
				return !xd7021bbd10567d53.x227665e444fb500a;
			case BorderType.Horizontal:
			case BorderType.Vertical:
				return true;
			default:
				throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("cjokikflckmlckdmakkmfkbnjjiniepnhigobjnobjepailpohcaiijaddabeihbgiobkhfcmgmccddd", 841657917)));
			}
		}
	}

	private bool x3a333903e6616945
	{
		get
		{
			if (!x5d9403404a946e14)
			{
				return x92be23f9da255ff5.x53263535daa1c4d0;
			}
			return x92be23f9da255ff5.x986456b0b2f01ea0;
		}
	}

	private bool x8485c89f8c613a16
	{
		get
		{
			if (!x5d9403404a946e14)
			{
				return x1eb0f2079082dc31.x99da06d3e3e3df11;
			}
			return x1eb0f2079082dc31.x4726fa3bbc3dd081;
		}
	}

	private Border xd7021bbd10567d53
	{
		get
		{
			if (x5d9403404a946e14)
			{
				return x92be23f9da255ff5.x3903fbc9023c861c;
			}
			return x92be23f9da255ff5.x0924cade9dc2d296;
		}
	}

	private BorderType x63da2c280ec96749
	{
		get
		{
			if (x92be23f9da255ff5.x0cbb90e1280f5639 && x1eb0f2079082dc31.x0cbb90e1280f5639)
			{
				return BorderType.Left;
			}
			if (x92be23f9da255ff5.x08c2d887a8477d25 && x1eb0f2079082dc31.x08c2d887a8477d25)
			{
				return BorderType.Right;
			}
			if (x92be23f9da255ff5.xbbb7728c0d3a91f6 && x1eb0f2079082dc31.xbbb7728c0d3a91f6)
			{
				return BorderType.Top;
			}
			if (x92be23f9da255ff5.x0cefdba378e0d261 && x1eb0f2079082dc31.x0cefdba378e0d261)
			{
				return BorderType.Bottom;
			}
			if (x70f7e6a46a8d4365)
			{
				return BorderType.Vertical;
			}
			return BorderType.Horizontal;
		}
	}

	private x26d9ecb4bdf0456d x9b41425268471380
	{
		get
		{
			x26d9ecb4bdf0456d x63b1a7c31a = xd7021bbd10567d53.x63b1a7c31a962459;
			if (x63b1a7c31a.x7149c962c02931b3)
			{
				return x26d9ecb4bdf0456d.x89fffa2751fdecbe;
			}
			return x63b1a7c31a;
		}
	}

	private float xffa1fc725bf36690 => (float)xd7021bbd10567d53.LineWidth;

	private float xeae235558dc44397 => xd7021bbd10567d53.xeae235558dc44397;

	private float xcb7f63403c44ccba
	{
		get
		{
			switch (x3d0571719b5893b4)
			{
			case LineStyle.Single:
			case LineStyle.Dot:
			case LineStyle.DashLargeGap:
			case LineStyle.DotDash:
			case LineStyle.DotDotDash:
			case LineStyle.Wave:
			case LineStyle.DoubleWave:
			case LineStyle.DashSmallGap:
			case LineStyle.DashDotStroker:
				return xeae235558dc44397;
			case LineStyle.Double:
			case LineStyle.Triple:
			case LineStyle.ThinThickSmallGap:
			case LineStyle.ThickThinSmallGap:
			case LineStyle.ThinThickThinSmallGap:
			case LineStyle.ThinThickMediumGap:
			case LineStyle.ThickThinMediumGap:
			case LineStyle.ThinThickThinMediumGap:
			case LineStyle.ThinThickLargeGap:
			case LineStyle.ThickThinLargeGap:
			case LineStyle.ThinThickThinLargeGap:
			case LineStyle.Emboss3D:
			case LineStyle.Engrave3D:
				return xffa1fc725bf36690;
			case LineStyle.Thick:
			case LineStyle.Hairline:
				return 1f;
			case LineStyle.Outset:
			case LineStyle.Inset:
				return 1f;
			default:
				return xeae235558dc44397;
			}
		}
	}

	private LineStyle x3d0571719b5893b4 => xd7021bbd10567d53.LineStyle;

	private bool xbca512cb9f5a451a => xd7021bbd10567d53.xbca512cb9f5a451a;

	private bool x7d8bb4adc1a34cd3 => xd7021bbd10567d53.x27d7528a28faeec8();

	private bool x6c1806535f76dd8d
	{
		get
		{
			if (xd7021bbd10567d53.Shadow)
			{
				if (x63da2c280ec96749 != 0)
				{
					return x63da2c280ec96749 == BorderType.Right;
				}
				return true;
			}
			return false;
		}
	}

	private bool xfe52fcdb589cdb39
	{
		get
		{
			switch (x63da2c280ec96749)
			{
			case BorderType.Bottom:
			case BorderType.Top:
			case BorderType.Horizontal:
				return true;
			default:
				return false;
			}
		}
	}

	private bool x5d9403404a946e14
	{
		get
		{
			switch (x63da2c280ec96749)
			{
			case BorderType.Left:
			case BorderType.Right:
			case BorderType.Vertical:
				return true;
			default:
				return false;
			}
		}
	}

	internal void xe406325e56f74b46(xe841d221096c0643 xcb09bd0cee4909a3, xe841d221096c0643 xa2da454aa40879d2, bool x627fac783af9499d, bool xe51c6c8096b26a1f, xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		x92be23f9da255ff5 = xcb09bd0cee4909a3;
		x1eb0f2079082dc31 = xa2da454aa40879d2;
		x7de5b88d5d11f601 = x627fac783af9499d;
		x70f7e6a46a8d4365 = xe51c6c8096b26a1f;
		x764ec755b84fd3b7 = x92be23f9da255ff5.xab07b26048f600ba.X;
		x7fb097f4c63f3200 = x92be23f9da255ff5.xab07b26048f600ba.Y;
		xf176f4fb26a1a10d = x1eb0f2079082dc31.xab07b26048f600ba.X;
		xc41984edda8958f8 = x1eb0f2079082dc31.xab07b26048f600ba.Y;
		xf5eb442bac38892a();
		x814608aa21f90eeb();
		x468b3e131f0c8061();
		xa7a441e9d4de36b0(x0f7b23d1c393aed9);
		if (x6c1806535f76dd8d)
		{
			xc698485eba912f6e(x0f7b23d1c393aed9);
		}
	}

	private void x468b3e131f0c8061()
	{
		if (x63da2c280ec96749 == BorderType.Horizontal)
		{
			x7fb097f4c63f3200 += xeae235558dc44397;
			xc41984edda8958f8 += xeae235558dc44397;
		}
	}

	private void xf5eb442bac38892a()
	{
		if (!x7de5b88d5d11f601)
		{
			return;
		}
		if (xfe52fcdb589cdb39)
		{
			PointF pointF = x42f278765ed22119(x779ffac5703ea31a(x92be23f9da255ff5) / 2f);
			x764ec755b84fd3b7 = pointF.X;
			x7fb097f4c63f3200 = pointF.Y;
			PointF pointF2 = x7f01025cd5d5554e(x779ffac5703ea31a(x1eb0f2079082dc31) / 2f);
			xf176f4fb26a1a10d = pointF2.X;
			xc41984edda8958f8 = pointF2.Y;
		}
		switch (x63da2c280ec96749)
		{
		case BorderType.Bottom:
			x7fb097f4c63f3200 = xc41984edda8958f8;
			x7fb097f4c63f3200 += xeae235558dc44397;
			xc41984edda8958f8 += xeae235558dc44397;
			break;
		case BorderType.Left:
			x764ec755b84fd3b7 -= xeae235558dc44397 / 2f;
			xf176f4fb26a1a10d -= xeae235558dc44397 / 2f;
			break;
		case BorderType.Vertical:
			if (x1eb0f2079082dc31.x0cefdba378e0d261 && x1eb0f2079082dc31.x53263535daa1c4d0)
			{
				xc41984edda8958f8 = x1eb0f2079082dc31.x6d763e63b9853d90.xab07b26048f600ba.Y;
			}
			x20ffed0cf0b16ad0();
			break;
		case BorderType.Right:
			x20ffed0cf0b16ad0();
			break;
		case BorderType.Top:
		case BorderType.Horizontal:
			break;
		}
	}

	private void x20ffed0cf0b16ad0()
	{
		x764ec755b84fd3b7 += xeae235558dc44397 / 2f;
		xf176f4fb26a1a10d += xeae235558dc44397 / 2f;
	}

	private void x814608aa21f90eeb()
	{
		if (x946ff67db4fb7db8())
		{
			PointF pointF = x42f278765ed22119(0f - x779ffac5703ea31a(x92be23f9da255ff5));
			x764ec755b84fd3b7 = pointF.X;
			x7fb097f4c63f3200 = pointF.Y;
		}
		if (x5d320475a61f8558())
		{
			PointF pointF2 = x7f01025cd5d5554e(0f - x779ffac5703ea31a(x1eb0f2079082dc31));
			xf176f4fb26a1a10d = pointF2.X;
			xc41984edda8958f8 = pointF2.Y;
		}
	}

	private bool x946ff67db4fb7db8()
	{
		if (x5d9403404a946e14)
		{
			return true;
		}
		if (!x92be23f9da255ff5.xe68687edc689a222)
		{
			return x92be23f9da255ff5.xc5ba672e20f97d35;
		}
		return true;
	}

	private bool x5d320475a61f8558()
	{
		if (x5d9403404a946e14)
		{
			if (x1eb0f2079082dc31.x0cefdba378e0d261)
			{
				return !x7de5b88d5d11f601;
			}
			return false;
		}
		if (!x1eb0f2079082dc31.xc5ba672e20f97d35)
		{
			return x1eb0f2079082dc31.xe68687edc689a222;
		}
		return true;
	}

	private float x779ffac5703ea31a(xe841d221096c0643 x2f7096dac971d6ec)
	{
		switch (x63da2c280ec96749)
		{
		case BorderType.Left:
			return x2f7096dac971d6ec.x0924cade9dc2d296.xeae235558dc44397;
		case BorderType.Right:
			return x2f7096dac971d6ec.x92e7e5f35452590d.xeae235558dc44397;
		case BorderType.Vertical:
			if (!x2f7096dac971d6ec.x53263535daa1c4d0)
			{
				return x2f7096dac971d6ec.x92e7e5f35452590d.xeae235558dc44397;
			}
			return x2f7096dac971d6ec.x0924cade9dc2d296.xeae235558dc44397;
		case BorderType.Top:
			return x2f7096dac971d6ec.x3903fbc9023c861c.xeae235558dc44397;
		case BorderType.Bottom:
			return x2f7096dac971d6ec.x9d329a00f2c534a8.xeae235558dc44397;
		case BorderType.Horizontal:
			if (!x2f7096dac971d6ec.x4726fa3bbc3dd081)
			{
				return x2f7096dac971d6ec.x3903fbc9023c861c.xeae235558dc44397;
			}
			return x2f7096dac971d6ec.x9d329a00f2c534a8.xeae235558dc44397;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("belchfcdlejdlfaeafheceoendfflemfjddgfdkgooahncihhdphhdgigcniecejocljjnbkkcjkmcalachlcbolinem", 481241836)));
		}
	}

	private void xa7a441e9d4de36b0(xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		float[] x7f5e3cc31dbfa85f = null;
		int[] array = null;
		bool flag = x3a333903e6616945;
		if (flag)
		{
			bool x4524f2268d8cf = x92be23f9da255ff5.xf1ea162af2edd4d0 ^ x4cb9a8bff1ec4dc0 ^ x976bd365acc15c27 ^ xf7b787cec86778e1;
			x7f5e3cc31dbfa85f = x7528558668744d84(x4524f2268d8cf);
			array = xfaad16b757fbc3cf(x92be23f9da255ff5);
		}
		float[] x7f5e3cc31dbfa85f2 = null;
		int[] array2 = null;
		bool flag2 = x8485c89f8c613a16;
		if (flag2)
		{
			bool x4524f2268d8cf2 = x1eb0f2079082dc31.xf1ea162af2edd4d0 ^ x112fa1f2de214ac6 ^ xfd9dfeea07d1eb36 ^ xf7b787cec86778e1;
			x7f5e3cc31dbfa85f2 = x7528558668744d84(x4524f2268d8cf2);
			array2 = xfaad16b757fbc3cf(x1eb0f2079082dc31);
		}
		float[] array3 = x7528558668744d84(xf7b787cec86778e1);
		for (int i = 0; i < array3.Length; i++)
		{
			float xbcea506a33cf = array3[i] / 2f;
			x575db3fedeadea6b(xbcea506a33cf);
			if (!x0d299f323d241756.x7e32f71c3f39b6bc(i))
			{
				PointF pointF = ((!flag) ? new PointF(x764ec755b84fd3b7, x7fb097f4c63f3200) : x42f278765ed22119(xf1781b06cebbc1b1(array[i], x7f5e3cc31dbfa85f)));
				PointF pointF2 = ((!flag2) ? new PointF(xf176f4fb26a1a10d, xc41984edda8958f8) : x7f01025cd5d5554e(xf1781b06cebbc1b1(array2[i], x7f5e3cc31dbfa85f2)));
				x4fdf549af9de6b97 xda5bf54deb817e = (xbca512cb9f5a451a ? ((x4fdf549af9de6b97)x93e9449f9b10dc52(pointF, pointF2, array3[i])) : ((x4fdf549af9de6b97)x1108ff941d309e12(pointF, pointF2, i, array3)));
				x0f7b23d1c393aed9.x1fa9148f6731ff24(xda5bf54deb817e);
			}
			x575db3fedeadea6b(xbcea506a33cf);
		}
	}

	private float[] x7528558668744d84(bool x4524f2268d8cf309)
	{
		float[] array = Border.x7528558668744d84(x3d0571719b5893b4, xcb7f63403c44ccba);
		if (x4524f2268d8cf309)
		{
			Array.Reverse(array);
		}
		return array;
	}

	private void x75f9ee1f57ffe08e(x31c19fcb724dfaf5 x90279591611601bc)
	{
		float[] array = Border.xfddcf003f8c48200(x3d0571719b5893b4, 1f);
		if (array != null)
		{
			x90279591611601bc.x358988d12e56bf69 = array;
		}
	}

	private void xc698485eba912f6e(xe6a5f3ec802a6d51 x0f7b23d1c393aed9)
	{
		x764ec755b84fd3b7 = x92be23f9da255ff5.xab07b26048f600ba.X;
		x7fb097f4c63f3200 = x92be23f9da255ff5.xab07b26048f600ba.Y;
		xf176f4fb26a1a10d = x1eb0f2079082dc31.xab07b26048f600ba.X;
		xc41984edda8958f8 = x1eb0f2079082dc31.xab07b26048f600ba.Y;
		x575db3fedeadea6b((0f - xeae235558dc44397) / 2f);
		PointF x10aaa7cdfa38f = x42f278765ed22119(0f - xeae235558dc44397);
		float num = ((!xfe52fcdb589cdb39) ? 1 : 0);
		PointF xca09b6c2b5b = x7f01025cd5d5554e(xeae235558dc44397 * num);
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x10aaa7cdfa38f, xca09b6c2b5b);
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe, xeae235558dc44397);
		x0f7b23d1c393aed9.x1fa9148f6731ff24(xab391c46ff9a0a);
	}

	private void x575db3fedeadea6b(float xbcea506a33cf9111)
	{
		switch (x63da2c280ec96749)
		{
		case BorderType.Left:
			x764ec755b84fd3b7 += xbcea506a33cf9111;
			xf176f4fb26a1a10d += xbcea506a33cf9111;
			break;
		case BorderType.Right:
		case BorderType.Vertical:
			x764ec755b84fd3b7 -= xbcea506a33cf9111;
			xf176f4fb26a1a10d -= xbcea506a33cf9111;
			break;
		case BorderType.Top:
			x7fb097f4c63f3200 += xbcea506a33cf9111;
			xc41984edda8958f8 += xbcea506a33cf9111;
			break;
		case BorderType.Bottom:
		case BorderType.Horizontal:
			x7fb097f4c63f3200 -= xbcea506a33cf9111;
			xc41984edda8958f8 -= xbcea506a33cf9111;
			break;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("phddfjkdjibejjieoipeaigflhnfjieghhlgdhchmcjhlgaifhhifhoiegfjcgmjmgdkhbkkigblkgilofplafgmgbnm", 1308308266)));
		}
	}

	private PointF x42f278765ed22119(float xbcea506a33cf9111)
	{
		if (x5d9403404a946e14)
		{
			return new PointF(x764ec755b84fd3b7, x7fb097f4c63f3200 - xbcea506a33cf9111);
		}
		return new PointF(x764ec755b84fd3b7 - xbcea506a33cf9111, x7fb097f4c63f3200);
	}

	private PointF x7f01025cd5d5554e(float xbcea506a33cf9111)
	{
		if (x5d9403404a946e14)
		{
			return new PointF(xf176f4fb26a1a10d, xc41984edda8958f8 + xbcea506a33cf9111);
		}
		return new PointF(xf176f4fb26a1a10d + xbcea506a33cf9111, xc41984edda8958f8);
	}

	private int[] xfaad16b757fbc3cf(xe841d221096c0643 x2f7096dac971d6ec)
	{
		return xd7021bbd10567d53.xd3369f817a5a99b6 switch
		{
			3 => x6ed78fca2b2315a1(x2f7096dac971d6ec, x182d2283a31036d8, x2e44ae8b62e042be, x288c37c96ee2a533), 
			5 => x6ed78fca2b2315a1(x2f7096dac971d6ec, xa4cb7853f4a243a2, xd76944ae6b16f4b1, xdc778b9405dc87bb), 
			_ => null, 
		};
	}

	private int[] x6ed78fca2b2315a1(xe841d221096c0643 x2f7096dac971d6ec, int[] x3c1dd115d44219d7, int[] xe568f1586d63fbe2, int[] x6842e8cffe695531)
	{
		switch (x2f7096dac971d6ec.x9e9752d5f0076f53)
		{
		case 2:
			switch (x63da2c280ec96749)
			{
			case BorderType.Vertical:
				if (!x2f7096dac971d6ec.x99da06d3e3e3df11)
				{
					return xe568f1586d63fbe2;
				}
				return x3c1dd115d44219d7;
			case BorderType.Horizontal:
				if (!x2f7096dac971d6ec.x4726fa3bbc3dd081)
				{
					return xe568f1586d63fbe2;
				}
				return x3c1dd115d44219d7;
			default:
				return x3c1dd115d44219d7;
			}
		case 3:
			switch (x63da2c280ec96749)
			{
			case BorderType.Vertical:
				if (x2f7096dac971d6ec.x99da06d3e3e3df11 && x2f7096dac971d6ec.x53263535daa1c4d0)
				{
					return x6842e8cffe695531;
				}
				if (!x2f7096dac971d6ec.x99da06d3e3e3df11)
				{
					return xe568f1586d63fbe2;
				}
				return x3c1dd115d44219d7;
			case BorderType.Horizontal:
				if (x2f7096dac971d6ec.x4726fa3bbc3dd081 && x2f7096dac971d6ec.x986456b0b2f01ea0)
				{
					return x6842e8cffe695531;
				}
				if (!x2f7096dac971d6ec.x4726fa3bbc3dd081)
				{
					return xe568f1586d63fbe2;
				}
				return x3c1dd115d44219d7;
			default:
				return x3c1dd115d44219d7;
			}
		case 4:
			return x6842e8cffe695531;
		default:
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("gflkmgclagjlahamfghmhfomcffnagmnoedokekodabpoeipcfpphegajdnajdebdelboobckdjcocadfogdfcodocfekcmehcdflbkfgbbgecigcbpgoaghhmmhgaeiabliabcjppijnppjhahkfaokpkelnollnpcmgkjmeoanakhnnoonjofoaomocodpfokpmjba", 998157057)));
		}
	}

	private static float xf1781b06cebbc1b1(int x36f46f8fb2a628d6, float[] x7f5e3cc31dbfa85f)
	{
		float num = 0f;
		int num2 = x7f5e3cc31dbfa85f.Length - 1;
		while (x36f46f8fb2a628d6 > 0)
		{
			num += x7f5e3cc31dbfa85f[num2];
			num2--;
			x36f46f8fb2a628d6--;
		}
		return num;
	}

	private xab391c46ff9a0a38 x1108ff941d309e12(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485, int x4bd8b74a22f4705c, float[] x7f5e3cc31dbfa85f)
	{
		float num = x7f5e3cc31dbfa85f[x4bd8b74a22f4705c];
		xab391c46ff9a0a38 xab391c46ff9a0a = null;
		switch (x3d0571719b5893b4)
		{
		case LineStyle.Single:
		case LineStyle.Thick:
		case LineStyle.Double:
		case LineStyle.Hairline:
		case LineStyle.Dot:
		case LineStyle.DashLargeGap:
		case LineStyle.DotDash:
		case LineStyle.DotDotDash:
		case LineStyle.Triple:
		case LineStyle.ThinThickSmallGap:
		case LineStyle.ThickThinSmallGap:
		case LineStyle.ThinThickThinSmallGap:
		case LineStyle.ThinThickMediumGap:
		case LineStyle.ThickThinMediumGap:
		case LineStyle.ThinThickThinMediumGap:
		case LineStyle.ThinThickLargeGap:
		case LineStyle.ThickThinLargeGap:
		case LineStyle.ThinThickThinLargeGap:
		case LineStyle.DashSmallGap:
		case LineStyle.Outset:
		case LineStyle.Inset:
			xab391c46ff9a0a = x1391dc4a70c00cc8.x993ecefe54fbc5b2(x10aaa7cdfa38f254, xca09b6c2b5b18485, num, x9b41425268471380);
			break;
		case LineStyle.Wave:
			xab391c46ff9a0a = x1391dc4a70c00cc8.x6cd6f35dd96985c5(x10aaa7cdfa38f254, xca09b6c2b5b18485, xeae235558dc44397, x9b41425268471380, xfe52fcdb589cdb39);
			break;
		case LineStyle.DoubleWave:
			xab391c46ff9a0a = x1391dc4a70c00cc8.x0229f5079884c4e4(x10aaa7cdfa38f254, xca09b6c2b5b18485, xeae235558dc44397, x9b41425268471380, xfe52fcdb589cdb39);
			break;
		case LineStyle.DashDotStroker:
			xab391c46ff9a0a = x1391dc4a70c00cc8.x07cd9e4b459e78df(x10aaa7cdfa38f254, xca09b6c2b5b18485, xeae235558dc44397, x9b41425268471380, xfe52fcdb589cdb39);
			break;
		case LineStyle.Emboss3D:
			xab391c46ff9a0a = x1391dc4a70c00cc8.x993ecefe54fbc5b2(x10aaa7cdfa38f254, xca09b6c2b5b18485, xe7e034e5ba3aab76(x4bd8b74a22f4705c, num, xb90723cf77e0b32f: false));
			break;
		case LineStyle.Engrave3D:
			xab391c46ff9a0a = x1391dc4a70c00cc8.x993ecefe54fbc5b2(x10aaa7cdfa38f254, xca09b6c2b5b18485, xe7e034e5ba3aab76(x4bd8b74a22f4705c, num, xb90723cf77e0b32f: true));
			break;
		}
		if (xab391c46ff9a0a == null)
		{
			throw new InvalidOperationException(string.Intern(x1110bdd110cdcea4._xaacba899487bce8c("nnkddpbenoienopelogfapnfeoegdjlgcnchmnjhmnailmhijmoidnfjohmjhmdkbmkkdmblhlilpgplplgmnlnmplenpklnfkcolgjo", 869284488)));
		}
		if (x7f5e3cc31dbfa85f.Length == 1)
		{
			x75f9ee1f57ffe08e(xab391c46ff9a0a.x9e5d5f9128c69a8f);
		}
		return xab391c46ff9a0a;
	}

	private xb8e7e788f6d59708 x93e9449f9b10dc52(PointF xcb09bd0cee4909a3, PointF xa2da454aa40879d2, float xcf04eecfd2f30af4)
	{
		return x53b2bedf14731433(xcb09bd0cee4909a3, xa2da454aa40879d2, xcf04eecfd2f30af4, xfe52fcdb589cdb39);
	}

	private xb8e7e788f6d59708 x53b2bedf14731433(PointF xcb09bd0cee4909a3, PointF xa2da454aa40879d2, float xe0ef2c97820f557e, bool xcc09fce5e585e665)
	{
		xf247fba5a716fd2b xf247fba5a716fd2b = x8e8782e01637cfee.x986b193abe1e68e5((xd28385f788b65737)x3d0571719b5893b4);
		float x961016a387451f = (xcc09fce5e585e665 ? (xa2da454aa40879d2.X - xcb09bd0cee4909a3.X) : (xa2da454aa40879d2.Y - xcb09bd0cee4909a3.Y));
		float x9357424712fdcc = (xcc09fce5e585e665 ? xf247fba5a716fd2b.x48bad9bd1e802b02 : xf247fba5a716fd2b.x506be76690bd7373);
		x9357424712fdcc = x79840cff5c28d3f4(x9357424712fdcc, x961016a387451f, xe0ef2c97820f557e, xcc09fce5e585e665);
		int num = xdc6a5b7632f51c9c(x961016a387451f, xe0ef2c97820f557e, x9357424712fdcc, xcc09fce5e585e665);
		float xad98bd3cff4fc = xbaf4c2bdf2ecefd1(x961016a387451f, xe0ef2c97820f557e, x9357424712fdcc, xcc09fce5e585e665);
		float num2 = 0f;
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		for (int i = 0; i < num; i++)
		{
			x32836ca8baa844bb x60fe2a = xf6af2e51c152ddef(i, num, xcc09fce5e585e665);
			float num3 = x137225403ccf68b1(xe0ef2c97820f557e, x9357424712fdcc, xad98bd3cff4fc, x60fe2a);
			SizeF size = (xcc09fce5e585e665 ? new SizeF(num3, xe0ef2c97820f557e) : new SizeF(xe0ef2c97820f557e, num3));
			x72c34b8dbaec3734 xda5bf54deb817e = new x72c34b8dbaec3734(x2145ae762a54b17b(xcb09bd0cee4909a3, num2, xe0ef2c97820f557e, xcc09fce5e585e665), size, xf247fba5a716fd2b.x2bc6e069e2d64db8(x63da2c280ec96749, x60fe2a));
			xb8e7e788f6d.xd6b6ed77479ef68c(xda5bf54deb817e);
			num2 += num3;
		}
		return xb8e7e788f6d;
	}

	private float x79840cff5c28d3f4(float x9357424712fdcc52, float x961016a387451f05, float xe0ef2c97820f557e, bool xb78b86fab5d9d35d)
	{
		int num = (xb78b86fab5d9d35d ? 2 : 0);
		float num2 = x961016a387451f05 - (float)num * xe0ef2c97820f557e;
		if (num2 < xe0ef2c97820f557e * x9357424712fdcc52)
		{
			x9357424712fdcc52 = num2 / xe0ef2c97820f557e;
		}
		return x9357424712fdcc52;
	}

	private x32836ca8baa844bb xf6af2e51c152ddef(int x07433bb8b8eaa191, int x08095d2a195b07af, bool xcc09fce5e585e665)
	{
		if (!xcc09fce5e585e665)
		{
			return x32836ca8baa844bb.x83e8265cdba541b5;
		}
		if (x07433bb8b8eaa191 != 0)
		{
			if (x07433bb8b8eaa191 != x08095d2a195b07af - 1)
			{
				return x32836ca8baa844bb.x83e8265cdba541b5;
			}
			return x32836ca8baa844bb.xed3e432f7c9bf846;
		}
		return x32836ca8baa844bb.x38ced5a01a389303;
	}

	private float x137225403ccf68b1(float x389f579bb09d94ed, float x9357424712fdcc52, float xad98bd3cff4fc514, x32836ca8baa844bb x60fe2a0636112190)
	{
		if (x60fe2a0636112190 == x32836ca8baa844bb.x83e8265cdba541b5)
		{
			return x389f579bb09d94ed * x9357424712fdcc52 + xad98bd3cff4fc514;
		}
		return x389f579bb09d94ed;
	}

	private PointF x2145ae762a54b17b(PointF x9c3c185e7046dc72, float x374ea4fe62468d0f, float xe0ef2c97820f557e, bool xcc09fce5e585e665)
	{
		if (!xcc09fce5e585e665)
		{
			return new PointF(x9c3c185e7046dc72.X - xe0ef2c97820f557e / 2f, x9c3c185e7046dc72.Y + x374ea4fe62468d0f);
		}
		return new PointF(x9c3c185e7046dc72.X + x374ea4fe62468d0f, x9c3c185e7046dc72.Y - xe0ef2c97820f557e / 2f);
	}

	private int xdc6a5b7632f51c9c(float x961016a387451f05, float xe0ef2c97820f557e, float x9357424712fdcc52, bool xb78b86fab5d9d35d)
	{
		int num = (xb78b86fab5d9d35d ? 2 : 0);
		float num2 = (float)num * xe0ef2c97820f557e;
		int num3 = (int)((x961016a387451f05 - num2) / (xe0ef2c97820f557e * x9357424712fdcc52));
		return num + num3;
	}

	private float xbaf4c2bdf2ecefd1(float x961016a387451f05, float xe0ef2c97820f557e, float x9357424712fdcc52, bool xb78b86fab5d9d35d)
	{
		int num = (xb78b86fab5d9d35d ? 2 : 0);
		int num2 = xdc6a5b7632f51c9c(x961016a387451f05, xe0ef2c97820f557e, x9357424712fdcc52, xb78b86fab5d9d35d) - num;
		float num3 = (float)num * xe0ef2c97820f557e;
		float num4 = (float)num2 * xe0ef2c97820f557e * x9357424712fdcc52;
		return (x961016a387451f05 - num3 - num4) / (float)num2;
	}

	private x31c19fcb724dfaf5 xe7e034e5ba3aab76(int x4bd8b74a22f4705c, float xcf04eecfd2f30af4, bool xb90723cf77e0b32f)
	{
		x26d9ecb4bdf0456d[] array = xd59f38e934987538();
		x26d9ecb4bdf0456d[] array2 = ((!xb90723cf77e0b32f) ? new x26d9ecb4bdf0456d[5]
		{
			array[2],
			x26d9ecb4bdf0456d.x45260ad4b94166f2,
			array[1],
			x26d9ecb4bdf0456d.x45260ad4b94166f2,
			array[0]
		} : new x26d9ecb4bdf0456d[5]
		{
			array[0],
			x26d9ecb4bdf0456d.x45260ad4b94166f2,
			array[1],
			x26d9ecb4bdf0456d.x45260ad4b94166f2,
			array[2]
		});
		if (xf7b787cec86778e1)
		{
			Array.Reverse(array2);
		}
		return new x31c19fcb724dfaf5(array2[x4bd8b74a22f4705c], xcf04eecfd2f30af4);
	}

	private x26d9ecb4bdf0456d[] xd59f38e934987538()
	{
		x26d9ecb4bdf0456d[] array = new x26d9ecb4bdf0456d[3];
		x5d9526c9d39aeeb2 x5d9526c9d39aeeb = new x5d9526c9d39aeeb2(x9b41425268471380);
		if (x5d9526c9d39aeeb.x8e8f6cc6a0756b05 < 85f)
		{
			array[0] = x9b41425268471380;
			array[1] = x5d9526c9d39aeeb2.x128319556e0855e3(x9b41425268471380, 85f);
			array[2] = x5d9526c9d39aeeb2.x128319556e0855e3(x9b41425268471380, 170f);
		}
		else if (x5d9526c9d39aeeb.x8e8f6cc6a0756b05 < 170f)
		{
			array[0] = x5d9526c9d39aeeb2.x128319556e0855e3(x9b41425268471380, -85f);
			array[1] = x9b41425268471380;
			array[2] = x5d9526c9d39aeeb2.x128319556e0855e3(x9b41425268471380, 85f);
		}
		else
		{
			array[0] = x5d9526c9d39aeeb2.x128319556e0855e3(x9b41425268471380, -170f);
			array[1] = x5d9526c9d39aeeb2.x128319556e0855e3(x9b41425268471380, -85f);
			array[2] = x9b41425268471380;
		}
		return array;
	}
}
