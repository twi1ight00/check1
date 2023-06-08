using Aspose.Words;
using Aspose.Words.Tables;
using x1495530f35d79681;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class x81e625161048fd10
{
	private x81e625161048fd10()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = (xedb0eb766e25e0c9)xe193ceb565ecaa0a.x8b61531c8ea35b85();
		Row row = new Row(xe134235b3526fa75.x2c8c6741422a1298, xedb0eb766e25e0c);
		xe134235b3526fa75.x490834a62c46f14d(row);
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "rsidTr")
			{
				int num = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xd2f68ee6f47e9dfb);
				if (num != int.MinValue)
				{
					xedb0eb766e25e0c.xae20093bed1e48a8(4400, num);
				}
			}
		}
		x6a5b9e9e63b563c8(xe134235b3526fa75, xedb0eb766e25e0c);
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Row);
		x88fc04b3ff226822.x6ce78ad60b4a67c9(row);
		if (row.IsFirstRow)
		{
			x23912f42b0ad6168(xe193ceb565ecaa0a, xedb0eb766e25e0c, 4070);
			x23912f42b0ad6168(xe193ceb565ecaa0a, xedb0eb766e25e0c, 4050);
			x23912f42b0ad6168(xe193ceb565ecaa0a, xedb0eb766e25e0c, 4060);
			x23912f42b0ad6168(xe193ceb565ecaa0a, xedb0eb766e25e0c, 4080);
			x23912f42b0ad6168(xe193ceb565ecaa0a, xedb0eb766e25e0c, 4100);
			x23912f42b0ad6168(xe193ceb565ecaa0a, xedb0eb766e25e0c, 4090);
		}
	}

	private static void x23912f42b0ad6168(xedb0eb766e25e0c9 xe193ceb565ecaa0a, xedb0eb766e25e0c9 x0d9383c33dfa78ca, int xba08ce632055a1d9)
	{
		if (xe193ceb565ecaa0a.xf7866f89640a29a3(xba08ce632055a1d9) == null && x0d9383c33dfa78ca.xf7866f89640a29a3(xba08ce632055a1d9) != null)
		{
			xe193ceb565ecaa0a.xae20093bed1e48a8(xba08ce632055a1d9, new Border());
		}
	}

	internal static void x6a5b9e9e63b563c8(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 x0d9383c33dfa78ca)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x152cbadbfa8061b1(xe134235b3526fa75, x0d9383c33dfa78ca);
		}
	}

	internal static void x152cbadbfa8061b1(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 x0d9383c33dfa78ca)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "tblPrEx":
			xebd82bd99fc8c73d.x3542c3148699107e(xe134235b3526fa75, x0d9383c33dfa78ca);
			break;
		case "trPr":
			xaa9812a6c786e766.x06b0e25aa6ad68a9(xe134235b3526fa75, x0d9383c33dfa78ca);
			break;
		case "tc":
			x9306bb5271b301f2.x06b0e25aa6ad68a9(xe134235b3526fa75);
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
			x1d1a299a51dcf8a0 x1d1a299a51dcf8a = x1d1a299a51dcf8a0.x902349bf5ac3a6fc(x0d9383c33dfa78ca);
			x1d1a299a51dcf8a.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		}
		case "customXml":
		{
			x37e7b06a61239ade x37e7b06a61239ade2 = x37e7b06a61239ade.x1631b9aabbade1ad(x0d9383c33dfa78ca);
			x37e7b06a61239ade2.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		}
		default:
			x6a5b9e9e63b563c8(xe134235b3526fa75, x0d9383c33dfa78ca);
			break;
		}
	}
}
