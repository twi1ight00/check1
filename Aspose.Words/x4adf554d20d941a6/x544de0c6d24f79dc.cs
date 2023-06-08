using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x59d6a4fc5007b7a4;

namespace x4adf554d20d941a6;

internal class x544de0c6d24f79dc : xcc8377767090013e
{
	private readonly DrawingML x48154453a08515ea;

	private SizeF x3b77a41bd57164d6 = SizeF.Empty;

	private xa67197c42bddc7dc xb01da31da3ec3cd2;

	internal override double xdc1bf80853046136
	{
		get
		{
			x2b797a3c54087a9b();
			return x3b77a41bd57164d6.Width;
		}
	}

	internal override double xb0f146032f47c24e
	{
		get
		{
			x2b797a3c54087a9b();
			return x3b77a41bd57164d6.Height;
		}
	}

	internal override Node x40212106aad8a8b0 => x48154453a08515ea;

	internal override bool xc5bb70cfaaae4a20 => x48154453a08515ea.xf7125312c7ee115c.xab6edfb47ff0b74c == WrapType.Inline;

	internal override bool x831a5e8d62d04082 => false;

	internal override bool x96e55b5d052d1279 => false;

	internal override string x58c712b0d1d1c39b => "";

	internal override bool x024a13cfae9ff232 => false;

	internal override bool xcb478672544cad66 => false;

	internal override bool x332b663769fd4483 => true;

	internal x544de0c6d24f79dc(DrawingML node)
	{
		x48154453a08515ea = node;
		x3b77a41bd57164d6 = new SizeF((float)node.Width, (float)node.Height);
	}

	internal override void x291868888b5021b9(xa67197c42bddc7dc x5906905c888d3d98)
	{
		if (xc5bb70cfaaae4a20)
		{
			xb01da31da3ec3cd2 = x5906905c888d3d98;
		}
	}

	private void x2b797a3c54087a9b()
	{
		if (xb01da31da3ec3cd2 != null && xb01da31da3ec3cd2.xf29810c0a232d826)
		{
			xa7492065dee59ad0 xa7492065dee59ad = new xa7492065dee59ad0(xb01da31da3ec3cd2);
			xa7492065dee59ad.xe406325e56f74b46(xb01da31da3ec3cd2.xdeb77ea37ad74c56, out var _);
			x3b77a41bd57164d6 = xa7492065dee59ad.x7721ad963b03c6eb.xfe502558fa04ffb1.Size;
		}
		xb01da31da3ec3cd2 = null;
	}
}
