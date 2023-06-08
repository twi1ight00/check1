using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;

namespace x3d94286fe72124a8;

internal class x453b6489e3fdbd4d : xf51865b83a7a0b3b
{
	private x1cab6af0a41b70e2 x452b030a6e9cfa9e;

	internal static xab391c46ff9a0a38 xf3814c2c2fb527cb(xab391c46ff9a0a38 xe125219852864557)
	{
		x453b6489e3fdbd4d x453b6489e3fdbd4d2 = new x453b6489e3fdbd4d();
		return x453b6489e3fdbd4d2.x73d3078e504ad1b9(xe125219852864557);
	}

	internal xab391c46ff9a0a38 x73d3078e504ad1b9(xab391c46ff9a0a38 xe125219852864557)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = xe125219852864557.x8b61531c8ea35b85(x1288426be0f0b745: false);
		if (xe125219852864557.xd44988f225497f3a == 0)
		{
			return xab391c46ff9a0a;
		}
		for (int num = xe125219852864557.xd44988f225497f3a - 1; num >= 0; num--)
		{
			x1cab6af0a41b70e2 x1cab6af0a41b70e = (x1cab6af0a41b70e2)((xbaec545ec01f92ca)xe125219852864557).get_xe6d4b1b411ed94b5(num);
			x452b030a6e9cfa9e = new x1cab6af0a41b70e2();
			x452b030a6e9cfa9e.x5e6c52cb3256cc85 = x1cab6af0a41b70e.x5e6c52cb3256cc85;
			x1cab6af0a41b70e.Accept(this);
			xab391c46ff9a0a.xd6b6ed77479ef68c(x452b030a6e9cfa9e);
		}
		return xab391c46ff9a0a;
	}

	public override void VisitPolyLineSegment(x60c040f35bb272aa segment)
	{
		ArrayList arrayList = (ArrayList)segment.x4d7474e8f1849803.Clone();
		arrayList.Reverse();
		x60c040f35bb272aa xda5bf54deb817e = new x60c040f35bb272aa((PointF[])arrayList.ToArray(typeof(PointF)));
		x452b030a6e9cfa9e.xef23aa45e7612fdd(0, xda5bf54deb817e);
	}

	public override void VisitBezierSegment(x519b1bd0625473ff segment)
	{
		x519b1bd0625473ff xda5bf54deb817e = new x519b1bd0625473ff(segment.x56b911bdb6515aed.x2271dea312f4a835, segment.x56b911bdb6515aed.xf52fe1c3cad11afd, segment.x56b911bdb6515aed.xc7cf0e43653f9c41, segment.x56b911bdb6515aed.xaf4e0fbe61814cf5);
		x452b030a6e9cfa9e.xef23aa45e7612fdd(0, xda5bf54deb817e);
	}
}
