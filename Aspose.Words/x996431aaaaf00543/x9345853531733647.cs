using System.Drawing;
using x1c8faa688b1f0b0c;
using x4dc96876c552a593;
using xeb326c6285a77ac1;

namespace x996431aaaaf00543;

internal class x9345853531733647 : x162d67570d6be3e3
{
	private x34b8da5e65f2d94f x63491dfc314ddfc4;

	public x34b8da5e65f2d94f x97c4cdb7669669f2
	{
		get
		{
			return x63491dfc314ddfc4;
		}
		set
		{
			x63491dfc314ddfc4 = value;
		}
	}

	public override x4fdf549af9de6b97 Render(x2094302a66c2ec77 nodeRenderParams)
	{
		nodeRenderParams.x1a1fb4b19097b9f6.x84e43ba1eb351dc4(GetTransform());
		try
		{
			x687bd29facb7e34a x687bd29facb7e34a = x4c1a949e2d5fc9d0(nodeRenderParams);
			xb8e7e788f6d59708 xb8e7e788f6d = base.x5d1f5ab5850c22b5.xe406325e56f74b46(x687bd29facb7e34a);
			if (x97c4cdb7669669f2 != null)
			{
				RectangleF x2727839aafc = GetTransform().x2727839aafc09868;
				RectangleF xefa4262da9bfb09c = new RectangleF(0f, 0f, x2727839aafc.Width, x2727839aafc.Height);
				xb8e7e788f6d.xd6b6ed77479ef68c(x97c4cdb7669669f2.xe406325e56f74b46(nodeRenderParams, xefa4262da9bfb09c, x687bd29facb7e34a));
			}
			x4ef42df82075df9e(nodeRenderParams.x1a1fb4b19097b9f6, xb8e7e788f6d);
			return xb8e7e788f6d;
		}
		finally
		{
			nodeRenderParams.x1a1fb4b19097b9f6.x23f6d2779534dd99();
		}
	}
}
