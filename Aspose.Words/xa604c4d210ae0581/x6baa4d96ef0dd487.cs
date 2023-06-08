using x16f9a31f749b8bb1;
using x6c95d9cf46ff5f25;

namespace xa604c4d210ae0581;

internal abstract class x6baa4d96ef0dd487
{
	private x0f8a9a895bdf560e xe1d718cca131846e;

	private x8c4ac77eaef388b9 xf02cf7d739dbf007;

	internal int xbe1e23e7d5b43370 => xf02cf7d739dbf007.xbe1e23e7d5b43370;

	internal void xd586e0c16bdae7fc(x0f8a9a895bdf560e x994e3cc0f99dd2dc, x6fa6e31d93cf837a xe83fbae1e983d207, int x2865e605e9fbfb80)
	{
		xe1d718cca131846e = x994e3cc0f99dd2dc;
		xf02cf7d739dbf007 = xe83fbae1e983d207.xca89f32a7f7f5d50(x2865e605e9fbfb80);
	}

	internal void xbf11ac143fca6897(int x2865e605e9fbfb80)
	{
		while (xf02cf7d739dbf007.xbe1e23e7d5b43370 == x2865e605e9fbfb80)
		{
			DoProcessTag(xe1d718cca131846e, xf02cf7d739dbf007.xd1bdf42207dd3638);
			if (xf02cf7d739dbf007.x0e410626c9576523)
			{
				break;
			}
			xf02cf7d739dbf007.x47f176deff0d42e2();
		}
	}

	protected abstract void DoProcessTag(x0f8a9a895bdf560e docReader, int itemIndex);
}
