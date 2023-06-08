using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;

namespace x13cd31bb39e0b7ea;

internal class x3e50ba9028aa4ca7
{
	private readonly DocumentBase x232be220f517f721;

	private readonly Hashtable xc79210451777a1c7 = new Hashtable();

	private readonly IWarningCallback xa056586c1f99e199;

	internal x3e50ba9028aa4ca7(DocumentBase doc, IWarningCallback warningCallback)
	{
		x232be220f517f721 = doc;
		x232be220f517f721.x0ba7c95e7dd1304b();
		xa056586c1f99e199 = warningCallback;
	}

	internal void x648a8aa88d1bbe19()
	{
		foreach (x5916349e001c5709 value in xc79210451777a1c7.Values)
		{
			if (value.x0437523424efa999 && !value.xd709943275ccfdc9)
			{
				x3dc950453374051a("CommentStart without corresponding CommentEnd was removed.");
				value.x8f0ca6b4968b9d01();
			}
			if (!value.x0437523424efa999 && value.xd709943275ccfdc9)
			{
				x3dc950453374051a("CommentEnd without corresponding CommentStart was removed.");
				value.x8f0ca6b4968b9d01();
			}
			if (value.x937e050c63ea1527 == null && value.x0437523424efa999 && value.xd709943275ccfdc9)
			{
				x3dc950453374051a("CommentRange without corresponding Comment was removed.");
				value.x8f0ca6b4968b9d01();
			}
			if (value.x54e11e67f47d1b4b)
			{
				x3dc950453374051a("Comment with empty CommentRange was removed.");
				value.x8f0ca6b4968b9d01();
			}
			if (value.x937e050c63ea1527 != null)
			{
				value.x937e050c63ea1527.xad2b66edfff52038 = value.x0437523424efa999 && value.xd709943275ccfdc9;
			}
			value.x76009e4e3065284b();
		}
	}

	internal VisitorAction x0a2f96470b05c54f(Comment x77c5a31ec0891f38)
	{
		x77c5a31ec0891f38.EnsureMinimum();
		x5916349e001c5709 x5916349e001c5710 = xd3cd191214cd3c12(x77c5a31ec0891f38.Id);
		if (x5916349e001c5710.x937e050c63ea1527 != null)
		{
			((x8ad0c0863d1cd403)x77c5a31ec0891f38).x417a0a94031e7e8b = x232be220f517f721.x8ef8795c4475a0e3();
		}
		else
		{
			x5916349e001c5710.x937e050c63ea1527 = x77c5a31ec0891f38;
		}
		return VisitorAction.Continue;
	}

	internal VisitorAction x66511c5e952e5fcb(CommentRangeStart x1ebe2b6d142c6e81)
	{
		x5916349e001c5709 x5916349e001c5710 = xd3cd191214cd3c12(x1ebe2b6d142c6e81.Id);
		if (x5916349e001c5710.x0437523424efa999)
		{
			x1ebe2b6d142c6e81.Remove();
			return VisitorAction.SkipThisNode;
		}
		x5916349e001c5710.xb2aa25f342d8a7ea = x1ebe2b6d142c6e81;
		return VisitorAction.Continue;
	}

	internal VisitorAction x057ef68b6193f0b3(CommentRangeEnd x95a427ccf20e4a25)
	{
		x5916349e001c5709 x5916349e001c5710 = xd3cd191214cd3c12(x95a427ccf20e4a25.Id);
		if (x5916349e001c5710.xd709943275ccfdc9 || !x5916349e001c5710.x0437523424efa999)
		{
			x95a427ccf20e4a25.Remove();
			return VisitorAction.SkipThisNode;
		}
		x5916349e001c5710.x84b5a4e4bf2cce0d = x95a427ccf20e4a25;
		return VisitorAction.Continue;
	}

	private x5916349e001c5709 xd3cd191214cd3c12(int xeaf1b27180c0557b)
	{
		x5916349e001c5709 x5916349e001c5710 = (x5916349e001c5709)xc79210451777a1c7[xeaf1b27180c0557b];
		if (x5916349e001c5710 == null)
		{
			x5916349e001c5710 = new x5916349e001c5709();
			x5916349e001c5710.x3654484eab05dbb6 = x232be220f517f721.x8ef8795c4475a0e3();
			xc79210451777a1c7[xeaf1b27180c0557b] = x5916349e001c5710;
		}
		return x5916349e001c5710;
	}

	private void x3dc950453374051a(string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(WarningType.UnexpectedContent, WarningSource.Unknown, xc2358fbac7da3d45));
		}
	}
}
