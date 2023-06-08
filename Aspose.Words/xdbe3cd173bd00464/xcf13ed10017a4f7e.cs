using Aspose.Words;
using x1a3e96f4b89a7a77;
using x381fb081d11d6275;

namespace xdbe3cd173bd00464;

internal class xcf13ed10017a4f7e : x05df33911093beb0
{
	private readonly x873451caae5ad4ae x800085dd555f7711;

	private readonly x68331b8428496f91 xa056586c1f99e199;

	internal xcf13ed10017a4f7e(x873451caae5ad4ae builder, x68331b8428496f91 warningCallback)
	{
		x800085dd555f7711 = builder;
		xa056586c1f99e199 = warningCallback;
	}

	protected override void WriteHyperlinkStartCore(string href, string target)
	{
		x800085dd555f7711.x2307058321cdb62f("Hyperlink");
		x800085dd555f7711.x943f6be3acf634db("NavigateUri", href);
	}

	protected override void WriteHyperlinkEndCore()
	{
		x800085dd555f7711.x2dfde153f4ef96d0();
	}

	protected override bool ValidateHyperlinkCore(string href, bool forceOutput)
	{
		bool flag = !href.StartsWith("#");
		if (!flag)
		{
			xa056586c1f99e199.xbbf9a1ead81dd3a1(WarningType.DataLossCategory, "Bookmarks are not supported in XAML, so hyperlinks to bookmarks will not be exported.");
		}
		return flag;
	}

	protected override string CorrectHref(string href)
	{
		return href;
	}
}
