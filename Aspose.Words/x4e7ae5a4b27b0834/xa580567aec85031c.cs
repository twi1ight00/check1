using System;
using System.Collections;
using x6c95d9cf46ff5f25;

namespace x4e7ae5a4b27b0834;

internal class xa580567aec85031c : x3a5e4dec5f70539d
{
	private readonly x9ee9b5f8dfb0e5db x53d060b49a9c2818;

	private readonly x74fb8c43cb3523a2[] x67460477d593cc2e;

	private readonly x74fb8c43cb3523a2[] x9c521f804a78fe85;

	private readonly xcb3ed34a3eba8ce2[] x726ba1d5f756fee0;

	public xa580567aec85031c(xe2451c6b5635cb1b reader, xc1d5d8a4d3290c43 header, xcb3ed34a3eba8ce2 nameIndex, x74fb8c43cb3523a2 topDict, xcb3ed34a3eba8ce2 stringIndex, xcb3ed34a3eba8ce2 globalSubrIndex, xcb3ed34a3eba8ce2 charStringIndex, xb67de7dfc17262be charset)
		: base(header, nameIndex, topDict, stringIndex, globalSubrIndex, charStringIndex, charset)
	{
		if (topDict.x3a5fc9678df91f7a == 0 || topDict.xabcfc7c8b7a4689c == 0)
		{
			throw new InvalidOperationException("Invalid CFF data.");
		}
		reader.xcaa93d37b4fef121(topDict.x3a5fc9678df91f7a);
		x53d060b49a9c2818 = x9ee9b5f8dfb0e5db.x06b0e25aa6ad68a9(reader, charStringIndex.x743de5a8c8cce84c);
		reader.xcaa93d37b4fef121(topDict.xabcfc7c8b7a4689c);
		xcb3ed34a3eba8ce2 xcb3ed34a3eba8ce3 = reader.x53d922d8067784fb();
		x67460477d593cc2e = new x74fb8c43cb3523a2[xcb3ed34a3eba8ce3.x743de5a8c8cce84c];
		x9c521f804a78fe85 = new x74fb8c43cb3523a2[xcb3ed34a3eba8ce3.x743de5a8c8cce84c];
		x726ba1d5f756fee0 = new xcb3ed34a3eba8ce2[xcb3ed34a3eba8ce3.x743de5a8c8cce84c];
		for (int i = 0; i < xcb3ed34a3eba8ce3.x743de5a8c8cce84c; i++)
		{
			x74fb8c43cb3523a2 x74fb8c43cb3523a3 = x31c94dab5abeafcb.x1f490eac106aee12(xcb3ed34a3eba8ce3.xe84e6ff66aac2a0e(i));
			x67460477d593cc2e[i] = x74fb8c43cb3523a3;
			if (x74fb8c43cb3523a3.xc675ae1e9b00827b == 0)
			{
				throw new InvalidOperationException("Invalid CFF data.");
			}
			reader.xcaa93d37b4fef121(x74fb8c43cb3523a3.xc675ae1e9b00827b);
			x74fb8c43cb3523a2 x74fb8c43cb3523a4 = x31c94dab5abeafcb.x1f490eac106aee12(reader.x0f6807cca84a8e5b(x74fb8c43cb3523a3.x69f5565ac5a7693e));
			x9c521f804a78fe85[i] = x74fb8c43cb3523a4;
			if (x74fb8c43cb3523a4.xecb09bc6349dc3ea != 0)
			{
				reader.xcaa93d37b4fef121(x74fb8c43cb3523a3.xc675ae1e9b00827b + x74fb8c43cb3523a4.xecb09bc6349dc3ea);
				x726ba1d5f756fee0[i] = reader.x53d922d8067784fb();
			}
			else
			{
				x726ba1d5f756fee0[i] = null;
			}
		}
	}

	public override void WriteToStream(x73087173962e3778 binaryWriter)
	{
		x1d7819db1e7bf43f();
		xb074016a522954c0();
		xc26afd5362f5c1ec(binaryWriter);
	}

	private void x1d7819db1e7bf43f()
	{
		xcb6243f33fefc8cf.x08ede4aec50a7679();
		xcb6243f33fefc8cf.xabfd14aae5eacb70();
		if (x6439f7732092858b == null)
		{
			xcb6243f33fefc8cf.xa620c027bb4fae7a();
		}
		for (int i = 0; i < x67460477d593cc2e.Length; i++)
		{
			x67460477d593cc2e[i].xa620c027bb4fae7a();
			x67460477d593cc2e[i].x08ede4aec50a7679();
			if (x726ba1d5f756fee0[i] == null)
			{
				x9c521f804a78fe85[i].x2256ddc96e2013a5();
			}
		}
	}

