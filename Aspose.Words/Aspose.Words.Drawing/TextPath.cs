using x28925c9b27b37a46;
using x6c95d9cf46ff5f25;

namespace Aspose.Words.Drawing;

public class TextPath
{
	private readonly x7b71245a33212e76 xc454c03c23d4b4d9;

	public bool On
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(241);
		}
		set
		{
			xae20093bed1e48a8(241, value);
		}
	}

	public bool FitPath
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(247);
		}
		set
		{
			xae20093bed1e48a8(247, value);
		}
	}

	public bool FitShape
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(245);
		}
		set
		{
			xae20093bed1e48a8(245, value);
		}
	}

	public string FontFamily
	{
		get
		{
			return (string)xfe91eeeafcb3026a(197);
		}
		set
		{
			xae20093bed1e48a8(197, value);
		}
	}

	public double Size
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(195));
		}
		set
		{
			xae20093bed1e48a8(195, x4574ea26106f0edb.x091b250f00534aae(value));
		}
	}

	public bool Bold
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(250);
		}
		set
		{
			xae20093bed1e48a8(250, value);
		}
	}

	public bool Italic
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(251);
		}
		set
		{
			xae20093bed1e48a8(251, value);
		}
	}

	public bool SmallCaps
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(254);
		}
		set
		{
			xae20093bed1e48a8(254, value);
		}
	}

	public bool RotateLetters
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(242);
		}
		set
		{
			xae20093bed1e48a8(242, value);
		}
	}

	public bool Trim
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(246);
		}
		set
		{
			xae20093bed1e48a8(246, value);
		}
	}

	public bool Kerning
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(243);
		}
		set
		{
			xae20093bed1e48a8(243, value);
		}
	}

	public bool Shadow
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(253);
		}
		set
		{
			xae20093bed1e48a8(253, value);
		}
	}

	public bool Underline
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(252);
		}
		set
		{
			xae20093bed1e48a8(252, value);
		}
	}

	public bool StrikeThrough
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(255);
		}
		set
		{
			xae20093bed1e48a8(255, value);
		}
	}

	public bool SameLetterHeights
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(248);
		}
		set
		{
			xae20093bed1e48a8(248, value);
		}
	}

	public string Text
	{
		get
		{
			return (string)xfe91eeeafcb3026a(192);
		}
		set
		{
			x0d299f323d241756.x0aaaea7864a53f26(value, "value");
			xae20093bed1e48a8(192, value);
		}
	}

	public TextPathAlignment TextPathAlignment
	{
		get
		{
			return (TextPathAlignment)xfe91eeeafcb3026a(194);
		}
		set
		{
			xae20093bed1e48a8(194, value);
		}
	}

	public bool ReverseRows
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(240);
		}
		set
		{
			xae20093bed1e48a8(240, value);
		}
	}

	public double Spacing
	{
		get
		{
			return x4574ea26106f0edb.x97ab502db0c0e5c2((int)xfe91eeeafcb3026a(196));
		}
		set
		{
			xae20093bed1e48a8(196, x4574ea26106f0edb.x091b250f00534aae(value));
			xae20093bed1e48a8(244, true);
		}
	}

	public bool XScale
	{
		get
		{
			return (bool)xfe91eeeafcb3026a(249);
		}
		set
		{
			xae20093bed1e48a8(249, value);
		}
	}

	internal TextPath(x7b71245a33212e76 parent)
	{
		xc454c03c23d4b4d9 = parent;
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		return xc454c03c23d4b4d9.xfc928672852cc4c4(xba08ce632055a1d9);
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		xc454c03c23d4b4d9.x0817d5cde9e19bf6(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
