using System.IO;
using Aspose.Words.Saving;
using Aspose.Words.Tables;
using x1a3e96f4b89a7a77;
using x6c95d9cf46ff5f25;
using xf9a9481c3f63a419;

namespace xce0136f05681c5e9;

internal class x515d2f71e3e1988e : x873451caae5ad4ae
{
	private readonly bool xa57e039eaf98f47e;

	private readonly bool xe55634e710842a8a;

	private readonly bool xf01c502d13fc67a8;

	internal x515d2f71e3e1988e(Stream stream, HtmlSaveOptions saveOptions)
		: base(stream, saveOptions.Encoding, saveOptions.PrettyFormat, useOnOff: true)
	{
		xa57e039eaf98f47e = saveOptions.ExportXhtmlTransitional;
		xe55634e710842a8a = saveOptions.x4e3c1d16eaf20ef3;
		xf01c502d13fc67a8 = saveOptions.ExportDocumentProperties;
	}

	internal void x6737a86fba7f7993()
	{
		if (xa57e039eaf98f47e)
		{
			base.x5222f4285e37d66b.WriteStartDocument(standalone: false);
			base.x5222f4285e37d66b.WriteDocType("html", xe55634e710842a8a ? "-//W3C//DTD XHTML 1.1//EN" : "-//W3C//DTD XHTML 1.0 Transitional//EN", xe55634e710842a8a ? "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd" : "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd", null);
			x2307058321cdb62f("html");
			xff520a0047c27122("xmlns", "http://www.w3.org/1999/xhtml");
		}
		else
		{
			x2307058321cdb62f("html");
		}
		if (xf01c502d13fc67a8)
		{
			xff520a0047c27122("xmlns:o", "urn:schemas-microsoft-com:office:office");
		}
	}

	internal void x718c3268815fe948()
	{
		x538f0e0fb2bf15ab();
		if (xa57e039eaf98f47e)
		{
			base.x5222f4285e37d66b.WriteEndDocument();
		}
		base.x5222f4285e37d66b.Flush();
	}

	internal void x55b893148f746a6f(string xc15bd84e01929885, int xbcea506a33cf9111)
	{
		xff520a0047c27122(xc15bd84e01929885, xbcea506a33cf9111.ToString());
	}

	internal void x564af086a330189f(string xc15bd84e01929885, PreferredWidth x961016a387451f05)
	{
		switch (x961016a387451f05.Type)
		{
		case PreferredWidthType.Points:
			x55b893148f746a6f(xc15bd84e01929885, x4574ea26106f0edb.xdbd829479885762d(x961016a387451f05.Value));
			break;
		case PreferredWidthType.Percent:
			xff520a0047c27122(xc15bd84e01929885, $"{xca004f56614e2431.xdbca7a004e2d3753(x961016a387451f05.Value)}%");
			break;
		}
	}

	internal void x7b7fba84e16aed73(string xc15bd84e01929885, string xbcea506a33cf9111)
	{
		if (x0d299f323d241756.x5959bccb67bbf051(xbcea506a33cf9111))
		{
			x2307058321cdb62f("meta");
			xff520a0047c27122("name", xc15bd84e01929885);
			xff520a0047c27122("content", xbcea506a33cf9111);
			x2dfde153f4ef96d0("meta");
		}
	}
}
