using System.Collections;

namespace x4adf554d20d941a6;

internal class xeae7c7333b3d6e96 : IEnumerable
{
	private readonly ArrayList xba505b457f56974b = new ArrayList();

	public IEnumerator GetEnumerator()
	{
		return xba505b457f56974b.GetEnumerator();
	}

	internal x109e3389933c23a8 x2a0cb95ab84ba877(x109e3389933c23a8 xdcf7b74ddd6caa25)
	{
		x109e3389933c23a8 x109e3389933c23a9 = x9855ab6e5b20ac8b(xdcf7b74ddd6caa25);
		if (x109e3389933c23a9 == null)
		{
			xba505b457f56974b.Add(xdcf7b74ddd6caa25);
			x109e3389933c23a9 = xdcf7b74ddd6caa25;
		}
		return x109e3389933c23a9;
	}

	internal void x73f63188bdafaeb6()
	{
		for (int num = xba505b457f56974b.Count - 1; num >= 0; num--)
		{
			x109e3389933c23a8 x109e3389933c23a9 = xaadb22af27962896(num);
			if (x109e3389933c23a9.xbd46d5308b22d9fd)
			{
				xba505b457f56974b.RemoveAt(num);
			}
		}
	}

	private x109e3389933c23a8 x9855ab6e5b20ac8b(x109e3389933c23a8 xdcf7b74ddd6caa25)
	{
		foreach (object item in xba505b457f56974b)
		{
			x109e3389933c23a8 x109e3389933c23a9 = (x109e3389933c23a8)item;
			if (xdcf7b74ddd6caa25.xa8337de37ecaeb68(x109e3389933c23a9))
			{
				return x109e3389933c23a9;
			}
		}
		return null;
	}

	private x109e3389933c23a8 xaadb22af27962896(int xc0c4c459c6ccbd00)
	{
		return (x109e3389933c23a8)xba505b457f56974b[xc0c4c459c6ccbd00];
	}
}
