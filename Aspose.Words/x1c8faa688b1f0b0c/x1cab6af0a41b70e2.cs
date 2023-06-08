using System.Drawing;
using x5794c252ba25e723;

namespace x1c8faa688b1f0b0c;

internal class x1cab6af0a41b70e2 : xbaec545ec01f92ca
{
	private bool x3c061d2457b28308;

	public bool x5e6c52cb3256cc85
	{
		get
		{
			return x3c061d2457b28308;
		}
		set
		{
			x3c061d2457b28308 = value;
		}
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitPathFigureStart(this);
		base.Accept(visitor);
		visitor.VisitPathFigureEnd(this);
	}

	public static x1cab6af0a41b70e2 xa7b580afa8756d69(PointF[] x6fa2570084b2ad39, bool x7a848427f2a9a3b5)
	{
		x1cab6af0a41b70e2 x1cab6af0a41b70e3 = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e3.x5e6c52cb3256cc85 = x7a848427f2a9a3b5;
		x1cab6af0a41b70e3.x8992595b6d42d9bd(x6fa2570084b2ad39);
		return x1cab6af0a41b70e3;
	}

	public static x1cab6af0a41b70e2 xb471d14948c54f27(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		x1cab6af0a41b70e2 x1cab6af0a41b70e3 = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e3.x49babf6761229eb5(x10aaa7cdfa38f254, xca09b6c2b5b18485);
		return x1cab6af0a41b70e3;
	}

	public static x1cab6af0a41b70e2 x7c89cd07f845b8e1(RectangleF x26545669838eb36e)
	{
		x1cab6af0a41b70e2 x1cab6af0a41b70e3 = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e3.x5e6c52cb3256cc85 = true;
		x1cab6af0a41b70e3.xb90eeef3d2a5a96b(x26545669838eb36e);
		return x1cab6af0a41b70e3;
	}

	public static x1cab6af0a41b70e2 xd224a32bc1c49a2c(PointF[] x6fa2570084b2ad39)
	{
		x1cab6af0a41b70e2 x1cab6af0a41b70e3 = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e3.x5e6c52cb3256cc85 = false;
		x1cab6af0a41b70e3.x7a07af5ab8d9b424(x6fa2570084b2ad39);
		return x1cab6af0a41b70e3;
	}

	public void x8992595b6d42d9bd(PointF[] x6fa2570084b2ad39)
	{
		x60c040f35bb272aa xda5bf54deb817e = new x60c040f35bb272aa(x6fa2570084b2ad39);
		xd6b6ed77479ef68c(xda5bf54deb817e);
	}

	public void x49babf6761229eb5(PointF x10aaa7cdfa38f254, PointF xca09b6c2b5b18485)
	{
		x60c040f35bb272aa x60c040f35bb272aa2 = new x60c040f35bb272aa();
		x60c040f35bb272aa2.x4d7474e8f1849803.Add(x10aaa7cdfa38f254);
		x60c040f35bb272aa2.x4d7474e8f1849803.Add(xca09b6c2b5b18485);
		xd6b6ed77479ef68c(x60c040f35bb272aa2);
	}

	public void xb90eeef3d2a5a96b(RectangleF x26545669838eb36e)
	{
		x60c040f35bb272aa x60c040f35bb272aa2 = new x60c040f35bb272aa();
		x60c040f35bb272aa2.x4d7474e8f1849803.Add(new PointF(x26545669838eb36e.Left, x26545669838eb36e.Top));
		x60c040f35bb272aa2.x4d7474e8f1849803.Add(new PointF(x26545669838eb36e.Right, x26545669838eb36e.Top));
		x60c040f35bb272aa2.x4d7474e8f1849803.Add(new PointF(x26545669838eb36e.Right, x26545669838eb36e.Bottom));
		x60c040f35bb272aa2.x4d7474e8f1849803.Add(new PointF(x26545669838eb36e.Left, x26545669838eb36e.Bottom));
		xd6b6ed77479ef68c(x60c040f35bb272aa2);
	}

	public void x7a07af5ab8d9b424(PointF[] x6fa2570084b2ad39)
	{
		int num = x6fa2570084b2ad39.Length;
		for (int i = 0; i < num - 3; i += 3)
		{
			xd6b6ed77479ef68c(new x519b1bd0625473ff(x6fa2570084b2ad39[i], x6fa2570084b2ad39[i + 1], x6fa2570084b2ad39[i + 2], x6fa2570084b2ad39[i + 3]));
		}
	}

	public void xb6e955ab98a0878c(x1fb5d45c2d0b868a xc919e9fef7dfced6)
	{
		x9fe47a4de491f4aa[] array = xc919e9fef7dfced6.x1a10ab118b131ef0();
		x9fe47a4de491f4aa[] array2 = array;
		foreach (x9fe47a4de491f4aa bezier in array2)
		{
			x519b1bd0625473ff xda5bf54deb817e = new x519b1bd0625473ff(bezier);
			xd6b6ed77479ef68c(xda5bf54deb817e);
		}
	}

	public void xaccac17571a8d9fa(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		for (int i = 0; i < base.xd44988f225497f3a; i++)
		{
			x5e0582a42c97011a x5e0582a42c97011a2 = (x5e0582a42c97011a)base.get_xe6d4b1b411ed94b5(i);
			x5e0582a42c97011a2.xaccac17571a8d9fa(xa801ccff44b0c7eb);
		}
	}

	public x1cab6af0a41b70e2 x8b61531c8ea35b85()
	{
		x1cab6af0a41b70e2 x1cab6af0a41b70e3 = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e3.x3c061d2457b28308 = x3c061d2457b28308;
		for (int i = 0; i < base.xd44988f225497f3a; i++)
		{
			x755f711e37bcb2b3 x755f711e37bcb2b4 = (x755f711e37bcb2b3)base.get_xe6d4b1b411ed94b5(i);
			x1cab6af0a41b70e3.xd6b6ed77479ef68c(x755f711e37bcb2b4.x8b61531c8ea35b85());
		}
		return x1cab6af0a41b70e3;
	}
}
