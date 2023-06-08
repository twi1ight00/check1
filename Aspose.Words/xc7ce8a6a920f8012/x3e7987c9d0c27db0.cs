using System.Drawing.Drawing2D;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace xc7ce8a6a920f8012;

internal class x3e7987c9d0c27db0 : x0096796e2eb81db6
{
	public x3e7987c9d0c27db0(x34b34bf589d8ec1e context)
		: base(context)
	{
	}

	public void xd2adeaddbd02b4c6(xcc8c7739d82c63ba x199c511544621683, short xbe4a60d4d01e2087)
	{
		if (x199c511544621683.xf09329ffe2ab2695 != x26d9ecb4bdf0456d.x45260ad4b94166f2)
		{
			base.x28fcdc775a1d069c.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, $"Rendering of Outlined and Embossed text is not supported upon exporting to SWF. Text will be rendered as normal text. Page {base.x28fcdc775a1d069c.x380e1d313f1dca54}.");
		}
		xb4e6bcae51300e9c xb4e6bcae51300e9c2 = new xb4e6bcae51300e9c(base.x28fcdc775a1d069c);
		xb4e6bcae51300e9c2.xacf4b9ddf32bef06();
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(xbe4a60d4d01e2087);
		base.x5aa326f374b3d0ef.xe62552de84356436(x4574ea26106f0edb.x88bf16f2386d633e(x199c511544621683.x6ae4612a8469678e.Left), x4574ea26106f0edb.x88bf16f2386d633e(x199c511544621683.x6ae4612a8469678e.Right), x4574ea26106f0edb.x88bf16f2386d633e(x199c511544621683.x6ae4612a8469678e.Top), x4574ea26106f0edb.x88bf16f2386d633e(x199c511544621683.x6ae4612a8469678e.Bottom));
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.xce92de628aa023cf(x4574ea26106f0edb.x88bf16f2386d633e(x199c511544621683.xc22eade24b085d91.X), x4574ea26106f0edb.x88bf16f2386d633e(x199c511544621683.xc22eade24b085d91.Y), MatrixOrder.Prepend);
		base.x5aa326f374b3d0ef.x215d2a6f35e16d24(x54366fa5f75a02f);
		x6b1a899052c71a60 x29f65b3e7616f6b = x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3;
		x6ba9063ea0f44561 x6ba9063ea0f44562 = base.x28fcdc775a1d069c.x5fa376febd884803(x29f65b3e7616f6b);
		xd8cce4761dc846ee xd8cce4761dc846ee = new xd8cce4761dc846ee();
		xd8cce4761dc846ee xd8cce4761dc846ee2 = new xd8cce4761dc846ee();
		foreach (int item in new x115139807e6482f7(x199c511544621683.Text))
		{
			int xbcea506a33cf = x6ba9063ea0f44562.x5810605ff8268f75(item);
			xd8cce4761dc846ee.xd6b6ed77479ef68c(xbcea506a33cf);
			xd8cce4761dc846ee2.xd6b6ed77479ef68c(x6ba9063ea0f44562.xa56be56d48dd0980(item, x199c511544621683.xc2d4efc42998d87b.x53531537bb3331e6));
		}
		int num = x5a224cf027b1ffd9.xa639cb4b0a05e97c(xd8cce4761dc846ee.x543681a74a4a8026());
		int num2 = x5a224cf027b1ffd9.xa639cb4b0a05e97c(xd8cce4761dc846ee2.x543681a74a4a8026());
		base.x5aa326f374b3d0ef.xc351d479ff7ee789((byte)num);
		base.x5aa326f374b3d0ef.xc351d479ff7ee789((byte)num2);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(1, 1, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(0, 3, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(1, 1, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(1, 1, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(0, 1, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(0, 1, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be(base.x28fcdc775a1d069c.x4a59854a1bae262a(x29f65b3e7616f6b));
		base.x5aa326f374b3d0ef.x374f83392c7b16a3(x199c511544621683.x9b41425268471380);
		base.x5aa326f374b3d0ef.xab5f6b7526efa5be((short)x4574ea26106f0edb.x88bf16f2386d633e(x199c511544621683.xc2d4efc42998d87b.x53531537bb3331e6));
		base.x5aa326f374b3d0ef.xc351d479ff7ee789((byte)xd8cce4761dc846ee.xd44988f225497f3a);
		for (int i = 0; i < xd8cce4761dc846ee.xd44988f225497f3a; i++)
		{
			base.x5aa326f374b3d0ef.xbd9d4226f381e56d(xd8cce4761dc846ee.get_xe6d4b1b411ed94b5(i), num, xde809bbd71bb692c: false);
			base.x5aa326f374b3d0ef.x4402da7591062ad7(xd8cce4761dc846ee2.get_xe6d4b1b411ed94b5(i), num2, xde809bbd71bb692c: false);
		}
		base.x5aa326f374b3d0ef.xbd9d4226f381e56d(0, 8, xde809bbd71bb692c: false);
		base.x5aa326f374b3d0ef.xbb7550bbb62a218c();
		xb4e6bcae51300e9c2.xc463dec5a3ab6e2d(xf066f1f57515a14c.x74356b972241671e);
	}
}
