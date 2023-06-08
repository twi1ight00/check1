using Aspose.Words;
using Aspose.Words.Markup;
using x1495530f35d79681;

namespace x2cc366c8657e2b6a;

internal class xe20a0cd5b17e35ef
{
	private xe20a0cd5b17e35ef()
	{
	}

	internal static bool x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		bool result = false;
		Paragraph paragraph = new Paragraph(xe134235b3526fa75.x2c8c6741422a1298);
		xe134235b3526fa75.x490834a62c46f14d(paragraph);
		xe134235b3526fa75.x58bdab3825959912();
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("p"))
		{
			if (x152cbadbfa8061b1(xe134235b3526fa75, paragraph))
			{
				result = true;
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Paragraph);
		return result;
	}

	private static bool x02cbe1d42fc2fa2b(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		if (xe134235b3526fa75 is x21a61af92fc2a45e x21a61af92fc2a45e2)
		{
			if (x21a61af92fc2a45e2.xff407d097cedd1e6)
			{
				if (!(xe134235b3526fa75.x3bcd232d01c14846.xa66385d80d4d296f == "oMathPara"))
				{
					return xe134235b3526fa75.x3bcd232d01c14846.xa66385d80d4d296f == "oMath";
				}
				return true;
			}
			return false;
		}
		return false;
	}

	private static bool x152cbadbfa8061b1(xdfce7f4f687956d7 xe134235b3526fa75, Paragraph x41baca1d6c0c2e8e)
	{
		bool result = false;
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		if (xe134235b3526fa75.x3ee7f4bad5fbb600 && !x02cbe1d42fc2fa2b(xe134235b3526fa75))
		{
			CustomXmlMarkup customXmlMarkup = x1390159526f3122a.x06b0e25aa6ad68a9(xe134235b3526fa75, MarkupLevel.Inline);
			xe134235b3526fa75.x490834a62c46f14d(customXmlMarkup);
			while (x3bcd232d01c.x152cbadbfa8061b1(customXmlMarkup.Element))
			{
				result = x152cbadbfa8061b1(xe134235b3526fa75, x41baca1d6c0c2e8e);
			}
			xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.CustomXmlMarkup);
		}
		else
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "pPr":
				result = xec45413ffc971f9d.x06b0e25aa6ad68a9(xe134235b3526fa75, x41baca1d6c0c2e8e.x1a78664fa10a3755, x41baca1d6c0c2e8e.x344511c4e4ce09da);
				break;
			case "listPr":
				xec45413ffc971f9d.xb55c4c6e333ae897(x3bcd232d01c, x41baca1d6c0c2e8e.x1a78664fa10a3755);
				break;
			case "permStart":
			case "permEnd":
				xe134235b3526fa75.xbbf9a1ead81dd3a1(WarningType.MajorFormattingLossCategory, WarningSource.WordML, $"Element '{x3bcd232d01c.xa66385d80d4d296f}' will be lost because protected ranges feature is not supported in WordML format by Aspose.Words.");
				x64e4e16f4da15749.x152cbadbfa8061b1(xe134235b3526fa75);
				break;
			default:
				x64e4e16f4da15749.x152cbadbfa8061b1(xe134235b3526fa75);
				break;
			}
		}
		return result;
	}
}
