using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using Aspose;
using Aspose.Words;
using Aspose.Words.Drawing;
using x06e283fdfa5dc5f0;
using x1c8faa688b1f0b0c;
using x3d94286fe72124a8;
using x4adf554d20d941a6;
using x5794c252ba25e723;
using x59d6a4fc5007b7a4;
using x6c95d9cf46ff5f25;
using x99ec507695f2d4ff;

namespace x6a42c37b95e9caa1;

internal class xfef22f4f866de8d2 : x3adba2572f6b9747
{
	private xe6a5f3ec802a6d51 x8cedcaa9a62c6e39;

	private x42b8c317113a56e4 x62e280b088d57187;

	private x5f887a65c13f569c xf57f277d65880c0b;

	private x5f887a65c13f569c x3816b1884c53915b;

	private readonly Stack x174cf9ef5947435d = new Stack();

	private static readonly x26d9ecb4bdf0456d xd02ea656b74333b3 = x26d9ecb4bdf0456d.xe3a106a4c00973e3;

	private static readonly x26d9ecb4bdf0456d xe53ef85266994b62 = x26d9ecb4bdf0456d.x50a7f8950dee0ba8;

	private static readonly x26d9ecb4bdf0456d x48d8d088ae2834fa = x26d9ecb4bdf0456d.xe7c87f797bb4b411;

	private static readonly x26d9ecb4bdf0456d xa15af169147d94c0 = x26d9ecb4bdf0456d.x46d2ee2a363fa637;

	private static readonly x26d9ecb4bdf0456d x49a3bb42d27913c4 = x26d9ecb4bdf0456d.x23d6043fb9c177ec;

	private x6442cfb56f7b4491 x936b4c49e9109527;

	private x5f887a65c13f569c xa7e9fdc58a02d814 => (x5f887a65c13f569c)x174cf9ef5947435d.Peek();

	internal xe6a5f3ec802a6d51 x28fcdc775a1d069c => x8cedcaa9a62c6e39;

	internal xfef22f4f866de8d2()
	{
		x936b4c49e9109527 = new x6442cfb56f7b4491(this);
	}

	internal xc67adcdbca121a26 xe406325e56f74b46(xdcf47a8f1807f37c x32eaf67d0ee57cb7, xdeb77ea37ad74c56 x1e972e751678e682)
	{
		xc67adcdbca121a26 xc67adcdbca121a = new xc67adcdbca121a26(x4574ea26106f0edb.xc96d70553223ee04(x32eaf67d0ee57cb7.xa65184d44a47025b.x56933a86bfcf89a1()), x32eaf67d0ee57cb7.xa65184d44a47025b.xef64f56541986736);
		x8cedcaa9a62c6e39 = new xe6a5f3ec802a6d51(xc67adcdbca121a, x1e972e751678e682);
		Shape backgroundShape = x32eaf67d0ee57cb7.x2c8c6741422a1298.BackgroundShape;
		bool flag = backgroundShape?.Filled ?? false;
		Shading shading = null;
		if (flag)
		{
			shading = new Shading();
			shading.BackgroundPatternColor = backgroundShape.FillColor;
			x8cedcaa9a62c6e39.x00149f2495b0f026(shading);
		}
		x62e280b088d57187 = new x42b8c317113a56e4(x8cedcaa9a62c6e39);
		xf57f277d65880c0b = new x5f887a65c13f569c(x9ec6ce5404580fa7.xfdc1a17f479acc42);
		x3816b1884c53915b = new x5f887a65c13f569c(x9ec6ce5404580fa7.xa65184d44a47025b);
		x398b3bd0acd94b61.x6fac24024cd1bb39(x32eaf67d0ee57cb7.x9fb0e9c0b1bdc4b3);
		x32eaf67d0ee57cb7.x7012609bcdb39574(this);
		if (flag)
		{
			x8cedcaa9a62c6e39.xbcd358ebb8d4e95e();
		}
		return xc67adcdbca121a;
	}

	internal bool x858a27249691845d(xdcf47a8f1807f37c xbbe2f7d7c86e0379)
	{
		if (xbbe2f7d7c86e0379.x53a759df62a20324)
		{
			return !x8cedcaa9a62c6e39.xdeb77ea37ad74c56.xc0f5f6c50d2e3575;
		}
		return false;
	}

