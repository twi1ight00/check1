using Aspose;
using x1c8faa688b1f0b0c;
using xad5c68c1ad3b0224;

namespace xb3013071794e5415;

internal abstract class x66e735b434e6b412
{
	private readonly x958ddf7e6db1ce94 xaaa5dc45bb695ced;

	internal x66e735b434e6b412(x958ddf7e6db1ce94 chart)
	{
		xaaa5dc45bb695ced = chart;
	}

	[JavaThrows(true)]
	internal abstract void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9);

	internal void x19858496179c0d1c(xc48e9faacc88a3d5 x07f5d57888ef4f31, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		if (x07f5d57888ef4f31.xf386d5d7dae80a05)
		{
			RenderLegendForDataPoints(x07f5d57888ef4f31, x0f7b23d1c393aed9);
		}
		else
		{
			RenderLegendForSeries(x07f5d57888ef4f31, x0f7b23d1c393aed9);
		}
	}

	protected virtual void RenderLegendForDataPoints(xc48e9faacc88a3d5 legendLayout, xcd7d6e7318ee6574 context)
	{
		x9b87766ad1dbe8d6 x9b87766ad1dbe8d = (x9b87766ad1dbe8d6)xaaa5dc45bb695ced.xc869533ad93d98d3[0];
		string[] array = x785802445639dd33(xaaa5dc45bb695ced, x9b87766ad1dbe8d);
		for (int i = 0; i < array.Length; i++)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(legendLayout.xc49ca4c0d3cc766e);
			x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, x9b87766ad1dbe8d.x320382c5f1993a78.get_xe6d4b1b411ed94b5(i).xff13b489d81606b6, context.x5e969e12ada2aab2.xa32838f54072b660, x9b87766ad1dbe8d.xd1bdf42207dd3638);
			legendLayout.xd7d75c376e5ae843(xab391c46ff9a0a, array[i]);
		}
	}

	protected virtual void RenderLegendForSeries(xc48e9faacc88a3d5 legendLayut, xcd7d6e7318ee6574 context)
	{
		foreach (x9b87766ad1dbe8d6 item in xaaa5dc45bb695ced.xc869533ad93d98d3)
		{
			xab391c46ff9a0a38 xab391c46ff9a0a = xab391c46ff9a0a38.x7c89cd07f845b8e1(legendLayut.xc49ca4c0d3cc766e);
			x318f74746d616ef0.x5bd690fbaae89142(xab391c46ff9a0a, item.x4ccdf3e6468ad446.xff13b489d81606b6, context.x5e969e12ada2aab2.xa32838f54072b660, item.xd1bdf42207dd3638);
			legendLayut.xd7d75c376e5ae843(xab391c46ff9a0a, item.x759aa16c2016a289);
		}
	}

	internal static string[] x785802445639dd33(x958ddf7e6db1ce94 xe640ebcce83ddadc, x9b87766ad1dbe8d6 x7acb8518c8ed6133)
	{
		string[] array = new string[x7acb8518c8ed6133.x2205bab75ecf5743];
		for (int i = 0; i < x7acb8518c8ed6133.x2205bab75ecf5743; i++)
		{
			array[i] = ((xe640ebcce83ddadc is x4457da8976f5f7bc) ? ((x4457da8976f5f7bc)xe640ebcce83ddadc).x47443c66c2e1bad9.xd8b4d728ebd381eb(x7acb8518c8ed6133.x3440cb7904436598.x2206903f9421fd4b(i)) : x7acb8518c8ed6133.x3440cb7904436598.x2206903f9421fd4b(i).StringValue);
		}
		return array;
	}
}
