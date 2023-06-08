using Aspose.Words;
using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace xfce5b6a304778b89;

internal class x7d952172b19db999
{
	private x7d952172b19db999()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, x899ab188166aec2d x0f4599bff013bd18, string x4bbc2c453c470189)
	{
		xb77bc1b681ac1354 xb77bc1b681ac1355 = xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(x0f4599bff013bd18.x4fc90f517816f531, (string)null, xe134235b3526fa75.xb9e32c79bd755ad8, xafd04c36a00d5bcf: true) as xb77bc1b681ac1354;
		xfc72d4c9b765cad7 xfc72d4c9b765cad = null;
		if (xb77bc1b681ac1355 == null)
		{
			return;
		}
		HeaderFooter headerFooter = new HeaderFooter(xe134235b3526fa75.x2c8c6741422a1298, x6d4e1ab0ce5f5577(x0f4599bff013bd18, x4bbc2c453c470189));
		xe7279888a1c5b978 xe7279888a1c5b979 = (x4bbc2c453c470189.StartsWith("header") ? xb77bc1b681ac1355.xd9d19e4aaaecdf95 : xb77bc1b681ac1355.xcba1c710c374f14e);
		if (xe7279888a1c5b979 != null)
		{
			xfc72d4c9b765cad = xe7279888a1c5b979.xfc72d4c9b765cad7;
		}
		if (x4bbc2c453c470189.EndsWith("-left"))
		{
			xe134235b3526fa75.x2c8c6741422a1298.xdade2366eaa6f915.x5ac0ad056c3fce83 = true;
		}
		xfc72d4c9b765cad?.xab3af626b1405ee8(x0f4599bff013bd18.x10d7a1cae426b158.xfc72d4c9b765cad7);
		while (xe134235b3526fa75.xca994afbcb9073a2.x152cbadbfa8061b1(x4bbc2c453c470189))
		{
			switch (xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f)
			{
			case "p":
			case "h":
				xef3217fa00e6d2ba.x06b0e25aa6ad68a9(xe134235b3526fa75, xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f, headerFooter);
				break;
			case "list":
				x51bdb35997d05bcf.x06b0e25aa6ad68a9(xe134235b3526fa75, headerFooter, null);
				break;
			case "table":
				xcf7a5dc1222c8f51.x06b0e25aa6ad68a9(xe134235b3526fa75, headerFooter);
				break;
			case "table-of-content":
			case "table-index":
			case "bibliography":
				x86738d7528f4304b.x06b0e25aa6ad68a9(xe134235b3526fa75, headerFooter, x0f4599bff013bd18);
				break;
			default:
				xe134235b3526fa75.xca994afbcb9073a2.IgnoreElement();
				break;
			}
		}
		x0f4599bff013bd18.x10d7a1cae426b158.HeadersFooters.Add(headerFooter);
	}

	private static HeaderFooterType x6d4e1ab0ce5f5577(x899ab188166aec2d x0f4599bff013bd18, string x4bbc2c453c470189)
	{
		if (x4bbc2c453c470189.StartsWith("header"))
		{
			if (x4bbc2c453c470189.EndsWith("-left"))
			{
				return HeaderFooterType.HeaderEven;
			}
			if (x0d299f323d241756.x5959bccb67bbf051(x0f4599bff013bd18.x807b7c93ff3b2db6))
			{
				return HeaderFooterType.HeaderFirst;
			}
			return HeaderFooterType.HeaderPrimary;
		}
		if (x4bbc2c453c470189.EndsWith("-left"))
		{
			return HeaderFooterType.FooterEven;
		}
		if (x0d299f323d241756.x5959bccb67bbf051(x0f4599bff013bd18.x807b7c93ff3b2db6))
		{
			return HeaderFooterType.FooterFirst;
		}
		return HeaderFooterType.FooterPrimary;
	}
}
