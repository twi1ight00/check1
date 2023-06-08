using Aspose.Words;
using Aspose.Words.Tables;
using x9db5f2e5af3d596e;

namespace xda075892eccab2ad;

internal class x4cf3b47199c96529
{
	private x4cf3b47199c96529()
	{
	}

	internal static bool x9e11fbf631e85f6c(DocumentBase x6beba47238e0ade6, xedb0eb766e25e0c9 xe193ceb565ecaa0a, int xba08ce632055a1d9)
	{
		for (TableStyle tableStyle = (TableStyle)x6beba47238e0ade6.Styles.x1976fb6958cf7237(xe193ceb565ecaa0a.x8301ab10c226b0c2, x988fcf605f8efa7e: false); tableStyle != null; tableStyle = (TableStyle)tableStyle.xea729b8c7bbb5bb0())
		{
			if (tableStyle.x511a581657d77f2b.xbc5dc59d0d9b620d(xba08ce632055a1d9))
			{
				return true;
			}
			if (tableStyle.xedb0eb766e25e0c9.xbc5dc59d0d9b620d(xba08ce632055a1d9))
			{
				return true;
			}
		}
		return false;
	}

	internal static int x48bdf8f97244c548(TableStyleOptions xdfde339da46db651)
	{
		return (int)(xdfde339da46db651 ^ TableStyleOptions.Default2003);
	}

	internal static TableStyleOptions xb7e770c54c5f7404(int xbcea506a33cf9111)
	{
		return (TableStyleOptions)(xbcea506a33cf9111 ^ 0x600);
	}
}
