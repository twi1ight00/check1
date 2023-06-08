using xcb49d7911c704e1a;

namespace x4f4df92b75ba3b67;

internal class x9e65c8722a39afe5 : x264ba3b7aca691be
{
	private const x0044309004b99510 x3c4c05b0d8dd25d4 = x0044309004b99510.x390726cc4d638c9c;

	private const x8424217194953834 xbbcd2474a04f5533 = x8424217194953834.x3b69e896556f1925;

	private x3a8cfc6f629fbbd3 xec2297a63dfcbffc;

	private x0044309004b99510 xa59f1dbe3362397a;

	private x8424217194953834 xf396cb6622d27607;

	private readonly x088a7b5025029c50 x4f6190ffbf116eda;

	private readonly xf86e577c4526d9a1 xf946812819fdb8f4;

	private x549f79f24c147bbf x40d7aed21dea62fa;

	private xab49962e520ab86b xb6569d9ce570d53f;

	private x556ab440136df1a4 xbfe35241721d6339;

	private xefea0dbd2f603b8d x7f8fceb96199429c;

	internal x088a7b5025029c50 x09ed8d79c4ca4609 => x4f6190ffbf116eda;

	internal xf86e577c4526d9a1 x93e68a44438355fd => xf946812819fdb8f4;

	internal x0044309004b99510 xabeecde5328505ea
	{
		get
		{
			return xa59f1dbe3362397a;
		}
		set
		{
			xa59f1dbe3362397a = value;
		}
	}

	internal x556ab440136df1a4 x3a60bb04bce53320
	{
		get
		{
			if (xbfe35241721d6339 == null)
			{
				xbfe35241721d6339 = new x556ab440136df1a4(x8cedcaa9a62c6e39);
			}
			return xbfe35241721d6339;
		}
	}

	private bool x623c2908dd2ce5e9 => xbfe35241721d6339 != null;

	internal x3a8cfc6f629fbbd3 xb0cbdf6b726de026
	{
		get
		{
			if (xec2297a63dfcbffc == null)
			{
				xec2297a63dfcbffc = new x3a8cfc6f629fbbd3(x8cedcaa9a62c6e39);
			}
			return xec2297a63dfcbffc;
		}
	}

	internal x8424217194953834 x8c5715ff65c8019b
	{
		get
		{
			return xf396cb6622d27607;
		}
		set
		{
			xf396cb6622d27607 = value;
		}
	}

