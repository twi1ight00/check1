using System.Drawing;
using x32a884d842a34446;
using xad5c68c1ad3b0224;

namespace xb3013071794e5415;

internal class x55970cc410f6a88f : x66e735b434e6b412
{
	private x8369881e4b910612 x5bfa45ee8d15feea;

	private bool x79404d417cc3f6cb
	{
		get
		{
			switch (x5bfa45ee8d15feea.x7e0b0092fe472ee7)
			{
			case x7e0b0092fe472ee7.x94e4690631260a6c:
			case x7e0b0092fe472ee7.x4d0b9d4447ba7566:
				return false;
			default:
				return true;
			}
		}
	}

	private bool x138f3e7bd8930522
	{
		get
		{
			switch (x5bfa45ee8d15feea.x7e0b0092fe472ee7)
			{
			case x7e0b0092fe472ee7.xca74c96a38cb8a6f:
			case x7e0b0092fe472ee7.x94e4690631260a6c:
			case x7e0b0092fe472ee7.x655b77f8a4702b9a:
				return true;
			default:
				return false;
			}
		}
	}

	private bool x22925f509223ea15
	{
		get
		{
			switch (x5bfa45ee8d15feea.x7e0b0092fe472ee7)
			{
			case x7e0b0092fe472ee7.x22925f509223ea15:
			case x7e0b0092fe472ee7.x655b77f8a4702b9a:
				return true;
			default:
				return false;
			}
		}
	}

	public x55970cc410f6a88f(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		x5bfa45ee8d15feea = (x8369881e4b910612)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		foreach (x9b87766ad1dbe8d6 item in x5bfa45ee8d15feea.xc869533ad93d98d3)
		{
			PointF[] x6fa2570084b2ad = x7458794d854f9b68.x466c8609d8f6c6c1(item);
			if (x79404d417cc3f6cb)
			{
				xd17edb07eea89cb0.x02c01e0bd89aaaa0(x6fa2570084b2ad, x0f7b23d1c393aed9, item, xd925f447ef7e00a4: false, x22925f509223ea15);
			}
			if (x138f3e7bd8930522)
			{
				xd17edb07eea89cb0.x188700e4cffdf544(x6fa2570084b2ad, x0f7b23d1c393aed9, item);
			}
		}
	}

	protected override void RenderLegendForDataPoints(xc48e9faacc88a3d5 legendLayout, xcd7d6e7318ee6574 context)
	{
		xd17edb07eea89cb0.x44675b8bc366701b(x5bfa45ee8d15feea, x138f3e7bd8930522, legendLayout, context);
	}

	protected override void RenderLegendForSeries(xc48e9faacc88a3d5 legendLayut, xcd7d6e7318ee6574 context)
	{
		xd17edb07eea89cb0.xbdcf7a2be6955201(x5bfa45ee8d15feea, x138f3e7bd8930522, legendLayut, context);
	}
}
