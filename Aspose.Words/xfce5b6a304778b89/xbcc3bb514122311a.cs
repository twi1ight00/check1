using System;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class xbcc3bb514122311a
{
	private xbcc3bb514122311a()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, x30d3766026a936d9 x1a3e1a5d7fe6a20f, xc559a3dd8354bcaa x13eeaa19b4289a25, bool x59c6d00e0898f6b8)
	{
		xc54ca6df458adfc5 xc54ca6df458adfc6 = new xc54ca6df458adfc5();
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		xc6d34d994d5c8134(xe134235b3526fa75, xc54ca6df458adfc6);
		xac09988577d41b0c xac09988577d41b0c2 = (xac09988577d41b0c)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "table-row", xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true);
		if (xac09988577d41b0c2 != null && xac09988577d41b0c2.xedb0eb766e25e0c9 != null)
		{
			xac09988577d41b0c2.xedb0eb766e25e0c9.xab3af626b1405ee8(xc54ca6df458adfc6.xedb0eb766e25e0c9);
		}
		x1a3e1a5d7fe6a20f.Add(xc54ca6df458adfc6);
		xdfada83792188250(xe134235b3526fa75, x13eeaa19b4289a25, xc54ca6df458adfc6);
		if (x13eeaa19b4289a25 != null)
		{
			xc54ca6df458adfc6.xedb0eb766e25e0c9.xc0741c7ff92cf1aa = xbb857c9fc36f5054.x286c839093f58b61(x13eeaa19b4289a25.xb09bf7248f4ba6cb.xa3e94d39710969ea.xc334118c782d9421);
		}
		if (x59c6d00e0898f6b8)
		{
			xc54ca6df458adfc6.xedb0eb766e25e0c9.xae20093bed1e48a8(4040, true);
		}
		x1a3e1a5d7fe6a20f.x5840ec53f70adb17 = Math.Max(x1a3e1a5d7fe6a20f.x5840ec53f70adb17, xc54ca6df458adfc6.Count);
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, x30d3766026a936d9 x1a3e1a5d7fe6a20f, xc559a3dd8354bcaa x13eeaa19b4289a25)
	{
		x06b0e25aa6ad68a9(xe134235b3526fa75, x1a3e1a5d7fe6a20f, x13eeaa19b4289a25, x59c6d00e0898f6b8: false);
	}

	private static void xc6d34d994d5c8134(xf871da68decec406 xe134235b3526fa75, xc54ca6df458adfc5 xa806b754814b9ae0)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "number-rows-repeated":
					xa806b754814b9ae0.x01e90984b4ad143d = xca994afbcb9073a.xbba6773b8ce56a01;
					break;
				case "default-cell-style-name":
					xa806b754814b9ae0.xe45972f6a0b167e5 = xca994afbcb9073a.xd2f68ee6f47e9dfb;
					break;
				}
			}
		}
	}

	internal static void xdfada83792188250(xf871da68decec406 xe134235b3526fa75, xc559a3dd8354bcaa x13eeaa19b4289a25, xc54ca6df458adfc5 xa806b754814b9ae0)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("table-row"))
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "table-cell":
				x01c528ef38106fa6.x06b0e25aa6ad68a9(xe134235b3526fa75, x13eeaa19b4289a25, xa806b754814b9ae0, xfd76f8a5ae437b32: false);
				break;
			case "covered-table-cell":
				x01c528ef38106fa6.x06b0e25aa6ad68a9(xe134235b3526fa75, x13eeaa19b4289a25, xa806b754814b9ae0, xfd76f8a5ae437b32: true);
				break;
			default:
				xca994afbcb9073a.IgnoreElement();
				break;
			}
		}
	}
}
