using Aspose.Words;
using x1495530f35d79681;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class x594679cbec3cc56e
{
	private x594679cbec3cc56e()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		bool x59c6d00e0898f6b = x3bcd232d01c.xa66385d80d4d296f == "headerReference";
		string xbcea506a33cf = null;
		string xc06e652f250a = null;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "type":
				xbcea506a33cf = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "id":
				xc06e652f250a = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			}
		}
		HeaderFooterType headerFooterType = x93625b0e8808b0cc.x188cbe5b54678d25(xbcea506a33cf, x59c6d00e0898f6b);
		HeaderFooter headerFooter = new HeaderFooter(xe134235b3526fa75.x2c8c6741422a1298, headerFooterType);
		xe134235b3526fa75.x663a863d790eefe8(xc06e652f250a);
		xe134235b3526fa75.xf41b717aaedc8265 = true;
		xce4dd62ad1252b05.x06b0e25aa6ad68a9(xe134235b3526fa75, headerFooter);
		xe134235b3526fa75.xf41b717aaedc8265 = false;
		xe134235b3526fa75.xc8ab4e294c74831b();
		Body body = ((xe134235b3526fa75.x0547ea8ef1ef19b1 is Paragraph paragraph) ? ((Body)paragraph.ParentStory) : ((Body)xe134235b3526fa75.x0547ea8ef1ef19b1));
		Section parentSection = body.ParentSection;
		if (parentSection.HeadersFooters[headerFooter.HeaderFooterType] == null)
		{
			xe134235b3526fa75.xbe11e60379d74111(parentSection, headerFooter, body);
			return;
		}
		HeaderFooter headerFooter2 = parentSection.HeadersFooters[headerFooter.HeaderFooterType];
		Paragraph newChild = new Paragraph(headerFooter2.Document);
		headerFooter2.InsertBefore(newChild, headerFooter2.FirstParagraph);
		while (headerFooter.HasChildNodes)
		{
			headerFooter2.InsertBefore(headerFooter.LastChild, headerFooter2.FirstChild);
		}
	}
}
