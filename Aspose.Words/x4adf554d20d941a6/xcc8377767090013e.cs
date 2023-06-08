using System;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Math;

namespace x4adf554d20d941a6;

internal abstract class xcc8377767090013e
{
	internal abstract double xb0f146032f47c24e { get; }

	internal abstract double xdc1bf80853046136 { get; }

	internal abstract Node x40212106aad8a8b0 { get; }

	internal abstract bool xc5bb70cfaaae4a20 { get; }

	internal abstract bool x831a5e8d62d04082 { get; }

	internal abstract bool x96e55b5d052d1279 { get; }

	internal abstract string x58c712b0d1d1c39b { get; }

	internal abstract bool x024a13cfae9ff232 { get; }

	internal abstract bool xcb478672544cad66 { get; }

	internal abstract bool x332b663769fd4483 { get; }

	internal static xcc8377767090013e x7a4c51050e4e7530(Node xda5bf54deb817e37)
	{
		switch (xda5bf54deb817e37.NodeType)
		{
		case NodeType.GroupShape:
		case NodeType.Shape:
			return new x4369d86026d53cd5((ShapeBase)xda5bf54deb817e37);
		case NodeType.DrawingML:
			return new x544de0c6d24f79dc((DrawingML)xda5bf54deb817e37);
		case NodeType.OfficeMath:
			return new xceb9556f0fd95aa6((OfficeMath)xda5bf54deb817e37);
		default:
			throw new InvalidOperationException("Unexpected node type.");
		}
	}

	internal abstract void x291868888b5021b9(xa67197c42bddc7dc x5906905c888d3d98);
}
