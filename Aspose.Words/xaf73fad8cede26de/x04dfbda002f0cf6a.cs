using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xaf73fad8cede26de;

internal class x04dfbda002f0cf6a
{
	private const double x1e18a3dfec50213f = 48.0;

	private bool x97fbbfa3e06734e6;

	private readonly x22a2c6bbecd8ed7a x8cedcaa9a62c6e39;

	private readonly x49c255776a98e55d xc93b6581011d6dcb;

	private readonly bool x364eb5e9303fee84;

	private int xe11710c1ff496b9a;

	internal x04dfbda002f0cf6a(x22a2c6bbecd8ed7a wpfContext, x49c255776a98e55d fiexdPageWriter, bool isXps)
	{
		x8cedcaa9a62c6e39 = wpfContext;
		xc93b6581011d6dcb = fiexdPageWriter;
		x364eb5e9303fee84 = isXps;
	}

	internal void x804b2039ae4e9b33(int x39b5532b4ddc40a3, float x9b0739496f8b5475, float x4d5aabc7a55b12ba)
	{
		xe11710c1ff496b9a = x39b5532b4ddc40a3;
		if (x364eb5e9303fee84)
		{
			xc93b6581011d6dcb.x9b9ed0109b743e3b("FixedPage");
		}
		else
		{
			xc93b6581011d6dcb.x2307058321cdb62f("FixedPage");
		}
		if (x364eb5e9303fee84)
		{
			xc93b6581011d6dcb.xff520a0047c27122("xmlns", "http://schemas.microsoft.com/xps/2005/06");
			xc93b6581011d6dcb.xff520a0047c27122("xmlns:x", "http://schemas.microsoft.com/xps/2005/06/resourcedictionary-key");
		}
		xc93b6581011d6dcb.xff520a0047c27122("xml:lang", "en-us");
		xc93b6581011d6dcb.xff520a0047c27122("Width", x81932a3e602d1e05(x9b0739496f8b5475));
		xc93b6581011d6dcb.xff520a0047c27122("Height", x81932a3e602d1e05(x4d5aabc7a55b12ba));
		xc93b6581011d6dcb.xff520a0047c27122("Name", $"Page{x39b5532b4ddc40a3}");
		if (x0d299f323d241756.x5959bccb67bbf051(x8cedcaa9a62c6e39.xb444c09fa044bbca.xc605b5c8a6696acf) && x364eb5e9303fee84)
		{
			xc93b6581011d6dcb.x5222f4285e37d66b.WriteComment($"Generated by {x8cedcaa9a62c6e39.xb444c09fa044bbca.xc605b5c8a6696acf}");
		}
		xc93b6581011d6dcb.x2307058321cdb62f("Canvas");
		x54366fa5f75a02f7 x54366fa5f75a02f = new x54366fa5f75a02f7();
		x54366fa5f75a02f.x5152a5707921c783(1.3333334f, 1.3333334f, MatrixOrder.Prepend);
		xc93b6581011d6dcb.xff520a0047c27122("RenderTransform", x54366fa5f75a02f);
	}

	private static double x81932a3e602d1e05(float x015a245ca1df8243)
	{
		double num = x7a02f1cfc55b8a6a.xef598e966b5dee6f(x015a245ca1df8243);
		if (!(num > 48.0))
		{
			return 48.0;
		}
		return num;
	}

	internal void xa0cf4a18229be519()
	{
		xc93b6581011d6dcb.x2dfde153f4ef96d0();
		if (x364eb5e9303fee84)
		{
			xc93b6581011d6dcb.xa0dfc102c691b11f();
		}
		else
		{
			xc93b6581011d6dcb.x2dfde153f4ef96d0();
		}
	}

	internal void xfb4a02d17cf55f9b(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		xc93b6581011d6dcb.x2307058321cdb62f("Canvas");
		if (x08ce8f4769eb3234.xc9bcfb2d9630b0c7 != null)
		{
			x0e8d5ed901dc5683(x08ce8f4769eb3234.xc9bcfb2d9630b0c7);
			xc93b6581011d6dcb.xff520a0047c27122("FixedPage.NavigateUri", x46198c3f24f2fdc4(x08ce8f4769eb3234.xc9bcfb2d9630b0c7));
		}
		if (x08ce8f4769eb3234.x52dde376accdec7d != null)
		{
			xc93b6581011d6dcb.xff520a0047c27122("RenderTransform", x08ce8f4769eb3234.x52dde376accdec7d);
		}
		if (x8d3fa2cc884e0af4.x2f7838697f3bd577(x08ce8f4769eb3234))
		{
			x4ff8ecf10eb0714f x4ff8ecf10eb0714f = new x4ff8ecf10eb0714f();
			xc93b6581011d6dcb.xff520a0047c27122("Clip", x4ff8ecf10eb0714f.x38b39e52c8321dc8(x08ce8f4769eb3234.x0e1bf8242ad10272));
		}
	}

	internal void xd23c6c9fd3a6fa74()
	{
		xc93b6581011d6dcb.x2dfde153f4ef96d0();
	}

