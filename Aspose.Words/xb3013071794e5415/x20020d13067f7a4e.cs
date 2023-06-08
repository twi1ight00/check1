using System;
using System.Drawing;
using x1c8faa688b1f0b0c;
using x5794c252ba25e723;

namespace xb3013071794e5415;

internal class x20020d13067f7a4e
{
	private SizeF x3b77a41bd57164d6 = SizeF.Empty;

	private readonly xb8e7e788f6d59708 x315072802a4b347d;

	private float x2a14ba4b7e8a7c1f;

	internal xb8e7e788f6d59708 x14e70d9e1d43117a => x315072802a4b347d;

	internal SizeF x437e3b626c0fdd43 => x3b77a41bd57164d6;

	internal x20020d13067f7a4e()
	{
		x315072802a4b347d = new xb8e7e788f6d59708();
	}

	internal void xd7d75c376e5ae843(xb8e7e788f6d59708 xcbea4badf1c0a676, SizeF x6596328d88b6df5e)
	{
		xcbea4badf1c0a676.x52dde376accdec7d = new x54366fa5f75a02f7();
		xcbea4badf1c0a676.x52dde376accdec7d.xce92de628aa023cf(x2a14ba4b7e8a7c1f, 0f);
		x315072802a4b347d.xd6b6ed77479ef68c(xcbea4badf1c0a676);
		x2a14ba4b7e8a7c1f += x6596328d88b6df5e.Width;
		x3b77a41bd57164d6 = new SizeF(x2a14ba4b7e8a7c1f, Math.Max(x3b77a41bd57164d6.Height, x6596328d88b6df5e.Height));
	}
}
