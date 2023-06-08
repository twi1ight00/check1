using System.Collections;
using System.Reflection;

namespace x79578da6a8a3ae37;

[DefaultMember("Item")]
internal class x24d0cd357ef39f75 : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal xe40873f9fe5f5022 xe6d4b1b411ed94b5 => (xe40873f9fe5f5022)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal x24d0cd357ef39f75 x8b61531c8ea35b85()
	{
		x24d0cd357ef39f75 x24d0cd357ef39f76 = new x24d0cd357ef39f75();
		foreach (xe40873f9fe5f5022 item in x82b70567a5f68f41)
		{
			x24d0cd357ef39f76.xd6b6ed77479ef68c(item.x8b61531c8ea35b85());
		}
		return x24d0cd357ef39f76;
	}

	internal void xd6b6ed77479ef68c(xe40873f9fe5f5022 x8ebde9a98df80374)
	{
		x82b70567a5f68f41.Add(x8ebde9a98df80374);
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}
}