	private void xb074016a522954c0()
	{
		int x75a9c8b35c93c27a = xcb6243f33fefc8cf.x8c22d3d8d430813f();
		int num = xcb3ed34a3eba8ce2.x77df235b4d3e2bcd(1, x75a9c8b35c93c27a);
		int num2 = x1ea60bde2b5d0d28.x437e3b626c0fdd43 + x10b0407bbb8c5595.x437e3b626c0fdd43 + num + x847e0c79580546e9.x437e3b626c0fdd43 + xf77d029f36995cdf.x437e3b626c0fdd43;
		int num3 = 0;
		if (x6439f7732092858b != null)
		{
			xcb6243f33fefc8cf.x6c82f2cb74c578e3 = num2;
			num3 = x6439f7732092858b.x437e3b626c0fdd43;
		}
		xcb6243f33fefc8cf.x3a5fc9678df91f7a = num2 + num3;
		xcb6243f33fefc8cf.x01833cfe9a0d0851 = xcb6243f33fefc8cf.x3a5fc9678df91f7a + x53d060b49a9c2818.x437e3b626c0fdd43;
		xcb6243f33fefc8cf.xabcfc7c8b7a4689c = xcb6243f33fefc8cf.x01833cfe9a0d0851 + xafebd1e80ffb55bd.x437e3b626c0fdd43;
		int num4 = 0;
		for (int i = 0; i < x67460477d593cc2e.Length; i++)
		{
			num4 += x67460477d593cc2e[i].x8c22d3d8d430813f();
		}
		int num5 = xcb3ed34a3eba8ce2.x77df235b4d3e2bcd(x67460477d593cc2e.Length, num4);
		int num6 = xcb6243f33fefc8cf.xabcfc7c8b7a4689c + num5;
		for (int j = 0; j < x67460477d593cc2e.Length; j++)
		{
			x67460477d593cc2e[j].xc675ae1e9b00827b = num6;
			int num7 = x9c521f804a78fe85[j].x8c22d3d8d430813f();
			x67460477d593cc2e[j].x69f5565ac5a7693e = num7;
			int num8 = 0;
			if (x726ba1d5f756fee0[j] != null)
			{
				x9c521f804a78fe85[j].xecb09bc6349dc3ea = num7;
				num8 = x726ba1d5f756fee0[j].x437e3b626c0fdd43;
			}
			num6 += num7 + num8;
		}
	}

	private void xc26afd5362f5c1ec(x73087173962e3778 xb0c1b6e952349c8a)
	{
		xc0e60c4cd8683899 xbdfb620b7167944b = new xc0e60c4cd8683899(xb0c1b6e952349c8a);
		x1ea60bde2b5d0d28.x6210059f049f0d48(xbdfb620b7167944b);
		x10b0407bbb8c5595.x6210059f049f0d48(xbdfb620b7167944b);
		x17ac0ca5dbf357a8(xbdfb620b7167944b);
		x847e0c79580546e9.x6210059f049f0d48(xbdfb620b7167944b);
		xf77d029f36995cdf.x6210059f049f0d48(xbdfb620b7167944b);
		if (x6439f7732092858b != null)
		{
			x6439f7732092858b.x6210059f049f0d48(xbdfb620b7167944b);
		}
		x53d060b49a9c2818.x6210059f049f0d48(xbdfb620b7167944b);
		xafebd1e80ffb55bd.x6210059f049f0d48(xbdfb620b7167944b);
		xb15e94b0b335e9b8(xbdfb620b7167944b);
		for (int i = 0; i < x9c521f804a78fe85.Length; i++)
		{
			x9c521f804a78fe85[i].x8d81a984b7f0332e(xb0c1b6e952349c8a);
			if (x726ba1d5f756fee0[i] != null)
			{
				x726ba1d5f756fee0[i].x6210059f049f0d48(xbdfb620b7167944b);
			}
		}
	}

	private void xb15e94b0b335e9b8(xc0e60c4cd8683899 xbdfb620b7167944b)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < x67460477d593cc2e.Length; i++)
		{
			arrayList.Add(x67460477d593cc2e[i].xbdc1ba5a08db0865());
		}
		xcb3ed34a3eba8ce2 xcb3ed34a3eba8ce3 = new xcb3ed34a3eba8ce2(arrayList);
		xcb3ed34a3eba8ce3.x6210059f049f0d48(xbdfb620b7167944b);
	}
}
