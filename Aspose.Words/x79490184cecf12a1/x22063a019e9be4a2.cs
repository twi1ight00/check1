using Aspose.Words;
using Aspose.Words.Tables;
using x1495530f35d79681;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class x22063a019e9be4a2
{
	private x22063a019e9be4a2()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		xe134235b3526fa75.x490834a62c46f14d(new Table(xe134235b3526fa75.x2c8c6741422a1298));
		xedb0eb766e25e0c9 xe193ceb565ecaa0a = new xedb0eb766e25e0c9();
		x6a5b9e9e63b563c8(xe134235b3526fa75, xe193ceb565ecaa0a);
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Table);
	}

	internal static void x6a5b9e9e63b563c8(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x152cbadbfa8061b1(xe134235b3526fa75, xe193ceb565ecaa0a);
		}
	}

	internal static void x152cbadbfa8061b1(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "tblPr":
			xebd82bd99fc8c73d.x0fef18e7f16bf0ca(xe134235b3526fa75, xe193ceb565ecaa0a, x37f701492043cfc5: false);
			break;
		case "tblGrid":
			x88fc04b3ff226822.x0dd2d2739751e83b(x3bcd232d01c, ((Table)xe134235b3526fa75.x0547ea8ef1ef19b1).xedb0eb766e25e0c9);
			break;
		case "tr":
			x81e625161048fd10.x06b0e25aa6ad68a9(xe134235b3526fa75, xe193ceb565ecaa0a);
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
			x1d1a299a51dcf8a0 x1d1a299a51dcf8a = x1d1a299a51dcf8a0.x84ad5c48cfed7861(xe193ceb565ecaa0a);
			x1d1a299a51dcf8a.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		}
		case "customXml":
		{
			x37e7b06a61239ade x37e7b06a61239ade2 = x37e7b06a61239ade.x50eb8de80d3129d6(xe193ceb565ecaa0a);
			x37e7b06a61239ade2.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		}
		default:
			x6a5b9e9e63b563c8(xe134235b3526fa75, xe193ceb565ecaa0a);
			break;
		}
	}
}
