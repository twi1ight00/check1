using x5794c252ba25e723;
using x9e34b6f7e9185197;

namespace xa6cc8e39f9a280d7;

internal class x84984d61907ac93b : x8af6aafe8486541b
{
	private string x132d23d487b0e3d4;

	private string x4574aea041dd835f;

	public string xd2f68ee6f47e9dfb
	{
		get
		{
			if (x4574aea041dd835f == null)
			{
				x4574aea041dd835f = string.Empty;
			}
			return x4574aea041dd835f;
		}
		set
		{
			x4574aea041dd835f = value;
		}
	}

	public string x30f7758261c05307
	{
		get
		{
			if (x132d23d487b0e3d4 == null)
			{
				x132d23d487b0e3d4 = string.Empty;
			}
			return x132d23d487b0e3d4;
		}
		set
		{
			x132d23d487b0e3d4 = value;
		}
	}

	protected override x26d9ecb4bdf0456d CreateUnmodifiedColor(x6ecdfaec63740001 themeProvider)
	{
		if (x30f7758261c05307.Length == 0)
		{
			return x26d9ecb4bdf0456d.x45260ad4b94166f2;
		}
		return x43287db0aa155c99.xa85c3c231557eaae(x30f7758261c05307);
	}

	public override xd7e8497b32a408b8 x8b61531c8ea35b85()
	{
		x84984d61907ac93b x84984d61907ac93b2 = new x84984d61907ac93b();
		x84984d61907ac93b2.xd2f68ee6f47e9dfb = xd2f68ee6f47e9dfb;
		x84984d61907ac93b2.x30f7758261c05307 = x30f7758261c05307;
		xbda3841a2cedd7e2(x84984d61907ac93b2);
		return x84984d61907ac93b2;
	}
}
