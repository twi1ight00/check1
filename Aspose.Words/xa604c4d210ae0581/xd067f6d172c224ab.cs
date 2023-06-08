using System.Collections;
using System.Reflection;

namespace xa604c4d210ae0581;

[DefaultMember("Item")]
internal class xd067f6d172c224ab
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	public xfc4c61079feab0be xe6d4b1b411ed94b5 => (xfc4c61079feab0be)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal void xd6b6ed77479ef68c(xfc4c61079feab0be xc303bb9e013a718f)
	{
		x82b70567a5f68f41.Add(xc303bb9e013a718f);
	}

	public IEnumerator x0df886665b5be89e()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}
}
