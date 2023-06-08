using Aspose.Words;

namespace xa2462df43988ffad;

internal class x352c232b6aeb5bd5
{
	private readonly xdb0bf9f81de4b38c x9b287b671d592594;

	internal x352c232b6aeb5bd5(xdb0bf9f81de4b38c writer)
	{
		x9b287b671d592594 = writer;
	}

	internal VisitorAction xad7a29fa75b79356(HeaderFooter x03e7e66b1eecc96f)
	{
		if (x9b287b671d592594.x68e1404b914783c1)
		{
			return VisitorAction.SkipThisNode;
		}
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62af77d3c3af0871)
		{
			x9b287b671d592594.xe1410f585439c7d4.x2307058321cdb62f(xbde3c36210061e2b(x03e7e66b1eecc96f));
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction xf2ddc0e9840f4570(HeaderFooter x03e7e66b1eecc96f)
	{
		if (x9b287b671d592594.x05ee8ce4d7312eb5 == x14bf6f47128e4438.x62af77d3c3af0871)
		{
			x9b287b671d592594.xe1410f585439c7d4.x2dfde153f4ef96d0(xbde3c36210061e2b(x03e7e66b1eecc96f));
		}
		return VisitorAction.Continue;
	}

	private static string xbde3c36210061e2b(HeaderFooter x03e7e66b1eecc96f)
	{
		string text = (x03e7e66b1eecc96f.IsHeader ? "style:header" : "style:footer");
		if (x03e7e66b1eecc96f.HeaderFooterType == HeaderFooterType.HeaderEven || x03e7e66b1eecc96f.HeaderFooterType == HeaderFooterType.FooterEven)
		{
			text = $"{text}-left";
		}
		return text;
	}
}
