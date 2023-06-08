using System.Drawing;
using x1c8faa688b1f0b0c;
using x8784bdb393e53e65;
using x8b1f7613579e78d0;
using xa769c310fbec8a5a;
using xb649d0eaa181773c;
using xe5b61ba6cfc93cea;
using xeb326c6285a77ac1;

namespace x996431aaaaf00543;

internal abstract class x162d67570d6be3e3 : x0a99c580c5be9824
{
	private x76628cd19dfc5c73 x122e6aca0ef08591;

	private x36c3925dc7ec8012 xf946812819fdb8f4;

	private xa66a49a54c0cb12b x5d9fbd9603e9dee5;

	private x78e18bdf9a108059 x435b26849f0d2436;

	public x76628cd19dfc5c73 x5d1f5ab5850c22b5
	{
		get
		{
			if (x122e6aca0ef08591 == null)
			{
				x122e6aca0ef08591 = new x76628cd19dfc5c73();
			}
			return x122e6aca0ef08591;
		}
		set
		{
			x122e6aca0ef08591 = value;
		}
	}

	public x36c3925dc7ec8012 x93e68a44438355fd
	{
		get
		{
			if (xf946812819fdb8f4 == null)
			{
				xf946812819fdb8f4 = new x0eb63046817e1a5c();
			}
			return xf946812819fdb8f4;
		}
		set
		{
			xf946812819fdb8f4 = value;
		}
	}

	public xa66a49a54c0cb12b xfe2178c1f916f36c
	{
		get
		{
			if (x5d9fbd9603e9dee5 == null)
			{
				x5d9fbd9603e9dee5 = new xa66a49a54c0cb12b();
			}
			return x5d9fbd9603e9dee5;
		}
		set
		{
			x5d9fbd9603e9dee5 = value;
		}
	}

	public override x78e18bdf9a108059 GetTransform()
	{
		if (x435b26849f0d2436 == null)
		{
			x435b26849f0d2436 = new x78e18bdf9a108059();
		}
		return x435b26849f0d2436;
	}

	public void x625c1e7700dd35e9(x78e18bdf9a108059 x678241938de24d81)
	{
		x435b26849f0d2436 = x678241938de24d81;
	}

	protected x687bd29facb7e34a x4c1a949e2d5fc9d0(x2094302a66c2ec77 x2f4d5d4fee2dfe29)
	{
		x8b545195dd56c1c7 x8b545195dd56c1c = new x8b545195dd56c1c7(this, x2f4d5d4fee2dfe29.xca687bd498227c89, xfe2178c1f916f36c);
		x8b545195dd56c1c.x6a1f9e96254c40aa = GetTransform().x2727839aafc09868;
		x8b545195dd56c1c.xa5f3a9472dfe822c = x2f4d5d4fee2dfe29.x1596f1cbbf3b4133;
		x8b545195dd56c1c.x1a31c5dbe3231791 = x2f4d5d4fee2dfe29.x968da130b40bd2b9;
		x8b545195dd56c1c.xaf2abb0b85eac4e2 = x2f4d5d4fee2dfe29.xd57fe9522fb6bc5a;
		return new x687bd29facb7e34a(GetTransform().xdc1bf80853046136, GetTransform().x1be93eed8950d961, x93e68a44438355fd, base.x6a81a30bcaf20a97, x8b545195dd56c1c, x5d1f5ab5850c22b5.x2639dfbfaf0930ee);
	}

	protected void x4ef42df82075df9e(x3c1460182f480df6 xe16d3243d6a3b9c3, xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		RectangleF x06b4849f65f5a9e = ((base.x332a8eedb847940d != null) ? base.x332a8eedb847940d.GetTransform().x2727839aafc09868 : GetTransform().x2727839aafc09868);
		x804c5bce88a9bb35 x804c5bce88a9bb = xe16d3243d6a3b9c3.x7aa7510ea77cbf15(x06b4849f65f5a9e);
		for (int i = 0; i < x08ce8f4769eb3234.xd44988f225497f3a; i++)
		{
			x4fdf549af9de6b97 x4fdf549af9de6b = ((xbaec545ec01f92ca)x08ce8f4769eb3234).get_xe6d4b1b411ed94b5(i);
			if (x4fdf549af9de6b != null && x4fdf549af9de6b is xab391c46ff9a0a38)
			{
				((xab391c46ff9a0a38)x4fdf549af9de6b).xaccac17571a8d9fa(x804c5bce88a9bb.x9bc1831bb7bbf0f7);
			}
		}
		x08ce8f4769eb3234.x52dde376accdec7d = x804c5bce88a9bb.x53c2efee610e1f9d;
	}
}
