using Aspose.Words;
using x1495530f35d79681;

namespace x79490184cecf12a1;

internal class xce4dd62ad1252b05
{
	private xce4dd62ad1252b05()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, CompositeNode x93d8434f027afd5a)
	{
		CompositeNode x0547ea8ef1ef19b = xe134235b3526fa75.x0547ea8ef1ef19b1;
		xe134235b3526fa75.x0547ea8ef1ef19b1 = x93d8434f027afd5a;
		x6a5b9e9e63b563c8(xe134235b3526fa75);
		xe134235b3526fa75.x0547ea8ef1ef19b1 = x0547ea8ef1ef19b;
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
		bool flag = false;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "p":
			flag = xf32efa9aef6963ce.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		case "tbl":
			x22063a019e9be4a2.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
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
		case "sdt":
		{
			x1d1a299a51dcf8a0 x1d1a299a51dcf8a = x1d1a299a51dcf8a0.x944488b699acab30();
			x1d1a299a51dcf8a.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		}
		case "customXml":
		{
			x37e7b06a61239ade x37e7b06a61239ade2 = x37e7b06a61239ade.x104a769b370c68e5();
			x37e7b06a61239ade2.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		}
		case "permStart":
		case "permEnd":
			xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MajorFormattingLossCategory, WarningSource.Docx, $"Element '{x3bcd232d01c.xa66385d80d4d296f}' will be lost because protected ranges feature is not supported in Docx format by Aspose.Words.");
			x6a5b9e9e63b563c8(xe134235b3526fa75);
			break;
		case "altChunk":
			xd51fda6ca5cf7028.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		default:
			x6a5b9e9e63b563c8(xe134235b3526fa75);
			break;
		}
		if (flag)
		{
			xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Body);
			xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Section);
			xe134235b3526fa75.x490834a62c46f14d(new Section(xe134235b3526fa75.x2c8c6741422a1298));
			xe134235b3526fa75.x490834a62c46f14d(new Body(xe134235b3526fa75.x2c8c6741422a1298));
		}
	}
}
