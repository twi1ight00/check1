using System;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x94af442f864d4b84 : xba15250b3f24fd3a
{
	internal int xf465816ce1e6196c;

	internal ushort x77fa6322561797a0;

	internal int xdeadd99a9c48a92b;

	internal x33fe617fac5d9812[] x380b1e4ecae13f99;

	internal static x94af442f864d4b84 x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75, int x6f8e54aeb8581116)
	{
		x94af442f864d4b84 x94af442f864d4b85 = new x94af442f864d4b84();
		x94af442f864d4b85.xf465816ce1e6196c = x6f8e54aeb8581116;
		x94af442f864d4b85.x77fa6322561797a0 = xe134235b3526fa75.xdb264d863790ee7b();
		int num = xe134235b3526fa75.x2e6b89ad8001e18f();
		x94af442f864d4b85.xdeadd99a9c48a92b = xe134235b3526fa75.x95ea7d23cc8ee04d();
		if (num < 0 || x94af442f864d4b85.xdeadd99a9c48a92b < x33fe617fac5d9812.xed219137e795f609(x6f8e54aeb8581116))
		{
			throw new InvalidOperationException("Unsupported hdmx table format.");
		}
		x94af442f864d4b85.x380b1e4ecae13f99 = new x33fe617fac5d9812[num];
		for (int i = 0; i < num; i++)
		{
			x94af442f864d4b85.x380b1e4ecae13f99[i] = x33fe617fac5d9812.x06b0e25aa6ad68a9(xe134235b3526fa75, x6f8e54aeb8581116, x94af442f864d4b85.xdeadd99a9c48a92b);
		}
		return x94af442f864d4b85;
	}

	internal override void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b)
	{
		xbdfb620b7167944b.xb0c682b9901a2443(x77fa6322561797a0);
		xbdfb620b7167944b.xab5f6b7526efa5be(x380b1e4ecae13f99.Length);
		xbdfb620b7167944b.x6ff7c65ed4805c27(xdeadd99a9c48a92b);
		for (int i = 0; i < x380b1e4ecae13f99.Length; i++)
		{
			x380b1e4ecae13f99[i].x6210059f049f0d48(xbdfb620b7167944b, xdeadd99a9c48a92b);
		}
	}

	internal void x6b4b68633a09765e()
	{
		xdeadd99a9c48a92b = x0d299f323d241756.x8b2ecf3d830a9342(x33fe617fac5d9812.xed219137e795f609(xf465816ce1e6196c), 4);
	}
}
