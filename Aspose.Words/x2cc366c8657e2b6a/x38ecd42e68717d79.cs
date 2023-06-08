using Aspose.Words;
using Aspose.Words.Markup;
using x1495530f35d79681;

namespace x2cc366c8657e2b6a;

internal class x38ecd42e68717d79
{
	private x38ecd42e68717d79()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75, CompositeNode x93d8434f027afd5a)
	{
		CompositeNode x0547ea8ef1ef19b = xe134235b3526fa75.x0547ea8ef1ef19b1;
		xe134235b3526fa75.x0547ea8ef1ef19b1 = x93d8434f027afd5a;
		x6a5b9e9e63b563c8(xe134235b3526fa75);
		xe134235b3526fa75.x0547ea8ef1ef19b1 = x0547ea8ef1ef19b;
	}

	private static void x6a5b9e9e63b563c8(xdfce7f4f687956d7 xe134235b3526fa75)
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
		if (xe134235b3526fa75.x3ee7f4bad5fbb600)
		{
			CustomXmlMarkup customXmlMarkup = x1390159526f3122a.x06b0e25aa6ad68a9(xe134235b3526fa75, MarkupLevel.Block);
			xe134235b3526fa75.x490834a62c46f14d(customXmlMarkup);
			while (x3bcd232d01c.x152cbadbfa8061b1(customXmlMarkup.Element))
			{
				x152cbadbfa8061b1(xe134235b3526fa75);
			}
			if (xe134235b3526fa75.x0547ea8ef1ef19b1.NodeType == NodeType.CustomXmlMarkup)
			{
				xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.CustomXmlMarkup);
			}
			return;
		}
		switch (x3bcd232d01c.xa66385d80d4d296f)
		{
		case "p":
			flag = xe20a0cd5b17e35ef.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		case "tbl":
			x41644ef0753fd015.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		case "annotation":
			x9cee4b6d17a3fda9.x06b0e25aa6ad68a9(xe134235b3526fa75);
			break;
		case "sectPr":
			if (xe134235b3526fa75.x0547ea8ef1ef19b1.NodeType == NodeType.Body)
			{
				Body body = (Body)xe134235b3526fa75.x0547ea8ef1ef19b1;
				xc0f8e03cabf3a123.x06b0e25aa6ad68a9(xe134235b3526fa75, body.ParentSection);
			}
			x6a5b9e9e63b563c8(xe134235b3526fa75);
			break;
		case "binData":
			xe134235b3526fa75.x2b6e606d842be5f3();
			break;
		case "permStart":
		case "permEnd":
			xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MajorFormattingLossCategory, WarningSource.WordML, $"Element '{x3bcd232d01c.xa66385d80d4d296f}' will be lost because protected ranges feature is not supported in WordML format by Aspose.Words.");
			x6a5b9e9e63b563c8(xe134235b3526fa75);
			break;
		default:
			x6a5b9e9e63b563c8(xe134235b3526fa75);
			break;
		}
		if (!flag)
		{
			return;
		}
		if (xe134235b3526fa75.x0547ea8ef1ef19b1.NodeType == NodeType.CustomXmlMarkup)
		{
			while (xe134235b3526fa75.x0547ea8ef1ef19b1.NodeType == NodeType.CustomXmlMarkup)
			{
				CustomXmlMarkup customXmlMarkup2 = (CustomXmlMarkup)xe134235b3526fa75.x0547ea8ef1ef19b1;
				xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.CustomXmlMarkup);
				while (customXmlMarkup2.HasChildNodes)
				{
					customXmlMarkup2.ParentNode.InsertAfter(customXmlMarkup2.LastChild, customXmlMarkup2);
				}
				customXmlMarkup2.Remove();
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Body);
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Section);
		Document doc = (Document)xe134235b3526fa75.x2c8c6741422a1298;
		xe134235b3526fa75.x490834a62c46f14d(new Section(doc));
		xe134235b3526fa75.x490834a62c46f14d(new Body(doc));
	}
}
