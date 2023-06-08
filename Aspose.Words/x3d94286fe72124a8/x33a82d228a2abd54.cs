using System;
using x1c8faa688b1f0b0c;

namespace x3d94286fe72124a8;

internal class x33a82d228a2abd54 : IComparable
{
	private int x1036128c48c0d335;

	private xab391c46ff9a0a38[] x66dd11831843c614;

	internal int x479977869948f26a
	{
		get
		{
			return x1036128c48c0d335;
		}
		set
		{
			x1036128c48c0d335 = value;
		}
	}

	internal xab391c46ff9a0a38[] xaaa120d80a7ca164
	{
		get
		{
			return x66dd11831843c614;
		}
		set
		{
			x66dd11831843c614 = value;
		}
	}

	public int CompareTo(object obj)
	{
		if (obj is x33a82d228a2abd54)
		{
			return x1036128c48c0d335.CompareTo(((x33a82d228a2abd54)obj).x479977869948f26a);
		}
		throw new ArgumentException("object is not a PathInfo");
	}
}
