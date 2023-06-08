using Aspose.Words;
using Aspose.Words.Drawing;

namespace x28925c9b27b37a46;

internal class x07232060576f6c33 : x8e28d0731c3bcab3
{
	public x07232060576f6c33()
		: base(new NodeType[2]
		{
			NodeType.DrawingML,
			NodeType.Shape
		})
	{
	}

	internal override bool xc313ef0c9ca8870d(Node xda5bf54deb817e37)
	{
		if (!base.xc313ef0c9ca8870d(xda5bf54deb817e37))
		{
			return false;
		}
		if (xda5bf54deb817e37.NodeType == NodeType.Shape)
		{
			return ((Shape)xda5bf54deb817e37).HasImage;
		}
		return ((DrawingML)xda5bf54deb817e37).HasImage;
	}
}
