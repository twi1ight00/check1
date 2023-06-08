using System.Collections;
using x6c95d9cf46ff5f25;

namespace xfc5388ad7dff404f;

internal class x13a141f958daf286 : IEnumerable
{
	private readonly string x3d5336bba281e21a;

	private readonly xd345c73dd1b16b74 xb9252816d9de41bf;

	private readonly xd345c73dd1b16b74 x2aecc287898c8737;

	private int x63c1e46809a3387f = 1;

	public int xd44988f225497f3a => xb9252816d9de41bf.Count;

	public string xd1accc61de11e4ae => x3d5336bba281e21a;

	public x13a141f958daf286(string partName)
	{
		x3d5336bba281e21a = partName;
		xb9252816d9de41bf = new xd345c73dd1b16b74(isCaseSensitive: true);
		x2aecc287898c8737 = new xd345c73dd1b16b74(isCaseSensitive: false);
	}

	public string xd6b6ed77479ef68c(string x061610664b4c984f, string x7a6cd6daf4195b8a, bool x1bc1cc5e4fd586bf)
	{
		if (x1bc1cc5e4fd586bf)
		{
			if (x0d4d45882065c63e.x4602b59392dc27e9(x7a6cd6daf4195b8a))
			{
				x7a6cd6daf4195b8a = "file:///" + x7a6cd6daf4195b8a;
				x7a6cd6daf4195b8a = x0d4d45882065c63e.x8644581dcf469731(x7a6cd6daf4195b8a);
			}
		}
		else
		{
			x7a6cd6daf4195b8a = xada461b17cdccac0.x4063f4f83c7a7157(x3d5336bba281e21a, x7a6cd6daf4195b8a);
		}
		x5b6f1954712b741f x5b6f1954712b741f2 = (x5b6f1954712b741f)x2aecc287898c8737[x7a6cd6daf4195b8a];
		if (x5b6f1954712b741f2 != null)
		{
			return x5b6f1954712b741f2.xea1e81378298fa81;
		}
		string text = $"rId{x63c1e46809a3387f}";
		x63c1e46809a3387f++;
		xd6b6ed77479ef68c(text, x061610664b4c984f, x7a6cd6daf4195b8a, x1bc1cc5e4fd586bf);
		return text;
	}

	public void xd6b6ed77479ef68c(string xc06e652f250a3786, string x061610664b4c984f, string x7a6cd6daf4195b8a, bool x1bc1cc5e4fd586bf)
	{
		x5b6f1954712b741f value = new x5b6f1954712b741f(xc06e652f250a3786, x061610664b4c984f, x7a6cd6daf4195b8a, x1bc1cc5e4fd586bf);
		xb9252816d9de41bf[xc06e652f250a3786] = value;
		x2aecc287898c8737[x7a6cd6daf4195b8a] = value;
	}

	public x5b6f1954712b741f x212c1a2c5130b96e(string xeaf1b27180c0557b)
	{
		return (x5b6f1954712b741f)xb9252816d9de41bf[xeaf1b27180c0557b];
	}

	public x5b6f1954712b741f x6bd3b5840d6ee24a(string x43163d22e8cd5a71)
	{
		foreach (x5b6f1954712b741f value in xb9252816d9de41bf.GetValueList())
		{
			if (value.x3146d638ec378671 == x43163d22e8cd5a71)
			{
				return value;
			}
		}
		return null;
	}

	private IEnumerator x05b0b83b5e6c5de6()
	{
		return xb9252816d9de41bf.GetValueList().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x05b0b83b5e6c5de6
		return this.x05b0b83b5e6c5de6();
	}
}
