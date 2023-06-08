using Aspose.Words;
using x28925c9b27b37a46;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x96a5aac2efa9fd8a
{
	private x96a5aac2efa9fd8a()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, xeedad81aaed42a76 x789564759d365819, Style xce987d84406b1bfc)
	{
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		xa18c3a814ffd9901 xa18c3a814ffd9902 = x73144002edb412d6(xe134235b3526fa75);
		xb5219355ceba1113(xe134235b3526fa75);
		if (xa18c3a814ffd9902 is xdc86c0f058b433d5)
		{
			x5136f81f5d4bec94.x8602df7130e8ca26(xe134235b3526fa75, x8b2c3c076d5a7daf, xa18c3a814ffd9902 as xdc86c0f058b433d5, x789564759d365819, xce987d84406b1bfc);
		}
	}

	private static xa18c3a814ffd9901 x73144002edb412d6(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		xa18c3a814ffd9901 xa18c3a814ffd9902 = xe134235b3526fa75.x1673de9450d42ee5.x1dba2c5863398e07(xca994afbcb9073a.xd68abcd61e368af9("control", ""));
		if (xa18c3a814ffd9902 == null)
		{
			return null;
		}
		xca994afbcb9073a.x99f8cdb2827fa686();
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a))
			{
				switch (xca994afbcb9073a.xa66385d80d4d296f)
				{
				case "width":
					xa18c3a814ffd9902.xdc1bf80853046136 = xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				case "height":
					xa18c3a814ffd9902.xb0f146032f47c24e = xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
					break;
				}
			}
		}
		return xa18c3a814ffd9902;
	}

	private static void xb5219355ceba1113(xf871da68decec406 xe134235b3526fa75)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x152cbadbfa8061b1("control"))
		{
			_ = xe134235b3526fa75.xca994afbcb9073a2.xa66385d80d4d296f;
			xca994afbcb9073a.IgnoreElement();
		}
	}
}
