using System;
using x6c95d9cf46ff5f25;

namespace x4e7ae5a4b27b0834;

internal class x0da944b70fbbd699 : x3a5e4dec5f70539d
{
	private readonly x74fb8c43cb3523a2 xcc1ea44a98f440f2;

	private readonly xcb3ed34a3eba8ce2 x6ee2f36d8c0847a1;

	public x0da944b70fbbd699(xe2451c6b5635cb1b reader, xc1d5d8a4d3290c43 header, xcb3ed34a3eba8ce2 nameIndex, x74fb8c43cb3523a2 topDict, xcb3ed34a3eba8ce2 stringIndex, xcb3ed34a3eba8ce2 globalSubrIndex, xcb3ed34a3eba8ce2 charStringIndex, xb67de7dfc17262be charset)
		: base(header, nameIndex, topDict, stringIndex, globalSubrIndex, charStringIndex, charset)
	{
		if (topDict.xc675ae1e9b00827b == 0)
		{
			throw new InvalidOperationException("Invalid CFF data.");
		}
		reader.xcaa93d37b4fef121(topDict.xc675ae1e9b00827b);
		byte[] x88d77c00d1f = reader.x0f6807cca84a8e5b(topDict.x69f5565ac5a7693e);
		xcc1ea44a98f440f2 = x31c94dab5abeafcb.x1f490eac106aee12(x88d77c00d1f);
		if (xcc1ea44a98f440f2.xecb09bc6349dc3ea != 0)
		{
			reader.xcaa93d37b4fef121(topDict.xc675ae1e9b00827b + xcc1ea44a98f440f2.xecb09bc6349dc3ea);
			x6ee2f36d8c0847a1 = reader.x53d922d8067784fb();
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
		if (x6439f7732092858b == null)
		{
			xcb6243f33fefc8cf.xa620c027bb4fae7a();
		}
		if (x6ee2f36d8c0847a1 == null)
		{
			xcc1ea44a98f440f2.xabfd14aae5eacb70();
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
		xcb6243f33fefc8cf.x01833cfe9a0d0851 = num2 + num3;
		xcb6243f33fefc8cf.xc675ae1e9b00827b = xcb6243f33fefc8cf.x01833cfe9a0d0851 + xafebd1e80ffb55bd.x437e3b626c0fdd43;
		xcb6243f33fefc8cf.x69f5565ac5a7693e = xcc1ea44a98f440f2.x8c22d3d8d430813f();
		if (x6ee2f36d8c0847a1 != null)
		{
			xcc1ea44a98f440f2.xecb09bc6349dc3ea = xcb6243f33fefc8cf.x69f5565ac5a7693e;
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
		xafebd1e80ffb55bd.x6210059f049f0d48(xbdfb620b7167944b);
		xcc1ea44a98f440f2.x8d81a984b7f0332e(xb0c1b6e952349c8a);
		if (x6ee2f36d8c0847a1 != null)
		{
			x6ee2f36d8c0847a1.x6210059f049f0d48(xbdfb620b7167944b);
		}
	}
}
