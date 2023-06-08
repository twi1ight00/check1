using System;
using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x32a884d842a34446;
using x5794c252ba25e723;
using xad5c68c1ad3b0224;

namespace xb3013071794e5415;

internal class x6f0dc7da3e6e3517
{
	private readonly x6128243c276d529b x8f4a54c23a2aaba2;

	private readonly xcd7d6e7318ee6574 x8cedcaa9a62c6e39;

	private readonly RectangleF x97979090afd24b04;

	private float x6e74c79ac777f020;

	private float xf995a7a9bffac1cf;

	private float x2cede84e47db333b;

	private float xf63c9a791cae8f48;

	private Hashtable xa82448801cad6eee = new Hashtable();

	private float x31f3192bdc025ca5 => x97979090afd24b04.Width - (x6e74c79ac777f020 + xf995a7a9bffac1cf);

	private float x89a1d2c0b93619bb => x97979090afd24b04.Height - (x2cede84e47db333b + xf63c9a791cae8f48);

	private bool x7087e7d1445e7b96
	{
		get
		{
			if (x8f4a54c23a2aaba2.xb7ae55095fddecd9 != null)
			{
				return x8f4a54c23a2aaba2.xb7ae55095fddecd9.xf82c96da969931d7 == xf82c96da969931d7.x3852411577c61867;
			}
			return false;
		}
	}

	internal x6f0dc7da3e6e3517(x6128243c276d529b plotArea, xcd7d6e7318ee6574 context, RectangleF targetRectangle)
	{
		x97979090afd24b04 = x318f74746d616ef0.x8dae03a2613b9b6c(targetRectangle, plotArea.xb7ae55095fddecd9, context);
		x8cedcaa9a62c6e39 = context;
		x8f4a54c23a2aaba2 = plotArea;
	}

	internal void xe406325e56f74b46()
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		x8cedcaa9a62c6e39.x490834a62c46f14d(xb8e7e788f6d);
		xe5278a815d83e7df();
		x05a1099f1715b524();
		x330e6a8b60947cb4();
		xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
		xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf(x97979090afd24b04.X, x97979090afd24b04.Y);
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
	}

	private void x05a1099f1715b524()
	{
		RectangleF x26545669838eb36e = x1affa8f6994ec66e();
		xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
		x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x8f4a54c23a2aaba2.xff13b489d81606b6, x8cedcaa9a62c6e39.x5e969e12ada2aab2.xea8d9330f7951f96, 1);
		x8cedcaa9a62c6e39.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xab391c46ff9a0a);
	}

	private void xe5278a815d83e7df()
	{
		x8f4a54c23a2aaba2.xd22d4131e7740788();
		foreach (x958ddf7e6db1ce94 item in x8f4a54c23a2aaba2.x4cb4f5636323b916)
		{
			x43c3197706cb18d9 x7458794d854f9b = x38a9029f1da31de4(item);
			xb074016a522954c0(x7458794d854f9b);
		}
		foreach (DictionaryEntry item2 in xa82448801cad6eee)
		{
			x43c3197706cb18d9 x43c3197706cb18d10 = (x43c3197706cb18d9)item2.Value;
			x43c3197706cb18d10.x9d75576ac28fd38a(x6e74c79ac777f020, xf995a7a9bffac1cf, x2cede84e47db333b, xf63c9a791cae8f48);
		}
	}

	private void xb074016a522954c0(x43c3197706cb18d9 x7458794d854f9b68)
	{
		x6e74c79ac777f020 = Math.Max(x6e74c79ac777f020, x7458794d854f9b68.xc24e3e091abd3197);
		xf995a7a9bffac1cf = Math.Max(xf995a7a9bffac1cf, x7458794d854f9b68.xb50d6cb9d3b61d4d);
		x2cede84e47db333b = Math.Max(x2cede84e47db333b, x7458794d854f9b68.xcdb214dfc38b1be3);
		xf63c9a791cae8f48 = Math.Max(xf63c9a791cae8f48, x7458794d854f9b68.xd0fade446b8d532a);
	}

	private x43c3197706cb18d9 x38a9029f1da31de4(x958ddf7e6db1ce94 xe640ebcce83ddadc)
	{
		long num = 0L;
		if (xe640ebcce83ddadc is x4457da8976f5f7bc)
		{
			x4457da8976f5f7bc x4457da8976f5f7bc = (x4457da8976f5f7bc)xe640ebcce83ddadc;
			num = x1b109b9661a02d87(x4457da8976f5f7bc.x47443c66c2e1bad9, x4457da8976f5f7bc.xd14c2707620ef55a);
			if (xa82448801cad6eee[num] == null)
			{
				x8f04e4e6e23bd1f5 x13c22d4630b556cf = xe640ebcce83ddadc.x13c22d4630b556cf;
				if (x13c22d4630b556cf == x8f04e4e6e23bd1f5.x43c013ec50029a74)
				{
					xa82448801cad6eee[num] = new x760100a488bf9b75(x4457da8976f5f7bc.x47443c66c2e1bad9, x4457da8976f5f7bc.xd14c2707620ef55a, x8cedcaa9a62c6e39, x97979090afd24b04, x7087e7d1445e7b96);
				}
				else
				{
					xa82448801cad6eee[num] = new x7f6e105e40e31dae(x4457da8976f5f7bc.x47443c66c2e1bad9, x4457da8976f5f7bc.xd14c2707620ef55a, x8cedcaa9a62c6e39, x97979090afd24b04, x7087e7d1445e7b96);
				}
			}
		}
		else if (xa82448801cad6eee[num] == null)
		{
			xa82448801cad6eee[num] = new x5b215895ce9a4c9a(x97979090afd24b04.Size, x7087e7d1445e7b96);
		}
		return (x43c3197706cb18d9)xa82448801cad6eee[num];
	}

	private static long x1b109b9661a02d87(xf6f80e59810bad00 x08db3aeabb253cb1, xf6f80e59810bad00 x1e218ceaee1bb583)
	{
		long num = x08db3aeabb253cb1.xb1cd0e7571a46f8e;
		long num2 = x1e218ceaee1bb583.xb1cd0e7571a46f8e;
		return (num << 32) + num2;
	}

	private void x330e6a8b60947cb4()
	{
		foreach (x958ddf7e6db1ce94 item in x8f4a54c23a2aaba2.x4cb4f5636323b916)
		{
			x1c68e9c95170be3b(item);
		}
	}

	private void x1c68e9c95170be3b(x958ddf7e6db1ce94 xe640ebcce83ddadc)
	{
		x43c3197706cb18d9 x43c3197706cb18d10 = x38a9029f1da31de4(xe640ebcce83ddadc);
		x43c3197706cb18d10.x5006720129e0cf11();
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		xb8e7e788f6d.x0e1bf8242ad10272 = xab391c46ff9a0a38.x7c89cd07f845b8e1(x43c3197706cb18d10.xb7d97a6d836eba66());
		x8cedcaa9a62c6e39.x490834a62c46f14d(xb8e7e788f6d);
		xe640ebcce83ddadc.xe406325e56f74b46(x43c3197706cb18d10, x8cedcaa9a62c6e39);
		x8cedcaa9a62c6e39.xf5b0b9b6ff7ac462();
		x43c3197706cb18d10.xac399403da6cb85d();
	}

	internal RectangleF x1affa8f6994ec66e()
	{
		return new RectangleF(x6e74c79ac777f020, x2cede84e47db333b, x31f3192bdc025ca5, x89a1d2c0b93619bb);
	}
}
