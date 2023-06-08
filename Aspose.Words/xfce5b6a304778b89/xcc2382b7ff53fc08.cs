using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xfce5b6a304778b89;

internal class xcc2382b7ff53fc08
{
	private xcc2382b7ff53fc08()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xeedad81aaed42a76 x789564759d365819)
	{
		GroupShape groupShape = new GroupShape(xe134235b3526fa75.x2c8c6741422a1298);
		x1989ad42a196d646(xe134235b3526fa75, groupShape);
		x1ba13e535f55aa54 x1ba13e535f55aa55 = (x1ba13e535f55aa54)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "graphic", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		if (x1ba13e535f55aa55 != null && x1ba13e535f55aa55.xf7125312c7ee115c != null)
		{
			x1ba13e535f55aa55.xf7125312c7ee115c.xab3af626b1405ee8(groupShape.xf7125312c7ee115c);
		}
		x789564759d365819?.xab3af626b1405ee8(groupShape.xeedad81aaed42a76);
		xf4ad35a4c681d85d(xe134235b3526fa75, groupShape, x789564759d365819);
		if (groupShape.ChildNodes.Count > 0 || !(x8b2c3c076d5a7daf is GroupShape))
		{
			x2e17c32b4f857b99(groupShape);
			x8b2c3c076d5a7daf.AppendChild(groupShape);
		}
	}

	private static void x2e17c32b4f857b99(ShapeBase x908338b83832d1aa)
	{
		if (x908338b83832d1aa.ChildNodes.Count <= 0)
		{
			return;
		}
		double num = double.MaxValue;
		double num2 = double.MaxValue;
		double num3 = double.MinValue;
		double num4 = double.MinValue;
		foreach (ShapeBase childNode in x908338b83832d1aa.ChildNodes)
		{
			num = Math.Min(childNode.Left, num);
			num2 = Math.Min(childNode.Top, num2);
			num3 = Math.Max(childNode.Right, num3);
			num4 = Math.Max(childNode.Bottom, num4);
		}
		Size coordSize = new Size((int)(num3 - num), (int)(num4 - num2));
		if (coordSize.Height > 0 && coordSize.Width > 0)
		{
			x908338b83832d1aa.CoordSize = coordSize;
			x908338b83832d1aa.Width = coordSize.Width;
			x908338b83832d1aa.Height = coordSize.Height;
		}
		x908338b83832d1aa.x06c65daad0c0656c = (int)num;
		x908338b83832d1aa.x399bb78ac51a4081 = (int)num2;
		x908338b83832d1aa.Left = x908338b83832d1aa.x06c65daad0c0656c;
		x908338b83832d1aa.Top = x908338b83832d1aa.x399bb78ac51a4081;
	}

	private static void x1989ad42a196d646(xf871da68decec406 xe134235b3526fa75, GroupShape x908338b83832d1aa)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		string x8b0a6a8c69ab5cff = "";
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a) && !xf871da68decec406.xec2649804854d946(xe134235b3526fa75, x908338b83832d1aa.xf7125312c7ee115c))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "z-index":
					x908338b83832d1aa.xf7125312c7ee115c.xae20093bed1e48a8(4154, xca994afbcb9073a.xbba6773b8ce56a01);
					break;
				case "transform":
					x8b0a6a8c69ab5cff = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				}
			}
		}
		xf871da68decec406.xc8cbf0c64adea241(x908338b83832d1aa.xf7125312c7ee115c, x8b0a6a8c69ab5cff);
	}

	private static void xf4ad35a4c681d85d(xf871da68decec406 xe134235b3526fa75, GroupShape x908338b83832d1aa, xeedad81aaed42a76 x789564759d365819)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x416ea3123144a39f("g", x764dfdef5d60f7e6.x278cc3fa1e8f2bcd))
		{
			if (xf871da68decec406.xfe4f7dca36c0076c(xe134235b3526fa75, x908338b83832d1aa, x789564759d365819, null))
			{
				xe134235b3526fa75.x5886c1038090f427 = true;
			}
			else
			{
				xe134235b3526fa75.xb18e918c8e329f66(x908338b83832d1aa.xf7125312c7ee115c);
			}
		}
	}
}
