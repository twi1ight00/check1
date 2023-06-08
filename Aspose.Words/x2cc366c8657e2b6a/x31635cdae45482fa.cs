using Aspose.Words;
using x1495530f35d79681;

namespace x2cc366c8657e2b6a;

internal class x31635cdae45482fa
{
	private x31635cdae45482fa()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		Document doc = (Document)xe134235b3526fa75.x2c8c6741422a1298;
		xe134235b3526fa75.x490834a62c46f14d(new Section(doc));
		xe134235b3526fa75.x490834a62c46f14d(new Body(doc));
		x6a5b9e9e63b563c8(xe134235b3526fa75);
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Body);
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Section);
	}

	private static void x6a5b9e9e63b563c8(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		x3bcd232d01c.x99f8cdb2827fa686();
		string xa66385d80d4d296f = x3bcd232d01c.xa66385d80d4d296f;
		while (x3bcd232d01c.x152cbadbfa8061b1(xa66385d80d4d296f))
		{
			string xa66385d80d4d296f2;
			if ((xa66385d80d4d296f2 = x3bcd232d01c.xa66385d80d4d296f) != null && xa66385d80d4d296f2 == "sectPr")
			{
				Body body = (Body)xe134235b3526fa75.x0547ea8ef1ef19b1;
				xc0f8e03cabf3a123.x06b0e25aa6ad68a9(xe134235b3526fa75, body.ParentSection);
			}
			else
			{
				x38ecd42e68717d79.x152cbadbfa8061b1(xe134235b3526fa75);
			}
		}
	}
}
