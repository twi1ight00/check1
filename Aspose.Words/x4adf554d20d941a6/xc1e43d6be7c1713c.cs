using System.Collections;
using Aspose;

namespace x4adf554d20d941a6;

internal abstract class xc1e43d6be7c1713c : xc63cc34daaa2e2d9
{
	private xc63cc34daaa2e2d9 xb82d10ba27e55223;

	private xc63cc34daaa2e2d9 xff28ca6af34bc066;

	internal xc63cc34daaa2e2d9 xa51d8d9790431b2b
	{
		get
		{
			return xb82d10ba27e55223;
		}
		set
		{
			xb82d10ba27e55223 = value;
		}
	}

	internal xc63cc34daaa2e2d9 x88fee64dba8223f9
	{
		get
		{
			return xff28ca6af34bc066;
		}
		set
		{
			xff28ca6af34bc066 = value;
		}
	}

	internal bool x909dc38ec7fc4d71 => null == xa51d8d9790431b2b;

	[JavaThrows(true)]
	internal override void x45a34609c70da3e5(xc63cc34daaa2e2d9 xd9ff4dee1dba180e, xc63cc34daaa2e2d9 xcc36986f44d69e8f, xc63cc34daaa2e2d9 x2612f62f94df47de)
	{
		if (xcc36986f44d69e8f == null && xd9ff4dee1dba180e == null && xa51d8d9790431b2b != null)
		{
			xcc36986f44d69e8f = xa51d8d9790431b2b;
		}
		if (xcc36986f44d69e8f != null)
		{
			x2612f62f94df47de.x3e8d56eefc6dfdad = xcc36986f44d69e8f.x3e8d56eefc6dfdad;
			x2612f62f94df47de.xbc13914359462815 = xcc36986f44d69e8f;
		}
		else if (xd9ff4dee1dba180e != null)
		{
			x2612f62f94df47de.x3e8d56eefc6dfdad = xd9ff4dee1dba180e;
			x2612f62f94df47de.xbc13914359462815 = xd9ff4dee1dba180e.xbc13914359462815;
		}
		if (x2612f62f94df47de.xbc13914359462815 != null)
		{
			x2612f62f94df47de.xbc13914359462815.x3e8d56eefc6dfdad = x2612f62f94df47de;
		}
		if (x2612f62f94df47de.x3e8d56eefc6dfdad != null)
		{
			x2612f62f94df47de.x3e8d56eefc6dfdad.xbc13914359462815 = x2612f62f94df47de;
		}
		if (xa51d8d9790431b2b == null || xa51d8d9790431b2b.x3e8d56eefc6dfdad == x2612f62f94df47de)
		{
			xa51d8d9790431b2b = x2612f62f94df47de;
		}
		if (x88fee64dba8223f9 == null || x88fee64dba8223f9.xbc13914359462815 == x2612f62f94df47de)
		{
			x88fee64dba8223f9 = x2612f62f94df47de;
		}
		x2612f62f94df47de.x332a8eedb847940d = this;
	}

	internal override void x9966dca653a8c1b8(xc63cc34daaa2e2d9 x2612f62f94df47de)
	{
		if (xa51d8d9790431b2b == x2612f62f94df47de)
		{
			xa51d8d9790431b2b = xa51d8d9790431b2b.xbc13914359462815;
		}
		if (x88fee64dba8223f9 == x2612f62f94df47de)
		{
			x88fee64dba8223f9 = x88fee64dba8223f9.x3e8d56eefc6dfdad;
		}
		if (x2612f62f94df47de.x3e8d56eefc6dfdad != null)
		{
			x2612f62f94df47de.x3e8d56eefc6dfdad.xbc13914359462815 = x2612f62f94df47de.xbc13914359462815;
		}
		if (x2612f62f94df47de.xbc13914359462815 != null)
		{
			x2612f62f94df47de.xbc13914359462815.x3e8d56eefc6dfdad = x2612f62f94df47de.x3e8d56eefc6dfdad;
		}
		x2612f62f94df47de.x3e8d56eefc6dfdad = null;
		x2612f62f94df47de.xbc13914359462815 = null;
		x2612f62f94df47de.x332a8eedb847940d = null;
		if (xa51d8d9790431b2b == null)
		{
			x52b190e626f65140();
		}
	}

	internal override IList x3616d1988aadef8a(xc63cc34daaa2e2d9 x62584df2cb5d40dd, xc63cc34daaa2e2d9 x2aa5114a5da7d6c8)
	{
		if (x62584df2cb5d40dd == null)
		{
			x62584df2cb5d40dd = xa51d8d9790431b2b;
		}
		ArrayList arrayList = new ArrayList();
		while (x62584df2cb5d40dd != null && x2aa5114a5da7d6c8 != x62584df2cb5d40dd)
		{
			arrayList.Add(x62584df2cb5d40dd);
			x62584df2cb5d40dd = x62584df2cb5d40dd.xbc13914359462815;
		}
		return arrayList;
	}

	internal override void x3df13c9311a0ba9b(xc63cc34daaa2e2d9 x0e990edf4549ee50)
	{
		base.x332a8eedb847940d.x45a34609c70da3e5(this, null, x8b61531c8ea35b85());
		if (x0e990edf4549ee50.xbc13914359462815 != null)
		{
			IList list = x3616d1988aadef8a(x0e990edf4549ee50.xbc13914359462815, null);
			for (int num = list.Count - 1; num >= 0; num--)
			{
				((xc63cc34daaa2e2d9)list[num]).x1914eddf1fde1228(null);
			}
		}
	}

	internal override void xd5da23b762ce52a2()
	{
		if (base.xbc13914359462815 != null)
		{
			x705ed5f9769744e5 = base.xbc13914359462815.x705ed5f9769744e5;
			IList list = base.xbc13914359462815.x3616d1988aadef8a(null, null);
			for (int i = 0; i < list.Count; i++)
			{
				((xc63cc34daaa2e2d9)list[i]).xcac6ac9df12a8893(null);
			}
		}
	}

	internal override void x633ccfccba9a2ba4()
	{
		for (xc63cc34daaa2e2d9 xc63cc34daaa2e2d10 = x88fee64dba8223f9; xc63cc34daaa2e2d10 != null; xc63cc34daaa2e2d10 = xc63cc34daaa2e2d10.x3e8d56eefc6dfdad)
		{
			xc63cc34daaa2e2d10.xbd829faf77014ec7();
		}
		for (xc63cc34daaa2e2d9 xc63cc34daaa2e2d11 = x88fee64dba8223f9; xc63cc34daaa2e2d11 != null; xc63cc34daaa2e2d11 = xc63cc34daaa2e2d11.x3e8d56eefc6dfdad)
		{
			xc63cc34daaa2e2d11.xbee71552c60a47bd();
		}
	}

	internal override void x7012609bcdb39574(x75b8b2f740aae644 x672ff13faf031f3d)
	{
		x672ff13faf031f3d.x99e63934692eac5f(this);
	}
}
