using System.Drawing;
using x1c8faa688b1f0b0c;
using x4dc96876c552a593;
using x996431aaaaf00543;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;
using xeadd538cc90d42ab;
using xeb326c6285a77ac1;

namespace xb3013071794e5415;

internal class xba4e61c28aac852c
{
	private float xd74c65b8d28b1740;

	private float x8918dc7c534575e5;

	private xb8e7e788f6d59708 x0cfa266de0997aa1;

	private xcd7d6e7318ee6574 x8cedcaa9a62c6e39;

	private xdd882e9431b5e6e2 xf7bbe199f47f234d;

	private RectangleF xcfb00db5f2a96790;

	private x8abed58e51c8641c x1d7558d054aff992;

	internal float xdc1bf80853046136 => xd74c65b8d28b1740;

	internal float xb0f146032f47c24e => x8918dc7c534575e5;

	internal bool x3f5e31045e967a38
	{
		get
		{
			if (xf7bbe199f47f234d != null)
			{
				return xf7bbe199f47f234d.x3f5e31045e967a38;
			}
			return false;
		}
	}

	private xa4d912a00c540cf0 x0aa9ecee38d152a0
	{
		get
		{
			if (xf7bbe199f47f234d == null)
			{
				return null;
			}
			return xf7bbe199f47f234d.xb7ae55095fddecd9;
		}
	}

	private x8abed58e51c8641c xc6e3acdd6cd7e386
	{
		get
		{
			if (x1d7558d054aff992 == null)
			{
				x1d7558d054aff992 = new x8abed58e51c8641c();
			}
			return x1d7558d054aff992;
		}
	}

	internal xba4e61c28aac852c(xd4e66257276c6905 chartSpace, xcd7d6e7318ee6574 context, RectangleF targetRect)
	{
		x8cedcaa9a62c6e39 = context;
		xf7bbe199f47f234d = chartSpace.x317eef27d88d4cf9.x238bf167ccfdd282;
		xcfb00db5f2a96790 = x318f74746d616ef0.x8dae03a2613b9b6c(targetRect, x0aa9ecee38d152a0, x8cedcaa9a62c6e39);
		x0cfa266de0997aa1 = new xb8e7e788f6d59708();
		xb7ae55095fddecd9(chartSpace);
	}

	private void xb7ae55095fddecd9(xd4e66257276c6905 x02726bba19c4d190)
	{
		if (xf7bbe199f47f234d == null || x02726bba19c4d190.x317eef27d88d4cf9.x1b975dd453f6e91d)
		{
			return;
		}
		if (xf7bbe199f47f234d.x470ecea91abfd1aa == null && x02726bba19c4d190.x317eef27d88d4cf9.x665038dfa8849161.x4cb4f5636323b916.Count == 1)
		{
			x958ddf7e6db1ce94 x958ddf7e6db1ce = (x958ddf7e6db1ce94)x02726bba19c4d190.x317eef27d88d4cf9.x665038dfa8849161.x4cb4f5636323b916[0];
			if (x958ddf7e6db1ce.xc869533ad93d98d3.Count == 1)
			{
				xf7bbe199f47f234d.x470ecea91abfd1aa = x3edf6af70914912b(x958ddf7e6db1ce);
			}
		}
		x4fdf549af9de6b97 x4fdf549af9de6b = xbe9e07c27cf80187(xf7bbe199f47f234d.x470ecea91abfd1aa, xf7bbe199f47f234d.x68955bfadd010132, xcfb00db5f2a96790, x8cedcaa9a62c6e39, x0aa9ecee38d152a0 != null);
		if (x4fdf549af9de6b != null)
		{
			x0cfa266de0997aa1.xd6b6ed77479ef68c(x4fdf549af9de6b);
			RectangleF rectangleF = xc6e3acdd6cd7e386.xb1de1ba20faeeff8(x4fdf549af9de6b);
			xd74c65b8d28b1740 = rectangleF.Width;
			x8918dc7c534575e5 = rectangleF.Height + 2f * x8cedcaa9a62c6e39.x5e969e12ada2aab2.xd7e2a2a7c2290fa5;
		}
	}

