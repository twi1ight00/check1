using System;

namespace x59d6a4fc5007b7a4;

internal class x7bc8e2bdb755f2f0
{
	private int xaabccab0c06d038b;

	private string xf7bbe199f47f234d;

	internal int x504f3d4040b356d7
	{
		get
		{
			return xaabccab0c06d038b;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			xaabccab0c06d038b = value;
		}
	}

	internal string x238bf167ccfdd282
	{
		get
		{
			return xf7bbe199f47f234d;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			xf7bbe199f47f234d = value;
		}
	}

	internal x7bc8e2bdb755f2f0(int level, string description)
	{
		x504f3d4040b356d7 = level;
		x238bf167ccfdd282 = description;
	}
}
