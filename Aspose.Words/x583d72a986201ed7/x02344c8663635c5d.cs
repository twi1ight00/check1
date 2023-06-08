using System;

namespace x583d72a986201ed7;

internal class x02344c8663635c5d
{
	private readonly x829e0857a06af038 xec190681a67a9b92;

	private readonly string xed4a7b1500064e12;

	private readonly string[] xe5c119bbf35c0d0b;

	private int x6ef8ddf177fe4e6e;

	private x754c5b323f287239 xaa05464613f56b8c;

	private x754c5b323f287239 x6ee7371e5dca39a1;

	internal int x9d3073c05209cae2
	{
		get
		{
			return x6ef8ddf177fe4e6e;
		}
		set
		{
			x6ef8ddf177fe4e6e = value;
		}
	}

	internal x754c5b323f287239 x6d1fa38f0423e11b
	{
		get
		{
			return x6ee7371e5dca39a1;
		}
		set
		{
			x6ee7371e5dca39a1 = value;
		}
	}

	internal x754c5b323f287239 x283d882f626f891a
	{
		get
		{
			return xaa05464613f56b8c;
		}
		set
		{
			xaa05464613f56b8c = value;
		}
	}

	internal x829e0857a06af038 xdcf9aad638f5cf6f => xec190681a67a9b92;

	internal string xf9ad6fb78355fe13 => xed4a7b1500064e12;

	internal string[] x3c24f47680ce5966 => xe5c119bbf35c0d0b;

	internal int xb303fade4d4c5a50
	{
		get
		{
			if (!xec190681a67a9b92.xd625490738b93054)
			{
				return xe5c119bbf35c0d0b.Length - 1;
			}
			return 0;
		}
	}

	internal x02344c8663635c5d(x829e0857a06af038 numberingStyle, string[] numbers, string numberingText)
	{
		if (numberingStyle == null)
		{
			throw new ArgumentNullException("numberingStyle");
		}
		if (numbers == null)
		{
			throw new ArgumentNullException("numbers");
		}
		if (numberingText == null)
		{
			throw new ArgumentNullException("numberingText");
		}
		xec190681a67a9b92 = numberingStyle;
		xe5c119bbf35c0d0b = numbers;
		xed4a7b1500064e12 = numberingText;
	}

	internal bool xe4c57e682bcbf8f6(x02344c8663635c5d x5b0e49f41ffdca3a)
	{
		if (!xec190681a67a9b92.xf80e8a13daebb8f4 || xec190681a67a9b92 != x5b0e49f41ffdca3a.xdcf9aad638f5cf6f || !xec190681a67a9b92.xb983789489a1157b(xd1931adab4a3cc91()) || xe5c119bbf35c0d0b.Length - 1 != x5b0e49f41ffdca3a.x3c24f47680ce5966.Length)
		{
			return false;
		}
		for (int i = 0; i < xe5c119bbf35c0d0b.Length - 1; i++)
		{
			if (xe5c119bbf35c0d0b[i] != x5b0e49f41ffdca3a.x3c24f47680ce5966[i])
			{
				return false;
			}
		}
		return true;
	}

	internal bool xaf9d631233913bfe(x02344c8663635c5d x5b0e49f41ffdca3a)
	{
		if (xec190681a67a9b92 != x5b0e49f41ffdca3a.xdcf9aad638f5cf6f)
		{
			return false;
		}
		if (xec190681a67a9b92.xd625490738b93054)
		{
			return true;
		}
		if (xe5c119bbf35c0d0b.Length != x5b0e49f41ffdca3a.x3c24f47680ce5966.Length)
		{
			return false;
		}
		for (int i = 0; i < xe5c119bbf35c0d0b.Length - 1; i++)
		{
			if (xe5c119bbf35c0d0b[i] != x5b0e49f41ffdca3a.x3c24f47680ce5966[i])
			{
				return false;
			}
		}
		return xec190681a67a9b92.x181ceabdeeb62d2d(xd1931adab4a3cc91()) == x5b0e49f41ffdca3a.xd1931adab4a3cc91();
	}

	internal bool x2af9c342e0ce6158()
	{
		if (!xec190681a67a9b92.xd625490738b93054)
		{
			if (xe5c119bbf35c0d0b.Length == 1)
			{
				return xec190681a67a9b92.xb983789489a1157b(xe5c119bbf35c0d0b[0]);
			}
			return false;
		}
		return true;
	}

	internal string xd1931adab4a3cc91()
	{
		return xe5c119bbf35c0d0b[xe5c119bbf35c0d0b.Length - 1];
	}
}