	internal override void xb657ee9ee2ce188a(xdcf47a8f1807f37c xbbe2f7d7c86e0379)
	{
		if (x858a27249691845d(xbbe2f7d7c86e0379))
		{
			x8cedcaa9a62c6e39.xd53690ab1592eec8(new PointF(0f, 0f));
		}
		x8096ed1677306b4d.x144a519b89660993(xbbe2f7d7c86e0379, x8cedcaa9a62c6e39);
		x1740478edaeaa566 xde931fb7c0e6373a = xbbe2f7d7c86e0379.xde931fb7c0e6373a;
		if (xde931fb7c0e6373a != null && !xde931fb7c0e6373a.xca170eff54278d9b)
		{
			xc0438d6974ed8b39(xde931fb7c0e6373a);
		}
		if (x858a27249691845d(xbbe2f7d7c86e0379))
		{
			x936b4c49e9109527.x7d146f9a953b4c96(xbbe2f7d7c86e0379);
		}
	}

	internal override void x0d9fe863128f7451(xdcf47a8f1807f37c xbbe2f7d7c86e0379)
	{
		x1740478edaeaa566 xde931fb7c0e6373a = xbbe2f7d7c86e0379.xde931fb7c0e6373a;
		if (xde931fb7c0e6373a != null && xde931fb7c0e6373a.xca170eff54278d9b)
		{
			xc0438d6974ed8b39(xde931fb7c0e6373a);
		}
		if (x858a27249691845d(xbbe2f7d7c86e0379))
		{
			x936b4c49e9109527.xa096b947452fa2d4(xbbe2f7d7c86e0379);
		}
		if (!x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x999996a7e5332e5e.x7149c962c02931b3)
		{
			x8cedcaa9a62c6e39.xee63d905da8ff550(new RectangleF(xbbe2f7d7c86e0379.x72d92bd1aff02e37, xbbe2f7d7c86e0379.xe360b1885d8d4a41, xbbe2f7d7c86e0379.xdc1bf80853046136, xbbe2f7d7c86e0379.xb0f146032f47c24e), x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x999996a7e5332e5e);
		}
		if (x858a27249691845d(xbbe2f7d7c86e0379))
		{
			xb8e7e788f6d59708 xb8e7e788f6d = (xb8e7e788f6d59708)x8cedcaa9a62c6e39.xc255c495fd9232ca;
			xb8e7e788f6d.x52dde376accdec7d = xbbe2f7d7c86e0379.xaccac17571a8d9fa;
			x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
		}
	}

	private void xc0438d6974ed8b39(x1740478edaeaa566 x54eba7ef49aa14a1)
	{
		if (x54eba7ef49aa14a1 != null)
		{
			x3816b1884c53915b.xc28dff9f03c0d48f();
			x3816b1884c53915b.xb1e2c9a68308ad60(x54eba7ef49aa14a1.x007986b943c7e3cf, x54eba7ef49aa14a1.x92e7e5f35452590d, x54eba7ef49aa14a1.x0924cade9dc2d296, x54eba7ef49aa14a1.x9d329a00f2c534a8, x54eba7ef49aa14a1.x3903fbc9023c861c);
			x3816b1884c53915b.xb0770b4ea658e78d(x8cedcaa9a62c6e39);
		}
	}

