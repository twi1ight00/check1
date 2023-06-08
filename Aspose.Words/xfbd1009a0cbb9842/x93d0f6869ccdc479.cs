using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;

namespace xfbd1009a0cbb9842;

internal class x93d0f6869ccdc479 : x9710cfdf3f61d319
{
	private readonly IEnumerable x88485bf5e43cb3fd;

	private readonly Paragraph x951ad14edff96c0d;

	private readonly Paragraph x2cf311af3beada62;

	internal x93d0f6869ccdc479(IEnumerable oldResultNodes, Paragraph oldStartParagraph, Paragraph oldEndParagraph)
	{
		x88485bf5e43cb3fd = oldResultNodes;
		x951ad14edff96c0d = (Paragraph)oldStartParagraph.Clone(isCloneChildren: false);
		x2cf311af3beada62 = (Paragraph)oldEndParagraph.Clone(isCloneChildren: false);
	}

	private void xdc1074cc34640437(x7e263f21a73a027a x7d95d971d8923f4c)
	{
		x43bb7ecffe7e5855 x58d5aed105ad = new x43bb7ecffe7e5855(x88485bf5e43cb3fd, x951ad14edff96c0d);
		Paragraph startParagraph = (Paragraph)x7d95d971d8923f4c.x12cb12b5d2cad53d.x40212106aad8a8b0.GetAncestor(NodeType.Paragraph);
		Paragraph endParagraph = (Paragraph)x7d95d971d8923f4c.x9fd888e65466818c.x40212106aad8a8b0.GetAncestor(NodeType.Paragraph);
		x948832640e0e1725 x948832640e0e1726 = new x948832640e0e1725(x7d95d971d8923f4c, startParagraph, endParagraph);
		x948832640e0e1726.x0179a04e11cec04d(x58d5aed105ad, x2cf311af3beada62);
	}

	void x9710cfdf3f61d319.x18739bb47cc530dd(x7e263f21a73a027a x7d95d971d8923f4c)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xdc1074cc34640437
		this.xdc1074cc34640437(x7d95d971d8923f4c);
	}
}
