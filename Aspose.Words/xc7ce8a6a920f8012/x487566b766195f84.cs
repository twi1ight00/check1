using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;
using xf9a9481c3f63a419;

namespace xc7ce8a6a920f8012;

internal class x487566b766195f84 : xf51865b83a7a0b3b, x2da3d38c09108f49
{
	private const long x1bb9cd7d97e4db7d = 4L;

	private const long xce9ec4ed38f6fbbc = 19L;

	private Stream xa49cef274042e702;

	private x34b34bf589d8ec1e x8cedcaa9a62c6e39;

	private Stack x1e8b6a441b5d8b9a = new Stack();

	private x54366fa5f75a02f7 xe09feaeccf7d7b04 = new x54366fa5f75a02f7();

	private readonly x48cb59b8ec3b78c9 xc1a30145b295d273;

	private xfaf91ffd88d78c15 x730a3c5f4afd73ef = new xfaf91ffd88d78c15();

	public x487566b766195f84(Stream stream, xfaf91ffd88d78c15 documentInfo, xf62f848e5d3ba660 options)
	{
		xa49cef274042e702 = stream;
		x8cedcaa9a62c6e39 = new x34b34bf589d8ec1e(new MemoryStream(), options);
		x730a3c5f4afd73ef = documentInfo;
		xc1a30145b295d273 = new x48cb59b8ec3b78c9(new x6edb191c4eaef585());
		x9b9ed0109b743e3b();
		xe09feaeccf7d7b04.x5152a5707921c783(20f, 20f, MatrixOrder.Prepend);
	}

	public void xe406325e56f74b46(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		xda5bf54deb817e37.Accept(this);
	}

	private void x9b9ed0109b743e3b()
	{
		x8687279c7d43171f x8687279c7d43171f2 = new x8687279c7d43171f(x8cedcaa9a62c6e39);
		x8687279c7d43171f2.x6210059f049f0d48(x8cedcaa9a62c6e39.x73979cef1002ed01.xaf09b1a5e6d60a5c);
		x62b1771a2c353a76 x62b1771a2c353a77 = new x62b1771a2c353a76(x8cedcaa9a62c6e39);
		x62b1771a2c353a77.xd303545b208f5d95();
		x5b8b330ef272c8c0 x5b8b330ef272c8c = new x5b8b330ef272c8c0(x8cedcaa9a62c6e39);
		x5b8b330ef272c8c.xb957ffdf5627f75a(x730a3c5f4afd73ef);
		if (x8cedcaa9a62c6e39.x73979cef1002ed01.x50d413fba889b359)
		{
			x8cedcaa9a62c6e39.x5aa326f374b3d0ef.x4c116b70372a3c6d(xac4ff1047b721aff.xbaeb8b895cf26378);
			x8cedcaa9a62c6e39.x887ee4cb0bd0448c();
		}
	}

	public void xa0dfc102c691b11f()
	{
		x8cedcaa9a62c6e39.x304b6d4b7f054ae1(x8cedcaa9a62c6e39.x73979cef1002ed01.x50d413fba889b359);
		x8cedcaa9a62c6e39.x5aa326f374b3d0ef.x4eadf767e5f91a38(xf066f1f57515a14c.x9fd888e65466818c, 0);
		Stream baseStream = x8cedcaa9a62c6e39.x5aa326f374b3d0ef.x7fdc1bfc45368624.BaseStream;
		baseStream.Position = 4L;
		x8cedcaa9a62c6e39.x5aa326f374b3d0ef.x6ff7c65ed4805c27((int)baseStream.Length);
		baseStream.Position = 19L;
		x8cedcaa9a62c6e39.x5aa326f374b3d0ef.xab5f6b7526efa5be((short)(x8cedcaa9a62c6e39.x09ed8d79c4ca4609.Count + (x8cedcaa9a62c6e39.x73979cef1002ed01.x50d413fba889b359 ? 2 : 0)));
		baseStream.Position = 0L;
		if (x8cedcaa9a62c6e39.x73979cef1002ed01.xaf09b1a5e6d60a5c)
		{
			x97bfffd6ed87777f(baseStream);
		}
		else
		{
			x0d299f323d241756.x3ad8e53785c39acd(baseStream, xa49cef274042e702);
		}
	}

