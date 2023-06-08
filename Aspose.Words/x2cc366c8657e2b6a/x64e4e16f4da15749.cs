using System;
using Aspose.Words;
using Aspose.Words.Markup;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using x79490184cecf12a1;

namespace x2cc366c8657e2b6a;

internal class x64e4e16f4da15749
{
	private x64e4e16f4da15749()
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
		case "annotation":
			x9cee4b6d17a3fda9.x06b0e25aa6ad68a9(xe134235b3526fa75);
			return;
		case "subDoc":
		{
			string originalFileName = ((Document)xe134235b3526fa75.x2c8c6741422a1298).OriginalFileName;
			string fileName = x0d4d45882065c63e.xbb8e765da244dfdd(originalFileName, x3bcd232d01c.xd68abcd61e368af9("link", ""));
			xe134235b3526fa75.x0547ea8ef1ef19b1.xdf7453d9fdf3f262(new SubDocument(xe134235b3526fa75.x2c8c6741422a1298, fileName));
			return;
		}
		case "r":
			x90c7969a84762ddd.x06b0e25aa6ad68a9(xe134235b3526fa75);
			return;
		case "hlink":
			x5f0061abf3511c04.x06b0e25aa6ad68a9(xe134235b3526fa75);
			return;
		case "oMath":
		case "oMathPara":
			x38d2e860d470f8e0(xe134235b3526fa75);
			return;
		}
		if (xe134235b3526fa75.x099487305e4675db)
		{
			x61611159b147d9f1(xe134235b3526fa75);
		}
		else if (!x90c7969a84762ddd.x46414487ffde0726(xe134235b3526fa75, new xeedad81aaed42a76()))
		{
			x6a5b9e9e63b563c8(xe134235b3526fa75);
		}
	}

	private static void x38d2e860d470f8e0(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		if (xe134235b3526fa75 is x21a61af92fc2a45e x21a61af92fc2a45e2 && x21a61af92fc2a45e2.xff407d097cedd1e6)
		{
			x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "oMath":
				x769e3b44d6c5a4cb.x61eaf7514df15047(xe134235b3526fa75);
				break;
			case "oMathPara":
				x769e3b44d6c5a4cb.x7c1d9b763e5e5f78(xe134235b3526fa75);
				break;
			default:
				xe134235b3526fa75.x3bcd232d01c14846.IgnoreElement();
				break;
			}
			return;
		}
		throw new InvalidOperationException("Unexpected token for WordML");
	}

	private static void x61611159b147d9f1(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		SmartTag smartTag = new SmartTag(xe134235b3526fa75.x2c8c6741422a1298);
		smartTag.Uri = x3bcd232d01c.x91d35d7dc070c876;
		smartTag.Element = x3bcd232d01c.xa66385d80d4d296f;
		xe134235b3526fa75.x490834a62c46f14d(smartTag);
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) == null || !(xa66385d80d4d296f == "st"))
			{
				CustomXmlProperty x46710263f0fedd = new CustomXmlProperty(x3bcd232d01c.xa66385d80d4d296f, x3bcd232d01c.x91d35d7dc070c876, x3bcd232d01c.xd2f68ee6f47e9dfb);
				smartTag.Properties.x1cd8943d02c5342f(x46710263f0fedd);
			}
		}
		x6a5b9e9e63b563c8(xe134235b3526fa75);
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.SmartTag);
	}
}
