using System.Drawing;
using x1c8faa688b1f0b0c;
using x5f5ca2a37b849b4a;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class xe12fc521c486b9a0 : x66e735b434e6b412
{
	private xc5b4b221f4698128 xaf33eb667d70b768;

	private x9b87766ad1dbe8d6 x7478fcb06804d869;

	private x9b87766ad1dbe8d6 x7758c3a0b53451ac;

	private x9b87766ad1dbe8d6 x1bdd23eae1fdccdb;

	private x9b87766ad1dbe8d6 x8d47089a81026e4d;

	private PointF[] xf3f81d6e7f8cf711;

	private PointF[] x4da93d080cd7eea2;

	private PointF[] x8512c340e11b8493;

	private PointF[] xf4d09a54e03a0680;

	private float x57e1e2b6dbd00624;

	public xe12fc521c486b9a0(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		xaf33eb667d70b768 = (xc5b4b221f4698128)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x3ac3996720135799((x7f6e105e40e31dae)x7458794d854f9b68);
		for (int i = 0; i < xaf33eb667d70b768.x28627c25cb262062; i++)
		{
			x62d651475bfbc774(i, x0f7b23d1c393aed9);
			xcec89951df69a0e6(i, x0f7b23d1c393aed9);
		}
		x0725224eb9ffdb1f(xf3f81d6e7f8cf711, x7478fcb06804d869, x0f7b23d1c393aed9);
		x0725224eb9ffdb1f(xf4d09a54e03a0680, x8d47089a81026e4d, x0f7b23d1c393aed9);
		x0725224eb9ffdb1f(x4da93d080cd7eea2, x7758c3a0b53451ac, x0f7b23d1c393aed9);
		x0725224eb9ffdb1f(x8512c340e11b8493, x1bdd23eae1fdccdb, x0f7b23d1c393aed9);
	}

	protected override void RenderLegendForDataPoints(xc48e9faacc88a3d5 legendLayout, xcd7d6e7318ee6574 context)
	{
		RenderLegendForSeries(legendLayout, context);
	}

	protected override void RenderLegendForSeries(xc48e9faacc88a3d5 legendLayut, xcd7d6e7318ee6574 context)
	{
		foreach (x9b87766ad1dbe8d6 item in xaf33eb667d70b768.xc869533ad93d98d3)
		{
			xb8e7e788f6d59708 xb8e7e788f6d = new xb8e7e788f6d59708();
			xab391c46ff9a0a38 xab391c46ff9a0a = x6377ccfa099ac593.x8c30fba0ce6ba6c8(legendLayut.x1ec127a2b0d2b01c, item.x320382c5f1993a78.x24d50ab5d64a016e.x94e4690631260a6c, item.xd1bdf42207dd3638, context);
			if (xab391c46ff9a0a != null)
			{
				xb8e7e788f6d.xd6b6ed77479ef68c(xab391c46ff9a0a);
			}
			legendLayut.xd7d75c376e5ae843(xb8e7e788f6d, item.x759aa16c2016a289);
		}
	}

	private void xcec89951df69a0e6(int xa2ee854ac63ea89c, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		if (x7478fcb06804d869 != null && x8d47089a81026e4d != null)
		{
			float num = xf4d09a54e03a0680[xa2ee854ac63ea89c].Y - xf3f81d6e7f8cf711[xa2ee854ac63ea89c].Y;
			float x = xf3f81d6e7f8cf711[xa2ee854ac63ea89c].X - x57e1e2b6dbd00624 / 2f;
			float y = xf3f81d6e7f8cf711[xa2ee854ac63ea89c].Y;
			RectangleF x26545669838eb36e = new RectangleF(x, y, x57e1e2b6dbd00624, num);
			xcd38be6e82bc4732 x85449f0299df03c = ((num < 0f) ? ((xcd38be6e82bc4732)x0f7b23d1c393aed9.x5e969e12ada2aab2.x55d773f95f0e9853) : ((xcd38be6e82bc4732)x0f7b23d1c393aed9.x5e969e12ada2aab2.x075ec5dae9abb601));
			xbc46977eebea4733 x82f66163e01f713f = ((num < 0f) ? xaf33eb667d70b768.x6afb9736bfd31348.x55d773f95f0e9853 : xaf33eb667d70b768.x6afb9736bfd31348.x075ec5dae9abb601);
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(x26545669838eb36e);
			x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x82f66163e01f713f, x85449f0299df03c, 0);
			x0f7b23d1c393aed9.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xab391c46ff9a0a);
		}
	}

	private void x62d651475bfbc774(int xa2ee854ac63ea89c, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		if (x7758c3a0b53451ac != null && x1bdd23eae1fdccdb != null)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.xb471d14948c54f27(x4da93d080cd7eea2[xa2ee854ac63ea89c], x8512c340e11b8493[xa2ee854ac63ea89c]);
			xab391c46ff9a0a.x9e5d5f9128c69a8f = x318f74746d616ef0.x2f0c16e51db81725(xaf33eb667d70b768.x93c1b4f8ca3c6608, x0f7b23d1c393aed9.x5e969e12ada2aab2.xb404ce1ec2770e93, 0);
			x0f7b23d1c393aed9.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xab391c46ff9a0a);
		}
	}

	private static void x0725224eb9ffdb1f(PointF[] x6fa2570084b2ad39, x9b87766ad1dbe8d6 x7acb8518c8ed6133, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		if (x7acb8518c8ed6133 != null)
		{
			xd17edb07eea89cb0.x02c01e0bd89aaaa0(x6fa2570084b2ad39, x0f7b23d1c393aed9, x7acb8518c8ed6133, xd925f447ef7e00a4: false, x559292b5f7ade8c2: false);
			xd17edb07eea89cb0.x188700e4cffdf544(x6fa2570084b2ad39, x0f7b23d1c393aed9, x7acb8518c8ed6133);
		}
	}

	private void x3ac3996720135799(x7f6e105e40e31dae x2a1bbcf88643e247)
	{
		foreach (x9b87766ad1dbe8d6 item in xaf33eb667d70b768.xc869533ad93d98d3)
		{
			switch (item.x759aa16c2016a289)
			{
			case "Open":
				x7478fcb06804d869 = item;
				xf3f81d6e7f8cf711 = x2a1bbcf88643e247.x466c8609d8f6c6c1(x7478fcb06804d869);
				break;
			case "High":
				x7758c3a0b53451ac = item;
				x4da93d080cd7eea2 = x2a1bbcf88643e247.x466c8609d8f6c6c1(x7758c3a0b53451ac);
				break;
			case "Low":
				x1bdd23eae1fdccdb = item;
				x8512c340e11b8493 = x2a1bbcf88643e247.x466c8609d8f6c6c1(x1bdd23eae1fdccdb);
				break;
			case "Close":
				x8d47089a81026e4d = item;
				xf4d09a54e03a0680 = x2a1bbcf88643e247.x466c8609d8f6c6c1(x8d47089a81026e4d);
				break;
			}
		}
		x57e1e2b6dbd00624 = x2a1bbcf88643e247.x156bf83d1a77efc1(1, xaf33eb667d70b768.x6afb9736bfd31348.x831803cdfcd433fb);
	}
}
