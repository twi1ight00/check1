using x1c8faa688b1f0b0c;
using x6c95d9cf46ff5f25;
using xa7850104c8d8c135;
using xfc5388ad7dff404f;

namespace xaf73fad8cede26de;

internal class x8ffc07717f2f315f : xf51865b83a7a0b3b, x2da3d38c09108f49
{
	private readonly x48cb59b8ec3b78c9 xc1a30145b295d273;

	private readonly xe965bada78e2d6b1 x7e24ae8042d3886b;

	private readonly xdce638a96bf2f54f x7b181c5102029720;

	private string xa1b6127f243e7e06;

	public xe965bada78e2d6b1 x39c7aeeec1af9dd0 => x7e24ae8042d3886b;

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

	public x8ffc07717f2f315f(xfaf91ffd88d78c15 info, x26efbcdc713eaa49 options)
	{
		x7e24ae8042d3886b = new xe965bada78e2d6b1();
		x7b181c5102029720 = new xdce638a96bf2f54f(x7e24ae8042d3886b, options);
		x7b181c5102029720.xb444c09fa044bbca = info;
		xc1a30145b295d273 = new x48cb59b8ec3b78c9(options.xafc42de38a25321a);
	}

	public void xe406325e56f74b46(x4fdf549af9de6b97 xda5bf54deb817e37)
	{
		xda5bf54deb817e37.Accept(this);
	}

	public void xa0dfc102c691b11f()
	{
		x7b181c5102029720.xb0882cca5e6880d3();
	}

	public override void VisitPageStart(xc67adcdbca121a26 page)
	{
		x7b181c5102029720.x804b2039ae4e9b33(page.xdc1bf80853046136, page.xb0f146032f47c24e);
		x7b181c5102029720.x0f61a94153870e81(page.x437e3b626c0fdd43);
	}

	public override void VisitPageEnd(xc67adcdbca121a26 page)
	{
		x7b181c5102029720.xa0cf4a18229be519();
	}

	public override void VisitCanvasStart(xb8e7e788f6d59708 canvas)
	{
		x7b181c5102029720.x38f1a5c6c8faf5b1.xfb4a02d17cf55f9b(canvas);
	}

	public override void VisitCanvasEnd(xb8e7e788f6d59708 canvas)
	{
		x7b181c5102029720.x38f1a5c6c8faf5b1.xd23c6c9fd3a6fa74();
	}

	public override void VisitGlyphs(xcc8c7739d82c63ba glyphs)
	{
		x7b181c5102029720.x38f1a5c6c8faf5b1.x99f8d80c87f330aa(glyphs);
	}

	public override void VisitPathStart(xab391c46ff9a0a38 path)
	{
		x7b181c5102029720.x38f1a5c6c8faf5b1.x9e85ecf25cca82ee(path);
	}

	public override void VisitPathEnd(xab391c46ff9a0a38 path)
	{
		x7b181c5102029720.x38f1a5c6c8faf5b1.x8e20e5f3afd31049();
	}

	public override void VisitImage(x72c34b8dbaec3734 image)
	{
		image = image.x9214b18190604b0d(this, xc1a30145b295d273, xac51bc46b01ec35d: false);
		if (image != null)
		{
			x7b181c5102029720.x38f1a5c6c8faf5b1.xb0eb947f93ab7675(image);
		}
	}

	public override void VisitBookmark(x9a66d03de2ff27e1 bookmark)
	{
		x7b181c5102029720.x7db09d025a6abf05(bookmark);
	}

	public override void VisitOutlineItem(x2e5b68a308682b82 outlineItem)
	{
		x7b181c5102029720.x4f1c165c82126a3e(outlineItem);
	}

	public x54b98d0096d7251a x4d2cf6c77ee521cd()
	{
		if (x7b181c5102029720.x73979cef1002ed01 == null || x7b181c5102029720.x73979cef1002ed01.x4d2cf6c77ee521cd() == null)
		{
			return x8694a2e0856b3478.x9834ddb0e0bd5996;
		}
		return x7b181c5102029720.x73979cef1002ed01.x4d2cf6c77ee521cd();
	}
}
