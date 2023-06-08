using System.Collections;
using System.Reflection;

namespace x452f379ec5921195;

[DefaultMember("Item")]
internal class x9de623d45f7fa640 : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal x227665e444fb500a xe6d4b1b411ed94b5 => (x227665e444fb500a)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	internal void xd6b6ed77479ef68c(x227665e444fb500a x5319ac6190db58c3)
	{
		x82b70567a5f68f41.Add(x5319ac6190db58c3);
	}
}
