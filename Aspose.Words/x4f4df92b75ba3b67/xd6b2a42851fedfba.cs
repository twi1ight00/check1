using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using x1c8faa688b1f0b0c;
using x38a89dee67fc7a16;
using x5794c252ba25e723;

namespace x4f4df92b75ba3b67;

internal class xd6b2a42851fedfba : x264ba3b7aca691be
{
	private readonly float xd74c65b8d28b1740;

	private readonly float x8918dc7c534575e5;

	private readonly x4d8917c8186e8cb2 x1a1d81c196cdd0dc;

	private readonly x9427801aa8503d6c x336289835451ba12;

	private readonly x79e4013ca0fc082a xb96cab30e96fb0bc;

	private readonly xa3d3e9bf30ebb072 x23005ecb620fd778;

	private xbad6feb536166b6b x15cd5903fdbf6f51;

	public float xdc1bf80853046136 => xd74c65b8d28b1740;

	public float xb0f146032f47c24e => x8918dc7c534575e5;

	private xbad6feb536166b6b x184d4ff9a68426cc
	{
		get
		{
			if (x15cd5903fdbf6f51 == null)
			{
				x15cd5903fdbf6f51 = new xbad6feb536166b6b();
			}
			return x15cd5903fdbf6f51;
		}
	}

	public xd6b2a42851fedfba(x4882ae789be6e2ef context, float width, float height)
		: base(context)
	{
		xd74c65b8d28b1740 = width;
		x8918dc7c534575e5 = height;
		x1a1d81c196cdd0dc = new x4d8917c8186e8cb2(x8cedcaa9a62c6e39);
		x336289835451ba12 = new x9427801aa8503d6c(x1a1d81c196cdd0dc);
		xb96cab30e96fb0bc = new x79e4013ca0fc082a(x8cedcaa9a62c6e39, x1a1d81c196cdd0dc);
		x23005ecb620fd778 = new xa3d3e9bf30ebb072(x8cedcaa9a62c6e39, x8cedcaa9a62c6e39.x2107de3fc2a21893, x1a1d81c196cdd0dc);
		x8cedcaa9a62c6e39.x147e079aca56accb.xfde0bef9d888fc90();
		x8cedcaa9a62c6e39.x147e079aca56accb.xc1291ef13d267082(new x54366fa5f75a02f7(1f, 0f, 0f, -1f, 0f, x8918dc7c534575e5), x1a1d81c196cdd0dc);
	}

	public void xa0cf4a18229be519()
	{
		xb96cab30e96fb0bc.x508e8f685c66ed54();
	}

	public void x93764b3608d338a4(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		xb96cab30e96fb0bc.x508e8f685c66ed54();
		xb67059efb664b0fb(x08ce8f4769eb3234, x43b0cbef2fcf3f77: false);
	}

	public void xd23c6c9fd3a6fa74(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		xed3b7dc19a70aa4a(x08ce8f4769eb3234, x43b0cbef2fcf3f77: false);
		if (x08ce8f4769eb3234.xc9bcfb2d9630b0c7 != null)
		{
			x3ca3595aa1a88d4b(x08ce8f4769eb3234.xc9bcfb2d9630b0c7);
		}
	}

	public void xc7234004e9b72a7e(xcc8c7739d82c63ba x199c511544621683)
	{
		xb67059efb664b0fb(x199c511544621683, x43b0cbef2fcf3f77: false);
		xb96cab30e96fb0bc.xd6b2549ca8b77560(x199c511544621683);
		if (x199c511544621683.xc9bcfb2d9630b0c7 != null)
		{
			x3ca3595aa1a88d4b(x199c511544621683.xc9bcfb2d9630b0c7);
		}
		xed3b7dc19a70aa4a(x199c511544621683, x43b0cbef2fcf3f77: false);
	}

	public void x4f6d0716f281880f(xab391c46ff9a0a38 xe125219852864557)
	{
		xb96cab30e96fb0bc.x508e8f685c66ed54();
		xb67059efb664b0fb(xe125219852864557, x8d3fa2cc884e0af4.xb32586d4069107ed(xe125219852864557));
		if (xe125219852864557.x60465f602599d327 != null)
		{
			x23005ecb620fd778.x3a53bab86bc1dfad(xe125219852864557.x60465f602599d327, x577adbf0cae935c5: false);
		}
		if (xe125219852864557.x9e5d5f9128c69a8f != null)
		{
			x23005ecb620fd778.xdaaa5fdab00f8843(xe125219852864557.x9e5d5f9128c69a8f);
		}
	}

	public void x8e20e5f3afd31049(xab391c46ff9a0a38 xe125219852864557)
	{
		x1a1d81c196cdd0dc.x241b3c2e8c3aaa86(x9b31aa41424b63e2(xe125219852864557));
		xed3b7dc19a70aa4a(xe125219852864557, x8d3fa2cc884e0af4.xb32586d4069107ed(xe125219852864557));
	}

