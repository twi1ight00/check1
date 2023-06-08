using x28925c9b27b37a46;

namespace Aspose.Words;

public class FootnoteOptions
{
	private readonly x38e21b53aa8148da xc454c03c23d4b4d9;

	private readonly bool x879af6d113f28c15;

	public FootnoteLocation Location
	{
		get
		{
			return (FootnoteLocation)xfe91eeeafcb3026a(2500);
		}
		set
		{
			xae20093bed1e48a8(2500, value);
		}
	}

	public NumberStyle NumberStyle
	{
		get
		{
			return (NumberStyle)xfe91eeeafcb3026a(2530);
		}
		set
		{
			xae20093bed1e48a8(2530, value);
		}
	}

	public int StartNumber
	{
		get
		{
			return (int)xfe91eeeafcb3026a(2520);
		}
		set
		{
			xae20093bed1e48a8(2520, value);
		}
	}

	public FootnoteNumberingRule RestartRule
	{
		get
		{
			return (FootnoteNumberingRule)xfe91eeeafcb3026a(2510);
		}
		set
		{
			xae20093bed1e48a8(2510, value);
		}
	}

	internal FootnoteOptions(x38e21b53aa8148da parent, FootnoteType footnoteType)
	{
		xc454c03c23d4b4d9 = parent;
		x879af6d113f28c15 = footnoteType == FootnoteType.Endnote;
	}

	private object xfe91eeeafcb3026a(int xba08ce632055a1d9)
	{
		if (x879af6d113f28c15)
		{
			xba08ce632055a1d9 += 100;
		}
		object obj = xc454c03c23d4b4d9.xb25c0862ce36b53c(xba08ce632055a1d9);
		if (obj == null)
		{
			return xc454c03c23d4b4d9.xe5b82b9f0104471f(xba08ce632055a1d9);
		}
		return obj;
	}

	private void xae20093bed1e48a8(int xba08ce632055a1d9, object xbcea506a33cf9111)
	{
		if (x879af6d113f28c15)
		{
			xba08ce632055a1d9 += 100;
		}
		xc454c03c23d4b4d9.xa2dc0badd30e7585(xba08ce632055a1d9, xbcea506a33cf9111);
	}
}
