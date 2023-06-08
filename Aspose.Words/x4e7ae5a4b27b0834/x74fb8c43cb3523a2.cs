using System.Collections;
using System.IO;
using x6c95d9cf46ff5f25;

namespace x4e7ae5a4b27b0834;

internal class x74fb8c43cb3523a2
{
	internal const int xf3ddbbe613b56755 = 15;

	internal const int xc1bc7acab57f5e64 = 16;

	internal const int x5798b7c4ed30e2f5 = 17;

	internal const int x91a1085cf9b39ab7 = 18;

	internal const int xf43af0dae0873026 = 19;

	internal const int x2f5b98e9c3133fbf = 1230;

	internal const int x1e74391bfbf4f596 = 1236;

	internal const int x286a9792bd08dfb0 = 1237;

	internal const int xac2ac346161f82ff = 1220;

	private readonly Hashtable x802c86ffb5402a2c;

	public Hashtable x57bfe153dea0dabb => x802c86ffb5402a2c;

	public int x3631c0dbd50d3ed3
	{
		get
		{
			return x80a45f3d64735669(16, 0, 0);
		}
		set
		{
			x1913f230715effc9(16, value);
		}
	}

	public int x6c82f2cb74c578e3
	{
		get
		{
			return x80a45f3d64735669(15, 0, 0);
		}
		set
		{
			x1913f230715effc9(15, value);
		}
	}

	public int x01833cfe9a0d0851
	{
		get
		{
			return x80a45f3d64735669(17, 0, 0);
		}
		set
		{
			x1913f230715effc9(17, value);
		}
	}

	public int xc675ae1e9b00827b
	{
		get
		{
			return x80a45f3d64735669(18, 1, 0);
		}
		set
		{
			xd7227a06d1765953(18, value, 1, 2);
		}
	}

	public int x69f5565ac5a7693e
	{
		get
		{
			return x80a45f3d64735669(18, 0, 0);
		}
		set
		{
			xd7227a06d1765953(18, value, 0, 2);
		}
	}

	public bool x2290b7de491ba59a => x802c86ffb5402a2c.ContainsKey(1230);

	public int xecb09bc6349dc3ea
	{
		get
		{
			return x80a45f3d64735669(19, 0, 0);
		}
		set
		{
			x1913f230715effc9(19, value);
		}
	}

	public int xabcfc7c8b7a4689c
	{
		get
		{
			return x80a45f3d64735669(1236, 0, 0);
		}
		set
		{
			x1913f230715effc9(1236, value);
		}
	}

	public int x3a5fc9678df91f7a
	{
		get
		{
			return x80a45f3d64735669(1237, 0, 0);
		}
		set
		{
			x1913f230715effc9(1237, value);
		}
	}

	public x74fb8c43cb3523a2(Hashtable operators)
	{
		x802c86ffb5402a2c = operators;
	}

	public int x8c22d3d8d430813f()
	{
		return xbdc1ba5a08db0865().Length;
	}

	public byte[] xbdc1ba5a08db0865()
	{
		using MemoryStream memoryStream = new MemoryStream();
		x73087173962e3778 xbdfb620b7167944b = new x73087173962e3778(memoryStream);
		x8d81a984b7f0332e(xbdfb620b7167944b);
		return memoryStream.ToArray();
	}

	public void x8d81a984b7f0332e(x73087173962e3778 xbdfb620b7167944b)
	{
		x31c94dab5abeafcb.x8d81a984b7f0332e(xbdfb620b7167944b, this);
	}

	public void x08ede4aec50a7679()
	{
		x3a10e81e69e2e411(16);
	}

	public void xa620c027bb4fae7a()
	{
		x3a10e81e69e2e411(15);
	}

	public void xabfd14aae5eacb70()
	{
		x3a10e81e69e2e411(18);
	}

	public void x2256ddc96e2013a5()
	{
		x3a10e81e69e2e411(19);
	}

	private int x80a45f3d64735669(int x8b5085d6778ff74e, int x6b48c28c11c2ef62, int xc6e85c82d0d89508)
	{
		ArrayList arrayList = (ArrayList)x802c86ffb5402a2c[x8b5085d6778ff74e];
		if (arrayList != null)
		{
			return (int)arrayList[x6b48c28c11c2ef62];
		}
		return xc6e85c82d0d89508;
	}

	private void xdc617c2ebf850e06(int xba08ce632055a1d9, int x98d631affc6b9363)
	{
		ArrayList value = new ArrayList(new int[x98d631affc6b9363]);
		x802c86ffb5402a2c[xba08ce632055a1d9] = value;
	}

	private void x3a10e81e69e2e411(int xba08ce632055a1d9)
	{
		x802c86ffb5402a2c.Remove(xba08ce632055a1d9);
	}

	private void xd7227a06d1765953(int xba08ce632055a1d9, int xbcea506a33cf9111, int x6b48c28c11c2ef62, int x98d631affc6b9363)
	{
		if (!x802c86ffb5402a2c.ContainsKey(xba08ce632055a1d9))
		{
			xdc617c2ebf850e06(xba08ce632055a1d9, x98d631affc6b9363);
		}
		ArrayList arrayList = (ArrayList)x802c86ffb5402a2c[xba08ce632055a1d9];
		arrayList[x6b48c28c11c2ef62] = xbcea506a33cf9111;
	}

	private void x1913f230715effc9(int xba08ce632055a1d9, int xbcea506a33cf9111)
	{
		xd7227a06d1765953(xba08ce632055a1d9, xbcea506a33cf9111, 0, 1);
	}
}
