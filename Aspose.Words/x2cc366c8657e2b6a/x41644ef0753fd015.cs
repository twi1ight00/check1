using System.Collections;
using Aspose.Words;
using Aspose.Words.Markup;
using Aspose.Words.Tables;
using x1495530f35d79681;
using x9db5f2e5af3d596e;
using xda075892eccab2ad;

namespace x2cc366c8657e2b6a;

internal class x41644ef0753fd015
{
	private x41644ef0753fd015()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		xe134235b3526fa75.x490834a62c46f14d(new Table(xe134235b3526fa75.x2c8c6741422a1298));
		xedb0eb766e25e0c9 xe193ceb565ecaa0a = new xedb0eb766e25e0c9();
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		new ArrayList();
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x152cbadbfa8061b1(xe134235b3526fa75, xe193ceb565ecaa0a);
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Table);
	}

	internal static void x152cbadbfa8061b1(xdfce7f4f687956d7 xe134235b3526fa75, xedb0eb766e25e0c9 xe193ceb565ecaa0a)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x3bcd232d01c.x99f8cdb2827fa686();
		if (xe134235b3526fa75.x3ee7f4bad5fbb600)
		{
			CustomXmlMarkup customXmlMarkup = x1390159526f3122a.x06b0e25aa6ad68a9(xe134235b3526fa75, MarkupLevel.Row);
			xe134235b3526fa75.x490834a62c46f14d(customXmlMarkup);
			while (x3bcd232d01c.x152cbadbfa8061b1(customXmlMarkup.Element))
			{
				x152cbadbfa8061b1(xe134235b3526fa75, xe193ceb565ecaa0a);
			}
			xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.CustomXmlMarkup);
			return;
		}
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "tblPr":
			xf24b05793143359f.x0fef18e7f16bf0ca(xe193ceb565ecaa0a, xe134235b3526fa75, x37f701492043cfc5: false);
			return;
		case "tblGrid":
			x88fc04b3ff226822.x0dd2d2739751e83b(x3bcd232d01c, ((Table)xe134235b3526fa75.x0547ea8ef1ef19b1).xedb0eb766e25e0c9);
			return;
		case "tr":
			x654730ca74a0caa3.x06b0e25aa6ad68a9(xe134235b3526fa75, xe193ceb565ecaa0a);
			return;
		case "annotation":
			x9cee4b6d17a3fda9.x06b0e25aa6ad68a9(xe134235b3526fa75);
			return;
		}
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			x152cbadbfa8061b1(xe134235b3526fa75, xe193ceb565ecaa0a);
		}
	}
}