	internal void x9e85ecf25cca82ee(xab391c46ff9a0a38 xe125219852864557)
	{
		x97fbbfa3e06734e6 = x941a3106af7ce3e9.x9e85ecf25cca82ee(xc93b6581011d6dcb, x8cedcaa9a62c6e39, xe125219852864557);
	}

	internal void x8e20e5f3afd31049()
	{
		if (x97fbbfa3e06734e6)
		{
			x941a3106af7ce3e9.x8e20e5f3afd31049(xc93b6581011d6dcb);
		}
	}

	internal void xb0eb947f93ab7675(x72c34b8dbaec3734 xaf3288ddace2264d)
	{
		xc93b6581011d6dcb.x2307058321cdb62f("Path");
		if (xaf3288ddace2264d.xc9bcfb2d9630b0c7 != null)
		{
			x0e8d5ed901dc5683(xaf3288ddace2264d.xc9bcfb2d9630b0c7);
			xc93b6581011d6dcb.xff520a0047c27122("FixedPage.NavigateUri", x46198c3f24f2fdc4(xaf3288ddace2264d.xc9bcfb2d9630b0c7));
		}
		xab391c46ff9a0a38 xe125219852864557 = xab391c46ff9a0a38.x7c89cd07f845b8e1(new RectangleF(xaf3288ddace2264d.xc22eade24b085d91, xaf3288ddace2264d.x437e3b626c0fdd43));
		x4ff8ecf10eb0714f x4ff8ecf10eb0714f = new x4ff8ecf10eb0714f();
		xc93b6581011d6dcb.xff520a0047c27122("Data", x4ff8ecf10eb0714f.x38b39e52c8321dc8(xe125219852864557));
		if (xaf3288ddace2264d.x1fa52d87045f9b01 != null)
		{
			x108edf828da9689b(xaf3288ddace2264d);
		}
		xc93b6581011d6dcb.x2307058321cdb62f("Path.Fill");
		xeb4cb9e320b75151.x927e197c87ba6884(xc93b6581011d6dcb, x8cedcaa9a62c6e39, xaf3288ddace2264d.xcc18177a965e0313, xaf3288ddace2264d.x4d7261a5f7f6e09c, xaf3288ddace2264d.x6ae4612a8469678e, WrapMode.Clamp, null);
		xc93b6581011d6dcb.x2dfde153f4ef96d0();
		xc93b6581011d6dcb.x2dfde153f4ef96d0();
	}

