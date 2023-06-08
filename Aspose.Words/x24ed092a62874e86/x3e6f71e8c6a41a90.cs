using x5794c252ba25e723;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;

namespace x24ed092a62874e86;

internal class x3e6f71e8c6a41a90 : x94368fc8535b3ca3
{
	public x3e6f71e8c6a41a90()
	{
	}

	public x3e6f71e8c6a41a90(x55c6a66cc28d5b86 percentage)
	{
		base.xd2f68ee6f47e9dfb = percentage;
	}

	public override x26d9ecb4bdf0456d x57f70b425b43a885(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		int r = xde320dd89a728452(x6c50a99faab7d741.xc613adc4330033f3);
		int g = xde320dd89a728452(x6c50a99faab7d741.x26463655896fd90a);
		int b = xde320dd89a728452(x6c50a99faab7d741.x8e8f6cc6a0756b05);
		return new x26d9ecb4bdf0456d(x6c50a99faab7d741.xda71bf6f7c07c3bc, r, g, b);
	}

	private int xde320dd89a728452(int x7b28e8a789372508)
	{
		double num = x13fd50d6a130a211.xf49df313f3311164(x7b28e8a789372508);
		double x71c5078172d = base.xd2f68ee6f47e9dfb.x71c5078172d72420;
		num = ((!(x71c5078172d > 0.0)) ? (num * (1.0 + x71c5078172d)) : (num * x71c5078172d + (1.0 - x71c5078172d)));
		return x13fd50d6a130a211.xad84963169a664d8(num);
	}

	protected override x94368fc8535b3ca3 CreateEmptyObject()
	{
		return new x3e6f71e8c6a41a90();
	}
}
