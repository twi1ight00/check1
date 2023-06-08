using System.Collections;
using xb1090543d168d647;
using xe86f37adaccef1c3;

namespace xfbd1009a0cbb9842;

internal class x5c9a4dc7d7dc8e67 : xea515a7e0d19a986
{
	private readonly xc5c3f438428cb03b x24edd27955741ac6;

	private readonly xea515a7e0d19a986 x60e542a0ae3f918d;

	private bool xc735c664f669ee00;

	internal x5c9a4dc7d7dc8e67(xc5c3f438428cb03b region, xea515a7e0d19a986 baseOverride)
	{
		x24edd27955741ac6 = region;
		x60e542a0ae3f918d = baseOverride;
	}

	private int x5a509fe7ac09c4a6(ArrayList x2ecbb33860b811fc, string xa628a17bf4cd031b)
	{
		if (x2ecbb33860b811fc.Count == 0)
		{
			int num = x24edd27955741ac6.xe3cf0bedd5b81485();
			xc735c664f669ee00 = num == -1;
			if (!xc735c664f669ee00)
			{
				return num;
			}
			return x60e542a0ae3f918d.x59e8b6b220bc288a(x2ecbb33860b811fc, xa628a17bf4cd031b);
		}
		if (!xc735c664f669ee00)
		{
			return 0;
		}
		return x60e542a0ae3f918d.x59e8b6b220bc288a(x2ecbb33860b811fc, xa628a17bf4cd031b);
	}

	int xea515a7e0d19a986.x59e8b6b220bc288a(ArrayList x2ecbb33860b811fc, string xa628a17bf4cd031b)
	{
		//ILSpy generated this explicit interface implementation from .override directive in x5a509fe7ac09c4a6
		return this.x5a509fe7ac09c4a6(x2ecbb33860b811fc, xa628a17bf4cd031b);
	}
}
