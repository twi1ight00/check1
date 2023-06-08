using x6c95d9cf46ff5f25;

namespace x28925c9b27b37a46;

internal abstract class x7f77ea92be0d9042 : x4c1e058c67948d6a
{
	private const int x1a3d26611fe656dc = 9999;

	internal bool x0f53f53f15b61ef5
	{
		get
		{
			x5fb16e270c21db2e x5fb16e270c21db2e2 = x5fb16e270c21db2e;
			if (x5fb16e270c21db2e2 != null)
			{
				return x5fb16e270c21db2e2.xdf4bcc85da8f85b2.xd44988f225497f3a > 0;
			}
			return false;
		}
	}

	internal bool x0392c0938d22c790 => x83da691dd3d974a6 != null;

	internal bool xba4e1d8a3e3316c8 => x18bb4aa7903ffced != null;

	internal bool xcb78713836fcc98a
	{
		get
		{
			if (!x0f53f53f15b61ef5 && !xba4e1d8a3e3316c8)
			{
				return x0392c0938d22c790;
			}
			return true;
		}
	}

	internal x5fb16e270c21db2e x5fb16e270c21db2e
	{
		get
		{
			return (x5fb16e270c21db2e)xf7866f89640a29a3(10010);
		}
		set
		{
			xae20093bed1e48a8(10010, value);
		}
	}

	internal xc1b2bac943a0f541 x83da691dd3d974a6
	{
		get
		{
			return (xc1b2bac943a0f541)xf7866f89640a29a3(12);
		}
		set
		{
			xae20093bed1e48a8(12, value);
		}
	}

	internal xc1b2bac943a0f541 x18bb4aa7903ffced
	{
		get
		{
			return (xc1b2bac943a0f541)xf7866f89640a29a3(14);
		}
		set
		{
			xae20093bed1e48a8(14, value);
		}
	}

	internal x7f77ea92be0d9042 x75eab24f5629a618
	{
		get
		{
			if (!x263d579af1d0d43f(9999))
			{
				return this;
			}
			return (x7f77ea92be0d9042)xf7866f89640a29a3(9999);
		}
		set
		{
			xae20093bed1e48a8(9999, value);
		}
	}

	internal void x097e4f3c708bd29c()
	{
		x52b190e626f65140(10010);
	}

	internal virtual void xcb395027497bc067()
	{
		x3b79c0ccf720b44f(-1, null);
	}

	protected void x3b79c0ccf720b44f(int x67e055991ce839a1, int[] x2a0ee5b1179ca446)
	{
		x5fb16e270c21db2e x5fb16e270c21db2e2 = x5fb16e270c21db2e;
		if (x5fb16e270c21db2e2 != null)
		{
			x7f77ea92be0d9042 xdf4bcc85da8f85b = x5fb16e270c21db2e2.xdf4bcc85da8f85b2;
			if (x67e055991ce839a1 >= 0 && xdf4bcc85da8f85b.xf7866f89640a29a3(x67e055991ce839a1) != null && x2a0ee5b1179ca446 != null)
			{
				object[] array = new object[x2a0ee5b1179ca446.Length];
				for (int i = 0; i < x2a0ee5b1179ca446.Length; i++)
				{
					array[i] = xf7866f89640a29a3(x2a0ee5b1179ca446[i]);
				}
				xa9d636b00ff486b7();
				for (int j = 0; j < x2a0ee5b1179ca446.Length; j++)
				{
					if (array[j] != null)
					{
						xae20093bed1e48a8(x2a0ee5b1179ca446[j], array[j]);
					}
				}
			}
			for (int k = 0; k < xdf4bcc85da8f85b.xd44988f225497f3a; k++)
			{
				xae20093bed1e48a8(xdf4bcc85da8f85b.xf15263674eb297bb(k), xdf4bcc85da8f85b.x6d3720b962bd3112(k));
			}
		}
		x52b190e626f65140(10010);
	}

	internal void x5406c7dbc2add337(x7f77ea92be0d9042 x50a18ad2656e7181)
	{
		for (int i = 0; i < x50a18ad2656e7181.xd44988f225497f3a; i++)
		{
			int xba08ce632055a1d = x50a18ad2656e7181.xf15263674eb297bb(i);
			xae20093bed1e48a8(xba08ce632055a1d, ((x09ce2c02826e31a6)x50a18ad2656e7181).get_xe6d4b1b411ed94b5(xba08ce632055a1d));
		}
	}
}
