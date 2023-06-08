using System;

namespace x4adf554d20d941a6;

internal class x06e41c15cb47ffad
{
	private xfb0c927634a887df xd2fe441f9b47eff7;

	private xfb0c927634a887df x212ae880d15d2ed1;

	private xfb0c927634a887df xb664a8c25c0c85cc;

	private string xe02f5a0888aae677;

	internal xfb0c927634a887df x69168101f53809d2 => xd2fe441f9b47eff7;

	internal xfb0c927634a887df x9a05d8dab0f0619f => x212ae880d15d2ed1;

	internal xfb0c927634a887df x70ff891026cb8704 => xb664a8c25c0c85cc;

	internal string xc085e830e777a251
	{
		get
		{
			return xe02f5a0888aae677;
		}
		set
		{
			xe02f5a0888aae677 = value;
		}
	}

	internal void x2a0cb95ab84ba877(xfb0c927634a887df x77c5a31ec0891f38, x6e414db5d060a816 x118938232dbd672b)
	{
		switch (x118938232dbd672b)
		{
		case x6e414db5d060a816.x12cb12b5d2cad53d:
			if (x212ae880d15d2ed1 != null)
			{
				throw new InvalidOperationException("Start value already initialized.");
			}
			x212ae880d15d2ed1 = x77c5a31ec0891f38;
			break;
		case x6e414db5d060a816.x9fd888e65466818c:
			if (xb664a8c25c0c85cc != null)
			{
				throw new InvalidOperationException("End value already initialized.");
			}
			xb664a8c25c0c85cc = x77c5a31ec0891f38;
			break;
		case x6e414db5d060a816.x865739e9b580d3cf:
			if (xd2fe441f9b47eff7 != null)
			{
				throw new InvalidOperationException("Master value already initialized.");
			}
			xd2fe441f9b47eff7 = x77c5a31ec0891f38;
			break;
		}
		x77c5a31ec0891f38.x7d2e50686d249839 = this;
	}

	internal x6e414db5d060a816 x8d113e0298810713(xfb0c927634a887df x77c5a31ec0891f38)
	{
		if (x77c5a31ec0891f38 == xd2fe441f9b47eff7)
		{
			return x6e414db5d060a816.x865739e9b580d3cf;
		}
		if (x77c5a31ec0891f38 == x212ae880d15d2ed1)
		{
			return x6e414db5d060a816.x12cb12b5d2cad53d;
		}
		if (x77c5a31ec0891f38 == xb664a8c25c0c85cc)
		{
			return x6e414db5d060a816.x9fd888e65466818c;
		}
		return x6e414db5d060a816.x4d0b9d4447ba7566;
	}
}