	private static xc19947e71bdbe16a x3edf6af70914912b(x958ddf7e6db1ce94 xcdc54cda8adb2f3e)
	{
		xc19947e71bdbe16a xc19947e71bdbe16a = new xc19947e71bdbe16a();
		xc19947e71bdbe16a.x71826a9cb7f893e0 = new x4e987a76388726b5();
		xf5c6aa532fe023d4 xf5c6aa532fe023d = new xf5c6aa532fe023d4();
		xc19947e71bdbe16a.x71826a9cb7f893e0.x959bfe125105856a(xf5c6aa532fe023d);
		x91f0f9c35f99edd9 x91f0f9c35f99edd = new x91f0f9c35f99edd9();
		xf5c6aa532fe023d.x4b02688aa4c0e34d(x91f0f9c35f99edd);
		x91f0f9c35f99edd.xf9ad6fb78355fe13 = ((x9b87766ad1dbe8d6)xcdc54cda8adb2f3e.xc869533ad93d98d3[0]).x759aa16c2016a289;
		return xc19947e71bdbe16a;
	}

	private static x4fdf549af9de6b97 xbe9e07c27cf80187(xc19947e71bdbe16a x0e0da4ab3344491a, x4694a3400bb4849a x5d73ec97767a1b0c, RectangleF xefa4262da9bfb09c, xcd7d6e7318ee6574 x0f7b23d1c393aed9, bool x960555a2ddd5e105)
	{
		if (x0e0da4ab3344491a == null)
		{
			return null;
		}
		x7423ef514d81c23e x7423ef514d81c23e = ((x5d73ec97767a1b0c != null) ? x5d73ec97767a1b0c.xeedad81aaed42a76 : new x7423ef514d81c23e());
		x7423ef514d81c23e.x81b5ab71da5b7ae4(x0f7b23d1c393aed9.x5e969e12ada2aab2.xc2d4efc42998d87b.xbf72f566c4f69fb6);
		if (x0e0da4ab3344491a.x81575bc7c9357176 == x6b94cea616e07c30.x5a25f59d572442aa)
		{
			return x318f74746d616ef0.x67e197bbfa6da21d(x0e0da4ab3344491a.x633d57e35b6715a4(), new PointF(0f, 0f), x5d73ec97767a1b0c, x0f7b23d1c393aed9, x461bfa5b6ec21819: true);
		}
		x34b8da5e65f2d94f x34b8da5e65f2d94f = new x34b8da5e65f2d94f();
		x34b8da5e65f2d94f.xf6bed998bac61470 = x0e0da4ab3344491a.x71826a9cb7f893e0;
		foreach (xf5c6aa532fe023d4 item in x34b8da5e65f2d94f.xf6bed998bac61470.xe944988856b6cea9)
		{
			item.x4e35c79189b28e26.xbbbfd1631e528b0a.x81b5ab71da5b7ae4(x7423ef514d81c23e);
			if (x960555a2ddd5e105)
			{
				item.x4e35c79189b28e26.x9ba359ff37a3a63b = x19a216c91d09a513.x72d92bd1aff02e37;
			}
		}
		x687bd29facb7e34a x7cc44cab9e9f = new x687bd29facb7e34a(0.0, 0.0, null, null, x0f7b23d1c393aed9.x5e969e12ada2aab2.x9cb15050b100a1bf.xe209e476a780d1b4, new xd0098fb28618d8f9());
		x2094302a66c2ec77 x2f4d5d4fee2dfe = new x2094302a66c2ec77(x0f7b23d1c393aed9.xca687bd498227c89);
		return x34b8da5e65f2d94f.xe406325e56f74b46(x2f4d5d4fee2dfe, xefa4262da9bfb09c, x7cc44cab9e9f);
	}

	internal void xe406325e56f74b46()
	{
		x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xd6b6ed77479ef68c(x0cfa266de0997aa1);
	}
}
