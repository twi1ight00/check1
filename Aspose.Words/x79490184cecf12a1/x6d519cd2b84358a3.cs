using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Fields;
using x1495530f35d79681;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;
using xfbd1009a0cbb9842;

namespace x79490184cecf12a1;

internal class x6d519cd2b84358a3
{
	private x6d519cd2b84358a3()
	{
	}

	internal static void x06b0e25aa6ad68a9(xdfce7f4f687956d7 xe134235b3526fa75)
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		x3c85359e1389ad43 x3bcd232d01c = xe134235b3526fa75.x3bcd232d01c14846;
		while (x3bcd232d01c.x1ac1960adc8c4c39())
		{
			switch (x3bcd232d01c.xa66385d80d4d296f)
			{
			case "anchor":
				text = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "id":
				text2 = xe134235b3526fa75.x052a6c2e603b1662(x3bcd232d01c.xd2f68ee6f47e9dfb);
				break;
			case "tgtFrame":
				text3 = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			case "tooltip":
				text4 = x3bcd232d01c.xd2f68ee6f47e9dfb;
				break;
			}
		}
		Node lastChild = xe134235b3526fa75.x0547ea8ef1ef19b1.LastChild;
		x5ab4843b5e9c9f8d.x6a5b9e9e63b563c8(xe134235b3526fa75);
		Node lastChild2 = xe134235b3526fa75.x0547ea8ef1ef19b1.LastChild;
		if (lastChild2 is ShapeBase)
		{
			ShapeBase shapeBase = (ShapeBase)lastChild2;
			shapeBase.x0817d5cde9e19bf6(898, x0d4d45882065c63e.x60ea34a7657b9f8a(text2, text));
			if (x0d299f323d241756.x5959bccb67bbf051(text3))
			{
				shapeBase.x0817d5cde9e19bf6(4120, text3);
			}
			if (x0d299f323d241756.x5959bccb67bbf051(text4))
			{
				shapeBase.x0817d5cde9e19bf6(909, text4);
			}
		}
		else
		{
			FieldStart fieldStart = new FieldStart(xe134235b3526fa75.x2c8c6741422a1298, new xeedad81aaed42a76(), FieldType.FieldHyperlink);
			xe134235b3526fa75.x4a3d790f43378811(xe134235b3526fa75.x0547ea8ef1ef19b1, fieldStart, lastChild);
			xdfac57ec3a49a3fc xdfac57ec3a49a3fc = new xdfac57ec3a49a3fc(text2, text, text4, text3);
			Run run = new Run(xe134235b3526fa75.x2c8c6741422a1298, xdfac57ec3a49a3fc.ToString());
			xe134235b3526fa75.x4a3d790f43378811(xe134235b3526fa75.x0547ea8ef1ef19b1, run, fieldStart);
			FieldSeparator x40e458b3a58f = new FieldSeparator(xe134235b3526fa75.x2c8c6741422a1298, new xeedad81aaed42a76(), FieldType.FieldHyperlink);
			xe134235b3526fa75.x4a3d790f43378811(xe134235b3526fa75.x0547ea8ef1ef19b1, x40e458b3a58f, run);
			FieldEnd xda5bf54deb817e = new FieldEnd(xe134235b3526fa75.x2c8c6741422a1298, new xeedad81aaed42a76(), FieldType.FieldHyperlink, hasSeparator: true);
			xe134235b3526fa75.x1fa9148f6731ff24(xda5bf54deb817e);
		}
	}
}