	private static string x9b31aa41424b63e2(xab391c46ff9a0a38 xe125219852864557)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (xe125219852864557.x60465f602599d327 != null && xe125219852864557.x9e5d5f9128c69a8f != null)
		{
			stringBuilder.Append(xe125219852864557.x424546082eb650ba ? "b" : "B");
			if (xe125219852864557.x4eada1f74f43bddb == FillMode.Alternate)
			{
				stringBuilder.Append("*");
			}
		}
		else if (xe125219852864557.x60465f602599d327 != null)
		{
			stringBuilder.Append("f");
			if (xe125219852864557.x4eada1f74f43bddb == FillMode.Alternate)
			{
				stringBuilder.Append("*");
			}
		}
		else if (xe125219852864557.x9e5d5f9128c69a8f != null)
		{
			stringBuilder.Append(xe125219852864557.x424546082eb650ba ? "s" : "S");
		}
		return stringBuilder.ToString();
	}

	public void xe7593051eba00f64(x1cab6af0a41b70e2 x1e8706aef1ad2b94)
	{
		x336289835451ba12.VisitPathFigureStart(x1e8706aef1ad2b94);
	}

	public void x6cd18ff4b66042fc(x1cab6af0a41b70e2 x1e8706aef1ad2b94)
	{
		x336289835451ba12.VisitPathFigureEnd(x1e8706aef1ad2b94);
	}

	public void xa991bd0d9c80557e(x60c040f35bb272aa x311b46c396890b2f)
	{
		x336289835451ba12.VisitPolyLineSegment(x311b46c396890b2f);
	}

	public void x23e7297287797971(x519b1bd0625473ff x311b46c396890b2f)
	{
		x336289835451ba12.VisitBezierSegment(x311b46c396890b2f);
	}

	public void x558cc83610335d8b(x72c34b8dbaec3734 xaf3288ddace2264d)
	{
		xb96cab30e96fb0bc.x508e8f685c66ed54();
		RectangleF rectangleF = xaf3288ddace2264d.x6ae4612a8469678e;
		if (!x02df97c06afacbf3.x1c140bd1078ddda1(xaf3288ddace2264d.x4d7261a5f7f6e09c))
		{
			rectangleF = xaf3288ddace2264d.x4d7261a5f7f6e09c.xade9cf8b9eb86a8e(rectangleF);
		}
		x23005ecb620fd778.x27335b788ad093c5(xaf3288ddace2264d.xcc18177a965e0313, rectangleF, xe9177d3c2a7f695a: true, xaf3288ddace2264d.x4d7261a5f7f6e09c, xaf3288ddace2264d.x1fa52d87045f9b01);
		if (xaf3288ddace2264d.xc9bcfb2d9630b0c7 != null)
		{
			x3ca3595aa1a88d4b(xaf3288ddace2264d.xc9bcfb2d9630b0c7);
		}
	}

	internal void x565402b98bcb072a(xf5cfd3a839b4ec91 xe01ae93d9fe5a880)
	{
		x184d4ff9a68426cc.Add(xe01ae93d9fe5a880.x899a2110a8a35fda);
	}

	internal void x7062f8071787723c(xf70c7bfb09d6c003 x1c1b6dc9ecd0f6ee)
	{
		x184d4ff9a68426cc.Add(x1c1b6dc9ecd0f6ee.x899a2110a8a35fda);
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		x51cf2b3953f93541(writer);
		x1a1d81c196cdd0dc.WriteToPdf(writer);
	}

	private void x51cf2b3953f93541(x4f40d990d5bf81a6 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.x7a67b9beb30292d6(this);
		xbdfb620b7167944b.xafb7e6f79ed43681();
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Type", "/Page");
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Parent", x8cedcaa9a62c6e39.x09ed8d79c4ca4609.x899a2110a8a35fda);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/Contents", x1a1d81c196cdd0dc.x899a2110a8a35fda);
		xbdfb620b7167944b.xa4dc0ad8886e23a2("/MediaBox", new RectangleF(0f, 0f, xd74c65b8d28b1740, x8918dc7c534575e5));
		if (!x8cedcaa9a62c6e39.x5ba9693d4c3c102e)
		{
			xbdfb620b7167944b.xa4dc0ad8886e23a2("/Group", "<</Type/Group/S/Transparency/CS/DeviceRGB>>");
		}
		if (x15cd5903fdbf6f51 != null)
		{
			xbdfb620b7167944b.x6210059f049f0d48("/Annots");
			x15cd5903fdbf6f51.x10f3680c04d77f08(xbdfb620b7167944b);
		}
		xbdfb620b7167944b.x693a8d6d020474f2();
		xbdfb620b7167944b.x5155d7b9dab28280();
	}

	private void xb67059efb664b0fb(x0c06161ccb9341e4 xda5bf54deb817e37, bool x43b0cbef2fcf3f77)
	{
		if (x43b0cbef2fcf3f77 || x8d3fa2cc884e0af4.xd35c930085b41406(xda5bf54deb817e37))
		{
			xb96cab30e96fb0bc.x508e8f685c66ed54();
			x8cedcaa9a62c6e39.x147e079aca56accb.xfa8268e52269b33f(x1a1d81c196cdd0dc);
			if (x8d3fa2cc884e0af4.x24e2ebfada9bb90d(xda5bf54deb817e37))
			{
				x8cedcaa9a62c6e39.x147e079aca56accb.xc1291ef13d267082(xda5bf54deb817e37.x52dde376accdec7d, x1a1d81c196cdd0dc);
			}
			if (x8d3fa2cc884e0af4.x2f7838697f3bd577(xda5bf54deb817e37))
			{
				x9427801aa8503d6c visitor = new x9427801aa8503d6c(x1a1d81c196cdd0dc);
				xda5bf54deb817e37.x0e1bf8242ad10272.Accept(visitor);
				x1a1d81c196cdd0dc.x241b3c2e8c3aaa86("W n");
			}
		}
	}

	private void xed3b7dc19a70aa4a(x0c06161ccb9341e4 xda5bf54deb817e37, bool x43b0cbef2fcf3f77)
	{
		if (x43b0cbef2fcf3f77 || x8d3fa2cc884e0af4.xd35c930085b41406(xda5bf54deb817e37))
		{
			xb96cab30e96fb0bc.x508e8f685c66ed54();
			x8cedcaa9a62c6e39.x147e079aca56accb.x5040e9489a5cf554(x1a1d81c196cdd0dc);
		}
	}

	private void x3ca3595aa1a88d4b(xa702b771604efc86 xe0abc8f59346647b)
	{
		x09657b391973c9d1 x09657b391973c9d2 = new x09657b391973c9d1(x8cedcaa9a62c6e39, x8cedcaa9a62c6e39.x147e079aca56accb.xaccac17571a8d9fa(xe0abc8f59346647b.x316e48914c4b28b5), xe0abc8f59346647b.x42f4c234c9358072, xe0abc8f59346647b.x23ae6e0c44b8e6a2);
		x184d4ff9a68426cc.Add(x09657b391973c9d2.x899a2110a8a35fda);
		x8cedcaa9a62c6e39.x7cdd5738448662c5.xfff43e6a4e67b816(x09657b391973c9d2);
	}

	public void x94f739530d38cc0a(x9a66d03de2ff27e1 xa490ad5ef1682691)
	{
		x3b40d431d373c41d x6b8e154b42d5c1e = x3e021ae2fa48fbfe(xa490ad5ef1682691.xc22eade24b085d91);
		x8cedcaa9a62c6e39.x7cdd5738448662c5.x19e9bba3d65e67a0(xa490ad5ef1682691.x759aa16c2016a289, x6b8e154b42d5c1e);
		int x9b6007a17b33a42b = x8cedcaa9a62c6e39.x73979cef1002ed01.x9b6007a17b33a42b;
		if (x9b6007a17b33a42b > 0 && !xa490ad5ef1682691.x4b8f3649c1a3071c)
		{
			x8cedcaa9a62c6e39.x93e68a44438355fd.xdac50776b1d359d8(xa490ad5ef1682691.x759aa16c2016a289, x9b6007a17b33a42b, x6b8e154b42d5c1e);
		}
	}

	public void xdac50776b1d359d8(x2e5b68a308682b82 xcb5840a48b682489)
	{
		x3b40d431d373c41d x6b8e154b42d5c1e = x3e021ae2fa48fbfe(xcb5840a48b682489.xc22eade24b085d91);
		int xcaedf7c40a4ec = x8cedcaa9a62c6e39.x73979cef1002ed01.xcaedf7c40a4ec358;
		if (xcb5840a48b682489.x504f3d4040b356d7 < xcaedf7c40a4ec)
		{
			x8cedcaa9a62c6e39.x93e68a44438355fd.xdac50776b1d359d8(xcb5840a48b682489.x238bf167ccfdd282, xcb5840a48b682489.x504f3d4040b356d7, x6b8e154b42d5c1e);
		}
	}

	private x3b40d431d373c41d x3e021ae2fa48fbfe(PointF x9c3c185e7046dc72)
	{
		return x3b40d431d373c41d.x525204da0664c710(base.x899a2110a8a35fda, x8cedcaa9a62c6e39.x147e079aca56accb.xaccac17571a8d9fa(x9c3c185e7046dc72));
	}
}
