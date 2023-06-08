using System.Collections;
using System.Reflection;

namespace x2a6f63b6650e76c4;

[DefaultMember("Item")]
internal class x83760f1ced087a09 : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal xddb28bb303a8678b xe6d4b1b411ed94b5 => (xddb28bb303a8678b)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal void xd6b6ed77479ef68c(xddb28bb303a8678b x28ebd0e348308467)
	{
		x82b70567a5f68f41.Add(x28ebd0e348308467);
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}
}
