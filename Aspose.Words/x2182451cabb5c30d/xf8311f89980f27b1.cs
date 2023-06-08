using System.Collections;
using x9db5f2e5af3d596e;

namespace x2182451cabb5c30d;

internal class xf8311f89980f27b1
{
	private readonly Stack xcfc2e975409c798f = new Stack();

	private xfc21fba486a13f17 xd0d977d1b71c6cf8;

	private int xd14df88b746853b1;

	internal bool xc5da8300b6251a76 => xd14df88b746853b1 > 0;

	internal bool xe388359ed363cdcf => xd14df88b746853b1 > 1;

	internal bool x5b383c3eb24c7820 => xfb0d306430ea208b > xd14df88b746853b1;

	internal bool xa1dfad6564b5e2e7 => xfb0d306430ea208b < xd14df88b746853b1;

	internal xedb0eb766e25e0c9 xedb0eb766e25e0c9 => xd0d977d1b71c6cf8.xedb0eb766e25e0c9;

	internal xedb0eb766e25e0c9 x3fd9d01b90f5c1ac => (xedb0eb766e25e0c9)xd0d977d1b71c6cf8.xedb0eb766e25e0c9.x8b61531c8ea35b85();

	internal int xe02d79c539b6382d
	{
		get
		{
			return xd0d977d1b71c6cf8.xe02d79c539b6382d;
		}
		set
		{
			xd0d977d1b71c6cf8.xe02d79c539b6382d = value;
		}
	}

	internal bool x5fed4f8aefdd1554
	{
		get
		{
			return xd0d977d1b71c6cf8.x5fed4f8aefdd1554;
		}
		set
		{
			xd0d977d1b71c6cf8.x5fed4f8aefdd1554 = value;
		}
	}

	internal int xccc71d0c3837217b => xd0d977d1b71c6cf8.xccc71d0c3837217b;

	private int xfb0d306430ea208b => ((xfc21fba486a13f17)xcfc2e975409c798f.Peek()).x772764427592d4bb;

	internal xf8311f89980f27b1()
	{
		xdcae50fcd3683487();
	}

	internal void xdcae50fcd3683487()
	{
		xd14df88b746853b1 = 0;
		xd0d977d1b71c6cf8 = new xfc21fba486a13f17(1);
		xcfc2e975409c798f.Push(xfc21fba486a13f17.xaa4f6939bed62a73);
	}

	internal void xc842919e05bdedb6()
	{
		if (xfb0d306430ea208b > 0)
		{
			xd0d977d1b71c6cf8 = new xfc21fba486a13f17(xd0d977d1b71c6cf8.x772764427592d4bb + 1);
		}
		xcfc2e975409c798f.Push(xd0d977d1b71c6cf8);
	}

	internal void x92117b1aa2e0c555()
	{
		xcfc2e975409c798f.Pop();
		xd0d977d1b71c6cf8 = (xfc21fba486a13f17)xcfc2e975409c798f.Peek();
		if (xfb0d306430ea208b == 0)
		{
			xd0d977d1b71c6cf8 = new xfc21fba486a13f17(1);
		}
		xd14df88b746853b1 = xfb0d306430ea208b;
	}

	internal void xc8a20a3049e15fc4(int xfd9017be40b261df)
	{
		xd0d977d1b71c6cf8.x74f5a1ef3906e23c();
		xd0d977d1b71c6cf8.xccc71d0c3837217b = xfd9017be40b261df;
		xb8e4673a0e9aac73();
	}

	internal void xb8e4673a0e9aac73()
	{
		if (xd14df88b746853b1 == 0)
		{
			xd14df88b746853b1 = 1;
		}
	}

	internal void xc7ae5256463a3132()
	{
		xd14df88b746853b1 = 0;
	}

	internal void x6683111c3a6459ee(int x8a61868fbfcf5edd)
	{
		xd14df88b746853b1 = x8a61868fbfcf5edd;
	}
}