	internal void x99f8d80c87f330aa(xcc8c7739d82c63ba x199c511544621683)
	{
		string xb41faee6912a = xc93b6581011d6dcb.x80134a53bcbb9665(x199c511544621683.Text);
		xb41faee6912a = x8cedcaa9a62c6e39.x312d56bccab33f07(x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3, xb41faee6912a);
		string xbcea506a33cf = x8cedcaa9a62c6e39.x1a95937351d48673(x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3, xb41faee6912a);
		if (x0d299f323d241756.x5959bccb67bbf051(xb41faee6912a))
		{
			xb41faee6912a = (xb41faee6912a.StartsWith("{") ? ("{}" + xb41faee6912a) : xb41faee6912a);
			xc93b6581011d6dcb.x2307058321cdb62f("Glyphs");
			xc93b6581011d6dcb.xff520a0047c27122("OriginX", x199c511544621683.xc22eade24b085d91.X);
			xc93b6581011d6dcb.xff520a0047c27122("OriginY", x199c511544621683.xc22eade24b085d91.Y);
			xc93b6581011d6dcb.xff520a0047c27122("UnicodeString", xb41faee6912a);
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
			{
				xc93b6581011d6dcb.xff520a0047c27122("Indices", xbcea506a33cf);
			}
			if (x199c511544621683.xf09329ffe2ab2695 != x26d9ecb4bdf0456d.x45260ad4b94166f2)
			{
				x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x13efdeb5b4f0d186, $"Rendering of Outlined and Embossed text is not supported upon exporting to XPS. Text will be rendered as normal text. Page {xe11710c1ff496b9a}.");
			}
			x26d9ecb4bdf0456d xbcea506a33cf2 = ((!x199c511544621683.x9b41425268471380.x7149c962c02931b3) ? x199c511544621683.x9b41425268471380 : (x199c511544621683.xf09329ffe2ab2695.x7149c962c02931b3 ? x26d9ecb4bdf0456d.x89fffa2751fdecbe : x199c511544621683.xf09329ffe2ab2695));
			xc93b6581011d6dcb.xff520a0047c27122("Fill", xbcea506a33cf2);
			xc93b6581011d6dcb.xff520a0047c27122("FontRenderingEmSize", x199c511544621683.xc2d4efc42998d87b.x53531537bb3331e6);
			string xbcea506a33cf3 = x8cedcaa9a62c6e39.x68949e659a0029db(x199c511544621683.xc2d4efc42998d87b.x29f65b3e7616f6b3);
			xc93b6581011d6dcb.xff520a0047c27122("FontUri", xbcea506a33cf3);
			string xbcea506a33cf4 = xe0ff1640a7105634(x199c511544621683.xc2d4efc42998d87b);
			if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf4))
			{
				xc93b6581011d6dcb.xff520a0047c27122("StyleSimulations", xbcea506a33cf4);
			}
			if (x199c511544621683.x52dde376accdec7d != null)
			{
				xc93b6581011d6dcb.xff520a0047c27122("RenderTransform", x199c511544621683.x52dde376accdec7d);
			}
			if (x199c511544621683.x0e1bf8242ad10272 != null)
			{
				x4ff8ecf10eb0714f x4ff8ecf10eb0714f = new x4ff8ecf10eb0714f();
				xc93b6581011d6dcb.xff520a0047c27122("Clip", x4ff8ecf10eb0714f.x38b39e52c8321dc8(x199c511544621683.x0e1bf8242ad10272));
			}
			if (x199c511544621683.xc9bcfb2d9630b0c7 != null)
			{
				x0e8d5ed901dc5683(x199c511544621683.xc9bcfb2d9630b0c7);
				xc93b6581011d6dcb.xff520a0047c27122("FixedPage.NavigateUri", x46198c3f24f2fdc4(x199c511544621683.xc9bcfb2d9630b0c7));
			}
			xc93b6581011d6dcb.x2dfde153f4ef96d0();
		}
	}

	internal void x7db09d025a6abf05(string xd17ec8f278d25c87, PointF x0c16b19696d9614b)
	{
		xc93b6581011d6dcb.x2307058321cdb62f("Path");
		xc93b6581011d6dcb.xff520a0047c27122("Name", xd17ec8f278d25c87);
		string xbcea506a33cf = $"M {xca004f56614e2431.x37804260a70f74eb(x0c16b19696d9614b.X)},{xca004f56614e2431.x37804260a70f74eb(x0c16b19696d9614b.Y)}";
		xc93b6581011d6dcb.xff520a0047c27122("Data", xbcea506a33cf);
		xc93b6581011d6dcb.xff520a0047c27122("Fill", x26d9ecb4bdf0456d.x45260ad4b94166f2);
		xc93b6581011d6dcb.x2dfde153f4ef96d0();
	}

	private static string xe0ff1640a7105634(xe39d06eee35dd23d x26094932cf7a9139)
	{
		if (x26094932cf7a9139.x30c7b3201d032345 && x26094932cf7a9139.xda4c813a32b9109b)
		{
			return "BoldItalicSimulation";
		}
		if (x26094932cf7a9139.x30c7b3201d032345)
		{
			return "BoldSimulation";
		}
		if (x26094932cf7a9139.xda4c813a32b9109b)
		{
			return "ItalicSimulation";
		}
		return "";
	}

	private string x46198c3f24f2fdc4(xa702b771604efc86 xe0abc8f59346647b)
	{
		if (!xe0abc8f59346647b.x23ae6e0c44b8e6a2)
		{
			return xe0abc8f59346647b.x42f4c234c9358072;
		}
		return string.Format(x364eb5e9303fee84 ? "../FixedDocument.fdoc#{0}" : "#{0}", x8cedcaa9a62c6e39.x94f739530d38cc0a(xe0abc8f59346647b.x42f4c234c9358072));
	}

	private void x108edf828da9689b(x72c34b8dbaec3734 xaf3288ddace2264d)
	{
		xc93b6581011d6dcb.x2307058321cdb62f("Path.OpacityMask");
		using (x3cd5d648729cd9b6 x3cd5d648729cd9b = new x3cd5d648729cd9b6(xaf3288ddace2264d.xcc18177a965e0313))
		{
			x3cd5d648729cd9b.xd9fb93ed9b732074(xaf3288ddace2264d.x1fa52d87045f9b01);
			using MemoryStream memoryStream = new MemoryStream();
			x3cd5d648729cd9b.x0acd3c2012ea2ee8(memoryStream, xfe2ff3c162b47c70.x6339cdb9e2b512c7);
			xeb4cb9e320b75151.x927e197c87ba6884(xc93b6581011d6dcb, x8cedcaa9a62c6e39, memoryStream.ToArray(), xaf3288ddace2264d.x4d7261a5f7f6e09c, xaf3288ddace2264d.x6ae4612a8469678e, WrapMode.Clamp, null);
		}
		xc93b6581011d6dcb.x2dfde153f4ef96d0();
	}

	private void x0e8d5ed901dc5683(xa702b771604efc86 xe0abc8f59346647b)
	{
		if (x0d4d45882065c63e.x4602b59392dc27e9(xe0abc8f59346647b.x42f4c234c9358072))
		{
			x8cedcaa9a62c6e39.xbbf9a1ead81dd3a1(x6d058fdf61831c39.x65def832e35c82b0, $"Hyperlinks to local resources can crash XPS viewer. This is a bug in XPS viewer. Page {xe11710c1ff496b9a}.");
		}
	}
}
