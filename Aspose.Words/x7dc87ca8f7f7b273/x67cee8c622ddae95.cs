using System.IO;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;

namespace x7dc87ca8f7f7b273;

internal class x67cee8c622ddae95 : xf51865b83a7a0b3b
{
	private readonly x48cb59b8ec3b78c9 xc1a30145b295d273;

	private readonly xd878af0d0717b77a x8cedcaa9a62c6e39;

	private readonly x833cdf314c9b989b x80f57697b4c811e9;

	public x67cee8c622ddae95(Stream stream, xbc9dfa2bfc69713d options)
	{
		x8cedcaa9a62c6e39 = new xd878af0d0717b77a(new x3c74b3c4f21844f9(stream, options.x953b08b2c4ae3d24), options);
		x80f57697b4c811e9 = new x833cdf314c9b989b(x8cedcaa9a62c6e39);
		xc1a30145b295d273 = new x48cb59b8ec3b78c9(options.xafc42de38a25321a);
		if (!x0d299f323d241756.x5959bccb67bbf051(options.xda77249ca2dc4984))
		{
			x80f57697b4c811e9.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, x3959df40367ac8a3.x6b60f7630a7ba83e, "Resources folder is not specified. Resources will be embedded into the SVG file.");
		}
	}

	public void x9b9ed0109b743e3b()
	{
		x80f57697b4c811e9.x9b9ed0109b743e3b();
	}

	public void xa0dfc102c691b11f()
	{
		x80f57697b4c811e9.xa0dfc102c691b11f();
	}

	public void xe406325e56f74b46(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		xda5bf54deb817e37.Accept(this);
	}

	public override void VisitPageStart(xc67adcdbca121a26 page)
	{
		x80f57697b4c811e9.x804b2039ae4e9b33(page);
	}

	public override void VisitPageEnd(xc67adcdbca121a26 page)
	{
		x80f57697b4c811e9.xa0cf4a18229be519();
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		x80f57697b4c811e9.x5c96e27b059805fe.xfb4a02d17cf55f9b(canvas);
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		x80f57697b4c811e9.x5c96e27b059805fe.xd23c6c9fd3a6fa74(canvas);
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		x80f57697b4c811e9.x5c96e27b059805fe.x9e85ecf25cca82ee(path);
	}

	public override void VisitPathEnd(xab391c46ff9a0a38 path)
	{
		x80f57697b4c811e9.x5c96e27b059805fe.x8e20e5f3afd31049();
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		x80f57697b4c811e9.x5c96e27b059805fe.xd6b2549ca8b77560(glyphs);
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		image = image.x9214b18190604b0d(this, xc1a30145b295d273, xac51bc46b01ec35d: false);
		if (image != null)
		{
			x80f57697b4c811e9.x5c96e27b059805fe.xb0eb947f93ab7675(image);
		}
	}

	public override void VisitBookmark(x9a66d03de2ff27e1 bookmark)
	{
		x80f57697b4c811e9.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x42daab0e7e499260, x3959df40367ac8a3.x6b60f7630a7ba83e, "Bookmarks are not supported by SVG renderer yet.");
	}
}
