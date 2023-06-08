using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Words.Saving;
using x28925c9b27b37a46;
using x38a89dee67fc7a16;
using x55b2bd426d41d30c;
using x6c95d9cf46ff5f25;
using xce0136f05681c5e9;
using xf989f31a236ff98c;

namespace x611adfb9b9d21a97;

internal class x75eb89ee42a8f635 : x3d2908992e1d1667
{
	private x8556eed81191af11 xb36c250515e408ad;

	private HtmlSaveOptions x39a547a368d84104;

	private xb08af07e0a146853 x7e24ae8042d3886b;

	private string xe088d3cf86c43aa1;

	private readonly ArrayList xee6dcf91257f44fd = new ArrayList();

	private readonly ArrayList x178ddd705e9f9e3a = new ArrayList();

	private readonly xd345c73dd1b16b74 x28ff454763e2f336 = new xd345c73dd1b16b74();

	private bool xcd5437e9c018b4ce;

	private ArrayList xcb24734d87e68ca7;

	private static readonly Regex xe5f2ce340c75fb4f = new Regex("[^-_a-zA-Z0-9 ]*", RegexOptions.Singleline);

	private SaveOutputParameters x8cac5adfe79bc025(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		xb36c250515e408ad = x5ac1382edb7bf2c2;
		x7e24ae8042d3886b = new xb08af07e0a146853();
		x9e3e28536b8b2456();
		xb0f465f5d9c363bb();
		xf5588de75c0bb67e();
		x4697652cad03e040();
		x4f675f5fc4c7fa47();
		x7e24ae8042d3886b.x0acd3c2012ea2ee8(xb36c250515e408ad.xb8a774e0111d0fbe, "application/epub+zip");
		return new SaveOutputParameters("application/epub+zip");
	}

