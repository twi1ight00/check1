using Aspose.Words;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace x79490184cecf12a1;

internal class x5ab4843b5e9c9f8d
{
	private x5ab4843b5e9c9f8d()
	{
	}

	internal static void x6a5b9e9e63b563c8(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x152cbadbfa8061b1(xe134235b3526fa75);
		}
	}

	internal static void x152cbadbfa8061b1(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "bookmarkStart":
			x09eedd5f568d4e13.xcaea02fd4d5f83c6(xe134235b3526fa75);
			break;
		case "bookmarkEnd":
			x09eedd5f568d4e13.x24deddd4c9b86ffd(xe134235b3526fa75);
			break;
		case "commentRangeStart":
			x24d47ad0d19873c2.x25cfe591c81d3275(xe134235b3526fa75);
			break;
		case "commentRangeEnd":
			x24d47ad0d19873c2.x3deb365a29df23e7(xe134235b3526fa75);
			break;
		case "subDoc":
		{
			string xc06e652f250a = xe134235b3526fa75.x3bcd232d01c14846.xd68abcd61e368af9("id", "");
			string originalFileName = ((Document)xe134235b3526fa75.x2c8c6741422a1298).OriginalFileName;
			string xafe2f3653ee64ebc = x0d4d45882065c63e.x2fbbd6c36ce879ff(xe134235b3526fa75.x052a6c2e603b1662(xc06e652f250a));
			xe134235b3526fa75.x1fa9148f6731ff24(new SubDocument(xe134235b3526fa75.x2c8c6741422a1298, x0d4d45882065c63e.xbb8e765da244dfdd(originalFileName, xafe2f3653ee64ebc)));
			break;
		}
		case "r":
			x90c7969a84762ddd.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		case "hyperlink":
			x6d519cd2b84358a3.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		case "smartTag":
			x59dc375fefb756b0.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		case "del":
			x993aabbdc0e02955.x67d504ac4e705dd2(xe134235b3526fa75);
			break;
		case "ins":
			x993aabbdc0e02955.x83d360430098f33c(xe134235b3526fa75);
			break;
		case "moveFrom":
			xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Docx, "MoveFrom revision type is unsupported and converted to Del revision.");
			x993aabbdc0e02955.x67d504ac4e705dd2(xe134235b3526fa75);
			break;
		case "moveTo":
			xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MinorFormattingLossCategory, WarningSource.Docx, "MoveTo revision type is unsupported and converted to Ins revision.");
			x993aabbdc0e02955.x83d360430098f33c(xe134235b3526fa75);
			break;
		case "sdt":
		{
			x1d1a299a51dcf8a0 x1d1a299a51dcf8a = x1d1a299a51dcf8a0.x2becda0634f612cd();
			x1d1a299a51dcf8a.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		}
		case "customXml":
		{
			x37e7b06a61239ade x37e7b06a61239ade2 = x37e7b06a61239ade.xf5b9bcd152ae8e99();
			x37e7b06a61239ade2.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		}
		case "oMath":
			x769e3b44d6c5a4cb.x61eaf7514df15047(xe134235b3526fa75);
			break;
		case "oMathPara":
			x769e3b44d6c5a4cb.x7c1d9b763e5e5f78(xe134235b3526fa75);
			break;
		case "permStart":
		case "permEnd":
			xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MajorFormattingLossCategory, WarningSource.Docx, $"Element '{x3bcd232d01c.xa66385d80d4d296f}' will be lost because protected ranges feature is not supported in Docx format by Aspose.Words.");
			x6a5b9e9e63b563c8(xe134235b3526fa75);
			break;
		default:
			if (!x90c7969a84762ddd.x46414487ffde0726(xe134235b3526fa75, new xeedad81aaed42a76()))
			{
				x6a5b9e9e63b563c8(xe134235b3526fa75);
			}
			break;
		case "moveFromRangeStart":
		case "moveFromRangeEnd":
		case "moveToRangeStart":
		case "moveToRangeEnd":
			break;
		}
	}
}
