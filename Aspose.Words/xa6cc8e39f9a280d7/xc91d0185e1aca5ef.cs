using x5794c252ba25e723;
using x6b8130194ad714f7;
using x6c95d9cf46ff5f25;
using x9e34b6f7e9185197;

namespace xa6cc8e39f9a280d7;

internal class xc91d0185e1aca5ef : x8af6aafe8486541b
{
	private x2f7951fa0946af7e x301c1d1c0870d859 = new x2f7951fa0946af7e(0.0);

	private x2f7951fa0946af7e x58997d13c35eb25c = new x2f7951fa0946af7e(0.0);

	private x2f7951fa0946af7e x254bb0e188c8a1d5 = new x2f7951fa0946af7e(0.0);

	public x2f7951fa0946af7e xc613adc4330033f3
	{
		get
		{
			return x254bb0e188c8a1d5;
		}
		set
		{
			x254bb0e188c8a1d5 = value;
		}
	}

	public x2f7951fa0946af7e x26463655896fd90a
	{
		get
		{
			return x58997d13c35eb25c;
		}
		set
		{
			x58997d13c35eb25c = value;
		}
	}

	public x2f7951fa0946af7e x8e8f6cc6a0756b05
	{
		get
		{
			return x301c1d1c0870d859;
		}
		set
		{
			x301c1d1c0870d859 = value;
		}
	}

	protected override x26d9ecb4bdf0456d CreateUnmodifiedColor(x6ecdfaec63740001 themeProvider)
	{
		int r = x15e971129fd80714.x43fcc3f62534530b(xc613adc4330033f3.x71c5078172d72420 * 255.0);
		int g = x15e971129fd80714.x43fcc3f62534530b(x26463655896fd90a.x71c5078172d72420 * 255.0);
		int b = x15e971129fd80714.x43fcc3f62534530b(x8e8f6cc6a0756b05.x71c5078172d72420 * 255.0);
		return new x26d9ecb4bdf0456d(r, g, b);
	}

	public override xd7e8497b32a408b8 x8b61531c8ea35b85()
	{
		xc91d0185e1aca5ef xc91d0185e1aca5ef2 = new xc91d0185e1aca5ef();
		xc91d0185e1aca5ef2.xc613adc4330033f3 = xc613adc4330033f3;
		xc91d0185e1aca5ef2.x26463655896fd90a = x26463655896fd90a;
		xc91d0185e1aca5ef2.x8e8f6cc6a0756b05 = x8e8f6cc6a0756b05;
		xbda3841a2cedd7e2(xc91d0185e1aca5ef2);
		return xc91d0185e1aca5ef2;
	}
}
