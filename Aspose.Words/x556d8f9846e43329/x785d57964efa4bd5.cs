using System.Collections;
using System.Reflection;
using x5794c252ba25e723;

namespace x556d8f9846e43329;

[DefaultMember("Item")]
internal class x785d57964efa4bd5
{
	private readonly ArrayList x416daa5f27da7c5c = new ArrayList();

	private readonly Hashtable x8759944ef132d9ef = new Hashtable();

	internal int xd44988f225497f3a => x416daa5f27da7c5c.Count;

	internal x26d9ecb4bdf0456d xe6d4b1b411ed94b5
	{
		get
		{
			if (xc0c4c459c6ccbd00 < 0 || xc0c4c459c6ccbd00 >= x416daa5f27da7c5c.Count)
			{
				return x26d9ecb4bdf0456d.x45260ad4b94166f2;
			}
			return (x26d9ecb4bdf0456d)x416daa5f27da7c5c[xc0c4c459c6ccbd00];
		}
	}

	internal x785d57964efa4bd5(bool addFirstEntry)
	{
		if (addFirstEntry)
		{
			xd6b6ed77479ef68c(x26d9ecb4bdf0456d.x45260ad4b94166f2);
		}
	}

	internal int xc15cf5804dbd5bbe(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		object obj = x8759944ef132d9ef[x6c50a99faab7d741];
		if (obj != null)
		{
			return (int)obj;
		}
		return xd6b6ed77479ef68c(x6c50a99faab7d741);
	}

	internal int xd6b6ed77479ef68c(x26d9ecb4bdf0456d x6c50a99faab7d741)
	{
		int num = x416daa5f27da7c5c.Add(x6c50a99faab7d741);
		x8759944ef132d9ef[x6c50a99faab7d741] = num;
		return num;
	}
}
