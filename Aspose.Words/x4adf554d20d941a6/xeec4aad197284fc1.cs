using System;

namespace x4adf554d20d941a6;

internal abstract class xeec4aad197284fc1 : x56410a8dd70087c5
{
	private readonly int x8cf825d90be23d37;

	internal override int x5566e2d2acbd1fbe => x8cf825d90be23d37;

	internal override int xbcd477821fdbd81b => Math.Min(base.x5a7799e1836857e3.xbcd477821fdbd81b, 13050);

	internal override int xb0f146032f47c24e => xbcd477821fdbd81b;

	internal override int xc821290d7ecc08bf
	{
		get
		{
			int num = xbcd477821fdbd81b * 82 / 100;
			return Math.Max(0, base.x5a7799e1836857e3.x139412b8dea2f02b - num);
		}
	}

	internal override string xf9ad6fb78355fe13
	{
		get
		{
			throw new InvalidOperationException("Text is not defined for SpanWmlSpeicial.");
		}
	}

	internal xeec4aad197284fc1(int spanType)
	{
		x8cf825d90be23d37 = spanType;
	}
}
