using Aspose.Words;
using Aspose.Words.Tables;
using x2cc366c8657e2b6a;
using x79490184cecf12a1;

namespace x1495530f35d79681;

internal class x9306bb5271b301f2
{
	private x9306bb5271b301f2()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		Cell cell = new Cell(xe134235b3526fa75.x2c8c6741422a1298);
		xe134235b3526fa75.x490834a62c46f14d(cell);
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x152cbadbfa8061b1("tc"))
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "tcPr":
				xfad593021ab5340a.x06b0e25aa6ad68a9(xe134235b3526fa75, cell.xf8cef531dae89ea3);
				continue;
			case "tcW":
				cell.xf8cef531dae89ea3.x921a6336ff3c4dd3(x3bcd232d01c.xe210c2db3704ad78());
				continue;
			}
			if (xe134235b3526fa75.x325f1926b78ae5cd)
			{
				xce4dd62ad1252b05.x152cbadbfa8061b1(xe134235b3526fa75);
			}
			else
			{
				x38ecd42e68717d79.x152cbadbfa8061b1(xe134235b3526fa75);
			}
		}
		xe134235b3526fa75.xf5b0b9b6ff7ac462(NodeType.Cell);
	}
}
