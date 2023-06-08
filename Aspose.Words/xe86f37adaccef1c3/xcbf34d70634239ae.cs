using System.Collections;
using System.Reflection;

namespace xe86f37adaccef1c3;

[DefaultMember("Item")]
internal class xcbf34d70634239ae : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41 = new ArrayList();

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal xc5c3f438428cb03b xe6d4b1b411ed94b5 => (xc5c3f438428cb03b)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal void xd6b6ed77479ef68c(xc5c3f438428cb03b xccb63ca5f63dc470)
	{
		x82b70567a5f68f41.Add(xccb63ca5f63dc470);
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}
}
