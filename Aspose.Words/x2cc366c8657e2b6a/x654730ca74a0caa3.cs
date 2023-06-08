using Aspose.Words;
using Aspose.Words.Markup;
using Aspose.Words.Tables;
using x1495530f35d79681;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x2cc366c8657e2b6a;

internal class x654730ca74a0caa3
{
	private x654730ca74a0caa3()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		xedb0eb766e25e0c9 xedb0eb766e25e0c = (xedb0eb766e25e0c9)xe193ceb565ecaa0a.x8b61531c8ea35b85();
		Row row = new Row(xe134235b3526fa75.x2c8c6741422a1298, xedb0eb766e25e0c);
		xe134235b3526fa75.x490834a62c46f14d(row);
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x152cbadbfa8061b1(xe134235b3526fa75, xedb0eb766e25e0c);
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Row);
		x88fc04b3ff226822.x6ce78ad60b4a67c9(row);
		row.x47ab0b351d6caf1e();
	}

	private static void x152cbadbfa8061b1(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 x0d9383c33dfa78ca)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		if (xe134235b3526fa75.x3ee7f4bad5fbb600)
		{
			CustomXmlMarkup customXmlMarkup = x1390159526f3122a.x06b0e25aa6ad68a9(xe134235b3526fa75, MarkupLevel.Cell);
			xe134235b3526fa75.x490834a62c46f14d(customXmlMarkup);
			while (x3bcd232d01c.x152cbadbfa8061b1(customXmlMarkup.Element))
			{
				x152cbadbfa8061b1(xe134235b3526fa75, x0d9383c33dfa78ca);
			}
			xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.CustomXmlMarkup);
			return;
		}
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "tblPrEx":
			xf24b05793143359f.x3542c3148699107e(x0d9383c33dfa78ca, xe134235b3526fa75);
			return;
		case "trPr":
			xbc80cffc72f0de48.x06b0e25aa6ad68a9(x0d9383c33dfa78ca, xe134235b3526fa75);
			return;
		case "tc":
			x9306bb5271b301f2.x06b0e25aa6ad68a9(xe134235b3526fa75);
			return;
		case "annotation":
			x9cee4b6d17a3fda9.x06b0e25aa6ad68a9(xe134235b3526fa75);
			return;
		}
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x152cbadbfa8061b1(xe134235b3526fa75, x0d9383c33dfa78ca);
		}
	}
}
