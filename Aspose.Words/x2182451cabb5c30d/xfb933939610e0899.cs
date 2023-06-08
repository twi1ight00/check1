using System.Collections;
using Aspose.Words;
using Aspose.Words.Lists;

namespace x2182451cabb5c30d;

internal class xfb933939610e0899 : x77fb5b1d5c73757b
{
	private readonly Hashtable x873e474df27816d8;

	private List x870980ad82373217;

	internal xfb933939610e0899(xe5e546ef5f0503b2 context, Hashtable listStyles)
		: base(context)
	{
		x873e474df27816d8 = listStyles;
	}

	internal override void x41e7a76e7e854e6e(x03f56b37a0050a82 x153c99a852375422)
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x882db169e2cb7652)
		{
			x870980ad82373217 = new List(base.x2c8c6741422a1298, 0);
		}
	}

	internal override void xa4085ff83f9ddeeb()
	{
		if (base.x1a55de3a01c1c82d.x3146d638ec378671 == x25099a8bbbd55d1c.x882db169e2cb7652)
		{
			base.x2c8c6741422a1298.Lists.xa22e280934fc3004(x870980ad82373217);
			Style style = (Style)x873e474df27816d8[x870980ad82373217.x1eac770549050632];
			if (style != null)
			{
				style.x1a78664fa10a3755.x71c63f7e57f7ede5 = x870980ad82373217.ListId;
			}
		}
	}

	internal override void xa2d8e36cb99ac0f4(x03f56b37a0050a82 x153c99a852375422)
	{
		switch (x153c99a852375422.x1dafd189c5465293())
		{
		case "\\listid":
			x870980ad82373217.x1eac770549050632 = x153c99a852375422.xd6f9e3c5ae6509d7();
			break;
		case "\\ls":
			x870980ad82373217.xd01d085303c8ed31(x153c99a852375422.xd6f9e3c5ae6509d7());
			break;
		}
	}

	internal override x77fb5b1d5c73757b x3e0bce851c12a688(xbf575e106f2f2373 x8d3f74e5f925679c)
	{
		return x8d3f74e5f925679c.x3146d638ec378671 switch
		{
			x25099a8bbbd55d1c.x882db169e2cb7652 => this, 
			x25099a8bbbd55d1c.xe42b57ae8b7aa31c => new x54ce96b10ed440aa(x28fcdc775a1d069c, x870980ad82373217), 
			_ => null, 
		};
	}
}
