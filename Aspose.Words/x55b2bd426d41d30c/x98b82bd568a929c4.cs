using System.Collections;
using System.Reflection;
using xf9a9481c3f63a419;

namespace x55b2bd426d41d30c;

[DefaultMember("Item")]
internal class x98b82bd568a929c4 : IEnumerable
{
	private readonly IDictionary x82b70567a5f68f41;

	public int xd44988f225497f3a => x82b70567a5f68f41.Count;

	public x0ca5e8b532953a51 xe6d4b1b411ed94b5 => (x0ca5e8b532953a51)x82b70567a5f68f41[xc15bd84e01929885];

	public x98b82bd568a929c4()
	{
		x82b70567a5f68f41 = xd51c34d05311eee3.xdb04a310bbb29cff();
	}

	public void xd6b6ed77479ef68c(x0ca5e8b532953a51 xd7e5673853e47af4)
	{
		x82b70567a5f68f41.Add(xd7e5673853e47af4.x759aa16c2016a289, xd7e5673853e47af4);
	}

	public IEnumerator GetEnumerator()
	{
		return x82b70567a5f68f41.Values.GetEnumerator();
	}
}
