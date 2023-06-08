using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using xeadd538cc90d42ab;
using xeb326c6285a77ac1;

namespace xb649d0eaa181773c;

internal class x76628cd19dfc5c73
{
	private readonly ArrayList xd5126346e5101136 = new ArrayList();

	private xd0098fb28618d8f9 x9c1f5270297abb08 = new xd0098fb28618d8f9();

	private string xc61ff88f1f98652d;

	public xd0098fb28618d8f9 x2639dfbfaf0930ee => x9c1f5270297abb08;

	public string xdf4a121570aaed7e
	{
		get
		{
			if (xc61ff88f1f98652d == null)
			{
				return "";
			}
			return xc61ff88f1f98652d;
		}
		set
		{
			xc61ff88f1f98652d = value;
		}
	}

	internal ArrayList xccf1ef7f15f14524 => xd5126346e5101136;

	internal xab391c46ff9a0a38 xbe03fdfd3b07bf15(x9118c2b63bc20309 x0f7b23d1c393aed9)
	{
		x2639dfbfaf0930ee.x4a705c5e126d7900(x0f7b23d1c393aed9.xa932600d61ea7dd8, x0f7b23d1c393aed9.x204414017cf54f95);
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		foreach (xec86d47cfa7ad297 item in xccf1ef7f15f14524)
		{
			item.xbe03fdfd3b07bf15(xab391c46ff9a0a, x0f7b23d1c393aed9);
		}
		if (xab391c46ff9a0a.xd44988f225497f3a == 0)
		{
			return null;
		}
		return xab391c46ff9a0a;
	}

	internal void x9f280d9f6d9d4ccb(xec86d47cfa7ad297 xe125219852864557)
	{
		if (xe125219852864557 != null)
		{
			xd5126346e5101136.Add(xe125219852864557);
		}
	}

	internal xb8e7e788f6d59708 xe406325e56f74b46(x9118c2b63bc20309 x0f7b23d1c393aed9)
	{
		x2639dfbfaf0930ee.x4a705c5e126d7900(x0f7b23d1c393aed9.xa932600d61ea7dd8, x0f7b23d1c393aed9.x204414017cf54f95);
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		foreach (xec86d47cfa7ad297 item in xccf1ef7f15f14524)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = item.xe406325e56f74b46(x0f7b23d1c393aed9);
			if (xab391c46ff9a0a != null)
			{
				xb8e7e788f6d.xd6b6ed77479ef68c(xab391c46ff9a0a);
			}
		}
		x7d9d14f376dca8ce(xb8e7e788f6d, x0f7b23d1c393aed9);
		return xb8e7e788f6d;
	}

	private void x7d9d14f376dca8ce(xb8e7e788f6d59708 x08ce8f4769eb3234, x9118c2b63bc20309 x0f7b23d1c393aed9)
	{
		if (!x0f7b23d1c393aed9.x17b2b93b89a6dd3c || xdf4a121570aaed7e != "rect" || x08ce8f4769eb3234.xd44988f225497f3a != 1)
		{
			return;
		}
		xab391c46ff9a0a38 xab391c46ff9a0a = (xab391c46ff9a0a38)((xbaec545ec01f92ca)x08ce8f4769eb3234).get_xe6d4b1b411ed94b5(0);
		if (xab391c46ff9a0a.xd44988f225497f3a == 1 && xab391c46ff9a0a.x9e5d5f9128c69a8f != null)
		{
			x1cab6af0a41b70e2 x1cab6af0a41b70e = (x1cab6af0a41b70e2)((xbaec545ec01f92ca)xab391c46ff9a0a).get_xe6d4b1b411ed94b5(0);
			if (x1cab6af0a41b70e.xd44988f225497f3a == 3)
			{
				float num = xab391c46ff9a0a.x9e5d5f9128c69a8f.xdc1bf80853046136 / 2f;
				xc5ae0714ec22011d(x1cab6af0a41b70e, 0, 0f - num, 0f - num, num, 0f - num);
				xc5ae0714ec22011d(x1cab6af0a41b70e, 1, num, 0f - num, num, num);
				xc5ae0714ec22011d(x1cab6af0a41b70e, 2, num, num, 0f - num, num);
			}
		}
	}

	private void xc5ae0714ec22011d(x1cab6af0a41b70e2 x6ac16bf6efd00832, int x9121c989b8d84a56, float xb833165a2ab5bde5, float x5abbe1d6e287e7d7, float x24b7676a458c31ed, float xdd6877dcff18a0b7)
	{
		x4fdf549af9de6b97 x4fdf549af9de6b = ((xbaec545ec01f92ca)x6ac16bf6efd00832).get_xe6d4b1b411ed94b5(x9121c989b8d84a56);
		if (x4fdf549af9de6b != null && x4fdf549af9de6b is x60c040f35bb272aa)
		{
			x60c040f35bb272aa x60c040f35bb272aa = (x60c040f35bb272aa)x4fdf549af9de6b;
			xd6a20a8d63e40d58(x60c040f35bb272aa.x4d7474e8f1849803, 0, xb833165a2ab5bde5, x5abbe1d6e287e7d7);
			xd6a20a8d63e40d58(x60c040f35bb272aa.x4d7474e8f1849803, 1, x24b7676a458c31ed, xdd6877dcff18a0b7);
		}
	}

	private void xd6a20a8d63e40d58(ArrayList x6fa2570084b2ad39, int xc0c4c459c6ccbd00, float xb73c4e7368f9939f, float xd143f88fddaa10ad)
	{
		PointF pointF = (PointF)x6fa2570084b2ad39[xc0c4c459c6ccbd00];
		x6fa2570084b2ad39[xc0c4c459c6ccbd00] = new PointF(pointF.X + xb73c4e7368f9939f, pointF.Y + xd143f88fddaa10ad);
	}
}
