using Aspose.Words;
using Aspose.Words.Tables;
using x6c95d9cf46ff5f25;

namespace xfce5b6a304778b89;

internal class x01c528ef38106fa6
{
	private x01c528ef38106fa6()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, xc559a3dd8354bcaa x13eeaa19b4289a25, xc54ca6df458adfc5 xa806b754814b9ae0, bool xfd76f8a5ae437b32)
	{
		if (!xfd76f8a5ae437b32)
		{
			xcb27402694ec8794 xcb27402694ec8795 = new xcb27402694ec8794();
			xcb27402694ec8795.x11db8fc7f469a2fc = new Cell(xe134235b3526fa75.x2c8c6741422a1298);
			xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
			x2c12dc7d81bf5af4(xe134235b3526fa75, xcb27402694ec8795);
			if (!x0d299f323d241756.x5959bccb67bbf051(xe134235b3526fa75.xe5ffcf1e3f9bd387))
			{
				xe134235b3526fa75.xe5ffcf1e3f9bd387 = xa806b754814b9ae0.xe45972f6a0b167e5;
			}
			xb40eb2b6a428e174 xb40eb2b6a428e175 = (xb40eb2b6a428e174)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "table-cell", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
			if (xb40eb2b6a428e175 != null && xb40eb2b6a428e175.xf8cef531dae89ea3 != null)
			{
				xb40eb2b6a428e175.xf8cef531dae89ea3.xab3af626b1405ee8(xcb27402694ec8795.x11db8fc7f469a2fc.xf8cef531dae89ea3);
			}
			x4ded75cb61d1d6ca(xe134235b3526fa75, xb40eb2b6a428e175, xcb27402694ec8795.x11db8fc7f469a2fc, x13eeaa19b4289a25);
			xa806b754814b9ae0.Add(xcb27402694ec8795);
			x79b270d1052f1ca9(x13eeaa19b4289a25, xa806b754814b9ae0, xcb27402694ec8795);
		}
	}

	private static void x79b270d1052f1ca9(xc559a3dd8354bcaa x13eeaa19b4289a25, xc54ca6df458adfc5 xa806b754814b9ae0, xcb27402694ec8794 x24eef47398b98d87)
	{
		for (int i = 1; i < x24eef47398b98d87.x2f4795c5e4c1617e; i++)
		{
			if (xa806b754814b9ae0.Count >= x13eeaa19b4289a25.xc3f79a5f92dfdcee.Count)
			{
				break;
			}
			xcb27402694ec8794 xcb27402694ec8795 = new xcb27402694ec8794();
			xcb27402694ec8795.x338a5e6ab7c5595e = CellMerge.Previous;
			xcb27402694ec8795.x1a1dda35b3ae703d = x24eef47398b98d87.x1a1dda35b3ae703d;
			xcb27402694ec8795.x2f4795c5e4c1617e = x24eef47398b98d87.x2f4795c5e4c1617e;
			xcb27402694ec8795.xe9fd99df52338f59 = x24eef47398b98d87.xe9fd99df52338f59;
			xa806b754814b9ae0.Add(xcb27402694ec8795);
		}
	}

	private static void x2c12dc7d81bf5af4(xf871da68decec406 xe134235b3526fa75, xcb27402694ec8794 x24eef47398b98d87)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "number-columns-spanned":
					x24eef47398b98d87.x2f4795c5e4c1617e = xca994afbcb9073a.xbba6773b8ce56a01;
					x24eef47398b98d87.x338a5e6ab7c5595e = CellMerge.First;
					break;
				case "number-rows-spanned":
					x24eef47398b98d87.xe9fd99df52338f59 = xca994afbcb9073a.xbba6773b8ce56a01;
					x24eef47398b98d87.x1a1dda35b3ae703d = CellMerge.First;
					break;
				}
			}
		}
	}

	internal static void x4ded75cb61d1d6ca(xf871da68decec406 xe134235b3526fa75, xb40eb2b6a428e174 x44ecfea61c937b8e, Cell xe6de5e5fa2d44af5, xc559a3dd8354bcaa x13eeaa19b4289a25)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xca994afbcb9073a.x99f8cdb2827fa686();
		x78ad567c64a94dad.x06b0e25aa6ad68a9(xe134235b3526fa75, xca994afbcb9073a.xa66385d80d4d296f, xe6de5e5fa2d44af5, x13eeaa19b4289a25);
		xbd7bf35fec319ca7(xe134235b3526fa75, xe6de5e5fa2d44af5);
	}

	internal static void xbd7bf35fec319ca7(xf871da68decec406 xe134235b3526fa75, Cell xe6de5e5fa2d44af5)
	{
		if (xe6de5e5fa2d44af5.LastChild is Paragraph && !xe134235b3526fa75.xf3a0f9e4e429f8f2)
		{
			((Paragraph)xe6de5e5fa2d44af5.LastChild).x1a78664fa10a3755.xb55a99e2e1381d7f(1220);
		}
	}
}
