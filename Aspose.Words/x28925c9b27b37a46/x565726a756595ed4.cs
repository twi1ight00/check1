using System;
using Aspose.Words;

namespace x28925c9b27b37a46;

internal class x565726a756595ed4
{
	private readonly StyleIdentifier x0eaacd710747f0c4;

	private bool x7255a5813e71e9fc;

	private bool x4176e2f70fa05c1d;

	private bool x6e75d86e07e07fee;

	private int xb27bacee944055a0;

	private bool x16c01d3465569fed;

	internal StyleIdentifier x9a4aa9a3455eb440 => x0eaacd710747f0c4;

	internal bool x2d8aaa05bddcf40c
	{
		get
		{
			return x7255a5813e71e9fc;
		}
		set
		{
			x7255a5813e71e9fc = value;
		}
	}

	internal bool xebe0f6c7e6f4ae3a
	{
		get
		{
			return x4176e2f70fa05c1d;
		}
		set
		{
			x4176e2f70fa05c1d = value;
		}
	}

	internal bool x45101ac87546632f
	{
		get
		{
			return x6e75d86e07e07fee;
		}
		set
		{
			x6e75d86e07e07fee = value;
		}
	}

	internal int x9eb07da9aa5bbf9e
	{
		get
		{
			return xb27bacee944055a0;
		}
		set
		{
			xb27bacee944055a0 = value;
		}
	}

	internal bool x5356a3af7e7ecdfa
	{
		get
		{
			return x16c01d3465569fed;
		}
		set
		{
			x16c01d3465569fed = value;
		}
	}

	internal x565726a756595ed4(StyleIdentifier styleIdentifier, bool locked, bool quickFormat, bool semiHidden, int uiPriority, bool unhideWhenUsed)
	{
		if (styleIdentifier == StyleIdentifier.User)
		{
			throw new ArgumentOutOfRangeException("styleIdentifier");
		}
		x0eaacd710747f0c4 = styleIdentifier;
		xb27bacee944055a0 = uiPriority;
		x7255a5813e71e9fc = locked;
		x6e75d86e07e07fee = semiHidden;
		x16c01d3465569fed = unhideWhenUsed;
		x4176e2f70fa05c1d = quickFormat;
	}

	internal x565726a756595ed4 x8b61531c8ea35b85()
	{
		return (x565726a756595ed4)MemberwiseClone();
	}

	internal bool Equals(x565726a756595ed4 lsd)
	{
		if (lsd.x7255a5813e71e9fc == x7255a5813e71e9fc && lsd.x4176e2f70fa05c1d == x4176e2f70fa05c1d && lsd.x6e75d86e07e07fee == x6e75d86e07e07fee && lsd.xb27bacee944055a0 == xb27bacee944055a0)
		{
			return lsd.x16c01d3465569fed == x16c01d3465569fed;
		}
		return false;
	}
}
