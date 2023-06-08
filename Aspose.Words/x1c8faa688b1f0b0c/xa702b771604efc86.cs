using System.Drawing;
using x6c95d9cf46ff5f25;

namespace x1c8faa688b1f0b0c;

internal class xa702b771604efc86
{
	private readonly RectangleF xd8427cc4dda1bfb0 = RectangleF.Empty;

	private readonly bool xa21ac38bde2a77c5;

	private readonly string xbe39036341e55b02;

	public RectangleF x316e48914c4b28b5 => xd8427cc4dda1bfb0;

	public bool x23ae6e0c44b8e6a2 => xa21ac38bde2a77c5;

	public string x42f4c234c9358072 => xbe39036341e55b02;

	public xa702b771604efc86(RectangleF activeRect, string targetUri)
	{
		xd8427cc4dda1bfb0 = activeRect;
		if (x0d4d45882065c63e.xbf8774d82d777b9e(targetUri))
		{
			xa21ac38bde2a77c5 = true;
			xbe39036341e55b02 = x9a66d03de2ff27e1.x493eb1990ce18545(targetUri.Substring(1));
		}
		else
		{
			xa21ac38bde2a77c5 = false;
			xbe39036341e55b02 = targetUri;
		}
	}
}
