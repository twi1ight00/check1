using System.Collections;
using x1c8faa688b1f0b0c;
using x66dd9eaee57cfba4;
using x6c95d9cf46ff5f25;

namespace x7dc87ca8f7f7b273;

internal class x3363b5fd92e52a33 : xc7a77b17ac8b122b
{
	private readonly x3c74b3c4f21844f9 x9b287b671d592594;

	public x3363b5fd92e52a33(xd878af0d0717b77a context, x3c74b3c4f21844f9 writer)
		: base(context)
	{
		x9b287b671d592594 = ((writer == null) ? context.x5aa326f374b3d0ef : writer);
	}

	public void xc4d46ec64ab4b74a(xcd986872cf3bcf68 xdf4e8adcb2e5e03b)
	{
		x6b1a899052c71a60 x29f65b3e7616f6b = xdf4e8adcb2e5e03b.x29f65b3e7616f6b3;
		string xbcea506a33cf = base.x28fcdc775a1d069c.x4a59854a1bae262a(x29f65b3e7616f6b);
		x9b287b671d592594.x2307058321cdb62f("font");
		x9b287b671d592594.xff520a0047c27122("id", xbcea506a33cf);
		x9b287b671d592594.xff520a0047c27122("horiz-adv-x", x29e43e97a14c50f5(x29f65b3e7616f6b.x11f73230b9b436a7, x29f65b3e7616f6b).ToString());
		x9b287b671d592594.x2307058321cdb62f("font-face");
		x9b287b671d592594.xff520a0047c27122("font-family", x29f65b3e7616f6b.x6054c4379c01a50d);
		x9b287b671d592594.xff520a0047c27122("font-weight", x3ee81b8db87b7dc2.x917c5a6cdc05561e(x29f65b3e7616f6b.xfe2178c1f916f36c));
		x9b287b671d592594.xff520a0047c27122("font-style", x3ee81b8db87b7dc2.x32b37ded42f44b0e(x29f65b3e7616f6b.xfe2178c1f916f36c));
		x9b287b671d592594.xff520a0047c27122("units-per-em", "20480");
		x9b287b671d592594.xff520a0047c27122("cap-height", x29e43e97a14c50f5(x29f65b3e7616f6b.x912ee4c8583acc0f, x29f65b3e7616f6b).ToString());
		x9b287b671d592594.xff520a0047c27122("x-height", x29e43e97a14c50f5(x29f65b3e7616f6b.xb0f146032f47c24e, x29f65b3e7616f6b).ToString());
		x9b287b671d592594.xff520a0047c27122("ascent", x29e43e97a14c50f5(x29f65b3e7616f6b.x3f80ed349f729542, x29f65b3e7616f6b).ToString());
		x9b287b671d592594.xff520a0047c27122("descent", x29e43e97a14c50f5(x29f65b3e7616f6b.xc9f7bec53c29c691, x29f65b3e7616f6b).ToString());
		x9b287b671d592594.x2307058321cdb62f("font-face-src");
		x9b287b671d592594.x2307058321cdb62f("font-face-name");
		x9b287b671d592594.xff520a0047c27122("name", x29f65b3e7616f6b.x0a4b32fbe2e5933b);
		x9b287b671d592594.x2dfde153f4ef96d0();
		x9b287b671d592594.x2dfde153f4ef96d0();
		x9b287b671d592594.x2dfde153f4ef96d0();
		xd6b2549ca8b77560(xdf4e8adcb2e5e03b, xdf80fee34d61116f: false);
		x9b287b671d592594.x2dfde153f4ef96d0();
	}

	public void xb395c8e795fac79c(xcd986872cf3bcf68 xdf4e8adcb2e5e03b)
	{
		xd6b2549ca8b77560(xdf4e8adcb2e5e03b, xdf80fee34d61116f: true);
	}

	public static int x29e43e97a14c50f5(int xb0d91e9ccc274d5c, x6b1a899052c71a60 x26094932cf7a9139)
	{
		return x4574ea26106f0edb.x88bf16f2386d633e((float)xb0d91e9ccc274d5c * 1024f / (float)x26094932cf7a9139.xa25a0348a20dc6ca);
	}

	private void xd6b2549ca8b77560(xcd986872cf3bcf68 xdf4e8adcb2e5e03b, bool xdf80fee34d61116f)
	{
		x6b1a899052c71a60 x29f65b3e7616f6b = xdf4e8adcb2e5e03b.x29f65b3e7616f6b3;
		Hashtable glyphsDataSubset = xdf4e8adcb2e5e03b.GetGlyphsDataSubset();
		x4ff8ecf10eb0714f x4ff8ecf10eb0714f = new x4ff8ecf10eb0714f();
		string arg = base.x28fcdc775a1d069c.x4a59854a1bae262a(x29f65b3e7616f6b);
		if (!xdf80fee34d61116f)
		{
			x5ddcd7f1136699aa x5ddcd7f1136699aa = (x5ddcd7f1136699aa)glyphsDataSubset[0];
			x9b287b671d592594.x2307058321cdb62f("missing-glyph");
			x9b287b671d592594.xff520a0047c27122("d", x4ff8ecf10eb0714f.x38b39e52c8321dc8(x5ddcd7f1136699aa.x77be53ce49261911(xbd085ec798f2ed62: false)));
			x9b287b671d592594.x2dfde153f4ef96d0();
		}
		for (int i = 0; i < xdf4e8adcb2e5e03b.x8f0b229fb69d4269.xd44988f225497f3a; i++)
		{
			int num = xdf4e8adcb2e5e03b.x8f0b229fb69d4269.xf15263674eb297bb(i);
			int num2 = (int)xdf4e8adcb2e5e03b.x8f0b229fb69d4269.x6d3720b962bd3112(i);
			x5ddcd7f1136699aa x5ddcd7f1136699aa2 = (x5ddcd7f1136699aa)glyphsDataSubset[num2];
			if (xdf80fee34d61116f)
			{
				x9b287b671d592594.x2307058321cdb62f("path");
				x9b287b671d592594.xff520a0047c27122("id", $"{arg}c{num}");
			}
			else
			{
				x9b287b671d592594.x2307058321cdb62f("glyph");
				x9b287b671d592594.xff520a0047c27122("unicode", xdf3a1f89dca325a3.x251dbcb3221739c5(num));
				x9b287b671d592594.xff520a0047c27122("horiz-adv-x", x29e43e97a14c50f5(x29f65b3e7616f6b.x1e6da4134d115607.x12f49b36ab885c48(num).xf58adb71a3d2dade, x29f65b3e7616f6b).ToString());
			}
			x9b287b671d592594.xff520a0047c27122("d", (num != 32) ? x4ff8ecf10eb0714f.x38b39e52c8321dc8(x5ddcd7f1136699aa2.x77be53ce49261911(xdf80fee34d61116f)) : "M0,0");
			x9b287b671d592594.x2dfde153f4ef96d0();
		}
	}
}
