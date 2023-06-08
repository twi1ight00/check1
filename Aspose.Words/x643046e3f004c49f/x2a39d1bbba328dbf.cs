using System.Collections;
using System.Reflection;

namespace x643046e3f004c49f;

[DefaultMember("Item")]
internal class x2a39d1bbba328dbf : IEnumerable
{
	private readonly ArrayList x82b70567a5f68f41;

	private readonly x9d6b37cac59aa2e2 x8a08cc7cfe65e03b;

	internal int xd44988f225497f3a => x82b70567a5f68f41.Count;

	internal x9d6b37cac59aa2e2 xe6d4b1b411ed94b5 => (x9d6b37cac59aa2e2)x82b70567a5f68f41[xc0c4c459c6ccbd00];

	internal x2a39d1bbba328dbf(x9d6b37cac59aa2e2 parentNode)
	{
		x82b70567a5f68f41 = new ArrayList();
		x8a08cc7cfe65e03b = parentNode;
	}

	internal void x52b190e626f65140(int xc0c4c459c6ccbd00)
	{
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e3 = null;
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e4 = null;
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e5 = (x9d6b37cac59aa2e2)x82b70567a5f68f41[xc0c4c459c6ccbd00];
		if (xc0c4c459c6ccbd00 > 0)
		{
			x9d6b37cac59aa2e4 = (x9d6b37cac59aa2e2)x82b70567a5f68f41[xc0c4c459c6ccbd00 - 1];
		}
		if (xc0c4c459c6ccbd00 < x82b70567a5f68f41.Count - 1)
		{
			x9d6b37cac59aa2e3 = (x9d6b37cac59aa2e2)x82b70567a5f68f41[xc0c4c459c6ccbd00 + 1];
		}
		x82b70567a5f68f41.RemoveAt(xc0c4c459c6ccbd00);
		if (x9d6b37cac59aa2e4 != null)
		{
			x9d6b37cac59aa2e4.x8385ef52c4ad91bc = x9d6b37cac59aa2e3;
		}
		if (x9d6b37cac59aa2e3 != null)
		{
			x9d6b37cac59aa2e3.xe34d6abf59682d24 = x9d6b37cac59aa2e4;
		}
		x9d6b37cac59aa2e5.xe34d6abf59682d24 = null;
		x9d6b37cac59aa2e5.x8385ef52c4ad91bc = null;
		x9d6b37cac59aa2e5.x8a08cc7cfe65e03b = null;
	}

	internal void x917b69030691beda(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		x9d6b37cac59aa2e2 x9d6b37cac59aa2e3 = null;
		if (x82b70567a5f68f41.Count > 0)
		{
			x9d6b37cac59aa2e3 = (x9d6b37cac59aa2e2)x82b70567a5f68f41[x82b70567a5f68f41.Count - 1];
		}
		x82b70567a5f68f41.Add(xda5bf54deb817e37);
		xda5bf54deb817e37.xe34d6abf59682d24 = x9d6b37cac59aa2e3;
		xda5bf54deb817e37.x8385ef52c4ad91bc = null;
		xda5bf54deb817e37.x8a08cc7cfe65e03b = x8a08cc7cfe65e03b;
		if (x9d6b37cac59aa2e3 != null)
		{
			x9d6b37cac59aa2e3.x8385ef52c4ad91bc = xda5bf54deb817e37;
		}
	}

	internal int x30eaba2971e72614(x9d6b37cac59aa2e2 xda5bf54deb817e37)
	{
		for (int i = 0; i < x82b70567a5f68f41.Count; i++)
		{
			if (xda5bf54deb817e37 == x82b70567a5f68f41[i])
			{
				return i;
			}
		}
		return -1;
	}

	private IEnumerator x05b0b83b5e6c5de6()
	{
		return x82b70567a5f68f41.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in x05b0b83b5e6c5de6
		return this.x05b0b83b5e6c5de6();
	}
}