	public override void VisitPageStart(xc67adcdbca121a26 page)
	{
		short num = x8cedcaa9a62c6e39.xa315ee2085b502cf();
		x8cedcaa9a62c6e39.x804b2039ae4e9b33(num, page.x437e3b626c0fdd43);
		xfaa0b71704009335 xfaa0b717040093352 = new xfaa0b71704009335(x8cedcaa9a62c6e39, num);
		x1574602d66ef8f7c(xfaa0b717040093352);
		xfaa0b71704009335 xfaa0b717040093353 = new xfaa0b71704009335(x8cedcaa9a62c6e39, x8cedcaa9a62c6e39.xa315ee2085b502cf());
		x1574602d66ef8f7c(xfaa0b717040093353);
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e.xb90eeef3d2a5a96b(new RectangleF(0f, 0f, page.xdc1bf80853046136, page.xb0f146032f47c24e));
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		xab391c46ff9a0a38 xab391c46ff9a0a2 = xab391c46ff9a0a.x8b61531c8ea35b85();
		xab391c46ff9a0a2.x60465f602599d327 = new xc020fa2f5133cba8(x26d9ecb4bdf0456d.x8f02f53f1587477d);
		short x9780d7c271345d = x8cedcaa9a62c6e39.x5c96e27b059805fe.x9f280d9f6d9d4ccb(xab391c46ff9a0a2);
		xfaa0b717040093352.x1fa9148f6731ff24(x9780d7c271345d, xe09feaeccf7d7b04, "", x4fc602f6d6f4c1ca: false);
		x1d306e43fba3ac78(xab391c46ff9a0a, xe09feaeccf7d7b04, xfaa0b717040093352);
		xfaa0b717040093352.x1fa9148f6731ff24(xfaa0b717040093353.xde89252455da1b3c, xe09feaeccf7d7b04, null);
	}