	internal x9e65c8722a39afe5(x4882ae789be6e2ef context)
		: base(context)
	{
		x4f6190ffbf116eda = new x088a7b5025029c50(context);
		xf946812819fdb8f4 = new xf86e577c4526d9a1(context);
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e)
		{
			x40d7aed21dea62fa = new x549f79f24c147bbf(x8cedcaa9a62c6e39);
			xb6569d9ce570d53f = new xab49962e520ab86b(x8cedcaa9a62c6e39);
		}
		else if (x8cedcaa9a62c6e39.x73979cef1002ed01.xba780c56881ff4f7)
		{
			xb6569d9ce570d53f = new xab49962e520ab86b(x8cedcaa9a62c6e39);
		}
	}

	public override void WriteToPdf(x4f40d990d5bf81a6 writer)
	{
		writer.x1c638d277561c422(xbfbb1719d4106af2());
		writer.x7a67b9beb30292d6(this);
		writer.xafb7e6f79ed43681();
		writer.xa4dc0ad8886e23a2("/Type", "/Catalog");
		writer.xa4dc0ad8886e23a2("/Pages", x4f6190ffbf116eda.x899a2110a8a35fda);
		writer.xa4dc0ad8886e23a2("/Outlines", xf946812819fdb8f4.x899a2110a8a35fda);
		if (!xf946812819fdb8f4.x7149c962c02931b3)
		{
			writer.xa4dc0ad8886e23a2("/PageMode", "/UseOutlines");
		}
		if (xec2297a63dfcbffc != null)
		{
			writer.xa4dc0ad8886e23a2("/ViewerPreferences", xec2297a63dfcbffc.x899a2110a8a35fda);
		}
		if (xa59f1dbe3362397a != 0)
		{
			writer.xa4dc0ad8886e23a2("/PageLayout", xb4f4824af7c55e3a.xa55b2706402c939d(xa59f1dbe3362397a));
		}
		if (xf396cb6622d27607 != 0)
		{
			writer.xa4dc0ad8886e23a2("/PageMode", xb4f4824af7c55e3a.xe7c427215108f919(xf396cb6622d27607));
			if (x8c5715ff65c8019b == x8424217194953834.x87c541fd77da92d8)
			{
				xb0cbdf6b726de026.xcbd6c6bf927b346a = true;
			}
		}
		if (x623c2908dd2ce5e9)
		{
			writer.xa4dc0ad8886e23a2("/AcroForm", x3a60bb04bce53320.x899a2110a8a35fda);
		}
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e)
		{
			writer.xa4dc0ad8886e23a2("/Metadata", xb6569d9ce570d53f.x899a2110a8a35fda);
			writer.xa4dc0ad8886e23a2("/OutputIntents", " ");
			writer.x6210059f049f0d48("[");
			writer.xafb7e6f79ed43681();
			writer.xa4dc0ad8886e23a2("/Type", "/OutputIntent");
			writer.xe8d35135edabe74c("/Info", "sRGB IEC61966-2.1", xf9aaf5b23109516c: true);
			writer.xa4dc0ad8886e23a2("/S", "/GTS_PDFA1");
			writer.xe8d35135edabe74c("/OutputConditionIdentifier", "Custom", xf9aaf5b23109516c: true);
			writer.xa4dc0ad8886e23a2("/DestOutputProfile", x40d7aed21dea62fa.x899a2110a8a35fda);
			writer.x693a8d6d020474f2();
			writer.x6210059f049f0d48("]");
		}
		else if (x8cedcaa9a62c6e39.x73979cef1002ed01.xba780c56881ff4f7)
		{
			writer.xa4dc0ad8886e23a2("/Metadata", xb6569d9ce570d53f.x899a2110a8a35fda);
		}
		if (x8cedcaa9a62c6e39.x73979cef1002ed01.xa8c6944aca2d6edc)
		{
			writer.x6210059f049f0d48("/OpenAction ");
			x3b40d431d373c41d destination = ((x8cedcaa9a62c6e39.x73979cef1002ed01.x6912ee5d48e468f3 == x966e2af2b1e11692.xccd14b62af842293) ? x3b40d431d373c41d.x56ffee0dbe7d977d(x09ed8d79c4ca4609.xbcf8e06f8b5cefff(), 0f, 0f, x8cedcaa9a62c6e39.x73979cef1002ed01.xd83c2eee63f2eabf) : new x3b40d431d373c41d(x09ed8d79c4ca4609.xbcf8e06f8b5cefff(), x8cedcaa9a62c6e39.x73979cef1002ed01.x6912ee5d48e468f3));
			x7f8fceb96199429c = new xefea0dbd2f603b8d(destination);
			x7f8fceb96199429c.x10f3680c04d77f08(writer);
		}
		writer.x693a8d6d020474f2();
		writer.x5155d7b9dab28280();
		if (xec2297a63dfcbffc != null)
		{
			xec2297a63dfcbffc.WriteToPdf(writer);
		}
		if (x623c2908dd2ce5e9)
		{
			x3a60bb04bce53320.WriteToPdf(writer);
		}
		x4f6190ffbf116eda.WriteToPdf(writer);
		xf946812819fdb8f4.x10f3680c04d77f08(writer);
		if (x8cedcaa9a62c6e39.x5ba9693d4c3c102e)
		{
			x40d7aed21dea62fa.WriteToPdf(writer);
			xb6569d9ce570d53f.x3cb9052d058ce73a = false;
			xb6569d9ce570d53f.WriteToPdf(writer);
		}
		else if (x8cedcaa9a62c6e39.x73979cef1002ed01.xba780c56881ff4f7)
		{
			xb6569d9ce570d53f.x3cb9052d058ce73a = true;
			xb6569d9ce570d53f.WriteToPdf(writer);
		}
	}
}
