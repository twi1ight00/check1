using System;
using x1c8faa688b1f0b0c;
using x4dc96876c552a593;
using x5794c252ba25e723;
using x6b8130194ad714f7;

namespace x7cd71466ce904867;

internal class x944c43943c01324c : x4e65d9f1b1fbe157
{
	private readonly x7cd9263b5da819f7 x89e78434620b2eb6 = new x7cd9263b5da819f7();

	private bool x49172811fa8c88ff;

	private double x1aefc8a2390552c2;

	private double xc234945b958dc332;

	private x9725f23333d8c1d6 x4b492e6a7fa8dcf4;

	private x9725f23333d8c1d6 x3696d59cf052d87b;

	private double x4411e42421d03738;

	private double x7cf290e345b9b3cf;

	private double x7b7c4bf07166b4da;

	public x5725b63233877cf4 x6cee542cebddb262 => x89e78434620b2eb6;

	public bool x8bfe79484ce3a1f2
	{
		get
		{
			return x49172811fa8c88ff;
		}
		set
		{
			x49172811fa8c88ff = value;
		}
	}

	public double xc821290d7ecc08bf
	{
		get
		{
			return x7b7c4bf07166b4da;
		}
		set
		{
			x7b7c4bf07166b4da = value;
		}
	}

	public double x8df91a2f90079e88
	{
		get
		{
			return x7cf290e345b9b3cf;
		}
		set
		{
			x7cf290e345b9b3cf = value;
		}
	}

	public x9725f23333d8c1d6 x8005fced6d6088d7 => x3696d59cf052d87b;

	internal x9725f23333d8c1d6 xc79083f92136743d => x4b492e6a7fa8dcf4;

	public x944c43943c01324c(double lineWidth, x9725f23333d8c1d6 spanRange)
	{
		x4b492e6a7fa8dcf4 = spanRange;
		x1aefc8a2390552c2 = lineWidth;
		x3c02714b73cc8076();
		x2f9881556fe66cc1();
	}

	public void xceaa36575b797b5b(x19a216c91d09a513 x4ec4022180cbf8f4)
	{
		double num = xc234945b958dc332 + x4411e42421d03738;
		switch (x4ec4022180cbf8f4)
		{
		case x19a216c91d09a513.x72d92bd1aff02e37:
			xceaa36575b797b5b(0.0);
			break;
		case x19a216c91d09a513.x58d2ccae3c5cfd08:
			xceaa36575b797b5b((x1aefc8a2390552c2 - num) / 2.0);
			break;
		case x19a216c91d09a513.x419ba17a5322627b:
			xceaa36575b797b5b(x1aefc8a2390552c2 - num);
			break;
		case x19a216c91d09a513.xe590b96312e08b5b:
		case x19a216c91d09a513.xbcf8338386567937:
		case x19a216c91d09a513.x18ef0deb23f38251:
		case x19a216c91d09a513.x8132d8efd150f3e7:
			x3d8491ec9db76121();
			break;
		default:
			throw new ArgumentOutOfRangeException("alignment");
		}
	}

	public x4fdf549af9de6b97 xe406325e56f74b46()
	{
		xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
		for (int i = 0; i < x3696d59cf052d87b.xd44988f225497f3a; i++)
		{
			xd1d18a01676074c6 xd1d18a01676074c7 = (xd1d18a01676074c6)x3696d59cf052d87b.xe84e6ff66aac2a0e(i);
			xb8e7e788f6d.xd6b6ed77479ef68c(xd1d18a01676074c7.xe406325e56f74b46());
		}
		xb8e7e788f6d.x52dde376accdec7d = new x54366fa5f75a02f7();
		xb8e7e788f6d.x52dde376accdec7d.xce92de628aa023cf((float)x8df91a2f90079e88, (float)xc821290d7ecc08bf);
		return xb8e7e788f6d;
	}

