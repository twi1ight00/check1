using System.IO;
using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;

namespace xe8a881d5eff3c473;

internal class x7fcf08d8ade7229c : xf51865b83a7a0b3b, x2da3d38c09108f49
{
	private x54b98d0096d7251a xa056586c1f99e199;

	private readonly xd057c4220d6d5ace x46f46603045c5537;

	private string xa1b6127f243e7e06;

	private readonly x48cb59b8ec3b78c9 xc1a30145b295d273;

	public xfaf91ffd88d78c15 xb444c09fa044bbca => x46f46603045c5537.xb444c09fa044bbca;

	public string xa6eb8bfffefdfca0
	{
		get
		{
			return xa1b6127f243e7e06;
		}
		set
		{
			xa1b6127f243e7e06 = value;
		}
	}

	public x7fcf08d8ade7229c(Stream outputStream, string resourcesFolderPath, string resourcesFolderAlias, x54b98d0096d7251a warningCallback)
	{
		xe1be84fa0dab2c38(warningCallback);
		x46f46603045c5537 = new xd057c4220d6d5ace(outputStream, resourcesFolderPath, resourcesFolderAlias, warningCallback);
		xc1a30145b295d273 = new x48cb59b8ec3b78c9(new x6edb191c4eaef585());
	}

	public void xe406325e56f74b46(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		xda5bf54deb817e37.Accept(this);
	}

	public void xa0dfc102c691b11f()
	{
		x46f46603045c5537.xb0882cca5e6880d3();
	}

	public override void VisitPageStart(xc67adcdbca121a26 page)
	{
		x46f46603045c5537.x804b2039ae4e9b33(page.xdc1bf80853046136, page.xb0f146032f47c24e);
	}

	public override void VisitPageEnd(xc67adcdbca121a26 page)
	{
		x46f46603045c5537.xa0cf4a18229be519();
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		x46f46603045c5537.x38f1a5c6c8faf5b1.xfb4a02d17cf55f9b(canvas);
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		x46f46603045c5537.x38f1a5c6c8faf5b1.xd23c6c9fd3a6fa74();
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		x46f46603045c5537.x38f1a5c6c8faf5b1.x99f8d80c87f330aa(glyphs);
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		x46f46603045c5537.x38f1a5c6c8faf5b1.x9e85ecf25cca82ee(path);
	}

	public override void VisitPathEnd(xab391c46ff9a0a38 path)
	{
		x46f46603045c5537.x38f1a5c6c8faf5b1.x8e20e5f3afd31049();
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		image = image.x9214b18190604b0d(this, xc1a30145b295d273, xac51bc46b01ec35d: false);
		if (image != null)
		{
			x46f46603045c5537.x38f1a5c6c8faf5b1.xb0eb947f93ab7675(image);
		}
	}

	public override void VisitBookmark(x9a66d03de2ff27e1 bookmark)
	{
		x46f46603045c5537.x7db09d025a6abf05(bookmark);
	}

	public x54b98d0096d7251a x4d2cf6c77ee521cd()
	{
		if (xa056586c1f99e199 == null)
		{
			xa056586c1f99e199 = x8694a2e0856b3478.x9834ddb0e0bd5996;
		}
		return xa056586c1f99e199;
	}

	public void xe1be84fa0dab2c38(x54b98d0096d7251a xbcea506a33cf9111)
	{
		xa056586c1f99e199 = xbcea506a33cf9111;
	}
}
