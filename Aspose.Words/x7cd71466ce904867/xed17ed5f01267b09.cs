using System;
using System.Collections;
using x4dc96876c552a593;

namespace x7cd71466ce904867;

internal class xed17ed5f01267b09 : x5e1f4fd20247e6da
{
	private readonly xe9a355a58980e0a4 xd995695f8e3419d6;

	private ArrayList xbe1b3879b7d92a27;

	public xed17ed5f01267b09(xe9a355a58980e0a4 serviceLocator)
	{
		xd995695f8e3419d6 = serviceLocator;
	}

	public ArrayList x6f1735600d67f8c8(xf5c6aa532fe023d4 x31e6518f5e08db6c)
	{
		xbe1b3879b7d92a27 = new ArrayList();
		foreach (x62d3f1339ed0fbcf item in x31e6518f5e08db6c.x0c560ee4a7223d6d)
		{
			if (item is x91f0f9c35f99edd9)
			{
				xdf2cafeb128b2de9((x91f0f9c35f99edd9)item);
			}
			else if (item is x1c56b7c63462bb5e)
			{
				x067f340610e55d0c((x1c56b7c63462bb5e)item);
			}
		}
		return xbe1b3879b7d92a27;
	}

	private void x067f340610e55d0c(x1c56b7c63462bb5e x4bbc2c453c470189)
	{
		xbe1b3879b7d92a27.Add(new xd6be391783172961(xd995695f8e3419d6));
	}

	private void xdf2cafeb128b2de9(x91f0f9c35f99edd9 xb0e5d73738e62f9e)
	{
		xd1d18a01676074c6 xd1d18a01676074c7 = null;
		if (xbe1b3879b7d92a27.Count > 0)
		{
			xd1d18a01676074c7 = (xd1d18a01676074c6)xbe1b3879b7d92a27[xbe1b3879b7d92a27.Count - 1];
		}
		x99b53760bae959e6 x99b53760bae959e7 = xd995695f8e3419d6.x323ed9f231847dea();
		x99b53760bae959e7.xfae21f55c59fd906(xb0e5d73738e62f9e);
		foreach (x06c9fc923c2ea3ef item in x99b53760bae959e7.xad6183fd48a39389)
		{
			if (xdffc5b8bf7073aa0(item, xd1d18a01676074c7))
			{
				xd1d18a01676074c7 = xddd600462bc32959(item);
			}
			((xa7f3a8645734d32e)xd1d18a01676074c7).xc288754f3b64ccca(item);
		}
	}

	private bool xdffc5b8bf7073aa0(x06c9fc923c2ea3ef x1461f66625b49913, xd1d18a01676074c6 xd0086c2dc4a1b300)
	{
		if (xd0086c2dc4a1b300 == null)
		{
			return true;
		}
		if (xd0086c2dc4a1b300.x3146d638ec378671 == x644902f73993c0f3.xe6e4072a65065ef9)
		{
			return true;
		}
		if (xd0086c2dc4a1b300.x3146d638ec378671 == x644902f73993c0f3.xe89828e8b8199286 && x1461f66625b49913.x77dc43988eaceb1c != 0)
		{
			return true;
		}
		if (xd0086c2dc4a1b300.x3146d638ec378671 == x644902f73993c0f3.x3e1feffd8ca6feb2 && x1461f66625b49913.x77dc43988eaceb1c != xd67056cdc9587a61.x3e1feffd8ca6feb2)
		{
			return true;
		}
		return false;
	}

	private xa7f3a8645734d32e xddd600462bc32959(x06c9fc923c2ea3ef x1461f66625b49913)
	{
		xa7f3a8645734d32e xa7f3a8645734d32e2 = x1461f66625b49913.x77dc43988eaceb1c switch
		{
			xd67056cdc9587a61.xe89828e8b8199286 => new xf0f6e7f2a5d46dcb(xd995695f8e3419d6), 
			xd67056cdc9587a61.x3e1feffd8ca6feb2 => new x3948d37420616164(xd995695f8e3419d6), 
			xd67056cdc9587a61.xcd42aad2332fa37b => new x3948d37420616164(xd995695f8e3419d6), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
		xbe1b3879b7d92a27.Add(xa7f3a8645734d32e2);
		return xa7f3a8645734d32e2;
	}
}