	SaveOutputParameters x3d2908992e1d1667.xa2e0b7f7da663553(x8556eed81191af11 x5ac1382edb7bf2c2)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x8cac5adfe79bc025
		return this.x8cac5adfe79bc025(x5ac1382edb7bf2c2);
	}

	private void x9e3e28536b8b2456()
	{
		string xbcea506a33cf = xe5f2ce340c75fb4f.Replace(xb36c250515e408ad.x2c8c6741422a1298.BuiltInDocumentProperties.Title.Trim(), string.Empty);
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf))
		{
			xe088d3cf86c43aa1 = xbcea506a33cf;
		}
		else if (x0d299f323d241756.x5959bccb67bbf051(xb36c250515e408ad.xa39af5a82860a9a3))
		{
			xe088d3cf86c43aa1 = Path.GetFileNameWithoutExtension(xb36c250515e408ad.xa39af5a82860a9a3);
		}
		else
		{
			xe088d3cf86c43aa1 = "document";
		}
	}

	private void xf5588de75c0bb67e()
	{
		x78efcb58d03c2f11 x78efcb58d03c2f12 = new x78efcb58d03c2f11(xe088d3cf86c43aa1, xb36c250515e408ad);
		x78efcb58d03c2f12.x95d1f647e5465823();
		x7e24ae8042d3886b.xd6abb2ab950b4d22.xd6b6ed77479ef68c(x78efcb58d03c2f12.x0e063e8407aa6f22);
	}

	private void x4697652cad03e040()
	{
		x78127fc231459d47 x78127fc231459d48 = new x78127fc231459d47(xe088d3cf86c43aa1, xb36c250515e408ad, x178ddd705e9f9e3a, x28ff454763e2f336.GetValueList(), xcd5437e9c018b4ce);
		x78127fc231459d48.x95d1f647e5465823();
		x7e24ae8042d3886b.xd6abb2ab950b4d22.xd6b6ed77479ef68c(x78127fc231459d48.x0e063e8407aa6f22);
	}

	private void x4f675f5fc4c7fa47()
	{
		xbcc7e93175c9b621 xbcc7e93175c9b622 = new xbcc7e93175c9b621(xe088d3cf86c43aa1, xb36c250515e408ad, xcb24734d87e68ca7);
		xbcc7e93175c9b622.x95d1f647e5465823();
		x7e24ae8042d3886b.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xbcc7e93175c9b622.x0e063e8407aa6f22);
	}

	private void xb0f465f5d9c363bb()
	{
		x39a547a368d84104 = ((HtmlSaveOptions)xb36c250515e408ad.xf57de0fd37d5e97d).x8b61531c8ea35b85();
		x39a547a368d84104.ExportXhtmlTransitional = true;
		x39a547a368d84104.ExportTextInputFormFieldAsText = true;
		x39a547a368d84104.xea0d040d38d75a91 = "application/xhtml+xml";
		x39a547a368d84104.xa0d41f9ce07d80f7 = true;
		x39a547a368d84104.x5e55119260398f2a = true;
		x39a547a368d84104.x4e3c1d16eaf20ef3 = true;
		MemoryStream memoryStream = ((x39a547a368d84104.DocumentSplitCriteria == DocumentSplitCriteria.None) ? new MemoryStream() : null);
		x1cfc9afea06d5324 x1cfc9afea06d = new x1cfc9afea06d5324(x39a547a368d84104.EpubNavigationMapLevel);
		xb388353c23101505 xb388353c = new xb388353c23101505();
		x754017e579b6a8ff x754017e579b6a8ff = new x754017e579b6a8ff(xb36c250515e408ad.x2c8c6741422a1298, memoryStream, null, x39a547a368d84104, xb36c250515e408ad.x158c955c749c5e5b, xb388353c, x1cfc9afea06d);
		x754017e579b6a8ff.xa2e0b7f7da663553();
		xad8ffafd83524bab();
		xcd581e7438fd0b82(xb388353c.xd6abb2ab950b4d22);
		x36948ee1b80f7baf(memoryStream);
		xcb24734d87e68ca7 = x1cfc9afea06d.x7e0bf1cc35062bd7;
		xb17a2f6d08626432();
	}

	private void xad8ffafd83524bab()
	{
		byte[] thumbnail = xb36c250515e408ad.x2c8c6741422a1298.BuiltInDocumentProperties.Thumbnail;
		xcd5437e9c018b4ce = xcd4bd3abd72ff2da.x57a8965bf85f0d71(thumbnail);
		if (xcd5437e9c018b4ce)
		{
			xfe2ff3c162b47c70 xfe2ff3c162b47c = xdd1b8f14cc8ba86d.x22bfb60fc9ca9282(thumbnail);
			xf3fc699ed2e317be(xfe2ff3c162b47c);
			string text = xb9015fe823e7e228.xac88cb4f794761a9(xfe2ff3c162b47c);
			string xe11224e032957d = "cover-image." + text;
			x012e4bf98e7e22ad(xe11224e032957d, text, thumbnail);
			xa9c1362d66a1db2a(xe11224e032957d);
		}
	}

	private void xcd581e7438fd0b82(ArrayList xf44d4a7faafc8304)
	{
		foreach (xd59a0d3f8248c4e8 item in xf44d4a7faafc8304)
		{
			xee6dcf91257f44fd.Add(item);
			if (item.x0b93856f95be30d0 == "application/xhtml+xml")
			{
				x178ddd705e9f9e3a.Add(item);
			}
			else
			{
				x28ff454763e2f336.Add(item.xb405a444ca77e2d4, item);
			}
		}
	}

	private void x36948ee1b80f7baf(MemoryStream x8422dcf1a22b02a2)
	{
		if (x8422dcf1a22b02a2 != null)
		{
			xd59a0d3f8248c4e8 value = new x32626c54bb4e8c9e(x39a547a368d84104.Encoding, x39a547a368d84104.xea0d040d38d75a91, xb00f4ba8788bbec8.xe6ef738f4b633cf2(xe088d3cf86c43aa1, x6c20b1df8047763a: true), x0d299f323d241756.xa0aed4cd3b3d5d92(x8422dcf1a22b02a2));
			xee6dcf91257f44fd.Add(value);
			x178ddd705e9f9e3a.Add(value);
		}
	}

	private void xb17a2f6d08626432()
	{
		foreach (xd59a0d3f8248c4e8 item in xee6dcf91257f44fd)
		{
			x0ca5e8b532953a51 xd7e5673853e47af = new x0ca5e8b532953a51("OEBPS/" + item.xb405a444ca77e2d4, item.x878afbafb98bf640());
			x7e24ae8042d3886b.xd6abb2ab950b4d22.xd6b6ed77479ef68c(xd7e5673853e47af);
		}
	}

	private void x012e4bf98e7e22ad(string xe11224e032957d06, string x2b60621e8d97f939, byte[] x43e181e083db6cdf)
	{
		string text = "cover/" + xe11224e032957d06;
		xd59a0d3f8248c4e8 value = new x32626c54bb4e8c9e("image/" + x2b60621e8d97f939, text, x43e181e083db6cdf);
		xee6dcf91257f44fd.Add(value);
		x28ff454763e2f336.Add(text, value);
	}

	private void xa9c1362d66a1db2a(string xe11224e032957d06)
	{
		using MemoryStream memoryStream = new MemoryStream();
		x515d2f71e3e1988e x515d2f71e3e1988e = new x515d2f71e3e1988e(memoryStream, x39a547a368d84104);
		x515d2f71e3e1988e.x6737a86fba7f7993();
		x515d2f71e3e1988e.x2307058321cdb62f("head");
		x515d2f71e3e1988e.x6b73ce92fd8e3f2c("title", "Cover");
		x515d2f71e3e1988e.x4122f10182ac673a("style", "type", "text/css");
		x515d2f71e3e1988e.x3d1be38abe5723e3("body { text-align: center; padding:0pt; margin: 0pt; }");
		x515d2f71e3e1988e.x538f0e0fb2bf15ab();
		x515d2f71e3e1988e.x538f0e0fb2bf15ab();
		x515d2f71e3e1988e.x2307058321cdb62f("body");
		x515d2f71e3e1988e.xc049ea80ee267201("img", "src", xe11224e032957d06, "alt", "Cover Image", "style", "height: 100%");
		x515d2f71e3e1988e.x538f0e0fb2bf15ab();
		x515d2f71e3e1988e.x718c3268815fe948();
		xd59a0d3f8248c4e8 value = new x32626c54bb4e8c9e(x39a547a368d84104.Encoding, x39a547a368d84104.xea0d040d38d75a91, "cover/cover-page.html", x0d299f323d241756.xa0aed4cd3b3d5d92(memoryStream));
		xee6dcf91257f44fd.Add(value);
		x178ddd705e9f9e3a.Add(value);
	}

	private static void xf3fc699ed2e317be(xfe2ff3c162b47c70 x0182a6dae298f8a4)
	{
		switch (x0182a6dae298f8a4)
		{
		case xfe2ff3c162b47c70.xf6c17f648b65c793:
			throw new InvalidOperationException("Thumbnail data is in unknown format.");
		case xfe2ff3c162b47c70.x796ab23ce57ee1e0:
		case xfe2ff3c162b47c70.x6339cdb9e2b512c7:
		case xfe2ff3c162b47c70.x8e716ec1cb703e9f:
			break;
		default:
			throw new NotSupportedException("Only Gif, Jpeg and Png thumbnails are supported for ePub.");
		}
	}
}
