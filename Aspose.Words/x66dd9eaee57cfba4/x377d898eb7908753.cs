using System;
using System.Collections;
using System.Drawing;

namespace x66dd9eaee57cfba4;

internal class x377d898eb7908753
{
	private readonly string x911e3317ce57abd8;

	private readonly Hashtable x0723a61e89e53dc1;

	internal string x6054c4379c01a50d => x911e3317ce57abd8;

	internal int xd44988f225497f3a => x0723a61e89e53dc1.Count;

	internal x377d898eb7908753(string familyName)
	{
		x911e3317ce57abd8 = familyName;
		x0723a61e89e53dc1 = new Hashtable();
	}

	internal void xd6b6ed77479ef68c(x6b1a899052c71a60 x26094932cf7a9139)
	{
		x0723a61e89e53dc1[x26094932cf7a9139.xfe2178c1f916f36c] = x26094932cf7a9139;
	}

	internal x6b1a899052c71a60 xdc2247c8d4648ae8(FontStyle x44ecfea61c937b8e, bool xa456a0d7ead141be)
	{
		x6b1a899052c71a60 x6b1a899052c71a61 = (x6b1a899052c71a60)x0723a61e89e53dc1[x44ecfea61c937b8e];
		if (x6b1a899052c71a61 != null)
		{
			return x6b1a899052c71a61;
		}
		if (xa456a0d7ead141be)
		{
			return null;
		}
		FontStyle fontStyle = x44ecfea61c937b8e & ~FontStyle.Underline;
		x6b1a899052c71a61 = (x6b1a899052c71a60)x0723a61e89e53dc1[fontStyle];
		if (x6b1a899052c71a61 != null)
		{
			return x6b1a899052c71a61;
		}
		fontStyle = x44ecfea61c937b8e & ~FontStyle.Strikeout;
		x6b1a899052c71a61 = (x6b1a899052c71a60)x0723a61e89e53dc1[fontStyle];
		if (x6b1a899052c71a61 != null)
		{
			return x6b1a899052c71a61;
		}
		fontStyle = x44ecfea61c937b8e & ~FontStyle.Italic;
		x6b1a899052c71a61 = (x6b1a899052c71a60)x0723a61e89e53dc1[fontStyle];
		if (x6b1a899052c71a61 != null)
		{
			return x6b1a899052c71a61;
		}
		fontStyle = x44ecfea61c937b8e & ~FontStyle.Bold;
		x6b1a899052c71a61 = (x6b1a899052c71a60)x0723a61e89e53dc1[fontStyle];
		if (x6b1a899052c71a61 != null)
		{
			return x6b1a899052c71a61;
		}
		fontStyle = FontStyle.Regular;
		x6b1a899052c71a61 = (x6b1a899052c71a60)x0723a61e89e53dc1[fontStyle];
		if (x6b1a899052c71a61 != null)
		{
			return x6b1a899052c71a61;
		}
		IEnumerator enumerator = x0723a61e89e53dc1.Values.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				return (x6b1a899052c71a60)current;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		return null;
	}
}
