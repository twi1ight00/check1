using Aspose.Words;
using x28925c9b27b37a46;

namespace x13cd31bb39e0b7ea;

internal class x5916349e001c5709
{
	internal Comment x937e050c63ea1527;

	internal CommentRangeStart xb2aa25f342d8a7ea;

	internal CommentRangeEnd x84b5a4e4bf2cce0d;

	internal int x3654484eab05dbb6;

	internal bool x0437523424efa999 => xb2aa25f342d8a7ea != null;

	internal bool xd709943275ccfdc9 => x84b5a4e4bf2cce0d != null;

	internal bool x880cbff6b687171e
	{
		get
		{
			if (x0437523424efa999 && xd709943275ccfdc9)
			{
				return xb2aa25f342d8a7ea.ParentNode == x84b5a4e4bf2cce0d.ParentNode;
			}
			return false;
		}
	}

	internal bool x54e11e67f47d1b4b
	{
		get
		{
			if (!x880cbff6b687171e)
			{
				return false;
			}
			Node nextSibling = xb2aa25f342d8a7ea;
			while (nextSibling != null && nextSibling != x84b5a4e4bf2cce0d)
			{
				if (nextSibling.x2e39a445d52f6ea8() > 0)
				{
					return false;
				}
				nextSibling = nextSibling.NextSibling;
			}
			return true;
		}
	}

	internal void x76009e4e3065284b()
	{
		if (x937e050c63ea1527 != null)
		{
			((x8ad0c0863d1cd403)x937e050c63ea1527).x417a0a94031e7e8b = x3654484eab05dbb6;
		}
		if (xb2aa25f342d8a7ea != null)
		{
			xb2aa25f342d8a7ea.Id = x3654484eab05dbb6;
		}
		if (x84b5a4e4bf2cce0d != null)
		{
			x84b5a4e4bf2cce0d.Id = x3654484eab05dbb6;
		}
	}

	internal void x8f0ca6b4968b9d01()
	{
		if (xb2aa25f342d8a7ea != null)
		{
			if (xb2aa25f342d8a7ea.ParentNode != null)
			{
				xb2aa25f342d8a7ea.Remove();
			}
			xb2aa25f342d8a7ea = null;
		}
		if (x84b5a4e4bf2cce0d != null)
		{
			if (x84b5a4e4bf2cce0d.ParentNode != null)
			{
				x84b5a4e4bf2cce0d.Remove();
			}
			x84b5a4e4bf2cce0d = null;
		}
	}
}
