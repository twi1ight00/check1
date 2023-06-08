using Aspose.Words;
using Aspose.Words.Math;

namespace xe5b37aee2c2a4d4e;

internal class x6dd1552d6eb89e4e : x52642f91ccdeeb35
{
	internal const char x7bc27edc06d8aefd = '∫';

	internal override x3e68720d12325f49 x3e68720d12325f49 => x3e68720d12325f49.x2ffb9ed185cafd85;

	internal char x067d56aec20cdd99
	{
		get
		{
			return (char)xfe91eeeafcb3026a(15045);
		}
		set
		{
			xae20093bed1e48a8(15045, value, value != '∫');
		}
	}

	internal bool xe316f972e75b51de
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(15210);
		}
		set
		{
			xae20093bed1e48a8(15210, value, value);
		}
	}

	internal xf47bac63068c8fd6 xe3e2b72900be18d6
	{
		get
		{
			return (xf47bac63068c8fd6)xfe91eeeafcb3026a(15510);
		}
		set
		{
			xae20093bed1e48a8(15510, value, value != xf47bac63068c8fd6.x236cb0a4295bc034);
		}
	}

	internal bool x42d0b8bb3dc018f1
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(15520);
		}
		set
		{
			xae20093bed1e48a8(15520, value, value);
		}
	}

	internal bool x6e65f77ea9696a75
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(15530);
		}
		set
		{
			xae20093bed1e48a8(15530, value, value);
		}
	}

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
