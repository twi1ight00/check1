using Aspose.Words;
using Aspose.Words.Math;

namespace xe5b37aee2c2a4d4e;

internal class xd909b0707303c682 : x52642f91ccdeeb35
{
	internal override x3e68720d12325f49 x3e68720d12325f49 => x3e68720d12325f49.x398384f7454300c1;

	internal override bool x8a4414b7d9d4073f(Node xda5bf54deb817e37)
	{
		if (base.x8a4414b7d9d4073f(xda5bf54deb817e37))
		{
			return true;
		}
		if (xda5bf54deb817e37.NodeType == NodeType.OfficeMath)
		{
			x3e68720d12325f49 x3e68720d12325f50 = ((OfficeMath)xda5bf54deb817e37).x52642f91ccdeeb35.x3e68720d12325f49;
			if (x3e68720d12325f50 != x3e68720d12325f49.x06b102f48629e32f)
			{
				return x3e68720d12325f50 == x3e68720d12325f49.x16984029356c96b7;
			}
			return true;
		}
		return false;
	}
}
