using x28925c9b27b37a46;

namespace xfce5b6a304778b89;

internal class x766fbaefce090d5a
{
	private x766fbaefce090d5a()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, xa02b88720ae12353 x44ecfea61c937b8e)
	{
		xfc72d4c9b765cad7 xfc72d4c9b765cad = new xfc72d4c9b765cad7();
		x44152c3f850a12d6(xe134235b3526fa75, xfc72d4c9b765cad);
		xf090537c8502e561(xe134235b3526fa75, xfc72d4c9b765cad);
		if (xfc72d4c9b765cad.xd44988f225497f3a > 0)
		{
			x44ecfea61c937b8e.xfc72d4c9b765cad7 = xfc72d4c9b765cad;
		}
	}

	private static void x44152c3f850a12d6(xf871da68decec406 xe134235b3526fa75, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		xe134235b3526fa75.x2c8c6741422a1298.CompatibilityOptions.NoColumnBalance = true;
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "dont-balance-text-columns" && xca994afbcb9073a.xd2f68ee6f47e9dfb == "false")
			{
				xe134235b3526fa75.x2c8c6741422a1298.CompatibilityOptions.NoColumnBalance = false;
			}
		}
	}

	internal static void xf090537c8502e561(xf871da68decec406 xe134235b3526fa75, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("section-properties"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "columns")
			{
				x05488f20088df8a9.xd155891a1e04d676(xe134235b3526fa75, x873e775b892867cf);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
	}
}
