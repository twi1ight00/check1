using System.Collections;
using Aspose.Words;
using x28925c9b27b37a46;
using xf9a9481c3f63a419;

namespace x13cd31bb39e0b7ea;

internal class x04fb9568ed86f085
{
	private readonly IDictionary xc2ff212d15865ab5 = xd51c34d05311eee3.xdb04a310bbb29cff();

	private readonly IWarningCallback xa056586c1f99e199;

	internal IDictionary x05f339cb92407608 => xc2ff212d15865ab5;

	internal x04fb9568ed86f085(IWarningCallback warningCallback)
	{
		xa056586c1f99e199 = warningCallback;
	}

	internal VisitorAction xa2b18804731061bd(BookmarkStart xf602e1acaabe9019, StoryType xdbbf47b5e620c262)
	{
		if (xf602e1acaabe9019.Name.Length > 40)
		{
			x98b0e09ccece0a5a.x3dc950453374051a(xa056586c1f99e199, "Bookmark name exceeded maximum allowed length was truncated.");
			xf602e1acaabe9019.x54f99ef1e934e59c(xf602e1acaabe9019.Name.Substring(0, 40));
		}
		x5f4b07d961619146 x5f4b07d961619147 = (x5f4b07d961619146)xc2ff212d15865ab5[xf602e1acaabe9019.Name];
		if (x5f4b07d961619147 == null)
		{
			xc2ff212d15865ab5.Add(xf602e1acaabe9019.Name, new x5f4b07d961619146(xf602e1acaabe9019, null, xdbbf47b5e620c262));
			return VisitorAction.Continue;
		}
		xf602e1acaabe9019.Remove();
		xbbf9a1ead81dd3a1(WarningType.DataLoss, $"Bookmark with duplicated name '{xf602e1acaabe9019.Name}' was removed.");
		return VisitorAction.SkipThisNode;
	}

	internal VisitorAction x3c82d5a325e3a429(BookmarkEnd x4413c2b27218d7b7, StoryType xdbbf47b5e620c262)
	{
		if (x4413c2b27218d7b7.Name.Length > 40)
		{
			xbbf9a1ead81dd3a1(WarningType.DataLoss, "Bookmark name exceeded maximum allowed length was truncated.");
			x4413c2b27218d7b7.x54f99ef1e934e59c(x4413c2b27218d7b7.Name.Substring(0, 40));
		}
		x5f4b07d961619146 x5f4b07d961619147 = (x5f4b07d961619146)xc2ff212d15865ab5[x4413c2b27218d7b7.Name];
		if (x5f4b07d961619147 != null && x5f4b07d961619147.xb19f31e8e085a518 && x5f4b07d961619147.xef137c3ef3308b94 == xdbbf47b5e620c262)
		{
			x5f4b07d961619147.x1148fa1778bbfd56 = x4413c2b27218d7b7;
			return VisitorAction.Continue;
		}
		x4413c2b27218d7b7.Remove();
		xbbf9a1ead81dd3a1(WarningType.DataLoss, $"Bookmark '{x4413c2b27218d7b7.Name}' without corresponding BookmarkStart was removed.");
		return VisitorAction.SkipThisNode;
	}

	internal void x648a8aa88d1bbe19()
	{
		foreach (x5f4b07d961619146 value in xc2ff212d15865ab5.Values)
		{
			if (value.xb19f31e8e085a518)
			{
				xbbf9a1ead81dd3a1(WarningType.DataLoss, $"Bookmark '{value.x724e8b0eb9767138.Name}' without corresponding BookmarkEnd was removed.");
				value.x724e8b0eb9767138.Remove();
			}
		}
	}

	internal void xbbf9a1ead81dd3a1(WarningType x9f91de645a9fe01a, string xc2358fbac7da3d45)
	{
		if (xa056586c1f99e199 != null)
		{
			xa056586c1f99e199.Warning(new WarningInfo(x9f91de645a9fe01a, WarningSource.Validator, xc2358fbac7da3d45));
		}
	}
}
