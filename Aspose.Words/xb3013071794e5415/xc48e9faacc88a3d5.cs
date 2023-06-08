using System;
using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x32a884d842a34446;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class xc48e9faacc88a3d5
{
	private int xb7e7b5935be29860;

	private float xd74c65b8d28b1740;

	private float x8918dc7c534575e5;

	private readonly float x62dc8cec5c087d49;

	private RectangleF x5df028e9306de021 = RectangleF.Empty;

	private PointF x03a5d38bfc2f6958 = PointF.Empty;

	private PointF x2d6530c18063ba2b = PointF.Empty;

	private PointF x63882224d9c68a0d = PointF.Empty;

	private readonly xb8e7e788f6d59708 x62a3395d374dccee;

	private readonly xcd7d6e7318ee6574 x8cedcaa9a62c6e39;

	private readonly xb7d17fc15d44a902 xdfc5c393fbd3cb54;

	private readonly RectangleF xcfb00db5f2a96790 = RectangleF.Empty;

	private readonly bool x173307fcb7b39e0e;

	private readonly ArrayList xb28afbb8d3db7f42 = new ArrayList();

	internal RectangleF xc49ca4c0d3cc766e => x5df028e9306de021;

	internal PointF x60e47f278f2e3258 => x03a5d38bfc2f6958;

	internal PointF xafbdb5baf173ebe2 => x2d6530c18063ba2b;

	internal PointF x1ec127a2b0d2b01c => x63882224d9c68a0d;

	internal float xdc1bf80853046136 => xd74c65b8d28b1740;

	internal float xb0f146032f47c24e => x8918dc7c534575e5;

	internal xe52a139d93fd6397 xbe1e23e7d5b43370
	{
		get
		{
			if (xdfc5c393fbd3cb54 != null)
			{
				return xdfc5c393fbd3cb54.x6e1ac924b90562d1;
			}
			return xe52a139d93fd6397.x4d0b9d4447ba7566;
		}
	}

	internal bool x3f5e31045e967a38
	{
		get
		{
			if (xdfc5c393fbd3cb54 != null)
			{
				return xdfc5c393fbd3cb54.x3f5e31045e967a38;
			}
			return false;
		}
	}

	internal bool xf386d5d7dae80a05 => x173307fcb7b39e0e;

	private xa4d912a00c540cf0 x0aa9ecee38d152a0
	{
		get
		{
			if (xdfc5c393fbd3cb54 == null)
			{
				return null;
			}
			return xdfc5c393fbd3cb54.xb7ae55095fddecd9;
		}
	}

	private bool xe0fa967e49e5e7e4
	{
		get
		{
			if (x0aa9ecee38d152a0 != null)
			{
				return false;
			}
			switch (xdfc5c393fbd3cb54.x6e1ac924b90562d1)
			{
			case xe52a139d93fd6397.x9bcb07e204e30218:
			case xe52a139d93fd6397.xe360b1885d8d4a41:
				return false;
			default:
				return true;
			}
		}
	}

	private x20020d13067f7a4e xf9ea3b8d9198b0cc
	{
		get
		{
			if (xb28afbb8d3db7f42.Count == 0)
			{
				xb28afbb8d3db7f42.Add(new x20020d13067f7a4e());
			}
			return (x20020d13067f7a4e)xb28afbb8d3db7f42[xb28afbb8d3db7f42.Count - 1];
		}
	}

	internal xc48e9faacc88a3d5(xd4e66257276c6905 chartSpace, xcd7d6e7318ee6574 context, RectangleF targetRect)
	{
		xdfc5c393fbd3cb54 = chartSpace.x317eef27d88d4cf9.xdd76c95ca663244c;
		x8cedcaa9a62c6e39 = context;
		x62a3395d374dccee = new xb8e7e788f6d59708();
		xcfb00db5f2a96790 = x318f74746d616ef0.x8dae03a2613b9b6c(targetRect, x0aa9ecee38d152a0, x8cedcaa9a62c6e39);
		x173307fcb7b39e0e = chartSpace.x317eef27d88d4cf9.x665038dfa8849161.x4cb4f5636323b916.Count == 1 && ((x958ddf7e6db1ce94)chartSpace.x317eef27d88d4cf9.x665038dfa8849161.x4cb4f5636323b916[0]).xc869533ad93d98d3.Count == 1;
		x62dc8cec5c087d49 = x318f74746d616ef0.xa9c9583c571d7dc3((xdfc5c393fbd3cb54 != null) ? xdfc5c393fbd3cb54.x68955bfadd010132 : new x4694a3400bb4849a(), x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
		xb7ae55095fddecd9(chartSpace);
	}

	internal void xe406325e56f74b46()
	{
		x62a3395d374dccee.x52dde376accdec7d = new x54366fa5f75a02f7();
		if (x0aa9ecee38d152a0 == null)
		{
			switch (xbe1e23e7d5b43370)
			{
			case xe52a139d93fd6397.x9bcb07e204e30218:
				x62a3395d374dccee.x52dde376accdec7d.xce92de628aa023cf((xcfb00db5f2a96790.X + xcfb00db5f2a96790.Width - xdc1bf80853046136) / 2f, xcfb00db5f2a96790.Y + xcfb00db5f2a96790.Height - xb0f146032f47c24e);
				break;
			case xe52a139d93fd6397.xe360b1885d8d4a41:
				x62a3395d374dccee.x52dde376accdec7d.xce92de628aa023cf((xcfb00db5f2a96790.X + xcfb00db5f2a96790.Width - xdc1bf80853046136) / 2f, xcfb00db5f2a96790.Y);
				break;
			case xe52a139d93fd6397.x72d92bd1aff02e37:
				x62a3395d374dccee.x52dde376accdec7d.xce92de628aa023cf(xcfb00db5f2a96790.X, (xcfb00db5f2a96790.Y + xcfb00db5f2a96790.Height - xb0f146032f47c24e) / 2f);
				break;
			case xe52a139d93fd6397.x46c964a11610fa46:
				x62a3395d374dccee.x52dde376accdec7d.xce92de628aa023cf(xcfb00db5f2a96790.X + xcfb00db5f2a96790.Width - xdc1bf80853046136, xcfb00db5f2a96790.Y);
				break;
			case xe52a139d93fd6397.x419ba17a5322627b:
				x62a3395d374dccee.x52dde376accdec7d.xce92de628aa023cf(xcfb00db5f2a96790.X + xcfb00db5f2a96790.Width - xdc1bf80853046136, (xcfb00db5f2a96790.Y + xcfb00db5f2a96790.Height - xb0f146032f47c24e) / 2f);
				break;
			}
		}
		else
		{
			x62a3395d374dccee.x52dde376accdec7d.xce92de628aa023cf(xcfb00db5f2a96790.X, xcfb00db5f2a96790.Y);
		}
		x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xd6b6ed77479ef68c(x62a3395d374dccee);
	}

	internal void xd7d75c376e5ae843(x4fdf549af9de6b97 x8f2400368d1c57d3, string xf1ada4e1b58a331d)
	{
		xe34702c565a0b0b9 xe34702c565a0b0b = xdfc5c393fbd3cb54.x17b0a2d8e345ae45(xb7e7b5935be29860);
		xb7e7b5935be29860++;
		if (xe34702c565a0b0b == null || !xe34702c565a0b0b.xddae736767606eb7)
		{
			xc55aeaa122dee548(xe34702c565a0b0b, xf1ada4e1b58a331d, x8f2400368d1c57d3);
		}
	}

	private void xb7ae55095fddecd9(xd4e66257276c6905 x02726bba19c4d190)
	{
		if (xdfc5c393fbd3cb54 != null)
		{
			xa7218a1d440266e7(x02726bba19c4d190);
			x2e9015b4fb9be7b7(x02726bba19c4d190);
			xf18a43f12d4269ae();
			x1fb76048d5430d2c();
		}
	}

	private void x2e9015b4fb9be7b7(xd4e66257276c6905 x02726bba19c4d190)
	{
		foreach (x958ddf7e6db1ce94 item in x02726bba19c4d190.x317eef27d88d4cf9.x665038dfa8849161.x4cb4f5636323b916)
		{
			item.x19858496179c0d1c(this, x8cedcaa9a62c6e39);
		}
	}

	private void xf18a43f12d4269ae()
	{
		foreach (x20020d13067f7a4e item in xb28afbb8d3db7f42)
		{
			xd74c65b8d28b1740 = Math.Max(xd74c65b8d28b1740, item.x437e3b626c0fdd43.Width);
			x8918dc7c534575e5 += item.x437e3b626c0fdd43.Height;
		}
		float num = 0f;
		if (x0aa9ecee38d152a0 != null)
		{
			if (xcfb00db5f2a96790.Height > x8918dc7c534575e5)
			{
				num = (xcfb00db5f2a96790.Height - x8918dc7c534575e5) / (float)xb28afbb8d3db7f42.Count;
			}
			xd74c65b8d28b1740 = xcfb00db5f2a96790.Width;
			x8918dc7c534575e5 = xcfb00db5f2a96790.Height;
		}
		float num2 = 0f;
		foreach (x20020d13067f7a4e item2 in xb28afbb8d3db7f42)
		{
			num2 += num / 2f;
			item2.x14e70d9e1d43117a.x52dde376accdec7d = new x54366fa5f75a02f7();
			item2.x14e70d9e1d43117a.x52dde376accdec7d.xce92de628aa023cf(0f, num2);
			x62a3395d374dccee.xd6b6ed77479ef68c(item2.x14e70d9e1d43117a);
			num2 += item2.x437e3b626c0fdd43.Height;
			num2 += num / 2f;
		}
	}

	private void x1fb76048d5430d2c()
	{
		RectangleF x26545669838eb36e = new RectangleF(0f, 0f, xdc1bf80853046136, xb0f146032f47c24e);
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
		x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, xdfc5c393fbd3cb54.xff13b489d81606b6, x8cedcaa9a62c6e39.x5e969e12ada2aab2.xdd76c95ca663244c, 0);
		x62a3395d374dccee.xef23aa45e7612fdd(0, xab391c46ff9a0a);
	}

	private void xc55aeaa122dee548(xe34702c565a0b0b9 xf748118c4d028e9f, string xf1ada4e1b58a331d, x4fdf549af9de6b97 x8f2400368d1c57d3)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xcc8c7739d82c63ba xcc8c7739d82c63ba = x36999da83cbe736e(xf748118c4d028e9f, xf1ada4e1b58a331d);
		xb8e7e788f6d.xd6b6ed77479ef68c(x8f2400368d1c57d3);
		xb8e7e788f6d.xd6b6ed77479ef68c(xcc8c7739d82c63ba);
		SizeF x6596328d88b6df5e = xa7a7db9283d71cb6(xcc8c7739d82c63ba);
		x20020d13067f7a4e x20020d13067f7a4e2 = xb45745acd93630be(x6596328d88b6df5e);
		x20020d13067f7a4e2.xd7d75c376e5ae843(xb8e7e788f6d, x6596328d88b6df5e);
	}

	private x20020d13067f7a4e xb45745acd93630be(SizeF x6596328d88b6df5e)
	{
		float num = xf9ea3b8d9198b0cc.x437e3b626c0fdd43.Width + x6596328d88b6df5e.Width - x62dc8cec5c087d49;
		if (xe0fa967e49e5e7e4 || (!xf9ea3b8d9198b0cc.x437e3b626c0fdd43.IsEmpty && num > xcfb00db5f2a96790.Size.Width))
		{
			xb28afbb8d3db7f42.Add(new x20020d13067f7a4e());
		}
		return xf9ea3b8d9198b0cc;
	}

	private xcc8c7739d82c63ba x36999da83cbe736e(xe34702c565a0b0b9 xf748118c4d028e9f, string xf1ada4e1b58a331d)
	{
		x4694a3400bb4849a x5d73ec97767a1b0c = ((xf748118c4d028e9f != null) ? xf748118c4d028e9f.x68955bfadd010132 : xdfc5c393fbd3cb54.x68955bfadd010132);
		float num = x318f74746d616ef0.xa9c9583c571d7dc3(x5d73ec97767a1b0c, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
		PointF x9c3c185e7046dc = new PointF(x5df028e9306de021.X + x5df028e9306de021.Width + x62dc8cec5c087d49 / 4f, (x62dc8cec5c087d49 - num) / 2f);
		return x318f74746d616ef0.x67e197bbfa6da21d(xf1ada4e1b58a331d, x9c3c185e7046dc, x5d73ec97767a1b0c, x8cedcaa9a62c6e39, x461bfa5b6ec21819: false);
	}

	private SizeF xa7a7db9283d71cb6(xcc8c7739d82c63ba xd1020a9db563b699)
	{
		float num = Math.Max(x62dc8cec5c087d49, x4574ea26106f0edb.x3aa08882c9feaf96(xd1020a9db563b699.x6ae4612a8469678e.Height));
		return new SizeF(xd1020a9db563b699.xc22eade24b085d91.X + (float)x4574ea26106f0edb.x3aa08882c9feaf96(xd1020a9db563b699.x6ae4612a8469678e.Width) + x62dc8cec5c087d49, num + x62dc8cec5c087d49 / 2f);
	}

	private void xa7218a1d440266e7(xd4e66257276c6905 x02726bba19c4d190)
	{
		float num = x62dc8cec5c087d49 * 0.6f;
		float num2 = num;
		float num3 = x62dc8cec5c087d49 * 0.4f;
		float num4 = num3;
		foreach (x958ddf7e6db1ce94 item in x02726bba19c4d190.x317eef27d88d4cf9.x665038dfa8849161.x4cb4f5636323b916)
		{
			switch (item.x13c22d4630b556cf)
			{
			case x8f04e4e6e23bd1f5.x75082347bbe6fbb0:
			case x8f04e4e6e23bd1f5.x6cd6caab5cff0e7a:
			case x8f04e4e6e23bd1f5.x44d15a8a22280ccd:
				num = x62dc8cec5c087d49 * 2f;
				break;
			case x8f04e4e6e23bd1f5.x43c013ec50029a74:
				if (((xeee90af555b475d2)item).xc08adeedaa9916be != 0)
				{
					num = x62dc8cec5c087d49 * 2f;
				}
				break;
			}
		}
		x5df028e9306de021 = new RectangleF(num4, num3, num, num2);
		float y = num3 + num2 / 2f;
		x03a5d38bfc2f6958 = new PointF(num4, y);
		x2d6530c18063ba2b = new PointF(num4 + num, y);
		x63882224d9c68a0d = new PointF(num4 + num / 2f, y);
	}
}
