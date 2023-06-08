using Aspose.Words;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class xdcd63a27e81b4ea9
{
	private xdcd63a27e81b4ea9()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75)
	{
		x899ab188166aec2d x899ab188166aec2d2 = new x899ab188166aec2d();
		xb0658955274848d3(xe134235b3526fa75, x899ab188166aec2d2);
		if (xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(x899ab188166aec2d2.x4fc90f517816f531, (string)null, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true) is xb77bc1b681ac1354 xb77bc1b681ac1355 && xb77bc1b681ac1355.xfc72d4c9b765cad7 != null)
		{
			x899ab188166aec2d2.x10d7a1cae426b158 = new Section(xe134235b3526fa75.x2c8c6741422a1298, xb77bc1b681ac1355.xfc72d4c9b765cad7);
		}
		else
		{
			x899ab188166aec2d2.x10d7a1cae426b158 = new Section(xe134235b3526fa75.x2c8c6741422a1298);
		}
		xe134235b3526fa75.x071d9b5ee3757e23.Add(x899ab188166aec2d2);
		xa128574005c33d46(xe134235b3526fa75, x899ab188166aec2d2);
	}

	private static void xb0658955274848d3(xf871da68decec406 xe134235b3526fa75, x899ab188166aec2d x0f4599bff013bd18)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xf871da68decec406.x8125d547dbbe8218(xca994afbcb9073a, x0f4599bff013bd18))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "page-layout-name":
					x0f4599bff013bd18.x4fc90f517816f531 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				case "next-style-name":
					x0f4599bff013bd18.x807b7c93ff3b2db6 = xbb857c9fc36f5054.x94045081801bb82d(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				}
			}
		}
	}

	private static void xa128574005c33d46(xf871da68decec406 xe134235b3526fa75, x899ab188166aec2d x0f4599bff013bd18)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("master-page"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "header":
			case "footer":
			case "header-left":
			case "footer-left":
				x7d952172b19db999.x06b0e25aa6ad68a9(xe134235b3526fa75, x0f4599bff013bd18, xca994afbcb9073a.xa66385d80d4d296f);
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}
}
