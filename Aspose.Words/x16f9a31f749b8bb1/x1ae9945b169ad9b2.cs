using System.IO;
using Aspose.Words;
using x28925c9b27b37a46;
using x9db5f2e5af3d596e;
using xa604c4d210ae0581;

namespace x16f9a31f749b8bb1;

internal class x1ae9945b169ad9b2 : x456c8b07916a8790
{
	private readonly xd503583b32a53cea x7ff04dd244132d8e;

	private readonly xa55b88ee4e81381b x17258deefeb290b7;

	private readonly x82985a3d7a64e540 x172509d410571cfd;

	private x1a78664fa10a3755 x4379ee33a06c4648;

	private x6ace28180a74825a xe1901b08fb542667;

	private xedb0eb766e25e0c9 xe661c29834d8220f;

	private readonly IWarningCallback xa056586c1f99e199;

	internal x1a78664fa10a3755 x1a78664fa10a3755 => x4379ee33a06c4648;

	internal x6ace28180a74825a x12d5a57a1541e872 => xe1901b08fb542667;

	internal xedb0eb766e25e0c9 xedb0eb766e25e0c9 => xe661c29834d8220f;

	internal x1ae9945b169ad9b2(BinaryReader dataReader, xd47c6c7442eb8033 revisionAuthors, x3a9e25666c8d1ee1 nFib, IWarningCallback warningCallback)
	{
		x7ff04dd244132d8e = new xd503583b32a53cea(this, dataReader);
		x17258deefeb290b7 = new xa55b88ee4e81381b(dataReader, revisionAuthors, warningCallback);
		x172509d410571cfd = new x82985a3d7a64e540(dataReader, revisionAuthors, nFib, warningCallback);
		xa056586c1f99e199 = warningCallback;
	}

	internal void x06b0e25aa6ad68a9(x3ff949c473a702d2 x03ef0b0129c670a6, byte[] x24c45257571ea504)
	{
		x4379ee33a06c4648 = new x1a78664fa10a3755();
		xe1901b08fb542667 = new x6ace28180a74825a();
		xe661c29834d8220f = null;
		x17258deefeb290b7.x53d3302394a93aa5(x4379ee33a06c4648, xe1901b08fb542667);
		x4379ee33a06c4648.xae20093bed1e48a8(1000, x03ef0b0129c670a6.x8301ab10c226b0c2);
		x7ff04dd244132d8e.x06b0e25aa6ad68a9(x03ef0b0129c670a6.x6b73aa01aa019d3a);
		x7ff04dd244132d8e.x06b0e25aa6ad68a9(x24c45257571ea504);
		if (xe661c29834d8220f != null)
		{
			x172509d410571cfd.x3301471272508313();
		}
		x17258deefeb290b7.x3301471272508313();
	}

	private bool x9b1a5fd2bd42bd55(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		switch (xe780cde24dcce6f2)
		{
		case x8de82539c936c298.x5c9e93d8164a04e3:
			return x17258deefeb290b7.x09a3d4a7eac8f520(x28180b3c3774af93, xe780cde24dcce6f2, x0d4f7f21e78721d6, xe134235b3526fa75);
		case x8de82539c936c298.xc760d3c548350954:
			if (xe661c29834d8220f == null)
			{
				xe661c29834d8220f = new xedb0eb766e25e0c9();
				x172509d410571cfd.x53d3302394a93aa5(xe661c29834d8220f, xe1901b08fb542667.xb8414804f39a9e90);
			}
			return x172509d410571cfd.x09a3d4a7eac8f520(x28180b3c3774af93, xe780cde24dcce6f2, x0d4f7f21e78721d6, xe134235b3526fa75);
		default:
			if (x28180b3c3774af93 != 0)
			{
				xbbf9a1ead81dd3a1(WarningType.UnexpectedContent, $"Unknown formatting modifier 0x{(int)x28180b3c3774af93:x4} occurred while reading DOC file.");
			}
			return true;
		}
	}

	bool x456c8b07916a8790.x09a3d4a7eac8f520(x875aca5784596b73 x28180b3c3774af93, x8de82539c936c298 xe780cde24dcce6f2, int x0d4f7f21e78721d6, BinaryReader xe134235b3526fa75)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x9b1a5fd2bd42bd55
		return this.x9b1a5fd2bd42bd55(x28180b3c3774af93, xe780cde24dcce6f2, x0d4f7f21e78721d6, xe134235b3526fa75);
	}

	private void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Doc, xc2358fbac7da3d45));
		}
	}
}
