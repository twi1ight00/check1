using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x66dd9eaee57cfba4;

internal class x544bfb321207189e
{
	private const ushort xaee21e655b142a3a = 128;

	private const uint xbd39166c5398f403 = 2147483648u;

	private const uint x4b84b759189a656b = 770703360u;

	internal ushort x272bc993a9d89cb6;

	internal short x04be66f8aabdef90;

	internal ushort x38d4baa397019c83;

	internal ushort xfe64210561c806a1;

	internal ushort xf0c26ba5a725ab49;

	internal short x138f8f3344c83988;

	internal short xdb66cf45215884e3;

	internal short xb0d273755b0f6023;

	internal short xb4d0f84025a3a6eb;

	internal short x9e3e69a3475595eb;

	internal short xe0674d45db4757b9;

	internal short xe6790608b4586051;

	internal short x0a910e98c67c27f6;

	internal short xb22216c7fc819d19;

	internal short x9e62c39863c0c0d5;

	internal short x27e5f9045c4422a0;

	internal byte[] x39b30ae09a769112;

	internal uint xf41fa21937dcf3a1;

	internal uint x0009f6f683dde1c3;

	internal uint x957ffd1aa710cdce;

	internal uint x0209a9332d0e80f2;

	internal byte[] x974a4e4c489c1270;

	internal ushort x999b99e9928b906c;

	internal ushort xa9f8580ef0db1b52;

	internal ushort xd2822c636620bbc8;

	internal short xe7f4daf2bffbe4bf;

	internal short x3dc0f0b75cf5adfa;

	internal short xf63d44293279a976;

	internal ushort xd0b0427ee1010122;

	internal ushort x6b3b3a3faf27dfa9;

	internal uint x746dc1006969d0a5;

	internal uint xdfff435bd1452220;

	internal short x475cc1f1f8c27e13;

	internal short x655848db2af557bc;

	internal ushort x6feb3b8812acaee7;

	internal ushort x52b09432d205f4f2;

	internal ushort x587040ef87b313d6;

	internal bool xd6d3c04b6c9d936e => x26000ce44ebda9ea.x7bd02e5db572bb0e(x0009f6f683dde1c3, 770703360u);

	internal bool x831246fb77132649 => x26000ce44ebda9ea.x3c25c5b87860f214(x999b99e9928b906c, 128);

	internal bool x97a3eef828c0255f => x26000ce44ebda9ea.x7bd02e5db572bb0e(x746dc1006969d0a5, 2147483648u);

	internal FontStyle xfe2178c1f916f36c
	{
		get
		{
			FontStyle fontStyle = FontStyle.Regular;
			fontStyle |= ((((uint)x999b99e9928b906c & (true ? 1u : 0u)) != 0) ? FontStyle.Italic : FontStyle.Regular);
			fontStyle |= (((x999b99e9928b906c & 2u) != 0) ? FontStyle.Underline : FontStyle.Regular);
			fontStyle |= (((x999b99e9928b906c & 0x10u) != 0) ? FontStyle.Strikeout : FontStyle.Regular);
			return fontStyle | (((x999b99e9928b906c & 0x20u) != 0) ? FontStyle.Bold : FontStyle.Regular);
		}
	}

	internal x544bfb321207189e(xa8866d7566da0aa2 reader)
	{
		x272bc993a9d89cb6 = reader.xdb264d863790ee7b();
		x04be66f8aabdef90 = reader.x2e6b89ad8001e18f();
		x38d4baa397019c83 = reader.xdb264d863790ee7b();
		xfe64210561c806a1 = reader.xdb264d863790ee7b();
		xf0c26ba5a725ab49 = reader.xdb264d863790ee7b();
		x138f8f3344c83988 = reader.x2e6b89ad8001e18f();
		xdb66cf45215884e3 = reader.x2e6b89ad8001e18f();
		xb0d273755b0f6023 = reader.x2e6b89ad8001e18f();
		xb4d0f84025a3a6eb = reader.x2e6b89ad8001e18f();
		x9e3e69a3475595eb = reader.x2e6b89ad8001e18f();
		xe0674d45db4757b9 = reader.x2e6b89ad8001e18f();
		xe6790608b4586051 = reader.x2e6b89ad8001e18f();
		x0a910e98c67c27f6 = reader.x2e6b89ad8001e18f();
		xb22216c7fc819d19 = reader.x2e6b89ad8001e18f();
		x9e62c39863c0c0d5 = reader.x2e6b89ad8001e18f();
		x27e5f9045c4422a0 = reader.x2e6b89ad8001e18f();
		x39b30ae09a769112 = reader.x0f6807cca84a8e5b(10);
		xf41fa21937dcf3a1 = reader.x2aa9a7ff4efa6ddf();
		x0009f6f683dde1c3 = reader.x2aa9a7ff4efa6ddf();
		x957ffd1aa710cdce = reader.x2aa9a7ff4efa6ddf();
		x0209a9332d0e80f2 = reader.x2aa9a7ff4efa6ddf();
		x974a4e4c489c1270 = reader.x0f6807cca84a8e5b(4);
		x999b99e9928b906c = reader.xdb264d863790ee7b();
		xa9f8580ef0db1b52 = reader.xdb264d863790ee7b();
		xd2822c636620bbc8 = reader.xdb264d863790ee7b();
		xe7f4daf2bffbe4bf = reader.x2e6b89ad8001e18f();
		x3dc0f0b75cf5adfa = reader.x2e6b89ad8001e18f();
		xf63d44293279a976 = reader.x2e6b89ad8001e18f();
		xd0b0427ee1010122 = reader.xdb264d863790ee7b();
		x6b3b3a3faf27dfa9 = reader.xdb264d863790ee7b();
		if (x272bc993a9d89cb6 > 0)
		{
			x746dc1006969d0a5 = reader.x2aa9a7ff4efa6ddf();
			xdfff435bd1452220 = reader.x2aa9a7ff4efa6ddf();
			if (x272bc993a9d89cb6 > 1)
			{
				x475cc1f1f8c27e13 = reader.x2e6b89ad8001e18f();
				x655848db2af557bc = reader.x2e6b89ad8001e18f();
				x6feb3b8812acaee7 = reader.xdb264d863790ee7b();
				x52b09432d205f4f2 = reader.xdb264d863790ee7b();
				x587040ef87b313d6 = reader.xdb264d863790ee7b();
			}
		}
	}
}
