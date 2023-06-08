using Aspose.Words;
using x1495530f35d79681;
using xda075892eccab2ad;

namespace x79490184cecf12a1;

internal class xf32efa9aef6963ce
{
	private xf32efa9aef6963ce()
	{
	}

	internal static bool x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		bool result = false;
		Paragraph paragraph = new Paragraph(xe134235b3526fa75.x2c8c6741422a1298);
		xe134235b3526fa75.x490834a62c46f14d(paragraph);
		xe134235b3526fa75.x58bdab3825959912();
		xe134235b3526fa75.xeb67d0521107425b(paragraph);
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "rsidP":
			{
				int num4 = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xd2f68ee6f47e9dfb);
				if (num4 != int.MinValue)
				{
					paragraph.x1a78664fa10a3755.xae20093bed1e48a8(1580, num4);
				}
				break;
			}
			case "rsidR":
			{
				int num2 = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xd2f68ee6f47e9dfb);
				if (num2 != int.MinValue)
				{
					paragraph.x344511c4e4ce09da.xae20093bed1e48a8(40, num2);
				}
				break;
			}
			case "rsidRDefault":
			{
				int num3 = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xd2f68ee6f47e9dfb);
				if (num3 != int.MinValue)
				{
					x3bcd232d01c.xbd89d3a43f3ef7f9 = num3;
				}
				break;
			}
			case "rsidRPr":
			{
				int num = xc1b08afa36bf580c.x2a2d5f8dcb4bf0c9(x3bcd232d01c.xd2f68ee6f47e9dfb);
				if (num != int.MinValue)
				{
					paragraph.x344511c4e4ce09da.xae20093bed1e48a8(30, num);
				}
				break;
			}
			}
		}
		x3bcd232d01c.x99f8cdb2827fa686();
		while (x3bcd232d01c.x152cbadbfa8061b1("p"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f == "pPr")
			{
				result = xec45413ffc971f9d.x06b0e25aa6ad68a9(xe134235b3526fa75, paragraph.x1a78664fa10a3755, paragraph.x344511c4e4ce09da);
			}
			else
			{
				x5ab4843b5e9c9f8d.x152cbadbfa8061b1(xe134235b3526fa75);
			}
		}
		x3bcd232d01c.xbd89d3a43f3ef7f9 = 0;
		x3bcd232d01c.x413affb5b90b6470 = paragraph;
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Paragraph);
		return result;
	}
}
