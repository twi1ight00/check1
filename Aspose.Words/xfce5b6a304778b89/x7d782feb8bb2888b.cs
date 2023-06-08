using Aspose.Words;
using x6c95d9cf46ff5f25;

namespace xfce5b6a304778b89;

internal class x7d782feb8bb2888b
{
	private x7d782feb8bb2888b()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("master-styles"))
		{
			string xa66385d80d4d296f;
			if ((xa66385d80d4d296f = xca994afbcb9073a.xa66385d80d4d296f) != null && xa66385d80d4d296f == "master-page")
			{
				xdcd63a27e81b4ea9.x06b0e25aa6ad68a9(xe134235b3526fa75);
			}
			else
			{
				xca994afbcb9073a.IgnoreElement();
			}
		}
		x86e697a4a77285b5(xe134235b3526fa75.x071d9b5ee3757e23);
	}

	internal static void x86e697a4a77285b5(xb129d89e9ebefa31 x2322f9a9544d0a88)
	{
		foreach (x899ab188166aec2d item in x2322f9a9544d0a88)
		{
			if (x0d299f323d241756.x5959bccb67bbf051(item.x807b7c93ff3b2db6))
			{
				x899ab188166aec2d x899ab188166aec2d3 = x2322f9a9544d0a88.get_xe6d4b1b411ed94b5(item.x807b7c93ff3b2db6);
				if (x899ab188166aec2d3 != null)
				{
					x0095eba7d67e198b(item, x899ab188166aec2d3, HeaderFooterType.HeaderPrimary);
					x0095eba7d67e198b(item, x899ab188166aec2d3, HeaderFooterType.FooterPrimary);
					item.x10d7a1cae426b158.xfc72d4c9b765cad7.x3e6533cdb8036bea = true;
				}
			}
		}
	}

	internal static void x0095eba7d67e198b(x899ab188166aec2d x0f4599bff013bd18, x899ab188166aec2d xfda8fb6fe2a58eaa, HeaderFooterType xa685fef1a31f5d4d)
	{
		HeaderFooter headerFooter = xfda8fb6fe2a58eaa.x10d7a1cae426b158.HeadersFooters[xa685fef1a31f5d4d];
		if (headerFooter != null)
		{
			x0f4599bff013bd18.x10d7a1cae426b158.HeadersFooters.Add(headerFooter.Clone(isCloneChildren: true));
		}
	}
}
