using System.Drawing;
using x5794c252ba25e723;

namespace x1c8faa688b1f0b0c;

internal class x519b1bd0625473ff : x4fdf549af9de6b97, x5e0582a42c97011a, x755f711e37bcb2b3
{
	private x9fe47a4de491f4aa xfebbb423f94a0aba;

	public x9fe47a4de491f4aa x56b911bdb6515aed
	{
		get
		{
			return xfebbb423f94a0aba;
		}
		set
		{
			xfebbb423f94a0aba = value;
		}
	}

	public x519b1bd0625473ff()
	{
	}

	public x519b1bd0625473ff(x9fe47a4de491f4aa bezier)
	{
		xfebbb423f94a0aba = bezier;
	}

	public x519b1bd0625473ff(PointF cubP0, PointF cubP1, PointF cubP2, PointF cubP3)
	{
		xfebbb423f94a0aba = default(x9fe47a4de491f4aa);
		xfebbb423f94a0aba.xaf4e0fbe61814cf5 = cubP0;
		xfebbb423f94a0aba.xc7cf0e43653f9c41 = cubP1;
		xfebbb423f94a0aba.xf52fe1c3cad11afd = cubP2;
		xfebbb423f94a0aba.x2271dea312f4a835 = cubP3;
	}

	public x519b1bd0625473ff(PointF[] points)
		: this(points[0], points[1], points[2], points[3])
	{
	}

	public x519b1bd0625473ff(PointF quadP0, PointF quadP1, PointF quadP2)
	{
		xfebbb423f94a0aba = new x9fe47a4de491f4aa(quadP0, quadP1, quadP2);
	}

	public override void Accept(xf51865b83a7a0b3b visitor)
	{
		visitor.VisitBezierSegment(this);
	}

	public void xaccac17571a8d9fa(x54366fa5f75a02f7 xa801ccff44b0c7eb)
	{
		PointF[] array = new PointF[4] { xfebbb423f94a0aba.xaf4e0fbe61814cf5, xfebbb423f94a0aba.xc7cf0e43653f9c41, xfebbb423f94a0aba.xf52fe1c3cad11afd, xfebbb423f94a0aba.x2271dea312f4a835 };
		xa801ccff44b0c7eb.xa4b699bd47eb7372(array);
		xfebbb423f94a0aba.xaf4e0fbe61814cf5 = array[0];
		xfebbb423f94a0aba.xc7cf0e43653f9c41 = array[1];
		xfebbb423f94a0aba.xf52fe1c3cad11afd = array[2];
		xfebbb423f94a0aba.x2271dea312f4a835 = array[3];
	}

	public x4fdf549af9de6b97 x8b61531c8ea35b85()
	{
		x9fe47a4de491f4aa bezier = default(x9fe47a4de491f4aa);
		bezier.xaf4e0fbe61814cf5 = new PointF(xfebbb423f94a0aba.xaf4e0fbe61814cf5.X, xfebbb423f94a0aba.xaf4e0fbe61814cf5.Y);
		bezier.x2271dea312f4a835 = new PointF(xfebbb423f94a0aba.x2271dea312f4a835.X, xfebbb423f94a0aba.x2271dea312f4a835.Y);
		bezier.xc7cf0e43653f9c41 = new PointF(xfebbb423f94a0aba.xc7cf0e43653f9c41.X, xfebbb423f94a0aba.xc7cf0e43653f9c41.Y);
		bezier.xf52fe1c3cad11afd = new PointF(xfebbb423f94a0aba.xf52fe1c3cad11afd.X, xfebbb423f94a0aba.xf52fe1c3cad11afd.Y);
		x519b1bd0625473ff x519b1bd0625473ff2 = new x519b1bd0625473ff(bezier);
		x519b1bd0625473ff2.xfebbb423f94a0aba = bezier;
		return x519b1bd0625473ff2;
	}
}
