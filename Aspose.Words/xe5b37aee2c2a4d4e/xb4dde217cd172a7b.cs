using System;
using Aspose.Words;

namespace xe5b37aee2c2a4d4e;

internal class xb4dde217cd172a7b : x52642f91ccdeeb35
{
	internal const int xdca441151f13b8f4 = 0;

	private readonly x3e68720d12325f49 xc6b011d119cc566b;

	private int x44406cfb98d7ec1e;

	internal int x31f7427e3db1c1a8
	{
		get
		{
			return x44406cfb98d7ec1e;
		}
		set
		{
			int num = ((value < -2) ? (-2) : ((value > 2) ? 2 : value));
			if (num != 0)
			{
				x44406cfb98d7ec1e = num;
			}
		}
	}

	internal override bool xcbe541d3325b8546 => false;

	internal override bool x48738d418e15105b => false;

	internal override x3e68720d12325f49 x3e68720d12325f49 => xc6b011d119cc566b;

	internal xb4dde217cd172a7b(x3e68720d12325f49 type)
	{
		switch (type)
		{
		case x3e68720d12325f49.x2b691ff28e877ea4:
		case x3e68720d12325f49.x1745ba6c6d5efbc4:
		case x3e68720d12325f49.x194cb0ccf5358fec:
		case x3e68720d12325f49.x5ec114ef0df8072b:
		case x3e68720d12325f49.x8c55fc884c93cb9f:
		case x3e68720d12325f49.x25d26846c330b189:
		case x3e68720d12325f49.x06b102f48629e32f:
		case x3e68720d12325f49.x16984029356c96b7:
			xc6b011d119cc566b = type;
			break;
		default:
			throw new InvalidOperationException("Please report exception");
		}
	}

	internal override bool x8a4414b7d9d4073f(Node xda5bf54deb817e37)
	{
		return x52642f91ccdeeb35.x6696894f491bb1a0(xda5bf54deb817e37);
	}
}
