using x5794c252ba25e723;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;

namespace x24ed092a62874e86;

internal class xc11f878785193b2d : x94368fc8535b3ca3
{
	public xc11f878785193b2d()
	{
	}

	public xc11f878785193b2d(x55c6a66cc28d5b86 value)
	{
		base.xd2f68ee6f47e9dfb = value;
	}

	public override x26d9ecb4bdf0456d x57f70b425b43a885(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		int r = xd4d9335470be4176(x6c50a99faab7d741.xc613adc4330033f3);
		int g = xd4d9335470be4176(x6c50a99faab7d741.x26463655896fd90a);
		int b = xd4d9335470be4176(x6c50a99faab7d741.x8e8f6cc6a0756b05);
		return new x26d9ecb4bdf0456d(x6c50a99faab7d741.xda71bf6f7c07c3bc, r, g, b);
	}

	private int xd4d9335470be4176(int x7b28e8a789372508)
	{
		double num = x13fd50d6a130a211.xf49df313f3311164(x7b28e8a789372508);
		num *= base.xd2f68ee6f47e9dfb.x71c5078172d72420;
		return x13fd50d6a130a211.xad84963169a664d8(x15e971129fd80714.xe193c76ba76a5afc(num, 0.0, 1.0));
	}

	protected override x94368fc8535b3ca3 CreateEmptyObject()
	{
		return new xc11f878785193b2d();
	}
}
