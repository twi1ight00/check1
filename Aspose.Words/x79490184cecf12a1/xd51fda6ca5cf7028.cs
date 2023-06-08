using System.IO;
using Aspose.Words;
using x1495530f35d79681;
using x909757d9fd2dd6ae;
using xf989f31a236ff98c;

namespace x79490184cecf12a1;

internal class xd51fda6ca5cf7028
{
	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		string xbe2e7cad438ed81d = "";
		ImportFormatMode xbddb8b51223ce9e = ImportFormatMode.KeepSourceFormatting;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "id")
			{
				xbe2e7cad438ed81d = x3bcd232d01c.xd2f68ee6f47e9dfb;
			}
			else
			{
				x3bcd232d01c.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Docx, x3bcd232d01c.xa66385d80d4d296f);
			}
		}
		while (x3bcd232d01c.x152cbadbfa8061b1("altChunk"))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "altChunkPr")
			{
				xbddb8b51223ce9e = xfa0aecb8edb09915(x3bcd232d01c, xbddb8b51223ce9e);
			}
			else
			{
				x3bcd232d01c.IgnoreElement();
			}
		}
		xd011607572e5ff1b(xe134235b3526fa75, xbe2e7cad438ed81d, xbddb8b51223ce9e);
	}

	private static ImportFormatMode xfa0aecb8edb09915(x3c85359e1389ad43 x97bf2eeabd4abc7b, ImportFormatMode xbddb8b51223ce9e8)
	{
		while (x97bf2eeabd4abc7b.x152cbadbfa8061b1("altChunkPr"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x97bf2eeabd4abc7b.xa66385d80d4d296f) != null && xa66385d80d4d296f == "matchSrc")
			{
				xbddb8b51223ce9e8 = (x97bf2eeabd4abc7b.xe04906126da94dd1() ? ImportFormatMode.KeepSourceFormatting : ImportFormatMode.UseDestinationStyles);
			}
			else
			{
				x97bf2eeabd4abc7b.xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, WarningSource.Docx, x97bf2eeabd4abc7b.xa66385d80d4d296f);
			}
		}
		return xbddb8b51223ce9e8;
	}

	private static void xd011607572e5ff1b(xdfce7f4f687956d7 xe134235b3526fa75, string xbe2e7cad438ed81d, ImportFormatMode xbddb8b51223ce9e8)
	{
		using MemoryStream memoryStream = new MemoryStream(xe134235b3526fa75.x7b29fad09d9101c5(xbe2e7cad438ed81d));
		x53dc82a419732f24 x53dc82a419732f = new x53dc82a419732f24();
		FileFormatInfo fileFormatInfo = x53dc82a419732f.xdef7f68a22ec051d(memoryStream);
		if (fileFormatInfo.LoadFormat != LoadFormat.Unknown)
		{
			Document altChunkDocument = new Document(memoryStream);
			Paragraph paragraph = new Paragraph(xe134235b3526fa75.x2c8c6741422a1298);
			xe134235b3526fa75.x490834a62c46f14d(paragraph);
			xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Paragraph);
			x7c5f42d7c853beff x962b4e83bcc275c = new x7c5f42d7c853beff(paragraph, altChunkDocument, xbddb8b51223ce9e8);
			((x11e1346c12ead315)xe134235b3526fa75).xd011607572e5ff1b(x962b4e83bcc275c);
		}
	}
}
