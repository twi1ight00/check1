using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using x5794c252ba25e723;
using xf9a9481c3f63a419;

namespace x4f4df92b75ba3b67;

internal class xce6b51b6998e50e4
{
	private bool x90f94c4eaa5e349d;

	private readonly x4882ae789be6e2ef x8cedcaa9a62c6e39;

	private xb0ab3c9ec6ea83b4 xf8f13794d87a78ff;

	private readonly Stack xe8cbc100051908cc = new Stack();

	internal xb0ab3c9ec6ea83b4 xb6d990994f0cea33 => xf8f13794d87a78ff;

	internal bool x417c1548351662da => x90f94c4eaa5e349d;

	internal bool x681ca949b70fefdc
	{
		get
		{
			if (!(xf8f13794d87a78ff.x0b15246bc2e0140e < 1f))
			{
				return xf8f13794d87a78ff.xb23002ebb610e506 < 1f;
			}
			return true;
		}
	}

	internal xce6b51b6998e50e4(x4882ae789be6e2ef context)
	{
		x8cedcaa9a62c6e39 = context;
	}

	internal void xfde0bef9d888fc90()
	{
		xf8f13794d87a78ff = new xb0ab3c9ec6ea83b4();
	}

	internal void xfa8268e52269b33f(x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("q");
		xe8cbc100051908cc.Push(xf8f13794d87a78ff.x8b61531c8ea35b85());
	}

	internal void x5040e9489a5cf554(x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("Q");
		xf8f13794d87a78ff = (xb0ab3c9ec6ea83b4)xe8cbc100051908cc.Pop();
	}

	internal void xc1291ef13d267082(x54366fa5f75a02f7 xa801ccff44b0c7eb, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		int num = ((xa801ccff44b0c7eb != null) ? xcd769e39c0788209.x56f8e216f636bee6(xa801ccff44b0c7eb.x35fa2f38e277fdee, xa801ccff44b0c7eb.x93f6f49bd53e2628) : 0);
		if (num > 1)
		{
			x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
			x54366fa5f75a02f.xce92de628aa023cf(xa801ccff44b0c7eb.x35fa2f38e277fdee / (float)num, xa801ccff44b0c7eb.x93f6f49bd53e2628 / (float)num);
			for (int i = 0; i < num; i++)
			{
				x57ca5ebb3901421e(x54366fa5f75a02f, xcf18e5243f8d5fd3);
			}
			x54366fa5f75a02f7 xa801ccff44b0c7eb2 = new x54366fa5f75a02f7(xa801ccff44b0c7eb.xb4f54e8f080ddae5, xa801ccff44b0c7eb.xdde8182ef4f9942b, xa801ccff44b0c7eb.xa71255917a9143ca, xa801ccff44b0c7eb.xcd7062a84a8f3162, 0f, 0f);
			x57ca5ebb3901421e(xa801ccff44b0c7eb2, xcf18e5243f8d5fd3);
		}
		else
		{
			x57ca5ebb3901421e(xa801ccff44b0c7eb, xcf18e5243f8d5fd3);
		}
	}

	private void x57ca5ebb3901421e(x54366fa5f75a02f7 xa801ccff44b0c7eb, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		xcf18e5243f8d5fd3.x1f64811c8bfde335(xa801ccff44b0c7eb, "cm");
		xf8f13794d87a78ff.x33bbb6b1ad2a7b2e.x490e30087768649f(xa801ccff44b0c7eb, MatrixOrder.Prepend);
	}