	public override void VisitPageEnd(xc67adcdbca121a26 page)
	{
		x8cedcaa9a62c6e39.x5c96e27b059805fe.x12acf473349bbd57(xa4b2062e20d34756());
		xfaa0b71704009335 xfaa0b717040093352 = xa4b2062e20d34756();
		if (x8cedcaa9a62c6e39.x73979cef1002ed01.xc2e1b0b1bf7219c5)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
			x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
			x1cab6af0a41b70e.xb90eeef3d2a5a96b(new RectangleF(0f, 0f, page.xdc1bf80853046136, page.xb0f146032f47c24e));
			x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
			xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
			xab391c46ff9a0a.x60465f602599d327 = new xc020fa2f5133cba8(x26d9ecb4bdf0456d.x45260ad4b94166f2);
			xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(new xc020fa2f5133cba8(x26d9ecb4bdf0456d.x89fffa2751fdecbe), 1f);
			short x9780d7c271345d = x8cedcaa9a62c6e39.x5c96e27b059805fe.x9f280d9f6d9d4ccb(xab391c46ff9a0a);
			xfaa0b717040093352.x1fa9148f6731ff24(x9780d7c271345d, xe09feaeccf7d7b04, "", x4fc602f6d6f4c1ca: false);
		}
		x8cedcaa9a62c6e39.xa0cf4a18229be519(xfaa0b717040093352);
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		xfaa0b71704009335 xfaa0b717040093352 = x5c6a409acbb8e374();
		xfaa0b71704009335 xfaa0b717040093353 = new xfaa0b71704009335(x8cedcaa9a62c6e39, x8cedcaa9a62c6e39.xa315ee2085b502cf());
		if (canvas.x0e1bf8242ad10272 != null)
		{
			x1d306e43fba3ac78(canvas.x0e1bf8242ad10272, canvas.x52dde376accdec7d, xfaa0b717040093352);
		}
		string xc15bd84e = "";
		if (canvas.xc9bcfb2d9630b0c7 != null)
		{
			xc15bd84e = $"hyperlink{xfaa0b717040093353.xde89252455da1b3c}";
			x8cedcaa9a62c6e39.x5c96e27b059805fe.x3ca3595aa1a88d4b(xfaa0b717040093353.xde89252455da1b3c, canvas.xc9bcfb2d9630b0c7);
		}
		xfaa0b717040093352.x1fa9148f6731ff24(xfaa0b717040093353.xde89252455da1b3c, canvas.x52dde376accdec7d, xc15bd84e);
		x1574602d66ef8f7c(xfaa0b717040093353);
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		x8cedcaa9a62c6e39.x5c96e27b059805fe.x12acf473349bbd57(xa4b2062e20d34756());
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		xfaa0b71704009335 xfaa0b717040093352 = x5c6a409acbb8e374();
		short x9780d7c271345d = x8cedcaa9a62c6e39.x5c96e27b059805fe.x2037c969f8f81f97(glyphs);
		if (glyphs.xc9bcfb2d9630b0c7 != null)
		{
			xfaa0b717040093352 = x2fb14e6725f3bb43(glyphs.xc9bcfb2d9630b0c7, xfaa0b717040093352);
		}
		x54366fa5f75a02f7 x54366fa5f75a02f = ((glyphs.x52dde376accdec7d != null) ? glyphs.x52dde376accdec7d.x8b61531c8ea35b85() : new x54366fa5f75a02f7());
		if (glyphs.xc2d4efc42998d87b.xda4c813a32b9109b)
		{
			x54366fa5f75a02f.x490e30087768649f(glyphs.xa9563a23c5ad1dd4());
		}
		if (glyphs.xc2d4efc42998d87b.x30c7b3201d032345)
		{
			x86fdf284ee17a347(glyphs, x54366fa5f75a02f, xfaa0b717040093352);
		}
		x54366fa5f75a02f.x5152a5707921c783(0.05f, 0.05f, MatrixOrder.Prepend);
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e.xb90eeef3d2a5a96b(new RectangleF(glyphs.xc22eade24b085d91.X, glyphs.xc22eade24b085d91.Y - glyphs.xc2d4efc42998d87b.x53531537bb3331e6, glyphs.x6ae4612a8469678e.Width, glyphs.x6ae4612a8469678e.Height));
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		short x9780d7c271345d2 = x8cedcaa9a62c6e39.x5c96e27b059805fe.x9f280d9f6d9d4ccb(xab391c46ff9a0a);
		xfaa0b717040093352.x1fa9148f6731ff24(x9780d7c271345d2, new x54366fa5f75a02f7(), "", x4fc602f6d6f4c1ca: false);
		if (glyphs.x0e1bf8242ad10272 != null)
		{
			x1d306e43fba3ac78(glyphs.x0e1bf8242ad10272, glyphs.x52dde376accdec7d, xfaa0b717040093352);
		}
		xfaa0b717040093352.x1fa9148f6731ff24(x9780d7c271345d, x54366fa5f75a02f, "");
	}

	private void x86fdf284ee17a347(xcc8c7739d82c63ba x199c511544621683, x54366fa5f75a02f7 xf91891a03b29e0da, xfaa0b71704009335 x66407984f6827336)
	{
		float num = x199c511544621683.xc2d4efc42998d87b.x53531537bb3331e6 / 20480f;
		x6ba9063ea0f44561 x6ba9063ea0f44562 = x8cedcaa9a62c6e39.x5fa376febd884803(x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3);
		x6ba9063ea0f44562.x27872d02dfb99793(x199c511544621683.Text);
		float num2 = x199c511544621683.xc22eade24b085d91.X / num;
		foreach (int item in new x115139807e6482f7(x199c511544621683.Text))
		{
			if (item != 32)
			{
				xab391c46ff9a0a38 xab391c46ff9a0a = x6ba9063ea0f44562.x10801e6f4a897d62(item).x77be53ce49261911();
				xab391c46ff9a0a.x52dde376accdec7d = xf91891a03b29e0da.x8b61531c8ea35b85();
				xab391c46ff9a0a.x52dde376accdec7d.x5152a5707921c783(num, num, MatrixOrder.Prepend);
				xab391c46ff9a0a.x52dde376accdec7d.xce92de628aa023cf(num2, x199c511544621683.xc22eade24b085d91.Y / num, MatrixOrder.Prepend);
				xab391c46ff9a0a.x9e5d5f9128c69a8f = new x31c19fcb724dfaf5(x199c511544621683.x9b41425268471380, 819.19995f);
				xab391c46ff9a0a.x60465f602599d327 = new xc020fa2f5133cba8(x199c511544621683.x9b41425268471380);
				short x9780d7c271345d = x8cedcaa9a62c6e39.x5c96e27b059805fe.x9f280d9f6d9d4ccb(xab391c46ff9a0a);
				x66407984f6827336.x1fa9148f6731ff24(x9780d7c271345d, xab391c46ff9a0a.x52dde376accdec7d, "");
			}
			num2 += (float)x6ba9063ea0f44562.xa56be56d48dd0980(item);
		}
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		xfaa0b71704009335 xfaa0b717040093352 = x5c6a409acbb8e374();
		if (path.x0e1bf8242ad10272 != null)
		{
			x1d306e43fba3ac78(path.x0e1bf8242ad10272, path.x52dde376accdec7d, xfaa0b717040093352);
		}
		short x9780d7c271345d = x8cedcaa9a62c6e39.x5c96e27b059805fe.x9f280d9f6d9d4ccb(path);
		xfaa0b717040093352.x1fa9148f6731ff24(x9780d7c271345d, path.x52dde376accdec7d, "");
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		image = image.x9214b18190604b0d(this, xc1a30145b295d273, xac51bc46b01ec35d: false);
		if (image != null)
		{
			xa9557f69810d0afe(image);
		}
	}

	public override void VisitBookmark(x9a66d03de2ff27e1 bookmark)
	{
		x8cedcaa9a62c6e39.x94f739530d38cc0a(bookmark);
	}

	public override void VisitOutlineItem(x2e5b68a308682b82 outlineItem)
	{
		x8cedcaa9a62c6e39.xdac50776b1d359d8(outlineItem);
	}

	private void x97bfffd6ed87777f(Stream x085f9802af0e0fa6)
	{
		x5a224cf027b1ffd9 x5a224cf027b1ffd10 = new x5a224cf027b1ffd9(xa49cef274042e702);
		byte[] array = new byte[8];
		x085f9802af0e0fa6.Read(array, 0, array.Length);
		x5a224cf027b1ffd10.x4c116b70372a3c6d(array);
		byte[] array2 = new byte[(int)(x085f9802af0e0fa6.Length - array.Length)];
		x085f9802af0e0fa6.Read(array2, 0, array2.Length);
		byte[] x5cafa8d49ea71ea = xf1da3993f05a75b7.x575db3fedeadea6b(array2, x2e6ebe7013ab34b9.x1455a9a8b1cd9f39);
		x5a224cf027b1ffd10.x4c116b70372a3c6d(x5cafa8d49ea71ea);
	}

	private void xa9557f69810d0afe(x72c34b8dbaec3734 xe058541ca798c059)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e.xb90eeef3d2a5a96b(new RectangleF(0f, 0f, xe058541ca798c059.x437e3b626c0fdd43.Width, xe058541ca798c059.x437e3b626c0fdd43.Height));
		x1cab6af0a41b70e.x5e6c52cb3256cc85 = true;
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		xab391c46ff9a0a.x60465f602599d327 = xa903f8f328b4c169(xe058541ca798c059);
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(xe058541ca798c059.xc22eade24b085d91.X, xe058541ca798c059.xc22eade24b085d91.Y, MatrixOrder.Prepend);
		xfaa0b71704009335 xfaa0b717040093352 = x5c6a409acbb8e374();
		if (xe058541ca798c059.xc9bcfb2d9630b0c7 != null)
		{
			xfaa0b717040093352 = x2fb14e6725f3bb43(xe058541ca798c059.xc9bcfb2d9630b0c7, xfaa0b717040093352);
		}
		short x9780d7c271345d = x8cedcaa9a62c6e39.x5c96e27b059805fe.x9f280d9f6d9d4ccb(xab391c46ff9a0a);
		xfaa0b717040093352.x1fa9148f6731ff24(x9780d7c271345d, x54366fa5f75a02f, "");
	}

	private x5e9754e56a4f759f xa903f8f328b4c169(x72c34b8dbaec3734 xe058541ca798c059)
	{
		x5e9754e56a4f759f x5e9754e56a4f759f = new x5e9754e56a4f759f(xe058541ca798c059.xcc18177a965e0313);
		x5e9754e56a4f759f.x349ff0df1e641b4e = WrapMode.Clamp;
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		xa2745adfabe0c674 xa2745adfabe0c = xdd1b8f14cc8ba86d.x16a7fb03c627ebfb(xe058541ca798c059.xcc18177a965e0313);
		float xb5c369f64ea369e = xe058541ca798c059.x437e3b626c0fdd43.Width / (float)xa2745adfabe0c.xdc1bf80853046136;
		float x9b8af180a4e21ec = xe058541ca798c059.x437e3b626c0fdd43.Height / (float)xa2745adfabe0c.xb0f146032f47c24e;
		x54366fa5f75a02f.x5152a5707921c783(xb5c369f64ea369e, x9b8af180a4e21ec, MatrixOrder.Prepend);
		x5e9754e56a4f759f.xaccac17571a8d9fa = x54366fa5f75a02f;
		return x5e9754e56a4f759f;
	}

	private xfaa0b71704009335 x2fb14e6725f3bb43(xa702b771604efc86 xe0abc8f59346647b, xfaa0b71704009335 x66407984f6827336)
	{
		xfaa0b71704009335 xfaa0b717040093352 = new xfaa0b71704009335(x8cedcaa9a62c6e39, x8cedcaa9a62c6e39.xa315ee2085b502cf());
		x66407984f6827336.x1fa9148f6731ff24(xfaa0b717040093352.xde89252455da1b3c, new x54366fa5f75a02f7(), $"hyperlink{xfaa0b717040093352.xde89252455da1b3c}");
		x8cedcaa9a62c6e39.x5c96e27b059805fe.x3ca3595aa1a88d4b(xfaa0b717040093352.xde89252455da1b3c, xe0abc8f59346647b);
		x66407984f6827336 = xfaa0b717040093352;
		x8cedcaa9a62c6e39.x5c96e27b059805fe.x12acf473349bbd57(xfaa0b717040093352);
		return x66407984f6827336;
	}

	private void x1d306e43fba3ac78(xab391c46ff9a0a38 xd1cff1e8f8666dbe, x54366fa5f75a02f7 xf5d5967aadadb468, xfaa0b71704009335 x66407984f6827336)
	{
		short x9780d7c271345d = x8cedcaa9a62c6e39.x5c96e27b059805fe.x9f280d9f6d9d4ccb(xd1cff1e8f8666dbe);
		x54366fa5f75a02f7 x54366fa5f75a02f = ((xd1cff1e8f8666dbe.x52dde376accdec7d != null) ? xd1cff1e8f8666dbe.x52dde376accdec7d.x8b61531c8ea35b85() : new x54366fa5f75a02f7());
		if (xf5d5967aadadb468 != null)
		{
			x54366fa5f75a02f.x490e30087768649f(xf5d5967aadadb468, MatrixOrder.Prepend);
		}
		x66407984f6827336.x1fa9148f6731ff24(x9780d7c271345d, x54366fa5f75a02f, "", x4fc602f6d6f4c1ca: true);
	}

	private void x1574602d66ef8f7c(xfaa0b71704009335 xc68d1afbafbe71be)
	{
		x1e8b6a441b5d8b9a.Push(xc68d1afbafbe71be);
	}

	private xfaa0b71704009335 xa4b2062e20d34756()
	{
		return (xfaa0b71704009335)x1e8b6a441b5d8b9a.Pop();
	}

	private xfaa0b71704009335 x5c6a409acbb8e374()
	{
		return (xfaa0b71704009335)x1e8b6a441b5d8b9a.Peek();
	}

	public x54b98d0096d7251a x4d2cf6c77ee521cd()
	{
		return x8cedcaa9a62c6e39.x73979cef1002ed01.x4d2cf6c77ee521cd();
	}
}
