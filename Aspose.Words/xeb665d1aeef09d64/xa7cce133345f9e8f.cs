using System.Collections;

namespace xeb665d1aeef09d64;

internal class xa7cce133345f9e8f : xe030f6981d09423d
{
	private static readonly Hashtable xd7b2016d8badc898;

	public xa7cce133345f9e8f()
		: base(xd7b2016d8badc898)
	{
	}

	static xa7cce133345f9e8f()
	{
		xd7b2016d8badc898 = new Hashtable();
		for (int i = 32; i <= 255; i++)
		{
			xd7b2016d8badc898.Add(i, i + 61440);
			xd7b2016d8badc898.Add(i + 61440, i);
		}
	}
}
