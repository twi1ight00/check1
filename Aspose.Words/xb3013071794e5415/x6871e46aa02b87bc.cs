using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using xad5c68c1ad3b0224;
using xcc8a79815d76af85;

namespace xb3013071794e5415;

internal class x6871e46aa02b87bc : x66e735b434e6b412
{
	private xd0ef1fdf136f2b44 xccf14f66d4cf2d79;

	public x6871e46aa02b87bc(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		xccf14f66d4cf2d79 = (xd0ef1fdf136f2b44)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		foreach (x9b87766ad1dbe8d6 item in xccf14f66d4cf2d79.xc869533ad93d98d3)
		{
			xe338941ac34e9d17[] array = x2218c6a5642c78e2(item, (x7f6e105e40e31dae)x7458794d854f9b68);
			for (int i = 0; i < array.Length; i++)
			{
				xe338941ac34e9d17 xe338941ac34e9d18 = array[i];
				RectangleF xefa4262da9bfb09c = new RectangleF(xe338941ac34e9d18.x865739e9b580d3cf.X - xe338941ac34e9d18.x437e3b626c0fdd43 / 2f, xe338941ac34e9d18.x865739e9b580d3cf.Y - xe338941ac34e9d18.x437e3b626c0fdd43 / 2f, xe338941ac34e9d18.x437e3b626c0fdd43, xe338941ac34e9d18.x437e3b626c0fdd43);
				xab391c46ff9a0a38 xda5bf54deb817e = x74fee75126f547da(item, xefa4262da9bfb09c, x0f7b23d1c393aed9, item.x320382c5f1993a78.get_xe6d4b1b411ed94b5(i));
				x0f7b23d1c393aed9.xc9443bca5b0a56d8.xd6b6ed77479ef68c(xda5bf54deb817e);
			}
		}
	}

	protected override void RenderLegendForDataPoints(xc48e9faacc88a3d5 legendLayout, xcd7d6e7318ee6574 context)
	{
		x9b87766ad1dbe8d6 x9b87766ad1dbe8d = (x9b87766ad1dbe8d6)xccf14f66d4cf2d79.xc869533ad93d98d3[0];
		if (x9b87766ad1dbe8d.x320382c5f1993a78.xddf2b5348950b232)
		{
			string[] array = x66e735b434e6b412.x785802445639dd33(xccf14f66d4cf2d79, x9b87766ad1dbe8d);
			for (int i = 0; i < array.Length; i++)
			{
				xab391c46ff9a0a38 x8f2400368d1c57d = x74fee75126f547da(x9b87766ad1dbe8d, legendLayout.xc49ca4c0d3cc766e, context, x9b87766ad1dbe8d.x320382c5f1993a78.get_xe6d4b1b411ed94b5(i));
				legendLayout.xd7d75c376e5ae843(x8f2400368d1c57d, array[i]);
			}
		}
		else
		{
			RenderLegendForSeries(legendLayout, context);
		}
	}

	protected override void RenderLegendForSeries(xc48e9faacc88a3d5 legendLayut, xcd7d6e7318ee6574 context)
	{
		foreach (x9b87766ad1dbe8d6 item in xccf14f66d4cf2d79.xc869533ad93d98d3)
		{
			xab391c46ff9a0a38 x8f2400368d1c57d = x74fee75126f547da(item, legendLayut.xc49ca4c0d3cc766e, context, item.x4ccdf3e6468ad446);
			legendLayut.xd7d75c376e5ae843(x8f2400368d1c57d, item.x759aa16c2016a289);
		}
	}

	internal static xab391c46ff9a0a38 x74fee75126f547da(x9b87766ad1dbe8d6 x7acb8518c8ed6133, RectangleF xefa4262da9bfb09c, xcd7d6e7318ee6574 x0f7b23d1c393aed9, x0c3d704ad3ea61a6 x6a2484744dda7709)
	{
		xab391c46ff9a0a38 xab391c46ff9a0a = new xab391c46ff9a0a38();
		x1fb5d45c2d0b868a xc919e9fef7dfced = new x1fb5d45c2d0b868a(xefa4262da9bfb09c);
		x1cab6af0a41b70e2 x1cab6af0a41b70e = new x1cab6af0a41b70e2();
		x1cab6af0a41b70e.xb6e955ab98a0878c(xc919e9fef7dfced);
		xab391c46ff9a0a.xd6b6ed77479ef68c(x1cab6af0a41b70e);
		x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x6a2484744dda7709.xff13b489d81606b6, x0f7b23d1c393aed9.x5e969e12ada2aab2.xa32838f54072b660, x7acb8518c8ed6133.xd1bdf42207dd3638);
		return xab391c46ff9a0a;
	}

	private xe338941ac34e9d17[] x2218c6a5642c78e2(x9b87766ad1dbe8d6 x7acb8518c8ed6133, x7f6e105e40e31dae x7458794d854f9b68)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < x7acb8518c8ed6133.x2205bab75ecf5743; i++)
		{
			x86270791cf6a92b9 x86270791cf6a92b = x7acb8518c8ed6133.x3440cb7904436598.x2206903f9421fd4b(i);
			x86270791cf6a92b9 x86270791cf6a92b2 = x7acb8518c8ed6133.x141ab7d3c1198e04.x2206903f9421fd4b(i);
			x86270791cf6a92b9 x86270791cf6a92b3 = x7acb8518c8ed6133.xf57725658db5c2df.x2206903f9421fd4b(i);
			if (x86270791cf6a92b != null && x86270791cf6a92b2 != null && x86270791cf6a92b3 != null)
			{
				arrayList.Add(new xe338941ac34e9d17(x7458794d854f9b68.x2206903f9421fd4b(x86270791cf6a92b.FloatValue, x86270791cf6a92b2.FloatValue), x7458794d854f9b68.xfbaea77d2f5322dc(x86270791cf6a92b3, xccf14f66d4cf2d79.xc4cfbad937290bb1)));
			}
		}
		xe338941ac34e9d17[] array = new xe338941ac34e9d17[arrayList.Count];
		arrayList.CopyTo(array, 0);
		return array;
	}
}
