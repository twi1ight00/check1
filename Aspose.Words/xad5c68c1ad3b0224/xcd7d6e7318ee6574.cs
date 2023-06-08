using System.Collections;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x5f5ca2a37b849b4a;
using x6c95d9cf46ff5f25;
using x7cd71466ce904867;
using x8bb6b4f09b5230a5;
using x996431aaaaf00543;

namespace xad5c68c1ad3b0224;

internal class xcd7d6e7318ee6574
{
	private xd4e66257276c6905 xa0db25b371643a4d;

	private xe9481907c579c280 xd995695f8e3419d6;

	private x08189a95e3ef4899 x92846a201c23924a;

	private xdf0f9e5e28bc4d1c xf58367db0c684103;

	private SizeF xc79460a2ad0bf0a7;

	private Stack xf8f23af472995af8 = new Stack();

	internal xb8e7e788f6d59708 xc9443bca5b0a56d8 => (xb8e7e788f6d59708)xf8f23af472995af8.Peek();

	internal x08189a95e3ef4899 x5e969e12ada2aab2 => x92846a201c23924a;

	internal xe9481907c579c280 xca687bd498227c89 => xd995695f8e3419d6;

	internal xdf0f9e5e28bc4d1c xdf9285c24d089295
	{
		get
		{
			if (xf58367db0c684103 == null)
			{
				xf58367db0c684103 = new xdf0f9e5e28bc4d1c(xd995695f8e3419d6.xe9e9c556ec0c3e33);
			}
			return xf58367db0c684103;
		}
	}

	internal SizeF x43e348908d6e68da => xc79460a2ad0bf0a7;

	internal xd4e66257276c6905 xf7403ba6b74ed227 => xa0db25b371643a4d;

	internal int xfe2178c1f916f36c => xa0db25b371643a4d.xfe2178c1f916f36c;

	internal xcd7d6e7318ee6574(xd4e66257276c6905 chartSpace, x2094302a66c2ec77 nodeRenderParams)
	{
		xa0db25b371643a4d = chartSpace;
		x92846a201c23924a = new x08189a95e3ef4899(this);
		xd995695f8e3419d6 = nodeRenderParams.xca687bd498227c89;
		xc79460a2ad0bf0a7 = new SizeF(x4574ea26106f0edb.x3aa08882c9feaf96(nodeRenderParams.x43e348908d6e68da.Width), x4574ea26106f0edb.x3aa08882c9feaf96(nodeRenderParams.x43e348908d6e68da.Height));
		xf8f23af472995af8.Push(new xb8e7e788f6d59708());
	}

	internal void x490834a62c46f14d(xb8e7e788f6d59708 x08ce8f4769eb3234)
	{
		xc9443bca5b0a56d8.xd6b6ed77479ef68c(x08ce8f4769eb3234);
		xf8f23af472995af8.Push(x08ce8f4769eb3234);
	}

	internal void xf5b0b9b6ff7ac462()
	{
		xf8f23af472995af8.Pop();
	}
}
