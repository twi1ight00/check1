using Aspose.Words;
using x556d8f9846e43329;
using x6c95d9cf46ff5f25;

namespace x2182451cabb5c30d;

internal class x8a31fc9888704a72 : xe16295e98b4802cb
{
	internal x8a31fc9888704a72(xe5e546ef5f0503b2 context)
		: base(context)
	{
	}

	protected override bool ParseSingleToken(x03f56b37a0050a82 token)
	{
		Border x51d60f077c5fc6e = base.x28fcdc775a1d069c.x51d60f077c5fc6e0;
		if (x51d60f077c5fc6e == null)
		{
			return false;
		}
		switch (token.x1dafd189c5465293())
		{
		case "\\brdrw":
		{
			int xf6495da3f9ed2d9c = token.xd6f9e3c5ae6509d7();
			double xce90ee8e = (x51d60f077c5fc6e.xbca512cb9f5a451a ? xa0d3611565b2a1f2.x61f4dd4997f9c927(xf6495da3f9ed2d9c) : x4574ea26106f0edb.x0e1fdb362561ddb2(xf6495da3f9ed2d9c));
			x51d60f077c5fc6e.x3b83679cceee1fab(xce90ee8e);
			break;
		}
		case "\\brdrcf":
			x51d60f077c5fc6e.x63b1a7c31a962459 = base.x28fcdc775a1d069c.x88bf28725f671e38.get_xe6d4b1b411ed94b5(token.xd6f9e3c5ae6509d7());
			break;
		case "\\brsp":
			x51d60f077c5fc6e.xd0ddb5dfe7e0d9df(x4574ea26106f0edb.x0e1fdb362561ddb2(token.xd6f9e3c5ae6509d7()));
			break;
		case "\\brdrframe":
			x51d60f077c5fc6e.x227665e444fb500a = true;
			break;
		case "\\brdrsh":
			x51d60f077c5fc6e.Shadow = true;
			break;
		case "\\brdrart":
			x51d60f077c5fc6e.LineStyle = xa0d3611565b2a1f2.x0ea0020e26ffd130(token.xd6f9e3c5ae6509d7());
			break;
		default:
			return false;
		}
		return true;
	}

	protected override bool SearchInEnums(x03f56b37a0050a82 token)
	{
		if (base.x28fcdc775a1d069c.x51d60f077c5fc6e0 == null)
		{
			return false;
		}
		object obj = x1cf55bf1c1c040ec.x66d300ae30bf6a9d(token.x1dafd189c5465293());
		if (obj != null)
		{
			base.x28fcdc775a1d069c.x51d60f077c5fc6e0.LineStyle = (LineStyle)obj;
			return true;
		}
		return false;
	}
}
