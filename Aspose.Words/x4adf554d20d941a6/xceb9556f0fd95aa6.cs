using System.Drawing;
using Aspose.Words;
using Aspose.Words.Math;
using x50d2f537cc336076;

namespace x4adf554d20d941a6;

internal class xceb9556f0fd95aa6 : xcc8377767090013e
{
	private x57df270da83ea6de xe5b759021dad6c06;

	private readonly OfficeMath x48154453a08515ea;

	private SizeF x3b77a41bd57164d6 = SizeF.Empty;

	internal override double xb0f146032f47c24e => x3b77a41bd57164d6.Height;

	internal override double xdc1bf80853046136 => x3b77a41bd57164d6.Width;

	internal override Node x40212106aad8a8b0 => x48154453a08515ea;

	internal override bool xc5bb70cfaaae4a20 => true;

	internal override bool x831a5e8d62d04082 => false;

	internal override bool x96e55b5d052d1279 => false;

	internal override string x58c712b0d1d1c39b => "";

	internal override bool x024a13cfae9ff232 => false;

	internal override bool xcb478672544cad66 => false;

	internal override bool x332b663769fd4483 => false;

	internal x57df270da83ea6de x57df270da83ea6de => xe5b759021dad6c06;

	internal xceb9556f0fd95aa6(OfficeMath node)
	{
		x48154453a08515ea = node;
		x30a8612e5702cae7 x30a8612e5702cae = new x30a8612e5702cae7();
		xe5b759021dad6c06 = x30a8612e5702cae.x5b81632e5b71b64c(x48154453a08515ea);
		x3b77a41bd57164d6 = new SizeF(xe5b759021dad6c06.x6ae4612a8469678e.Width, xe5b759021dad6c06.x6ae4612a8469678e.Height);
	}

	internal override void x291868888b5021b9(xa67197c42bddc7dc x5906905c888d3d98)
	{
		if (xe5b759021dad6c06 != null)
		{
			x3b77a41bd57164d6 = new SizeF(xe5b759021dad6c06.x6ae4612a8469678e.Width, xe5b759021dad6c06.x6ae4612a8469678e.Height);
		}
	}
}
