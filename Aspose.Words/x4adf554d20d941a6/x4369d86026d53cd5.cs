using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using x59d6a4fc5007b7a4;

namespace x4adf554d20d941a6;

internal class x4369d86026d53cd5 : xcc8377767090013e
{
	private readonly ShapeBase x48154453a08515ea;

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

	internal override bool xc5bb70cfaaae4a20 => x48154453a08515ea.IsInline;

	internal override bool x831a5e8d62d04082 => x48154453a08515ea.IsImage;

	internal override bool x96e55b5d052d1279 => x48154453a08515ea.x96e55b5d052d1279;

	internal override string x58c712b0d1d1c39b => x48154453a08515ea.HRef;

	internal override bool x024a13cfae9ff232 => x48154453a08515ea.x73db39780c76cb8d;

	internal override bool xcb478672544cad66 => x48154453a08515ea.IsWordArt;

	internal override bool x332b663769fd4483 => false;

	private bool x9badaacc112365d3
	{
		get
		{
			if (x48154453a08515ea.NodeType == NodeType.Shape && x48154453a08515ea.HasChildNodes)
			{
				return ((Shape)x48154453a08515ea).x3ffbaff53e6d8618;
			}
			return false;
		}
	}

	internal x4369d86026d53cd5(ShapeBase node)
	{
		x48154453a08515ea = node;
		x3b77a41bd57164d6 = x48154453a08515ea.SizeInPoints;
	}

	internal override void x291868888b5021b9(xa67197c42bddc7dc x5906905c888d3d98)
	{
		if (xc5bb70cfaaae4a20 || (x9badaacc112365d3 && x5906905c888d3d98.x92adfed6f1d8efe4 == null && x5906905c888d3d98.xd8cde6b694c3af46 == null))
		{
			xb01da31da3ec3cd2 = x5906905c888d3d98;
		}
	}

	private void x2b797a3c54087a9b()
	{
		if (xb01da31da3ec3cd2 != null && xb01da31da3ec3cd2.xf29810c0a232d826 && xb01da31da3ec3cd2.x92adfed6f1d8efe4 == null && xb01da31da3ec3cd2.xd8cde6b694c3af46 == null)
		{
			xa7492065dee59ad0 xa7492065dee59ad = new xa7492065dee59ad0(xb01da31da3ec3cd2);
			xa7492065dee59ad.xe406325e56f74b46(xb01da31da3ec3cd2.x2c8c6741422a1298.xdeb77ea37ad74c56, out var _);
			x3b77a41bd57164d6 = xa7492065dee59ad.x7721ad963b03c6eb.xfe502558fa04ffb1.Size;
		}
		xb01da31da3ec3cd2 = null;
	}
}
