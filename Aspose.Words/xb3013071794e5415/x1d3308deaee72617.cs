using System.Drawing;
using x32a884d842a34446;
using xad5c68c1ad3b0224;

namespace xb3013071794e5415;

internal class x1d3308deaee72617 : x66e735b434e6b412
{
	private xeee90af555b475d2 x8d84f385c1b12408;

	private bool x138f3e7bd8930522 => x8d84f385c1b12408.xc08adeedaa9916be == xc08adeedaa9916be.x94e4690631260a6c;

	private bool xda6252d2884b846f => x8d84f385c1b12408.xc08adeedaa9916be == xc08adeedaa9916be.xcf49a18e709f5041;

	public x1d3308deaee72617(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		x8d84f385c1b12408 = (xeee90af555b475d2)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		foreach (x9b87766ad1dbe8d6 item in x8d84f385c1b12408.xc869533ad93d98d3)
		{
			PointF[] array = x7458794d854f9b68.x466c8609d8f6c6c1(item);
			PointF[] array2 = new PointF[array.Length + 1];
			array.CopyTo(array2, 0);
			ref PointF reference = ref array2[^1];
			reference = array2[0];
			xd17edb07eea89cb0.x02c01e0bd89aaaa0(array2, x0f7b23d1c393aed9, item, xda6252d2884b846f, item.x22925f509223ea15);
			if (x138f3e7bd8930522)
			{
				xd17edb07eea89cb0.x188700e4cffdf544(array2, x0f7b23d1c393aed9, item);
			}
		}
	}

	protected override void RenderLegendForDataPoints(xc48e9faacc88a3d5 legendLayout, xcd7d6e7318ee6574 context)
	{
		if (!xda6252d2884b846f)
		{
			xd17edb07eea89cb0.x44675b8bc366701b(x8d84f385c1b12408, x138f3e7bd8930522, legendLayout, context);
		}
		else
		{
			base.RenderLegendForDataPoints(legendLayout, context);
		}
	}

	protected override void RenderLegendForSeries(xc48e9faacc88a3d5 legendLayut, xcd7d6e7318ee6574 context)
	{
		if (!xda6252d2884b846f)
		{
			xd17edb07eea89cb0.xbdcf7a2be6955201(x8d84f385c1b12408, x138f3e7bd8930522, legendLayut, context);
		}
		else
		{
			base.RenderLegendForSeries(legendLayut, context);
		}
	}
}