	internal void xc4274d0e82b5988e(string x179595faeecbdd36, bool x577adbf0cae935c5, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (xf8f13794d87a78ff.x1bd9cff42f77587e(x577adbf0cae935c5) != x28d5285d743f03f5.xd265a220a45d3124)
		{
			xf8f13794d87a78ff.x3136fe6697fa3f0c(x577adbf0cae935c5, x28d5285d743f03f5.xd265a220a45d3124);
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} {1}", x28d5285d743f03f5.xd265a220a45d3124.x0155217fb8bbda6a, x577adbf0cae935c5 ? "CS" : "cs");
		}
		xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("/{0} {1}", x179595faeecbdd36, x577adbf0cae935c5 ? "SCN" : "scn");
	}

	internal void x2a037b343bdac965(x26d9ecb4bdf0456d x6c50a99faab7d741, bool x577adbf0cae935c5, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		x28d5285d743f03f5 x28d5285d743f03f6 = x28d5285d743f03f5.x17b1961e76a1bb2b(x6c50a99faab7d741);
		if (xf8f13794d87a78ff.x1bd9cff42f77587e(x577adbf0cae935c5) == x28d5285d743f03f6 && xf8f13794d87a78ff.xef50a938c8b9c7fd(x577adbf0cae935c5) == x6c50a99faab7d741)
		{
			return;
		}
		xf8f13794d87a78ff.x3136fe6697fa3f0c(x577adbf0cae935c5, x28d5285d743f03f6);
		xf8f13794d87a78ff.xf4868abd18f579a7(x577adbf0cae935c5, x6c50a99faab7d741);
		if (x6c50a99faab7d741.xda71bf6f7c07c3bc < 255)
		{
			xab3c72a18f0329ac xab3c72a18f0329ac2 = x8cedcaa9a62c6e39.x2107de3fc2a21893.x6d1483ac033919d3();
			float num = (float)x6c50a99faab7d741.xda71bf6f7c07c3bc / 255f;
			if (x577adbf0cae935c5)
			{
				xf8f13794d87a78ff.x0b15246bc2e0140e = num;
			}
			else
			{
				xf8f13794d87a78ff.xb23002ebb610e506 = num;
			}
			xab3c72a18f0329ac2.x5f994f7d6671fc42 = xf8f13794d87a78ff.xb23002ebb610e506;
			xab3c72a18f0329ac2.x0b15246bc2e0140e = xf8f13794d87a78ff.x0b15246bc2e0140e;
			x77bd62802fa87acc(xab3c72a18f0329ac2, xcf18e5243f8d5fd3);
			x90f94c4eaa5e349d = true;
		}
		else if (x681ca949b70fefdc)
		{
			xab3c72a18f0329ac xab3c72a18f0329ac3 = x8cedcaa9a62c6e39.x2107de3fc2a21893.x6d1483ac033919d3();
			if (x577adbf0cae935c5)
			{
				xf8f13794d87a78ff.x0b15246bc2e0140e = 1f;
			}
			else
			{
				xf8f13794d87a78ff.xb23002ebb610e506 = 1f;
			}
			xab3c72a18f0329ac3.x5f994f7d6671fc42 = xf8f13794d87a78ff.xb23002ebb610e506;
			xab3c72a18f0329ac3.x0b15246bc2e0140e = xf8f13794d87a78ff.x0b15246bc2e0140e;
			x77bd62802fa87acc(xab3c72a18f0329ac3, xcf18e5243f8d5fd3);
		}
		xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} {1}", x28d5285d743f03f6.xfafbf12cd38285b5(x6c50a99faab7d741), x577adbf0cae935c5 ? x28d5285d743f03f6.xeff0fe726f3da2ea : x28d5285d743f03f6.x8f878f72e5a5dc35);
	}

	internal void xf74dabb52ecdb397(float xc106116e5c1f8533, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (xc106116e5c1f8533 != xf8f13794d87a78ff.x54d212b412ca54d5)
		{
			xf8f13794d87a78ff.x54d212b412ca54d5 = xc106116e5c1f8533;
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} TL", xcd769e39c0788209.x355581fe14891d82(xc106116e5c1f8533));
		}
	}

	internal void x2126b815e845382d(xba2f911354958a68 x26094932cf7a9139, float x5c021e387157a637, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (x26094932cf7a9139 != xf8f13794d87a78ff.x50c171f9f75b68a1 || x5c021e387157a637 != xf8f13794d87a78ff.x845a515eabfa755e)
		{
			xf8f13794d87a78ff.x50c171f9f75b68a1 = x26094932cf7a9139;
			xf8f13794d87a78ff.x845a515eabfa755e = x5c021e387157a637;
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("/{0} {1} Tf", x26094932cf7a9139.xd160355ae2167ae9, xcd769e39c0788209.x355581fe14891d82(x5c021e387157a637));
		}
	}

	internal void x61980db65496bed2(int xa4aa8b4150b11435, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (xa4aa8b4150b11435 != xf8f13794d87a78ff.x28ac52bccb0adab4)
		{
			xf8f13794d87a78ff.x28ac52bccb0adab4 = xa4aa8b4150b11435;
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} Tr", xca004f56614e2431.xc8ba948e0d631490(xa4aa8b4150b11435));
		}
	}

	internal void xe98c0b45f0df18ad(float x342174d4cbc8b15e, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (x342174d4cbc8b15e != xf8f13794d87a78ff.x0b7f5f6f60aa9375)
		{
			xf8f13794d87a78ff.x0b7f5f6f60aa9375 = x342174d4cbc8b15e;
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} Tc", xcd769e39c0788209.x355581fe14891d82(x342174d4cbc8b15e));
		}
	}

	internal void xb23a4cddc1d7ffe4(float xce90ee8e49859281, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (xce90ee8e49859281 != xf8f13794d87a78ff.xffa1fc725bf36690)
		{
			xf8f13794d87a78ff.xffa1fc725bf36690 = xce90ee8e49859281;
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} w", xcd769e39c0788209.x355581fe14891d82(xce90ee8e49859281));
		}
	}

	internal void xb713e6d18915b4f8(int x924d47924ddd687d, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (x924d47924ddd687d != xf8f13794d87a78ff.x758cbcf9b4de7a52)
		{
			xf8f13794d87a78ff.x758cbcf9b4de7a52 = x924d47924ddd687d;
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} J", xca004f56614e2431.xc8ba948e0d631490(x924d47924ddd687d));
		}
	}

	internal void x6372d209ad6773a9(int x116dc3c08b623a0b, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (x116dc3c08b623a0b != xf8f13794d87a78ff.x03a8df074279275f)
		{
			xf8f13794d87a78ff.x03a8df074279275f = x116dc3c08b623a0b;
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} j", xca004f56614e2431.xc8ba948e0d631490(x116dc3c08b623a0b));
		}
	}

	internal void x03e6c22eeea17c94(float xcc3cefa04826c25d, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		if (xcc3cefa04826c25d != xf8f13794d87a78ff.x3372c2e5fab45e9a)
		{
			xf8f13794d87a78ff.x3372c2e5fab45e9a = xcc3cefa04826c25d;
			xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("{0} M", xcd769e39c0788209.x355581fe14891d82(xcc3cefa04826c25d));
		}
	}

	private static void x77bd62802fa87acc(xab3c72a18f0329ac xaaab32adcbd11397, x4d8917c8186e8cb2 xcf18e5243f8d5fd3)
	{
		xcf18e5243f8d5fd3.x241b3c2e8c3aaa86("/{0} gs", xaaab32adcbd11397.xd160355ae2167ae9);
	}

	internal RectangleF xaccac17571a8d9fa(RectangleF x26545669838eb36e)
	{
		PointF[] array = new PointF[2]
		{
			new PointF(x26545669838eb36e.Left, x26545669838eb36e.Top),
			new PointF(x26545669838eb36e.Right, x26545669838eb36e.Bottom)
		};
		xf8f13794d87a78ff.x33bbb6b1ad2a7b2e.xa4b699bd47eb7372(array);
		return new RectangleF(Math.Min(array[0].X, array[1].X), Math.Min(array[0].Y, array[1].Y), Math.Abs(array[0].X - array[1].X), Math.Abs(array[0].Y - array[1].Y));
	}

	internal PointF xaccac17571a8d9fa(PointF x2f7096dac971d6ec)
	{
		PointF[] array = new PointF[1] { x2f7096dac971d6ec };
		xf8f13794d87a78ff.x33bbb6b1ad2a7b2e.xa4b699bd47eb7372(array);
		return array[0];
	}
}
