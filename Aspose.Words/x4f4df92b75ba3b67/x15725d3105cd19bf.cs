using System.Drawing;
using System.IO;
using x1c8faa688b1f0b0c;

namespace x4f4df92b75ba3b67;

internal class x15725d3105cd19bf : xf5cfd3a839b4ec91
{
	private const bool xeb55072a14c0f6b6 = false;

	private const string x8f13e1948ce78d1c = "/On";

	private const string x36fb8ba5df69c164 = "/Off";

	private const string xd204702876feb866 = "0 G ";

	private readonly bool xe3fa775672cbbfc7;

	private x8b1c15f4cec97314 x3c48212bd7e8ac85;

	private x8b1c15f4cec97314 xb98bbebc58b2ad9a;

	internal x15725d3105cd19bf(xd6b2a42851fedfba hostPage, xf8b7d3491a4bc1b0 source)
		: base(hostPage, source)
	{
		xe3fa775672cbbfc7 = source.xd2f68ee6f47e9dfb;
		x109a5b5bb236ce20();
	}

	protected override x4f47636462fbf23a GetFieldType()
	{
		return x4f47636462fbf23a.x9ed3ae88738319ae;
	}

	protected override void WriteFieldSpecificDictionaryEntries(x4f40d990d5bf81a6 writer)
	{
		if (xe3fa775672cbbfc7)
		{
			writer.xa4dc0ad8886e23a2(xf5cfd3a839b4ec91.x4d7648648a11f443, xe3fa775672cbbfc7 ? "/On" : "/Off");
		}
		writer.x6210059f049f0d48(xf5cfd3a839b4ec91.x2f83359518b6600c);
		writer.xafb7e6f79ed43681();
		writer.x6210059f049f0d48(xf5cfd3a839b4ec91.x22c40f2843e791e9);
		writer.xafb7e6f79ed43681();
		writer.x241b3c2e8c3aaa86("/Off");
		writer.x241b3c2e8c3aaa86(xb98bbebc58b2ad9a.x899a2110a8a35fda);
		writer.x241b3c2e8c3aaa86("/On");
		writer.x241b3c2e8c3aaa86(x3c48212bd7e8ac85.x899a2110a8a35fda);
		writer.x693a8d6d020474f2();
		writer.x693a8d6d020474f2();
		writer.xa4dc0ad8886e23a2(xf5cfd3a839b4ec91.x4b6072d29bc4fcc0, xe3fa775672cbbfc7 ? "/On" : "/Off");
	}

	protected override void WriteFieldSpecificObjects(x4f40d990d5bf81a6 writer)
	{
		x3c48212bd7e8ac85.WriteToPdf(writer);
		xb98bbebc58b2ad9a.WriteToPdf(writer);
	}

	private void x109a5b5bb236ce20()
	{
		RectangleF xda73fcb97c77d = new RectangleF(0f, 0f, base.x2727839aafc09868.Width, base.x2727839aafc09868.Height);
		xb98bbebc58b2ad9a = new x8b1c15f4cec97314(x8cedcaa9a62c6e39);
		xb98bbebc58b2ad9a.x2727839aafc09868 = xda73fcb97c77d;
		xb98bbebc58b2ad9a.xe36c96d8c564b382 = new MemoryStream();
		xcd769e39c0788209 xbdfb620b7167944b = new xcd769e39c0788209(xb98bbebc58b2ad9a.xe36c96d8c564b382);
		xf5cfd3a839b4ec91.x47cfb90fdeb56514(xbdfb620b7167944b, xb98bbebc58b2ad9a.x2727839aafc09868);
		x3c48212bd7e8ac85 = new x8b1c15f4cec97314(x8cedcaa9a62c6e39);
		x3c48212bd7e8ac85.x2727839aafc09868 = xda73fcb97c77d;
		x3c48212bd7e8ac85.xe36c96d8c564b382 = new MemoryStream();
		xcd769e39c0788209 xbdfb620b7167944b2 = new xcd769e39c0788209(x3c48212bd7e8ac85.xe36c96d8c564b382);
		xf5cfd3a839b4ec91.x47cfb90fdeb56514(xbdfb620b7167944b2, xda73fcb97c77d);
		xbd1d1b66ff5ae3a6(xbdfb620b7167944b2, xda73fcb97c77d);
	}

	private static void xbd1d1b66ff5ae3a6(xcd769e39c0788209 xbdfb620b7167944b, RectangleF xda73fcb97c77d998)
	{
		xbdfb620b7167944b.x6210059f049f0d48("0 G ");
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Left);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Top);
		xbdfb620b7167944b.x6210059f049f0d48(xf5cfd3a839b4ec91.x49a3b5016b66cfd5);
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Right);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Bottom);
		xbdfb620b7167944b.x6210059f049f0d48(xf5cfd3a839b4ec91.x931898f64633e130);
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Left);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Bottom);
		xbdfb620b7167944b.x6210059f049f0d48(xf5cfd3a839b4ec91.x49a3b5016b66cfd5);
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Right);
		xbdfb620b7167944b.xe7b920de107da0c7();
		xbdfb620b7167944b.x6210059f049f0d48(xda73fcb97c77d998.Top);
		xbdfb620b7167944b.x6210059f049f0d48(xf5cfd3a839b4ec91.x931898f64633e130);
	}
}