	internal override void x8ed9c1094d826c2f(x512b9a381ad7cd9c x89effcb726ec92db)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = x8cedcaa9a62c6e39.xd53690ab1592eec8(x89effcb726ec92db.xc22eade24b085d91);
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x89effcb726ec92db.x0e1bf8242ad10272);
	}

	internal override void xd367b0854e02449e(x512b9a381ad7cd9c x89effcb726ec92db)
	{
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
	}

	internal override void x81b05dc513830622(xc6ae5bf3fc6721e2 xe3e287548b3d01f5)
	{
		x8cedcaa9a62c6e39.xd53690ab1592eec8(xe3e287548b3d01f5.xc22eade24b085d91);
	}

	internal override void x8ebf847d0a00f979(xc6ae5bf3fc6721e2 xe3e287548b3d01f5)
	{
		xf57f277d65880c0b.xb0770b4ea658e78d(x8cedcaa9a62c6e39);
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
		if (!xe3e287548b3d01f5.xe74b2c668179aa09.IsEmpty)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(new PointF(xe3e287548b3d01f5.xe74b2c668179aa09.X, xe3e287548b3d01f5.xe360b1885d8d4a41), new PointF(xe3e287548b3d01f5.xe74b2c668179aa09.X, xe3e287548b3d01f5.xe360b1885d8d4a41 + xe3e287548b3d01f5.xe74b2c668179aa09.Height));
			xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
			x8cedcaa9a62c6e39.x1fa9148f6731ff24(xab391c46ff9a0a);
		}
	}

	internal override void xdfc9ad174ecab9eb(xb850ecb8335a2e09 xd3311d815ca25f02)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = x8cedcaa9a62c6e39.xd53690ab1592eec8(xd3311d815ca25f02.xc22eade24b085d91);
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(xd3311d815ca25f02.x0e1bf8242ad10272);
		if (xd3311d815ca25f02.xaccac17571a8d9fa != null)
		{
			xb8e7e788f6d.x52dde376accdec7d = xd3311d815ca25f02.xaccac17571a8d9fa;
		}
	}

	internal override void x3bd3c50d2c5e3ad7(xb850ecb8335a2e09 xd3311d815ca25f02)
	{
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
	}

	internal override void xa5ea669db02dc54a(x24007e5c985fb52a x6b0ad9f73c48ad53)
	{
		xb8e7e788f6d59708 xb8e7e788f6d = x8cedcaa9a62c6e39.xd53690ab1592eec8(x6b0ad9f73c48ad53.xc22eade24b085d91);
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x6b0ad9f73c48ad53.x0e1bf8242ad10272);
	}

	internal override void xd5a9dc0e56d9d1fb(x24007e5c985fb52a x6b0ad9f73c48ad53)
	{
		xf57f277d65880c0b.xb0770b4ea658e78d(x8cedcaa9a62c6e39);
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
	}

	internal override void xdfec5ca48512842a(xa68c54b19fa2b58c x1ec770899c98a268)
	{
		x8cedcaa9a62c6e39.xd53690ab1592eec8(x1ec770899c98a268.xc22eade24b085d91);
		x174cf9ef5947435d.Push(new x5f887a65c13f569c(x9ec6ce5404580fa7.x25af49e7b49ea0bc));
	}

	internal override void xcad591cb7cc7b3be(xa68c54b19fa2b58c x1ec770899c98a268)
	{
		xa7e9fdc58a02d814.xb0770b4ea658e78d(x8cedcaa9a62c6e39);
		x174cf9ef5947435d.Pop();
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
	}

	[JavaConvertCheckedExceptions]
	internal override void x81181dae89c9ea13(xe4d6d8acaf4e81ea xa806b754814b9ae0)
	{
		if (xa806b754814b9ae0.x3224fba74054513c)
		{
			xb8e7e788f6d59708 x4bbd18967c469fa = xa806b754814b9ae0.x4bbd18967c469fa1;
			x8cedcaa9a62c6e39.x1fa9148f6731ff24(x4bbd18967c469fa);
			ArrayList xa955664f4f50999d = new ArrayList();
			x694f001896973fe3 x694f001896973fe = (x694f001896973fe3)xa806b754814b9ae0.x9fb0e9c0b1bdc4b3;
			x398b3bd0acd94b61 x8b8a0a04b3aeaf3a = x694f001896973fe.x838c6c67b5953bb0.x133f2db9e5b5690d.x5d6d04c35215bc51.x8b8a0a04b3aeaf3a;
			x3557aa8566455ba9.xd4a05df1ad040932(x8b8a0a04b3aeaf3a, xa955664f4f50999d, x4729f6e0bbe03396: false, x59c6d00e0898f6b8: true, xa7e9fdc58a02d814);
			float num = x4574ea26106f0edb.xc96d70553223ee04(x694f001896973fe.xc821290d7ecc08bf);
			xa7e9fdc58a02d814.x9e19f5bd0a6dd5b7(0f, 0f - num);
		}
		x8cedcaa9a62c6e39.xd53690ab1592eec8(xa806b754814b9ae0.xc22eade24b085d91);
		xa7e9fdc58a02d814.xc28dff9f03c0d48f();
	}

	internal override void xd0fe4ce66ef350ed(xe4d6d8acaf4e81ea xa806b754814b9ae0)
	{
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
	}

	internal override void x0d919b3be4833815(xb2b9d43291f4067d xe6de5e5fa2d44af5)
	{
		if (xe6de5e5fa2d44af5.x6b476d1cf3ec3a3d)
		{
			x8cedcaa9a62c6e39.x00149f2495b0f026(xe6de5e5fa2d44af5.x554aca059bdf6d48);
			RectangleF x8d3e220b8546945e = xe6de5e5fa2d44af5.x8d3e220b8546945e;
			x3bc42b548f62bdca.xa4520be1beb8f046(x8d3e220b8546945e, xe6de5e5fa2d44af5.x554aca059bdf6d48, x8cedcaa9a62c6e39);
		}
		xb8e7e788f6d59708 xb8e7e788f6d = x8cedcaa9a62c6e39.xd53690ab1592eec8(xe6de5e5fa2d44af5.xc22eade24b085d91);
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(xe6de5e5fa2d44af5.x0e1bf8242ad10272);
		if (xe6de5e5fa2d44af5.x01bc5527a261f633 && xe6de5e5fa2d44af5.x6b476d1cf3ec3a3d)
		{
			xb8e7e788f6d = x8cedcaa9a62c6e39.xd53690ab1592eec8(PointF.Empty);
			xb8e7e788f6d.x52dde376accdec7d = xe6de5e5fa2d44af5.x11db8fc7f469a2fc.xa228a56c1d2f69ff(xb8e7e788f6d.x52dde376accdec7d, xac64a29018fe64e7: false);
		}
	}

	[JavaConvertCheckedExceptions]
	internal override void x67c463ab8a7d7a8e(xb2b9d43291f4067d xe6de5e5fa2d44af5)
	{
		if (xe6de5e5fa2d44af5.x01bc5527a261f633 && xe6de5e5fa2d44af5.x6b476d1cf3ec3a3d)
		{
			x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
		}
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
		if (xe6de5e5fa2d44af5.xb12567c8f0a05a2b)
		{
			x02cfd28b22f47a16(xa7e9fdc58a02d814, xe6de5e5fa2d44af5.x11db8fc7f469a2fc, x4729f6e0bbe03396: false);
		}
		if (xe6de5e5fa2d44af5.x6b476d1cf3ec3a3d)
		{
			x8cedcaa9a62c6e39.xbcd358ebb8d4e95e();
		}
		x0b2a5d4600726325(xe6de5e5fa2d44af5);
	}

	private void x0b2a5d4600726325(xb2b9d43291f4067d xe6de5e5fa2d44af5)
	{
		if (xe6de5e5fa2d44af5.xe6f52e090163d45e == x526c0da08ed0e498.xc922d5cb05b5c111)
		{
			x86accec882b7012a shared = xa6c6ed003f022075.x63b337e5b91d5f83(xe6de5e5fa2d44af5.x11db8fc7f469a2fc, x85eafb71f618c3ae: false);
			xb2b9d43291f4067d xb2b9d43291f4067d = new xb2b9d43291f4067d(shared, xe6de5e5fa2d44af5.x11db8fc7f469a2fc);
			xb2b9d43291f4067d.x7012609bcdb39574(this);
		}
	}

	[Conditional("DEBUG")]
	private void x43a151013475cd66(xb2b9d43291f4067d xe6de5e5fa2d44af5)
	{
		if (!x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x5a0288a81a20d0c2.x7149c962c02931b3)
		{
			x8cedcaa9a62c6e39.xee63d905da8ff550(xb2b9d43291f4067d.x04a13814ebb01700(xe6de5e5fa2d44af5.x11db8fc7f469a2fc), x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x5a0288a81a20d0c2);
		}
	}

	[Conditional("DEBUG")]
	private void x1c54324f7baa65e9(xb2b9d43291f4067d xe6de5e5fa2d44af5)
	{
		if (!x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x9eaabe76cf8eea16.x7149c962c02931b3)
		{
			x8cedcaa9a62c6e39.xee63d905da8ff550(xa3a992e8cf81dabe.xb525df69a6e7d8ef(xe6de5e5fa2d44af5.x11db8fc7f469a2fc, x39df78691dbb02b2: true), x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x9eaabe76cf8eea16);
		}
	}

	[Conditional("DEBUG")]
	private void x0376396cbe476bf0(xb850ecb8335a2e09 xb919f78f3ecb289c)
	{
		if (x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x86e1531584718ad3.x7149c962c02931b3)
		{
			return;
		}
		Rectangle x26545669838eb36e = new Rectangle(0, 0, xb919f78f3ecb289c.x9fb0e9c0b1bdc4b3.xdc1bf80853046136, xb919f78f3ecb289c.x9fb0e9c0b1bdc4b3.xb0f146032f47c24e);
		xd4c1d21f07094800 xd4c1d21f = ((xb919f78f3ecb289c.x9fb0e9c0b1bdc4b3 is xc7f90d9c7c51cede) ? ((xc7f90d9c7c51cede)xb919f78f3ecb289c.x9fb0e9c0b1bdc4b3).xf9d5944b191eb276(x5aa7d09b258e0f23: false) : ((x86accec882b7012a)xb919f78f3ecb289c.x9fb0e9c0b1bdc4b3).xf9d5944b191eb276(x5aa7d09b258e0f23: false));
		if (xd4c1d21f != null && xd4c1d21f.xd44988f225497f3a > 0)
		{
			for (int i = 0; i < xd4c1d21f.xd44988f225497f3a; i++)
			{
				x109e3389933c23a8 x109e3389933c23a = xd4c1d21f.xaadb22af27962896(i);
				Rectangle xf671230c49fb86ad = x109e3389933c23a.x3a116ea4a0f97ab2(x26545669838eb36e);
				RectangleF x26545669838eb36e2 = x4574ea26106f0edb.xc96d70553223ee04(xf671230c49fb86ad);
				x8cedcaa9a62c6e39.xee63d905da8ff550(x26545669838eb36e2, x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x86e1531584718ad3);
				x26545669838eb36e2 = x4574ea26106f0edb.xc96d70553223ee04(x109e3389933c23a.x6ae4612a8469678e);
				x8cedcaa9a62c6e39.xee63d905da8ff550(x26545669838eb36e2, x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x86e1531584718ad3);
			}
		}
	}

	internal static void x02cfd28b22f47a16(x5f887a65c13f569c xcd4ea23e1c937019, x86accec882b7012a xb4144741a65a3e9a, bool x4729f6e0bbe03396)
	{
		RectangleF xdc901b9828d8600c = xb2b9d43291f4067d.x04a13814ebb01700(xb4144741a65a3e9a);
		Border xcf4d59ab018ff9c = (x4729f6e0bbe03396 ? x3557aa8566455ba9.x9f6bbfd6a9013899(xc8e01097217ac9d2.x66f2271ac271c2df) : null);
		xcd4ea23e1c937019.xb1e2c9a68308ad60(xdc901b9828d8600c, xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Left, xcf4d59ab018ff9c), xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Right, xcf4d59ab018ff9c), xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Top, xcf4d59ab018ff9c), xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Bottom, xcf4d59ab018ff9c));
	}

	private static ArrayList x65afe16d1469539e(x56b4eac69b5fa65b x2612f62f94df47de, int xa82bacd86ccf8ff9)
	{
		xe20e20657f464768 x768f9befb545345a = x2612f62f94df47de.x838c6c67b5953bb0.x768f9befb545345a;
		ArrayList arrayList = new ArrayList();
		int[] x03bb6a33fcd217b = x2612f62f94df47de.x838c6c67b5953bb0.x133f2db9e5b5690d.x03bb6a33fcd217b4;
		int num;
		int num2;
		if (0 > xa82bacd86ccf8ff9)
		{
			if (0 >= x768f9befb545345a.x0364c07ad4dcfe0c)
			{
				return arrayList;
			}
			num = 0;
			num2 = x768f9befb545345a.x0364c07ad4dcfe0c;
		}
		else if (0 < xa82bacd86ccf8ff9)
		{
			if (0 >= x768f9befb545345a.x851fcfc17df82b1b)
			{
				return arrayList;
			}
			num = x03bb6a33fcd217b.Length - x768f9befb545345a.x851fcfc17df82b1b;
			num2 = x03bb6a33fcd217b.Length;
		}
		else
		{
			int x6e1eb96b81362ebc = x2612f62f94df47de.xdfd0c9de0b4aa96a.x6e1eb96b81362ebc;
			num = x2612f62f94df47de.xa8c2682cb8534de2();
			num2 = num + x6e1eb96b81362ebc;
		}
		for (int i = num; i < num2; i++)
		{
			arrayList.Add(x03bb6a33fcd217b[i]);
		}
		return arrayList;
	}

	private static Border x0a7976f64c28949e(x86accec882b7012a xb4144741a65a3e9a, int xa82bacd86ccf8ff9, int xc0c4c459c6ccbd00, int x10f4d88af727adbc, BorderType xe6e655492739f7d2, Border xcf4d59ab018ff9c4)
	{
		if (0 > xa82bacd86ccf8ff9)
		{
			return x6bd4e337d4083595(xb4144741a65a3e9a, xc0c4c459c6ccbd00, x10f4d88af727adbc, xe6e655492739f7d2, xcf4d59ab018ff9c4);
		}
		if (0 < xa82bacd86ccf8ff9)
		{
			return x07fe9d2b9015137d(xb4144741a65a3e9a, xc0c4c459c6ccbd00, x10f4d88af727adbc, xe6e655492739f7d2, xcf4d59ab018ff9c4);
		}
		switch (xe6e655492739f7d2)
		{
		case BorderType.Top:
			return xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Top, xcf4d59ab018ff9c4);
		case BorderType.Bottom:
			return xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Bottom, xcf4d59ab018ff9c4);
		case BorderType.Left:
			if (0 < xc0c4c459c6ccbd00)
			{
				return Border.x45260ad4b94166f2;
			}
			return xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Left, xcf4d59ab018ff9c4);
		case BorderType.Right:
			if (x10f4d88af727adbc - 1 > xc0c4c459c6ccbd00)
			{
				return Border.x45260ad4b94166f2;
			}
			return xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Right, xcf4d59ab018ff9c4);
		default:
			throw x1b8f3b5ba0f906d9(xe6e655492739f7d2);
		}
	}

	private static Border x6bd4e337d4083595(x86accec882b7012a xb4144741a65a3e9a, int xc0c4c459c6ccbd00, int x10f4d88af727adbc, BorderType xe6e655492739f7d2, Border xcf4d59ab018ff9c4)
	{
		x56b4eac69b5fa65b xc5464084edc8e = xb4144741a65a3e9a.xc5464084edc8e226;
		switch (xe6e655492739f7d2)
		{
		case BorderType.Left:
			return Border.x45260ad4b94166f2;
		case BorderType.Right:
			if (x10f4d88af727adbc - 1 < xc0c4c459c6ccbd00)
			{
				return xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Left, xcf4d59ab018ff9c4);
			}
			return Border.x45260ad4b94166f2;
		case BorderType.Top:
			if (!xc5464084edc8e.x838c6c67b5953bb0.xc0e56f2fca892328)
			{
				if (xc0c4c459c6ccbd00 >= xc5464084edc8e.x838c6c67b5953bb0.xc22e54d85f137f3e.x768f9befb545345a.x0364c07ad4dcfe0c)
				{
					return xb2b9d43291f4067d.x9f6bbfd6a9013899((x86accec882b7012a)xc5464084edc8e.x838c6c67b5953bb0.xc22e54d85f137f3e.x96ac59f61797f5b9.x8b8a0a04b3aeaf3a, BorderType.Bottom, xcf4d59ab018ff9c4);
				}
				return Border.x45260ad4b94166f2;
			}
			return Border.x45260ad4b94166f2;
		case BorderType.Bottom:
			if (!xc5464084edc8e.x838c6c67b5953bb0.x55b6066f30988caf)
			{
				if (xc0c4c459c6ccbd00 >= xc5464084edc8e.x838c6c67b5953bb0.xebb8ac1152da9a1f.x768f9befb545345a.x0364c07ad4dcfe0c)
				{
					return xb2b9d43291f4067d.x9f6bbfd6a9013899((x86accec882b7012a)xc5464084edc8e.x838c6c67b5953bb0.xebb8ac1152da9a1f.x96ac59f61797f5b9.x8b8a0a04b3aeaf3a, BorderType.Top, xcf4d59ab018ff9c4);
				}
				return Border.x45260ad4b94166f2;
			}
			return Border.x45260ad4b94166f2;
		default:
			throw x1b8f3b5ba0f906d9(xe6e655492739f7d2);
		}
	}

	private static Border x07fe9d2b9015137d(x86accec882b7012a xb4144741a65a3e9a, int xc0c4c459c6ccbd00, int x10f4d88af727adbc, BorderType xe6e655492739f7d2, Border xcf4d59ab018ff9c4)
	{
		x56b4eac69b5fa65b xc5464084edc8e = xb4144741a65a3e9a.xc5464084edc8e226;
		switch (xe6e655492739f7d2)
		{
		case BorderType.Left:
			if (0 >= xc0c4c459c6ccbd00)
			{
				return xb2b9d43291f4067d.x9f6bbfd6a9013899(xb4144741a65a3e9a, BorderType.Right, xcf4d59ab018ff9c4);
			}
			return Border.x45260ad4b94166f2;
		case BorderType.Right:
			return Border.x45260ad4b94166f2;
		case BorderType.Top:
			if (!xc5464084edc8e.x838c6c67b5953bb0.xc0e56f2fca892328)
			{
				if (x10f4d88af727adbc - xc0c4c459c6ccbd00 > xc5464084edc8e.x838c6c67b5953bb0.xc22e54d85f137f3e.x768f9befb545345a.x851fcfc17df82b1b)
				{
					return xb2b9d43291f4067d.x9f6bbfd6a9013899((x86accec882b7012a)xc5464084edc8e.x838c6c67b5953bb0.xc22e54d85f137f3e.xc1277af2cd8d654e.x2f5fd09b3d327fb0.x7e2e5dd40daabc3b, BorderType.Bottom, xcf4d59ab018ff9c4);
				}
				return Border.x45260ad4b94166f2;
			}
			return Border.x45260ad4b94166f2;
		case BorderType.Bottom:
			if (!xc5464084edc8e.x838c6c67b5953bb0.x55b6066f30988caf)
			{
				if (x10f4d88af727adbc - xc0c4c459c6ccbd00 > xc5464084edc8e.x838c6c67b5953bb0.xebb8ac1152da9a1f.x768f9befb545345a.x851fcfc17df82b1b)
				{
					return xb2b9d43291f4067d.x9f6bbfd6a9013899((x86accec882b7012a)xc5464084edc8e.x838c6c67b5953bb0.xebb8ac1152da9a1f.xc1277af2cd8d654e.x2f5fd09b3d327fb0.x8b8a0a04b3aeaf3a, BorderType.Top, xcf4d59ab018ff9c4);
				}
				return Border.x45260ad4b94166f2;
			}
			return Border.x45260ad4b94166f2;
		default:
			throw x1b8f3b5ba0f906d9(xe6e655492739f7d2);
		}
	}

	private static InvalidOperationException x1b8f3b5ba0f906d9(BorderType xe6e655492739f7d2)
	{
		return new InvalidOperationException("Unrecognized border type, " + xe6e655492739f7d2);
	}

	internal override void x6967be9680f35960(xbf5b03855bcdbdae x41baca1d6c0c2e8e)
	{
		x8cedcaa9a62c6e39.x00149f2495b0f026(x41baca1d6c0c2e8e.x554aca059bdf6d48);
		x3bc42b548f62bdca.xa4520be1beb8f046(x41baca1d6c0c2e8e.x8d3e220b8546945e, x41baca1d6c0c2e8e.x554aca059bdf6d48, x8cedcaa9a62c6e39);
		x8cedcaa9a62c6e39.xd53690ab1592eec8(x41baca1d6c0c2e8e.xc22eade24b085d91);
		if (x41baca1d6c0c2e8e.xa9e41271000a315a != null)
		{
			x2e5b68a308682b82 xda5bf54deb817e = new x2e5b68a308682b82(x8cedcaa9a62c6e39.xce92de628aa023cf(PointF.Empty), x41baca1d6c0c2e8e.xa9e41271000a315a.x504f3d4040b356d7, x41baca1d6c0c2e8e.xa9e41271000a315a.x238bf167ccfdd282);
			x8cedcaa9a62c6e39.x1fa9148f6731ff24(xda5bf54deb817e);
		}
	}

	internal override void x93c88bcdc9f7f32e(xbf5b03855bcdbdae x41baca1d6c0c2e8e)
	{
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
		float[] barTabPositions = x41baca1d6c0c2e8e.x8df6f6ca274123b0.GetBarTabPositions();
		x2f76d0659e896f61(barTabPositions, x41baca1d6c0c2e8e.xce1f19b805aa290d, x41baca1d6c0c2e8e.xa2a9e5b20ef4d76a);
		xca80992759df6ebf(x41baca1d6c0c2e8e);
		x8cedcaa9a62c6e39.xbcd358ebb8d4e95e();
		if (!x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x1a233f0af2b260c3.x7149c962c02931b3)
		{
			x8cedcaa9a62c6e39.xee63d905da8ff550(x41baca1d6c0c2e8e.x007986b943c7e3cf, x8cedcaa9a62c6e39.xdeb77ea37ad74c56.x1a233f0af2b260c3);
		}
	}

	private void x2f76d0659e896f61(float[] x1692a49b2cba9274, float xc941868c59399d3e, float x4d5aabc7a55b12ba)
	{
		for (int i = 0; i < x1692a49b2cba9274.Length; i++)
		{
			x8cedcaa9a62c6e39.x1fa9148f6731ff24(x35a0f05c914a4e0b(x1692a49b2cba9274[i], xc941868c59399d3e, x4d5aabc7a55b12ba));
		}
	}

	internal static xab391c46ff9a0a38 x35a0f05c914a4e0b(float x08db3aeabb253cb1, float x1e218ceaee1bb583, float x4d5aabc7a55b12ba)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(new PointF(x08db3aeabb253cb1, x1e218ceaee1bb583), new PointF(x08db3aeabb253cb1, x1e218ceaee1bb583 + x4d5aabc7a55b12ba));
		xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x26d9ecb4bdf0456d.x89fffa2751fdecbe);
		return xab391c46ff9a0a;
	}

	private void xca80992759df6ebf(xbf5b03855bcdbdae x41baca1d6c0c2e8e)
	{
		if (x41baca1d6c0c2e8e.xd356018c23fff3be)
		{
			xf57f277d65880c0b.xc28dff9f03c0d48f();
			xf57f277d65880c0b.xb1e2c9a68308ad60(x41baca1d6c0c2e8e.xc95b376fd068d3cb, x41baca1d6c0c2e8e.x92e7e5f35452590d, x41baca1d6c0c2e8e.x0924cade9dc2d296, x41baca1d6c0c2e8e.x9d329a00f2c534a8, x41baca1d6c0c2e8e.x3903fbc9023c861c);
			if (!x41baca1d6c0c2e8e.x11e2cd24a3b67965)
			{
				xf57f277d65880c0b.xb0770b4ea658e78d(x8cedcaa9a62c6e39);
			}
		}
		else
		{
			xf57f277d65880c0b.xb0770b4ea658e78d(x8cedcaa9a62c6e39);
		}
	}

	internal override void xd5d8ece01511f314(x6a53cec2ada67e5c x311e7a92306d7199)
	{
		x62e280b088d57187.x7c922a3d2390ec27(x311e7a92306d7199);
	}

	internal override void x3d7ea625bef846bf(x6a53cec2ada67e5c x311e7a92306d7199)
	{
		x62e280b088d57187.x2c033959922f72a9();
	}

	internal override void x5e3c9e6ae8d36dd1(xcd3694ded987e19d x5906905c888d3d98)
	{
		x62e280b088d57187.xe04b5d7c28160175(x5906905c888d3d98);
	}

	internal override void xaa9ea643e6d66d7b(x96fdc2b3abde93b1 x5906905c888d3d98)
	{
		x62e280b088d57187.xa2007eb3b6f579d9(x5906905c888d3d98);
	}

	internal override void x093532051f31f9ab(x740374357407832e x5906905c888d3d98)
	{
		x62e280b088d57187.xb5cf8dd3ac6ab11c(x5906905c888d3d98);
	}

	internal override void x76f324df3b49ece0(xfb07b2a80e43c2cc x5906905c888d3d98)
	{
		x62e280b088d57187.xbb61f83f3bddaa5d(x5906905c888d3d98);
	}

	internal override void x9773fd96b36022c0(xb43a47dbe11ef8fb x5906905c888d3d98)
	{
		x62e280b088d57187.x39f76dcf47c1d43c(x5906905c888d3d98);
	}

	internal override void x371451abcd43de03(xa7492065dee59ad0 x5906905c888d3d98)
	{
		x62e280b088d57187.x6352d2f80acb683d(x5906905c888d3d98);
	}

	internal override void x8f7209e6e174fc25(xc7b875b517342f11 x5906905c888d3d98)
	{
		if (x5906905c888d3d98.x83f9d074410e5abf)
		{
			x62e280b088d57187.x3e1fd9da6cf38edc(x5906905c888d3d98);
		}
	}

	internal override void xeb3f33fe08e9a2e6(x988c1cad471a514c x5906905c888d3d98)
	{
		x62e280b088d57187.x5f35398aa06d0b48(x5906905c888d3d98);
	}
}
