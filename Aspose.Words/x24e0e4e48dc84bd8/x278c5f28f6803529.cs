using x5794c252ba25e723;
using x74500b509de15565;

namespace x24e0e4e48dc84bd8;

internal class x278c5f28f6803529
{
	private readonly x4e88096751fad171 xd995695f8e3419d6;

	private int xd92046fb57459be4;

	private x26d9ecb4bdf0456d x78e4acec873c7675;

	private bool xba8b4174c4c84d59;

	private xf67b8f3d5352fefb x1529fde15094ab27;

	private x28a5d52551b64191 x7450cc1e48712286;

	private x7cf45d99b6b735e8 xe44f61b8aae3103d;

	public x278c5f28f6803529(x4e88096751fad171 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
		xe44f61b8aae3103d = xd995695f8e3419d6.xe3e99d3417159bec;
		x7450cc1e48712286 = xd995695f8e3419d6.xf86de1bd2f396938;
		x1529fde15094ab27 = xd995695f8e3419d6.x9deec9457dc2451d;
	}

	public x845d6a068e0b03c5 xa3fa1ce4ffca3dc3()
	{
		if (xba8b4174c4c84d59)
		{
			return new xc020fa2f5133cba8(x78e4acec873c7675);
		}
		return (x845d6a068e0b03c5)x1529fde15094ab27.x38758cbbee49e4cb(xd92046fb57459be4);
	}

	public void x706c726a8e9cc23f()
	{
		xba8b4174c4c84d59 = xe44f61b8aae3103d.x586b7652ac7cefe0.x375aed0ef1326002(0);
		if (xba8b4174c4c84d59)
		{
			x78e4acec873c7675 = x7450cc1e48712286.x458cbe2343cf2fba();
		}
		else
		{
			xd92046fb57459be4 = x7450cc1e48712286.ReadInt32();
		}
	}
}