	private void x2f9881556fe66cc1()
	{
		xc234945b958dc332 = 0.0;
		x4411e42421d03738 = 0.0;
		x89e78434620b2eb6.x74f5a1ef3906e23c();
		for (int i = 0; i < x3696d59cf052d87b.xd44988f225497f3a; i++)
		{
			xd1d18a01676074c6 xd1d18a01676074c7 = (xd1d18a01676074c6)x3696d59cf052d87b.xe84e6ff66aac2a0e(i);
			x89e78434620b2eb6.xd6b6ed77479ef68c(xd1d18a01676074c7.x6cee542cebddb262);
			switch (xd1d18a01676074c7.x3146d638ec378671)
			{
			case x644902f73993c0f3.xe89828e8b8199286:
				x4411e42421d03738 += xd1d18a01676074c7.xbd07e3206ab4c3fa;
				break;
			case x644902f73993c0f3.x3e1feffd8ca6feb2:
				xc234945b958dc332 += xd1d18a01676074c7.xbd07e3206ab4c3fa;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			case x644902f73993c0f3.xe6e4072a65065ef9:
				break;
			}
		}
	}

	private void x3d8491ec9db76121()
	{
		double num = (x1aefc8a2390552c2 - x4411e42421d03738) / xc234945b958dc332;
		double num2 = 0.0;
		for (int i = 0; i < x3696d59cf052d87b.xd44988f225497f3a; i++)
		{
			xd1d18a01676074c6 xd1d18a01676074c7 = (xd1d18a01676074c6)x3696d59cf052d87b.xe84e6ff66aac2a0e(i);
			if (xd1d18a01676074c7.x3146d638ec378671 == x644902f73993c0f3.x3e1feffd8ca6feb2)
			{
				xd1d18a01676074c7.x3e40dd6cc0f0c7e1 = xd1d18a01676074c7.xbd07e3206ab4c3fa * num;
			}
			else
			{
				xd1d18a01676074c7.x3e40dd6cc0f0c7e1 = xd1d18a01676074c7.xbd07e3206ab4c3fa;
			}
			xd1d18a01676074c7.x8df91a2f90079e88 = num2;
			num2 += xd1d18a01676074c7.x3e40dd6cc0f0c7e1;
		}
	}

	private void xceaa36575b797b5b(double x374ea4fe62468d0f)
	{
		for (int i = 0; i < x3696d59cf052d87b.xd44988f225497f3a; i++)
		{
			xd1d18a01676074c6 xd1d18a01676074c7 = (xd1d18a01676074c6)x3696d59cf052d87b.xe84e6ff66aac2a0e(i);
			xd1d18a01676074c7.x8df91a2f90079e88 = x374ea4fe62468d0f;
			xd1d18a01676074c7.x3e40dd6cc0f0c7e1 = xd1d18a01676074c7.xbd07e3206ab4c3fa;
			x374ea4fe62468d0f += xd1d18a01676074c7.x3e40dd6cc0f0c7e1;
		}
	}

	private void x3c02714b73cc8076()
	{
		x3696d59cf052d87b = x4b492e6a7fa8dcf4.x8b61531c8ea35b85();
		while (x8005fced6d6088d7.x97fbc3cdb3cadcc8)
		{
			xd1d18a01676074c6 xd1d18a01676074c7 = (xd1d18a01676074c6)x3696d59cf052d87b.x5bcf371cf6e8144d;
			if (xd1d18a01676074c7.x3146d638ec378671 == x644902f73993c0f3.xe89828e8b8199286)
			{
				break;
			}
			x3696d59cf052d87b.xcf25c2b572db7a4e(1);
		}
		while (x8005fced6d6088d7.x97fbc3cdb3cadcc8)
		{
			xd1d18a01676074c6 xd1d18a01676074c8 = (xd1d18a01676074c6)x3696d59cf052d87b.xc3806d802c319dc2;
			if (xd1d18a01676074c8.x3146d638ec378671 == x644902f73993c0f3.xe89828e8b8199286)
			{
				break;
			}
			x3696d59cf052d87b.x003f89d2b0039c61(1);
		}
	}
}
