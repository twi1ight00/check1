using Aspose.Words;
using Aspose.Words.Drawing;
using xbe73d5820f7f4ae3;

namespace xfce5b6a304778b89;

internal class x451afc3a84b05bf5
{
	private x451afc3a84b05bf5()
	{
	}

	internal static double x06b0e25aa6ad68a9(xf871da68decec406 xe134235b3526fa75, CompositeNode x8b2c3c076d5a7daf, Shape x5770cdefd8931aa9)
	{
		xe134235b3526fa75.xe5ffcf1e3f9bd387 = null;
		double result = x1d1b335d3e85b243(xe134235b3526fa75, x5770cdefd8931aa9);
		x22fd53822b176d76(xe134235b3526fa75, x5770cdefd8931aa9);
		if (xe134235b3526fa75.x6147b51b34c29eea.Count > 0)
		{
			if (((Paragraph)xe134235b3526fa75.x6147b51b34c29eea[xe134235b3526fa75.x6147b51b34c29eea.Count - 1]).xd2c86fb8ed7b1331)
			{
				Paragraph paragraph = new Paragraph(xe134235b3526fa75.x2c8c6741422a1298);
				paragraph.AppendChild(x5770cdefd8931aa9);
				xe134235b3526fa75.x6147b51b34c29eea.Add(paragraph);
			}
			else
			{
				((Paragraph)xe134235b3526fa75.x6147b51b34c29eea[xe134235b3526fa75.x6147b51b34c29eea.Count - 1]).AppendChild(x5770cdefd8931aa9);
			}
		}
		else if (x8b2c3c076d5a7daf is Body || x8b2c3c076d5a7daf == null)
		{
			Paragraph paragraph2 = new Paragraph(xe134235b3526fa75.x2c8c6741422a1298);
			paragraph2.AppendChild(x5770cdefd8931aa9);
			xe134235b3526fa75.x6147b51b34c29eea.Add(paragraph2);
			if (x8b2c3c076d5a7daf is Body)
			{
				x8b2c3c076d5a7daf.AppendChild((Paragraph)xe134235b3526fa75.x6147b51b34c29eea[xe134235b3526fa75.x6147b51b34c29eea.Count - 1]);
			}
		}
		else
		{
			x8b2c3c076d5a7daf.AppendChild(x5770cdefd8931aa9);
		}
		return result;
	}

	private static double x1d1b335d3e85b243(xf871da68decec406 xe134235b3526fa75, Shape x5770cdefd8931aa9)
	{
		x536e1b48249b1390 xca994afbcb9073a = xe134235b3526fa75.xca994afbcb9073a2;
		double result = double.NaN;
		while (xca994afbcb9073a.x1ac1960adc8c4c39())
		{
			switch (xca994afbcb9073a.xa66385d80d4d296f)
			{
			case "min-height":
				result = xbb857c9fc36f5054.xc42baa2576960ea5(xca994afbcb9073a.xd2f68ee6f47e9dfb);
				break;
			}
		}
		return result;
	}

	internal static void x22fd53822b176d76(xf871da68decec406 xe134235b3526fa75, Shape x5770cdefd8931aa9)
	{
		x78ad567c64a94dad.x06b0e25aa6ad68a9(xe134235b3526fa75, "text-box", x5770cdefd8931aa9);
	}
}
