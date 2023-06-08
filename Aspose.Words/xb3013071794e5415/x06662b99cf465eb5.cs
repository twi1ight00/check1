using System.Drawing;
using x6c95d9cf46ff5f25;
using xad5c68c1ad3b0224;

namespace xb3013071794e5415;

internal class x06662b99cf465eb5 : x66e735b434e6b412
{
	private x5ef2030a2de51c8a x338634e753b404f3;

	public x06662b99cf465eb5(x958ddf7e6db1ce94 chart)
		: base(chart)
	{
		x338634e753b404f3 = (x5ef2030a2de51c8a)chart;
	}

	internal override void xe406325e56f74b46(x43c3197706cb18d9 x7458794d854f9b68, xcd7d6e7318ee6574 x0f7b23d1c393aed9)
	{
		x0f7b23d1c393aed9.xca687bd498227c89.xf69ca7a9bb4a4a51.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x3d55d2f5d9d21184, x3959df40367ac8a3.xc37a0b27f6a0dfd4, "Rendering of surface charts is not supported. Chart will be rendered as line chart.");
		foreach (x9b87766ad1dbe8d6 item in x338634e753b404f3.xc869533ad93d98d3)
		{
			PointF[] x6fa2570084b2ad = x7458794d854f9b68.x466c8609d8f6c6c1(item);
			xd17edb07eea89cb0.x02c01e0bd89aaaa0(x6fa2570084b2ad, x0f7b23d1c393aed9, item, xd925f447ef7e00a4: false, x559292b5f7ade8c2: false);
		}
	}
}
