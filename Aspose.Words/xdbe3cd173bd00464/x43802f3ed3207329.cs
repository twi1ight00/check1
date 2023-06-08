using Aspose.Words;
using x1a3e96f4b89a7a77;
using x28925c9b27b37a46;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace xdbe3cd173bd00464;

internal class x43802f3ed3207329
{
	private readonly Document xd1424e1a0bb4a72b;

	private readonly x873451caae5ad4ae x800085dd555f7711;

	private readonly x9df536d98415d2d0 xa737d500a7554634;

	internal x43802f3ed3207329(Document document, x873451caae5ad4ae builder, x9df536d98415d2d0 fontColorResolver)
	{
		xd1424e1a0bb4a72b = document;
		x800085dd555f7711 = builder;
		xa737d500a7554634 = fontColorResolver;
	}

	internal void x486167d7a74e8e88(Font x26094932cf7a9139, string xb41faee6912a2313)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a2313))
		{
			x800085dd555f7711.x2307058321cdb62f("Run");
			xc946ba15e395060e.x96072a935905c3fb(x800085dd555f7711, x26094932cf7a9139, xa737d500a7554634, xb36a059a5e87b854: false);
			x6b1a899052c71a60 x6b1a899052c71a = xd1424e1a0bb4a72b.FontInfos.x26ee10d60756aeab.FetchTTFont(x26094932cf7a9139.xaf95fb496eb25433(x000f21cbda739311.x175297738c8b8d1e), x26094932cf7a9139.xfa47517dba72fd20, null);
			xb41faee6912a2313 = x6b1a899052c71a.x839c39284cd04767(xb41faee6912a2313);
			x800085dd555f7711.x3d1be38abe5723e3(xb41faee6912a2313);
			x800085dd555f7711.x2dfde153f4ef96d0();
		}
	}
}
