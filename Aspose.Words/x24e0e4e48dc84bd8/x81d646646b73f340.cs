using System.Drawing;
using System.Drawing.Drawing2D;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x85732faf56f7825d;
using xa7850104c8d8c135;
using xf9a9481c3f63a419;

namespace x24e0e4e48dc84bd8;

internal class x81d646646b73f340
{
	private readonly x4e88096751fad171 xd995695f8e3419d6;

	private readonly SizeF x3b77a41bd57164d6;

	private x22be4efc841bf970 x2c14065e28457333;

	private xb8e7e788f6d59708 x7a8a30505eb89f6e;

	private readonly xba4efa2f947ea057 x3d4b1a1699f2d6a4 = new xba4efa2f947ea057();

	private xf45d779c93b84127 xa8548d289a49a30a;

	public x22be4efc841bf970 x7862da8b83f1b6b8 => x2c14065e28457333;

	public xb8e7e788f6d59708 x5fe28c2b4826581d
	{
		get
		{
			RectangleF xee6354c7044d841a = xd995695f8e3419d6.x4aca0559c9e6ddc0.xee6354c7044d841a;
			float m = x3b77a41bd57164d6.Width / xee6354c7044d841a.Width;
			float m2 = x3b77a41bd57164d6.Height / xee6354c7044d841a.Height;
			x7a8a30505eb89f6e.x52dde376accdec7d = new x54366fa5f75a02f7(m, 0f, 0f, m2, 0f, 0f);
			x7a8a30505eb89f6e.x52dde376accdec7d.xce92de628aa023cf(0f - xee6354c7044d841a.X, 0f - xee6354c7044d841a.Y, MatrixOrder.Prepend);
			x7a8a30505eb89f6e.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(xee6354c7044d841a);
			return x7a8a30505eb89f6e;
		}
	}

	public x81d646646b73f340(x4e88096751fad171 serviceLocator, SizeF size)
	{
		xd995695f8e3419d6 = serviceLocator;
		x3b77a41bd57164d6 = size;
		x2c14065e28457333 = new x22be4efc841bf970();
		xa8548d289a49a30a = new xf45d779c93b84127(serviceLocator.x4aca0559c9e6ddc0.xee6354c7044d841a);
		x959ddd5eb23fcbe1(x26d9ecb4bdf0456d.x66d844daa6e9f181);
	}

	public void xa9d636b00ff486b7(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		x959ddd5eb23fcbe1(x6c50a99faab7d741);
	}

	private void x959ddd5eb23fcbe1(x26d9ecb4bdf0456d x824bfb65f06865bd)
	{
		x7a8a30505eb89f6e = new xb8e7e788f6d59708();
		if (!(x824bfb65f06865bd == x26d9ecb4bdf0456d.x66d844daa6e9f181))
		{
			x3fa09e8d7b952fbc x4aca0559c9e6ddc = xd995695f8e3419d6.x4aca0559c9e6ddc0;
			RectangleF xee6354c7044d841a = x4aca0559c9e6ddc.xee6354c7044d841a;
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(xee6354c7044d841a);
			xab391c46ff9a0a.x60465f602599d327 = new xc020fa2f5133cba8(x824bfb65f06865bd);
			x7a8a30505eb89f6e.xd6b6ed77479ef68c(xab391c46ff9a0a);
		}
	}

	public void x42b847293bd729a1()
	{
		xa8548d289a49a30a.x74f5a1ef3906e23c();
	}

	public void x201332625b9cb8f0(RectangleF x26545669838eb36e, CombineMode xa4aa8b4150b11435)
	{
		x3ba89ef66ec1bfc3(new Region(x26545669838eb36e), xa4aa8b4150b11435);
	}

