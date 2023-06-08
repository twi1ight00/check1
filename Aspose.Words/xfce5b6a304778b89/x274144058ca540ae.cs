using Aspose.Words;
using Aspose.Words.Drawing;
using x011d489fb9df7027;
using x28925c9b27b37a46;

namespace xfce5b6a304778b89;

internal class x274144058ca540ae
{
	private x274144058ca540ae()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xeedad81aaed42a76 x789564759d365819)
	{
		Shape shape = new Shape(xe134235b3526fa75.x2c8c6741422a1298);
		x789564759d365819?.xab3af626b1405ee8(shape.xeedad81aaed42a76);
		xf7125312c7ee115c xf7125312c7ee115c = new xf7125312c7ee115c();
		xf7125312c7ee115c xf7125312c7ee115c2 = new xf7125312c7ee115c();
		xf7125312c7ee115c2.xae20093bed1e48a8(4155, ShapeType.StraightConnector1);
		x2f70f4b50b541c08.x1989ad42a196d646(xe134235b3526fa75, xf7125312c7ee115c2);
		x253dc1c25dfd49a2.x0c1288d16c9571df(xe134235b3526fa75, xf7125312c7ee115c);
		xf4ad35a4c681d85d(xe134235b3526fa75, xf7125312c7ee115c2);
		shape.xf7125312c7ee115c = xf7125312c7ee115c;
		xf7125312c7ee115c2.xab3af626b1405ee8(shape.xf7125312c7ee115c);
		x8b2c3c076d5a7daf.AppendChild(shape);
	}

	private static void xf4ad35a4c681d85d(xf871da68decec406 xe134235b3526fa75, xf7125312c7ee115c xb1b96b4a406833d8)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("connector"))
		{
			if (!xe134235b3526fa75.xb18e918c8e329f66(xb1b96b4a406833d8))
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}
}
