using Aspose.Words;
using x28925c9b27b37a46;

namespace xfce5b6a304778b89;

internal class x65d2adf794d9cebc
{
	private x65d2adf794d9cebc()
	{
	}

	internal static void x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, x899ab188166aec2d x0f4599bff013bd18)
	{
		Section section = x0f4599bff013bd18.x10d7a1cae426b158.Clone();
		section.xfc72d4c9b765cad7.xe95664527db59e6e = SectionStart.Continuous;
		section.AppendChild(new Body(xe134235b3526fa75.x2c8c6741422a1298));
		x53a1c481b92411e7(xe134235b3526fa75, section.xfc72d4c9b765cad7);
		xa02b88720ae12353 xa02b88720ae12354 = (xa02b88720ae12353)xe134235b3526fa75.x37eb83f4e2a8fe56.get_xe6d4b1b411ed94b5(xe134235b3526fa75.xe5ffcf1e3f9bd387, "section", xe134235b3526fa75.xb9e32c79bd755ad8);
		if (xa02b88720ae12354 != null && xa02b88720ae12354.xfc72d4c9b765cad7 != null)
		{
			xa02b88720ae12354.xfc72d4c9b765cad7.xab3af626b1405ee8(section.xfc72d4c9b765cad7);
		}
		xe134235b3526fa75.x025b4232f6267898.Push(section);
		xe134235b3526fa75.xed48a3fa9b038203 = true;
		x78ad567c64a94dad.x06b0e25aa6ad68a9(xe134235b3526fa75, "section", section.Body);
		xe134235b3526fa75.x513275af5c756949 = true;
		xe134235b3526fa75.x025b4232f6267898.Pop();
	}

	private static void x53a1c481b92411e7(xf871da68decec406 xe134235b3526fa75, xfc72d4c9b765cad7 x873e775b892867cf)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			if (!xe134235b3526fa75.x81c468031b83f5fc(xca994afbcb9073a) && xca994afbcb9073a.xa66385d80d4d296f == "protected" && xca994afbcb9073a.xd2f68ee6f47e9dfb == "true")
			{
				xe134235b3526fa75.xf0012596d13ab3f3 = true;
				x873e775b892867cf.x3f5233cee263582a = false;
			}
		}
	}
}