	public void xd08421bb72c7313a(int x1b17d2598850aa3a, CombineMode xa4aa8b4150b11435)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = (xab391c46ff9a0a38)xd995695f8e3419d6.x9deec9457dc2451d.x38758cbbee49e4cb(x1b17d2598850aa3a);
		if (xab391c46ff9a0a != null)
		{
			x5250236f9cf73045 x5250236f9cf = new x5250236f9cf73045();
			xab391c46ff9a0a.Accept(x5250236f9cf);
			x3ba89ef66ec1bfc3(new Region(x5250236f9cf.x588bacbaa0ed1589), xa4aa8b4150b11435);
		}
	}

	public void x3ba89ef66ec1bfc3(int x5f821c736ab57440, CombineMode xa4aa8b4150b11435)
	{
		Region region = (Region)xd995695f8e3419d6.x9deec9457dc2451d.x38758cbbee49e4cb(x5f821c736ab57440);
		if (region != null)
		{
			x3ba89ef66ec1bfc3(region.Clone(), xa4aa8b4150b11435);
		}
	}

	private void x3ba89ef66ec1bfc3(Region xa4d52e34b62b5495, CombineMode xa4aa8b4150b11435)
	{
		xa4d52e34b62b5495.Transform(x2f9dbabfc5e5ed3e.xc675a307f114fa9b(x7862da8b83f1b6b8.x1e9acba06e394dcb));
		xa8548d289a49a30a.x3ba89ef66ec1bfc3(xa4d52e34b62b5495, xa4aa8b4150b11435);
	}

	public void x35f14820eeee9fe9(SizeF x374ea4fe62468d0f)
	{
		PointF pointF = x7862da8b83f1b6b8.x1e9acba06e394dcb.x5c785f1d561da269(new PointF(x374ea4fe62468d0f.Width, x374ea4fe62468d0f.Height));
		xa8548d289a49a30a.xf1d9b91c9700c401(new SizeF(pointF.X, pointF.Y));
	}

	public void x51d3a13ecd447601(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		if (xda5bf54deb817e37 != null)
		{
			xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
			xb8e7e788f6d.x0e1bf8242ad10272 = xa8548d289a49a30a.x385638247aa8a54b;
			xb8e7e788f6d59708 xb8e7e788f6d2 = new xb8e7e788f6d59708();
			xb8e7e788f6d2.x52dde376accdec7d = x2c14065e28457333.x1e9acba06e394dcb.x8b61531c8ea35b85();
			xb8e7e788f6d2.xd6b6ed77479ef68c(xda5bf54deb817e37);
			xb8e7e788f6d.xd6b6ed77479ef68c(xb8e7e788f6d2);
			x7a8a30505eb89f6e.xd6b6ed77479ef68c(xb8e7e788f6d);
		}
	}

	public void xbb4d4033cbf2c7fd(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		if (x08ce8f4769eb3234 != null)
		{
			x7a8a30505eb89f6e.xd6b6ed77479ef68c(x08ce8f4769eb3234);
		}
	}

	public void x0acd3c2012ea2ee8(int x0c131de6e4b13692)
	{
		x1dd7d14b42118378 x01b557925841ae = x44290d9c6946562d(x0c131de6e4b13692);
		x3d4b1a1699f2d6a4.xd6b6ed77479ef68c(x01b557925841ae);
	}

	public void x53fe2787f0b104c4(int x0c131de6e4b13692)
	{
		x1dd7d14b42118378 x01b557925841ae = x3d4b1a1699f2d6a4.x52b190e626f65140(x0c131de6e4b13692);
		x4590a664d199dd54(x01b557925841ae);
	}

	public void x655e2ab738dffef0(int x0c131de6e4b13692)
	{
		x1dd7d14b42118378 x01b557925841ae = x44290d9c6946562d(x0c131de6e4b13692);
		x3d4b1a1699f2d6a4.xd6b6ed77479ef68c(x01b557925841ae);
	}

	public void x655e2ab738dffef0(RectangleF x6b8e154b42d5c1e3, RectangleF x50a18ad2656e7181, int x0c131de6e4b13692)
	{
		x1dd7d14b42118378 x01b557925841ae = x44290d9c6946562d(x0c131de6e4b13692);
		x3d4b1a1699f2d6a4.xd6b6ed77479ef68c(x01b557925841ae);
	}

	public void x72d23433127b2d3b(int x0c131de6e4b13692)
	{
		x1dd7d14b42118378 x1dd7d14b42118379 = x3d4b1a1699f2d6a4.x52b190e626f65140(x0c131de6e4b13692);
		if (x1dd7d14b42118379 != null)
		{
			x4590a664d199dd54(x1dd7d14b42118379);
		}
	}

	private x1dd7d14b42118378 x44290d9c6946562d(int xed3d312606d106cd)
	{
		return new x1dd7d14b42118378(xa8548d289a49a30a, x2c14065e28457333, xed3d312606d106cd);
	}

	private void x4590a664d199dd54(x1dd7d14b42118378 x01b557925841ae51)
	{
		xa8548d289a49a30a = x01b557925841ae51.x0e1bf8242ad10272;
		x2c14065e28457333 = x01b557925841ae51.x7862da8b83f1b6b8;
	}
}
