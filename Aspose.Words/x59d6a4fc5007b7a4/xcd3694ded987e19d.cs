using x4adf554d20d941a6;
using x6c95d9cf46ff5f25;

namespace x59d6a4fc5007b7a4;

internal class xcd3694ded987e19d : x038d2057eb729fcf
{
	private string xed4a7b1500064e12;

	internal override string xf9ad6fb78355fe13
	{
		get
		{
			if (xed4a7b1500064e12 == null)
			{
				xed4a7b1500064e12 = x038d2057eb729fcf.xe4b49d17e98f45f8(base.x56410a8dd70087c5.xf9ad6fb78355fe13);
				if (x247ed81d1f186ef7())
				{
					xed4a7b1500064e12 = x0d299f323d241756.xed53f96588a7739b(xed4a7b1500064e12);
				}
			}
			return xed4a7b1500064e12;
		}
		set
		{
			xed4a7b1500064e12 = x038d2057eb729fcf.xe4b49d17e98f45f8(value);
		}
	}

	internal xcd3694ded987e19d(x398b3bd0acd94b61 part)
		: base(part)
	{
	}

	internal xcd3694ded987e19d(x038d2057eb729fcf span, string text)
		: base(span.x9fb0e9c0b1bdc4b3)
	{
		xf9ad6fb78355fe13 = text;
	}

	internal override void x7012609bcdb39574(x3adba2572f6b9747 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.x5e3c9e6ae8d36dd1(this);
	}

	private bool x247ed81d1f186ef7()
	{
		if (base.x56410a8dd70087c5.x3a03159a374ab4fd == 1 && xed4a7b1500064e12.Length > 1)
		{
			return !x34a37b5a89c466fd.xfb345a6afecb5385(xed4a7b1500064e12[0]);
		}
		return false;
	}
}
