using System;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x33fe617fac5d9812
{
	internal byte x7188c63c61c3d450;

	internal byte x1e5325ab72cf7ec9;

	internal byte[] x6a3e6a877109827c;

	internal static x33fe617fac5d9812 x06b0e25aa6ad68a9(xa8866d7566da0aa2 xe134235b3526fa75, int x6f8e54aeb8581116, int x8e9828bee2fd4844)
	{
		if (x8e9828bee2fd4844 < xed219137e795f609(x6f8e54aeb8581116))
		{
			throw new InvalidOperationException("Wrong hdmx device record size.");
		}
		x33fe617fac5d9812 x33fe617fac5d9813 = new x33fe617fac5d9812();
		x33fe617fac5d9813.x7188c63c61c3d450 = (byte)xe134235b3526fa75.x672ed37ee25c078c();
		x33fe617fac5d9813.x1e5325ab72cf7ec9 = (byte)xe134235b3526fa75.x672ed37ee25c078c();
		x33fe617fac5d9813.x6a3e6a877109827c = xe134235b3526fa75.x0f6807cca84a8e5b(x6f8e54aeb8581116);
		xe134235b3526fa75.x9e418ad9a56d1cf5.Position += x8e9828bee2fd4844 - xed219137e795f609(x6f8e54aeb8581116);
		return x33fe617fac5d9813;
	}

	internal void x6210059f049f0d48(x73087173962e3778 xbdfb620b7167944b, int x8e9828bee2fd4844)
	{
		if (x8e9828bee2fd4844 < xed219137e795f609(x6a3e6a877109827c.Length))
		{
			throw new InvalidOperationException("Wrong hdmx device record size.");
		}
		xbdfb620b7167944b.xc351d479ff7ee789(x7188c63c61c3d450);
		xbdfb620b7167944b.xc351d479ff7ee789(x1e5325ab72cf7ec9);
		xbdfb620b7167944b.x4c116b70372a3c6d(x6a3e6a877109827c);
		xbdfb620b7167944b.x9e418ad9a56d1cf5.Position += x8e9828bee2fd4844 - xed219137e795f609();
	}

	internal static int xed219137e795f609(int x6f8e54aeb8581116)
	{
		return x6f8e54aeb8581116 + 2;
	}

	internal int xed219137e795f609()
	{
		return xed219137e795f609(x6a3e6a877109827c.Length);
	}
}
